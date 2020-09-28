Imports Helios.Cont.Business.Entity.BaseBE
Imports Helios.General
Imports Helios.Cont.Business.Entity

Imports Helios.Cont.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping


Public Class frmEnvioExistencia
    Inherits frmMaster

    Public Property Movimiento As String

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GetCMBMeses()
        CargarCMB()
    End Sub

#Region "Métodos"

    Private Sub GetCMBMeses()
        Dim listaAnios As New empresaPeriodoSA
        cboAnio.DisplayMember = "periodo"
        cboAnio.ValueMember = "periodo"
        cboAnio.DataSource = listaAnios.GetListar_empresaPeriodo(New empresaPeriodo With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})
        cboAnio.Text = DateTime.Now.Year

        cboMesCompra.DisplayMember = "Mes"
        cboMesCompra.ValueMember = "Codigo"
        cboMesCompra.DataSource = ListaDeMeses()
        cboMesCompra.SelectedValue = String.Format("{0:00}", DateTime.Now)
    End Sub

    Sub GetDiasMes(mes As Integer, anio As Integer)
        Dim days As Integer = System.DateTime.DaysInMonth(anio, mes)
        TxtDia.MaxValue = days
        TxtDia.MinValue = 1

    End Sub

    Public Sub CargarCMB()
        Dim estableSA As New establecimientoSA

        cboEstable.DisplayMember = "nombre"
        cboEstable.ValueMember = "idCentroCosto"
        cboEstable.DataSource = estableSA.ObtenerListaEstablecimientos(Gempresas.IdEmpresaRuc).Where(Function(o) o.TipoEstab = "UN").ToList
        cboEstable.SelectedValue = GEstableciento.IdEstablecimiento

    End Sub
#End Region

    Private Sub cboMesCompra_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboMesCompra.SelectedValueChanged
        If Not IsNothing(cboMesCompra.SelectedValue) Then
            If TxtDia.Text.Trim.Length > 0 Then
                GetDiasMes(Integer.Parse(cboMesCompra.SelectedValue), cboAnio.Text)
            Else
                GetDiasMes(Integer.Parse(cboMesCompra.SelectedValue), cboAnio.Text)
                TxtDia.Clear()
            End If
        End If
    End Sub

    Private Sub cboAnio_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboAnio.SelectedValueChanged
        If cboAnio.Text.Trim.Length > 0 Then
            TxtDia_TextChanged(sender, e)
        End If
    End Sub

    Private Sub frmDistribucionMasiva_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmDistribucionMasiva_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'txtFecha.Value = New DateTime(AnioGeneral, MesGeneral, DateTime.Now.Date.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0)
        '  txtFechaVcto.Value = Date.Now
    End Sub

    Private Sub cboEstable_Click(sender As Object, e As EventArgs) Handles cboEstable.Click

    End Sub

    Private Sub cboEstable_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEstable.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        Dim codEstable = cboEstable.SelectedValue
        If IsNumeric(codEstable) Then
            Dim almacenSA As New almacenSA
            cboAlmacen.DisplayMember = "descripcionAlmacen"
            cboAlmacen.ValueMember = "idAlmacen"
            cboAlmacen.DataSource = almacenSA.GetListar_almacenExceptAV(codEstable)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Close()
    End Sub

    Private Sub ButtonAdv15_Click(sender As Object, e As EventArgs) Handles ButtonAdv15.Click
        Dim envio As New EnvioExistencia
        Dim empresaPeriodoSA As New empresaCierreMensualSA
        Try
            If TxtDia.Text.Trim.Length = 0 Then
                MessageBox.Show("Debe ingresar la fecha de envío", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TxtDia.Select()
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            If Not txtSerie.Text.Trim.Length > 0 Then
                MessageBox.Show("Ingrese la serie de la guía", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtSerie.Select()
                txtSerie.Focus()
                Exit Sub
            End If

            If Not txtNumero.Text.Trim.Length > 0 Then
                MessageBox.Show("Ingrese el número de guía", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtNumero.Select()
                txtNumero.Focus()
                Exit Sub
            End If

            Dim fechaEnvio As New Date(cboAnio.Text, Integer.Parse(cboMesCompra.SelectedValue), TxtDia.Text)

            Dim fechaAnt = New Date(fechaEnvio.Year, CInt(fechaEnvio.Month), 1)
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                Cursor = Cursors.Default
                Exit Sub
            End If

            Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaEnvio.Year, .mes = fechaEnvio.Month})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realizar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Cursor = Cursors.Default
                    Exit Sub
                End If
            End If

            Select Case Movimiento
                Case "Parcial"

                    envio = New EnvioExistencia With
                        {
                            .FechaEnvio = fechaEnvio,
                            .TipoDoc = "99",
                            .Serie = txtSerie.Text.Trim,
                            .Numero = txtNumero.Text.Trim,
                            .Almacen = cboAlmacen.SelectedValue
                        }
                    Me.Tag = envio
                    Dispose()

                Case Else

                    If Not cboAlmacen.SelectedIndex > -1 Then
                        MessageBox.Show("Ingrese el almacen de destino de la existencia!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        cboAlmacen.Select()
                        cboAlmacen.Focus()
                        Exit Sub
                    End If

                    envio = New EnvioExistencia With
                            {
                                .FechaEnvio = fechaEnvio,
                                .TipoDoc = "99",
                                .Serie = txtSerie.Text.Trim,
                                .Numero = txtNumero.Text.Trim,
                                .Almacen = cboAlmacen.SelectedValue
                            }
                    Me.Tag = envio
                    Dispose()
            End Select

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Me.Tag = Nothing
        End Try
    End Sub

    Private Sub txtSerie_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSerie.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                txtNumero.Select()
            End If
        Catch ex As Exception
            txtSerie.Clear()
        End Try

    End Sub

    Private Sub txtSerie_LostFocus(sender As Object, e As EventArgs) Handles txtSerie.LostFocus
        'Try
        '    If txtSerie.Text.Trim.Length > 0 Then
        '        '  If chFormato.Checked = True Then
        '        txtSerie.Text = String.Format("{0:00000}", Convert.ToInt32(txtSerie.Text))
        '        'End If
        '    End If

        'Catch ex As Exception

        '    If IsNumeric(Microsoft.VisualBasic.Mid(Trim(txtSerie.Text), 2, 1)) = True Then

        '        If IsNumeric(Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 1)) = True Then

        '            If Not IsNumeric(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1)) = True Then

        '                If Len(txtSerie.Text) <= 2 Then

        '                    txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + "000" + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 1))

        '                ElseIf Len(txtSerie.Text) <= 3 Then

        '                    txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + "00" + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 2))

        '                ElseIf Len(txtSerie.Text) <= 4 Then

        '                    txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + "0" + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 3))

        '                ElseIf Len(txtSerie.Text) <= 5 Then

        '                    txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 4))

        '                End If
        '            End If
        '        Else

        '            txtSerie.Select()
        '            txtSerie.Focus()
        '            txtSerie.Clear()
        '            MessageBox.Show("INGRESE PRIMERO SOLO UNA LETRA SEGUIDO DE UN NUMERO")

        '        End If

        '    Else

        '        txtSerie.Select()
        '        txtSerie.Focus()
        '        txtSerie.Clear()
        '        MessageBox.Show("INGRESE PRIMERO SOLO UNA LETRA SEGUIDO DE UN NUMERO")

        '    End If

        'End Try
    End Sub

    Private Sub txtSerie_TextChanged(sender As Object, e As EventArgs) Handles txtSerie.TextChanged

    End Sub

    Private Sub txtNumero_LostFocus(sender As Object, e As EventArgs) Handles txtNumero.LostFocus
        'Try
        '    If txtNumero.Text.Trim.Length > 0 Then
        '        '    If chFormato.Checked = True Then
        '        If txtNumero.Text.Contains(".") Then
        '            txtNumero.Text.Replace(".", "")
        '        End If

        '        txtNumero.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumero.Text))

        '        'End If
        '    End If
        'Catch ex As Exception
        '    txtNumero.Select()
        '    txtNumero.Focus()
        '    txtNumero.Clear()
        'End Try

    End Sub

    Private Sub txtNumero_TextChanged(sender As Object, e As EventArgs) Handles txtNumero.TextChanged

    End Sub

    'Private Sub txtFecha_ValueChanged(sender As Object, e As EventArgs)
    '    If IsDate(txtFecha.Value) Then
    '        If txtFecha.Value.Date > DiaLaboral.Date Then
    '            txtFecha.Value = DiaLaboral
    '            MessageBox.Show("Debe respetar la fecha laboral o fechas inferiores a esta.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        End If
    '    End If
    'End Sub

    Private Sub cboAsignacion_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TxtDia_TextChanged(sender As Object, e As EventArgs) Handles TxtDia.TextChanged
        If cboMesCompra.Text.Trim.Length > 0 Then

        End If
    End Sub

    'Private Sub cboAsignacion_SelectedValueChanged(sender As Object, e As EventArgs)
    '    Select Case cboAsignacion.Text
    '        Case "POR LOTES"
    '            txtNroLote.Clear()
    '            txtNroLote.Enabled = True
    '            txtFechaVcto.Enabled = True
    '        Case "LOTE EXISTENTE"

    '        Case "CONTROL POR COMPROBANTE"
    '            txtNroLote.Clear()
    '            txtNroLote.Enabled = False
    '            txtFechaVcto.Enabled = False
    '    End Select
    'End Sub
End Class
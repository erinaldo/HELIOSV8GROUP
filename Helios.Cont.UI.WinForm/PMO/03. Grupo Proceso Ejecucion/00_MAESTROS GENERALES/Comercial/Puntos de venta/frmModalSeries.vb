Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmModalSeries
    Enum action
        SerieActivada = 1
        SerieDesactivada = 0
    End Enum
#Region "métodos"

    Enum Manipulacion
        Eliminar = 0
        Grabar = 1
        Editar = 2
        Nuevo = 3
        Situacion = 4
    End Enum

    Public Sub AnclarNumeracion()

        Dim objNumeroEO As New numeracionBoletas
        Dim numeracionSA As New NumeracionBoletaSA
        Try
            With objNumeroEO
                .empresa = Gempresas.IdEmpresaRuc
                .establecimiento = GEstableciento.IdEstablecimiento
                .tipo = lsvNumeracion.SelectedItems(0).SubItems(1).Text
                .serie = lsvNumeracion.SelectedItems(0).SubItems(2).Text
                .anclado = "S"
            End With
            numeracionSA.UpdatePredeterminadoAll(objNumeroEO)
            lblEstado.Text = "Registro actualizado correctamente"
            lblEstado.Image = My.Resources.ok4
        Catch ex As Exception
            MsgBox("No se pudo grabar el numero de serie.", MsgBoxStyle.Critical, "Aviso del Sistema!")
        End Try
    End Sub

    Public Sub HaveConfiguracion(ByVal strIdEmpresa As String, ByVal intidEstablecimiento As Integer, ByVal strSerie As String)
        Dim numeracionSA As New NumeracionBoletaSA
        Dim ExisteConf As Boolean = False
        Try
            ExisteConf = numeracionSA.GetTieneConfiguracion(strIdEmpresa, intidEstablecimiento, strSerie)

            If ExisteConf = True Then
                lblEstado.Text = "Serie habilitada."
                lblEstado.ForeColor = Color.Green
                lblEstado.Tag = action.SerieActivada
            Else
                lblEstado.Text = "no tiene configuración."
                lblEstado.ForeColor = Color.Red
                lblEstado.Tag = action.SerieDesactivada
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub GrabarNumeracion()
        Dim numeracionSA As New NumeracionBoletaSA
        Dim objSerie As New numeracionBoletas
        With objSerie
            .codigoNumeracion = "VENTA"
            .tipo = IIf(rbFac.Checked = True, "FAC", "BOL")
            .serie = txtSerieSel.Text
            '     .ValorInicial = nudinicio.Value
            .empresa = Gempresas.IdEmpresaRuc
            .establecimiento = GEstableciento.IdEstablecimiento
            .valorMinimo = nudinicio.Value
            .valorInicial = 0
            '.Serie = txtSerie.Text.Trim
            .valorMaximo = nudMaximo.Value
            .incremento = nudincremento.Value
            .anclado = "N"
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = Date.Now
        End With
        numeracionSA.InsertNumBoletas(objSerie)
        lblEstado.Text = "Número de serie grabada correctamente!"
        lblEstado.Image = My.Resources.ok4
        ObtenerSeriesEE(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
        btnRegistrar.Enabled = False

        'Else
        'MsgBox("El número de serie ya existe, ingrese otro!", MsgBoxStyle.Critical, "Aviso del sistema!")
        'End If
    End Sub

    Public Sub ObtenerNumeracionEE(ByVal strIdEmpresa As String, ByVal intidEstablecimiento As Integer)
        Dim numeracionSA As New NumeracionBoletaSA
        Try
            lsvNumeracion.Columns.Clear()
            lsvNumeracion.Items.Clear()
            lsvNumeracion.Columns.Add("ID", 0) '0
            lsvNumeracion.Columns.Add("Doc", 50) '01
            lsvNumeracion.Columns.Add("Serie", 60) '02
            lsvNumeracion.Columns.Add("Valor Actual", 60) '03
            lsvNumeracion.Columns.Add("Incremento", 0) '04
            lsvNumeracion.Columns.Add("Máximo", 0) '05
            lsvNumeracion.Columns.Add("Anclado", 40) '06

            For Each i As numeracionBoletas In numeracionSA.ObtenerNumeracionEES(strIdEmpresa, intidEstablecimiento, lsvSerie.SelectedItems(0).SubItems(0).Text)
                Dim n As New ListViewItem(i.codigoNumeracion)
                n.SubItems.Add(i.tipo)
                n.SubItems.Add(i.serie)
                n.SubItems.Add(i.valorInicial)
                n.SubItems.Add(i.incremento)
                n.SubItems.Add(i.valorMaximo)
                n.SubItems.Add(i.anclado)
                lsvNumeracion.Items.Add(n)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Sub ObtenerSeriesEE(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer)
        Dim serieSA As New empresaSerieSA
        Try
            lsvSerie.Items.Clear()
            For Each i In serieSA.obtenerSeriePorEEmpresa(strIdEmpresa, intIdEstablecimiento)
                Dim n As New ListViewItem(i.serie)
                n.SubItems.Add(i.comprobante)
                lsvSerie.Items.Add(n)
            Next
            'lstSeries.DisplayMember = "serie"
            'lstSeries.ValueMember = "fechaEmision"
            'lstSeries.DataSource = serieSA.obtenerSeriePorEEmpresa(strIdEmpresa, intIdEstablecimiento)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub Grabar()
        Dim serieSA As New empresaSerieSA
        Dim objSerie As New EmpresaSeries
        With objSerie
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento
            .fechaEmision = txtFecha.Value
            .serie = txtSerie.Text.Trim
            .comprobante = IIf(rbBol.Checked = True, "BOL", "FAC") ' txtComprobante.Text
            .usuarioAcualizacion = "Jiuni"
            .fechaActualizacion = Date.Now
        End With
        serieSA.InsertEmpresaSerie(objSerie)
        lblEstado.Text = "Número de serie grabada correctamente!"
        lblEstado.Image = My.Resources.ok4
        ObtenerSeriesEE(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
        'Else
        'MsgBox("El número de serie ya existe, ingrese otro!", MsgBoxStyle.Critical, "Aviso del sistema!")
        'End If
    End Sub

#End Region

    Private Sub frmModalSeries_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmModalSeries_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        btnRegistrar.Enabled = False
    End Sub

    Private Sub NuevoToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        gbSeries.Enabled = True
        gbSeries.Text = "Nuevo Registro"
        txtSerie.Clear()
        Me.Tag = Manipulacion.Grabar
    End Sub

    Private Sub AbrirToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        gbSeries.Enabled = True
        gbSeries.Text = "Editar Registro"
        btnNuevo.Enabled = False
        'lstSeries.Enabled = False
        Me.Tag = Manipulacion.Editar
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        gbSeries.Enabled = False
        gbSeries.Text = "Nuevo Registro"
        txtSerie.Clear()
        btnNuevo.Enabled = True
        btnEdit.Enabled = False
        'lstSeries.Enabled = True
    End Sub



    Private Sub btnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabar.Click
        If txtSerie.Text.Trim.Length > 0 Then
            If Me.Tag = Manipulacion.Grabar Then
                Grabar()
                btnCancelar_Click(sender, e)
            End If
        Else
            MsgBox("Ingrese un número de serie válido!", MsgBoxStyle.Information, "Atención!")
            txtSerie.Focus()
        End If
    End Sub

    Private Sub txtSerie_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtSerie.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If Not txtSerie.Text = "" Or Not String.IsNullOrEmpty(txtSerie.Text) Then
                If IsNumeric(txtSerie.Text) Then
                    txtSerie.Text = String.Format("{0:00000}", Convert.ToInt32(txtSerie.Text))
                Else
                    MessageBox.Show("Serie inválida", "Ingresa otra vez", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtSerie.Clear()
                    txtSerie.Focus()
                    txtSerie.SelectAll()
                End If
            End If
        End If
    End Sub

    Private Sub txtSerie_LostFocus(sender As Object, e As System.EventArgs) Handles txtSerie.LostFocus
        If Not txtSerie.Text = "" Or Not String.IsNullOrEmpty(txtSerie.Text) Then
            If IsNumeric(txtSerie.Text) Then
                txtSerie.Text = String.Format("{0:00000}", Convert.ToInt32(txtSerie.Text))
            Else
                MessageBox.Show("Serie inválida", "Ingresa otra vez", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtSerie.Clear()
                txtSerie.Focus()
                txtSerie.SelectAll()
            End If
        End If
    End Sub

    Private Sub txtSerie_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSerie.TextChanged

    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        If lblEstado.Tag = action.SerieDesactivada Then
            Me.Cursor = Cursors.WaitCursor
            btnRegistrar.Enabled = True
            txtSerieSel.Text = lsvSerie.SelectedItems(0).SubItems(0).Text
            ObtenerNumeracionEE(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
            Me.Cursor = Cursors.Arrow
        End If
    End Sub

    Private Sub btnRegistrar_Click(sender As System.Object, e As System.EventArgs) Handles btnRegistrar.Click
        GrabarNumeracion()
        ObtenerNumeracionEE(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
        lsvSerie_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub pic_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub ToolStripButton3_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem1.Click
        AnclarNumeracion()
        lsvSerie_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub lsvSerie_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lsvSerie.MouseDoubleClick
        If lsvSerie.Items.Count > 0 AndAlso lsvSerie.SelectedItems.Count > 0 Then
            If lblEstado.Tag = action.SerieActivada Then
                Dim n As New RecuperarSerie()
                Dim datos As List(Of RecuperarSerie) = RecuperarSerie.Instance()
                n.Serie = txtSerie.Text.Trim
                n.Comprobante = lsvSerie.SelectedItems(0).SubItems(1).Text
                datos.Add(n)
                Dispose()
            Else
                MsgBox("Debe asignar una numeración!", MsgBoxStyle.Critical, "Atención")
            End If
        End If
    End Sub

    Private Sub lsvSerie_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lsvSerie.SelectedIndexChanged
        'Dim serieSA As New empresaSerieSA
        'Dim serie As New EmpresaSeries
        If lsvSerie.SelectedItems.Count > 0 Then
            HaveConfiguracion(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, lsvSerie.SelectedItems(0).Text)
            '   txtFecha.Value = CDate(lstSeries.SelectedValue).Date
            txtSerie.Text = lsvSerie.SelectedItems(0).Text
            Select Case lsvSerie.SelectedItems(0).SubItems(1).Text
                Case "BOL"
                    rbBol.Checked = True
                Case "FAC"
                    rbFact.Checked = True
            End Select
            ObtenerNumeracionEE(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
            'serieSA.GetUbicarSerieEmpresa(GEstableciento.IdEstablecimiento, )
            If lsvSerie.Items.Count > 0 Then
                btnEdit.Enabled = True
            Else
                btnEdit.Enabled = False
            End If
        End If
    End Sub
End Class
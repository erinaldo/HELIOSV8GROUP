Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Windows.Forms

Public Class frmBusquedaKardex
    Inherits frmMaster

    Public Property ListaCustomExistencias() As New List(Of totalesAlmacen)

    Public Sub New(idalmacen As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GetCombos()
        GetItemsByEstablecimiento(idalmacen)
    End Sub

#Region "Métodos"

    Sub llenarLSV(lista As List(Of totalesAlmacen))
        lsvArticulos.Items.Clear()
        For Each i In lista
            Dim n As New ListViewItem
            n.Text = i.idItem
            n.SubItems.Add(i.descripcion)
            n.SubItems.Add(i.origenRecaudo)
            n.SubItems.Add(i.tipoExistencia)
            lsvArticulos.Items.Add(n)
        Next
    End Sub

    Sub GetItemsByEstablecimiento(idalmacen As Integer)
        '  Dim itemsSA As New detalleitemsSA
        Dim totalSA As New TotalesAlmacenSA

        ListaCustomExistencias = totalSA.GetProductosPorAlmacen(idalmacen).ToList ' itemsSA.GetExistenciasByempresa()

    End Sub


    Public Sub GetCombos()
        Dim tablaSA As New tablaDetalleSA

        cboTipoExistencia.DisplayMember = "descripcion"
        cboTipoExistencia.ValueMember = "codigoDetalle"
        cboTipoExistencia.DataSource = tablaSA.GetListaTablaDetalle(5, "1")

    End Sub
#End Region

    Private Sub frmBusquedaKardex_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmBusquedaKardex_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lsvArticulos.FullRowSelect = True
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Dispose()
    End Sub

    Private Sub txtExistencia_KeyDown(sender As Object, e As KeyEventArgs) Handles txtExistencia.KeyDown

        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        Else
            Me.pcExistencias.Font = New Font("Segoe UI", 8)
            Me.pcExistencias.Size = New Size(312, 110)
            Me.pcExistencias.ParentControl = Me.txtExistencia
            Me.pcExistencias.ShowPopup(Point.Empty)

            Dim consulta = (From n In ListaCustomExistencias _
                            Where n.descripcion.StartsWith(txtExistencia.Text.Trim) _
                            And n.tipoExistencia = cboTipoExistencia.SelectedValue
                            Order By n.descripcion).ToList

            llenarLSV(consulta)
            e.Handled = True
        End If

        '  If Not Me.pcLikeCategoria.IsShowing() Then

        '   End If

        '    If Not Me.pcLikeCategoria.IsShowing() Then
        If e.KeyCode = Keys.Down Then
            Me.pcExistencias.Font = New Font("Segoe UI", 8)
            Me.pcExistencias.Size = New Size(312, 110)
            Me.pcExistencias.ParentControl = Me.txtExistencia
            Me.pcExistencias.ShowPopup(Point.Empty)
            lsvArticulos.Focus()
        End If
        '   End If

        ' e.SuppressKeyPress = True
        If e.KeyCode = Keys.Escape Then
            If Me.pcExistencias.IsShowing() Then
                Me.pcExistencias.HidePopup(PopupCloseType.Canceled)
            End If
        End If
    End Sub

    Private Sub txtExistencia_TextChanged(sender As Object, e As EventArgs) Handles txtExistencia.TextChanged

    End Sub

    Private Sub pcExistencias_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcExistencias.CloseUp
        Me.Cursor = Cursors.WaitCursor
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvArticulos.SelectedItems.Count > 0 Then
                txtExistencia.Text = lsvArticulos.SelectedItems(0).SubItems(1).Text
                txtExistencia.Tag = lsvArticulos.SelectedItems(0).SubItems(0).Text
            End If
        End If
        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtExistencia.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lstExistencias_MouseDoubleClick(sender As Object, e As MouseEventArgs)
        Me.pcExistencias.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        Dim envio As New BusquedaExstencia
        Try
            If chkfiltro.Checked = False Then
                If txtExistencia.Tag.ToString.Trim.Length > 0 Then
                    envio = New BusquedaExstencia
                    envio.IdExistencia = CType(txtExistencia.Tag, Integer)
                    envio.TipoExistencia = cboTipoExistencia.SelectedValue
                    envio.NombreExistencia = txtExistencia.Text.Trim
                    envio.UnidadMedida = "NO"
                    Me.Tag = envio
                    Dispose()
                Else
                    MessageBox.Show("Debe seleccionar un item!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            ElseIf chkfiltro.Checked = True Then

                envio = New BusquedaExstencia
                envio.TipoExistencia = cboTipoExistencia.SelectedValue
                envio.UnidadMedida = "SI"
                Me.Tag = envio
                Dispose()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Me.Tag = Nothing
        End Try
    End Sub

    Private Sub lsvArticulos_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvArticulos.MouseDoubleClick
        Me.pcExistencias.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub chkfiltro_CheckedChanged(sender As Object, e As EventArgs) Handles chkfiltro.CheckedChanged
        If chkfiltro.Checked = True Then
            txtExistencia.Visible = False
            Label2.Visible = False
        ElseIf chkfiltro.Checked = False Then
            txtExistencia.Visible = True
            Label2.Visible = True
        End If
    End Sub
End Class
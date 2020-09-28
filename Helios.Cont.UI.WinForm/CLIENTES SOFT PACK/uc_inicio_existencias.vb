Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General.Constantes
Imports Syncfusion.Windows.Forms

Public Class uc_inicio_existencias
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    ' Public Property Documento As New documento


    '  Public Property ListaCustomExistencias() As New List(Of totalesAlmacen)


    'Sub llenarLSV(lista As List(Of totalesAlmacen))
    '    lsvArticulos.Items.Clear()
    '    For Each i In lista
    '        Dim n As New ListViewItem
    '        n.Text = i.idItem
    '        n.SubItems.Add(i.descripcion)
    '        n.SubItems.Add(i.origenRecaudo)
    '        n.SubItems.Add(i.tipoExistencia)
    '        lsvArticulos.Items.Add(n)
    '    Next
    'End Sub

    Private Sub LoadCombos()
        '   Dim tablasa As New tablaDetalleSA
        Dim almacenSA As New almacenSA
        cboalmacenKardex.DataSource = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
        cboalmacenKardex.DisplayMember = "descripcionAlmacen"
        cboalmacenKardex.ValueMember = "idAlmacen"

        'cboTipoExistencia.DataSource = tablasa.GetListaTablaDetalle(5, "1")
        'cboTipoExistencia.DisplayMember = "descripcion"
        'cboTipoExistencia.ValueMember = "codigoDetalle"
    End Sub

    Private Sub ButtonAdv14_Click(sender As Object, e As EventArgs) Handles ButtonAdv14.Click
        GrabarArticulo()
    End Sub

    Private Sub GrabarArticulo()
        Throw New NotImplementedException()
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click

    End Sub

    Private Sub Panel22_Click(sender As Object, e As EventArgs) Handles Panel22.Click
        Try
            Dim f As New frmBusquedaKardex(cboalmacenKardex.SelectedValue)
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            If Not IsNothing(f.Tag) Then
                Dim envio = CType(f.Tag, BusquedaExstencia)
                txtArticulo.Tag = envio.IdExistencia
                txtArticulo.Text = envio.NombreExistencia
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Panel22_Paint(sender As Object, e As PaintEventArgs) Handles Panel22.Paint

    End Sub

    Private Sub lsvArticulos_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvArticulos.MouseDoubleClick
        Me.pcExistencias.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub pcExistencias_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcExistencias.CloseUp
        Me.Cursor = Cursors.WaitCursor
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvArticulos.SelectedItems.Count > 0 Then
                txtArticulo.Text = lsvArticulos.SelectedItems(0).SubItems(1).Text
                txtArticulo.Tag = lsvArticulos.SelectedItems(0).SubItems(0).Text
            End If
        End If
        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtArticulo.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    'Private Sub txtArticulo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtArticulo.KeyDown

    '    If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

    '    Else
    '        Me.pcExistencias.Font = New Font("Segoe UI", 8)
    '        Me.pcExistencias.Size = New Size(312, 110)
    '        Me.pcExistencias.ParentControl = Me.txtArticulo
    '        Me.pcExistencias.ShowPopup(Point.Empty)

    '        Dim consulta = (From n In ListaCustomExistencias
    '                        Where n.descripcion.StartsWith(txtArticulo.Text.Trim) _
    '                        And n.tipoExistencia = cboTipoExistencia.SelectedValue
    '                        Order By n.descripcion).ToList

    '        llenarLSV(consulta)
    '        e.Handled = True
    '    End If

    '    '  If Not Me.pcLikeCategoria.IsShowing() Then

    '    '   End If

    '    '    If Not Me.pcLikeCategoria.IsShowing() Then
    '    If e.KeyCode = Keys.Down Then
    '        Me.pcExistencias.Font = New Font("Segoe UI", 8)
    '        Me.pcExistencias.Size = New Size(312, 110)
    '        Me.pcExistencias.ParentControl = Me.txtArticulo
    '        Me.pcExistencias.ShowPopup(Point.Empty)
    '        lsvArticulos.Focus()
    '    End If
    '    '   End If

    '    ' e.SuppressKeyPress = True
    '    If e.KeyCode = Keys.Escape Then
    '        If Me.pcExistencias.IsShowing() Then
    '            Me.pcExistencias.HidePopup(PopupCloseType.Canceled)
    '        End If
    '    End If
    'End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub lsvArticulos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvArticulos.SelectedIndexChanged

    End Sub

    Private Sub uc_inicio_existencias_Load(sender As Object, e As EventArgs) Handles Me.Load
        '  LoadCombos()
    End Sub
End Class

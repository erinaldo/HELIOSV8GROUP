Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmCanastaAlmacen

#Region "Métodos"
    Public Sub ObtenerListadoPreciosLiked(intIdAlmacen As Integer, strtipoEx As String, strBusqueda As String)
        Dim tablaSA As New tablaDetalleSA
        Dim totalSA As New TotalesAlmacenSA
        Try
            lsvExistencias.Items.Clear()
            For Each i As totalesAlmacen In totalSA.GetProductoPorAlmacenTipoEx(intIdAlmacen, strtipoEx, strBusqueda)
                Dim n As New ListViewItem(i.idEstablecimiento)
                n.SubItems.Add(i.origenRecaudo)
                n.SubItems.Add(i.idItem)
                n.SubItems.Add(i.descripcion)
                n.SubItems.Add(i.unidadMedida)
                n.SubItems.Add(tablaSA.GetUbicarTablaID(21, i.Presentacion).descripcion)
                n.SubItems.Add(FormatNumber(i.cantidad, 2))
                n.SubItems.Add(FormatNumber(i.importeSoles, 2))
                n.SubItems.Add(FormatNumber(i.importeDolares, 2))
                If CDec(i.cantidad) > 0 Then
                    n.SubItems.Add(Math.Round(CDec(i.importeSoles) / CDec(i.cantidad), 2).ToString("N2"))
                Else
                    n.SubItems.Add(0)
                End If

                If CDec(i.cantidad) > 0 Then
                    n.SubItems.Add(Math.Round(CDec(i.importeDolares) / CDec(i.cantidad), 2).ToString("N2"))
                Else
                    n.SubItems.Add(0)
                End If
                lsvExistencias.Items.Add(n)
            Next
            For Each item As ListViewItem In lsvExistencias.Items
                Dim i As Short
                If i Mod 2 = 0 Then
                    item.BackColor = Color.Transparent
                    item.ForeColor = Color.Gray
                Else
                    item.BackColor = Color.WhiteSmoke
                    item.ForeColor = Color.Gray
                End If
                i = i + 1
            Next
        Catch ex As Exception
            MsgBox("No se pudo cargar la informacion de la BD." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del Sistema.!")
        End Try
    End Sub
#End Region

    Private Sub ToolStripButton7_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton7.Click
        Dispose()
    End Sub

    Private Sub cboExistencia_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboExistencia.KeyPress
        e.Handled = True
    End Sub

    Private Sub cboExistencia_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboExistencia.SelectedIndexChanged
        If cboExistencia.Text = "MERCADERIA" Then
            cboExistencia.ValueMember = "01"
        End If
    End Sub

    Private Sub cboExistencia_TextChanged(sender As System.Object, e As System.EventArgs) Handles cboExistencia.TextChanged

    End Sub

    Private Sub txtBusqueda_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtBusqueda.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtBusqueda.Text.Trim.Length > 0 Then
                ObtenerListadoPreciosLiked(txtAlmacenOrigen.ValueMember, cboExistencia.ValueMember, txtBusqueda.Text.Trim)
            Else

            End If
        End If
    End Sub

    Private Sub txtBusqueda_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBusqueda.TextChanged

    End Sub

    'Private Sub lsvExistencias_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lsvExistencias.MouseDoubleClick
    '    Me.Cursor = Cursors.WaitCursor
    '    Dim n As New RecolectarDatos()
    '    Dim datos As List(Of RecolectarDatos) = RecolectarDatos.Instance()
    '    Try
    '        If lsvExistencias.SelectedItems.Count > 0 Then
    '            n = New RecolectarDatos()
    '            n.Secuencia = datos.Count + 1 '0
    '            n.Gravado = lsvExistencias.SelectedItems(0).SubItems(1).Text
    '            n.IdArticulo = lsvExistencias.SelectedItems(0).SubItems(2).Text
    '            n.NameArticulo = lsvExistencias.SelectedItems(0).SubItems(3).Text
    '            n.Cantidad = lsvExistencias.SelectedItems(0).SubItems(6).Text
    '            n.NamePresentacion = lsvExistencias.SelectedItems(0).SubItems(5).Text
    '            n.UM = lsvExistencias.SelectedItems(0).SubItems(5).Text
    '            n.PrecUnitKardexMN = lsvExistencias.SelectedItems(0).SubItems(9).Text
    '            n.PrecUnitKardexME = lsvExistencias.SelectedItems(0).SubItems(10).Text
    '            n.IdAlmacen = txtAlmacenOrigen.ValueMember
    '            datos.Add(n)
    '        End If
    '        Dispose()
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try

    '    Me.Cursor = Cursors.Arrow
    'End Sub

    Private Sub lsvExistencias_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lsvExistencias.SelectedIndexChanged

    End Sub

    Private Sub frmCanastaAlmacen_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        txtBusqueda.Select()
        txtBusqueda.Focus()
    End Sub
End Class
Imports Helios.Cont.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Helios.General
Imports Syncfusion.Grouping
Imports Helios.Cont.Business.Entity

Public Class UCComision

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGrid(GridProducts)
        GetComisiones()
    End Sub

    Private Sub FormatoGrid(grid As GridGroupingControl)
        grid.Appearance.AnyCell.TextColor = Color.WhiteSmoke
        grid.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        grid.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        grid.TableOptions.ListBoxSelectionMode = SelectionMode.One
        grid.TableOptions.SelectionBackColor = Color.FromArgb(85, 170, 255)
        grid.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        grid.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
    End Sub

    Private Sub GetComisiones()
        Dim comisionSA As New detalleitemcatalogo_comisionSA
        Dim lista = comisionSA.detalleitemcatalogo_comisionJoinList(New Business.Entity.detalleitemcatalogo_comision With {.empresa = Gempresas.IdEmpresaRuc, .unidadNegocio = GEstableciento.IdEstablecimiento})
        Dim dt As New DataTable()
        dt.Columns.Add("id")
        dt.Columns.Add("unidad")
        dt.Columns.Add("producto")
        dt.Columns.Add("unidadcomercial")
        dt.Columns.Add("catalogo")
        dt.Columns.Add("tipo")
        dt.Columns.Add("bloqueado")
        dt.Columns.Add("vigencia")
        dt.Columns.Add("apartir")
        dt.Columns.Add("comision", GetType(detalleitemcatalogo_comision))

        For Each i In lista
            dt.Rows.Add(i.idComision, GEstableciento.NombreEstablecimiento, i.customProducto.descripcionItem, i.customUnidadComercial.unidadComercial, i.customCatalogoPrecio.nombre_corto,
                        i.tipo_comision, i.bloqueado, i.vigencia, i.apartir_de, i)
        Next
        GridProducts.DataSource = dt
    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        Dim form As New FormCrearContrato
        form.StartPosition = FormStartPosition.CenterParent
        form.ShowDialog(Me)
    End Sub

    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click
        Dim r As Record = GridProducts.Table.CurrentRecord
        If r Is Nothing Then Exit Sub
        Dim obj = CType(r.GetValue("comision"), detalleitemcatalogo_comision)
        Dim f As New FormContratoAsignaUsuario(obj)
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            GetComisiones()
        End If

    End Sub

    Private Sub GridProducts_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridProducts.TableControlCellClick

    End Sub

    Private Sub GridProducts_SelectedRecordsChanging(sender As Object, e As SelectedRecordsChangedEventArgs) Handles GridProducts.SelectedRecordsChanging
        If e.SelectedRecord IsNot Nothing Then
            GetComisionUsuarios(e.SelectedRecord.Record)
        End If
    End Sub

    Private Sub GetComisionUsuarios(r As Record)
        Dim obj = CType(r.GetValue("comision"), detalleitemcatalogo_comision)

        Dim dt As New DataTable
        dt.Columns.Add("IDUsuario")
        dt.Columns.Add("Nombres")
        dt.Columns.Add("ApellidoPaterno")
        dt.Columns.Add("ApellidoMaterno")
        dt.Columns.Add("TipoDocumento")
        dt.Columns.Add("NroDocumento")
        dt.Columns.Add("codigo")
        dt.Columns.Add("estado")
        dt.Columns.Add("comision", GetType(detalleitemcatalogo_comisiondetalle))

        For Each i In obj.detalleitemcatalogo_comisiondetalle.ToList
            Dim usuario = UsuariosList.Where(Function(o) o.IDUsuario = i.IdUsuario).SingleOrDefault
            dt.Rows.Add(i.IdUsuario, usuario.Nombres, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.TipoDocumento, usuario.NroDocumento, usuario.codigo, usuario.estado, i)
        Next
        gridAutoprecio.DataSource = dt
    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        Dim r As Record = GridProducts.Table.CurrentRecord
        If r Is Nothing Then Exit Sub
        Dim obj = CType(r.GetValue("comision"), detalleitemcatalogo_comision)
        Dim form As New FormCrearContrato(obj)
        form.StartPosition = FormStartPosition.CenterParent
        form.ShowDialog(Me)
    End Sub

    Private Sub BunifuFlatButton6_Click(sender As Object, e As EventArgs) Handles bunifuFlatButton6.Click
        GetComisiones()
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        Dim pont = New Point(BunifuFlatButton1.Location.X - 100, BunifuFlatButton1.Location.Y + 20)
        contextMenuStripEx1.Show(Me.BunifuFlatButton1, pont)
    End Sub

    Private Sub InactivoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles inactivoToolStripMenuItem.Click
        Dim r As Record = GridProducts.Table.CurrentRecord
        If r Is Nothing Then Exit Sub
        Dim obj = CType(r.GetValue("comision"), detalleitemcatalogo_comision)
        changeStatusComision(obj, True)
    End Sub

    Private Sub changeStatusComision(obj As detalleitemcatalogo_comision, bloquear As Boolean)
        Dim comisionSA As New detalleitemcatalogo_comisionSA
        obj.Action = BaseBE.EntityAction.UPDATE
        obj.empresa = Gempresas.IdEmpresaRuc
        obj.unidadNegocio = GEstableciento.IdEstablecimiento
        obj.bloqueado = bloquear
        comisionSA.detalleitemcatalogo_comisionSave(obj)
    End Sub

    Private Sub ACTIVARToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles aCTIVARToolStripMenuItem.Click
        Dim r As Record = GridProducts.Table.CurrentRecord
        If r Is Nothing Then Exit Sub
        Dim obj = CType(r.GetValue("comision"), detalleitemcatalogo_comision)
        changeStatusComision(obj, False)
    End Sub

    Private Sub gridAutoprecio_TableControlDrawCell(sender As Object, e As GridTableControlDrawCellEventArgs) Handles gridAutoprecio.TableControlDrawCell
        If e.Inner.Style.CellType = "PushButton" Then
            e.Inner.Cancel = True

            ' //Draw the Image in a cell.
            If e.Inner.ColIndex = 10 Then
                e.Inner.Style.Description = "Eliminar"
                e.Inner.Style.TextColor = Color.Black
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3),
                                           New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6)
                    )
                '    e.Inner.Graphics.DrawImage(Me.ImageList1.Images(0), irect)
            End If
        End If
    End Sub

    Private Sub gridAutoprecio_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles gridAutoprecio.TableControlPushButtonClick
        Me.Cursor = Cursors.WaitCursor
        Dim comisionSA As New detalleitemcatalogo_comisiondetalleSA
        Try
            If e.Inner.ColIndex = 10 Then

                If gridAutoprecio.Table.CurrentRecord IsNot Nothing Then
                    If MessageBox.Show("Desea eliminar el usuario seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        'Dim idAsignacion = gridAutoprecio.TableModel(e.Inner.RowIndex, 1).CellValue

                        Dim obj = CType(gridAutoprecio.Table.CurrentRecord.GetValue("comision"), detalleitemcatalogo_comisiondetalle)

                        'Dim EQ = ListaEquivalencia.Where(Function(o) o.IDGUI = idEquivalencia).Single
                        obj.Action = BaseBE.EntityAction.DELETE
                        comisionSA.detalleitemcatalogo_comisiondetalleSave(obj)
                        gridAutoprecio.Table.CurrentRecord.Delete()
                        gridAutoprecio.Refresh()
                        GetComisiones()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

End Class

Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Public Class FormAsignCategory
    Private ReadOnly listaProducts As List(Of detalleitems)
    Private itemSA As New itemSA
    Private listaCategories As List(Of item)

    Public Sub New(ListaProducts As List(Of detalleitems))

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        listaCategories = itemSA.GetListaItemPorEstable(GEstableciento.IdEstablecimiento, Gempresas.IdEmpresaRuc)
        GetComboCategories()
        Me.listaProducts = ListaProducts
        LabelsEL.Text = $"{ListaProducts.Count} Items seleccionados"

    End Sub

    Private Sub GetComboCategories()
        ComboCategoria.DataSource = listaCategories
        ComboCategoria.DisplayMember = "descripcion"
        ComboCategoria.ValueMember = "idItem"
        ComboCategoria.Refresh()
    End Sub

    Private Sub BunifuThinButton21_Click(sender As Object, e As EventArgs) Handles BunifuThinButton21.Click
        SaveCategoriesProducts()
    End Sub

    Private Sub SaveCategoriesProducts()
        itemSA.EditarPropertycategoryProducts(listaProducts, Integer.Parse(ComboCategoria.SelectedValue))
        MessageBox.Show("Productos actualizados!", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information)

        For Each i In listaProducts
            Dim category = listaCategories.Where(Function(o) o.idItem = Integer.Parse(ComboCategoria.SelectedValue)).SingleOrDefault
            i.item = category
            i.idItem = category.idItem
        Next
        Tag = True
        Close()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim f As New FormCrearCategory
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            Dim c = CType(f.Tag, item)
            listaCategories.Add(c)
            ComboCategoria.DataSource = New List(Of item)
            GetComboCategories()
            ComboCategoria.Text = c.descripcion
        End If

    End Sub

    Private Sub ComboCategoria_Click(sender As Object, e As EventArgs) Handles ComboCategoria.Click

    End Sub

    Private Sub ComboCategoria_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboCategoria.SelectedValueChanged
        If IsNumeric(ComboCategoria.SelectedValue) Then
            Dim cat = listaCategories.Where(Function(o) o.idItem = ComboCategoria.SelectedValue).SingleOrDefault
            If cat IsNot Nothing Then
                '  TextPrecioCompra.DecimalValue = cat.precioCompra.GetValueOrDefault
                TextUtilidadBefore.DecimalValue = cat.beforepercent.GetValueOrDefault
                TextUtilidadFirst.DecimalValue = cat.firstpercent.GetValueOrDefault
                If cat.preciocompratipo = "PCT" Then
                    ComboBoxAdv1.Text = "PORCENTAJE"
                Else
                    ComboBoxAdv1.Text = "MONTO FIJO"
                End If
            End If
        End If
    End Sub

    Private Sub ComboBoxAdv1_Click(sender As Object, e As EventArgs) Handles ComboBoxAdv1.Click

    End Sub
End Class
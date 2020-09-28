Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Public Class FormRecursoCostoLoteTalla
    Private listaTallas As List(Of talla)

    Private recursoCostoLoteList As List(Of recursoCostoLoteTalla)

    Public Sub New(lote As recursoCostoLote)

        ' This call is required by the designer.
        InitializeComponent()
        _Lote = lote
        GetMappingContols()


        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub GetMappingContols()
        recursoCostoLoteList = New List(Of recursoCostoLoteTalla)
        Dim itemSA As New itemSA
        Dim tallaSA As New tallaSA
        Dim cat = itemSA.UbicarCategoriaPorID(_Lote.CustomProducto.idItem)
        TextDisponible.Text = _Lote.cantidad.GetValueOrDefault
        If cat IsNot Nothing Then
            TextCategory.Text = cat.descripcion
            TextCategory.Tag = cat.idItem
        Else
            TextCategory.Text = ""
            TextCategory.Tag = Nothing
        End If

        listaTallas = tallaSA.GetPlantillaTallaSelcategory(New talla With {.idcategoria = cat.idItem})
        If listaTallas.Count > 0 Then
            ComboTallas.DataSource = listaTallas
            ComboTallas.ValueMember = "idtalla"
            ComboTallas.DisplayMember = "GetNameGenero"

            GetComboDetalle(ComboTallas.SelectedValue)
        End If

    End Sub

    Public ReadOnly Property _Lote As recursoCostoLote

    Private Sub TextBoxExt5_TextChanged(sender As Object, e As EventArgs) Handles TextEur.TextChanged

    End Sub

    Private Sub GetComboDetalle(idTalla As Integer)
        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("usa")
        dt.Columns.Add("uk")
        dt.Columns.Add("eur")
        dt.Columns.Add("cm")
        dt.Columns.Add("obj", GetType(talla_equivalencias))

        Dim lst = listaTallas.Where(Function(o) o.idtalla = idTalla).SingleOrDefault

        For Each i In lst.talla_equivalencias.ToList()
            dt.Rows.Add(i.GetInfo, i.usa, i.uk, i.eur, i.cm, i)
        Next

        dt.Columns(0).ColumnMapping = MappingType.Hidden
        dt.Columns(5).ColumnMapping = MappingType.Hidden

        Dim view As DataView = New DataView(dt)
        Me.ComboDetalleTallas.DataSource = view
        Me.ComboDetalleTallas.DisplayMember = "id"
        Me.ComboDetalleTallas.ValueMember = "obj"



        '--------------------------------------------------------------
        Dim sel = ComboDetalleTallas.SelectedValue
        'If sel > 0 Then
        Dim obj = CType(ComboDetalleTallas.SelectedValue, talla_equivalencias)
            TextUsa.Clear()
            TextUK.Clear()
            TextEur.Clear()
            TextCm.Clear()

            If obj IsNot Nothing Then
                TextUsa.Text = obj.usa
                TextUK.Text = obj.uk
                TextEur.Text = obj.eur
                TextCm.Text = obj.cm
            End If
        'End If

    End Sub

    Private Sub ComboTallas_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboTallas.SelectionChangeCommitted
        GetComboDetalle(ComboTallas.SelectedValue)
    End Sub

    Private Sub ComboDetalleTallas_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboDetalleTallas.SelectionChangeCommitted
        Dim obj = CType(ComboDetalleTallas.SelectedValue, talla_equivalencias)
        TextUsa.Clear()
        TextUK.Clear()
        TextEur.Clear()
        TextCm.Clear()

        If obj IsNot Nothing Then
            TextUsa.Text = obj.usa
            TextUK.Text = obj.uk
            TextEur.Text = obj.eur
            TextCm.Text = obj.cm
        End If
    End Sub

    Private Sub ButtonAdd_Click(sender As Object, e As EventArgs) Handles ButtonAdd.Click
        Dim SumCantidad = 0
        If recursoCostoLoteList IsNot Nothing Then
            SumCantidad = recursoCostoLoteList.Sum(Function(o) o.stock).GetValueOrDefault()
        End If

        If CurrencyStock.DecimalValue <= 0 Then
            MessageBox.Show("Ingresar una cantidad mayor a cero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If


        If SumCantidad > CDec(TextDisponible.Text) Then
            MessageBox.Show("Sin stock suficiente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextDisponible.Select()
            TextDisponible.SelectAll()
            Exit Sub
        End If

        Dim objTalla = CType(ComboDetalleTallas.SelectedValue, talla_equivalencias)

        Dim codigo = Guid.NewGuid().ToString

        Dim t = listaTallas.Where(Function(o) o.idtalla = ComboTallas.SelectedValue).Single

        Dim obj As New recursoCostoLoteTalla
        obj.CodigoAuth = codigo
        obj.idProducto = _Lote.CustomProducto.codigodetalle
        obj.idtalla = ComboTallas.SelectedValue
        obj.id_equivalencia = objTalla.id_equivalencia
        obj.idalmacen = 0 '_Lote.CustomCompraDetail.almacenRef
        'obj.idalmacen = _Lote.
        obj.codigoLote = _Lote.codigoLote
        obj.idcategoria = TextCategory.Tag


        obj.genero = t.genero
        obj.GetNameGenero = ComboTallas.Text
        obj.usa = objTalla.usa
        obj.uka = objTalla.uk
        obj.eur_fr = objTalla.eur
        obj.ot = objTalla.cm
        obj.stock = CurrencyStock.DecimalValue
        obj.CustomTotalesAlmacenOthers = New totalesAlmacenOthers With
        {
        .idProducto = _Lote.CustomProducto.codigodetalle,
        .id_equivalencia = objTalla.id_equivalencia,
        .idcategoria = TextCategory.Tag,
        .idalmacen = 0,
        .genero = t.genero,
        .cantidad = CurrencyStock.DecimalValue,
        .tipoRegistro = "E",
        .status = 1
        }
        recursoCostoLoteList.Add(obj)
        GetSourceListView(recursoCostoLoteList)

        TextUsa.Clear()
        TextUK.Clear()
        TextEur.Clear()
        TextCm.Clear()
        CurrencyStock.DecimalValue = 0
    End Sub

    Private Sub GetSourceListView(lst As List(Of recursoCostoLoteTalla))
        ListView1.Items.Clear()

        For Each i In lst
            Dim n As New ListViewItem(i.GetNameGenero)
            n.SubItems.Add(i.usa)
            n.SubItems.Add(i.uka)
            n.SubItems.Add(i.eur_fr)
            n.SubItems.Add(i.ot)
            n.SubItems.Add(i.CodigoAuth)
            n.SubItems.Add(i.stock.GetValueOrDefault)
            ListView1.Items.Add(n)
        Next
        ListView1.Refresh()
    End Sub

    Private Sub Grabar()
        Dim loteSA As New recursoCostoLoteTallaSA
        Dim lote As New recursoCostoLote
        lote = _Lote
        lote.CustomRecursoCostoLoteTallaList = recursoCostoLoteList
        loteSA.RegistrarItems(lote)
        MessageBox.Show("Lotes registrados", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Tag = "Grabado"
        Close()
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        If ListView1.SelectedItems.Count > 0 Then
            Dim codigo = ListView1.SelectedItems(0).SubItems(5).Text
            Dim item = recursoCostoLoteList.Where(Function(o) o.CodigoAuth = codigo).SingleOrDefault
            If item IsNot Nothing Then
                recursoCostoLoteList.Remove(item)
                GetSourceListView(recursoCostoLoteList)
            End If
        End If
    End Sub

    Private Sub BtOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        If recursoCostoLoteList IsNot Nothing And recursoCostoLoteList.Count > 0 Then
            Dim totalCantidades = recursoCostoLoteList.Sum(Function(o) o.stock).GetValueOrDefault

            If totalCantidades = CDec(TextDisponible.Text) Then
                Grabar()
            Else
                MessageBox.Show("Debe ingresar la cantidad disponible completa", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub ComboTallas_Click(sender As Object, e As EventArgs) Handles ComboTallas.Click

    End Sub
End Class
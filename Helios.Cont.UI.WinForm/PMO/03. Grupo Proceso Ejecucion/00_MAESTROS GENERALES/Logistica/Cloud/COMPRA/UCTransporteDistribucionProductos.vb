Imports Helios.Cont.Business.Entity
Imports Helios.General
Public Class UCTransporteDistribucionProductos

#Region "Attributes"
    Public Property UCDistribucionAlmacen As UCDistribucionAlmacen
    Private UCEstructuraDocumentocabecera As UCEstructuraDocumentocabecera

#End Region

#Region "Constructors"
    Public Sub New(ucControlPadre As UCEstructuraDocumentocabecera)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UCEstructuraDocumentocabecera = ucControlPadre
        UCDistribucionAlmacen = New UCDistribucionAlmacen(UCEstructuraDocumentocabecera)
        UCDistribucionAlmacen.Dock = DockStyle.Fill
        UCDistribucionAlmacen.Show()
        PanelBody.Controls.Add(UCDistribucionAlmacen)
        GetListaProductos(ucControlPadre.ListaproductosComprados)
    End Sub

#End Region

#Region "Methods"
    Private Sub LoadGridInventario(itemCompra As documentocompradetalle)
        Dim almVirtual As almacen = Nothing
        If UCDistribucionAlmacen IsNot Nothing Then
            Dim dt As New DataTable
            dt.Columns.Add("codigo")
            dt.Columns.Add("idalmacen")
            dt.Columns.Add("tipo")
            dt.Columns.Add("serieGuia")
            dt.Columns.Add("numGuia")
            dt.Columns.Add("matricula")
            dt.Columns.Add("chofer")
            dt.Columns.Add("cantidad")
            dt.Columns.Add("fraccion")
            dt.Columns.Add("preciounitario")
            dt.Columns.Add("costo")
            dt.Columns.Add("idItemCompra")

            dt.Columns.Add("status")
            dt.Columns.Add("codigoUser")
            dt.Columns.Add("usuario")
            dt.Columns.Add("seleccionar", GetType(Boolean))
            dt.Columns.Add("cantidadcompra")

            If UCDistribucionAlmacen.ListaAlmacen IsNot Nothing Then
                If UCDistribucionAlmacen.ListaAlmacen.Count > 0 Then
                    almVirtual = UCDistribucionAlmacen.ListaAlmacen.Where(Function(a) a.tipo = "AV").SingleOrDefault
                End If
            End If

            For Each i In itemCompra.CustomListaInventarioMovimiento
                dt.Rows.Add(i.codigoBarra,
                            almVirtual.idAlmacen,
                            i.TipoAlmacen,
                            UCEstructuraDocumentocabecera.txtSerie.Text,
                            UCEstructuraDocumentocabecera.txtNumero.Text,
                            i.MatriculaVehiculo,
                            i.Chofer,
                            i.cantidad,
                            itemCompra.CustomProducto_equivalencia.fraccionUnidad,
                            i.precUnite,
                            i.monto,
                            itemCompra.CodigoCosto,
                            "1",
                            String.Empty,
                            String.Empty,
                            False, i.CantEntrada)
            Next

            UCDistribucionAlmacen.GridCompra.DataSource = dt
        End If
    End Sub

    Private Sub LoadGridInventarioDefault(itemCompra As documentocompradetalle)
        Dim almVirtual As almacen = Nothing
        If UCDistribucionAlmacen IsNot Nothing Then
            Dim dt As New DataTable
            dt.Columns.Add("codigo")
            dt.Columns.Add("idalmacen")
            dt.Columns.Add("tipo")
            dt.Columns.Add("serieGuia")
            dt.Columns.Add("numGuia")
            dt.Columns.Add("matricula")
            dt.Columns.Add("chofer")
            dt.Columns.Add("cantidad")
            dt.Columns.Add("fraccion")
            dt.Columns.Add("preciounitario")
            dt.Columns.Add("costo")
            dt.Columns.Add("idItemCompra")
            dt.Columns.Add("status")
            dt.Columns.Add("codigoUser")
            dt.Columns.Add("usuario")
            dt.Columns.Add("seleccionar", GetType(Boolean))
            dt.Columns.Add("cantidadcompra")

            'i.precUnite

            For Each i In itemCompra.CustomListaInventarioMovimiento
                dt.Rows.Add(
                    i.codigoBarra,
                    i.idAlmacen,
                    i.TipoAlmacen,
                    i.serie,
                    i.numero,
                    i.MatriculaVehiculo,
                    i.Chofer,
                    i.cantidad,
                    itemCompra.CustomProducto_equivalencia.fraccionUnidad,
                    i.precUnite,
                    i.monto,
                    itemCompra.CodigoCosto, i.entragado, i.CodigoUsuario, i.nombreUsuario, False, i.CantEntrada)
            Next

            UCDistribucionAlmacen.GridCompra.DataSource = dt
        End If
    End Sub

    Public Sub GetListaProductos(listaproductosComprados As List(Of documentocompradetalle))
        ListDetalle.Items.Clear()

        For Each i In listaproductosComprados
            Dim n As New ListViewItem(i.CodigoCosto)
            n.SubItems.Add(i.CustomProducto.descripcionItem)
            n.SubItems.Add(i.CustomProducto.tipoExistencia)
            n.SubItems.Add(i.CustomProducto.origenProducto)
            n.SubItems.Add(i.CustomProducto.unidad1)
            n.SubItems.Add(i.CustomProducto_equivalencia.unidadComercial)
            n.SubItems.Add(i.monto1)
            ListDetalle.Items.Add(n)
        Next
        ListDetalle.Refresh()
    End Sub
#End Region

#Region "Events"

    Private Sub BunifuThinButton23_Click(sender As Object, e As EventArgs) Handles BunifuThinButton23.Click
        If ListDetalle.SelectedItems.Count > 0 Then
            Dim codigoCompra = ListDetalle.SelectedItems(0).SubItems(0).Text
            Dim cantidad As Decimal = Decimal.Parse(ListDetalle.SelectedItems(0).SubItems(6).Text)

            Dim itemCompra = UCEstructuraDocumentocabecera.ListaproductosComprados.Where(Function(o) o.CodigoCosto = codigoCompra).Single
            If itemCompra IsNot Nothing Then
                itemCompra.CustomListaInventarioMovimiento = New List(Of InventarioMovimiento)
                GetEntregas(TextCantEntrega.IntegerValue, cantidad, itemCompra.CodigoCosto)
            End If
        Else
            MessageBox.Show("Debe seleccionar un producto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub GetEntregas(NumPartes As Long, cantidad As Decimal, codigo As String)
        If UCDistribucionAlmacen IsNot Nothing Then

            Dim itemCompra = UCEstructuraDocumentocabecera.ListaproductosComprados.Where(Function(o) o.CodigoCosto = codigo).Single
            If itemCompra IsNot Nothing Then
                Dim division = cantidad / NumPartes
                'For index = 0 To NumPartes
                '    AddInventario(itemCompra, division)
                '    index = index + 1
                'Next

                Dim index As Integer = 1
                Do While index <= NumPartes
                    AddInventario(itemCompra, division)
                    index += 1
                Loop
            End If
        End If
    End Sub

    Private Sub AddInventario(itemCompra As documentocompradetalle, cantDividida As Decimal)
        Dim codigoInv = System.Guid.NewGuid.ToString
        Dim almVirtual As New almacen

        Dim fechaCompra = Date.Now ' New Date(UCEstructuraDocumentocabecera.TxtDia.DecimalValue, CInt(UCEstructuraDocumentocabecera.cboMesCompra.SelectedValue), Date.Now.Year)
        If UCDistribucionAlmacen.ListaAlmacen IsNot Nothing Then
            If UCDistribucionAlmacen.ListaAlmacen.Count > 0 Then
                almVirtual = UCDistribucionAlmacen.ListaAlmacen.Where(Function(a) a.tipo = "AV").SingleOrDefault
            End If
        End If

        Dim fracccion As Decimal = itemCompra.CustomProducto_equivalencia.fraccionUnidad
        Dim cantidadInventario = fracccion * cantDividida
        Dim costoInventario = itemCompra.montokardex
        Dim costoUnitario = Math.Round(CDec(costoInventario / itemCompra.monto1), 2)
        Dim montoCostoItem = costoUnitario * cantDividida 'cantidadInventario

        Dim obj As New InventarioMovimiento
        obj.codigoBarra = codigoInv
        obj.idEmpresa = Gempresas.IdEmpresaRuc
        obj.idEstablecimiento = GEstableciento.IdEstablecimiento
        obj.idAlmacen = almVirtual.idAlmacen
        obj.TipoAlmacen = almVirtual.tipo
        obj.nrolote = 0
        obj.MatriculaVehiculo = "nro.matricula"
        obj.Chofer = "nom.chofer"
        obj.tipoOperacion = StatusTipoOperacion.COMPRA
        obj.tipoDocAlmacen = "99"
        obj.serie = UCEstructuraDocumentocabecera.txtSerie.Text.Trim
        obj.numero = UCEstructuraDocumentocabecera.txtNumero.Text.Trim
        obj.idDocumento = 0
        obj.idDocumentoRef = 0
        obj.descripcion = itemCompra.CustomProducto.descripcionItem
        obj.fechaLaboral = Date.Now
        obj.fecha = fechaCompra
        obj.tipoRegistro = "E"
        obj.destinoGravadoItem = itemCompra.CustomProducto.origenProducto
        obj.tipoProducto = itemCompra.CustomProducto.tipoExistencia
        obj.OrigentipoProducto = "N"
        obj.idItem = itemCompra.CustomProducto.codigodetalle
        obj.marca = itemCompra.CustomProducto.unidad2
        obj.presentacion = itemCompra.CustomProducto.presentacion
        obj.cantidad = cantidadInventario
        obj.unidad = itemCompra.CustomProducto.unidad1
        obj.CantEntrada = cantDividida
        obj.cantidad2 = 0
        obj.precUnite = costoUnitario
        obj.precUniteUSD = 0
        obj.monto = montoCostoItem 'obj.GetImporteAlmacen ' montoCostoItem
        obj.montoUSD = 0
        obj.montoOther = 0
        obj.monedaOther = 0
        obj.disponible = 0
        obj.disponible2 = 0
        obj.saldoMonto = 0
        obj.saldoMontoUsd = 0
        obj.status = "D"
        obj.entragado = "1"
        obj.usuarioActualizacion = usuario.IDUsuario
        obj.consignado = "N"
        obj.fechaActualizacion = Date.Now
        itemCompra.CustomListaInventarioMovimiento.Add(obj)

        LoadGridInventario(itemCompra)
    End Sub

    Private Sub BunifuFlatButton15_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton15.Click

    End Sub

    Private Sub ListDetalle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListDetalle.SelectedIndexChanged
        If ListDetalle.SelectedItems.Count > 0 Then
            BunifuThinButton23.Visible = True
            Dim codigoCompra = ListDetalle.SelectedItems(0).SubItems(0).Text
            Dim itemCompra = UCEstructuraDocumentocabecera.ListaproductosComprados.Where(Function(o) o.CodigoCosto = codigoCompra).SingleOrDefault
            If itemCompra IsNot Nothing Then
                LoadGridInventarioDefault(itemCompra)
            End If
        Else
            UCDistribucionAlmacen.GridCompra.Table.Records.DeleteAll()
            'ListDetalle.Items.Clear()
            BunifuThinButton23.Visible = False
        End If
    End Sub

    Private Sub BunifuThinButton21_Click(sender As Object, e As EventArgs) Handles BunifuThinButton21.Click

    End Sub

    Private Sub BunifuThinButton22_Click(sender As Object, e As EventArgs) Handles BunifuThinButton22.Click

    End Sub


#End Region

End Class

Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Public Class UserControlPreciosCompraVenta

    Public Sub GetDetalleEntradasDeinventario(idProducto As Integer)
        Dim invSA As New TotalesAlmacenSA

        Dim listaInventario = invSA.GetDetalleLoteXproductoFullAlmacen(New totalesAlmacen With
                                                                       {
                                                                       .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                       .idItem = idProducto
                                                                       })

        ListInventario.Items.Clear()

        For Each i In listaInventario
            Dim n As New ListViewItem(i.idAlmacen)
            n.SubItems.Add(i.NomAlmacen)
            n.SubItems.Add(i.CustomLote.codigoLote)
            n.SubItems.Add(i.CustomLote.nroLote)
            n.SubItems.Add(i.cantidad)
            If i.cantidad > 0 Then
                n.SubItems.Add(Math.Round(i.CustomLote.precioUnitarioIva.GetValueOrDefault / i.cantidad, 2))
            Else
                n.SubItems.Add("0.00")
            End If
            n.SubItems.Add(i.CustomLote.fechaentrada)
            n.SubItems.Add(i.CustomLote.fechaVcto)
            n.SubItems.Add(If(i.CustomLote.productoSustentado = True, "Compra", "Otros"))
            n.SubItems.Add(i.CustomLote.precioUnitarioIva.GetValueOrDefault)
            ListInventario.Items.Add(n)
        Next
    End Sub

End Class

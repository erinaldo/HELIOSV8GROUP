Imports Helios.Cont.Business.Entity

Public Class UCPreciosCanastaVenta
    Public Sub GetDetallePrecios(ListaPrecios As List(Of detalleitemequivalencia_precios))
        ListInventario.Items.Clear()

        For Each i In ListaPrecios
            Dim n As New ListViewItem(i.precio_id)
            n.SubItems.Add(i.precioCode)
            n.SubItems.Add($"{i.rango_inicio}-{i.rango_final}")
            n.SubItems.Add(i.precio)
            n.SubItems.Add(i.precioUSD.GetValueOrDefault)
            n.SubItems.Add(i.precioCredito)
            n.SubItems.Add(i.precioCreditoUSD.GetValueOrDefault)
            ListInventario.Items.Add(n)
        Next
    End Sub


End Class

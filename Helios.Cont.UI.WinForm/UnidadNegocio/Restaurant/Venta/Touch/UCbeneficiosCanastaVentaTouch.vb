Imports Helios.Cont.Business.Entity
Imports Syncfusion.Grouping

Public Class UCbeneficiosCanastaVentaTouch

    Public Property FormVenta As FormVentaNuevaRestaurant
    Public Property ListaBeneficios As List(Of detalleitemequivalencia_beneficio)

    Public Sub New(FormMaster As FormVentaNuevaRestaurant)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormVenta = FormMaster
        ListInventario.Font = New Font("Segoe UI", 7.5F, FontStyle.Regular)
    End Sub

    Public Sub GetDetallePrecios(ListaPrecios As List(Of detalleitemequivalencia_beneficio))
        ListInventario.Items.Clear()
        ListaBeneficios = ListaPrecios

        Dim AplicaRangos = ListaBeneficios.Any(Function(o) o.aplica = 2 And o.tipobeneficio = "DESCUENTO" And o.tipoafectacion = "IMPORTE")

        Dim AplicaRangosVolumen = ListaBeneficios.Any(Function(o) o.aplica = 2 And o.tipobeneficio = "DESCUENTO" And o.tipoafectacion = "CANTIDAD")

        If AplicaRangosVolumen Then
            Dim lista = FormVenta.UCEstructuraCabeceraVentaV2.ConvertirDsctosArangosVolumen(ListaBeneficios)
            For Each i In lista
                Dim n As New ListViewItem(i.beneficio_id)
                n.SubItems.Add($"Rango de: {i.valor_evaluado}-{i.rango_final}")
                n.SubItems.Add(i.tipobeneficio)
                n.SubItems.Add(i.tipoafectacion)
                n.SubItems.Add("-")
                n.SubItems.Add(i.valor_conversion)
                n.SubItems.Add(i.valor_beneficio.GetValueOrDefault)
                ListInventario.Items.Add(n)
            Next
            Exit Sub
        End If

        Select Case AplicaRangos
            Case True
                Dim lista = FormVenta.UCEstructuraCabeceraVentaV2.ConvertirDsctosArangos(ListaBeneficios)
                For Each i In lista
                    Dim n As New ListViewItem(i.beneficio_id)
                    n.SubItems.Add($"Rango de: {i.valor_evaluado}-{i.rango_final}")
                    n.SubItems.Add(i.tipobeneficio)
                    n.SubItems.Add(i.tipoafectacion)
                    n.SubItems.Add("-")
                    n.SubItems.Add(i.valor_conversion)
                    n.SubItems.Add(i.valor_beneficio.GetValueOrDefault)
                    ListInventario.Items.Add(n)
                Next

            Case False
                For Each i In ListaPrecios
                    Dim n As New ListViewItem(i.beneficio_id)
                    n.SubItems.Add(i.beneficio_detalle)
                    n.SubItems.Add(i.tipobeneficio)
                    n.SubItems.Add(i.tipoafectacion)
                    n.SubItems.Add(i.valor_evaluado)
                    n.SubItems.Add(i.valor_conversion)
                    n.SubItems.Add(i.valor_beneficio.GetValueOrDefault)
                    ListInventario.Items.Add(n)
                Next
        End Select
    End Sub

    Private Sub ListInventario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListInventario.SelectedIndexChanged

    End Sub

    Private Sub ListInventario_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListInventario.MouseDoubleClick
        If ListInventario.SelectedItems.Count > 0 Then
            Dim r As Record = FormVenta.UCEstructuraCabeceraVentaV2.GridCompra.Table.CurrentRecord
            If r IsNot Nothing Then

                Dim descuentoConfigurado = FormVenta.UCEstructuraCabeceraVentaV2.GetBeneficioItem(r)


            End If
        End If
    End Sub
End Class

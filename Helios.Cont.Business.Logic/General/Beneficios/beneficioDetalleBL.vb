Imports Helios.Cont.Business.Entity

Public Class beneficioDetalleBL
    Inherits BaseBL

    Public Function GetListDetalleSel(be As beneficio) As List(Of beneficioDetalle)
        Dim consulta = (From n In HeliosData.beneficioDetalle
                        Join prod In HeliosData.detalleitems
                           On prod.codigodetalle Equals n.iditem
                        Where n.beneficio_id = be.beneficio_id
                        Select
                            n.beneficio_id,
                            n.iditem,
                            prod.descripcionItem,
                            n.cantidad,
                            n.almacen).ToList

        GetListDetalleSel = New List(Of beneficioDetalle)
        For Each i In consulta
            GetListDetalleSel.Add(New beneficioDetalle With
                                  {
                                  .beneficio_id = i.beneficio_id,
                                  .iditem = i.iditem,
                                  .Nombreproducto = i.descripcionItem,
                                  .cantidad = i.cantidad,
                                  .almacen = i.almacen
                                  })
        Next
    End Function

End Class

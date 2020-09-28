Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Imports System.Data.Entity
Public Class tallaBL
    Inherits BaseBL

    Public Function GetTallasSelCategoria(be As talla) As List(Of talla)
        GetTallasSelCategoria = New List(Of talla)
        Dim con = HeliosData.talla.Include(Function(o) o.talla_detalle.Select(Function(d) d.talladetalle_valor)) _
                                .Where(Function(p) p.idcategoria = be.idcategoria).ToList

        For Each i In con
            Dim obj = New talla With
            {
            .idtalla = i.idtalla,
            .idcategoria = i.idcategoria,
            .genero = i.genero,
            .estado = i.estado,
            .talla_detalle = GetDetalleTalla(i)
            }
            GetTallasSelCategoria.Add(obj)
        Next


    End Function

    Private Function GetDetalleTalla(i As talla) As List(Of talla_detalle)
        GetDetalleTalla = New List(Of talla_detalle)
        For Each d In i.talla_detalle.ToList
            GetDetalleTalla.Add(New talla_detalle() With
                                {
                                .talladetalle_id = d.talladetalle_id,
                                .idtalla = d.idtalla,
                                .codigo_calzado = d.codigo_calzado,
                                .estado = d.estado,
                                .talladetalle_valor = GetDetalleValorTallas(d)
                                })
        Next
    End Function

    Private Function GetDetalleValorTallas(d As talla_detalle) As List(Of talladetalle_valor)
        GetDetalleValorTallas = New List(Of talladetalle_valor)
        For Each i In d.talladetalle_valor.ToList
            GetDetalleValorTallas.Add(New talladetalle_valor() With
                                      {
                                      .detallevalor_id = i.detallevalor_id,
                                      .talladetalle_id = i.talladetalle_id,
                                      .idtalla = i.idtalla,
                                      .valor = i.valor
                                      })
        Next
    End Function
End Class

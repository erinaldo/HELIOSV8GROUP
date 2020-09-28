Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class itemServicioBL
    Inherits BaseBL

    Public Function Insert(ByVal itemBE As itemServicio) As Integer
        Dim productoBL As New detalleitemsBL()
        Using ts As New TransactionScope
            'Se inserta item
            Dim consulta As Integer = HeliosData.itemServicio.Where(Function(o) o.idEmpresa = itemBE.idEmpresa _
                                                              And o.idEstablecimiento = itemBE.idEstablecimiento And
                                                              o.descripcion = itemBE.descripcion).Count

            If consulta > 0 Then
                Throw New Exception("Categoría existente en la base de datos, ingrese otro!")
            Else
                HeliosData.itemServicio.Add(itemBE)
                For Each detalleBE In itemBE.servicio
                    productoBL.GetUbicaProductoNombre(detalleBE.descripcion, detalleBE.idEmpresa, detalleBE.idEstablecimiento)
                    If IsNothing(productoBL) Then
                        HeliosData.servicio.Add(detalleBE)
                    End If
                Next
                HeliosData.SaveChanges()
                ts.Complete()
            End If
            'Se inserta detalle
            Return itemBE.idItemServicio
        End Using
    End Function

    Function UbicarCategoriaServicioPorID(intIdCategoria As Integer) As itemServicio
        Return (From a In HeliosData.itemServicio Where a.idItemServicio = intIdCategoria).First
    End Function

    Public Function GetListaItemServicioPorTipo(be As itemServicio) As List(Of itemServicio)
        Return (From a In HeliosData.itemServicio Where a.idEmpresa = be.idEmpresa And a.tipo = be.tipo Select a Order By a.descripcion).ToList
    End Function

End Class

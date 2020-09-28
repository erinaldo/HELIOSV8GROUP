Imports System.Data.Entity.Migrations
Imports System.Transactions
Imports Helios.Cont.Business.Entity

Public Class detalleitemequivalencia_preciosBL
    Inherits BaseBL

    Public Function PrecioEquivalenciaSave(be As detalleitemequivalencia_precios) As detalleitemequivalencia_precios
        Using ts As New TransactionScope
            Select Case be.Action
                Case BaseBE.EntityAction.INSERT
                    Insert(be)
                Case BaseBE.EntityAction.UPDATE
                    HeliosData.detalleitemequivalencia_precios.AddOrUpdate(be)

                Case BaseBE.EntityAction.DELETE
                    EliminarPrecio(be)
            End Select
            HeliosData.SaveChanges()
            ts.Complete()
            be.precio_id = be.precio_id
            Return be
        End Using
    End Function

    Private Sub EliminarPrecio(be As detalleitemequivalencia_precios)
        Using ts As New TransactionScope
            Dim consulta = HeliosData.detalleitemequivalencia_precios.Where(Function(o) o.precio_id = be.precio_id).SingleOrDefault

            CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(consulta)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Private Sub Insert(be As detalleitemequivalencia_precios)
        Using ts As New TransactionScope
            HeliosData.detalleitemequivalencia_precios.Add(be)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub
End Class

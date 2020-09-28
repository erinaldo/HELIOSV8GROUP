Imports Helios.Cont.Business.Entity
Imports System.Data.Entity.Migrations
Imports System.Transactions
Public Class detalleitem_preciosBL
    Inherits BaseBL

    Public Function DetalleItemPrecioSave(be As detalleitem_precios) As detalleitem_precios
        DetalleItemPrecioSave = New detalleitem_precios
        Using ts As New TransactionScope
            Select Case be.Action
                Case BaseBE.EntityAction.INSERT
                    DetalleItemPrecioSave = Insert(be)
                Case BaseBE.EntityAction.UPDATE
                    HeliosData.detalleitem_precios.AddOrUpdate(be)
                Case BaseBE.EntityAction.DELETE
                    EliminarPrecio(be)
            End Select
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Function

    Private Sub EliminarPrecio(be As detalleitem_precios)
        Using ts As New TransactionScope
            Dim consulta = HeliosData.detalleitem_precios.Where(Function(o) o.precio_id = be.precio_id).Single
            CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(consulta)

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Private Function Insert(be As detalleitem_precios) As detalleitem_precios
        Using ts As New TransactionScope
            HeliosData.detalleitem_precios.Add(be)
            HeliosData.SaveChanges()
            ts.Complete()
            Return be
        End Using
    End Function
End Class

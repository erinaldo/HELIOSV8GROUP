Imports System.Data.Entity.Migrations
Imports System.Transactions
Imports Helios.Cont.Business.Entity

Public Class detalleitemequivalencia_catalogosBL
    Inherits BaseBL

    Public Function CatalogoPrecioSave(be As detalleitemequivalencia_catalogos) As detalleitemequivalencia_catalogos
        Using ts As New TransactionScope
            Select Case be.Action
                Case BaseBE.EntityAction.INSERT
                    Insertar(be)
                Case BaseBE.EntityAction.UPDATE
                    HeliosData.detalleitemequivalencia_catalogos.AddOrUpdate(be)
                Case BaseBE.EntityAction.DELETE
                    Eliminar(be)
            End Select
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
        Return be
    End Function

    Private Sub Eliminar(be As detalleitemequivalencia_catalogos)
        Using ts As New TransactionScope
            Dim obj = HeliosData.detalleitemequivalencia_catalogos.Where(Function(o) o.idCatalogo = be.idCatalogo).SingleOrDefault

            CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(obj)

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Private Sub Insertar(be As detalleitemequivalencia_catalogos)
        Using ts As New TransactionScope
            HeliosData.detalleitemequivalencia_catalogos.Add(be)
            HeliosData.SaveChanges()
            ts.Complete()
            be.idCatalogo = be.idCatalogo
        End Using
    End Sub

    Public Sub CatalogoPredeterminado(obj As detalleitemequivalencia_catalogos)
        Using ts As New TransactionScope
            Dim con = HeliosData.detalleitemequivalencia_catalogos.Where(Function(o) o.idCatalogo = obj.idCatalogo And o.equivalencia_id = obj.equivalencia_id).SingleOrDefault

            con.predeterminado = True

            Dim lista = HeliosData.detalleitemequivalencia_catalogos.Where(Function(o) o.idCatalogo <> obj.idCatalogo And o.equivalencia_id = obj.equivalencia_id).ToList

            For Each i In lista
                i.predeterminado = False
            Next

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub
End Class

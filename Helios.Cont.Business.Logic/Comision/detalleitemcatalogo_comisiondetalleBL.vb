Imports System.Data.Entity.Migrations
Imports System.Transactions
Imports Helios.Cont.Business.Entity
Imports System.Data.Entity
Public Class detalleitemcatalogo_comisiondetalleBL
    Inherits BaseBL

    Public Function detalleitemcatalogo_comisiondetalleSave(be As detalleitemcatalogo_comisiondetalle) As detalleitemcatalogo_comisiondetalle
        Using ts As New TransactionScope()

            Select Case be.Action
                Case BaseBE.EntityAction.INSERT
                    HeliosData.detalleitemcatalogo_comisiondetalle.Add(be)
                Case BaseBE.EntityAction.UPDATE
                    HeliosData.detalleitemcatalogo_comisiondetalle.AddOrUpdate(be)
                Case BaseBE.EntityAction.DELETE
                    Dim obj = HeliosData.detalleitemcatalogo_comisiondetalle.Where(Function(o) o.idComisiondetalle = be.idComisiondetalle).SingleOrDefault
                    CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(obj)
            End Select
            HeliosData.SaveChanges()
            ts.Complete()
            Return be
        End Using
    End Function



End Class

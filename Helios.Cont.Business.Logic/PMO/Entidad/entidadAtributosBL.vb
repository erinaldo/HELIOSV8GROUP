Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Imports System.Data.Entity
Imports System.Data.Entity.Migrations

Public Class entidadAtributosBL
    Inherits BaseBL

    Public Function AtributoEntidadSave(be As entidadAtributos) As entidadAtributos
        Using ts As New TransactionScope
            Select Case be.Action
                Case BaseBE.EntityAction.INSERT
                    AddAttributo(be)
                Case BaseBE.EntityAction.UPDATE
                    HeliosData.entidadAtributos.AddOrUpdate(be)
                Case BaseBE.EntityAction.DELETE
                    Dim con = HeliosData.entidadAtributos.Where(Function(o) o.idAtributo = be.idAtributo).SingleOrDefault
                    CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(con)
            End Select
            HeliosData.SaveChanges()
            ts.Complete()

        End Using
        Return be
    End Function

    Public Function AddAttributo(be As entidadAtributos) As entidadAtributos
        Using ts As New TransactionScope
            HeliosData.entidadAtributos.Add(be)
            HeliosData.SaveChanges()
            ts.Complete()
            be.idAtributo = be.idAtributo
            Return be
        End Using
    End Function

End Class

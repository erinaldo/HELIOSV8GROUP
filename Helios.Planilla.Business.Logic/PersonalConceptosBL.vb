Imports Helios.Planilla.Business.Entity

Public Class PersonalConceptosBL
    Inherits BaseBL(Of PersonalConceptos)

    Public Function PersonalConceptosXIDAU(item As PersonalConceptos) As PersonalConceptos
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Reading)
            Return scope.DBContext.PersonalConceptos.Where(Function(o) o.IDConcepto = item.IDConcepto And o.IDPersonal = item.IDPersonal And o.IDCargo = item.IDCargo).FirstOrDefault
        End Using
    End Function

    Public Function PersonalConceptosSelxBuscado(item As PersonalConceptos) As List(Of PersonalConceptos)
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Reading)
            Return scope.DBContext.PersonalConceptos.Where(Function(o) o.IDPersonal = item.IDPersonal).ToList
        End Using
    End Function

    Public Function PersonalConceptosSelxCargo(item As PersonalConceptos) As List(Of PersonalConceptos)
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Reading)
            Return scope.DBContext.PersonalConceptos.Where(Function(o) o.IDPersonal = item.IDPersonal And o.IDCargo = item.IDCargo).ToList
        End Using
    End Function

    Public Function PersonalConceptosSelxCargoV2(item As PersonalConceptos) As List(Of PersonalConceptos)
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Reading)
            Return scope.DBContext.PersonalConceptos.Where(Function(o) o.IDPersonal = item.IDPersonal And o.IDCargo = item.IDCargo).ToList
        End Using
    End Function

    Public Function PersonalConceptosSave(item As PersonalConceptos, log As TransactionDataBE) As PersonalConceptos

        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Writing)
            If item.Action = BaseBE.EntityAction.INSERT Then
                Me.Insert(item)
            Else
                Me.Update(item)
            End If
            scope.SaveChanges()
        End Using
        Return item
    End Function

    Public Function PersonalConceptosSaveLista(item As List(Of PersonalConceptos), log As TransactionDataBE) As List(Of PersonalConceptos)
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Writing)
            For Each i In item
                Me.Insert(i)
            Next
            scope.SaveChanges()
        End Using
        Return item
    End Function

End Class


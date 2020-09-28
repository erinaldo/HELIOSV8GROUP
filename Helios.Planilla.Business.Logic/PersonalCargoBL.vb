Imports Helios.Planilla.Business.Entity
Public Class PersonalCargoBL
    Inherits BaseBL(Of PersonalCargo)

    Public Function PersonalCargoSelxID(item As PersonalCargo) As PersonalCargo
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Reading)
            Return scope.DBContext.PersonalCargo.Where(Function(o) o.IDCargo = item.IDCargo And o.IDPersonal = item.IDPersonal).FirstOrDefault
        End Using
    End Function

    Public Function PersonalCargoSelxAll(item As PersonalCargo) As List(Of PersonalCargo)
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Reading)
            Return scope.DBContext.PersonalCargo.OrderBy(Function(o) o.DescripcionLarga).ToList
        End Using
    End Function

    Public Function PersonalCargoSel(item As PersonalCargo) As List(Of PersonalCargo)
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Reading)
            Return scope.DBContext.PersonalCargo.Where(Function(o) o.IDPersonal = item.IDPersonal).ToList
        End Using
    End Function

    Public Function PersonalCargoSelxCargo(item As PersonalCargo) As PersonalCargo
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Reading)
            Return scope.DBContext.PersonalCargo.Where(Function(o) o.IDPersonal = item.IDPersonal And o.IDCargo = item.IDCargo).FirstOrDefault
        End Using
    End Function

    Public Function PersonalCargoSave(item As PersonalCargo, log As TransactionDataBE) As PersonalCargo
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

End Class

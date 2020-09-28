Imports Helios.Planilla.Business.Entity

Public Class CargosBL
    Inherits BaseBL(Of Cargos)

    Public Function CargosSelxID(item As Cargos) As Cargos
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Reading)
            Return scope.DBContext.Cargos.Where(Function(o) o.IDCargo = item.IDCargo).FirstOrDefault
        End Using
    End Function

    Public Function CargosSelAll() As List(Of Cargos)
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Reading)
            Return scope.DBContext.Cargos.ToList
        End Using
    End Function

    Public Function CargosSave(item As Cargos, log As TransactionDataBE) As Cargos
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



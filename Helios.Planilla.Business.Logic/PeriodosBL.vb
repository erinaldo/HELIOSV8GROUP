Imports Helios.Planilla.Business.Entity

Public Class PeriodosBL
    Inherits BaseBL(Of Periodos)

    Public Function PeriodosSelxID(item As Periodos) As Periodos
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Reading)
            Return scope.DBContext.Periodos.Where(Function(o) o.IDPeriodo = item.IDPeriodo).FirstOrDefault
        End Using
    End Function

    Public Function PeriodosSave(item As Periodos, log As TransactionDataBE) As Periodos

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




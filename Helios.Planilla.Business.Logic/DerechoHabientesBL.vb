Imports Helios.Planilla.Business.Entity

Public Class DerechoHabientesBL
    Inherits BaseBL(Of DerechoHabientes)

    Public Function DerechoHabientesSelxBuscado(item As DerechoHabientes) As List(Of DerechoHabientes)
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Reading)
            Return scope.DBContext.DerechoHabientes.Where(Function(o) o.IDPersonal = item.IDPersonal).ToList
        End Using
    End Function

    Public Function DerechoHabientesSave(item As DerechoHabientes, log As TransactionDataBE) As DerechoHabientes

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

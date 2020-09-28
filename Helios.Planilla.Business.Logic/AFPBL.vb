Imports Helios.Planilla.Business.Entity

Public Class AFPBL
    Inherits BaseBL(Of Afp)

    Public Function AFPSelAll(item As Afp) As List(Of Afp)
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Reading)
            Return scope.DBContext.Afp.OrderBy(Function(o) o.DescripcionCorta).ToList
        End Using
    End Function

    Public Function AFPSelxID(item As Afp) As List(Of Afp)
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Reading)
            Return scope.DBContext.Afp.OrderBy(Function(o) o.DescripcionCorta).Where(Function(o) o.IDAFP = item.IDAFP).ToList
        End Using
    End Function

    Public Function AFPSave(item As Afp, log As TransactionDataBE) As Afp

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

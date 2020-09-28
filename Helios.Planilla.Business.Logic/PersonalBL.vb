Imports Helios.Planilla.Business.Entity

Public Class PersonalBL
    Inherits BaseBL(Of Personal)

    Public Function PersonalSelxEstado(item As Personal) As List(Of Personal)
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Reading)
            'Return scope.DBContext.Personal.Where(Function(o) o.Estado = item.Estado).ToList
            Return scope.DBContext.Personal.ToList

        End Using
    End Function
    Public Function PersonalSelxID(item As Personal) As Personal
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Reading)
            Return scope.DBContext.Personal.Where(Function(o) o.IDPersonal = item.IDPersonal).FirstOrDefault
        End Using
    End Function

    Public Function PersonalSelxDNI(item As Personal) As Personal
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Reading)
            Return scope.DBContext.Personal.Where(Function(o) o.Numerodocumento = item.Numerodocumento).FirstOrDefault
        End Using
    End Function

    Public Function PersonalSelStartwithNombres(item As Personal) As List(Of Personal)
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Reading)
            Dim lista = scope.DBContext.Personal.ToList()
            Return lista.Where(Function(o) o.FullName.Contains(item.Nombre)).ToList
        End Using
    End Function

    Public Function PersonalSave(item As Personal, log As TransactionDataBE) As Personal
        Dim PRBL As New PersonalProyectoBL
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Writing)
            If item.Action = BaseBE.EntityAction.INSERT Then
                Me.Insert(item)
            Else
                Me.Update(item)
            End If
            scope.SaveChanges()
        End Using
        For Each i In item.PersonalProyecto
            i.Personal = Nothing
        Next

        'For Each i In item.PersonalHorarios
        '    i.Personal = Nothing
        'Next
        'item.PersonalProyecto.ToList.ForEach(Function(o) o.Personal = Nothing)
        Return item
    End Function
End Class
Imports Helios.Planilla.Business.Entity

Public Class PersonalHorariosBL
    Inherits BaseBL(Of PersonalHorarios)

    Public Function PersonalHorariosSelxID(item As PersonalHorarios) As PersonalHorarios
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Reading)
            Return scope.DBContext.PersonalHorarios.Where(Function(o) o.IDHorario = item.IDHorario).FirstOrDefault
        End Using
    End Function

    Public Function PersonalHorariosSelxIDPersonalDiaSemana(item As PersonalHorarios) As PersonalHorarios
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Reading)
            Return scope.DBContext.PersonalHorarios.Where(Function(o) o.IDPersonal = item.IDPersonal And o.DiaNumero = item.DiaNumero).FirstOrDefault
        End Using
    End Function

    Public Function PersonalHorariosSelxIDPersonal(item As PersonalHorarios) As List(Of PersonalHorarios)
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Reading)
            Return scope.DBContext.PersonalHorarios.Where(Function(o) o.IDPersonal = item.IDPersonal).ToList
        End Using
    End Function

    Public Function PersonalHorariosSelxCargo(item As PersonalHorarios) As List(Of PersonalHorarios)
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Reading)
            Return scope.DBContext.PersonalHorarios.Where(Function(o) o.IDPersonal = item.IDPersonal And o.IDCargo = item.IDCargo).ToList
        End Using
    End Function

    Public Function PersonalHorariosSave(item As PersonalHorarios, log As TransactionDataBE) As PersonalHorarios

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

    Public Function PersonalHorariosSaveLista(item As List(Of PersonalHorarios), log As TransactionDataBE)

        Dim codPerson = item(0).IDPersonal
        Dim codCargo = item(0).IDCargo


        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Writing)
            Dim cargoPersonal = scope.DBContext.PersonalCargo.Where(Function(o) o.IDPersonal = codPerson And o.IDCargo = codCargo).FirstOrDefault
            If cargoPersonal IsNot Nothing Then
                cargoPersonal.Totalhoras = item(0).CustomPersonalCargo.Totalhoras
                cargoPersonal.DiasLaborales = item(0).CustomPersonalCargo.DiasLaborales
            End If

            Dim listaAnterior = scope.DBContext.PersonalHorarios.Where(Function(o) o.IDPersonal = codPerson And o.IDCargo = codCargo).ToList

            For Each x In listaAnterior
                PersonalHorariosDelete(x)
            Next

            For Each i In item
                Me.Insert(i)
            Next
            scope.SaveChanges()
        End Using
        Return Nothing
    End Function

    Public Function PersonalHorariosDelete(item As PersonalHorarios) As PersonalHorarios
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Writing)
            Me.Delete(item)
            scope.SaveChanges()
        End Using
        Return item
    End Function

End Class



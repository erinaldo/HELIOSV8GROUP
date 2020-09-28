Imports Helios.Planilla.Business.Entity
Imports System.Data.Entity.DbFunctions
Imports JNetFx

Public Class ControlAsistenciaBL
    Inherits BaseBL(Of ControlAsistencia)

    Public Function ControlAsistenciaSelxIDPersonal(item As ControlAsistencia) As List(Of ControlAsistencia)
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Reading)
            Return scope.DBContext.ControlAsistencia.Where(Function(o) o.IDPersonal = item.IDPersonal).ToList
        End Using
    End Function

    Public Function ControlAsistenciaSelxIDPersonalFecha(item As ControlAsistencia) As List(Of ControlAsistencia)
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Reading)
            Return scope.DBContext.ControlAsistencia.Where(Function(o) o.IDPersonal = item.IDPersonal And TruncateTime(o.Fecha) = item.Fecha).ToList
        End Using
    End Function

    Public Function ControlAsistenciaSelxID(item As ControlAsistencia) As List(Of ControlAsistencia)
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Reading)
            Return scope.DBContext.ControlAsistencia.Where(Function(o) o.IDAsistencia = item.IDAsistencia).ToList
        End Using
    End Function

    Public Function ControlAsistenciaSave(item As ControlAsistencia, log As TransactionDataBE) As ControlAsistencia
        Try
            Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Writing)

                Dim obj = scope.DBContext.ControlAsistencia.Where(Function(o) o.IDPersonal = item.IDPersonal _
                                                                      And o.Fecha.Value.Year = item.Fecha.Value.Year _
                                                                      And o.Fecha.Value.Month = item.Fecha.Value.Month _
                                                                      And o.Fecha.Value.Day = item.Fecha.Value.Day _
                                                                           And o.TipoAcesso = item.TipoAcesso).FirstOrDefault

                If Not IsNothing(obj) Then
                    Throw New Exception("Ingrese otro registro válido!")
                End If

                If item.Action = BaseBE.EntityAction.INSERT Then
                    Me.Insert(item)
                Else
                    Me.Update(item)
                End If
                scope.SaveChanges()
            End Using

            For Each i In item.PlanillaGeneral
                i.ControlAsistencia = Nothing
            Next
        Catch ex As Exception
            Throw ex
        End Try
        Return item
    End Function

    Public Function ControlAsistenciaDelete(item As ControlAsistencia, log As TransactionDataBE) As ControlAsistencia
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Writing)
            Me.Delete(item)
            scope.SaveChanges()
        End Using
        Return item
    End Function

End Class

Imports Helios.Planilla.Business.Entity

Public Class ControlDeAsistenciaBL
    Inherits BaseBL(Of ControlDeAsistencia)

    Public Function ControlDeAsistenciaSelxSocio(item As ControlDeAsistencia) As List(Of ControlDeAsistencia)
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Reading)
            Return scope.DBContext.ControlDeAsistencia.Where(Function(o) o.iddocumentoref = item.iddocumentoref And o.IDPersonal = item.IDPersonal).ToList
        End Using
    End Function

    Public Function ControlDeAsistenciaSelxIDAsistencia(item As ControlDeAsistencia) As List(Of ControlDeAsistencia)
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Reading)
            Return scope.DBContext.ControlDeAsistencia.Where(Function(o) o.IDAsistencia = item.IDAsistencia).ToList
        End Using
    End Function

    Public Function ControlDeAsistenciaSelxIDPersonal(item As ControlDeAsistencia) As List(Of ControlDeAsistencia)
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Reading)
            Return scope.DBContext.ControlDeAsistencia.Where(Function(o) o.IDPersonal = item.IDPersonal).ToList
        End Using
    End Function

    Public Function ControlDeAsistenciaSelxIDPersonal_SP(item As ControlDeAsistencia) As List(Of usp_GetAsistenciaXtrabajador_Result)
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Reading)
            Return scope.DBContext.usp_GetAsistenciaXtrabajador(item.IDPersonal, item.AñoAsistencia, item.MesAsistencia).ToList
        End Using
    End Function


    Public Function ControldeAsistenciaSelxPersonalFecha(item As ControlDeAsistencia) As List(Of ControlDeAsistencia)
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Reading)
            Return scope.DBContext.ControlDeAsistencia.Where(Function(o) o.IDPersonal = item.IDPersonal And o.MesAsistencia = item.MesAsistencia And o.AñoAsistencia = item.AñoAsistencia).ToList
        End Using
    End Function

    Public Function ControldeAsistenciaSelxPersonalDetalle(item As ControlDeAsistencia) As List(Of ControlDeAsistencia)
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Reading)
            Return scope.DBContext.ControlDeAsistencia.Where(Function(o) o.IDPersonal = item.IDPersonal And o.MesAsistencia = item.MesAsistencia And o.AñoAsistencia = item.AñoAsistencia And o.DiaAsistencia = item.DiaAsistencia).ToList
        End Using
    End Function


    Public Function ControlDeAsistenciaSelxIDPersonalFecha(item As ControlDeAsistencia) As ControlDeAsistencia
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Reading)
            Return scope.DBContext.ControlDeAsistencia.Where(Function(o) o.IDPersonal = item.IDPersonal And o.FechaAsistencia = item.FechaAsistencia).FirstOrDefault
        End Using
    End Function

    Public Function ControlDeAsistenciaSave(item As ControlDeAsistencia, log As TransactionDataBE) As ControlDeAsistencia
        Try
            Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Writing)

                Dim validarDia = scope.DBContext.ControlDeAsistencia.Where(Function(o) o.IDPersonal = item.IDPersonal And
                                                                               o.iddocumentoref = item.iddocumentoref And
                                                                               o.AñoAsistencia = item.AñoAsistencia And
                                                                               o.MesAsistencia = item.MesAsistencia And
                                                                               o.DiaAsistencia = item.DiaAsistencia).FirstOrDefault

                If validarDia Is Nothing Then
                    If item.Action = BaseBE.EntityAction.INSERT Then
                        Insert(item)
                    Else
                        Update(item)
                    End If
                Else
                    Throw New Exception("El usuario ya resgitró su asistencia con anterioridad")
                End If

                scope.SaveChanges()
            End Using
        Catch ex As Exception
            Throw ex
        End Try

        Return item
    End Function

End Class

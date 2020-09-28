Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class ActividadesBL
    Inherits BaseBL

    Public Sub UpdateIdPadreActividad(actividadBL As List(Of Actividades))
        Dim objActividad As New Actividades
        Dim objProyecto As New ProyectoPlaneacionBL
        Using ts As New TransactionScope
            For Each i As Actividades In actividadBL
                UpdateIdPadreSingle(i)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub UpdateIdPadreSingle(nActividadBL As Actividades)
        Dim objActividad As New Actividades
        Using ts As New TransactionScope
            objActividad = HeliosData.Actividades.Where(Function(o) o.idActividad = nActividadBL.idActividad).First
            objActividad.idPadre = nActividadBL.idPadre
            objActividad.Estado = nActividadBL.Estado
            'HeliosData.ObjectStateManager.GetObjectStateEntry(objActividad).State.ToString()
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function GetUbicarMontoContractual(intIDProyecto As Integer, strTipoRecurso As String, strFlag As String)
        Return (From a In HeliosData.Actividades
              Where a.modulo = strTipoRecurso _
              And a.idPadre = intIDProyecto _
              And a.flag = strFlag).ToList
    End Function

    Public Sub GrabarActividadEquipo(actividadBL As List(Of Actividades), nProyecto As ProyectoPlaneacion)
        Dim objActividad As New Actividades
        Dim objProyecto As New ProyectoPlaneacionBL
        Using ts As New TransactionScope
            objProyecto.Update(nProyecto)
            For Each i In actividadBL
                If i.Estado = ENTITY_ACTIONS.INSERT Then
                    GrabarActividadEquipoDefault(i)
                End If

                'objActividad = New Actividades With {
                '    .idEmpresa = i.idEmpresa,
                '.idEstablecimiento = i.idEstablecimiento,
                '    .idProyecto = i.idProyecto,
                '    .idPadre = i.idPadre,
                '.NombreActividad = i.NombreActividad,
                '.descripcion = i.descripcion,
                '.modulo = i.modulo,
                '.responsable = i.responsable,
                '.FechaInicio = i.FechaInicio,
                '.FechaFinal = i.FechaFinal,
                '.usuarioActualizacion = i.usuarioActualizacion,
                '.fechaActualizacion = i.fechaActualizacion}
                'HeliosData.Actividades.Add(objActividad)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub GrabarActividadEquipoDefault(nActividadBL As Actividades)
        Dim objActividad As New Actividades
        Using ts As New TransactionScope
            Select Case nActividadBL.Action
                Case BaseBE.EntityAction.INSERT
                    objActividad = New Actividades With {
                        .idEmpresa = nActividadBL.idEmpresa,
                        .idEstablecimiento = nActividadBL.idEstablecimiento,
                        .idProyecto = nActividadBL.idProyecto,
                        .idPadre = nActividadBL.idPadre,
                        .NombreActividad = nActividadBL.NombreActividad,
                        .descripcion = nActividadBL.descripcion,
                        .unidad = nActividadBL.unidad,
                        .modulo = nActividadBL.modulo,
                        .responsable = nActividadBL.responsable,
                        .FechaInicio = nActividadBL.FechaInicio,
                        .FechaFinal = nActividadBL.FechaFinal,
                        .flag = nActividadBL.flag,
                        .usuarioActualizacion = nActividadBL.usuarioActualizacion,
                        .fechaActualizacion = nActividadBL.fechaActualizacion}
                    HeliosData.Actividades.Add(objActividad)
                Case BaseBE.EntityAction.UPDATE

            End Select

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub GrabarActividadEDTExcel(ByVal ListaRecursoEDT As List(Of Actividades))
        Dim objActividad As New Actividades

        Using ts As New TransactionScope
            For Each RecursoBE In ListaRecursoEDT
                objActividad = New Actividades
                With objActividad
                    .idEmpresa = RecursoBE.idEmpresa
                    .idEstablecimiento = RecursoBE.idEstablecimiento
                    .idProyecto = RecursoBE.idProyecto
                    .idPadre = RecursoBE.idPadre
                    .NombreActividad = RecursoBE.NombreActividad
                    .descripcion = RecursoBE.descripcion
                    .unidad = RecursoBE.unidad
                    .modulo = RecursoBE.modulo
                    .Observacion = RecursoBE.Observacion
                    .Dias = RecursoBE.Dias
                    .responsable = RecursoBE.responsable
                    .FechaInicio = RecursoBE.FechaInicio
                    .FechaFinal = RecursoBE.FechaFinal
                    .flag = RecursoBE.flag
                    .usuarioActualizacion = RecursoBE.usuarioActualizacion
                    .fechaActualizacion = RecursoBE.fechaActualizacion
                End With
                HeliosData.Actividades.Add(objActividad)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub GrabarActividadesAprobadas(nActividad As Actividades)
        Dim objActividad As New Actividades
        Using ts As New TransactionScope
            With objActividad
                .idEmpresa = nActividad.idEmpresa
                .idEstablecimiento = nActividad.idEstablecimiento
                .idProyecto = nActividad.idProyecto
                .idPadre = nActividad.idPadre
                .NombreActividad = nActividad.NombreActividad
                .descripcion = nActividad.descripcion
                .unidad = nActividad.unidad
                .modulo = nActividad.modulo
                .importePrecUni = nActividad.importePrecUni
                .cantidad = nActividad.cantidad
                .responsable = nActividad.responsable
                .FechaInicio = nActividad.FechaInicio
                .Observacion = nActividad.Observacion
                .Dias = nActividad.Dias
                .Estado = nActividad.Estado
                .flag = "AP"
                .usuarioActualizacion = nActividad.usuarioActualizacion
                .fechaActualizacion = nActividad.fechaActualizacion
            End With
            HeliosData.Actividades.Add(objActividad)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using

    End Sub

    Public Sub GrabarActividadListaEDT(ByVal intIDProyecto As Integer, ByVal intIDEstable As Integer, ByVal srtTipoPlan As String)
        Dim liquidacionBL As New totalesLiquidacionBL
        Using ts As New TransactionScope
            For Each RecursoBE In GetUbicarListaEDT(intIDProyecto, srtTipoPlan)
                GrabarActividadesAprobadas(RecursoBE)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function GetUbicarProyectoActividad(intIdProyecto As Integer, strModulo As String) As Actividades
        Return (From a In HeliosData.Actividades
              Where a.idProyecto = intIdProyecto _
              And a.modulo = strModulo).FirstOrDefault
    End Function

    Public Function GetUbicarListaEDT(intIdProyecto As Integer, strFlag As String) As List(Of Actividades)
        Dim listTipoModulo As New List(Of String)()
        listTipoModulo.Add("EDT")
        listTipoModulo.Add("EQ")
        listTipoModulo.Add("EQC")
        listTipoModulo.Add("HT")
        Return (From a In HeliosData.Actividades
              Where a.idProyecto = intIdProyecto _
              And listTipoModulo.Contains(a.modulo) _
              And a.flag = strFlag).ToList
    End Function

    Public Function GetUbicarActividadPorModulo(intIdProyecto As Integer, strModulo As String) 'As List(Of Actividades)

        Dim Lista As New List(Of Actividades)
        Dim objRecurso As New Actividades

        Dim consulta = (From a In HeliosData.Actividades _
                Join res In HeliosData.Trabajador_PL _
                On a.responsable Equals res.codTrabajdor _
                And a.idEstablecimiento Equals res.idEstablecimiento _
              Where a.idPadre = intIdProyecto _
              And a.modulo = strModulo).ToList

        For Each obj In consulta
            objRecurso = New Actividades With _
                             {
                                 .idActividad = obj.a.idActividad,
                                 .idEmpresa = obj.a.idEmpresa, _
                                 .idEstablecimiento = obj.a.idEstablecimiento, _
                                 .NombreResponsableEquipo = obj.res.appat & " " & obj.res.apmat & ", " & obj.res.nombres, _
                                 .responsable = obj.res.codTrabajdor, _
                                 .NombreActividad = obj.a.NombreActividad, _
                                 .descripcion = obj.a.descripcion, _
                                 .unidad = obj.a.unidad _
                               }
            Lista.Add(objRecurso)
        Next
        Return Lista
    End Function

    Public Function GetUbicarActividadPorModuloOcupa(intIdProyecto As Integer, strModulo As String) 'As List(Of Actividades)

        Dim Lista As New List(Of Actividades)
        Dim objRecurso As Actividades

        Dim consulta = (From a In HeliosData.Actividades _
              Group Join ocupa In HeliosData.ocupacion _
                On a.unidad Equals ocupa.codOcupacion _
                 Into ords = Group _
                 From e In ords.DefaultIfEmpty _
               Group Join entidad In HeliosData.entidad _
                On a.responsable Equals entidad.idEntidad _
                Into ordsx = Group _
                 From ex In ordsx.DefaultIfEmpty _
                Where a.idPadre = intIdProyecto _
                And a.modulo = strModulo _
                ).ToList

        For Each obj In consulta
            objRecurso = New Actividades

            objRecurso.idActividad = obj.a.idActividad
            objRecurso.idEmpresa = obj.a.idEmpresa
            objRecurso.idEstablecimiento = obj.a.idEstablecimiento

            objRecurso.NombreActividad = obj.a.NombreActividad
            objRecurso.descripcion = obj.a.descripcion
            If IsNothing(obj.e) Then
                objRecurso.unidad = Nothing
            Else
                objRecurso.unidad = obj.e.nombreOcupacion
            End If
            If IsNothing(obj.ex) Then
                objRecurso.responsable = Nothing
                objRecurso.nombreTrab = Nothing
            Else
                objRecurso.responsable = obj.a.responsable
                objRecurso.nombreTrab = obj.ex.nombreCompleto
            End If
            Lista.Add(objRecurso)
        Next
        Return Lista
    End Function

    Public Sub ProyectoActividadGrabarTodo(ByVal actividad As Actividades)
        Dim ProyectoBL As New ProyectoPlaneacionBL
        Dim objActividad As New Actividades
        Dim objProyecto As New ProyectoPlaneacion

        Using ts As New TransactionScope
            With objProyecto
                .Action = actividad.CustomProyecto.Action
                .idEmpresa = actividad.CustomProyecto.idEmpresa
                .idEstablecimiento = actividad.CustomProyecto.idEstablecimiento
                .nombreProyecto = actividad.CustomProyecto.nombreProyecto
                ' .descripcion = actividad.CustomProyecto.descripcion
                .fechaInicio = actividad.CustomProyecto.fechaInicio
                .fechaFinal = actividad.CustomProyecto.fechaFinal
                .responsable = actividad.CustomProyecto.responsable
                .usuarioModificacion = actividad.CustomProyecto.usuarioModificacion
                .fechaModificacion = actividad.CustomProyecto.fechaModificacion
            End With
            With objActividad
                .Action = actividad.Action
                .idEmpresa = actividad.idEmpresa
                .idEstablecimiento = actividad.idEstablecimiento
                .NombreActividad = actividad.NombreActividad
                .descripcion = actividad.descripcion
                .modulo = actividad.modulo
                .responsable = actividad.responsable
                .FechaInicio = actividad.FechaInicio
                .FechaFinal = actividad.FechaFinal
                .usuarioActualizacion = actividad.usuarioActualizacion
                .usuarioActualizacion = actividad.fechaActualizacion
            End With
            If actividad.Action = BaseBE.EntityAction.INSERT Then
                objProyecto.Actividades.Add(objActividad)
                HeliosData.ProyectoPlaneacion.Add(objProyecto)
            Else
                HeliosData.ProyectoPlaneacion.Attach(objProyecto)
                HeliosData.Entry(actividad).State = System.Data.Entity.EntityState.Modified
            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function Insert(ByVal actividadBE As Actividades) As Integer
        Using ts As New TransactionScope
            HeliosData.Actividades.Add(actividadBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return actividadBE.idActividad
        End Using
    End Function

    Public Sub Update(ByVal actividadBE As Actividades)
        Using ts As New TransactionScope

            Dim actividad As Actividades = HeliosData.Actividades.Where(Function(o) o.idActividad = actividadBE.idActividad).First

            With actividad

                .NombreActividad = actividadBE.NombreActividad
                .descripcion = actividadBE.descripcion
                .modalidadEjecucion = actividadBE.modalidadEjecucion
                .modalidadEjecucionDescripcion = actividadBE.modalidadEjecucionDescripcion
                .prioridadSecuencia = actividadBE.prioridadSecuencia
                .cantidad = actividadBE.cantidad
                .unidad = actividadBE.unidad
                .importePrecUni = actividadBE.importePrecUni
                .importeMEPrecUni = actividadBE.importeMEPrecUni
                .responsable = actividadBE.responsable
                .NroOrden = actividadBE.NroOrden
                .Limitaciones = actividadBE.Limitaciones
                .FactorExito = actividadBE.FactorExito
                .CriterioFin = actividadBE.CriterioFin
                .Modalidad = actividadBE.Modalidad
                .FechaInicio = actividadBE.FechaInicio
                .FechaFinal = actividadBE.FechaFinal
                .TotalPlazo = actividadBE.TotalPlazo
                .Estado = actividadBE.Estado
                .Observacion = actividadBE.Observacion
                .Horas = actividadBE.Horas
                .Dias = actividadBE.Dias
                .Horas1 = actividadBE.Horas1
                .Dias2 = actividadBE.Dias2
                .activo = actividadBE.activo
                .flag = actividadBE.flag
            End With

            'HeliosData.ObjectStateManager.GetObjectStateEntry(actividad).State.ToString()
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal actividadBE As Actividades)
        Using ts As New TransactionScope
            Dim consulta = (From n In HeliosData.Actividades _
                          Where n.idActividad = actividadBE.idActividad).First
            CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(consulta)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using

    End Sub

    Public Function GetUbicarEDT(intIdActividad As Integer) As Actividades
        Return (From a In HeliosData.Actividades
              Where a.idActividad = intIdActividad).FirstOrDefault
    End Function

    Public Function GetListaEDT(intIDProyecto As Integer, strTipoRecurso As String, strFlag As String) 'As List(Of actividadRecurso)
        Dim consulta As New List(Of Actividades)
        Dim objRecurso As New Actividades

        Dim consulta2 = (From a In HeliosData.Actividades _
                        Group Join t In HeliosData.Trabajador_PL _
                         On a.responsable Equals t.codTrabajdor _
                           Into ords = Group _
                 From e In ords.DefaultIfEmpty _
                          Where a.idPadre = intIDProyecto _
                          And a.modulo = strTipoRecurso _
                          And a.flag = strFlag _
                         Select New With {.IdActividad = a.idActividad,
                                          .idEmpresa = a.idEmpresa,
                                          .idEstablecimiento = a.idEstablecimiento,
                                            .idProyecto = a.idProyecto,
                                          .descripcion = a.descripcion,
                                          .responsable = e.nombres,
                                          .appat = e.appat,
                                          .appmat = e.apmat,
                                          .idResp = e.codTrabajdor,
                                          .fechaInicio = a.FechaInicio,
                                          .nombreActividad = a.NombreActividad,
                                          .dias = a.Dias,
                                          .observaciones = a.Observacion,
                                          .fechaFin = a.FechaFinal,
                                          .modulo = a.modulo}).ToList
        For Each obj In consulta2
            objRecurso = New Actividades With _
                               {
                                   .idActividad = obj.IdActividad,
                                   .idEmpresa = obj.idEmpresa, _
                                   .idEstablecimiento = obj.idEstablecimiento, _
                                   .idProyecto = obj.idProyecto, _
                                   .NombreActividad = obj.nombreActividad, _
                                   .Dias = obj.dias, _
                                   .Observacion = obj.observaciones, _
                                   .descripcion = obj.descripcion, _
                                   .responsable = obj.idResp, _
                                   .nombreTrab = String.Concat(obj.responsable & " " & obj.appat & " " & obj.appmat), _
                                   .FechaInicio = obj.fechaInicio, _
                                   .FechaFinal = obj.fechaFin, _
                                   .modulo = obj.modulo _
                                 }
            consulta.Add(objRecurso)
        Next

        Return consulta
    End Function

    Public Function GetListaActividadPorProyecto(intIDProyecto As Integer, strTipoRecurso As String, strFlag As String) 'As List(Of actividadRecurso)
        Dim consulta As New List(Of Actividades)
        Dim objRecurso As New Actividades

        Dim consulta2 = (From a In HeliosData.Actividades _
                        Group Join t In HeliosData.Trabajador_PL _
                         On a.responsable Equals t.codTrabajdor _
                           Into ords = Group _
                 From e In ords.DefaultIfEmpty _
                          Where a.idProyecto = intIDProyecto _
                          And a.modulo = strTipoRecurso _
                          And a.flag = strFlag _
                         Select New With {.IdActividad = a.idActividad,
                                          .idEmpresa = a.idEmpresa,
                                          .idEstablecimiento = a.idEstablecimiento,
                                            .idProyecto = a.idProyecto,
                                          .descripcion = a.descripcion,
                                          .responsable = e.nombres,
                                          .appat = e.appat,
                                          .appmat = e.apmat,
                                          .idResp = e.codTrabajdor,
                                          .fechaInicio = a.FechaInicio,
                                          .nombreActividad = a.NombreActividad,
                                          .dias = a.Dias,
                                          .observaciones = a.Observacion,
                                          .fechaFin = a.FechaFinal,
                                          .modulo = a.modulo}).ToList
        For Each obj In consulta2
            objRecurso = New Actividades With _
                               {
                                   .idActividad = obj.IdActividad,
                                   .idEmpresa = obj.idEmpresa, _
                                   .idEstablecimiento = obj.idEstablecimiento, _
                                   .idProyecto = obj.idProyecto, _
                                   .NombreActividad = obj.nombreActividad, _
                                   .Dias = obj.dias, _
                                   .Observacion = obj.observaciones, _
                                   .descripcion = obj.descripcion, _
                                   .responsable = obj.idResp, _
                                   .nombreTrab = String.Concat(obj.responsable & " " & obj.appat & " " & obj.appmat), _
                                   .FechaInicio = obj.fechaInicio, _
                                   .FechaFinal = obj.fechaFin, _
                                   .modulo = obj.modulo _
                                 }
            consulta.Add(objRecurso)
        Next

        Return consulta
    End Function

    Public Function GetBusquedaActividadGeneralPorEstado(intIDProyecto As Integer, strTipoRecurso As String, strEstado As String, strFlag As String) 'As List(Of actividadRecurso)
        Dim consulta As New List(Of Actividades)
        Dim objRecurso As New Actividades
        Dim consulta2 = (From a In HeliosData.Actividades _
                        Group Join t In HeliosData.Trabajador_PL _
                         On a.responsable Equals t.codTrabajdor _
                           Into ords = Group _
                 From e In ords.DefaultIfEmpty _
                          Where a.idPadre = intIDProyecto _
                          And a.modulo = strTipoRecurso _
                          And a.Estado = strEstado _
                          And a.flag = strFlag _
                         Select New With {.IdActividad = a.idActividad,
                                          .idEmpresa = a.idEmpresa,
                                          .idEstablecimiento = a.idEstablecimiento,
                                            .idProyecto = a.idProyecto,
                                          .descripcion = a.descripcion,
                                          .responsable = e.nombres,
                                          .appat = e.appat,
                                          .appmat = e.apmat,
                                          .idResp = e.codTrabajdor,
                                          .fechaInicio = a.FechaInicio,
                                          .nombreActividad = a.NombreActividad,
                                          .dias = a.Dias,
                                          .observaciones = a.Observacion,
                                          .fechaFin = a.FechaFinal,
                                          .modulo = a.modulo}).ToList
        For Each obj In consulta2
            objRecurso = New Actividades With _
                               {
                                   .idActividad = obj.IdActividad,
                                   .idEmpresa = obj.idEmpresa, _
                                   .idEstablecimiento = obj.idEstablecimiento, _
                                   .idProyecto = obj.idProyecto, _
                                   .NombreActividad = obj.nombreActividad, _
                                   .Dias = obj.dias, _
                                   .Observacion = obj.observaciones, _
                                   .descripcion = obj.descripcion, _
                                   .responsable = obj.idResp, _
                                   .nombreTrab = String.Concat(obj.responsable & " " & obj.appat & " " & obj.appmat), _
                                   .FechaInicio = obj.fechaInicio, _
                                   .FechaFinal = obj.fechaFin, _
                                   .modulo = obj.modulo _
                                 }
            consulta.Add(objRecurso)
        Next

        Return consulta
    End Function

End Class

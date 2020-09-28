Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class ProyectoPlaneacionBL
    Inherits BaseBL

    Public Sub Insert(ByVal proyectoBE As ProyectoPlaneacion)
        Dim objActividad As New Actividades
        Using ts As New TransactionScope
            'Se inserta proyectoBE
            HeliosData.ProyectoPlaneacion.Add(proyectoBE)
            'InsertProyectPart(proyectoBE)
            For Each movimientoBE In proyectoBE.Actividades
                HeliosData.Actividades.Add(movimientoBE)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Update(ByVal proyectoBE As ProyectoPlaneacion)
        Using ts As New TransactionScope
            Dim objConsulta As ProyectoPlaneacion = HeliosData.ProyectoPlaneacion.Where(Function(o) o.idProyecto = proyectoBE.idProyecto).First
            With objConsulta
                .Action = Business.Entity.BaseBE.EntityAction.INSERT
                .idEmpresa = objConsulta.idEmpresa
                .idEstablecimiento = objConsulta.idEstablecimiento
                .objetivo = objConsulta.objetivo
                .nombreProyecto = objConsulta.nombreProyecto
                .fechaInicio = objConsulta.fechaInicio
                .fechaFinal = objConsulta.fechaFinal
                .responsable = objConsulta.responsable
                .estadoCosto = proyectoBE.estadoCosto
                .modalidadServicio = objConsulta.modalidadServicio
                .nroContrato = objConsulta.nroContrato
                .ot = objConsulta.ot
                .pte = objConsulta.pte
                .usuarioModificacion = objConsulta.usuarioModificacion
                .fechaModificacion = proyectoBE.fechaModificacion
            End With
            'HeliosData.ObjectStateManager.GetObjectStateEntry(objConsulta).State.ToString()
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function UpdateModoTrabajo(ByVal proyectoBE As ProyectoPlaneacion, ByVal IdActividadMTAnt As Integer, ByVal EstadoMTAnt As String) As Boolean
        Dim ActividadBL As New actividadRecursoBL
        Dim TotalLiquidacion As New totalesLiquidacionBL
        Using ts As New TransactionScope
            ActividadBL.UpdateActividadRecursoMT(proyectoBE.refDocAprobacion, proyectoBE.anotacionEstado, IdActividadMTAnt, EstadoMTAnt)
            TotalLiquidacion.UpdateTotalLiquidacionID(proyectoBE.refDocAprobacion, IdActividadMTAnt)
            Dim objConsulta As ProyectoPlaneacion = HeliosData.ProyectoPlaneacion.Where(Function(o) o.idProyecto = proyectoBE.idProyecto).First
            With objConsulta
                .anotacionEstado = proyectoBE.anotacionEstado
                .refDocAprobacion = proyectoBE.refDocAprobacion
            End With
            'HeliosData.ObjectStateManager.GetObjectStateEntry(objConsulta).State.ToString()
            HeliosData.SaveChanges()
            ts.Complete()
            Return objConsulta.idProyecto
        End Using
    End Function

    Public Sub Delete(ByVal proyectoBE As ProyectoPlaneacion)
        Dim consulta = (From n In HeliosData.ProyectoPlaneacion _
                       Where n.idProyecto = proyectoBE.idProyecto).First
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(consulta)
        HeliosData.SaveChanges()
    End Sub

    Public Function GetProyectos(intIDEstable As Integer) As List(Of ProyectoPlaneacion)
        Return (From a In HeliosData.ProyectoPlaneacion Where a.idEstablecimiento = intIDEstable Select a).ToList
    End Function

    Public Function GetUbicaProyecto(intIDProyecto As Integer) As ProyectoPlaneacion
        Dim ObjProyecto As New ProyectoPlaneacion
        Dim consulta = (From a In HeliosData.ProyectoPlaneacion _
                    Join trab In HeliosData.Trabajador_PL On _
                    a.responsable Equals trab.codTrabajdor _
                    And a.idEstablecimiento Equals trab.idEstablecimiento _
                   Where a.idProyecto = intIDProyecto).First

        ObjProyecto = New ProyectoPlaneacion
        ObjProyecto.idProyecto = consulta.a.idProyecto
        ObjProyecto.idEmpresa = consulta.a.idEmpresa
        ObjProyecto.idEstablecimiento = consulta.a.idEstablecimiento
        ObjProyecto.nombreProyecto = consulta.a.nombreProyecto
        ObjProyecto.fechaEmision = consulta.a.fechaEmision
        ObjProyecto.objetivo = consulta.a.objetivo
        ObjProyecto.fechaInicio = consulta.a.fechaInicio
        ObjProyecto.fechaFinal = consulta.a.fechaFinal
        ObjProyecto.responsable = consulta.a.responsable
        ObjProyecto.NombreTrabajador = consulta.trab.appat & " " & consulta.trab.apmat & ", " & consulta.trab.nombres
        ObjProyecto.fechaEstadoCobro = consulta.a.fechaEstadoCobro
        ObjProyecto.estadoCosto = consulta.a.estadoCosto
        ObjProyecto.anotacionEstado = consulta.a.anotacionEstado
        ObjProyecto.refDocAprobacion = consulta.a.refDocAprobacion
        ObjProyecto.FechaInicioAprob = consulta.a.FechaInicioAprob
        ObjProyecto.FechaFinAprob = consulta.a.FechaFinAprob
        ObjProyecto.modalidadServicio = consulta.a.modalidadServicio
        ObjProyecto.nroContrato = consulta.a.nroContrato
        ObjProyecto.ot = consulta.a.ot
        ObjProyecto.pte = consulta.a.pte
        ObjProyecto.usuarioModificacion = consulta.a.usuarioModificacion
        ObjProyecto.fechaModificacion = consulta.a.fechaModificacion

        Return ObjProyecto
    End Function

    Public Sub UpdateModoTrabajo(ByVal proyectoBE As ProyectoPlaneacion)
        Using ts As New TransactionScope
            Dim objConsulta As ProyectoPlaneacion = HeliosData.ProyectoPlaneacion.Where(Function(o) o.idProyecto = proyectoBE.idProyecto).First
            With objConsulta
                .anotacionEstado = proyectoBE.anotacionEstado
                .refDocAprobacion = proyectoBE.refDocAprobacion
            End With
            'HeliosData.ObjectStateManager.GetObjectStateEntry(objConsulta).State.ToString()
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

End Class

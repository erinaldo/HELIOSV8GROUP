Imports Helios.Cont.Business.Entity

Public Class ProyectoPlaneacionSA
    Public Function GrabarProyecto(ByVal be As ProyectoPlaneacion) As Boolean
        Dim miServicio = General.GetHeliosProxy()
        miServicio.SaveProyecto(be)
        Return True
    End Function

    Public Function EditarProyecto(ByVal be As ProyectoPlaneacion) As Boolean
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EditarProyecto(be)
        Return True
    End Function

    'Public Sub EditarProyectoModoTrabajo(nProyecto As ProyectoPlaneacion)
    '    Dim miServicio = General.GetHeliosProxy()
    '    miServicio.EditarProyectoModoTrabajo(nProyecto)
    'End Sub

    Public Function DeleteProyecto(ByVal be As ProyectoPlaneacion) As Boolean
        Dim miServicio = General.GetHeliosProxy()
        miServicio.DeleteProyecto(be)
        Return True
    End Function

    Public Function ObtenerListaProyectos(intEstablecimiento As Integer) As List(Of ProyectoPlaneacion)
        Dim miServicio = General.GetHeliosProxy()
        Dim miLista As List(Of ProyectoPlaneacion)
        miLista = miServicio.GetListaProyectos(intEstablecimiento)
        Return miLista
    End Function

    Public Function UbicarProyecto(intIdProyecto As Integer) As ProyectoPlaneacion
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicaProyecto(intIdProyecto)
    End Function

    Public Function UpdateModoTrabajo(ByVal be As ProyectoPlaneacion, ByVal IdActividadMTAnt As Integer, ByVal EstadoMTAnt As String) As Boolean
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateModoTrabajo(be, IdActividadMTAnt, EstadoMTAnt)
        Return True
    End Function

    Public Sub EditarProyectoModoTrabajo(nProyecto As ProyectoPlaneacion)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EditarProyectoModoTrabajo(nProyecto)
    End Sub

End Class

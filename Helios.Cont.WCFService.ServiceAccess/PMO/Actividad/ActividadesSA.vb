Imports Helios.Cont.Business.Entity
Public Class ActividadesSA

    Public Function GetUbicarMontoContractual(intIDProyecto As Integer, strTipoRecurso As String, strFlag As String) As List(Of Actividades)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicarMontoContractual(intIDProyecto, strTipoRecurso, strFlag)
    End Function

    Public Sub GrabarActividadEquipo(nLista As List(Of Actividades), nProyecto As ProyectoPlaneacion)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarActividadEquipo(nLista, nProyecto)
    End Sub

    Public Sub UpdateIdPadreActividad(nLista As List(Of Actividades))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateIdPadreActividad(nLista)
    End Sub

    Public Function GetUbicarActividadPorModulo(intIdProyecto As Integer, strModulo As String)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicarActividadPorModulo(intIdProyecto, strModulo)
    End Function

    Public Function GetUbicarActividadPorModuloOcupacion(intIdProyecto As Integer, strModulo As String)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicarActividadPorModuloOcupa(intIdProyecto, strModulo)
    End Function

    Public Function ProyectoActividadGrabarTodo(ByVal be As Actividades) As Boolean
        Dim miServicio = General.GetHeliosProxy()
        miServicio.ProyectoActividadGrabarTodo(be)
        Return True
    End Function

    Public Function GetUbicarListaEDT(intIdProyecto As Integer, intIdPadre As Integer, strModulo As String) As List(Of Actividades)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicarListaEDT(intIdProyecto, intIdPadre, strModulo)
    End Function

    Public Function GetUbicaProyectoActividad(intProyecto As Integer, strModulo As String) As Actividades
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicaProyectoActividad(intProyecto, strModulo)
    End Function

    Public Function InsertarEDT(ByVal nEDT As Actividades) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.InsertarEDT(nEDT)
    End Function

    Public Sub GrabarActividadListaEDT(ByVal intIDProyecto As Integer, ByVal intIDEstable As Integer, ByVal srtTipoPlan As String)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarActividadListaEDT(intIDProyecto, intIDEstable, srtTipoPlan)
    End Sub

    Public Function UpdateEDT(ByVal nEDT As Actividades) As Boolean
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EditarEDT(nEDT)
        Return True
    End Function

    Public Function DeleteEDT(ByVal nEDT As Actividades) As Boolean
        Dim miServicio = General.GetHeliosProxy()
        miServicio.DeleteEDT(nEDT)
        Return True
    End Function

    Public Function GetUbicaEDT(intIdActividad As Integer) As Actividades
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicaEDT(intIdActividad)
    End Function

    Public Function ListaEDT(intIDProyecto As Integer, strTipoRecurso As String, strFlag As String) As List(Of Actividades)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListaEDT(intIDProyecto, strTipoRecurso, strFlag)
    End Function

    Public Function GetListaActividadPorProyecto(intIDProyecto As Integer, strTipoRecurso As String, strFlag As String) As List(Of Actividades)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaActividadPorProyecto(intIDProyecto, strTipoRecurso, strFlag)
    End Function

    Public Function GetBusquedaActividadGeneralPorEstado(intIDProyecto As Integer, strTipoRecurso As String, strEstado As String, strFlag As String) As List(Of Actividades)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetBusquedaActividadGeneralPorEstado(intIDProyecto, strTipoRecurso, strEstado, strFlag)
    End Function

End Class

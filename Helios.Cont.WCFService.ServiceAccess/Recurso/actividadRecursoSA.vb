Imports Helios.Cont.Business.Entity
Public Class actividadRecursoSA
    'NUEVO BL
    Public Function GetListaInsumosPorProyecto(intIDProyecto As Integer, strTipoRecurso As String) As List(Of actividadRecurso)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaInsumosPorProyecto(intIDProyecto, strTipoRecurso)
    End Function

    Public Function UpdateCotizacionFinal(nListaRecurso As List(Of actividadRecurso))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateCotizacionFinal(nListaRecurso)
        Return True
    End Function

    Public Sub SaveListaRecurso(nListaRecurso As List(Of actividadRecurso), nListaRecursoGasto As List(Of actividadRecurso), nListaRecursoEDT As List(Of Actividades), nLiquidacion As List(Of totalesLiquidacion))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.SaveListaRecurso(nListaRecurso, nListaRecursoGasto, nListaRecursoEDT, nLiquidacion)
    End Sub

    Public Sub InsertCotizacionFinal(nListaRecurso As List(Of actividadRecurso))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.InsertCotizacionFinal(nListaRecurso)
    End Sub

    Public Function SaveRecursoIniciacion(nRecurso As actividadRecurso, nLiquidacion As totalesLiquidacion) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveRecursoIniciacion(nRecurso, nLiquidacion)
    End Function

    Public Function SaveRecurso(nRecurso As actividadRecurso, nLiquidacion As totalesLiquidacion) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveRecurso(nRecurso, nLiquidacion)
    End Function

    Public Function SaveRecursoCotizacion(nRecurso As actividadRecurso, nLiquidacion As totalesLiquidacion) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveRecursoCotizacion(nRecurso, nLiquidacion)
    End Function

    Public Function GetConteoActividadRecursos(intIDProyecto As Integer) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetConteoActividadRecursos(intIDProyecto)
    End Function

    Public Function UpdateRecursoCotizacion(nRecurso As actividadRecurso, ByVal nRecursoDelete As totalesLiquidacion, nLiquidacion As totalesLiquidacion) As Boolean
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateRecursoCotizacion(nRecurso, nRecursoDelete, nLiquidacion)
        Return True
    End Function

    Public Function UpdateRecursoIniciacion(ByVal nRecurso As actividadRecurso, ByVal nRecursoDelete As totalesLiquidacion, nLiquidacion As totalesLiquidacion) As Boolean
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateRecursoIniciacion(nRecurso, nRecursoDelete, nLiquidacion)
        Return True
    End Function

    Public Function UpdateRecurso(ByVal nRecurso As actividadRecurso, ByVal nRecursoDelete As totalesLiquidacion, nLiquidacion As totalesLiquidacion) As Boolean
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateRecurso(nRecurso, nRecursoDelete, nLiquidacion)
        Return True
    End Function

    Public Function DeleteRecurso(nRecurso As actividadRecurso) As Boolean
        Dim miServicio = General.GetHeliosProxy()
        miServicio.DeleteRecurso(nRecurso)
        Return True
    End Function

    Public Function ListaRecursosCotizacionGasto(intIDProyecto As Integer, strSustento As String, strTipoPlan As String) As List(Of actividadRecurso)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListaRecursosCotizacionGasto(intIDProyecto, strSustento, strTipoPlan)
    End Function

    Public Function ListaRecursosCotizacionGastoFinal(intIDProyecto As Integer, strTipoRecurso As String, strSustentado As String) As List(Of actividadRecurso)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListaRecursosCotizacionGastoFinal(intIDProyecto, strTipoRecurso, strSustentado)
    End Function

    Public Function ListaRecursosGastosFinal(intIDProyecto As Integer, strTipoRecurso As String, strSustentado As String) As List(Of actividadRecurso)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListaRecursosGastosFinal(intIDProyecto, strTipoRecurso, strSustentado)
    End Function

    Public Function GetListaGastoPlaneacion(intIDProyecto As Integer, strTipoRecurso As String, intIDActividad As Integer) As List(Of actividadRecurso)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaGastoPlaneacion(intIDProyecto, strTipoRecurso, intIDActividad)
    End Function

    Public Function GetListaGPlaneacionIngreso(intIDProyecto As Integer, strTipoRecurso As String, intIDActividad As Integer) As List(Of actividadRecurso)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaGPlaneacionIngreso(intIDProyecto, strTipoRecurso, intIDActividad)
    End Function

    Public Function ListaRecursosGastoPreliminar(intIDProyecto As Integer, strTipoRecurso As String, strTipoPresupuesto As String, strTipoPlan As String) As List(Of actividadRecurso)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListaRecursosGastoPreliminar(intIDProyecto, strTipoRecurso, strTipoPresupuesto, strTipoPlan)
    End Function

    Public Function UbicaRecursoID(intIdActividad As Integer) As actividadRecurso
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicaRecursoID(intIdActividad)
    End Function

    Public Function UbicaCotizacionRecursoID(intIdActividad As Integer) As actividadRecurso
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicaCotizacionbRecursoID(intIdActividad)
    End Function

End Class

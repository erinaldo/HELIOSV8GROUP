Imports Helios.Cont.Business.Entity
Public Class LibroDiarioRPTSA

    Public Function ObtenerAsientosPorPeriodoFullReporte() As List(Of asiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerAsientosPorPeriodoFullReporte()
    End Function

    Public Function UbicarReporteAsientoPorDocumento(intIdDocumento As Integer) As List(Of asiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarReporteAsientoPorDocumento(intIdDocumento)
    End Function

    Public Function UbicarReporteAsientoPorEntidad(intidEntidad As Integer) As List(Of asiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarReporteAsientoPorEntidad(intidEntidad)
    End Function

    Public Function UbicarReporteAsientoPorTipo(srtidTipo As String) As List(Of asiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarReporteAsientoPorTipo(srtidTipo)
    End Function

    Public Function UbicarReporteAsientoPorFecha(srtFechaInicio As Date, srtFechaHasta As Date, srtidTipo As String) As List(Of asiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarReporteAsientoPorFecha(srtFechaInicio, srtFechaHasta, srtidTipo)
    End Function

    Public Function UbicarReporteAsientoPorPeriodo(srtFechaAnio As String, srtFechaMes As String) As List(Of asiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarReporteAsientoPorPeriodo(srtFechaAnio, srtFechaMes)
    End Function

    Public Function UbicarReporteAsientosPorPeriodoFull(srtFechaAnio As Integer) As List(Of asiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarReporteAsientosPorPeriodoFull(srtFechaAnio)
    End Function

    Public Function UbicarReporteAsientoPorAcumulado(dtpDesdeAnio As Date, dtphastaAnio As Date) As List(Of asiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarReporteAsientoPorAcumulado(dtpDesdeAnio, dtphastaAnio)
    End Function

End Class

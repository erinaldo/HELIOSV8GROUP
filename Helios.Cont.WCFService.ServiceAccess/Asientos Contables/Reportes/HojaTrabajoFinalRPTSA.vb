Imports Helios.Cont.Business.Entity
Public Class HojaTrabajoFinalRPTSA

    Public Function ListarDetallexCuenta(strPeriodo As String, intMes As String, cuenta As String) As List(Of movimiento)
        Dim miServicio = General.GetHeliosProxy()
        Dim miLista As List(Of movimiento)
        miLista = miServicio.ListarDetallexCuenta(strPeriodo, intMes, cuenta)
        Return miLista
    End Function

    Public Function BuscarHojaTrabajoFinalFullReporte(strPeriodo As Integer) As List(Of movimiento)
        Dim miServicio = General.GetHeliosProxy()
        Dim miLista As List(Of movimiento)
        miLista = miServicio.BuscarHojaTrabajoFinalFullReporte(strPeriodo)
        Return miLista
    End Function

    Public Function BuscarHojaTrabajoFinalPorMesReporte(strPeriodo As String, intMes As String) As List(Of movimiento)
        Dim miServicio = General.GetHeliosProxy()
        Dim miLista As List(Of movimiento)
        miLista = miServicio.BuscarHojaTrabajoFinalPorMesReporte(strPeriodo, intMes)
        Return miLista
    End Function

    Public Function BuscarHojaTrabajoFinalPorAcumuladoReporte(strFechaDesde As Date, strFechaHasta As Date) As List(Of movimiento)
        Dim miServicio = General.GetHeliosProxy()
        Dim miLista As List(Of movimiento)
        miLista = miServicio.BuscarHojaTrabajoFinalPorAcumuladoReporte(strFechaDesde, strFechaHasta)
        Return miLista
    End Function

End Class

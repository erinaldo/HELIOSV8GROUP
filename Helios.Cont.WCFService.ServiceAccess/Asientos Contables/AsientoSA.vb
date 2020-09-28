Imports Helios.Cont.Business.Entity

Public Class AsientoSA
    Public Sub ReingresarAsientoContable(objAsiento As asiento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.ReingresarAsientoContable(objAsiento)
    End Sub

    Public Function GetHojaTrabajoXmodulo(be As asiento) As List(Of usp_HojaTrabajoXmodulo_Result)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetHojaTrabajoXmodulo(be)
    End Function

    Public Function GetHojaTrabajCompras(be As asiento) As List(Of usp_HojaTrabajoCompras_Result)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetHojaTrabajCompras(be)
    End Function

    Public Function GetResumenLibroDiarioByPeriodo(be As asiento) As List(Of asiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetResumenLibroDiarioByPeriodo(be)
    End Function

    Public Sub EliminarAsientoCostos(be As asiento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarAsientoCostos(be)
    End Sub

    Public Function UbicarAsientoPorPeriodoXcodigo(srtFechaMes As Date, srtFechaAnio As Date, strAprobado As String, strCodigo As String) As List(Of asiento)
        Dim miServicio = General.GetHeliosProxy()
        Dim miLista As List(Of asiento)
        miLista = miServicio.UbicarAsientoPorPeriodoXcodigo(srtFechaMes, srtFechaAnio, strAprobado, strCodigo)
        Return miLista
    End Function

    Public Sub DeletePorIdAsiento(ByVal intIdAsiento As Integer)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.DeletePorIdAsiento(intIdAsiento)
    End Sub

    Public Sub ActualizarAsientoDetalleXidAsiento(objAsiento As asiento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.ActualizarAsientoDetalleXidAsiento(objAsiento)
    End Sub

    Public Function UbicarAsientoPorIDAsiento(intIdAsiento As Integer) As asiento
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarAsientoPorIDAsiento(intIdAsiento)
    End Function

    Public Sub ActualizarEstadoAprobado(ByVal asientos As List(Of asiento))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.ActualizarEstadoAprobado(asientos)
    End Sub

    Public Function ObtenerListaAsientos() As List(Of asiento)
        Dim miServicio = General.GetHeliosProxy()
        Dim miLista As List(Of asiento)
        miLista = miServicio.AsientoGetAll
        Return miLista
    End Function

    Public Function UbicarAsientoPorDocumento(intIdDocumento As Integer) As List(Of asiento)
        Dim miServicio = General.GetHeliosProxy()
        Dim miLista As List(Of asiento)
        miLista = miServicio.UbicarAsientoPorDocumento(intIdDocumento)
        Return miLista
    End Function
    Public Function UbicarAsientoPorTipo(srtidTipo As String) As List(Of asiento)
        Dim miServicio = General.GetHeliosProxy()
        Dim miLista As List(Of asiento)
        miLista = miServicio.UbicarAsientoPorTipo(srtidTipo)
        Return miLista
    End Function

    Public Function UbicarAsientoPorFecha(srtFechaInicio As Date, srtFechaHasta As Date, srtidTipo As String) As List(Of asiento)
        Dim miServicio = General.GetHeliosProxy()
        Dim miLista As List(Of asiento)
        miLista = miServicio.UbicarAsientoPorFecha(srtFechaInicio, srtFechaHasta, srtidTipo)
        Return miLista
    End Function

    Public Function UbicarAsientoPorPeriodo(srtFechaMes As Date, srtFechaAnio As Date, strAprobado As String) As List(Of asiento)
        Dim miServicio = General.GetHeliosProxy()
        Dim miLista As List(Of asiento)
        miLista = miServicio.UbicarAsientoPorPeriodo(srtFechaMes, srtFechaAnio, strAprobado)
        Return miLista
    End Function

    Public Function UbicarAsientoPorEntidad(intIdEntidad As Integer) As List(Of asiento)
        Dim miServicio = General.GetHeliosProxy()
        Dim miLista As List(Of asiento)
        miLista = miServicio.UbicarAsientoPorEntidad(intIdEntidad)
        Return miLista
    End Function

    Public Sub GrabarListaAsientosXConciliar(be As List(Of asiento))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarListaAsientosXConciliar(be)
    End Sub
End Class

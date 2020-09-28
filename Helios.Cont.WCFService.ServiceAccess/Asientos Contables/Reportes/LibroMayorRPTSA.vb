Imports Helios.Cont.Business.Entity
Public Class LibroMayorRPTSA

    Public Function GetUbicarMovimientoLibroMayorFullMensual(strPeriodo As List(Of String), periodo As String, mesPer As String) As List(Of movimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicarMovimientoLibroMayorFullMensual(strPeriodo, periodo, mesPer)
    End Function

    Public Function GetUbicarMovimientoLibroMayorFull(strPeriodo As List(Of String), periodo As String) As List(Of movimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicarMovimientoLibroMayorFull(strPeriodo, periodo)
    End Function

    Public Function GetUbicarMovimientoLibroMayorPorIdDocumento(strCuenta As String) As List(Of movimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicarMovimientoLibroMayorPorIdDocumento(strCuenta)
    End Function
End Class

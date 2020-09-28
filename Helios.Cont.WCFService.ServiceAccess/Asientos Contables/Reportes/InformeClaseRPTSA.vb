Imports Helios.Cont.Business.Entity
Public Class InformeClaseRPTSA
    Public Function BuscarInformePorClaseReporte(strCuenta As String, anio As String) As List(Of movimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.BuscarInformePorClaseReporte(strCuenta, anio)
    End Function

    Public Function BuscarInformePorClaseAcumuladoReporte(strFechaDesde As Date, strFechaHasta As Date, strCuenta As String) As List(Of movimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.BuscarInformePorClaseAcumuladoReporte(strFechaDesde, strFechaHasta, strCuenta)
    End Function

    Public Function BuscarInformePorClaseMesReporte(strPeriodo As String, intMes As String, strCuenta As String) As List(Of movimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.BuscarInformePorClaseMesReporte(strPeriodo, intMes, strCuenta)
    End Function
End Class

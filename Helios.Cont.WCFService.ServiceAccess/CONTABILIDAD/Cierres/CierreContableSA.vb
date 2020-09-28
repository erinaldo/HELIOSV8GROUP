Imports Helios.Cont.Business.Entity
Public Class CierreContableSA

    Public Function ReporteSaldoInicioXperiodoHojaTrabajo(intAnio As Integer, intMes As Integer, idEmpresa As String) As List(Of cierrecontable)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ReporteSaldoInicioXperiodoHojaTrabajo(intAnio, intMes, idEmpresa)
    End Function

    'HOJA DE TRABAJO
    Public Function ReporteSaldoInicioXperiodo(intAnio As Integer, intMes As Integer) As List(Of cierrecontable)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ReporteSaldoInicioXperiodo(intAnio, intMes)
    End Function

    Public Sub EliminarCierreContable(cierreBE As cierrecontable)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarCierreContable(cierreBE)
    End Sub

    Public Function RecuperarEstadoCierrePeriodo(strEmpresa As String, intIdEstablec As Integer, strPeriodo As String) As cierrecontable
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.RecuperarEstadoCierrePeriodo(strEmpresa, intIdEstablec, strPeriodo)
    End Function

    Public Sub AperturarPeriodo(strEmpresa As String, intIdEstablec As Integer, strPeriodo As String)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.AperturarPeriodo(strEmpresa, intIdEstablec, strPeriodo)
    End Sub

    Public Sub GrabarListaAsientos(lista As List(Of cierrecontable), asiento As asiento, documento As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarListaAsientos(lista, asiento, documento)
    End Sub

    Public Sub GrabarListaAsientosCierre(lista As List(Of cierrecontable))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarListaAsientosCierre(lista)
    End Sub

    Public Sub UpdateListaAsientos(lista As List(Of cierrecontable))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateListaAsientos(lista)
    End Sub

    Public Function GetCargarCierrePorPeriodo(idEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String) As List(Of cierrecontable)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetCargarCierrePorPeriodo(idEmpresa, intIdEstablecimiento, strPeriodo)
    End Function

    Function CierreCerrado(strIdEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String) As Boolean
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.CierreCerrado(strIdEmpresa, intIdEstablecimiento, strPeriodo)
    End Function

End Class

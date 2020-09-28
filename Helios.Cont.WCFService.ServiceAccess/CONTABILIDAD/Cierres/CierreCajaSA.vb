Imports Helios.Cont.Business.Entity
Public Class CierreCajaSA

    Public Function GetListado_cierreCajasPorPeriodo(cierreBE As cierreCaja) As List(Of cierreCaja)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListado_cierreCajasPorPeriodo(cierreBE)
    End Function

    Public Sub GrabarListaCierreCaja(lista As List(Of cierreCaja))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GrabarListaCierreCaja(lista)
    End Sub

    Public Sub EliminarCierreCaja(cierreBE As cierreCaja)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarCierreCaja(cierreBE)
    End Sub

    Public Function CajaTienePeriodoCerrado(strEmpresa As String, strperiodo As String, intIdEstaclecimiento As Integer) As Boolean
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.CajaTienePeriodoCerrado(strEmpresa, strperiodo, intIdEstaclecimiento)
    End Function

    Public Function RecuperarCierreCajaXEF(intAnio As Integer, intMes As Integer, intIdEF As Integer) As cierreCaja
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.RecuperarCierreCajaXEF(intAnio, intMes, intIdEF)
    End Function
End Class

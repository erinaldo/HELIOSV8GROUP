Imports Helios.Cont.Business.Entity
Public Class CierreInventarioSA
    Public Sub CerrarInventario(lista As List(Of cierreinventario))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.CerrarInventario(lista)
    End Sub

    Public Function GetListAnios(be As cierreinventario) As List(Of cierreinventario)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListAnios(be)
    End Function

    Public Function GetListMeses(be As cierreinventario) As List(Of cierreinventario)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListMeses(be)
    End Function

    Public Function GetListPeriodos(be As cierreinventario) As List(Of cierreinventario)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListPeriodos(be)
    End Function

    Public Sub CerrarByPeriodo(doc As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.CerrarByPeriodo(doc)
    End Sub

    Public Sub EliminarCierreInventario(cierreBE As cierreinventario)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarCierreInventario(cierreBE)
    End Sub

    Public Function RecuperarCierre(intAnio As Integer, intMes As Integer, intIdItem As Integer) As cierreinventario
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.RecuperarCierre(intAnio, intMes, intIdItem)
    End Function

    'Public Function RecuperarCierreListado(intAnio As Integer, intMes As Integer, intIdItem As Integer) As List(Of cierreinventario)
    '    Dim miServicio = General.GetHeliosProxy()
    '    Return miServicio.RecuperarCierreListado(intAnio, intMes, intIdItem)
    'End Function

    Public Function PeriodoInventarioCerrado(strempresa As String, strPeriodo As String) As Boolean
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.PeriodoInventarioCerrado(strempresa, strPeriodo)
    End Function

    Public Function ObtenerPeriodosCerrados(cierreBE As cierreinventario) As List(Of cierreinventario)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerPeriodosCerrados(cierreBE)
    End Function

    Public Function GetListado_cierreinventarioPorPeriodo(cierreBE As cierreinventario) As List(Of cierreinventario)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListado_cierreinventarioPorPeriodo(cierreBE)
    End Function
End Class

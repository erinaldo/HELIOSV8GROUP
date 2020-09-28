Imports Helios.Cont.Business.Entity
Public Class cierreResultadosSA


    Public Function GetUbicaCierreResultado(strIdEmpresa As String, anioPeriodo As String, mesPeriodo As String) As IList(Of cierreResultados)
        Dim miServicio = General.GetHeliosProxy()
        '   Dim miLista As List(Of empresa)
        Return miServicio.GetUbicaCierreResultado(strIdEmpresa, anioPeriodo, mesPeriodo)
    End Function

    Public Function UbicarCierrePorPeriodo(strIdEmpresa As String, Periodo As String) As cierreResultados
        Dim miServicio = General.GetHeliosProxy()
        '   Dim miLista As List(Of empresa)
        Return miServicio.GetUbicaCierrePorPeriodo(strIdEmpresa, Periodo)
    End Function

End Class

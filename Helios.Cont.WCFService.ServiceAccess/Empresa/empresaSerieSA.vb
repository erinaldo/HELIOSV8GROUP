Imports Helios.Cont.Business.Entity
Public Class empresaSerieSA
    Public Function GetUbicarSerieEmpresa(intIDEstablecimiento As Integer, strComprobante As String, strSerie As String) As EmpresaSeries
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicarSerieEmpresa(intIDEstablecimiento, strComprobante, strSerie)
    End Function


    Public Function obtenerSeriePorEEmpresa(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer) As List(Of EmpresaSeries)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.obtenerSeriePorEEmpresa(strIdEmpresa, intIdEstablecimiento)
    End Function

    Public Sub InsertEmpresaSerie(ByVal EmpresaSeriesBE As EmpresaSeries)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.InsertEmpresaSerie(EmpresaSeriesBE)
    End Sub

    Public Sub EditarEmpresaSerie(ByVal EmpresaSeriesBE As EmpresaSeries)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EditarEmpresaSerie(EmpresaSeriesBE)
    End Sub

    Public Sub DeleteEmpresaSerie(ByVal EmpresaSeriesBE As EmpresaSeries)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.DeleteEmpresaSerie(EmpresaSeriesBE)
    End Sub
End Class

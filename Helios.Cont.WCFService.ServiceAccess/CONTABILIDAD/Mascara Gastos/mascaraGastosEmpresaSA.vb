Imports Helios.Cont.Business.Entity
Public Class mascaraGastosEmpresaSA

    Public Function ObtenerMascaraGastos(ByVal strIdEmpresa As String, ByVal strCuentaPadre As String) As List(Of mascaraGastosEmpresa)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerMascaraGastos(strIdEmpresa, strCuentaPadre)
    End Function

    Public Function ListarCuentasServiciosPublicos(ByVal strIdEmpresa As String) As List(Of mascaraGastosEmpresa)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListarCuentasServiciosPublicos(strIdEmpresa)
    End Function

End Class

Imports Helios.Cont.Business.Entity

Public Class empresaSA
    Public Function Test() As String
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.Test
    End Function

    Public Sub EditarEmpresa(be As empresa, listaCierre As List(Of empresaCierreMensual))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EditarEmpresa(be, listaCierre)
    End Sub

    Public Function ObtenerListaEmpresas() As List(Of empresa)
        Dim miServicio = General.GetHeliosProxy()
        Dim miLista As List(Of empresa)
        miLista = miServicio.GetListaEmpresas
        Return miLista
    End Function

    Public Function UbicarEmpresaRuc(strIdEmpresa As String) As empresa
        Dim miServicio = General.GetHeliosProxy()
        '   Dim miLista As List(Of empresa)
        Return miServicio.GetUbicaEmpresaRuc(strIdEmpresa)
    End Function

    Public Sub InsertarEmpresa(empresaBE As empresa, ListaMascaraContable2 As List(Of mascaraContable2), ListaCuentaMascara As List(Of cuentaMascara), ListamascaraGastosEmpresa As List(Of mascaraGastosEmpresa), ListacuentaplanContableEmpresa As List(Of cuentaplanContableEmpresa))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.InsertarEmpresa(empresaBE, ListaMascaraContable2, ListaCuentaMascara, ListamascaraGastosEmpresa, ListacuentaplanContableEmpresa)
    End Sub

    Public Function GetEmpresasXcliente(idclientespk As Integer) As List(Of empresa)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetEmpresasXcliente(idclientespk)
    End Function

#Region "TRansporte"
    Public Sub CrearBackupDatabase()
        Dim miServicio = General.GetHeliosProxy()
        miServicio.CrearBackupDatabase()
    End Sub
#End Region

End Class

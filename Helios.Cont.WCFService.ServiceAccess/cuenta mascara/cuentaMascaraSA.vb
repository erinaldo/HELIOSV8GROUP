Imports Helios.Cont.Business.Entity
Public Class cuentaMascaraSA

    Public Function UbicarCuentaXmoduloXitem(strEmpresa As String, strParametro As String, strTipoItem As String, strModulo As String) As cuentaMascara
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarCuentaXmoduloXitem(strEmpresa, strParametro, strTipoItem, strModulo)
    End Function

    Public Function UbicarEmpresaXmodulo(strEmpresa As String, strModulo As String) As List(Of cuentaMascara)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarEmpresaXmodulo(strEmpresa, strModulo)
    End Function
End Class

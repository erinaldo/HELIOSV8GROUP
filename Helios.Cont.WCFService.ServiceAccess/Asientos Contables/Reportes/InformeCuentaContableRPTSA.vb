Imports Helios.Cont.Business.Entity
Public Class InformeCuentaContableRPTSA
    Public Function BuscarInformePorCuentaContableReporte(strCuenta As String, strRazonSocial As String) As List(Of movimiento)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.BuscarInformePorCuentaContableReporte(strCuenta, strRazonSocial)
    End Function
End Class

Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class cuentaMascaraBL
    Inherits BaseBL

    Public Function UbicarCuentaXmoduloXitem(strEmpresa As String, strParametro As String, strTipoItem As String, strModulo As String) As cuentaMascara
        Return (From n In HeliosData.cuentaMascara Where n.idEmpresa = strEmpresa And n.parametro = strParametro And n.tipo = strTipoItem And _
                n.idModulo = strModulo).FirstOrDefault
    End Function

    Public Function UbicarEmpresaXmodulo(strEmpresa As String, strModulo As String) As List(Of cuentaMascara)
        Return (From n In HeliosData.cuentaMascara Where n.idEmpresa = strEmpresa And _
                n.idModulo = strModulo).ToList
    End Function

End Class

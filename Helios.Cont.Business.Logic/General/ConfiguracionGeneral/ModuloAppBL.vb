Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class ModuloAppBL
    Inherits BaseBL

    Function ListaModulos() As List(Of moduloApp)
        Return (From n In HeliosData.moduloApp Select n).ToList
    End Function

    Function UbicarModuloPorCodigo(strIdModulo As String) As moduloApp
        Return (From n In HeliosData.moduloApp Where n.idModulo = strIdModulo).First
    End Function

End Class

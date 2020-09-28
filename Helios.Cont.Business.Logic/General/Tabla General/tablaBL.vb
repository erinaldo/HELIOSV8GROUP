Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class tablaBL
    Inherits BaseBL

    Function GetListaTabla() As List(Of tabla)
        Return (From a In HeliosData.tabla Select a).ToList
    End Function

End Class

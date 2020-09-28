Imports System.Transactions
Imports Helios.Cont.Business.Entity

Public Class cajaUsuarioDineroEntregadoBL
    Inherits BaseBL

    Public Sub GetGrabarCierreCaja(be As cajaUsuarioDineroEntregado)
        Using ts As New TransactionScope()
            HeliosData.cajaUsuarioDineroEntregado.Add(be)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

End Class

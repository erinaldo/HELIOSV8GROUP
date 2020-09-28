Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class JerarquiaBL
    Inherits BaseBL

    Public Sub SaveJerarquia(ByVal Jerarq As List(Of jerarquia))
        Try
            For Each i In Jerarq
                validarSave(i)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Public Sub validarSave(ByVal JerarBe As jerarquia)
        Using ts As New TransactionScope

            HeliosData.jerarquia.Add(JerarBe)
            HeliosData.SaveChanges()
            ts.Complete()

        End Using
    End Sub



    Public Function GetObtenerJerar(Idorgani As Integer) As List(Of jerarquia)
        Return (From a In HeliosData.jerarquia Where a.idCentroCosto = Idorgani Select a).ToList
    End Function
End Class


Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class perfilAnexoBL
    Inherits BaseBL

    Public Sub SavePerfilAnexo(ByVal PerfilAnexoBE As List(Of perfilAnexo))
        Try
            For Each i In PerfilAnexoBE
                SavePerfilAnexoSingle(i)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Public Function SavePerfilAnexoSingle(ByVal PerfilAnexoBE As perfilAnexo) As perfilAnexo
        Try

            Using ts As New TransactionScope
                HeliosData.perfilAnexo.Add(PerfilAnexoBE)
                HeliosData.SaveChanges()
                ts.Complete()
            End Using

            Return PerfilAnexoBE

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub UpdatePerfilAnexoSingle(ByVal PerfilAnexoBE As perfilAnexo)
        Try

            Using ts As New TransactionScope

                Dim consulta = (From a In HeliosData.perfilAnexo Where a.idCargo = PerfilAnexoBE.idCargo And a.idCentroCosto = PerfilAnexoBE.idCentroCosto Select a).FirstOrDefault

                If (Not IsNothing(consulta)) Then

                    consulta.estado = "N"
                    HeliosData.SaveChanges()
                    ts.Complete()
                End If


            End Using

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetObtenerPerfilAnexo(PerfilAnexoBE As perfilAnexo) As List(Of perfilAnexo)
        'Return (From a In HeliosData.perfilAnexo Where a.idOrganigrama = PerfilAnexoBE.idOrganigrama Select a).ToList
    End Function

    Public Function GetObtenerPerfilAnexoXID(PerfilAnexoBE As perfilAnexo) As List(Of perfilAnexo)
        Return (From a In HeliosData.perfilAnexo Where a.tipo = PerfilAnexoBE.tipo Select a).ToList
    End Function

    Public Function GetObtenerPerfilIDestablecimiento(PerfilAnexoBE As perfilAnexo) As List(Of perfilAnexo)
        Return (From a In HeliosData.perfilAnexo Where a.idCentroCosto = PerfilAnexoBE.idCentroCosto Select a).ToList
    End Function

End Class

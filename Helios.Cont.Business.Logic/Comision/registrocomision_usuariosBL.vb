Imports System.Data.Entity.Migrations
Imports System.Transactions
Imports Helios.Cont.Business.Entity
Imports System.Data.Entity
Public Class registrocomision_usuariosBL
    Inherits BaseBL

    Public Sub registrocomision_usuariosSave(be As registrocomision_usuarios)
        Using ts As New TransactionScope

            Select Case be.Action
                Case BaseBE.EntityAction.INSERT
                    HeliosData.registrocomision_usuarios.Add(be)
                Case BaseBE.EntityAction.UPDATE
                    HeliosData.registrocomision_usuarios.AddOrUpdate(be)
                Case BaseBE.EntityAction.DELETE

            End Select

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

End Class

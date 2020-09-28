Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class mascaracontableBL
    Inherits BaseBL

    Public Function Insert(ByVal mascaracontableBE As mascaracontable) As Integer
        Using ts As New TransactionScope
            HeliosData.mascaracontable.Add(mascaracontableBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return mascaracontableBE.idMascaraContable
        End Using
    End Function

    Public Sub Update(ByVal mascaracontableBE As mascaracontable)
        Using ts As New TransactionScope
            Dim maskcontable As mascaracontable = HeliosData.mascaracontable.Where(Function(o) _
                                            o.idMascaraContable = mascaracontableBE.idMascaraContable).First()

            maskcontable.idEmpresa = mascaracontableBE.idEmpresa
            maskcontable.idEstablecimiento = mascaracontableBE.idEstablecimiento
            maskcontable.descripcion = mascaracontableBE.descripcion
            maskcontable.usuarioModificacion = mascaracontableBE.usuarioModificacion
            maskcontable.fechaModificacion = mascaracontableBE.fechaModificacion
             
            'HeliosData.ObjectStateManager.GetObjectStateEntry(maskcontable).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Public Sub Delete(ByVal mascaracontableBE As mascaracontable)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(mascaracontableBE)
    End Sub

    Public Function GetListar_mascaracontable() As List(Of mascaracontable)
        Return (From a In HeliosData.mascaracontable Select a).ToList
    End Function

    Public Function GetUbicar_mascaracontablePorID(idMascaraContable As Integer) As mascaracontable
        Return (From a In HeliosData.mascaracontable
                 Where a.idMascaraContable = idMascaraContable Select a).First
    End Function
End Class

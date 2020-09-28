Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class entesRegaludoresTCBL
    Inherits BaseBL

    Public Function Insert(ByVal entesRegaludoresTCBE As entesRegaludoresTC) As Integer
        Using ts As New TransactionScope
            HeliosData.entesRegaludoresTC.Add(entesRegaludoresTCBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return entesRegaludoresTCBE.idRegulador
        End Using
    End Function

    Public Sub Update(ByVal entesRegaludoresTCBE As entesRegaludoresTC)
        Using ts As New TransactionScope
            Dim entesRegaludoresTC As entesRegaludoresTC = HeliosData.entesRegaludoresTC.Where(Function(o) _
                                            o.idRegulador = entesRegaludoresTCBE.idRegulador).First()

            entesRegaludoresTC.desripción = entesRegaludoresTCBE.desripción
            entesRegaludoresTC.siglas = entesRegaludoresTCBE.siglas
            entesRegaludoresTC.usuarioModificacion = entesRegaludoresTCBE.usuarioModificacion
            entesRegaludoresTC.fechaModificacion = entesRegaludoresTCBE.fechaModificacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(entesRegaludoresTC).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal entesRegaludoresTCBE As entesRegaludoresTC)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(entesRegaludoresTCBE)
    End Sub

    Public Function GetListar_entesRegaludoresTC() As List(Of entesRegaludoresTC)
        Return (From a In HeliosData.entesRegaludoresTC Select a).ToList
    End Function

    Public Function GetUbicar_entesRegaludoresTCPorID(idRegulador As Integer) As entesRegaludoresTC
        Return (From a In HeliosData.entesRegaludoresTC
                 Where a.idRegulador = idRegulador Select a).First
    End Function
End Class

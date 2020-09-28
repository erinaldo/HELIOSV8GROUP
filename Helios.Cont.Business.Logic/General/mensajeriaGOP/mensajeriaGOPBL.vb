Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class mensajeriaGOPBL
    Inherits BaseBL

    Public Function Insert(ByVal mensajeriaGOPBE As mensajeriaGOP) As Integer
        Using ts As New TransactionScope
            HeliosData.mensajeriaGOP.Add(mensajeriaGOPBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return mensajeriaGOPBE.seuencia
        End Using
    End Function

    Public Sub Update(ByVal mensajeriaGOPBE As mensajeriaGOP)
        Using ts As New TransactionScope
            Dim msnGOP As mensajeriaGOP = HeliosData.mensajeriaGOP.Where(Function(o) _
                                            o.seuencia = mensajeriaGOPBE.seuencia _
                                            And o.idActividad = mensajeriaGOPBE.idActividad).First()

            msnGOP.fechaMensaje = mensajeriaGOPBE.fechaMensaje
            msnGOP.horaMensaje = mensajeriaGOPBE.horaMensaje
            msnGOP.comentario = mensajeriaGOPBE.comentario
            msnGOP.usuarioActualizacion = mensajeriaGOPBE.usuarioActualizacion
            msnGOP.fechaActualizacion = mensajeriaGOPBE.fechaActualizacion
 
            'HeliosData.ObjectStateManager.GetObjectStateEntry(msnGOP).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Public Sub Delete(ByVal mensajeriaGOPBE As mensajeriaGOP)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(mensajeriaGOPBE)
    End Sub

    Public Function GetListar_mensajeriaGOP() As List(Of mensajeriaGOP)
        Return (From a In HeliosData.mensajeriaGOP Select a).ToList
    End Function

    Public Function GetUbicar_mensajeriaGOPPorID(seuencia As Integer) As mensajeriaGOP
        Return (From a In HeliosData.mensajeriaGOP
                 Where a.seuencia = seuencia Select a).First
    End Function
End Class

Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class documentoPrestamoDetalleBL
    Inherits BaseBL

    Public Function Insert(ByVal documentoPrestamoDetalleBE As documentoPrestamoDetalle) As Integer
        Using ts As New TransactionScope
            HeliosData.documentoPrestamoDetalle.Add(documentoPrestamoDetalleBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return documentoPrestamoDetalleBE.Secuencia
        End Using
    End Function

    Public Sub Update(ByVal documentoPrestamoDetalleBE As documentoPrestamoDetalle)
        Using ts As New TransactionScope
            Dim docPrestamoDetalle As documentoPrestamoDetalle = HeliosData.documentoPrestamoDetalle.Where(Function(o) _
                                            o.idDocumento = documentoPrestamoDetalleBE.idDocumento _
                                            And o.secuencia = documentoPrestamoDetalleBE.secuencia).First()

            'docPrestamoDetalle.fecha = documentoPrestamoDetalleBE.fecha
            docPrestamoDetalle.montoSoles = documentoPrestamoDetalleBE.montoSoles
            docPrestamoDetalle.montoUsd = documentoPrestamoDetalleBE.montoUsd
            'docPrestamoDetalle.montoItf = documentoPrestamoDetalleBE.montoItf
            'docPrestamoDetalle.montoItfusd = documentoPrestamoDetalleBE.montoItf
            'docPrestamoDetalle.montoInteresSoles = documentoPrestamoDetalleBE.montoInteresSoles
            'docPrestamoDetalle.montoInteresUSD = documentoPrestamoDetalleBE.montoInteresUSD
            'docPrestamoDetalle.entregado = documentoPrestamoDetalleBE.entregado
            ' docPrestamoDetalle.documentoPrestamoAfectado = documentoPrestamoDetalleBE.documentoPrestamoAfectado
            docPrestamoDetalle.idCuota = documentoPrestamoDetalleBE.idCuota
            docPrestamoDetalle.usuarioModificacion = documentoPrestamoDetalleBE.usuarioModificacion
            docPrestamoDetalle.fechaModificacion = documentoPrestamoDetalleBE.usuarioModificacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(docPrestamoDetalle).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal documentoPrestamoDetalleBE As documentoPrestamoDetalle)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(documentoPrestamoDetalleBE)
    End Sub

    Public Function GetListar_documentoPrestamoDetalle() As List(Of documentoPrestamoDetalle)
        Return (From a In HeliosData.documentoPrestamoDetalle Select a).ToList
    End Function

    Public Function GetUbicar_documentoPrestamoDetallePorID(Secuencia As Integer) As documentoPrestamoDetalle
        Return (From a In HeliosData.documentoPrestamoDetalle
                 Where a.secuencia = Secuencia Select a).First
    End Function
End Class

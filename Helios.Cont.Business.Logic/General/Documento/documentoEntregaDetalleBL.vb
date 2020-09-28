Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class documentoEntregaDetalleBL

    Inherits BaseBL

    Public Function Insert(ByVal documentoEntregaDetalleBE As documentoEntregaDetalle) As Integer
        Using ts As New TransactionScope
            HeliosData.documentoEntregaDetalle.Add(documentoEntregaDetalleBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return documentoEntregaDetalleBE.Secuencia
        End Using
    End Function

    Public Sub Update(ByVal documentoEntregaDetalleBE As documentoEntregaDetalle)
        Using ts As New TransactionScope
            Dim docEntregaDetalle As documentoEntregaDetalle = HeliosData.documentoEntregaDetalle.Where(Function(o) _
                                            o.idDocumento = documentoEntregaDetalleBE.idDocumento _
                                            And o.secuencia = documentoEntregaDetalleBE.secuencia).First()

            docEntregaDetalle.idItem = documentoEntregaDetalleBE.idItem
            docEntregaDetalle.destino = documentoEntregaDetalleBE.destino
            docEntregaDetalle.nombreItem = documentoEntregaDetalleBE.nombreItem
            docEntregaDetalle.ImporteMN = documentoEntregaDetalleBE.ImporteMN
            docEntregaDetalle.ImporteME = documentoEntregaDetalleBE.ImporteME
            docEntregaDetalle.usuarioActualizacion = documentoEntregaDetalleBE.usuarioActualizacion
            docEntregaDetalle.fechaActualizacion = documentoEntregaDetalleBE.fechaActualizacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(docEntregaDetalle).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal documentoEntregaDetalleBE As documentoEntregaDetalle)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(documentoEntregaDetalleBE)
    End Sub

    Public Function GetListar_documentoEntregaDetalle() As List(Of documentoEntregaDetalle)
        Return (From a In HeliosData.documentoEntregaDetalle Select a).ToList
    End Function

    Public Function GetUbicar_documentoEntregaDetallePorID(Secuencia As Integer) As documentoEntregaDetalle
        Return (From a In HeliosData.documentoEntregaDetalle
                 Where a.secuencia = Secuencia Select a).First
    End Function

End Class

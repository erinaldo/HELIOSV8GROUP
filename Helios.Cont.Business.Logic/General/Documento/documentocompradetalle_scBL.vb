Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class documentocompradetalle_scBL
    Inherits BaseBL
    Public Function Insert(ByVal documentocompradetalle_scBE As documentocompradetalle_sc) As Integer
        Using ts As New TransactionScope
            HeliosData.documentocompradetalle_sc.Add(documentocompradetalle_scBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return documentocompradetalle_scBE.secuencia
        End Using
    End Function

    Public Sub Update(ByVal documentocompradetalle_scBE As documentocompradetalle_sc)
        Using ts As New TransactionScope
            Dim docCompradetalle_sc As documentocompradetalle_sc = HeliosData.documentocompradetalle_sc.Where(Function(o) _
                                            o.idDocumento = documentocompradetalle_scBE.idDocumento _
                                            And o.secuencia = documentocompradetalle_scBE.secuencia).First()

            docCompradetalle_sc.idItem = documentocompradetalle_scBE.idItem
            docCompradetalle_sc.descripcionItem = documentocompradetalle_scBE.descripcionItem
            docCompradetalle_sc.destino = documentocompradetalle_scBE.destino
            docCompradetalle_sc.unidad1 = documentocompradetalle_scBE.unidad1
            docCompradetalle_sc.cantidad1 = documentocompradetalle_scBE.cantidad1
            docCompradetalle_sc.unidad2 = documentocompradetalle_scBE.unidad2
            docCompradetalle_sc.cantidad2 = documentocompradetalle_scBE.cantidad2
            docCompradetalle_sc.precioUnitario = documentocompradetalle_scBE.precioUnitario
            docCompradetalle_sc.precioUnitarioUS = documentocompradetalle_scBE.precioUnitarioUS
            docCompradetalle_sc.importe = documentocompradetalle_scBE.importe
            docCompradetalle_sc.importeUS = documentocompradetalle_scBE.importeUS
            docCompradetalle_sc.montokardex = documentocompradetalle_scBE.montokardex
            docCompradetalle_sc.montoIsc = documentocompradetalle_scBE.montoIsc
            docCompradetalle_sc.montoIgv = documentocompradetalle_scBE.montoIgv
            docCompradetalle_sc.otrosTributos = documentocompradetalle_scBE.otrosTributos
            docCompradetalle_sc.montokardexUS = documentocompradetalle_scBE.montokardexUS
            docCompradetalle_sc.montoIscUS = documentocompradetalle_scBE.montoIscUS
            docCompradetalle_sc.montoIgvUS = documentocompradetalle_scBE.montoIgvUS
            docCompradetalle_sc.otrosTributosUS = documentocompradetalle_scBE.otrosTributosUS
            docCompradetalle_sc.preEvento = documentocompradetalle_scBE.preEvento
            docCompradetalle_sc.saldoImporteNota = documentocompradetalle_scBE.saldoImporteNota
            docCompradetalle_sc.saldoImporteNotaUSD = documentocompradetalle_scBE.saldoImporteNotaUSD
            docCompradetalle_sc.usuarioModificacion = documentocompradetalle_scBE.usuarioModificacion
            docCompradetalle_sc.fechaModificacion = documentocompradetalle_scBE.fechaModificacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(docCompradetalle_sc).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal documentocompradetalle_scBE As documentocompradetalle_sc)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(documentocompradetalle_scBE)
    End Sub

    Public Function GetListar_documentocompradetalle_sc() As List(Of documentocompradetalle_sc)
        Return (From a In HeliosData.documentocompradetalle_sc Select a).ToList
    End Function

    Public Function GetUbicar_documentocompradetalle_scPorID(Secuencia As Integer) As documentocompradetalle_sc
        Return (From a In HeliosData.documentocompradetalle_sc
                 Where a.secuencia = Secuencia Select a).First
    End Function
End Class

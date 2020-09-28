Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class documentoVentaDetalle_scBL
    Inherits BaseBL

    Public Function Insert(ByVal documentoVentaDetalle_scBE As documentoVentaDetalle_sc) As Integer
        Using ts As New TransactionScope
            HeliosData.documentoVentaDetalle_sc.Add(documentoVentaDetalle_scBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return documentoVentaDetalle_scBE.Secuencia
        End Using
    End Function

    Public Sub Update(ByVal documentoVentaDetalle_scBE As documentoVentaDetalle_sc)
        Using ts As New TransactionScope
            Dim docVentaDetalle_sc As documentoVentaDetalle_sc = HeliosData.documentoVentaDetalle_sc.Where(Function(o) _
                                            o.idDocumento = documentoVentaDetalle_scBE.idDocumento _
                                            And o.secuencia = documentoVentaDetalle_scBE.secuencia).First()

            docVentaDetalle_sc.idItem = documentoVentaDetalle_scBE.idItem
            docVentaDetalle_sc.descripcionItem = documentoVentaDetalle_scBE.descripcionItem
            docVentaDetalle_sc.destino = documentoVentaDetalle_scBE.destino
            docVentaDetalle_sc.unidad1 = documentoVentaDetalle_scBE.unidad1
            docVentaDetalle_sc.cantidad1 = documentoVentaDetalle_scBE.cantidad1
            docVentaDetalle_sc.unidad2 = documentoVentaDetalle_scBE.unidad2
            docVentaDetalle_sc.cantidad2 = documentoVentaDetalle_scBE.cantidad2
            docVentaDetalle_sc.precioUnitario = documentoVentaDetalle_scBE.precioUnitario
            docVentaDetalle_sc.precioUnitarioUS = documentoVentaDetalle_scBE.precioUnitarioUS
            docVentaDetalle_sc.importe = documentoVentaDetalle_scBE.importe
            docVentaDetalle_sc.importeUS = documentoVentaDetalle_scBE.importeUS
            docVentaDetalle_sc.montokardex = documentoVentaDetalle_scBE.montokardex
            docVentaDetalle_sc.montoIsc = documentoVentaDetalle_scBE.montoIsc
            docVentaDetalle_sc.montoIgv = documentoVentaDetalle_scBE.montoIgv
            docVentaDetalle_sc.otrosTributos = documentoVentaDetalle_scBE.otrosTributos
            docVentaDetalle_sc.montokardexUS = documentoVentaDetalle_scBE.montokardexUS
            docVentaDetalle_sc.montoIscUS = documentoVentaDetalle_scBE.montoIscUS
            docVentaDetalle_sc.montoIgvUS = documentoVentaDetalle_scBE.montoIgvUS
            docVentaDetalle_sc.otrosTributosUS = documentoVentaDetalle_scBE.otrosTributosUS
            docVentaDetalle_sc.usuarioModificacion = documentoVentaDetalle_scBE.usuarioModificacion
            docVentaDetalle_sc.fechaModificacion = documentoVentaDetalle_scBE.fechaModificacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(docVentaDetalle_sc).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal documentoVentaDetalle_scBE As documentoVentaDetalle_sc)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(documentoVentaDetalle_scBE)
    End Sub

    Public Function GetListar_documentoVentaDetalle_sc() As List(Of documentoVentaDetalle_sc)
        Return (From a In HeliosData.documentoVentaDetalle_sc Select a).ToList
    End Function

    Public Function GetUbicar_documentoVentaDetalle_scPorID(Secuencia As Integer) As documentoVentaDetalle_sc
        Return (From a In HeliosData.documentoVentaDetalle_sc
                 Where a.secuencia = Secuencia Select a).First
    End Function
End Class

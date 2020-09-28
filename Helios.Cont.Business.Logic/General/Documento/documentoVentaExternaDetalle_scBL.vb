Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class documentoVentaExternaDetalle_scBL
    Inherits BaseBL

    Public Function Insert(ByVal documentoVentaExternaDetalle_scBE As documentoVentaExternaDetalle_sc) As Integer
        Using ts As New TransactionScope
            HeliosData.documentoVentaExternaDetalle_sc.Add(documentoVentaExternaDetalle_scBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return documentoVentaExternaDetalle_scBE.secuencia
        End Using
    End Function

    Public Sub Update(ByVal documentoVentaExternaDetalle_scBE As documentoVentaExternaDetalle_sc)
        Using ts As New TransactionScope
            Dim docVentaExternaDetalle_sc As documentoVentaExternaDetalle_sc = HeliosData.documentoVentaExternaDetalle_sc.Where(Function(o) _
                                            o.idDocumento = documentoVentaExternaDetalle_scBE.idDocumento _
                                            And o.secuencia = documentoVentaExternaDetalle_scBE.secuencia).First()

            docVentaExternaDetalle_sc.idItem = documentoVentaExternaDetalle_scBE.idItem
            docVentaExternaDetalle_sc.descripcionItem = documentoVentaExternaDetalle_scBE.descripcionItem
            docVentaExternaDetalle_sc.destino = documentoVentaExternaDetalle_scBE.destino
            docVentaExternaDetalle_sc.unidad1 = documentoVentaExternaDetalle_scBE.unidad1
            docVentaExternaDetalle_sc.cantidad1 = documentoVentaExternaDetalle_scBE.cantidad1
            docVentaExternaDetalle_sc.unidad2 = documentoVentaExternaDetalle_scBE.unidad2
            docVentaExternaDetalle_sc.cantidad2 = documentoVentaExternaDetalle_scBE.cantidad2
            docVentaExternaDetalle_sc.precioUnitario = documentoVentaExternaDetalle_scBE.precioUnitario
            docVentaExternaDetalle_sc.precioUnitarioUS = documentoVentaExternaDetalle_scBE.precioUnitarioUS
            docVentaExternaDetalle_sc.importe = documentoVentaExternaDetalle_scBE.importe
            docVentaExternaDetalle_sc.importeUS = documentoVentaExternaDetalle_scBE.importeUS
            docVentaExternaDetalle_sc.montokardex = documentoVentaExternaDetalle_scBE.montokardex
            docVentaExternaDetalle_sc.montoIsc = documentoVentaExternaDetalle_scBE.montoIsc
            docVentaExternaDetalle_sc.montoIgv = documentoVentaExternaDetalle_scBE.montoIgv
            docVentaExternaDetalle_sc.otrosTributos = documentoVentaExternaDetalle_scBE.otrosTributos
            docVentaExternaDetalle_sc.montokardexUS = documentoVentaExternaDetalle_scBE.montokardexUS
            docVentaExternaDetalle_sc.montoIscUS = documentoVentaExternaDetalle_scBE.montoIscUS
            docVentaExternaDetalle_sc.montoIgvUS = documentoVentaExternaDetalle_scBE.montoIgvUS
            docVentaExternaDetalle_sc.otrosTributosUS = documentoVentaExternaDetalle_scBE.otrosTributosUS
            docVentaExternaDetalle_sc.usuarioModificacion = documentoVentaExternaDetalle_scBE.usuarioModificacion
            docVentaExternaDetalle_sc.fechaModificacion = documentoVentaExternaDetalle_scBE.fechaModificacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(docVentaExternaDetalle_sc).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal documentoVentaExternaDetalle_scBE As documentoVentaExternaDetalle_sc)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(documentoVentaExternaDetalle_scBE)
    End Sub

    Public Function GetListar_documentoVentaExternaDetalle_sc() As List(Of documentoVentaExternaDetalle_sc)
        Return (From a In HeliosData.documentoVentaExternaDetalle_sc Select a).ToList
    End Function

    Public Function GetUbicar_documentoVentaExternaDetalle_scPorID(Secuencia As Integer) As documentoVentaExternaDetalle_sc
        Return (From a In HeliosData.documentoVentaExternaDetalle_sc
                 Where a.secuencia = Secuencia Select a).First
    End Function
End Class

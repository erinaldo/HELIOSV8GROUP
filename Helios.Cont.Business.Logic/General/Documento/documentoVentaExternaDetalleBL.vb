Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class documentoVentaExternaDetalleBL
    Inherits BaseBL

    Public Function Insert(ByVal documentoVentaExternaDetalleBE As documentoVentaExternaDetalle) As Integer
        Using ts As New TransactionScope
            HeliosData.documentoVentaExternaDetalle.Add(documentoVentaExternaDetalleBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return documentoVentaExternaDetalleBE.secuencia
        End Using
    End Function

    Public Sub Update(ByVal documentoVentaExternaDetalleBE As documentoVentaExternaDetalle)
        Using ts As New TransactionScope
            Dim docVentaExternaDetalle As documentoVentaExternaDetalle = HeliosData.documentoVentaExternaDetalle.Where(Function(o) _
                                            o.idDocumento = documentoVentaExternaDetalleBE.idDocumento _
                                            And o.secuencia = documentoVentaExternaDetalleBE.secuencia).First()

            docVentaExternaDetalle.idAlmacen = documentoVentaExternaDetalleBE.idAlmacen
            docVentaExternaDetalle.establecimientoOrigen = documentoVentaExternaDetalleBE.establecimientoOrigen
            docVentaExternaDetalle.cuentaOrigen = documentoVentaExternaDetalleBE.cuentaOrigen
            docVentaExternaDetalle.idItem = documentoVentaExternaDetalleBE.idItem
            docVentaExternaDetalle.tipoExistencia = documentoVentaExternaDetalleBE.tipoExistencia
            docVentaExternaDetalle.idOrigen = documentoVentaExternaDetalleBE.idOrigen
            docVentaExternaDetalle.destino = documentoVentaExternaDetalleBE.destino
            docVentaExternaDetalle.unidad1 = documentoVentaExternaDetalleBE.unidad1
            docVentaExternaDetalle.monto1 = documentoVentaExternaDetalleBE.monto1
            docVentaExternaDetalle.unidad2 = documentoVentaExternaDetalleBE.unidad2
            docVentaExternaDetalle.monto2 = documentoVentaExternaDetalleBE.monto2
            docVentaExternaDetalle.precioUnitario = documentoVentaExternaDetalleBE.precioUnitario
            docVentaExternaDetalle.precioUnitarioUS = documentoVentaExternaDetalleBE.precioUnitarioUS
            docVentaExternaDetalle.importe = documentoVentaExternaDetalleBE.importe
            docVentaExternaDetalle.importeUS = documentoVentaExternaDetalleBE.importeUS
            docVentaExternaDetalle.bonificacion = documentoVentaExternaDetalleBE.bonificacion
            docVentaExternaDetalle.montokardex = documentoVentaExternaDetalleBE.montokardex
            docVentaExternaDetalle.montoIsc = documentoVentaExternaDetalleBE.montoIsc
            docVentaExternaDetalle.montoIgv = documentoVentaExternaDetalleBE.montoIgv
            docVentaExternaDetalle.otrosTributos = documentoVentaExternaDetalleBE.otrosTributos
            docVentaExternaDetalle.montokardexUS = documentoVentaExternaDetalleBE.montokardexUS
            docVentaExternaDetalle.montoIscUS = documentoVentaExternaDetalleBE.montoIscUS
            docVentaExternaDetalle.montoIgvUS = documentoVentaExternaDetalleBE.montoIgvUS
            docVentaExternaDetalle.otrosTributosUS = documentoVentaExternaDetalleBE.otrosTributosUS
            docVentaExternaDetalle.estadoMovimiento = documentoVentaExternaDetalleBE.estadoMovimiento
            docVentaExternaDetalle.usuarioModificacion = documentoVentaExternaDetalleBE.usuarioModificacion
            docVentaExternaDetalle.fechaModificacion = documentoVentaExternaDetalleBE.fechaModificacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(docVentaExternaDetalle).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal documentoVentaExternaDetalleBE As documentoVentaExternaDetalle)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(documentoVentaExternaDetalleBE)
    End Sub

    Public Function GetListar_documentoVentaExternaDetalle() As List(Of documentoVentaExternaDetalle)
        Return (From a In HeliosData.documentoVentaExternaDetalle Select a).ToList
    End Function

    Public Function GetUbicar_documentoVentaExternaDetallePorID(Secuencia As Integer) As documentoVentaExternaDetalle
        Return (From a In HeliosData.documentoVentaExternaDetalle
                 Where a.secuencia = Secuencia Select a).First
    End Function
End Class

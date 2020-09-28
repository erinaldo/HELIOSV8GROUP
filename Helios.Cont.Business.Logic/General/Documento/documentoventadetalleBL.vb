Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class documentoventadetalleBL
    Inherits BaseBL

    Public Function Insert(ByVal documentoventadetalleBE As documentoventadetalle) As Integer
        Using ts As New TransactionScope
            HeliosData.documentoventadetalle.Add(documentoventadetalleBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return documentoventadetalleBE.Secuencia
        End Using
    End Function

    Public Sub Update(ByVal documentoventadetalleBE As documentoventadetalle)
        Using ts As New TransactionScope
            Dim docVentadetalle As documentoventadetalle = HeliosData.documentoventadetalle.Where(Function(o) _
                                            o.idDocumento = documentoventadetalleBE.idDocumento _
                                            And o.secuencia = documentoventadetalleBE.secuencia).First()

            docVentadetalle.idAlmacenOrigen = documentoventadetalleBE.idAlmacenOrigen
            docVentadetalle.establecimientoOrigen = documentoventadetalleBE.establecimientoOrigen
            docVentadetalle.cuentaOrigen = documentoventadetalleBE.cuentaOrigen
            docVentadetalle.idItem = documentoventadetalleBE.idItem
            docVentadetalle.nombreItem = documentoventadetalleBE.nombreItem
            docVentadetalle.fechaVcto = documentoventadetalleBE.fechaVcto
            docVentadetalle.tipoExistencia = documentoventadetalleBE.tipoExistencia
            docVentadetalle.destino = documentoventadetalleBE.destino
            docVentadetalle.unidad1 = documentoventadetalleBE.unidad1
            docVentadetalle.monto1 = documentoventadetalleBE.monto1
            docVentadetalle.unidad2 = documentoventadetalleBE.unidad2
            docVentadetalle.monto2 = documentoventadetalleBE.monto2
            docVentadetalle.precioUnitario = documentoventadetalleBE.precioUnitario
            docVentadetalle.precioUnitarioUS = documentoventadetalleBE.precioUnitarioUS
            docVentadetalle.importeMN = documentoventadetalleBE.importeMN
            docVentadetalle.importeME = documentoventadetalleBE.importeME
            docVentadetalle.importeMNK = documentoventadetalleBE.importeMNK
            docVentadetalle.importeMEK = documentoventadetalleBE.importeMEK
            docVentadetalle.descuentoMN = documentoventadetalleBE.descuentoMN
            docVentadetalle.descuentoME = documentoventadetalleBE.descuentoME
            docVentadetalle.montokardex = documentoventadetalleBE.montokardex
            docVentadetalle.montoIsc = documentoventadetalleBE.montoIsc
            docVentadetalle.montoIgv = documentoventadetalleBE.montoIgv
            docVentadetalle.otrosTributos = documentoventadetalleBE.otrosTributos
            docVentadetalle.montokardexUS = documentoventadetalleBE.montokardexUS
            docVentadetalle.montoIscUS = documentoventadetalleBE.montoIscUS
            docVentadetalle.montoIgvUS = documentoventadetalleBE.montoIgvUS
            docVentadetalle.otrosTributosUS = documentoventadetalleBE.otrosTributosUS
            docVentadetalle.salidaCostoMN = documentoventadetalleBE.salidaCostoMN
            docVentadetalle.salidaCostoME = documentoventadetalleBE.salidaCostoME
            docVentadetalle.preEvento = documentoventadetalleBE.preEvento
            docVentadetalle.estadoMovimiento = documentoventadetalleBE.estadoMovimiento
            docVentadetalle.tipoVenta = documentoventadetalleBE.tipoVenta
            docVentadetalle.usuarioModificacion = documentoventadetalleBE.usuarioModificacion
            docVentadetalle.fechaModificacion = documentoventadetalleBE.fechaModificacion
             

            'HeliosData.ObjectStateManager.GetObjectStateEntry(docVentadetalle).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal documentoventadetalleBE As documentoventadetalle)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(documentoventadetalleBE)
    End Sub

    Public Function GetListar_documentoventadetalle() As List(Of documentoventadetalle)
        Return (From a In HeliosData.documentoventadetalle Select a).ToList
    End Function

    Public Function GetUbicar_documentoventadetallePorID(Secuencia As Integer) As documentoventadetalle
        Return (From a In HeliosData.documentoventadetalle
                 Where a.secuencia = Secuencia Select a).First
    End Function
End Class

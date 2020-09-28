Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class otrasEntradasDetalleBL
    Inherits BaseBL

    Public Function Insert(ByVal otrasEntradasDetalleBE As otrasEntradasDetalle) As Integer
        Using ts As New TransactionScope
            HeliosData.otrasEntradasDetalle.Add(otrasEntradasDetalleBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return otrasEntradasDetalleBE.Secuencia
        End Using
    End Function

    Public Sub Update(ByVal otrasEntradasDetalleBE As otrasEntradasDetalle)
        Using ts As New TransactionScope
            Dim otrasEntDetalle As otrasEntradasDetalle = HeliosData.otrasEntradasDetalle.Where(Function(o) _
                                            o.idDocumento = otrasEntradasDetalleBE.idDocumento _
                                            And o.secuencia = otrasEntradasDetalleBE.secuencia).First()

            otrasEntDetalle.idItem = otrasEntradasDetalleBE.idItem
            otrasEntDetalle.tipoExistencia = otrasEntradasDetalleBE.tipoExistencia
            otrasEntDetalle.destino = otrasEntradasDetalleBE.destino
            otrasEntDetalle.unidad1 = otrasEntradasDetalleBE.unidad1
            otrasEntDetalle.monto1 = otrasEntradasDetalleBE.monto1
            otrasEntDetalle.unidad2 = otrasEntradasDetalleBE.unidad2
            otrasEntDetalle.monto2 = otrasEntradasDetalleBE.monto2
            otrasEntDetalle.precioUnitario = otrasEntradasDetalleBE.precioUnitario
            otrasEntDetalle.precioUnitarioUS = otrasEntradasDetalleBE.precioUnitarioUS
            otrasEntDetalle.importe = otrasEntradasDetalleBE.importe
            otrasEntDetalle.importeUS = otrasEntradasDetalleBE.importeUS
            otrasEntDetalle.montokardex = otrasEntradasDetalleBE.montokardex
            otrasEntDetalle.montoIsc = otrasEntradasDetalleBE.montoIsc
            otrasEntDetalle.montoIgv = otrasEntradasDetalleBE.montoIgv
            otrasEntDetalle.otrosTributos = otrasEntradasDetalleBE.otrosTributos
            otrasEntDetalle.montokardexUS = otrasEntradasDetalleBE.montokardexUS
            otrasEntDetalle.montoIscUS = otrasEntradasDetalleBE.montoIscUS
            otrasEntDetalle.montoIgvUS = otrasEntradasDetalleBE.montoIgvUS
            otrasEntDetalle.otrosTributosUS = otrasEntradasDetalleBE.otrosTributosUS
            otrasEntDetalle.idpreEvento = otrasEntradasDetalleBE.idpreEvento
            otrasEntDetalle.idEstablecimientoDestino = otrasEntradasDetalleBE.idEstablecimientoDestino
            otrasEntDetalle.idAlmacen = otrasEntradasDetalleBE.idAlmacen
            otrasEntDetalle.usuarioModificacion = otrasEntradasDetalleBE.usuarioModificacion
            otrasEntDetalle.fechaModificacion = otrasEntradasDetalleBE.fechaModificacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(otrasEntDetalle).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Public Sub Delete(ByVal otrasEntradasDetalleBE As otrasEntradasDetalle)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(otrasEntradasDetalleBE)
    End Sub

    Public Function GetListar_otrasEntradasDetalle() As List(Of otrasEntradasDetalle)
        Return (From a In HeliosData.otrasEntradasDetalle Select a).ToList
    End Function

    Public Function GetUbicar_otrasEntradasDetallePorID(Secuencia As Integer) As otrasEntradasDetalle
        Return (From a In HeliosData.otrasEntradasDetalle
                 Where a.secuencia = Secuencia Select a).First
    End Function
End Class

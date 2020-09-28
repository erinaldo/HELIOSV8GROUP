Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class otrasSalidasDetalleBL
    Inherits BaseBL

    Public Function Insert(ByVal otrasSalidasDetalleBE As otrasSalidasDetalle) As Integer
        Using ts As New TransactionScope
            HeliosData.otrasSalidasDetalle.Add(otrasSalidasDetalleBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return otrasSalidasDetalleBE.secuencia
        End Using
    End Function

    Public Sub Update(ByVal otrasSalidasDetalleBE As otrasSalidasDetalle)
        Using ts As New TransactionScope
            Dim otrasSalDetalle As otrasSalidasDetalle = HeliosData.otrasSalidasDetalle.Where(Function(o) _
                                            o.idDocumento = otrasSalidasDetalleBE.idDocumento _
                                            And o.secuencia = otrasSalidasDetalleBE.secuencia).First()

            otrasSalDetalle.idAlmacen = otrasSalidasDetalleBE.idAlmacen
            otrasSalDetalle.establecimientoOrigen = otrasSalidasDetalleBE.establecimientoOrigen
            otrasSalDetalle.cuentaOrigen = otrasSalidasDetalleBE.cuentaOrigen
            otrasSalDetalle.idItem = otrasSalidasDetalleBE.idItem
            otrasSalDetalle.tipoExistencia = otrasSalidasDetalleBE.tipoExistencia
            otrasSalDetalle.idOrigen = otrasSalidasDetalleBE.idOrigen
            otrasSalDetalle.destino = otrasSalidasDetalleBE.destino
            otrasSalDetalle.unidad1 = otrasSalidasDetalleBE.unidad1
            otrasSalDetalle.monto1 = otrasSalidasDetalleBE.monto1
            otrasSalDetalle.unidad2 = otrasSalidasDetalleBE.unidad2
            otrasSalDetalle.monto2 = otrasSalidasDetalleBE.monto2
            otrasSalDetalle.precioUnitario = otrasSalidasDetalleBE.precioUnitario
            otrasSalDetalle.precioUnitarioUS = otrasSalidasDetalleBE.precioUnitarioUS
            otrasSalDetalle.importe = otrasSalidasDetalleBE.importe
            otrasSalDetalle.importeUS = otrasSalidasDetalleBE.importeUS
            otrasSalDetalle.bonificacion = otrasSalidasDetalleBE.bonificacion
            otrasSalDetalle.montokardex = otrasSalidasDetalleBE.montokardex
            otrasSalDetalle.montoIsc = otrasSalidasDetalleBE.montoIsc
            otrasSalDetalle.montoIgv = otrasSalidasDetalleBE.montoIgv
            otrasSalDetalle.otrosTributos = otrasSalidasDetalleBE.otrosTributos
            otrasSalDetalle.montokardexUS = otrasSalidasDetalleBE.montokardexUS
            otrasSalDetalle.montoIscUS = otrasSalidasDetalleBE.montoIscUS
            otrasSalDetalle.montoIgvUS = otrasSalidasDetalleBE.montoIgvUS
            otrasSalDetalle.otrosTributosUS = otrasSalidasDetalleBE.otrosTributosUS
            otrasSalDetalle.estadoMovimiento = otrasSalidasDetalleBE.estadoMovimiento
            otrasSalDetalle.tipoCosto = otrasSalidasDetalleBE.tipoCosto
            otrasSalDetalle.idTareaArea = otrasSalidasDetalleBE.idTareaArea
            otrasSalDetalle.elementoCosto = otrasSalidasDetalleBE.elementoCosto
            otrasSalDetalle.establecimientoRef = otrasSalidasDetalleBE.establecimientoRef
            otrasSalDetalle.idProceso = otrasSalidasDetalleBE.idProceso
            otrasSalDetalle.idActividad = otrasSalidasDetalleBE.idActividad
            otrasSalDetalle.almacentrs = otrasSalidasDetalleBE.almacentrs
            otrasSalDetalle.establetrs = otrasSalidasDetalleBE.establetrs
            otrasSalDetalle.usuarioModificacion = otrasSalidasDetalleBE.usuarioModificacion
            otrasSalDetalle.fechaModificacion = otrasSalidasDetalleBE.fechaModificacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(otrasSalDetalle).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Public Sub Delete(ByVal otrasSalidasDetalleBE As otrasSalidasDetalle)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(otrasSalidasDetalleBE)
    End Sub

    Public Function GetListar_otrasSalidasDetalle() As List(Of otrasSalidasDetalle)
        Return (From a In HeliosData.otrasSalidasDetalle Select a).ToList
    End Function

    Public Function GetUbicar_otrasSalidasDetallePorID(Secuencia As Integer) As otrasSalidasDetalle
        Return (From a In HeliosData.otrasSalidasDetalle
                 Where a.secuencia = Secuencia Select a).First
    End Function
End Class

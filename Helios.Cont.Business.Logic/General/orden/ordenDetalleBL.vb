Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class ordenDetalleBL
    Inherits BaseBL

    Public Function Insert(ByVal ordenDetalleBE As ordenDetalle) As Integer
        Using ts As New TransactionScope
            HeliosData.ordenDetalle.Add(ordenDetalleBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return ordenDetalleBE.idOrden
        End Using
    End Function

    Public Sub Update(ByVal ordenDetalleBE As ordenDetalle)
        Using ts As New TransactionScope
            Dim ordDetalle As ordenDetalle = HeliosData.ordenDetalle.Where(Function(o) _
                                            o.idOrden = ordenDetalleBE.idOrden _
                                            And o.secuencia = ordenDetalleBE.secuencia).First()

            ordDetalle.idItem = ordenDetalleBE.idItem
            ordDetalle.descripcionItem = ordenDetalleBE.descripcionItem
            ordDetalle.tipoExistencia = ordenDetalleBE.tipoExistencia
            ordDetalle.destino = ordenDetalleBE.destino
            ordDetalle.unidad1 = ordenDetalleBE.unidad1
            ordDetalle.monto1 = ordenDetalleBE.monto1
            ordDetalle.unidad2 = ordenDetalleBE.unidad2
            ordDetalle.monto2 = ordenDetalleBE.monto2
            ordDetalle.precioUnitario = ordenDetalleBE.precioUnitario
            ordDetalle.precioUnitarioUS = ordenDetalleBE.precioUnitarioUS
            ordDetalle.importe = ordenDetalleBE.importe
            ordDetalle.importeUS = ordenDetalleBE.importeUS
            ordDetalle.montokardex = ordenDetalleBE.montokardex
            ordDetalle.montoIsc = ordenDetalleBE.montoIsc
            ordDetalle.montoIgv = ordenDetalleBE.montoIgv
            ordDetalle.otrosTributos = ordenDetalleBE.otrosTributos
            ordDetalle.montokardexUS = ordenDetalleBE.montokardexUS
            ordDetalle.montoIscUS = ordenDetalleBE.montoIscUS
            ordDetalle.montoIgvUS = ordenDetalleBE.montoIgvUS
            ordDetalle.otrosTributosUS = ordenDetalleBE.otrosTributosUS
            ordDetalle.almacenRef = ordenDetalleBE.almacenRef
            ordDetalle.usuarioModificacion = ordenDetalleBE.usuarioModificacion
            ordDetalle.fechaModificacion = ordenDetalleBE.fechaModificacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(ordDetalle).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Public Sub Delete(ByVal ordenDetalleBE As ordenDetalle)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(ordenDetalleBE)
    End Sub

    Public Function GetListar_ordenDetalle() As List(Of ordenDetalle)
        Return (From a In HeliosData.ordenDetalle Select a).ToList
    End Function

    Public Function GetUbicar_ordenDetallePorID(idOrden As Integer) As ordenDetalle
        Return (From a In HeliosData.ordenDetalle
                 Where a.idOrden = idOrden Select a).First
    End Function
End Class

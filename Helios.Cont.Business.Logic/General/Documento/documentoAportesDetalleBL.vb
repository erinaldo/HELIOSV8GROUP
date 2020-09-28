Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class documentoAportesDetalleBL
    Inherits BaseBL

    Public Function Insert(ByVal documentoAportesDetalleBE As documentoAportesDetalle) As Integer
        Using ts As New TransactionScope
            HeliosData.documentoAportesDetalle.Add(documentoAportesDetalleBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return documentoAportesDetalleBE.secuencia
        End Using
    End Function

    Public Sub Update(ByVal documentoAportesDetalleBE As documentoAportesDetalle)
        Using ts As New TransactionScope
            Dim docAportesDetalle As documentoAportesDetalle = HeliosData.documentoAportesDetalle.Where(Function(o) _
                                            o.idDocumento = documentoAportesDetalleBE.idDocumento _
                                            And o.secuencia = documentoAportesDetalleBE.secuencia).First()

            docAportesDetalle.tipoAporte = documentoAportesDetalleBE.tipoAporte
            docAportesDetalle.motivoIngreso = documentoAportesDetalleBE.motivoIngreso
            docAportesDetalle.moneda = documentoAportesDetalleBE.moneda
            docAportesDetalle.tipoCambio = documentoAportesDetalleBE.tipoCambio
            docAportesDetalle.cuenta = documentoAportesDetalleBE.cuenta
            docAportesDetalle.idAdquisicion = documentoAportesDetalleBE.idAdquisicion
            docAportesDetalle.descripcionAdqui = documentoAportesDetalleBE.descripcionAdqui
            docAportesDetalle.tipoExistencia = documentoAportesDetalleBE.tipoExistencia
            docAportesDetalle.destino = documentoAportesDetalleBE.destino
            docAportesDetalle.unidadMedia = documentoAportesDetalleBE.unidadMedia
            docAportesDetalle.cantidad = documentoAportesDetalleBE.cantidad
            docAportesDetalle.precioUnitario = documentoAportesDetalleBE.precioUnitario
            docAportesDetalle.precioUnitarioUS = documentoAportesDetalleBE.precioUnitarioUS
            docAportesDetalle.importe = documentoAportesDetalleBE.importe
            docAportesDetalle.importeUS = documentoAportesDetalleBE.importeUS
            docAportesDetalle.montokardex = documentoAportesDetalleBE.montokardex
            docAportesDetalle.montoIsc = documentoAportesDetalleBE.montoIsc
            docAportesDetalle.montoIgv = documentoAportesDetalleBE.montoIgv
            docAportesDetalle.otrosTributos = documentoAportesDetalleBE.otrosTributos
            docAportesDetalle.montokardexUS = documentoAportesDetalleBE.montokardexUS
            docAportesDetalle.montoIscUS = documentoAportesDetalleBE.montoIscUS
            docAportesDetalle.montoIgvUS = documentoAportesDetalleBE.montoIgvUS
            docAportesDetalle.otrosTributosUS = documentoAportesDetalleBE.otrosTributosUS
            docAportesDetalle.establecimientoRef = documentoAportesDetalleBE.establecimientoRef
            docAportesDetalle.almacenRef = documentoAportesDetalleBE.almacenRef
            docAportesDetalle.preEvento = documentoAportesDetalleBE.preEvento
            docAportesDetalle.Saldado = documentoAportesDetalleBE.Saldado
            docAportesDetalle.usuarioModificacion = documentoAportesDetalleBE.usuarioModificacion
            docAportesDetalle.fechaModificacion = documentoAportesDetalleBE.fechaModificacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(docAportesDetalle).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal documentoAportesDetalleBE As documentoAportesDetalle)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(documentoAportesDetalleBE)
    End Sub

    Public Function GetListar_actividadSeguimiento() As List(Of documentoAportesDetalle)
        Return (From a In HeliosData.documentoAportesDetalle Select a).ToList
    End Function

    Public Function GetUbicar_actividadSeguimientoPorID(Secuencia As Integer) As documentoAportesDetalle
        Return (From a In HeliosData.documentoAportesDetalle
                 Where a.secuencia = Secuencia Select a).First
    End Function
End Class

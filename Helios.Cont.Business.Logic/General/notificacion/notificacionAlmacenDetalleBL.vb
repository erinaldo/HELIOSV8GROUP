Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class notificacionAlmacenDetalleBL
    Inherits BaseBL

    Public Sub Insert(ByVal objNuevo As totalesAlmacen, idMovimiento As Integer, idDocumentoNotificacion As Integer)
        Dim notificacionAlmacenDetalle As New notificacionAlmacenDetalle
        Dim totalesCuenta As New documentocompradetalle
        Dim docuemntoCompraBL As New documentocompraBL
        Using ts As New TransactionScope

            totalesCuenta = HeliosData.documentocompradetalle.Where(Function(o) o.idDocumento = idMovimiento And _
                                                         o.idItem = objNuevo.idItem).FirstOrDefault

            If Not IsNothing(totalesCuenta) Then

                notificacionAlmacenDetalle.idDocumento = idDocumentoNotificacion
                'notificacionAlmacenDetalle.secuencia = objNuevo.SecuenciaDetalle
                notificacionAlmacenDetalle.idItem = objNuevo.idItem
                notificacionAlmacenDetalle.descripcionItem = totalesCuenta.descripcionItem
                notificacionAlmacenDetalle.tipoExistencia = totalesCuenta.tipoExistencia
                notificacionAlmacenDetalle.destino = totalesCuenta.destino
                notificacionAlmacenDetalle.unidad1 = totalesCuenta.unidad1
                notificacionAlmacenDetalle.unidad2 = totalesCuenta.unidad2
                notificacionAlmacenDetalle.monto2 = totalesCuenta.monto2
                notificacionAlmacenDetalle.monto1 = CDec(objNuevo.cantidad)
                notificacionAlmacenDetalle.importe = (1 + CDec((docuemntoCompraBL.UbicarCompraPorIdDocumento(idMovimiento).tasaIgv) / 100).ToString("N2")) * CDec(objNuevo.importeSoles).ToString("N2")
                notificacionAlmacenDetalle.precioUnitario = CDec(notificacionAlmacenDetalle.importe).ToString("N2") / CDec(notificacionAlmacenDetalle.monto1).ToString("N2")
                notificacionAlmacenDetalle.precioUnitarioUS = CDec(notificacionAlmacenDetalle.precioUnitario).ToString("N2") / CDec(docuemntoCompraBL.UbicarCompraPorIdDocumento(idMovimiento).tcDolLoc).ToString("N2")
                notificacionAlmacenDetalle.montokardex = CDec(objNuevo.importeSoles).ToString("N2")
                notificacionAlmacenDetalle.montoIsc = CDec(objNuevo.montoIsc).ToString("N2")
                notificacionAlmacenDetalle.montoIgv = CDec(notificacionAlmacenDetalle.importe).ToString("N2") - CDec(objNuevo.importeSoles).ToString("N2")
                notificacionAlmacenDetalle.montokardexUS = CDec(objNuevo.importeDolares).ToString("N2")
                notificacionAlmacenDetalle.montoIscUS = CDec(objNuevo.montoIscUS).ToString("N2")
                notificacionAlmacenDetalle.montoIgvUS = CDec(notificacionAlmacenDetalle.montoIgv).ToString("N2") / CDec(docuemntoCompraBL.UbicarCompraPorIdDocumento(idMovimiento).tcDolLoc).ToString("N2")
                notificacionAlmacenDetalle.otrosTributos = 0.0
                notificacionAlmacenDetalle.otrosTributosUS = 0.0
                notificacionAlmacenDetalle.almacenRef = objNuevo.idAlmacen
                notificacionAlmacenDetalle.usuarioModificacion = objNuevo.usuarioActualizacion
                notificacionAlmacenDetalle.fechaModificacion = Date.Now
            Else
                Throw New Exception("El comprobante no se encuentra, verifique su existencia!")
            End If

            HeliosData.notificacionAlmacenDetalle.Add(notificacionAlmacenDetalle)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Insert2(ByVal objCompraDetalle As totalesAlmacen, idMovimiento As Integer, idDocumentoNotificacion As Integer)
        Dim notificacionAlmacenDetalle As New notificacionAlmacenDetalle
        Dim documento As New documentocompradetalle
        Dim docuemntoCompraBL As New documentocompraBL
        Dim notificacionAlmacenBL As New notificacionAlmacenBL
        Using ts As New TransactionScope

            documento = HeliosData.documentocompradetalle.Where(Function(o) o.idDocumento = idMovimiento And _
                                                         o.idItem = objCompraDetalle.idItem).FirstOrDefault

            If Not IsNothing(documento) Then

                notificacionAlmacenDetalle.idDocumento = idDocumentoNotificacion
                notificacionAlmacenDetalle.secuencia = documento.secuencia
                notificacionAlmacenDetalle.idItem = documento.idItem
                notificacionAlmacenDetalle.descripcionItem = documento.DetalleItem
                notificacionAlmacenDetalle.tipoExistencia = documento.tipoExistencia
                notificacionAlmacenDetalle.destino = documento.destino
                notificacionAlmacenDetalle.unidad1 = documento.unidad1
                notificacionAlmacenDetalle.unidad2 = documento.unidad2
                notificacionAlmacenDetalle.monto2 = documento.monto2
                notificacionAlmacenDetalle.monto1 = documento.monto1
                notificacionAlmacenDetalle.importe = CDec(documento.importe).ToString("N2")
                notificacionAlmacenDetalle.precioUnitario = CDec(documento.precioUnitario).ToString("N2")
                notificacionAlmacenDetalle.precioUnitarioUS = CDec(documento.precioUnitarioUS).ToString("N2")
                notificacionAlmacenDetalle.montokardex = CDec(documento.montokardex).ToString("N2")
                notificacionAlmacenDetalle.montoIsc = CDec(documento.montoIsc).ToString("N2")
                notificacionAlmacenDetalle.montoIgv = CDec(documento.montoIgv).ToString("N2")
                notificacionAlmacenDetalle.montokardexUS = CDec(documento.montokardexUS).ToString("N2")
                notificacionAlmacenDetalle.montoIscUS = CDec(documento.montoIscUS).ToString("N2")
                notificacionAlmacenDetalle.montoIgvUS = CDec(documento.montoIgvUS).ToString("N2")
                notificacionAlmacenDetalle.otrosTributos = CDec(documento.otrosTributos).ToString("N2")
                notificacionAlmacenDetalle.otrosTributosUS = CDec(documento.otrosTributosUS).ToString("N2")
                notificacionAlmacenDetalle.almacenRef = objCompraDetalle.idAlmacen
                notificacionAlmacenDetalle.usuarioModificacion = documento.usuarioModificacion
                notificacionAlmacenDetalle.fechaModificacion = Date.Now
            Else
                Throw New Exception("El comprobante no se encuentra, verifique su existencia!")
            End If
            HeliosData.notificacionAlmacenDetalle.Add(notificacionAlmacenDetalle)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

End Class

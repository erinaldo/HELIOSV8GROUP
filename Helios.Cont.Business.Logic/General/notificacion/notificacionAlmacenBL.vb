Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class notificacionAlmacenBL
    Inherits BaseBL

    Public Sub DeleteNotificacion(ByVal intIdDocumento As Integer)
        Using ts As New TransactionScope
            Dim consulta = (From c In HeliosData.notificacionAlmacen _
                                   Where c.idDocumento = intIdDocumento _
                                   Select c).FirstOrDefault
            If Not IsNothing(consulta) Then
                consulta.estado = TIPO_SITUACION.NOTIFICACION_DOCUMENTO_CAJA_COMPLETA
                'HeliosData.ObjectStateManager.GetObjectStateEntry(consulta).State.ToString()

                HeliosData.SaveChanges()
                ts.Complete()
            Else
                Throw New Exception("El comprobante no se encuentra, verifique su existencia!")
            End If
        End Using
    End Sub

    Public Function GetUbicarNotificacionConteo(strIdEmpresa As String, intIdEstablecimiento As Integer, strSituacioN As String) As Integer
        Dim Listatotal As New List(Of notificacionAlmacen)
        Dim obj = (From a In HeliosData.notificacionAlmacen
                      Where a.idEmpresa = strIdEmpresa And _
                      a.idCentroCosto = intIdEstablecimiento And _
                      a.estado = strSituacioN).Count

        Return obj
    End Function

    Public Function GetUbicarNotificacionCaja(strIdEmpresa As String, intIdEstablecimiento As Integer, strIdAlmacen As String) As List(Of notificacionAlmacen)
        Dim ntotal As New notificacionAlmacen

        Dim Listatotal As New List(Of notificacionAlmacen)
        Dim obj = (From a In HeliosData.notificacionAlmacen
                      Where a.estado = strIdAlmacen And _
                      a.idEmpresa = strIdEmpresa And _
                      a.idCentroCosto = intIdEstablecimiento).ToList

        For Each items In obj
            ntotal = New notificacionAlmacen
            ntotal.idDocumento = items.idDocumento
            ntotal.idEmpresa = items.idEmpresa
            ntotal.idCentroCosto = items.idCentroCosto
            ntotal.glosa = items.glosa
            ntotal.fechaDoc = items.fechaDoc
            ntotal.entidadFinanciera = items.entidadFinanciera
            ntotal.entidadFinancieraDestino = items.entidadFinancieraDestino
            ntotal.nombreProveedor = Nothing
            ntotal.estado = items.estado
            ntotal.importeTotal = items.importeTotal
            ntotal.importeUS = items.importeUS
            ntotal.tipoDoc = items.tipoDoc
            ntotal.idPadre = items.idPadre
            Listatotal.Add(ntotal)
        Next
        Return Listatotal
    End Function

    Public Function GetUbicarNotificacion(strIdEmpresa As String, intIdEstablecimiento As Integer, strIdAlmacen As String) As List(Of notificacionAlmacen)
        Dim ntotal As New notificacionAlmacen

        Dim Listatotal As New List(Of notificacionAlmacen)
        Dim obj = (From a In HeliosData.notificacionAlmacen
                   Join b In HeliosData.entidad
                   On a.idProveedor Equals b.idEntidad _
                    Where a.idEmpresa = strIdEmpresa And
               a.idCentroCosto = intIdEstablecimiento And
               a.estado = strIdAlmacen).ToList

        For Each items In obj
            ntotal = New notificacionAlmacen
            ntotal.idDocumento = items.a.idDocumento
            ntotal.idEmpresa = items.a.idEmpresa
            ntotal.idCentroCosto = items.a.idCentroCosto
            ntotal.serie = items.a.serie
            ntotal.numeroDoc = items.a.numeroDoc
            ntotal.glosa = items.a.glosa
            ntotal.nombreProveedor = items.b.nombreCompleto
            ntotal.idProveedor = items.a.idProveedor
            ntotal.estado = items.a.estado
            ntotal.tipoDoc = items.a.tipoDoc
            ntotal.idPadre = items.a.idPadre
            Listatotal.Add(ntotal)
        Next
        Return Listatotal
    End Function

    Public Sub notificaionesSingle(ByVal documentoBE As documento, ByVal IdDocumento As Integer)
        Dim documentoBL As New documentoBL
        Dim notificacionAlmacenDetalleBL As New notificacionAlmacenDetalleBL
        Dim idDocumentoNotificacion As Integer
        idDocumentoNotificacion = documentoBL.InsertNotificacion(documentoBE)
        Me.Insert(IdDocumento, idDocumentoNotificacion)
    End Sub

    Public Sub notificaionesCaja(ByVal documentoBE As documento)
        Dim documentoBL As New documentoBL
        Dim notificacionAlmacenDetalleBL As New notificacionAlmacenDetalleBL
        Dim idDocumentoNotificacion As Integer
        idDocumentoNotificacion = documentoBL.InsertNotificacion(documentoBE)
        Me.InsertNotificacionCaja(documentoBE.idDocumento, idDocumentoNotificacion)
    End Sub

    Public Sub Insert(ByVal idDocumento As Integer, ByVal idDocumentoNotificacion As Integer)
        Dim notificacionAlmacen As New notificacionAlmacen
        Using ts As New TransactionScope

            Dim documentoCompra As documentocompra = HeliosData.documentocompra.Where(Function(o) _
                                          o.idDocumento = idDocumento).FirstOrDefault()

            notificacionAlmacen.idDocumento = idDocumentoNotificacion
            notificacionAlmacen.codigoLibro = documentoCompra.codigoLibro
            notificacionAlmacen.idEmpresa = documentoCompra.idEmpresa
            notificacionAlmacen.idCentroCosto = documentoCompra.idCentroCosto
            notificacionAlmacen.fechaDoc = Date.Now.Date
            notificacionAlmacen.fechaContable = PeriodoGeneral
            notificacionAlmacen.tipoDoc = 9901
            notificacionAlmacen.serie = documentoCompra.serie
            notificacionAlmacen.numeroDoc = documentoCompra.numeroDoc
            notificacionAlmacen.idProveedor = documentoCompra.idProveedor
            notificacionAlmacen.monedaDoc = documentoCompra.monedaDoc
            notificacionAlmacen.tipoCambio = documentoCompra.tcDolLoc
            notificacionAlmacen.importeTotal = documentoCompra.importeTotal
            notificacionAlmacen.importeUS = documentoCompra.importeUS
            notificacionAlmacen.estado = TIPO_SITUACION.NOTIFICACION_SOBRANTE
            notificacionAlmacen.glosa = String.Concat("Compra N°" + documentoCompra.numeroDoc + "  -  Eliminado en la Fecha: " + Date.Now.Date)
            notificacionAlmacen.idPadre = idDocumento
            notificacionAlmacen.usuarioActualizacion = documentoCompra.usuarioActualizacion
            notificacionAlmacen.fechaActualizacion = Date.Now
            HeliosData.notificacionAlmacen.Add(notificacionAlmacen)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub UpdateSingle(ByVal intIdDocumento As Integer)
        Using ts As New TransactionScope
            Dim consulta = (From c In HeliosData.notificacionAlmacen _
                                   Where c.idDocumento = intIdDocumento _
                                   Select c).FirstOrDefault
            If Not IsNothing(consulta) Then
                consulta.estado = TIPO_SITUACION.NOTIFICACION_COMPLETA
                'HeliosData.ObjectStateManager.GetObjectStateEntry(consulta).State.ToString()
                HeliosData.SaveChanges()
                ts.Complete()
            Else
                Throw New Exception("El comprobante no se encuentra, verifique su existencia!")
            End If
        End Using
    End Sub

    Public Sub InsertNotificacionCaja(ByVal idDocumento As Integer, ByVal idDocumentoNotificacion As Integer)
        Dim notificacionAlmacen As New notificacionAlmacen
        Using ts As New TransactionScope

            Dim documentoCaja As documentoCaja = HeliosData.documentoCaja.Where(Function(o) _
                                          o.idDocumento = idDocumento).FirstOrDefault()

            notificacionAlmacen.idDocumento = idDocumentoNotificacion
            notificacionAlmacen.codigoLibro = documentoCaja.codigoLibro
            notificacionAlmacen.idEmpresa = documentoCaja.idEmpresa
            notificacionAlmacen.idCentroCosto = documentoCaja.idEstablecimiento
            notificacionAlmacen.tipoMovimiento = documentoCaja.tipoMovimiento

            notificacionAlmacen.entidadFinanciera = documentoCaja.entidadFinanciera
            notificacionAlmacen.entidadFinancieraDestino = documentoCaja.entidadFinancieraDestino
            notificacionAlmacen.moneda = documentoCaja.moneda
            notificacionAlmacen.fechaDoc = Date.Now.Date
            notificacionAlmacen.fechaContable = PeriodoGeneral
            notificacionAlmacen.tipoDoc = 9901
            notificacionAlmacen.serie = documentoCaja.SerieCompra
            notificacionAlmacen.numeroDoc = documentoCaja.numeroDoc
            notificacionAlmacen.idProveedor = documentoCaja.IdProveedor
            notificacionAlmacen.monedaDoc = documentoCaja.monedaCompra
            notificacionAlmacen.tipoCambio = documentoCaja.tipoCambio
            notificacionAlmacen.importeTotal = documentoCaja.montoSoles
            notificacionAlmacen.importeUS = documentoCaja.montoUsd
            notificacionAlmacen.estado = TIPO_SITUACION.NOTIFICACION_DOCUMENTO_CAJA
            notificacionAlmacen.glosa = String.Concat("Eliminado la transferencia de cajas con fecha: " + Date.Now.Date)
            notificacionAlmacen.idPadre = idDocumento
            notificacionAlmacen.usuarioActualizacion = documentoCaja.usuarioModificacion
            notificacionAlmacen.fechaActualizacion = Date.Now
            HeliosData.notificacionAlmacen.Add(notificacionAlmacen)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

End Class

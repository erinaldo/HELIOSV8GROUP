Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class saldoInicioDetalleBL
    Inherits BaseBL


    Public Sub Insert(saldoBE As documento, intIdDocumento As Integer)
        Dim objInventario As New InventarioMovimiento
        Dim productoBL As New detalleitemsBL
        Dim producto As New detalleitems
        Dim documento As New documento
        Dim documentoBL As New documentoBL
        Dim precioV As New listadoPreciosBL
        Using ts As New TransactionScope()
            For Each i In saldoBE.saldoInicio.saldoInicioDetalle
                InsertDetalle(i, intIdDocumento)
                Select Case i.modulo
                    Case "MR"
                        If i.FlagModificaPrecioVenta = "S" Then
                            precioV.GrabarPrecioEntradaAportes(i)
                        End If
                        producto = productoBL.GetUbicaProductoID(i.idModulo)
                        objInventario = New InventarioMovimiento
                        objInventario.idEmpresa = saldoBE.idEmpresa
                        objInventario.idEstablecimiento = saldoBE.idCentroCosto
                        objInventario.idAlmacen = i.almacen
                        objInventario.tipoOperacion = "17"
                        objInventario.tipoDocAlmacen = i.TipoDoc
                        objInventario.serie = saldoBE.saldoInicio.serie
                        objInventario.numero = saldoBE.saldoInicio.numeroDoc
                        objInventario.idDocumento = intIdDocumento
                        objInventario.idDocumentoRef = intIdDocumento
                        objInventario.descripcion = i.descripcionItem

                        objInventario.fecha = saldoBE.fechaProceso
                        objInventario.tipoRegistro = "E"
                        objInventario.destinoGravadoItem = producto.origenProducto
                        objInventario.tipoProducto = producto.tipoExistencia
                        objInventario.cuentaOrigen = Nothing
                        objInventario.idItem = producto.codigodetalle
                        objInventario.presentacion = producto.presentacion
                        objInventario.fechavcto = Nothing
                        objInventario.cantidad = i.cantidad
                        objInventario.unidad = producto.unidad1
                        objInventario.cantidad2 = 0 'documentocompradetalle(x).Monto2
                        objInventario.unidad2 = Nothing  'documentocompradetalle(x).Unidad2

                        objInventario.precUnite = i.precioUnitario
                        objInventario.precUniteUSD = i.precioUnitarioUS

                        objInventario.monto = i.importe
                        objInventario.montoUSD = i.importeUS

                        objInventario.disponible = 0
                        objInventario.disponible2 = 0
                        objInventario.saldoMonto = 0 'documentocompradetalle(x).Importe
                        objInventario.saldoMontoUsd = 0 'documentocompradetalle(x).ImporteUS
                        objInventario.status = "A"
                        objInventario.entragado = "SI"
                        objInventario.preEvento = Nothing
                        objInventario.usuarioActualizacion = "Jiuni"
                        objInventario.fechaActualizacion = DateTime.Now
                        HeliosData.InventarioMovimiento.Add(objInventario)
                    Case "CA"
                        With documento
                            .idEmpresa = saldoBE.idEmpresa
                            .idCentroCosto = saldoBE.idCentroCosto
                            .tipoDoc = "9901"
                            .fechaProceso = saldoBE.fechaProceso
                            .nroDoc = Nothing
                            .idOrden = Nothing
                            .tipoOperacion = saldoBE.tipoOperacion
                            .usuarioActualizacion = saldoBE.usuarioActualizacion
                            .fechaActualizacion = saldoBE.fechaActualizacion
                        End With
                        documentoBL.Insert(documento)
                        InsertDocumentoCaja(i, saldoBE.saldoInicio, documento.idDocumento)
                        InsertDocumentoCajadetalle(i, saldoBE.saldoInicio, intIdDocumento, documento.idDocumento)

                    Case "TR"

                End Select
                'HeliosData.SaveChanges()
                'ts.Complete()
            Next

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Private Sub InsertDocumentoCaja(row As saldoInicioDetalle, docBase As saldoInicio, intIdDocumento As Integer)
        Dim documentoCaja As New documentoCaja
        Using ts As New TransactionScope
            With documentoCaja
                .idDocumento = intIdDocumento
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                .codigoLibro = "17"
                .tipoMovimiento = TIPO_VENTA.PAGO.COBRADO
                .codigoProveedor = Nothing
                .fechaProceso = docBase.fechaDoc
                .periodo = docBase.periodo
                .fechaCobro = docBase.fechaDoc
                .tipoDocPago = "9901"
                .numeroDoc = Nothing

                .moneda = docBase.monedaDoc
                .entidadFinanciera = row.idModulo
                .entidadFinancieraDestino = Nothing
                .numeroOperacion = Nothing
                .tipoCambio = 3.0
                Select Case row.tipoAsiento
                    Case "D"
                        .montoSoles = row.importe
                        .montoUsd = row.importeUS
                    Case Else
                        .montoSoles = row.importe
                        .montoUsd = row.importeUS
                End Select
              
                .glosa = docBase.glosa
                .entregado = "SI"
                .bancoEntidad = Nothing
                .ctaCorrienteDeposito = Nothing
                .usuarioModificacion = docBase.usuarioActualizacion
                .fechaModificacion = DateTime.Now
            End With
            HeliosData.documentoCaja.Add(documentoCaja)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Private Sub InsertDocumentoCajadetalle(row As saldoInicioDetalle, docBase As saldoInicio, intIdDocumento As Integer, intDocCaja As Integer)
        Dim documentoCajaDetalle As New documentoCajaDetalle
        Using ts As New TransactionScope
            documentoCajaDetalle = New documentoCajaDetalle
            documentoCajaDetalle.idDocumento = intDocCaja
            documentoCajaDetalle.documentoAfectado = intIdDocumento
            documentoCajaDetalle.fecha = docBase.fechaDoc
            documentoCajaDetalle.idItem = "00"
            documentoCajaDetalle.DetalleItem = row.NomAporte
            Select Case row.tipoAsiento
                Case "D"
                    documentoCajaDetalle.montoSoles = row.importe
                    documentoCajaDetalle.montoUsd = row.importeUS
                Case Else
                    documentoCajaDetalle.montoSoles = row.importe
                    documentoCajaDetalle.montoUsd = row.importeUS
            End Select
          
            documentoCajaDetalle.entregado = "SI"
            documentoCajaDetalle.diferTipoCambio = 0
          
            documentoCajaDetalle.usuarioModificacion = docBase.usuarioActualizacion
            documentoCajaDetalle.fechaModificacion = DateTime.Now
            HeliosData.documentoCajaDetalle.Add(documentoCajaDetalle)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub InsertDetalle(detalleBE As saldoInicioDetalle, intIdDocumento As Integer)
        Dim detalle As New saldoInicioDetalle
        Using ts As New TransactionScope()
            With detalle
                .idDocumento = intIdDocumento
                .modulo = detalleBE.modulo
                .idModulo = detalleBE.idModulo
                .idItem = detalleBE.idItem
                .descripcionItem = detalleBE.descripcionItem
                .tipoExistencia = detalleBE.tipoExistencia
                .cantidad = detalleBE.cantidad
                .precioUnitario = detalleBE.precioUnitario
                .precioUnitarioUS = detalleBE.precioUnitarioUS
                .tipoAsiento = detalleBE.tipoAsiento
                .importe = detalleBE.importe
                .importeUS = detalleBE.importeUS
                .bonificacion = detalleBE.bonificacion
                .almacen = detalleBE.almacen
                .caja = detalleBE.caja
                .usuarioModificacion = detalleBE.usuarioModificacion
                .fechaModificacion = detalleBE.fechaModificacion
            End With
            HeliosData.saldoInicioDetalle.Add(detalle)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function ListadoDetalleSaldoXidDocumento(intIdDocumento As Integer) As List(Of saldoInicioDetalle)
        Return (From n In HeliosData.saldoInicioDetalle Where n.idDocumento = intIdDocumento).ToList
    End Function

    Public Function ListadoMercaderiaXidDocumento(intIdDocumento As Integer) As List(Of saldoInicioDetalle)
        Return (From n In HeliosData.saldoInicioDetalle Where n.idDocumento = intIdDocumento And _
                n.modulo = "MR").ToList
    End Function

End Class

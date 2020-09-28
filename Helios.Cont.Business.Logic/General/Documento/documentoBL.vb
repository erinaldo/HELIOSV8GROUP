Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class documentoBL
    Inherits BaseBL

    Public Sub InsertDocCierre(ByVal documentoBE As documento)
        Dim documento As New documento
        Dim numeracionBL As New numeracionBoletasBL
        Dim cval As Integer = 0
        Dim idNumeracion As Integer = 0
        idNumeracion = documentoBE.nroDoc
        Using ts As New TransactionScope

            cval = Convert.ToInt32(numeracionBL.GenerarNumeroPorID(idNumeracion))

            documento.idEmpresa = documentoBE.idEmpresa
            documento.idCentroCosto = CInt(documentoBE.idCentroCosto)
            documento.idProyecto = documentoBE.idProyecto
            documento.tipoDoc = documentoBE.tipoDoc
            documento.fechaProceso = documentoBE.fechaProceso
            'documento.nroDoc = documentoBE.nroDoc
            documento.nroDoc = cval
            documento.idOrden = "1"
            documento.tipoOperacion = documentoBE.tipoOperacion
            documento.moneda = documentoBE.moneda
            documento.idEntidad = documentoBE.idEntidad
            documento.entidad = documentoBE.entidad
            documento.tipoEntidad = documentoBE.tipoEntidad
            documento.nrodocEntidad = documentoBE.nrodocEntidad
            documento.usuarioActualizacion = documentoBE.usuarioActualizacion
            documento.fechaActualizacion = documentoBE.fechaActualizacion
            HeliosData.documento.Add(documento)
            HeliosData.SaveChanges()
            ts.Complete()
            documentoBE.idDocumento = documento.idDocumento
        End Using
    End Sub

    Public Sub UpdatePendienteCronograma(ByVal iddoc As Integer, estadoA As String, idpago As Integer)
        Using ts As New TransactionScope
            Dim compra As Cronograma = HeliosData.Cronograma.Where(Function(o) o.idDocumentoRef = iddoc And o.idDocumentoPago = idpago).First
            compra.idDocumentoPago = 0
            compra.estado = estadoA
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub CompraPendienteUpdate(ByVal iddoc As Integer)

        Dim compra As documentocompra = HeliosData.documentocompra.Where(Function(o) o.idDocumento = iddoc).First
        compra.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
        HeliosData.SaveChanges()
    End Sub

    Public Sub VentaSaldadaDocs(ByVal iddoc As Integer)
        Dim documentoCajaDetalleBL As New documentoCajaDetalleBL
        Dim venta As documentoventaAbarrotes = HeliosData.documentoventaAbarrotes.Where(Function(o) o.idDocumento = iddoc).FirstOrDefault

        ' documentoCajaDetalleBL.ActualizarItemsPagosFull(iddoc)

        Dim ventaDetalle = (From n In HeliosData.documentoventaAbarrotesDet
                            Where n.idDocumento = venta.idDocumento AndAlso n.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO).Count

        If ventaDetalle > 0 Then
            venta.estadoCobro = TIPO_VENTA.PAGO.PENDIENTE_PAGO
        Else
            venta.estadoCobro = TIPO_VENTA.PAGO.COBRADO
        End If

        HeliosData.SaveChanges()
    End Sub

    Public Sub CompraSaldadaDocs(ByVal iddoc As Integer)

        Dim totalPagos = Aggregate i In HeliosData.documentoCajaDetalle _
                   Where i.documentoAfectado = iddoc _
                   Into mn = Sum(i.montoSoles), _
               mne = Sum(i.montoUsd)


        Dim compra As documentocompra = HeliosData.documentocompra.Where(Function(o) o.idDocumento = iddoc).First

        Dim moNtoCompraMN As Decimal = 0
        Dim salCompra As Decimal = 0

        Dim pagos As Decimal = totalPagos.mn.GetValueOrDefault
        moNtoCompraMN = compra.importeTotal

        salCompra = moNtoCompraMN - pagos

        If salCompra <= 0 Then
            ' pagado
            compra.estadoPago = TIPO_COMPRA.PAGO.PAGADO
        Else
            ' peNdieNte
            compra.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
        End If


        HeliosData.SaveChanges()
    End Sub

    Public Sub ElimiNarPagoAnticipoCompra(ByVal documentoBE As documento)
        Dim objItemsaldo As New documentoCajaDetalle
        Dim objItemsaldoA As New documentoAnticipoDetalle
        Dim cajaDetalleBL As New documentoCajaDetalleBL
        Dim saldoItem As Double = 0
        Dim saldoItemME As Double = 0
        Try
            Using ts As New TransactionScope

                'Select Case documentoBE.idOrden
                '    Case 9908 ' PAGO A CLIENTES
                '        DeleteSingle(documentoBE)
                '        VentaSaldada(documentoBE)
                '    Case 9907 ' PAGO A PROVEEDORES
                Dim cajdetalle = (From n In HeliosData.documentoAnticipoDetalle
                                  Where n.idDocumento = documentoBE.idDocumento).ToList

                For Each i In cajdetalle
                    Dim NCventa = Aggregate det In HeliosData.documentocompradetalle
                                Join v In HeliosData.documentocompra On v.idDocumento Equals det.idDocumento
                                Where v.tipoDoc = "07" And det.idPadreDTCompra = i.documentoAfectadodetalle
                                Into NCmn = Sum(det.importe),
                                     NCme = Sum(det.importeUS)

                    Dim NBventa = Aggregate det In HeliosData.documentocompradetalle
                                 Join v In HeliosData.documentocompra On v.idDocumento Equals det.idDocumento
                                 Where v.tipoDoc = "08" And det.idPadreDTCompra = i.documentoAfectadodetalle
                                 Into NBmn = Sum(det.importe),
                                      NBme = Sum(det.importeUS)

                    Dim Ajustes = Aggregate p In HeliosData.documentoLibroDiarioDetalle
                     Join compra In HeliosData.documentoLibroDiario
                     On p.idDocumento Equals compra.idDocumento
                                Where p.cuenta = i.documentoAfectadodetalle _
                                And compra.tipoRegistro = "AJU"
                Into AJmn = Sum(p.importeMN),
                     AJme = Sum(p.importeME)


                    objItemsaldo = cajaDetalleBL.ObtenerCuentasPorPagarPorProducto(i.documentoAfectado, i.documentoAfectadodetalle)
                    objItemsaldoA = cajaDetalleBL.ObtenerCuentasPorPagarAnticipoPorProducto(i.documentoAfectado, i.documentoAfectadodetalle)

                    Dim VentaDetalle As documentocompradetalle = HeliosData.documentocompradetalle.Where(Function(o) o.secuencia = i.documentoAfectadodetalle).FirstOrDefault

                    saldoItem = objItemsaldo.MontoDeudaSoles + i.importeMN - objItemsaldo.MontoPagadoSoles - NCventa.NCmn.GetValueOrDefault + NBventa.NBmn.GetValueOrDefault - Ajustes.AJmn.GetValueOrDefault - objItemsaldoA.MontoPagadoSoles
                    saldoItemME = objItemsaldo.MontoDeudaUSD + i.importeME - objItemsaldo.MontoPagadoUSD - NCventa.NCme.GetValueOrDefault + NBventa.NBme.GetValueOrDefault - Ajustes.AJme.GetValueOrDefault - objItemsaldoA.MontoPagadoUSD

                    If saldoItem <= 0 Then
                        VentaDetalle.estadoPago = TIPO_COMPRA.PAGO.PAGADO
                    Else
                        VentaDetalle.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                    End If
                Next

                DeleteSingle(documentoBE)
                CompraSaldada(documentoBE)


                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ElimiNarCobroAnticipoVenta(ByVal documentoBE As documento)
        Dim objItemsaldo As New documentoCajaDetalle
        Dim objItemsaldoA As New documentoAnticipoDetalle
        Dim cajaDetalleBL As New documentoCajaDetalleBL
        Dim saldoItem As Double = 0
        Dim saldoItemME As Double = 0
        Dim objitemsaldoant As New documentoAnticipoDetalle
        Try
            Using ts As New TransactionScope

                'Select Case documentoBE.idOrden
                '    Case 9908 ' PAGO A CLIENTES
                '        DeleteSingle(documentoBE)
                '        VentaSaldada(documentoBE)
                '    Case 9907 ' PAGO A PROVEEDORES
                Dim cajdetalle = (From n In HeliosData.documentoAnticipoDetalle
                             Where n.idDocumento = documentoBE.idDocumento).ToList

                For Each i In cajdetalle
                    'Dim NCventa = Aggregate det In HeliosData.documentocompradetalle _
                    '            Join v In HeliosData.documentocompra On v.idDocumento Equals det.idDocumento _
                    '            Where v.tipoDoc = "07" And det.idPadreDTCompra = i.documentoAfectadodetalle _
                    '            Into NCmn = Sum(det.importe), _
                    '                 NCme = Sum(det.importeUS)

                    'Dim NBventa = Aggregate det In HeliosData.documentocompradetalle _
                    '             Join v In HeliosData.documentocompra On v.idDocumento Equals det.idDocumento _
                    '             Where v.tipoDoc = "08" And det.idPadreDTCompra = i.documentoAfectadodetalle _
                    '             Into NBmn = Sum(det.importe), _
                    '                  NBme = Sum(det.importeUS)

                    Dim NCventa = Aggregate det In HeliosData.documentoventaAbarrotesDet _
                            Join v In HeliosData.documentoventaAbarrotes On v.idDocumento Equals det.idDocumento _
                            Where v.tipoDocumento = "07" And det.idPadreDTVenta = i.documentoAfectadodetalle _
                            Into NCmn = Sum(det.importeMN), _
                                 NCme = Sum(det.importeME)

                    Dim NBventa = Aggregate det In HeliosData.documentoventaAbarrotesDet _
                                 Join v In HeliosData.documentoventaAbarrotes On v.idDocumento Equals det.idDocumento _
                                 Where v.tipoDocumento = "08" And det.idPadreDTVenta = i.documentoAfectadodetalle _
                                 Into NBmn = Sum(det.importeMN), _
                                      NBme = Sum(det.importeME)

                    'Dim Ajustes = Aggregate p In HeliosData.documentoLibroDiarioDetalle _
                    ' Join compra In HeliosData.documentoLibroDiario _
                    ' On p.idDocumento Equals compra.idDocumento _
                    '            Where p.cuenta = i.documentoAfectadodetalle _
                    '            And compra.tipoRegistro = "AJU"
                    'Into(AJmn = Sum(p.importeMN), _
                    '     AJme = Sum(p.importeME))


                    'objItemsaldo = cajaDetalleBL.ObtenerCuentasPorPagarPorProducto(i.documentoAfectado, i.documentoAfectadodetalle)
                    'objItemsaldoA = cajaDetalleBL.ObtenerCuentasPorPagarAnticipoPorProducto(i.documentoAfectado, i.documentoAfectadodetalle)

                    'Dim VentaDetalle As documentocompradetalle = HeliosData.documentocompradetalle.Where(Function(o) o.secuencia = i.documentoAfectadodetalle).FirstOrDefault

                    objItemsaldo = cajaDetalleBL.ObtenerCuentasPorCobrarPorProducto(i.documentoAfectado, i.documentoAfectadodetalle)

                    objitemsaldoant = cajaDetalleBL.ObtenerCuentasPorCobrarAnticipoOtorPorProducto(i.documentoAfectado, i.documentoAfectadodetalle)
                    Dim VentaDetalle As documentoventaAbarrotesDet = HeliosData.documentoventaAbarrotesDet.Where(Function(o) o.secuencia = i.documentoAfectadodetalle).FirstOrDefault



                    saldoItem = objItemsaldo.MontoDeudaSoles + i.importeMN - objItemsaldo.MontoPagadoSoles - NCventa.NCmn.GetValueOrDefault + NBventa.NBmn.GetValueOrDefault - objitemsaldoant.MontoPagadoSoles
                    saldoItemME = objItemsaldo.MontoDeudaUSD + i.importeME - objItemsaldo.MontoPagadoUSD - NCventa.NCme.GetValueOrDefault + NBventa.NBme.GetValueOrDefault - objItemsaldoA.MontoPagadoUSD

                    If saldoItem <= 0 Then
                        VentaDetalle.estadoPago = TIPO_VENTA.PAGO.COBRADO
                    Else
                        VentaDetalle.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO
                    End If
                Next

                DeleteSingle(documentoBE)
                VentaSaldada2(documentoBE)


                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub VentaSaldada2(ByVal documentoBE As documento)

  
        Dim totalPagos = Aggregate i In HeliosData.documentoCajaDetalle _
                   Where i.documentoAfectado = documentoBE.IdDocumentoAfectado _
                   Into mn = Sum(i.montoSoles), _
               mne = Sum(i.montoUsd)

        'martin
        Dim totalPagosA = Aggregate i In HeliosData.documentoAnticipoDetalle
                   Where i.documentoAfectado = documentoBE.IdDocumentoAfectado _
                   Into mn = Sum(i.importeMN), _
               mne = Sum(i.importeME)


        Dim compra As documentoventaAbarrotes = HeliosData.documentoventaAbarrotes.Where(Function(o) o.idDocumento = documentoBE.IdDocumentoAfectado).First

        Dim moNtoCompraMN As Decimal = 0
        Dim salCompra As Decimal = 0

        Dim pagos As Decimal = totalPagos.mn.GetValueOrDefault
        Dim pagosA As Decimal = totalPagosA.mn.GetValueOrDefault
        moNtoCompraMN = compra.ImporteNacional

        salCompra = moNtoCompraMN - pagos - pagosA

        If salCompra <= 0 Then
            ' pagado
            compra.estadoCobro = TIPO_VENTA.PAGO.COBRADO
        Else
            ' peNdieNte
            compra.estadoCobro = TIPO_VENTA.PAGO.PENDIENTE_PAGO
        End If


        HeliosData.SaveChanges()
    End Sub

    Public Function UbicarConteoVentaCompra(strEmpresa As String, intIdEstablecimiento As Integer, strPeriodo As String) As documento
        Dim doccompra As New documento
        Dim list As New List(Of String)
        Dim listaTipoSituacion As New List(Of String)
        listaTipoSituacion.Add(TIPO_SITUACION.ALMACEN_TRANSITO)
        listaTipoSituacion.Add(TIPO_SITUACION.ALMACEN_FISICO)
        listaTipoSituacion.Add(TIPO_SITUACION.ALMACEN_TRANSITO_FISICO)
        list.Add(TIPO_COMPRA.COMPRA)
        doccompra = New documento

        Dim consulta2 = (From n In HeliosData.documentocompra _
                       Group Join cajadet In HeliosData.documentoCajaDetalle _
                       On n.idDocumento Equals cajadet.documentoAfectado _
                       Into ords = Group _
                       From c In ords.DefaultIfEmpty _
                       Where n.idEmpresa = strEmpresa And n.idCentroCosto = intIdEstablecimiento _
                       And n.fechaContable = strPeriodo And list.Contains(n.tipoCompra) _
                       Group c By n.idDocumento, n.tipoCompra, n.fechaContable, n.fechaDoc,
                       n.serie, n.numeroDoc, n.tipoDoc, n.monedaDoc, n.importeTotal, n.tcDolLoc,
                       n.importeUS, n.estadoPago Into g = Group _
                       Select New With {
                                      .idDocumento = idDocumento}).ToList

        For Each i In consulta2
            doccompra.idDocumento += 1
        Next

        Dim list2 As New List(Of String)
        list2.Add(TIPO_VENTA.VENTA_NORMAL_CREDITO)
        list2.Add(TIPO_VENTA.VENTA_GENERAL)

        Dim consulta = (From n In HeliosData.documentoventaAbarrotes _
                         Group Join cajadet In HeliosData.documentoCajaDetalle _
                         On n.idDocumento Equals cajadet.documentoAfectado _
                         Into ords = Group _
                         From c In ords.DefaultIfEmpty _
                         Where n.idEmpresa = strEmpresa And n.idEstablecimiento = intIdEstablecimiento _
                         And n.fechaPeriodo = strPeriodo And list2.Contains(n.tipoVenta) _
                         Group c By n.idDocumento, n.tipoVenta, n.fechaPeriodo, n.fechaDoc,
                         n.serie, n.numeroDocNormal, n.tipoDocumento, n.moneda, n.ImporteNacional, n.tipoCambio,
                         n.ImporteExtranjero, n.estadoCobro Into g = Group _
                         Select New With {.serie = serie}).ToList

        For Each i In consulta
            doccompra.nroDoc += 1
        Next

        Return doccompra
    End Function

    Public Sub DeleteVentaNormalServicio(ByVal documentoBE As documento)
        Dim documentoDetalleObligacionBL As New documentoObligacionTributariaDetalleBL
        Dim inventarioBL As New InventarioMovimientoBL
        Dim documentocompraBL As New documentocompraBL
        Dim documentocompradetalleBL As New documentocompradetalleBL
        Dim asientoBL As New AsientoBL
        'Dim totales As New totalesAlmacenBL
        Dim documentoCajaBl As New documentoCajaDetalleBL
        Try
            Dim veNta As documentoventaAbarrotes = HeliosData.documentoventaAbarrotes.Where(Function(o) o.idDocumento = documentoBE.idDocumento).First
            Select Case veNta.estadoCobro
                Case TIPO_VENTA.VENTA_ANULADA
                    Throw New Exception("Está venta ya fue anulada!")
                Case Else
                    documentoCajaBl.DeleteDocumentoCaja(documentoBE.idDocumento)
                    '----------------
                    'documentoDetalleObligacionBL.EliminarGrupoTributo(documentoBE.idDocumento)
                    'NOTAS DE CREDITO Y DEBIDO
                    EliminarDocNotasRef(documentoBE.idDocumento)
                    'documentoGuiaDetalleBL.EliminarDetalleItemsSL(documentoBE.idDocumento)
                    asientoBL.DeletePorDocumento(documentoBE.idDocumento)

                    veNta.estadoCobro = TIPO_VENTA.VENTA_ANULADA
                    HeliosData.SaveChanges()
            End Select
        Catch ex As Exception
            Throw ex
        End Try
      

      
        ' DeleteSingle2Free(documentoBE)
    End Sub

    Public Sub InsertDocAsiento(ByVal documentoBE As documento, nroCorre As String)
        Dim documento As New documento
        Dim numeracionBL As New numeracionBoletasBL

        ''Dim cval As Integer = 0
        Using ts As New TransactionScope

            'cval = Convert.ToInt32(numeracionBL.GenerarNumeroPorID(documentoBE.documentocompra.IdNumeracion))

            documento.idEmpresa = documentoBE.idEmpresa
            documento.idCentroCosto = CInt(documentoBE.idCentroCosto)
            documento.idProyecto = documentoBE.idProyecto
            documento.tipoDoc = documentoBE.tipoDoc
            documento.fechaProceso = documentoBE.fechaProceso
            documento.nroDoc = nroCorre
            documento.idOrden = "1"
            documento.moneda = documentoBE.moneda
            documento.idEntidad = documentoBE.idEntidad
            documento.entidad = documentoBE.entidad
            documento.tipoEntidad = documentoBE.tipoEntidad
            documento.nrodocEntidad = documentoBE.nrodocEntidad
            documento.tipoOperacion = documentoBE.tipoOperacion
            documento.usuarioActualizacion = documentoBE.usuarioActualizacion
            documento.fechaActualizacion = documentoBE.fechaActualizacion
            HeliosData.documento.Add(documento)
            HeliosData.SaveChanges()
            ts.Complete()
            documentoBE.idDocumento = documento.idDocumento
        End Using
    End Sub

    Public Sub Insert(ByVal documentoBE As documento)
        Dim documento As New documento
        Dim numeracionBL As New numeracionBoletasBL
        ''Dim cval As Integer = 0
        Using ts As New TransactionScope

            'cval = Convert.ToInt32(numeracionBL.GenerarNumeroPorID(documentoBE.documentocompra.IdNumeracion))

            documento.idEmpresa = documentoBE.idEmpresa
            documento.idCentroCosto = CInt(documentoBE.idCentroCosto)
            documento.idProyecto = documentoBE.idProyecto
            documento.tipoDoc = documentoBE.tipoDoc
            documento.fechaProceso = documentoBE.fechaProceso
            documento.nroDoc = documentoBE.nroDoc
            documento.idOrden = "1"
            documento.tipoOperacion = documentoBE.tipoOperacion
            documento.moneda = documentoBE.moneda
            documento.idEntidad = documentoBE.idEntidad
            documento.entidad = documentoBE.entidad
            documento.tipoEntidad = documentoBE.tipoEntidad
            documento.nrodocEntidad = documentoBE.nrodocEntidad
            documento.usuarioActualizacion = documentoBE.usuarioActualizacion
            documento.fechaActualizacion = documentoBE.fechaActualizacion
            HeliosData.documento.Add(documento)
            HeliosData.SaveChanges()
            ts.Complete()
            documentoBE.idDocumento = documento.idDocumento
        End Using
    End Sub

    Public Function InsertTranferencia(ByVal documentoBE As documento) As Integer
        Dim documento As New documento
        Using ts As New TransactionScope

            documento.idEmpresa = documentoBE.idEmpresa
            documento.idCentroCosto = CInt(documentoBE.idCentroCosto)
            documento.idProyecto = documentoBE.idProyecto
            documento.tipoDoc = documentoBE.tipoDoc
            documento.fechaProceso = documentoBE.fechaProceso
            documento.nroDoc = documentoBE.nroDoc
            documento.idOrden = "1"
            documento.tipoOperacion = documentoBE.tipoOperacion
            documento.moneda = documentoBE.moneda
            documento.idEntidad = documentoBE.idEntidad
            documento.entidad = documentoBE.entidad
            documento.tipoEntidad = documentoBE.tipoEntidad
            documento.nrodocEntidad = documentoBE.nrodocEntidad
            documento.usuarioActualizacion = documentoBE.usuarioActualizacion
            documento.fechaActualizacion = documentoBE.fechaActualizacion
            HeliosData.documento.Add(documento)
            HeliosData.SaveChanges()
            ts.Complete()
            Return documento.idDocumento
        End Using
    End Function

    Public Sub Update(ByVal documentoBE As documento)
        Using ts As New TransactionScope
            Dim documento As documento = HeliosData.documento.Where(Function(o) _
                                            o.idDocumento = documentoBE.idDocumento).First()

            documento.tipoDoc = documentoBE.tipoDoc
            documento.fechaProceso = documentoBE.fechaProceso
            documento.nroDoc = documentoBE.nroDoc
            documento.idOrden = documentoBE.idOrden
            documento.tipoOperacion = documentoBE.tipoOperacion
            documento.moneda = documentoBE.moneda
            documento.idEntidad = documentoBE.idEntidad
            documento.entidad = documentoBE.entidad
            documento.tipoEntidad = documentoBE.tipoEntidad
            documento.nrodocEntidad = documentoBE.nrodocEntidad
            documento.usuarioActualizacion = documentoBE.usuarioActualizacion
            documento.fechaActualizacion = documentoBE.fechaActualizacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(documento).State.ToString()
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub
    'DeleteTotalesAlmacen

    'metodos eliminar compras 
    Public Sub Delete(ByVal documentoBE As documento, objTotalBorrar As List(Of totalesAlmacen))
        Dim documentoDetalleObligacionBL As New documentoObligacionTributariaDetalleBL
        Dim totales As New totalesAlmacenBL
        Dim documentoCajaDetalleBL As New documentoCajaDetalleBL
        Dim inventarioBL As New InventarioMovimientoBL
        Dim documentoGuiaDetalleBL As New documentoguiaDetalleBL
        Dim totalesCajaUsuario As New CajaUsuarioBL
        Dim documentoCaja As New documentoCajaDetalleBL
        'METODOS
        inventarioBL.DeleteInventarioPorDocumento(documentoBE.idDocumento)
        totales.DeleteTotalesAlmacen(objTotalBorrar)
        documentoGuiaDetalleBL.EliminarDetalleItems(documentoBE.idDocumento)
        'Dim cajaDetalle As List(Of documentoCajaDetalle) = HeliosData.documentoCajaDetalle.Where(Function(o) o.documentoAfectado = documentoBE.idDocumento).ToList
        'For Each i In cajaDetalle
        '    totalesCajaUsuario.DeleteTotalesCajaUsuarioDocCajaDetalle(i.idDocumento, i.usuarioModificacion, documentoBE.idDocumento)
        '    DeleteSinglePagado(i.idDocumento)
        'Next
        'eliminar si se uso caja para realizar pago
        documentoCaja.DeleteDocumentoCaja(documentoBE.idDocumento)
        documentoDetalleObligacionBL.EliminarGrupoTributo(documentoBE.idDocumento)
        'NOTAS DE CREDITO Y DEBIDO
        EliminarDocNotasRef(documentoBE.idDocumento)
        DeleteSingle2(documentoBE)
    End Sub

    Public Sub DeleteSL(ByVal documentoBE As documento, objTotalBorrar As List(Of totalesAlmacen))
        Dim documentoDetalleObligacionBL As New documentoObligacionTributariaDetalleBL
        Dim documentoCajaDetalleBL As New documentoCajaDetalleBL
        Dim inventarioBL As New InventarioMovimientoBL
        Dim documentoGuiaDetalleBL As New documentoguiaDetalleBL
        Dim documentoCompra As New documentocompraBL
        Dim documentoCompraDetalle As New documentocompradetalleBL
        Dim notificacionAlmacenBL As New notificacionAlmacenBL
        Dim documentocompraBL As New documentocompraBL
        Dim documentocompradetalleBL As New documentocompradetalleBL
        Dim totales As New totalesAlmacenBL
        Dim asientoBL As New AsientoBL
        Dim documentoCajaBL As New documentoCajaDetalleBL
        Dim val As Integer
        Dim documentoBL As New documentoBL
        'METODOS
        'Se elimina el inventario y guia
        inventarioBL.DeleteInventarioPorDocumento(documentoBE.idDocumento)
        documentoGuiaDetalleBL.EliminarDetalleItems(documentoBE.idDocumento)
        'si existe la compra al credito se realizo elpago conuna caja
        'Dim cajaDetalle As List(Of documentoCajaDetalle) = HeliosData.documentoCajaDetalle.Where(Function(o) o.documentoAfectado = documentoBE.idDocumento).ToList
        'For Each i In cajaDetalle
        '    'totalesCajaUsuario.DeleteTotalesCajaUsuarioDocCajaDetalle(i.idDocumento, i.usuarioModificacion, documentoBE.idDocumento)
        '    DeleteSinglePagado(i.idDocumento)
        'Next
        'documentoCajaBL.DeleteDocumentoCaja(documentoBE.idDocumento)
        documentoBL.DeleteSinglePagado(documentoCajaDetalleBL.RecuperarIDCompra(documentoBE.idDocumento)) 'ELIMINANDO DOCUMENTO CAJA
        '------------
        documentoDetalleObligacionBL.EliminarGrupoTributo(documentoBE.idDocumento)
        'NOTAS DE CREDITO Y DEBIDO
        EliminarDocNotasRef(documentoBE.idDocumento)

        'actualiza la situacion del documento de la compra
        'totales.DeleteTotalesAlmacen(objTotalBorrar)

        documentocompradetalleBL.UpdateSingleDocCompraDetalle(documentoBE.idDocumento)
        val = documentocompraBL.UpdateSingleDocCompra(documentoBE.idDocumento)

        If val = 1 Then
            notificacionAlmacenBL.notificaionesSingle(documentoBE, documentoBE.idDocumento)
        End If
        'Crea un notificacion y elimina asiento y movimiento
        asientoBL.DeletePorDocumento(documentoBE.idDocumento)
        'Elimina las existencias en transito

    End Sub

    Public Sub DeleteDocumentoPagadoAlCredito(ByVal documentoBE As documento)
        Dim documentoDetalleObligacionBL As New documentoObligacionTributariaDetalleBL
        Dim inventarioBL As New InventarioMovimientoBL
        Dim documentocompraBL As New documentocompraBL
        Dim documentocompradetalleBL As New documentocompradetalleBL
        Dim notificacionAlmacenBL As New notificacionAlmacenBL
        Dim documentoGuiaDetalleBL As New documentoguiaDetalleBL
        Dim asientoBL As New AsientoBL
        Dim documentoCajaBl As New documentoCajaDetalleBL
        'METODOS
        'Se elimina el inventario y guia
        inventarioBL.DeleteInventarioPorDocumento(documentoBE.idDocumento)
        'si existe la compra al credito se realizo elpago conuna caja
        documentoCajaBl.DeleteDocumentoCaja(documentoBE.idDocumento)

        documentoDetalleObligacionBL.EliminarGrupoTributo(documentoBE.idDocumento)
        'NOTAS DE CREDITO Y DEBIDO
        EliminarDocNotasRef(documentoBE.idDocumento)
        'Crea un notificacion y elimina asiento y movimiento

        documentocompraBL.UpdateSingleDocCompra(documentoBE.idDocumento)
        documentocompradetalleBL.UpdateSingleDocCompraDetalle(documentoBE.idDocumento)
        documentoGuiaDetalleBL.EliminarDetalleItemsSL(documentoBE.idDocumento)
        asientoBL.DeletePorDocumento(documentoBE.idDocumento)
    End Sub

    Public Sub EliminarVentaGeneral(ByVal documentoBE As documento)
        Dim documentoDetalleObligacionBL As New documentoObligacionTributariaDetalleBL
        Dim inventarioBL As New InventarioMovimientoBL
        Dim documentocompraBL As New documentocompraBL
        Dim documentocompradetalleBL As New documentocompradetalleBL
        Dim notificacionAlmacenBL As New notificacionAlmacenBL
        Dim documentoGuiaDetalleBL As New documentoguiaDetalleBL
        Dim asientoBL As New AsientoBL
        Dim documentoCajaBl As New documentoCajaDetalleBL
        Dim t As New totalesAlmacen
        Dim totalesBL As New totalesAlmacenBL
        'METODOS
        Using ts As New TransactionScope
            inventarioBL.DeleteInventarioPorDocumento(documentoBE.idDocumento)
            'si existe la compra al credito se realizo elpago conuna caja
            documentoCajaBl.DeleteDocumentoCaja(documentoBE.idDocumento)
            documentoDetalleObligacionBL.EliminarGrupoTributo(documentoBE.idDocumento)
            'NOTAS DE CREDITO Y DEBIDO
            EliminarDocNotasRef(documentoBE.idDocumento)
            'Crea un notificacion y elimina asiento y movimiento
            documentoGuiaDetalleBL.EliminarDetalleItemsSL(documentoBE.idDocumento)
            asientoBL.DeletePorDocumento(documentoBE.idDocumento)
            Dim consultaDetalle = (From n In HeliosData.documentoventaAbarrotesDet _
                                   Where n.idDocumento = documentoBE.idDocumento).ToList


            For Each i In consultaDetalle
                'actualizando cabecera total almacen
                t = New totalesAlmacen
                t.idEmpresa = i.IdEmpresa
                t.idEstablecimiento = i.IdEstablecimiento
                t.idAlmacen = i.idAlmacenOrigen
                t.origenRecaudo = i.destino
                t.idItem = i.idItem
                t.cantidad = i.monto1
                t.precioUnitarioCompra = i.precioUnitario
                t.importeSoles = i.salidaCostoMN
                t.importeDolares = i.salidaCostoME
                totalesBL.UpdateSingle2(t)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub EliminarVentaGeneralPV(ByVal documentoBE As documento)
        Dim documentoDetalleObligacionBL As New documentoObligacionTributariaDetalleBL
        Dim inventarioBL As New InventarioMovimientoBL
        Dim documentocompraBL As New documentocompraBL
        Dim documentocompradetalleBL As New documentocompradetalleBL
        Dim documentoGuiaBL As New documentoGuiaBL
        Dim asientoBL As New AsientoBL
        Dim documentoCajaBl As New documentoCajaDetalleBL
        Dim t As New totalesAlmacen
        Dim totalesBL As New totalesAlmacenBL
        Dim empresaCierreMensualBL As New empresaCierreMensualBL
        Dim cierreinventarioBL As New cierreinventarioBL
        'METODOS
        Using ts As New TransactionScope

            Dim DocExiste As documentoventaAbarrotes = HeliosData.documentoventaAbarrotes.Where(Function(o) o.idDocumento = documentoBE.idDocumento).FirstOrDefault



            If Not IsNothing(DocExiste) Then

                Dim fechaActual = New Date(DocExiste.fechaDoc.Value.Year, DocExiste.fechaDoc.Value.Month, 1)
                Dim fechaAnterior = fechaActual.AddMonths(-1)

                'si es false es porque no esta dentro del inicio de operaciones
                Dim valor = empresaCierreMensualBL.GetValidaFechaInicioOperacion(DocExiste.idEmpresa, fechaActual, DocExiste.idEstablecimiento)
                If valor = "False" Then
                    If cierreinventarioBL.InventarioEstaCerradoV2(DocExiste.idEmpresa, fechaActual.Year, fechaActual.Month, DocExiste.idEstablecimiento) Then
                        Throw New Exception("El período: " & MonthName(fechaActual.Month) & ", esta cerrado!")
                    End If

                    If empresaCierreMensualBL.EstadoMesCerrado(New empresaCierreMensual With
                                                {.idEmpresa = DocExiste.idEmpresa,
                                                .idCentroCosto = DocExiste.idEstablecimiento,
                                                 .anio = fechaAnterior.Year,
                                                 .mes = fechaAnterior.Month}) = False Then
                        Throw New Exception("Debe cerrar el período anterior: " & MonthName(fechaAnterior.Month) & "-" & fechaAnterior.Year)
                    End If
                ElseIf valor = "True" Then
                    Throw New Exception("No puede ingresar en un período anterior al inicio de operaciones")
                Else
                    If cierreinventarioBL.InventarioEstaCerradoV2(DocExiste.idEmpresa, fechaActual.Year, fechaActual.Month, DocExiste.idEstablecimiento) Then
                        Throw New Exception("El período: " & MonthName(fechaActual.Month) & ", esta cerrado!")
                    End If

                    'If empresaCierreMensualBL.EstadoMesCerrado(New empresaCierreMensual With
                    '                                    {.idEmpresa = objDocumento.idEmpresa,
                    '                                     .anio = fechaAnterior.Year,
                    '                                     .mes = fechaAnterior.Month}) = False Then
                    '    Throw New Exception("Debe cerrar el período anterior: " & MonthName(fechaAnterior.Month) & "-" & fechaAnterior.Year)
                    'End If
                End If

                If DocExiste.estadoCobro = "ANU" Or DocExiste.estadoCobro = TIPO_VENTA.AnuladaPorNotaCredito Then

                    Throw New Exception("El comprobante solicitado está anulado!")
                Else

                    Dim consultaDetalle = (From n In HeliosData.documentoventaAbarrotesDet
                                           Where n.idDocumento = documentoBE.idDocumento).ToList

                    'eliminando inventario
                    inventarioBL.DeleteInventarioPorDocumento(documentoBE.idDocumento)

                    'si existe la compra al credito se realizo elpago conuna caja
                    documentoCajaBl.DeleteDocumentoCaja(documentoBE.idDocumento)

                    'documentoDetalleObligacionBL.EliminarGrupoTributo(documentoBE.idDocumento)

                    ' NOTAS DE CREDITO Y DEBIDO
                    EliminarDocNotasRefVentas(documentoBE.idDocumento)


                    'eliminando guía de remisión
                    documentoGuiaBL.EliminarGuiaGeneral(documentoBE.idDocumento)

                    'eliminando asiento contable
                    asientoBL.DeletePorDocumento(documentoBE.idDocumento)


                    For Each i In consultaDetalle
                        'actualizando cabecera total almacen
                        t = New totalesAlmacen
                        t.idEmpresa = DocExiste.idEmpresa
                        t.idEstablecimiento = DocExiste.idEstablecimiento
                        t.idAlmacen = i.idAlmacenOrigen
                        t.origenRecaudo = i.destino
                        t.idItem = i.idItem
                        t.cantidad = i.monto1
                        t.precioUnitarioCompra = i.precioUnitario
                        t.importeSoles = i.salidaCostoMN
                        t.importeDolares = i.salidaCostoME
                        totalesBL.UpdateCostoVentaKardex(t)


                        i.monto1 = 0
                        i.monto2 = 0
                        i.precioUnitario = 0
                        i.precioUnitarioUS = 0
                        i.importeMN = 0
                        i.importeME = 0
                        i.importeMNK = 0
                        i.importeMEK = 0
                        i.descuentoMN = 0
                        i.descuentoME = 0
                        i.montokardex = 0
                        i.montoIsc = 0
                        i.montoIgv = 0
                        i.otrosTributos = 0
                        i.montokardexUS = 0
                        i.montoIscUS = 0
                        i.montoIgvUS = 0
                        i.otrosTributosUS = 0
                        i.salidaCostoMN = 0
                        i.salidaCostoME = 0
                        i.cantidadCredito = 0
                        i.cantidadDebito = 0
                        i.notaCreditoMN = 0
                        i.notaCreditoME = 0
                        i.notaDebitoMN = 0
                        i.notaDebitoME = 0
                        i.entregado = Nothing
                        i.estadoPago = "ANU"
                        i.usuarioModificacion = DocExiste.usuarioActualizacion
                        i.fechaModificacion = DateTime.Now
                    Next
                    DocExiste.tipoCambio = 0
                    DocExiste.tasaIgv = 0
                    DocExiste.bi01 = 0
                    DocExiste.bi02 = 0
                    DocExiste.isc01 = 0
                    DocExiste.isc02 = 0
                    DocExiste.igv01 = 0
                    DocExiste.igv02 = 0
                    DocExiste.otc01 = 0
                    DocExiste.otc02 = 0
                    DocExiste.bi01us = 0
                    DocExiste.bi02us = 0
                    DocExiste.isc01us = 0
                    DocExiste.isc02us = 0
                    DocExiste.igv01us = 0
                    DocExiste.igv02us = 0
                    DocExiste.otc01us = 0
                    DocExiste.otc02us = 0
                    DocExiste.ImporteNacional = 0
                    DocExiste.ImporteExtranjero = 0
                    DocExiste.importeCostoMN = 0
                    DocExiste.importeCostoME = 0
                    DocExiste.estadoCobro = "ANU"
                    DocExiste.usuarioActualizacion = DocExiste.usuarioActualizacion
                    DocExiste.fechaActualizacion = DateTime.Now

                    'eliminando coprobante General
                    'DeleteSingle(documentoBE)
                End If
            Else
                Throw New Exception("El comprobante solicitado no existe!")
            End If
                HeliosData.SaveChanges()
                ts.Complete()
        End Using
    End Sub

    Public Sub EliminarPedidos(ByVal documentoBE As documento)
        Dim documentoDetalleObligacionBL As New documentoObligacionTributariaDetalleBL
        Dim inventarioBL As New InventarioMovimientoBL
        Dim documentocompraBL As New documentocompraBL
        Dim documentocompradetalleBL As New documentocompradetalleBL
        Dim documentoGuiaBL As New documentoGuiaBL
        Dim asientoBL As New AsientoBL
        Dim documentoCajaBl As New documentoCajaDetalleBL
        Dim t As New totalesAlmacen
        Dim totalesBL As New totalesAlmacenBL
        'METODOS
        Using ts As New TransactionScope

            Dim DocExiste As documentoventaAbarrotes = HeliosData.documentoventaAbarrotes.Where(Function(o) o.idDocumento = documentoBE.idDocumento).FirstOrDefault

            If Not IsNothing(DocExiste) Then

                If DocExiste.estadoCobro = "ANU" Or DocExiste.estadoCobro = TIPO_VENTA.AnuladaPorNotaCredito Then

                    Throw New Exception("El comprobante solicitado está anulado!")
                Else

                    Dim consultaDetalle = (From n In HeliosData.documentoventaAbarrotesDet _
                                          Where n.idDocumento = documentoBE.idDocumento).ToList

                    For Each i In consultaDetalle
                        'actualizando cabecera total almacen
                        't = New totalesAlmacen
                        't.idEmpresa = DocExiste.idEmpresa
                        't.idEstablecimiento = DocExiste.idEstablecimiento
                        't.origenRecaudo = i.destino
                        't.idItem = i.idItem
                        't.cantidad = i.monto1
                        't.precioUnitarioCompra = i.precioUnitario
                        't.importeSoles = i.salidaCostoMN
                        't.importeDolares = i.salidaCostoME
                        'totalesBL.UpdateCostoVentaKardex(t)


                        i.monto1 = 0
                        i.monto2 = 0
                        i.precioUnitario = 0
                        i.precioUnitarioUS = 0
                        i.importeMN = 0
                        i.importeME = 0
                        i.importeMNK = 0
                        i.importeMEK = 0
                        i.descuentoMN = 0
                        i.descuentoME = 0
                        i.montokardex = 0
                        i.montoIsc = 0
                        i.montoIgv = 0
                        i.otrosTributos = 0
                        i.montokardexUS = 0
                        i.montoIscUS = 0
                        i.montoIgvUS = 0
                        i.otrosTributosUS = 0
                        i.salidaCostoMN = 0
                        i.salidaCostoME = 0
                        i.cantidadCredito = 0
                        i.cantidadDebito = 0
                        i.notaCreditoMN = 0
                        i.notaCreditoME = 0
                        i.notaDebitoMN = 0
                        i.notaDebitoME = 0
                        i.entregado = Nothing
                        i.estadoPago = "ANU"
                        i.usuarioModificacion = DocExiste.usuarioActualizacion
                        i.fechaModificacion = DateTime.Now
                    Next
                    DocExiste.tipoCambio = 0
                    DocExiste.tasaIgv = 0
                    DocExiste.bi01 = 0
                    DocExiste.bi02 = 0
                    DocExiste.isc01 = 0
                    DocExiste.isc02 = 0
                    DocExiste.igv01 = 0
                    DocExiste.igv02 = 0
                    DocExiste.otc01 = 0
                    DocExiste.otc02 = 0
                    DocExiste.bi01us = 0
                    DocExiste.bi02us = 0
                    DocExiste.isc01us = 0
                    DocExiste.isc02us = 0
                    DocExiste.igv01us = 0
                    DocExiste.igv02us = 0
                    DocExiste.otc01us = 0
                    DocExiste.otc02us = 0
                    DocExiste.ImporteNacional = 0
                    DocExiste.ImporteExtranjero = 0
                    DocExiste.importeCostoMN = 0
                    DocExiste.importeCostoME = 0
                    DocExiste.estadoCobro = "ANU"
                    DocExiste.usuarioActualizacion = DocExiste.usuarioActualizacion
                    DocExiste.fechaActualizacion = DateTime.Now

                End If
            Else
                Throw New Exception("El comprobante solicitado no existe!")
            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Sub ElminarDetalleConsumo(DocExiste As documentoventaAbarrotes)
        Dim t As New totalesAlmacen
        Dim totalesBL As New totalesAlmacenBL
        Dim con = HeliosData.documentoconsumodirecto.Where(Function(o) o.idDocumento = DocExiste.idDocumento).ToList

        Using ts As New TransactionScope
            For Each i In con
                t = New totalesAlmacen
                t.idEmpresa = DocExiste.idEmpresa
                t.idEstablecimiento = DocExiste.idEstablecimiento
                t.idAlmacen = i.almacen
                t.origenRecaudo = "1"
                t.idItem = i.idMateriaPrima
                t.cantidad = i.cant
                t.precioUnitarioCompra = 0
                t.importeSoles = i.costo
                t.importeDolares = 0
                totalesBL.UpdateCostoVentaAnulacion(t)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using

    End Sub

    ''' <summary>
    ''' Eliminar venta directa con Ticket POS
    ''' </summary>
    ''' <param name="documentoBE"></param>
    ''' <remarks></remarks>
    Public Sub EliminarVentaTicketDirecta(ByVal documentoBE As documento)
        Dim documentoDetalleObligacionBL As New documentoObligacionTributariaDetalleBL
        Dim inventarioBL As New InventarioMovimientoBL
        Dim documentocompraBL As New documentocompraBL
        Dim documentocompradetalleBL As New documentocompradetalleBL
        Dim documentoGuiaBL As New documentoGuiaBL
        Dim asientoBL As New AsientoBL
        Dim documentoCajaBl As New documentoCajaDetalleBL
        Dim t As New totalesAlmacen
        Dim totalesBL As New totalesAlmacenBL
        'METODOS
        Using ts As New TransactionScope

            Dim DocExiste As documentoventaAbarrotes = HeliosData.documentoventaAbarrotes.Where(Function(o) o.idDocumento = documentoBE.idDocumento).FirstOrDefault

            If DocExiste.estadoCobro = "ANU" Or DocExiste.estadoCobro = TIPO_VENTA.AnuladaPorNotaCredito Then

                Throw New Exception("El comprobante solicitado está anulado!")
            Else
                Dim consultaDetalle = (From n In HeliosData.documentoventaAbarrotesDet _
                                     Where n.idDocumento = documentoBE.idDocumento).ToList

                For Each i In consultaDetalle
                    'actualizando cabecera total almacen
                    t = New totalesAlmacen
                    t.idEmpresa = DocExiste.idEmpresa
                    t.idEstablecimiento = DocExiste.idEstablecimiento
                    t.idAlmacen = i.idAlmacenOrigen
                    t.origenRecaudo = i.destino
                    t.idItem = i.idItem
                    t.cantidad = i.monto1
                    t.precioUnitarioCompra = i.precioUnitario
                    t.importeSoles = i.salidaCostoMN
                    t.importeDolares = i.salidaCostoME
                    totalesBL.UpdateCostoVentaAnulacion(t)


                    i.monto1 = 0
                    i.monto2 = 0
                    i.precioUnitario = 0
                    i.precioUnitarioUS = 0
                    i.importeMN = 0
                    i.importeME = 0
                    i.importeMNK = 0
                    i.importeMEK = 0
                    i.descuentoMN = 0
                    i.descuentoME = 0
                    i.montokardex = 0
                    i.montoIsc = 0
                    i.montoIgv = 0
                    i.otrosTributos = 0
                    i.montokardexUS = 0
                    i.montoIscUS = 0
                    i.montoIgvUS = 0
                    i.otrosTributosUS = 0
                    i.salidaCostoMN = 0
                    i.salidaCostoME = 0
                    i.cantidadCredito = 0
                    i.cantidadDebito = 0
                    i.notaCreditoMN = 0
                    i.notaCreditoME = 0
                    i.notaDebitoMN = 0
                    i.notaDebitoME = 0
                    i.entregado = Nothing
                    i.estadoPago = "ANU"
                    i.usuarioModificacion = DocExiste.usuarioActualizacion
                    i.fechaModificacion = DateTime.Now
                Next


               

                'eliminando inventario
                inventarioBL.DeleteInventarioPorDocumento(documentoBE.idDocumento)

                'si existe la compra al credito se realizo elpago conuna caja
                documentoCajaBl.DeleteDocumentoCaja(documentoBE.idDocumento)

                documentoDetalleObligacionBL.EliminarGrupoTributo(documentoBE.idDocumento)

                ' NOTAS DE CREDITO Y DEBIDO
                EliminarDocNotasRefVentas(documentoBE.idDocumento)


                'eliminando guía de remisión
                documentoGuiaBL.EliminarGuiaGeneral(documentoBE.idDocumento)

                'eliminando asiento contable
                asientoBL.DeletePorDocumento(documentoBE.idDocumento)



                DocExiste.tipoCambio = 0
                DocExiste.tasaIgv = 0
                DocExiste.bi01 = 0
                DocExiste.bi02 = 0
                DocExiste.isc01 = 0
                DocExiste.isc02 = 0
                DocExiste.igv01 = 0
                DocExiste.igv02 = 0
                DocExiste.otc01 = 0
                DocExiste.otc02 = 0
                DocExiste.bi01us = 0
                DocExiste.bi02us = 0
                DocExiste.isc01us = 0
                DocExiste.isc02us = 0
                DocExiste.igv01us = 0
                DocExiste.igv02us = 0
                DocExiste.otc01us = 0
                DocExiste.otc02us = 0
                DocExiste.ImporteNacional = 0
                DocExiste.ImporteExtranjero = 0
                DocExiste.importeCostoMN = 0
                DocExiste.importeCostoME = 0
                DocExiste.estadoCobro = "ANU"
                DocExiste.usuarioActualizacion = DocExiste.usuarioActualizacion
                DocExiste.fechaActualizacion = DateTime.Now

                'eliminando coprobante General
                'DeleteSingle(documentoBE)

            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub EliminarConsumoDirecto(ByVal documentoBE As documento)
        Dim documentoDetalleObligacionBL As New documentoObligacionTributariaDetalleBL
        Dim inventarioBL As New InventarioMovimientoBL
        Dim documentocompraBL As New documentocompraBL
        Dim documentocompradetalleBL As New documentocompradetalleBL
        Dim documentoGuiaBL As New documentoGuiaBL
        Dim asientoBL As New AsientoBL
        Dim documentoCajaBl As New documentoCajaDetalleBL
        Dim t As New totalesAlmacen
        Dim totalesBL As New totalesAlmacenBL
        'METODOS
        Using ts As New TransactionScope

            Dim DocExiste As documentoventaAbarrotes = HeliosData.documentoventaAbarrotes.Where(Function(o) o.idDocumento = documentoBE.idDocumento).FirstOrDefault

            If DocExiste.estadoCobro = "ANU" Or DocExiste.estadoCobro = TIPO_VENTA.AnuladaPorNotaCredito Then

                Throw New Exception("El comprobante solicitado está anulado!")
            Else

                ElminarDetalleConsumo(DocExiste)


                Dim consultaDetalle = (From n In HeliosData.documentoventaAbarrotesDet _
                                     Where n.idDocumento = documentoBE.idDocumento).ToList

                For Each i In consultaDetalle

                    If i.tipoExistencia = TipoExistencia.Mercaderia Then
                        'actualizando cabecera total almacen
                        t = New totalesAlmacen
                        t.idEmpresa = DocExiste.idEmpresa
                        t.idEstablecimiento = DocExiste.idEstablecimiento
                        t.idAlmacen = i.idAlmacenOrigen
                        t.origenRecaudo = i.destino
                        t.idItem = i.idItem
                        t.cantidad = i.monto1
                        t.precioUnitarioCompra = i.precioUnitario
                        t.importeSoles = i.salidaCostoMN
                        t.importeDolares = i.salidaCostoME
                        totalesBL.UpdateCostoVentaAnulacion(t)
                    End If
                 
                    i.monto1 = 0
                    i.monto2 = 0
                    i.precioUnitario = 0
                    i.precioUnitarioUS = 0
                    i.importeMN = 0
                    i.importeME = 0
                    i.importeMNK = 0
                    i.importeMEK = 0
                    i.descuentoMN = 0
                    i.descuentoME = 0
                    i.montokardex = 0
                    i.montoIsc = 0
                    i.montoIgv = 0
                    i.otrosTributos = 0
                    i.montokardexUS = 0
                    i.montoIscUS = 0
                    i.montoIgvUS = 0
                    i.otrosTributosUS = 0
                    i.salidaCostoMN = 0
                    i.salidaCostoME = 0
                    i.cantidadCredito = 0
                    i.cantidadDebito = 0
                    i.notaCreditoMN = 0
                    i.notaCreditoME = 0
                    i.notaDebitoMN = 0
                    i.notaDebitoME = 0
                    i.entregado = Nothing
                    i.estadoPago = "ANU"
                    i.usuarioModificacion = DocExiste.usuarioActualizacion
                    i.fechaModificacion = DateTime.Now
                Next

                'eliminando inventario
                inventarioBL.DeleteInventarioPorDocumento(documentoBE.idDocumento)

                'si existe la compra al credito se realizo elpago conuna caja
                documentoCajaBl.DeleteDocumentoCaja(documentoBE.idDocumento)

                documentoDetalleObligacionBL.EliminarGrupoTributo(documentoBE.idDocumento)

                ' NOTAS DE CREDITO Y DEBIDO
                EliminarDocNotasRefVentas(documentoBE.idDocumento)

                'eliminando guía de remisión
                documentoGuiaBL.EliminarGuiaGeneral(documentoBE.idDocumento)

                'eliminando asiento contable
                asientoBL.DeletePorDocumento(documentoBE.idDocumento)

                DocExiste.tipoCambio = 0
                DocExiste.tasaIgv = 0
                DocExiste.bi01 = 0
                DocExiste.bi02 = 0
                DocExiste.isc01 = 0
                DocExiste.isc02 = 0
                DocExiste.igv01 = 0
                DocExiste.igv02 = 0
                DocExiste.otc01 = 0
                DocExiste.otc02 = 0
                DocExiste.bi01us = 0
                DocExiste.bi02us = 0
                DocExiste.isc01us = 0
                DocExiste.isc02us = 0
                DocExiste.igv01us = 0
                DocExiste.igv02us = 0
                DocExiste.otc01us = 0
                DocExiste.otc02us = 0
                DocExiste.ImporteNacional = 0
                DocExiste.ImporteExtranjero = 0
                DocExiste.importeCostoMN = 0
                DocExiste.importeCostoME = 0
                DocExiste.estadoCobro = "ANU"
                DocExiste.usuarioActualizacion = DocExiste.usuarioActualizacion
                DocExiste.fechaActualizacion = DateTime.Now

                'eliminando coprobante General
                'DeleteSingle(documentoBE)

            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub EliminarCompraGeneral(ByVal documentoBE As documento)
        Dim documentoDetalleObligacionBL As New documentoObligacionTributariaDetalleBL
        Dim inventarioBL As New InventarioMovimientoBL
        Dim documentocompraBL As New documentocompraBL
        Dim documentocompradetalleBL As New documentocompradetalleBL
        Dim notificacionAlmacenBL As New notificacionAlmacenBL
        Dim documentoGuiaBL As New documentoGuiaBL
        Dim asientoBL As New AsientoBL
        Dim documentoCajaBl As New documentoCajaDetalleBL
        Dim t As New totalesAlmacen
        Dim totalesBL As New totalesAlmacenBL
        Dim recursoCostoBL As New recursoCostoDetalleBL
        Try
            Using ts As New TransactionScope
                'eliminando totales almacen
                Dim codDoc = documentoBE.idDocumento
                Dim consulta As List(Of documentocompradetalle) = HeliosData.documentocompradetalle.Where(Function(o) o.idDocumento = documentoBE.idDocumento).ToList
                For Each i In consulta ' documentoBE.documentocompra.documentocompradetalle
                    If i.tipoExistencia <> TipoRecurso.SERVICIO Then
                        t = New totalesAlmacen
                        t.idEmpresa = documentoBE.idEmpresa
                        t.idEstablecimiento = documentoBE.idCentroCosto
                        t.idAlmacen = i.almacenRef  ' almacen de DESTINO
                        t.origenRecaudo = i.destino
                        t.idItem = i.idItem
                        t.descripcion = i.descripcionItem
                        t.tipoExistencia = i.tipoExistencia
                        t.tipoCambio = 0
                        t.idUnidad = i.unidad1
                        t.cantidad = i.monto1 * -1
                        t.importeSoles = i.montokardex * -1
                        t.importeDolares = i.montokardexUS * -1
                        t.usuarioActualizacion = i.usuarioModificacion
                        t.fechaActualizacion = i.fechaModificacion
                        totalesBL.UpdateSingle2(t)
                    End If
                Next
                '----------------------------------------------------------------------

                'eliminando inventario
                inventarioBL.DeleteInventarioPorDocumento(documentoBE.idDocumento)

                'eliminando documento caja
                documentoCajaBl.DeleteDocumentoCaja(documentoBE.idDocumento)

                'eliminando tributos
                documentoDetalleObligacionBL.EliminarGrupoTributo(documentoBE.idDocumento)

                'Eliminando notas de debito y credito
                EliminarDocNotasRef(documentoBE.idDocumento)

                'eliminando guía de remisión
                documentoGuiaBL.EliminarGuiaGeneral(documentoBE.idDocumento)

                'eliminando asiento contable
                asientoBL.DeletePorDocumento(documentoBE.idDocumento)

                'eliminado costos referenciados
                recursoCostoBL.eliminarDetalleCostoByIdDocumento(documentoBE.idDocumento)

                Dim consultaVentas = (From vt In HeliosData.documentoventaAbarrotesDet _
                       Join v In HeliosData.documentoventaAbarrotes _
                       On vt.idDocumento Equals v.idDocumento _
                       Join cd In HeliosData.documentocompradetalle _
                       On cd.idItem Equals vt.idItem _
                       Where cd.idDocumento = codDoc _
                       And v.fechaDoc >= cd.fechaEntrega).ToList

                For Each i In consultaVentas
                    i.v.notificacionAsiento = "S"
                Next


                'eliminando coprobante General
                DeleteSingle(documentoBE)

                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub DeleteCompraDirectaSinRecepcionSL(ByVal documentoBE As documento, objTotalBorrar As List(Of totalesAlmacen))
        Dim documentocajaDetalleBL As New documentoCajaDetalleBL
        Dim documentoDetalleObligacionBL As New documentoObligacionTributariaDetalleBL
        Dim DocumentoBL As New documentoBL
        Dim inventarioBL As New InventarioMovimientoBL
        Dim documentoNotaBL As New documentocompraBL
        Dim documentoCompraDetalle As New documentocompradetalleBL
        Dim totales As New totalesAlmacenBL
        Dim documentoCajaBL As New documentoCajaDetalleBL
        'Dim documentoguiaDetalleBL As New documentoguiaDetalleBL

        inventarioBL.DeleteInventarioPorDocumento(documentoBE.idDocumento)
        'documentoguiaDetalleBL.EliminarDetalleItems(documentoBE.idDocumento)
        'Dim cajaDetalle As List(Of documentoCajaDetalle) = HeliosData.documentoCajaDetalle.Where(Function(o) o.documentoAfectado = documentoBE.idDocumento).ToList
        'For Each i In cajaDetalle
        '    DeleteSinglePagado(i.idDocumento)
        'Next
        documentoCajaBL.DeleteDocumentoCaja(documentoBE.idDocumento)
        'DocumentoBL.DeleteSinglePagado(documentocajaDetalleBL.RecuperarIDCompra(documentoBE.idDocumento)) 'ELIMINANDO DOCUMENTO CAJA
        documentoDetalleObligacionBL.EliminarGrupoTributo(documentoBE.idDocumento)
        EliminarDocNotasRef(documentoBE.idDocumento)
        totales.DeleteTotalesAlmacen(objTotalBorrar)
        DeleteSingle2(documentoBE)
    End Sub

    Public Sub DeletePagadoSL(ByVal documentoBE As documento)
        Dim documentocajaDetalleBL As New documentoCajaDetalleBL
        Dim documentoDetalleObligacionBL As New documentoObligacionTributariaDetalleBL
        Dim DocumentoBL As New documentoBL
        Dim inventarioBL As New InventarioMovimientoBL
        Dim documentoNotaBL As New documentocompraBL
        Dim documentoCompraBL As New documentocompraBL
        Dim documentoCompraDetalleBL As New documentocompradetalleBL
        Dim notificacionAlmacenBL As New notificacionAlmacenBL
        Dim documentoguiaDetalleBL As New documentoguiaDetalleBL
        Dim asientoBL As New AsientoBL
        Dim documentoCaja As New documentoCajaDetalleBL

        notificacionAlmacenBL.notificaionesSingle(documentoBE, documentoBE.idDocumento)
        inventarioBL.DeleteInventarioPorDocumento(documentoBE.idDocumento)
        'si existe la compra al credito se realizo elpago conuna caja
        ' documentoCaja.DeleteDocumentoCaja(documentoBE.idDocumento)
        DocumentoBL.DeleteSinglePagado(documentocajaDetalleBL.RecuperarIDCompra(documentoBE.idDocumento)) 'ELIMINANDO DOCUMENTO CAJA
        '-----
        documentoDetalleObligacionBL.EliminarGrupoTributo(documentoBE.idDocumento)
        'NOTAS DE CREDITO Y DEBIDO
        EliminarDocNotasRef(documentoBE.idDocumento)
        'Crea un notificacion y elimina asiento y movimiento
        documentoCompraBL.UpdateSingleDocCompra(documentoBE.idDocumento)
        documentoCompraDetalleBL.UpdateSingleDocCompraDetalle(documentoBE.idDocumento)
        documentoguiaDetalleBL.EliminarDetalleItemsSL(documentoBE.idDocumento)
        asientoBL.DeletePorDocumento(documentoBE.idDocumento)

    End Sub

    Public Sub DeleteCompraCreditoConRecepcionSL(ByVal documentoBE As documento)
        Dim documentocajaDetalleBL As New documentoCajaDetalleBL
        Dim DocumentoBL As New documentoBL
        Dim inventarioBL As New InventarioMovimientoBL
        Dim documentoNotaBL As New documentocompraBL
        Dim documentoCompraDetalle As New documentocompradetalleBL
        Dim documentoguiaDetalleBL As New documentoguiaDetalleBL

        inventarioBL.DeleteInventarioPorDocumento(documentoBE.idDocumento)
        documentoguiaDetalleBL.EliminarDetalleItems(documentoBE.idDocumento)
        'totalesCajaUsuario.DeleteTotalesCajaUsuarioCompra(documentoBE.idDocumento, documentoBE.usuarioActualizacion)
        DocumentoBL.DeleteSinglePagado(documentocajaDetalleBL.RecuperarIDCompra(documentoBE.idDocumento)) 'ELIMINANDO DOCUMENTO CAJA
        'documentoDetalleObligacionBL.EliminarGrupoTributo(documentoBE.idDocumento)
        EliminarDocNotasRef(documentoBE.idDocumento)
        documentoNotaBL.UpdateSingleDocCompra(documentoBE.idDocumento)
        documentoCompraDetalle.UpdateSingleDocCompraDetalle(documentoBE.idDocumento)
        'UpdateSingle2Free(documentoBE)
    End Sub

    '-------------------------------------------------------------------------------------------

    Public Sub DeleteSaldoAporte(ByVal documentoBE As documento, ListaItemsAeliminar As List(Of totalesAlmacen))
        Dim documentoDetalleObligacionBL As New documentoObligacionTributariaDetalleBL
        Dim totales As New totalesAlmacenBL
        Dim documentoCajaDetalleBL As New documentoCajaDetalleBL
        Dim inventarioBL As New InventarioMovimientoBL
        Dim documentoGuiaDetalleBL As New documentoguiaDetalleBL
        'METODOS
        inventarioBL.DeleteInventarioPorDocumento(documentoBE.idDocumento)
        totales.DeleteSaldoAportes(ListaItemsAeliminar)
        Dim cajaDetalle As List(Of documentoCajaDetalle) = HeliosData.documentoCajaDetalle.Where(Function(o) o.documentoAfectado = documentoBE.idDocumento).ToList
        For Each i In cajaDetalle
            DeleteSinglePagado(i.idDocumento)
        Next
        DeleteSingle2(documentoBE)
    End Sub

    '-------------eliminar --------------------------------------
    'Public Sub DeleteSL(ByVal documentoBE As documento, objTotalBorrar As List(Of totalesAlmacen))
    '    Dim documentoDetalleObligacionBL As New documentoObligacionTributariaDetalleBL
    '    Dim documentoCajaDetalleBL As New documentoCajaDetalleBL
    '    Dim inventarioBL As New InventarioMovimientoBL
    '    Dim documentoGuiaDetalleBL As New documentoguiaDetalleBL
    '    Dim documentoCompra As New documentocompraBL
    '    Dim documentoCompraDetalle As New documentocompradetalleBL
    '    Dim notificacionAlmacenBL As New notificacionAlmacenBL
    '    Dim documentocompraBL As New documentocompraBL
    '    Dim documentocompradetalleBL As New documentocompradetalleBL
    '    Dim totales As New totalesAlmacenBL
    '    Dim asientoBL As New AsientoBL
    '    'METODOS
    '    'Se elimina el inventario y guia
    '    inventarioBL.DeleteInventarioPorDocumento(documentoBE.idDocumento)
    '    documentoGuiaDetalleBL.EliminarDetalleItems(documentoBE.idDocumento)
    '    'si existe la compra al credito se realizo elpago conuna caja
    '    Dim cajaDetalle As List(Of documentoCajaDetalle) = HeliosData.documentoCajaDetalle.Where(Function(o) o.documentoAfectado = documentoBE.idDocumento).ToList
    '    For Each i In cajaDetalle
    '        'totalesCajaUsuario.DeleteTotalesCajaUsuarioDocCajaDetalle(i.idDocumento, i.usuarioModificacion, documentoBE.idDocumento)
    '        DeleteSinglePagado(i.idDocumento)
    '    Next
    '    documentoDetalleObligacionBL.EliminarGrupoTributo(documentoBE.idDocumento)
    '    'NOTAS DE CREDITO Y DEBIDO
    '    EliminarDocNotasRef(documentoBE.idDocumento)

    '    'actualiza la situacion del documento de la compra
    '    documentocompraBL.UpdateSingleDocCompra(documentoBE.idDocumento)
    '    documentocompradetalleBL.UpdateSingleDocCompraDetalle(documentoBE.idDocumento)
    '    notificacionAlmacenBL.notificaionesSingle(documentoBE, documentoBE.idDocumento)
    '    'Crea un notificacion y elimina asiento y movimiento
    '    asientoBL.DeletePorDocumento(documentoBE.idDocumento)
    '    'Elimina las existencias en transito
    '    totales.DeleteTotalesAlmacen(objTotalBorrar)
    'End Sub

    Public Sub DeleteCompraDirectaSinRecepcion(ByVal documentoBE As documento, objTotalBorrar As List(Of totalesAlmacen))
        Dim documentocajaDetalleBL As New documentoCajaDetalleBL
        Dim documentoDetalleObligacionBL As New documentoObligacionTributariaDetalleBL
        Dim DocumentoBL As New documentoBL
        Dim totales As New totalesAlmacenBL
        Dim totalesCajaUsuario As New CajaUsuarioBL
        Dim inventarioBL As New InventarioMovimientoBL
        Dim documentoNotaBL As New documentocompraBL
        Dim documentoguiaDetalleBL As New documentoguiaDetalleBL

        inventarioBL.DeleteInventarioPorDocumento(documentoBE.idDocumento)
        totales.DeleteTotalesAlmacen(objTotalBorrar)
        documentoguiaDetalleBL.EliminarDetalleItems(documentoBE.idDocumento)
        totalesCajaUsuario.DeleteTotalesCajaUsuarioCompra(documentoBE.idDocumento, documentoBE.usuarioActualizacion)
        DocumentoBL.DeleteSinglePagado(documentocajaDetalleBL.RecuperarIDCompra(documentoBE.idDocumento)) 'ELIMINANDO DOCUMENTO CAJA
        documentoDetalleObligacionBL.EliminarGrupoTributo(documentoBE.idDocumento)
        EliminarDocNotasRef(documentoBE.idDocumento)
        DeleteSingle2Free(documentoBE)

    End Sub

    Public Sub DeletePagado(ByVal documentoBE As documento, objTotalBorrar As List(Of totalesAlmacen))
        Dim documentocajaDetalleBL As New documentoCajaDetalleBL
        Dim documentoDetalleObligacionBL As New documentoObligacionTributariaDetalleBL
        Dim DocumentoBL As New documentoBL
        Dim totales As New totalesAlmacenBL
        Dim totalesCajaUsuario As New CajaUsuarioBL
        Dim inventarioBL As New InventarioMovimientoBL
        Dim documentoNotaBL As New documentocompraBL

        inventarioBL.DeleteInventarioPorDocumento(documentoBE.idDocumento)
        totales.DeleteTotalesAlmacen(objTotalBorrar)
        totalesCajaUsuario.DeleteTotalesCajaUsuarioCompra(documentoBE.idDocumento, documentoBE.usuarioActualizacion)
        DocumentoBL.DeleteSinglePagado(documentocajaDetalleBL.RecuperarIDCompra(documentoBE.idDocumento)) 'ELIMINANDO DOCUMENTO CAJA
        documentoDetalleObligacionBL.EliminarGrupoTributo(documentoBE.idDocumento)
        EliminarDocNotasRef(documentoBE.idDocumento)
        DeleteSingle2Free(documentoBE)

    End Sub

    'Public Sub DeleteDocumentoPagadoAlCredito(ByVal documentoBE As documento)
    '    Dim documentoDetalleObligacionBL As New documentoObligacionTributariaDetalleBL
    '    Dim inventarioBL As New InventarioMovimientoBL
    '    Dim documentocompraBL As New documentocompraBL
    '    Dim documentocompradetalleBL As New documentocompradetalleBL
    '    Dim notificacionAlmacenBL As New notificacionAlmacenBL
    '    Dim documentoGuiaDetalleBL As New documentoguiaDetalleBL
    '    Dim asientoBL As New AsientoBL
    '    'METODOS
    '    'Se elimina el inventario y guia
    '    inventarioBL.DeleteInventarioPorDocumento(documentoBE.idDocumento)
    '    'si existe la compra al credito se realizo elpago conuna caja
    '    Dim cajaDetalle As List(Of documentoCajaDetalle) = HeliosData.documentoCajaDetalle.Where(Function(o) o.documentoAfectado = documentoBE.idDocumento).ToList
    '    For Each i In cajaDetalle
    '        'totalesCajaUsuario.DeleteTotalesCajaUsuarioDocCajaDetalle(i.idDocumento, i.usuarioModificacion, documentoBE.idDocumento)
    '        DeleteSinglePagado(i.idDocumento)
    '    Next
    '    documentoDetalleObligacionBL.EliminarGrupoTributo(documentoBE.idDocumento)
    '    'NOTAS DE CREDITO Y DEBIDO
    '    EliminarDocNotasRef(documentoBE.idDocumento)
    '    'Crea un notificacion y elimina asiento y movimiento
    '    notificacionAlmacenBL.notificaionesSingle(documentoBE, documentoBE.idDocumento)
    '    documentocompraBL.UpdateSingleDocCompra(documentoBE.idDocumento)
    '    documentocompradetalleBL.UpdateSingleDocCompraDetalle(documentoBE.idDocumento)
    '    documentoGuiaDetalleBL.EliminarDetalleItemsSL(documentoBE.idDocumento)
    '    asientoBL.DeletePorDocumento(documentoBE.idDocumento)
    'End Sub

    'Public Sub DeletePagadoSL(ByVal documentoBE As documento)
    '    Dim documentocajaDetalleBL As New documentoCajaDetalleBL
    '    Dim documentoDetalleObligacionBL As New documentoObligacionTributariaDetalleBL
    '    Dim DocumentoBL As New documentoBL
    '    Dim totalesCajaUsuario As New CajaUsuarioBL
    '    Dim inventarioBL As New InventarioMovimientoBL
    '    Dim documentoNotaBL As New documentocompraBL
    '    Dim documentoCompraBL As New documentocompraBL
    '    Dim documentoCompraDetalleBL As New documentocompradetalleBL
    '    Dim notificacionAlmacenBL As New notificacionAlmacenBL

    '    inventarioBL.DeleteInventarioPorDocumento(documentoBE.idDocumento)
    '    totalesCajaUsuario.DeleteTotalesCajaUsuarioCompra(documentoBE.idDocumento, documentoBE.usuarioActualizacion)
    '    DocumentoBL.DeleteSinglePagado(documentocajaDetalleBL.RecuperarIDCompra(documentoBE.idDocumento)) 'ELIMINANDO DOCUMENTO CAJA
    '    documentoDetalleObligacionBL.EliminarGrupoTributo(documentoBE.idDocumento)
    '    EliminarDocNotasRef(documentoBE.idDocumento)
    '    documentoCompraBL.UpdateSingleDocCompra(documentoBE.idDocumento)
    '    documentoCompraDetalleBL.UpdateSingleDocCompraDetalle(documentoBE.idDocumento)
    '    notificacionAlmacenBL.notificaionesSingle(documentoBE, documentoBE.idDocumento)
    'End Sub

    'Public Sub DeleteCompraDirectaSinRecepcion(ByVal documentoBE As documento, objTotalBorrar As List(Of totalesAlmacen))
    '    Dim documentocajaDetalleBL As New documentoCajaDetalleBL
    '    Dim documentoDetalleObligacionBL As New documentoObligacionTributariaDetalleBL
    '    Dim DocumentoBL As New documentoBL
    '    Dim totales As New totalesAlmacenBL
    '    Dim totalesCajaUsuario As New CajaUsuarioBL
    '    Dim inventarioBL As New InventarioMovimientoBL
    '    Dim documentoNotaBL As New documentocompraBL
    '    Dim documentoguiaDetalleBL As New documentoguiaDetalleBL

    '    inventarioBL.DeleteInventarioPorDocumento(documentoBE.idDocumento)
    '    totales.DeleteTotalesAlmacen(objTotalBorrar)
    '    documentoguiaDetalleBL.EliminarDetalleItems(documentoBE.idDocumento)
    '    totalesCajaUsuario.DeleteTotalesCajaUsuarioCompra(documentoBE.idDocumento, documentoBE.usuarioActualizacion)
    '    DocumentoBL.DeleteSinglePagado(documentocajaDetalleBL.RecuperarIDCompra(documentoBE.idDocumento)) 'ELIMINANDO DOCUMENTO CAJA
    '    documentoDetalleObligacionBL.EliminarGrupoTributo(documentoBE.idDocumento)
    '    EliminarDocNotasRef(documentoBE.idDocumento)
    '    DeleteSingle2Free(documentoBE)

    'End Sub

    'Public Sub DeleteCompraDirectaSinRecepcionSL(ByVal documentoBE As documento, objTotalBorrar As List(Of totalesAlmacen))
    '    Dim documentocajaDetalleBL As New documentoCajaDetalleBL
    '    Dim documentoDetalleObligacionBL As New documentoObligacionTributariaDetalleBL
    '    Dim DocumentoBL As New documentoBL
    '    Dim inventarioBL As New InventarioMovimientoBL
    '    Dim documentoNotaBL As New documentocompraBL
    '    Dim documentoCompraDetalle As New documentocompradetalleBL
    '    Dim totales As New totalesAlmacenBL
    '    'Dim documentoguiaDetalleBL As New documentoguiaDetalleBL

    '    inventarioBL.DeleteInventarioPorDocumento(documentoBE.idDocumento)
    '    'documentoguiaDetalleBL.EliminarDetalleItems(documentoBE.idDocumento)
    '    Dim cajaDetalle As List(Of documentoCajaDetalle) = HeliosData.documentoCajaDetalle.Where(Function(o) o.documentoAfectado = documentoBE.idDocumento).ToList
    '    For Each i In cajaDetalle
    '        DeleteSinglePagado(i.idDocumento)
    '    Next
    '    'DocumentoBL.DeleteSinglePagado(documentocajaDetalleBL.RecuperarIDCompra(documentoBE.idDocumento)) 'ELIMINANDO DOCUMENTO CAJA
    '    documentoDetalleObligacionBL.EliminarGrupoTributo(documentoBE.idDocumento)
    '    EliminarDocNotasRef(documentoBE.idDocumento)
    '    totales.DeleteTotalesAlmacen(objTotalBorrar)
    '    DeleteSingle2(documentoBE)
    'End Sub

    'Public Sub DeleteCompraCreditoConRecepcionSL(ByVal documentoBE As documento)
    '    Dim documentocajaDetalleBL As New documentoCajaDetalleBL
    '    Dim DocumentoBL As New documentoBL
    '    Dim inventarioBL As New InventarioMovimientoBL
    '    Dim documentoNotaBL As New documentocompraBL
    '    Dim documentoCompraDetalle As New documentocompradetalleBL
    '    Dim documentoguiaDetalleBL As New documentoguiaDetalleBL

    '    inventarioBL.DeleteInventarioPorDocumento(documentoBE.idDocumento)
    '    documentoguiaDetalleBL.EliminarDetalleItems(documentoBE.idDocumento)
    '    totalesCajaUsuario.DeleteTotalesCajaUsuarioCompra(documentoBE.idDocumento, documentoBE.usuarioActualizacion)
    '    DocumentoBL.DeleteSinglePagado(documentocajaDetalleBL.RecuperarIDCompra(documentoBE.idDocumento)) 'ELIMINANDO DOCUMENTO CAJA
    '    documentoDetalleObligacionBL.EliminarGrupoTributo(documentoBE.idDocumento)
    '    EliminarDocNotasRef(documentoBE.idDocumento)
    '    documentoNotaBL.UpdateSingleDocCompra(documentoBE.idDocumento)
    '    documentoCompraDetalle.UpdateSingleDocCompraDetalle(documentoBE.idDocumento)
    '    UpdateSingle2Free(documentoBE)
    'End Sub

    '-------------------------------------------------------------------------------------------

    Public Sub DeleteAporte(ByVal documentoBE As documento, objTotalBorrar As List(Of totalesAlmacen))
        Dim totales As New totalesAlmacenBL
        Dim inventarioBL As New InventarioMovimientoBL
        inventarioBL.DeleteInventarioPorDocumento(documentoBE.idDocumento)
        totales.DeleteTotalesAlmacenOE(objTotalBorrar)
        DeleteSingle2Free(documentoBE)
    End Sub

    Public Sub EliminarTransferenciaCaja(ByVal documentoBE As documento)
        Dim cajaBL As New documentoCajaBL
        'cajaBL.EliminarDocumentoPorIdPadre(documentoBE.idDocumento)
        cajaBL.EliminarDocumentoPorIdPadreSL(documentoBE)
    End Sub

    'Public Sub EliminarOtrosMovimientosCaja(ByVal documentoBE As documento)
    '    Dim recursoBL As New recursoCostoDetalleBL
    '    Using ts As New TransactionScope

    '        Dim ConsultaCaja = (From n In HeliosData.documentoCajaDetalle _
    '                             Where n.idCajaPadre = documentoBE.idDocumento).Count
    '        If (ConsultaCaja = 0) Then
    '            DeleteSingle2Free(documentoBE)
    '            HeliosData.SaveChanges()
    '            ts.Complete()
    '        Else
    '            Throw New Exception("Ya existe transacciones con esta cuenta!")
    '        End If

    '    End Using
    'End Sub

    Public Sub EliminarOtrosMovimientosCaja(ByVal documentoBE As documento)
        Dim recursoBL As New recursoCostoDetalleBL
        Using ts As New TransactionScope

            Dim ConsultaCaja = (From n In HeliosData.documentoCajaDetalle Where n.idDocumento = documentoBE.idDocumento).FirstOrDefault
            If (Not IsNothing(ConsultaCaja)) Then
                Dim ConsultaCajaHijo = (From n In HeliosData.documentoCajaDetalle Where n.idCajaPadre = ConsultaCaja.secuencia).Count
                If ((ConsultaCajaHijo = 0)) Then
                    DeleteSingle2Free(documentoBE)
                    HeliosData.SaveChanges()
                    ts.Complete()
                End If
            Else
                Throw New Exception("Ya existe transacciones con esta cuenta!")
            End If
        End Using
    End Sub

    Public Sub EliminarDocNotasRef(intIdDocumentoPadre As Integer)
        Dim documentoCaja As New documentoCajaDetalleBL
        Dim documentoCajaDetalleBL As New documentoCajaDetalleBL
        Dim documentoBL As New documentoBL
        Using ts As New TransactionScope
            Dim documentoNotas As List(Of documentocompra) = HeliosData.documentocompra.Where(Function(o) o.idPadre = intIdDocumentoPadre).ToList

            For Each i In documentoNotas

                If i.tipoCompra = TIPO_COMPRA.NOTA_CREDITO Then
                    DeleteNotasFullPadre(i)
                    documentoCaja.DeleteDocumentoCaja(i.idDocumento)
                    '''''''''''''''''''
                    Dim lista As New List(Of String)
                    lista.Add("07")
                    lista.Add("87")

                    Dim listaHijas = (From n In HeliosData.documentocompra Where lista.Contains(n.tipoDoc) _
                                     AndAlso n.idPadre = i.idDocumento AndAlso n.tipoCompra = "EXD").ToList

                    For Each c In listaHijas
                        documentoCajaDetalleBL.DeleteDocumentoCaja(c.idDocumento)
                        documentoBL.DeleteSingleVariable(c.idDocumento)
                    Next
                    ''''''''''''''''''''''''
                ElseIf i.tipoCompra = TIPO_COMPRA.NOTA_DEBITO Then
                    DeleteNotasDebitoFullPadre(i)
                    documentoCaja.DeleteDocumentoCaja(i.idDocumento)

                End If
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub
    'Public Sub EliminarDocNotasRef(intIdDocumentoPadre As Integer)
    '    Dim documentoCaja As New documentoCajaDetalleBL
    '    Using ts As New TransactionScope
    '        Dim documentoNotas As List(Of documentocompra) = HeliosData.documentocompra.Where(Function(o) o.idPadre = intIdDocumentoPadre).ToList

    '        For Each i In documentoNotas

    '            If i.tipoCompra = TIPO_COMPRA.NOTA_CREDITO Then
    '                DeleteNotasFullPadre(i)
    '                documentoCaja.DeleteDocumentoCaja(i.idDocumento)
    '            ElseIf i.tipoCompra = TIPO_COMPRA.NOTA_DEBITO Then
    '                DeleteNotasDebitoFullPadre(i)
    '                documentoCaja.DeleteDocumentoCaja(i.idDocumento)
    '            End If
    '        Next
    '        HeliosData.SaveChanges()
    '        ts.Complete()
    '    End Using
    'End Sub

    Public Sub EliminarDocNotasRefVentas(intIdDocumentoPadre As Integer)
        Dim documentoCaja As New documentoCajaDetalleBL
        Using ts As New TransactionScope
            Dim documentoNotas As List(Of documentoventaAbarrotes) = HeliosData.documentoventaAbarrotes.Where(Function(o) o.idPadre = intIdDocumentoPadre).ToList

            For Each i In documentoNotas

                If i.tipoVenta = TIPO_COMPRA.NOTA_CREDITO Then
                    DeleteNotasFullPadreVentas(i)
                    documentoCaja.DeleteDocumentoCaja(i.idDocumento)
                ElseIf i.tipoVenta = TIPO_COMPRA.NOTA_DEBITO Then
                    DeleteNotasDebitoFullPadreVenta(i)
                    documentoCaja.DeleteDocumentoCaja(i.idDocumento)
                End If
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Public Sub DeleteOtrasEntradas(ByVal documentoBE As documento, objTotalBorrar As List(Of totalesAlmacen))
        Dim documentocajaDetalleBL As New documentoCajaDetalleBL
        Dim DocumentoBL As New documentoBL
        Dim totales As New totalesAlmacenBL
        Dim inventarioBL As New InventarioMovimientoBL

        Using ts As New TransactionScope
            Dim ConsultaCosto = (From n In HeliosData.recursoCostoDetalle _
                              Where n.documentoRef = documentoBE.idDocumento).ToList

            For Each i In ConsultaCosto
                CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(i)
            Next

            inventarioBL.DeleteInventarioPorDocumento(documentoBE.idDocumento)
            totales.DeleteTotalesAlmacenOE(objTotalBorrar)
            DeleteSingle2Free(documentoBE)

            HeliosData.SaveChanges()
            ts.Complete()
        End Using

    End Sub


    ''' <summary>
    ''' Eliminar Comprobante Otras Entradas a almacen de un Costo de producción
    ''' </summary>
    ''' <param name="documentoBE"></param>
    ''' <remarks></remarks>
    Public Sub EliminarComprobanteORPByCosto(ByVal documentoBE As documento)
        Dim documentocajaDetalleBL As New documentoCajaDetalleBL
        Dim t As New totalesAlmacen
        Dim DocumentoBL As New documentoBL
        Dim totalesBL As New totalesAlmacenBL
        Dim inventarioBL As New InventarioMovimientoBL
        inventarioBL.DeleteInventarioPorDocumento(documentoBE.idDocumento)

        Dim consulta = (From n In HeliosData.documentocompradetalle _
                       Where n.idDocumento = documentoBE.idDocumento).ToList


        For Each i In consulta
            t = New totalesAlmacen
            t.idEmpresa = documentoBE.idEmpresa
            t.idEstablecimiento = documentoBE.idCentroCosto
            t.idAlmacen = i.almacenRef
            t.origenRecaudo = i.destino
            t.idItem = i.idItem
            t.cantidad = i.monto1 * -1
            t.precioUnitarioCompra = 0
            t.importeSoles = i.importe * -1
            t.importeDolares = i.importeUS * -1
            totalesBL.UpdateSingle2(t)
        Next

        DeleteSingle2Free(documentoBE)
    End Sub

    Public Sub DeleteOtrasTransAlmacenOE(ByVal documentoBE As documento, ListaOrigen As List(Of totalesAlmacen),
                                          ListaDestino As List(Of totalesAlmacen))
        Dim documentocajaDetalleBL As New documentoCajaDetalleBL
        Dim DocumentoBL As New documentoBL
        Dim totales As New totalesAlmacenBL
        Dim inventarioBL As New InventarioMovimientoBL
        inventarioBL.DeleteInventarioPorDocumento(documentoBE.idDocumento)
        totales.EliminarTransferenciaAlmacenOrigen(ListaOrigen)
        totales.EliminarTransferenciaAlmacenDestino(ListaDestino)
        DeleteSingle2Free(documentoBE)
    End Sub

    Public Sub DeleteOtrasTransAlmacenOESL(ByVal documentoBE As documento)
        Dim documentocajaDetalleBL As New documentoCajaDetalleBL
        Dim DocumentoBL As New documentoBL
        Dim inventarioBL As New InventarioMovimientoBL
        inventarioBL.DeleteInventarioPorDocumento(documentoBE.idDocumento)
        DeleteSingle2Free(documentoBE)
    End Sub


    Public Sub DeleteOtrasSalidasDeAlmacen(ByVal documentoBE As documento, objTotalBorrar As List(Of totalesAlmacen))
        Dim DocumentoBL As New documentoBL
        Dim totales As New totalesAlmacenBL
        Dim inventarioBL As New InventarioMovimientoBL

        Using ts As New TransactionScope

            Dim ConsultaCosto = (From n In HeliosData.recursoCostoDetalle _
                                 Where n.documentoRef = documentoBE.idDocumento).ToList

            For Each i In ConsultaCosto
                CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(i)
            Next

            inventarioBL.DeleteInventarioPorDocumento(documentoBE.idDocumento)
            totales.DeleteTotalesAlmacenOSalidas(objTotalBorrar)
            DeleteSingle2Free(documentoBE)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using

    End Sub

    Public Sub DeleteOtrasSalidas(ByVal documentoBE As documento, objTotalBorrar As List(Of totalesAlmacen))
        Dim DocumentoBL As New documentoBL
        Dim totales As New totalesAlmacenBL
        Dim inventarioBL As New InventarioMovimientoBL
        inventarioBL.DeleteInventarioPorDocumento(documentoBE.idDocumento)
        totales.DeleteTotalesAlmacenOS(objTotalBorrar)
        DeleteSingle(documentoBE)
    End Sub

    Public Sub DeleteNotas(ByVal documentoBE As documento, objTotalBorrar As List(Of totalesAlmacen))
        Dim documentocajaDetalleBL As New documentoCajaDetalleBL
        Dim DocumentoBL As New documentoBL
        Dim totales As New totalesAlmacenBL
        Dim inventarioBL As New InventarioMovimientoBL
        Dim documentoCompraBL As New documentocompraBL
        Dim documentoCompraDetalleBL As New documentocompradetalleBL
        Dim CAN_BOF As Decimal = 0

        If documentoCompraBL.TieneNotasCD(documentoBE.IdDocumentoAfectado) = True Then
            Throw New Exception("No puede eliminar cuando existan varias referencias!!")
        Else
            Select Case documentoBE.documentocompra.destino
                Case "NC-DISMINUIR CANTIDAD"
                    inventarioBL.DeleteInventarioPorDocumento(documentoBE.idDocumento)
                    totales.DeleteTotalesAlmacenNotas(objTotalBorrar)
                Case "NC-DISMINUIR IMPORTE"
                    inventarioBL.DeleteInventarioPorDocumento(documentoBE.idDocumento)
                    totales.DeleteTotalesAlmacenNotas(objTotalBorrar)
                Case "NC-DISMINUIR CANTIDAD E IMPORTE"

                Case "NC-DEVOLUCION DE EXISTENCIAS"
                    inventarioBL.DeleteInventarioPorDocumento(documentoBE.idDocumento)
                    totales.DeleteTotalesAlmacenNotas(objTotalBorrar)
                Case "BONIFICACIONES RECIBIDAS (OPC. Beneficios)"
                    inventarioBL.DeleteInventarioPorDocumento(documentoBE.idDocumento)
                    totales.DeleteTotalesAlmacenNotasBOF(objTotalBorrar)
                Case "BONIFICACIONES RECIBIDAS (OPC. Reduc. costos)"
                    inventarioBL.DeleteInventarioPorDocumento(documentoBE.idDocumento)
                    totales.DeleteTotalesAlmacenNotasBOF2(objTotalBorrar)
            End Select


            documentocajaDetalleBL.DeleteDocumentoCaja(documentoBE.idDocumento)

            'DeleteSingle(documentoBE)
            DeleteSingle2Free(documentoBE)
        End If
    End Sub

    Public Sub DeleteNotasFullPadre(ByVal documentoBE As documentocompra)
        Dim documentocajaDetalleBL As New documentoCajaDetalleBL
        Dim DocumentoBL As New documentoBL
        '   Dim totales As New totalesAlmacenBL
        Dim inventarioBL As New InventarioMovimientoBL
        Dim documentoCompraBL As New documentocompraBL
        Dim documentoCompraDetalleBL As New documentocompradetalleBL
        Dim documentoCajaSA As New documentoCajaBL
        Dim CAN_BOF As Decimal = 0

        Select Case documentoBE.sustentado
            Case Notas_Credito.DEV_EXISTENCIA
                inventarioBL.DeleteInventarioPorDocumento(documentoBE.idDocumento)
            '    totales.DeleteTotalesAlmacenNotasFullPadre(documentoCompraDetalleBL.GetUbicar_documentocompradetallePorCompra(documentoBE.idDocumento), documentoBE)
                'documentoCajaSA.EliminarDocumentoPorIdPadre(documentoBE.idDocumento)
            Case Notas_Credito.DR_REDUCCION_COSTOS
                inventarioBL.DeleteInventarioPorDocumento(documentoBE.idDocumento)
            '    totales.DeleteTotalesAlmacenNotasFullPadre(documentoCompraDetalleBL.GetUbicar_documentocompradetallePorCompra(documentoBE.idDocumento), documentoBE)

            Case Notas_Credito.DR_BENEFICIO

            Case Notas_Credito.ERR_PRECIO
                inventarioBL.DeleteInventarioPorDocumento(documentoBE.idDocumento)
            '    totales.DeleteTotalesAlmacenNotasFullPadre(documentoCompraDetalleBL.GetUbicar_documentocompradetallePorCompra(documentoBE.idDocumento), documentoBE)

            Case Notas_Credito.ERR_CANTIDAD
                inventarioBL.DeleteInventarioPorDocumento(documentoBE.idDocumento)
              '  totales.DeleteTotalesAlmacenNotasFullPadre(documentoCompraDetalleBL.GetUbicar_documentocompradetallePorCompra(documentoBE.idDocumento), documentoBE)

            Case Notas_Credito.BOF_REDUC_COSTO_IGUAL_COMPRA
                inventarioBL.DeleteInventarioPorDocumento(documentoBE.idDocumento)
              '  totales.DeleteTotalesAlmacenNotasFullPadre(documentoCompraDetalleBL.GetUbicar_documentocompradetallePorCompra(documentoBE.idDocumento), documentoBE)

            Case Notas_Credito.BOF_REDUC_COSTO_DISTINTO_COMPRA


            Case Notas_Credito.BOF_BENEFICIO_TERCEROS

        End Select

        'For Each i In documentoCompraDetalleBL.GetUbicar_documentocompradetallePorCompra(documentoBE.idDocumento)
        '    Select Case documentoBE.sustentado
        '        Case Notas_Credito.BOF_REDUC_COSTO_IGUAL_COMPRA
        '            CAN_BOF = i.monto1
        '            i.monto1 = 0
        '            documentoCompraBL.UpdateDataNotaCredito(i.idPadreDTCompra, CDec(i.importe) * -1, CDec(i.importeUS) * -1, CDec(i.monto1) * -1, CAN_BOF * -1)
        '            '  documentoCompraBL.UpdateDataNotaCredito(i.secuencia, CDec(i.importe) , CDec(i.importeUS) * -1, CDec(i.monto1) * -1, CAN_BOF * -1)
        '        Case Else
        '            CAN_BOF = 0
        '            documentoCompraBL.UpdateDataNotaCredito(i.idPadreDTCompra, CDec(i.importe) * -1, CDec(i.importeUS) * -1, CDec(i.monto1) * -1, CAN_BOF)
        '    End Select
        'Next

        'If documentoBE.documentocompra.estadoPago = TIPO_COMPRA.PAGO.PAGADO Then
        '    DocumentoBL.DeleteSinglePagado(documentocajaDetalleBL.RecuperarIDCompra(documentoBE.documentocompra.idPadre)) 'ELIMINANDO DOCUMENTO CAJA
        '    DeleteSingle(documentoBE)
        'Else
        DeleteSingleVariable(documentoBE.idDocumento)
        '  End If

    End Sub

    Public Sub DeleteNotasFullPadreVentas(ByVal documentoBE As documentoventaAbarrotes)
        Dim documentocajaDetalleBL As New documentoCajaDetalleBL
        Dim DocumentoBL As New documentoBL
        ' Dim totales As New totalesAlmacenBL
        Dim inventarioBL As New InventarioMovimientoBL
        Dim documentoCompraBL As New documentoventaAbarrotesBL
        Dim documentoCompraDetalleBL As New documentoventaAbarrotesDetBL
        Dim documentoCajaSA As New documentoCajaBL
        Dim CAN_BOF As Decimal = 0

        Select Case documentoBE.sustentado
            Case Notas_Credito.DEV_EXISTENCIA
                inventarioBL.DeleteInventarioPorDocumento(documentoBE.idDocumento)
                '    totales.DeleteTotalesAlmacenNotasFullPadreVenta(documentoCompraDetalleBL.GetUbicar_documentoventaAbarrotesDetPorIDocumento(documentoBE.idDocumento), documentoBE)
                'documentoCajaSA.EliminarDocumentoPorIdPadre(documentoBE.idDocumento)

        End Select

        'For Each i In documentoCompraDetalleBL.GetUbicar_documentocompradetallePorCompra(documentoBE.idDocumento)
        '    Select Case documentoBE.sustentado
        '        Case Notas_Credito.BOF_REDUC_COSTO_IGUAL_COMPRA
        '            CAN_BOF = i.monto1
        '            i.monto1 = 0
        '            documentoCompraBL.UpdateDataNotaCredito(i.idPadreDTCompra, CDec(i.importe) * -1, CDec(i.importeUS) * -1, CDec(i.monto1) * -1, CAN_BOF * -1)
        '            '  documentoCompraBL.UpdateDataNotaCredito(i.secuencia, CDec(i.importe) , CDec(i.importeUS) * -1, CDec(i.monto1) * -1, CAN_BOF * -1)
        '        Case Else
        '            CAN_BOF = 0
        '            documentoCompraBL.UpdateDataNotaCredito(i.idPadreDTCompra, CDec(i.importe) * -1, CDec(i.importeUS) * -1, CDec(i.monto1) * -1, CAN_BOF)
        '    End Select
        'Next

        'If documentoBE.documentocompra.estadoPago = TIPO_COMPRA.PAGO.PAGADO Then
        '    DocumentoBL.DeleteSinglePagado(documentocajaDetalleBL.RecuperarIDCompra(documentoBE.documentocompra.idPadre)) 'ELIMINANDO DOCUMENTO CAJA
        '    DeleteSingle(documentoBE)
        'Else
        DeleteSingleVariable(documentoBE.idDocumento)
        '  End If

    End Sub


    Public Sub DeleteNotasDebitoFullPadre(ByVal documentoBE As documentocompra)
        Dim documentocajaDetalleBL As New documentoCajaDetalleBL
        Dim DocumentoBL As New documentoBL
        Dim totales As New totalesAlmacenBL
        Dim inventarioBL As New InventarioMovimientoBL
        Dim documentoCompraBL As New documentocompraBL
        Dim documentoCompraDetalleBL As New documentocompradetalleBL

        inventarioBL.DeleteInventarioPorDocumento(documentoBE.idDocumento)
        'totales.DeleteTotalesAlmacenNotasDEBITOFullPadre(documentoCompraDetalleBL.GetUbicar_documentocompradetallePorCompra(documentoBE.idDocumento), documentoBE)

        'For Each i In documentoCompraDetalleBL.GetUbicar_documentocompradetallePorCompra(documentoBE.idDocumento)
        '    documentoCompraBL.UpdateDataNotaDebito(i.idPadreDTCompra, CDec(i.importe) * -1, CDec(i.importeUS) * -1, 0)
        'Next

        ''If documentoBE.documentocompra.estadoPago = TIPO_COMPRA.PAGO.PAGADO Then
        '    DocumentoBL.DeleteSinglePagado(documentocajaDetalleBL.RecuperarIDCompra(documentoBE.documentocompra.idPadre)) 'ELIMINANDO DOCUMENTO CAJA
        '    DeleteSingle(documentoBE)
        'Else
        DeleteSingleVariable(documentoBE.idDocumento)
        '  End If

    End Sub

    Public Sub DeleteNotasDebitoFullPadreVenta(ByVal documentoBE As documentoventaAbarrotes)
        Dim documentocajaDetalleBL As New documentoCajaDetalleBL
        Dim DocumentoBL As New documentoBL
        'Dim totales As New totalesAlmacenBL
        Dim inventarioBL As New InventarioMovimientoBL
        Dim documentoCompraBL As New documentoventaAbarrotesBL
        Dim documentoCompraDetalleBL As New documentoventaAbarrotesDetBL

        inventarioBL.DeleteInventarioPorDocumento(documentoBE.idDocumento)
        '   totales.DeleteTotalesAlmacenNotasDEBITOFullPadreVenta(documentoCompraDetalleBL.GetUbicar_documentoventaAbarrotesDetPorIDocumento(documentoBE.idDocumento), documentoBE)

        'For Each i In documentoCompraDetalleBL.GetUbicar_documentocompradetallePorCompra(documentoBE.idDocumento)
        '    documentoCompraBL.UpdateDataNotaDebito(i.idPadreDTCompra, CDec(i.importe) * -1, CDec(i.importeUS) * -1, 0)
        'Next

        'If documentoBE.documentocompra.estadoPago = TIPO_COMPRA.PAGO.PAGADO Then
        '    DocumentoBL.DeleteSinglePagado(documentocajaDetalleBL.RecuperarIDCompra(documentoBE.documentocompra.idPadre)) 'ELIMINANDO DOCUMENTO CAJA
        '    DeleteSingle(documentoBE)
        'Else
        DeleteSingleVariable(documentoBE.idDocumento)
        '  End If

    End Sub


    Public Sub DeleteNotasDebito(ByVal documentoBE As documento, objTotalBorrar As List(Of totalesAlmacen))
        Dim documentocajaDetalleBL As New documentoCajaDetalleBL
        Dim DocumentoBL As New documentoBL
        Dim totales As New totalesAlmacenBL
        Dim inventarioBL As New InventarioMovimientoBL
        Dim documentoCompraBL As New documentocompraBL
        Dim documentoCompraDetalleBL As New documentocompradetalleBL

        If documentoCompraBL.TieneNotasCD(documentoBE.IdDocumentoAfectado) = True Then
            Throw New Exception("No puede eliminar cuando existan varias referencias!!")
        Else
            inventarioBL.DeleteInventarioPorDocumento(documentoBE.idDocumento)
            totales.DeleteTotalesAlmacenNotasDEBITO(objTotalBorrar)
            For Each i In documentoCompraDetalleBL.GetUbicar_documentocompradetallePorCompra(documentoBE.idDocumento)
                documentoCompraBL.UpdateDataNotaDebito(i.idPadreDTCompra, CDec(i.importe) * -1, CDec(i.importeUS) * -1, 0)
            Next
            DeleteSingle2Free(documentoBE)
        End If
    End Sub

    Public Sub DeleteVentaTicket(ByVal documentoBE As documento, objTotalBorrar As List(Of totalesAlmacen))
        Dim totales As New totalesAlmacenBL
        Dim inventarioBL As New InventarioMovimientoBL
        Try
            Using ts As New TransactionScope
                Dim consulta As documentoventaAbarrotes = HeliosData.documentoventaAbarrotes.Where(Function(o) o.idDocumento = documentoBE.idDocumento).FirstOrDefault
                If Not IsNothing(consulta) Then
                    If consulta.estadoCobro = "PN" Then
                        inventarioBL.DeleteInventarioPorDocumento(documentoBE.idDocumento)
                        totales.DeleteTotalesAlmacenVentaTicket(objTotalBorrar)
                        DeleteSingle2Free(documentoBE)
                    ElseIf consulta.estadoCobro = "DC" Then
                        Throw New Exception("Comprobante modificado/cobrado, actualice!!")
                    Else
                        Throw New Exception("Comprobante anulado/borrado!!")
                    End If

                End If
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub DeleteVentaTicketXitem(ByVal documentoBE As documento, objTotalBorrar As totalesAlmacen)
        Dim totales As New totalesAlmacenBL
        Dim inventarioBL As New InventarioMovimientoBL
        Dim valMn As Decimal = 0
        Dim valMe As Decimal = 0

        Dim valCostoMn As Decimal = 0
        Dim valCostoMe As Decimal = 0

        Dim valVCmn As Decimal = 0
        Dim valVCme As Decimal = 0
        Try
            Using ts As New TransactionScope
                Dim consulta As documentoventaAbarrotes = HeliosData.documentoventaAbarrotes.Where(Function(o) o.idDocumento = documentoBE.idDocumento).FirstOrDefault
                If Not IsNothing(consulta) Then
                    inventarioBL.DeleteInventarioPorDocumentoXitem(documentoBE.idDocumento, objTotalBorrar.idAlmacen, objTotalBorrar.idItem)
                    totales.DeleteTotalesAlmacenVentaTicketXitem(objTotalBorrar)

                    Dim detaVenta As documentoventaAbarrotesDet = HeliosData.documentoventaAbarrotesDet.Where(Function(o) o.secuencia = objTotalBorrar.SecuenciaDetalle).FirstOrDefault
                    valMn = detaVenta.importeMN
                    valMe = detaVenta.importeME

                    valCostoMn = detaVenta.salidaCostoMN
                    valCostoMn = detaVenta.salidaCostoME

                    valVCmn = detaVenta.montokardex
                    valVCme = detaVenta.montokardexUS
                    CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(detaVenta)
                    'DeleteSingle2Free(documentoBE)

                End If
                consulta.ImporteNacional = consulta.ImporteNacional - valMn
                consulta.ImporteExtranjero = consulta.ImporteNacional - valMe

                consulta.importeCostoMN = consulta.importeCostoMN - valCostoMn
                consulta.importeCostoME = consulta.importeCostoME - valCostoMe

                consulta.bi01 = consulta.bi01 - valVCmn
                consulta.bi01us = consulta.bi01us - valVCme
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub DeleteVentaNormalAlCredito(ByVal documentoBE As documento, objTotalBorrar As List(Of totalesAlmacen))
        Dim documentoDetalleObligacionBL As New documentoObligacionTributariaDetalleBL
        Dim inventarioBL As New InventarioMovimientoBL
        Dim documentocompraBL As New documentocompraBL
        Dim documentocompradetalleBL As New documentocompradetalleBL
        Dim notificacionAlmacenBL As New notificacionAlmacenBL
        Dim documentoGuiaDetalleBL As New documentoguiaDetalleBL
        Dim asientoBL As New AsientoBL
        Dim totales As New totalesAlmacenBL
        Dim documentoCajaBl As New documentoCajaDetalleBL
        'METODOS
        'Se elimina el inventario y guia
        Try
            Dim veNta As documentoventaAbarrotes = HeliosData.documentoventaAbarrotes.Where(Function(o) o.idDocumento = documentoBE.idDocumento).First

            Select Case veNta.estadoCobro
                Case TIPO_VENTA.VENTA_ANULADA
                    Throw New Exception("Esta venta ya está anulada!")

                Case Else

                    inventarioBL.DeleteInventarioPorDocumento(documentoBE.idDocumento)
                    totales.DeleteTotalesAlmacenVentaTicket(objTotalBorrar)
                    'si existe la compra al credito se realizo elpago conuna caja
                    documentoCajaBl.DeleteDocumentoCaja(documentoBE.idDocumento)
                    '----------------
                    documentoDetalleObligacionBL.EliminarGrupoTributo(documentoBE.idDocumento)
                    'NOTAS DE CREDITO Y DEBIDO
                    EliminarDocNotasRef(documentoBE.idDocumento)
                    documentoGuiaDetalleBL.EliminarDetalleItemsSL(documentoBE.idDocumento)
                    asientoBL.DeletePorDocumento(documentoBE.idDocumento)
                    'DeleteSingle2Free(documentoBE)

                    veNta.estadoCobro = TIPO_VENTA.VENTA_ANULADA
                    HeliosData.SaveChanges()
            End Select
        Catch ex As Exception
            Throw ex
        End Try
    
    End Sub

    Public Sub DeleteVentaTicketCobrado(ByVal documentoBE As documento, objTotalBorrar As List(Of totalesAlmacen))
        Dim DocumentoBL As New documentoBL
        Dim docVentaBL As New documentoventaAbarrotesBL
        Dim documentocajaDetalleBL As New documentoCajaDetalleBL
        Dim totales As New totalesAlmacenBL
        Dim totalesCajaUsuario As New CajaUsuarioBL
        Dim inventarioBL As New InventarioMovimientoBL
        Dim asientoBL As New AsientoBL
        Try
            Using ts As New TransactionScope
                Dim consulta As documentoventaAbarrotes = HeliosData.documentoventaAbarrotes.Where(Function(o) o.idDocumento = documentoBE.idDocumento).FirstOrDefault
                consulta.fechaActualizacion = DateTime.Now
                If Not IsNothing(consulta) Then
                    If consulta.estadoCobro = TIPO_VENTA.VENTA_ANULADA Then
                        Throw New Exception("El documento esta anulado")
                    Else
                        asientoBL.DeletePorDocumento(documentoBE.idDocumento)
                        inventarioBL.DeleteInventarioPorDocumento(documentoBE.idDocumento)
                        totales.DeleteTotalesAlmacenVentaTicket(objTotalBorrar)
                        Select Case documentoBE.tipoDoc
                            Case TIPO_VENTA.VENTA_AL_TICKET
                                totalesCajaUsuario.DeleteTotalesCajaUsuario(documentoBE.idDocumento, documentoBE.usuarioActualizacion)
                            Case TIPO_VENTA.VENTA_AL_TICKET_DIRECTA
                                totalesCajaUsuario.DeleteTotalesCajaUsuario(documentoBE.idDocumento, documentoBE.usuarioActualizacion)
                            Case TIPO_VENTA.VENTA_PAGADA
                                totalesCajaUsuario.DeleteTotalesCajaUsuario(documentoBE.idDocumento, documentoBE.usuarioActualizacion)
                        End Select
                        DocumentoBL.DeleteSinglePagado(documentocajaDetalleBL.RecuperarIDCompra(documentoBE.idDocumento)) 'ELIMINANDO DOCUMENTO CAJA
                        docVentaBL.AnularVenta(documentoBE.idDocumento)

                    End If
                End If
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        ' DeleteSingle(documentoBE)
    End Sub

    Public Sub CompraSaldada(ByVal documentoBE As documento)

        'Dim documentoCajaDetalleBL As New documentoCajaDetalleBL
        'Dim venta As documentocompradetalle = HeliosData.documentocompradetalle.Where(Function(o) o.idDocumento = documentoBE.IdDocumentoAfectado).FirstOrDefault

        'documentoCajaDetalleBL.ActualizarItemsPagosFull(documentoBE.IdDocumentoAfectado)

        'Dim ventaDetalle = (From n In HeliosData.documentoventaAbarrotesDet _
        '              Where n.idDocumento = venta.idDocumento AndAlso n.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO).Count

        'If ventaDetalle > 0 Then
        '    venta.estadoCobro = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
        'Else
        '    venta.estadoCobro = TIPO_COMPRA.PAGO.PAGADO
        'End If


        Dim totalPagos = Aggregate i In HeliosData.documentoCajaDetalle _
                   Where i.documentoAfectado = documentoBE.IdDocumentoAfectado _
                   Into mn = Sum(i.montoSoles), _
               mne = Sum(i.montoUsd)


        Dim compra As documentocompra = HeliosData.documentocompra.Where(Function(o) o.idDocumento = documentoBE.IdDocumentoAfectado).First

        Dim moNtoCompraMN As Decimal = 0
        Dim salCompra As Decimal = 0

        Dim pagos As Decimal = totalPagos.mn.GetValueOrDefault
        moNtoCompraMN = compra.importeTotal

        salCompra = moNtoCompraMN - pagos

        If salCompra <= 0 Then
            ' pagado
            compra.estadoPago = TIPO_COMPRA.PAGO.PAGADO
        Else
            ' peNdieNte
            compra.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
        End If

      
        HeliosData.SaveChanges()
    End Sub

    Public Sub CompraExcedente(ByVal documentoBE As documento)

        Dim totalPagos = Aggregate i In HeliosData.documentoCajaDetalle _
                   Where i.documentoAfectado = documentoBE.IdDocumentoAfectado _
                   Into mn = Sum(i.montoSoles), _
               mne = Sum(i.montoUsd)


        Dim compra As documentocompra = HeliosData.documentocompra.Where(Function(o) o.idDocumento = documentoBE.IdDocumentoAfectado).First

        Dim moNtoCompraMN As Decimal = 0
        Dim salCompra As Decimal = 0

        Dim pagos As Decimal = totalPagos.mn.GetValueOrDefault
        moNtoCompraMN = compra.importeTotal

        salCompra = moNtoCompraMN - pagos

        If salCompra <= 0 Then
            ' pagado
            compra.estadoPago = TIPO_VENTA.PAGO.COBRADO
        Else
            ' peNdieNte
            compra.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO
        End If
        HeliosData.SaveChanges()
    End Sub

    Public Sub EliminarVentaExcedente(ByVal documentoBE As documento)

        Dim totalPagos = Aggregate i In HeliosData.documentoCajaDetalle _
                   Where i.documentoAfectado = documentoBE.IdDocumentoAfectado _
                   Into mn = Sum(i.montoSoles), _
               mne = Sum(i.montoUsd)

        Dim venta As documentoventaAbarrotes = HeliosData.documentoventaAbarrotes.Where(Function(o) o.idDocumento = documentoBE.IdDocumentoAfectado).First

        Dim moNtoCompraMN As Decimal = 0
        Dim salCompra As Decimal = 0

        Dim pagos As Decimal = totalPagos.mn.GetValueOrDefault
        moNtoCompraMN = venta.ImporteNacional

        salCompra = moNtoCompraMN - pagos

        If salCompra <= 0 Then
            ' pagado
            venta.estadoCobro = TIPO_COMPRA.PAGO.PAGADO
        Else
            ' peNdieNte
            venta.estadoCobro = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
        End If
        HeliosData.SaveChanges()
    End Sub

    Public Sub VentaSaldada(ByVal documentoBE As documento)
        Dim documentoCajaDetalleBL As New documentoCajaDetalleBL
        Dim venta As documentoventaAbarrotes = HeliosData.documentoventaAbarrotes.Where(Function(o) o.idDocumento = documentoBE.IdDocumentoAfectado).FirstOrDefault

        documentoCajaDetalleBL.ActualizarItemsPagosFull(documentoBE.IdDocumentoAfectado)

        Dim ventaDetalle = (From n In HeliosData.documentoventaAbarrotesDet _
                      Where n.idDocumento = venta.idDocumento AndAlso n.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO).Count

        If ventaDetalle > 0 Then
            venta.estadoCobro = TIPO_VENTA.PAGO.PENDIENTE_PAGO
        Else
            venta.estadoCobro = TIPO_VENTA.PAGO.COBRADO
        End If
        '-------------------------------------------------------------------------------------------------------------------

        'Dim totalPagos = Aggregate i In HeliosData.documentoCajaDetalle _
        '           Where i.documentoAfectado = documentoBE.IdDocumentoAfectado _
        '           Into mn = Sum(i.montoSoles), _
        '       mne = Sum(i.montoUsd)


        'Dim compra As documentoventaAbarrotes = HeliosData.documentoventaAbarrotes.Where(Function(o) o.idDocumento = documentoBE.IdDocumentoAfectado).First

        'Dim moNtoCompraMN As Decimal = 0
        'Dim salCompra As Decimal = 0

        'Dim pagos As Decimal = totalPagos.mn.GetValueOrDefault
        'moNtoCompraMN = compra.ImporteNacional

        'salCompra = moNtoCompraMN - pagos

        'If salCompra <= 0 Then
        '    ' pagado
        '    compra.estadoCobro = TIPO_VENTA.PAGO.COBRADO
        'Else
        '    ' peNdieNte
        '    compra.estadoCobro = TIPO_VENTA.PAGO.PENDIENTE_PAGO
        'End If
        HeliosData.SaveChanges()
    End Sub

    Public Sub EliminarPagoMembresia(ByVal documentoBE As documento)
        Dim membresiaBL As New Entidadmembresia_GymBL
        Try
            Using ts As New TransactionScope
                DeleteSingle(documentoBE)
                Dim venta = HeliosData.Entidadmembresia_Gym.Where(Function(o) o.idDocumento = documentoBE.IdDocumentoAfectado).FirstOrDefault
                If venta IsNot Nothing Then
                    Dim pagos = membresiaBL.GetDocumentoCajaMembresiaByDocumento(venta.idDocumento)
                    Dim saldo = pagos.importe - pagos.CustomDocumentoCaja.montoSoles

                    If saldo > 0 Then
                        If pagos.CustomDocumentoCaja.montoSoles.GetValueOrDefault = 0 Then
                            venta.statusPago = Gimnasio_EstadoMembresiaPago.Pendiente
                        Else
                            venta.statusPago = Gimnasio_EstadoMembresiaPago.PagoParcial
                        End If
                    Else
                        venta.statusPago = Gimnasio_EstadoMembresiaPago.Completo
                    End If
                End If
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Sub ElimiNarPagoCompra(ByVal documentoBE As documento)
        Dim objItemsaldo As New documentoCajaDetalle
        Dim cajaDetalleBL As New documentoCajaDetalleBL
        Dim saldoItem As Double = 0
        Dim saldoItemME As Double = 0
        Dim monedaExtranjeraBL As New movimientocajaextranjeraBL
        Dim docCajaBL As New documentoCajaBL
        Try
            Using ts As New TransactionScope

                Select Case documentoBE.idOrden
                    Case 9908 ' PAGO A CLIENTES

                        Dim saldo = docCajaBL.SaldoCajaOnline(New documentoCaja With {.fechaProceso = DateTime.Now,
                                                                      .entidadFinanciera = documentoBE.entidad})

                        If documentoBE.ImporteMN <= saldo Then

                            DeleteSingle(documentoBE)
                            VentaSaldada(documentoBE)
                        Else
                            Throw New Exception("No hay Saldo Suficiente!")

                        End If

                    Case 9907 ' PAGO A PROVEEDORES
                        Dim cajdetalle = (From n In HeliosData.documentoCajaDetalle
                                          Where n.idDocumento = documentoBE.idDocumento).ToList

                        For Each i In cajdetalle
                            Dim NCventa = Aggregate det In HeliosData.documentocompradetalle
                                        Join v In HeliosData.documentocompra On v.idDocumento Equals det.idDocumento
                                        Where v.tipoDoc = "07" And det.idPadreDTCompra = i.documentoAfectadodetalle
                                        Into NCmn = Sum(det.importe),
                                             NCme = Sum(det.importeUS)

                            Dim NBventa = Aggregate det In HeliosData.documentocompradetalle
                                         Join v In HeliosData.documentocompra On v.idDocumento Equals det.idDocumento
                                         Where v.tipoDoc = "08" And det.idPadreDTCompra = i.documentoAfectadodetalle
                                         Into NBmn = Sum(det.importe),
                                              NBme = Sum(det.importeUS)

                            '    Dim Ajustes = Aggregate p In HeliosData.documentoLibroDiarioDetalle _
                            '     Join compra In HeliosData.documentoLibroDiario _
                            '     On p.idDocumento Equals compra.idDocumento _
                            '                Where p.cuenta = i.documentoAfectadodetalle _
                            '                And compra.tipoRegistro = "AJU"
                            'Into AJmn = Sum(p.importeMN), _
                            '     AJme = Sum(p.importeME)


                            objItemsaldo = cajaDetalleBL.ObtenerCuentasPorPagarPorProducto(i.documentoAfectado, i.documentoAfectadodetalle)

                            Dim VentaDetalle As documentocompradetalle = HeliosData.documentocompradetalle.Where(Function(o) o.secuencia = i.documentoAfectadodetalle).FirstOrDefault

                            'saldoItem = objItemsaldo.MontoDeudaSoles + i.montoSoles - objItemsaldo.MontoPagadoSoles - NCventa.NCmn.GetValueOrDefault + NBventa.NBmn.GetValueOrDefault - Ajustes.AJmn.GetValueOrDefault
                            'saldoItemME = objItemsaldo.MontoDeudaUSD + i.montoUsd - objItemsaldo.MontoPagadoUSD - NCventa.NCme.GetValueOrDefault + NBventa.NBme.GetValueOrDefault - Ajustes.AJme.GetValueOrDefault

                            saldoItem = objItemsaldo.MontoDeudaSoles + i.montoSoles - objItemsaldo.MontoPagadoSoles - NCventa.NCmn.GetValueOrDefault + NBventa.NBmn.GetValueOrDefault
                            saldoItemME = objItemsaldo.MontoDeudaUSD + i.montoUsd - objItemsaldo.MontoPagadoUSD - NCventa.NCme.GetValueOrDefault + NBventa.NBme.GetValueOrDefault

                            If saldoItem <= 0 Then
                                VentaDetalle.estadoPago = TIPO_COMPRA.PAGO.PAGADO
                            Else
                                VentaDetalle.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                            End If
                        Next

                        DeleteSingle(documentoBE)
                        CompraSaldada(documentoBE)
                    Case 9922
                        DeleteSingle(documentoBE)
                        CompraExcedente(documentoBE)
                    Case 9920
                        DeleteSingle(documentoBE)
                        EliminarVentaExcedente(documentoBE)
                End Select
                monedaExtranjeraBL.EliminarPagos(documentoBE.idDocumento)
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    'Public Sub ElimiNarPagoCompra(ByVal documentoBE As documento)
    '    Dim objItemsaldo As New documentoCajaDetalle
    '    Dim cajaDetalleBL As New documentoCajaDetalleBL
    '    Dim saldoItem As Double = 0
    '    Dim saldoItemME As Double = 0
    '    Dim monedaExtranjeraBL As New movimientocajaextranjeraBL
    '    Try
    '        Using ts As New TransactionScope

    '            Select Case documentoBE.idOrden
    '                Case 9908 ' PAGO A CLIENTES
    '                    DeleteSingle(documentoBE)
    '                    VentaSaldada(documentoBE)
    '                Case 9907 ' PAGO A PROVEEDORES
    '                    Dim cajdetalle = (From n In HeliosData.documentoCajaDetalle _
    '                                 Where n.idDocumento = documentoBE.idDocumento).ToList

    '                    For Each i In cajdetalle
    '                        Dim NCventa = Aggregate det In HeliosData.documentocompradetalle _
    '                                    Join v In HeliosData.documentocompra On v.idDocumento Equals det.idDocumento _
    '                                    Where v.tipoDoc = "07" And det.idPadreDTCompra = i.documentoAfectadodetalle _
    '                                    Into NCmn = Sum(det.importe), _
    '                                         NCme = Sum(det.importeUS)

    '                        Dim NBventa = Aggregate det In HeliosData.documentocompradetalle _
    '                                     Join v In HeliosData.documentocompra On v.idDocumento Equals det.idDocumento _
    '                                     Where v.tipoDoc = "08" And det.idPadreDTCompra = i.documentoAfectadodetalle _
    '                                     Into NBmn = Sum(det.importe), _
    '                                          NBme = Sum(det.importeUS)

    '                        '    Dim Ajustes = Aggregate p In HeliosData.documentoLibroDiarioDetalle _
    '                        '     Join compra In HeliosData.documentoLibroDiario _
    '                        '     On p.idDocumento Equals compra.idDocumento _
    '                        '                Where p.cuenta = i.documentoAfectadodetalle _
    '                        '                And compra.tipoRegistro = "AJU"
    '                        'Into AJmn = Sum(p.importeMN), _
    '                        '     AJme = Sum(p.importeME)


    '                        objItemsaldo = cajaDetalleBL.ObtenerCuentasPorPagarPorProducto(i.documentoAfectado, i.documentoAfectadodetalle)

    '                        Dim VentaDetalle As documentocompradetalle = HeliosData.documentocompradetalle.Where(Function(o) o.secuencia = i.documentoAfectadodetalle).FirstOrDefault

    '                        'saldoItem = objItemsaldo.MontoDeudaSoles + i.montoSoles - objItemsaldo.MontoPagadoSoles - NCventa.NCmn.GetValueOrDefault + NBventa.NBmn.GetValueOrDefault - Ajustes.AJmn.GetValueOrDefault
    '                        'saldoItemME = objItemsaldo.MontoDeudaUSD + i.montoUsd - objItemsaldo.MontoPagadoUSD - NCventa.NCme.GetValueOrDefault + NBventa.NBme.GetValueOrDefault - Ajustes.AJme.GetValueOrDefault

    '                        saldoItem = objItemsaldo.MontoDeudaSoles + i.montoSoles - objItemsaldo.MontoPagadoSoles - NCventa.NCmn.GetValueOrDefault + NBventa.NBmn.GetValueOrDefault
    '                        saldoItemME = objItemsaldo.MontoDeudaUSD + i.montoUsd - objItemsaldo.MontoPagadoUSD - NCventa.NCme.GetValueOrDefault + NBventa.NBme.GetValueOrDefault

    '                        If saldoItem <= 0 Then
    '                            VentaDetalle.estadoPago = TIPO_COMPRA.PAGO.PAGADO
    '                        Else
    '                            VentaDetalle.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
    '                        End If
    '                    Next

    '                    DeleteSingle(documentoBE)
    '                    CompraSaldada(documentoBE)
    '                Case 9922
    '                    DeleteSingle(documentoBE)
    '                    CompraExcedente(documentoBE)
    '                Case 9920
    '                    DeleteSingle(documentoBE)
    '                    EliminarVentaExcedente(documentoBE)
    '            End Select
    '            monedaExtranjeraBL.EliminarPagos(documentoBE.idDocumento)
    '            HeliosData.SaveChanges()
    '            ts.Complete()
    '        End Using
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Public Sub DeleteSingle(ByVal documentoBE As documento)
        Dim totalesCajaUsuario As New CajaUsuarioBL
        Dim consulta As documento = HeliosData.documento.Where(Function(o) o.idDocumento = documentoBE.idDocumento).FirstOrDefault
        If Not IsNothing(consulta) Then
            '   totalesCajaUsuario.DeleteTotalesCajaUsuarioDocCajaDetalle(documentoBE.idDocumento, documentoBE.usuarioActualizacion, documentoBE.IdDocumentoAfectado)
            CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(consulta)
            HeliosData.SaveChanges()
        Else
            Throw New Exception("El comprobante no se encuentra, verifique su existencia!")
        End If
    End Sub

    Public Sub DeleteSinglePrestamos(ByVal documentoBE As documento)
        Dim totalesCajaUsuario As New CajaUsuarioBL
        Dim consulta As documento = HeliosData.documento.Where(Function(o) o.idDocumento = documentoBE.idDocumento).FirstOrDefault
        If Not IsNothing(consulta) Then
            totalesCajaUsuario.DeleteTotalesCajaUsuarioDocCajaDetallePrestamoOT(documentoBE.idDocumento, documentoBE.usuarioActualizacion, documentoBE.IdDocumentoAfectado)
            CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(consulta)
            HeliosData.SaveChanges()
        Else
            Throw New Exception("El comprobante no se encuentra, verifique su existencia!")
        End If
    End Sub

    Public Sub DeleteSingle2Free(ByVal documentoBE As documento)
        Using ts As New TransactionScope
            Dim consulta As documento = HeliosData.documento.Where(Function(o) o.idDocumento = documentoBE.idDocumento).FirstOrDefault
            If Not IsNothing(consulta) Then
                CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(consulta)

            Else
                Throw New Exception("El comprobante no se encuentra, verifique su existencia!")
            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub DeleteSingle2(ByVal documentoBE As documento)
        'Dim totalesCuentasBL As New totalesCuentasBL
        'Dim idDocMaster As Integer
        Dim consulta As documento = HeliosData.documento.Where(Function(o) o.idDocumento = documentoBE.idDocumento).FirstOrDefault
        If Not IsNothing(consulta) Then
            CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(consulta)
            'idDocMaster = totalesCuentasBL.DeleteTotalesCC(documentoBE.idDocumento)
            'If ((idDocMaster) <> 0) Then
            '    totalesCuentasBL.DeleteTotalesCC(idDocMaster)
            'End If
            HeliosData.SaveChanges()
        Else
            '   Throw New Exception("El comprobante no se encuentra, verifique su existencia!")
        End If
    End Sub

    Public Sub deleteSingleCaja(ByVal documentoBE As documento)
        DeleteSingle(documentoBE)
    End Sub

    Public Sub EliminarPagoPrestamo(ByVal documentoBE As documento)
        DeleteSinglePrestamos(documentoBE)
    End Sub

    Public Sub DeleteSingleVariable(ByVal intIdDocumento As Integer)
        Dim consulta As documento = HeliosData.documento.Where(Function(o) o.idDocumento = intIdDocumento).FirstOrDefault
        Using ts As New TransactionScope
            If Not IsNothing(consulta) Then
                CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(consulta)
            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub DeleteSinglePagado(intIdDocumento As Integer)
        Dim recursoCostoBL As New recursoCostoDetalleBL
        Using ts As New TransactionScope
            'eliminado costos referenciados
            recursoCostoBL.eliminarDetalleCostoByIdDocumento(intIdDocumento)

            Dim consulta As documento = HeliosData.documento.Where(Function(o) o.idDocumento = intIdDocumento).FirstOrDefault
            If Not IsNothing(consulta) Then
                CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(consulta)
            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub DeleteSinglePagadoDetalles(intIdDocumento As Integer)
        Dim recursoCostoBL As New recursoCostoDetalleBL
        Using ts As New TransactionScope
            Dim consulta As documentoCajaDetalle = HeliosData.documentoCajaDetalle.Where(Function(o) o.idCajaPadre = intIdDocumento).FirstOrDefault

            If Not IsNothing(consulta) Then
                Dim consultaElimiar As documento = HeliosData.documento.Where(Function(o) o.idDocumento = consulta.idDocumento).FirstOrDefault
                If Not IsNothing(consultaElimiar) Then
                    CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(consultaElimiar)
                End If
            End If

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub EliminarObligacionPercepcion(intIdDocumentoCompra As Integer, intIdDocumentoTributo As Integer)
        Dim con As List(Of documentoObligacionDetalle) = HeliosData.documentoObligacionDetalle.Where(Function(o) o.idDocumentoOrigen = intIdDocumentoCompra And _
                                                                                                         o.idDocumento = intIdDocumentoTributo).ToList
        Using ts As New TransactionScope
            For Each i In con
                EliminarObligacionPercepcionDealle(i.secuencia)
            Next
            Dim consultaVerificaExiste As Integer = HeliosData.documentoObligacionDetalle.Where(Function(o) o.idDocumento = intIdDocumentoTributo).Count
            If consultaVerificaExiste > 0 Then
            Else
                DeleteSingleVariable(intIdDocumentoTributo)
            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using

    End Sub

    Public Sub EliminarObligacionPercepcionDealle(intSecuencia As Integer)
        Using ts As New TransactionScope
            Dim con As documentoObligacionDetalle = HeliosData.documentoObligacionDetalle.Where(Function(o) o.secuencia = intSecuencia).First
            CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(con)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using

    End Sub

    Public Function GetListar_documento() As List(Of documento)
        Return (From a In HeliosData.documento Select a).ToList
    End Function

    Public Function GetUbicar_documentoPorID(idDocumento As Integer) As documento
        Return (From a In HeliosData.documento
                 Where a.idDocumento = idDocumento Select a).First
    End Function
    Public Function InsertNotificacion(ByVal documentoBE As documento) As Integer
        Dim documento As New documento
        Dim IdDocumento As Integer
        Using ts As New TransactionScope

            documento.idEmpresa = documentoBE.idEmpresa
            documento.idCentroCosto = documentoBE.idCentroCosto
            documento.idProyecto = documentoBE.idProyecto
            documento.tipoDoc = documentoBE.tipoDoc
            documento.fechaProceso = documentoBE.fechaProceso
            documento.nroDoc = documentoBE.nroDoc
            documento.idOrden = documentoBE.idOrden
            documento.moneda = documentoBE.moneda
            documento.idEntidad = documentoBE.idEntidad
            documento.entidad = documentoBE.entidad
            documento.tipoEntidad = documentoBE.tipoEntidad
            documento.nrodocEntidad = documentoBE.nrodocEntidad
            documento.tipoOperacion = documentoBE.tipoOperacion
            documento.usuarioActualizacion = documentoBE.usuarioActualizacion
            documento.fechaActualizacion = documentoBE.fechaActualizacion
            HeliosData.documento.Add(documento)
            HeliosData.SaveChanges()
            ts.Complete()
            IdDocumento = documento.idDocumento
        End Using
        Return IdDocumento
    End Function

    Public Function DeleteUsuarioCajaSL(ByVal documentoBE As documento) As String
        Dim UsuarioCajaBL As New CajaUsuarioBL
        Dim ReturnDato As String = ""

        Dim ListaTipoOperacion As New List(Of String)
        ListaTipoOperacion.Add("02")
        ListaTipoOperacion.Add("01")
        ListaTipoOperacion.Add("100")
        ListaTipoOperacion.Add("101")
        ListaTipoOperacion.Add("9907")
        ListaTipoOperacion.Add("9908")
        ListaTipoOperacion.Add("12.1")
        ListaTipoOperacion.Add("12.2")

        Try
            Using ts As New TransactionScope
                Dim compraPago = (From c In HeliosData.documentoCaja
                       Where c.usuarioModificacion = CStr(documentoBE.idDocumento) And
                       ListaTipoOperacion.Contains(c.codigoLibro)).Count

                If (compraPago = 0) Then

                    Dim cajasHijas = (From n In HeliosData.cajaUsuario
                        Where n.idPadre = documentoBE.idDocumento).ToList

                    For Each i In cajasHijas

                        Dim validaUsuario = (From c In HeliosData.documentoCaja
                                            Where c.usuarioModificacion = i.idcajaUsuario And
                                            ListaTipoOperacion.Contains(c.codigoLibro)).Count


                        If validaUsuario = 0 Then
                            UsuarioCajaBL.EliminarCajaPorIdUsuario(i.idcajaUsuario)
                        Else
                            Throw New Exception("La caja seleccionda registra transacciones, no puede eliminarse!")
                        End If

                    Next


                    Dim consulta = (From n In HeliosData.cajaUsuario _
                            Join c In HeliosData.documentoCaja
                            On n.idPersona Equals c.codigoProveedor _
                            Where n.idcajaUsuario = documentoBE.idDocumento).ToList

                    If (Not IsNothing(consulta)) Then
                        For Each items In consulta
                            DeleteSinglePagado(items.c.idDocumento)
                        Next

                        UsuarioCajaBL.EliminarCajaPorIdUsuario(documentoBE.idDocumento)

                    End If
                Else
                    ReturnDato = "OK"
                End If
                HeliosData.SaveChanges()
                ts.Complete()
                Return ReturnDato
            End Using
         
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub DeleteAnticipoSL(ByVal documentoBE As documento)
        Dim documentocajaDetalleBL As New documentoCajaDetalleBL
        Dim DocumentoBL As New documentoBL
        'Dim asientoBL As New AsientoBL
        Dim documentoCaja As New documentoCajaDetalleBL
        DocumentoBL.DeleteSinglePagado(documentoBE.idDocumento)
        ' documentoCaja.DeleteDocumentoCaja(documentoBE.idDocumento)
        DocumentoBL.DeleteSinglePagado(documentocajaDetalleBL.RecuperarIDCompra(documentoBE.idDocumento)) 'ELIMINANDO DOCUMENTO CAJA
        'asientoBL.DeletePorDocumento(documentoBE.idDocumento)
    End Sub

    Public Sub DeleteSingleVariableSL(ByVal intIdDocumento As Integer)
        Dim consulta As documento = HeliosData.documento.Where(Function(o) o.idDocumento = intIdDocumento).FirstOrDefault
        If Not IsNothing(consulta) Then
            If Not IsNothing(consulta) Then
                CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(consulta)
            End If
            HeliosData.SaveChanges()
        End If
    End Sub

    Public Sub updateDocumentoTransferencia(ByVal documentoBE As documentoGuia)
        Dim documentoCompra As New documentocompraBL

        Using ts As New TransactionScope

            Dim documentoGuia As documento = HeliosData.documento.Where(Function(o) _
                                            o.idDocumento = documentoBE.idDocumento).First()

            documentoGuia.nroDoc = documentoBE.numeroDoc

            Dim documentocom As documento = HeliosData.documento.Where(Function(o) _
                                            o.idDocumento = documentoBE.idEntidadTransporte).First()

            documentocom.nroDoc = documentoBE.numeroDoc

            documentoCompra.updateDocumentoGuiaTransferencia(documentoBE)

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub
End Class

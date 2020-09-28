Imports System.ComponentModel
Imports System.Drawing.Printing
Imports System.Runtime.Serialization
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.Presentation.WinForm
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Drawing
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Tools

Public Class FormNotaVentaDescuentoFE

#Region "Variables"
    Public Property IdCompraOrigen() As Integer
    Public Property ListaAsientonTransito As New List(Of asiento)
    Public ListaEstadosFinancieros As List(Of estadosFinancieros)
    Public ListaOperacion As New List(Of tabladetalle)

#End Region
#Region "Constructor"
    Sub New(idDocumento As Integer)

        ' This call is required by the designer.
        InitializeComponent()
        FormatoGridAvanzado(dgvMov, False, False, 7.0F)
        GetTableGrid()
        ' Add any initialization after the InitializeComponent() call.

        CargarCombo()
        UbicarDocumento(idDocumento)


        Dim strIDEmpresa = Gempresas.IdEmpresaRuc
        configuracionModuloV2(strIDEmpresa, "NTC", "", GEstableciento.IdEstablecimiento)

        txtGlosa.Text = cboTipoNota.Text

    End Sub
#End Region



#Region "TIMER"
    Sub parpadeo()
        Static parpadear As Boolean
        parpadear = Not parpadear
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick

    End Sub
    Private TiempoRestante As Integer
    Public Sub TimerOn(ByRef Interval As Short)
        If Interval > 0 Then
            Timer1.Enabled = True
        Else
            Timer1.Enabled = False
        End If

    End Sub
    Public Function TiempoEjecutar(ByVal Tiempo As Integer)
        TiempoEjecutar = ""
        TiempoRestante = Tiempo  ' 1 minutos=60 segundos 
        Timer1.Interval = 400

        Call TimerOn(1000) ' Hechanos a andar el timer
    End Function
#End Region

#Region "Metodos"

    Public Sub UpdateEnvioSunat(idDoc As Integer)
        Try

            Dim docSA As New documentoVentaAbarrotesSA

            docSA.UpdateEnvioSunat(idDoc)

            'MessageBox.Show("Se Genero Correctamente")
        Catch ex As Exception
            MessageBox.Show("No se Pudo Actualizar")
        End Try



    End Sub

    Public Sub EnviarNotaCreditoElectronico(idDocumento As Integer)

        Dim documentoSA As New documentoVentaAbarrotesSA
        Dim documentoDetSA As New documentoVentaAbarrotesDetSA
        Dim entidadSA As New entidadSA
        Dim DetalleFactura As Fact.Sunat.Business.Entity.DocumentoElectronicoDetalle

        Try

            Dim comprobante = documentoSA.GetUbicar_NotaXID(idDocumento)
            Dim comprobanteDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(idDocumento)
            Dim receptor = entidadSA.GetUbicarEntPorID(Gempresas.IdEmpresaRuc, comprobante.idCliente)
            Dim numerovent As String = String.Format("{0:00000000}", comprobante.numeroVenta)
            Dim tipoDoc = String.Format("{0:00}", comprobante.tipoDocumento)
            Dim conteo As Integer = 0
            Dim numeroafect As String = String.Format("{0:00000000}", comprobante.numeroDoc)
            '//Enviando el documento

            Dim Factura As New Fact.Sunat.Business.Entity.DocumentoElectronico

            'Datos del Cliente 
            Factura.Action = 0
            Factura.idEmpresa = Gempresas.ubigeo 'lblIdPse.Text
            Factura.Contribuyente_id = Gempresas.IdEmpresaRuc
            Factura.EnvioSunat = "NO"
            'Receptor de la Factura
            Factura.NroDocumentoRec = receptor.nrodoc
            Factura.TipoDocumentoRec = receptor.tipoDoc
            Factura.NombreLegalRec = receptor.nombreCompleto
            'Datos Generales De La Factura
            Factura.IdDocumento = comprobante.serieVenta & "-" & numerovent
            Factura.FechaEmision = comprobante.fechaDoc
            Factura.FechaRecepcion = DateTime.Now 'fecha en la que se envia al PSE
            'Factura.FechaVencimiento = DateTime.Now
            Factura.HoraEmision = comprobante.fechaDoc.Value.ToString("HH:mm:ss")
            If comprobante.moneda = "1" Then
                Factura.Moneda = "PEN"
            ElseIf comprobante.moneda = "2" Then
                Factura.Moneda = "USD"
            End If
            Factura.TipoDocumento = tipoDoc
            Factura.TotalIgv = comprobante.igv01
            Factura.TotalVenta = comprobante.ImporteNacional
            Factura.Gravadas = comprobante.bi01
            Factura.Exoneradas = comprobante.bi02
            Factura.TipoOperacion = "0101"

            'Cargando el Detalle de la Factura

            For Each i In comprobanteDetalle
                conteo += 1

                DetalleFactura = New Fact.Sunat.Business.Entity.DocumentoElectronicoDetalle
                DetalleFactura.Id = conteo
                DetalleFactura.Cantidad = i.monto1
                DetalleFactura.PrecioReferencial = i.precioUnitario
                DetalleFactura.CodigoItem = i.idItem
                DetalleFactura.Descripcion = i.nombreItem
                DetalleFactura.UnidadMedida = i.unidad1
                DetalleFactura.Impuesto = i.montoIgv
                If i.destino = "1" Then
                    DetalleFactura.TipoImpuesto = "10" 'CATALOGO 7
                    DetalleFactura.TipoPrecio = "01" 'CATALOGO 16
                    DetalleFactura.PrecioUnitario = CalculoBaseImponible(i.precioUnitario, 1.18) 'FormatNumber(CalculoBaseImponible(i.precioUnitario, 1.18), 2)
                ElseIf i.destino = "2" Then
                    DetalleFactura.TipoImpuesto = "20" 'CATALOGO 7
                    DetalleFactura.TipoPrecio = "01" '"02"  'CATALOGO 16
                    DetalleFactura.PrecioUnitario = i.precioUnitario
                End If

                DetalleFactura.TotalVenta = i.montokardex
                'DetalleItems .Descuento = "falta"
                'DetalleItems .ImpuestoSelectivo = "falta"
                'DetalleItems.OtroImpuesto = "falta"
                'DetalleItems.PlacaVehiculo = "falta"
                Factura.DocumentoElectronicoDetalle.Add(DetalleFactura)
            Next

            'Datos Adicionales 
            Dim DocRel = New Fact.Sunat.Business.Entity.DocumentoRelacionado()
            DocRel.TipoDocumento = comprobante.TipoDocNota
            DocRel.NroDocumento = comprobante.serie & "-" & numeroafect
            Factura.DocumentoRelacionado.Add(DocRel)

            Dim DocDiscrep = New Fact.Sunat.Business.Entity.Discrepancia()
            DocDiscrep.NroReferencia = comprobante.serie & "-" & numeroafect 'comprobante.numeroDoc
            DocDiscrep.Tipo = comprobante.notaCredito 'comprobante.TipoDocNota
            DocDiscrep.Descripcion = comprobante.glosa  '"POR ANULACION"
            Factura.Discrepancia.Add(DocDiscrep)



            'Enviando al PSE
            Dim codigo = Helios.Fact.Sunat.WCFService.ServiceAccess.Admin.DocumentoElectronicoSA.DocumentoElectronicoSave(Factura, Nothing)

            If codigo.idDocumentoElectronico > 0 Then

                UpdateEnvioSunat(comprobante.idDocumento)
                MessageBox.Show("La Nota de Credito se Envio Correctamente al PSE")
            End If

        Catch ex As Exception

            MessageBox.Show("No se Pudo Enviar")

        End Try


    End Sub


    Function ComprobanteCaja(listaCaja As List(Of documentoventaAbarrotesDet)) As documento
        Dim efSA As New EstadosFinancierosSA
        Dim ef As New estadosFinancieros
        Dim nDocumentoCaja As New documento()
        Dim objCaja As New documentoCaja
        Dim objCajaDetalle As New documentoCajaDetalle
        Dim ListaDetalle As New List(Of documentoCajaDetalle)
        Dim asiento As New asiento
        Dim nMovimiento As New movimiento

        Dim sumMN As Decimal = 0
        Dim sumME As Decimal = 0


        ef = efSA.GetUbicar_estadosFinancierosPorID(cbocajaPago.SelectedValue) 'GFichaUsuarios.IdCajaDestino)
        nDocumentoCaja = New documento()
        nDocumentoCaja.idDocumento = 0
        nDocumentoCaja.idEmpresa = Gempresas.IdEmpresaRuc
        nDocumentoCaja.idCentroCosto = ef.idEstablecimiento  'GEstableciento.IdEstablecimiento
        If IsNothing(GProyectos) Then
        Else
            nDocumentoCaja.idProyecto = GProyectos.IdProyectoActividad
        End If
        nDocumentoCaja.tipoDoc = "109"
        nDocumentoCaja.fechaProceso = txtFecha.Value
        nDocumentoCaja.nroDoc = txtSerie.Text & "-" & txtNumero.Text 'Nothing ' IIf(rbEfectivo.Checked = True, Nothing, txtNumCaja.Text.Trim)
        nDocumentoCaja.idEntidad = CInt(txtCliente.Tag)
        nDocumentoCaja.entidad = txtCliente.Text
        nDocumentoCaja.tipoEntidad = txtDocCliente.Text
        nDocumentoCaja.nrodocEntidad = txtRuc.Text
        nDocumentoCaja.idOrden = Nothing
        nDocumentoCaja.moneda = If(txtdesmoneda.Text = "NACIONAL", "1", "2")
        nDocumentoCaja.tipoOperacion = "9920" ' INGRESO DE DINERO A CAJA
        nDocumentoCaja.usuarioActualizacion = "Jiuni"
        nDocumentoCaja.fechaActualizacion = DateTime.Now

        objCaja = New documentoCaja
        objCaja.tipoOperacion = StatusTipoOperacion.SALIDA_DINERO_POR_NOTA_CREDITO
        objCaja.idDocumento = 0
        objCaja.numeroDoc = txtSerie.Text & "-" & txtNumero.Text
        objCaja.idEmpresa = Gempresas.IdEmpresaRuc
        objCaja.idEstablecimiento = ef.idEstablecimiento
        objCaja.fechaProceso = txtFecha.Value
        objCaja.fechaCobro = txtFecha.Value
        objCaja.tipoMovimiento = TIPO_COMPRA.PAGO.PAGADO
        objCaja.IdProveedor = txtCliente.Tag
        objCaja.codigoLibro = "9920"
        objCaja.codigoProveedor = CInt(txtCliente.Tag)
        objCaja.idPersonal = CInt(txtCliente.Tag)
        objCaja.tipoDocPago = "07"
        objCaja.formapago = "109"
        objCaja.periodo = lblPerido.Text
        objCaja.NumeroDocumento = Nothing ' IIf(txtNumCaja.Text.Trim.Length > 0, txtNumCaja.Text, Nothing)
        objCaja.moneda = If(txtdesmoneda.Text = "NACIONAL", "1", "2") ' txtCodMoneda.Text ' IIf(cboMoneda.Text = "MONEDA NACIONAL (SOLES)", "SOL", "USD")
        objCaja.tipoCambio = CDec(txtTipoCambio.Text)
        objCaja.movimientoCaja = TIPO_COMPRA.NOTA_CREDITO_ELECTRONICA
        objCaja.estado = "1"
        objCaja.glosa = txtGlosa.Text.Trim
        objCaja.entregado = "SI"
        objCaja.idCajaUsuario = GFichaUsuarios.IdCajaUsuario
        'objCaja.entidadFinanciera = ef.idestado
        objCaja.entidadFinanciera = cbocajaPago.SelectedValue
        objCaja.NombreEntidad = cbocajaPago.Text
        objCaja.usuarioModificacion = usuario.IDUsuario
        objCaja.fechaModificacion = DateTime.Now
        nDocumentoCaja.documentoCaja = objCaja

        '   For Each i As DataGridViewRow In dgvNuevoDoc.Rows
        For Each i In listaCaja

            sumMN += CDec(i.importeMN)
            sumME += CDec(i.importeME)

            objCajaDetalle = New documentoCajaDetalle
            objCajaDetalle.idDocumento = 0
            objCajaDetalle.documentoAfectadodetalle = i.idPadreDTVenta
            objCajaDetalle.fecha = txtFecha.Value
            objCajaDetalle.idItem = i.idItem
            objCajaDetalle.DetalleItem = i.DetalleItem
            objCajaDetalle.montoSoles = i.ImporteDevolucionmn
            objCajaDetalle.montoUsd = i.ImporteDevolucionme
            objCajaDetalle.entregado = "SI"
            objCajaDetalle.documentoAfectado = 0 ' lblIdDoc.Text
            objCajaDetalle.usuarioModificacion = usuario.IDUsuario
            objCajaDetalle.fechaModificacion = DateTime.Now
            ListaDetalle.Add(objCajaDetalle)
        Next

        nDocumentoCaja.documentoCaja.montoSoles = sumMN
        nDocumentoCaja.documentoCaja.montoUsd = sumME
        nDocumentoCaja.documentoCaja.documentoCajaDetalle = ListaDetalle


        'ASIENTO CONTABLE

        asiento = New asiento
        With asiento
            .periodo = lblPerido.Text
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCostos = GEstableciento.IdEstablecimiento
            .idEntidad = txtCliente.Tag
            .nombreEntidad = txtCliente.Text
            .tipoEntidad = "CL"
            .fechaProceso = txtFecha.Value
            .codigoLibro = "14"
            .tipo = "D"
            .tipoAsiento = "AS-NTC"
            .importeMN = sumMN ' TotalesXcanbeceras.importeDevmn
            .importeME = sumME 'TotalesXcanbeceras.importeDevme
            .glosa = txtGlosa.Text.Trim
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With

        nMovimiento = New movimiento
        nMovimiento.cuenta = "46"
        nMovimiento.descripcion = txtCliente.Text
        nMovimiento.tipo = "D"
        nMovimiento.monto = sumMN ' TotalesXcanbeceras.importeDevmn
        nMovimiento.montoUSD = sumME 'TotalesXcanbeceras.importeDevme
        nMovimiento.usuarioActualizacion = "Jiuni"
        nMovimiento.fechaActualizacion = DateTime.Now
        asiento.movimiento.Add(nMovimiento)

        nMovimiento = New movimiento
        nMovimiento.cuenta = ef.cuenta
        nMovimiento.descripcion = ef.descripcion
        nMovimiento.tipo = "H"
        nMovimiento.monto = sumMN ' TotalesXcanbeceras.importeDevmn
        nMovimiento.montoUSD = sumME ' TotalesXcanbeceras.importeDevme
        nMovimiento.usuarioActualizacion = "Jiuni"
        nMovimiento.fechaActualizacion = DateTime.Now
        asiento.movimiento.Add(nMovimiento)

        ListaAsientonTransito.Add(asiento)

        Return nDocumentoCaja
    End Function

    Sub AsientoNotaCreditoExcedente(ListaExistencias As List(Of documentoventaAbarrotesDet))
        Dim nMovimiento As New movimiento
        Dim nAsiento As New asiento

        Dim SumaCliente = Aggregate n In ListaExistencias
                  Into totalMN = Sum(n.importeMN),
                  totalME = Sum(n.importeME)

        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.periodo = lblPerido.Text
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = txtCliente.Tag
        nAsiento.nombreEntidad = txtCliente.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.codigoLibro = "14"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_NotaCredito
        nAsiento.importeMN = SumaCliente.totalMN.GetValueOrDefault
        nAsiento.importeME = SumaCliente.totalME.GetValueOrDefault
        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now
        ListaAsientonTransito.Add(nAsiento)


        For Each i In ListaExistencias
            'MV_Item_Transito(i.nombreItem, i.salidaCostoMN, i.salidaCostoME, i.tipoExistencia)
            nAsiento.movimiento.Add(AS_Default("70111", i.montokardex, i.montokardexUS, i.tipoExistencia, i.nombreItem))
        Next
        Dim SumaIGV = Aggregate n In ListaExistencias
           Into IGVmn = Sum(n.montoIgv),
           IGVme = Sum(n.montoIgvUS)

        nAsiento.movimiento.Add(AS_IGV(SumaIGV.IGVmn.GetValueOrDefault, SumaIGV.IGVme.GetValueOrDefault))
        nAsiento.movimiento.Add(Ad_Cli_Excedente(SumaCliente.totalMN.GetValueOrDefault, SumaCliente.totalME.GetValueOrDefault))

    End Sub

    Sub AsientoNotaCreditoExcedenteServicios(ListaServicios As List(Of documentoventaAbarrotesDet))
        Dim nMovimiento As New movimiento
        Dim nAsiento As New asiento

        Dim SumaCliente = Aggregate n In ListaServicios
                     Into totalMN = Sum(n.importeMN),
                     totalME = Sum(n.importeME)

        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.periodo = lblPerido.Text
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = txtCliente.Tag
        nAsiento.nombreEntidad = txtCliente.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.codigoLibro = "14"
        nAsiento.importeMN = SumaCliente.totalMN.GetValueOrDefault
        nAsiento.importeME = SumaCliente.totalME.GetValueOrDefault
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_NotaCredito

        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now
        ListaAsientonTransito.Add(nAsiento)

        For Each i In ListaServicios
            nAsiento.movimiento.Add(AS_Default(i.idItem, i.montokardex, i.montokardexUS, i.tipoExistencia, i.nombreItem))
        Next
        Dim SumaIGV = Aggregate n In ListaServicios
               Into IGVmn = Sum(n.montoIgv),
               IGVme = Sum(n.montoIgvUS)

        nAsiento.movimiento.Add(AS_IGV(SumaIGV.IGVmn.GetValueOrDefault, SumaIGV.IGVme.GetValueOrDefault))
        nAsiento.movimiento.Add(Ad_Cli_Excedente(SumaCliente.totalMN.GetValueOrDefault, SumaCliente.totalME.GetValueOrDefault))
    End Sub

    Public Function AS_Default(srtCuentaContable As String, cMonto As Decimal, cMontoUS As Decimal, tipoex As String, DescItem As String) As movimiento
        Dim nMovimiento As New movimiento
        Dim cuentaMascaraSA As New cuentaMascaraSA
        nMovimiento = New movimiento
        nMovimiento.cuenta = srtCuentaContable
        nMovimiento.descripcion = DescItem
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
        nMovimiento.monto = cMonto
        nMovimiento.montoUSD = cMontoUS
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = "Jiuni"

        Return nMovimiento
    End Function

    Function ComprobanteCajaSaldo(listaCaja As List(Of documentoventaAbarrotesDet)) As documento
        Dim efSA As New EstadosFinancierosSA
        Dim ef As New estadosFinancieros
        Dim nDocumentoCaja As New documento()
        Dim objCaja As New documentoCaja
        Dim objCajaDetalle As New documentoCajaDetalle
        Dim ListaDetalle As New List(Of documentoCajaDetalle)
        Dim asiento As New asiento
        Dim nMovimiento As New movimiento

        Dim sumMN As Decimal = 0
        Dim sumME As Decimal = 0


        ef = efSA.GetUbicar_estadosFinancierosPorID(GFichaUsuarios.IdCajaDestino)
        nDocumentoCaja = New documento()
        nDocumentoCaja.idDocumento = 0
        nDocumentoCaja.idEmpresa = Gempresas.IdEmpresaRuc
        nDocumentoCaja.idCentroCosto = ef.idEstablecimiento  'GEstableciento.IdEstablecimiento
        If IsNothing(GProyectos) Then
        Else
            nDocumentoCaja.idProyecto = GProyectos.IdProyectoActividad
        End If
        nDocumentoCaja.tipoDoc = "109"
        nDocumentoCaja.fechaProceso = txtFecha.Value
        nDocumentoCaja.nroDoc = Nothing ' IIf(rbEfectivo.Checked = True, Nothing, txtNumCaja.Text.Trim)
        nDocumentoCaja.idOrden = Nothing
        nDocumentoCaja.tipoOperacion = "9908" ' INGRESO DE DINERO A CAJA
        nDocumentoCaja.usuarioActualizacion = "Jiuni"
        nDocumentoCaja.fechaActualizacion = DateTime.Now

        objCaja = New documentoCaja
        objCaja.idDocumento = 0
        objCaja.idEmpresa = Gempresas.IdEmpresaRuc
        objCaja.idEstablecimiento = ef.idEstablecimiento
        objCaja.fechaProceso = txtFecha.Value
        objCaja.fechaCobro = txtFecha.Value
        objCaja.tipoMovimiento = TIPO_VENTA.PAGO.COBRADO
        objCaja.IdProveedor = txtCliente.Tag
        objCaja.codigoLibro = "9908"
        objCaja.codigoProveedor = CInt(txtCliente.Tag)
        objCaja.TipoDocumentoPago = "109"
        objCaja.tipoDocPago = "109"
        objCaja.periodo = lblPerido.Text
        objCaja.NumeroDocumento = Nothing ' IIf(txtNumCaja.Text.Trim.Length > 0, txtNumCaja.Text, Nothing)
        objCaja.moneda = "1" ' txtCodMoneda.Text ' IIf(cboMoneda.Text = "MONEDA NACIONAL (SOLES)", "SOL", "USD")
        objCaja.tipoCambio = CDec(txtTipoCambio.Text)


        objCaja.glosa = txtGlosa.Text.Trim
        objCaja.entregado = "SI"
        objCaja.entidadFinanciera = ef.idestado
        objCaja.usuarioModificacion = usuario.IDUsuario
        objCaja.fechaModificacion = DateTime.Now
        nDocumentoCaja.documentoCaja = objCaja

        '   For Each i As DataGridViewRow In dgvNuevoDoc.Rows
        For Each i In listaCaja
            sumMN += CDec(i.saldoVentaMN)
            sumME += CDec(i.saldoVentaME)
            objCajaDetalle = New documentoCajaDetalle
            objCajaDetalle.idDocumento = 0
            objCajaDetalle.documentoAfectadodetalle = i.idPadreDTVenta
            objCajaDetalle.fecha = txtFecha.Value
            objCajaDetalle.idItem = i.idItem
            objCajaDetalle.DetalleItem = i.DetalleItem
            objCajaDetalle.montoSoles = i.saldoVentaMN
            objCajaDetalle.montoUsd = i.saldoVentaME
            objCajaDetalle.entregado = "SI"
            objCajaDetalle.documentoAfectado = 0 ' lblIdDoc.Text
            objCajaDetalle.usuarioModificacion = usuario.IDUsuario
            objCajaDetalle.fechaModificacion = DateTime.Now
            ListaDetalle.Add(objCajaDetalle)
        Next
        nDocumentoCaja.documentoCaja.montoSoles = sumMN
        nDocumentoCaja.documentoCaja.montoUsd = sumME

        nDocumentoCaja.documentoCaja.documentoCajaDetalle = ListaDetalle


        'ASIENTO CONTABLE

        asiento = New asiento
        With asiento
            .periodo = lblPerido.Text
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCostos = GEstableciento.IdEstablecimiento
            .idEntidad = txtCliente.Tag
            .nombreEntidad = txtCliente.Text
            .tipoEntidad = "CL"
            .fechaProceso = txtFecha.Value
            .codigoLibro = "14"
            .tipo = "D"
            .tipoAsiento = "AS-NTC"
            .importeMN = sumMN ' TotalesXcanbeceras.SaldoVentaMN
            .importeME = sumME ' TotalesXcanbeceras.SaldoVentaME
            .glosa = txtGlosa.Text.Trim
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With

        nMovimiento = New movimiento
        nMovimiento.cuenta = "1212"
        nMovimiento.descripcion = txtCliente.Text
        nMovimiento.tipo = "D"
        nMovimiento.monto = sumMN ' TotalesXcanbeceras.SaldoVentaMN
        nMovimiento.montoUSD = sumME ' TotalesXcanbeceras.SaldoVentaME
        nMovimiento.usuarioActualizacion = "Jiuni"
        nMovimiento.fechaActualizacion = DateTime.Now
        asiento.movimiento.Add(nMovimiento)


        nMovimiento = New movimiento
        nMovimiento.cuenta = "46"
        nMovimiento.descripcion = txtCliente.Text
        nMovimiento.tipo = "H"
        nMovimiento.monto = sumMN ' TotalesXcanbeceras.SaldoVentaMN
        nMovimiento.montoUSD = sumME 'TotalesXcanbeceras.SaldoVentaME
        nMovimiento.usuarioActualizacion = "Jiuni"
        nMovimiento.fechaActualizacion = DateTime.Now
        asiento.movimiento.Add(nMovimiento)

        ListaAsientonTransito.Add(asiento)

        Return nDocumentoCaja
    End Function

    Sub AsientoNotaCreditoExcedenteMaspagoDeudaPendiente(ListaExistencias As List(Of documentoventaAbarrotesDet))
        Dim nMovimiento As New movimiento
        Dim nAsiento As New asiento

        Dim SumaCliente = Aggregate n In ListaExistencias
                  Into totalMN = Sum(n.importeMN),
                  totalME = Sum(n.importeME),
                  devo = Sum(n.ImporteDevolucionmn),
                  devme = Sum(n.ImporteDevolucionme)

        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.periodo = lblPerido.Text
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = txtCliente.Tag
        nAsiento.nombreEntidad = txtCliente.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.codigoLibro = "14"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_NotaCredito
        nAsiento.importeMN = SumaCliente.totalMN.GetValueOrDefault
        nAsiento.importeME = SumaCliente.totalME.GetValueOrDefault
        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now
        ListaAsientonTransito.Add(nAsiento)


        For Each i In ListaExistencias
            'MV_Item_Transito(i.nombreItem, i.salidaCostoMN, i.salidaCostoME, i.tipoExistencia)
            nAsiento.movimiento.Add(AS_Default("70111", i.montokardex, i.montokardexUS, i.tipoExistencia, i.nombreItem))
        Next
        Dim SumaIGV = Aggregate n In ListaExistencias
           Into IGVmn = Sum(n.montoIgv),
           IGVme = Sum(n.montoIgvUS)

        nAsiento.movimiento.Add(AS_IGV(SumaIGV.IGVmn.GetValueOrDefault, SumaIGV.IGVme.GetValueOrDefault))
        nAsiento.movimiento.Add(Ad_Cli_Excedente(SumaCliente.devo.GetValueOrDefault, SumaCliente.devme.GetValueOrDefault))
        nAsiento.movimiento.Add(AS_Proveedor(SumaCliente.totalMN.GetValueOrDefault - SumaCliente.devo.GetValueOrDefault, SumaCliente.totalME.GetValueOrDefault - SumaCliente.devme.GetValueOrDefault))
    End Sub

    Sub AsientoNotaCreditoExcedenteServiciosMasPagoPendiente(ListaServicios As List(Of documentoventaAbarrotesDet))
        Dim nMovimiento As New movimiento
        Dim nAsiento As New asiento

        Dim SumaCliente = Aggregate n In ListaServicios
                     Into totalMN = Sum(n.importeMN),
                     totalME = Sum(n.importeME),
                  devo = Sum(n.ImporteDevolucionmn),
                  devme = Sum(n.ImporteDevolucionme)

        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.periodo = lblPerido.Text
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = txtCliente.Tag
        nAsiento.nombreEntidad = txtCliente.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.codigoLibro = "14"
        nAsiento.importeMN = SumaCliente.totalMN.GetValueOrDefault
        nAsiento.importeME = SumaCliente.totalME.GetValueOrDefault
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_NotaCredito

        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now
        ListaAsientonTransito.Add(nAsiento)

        For Each i In ListaServicios
            nAsiento.movimiento.Add(AS_Default(i.idItem, i.montokardex, i.montokardexUS, i.tipoExistencia, i.nombreItem))
        Next
        Dim SumaIGV = Aggregate n In ListaServicios
               Into IGVmn = Sum(n.montoIgv),
               IGVme = Sum(n.montoIgvUS)

        'nAsiento.movimiento.Add(AS_IGV(SumaIGV.IGVmn.GetValueOrDefault, SumaIGV.IGVme.GetValueOrDefault))
        'nAsiento.movimiento.Add(Ad_Cli_Excedente(SumaCliente.totalMN.GetValueOrDefault, SumaCliente.totalME.GetValueOrDefault))
        nAsiento.movimiento.Add(AS_IGV(SumaIGV.IGVmn.GetValueOrDefault, SumaIGV.IGVme.GetValueOrDefault))
        nAsiento.movimiento.Add(Ad_Cli_Excedente(SumaCliente.devo.GetValueOrDefault, SumaCliente.devme.GetValueOrDefault))
        nAsiento.movimiento.Add(AS_Proveedor(SumaCliente.totalMN.GetValueOrDefault - SumaCliente.devo.GetValueOrDefault, SumaCliente.totalME.GetValueOrDefault - SumaCliente.devme.GetValueOrDefault))
    End Sub

    Public Function AS_Proveedor(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento
        nMovimiento.cuenta = "1213"
        nMovimiento.descripcion = txtCliente.Text
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
        nMovimiento.monto = cMonto
        nMovimiento.montoUSD = cMontoUS
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = "Jiuni"

        Return nMovimiento
    End Function

    Public Function Ad_Cli_Excedente(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento
        nMovimiento.cuenta = "461"
        nMovimiento.descripcion = txtCliente.Text
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
        nMovimiento.monto = cMonto
        nMovimiento.montoUSD = cMontoUS
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = "Jiuni"

        Return nMovimiento
    End Function

    Public Function AS_IGV(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .cuenta = "40111",
              .descripcion = "I.G.V.",
              .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = "Jiuni"}

        Return nMovimiento
    End Function

    Sub AsientoNotaCreditoNormal(ListaExistencias As List(Of documentoventaAbarrotesDet))
        Dim nMovimiento As New movimiento
        Dim nAsiento As New asiento


        Dim SumaCliente = Aggregate n In ListaExistencias
           Into totalMN = Sum(n.importeMN),
           totalME = Sum(n.importeME)

        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.periodo = lblPerido.Text
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = txtCliente.Tag
        nAsiento.nombreEntidad = txtCliente.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.codigoLibro = "14"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_NotaCredito
        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.importeMN = SumaCliente.totalMN.GetValueOrDefault
        nAsiento.importeME = SumaCliente.totalME.GetValueOrDefault
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now
        ListaAsientonTransito.Add(nAsiento)


        For Each i In ListaExistencias
            nAsiento.movimiento.Add(AS_Default("70111", i.montokardex, i.montokardexUS, i.tipoExistencia, i.nombreItem))
            'MV_Item_Transito(i.nombreItem, i.salidaCostoMN, i.salidaCostoME, i.tipoExistencia)
        Next

        Dim SumaIGV = Aggregate n In ListaExistencias
                  Into IGVmn = Sum(n.montoIgv),
                  IGVme = Sum(n.montoIgvUS)

        nAsiento.movimiento.Add(AS_IGV(SumaIGV.IGVmn.GetValueOrDefault, SumaIGV.IGVme.GetValueOrDefault))
        nAsiento.movimiento.Add(AS_Proveedor(SumaCliente.totalMN.GetValueOrDefault, SumaCliente.totalME.GetValueOrDefault))

    End Sub

    Sub GuiaRemision(objDocumentoCompra As documento, Lista As List(Of documentoventaAbarrotesDet))
        Dim guiaRemisionBE As New documentoGuia
        Dim documentoguiaDetalle As New documentoguiaDetalle
        Dim ListaGuiaDetalle As New List(Of documentoguiaDetalle)
        'REGISTRANDO LA GUIA DE REMISION
        With guiaRemisionBE
            .idDocumento = 0
            .codigoLibro = "14"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = txtFecha.Value
            .periodo = lblPerido.Text
            .tipoDoc = "99"
            .idEntidad = CInt(txtCliente.Tag)
            .monedaDoc = IIf(txtMon.Text = 1, "1", "2")
            .tasaIgv = CDec(txtIva.Text)
            .tipoCambio = CDec(txtTipoCambio.Text)
            .importeMN = CDec(txtTotalPagar.Text)  'TotalesXcanbeceras.TotalMN
            .importeME = 0 'TotalesXcanbeceras.TotalMN
            .glosa = txtGlosa.Text.Trim
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With
        objDocumentoCompra.documentoGuia = guiaRemisionBE

        For Each r As documentoventaAbarrotesDet In Lista

            If r.tipoExistencia <> "GS" Then
                'If r.GetValue("almacen") <> idAlmacenVirtual Then
                documentoguiaDetalle = New documentoguiaDetalle
                If txtSerieGuia.Text.Trim.Length > 0 Then
                    'objDocumentoCompra.documentoGuia.serie = String.Format("{0:00000}", Convert.ToInt32(txtSerieGuia.Text))
                    objDocumentoCompra.documentoGuia.serie = txtSerieGuia.Text
                Else
                    Throw New Exception("Ingrese número de serie de la guía!")
                    'MessageBoxAdv.Show("Ingrese número de serie de la guía!")
                    'Exit Sub
                End If
                If txtNumeroGuia.Text.Trim.Length > 0 Then
                    objDocumentoCompra.documentoGuia.numeroDoc = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumeroGuia.Text))
                Else
                    Throw New Exception("Ingrese número de la guía!")
                    'MessageBoxAdv.Show("Ingrese número de la guía!")
                    'Exit Sub
                End If
                documentoguiaDetalle.idDocumento = 0
                documentoguiaDetalle.idItem = r.idItem
                documentoguiaDetalle.descripcionItem = r.nombreItem
                documentoguiaDetalle.destino = r.destino
                documentoguiaDetalle.unidadMedida = Nothing  'r.GetValue("um")
                documentoguiaDetalle.cantidad = r.monto1
                documentoguiaDetalle.precioUnitario = r.precioUnitario
                documentoguiaDetalle.precioUnitarioUS = r.precioUnitarioUS
                documentoguiaDetalle.importeMN = r.importeMN
                documentoguiaDetalle.importeME = r.importeME
                documentoguiaDetalle.almacenRef = r.idAlmacenOrigen
                documentoguiaDetalle.usuarioModificacion = "Jiuni"
                documentoguiaDetalle.fechaModificacion = DateTime.Now
                ListaGuiaDetalle.Add(documentoguiaDetalle)
            End If

        Next
        objDocumentoCompra.documentoGuia.documentoguiaDetalle = ListaGuiaDetalle
    End Sub

    Sub AsientoNotaCreditoNormalServicio(ListaServicios As List(Of documentoventaAbarrotesDet))

        Dim nMovimiento As New movimiento
        Dim nAsiento As New asiento

        Dim SumaCliente = Aggregate n In ListaServicios
             Into totalMN = Sum(n.importeMN),
             totalME = Sum(n.importeME)

        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.periodo = lblPerido.Text
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = txtCliente.Tag
        nAsiento.nombreEntidad = txtCliente.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.codigoLibro = "14"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_NotaCredito
        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.importeMN = SumaCliente.totalMN.GetValueOrDefault
        nAsiento.importeME = SumaCliente.totalME.GetValueOrDefault
        nAsiento.usuarioActualizacion = "jiuni"
        nAsiento.fechaActualizacion = DateTime.Now
        ListaAsientonTransito.Add(nAsiento)

        For Each i In ListaServicios
            nAsiento.movimiento.Add(AS_Default(i.idItem, i.montokardex, i.montokardexUS, i.tipoExistencia, i.nombreItem))
        Next

        Dim SumaIGV = Aggregate n In ListaServicios
                     Into IGVmn = Sum(n.montoIgv),
                     IGVme = Sum(n.montoIgvUS)

        nAsiento.movimiento.Add(AS_IGV(SumaIGV.IGVmn.GetValueOrDefault, SumaIGV.IGVme.GetValueOrDefault))
        nAsiento.movimiento.Add(AS_Proveedor(SumaCliente.totalMN.GetValueOrDefault, SumaCliente.totalME.GetValueOrDefault))

    End Sub

    Sub Grabar()
        Dim CompraSA As New documentoVentaAbarrotesSA
        Dim ndocumento As New documento()
        Dim nDocumentoExce As New documento
        Dim nDocumentoCompra As New documentoventaAbarrotes()
        Dim objDocumentoCompraDet As New documentoventaAbarrotesDet
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad
        Dim DocCaja As New documento

        Dim asientoSA As New AsientoSA
        ' Dim ListaAsiento As New List(Of asiento)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento
        Dim almacenSA As New almacenSA
        Dim ListaDetalle As New List(Of documentoventaAbarrotesDet)
        Dim ListaTotales As New List(Of totalesAlmacen)
        ''''''''''' LIMPIANDO VARIABLES---------------------

        ListaAsientonTransito = New List(Of asiento)

        With ndocumento
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            If Not IsNothing(GProyectos) Then
                .idProyecto = GProyectos.IdProyectoActividad
            End If
            .tipoDoc = "07"
            .fechaProceso = txtFecha.Value
            .nroDoc = txtSerie.Text & "-" & txtNumero.Text.Trim
            .idOrden = Nothing ' Me.IdOrden
            .moneda = IIf(txtMon.Text = 1, "1", "2")

            If chIdentidad.Checked = True Then
                .idEntidad = 0
                .entidad = "SIN IDENTIDAD"
                .tipoEntidad = "VR"
                .nrodocEntidad = "0"
            Else
                .idEntidad = Val(txtCliente.Tag)
                .entidad = txtCliente.Text
                .tipoEntidad = TIPO_ENTIDAD.CLIENTE
                .nrodocEntidad = txtRuc.Text
            End If

            .tipoOperacion = "07"
            .usuarioActualizacion = "NN"
            .fechaActualizacion = DateTime.Now

        End With

        With nDocumentoCompra
            .tipoOperacion = "07"
            .idPadre = IdCompraOrigen
            .IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
            .codigoLibro = "14"
            .notaCredito = cboTipoNota.SelectedValue
            .tipoDocumento = "07"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento
            .fechaDoc = txtFecha.Value
            .fechaConfirmacion = txtFecha.Value
            .fechaPeriodo = lblPerido.Text
            .serie = txtSerie.Text.Trim
            .serieVenta = txtSerie.Text.Trim
            .numeroDocNormal = txtNumero.Text.Trim
            .numeroDoc = txtNumero.Text.Trim
            .numeroVenta = txtNumero.Text.Trim
            If chIdentidad.Checked = True Then
                .idCliente = 0
                .nombrePedido = "SIN IDENTIDAD"
                .NombreEntidad = "SIN IDENTIDAD"
            Else
                .idCliente = CInt(txtCliente.Tag)
                .nombrePedido = txtCliente.Text
                .NombreEntidad = txtCliente.Text
            End If

            .moneda = IIf(txtMon.Text = 1, "1", "2")
            .tasaIgv = CDec(txtIva.Text)    ' IIf(IsNothing(nudIgv.Value) Or String.IsNullOrEmpty(nudIgv.Value) Or String.IsNullOrWhiteSpace(nudIgv.Value), Nothing, Trim(nudIgv.Value))
            .tipoCambio = CDec(txtTipoCambio.Text)


            '****************** DESTINO EN SOLES ************************************************************************
            .bi01 = CDec(lblmontogravado.Text) 'TotalesXcanbeceras.base1
            .bi02 = CDec(lblexonerado.Text) 'TotalesXcanbeceras.base2

            .igv01 = CDec(txtTotalIva.Text) 'TotalesXcanbeceras.MontoIgv1
            .igv02 = 0 'TotalesXcanbeceras.MontoIgv2


            '****************** DESTINO EN DOLARES ************************************************************************
            .bi01us = 0 'TotalesXcanbeceras.base1me
            .bi02us = 0 'TotalesXcanbeceras.base2me

            .igv01us = 0 'TotalesXcanbeceras.MontoIgv1me
            .igv02us = 0 'TotalesXcanbeceras.MontoIgv2me

            '****************************************************************************************************************
            .ImporteNacional = CDec(txtTotalPagar.Text) 'TotalesXcanbeceras.TotalMN
            .ImporteExtranjero = 0 'TotalesXcanbeceras.TotalME
            .tipoVenta = TIPO_COMPRA.NOTA_CREDITO_ELECTRONICA
            .glosa = txtGlosa.Text.Trim
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
            .sustentado = "01" 'strTipoNota
            ' .aprobado = "N"

            'If cboDevolucion.Visible = True Then
            '    If cboDevolucion.Text = "PAGADO" Then
            '        .EstadoPagoDevolucion = TIPO_VENTA.PAGO.COBRADO
            '    Else
            '        .EstadoPagoDevolucion = TIPO_VENTA.PAGO.PENDIENTE_PAGO
            '    End If
            'Else
            '    .EstadoPagoDevolucion = Nothing
            'End If

            'If cboDinero.Text = "DEVOLUCION DINERO" Then
            '    .EstadoPagoDevolucion = TIPO_VENTA.PAGO.COBRADO
            'ElseIf cboDinero.Text = "RECLAMACION/OTROS" Then
            '    .EstadoPagoDevolucion = TIPO_VENTA.PAGO.PENDIENTE_PAGO
            'End If

            If txtBonifica.Text > 0 Then
                .EstadoPagoDevolucion = TIPO_VENTA.PAGO.COBRADO

                Dim iva As Decimal = TmpIGV / 100
                Dim tot As Decimal = txtBonifica.Text
                Dim igv As Decimal = Math.Round(CDec(CalculoBaseImponible(tot, iva + 1)), 2)
                Dim bi As Decimal = tot - igv

                .IgvDevMN = igv
                .BiDevMN = bi
            Else
                .IgvDevMN = 0
                .BiDevMN = 0

            End If


            .ImporteDevMN = CDec(txtBonifica.Text)   'TotalesXcanbeceras.importeDevmn
            .Bi2DevMN = CDec(lblexonerado.Text)




            .ImporteDevME = 0 'TotalesXcanbeceras.importeDevme
            .SaldoVentaMN = 0 'TotalesXcanbeceras.SaldoVentaMN
            .SaldoVentaME = 0 'TotalesXcanbeceras.SaldoVentaME
        End With

        ndocumento.documentoventaAbarrotes = nDocumentoCompra


        For Each r As Record In dgvMov.Table.Records

            objDocumentoCompraDet = New documentoventaAbarrotesDet
            'objDocumentoCompraDet.saldoVentaMN = r.GetValue("importeMN")
            ' objDocumentoCompraDet.saldoVentaME = r.GetValue("importeME")
            'Select Case r.GetValue("estadoPago")
            '    Case "Pagado"
            '        objDocumentoCompraDet.ImporteDevolucionmn = r.GetValue("ValDevmn")
            '        objDocumentoCompraDet.ImporteDevolucionme = r.GetValue("ValDevme")

            '    Case Else
            '        objDocumentoCompraDet.ImporteDevolucionmn = r.GetValue("ValDevmn")
            '        objDocumentoCompraDet.ImporteDevolucionme = r.GetValue("ValDevme")
            'End Select
            Select Case ndocumento.documentoventaAbarrotes.notaCredito
                Case "01", "02", "06"
                    objDocumentoCompraDet.TipoOperacion = "9916"

                    If Not CDec(r.GetValue("Devtotal")) > 0 Then
                        lblEstado.Text = "No hay Montos por devolver o disminuir!"
                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                        'Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc.Rows(i.Index).Cells(7)
                        'Me.dgvNuevoDoc.BeginEdit(True)
                        Exit Sub
                    End If

                Case "05"
                    objDocumentoCompraDet.TipoOperacion = "9914"

                    If Not CDec(r.GetValue("Devtotal")) > 0 Then
                        lblEstado.Text = "Ingrese un monto mayor a cero!"
                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                        'Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc.Rows(i.Index).Cells(7)
                        'Me.dgvNuevoDoc.BeginEdit(True)
                        Exit Sub
                    End If

                Case "07"
                    objDocumentoCompraDet.TipoOperacion = "9913"

                    If Not CDec(r.GetValue("Devcantidad")) > 0 Then
                        lblEstado.Text = "Ingrese una cantidad mayor a cero!"
                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                        'Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc.Rows(i.Index).Cells(7)
                        'Me.dgvNuevoDoc.BeginEdit(True)
                        Exit Sub
                    End If

            End Select


            objDocumentoCompraDet.ImporteDevolucionmn = CDec(r.GetValue("DevCobro"))
            objDocumentoCompraDet.ImporteDevolucionme = 0


            If objDocumentoCompraDet.ImporteDevolucionmn > 0 Then
                objDocumentoCompraDet.TieneExcedente = True
            Else
                objDocumentoCompraDet.TieneExcedente = False
            End If

            objDocumentoCompraDet.secuencia = r.GetValue("secuencia")
            objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoCompraDet.IdEstablecimiento = GEstableciento.IdEstablecimiento
            objDocumentoCompraDet.FechaDoc = txtFecha.Value
            objDocumentoCompraDet.unidad1 = r.GetValue("unidad")





            'Select Case cboTipoNota.SelectedValue 'r.GetValue("cboMov")
            '    Case "1" '"DISMINUIR CANTIDAD"
            '        If Not CDec(r.GetValue("canDev")) > 0 Then
            '            lblEstado.Text = "Ingrese una cantidad mayor a cero!"
            '            PanelError.Visible = True
            '            Timer1.Enabled = True
            '            TiempoEjecutar(10)
            '            'Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc.Rows(i.Index).Cells(7)
            '            'Me.dgvNuevoDoc.BeginEdit(True)
            '            Exit Sub
            '        End If

            '        objDocumentoCompraDet.TipoOperacion = "9913"
            '    Case "2" '"DISMINUIR IMPORTE"
            '        If Not CDec(r.GetValue("vcmn")) > 0 Then
            '            lblEstado.Text = "Ingrese un Valor de compra mayor a cero!"
            '            PanelError.Visible = True
            '            Timer1.Enabled = True
            '            TiempoEjecutar(10)
            '            'Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc.Rows(i.Index).Cells(8)
            '            'Me.dgvNuevoDoc.BeginEdit(True)
            '            Exit Sub
            '        End If

            '        objDocumentoCompraDet.TipoOperacion = "9914"
            '    Case "01" '"DISMINUIR CANTIDAD E IMPORTE"
            '        objDocumentoCompraDet.TipoOperacion = "9915"
            '    Case "3", "DEVOLUCION DE EXISTENCIAS" '"DEVOLUCION DE EXISTENCIAS"

            '        Select Case r.GetValue("tipoEx")
            '            Case "GS"

            '                If Not CDec(r.GetValue("Devtotal")) > 0 Then
            '                    lblEstado.Text = "Ingrese un Valor de Venta mayor a cero!"
            '                    PanelError.Visible = True
            '                    Timer1.Enabled = True
            '                    TiempoEjecutar(10)

            '                    Exit Sub
            '                End If

            '            Case Else
            '                If Not CDec(r.GetValue("Devcantidad")) > 0 Then
            '                    lblEstado.Text = "Ingrese una cantidad mayor a cero!"
            '                    PanelError.Visible = True
            '                    Timer1.Enabled = True
            '                    TiempoEjecutar(10)

            '                    Exit Sub
            '                End If

            '                If Not CDec(r.GetValue("Devtotal")) > 0 Then
            '                    lblEstado.Text = "Ingrese un Valor de Venta mayor a cero!"
            '                    PanelError.Visible = True
            '                    Timer1.Enabled = True
            '                    TiempoEjecutar(10)

            '                    Exit Sub
            '                End If
            '        End Select


            '        objDocumentoCompraDet.salidaCostoMN = CDec(r.GetValue("Devcantidad")) * CDec(r.GetValue("preuni"))
            '        objDocumentoCompraDet.salidaCostoME = CDec(r.GetValue("Devcantidad")) * 0

            '        objDocumentoCompraDet.TipoOperacion = "9916"
            '        objDocumentoCompraDet.tipoVenta = "9916"
            '    Case "BONIFICACIONES RECIBIDAS (OPC. Beneficios)"
            '        objDocumentoCompraDet.TipoOperacion = "9917"
            '    Case "BONIFICACIONES RECIBIDAS (OPC. Reduc. costos)"
            '        objDocumentoCompraDet.TipoOperacion = "9918"
            '        objDocumentoCompraDet.tipoVenta = "9918"
            '        'objDocumentoCompraDet.FlagBonif = i.Cells(40).Value()
            'End Select
            objDocumentoCompraDet.destino = r.GetValue("destino")
            objDocumentoCompraDet.idItem = r.GetValue("idItem")
            objDocumentoCompraDet.nombreItem = CStr(r.GetValue("descripcion"))
            objDocumentoCompraDet.DetalleItem = CStr(r.GetValue("descripcion"))
            objDocumentoCompraDet.tipoExistencia = CStr(r.GetValue("tipoEx"))
            objDocumentoCompraDet.monto1 = CDec(r.GetValue("Devcantidad"))
            objDocumentoCompraDet.precioUnitario = CDec(r.GetValue("pu"))  'CDec(r.GetValue("preuni")) 'CDec(r.GetValue("pumn"))
            objDocumentoCompraDet.precioUnitarioUS = 0 'CDec(r.GetValue("pume"))
            objDocumentoCompraDet.importeMN = CDec(r.GetValue("Devtotal"))
            objDocumentoCompraDet.importeME = 0

            If r.GetValue("destino") = "1" Then
                objDocumentoCompraDet.montokardex = CDec(r.GetValue("Devgravado"))

                If CDec(r.GetValue("DevCobro")) > 0 Then

                    Dim iva As Decimal = TmpIGV / 100
                    Dim tot As Decimal = CDec(r.GetValue("DevCobro"))
                    Dim igv As Decimal = Math.Round(CDec(CalculoBaseImponible(tot, iva + 1)), 2)
                    Dim bi As Decimal = tot - igv

                    objDocumentoCompraDet.IgvDevolucionmn = igv
                    objDocumentoCompraDet.BiDevolucionmn = bi


                Else
                    objDocumentoCompraDet.IgvDevolucionmn = 0
                    objDocumentoCompraDet.BiDevolucionmn = 0
                End If


            ElseIf r.GetValue("destino") = "2" Then
                objDocumentoCompraDet.montokardex = CDec(r.GetValue("Devexonerado"))

                If CDec(r.GetValue("DevCobro")) > 0 Then
                    objDocumentoCompraDet.IgvDevolucionmn = 0
                    objDocumentoCompraDet.BiDevolucionmn = CDec(r.GetValue("DevCobro"))
                End If

            End If

            objDocumentoCompraDet.montoIsc = 0 ' CDec(i.Cells(13).Value())
            objDocumentoCompraDet.montoIgv = CDec(r.GetValue("Devigv"))
            objDocumentoCompraDet.otrosTributos = 0 ' CDec(i.Cells(15).Value())
            '**********************************************************************************
            objDocumentoCompraDet.montokardexUS = 0 'CDec(r.GetValue("vcme"))
            objDocumentoCompraDet.montoIscUS = 0 'CDec(i.Cells(17).Value())
            objDocumentoCompraDet.montoIgvUS = 0 'CDec(r.GetValue("ivame"))
            objDocumentoCompraDet.otrosTributosUS = 0 ' CDec(i.Cells(19).Value())

            objDocumentoCompraDet.IdEstablecimiento = GEstableciento.IdEstablecimiento
            objDocumentoCompraDet.idAlmacenOrigen = CInt(r.GetValue("almacenRef"))
            objDocumentoCompraDet.codigoLote = CInt(r.GetValue("lote"))



            objDocumentoCompraDet.preEvento = r.GetValue("estadocobro")  '= "00", Nothing, dgvNuevoDoc.Rows(S).Cells(23).Value())
            '        objDocumentoCompraDet.bonificacion = Nothing


            objDocumentoCompraDet.idPadreDTVenta = CInt(r.GetValue("secuencia"))
            '**********************************************************************************
            objDocumentoCompraDet.usuarioModificacion = usuario.IDUsuario
            objDocumentoCompraDet.fechaModificacion = DateTime.Now
            objDocumentoCompraDet.fechaVcto = Nothing ' IIf(IsNothing(dgvNuevoDoc.Rows(S).Cells(28).Value()), Nothing, CDate(dgvNuevoDoc.Rows(S).Cells(28).Value()))
            objDocumentoCompraDet.Glosa = txtGlosa.Text.Trim
            ' objDocumentoCompraDet.BonificacionMN =

            objDocumentoCompraDet.NumDoc = txtNumeroGuia.Text
            objDocumentoCompraDet.Serie = txtSerieGuia.Text
            objDocumentoCompraDet.TipoDoc = "99"
            'objDocumentoCompraDet.estadoPago = r.GetValue("estadoPago") 'TIPO_VENTA.PAGO.COBRADO
            If r.GetValue("estadocobro") = "Pagado" Then
                objDocumentoCompraDet.estadoPago = TIPO_VENTA.PAGO.COBRADO
            ElseIf r.GetValue("estadocobro") = "Pendiente" Then
                objDocumentoCompraDet.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO
            End If





            ListaDetalle.Add(objDocumentoCompraDet)
            '   End If
        Next


        If cboDinero.Text = "DEVOLUCION DINERO" Then

            Dim ItemDev As List(Of documentoventaAbarrotesDet) = (From n In ListaDetalle
                                                                  Where Fix(n.ImporteDevolucionmn) > 0).ToList

            DocCaja = ComprobanteCaja(ItemDev)

            Dim ListadoExistencias = (From n In ItemDev
                                      Where n.tipoExistencia <> TipoRecurso.SERVICIO).ToList

            If ListadoExistencias.Count > 0 Then
                AsientoNotaCreditoExcedente(ListadoExistencias)
            End If

            Dim ListadoServicios = (From n In ItemDev
                                    Where n.tipoExistencia = TipoRecurso.SERVICIO).ToList
            If ListadoServicios.Count > 0 Then
                AsientoNotaCreditoExcedenteServicios(ListadoServicios)
            End If

        ElseIf cboDinero.Text = "RECLAMACION/OTROS" Then


        End If





        '---------------------------------------------------------------------------------


        'Dim ItemPagados As List(Of documentoventaAbarrotesDet) = (From n In ListaDetalle
        '                                                          Where n.preEvento = "Pagado" _
        '                                                       AndAlso Fix(n.ImporteDevolucionmn) > 0).ToList

        'If ItemPagados.Count > 0 Then
        '    If cboDinero.Text = "DEVOLUCION DINERO" Then 'cboDevolucion.Text = "PAGADO" Then
        '        DocCaja = ComprobanteCaja(ItemPagados) ' DEVOLUCION DEL EXCEDENTE
        '    Else

        '    End If
        '    ''EXISTENCIAS
        '    Dim ListadoExistencias = (From n In ItemPagados
        '                              Where n.tipoExistencia <> TipoRecurso.SERVICIO).ToList

        '    If ListadoExistencias.Count > 0 Then
        '        AsientoNotaCreditoExcedente(ListadoExistencias)
        '    End If
        '    '------------------------------------------------------------------------------------------

        '    ''SERVICIOS
        '    Dim ListadoServicios = (From n In ItemPagados
        '                            Where n.tipoExistencia = TipoRecurso.SERVICIO).ToList

        '    If ListadoServicios.Count > 0 Then
        '        AsientoNotaCreditoExcedenteServicios(ListadoServicios)
        '    End If


        'End If
        '---------------------------------------------------------------------------------------------
        '*****************************************************************************************************
        'Dim itemNoPagados As List(Of documentoventaAbarrotesDet) = (From n In ListaDetalle
        '                                                            Where n.preEvento = "Pendiente").ToList

        Dim documentoSaldo As New documento
        'If itemNoPagados.Count > 0 Then
        '    Dim Opcion1 As List(Of documentoventaAbarrotesDet) = (From i In itemNoPagados
        '                                                          Where i.ImporteDevolucionmn > 0 AndAlso i.saldoVentaMN > 0).ToList

        '    If Opcion1.Count > 0 Then
        '        If cboDinero.Text = "DEVOLUCION DINERO" Then 'cboDevolucion.Text = "PAGADO" Then
        '            DocCaja = ComprobanteCaja(Opcion1) ' DEVOLUCION DEL EXCEDENTE

        '            ''EXISTENCIAS
        '            Dim ListadoExistencias = (From n In Opcion1
        '                                      Where n.tipoExistencia <> TipoRecurso.SERVICIO).ToList

        '            If ListadoExistencias.Count > 0 Then
        '                AsientoNotaCreditoExcedente(ListadoExistencias)
        '            End If
        '            '----------------------------------------------------------------------------------

        '            ''SERVICIOS
        '            Dim ListadoServicios = (From n In Opcion1
        '                                    Where n.tipoExistencia = TipoRecurso.SERVICIO).ToList

        '            If ListadoServicios.Count > 0 Then
        '                AsientoNotaCreditoExcedenteServicios(ListadoServicios)
        '            End If
        '            documentoSaldo = ComprobanteCajaSaldo(Opcion1) ' PAGO DEL SALDO DE LA VENTA

        '        Else

        '            ''EXISTENCIAS
        '            Dim ListadoExistencias = (From n In Opcion1
        '                                      Where n.tipoExistencia <> TipoRecurso.SERVICIO).ToList

        '            If ListadoExistencias.Count > 0 Then
        '                AsientoNotaCreditoExcedenteMaspagoDeudaPendiente(ListadoExistencias)
        '            End If
        '            '----------------------------------------------------------------------------------

        '            ''SERVICIOS
        '            Dim ListadoServicios = (From n In Opcion1
        '                                    Where n.tipoExistencia = TipoRecurso.SERVICIO).ToList

        '            If ListadoServicios.Count > 0 Then
        '                AsientoNotaCreditoExcedenteServiciosMasPagoPendiente(ListadoServicios)
        '            End If
        '            ' documentoSaldo = ComprobanteCajaSaldo(Opcion1) ' PAGO DEL SALDO DE LA VENTA

        '        End If

        '        '    documentoSaldo = ComprobanteCajaSaldo(Opcion1) ' PAGO DEL SALDO DE LA VENTA
        '    End If

        '    'opcion 02

        '    Dim Opcion2 As List(Of documentoventaAbarrotesDet) = (From i In itemNoPagados
        '                                                          Where i.ImporteDevolucionmn = 0 AndAlso i.saldoVentaMN > 0).ToList

        '    If Opcion2.Count > 0 Then
        '        ''EXISTENCIAS
        '        Dim ListadoExistencias = (From n In Opcion2
        '                                  Where n.tipoExistencia <> TipoRecurso.SERVICIO).ToList

        '        If ListadoExistencias.Count > 0 Then
        '            AsientoNotaCreditoNormal(ListadoExistencias)
        '        End If

        '        '-------------------------------------------------------------------------
        '        ''SERVICIOS
        '        Dim ListadoServicios = (From n In Opcion2
        '                                Where n.tipoExistencia = TipoRecurso.SERVICIO).ToList

        '        If ListadoServicios.Count > 0 Then
        '            AsientoNotaCreditoNormalServicio(ListadoServicios)
        '        End If
        '    End If

        'End If

        ndocumento.asiento = ListaAsientonTransito

        Dim listaOp As New List(Of String)
        'listaOp.Add("9913") 'NC-DISMINUIR CANTIDAD
        'listaOp.Add("9916") 'NC-DEVOLUCION DE EXISTENCIAS
        listaOp.Add("01") 'ANULACION TOTAL
        listaOp.Add("02") 'DEVOLUCION TOTAL X RUC MAL
        listaOp.Add("06") 'DEVOLUCION TOTAL 
        listaOp.Add("07") 'DEVOLUCION X ITEM 


        Dim consulta As List(Of documentoventaAbarrotesDet) = (From i In ListaDetalle
                                                               Where listaOp.Contains(i.TipoOperacion)).ToList

        If consulta.Count > 0 Then
            GuiaRemision(ndocumento, consulta)
        End If





        ndocumento.documentoventaAbarrotes.documentoventaAbarrotesDet = ListaDetalle

        Dim xcod As Integer = CompraSA.SaveNotaCreditoFE(ndocumento, DocCaja, documentoSaldo)

        If My.Computer.Network.IsAvailable = True Then
            If My.Computer.Network.Ping("148.102.27.231") Then
                If Gempresas.ubigeo > 0 Then
                    'If ComboComprobante.Text = "FACTURA ELECTRONICA" Then
                    'EnvioPSE(Gempresas.IdEmpresaRuc, impresionTicketDoc.idDocumento)

                    EnviarNotaCreditoElectronico(xcod)

                    'End If
                End If
            Else
                'Alert = New Alert("Envio a Respositorio", alertType.success)
                'Alert.TopMost = True
                'Alert.Show()
            End If
        End If



        'Dim xcod As Integer = CompraSA.SaveVentaNotaCredito2Electronica(ndocumento, DocCaja, documentoSaldo)
        lblEstado.Text = "nota de crédito registrada!"
        Dispose()
    End Sub



    Sub TotalTalesXcolumna()

        Dim Devolucion As Decimal = 0
        Dim gravados As Decimal = 0
        Dim exonerados As Decimal = 0
        Dim inafectas As Decimal = 0
        Dim igv As Decimal = 0
        Dim total As Decimal = 0



        For Each r As Record In dgvMov.Table.Records
            Devolucion += CDec(r.GetValue("DevCobro"))
            gravados += CDec(r.GetValue("Devgravado"))
            exonerados += CDec(r.GetValue("Devexonerado"))
            inafectas += CDec(r.GetValue("Devinafecto"))
            igv += CDec(r.GetValue("Devigv"))
            total += CDec(r.GetValue("Devtotal"))
        Next






        txtBonifica.Text = Devolucion.ToString("N2")
        lblmontogravado.Text = gravados.ToString("N2")
        txtTotalIva.Text = igv.ToString("N2")
        txtinafectas.Text = inafectas.ToString("N2")
        lblexonerado.Text = exonerados.ToString("N2")
        txtTotalPagar.Text = total.ToString("N2")


    End Sub

    'Dim conf As New GConfiguracionModulo

    'Private Sub GetNumeracion(strIdModulo As String, strIDEmpresa As String, intIdEstablecimiento As Integer)
    '    Dim moduloConfiguracionSA As New ModuloConfiguracionSA
    '    Dim moduloConfiguracion As New moduloConfiguracion
    '    moduloConfiguracion = moduloConfiguracionSA.UbicarConfiguracionPorEmpresaModulo(strIdModulo, strIDEmpresa, intIdEstablecimiento)
    '    conf = New GConfiguracionModulo
    '    conf = ConfigurarComprobanteVenta(moduloConfiguracion)
    '    'SetDataSourceNumeracion(moduloConfiguracion)
    'End Sub


    'Public Function ConfigurarComprobanteVenta(moduloConfiguracion As moduloConfiguracion) As GConfiguracionModulo
    '    Dim numeracionSA As New NumeracionBoletaSA
    '    Dim TablaSA As New tablaDetalleSA
    '    Dim almacenSA As New almacenSA
    '    Dim cajaSA As New EstadosFinancierosSA

    '    If Not IsNothing(moduloConfiguracion) Then
    '        With moduloConfiguracion
    '            GConfiguracion2 = New GConfiguracionModulo
    '            GConfiguracion2.IdModulo = .idModulo
    '            GConfiguracion2.TipoConfiguracion = .tipoConfiguracion
    '            Select Case .tipoConfiguracion
    '                Case "P"
    '                    With numeracionSA.GetUbicar_numeracionBoletasPorID(.configComprobante)
    '                        GConfiguracion2.ConfigComprobante = .IdEnumeracion

    '                        GConfiguracion2.TipoComprobante = "07" ' .tipo
    '                        GConfiguracion2.Serie = .serie
    '                        GConfiguracion2.ValorActual = .valorInicial

    '                        txtNumero.Text = .valorInicial + 1



    '                    End With
    '                Case "M"

    '            End Select

    '        End With
    '    Else
    '        lblEstado.Text = "Este módulo no contiene una configuración disponible, intentelo más tarde.!"
    '        Timer1.Enabled = True
    '        'TabCompra.Enabled = False
    '        TiempoEjecutar(5)
    '    End If
    '    Return GConfiguracion2
    'End Function

    Public Sub configuracionModuloV2(strIDEmpresa As String, strIdModulo As String, strNomModulo As String, intIdEstablecimiento As Integer)
        Try

            Dim moduloConfiguracionSA As New ModuloConfiguracionSA
            Dim moduloConfiguracion As New moduloConfiguracion
            Dim numeracionSA As New NumeracionBoletaSA
            Dim TablaSA As New tablaDetalleSA
            Dim almacenSA As New almacenSA
            Dim cajaSA As New EstadosFinancierosSA

            Dim RecuperacionNumeracion = numeracionSA.GetUbicar_numeracionBoletasXUnidadNegocio(New numeracionBoletas With {.empresa = strIDEmpresa, .establecimiento = intIdEstablecimiento, .codigoNumeracion = strIdModulo, .estado = "A"})

            If (Not IsNothing(RecuperacionNumeracion)) Then
                GConfiguracion = New GConfiguracionModulo
                GConfiguracion.ConfigComprobante = CInt(RecuperacionNumeracion.IdEnumeracion)
                GConfiguracion.TipoComprobante = "07" 'RecuperacionNumeracion.tipo

                'GConfiguracion.Serie = RecuperacionNumeracion.serie
                GConfiguracion.ValorActual = CInt(RecuperacionNumeracion.valorInicial)
                txtNumero.Text = CInt(RecuperacionNumeracion.valorInicial) + 1
            Else
                Throw New Exception("Verificar configuración")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub CalculosxCantidad()

        Dim igvDev As Decimal = 0
        Dim exoneradoDev As Decimal = 0
        Dim gravadoDev As Decimal = 0
        Dim totalDev As Decimal = 0
        Dim Dinero As Decimal = 0
        Dim DineroXDevolver As Decimal = 0
        Dim cant As Decimal = 0
        Dim cantDev As Decimal = 0
        Dim preciounit As Decimal = 0

        If Not IsNothing(Me.dgvMov.Table.CurrentRecord) Then
            Dim iva As Decimal = TmpIGV / 100
            Dim destino = Me.dgvMov.Table.CurrentRecord.GetValue("destino")
            'totalDev = Math.Round(CDec(Me.dgvMov.Table.CurrentRecord.GetValue("Devtotal")), 2)
            Dinero = Math.Round(CDec(Me.dgvMov.Table.CurrentRecord.GetValue("montoxdev")), 2)

            preciounit = Math.Round(CDec(Me.dgvMov.Table.CurrentRecord.GetValue("pu")), 2)
            cantDev = Math.Round(CDec(Me.dgvMov.Table.CurrentRecord.GetValue("Devcantidad")), 2)

            totalDev = cantDev * preciounit

            If Dinero > 0 Then
                If Dinero >= totalDev Then
                    DineroXDevolver = totalDev
                ElseIf Dinero <= totalDev Then
                    DineroXDevolver = Dinero
                End If
            End If


            If totalDev > 0 Then
                Select Case destino
                    Case "1"
                        gravadoDev = Math.Round(CDec(CalculoBaseImponible(totalDev, iva + 1)), 2)
                        igvDev = totalDev - gravadoDev

                    Case "2"
                        exoneradoDev = totalDev
                End Select


                Me.dgvMov.Table.CurrentRecord.SetValue("Devgravado", gravadoDev) 'Math.Round(totalMN, 2))
                Me.dgvMov.Table.CurrentRecord.SetValue("Devexonerado", exoneradoDev)
                Me.dgvMov.Table.CurrentRecord.SetValue("Devigv", igvDev)
                Me.dgvMov.Table.CurrentRecord.SetValue("DevCobro", DineroXDevolver)
                Me.dgvMov.Table.CurrentRecord.SetValue("Devtotal", totalDev)
            Else
                Me.dgvMov.Table.CurrentRecord.SetValue("Devgravado", 0) 'Math.Round(totalMN, 2))
                Me.dgvMov.Table.CurrentRecord.SetValue("Devexonerado", 0)
                Me.dgvMov.Table.CurrentRecord.SetValue("Devigv", 0)
                Me.dgvMov.Table.CurrentRecord.SetValue("DevCobro", 0)
                Me.dgvMov.Table.CurrentRecord.SetValue("Devtotal", 0)
            End If
        End If

        TotalTalesXcolumna()
    End Sub

    Sub Calculos(totalDisponible As Decimal)

        Dim igvDev As Decimal = 0
        Dim exoneradoDev As Decimal = 0
        Dim gravadoDev As Decimal = 0
        Dim totalDev As Decimal = 0
        Dim Dinero As Decimal = 0
        Dim DineroXDevolver As Decimal = 0

        Dim AfectarDinero As Decimal = 0

        If Not IsNothing(Me.dgvMov.Table.CurrentRecord) Then
            Dim iva As Decimal = TmpIGV / 100
            Dim destino = Me.dgvMov.Table.CurrentRecord.GetValue("destino")
            totalDev = Math.Round(CDec(Me.dgvMov.Table.CurrentRecord.GetValue("Devtotal")), 2)
            Dinero = Math.Round(CDec(Me.dgvMov.Table.CurrentRecord.GetValue("montoxdev")), 2)

            If Dinero > 0 Then
                AfectarDinero = totalDisponible - Dinero


                If totalDev > AfectarDinero Then

                    'afectar dinero

                    DineroXDevolver = totalDev - AfectarDinero



                    'If Dinero > 0 Then
                    '    If Dinero >= totalDev Then
                    '        DineroXDevolver = totalDev
                    '    ElseIf Dinero <= totalDev Then
                    '        DineroXDevolver = Dinero
                    '    End If
                    'End If

                ElseIf totalDev = AfectarDinero Then


                    DineroXDevolver = 0

                End If
            End If





            If totalDev > 0 Then
                    Select Case destino
                        Case "1"
                            gravadoDev = Math.Round(CDec(CalculoBaseImponible(totalDev, iva + 1)), 2)
                            igvDev = totalDev - gravadoDev

                        Case "2"
                            exoneradoDev = totalDev
                    End Select


                    Me.dgvMov.Table.CurrentRecord.SetValue("Devgravado", gravadoDev) 'Math.Round(totalMN, 2))
                    Me.dgvMov.Table.CurrentRecord.SetValue("Devexonerado", exoneradoDev)
                    Me.dgvMov.Table.CurrentRecord.SetValue("Devigv", igvDev)
                    Me.dgvMov.Table.CurrentRecord.SetValue("DevCobro", DineroXDevolver)
                Else
                    Me.dgvMov.Table.CurrentRecord.SetValue("Devgravado", 0) 'Math.Round(totalMN, 2))
                    Me.dgvMov.Table.CurrentRecord.SetValue("Devexonerado", 0)
                    Me.dgvMov.Table.CurrentRecord.SetValue("Devigv", 0)
                    Me.dgvMov.Table.CurrentRecord.SetValue("DevCobro", 0)
                End If
            End If
            TotalTalesXcolumna()
    End Sub

    Public Sub CombosDev()

        cboTipoNota.DataSource = Nothing

        Dim listaVenta As New List(Of String)
        listaVenta.Add("05")
        listaVenta.Add("07")

        Dim consulta = (From i In ListaOperacion
                        Where listaVenta.Contains(i.codigoDetalle)).ToList



        cboTipoNota.DisplayMember = "descripcion"
        cboTipoNota.ValueMember = "codigoDetalle"
        'cboTipoNota.DataSource = listaTipoExistencia
        cboTipoNota.DataSource = consulta
    End Sub



    Public Sub CargarCombo()

        ListaEstadosFinancieros = New List(Of estadosFinancieros)
        Dim cajaUsuarioSA As New cajaUsuarioSA

        Dim tablaDetalleSA As New tablaDetalleSA
        'Dim listaTipoExistencia = New List(Of tabladetalle)
        'listaTipoExistencia = tablaDetalleSA.GetListaTablaDetalle(24, "1")

        ListaOperacion = tablaDetalleSA.GetListaTablaDetalle(24, "1")

        cboTipoNota.DisplayMember = "descripcion"
        cboTipoNota.ValueMember = "codigoDetalle"
        'cboTipoNota.DataSource = listaTipoExistencia
        cboTipoNota.DataSource = ListaOperacion




        For Each i As cajaUsuario In cajaUsuarioSA.ResumenTransaccionesXusuarioCajaPago(New cajaUsuario With {.idcajaUsuario = GFichaUsuarios.IdCajaUsuario, .idPersona = usuario.IDUsuario})
            ListaEstadosFinancieros.Add(New estadosFinancieros With {.idestado = i.idEntidad, .descripcion = i.NombreEntidad, .tipo = i.Tipo, .codigo = i.moneda})
        Next


        If ListaEstadosFinancieros.Count > 0 Then
            cbocajaPago.DataSource = ListaEstadosFinancieros ' cajaSA.GetCuentasFinancierasByEmpresa(Gempresas.IdEmpresaRuc, "EF")
            cbocajaPago.ValueMember = "idestado"
            cbocajaPago.DisplayMember = "descripcion"
        End If
    End Sub

    Public Sub UbicarDocumento(intIddocumento As Integer)
        Dim detalleSA As New documentoVentaAbarrotesDetSA
        Dim objLista As New DocumentoCajaDetalleSA
        Dim detalle As New documentoventaAbarrotesDet
        Dim compraSA As New documentoVentaAbarrotesSA
        Dim entidadSA As New entidadSA
        Dim dt As New DataTable

        Dim cTotalmn As Decimal = 0
        Dim cTotalme As Decimal = 0
        Dim cTotalActmn As Decimal = 0
        Dim cTotalActme As Decimal = 0
        Dim igvAct As Decimal = 0

        Dim cCreditomn As Decimal = 0
        Dim cCreditome As Decimal = 0
        Dim cDebitomn As Decimal = 0
        Dim cDebitome As Decimal = 0

        Dim cCantidadNC As Decimal = 0
        Dim cCantidadDB As Decimal = 0
        Dim cTotalCantidad As Decimal = 0

        Dim conteoNotas As Decimal = 0

        Try
            With compraSA.GetUbicar_documentoventaAbarrotesPorID(intIddocumento)
                IdCompraOrigen = .idDocumento

                txtMon.Text = .moneda
                If .moneda = "1" Then
                    txtdesmoneda.Text = "NACIONAL"
                ElseIf .moneda = "2" Then
                    txtdesmoneda.Text = "EXTRANJERO"
                End If

                txtSerieRel.Text = .serieVenta
                txtNumRel.Text = .numeroVenta

                If .tipoDocumento = "01" Then
                    txtSerie.Text = "FN01"
                ElseIf .tipoDocumento = "03" Then
                    txtSerie.Text = "BN01"
                End If


                txtTipoCambio.Text = .tipoCambio
                txtTipoCambio.ReadOnly = True
                txtIva.Text = .tasaIgv
                txtImpFacmn.DecimalValue = .ImporteNacional
                txtImpFacme.DecimalValue = .ImporteExtranjero
                txtTipoDoc.Text = .tipoDocumento
                lblTipoDocRel.Text = .tipoDocumento
                Dim tablaSA As New tablaDetalleSA
                txtdescdocu.Text = tablaSA.GetUbicarTablaID(CInt(10), .tipoDocumento).descripcion
                Dim entidad = entidadSA.UbicarEntidadPorID(.idCliente).FirstOrDefault
                If Not IsNothing(entidad) Then
                    txtRuc.Text = entidad.nrodoc
                    txtCliente.Text = entidad.nombreCompleto
                    txtCliente.Tag = entidad.idEntidad
                    txtDocCliente.Text = entidad.tipoDoc
                    chIdentidad.Checked = False
                Else
                    chIdentidad.Checked = True
                End If
            End With

            Dim saldomn As Decimal = 0
            Dim saldome As Decimal = 0
            Dim saldoCantidad As Decimal = 0

            Dim KardexActualizado As Decimal = 0
            Dim KardexActualizadoME As Decimal = 0

            Dim porcentajeIgv = Math.Round(CDec(txtIva.Text) / 100, 2)


            For Each i As documentoCajaDetalle In objLista.ObtenerCuentasPorCobrarPorDetails(intIddocumento)
                detalle = detalleSA.SumaNotasXidPadreItemVentaOpcionDefault(i.secuencia)

                conteoNotas += detalle.importeMN


                saldoCantidad = i.CantidadCompra - detalle.monto1
                cTotalmn = CDec(i.MontoDeudaSoles) - detalle.importeMN - CDec(i.MontoPagadoSoles) + detalle.ImporteDBMN - detalle.montoCompesacion
                cTotalme = CDec(i.MontoDeudaUSD) - detalle.importeME - CDec(i.MontoPagadoUSD) + detalle.ImporteDBME - detalle.montoCompesacionme

                cTotalActmn = CDec(i.MontoDeudaSoles) - detalle.importeMN + detalle.ImporteDBMN
                cTotalActme = CDec(i.MontoDeudaUSD) - detalle.importeME + detalle.ImporteDBME


                KardexActualizado = i.montokardex - detalle.montokardex + detalle.montokardexDB
                KardexActualizadoME = i.montokardexus - detalle.montokardexUS + detalle.montokardexDBUS

                igvAct = i.montoIgv - detalle.montoIgv

                saldomn += cTotalmn
                saldome += cTotalme

                Me.dgvMov.Table.AddNewRecord.SetCurrent()
                Me.dgvMov.Table.AddNewRecord.BeginEdit()
                Me.dgvMov.Table.CurrentRecord.SetValue("secuencia", i.secuencia)
                Me.dgvMov.Table.CurrentRecord.SetValue("destino", i.destino)
                Me.dgvMov.Table.CurrentRecord.SetValue("lote", i.codigoLote)
                Me.dgvMov.Table.CurrentRecord.SetValue("idItem", i.idItem)
                Me.dgvMov.Table.CurrentRecord.SetValue("descripcion", i.DetalleItem)
                Me.dgvMov.Table.CurrentRecord.SetValue("tipoEx", i.TipoExistencia)
                Me.dgvMov.Table.CurrentRecord.SetValue("almacenRef", i.almacenRef)
                Me.dgvMov.Table.CurrentRecord.SetValue("unidad", i.unidad1)
                Me.dgvMov.Table.CurrentRecord.SetValue("preuni", i.precioUnitario)

                Select Case i.TipoExistencia
                    Case "GS"
                        Me.dgvMov.Table.CurrentRecord.SetValue("antcant", 0)
                    Case Else
                        If IsNothing(detalle) Then
                            Me.dgvMov.Table.CurrentRecord.SetValue("antcant", 0)
                        Else

                            Me.dgvMov.Table.CurrentRecord.SetValue("antcant", i.CantidadCompra)
                        End If
                End Select

                If i.destino = 1 Then

                    Me.dgvMov.Table.CurrentRecord.SetValue("antgravado", i.montokardex)
                Else
                    Me.dgvMov.Table.CurrentRecord.SetValue("antgravado", 0)
                End If

                Me.dgvMov.Table.CurrentRecord.SetValue("antigv", i.montoIgv)
                Me.dgvMov.Table.CurrentRecord.SetValue("anttotal", i.MontoDeudaSoles)

                Select Case i.TipoExistencia
                    Case "GS"
                        Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
                    Case Else
                        If IsNothing(detalle) Then
                            Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", 0)
                        Else
                            Me.dgvMov.Table.CurrentRecord.SetValue("cantidad", saldoCantidad)

                            If saldoCantidad > 0 Then
                                Me.dgvMov.Table.CurrentRecord.SetValue("pu", cTotalActmn / saldoCantidad)
                            Else
                                Me.dgvMov.Table.CurrentRecord.SetValue("pu", 0)
                            End If
                            Me.dgvMov.Table.CurrentRecord.SetValue("Devcantidad", 0) ' saldoCantidad)
                        End If
                End Select

                If i.destino = 1 Then


                    Dim iva As Decimal = TmpIGV / 100

                    Dim gravadoDev = Math.Round(CDec(CalculoBaseImponible(cTotalActmn, iva + 1)), 2)
                    Dim igvDev = cTotalActmn - gravadoDev




                    Me.dgvMov.Table.CurrentRecord.SetValue("gravado", gravadoDev)
                    Me.dgvMov.Table.CurrentRecord.SetValue("exonerado", 0)

                    Me.dgvMov.Table.CurrentRecord.SetValue("Devgravado", 0) 'gravadoDev)
                    Me.dgvMov.Table.CurrentRecord.SetValue("Devexonerado", 0)

                    Me.dgvMov.Table.CurrentRecord.SetValue("igv", igvDev)
                    Me.dgvMov.Table.CurrentRecord.SetValue("Devigv", igvDev)

                ElseIf i.destino = 2 Then

                    Me.dgvMov.Table.CurrentRecord.SetValue("gravado", 0)
                    Me.dgvMov.Table.CurrentRecord.SetValue("exonerado", KardexActualizado)

                    Me.dgvMov.Table.CurrentRecord.SetValue("Devgravado", 0)
                    Me.dgvMov.Table.CurrentRecord.SetValue("Devexonerado", 0) 'KardexActualizado)

                    Me.dgvMov.Table.CurrentRecord.SetValue("igv", 0)
                    Me.dgvMov.Table.CurrentRecord.SetValue("Devigv", 0)
                End If

                Me.dgvMov.Table.CurrentRecord.SetValue("inafecto", 0)
                Me.dgvMov.Table.CurrentRecord.SetValue("exportacion", 0)
                Me.dgvMov.Table.CurrentRecord.SetValue("isc", 0)
                Me.dgvMov.Table.CurrentRecord.SetValue("ivap", 0)
                Me.dgvMov.Table.CurrentRecord.SetValue("otros", 0)
                Me.dgvMov.Table.CurrentRecord.SetValue("descuento", 0)

                Me.dgvMov.Table.CurrentRecord.SetValue("total", cTotalActmn)


                Select Case i.EstadoCobro
                    Case TIPO_VENTA.PAGO.COBRADO

                        Me.dgvMov.Table.CurrentRecord.SetValue("montocob", i.MontoPagadoSoles)
                        Me.dgvMov.Table.CurrentRecord.SetValue("montodev", detalle.montoDevuelto)
                        Me.dgvMov.Table.CurrentRecord.SetValue("montoxdev", i.MontoPagadoSoles - detalle.montoDevuelto)
                        Me.dgvMov.Table.CurrentRecord.SetValue("estadocobro", "Pagado")

                        Me.dgvMov.Table.CurrentRecord.SetValue("DevCobro", 0) 'i.MontoPagadoSoles - detalle.montoDevuelto)
                    Case Else

                        Me.dgvMov.Table.CurrentRecord.SetValue("montocob", i.MontoPagadoSoles)
                        Me.dgvMov.Table.CurrentRecord.SetValue("montodev", detalle.montoDevuelto)
                        Me.dgvMov.Table.CurrentRecord.SetValue("montoxdev", i.MontoPagadoSoles - detalle.montoDevuelto)
                        Me.dgvMov.Table.CurrentRecord.SetValue("estadocobro", "Pendiente")
                        Me.dgvMov.Table.CurrentRecord.SetValue("DevCobro", 0) 'i.MontoPagadoSoles - detalle.montoDevuelto)
                End Select

                Me.dgvMov.Table.CurrentRecord.SetValue("Devinafecto", 0)
                Me.dgvMov.Table.CurrentRecord.SetValue("Devexportacion", 0)
                Me.dgvMov.Table.CurrentRecord.SetValue("Devisc", 0)
                Me.dgvMov.Table.CurrentRecord.SetValue("Devivap", 0)
                Me.dgvMov.Table.CurrentRecord.SetValue("Devotros", 0)
                Me.dgvMov.Table.CurrentRecord.SetValue("Devdescuento", 0)

                Me.dgvMov.Table.CurrentRecord.SetValue("Devtotal", 0) 'cTotalActmn)

                Me.dgvMov.Table.AddNewRecord.EndEdit()




            Next

            'If conteoNotas > 0 Then
            '    CombosDev()
            '    txtGlosa.Text = cboTipoNota.Text
            'End If

            TotalTalesXcolumna()
            txtGlosa.Text = cboTipoNota.Text
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub

    Sub GridCFG(grid As GridGroupingControl)
        grid.TableOptions.ShowRowHeader = False
        grid.TopLevelGroupOptions.ShowCaption = False
        Dim colorx As New GridMetroColors()
        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        grid.SetMetroStyle(colorx)
        grid.BorderStyle = System.Windows.Forms.BorderStyle.None

        'Me.gridGroupingControl1.BrowseOnly = true
        'Me.gridGroupingControl1.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One
        grid.TableOptions.SelectionBackColor = Color.Gray
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
        'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left
        'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
        grid.AllowProportionalColumnSizing = False
        grid.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        grid.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        grid.Table.DefaultColumnHeaderRowHeight = 25
        grid.Table.DefaultRecordRowHeight = 20
        grid.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub
    Public Sub RecargarDevolucion()
        For Each r As Record In dgvMov.Table.Records
            r.SetValue("DevCobro", CDec(r.GetValue("montoxdev")))
            r.SetValue("Devcantidad", CDec(r.GetValue("cantidad")))
            r.SetValue("Devgravado", CDec(r.GetValue("gravado")))
            r.SetValue("Devexonerado", CDec(r.GetValue("exonerado")))
            r.SetValue("Devigv", CDec(r.GetValue("igv")))
            r.SetValue("Devtotal", CDec(r.GetValue("total")))
        Next
        TotalTalesXcolumna()
    End Sub

    Public Sub Limpiar()
        For Each r As Record In dgvMov.Table.Records
            r.SetValue("DevCobro", 0)
            r.SetValue("Devcantidad", 0)
            r.SetValue("Devgravado", 0)
            r.SetValue("Devexonerado", 0)
            r.SetValue("Devigv", 0)
            r.SetValue("Devtotal", 0)
        Next
        TotalTalesXcolumna()
    End Sub



    Sub GetTableGrid()
        Dim dt As New DataTable()
        'dt.Columns.Add("codigo", GetType(String))
        dt.Columns.Add("secuencia")
        dt.Columns.Add("destino")
        dt.Columns.Add("lote")
        dt.Columns.Add("idItem")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("tipoEx")
        dt.Columns.Add("almacenRef")
        dt.Columns.Add("unidad")
        dt.Columns.Add("preuni")
        dt.Columns.Add("antcant")
        dt.Columns.Add("antgravado")
        dt.Columns.Add("antigv")
        dt.Columns.Add("anttotal")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("pu")
        dt.Columns.Add("gravado")
        dt.Columns.Add("exonerado")
        dt.Columns.Add("inafecto")
        dt.Columns.Add("exportacion")
        dt.Columns.Add("isc")
        dt.Columns.Add("ivap")
        dt.Columns.Add("otros")
        dt.Columns.Add("descuento")
        dt.Columns.Add("igv")
        dt.Columns.Add("total")
        dt.Columns.Add("montocob")
        dt.Columns.Add("montodev")
        dt.Columns.Add("montoxdev")
        dt.Columns.Add("estadocobro")
        dt.Columns.Add("Devcantidad")
        dt.Columns.Add("Devgravado")
        dt.Columns.Add("Devexonerado")
        dt.Columns.Add("Devinafecto")
        dt.Columns.Add("Devexportacion")
        dt.Columns.Add("Devisc")
        dt.Columns.Add("Devivap")
        dt.Columns.Add("Devotros")
        dt.Columns.Add("Devdescuento")
        dt.Columns.Add("Devigv")
        dt.Columns.Add("Devtotal")
        dt.Columns.Add("DevCobro")
        dgvMov.DataSource = dt
    End Sub
#End Region

    Private Sub FormNotaVentaFE_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cboTipoNota_Click(sender As Object, e As EventArgs) Handles cboTipoNota.Click

    End Sub

    Private Sub cboTipoNota_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboTipoNota.SelectedValueChanged
        Select Case cboTipoNota.SelectedValue
            Case "01", "02", "06"  'DEVOLUCION DE EXISTENCIAS
                dgvMov.TableDescriptor.Columns("Devtotal").ReadOnly = True
                dgvMov.TableDescriptor.Columns("Devcantidad").ReadOnly = True

                RecargarDevolucion()
            Case "07"
                dgvMov.TableDescriptor.Columns("Devtotal").ReadOnly = True
                dgvMov.TableDescriptor.Columns("Devcantidad").ReadOnly = False
                Limpiar()
            Case "05", "09"
                dgvMov.TableDescriptor.Columns("Devtotal").ReadOnly = False
                dgvMov.TableDescriptor.Columns("Devcantidad").ReadOnly = True
                Limpiar()
            Case "08"

            Case Else
                dgvMov.TableDescriptor.Columns("Devtotal").ReadOnly = True
                dgvMov.TableDescriptor.Columns("Devcantidad").ReadOnly = True
                RecargarDevolucion()
        End Select

        txtGlosa.Text = cboTipoNota.Text
    End Sub

    Private Sub dgvMov_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvMov.TableControlCellClick

    End Sub

    Private Sub dgvMov_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvMov.TableControlCurrentCellEditingComplete
        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        'Dim cc As GridCurrentCell = dgvMov.TableControl.CurrentCell
        'cc.ConfirmChanges()

        'If Not IsNothing(Me.dgvMov.Table.CurrentRecord) Then
        '    Dim strTipoEx As String = dgvMov.Table.CurrentRecord.GetValue("destino")

        '    Select Case cc.ColIndex
        '        Case 38 ' CODIGO BARRA


        '        Case 2 ' seleccion de empresa stock

        '        Case 3 ' seleccionar precios de venta: Mayo,r menor, gran mayor
        '            Dim r As Record = dgvMov.Table.CurrentRecord
        '            If Not IsNothing(r) Then

        '                'Select Case Int32.Parse(r.GetValue("cboprecio"))
        '                '    Case 0
        '                '        'Dim f As New frmPreciosByArticulos(r)
        '                '        'f.StartPosition = FormStartPosition.CenterParent
        '                '        'f.ShowDialog()

        '                '    Case Else
        '                '        precio = precioSA.GetPreciosproductoMaxFecha(Int32.Parse(r.GetValue("idProducto").ToString), Int32.Parse(r.GetValue("cboprecio")))

        '                '        If Not IsNothing(precio) Then
        '                '            r.SetValue("pumn", precio.precioMN)
        '                '            r.SetValue("pume", precio.precioME)
        '                '            Calculos()
        '                '        Else
        '                '            MessageBox.Show("No tiene una configuración para este precio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '                '            r.SetValue("pumn", 0)
        '                '            r.SetValue("pume", 0)
        '                '            Calculos()
        '                '        End If
        '                'End Select

        '            Else

        '            End If

        '        Case 9 'precio unitario

        '            Dim r As Record = dgvMov.Table.CurrentRecord
        '            Dim text As String = cc.Renderer.ControlText
        '            If r.GetValue("chPago") = True Then
        '                'Calculos()
        '            Else
        '                Dim valuePrecioVenta As Decimal = Convert.ToDecimal(text)
        '                cc.Renderer.ControlValue = valuePrecioVenta

        '                Dim menor = r.GetValue("menor")
        '                Dim mayor = r.GetValue("mayor")
        '                Dim gmayor = r.GetValue("gmayor")


        '                Dim lista As New List(Of Decimal)
        '                If menor > 0.00001 Then
        '                    lista.Add(menor)
        '                End If
        '                If mayor > 0.00001 Then
        '                    lista.Add(mayor)
        '                End If
        '                If gmayor > 0.00001 Then
        '                    lista.Add(gmayor)
        '                End If

        '                Dim minimo = lista.Min()
        '                Dim maximo = lista.Max()

        '                If valuePrecioVenta < minimo Then
        '                    cc.Renderer.ControlValue = menor
        '                    cc.ConfirmChanges()
        '                    cc.EndEdit()
        '                    'Calculos()
        '                    r.SetValue("tipoPrecio", "0")
        '                    Exit Sub
        '                Else
        '                    If valuePrecioVenta = menor Then
        '                        r.SetValue("tipoPrecio", "1")
        '                    ElseIf valuePrecioVenta = mayor Then
        '                        r.SetValue("tipoPrecio", "2")
        '                    ElseIf valuePrecioVenta = gmayor Then
        '                        r.SetValue("tipoPrecio", "3")
        '                    Else
        '                        r.SetValue("tipoPrecio", "0")
        '                    End If
        '                    'Calculos()
        '                End If
        '            End If



        '        Case 14
        '            Dim r As Record = dgvMov.Table.CurrentRecord
        '            Dim text As String = cc.Renderer.ControlText
        '            If r.GetValue("chPago") = True Then
        '                'Calculos()
        '            Else
        '                Dim valuePrecioVenta As Decimal = Convert.ToDecimal(text)
        '                cc.Renderer.ControlValue = valuePrecioVenta

        '                Dim menor = r.GetValue("menor")
        '                Dim mayor = r.GetValue("mayor")
        '                Dim gmayor = r.GetValue("gmayor")


        '                Dim lista As New List(Of Decimal)
        '                If menor > 0.00001 Then
        '                    lista.Add(menor)
        '                End If
        '                If mayor > 0.00001 Then
        '                    lista.Add(mayor)
        '                End If
        '                If gmayor > 0.00001 Then
        '                    lista.Add(gmayor)
        '                End If

        '                Dim minimo = lista.Min()
        '                Dim maximo = lista.Max()

        '                If valuePrecioVenta < minimo Then
        '                    cc.Renderer.ControlValue = menor
        '                    cc.ConfirmChanges()
        '                    cc.EndEdit()
        '                    'Calculos()
        '                    r.SetValue("tipoPrecio", "0")
        '                    Exit Sub
        '                Else
        '                    If valuePrecioVenta = menor Then
        '                        r.SetValue("tipoPrecio", "1")
        '                    ElseIf valuePrecioVenta = mayor Then
        '                        r.SetValue("tipoPrecio", "2")
        '                    ElseIf valuePrecioVenta = gmayor Then
        '                        r.SetValue("tipoPrecio", "3")
        '                    Else
        '                        r.SetValue("tipoPrecio", "0")
        '                    End If
        '                    'Calculos()
        '                End If
        '            End If
        '    End Select
        'End If
    End Sub

    Private Sub dgvMov_TableControlCurrentCellChanged(sender As Object, e As GridTableControlEventArgs) Handles dgvMov.TableControlCurrentCellChanged
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim precio As New configuracionPrecioProducto
        Dim cc As GridCurrentCell = dgvMov.TableControl.CurrentCell
        cc.ConfirmChanges()
        Try
            If Not IsNothing(cc) Then
                Select Case cc.ColIndex
                    Case 30 ' CANTIDAD


                        Dim r As Record = dgvMov.Table.CurrentRecord
                        Dim text As String = cc.Renderer.ControlText
                        If text.Trim.Length > 0 Then
                            Dim value As Decimal = Convert.ToDecimal(text)
                            cc.Renderer.ControlValue = value

                            Dim impDisponible = r.GetValue("cantidad")

                            If value = impDisponible Then

                                'recargar todo para no recalcular
                                RecargarDevolucion()

                            ElseIf value > impDisponible Then
                                cc.Renderer.ControlValue = 0
                                    cc.ConfirmChanges()
                                    cc.EndEdit()
                                    CalculosxCantidad()
                                    lblEstado.Text = "La Cantidad disponible es: " & impDisponible
                                    PanelError.Visible = True
                                    Timer1.Enabled = True
                                    TiempoEjecutar(10)
                                    Exit Sub
                                Else
                                    CalculosxCantidad()
                                End If

                            End If



                    Case 40 ' IMPORTES


                        Dim r As Record = dgvMov.Table.CurrentRecord
                        Dim text As String = cc.Renderer.ControlText
                        If text.Trim.Length > 0 Then
                            Dim value As Decimal = Convert.ToDecimal(text)
                            cc.Renderer.ControlValue = value

                            Dim impDisponible = r.GetValue("total")
                            'If value >= impDisponible Then
                            If value > impDisponible Then
                                cc.Renderer.ControlValue = 0
                                cc.ConfirmChanges()
                                cc.EndEdit()
                                Calculos(impDisponible)
                                lblEstado.Text = "El importe debe ser menor a: " & impDisponible
                                PanelError.Visible = True
                                Timer1.Enabled = True
                                TiempoEjecutar(10)
                                Exit Sub
                            Else
                                Calculos(impDisponible )
                            End If

                        End If





                End Select
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If Not IsNothing(Me.dgvMov.Table.CurrentRecord) Then
            Me.dgvMov.Table.CurrentRecord.Delete()
            'TotalTalesXcolumna()

            'If dgvMov.Table.Records.Count > 0 Then
            '    dgvMov.Table.Records(dgvMov.Table.Records.Count - 1).SetCurrent()
            '    dgvMov.Table.Records(dgvMov.Table.Records.Count - 1).BeginEdit()
            'End If
            'ConteoLabelVentas()
        End If
    End Sub

    Private Sub ToolStrip5_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip5.ItemClicked

    End Sub

    Private Sub btGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click
        Try

            If Not txtGlosa.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingresar una glosa o Información"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)

                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
            If Not txtSerie.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingresar un número de serie válido"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)

                Me.Cursor = Cursors.Arrow
                Exit Sub
            Else
                lblEstado.Text = "Done serie"
            End If

            If chIdentidad.Checked = False Then
                If Not txtCliente.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Ingresar un proveedor válido"

                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)

                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                Else
                    lblEstado.Text = "Done proveedor"

                End If
            End If



            If Not txtNumero.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingresar un número de comprobante válido"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)

                Me.Cursor = Cursors.Arrow
                Exit Sub
            Else
                lblEstado.Text = "Done número comprobante"

            End If

            '***********************************************************************
            If dgvMov.Table.Records.Count > 0 Then

                'generarFactNotaCredito()

                'NotaCreditoFacturaElectronica()
                Grabar()







                'fhfghfgh
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub

    Private Sub ChPagoDirecto_OnChange(sender As Object, e As EventArgs) Handles ChPagoDirecto.OnChange
        PagoDirectoCheck()
    End Sub

    Private Sub PagoDirectoCheck()
        If ChPagoDirecto.Checked Then
            cbocajaPago.Visible = True
            ' ChPagoAvanzado.Visible = True
            ChPagoAvanzado.Checked = False
            Label8.Visible = True
        Else
            cbocajaPago.Visible = False
            ''  ChPagoAvanzado.Visible = False
            'ChPagoAvanzado.Checked = False
            'Label8.Visible = False
        End If
        If ChPagoAvanzado.Checked = False AndAlso ChPagoDirecto.Checked = False Then
            LblPagoCredito.Visible = True
        Else
            LblPagoCredito.Visible = False
        End If
    End Sub

    Private Sub ChPagoAvanzado_OnChange(sender As Object, e As EventArgs) Handles ChPagoAvanzado.OnChange
        If ChPagoAvanzado.Checked = True Then
            ChPagoDirecto.Checked = False
            cbocajaPago.Visible = False
        Else
            '       cbocajaPago.Visible = True
        End If
        If ChPagoAvanzado.Checked = False AndAlso ChPagoDirecto.Checked = False Then
            LblPagoCredito.Visible = True
        Else
            LblPagoCredito.Visible = False
        End If
    End Sub
End Class
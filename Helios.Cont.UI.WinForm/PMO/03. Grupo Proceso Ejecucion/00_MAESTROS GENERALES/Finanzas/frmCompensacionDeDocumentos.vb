Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Tools

Public Class frmCompensacionDeDocumentos
    Inherits frmMaster

    Public Property listaCompensatorio As New List(Of documentoCajaDetalle)

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        'ConfiguracionInicio()
        GridCFG(dgvCompensacion)
        GridCFG(dgvDetCompensacion)

        'GridCFGOblig(dgvObligaciones)
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        'AddHandler TreeMenuItem1.SelectionChanged, AddressOf Me.TreeMenuItem1_SelectionChanged
        'Me.WindowState = FormWindowState.Maximized
        'DateTimePickerAdv2.Value = PeriodoGeneral
        'DateTimePickerAdv1.Value = PeriodoGeneral
        'txtPeriodoAFC.Value = PeriodoGeneral
        txtPeriodoCompras.Value = PeriodoGeneral

        'txtFechaInicio.Value = DateTime.Now
        'txtFechaFin.Value = DateTime.Now
    End Sub

#Region "Metodos"


    Private Sub UbicarVentaXProveedorNroSerie(RucProveedor As String, strPeriodo As String)
        Dim documentoVentaSA As New documentoVentaAbarrotesSA
        Dim documentoVenta As New List(Of documentoventaAbarrotes)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable

        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("tipoCompra", GetType(String))
        dt.Columns.Add("Fecha", GetType(String))
        dt.Columns.Add("periodo", GetType(String))

        dt.Columns.Add("TipoDoc", GetType(String))
        dt.Columns.Add("Serie", GetType(String))
        dt.Columns.Add("Numero", GetType(String))
        dt.Columns.Add("moneda", GetType(String))
        dt.Columns.Add("montoMN", GetType(Decimal))
        dt.Columns.Add("montoME", GetType(Decimal))





        documentoVenta = documentoVentaSA.UbicarVentaPorCompensar(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, RucProveedor, strPeriodo, "1")
        Dim str As String
        If Not IsNothing(documentoVenta) Then
            Dim SaldoPagosMN As Decimal = 0
            Dim SaldoPagosME As Decimal = 0

            For Each i In documentoVenta

                SaldoPagosMN = 0
                SaldoPagosME = 0

                SaldoPagosMN = i.ImporteNacional - i.PagoSumaMN
                SaldoPagosME = i.ImporteExtranjero - i.PagoSumaME

                'nota de credito
                SaldoPagosMN = SaldoPagosMN - i.PagoNotaCreditoMN + i.PagoNotaDebitoMN
                SaldoPagosME = SaldoPagosME - i.PagoNotaCreditoME + i.PagoNotaDebitoME


                Dim dr As DataRow = dt.NewRow()
                str = Nothing
                str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
                dr(0) = i.idDocumento
                dr(1) = i.tipoVenta
                dr(2) = str
                dr(3) = i.fechaPeriodo
                dr(4) = tablaSA.GetUbicarTablaID(10, i.tipoDocumento).descripcion.Substring(0, 3)
                dr(5) = i.serie
                dr(6) = i.numeroDoc
                Select Case i.moneda
                    Case 1
                        dr(7) = "NAC"
                    Case Else
                        dr(7) = "EXT"
                End Select
                'dr(8) = i.ImporteNacional
                'dr(9) = i.ImporteExtranjero
                dr(8) = SaldoPagosMN
                dr(9) = SaldoPagosME
                dt.Rows.Add(dr)
            Next
            dgvCompra.DataSource = dt

        Else

        End If
    End Sub
    Function asientoCaja2Reclamacion() As asiento
        Dim cuentaFinacieraSA As New EstadosFinancierosSA
        Dim nAsiento As New asiento
        Dim nDebe As New movimiento
        Dim nHaber As New movimiento
        Dim sumaAsientocajaMN As Decimal = 0
        Dim sumaAsientocajaME As Decimal = 0

        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.periodo = PeriodoGeneral
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        'nAsiento.idEntidad = lblIdProveedor
        nAsiento.idEntidad = txtProveedor.Tag
        'nAsiento.nombreEntidad = lblNomProveedor
        nAsiento.nombreEntidad = txtProveedor.Text
        'nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.tipoEntidad = "PR"
        nAsiento.fechaProceso = DateTime.Now
        nAsiento.codigoLibro = "1"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = "NN"
        'correccin asientos
        nAsiento.importeMN = txttotalcomp.Text   ' dgvDetalleItems.Rows(i.Index).Cells(6).Value()
        nAsiento.importeME = txttotalcompme.Text   ' dgvDetalleItems.Rows(i.Index).Cells(7).Value()
        nAsiento.glosa = "Por Compensacion"
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now

        'For Each i As DataGridViewRow In dgvDetalleItems.Rows

        'aquiiiiiiiiiiiiiiiiii!()
        For Each i As Record In dgvDetCompensacion.Table.Records


            If CDec(i.GetValue("importemn")) > 0 Then

                nAsiento.movimiento.Add(AS_DebeCompReclamacion(i.GetValue("importemn"), i.GetValue("importeme")))
            End If
        Next

        'Corregir
        'For Each r As Record In dgvDiferencia.Table.Records



        Return nAsiento
    End Function

    Function asientoCaja2() As asiento
        Dim cuentaFinacieraSA As New EstadosFinancierosSA
        Dim nAsiento As New asiento
        Dim nDebe As New movimiento
        Dim nHaber As New movimiento
        Dim sumaAsientocajaMN As Decimal = 0
        Dim sumaAsientocajaME As Decimal = 0

        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.periodo = PeriodoGeneral
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        'nAsiento.idEntidad = lblIdProveedor
        nAsiento.idEntidad = txtProveedor.Tag
        'nAsiento.nombreEntidad = lblNomProveedor
        nAsiento.nombreEntidad = txtProveedor.Text
        'nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.tipoEntidad = "PR"
        nAsiento.fechaProceso = DateTime.Now
        nAsiento.codigoLibro = "1"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = "NN"
        'correccin asientos
        nAsiento.importeMN = txttotalcomp.Text   ' dgvDetalleItems.Rows(i.Index).Cells(6).Value()
        nAsiento.importeME = txttotalcompme.Text   ' dgvDetalleItems.Rows(i.Index).Cells(7).Value()
        nAsiento.glosa = "Por Compensacion"
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now

        'For Each i As DataGridViewRow In dgvDetalleItems.Rows

        'aquiiiiiiiiiiiiiiiiii!()
        For Each i As Record In dgvDetCompensacion.Table.Records


            If CDec(i.GetValue("importemn")) > 0 Then

                nAsiento.movimiento.Add(AS_HaberComp(i.GetValue("importemn"), i.GetValue("importeme")))
            End If
        Next

        'Corregir
        'For Each r As Record In dgvDiferencia.Table.Records



        Return nAsiento
    End Function

    Public Function AS_HaberComp(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
      .cuenta = "1629",
      .descripcion = "COMPENSACION",
      .tipo = ASIENTO_CONTABLE.UBICACION.HABER,
      .monto = cMonto,
      .montoUSD = cMontoUS,
      .fechaActualizacion = DateTime.Now,
      .usuarioActualizacion = usuario.IDUsuario}
        Return nMovimiento
    End Function


    Public Function AS_DebeCompReclamacion(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
      .cuenta = "461",
      .descripcion = "COMPENSACION",
      .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
      .monto = cMonto,
      .montoUSD = cMontoUS,
      .fechaActualizacion = DateTime.Now,
      .usuarioActualizacion = usuario.IDUsuario}
        Return nMovimiento
    End Function

    Public Function AS_HaberClienteReclamacion(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
      .cuenta = "1213",
      .descripcion = "COMPENSACION",
      .tipo = ASIENTO_CONTABLE.UBICACION.HABER,
      .monto = cMonto,
      .montoUSD = cMontoUS,
      .fechaActualizacion = DateTime.Now,
      .usuarioActualizacion = usuario.IDUsuario}
        Return nMovimiento
    End Function

    Public Function AS_HaberCliente(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
      .cuenta = "4212",
      .descripcion = "COMPENSACION",
      .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
      .monto = cMonto,
      .montoUSD = cMontoUS,
      .fechaActualizacion = DateTime.Now,
      .usuarioActualizacion = usuario.IDUsuario}
        Return nMovimiento
    End Function


    Function asientoCajaReclamacion() As asiento
        Dim cuentaFinacieraSA As New EstadosFinancierosSA
        Dim nAsiento As New asiento
        Dim nDebe As New movimiento
        Dim nHaber As New movimiento
        Dim sumaAsientocajaMN As Decimal = 0
        Dim sumaAsientocajaME As Decimal = 0

        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.periodo = PeriodoGeneral
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        'nAsiento.idEntidad = lblIdProveedor
        nAsiento.idEntidad = txtProveedor.Tag
        'nAsiento.nombreEntidad = lblNomProveedor
        nAsiento.nombreEntidad = txtProveedor.Text
        'nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.tipoEntidad = "PR"
        nAsiento.fechaProceso = DateTime.Now
        nAsiento.codigoLibro = "1"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = "NN"
        'correccin asientos
        nAsiento.importeMN = txttotalcomp.Text   ' dgvDetalleItems.Rows(i.Index).Cells(6).Value()
        nAsiento.importeME = txttotalcompme.Text   ' dgvDetalleItems.Rows(i.Index).Cells(7).Value()
        nAsiento.glosa = "Por Compensacion"
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now

        'For Each i As DataGridViewRow In dgvDetalleItems.Rows

        'aquiiiiiiiiiiiiiiiiii!()
        For Each i As Record In dgvCompensacion.Table.Records


            If CDec(i.GetValue("pago")) > 0 Then

                nAsiento.movimiento.Add(AS_HaberClienteReclamacion(i.GetValue("pago"), i.GetValue("pagome")))
            End If
        Next

        'Corregir
        'For Each r As Record In dgvDiferencia.Table.Records



        Return nAsiento
    End Function


    Function asientoCaja() As asiento
        Dim cuentaFinacieraSA As New EstadosFinancierosSA
        Dim nAsiento As New asiento
        Dim nDebe As New movimiento
        Dim nHaber As New movimiento
        Dim sumaAsientocajaMN As Decimal = 0
        Dim sumaAsientocajaME As Decimal = 0

        nAsiento = New asiento
        nAsiento.periodo = PeriodoGeneral
        nAsiento.idDocumento = 0
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        'nAsiento.idEntidad = lblIdProveedor
        nAsiento.idEntidad = txtProveedor.Tag
        'nAsiento.nombreEntidad = lblNomProveedor
        nAsiento.nombreEntidad = txtProveedor.Text
        'nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.tipoEntidad = "PR"
        nAsiento.fechaProceso = DateTime.Now
        nAsiento.codigoLibro = "1"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = "NN"
        'correccin asientos
        nAsiento.importeMN = txttotalcomp.Text   ' dgvDetalleItems.Rows(i.Index).Cells(6).Value()
        nAsiento.importeME = txttotalcompme.Text   ' dgvDetalleItems.Rows(i.Index).Cells(7).Value()
        nAsiento.glosa = "Por Compensacion"
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now

        'For Each i As DataGridViewRow In dgvDetalleItems.Rows

        'aquiiiiiiiiiiiiiiiiii!()
        For Each i As Record In dgvCompensacion.Table.Records


            If CDec(i.GetValue("pago")) > 0 Then

                nAsiento.movimiento.Add(AS_HaberCliente(i.GetValue("pago"), i.GetValue("pagome")))
            End If
        Next

        'Corregir
        'For Each r As Record In dgvDiferencia.Table.Records



        Return nAsiento
    End Function


    'Sub AsientoNotaCreditoNormal(ListaExistencias As List(Of documentocompradetalle))
    '    Dim nMovimiento As New movimiento
    '    Dim nAsiento As New asiento


    '    Dim SumaCliente = Aggregate n In ListaExistencias
    '       Into totalMN = Sum(n.importe),
    '       totalME = Sum(n.importeUS)

    '    If SumaCliente.totalMN.GetValueOrDefault > 0 Then
    '        nAsiento = New asiento
    '        nAsiento.idDocumento = 0
    '        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
    '        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
    '        nAsiento.idEntidad = txtProveedor.Tag
    '        nAsiento.nombreEntidad = txtProveedor.Text
    '        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
    '        nAsiento.fechaProceso = txtFecha.Value
    '        nAsiento.codigoLibro = "8"
    '        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
    '        nAsiento.tipoAsiento = ASIENTO_CONTABLE.COMPRA_NOTA_CREDITO
    '        nAsiento.glosa = txtGlosa.Text.Trim
    '        nAsiento.importeMN = SumaCliente.totalMN.GetValueOrDefault
    '        nAsiento.importeME = SumaCliente.totalME.GetValueOrDefault
    '        nAsiento.usuarioActualizacion = usuario.IDUsuario
    '        nAsiento.fechaActualizacion = DateTime.Now
    '        ListaAsientonTransito.Add(nAsiento)
    '    End If

    '    If SumaCliente.totalMN.GetValueOrDefault > 0 Then
    '        nAsiento.movimiento.Add(AS_Proveedor(SumaCliente.totalMN.GetValueOrDefault, SumaCliente.totalME.GetValueOrDefault))
    '    End If

    '    For Each i In ListaExistencias
    '        Select Case i.TipoOperacion
    '            Case "9913"

    '            Case "9925"
    '                nMovimiento = New movimiento
    '                nMovimiento.cuenta = "775"
    '                nMovimiento.descripcion = "DESCUENTOS OBTENIDOS POR PRONTO PAGO"
    '                nMovimiento.tipo = "H"
    '                nMovimiento.monto = i.montokardex
    '                nMovimiento.montoUSD = i.montokardexUS
    '                nMovimiento.usuarioActualizacion = usuario.IDUsuario
    '                nMovimiento.fechaActualizacion = DateTime.Now
    '                nAsiento.movimiento.Add(nMovimiento)
    '            Case Else
    '                nAsiento.movimiento.Add(AS_Default(Nothing, i.montokardex, i.montokardexUS, i.tipoExistencia, i.descripcionItem))
    '                MV_Item_Transito(i.descripcionItem, i.montokardex, i.montokardexUS, i.tipoExistencia)
    '        End Select

    '    Next

    '    Dim SumaIGV = Aggregate n In ListaExistencias
    '              Into IGVmn = Sum(n.montoIgv),
    '              IGVme = Sum(n.montoIgvUS)

    '    If SumaIGV.IGVmn.GetValueOrDefault > 0 Then
    '        nAsiento.movimiento.Add(AS_IGV(SumaIGV.IGVmn.GetValueOrDefault, SumaIGV.IGVme.GetValueOrDefault))
    '    End If
    'End Sub

    Sub GrabarVenta()
        Dim VentaSA As New documentoVentaAbarrotesSA
        Dim ndocumento As New documento()
        Dim nDocumentoExce As New documento
        Dim nDocumentVenta As New documentoventaAbarrotes()
        Dim objDocumentoVentaDet As New documentoventaAbarrotesDet
        Dim ListaDetalle As New List(Of documentoventaAbarrotesDet)
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad
        Dim DocCaja As New documento
        Dim FichaEFSaldo As New GFichaUsuario
        Dim asientoSA As New AsientoSA
        ' Dim ListaAsiento As New List(Of asiento)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        Dim ndocumentoComp As New documento()
        Dim nDocumentoCompraComp As New documentoventaAbarrotes()
        Dim objDocumentoCompraDetComp As New documentoventaAbarrotesDet
        Dim ListaDetalleComp As New List(Of documentoventaAbarrotesDet)
        Dim asiento As New asiento
        Dim ListaAsiento As New List(Of asiento)
        Dim asiento2 As New asiento
        Dim ListaAsiento2 As New List(Of asiento)

        With ndocumento
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            If Not IsNothing(GProyectos) Then
                .idProyecto = GProyectos.IdProyectoActividad
            End If

            .tipoDoc = "9901"
            .fechaProceso = DateTime.Now
            .nroDoc = txtSerieCompr.Text & "-" & txtNumeroCompr.Text.Trim

            .idOrden = Nothing ' Me.IdOrden
            .moneda = IIf(txtMon.Text = 1, "1", "2")
            .idEntidad = CInt(txtProveedor.Tag)
            .entidad = txtProveedor.Text
            .nrodocEntidad = txtRuc.Text
            .tipoEntidad = lblTipoEntidad.Text
            .tipoOperacion = "18"
            .usuarioActualizacion = "NN"
            .fechaActualizacion = DateTime.Now
        End With

        With nDocumentVenta
            .idPadre = lblIdDocumento.Text
            .codigoLibro = "8"
            .tipoDocumento = "9901"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento
            .fechaDoc = DateTime.Now
            .fechaLaboral = New DateTime(DiaLaboral.Year, DiaLaboral.Month, DiaLaboral.Day, DiaLaboral.Hour, DiaLaboral.Minute, DiaLaboral.Second)
            .fechaPeriodo = PeriodoGeneral
            .serie = txtSerieCompr.Text
            .numeroDoc = txtNumeroCompr.Text.Trim
            .idCliente = CInt(txtProveedor.Tag)
            .nombrePedido = txtProveedor.Text
            .moneda = IIf(txtMon.Text = 1, "1", "2")
            .tasaIgv = CDec(txtIva.Text)    ' IIf(IsNothing(nudIgv.Value) Or String.IsNullOrEmpty(nudIgv.Value) Or String.IsNullOrWhiteSpace(nudIgv.Value), Nothing, Trim(nudIgv.Value))
            .tipoCambio = CDec(txtTipoCambio.Text)
            '.tipoRecaudo = Nothing
            ' .regimen = Nothing
            ' .tasaRegimen = 0
            ' .nroRegimen = Nothing
            '****************** DESTINO EN SOLES ************************************************************************
            '.bi01 = TotalesXcanbeceras.base1.GetValueOrDefault
            '.bi02 = TotalesXcanbeceras.base2.GetValueOrDefault

            '.igv01 = TotalesXcanbeceras.MontoIgv1.GetValueOrDefault
            '.igv02 = TotalesXcanbeceras.MontoIgv2.GetValueOrDefault


            '****************** DESTINO EN DOLARES ************************************************************************
            '.bi01us = TotalesXcanbeceras.base1me.GetValueOrDefault
            '.bi02us = TotalesXcanbeceras.base2me.GetValueOrDefault

            '.igv01us = TotalesXcanbeceras.MontoIgv1me.GetValueOrDefault
            '.igv02us = TotalesXcanbeceras.MontoIgv2me.GetValueOrDefault

            '****************************************************************************************************************
            .ImporteNacional = txttotalcomp.Text
            .ImporteExtranjero = txttotalcompme.Text
            '.destino = "COMP"
            .glosa = "Compensacion de Documentos"
            '.refe = Nothing ' IIf(IsNothing(txtDestinoref.Text) Or String.IsNullOrEmpty(txtDestinoref.Text) Or String.IsNullOrWhiteSpace(txtDestinoref.Text), Nothing, Trim(txtDestinoref.Text.Trim))
            .tipoVenta = "COMPV"
            '.s = "ALTF"
            ' .DocumentoSustentado = "S"
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
            .sustentado = "01" 'strTipoNota
            ' .aprobado = "S"
            .CajaSeleccionada = Nothing

        End With
        ndocumento.documentoventaAbarrotes = nDocumentVenta


        For Each r As Record In dgvCompensacion.Table.Records

            objDocumentoVentaDet = New documentoventaAbarrotesDet

            objDocumentoVentaDet.secuencia = r.GetValue("secuencia")
            objDocumentoVentaDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoVentaDet.IdEstablecimiento = GEstableciento.IdEstablecimiento
            objDocumentoVentaDet.FechaDoc = DateTime.Now
            objDocumentoVentaDet.FechaLaboral = New DateTime(DiaLaboral.Year, DiaLaboral.Month, DiaLaboral.Day, DiaLaboral.Hour, DiaLaboral.Minute, DiaLaboral.Second)

            objDocumentoVentaDet.TipoOperacion = "9918"
            ' objDocumentoVentaDet.operacionNota = "9918"
            objDocumentoVentaDet.destino = r.GetValue("grav")
            objDocumentoVentaDet.idItem = r.GetValue("idItem")
            objDocumentoVentaDet.nombreItem = CStr(r.GetValue("descripcion"))
            objDocumentoVentaDet.tipoExistencia = CStr(r.GetValue("tipoEx"))
            objDocumentoVentaDet.importeMN = CDec(r.GetValue("pago"))
            objDocumentoVentaDet.importeME = CDec(r.GetValue("pagome"))
            objDocumentoVentaDet.IdEstablecimiento = GEstableciento.IdEstablecimiento
            'objDocumentoVentaDet.bonificacion = Nothing
            objDocumentoVentaDet.idPadreDTVenta = CInt(r.GetValue("secuencia"))
            '**********************************************************************************
            objDocumentoVentaDet.usuarioModificacion = usuario.IDUsuario
            objDocumentoVentaDet.fechaModificacion = DateTime.Now
            objDocumentoVentaDet.fechaVcto = Nothing ' IIf(IsNothing(dgvNuevoDoc.Rows(S).Cells(28).Value()), Nothing, CDate(dgvNuevoDoc.Rows(S).Cells(28).Value()))
            objDocumentoVentaDet.Glosa = "Compensacion de documentos"
            ' objDocumentoCompraDet.BonificacionMN =

            objDocumentoVentaDet.NumDoc = txtNumeroCompr.Text
            objDocumentoVentaDet.Serie = txtSerieCompr.Text
            objDocumentoVentaDet.TipoDoc = "9901"

            ListaDetalle.Add(objDocumentoVentaDet)
            '   End If
        Next
        '---------------------------------------------------------------------------------
        ndocumento.documentoventaAbarrotes.tipoOperacion = "18"
        'AsientoNotaCreditoNormal(ListadoExistencias)

        asiento = asientoCajaReclamacion()
        ListaAsiento.Add(asiento)
        ndocumento.asiento = ListaAsiento


        ndocumento.documentoventaAbarrotes.documentoventaAbarrotesDet = ListaDetalle



        '/////////////////DOCUMENTO COMPENSATORIO ////////////////
        With ndocumentoComp
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            If Not IsNothing(GProyectos) Then
                .idProyecto = GProyectos.IdProyectoActividad
            End If

            .tipoDoc = "9901"
            .fechaProceso = DateTime.Now
            .nroDoc = TextBoxExt4.Text & "-" & TextBoxExt3.Text.Trim

            .idOrden = Nothing ' Me.IdOrden
            .moneda = IIf(txtMon.Text = 1, "1", "2")
            .idEntidad = CInt(txtProveedor.Tag)
            .entidad = txtProveedor.Text
            .nrodocEntidad = txtRuc.Text
            .tipoEntidad = lblTipoEntidad.Text
            .tipoOperacion = "18"
            .usuarioActualizacion = "NN"
            .fechaActualizacion = DateTime.Now
        End With

        With nDocumentoCompraComp
            .idPadre = lblIdDocumentoComp.Text
            .codigoLibro = "8"
            .tipoDocumento = "9901"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento
            .fechaDoc = DateTime.Now
            .fechaLaboral = New DateTime(DiaLaboral.Year, DiaLaboral.Month, DiaLaboral.Day, DiaLaboral.Hour, DiaLaboral.Minute, DiaLaboral.Second)
            .fechaPeriodo = PeriodoGeneral
            .serie = TextBoxExt4.Text
            .numeroDoc = TextBoxExt3.Text.Trim
            .idCliente = CInt(txtProveedor.Tag)
            .nombrePedido = txtProveedor.Text
            .moneda = IIf(txtMon.Text = 1, "1", "2")
            .tasaIgv = CDec(txtIva.Text)    ' IIf(IsNothing(nudIgv.Value) Or String.IsNullOrEmpty(nudIgv.Value) Or String.IsNullOrWhiteSpace(nudIgv.Value), Nothing, Trim(nudIgv.Value))
            .tipoCambio = CDec(txtTipoCambio.Text)
            '.tipoRecaudo = Nothing
            '.regimen = Nothing
            ' .tasaRegimen = 0
            ' .nroRegimen = Nothing
            '  '****************** DESTINO EN SOLES ************************************************************************
            '.bi01 = TotalesXcanbeceras.base1.GetValueOrDefault
            '.bi02 = TotalesXcanbeceras.base2.GetValueOrDefault

            '.igv01 = TotalesXcanbeceras.MontoIgv1.GetValueOrDefault
            '.igv02 = TotalesXcanbeceras.MontoIgv2.GetValueOrDefault


            '****************** DESTINO EN DOLARES ************************************************************************
            '.bi01us = TotalesXcanbeceras.base1me.GetValueOrDefault
            '.bi02us = TotalesXcanbeceras.base2me.GetValueOrDefault

            '.igv01us = TotalesXcanbeceras.MontoIgv1me.GetValueOrDefault
            '.igv02us = TotalesXcanbeceras.MontoIgv2me.GetValueOrDefault

            '****************************************************************************************************************
            .ImporteNacional = txttotalcomp2.Text
            .ImporteExtranjero = txttotalcomp2me.Text
            '.destino = "COMP"
            .glosa = "Compensacion de Documentos"
            ' .referenciaDestino = Nothing ' IIf(IsNothing(txtDestinoref.Text) Or String.IsNullOrEmpty(txtDestinoref.Text) Or String.IsNullOrWhiteSpace(txtDestinoref.Text), Nothing, Trim(txtDestinoref.Text.Trim))
            .tipoVenta = "COMPV"
            ' .situacion = "ALTF"
            ' .DocumentoSustentado = "S"
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
            .sustentado = "01" 'strTipoNota
            ' .aprobado = "S"
            .CajaSeleccionada = Nothing

        End With
        ndocumentoComp.documentoventaAbarrotes = nDocumentoCompraComp


        For Each rx As Record In dgvDetCompensacion.Table.Records

            objDocumentoCompraDetComp = New documentoventaAbarrotesDet

            objDocumentoCompraDetComp.secuencia = rx.GetValue("Sec")
            objDocumentoCompraDetComp.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoCompraDetComp.IdEstablecimiento = GEstableciento.IdEstablecimiento
            objDocumentoCompraDetComp.FechaDoc = DateTime.Now
            objDocumentoCompraDetComp.FechaLaboral = New DateTime(DiaLaboral.Year, DiaLaboral.Month, DiaLaboral.Day, DiaLaboral.Hour, DiaLaboral.Minute, DiaLaboral.Second)

            objDocumentoCompraDetComp.TipoOperacion = "9918"
            'objDocumentoCompraDetComp.operacionNota = "9918"
            objDocumentoCompraDetComp.destino = rx.GetValue("grav")
            objDocumentoCompraDetComp.idItem = rx.GetValue("idItem")
            objDocumentoCompraDetComp.nombreItem = CStr(rx.GetValue("Descrip"))
            objDocumentoCompraDetComp.tipoExistencia = CStr(rx.GetValue("tipoEx"))
            objDocumentoCompraDetComp.importeMN = CDec(rx.GetValue("importemn"))
            objDocumentoCompraDetComp.importeME = CDec(rx.GetValue("importeme"))
            objDocumentoCompraDetComp.IdEstablecimiento = GEstableciento.IdEstablecimiento
            'objDocumentoCompraDetComp.bonificacion = Nothing
            objDocumentoCompraDetComp.idPadreDTVenta = CInt(rx.GetValue("Sec"))
            '**********************************************************************************
            objDocumentoCompraDetComp.usuarioModificacion = usuario.IDUsuario
            objDocumentoCompraDetComp.fechaModificacion = DateTime.Now
            objDocumentoCompraDetComp.fechaVcto = Nothing ' IIf(IsNothing(dgvNuevoDoc.Rows(S).Cells(28).Value()), Nothing, CDate(dgvNuevoDoc.Rows(S).Cells(28).Value()))
            objDocumentoCompraDetComp.Glosa = "Compensacion de documentos"
            ' objDocumentoCompraDet.BonificacionMN =

            objDocumentoCompraDetComp.NumDoc = txtNumeroCompr.Text
            objDocumentoCompraDetComp.Serie = txtSerieCompr.Text
            objDocumentoCompraDetComp.TipoDoc = "9901"

            ListaDetalleComp.Add(objDocumentoCompraDetComp)
            '   End If
        Next
        '---------------------------------------------------------------------------------
        ndocumentoComp.documentoventaAbarrotes.tipoOperacion = "18"
        'AsientoNotaCreditoNormal(ListadoExistencias)


        asiento2 = asientoCaja2Reclamacion()
        ListaAsiento2.Add(asiento2)
        ndocumentoComp.asiento = ListaAsiento2

        ndocumentoComp.documentoventaAbarrotes.documentoventaAbarrotesDet = ListaDetalleComp


        Dim xcod As Integer = VentaSA.CompensacionDocumentosVenta(ndocumento, ndocumentoComp)
        lblEstado.Text = "nota de crédito registrada!"
        Dispose()
    End Sub

    Sub Grabar()
        Dim CompraSA As New DocumentoCompraSA
        Dim ndocumento As New documento()
        Dim nDocumentoExce As New documento
        Dim nDocumentoCompra As New documentocompra()
        Dim objDocumentoCompraDet As New documentocompradetalle
        Dim ListaDetalle As New List(Of documentocompradetalle)
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad
        Dim DocCaja As New documento
        Dim FichaEFSaldo As New GFichaUsuario
        Dim asientoSA As New AsientoSA
        ' Dim ListaAsiento As New List(Of asiento)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        Dim ndocumentoComp As New documento()
        Dim nDocumentoCompraComp As New documentocompra()
        Dim objDocumentoCompraDetComp As New documentocompradetalle
        Dim ListaDetalleComp As New List(Of documentocompradetalle)
        Dim asiento As New asiento
        Dim ListaAsiento As New List(Of asiento)
        Dim asiento2 As New asiento
        Dim ListaAsiento2 As New List(Of asiento)

        With ndocumento
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            If Not IsNothing(GProyectos) Then
                .idProyecto = GProyectos.IdProyectoActividad
            End If

            .tipoDoc = "9901"
            .fechaProceso = DateTime.Now
            .nroDoc = txtSerieCompr.Text & "-" & txtNumeroCompr.Text.Trim

            .idOrden = Nothing ' Me.IdOrden
            .moneda = IIf(txtMon.Text = 1, "1", "2")
            .idEntidad = CInt(txtProveedor.Tag)
            .entidad = txtProveedor.Text
            .nrodocEntidad = txtRuc.Text
            .tipoEntidad = lblTipoEntidad.Text
            .tipoOperacion = "18"
            .usuarioActualizacion = "NN"
            .fechaActualizacion = DateTime.Now
        End With

        With nDocumentoCompra
            .idPadre = lblIdDocumento.Text
            .codigoLibro = "8"
            .tipoDoc = "9901"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = DateTime.Now
            .fechaLaboral = New DateTime(DiaLaboral.Year, DiaLaboral.Month, DiaLaboral.Day, DiaLaboral.Hour, DiaLaboral.Minute, DiaLaboral.Second)
            .fechaContable = PeriodoGeneral
            .serie = txtSerieCompr.Text
            .numeroDoc = txtNumeroCompr.Text.Trim
            .idProveedor = CInt(txtProveedor.Tag)
            .nombreProveedor = txtProveedor.Text
            .monedaDoc = IIf(txtMon.Text = 1, "1", "2")
            .tasaIgv = CDec(txtIva.Text)    ' IIf(IsNothing(nudIgv.Value) Or String.IsNullOrEmpty(nudIgv.Value) Or String.IsNullOrWhiteSpace(nudIgv.Value), Nothing, Trim(nudIgv.Value))
            .tcDolLoc = CDec(txtTipoCambio.Text)
            .tipoRecaudo = Nothing
            .regimen = Nothing
            .tasaRegimen = 0
            .nroRegimen = Nothing
            '****************** DESTINO EN SOLES ************************************************************************
            '.bi01 = TotalesXcanbeceras.base1.GetValueOrDefault
            '.bi02 = TotalesXcanbeceras.base2.GetValueOrDefault

            '.igv01 = TotalesXcanbeceras.MontoIgv1.GetValueOrDefault
            '.igv02 = TotalesXcanbeceras.MontoIgv2.GetValueOrDefault


            '****************** DESTINO EN DOLARES ************************************************************************
            '.bi01us = TotalesXcanbeceras.base1me.GetValueOrDefault
            '.bi02us = TotalesXcanbeceras.base2me.GetValueOrDefault

            '.igv01us = TotalesXcanbeceras.MontoIgv1me.GetValueOrDefault
            '.igv02us = TotalesXcanbeceras.MontoIgv2me.GetValueOrDefault

            '****************************************************************************************************************
            .importeTotal = txttotalcomp.Text
            .importeUS = txttotalcompme.Text
            .destino = "COMP"
            .glosa = "Compensacion de Documentos"
            .referenciaDestino = Nothing ' IIf(IsNothing(txtDestinoref.Text) Or String.IsNullOrEmpty(txtDestinoref.Text) Or String.IsNullOrWhiteSpace(txtDestinoref.Text), Nothing, Trim(txtDestinoref.Text.Trim))
            .tipoCompra = "COMP"
            .situacion = "ALTF"
            ' .DocumentoSustentado = "S"
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
            .sustentado = "01" 'strTipoNota
            .aprobado = "S"
            .CajaSeleccionada = Nothing

        End With
        ndocumento.documentocompra = nDocumentoCompra


        For Each r As Record In dgvCompensacion.Table.Records

            objDocumentoCompraDet = New documentocompradetalle

            objDocumentoCompraDet.secuencia = r.GetValue("secuencia")
            objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoCompraDet.IdEstablecimiento = GEstableciento.IdEstablecimiento
            objDocumentoCompraDet.FechaDoc = DateTime.Now
            objDocumentoCompraDet.FechaLaboral = New DateTime(DiaLaboral.Year, DiaLaboral.Month, DiaLaboral.Day, DiaLaboral.Hour, DiaLaboral.Minute, DiaLaboral.Second)

            objDocumentoCompraDet.TipoOperacion = "9918"
            objDocumentoCompraDet.operacionNota = "9918"
            objDocumentoCompraDet.destino = r.GetValue("grav")
            objDocumentoCompraDet.idItem = r.GetValue("idItem")
            objDocumentoCompraDet.descripcionItem = CStr(r.GetValue("descripcion"))
            objDocumentoCompraDet.tipoExistencia = CStr(r.GetValue("tipoEx"))
            objDocumentoCompraDet.importe = CDec(r.GetValue("pago"))
            objDocumentoCompraDet.importeUS = CDec(r.GetValue("pagome"))
            objDocumentoCompraDet.IdEstablecimiento = GEstableciento.IdEstablecimiento
            objDocumentoCompraDet.bonificacion = Nothing
            objDocumentoCompraDet.idPadreDTCompra = CInt(r.GetValue("secuencia"))
            '**********************************************************************************
            objDocumentoCompraDet.usuarioModificacion = usuario.IDUsuario
            objDocumentoCompraDet.fechaModificacion = DateTime.Now
            objDocumentoCompraDet.FechaVcto = Nothing ' IIf(IsNothing(dgvNuevoDoc.Rows(S).Cells(28).Value()), Nothing, CDate(dgvNuevoDoc.Rows(S).Cells(28).Value()))
            objDocumentoCompraDet.Glosa = "Compensacion de documentos"
            ' objDocumentoCompraDet.BonificacionMN =

            objDocumentoCompraDet.NumDoc = txtNumeroCompr.Text
            objDocumentoCompraDet.Serie = txtSerieCompr.Text
            objDocumentoCompraDet.TipoDoc = "9901"

            ListaDetalle.Add(objDocumentoCompraDet)
            '   End If
        Next
        '---------------------------------------------------------------------------------
        ndocumento.documentocompra.tipoOperacion = "18"
        'AsientoNotaCreditoNormal(ListadoExistencias)

        asiento = asientoCaja()
        ListaAsiento.Add(asiento)
        ndocumento.asiento = ListaAsiento

        ndocumento.documentocompra.documentocompradetalle = ListaDetalle

        '/////////////////DOCUMENTO COMPENSATORIO ////////////////
        With ndocumentoComp
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            If Not IsNothing(GProyectos) Then
                .idProyecto = GProyectos.IdProyectoActividad
            End If

            .tipoDoc = "9901"
            .fechaProceso = DateTime.Now
            .nroDoc = TextBoxExt4.Text & "-" & TextBoxExt3.Text.Trim

            .idOrden = Nothing ' Me.IdOrden
            .moneda = IIf(txtMon.Text = 1, "1", "2")
            .idEntidad = CInt(txtProveedor.Tag)
            .entidad = txtProveedor.Text
            .nrodocEntidad = txtRuc.Text
            .tipoEntidad = lblTipoEntidad.Text
            .tipoOperacion = "18"
            .usuarioActualizacion = "NN"
            .fechaActualizacion = DateTime.Now
        End With

        With nDocumentoCompraComp
            .idPadre = lblIdDocumentoComp.Text
            .codigoLibro = "8"
            .tipoDoc = "9901"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = DateTime.Now
            .fechaLaboral = New DateTime(DiaLaboral.Year, DiaLaboral.Month, DiaLaboral.Day, DiaLaboral.Hour, DiaLaboral.Minute, DiaLaboral.Second)
            .fechaContable = PeriodoGeneral
            .serie = TextBoxExt4.Text
            .numeroDoc = TextBoxExt3.Text.Trim
            .idProveedor = CInt(txtProveedor.Tag)
            .nombreProveedor = txtProveedor.Text
            .monedaDoc = IIf(txtMon.Text = 1, "1", "2")
            .tasaIgv = CDec(txtIva.Text)    ' IIf(IsNothing(nudIgv.Value) Or String.IsNullOrEmpty(nudIgv.Value) Or String.IsNullOrWhiteSpace(nudIgv.Value), Nothing, Trim(nudIgv.Value))
            .tcDolLoc = CDec(txtTipoCambio.Text)
            .tipoRecaudo = Nothing
            .regimen = Nothing
            .tasaRegimen = 0
            .nroRegimen = Nothing
            '****************** DESTINO EN SOLES ************************************************************************
            '.bi01 = TotalesXcanbeceras.base1.GetValueOrDefault
            '.bi02 = TotalesXcanbeceras.base2.GetValueOrDefault

            '.igv01 = TotalesXcanbeceras.MontoIgv1.GetValueOrDefault
            '.igv02 = TotalesXcanbeceras.MontoIgv2.GetValueOrDefault


            '****************** DESTINO EN DOLARES ************************************************************************
            '.bi01us = TotalesXcanbeceras.base1me.GetValueOrDefault
            '.bi02us = TotalesXcanbeceras.base2me.GetValueOrDefault

            '.igv01us = TotalesXcanbeceras.MontoIgv1me.GetValueOrDefault
            '.igv02us = TotalesXcanbeceras.MontoIgv2me.GetValueOrDefault

            '****************************************************************************************************************
            .importeTotal = txttotalcomp2.Text
            .importeUS = txttotalcomp2me.Text
            .destino = "COMP"
            .glosa = "Compensacion de Documentos"
            .referenciaDestino = Nothing ' IIf(IsNothing(txtDestinoref.Text) Or String.IsNullOrEmpty(txtDestinoref.Text) Or String.IsNullOrWhiteSpace(txtDestinoref.Text), Nothing, Trim(txtDestinoref.Text.Trim))
            .tipoCompra = "COMP"
            .situacion = "ALTF"
            ' .DocumentoSustentado = "S"
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
            .sustentado = "01" 'strTipoNota
            .aprobado = "S"
            .CajaSeleccionada = Nothing

        End With
        ndocumentoComp.documentocompra = nDocumentoCompraComp


        For Each rx As Record In dgvDetCompensacion.Table.Records

            objDocumentoCompraDet = New documentocompradetalle

            objDocumentoCompraDet.secuencia = rx.GetValue("Sec")
            objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoCompraDet.IdEstablecimiento = GEstableciento.IdEstablecimiento
            objDocumentoCompraDet.FechaDoc = DateTime.Now
            objDocumentoCompraDet.FechaLaboral = New DateTime(DiaLaboral.Year, DiaLaboral.Month, DiaLaboral.Day, DiaLaboral.Hour, DiaLaboral.Minute, DiaLaboral.Second)

            objDocumentoCompraDet.TipoOperacion = "9918"
            objDocumentoCompraDet.operacionNota = "9918"
            objDocumentoCompraDet.destino = rx.GetValue("grav")
            objDocumentoCompraDet.idItem = rx.GetValue("idItem")
            objDocumentoCompraDet.descripcionItem = CStr(rx.GetValue("Descrip"))
            objDocumentoCompraDet.tipoExistencia = CStr(rx.GetValue("tipoEx"))
            objDocumentoCompraDet.importe = CDec(rx.GetValue("importemn"))
            objDocumentoCompraDet.importeUS = CDec(rx.GetValue("importeme"))
            objDocumentoCompraDet.IdEstablecimiento = GEstableciento.IdEstablecimiento
            objDocumentoCompraDet.bonificacion = Nothing
            objDocumentoCompraDet.idPadreDTCompra = CInt(rx.GetValue("Sec"))
            '**********************************************************************************
            objDocumentoCompraDet.usuarioModificacion = usuario.IDUsuario
            objDocumentoCompraDet.fechaModificacion = DateTime.Now
            objDocumentoCompraDet.FechaVcto = Nothing ' IIf(IsNothing(dgvNuevoDoc.Rows(S).Cells(28).Value()), Nothing, CDate(dgvNuevoDoc.Rows(S).Cells(28).Value()))
            objDocumentoCompraDet.Glosa = "Compensacion de documentos"
            ' objDocumentoCompraDet.BonificacionMN =

            objDocumentoCompraDet.NumDoc = txtNumeroCompr.Text
            objDocumentoCompraDet.Serie = txtSerieCompr.Text
            objDocumentoCompraDet.TipoDoc = "9901"

            ListaDetalleComp.Add(objDocumentoCompraDet)
            '   End If
        Next
        '---------------------------------------------------------------------------------
        ndocumentoComp.documentocompra.tipoOperacion = "18"
        'AsientoNotaCreditoNormal(ListadoExistencias)
        asiento2 = asientoCaja2()
        ListaAsiento2.Add(asiento2)
        ndocumentoComp.asiento = ListaAsiento2

        ndocumentoComp.documentocompra.documentocompradetalle = ListaDetalleComp




        Dim xcod As Integer = CompraSA.CompensacionDocumentos(ndocumento, ndocumentoComp)
        lblEstado.Text = "nota de crédito registrada!"
        Dispose()
    End Sub

    Sub GridCFG(GGC As GridGroupingControl)
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True

        Dim colorx As New GridMetroColors()

        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        GGC.SetMetroStyle(colorx)
        GGC.BorderStyle = System.Windows.Forms.BorderStyle.None
        '  GGC.BrowseOnly = True
        GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        GGC.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
        GGC.TableOptions.SelectionBackColor = Color.Gray

        GGC.AllowProportionalColumnSizing = False
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center

        GGC.Table.DefaultColumnHeaderRowHeight = 25
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub



    Sub PagoDocumentos()

        Dim dt As New DataTable
        'dt.Columns.Add("idDocumento", GetType(Integer))
        'dt.Columns.Add("idsecuencia", GetType(Integer))
        'dt.Columns.Add("detalle", GetType(String))
        'dt.Columns.Add("monto", GetType(Decimal))
        'dt.Columns.Add("montome", GetType(Decimal))
        'dt.Columns.Add("iditem", GetType(Integer))
        'dt.Columns.Add("tipocambio", GetType(Decimal))
        'dt.Columns.Add("cuenta", GetType(String))

        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("secuencia", GetType(Integer))
        dt.Columns.Add("descripcion", GetType(String))
        dt.Columns.Add("montomn", GetType(Decimal))
        dt.Columns.Add("montome", GetType(Decimal))
        dt.Columns.Add("idDoc", GetType(Integer))
        dt.Columns.Add("Sec", GetType(Integer))
        dt.Columns.Add("Descrip", GetType(String))
        dt.Columns.Add("montoDoc", GetType(Decimal))
        dt.Columns.Add("montoDocME", GetType(Decimal))
        dt.Columns.Add("importemn", GetType(Decimal))
        dt.Columns.Add("importeme", GetType(Decimal))

        dt.Columns.Add("tipoEx", GetType(String))
        dt.Columns.Add("grav", GetType(String))
        dt.Columns.Add("idItem", GetType(Integer))


        'Dim dt As New DataTable

        For Each j In listaCompensatorio

            Dim nudSaldo As Decimal = j.ImporteNacional
            'Dim nudSaldoME As Decimal = j.importeUS
            Dim nudSaldoME As Decimal = j.ImporteNacional / TmpTipoCambioTransaccionVenta
            Dim cSaldo As Decimal = 0
            Dim cSaldoex As Decimal = 0
            Dim cSaldoME As Decimal = 0
            Dim cSaldoexME As Decimal = 0
            'Dim PagoActual As Decimal = j.importeTotal
            'Dim PagoActualME As Decimal = j.importeTotal / TmpTipoCambioTransaccionVenta
            Dim PagoActual As Decimal = CDec(0.0)
            Dim PagoActualME As Decimal = CDec(0.0)




            For Each i As Record In dgvCompensacion.Table.Records
                If nudSaldo > 0 Then

                    If i.GetValue("saldo") > 0 Then



                        If nudSaldo > 0 Then

                            cSaldo = Math.Round((CDec(i.GetValue("saldo"))), 2) - nudSaldo
                            If cSaldo >= 0 Then
                                'nudSaldo += Math.Round((CDec(i.GetValue("pago"))), 2)
                                i.SetValue("pago", nudSaldo + CDec(i.GetValue("pago")))
                                i.SetValue("saldo", cSaldo)

                                i.SetValue("pagome", CDec(i.GetValue("pago")) / TmpTipoCambioTransaccionVenta)
                                i.SetValue("saldome", (nudSaldo + CDec(i.GetValue("pago"))) / TmpTipoCambioTransaccionVenta)

                                PagoActual = nudSaldo
                                PagoActualME = nudSaldo / TmpTipoCambioTransaccionVenta


                                nudSaldo = 0

                                dt.Rows.Add(i.GetValue("idDocumento"), i.GetValue("secuencia"), i.GetValue("descripcion"), i.GetValue("importe"), i.GetValue("importeme"),
                                    j.idDocumento, j.secuencia, j.DetalleItem, j.ImporteNacional, j.ImporteExtranjero, PagoActual, PagoActualME, j.TipoExistencia, j.destino, j.idItem)
                            Else
                                PagoActual = CDec(i.GetValue("saldo"))
                                PagoActualME = CDec(i.GetValue("saldo")) / TmpTipoCambioTransaccionVenta

                                i.SetValue("pago", CDec(i.GetValue("saldo")) + CDec(i.GetValue("pago")))
                                i.SetValue("saldo", CDec(0.0))

                                i.SetValue("pagome", ((CDec(i.GetValue("saldo")) + CDec(i.GetValue("pago")))) / TmpTipoCambioTransaccionVenta)
                                i.SetValue("saldome", CDec(0.0))

                                'PagoActual = nudSaldo
                                'PagoActualME = (nudSaldo) / TmpTipoCambioTransaccionVenta


                                nudSaldo = cSaldo * -1


                                dt.Rows.Add(i.GetValue("idDocumento"), i.GetValue("secuencia"), i.GetValue("descripcion"), i.GetValue("importe"), i.GetValue("importeme"),
                                    j.idDocumento, j.secuencia, j.DetalleItem, j.ImporteNacional, j.ImporteExtranjero, PagoActual, PagoActualME, j.TipoExistencia, j.destino, j.idItem)
                            End If

                        Else
                            'i.SetValue("saldo", CDec(i.GetValue("saldo")))
                            'i.SetValue("saldome", CDec(i.GetValue("saldome")))
                        End If

                    End If

                    'If nudSaldoME > 0 Then
                    '    cSaldoME = Math.Round((CDec(i.GetValue("saldome"))), 2) - nudSaldoME
                    '    If cSaldoME >= 0 Then


                    '        i.SetValue("pagome", nudSaldoME)
                    '        i.SetValue("saldopme", cSaldoME)
                    '        nudSaldoME = 0

                    '    Else
                    '        i.SetValue("pagome", CDec(i.GetValue("saldome")))
                    '        i.SetValue("saldopme", CDec(0.0))
                    '        nudSaldoME = cSaldoME * -1

                    '    End If

                    'Else

                    '    i.SetValue("saldopme", CDec(i.GetValue("saldome")))

                    'End If

                    'If i.GetValue("pago") > 0 Then
                    '    dt.Rows.Add(i.GetValue("idDocumento"), i.GetValue("secuencia"), i.GetValue("descripcion"), i.GetValue("saldo"), i.GetValue("saldome"),
                    '                j.idDocumento, j.secuencia, j.DetalleItem, PagoActual, PagoActualME)
                    'End If


                End If
            Next

        Next


        dgvDetCompensacion.DataSource = dt

        Dim pagototal As Decimal = CDec(0.0)
        Dim pagototalme As Decimal = CDec(0.0)
        For Each x As Record In dgvCompensacion.Table.Records
            pagototal += x.GetValue("pago")
            pagototalme += x.GetValue("pagome")
        Next

        txttotalcomp.Text = pagototal
        txttotalcompme.Text = pagototalme


        Dim pagototal2 As Decimal = CDec(0.0)
        Dim pagototalme2 As Decimal = CDec(0.0)
        For Each v As Record In dgvDetCompensacion.Table.Records
            pagototal2 += v.GetValue("importemn")
            pagototalme2 += v.GetValue("importeme")
        Next


        txttotalcomp2.Text = pagototal2
        txttotalcomp2me.Text = pagototalme2

    End Sub




    Public Property TipoDocGobal() As String
    Public Sub UbicarDetalle(intIddocumento As Integer)
        Dim detalleSA As New DocumentoCompraDetalleSA
        Dim objLista As New DocumentoCajaDetalleSA
        Dim detalle As New documentocompradetalle
        Dim compraSA As New DocumentoCompraSA
        Dim entidadSA As New entidadSA
        Dim dt As New DataTable
        Dim listacomp As New documentoCajaDetalle
        Dim cTotalmn As Decimal = 0
        Dim cTotalme As Decimal = 0
        Dim cCreditomn As Decimal = 0
        Dim cCreditome As Decimal = 0
        Dim cDebitomn As Decimal = 0
        Dim cDebitome As Decimal = 0

        Dim cCantidadNC As Decimal = 0
        Dim cCantidadDB As Decimal = 0
        Dim cTotalCantidad As Decimal = 0
        Dim saldoCantidad As Decimal = 0
        TipoDocGobal = String.Empty
        Try


            With compraSA.UbicarDocumentoCompra(intIddocumento)
                lblIdDocumentoComp.Text = .idDocumento

                txtTipoDoc.Tag = .tipoCompra
                If .monedaDoc = "1" Then
                    txtMon.Text = "1"
                    'MostrarColumnsByMoneda("1")


                ElseIf .monedaDoc = "2" Then
                    txtMon.Text = "2"
                    'MostrarColumnsByMoneda("2")
                End If


                txtTipoCambio.Text = .tcDolLoc
                txtTipoCambio.ReadOnly = True
                txtIva.Text = .tasaIgv
                txtImpFacmn.DecimalValue = .importeTotal
                txtImpFacme.DecimalValue = .importeUS


                Dim tablaSA As New tablaDetalleSA

                txtTipoDoc.Text = tablaSA.GetUbicarTablaID(CInt(10), .tipoDoc).descripcion
                TipoDocGobal = .tipoDoc
                TextBoxExt4.Text = .serie
                TextBoxExt3.Text = .numeroDoc

            End With

            Dim saldomn As Decimal = 0
            Dim saldome As Decimal = 0



            For Each i As documentoCajaDetalle In objLista.ObtenerCuentasPorPagarPorDetails(intIddocumento)
                detalle = detalleSA.SumaNotasXidPadreItem(i.secuencia)

                saldoCantidad = i.CantidadCompra - detalle.monto1
                cTotalmn = CDec(i.MontoDeudaSoles) - detalle.importe - CDec(i.MontoPagadoSoles) + detalle.ImporteDBMN
                cTotalme = CDec(i.MontoDeudaUSD) - detalle.importeUS - CDec(i.MontoPagadoUSD) + detalle.ImporteDBME

                saldomn += cTotalmn
                saldome += cTotalme

                saldomn += cTotalmn
                saldome += cTotalme

                Dim dr As DataRow = dt.NewRow()

                listacomp = New documentoCajaDetalle

                listacomp.idDocumento = i.idDocumento
                listacomp.secuencia = i.secuencia
                listacomp.destino = i.destino
                listacomp.idItem = i.idItem
                listacomp.DetalleItem = i.DetalleItem
                listacomp.TipoExistencia = i.TipoExistencia

                Select Case i.TipoExistencia
                    Case "GS"
                        listacomp.CantidadCompra = 0
                    Case Else
                        If IsNothing(detalle) Then
                            listacomp.CantidadCompra = 0
                        Else
                            listacomp.CantidadCompra = i.CantidadCompra - detalle.monto1  ' detalle.monto1
                        End If
                End Select

                If cTotalmn < 0 Then
                    cTotalmn = 0
                End If
                listacomp.ImporteNacional = cTotalmn
                'dr(7) = 0
                If cTotalme < 0 Then
                    listacomp.ImporteExtranjero = 0
                End If
                listacomp.ImporteExtranjero = cTotalme
                listacomp.TipoExistencia = i.TipoExistencia
                listacomp.almacenRef = i.almacenRef

                listacomp.CantidadCompra = i.CantidadCompra

                'dr(12) = i.MontoDeudaSoles
                'dr(13) = i.MontoDeudaUSD
                'dr(14) = i.montokardex
                'dr(15) = i.montokardexus
                'dr(16) = i.montoIgv
                'dr(17) = i.montoIgvUS
                'Select Case dgvCompra.Table.CurrentRecord.GetValue("tipoCompra")
                '    Case TIPO_COMPRA.COMPRA_SERVICIO_PUBLICO, TIPO_COMPRA.COMPRA_RECIBO_HONORARIOS
                '        dr(18) = "3"
                '    Case Else
                '        dr(18) = "2"
                'End Select


                'Select Case i.EstadoCobro
                '    Case TIPO_COMPRA.PAGO.PAGADO

                '        dr(29) = "Pagado"
                '    Case Else
                '        dr(29) = "Pendiente"

                'End Select

                listaCompensatorio.Add(listacomp)
            Next
            PagoDocumentos()
            '    Me.dgvMov.TableOptions.ListBoxSelectionMode = SelectionMode.One

        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub



    Public Sub UbicarDetallePago(intIddocumento As Integer)
        Dim detalleSA As New DocumentoCompraDetalleSA
        Dim objLista As New DocumentoCajaDetalleSA
        Dim detalle As New documentocompradetalle
        Dim compraSA As New documentoVentaAbarrotesSA
        Dim entidadSA As New entidadSA
        Dim dt As New DataTable
        Dim listacomp As New documentoCajaDetalle
        Dim cTotalmn As Decimal = 0
        Dim cTotalme As Decimal = 0
        Dim cCreditomn As Decimal = 0
        Dim cCreditome As Decimal = 0
        Dim cDebitomn As Decimal = 0
        Dim cDebitome As Decimal = 0

        Dim cCantidadNC As Decimal = 0
        Dim cCantidadDB As Decimal = 0
        Dim cTotalCantidad As Decimal = 0
        Dim saldoCantidad As Decimal = 0
        TipoDocGobal = String.Empty
        Try

            With compraSA.GetUbicar_documentoventaAbarrotesPorID(intIddocumento)
                lblIdDocumentoComp.Text = .idDocumento

                txtTipoDoc.Tag = .tipoVenta
                If .moneda = "1" Then
                    txtMon.Text = "1"
                    'MostrarColumnsByMoneda("1")
                ElseIf .moneda = "2" Then
                    txtMon.Text = "2"
                    'MostrarColumnsByMoneda("2")
                End If

                txtTipoCambio.Text = .tipoCambio
                txtTipoCambio.ReadOnly = True
                txtIva.Text = .tasaIgv
                txtImpFacmn.DecimalValue = .ImporteNacional
                txtImpFacme.DecimalValue = .ImporteExtranjero

                Dim tablaSA As New tablaDetalleSA

                txtTipoDoc.Text = tablaSA.GetUbicarTablaID(CInt(10), .tipoDocumento).descripcion
                TipoDocGobal = .tipoDocumento
                TextBoxExt4.Text = .serie
                TextBoxExt3.Text = .numeroDoc

            End With

            Dim saldomn As Decimal = 0
            Dim saldome As Decimal = 0


            For Each i As documentoCajaDetalle In objLista.ObtenerCuentasPorCobrarPorDetails(intIddocumento)
                detalle = detalleSA.SumaNotasXidPadreItem(i.secuencia)

                saldoCantidad = i.CantidadCompra - detalle.monto1
                cTotalmn = CDec(i.MontoDeudaSoles) - detalle.importe - CDec(i.MontoPagadoSoles) + detalle.ImporteDBMN
                cTotalme = CDec(i.MontoDeudaUSD) - detalle.importeUS - CDec(i.MontoPagadoUSD) + detalle.ImporteDBME

                saldomn += cTotalmn
                saldome += cTotalme

                saldomn += cTotalmn
                saldome += cTotalme

                Dim dr As DataRow = dt.NewRow()

                listacomp = New documentoCajaDetalle

                listacomp.idDocumento = i.idDocumento
                listacomp.secuencia = i.secuencia
                listacomp.destino = i.destino
                listacomp.idItem = i.idItem
                listacomp.DetalleItem = i.DetalleItem
                listacomp.TipoExistencia = i.TipoExistencia

                Select Case i.TipoExistencia
                    Case "GS"
                        listacomp.CantidadCompra = 0
                    Case Else
                        If IsNothing(detalle) Then
                            listacomp.CantidadCompra = 0
                        Else
                            listacomp.CantidadCompra = i.CantidadCompra - detalle.monto1  ' detalle.monto1
                        End If
                End Select

                If cTotalmn < 0 Then
                    cTotalmn = 0
                End If
                listacomp.ImporteNacional = cTotalmn
                'dr(7) = 0
                If cTotalme < 0 Then
                    listacomp.ImporteExtranjero = 0
                End If
                listacomp.ImporteExtranjero = cTotalme
                listacomp.TipoExistencia = i.TipoExistencia
                listacomp.almacenRef = i.almacenRef

                listacomp.CantidadCompra = i.CantidadCompra

                'dr(12) = i.MontoDeudaSoles
                'dr(13) = i.MontoDeudaUSD
                'dr(14) = i.montokardex
                'dr(15) = i.montokardexus
                'dr(16) = i.montoIgv
                'dr(17) = i.montoIgvUS
                'Select Case dgvCompra.Table.CurrentRecord.GetValue("tipoCompra")
                '    Case TIPO_COMPRA.COMPRA_SERVICIO_PUBLICO, TIPO_COMPRA.COMPRA_RECIBO_HONORARIOS
                '        dr(18) = "3"
                '    Case Else
                '        dr(18) = "2"
                'End Select


                'Select Case i.EstadoCobro
                '    Case TIPO_COMPRA.PAGO.PAGADO

                '        dr(29) = "Pagado"
                '    Case Else
                '        dr(29) = "Pendiente"

                'End Select

                listaCompensatorio.Add(listacomp)
            Next
            PagoDocumentos()
            '    Me.dgvMov.TableOptions.ListBoxSelectionMode = SelectionMode.One

        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub




#Region "TIMER"
    Sub parpadeo()
        Static parpadear As Boolean



        parpadear = Not parpadear
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If TiempoRestante > 0 Then
            parpadeo()

            'lblAgregar.Visible = True
            'lblMensaje.Visible = True
            'tsSave.Enabled = False
            'lblMensaje.Text = "Agregar otro en: " & TiempoRestante
            TiempoRestante = TiempoRestante - 1
        ElseIf TiempoRestante = 0 Then
            Timer1.Enabled = False
            'lblEstado.ForeColor = Color.Navy
            'lblEstado.BackColor = Color.Transparent
            PanelError.Visible = False
            '      Dispose()
        Else
            Timer1.Enabled = False
            'Ejecuta tu función cuando termina el tiempo
            TiempoEjecutar(10)

        End If
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

    Sub ConfiguracionInicio()

        'configurando docking manager
        Me.WindowState = FormWindowState.Maximized
        dockingManager1.DockControlInAutoHideMode(Panel8, DockingStyle.Right, 565)
        dockingManager1.SetDockLabel(Panel8, "Compras")
        dockingManager1.CloseEnabled = False
        'If Not IsNothing(GFichaUsuarios) Then
        'ToolStripButton1.Image = ImageListAdv1.Images(1)
        'Else
        '    ToolStripButton1.Image = ImageListAdv1.Images(0)
        '    GFichaUsuarios = Nothing
        'End If
        dgvCompra.ShowRowHeaders = False
        'confgiurando variables generales
        ' lblPerido.Text = PeriodoGeneral
        txtPeriodoCompras.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
        ' txtFecha.Value = New Date(CInt(AnioGeneral), CInt(MesGeneral), DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        ' txtFecha.Select()
    End Sub


    Private Sub UbicarCompraXProveedorNroSerie(RucProveedor As String, strPeriodo As String)
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim documentoCompra As New List(Of documentocompra)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable

        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("tipoCompra", GetType(String))
        dt.Columns.Add("Fecha", GetType(String))
        dt.Columns.Add("periodo", GetType(String))

        dt.Columns.Add("TipoDoc", GetType(String))
        dt.Columns.Add("Serie", GetType(String))
        dt.Columns.Add("Numero", GetType(String))
        dt.Columns.Add("moneda", GetType(String))
        dt.Columns.Add("montoMN", GetType(Decimal))
        dt.Columns.Add("montoME", GetType(Decimal))
        dt.Columns.Add("cuotas", GetType(Integer))



        documentoCompra = documentoCompraSA.UbicarComprasXCompensar(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, RucProveedor, strPeriodo)

        Dim str As String
        If Not IsNothing(documentoCompra) Then
            Dim SaldoPagosMN As Decimal = 0
            Dim SaldoPagosME As Decimal = 0
            For Each i In documentoCompra

                SaldoPagosMN = 0
                SaldoPagosME = 0

                SaldoPagosMN = i.importeTotal - i.PagoSumaMN
                SaldoPagosME = i.importeUS - i.PagoSumaME

                'nota de credito
                SaldoPagosMN = SaldoPagosMN - i.PagoNotaCreditoMN + i.PagoNotaDebitoMN
                SaldoPagosME = SaldoPagosME - i.PagoNotaCreditoME + i.PagoNotaDebitoME


                Dim dr As DataRow = dt.NewRow()
                str = Nothing
                str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
                dr(0) = i.idDocumento
                dr(1) = i.tipoCompra
                dr(2) = str
                dr(3) = i.fechaContable
                dr(4) = tablaSA.GetUbicarTablaID(10, i.tipoDoc).descripcion.Substring(0, 3)
                dr(5) = i.serie
                dr(6) = i.numeroDoc
                Select Case i.monedaDoc
                    Case 1
                        dr(7) = "NAC"
                    Case Else
                        dr(7) = "EXT"

                End Select
                'dr(8) = i.importeTotal
                'dr(9) = i.importeUS
                dr(8) = SaldoPagosMN
                dr(9) = SaldoPagosME

                dr(10) = i.conteoCuotas

                dt.Rows.Add(dr)
            Next
            dgvCompra.DataSource = dt

        Else

        End If
    End Sub


    Public Sub btnNuevoCobro(strMoneda As String, IDDocumentoCompra As Integer)
        Me.Cursor = Cursors.WaitCursor
        Dim objLista As New DocumentoCajaDetalleSA


        Dim dt As New DataTable
        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("secuencia", GetType(Integer))
        dt.Columns.Add("descripcion", GetType(String))
        dt.Columns.Add("importe", GetType(Decimal))
        dt.Columns.Add("importeme", GetType(Decimal))
        dt.Columns.Add("pago", GetType(Decimal))
        dt.Columns.Add("pagome", GetType(Decimal))
        dt.Columns.Add("saldo", GetType(Decimal))
        dt.Columns.Add("saldome", GetType(Decimal))

        dt.Columns.Add("tipoEx", GetType(String))
        dt.Columns.Add("grav", GetType(String))
        dt.Columns.Add("idItem", GetType(Integer))


        Dim saldomn As Decimal = 0
        Dim saldome As Decimal = 0

        Dim cTotalmn As Decimal = 0
        Dim cTotalme As Decimal = 0
        Dim cCreditomn As Decimal = 0
        Dim cCreditome As Decimal = 0
        Dim cDebitomn As Decimal = 0
        Dim cDebitome As Decimal = 0
        Dim detalle As New documentoventaAbarrotesDet
        Dim detalleSA As New documentoVentaAbarrotesDetSA

        'Select Case TipoCompra

        '    Case TIPO_VENTA.VENTA_NORMAL_CREDITO
        'With frmCobros
        '.dgvDetalleItems.Rows.Clear()
        '.manipulacionEstado = ENTITY_ACTIONS.INSERT
        '.CaptionLabels(0).Text = "COBROS - " & txtCliente.Text
        Select Case strMoneda
            Case "NAC"
                'If TabPageCobranzaCli Is TabCuentasCobrar.SelectedTab Then
                '    .lblIdProveedor = CStr(txtCliente.Tag)
                '    .lblNomProveedor = txtCliente.Text
                '    .lblCuentaProveedor = "1212"
                '    .lblIdDocumento.Text = CStr(IDDocumentoCompra)
                '    'Nuevo Maykol correccion
                '    .txtProveedor.Text = txtCliente.Text
                '    .txtProveedor.Tag = txtCliente.Tag
                'ElseIf TabPageDevolucion Is TabCuentasCobrar.SelectedTab Then
                '    .lblIdProveedor = CStr(txtcliDev.Tag)
                '    .lblNomProveedor = txtcliDev.Text
                '    .lblCuentaProveedor = "1212"
                '    .lblIdDocumento.Text = CStr(IDDocumentoCompra)
                '    'Nuevo Maykol correccion
                '    .txtProveedor.Text = txtCliente.Text
                '    .txtProveedor.Tag = txtCliente.Tag
                'End If
                Dim documentoVenta As New List(Of documentoCajaDetalle)
                documentoVenta = objLista.ObtenerCuentasPorCobrarPorDetails(IDDocumentoCompra)



                If Not IsNothing(documentoVenta) Then
                    For Each i In documentoVenta
                        'If Not i.EstadoCobro = "DC" Then
                        Dim dr As DataRow = dt.NewRow()
                        'Str = Nothing
                        'Str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")

                        detalle = detalleSA.SumaNotasXidPadreItemVentas(i.secuencia)
                        'cTotalmn = CDec(CDec(i.MontoDeudaSoles) - detalle.importeMN - CDec(i.MontoPagadoSoles) + detalle.ImporteDBMN)
                        'cTotalme = CDec(CDec(i.MontoDeudaUSD) - detalle.importeME - CDec(i.MontoPagadoUSD) + detalle.ImporteDBME)
                        cTotalmn = CDec(CDec(i.MontoDeudaSoles) - detalle.importeMN - CDec(i.MontoPagadoSoles) + detalle.ImporteDBMN)
                        cTotalme = CDec(CDec(i.MontoDeudaUSD) - detalle.importeME - CDec(i.MontoPagadoUSD) + detalle.ImporteDBME)
                        If cTotalmn < 0 Then
                            cTotalmn = 0
                        End If
                        If cTotalme < 0 Then
                            cTotalme = 0
                        End If
                        dr(0) = i.idDocumento
                        dr(1) = i.secuencia
                        dr(2) = i.DetalleItem
                        dr(3) = cTotalmn
                        dr(4) = cTotalme
                        dr(5) = CDec(0.0)
                        dr(6) = CDec(0.0)
                        dr(7) = cTotalmn
                        dr(8) = cTotalme

                        dr(9) = i.TipoExistencia
                        dr(10) = i.destino
                        dr(11) = i.idItem




                        dt.Rows.Add(dr)
                        'End If
                    Next
                    dgvCompensacion.DataSource = dt
                    Me.dgvCompensacion.TableOptions.ListBoxSelectionMode = SelectionMode.One




                Else

                End If
                '    fghfh
                '    detalle = detalleSA.SumaNotasXidPadreItemVentas(i.secuencia)
                '    'cTotalmn = CDec(i.MontoDeudaSoles) - detalle.importe + detalle.ImporteDBMN - CDec(i.MontoPagadoSoles)
                '    'cTotalme = CDec(i.MontoDeudaUSD) - detalle.importeUS + detalle.ImporteDBME - CDec(i.MontoPagadoUSD)
                '    cTotalmn = CDec(CDec(i.MontoDeudaSoles) - detalle.importeMN - CDec(i.MontoPagadoSoles) + detalle.ImporteDBMN)
                '    cTotalme = CDec(CDec(i.MontoDeudaUSD) - detalle.importeME - CDec(i.MontoPagadoUSD) + detalle.ImporteDBME)
                '    If cTotalmn < 0 Then
                '        cTotalmn = 0
                '    End If
                '    If cTotalme < 0 Then
                '        cTotalme = 0
                '    End If
                '    saldomn += cTotalmn
                '    saldome += cTotalme
                '    If cTotalmn > 0 Or cTotalme > 0 Then
                '        .dgvDetalleItems.Rows.Add(i.idItem, i.DetalleItem, Nothing,
                '                                   Nothing, cTotalmn, cTotalme,
                '                                   "0.00", "0.00", "0.00", "0.00", Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT, i.secuencia)
                '    End If

                '    fghfgh



                'End If

                'txtImporteCompramn.Text = saldomn.ToString("N2")
                'txtImporteComprame.Text = saldome.ToString("N2")

                '.nudImporteNac.Maximum = CDec(lblPagoMN.Text)
                '.lblDeudaPendiente.Text = CStr(CDec(saldomn))
                '.lblDeudaPendienteme.Text = CStr(CDec(saldome))
                '.btnSaldoCobro.Text = CDec(saldomn)
                '.lblMonedaCobro.Text = "NACIONAL:"
                'Dim tablaSA As New tablaDetalleSA
                'Dim tablaBL As New tabladetalle

                'tablaBL = tablaSA.GetUbicarTablaID(10, CStr(dgvCobranzaCli.Table.CurrentRecord.GetValue("tipoDoc")))

                '.txtComprobante.Text = tablaBL.descripcion
                '.txtComprobante.Tag = tablaBL.codigoDetalle
                '.txtNumeroCompr.Text = dgvCobranzaCli.Table.CurrentRecord.GetValue("numero")
                '.txtSerieCompr.Text = dgvCobranzaCli.Table.CurrentRecord.GetValue("serie")

                '.lblTipoCambio.Text = dgvCobranzaCli.Table.CurrentRecord.GetValue("tipoCambio")
                '.txtFechaComprobante.Text = (dgvCobranzaCli.Table.CurrentRecord.GetValue("fecha"))

                'Select Case dgvCobranzaCli.Table.CurrentRecord.GetValue("moneda")
                '    Case "NAC"
                '        .tb19.ToggleState = ToggleButton2.ToggleButtonState.ON
                '    Case "EXT"
                '        .tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF
                'End Select

                '.pnSaldoMN.Location = New Point(25, 45)
                '.pnSaldoME.Location = New Point(25, 70)
                '.pnColorME.BackColor = Color.White
                '.pnColorMN.BackColor = Color.Yellow


            Case "EXT"
                'If TabPageCobranzaCli Is TabCuentasCobrar.SelectedTab Then
                '    .lblIdProveedor = CStr(txtCliente.Tag)
                '    .lblNomProveedor = txtCliente.Text
                '    .lblCuentaProveedor = "1212"
                '    .lblIdDocumento.Text = CStr(IDDocumentoCompra)
                '    'Nuevo Maykol correccion
                '    .txtProveedor.Text = txtCliente.Text
                '    .txtProveedor.Tag = txtCliente.Tag
                'ElseIf TabPageDevolucion Is TabCuentasCobrar.SelectedTab Then
                '    .lblIdProveedor = CStr(txtcliDev.Tag)
                '    .lblNomProveedor = txtcliDev.Text
                '    .lblCuentaProveedor = "1212"
                '    .lblIdDocumento.Text = CStr(IDDocumentoCompra)
                '    'Nuevo Maykol correccion
                '    .txtProveedor.Text = txtCliente.Text
                '    .txtProveedor.Tag = txtCliente.Tag
                'End If

                'For Each i As documentoCajaDetalle In objLista.ObtenerCuentasPorCobrarPorDetails(IDDocumentoCompra)
                '    If Not i.EstadoCobro = "DC" Then
                '        detalle = detalleSA.SumaNotasXidPadreItemVentas(i.secuencia)
                '        'cTotalmn = CDec(i.MontoDeudaSoles) - detalle.importe + detalle.ImporteDBMN - CDec(i.MontoPagadoSoles)
                '        'cTotalme = CDec(i.MontoDeudaUSD) - detalle.importeUS + detalle.ImporteDBME - CDec(i.MontoPagadoUSD)
                '        cTotalmn = CDec(CDec(i.MontoDeudaSoles) - detalle.importeMN - CDec(i.MontoPagadoSoles) + detalle.ImporteDBMN)
                '        cTotalme = CDec(CDec(i.MontoDeudaUSD) - detalle.importeME - CDec(i.MontoPagadoUSD) + detalle.ImporteDBME)
                '        If cTotalmn < 0 Then
                '            cTotalmn = 0
                '        End If
                '        If cTotalme < 0 Then
                '            cTotalme = 0
                '        End If
                '        saldomn += cTotalmn
                '        saldome += cTotalme
                '        If cTotalmn > 0 Or cTotalme > 0 Then
                '            .dgvDetalleItems.Rows.Add(i.idItem, i.DetalleItem, Nothing,
                '                                       Nothing, cTotalmn, cTotalme,
                '                                       "0.00", "0.00", "0.00", "0.00", Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT, i.secuencia)
                '        End If
                '    End If
                'Next
                ''txtImporteCompramn.Text = saldomn.ToString("N2")
                ''txtImporteComprame.Text = saldome.ToString("N2")

                ''.nudImporteNac.Maximum = CDec(lblPagoMN.Text)
                '.lblDeudaPendiente.Text = CStr(CDec(saldomn))
                '.lblDeudaPendienteme.Text = CStr((saldome))
                '.btnSaldoCobro.Text = CDec(saldome)
                '.lblMonedaCobro.Text = "EXTRANJERA:"
                'Dim tablaSA As New tablaDetalleSA
                'Dim tablaBL As New tabladetalle

                'tablaBL = tablaSA.GetUbicarTablaID(10, CStr(dgvCobranzaCli.Table.CurrentRecord.GetValue("tipoDoc")))

                '.txtComprobante.Text = tablaBL.descripcion
                '.txtComprobante.Tag = tablaBL.codigoDetalle
                '.txtNumeroCompr.Text = dgvCobranzaCli.Table.CurrentRecord.GetValue("numero")
                '.txtSerieCompr.Text = dgvCobranzaCli.Table.CurrentRecord.GetValue("serie")

                '.lblTipoCambio.Text = dgvCobranzaCli.Table.CurrentRecord.GetValue("tipoCambio")
                '.txtFechaComprobante.Text = (dgvCobranzaCli.Table.CurrentRecord.GetValue("fecha"))
                'Dim DSFS As String = dgvCobranzaCli.Table.CurrentRecord.GetValue("moneda")
                'Select Case dgvCobranzaCli.Table.CurrentRecord.GetValue("moneda")
                '    Case "NAC"
                '        .tb19.ToggleState = ToggleButton2.ToggleButtonState.ON
                '    Case "EXT"
                '        .tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF
                'End Select

                '.pnSaldoMN.Location = New Point(25, 70)
                '.pnSaldoME.Location = New Point(25, 45)
                '.pnColorME.BackColor = Color.Yellow
                '.pnColorMN.BackColor = Color.White


        End Select

        'If CDec(saldomn) <= 0 Then

        '    'lblEstado.Text = "El documento ya se encuentra pagado."
        '    'Timer1.Enabled = True
        '    'PanelError.Visible = True
        '    'TiempoEjecutar(10)
        '    MessageBox.Show("Ya esta Pagado")
        '    Me.Cursor = Cursors.Arrow
        '    Exit Sub
        'Else
        '    '    EditarEstadoPagoCompra(TIPO_COMPRA.PAGO.PENDIENTE_PAGO)

        '    'If .TieneCuentaFinanciera = True Then
        '    '.txtFechaComprobante.Value = New Date(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
        '    '.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
        '    '.txtFechaComprobante.Enabled = False
        '    '.lblPerido.Text = PeriodoGeneral
        '    '.cboTipoDocument.Enabled = True
        '    '.cboTipoDocument.ReadOnly = False
        '    '.StartPosition = FormStartPosition.CenterParent
        '    '.ShowDialog()
        '    'Else
        '    '    lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
        '    '    Timer1.Enabled = True
        '    '    PanelError.Visible = True
        '    '    TiempoEjecutar(10)
        '    'End If
        'End If
        ' End With
        'End Select
        Me.Cursor = Cursors.Arrow
    End Sub




    Public Sub btnNuevoPago(strMoneda As String, IDDocumentoCompra As Integer)
        Me.Cursor = Cursors.WaitCursor
        Dim objLista As New DocumentoCajaDetalleSA


        Dim dt As New DataTable
        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("secuencia", GetType(Integer))
        dt.Columns.Add("descripcion", GetType(String))
        dt.Columns.Add("importe", GetType(Decimal))
        dt.Columns.Add("importeme", GetType(Decimal))
        dt.Columns.Add("pago", GetType(Decimal))
        dt.Columns.Add("pagome", GetType(Decimal))
        dt.Columns.Add("saldo", GetType(Decimal))
        dt.Columns.Add("saldome", GetType(Decimal))

        dt.Columns.Add("tipoEx", GetType(String))
        dt.Columns.Add("grav", GetType(String))
        dt.Columns.Add("idItem", GetType(Integer))


        Dim saldomn As Decimal = 0
        Dim saldome As Decimal = 0

        Dim cTotalmn As Decimal = 0
        Dim cTotalme As Decimal = 0
        Dim cCreditomn As Decimal = 0
        Dim cCreditome As Decimal = 0
        Dim cDebitomn As Decimal = 0
        Dim cDebitome As Decimal = 0
        Dim detalle As New documentoventaAbarrotesDet
        Dim detalleSA As New documentoVentaAbarrotesDetSA

        'Select Case TipoCompra

        '    Case TIPO_VENTA.VENTA_NORMAL_CREDITO
        'With frmCobros
        '.dgvDetalleItems.Rows.Clear()
        '.manipulacionEstado = ENTITY_ACTIONS.INSERT
        '.CaptionLabels(0).Text = "COBROS - " & txtCliente.Text
        Select Case strMoneda
            Case "NAC"
                'If TabPageCobranzaCli Is TabCuentasCobrar.SelectedTab Then
                '    .lblIdProveedor = CStr(txtCliente.Tag)
                '    .lblNomProveedor = txtCliente.Text
                '    .lblCuentaProveedor = "1212"
                '    .lblIdDocumento.Text = CStr(IDDocumentoCompra)
                '    'Nuevo Maykol correccion
                '    .txtProveedor.Text = txtCliente.Text
                '    .txtProveedor.Tag = txtCliente.Tag
                'ElseIf TabPageDevolucion Is TabCuentasCobrar.SelectedTab Then
                '    .lblIdProveedor = CStr(txtcliDev.Tag)
                '    .lblNomProveedor = txtcliDev.Text
                '    .lblCuentaProveedor = "1212"
                '    .lblIdDocumento.Text = CStr(IDDocumentoCompra)
                '    'Nuevo Maykol correccion
                '    .txtProveedor.Text = txtCliente.Text
                '    .txtProveedor.Tag = txtCliente.Tag
                'End If
                Dim documentoVenta As New List(Of documentoCajaDetalle)
                documentoVenta = objLista.ObtenerCuentasPorPagarPorDetails(IDDocumentoCompra)



                If Not IsNothing(documentoVenta) Then
                    For Each i In documentoVenta
                        'If Not i.EstadoCobro = "DC" Then
                        Dim dr As DataRow = dt.NewRow()
                        'Str = Nothing
                        'Str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
                        'cTotalmn = CDec(CDec(i.MontoDeudaSoles) - detalle.importeMN - CDec(i.MontoPagadoSoles) + detalle.ImporteDBMN)
                        'cTotalme = CDec(CDec(i.MontoDeudaUSD) - detalle.importeME - CDec(i.MontoPagadoUSD) + detalle.ImporteDBME)
                        cTotalmn = CDec(i.MontoDeudaSoles) - CDec(i.MontoPagadoSoles)
                        cTotalme = CDec(i.MontoDeudaUSD) - CDec(i.MontoPagadoUSD)
                        If cTotalmn < 0 Then
                            cTotalmn = 0
                        End If
                        If cTotalme < 0 Then
                            cTotalme = 0
                        End If
                        dr(0) = i.idDocumento
                        dr(1) = i.secuencia
                        dr(2) = i.DetalleItem
                        dr(3) = cTotalmn
                        dr(4) = cTotalme
                        dr(5) = CDec(0.0)
                        dr(6) = CDec(0.0)
                        dr(7) = cTotalmn
                        dr(8) = cTotalme

                        dr(9) = i.TipoExistencia
                        dr(10) = i.destino
                        dr(11) = i.idItem




                        dt.Rows.Add(dr)
                        'End If
                    Next
                    dgvCompensacion.DataSource = dt
                    Me.dgvCompensacion.TableOptions.ListBoxSelectionMode = SelectionMode.One




                Else

                End If
                '    fghfh
                '    detalle = detalleSA.SumaNotasXidPadreItemVentas(i.secuencia)
                '    'cTotalmn = CDec(i.MontoDeudaSoles) - detalle.importe + detalle.ImporteDBMN - CDec(i.MontoPagadoSoles)
                '    'cTotalme = CDec(i.MontoDeudaUSD) - detalle.importeUS + detalle.ImporteDBME - CDec(i.MontoPagadoUSD)
                '    cTotalmn = CDec(CDec(i.MontoDeudaSoles) - detalle.importeMN - CDec(i.MontoPagadoSoles) + detalle.ImporteDBMN)
                '    cTotalme = CDec(CDec(i.MontoDeudaUSD) - detalle.importeME - CDec(i.MontoPagadoUSD) + detalle.ImporteDBME)
                '    If cTotalmn < 0 Then
                '        cTotalmn = 0
                '    End If
                '    If cTotalme < 0 Then
                '        cTotalme = 0
                '    End If
                '    saldomn += cTotalmn
                '    saldome += cTotalme
                '    If cTotalmn > 0 Or cTotalme > 0 Then
                '        .dgvDetalleItems.Rows.Add(i.idItem, i.DetalleItem, Nothing,
                '                                   Nothing, cTotalmn, cTotalme,
                '                                   "0.00", "0.00", "0.00", "0.00", Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT, i.secuencia)
                '    End If

                '    fghfgh



                'End If

                'txtImporteCompramn.Text = saldomn.ToString("N2")
                'txtImporteComprame.Text = saldome.ToString("N2")

                '.nudImporteNac.Maximum = CDec(lblPagoMN.Text)
                '.lblDeudaPendiente.Text = CStr(CDec(saldomn))
                '.lblDeudaPendienteme.Text = CStr(CDec(saldome))
                '.btnSaldoCobro.Text = CDec(saldomn)
                '.lblMonedaCobro.Text = "NACIONAL:"
                'Dim tablaSA As New tablaDetalleSA
                'Dim tablaBL As New tabladetalle

                'tablaBL = tablaSA.GetUbicarTablaID(10, CStr(dgvCobranzaCli.Table.CurrentRecord.GetValue("tipoDoc")))

                '.txtComprobante.Text = tablaBL.descripcion
                '.txtComprobante.Tag = tablaBL.codigoDetalle
                '.txtNumeroCompr.Text = dgvCobranzaCli.Table.CurrentRecord.GetValue("numero")
                '.txtSerieCompr.Text = dgvCobranzaCli.Table.CurrentRecord.GetValue("serie")

                '.lblTipoCambio.Text = dgvCobranzaCli.Table.CurrentRecord.GetValue("tipoCambio")
                '.txtFechaComprobante.Text = (dgvCobranzaCli.Table.CurrentRecord.GetValue("fecha"))

                'Select Case dgvCobranzaCli.Table.CurrentRecord.GetValue("moneda")
                '    Case "NAC"
                '        .tb19.ToggleState = ToggleButton2.ToggleButtonState.ON
                '    Case "EXT"
                '        .tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF
                'End Select

                '.pnSaldoMN.Location = New Point(25, 45)
                '.pnSaldoME.Location = New Point(25, 70)
                '.pnColorME.BackColor = Color.White
                '.pnColorMN.BackColor = Color.Yellow


            Case "EXT"
                'If TabPageCobranzaCli Is TabCuentasCobrar.SelectedTab Then
                '    .lblIdProveedor = CStr(txtCliente.Tag)
                '    .lblNomProveedor = txtCliente.Text
                '    .lblCuentaProveedor = "1212"
                '    .lblIdDocumento.Text = CStr(IDDocumentoCompra)
                '    'Nuevo Maykol correccion
                '    .txtProveedor.Text = txtCliente.Text
                '    .txtProveedor.Tag = txtCliente.Tag
                'ElseIf TabPageDevolucion Is TabCuentasCobrar.SelectedTab Then
                '    .lblIdProveedor = CStr(txtcliDev.Tag)
                '    .lblNomProveedor = txtcliDev.Text
                '    .lblCuentaProveedor = "1212"
                '    .lblIdDocumento.Text = CStr(IDDocumentoCompra)
                '    'Nuevo Maykol correccion
                '    .txtProveedor.Text = txtCliente.Text
                '    .txtProveedor.Tag = txtCliente.Tag
                'End If

                'For Each i As documentoCajaDetalle In objLista.ObtenerCuentasPorCobrarPorDetails(IDDocumentoCompra)
                '    If Not i.EstadoCobro = "DC" Then
                '        detalle = detalleSA.SumaNotasXidPadreItemVentas(i.secuencia)
                '        'cTotalmn = CDec(i.MontoDeudaSoles) - detalle.importe + detalle.ImporteDBMN - CDec(i.MontoPagadoSoles)
                '        'cTotalme = CDec(i.MontoDeudaUSD) - detalle.importeUS + detalle.ImporteDBME - CDec(i.MontoPagadoUSD)
                '        cTotalmn = CDec(CDec(i.MontoDeudaSoles) - detalle.importeMN - CDec(i.MontoPagadoSoles) + detalle.ImporteDBMN)
                '        cTotalme = CDec(CDec(i.MontoDeudaUSD) - detalle.importeME - CDec(i.MontoPagadoUSD) + detalle.ImporteDBME)
                '        If cTotalmn < 0 Then
                '            cTotalmn = 0
                '        End If
                '        If cTotalme < 0 Then
                '            cTotalme = 0
                '        End If
                '        saldomn += cTotalmn
                '        saldome += cTotalme
                '        If cTotalmn > 0 Or cTotalme > 0 Then
                '            .dgvDetalleItems.Rows.Add(i.idItem, i.DetalleItem, Nothing,
                '                                       Nothing, cTotalmn, cTotalme,
                '                                       "0.00", "0.00", "0.00", "0.00", Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT, i.secuencia)
                '        End If
                '    End If
                'Next
                ''txtImporteCompramn.Text = saldomn.ToString("N2")
                ''txtImporteComprame.Text = saldome.ToString("N2")

                ''.nudImporteNac.Maximum = CDec(lblPagoMN.Text)
                '.lblDeudaPendiente.Text = CStr(CDec(saldomn))
                '.lblDeudaPendienteme.Text = CStr((saldome))
                '.btnSaldoCobro.Text = CDec(saldome)
                '.lblMonedaCobro.Text = "EXTRANJERA:"
                'Dim tablaSA As New tablaDetalleSA
                'Dim tablaBL As New tabladetalle

                'tablaBL = tablaSA.GetUbicarTablaID(10, CStr(dgvCobranzaCli.Table.CurrentRecord.GetValue("tipoDoc")))

                '.txtComprobante.Text = tablaBL.descripcion
                '.txtComprobante.Tag = tablaBL.codigoDetalle
                '.txtNumeroCompr.Text = dgvCobranzaCli.Table.CurrentRecord.GetValue("numero")
                '.txtSerieCompr.Text = dgvCobranzaCli.Table.CurrentRecord.GetValue("serie")

                '.lblTipoCambio.Text = dgvCobranzaCli.Table.CurrentRecord.GetValue("tipoCambio")
                '.txtFechaComprobante.Text = (dgvCobranzaCli.Table.CurrentRecord.GetValue("fecha"))
                'Dim DSFS As String = dgvCobranzaCli.Table.CurrentRecord.GetValue("moneda")
                'Select Case dgvCobranzaCli.Table.CurrentRecord.GetValue("moneda")
                '    Case "NAC"
                '        .tb19.ToggleState = ToggleButton2.ToggleButtonState.ON
                '    Case "EXT"
                '        .tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF
                'End Select

                '.pnSaldoMN.Location = New Point(25, 70)
                '.pnSaldoME.Location = New Point(25, 45)
                '.pnColorME.BackColor = Color.Yellow
                '.pnColorMN.BackColor = Color.White


        End Select

        'If CDec(saldomn) <= 0 Then

        '    'lblEstado.Text = "El documento ya se encuentra pagado."
        '    'Timer1.Enabled = True
        '    'PanelError.Visible = True
        '    'TiempoEjecutar(10)
        '    MessageBox.Show("Ya esta Pagado")
        '    Me.Cursor = Cursors.Arrow
        '    Exit Sub
        'Else
        '    '    EditarEstadoPagoCompra(TIPO_COMPRA.PAGO.PENDIENTE_PAGO)

        '    'If .TieneCuentaFinanciera = True Then
        '    '.txtFechaComprobante.Value = New Date(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
        '    '.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
        '    '.txtFechaComprobante.Enabled = False
        '    '.lblPerido.Text = PeriodoGeneral
        '    '.cboTipoDocument.Enabled = True
        '    '.cboTipoDocument.ReadOnly = False
        '    '.StartPosition = FormStartPosition.CenterParent
        '    '.ShowDialog()
        '    'Else
        '    '    lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
        '    '    Timer1.Enabled = True
        '    '    PanelError.Visible = True
        '    '    TiempoEjecutar(10)
        '    'End If
        'End If
        ' End With
        'End Select
        Me.Cursor = Cursors.Arrow
    End Sub


    Private Sub UbicarVentaNroSerie(RucCliente As Integer, intMoneda As String)
        Dim documentoVentaSA As New documentoVentaAbarrotesSA
        Dim documentoVenta As New List(Of documentoventaAbarrotes)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodoCompras.Value.Month)) & "/" & txtPeriodoCompras.Value.Year

        'dt.Columns.Add("idDocumento", GetType(Integer))
        'dt.Columns.Add("fecha", GetType(String))
        'dt.Columns.Add("tipoVenta", GetType(String))
        'dt.Columns.Add("tipoDoc", GetType(String))
        'dt.Columns.Add("serie", GetType(String))
        'dt.Columns.Add("numero", GetType(String))
        'dt.Columns.Add("moneda", GetType(String))
        'dt.Columns.Add("importeMN", GetType(Decimal))
        'dt.Columns.Add("tipoCambio", GetType(Decimal))
        'dt.Columns.Add("importeME", GetType(Decimal))
        'dt.Columns.Add("abonoMN", GetType(Decimal))
        'dt.Columns.Add("abonoME", GetType(Decimal))
        'dt.Columns.Add("saldoMN", GetType(Decimal))
        'dt.Columns.Add("saldoME", GetType(Decimal))
        'dt.Columns.Add("estadoPago", GetType(String))

        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("tipoCompra", GetType(String))
        dt.Columns.Add("Fecha", GetType(String))
        dt.Columns.Add("periodo", GetType(String))

        dt.Columns.Add("TipoDoc", GetType(String))
        dt.Columns.Add("Serie", GetType(String))
        dt.Columns.Add("Numero", GetType(String))
        dt.Columns.Add("moneda", GetType(String))
        dt.Columns.Add("montoMN", GetType(Decimal))
        dt.Columns.Add("montoME", GetType(Decimal))
        'dt.Columns.Add("cuotas", GetType(Integer))




        documentoVenta = documentoVentaSA.UbicarVentaPorClienteXperiodo2(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, RucCliente, strPeriodo, intMoneda)
        Dim str As String
        If Not IsNothing(documentoVenta) Then
            For Each i In documentoVenta
                Dim dr As DataRow = dt.NewRow()
                str = Nothing
                str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
                dr(0) = i.idDocumento
                dr(1) = i.tipoVenta
                dr(2) = str
                dr(3) = i.fechaPeriodo
                dr(4) = tablaSA.GetUbicarTablaID(10, i.tipoDocumento).descripcion.Substring(0, 3)
                dr(5) = i.serie
                dr(6) = i.numeroDoc
                Select Case i.moneda
                    Case 1
                        dr(7) = "NAC"
                    Case Else
                        dr(7) = "EXT"

                End Select
                dr(8) = i.ImporteNacional - i.PagoSumaMN
                dr(9) = i.ImporteExtranjero - i.PagoSumaME

                'dr(0) = i.idDocumento
                'dr(1) = str
                'dr(2) = i.tipoVenta
                'dr(3) = i.tipoDocumento
                'dr(4) = i.serie
                'dr(5) = i.numeroDoc
                'Select Case i.moneda
                '    Case CStr(1)
                '        dr(6) = "NAC"
                '    Case Else
                '        dr(6) = "EXT"
                'End Select
                'dr(7) = i.ImporteNacional
                'dr(8) = i.tipoCambio
                'dr(9) = i.ImporteExtranjero
                'dr(10) = i.PagoSumaMN
                'dr(11) = i.PagoSumaME
                'dr(12) = CDec(i.ImporteNacional - i.PagoSumaMN).ToString("N2")
                'dr(13) = CDec(i.ImporteExtranjero - i.PagoSumaME).ToString("N2")

                'Select Case i.estadoCobro
                '    Case TIPO_VENTA.PAGO.COBRADO
                '        dr(14) = "Saldado"
                '    Case TIPO_VENTA.PAGO.PENDIENTE_PAGO
                '        dr(14) = "Pendiente"
                'End Select




                'Select Case i.estadoCobro
                '    Case TIPO_COMPRA.PAGO.PAGADO
                '        dr(14) = "Saldado"
                '    Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                '        dr(14) = "Pendiente"
                'End Select

                dt.Rows.Add(dr)
            Next
            dgvCompra.DataSource = dt
            Me.dgvCompra.TableOptions.ListBoxSelectionMode = SelectionMode.One

            'Select Case cboMonedaCobro.Text
            '    Case "NACIONAL"
            '        dgvCobranzaCli.TableDescriptor.Columns("importeMN").Width = 70
            '        dgvCobranzaCli.TableDescriptor.Columns("abonoMN").Width = 70
            '        dgvCobranzaCli.TableDescriptor.Columns("saldoMN").Width = 70
            '        dgvCobranzaCli.TableDescriptor.Columns("tipoCambio").Width = 0
            '        dgvCobranzaCli.TableDescriptor.Columns("importeME").Width = 0
            '        dgvCobranzaCli.TableDescriptor.Columns("abonoME").Width = 0
            '        dgvCobranzaCli.TableDescriptor.Columns("saldoME").Width = 0
            '    Case "EXTRANJERA"
            '        dgvCobranzaCli.TableDescriptor.Columns("tipoCambio").Width = 70
            '        dgvCobranzaCli.TableDescriptor.Columns("importeME").Width = 70
            '        dgvCobranzaCli.TableDescriptor.Columns("abonoME").Width = 70
            '        dgvCobranzaCli.TableDescriptor.Columns("saldoME").Width = 70
            '        dgvCobranzaCli.TableDescriptor.Columns("importeMN").Width = 0
            '        dgvCobranzaCli.TableDescriptor.Columns("abonoMN").Width = 0
            '        dgvCobranzaCli.TableDescriptor.Columns("saldoMN").Width = 0
            'End Select


        Else

        End If
    End Sub

#End Region

    Private Sub frmCompensacionDeDocumentos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click

        Me.Cursor = Cursors.WaitCursor
        Dim strPeriodo As String = String.Format("{0:00}", CInt(txtPeriodoCompras.Value.Month))
        strPeriodo = String.Concat(strPeriodo, "/", txtPeriodoCompras.Value.Year)

        If Label8.Text = "COMPRAS" Then
            UbicarCompraXProveedorNroSerie(txtRuc.Text, strPeriodo)
        ElseIf Label8.Text = "VENTAS" Then
            UbicarVentaXProveedorNroSerie(txtRuc.Text, strPeriodo)
        End If
        Me.Cursor = Cursors.Arrow
        'Me.Cursor = Cursors.WaitCursor
        'If txtProveedor.Text.Trim.Length > 0 Then

        '    'Select Case cboMonedaCobro.Text
        '    '    Case "NACIONAL"
        '    UbicarVentaNroSerie(txtProveedor.Tag, "1")

        '    '    Case "EXTRANJERA"
        '    '        UbicarVentaNroSerie(txtProveedor.Tag, "2")
        '    'End Select


        'Else
        '    'lblEstado.Text = "Seleccione un cliente antes de realizar la tarea!"
        '    'PanelError.Visible = True
        '    'Timer1.Enabled = True
        '    'TiempoEjecutar(10)
        '    MessageBox.Show("Seleccione un proveedor antes de realizar la tarea!")
        'End If
        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvCompra_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCompra.TableControlCellClick

    End Sub

    Private Sub dgvCompra_TableControlCurrentCellControlDoubleClick(sender As Object, e As GridTableControlControlEventArgs) Handles dgvCompra.TableControlCurrentCellControlDoubleClick
        Dim DocumentoCompraSA As New DocumentoCompraDetalleSA
        Me.Cursor = Cursors.WaitCursor
        'If DocumentoCompraSA.TieneItemsEnAV(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento")) = True Then
        '    PanelError.Visible = True
        '    lblEstado.Text = "El comprobante posee items en el almacen en transito, " & "necesita realizar la distribución, para seguir el proceso!"
        '    Timer1.Enabled = True
        '    TiempoEjecutar(10)
        '    Me.Cursor = Cursors.Arrow
        'Else
        dgvDetCompensacion.Table.Records.DeleteAll()
        For Each i As Record In dgvCompensacion.Table.Records

            i.SetValue("pago", CDec(0))
            i.SetValue("pagome", CDec(0))
            i.SetValue("saldo", i.GetValue("importe"))
            i.SetValue("saldome", i.GetValue("importeme"))
        Next

        listaCompensatorio.Clear()



        If Label8.Text = "COMPRAS" Then
            UbicarDetalle(dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
        ElseIf Label8.Text = "VENTAS" Then
            UbicarDetallePago(dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
        End If
        'End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub frmCompensacionDeDocumentos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub


    Private Sub btGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click

        Try
            If Not txtSerieCompr.Text.Trim.Length > 0 Then
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

            If Not txtNumeroCompr.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingresar un número de comprobante válido"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)

                Me.Cursor = Cursors.Arrow
                Exit Sub
            Else
                lblEstado.Text = "Done número comprobante"

            End If

            If Not txtProveedor.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingresar un proveedor válido"

                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)

                Me.Cursor = Cursors.Arrow
                Exit Sub
            Else
                lblEstado.Text = "Done proveedor"

            End If


            '***********************************************************************
            If dgvDetCompensacion.Table.Records.Count > 0 Then


                If Label8.Text = "COMPRAS" Then
                    Grabar()
                ElseIf Label8.Text = "VENTAS" Then
                    GrabarVenta()
                End If

            Else
                MessageBox.Show("No Hay Items por compensar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try

    End Sub

    Private Sub DockingClientPanel1_Paint(sender As Object, e As PaintEventArgs) Handles DockingClientPanel1.Paint

    End Sub
End Class
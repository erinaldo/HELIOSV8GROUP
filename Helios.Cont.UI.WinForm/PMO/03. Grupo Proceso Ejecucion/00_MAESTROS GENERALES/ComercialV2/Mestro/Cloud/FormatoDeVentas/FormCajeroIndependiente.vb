Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports ProcesosGeneralesCajamiSoft
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class FormCajeroIndependiente

#Region "Variables"
    Private listaActivas As List(Of cajaUsuario)

    Private FormImpresionNuevo As FormImpresionEquivalencia
    Public Alert As Alert
    Public Property BeneficioProduccionSA As New BeneficioProduccionConsumoSA
    Public Property ListaBeneficios As List(Of Business.Entity.beneficio)
    Public Property beneficioSA As New beneficioSA
    ' Public ListaEstadosFinancieros As List(Of estadosFinancieros)
    Public Property ListaAsientonTransito As New List(Of asiento)
    Dim entidadSA As New entidadSA
    Friend Delegate Sub SetDataSourceDelegate(ByVal lista As List(Of entidad))
    Public Property listaClientes As List(Of entidad)
    Public Property TipoVentaGeneral As String
    Public Grid As GridGroupingControl
    Public Totales As TotalesXcanbecera
    Public Property pagoAnticipo As documentoAnticipo

    Public Property DocumentoVenta As documentoventaAbarrotes
    Public Property frmInformacionFinanzas As frmInformacionFinanzas
    Public Property HistorialCajasUsuario As HistorialCajasUsuario

    ' Public Property CuentaEFECTIVO As estadosFinancieros
    Public Property CuentasHabilitadas As List(Of estadosFinancierosConfiguracionPagos)


    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData
            Case Keys.F2
                btOperacion.PerformClick()
            Case Keys.F7
                ToolImportar.PerformClick()
            Case Keys.F8
                ToolBuscarVenta.PerformClick()
            Case Keys.F9
                ToolSeguimientoCaja.PerformClick()
            Case Keys.F10
                ToolCerracaja.PerformClick()
        End Select

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        HabilitarPago(False)
        FormatoGridAvanzado(dgvCuentas, False, False)
        GetColumnsGrid()
        'GridVenta = Grid
        Me.KeyPreview = True
        'TotalesXcanbeceras = New TotalesXcanbecera
        'TotalesXcanbeceras = Totales
        GetDocsVenta()
        GetCajasActivas()
        Me.CaptionLabels(0).Text = $"{"Cajero:"} {usuario.IDUsuario }"

        ServicePointManager.ServerCertificateValidationCallback = AddressOf AcceptAllCertifications

    End Sub
#End Region

    Sub GetCajasActivas()
        Dim UsuarioBE = New cajaUsuario
        Dim cajaUsuarioSA As New cajaUsuarioSA
        UsuarioBE.idEmpresa = Gempresas.IdEmpresaRuc
        UsuarioBE.idEstablecimiento = GEstableciento.IdEstablecimiento
        UsuarioBE.estadoCaja = "A"


        If GconfigCaja = "2" Then
            Dim query = (From i In ListaCajasActivas
                         Where i.idPersona = usuario.IDUsuario And i.estadoCaja = "A" And i.IDRol = usuario.IDRol).ToList
            listaActivas = query

            ComboCaja.DataSource = listaActivas
            ComboCaja.ValueMember = "idcajaUsuario" ' "IDUsuario"
            ComboCaja.DisplayMember = "NombrePersona"
        Else
            listaActivas = cajaUsuarioSA.ListadoCajaXEstado(UsuarioBE)

            ComboCaja.DataSource = listaActivas
            ComboCaja.ValueMember = "idcajaUsuario" ' "IDUsuario"
            ComboCaja.DisplayMember = "NombrePersona"
        End If



    End Sub

    Public Sub GetCuponesHabilitados()
        If listaCuponesActivos.Count > 0 Then
            Dim valorDeVenta = txtTotalPagar.DecimalValue

            Dim calculoCupon = valorDeVenta / listaCuponesActivos.FirstOrDefault.valorbase
            Dim parteEntera = CInt(calculoCupon)
            If parteEntera > 0 Then
                GradientPanel7.Visible = True
                LabelCupon.Text = listaCuponesActivos.FirstOrDefault.descripcion
                LabelCupon.Tag = listaCuponesActivos.FirstOrDefault
                'GetBeneficioMappingCliente(CType(LabelCupon.Tag, Business.Entity.beneficioProduccionConsumo))
            End If
        End If
    End Sub

    Public Sub Loadcontroles()
        listaCuponesActivos = BeneficioProduccionSA.GetBeneficiosSelTipo(Nothing)
        GetCuponesHabilitados()
    End Sub

#Region "Methods"

    Public Function AcceptAllCertifications(ByVal sender As Object, ByVal certification As System.Security.Cryptography.X509Certificates.X509Certificate, ByVal chain As System.Security.Cryptography.X509Certificates.X509Chain, ByVal sslPolicyErrors As System.Net.Security.SslPolicyErrors) As Boolean
        Return True
    End Function

    'Private Sub GetInicioCuentas()
    '    Dim SA As New EstadosFinancierosConfiguracionPagosSA
    '    Dim usuariocaja = ListaCajasActivas.Where(Function(o) o.idPersona = usuario.IDUsuario).FirstOrDefault
    '    If usuariocaja IsNot Nothing Then
    '        CuentasHabilitadas = SA.GetConfigurationPayCaja(New estadosFinancierosConfiguracionPagos With
    '                                            {
    '                                            .idEmpresa = Gempresas.IdEmpresaRuc,
    '                                            .idEstablecimiento = GEstableciento.IdEstablecimiento,
    '                                            .IDCaja = usuariocaja.idcajaUsuario
    '                                            })


    '    End If

    'End Sub

    Private Sub GetInicioCuentas(idCajaUsuario As Integer)
        Dim SA As New EstadosFinancierosConfiguracionPagosSA
        Dim usuariocaja = listaActivas.Where(Function(o) o.idcajaUsuario = idCajaUsuario).FirstOrDefault

        Dim dt As New DataTable

        With dt
            .Columns.Add("tipo")
            .Columns.Add("identidad")
            .Columns.Add("entidad")
            .Columns.Add("abonado")
            .Columns.Add("tipocambio")
            .Columns.Add("idforma")
            .Columns.Add("formaPago")
            .Columns.Add("nrooperacion")
        End With

        If usuariocaja IsNot Nothing Then
            CuentasHabilitadas = SA.GetConfigurationPayCaja(New estadosFinancierosConfiguracionPagos With
                                                {
                                                .idEmpresa = Gempresas.IdEmpresaRuc,
                                                .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                .IDCaja = usuariocaja.idcajaUsuario
                                                })

            For Each i In CuentasHabilitadas.Where(Function(o) o.tipo <> "EE").ToList ' ListaCuentasFinancierasConfiguradas.Where(Function(o) o.IDFormaPago <> "9991").ToList
                If CheckEfectivoDefault.Checked = True Then
                    If i.FormaPago = "EFECTIVO" And txtTotalPagar.DecimalValue > 0 Then
                        dt.Rows.Add(String.Empty, i.identidad, i.entidad, txtTotalPagar.DecimalValue, TmpTipoCambio, i.IDFormaPago, i.FormaPago, "-")



                    Else
                        dt.Rows.Add(String.Empty, i.identidad, i.entidad, 0.0, TmpTipoCambio, i.IDFormaPago, i.FormaPago, "-")
                    End If
                Else
                    dt.Rows.Add(String.Empty, i.identidad, i.entidad, 0.0, TmpTipoCambio, i.IDFormaPago, i.FormaPago, "-")
                End If
            Next



            'If ListaCuentasFinancierasConfiguradas.Count > 0 Then
            '    Dim cuponSel = ListaCuentasFinancierasConfiguradas.Where(Function(o) o.IDFormaPago = "9991").SingleOrDefault
            '    PanelCupon.Tag = cuponSel
            '    TextCodigoCupon.Visible = True
            '    ButtonAdv4.Visible = True
            'End If


            dgvCuentas.DataSource = dt
            '  lblPagoVenta.Text = CDec(txtTotalPagar.Text)
            LblPagoCredito.Visible = True
            lblPagoVenta.Visible = True

            Dim pagos As Decimal = SumaPagos()
            LblPagoCredito.Text = "SALDO POR COBRAR"
            lblPagoVenta.Text = CDec(txtTotalPagar.Text) - CDec(SumaPagos())
        End If

    End Sub

    Public Sub EnviarFacturaElectronica(idDocumento As Integer, idPSE As Integer)

        Dim documentoSA As New documentoVentaAbarrotesSA
        Dim documentoDetSA As New documentoVentaAbarrotesDetSA
        Dim entidadSA As New entidadSA
        Dim DetalleFactura As Fact.Sunat.Business.Entity.DocumentoElectronicoDetalle

        Try

            Dim comprobante = documentoSA.GetUbicar_documentoventaAbarrotesPorID(idDocumento)
            Dim comprobanteDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(idDocumento)
            Dim receptor = entidadSA.GetUbicarEntPorID(Gempresas.IdEmpresaRuc, comprobante.idCliente)
            Dim numerovent As String = String.Format("{0:00000000}", comprobante.numeroVenta)
            Dim tipoDoc = String.Format("{0:00}", comprobante.tipoDocumento)
            Dim conteo As Integer = 0

            '//Enviando el documento

            Dim Factura As New Fact.Sunat.Business.Entity.DocumentoElectronico

            'Datos del Cliente 
            Factura.Action = 0
            Factura.idEmpresa = idPSE 'lblIdPse.Text
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
            Factura.FechaVencimiento = DateTime.Now
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


            'Enviando al PSE
            Dim codigo = Helios.Fact.Sunat.WCFService.ServiceAccess.Admin.DocumentoElectronicoSA.DocumentoElectronicoSave(Factura, Nothing)

            If codigo.idDocumentoElectronico > 0 Then

                UpdateEnvioSunatEstado(comprobante.idDocumento, "SI")
                'MessageBox.Show("La Factura se Envio Correctamente al PSE")
            End If

        Catch ex As Exception

            'MessageBox.Show("No se Pudo Enviar")

        End Try


    End Sub

    Public Sub UpdateEnvioSunatEstado(idDoc As Integer, estado As String)
        Try

            Dim docSA As New documentoVentaAbarrotesSA

            docSA.UpdateFacturasXEstado(idDoc, estado)

            'MessageBox.Show("Se Genero Correctamente")
        Catch ex As Exception
            'MessageBox.Show("No se Pudo Actualizar")
        End Try



    End Sub

    Public Function AsientoTransito(cMonto As Decimal, cMontoUS As Decimal) As asiento
        Dim nAsiento As New asiento
        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.periodo = GetPeriodo(txtFecha.Value, True)
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        'If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
        '    nAsiento.idEntidad = Integer.Parse(TXTcOMPRADOR.Tag)
        '    nAsiento.nombreEntidad = TXTcOMPRADOR.Text
        'Else
        '    nAsiento.idEntidad = Integer.Parse(0)
        '    nAsiento.nombreEntidad = TXTcOMPRADOR.Text
        'End If

        nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.codigoLibro = "14"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_Existencia
        nAsiento.importeMN = cMonto
        nAsiento.importeME = cMontoUS
        nAsiento.glosa = "Pago Venta"
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now
        Return nAsiento
    End Function

    'Sub asientoDocumento(doc As documentoCaja)
    '    Dim asiento As New asiento
    '    Dim nMovimiento As New movimiento
    '    Dim efSA As New EstadosFinancierosSA
    '    Dim ef As New estadosFinancieros


    '    ef = efSA.GetUbicar_estadosFinancierosPorID(doc.entidadFinanciera)

    '    asiento = AsientoTransito(doc.montoSoles, doc.montoUsd)

    '    ListaAsientonTransito.Add(asiento)

    '    nMovimiento = New movimiento
    '    nMovimiento.cuenta = ef.cuenta
    '    nMovimiento.descripcion = ef.descripcion
    '    nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
    '    nMovimiento.monto = doc.montoSoles
    '    nMovimiento.montoUSD = doc.montoUsd
    '    nMovimiento.usuarioActualizacion = usuario.IDUsuario
    '    nMovimiento.fechaActualizacion = DateTime.Now
    '    asiento.movimiento.Add(nMovimiento)

    '    nMovimiento = New movimiento
    '    nMovimiento.cuenta = "1213"
    '    nMovimiento.descripcion = TXTcOMPRADOR.Text
    '    nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
    '    nMovimiento.monto = doc.montoSoles
    '    nMovimiento.montoUSD = doc.montoUsd
    '    nMovimiento.usuarioActualizacion = usuario.IDUsuario
    '    nMovimiento.fechaActualizacion = DateTime.Now
    '    asiento.movimiento.Add(nMovimiento)

    'End Sub


    Sub AsientoVentaServicios(listadoServicios As List(Of documentoventaAbarrotesDet))
        Dim nMovimiento As New movimiento
        Dim nAsiento As New asiento

        Dim SumaCliente = Aggregate n In listadoServicios
                    Into totalMN = Sum(n.importeMN),
                    TotalME = Sum(n.importeME)

        nAsiento = New asiento
        nAsiento.idAsiento = 0
        nAsiento.idDocumento = 0
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.periodo = GetPeriodo(txtFecha.Value, True)
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idDocumentoRef = 0
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.idAlmacen = Nothing
        nAsiento.nombreAlmacen = Nothing

        'If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
        '    nAsiento.idEntidad = Integer.Parse(TXTcOMPRADOR.Tag) ' txtIdCliente.Text
        '    nAsiento.nombreEntidad = TXTcOMPRADOR.Text
        'Else
        '    nAsiento.nombreEntidad = TXTcOMPRADOR.Text
        '    nAsiento.idEntidad = Integer.Parse(0)
        'End If

        nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nAsiento.codigoLibro = "14"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_Existencia
        nAsiento.glosa = "Venta"
        nAsiento.importeMN = SumaCliente.totalMN.GetValueOrDefault
        nAsiento.importeME = SumaCliente.TotalME.GetValueOrDefault
        nAsiento.fechaActualizacion = DateTime.Now
        If IsNothing(GFichaUsuarios) Then
            nAsiento.usuarioActualizacion = DocumentoVenta.usuarioActualizacion 'usuario.IDUsuario
        Else
            nAsiento.usuarioActualizacion = GFichaUsuarios.IdCajaUsuario
        End If

        ListaAsientonTransito.Add(nAsiento)

        nAsiento.movimiento.Add(AS_Cliente(SumaCliente.totalMN.GetValueOrDefault, SumaCliente.TotalME.GetValueOrDefault))

        Dim SumaIGV = Aggregate n In listadoServicios
                       Into totalIGVMN = Sum(n.montoIgv),
                       totalIGVME = Sum(n.montoIgvUS)

        If SumaIGV.totalIGVMN.GetValueOrDefault > 0 Then
            nAsiento.movimiento.Add(AS_IGV(SumaIGV.totalIGVMN.GetValueOrDefault, SumaIGV.totalIGVME.GetValueOrDefault))
        End If
        'nAsiento.movimiento.Add(AS_CAJA(TotalesXcanbeceras.TotalMN, TotalesXcanbeceras.TotalME))
        For Each i In listadoServicios
            nMovimiento = New movimiento
            nMovimiento.cuenta = "7041" 'i.idItem
            nMovimiento.descripcion = i.DetalleItem
            nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
            nMovimiento.monto = CDec(i.montokardex)
            nMovimiento.montoUSD = CDec(i.montokardexUS)
            nMovimiento.fechaActualizacion = DateTime.Now
            nMovimiento.usuarioActualizacion = usuario.IDUsuario
            nAsiento.movimiento.Add(nMovimiento)
        Next

    End Sub

    Sub AsientoVenta(listadoExistencias As List(Of documentoventaAbarrotesDet))
        Dim nMovimiento As New movimiento
        Dim nAsiento As New asiento

        Dim SumaCliente = Aggregate n In listadoExistencias
                         Into totalMN = Sum(n.importeMN),
                         TotalME = Sum(n.importeME)

        nAsiento = New asiento
        nAsiento.idAsiento = 0
        nAsiento.idDocumento = 0
        nAsiento.periodo = GetPeriodo(txtFecha.Value, True)
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idDocumentoRef = 0
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.idAlmacen = Nothing
        nAsiento.nombreAlmacen = Nothing

        'If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
        '    nAsiento.nombreEntidad = TXTcOMPRADOR.Text
        '    nAsiento.idEntidad = Integer.Parse(TXTcOMPRADOR.Tag)
        'Else
        '    nAsiento.nombreEntidad = TXTcOMPRADOR.Text
        '    nAsiento.idEntidad = Integer.Parse(0)
        'End If

        nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nAsiento.codigoLibro = "14"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_Existencia
        nAsiento.glosa = "Venta"
        nAsiento.importeMN = SumaCliente.totalMN.GetValueOrDefault
        nAsiento.importeME = SumaCliente.TotalME.GetValueOrDefault
        nAsiento.fechaActualizacion = DateTime.Now
        nAsiento.usuarioActualizacion = DocumentoVenta.usuarioActualizacion ''usuario.IDUsuario

        ListaAsientonTransito.Add(nAsiento)

        nAsiento.movimiento.Add(AS_Cliente(SumaCliente.totalMN.GetValueOrDefault, SumaCliente.TotalME.GetValueOrDefault))

        Dim SumaIGV = Aggregate n In listadoExistencias
                       Into totalIGVMN = Sum(n.montoIgv),
                       totalIGVME = Sum(n.montoIgvUS)

        If SumaIGV.totalIGVMN.GetValueOrDefault > 0 Then
            nAsiento.movimiento.Add(AS_IGV(SumaIGV.totalIGVMN.GetValueOrDefault, SumaIGV.totalIGVME.GetValueOrDefault))
        End If
        'nAsiento.movimiento.Add(AS_CAJA(TotalesXcanbeceras.TotalMN, TotalesXcanbeceras.TotalME))
        For Each i In listadoExistencias
            'MV_Item_Transito(i.DetalleItem, i.salidaCostoMN, i.salidaCostoME, i.tipoExistencia)
            nMovimiento = New movimiento

            If i.tipoExistencia = "01" Then
                nMovimiento.cuenta = "70111"
            ElseIf i.tipoExistencia = "02" Then
                nMovimiento.cuenta = "70211"
            ElseIf i.tipoExistencia = "06" Then
                nMovimiento.cuenta = " 70311"
            Else
                nMovimiento.cuenta = "70111"
            End If

            nMovimiento.descripcion = i.DetalleItem
            nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
            nMovimiento.monto = CDec(i.montokardex)
            nMovimiento.montoUSD = CDec(i.montokardexUS)
            nMovimiento.fechaActualizacion = DateTime.Now
            nMovimiento.usuarioActualizacion = DocumentoVenta.usuarioActualizacion 'usuario.IDUsuario
            nAsiento.movimiento.Add(nMovimiento)
        Next

    End Sub

    Public Function AS_Cliente(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .cuenta = "1213",
              .descripcion = TextProveedor.Text,
              .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = DocumentoVenta.usuarioActualizacion} 'usuario.IDUsuario}

        Return nMovimiento
    End Function

    Public Function AS_IGV(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .cuenta = "40111",
              .descripcion = "I.G.V.",
              .tipo = ASIENTO_CONTABLE.UBICACION.HABER,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = DocumentoVenta.usuarioActualizacion} ' usuario.IDUsuario}

        Return nMovimiento
    End Function

    Sub centrar()
        Dim boundWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim boundHeight As Integer = Screen.PrimaryScreen.Bounds.Height
        Dim x As Integer = boundWidth - Me.Width
        Dim y As Integer = boundHeight - Me.Height
        Me.Location = New Point(x \ 2, y \ 2)
    End Sub

    Private Sub HabilitarPago(opcion As Boolean)
        Select Case opcion
            Case True
                'pcLikeCategoria.Visible = True
                PanelVendedorInfo.Visible = True
                '  PanelDetalleDoc.Visible = True
                PanelMontos.Visible = True
                'Me.Size = New Size(1047, 599)

                For Each i In dgvCuentas.Table.Records
                    i.SetValue("abonado", 0)
                Next

                Dim pagos As Decimal = SumaPagos()

                LblPagoCredito.Text = "SALDO POR COBRAR"

                lblPagoVenta.Text = CDec(txtTotalPagar.Text) - CDec(SumaPagos())

                If (lblPagoVenta.Text = CDec(0.0)) Then
                    ErrorProvider1.Clear()
                End If
                GetMappingColumnsGrid()
                PanelLoadingWaith.Visible = False
                ToolEditPedido.Enabled = True
            Case False
                'pcLikeCategoria.Visible = False
                PanelVendedorInfo.Visible = False
                '  PanelDetalleDoc.Visible = False
                PanelMontos.Visible = False
                'Me.Size = New Size(834, 148)
                PanelLoadingWaith.Visible = True
                ToolEditPedido.Enabled = False
        End Select
        centrar()
    End Sub

    Private Sub ValidacionCredito()
        LblPagoCredito.Text = "VENTA AL CREDITO"
        lblPagoVenta.Text = CDec(txtTotalPagar.Text)
        LblPagoCredito.Visible = True
        lblPagoVenta.Visible = True
        dgvCuentas.Table.Records.DeleteAll()
    End Sub

    Public Sub GetDocsVenta()
        Dim ListaDocumentos As New List(Of tabladetalle)
        If Gempresas.ubigeo IsNot Nothing Then
            ListaDocumentos = GetComprobantesCompra()
        End If
        ListaDocumentos.Add(New tabladetalle With {.codigoDetalle = "9907", .descripcion = "NOTA"})

        cboTipoDoc.DataSource = ListaDocumentos
        cboTipoDoc.DisplayMember = "descripcion"
        cboTipoDoc.ValueMember = "codigoDetalle"

        'cboTipoDoc.Items.Clear()
        'cboTipoDoc.Items.Add("NOTA DE VENTA")
        'cboTipoDoc.Items.Add("FACTURA")
        'cboTipoDoc.Items.Add("BOLETA")

    End Sub

    Public Sub GetDocProforma()
        cboTipoDoc.Items.Clear()
        cboTipoDoc.Items.Add("PROFORMA")
        cboTipoDoc.Text = "PROFORMA"
    End Sub

    'Public Class TotalesXcanbecera
    '    '   Private base_mn, base_me, igv_mn, igv_me, total_mn, total_me As Decimal?

    '    Public Property BaseMN() As Decimal
    '    Public Property BaseME() As Decimal

    '    Public Property BaseMN2() As Decimal
    '    Public Property BaseME2() As Decimal

    '    Public Property BaseMN3() As Decimal
    '    Public Property BaseME3() As Decimal

    '    Public Property IgvMN() As Decimal
    '    Public Property IgvME() As Decimal
    '    Public Property TotalMN() As Decimal
    '    Public Property TotalME() As Decimal

    '    Public Property base1() As Decimal
    '    Public Property base1me() As Decimal
    '    Public Property base2() As Decimal
    '    Public Property base2me() As Decimal
    '    Public Property MontoIgv1() As Decimal
    '    Public Property MontoIgv1me() As Decimal
    '    Public Property MontoIgv2() As Decimal
    '    Public Property MontoIgv2me() As Decimal

    '    Public Property PercepcionMN() As Decimal
    '    Public Property PercepcionME() As Decimal

    '    Public Sub New()
    '        BaseMN = 0
    '        BaseME = 0
    '        BaseMN2 = 0
    '        BaseME2 = 0
    '        BaseMN3 = 0
    '        BaseME3 = 0
    '        IgvMN = 0
    '        IgvME = 0
    '        TotalMN = 0
    '        TotalME = 0
    '        base1 = 0
    '        base1me = 0
    '        base2 = 0
    '        base2me = 0
    '        MontoIgv1 = 0
    '        MontoIgv1me = 0
    '        MontoIgv2 = 0
    '        MontoIgv2me = 0
    '        PercepcionMN = 0
    '        PercepcionME = 0
    '    End Sub


    'End Class
#End Region

    'Dim thread As System.Threading.Thread
    'Private Sub threadClientes()
    '    Dim tipo = General.TIPO_ENTIDAD.CLIENTE
    '    Dim empresa = General.Gempresas.IdEmpresaRuc
    '    ProgressBar1.Visible = True
    '    ProgressBar1.Style = ProgressBarStyle.Marquee
    '    thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetClientes(tipo, empresa)))
    '    thread.Start()
    'End Sub

    Private Sub GetClientes(tipo As String, empresa As String)
        Dim lista As New List(Of entidad)
        lista = New List(Of entidad)
        '  Dim varios = entidadSA.UbicarEntidadVarios("VR", General.Gempresas.IdEmpresaRuc, String.Empty)
        'Dim lista = entidadSA.ObtenerListaEntidad(tipo, empresa)
        lista.Add(VarClienteGeneral)
        lista.AddRange(entidadSA.GetListarEntidad(New entidad With {.tipoEntidad = tipo, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA}))
        setDataSource(lista)
    End Sub

    Private Sub setDataSource(ByVal lista As List(Of entidad))
        If Me.InvokeRequired Then
            'Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table)

            Dim deleg As New SetDataSourceDelegate(AddressOf setDataSource)
            Invoke(deleg, New Object() {lista})
        Else
            listaClientes = New List(Of entidad)
            listaClientes = lista
        End If
    End Sub

    Private Sub GetColumnsGrid()
        Dim dt As New DataTable

        With dt
            .Columns.Add("tipo")
            .Columns.Add("identidad")
            .Columns.Add("entidad")
            .Columns.Add("abonado")
            .Columns.Add("tipocambio")
            .Columns.Add("idforma")
            .Columns.Add("formaPago")
            .Columns.Add("nrooperacion")
        End With
        dgvCuentas.DataSource = dt
    End Sub

    Private Sub cboTipoDoc_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboTipoDoc.SelectedValueChanged
        If cboTipoDoc.Text.Trim.Length > 0 Then
            'Select Case cboTipoDoc.Text
            '    Case "BOLETA"

            '        chAutoNumeracion.Enabled = True
            '        If chAutoNumeracion.Checked = True Then
            '            txtNumero.Clear()
            '            txtSerie.Visible = False
            '            txtSerie.ReadOnly = True
            '            txtNumero.Visible = False
            '            txtNumero.ReadOnly = True

            '            'txtruc.Text = 0
            '            'TXTcOMPRADOR.Text = "VARIOS"
            '            'txtruc.Select(0, txtruc.Text.Length)
            '            'txtruc.Focus()
            '            'Getclientepedido()

            '            ProgressBar2.Visible = True
            '            ProgressBar2.Style = ProgressBarStyle.Marquee
            '            BackgroundWorker1.RunWorkerAsync()

            '        Else
            '            txtNumero.Clear()
            '            txtSerie.Visible = True
            '            txtSerie.ReadOnly = False
            '            txtNumero.Visible = True
            '            txtNumero.ReadOnly = False
            '        End If
            '    Case "FACTURA"

            '        chAutoNumeracion.Enabled = True
            '        If chAutoNumeracion.Checked = True Then
            '            txtNumero.Clear()
            '            txtSerie.Visible = False
            '            txtSerie.ReadOnly = True
            '            txtNumero.Visible = False
            '            txtNumero.ReadOnly = True

            '            'txtruc.Clear()
            '            'TXTcOMPRADOR.Clear()
            '            'txtruc.Select(0, txtruc.Text.Length)
            '            'txtruc.Focus()
            '            '  Getclientepedido()

            '            ProgressBar2.Visible = True
            '            ProgressBar2.Style = ProgressBarStyle.Marquee
            '            BackgroundWorker1.RunWorkerAsync()

            '        Else
            '            txtNumero.Clear()
            '            txtSerie.Visible = True
            '            txtSerie.ReadOnly = False
            '            txtNumero.Visible = True
            '            txtNumero.ReadOnly = False
            '        End If
            '    Case "NOTA DE VENTA"

            '        chAutoNumeracion.Checked = True
            '        chAutoNumeracion.Enabled = False
            '        txtSerie.Visible = False
            '        txtNumero.Visible = False
            '        txtSerie.ReadOnly = False

            '        'txtruc.Text = 0
            '        'TXTcOMPRADOR.Text = "VARIOS"
            '        'txtruc.Select(0, txtruc.Text.Length)S
            '        'txtruc.Focus()

            '    Case "BOLETA"

            '        chAutoNumeracion.Enabled = True
            '        chAutoNumeracion.Checked = True

            '        'txtSerie.Visible = True
            '        'txtSerie.Text = "B001"
            '        'txtSerie.ReadOnly = True
            '        'txtNumero.Visible = True
            '        'txtNumero.ReadOnly = True
            '        txtNumero.Clear()
            '        txtSerie.Visible = False
            '        txtSerie.ReadOnly = True
            '        txtNumero.Visible = False
            '        txtNumero.ReadOnly = True

            '        'txtruc.Text = 0
            '        'TXTcOMPRADOR.Text = "VARIOS"
            '        'txtruc.Select(0, txtruc.Text.Length)
            '        'txtruc.Focus()

            '        ProgressBar2.Visible = True
            '        ProgressBar2.Style = ProgressBarStyle.Marquee
            '        BackgroundWorker1.RunWorkerAsync()
            '    Case "FACTURA"

            '        chAutoNumeracion.Enabled = True
            '        chAutoNumeracion.Checked = True

            '        'txtSerie.Visible = True
            '        'txtSerie.Text = "F001"
            '        'txtSerie.ReadOnly = True
            '        'txtNumero.Visible = True
            '        'txtNumero.ReadOnly = True

            '        txtNumero.Clear()
            '        txtSerie.Visible = False
            '        txtSerie.ReadOnly = True
            '        txtNumero.Visible = False
            '        txtNumero.ReadOnly = True

            '        'txtruc.Clear()
            '        'TXTcOMPRADOR.Clear()
            '        'txtruc.Select(0, txtruc.Text.Length)
            '        'txtruc.Focus()

            '        ProgressBar2.Visible = True
            '        ProgressBar2.Style = ProgressBarStyle.Marquee
            '        BackgroundWorker1.RunWorkerAsync()
            '    Case "PROFORMA"
            '        txtNumero.Clear()
            '        txtSerie.Visible = False
            '        txtSerie.ReadOnly = True
            '        txtNumero.Visible = False
            '        txtNumero.ReadOnly = True

            '        Getclientepedido()

            '        ProgressBar2.Visible = True
            '        ProgressBar2.Style = ProgressBarStyle.Marquee
            '        BackgroundWorker1.RunWorkerAsync()
            'End Select
            'GetResetCantidades()
        End If

    End Sub


    Private Sub GetConsultaSunatThread(ruc As String)
        SelRazon = New entidad
        Dim nroDoc = ruc.Substring(0, 1).ToString
        If nroDoc = "1" Then

            'getRuc donde ase llama como el company
            Dim sunat As New Helios.Consultas.Sunat.Sunat()
            sunat.GenerateCapchaTemporal()
            Dim valorCapcha = sunat.Decode_CapchaTemporal()
            Dim company As ProcesosJH.DatosRuc = ProcesosJH.ConsultarRUC(ruc, valorCapcha)

            'Dim datosSunat = New Helios.Sunat.Consulta.GetConsultaSunat()
            'Dim company = datosSunat.GetConsultaRuc(ruc)

            '  Dim company = CType(Await SoftPackERP_Sunat.GetRucContribuyenteSPK.GetContribuyente(ruc), SoftPackERP_Sunat.CompanyJuridico)
            If company.Ruc IsNot Nothing Then
                If company.RazonSocial = "ERROR" Then

                Else
                    SelRazon.tipoPersona = "N"
                    SelRazon.tipoDoc = "6"
                    SelRazon.tipoEntidad = "CL"
                    SelRazon.nombreCompleto = company.RazonSocial
                    SelRazon.nombreContacto = company.RazonSocial
                    SelRazon.estado = company.Estado_Contribuyente
                    SelRazon.nrodoc = company.Ruc
                    SelRazon.direccion = company.DireccionDomicilioFiscal
                End If

            Else

            End If
        ElseIf nroDoc = "2" Then
            Dim sunat As New Helios.Consultas.Sunat.Sunat()
            sunat.GenerateCapchaTemporal()
            Dim valorCapcha = sunat.Decode_CapchaTemporal()
            Dim company As ProcesosJH.DatosRuc = ProcesosJH.ConsultarRUC(ruc, valorCapcha)

            'Dim company = CType(Await SoftPackERP_Sunat.GetRucContribuyenteSPK.GetContribuyente(ruc), SoftPackERP_Sunat.CompanyJuridico)
            If company.Ruc IsNot Nothing Then
                'If company.ContribuyenteTipo = "SOCIEDAD ANONIMA CERRADA" Then
                If company.RazonSocial = "ERROR" Then

                Else
                    SelRazon.tipoPersona = "J"
                    SelRazon.tipoDoc = "6"
                    SelRazon.tipoEntidad = "CL"
                    SelRazon.nombreCompleto = company.RazonSocial
                    SelRazon.nombreContacto = company.RazonSocial
                    SelRazon.estado = company.Estado_Contribuyente
                    SelRazon.direccion = company.DireccionDomicilioFiscal
                    SelRazon.nrodoc = company.Ruc

                End If
            Else

            End If
        End If
    End Sub

    Private Function GuardarEntidad(razonSocial As String, numero As String, direccion As String, tipoDoc As String) As Integer
        Dim obEntidad As New entidad
        Dim entidadSA As New entidadSA
        Try
            'Se asigna cada uno de los datos registrados
            obEntidad.idEmpresa = Gempresas.IdEmpresaRuc

            If tipoDoc = "RUC" Then
                obEntidad.tipoDoc = "6"
            ElseIf tipoDoc = "DNI" Then
                obEntidad.tipoDoc = "1"
            ElseIf tipoDoc = "PASSAPORTE" Then
                obEntidad.tipoDoc = "7"
            ElseIf tipoDoc = "CARNET DE EXTRANJERIA" Then
                obEntidad.tipoDoc = "4"
            End If
            obEntidad.nrodoc = numero

            If TextNumIdentrazon.Text.Length = 8 Then
                obEntidad.appat = String.Empty ' txtApePat.Text.Trim
                obEntidad.apmat = String.Empty 'txtApeMaterno.Text.Trim
                obEntidad.nombre1 = String.Empty 'txtNomProv.Text.Trim
                obEntidad.nombreCompleto = razonSocial ' obEntidad.appat & " " & txtApeMaterno.Text.Trim & ", " & obEntidad.nombre1
                obEntidad.tipoPersona = "N"
                obEntidad.tipoEntidad = TIPO_ENTIDAD.CLIENTE
            ElseIf TextNumIdentrazon.Text.Length = 11 Then
                obEntidad.nombre = razonSocial
                obEntidad.nombreCompleto = razonSocial
                obEntidad.tipoPersona = "J"
                obEntidad.tipoEntidad = TIPO_ENTIDAD.CLIENTE
                'ElseIf RBnatConnegocio.Checked = True Then
                '    obEntidad.nombre = txtNomProv.Text.Trim
                '    obEntidad.nombreCompleto = txtNomProv.Text.Trim
                '    obEntidad.tipoPersona = "NJ"
            End If
            'Select Case strTipo
            '    Case TIPO_ENTIDAD.PROVEEDOR
            '        obEntidad.cuentaAsiento = "4212"
            '    Case TIPO_ENTIDAD.CLIENTE
            obEntidad.cuentaAsiento = "1213"
            'End Select

            obEntidad.estado = StatusEntidad.Activo
            If TextNumIdentrazon.Text.Trim.Length = 11 Then
                obEntidad.direccion = direccion
            Else
                obEntidad.direccion = Nothing
            End If

            'If txtFoNo.Text.Trim.Length > 0 Then
            '    obEntidad.telefono = txtFoNo.Text.Trim
            'Else
            '    obEntidad.telefono = Nothing
            'End If

            obEntidad.nombreContacto = String.Empty
            obEntidad.email = String.Empty
            obEntidad.usuarioModificacion = usuario.Alias
            obEntidad.fechaModificacion = DateTime.Now
            obEntidad.EnvioEntidades = False
            obEntidad.EnvioPlanilla = False
            Dim codx As Integer = entidadSA.GrabarEntidad(obEntidad)

            Return codx

        Catch ex As Exception
            'Manejo de errores
            MsgBox("No se pudo grabar el cliente." & vbCrLf & ex.Message)
            Me.Tag = Nothing
        End Try
    End Function


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
    '            GConfiguracion = New GConfiguracionModulo
    '            GConfiguracion.IdModulo = .idModulo
    '            GConfiguracion.TipoConfiguracion = .tipoConfiguracion
    '            Select Case .tipoConfiguracion
    '                Case "P"
    '                    With numeracionSA.GetUbicar_numeracionBoletasPorID(.configComprobante)
    '                        GConfiguracion.ConfigComprobante = .IdEnumeracion

    '                        If cboTipoDoc.Text = "BOLETA" Then
    '                            GConfiguracion.TipoComprobante = "12.1" ' .tipo
    '                            GConfiguracion.Serie = .serie
    '                            GConfiguracion.ValorActual = .valorInicial

    '                        End If
    '                        If cboTipoDoc.Text = "FACTURA" Then
    '                            GConfiguracion.TipoComprobante = "12.2" '.tipo
    '                            GConfiguracion.Serie = .serie
    '                            GConfiguracion.ValorActual = .valorInicial

    '                        End If

    '                        If cboTipoDoc.Text = "FACTURA" Then

    '                            GConfiguracion.TipoComprobante = "01" '.tipo
    '                            GConfiguracion.Serie = .serie
    '                            GConfiguracion.ValorActual = .valorInicial


    '                        End If
    '                        If cboTipoDoc.Text = "BOLETA" Then
    '                            GConfiguracion.TipoComprobante = "03" ' .tipo
    '                            GConfiguracion.Serie = .serie
    '                            GConfiguracion.ValorActual = .valorInicial

    '                        End If

    '                        If cboTipoDoc.Text = "PROFORMA" Then
    '                            GConfiguracion.TipoComprobante = .tipo
    '                            GConfiguracion.Serie = .serie
    '                            GConfiguracion.ValorActual = .valorInicial
    '                        End If
    '                    End With
    '                Case "M"

    '            End Select

    '        End With
    '    Else
    '        '  lblEstado.Text = "Este módulo no contiene una configuración disponible, intentelo más tarde.!"
    '        ' Timer1.Enabled = True
    '        'TabCompra.Enabled = False
    '        'TiempoEjecutar(5)
    '    End If
    '    Return GConfiguracion2
    'End Function

    Public Function configuracionModuloV2(strIDEmpresa As String, strIdModulo As String, strNomModulo As String, intIdEstablecimiento As Integer) As GConfiguracionModulo
        Try
            Dim numeracionSA As New NumeracionBoletaSA
            Dim TablaSA As New tablaDetalleSA
            Dim almacenSA As New almacenSA
            Dim cajaSA As New EstadosFinancierosSA

            Dim RecuperacionNumeracion = numeracionSA.GetUbicar_numeracionBoletasXUnidadNegocio(New numeracionBoletas With {.empresa = strIDEmpresa, .establecimiento = intIdEstablecimiento, .codigoNumeracion = strIdModulo, .estado = "A"})

            If (Not IsNothing(RecuperacionNumeracion)) Then
                GConfiguracion = New GConfiguracionModulo
                GConfiguracion.ConfigComprobante = CInt(RecuperacionNumeracion.IdEnumeracion)

                If cboTipoDoc.Text = "BOLETA" Then
                    GConfiguracion.TipoComprobante = "12.1" ' .tipo
                    GConfiguracion.Serie = RecuperacionNumeracion.serie
                    GConfiguracion.ValorActual = RecuperacionNumeracion.valorInicial

                End If
                If cboTipoDoc.Text = "FACTURA" Then
                    GConfiguracion.TipoComprobante = "12.2" '.tipo
                    GConfiguracion.Serie = RecuperacionNumeracion.serie
                    GConfiguracion.ValorActual = RecuperacionNumeracion.valorInicial

                End If

                If cboTipoDoc.Text = "FACTURA ELECTRONICA" Then

                    GConfiguracion.TipoComprobante = "01" '.tipo
                    GConfiguracion.Serie = RecuperacionNumeracion.serie
                    GConfiguracion.ValorActual = RecuperacionNumeracion.valorInicial


                End If
                If cboTipoDoc.Text = "BOLETA ELECTRONICA" Then
                    GConfiguracion.TipoComprobante = "03" ' .tipo
                    GConfiguracion.Serie = RecuperacionNumeracion.serie
                    GConfiguracion.ValorActual = RecuperacionNumeracion.valorInicial

                End If

                If cboTipoDoc.Text = "PROFORMA" Then
                    GConfiguracion.TipoComprobante = RecuperacionNumeracion.tipo
                    GConfiguracion.Serie = RecuperacionNumeracion.serie
                    GConfiguracion.ValorActual = RecuperacionNumeracion.valorInicial
                End If
            Else
                Throw New Exception("Verificar configuración")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return GConfiguracion
    End Function

    Private Function ValidacionDeMontoTotalConDetalle() As Boolean
        ValidacionDeMontoTotalConDetalle = False

        Dim totalDetalle As Decimal = txtTotalBase.DecimalValue + txtTotalBase2.DecimalValue + txtTotalBase3.DecimalValue + txtTotalIva.DecimalValue

        Dim totalDoc As Decimal = txtTotalPagar.DecimalValue

        If totalDoc = totalDetalle Then
            ValidacionDeMontoTotalConDetalle = True
        End If

    End Function

    '  Dim objPleaseWait As New FeedbackForm()
    Private listaCuponesActivos As List(Of beneficioProduccionConsumo)
    Private listaAnticipoDetalle As List(Of documentoAnticipoConciliacion)
    Private cliventa As entidad


    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Try
            btOperacion.Enabled = False
            txtFecha.Value = DateTime.Now

            'ListaCajasActivas = cajaUsuarioSA.ListadoCajaXEstado(New cajaUsuario With {
            '                                                 .idEmpresa = Gempresas.IdEmpresaRuc,
            '                                                 .idEstablecimiento = GEstableciento.IdEstablecimiento,
            '                                                 .estadoCaja = "A"
            '                                                 })

            'Dim cajaUsuario = ListaCajasActivas.Where(Function(o) o.idPersona = usuario.IDUsuario).SingleOrDefault
            'If cajaUsuario Is Nothing Then
            '    btOperacion.Enabled = True
            '    MessageBox.Show("Debe aperturar una caja realizar la venta!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    Exit Sub
            'End If
            If listaActivas Is Nothing Then
                btOperacion.Enabled = True
                MessageBox.Show("Debe aperturar una caja realizar la venta!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If


            Select Case cboTipoDoc.Text
                Case "FACTURA", "FACTURA"
                    Dim objeto As Boolean = ValidationRUC(TextNumIdentrazon.Text.Trim)
                    If objeto = False Then
                        btOperacion.Enabled = True
                        MessageBox.Show("Debe Ingresar un número correcto de ruc", "Ingresar identificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Cursor = Cursors.Default
                        Exit Sub
                    End If
                Case "BOLETA", "BOLETA"


                    If TextProveedor.Tag = VarClienteGeneral.idEntidad Then

                    Else
                        Dim rsp = validarDNIRUC(TextNumIdentrazon.Text.Trim)
                        If rsp = False Then
                            btOperacion.Enabled = True
                            MessageBox.Show("Debe Ingresar un número correcto de DNI", "Ingresar identificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Cursor = Cursors.Default
                            Exit Sub
                        End If
                    End If


            End Select

            ' If ValidarGrabado() = True Then


            If chCredito.Checked = True Then

            ElseIf ChPagoAvanzado.Checked = True Then
                Dim pagos As Decimal = 0 ' SumaPagos()
                Dim deudadTotal As Decimal = 0
                If DocumentoVenta.moneda = "1" Then
                    pagos = SumaPagos()
                    deudadTotal = DocumentoVenta.ImporteNacional
                Else
                    pagos = SumaPagosME()
                    deudadTotal = DocumentoVenta.ImporteExtranjero
                End If

                If pagos <= 0 Then
                    btOperacion.Enabled = True
                    MessageBox.Show("Debe ingresar un pago mayor a cero!", "Pagar venta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    '   objPleaseWait.Close()
                    Exit Sub
                End If

                If pagos > 0 AndAlso pagos < deudadTotal Then
                    btOperacion.Enabled = True
                    If MessageBox.Show("Está realizando una cobranza parcial, Desea Continuar?", "Pagar venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                        '        objPleaseWait.Close()
                        Exit Sub
                    End If
                End If
            End If

            ' If ValidacionDeMontoTotalConDetalle() = True Then
            'objPleaseWait = New FeedbackForm()
            'objPleaseWait.StartPosition = FormStartPosition.CenterScreen
            'objPleaseWait.Show()
            Application.DoEvents()
            GrabarVentaEquivalencia()



            'Select Case cboTipoDoc.Text
            '    Case "BOLETA", "FACTURA"
            '        TipoVentaGeneral = TIPO_VENTA.VENTA_POS_DIRECTA
            '        GrabarVentaCasoEspecial()

            '    Case "FACTURA", "BOLETA"
            '        TipoVentaGeneral = TIPO_VENTA.VENTA_ELECTRONICA
            '        GrabarVentaCasoEspecial()

            '    Case "NOTA DE VENTA"
            '        GrabarNotaDeVenta()
            '    Case "PROFORMA"
            '        GrabarProforma()
            'End Select
            'Else
            '    MessageBox.Show("Los importes no coinciden, el detalle, con el total de la venta ", "Verificar importes", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End If
            'End If
        Catch ex As Exception
            '     objPleaseWait.Close()
            btOperacion.Enabled = True
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function ValidarGrabado() As Boolean
        Dim listaErrores As Integer = 0

        Select Case cboTipoDoc.Text

            Case "BOLETA", "FACTURA"
                If TextProveedor.Text.Trim.Length = 0 Then
                    ErrorProvider1.SetError(TextProveedor, "Ingrese un cliente")
                    listaErrores += 1
                Else
                    ErrorProvider1.SetError(TextProveedor, Nothing)
                End If

                'If TextProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
                '    ErrorProvider1.SetError(TXTcOMPRADOR, Nothing)
                'Else
                '    ErrorProvider1.SetError(TXTcOMPRADOR, "Ingrese un cliente válido")
                '    listaErrores += 1
                'End If

                If chAutoNumeracion.Checked = False Then
                    If txtSerie.Text.Trim.Length = 0 Then
                        ErrorProvider1.SetError(txtSerie, "El campo serie es obligatorio")
                        listaErrores += 1
                    Else
                        ErrorProvider1.SetError(txtSerie, Nothing)
                    End If

                    If txtNumero.Text.Trim.Length = 0 Then
                        ErrorProvider1.SetError(txtNumero, "El campo número es obligatorio")
                        listaErrores += 1
                    Else
                        ErrorProvider1.SetError(txtNumero, Nothing)
                    End If
                End If
            Case "NOTA DE VENTA"
                If TextProveedor.Text.Trim.Length = 0 Then
                    ErrorProvider1.SetError(TextProveedor, "Ingrese un cliente")
                    listaErrores += 1
                Else
                    ErrorProvider1.SetError(TextProveedor, Nothing)
                End If

                'If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
                '    ErrorProvider1.SetError(TXTcOMPRADOR, Nothing)
                'Else
                '    ErrorProvider1.SetError(TXTcOMPRADOR, "Ingrese un cliente válido")
                '    listaErrores += 1
                'End If



            Case "BOLETA"

                If TextProveedor.Text.Trim.Length = 0 Then
                    ErrorProvider1.SetError(TextProveedor, "Ingrese un cliente")
                    listaErrores += 1
                Else
                    ErrorProvider1.SetError(TextProveedor, Nothing)
                End If

                'If TextProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
                '    ErrorProvider1.SetError(TextProveedor, Nothing)
                'Else
                '    ErrorProvider1.SetError(TextProveedor, "Ingrese un cliente válido")
                '    listaErrores += 1
                'End If

            '    If txtTipoDocClie.Text = "6" Then
            '        ErrorProvider1.SetError(TXTcOMPRADOR, "Debe ingresar Cliente DNI/Otros")
            '        listaErrores += 1
            '    Else
            '        ErrorProvider1.SetError(TXTcOMPRADOR, Nothing)
            '    End If

            Case "FACTURA"

                If TextProveedor.Text.Trim.Length = 0 Then
                    ErrorProvider1.SetError(TextProveedor, "Ingrese un cliente")
                    listaErrores += 1
                Else
                    ErrorProvider1.SetError(TextProveedor, Nothing)
                End If

                'If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
                '    ErrorProvider1.SetError(TXTcOMPRADOR, Nothing)
                'Else
                '    ErrorProvider1.SetError(TXTcOMPRADOR, "Ingrese un cliente válido")
                '    listaErrores += 1
                'End If

                'If txtTipoDocClie.Text = "1" Or txtTipoDocClie.Text = "0" Then
                '    ErrorProvider1.SetError(TXTcOMPRADOR, "Debe ingresar Cliente RUC")
                '    listaErrores += 1
                'Else
                '    ErrorProvider1.SetError(TXTcOMPRADOR, Nothing)
                'End If

                'If (TXTcOMPRADOR.Text.Length = 0) Then
                '    ErrorProvider1.SetError(TXTcOMPRADOR, "Debe ingresar Cliente RUC")
                '    listaErrores += 1
                'End If

        End Select

        'If (ChPagoAvanzado.Checked = True And lblPagoVenta.Text > 0) Then
        '    ErrorProvider1.SetError(Label8, "Debe efectuar la totalidad del pago")
        '    listaErrores += 1
        'End If

        If txtTotalPagar.DecimalValue <= 0 Then
            ErrorProvider1.SetError(txtTotalPagar, "La venta debe ser mayor a cero")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(txtTotalPagar, Nothing)
        End If

        If listaErrores > 0 Then
            ValidarGrabado = False
        Else
            ValidarGrabado = True
        End If
    End Function

    'Sub GrabarProforma()
    '    Dim VentaSA As New documentoVentaAbarrotesSA
    '    Dim ndocumento As New documento()
    '    Dim DocCaja As New documento

    '    Dim ListaTotales As New List(Of totalesAlmacen)
    '    Dim docVentaSA As New documentoVentaAbarrotesSA

    '    Dim nDocumentoVenta As New documentoventaAbarrotes()
    '    Dim objDocumentoVentaDet As New documentoventaAbarrotesDet
    '    Dim entidadSA As New entidadSA
    '    Dim entidad As New entidad

    '    Dim asientoSA As New AsientoSA
    '    ' Dim ListaAsiento As New List(Of asiento)
    '    Dim nAsiento As New asiento
    '    Dim nMovimiento As New movimiento

    '    Dim ListaDetalle As New List(Of documentoventaAbarrotesDet)
    '    Dim proveedor As String
    '    Dim idProveedor As Integer

    '    proveedor = TextProveedor.Text
    '    idProveedor = CInt(TextProveedor.Tag)

    '    '-------------------------------------------------------------------------------------
    '    ndocumento = New documento
    '    ndocumento.Action = Business.Entity.BaseBE.EntityAction.INSERT
    '    ndocumento.idEmpresa = Gempresas.IdEmpresaRuc
    '    ndocumento.idCentroCosto = GEstableciento.IdEstablecimiento
    '    If IsNothing(GProyectos) Then
    '    Else
    '        ndocumento.idProyecto = GProyectos.IdProyectoActividad
    '    End If
    '    ndocumento.tipoDoc = conf.TipoComprobante
    '    ndocumento.fechaProceso = txtFecha.Value
    '    ndocumento.nroDoc = conf.Serie
    '    ndocumento.idOrden = Nothing ' Me.IdOrden
    '    ndocumento.moneda = If(cboMoneda.Text = "NACIONAL", "1", "2")
    '    ndocumento.idEntidad = Val(idProveedor)
    '    ndocumento.entidad = proveedor
    '    ndocumento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
    '    ndocumento.nrodocEntidad = txtruc.Text
    '    ndocumento.tipoOperacion = StatusTipoOperacion.VENTA
    '    ndocumento.usuarioActualizacion = usuario.IDUsuario
    '    ndocumento.fechaActualizacion = DateTime.Now

    '    nDocumentoVenta = New documentoventaAbarrotes With {
    '        .IdDocumentoCotizacion = False,
    '             .TipoConfiguracion = If(conf Is Nothing, Nothing, conf.TipoConfiguracion),
    '              .IdNumeracion = IIf(IsNothing(conf.ConfigComprobante), 0, conf.ConfigComprobante),
    '              .tipoOperacion = "01",
    '              .codigoLibro = "14",
    '              .tipoDocumento = conf.TipoComprobante,
    '              .idEmpresa = Gempresas.IdEmpresaRuc,
    '              .idEstablecimiento = GEstableciento.IdEstablecimiento,
    '              .fechaDoc = txtFecha.Value,
    '              .fechaPeriodo = GetPeriodo(txtFecha.Value, True),' lblPerido.Text,
    '              .serie = conf.Serie,
    '              .numeroDocNormal = Nothing,
    '              .idCliente = idProveedor,
    '              .nombrePedido = proveedor,
    '              .moneda = If(cboMoneda.Text = "NACIONAL", "1", "2"),
    '              .tasaIgv = TmpIGV,
    '              .tipoCambio = TmpTipoCambio,
    '              .bi01 = DocumentoVenta.bi01,
    '              .bi02 = DocumentoVenta.bi02,
    '              .igv01 = DocumentoVenta.igv01,
    '              .igv02 = DocumentoVenta.igv02,
    '              .bi01us = DocumentoVenta.bi01us,
    '              .bi02us = DocumentoVenta.bi02us,
    '              .igv01us = DocumentoVenta.igv01us,
    '              .igv02us = DocumentoVenta.igv02us,
    '              .ImporteNacional = DocumentoVenta.ImporteNacional,
    '              .ImporteExtranjero = DocumentoVenta.ImporteExtranjero,
    '              .tipoVenta = TIPO_VENTA.COTIZACION,
    '              .estadoCobro = TIPO_VENTA.PAGO.PENDIENTE_PAGO,
    '              .glosa = "Por cotizacion de venta",
    '              .usuarioActualizacion = usuario.IDUsuario,
    '              .fechaActualizacion = DateTime.Now}
    '    ndocumento.documentoventaAbarrotes = nDocumentoVenta


    '    'REGISTRANDO LA GUIA DE REMISION
    '    'GuiaRemision(ndocumento)

    '    For Each r In DocumentoVenta.documentoventaAbarrotesDet.ToList
    '        objDocumentoVentaDet = New documentoventaAbarrotesDet
    '        'Select Case r.GetValue("valPago")
    '        '    Case "Pagado"
    '        '        objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.COBRADO
    '        '    Case Else
    '        '        objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO
    '        'End Select
    '        objDocumentoVentaDet.IdEmpresa = Gempresas.IdEmpresaRuc
    '        objDocumentoVentaDet.IdEstablecimiento = GEstableciento.IdEstablecimiento ' almacenSA.GetUbicar_almacenPorID(i.Cells(24).Value()).idEstablecimiento
    '        objDocumentoVentaDet.FechaDoc = txtFecha.Value
    '        objDocumentoVentaDet.Serie = conf.Serie
    '        objDocumentoVentaDet.NumDoc = Nothing
    '        objDocumentoVentaDet.TipoDoc = conf.TipoComprobante
    '        If r.tipoExistencia = "GS" Then
    '            objDocumentoVentaDet.idAlmacenOrigen = Nothing
    '            objDocumentoVentaDet.tipoVenta = Nothing
    '        Else
    '            objDocumentoVentaDet.idAlmacenOrigen = r.idAlmacenOrigen
    '            'objDocumentoVentaDet.tipoVenta = r.GetValue("tipoPrecio")
    '        End If
    '        objDocumentoVentaDet.establecimientoOrigen = GEstableciento.IdEstablecimiento
    '        objDocumentoVentaDet.cuentaOrigen = Nothing
    '        objDocumentoVentaDet.idItem = r.idItem
    '        objDocumentoVentaDet.DetalleItem = r.nombreItem
    '        objDocumentoVentaDet.tipoExistencia = r.tipoExistencia
    '        objDocumentoVentaDet.destino = r.destino
    '        objDocumentoVentaDet.unidad1 = r.unidad1
    '        If r.monto1 <= 0 Then
    '            MessageBox.Show("Debe ingresar un cantidad mayor a cero.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Question)
    '            Exit Sub
    '        End If

    '        If r.importeMN <= 0 Then
    '            MessageBox.Show("El importe de venta debe ser mayor a cero.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Question)
    '            Exit Sub
    '        End If

    '        objDocumentoVentaDet.monto1 = r.monto1
    '        objDocumentoVentaDet.unidad2 = Nothing
    '        objDocumentoVentaDet.monto2 = Nothing 'i.Cells(31).Value()
    '        objDocumentoVentaDet.precioUnitario = r.precioUnitario
    '        objDocumentoVentaDet.precioUnitarioUS = r.precioUnitarioUS
    '        objDocumentoVentaDet.importeMN = r.importeME
    '        objDocumentoVentaDet.importeME = r.importeME
    '        objDocumentoVentaDet.descuentoMN = 0
    '        objDocumentoVentaDet.descuentoME = 0

    '        objDocumentoVentaDet.montokardex = r.montokardex
    '        objDocumentoVentaDet.montoIsc = 0
    '        objDocumentoVentaDet.montoIgv = r.montoIgv
    '        objDocumentoVentaDet.otrosTributos = 0
    '        '**********************************************************************************
    '        objDocumentoVentaDet.montokardexUS = r.montokardexUS
    '        objDocumentoVentaDet.montoIscUS = 0
    '        objDocumentoVentaDet.montoIgvUS = r.montoIgvUS
    '        objDocumentoVentaDet.otrosTributosUS = 0
    '        '  objDocumentoVentaDet.PreEvento = i.Cells(25).Value()
    '        objDocumentoVentaDet.estadoMovimiento = "NO" 'ENTREGADO/COBRADO
    '        '**********************************************************************************
    '        objDocumentoVentaDet.importeMNK = 0 'CDec(r.GetValue("puKardex"))
    '        objDocumentoVentaDet.importeMEK = 0 'CDec(r.GetValue("pukardeme"))
    '        objDocumentoVentaDet.fechaVcto = Nothing
    '        objDocumentoVentaDet.salidaCostoMN = 0
    '        objDocumentoVentaDet.salidaCostoME = 0
    '        objDocumentoVentaDet.categoria = Nothing
    '        objDocumentoVentaDet.preEvento = Nothing
    '        objDocumentoVentaDet.usuarioModificacion = usuario.IDUsuario
    '        objDocumentoVentaDet.fechaModificacion = Date.Now

    '        objDocumentoVentaDet.Glosa = "Por cotizacion de venta"
    '        ListaDetalle.Add(objDocumentoVentaDet)
    '    Next


    '    '-------------------------------------------------------------------------------------
    '    '---------------- VALIDACION DE IMPORTE CON DETALLE DE VENTA -------------------------
    '    Dim sumaVentaMN As Decimal = ListaDetalle.Sum(Function(o) o.importeMN).GetValueOrDefault
    '    Dim sumaVentaME As Decimal = ListaDetalle.Sum(Function(o) o.importeME).GetValueOrDefault
    '    Dim sumaBase1MN As Decimal =
    '        ListaDetalle.Where(Function(o) o.destino = OperacionGravada.Grabado).Sum(Function(o) o.montokardex).GetValueOrDefault

    '    Dim sumaBase1ME As Decimal =
    '        ListaDetalle.Where(Function(o) o.destino = OperacionGravada.Grabado).Sum(Function(o) o.montokardexUS).GetValueOrDefault

    '    Dim sumaBase2MN As Decimal =
    '        ListaDetalle.Where(Function(o) o.destino = OperacionGravada.Exonerado).Sum(Function(o) o.montokardex).GetValueOrDefault

    '    Dim sumaBase2ME As Decimal =
    '        ListaDetalle.Where(Function(o) o.destino = OperacionGravada.Exonerado).Sum(Function(o) o.montokardexUS).GetValueOrDefault

    '    Dim sumaIgvMN As Decimal = ListaDetalle.Sum(Function(o) o.montoIgv).GetValueOrDefault
    '    Dim sumaIgvME As Decimal = ListaDetalle.Sum(Function(o) o.montoIgvUS).GetValueOrDefault

    '    Dim totalVentaDetalle As Decimal = sumaBase1MN + sumaBase2MN + sumaIgvMN
    '    Dim totalHeader As Decimal = txtTotalPagar.DecimalValue
    '    If totalHeader <> totalVentaDetalle Then
    '        Throw New Exception("Los importes no coinciden, tanto del detalle con la cabecera ")
    '    End If
    '    '-------------------------------------------------------------------------------------


    '    ndocumento.documentoventaAbarrotes.documentoventaAbarrotesDet = ListaDetalle
    '    Dim cod = VentaSA.GrabarCotizacion(ndocumento)
    '    MessageBox.Show("Proforma registrada", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    'LimpiarControles()
    '    'Alert = New Alert("Proforma registrada", alertType.success)
    '    'Alert.TopMost = True
    '    'Alert.Show()

    '    'Dim f As New FormImpresionNuevo
    '    'f.DocumentoID = cod
    '    'f.StartPosition = FormStartPosition.CenterScreen
    '    'f.ShowDialog(Me)
    '    'VentaSA.GetActualizarImpresion(New documentoventaAbarrotes With {.idDocumento = cod})
    '    'Dim miInterfaz As ICommitOperacionMKT = TryCast(Me.Owner, ICommitOperacionMKT)
    '    'If miInterfaz IsNot Nothing Then miInterfaz.Commit(True, cod)
    '    'objPleaseWait.Close()
    '    'Close()

    'End Sub

    Private Function GetConfiguracionUsuario(usuarioSel As Seguridad.Business.Entity.Usuario, cajaUsuario As cajaUsuario) As EnvioImpresionVendedorPernos
        Dim envio As EnvioImpresionVendedorPernos
        envio = New EnvioImpresionVendedorPernos With
            {
            .CodigoVendedor = usuarioSel.codigo,
            .IDCaja = cajaUsuario.idcajaUsuario,' ComboCaja.SelectedValue,
            .IDVendedor = usuarioSel.IDUsuario,
            .print = True,
            .Nombreprint = String.Empty,
            .NombreCajero = usuarioSel.Full_Name,
            .EntidadFinanciera = 0,'ef.idestado,
            .EntidadFinancieraName = String.Empty
        }
        Return envio
    End Function

    Private Sub GrabarVentaEquivalencia()
        Dim cajaUsuaroSA As New cajaUsuarioSA
        Dim envio As EnvioImpresionVendedorPernos = Nothing
        Dim ventaSA As New documentoVentaAbarrotesSA
        Dim obj As New documento
        Try
            '   Dim cajaUsuario = cajaUsuaroSA.UbicarCajaUsuarioPorID(codigo)
            'Dim usuarioSel = ListaCajasActivas.Where(Function(o) o.idPersona = usuario.IDUsuario).SingleOrDefault
            Dim usuarioSel = listaActivas.Where(Function(o) o.idcajaUsuario = Integer.Parse(ComboCaja.SelectedValue)).SingleOrDefault
            If usuarioSel Is Nothing Then
                btOperacion.Enabled = True
                MessageBox.Show("Debe aperturar una caja realizar la venta!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            'Dim codigoVendedor = UCCondicionesPago.UCPagoCompletoDocumento.TextCodigoVendedor.Text.Trim
            'Dim usuarioSel = UsuariosList.Where(Function(o) o.codigo = codigoVendedor).FirstOrDefault

            If usuarioSel IsNot Nothing Then
                obj = MappingDocumento()
                If ChPagoAvanzado.Checked = True Then
                    'Dim codigo As Integer = Integer.Parse(UCCondicionesPago.UCPagoCompletoDocumento.ComboCaja.SelectedValue)
                    'Dim cajaUsuario = cajaUsuaroSA.UbicarCajaUsuarioPorID(usuarioSel.idcajaUsuario)

                    Dim usuarioPedido = UsuariosList.Where(Function(o) o.IDUsuario = DocumentoVenta.usuarioActualizacion).SingleOrDefault

                    envio = GetConfiguracionUsuario(usuarioPedido, usuarioSel)
                ElseIf chCredito.Checked = True Then

                End If

                'Select Case UCEstructuraCabeceraVentaV2.ComboTerminosPago.Text
                '    Case "CONTADO"

                '    Case "CREDITO"

                '    Case "CRONOGRAMA"
                '        'If UCCondicionesPago.UCCronogramaPagos.ListaCronograma IsNot Nothing Then
                '        obj.Cronograma = New List(Of Cronograma)
                '        obj.Cronograma = UCCondicionesPago.UCCronogramaPagos.ListaCronograma
                '        'Else
                '        'Throw New Exception("Debe registrar el cronograma de pagos")
                '        'End If
                'End Select
                MappingDocumentoCompraCabecera(obj)
                MappingDocumentoCompraCabeceraDetalle(obj)

                Select Case obj.tipoDoc
                    Case "03", "01", "9907"
                        MappingPagos(envio, obj)
                    Case "9903", "1000" ' PROFORMA

                End Select

                'If validarCanastaDeVentas(obj) Then
                Dim docImpresion = obj
                '  obj.AfectaInventario = SwitchInventario.Value
                Dim ListaPagos = obj.ListaCustomDocumento
                Dim doc = ventaSA.GrabarVentaEquivalencia(obj)
                docImpresion.idDocumento = obj.idDocumento
                docImpresion.documentoventaAbarrotes.idDocumento = obj.idDocumento
                If cboTipoDoc.Text = "FACTURA" Or cboTipoDoc.Text = "BOLETA" Then
                    If My.Computer.Network.IsAvailable = True Then
                        If My.Computer.Network.Ping("138.128.171.106") Then
                            If Gempresas.ubigeo > 0 Then

                                Dim documentoSave = ventaSA.GetVentaID(New documento With {.idDocumento = doc.idDocumento})
                                Dim documentoEnvio As New documento With {.idDocumento = doc.idDocumento}
                                documentoEnvio.documentoventaAbarrotes = documentoSave
                                documentoEnvio.ListaCustomDocumento = ListaPagos
                                EnviarFacturaElectronica(documentoEnvio, Gempresas.ubigeo)

                                FormImpresionNuevo = New FormImpresionEquivalencia(documentoEnvio)  ' frmVentaNuevoFormato
                                FormImpresionNuevo.tienda = ""
                                FormImpresionNuevo.FormaPago = ""
                                FormImpresionNuevo.DocumentoID = doc.idDocumento
                                FormImpresionNuevo.Email = ""
                                FormImpresionNuevo.StartPosition = FormStartPosition.CenterScreen

                                FormImpresionNuevo.ShowDialog(Me)
                            End If
                        End If
                    Else
                        MessageBox.Show("Envio a Respositorio!", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'Alert = New Alert("Envio a Respositorio", alertType.success)
                        'Alert.TopMost = True
                        'Alert.Show()
                    End If
                ElseIf cboTipoDoc.Text = "NOTA" Then

                    Dim documentoSave = ventaSA.GetVentaID(New documento With {.idDocumento = doc.idDocumento})
                    Dim documentoEnvio As New documento With {.idDocumento = doc.idDocumento}
                    documentoEnvio.documentoventaAbarrotes = documentoSave
                    documentoEnvio.ListaCustomDocumento = ListaPagos

                    FormImpresionNuevo = New FormImpresionEquivalencia(documentoEnvio)  ' frmVentaNuevoFormato
                    FormImpresionNuevo.tienda = ""
                    FormImpresionNuevo.FormaPago = ""
                    FormImpresionNuevo.DocumentoID = doc.idDocumento
                    FormImpresionNuevo.Email = ""
                    FormImpresionNuevo.StartPosition = FormStartPosition.CenterScreen

                    FormImpresionNuevo.ShowDialog(Me)
                End If
                '   MessageBox.Show("Venta registrada!", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                DocumentoVenta = Nothing

                ChPagoAvanzado.Checked = True
                PagoDirectoCheck()
                btOperacion.Enabled = False
                TextCodigoVendedor.Clear()
                TextComprador.Clear()
                lblPagoVenta.Text = "0.00"
                txtTotalBase.DecimalValue = 0
                txtTotalBase2.DecimalValue = 0
                txtTotalBase3.DecimalValue = 0
                txtTotalIva.DecimalValue = 0
                TextTotalDescuentos.DecimalValue = 0
                txtTotalPagar.DecimalValue = 0
                LabelTotalCobrarCliente.Text = "0.00"
                TextPagoAnticipoDisponible.DecimalValue = 0
                TextValoranticipo.DecimalValue = 0
                'VUELTO
                TextTotalPagosCliente.DecimalValue = 0
                LabelTotalCobrarCliente.Text = "0.00"
                LabelVueltoCliente.Text = "0.00"
                '***********************************************
                GetUbicarClienteGeneral()

                chCredito.Checked = False
                LblPagoCredito.Visible = False
                chCobranzaParcial.Checked = False
                PanelCupon.Visible = False
                ErrorProvider1.Clear()
                GetMappingColumnsGrid()

                Alert = New Alert("Venta registrada", alertType.success)
                Alert.TopMost = True
                Alert.Show()

                HabilitarPago(False)
                ToolImportar.PerformClick()
                '  Close()
                'Else
                '    MessageBox.Show("Debe ingresar una cantidad mayor a cero", "Verificar el detalle de venta", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '    btGrabar.Enabled = True
                'End If
            Else
                MessageBox.Show("Ingrese un código valido", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                'btGrabar.Enabled = True
                'UCCondicionesPago.UCPagoCompletoDocumento.TextCodigoVendedor.Select()
            End If
        Catch ex As Exception
            btOperacion.Enabled = True
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Atención")
        End Try
    End Sub

    Private Async Sub GetApiSunat(ByVal nroruc As String)
        SelRazon = New entidad()
        Dim responseTask As New HttpResponseMessage
        Using client = New HttpClient()
            If nroruc.ToString().Trim().Substring(0, 1) = "1" Then
                SelRazon.tipoPersona = "N"
            ElseIf nroruc.ToString().Trim().Substring(0, 1) = "2" Then
                SelRazon.tipoPersona = "J"
            End If

            Select Case ApiRucOption
                Case ApisRuc.ApiRucCloudPeru
                    responseTask = Await client.GetAsync("https://api.peruonline.cloud/v1/?ruc=" & nroruc)

                    If responseTask.IsSuccessStatusCode Then
                        Dim readTask = responseTask.Content.ReadAsAsync(Of SunatContribuyente)()
                        readTask.Wait()
                        Dim students = readTask.Result
                        SelRazon.tipoDoc = "6"
                        SelRazon.tipoEntidad = "CL"
                        SelRazon.nombreCompleto = students.NombreORazonSocial
                        SelRazon.nombreContacto = students.NombreORazonSocial
                        TextProveedor.Text = students.NombreORazonSocial
                        SelRazon.estado = students.EstadoDelContribuyente
                        SelRazon.nrodoc = students.Ruc
                        SelRazon.direccion = students.Direccion & " " & students.Manzana & " " & students.Lote & " " & students.CodigoDeZona & " " & students.TipoDeZona

                        SelRazon.TipoVia = students.TipoDeVia
                        SelRazon.Via = students.NombreDeVia
                        SelRazon.Ubigeo = students.Ubigeo

                        GrabarEntidadRapida()
                        PictureLoad.Visible = False
                    Else
                        GetConsultaSunatAsync(nroruc)

                        'TextProveedor.Clear()
                        'PictureLoad.Visible = False
                    End If
                    TextNumIdentrazon.ReadOnly = False

                Case ApisRuc.ApiRucSunatCloud
                    responseTask = Await client.GetAsync("https://api.sunat.cloud/ruc/" & nroruc)

                    If responseTask.IsSuccessStatusCode Then
                        Dim readTask = responseTask.Content.ReadAsAsync(Of SunatContribuyente2)()
                        readTask.Wait()
                        Dim students = readTask.Result
                        SelRazon.tipoDoc = "6"
                        SelRazon.tipoEntidad = "CL"
                        SelRazon.nombreCompleto = students.NombreORazonSocial
                        SelRazon.nombreContacto = students.NombreORazonSocial
                        TextProveedor.Text = students.NombreORazonSocial
                        SelRazon.estado = students.EstadoDelContribuyente
                        SelRazon.nrodoc = students.Ruc
                        SelRazon.direccion = students.Direccion

                        'SelRazon.TipoVia = students.TipoDeVia
                        'SelRazon.Via = students.NombreDeVia
                        'SelRazon.Ubigeo = students.Ubigeo

                        GrabarEntidadRapida()
                        PictureLoad.Visible = False
                    Else
                        GetConsultaSunatAsync(nroruc)

                        'TextProveedor.Clear()
                        'PictureLoad.Visible = False
                    End If
                    TextNumIdentrazon.ReadOnly = False

                Case ApisRuc.ApiRucaqfac
                    responseTask = Await client.GetAsync("http://ruc.aqpfact.pe/sunat/" & nroruc)

                    If responseTask.IsSuccessStatusCode Then
                        Dim readTask = responseTask.Content.ReadAsAsync(Of SunatContribuyente3)()
                        readTask.Wait()
                        Dim students = readTask.Result
                        SelRazon.tipoDoc = "6"
                        SelRazon.tipoEntidad = "CL"
                        SelRazon.nombreCompleto = students.NombreORazonSocial
                        SelRazon.nombreContacto = students.NombreORazonSocial
                        TextProveedor.Text = students.NombreORazonSocial
                        SelRazon.estado = students.EstadoDelContribuyente
                        SelRazon.nrodoc = students.Ruc
                        SelRazon.direccion = students.Direccion

                        'SelRazon.TipoVia = students.TipoDeVia
                        'SelRazon.Via = students.NombreDeVia
                        'SelRazon.Ubigeo = students.Ubigeo

                        GrabarEntidadRapida()
                        PictureLoad.Visible = False
                    Else
                        GetConsultaSunatAsync(nroruc)

                        'TextProveedor.Clear()
                        'PictureLoad.Visible = False
                    End If
                    TextNumIdentrazon.ReadOnly = False

            End Select
        End Using
    End Sub

    Public Sub EnviarFacturaElectronica(doc As documento, idPSE As Integer)

        Dim documentoSA As New documentoVentaAbarrotesSA
        Dim documentoDetSA As New documentoVentaAbarrotesDetSA
        Dim entidadSA As New entidadSA
        Dim DetalleFactura As Fact.Sunat.Business.Entity.DocumentoElectronicoDetalle
        Try
            Dim comprobante = doc.documentoventaAbarrotes 'documentoSA.GetVentaID(New documento With {.idDocumento = doc.idDocumento})
            'Dim comprobanteDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(doc.idDocumento)
            Dim receptor = comprobante.CustomEntidad ' entidadSA.GetUbicarEntPorID(Gempresas.IdEmpresaRuc, comprobante.idCliente)
            Dim numerovent As String = String.Format("{0:00000000}", comprobante.numeroVenta)
            Dim tipoDoc = String.Format("{0:00}", comprobante.tipoDocumento)
            Dim conteo As Integer = 0
            '//Enviando el documento
            Dim Factura As New Fact.Sunat.Business.Entity.DocumentoElectronico
            'Datos del Cliente 
            Factura.Action = 0
            Factura.idEmpresa = idPSE 'lblIdPse.Text
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
            Factura.FechaVencimiento = DateTime.Now
            Factura.HoraEmision = comprobante.fechaDoc.Value.ToString("HH:mm:ss")
            Factura.TipoDocumento = tipoDoc
            Factura.TipoOperacion = "0101"

            Factura.TotalIcbper = comprobante.icbper.GetValueOrDefault

            If comprobante.importeCostoMN.GetValueOrDefault > 0 Then
                Factura.DescuentoGlobal = comprobante.importeCostoMN.GetValueOrDefault
            Else
                Factura.DescuentoGlobal = 0
            End If

            If comprobante.moneda = "1" Then
                Factura.Moneda = "PEN"
                Factura.TotalIgv = comprobante.igv01
                Factura.TotalVenta = comprobante.ImporteNacional
                Factura.Gravadas = comprobante.bi01
                Factura.Exoneradas = comprobante.bi02
            ElseIf comprobante.moneda = "2" Then
                Factura.Moneda = "USD"
                Factura.TotalIgv = comprobante.igv01us
                Factura.TotalVenta = comprobante.ImporteExtranjero
                Factura.Gravadas = comprobante.bi01us
                Factura.Exoneradas = comprobante.bi02us
            End If



            'Cargando el Detalle de la Factura
            Dim precioSinIva As Decimal = 0
            Dim precioConIva As Decimal = 0
            Dim cantEquiva As Decimal = 0
            For Each i In comprobante.documentoventaAbarrotesDet
                DetalleFactura = New Fact.Sunat.Business.Entity.DocumentoElectronicoDetalle
                Select Case i.tipoExistencia
                    Case TipoExistencia.ServicioGasto
                        cantEquiva = i.monto1 '1
                        DetalleFactura.CodigoItem = 1
                    Case Else
                        cantEquiva = i.monto1 * i.CustomEquivalencia.fraccionUnidad.GetValueOrDefault
                        DetalleFactura.CodigoItem = i.idItem
                End Select

                'cantEquiva = i.monto1 * i.CustomEquivalencia.fraccionUnidad.GetValueOrDefault
                precioSinIva = i.montokardex / cantEquiva
                precioConIva = i.importeMN / cantEquiva

                conteo += 1

                DetalleFactura.Id = conteo
                DetalleFactura.Cantidad = cantEquiva ' i.monto1 * i.CustomEquivalencia.fraccionUnidad.GetValueOrDefault 'i.monto1

                DetalleFactura.Descripcion = i.nombreItem
                DetalleFactura.UnidadMedida = i.unidad1

                If doc.documentoventaAbarrotes.moneda = "1" Then
                    DetalleFactura.PrecioReferencial = precioConIva 'i.precioUnitario
                    DetalleFactura.Impuesto = i.montoIgv
                    DetalleFactura.TotalVenta = i.montokardex
                    If i.destino = "1" Then
                        DetalleFactura.TipoImpuesto = "10" 'CATALOGO 7
                        DetalleFactura.TipoPrecio = "01" 'CATALOGO 16
                        DetalleFactura.PrecioUnitario = precioSinIva ' CalculoBaseImponible(i.precioUnitario, 1.18) 'FormatNumber(CalculoBaseImponible(i.precioUnitario, 1.18), 2)
                    ElseIf i.destino = "2" Then
                        DetalleFactura.TipoImpuesto = "20" 'CATALOGO 7
                        DetalleFactura.TipoPrecio = "01" '"02"  'CATALOGO 16
                        DetalleFactura.PrecioUnitario = precioConIva ' i.precioUnitario
                    End If
                ElseIf doc.documentoventaAbarrotes.moneda = "2" Then
                    'DetalleFactura.PrecioReferencial = i.precioUnitarioUS
                    'DetalleFactura.Impuesto = i.montoIgvUS
                    'DetalleFactura.TotalVenta = i.montokardexUS
                    'If i.destino = "1" Then
                    '    DetalleFactura.TipoImpuesto = "10" 'CATALOGO 7
                    '    DetalleFactura.TipoPrecio = "01" 'CATALOGO 16
                    '    DetalleFactura.PrecioUnitario = CalculoBaseImponible(i.precioUnitarioUS, 1.18) 'FormatNumber(CalculoBaseImponible(i.precioUnitario, 1.18), 2)
                    'ElseIf i.destino = "2" Then
                    '    DetalleFactura.TipoImpuesto = "20" 'CATALOGO 7
                    '    DetalleFactura.TipoPrecio = "01" '"02"  'CATALOGO 16
                    '    DetalleFactura.PrecioUnitario = i.precioUnitarioUS
                    'End If
                End If

                If i.tasaIcbper.GetValueOrDefault > 0 Then
                    DetalleFactura.TotalIcbper = i.montoIcbper.GetValueOrDefault
                    DetalleFactura.ImpuestoIcbper = i.tasaIcbper.GetValueOrDefault
                    DetalleFactura.CantidadBolsa = cantEquiva
                Else
                    DetalleFactura.TotalIcbper = 0
                    DetalleFactura.ImpuestoIcbper = 0
                    DetalleFactura.CantidadBolsa = 0
                End If

                'DetalleItems .Descuento = "falta"
                'DetalleItems .ImpuestoSelectivo = "falta"
                'DetalleItems.OtroImpuesto = "falta"
                'DetalleItems.PlacaVehiculo = "falta"
                Factura.DocumentoElectronicoDetalle.Add(DetalleFactura)
            Next
            'Enviando al PSE
            Dim codigo = Helios.Fact.Sunat.WCFService.ServiceAccess.Admin.DocumentoElectronicoSA.DocumentoElectronicoSave(Factura, Nothing)

            If codigo.idDocumentoElectronico > 0 Then
                UpdateEnvioSunatEstado(comprobante.idDocumento, "SI")
                'MessageBox.Show("La Factura se Envio Correctamente al PSE")
            End If

        Catch ex As Exception

            'MessageBox.Show("No se Pudo Enviar")

        End Try


    End Sub

#Region "ClienteNuevo"

    Private Function GetConsultarDNIReniec(Dni As String) As String
        Dim CLIENTE As New WebClient
        Dim PAGINA As Stream = CLIENTE.OpenRead("http://aplicaciones007.jne.gob.pe/srop_publico/Consulta/Afiliado/GetNombresCiudadano?DNI=" & Dni)
        Dim LECTOR As New StreamReader(PAGINA)
        Dim MIHTML As String = LECTOR.ReadToEnd
        ' Dim array = MIHTML.Split("|")

        Dim nombres = MIHTML.Replace("|", Space(1))
        Return Trim(nombres)
    End Function

    Private Function GetValidarLocalDB(idEntidad As String) As Boolean
        GetValidarLocalDB = False
        Dim entidadSA As New entidadSA

        Dim entidad = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", idEntidad)
        If entidad IsNot Nothing Then
            SelRazon = New entidad
            SelRazon = entidad
            TextProveedor.Text = entidad.nombreCompleto
            TextProveedor.Tag = entidad.idEntidad
            GetValidarLocalDB = True
            PictureLoad.Visible = False

            If TextProveedor.Text.Trim.Length > 0 Then
                btOperacion.Select()
                ' btOperacion.Focus()
            Else
                TextNumIdentrazon.Clear()
                TextNumIdentrazon.Select()
            End If
        End If
    End Function

    Private Sub GrabarEntidadRapida()
        Dim obEntidad As New entidad
        Dim entidadSA As New entidadSA
        Try
            'Se asigna cada uno de los datos registrados
            obEntidad.idEmpresa = Gempresas.IdEmpresaRuc
            obEntidad.idOrganizacion = GEstableciento.IdEstablecimiento
            obEntidad.tipoEntidad = "CL"
            obEntidad.tipoDoc = SelRazon.tipoDoc
            obEntidad.tipoPersona = SelRazon.tipoPersona
            obEntidad.nrodoc = SelRazon.nrodoc
            obEntidad.nombreCompleto = TextProveedor.Text.Trim
            obEntidad.cuentaAsiento = "1213"
            obEntidad.direccion = SelRazon.direccion
            obEntidad.estado = StatusEntidad.Activo
            Dim codx As Integer = entidadSA.GrabarEntidad(obEntidad)

            TextProveedor.Tag = codx
            Dim entidad As New entidad
            entidad.idEntidad = codx
            entidad.nrodoc = TextNumIdentrazon.Text.Trim
            entidad.nombreCompleto = obEntidad.nombreCompleto
            entidad.tipoDoc = obEntidad.tipoDoc
            Me.Tag = entidad
            'If RadioButton2.Checked = True Then
            '    textPersona.Focus()
            '    textPersona.Select()
            'ElseIf RadioButton1.Checked = True Then
            '    txtruc.Focus()
            '    txtruc.Select()
            'End If
            'Transporte.ListaEmpresas.Add(entidad)

            '    Dispose()
        Catch ex As Exception
            'Manejo de errores
            MsgBox("No se pudo grabar el cliente." & vbCrLf & ex.Message, MsgBoxStyle.Critical)
            Me.Tag = Nothing
        End Try
    End Sub

    Private Async Sub GetConsultaSunatAsync(ruc As String)
        SelRazon = New entidad
        Dim nroDoc = ruc.Substring(0, 1).ToString
        If nroDoc = "1" Then
            Dim company = CType(Await SoftPackERP_Sunat.GetRucContribuyenteSPK.GetContribuyente(ruc), SoftPackERP_Sunat.CompanyJuridico)
            If company IsNot Nothing Then
                If company.ContribuyenteTipo = "PERSONA NATURAL SIN NEGOCIO" Then
                    SelRazon.tipoPersona = "N"
                    SelRazon.tipoDoc = "6"
                End If
                SelRazon.tipoEntidad = "CL"
                SelRazon.nombreCompleto = company.RazonSocial
                TextProveedor.Text = company.RazonSocial
                SelRazon.nombreContacto = company.RazonSocial
                SelRazon.estado = company.ContribuyenteEstado
                SelRazon.nrodoc = company.Ruc
                SelRazon.direccion = company.DomicilioFiscal
                GrabarEntidadRapida()
                PictureLoad.Visible = False
            Else
                TextProveedor.Clear()
                PictureLoad.Visible = False
            End If
        ElseIf nroDoc = "2" Then
            Dim company = CType(Await SoftPackERP_Sunat.GetRucContribuyenteSPK.GetContribuyente(ruc), SoftPackERP_Sunat.CompanyJuridico)
            If company IsNot Nothing Then
                'If company.ContribuyenteTipo = "SOCIEDAD ANONIMA CERRADA" Then
                SelRazon.tipoPersona = "J"
                SelRazon.tipoDoc = "6"
                '  End If
                SelRazon.nombreCompleto = company.RazonSocial
                SelRazon.nombreContacto = company.RazonSocial
                TextProveedor.Text = company.RazonSocial
                SelRazon.estado = company.ContribuyenteEstado
                SelRazon.direccion = company.DomicilioFiscal
                SelRazon.nrodoc = company.Ruc
                'If company.RepresentanteLegal IsNot Nothing Then
                '    If company.RepresentanteLegal.Dni41094462 IsNot Nothing Then
                '        With company.RepresentanteLegal.Dni41094462
                '            txtContacto.Text = String.Format("{0}/{1}/{2}", .Cargo, .Nombre, .Desde)
                '        End With
                '    End If
                'End If
                GrabarEntidadRapida()
                PictureLoad.Visible = False
            Else
                TextProveedor.Clear()
                PictureLoad.Visible = False
            End If
        End If

    End Sub

    Private Sub GrabarEnFormBasico()
        Dim f As New frmCrearENtidades
        f.strTipo = TIPO_ENTIDAD.CLIENTE
        f.CaptionLabels(0).Text = "Nuevo cliente"
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            Dim ent = CType(f.Tag, entidad)
            TextNumIdentrazon.Text = ent.nrodoc
            TextProveedor.Text = ent.nombreCompleto
            TextProveedor.Tag = ent.idEntidad
        Else
            TextNumIdentrazon.Text = String.Empty
            TextProveedor.Text = String.Empty
            TextProveedor.Tag = Nothing
        End If
    End Sub

    Private Sub TextNumIdentrazon_KeyDown(sender As Object, e As KeyEventArgs) Handles TextNumIdentrazon.KeyDown
        Dim nombres = String.Empty
        Try
            'TextNumIdentrazon.Enabled = False
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True

                Select Case TextNumIdentrazon.Text.Trim.Length
                    Case 8 'dni

                        SelRazon = New entidad

                        If My.Computer.Network.IsAvailable = True Then
                            PictureLoad.Visible = True
                            nombres = GetConsultarDNIReniec(TextNumIdentrazon.Text.Trim)

                            If nombres.Trim.Length > 0 Then

                                If nombres = "DNI no encontrado en Padrón Electoral" Then
                                    TextNumIdentrazon.Clear()
                                    TextProveedor.Text = String.Empty
                                    TextProveedor.Tag = Nothing
                                    PictureLoad.Visible = False
                                    Exit Sub
                                End If

                                SelRazon.tipoEntidad = "CL"
                                SelRazon.nombreCompleto = nombres
                                SelRazon.nrodoc = TextNumIdentrazon.Text.Trim
                                SelRazon.tipoDoc = "1"
                                SelRazon.tipoPersona = "N"
                                TextProveedor.Text = nombres

                                Dim existeEnDB = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", TextNumIdentrazon.Text.Trim)

                                If existeEnDB Is Nothing Then
                                    TextProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    GrabarEntidadRapida()
                                    PictureLoad.Visible = False
                                Else
                                    TextProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    TextProveedor.Tag = existeEnDB.idEntidad
                                    'If RadioButton2.Checked = True Then
                                    btOperacion.Select()
                                    'TextFiltrar.Select()
                                    'ElseIf RadioButton1.Checked = True Then
                                    '    txtruc.Focus()
                                    '    txtruc.Select()
                                    'End If
                                End If
                            Else
                                TextNumIdentrazon.Clear()
                                TextProveedor.Text = String.Empty
                                TextProveedor.Tag = Nothing
                            End If
                            PictureLoad.Visible = False
                        Else

                            'CUANDO NO HAY CONEXION A INTERNET
                            Dim existeEnDB = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", TextNumIdentrazon.Text.Trim)
                            If existeEnDB Is Nothing Then
                                SelRazon.tipoEntidad = "CL"
                                SelRazon.nombreCompleto = TextProveedor.Text.Trim
                                SelRazon.nrodoc = TextNumIdentrazon.Text.Trim
                                SelRazon.tipoDoc = "1"
                                SelRazon.tipoPersona = "N"
                                'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                'GrabarEntidadRapida()
                                GrabarEnFormBasico()
                                PictureLoad.Visible = False
                            Else
                                TextProveedor.Text = existeEnDB.nombreCompleto
                                TextProveedor.Tag = existeEnDB.idEntidad
                                TextProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                'If RadioButton2.Checked = True Then
                                ''TextFiltrar.Focus()
                                btOperacion.Select()
                                'ElseIf RadioButton1.Checked = True Then
                                '    txtruc.Focus()
                                '    txtruc.Select()
                                'End If
                            End If
                        End If



                    Case 11 'razonSocial
                        PictureLoad.Visible = True
                        Dim objeto As Boolean = ValidationRUC(TextNumIdentrazon.Text.Trim)
                        If objeto = False Then
                            PictureLoad.Visible = False
                            MessageBox.Show("Debe Ingresar un número correcto de ruc", "Ingresar identificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Cursor = Cursors.Default
                            TextProveedor.Clear()
                            Exit Sub
                        End If

                        If My.Computer.Network.IsAvailable = True Then
                            'VALIDAR SI EXISTE EN LA bd LOCAL PRIMERO 
                            If GetValidarLocalDB(TextNumIdentrazon.Text.Trim) = False Then
                                TextNumIdentrazon.ReadOnly = True

                                Select Case ToggleConsultas.ToggleState
                                    Case ToggleButton2.ToggleButtonState.OFF ' API
                                        '  GetConsultaSunatAsync(TextNumIdentrazon.Text.Trim)
                                        GetApiSunat(TextNumIdentrazon.Text.Trim)
                                        'GetApiSunatVer2(TextNumIdentrazon.Text.Trim)
                                    Case ToggleButton2.ToggleButtonState.ON ' WEB
                                        BgProveedor.RunWorkerAsync()
                                End Select
                            End If
                        Else
                            'SI NO HAY CONEXION A INTERNET
                            If GetValidarLocalDB(TextNumIdentrazon.Text.Trim) = False Then
                                Dim nroDoc = TextNumIdentrazon.Text.Trim.Substring(0, 1).ToString
                                If nroDoc = "1" Then
                                    'SelRazon.tipoEntidad = "CL"
                                    'SelRazon.nombreCompleto = TextEmpresaPasajero.Text.Trim
                                    'SelRazon.nrodoc = TextNumIdentrazon.Text.Trim
                                    'SelRazon.tipoDoc = "6"
                                    'SelRazon.tipoPersona = "N"
                                    'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    'GrabarEntidadRapida()
                                    GrabarEnFormBasico()
                                    PictureLoad.Visible = False
                                    If TextProveedor.Text.Trim.Length > 0 Then
                                        TextNumIdentrazon.Select()
                                        TextNumIdentrazon.Focus()
                                    Else
                                        TextNumIdentrazon.Clear()
                                        TextNumIdentrazon.Select()
                                    End If
                                ElseIf nroDoc = "2" Then
                                    'SelRazon.tipoEntidad = "CL"
                                    'SelRazon.nombreCompleto = TextEmpresaPasajero.Text.Trim
                                    'SelRazon.nrodoc = TextNumIdentrazon.Text.Trim
                                    'SelRazon.tipoDoc = "6"
                                    'SelRazon.tipoPersona = "J"
                                    'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    'GrabarEntidadRapida()
                                    GrabarEnFormBasico()
                                    PictureLoad.Visible = False
                                    If TextProveedor.Text.Trim.Length > 0 Then
                                        TextNumIdentrazon.Select()
                                        TextNumIdentrazon.Focus()
                                    Else
                                        TextNumIdentrazon.Clear()
                                        TextNumIdentrazon.Select()
                                    End If
                                End If
                            End If
                        End If

                    Case Else
                        TextProveedor.Text = String.Empty
                        TextNumIdentrazon.Text = String.Empty
                        MessageBox.Show("Ingrese un documento correcto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Select

            End If
            '    TextNumIdentrazon.Enabled = True

        Catch ew As WebException

            If ew.Status = WebExceptionStatus.ProtocolError Then
                PictureLoad.Visible = False
                Dim [error] As String = New System.IO.StreamReader(ew.Response.GetResponseStream()).ReadToEnd()
                MessageBox.Show("DNI no encontrado en el padron, verifique si es menor de edad")
                TextNumIdentrazon.Clear()
                TextNumIdentrazon.Select()
                TextNumIdentrazon.Focus()
                TextProveedor.Clear()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region

    Private Function MappingDocumento() As documento
        'Dim IDCliente As Integer = 0
        'Dim Cliente As String = String.Empty

        Dim fechaVenta = DateTime.Now


        'If UCEstructuraCabeceraVentaV2.RadioButton1.Checked = True Then ' razon social
        '    IDCliente = UCEstructuraCabeceraVentaV2.TextProveedor.Tag
        '    Cliente = UCEstructuraCabeceraVentaV2.TextProveedor.Text
        'Else ' cliente varios
        '    IDCliente = UCEstructuraCabeceraVentaV2.TextProveedor.Tag
        '    Cliente = UCEstructuraCabeceraVentaV2.TextProveedor.Text
        'End If

        MappingDocumento = New documento With
        {
         .TipoEnvio = "PREVENTA",
        .idEmpresa = Gempresas.IdEmpresaRuc,
        .idCentroCosto = GEstableciento.IdEstablecimiento,
        .idProyecto = 0,
        .tipoDoc = cboTipoDoc.SelectedValue,
        .fechaProceso = fechaVenta,
        .moneda = DocumentoVenta.moneda,
        .idEntidad = TextProveedor.Tag,
        .entidad = TextProveedor.Text,
        .tipoEntidad = TIPO_ENTIDAD.CLIENTE,
        .nrodocEntidad = TextNumIdentrazon.Text,
        .nroDoc = "0",'$"{UCEstructuraCabeceraVentaV2.txtSerie.Text}-{UCEstructuraCabeceraVentaV2.txtNumero.Text}",
        .idOrden = 0,
        .tipoOperacion = StatusTipoOperacion.VENTA,
        .usuarioActualizacion = DocumentoVenta.usuarioActualizacion,' usuario.IDUsuario,
        .fechaActualizacion = Date.Now,
          .IdPerfil = usuario.IDRol
        }
    End Function

    Private Sub MappingDocumentoCompraCabecera(be As documento)
        Dim tipoVenta As String = String.Empty
        Dim base1 As Decimal = 0
        Dim base2 As Decimal = 0

        Dim base1ME As Decimal = 0
        Dim base2ME As Decimal = 0

        Dim icbper As Decimal = 0
        Dim icbperME As Decimal = 0

        Dim iva1 As Decimal = 0
        Dim iva1ME As Decimal = 0
        Dim iva2 As Decimal = 0
        Dim total As Decimal = 0 ' 
        Dim totalME As Decimal = 0 ' UCEstructuraDocumentocabecera.txtTotalPagar.DecimalValue

        'Select Case be.moneda
        '    Case "1"
        '        base1 = txtTotalBase.DecimalValue
        '        base2 = txtTotalBase2.DecimalValue
        '        base1ME = Math.Round(txtTotalBase.DecimalValue / txtTipoCambio.DecimalValue, 2)
        '        base2ME = Math.Round(txtTotalBase2.DecimalValue / txtTipoCambio.DecimalValue, 2)
        '        iva1 = txtTotalIva.DecimalValue
        '        iva1ME = Math.Round(txtTotalIva.DecimalValue / txtTipoCambio.DecimalValue, 2)

        '        icbper = txtTotalIcbper.DecimalValue
        '        icbperME = Math.Round(txtTotalIcbper.DecimalValue / txtTipoCambio.DecimalValue, 2)


        '        total = txtTotalPagar.DecimalValue
        '        totalME = Math.Round(txtTotalPagar.DecimalValue / txtTipoCambio.DecimalValue, 2)
        '    Case "2"

        '        base1ME = txtTotalBase.DecimalValue
        '        base2ME = txtTotalBase2.DecimalValue

        '        base1 = Math.Round(txtTotalBase.DecimalValue * txtTipoCambio.DecimalValue, 2)
        '        base2 = Math.Round(txtTotalBase2.DecimalValue * txtTipoCambio.DecimalValue, 2)

        '        iva1ME = txtTotalIva.DecimalValue
        '        iva1 = Math.Round(txtTotalIva.DecimalValue * txtTipoCambio.DecimalValue, 2)

        '        icbperME = txtTotalIcbper.DecimalValue
        '        icbper = Math.Round(txtTotalIcbper.DecimalValue * txtTipoCambio.DecimalValue, 2)

        '        totalME = txtTotalPagar.DecimalValue
        '        total = Math.Round(txtTotalPagar.DecimalValue * txtTipoCambio.DecimalValue, 2)
        'End Select


        Select Case be.tipoDoc
            Case "9907"
                tipoVenta = TIPO_VENTA.NOTA_DE_VENTA
            Case "01", "03"
                tipoVenta = TIPO_VENTA.VENTA_ELECTRONICA
            Case "9903" ' PROFORMA
                tipoVenta = TIPO_VENTA.COTIZACION
        End Select

        '.serie = UCEstructuraCabeceraVentaV2.txtSerie.Text.Trim,
        '.numeroDoc = UCEstructuraCabeceraVentaV2.txtNumero.Text.Trim,

        Dim obj As New documentoventaAbarrotes With
        {
        .tipoOperacion = be.tipoOperacion,
        .codigoLibro = "8",
        .idEmpresa = be.idEmpresa,
        .idEstablecimiento = be.idCentroCosto,
        .fechaLaboral = Date.Now,
        .fechaDoc = be.fechaProceso,
        .fechaVcto = Nothing,
        .fechaPeriodo = GetPeriodo(be.fechaProceso, True),
        .tipoDocumento = be.tipoDoc,
        .idCliente = be.idEntidad,
        .nombrePedido = be.entidad,
        .moneda = be.moneda,
        .tasaIgv = DocumentoVenta.tasaIgv,
        .icbper = DocumentoVenta.icbper.GetValueOrDefault,
        .icbperus = DocumentoVenta.icbperus.GetValueOrDefault,
        .tipoCambio = txtTipoCambio.DecimalValue,
        .bi01 = DocumentoVenta.bi01,' base1,
        .bi02 = DocumentoVenta.bi02,'base2,
        .isc01 = 0,
        .isc02 = 0,
        .igv01 = DocumentoVenta.igv01,'iva1,
        .igv02 = 0,
        .otc01 = 0,
        .otc02 = 0,
        .bi01us = DocumentoVenta.bi01us,' base1ME,
        .bi02us = DocumentoVenta.bi02us,'base2ME,
        .isc01us = 0,
        .isc02us = 0,
        .igv01us = DocumentoVenta.igv01us,' iva1ME,
        .igv02us = 0,
        .otc01us = 0,
        .otc02us = 0,
        .importeCostoMN = TextTotalDescuentos.DecimalValue,
        .terminos = If(ChPagoAvanzado.Checked = True, "CONTADO", "CREDITO"),
        .ImporteNacional = DocumentoVenta.ImporteNacional,' total,
        .ImporteExtranjero = DocumentoVenta.ImporteExtranjero,' totalME,
        .tipoVenta = tipoVenta,
        .estadoCobro = TIPO_VENTA.PAGO.PENDIENTE_PAGO,
        .glosa = "Venta de mercadería",
        .sustentado = "S",
        .idPadre = DocumentoVenta.idDocumento,
        .estadoEntrega = "1",
        .usuarioActualizacion = be.usuarioActualizacion,' usuario.IDUsuario,
        .fechaActualizacion = Date.Now
        }

        be.documentoventaAbarrotes = obj
        'Select Case UCCondicionesPago.RBNo.Checked
        '    Case True
        be.documentoventaAbarrotes.estadoCobro = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
        '    Case Else
        '        If UCCondicionesPago.UCPagoCompletoDocumento.TextPagado.DecimalValue > 0 Then
        '            be.documentocompra.estadoPago = TIPO_COMPRA.PAGO.PagoParcial
        '        End If

        '        If UCCondicionesPago.UCPagoCompletoDocumento.TextSaldo.DecimalValue <= 0 Then
        '            be.documentocompra.estadoPago = TIPO_COMPRA.PAGO.PAGADO
        '        End If
        'End Select
        be.documentoventaAbarrotes.documentoventaAbarrotesDet = New List(Of documentoventaAbarrotesDet)
    End Sub

    Private Sub MappingDocumentoCompraCabeceraDetalle(obj As documento)
        Dim objDet As documentoventaAbarrotesDet

        For Each i In DocumentoVenta.documentoventaAbarrotesDet.ToList
            Dim cod = System.Guid.NewGuid.ToString()

            Select Case tmpConfigInicio.FormatoVenta
                Case "FACT"
                    i.AfectoInventario = False
            End Select


            Select Case i.tipoExistencia
                Case TipoExistencia.ServicioGasto
                    objDet = New documentoventaAbarrotesDet With
                            {
                            .AfectoInventario = i.AfectoInventario,
                            .CodigoCosto = cod,
                            .catalogo_id = 0,
                            .CustomCatalogo = Nothing,
                            .CustomEquivalencia = Nothing,
                            .CustomProducto = Nothing,
                            .idItem = "1",
                            .nombreItem = i.nombreItem,
                            .detalleAdicional = i.detalleAdicional,
                            .tipoExistencia = i.tipoExistencia,
                            .destino = i.destino,
                            .unidad1 = i.unidad1,
                            .monto1 = i.monto1,
                            .equivalencia_id = 0,
                            .unidad2 = Nothing,
                            .monto2 = i.monto2,
                            .precioUnitario = i.precioUnitario.GetValueOrDefault,
                            .precioUnitarioUS = i.precioUnitarioUS.GetValueOrDefault,
                            .importeMN = i.importeMN,
                            .importeME = i.importeME.GetValueOrDefault,
                            .montokardex = i.montokardex,
                            .montoIsc = 0,
                            .montoIgv = i.montoIgv,
                            .montoIcbper = i.montoIcbper.GetValueOrDefault,
                            .montoIcbperUS = i.montoIcbperUS.GetValueOrDefault,
                            .tasaIcbper = i.tasaIcbper.GetValueOrDefault,
                            .otrosTributos = 0,
                            .montokardexUS = i.montokardex.GetValueOrDefault,
                            .montoIscUS = 0,
                            .montoIgvUS = i.montoIgvUS.GetValueOrDefault,
                            .otrosTributosUS = 0,
                            .entregado = "1",
                            .estadoPago = i.estadoPago,
                            .bonificacion = i.bonificacion,
                            .descuentoMN = i.descuentoMN.GetValueOrDefault,
                            .usuarioModificacion = obj.usuarioActualizacion,' usuario.IDUsuario,
                            .fechaModificacion = Date.Now
                            }
                Case Else
                    objDet = New documentoventaAbarrotesDet With
                            {
                            .AfectoInventario = i.AfectoInventario,
                            .estadoMovimiento = i.AfectoInventario.ToString(),
                            .CodigoCosto = cod,
                            .catalogo_id = i.CustomCatalogo.idCatalogo,
                            .CustomCatalogo = i.CustomCatalogo,
                            .CustomEquivalencia = i.CustomEquivalencia,
                            .ContenidoNetoUnidadComercialMaxima = i.CustomEquivalencia.contenido,
                            .CustomProducto = i.CustomProducto,
                            .idItem = i.CustomProducto.codigodetalle,
                            .detalleAdicional = i.detalleAdicional,
                            .nombreItem = i.CustomProducto.descripcionItem,
                            .tipoExistencia = i.CustomProducto.tipoExistencia,
                            .destino = i.CustomProducto.origenProducto,
                            .unidad1 = i.CustomProducto.unidad1,
                            .monto1 = i.monto1,
                            .equivalencia_id = i.CustomEquivalencia.equivalencia_id,
                            .unidad2 = Nothing,
                            .monto2 = i.monto2,
                            .precioUnitario = i.precioUnitario.GetValueOrDefault,
                            .precioUnitarioUS = i.precioUnitarioUS.GetValueOrDefault,
                            .importeMN = i.importeMN,
                            .importeME = i.importeME.GetValueOrDefault,
                            .montokardex = i.montokardex,
                            .montoIsc = 0,
                            .montoIgv = i.montoIgv,
                            .montoIcbper = i.montoIcbper.GetValueOrDefault,
                            .montoIcbperUS = i.montoIcbperUS.GetValueOrDefault,
                            .tasaIcbper = i.tasaIcbper.GetValueOrDefault,
                            .otrosTributos = 0,
                            .montokardexUS = i.montokardex.GetValueOrDefault,
                            .montoIscUS = 0,
                            .montoIgvUS = i.montoIgvUS.GetValueOrDefault,
                            .otrosTributosUS = 0,
                            .entregado = "1",
                            .estadoPago = i.estadoPago,
                            .bonificacion = i.bonificacion,
                            .tipobeneficio = i.tipobeneficio,
                            .descuentoMN = i.descuentoMN.GetValueOrDefault,
                            .usuarioModificacion = obj.usuarioActualizacion,' usuario.IDUsuario,
                            .fechaModificacion = Date.Now
                            }
            End Select
            obj.documentoventaAbarrotes.documentoventaAbarrotesDet.Add(objDet)
        Next
    End Sub

    Private Sub MappingPagos(envio As EnvioImpresionVendedorPernos, obj As documento)
        Dim ListaPagos = ListaPagosCajas(obj.documentoventaAbarrotes, obj.documentoventaAbarrotes.documentoventaAbarrotesDet, envio)
        obj.ListaCustomDocumento = ListaPagos.ToList

        Dim SumaPagos As Decimal = 0
        For Each i In ListaPagos
            SumaPagos += i.documentoCaja.montoSoles.GetValueOrDefault
        Next
        If SumaPagos = obj.documentoventaAbarrotes.ImporteNacional Then 'txtTotalPagar.DecimalValue Then
            obj.documentoventaAbarrotes.terminos = "CONTADO"
            obj.documentoventaAbarrotes.estadoCobro = TIPO_VENTA.PAGO.COBRADO
        Else
            'ndocumento.documentoventaAbarrotes.terminos = "PARCIAL"
            obj.documentoventaAbarrotes.terminos = "CREDITO"
            obj.documentoventaAbarrotes.estadoCobro = TIPO_VENTA.PAGO.PENDIENTE_PAGO
        End If
        '     obj.documentoventaAbarrotes.estadoCobro = obj.documentoventaAbarrotes.GetEstadoPagoComprobante

    End Sub

    Public Function ListaPagosCajas(venta As documentoventaAbarrotes, ventaDetalle As List(Of documentoventaAbarrotesDet), envio As EnvioImpresionVendedorPernos) As List(Of documento)
        Dim nDocumentoCaja As New documento
        Dim objCaja As New documentoCaja
        Dim ListaDoc As New List(Of documento)

        For Each i In dgvCuentas.Table.Records
            If Decimal.Parse(i.GetValue("abonado")) > 0 Then
                nDocumentoCaja = New documento
                nDocumentoCaja.idDocumento = 0 'CInt(Me.Tag)
                nDocumentoCaja.idEmpresa = Gempresas.IdEmpresaRuc
                nDocumentoCaja.idCentroCosto = GEstableciento.IdEstablecimiento
                nDocumentoCaja.fechaProceso = txtFecha.Value
                nDocumentoCaja.tipoDoc = "9903" ' cbotipoDocPago.SelectedValue
                nDocumentoCaja.nroDoc = "0"
                nDocumentoCaja.nroDoc = 0 ' GConfiguracion.Serie
                nDocumentoCaja.idOrden = Nothing
                nDocumentoCaja.moneda = i.GetValue("moneda")
                'If TextProveedor.Text.Trim.Length > 0 Then
                nDocumentoCaja.idEntidad = Val(TextProveedor.Tag)
                nDocumentoCaja.entidad = TextProveedor.Text
                nDocumentoCaja.nrodocEntidad = TextNumIdentrazon.Text
                'Else
                'nDocumentoCaja.entidad = TextProveedor.Text
                '    nDocumentoCaja.nrodocEntidad = 0
                ' nDocumentoCaja.idEntidad = Val(0)
                'End If
                nDocumentoCaja.tipoEntidad = TIPO_ENTIDAD.CLIENTE
                nDocumentoCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
                nDocumentoCaja.usuarioActualizacion = DocumentoVenta.usuarioActualizacion ' usuario.IDUsuario
                nDocumentoCaja.fechaActualizacion = DateTime.Now


                'DOCUMENTO CAJA
                objCaja = New documentoCaja
                objCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
                objCaja.idDocumento = 0
                objCaja.periodo = venta.fechaPeriodo
                objCaja.idEmpresa = Gempresas.IdEmpresaRuc
                objCaja.idEstablecimiento = GEstableciento.IdEstablecimiento
                objCaja.fechaProceso = txtFecha.Value
                objCaja.fechaCobro = txtFecha.Value
                objCaja.tipoMovimiento = TIPO_VENTA.PAGO.COBRADO
                'If TextProveedor.Text.Trim.Length > 0 Then
                objCaja.codigoProveedor = TextProveedor.Tag
                objCaja.IdProveedor = Integer.Parse(TextProveedor.Tag)
                objCaja.idPersonal = Integer.Parse(TextProveedor.Tag)
                'End If
                objCaja.TipoDocumentoPago = "9903" 'cbotipoDocPago.SelectedValue
                objCaja.codigoLibro = "1"
                objCaja.tipoDocPago = venta.tipoDocumento
                objCaja.formapago = i.GetValue("idforma") ' "9903"
                objCaja.formaPagoName = i.GetValue("formaPago")
                objCaja.NumeroDocumento = "-"
                ' Dim numeroop = i.GetValue("nrooperacion")


                Dim numeroop = i.GetValue("nrooperacion")

                If numeroop.ToString.Trim.Length > 0 Then
                    objCaja.numeroOperacion = i.GetValue("nrooperacion")
                End If


                If i.GetValue("idforma") = "006" Or i.GetValue("idforma") = "007" Then
                    objCaja.estadopago = 1

                End If

                Select Case venta.tipoDocumento
                    Case "9907"
                        objCaja.movimientoCaja = TIPO_VENTA.NOTA_DE_VENTA
                    Case "9903"
                        objCaja.movimientoCaja = TIPO_VENTA.PROFORMA
                    Case Else
                        objCaja.movimientoCaja = TIPO_VENTA.VENTA_ELECTRONICA
                End Select

                'Select Case venta.tipoDocumento
                '    Case "9907"
                '        objCaja.movimientoCaja = TIPO_VENTA.NOTA_DE_VENTA
                '    Case Else
                '        objCaja.movimientoCaja = TipoVentaGeneral 'TIPO_VENTA.VENTA_POS_DIRECTA,
                'End Select
                objCaja.montoSoles = Decimal.Parse(i.GetValue("abonado"))

                objCaja.moneda = i.GetValue("moneda")
                objCaja.tipoCambio = Decimal.Parse(i.GetValue("tipocambio"))
                objCaja.montoUsd = Decimal.Parse(i.GetValue("abonadoME")) 'Decimal.Parse(objCaja.montoSoles / TmpTipoCambio)

                objCaja.estado = "1"
                objCaja.estadopago = 0
                objCaja.glosa = "Por ventas" & TextProveedor.Text & "con tipo Doc. " & cboTipoDoc.Text & ", fecha de venta " & txtFecha.Value
                objCaja.entregado = "SI"

                objCaja.idCajaUsuario = envio.IDCaja ' GFichaUsuarios.IdCajaUsuario
                objCaja.entidadFinanciera = i.GetValue("identidad")
                objCaja.NombreEntidad = i.GetValue("entidad")
                objCaja.usuarioModificacion = DocumentoVenta.usuarioActualizacion ' usuario.IDUsuario
                objCaja.fechaModificacion = DateTime.Now
                nDocumentoCaja.documentoCaja = objCaja
                nDocumentoCaja.documentoCaja.documentoCajaDetalle = GetDetallePago(objCaja, ventaDetalle)
                'asientoDocumento(nDocumentoCaja.documentoCaja)
                ListaDoc.Add(nDocumentoCaja)
            End If
        Next

        'If TextValoranticipo.DecimalValue > 0 Then
        '    listaAnticipoDetalle = New List(Of documentoAnticipoConciliacion)
        '    listaAnticipoDetalle = GetDetallePagoAnticipoV2(TextValoranticipo.DecimalValue, ventaDetalle)
        'End If

        'If PanelCupon.Visible Then
        '    If TextCuponImporte.DecimalValue > 0 Then
        '        ListaDoc.Add(AddPagoCuponCaja(venta, ventaDetalle))
        '    End If
        'End If

        Return ListaDoc
    End Function


    Sub GrabarVentaCasoEspecial()
        Dim VentaSA As New documentoVentaAbarrotesSA
        Dim ListProductosVendidos As New List(Of documentoventaAbarrotesDet)
        'objPleaseWait = New FeedbackForm()
        'objPleaseWait.StartPosition = FormStartPosition.CenterScreen
        'objPleaseWait.Show()
        Application.DoEvents()

        ListProductosVendidos = New List(Of documentoventaAbarrotesDet)

        ListProductosVendidos = GetDetalleVenta()

        If ListProductosVendidos.Count = 0 Then
            btOperacion.Enabled = True
            'objPleaseWait.Close()
            Throw New Exception("Debe ingresar artículos a la canasta de venta")
        End If

        'Dim listaBeneficios = GetDetalleBeneficios()
        'If listaBeneficios.Count > 0 Then
        '    ListProductosVendidos.AddRange(listaBeneficios)
        'End If

        Dim listaDocumento As New List(Of documento)

        If ListProductosVendidos.Count > 0 Then
            Dim DocComprobante =
            CType(GetGrabarVentaComprobante(ListProductosVendidos.ToList()), documento)

            listaDocumento.Add(DocComprobante)
        End If

        If PanelCupon.Visible Then
            If TextCuponImporte.DecimalValue > 0 Then
                listaDocumento(0).CustomListaBeneficios = New List(Of Business.Entity.beneficio) From
                {
                New Business.Entity.beneficio With {.beneficio_id = TextCodigoCupon.Tag}
                }
            End If
        End If

        Dim lista = VentaSA.Grabar_VentaEspecialSinLote(listaDocumento)
        DocumentoVenta = Nothing
        'GetImpresionTicketsEspecial(lista)
        'ChPagoDirecto.Checked = False
        ChPagoAvanzado.Checked = True
        PagoDirectoCheck()
        btOperacion.Enabled = False
        TextCodigoVendedor.Clear()
        TextComprador.Clear()
        lblPagoVenta.Text = "0.00"
        txtTotalBase.DecimalValue = 0
        txtTotalBase2.DecimalValue = 0
        txtTotalBase3.DecimalValue = 0
        txtTotalIva.DecimalValue = 0
        TextTotalDescuentos.DecimalValue = 0
        txtTotalPagar.DecimalValue = 0
        LabelTotalCobrarCliente.Text = "0.00"
        TextPagoAnticipoDisponible.DecimalValue = 0
        TextValoranticipo.DecimalValue = 0
        GetUbicarClienteGeneral()

        chCredito.Checked = False
        LblPagoCredito.Visible = False
        chCobranzaParcial.Checked = False
        PanelCupon.Visible = False
        ErrorProvider1.Clear()
        GetMappingColumnsGrid()

        Alert = New Alert("Venta registrada", alertType.success)
        Alert.TopMost = True
        Alert.Show()
        'objPleaseWait.Close()

        GetImpresionTicketsEspecial(lista)

        HabilitarPago(False)
        ToolImportar.PerformClick()


        'If listaCuponesActivos.Count > 0 Then
        '    Dim valorDeVenta = txtTotalPagar.DecimalValue ' ListProductosVendidos.FirstOrDefault.documentoventaAbarrotes.ImporteNacional

        '    Dim calculoCupon = valorDeVenta / listaCuponesActivos.FirstOrDefault.valorbase
        '    Dim parteEntera = CInt(calculoCupon)
        '    If parteEntera > 0 Then
        '        LabelCupon.Text = listaCuponesActivos.FirstOrDefault.descripcion
        '        LabelCupon.Tag = listaCuponesActivos.FirstOrDefault
        '        GetBeneficioMappingCliente(CType(LabelCupon.Tag, Business.Entity.beneficioProduccionConsumo))
        '    End If
        'End If

        'Dim miInterfaz As ICommitOperacionMKT = TryCast(Me.Owner, ICommitOperacionMKT)
        'If miInterfaz IsNot Nothing Then miInterfaz.Commit(True, lista(0).idDocumento)
        'objPleaseWait.Close()
        'Close()
    End Sub

    Private Sub GetBeneficioMappingCliente(tag As Business.Entity.beneficioProduccionConsumo)
        Dim codigoTipoTabla = General.TipoTabla.valesDeDescuento
        Dim codigoTipoBeneficio = General.TipoBeneficio.Documento

        Dim beneficio As New Business.Entity.beneficio With
          {
          .Action = BaseBE.EntityAction.INSERT,
          .tipoTabla = codigoTipoTabla,
          .detalleBeneficio = tag.descripcion,
          .tipoBeneficio = codigoTipoBeneficio,
          .beneficioReferencia = 0,
          .beneficioReferenciaCantidad = 0,
          .afectoComprobante = False,
          .tipoAfectacion = "I",
          .importeBase = tag.valorbase,
          .valorConvertido = tag.valor,
          .vigencia = tag.Vigencia,
          .esPremioRegaloBonif = False,
          .idCliente = TextProveedor.Tag,
          .produccion_id = tag.produccion_id,
          .estado = StatusBeneficio.Activo
          }

        beneficioSA.RegisterClientBeneficeCupon(beneficio)
    End Sub

    Private Sub PagoDirectoCheck()
        ChPagoAvanzado.Checked = True
    End Sub

    Private Sub GeTgColumnsGrid()
        Dim dt As New DataTable

        With dt
            .Columns.Add("tipo")
            .Columns.Add("identidad")
            .Columns.Add("entidad")
            .Columns.Add("abonado")
            .Columns.Add("tipocambio")
            .Columns.Add("idforma")
            .Columns.Add("formaPago")
        End With
        dgvCuentas.DataSource = dt
    End Sub

    Sub GuiaRemisionGenerico(beDocumento As documento)
        Dim guiaRemisionBE As New documentoGuia
        Dim documentoguiaDetalle As New documentoguiaDetalle
        Dim ListaGuiaDetalle As New List(Of documentoguiaDetalle)
        'REGISTRANDO LA GUIA DE REMISION

        'Dim idCliente As Integer = 0
        'Dim nomCliente As String = Nothing

        'If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
        '    idCliente = TXTcOMPRADOR.Tag
        '    nomCliente = TXTcOMPRADOR.Text
        'Else
        '    nomCliente = TXTcOMPRADOR.Text
        'End If

        With guiaRemisionBE
            .idDocumento = 0
            .codigoLibro = "14"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = txtFecha.Value
            .periodo = GetPeriodo(txtFecha.Value, True)
            .tipoDoc = "99"
            .idEntidad = beDocumento.documentoventaAbarrotes.idCliente ' idCliente
            .monedaDoc = beDocumento.documentoventaAbarrotes.moneda '"1"
            .tasaIgv = 0 'txtIva.DoubleValue
            .tipoCambio = beDocumento.documentoventaAbarrotes.tipoCambio ' txtTipoCambio.DecimalValue
            .importeMN = beDocumento.documentoventaAbarrotes.ImporteNacional
            .importeME = beDocumento.documentoventaAbarrotes.ImporteExtranjero
            .glosa = "Guia remision por ventas"
            .estado = TipoGuia.Entregado
            .direccionPartida = "ORIGEN"
            .fechaTraslado = Date.Now
            .estado = TipoGuia.Entregado
            .usuarioActualizacion = DocumentoVenta.usuarioActualizacion 'usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With
        beDocumento.documentoGuia = guiaRemisionBE

        For Each r In beDocumento.documentoventaAbarrotes.documentoventaAbarrotesDet.ToList
            If r.tipoExistencia <> "GS" Then
                documentoguiaDetalle = New documentoguiaDetalle
                'sdfsdfsdf
                'beDocumento.documentoGuia.serie = GConfiguracion2.Serie
                'beDocumento.documentoGuia.numeroDoc = GConfiguracion2.Serie
                documentoguiaDetalle.idDocumento = 0
                documentoguiaDetalle.idItem = r.idItem
                documentoguiaDetalle.descripcionItem = r.DetalleItem
                documentoguiaDetalle.destino = r.destino
                documentoguiaDetalle.unidadMedida = r.unidad1
                documentoguiaDetalle.cantidad = CDec(r.monto1)

                documentoguiaDetalle.almacenRef = r.idAlmacenOrigen
                documentoguiaDetalle.nombreRecepcion = beDocumento.documentoventaAbarrotes.NombreEntidad ' nomCliente
                documentoguiaDetalle.dniRecepcion = Nothing
                documentoguiaDetalle.puntoLlegada = "ORIGEN"
                documentoguiaDetalle.estado = TipoGuiaDetalle.Entrega_Total
                documentoguiaDetalle.usuarioModificacion = DocumentoVenta.usuarioActualizacion ' usuario.IDUsuario
                documentoguiaDetalle.fechaModificacion = DateTime.Now
                ListaGuiaDetalle.Add(documentoguiaDetalle)
                ' End If
            End If

        Next
        beDocumento.documentoGuia.documentoguiaDetalle = ListaGuiaDetalle
    End Sub

    Private Function GetDetalleVenta() As List(Of documentoventaAbarrotesDet)
        Dim TipoEntrega = TipoEntregado.Entregado
        Dim objDocumentoVentaDet As documentoventaAbarrotesDet
        GetDetalleVenta = New List(Of documentoventaAbarrotesDet)
        For Each r In DocumentoVenta.documentoventaAbarrotesDet.ToList

            If r.monto1 <= 0 Then
                btOperacion.Enabled = True
                Throw New Exception("Debe ingresar un cantidad mayor a cero.")
            End If

            If r.importeMN <= 0 Then
                btOperacion.Enabled = True
                Throw New Exception("El importe de venta debe ser mayor a cero.")
            End If
            objDocumentoVentaDet = New documentoventaAbarrotesDet
            'If r.tipoExistencia = "OF" Then
            '    objDocumentoVentaDet.CustomOferta_Detalle = New ventaDetalle_oferta With {
            '    .id_oferta = r.GetValue("codigo")
            '    }
            'End If

            objDocumentoVentaDet.codigoLote = 0 ' Integer.Parse(r.GetValue("codigoLote"))
            If ChPagoAvanzado.Checked Then
                If CDec(r.MontoSaldo) <= 0 Then
                    objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.COBRADO
                Else
                    objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO
                End If
            Else
                objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO
            End If

            objDocumentoVentaDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoVentaDet.IdEstablecimiento = GEstableciento.IdEstablecimiento ' almacenSA.GetUbicar_almacenPorID(i.Cells(24).Value()).idEstablecimiento
            objDocumentoVentaDet.FechaDoc = txtFecha.Value
            objDocumentoVentaDet.Serie = GConfiguracion.Serie
            objDocumentoVentaDet.NumDoc = GConfiguracion.Serie
            objDocumentoVentaDet.TipoDoc = GConfiguracion.TipoComprobante
            If r.tipoExistencia = "GS" Then
                objDocumentoVentaDet.idAlmacenOrigen = Nothing
                'objDocumentoVentaDet.tipoVenta = r.GetValue("tipoPrecio")
            ElseIf r.tipoExistencia = "OF" Then
                objDocumentoVentaDet.idAlmacenOrigen = Nothing
                objDocumentoVentaDet.tipoVenta = "F"
            Else
                objDocumentoVentaDet.idAlmacenOrigen = r.idAlmacenOrigen
                'objDocumentoVentaDet.tipoVenta = r.GetValue("tipoPrecio")
            End If
            objDocumentoVentaDet.establecimientoOrigen = GEstableciento.IdEstablecimiento
            objDocumentoVentaDet.cuentaOrigen = Nothing
            objDocumentoVentaDet.idItem = r.idItem
            objDocumentoVentaDet.DetalleItem = r.nombreItem
            objDocumentoVentaDet.nombreItem = r.nombreItem
            objDocumentoVentaDet.tipoExistencia = r.tipoExistencia
            objDocumentoVentaDet.destino = r.destino
            objDocumentoVentaDet.unidad1 = r.unidad1
            objDocumentoVentaDet.monto1 = r.monto1
            objDocumentoVentaDet.unidad2 = Nothing
            objDocumentoVentaDet.monto2 = Nothing ''CDec(r.GetValue("cantidad2")) '  Nothing 'i.Cells(31).Value()
            objDocumentoVentaDet.precioUnitario = r.precioUnitario
            objDocumentoVentaDet.precioUnitarioUS = r.precioUnitarioUS
            objDocumentoVentaDet.importeMN = r.importeMN
            objDocumentoVentaDet.importeME = r.importeME
            'objDocumentoVentaDet.descuentoMN = 0
            objDocumentoVentaDet.descuentoME = 0

            objDocumentoVentaDet.montokardex = r.montokardex
            objDocumentoVentaDet.montoIsc = 0
            objDocumentoVentaDet.montoIgv = r.montoIgv
            objDocumentoVentaDet.otrosTributos = 0
            '**********************************************************************************
            objDocumentoVentaDet.montokardexUS = r.montokardexUS
            objDocumentoVentaDet.montoIscUS = 0
            objDocumentoVentaDet.montoIgvUS = r.montoIgvUS
            objDocumentoVentaDet.otrosTributosUS = 0
            objDocumentoVentaDet.estadoMovimiento = "V" 'ENTREGADO/COBRADO
            '**********************************************************************************
            objDocumentoVentaDet.importeMNK = 0 ' CDec(r.GetValue("puKardex"))
            objDocumentoVentaDet.importeMEK = 0 ' CDec(r.GetValue("pukardeme"))
            objDocumentoVentaDet.fechaVcto = txtFecha.Value
            objDocumentoVentaDet.estadoEntrega = TipoEntrega
            'objDocumentoVentaDet.cantidadEntrega = CDec(r.GetValue("cantEntregar"))
            objDocumentoVentaDet.salidaCostoMN = 0
            objDocumentoVentaDet.salidaCostoME = 0
            'If (TipoEntrega = TipoEntregado.PorEntregar) Then
            '    conteoCantidad = CDec(r.GetValue("cantEntregar"))
            'End If
            'objDocumentoVentaDet.categoria = r.GetValue("cat")
            objDocumentoVentaDet.preEvento = Nothing
            objDocumentoVentaDet.usuarioModificacion = usuario.IDUsuario
            objDocumentoVentaDet.fechaModificacion = DateTime.Now
            objDocumentoVentaDet.Glosa = "Venta"
            objDocumentoVentaDet.NomMarca = Nothing ' r.GetValue("marca")
            objDocumentoVentaDet.tipobeneficio = r.tipobeneficio
            objDocumentoVentaDet.beneficiobase = r.beneficiobase
            objDocumentoVentaDet.descuentoMN = r.descuentoMN
            GetDetalleVenta.Add(objDocumentoVentaDet)
        Next

    End Function

    Private Function GetGrabarVentaComprobante(DetalleVenta As List(Of documentoventaAbarrotesDet)) As documento
        Dim tipoDocumentoVenta As String = Nothing
        Dim serieVenta As String = Nothing
        Dim numeroVenta As String = Nothing
        Dim NroDoc As String = Nothing
        Dim ndocumento As New documento()
        Dim DocCaja As New documento

        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim docVentaSA As New documentoVentaAbarrotesSA

        Dim nDocumentoVenta As New documentoventaAbarrotes()
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        Dim asientoSA As New AsientoSA
        ' Dim ListaAsiento As New List(Of asiento)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        Dim TipoCobro As String
        Dim proveedor As String
        Dim idProveedor As Integer

        Dim sumaVentaMN As Decimal = DetalleVenta.Sum(Function(o) o.importeMN).GetValueOrDefault
        Dim sumaVentaME As Decimal = DetalleVenta.Sum(Function(o) o.importeME).GetValueOrDefault
        Dim sumaBase1MN As Decimal =
            DetalleVenta.Where(Function(o) o.destino = OperacionGravada.Grabado).Sum(Function(o) o.montokardex).GetValueOrDefault

        Dim sumaBase1ME As Decimal =
            DetalleVenta.Where(Function(o) o.destino = OperacionGravada.Grabado).Sum(Function(o) o.montokardexUS).GetValueOrDefault

        Dim sumaBase2MN As Decimal =
            DetalleVenta.Where(Function(o) o.destino = OperacionGravada.Exonerado).Sum(Function(o) o.montokardex).GetValueOrDefault

        Dim sumaBase2ME As Decimal =
            DetalleVenta.Where(Function(o) o.destino = OperacionGravada.Exonerado).Sum(Function(o) o.montokardexUS).GetValueOrDefault

        Dim sumaIgvMN As Decimal = DetalleVenta.Sum(Function(o) o.montoIgv).GetValueOrDefault
        Dim sumaIgvME As Decimal = DetalleVenta.Sum(Function(o) o.montoIgvUS).GetValueOrDefault
        '-------------------------------------------------------------------------------------
        '---------------- VALIDACION DE IMPORTE CON DETALLE DE VENTA -------------------------

        Dim totalVentaDetalle As Decimal = sumaBase1MN + sumaBase2MN + sumaIgvMN
        Dim totalHeader As Decimal = txtTotalPagar.DecimalValue
        If totalHeader <> totalVentaDetalle Then
            btOperacion.Enabled = True
            Throw New Exception("Los importes no coinciden, tanto del detalle con la cabecera ")
        End If

        '-------------------------------------------------------------------------------------

        Select Case chAutoNumeracion.Checked
            Case True
                Select Case cboTipoDoc.Text

                    Case "FACTURA", "BOLETA"
                        'tipoDocumentoVenta = If(cboTipoDoc.Text = "BOLETA", "03", "01")
                        'serieVenta = txtSerie.Text
                        'numeroVenta = txtNumero.Text
                        'NroDoc = String.Concat(txtSerie.Text.Trim, "-", txtNumero.Text.Trim)

                        tipoDocumentoVenta = GConfiguracion.TipoComprobante
                        serieVenta = GConfiguracion.Serie
                        numeroVenta = 1
                        NroDoc = GConfiguracion.Serie

                    Case Else

                        tipoDocumentoVenta = GConfiguracion.TipoComprobante
                        serieVenta = GConfiguracion.Serie
                        numeroVenta = 1
                        NroDoc = GConfiguracion.Serie

                End Select
            Case False
                tipoDocumentoVenta = If(cboTipoDoc.Text = "BOLETA", "03", "01")
                serieVenta = txtSerie.Text.Trim
                numeroVenta = txtNumero.Text.Trim
                NroDoc = String.Concat(txtSerie.Text.Trim, "-", txtNumero.Text.Trim)
        End Select


        ndocumento = New documento
        ndocumento.Action = BaseBE.EntityAction.INSERT
        ndocumento.IsFormatoGeneral = If(chAutoNumeracion.Checked, False, True)
        ndocumento.idEmpresa = Gempresas.IdEmpresaRuc
        ndocumento.idCentroCosto = GEstableciento.IdEstablecimiento
        ndocumento.tipoDoc = tipoDocumentoVenta 'conf.TipoComprobante
        ndocumento.fechaProceso = txtFecha.Value
        ndocumento.nroDoc = NroDoc ' conf.Serie
        ndocumento.moneda = "1"

        If TextProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            ndocumento.entidad = TextProveedor.Text
            ndocumento.nrodocEntidad = TextNumIdentrazon.Text
            ndocumento.idEntidad = Val(TextProveedor.Tag)
        Else
            ndocumento.entidad = TextProveedor.Text
            ndocumento.nrodocEntidad = 0
            ndocumento.idEntidad = Val(0)
        End If
        ndocumento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        ndocumento.tipoOperacion = StatusTipoOperacion.VENTA
        ndocumento.usuarioActualizacion = DocumentoVenta.usuarioActualizacion ' usuario.IDUsuario
        ndocumento.fechaActualizacion = DateTime.Now
        TipoCobro = TIPO_VENTA.PAGO.COBRADO
        Dim TipoEntrega = TipoEntregado.Entregado
        Dim tipoEstado = TipoGuia.Entregado

        If TextProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            proveedor = TextProveedor.Text
            idProveedor = CInt(TextProveedor.Tag)
        Else
            proveedor = TextProveedor.Text
            idProveedor = 0
        End If

        nDocumentoVenta = New documentoventaAbarrotes With {
             .idPadre = DocumentoVenta.idDocumento,
            .horaVenta = txtFecha.Value.TimeOfDay.ToString(),
                  .TipoConfiguracion = If(GConfiguracion Is Nothing, Nothing, GConfiguracion.TipoConfiguracion),
                  .IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante),
                  .tipoOperacion = StatusTipoOperacion.VENTA,
                  .codigoLibro = "14",
                  .tipoDocumento = tipoDocumentoVenta,
                  .idEmpresa = Gempresas.IdEmpresaRuc,
                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                  .fechaDoc = txtFecha.Value,
                  .fechaConfirmacion = txtFecha.Value,
                  .fechaPeriodo = GetPeriodo(txtFecha.Value, True),
                  .serie = serieVenta,
                  .serieVenta = serieVenta,
                  .numeroDocNormal = Nothing,
                  .numeroVenta = numeroVenta,
                  .idCliente = CInt(idProveedor),
                  .idClientePedido = CInt(idProveedor),
                  .nombrePedido = DocumentoVenta.nombrePedido,'proveedor,
                  .moneda = "1",
                  .tasaIgv = TmpIGV,
                  .tipoCambio = TmpTipoCambio,
                  .bi01 = sumaBase1MN,
                  .bi02 = sumaBase2MN,
                  .igv01 = sumaIgvMN,
                  .igv02 = 0,
                  .bi01us = sumaBase1ME,
                  .bi02us = sumaBase2ME,
                  .igv01us = sumaIgvME,
                  .igv02us = 0,
                  .ImporteNacional = sumaVentaMN,
                  .ImporteExtranjero = sumaVentaME,
                  .tipoVenta = TipoVentaGeneral, 'TIPO_VENTA.VENTA_POS_DIRECTA,
                  .estadoCobro = TipoCobro,
                  .estadoEntrega = TipoEntrega,
                  .terminos = "CONTADO",
                  .glosa = "Por ventas",
                  .fechaVcto = txtFecha.Value,
                  .estado = StatusNotaDeVentas.Sustentado,
                  .usuarioActualizacion = DocumentoVenta.usuarioActualizacion,''usuario.IDUsuario,
        .fechaActualizacion = DateTime.Now}
        'tipoEstado,
        ndocumento.documentoventaAbarrotes = nDocumentoVenta

        ndocumento.documentoventaAbarrotes.documentoventaAbarrotesDet = DetalleVenta

        '--------------------------------------------------------------------------------------
        Dim listaExistencias As List(Of documentoventaAbarrotesDet) = (From n In DetalleVenta
                                                                       Where n.tipoExistencia <> TipoRecurso.SERVICIO).ToList
        If listaExistencias.Count > 0 Then
            AsientoVenta(listaExistencias)
        End If

        Dim listaServicios As List(Of documentoventaAbarrotesDet) = (From n In DetalleVenta
                                                                     Where n.tipoExistencia = TipoRecurso.SERVICIO).ToList

        If listaServicios.Count > 0 Then
            AsientoVentaServicios(listaServicios)
        End If

        GuiaRemisionGenerico(ndocumento)

        If ChPagoAvanzado.Checked = True Then

            'Dim f As New frmFormatoPagoComprobantes
            'f.txtMontoXcobrar.Text = nDocumentoVenta.ImporteNacional ' txtTotalPagar.DecimalValue
            'f.StartPosition = FormStartPosition.CenterParent
            'f.ShowDialog(Me)
            'If f.Tag IsNot Nothing Then
            '    Dim c = CType(f.Tag, List(Of documentoCaja))
            '    If c.Count > 0 Then
            'Dim ListaPagos = ListaPagosCajas(ndocumento.documentoventaAbarrotes, ndocumento.documentoventaAbarrotes.documentoventaAbarrotesDet)
            Dim SumaPagos As Decimal = 0
            'For Each i In ListaPagos
            '    SumaPagos += i.documentoCaja.montoSoles.GetValueOrDefault
            'Next
            'If SumaPagos = nDocumentoVenta.ImporteNacional Then 'txtTotalPagar.DecimalValue Then
            '    ndocumento.documentoventaAbarrotes.terminos = "CONTADO"
            'Else
            '    'ndocumento.documentoventaAbarrotes.terminos = "PARCIAL"
            '    ndocumento.documentoventaAbarrotes.terminos = "CREDITO"
            'End If
            'ndocumento.documentoventaAbarrotes.estadoCobro = ndocumento.documentoventaAbarrotes.GetEstadoPagoComprobante
            'ndocumento.ListaCustomDocumento = ListaPagos 'ListaPagosCajas(c)
            'Else
            '    Throw New Exception("Debe realizar el pago del comprobante")
            'End If
            'Else
            '    Throw New Exception("Debe realizar el pago del comprobante")
            'End If
        Else
            ndocumento.documentoventaAbarrotes.estadoCobro = "PN"
            ndocumento.documentoventaAbarrotes.terminos = "CREDITO"
        End If

        ndocumento.asiento = ListaAsientonTransito

        If listaAnticipoDetalle IsNot Nothing Then
            If listaAnticipoDetalle.Count > 0 Then
                ndocumento.ListaDetalleAnticipos = listaAnticipoDetalle
            End If
        End If

        Return ndocumento
    End Function


    Public Function AddPagoCuponCaja(venta As documentoventaAbarrotes, ventaDetalle As List(Of documentoventaAbarrotesDet)) As documento
        Dim nDocumentoCaja As New documento
        Dim objCaja As New documentoCaja

        Dim entidadCuponSel = CType(PanelCupon.Tag, estadosFinancierosConfiguracionPagos)


        nDocumentoCaja = New documento
        nDocumentoCaja.idDocumento = CInt(Me.Tag)
        nDocumentoCaja.idEmpresa = Gempresas.IdEmpresaRuc
        nDocumentoCaja.idCentroCosto = GEstableciento.IdEstablecimiento
        nDocumentoCaja.tipoDoc = venta.tipoDocumento ' cbotipoDocPago.SelectedValue
        nDocumentoCaja.fechaProceso = txtFecha.Value
        nDocumentoCaja.nroDoc = GConfiguracion.Serie
        nDocumentoCaja.idOrden = Nothing
        nDocumentoCaja.moneda = If(cboMoneda.Text = "NACIONAL", "1", "2")
        If TextProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            nDocumentoCaja.idEntidad = Val(TextProveedor.Tag)
            nDocumentoCaja.entidad = TextProveedor.Text
            nDocumentoCaja.nrodocEntidad = TextNumIdentrazon.Text
        Else
            nDocumentoCaja.entidad = TextProveedor.Text
            nDocumentoCaja.nrodocEntidad = 0
            nDocumentoCaja.idEntidad = Val(0)
        End If
        nDocumentoCaja.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nDocumentoCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
        nDocumentoCaja.usuarioActualizacion = DocumentoVenta.usuarioActualizacion ' usuario.IDUsuario
        nDocumentoCaja.fechaActualizacion = DateTime.Now


        'DOCUMENTO CAJA
        objCaja = New documentoCaja
        objCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
        objCaja.idDocumento = 0
        objCaja.periodo = venta.fechaPeriodo
        objCaja.idEmpresa = Gempresas.IdEmpresaRuc
        objCaja.idEstablecimiento = GEstableciento.IdEstablecimiento
        objCaja.fechaProceso = txtFecha.Value
        objCaja.fechaCobro = txtFecha.Value
        objCaja.tipoMovimiento = TIPO_VENTA.PAGO.COBRADO
        If TextProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            objCaja.codigoProveedor = Integer.Parse(TextProveedor.Tag)
            objCaja.IdProveedor = Integer.Parse(TextProveedor.Tag)
            objCaja.idPersonal = Integer.Parse(TextProveedor.Tag)
        End If
        objCaja.TipoDocumentoPago = venta.tipoDocumento 'cbotipoDocPago.SelectedValue
        objCaja.codigoLibro = "1"
        objCaja.tipoDocPago = venta.tipoDocumento
        objCaja.formapago = "9991"
        objCaja.NumeroDocumento = "-"
        objCaja.numeroOperacion = "-"
        Select Case venta.tipoDocumento
            Case "9907"
                objCaja.movimientoCaja = TIPO_VENTA.NOTA_DE_VENTA
            Case Else
                objCaja.movimientoCaja = TipoVentaGeneral 'TIPO_VENTA.VENTA_POS_DIRECTA,
        End Select
        objCaja.montoSoles = TextCuponImporte.DecimalValue

        objCaja.moneda = If(cboMoneda.Text = "NACIONAL", "1", "2")
        objCaja.tipoCambio = TmpTipoCambio
        objCaja.montoUsd = Decimal.Parse(objCaja.montoSoles / TmpTipoCambio)

        objCaja.estado = "1"
        objCaja.glosa = "Pago con cupon de descuento"
        objCaja.entregado = "SI"

        objCaja.idCajaUsuario = GFichaUsuarios.IdCajaUsuario
        objCaja.entidadFinanciera = entidadCuponSel.identidad
        objCaja.NombreEntidad = entidadCuponSel.entidad
        objCaja.usuarioModificacion = DocumentoVenta.usuarioActualizacion 'usuario.IDUsuario
        objCaja.fechaModificacion = DateTime.Now
        nDocumentoCaja.documentoCaja = objCaja
        nDocumentoCaja.documentoCaja.documentoCajaDetalle = GetDetallePago(objCaja, ventaDetalle)
        '  asientoDocumento(nDocumentoCaja.documentoCaja)
        Return nDocumentoCaja
    End Function

    'Public Function ListaPagosCajas(venta As documentoventaAbarrotes, ventaDetalle As List(Of documentoventaAbarrotesDet)) As List(Of documento)
    '    Dim nDocumentoCaja As New documento
    '    Dim objCaja As New documentoCaja
    '    Dim ListaDoc As New List(Of documento)
    '    For Each i In dgvCuentas.Table.Records

    '        If Decimal.Parse(i.GetValue("abonado")) > 0 Then

    '            nDocumentoCaja = New documento
    '            nDocumentoCaja.idDocumento = CInt(Me.Tag)
    '            nDocumentoCaja.idEmpresa = Gempresas.IdEmpresaRuc
    '            nDocumentoCaja.idCentroCosto = GEstableciento.IdEstablecimiento
    '            nDocumentoCaja.tipoDoc = venta.tipoDocumento ' cbotipoDocPago.SelectedValue
    '            nDocumentoCaja.fechaProceso = txtFecha.Value
    '            nDocumentoCaja.nroDoc = conf.Serie
    '            nDocumentoCaja.idOrden = Nothing
    '            nDocumentoCaja.moneda = If(cboMoneda.Text = "NACIONAL", "1", "2")
    '            If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
    '                nDocumentoCaja.idEntidad = Val(TXTcOMPRADOR.Tag)
    '                nDocumentoCaja.entidad = TXTcOMPRADOR.Text
    '                nDocumentoCaja.nrodocEntidad = txtruc.Text
    '            Else
    '                nDocumentoCaja.entidad = TXTcOMPRADOR.Text
    '                nDocumentoCaja.nrodocEntidad = 0
    '                nDocumentoCaja.idEntidad = Val(0)
    '            End If
    '            nDocumentoCaja.tipoEntidad = TIPO_ENTIDAD.CLIENTE
    '            nDocumentoCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
    '            nDocumentoCaja.usuarioActualizacion = DocumentoVenta.usuarioActualizacion ' usuario.IDUsuario
    '            nDocumentoCaja.fechaActualizacion = DateTime.Now


    '            'DOCUMENTO CAJA
    '            objCaja = New documentoCaja
    '            objCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
    '            objCaja.idDocumento = 0
    '            objCaja.periodo = venta.fechaPeriodo
    '            objCaja.idEmpresa = Gempresas.IdEmpresaRuc
    '            objCaja.idEstablecimiento = GEstableciento.IdEstablecimiento
    '            objCaja.fechaProceso = txtFecha.Value
    '            objCaja.fechaCobro = txtFecha.Value
    '            objCaja.tipoMovimiento = TIPO_VENTA.PAGO.COBRADO
    '            If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
    '                objCaja.codigoProveedor = Integer.Parse(TXTcOMPRADOR.Tag)
    '                objCaja.IdProveedor = Integer.Parse(TXTcOMPRADOR.Tag)
    '                objCaja.idPersonal = Integer.Parse(TXTcOMPRADOR.Tag)
    '            End If
    '            objCaja.TipoDocumentoPago = venta.tipoDocumento 'cbotipoDocPago.SelectedValue
    '            objCaja.codigoLibro = "1"
    '            objCaja.tipoDocPago = venta.tipoDocumento
    '            objCaja.formapago = i.GetValue("idforma")
    '            objCaja.NumeroDocumento = "-"


    '            Dim numeroop = i.GetValue("nrooperacion")

    '            If numeroop.ToString.Trim.Length > 0 Then
    '                objCaja.numeroOperacion = i.GetValue("nrooperacion")
    '            End If


    '            If i.GetValue("idforma") = "006" Or i.GetValue("idforma") = "007" Then
    '                objCaja.estadopago = 1

    '            End If


    '            Select Case venta.tipoDocumento
    '                Case "9907"
    '                    objCaja.movimientoCaja = TIPO_VENTA.NOTA_DE_VENTA
    '                Case Else
    '                    objCaja.movimientoCaja = TipoVentaGeneral 'TIPO_VENTA.VENTA_POS_DIRECTA,
    '            End Select
    '            objCaja.montoSoles = Decimal.Parse(i.GetValue("abonado"))

    '            objCaja.moneda = If(cboMoneda.Text = "NACIONAL", "1", "2")
    '            objCaja.tipoCambio = TmpTipoCambio
    '            objCaja.montoUsd = Decimal.Parse(objCaja.montoSoles / TmpTipoCambio)

    '            objCaja.estado = "1"
    '            objCaja.glosa = "Por ventas POS directa del cliente: " & TXTcOMPRADOR.Text & "con tipo Doc. " & cboTipoDoc.Text & ", fecha de venta " & txtFecha.Value
    '            objCaja.entregado = "SI"

    '            objCaja.idCajaUsuario = GFichaUsuarios.IdCajaUsuario
    '            objCaja.entidadFinanciera = i.GetValue("identidad")
    '            objCaja.NombreEntidad = i.GetValue("entidad")
    '            objCaja.usuarioModificacion = DocumentoVenta.usuarioActualizacion ' usuario.IDUsuario
    '            objCaja.fechaModificacion = DateTime.Now
    '            nDocumentoCaja.documentoCaja = objCaja
    '            nDocumentoCaja.documentoCaja.documentoCajaDetalle = GetDetallePago(objCaja, ventaDetalle)
    '            asientoDocumento(nDocumentoCaja.documentoCaja)
    '            ListaDoc.Add(nDocumentoCaja)
    '        End If
    '    Next

    '    If TextValoranticipo.DecimalValue > 0 Then
    '        listaAnticipoDetalle = New List(Of documentoAnticipoConciliacion)
    '        listaAnticipoDetalle = GetDetallePagoAnticipoV2(TextValoranticipo.DecimalValue, ventaDetalle)
    '    End If

    '    If PanelCupon.Visible Then
    '        If TextCuponImporte.DecimalValue > 0 Then
    '            ListaDoc.Add(AddPagoCuponCaja(venta, ventaDetalle))
    '        End If
    '    End If

    '    Return ListaDoc
    'End Function

    'Public Function ListaPagosCajas(lista As List(Of documentoCaja), venta As documentoventaAbarrotes, ventaDetalle As List(Of documentoventaAbarrotesDet)) As List(Of documento)
    '    Dim nDocumentoCaja As New documento
    '    Dim objCaja As New documentoCaja
    '    Dim ListaDoc As New List(Of documento)
    '    For Each i In lista

    '        nDocumentoCaja = New documento
    '        nDocumentoCaja.idDocumento = CInt(Me.Tag)
    '        nDocumentoCaja.idEmpresa = Gempresas.IdEmpresaRuc
    '        nDocumentoCaja.idCentroCosto = GEstableciento.IdEstablecimiento
    '        nDocumentoCaja.tipoDoc = venta.tipoDocumento ' cbotipoDocPago.SelectedValue
    '        nDocumentoCaja.fechaProceso = txtFecha.Value
    '        nDocumentoCaja.nroDoc = conf.Serie
    '        nDocumentoCaja.idOrden = Nothing
    '        nDocumentoCaja.moneda = If(cboMoneda.Text = "NACIONAL", "1", "2")
    '        If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
    '            nDocumentoCaja.idEntidad = Val(TXTcOMPRADOR.Tag)
    '            nDocumentoCaja.entidad = TXTcOMPRADOR.Text
    '            nDocumentoCaja.nrodocEntidad = txtruc.Text
    '        Else
    '            nDocumentoCaja.entidad = TXTcOMPRADOR.Text
    '            nDocumentoCaja.nrodocEntidad = 0
    '            nDocumentoCaja.idEntidad = Val(0)
    '        End If
    '        nDocumentoCaja.tipoEntidad = TIPO_ENTIDAD.CLIENTE
    '        nDocumentoCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
    '        nDocumentoCaja.usuarioActualizacion = usuario.IDUsuario
    '        nDocumentoCaja.fechaActualizacion = DateTime.Now


    '        'DOCUMENTO CAJA
    '        objCaja = New documentoCaja
    '        objCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
    '        objCaja.idDocumento = 0
    '        objCaja.periodo = venta.fechaPeriodo
    '        objCaja.idEmpresa = Gempresas.IdEmpresaRuc
    '        objCaja.idEstablecimiento = GEstableciento.IdEstablecimiento
    '        objCaja.fechaProceso = txtFecha.Value
    '        objCaja.fechaCobro = txtFecha.Value
    '        objCaja.tipoMovimiento = TIPO_VENTA.PAGO.COBRADO
    '        If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
    '            objCaja.codigoProveedor = Integer.Parse(TXTcOMPRADOR.Tag)
    '            objCaja.IdProveedor = Integer.Parse(TXTcOMPRADOR.Tag)
    '            objCaja.idPersonal = Integer.Parse(TXTcOMPRADOR.Tag)
    '        End If
    '        objCaja.TipoDocumentoPago = venta.tipoDocumento 'cbotipoDocPago.SelectedValue
    '        objCaja.codigoLibro = "1"
    '        objCaja.tipoDocPago = venta.tipoDocumento
    '        objCaja.formapago = i.formapago
    '        objCaja.NumeroDocumento = "-"
    '        objCaja.numeroOperacion = "-"
    '        Select Case venta.tipoDocumento
    '            Case "9907"
    '                objCaja.movimientoCaja = TIPO_VENTA.NOTA_DE_VENTA
    '            Case Else
    '                objCaja.movimientoCaja = TipoVentaGeneral 'TIPO_VENTA.VENTA_POS_DIRECTA,
    '        End Select
    '        objCaja.montoSoles = Decimal.Parse(i.montoSoles)

    '        objCaja.moneda = If(cboMoneda.Text = "NACIONAL", "1", "2")
    '        objCaja.tipoCambio = TmpTipoCambio
    '        objCaja.montoUsd = Decimal.Parse(objCaja.montoSoles / TmpTipoCambio)

    '        objCaja.estado = "1"
    '        objCaja.glosa = "Por ventas POS directa del cliente: " & TXTcOMPRADOR.Text & "con tipo Doc. " & cboTipoDoc.Text & ", fecha de venta " & txtFecha.Value
    '        objCaja.entregado = "SI"

    '        objCaja.idCajaUsuario = GFichaUsuarios.IdCajaUsuario
    '        objCaja.entidadFinanciera = i.IdEntidadFinanciera
    '        objCaja.NombreEntidad = i.NomCajaOrigen
    '        objCaja.usuarioModificacion = usuario.IDUsuario
    '        objCaja.fechaModificacion = DateTime.Now
    '        nDocumentoCaja.documentoCaja = objCaja
    '        nDocumentoCaja.documentoCaja.documentoCajaDetalle = GetDetallePago(objCaja, ventaDetalle)
    '        '  asientoDocumento(nDocumentoCaja.documentoCaja)
    '        ListaDoc.Add(nDocumentoCaja)
    '    Next

    '    Return ListaDoc
    'End Function

    Private Function GetDetallePago(objCaja As documentoCaja, ventaDetalle As List(Of documentoventaAbarrotesDet)) As List(Of documentoCajaDetalle)
        Dim listaBeneficio As New List(Of String)
        listaBeneficio.Add("OFERTA")
        listaBeneficio.Add("REGALO")
        Dim montoPago = objCaja.montoSoles
        Dim montoPagoME = objCaja.montoUsd
        GetDetallePago = New List(Of documentoCajaDetalle)
        For Each i In ventaDetalle.Where(Function(o) Not listaBeneficio.Contains(o.tipobeneficio)).ToList()

            If DocumentoVenta.moneda = "1" Then
                If montoPago > 0 Then
                    If i.MontoSaldo > 0 Then
                        If i.MontoSaldo > montoPago Then
                            Dim canUso = montoPago
                            i.MontoPago = canUso
                            i.estadoPago = i.ItemPendiente
                        ElseIf i.MontoSaldo = montoPago Then
                            i.MontoPago = montoPago
                            i.estadoPago = i.ItemSaldado
                        Else
                            Dim canUso = i.MontoSaldo
                            i.MontoPago = canUso
                            i.estadoPago = i.ItemSaldado
                        End If
                        montoPago -= i.MontoPago 'ImporteDisponible

                        '.codigoLote = Integer.Parse(i.codigoLote),
                        Dim montoUsd As Decimal = 0
                        If (objCaja.moneda = "1") Then
                            montoUsd = 0
                        Else
                            montoUsd = Math.Round(i.MontoPago / objCaja.tipoCambio.GetValueOrDefault, 2)
                        End If

                        GetDetallePago.Add(New documentoCajaDetalle With
                                       {
                                       .destino = i.CodigoCosto,
                                       .fecha = Date.Now,
                                       .codigoLote = 0,
                                       .otroMN = 0,
                                       .idItem = i.idItem,
                                       .DetalleItem = i.nombreItem,
                                       .montoSoles = (i.MontoPago + i.montoIcbper),
                                       .montoUsd = montoUsd,
                                       .diferTipoCambio = objCaja.tipoCambio,
                                       .tipoCambioTransacc = objCaja.tipoCambio,
                                       .entregado = "SI",
                                       .idCajaUsuario = objCaja.idCajaUsuario, ' GFichaUsuarios.IdCajaUsuario,
                                       .usuarioModificacion = DocumentoVenta.usuarioActualizacion, ' usuario.IDUsuario,
                                       .documentoAfectado = DocumentoVenta.idDocumento,
                                       .documentoAfectadodetalle = i.secuencia,
                                       .EstadoCobro = i.estadoPago,
                                       .fechaModificacion = DateTime.Now
                                       })
                        i.estadoPago = i.estadoPago
                        'Dim item = ventaDetalle.Where(Function(o) o.secuencia = i.secuencia).Single
                        'item.estadoPago = i.EstadoPagos
                    End If
                End If

            Else 'MONEDA DOLARES

                If montoPagoME > 0 Then
                    If i.MontoSaldoME > 0 Then
                        If i.MontoSaldoME > montoPagoME Then
                            Dim canUso = montoPagoME
                            i.MontoPagoME = canUso
                            i.estadoPago = i.ItemPendiente
                        ElseIf i.MontoSaldoME = montoPagoME Then
                            i.MontoPagoME = montoPagoME
                            i.estadoPago = i.ItemSaldado
                        Else
                            Dim canUso = i.MontoSaldoME
                            i.MontoPagoME = canUso
                            i.estadoPago = i.ItemSaldado
                        End If
                        montoPagoME -= i.MontoPagoME 'ImporteDisponible

                        GetDetallePago.Add(New documentoCajaDetalle With
                                       {
                                       .fecha = Date.Now,
                                       .destino = i.CodigoCosto,
                                       .otroMN = 0,
                                       .idItem = i.idItem,
                                       .DetalleItem = i.nombreItem,
                                       .montoSoles = Math.Round(i.MontoPagoME * objCaja.tipoCambio.GetValueOrDefault, 2),
                                       .montoUsd = (i.MontoPagoME + i.montoIcbper.GetValueOrDefault),'(i.MontoPagoME + i.montoIcbper.GetValueOrDefault),' FormatNumber((i.MontoPago + i.montoIcbper.GetValueOrDefault) / TmpTipoCambio, 2),
                                       .diferTipoCambio = objCaja.tipoCambio,
                                       .tipoCambioTransacc = objCaja.tipoCambio,
                                       .entregado = "SI",
                                       .idCajaUsuario = objCaja.idCajaUsuario,
                                       .usuarioModificacion = DocumentoVenta.usuarioActualizacion,' usuario.IDUsuario,
                                       .documentoAfectado = DocumentoVenta.idDocumento,
                                       .documentoAfectadodetalle = i.secuencia,
                                       .EstadoCobro = i.estadoPago,
                                       .fechaModificacion = DateTime.Now
                                       })

                        '.codigoLote = Integer.Parse(i.codigoLote),

                        i.estadoPago = i.estadoPago
                        'Dim item = ventaDetalle.Where(Function(o) o.secuencia = i.secuencia).Single
                        'item.estadoPago = i.EstadoPagos
                    End If
                End If
            End If


        Next
    End Function
    Private Function GetDetallePagoAnticipo(montoAnticipo As Decimal, ventaDetalle As List(Of documentoventaAbarrotesDet)) As List(Of documentoAnticipoDetalle)
        Dim listaBeneficio As New List(Of String)
        listaBeneficio.Add("OFERTA")
        listaBeneficio.Add("REGALO")
        Dim montoPago = montoAnticipo
        GetDetallePagoAnticipo = New List(Of documentoAnticipoDetalle)
        For Each i In ventaDetalle.Where(Function(o) Not listaBeneficio.Contains(o.tipobeneficio)).ToList()
            If montoPago > 0 Then
                If i.MontoSaldo > 0 Then
                    If i.MontoSaldo > montoPago Then
                        Dim canUso = montoPago
                        i.MontoPago = canUso
                        i.estadoPago = i.ItemPendiente
                    ElseIf i.MontoSaldo = montoPago Then
                        i.MontoPago = montoPago
                        i.estadoPago = i.ItemSaldado
                    Else
                        Dim canUso = i.MontoSaldo
                        i.MontoPago = canUso
                        i.estadoPago = i.ItemSaldado
                    End If
                    montoPago -= i.MontoPago 'ImporteDisponible

                    '.codigoLote = Integer.Parse(i.codigoLote),

                    GetDetallePagoAnticipo.Add(New documentoAnticipoDetalle With
                                   {
                                   .idDocumento = pagoAnticipo.idDocumento,
                                   .idEmpresa = Gempresas.IdEmpresaRuc,
                                   .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                   .codigoOperacion = StatusTipoOperacion.ANTICIPOS_RECIBIDOS,
                                   .descripcion = i.DetalleItem,
                                   .DetalleItem = i.DetalleItem,
                                   .importeMN = i.MontoPago,
                                   .importeME = FormatNumber(i.MontoPago / TmpTipoCambio, 2),
                                   .fecha = Date.Now,
                                   .docAfectado = CInt(Me.Tag),
                                   .documentoAfectado = CInt(Me.Tag),
                                   .documentoAfectadodetalle = i.secuencia,
                                   .diferTipoCambio = TmpTipoCambio,
                                   .montoSolesRef = 0,
                                   .montoUsdRef = 0,
                                   .idAnticipo = 0,
                                   .estadoAnticipo = "E",
                                   .entregado = "SI",
                                   .idCajaUsuario = GFichaUsuarios.IdCajaUsuario,
                                   .usuarioModificacion = usuario.IDUsuario,
                                   .fechaActualizacion = DateTime.Now
                                   })
                    i.estadoPago = i.estadoPago
                    'Dim item = ventaDetalle.Where(Function(o) o.secuencia = i.secuencia).Single
                    'item.estadoPago = i.EstadoPagos
                End If
            End If
        Next
    End Function
    Private Function GetDetallePagoAnticipoV2(montoAnticipo As Decimal, ventaDetalle As List(Of documentoventaAbarrotesDet)) As List(Of documentoAnticipoConciliacion)
        Dim listaBeneficio As New List(Of String)
        listaBeneficio.Add("OFERTA")
        listaBeneficio.Add("REGALO")
        Dim montoPago = montoAnticipo
        GetDetallePagoAnticipoV2 = New List(Of documentoAnticipoConciliacion)
        For Each i In ventaDetalle.Where(Function(o) Not listaBeneficio.Contains(o.tipobeneficio)).ToList()
            If montoPago > 0 Then
                If i.MontoSaldo > 0 Then
                    If i.MontoSaldo > montoPago Then
                        Dim canUso = montoPago
                        i.MontoPago = canUso
                        i.estadoPago = i.ItemPendiente
                    ElseIf i.MontoSaldo = montoPago Then
                        i.MontoPago = montoPago
                        i.estadoPago = i.ItemSaldado
                    Else
                        Dim canUso = i.MontoSaldo
                        i.MontoPago = canUso
                        i.estadoPago = i.ItemSaldado
                    End If
                    montoPago -= i.MontoPago 'ImporteDisponible

                    '.codigoLote = Integer.Parse(i.codigoLote),

                    GetDetallePagoAnticipoV2.Add(New documentoAnticipoConciliacion With
                                   {
                                   .idDocumento = pagoAnticipo.idDocumento,
                                   .fechaRegistro = txtFecha.Value,
                                   .tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES,
                                   .idItem = i.idItem,
                                   .detalle = i.DetalleItem,
                                   .importe = i.MontoPago,
                                   .idCajaUsuario = GFichaUsuarios.IdCajaUsuario,
                                   .usuarioActualizacion = DocumentoVenta.usuarioActualizacion, 'usuario.IDUsuario,
                                   .fechaActualizacion = DateTime.Now
                                   })
                    i.estadoPago = i.estadoPago
                    'Dim item = ventaDetalle.Where(Function(o) o.secuencia = i.secuencia).Single
                    'item.estadoPago = i.EstadoPagos
                End If
            End If
        Next
    End Function

    Function ListaDocumentoCajaGenerico(be As documentoventaAbarrotes) As List(Of documento)
        Dim nDocumentoCaja As New documento
        Dim objCaja As New documentoCaja
        Dim ListaDoc As New List(Of documento)

        nDocumentoCaja = New documento
        'DOCUMENTO
        nDocumentoCaja.idDocumento = CInt(Me.Tag)
        nDocumentoCaja.idEmpresa = Gempresas.IdEmpresaRuc
        nDocumentoCaja.idCentroCosto = GEstableciento.IdEstablecimiento
        nDocumentoCaja.tipoDoc = be.tipoDocumento ' cbotipoDocPago.SelectedValue
        nDocumentoCaja.fechaProceso = txtFecha.Value
        nDocumentoCaja.nroDoc = GConfiguracion.Serie
        nDocumentoCaja.idOrden = Nothing
        nDocumentoCaja.moneda = "1"
        If TextProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            nDocumentoCaja.idEntidad = Val(TextProveedor.Tag)
            nDocumentoCaja.entidad = TextProveedor.Text
            nDocumentoCaja.nrodocEntidad = TextNumIdentrazon.Text
        Else
            nDocumentoCaja.entidad = TextProveedor.Text
            nDocumentoCaja.nrodocEntidad = 0
            nDocumentoCaja.idEntidad = Val(0)
        End If
        nDocumentoCaja.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nDocumentoCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
        nDocumentoCaja.usuarioActualizacion = usuario.IDUsuario
        nDocumentoCaja.fechaActualizacion = DateTime.Now

        'DOCUMENTO CAJA
        objCaja = New documentoCaja
        objCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
        objCaja.idDocumento = 0
        objCaja.periodo = be.fechaPeriodo
        objCaja.idEmpresa = Gempresas.IdEmpresaRuc
        objCaja.idEstablecimiento = GEstableciento.IdEstablecimiento
        objCaja.fechaProceso = txtFecha.Value
        objCaja.fechaCobro = txtFecha.Value
        objCaja.tipoMovimiento = TIPO_VENTA.PAGO.COBRADO
        If TextProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            objCaja.codigoProveedor = Integer.Parse(TextProveedor.Tag)
            objCaja.IdProveedor = Integer.Parse(TextProveedor.Tag)
            objCaja.idPersonal = Integer.Parse(TextProveedor.Tag)
        End If
        objCaja.tipoDocPago = be.tipoDocumento
        objCaja.TipoDocumentoPago = be.tipoDocumento 'cbotipoDocPago.SelectedValue
        objCaja.codigoLibro = "1"
        objCaja.formapago = "109"
        objCaja.NumeroDocumento = "-"
        objCaja.numeroOperacion = "-"
        objCaja.movimientoCaja = TipoVentaGeneral 'TIPO_VENTA.VENTA_POS_DIRECTA,
        objCaja.montoSoles = Decimal.Parse(be.ImporteNacional)

        objCaja.moneda = If(cboMoneda.Text = "NACIONAL", "1", "2")
        objCaja.tipoCambio = TmpTipoCambio
        objCaja.montoUsd = FormatNumber(objCaja.montoSoles / TmpTipoCambio, 2)

        objCaja.estado = "1"
        objCaja.glosa = "Por ventas POS directa del cliente: " & TextProveedor.Text & "con tipo Doc. " & cboTipoDoc.Text & ", fecha de venta " & txtFecha.Value
        objCaja.entregado = "SI"

        objCaja.idCajaUsuario = GFichaUsuarios.IdCajaUsuario
        objCaja.usuarioModificacion = usuario.IDUsuario
        objCaja.entidadFinanciera = 0 'cbocajaPago.SelectedValue
        objCaja.NombreEntidad = String.Empty 'cbocajaPago.Text
        objCaja.fechaModificacion = DateTime.Now

        nDocumentoCaja.documentoCaja = objCaja
        ListaDoc.Add(nDocumentoCaja)
        ListaDetalleCajaGenerico(nDocumentoCaja.documentoCaja, be.documentoventaAbarrotesDet.ToList)
        ' asientoDocumento(nDocumentoCaja.documentoCaja)

        Return ListaDoc
    End Function

    Private Sub ListaDetalleCajaGenerico(doc As documentoCaja, detalleVenta As List(Of documentoventaAbarrotesDet))
        Dim obj As New documentoCajaDetalle
        Dim lista As New List(Of documentoCajaDetalle)
        For Each i In detalleVenta

            obj = New documentoCajaDetalle
            obj.fecha = Date.Now
            '   obj.codigoLote = Integer.Parse(i.codigoLote)
            obj.idItem = CInt(i.idItem)
            obj.DetalleItem = i.DetalleItem
            obj.montoSoles = FormatNumber(Decimal.Parse(i.importeMN), 2)
            obj.montoUsd = FormatNumber(Decimal.Parse(i.importeME), 2) '
            obj.diferTipoCambio = TmpTipoCambio
            obj.tipoCambioTransacc = TmpTipoCambio
            obj.entregado = "SI"
            obj.idCajaUsuario = GFichaUsuarios.IdCajaUsuario
            obj.usuarioModificacion = usuario.IDUsuario
            obj.documentoAfectado = CInt(Me.Tag)
            obj.fechaModificacion = DateTime.Now
            lista.Add(obj)
        Next
        'If PanelCupon.Visible Then
        '    If TextCuponImporte.DecimalValue > 0 Then
        '        obj = New documentoCajaDetalle
        '        obj.fecha = Date.Now
        '        '   obj.codigoLote = Integer.Parse(i.codigoLote)

        '        Dim cuponSel = CType(PanelCupon.Tag, estadosFinancierosConfiguracionPagos)

        '        obj.idItem = CInt(i.idItem)
        '        obj.DetalleItem = i.DetalleItem
        '        obj.montoSoles = FormatNumber(Decimal.Parse(i.importeMN), 2)
        '        obj.montoUsd = FormatNumber(Decimal.Parse(i.importeME), 2) '
        '        obj.diferTipoCambio = TmpTipoCambio
        '        obj.tipoCambioTransacc = TmpTipoCambio
        '        obj.entregado = "SI"
        '        obj.idCajaUsuario = GFichaUsuarios.IdCajaUsuario
        '        obj.usuarioModificacion = usuario.IDUsuario
        '        obj.documentoAfectado = CInt(Me.Tag)
        '        obj.fechaModificacion = DateTime.Now
        '        lista.Add(obj)
        '    End If
        'End If
        doc.documentoCajaDetalle = lista
    End Sub

    Private Sub GetImpresionTicketsEspecial(listaDocumento As List(Of documentoventaAbarrotes))
        Dim ventaSA As New documentoVentaAbarrotesSA
        Dim impresionTicketDoc = listaDocumento.Where(Function(o) o.tipoVenta = TIPO_VENTA.VENTA_POS_DIRECTA).FirstOrDefault

        If My.Computer.Network.IsAvailable = True Then
            If My.Computer.Network.Ping("138.128.171.106") Then
                If impresionTicketDoc IsNot Nothing Then
                    If impresionTicketDoc.idDocumento > 0 Then
                        If Gempresas.ubigeo > 0 Then
                            If cboTipoDoc.Text = "FACTURA" Then
                                'EnvioPSE(Gempresas.IdEmpresaRuc, impresionTicketDoc.idDocumento)

                                EnviarFacturaElectronica(impresionTicketDoc.idDocumento, Gempresas.ubigeo)

                            End If
                        End If
                    End If
                End If
            Else
                Alert = New Alert("Envio a Repositorio", alertType.success)
                Alert.TopMost = True
                Alert.Show()
            End If
        End If


        If impresionTicketDoc IsNot Nothing Then
            'If MessageBox.Show("Desea imprimir la venta ?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            '    ImprimirTicket(impresionTicketDoc.idDocumento)
            ' ImprimirTicketAcumulado(impresionTicketDoc.idDocumento)
            'Dim f As New FormImpresionNuevo  ' frmVentaNuevoFormato
            'f.DocumentoID = impresionTicketDoc.idDocumento
            'f.StartPosition = FormStartPosition.CenterScreen
            '' f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            'f.ShowDialog(Me)
            'ventaSA.GetActualizarImpresion(New documentoventaAbarrotes With {.idDocumento = impresionTicketDoc.idDocumento})
            'End If
        End If
    End Sub

    Sub GrabarNotaDeVenta()
        'objPleaseWait = New FeedbackForm()
        'objPleaseWait.StartPosition = FormStartPosition.CenterScreen
        'objPleaseWait.Show()
        Application.DoEvents()

        Dim ndocumento As New documento()
        Dim DocCaja As New documento

        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim docVentaSA As New documentoVentaAbarrotesSA

        Dim nDocumentoVenta As New documentoventaAbarrotes()
        Dim objDocumentoVentaDet As New documentoventaAbarrotesDet
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        Dim asientoSA As New AsientoSA
        ' Dim ListaAsiento As New List(Of asiento)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        Dim ListaDetalle As New List(Of documentoventaAbarrotesDet)

        Dim TipoCobro As String

        Dim proveedor As String
        Dim idProveedor As Integer
        '   Dim conteoCantidad As Integer

        'dgvCompra.TableControl.CurrentCell.EndEdit()
        'dgvCompra.TableControl.Table.TableDirty = True
        'dgvCompra.TableControl.Table.EndEdit()

        '-------------------------------------------------------------------------------------
        ndocumento = New documento
        ndocumento.Action = Business.Entity.BaseBE.EntityAction.INSERT
        ndocumento.IsFormatoGeneral = False
        ndocumento.idEmpresa = Gempresas.IdEmpresaRuc
        ndocumento.idCentroCosto = GEstableciento.IdEstablecimiento
        ndocumento.tipoDoc = "9907"
        ndocumento.fechaProceso = txtFecha.Value
        ndocumento.nroDoc = "1"
        ndocumento.moneda = If(cboMoneda.Text = "NACIONAL", "1", "2")

        If TextProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            ndocumento.entidad = TextProveedor.Text
            ndocumento.nrodocEntidad = TextNumIdentrazon.Text
            ndocumento.idEntidad = Val(TextProveedor.Tag)
        Else
            ndocumento.entidad = TextProveedor.Text
            ndocumento.nrodocEntidad = 0
            ndocumento.idEntidad = Val(0)
        End If
        ndocumento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        ndocumento.tipoOperacion = StatusTipoOperacion.VENTA
        ndocumento.usuarioActualizacion = DocumentoVenta.usuarioActualizacion ' usuario.IDUsuario
        ndocumento.fechaActualizacion = DateTime.Now
        TipoCobro = TIPO_VENTA.PAGO.COBRADO
        Dim TipoEntrega = TipoEntregado.Entregado
        Dim tipoEstado = TipoGuia.Entregado

        If TextProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            proveedor = TextProveedor.Text
            idProveedor = CInt(TextProveedor.Tag)
        Else
            proveedor = TextProveedor.Text
            idProveedor = 0
        End If

        nDocumentoVenta = New documentoventaAbarrotes With {
            .idPadre = DocumentoVenta.idDocumento,
                  .tipoOperacion = StatusTipoOperacion.VENTA,
                  .horaVenta = txtFecha.Value.TimeOfDay.ToString(),
                  .codigoLibro = "14",
                  .tipoDocumento = "9907",
                  .idEmpresa = Gempresas.IdEmpresaRuc,
                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                  .fechaDoc = txtFecha.Value,
                  .fechaConfirmacion = txtFecha.Value,
                  .fechaPeriodo = GetPeriodo(txtFecha.Value, True),' lblPerido.Text,
                    .serie = "NOTA",
                  .serieVenta = "NOTA",
                  .numeroDoc = 1,
                  .numeroVenta = 1,
                  .numeroDocNormal = Nothing,
                  .idCliente = CInt(idProveedor),
                  .idClientePedido = CInt(idProveedor),
                  .nombrePedido = DocumentoVenta.nombrePedido,' proveedor,
                  .moneda = If(cboMoneda.Text = "NACIONAL", "1", "2"),
                  .tasaIgv = TmpIGV,
                  .tipoCambio = TmpTipoCambio,
                  .bi01 = DocumentoVenta.bi01,
                  .bi02 = DocumentoVenta.bi02,
                  .igv01 = DocumentoVenta.igv01,
                  .igv02 = DocumentoVenta.igv02,
                  .bi01us = 0,
                  .bi02us = 0,
                  .igv01us = 0,
                  .igv02us = 0,
                  .ImporteNacional = DocumentoVenta.ImporteNacional,
                  .ImporteExtranjero = DocumentoVenta.ImporteExtranjero,
                  .tipoVenta = TIPO_VENTA.NOTA_DE_VENTA,
                  .estado = StatusNotaDeVentas.NoSustentado,
                  .estadoCobro = TipoCobro,
                  .estadoEntrega = TipoEntrega,
                  .terminos = "CONTADO",
                  .glosa = "Por ventas con nota de venta del cliente: " & TextProveedor.Text & "con tipo Doc. " & cboTipoDoc.Text & ", fecha de venta " & txtFecha.Value,
                  .fechaVcto = txtFecha.Value,
                  .usuarioActualizacion = DocumentoVenta.usuarioActualizacion,'usuario.IDUsuario,
                  .fechaActualizacion = DateTime.Now}
        'tipoEstado,
        ndocumento.documentoventaAbarrotes = nDocumentoVenta

        'REGISTRANDO LA GUIA DE REMISION
        'GuiaRemision(ndocumento)
        ListaDetalle = New List(Of documentoventaAbarrotesDet)
        For Each r In DocumentoVenta.documentoventaAbarrotesDet.ToList

            If CDec(r.monto1) <= 0 Then
                'MessageBoxAdv.Show("Debe ingresar un cantidad mayor a cero.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Question)
                btOperacion.Enabled = True
                Throw New Exception("Debe ingresar un cantidad mayor a cero.")
                'Exit Sub
            End If

            If (r.tipoExistencia <> TipoExistencia.ServicioGasto) Then
                If CDec(r.importeMN) <= 0 Then
                    btOperacion.Enabled = True
                    Throw New Exception("El importe de venta debe ser mayor a cero.")
                    '  MessageBoxAdv.Show("El importe de venta debe ser mayor a cero.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Question)
                    '  Exit Sub
                End If
            End If
            objDocumentoVentaDet = New documentoventaAbarrotesDet
            objDocumentoVentaDet.codigoLote = 0 'Integer.Parse(r.GetValue("codigoLote"))
            If ChPagoAvanzado.Checked Then
                If CDec(r.MontoSaldo) <= 0 Then
                    objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.COBRADO
                Else
                    objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO
                End If
            Else
                objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO
            End If



            objDocumentoVentaDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoVentaDet.IdEstablecimiento = GEstableciento.IdEstablecimiento ' almacenSA.GetUbicar_almacenPorID(i.Cells(24).Value()).idEstablecimiento
            objDocumentoVentaDet.FechaDoc = txtFecha.Value
            objDocumentoVentaDet.Serie = "NOTA"
            objDocumentoVentaDet.NumDoc = 1
            objDocumentoVentaDet.TipoDoc = "9907"
            If r.tipoExistencia = "GS" Then
                objDocumentoVentaDet.idAlmacenOrigen = Nothing
                'objDocumentoVentaDet.tipoVenta = r.tipo
            Else
                objDocumentoVentaDet.idAlmacenOrigen = r.idAlmacenOrigen
                'objDocumentoVentaDet.tipoVenta = r.GetValue("tipoPrecio")
            End If
            objDocumentoVentaDet.establecimientoOrigen = GEstableciento.IdEstablecimiento
            objDocumentoVentaDet.cuentaOrigen = Nothing
            objDocumentoVentaDet.idItem = r.idItem
            objDocumentoVentaDet.DetalleItem = r.nombreItem
            objDocumentoVentaDet.nombreItem = r.nombreItem
            objDocumentoVentaDet.tipoExistencia = r.tipoExistencia
            objDocumentoVentaDet.destino = r.destino
            objDocumentoVentaDet.unidad1 = r.unidad1
            objDocumentoVentaDet.monto1 = r.monto1
            objDocumentoVentaDet.unidad2 = Nothing
            objDocumentoVentaDet.monto2 = 0 ' CDec(r.GetValue("cantidad2")) ' i.Cells(31).Value()
            objDocumentoVentaDet.precioUnitario = r.precioUnitario
            objDocumentoVentaDet.precioUnitarioUS = r.precioUnitarioUS
            objDocumentoVentaDet.importeMN = r.importeMN
            objDocumentoVentaDet.importeME = r.importeME
            objDocumentoVentaDet.descuentoMN = 0
            objDocumentoVentaDet.descuentoME = 0

            objDocumentoVentaDet.montokardex = r.montokardex
            objDocumentoVentaDet.montoIsc = 0
            objDocumentoVentaDet.montoIgv = r.montoIgv
            objDocumentoVentaDet.otrosTributos = 0
            '**********************************************************************************
            objDocumentoVentaDet.montokardexUS = r.montokardexUS
            objDocumentoVentaDet.montoIscUS = 0
            objDocumentoVentaDet.montoIgvUS = r.montoIgvUS
            objDocumentoVentaDet.otrosTributosUS = 0
            objDocumentoVentaDet.estadoMovimiento = "V" 'ENTREGADO/COBRADO
            '**********************************************************************************
            objDocumentoVentaDet.importeMNK = 0 ' CDec(r.GetValue("puKardex"))
            objDocumentoVentaDet.importeMEK = 0 'CDec(r.GetValue("pukardeme"))
            objDocumentoVentaDet.fechaVcto = txtFecha.Value
            objDocumentoVentaDet.estadoEntrega = TipoEntrega
            objDocumentoVentaDet.cantidadEntrega = r.cantidadEntrega
            objDocumentoVentaDet.salidaCostoMN = 0
            objDocumentoVentaDet.salidaCostoME = 0
            objDocumentoVentaDet.NomMarca = Nothing ' r.GetValue("marca")
            objDocumentoVentaDet.categoria = Nothing
            objDocumentoVentaDet.preEvento = Nothing
            objDocumentoVentaDet.usuarioModificacion = DocumentoVenta.usuarioActualizacion ' usuario.IDUsuario
            objDocumentoVentaDet.fechaModificacion = DateTime.Now
            objDocumentoVentaDet.Glosa = "Por nota de ventas"
            objDocumentoVentaDet.tipobeneficio = r.tipobeneficio
            objDocumentoVentaDet.beneficiobase = r.beneficiobase
            objDocumentoVentaDet.descuentoMN = r.descuentoMN
            ListaDetalle.Add(objDocumentoVentaDet)
        Next
        'Dim listaBeneficios = GetDetalleBeneficios()
        'If listaBeneficios.Count > 0 Then
        '    ListaDetalle.AddRange(listaBeneficios)
        'End If

        '-------------------------------------------------------------------------------------
        '---------------- VALIDACION DE IMPORTE CON DETALLE DE VENTA -------------------------

        Dim sumaVentaMN As Decimal = ListaDetalle.Sum(Function(o) o.importeMN).GetValueOrDefault
        Dim sumaVentaME As Decimal = ListaDetalle.Sum(Function(o) o.importeME).GetValueOrDefault
        Dim sumaBase1MN As Decimal =
            ListaDetalle.Where(Function(o) o.destino = OperacionGravada.Grabado).Sum(Function(o) o.montokardex).GetValueOrDefault

        Dim sumaBase1ME As Decimal =
            ListaDetalle.Where(Function(o) o.destino = OperacionGravada.Grabado).Sum(Function(o) o.montokardexUS).GetValueOrDefault

        Dim sumaBase2MN As Decimal =
            ListaDetalle.Where(Function(o) o.destino = OperacionGravada.Exonerado).Sum(Function(o) o.montokardex).GetValueOrDefault

        Dim sumaBase2ME As Decimal =
            ListaDetalle.Where(Function(o) o.destino = OperacionGravada.Exonerado).Sum(Function(o) o.montokardexUS).GetValueOrDefault

        Dim sumaIgvMN As Decimal = ListaDetalle.Sum(Function(o) o.montoIgv).GetValueOrDefault
        Dim sumaIgvME As Decimal = ListaDetalle.Sum(Function(o) o.montoIgvUS).GetValueOrDefault

        Dim totalVentaDetalle As Decimal = sumaBase1MN + sumaBase2MN + sumaIgvMN
        Dim totalHeader As Decimal = txtTotalPagar.DecimalValue
        If totalHeader <> totalVentaDetalle Then
            btOperacion.Enabled = True
            Throw New Exception("Los importes no coinciden, tanto del detalle con la cabecera ")
        End If
        '-------------------------------------------------------------------------------------
        ndocumento.documentoventaAbarrotes.documentoventaAbarrotesDet = ListaDetalle

        Dim listaExistencias As List(Of documentoventaAbarrotesDet) = (From n In ListaDetalle
                                                                       Where n.tipoExistencia <> TipoRecurso.SERVICIO).ToList
        If listaExistencias.Count > 0 Then
            AsientoVenta(listaExistencias)
        End If

        Dim listaServicios As List(Of documentoventaAbarrotesDet) = (From n In ListaDetalle
                                                                     Where n.tipoExistencia = TipoRecurso.SERVICIO).ToList

        If listaServicios.Count > 0 Then
            AsientoVentaServicios(listaServicios)
        End If

        'GuiaRemision(ndocumento)


        If ChPagoAvanzado.Checked = True Then
            'Dim f As New FormPagoVariasCajas ' frmFormatoPagoComprobantes
            'f.txtMontoXcobrar.Text = nDocumentoVenta.ImporteNacional ' txtTotalPagar.DecimalValue
            'f.StartPosition = FormStartPosition.CenterParent
            'f.ShowDialog()
            'If f.Tag IsNot Nothing Then
            '    Dim c = CType(f.Tag, List(Of documentoCaja))
            '    If c.Count > 0 Then
            'Dim ListaPagos = ListaPagosCajas(ndocumento.documentoventaAbarrotes, ndocumento.documentoventaAbarrotes.documentoventaAbarrotesDet)
            'Dim SumaPagos As Decimal = 0
            'For Each i In ListaPagos
            '    SumaPagos += i.documentoCaja.montoSoles.GetValueOrDefault
            'Next
            'If SumaPagos = nDocumentoVenta.ImporteNacional Then
            '    ndocumento.documentoventaAbarrotes.terminos = "CONTADO"
            'Else
            '    'ndocumento.documentoventaAbarrotes.terminos = "PARCIAL"
            '    ndocumento.documentoventaAbarrotes.terminos = "CREDITO"
            'End If
            'ndocumento.documentoventaAbarrotes.estadoCobro = ndocumento.documentoventaAbarrotes.GetEstadoPagoComprobante
            'ndocumento.ListaCustomDocumento = ListaPagos 'ListaPagosCajas(c)
            '    Else
            '        MessageBox.Show("Debe realizar el pago del comprobante", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '        Exit Sub
            '    End If
            'Else
            '    MessageBox.Show("Debe realizar el pago del comprobante", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    Exit Sub
            'End If
        Else
            ndocumento.documentoventaAbarrotes.estadoCobro = "PN"
            ndocumento.documentoventaAbarrotes.terminos = "CREDITO"
        End If


        Dim idDocuentoGrabado As Integer
        If ListaDetalle.Where(Function(o) o.monto1 = 0).Count = 0 Then
            If PanelCupon.Visible Then
                If TextCuponImporte.DecimalValue > 0 Then
                    ndocumento.CustomListaBeneficios = New List(Of Business.Entity.beneficio) From
                {
                New Business.Entity.beneficio With {.beneficio_id = TextCodigoCupon.Tag}
                }
                End If
            End If

            If listaAnticipoDetalle IsNot Nothing Then
                If listaAnticipoDetalle.Count > 0 Then
                    ndocumento.ListaDetalleAnticipos = listaAnticipoDetalle
                End If
            End If

            ndocumento.asiento = ListaAsientonTransito
            idDocuentoGrabado = docVentaSA.Grabar_VentaNotaSinLote(ndocumento)
            DocumentoVenta = Nothing
            'GetImpresionTicketsEspecialNota(idDocuentoGrabado)
            If listaCuponesActivos IsNot Nothing Then
                If listaCuponesActivos.Count > 0 Then
                    Dim valorDeVenta = txtTotalPagar.DecimalValue ' 

                    Dim calculoCupon = valorDeVenta / listaCuponesActivos.FirstOrDefault.valorbase
                    Dim parteEntera = CInt(calculoCupon)
                    If parteEntera > 0 Then
                        LabelCupon.Text = listaCuponesActivos.FirstOrDefault.descripcion
                        LabelCupon.Tag = listaCuponesActivos.FirstOrDefault
                        GetBeneficioMappingCliente(CType(LabelCupon.Tag, Business.Entity.beneficioProduccionConsumo))
                    End If
                End If
            End If

            ChPagoAvanzado.Checked = True
            PagoDirectoCheck()
            btOperacion.Enabled = False
            TextCodigoVendedor.Clear()
            TextComprador.Clear()
            lblPagoVenta.Text = "0.00"
            txtTotalBase.DecimalValue = 0
            txtTotalBase2.DecimalValue = 0
            txtTotalBase3.DecimalValue = 0
            txtTotalIva.DecimalValue = 0
            TextTotalDescuentos.DecimalValue = 0
            txtTotalPagar.DecimalValue = 0
            LabelTotalCobrarCliente.Text = "0.00"
            TextPagoAnticipoDisponible.DecimalValue = 0
            TextValoranticipo.DecimalValue = 0
            GetUbicarClienteGeneral()

            chCredito.Checked = False
            LblPagoCredito.Visible = False
            chCobranzaParcial.Checked = False
            PanelCupon.Visible = False
            ErrorProvider1.Clear()
            GetMappingColumnsGrid()

            Alert = New Alert("Venta registrada", alertType.success)
            Alert.TopMost = True
            Alert.Show()
            'objPleaseWait.Close()

            GetImpresionTicketsEspecialNota(idDocuentoGrabado)

            HabilitarPago(False)
            ToolImportar.PerformClick()

            'Dim miInterfaz As ICommitOperacionMKT = TryCast(Me.Owner, ICommitOperacionMKT)
            'If miInterfaz IsNot Nothing Then miInterfaz.Commit(True, idDocuentoGrabado)
            'objPleaseWait.Close()
            'Close()

        Else
            btOperacion.Enabled = True
            Throw New Exception("Debe verificar que las celdas estan completas!")
        End If
    End Sub

    'Private Function GetDetalleBeneficios() As List(Of documentoventaAbarrotesDet)
    '    GetDetalleBeneficios = New List(Of documentoventaAbarrotesDet)
    '    Dim objDocumentoVentaDet As documentoventaAbarrotesDet
    '    For Each r In DocumentoVenta.documentoventaAbarrotesDet.ToList
    '        objDocumentoVentaDet = New documentoventaAbarrotesDet
    '        objDocumentoVentaDet.codigoLote = 0
    '        objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.COBRADO
    '        objDocumentoVentaDet.IdEmpresa = Gempresas.IdEmpresaRuc
    '        objDocumentoVentaDet.IdEstablecimiento = GEstableciento.IdEstablecimiento
    '        objDocumentoVentaDet.FechaDoc = txtFecha.Value
    '        objDocumentoVentaDet.Serie = "NOTA"
    '        objDocumentoVentaDet.NumDoc = 1
    '        objDocumentoVentaDet.TipoDoc = "9907"

    '        objDocumentoVentaDet.idAlmacenOrigen = r.idAlmacenOrigen
    '        objDocumentoVentaDet.tipoVenta = 0

    '        objDocumentoVentaDet.establecimientoOrigen = GEstableciento.IdEstablecimiento
    '        objDocumentoVentaDet.cuentaOrigen = Nothing
    '        objDocumentoVentaDet.idItem = r.idItem
    '        objDocumentoVentaDet.DetalleItem = r.nombreItem
    '        objDocumentoVentaDet.nombreItem = r.nombreItem
    '        objDocumentoVentaDet.tipoExistencia = r.tipoExistencia
    '        objDocumentoVentaDet.destino = r.destino
    '        objDocumentoVentaDet.unidad1 = r.unidad1
    '        objDocumentoVentaDet.monto1 = r.monto1
    '        objDocumentoVentaDet.unidad2 = Nothing
    '        objDocumentoVentaDet.monto2 = 0 ' CDec(r.GetValue("cantidad2")) ' i.Cells(31).Value()
    '        objDocumentoVentaDet.precioUnitario = 0
    '        objDocumentoVentaDet.precioUnitarioUS = 0
    '        objDocumentoVentaDet.importeMN = 0
    '        objDocumentoVentaDet.importeME = 0
    '        objDocumentoVentaDet.descuentoMN = 0
    '        objDocumentoVentaDet.descuentoME = 0

    '        objDocumentoVentaDet.montokardex = 0
    '        objDocumentoVentaDet.montoIsc = 0
    '        objDocumentoVentaDet.montoIgv = 0
    '        objDocumentoVentaDet.otrosTributos = 0
    '        '**********************************************************************************
    '        objDocumentoVentaDet.montokardexUS = 0
    '        objDocumentoVentaDet.montoIscUS = 0
    '        objDocumentoVentaDet.montoIgvUS = 0
    '        objDocumentoVentaDet.otrosTributosUS = 0
    '        objDocumentoVentaDet.estadoMovimiento = "V" 'ENTREGADO/COBRADO
    '        '**********************************************************************************
    '        objDocumentoVentaDet.importeMNK = 0 ' CDec(r.GetValue("puKardex"))
    '        objDocumentoVentaDet.importeMEK = 0 'CDec(r.GetValue("pukardeme"))
    '        objDocumentoVentaDet.fechaVcto = txtFecha.Value
    '        'objDocumentoVentaDet.estadoEntrega = TipoEntregado.Entregado
    '        'objDocumentoVentaDet.cantidadEntrega = CDec(r.GetValue("cantidad"))
    '        objDocumentoVentaDet.salidaCostoMN = 0
    '        objDocumentoVentaDet.salidaCostoME = 0
    '        objDocumentoVentaDet.NomMarca = Nothing ' r.GetValue("marca")
    '        objDocumentoVentaDet.categoria = Nothing
    '        objDocumentoVentaDet.preEvento = Nothing
    '        objDocumentoVentaDet.usuarioModificacion = usuario.IDUsuario
    '        objDocumentoVentaDet.fechaModificacion = DateTime.Now
    '        objDocumentoVentaDet.Glosa = "beneficios de venta afavor del cliente "
    '        objDocumentoVentaDet.tipobeneficio = r.tipobeneficio
    '        objDocumentoVentaDet.beneficiobase = 0
    '        objDocumentoVentaDet.descuentoMN = 0
    '        GetDetalleBeneficios.Add(objDocumentoVentaDet)
    '    Next
    'End Function

    Private Sub GetImpresionTicketsEspecialNota(idDocumento As Integer)
        Dim ventaSA As New documentoVentaAbarrotesSA

        'If MessageBox.Show("Desea imprimir la venta ?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
        'ImprimirTicketGladis(idDocumento)
        'ImprimirTicketAcumulado(idDocumento)

        'Dim f As New FormImpresionNuevo  ' frmVentaNuevoFormato
        'f.DocumentoID = idDocumento
        'f.StartPosition = FormStartPosition.CenterScreen
        'f.BringToFront()
        ' f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        'f.ShowDialog(Me)

        'ventaSA.GetActualizarImpresion(New documentoventaAbarrotes With {.idDocumento = idDocumento})
        'End If
    End Sub

    Function ListaDocumentoCaja(VENTA As documentoventaAbarrotes) As List(Of documento)
        Dim nDocumentoCaja As New documento
        Dim objCaja As New documentoCaja
        Dim ListaDoc As New List(Of documento)

        Dim tipoDocumento As String = Nothing
        Dim serieVenta As String = Nothing
        Dim numeroVenta As String = Nothing

        Select Case VENTA.tipoDocumento
            Case "9907"
                tipoDocumento = "9907"
                serieVenta = "NOTE"
                numeroVenta = "1"
            Case Else
                tipoDocumento = VENTA.tipoDocumento
                serieVenta = VENTA.serieVenta
                numeroVenta = VENTA.numeroVenta
        End Select

        nDocumentoCaja = New documento
        'DOCUMENTO
        nDocumentoCaja.idDocumento = CInt(Me.Tag)
        nDocumentoCaja.idEmpresa = Gempresas.IdEmpresaRuc
        nDocumentoCaja.idCentroCosto = GEstableciento.IdEstablecimiento
        nDocumentoCaja.tipoDoc = tipoDocumento ' cbotipoDocPago.SelectedValue
        nDocumentoCaja.fechaProceso = txtFecha.Value
        nDocumentoCaja.nroDoc = serieVenta & "-" & numeroVenta
        nDocumentoCaja.idOrden = Nothing
        nDocumentoCaja.moneda = If(cboMoneda.Text = "NACIONAL", "1", "2")
        If TextProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            nDocumentoCaja.idEntidad = Val(TextProveedor.Tag)
            nDocumentoCaja.entidad = TextProveedor.Text
            nDocumentoCaja.nrodocEntidad = TextNumIdentrazon.Text
        Else
            nDocumentoCaja.entidad = TextProveedor.Text
            nDocumentoCaja.nrodocEntidad = 0
            nDocumentoCaja.idEntidad = Val(0)
        End If
        nDocumentoCaja.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nDocumentoCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
        nDocumentoCaja.usuarioActualizacion = usuario.IDUsuario
        nDocumentoCaja.fechaActualizacion = DateTime.Now

        'DOCUMENTO CAJA
        objCaja = New documentoCaja
        objCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
        objCaja.idDocumento = 0
        objCaja.periodo = VENTA.fechaPeriodo ' lblPerido.Text
        objCaja.idEmpresa = Gempresas.IdEmpresaRuc
        objCaja.idEstablecimiento = GEstableciento.IdEstablecimiento
        objCaja.fechaProceso = txtFecha.Value
        objCaja.fechaCobro = txtFecha.Value
        objCaja.tipoMovimiento = TIPO_VENTA.PAGO.COBRADO
        If TextProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            objCaja.codigoProveedor = Integer.Parse(TextProveedor.Tag)
            objCaja.IdProveedor = Integer.Parse(TextProveedor.Tag)
            objCaja.idPersonal = Integer.Parse(TextProveedor.Tag)
        End If
        objCaja.tipoDocPago = tipoDocumento
        objCaja.TipoDocumentoPago = tipoDocumento 'cbotipoDocPago.SelectedValue
        objCaja.codigoLibro = "1"
        objCaja.formapago = "109"
        objCaja.NumeroDocumento = "-"
        objCaja.numeroOperacion = "-"

        Select Case VENTA.tipoDocumento
            Case "9907"
                objCaja.movimientoCaja = TIPO_VENTA.NOTA_DE_VENTA
            Case Else
                objCaja.movimientoCaja = TIPO_VENTA.VENTA_POS_DIRECTA
        End Select

        objCaja.montoSoles = Decimal.Parse(VENTA.ImporteNacional)

        objCaja.moneda = If(cboMoneda.Text = "NACIONAL", "1", "2")
        objCaja.tipoCambio = TmpTipoCambio
        objCaja.montoUsd = FormatNumber(objCaja.montoSoles / TmpTipoCambio, 2)

        objCaja.estado = "1"
        objCaja.glosa = "Por ventas POS directa del cliente: " & TextProveedor.Text & "con tipo Doc. " & cboTipoDoc.Text & ", fecha de venta " & txtFecha.Value
        objCaja.entregado = "SI"

        objCaja.idCajaUsuario = GFichaUsuarios.IdCajaUsuario
        objCaja.usuarioModificacion = usuario.IDUsuario
        objCaja.entidadFinanciera = 0
        objCaja.NombreEntidad = String.Empty
        objCaja.fechaModificacion = DateTime.Now

        nDocumentoCaja.documentoCaja = objCaja
        ListaDoc.Add(nDocumentoCaja)
        ListaDetalleCaja(nDocumentoCaja.documentoCaja)
        '  asientoDocumento(nDocumentoCaja.documentoCaja)

        Return ListaDoc
    End Function

    Private Sub ListaDetalleCaja(doc As documentoCaja)
        Dim obj As New documentoCajaDetalle
        Dim lista As New List(Of documentoCajaDetalle)
        For Each i In DocumentoVenta.documentoventaAbarrotesDet.ToList
            If i.tipobeneficio <> "OFERTA" Then
                If i.tipobeneficio <> "REGALO" Then
                    obj = New documentoCajaDetalle
                    obj.fecha = Date.Now
                    obj.codigoLote = 0 'Integer.Parse(i.GetValue("codigoLote"))
                    obj.otroMN = 0 'Integer.Parse(i.GetValue("codigoLote"))
                    obj.idItem = i.idItem
                    obj.DetalleItem = i.nombreItem
                    obj.montoSoles = i.importeMN
                    obj.montoUsd = i.importeME
                    obj.diferTipoCambio = 1
                    obj.tipoCambioTransacc = 1
                    obj.entregado = "SI"
                    obj.idCajaUsuario = GFichaUsuarios.IdCajaUsuario
                    obj.usuarioModificacion = usuario.IDUsuario
                    obj.documentoAfectado = CInt(Me.Tag)
                    obj.fechaModificacion = DateTime.Now
                    lista.Add(obj)
                End If
            End If
        Next
        doc.documentoCajaDetalle = lista
    End Sub

    Private Sub FormConfirmaVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtFecha.Value = DateTime.Now
        txtFecha.Enabled = True
        cboTipoDoc.Focus()
        GetUbicarClienteGeneral()
        chCredito.Checked = False
        LblPagoCredito.Visible = False
        chCobranzaParcial.Checked = False
        PanelCupon.Visible = False
        ErrorProvider1.Clear()
        '   GetMappingColumnsGrid()
        centrar()
    End Sub

    Private Sub GetUbicarClienteGeneral()
        '  Dim entidadSA As New entidadSA
        '   Dim ClienteGeneral = entidadSA.UbicarEntidadVarios("VR", Gempresas.IdEmpresaRuc, String.Empty)
        If VarClienteGeneral IsNot Nothing Then
            'txtruc.Text = VarClienteGeneral.nrodoc
            'TXTcOMPRADOR.Text = VarClienteGeneral.nombreCompleto
            'TXTcOMPRADOR.Tag = VarClienteGeneral.idEntidad
            'TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            'txtruc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            GetBeneficios()
        End If

    End Sub

    'Private Sub TXTcOMPRADOR_TextChanged(sender As Object, e As EventArgs)
    '    TXTcOMPRADOR.ForeColor = Color.Black
    '    TXTcOMPRADOR.Tag = Nothing
    '    If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
    '        txtruc.Visible = True
    '    Else
    '        txtruc.Visible = True
    '    End If
    'End Sub

    'Private Sub TXTcOMPRADOR_KeyDown(sender As Object, e As KeyEventArgs)
    '    If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

    '    ElseIf e.KeyCode = Keys.Enter Then
    '        Me.pcLikeCategoria.Size = New Size(319, 128)
    '        Me.pcLikeCategoria.ParentControl = Me.TXTcOMPRADOR
    '        Me.pcLikeCategoria.ShowPopup(Point.Empty)
    '        Dim consulta As New List(Of entidad)
    '        consulta.Add(New entidad With {.nombreCompleto = "Agregar nuevo"})



    '        Dim consulta2 = (From n In listaClientes
    '                         Where n.nombreCompleto.StartsWith(TXTcOMPRADOR.Text) Or n.nrodoc.StartsWith(TXTcOMPRADOR.Text)).ToList


    '        consulta.AddRange(consulta2)
    '        FillLSVClientes(consulta)
    '        If consulta.Count <= 1 Then
    '            If MessageBox.Show("El cliente ingresado no existe!. Desea crearlo ahora?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

    '                Dim f As New frmCrearENtidades(TXTcOMPRADOR.Text)
    '                f.CaptionLabels(0).Text = "Nuevo cliente"
    '                f.strTipo = TIPO_ENTIDAD.CLIENTE
    '                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
    '                f.StartPosition = FormStartPosition.CenterParent
    '                f.ShowDialog()
    '                If f.Tag IsNot Nothing Then
    '                    Dim c = CType(f.Tag, entidad)
    '                    TXTcOMPRADOR.Text = c.nombreCompleto
    '                    TXTcOMPRADOR.Tag = c.idEntidad
    '                    txtruc.Visible = True
    '                    txtruc.Text = c.nrodoc
    '                    txtruc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
    '                    TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
    '                    listaClientes.Add(c)
    '                End If

    '            End If

    '        End If

    '    Else
    '        '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
    '        Me.pcLikeCategoria.Size = New Size(282, 128)
    '        Me.pcLikeCategoria.ParentControl = Me.TXTcOMPRADOR
    '        Me.pcLikeCategoria.ShowPopup(Point.Empty)
    '        Dim consulta As New List(Of entidad)
    '        consulta.Add(New entidad With {.nombreCompleto = "Agregar nuevo"})



    '        Dim consulta2 = (From n In listaClientes
    '                         Where n.nombreCompleto.StartsWith(TXTcOMPRADOR.Text) Or n.nrodoc.StartsWith(TXTcOMPRADOR.Text)).ToList




    '        consulta.AddRange(consulta2)
    '        FillLSVClientes(consulta)
    '        e.Handled = True
    '    End If

    '    If e.KeyCode = Keys.Down Then
    '        '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
    '        Me.pcLikeCategoria.Size = New Size(282, 128)
    '        Me.pcLikeCategoria.ParentControl = Me.TXTcOMPRADOR
    '        Me.pcLikeCategoria.ShowPopup(Point.Empty)
    '        LsvProveedor.Focus()
    '    End If
    '    '   End If

    '    ' e.SuppressKeyPress = True
    '    If e.KeyCode = Keys.Escape Then
    '        If Me.pcLikeCategoria.IsShowing() Then
    '            Me.pcLikeCategoria.HidePopup(PopupCloseType.Canceled)
    '        End If
    '    End If
    'End Sub

    Private Sub FillLSVClientes(consulta As List(Of entidad))
        LsvProveedor.Items.Clear()
        '     Dim image = ImageList1.Images(0)
        For Each i In consulta
            Dim n As New ListViewItem(i.idEntidad)

            n.SubItems.Add(i.nombreCompleto)
            n.SubItems.Add(i.nrodoc)
            n.SubItems.Add(i.tipoDoc)
            LsvProveedor.Items.Add(n)
        Next
    End Sub

    'Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles LsvProveedor.MouseDoubleClick
    '    Me.pcLikeCategoria.HidePopup(PopupCloseType.Done)
    'End Sub

    'Private Sub pcLikeCategoria_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcLikeCategoria.CloseUp
    '    Dim beneficioSA As New beneficioSA
    '    Me.Cursor = Cursors.WaitCursor
    '    Try
    '        If e.PopupCloseType = PopupCloseType.Done Then
    '            If LsvProveedor.SelectedItems.Count > 0 Then
    '                If LsvProveedor.SelectedItems(0).SubItems(1).Text = "Agregar nuevo" Then
    '                    Dim f As New frmCrearENtidades
    '                    f.CaptionLabels(0).Text = "Nuevo cliente"
    '                    f.strTipo = TIPO_ENTIDAD.CLIENTE
    '                    f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
    '                    'f.tipoPersona(TIPO_ENTIDAD.CLIENTE)
    '                    f.StartPosition = FormStartPosition.CenterParent
    '                    f.ShowDialog()
    '                    If Not IsNothing(f.Tag) Then
    '                        Dim c = CType(f.Tag, entidad)
    '                        listaClientes.Add(c)
    '                        'txtTipoDocClie.Text = c.tipoDoc
    '                        TXTcOMPRADOR.Text = c.nombreCompleto
    '                        txtruc.Text = c.nrodoc
    '                        TXTcOMPRADOR.Tag = c.idEntidad
    '                        txtruc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
    '                        txtruc.Visible = True
    '                        TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
    '                    End If
    '                Else
    '                    TXTcOMPRADOR.Text = LsvProveedor.SelectedItems(0).SubItems(1).Text
    '                    TXTcOMPRADOR.Tag = LsvProveedor.SelectedItems(0).SubItems(0).Text
    '                    TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
    '                    txtruc.Text = LsvProveedor.SelectedItems(0).SubItems(2).Text
    '                    'txtTipoDocClie.Text = LsvProveedor.SelectedItems(0).SubItems(3).Text
    '                    txtruc.Visible = True
    '                    'ListaBeneficios = New List(Of Business.Entity.beneficio)
    '                    'ListaBeneficios = beneficioSA.BeneficioListaClienteProductions(New Business.Entity.beneficio With {.idCliente = Integer.Parse(TXTcOMPRADOR.Tag)})

    '                    'If ListaBeneficios.Count > 0 Then
    '                    '    TotalesColumnaDescuentos(ListaBeneficios)
    '                    'Else
    '                    '    TotalesColumnaDescuentos(ListaBeneficios)
    '                    'End If


    '                    'TextBenefClienteBase.Text = beneficio.importeBase.GetValueOrDefault
    '                    'TextValorAfecto.Text = beneficio.valorConvertido

    '                    'Select Case beneficio.tipoAfectacion
    '                    '    Case "I"
    '                    '        TextTipoBeneficio.Text = "IMPORTE"
    '                    '    Case "C"
    '                    '        TextTipoBeneficio.Text = "CANTIDAD"
    '                    '    Case "P"
    '                    '        TextTipoBeneficio.Text = "PORCENTAJE"
    '                    'End Select

    '                End If
    '                'ListaMercaderiasXIdHijo(Val(txtSubCategoria.Tag), cboTipoExistencia.SelectedValue)
    '            End If
    '        End If

    '        'Set focus back to textbox.
    '        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
    '            Me.TXTcOMPRADOR.Focus()
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try

    '    Me.Cursor = Cursors.Arrow
    'End Sub

    Private Sub FormConfirmaVenta_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        '  BackgroundWorker1.CancelAsync()
        'If thread IsNot Nothing Then
        '    thread.Abort()
        'End If
    End Sub

    Private Sub ChPagoDirecto_OnChange(sender As Object, e As EventArgs)
        PagoDirectoCheck()
        'Me.dgvCuentas.Table.Records.DeleteAll()
        'Me.dgvCuentas.Table.AddNewRecord.SetCurrent()
        'Me.dgvCuentas.Table.AddNewRecord.BeginEdit()
        'Me.dgvCuentas.Table.CurrentRecord.SetValue("tipo", Nothing) '0
        'Me.dgvCuentas.Table.CurrentRecord.SetValue("identidad", cbocajaPago.SelectedValue)
        'Me.dgvCuentas.Table.CurrentRecord.SetValue("entidad", cbocajaPago.Text)
        'Me.dgvCuentas.Table.CurrentRecord.SetValue("abonado", CDec(txtTotalPagar.Text))
        'Me.dgvCuentas.Table.CurrentRecord.SetValue("tipocambio", TmpTipoCambio)
        'Me.dgvCuentas.Table.CurrentRecord.SetValue("idforma", Nothing)
        'Me.dgvCuentas.Table.CurrentRecord.SetValue("formaPago", "CUENTA EFECTIVO")
        'Me.dgvCuentas.Table.AddNewRecord.EndEdit()
    End Sub

    Private Sub ChPagoAvanzado_OnChange(sender As Object, e As EventArgs) Handles ChPagoAvanzado.OnChange
        If ChPagoAvanzado.Checked = True Then
            chCredito.Checked = False
            LblPagoCredito.Visible = False
            chCobranzaParcial.Checked = False
            PanelCupon.Visible = False
            ErrorProvider1.Clear()
            GetMappingColumnsGrid()
        Else
            PanelCupon.Visible = False
            ChPagoAvanzado.Checked = True
        End If
        'If ChPagoAvanzado.Checked = False AndAlso ChPagoDirecto.Checked = False Then
        '    LblPagoCredito.Visible = True
        'Else
        '    LblPagoCredito.Visible = False
        'End If
    End Sub

    Private Sub txtruc_KeyDown(sender As Object, e As KeyEventArgs)
        'If (e.KeyCode = Keys.Enter) Then
        '    If (cboTipoDoc.Text = "FACTURA") Then
        '        If (txtruc.Text.Length = 11) Then
        '            ValidarSunat(txtruc.Text)
        '        Else
        '            txtruc.Clear()
        '            TXTcOMPRADOR.Clear()
        '            lblValidacion.Text = "Ingresar RUC"
        '            TXTcOMPRADOR.Clear()
        '            TXTcOMPRADOR.Tag = 0
        '            txtNumero.Clear()
        '            GetBeneficios()
        '        End If
        '    ElseIf (cboTipoDoc.Text = "BOLETA") Then
        '        If (txtruc.Text.Length = 8) Then
        '            ValidarReniec(txtruc.Text)
        '        ElseIf (txtruc.Text.Length = 11) Then
        '            ValidarSunat(txtruc.Text)
        '        Else
        '            TXTcOMPRADOR.Clear()
        '            txtruc.Clear()
        '            lblValidacion.Text = "Verifique número"
        '            TXTcOMPRADOR.Clear()
        '            TXTcOMPRADOR.Tag = 0
        '            txtNumero.Clear()
        '            GetBeneficios()
        '        End If
        '    ElseIf (cboTipoDoc.Text = "FACTURA") Then
        '        If (txtruc.Text.Length = 11) Then
        '            ValidarSunat(txtruc.Text)
        '        Else
        '            txtruc.Clear()
        '            TXTcOMPRADOR.Clear()
        '            lblValidacion.Text = "Ingresa RUC"
        '            TXTcOMPRADOR.Clear()
        '            TXTcOMPRADOR.Tag = 0
        '            txtNumero.Clear()
        '            GetBeneficios()
        '        End If
        '    ElseIf (cboTipoDoc.Text = "BOLETA") Then
        '        If (txtruc.Text.Length = 8) Then
        '            ValidarReniec(txtruc.Text)
        '        ElseIf (txtruc.Text.Length = 11) Then
        '            ValidarSunat(txtruc.Text)
        '        Else
        '            TXTcOMPRADOR.Clear()
        '            txtruc.Clear()
        '            lblValidacion.Text = "Ingresa DNI"
        '            TXTcOMPRADOR.Clear()
        '            TXTcOMPRADOR.Tag = 0
        '            txtNumero.Clear()
        '            GetBeneficios()
        '        End If
        '    Else
        '        If (txtruc.Text.Length = 8) Then
        '            ValidarReniec(txtruc.Text)
        '        ElseIf (txtruc.Text.Length = 11) Then
        '            ValidarSunat(txtruc.Text)
        '        Else
        '            lblValidacion.Text = "Verifica número"
        '            TXTcOMPRADOR.Clear()
        '            TXTcOMPRADOR.Tag = 0
        '            txtNumero.Clear()
        '            GetBeneficios()
        '        End If
        '    End If
        'ElseIf (e.KeyCode = Keys.Back) Then
        '    TXTcOMPRADOR.Clear()
        'ElseIf (e.KeyCode = Keys.Delete) Then
        '    TXTcOMPRADOR.Clear()
        'End If


    End Sub

    Public Property TextoEtiqueta() As String
        Get
            Return Me.Label1.Text

        End Get
        Set(value As String)
            Me.Label1.Text = value

        End Set

    End Property

    Private Sub ValidarSunat(RUC As String)
        Cursor = Cursors.WaitCursor

        If RUC.Length > 0 Then
            Dim objeto As Boolean = ValidationRUC(RUC)
            If objeto = False Then
                MessageBox.Show("Debe Ingresar un Numero correcto de ruc", "Ingresar identificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Cursor = Cursors.Default
                TextNumIdentrazon.Clear()
                TextProveedor.Clear()
                TextProveedor.Tag = 0
                txtNumero.Clear()
                GetBeneficios()
                Exit Sub
            End If

            If cboTipoDoc.Text = "FACTURA" Then

                'LinkLabel1.Enabled = False
                'PanelLoading.Visible = True
                'ProgressBar4.Visible = True
                'ProgressBar4.Style = ProgressBarStyle.Marquee
                GetConsultaSunatAsync(RUC)
                'Select Case LinkLabel1.Text
                '    Case "Consultar en SUNAT"

            ElseIf (cboTipoDoc.Text = "BOLETA") Then
                'PanelLoading.Visible = True
                'ProgressBar4.Visible = True
                'ProgressBar4.Style = ProgressBarStyle.Marquee
                GetConsultaSunatAsync(RUC)
            ElseIf (cboTipoDoc.Text = "BOLETA") Then

                GetConsultaSunatAsync(RUC)
            ElseIf (cboTipoDoc.Text = "FACTURA") Then

                GetConsultaSunatAsync(RUC)

            ElseIf cboTipoDoc.Text = "NOTA DE VENTA" Then

                GetConsultaSunatAsync(RUC)
            Else
                GetBeneficios()
            End If

            '    Case "Consultar en RENIEC"
            '        GetConsultarDNIReniec(txtDocProveedor.Text.Trim)
            'End Select
        Else
            MessageBox.Show("Debe ingresar un número de documento", "Ingresar identificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'ProgressBar1.Visible = False
            'txtDocProveedor.Select()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ValidarReniec(DNI As String)
        Cursor = Cursors.WaitCursor
        If DNI.Length > 0 Then

            GetConsultarDNIReniec(DNI)

        Else
            MessageBox.Show("Debe ingresar un número de documento", "Ingresar identificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            'txtDocProveedor.Select()
        End If
        Cursor = Cursors.Default
    End Sub

    Sub CalculosMontos()
        If DocumentoVenta.moneda = "2" Then
            txtTotalBase.DecimalValue = DocumentoVenta.bi01us.GetValueOrDefault
            txtTotalBase2.DecimalValue = DocumentoVenta.bi02us.GetValueOrDefault
            txtTotalBase3.DecimalValue = 0
            txtTotalIcbper.DecimalValue = DocumentoVenta.icbper.GetValueOrDefault
            txtTotalIva.DecimalValue = DocumentoVenta.igv01us.GetValueOrDefault
            TextSubTotal.DecimalValue = DocumentoVenta.ImporteExtranjero.GetValueOrDefault + DocumentoVenta.importeCostoME.GetValueOrDefault
            txtTotalPagar.DecimalValue = TextSubTotal.DecimalValue - DocumentoVenta.importeCostoME.GetValueOrDefault
            LabelTotalCobrarCliente.Text = TextSubTotal.DecimalValue - DocumentoVenta.importeCostoMN.GetValueOrDefault
            TextTotalDescuentos.DecimalValue = DocumentoVenta.importeCostoME.GetValueOrDefault
        Else
            txtTotalBase.DecimalValue = DocumentoVenta.bi01.GetValueOrDefault
            txtTotalBase2.DecimalValue = DocumentoVenta.bi02.GetValueOrDefault
            txtTotalBase3.DecimalValue = 0
            txtTotalIcbper.DecimalValue = DocumentoVenta.icbper.GetValueOrDefault
            txtTotalIva.DecimalValue = DocumentoVenta.igv01.GetValueOrDefault
            TextSubTotal.DecimalValue = DocumentoVenta.ImporteNacional.GetValueOrDefault + DocumentoVenta.importeCostoMN.GetValueOrDefault
            txtTotalPagar.DecimalValue = TextSubTotal.DecimalValue - DocumentoVenta.importeCostoMN.GetValueOrDefault
            LabelTotalCobrarCliente.Text = TextSubTotal.DecimalValue - DocumentoVenta.importeCostoMN.GetValueOrDefault
            TextTotalDescuentos.DecimalValue = DocumentoVenta.importeCostoMN.GetValueOrDefault
        End If

    End Sub

    'Private Async Sub GetConsultaSunatAsync(ruc As String)
    '    Dim nroDoc = ruc.Substring(0, 1).ToString
    '    Dim entidadBE As New entidad
    '    Dim objEntidad As New entidad

    '    If nroDoc = "1" Then
    '        'VALIDANDO PROVEEDOR DE MANERA LOCAL
    '        objEntidad = entidadSA.UbicarClienteXID(New entidad With {.nrodoc = ruc, .idEmpresa = Gempresas.IdEmpresaRuc})
    '        If objEntidad Is Nothing Then
    '            'VALIDANDO RUC EN LA SUNAT
    '            Dim company = CType(Await SoftPackERP_Sunat.GetRucContribuyenteSPK.GetContribuyente(ruc), SoftPackERP_Sunat.CompanyJuridico)
    '            Dim idEntidad = GuardarEntidad(company.RazonSocial, company.Ruc, company.DomicilioFiscal, "RUC")
    '            TXTcOMPRADOR.Tag = idEntidad
    '            txtruc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
    '            TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
    '            GetBeneficios()
    '        Else
    '            TXTcOMPRADOR.Tag = objEntidad.idEntidad
    '            txtruc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
    '            TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
    '            GetBeneficios()
    '        End If
    '        '---------------------------------------------------------------------------------------------------------------

    '        'If company IsNot Nothing Then
    '        '    'If company.ContribuyenteTipo = "PERSONA NATURAL SIN NEGOCIO" Then
    '        '    '    'rbNatural.Checked = True
    '        '    '    cboTipoDoc.Text = "FACTURA ELEC"
    '        '    'End If
    '        '    entidadBE.idEmpresa = Gempresas.IdEmpresaRuc
    '        '    entidadBE.nrodoc = txtruc.Text


    '        '    TXTcOMPRADOR.Text = company.RazonSocial


    '        '    PanelLoading.Visible = False
    '        '    ProgressBar4.Visible = False
    '        '    'LinkLabel1.Enabled = True
    '        'Else
    '        '    PanelLoading.Visible = False
    '        '    ProgressBar4.Visible = False
    '        '    'LinkLabel1.Enabled = True
    '        'End If
    '    ElseIf nroDoc = "2" Then
    '        Dim company = CType(Await SoftPackERP_Sunat.GetRucContribuyenteSPK.GetContribuyente(ruc), SoftPackERP_Sunat.CompanyJuridico)
    '        objEntidad = entidadSA.UbicarClienteXID(entidadBE)
    '        If company IsNot Nothing Then
    '            'If company.ContribuyenteTipo = "SOCIEDAD ANONIMA CERRADA" Then
    '            'rbJuridico.Checked = True
    '            'cboTipoDoc.Text = "RUC"
    '            '  End If

    '            entidadBE.idEmpresa = Gempresas.IdEmpresaRuc
    '            entidadBE.nrodoc = txtruc.Text


    '            TXTcOMPRADOR.Text = company.RazonSocial
    '            If (IsNothing(objEntidad)) Then
    '                Dim idEntidad = GuardarEntidad(company.RazonSocial, company.Ruc, company.DomicilioFiscal, "RUC")
    '                TXTcOMPRADOR.Tag = idEntidad
    '                txtruc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
    '                TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
    '                GetBeneficios()
    '            Else
    '                TXTcOMPRADOR.Tag = objEntidad.idEntidad
    '                txtruc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
    '                TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
    '                GetBeneficios()
    '            End If

    '            'Dim idEntidad = GuardarEntidad(company.RazonSocial, company.Ruc, company.DomicilioFiscal, "RUC")
    '            'TXTcOMPRADOR.Tag = idEntidad
    '            'TXTcOMPRADOR.Text = company.RazonSocial
    '            'txtruc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
    '            'TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)

    '            'txtContacto.Text = company.RazonSocial
    '            'lblStatus.Text = company.ContribuyenteEstado
    '            'txtDir.Text = company.DomicilioFiscal
    '            'txtDocProveedor.Text = company.Ruc
    '            'If company.RepresentanteLegal IsNot Nothing Then
    '            '    If company.RepresentanteLegal.Dni41094462 IsNot Nothing Then
    '            '        With company.RepresentanteLegal.Dni41094462
    '            '            txtContacto.Text = String.Format("{0}/{1}/{2}", .Cargo, .Nombre, .Desde)
    '            '        End With
    '            '    End If
    '            'End If

    '            'LinkLabel1.Enabled = True
    '        Else

    '            'LinkLabel1.Enabled = True
    '        End If
    '    End If

    'End Sub

    Private Sub GetBeneficios()
        'ListaBeneficios = New List(Of Business.Entity.beneficio)
        'ListaBeneficios = beneficioSA.BeneficioListaClienteProductions(New Business.Entity.beneficio With {.idCliente = Integer.Parse(TXTcOMPRADOR.Tag)})

        'If ListaBeneficios.Count > 0 Then
        '    formventa.TotalesColumnaDescuentos(ListaBeneficios)
        'Else
        '    formventa.TotalesColumnaDescuentos(ListaBeneficios)
        'End If

        ' CalculosMontos()
        PagoDirectoCheck()
        'Me.dgvCuentas.Table.Records.DeleteAll()
        'Me.dgvCuentas.Table.AddNewRecord.SetCurrent()
        'Me.dgvCuentas.Table.AddNewRecord.BeginEdit()
        'Me.dgvCuentas.Table.CurrentRecord.SetValue("tipo", Nothing) '0
        'Me.dgvCuentas.Table.CurrentRecord.SetValue("identidad", cbocajaPago.SelectedValue)
        'Me.dgvCuentas.Table.CurrentRecord.SetValue("entidad", cbocajaPago.Text)
        'Me.dgvCuentas.Table.CurrentRecord.SetValue("abonado", CDec(txtTotalPagar.Text))
        'Me.dgvCuentas.Table.CurrentRecord.SetValue("tipocambio", TmpTipoCambio)
        'Me.dgvCuentas.Table.CurrentRecord.SetValue("idforma", Nothing)
        'Me.dgvCuentas.Table.CurrentRecord.SetValue("formaPago", "CUENTA EFECTIVO")
        'Me.dgvCuentas.Table.AddNewRecord.EndEdit()
    End Sub

    'Private Sub GetConsultarDNIReniec(Dni As String)
    '    Dim CLIENTE As New WebClient
    '    Dim PAGINA As Stream = CLIENTE.OpenRead("http://aplicaciones007.jne.gob.pe/srop_publico/Consulta/Afiliado/GetNombresCiudadano?DNI=" & Dni)
    '    Dim LECTOR As New StreamReader(PAGINA)
    '    Dim MIHTML As String = LECTOR.ReadToEnd
    '    Dim entidadBE As New entidad
    '    Dim objEntidad As New entidad

    '    TXTcOMPRADOR.Text = MIHTML.Replace("|", Space(1))

    '    If (TXTcOMPRADOR.Text.Length > 0) Then

    '        If (TXTcOMPRADOR.Text = "   DNI NO ENCONTRADO EN PADRÓN ELECTORAL ") Then
    '            txtruc.ForeColor = Color.FromKnownColor(KnownColor.Black)
    '            TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.Black)
    '        Else

    '            entidadBE.idEmpresa = Gempresas.IdEmpresaRuc
    '            entidadBE.nrodoc = txtruc.Text

    '            objEntidad = entidadSA.UbicarClienteXID(entidadBE)

    '            If (IsNothing(objEntidad)) Then
    '                Dim idEntidad = GuardarEntidad(TXTcOMPRADOR.Text, txtruc.Text, String.Empty, "DNI")
    '                TXTcOMPRADOR.Tag = idEntidad
    '                GetBeneficios()
    '            Else
    '                TXTcOMPRADOR.Tag = objEntidad.idEntidad
    '                GetBeneficios()
    '            End If
    '            txtruc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
    '            TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
    '        End If
    '    End If

    'End Sub

    'Public Shared Function ValidationRUC(ByVal ruc As String) As Boolean

    '    If ruc.Length <> 11 Then
    '        MessageBox.Show("NUMERO DE DIGITOS INVALIDO!!!.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        Return False
    '    End If

    '    Dim dig01 As Integer = Convert.ToInt32(ruc.Substring(0, 1)) * 5
    '    Dim dig02 As Integer = Convert.ToInt32(ruc.Substring(1, 1)) * 4
    '    Dim dig03 As Integer = Convert.ToInt32(ruc.Substring(2, 1)) * 3
    '    Dim dig04 As Integer = Convert.ToInt32(ruc.Substring(3, 1)) * 2
    '    Dim dig05 As Integer = Convert.ToInt32(ruc.Substring(4, 1)) * 7
    '    Dim dig06 As Integer = Convert.ToInt32(ruc.Substring(5, 1)) * 6
    '    Dim dig07 As Integer = Convert.ToInt32(ruc.Substring(6, 1)) * 5
    '    Dim dig08 As Integer = Convert.ToInt32(ruc.Substring(7, 1)) * 4
    '    Dim dig09 As Integer = Convert.ToInt32(ruc.Substring(8, 1)) * 3
    '    Dim dig10 As Integer = Convert.ToInt32(ruc.Substring(9, 1)) * 2
    '    Dim dig11 As Integer = Convert.ToInt32(ruc.Substring(10, 1))
    '    Dim suma As Integer = dig01 + dig02 + dig03 + dig04 + dig05 + dig06 + dig07 + dig08 + dig09 + dig10
    '    Dim residuo As Integer = suma Mod 11
    '    Dim resta As Integer = 11 - residuo
    '    Dim digChk As Integer = 0

    '    If resta = 10 Then
    '        digChk = 0
    '    ElseIf resta = 11 Then
    '        digChk = 1
    '    Else
    '        digChk = resta
    '    End If

    '    If dig11 = digChk Then
    '        Return True
    '    Else
    '        MessageBox.Show("NUMERO DE RUC INVALIDO!!!.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        Return False
    '    End If
    'End Function

    Public Property msj As String
    Public Property SelRazon As entidad

    Public Function ValidationRUC(ruc As String) As Boolean
        msj = String.Empty

        If ruc.Length <> 11 Then
            msj = "NUMERO DE DIGITOS INVALIDO!!!."
            Return False

        End If

        Dim dig01 As Integer = Convert.ToInt32(ruc.Substring(0, 1)) * 5
        Dim dig02 As Integer = Convert.ToInt32(ruc.Substring(1, 1)) * 4
        Dim dig03 As Integer = Convert.ToInt32(ruc.Substring(2, 1)) * 3
        Dim dig04 As Integer = Convert.ToInt32(ruc.Substring(3, 1)) * 2
        Dim dig05 As Integer = Convert.ToInt32(ruc.Substring(4, 1)) * 7
        Dim dig06 As Integer = Convert.ToInt32(ruc.Substring(5, 1)) * 6
        Dim dig07 As Integer = Convert.ToInt32(ruc.Substring(6, 1)) * 5
        Dim dig08 As Integer = Convert.ToInt32(ruc.Substring(7, 1)) * 4
        Dim dig09 As Integer = Convert.ToInt32(ruc.Substring(8, 1)) * 3
        Dim dig10 As Integer = Convert.ToInt32(ruc.Substring(9, 1)) * 2
        Dim dig11 As Integer = Convert.ToInt32(ruc.Substring(10, 1))
        Dim suma As Integer = dig01 + dig02 + dig03 + dig04 + dig05 + dig06 + dig07 + dig08 + dig09 + dig10
        Dim residuo As Integer = suma Mod 11
        Dim resta As Integer = 11 - residuo
        Dim digChk As Integer = 0
        If resta = 10 Then
            digChk = 0

        ElseIf resta = 11 Then
            digChk = 1

        Else
            digChk = resta
        End If


        If dig11 = digChk Then
            msj = "NUMERO DE RUC VALIDO!!!."
            Return True

        Else
            msj = "NUMERO DE RUC INVALIDO!!!."
            Return False

        End If

        msj = "NUMERO DE RUC VALIDO!!!."
    End Function

    Private Sub chCredito_OnChange(sender As Object, e As EventArgs) Handles chCredito.OnChange
        If chCredito.Checked = True Then
            chCredito.Checked = True
            LblPagoCredito.Visible = True
            chCobranzaParcial.Checked = False
            ChPagoAvanzado.Checked = False
            ErrorProvider1.Clear()
            ValidacionCredito()
        Else
            chCredito.Checked = True
            LblPagoCredito.Visible = True
        End If
    End Sub

    Private Sub FormConfirmaVenta_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Dispose()
        ElseIf (e.KeyCode = Keys.F10) Then
            Me.Close()
        End If
    End Sub

    Private Sub GetMappingColumnsGrid()
        Dim dt As New DataTable
        Dim SA As New EstadosFinancierosConfiguracionPagosSA
        With dt
            .Columns.Add("tipo")
            .Columns.Add("identidad")
            .Columns.Add("entidad")
            .Columns.Add("abonado")
            .Columns.Add("tipocambio")
            .Columns.Add("idforma")
            .Columns.Add("formaPago")
            .Columns.Add("nrooperacion")
            .Columns.Add("moneda")
            .Columns.Add("abonadoME")
        End With

        Dim usuariocaja = ListaCajasActivas.Where(Function(o) o.idPersona = usuario.IDUsuario).FirstOrDefault

        If usuariocaja IsNot Nothing Then
            Dim listaCuentas = SA.GetConfigurationPayCaja(New estadosFinancierosConfiguracionPagos With
                                                 {
                                                 .idEmpresa = Gempresas.IdEmpresaRuc,
                                                 .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                 .IDCaja = usuariocaja.idcajaUsuario
                                                 })



            For Each i In listaCuentas.Where(Function(o) o.tipo <> "EE").ToList ' ListaCuentasFinancierasConfiguradas.Where(Function(o) o.IDFormaPago <> "9991").ToList
                If CheckEfectivoDefault.Checked = True Then

                    If i.FormaPago = "EFECTIVO" And txtTotalPagar.DecimalValue > 0 Then

                        If DocumentoVenta.moneda = "1" Then
                            dt.Rows.Add(String.Empty, i.identidad, i.entidad, If(i.moneda = "1", txtTotalPagar.DecimalValue, 0), TmpTipoCambio, i.IDFormaPago, i.FormaPago, "-", i.moneda, 0)
                        Else
                            dt.Rows.Add(String.Empty, i.identidad, i.entidad, 0, TmpTipoCambio, i.IDFormaPago, i.FormaPago, "-", i.moneda, 0)
                        End If
                    Else
                        dt.Rows.Add(String.Empty, i.identidad, i.entidad, 0.0, TmpTipoCambio, i.IDFormaPago, i.FormaPago, "-", i.moneda, 0)
                    End If
                Else
                    dt.Rows.Add(String.Empty, i.identidad, i.entidad, 0.0, TmpTipoCambio, i.IDFormaPago, i.FormaPago, "-", i.moneda, 0)
                End If
            Next



            If ListaCuentasFinancierasConfiguradas.Count > 0 Then
                Dim cuponSel = ListaCuentasFinancierasConfiguradas.Where(Function(o) o.IDFormaPago = "9991").SingleOrDefault
                PanelCupon.Tag = cuponSel
                TextCodigoCupon.Visible = True
                ButtonAdv4.Visible = True
            End If


            dgvCuentas.DataSource = dt
            '  lblPagoVenta.Text = CDec(txtTotalPagar.Text)
            LblPagoCredito.Visible = True
            lblPagoVenta.Visible = True

            Dim pagos As Decimal = SumaPagos()
            LblPagoCredito.Text = "SALDO POR COBRAR"
            lblPagoVenta.Text = CDec(txtTotalPagar.Text) - CDec(SumaPagos())
        End If
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        GetMappingColumnsGrid()
    End Sub

    Private Sub txtruc_TextChanged(sender As Object, e As EventArgs)
        'If (txtruc.Text.Length <> 8 Or txtruc.Text.Length <> 11) Then
        '    If (txtruc.Text.Length > 0) Then
        '        TXTcOMPRADOR.Clear()
        '    End If
        'End If
    End Sub

    'Private Function FValidarRuc(ByVal ruc As String) As Int16
    '    Dim nroRUC As String = String.Empty
    '    Dim valor As Int16
    '    Dim valorB As Decimal
    '    nroRUC = ruc
    '    valor = (nroRUC.Substring(0, 1) * 5) +
    '    (nroRUC.Substring(1, 1) * 4) +
    '    (nroRUC.Substring(2, 1) * 3) +
    '    (nroRUC.Substring(3, 1) * 2) +
    '    (nroRUC.Substring(4, 1) * 7) +
    '    (nroRUC.Substring(5, 1) * 6) +
    '    (nroRUC.Substring(6, 1) * 5) +
    '    (nroRUC.Substring(7, 1) * 4) +
    '    (nroRUC.Substring(8, 1) * 3) +
    '    (nroRUC.Substring(9, 1) * 2)
    '    valorB = Int((valor / 11))
    '    valor = valor - (valorB * 11)
    '    valor = 11 - valor
    '    IIf(valor = 10, valor = 0, IIf(valor = 11, valor = 1, valor))
    '    If ruc.Substring(10, 1) <> valor Then : Return 0 : Else : Return 1 : End If
    'End Function
    Private Function SumaPagos() As Decimal
        SumaPagos = 0
        Dim pagoCupones As Decimal = 0
        Dim pagoAnticipos As Decimal = 0
        For Each i In dgvCuentas.Table.Records
            'If i.GetValue("abonado") <= 0 Then
            '    Throw New Exception("El monto abonado debe sre mayor a cero")
            'End If
            SumaPagos += CDec(i.GetValue("abonado"))
        Next
        pagoCupones = TextCuponImporte.DecimalValue
        pagoAnticipos = TextValoranticipo.DecimalValue
        SumaPagos = SumaPagos + pagoCupones + pagoAnticipos
        Return SumaPagos
    End Function

    Private Function GetPagos() As List(Of documentoCaja)
        GetPagos = New List(Of documentoCaja)
        For Each r As Record In dgvCuentas.Table.Records
            If CDec(r.GetValue("abonado")) <= 0 Then
                Throw New Exception("Debe indicar un importe mayor a cero")
            End If

            GetPagos.Add(New documentoCaja With
                         {
                            .IdEntidadFinanciera = Integer.Parse(r.GetValue("identidad").ToString()),
                            .NomCajaOrigen = r.GetValue("entidad"),
                            .montoSoles = Decimal.Parse(r.GetValue("abonado")),
                            .formapago = r.GetValue("idforma")
                         })
        Next
    End Function
    Public Function SumaPagosME() As Decimal
        SumaPagosME = 0
        For Each i In dgvCuentas.Table.Records
            'If i.GetValue("moneda") = "2" Then
            SumaPagosME += CDec(i.GetValue("abonadoME"))
            ' End If
        Next
        SumaPagosME = SumaPagosME
        '  TextPagadoME.DecimalValue = SumaPagosME
        Return SumaPagosME
    End Function
    Private Sub dgvCuentas_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvCuentas.TableControlCurrentCellEditingComplete
        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        'Try
        '    Select Case ColIndex
        '        Case 3 'PAGOS SOLES
        '            Dim pagos As Decimal = SumaPagos()

        '            LblPagoCredito.Text = "SALDO POR COBRAR"

        '            lblPagoVenta.Text = CDec(txtTotalPagar.Text) - CDec(SumaPagos())

        '            If (lblPagoVenta.Text = CDec(0.0)) Then
        '                ErrorProvider1.Clear()
        '            End If

        '            If pagos > CDec(txtTotalPagar.Text) Then
        '                MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '                dgvCuentas.Table.CurrentRecord.SetValue("abonado", 0)
        '                Exit Sub
        '            End If
        '    End Select
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Verificar montos del pago")
        'End Try



        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Try
            ' Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
            Dim cc As GridCurrentCell = dgvCuentas.TableControl.CurrentCell
            cc.ConfirmChanges()
            If cc.Renderer IsNot Nothing Then

                If cc.ColIndex > -1 Then
                    Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

                    If style.TableCellIdentity.Column.Name = "abonado" Then
                        Dim pagos As Decimal = 0
                        Select Case DocumentoVenta.moneda
                            Case "2"
                                Dim tipocambio = CDec(style.TableCellIdentity.Table.CurrentRecord.GetValue("tipocambio"))
                                Dim pagoCelSoles As Decimal = Math.Round(CDec(style.TableCellIdentity.Table.CurrentRecord.GetValue("abonado")) / tipocambio, 2)
                                style.TableCellIdentity.Table.CurrentRecord.SetValue("abonadoME", pagoCelSoles)

                                pagos = SumaPagosME()

                                lblPagoVenta.Text = CDec(txtTotalPagar.Text) - CDec(SumaPagosME())

                                If (lblPagoVenta.Text = CDec(0.0)) Then
                                    ErrorProvider1.Clear()
                                End If

                                If pagos > CDec(DocumentoVenta.ImporteExtranjero) Then
                                    MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    dgvCuentas.Table.CurrentRecord.SetValue("abonado", 0)
                                    dgvCuentas.Table.CurrentRecord.SetValue("abonadoME", 0)
                                    '  TextSaldo.DecimalValue = TextCompraTotal.DecimalValue - pagos
                                    Exit Sub
                                End If

                            Case "1"

                                '  TextSaldo.DecimalValue = TextCompraTotal.DecimalValue - pagos
                                'style.TableCellIdentity.Table.CurrentRecord.SetValue("abonadoME", 0)

                                pagos = SumaPagos()

                                lblPagoVenta.Text = CDec(txtTotalPagar.Text) - CDec(pagos)
                                If pagos > DocumentoVenta.ImporteNacional Then
                                    MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    dgvCuentas.Table.CurrentRecord.SetValue("abonado", 0)
                                    dgvCuentas.Table.CurrentRecord.SetValue("abonadoME", 0)
                                    'TextSaldo.DecimalValue = TextCompraTotal.DecimalValue - pagos
                                    Exit Sub
                                End If
                        End Select




                        ' style.TableCellIdentity.Table.CurrentRecord.SetValue("tipocambio", 0)


                    ElseIf style.TableCellIdentity.Column.Name = "abonadoME" Then

                        If style.TableCellIdentity.Table.CurrentRecord IsNot Nothing Then
                            Dim pagos As Decimal = 0 'SumaPagosME()

                            Dim tipocambio = CDec(style.TableCellIdentity.Table.CurrentRecord.GetValue("tipocambio"))
                            Dim pagoCelSoles As Decimal = Math.Round(CDec(style.TableCellIdentity.Table.CurrentRecord.GetValue("abonadoME")) * tipocambio, 2)
                            style.TableCellIdentity.Table.CurrentRecord.SetValue("abonado", pagoCelSoles)

                            Select Case DocumentoVenta.moneda
                                Case "2"
                                    pagos = SumaPagosME()

                                    lblPagoVenta.Text = CDec(txtTotalPagar.Text) - CDec(pagos)


                                    If pagos > DocumentoVenta.ImporteExtranjero Then
                                        MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                        dgvCuentas.Table.CurrentRecord.SetValue("abonadoME", 0)
                                        dgvCuentas.Table.CurrentRecord.SetValue("abonado", 0)
                                        '  TextSaldo.DecimalValue = TextCompraTotal.DecimalValue '- CDec(SumaPagosME())
                                        Exit Sub
                                    End If
                                Case "1"
                                    pagos = SumaPagos()

                                    lblPagoVenta.Text = CDec(txtTotalPagar.Text) - CDec(pagos)


                                    If pagos > DocumentoVenta.ImporteNacional Then
                                        MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                        dgvCuentas.Table.CurrentRecord.SetValue("abonadoME", 0)
                                        dgvCuentas.Table.CurrentRecord.SetValue("abonado", 0)
                                        '  TextSaldo.DecimalValue = TextCompraTotal.DecimalValue '- CDec(SumaPagosME())
                                        Exit Sub
                                    End If
                            End Select
                        End If

                        'TextSaldo.DecimalValue = TextCompraTotal.DecimalValue '- CDec(SumaPagosME())

                    ElseIf style.TableCellIdentity.Column.Name = "tipocambio" Then
                        Dim pagos As Decimal = 0
                        'Dim style As GridTableCellStyleInfo = e.TableControl.Model(cc.RowIndex, cc.ColIndex)
                        If style.TableCellIdentity.Table.CurrentRecord Is Nothing Then Exit Sub
                        Dim r = style.TableCellIdentity.Table.CurrentRecord
                        Select Case r.GetValue("moneda")
                            Case 1
                                Dim valorSoles = CDec(r.GetValue("abonado"))
                                Dim valorTipoCambio As Decimal = cc.Renderer.ControlText
                                Dim valorDolares = 0 ' 
                                If valorTipoCambio > 0 Then
                                    valorDolares = Math.Round(valorSoles / valorTipoCambio, 2)
                                Else
                                    valorDolares = 0
                                End If
                                r.SetValue("abonadoME", valorDolares)

                                Select Case DocumentoVenta.moneda
                                    Case "2"
                                        pagos = SumaPagosME()

                                        If pagos > CDec(DocumentoVenta.ImporteExtranjero) Then
                                            MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                            dgvCuentas.Table.CurrentRecord.SetValue("abonadoME", 0)
                                            dgvCuentas.Table.CurrentRecord.SetValue("abonado", 0)
                                            dgvCuentas.Table.CurrentRecord.SetValue("tipocambio", 0)
                                            Exit Sub
                                        End If

                                    Case "1"
                                        pagos = SumaPagos()

                                        If pagos > CDec(DocumentoVenta.ImporteNacional) Then
                                            MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                            dgvCuentas.Table.CurrentRecord.SetValue("abonadoME", 0)
                                            dgvCuentas.Table.CurrentRecord.SetValue("abonado", 0)
                                            dgvCuentas.Table.CurrentRecord.SetValue("tipocambio", 0)
                                            Exit Sub
                                        End If
                                End Select

                            Case 2
                                Dim valorDolares = CDec(r.GetValue("abonadoME"))
                                Dim valorTipoCambio As Decimal = cc.Renderer.ControlText
                                Dim valorSoles As Decimal = 0

                                If valorTipoCambio > 0 Then
                                    valorSoles = Math.Round(valorDolares * valorTipoCambio, 2)
                                    r.SetValue("abonado", valorSoles)
                                Else
                                    valorSoles = 0
                                    r.SetValue("abonado", valorSoles)
                                End If

                                Select Case DocumentoVenta.moneda
                                    Case "2"
                                        pagos = SumaPagosME()

                                        If pagos > CDec(DocumentoVenta.ImporteExtranjero) Then
                                            MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                            dgvCuentas.Table.CurrentRecord.SetValue("abonadoME", 0)
                                            dgvCuentas.Table.CurrentRecord.SetValue("abonado", 0)
                                            dgvCuentas.Table.CurrentRecord.SetValue("tipocambio", 0)
                                            Exit Sub
                                        End If

                                    Case "1"
                                        pagos = SumaPagos()

                                        If pagos > CDec(DocumentoVenta.ImporteNacional) Then
                                            MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                            dgvCuentas.Table.CurrentRecord.SetValue("abonadoME", 0)
                                            dgvCuentas.Table.CurrentRecord.SetValue("abonado", 0)
                                            dgvCuentas.Table.CurrentRecord.SetValue("tipocambio", 0)
                                            Exit Sub
                                        End If
                                End Select

                        End Select

                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Verificar montos del pago")
        End Try
    End Sub

    Private Sub btnCliente_Click(sender As Object, e As EventArgs) Handles btnCliente.Click
        GrabarEnFormBasico()
        'Me.Cursor = Cursors.WaitCursor

        'Dim f As New frmCrearENtidades
        'f.CaptionLabels(0).Text = "Nuevo cliente"
        'f.strTipo = TIPO_ENTIDAD.CLIENTE
        'f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        ''f.tipoPersona(TIPO_ENTIDAD.CLIENTE)
        'f.StartPosition = FormStartPosition.CenterParent
        'f.ShowDialog()
        'If Not IsNothing(f.Tag) Then
        '    Dim c = CType(f.Tag, entidad)
        '    listaClientes.Add(c)
        '    'txtTipoDocClie.Text = c.tipoDoc
        '    TextProveedor.Text = c.nombreCompleto
        '    TextNumIdentrazon.Text = c.nrodoc
        '    TextProveedor.Tag = c.idEntidad
        '    TextNumIdentrazon.Visible = True

        'End If
        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub chCobranzaParcial_OnChange(sender As Object, e As EventArgs) Handles chCobranzaParcial.OnChange
        If chCobranzaParcial.Checked = True Then
            chCobranzaParcial.Checked = True
            chCredito.Checked = False
            LblPagoCredito.Visible = False
            ChPagoAvanzado.Checked = False
            ErrorProvider1.Clear()
            GetMappingColumnsGrid()
        Else
            chCobranzaParcial.Checked = True
        End If
    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        GetUbicarCuponPorCodigo()
    End Sub

    Private Sub GetUbicarCuponPorCodigo()
        Dim beneficioSA As New beneficioSA

        Dim cupon = beneficioSA.BeneficioSelXID(New Business.Entity.beneficio With {.beneficio_id = TextCodigoCupon.Text})

        If cupon IsNot Nothing Then
            If cupon.estado = 1 Then
                TextCodigoCupon.Text = $"{"CPN"}-{cupon.beneficio_id}"
                TextCodigoCupon.Tag = cupon.beneficio_id
                TextCuponImporte.DecimalValue = cupon.valorConvertido.GetValueOrDefault
            Else
                MessageBox.Show("El cupon que quiere usar ya fue procesado, ingrese otro!", "Cupon verificar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            TextCodigoCupon.Text = String.Empty
            TextCodigoCupon.Tag = String.Empty
            TextCuponImporte.DecimalValue = 0
        End If
    End Sub

    Private Sub dgvCuentas_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCuentas.TableControlCellClick

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
        TextCuponImporte.DecimalValue = 0
        TextCodigoCupon.Tag = String.Empty
        TextCodigoCupon.Text = String.Empty
    End Sub

    'Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs)
    '    Try
    '        If BackgroundWorker1.CancellationPending Then
    '            ' MessageBox.Show("Up to here? ...")
    '            e.Cancel = True
    '        Else
    '            Dim strIdModulo As String = Nothing
    '            If cboTipoDoc.Text = "BOLETA" Then
    '                strIdModulo = "VT2"
    '            ElseIf cboTipoDoc.Text = "FACTURA" Then
    '                strIdModulo = "VT3"
    '            ElseIf cboTipoDoc.Text = "BOLETA" Then
    '                strIdModulo = "VT2E"
    '            ElseIf cboTipoDoc.Text = "FACTURA" Then
    '                strIdModulo = "VT3E"
    '            ElseIf cboTipoDoc.Text = "PROFORMA" Then
    '                strIdModulo = "COTIZACION"
    '            End If
    '            Dim strIDEmpresa = General.Gempresas.IdEmpresaRuc
    '            GetNumeracion(strIdModulo, strIDEmpresa)
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    'Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)
    '    If e.Cancelled Then

    '    Else
    '        txtSerie.Text = conf.Serie
    '        ProgressBar2.Visible = False
    '    End If
    'End Sub

    Sub Reinicarcarga()
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA
        Dim venta = DocumentoVentaSA.GetVentaID(New documento With {.idDocumento = DocumentoVenta.idDocumento})
        DocumentoVenta = venta
        btOperacion.Enabled = True
        CalculosMontos()
        cliventa = venta.CustomEntidad ' entidadSA.UbicarEntidadPorID(DocumentoVenta.idCliente).FirstOrDefault
        Getclientepedido()
        HabilitarPago(True)
    End Sub

    Private Sub ToolImportar_Click(sender As Object, e As EventArgs) Handles ToolImportar.Click
        PanelLoadingWaith.Controls.Clear()
        PanelLoadingWaith.Visible = True
        Dim entidadSA As New entidadSA
        Dim f As New FormCanastaPedidoDeVentas
        f.MaximizeBox = False

        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            DocumentoVenta = CType(f.Tag, documentoventaAbarrotes)
            btOperacion.Enabled = True
            CalculosMontos()
            cliventa = DocumentoVenta.CustomEntidad '  entidadSA.UbicarEntidadPorID(DocumentoVenta.idCliente).FirstOrDefault
            If cliventa.tipoEntidad = "VR" Then
                RadioButton2.Checked = True
            Else
                RadioButton1.Checked = True
            End If
            Getclientepedido()
            HabilitarPago(True)
            f.BringToFront()
        Else
            HabilitarPago(False)
            btOperacion.Enabled = False
            '    MessageBox.Show("Debe seleccionar una venta!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Sub Getclientepedido()
        Dim vendedor = UsuariosList.Where(Function(o) o.IDUsuario = DocumentoVenta.usuarioActualizacion).SingleOrDefault

        If vendedor IsNot Nothing Then
            TextCodigoVendedor.Text = vendedor.Full_Name
        End If

        TextComprador.Text = DocumentoVenta.nombrePedido
        Label15.Text = $"{"Pedido Nro:"} {DocumentoVenta.serieVenta}-{DocumentoVenta.numeroVenta}"
        Select Case DocumentoVenta.tipoDocumento
            Case "01"
                cboTipoDoc.Text = "FACTURA"
            Case "03"
                cboTipoDoc.Text = "BOLETA"
            Case "9907"
                cboTipoDoc.Text = "NOTA DE VENTA"
        End Select

        Select Case DocumentoVenta.moneda
            Case "1"
                cboMoneda.Text = "NACIONAL"
            Case Else
                cboMoneda.Text = "EXTRANJERA"
        End Select

        If cliventa IsNot Nothing Then
            TextNumIdentrazon.Text = cliventa.nrodoc
            TextProveedor.Text = cliventa.nombreCompleto
            TextProveedor.Tag = cliventa.idEntidad
            If RadioButton2.Checked Then
                TextProveedor.Text = DocumentoVenta.nombrePedido
            End If
        End If
        'VUELTO
        TextTotalPagosCliente.DecimalValue = 0
        'LabelTotalCobrarCliente.Text = "0.00"
        LabelVueltoCliente.Text = "0.00"
        '***********************************************
    End Sub


    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Try
            If TextProveedor.Tag IsNot Nothing Then
                If TextProveedor.Text.Trim.Length > 0 Then
                    'Dim f As New FormAntReclamacionesPendientes(New entidad With {
                    '                                            .idEntidad = Val(TextProveedor.Tag),
                    '                                            .nombreCompleto = TextProveedor.Text,
                    '                                            .nrodoc = TextNumIdentrazon.Text
                    '                                            })
                    'f.StartPosition = FormStartPosition.CenterParent
                    'f.ShowDialog(Me)
                    'pagoAnticipo = New documentoAnticipo
                    'If f.Tag IsNot Nothing Then
                    '    Dim anticipoSA As New documentoAnticipoSA
                    '    Dim codigoDoc = CType(f.Tag, Decimal)
                    '    pagoAnticipo = anticipoSA.GetANTReclamacionesXDocumento(New documentoventaAbarrotes With {.idDocumento = codigoDoc})

                    '    TextPagoAnticipoDisponible.DecimalValue = pagoAnticipo.SaldoReclamacion.GetValueOrDefault
                    '    TextValoranticipo.MaxValue = pagoAnticipo.SaldoReclamacion.GetValueOrDefault
                    '    TextValoranticipo.MinValue = 0
                    'End If
                Else
                    MessageBox.Show("Debe identificar un cliente válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TextValoranticipo_TextChanged(sender As Object, e As EventArgs) Handles TextValoranticipo.TextChanged
        'If TextValoranticipo.DecimalValue > 0 Then
        Try
            If TextPagoAnticipoDisponible.DecimalValue > 0 Then

                If txtTotalPagar.Text.Trim.Length > 0 Then
                    Dim pagos As Decimal = SumaPagos()

                    lblPagoVenta.Text = CDec(txtTotalPagar.Text) - CDec(SumaPagos()) - CDec(TextTotalDescuentos.DecimalValue)

                    If (lblPagoVenta.Text = CDec(0.0)) Then
                        ErrorProvider1.Clear()
                    End If

                    If pagos > CDec(txtTotalPagar.Text) Then
                        MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        dgvCuentas.Table.CurrentRecord.SetValue("abonado", 0)
                        Exit Sub
                    End If
                End If
            Else
                TextValoranticipo.DecimalValue = 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripLabel3_Click(sender As Object, e As EventArgs) Handles ToolStripLabel3.Click
        ChPagoAvanzado.Checked = True
        PagoDirectoCheck()
        btOperacion.Enabled = False
        TextCodigoVendedor.Clear()
        TextComprador.Clear()
        lblPagoVenta.Text = "0.00"
        txtTotalBase.DecimalValue = 0
        txtTotalBase2.DecimalValue = 0
        txtTotalBase3.DecimalValue = 0
        txtTotalIva.DecimalValue = 0
        TextTotalDescuentos.DecimalValue = 0
        txtTotalPagar.DecimalValue = 0
        LabelTotalCobrarCliente.Text = "0.00"
        GetUbicarClienteGeneral()

        chCredito.Checked = False
        LblPagoCredito.Visible = False
        chCobranzaParcial.Checked = False
        PanelCupon.Visible = False
        ErrorProvider1.Clear()
        GetMappingColumnsGrid()

        HabilitarPago(False)
    End Sub


    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolBuscarVenta.Click
        Dim f As New FormVentasCajero
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolCerracaja.Click
        Dim frm As MetroForm = Application.OpenForms.OfType(Of MetroForm)().Where(Function(pre) pre.Name = "frmTableroGeneral").SingleOrDefault
        If frm Is Nothing Then
            'TableroGeneral = New frmTableroGeneral
            'TableroGeneral.StartPosition = FormStartPosition.CenterScreen
            'TableroGeneral.Show(Me)
            frmInformacionFinanzas = New frmInformacionFinanzas
            frmInformacionFinanzas.StartPosition = FormStartPosition.CenterScreen
            frmInformacionFinanzas.ShowDialog(Me)
        Else
            frmInformacionFinanzas.WindowState = FormWindowState.Normal
            frmInformacionFinanzas.BringToFront()
        End If
    End Sub

    Private Sub ButtonAdv7_Click(sender As Object, e As EventArgs) Handles ButtonAdv7.Click
        Dim f As New FormCuentasCobrarPersona
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolSeguimientoCaja.Click
        PanelLoadingWaith.Visible = True
        PanelLoadingWaith.Controls.Clear()
        ToolEditPedido.Enabled = False
        HistorialCajasUsuario = New HistorialCajasUsuario With
        {
          .Dock = DockStyle.Fill
        }
        HistorialCajasUsuario.BringToFront()
        PanelLoadingWaith.Controls.Add(HistorialCajasUsuario)
    End Sub

    Private Sub PanelLoadingWaith_Paint(sender As Object, e As PaintEventArgs) Handles PanelLoadingWaith.Paint

    End Sub

    Private Sub ToolEditPedido_Click(sender As Object, e As EventArgs) Handles ToolEditPedido.Click
        'Dim f As New FormVentaModify(DocumentoVenta.idDocumento)
        'f.StartPosition = FormStartPosition.CenterParent
        'f.ShowDialog(Me)

        'PictureLoad.Visible = True
        'Dim r As Record = Me.dgPedidos.Table.CurrentRecord
        'If r IsNot Nothing Then
        btOperacion.Enabled = False
        Dim f As New FormVentaNueva(DocumentoVenta.idDocumento)
        f.ToolStrip1.Enabled = True
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        'End If
        'PictureLoad.Visible = False
        If f.Tag IsNot Nothing Then
            Dim c = CType(f.Tag, String)
            If c = "Grabado" Then
                Reinicarcarga()
            End If
        End If
        btOperacion.Enabled = True
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Cursor = Cursors.WaitCursor
        Dim FormCrearAnticipo As New FormCrearAnticipo()
        FormCrearAnticipo.StartPosition = FormStartPosition.CenterParent
        FormCrearAnticipo.ShowDialog(Me)
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv15_Click(sender As Object, e As EventArgs) Handles ButtonAdv15.Click
        Cursor = Cursors.WaitCursor
        If CuentasHabilitadas IsNot Nothing Then
            Dim f As New FormIngresoEspecial(CuentasHabilitadas)
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Cursor = Cursors.WaitCursor
        If DocumentoVenta IsNot Nothing Then
            Dim frmDetalleVentaView = New frmDetalleVentaView(DocumentoVenta)
            frmDetalleVentaView.CaptionLabels(1).Text = DocumentoVenta.nombrePedido
            frmDetalleVentaView.StartPosition = FormStartPosition.CenterParent
            frmDetalleVentaView.ShowDialog(Me)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv14_Click(sender As Object, e As EventArgs) Handles ButtonAdv14.Click
        'If CuentasHabilitadas IsNot Nothing Then
        '    Dim f As New FormEntregaArendir(CuentasHabilitadas)
        '    f.StartPosition = FormStartPosition.CenterParent
        '    f.ShowDialog(Me)
        'End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            TextNumIdentrazon.Enabled = False
            cboTipoDoc.Text = "BOLETA"
            TextNumIdentrazon.Text = VarClienteGeneral.idEntidad
            TextProveedor.Text = VarClienteGeneral.nombreCompleto
            TextProveedor.Tag = VarClienteGeneral.idEntidad
            TextProveedor.Enabled = True
            TextProveedor.Focus()
            TextProveedor.SelectAll()

        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            TextNumIdentrazon.Enabled = True
            TextNumIdentrazon.Clear()
            TextProveedor.Clear()
            TextProveedor.Enabled = False
            TextNumIdentrazon.Select()
        End If
    End Sub

    Private Sub TextNumIdentrazon_TextChanged(sender As Object, e As EventArgs) Handles TextNumIdentrazon.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextProveedor.Tag IsNot Nothing Then

            If Not TextProveedor.Tag = VarClienteGeneral.idEntidad Then

                Dim f As New frmCrearENtidades(CInt(TextProveedor.Tag))
                f.CaptionLabels(0).Text = "Editar Cliente"
                f.strTipo = TIPO_ENTIDAD.CLIENTE
                f.intIdEntidad = TextProveedor.Tag
                'f.UbicarEntidad(dgvProveedor.Table.CurrentRecord.GetValue("idEntidad"))
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()

                Dim cliente = entidadSA.UbicarEntidadPorID(CInt(TextProveedor.Tag)).FirstOrDefault

                If cliente IsNot Nothing Then
                    TextNumIdentrazon.Text = cliente.nrodoc
                    TextProveedor.Text = cliente.nombreCompleto
                    TextProveedor.Tag = cliente.idEntidad
                End If
            Else
                MessageBox.Show("Seleccione Solo RUC O DNI para editar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Debe seleccionar un cliente!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ComboCaja_Click(sender As Object, e As EventArgs) Handles ComboCaja.Click

    End Sub

    Private Sub ComboCaja_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboCaja.SelectedValueChanged
        Cursor = Cursors.WaitCursor
        If IsNumeric(ComboCaja.SelectedValue) Then
            GetInicioCuentas(Integer.Parse(ComboCaja.SelectedValue))
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub dgvCuentas_TableControlKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles dgvCuentas.TableControlKeyDown
        'Try
        '    Dim cc As GridCurrentCell = dgvCuentas.TableControl.CurrentCell
        '    If cc.RowIndex > -1 Then
        '        If e.Inner.KeyCode = Keys.Up Then
        '            If cc IsNot Nothing Then
        '                cc.ConfirmChanges()
        '                If cc.RowIndex = 2 Then
        '                    Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(cc.RowIndex, cc.ColIndex), GridTableCellStyleInfo)
        '                    Dim currenrecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
        '                    Dim idProducto As Decimal = Decimal.Parse(currenrecord.GetValue("abonado"))



        '                    Dim pagos As Decimal = SumaPagos()

        '                    LblPagoCredito.Text = "SALDO POR COBRAR"

        '                    lblPagoVenta.Text = CDec(txtTotalPagar.Text) - CDec(SumaPagos())

        '                    If (lblPagoVenta.Text = CDec(0.0)) Then
        '                        ErrorProvider1.Clear()
        '                    End If

        '                    If pagos > CDec(txtTotalPagar.Text) Then
        '                        cc.Renderer.ControlText = 0
        '                        cc.Renderer.ControlValue = 0
        '                        MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '                        'dgvCuentas.Table.CurrentRecord.SetValue("abonado", 0)
        '                        Exit Sub
        '                    End If


        '                Else
        '                    Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(cc.RowIndex, cc.ColIndex), GridTableCellStyleInfo)
        '                    Dim currenrecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
        '                    Dim idProducto As Decimal = Decimal.Parse(currenrecord.GetValue("abonado"))


        '                    Dim pagos As Decimal = SumaPagos()

        '                    LblPagoCredito.Text = "SALDO POR COBRAR"

        '                    lblPagoVenta.Text = CDec(txtTotalPagar.Text) - CDec(SumaPagos())

        '                    If (lblPagoVenta.Text = CDec(0.0)) Then
        '                        ErrorProvider1.Clear()
        '                    End If

        '                    If pagos > CDec(txtTotalPagar.Text) Then
        '                        cc.Renderer.ControlText = 0
        '                        cc.Renderer.ControlValue = 0
        '                        MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '                        'dgvCuentas.Table.CurrentRecord.SetValue("abonado", 0)
        '                        Exit Sub
        '                    End If

        '                    'TextSaldo.DecimalValue = TextCompraTotal.DecimalValue - CDec(SumaPagos())

        '                    'If pagos > TextCompraTotal.DecimalValue Then
        '                    '    currenrecord.SetValue("monto", 0)
        '                    '    MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        '                    '    TextSaldo.DecimalValue = TextCompraTotal.DecimalValue - CDec(SumaPagos())
        '                    '    Exit Sub
        '                    'End If
        '                End If

        '            End If
        '        ElseIf e.Inner.KeyCode = Keys.Down Then
        '            If cc IsNot Nothing Then
        '                cc.ConfirmChanges()
        '                Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(cc.RowIndex, cc.ColIndex), GridTableCellStyleInfo)
        '                If style IsNot Nothing Then
        '                    ' Dim rows = dgvCompra.Table.Records.Count
        '                    If style.TableCellIdentity IsNot Nothing Then
        '                        Dim currenrecord = style.TableCellIdentity.DisplayElement.GetRecord()
        '                        If currenrecord IsNot Nothing Then
        '                            Dim idProducto As Decimal = Decimal.Parse(currenrecord.GetValue("abonado"))

        '                            'currenrecord.SetValue("monto", 0)

        '                            Dim pagos As Decimal = SumaPagos()

        '                            LblPagoCredito.Text = "SALDO POR COBRAR"

        '                            lblPagoVenta.Text = CDec(txtTotalPagar.Text) - CDec(SumaPagos())

        '                            If (lblPagoVenta.Text = CDec(0.0)) Then
        '                                ErrorProvider1.Clear()
        '                            End If

        '                            If pagos > CDec(txtTotalPagar.Text) Then
        '                                cc.Renderer.ControlText = 0
        '                                cc.Renderer.ControlValue = 0
        '                                MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '                                'dgvCuentas.Table.CurrentRecord.SetValue("abonado", 0)
        '                                Exit Sub
        '                            End If
        '                        End If
        '                    End If

        '                End If

        '            End If

        '        Else
        '            cc.ConfirmChanges()
        '            Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(cc.RowIndex, cc.ColIndex), GridTableCellStyleInfo)
        '            Dim currenrecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
        '            Dim idProducto As Decimal = Decimal.Parse(currenrecord.GetValue("abonado"))

        '            Dim pagos As Decimal = SumaPagos()

        '            LblPagoCredito.Text = "SALDO POR COBRAR"

        '            lblPagoVenta.Text = CDec(txtTotalPagar.Text) - CDec(SumaPagos())

        '            If (lblPagoVenta.Text = CDec(0.0)) Then
        '                ErrorProvider1.Clear()
        '            End If

        '            If pagos > CDec(txtTotalPagar.Text) Then
        '                cc.Renderer.ControlText = 0
        '                cc.Renderer.ControlValue = 0
        '                MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '                'dgvCuentas.Table.CurrentRecord.SetValue("abonado", 0)
        '                Exit Sub
        '            End If


        '            'Dim pagos As Decimal = SumaPagos()

        '            'TextSaldo.DecimalValue = TextCompraTotal.DecimalValue - CDec(SumaPagos())

        '            'If pagos > TextCompraTotal.DecimalValue Then

        '            '    MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        '            '    TextSaldo.DecimalValue = TextCompraTotal.DecimalValue - CDec(SumaPagos())
        '            '    Exit Sub
        '            'End If
        '        End If
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub

    Private Sub GradientPanel20_Paint(sender As Object, e As PaintEventArgs) Handles GradientPanel20.Paint

    End Sub

    Private Sub TextTotalPagosCliente_TextChanged(sender As Object, e As EventArgs) Handles TextTotalPagosCliente.TextChanged
        If TextTotalPagosCliente.DecimalValue > 0 Then
            CalcularPagoDelCliente()
        Else
            LabelVueltoCliente.Text = "0.00"
        End If
    End Sub

    Private Sub CalcularPagoDelCliente()
        Dim totalPago As Decimal = TextTotalPagosCliente.DecimalValue
        Dim totalVenta As Decimal = txtTotalPagar.DecimalValue

        If totalVenta > totalPago Then
            LabelVueltoCliente.Text = "0.00"
            Exit Sub
        End If
        Dim vuelto As Decimal = totalPago - totalVenta
        LabelVueltoCliente.Text = vuelto.ToString("N2")
    End Sub

    Private Sub dgvCuentas_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvCuentas.QueryCellStyleInfo
        If Not IsNothing(e.TableCellIdentity.Column) Then
            Dim el As Syncfusion.Grouping.Element = e.TableCellIdentity.DisplayElement


            If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "abonado")) Then
                Dim moneda As String = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("moneda").ToString()

                If moneda IsNot Nothing Then
                    Select Case moneda
                        Case "1"
                            'e.Style.BackColor = Color.Yellow
                            'e.Style.TextColor = Color.Black
                            e.Style.ReadOnly = False
                            e.Style.BackColor = Color.FromArgb(255, 255, 128)
                        Case Else
                            e.Style.ReadOnly = True
                            e.Style.BackColor = Color.White
                    End Select
                End If

            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "abonadoME")) Then
                Dim moneda As String = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("moneda").ToString()

                If moneda IsNot Nothing Then
                    Select Case moneda
                        Case "2"
                            'e.Style.BackColor = Color.Yellow
                            'e.Style.TextColor = Color.Black
                            e.Style.ReadOnly = False
                            e.Style.BackColor = Color.FromArgb(255, 255, 128)
                        Case Else
                            e.Style.ReadOnly = True
                            e.Style.BackColor = Color.White
                    End Select
                End If
            End If
        End If
    End Sub

    Private Sub BgProveedor_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BgProveedor.DoWork
        GetConsultaSunatThread(TextNumIdentrazon.Text)
    End Sub

    Private Sub BgProveedor_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BgProveedor.RunWorkerCompleted
        If SelRazon.nrodoc IsNot Nothing Then
            SelRazon.tipoEntidad = "CL"
            SelRazon.nombreCompleto = SelRazon.nombreCompleto.ToString.Replace(Chr(34), "")
            GrabarEntidadRapidaThread()
            TextNumIdentrazon.Text = SelRazon.nrodoc
            TextProveedor.Text = SelRazon.nombreCompleto
            TextNumIdentrazon.ReadOnly = False
            SelRazon = New entidad

        Else
            TextProveedor.Clear()
            TextProveedor.Tag = Nothing
            TextNumIdentrazon.ReadOnly = False
            SelRazon = New entidad
            TextNumIdentrazon.Select()
        End If
        PictureLoad.Visible = False
    End Sub

    Private Sub GrabarEntidadRapidaThread()
        Dim obEntidad As New entidad
        Dim entidadSA As New entidadSA
        Try
            'Se asigna cada uno de los datos registrados
            obEntidad.idEmpresa = Gempresas.IdEmpresaRuc
            obEntidad.idOrganizacion = GEstableciento.IdEstablecimiento
            obEntidad.tipoEntidad = "CL"
            obEntidad.tipoDoc = SelRazon.tipoDoc
            obEntidad.tipoPersona = SelRazon.tipoPersona
            obEntidad.nrodoc = SelRazon.nrodoc
            obEntidad.nombreCompleto = SelRazon.nombreCompleto
            obEntidad.cuentaAsiento = "1213"
            obEntidad.direccion = SelRazon.direccion
            If SelRazon.direccion IsNot Nothing Then
                If SelRazon.direccion.Trim.Length > 0 Then
                    obEntidad.entidadAtributos = New List(Of entidadAtributos)
                    obEntidad.entidadAtributos.Add(New entidadAtributos With {
                                                   .Action = BaseBE.EntityAction.INSERT,
                                                   .tipo = "DOMICILIO",
                                                   .estado = 1,
                                                   .valorAtributo = SelRazon.direccion,
                                                   .usuarioModificacion = usuario.IDUsuario,
                                                   .fechaModificacion = Date.Now
                                                   })
                End If
            End If
            obEntidad.estado = StatusEntidad.Activo
            Dim codx As Integer = entidadSA.GrabarEntidad(obEntidad)

            TextProveedor.Tag = codx
            Dim entidad As New entidad
            entidad.idEntidad = codx
            entidad.nrodoc = TextNumIdentrazon.Text.Trim
            entidad.nombreCompleto = obEntidad.nombreCompleto
            entidad.tipoDoc = obEntidad.tipoDoc
            Me.Tag = entidad

            'If RadioButton2.Checked = True Then
            '    textPersona.Focus()
            '    textPersona.Select()
            'ElseIf RadioButton1.Checked = True Then
            '    txtruc.Focus()
            '    txtruc.Select()
            'End If
            'Transporte.ListaEmpresas.Add(entidad)

            '    Dispose()
        Catch ex As Exception
            'Manejo de errores
            MsgBox("No se pudo grabar el cliente." & vbCrLf & ex.Message, MsgBoxStyle.Critical)
            Me.Tag = Nothing
        End Try
    End Sub

End Class
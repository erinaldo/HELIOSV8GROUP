Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Tools

Public Class TabFN_GetPagarReclamacion
#Region "Variables"
    Public Property entidadSA As New entidadSA
    Public Property compraSA As New DocumentoCompraSA
    Public Property ventaSA As New documentoVentaAbarrotesSA
    Public Property anticipoSA As New documentoAnticipoSA
    Public Property ListaEntidad As List(Of entidad)
    Public Property documentoAnticipoConciliacionSA As New documentoAnticipoConciliacionSA
    Public Property estado As String

    'Public Property FormMDI As FormMaestroReclamacionPagos

#End Region

#Region "Constructors"
    'Public Sub New(form As FormMaestroReclamacionPagos, estadoReclamo As String)
    Public Sub New(estadoReclamo As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'FormatoGridAvanzado(dgvPagosVarios, True, False, 10.0F)
        General.FormatoGridAvanzado(dgvPagosVarios, True, False, 10.0F, SelectionMode.One)
        General.FormatoGridAvanzado(GridNotas, True, False, 10.0F, SelectionMode.One)
        estado = estadoReclamo
        'FormMDI = Form
        'dockingManager1.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.VS2010
        'dockingManager1.ShowCaption = True
        'dockingManager1.SetDockLabel(PanelfILTROS, "Búsqueda")
        'dockingManager1.DockControlInAutoHideMode(PanelfILTROS, DockingStyle.Left, 295)
        GetProveedores()
        txtPeriodo.Value = DateTime.Now
    End Sub
#End Region

#Region "Methods"

    Private Sub GetNotas(idDoc As Integer)

        Dim dt As New DataTable
        dt.Columns.Add("idDocumento")
        dt.Columns.Add("fecha")
        dt.Columns.Add("tipo")
        dt.Columns.Add("nrodoc")
        dt.Columns.Add("monto")
        dt.Columns.Add("usado")
        dt.Columns.Add("saldo")
        dt.Columns.Add("estado")

        For Each i In anticipoSA.GetCompromisoXDocumento(New documentoventaAbarrotes With
                                                             {
                                                             .idEmpresa = Gempresas.IdEmpresaRuc,
                                                             .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                             .tipoVenta = "VRC",
                                                             .idDocumento = idDoc
                                                             })

            dt.Rows.Add(i.idDocumento, i.fechaDoc, "COMPROMISO RECLAMACION", i.numeroDoc, i.importeMN, i.TotalNotas, i.SaldoReclamacion.GetValueOrDefault, i.EstadoName)
        Next
        GridNotas.DataSource = dt
    End Sub




    Private Sub GetProveedores()
        ListaEntidad = entidadSA.GetListarEntidad(New entidad With {.tipoEntidad = TIPO_ENTIDAD.CLIENTE, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
        TextBoxExt1.Visible = True
        TextBoxExt1.ReadOnly = False
        TextBoxExt1.Enabled = True
    End Sub



    Public Sub GetReclamacionesXClientes(moneda As String, idcliente As Integer)

        dgvPagosVarios.Table.Records.DeleteAll()

        Dim dt As New DataTable
        Dim strPeriodo = New DateTime(txtPeriodo.Value.Year, txtPeriodo.Value.Month, 1)
        'Dim cuentasList = ventaSA.GetReclamacionesXClientes(Gempresas.IdEmpresaRuc,
        '                                                    GEstableciento.IdEstablecimiento,
        '                                                    strPeriodo,
        '                                                    "1", idcliente)
        Dim cuentasList = ventaSA.GetReclamacionesXClientes(New Business.Entity.documentoventaAbarrotes With
                                                            {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                            .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                            .fechaDoc = txtPeriodo.Value,
                                                            .moneda = moneda,
                                                            .idCliente = idcliente,
                                                            .estado = estado})

        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("fecha", GetType(String))
        dt.Columns.Add("tipoVenta", GetType(String))
        dt.Columns.Add("tipoDoc", GetType(String))
        dt.Columns.Add("serie", GetType(String))
        dt.Columns.Add("numero", GetType(String))
        dt.Columns.Add("moneda", GetType(String))
        dt.Columns.Add("importeMN", GetType(Decimal))
        dt.Columns.Add("tipoCambio", GetType(Decimal))
        dt.Columns.Add("importeME", GetType(Decimal))
        dt.Columns.Add("abonoMN", GetType(Decimal))
        dt.Columns.Add("abonoME", GetType(Decimal))
        dt.Columns.Add("saldoMN", GetType(Decimal))
        dt.Columns.Add("saldoME", GetType(Decimal))
        dt.Columns.Add("estadoPago", GetType(String))
        dt.Columns.Add("montoProg", GetType(Integer))

        dt.Columns.Add("idProveedor", GetType(String))
        dt.Columns.Add("proveedor", GetType(String))
        dt.Columns.Add("nrodocEntidad", GetType(String))

        Dim str As String
        If cuentasList.Count > 0 Then
            Dim SaldoPagosMN As Decimal = 0
            Dim SaldoPagosME As Decimal = 0
            For Each i In cuentasList.OrderBy(Function(o) o.NombreEntidad).ToList
                SaldoPagosMN = 0
                SaldoPagosME = 0

                SaldoPagosMN = i.ImporteNacional - i.PagoSumaMN
                SaldoPagosME = i.ImporteExtranjero - i.PagoSumaME

                'nota de credito
                SaldoPagosMN = SaldoPagosMN '- i.PagoNotaCreditoMN + i.PagoNotaDebitoMN
                SaldoPagosME = SaldoPagosME '- i.PagoNotaCreditoME + i.PagoNotaDebitoME

                'If SaldoPagosMN < 0 Then
                '    SaldoPagosMN = 0
                'End If

                'If SaldoPagosME < 0 Then
                '    SaldoPagosME = 0
                'End If

                Dim dr As DataRow = dt.NewRow()
                str = Nothing
                str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
                dr(0) = i.idDocumento
                dr(1) = str
                dr(2) = i.tipoVenta
                dr(3) = i.tipoDocumento
                dr(4) = i.serie
                dr(5) = i.numeroDoc
                Select Case i.moneda
                    Case 1
                        dr(6) = "NAC"

                        'dr(10) = i.ImportePagoMN
                        'dr(11) = i.ImportePagoME
                        'dr(12) = CDec(i.importeTotal - i.ImportePagoMN).ToString("N2")
                        'dr(13) = CDec(i.importeUS - i.ImportePagoME).ToString("N2")
                    Case Else
                        dr(6) = "EXT"


                End Select
                dr(7) = CDec(i.ImporteNacional).ToString("N2") '- CDec(i.PagoNotaCreditoMN).ToString("N2") + CDec(i.PagoNotaDebitoMN).ToString("N2")
                dr(8) = i.tipoCambio
                dr(9) = CDec(i.ImporteExtranjero.GetValueOrDefault).ToString("N2") '- CDec(i.PagoNotaCreditoME).ToString("N2") + CDec(i.PagoNotaDebitoME).ToString("N2")
                dr(10) = i.PagoSumaMN + i.PagoNotaCreditoMN '+ i.PagoNotaDebitoMN '  CDec(i.PagoSumaMN).ToString("N2")
                dr(11) = i.PagoSumaME + i.PagoNotaCreditoME '+ i.PagoNotaDebitoME ' CDec(i.PagoSumaME).ToString("N2")
                dr(12) = SaldoPagosMN ' i.SaldoComprobanteDocumentoCompraMN '  CDec(i.importeTotal - i.PagoSumaMN).ToString("N2")
                dr(13) = SaldoPagosME ' i.SaldoComprobanteDocumentoCompraME 'CDec(i.importeUS - i.PagoSumaME).ToString("N2")
                Select Case i.estadoCobro
                    Case TIPO_COMPRA.PAGO.PAGADO
                        dr(14) = "Saldado"
                    Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                        dr(14) = "Pendiente"
                End Select

                dr(15) = 0 'i.conteoCuotas

                dr(16) = i.idCliente
                dr(17) = i.NombreEntidad
                dr(18) = i.NroDocEntidad
                dt.Rows.Add(dr)
            Next

            Select Case cboMonedaProveedor.Text
                Case "NACIONAL"
                    dgvPagosVarios.TableDescriptor.Columns("importeMN").Width = 70
                    dgvPagosVarios.TableDescriptor.Columns("abonoMN").Width = 70
                    dgvPagosVarios.TableDescriptor.Columns("saldoMN").Width = 70
                    dgvPagosVarios.TableDescriptor.Columns("tipoCambio").Width = 0
                    dgvPagosVarios.TableDescriptor.Columns("importeME").Width = 0
                    dgvPagosVarios.TableDescriptor.Columns("abonoME").Width = 0
                    dgvPagosVarios.TableDescriptor.Columns("saldoME").Width = 0
                Case "EXTRANJERA"
                    dgvPagosVarios.TableDescriptor.Columns("tipoCambio").Width = 70
                    dgvPagosVarios.TableDescriptor.Columns("importeME").Width = 70
                    dgvPagosVarios.TableDescriptor.Columns("abonoME").Width = 70
                    dgvPagosVarios.TableDescriptor.Columns("saldoME").Width = 70

                    dgvPagosVarios.TableDescriptor.Columns("importeMN").Width = 0
                    dgvPagosVarios.TableDescriptor.Columns("abonoMN").Width = 0
                    dgvPagosVarios.TableDescriptor.Columns("saldoMN").Width = 0
            End Select


            dgvPagosVarios.DataSource = dt
            dgvPagosVarios.TableDescriptor.Columns("proveedor").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
            dgvPagosVarios.TableDescriptor.Columns("proveedor").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
            dgvPagosVarios.TableDescriptor.Columns("fecha").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
            dgvPagosVarios.TableDescriptor.Columns("fecha").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle


            Me.dgvPagosVarios.TableOptions.ListBoxSelectionMode = SelectionMode.One
        Else

        End If

    End Sub


    Public Sub CuentasPorPagar(moneda As String)
        dgvPagosVarios.Table.Records.DeleteAll()
        Dim dt As New DataTable
        'Dim strPeriodo = New DateTime(txtPeriodo.Value.Year, txtPeriodo.Value.Month, 1)
        'Dim cuentasList = ventaSA.GetCuentasPagarReclamacionesClientes(Gempresas.IdEmpresaRuc,
        '                                                    GEstableciento.IdEstablecimiento,
        '                                                    strPeriodo,
        '                                                    "1")
        Dim cuentasList = ventaSA.GetCuentasPagarReclamacionesClientes(New Business.Entity.documentoventaAbarrotes With
                                                       {
                                                       .idEmpresa = Gempresas.IdEmpresaRuc,
                                                       .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                       .fechaDoc = txtPeriodo.Value,
                                                       .estado = estado,
                                                       .moneda = moneda
                                                       })




        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("fecha", GetType(String))
        dt.Columns.Add("tipoVenta", GetType(String))
        dt.Columns.Add("tipoDoc", GetType(String))
        dt.Columns.Add("serie", GetType(String))
        dt.Columns.Add("numero", GetType(String))
        dt.Columns.Add("moneda", GetType(String))
        dt.Columns.Add("importeMN", GetType(Decimal))
        dt.Columns.Add("tipoCambio", GetType(Decimal))
        dt.Columns.Add("importeME", GetType(Decimal))
        dt.Columns.Add("abonoMN", GetType(Decimal))
        dt.Columns.Add("abonoME", GetType(Decimal))
        dt.Columns.Add("saldoMN", GetType(Decimal))
        dt.Columns.Add("saldoME", GetType(Decimal))
        dt.Columns.Add("estadoPago", GetType(String))
        dt.Columns.Add("montoProg", GetType(Integer))

        dt.Columns.Add("idProveedor", GetType(String))
        dt.Columns.Add("proveedor", GetType(String))
        dt.Columns.Add("nrodocEntidad", GetType(String))

        Dim str As String
        If cuentasList.Count > 0 Then
            Dim SaldoPagosMN As Decimal = 0
            Dim SaldoPagosME As Decimal = 0
            For Each i In cuentasList.OrderBy(Function(o) o.NombreEntidad).ToList
                SaldoPagosMN = 0
                SaldoPagosME = 0

                SaldoPagosMN = i.ImporteNacional - i.PagoSumaMN
                SaldoPagosME = i.ImporteExtranjero - i.PagoSumaME

                'nota de credito
                SaldoPagosMN = SaldoPagosMN '- i.PagoNotaCreditoMN + i.PagoNotaDebitoMN
                SaldoPagosME = SaldoPagosME '- i.PagoNotaCreditoME + i.PagoNotaDebitoME

                'If SaldoPagosMN < 0 Then
                '    SaldoPagosMN = 0
                'End If

                'If SaldoPagosME < 0 Then
                '    SaldoPagosME = 0
                'End If

                Dim dr As DataRow = dt.NewRow()
                str = Nothing
                str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
                dr(0) = i.idDocumento
                dr(1) = str
                dr(2) = i.tipoVenta
                dr(3) = i.tipoDocumento
                dr(4) = i.serie
                dr(5) = i.numeroDoc
                Select Case i.moneda
                    Case 1
                        dr(6) = "NAC"

                        'dr(10) = i.ImportePagoMN
                        'dr(11) = i.ImportePagoME
                        'dr(12) = CDec(i.importeTotal - i.ImportePagoMN).ToString("N2")
                        'dr(13) = CDec(i.importeUS - i.ImportePagoME).ToString("N2")
                    Case Else
                        dr(6) = "EXT"


                End Select
                dr(7) = CDec(i.ImporteNacional).ToString("N2") '- CDec(i.PagoNotaCreditoMN).ToString("N2") + CDec(i.PagoNotaDebitoMN).ToString("N2")
                dr(8) = i.tipoCambio
                dr(9) = CDec(i.ImporteExtranjero.GetValueOrDefault).ToString("N2") '- CDec(i.PagoNotaCreditoME).ToString("N2") + CDec(i.PagoNotaDebitoME).ToString("N2")
                dr(10) = i.PagoSumaMN + i.PagoNotaCreditoMN '+ i.PagoNotaDebitoMN '  CDec(i.PagoSumaMN).ToString("N2")
                dr(11) = i.PagoSumaME + i.PagoNotaCreditoME '+ i.PagoNotaDebitoME ' CDec(i.PagoSumaME).ToString("N2")
                dr(12) = SaldoPagosMN ' i.SaldoComprobanteDocumentoCompraMN '  CDec(i.importeTotal - i.PagoSumaMN).ToString("N2")
                dr(13) = SaldoPagosME ' i.SaldoComprobanteDocumentoCompraME 'CDec(i.importeUS - i.PagoSumaME).ToString("N2")
                Select Case i.estadoCobro
                    Case TIPO_COMPRA.PAGO.PAGADO
                        dr(14) = "Saldado"
                    Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                        dr(14) = "Pendiente"
                End Select

                dr(15) = 0 'i.conteoCuotas

                dr(16) = i.idCliente
                dr(17) = i.NombreEntidad
                dr(18) = i.NroDocEntidad
                dt.Rows.Add(dr)
            Next

            Select Case cboMonedaProveedor.Text
                Case "NACIONAL"
                    dgvPagosVarios.TableDescriptor.Columns("importeMN").Width = 70
                    dgvPagosVarios.TableDescriptor.Columns("abonoMN").Width = 70
                    dgvPagosVarios.TableDescriptor.Columns("saldoMN").Width = 70
                    dgvPagosVarios.TableDescriptor.Columns("tipoCambio").Width = 0
                    dgvPagosVarios.TableDescriptor.Columns("importeME").Width = 0
                    dgvPagosVarios.TableDescriptor.Columns("abonoME").Width = 0
                    dgvPagosVarios.TableDescriptor.Columns("saldoME").Width = 0
                Case "EXTRANJERA"
                    dgvPagosVarios.TableDescriptor.Columns("tipoCambio").Width = 70
                    dgvPagosVarios.TableDescriptor.Columns("importeME").Width = 70
                    dgvPagosVarios.TableDescriptor.Columns("abonoME").Width = 70
                    dgvPagosVarios.TableDescriptor.Columns("saldoME").Width = 70

                    dgvPagosVarios.TableDescriptor.Columns("importeMN").Width = 0
                    dgvPagosVarios.TableDescriptor.Columns("abonoMN").Width = 0
                    dgvPagosVarios.TableDescriptor.Columns("saldoMN").Width = 0
            End Select


            dgvPagosVarios.DataSource = dt
            dgvPagosVarios.TableDescriptor.Columns("proveedor").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
            dgvPagosVarios.TableDescriptor.Columns("proveedor").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
            dgvPagosVarios.TableDescriptor.Columns("fecha").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
            dgvPagosVarios.TableDescriptor.Columns("fecha").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle


            Me.dgvPagosVarios.TableOptions.ListBoxSelectionMode = SelectionMode.One
        Else

        End If

    End Sub

    Public Sub CuentasPorPagarProveedor()
        Dim dt As New DataTable
        Dim strPeriodo = New DateTime(txtPeriodo.Value.Year, txtPeriodo.Value.Month, 1)
        Dim cuentasList = compraSA.GetCuentasPorpagarProveedorPendientes(New Business.Entity.documentocompra With
                                                            {
                                                            .idEmpresa = Gempresas.IdEmpresaRuc,
                                                            .idCentroCosto = GEstableciento.IdEstablecimiento,
                                                            .monedaDoc = "1",
                                                            .fechaDoc = DateTime.Now,
                                                            .idProveedor = Integer.Parse(TextBoxExt1.Tag)})

        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("fecha", GetType(String))
        dt.Columns.Add("tipoVenta", GetType(String))
        dt.Columns.Add("tipoDoc", GetType(String))
        dt.Columns.Add("serie", GetType(String))
        dt.Columns.Add("numero", GetType(String))
        dt.Columns.Add("moneda", GetType(String))
        dt.Columns.Add("importeMN", GetType(Decimal))
        dt.Columns.Add("tipoCambio", GetType(Decimal))
        dt.Columns.Add("importeME", GetType(Decimal))
        dt.Columns.Add("abonoMN", GetType(Decimal))
        dt.Columns.Add("abonoME", GetType(Decimal))
        dt.Columns.Add("saldoMN", GetType(Decimal))
        dt.Columns.Add("saldoME", GetType(Decimal))
        dt.Columns.Add("estadoPago", GetType(String))
        dt.Columns.Add("montoProg", GetType(Integer))

        dt.Columns.Add("idProveedor", GetType(String))
        dt.Columns.Add("proveedor", GetType(String))
        dt.Columns.Add("nrodocEntidad", GetType(String))

        Dim str As String
        If cuentasList.Count > 0 Then
            Dim SaldoPagosMN As Decimal = 0
            Dim SaldoPagosME As Decimal = 0
            For Each i In cuentasList.OrderBy(Function(o) o.NombreEntidad).ToList
                SaldoPagosMN = 0
                SaldoPagosME = 0

                SaldoPagosMN = i.importeTotal - i.PagoSumaMN
                SaldoPagosME = i.importeUS - i.PagoSumaME

                'nota de credito
                SaldoPagosMN = SaldoPagosMN - i.PagoNotaCreditoMN + i.PagoNotaDebitoMN
                SaldoPagosME = SaldoPagosME - i.PagoNotaCreditoME + i.PagoNotaDebitoME

                'If SaldoPagosMN < 0 Then
                '    SaldoPagosMN = 0
                'End If

                'If SaldoPagosME < 0 Then
                '    SaldoPagosME = 0
                'End If

                Dim dr As DataRow = dt.NewRow()
                str = Nothing
                str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
                dr(0) = i.idDocumento
                dr(1) = str
                dr(2) = i.tipoCompra
                dr(3) = i.tipoDoc
                dr(4) = i.serie
                dr(5) = i.numeroDoc
                Select Case i.monedaDoc
                    Case 1
                        dr(6) = "NAC"

                        'dr(10) = i.ImportePagoMN
                        'dr(11) = i.ImportePagoME
                        'dr(12) = CDec(i.importeTotal - i.ImportePagoMN).ToString("N2")
                        'dr(13) = CDec(i.importeUS - i.ImportePagoME).ToString("N2")
                    Case Else
                        dr(6) = "EXT"


                End Select
                dr(7) = CDec(i.importeTotal).ToString("N2") '- CDec(i.PagoNotaCreditoMN).ToString("N2") + CDec(i.PagoNotaDebitoMN).ToString("N2")
                dr(8) = i.tcDolLoc
                dr(9) = CDec(i.importeUS.GetValueOrDefault).ToString("N2") '- CDec(i.PagoNotaCreditoME).ToString("N2") + CDec(i.PagoNotaDebitoME).ToString("N2")
                dr(10) = i.PagoSumaMN + i.PagoNotaCreditoMN '+ i.PagoNotaDebitoMN '  CDec(i.PagoSumaMN).ToString("N2")
                dr(11) = i.PagoSumaME + i.PagoNotaCreditoME '+ i.PagoNotaDebitoME ' CDec(i.PagoSumaME).ToString("N2")
                dr(12) = SaldoPagosMN ' i.SaldoComprobanteDocumentoCompraMN '  CDec(i.importeTotal - i.PagoSumaMN).ToString("N2")
                dr(13) = SaldoPagosME ' i.SaldoComprobanteDocumentoCompraME 'CDec(i.importeUS - i.PagoSumaME).ToString("N2")
                Select Case i.estadoPago
                    Case TIPO_COMPRA.PAGO.PAGADO
                        dr(14) = "Saldado"
                    Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                        dr(14) = "Pendiente"
                End Select

                dr(15) = i.conteoCuotas

                dr(16) = i.idProveedor
                dr(17) = i.NombreEntidad
                dr(18) = i.NroDocEntidad
                dt.Rows.Add(dr)
            Next

            Select Case cboMonedaProveedor.Text
                Case "NACIONAL"
                    dgvPagosVarios.TableDescriptor.Columns("importeMN").Width = 70
                    dgvPagosVarios.TableDescriptor.Columns("abonoMN").Width = 70
                    dgvPagosVarios.TableDescriptor.Columns("saldoMN").Width = 70
                    dgvPagosVarios.TableDescriptor.Columns("tipoCambio").Width = 0
                    dgvPagosVarios.TableDescriptor.Columns("importeME").Width = 0
                    dgvPagosVarios.TableDescriptor.Columns("abonoME").Width = 0
                    dgvPagosVarios.TableDescriptor.Columns("saldoME").Width = 0
                Case "EXTRANJERA"
                    dgvPagosVarios.TableDescriptor.Columns("tipoCambio").Width = 70
                    dgvPagosVarios.TableDescriptor.Columns("importeME").Width = 70
                    dgvPagosVarios.TableDescriptor.Columns("abonoME").Width = 70
                    dgvPagosVarios.TableDescriptor.Columns("saldoME").Width = 70

                    dgvPagosVarios.TableDescriptor.Columns("importeMN").Width = 0
                    dgvPagosVarios.TableDescriptor.Columns("abonoMN").Width = 0
                    dgvPagosVarios.TableDescriptor.Columns("saldoMN").Width = 0
            End Select


            dgvPagosVarios.DataSource = dt
            dgvPagosVarios.TableDescriptor.Columns("proveedor").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
            dgvPagosVarios.TableDescriptor.Columns("proveedor").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
            dgvPagosVarios.TableDescriptor.Columns("fecha").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
            dgvPagosVarios.TableDescriptor.Columns("fecha").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle


            Me.dgvPagosVarios.TableOptions.ListBoxSelectionMode = SelectionMode.One
        Else

        End If

    End Sub

    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click, ButtonAdv12.Click
        Cursor = Cursors.WaitCursor

        If cboMonedaProveedor.Text = "NACIONAL" Then
            CuentasPorPagar("1")
        ElseIf cboMonedaProveedor.Text = "EXTRANJERA" Then
            CuentasPorPagar("2")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Cursor = Cursors.WaitCursor
        Dim r As Record = dgvPagosVarios.Table.CurrentRecord
        If r IsNot Nothing Then
            Dim ent As New entidad With
                {
                .idEntidad = Integer.Parse(r.GetValue("idProveedor")),
                .nombreCompleto = r.GetValue("proveedor"),
                .nrodoc = r.GetValue("nrodocEntidad")
            }

            Dim idDocumento As Integer = Integer.Parse(r.GetValue("idDocumento"))
            Dim f As New FormCrearReclamoPago(idDocumento, ent)
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)



            If cboMonedaProveedor.Text = "NACIONAL" Then
                CuentasPorPagar("1")
            ElseIf cboMonedaProveedor.Text = "EXTRANJERA" Then
                CuentasPorPagar("2")
            End If


        End If

        Cursor = Cursors.Default
        'Dim cajaUsuarioSA As New cajaUsuarioSA
        'If Not IsNothing(Me.dgvPagosVarios.Table.CurrentRecord) Then

        '    'Dim fechaAnt = New Date(txtPeriodo.Value.Year, CInt(txtPeriodo.Value.Month), 1)
        '    'fechaAnt = fechaAnt.AddMonths(-1)
        '    'Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
        '    'If periodoAnteriorEstaCerrado = False Then
        '    '    MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
        '    '    Cursor = Cursors.Default
        '    '    Exit Sub
        '    'End If

        '    'Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = txtPeriodo.Value.Year, .mes = CInt(txtPeriodo.Value.Month)})
        '    'If Not IsNothing(valida) Then
        '    '    If valida = True Then
        '    '        MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    '        Me.Cursor = Cursors.Default
        '    '        Exit Sub
        '    '    End If
        '    'End If

        '    If dgvPagosVarios.Table.SelectedRecords.Count > 0 Then

        '        Dim cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
        '        If Not IsNothing(cajaUsuario) Then
        '            GetGlobalMappingCajaUsuario(cajaUsuario, usuario.IDUsuario, usuario.CustomUsuario.Full_Name)
        '            'btnNuevoPagoPago(dgvPagosVarios.Table.CurrentRecord.GetValue("moneda"), dgvPagosVarios.Table.CurrentRecord.GetValue("idDocumento"))
        '            Dim f As New FormPagarDoc(dgvPagosVarios.Table.CurrentRecord.GetValue("idDocumento"))
        '            f.Saldo = CDec(dgvPagosVarios.Table.CurrentRecord.GetValue("saldoMN"))
        '            f.StartPosition = FormStartPosition.CenterParent
        '            f.ShowDialog(Me)

        '        Else
        '            MessageBox.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '        End If
        '    End If
        'Else
        '    MessageBox.Show("Debe seleccionar una item!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
    End Sub


    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles LsvProveedor.MouseDoubleClick, ListView3.MouseDoubleClick
        Me.pcLikeCategoria.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub TextBoxExt1_TextChanged(sender As Object, e As EventArgs) Handles TextBoxExt1.TextChanged, TextBoxExt14.TextChanged
        TextBoxExt1.ForeColor = Color.Black
        TextBoxExt1.Tag = Nothing
        If TextBoxExt1.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            '    txtruc.Visible = True
        Else
            '    txtruc.Visible = False
        End If
    End Sub

    Private Sub pcLikeCategoria_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcLikeCategoria.CloseUp, PopupControlContainer3.CloseUp
        Dim beneficioSA As New beneficioSA
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.PopupCloseType = PopupCloseType.Done Then
                If LsvProveedor.SelectedItems.Count > 0 Then
                    If LsvProveedor.SelectedItems(0).SubItems(1).Text = "Agregar nuevo" Then
                        'Dim f As New frmCrearENtidades
                        'f.CaptionLabels(0).Text = "Nuevo proveedor"
                        'f.strTipo = TIPO_ENTIDAD.PROVEEDOR
                        'f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        ''f.tipoPersona(TIPO_ENTIDAD.CLIENTE)
                        'f.StartPosition = FormStartPosition.CenterParent
                        'f.ShowDialog()
                        'If Not IsNothing(f.Tag) Then
                        '    Dim c = CType(f.Tag, entidad)
                        '    ListaEntidad.Add(c)
                        '    TextBoxExt1.Text = c.nombreCompleto
                        '    'txtruc.Text = c.nrodoc
                        '    TextBoxExt1.Tag = c.idEntidad
                        '    'txtruc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        '    'txtruc.Visible = True
                        '    TextBoxExt1.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        'End If
                    Else
                        txtBuscarProveedorPago.Text = LsvProveedor.SelectedItems(0).SubItems(1).Text
                        txtBuscarProveedorPago.Tag = LsvProveedor.SelectedItems(0).SubItems(0).Text
                        txtBuscarProveedorPago.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        txtRucPago.Text = LsvProveedor.SelectedItems(0).SubItems(2).Text
                        'txtruc.Visible = True

                    End If
                    'ListaMercaderiasXIdHijo(Val(txtSubCategoria.Tag), cboTipoExistencia.SelectedValue)
                End If
            End If

            'Set focus back to textbox.
            If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
                Me.TextBoxExt1.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub TextBoxExt1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxExt1.KeyDown, TextBoxExt14.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        Else
            '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.pcLikeCategoria.Size = New Size(282, 128)
            Me.pcLikeCategoria.ParentControl = Me.TextBoxExt1
            Me.pcLikeCategoria.ShowPopup(Point.Empty)
            Dim consulta As New List(Of entidad)
            'consulta.Add(New entidad With {.nombreCompleto = "Agregar nuevo"})



            Dim consulta2 = (From n In ListaEntidad
                             Where n.nombreCompleto.StartsWith(TextBoxExt1.Text) Or n.nrodoc.StartsWith(TextBoxExt1.Text)).ToList




            consulta.AddRange(consulta2)
            FillLSVClientes(consulta)
            e.Handled = True
        End If

        If e.KeyCode = Keys.Down Then
            '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.pcLikeCategoria.Size = New Size(282, 128)
            Me.pcLikeCategoria.ParentControl = Me.TextBoxExt1
            Me.pcLikeCategoria.ShowPopup(Point.Empty)
            LsvProveedor.Focus()
        End If
        '   End If

        ' e.SuppressKeyPress = True
        If e.KeyCode = Keys.Escape Then
            If Me.pcLikeCategoria.IsShowing() Then
                Me.pcLikeCategoria.HidePopup(PopupCloseType.Canceled)
            End If
        End If
    End Sub

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

#End Region

#Region "Events"
    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click, ButtonAdv10.Click
        Try
            If RBProveedor.Checked = True Then
                CuentasPorPagarProveedor()
            ElseIf RBTodos.Checked = True Then

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub



    Private Sub dgvPagosVarios_SelectedRecordsChanged(sender As Object, e As SelectedRecordsChangedEventArgs) Handles dgvPagosVarios.SelectedRecordsChanged
        'Cursor = Cursors.WaitCursor
        'If e.SelectedRecord IsNot Nothing Then
        '    Dim r As Record = e.SelectedRecord.Record
        '    If r IsNot Nothing Then
        '        If dgvPagosVarios.Table.Records.Count > 0 Then
        '            GetNotas(Integer.Parse(r.GetValue("idDocumento")))
        '        End If
        '    End If
        'End If
        'Cursor = Cursors.Default
    End Sub

    Private Sub dgvPagosVarios_TableControlCellClick(sender As Object, e As Grouping.GridTableControlCellClickEventArgs) Handles dgvPagosVarios.TableControlCellClick

    End Sub

    Private Sub txtBuscarProveedorPago_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarProveedorPago.TextChanged
        txtBuscarProveedorPago.ForeColor = Color.Black
        txtBuscarProveedorPago.Tag = Nothing
        If txtBuscarProveedorPago.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            '    txtruc.Visible = True
        Else
            '    txtruc.Visible = False
        End If
    End Sub

    Private Sub txtBuscarProveedorPago_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscarProveedorPago.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        Else
            '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.pcLikeCategoria.Size = New Size(282, 128)
            Me.pcLikeCategoria.ParentControl = Me.txtBuscarProveedorPago
            Me.pcLikeCategoria.ShowPopup(Point.Empty)
            Dim consulta As New List(Of entidad)
            'consulta.Add(New entidad With {.nombreCompleto = "Agregar nuevo"})



            Dim consulta2 = (From n In ListaEntidad
                             Where n.nombreCompleto.StartsWith(txtBuscarProveedorPago.Text) Or n.nrodoc.StartsWith(txtBuscarProveedorPago.Text)).ToList




            consulta.AddRange(consulta2)
            FillLSVClientes(consulta)
            e.Handled = True
        End If

        If e.KeyCode = Keys.Down Then
            '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.pcLikeCategoria.Size = New Size(282, 128)
            Me.pcLikeCategoria.ParentControl = Me.txtBuscarProveedorPago
            Me.pcLikeCategoria.ShowPopup(Point.Empty)
            LsvProveedor.Focus()
        End If
        '   End If

        ' e.SuppressKeyPress = True
        If e.KeyCode = Keys.Escape Then
            If Me.pcLikeCategoria.IsShowing() Then
                Me.pcLikeCategoria.HidePopup(PopupCloseType.Canceled)
            End If
        End If
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Cursor = Cursors.WaitCursor
        If txtBuscarProveedorPago.Text.Trim.Length > 0 Then


            If cboMonedaProveedor.Text = "NACIONAL" Then
                GetReclamacionesXClientes(txtBuscarProveedorPago.Tag, "1")
            ElseIf cboMonedaProveedor.Text = "EXTRANJERA" Then
                GetReclamacionesXClientes(txtBuscarProveedorPago.Tag, "2")
            End If

        End If
        Cursor = Cursors.Default


    End Sub

    Private Sub ToolStrip2_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip2.ItemClicked

    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Dim moneda As String = ""

        Select Case cboMonedaProveedor.Text
            Case "NACIONAL"
                moneda = "1"
            Case "EXTRANJERA"
                moneda = "2"
        End Select

        If checkProveedor.Checked = True Then 'por cliente periodo
            If txtBuscarProveedorPago.Text.Trim.Length > 0 Then
                GetReclamacionesXClientes(moneda, txtBuscarProveedorPago.Tag)
            End If
        ElseIf checkProveedor.Checked = False Then ' por periodo todos
            CuentasPorPagar(moneda)
        End If
    End Sub

    Private Sub checkProveedor_CheckedChanged(sender As Object, e As EventArgs) Handles checkProveedor.CheckedChanged
        If checkProveedor.Checked = True Then
            txtBuscarProveedorPago.Visible = True
            txtRucPago.Visible = True
            Label53.Visible = True
        ElseIf checkProveedor.Checked = False Then
            txtBuscarProveedorPago.Visible = False
            txtRucPago.Visible = False
            Label53.Visible = False
        End If
    End Sub
#End Region
End Class

Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Tools

Public Class TabFN_GetCuentasCobrarPeriodo

#Region "Variables"
    '   Public Property opcionSel As String
    Public Property compraSA As New documentoVentaAbarrotesSA
    Public Property ListaEntidad As List(Of entidad)
    Public Property entidadSA As New entidadSA

    Public selRecordCliente As Record

    Public Property FormPurchase As TabCT_ControlXCliente

#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(dgvCobranzaCli, True, False, 10.0F)
        FormatoGridAvanzado(GridClientes, True, False, 10.0F)
        'dockingManager1.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.VS2010
        'dockingManager1.ShowCaption = True
        'dockingManager1.SetDockLabel(PanelfILTROS, "Búsqueda")
        'dockingManager1.DockControlInAutoHideMode(PanelfILTROS, DockingStyle.Left, 295)
        'GetClientes()
        txtPeriodo.Value = DateTime.Now
    End Sub

    Public Sub New(formRepPiscina As TabCT_ControlXCliente)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(dgvCobranzaCli, True, False, 10.0F)
        FormatoGridAvanzado(GridClientes, True, False, 10.0F)
        txtPeriodo.Value = DateTime.Now
        GetClientes()
        FormPurchase = formRepPiscina
    End Sub

#End Region

#Region "Methdos"

    Public Sub RecargarConsulta()
        Dim moneda As String = ""

        Select Case cboMonedaProveedor.Text
            Case "NACIONAL"
                moneda = "1"
            Case "EXTRANJERA"
                moneda = "2"
        End Select

        If checkProveedor.Checked = True Then 'por cliente periodo
            If txtBuscarProveedorPago.Text.Trim.Length > 0 Then
                CuentasXCliente(moneda, TIPO_VENTA.PAGO.PENDIENTE_PAGO)
            End If
        ElseIf checkProveedor.Checked = False Then ' por periodo todos
            CuentasPorPagar(moneda)
        End If
    End Sub


    Private Sub GetClientes()
        ListaEntidad = entidadSA.GetListarEntidad(New entidad With {.tipoEntidad = TIPO_ENTIDAD.CLIENTE, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})

        'ListaEntidad.Add(VarClienteGeneral)

        TextBoxExt1.Visible = True
        TextBoxExt1.ReadOnly = False
        TextBoxExt1.Enabled = True

    End Sub

    Public Sub CuentasPorPagar(moneda As String)

        dgvCobranzaCli.Table.Records.DeleteAll()

        Dim dt As New DataTable
        Dim cuentasList = compraSA.GetCuentasXPagarTodoClientes(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, txtPeriodo.Value, moneda, TIPO_VENTA.PAGO.PENDIENTE_PAGO)


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

        dt.Columns.Add("idCliente")
        dt.Columns.Add("cliente")
        dt.Columns.Add("nroDocEntidad")

        Dim str As String
        If cuentasList.Count > 0 Then
            Dim SaldoPagosMN As Decimal = 0
            Dim SaldoPagosME As Decimal = 0
            For Each i In cuentasList


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
                dr(1) = str
                dr(2) = i.tipoVenta
                dr(3) = i.tipoDocumento
                dr(4) = i.serie
                dr(5) = i.numeroDoc
                Select Case i.moneda
                    Case CStr(1)
                        dr(6) = "NAC"
                    Case Else
                        dr(6) = "EXT"
                End Select
                dr(7) = i.ImporteNacional
                dr(8) = i.tipoCambio
                dr(9) = i.ImporteExtranjero
                dr(10) = i.PagoSumaMN + i.PagoNotaCreditoMN
                dr(11) = i.PagoSumaME + i.PagoNotaCreditoME
                'dr(12) = CDec(i.ImporteNacional - i.PagoSumaMN).ToString("N2")
                'dr(13) = CDec(i.ImporteExtranjero - i.PagoSumaME).ToString("N2")
                dr(12) = CDec(SaldoPagosMN).ToString("N2")
                dr(13) = CDec(SaldoPagosME).ToString("N2")

                Select Case i.estadoCobro
                    Case TIPO_VENTA.PAGO.COBRADO
                        dr(14) = "Saldado"
                    Case TIPO_VENTA.PAGO.PENDIENTE_PAGO
                        dr(14) = "Pendiente"
                End Select




                Select Case i.estadoCobro
                    Case TIPO_COMPRA.PAGO.PAGADO
                        dr(14) = "Saldado"
                    Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                        dr(14) = "Pendiente"
                End Select
                dr(15) = (i.idCliente)
                dr(16) = (i.NombreEntidad)
                dr(17) = (i.NroDocEntidad)
                dt.Rows.Add(dr)
            Next
            dgvCobranzaCli.DataSource = dt
            Me.dgvCobranzaCli.TableOptions.ListBoxSelectionMode = SelectionMode.One

            'Select Case cboMonedaCobro.Text
            '    Case "NACIONAL"
            dgvCobranzaCli.TableDescriptor.Columns("importeMN").Width = 70
            dgvCobranzaCli.TableDescriptor.Columns("abonoMN").Width = 70
            dgvCobranzaCli.TableDescriptor.Columns("saldoMN").Width = 70
            dgvCobranzaCli.TableDescriptor.Columns("tipoCambio").Width = 0
            dgvCobranzaCli.TableDescriptor.Columns("importeME").Width = 0
            dgvCobranzaCli.TableDescriptor.Columns("abonoME").Width = 0
            dgvCobranzaCli.TableDescriptor.Columns("saldoME").Width = 0
            'Case "EXTRANJERA"
            '    dgvCobranzaCli.TableDescriptor.Columns("tipoCambio").Width = 70
            '    dgvCobranzaCli.TableDescriptor.Columns("importeME").Width = 70
            '    dgvCobranzaCli.TableDescriptor.Columns("abonoME").Width = 70
            '    dgvCobranzaCli.TableDescriptor.Columns("saldoME").Width = 70
            '    dgvCobranzaCli.TableDescriptor.Columns("importeMN").Width = 0
            '    dgvCobranzaCli.TableDescriptor.Columns("abonoMN").Width = 0
            '    dgvCobranzaCli.TableDescriptor.Columns("saldoMN").Width = 0
            'End Select


        Else

        End If

    End Sub

    Public Sub CuentasPorPagarSelCliente(moneda As String, intIdCliente As Integer, terminos As String)

        dgvCobranzaCli.Table.Records.DeleteAll()

        Dim dt As New DataTable
        Dim cuentasList = compraSA.GetCuentaCobrarSelCliente(txtPeriodo.Value, moneda, intIdCliente, terminos)


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

        dt.Columns.Add("idCliente")
        dt.Columns.Add("cliente")
        dt.Columns.Add("nroDocEntidad")

        Dim str As String
        If cuentasList.Count > 0 Then
            Dim SaldoPagosMN As Decimal = 0
            Dim SaldoPagosME As Decimal = 0
            For Each i In cuentasList
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
                dr(1) = str
                dr(2) = i.tipoVenta
                dr(3) = i.tipoDocumento
                dr(4) = i.serie
                dr(5) = i.numeroDoc
                Select Case i.moneda
                    Case CStr(1)
                        dr(6) = "NAC"
                    Case Else
                        dr(6) = "EXT"
                End Select
                dr(7) = i.ImporteNacional
                dr(8) = i.tipoCambio
                dr(9) = i.ImporteExtranjero
                dr(10) = i.PagoSumaMN + i.PagoNotaCreditoMN
                dr(11) = i.PagoSumaME + i.PagoNotaCreditoME
                'dr(12) = CDec(i.ImporteNacional - i.PagoSumaMN).ToString("N2")
                'dr(13) = CDec(i.ImporteExtranjero - i.PagoSumaME).ToString("N2")
                dr(12) = CDec(SaldoPagosMN).ToString("N2")
                dr(13) = CDec(SaldoPagosME).ToString("N2")

                Select Case i.estadoCobro
                    Case TIPO_VENTA.PAGO.COBRADO
                        dr(14) = "Saldado"
                    Case TIPO_VENTA.PAGO.PENDIENTE_PAGO
                        dr(14) = "Pendiente"
                End Select




                Select Case i.estadoCobro
                    Case TIPO_COMPRA.PAGO.PAGADO
                        dr(14) = "Saldado"
                    Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                        dr(14) = "Pendiente"
                End Select
                dr(15) = (i.idCliente)
                dr(16) = (i.NombreEntidad)
                dr(17) = (i.NroDocEntidad)
                dt.Rows.Add(dr)
            Next
            dgvCobranzaCli.DataSource = dt
            Me.dgvCobranzaCli.TableOptions.ListBoxSelectionMode = SelectionMode.One

            Select Case cboMonedaProveedor.Text
                Case "EXTRANJERA"
                    dgvCobranzaCli.TableDescriptor.Columns("tipoCambio").Width = 70
                    dgvCobranzaCli.TableDescriptor.Columns("importeME").Width = 70
                    dgvCobranzaCli.TableDescriptor.Columns("abonoME").Width = 70
                    dgvCobranzaCli.TableDescriptor.Columns("saldoME").Width = 70
                    dgvCobranzaCli.TableDescriptor.Columns("importeMN").Width = 0
                    dgvCobranzaCli.TableDescriptor.Columns("abonoMN").Width = 0
                    dgvCobranzaCli.TableDescriptor.Columns("saldoMN").Width = 0
                Case Else
                    dgvCobranzaCli.TableDescriptor.Columns("importeMN").Width = 70
                    dgvCobranzaCli.TableDescriptor.Columns("abonoMN").Width = 70
                    dgvCobranzaCli.TableDescriptor.Columns("saldoMN").Width = 70
                    dgvCobranzaCli.TableDescriptor.Columns("tipoCambio").Width = 0
                    dgvCobranzaCli.TableDescriptor.Columns("importeME").Width = 0
                    dgvCobranzaCli.TableDescriptor.Columns("abonoME").Width = 0
                    dgvCobranzaCli.TableDescriptor.Columns("saldoME").Width = 0

            End Select
            'Select Case cboMonedaCobro.Text
            '    Case "NACIONAL"

            'Case "EXTRANJERA"
            '    dgvCobranzaCli.TableDescriptor.Columns("tipoCambio").Width = 70
            '    dgvCobranzaCli.TableDescriptor.Columns("importeME").Width = 70
            '    dgvCobranzaCli.TableDescriptor.Columns("abonoME").Width = 70
            '    dgvCobranzaCli.TableDescriptor.Columns("saldoME").Width = 70
            '    dgvCobranzaCli.TableDescriptor.Columns("importeMN").Width = 0
            '    dgvCobranzaCli.TableDescriptor.Columns("abonoMN").Width = 0
            '    dgvCobranzaCli.TableDescriptor.Columns("saldoMN").Width = 0
            'End Select


        Else

        End If

    End Sub

    Public Sub CuentasPorPagarTerminos(moneda As String, estadocobro As String)

        GridClientes.Table.Records.DeleteAll()
        Dim dt As New DataTable
        Dim cuentasList = compraSA.GetResumenCuentasXCobrarTerminos(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, txtPeriodo.Value, moneda, estadocobro)


        dt.Columns.Add("idcliente", GetType(Integer))
        dt.Columns.Add("terminos", GetType(String))
        dt.Columns.Add("nrodoc", GetType(String))
        dt.Columns.Add("cliente", GetType(String))
        dt.Columns.Add("xcobrar", GetType(Decimal))
        dt.Columns.Add("pagos", GetType(Decimal))
        dt.Columns.Add("saldo", GetType(Decimal))

        If cuentasList.Count > 0 Then
            Dim SaldoPagosMN As Decimal = 0
            Dim SaldoPagosME As Decimal = 0
            For Each i In cuentasList
                SaldoPagosMN = 0
                SaldoPagosME = 0

                SaldoPagosMN = i.ImporteNacional - i.PagoSumaMN
                SaldoPagosME = i.ImporteExtranjero - i.PagoSumaME

                'nota de credito
                SaldoPagosMN = SaldoPagosMN '- i.PagoNotaCreditoMN + i.PagoNotaDebitoMN
                SaldoPagosME = SaldoPagosME '- i.PagoNotaCreditoME + i.PagoNotaDebitoME

                Dim dr As DataRow = dt.NewRow()
                dr(0) = i.idCliente
                dr(1) = i.terminos
                dr(2) = i.NroDocEntidad
                dr(3) = i.NombreEntidad

                Select Case cboMonedaProveedor.Text
                    Case "EXTRANJERA"
                        dr(4) = i.ImporteExtranjero
                        dr(5) = i.PagoSumaME + i.PagoNotaCreditoME
                        dr(6) = CDec(SaldoPagosME).ToString("N2")
                    Case Else
                        dr(4) = i.ImporteNacional
                        dr(5) = i.PagoSumaMN + i.PagoNotaCreditoMN
                        dr(6) = CDec(SaldoPagosMN).ToString("N2")
                End Select


                dt.Rows.Add(dr)
            Next
            GridClientes.DataSource = dt
            Me.GridClientes.TableOptions.ListBoxSelectionMode = SelectionMode.One

            'Select Case cboMonedaCobro.Text
            '    Case "NACIONAL"
            'dgvCobranzaCli.TableDescriptor.Columns("importeMN").Width = 70
            'dgvCobranzaCli.TableDescriptor.Columns("abonoMN").Width = 70
            'dgvCobranzaCli.TableDescriptor.Columns("saldoMN").Width = 70
            'dgvCobranzaCli.TableDescriptor.Columns("tipoCambio").Width = 0
            'dgvCobranzaCli.TableDescriptor.Columns("importeME").Width = 0
            'dgvCobranzaCli.TableDescriptor.Columns("abonoME").Width = 0
            'dgvCobranzaCli.TableDescriptor.Columns("saldoME").Width = 0
            'Case "EXTRANJERA"
            '    dgvCobranzaCli.TableDescriptor.Columns("tipoCambio").Width = 70
            '    dgvCobranzaCli.TableDescriptor.Columns("importeME").Width = 70
            '    dgvCobranzaCli.TableDescriptor.Columns("abonoME").Width = 70
            '    dgvCobranzaCli.TableDescriptor.Columns("saldoME").Width = 70
            '    dgvCobranzaCli.TableDescriptor.Columns("importeMN").Width = 0
            '    dgvCobranzaCli.TableDescriptor.Columns("abonoMN").Width = 0
            '    dgvCobranzaCli.TableDescriptor.Columns("saldoMN").Width = 0
            'End Select


        Else

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


    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Try
            If RBProveedor.Checked = True Then
                CuentasPorPagarCliente()
            ElseIf RBTodos.Checked = True Then

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub CuentasXCliente(moneda As String, estadocobro As String)

        dgvCobranzaCli.Table.Records.DeleteAll()

        Dim dt As New DataTable
        Dim cuentasList = compraSA.GetCobroPorCliente(New documentoventaAbarrotes With
                                                      {
                                                      .idEmpresa = Gempresas.IdEmpresaRuc,
                                                      .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                      .fechaDoc = Date.Now,
                                                      .moneda = moneda,
                                                      .idCliente = Integer.Parse(txtBuscarProveedorPago.Tag),
                                                      .estadoCobro = estadocobro
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

        dt.Columns.Add("idCliente")
        dt.Columns.Add("cliente")
        dt.Columns.Add("nroDocEntidad")

        Dim str As String
        If cuentasList.Count > 0 Then
            Dim SaldoPagosMN As Decimal = 0
            Dim SaldoPagosME As Decimal = 0
            For Each i In cuentasList


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
                dr(1) = str
                dr(2) = i.tipoVenta
                dr(3) = i.tipoDocumento
                dr(4) = i.serie
                dr(5) = i.numeroDoc
                Select Case i.moneda
                    Case CStr(1)
                        dr(6) = "NAC"
                    Case Else
                        dr(6) = "EXT"
                End Select
                dr(7) = i.ImporteNacional
                dr(8) = i.tipoCambio
                dr(9) = i.ImporteExtranjero
                dr(10) = i.PagoSumaMN + i.PagoNotaCreditoMN
                dr(11) = i.PagoSumaME + i.PagoNotaCreditoME
                'dr(12) = CDec(i.ImporteNacional - i.PagoSumaMN).ToString("N2")
                'dr(13) = CDec(i.ImporteExtranjero - i.PagoSumaME).ToString("N2")
                dr(12) = CDec(SaldoPagosMN).ToString("N2")
                dr(13) = CDec(SaldoPagosME).ToString("N2")

                Select Case i.estadoCobro
                    Case TIPO_VENTA.PAGO.COBRADO
                        dr(14) = "Saldado"
                    Case TIPO_VENTA.PAGO.PENDIENTE_PAGO
                        dr(14) = "Pendiente"
                End Select

                Select Case i.estadoCobro
                    Case TIPO_COMPRA.PAGO.PAGADO
                        dr(14) = "Saldado"
                    Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                        dr(14) = "Pendiente"
                End Select
                dr(15) = (i.idCliente)
                dr(16) = (i.NombreEntidad)
                dr(17) = (i.NroDocEntidad)
                dt.Rows.Add(dr)
            Next
            dgvCobranzaCli.DataSource = dt
            Me.dgvCobranzaCli.TableOptions.ListBoxSelectionMode = SelectionMode.One

            'Select Case cboMonedaCobro.Text
            '    Case "NACIONAL"
            dgvCobranzaCli.TableDescriptor.Columns("importeMN").Width = 70
            dgvCobranzaCli.TableDescriptor.Columns("abonoMN").Width = 70
            dgvCobranzaCli.TableDescriptor.Columns("saldoMN").Width = 70
            dgvCobranzaCli.TableDescriptor.Columns("tipoCambio").Width = 0
            dgvCobranzaCli.TableDescriptor.Columns("importeME").Width = 0
            dgvCobranzaCli.TableDescriptor.Columns("abonoME").Width = 0
            dgvCobranzaCli.TableDescriptor.Columns("saldoME").Width = 0
            'Case "EXTRANJERA"
            '    dgvCobranzaCli.TableDescriptor.Columns("tipoCambio").Width = 70
            '    dgvCobranzaCli.TableDescriptor.Columns("importeME").Width = 70
            '    dgvCobranzaCli.TableDescriptor.Columns("abonoME").Width = 70
            '    dgvCobranzaCli.TableDescriptor.Columns("saldoME").Width = 70
            '    dgvCobranzaCli.TableDescriptor.Columns("importeMN").Width = 0
            '    dgvCobranzaCli.TableDescriptor.Columns("abonoMN").Width = 0
            '    dgvCobranzaCli.TableDescriptor.Columns("saldoMN").Width = 0
            'End Select


        Else

        End If
    End Sub

    Private Sub CuentasPorPagarCliente()
        Dim dt As New DataTable
        Dim cuentasList = compraSA.GetCobroPorCliente(New documentoventaAbarrotes With
                                                      {
                                                      .idEmpresa = Gempresas.IdEmpresaRuc,
                                                      .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                      .fechaDoc = Date.Now,
                                                      .moneda = 1,
                                                      .idCliente = Integer.Parse(TextBoxExt1.Tag)
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

        dt.Columns.Add("idCliente")
        dt.Columns.Add("cliente")
        dt.Columns.Add("nroDocEntidad")

        Dim str As String
        If cuentasList.Count > 0 Then
            Dim SaldoPagosMN As Decimal = 0
            Dim SaldoPagosME As Decimal = 0
            For Each i In cuentasList


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
                dr(1) = str
                dr(2) = i.tipoVenta
                dr(3) = i.tipoDocumento
                dr(4) = i.serie
                dr(5) = i.numeroDoc
                Select Case i.moneda
                    Case CStr(1)
                        dr(6) = "NAC"
                    Case Else
                        dr(6) = "EXT"
                End Select
                dr(7) = i.ImporteNacional
                dr(8) = i.tipoCambio
                dr(9) = i.ImporteExtranjero
                dr(10) = i.PagoSumaMN + i.PagoNotaCreditoMN
                dr(11) = i.PagoSumaME + i.PagoNotaCreditoME
                'dr(12) = CDec(i.ImporteNacional - i.PagoSumaMN).ToString("N2")
                'dr(13) = CDec(i.ImporteExtranjero - i.PagoSumaME).ToString("N2")
                dr(12) = CDec(SaldoPagosMN).ToString("N2")
                dr(13) = CDec(SaldoPagosME).ToString("N2")

                Select Case i.estadoCobro
                    Case TIPO_VENTA.PAGO.COBRADO
                        dr(14) = "Saldado"
                    Case TIPO_VENTA.PAGO.PENDIENTE_PAGO
                        dr(14) = "Pendiente"
                End Select

                Select Case i.estadoCobro
                    Case TIPO_COMPRA.PAGO.PAGADO
                        dr(14) = "Saldado"
                    Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                        dr(14) = "Pendiente"
                End Select
                dr(15) = (i.idCliente)
                dr(16) = (i.NombreEntidad)
                dr(17) = (i.NroDocEntidad)
                dt.Rows.Add(dr)
            Next
            dgvCobranzaCli.DataSource = dt
            Me.dgvCobranzaCli.TableOptions.ListBoxSelectionMode = SelectionMode.One

            'Select Case cboMonedaCobro.Text
            '    Case "NACIONAL"
            dgvCobranzaCli.TableDescriptor.Columns("importeMN").Width = 70
            dgvCobranzaCli.TableDescriptor.Columns("abonoMN").Width = 70
            dgvCobranzaCli.TableDescriptor.Columns("saldoMN").Width = 70
            dgvCobranzaCli.TableDescriptor.Columns("tipoCambio").Width = 0
            dgvCobranzaCli.TableDescriptor.Columns("importeME").Width = 0
            dgvCobranzaCli.TableDescriptor.Columns("abonoME").Width = 0
            dgvCobranzaCli.TableDescriptor.Columns("saldoME").Width = 0
            'Case "EXTRANJERA"
            '    dgvCobranzaCli.TableDescriptor.Columns("tipoCambio").Width = 70
            '    dgvCobranzaCli.TableDescriptor.Columns("importeME").Width = 70
            '    dgvCobranzaCli.TableDescriptor.Columns("abonoME").Width = 70
            '    dgvCobranzaCli.TableDescriptor.Columns("saldoME").Width = 70
            '    dgvCobranzaCli.TableDescriptor.Columns("importeMN").Width = 0
            '    dgvCobranzaCli.TableDescriptor.Columns("abonoMN").Width = 0
            '    dgvCobranzaCli.TableDescriptor.Columns("saldoMN").Width = 0
            'End Select


        Else

        End If
    End Sub

    Private Sub TextBoxExt1_TextChanged(sender As Object, e As EventArgs) Handles TextBoxExt1.TextChanged
        TextBoxExt1.ForeColor = Color.Black
        TextBoxExt1.Tag = Nothing
        If TextBoxExt1.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            '    txtruc.Visible = True
        Else
            '    txtruc.Visible = False
        End If
    End Sub

    Private Sub pcLikeCategoria_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcLikeCategoria.CloseUp
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

                        'TextBoxExt1.Text = LsvProveedor.SelectedItems(0).SubItems(1).Text
                        'TextBoxExt1.Tag = LsvProveedor.SelectedItems(0).SubItems(0).Text
                        'TextBoxExt1.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)


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

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles LsvProveedor.MouseDoubleClick
        Me.pcLikeCategoria.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub TextBoxExt1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxExt1.KeyDown
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

    Private Sub ToolStrip2_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip2.ItemClicked

    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click

    End Sub

    Private Sub dgvCobranzaCli_TableControlCellClick(sender As Object, e As Grouping.GridTableControlCellClickEventArgs) Handles dgvCobranzaCli.TableControlCellClick

    End Sub

    Private Sub RBTodos_CheckedChanged(sender As Object, e As EventArgs) Handles RBTodos.CheckedChanged

    End Sub

    Private Sub txtBuscarProveedorPago_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarProveedorPago.TextChanged

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

            If ListaEntidad Is Nothing Then
                GetClientes()
            End If

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
        If txtBuscarProveedorPago.Text.Trim.Length > 0 Then

            If cboMonedaProveedor.Text = "NACIONAL" Then

                CuentasXCliente("1", TIPO_VENTA.PAGO.PENDIENTE_PAGO)
            ElseIf cboMonedaProveedor.Text = "EXTRANJERA" Then

                CuentasXCliente("2", TIPO_VENTA.PAGO.PENDIENTE_PAGO)
            End If

        End If
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click

    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        ConsultarDetallePagos()
    End Sub

    Private Sub ConsultarDetallePagos()
        Dim moneda As String = ""
        Dim r As Record = GridClientes.Table.CurrentRecord
        Select Case cboMonedaProveedor.Text
            Case "NACIONAL"
                moneda = "1"
            Case "EXTRANJERA"
                moneda = "2"
        End Select

        If r IsNot Nothing Then
            CuentasPorPagarSelCliente(moneda, Integer.Parse(r.GetValue("idcliente")), r.GetValue("terminos"))
        Else
            MessageBox.Show("Seleccionar un cliente!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        selRecordCliente = Nothing
        Dim moneda As String = ""
        Dim estadocobro As String = TIPO_VENTA.PAGO.PENDIENTE_PAGO

        Select Case cboMonedaProveedor.Text
            Case "NACIONAL"
                moneda = "1"
            Case "EXTRANJERA"
                moneda = "2"
        End Select


        If checkProveedor.Checked = True Then 'por cliente periodo
            If txtBuscarProveedorPago.Text.Trim.Length > 0 Then
                CuentasXCliente(moneda, estadocobro)
            End If
        ElseIf checkProveedor.Checked = False Then ' por periodo todos
            'CuentasPorPagar(moneda)
            CuentasPorPagarTerminos(moneda, estadocobro)
        End If
        selRecordCliente = Nothing
    End Sub

    Private Sub GridClientes_TableControlCellClick(sender As Object, e As Grouping.GridTableControlCellClickEventArgs) Handles GridClientes.TableControlCellClick
        If GridClientes.Table.CurrentRecord IsNot Nothing Then
            selRecordCliente = GridClientes.Table.CurrentRecord
        End If
    End Sub

    Private Sub GridClientes_TableControlDrawCell(sender As Object, e As GridTableControlDrawCellEventArgs) Handles GridClientes.TableControlDrawCell
        If e.Inner.Style.CellType = "PushButton" Then
            e.Inner.Cancel = True

            ' //Draw the Image in a cell.
            If e.Inner.ColIndex = 8 Then
                e.Inner.Style.Description = "Documentos"
                e.Inner.Style.TextColor = Color.Black
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3),
                                           New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6)
                    )
                '    e.Inner.Graphics.DrawImage(Me.ImageList1.Images(0), irect)
            End If
        End If
    End Sub

    Private Sub GridClientes_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles GridClientes.TableControlPushButtonClick
        Me.Cursor = Cursors.WaitCursor
        Dim precioSA As New detalleitemequivalencia_preciosSA
        Dim moneda As String = ""
        Try
            If e.Inner.ColIndex = 8 Then
                If GridClientes.Table.CurrentRecord IsNot Nothing Then

                    Dim idCliente = GridClientes.TableModel(e.Inner.RowIndex, 1).CellValue
                    Dim terminos = GridClientes.TableModel(e.Inner.RowIndex, 2).CellValue

                    Select Case cboMonedaProveedor.Text
                        Case "NACIONAL"
                            moneda = "1"
                        Case "EXTRANJERA"
                            moneda = "2"
                    End Select
                    CuentasPorPagarSelCliente(moneda, idCliente, terminos)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click

        Dim cajaUsuarioSA As New cajaUsuarioSA
        Try
            If Not IsNothing(Me.dgvCobranzaCli.Table.CurrentRecord) Then

                'Dim fechaAnt = New Date(txtPeriodo.Value.Year, CInt(txtPeriodo.Value.Month), 1)
                'fechaAnt = fechaAnt.AddMonths(-1)
                'Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
                'If periodoAnteriorEstaCerrado = False Then
                '    MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                '    Cursor = Cursors.Default
                '    Exit Sub
                'End If

                'Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = txtPeriodo.Value.Year, .mes = CInt(txtPeriodo.Value.Month)})
                'If Not IsNothing(valida) Then
                '    If valida = True Then
                '        MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '        Me.Cursor = Cursors.Default
                '        Exit Sub
                '    End If
                'End If

                Select Case selRecordCliente.GetValue("terminos")
                     'Select Case GridClientes.Table.CurrentRecord.GetValue("terminos")
                    Case "CRONOGRAMA"
                        If dgvCobranzaCli.Table.SelectedRecords.Count > 0 Then
                            Dim f As New FormCronogramaPagos(dgvCobranzaCli.Table.CurrentRecord.GetValue("idDocumento"))
                            f.Saldo = CDec(dgvCobranzaCli.Table.CurrentRecord.GetValue("saldoMN"))
                            f.txtruc.Text = dgvCobranzaCli.Table.CurrentRecord.GetValue("nroDocEntidad")
                            f.txtCliente.Text = dgvCobranzaCli.Table.CurrentRecord.GetValue("cliente")
                            f.txtCliente.Tag = CDec(dgvCobranzaCli.Table.CurrentRecord.GetValue("idCliente"))
                            f.StartPosition = FormStartPosition.CenterParent
                            f.ShowDialog(Me)
                            dgvCobranzaCli.Table.Records.DeleteAll()
                        End If

                    Case Else
                        If dgvCobranzaCli.Table.SelectedRecords.Count > 0 Then

                            '     Dim cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
                            '     If Not IsNothing(cajaUsuario) Then
                            '    GetGlobalMappingCajaUsuario(cajaUsuario, usuario.IDUsuario, usuario.CustomUsuario.Full_Name)

                            'btnNuevoPagoPago(dgvPagosVarios.Table.CurrentRecord.GetValue("moneda"), dgvPagosVarios.Table.CurrentRecord.GetValue("idDocumento"))

                            Dim f As New FormCobrarDoc(dgvCobranzaCli.Table.CurrentRecord.GetValue("idDocumento"))
                            ' f.Saldo = CDec(dgvCobranzaCli.Table.CurrentRecord.GetValue("saldoMN"))
                            If dgvCobranzaCli.Table.CurrentRecord.GetValue("moneda") = "EXT" Then
                                f.Saldo = CDec(dgvCobranzaCli.Table.CurrentRecord.GetValue("saldoME"))
                                f.Label30.Text = "Resúmen de los cobros: " & "Deuda en moneda extranjera"
                            Else
                                f.Saldo = CDec(dgvCobranzaCli.Table.CurrentRecord.GetValue("saldoMN"))
                                f.Label30.Text = "Resúmen de los cobros: " & "Deuda en Soles"
                            End If

                            f.txtruc.Text = dgvCobranzaCli.Table.CurrentRecord.GetValue("nroDocEntidad")
                            f.txtCliente.Text = dgvCobranzaCli.Table.CurrentRecord.GetValue("cliente")
                            f.txtCliente.Tag = CDec(dgvCobranzaCli.Table.CurrentRecord.GetValue("idCliente"))
                            f.StartPosition = FormStartPosition.CenterParent
                            f.ShowDialog(Me)

                            dgvCobranzaCli.Table.Records.DeleteAll()
                            'ConsultarDetallePagos()

                            '   RecargarConsulta()
                            'Else
                            '    MessageBox.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            'End If
                        End If
                End Select
                ToolStripButton2_Click(sender, e)
                'ConsultarDetallePagos()
            Else
                MessageBox.Show("Debe seleccionar una item!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Try
            If Not IsNothing(Me.dgvCobranzaCli.Table.CurrentRecord) Then
                If dgvCobranzaCli.Table.SelectedRecords.Count > 0 Then
                    Dim f As New FormHistorialCobros()
                    f.CargarHistorial(dgvCobranzaCli.Table.CurrentRecord.GetValue("idDocumento"))
                    f.txtNumero.Text = dgvCobranzaCli.Table.CurrentRecord.GetValue("serie") & "-" & dgvCobranzaCli.Table.CurrentRecord.GetValue("numero")
                    f.txtCliente.Text = dgvCobranzaCli.Table.CurrentRecord.GetValue("cliente")
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog(Me)
                End If
            Else
                MessageBox.Show("Debe seleccionar una item!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Atención!")
        End Try
    End Sub
    Dim filter As New GridExcelFilter()
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        GridClientes.TopLevelGroupOptions.ShowFilterBar = True
        GridClientes.NestedTableGroupOptions.ShowFilterBar = True
        GridClientes.ChildGroupOptions.ShowFilterBar = True
        For Each col As GridColumnDescriptor In GridClientes.TableDescriptor.Columns
            col.AllowFilter = True
        Next
        filter.AllowResize = True
        filter.AllowFilterByColor = True
        filter.EnableDateFilter = True
        filter.EnableNumberFilter = True

        GridClientes.OptimizeFilterPerformance = True
        GridClientes.ShowNavigationBar = True
        filter.WireGrid(GridClientes)

        '---------------------------------------------------------------------------------------


        dgvCobranzaCli.TopLevelGroupOptions.ShowFilterBar = True
        dgvCobranzaCli.NestedTableGroupOptions.ShowFilterBar = True
        dgvCobranzaCli.ChildGroupOptions.ShowFilterBar = True
        For Each col As GridColumnDescriptor In dgvCobranzaCli.TableDescriptor.Columns
            col.AllowFilter = True
        Next
        filter.AllowResize = True
        filter.AllowFilterByColor = True
        filter.EnableDateFilter = True
        filter.EnableNumberFilter = True

        dgvCobranzaCli.OptimizeFilterPerformance = True
        dgvCobranzaCli.ShowNavigationBar = True
        filter.WireGrid(dgvCobranzaCli)

    End Sub

    Private Sub CboMonedaProveedor_Click(sender As Object, e As EventArgs) Handles cboMonedaProveedor.Click

    End Sub

    Private Sub cboMonedaProveedor_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboMonedaProveedor.SelectedValueChanged
        GridClientes.Table.Records.DeleteAll()
        dgvCobranzaCli.Table.Records.DeleteAll()
        selRecordCliente = Nothing
        If cboMonedaProveedor.Text = "NACIONAL" Then

        Else

        End If
    End Sub

    Private Sub GridClientes_SelectedRecordsChanging(sender As Object, e As SelectedRecordsChangedEventArgs) Handles GridClientes.SelectedRecordsChanging
        If e.SelectedRecord IsNot Nothing Then
            selRecordCliente = e.SelectedRecord.Record
            dgvCobranzaCli.Table.Records.DeleteAll()
        Else
            selRecordCliente = Nothing
        End If
    End Sub
#End Region
End Class

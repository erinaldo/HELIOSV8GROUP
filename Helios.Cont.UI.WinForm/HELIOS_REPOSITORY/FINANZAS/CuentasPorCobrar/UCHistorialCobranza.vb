Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Tools

Public Class UCHistorialCobranza

#Region "Variables"
    '   Public Property opcionSel As String
    Public Property compraSA As New documentoVentaAbarrotesSA
    Public Property ListaEntidad As List(Of entidad)
    Public Property entidadSA As New entidadSA
#End Region


#Region "Constructors"
    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(dgvCobranzaCli, True, False, 10.0F)
        'dockingManager1.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.VS2010
        'dockingManager1.ShowCaption = True
        'dockingManager1.SetDockLabel(PanelfILTROS, "Búsqueda")
        'dockingManager1.DockControlInAutoHideMode(PanelfILTROS, DockingStyle.Left, 295)
        GetClientes()
        txtPeriodo.Value = DateTime.Now

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
#End Region

#Region "Metodos"

    Public Sub CuentasPorPagar(moneda As String)

        dgvCobranzaCli.Table.Records.DeleteAll()

        Dim dt As New DataTable
        Dim cuentasList = compraSA.GetCuentasXPagarTodoClientes(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, txtPeriodo.Value, moneda, TIPO_VENTA.PAGO.COBRADO)


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

    Private Sub CuentasXCliente(moneda As String)

        dgvCobranzaCli.Table.Records.DeleteAll()

        Dim dt As New DataTable
        Dim cuentasList = compraSA.GetCobroPorCliente(New documentoventaAbarrotes With
                                                      {
                                                      .idEmpresa = Gempresas.IdEmpresaRuc,
                                                      .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                      .fechaDoc = Date.Now,
                                                      .moneda = moneda,
                                                      .idCliente = Integer.Parse(txtBuscarProveedorPago.Tag),
                                                      .estadoCobro = TIPO_VENTA.PAGO.COBRADO
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

    Private Sub GetClientes()
        ListaEntidad = entidadSA.GetListarEntidad(New entidad With {.tipoEntidad = TIPO_ENTIDAD.CLIENTE, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})

        'ListaEntidad.Add(VarClienteGeneral)

        TextBoxExt1.Visible = True
        TextBoxExt1.ReadOnly = False
        TextBoxExt1.Enabled = True

    End Sub

#End Region

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
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

        End Try
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
                CuentasXCliente(moneda)
            End If
        ElseIf checkProveedor.Checked = False Then ' por periodo todos
            CuentasPorPagar(moneda)
        End If
    End Sub
End Class

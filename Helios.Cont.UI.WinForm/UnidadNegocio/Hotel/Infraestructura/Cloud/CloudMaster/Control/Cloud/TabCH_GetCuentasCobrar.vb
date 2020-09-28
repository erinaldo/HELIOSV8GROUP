Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Tools

Public Class TabCH_GetCuentasCobrar

#Region "Variables"
    '   Public Property opcionSel As String
    Public Property compraSA As New documentoVentaAbarrotesSA

#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(dgvCobranzaCli, True, False, 10.0F)
        FormatoGridAvanzado(GridClientes, True, False, 10.0F)


    End Sub
#End Region

#Region "Methdos"


    '    CuentasXCliente(moneda)

    'CuentasPorPagar(moneda)

    Public Sub CuentasPorPagar(moneda As String)

        dgvCobranzaCli.Table.Records.DeleteAll()

        Dim dt As New DataTable
        Dim cuentasList = compraSA.GetCuentasXPagarTodoClientes(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, "", moneda, "")


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

            dgvCobranzaCli.TableDescriptor.Columns("importeMN").Width = 70
            dgvCobranzaCli.TableDescriptor.Columns("abonoMN").Width = 70
            dgvCobranzaCli.TableDescriptor.Columns("saldoMN").Width = 70
            dgvCobranzaCli.TableDescriptor.Columns("tipoCambio").Width = 0
            dgvCobranzaCli.TableDescriptor.Columns("importeME").Width = 0
            dgvCobranzaCli.TableDescriptor.Columns("abonoME").Width = 0
            dgvCobranzaCli.TableDescriptor.Columns("saldoME").Width = 0

        Else

        End If

    End Sub

    Public Sub CuentasPorPagarSelCliente(moneda As String, intIdCliente As Integer, terminos As String)

        dgvCobranzaCli.Table.Records.DeleteAll()

        Dim dt As New DataTable
        Dim cuentasList = compraSA.GetCuentaCobrarSelCliente("", moneda, intIdCliente, terminos)


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

            dgvCobranzaCli.TableDescriptor.Columns("importeMN").Width = 70
            dgvCobranzaCli.TableDescriptor.Columns("abonoMN").Width = 70
            dgvCobranzaCli.TableDescriptor.Columns("saldoMN").Width = 70
            dgvCobranzaCli.TableDescriptor.Columns("tipoCambio").Width = 0
            dgvCobranzaCli.TableDescriptor.Columns("importeME").Width = 0
            dgvCobranzaCli.TableDescriptor.Columns("abonoME").Width = 0
            dgvCobranzaCli.TableDescriptor.Columns("saldoME").Width = 0

        Else

        End If

    End Sub

    Public Sub CuentasPorPagarTerminos(moneda As String)

        GridClientes.Table.Records.DeleteAll()
        Dim dt As New DataTable
        Dim cuentasList = compraSA.GetResumenCuentasXCobrarTerminos(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, "", moneda, "")


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
                dr(4) = i.ImporteNacional
                dr(5) = i.PagoSumaMN + i.PagoNotaCreditoMN
                dr(6) = CDec(SaldoPagosMN).ToString("N2")
                dt.Rows.Add(dr)
            Next
            GridClientes.DataSource = dt
            Me.GridClientes.TableOptions.ListBoxSelectionMode = SelectionMode.One

        Else

        End If

    End Sub


#End Region

#Region "Events"
    'CuentasPorPagarCliente()

    Private Sub CuentasXCliente(moneda As String)

        dgvCobranzaCli.Table.Records.DeleteAll()

        Dim dt As New DataTable
        Dim cuentasList = compraSA.GetCobroPorCliente(New documentoventaAbarrotes With
                                                      {
                                                      .idEmpresa = Gempresas.IdEmpresaRuc,
                                                      .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                      .fechaDoc = Date.Now,
                                                      .moneda = moneda,
                                                      .idCliente = Integer.Parse(1)
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





    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs)
        ConsultarDetallePagos()
    End Sub

    Private Sub ConsultarDetallePagos()
        Dim moneda As String = ""
        Dim r As Record = GridClientes.Table.CurrentRecord

        moneda = "1"


        If r IsNot Nothing Then
            CuentasPorPagarSelCliente(moneda, Integer.Parse(r.GetValue("idcliente")), r.GetValue("terminos"))
        Else
            MessageBox.Show("Seleccionar un cliente!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
                    moneda = "1"
                    CuentasPorPagarSelCliente(moneda, idCliente, terminos)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs)

        Dim cajaUsuarioSA As New cajaUsuarioSA
        Try
            If Not IsNothing(Me.dgvCobranzaCli.Table.CurrentRecord) Then


                Select Case GridClientes.Table.CurrentRecord.GetValue("terminos")
                    Case "CRONOGRAMA"
                        If dgvCobranzaCli.Table.SelectedRecords.Count > 0 Then
                            Dim f As New FormCronogramaPagos(dgvCobranzaCli.Table.CurrentRecord.GetValue("idDocumento"))
                            f.Saldo = CDec(dgvCobranzaCli.Table.CurrentRecord.GetValue("saldoMN"))
                            f.txtruc.Text = dgvCobranzaCli.Table.CurrentRecord.GetValue("nroDocEntidad")
                            f.txtCliente.Text = dgvCobranzaCli.Table.CurrentRecord.GetValue("cliente")
                            f.txtCliente.Tag = CDec(dgvCobranzaCli.Table.CurrentRecord.GetValue("idCliente"))
                            f.StartPosition = FormStartPosition.CenterParent
                            f.ShowDialog(Me)
                        End If

                    Case Else
                        If dgvCobranzaCli.Table.SelectedRecords.Count > 0 Then

                            '     Dim cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
                            '     If Not IsNothing(cajaUsuario) Then
                            '    GetGlobalMappingCajaUsuario(cajaUsuario, usuario.IDUsuario, usuario.CustomUsuario.Full_Name)

                            'btnNuevoPagoPago(dgvPagosVarios.Table.CurrentRecord.GetValue("moneda"), dgvPagosVarios.Table.CurrentRecord.GetValue("idDocumento"))

                            Dim f As New FormCobrarDoc(dgvCobranzaCli.Table.CurrentRecord.GetValue("idDocumento"))
                            f.Saldo = CDec(dgvCobranzaCli.Table.CurrentRecord.GetValue("saldoMN"))
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

            Else
                MessageBox.Show("Debe seleccionar una item!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs)
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
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs)
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
#End Region
End Class

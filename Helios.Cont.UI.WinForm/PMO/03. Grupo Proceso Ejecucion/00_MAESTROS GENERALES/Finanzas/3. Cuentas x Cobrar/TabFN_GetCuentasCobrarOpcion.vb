Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid
Public Class TabFN_GetCuentasCobrarOpcion

#Region "Variables"
    '   Public Property opcionSel As String
    Public Property compraSA As New documentoVentaAbarrotesSA
#End Region

#Region "Constructors"
    Public Sub New(opcion As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(dgvCobranzaCli, True, False, 10.0F)
        '   opcionSel = opcion



        If opcion = "0-30V" Or opcion = "31-60V" Or opcion = "61+masV" Then
            GetVentaxCobrarVenc(opcion)
        Else

            CuentasPorPagar(opcion)




        End If


    End Sub

#End Region

#Region "Methods"

    Public Sub GetVentaxCobrarVenc(opcionSel As String)
        Dim dt As New DataTable
        Dim cuentasList = compraSA.GetVentaxCobrarVenc(New Business.Entity.documentoventaAbarrotes With
                                                            {
                                                            .idEmpresa = Gempresas.IdEmpresaRuc,
                                                            .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                            .fechaDoc = Date.Now,
                                                            .moneda = "1"
                                                            }, opcionSel)


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


    Public Sub CuentasPorPagar(opcionSel As String)
        Dim dt As New DataTable
        Dim cuentasList = compraSA.GetComprasPorCobrarOpcion(New Business.Entity.documentoventaAbarrotes With
                                                            {
                                                            .idEmpresa = Gempresas.IdEmpresaRuc,
                                                            .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                            .fechaDoc = Date.Now,
                                                            .moneda = "1"
                                                            }, opcionSel)


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

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
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

                If dgvCobranzaCli.Table.SelectedRecords.Count > 0 Then

                    Dim cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
                    If Not IsNothing(cajaUsuario) Then
                        GetGlobalMappingCajaUsuario(cajaUsuario, usuario.IDUsuario, usuario.CustomUsuario.Full_Name)
                        'btnNuevoPagoPago(dgvPagosVarios.Table.CurrentRecord.GetValue("moneda"), dgvPagosVarios.Table.CurrentRecord.GetValue("idDocumento"))
                        Dim f As New FormCobrarDoc(dgvCobranzaCli.Table.CurrentRecord.GetValue("idDocumento"))
                        f.Saldo = CDec(dgvCobranzaCli.Table.CurrentRecord.GetValue("saldoMN"))
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ShowDialog(Me)

                    Else
                        MessageBox.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If
            Else
                MessageBox.Show("Debe seleccionar una item!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click

    End Sub
#End Region

#Region "Events"

#End Region

End Class

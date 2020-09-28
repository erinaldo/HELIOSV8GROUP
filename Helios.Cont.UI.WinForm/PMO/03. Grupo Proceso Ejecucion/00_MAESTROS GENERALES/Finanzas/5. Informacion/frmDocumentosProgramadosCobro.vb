Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Public Class frmDocumentosProgramadosCobro

    Inherits frmMaster

#Region "Attributes"
    Dim selectionColl As New Hashtable()
    Dim hoveredIndex As Integer = 0
#End Region
#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridPequeño(dgvCobranzaCli, True)
        txtPeriodo.Value = New DateTime(AnioGeneral, MesGeneral, 1)
    End Sub
#End Region

#Region "Metodos"
    Private Sub UbicarVentaNroSerie(RucCliente As Integer, intMoneda As String)
        Dim documentoVentaSA As New documentoVentaAbarrotesSA
        Dim documentoVenta As New List(Of documentoventaAbarrotes)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        'Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodo.Value.Month)) & "/" & txtPeriodo.Value.Year

        Dim strPeriodo = New DateTime(txtPeriodo.Value.Year, txtPeriodo.Value.Month, 1)

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

        documentoVenta = documentoVentaSA.UbicarVentaPorClienteXperiodo2(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, RucCliente, strPeriodo, intMoneda)
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
                dr(10) = i.PagoSumaMN
                dr(11) = i.PagoSumaME
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

                dr(15) = i.conteoCuotas

                dt.Rows.Add(dr)
            Next
            dgvCobranzaCli.DataSource = dt
            Me.dgvCobranzaCli.TableOptions.ListBoxSelectionMode = SelectionMode.One

            Select Case cboMonedaCobro.Text
                Case "NACIONAL"
                    dgvCobranzaCli.TableDescriptor.Columns("importeMN").Width = 70
                    dgvCobranzaCli.TableDescriptor.Columns("abonoMN").Width = 70
                    dgvCobranzaCli.TableDescriptor.Columns("saldoMN").Width = 70
                    dgvCobranzaCli.TableDescriptor.Columns("tipoCambio").Width = 0
                    dgvCobranzaCli.TableDescriptor.Columns("importeME").Width = 0
                    dgvCobranzaCli.TableDescriptor.Columns("abonoME").Width = 0
                    dgvCobranzaCli.TableDescriptor.Columns("saldoME").Width = 0
                Case "EXTRANJERA"
                    dgvCobranzaCli.TableDescriptor.Columns("tipoCambio").Width = 70
                    dgvCobranzaCli.TableDescriptor.Columns("importeME").Width = 70
                    dgvCobranzaCli.TableDescriptor.Columns("abonoME").Width = 70
                    dgvCobranzaCli.TableDescriptor.Columns("saldoME").Width = 70
                    dgvCobranzaCli.TableDescriptor.Columns("importeMN").Width = 0
                    dgvCobranzaCli.TableDescriptor.Columns("abonoMN").Width = 0
                    dgvCobranzaCli.TableDescriptor.Columns("saldoMN").Width = 0
            End Select


        Else

        End If
    End Sub
#End Region

    Private Sub frmDocumentosProgramadosCobro_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonAdv15_Click(sender As Object, e As EventArgs) Handles ButtonAdv15.Click
        Me.Cursor = Cursors.WaitCursor
        If txtBeneficiario.Text.Trim.Length > 0 Then
            Select Case cboMonedaCobro.Text
                Case "NACIONAL"
                    UbicarVentaNroSerie(txtidBeneficiario.Text, "1")
                    'UbicarVentaNroSeriePago(txtBuscarProveedorPago.Tag, "1")
                Case "EXTRANJERA"
                    UbicarVentaNroSerie(txtidBeneficiario.Text, "2")
            End Select
        Else
            'lblEstado.Text = "Seleccione un cliente antes de realizar la tarea!"
            'PanelError.Visible = True
            'Timer1.Enabled = True
            'TiempoEjecutar(10)
            MessageBox.Show("Seleccione un cliente antes de realizar la tarea!")
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor

        If Not IsNothing(dgvCobranzaCli.Table.CurrentRecord) Then

            Dim f As New frmDetalleCuotas
            f.UbicarCuotasPorDocumento(dgvCobranzaCli.Table.CurrentRecord.GetValue("idDocumento"))
            f.txtCliente.Text = txtBeneficiario.Text
            f.txtSerie.Text = dgvCobranzaCli.Table.CurrentRecord.GetValue("serie")
            f.txtNumero.Text = dgvCobranzaCli.Table.CurrentRecord.GetValue("numero")
            f.txtImporteCompramn.Value = dgvCobranzaCli.Table.CurrentRecord.GetValue("importeMN")
            f.txtImporteComprame.Value = dgvCobranzaCli.Table.CurrentRecord.GetValue("importeME")
            f.txtMoneda.Text = dgvCobranzaCli.Table.CurrentRecord.GetValue("moneda")

            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()



        Else
            ' MessageBox.Show("Seleccione un Item a Editar")
            MessageBox.Show("Seleccione un Documento!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub
End Class
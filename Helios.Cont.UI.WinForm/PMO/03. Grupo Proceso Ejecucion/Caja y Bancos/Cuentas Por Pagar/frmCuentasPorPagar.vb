Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmCuentasPorPagar
    Inherits frmMaster

#Region "Métodos"
    Public Sub UbicarVenta(strFiltro As String)
        Dim ventaSA As New documentoVentaAbarrotesSA
        Dim venta As New documentoventaAbarrotes
        Dim ClienteSA As New entidadSA
        Dim DocumentoCajaDetalleSA As New DocumentoCajaDetalleSA
        Dim cajadetalle As New documentoCajaDetalle

        Dim entidad As New entidad
        Try
            'venta = ventaSA.GetObtenerVentaPorNumeroComprobante(GEstableciento.IdEstablecimiento, "12/2014", TIPO_VENTA.VENTA_AL_CREDITO, txtIdComprobante.Text, strFiltro)
            'If Not IsNothing(venta) Then
            cajadetalle = DocumentoCajaDetalleSA.SumaCobroPorDocumentoPagos(GEstableciento.IdEstablecimiento, txtIdComprobante.Text, strFiltro, txtSerieFiltro.Text)
            If Not IsNothing(cajadetalle) Then
                With cajadetalle
                    txtPeriodo.Text = .FechaPeriodo
                    lblIdDocumento.Text = .idDocumento
                    txtFechaVenta.Text = .fechaDoc
                    txtTipoDoc.Text = .tipoDocumento
                    txtNumDoc.Text = .serie & "-" & .numeroDocNormal
                    txtTipoCambio.Text = .tipoCambioTransacc
                    If .EstadoCobro = TIPO_COMPRA.PAGO.PAGADO Then
                        rbPagado.Checked = True
                    Else
                        rbEnTramite.Checked = True
                    End If

                    entidad = ClienteSA.UbicarEntidadPorID(.idCliente).FirstOrDefault
                    If Not IsNothing(entidad) Then
                        With entidad
                            lblIdCliente.Text = .idEntidad
                            txtCliente.Text = .nombreCompleto
                            txtRucCliente.Text = .nrodoc
                            txtCuentaCliente.Text = .cuentaAsiento
                        End With
                    Else
                        lblIdCliente.Text = String.Empty
                        txtCliente.Text = String.Empty
                        txtRucCliente.Text = String.Empty
                        txtCuentaCliente.Text = String.Empty
                    End If
                    txtMoneda.Text = .moneda
                    txtIgv.Text = .tasaIgv
                    txtImportemn.Text = FormatNumber(.ImporteNacional, 2)
                    txtImporteme.Text = FormatNumber(.ImporteExtranjero, 2)
                    lblImporteACuenta.Text = FormatNumber(.montoSoles, 2)
                    lblImporteACuentame.Text = FormatNumber(.montoUsd, 2)
                    If .TipoCompra = TIPO_COMPRA.COMPRA_AL_CREDITO Then
                        txtTipoCompra.Text = "Compra Al crédito"
                    ElseIf .TipoCompra = TIPO_COMPRA.COMPRA_PAGADA Then
                        txtTipoCompra.Text = "Compra Pagada"
                    End If

                    lblSaldo.Text = Math.Round(CDec(.ImporteNacional) - CDec(.montoSoles), 2)
                    lblSaldome.Text = Math.Round(CDec(.ImporteExtranjero) - CDec(.montoUsd), 2)

                    ObtenerPorDetails(lblIdDocumento.Text, lsvDetalleItems)
                End With
            Else
                For Each x In GroupBox1.Controls
                    If TypeOf x Is System.Windows.Forms.TextBox Then x.Text = ""
                Next
            End If


            '  End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ObtenerPorDetails(strDocumentoAfectado As Integer, lsvDetalleItems As ListView)

        Dim objLista As New DocumentoCajaDetalleSA
        Dim saldomn As Decimal = 0
        Dim saldome As Decimal = 0

        Dim cTotalmn As Decimal = 0
        Dim cTotalme As Decimal = 0
        Dim cCreditomn As Decimal = 0
        Dim cCreditome As Decimal = 0
        Dim cDebitomn As Decimal = 0
        Dim cDebitome As Decimal = 0

        Try
            lsvDetalleItems.Columns.Clear()
            lsvDetalleItems.Items.Clear()
            lsvDetalleItems.Columns.Add("ID", 0) '0
            lsvDetalleItems.Columns.Add("Descripción", 250) '01
            lsvDetalleItems.Columns.Add("Deuda M.N.", 100, HorizontalAlignment.Right) '02
            lsvDetalleItems.Columns.Add("Deuda M.E.", 100, HorizontalAlignment.Right) '03

            lsvDetalleItems.Columns.Add("Nota CR.mn.", 100, HorizontalAlignment.Right) '04
            lsvDetalleItems.Columns.Add("Nota CR.me.", 100, HorizontalAlignment.Right) '05

            lsvDetalleItems.Columns.Add("Nota DB.mn.", 100, HorizontalAlignment.Right) '06
            lsvDetalleItems.Columns.Add("Nota DB.me.", 100, HorizontalAlignment.Right) '07

            lsvDetalleItems.Columns.Add("A Cuenta M.N.", 100, HorizontalAlignment.Right) '08
            lsvDetalleItems.Columns.Add("A cuenta M.E.", 100, HorizontalAlignment.Right) '09
            lsvDetalleItems.Columns.Add("Saldo M.N.", 100, HorizontalAlignment.Right) '10
            lsvDetalleItems.Columns.Add("Saldo M.E.", 100, HorizontalAlignment.Right) '11
            lsvDetalleItems.Columns.Add("Cancelado", 100, HorizontalAlignment.Center) '12
            For Each i As documentoCajaDetalle In objLista.ObtenerCuentasPorPagarPorDetails(strDocumentoAfectado)
                'saldomn = Math.Round(i.MontoDeudaSoles - i.MontoPagadoSoles, 2)
                'saldome = Math.Round(i.MontoDeudaUSD - i.MontoPagadoUSD, 2)

                cTotalmn = Math.Round(CDec(i.MontoDeudaSoles) - CDec(i.notaCreditoMN) + CDec(i.notaDebitoMN) - CDec(i.MontoPagadoSoles), 2)
                cTotalme = Math.Round(CDec(i.MontoDeudaUSD) - CDec(i.notaCreditoME) + CDec(i.notaDebitoME) - CDec(i.MontoPagadoUSD), 2)
                saldomn += cTotalmn
                saldome += cTotalme
                Dim n As New ListViewItem(i.idItem)
                n.SubItems.Add(i.DetalleItem)
                n.SubItems.Add(i.MontoDeudaSoles.ToString("N2"))
                n.SubItems.Add(i.MontoDeudaUSD.ToString("N2"))
                n.SubItems.Add(i.notaCreditoMN.ToString("N2"))
                n.SubItems.Add(i.notaCreditoME.ToString("N2"))
                n.SubItems.Add(i.notaDebitoMN.ToString("N2"))
                n.SubItems.Add(i.notaDebitoME.ToString("N2"))

                If TabControl1.SelectedTab Is TabPage2 Then

                    If txtTipoCompra.Text = "Compra Pagada" Then
                        n.SubItems.Add(cTotalmn.ToString("N2"))
                        n.SubItems.Add(cTotalme.ToString("N2"))
                        n.SubItems.Add(0)
                        n.SubItems.Add(0)
                        n.SubItems.Add("S")
                    ElseIf txtTipoCompra.Text = "Compra Al crédito" Then
                        n.SubItems.Add(i.MontoPagadoSoles.ToString("N2"))
                        n.SubItems.Add(i.MontoPagadoUSD.ToString("N2"))
                        n.SubItems.Add(cTotalmn.ToString("N2"))
                        n.SubItems.Add(cTotalme.ToString("N2"))
                        n.SubItems.Add(IIf(Mid(cTotalmn, 1, 1) = 0, "S", "N"))
                    End If

                ElseIf TabControl1.SelectedTab Is TabPage1 Then
                    If lsvDocs.SelectedItems(0).SubItems(12).Text = "Compra Pagada" Then
                        n.SubItems.Add(cTotalmn.ToString("N2"))
                        n.SubItems.Add(cTotalme.ToString("N2"))
                        n.SubItems.Add(0)
                        n.SubItems.Add(0)
                        n.SubItems.Add("S")
                    ElseIf lsvDocs.SelectedItems(0).SubItems(12).Text = "Compra Al crédito" Then
                        n.SubItems.Add(i.MontoPagadoSoles.ToString("N2"))
                        n.SubItems.Add(i.MontoPagadoUSD.ToString("N2"))
                        n.SubItems.Add(cTotalmn.ToString("N2"))
                        n.SubItems.Add(cTotalme.ToString("N2"))
                        n.SubItems.Add(IIf(cTotalmn <= 0, "S", "N"))
                    End If
                End If
                lsvDetalleItems.Items.Add(n)
            Next
            lblPagoMN.Text = saldomn.ToString("N2")
            lblPagoME.Text = saldome.ToString("N2")
            lblSaldo.Text = saldomn.ToString("N2")
            lblSaldome.Text = saldome.ToString("N2")
        Catch ex As Exception
            MsgBox("Error al obtener datos.!" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del Sistema.!")
        End Try
    End Sub

    Sub ProveedoresShows()
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        datos.Clear()
        'With frmModalEntidades
        '    .lblTipo.Text = TIPO_ENTIDAD.PROVEEDOR
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        '    If datos.Count > 0 Then
        '        lsvCanasta.Items.Clear()
        '        txtRuc.Text = datos(0).NroDoc
        '        txtCuentaProv.Text = datos(0).Cuenta
        '        txtNomProveedor.Text = datos(0).NombreEntidad
        '        lblIdCli.Text = datos(0).ID
        '        UbicarDocumentosPorProveedor(datos(0).ID, lblPeriodo.Text)

        '        If lsvDocs.Items.Count > 0 Then
        '            lsvDocs.Items(0).Selected = True
        '        End If
        '    End If
        'End With

        Me.Cursor = Cursors.Arrow
    End Sub

    Public Sub UbicarDocumentosPorProveedor(strProveedor As String, strPeriodo As String)
        Dim docCajaSA As New DocumentoCajaDetalleSA
        Dim vSaldo As Decimal = 0
        Dim vSaldome As Decimal = 0
        lsvDocs.Items.Clear()
        For Each i As documentoCajaDetalle In docCajaSA.SumaPagosPorProveedor(GEstableciento.IdEstablecimiento, strProveedor, strPeriodo)

            vSaldo = Math.Round(CDec(i.ImporteNacional) - CDec(i.montoSoles), 2)
            vSaldome = Math.Round(CDec(i.ImporteExtranjero) - CDec(i.montoUsd), 2)
            Dim n As New ListViewItem(i.idDocumento)
            n.UseItemStyleForSubItems = False
            n.SubItems.Add(i.tipoDocumento)
            n.SubItems.Add(i.numeroDocNormal)
            With n.SubItems.Add(i.tipoCambioTransacc)
                .BackColor = Color.LavenderBlush
                .ForeColor = Color.DarkRed
                .Font = CreateFont("tahoma", 8, False, False, False)
            End With
            With n.SubItems.Add(FormatNumber(i.ImporteNacional, 2))
                .BackColor = Color.LavenderBlush
                .ForeColor = Color.DarkRed
                .Font = CreateFont("tahoma", 7.5, True, False, False)
            End With

            n.SubItems.Add(i.moneda).BackColor = Color.Yellow
            n.SubItems.Add(FormatNumber(i.ImporteExtranjero, 2)).BackColor = Color.AliceBlue
            n.SubItems.Add(i.EstadoCobro).Font = CreateFont("tahoma", 8, True, False, False)
            With n.SubItems.Add(i.montoSoles)
                .BackColor = Color.AliceBlue
                .ForeColor = Color.SteelBlue
            End With
            With n.SubItems.Add(i.montoUsd)
                .BackColor = Color.AliceBlue
                .ForeColor = Color.SteelBlue
            End With

            With n.SubItems.Add(vSaldo)
                .BackColor = Color.LavenderBlush
                .ForeColor = Color.DarkRed
                .Font = CreateFont("tahoma", 7.5, True, False, False)
            End With

            With n.SubItems.Add(vSaldome)
                .BackColor = Color.LavenderBlush
                .ForeColor = Color.DarkRed
                .Font = CreateFont("tahoma", 7.5, True, False, False)
            End With
            If i.TipoCompra = TIPO_COMPRA.COMPRA_PAGADA Then
                n.SubItems.Add("Compra Pagada")
            ElseIf i.TipoCompra = TIPO_COMPRA.COMPRA_AL_CREDITO Then
                n.SubItems.Add("Compra Al crédito")
            End If


            lsvDocs.Items.Add(n)
        Next
        lblDocsEnct.Text = lsvDocs.Items.Count
    End Sub
    Public Function CreateFont(ByVal fontName As String, _
                           ByVal fontSize As Integer, _
                           ByVal isBold As Boolean, _
                           ByVal isItalic As Boolean, _
                           ByVal isStrikeout As Boolean
                           ) As Drawing.Font

        Dim styles As FontStyle = FontStyle.Regular

        If (isBold) Then
            styles = styles Or FontStyle.Bold
        End If

        If (isItalic) Then
            styles = styles Or FontStyle.Italic
        End If

        If (isStrikeout) Then
            styles = styles Or FontStyle.Strikeout
        End If

        Dim newFont As New Drawing.Font(fontName, fontSize, styles, GraphicsUnit.Point)

        Return newFont

    End Function
#End Region

    Private Sub cboPeriodo_Click(sender As System.Object, e As System.EventArgs) Handles cboPeriodo.Click

    End Sub

    Private Sub cboPeriodo_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboPeriodo.SelectedIndexChanged
        Select Case cboPeriodo.Text
            Case "ENERO"
                lblPeriodo.Text = "01" & "/2014"
            Case "FEBRERO"
                lblPeriodo.Text = "02" & "/2014"
            Case "MARZO"
                lblPeriodo.Text = "03" & "/2014"
            Case "ABRIL"
                lblPeriodo.Text = "04" & "/2014"
            Case "MAYO"
                lblPeriodo.Text = "05" & "/2014"
            Case "JUNIO"
                lblPeriodo.Text = "06" & "/2014"
            Case "JULIO"
                lblPeriodo.Text = "07" & "/2014"
            Case "AGOSTO"
                lblPeriodo.Text = "08" & "/2014"
            Case "SETIEMBRE"
                lblPeriodo.Text = "09" & "/2014"
            Case "OCTUBRE"
                lblPeriodo.Text = "10" & "/2014"
            Case "NOVIEMBRE"
                lblPeriodo.Text = "11" & "/2014"
            Case "DICIEMBRE"
                lblPeriodo.Text = "12" & "/2014"
        End Select
        UbicarDocumentosPorProveedor(lblIdCli.Text, lblPeriodo.Text)
        ContextMenuStrip1.Hide()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Call ProveedoresShows()
    End Sub

    Private Sub lblPeriodo_Click(sender As System.Object, e As System.EventArgs) Handles lblPeriodo.Click

    End Sub

    Private Sub lblPeriodo_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lblPeriodo.MouseUp
        Dim p As Point = e.Location
        p.Offset(lblPeriodo.Bounds.Location)
        ContextMenuStrip1.Show(ToolStrip1.PointToScreen(p))
        cboPeriodo.DroppedDown = True
    End Sub

    Private Sub ToolStripButton3_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton3.Click
        If TabControl1.SelectedTab Is TabPage1 Then
            If lsvDocs.SelectedItems.Count > 0 Then
                With frmHistorialPagosMembresia
                    .lblIdDocumento.Text = lsvDocs.SelectedItems(0).SubItems(0).Text
                    .colFechaCObr.Text = "Fecha de Pago"
                    .ObtenerHistorialPagos(lsvDocs.SelectedItems(0).SubItems(0).Text)
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            End If
        End If

        If TabControl1.SelectedTab Is TabPage2 Then
            If txtCliente.Text.Trim.Length > 0 Then
                With frmHistorialPagosMembresia
                    .lblIdDocumento.Text = lblIdDocumento.Text
                    .colFechaCObr.Text = "Fecha de Pago"
                    .ObtenerHistorialPagos(lblIdDocumento.Text)
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            End If

        End If
    End Sub

    Private Sub frmCuentasPorPagar_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmCuentasPorPagar_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim cfecha As Date = DateTime.Now.Date

        lblPeriodo.Text = String.Format("{0:00}", Convert.ToInt32(cfecha.Month)) & "/" & PeriodoGeneral

        TabPage2.Parent = TabControl1
        TabPage1.Parent = Nothing
        ToolStripComboBox1.Text = "POR PROVEEDOR"
    End Sub

    Private Sub ToolStripComboBox1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripComboBox1.Click

    End Sub

    Private Sub ToolStripComboBox1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ToolStripComboBox1.SelectedIndexChanged
        If ToolStripComboBox1.Text = "POR DOCUMENTO" Then
            TabPage2.Parent = TabControl1
            TabPage1.Parent = Nothing
        ElseIf ToolStripComboBox1.Text = "POR PROVEEDOR" Then
            TabPage2.Parent = Nothing
            TabPage1.Parent = TabControl1
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs)
        '''''frmPMO.Panel3.Width = 249
        Dispose()
    End Sub
    Dim colSec As Integer
    Private Sub lsvDocs_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lsvDocs.SelectedIndexChanged
        If lsvDocs.SelectedItems.Count > 0 Then
            colSec = lsvDocs.SelectedItems(0).Index
            ObtenerPorDetails(lsvDocs.Items(colSec).SubItems(0).Text, lsvCanasta)
            ' colSec = lsvDocs.SelectedItems(0).Index

        Else
            lsvCanasta.Items.Clear()
        End If
    End Sub

    Private Sub txtNumDocFiltro_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtNumDocFiltro.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtSerieFiltro.Text.Trim.Length > 0 Then
                If txtNumDocFiltro.Text.Trim.Length > 0 Then
                    UbicarVenta(txtNumDocFiltro.Text.Trim)
                End If
            Else
                txtSerieFiltro.Focus()
                txtSerieFiltro.SelectAll()
            End If

        End If
    End Sub

    Private Sub txtNumDocFiltro_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNumDocFiltro.TextChanged

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
        datos.Clear()
        'With frmModalComprobantesTabla
        '    .lblTipo.Text = "10"
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        '    If datos.Count > 0 Then
        '        txtIdComprobante.Text = datos(0).ID
        '        txtComprobante.Text = datos(0).NombreCampo
        '    End If
        'End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub NuevoToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles NuevoToolStripButton.Click
        If TabControl1.SelectedTab Is TabPage2 Then
            If rbPagado.Checked = True Then
                MsgBox("El documento ya se encuentra pagado.", MsgBoxStyle.Information, "Aviso del Sistema")
                Exit Sub
            End If

            Select Case txtMoneda.Text
                Case 1
                    With frmModalPago
                        .Estado = ENTITY_ACTIONS.INSERT
                        .lblIdProveedor.Text = lblIdCliente.Text
                        .lblNomProveedor.Text = txtNomProveedor.Text
                        .lblCuentaProveedor.Text = txtCuentaCliente.Text

                        .lblIdDocumento.Text = lblIdDocumento.Text
                        .ObtenerEFPredeterminada()
                        .nudImporteNac.Maximum = lblSaldo.Text
                        .lblDeudaPendiente.Text = lblSaldo.Text
                        .lblDeudaPendienteme.Text = lblSaldome.Text
                        For Each i As ListViewItem In lsvDetalleItems.Items
                            If i.SubItems(12).Text = "N" Then
                                .dgvDetalleItems.Rows.Add(i.SubItems(0).Text, i.SubItems(1).Text, Nothing,
                                                          Nothing, i.SubItems(10).Text, i.SubItems(11).Text,
                                                          "0.00", "0.00", "0.00", "0.00", Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT)
                            End If
                        Next
                        .StartPosition = FormStartPosition.CenterParent
                        .ShowDialog()

                        UbicarVenta(txtNumDocFiltro.Text.Trim)
                    End With
                Case 2


            End Select
        ElseIf TabControl1.SelectedTab Is TabPage1 Then
            If lsvDocs.SelectedItems.Count > 0 Then

                If CDec(lblPagoMN.Text) <= 0 Then
                    MsgBox("El documento ya se encuentra pagado.", MsgBoxStyle.Information, "Aviso del Sistema")
                    Exit Sub
                Else
                    Select Case lsvDocs.SelectedItems(0).SubItems(5).Text
                        Case 1
                            With frmModalPago
                                .Estado = ENTITY_ACTIONS.INSERT
                                .lblIdProveedor.Text = lblIdCli.Text
                                .lblNomProveedor.Text = txtNomProveedor.Text
                                .lblCuentaProveedor.Text = txtCuentaProv.Text
                                .lblIdDocumento.Text = lsvDocs.SelectedItems(0).SubItems(0).Text
                                .ObtenerEFPredeterminada()
                                .nudImporteNac.Maximum = CDec(lblPagoMN.Text)
                                .lblDeudaPendiente.Text = CDec(lblPagoMN.Text)
                                .lblDeudaPendienteme.Text = CDec(lblPagoME.Text)
                                For Each i As ListViewItem In lsvCanasta.Items
                                    If i.SubItems(12).Text = "N" Then
                                        .dgvDetalleItems.Rows.Add(i.SubItems(0).Text, i.SubItems(1).Text, Nothing,
                                                                  Nothing, i.SubItems(10).Text, i.SubItems(11).Text,
                                                                  "0.00", "0.00", "0.00", "0.00", Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT)
                                    End If
                                Next
                                .StartPosition = FormStartPosition.CenterParent
                                .ShowDialog()
                                lsvDocs.Items(colSec).Selected = True
                                lsvDocs.Items(colSec).Focused = True
                                lsvDocs.EnsureVisible(colSec)
                                lsvDocs.Focus()
                                ObtenerPorDetails(lsvDocs.Items(colSec).SubItems(0).Text, lsvCanasta)
                            End With
                        Case 2


                    End Select
                End If


            End If
        End If
    End Sub

    Private Sub ToolStripButton4_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton4.Click
        Me.Cursor = Cursors.WaitCursor
        UbicarDocumentosPorProveedor(lblIdCli.Text, lblPeriodo.Text)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStrip3_ItemClicked(sender As System.Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStrip3.ItemClicked

    End Sub

    Private Sub txtSerieFiltro_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtSerieFiltro.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtNumDocFiltro.Focus()
            txtNumDocFiltro.SelectAll()
        End If
    End Sub

    Private Sub txtSerieFiltro_LostFocus(sender As Object, e As System.EventArgs) Handles txtSerieFiltro.LostFocus
        If txtSerieFiltro.Text.Trim.Length > 0 Then
            txtSerieFiltro.Text = String.Format("{0:00000}", Convert.ToInt32(txtSerieFiltro.Text))
        End If

    End Sub

    Private Sub txtSerieFiltro_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtSerieFiltro.MouseClick
        txtSerieFiltro.Select(0, txtSerieFiltro.Text.Length)
    End Sub

    Private Sub txtSerieFiltro_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSerieFiltro.TextChanged

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        txtNumDocFiltro_KeyDown(sender, e)
    End Sub
End Class
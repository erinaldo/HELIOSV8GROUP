Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmCuentasPorCobrar
    Inherits frmMaster

#Region "Métodos"
    Private Sub ObtenerPorDetails(strDocumentoAfectado As Integer, lsvDetalleItems As ListView)

        Dim objLista As New DocumentoCajaDetalleSA
        Dim saldomn As Decimal = 0
        Dim saldome As Decimal = 0

        Try
            lsvDetalleItems.Columns.Clear()
            lsvDetalleItems.Items.Clear()
            lsvDetalleItems.Columns.Add("ID", 0) '0
            lsvDetalleItems.Columns.Add("Descripción", 250) '01
            lsvDetalleItems.Columns.Add("Deuda M.N.", 100, HorizontalAlignment.Right) '02
            lsvDetalleItems.Columns.Add("Deuda M.E.", 100, HorizontalAlignment.Right) '03

            lsvDetalleItems.Columns.Add("Nota M.N.", 100, HorizontalAlignment.Right) '04
            lsvDetalleItems.Columns.Add("Nota M.E.", 100, HorizontalAlignment.Right) '05

            lsvDetalleItems.Columns.Add("A Cuenta M.N.", 100, HorizontalAlignment.Right) '06
            lsvDetalleItems.Columns.Add("A cuenta M.E.", 100, HorizontalAlignment.Right) '07
            lsvDetalleItems.Columns.Add("Saldo M.N.", 100, HorizontalAlignment.Right) '08
            lsvDetalleItems.Columns.Add("Saldo M.E.", 100, HorizontalAlignment.Right) '09
            lsvDetalleItems.Columns.Add("Cancelado", 100, HorizontalAlignment.Center) '10
            For Each i As documentoCajaDetalle In objLista.ObtenerCuentasPorCobrarPorDetails(strDocumentoAfectado)
                saldomn = Math.Round(i.MontoDeudaSoles - i.MontoPagadoSoles, 2)
                saldome = Math.Round(i.MontoDeudaUSD - i.MontoPagadoUSD, 2)
                Dim n As New ListViewItem(i.idItem)
                n.SubItems.Add(i.DetalleItem)
                n.SubItems.Add(i.MontoDeudaSoles.ToString("N2"))
                n.SubItems.Add(i.MontoDeudaUSD.ToString("N2"))
                n.SubItems.Add(0)
                n.SubItems.Add(0)
                n.SubItems.Add(i.MontoPagadoSoles.ToString("N2"))
                n.SubItems.Add(i.MontoPagadoUSD.ToString("N2"))
                n.SubItems.Add(saldomn.ToString("N2"))
                n.SubItems.Add(saldome.ToString("N2"))
                n.SubItems.Add(IIf(Mid(saldomn, 1, 1) = 0, "S", "N"))
                lsvDetalleItems.Items.Add(n)
            Next

        Catch ex As Exception
            MsgBox("Error al obtener datos.!" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del Sistema.!")
        End Try
    End Sub

    Public Sub UbicarDocumentosPorCliente(strCliente As String, strPeriodo As String)
        Dim docCajaSA As New DocumentoCajaDetalleSA
        Dim vSaldo As Decimal = 0
        Dim vSaldome As Decimal = 0
        lsvDocs.Items.Clear()
        For Each i As documentoCajaDetalle In docCajaSA.SumaCobroPorCliente(GEstableciento.IdEstablecimiento, strCliente, strPeriodo)

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
            cajadetalle = DocumentoCajaDetalleSA.SumaCobroPorDocumento(GEstableciento.IdEstablecimiento, txtIdComprobante.Text, strFiltro)
            If Not IsNothing(cajadetalle) Then
                With cajadetalle
                    txtPeriodo.Text = .FechaPeriodo
                    lblIdDocumento.Text = .idDocumento
                    txtFechaVenta.Text = .fechaDoc
                    txtTipoDoc.Text = .tipoDocumento
                    txtNumDoc.Text = .serie & "-" & .numeroDocNormal
                    txtTipoCambio.Text = .tipoCambioTransacc
                    If .EstadoCobro = TIPO_VENTA.PAGO.COBRADO Then
                        rbPagado.Checked = True
                    Else
                        rbEnTramite.Checked = True
                    End If

                    entidad = ClienteSA.UbicarEntidadPorID(.idCliente).FirstOrDefault
                    If Not IsNothing(entidad) Then
                        With entidad
                            lblIdProveedor.Text = .idEntidad
                            txtCliente.Text = .nombreCompleto
                            txtRucCliente.Text = .nrodoc
                            txtCuentaCliente.Text = .cuentaAsiento
                        End With
                    Else
                        lblIdProveedor.Text = String.Empty
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
#End Region

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs)
        '''''frmPMO.Panel3.Width = 249
        Dispose()
    End Sub

    Private Sub GroupBox1_Enter(sender As System.Object, e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub GuardarToolStripButton_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub AbrirToolStripButton_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub PagadaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub AlCreditoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub txtNumDocFiltro_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtNumDocFiltro.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtNumDocFiltro.Text.Trim.Length > 0 Then
                UbicarVenta(txtNumDocFiltro.Text.Trim)
            End If
        End If
    End Sub

    Private Sub txtNumDocFiltro_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNumDocFiltro.TextChanged

    End Sub

    Private Sub NuevoToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles NuevoToolStripButton.Click
        If TabControl1.SelectedTab Is TabPage2 Then
            If rbPagado.Checked = True Then
                MsgBox("El documento ya se encuentra pagado.", MsgBoxStyle.Information, "Aviso del Sistema")
                Exit Sub
            End If
            Select Case txtMoneda.Text
                Case 1
                    With frmModalCobro
                        .Estado = ENTITY_ACTIONS.INSERT
                        .lblIdCliente.Text = lblIdProveedor.Text
                        .lblNomCliente.Text = txtNomCliente.Text
                        .lblCuentaCliente.Text = txtCuentaCliente.Text

                        .lblIdDocumento.Text = lblIdDocumento.Text
                        .ObtenerEFPredeterminada()
                        .nudImporteNac.Maximum = lblSaldo.Text
                        .lblDeudaPendiente.Text = lblSaldo.Text
                        .lblDeudaPendienteme.Text = lblSaldome.Text
                        For Each i As ListViewItem In lsvDetalleItems.Items
                            If i.SubItems(10).Text = "N" Then
                                .dgvDetalleItems.Rows.Add(i.SubItems(0).Text, i.SubItems(1).Text, Nothing,
                                                          Nothing, i.SubItems(8).Text, i.SubItems(9).Text,
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
                Select Case lsvDocs.SelectedItems(0).SubItems(5).Text
                    Case 1
                        With frmModalCobro
                            .Estado = ENTITY_ACTIONS.INSERT
                            .lblIdCliente.Text = lblIdCli.Text
                            .lblNomCliente.Text = txtNomCliente.Text
                            .lblCuentaCliente.Text = txtCuentaCli.Text
                            .lblIdDocumento.Text = lsvDocs.SelectedItems(0).SubItems(0).Text
                            .ObtenerEFPredeterminada()
                            .nudImporteNac.Maximum = lsvDocs.SelectedItems(0).SubItems(10).Text
                            .lblDeudaPendiente.Text = lsvDocs.SelectedItems(0).SubItems(10).Text
                            .lblDeudaPendienteme.Text = lsvDocs.SelectedItems(0).SubItems(11).Text
                            For Each i As ListViewItem In lsvCanasta.Items
                                If i.SubItems(10).Text = "N" Then
                                    .dgvDetalleItems.Rows.Add(i.SubItems(0).Text, i.SubItems(1).Text, Nothing,
                                                              Nothing, i.SubItems(8).Text, i.SubItems(9).Text,
                                                              "0.00", "0.00", "0.00", "0.00", Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT)
                                End If
                            Next
                            .StartPosition = FormStartPosition.CenterParent
                            .ShowDialog()
                        End With
                    Case 2


                End Select
            End If
        End If



    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        ' Call ShowDoc()
        If txtIdComprobante.Text = "03" Then
            txtIdComprobante.Text = "01"
            txtComprobante.Text = "FACTURA"
        Else
            txtIdComprobante.Text = "03"
            txtComprobante.Text = "BOLETA DE VENTA"
        End If
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

    Private Sub Panel7_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs)

    End Sub
    Sub ProveedoresShows()
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        datos.Clear()
        'With frmModalEntidades
        '    .lblTipo.Text = TIPO_ENTIDAD.CLIENTE
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        '    If datos.Count > 0 Then
        '        lsvCanasta.Items.Clear()
        '        txtRuc.Text = datos(0).NroDoc
        '        txtCuentaCli.Text = datos(0).Cuenta
        '        txtNomCliente.Text = datos(0).NombreEntidad
        '        lblIdCli.Text = datos(0).ID
        '        UbicarDocumentosPorCliente(datos(0).ID, lblPeriodo.Text)

        '        If lsvDocs.Items.Count > 0 Then
        '            lsvDocs.Items(0).Selected = True
        '        End If
        '    End If
        'End With

        Me.Cursor = Cursors.Arrow
    End Sub
    Private Sub LinkLabel2_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Call ProveedoresShows()
    End Sub

    Private Sub lsvDocs_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lsvDocs.SelectedIndexChanged
        If lsvDocs.SelectedItems.Count > 0 Then
            ObtenerPorDetails(lsvDocs.SelectedItems(0).SubItems(0).Text, lsvCanasta)

        Else
            lsvCanasta.Items.Clear()
        End If
    End Sub

    Private Sub ToolStripComboBox1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripComboBox1.Click

    End Sub

    Private Sub frmCuentasPorCobrar_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmCuentasPorCobrar_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim cfecha As Date = DateTime.Now.Date
        lblPeriodo.Text = String.Format("{0:00}", Convert.ToInt32(cfecha.Month)) & "/" & cfecha.Year

        TabPage2.Parent = TabControl1
        TabPage1.Parent = Nothing
        ToolStripComboBox1.Text = "POR CLIENTE"
    End Sub

    Private Sub ToolStripComboBox1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ToolStripComboBox1.SelectedIndexChanged
        If ToolStripComboBox1.Text = "POR DOCUMENTO" Then
            TabPage2.Parent = TabControl1
            TabPage1.Parent = Nothing
        ElseIf ToolStripComboBox1.Text = "POR CLIENTE" Then
            TabPage2.Parent = Nothing
            TabPage1.Parent = TabControl1
        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Call ProveedoresShows()
    End Sub

    Private Sub ToolStripButton4_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton4.Click
        Me.Cursor = Cursors.WaitCursor
        UbicarDocumentosPorCliente(lblIdCli.Text, lblPeriodo.Text)
        Me.Cursor = Cursors.Arrow
    End Sub

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
        UbicarDocumentosPorCliente(lblIdCli.Text, lblPeriodo.Text)
        ContextMenuStrip1.Hide()
    End Sub

    Private Sub lblPeriodo_Click(sender As System.Object, e As System.EventArgs) Handles lblPeriodo.Click

    End Sub

    Private Sub lblPeriodo_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lblPeriodo.MouseUp
        Dim p As Point = e.Location
        p.Offset(lblPeriodo.Bounds.Location)
        ContextMenuStrip1.Show(ToolStrip1.PointToScreen(p))
        cboPeriodo.DroppedDown = True
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If txtNomCliente.Text.Trim.Length > 0 Then
            lblPeriodo.Enabled = True
        Else
            lblPeriodo.Enabled = False
        End If
    End Sub

    Private Sub lsvCanasta_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lsvCanasta.SelectedIndexChanged

    End Sub
End Class
Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Tools
Imports System.Collections
Imports Syncfusion.Windows.Forms.Grid
Imports System.Collections.Specialized
Imports Syncfusion.Grouping
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Grid.Grouping
Public Class frmModuloCobros
    Inherits frmMaster

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        EstadoPAgos()
        ' Add any initialization after the InitializeComponent() call.
        Me.WindowState = FormWindowState.Maximized
        dockingManager1.DockControlInAutoHideMode(Panel8, DockingStyle.Right, 565)
        dockingManager1.SetDockLabel(Panel8, "Ventas")
    End Sub

    Public Sub EstadoPAgos()
        Dim CompraSA As New documentoVentaAbarrotesSA
        Dim Compra As New documentoventaAbarrotes
        Dim documentoCaja As New List(Of documentoCaja)
        Dim documentoCajaSA As New DocumentoCajaSA

        Compra = CompraSA.GetSumaCuentasXCobrar(GEstableciento.IdEstablecimiento, "30")

        Label26.Text = FormatNumber(Compra.Monto30mn, 2)

        ' Compra = CompraSA.GetSumaCuentasXpagar(GEstableciento.IdEstablecimiento, "60")

        Label24.Text = FormatNumber(Compra.Monto60mn, 2)

        '  Compra = CompraSA.GetSumaCuentasXpagar(GEstableciento.IdEstablecimiento, "90")

        Label22.Text = FormatNumber(Compra.Monto90mn, 2)

        '   Compra = CompraSA.GetSumaCuentasXpagar(GEstableciento.IdEstablecimiento, "90+")

        Label4.Text = FormatNumber(Compra.Monto90Masmn, 2)

        Label11.Text = "S/." & FormatNumber(CDec(Label26.Text) + CDec(Label24.Text) + CDec(Label22.Text) + CDec(Label4.Text), 2)


        documentoCaja = documentoCajaSA.SumaxINgresosEgresosAnual()

        For Each i In documentoCaja
            Select Case i.tipoMovimiento
                Case "DC"
                    Label19.Text = "PENS/." & FormatNumber(i.montoSoles, 2)
                Case "PG"

            End Select
        Next
    End Sub

    Public Property TipoCompra() As String

    ''' <summary>
    ''' código de la compra de origen
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IDDocumentoCompra() As Integer
    Dim toolTip As Popup

    ''' <summary>
    ''' Control de usuario que muestra información de la compra
    ''' </summary>
    ''' <remarks></remarks>
    Dim ucInfoCompra As New ucInfoCompra

    ''' <summary>
    ''' Moneda de la compra de origen
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MonedaCompra() As String

#Region "Métodos"

    Private Sub UbicarCompraNroSerie(RucProveedor As String)
        Dim documentoCompraSA As New documentoVentaAbarrotesSA
        Dim documentoCompra As New List(Of documentoventaAbarrotes)
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

        documentoCompra = documentoCompraSA.UbicarVentaPorClienteXperiodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, RucProveedor, PeriodoGeneral)
        Dim str As String
        If Not IsNothing(documentoCompra) Then
            For Each i In documentoCompra
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

                dt.Rows.Add(dr)
            Next
            '   Me.GDB.DataSource = dt
            dgvCompra.DataSource = dt
            Me.dgvCompra.TableOptions.ListBoxSelectionMode = SelectionMode.One
            'GDB.GridBoundColumns.Item("idDocumento").Hidden = True
            'GDB.GridBoundColumns.Item("Fecha").Width = 100


            '    Me.GDB.ListBoxSelectionMode = SelectionMode.One

            'If Not theFilterBar Is Nothing And Not theFilterBar.Wired Then
            '    theFilterBar.WireGrid(Me.GDB)
            '    '    Me.label2.Text = ""
            'End If
            'Me.GDB.RefreshRange(GridRangeInfo.Row(1))
        Else

        End If
    End Sub

#Region "TIMER"
    Sub parpadeo()
        Static parpadear As Boolean

        'If Not parpadear Then
        '    lblEstado.ForeColor = lblEstado.BackColor
        '    lblEstado.BackColor = Color.Yellow
        'Else
        '    lblEstado.ForeColor = SystemColors.WindowText
        'End If

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

    Private Sub btnNuevoPago(strFormPago As String)
        Me.Cursor = Cursors.WaitCursor
        Dim objLista As New DocumentoCajaDetalleSA
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

        Select Case TipoCompra

            Case TIPO_VENTA.VENTA_NORMAL_CREDITO
                With frmCobros
                    '   .tbFormaPago.ToggleState = Tools.ToggleButtonState.Inactive
                    .dgvDetalleItems.Rows.Clear()
                    .manipulacionEstado = ENTITY_ACTIONS.INSERT
                    Select Case MonedaCompra
                        Case "NAC"
                            .lblIdProveedor = txtProveedor.ValueMember
                            .lblNomProveedor = txtProveedor.Text
                            .lblCuentaProveedor = "1212"
                            .lblIdDocumento.Text = IDDocumentoCompra

                            For Each i As documentoCajaDetalle In objLista.ObtenerCuentasPorCobrarPorDetails(IDDocumentoCompra)
                                detalle = detalleSA.SumaNotasXidPadreItemVentas(i.secuencia)
                                'cTotalmn = CDec(i.MontoDeudaSoles) - detalle.importe + detalle.ImporteDBMN - CDec(i.MontoPagadoSoles)
                                'cTotalme = CDec(i.MontoDeudaUSD) - detalle.importeUS + detalle.ImporteDBME - CDec(i.MontoPagadoUSD)
                                cTotalmn = CDec(i.MontoDeudaSoles) - detalle.importeMN - CDec(i.MontoPagadoSoles)
                                cTotalme = CDec(i.MontoDeudaUSD) - detalle.importeME - CDec(i.MontoPagadoUSD)
                                saldomn += cTotalmn
                                saldome += cTotalme
                                If cTotalmn > 0 Or cTotalme > 0 Then
                                    .dgvDetalleItems.Rows.Add(i.idItem, i.DetalleItem, Nothing,
                                                               Nothing, cTotalmn, cTotalme,
                                                               "0.00", "0.00", "0.00", "0.00", Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT)
                                End If

                            Next
                            txtImporteCompramn.Text = saldomn.ToString("N2")
                            txtImporteComprame.Text = saldome.ToString("N2")

                            '.nudImporteNac.Maximum = CDec(lblPagoMN.Text)
                            .lblDeudaPendiente.Text = CDec(txtImporteCompramn.Text)
                            .lblDeudaPendienteme.Text = CDec(txtImporteComprame.Text)
                        Case Else

                    End Select

                    If CDec(txtImporteCompramn.Text) <= 0 Then
                        '    MsgBox("El documento ya se encuentra pagado.", MsgBoxStyle.Information, "Aviso del Sistema")
                        lblEstado.Text = "El documento ya se encuentra pagado."
                        Timer1.Enabled = True
                        PanelError.Visible = True
                        TiempoEjecutar(10)
                        '   EditarEstadoPagoCompra(TIPO_COMPRA.PAGO.PAGADO)
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    Else
                        '    EditarEstadoPagoCompra(TIPO_COMPRA.PAGO.PENDIENTE_PAGO)

                        'If .TieneCuentaFinanciera = True Then
                        '.txtFechaComprobante.Value = New Date(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
                        '.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                        '.txtFechaComprobante.Enabled = False
                        '   .lblPerido.Text = PeriodoGeneral
                        .cboTipoDoc.Enabled = True
                        .cboTipoDoc.ReadOnly = False
                        .StartPosition = FormStartPosition.CenterParent
                        .ShowDialog()
                        'Else
                        '    lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
                        '    Timer1.Enabled = True
                        '    PanelError.Visible = True
                        '    TiempoEjecutar(10)
                        'End If
                    End If
                End With
        End Select
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ObtenerPorDetails(strDocumentoAfectado As Integer)

        Dim objLista As New DocumentoCajaDetalleSA
        Dim saldomn As Decimal = 0
        Dim saldome As Decimal = 0
        Dim detalle As New documentoventaAbarrotesDet
        Dim detalleSA As New documentoVentaAbarrotesDetSA

        Dim cTotalmn As Decimal = 0
        Dim cTotalme As Decimal = 0
        Dim cCreditomn As Decimal = 0
        Dim cCreditome As Decimal = 0
        Dim cDebitomn As Decimal = 0
        Dim cDebitome As Decimal = 0
        Dim dt As New DataTable()
        Try
            dt.Columns.Add("idItem", GetType(Integer))
            dt.Columns.Add("nombreItem", GetType(String))
            dt.Columns.Add("importeCompraMN", GetType(Decimal))
            dt.Columns.Add("importeCompraME", GetType(Decimal))
            dt.Columns.Add("acuentaMN", GetType(Decimal))
            dt.Columns.Add("acuentaME", GetType(Decimal))

            dt.Columns.Add("ndbMN", GetType(Decimal))
            dt.Columns.Add("ndbME", GetType(Decimal))

            dt.Columns.Add("ncMN", GetType(Decimal))
            dt.Columns.Add("ncME", GetType(Decimal))

            dt.Columns.Add("estado", GetType(String))
            dt.Columns.Add("secuencia", GetType(Integer))

            For Each i As documentoCajaDetalle In objLista.ObtenerCuentasPorCobrarPorDetails(strDocumentoAfectado)
                detalle = detalleSA.SumaNotasXidPadreItemVentas(i.secuencia)

                'cTotalmn = CDec(i.MontoDeudaSoles) - detalle.importe + detalle.ImporteDBMN - CDec(i.MontoPagadoSoles)
                'cTotalme = CDec(i.MontoDeudaUSD) - detalle.importeUS + detalle.ImporteDBME - CDec(i.MontoPagadoUSD)
                cTotalmn = CDec(i.MontoDeudaSoles) - detalle.importeMN - CDec(i.MontoPagadoSoles)
                cTotalme = CDec(i.MontoDeudaUSD) - detalle.importeME - CDec(i.MontoPagadoUSD)
                saldomn += cTotalmn
                saldome += cTotalme

                Dim dr As DataRow = dt.NewRow()
                dr(0) = i.idItem
                dr(1) = i.DetalleItem

                If TipoCompra = TIPO_COMPRA.COMPRA_DIRECTA_CON_RECEPCION Or TipoCompra = TIPO_COMPRA.COMPRA_DIRECTA_SIN_RECEPCION Then
                    dr(2) = i.MontoDeudaSoles
                    dr(3) = i.MontoDeudaUSD
                    dr(4) = 0
                    dr(5) = 0

                    dr(6) = detalle.ImporteDBMN
                    dr(7) = detalle.ImporteDBME
                    dr(8) = detalle.importeMN
                    dr(9) = detalle.importeME
                    dr(10) = "Pagado"
                    dr(11) = i.secuencia
                ElseIf TipoCompra = TIPO_VENTA.VENTA_NORMAL_CREDITO Then ' Or TipoCompra = TIPO_COMPRA.COMPRA_AL_CREDITO_CON_RECEPCION Then
                    dr(2) = i.MontoDeudaSoles
                    dr(3) = i.MontoDeudaUSD
                    dr(4) = i.MontoPagadoSoles
                    dr(5) = i.MontoPagadoUSD
                    dr(6) = detalle.ImporteDBMN
                    dr(7) = detalle.ImporteDBME
                    dr(8) = detalle.importeMN
                    dr(9) = detalle.importeME
                    dr(10) = IIf(cTotalmn <= 0, "Pagado", "Pendiente")
                    dr(11) = i.secuencia
                End If
                dt.Rows.Add(dr)
            Next
            '  Me.dgvDoc.BeginUpdate()
            Me.dgvDoc.DataSource = dt
            Me.dgvDoc.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended
            txtImporteCompramn.Text = saldomn.ToString("N2")
            txtImporteComprame.Text = saldome.ToString("N2")
        Catch ex As Exception
            MsgBox("Error al obtener datos.!" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del Sistema.!")
        End Try
    End Sub

    Public Sub CargarEntidadesXtipo(strTipo As String, strBusqueda As String)
        Dim entidadSA As New entidadSA
        Try

            'Me.lstEntidades.DataSource = entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, strTipo, strBusqueda)
            'Me.lstEntidades.DisplayMember = "nombreCompleto"
            'Me.lstEntidades.ValueMember = "idEntidad"
            lsvProveedor.Items.Clear()
            For Each i As entidad In entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, TIPO_ENTIDAD.CLIENTE, strBusqueda)
                Dim n As New ListViewItem(i.idEntidad)
                n.SubItems.Add(i.nombreCompleto)
                n.SubItems.Add(i.cuentaAsiento)
                n.SubItems.Add(i.nrodoc)
                lsvProveedor.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub
#End Region

    Private Sub txtProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProveedor.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Me.popupControlContainer1.ParentControl = Me.txtProveedor
            Me.popupControlContainer1.ShowPopup(Point.Empty)
            CargarEntidadesXtipo(TIPO_ENTIDAD.CLIENTE, txtProveedor.Text.Trim)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub popupControlContainer1_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles popupControlContainer1.BeforePopup
        Me.popupControlContainer1.BackColor = Color.FromArgb(227, 241, 254)
    End Sub

    Private Sub popupControlContainer1_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles popupControlContainer1.CloseUp
        Me.Cursor = Cursors.WaitCursor
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvProveedor.SelectedItems.Count > 0 Then
                Me.txtProveedor.Text = lsvProveedor.SelectedItems(0).SubItems(1).Text
                txtProveedor.ValueMember = lsvProveedor.SelectedItems(0).SubItems(0).Text
                txtRuc.Text = lsvProveedor.SelectedItems(0).SubItems(3).Text
                UbicarCompraNroSerie(txtRuc.Text)
                'ToolStripButton2.Text = ConteoChequesPendientes()
                'btnInfoComprasPendientes.Text = ConteoComprasPendientes()
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            If Me.txtProveedor.Text.Trim.Length > 0 Then
                TextBoxExt1.Select()
                TextBoxExt1.Focus()
            Else
                Me.txtProveedor.Focus()
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub TextBoxExt1_KeyDown(sender As Object, e As KeyEventArgs)
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtProveedor.Text.Trim.Length > 0 Then
                Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
                datos.Clear()
                e.SuppressKeyPress = True
                With frmVentasBusqueda
                    .RucProveedor = txtRuc.Text.Trim
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                    If datos.Count > 0 Then
                        IDDocumentoCompra = datos(0).ID
                        TipoCompra = datos(0).NomProceso
                        Select Case TipoCompra
                            Case TIPO_VENTA.VENTA_NORMAL_CREDITO
                                txTipoCompra.Text = "Venta al credito"

                        End Select

                        MonedaCompra = datos(0).NomEvento
                        btnInfoCompra.Image = My.Resources.b_docsql
                        btnInfoCompra.Tag = "YES"
                        TextBoxExt1.Metrocolor = Color.FromKnownColor(KnownColor.Highlight)
                        TextBoxExt1.FocusBorderColor = Color.FromKnownColor(KnownColor.Highlight)
                        Dim str As String = datos(0).Appat.Replace("0", "")
                        TextBoxExt1.Text = String.Concat(datos(0).Cuenta, ", ", datos(0).Apmat, "-", str)
                        ObtenerPorDetails(datos(0).ID)
                        '     loadNotas()
                    Else
                        'lsvCanasta.Items.Clear()
                        'dgvNuevoDoc.Rows.Clear()
                        btnInfoCompra.Image = My.Resources.b_drop
                        btnInfoCompra.Tag = "NO"
                        TextBoxExt1.Metrocolor = Color.Red
                        TextBoxExt1.FocusBorderColor = Color.Red
                        TextBoxExt1.Text = String.Empty
                    End If
                End With
            Else
                lblEstado.Text = "Debe seleccionar un proveedor para realizar esta operación!"
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub TextBoxExt1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtProveedor_TextChanged(sender As Object, e As EventArgs) Handles txtProveedor.TextChanged

    End Sub

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvProveedor.MouseDoubleClick
        If lsvProveedor.SelectedItems.Count > 0 Then
            Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub frmModuloCobros_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmModuloCobros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '   Me.WindowState = FormWindowState.Maximized
        Label18.Text = "TOTAL INGRESOS " & AnioGeneral
    End Sub

    Private Sub GuardarToolStripButton_Click(sender As Object, e As EventArgs) Handles GuardarToolStripButton.Click
        btnNuevoPago("EFECTIVO")
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click

    End Sub

    Private Sub btDelete_Click(sender As Object, e As EventArgs) Handles btDelete.Click
        If IsNothing(GFichaUsuarios) Then
            lblEstado.Text = "Debe asignar una caja válida!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        Else
            btnNuevoPago("EFECTIVO")
        End If

    End Sub

    Private Sub btnInfoComprasPendientes_Click(sender As Object, e As EventArgs) Handles btnInfoComprasPendientes.Click

    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click

    End Sub

    Private Sub ListaDeChequesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListaDeChequesToolStripMenuItem.Click

    End Sub

    Private Sub ActualizarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActualizarToolStripMenuItem.Click

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        PanelError.Visible = False
        Timer1.Enabled = False
    End Sub

    Private Sub ListaDeChuequesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListaDeChuequesToolStripMenuItem.Click

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor
        ObtenerPorDetails(IDDocumentoCompra)
        '  loadNotas()

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        Me.Cursor = Cursors.WaitCursor
        If txtProveedor.ValueMember.Trim.Length > 0 Then
            With frmHistorial
                .IdDocumentoCompra = IDDocumentoCompra
                .LoadHistorialCajasXcompra()
                ' .HistorialCompra(IDDocumentoCompra)
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        End If
        Me.Cursor = Cursors.Arrow
    End Sub
    Sub LoadDetalles()
        IDDocumentoCompra = dgvCompra.Table.CurrentRecord.GetValue("idDocumento")
        TipoCompra = dgvCompra.Table.CurrentRecord.GetValue("tipoCompra")
        Select Case dgvCompra.Table.CurrentRecord.GetValue("tipoCompra")
            Case TIPO_VENTA.VENTA_NORMAL_CREDITO
                txTipoCompra.Text = "Venta al credito"

        End Select
        MonedaCompra = dgvCompra.Table.CurrentRecord.GetValue("moneda")
        btnInfoCompra.Image = My.Resources.b_docsql
        btnInfoCompra.Tag = "YES"
        TextBoxExt1.Metrocolor = Color.FromKnownColor(KnownColor.Highlight)
        TextBoxExt1.FocusBorderColor = Color.FromKnownColor(KnownColor.Highlight)
        Dim str As String = dgvCompra.Table.CurrentRecord.GetValue("tipoCompra")
        TextBoxExt1.Text = String.Concat(dgvCompra.Table.CurrentRecord.GetValue("TipoDoc"), ", ", dgvCompra.Table.CurrentRecord.GetValue("Serie"), "-", str)
        ObtenerPorDetails(dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
    End Sub
    Private Sub dgvCompra_TableControlCurrentCellControlDoubleClick(sender As Object, e As GridTableControlControlEventArgs) Handles dgvCompra.TableControlCurrentCellControlDoubleClick
        Me.Cursor = Cursors.WaitCursor
        LoadDetalles()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub TextBoxExt1_KeyDown1(sender As Object, e As KeyEventArgs) Handles TextBoxExt1.KeyDown

    End Sub

    Private Sub TextBoxExt1_TextChanged_1(sender As Object, e As EventArgs) Handles TextBoxExt1.TextChanged

    End Sub
End Class
Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.GridHelperClasses
Imports PopupControl
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Public Class frmCuentasACobrar
    Inherits frmMaster

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        QGlobalColorSchemeManager1 = New Qios.DevSuite.Components.QGlobalColorSchemeManager
        QGlobalColorSchemeManager1.Global.CurrentTheme = Qios.DevSuite.Components.QColorScheme.LunaBlueThemeName
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        ConfiguracionInicio()
        '  dockingManager1.DockToFill = True
        configDockingManger()
        TabPageAdv1.Parent = Nothing
        TabPageAdv2.Parent = Nothing
        TabPageAdv3.Parent = Nothing
        TabPageAdv4.Parent = Nothing
    End Sub

    Private lblPeriodo As System.Windows.Forms.ToolStripLabel
    Private lblPeriodoLabel As System.Windows.Forms.ToolStripLabel

    Private Sub ConfiguracionInicio()
        Me.RibbonControlAdv1.QuickPanelVisible = True
        Me.lblPeriodo = New System.Windows.Forms.ToolStripLabel()
        Me.lblPeriodoLabel = New System.Windows.Forms.ToolStripLabel()
        Me.lblPeriodoLabel.Text = "Período:"
        Me.lblPeriodoLabel.Font = New Font("Segoe UI", 8.25, FontStyle.Bold)
        lblPeriodoLabel.Enabled = False

        Me.lblPeriodo.Font = New Font("Segoe UI", 8.25)
        ' Set the text and DisplayStyle property.
        Me.lblPeriodo.Text = PeriodoGeneral
        lblPeriodo.Enabled = False
        Me.lblPeriodo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text

        ' Add the toolstripbutton in the header of the RibbonControlAdv.
        Me.RibbonControlAdv1.Header.AddQuickItem(Me.lblPeriodoLabel)
        Me.RibbonControlAdv1.Header.AddQuickItem(Me.lblPeriodo) 'ToolStripSeparator1
        '  Me.RibbonControlAdv1.Header.AddQuickItem(Me.ToolStripSeparator1)
        RibbonControlAdv1.RibbonHeaderImage = Syncfusion.Windows.Forms.Tools.RibbonHeaderImage.Birds
        'Me.rbnPrincipal.Header.AddQuickItem(btnAnio)
        'Me.rbnPrincipal.Header.AddQuickItem(cboAnio)
        TabPageAdv1.Parent = TabControlAdv1
        TabPageAdv2.Parent = Nothing
    End Sub

#Region "CONFIGURACION DOCKING CONTROL"
    Sub configDockingManger()
        '      Me.dockingManager1.DockControlInAutoHideMode(Me.PanelHistorialPago, Syncfusion.Windows.Forms.Tools.DockingStyle.Bottom, 180)
        Me.dockingManager1.DockControl(Me.PanelHistorialPago, Me, Syncfusion.Windows.Forms.Tools.DockingStyle.Bottom, 180)
        dockingManager1.SetDockLabel(PanelHistorialPago, "Historial de Pago")
        dockingManager1.CloseEnabled = False
    End Sub
#End Region

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

#Region "Métodos"
    Private Sub LoadProveedores()
        Dim entidadSA As New entidadSA

        lsvProveedor.Items.Clear()

        For Each i As entidad In entidadSA.GetListarEntidad(New entidad With {.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
            Dim n As New ListViewItem(i.idEntidad)
            n.SubItems.Add(i.nombreCompleto)
            n.SubItems.Add(i.cuentaAsiento)
            n.SubItems.Add(i.nrodoc)
            lsvProveedor.Items.Add(n)
        Next
    End Sub

    Private Function getParentTableComprasPorPeriodo() As DataTable
        Dim DocumentoCompraSA As New DocumentoCompraSA
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable("Compras - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("DetalleItem", GetType(String)))
        '   dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))

        '   dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))

        dt.Columns.Add(New DataColumn("ImporteCompraDetalleMN", GetType(Decimal)))
        'dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("ImporteCompraDetalleME", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("NombreCajaPago", GetType(String)))
        dt.Columns.Add(New DataColumn("ImportePagoMN", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("ImportePagoME", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("TipoDocPagoCaja", GetType(String)))
        dt.Columns.Add(New DataColumn("NumeroTipoDocCaja", GetType(String)))
        dt.Columns.Add(New DataColumn("NumDocOperCaja", GetType(String)))
        dt.Columns.Add(New DataColumn("BancoDeposito", GetType(String)))
        dt.Columns.Add(New DataColumn("CtaCorrienteDeposito", GetType(String)))

        Dim str As String
        For Each i As documentocompra In DocumentoCompraSA.GetListarComprasNotaCreditoPorProveedorCaja(GEstableciento.IdEstablecimiento, txtProveedorFilter.ValueMember, PeriodoGeneral)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoCompra
            dr(2) = str
            dr(3) = tablaSA.GetUbicarTablaID(10, i.tipoDoc).descripcion.Substring(0, 3) & ", " & CInt(i.serie) & "-" & CInt(i.numeroDoc)
            dr(4) = i.DetalleItemCaja
            dr(5) = i.ImporteCompraDetalleMN
            dr(6) = i.ImporteCompraDetalleME
            dr(7) = i.NombreCajaPago
            dr(8) = i.ImportePagoMN
            dr(9) = i.ImportePagoME

            Select Case i.TipoDocPagoCaja
                Case "003"
                    dr(10) = New String("TRAN")
                Case "109"
                    dr(10) = New String("EFE")
                Case "007"
                    dr(10) = New String("CHE")
            End Select
            dr(11) = i.NumeroTipoDocCaja
            dr(12) = i.NumDocOperCaja
            Select Case i.TipoDocPagoCaja
                Case "003"
                    dr(13) = tablaSA.GetUbicarTablaID(3, i.BancoDeposito).descripcion.Substring(0, 10)
                Case "109"
                    dr(13) = "-"
                Case "007"
                    dr(13) = "-"
            End Select
            dr(14) = i.CtaCorrienteDeposito
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Public Sub ListaComprasProveedor()
        Try
            Dim parentTable As DataTable = getParentTableComprasPorPeriodo()
            Me.dgvCompra.DataSource = parentTable
            dgvCompra.TableDescriptor.Relations.Clear()
            dgvCompra.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            dgvCompra.TableOptions.ListBoxSelectionMode = SelectionMode.One
            dgvCompra.Appearance.AnyRecordFieldCell.Enabled = False
            dgvCompra.GroupDropPanel.Visible = True
            dgvCompra.TableDescriptor.GroupedColumns.Clear()
            dgvCompra.TableDescriptor.GroupedColumns.Add("tipoDoc")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub EliminarDocumento(intIdDocumento As Integer)
        Dim documentoSA As New DocumentoSA
        Dim docCajaSA As New DocumentoCajaSA
        Dim nDocumento As New documento()
        With nDocumento
            .IdDocumentoAfectado = txtFechaCompra.ValueMember
            .idDocumento = intIdDocumento
            .usuarioActualizacion = docCajaSA.GetUbicar_documentoCajaPorID(intIdDocumento).usuarioModificacion
        End With
        documentoSA.EliminarDocumentoCaja(nDocumento)
        Me.dgvHistorial.Table.CurrentRecord.Delete()
        lblEstado.Text = "Pago eliminado correctamente"
        PanelError.Visible = True
        Timer1.Enabled = True
        TiempoEjecutar(10)
        '  HistorialCompra(txtFechaCompra.ValueMember)
    End Sub

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

        If TabControlAdv1.SelectedTab Is TabPageAdv1 Then

            Select Case txtTipoCompra.ValueMember

                Case TIPO_COMPRA.NOTA_CREDITO
                    With frmCobros
                        '   .tbFormaPago.ToggleState = Tools.ToggleButtonState.Inactive
                        .dgvDetalleItems.Rows.Clear()
                        .manipulacionEstado = ENTITY_ACTIONS.INSERT
                        Select Case txtMonedaCompra.ValueMember
                            Case 1
                                .lblIdProveedor = txtProveedor.ValueMember
                                .lblNomProveedor = txtProveedor.Text
                                .lblCuentaProveedor = txtCuenta.Text
                                .lblIdDocumento.Text = txtFechaCompra.ValueMember

                                For Each i As documentoCajaDetalle In objLista.ObtenerCuentasPorPagarPorDetails(txtFechaCompra.ValueMember)
                                    If i.bonificacion = "S" Then
                                        cTotalmn = i.notaCreditoMN - CDec(i.MontoPagadoSoles) ' Math.Round(CDec(i.MontoDeudaSoles) - CDec(i.notaCreditoMN) + CDec(i.notaDebitoMN) - CDec(i.MontoPagadoSoles), 2)
                                        cTotalme = i.notaCreditoME - CDec(i.MontoPagadoUSD) ' Math.Round(CDec(i.MontoDeudaUSD) - CDec(i.notaCreditoME) + CDec(i.notaDebitoME) - CDec(i.MontoPagadoUSD), 2)
                                        saldomn += cTotalmn
                                        saldome += cTotalme
                                        If cTotalmn > 0 Or cTotalme > 0 Then
                                            .dgvDetalleItems.Rows.Add(i.idItem, i.DetalleItem, Nothing,
                                                                       Nothing, cTotalmn, cTotalme,
                                                                       "0.00", "0.00", "0.00", "0.00", Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT)
                                        End If
                                    End If
                                Next
                                lblPagoMN.Text = saldomn.ToString("N2")
                                lblPagoME.Text = saldome.ToString("N2")

                                '.nudImporteNac.Maximum = CDec(lblPagoMN.Text)
                                .lblDeudaPendiente.Text = CDec(lblPagoMN.Text)
                                .lblDeudaPendienteme.Text = CDec(lblPagoME.Text)
                        End Select

                        If CDec(lblPagoMN.Text) <= 0 Then
                            '    MsgBox("El documento ya se encuentra pagado.", MsgBoxStyle.Information, "Aviso del Sistema")
                            lblEstado.Text = "El documento ya se encuentra pagado."
                            PanelError.Visible = True
                            Timer1.Enabled = True
                            TiempoEjecutar(10)
                            Me.Cursor = Cursors.Arrow
                            Exit Sub
                        Else
                            'If .TieneCuentaFinanciera = True Then
                            '    .txtFechaComprobante.Value = New Date(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
                            '    .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                            '    .txtFechaComprobante.Enabled = False
                            '    .lblPerido.Text = lblPeriodo.Text
                            '    'If strFormPago = "EFECTIVO" Then
                            '    '    .rbEfectivo.Checked = True
                            '    '    .LoadEfectivo()
                            '    '    .txtNumero.Visible = False
                            '    '    .txtNumero.Clear()
                            '    'ElseIf strFormPago = "OTROS" Then
                            '    '    .rbOtros.Checked = True
                            '    '    .LoadOtros()
                            '    '    .txtNumero.Visible = True
                            '    '    .txtNumero.Clear()
                            '    'End If
                            '    .cboTipoDoc.Enabled = True
                            '    .cboTipoDoc.ReadOnly = False
                            '    .StartPosition = FormStartPosition.CenterParent
                            '    .ShowDialog()
                            'Else
                            '    lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
                            '    PanelError.Visible = True
                            '    Timer1.Enabled = True
                            '    TiempoEjecutar(10)
                            'End If
                        End If
                    End With
                    'Case TIPO_COMPRA.COMPRA_DIRECTA_CON_RECEPCION, TIPO_COMPRA.COMPRA_DIRECTA_SIN_RECEPCION
                    '    lblEstado.Text = "La compra está pagada."
                    '    PanelError.Visible = True
                    '    Timer1.Enabled = True
                    '    TiempoEjecutar(10)
                    '    Me.Cursor = Cursors.Arrow
                    '    Exit Sub
            End Select
        ElseIf TabControlAdv1.SelectedTab Is TabPageAdv3 Then

            If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
                Select Case Me.dgvCompra.Table.CurrentRecord.GetValue("tipoCompra")

                    Case TIPO_COMPRA.NOTA_CREDITO
                        With frmCobros
                            '          .tbFormaPago.ToggleState = Tools.ToggleButtonState.Active
                            .dgvDetalleItems.Rows.Clear()
                            .manipulacionEstado = ENTITY_ACTIONS.INSERT
                            '   Select Case txtMonedaCompra.ValueMember
                            '    Case 1
                            .lblIdProveedor = txtProveedorFilter.ValueMember
                            .lblNomProveedor = txtProveedorFilter.Text
                            .lblCuentaProveedor = txtCuentaProvFilter.Text
                            .lblIdDocumento.Text = Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento")

                            For Each i As documentoCajaDetalle In objLista.ObtenerCuentasPorPagarPorDetails(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
                                If i.bonificacion = "S" Then
                                    cTotalmn = i.notaCreditoMN - CDec(i.MontoPagadoSoles) ' Math.Round(CDec(i.MontoDeudaSoles) - CDec(i.notaCreditoMN) + CDec(i.notaDebitoMN) - CDec(i.MontoPagadoSoles), 2)
                                    cTotalme = i.notaCreditoME - CDec(i.MontoPagadoUSD) ' Math.Roundh.Round(CDec(i.MontoDeudaUSD) - CDec(i.notaCreditoME) + CDec(i.notaDebitoME) - CDec(i.MontoPagadoUSD), 2)
                                    saldomn += cTotalmn
                                    saldome += cTotalme
                                    If cTotalmn > 0 Or cTotalme > 0 Then
                                        .dgvDetalleItems.Rows.Add(i.idItem, i.DetalleItem, Nothing,
                                                                   Nothing, cTotalmn, cTotalme,
                                                                   "0.00", "0.00", "0.00", "0.00", Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT)
                                    End If
                                End If
                            Next
                            lblPagoMN.Text = saldomn.ToString("N2")
                            lblPagoME.Text = saldome.ToString("N2")

                            '.nudImporteNac.Maximum = CDec(lblPagoMN.Text)
                            .lblDeudaPendiente.Text = CDec(lblPagoMN.Text)
                            .lblDeudaPendienteme.Text = CDec(lblPagoME.Text)
                            '    End Select

                            If CDec(lblPagoMN.Text) <= 0 Then
                                '    MsgBox("El documento ya se encuentra pagado.", MsgBoxStyle.Information, "Aviso del Sistema")
                                lblEstado.Text = "El documento ya se encuentra pagado."
                                PanelError.Visible = True
                                Timer1.Enabled = True
                                TiempoEjecutar(10)
                                Me.Cursor = Cursors.Arrow
                                Exit Sub
                            Else
                                'If .TieneCuentaFinanciera = True Then
                                '    .txtFechaComprobante.Value = New Date(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
                                '    .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                                '    .txtFechaComprobante.Enabled = False
                                '    .lblPerido.Text = lblPeriodo.Text
                                '    'If strFormPago = "EFECTIVO" Then
                                '    '    .rbEfectivo.Checked = True
                                '    '    .LoadEfectivo()
                                '    '    .txtNumero.Visible = False
                                '    '    .txtNumero.Clear()
                                '    'ElseIf strFormPago = "OTROS" Then
                                '    '    .rbOtros.Checked = True
                                '    '    .LoadOtros()
                                '    '    .txtNumero.Visible = True
                                '    '    .txtNumero.Clear()
                                '    'End If
                                '    .cboTipoDoc.Enabled = True
                                '    .cboTipoDoc.ReadOnly = False
                                '    .StartPosition = FormStartPosition.CenterParent
                                '    .ShowDialog()
                                'Else
                                '    lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
                                '    PanelError.Visible = True
                                '    Timer1.Enabled = True
                                '    TiempoEjecutar(10)
                                'End If
                            End If
                        End With
                    Case TIPO_COMPRA.COMPRA_DIRECTA_CON_RECEPCION, TIPO_COMPRA.COMPRA_DIRECTA_SIN_RECEPCION
                        lblEstado.Text = "La compra está pagada."
                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                End Select
            End If


        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Public Class DocCompra
        Private _name As String
        Private _id As Integer
        Public Sub New(ByVal name As String, ByVal id As Integer)
            _name = name
            _id = id
        End Sub

        Sub New()
            ' TODO: Complete member initialization 
        End Sub

        Public Property Name() As String
            Get
                Return _name
            End Get
            Set(ByVal value As String)
                _name = value
            End Set
        End Property
        Public Property Id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal value As Integer)
                _id = value
            End Set
        End Property
    End Class

    Private Sub UbicarCompraNroSerie(strSerie As String, strNumero As String, strRuc As String)
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim documentoCompra As New List(Of documentocompra)
        Dim tablaSA As New tablaDetalleSA
        lstCompras.Items.Clear()
        documentoCompra = documentoCompraSA.UbicarNCreditoPorSerieNro(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, strSerie, strNumero, strRuc)
        If Not IsNothing(documentoCompra) Then
            For Each i In documentoCompra
                lstCompras.Items.Add(New DocCompra(i.numeroDoc, i.idDocumento))
            Next
            '  lstCompras.DataSource = tablaSA.GetListaTablaDetalle(5, "1")
            lstCompras.DisplayMember = "Name"
            lstCompras.ValueMember = "Id"
        Else
            lstCompras.DataSource = Nothing
            lstCompras.Items.Clear()
        End If
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
            lsvDetalleItems.Columns.Add("Descripción", 200) '01
            lsvDetalleItems.Columns.Add("Deuda M.N.", 100, HorizontalAlignment.Right) '02
            lsvDetalleItems.Columns.Add("Deuda M.E.", 0, HorizontalAlignment.Right) '03

            lsvDetalleItems.Columns.Add("A cuenta", 80, HorizontalAlignment.Right) '04
            lsvDetalleItems.Columns.Add("A cuenta me.", 0, HorizontalAlignment.Right) '05

            lsvDetalleItems.Columns.Add("Saldo M.N.", 80, HorizontalAlignment.Right) '10
            lsvDetalleItems.Columns.Add("Saldo M.E.", 0, HorizontalAlignment.Right) '11
            lsvDetalleItems.Columns.Add("Cancelado", 0, HorizontalAlignment.Center) '12
            For Each i As documentoCajaDetalle In objLista.ObtenerCuentasPorPagarPorDetails(strDocumentoAfectado)
                'saldomn = Math.Round(i.MontoDeudaSoles - i.MontoPagadoSoles, 2)
                'saldome = Math.Round(i.MontoDeudaUSD - i.MontoPagadoUSD, 2)
                If i.bonificacion = "S" Then
                    cTotalmn = CDec(i.notaCreditoMN) - CDec(i.MontoPagadoSoles)  ' Math.Round(CDec(i.MontoDeudaSoles) - CDec(i.notaCreditoMN) + CDec(i.notaDebitoMN) - CDec(i.MontoPagadoSoles), 2)
                    cTotalme = CDec(i.notaCreditoME) - CDec(i.MontoPagadoUSD) ' Math.Round(CDec(i.MontoDeudaUSD) - CDec(i.notaCreditoME) + CDec(i.notaDebitoME) - CDec(i.MontoPagadoUSD), 2)
                    saldomn += cTotalmn
                    saldome += cTotalme
                    Dim n As New ListViewItem(i.idItem)
                    n.SubItems.Add(i.DetalleItem)
                    n.SubItems.Add(i.notaCreditoMN.ToString("N2"))
                    n.SubItems.Add(i.notaCreditoME.ToString("N2"))

                    n.SubItems.Add(i.MontoPagadoSoles.ToString("N2"))
                    n.SubItems.Add(i.MontoPagadoUSD.ToString("N2"))

                    n.SubItems.Add(saldomn.ToString("N2"))
                    n.SubItems.Add(saldome.ToString("N2"))
                    '       n.SubItems.Add(i.notaDebitoME.ToString("N2"))

                    'If TabControl1.SelectedTab Is TabPage2 Then

                    '    If txtTipoCompra.Text = "Compra Pagada" Then
                    '        n.SubItems.Add(cTotalmn.ToString("N2"))
                    '        n.SubItems.Add(cTotalme.ToString("N2"))
                    '        n.SubItems.Add(0)
                    '        n.SubItems.Add(0)
                    '        n.SubItems.Add("S")
                    '    ElseIf txtTipoCompra.Text = "Compra Al crédito" Then
                    '        n.SubItems.Add(i.MontoPagadoSoles.ToString("N2"))
                    '        n.SubItems.Add(i.MontoPagadoUSD.ToString("N2"))
                    '        n.SubItems.Add(cTotalmn.ToString("N2"))
                    '        n.SubItems.Add(cTotalme.ToString("N2"))
                    '        n.SubItems.Add(IIf(Mid(cTotalmn, 1, 1) = 0, "S", "N"))
                    '    End If

                    '     ElseIf TabControl1.SelectedTab Is TabPage1 Then
                    'If txtTipoCompra.ValueMember = TIPO_COMPRA.COMPRA_DIRECTA_CON_RECEPCION Or txtTipoCompra.ValueMember = TIPO_COMPRA.COMPRA_DIRECTA_SIN_RECEPCION Then
                    '    n.SubItems.Add(cTotalmn.ToString("N2"))
                    '    n.SubItems.Add(cTotalme.ToString("N2"))
                    '    n.SubItems.Add(0)
                    '    n.SubItems.Add(0)
                    '    n.SubItems.Add("S")
                    'ElseIf txtTipoCompra.ValueMember = TIPO_COMPRA.COMPRA_AL_CREDITO Then
                    '    n.SubItems.Add(i.MontoPagadoSoles.ToString("N2"))
                    '    n.SubItems.Add(i.MontoPagadoUSD.ToString("N2"))
                    '    n.SubItems.Add(cTotalmn.ToString("N2"))
                    '    n.SubItems.Add(cTotalme.ToString("N2"))
                    '    n.SubItems.Add(IIf(cTotalmn <= 0, "S", "N"))
                    'End If
                    '  End If
                    lsvDetalleItems.Items.Add(n)
                End If
            Next
            lblPagoMN.Text = saldomn.ToString("N2")
            lblPagoME.Text = saldome.ToString("N2")
            ToolStrip3.Visible = True
            'lblSaldo.Text = saldomn.ToString("N2")
            'lblSaldome.Text = saldome.ToString("N2")
        Catch ex As Exception
            MsgBox("Error al obtener datos.!" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del Sistema.!")
        End Try
    End Sub

    Public Sub UbicarCompra(IntIdDocumento As Integer)
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim documentoCompra As New documentocompra
        Dim entidadSA As New entidadSA
        Dim tablaSA As New tablaDetalleSA

        documentoCompra = documentoCompraSA.UbicarDocumentoCompra(IntIdDocumento)
        If Not IsNothing(documentoCompra) Then
            With documentoCompra ' documentoCompraSA.UbicarDocumentoCompra(IntIdDocumento)
                txtFechaCompra.ValueMember = .idDocumento
                txtFechaCompra.Text = .fechaDoc
                txtComprobante.ValueMember = .tipoDoc
                txtComprobante.Text = tablaSA.GetUbicarTablaID(10, .tipoDoc).descripcion
                With entidadSA.UbicarEntidadPorID(.idProveedor).First
                    txtProveedor.ValueMember = .idEntidad
                    txtProveedor.Text = .nombreCompleto
                    txtRuc.Text = .nrodoc
                    txtCuenta.Text = .cuentaAsiento
                End With

                txtSerie.Text = .serie
                txtNumero.Text = .numeroDoc
                txtTipoCambio.Text = .tcDolLoc
                txtMonedaCompra.ValueMember = .monedaDoc
                Select Case .monedaDoc
                    Case 1
                        txtMonedaCompra.Text = "NACIONAL"
                    Case Else
                        txtMonedaCompra.Text = "EXTRANJERA"
                End Select
                txtTipoCompra.ValueMember = .tipoCompra
                Select Case .tipoCompra
                    Case TIPO_COMPRA.NOTA_CREDITO
                        txtTipoCompra.Text = "Nota de credito"
                        txtTipoCompra.ValueMember = .tipoCompra
                End Select
                txtEstadoPago.Text = .estadoPago
                txtImporteCompramn.Text = .importeTotal
                txtImporteComprame.Text = .importeUS
                ObtenerPorDetails(txtFechaCompra.ValueMember, lsvCanasta)
                HistorialCompra(txtFechaCompra.ValueMember)
            End With
        End If

    End Sub


    Private Function getParentTableHistorial(intIdCompra As Integer) As DataTable
        Dim objLista As New DocumentoCajaDetalleSA()

        Dim dt As New DataTable("Historial de pagos ")

        dt.Columns.Add(New DataColumn("documentoAfectado", GetType(Integer)))
        dt.Columns.Add(New DataColumn("nomDocumento", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("numeroDocNormal", GetType(String)))
        dt.Columns.Add(New DataColumn("idCliente", GetType(String)))
        dt.Columns.Add(New DataColumn("nomEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))

        dt.Columns.Add(New DataColumn("moneda", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDocumento", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoCambio", GetType(String)))
        dt.Columns.Add(New DataColumn("idDocumento", GetType(String)))

        dt.Columns.Add(New DataColumn("montoSoles", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoUsd", GetType(Decimal)))

        Dim str As String
        For Each i As documentoCajaDetalle In objLista.ObtenerHistorialPagos(intIdCompra)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.documentoAfectado
            dr(1) = i.nomDocumento
            dr(2) = i.numeroDocNormal
            dr(3) = i.idCliente
            dr(4) = i.nomEntidad
            dr(5) = str

            dr(6) = i.moneda
            dr(7) = i.tipoDocumento
            dr(8) = i.tipoCambioTransacc
            dr(9) = i.idDocumento
            dr(10) = i.montoSoles
            dr(11) = i.montoUsd
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Private Sub HistorialCompra(intIdCompra As Integer)
        Dim objLista As New DocumentoCajaDetalleSA()
        dgvHistorial.TableDescriptor.Name = ("Historial compra")
        dgvHistorial.DataSource = getParentTableHistorial(intIdCompra) ' objLista.ObtenerHistorialPagos(intIdCompra)
        dgvHistorial.TableDescriptor.Relations.Clear()
        dgvHistorial.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
        dgvHistorial.TableOptions.ListBoxSelectionMode = SelectionMode.One
        dgvHistorial.ShowColumnHeaders = False
        dgvHistorial.GroupDropPanel.Visible = False
        Me.dgvHistorial.TopLevelGroupOptions.ShowCaption = False
        '  dgvPagos.TableOptions.ShowRowHeader = False
        dgvHistorial.Appearance.AnyRecordFieldCell.Enabled = False
        dgvHistorial.TableDescriptor.GroupedColumns.Clear()
        dgvHistorial.TableDescriptor.GroupedColumns.Add("nomDocumento")
    End Sub
#End Region

    Private Sub frmCuentasACobrar_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub ButtonAdv4_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv4.Click
        Me.pcAlmacen.HidePopup(PopupCloseType.Canceled)
    End Sub

    Private Sub pcAlmacen_BeforePopup(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles pcAlmacen.BeforePopup
        Me.pcAlmacen.BackColor = Color.White
    End Sub

    Private Sub pcAlmacen_CloseUp(sender As Object, e As Syncfusion.Windows.Forms.PopupClosedEventArgs) Handles pcAlmacen.CloseUp
        Me.Cursor = Cursors.WaitCursor
        If e.PopupCloseType = PopupCloseType.Done Then
            If lstCompras.SelectedItems.Count > 0 Then
                UbicarCompra(DirectCast(Me.lstCompras.SelectedItem, DocCompra).Id)
                TabControlAdv1.Visible = True
                TabPageAdv1.Parent = TabControlAdv1
                TabPageAdv2.Parent = Nothing
                TabPageAdv3.Parent = Nothing
                TabPageAdv4.Parent = Nothing
                dockingManager1.SetDockVisibility(PanelHistorialPago, True)
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            '  Me.txtAlmacen.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv1_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            UbicarCompraNroSerie(String.Format("{0:00000}", Convert.ToInt32(txtBuscar.Text)), String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNUmFilter.Text)), txtFiltroProveedor.Text.Trim)
        Catch ex As Exception
            lblEstado.Text = ex.Message & ", verifique que los campos sean correctos!!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lstCompras_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lstCompras.MouseDoubleClick
        Me.pcAlmacen.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub lstCompras_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lstCompras.SelectedIndexChanged

    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        pcAlmacen.Font = New Font("Tahoma", 8)
        pcAlmacen.Size = New Size(306, 277)
        Me.pcAlmacen.ParentControl = Me.RibbonControlAdv1
        Me.pcAlmacen.ShowPopup(Point.Empty)
    End Sub

    Private Sub frmCuentasACobrar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnHistorialPago_Click(sender As Object, e As EventArgs) Handles btnHistorialPago.Click
        If TabControlAdv1.SelectedTab Is TabPageAdv1 Then
            configDockingManger()
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        Dim datos As List(Of RecolectarDatos) = RecolectarDatos.Instance()
        datos.Clear()
        Dim documentoCajaDetalleSA As New DocumentoCajaDetalleSA
        btnNuevoPago("EFECTIVO")
        If datos.Count > 0 Then
            Dim str As String = Nothing
            With documentoCajaDetalleSA.ObtenerHistorialPagosPorIdPago(datos(0).IdAlmacen)
                Me.dgvHistorial.Table.AddNewRecord.SetCurrent()
                Me.dgvHistorial.Table.AddNewRecord.BeginEdit()
                str = CDate(.fechaDoc).ToString("dd-MMM hh:mm tt ")
                Me.dgvHistorial.Table.CurrentRecord.SetValue("documentoAfectado", .documentoAfectado)
                Me.dgvHistorial.Table.CurrentRecord.SetValue("nomDocumento", .nomDocumento)
                Me.dgvHistorial.Table.CurrentRecord.SetValue("numeroDocNormal", .numeroDocNormal)
                Me.dgvHistorial.Table.CurrentRecord.SetValue("idCliente", .idCliente)
                Me.dgvHistorial.Table.CurrentRecord.SetValue("nomEntidad", .nomEntidad)
                Me.dgvHistorial.Table.CurrentRecord.SetValue("fechaDoc", str)
                Me.dgvHistorial.Table.CurrentRecord.SetValue("moneda", .moneda)
                Me.dgvHistorial.Table.CurrentRecord.SetValue("tipoDocumento", .tipoDocumento)
                Me.dgvHistorial.Table.CurrentRecord.SetValue("tipoCambio", .tipoCambioTransacc)
                Me.dgvHistorial.Table.CurrentRecord.SetValue("idDocumento", .idDocumento)
                Me.dgvHistorial.Table.CurrentRecord.SetValue("montoSoles", .montoSoles)
                Me.dgvHistorial.Table.CurrentRecord.SetValue("montoUsd", .montoUsd)
                Me.dgvHistorial.Table.AddNewRecord.EndEdit()
            End With

        End If
    End Sub

    Private Sub txtBuscar_LostFocus(sender As Object, e As System.EventArgs) Handles txtBuscar.LostFocus
        If txtBuscar.Text.Trim.Length > 0 Then
            txtBuscar.Text = String.Format("{0:00000}", Convert.ToInt32(txtBuscar.Text))
        End If
    End Sub

    Private Sub txtBuscar_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBuscar.TextChanged

    End Sub

    Private Sub txtNUmFilter_LostFocus(sender As Object, e As System.EventArgs) Handles txtNUmFilter.LostFocus
        If txtNUmFilter.Text.Trim.Length > 0 Then
            txtNUmFilter.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNUmFilter.Text))
        End If
    End Sub

    Private Sub txtNUmFilter_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNUmFilter.TextChanged

    End Sub

    Private Sub btnEliminarCompra_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminarCompra.Click
        Try
            If Not IsNothing(Me.dgvHistorial.Table.CurrentRecord) Then
                EliminarDocumento(CInt(Me.dgvHistorial.Table.CurrentRecord.GetValue("idDocumento")))
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub

    Private Sub dropDownBtn_Click(sender As System.Object, e As System.EventArgs) Handles dropDownBtn.Click
        PopupControlContainer2.Font = New Font("Segoe UI", 8)
        PopupControlContainer2.Size = New Size(334, 150)
        Me.PopupControlContainer2.ParentControl = Me.txtProveedorFilter
        Me.PopupControlContainer2.ShowPopup(Point.Empty)
    End Sub

    Private Sub PopupControlContainer2_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles PopupControlContainer2.BeforePopup
        Me.PopupControlContainer2.BackColor = Color.White
    End Sub

    Private Sub PopupControlContainer2_CloseUp(sender As Object, e As Syncfusion.Windows.Forms.PopupClosedEventArgs) Handles PopupControlContainer2.CloseUp
        Me.Cursor = Cursors.WaitCursor
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvProveedor.SelectedItems.Count > 0 Then
                Me.txtProveedorFilter.Text = lsvProveedor.SelectedItems(0).SubItems(1).Text
                txtProveedorFilter.ValueMember = lsvProveedor.SelectedItems(0).SubItems(0).Text
                txtNumProvFilter.Text = lsvProveedor.SelectedItems(0).SubItems(3).Text
                txtCuentaProvFilter.Text = lsvProveedor.SelectedItems(0).SubItems(2).Text
                ListaComprasProveedor()
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedorFilter.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lsvProveedor.MouseDoubleClick
        If lsvProveedor.SelectedItems.Count > 0 Then
            Me.PopupControlContainer2.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub lsvProveedor_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lsvProveedor.SelectedIndexChanged

    End Sub

    Private Sub PagoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PagoToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        LoadProveedores()
        TabPageAdv1.Parent = Nothing
        TabPageAdv2.Parent = Nothing
        TabPageAdv4.Parent = Nothing
        TabPageAdv3.Parent = TabControlAdv1
        If Not IsNothing(dockingManager1.ActiveControl) Then
            dockingManager1.SetDockVisibility(PanelHistorialPago, False)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub
End Class
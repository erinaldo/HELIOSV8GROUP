<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCobros
    Inherits Helios.Cont.Presentation.WinForm.frmMaster

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCobros))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor6 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor7 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor8 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor9 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridSummaryRowDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor()
        Dim GridSummaryColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor()
        Dim GridSummaryColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.GuardarToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.PegarToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblIdDocumento = New System.Windows.Forms.ToolStripLabel()
        Me.lbldDocCaja = New System.Windows.Forms.ToolStripLabel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.btnConfigCaja = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.DockingClientPanel1 = New Syncfusion.Windows.Forms.Tools.DockingClientPanel()
        Me.txtPeriodo = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtTipoEntidad = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtNroDocEntidad = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtEntidad = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.pnContenedorCobro = New System.Windows.Forms.Panel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cboTipoDoc = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.pnEntidad = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.cboEntidades = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtCuentaCorriente = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.pnFecha = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFechaEmision = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtFechaCobro = New System.Windows.Forms.DateTimePicker()
        Me.txtNumOper = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.PanelDetallePagos = New System.Windows.Forms.Panel()
        Me.dgvDetalleItems = New System.Windows.Forms.DataGridView()
        Me.colId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNameItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPrecUnit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPagoMN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPagoME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSaldoMN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSaldoME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sec = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.PopupControlContainer1 = New Syncfusion.Windows.Forms.PopupControlContainer()
        Me.lsvTipoCambio = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ButtonAdv2 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv3 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.pnDiferencia = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.txtDiferenciaMontos = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.pnTipoCambio = New System.Windows.Forms.Panel()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.txtTipoCambio = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.pnNacional = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtImporteCompramn = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.pnExtranjero = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtImporteComprame = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ButtonAdv4 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv5 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblMonedaCobro = New System.Windows.Forms.Label()
        Me.btnSaldoCobro = New System.Windows.Forms.Button()
        Me.txtFechaTrans = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.GradientPanel6 = New System.Windows.Forms.GroupBox()
        Me.txtCuentaOrigen = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.pnImpMNDisp = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.nudDeudaPendientemn = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.pnImpMEDisp = New System.Windows.Forms.Panel()
        Me.nudDeudaPendienteme = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboMoneda = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.cboTipo = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cboDepositoHijo = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.GradientPanel1 = New System.Windows.Forms.GroupBox()
        Me.pnTipoCambioVenta = New System.Windows.Forms.Panel()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.lblTipoCambio = New System.Windows.Forms.Label()
        Me.pnSaldoME = New System.Windows.Forms.Panel()
        Me.pnColorME = New System.Windows.Forms.Panel()
        Me.lblDeudaPendienteme = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.pnSaldoMN = New System.Windows.Forms.Panel()
        Me.pnColorMN = New System.Windows.Forms.Panel()
        Me.lblDeudaPendiente = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.tb19 = New Helios.Cont.Presentation.WinForm.ToggleButton2()
        Me.gpVSBehavior = New System.Windows.Forms.GroupBox()
        Me.txtFechaComprobante = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtNumeroCompr = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtSerieCompr = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtComprobante = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtProveedor = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.PopupControlContainer3 = New Syncfusion.Windows.Forms.PopupControlContainer()
        Me.pn = New System.Windows.Forms.Panel()
        Me.dgvDiferencia = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.ButtonAdv6 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv9 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.cboooottr = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.cbooo = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.cboTipoDocument = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.dockingManager1 = New Syncfusion.Windows.Forms.Tools.DockingManager(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.QGlobalColorSchemeManager1 = New Qios.DevSuite.Components.QGlobalColorSchemeManager(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.btGrabar = New System.Windows.Forms.ToolStripButton()
        Me.PanelError = New System.Windows.Forms.Panel()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.btOperacion = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ToolStrip3.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.DockingClientPanel1.SuspendLayout()
        CType(Me.txtPeriodo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPeriodo.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoEntidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNroDocEntidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEntidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnContenedorCobro.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.cboTipoDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnEntidad.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboEntidades, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCuentaCorriente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnFecha.SuspendLayout()
        CType(Me.txtNumOper, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelDetallePagos.SuspendLayout()
        CType(Me.dgvDetalleItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.PopupControlContainer1.SuspendLayout()
        Me.pnDiferencia.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDiferenciaMontos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnTipoCambio.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoCambio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnNacional.SuspendLayout()
        CType(Me.txtImporteCompramn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnExtranjero.SuspendLayout()
        CType(Me.txtImporteComprame, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.txtFechaTrans, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaTrans.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.pnImpMNDisp.SuspendLayout()
        CType(Me.nudDeudaPendientemn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnImpMEDisp.SuspendLayout()
        CType(Me.nudDeudaPendienteme, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDepositoHijo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        Me.pnTipoCambioVenta.SuspendLayout()
        Me.pnSaldoME.SuspendLayout()
        Me.pnColorME.SuspendLayout()
        Me.pnSaldoMN.SuspendLayout()
        Me.pnColorMN.SuspendLayout()
        Me.gpVSBehavior.SuspendLayout()
        CType(Me.txtFechaComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumeroCompr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSerieCompr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PopupControlContainer3.SuspendLayout()
        Me.pn.SuspendLayout()
        CType(Me.dgvDiferencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboooottr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbooo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTipoDocument, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dockingManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelError.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip3
        '
        Me.ToolStrip3.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip3.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GuardarToolStripButton, Me.PegarToolStripButton, Me.toolStripSeparator1, Me.lblIdDocumento, Me.lbldDocCaja})
        Me.ToolStrip3.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip3.Size = New System.Drawing.Size(1260, 22)
        Me.ToolStrip3.TabIndex = 412
        Me.ToolStrip3.Text = "ToolStrip3"
        Me.ToolStrip3.Visible = False
        '
        'GuardarToolStripButton
        '
        Me.GuardarToolStripButton.Image = CType(resources.GetObject("GuardarToolStripButton.Image"), System.Drawing.Image)
        Me.GuardarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.GuardarToolStripButton.Name = "GuardarToolStripButton"
        Me.GuardarToolStripButton.Size = New System.Drawing.Size(66, 19)
        Me.GuardarToolStripButton.Text = "&Grabar"
        '
        'PegarToolStripButton
        '
        Me.PegarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PegarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PegarToolStripButton.Name = "PegarToolStripButton"
        Me.PegarToolStripButton.Size = New System.Drawing.Size(23, 19)
        Me.PegarToolStripButton.Text = "&Cancelar"
        Me.PegarToolStripButton.Visible = False
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 22)
        '
        'lblIdDocumento
        '
        Me.lblIdDocumento.Name = "lblIdDocumento"
        Me.lblIdDocumento.Size = New System.Drawing.Size(19, 19)
        Me.lblIdDocumento.Text = "00"
        Me.lblIdDocumento.Visible = False
        '
        'lbldDocCaja
        '
        Me.lbldDocCaja.Name = "lbldDocCaja"
        Me.lbldDocCaja.Size = New System.Drawing.Size(13, 19)
        Me.lbldDocCaja.Text = "0"
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.btnConfigCaja)
        Me.Panel7.Controls.Add(Me.Label23)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(760, 0)
        Me.Panel7.TabIndex = 413
        '
        'btnConfigCaja
        '
        Me.btnConfigCaja.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btnConfigCaja.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.btnConfigCaja.BeforeTouchSize = New System.Drawing.Size(28, 20)
        Me.btnConfigCaja.ForeColor = System.Drawing.Color.White
        Me.btnConfigCaja.Image = CType(resources.GetObject("btnConfigCaja.Image"), System.Drawing.Image)
        Me.btnConfigCaja.IsBackStageButton = False
        Me.btnConfigCaja.Location = New System.Drawing.Point(0, -1)
        Me.btnConfigCaja.Name = "btnConfigCaja"
        Me.btnConfigCaja.Size = New System.Drawing.Size(28, 20)
        Me.btnConfigCaja.TabIndex = 417
        Me.btnConfigCaja.UseVisualStyle = True
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label23.Location = New System.Drawing.Point(34, 4)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(97, 13)
        Me.Label23.TabIndex = 416
        Me.Label23.Text = "Entidad Bancaria:"
        Me.Label23.Visible = False
        '
        'DockingClientPanel1
        '
        Me.DockingClientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DockingClientPanel1.Controls.Add(Me.txtPeriodo)
        Me.DockingClientPanel1.Controls.Add(Me.Label18)
        Me.DockingClientPanel1.Controls.Add(Me.txtTipoEntidad)
        Me.DockingClientPanel1.Controls.Add(Me.txtNroDocEntidad)
        Me.DockingClientPanel1.Controls.Add(Me.txtEntidad)
        Me.DockingClientPanel1.Controls.Add(Me.Label16)
        Me.DockingClientPanel1.Controls.Add(Me.pnContenedorCobro)
        Me.DockingClientPanel1.Controls.Add(Me.GroupBox1)
        Me.DockingClientPanel1.Controls.Add(Me.GradientPanel6)
        Me.DockingClientPanel1.Location = New System.Drawing.Point(0, 28)
        Me.DockingClientPanel1.Name = "DockingClientPanel1"
        Me.DockingClientPanel1.Size = New System.Drawing.Size(757, 521)
        Me.DockingClientPanel1.TabIndex = 414
        '
        'txtPeriodo
        '
        Me.txtPeriodo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtPeriodo.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtPeriodo.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtPeriodo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtPeriodo.Calendar.AllowMultipleSelection = False
        Me.txtPeriodo.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtPeriodo.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPeriodo.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtPeriodo.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtPeriodo.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtPeriodo.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtPeriodo.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPeriodo.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPeriodo.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPeriodo.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtPeriodo.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtPeriodo.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtPeriodo.Calendar.HeadForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPeriodo.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtPeriodo.Calendar.Iso8601CalenderFormat = False
        Me.txtPeriodo.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtPeriodo.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtPeriodo.Calendar.Name = "monthCalendar"
        Me.txtPeriodo.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtPeriodo.Calendar.SelectedDates = New Date(-1) {}
        Me.txtPeriodo.Calendar.Size = New System.Drawing.Size(83, 174)
        Me.txtPeriodo.Calendar.SizeToFit = True
        Me.txtPeriodo.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtPeriodo.Calendar.TabIndex = 0
        Me.txtPeriodo.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtPeriodo.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtPeriodo.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtPeriodo.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtPeriodo.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtPeriodo.Calendar.NoneButton.IsBackStageButton = False
        Me.txtPeriodo.Calendar.NoneButton.Location = New System.Drawing.Point(11, 0)
        Me.txtPeriodo.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtPeriodo.Calendar.NoneButton.Text = "None"
        Me.txtPeriodo.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtPeriodo.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtPeriodo.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtPeriodo.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtPeriodo.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtPeriodo.Calendar.TodayButton.IsBackStageButton = False
        Me.txtPeriodo.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtPeriodo.Calendar.TodayButton.Size = New System.Drawing.Size(11, 20)
        Me.txtPeriodo.Calendar.TodayButton.Text = "Today"
        Me.txtPeriodo.Calendar.TodayButton.UseVisualStyle = True
        Me.txtPeriodo.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPeriodo.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtPeriodo.CalendarTitleForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPeriodo.Checked = False
        Me.txtPeriodo.CustomFormat = "MM/yyyy"
        Me.txtPeriodo.DropDownImage = Nothing
        Me.txtPeriodo.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtPeriodo.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtPeriodo.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtPeriodo.Enabled = False
        Me.txtPeriodo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtPeriodo.Location = New System.Drawing.Point(539, 26)
        Me.txtPeriodo.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtPeriodo.MinValue = New Date(CType(0, Long))
        Me.txtPeriodo.Name = "txtPeriodo"
        Me.txtPeriodo.ShowCheckBox = False
        Me.txtPeriodo.ShowDropButton = False
        Me.txtPeriodo.ShowUpDown = True
        Me.txtPeriodo.Size = New System.Drawing.Size(87, 20)
        Me.txtPeriodo.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtPeriodo.TabIndex = 541
        Me.txtPeriodo.Value = New Date(2016, 3, 2, 12, 27, 4, 289)
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(536, 7)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(44, 14)
        Me.Label18.TabIndex = 540
        Me.Label18.Text = "Período"
        '
        'txtTipoEntidad
        '
        Me.txtTipoEntidad.BackColor = System.Drawing.Color.White
        Me.txtTipoEntidad.BeforeTouchSize = New System.Drawing.Size(195, 20)
        Me.txtTipoEntidad.BorderColor = System.Drawing.Color.DarkGray
        Me.txtTipoEntidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTipoEntidad.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTipoEntidad.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoEntidad.Location = New System.Drawing.Point(483, 24)
        Me.txtTipoEntidad.MaxLength = 20
        Me.txtTipoEntidad.Metrocolor = System.Drawing.Color.DarkGray
        Me.txtTipoEntidad.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtTipoEntidad.Name = "txtTipoEntidad"
        Me.txtTipoEntidad.ReadOnly = True
        Me.txtTipoEntidad.Size = New System.Drawing.Size(53, 22)
        Me.txtTipoEntidad.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtTipoEntidad.TabIndex = 538
        '
        'txtNroDocEntidad
        '
        Me.txtNroDocEntidad.BackColor = System.Drawing.Color.White
        Me.txtNroDocEntidad.BeforeTouchSize = New System.Drawing.Size(195, 20)
        Me.txtNroDocEntidad.BorderColor = System.Drawing.Color.DarkGray
        Me.txtNroDocEntidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNroDocEntidad.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNroDocEntidad.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNroDocEntidad.Location = New System.Drawing.Point(368, 24)
        Me.txtNroDocEntidad.MaxLength = 20
        Me.txtNroDocEntidad.Metrocolor = System.Drawing.Color.DarkGray
        Me.txtNroDocEntidad.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtNroDocEntidad.Name = "txtNroDocEntidad"
        Me.txtNroDocEntidad.ReadOnly = True
        Me.txtNroDocEntidad.Size = New System.Drawing.Size(112, 22)
        Me.txtNroDocEntidad.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtNroDocEntidad.TabIndex = 537
        '
        'txtEntidad
        '
        Me.txtEntidad.BackColor = System.Drawing.Color.White
        Me.txtEntidad.BeforeTouchSize = New System.Drawing.Size(195, 20)
        Me.txtEntidad.BorderColor = System.Drawing.Color.DarkGray
        Me.txtEntidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEntidad.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtEntidad.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEntidad.Location = New System.Drawing.Point(11, 24)
        Me.txtEntidad.MaxLength = 20
        Me.txtEntidad.Metrocolor = System.Drawing.Color.DarkGray
        Me.txtEntidad.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtEntidad.Name = "txtEntidad"
        Me.txtEntidad.NearImage = CType(resources.GetObject("txtEntidad.NearImage"), System.Drawing.Image)
        Me.txtEntidad.ReadOnly = True
        Me.txtEntidad.Size = New System.Drawing.Size(353, 22)
        Me.txtEntidad.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtEntidad.TabIndex = 536
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Corbel", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(12, 4)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(138, 15)
        Me.Label16.TabIndex = 539
        Me.Label16.Text = "Razon Social / Nombres."
        '
        'pnContenedorCobro
        '
        Me.pnContenedorCobro.Controls.Add(Me.GroupBox3)
        Me.pnContenedorCobro.Controls.Add(Me.PanelDetallePagos)
        Me.pnContenedorCobro.Controls.Add(Me.GroupBox2)
        Me.pnContenedorCobro.Controls.Add(Me.Panel1)
        Me.pnContenedorCobro.Enabled = False
        Me.pnContenedorCobro.Location = New System.Drawing.Point(5, 162)
        Me.pnContenedorCobro.Name = "pnContenedorCobro"
        Me.pnContenedorCobro.Size = New System.Drawing.Size(743, 354)
        Me.pnContenedorCobro.TabIndex = 519
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cboTipoDoc)
        Me.GroupBox3.Controls.Add(Me.pnEntidad)
        Me.GroupBox3.Controls.Add(Me.pnFecha)
        Me.GroupBox3.Controls.Add(Me.txtNumOper)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.Brown
        Me.GroupBox3.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(714, 88)
        Me.GroupBox3.TabIndex = 516
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "MEDIO PAGO"
        '
        'cboTipoDoc
        '
        Me.cboTipoDoc.BackColor = System.Drawing.Color.White
        Me.cboTipoDoc.BeforeTouchSize = New System.Drawing.Size(219, 21)
        Me.cboTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoDoc.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoDoc.Location = New System.Drawing.Point(137, 22)
        Me.cboTipoDoc.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cboTipoDoc.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cboTipoDoc.Name = "cboTipoDoc"
        Me.cboTipoDoc.Size = New System.Drawing.Size(219, 21)
        Me.cboTipoDoc.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboTipoDoc.TabIndex = 471
        '
        'pnEntidad
        '
        Me.pnEntidad.BackColor = System.Drawing.Color.Transparent
        Me.pnEntidad.Controls.Add(Me.Label2)
        Me.pnEntidad.Controls.Add(Me.PictureBox1)
        Me.pnEntidad.Controls.Add(Me.cboEntidades)
        Me.pnEntidad.Controls.Add(Me.Label19)
        Me.pnEntidad.Controls.Add(Me.txtCuentaCorriente)
        Me.pnEntidad.Location = New System.Drawing.Point(6, 47)
        Me.pnEntidad.Name = "pnEntidad"
        Me.pnEntidad.Size = New System.Drawing.Size(832, 33)
        Me.pnEntidad.TabIndex = 469
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(7, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 12)
        Me.Label2.TabIndex = 430
        Me.Label2.Text = "ENTIDAD FINANCIERA:"
        '
        'PictureBox1
        '
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(356, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(21, 21)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 439
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'cboEntidades
        '
        Me.cboEntidades.BackColor = System.Drawing.Color.White
        Me.cboEntidades.BeforeTouchSize = New System.Drawing.Size(219, 21)
        Me.cboEntidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEntidades.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEntidades.Location = New System.Drawing.Point(131, 4)
        Me.cboEntidades.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cboEntidades.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cboEntidades.Name = "cboEntidades"
        Me.cboEntidades.Size = New System.Drawing.Size(219, 21)
        Me.cboEntidades.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboEntidades.TabIndex = 436
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(402, 13)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(90, 12)
        Me.Label19.TabIndex = 438
        Me.Label19.Text = "CTA. CORRIENTE:"
        '
        'txtCuentaCorriente
        '
        Me.txtCuentaCorriente.BackColor = System.Drawing.Color.White
        Me.txtCuentaCorriente.BeforeTouchSize = New System.Drawing.Size(195, 20)
        Me.txtCuentaCorriente.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtCuentaCorriente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuentaCorriente.CornerRadius = 5
        Me.txtCuentaCorriente.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCuentaCorriente.Location = New System.Drawing.Point(498, 8)
        Me.txtCuentaCorriente.MaxLength = 20
        Me.txtCuentaCorriente.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtCuentaCorriente.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtCuentaCorriente.Name = "txtCuentaCorriente"
        Me.txtCuentaCorriente.Size = New System.Drawing.Size(195, 20)
        Me.txtCuentaCorriente.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtCuentaCorriente.TabIndex = 437
        '
        'pnFecha
        '
        Me.pnFecha.Controls.Add(Me.Label4)
        Me.pnFecha.Controls.Add(Me.txtFechaEmision)
        Me.pnFecha.Controls.Add(Me.Label10)
        Me.pnFecha.Controls.Add(Me.txtFechaCobro)
        Me.pnFecha.Location = New System.Drawing.Point(6, 86)
        Me.pnFecha.Name = "pnFecha"
        Me.pnFecha.Size = New System.Drawing.Size(832, 30)
        Me.pnFecha.TabIndex = 470
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(36, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 12)
        Me.Label4.TabIndex = 442
        Me.Label4.Text = "FECHA EMISIÓN:"
        '
        'txtFechaEmision
        '
        Me.txtFechaEmision.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFechaEmision.Location = New System.Drawing.Point(131, 6)
        Me.txtFechaEmision.Name = "txtFechaEmision"
        Me.txtFechaEmision.Size = New System.Drawing.Size(181, 20)
        Me.txtFechaEmision.TabIndex = 466
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(451, 13)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(110, 12)
        Me.Label10.TabIndex = 440
        Me.Label10.Text = "COBRO A PARTIR DE:"
        '
        'txtFechaCobro
        '
        Me.txtFechaCobro.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFechaCobro.Location = New System.Drawing.Point(567, 6)
        Me.txtFechaCobro.Name = "txtFechaCobro"
        Me.txtFechaCobro.Size = New System.Drawing.Size(181, 20)
        Me.txtFechaCobro.TabIndex = 467
        '
        'txtNumOper
        '
        Me.txtNumOper.BackColor = System.Drawing.Color.White
        Me.txtNumOper.BeforeTouchSize = New System.Drawing.Size(195, 20)
        Me.txtNumOper.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtNumOper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumOper.CornerRadius = 5
        Me.txtNumOper.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtNumOper.Location = New System.Drawing.Point(504, 24)
        Me.txtNumOper.MaxLength = 20
        Me.txtNumOper.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtNumOper.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtNumOper.Name = "txtNumOper"
        Me.txtNumOper.Size = New System.Drawing.Size(195, 20)
        Me.txtNumOper.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtNumOper.TabIndex = 211
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(401, 31)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(97, 12)
        Me.Label17.TabIndex = 434
        Me.Label17.Text = "NRO. OPERACIÓN:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(65, 30)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(63, 12)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "TIPO PAGO:"
        '
        'PanelDetallePagos
        '
        Me.PanelDetallePagos.Controls.Add(Me.dgvDetalleItems)
        Me.PanelDetallePagos.Location = New System.Drawing.Point(3, 164)
        Me.PanelDetallePagos.Name = "PanelDetallePagos"
        Me.PanelDetallePagos.Size = New System.Drawing.Size(714, 147)
        Me.PanelDetallePagos.TabIndex = 429
        '
        'dgvDetalleItems
        '
        Me.dgvDetalleItems.AllowUserToAddRows = False
        Me.dgvDetalleItems.BackgroundColor = System.Drawing.Color.SeaShell
        Me.dgvDetalleItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalleItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colId, Me.colNameItem, Me.colum, Me.ColPrecUnit, Me.colMN, Me.colME, Me.colPagoMN, Me.colPagoME, Me.colSaldoMN, Me.colSaldoME, Me.colEstado, Me.sec})
        Me.dgvDetalleItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDetalleItems.EnableHeadersVisualStyles = False
        Me.dgvDetalleItems.Location = New System.Drawing.Point(0, 0)
        Me.dgvDetalleItems.MultiSelect = False
        Me.dgvDetalleItems.Name = "dgvDetalleItems"
        Me.dgvDetalleItems.RowHeadersVisible = False
        Me.dgvDetalleItems.Size = New System.Drawing.Size(714, 147)
        Me.dgvDetalleItems.TabIndex = 114
        '
        'colId
        '
        Me.colId.HeaderText = "ID"
        Me.colId.Name = "colId"
        Me.colId.ReadOnly = True
        Me.colId.Visible = False
        Me.colId.Width = 50
        '
        'colNameItem
        '
        Me.colNameItem.HeaderText = "Descripción"
        Me.colNameItem.Name = "colNameItem"
        Me.colNameItem.ReadOnly = True
        Me.colNameItem.Width = 250
        '
        'colum
        '
        Me.colum.HeaderText = "U.M."
        Me.colum.Name = "colum"
        Me.colum.ReadOnly = True
        Me.colum.Visible = False
        Me.colum.Width = 40
        '
        'ColPrecUnit
        '
        Me.ColPrecUnit.HeaderText = "Prec Unit"
        Me.ColPrecUnit.Name = "ColPrecUnit"
        Me.ColPrecUnit.ReadOnly = True
        Me.ColPrecUnit.Visible = False
        '
        'colMN
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.colMN.DefaultCellStyle = DataGridViewCellStyle1
        Me.colMN.HeaderText = "Importe MN"
        Me.colMN.Name = "colMN"
        Me.colMN.ReadOnly = True
        Me.colMN.Width = 70
        '
        'colME
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.colME.DefaultCellStyle = DataGridViewCellStyle2
        Me.colME.HeaderText = "Importe ME"
        Me.colME.Name = "colME"
        Me.colME.ReadOnly = True
        Me.colME.Width = 70
        '
        'colPagoMN
        '
        Me.colPagoMN.HeaderText = "Pago MN"
        Me.colPagoMN.Name = "colPagoMN"
        Me.colPagoMN.Width = 70
        '
        'colPagoME
        '
        Me.colPagoME.HeaderText = "Pago ME"
        Me.colPagoME.Name = "colPagoME"
        Me.colPagoME.Width = 70
        '
        'colSaldoMN
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LavenderBlush
        Me.colSaldoMN.DefaultCellStyle = DataGridViewCellStyle3
        Me.colSaldoMN.HeaderText = "Saldo MN"
        Me.colSaldoMN.Name = "colSaldoMN"
        Me.colSaldoMN.ReadOnly = True
        Me.colSaldoMN.Width = 70
        '
        'colSaldoME
        '
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.LavenderBlush
        Me.colSaldoME.DefaultCellStyle = DataGridViewCellStyle4
        Me.colSaldoME.HeaderText = "Saldo ME"
        Me.colSaldoME.Name = "colSaldoME"
        Me.colSaldoME.ReadOnly = True
        Me.colSaldoME.Width = 70
        '
        'colEstado
        '
        Me.colEstado.HeaderText = "EST"
        Me.colEstado.Name = "colEstado"
        Me.colEstado.ReadOnly = True
        Me.colEstado.Visible = False
        Me.colEstado.Width = 50
        '
        'sec
        '
        Me.sec.HeaderText = "sec"
        Me.sec.Name = "sec"
        Me.sec.ReadOnly = True
        Me.sec.Visible = False
        Me.sec.Width = 50
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.PopupControlContainer1)
        Me.GroupBox2.Controls.Add(Me.pnDiferencia)
        Me.GroupBox2.Controls.Add(Me.pnTipoCambio)
        Me.GroupBox2.Controls.Add(Me.pnNacional)
        Me.GroupBox2.Controls.Add(Me.pnExtranjero)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Brown
        Me.GroupBox2.Location = New System.Drawing.Point(3, 97)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(714, 61)
        Me.GroupBox2.TabIndex = 517
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "REALIZAR PAGOS"
        '
        'PopupControlContainer1
        '
        Me.PopupControlContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PopupControlContainer1.Controls.Add(Me.lsvTipoCambio)
        Me.PopupControlContainer1.Controls.Add(Me.ButtonAdv2)
        Me.PopupControlContainer1.Controls.Add(Me.ButtonAdv3)
        Me.PopupControlContainer1.Location = New System.Drawing.Point(268, 62)
        Me.PopupControlContainer1.Name = "PopupControlContainer1"
        Me.PopupControlContainer1.Size = New System.Drawing.Size(251, 132)
        Me.PopupControlContainer1.TabIndex = 446
        Me.PopupControlContainer1.Visible = False
        '
        'lsvTipoCambio
        '
        Me.lsvTipoCambio.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lsvTipoCambio.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lsvTipoCambio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvTipoCambio.FullRowSelect = True
        Me.lsvTipoCambio.Location = New System.Drawing.Point(0, 0)
        Me.lsvTipoCambio.MultiSelect = False
        Me.lsvTipoCambio.Name = "lsvTipoCambio"
        Me.lsvTipoCambio.Size = New System.Drawing.Size(249, 130)
        Me.lsvTipoCambio.TabIndex = 3
        Me.lsvTipoCambio.UseCompatibleStateImageBehavior = False
        Me.lsvTipoCambio.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "idDocumento"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "T/C"
        Me.ColumnHeader2.Width = 50
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Importe ME"
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader3.Width = 80
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Importe MN"
        Me.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader4.Width = 80
        '
        'ButtonAdv2
        '
        Me.ButtonAdv2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonAdv2.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv2.BackColor = System.Drawing.SystemColors.Highlight
        Me.ButtonAdv2.BeforeTouchSize = New System.Drawing.Size(103, 66)
        Me.ButtonAdv2.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv2.IsBackStageButton = False
        Me.ButtonAdv2.Location = New System.Drawing.Point(65, 120)
        Me.ButtonAdv2.Name = "ButtonAdv2"
        Me.ButtonAdv2.Size = New System.Drawing.Size(103, 66)
        Me.ButtonAdv2.TabIndex = 2
        Me.ButtonAdv2.Text = "Cancel"
        Me.ButtonAdv2.UseVisualStyle = True
        '
        'ButtonAdv3
        '
        Me.ButtonAdv3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonAdv3.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv3.BackColor = System.Drawing.SystemColors.Highlight
        Me.ButtonAdv3.BeforeTouchSize = New System.Drawing.Size(103, 66)
        Me.ButtonAdv3.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv3.IsBackStageButton = False
        Me.ButtonAdv3.Location = New System.Drawing.Point(5, 120)
        Me.ButtonAdv3.Name = "ButtonAdv3"
        Me.ButtonAdv3.Size = New System.Drawing.Size(103, 66)
        Me.ButtonAdv3.TabIndex = 1
        Me.ButtonAdv3.Text = "ButtonAdv3"
        Me.ButtonAdv3.UseVisualStyle = True
        '
        'pnDiferencia
        '
        Me.pnDiferencia.Controls.Add(Me.PictureBox2)
        Me.pnDiferencia.Controls.Add(Me.txtDiferenciaMontos)
        Me.pnDiferencia.Controls.Add(Me.Label11)
        Me.pnDiferencia.Location = New System.Drawing.Point(525, 23)
        Me.pnDiferencia.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnDiferencia.Name = "pnDiferencia"
        Me.pnDiferencia.Size = New System.Drawing.Size(179, 28)
        Me.pnDiferencia.TabIndex = 445
        '
        'PictureBox2
        '
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox2.Location = New System.Drawing.Point(150, 4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(21, 20)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 443
        Me.PictureBox2.TabStop = False
        '
        'txtDiferenciaMontos
        '
        Me.txtDiferenciaMontos.BackColor = System.Drawing.Color.PaleGreen
        Me.txtDiferenciaMontos.BeforeTouchSize = New System.Drawing.Size(79, 21)
        Me.txtDiferenciaMontos.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtDiferenciaMontos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDiferenciaMontos.DecimalPlaces = 2
        Me.txtDiferenciaMontos.Font = New System.Drawing.Font("Arial", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiferenciaMontos.ForeColor = System.Drawing.Color.Black
        Me.txtDiferenciaMontos.Location = New System.Drawing.Point(70, 4)
        Me.txtDiferenciaMontos.Maximum = New Decimal(New Integer() {-1304428544, 434162106, 542, 0})
        Me.txtDiferenciaMontos.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtDiferenciaMontos.Minimum = New Decimal(New Integer() {-1304428544, 434162106, 542, -2147483648})
        Me.txtDiferenciaMontos.Name = "txtDiferenciaMontos"
        Me.txtDiferenciaMontos.Size = New System.Drawing.Size(79, 21)
        Me.txtDiferenciaMontos.TabIndex = 398
        Me.txtDiferenciaMontos.TabStop = False
        Me.txtDiferenciaMontos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtDiferenciaMontos.ThousandsSeparator = True
        Me.txtDiferenciaMontos.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(4, 9)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(69, 12)
        Me.Label11.TabIndex = 204
        Me.Label11.Text = "DIFERENCIA:"
        '
        'pnTipoCambio
        '
        Me.pnTipoCambio.Controls.Add(Me.PictureBox5)
        Me.pnTipoCambio.Controls.Add(Me.txtTipoCambio)
        Me.pnTipoCambio.Controls.Add(Me.Label13)
        Me.pnTipoCambio.Location = New System.Drawing.Point(207, 23)
        Me.pnTipoCambio.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnTipoCambio.Name = "pnTipoCambio"
        Me.pnTipoCambio.Size = New System.Drawing.Size(124, 29)
        Me.pnTipoCambio.TabIndex = 444
        '
        'PictureBox5
        '
        Me.PictureBox5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox5.Location = New System.Drawing.Point(94, 6)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(21, 20)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox5.TabIndex = 442
        Me.PictureBox5.TabStop = False
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.BackColor = System.Drawing.SystemColors.Info
        Me.txtTipoCambio.BeforeTouchSize = New System.Drawing.Size(55, 21)
        Me.txtTipoCambio.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTipoCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTipoCambio.DecimalPlaces = 3
        Me.txtTipoCambio.Font = New System.Drawing.Font("Arial", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoCambio.Location = New System.Drawing.Point(33, 6)
        Me.txtTipoCambio.Maximum = New Decimal(New Integer() {-159383552, 46653770, 5421, 0})
        Me.txtTipoCambio.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.Size = New System.Drawing.Size(55, 21)
        Me.txtTipoCambio.TabIndex = 400
        Me.txtTipoCambio.TabStop = False
        Me.txtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTipoCambio.ThousandsSeparator = True
        Me.txtTipoCambio.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(4, 10)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(23, 12)
        Me.Label13.TabIndex = 399
        Me.Label13.Text = "T/C:"
        '
        'pnNacional
        '
        Me.pnNacional.Controls.Add(Me.Label6)
        Me.pnNacional.Controls.Add(Me.txtImporteCompramn)
        Me.pnNacional.Location = New System.Drawing.Point(5, 23)
        Me.pnNacional.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnNacional.Name = "pnNacional"
        Me.pnNacional.Size = New System.Drawing.Size(196, 28)
        Me.pnNacional.TabIndex = 402
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(7, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 12)
        Me.Label6.TabIndex = 203
        Me.Label6.Text = "&IMPORTE MN:"
        '
        'txtImporteCompramn
        '
        Me.txtImporteCompramn.BackColor = System.Drawing.SystemColors.Info
        Me.txtImporteCompramn.BeforeTouchSize = New System.Drawing.Size(107, 21)
        Me.txtImporteCompramn.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtImporteCompramn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtImporteCompramn.DecimalPlaces = 2
        Me.txtImporteCompramn.Font = New System.Drawing.Font("Arial", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImporteCompramn.ForeColor = System.Drawing.Color.Black
        Me.txtImporteCompramn.Location = New System.Drawing.Point(83, 4)
        Me.txtImporteCompramn.Maximum = New Decimal(New Integer() {-159383552, 46653770, 5421, 0})
        Me.txtImporteCompramn.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtImporteCompramn.Name = "txtImporteCompramn"
        Me.txtImporteCompramn.Size = New System.Drawing.Size(107, 21)
        Me.txtImporteCompramn.TabIndex = 397
        Me.txtImporteCompramn.TabStop = False
        Me.txtImporteCompramn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtImporteCompramn.ThousandsSeparator = True
        Me.txtImporteCompramn.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'pnExtranjero
        '
        Me.pnExtranjero.Controls.Add(Me.Label8)
        Me.pnExtranjero.Controls.Add(Me.txtImporteComprame)
        Me.pnExtranjero.Location = New System.Drawing.Point(334, 23)
        Me.pnExtranjero.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnExtranjero.Name = "pnExtranjero"
        Me.pnExtranjero.Size = New System.Drawing.Size(185, 28)
        Me.pnExtranjero.TabIndex = 401
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(9, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 12)
        Me.Label8.TabIndex = 204
        Me.Label8.Text = "&IMPORTE ME:"
        '
        'txtImporteComprame
        '
        Me.txtImporteComprame.BackColor = System.Drawing.Color.PaleGreen
        Me.txtImporteComprame.BeforeTouchSize = New System.Drawing.Size(100, 21)
        Me.txtImporteComprame.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtImporteComprame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtImporteComprame.DecimalPlaces = 2
        Me.txtImporteComprame.Font = New System.Drawing.Font("Arial", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImporteComprame.ForeColor = System.Drawing.Color.Black
        Me.txtImporteComprame.Location = New System.Drawing.Point(82, 4)
        Me.txtImporteComprame.Maximum = New Decimal(New Integer() {-1304428544, 434162106, 542, 0})
        Me.txtImporteComprame.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtImporteComprame.Name = "txtImporteComprame"
        Me.txtImporteComprame.Size = New System.Drawing.Size(100, 21)
        Me.txtImporteComprame.TabIndex = 398
        Me.txtImporteComprame.TabStop = False
        Me.txtImporteComprame.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtImporteComprame.ThousandsSeparator = True
        Me.txtImporteComprame.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ButtonAdv4)
        Me.Panel1.Controls.Add(Me.ButtonAdv5)
        Me.Panel1.Location = New System.Drawing.Point(3, 315)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(714, 37)
        Me.Panel1.TabIndex = 434
        '
        'ButtonAdv4
        '
        Me.ButtonAdv4.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv4.BackColor = System.Drawing.Color.White
        Me.ButtonAdv4.BeforeTouchSize = New System.Drawing.Size(100, 32)
        Me.ButtonAdv4.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.ButtonAdv4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAdv4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv4.ForeColor = System.Drawing.Color.Black
        Me.ButtonAdv4.IsBackStageButton = False
        Me.ButtonAdv4.Location = New System.Drawing.Point(604, 3)
        Me.ButtonAdv4.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonAdv4.Name = "ButtonAdv4"
        Me.ButtonAdv4.Size = New System.Drawing.Size(100, 32)
        Me.ButtonAdv4.TabIndex = 11
        Me.ButtonAdv4.Text = "Cancel"
        Me.ButtonAdv4.UseVisualStyle = True
        '
        'ButtonAdv5
        '
        Me.ButtonAdv5.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv5.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonAdv5.BeforeTouchSize = New System.Drawing.Size(110, 32)
        Me.ButtonAdv5.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv5.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv5.IsBackStageButton = False
        Me.ButtonAdv5.Location = New System.Drawing.Point(480, 3)
        Me.ButtonAdv5.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonAdv5.Name = "ButtonAdv5"
        Me.ButtonAdv5.Size = New System.Drawing.Size(110, 32)
        Me.ButtonAdv5.TabIndex = 10
        Me.ButtonAdv5.Text = "Grabar cobro"
        Me.ButtonAdv5.UseVisualStyle = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Controls.Add(Me.btnSaldoCobro)
        Me.GroupBox1.Controls.Add(Me.txtFechaTrans)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Brown
        Me.GroupBox1.Location = New System.Drawing.Point(5, 51)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(717, 45)
        Me.GroupBox1.TabIndex = 518
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "FECHA DE TRANSACCION                                                             " &
    "                                                                               S" &
    "ALDO POR COBRAR"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel2.Controls.Add(Me.lblMonedaCobro)
        Me.Panel2.Location = New System.Drawing.Point(462, 15)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(95, 22)
        Me.Panel2.TabIndex = 507
        '
        'lblMonedaCobro
        '
        Me.lblMonedaCobro.AutoSize = True
        Me.lblMonedaCobro.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonedaCobro.ForeColor = System.Drawing.Color.White
        Me.lblMonedaCobro.Location = New System.Drawing.Point(18, 5)
        Me.lblMonedaCobro.Name = "lblMonedaCobro"
        Me.lblMonedaCobro.Size = New System.Drawing.Size(50, 12)
        Me.lblMonedaCobro.TabIndex = 506
        Me.lblMonedaCobro.Text = "MONEDA"
        '
        'btnSaldoCobro
        '
        Me.btnSaldoCobro.BackColor = System.Drawing.Color.White
        Me.btnSaldoCobro.Enabled = False
        Me.btnSaldoCobro.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSaldoCobro.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaldoCobro.ForeColor = System.Drawing.Color.White
        Me.btnSaldoCobro.Location = New System.Drawing.Point(563, 15)
        Me.btnSaldoCobro.Name = "btnSaldoCobro"
        Me.btnSaldoCobro.Size = New System.Drawing.Size(148, 23)
        Me.btnSaldoCobro.TabIndex = 505
        Me.btnSaldoCobro.UseVisualStyleBackColor = False
        '
        'txtFechaTrans
        '
        Me.txtFechaTrans.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtFechaTrans.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtFechaTrans.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaTrans.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtFechaTrans.Calendar.AllowMultipleSelection = False
        Me.txtFechaTrans.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaTrans.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaTrans.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechaTrans.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaTrans.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFechaTrans.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtFechaTrans.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFechaTrans.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaTrans.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaTrans.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtFechaTrans.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtFechaTrans.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtFechaTrans.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtFechaTrans.Calendar.Iso8601CalenderFormat = False
        Me.txtFechaTrans.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaTrans.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtFechaTrans.Calendar.Name = "monthCalendar"
        Me.txtFechaTrans.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtFechaTrans.Calendar.SelectedDates = New Date(-1) {}
        Me.txtFechaTrans.Calendar.Size = New System.Drawing.Size(290, 174)
        Me.txtFechaTrans.Calendar.SizeToFit = True
        Me.txtFechaTrans.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaTrans.Calendar.TabIndex = 0
        Me.txtFechaTrans.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtFechaTrans.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaTrans.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtFechaTrans.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaTrans.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaTrans.Calendar.NoneButton.IsBackStageButton = False
        Me.txtFechaTrans.Calendar.NoneButton.Location = New System.Drawing.Point(218, 0)
        Me.txtFechaTrans.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtFechaTrans.Calendar.NoneButton.Text = "None"
        Me.txtFechaTrans.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtFechaTrans.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaTrans.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtFechaTrans.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaTrans.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaTrans.Calendar.TodayButton.IsBackStageButton = False
        Me.txtFechaTrans.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaTrans.Calendar.TodayButton.Size = New System.Drawing.Size(218, 20)
        Me.txtFechaTrans.Calendar.TodayButton.Text = "Today"
        Me.txtFechaTrans.Calendar.TodayButton.UseVisualStyle = True
        Me.txtFechaTrans.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaTrans.CalendarForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaTrans.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtFechaTrans.CustomFormat = "dd/MM/yyyy hh:mm:ss tt"
        Me.txtFechaTrans.DropDownImage = Nothing
        Me.txtFechaTrans.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtFechaTrans.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtFechaTrans.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(15, Byte), Integer))
        Me.txtFechaTrans.ForeColor = System.Drawing.Color.White
        Me.txtFechaTrans.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFechaTrans.Location = New System.Drawing.Point(7, 18)
        Me.txtFechaTrans.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtFechaTrans.MinValue = New Date(CType(0, Long))
        Me.txtFechaTrans.Name = "txtFechaTrans"
        Me.txtFechaTrans.ShowCheckBox = False
        Me.txtFechaTrans.Size = New System.Drawing.Size(294, 20)
        Me.txtFechaTrans.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaTrans.TabIndex = 504
        Me.txtFechaTrans.TabStop = False
        Me.txtFechaTrans.Value = New Date(2015, 4, 14, 15, 59, 3, 447)
        '
        'GradientPanel6
        '
        Me.GradientPanel6.Controls.Add(Me.txtCuentaOrigen)
        Me.GradientPanel6.Controls.Add(Me.GroupBox5)
        Me.GradientPanel6.Controls.Add(Me.cboMoneda)
        Me.GradientPanel6.Controls.Add(Me.Label24)
        Me.GradientPanel6.Controls.Add(Me.cboTipo)
        Me.GradientPanel6.Controls.Add(Me.Label20)
        Me.GradientPanel6.Controls.Add(Me.cboDepositoHijo)
        Me.GradientPanel6.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GradientPanel6.Location = New System.Drawing.Point(5, 96)
        Me.GradientPanel6.Name = "GradientPanel6"
        Me.GradientPanel6.Size = New System.Drawing.Size(717, 61)
        Me.GradientPanel6.TabIndex = 508
        Me.GradientPanel6.TabStop = False
        '
        'txtCuentaOrigen
        '
        Me.txtCuentaOrigen.Location = New System.Drawing.Point(165, 10)
        Me.txtCuentaOrigen.Name = "txtCuentaOrigen"
        Me.txtCuentaOrigen.ReadOnly = True
        Me.txtCuentaOrigen.Size = New System.Drawing.Size(46, 20)
        Me.txtCuentaOrigen.TabIndex = 516
        Me.txtCuentaOrigen.Visible = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.pnImpMNDisp)
        Me.GroupBox5.Controls.Add(Me.pnImpMEDisp)
        Me.GroupBox5.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox5.ForeColor = System.Drawing.Color.Brown
        Me.GroupBox5.Location = New System.Drawing.Point(502, 11)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(215, 48)
        Me.GroupBox5.TabIndex = 515
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "IMPORTE DISPONIBLE"
        Me.GroupBox5.Visible = False
        '
        'pnImpMNDisp
        '
        Me.pnImpMNDisp.Controls.Add(Me.Label7)
        Me.pnImpMNDisp.Controls.Add(Me.nudDeudaPendientemn)
        Me.pnImpMNDisp.Location = New System.Drawing.Point(8, 19)
        Me.pnImpMNDisp.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnImpMNDisp.Name = "pnImpMNDisp"
        Me.pnImpMNDisp.Size = New System.Drawing.Size(177, 25)
        Me.pnImpMNDisp.TabIndex = 434
        Me.pnImpMNDisp.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.Brown
        Me.Label7.Location = New System.Drawing.Point(3, 7)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 12)
        Me.Label7.TabIndex = 433
        Me.Label7.Text = "MONTO MN:"
        '
        'nudDeudaPendientemn
        '
        Me.nudDeudaPendientemn.BackColor = System.Drawing.Color.White
        Me.nudDeudaPendientemn.BeforeTouchSize = New System.Drawing.Size(105, 22)
        Me.nudDeudaPendientemn.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.nudDeudaPendientemn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nudDeudaPendientemn.DecimalPlaces = 2
        Me.nudDeudaPendientemn.Enabled = False
        Me.nudDeudaPendientemn.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudDeudaPendientemn.Location = New System.Drawing.Point(69, 2)
        Me.nudDeudaPendientemn.Maximum = New Decimal(New Integer() {-159383552, 46653770, 5421, 0})
        Me.nudDeudaPendientemn.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.nudDeudaPendientemn.Name = "nudDeudaPendientemn"
        Me.nudDeudaPendientemn.Size = New System.Drawing.Size(105, 22)
        Me.nudDeudaPendientemn.TabIndex = 432
        Me.nudDeudaPendientemn.ThousandsSeparator = True
        Me.nudDeudaPendientemn.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'pnImpMEDisp
        '
        Me.pnImpMEDisp.Controls.Add(Me.nudDeudaPendienteme)
        Me.pnImpMEDisp.Controls.Add(Me.Label1)
        Me.pnImpMEDisp.Location = New System.Drawing.Point(189, 17)
        Me.pnImpMEDisp.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnImpMEDisp.Name = "pnImpMEDisp"
        Me.pnImpMEDisp.Size = New System.Drawing.Size(165, 27)
        Me.pnImpMEDisp.TabIndex = 435
        Me.pnImpMEDisp.Visible = False
        '
        'nudDeudaPendienteme
        '
        Me.nudDeudaPendienteme.BackColor = System.Drawing.Color.PaleGreen
        Me.nudDeudaPendienteme.BeforeTouchSize = New System.Drawing.Size(93, 22)
        Me.nudDeudaPendienteme.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.nudDeudaPendienteme.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nudDeudaPendienteme.DecimalPlaces = 2
        Me.nudDeudaPendienteme.Enabled = False
        Me.nudDeudaPendienteme.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudDeudaPendienteme.Location = New System.Drawing.Point(69, 2)
        Me.nudDeudaPendienteme.Maximum = New Decimal(New Integer() {-159383552, 46653770, 5421, 0})
        Me.nudDeudaPendienteme.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.nudDeudaPendienteme.Name = "nudDeudaPendienteme"
        Me.nudDeudaPendienteme.Size = New System.Drawing.Size(93, 22)
        Me.nudDeudaPendienteme.TabIndex = 431
        Me.nudDeudaPendienteme.ThousandsSeparator = True
        Me.nudDeudaPendienteme.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Brown
        Me.Label1.Location = New System.Drawing.Point(3, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 12)
        Me.Label1.TabIndex = 54
        Me.Label1.Text = "MONTO ME:"
        '
        'cboMoneda
        '
        Me.cboMoneda.BackColor = System.Drawing.Color.White
        Me.cboMoneda.BeforeTouchSize = New System.Drawing.Size(114, 21)
        Me.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMoneda.Enabled = False
        Me.cboMoneda.FlatBorderColor = System.Drawing.SystemColors.AppWorkspace
        Me.cboMoneda.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMoneda.Location = New System.Drawing.Point(383, 32)
        Me.cboMoneda.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cboMoneda.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cboMoneda.Name = "cboMoneda"
        Me.cboMoneda.Size = New System.Drawing.Size(114, 21)
        Me.cboMoneda.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboMoneda.TabIndex = 505
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.Label24.ForeColor = System.Drawing.Color.Brown
        Me.Label24.Location = New System.Drawing.Point(7, 14)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(51, 12)
        Me.Label24.TabIndex = 498
        Me.Label24.Text = "CUENTAS"
        '
        'cboTipo
        '
        Me.cboTipo.BackColor = System.Drawing.Color.White
        Me.cboTipo.BeforeTouchSize = New System.Drawing.Size(155, 21)
        Me.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipo.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cboTipo.Items.AddRange(New Object() {"CUENTAS EN EFECTIVO", "CUENTAS EN BANCO", "TARJETA DE CREDITO"})
        Me.cboTipo.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboTipo, "CUENTAS EN EFECTIVO"))
        Me.cboTipo.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboTipo, "CUENTAS EN BANCO"))
        Me.cboTipo.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboTipo, "TARJETA DE CREDITO"))
        Me.cboTipo.Location = New System.Drawing.Point(5, 32)
        Me.cboTipo.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(155, 21)
        Me.cboTipo.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboTipo.TabIndex = 501
        Me.cboTipo.Text = "CUENTAS EN EFECTIVO"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Brown
        Me.Label20.Location = New System.Drawing.Point(381, 14)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(50, 12)
        Me.Label20.TabIndex = 406
        Me.Label20.Text = "MONEDA"
        '
        'cboDepositoHijo
        '
        Me.cboDepositoHijo.BackColor = System.Drawing.Color.White
        Me.cboDepositoHijo.BeforeTouchSize = New System.Drawing.Size(212, 21)
        Me.cboDepositoHijo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDepositoHijo.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDepositoHijo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cboDepositoHijo.Location = New System.Drawing.Point(165, 32)
        Me.cboDepositoHijo.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cboDepositoHijo.Name = "cboDepositoHijo"
        Me.cboDepositoHijo.Size = New System.Drawing.Size(212, 21)
        Me.cboDepositoHijo.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboDepositoHijo.TabIndex = 500
        '
        'GradientPanel1
        '
        Me.GradientPanel1.Controls.Add(Me.pnTipoCambioVenta)
        Me.GradientPanel1.Controls.Add(Me.pnSaldoME)
        Me.GradientPanel1.Controls.Add(Me.pnSaldoMN)
        Me.GradientPanel1.Controls.Add(Me.Label29)
        Me.GradientPanel1.Controls.Add(Me.tb19)
        Me.GradientPanel1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GradientPanel1.ForeColor = System.Drawing.Color.Brown
        Me.GradientPanel1.Location = New System.Drawing.Point(8, 215)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(287, 176)
        Me.GradientPanel1.TabIndex = 509
        Me.GradientPanel1.TabStop = False
        Me.GradientPanel1.Text = "SALDO POR COBRAR"
        '
        'pnTipoCambioVenta
        '
        Me.pnTipoCambioVenta.Controls.Add(Me.Label30)
        Me.pnTipoCambioVenta.Controls.Add(Me.lblTipoCambio)
        Me.pnTipoCambioVenta.Location = New System.Drawing.Point(9, 23)
        Me.pnTipoCambioVenta.Name = "pnTipoCambioVenta"
        Me.pnTipoCambioVenta.Size = New System.Drawing.Size(228, 20)
        Me.pnTipoCambioVenta.TabIndex = 512
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.Label30.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label30.Location = New System.Drawing.Point(42, 5)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(92, 12)
        Me.Label30.TabIndex = 435
        Me.Label30.Text = "TIPO DE CAMBIO:"
        '
        'lblTipoCambio
        '
        Me.lblTipoCambio.AutoSize = True
        Me.lblTipoCambio.BackColor = System.Drawing.Color.Transparent
        Me.lblTipoCambio.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoCambio.ForeColor = System.Drawing.Color.Maroon
        Me.lblTipoCambio.Location = New System.Drawing.Point(153, 4)
        Me.lblTipoCambio.Name = "lblTipoCambio"
        Me.lblTipoCambio.Size = New System.Drawing.Size(31, 13)
        Me.lblTipoCambio.TabIndex = 434
        Me.lblTipoCambio.Text = "0.00"
        '
        'pnSaldoME
        '
        Me.pnSaldoME.Controls.Add(Me.pnColorME)
        Me.pnSaldoME.Controls.Add(Me.Label9)
        Me.pnSaldoME.Location = New System.Drawing.Point(9, 74)
        Me.pnSaldoME.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnSaldoME.Name = "pnSaldoME"
        Me.pnSaldoME.Size = New System.Drawing.Size(228, 31)
        Me.pnSaldoME.TabIndex = 437
        '
        'pnColorME
        '
        Me.pnColorME.Controls.Add(Me.lblDeudaPendienteme)
        Me.pnColorME.Location = New System.Drawing.Point(141, 6)
        Me.pnColorME.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnColorME.Name = "pnColorME"
        Me.pnColorME.Size = New System.Drawing.Size(85, 21)
        Me.pnColorME.TabIndex = 56
        '
        'lblDeudaPendienteme
        '
        Me.lblDeudaPendienteme.AutoSize = True
        Me.lblDeudaPendienteme.BackColor = System.Drawing.Color.Transparent
        Me.lblDeudaPendienteme.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeudaPendienteme.ForeColor = System.Drawing.Color.Maroon
        Me.lblDeudaPendienteme.Location = New System.Drawing.Point(12, 4)
        Me.lblDeudaPendienteme.Name = "lblDeudaPendienteme"
        Me.lblDeudaPendienteme.Size = New System.Drawing.Size(31, 13)
        Me.lblDeudaPendienteme.TabIndex = 55
        Me.lblDeudaPendienteme.Text = "0.00"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(9, 11)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(133, 12)
        Me.Label9.TabIndex = 54
        Me.Label9.Text = "PENDIENTE DE PAGO ME:"
        '
        'pnSaldoMN
        '
        Me.pnSaldoMN.Controls.Add(Me.pnColorMN)
        Me.pnSaldoMN.Controls.Add(Me.Label21)
        Me.pnSaldoMN.Location = New System.Drawing.Point(9, 44)
        Me.pnSaldoMN.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnSaldoMN.Name = "pnSaldoMN"
        Me.pnSaldoMN.Size = New System.Drawing.Size(228, 30)
        Me.pnSaldoMN.TabIndex = 436
        '
        'pnColorMN
        '
        Me.pnColorMN.BackColor = System.Drawing.Color.White
        Me.pnColorMN.Controls.Add(Me.lblDeudaPendiente)
        Me.pnColorMN.Location = New System.Drawing.Point(141, 4)
        Me.pnColorMN.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnColorMN.Name = "pnColorMN"
        Me.pnColorMN.Size = New System.Drawing.Size(85, 21)
        Me.pnColorMN.TabIndex = 224
        '
        'lblDeudaPendiente
        '
        Me.lblDeudaPendiente.AutoSize = True
        Me.lblDeudaPendiente.BackColor = System.Drawing.Color.Transparent
        Me.lblDeudaPendiente.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeudaPendiente.ForeColor = System.Drawing.Color.Maroon
        Me.lblDeudaPendiente.Location = New System.Drawing.Point(12, 3)
        Me.lblDeudaPendiente.Name = "lblDeudaPendiente"
        Me.lblDeudaPendiente.Size = New System.Drawing.Size(31, 13)
        Me.lblDeudaPendiente.TabIndex = 51
        Me.lblDeudaPendiente.Text = "0.00"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.Label21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label21.Location = New System.Drawing.Point(8, 8)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(133, 12)
        Me.Label21.TabIndex = 223
        Me.Label21.Text = "PENDIENTE DE PAGO MN:"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label29.Location = New System.Drawing.Point(94, 118)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(85, 12)
        Me.Label29.TabIndex = 433
        Me.Label29.Text = "MONEDA VENTA"
        '
        'tb19
        '
        Me.tb19.ActiveColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.tb19.ActiveText = "Nacional"
        Me.tb19.BackColor = System.Drawing.Color.Transparent
        Me.tb19.Enabled = False
        Me.tb19.InActiveColor = System.Drawing.Color.WhiteSmoke
        Me.tb19.InActiveText = "Extranjera"
        Me.tb19.Location = New System.Drawing.Point(85, 133)
        Me.tb19.MaximumSize = New System.Drawing.Size(135, 51)
        Me.tb19.MinimumSize = New System.Drawing.Size(93, 30)
        Me.tb19.Name = "tb19"
        Me.tb19.Size = New System.Drawing.Size(116, 30)
        Me.tb19.SliderColor = System.Drawing.Color.Black
        Me.tb19.SlidingAngle = 8
        Me.tb19.TabIndex = 432
        Me.tb19.Text = "ToggleButton21"
        Me.tb19.TextColor = System.Drawing.Color.White
        Me.tb19.ToggleState = Helios.Cont.Presentation.WinForm.ToggleButton2.ToggleButtonState.[ON]
        Me.tb19.ToggleStyle = Helios.Cont.Presentation.WinForm.ToggleButton2.ToggleButtonStyle.IOS
        '
        'gpVSBehavior
        '
        Me.gpVSBehavior.Controls.Add(Me.GradientPanel1)
        Me.gpVSBehavior.Controls.Add(Me.txtFechaComprobante)
        Me.gpVSBehavior.Controls.Add(Me.txtNumeroCompr)
        Me.gpVSBehavior.Controls.Add(Me.txtSerieCompr)
        Me.gpVSBehavior.Controls.Add(Me.Label3)
        Me.gpVSBehavior.Controls.Add(Me.txtComprobante)
        Me.gpVSBehavior.Controls.Add(Me.Label25)
        Me.gpVSBehavior.Controls.Add(Me.Label22)
        Me.gpVSBehavior.Controls.Add(Me.Label26)
        Me.gpVSBehavior.Controls.Add(Me.txtProveedor)
        Me.gpVSBehavior.Controls.Add(Me.Label34)
        Me.gpVSBehavior.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpVSBehavior.ForeColor = System.Drawing.Color.Brown
        Me.gpVSBehavior.Location = New System.Drawing.Point(796, 510)
        Me.gpVSBehavior.Name = "gpVSBehavior"
        Me.gpVSBehavior.Size = New System.Drawing.Size(304, 397)
        Me.gpVSBehavior.TabIndex = 453
        Me.gpVSBehavior.TabStop = False
        '
        'txtFechaComprobante
        '
        Me.txtFechaComprobante.BackColor = System.Drawing.SystemColors.Info
        Me.txtFechaComprobante.BeforeTouchSize = New System.Drawing.Size(195, 20)
        Me.txtFechaComprobante.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtFechaComprobante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaComprobante.CornerRadius = 5
        Me.txtFechaComprobante.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFechaComprobante.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaComprobante.Location = New System.Drawing.Point(8, 85)
        Me.txtFechaComprobante.MaxLength = 20
        Me.txtFechaComprobante.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtFechaComprobante.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtFechaComprobante.Name = "txtFechaComprobante"
        Me.txtFechaComprobante.ReadOnly = True
        Me.txtFechaComprobante.Size = New System.Drawing.Size(191, 20)
        Me.txtFechaComprobante.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtFechaComprobante.TabIndex = 458
        '
        'txtNumeroCompr
        '
        Me.txtNumeroCompr.BackColor = System.Drawing.SystemColors.Info
        Me.txtNumeroCompr.BeforeTouchSize = New System.Drawing.Size(195, 20)
        Me.txtNumeroCompr.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtNumeroCompr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumeroCompr.CornerRadius = 5
        Me.txtNumeroCompr.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNumeroCompr.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumeroCompr.Location = New System.Drawing.Point(8, 177)
        Me.txtNumeroCompr.MaxLength = 20
        Me.txtNumeroCompr.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtNumeroCompr.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtNumeroCompr.Name = "txtNumeroCompr"
        Me.txtNumeroCompr.ReadOnly = True
        Me.txtNumeroCompr.Size = New System.Drawing.Size(150, 20)
        Me.txtNumeroCompr.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtNumeroCompr.TabIndex = 457
        '
        'txtSerieCompr
        '
        Me.txtSerieCompr.BackColor = System.Drawing.SystemColors.Info
        Me.txtSerieCompr.BeforeTouchSize = New System.Drawing.Size(195, 20)
        Me.txtSerieCompr.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtSerieCompr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSerieCompr.CornerRadius = 5
        Me.txtSerieCompr.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtSerieCompr.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerieCompr.Location = New System.Drawing.Point(165, 177)
        Me.txtSerieCompr.MaxLength = 20
        Me.txtSerieCompr.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtSerieCompr.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtSerieCompr.Name = "txtSerieCompr"
        Me.txtSerieCompr.ReadOnly = True
        Me.txtSerieCompr.Size = New System.Drawing.Size(75, 20)
        Me.txtSerieCompr.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtSerieCompr.TabIndex = 456
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(163, 161)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 12)
        Me.Label3.TabIndex = 452
        Me.Label3.Text = "SERIE"
        '
        'txtComprobante
        '
        Me.txtComprobante.BackColor = System.Drawing.SystemColors.Info
        Me.txtComprobante.BeforeTouchSize = New System.Drawing.Size(195, 20)
        Me.txtComprobante.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtComprobante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComprobante.CornerRadius = 5
        Me.txtComprobante.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtComprobante.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComprobante.Location = New System.Drawing.Point(8, 130)
        Me.txtComprobante.MaxLength = 20
        Me.txtComprobante.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtComprobante.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtComprobante.Name = "txtComprobante"
        Me.txtComprobante.ReadOnly = True
        Me.txtComprobante.Size = New System.Drawing.Size(287, 20)
        Me.txtComprobante.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtComprobante.TabIndex = 455
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.Label25.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label25.Location = New System.Drawing.Point(6, 162)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(50, 12)
        Me.Label25.TabIndex = 454
        Me.Label25.Text = "NUMERO"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label22.Location = New System.Drawing.Point(6, 115)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(110, 12)
        Me.Label22.TabIndex = 453
        Me.Label22.Text = "TIPO COMPROBANTE"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label26.Location = New System.Drawing.Point(6, 24)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(70, 12)
        Me.Label26.TabIndex = 2
        Me.Label26.Text = "PROVEEDOR"
        '
        'txtProveedor
        '
        Me.txtProveedor.BackColor = System.Drawing.SystemColors.Info
        Me.txtProveedor.BeforeTouchSize = New System.Drawing.Size(195, 20)
        Me.txtProveedor.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProveedor.CornerRadius = 5
        Me.txtProveedor.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtProveedor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtProveedor.Location = New System.Drawing.Point(8, 40)
        Me.txtProveedor.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtProveedor.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.NearImage = CType(resources.GetObject("txtProveedor.NearImage"), System.Drawing.Image)
        Me.txtProveedor.Size = New System.Drawing.Size(287, 20)
        Me.txtProveedor.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtProveedor.TabIndex = 216
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.BackColor = System.Drawing.Color.Transparent
        Me.Label34.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label34.Location = New System.Drawing.Point(6, 70)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(39, 12)
        Me.Label34.TabIndex = 0
        Me.Label34.Text = "FECHA"
        '
        'PopupControlContainer3
        '
        Me.PopupControlContainer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PopupControlContainer3.Controls.Add(Me.pn)
        Me.PopupControlContainer3.Controls.Add(Me.ButtonAdv6)
        Me.PopupControlContainer3.Controls.Add(Me.ButtonAdv9)
        Me.PopupControlContainer3.Location = New System.Drawing.Point(900, 395)
        Me.PopupControlContainer3.Name = "PopupControlContainer3"
        Me.PopupControlContainer3.Size = New System.Drawing.Size(751, 166)
        Me.PopupControlContainer3.TabIndex = 511
        '
        'pn
        '
        Me.pn.Controls.Add(Me.dgvDiferencia)
        Me.pn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pn.Location = New System.Drawing.Point(0, 0)
        Me.pn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pn.Name = "pn"
        Me.pn.Size = New System.Drawing.Size(749, 164)
        Me.pn.TabIndex = 210
        '
        'dgvDiferencia
        '
        Me.dgvDiferencia.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        Me.dgvDiferencia.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.dgvDiferencia.BackColor = System.Drawing.SystemColors.Window
        Me.dgvDiferencia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDiferencia.FreezeCaption = False
        Me.dgvDiferencia.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgvDiferencia.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.dgvDiferencia.Location = New System.Drawing.Point(0, 0)
        Me.dgvDiferencia.Name = "dgvDiferencia"
        Me.dgvDiferencia.Size = New System.Drawing.Size(749, 164)
        Me.dgvDiferencia.TabIndex = 295
        Me.dgvDiferencia.TableDescriptor.AllowNew = False
        Me.dgvDiferencia.TableDescriptor.Appearance.AnyCell.Font.Facename = "Segoe UI"
        Me.dgvDiferencia.TableDescriptor.Appearance.AnyCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.dgvDiferencia.TableDescriptor.Appearance.AnyGroupCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvDiferencia.TableDescriptor.Appearance.AnyGroupCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvDiferencia.TableDescriptor.Appearance.AnyGroupCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer)))
        Me.dgvDiferencia.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvDiferencia.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvDiferencia.TableDescriptor.Appearance.AnySummaryCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvDiferencia.TableDescriptor.Appearance.AnySummaryCell.Borders.Top = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvDiferencia.TableDescriptor.Appearance.AnySummaryCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)))
        Me.dgvDiferencia.TableDescriptor.Appearance.ColumnHeaderCell.Font.Bold = True
        Me.dgvDiferencia.TableDescriptor.Appearance.ColumnHeaderCell.Font.Italic = False
        Me.dgvDiferencia.TableDescriptor.Appearance.ColumnHeaderCell.Font.Size = 8.0!
        Me.dgvDiferencia.TableDescriptor.Appearance.GroupCaptionCell.CellType = """ColumnHeader"""
        GridColumnDescriptor1.AllowSort = False
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.HeaderText = "ID"
        GridColumnDescriptor1.MappingName = "idDocumento"
        GridColumnDescriptor1.Name = "idDocumento"
        GridColumnDescriptor1.ReadOnly = True
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor1.Width = 50
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.HeaderText = "T/C"
        GridColumnDescriptor2.MappingName = "TC"
        GridColumnDescriptor2.Name = "TC"
        GridColumnDescriptor2.ReadOnly = True
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor2.Width = 50
        GridColumnDescriptor3.AllowSort = False
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.HeaderText = "Importe MN"
        GridColumnDescriptor3.MappingName = "importeMN"
        GridColumnDescriptor3.Name = "importeMN"
        GridColumnDescriptor3.ReadOnly = True
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor3.Width = 100
        GridColumnDescriptor4.AllowSort = False
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.HeaderText = "Importe ME"
        GridColumnDescriptor4.MappingName = "importeME"
        GridColumnDescriptor4.Name = "importeME"
        GridColumnDescriptor4.ReadOnly = True
        GridColumnDescriptor4.SerializedImageArray = ""
        GridColumnDescriptor4.Width = 100
        GridColumnDescriptor5.HeaderImage = Nothing
        GridColumnDescriptor5.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor5.HeaderText = "T/C"
        GridColumnDescriptor5.MappingName = "TCCompra"
        GridColumnDescriptor5.Name = "TCCompra"
        GridColumnDescriptor5.SerializedImageArray = ""
        GridColumnDescriptor5.Width = 50
        GridColumnDescriptor6.AllowSort = False
        GridColumnDescriptor6.HeaderImage = Nothing
        GridColumnDescriptor6.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor6.HeaderText = "Importe MN"
        GridColumnDescriptor6.MappingName = "importeCompraMN"
        GridColumnDescriptor6.Name = "importeCompraMN"
        GridColumnDescriptor6.ReadOnly = True
        GridColumnDescriptor6.SerializedImageArray = ""
        GridColumnDescriptor6.Width = 100
        GridColumnDescriptor7.AllowSort = False
        GridColumnDescriptor7.HeaderImage = Nothing
        GridColumnDescriptor7.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor7.HeaderText = "Importe ME"
        GridColumnDescriptor7.MappingName = "importeCompraME"
        GridColumnDescriptor7.Name = "importeCompraME"
        GridColumnDescriptor7.ReadOnly = True
        GridColumnDescriptor7.SerializedImageArray = ""
        GridColumnDescriptor7.Width = 100
        GridColumnDescriptor8.AllowSort = False
        GridColumnDescriptor8.HeaderImage = Nothing
        GridColumnDescriptor8.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor8.HeaderText = "Importe MN"
        GridColumnDescriptor8.MappingName = "difMNCajaMN"
        GridColumnDescriptor8.Name = "difMNCajaMN"
        GridColumnDescriptor8.ReadOnly = True
        GridColumnDescriptor8.SerializedImageArray = ""
        GridColumnDescriptor8.Width = 100
        GridColumnDescriptor9.AllowSort = False
        GridColumnDescriptor9.HeaderImage = Nothing
        GridColumnDescriptor9.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor9.HeaderText = "Importe ME"
        GridColumnDescriptor9.MappingName = "difMNCajaME"
        GridColumnDescriptor9.Name = "difMNCajaME"
        GridColumnDescriptor9.ReadOnly = True
        GridColumnDescriptor9.SerializedImageArray = ""
        GridColumnDescriptor9.Width = 100
        Me.dgvDiferencia.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7, GridColumnDescriptor8, GridColumnDescriptor9})
        GridSummaryRowDescriptor1.Name = "Row 1"
        GridSummaryColumnDescriptor1.Appearance.AnySummaryCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
        GridSummaryColumnDescriptor1.Appearance.AnySummaryCell.TextAlign = Syncfusion.Windows.Forms.Grid.GridTextAlign.[Default]
        GridSummaryColumnDescriptor1.DataMember = "difMNCajaMN"
        GridSummaryColumnDescriptor1.Format = "{Sum}"
        GridSummaryColumnDescriptor1.Name = "difMNCajaMN"
        GridSummaryColumnDescriptor1.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        GridSummaryColumnDescriptor2.Appearance.AnySummaryCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
        GridSummaryColumnDescriptor2.Appearance.AnySummaryCell.TextAlign = Syncfusion.Windows.Forms.Grid.GridTextAlign.[Default]
        GridSummaryColumnDescriptor2.DataMember = "difMNCajaME"
        GridSummaryColumnDescriptor2.Format = "{Sum}"
        GridSummaryColumnDescriptor2.Name = "difMNCajaME"
        GridSummaryColumnDescriptor2.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        GridSummaryRowDescriptor1.SummaryColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor() {GridSummaryColumnDescriptor1, GridSummaryColumnDescriptor2})
        Me.dgvDiferencia.TableDescriptor.SummaryRows.Add(GridSummaryRowDescriptor1)
        Me.dgvDiferencia.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.dgvDiferencia.TableDescriptor.TableOptions.RecordRowHeight = 20
        Me.dgvDiferencia.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("TC"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("importeMN"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("importeME"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("TCCompra"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("importeCompraMN"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("importeCompraME"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("difMNCajaMN"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("difMNCajaME")})
        Me.dgvDiferencia.Text = "GridGroupingControl2"
        Me.dgvDiferencia.VersionInfo = "12.4400.0.24"
        '
        'ButtonAdv6
        '
        Me.ButtonAdv6.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv6.BackColor = System.Drawing.SystemColors.Highlight
        Me.ButtonAdv6.BeforeTouchSize = New System.Drawing.Size(60, 19)
        Me.ButtonAdv6.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv6.IsBackStageButton = False
        Me.ButtonAdv6.Location = New System.Drawing.Point(64, 110)
        Me.ButtonAdv6.Name = "ButtonAdv6"
        Me.ButtonAdv6.Size = New System.Drawing.Size(60, 19)
        Me.ButtonAdv6.TabIndex = 209
        Me.ButtonAdv6.Text = "Cancelar"
        Me.ButtonAdv6.UseVisualStyle = True
        '
        'ButtonAdv9
        '
        Me.ButtonAdv9.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv9.BackColor = System.Drawing.SystemColors.Highlight
        Me.ButtonAdv9.BeforeTouchSize = New System.Drawing.Size(60, 19)
        Me.ButtonAdv9.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv9.IsBackStageButton = False
        Me.ButtonAdv9.Location = New System.Drawing.Point(4, 110)
        Me.ButtonAdv9.Name = "ButtonAdv9"
        Me.ButtonAdv9.Size = New System.Drawing.Size(60, 19)
        Me.ButtonAdv9.TabIndex = 208
        Me.ButtonAdv9.Text = "OK"
        Me.ButtonAdv9.UseVisualStyle = True
        '
        'cboooottr
        '
        Me.cboooottr.BackColor = System.Drawing.Color.White
        Me.cboooottr.BeforeTouchSize = New System.Drawing.Size(190, 21)
        Me.cboooottr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboooottr.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboooottr.Location = New System.Drawing.Point(60, 8)
        Me.cboooottr.Name = "cboooottr"
        Me.cboooottr.Size = New System.Drawing.Size(190, 21)
        Me.cboooottr.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboooottr.TabIndex = 436
        '
        'cbooo
        '
        Me.cbooo.BackColor = System.Drawing.Color.White
        Me.cbooo.BeforeTouchSize = New System.Drawing.Size(181, 21)
        Me.cbooo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbooo.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbooo.Location = New System.Drawing.Point(89, 83)
        Me.cbooo.Name = "cbooo"
        Me.cbooo.Size = New System.Drawing.Size(181, 21)
        Me.cbooo.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cbooo.TabIndex = 401
        '
        'cboTipoDocument
        '
        Me.cboTipoDocument.BackColor = System.Drawing.Color.White
        Me.cboTipoDocument.BeforeTouchSize = New System.Drawing.Size(181, 21)
        Me.cboTipoDocument.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoDocument.Enabled = False
        Me.cboTipoDocument.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoDocument.Location = New System.Drawing.Point(89, 34)
        Me.cboTipoDocument.Name = "cboTipoDocument"
        Me.cboTipoDocument.Size = New System.Drawing.Size(181, 21)
        Me.cboTipoDocument.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboTipoDocument.TabIndex = 212
        Me.cboTipoDocument.TabStop = False
        '
        'dockingManager1
        '
        Me.dockingManager1.ActiveCaptionFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.dockingManager1.AutoHideTabFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.dockingManager1.DockLayoutStream = CType(resources.GetObject("dockingManager1.DockLayoutStream"), System.IO.MemoryStream)
        Me.dockingManager1.DockTabFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.dockingManager1.HostControl = Me
        Me.dockingManager1.InActiveCaptionBackground = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer)))
        Me.dockingManager1.InActiveCaptionFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.dockingManager1.MetroButtonColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dockingManager1.MetroCaptionColor = System.Drawing.Color.White
        Me.dockingManager1.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.dockingManager1.MetroSplitterBackColor = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.dockingManager1.ReduceFlickeringInRtl = False
        Me.dockingManager1.SplitterWidth = 1
        Me.dockingManager1.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.dockingManager1.CaptionButtons.Add(New Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Close, "CloseButton"))
        Me.dockingManager1.CaptionButtons.Add(New Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Pin, "PinButton"))
        Me.dockingManager1.CaptionButtons.Add(New Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Maximize, "MaximizeButton"))
        Me.dockingManager1.CaptionButtons.Add(New Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Restore, "RestoreButton"))
        Me.dockingManager1.CaptionButtons.Add(New Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Menu, "MenuButton"))
        '
        'Timer1
        '
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        '
        'btGrabar
        '
        Me.btGrabar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btGrabar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btGrabar.Image = CType(resources.GetObject("btGrabar.Image"), System.Drawing.Image)
        Me.btGrabar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btGrabar.Name = "btGrabar"
        Me.btGrabar.Size = New System.Drawing.Size(44, 42)
        Me.btGrabar.Text = "Grabar"
        '
        'PanelError
        '
        Me.PanelError.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PanelError.Controls.Add(Me.PictureBox3)
        Me.PanelError.Controls.Add(Me.lblEstado)
        Me.PanelError.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelError.Location = New System.Drawing.Point(0, 0)
        Me.PanelError.Name = "PanelError"
        Me.PanelError.Size = New System.Drawing.Size(760, 22)
        Me.PanelError.TabIndex = 430
        Me.PanelError.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox3.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(741, 0)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(19, 22)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 288
        Me.PictureBox3.TabStop = False
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.BackColor = System.Drawing.Color.Transparent
        Me.lblEstado.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblEstado.Location = New System.Drawing.Point(9, 4)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(79, 13)
        Me.lblEstado.TabIndex = 0
        Me.lblEstado.Text = "Mensaje error"
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(0, 0)
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(75, 23)
        Me.ButtonAdv1.TabIndex = 0
        '
        'btOperacion
        '
        Me.btOperacion.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.btOperacion.IsBackStageButton = False
        Me.btOperacion.Location = New System.Drawing.Point(0, 0)
        Me.btOperacion.Name = "btOperacion"
        Me.btOperacion.Size = New System.Drawing.Size(75, 23)
        Me.btOperacion.TabIndex = 0
        '
        'frmCobros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CaptionBarHeight = 50
        Me.CaptionButtonColor = System.Drawing.Color.White
        Me.CaptionButtonHoverColor = System.Drawing.Color.White
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.White
        CaptionLabel1.Location = New System.Drawing.Point(30, 9)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(700, 24)
        CaptionLabel1.Text = "COBROS"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(760, 561)
        Me.Controls.Add(Me.gpVSBehavior)
        Me.Controls.Add(Me.PopupControlContainer3)
        Me.Controls.Add(Me.PanelError)
        Me.Controls.Add(Me.DockingClientPanel1)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.ToolStrip3)
        Me.Name = "frmCobros"
        Me.ShowIcon = False
        Me.Text = ""
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.DockingClientPanel1.ResumeLayout(False)
        Me.DockingClientPanel1.PerformLayout()
        CType(Me.txtPeriodo.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPeriodo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoEntidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNroDocEntidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEntidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnContenedorCobro.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.cboTipoDoc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnEntidad.ResumeLayout(False)
        Me.pnEntidad.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboEntidades, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCuentaCorriente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnFecha.ResumeLayout(False)
        Me.pnFecha.PerformLayout()
        CType(Me.txtNumOper, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelDetallePagos.ResumeLayout(False)
        CType(Me.dgvDetalleItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.PopupControlContainer1.ResumeLayout(False)
        Me.pnDiferencia.ResumeLayout(False)
        Me.pnDiferencia.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDiferenciaMontos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnTipoCambio.ResumeLayout(False)
        Me.pnTipoCambio.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoCambio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnNacional.ResumeLayout(False)
        Me.pnNacional.PerformLayout()
        CType(Me.txtImporteCompramn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnExtranjero.ResumeLayout(False)
        Me.pnExtranjero.PerformLayout()
        CType(Me.txtImporteComprame, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.txtFechaTrans.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaTrans, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel6.ResumeLayout(False)
        Me.GradientPanel6.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.pnImpMNDisp.ResumeLayout(False)
        Me.pnImpMNDisp.PerformLayout()
        CType(Me.nudDeudaPendientemn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnImpMEDisp.ResumeLayout(False)
        Me.pnImpMEDisp.PerformLayout()
        CType(Me.nudDeudaPendienteme, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDepositoHijo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        Me.pnTipoCambioVenta.ResumeLayout(False)
        Me.pnTipoCambioVenta.PerformLayout()
        Me.pnSaldoME.ResumeLayout(False)
        Me.pnSaldoME.PerformLayout()
        Me.pnColorME.ResumeLayout(False)
        Me.pnColorME.PerformLayout()
        Me.pnSaldoMN.ResumeLayout(False)
        Me.pnSaldoMN.PerformLayout()
        Me.pnColorMN.ResumeLayout(False)
        Me.pnColorMN.PerformLayout()
        Me.gpVSBehavior.ResumeLayout(False)
        Me.gpVSBehavior.PerformLayout()
        CType(Me.txtFechaComprobante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumeroCompr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSerieCompr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtComprobante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PopupControlContainer3.ResumeLayout(False)
        Me.pn.ResumeLayout(False)
        CType(Me.dgvDiferencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboooottr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbooo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTipoDocument, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dockingManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelError.ResumeLayout(False)
        Me.PanelError.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents GuardarToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PegarToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblIdDocumento As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lbldDocCaja As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents btnConfigCaja As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents DockingClientPanel1 As Syncfusion.Windows.Forms.Tools.DockingClientPanel
    Friend WithEvents cboooottr As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents PanelDetallePagos As System.Windows.Forms.Panel
    Friend WithEvents dgvDetalleItems As System.Windows.Forms.DataGridView
    Friend WithEvents cbooo As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents cboTipoDocument As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Private WithEvents dockingManager1 As Syncfusion.Windows.Forms.Tools.DockingManager
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents QGlobalColorSchemeManager1 As Qios.DevSuite.Components.QGlobalColorSchemeManager
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents btGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents PanelError As System.Windows.Forms.Panel
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents txtFechaTrans As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents cboTipo As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents cboDepositoHijo As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents lblImporteMN As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtProveedor As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents tb19 As Helios.Cont.Presentation.WinForm.ToggleButton2
    Friend WithEvents gpVSBehavior As System.Windows.Forms.GroupBox
    Friend WithEvents GradientPanel1 As System.Windows.Forms.GroupBox
    Friend WithEvents GradientPanel6 As System.Windows.Forms.GroupBox
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents btOperacion As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents cboMoneda As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents pnImpMNDisp As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents nudDeudaPendientemn As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents pnImpMEDisp As System.Windows.Forms.Panel
    Friend WithEvents nudDeudaPendienteme As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNumeroCompr As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtSerieCompr As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtComprobante As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cboTipoDoc As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents pnEntidad As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents cboEntidades As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtCuentaCorriente As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents pnFecha As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFechaEmision As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtFechaCobro As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtNumOper As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents pnNacional As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtImporteCompramn As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents pnExtranjero As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtImporteComprame As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents txtTipoCambio As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ButtonAdv4 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents ButtonAdv5 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents lblTipoCambio As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtFechaComprobante As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents pnTipoCambio As System.Windows.Forms.Panel
    Friend WithEvents pnDiferencia As System.Windows.Forms.Panel
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtDiferenciaMontos As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Private WithEvents PopupControlContainer3 As Syncfusion.Windows.Forms.PopupControlContainer
    Friend WithEvents pn As System.Windows.Forms.Panel
    Friend WithEvents dgvDiferencia As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Private WithEvents ButtonAdv6 As Syncfusion.Windows.Forms.ButtonAdv
    Private WithEvents ButtonAdv9 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents txtCuentaOrigen As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents pnSaldoME As System.Windows.Forms.Panel
    Friend WithEvents pnColorME As System.Windows.Forms.Panel
    Friend WithEvents lblDeudaPendienteme As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents pnSaldoMN As System.Windows.Forms.Panel
    Friend WithEvents pnColorMN As System.Windows.Forms.Panel
    Friend WithEvents lblDeudaPendiente As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Private WithEvents PopupControlContainer1 As Syncfusion.Windows.Forms.PopupControlContainer
    Friend WithEvents lsvTipoCambio As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Private WithEvents ButtonAdv2 As Syncfusion.Windows.Forms.ButtonAdv
    Private WithEvents ButtonAdv3 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents colId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNameItem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPrecUnit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPagoMN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPagoME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSaldoMN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSaldoME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEstado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sec As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pnContenedorCobro As System.Windows.Forms.Panel
    Friend WithEvents pnTipoCambioVenta As System.Windows.Forms.Panel
    Friend WithEvents btnSaldoCobro As System.Windows.Forms.Button
    Friend WithEvents lblMonedaCobro As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtTipoEntidad As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtNroDocEntidad As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtEntidad As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label16 As Label
    Friend WithEvents txtPeriodo As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents Label18 As System.Windows.Forms.Label
End Class

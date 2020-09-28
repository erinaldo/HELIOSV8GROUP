<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDevolucionAproveedor
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDevolucionAproveedor))
		Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
		Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
		Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
		Dim GridSummaryRowDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor()
		Dim GridSummaryColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor()
		Dim GridSummaryColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor()
		Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
		Dim GridColumnDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
		Dim GridColumnDescriptor6 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
		Dim GridColumnDescriptor7 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
		Dim GridColumnDescriptor8 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
		Dim GridColumnDescriptor9 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
		Dim GridColumnDescriptor10 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
		Dim GridColumnDescriptor11 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
		Dim GridColumnDescriptor12 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
		Dim GridSummaryRowDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor()
		Dim GridSummaryColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor()
		Dim GridSummaryColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor()
		Me.PanelError = New System.Windows.Forms.Panel()
		Me.PictureBox3 = New System.Windows.Forms.PictureBox()
		Me.lblEstado = New System.Windows.Forms.Label()
		Me.PanelDetallePagos = New System.Windows.Forms.Panel()
        Me.pcEntidad = New Syncfusion.Windows.Forms.PopupControlContainer()
        Me.TextBoxExt1 = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
		Me.Label16 = New System.Windows.Forms.Label()
		Me.txtNomEntidadFinaciera = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
		Me.Label15 = New System.Windows.Forms.Label()
		Me.ButtonAdv7 = New Syncfusion.Windows.Forms.ButtonAdv()
		Me.ButtonAdv8 = New Syncfusion.Windows.Forms.ButtonAdv()
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
		Me.colSec = New System.Windows.Forms.DataGridViewTextBoxColumn()
		Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
		Me.BannerTextProvider1 = New Syncfusion.Windows.Forms.BannerTextProvider(Me.components)
		Me.Panel4 = New System.Windows.Forms.Panel()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.cboTipoDocumento = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
		Me.nudDeudaPendienteme = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
		Me.pnDiferencia = New System.Windows.Forms.Panel()
		Me.Label28 = New System.Windows.Forms.Label()
		Me.txtDiferenciaMontos = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
		Me.pnEntidad = New System.Windows.Forms.Panel()
		Me.Label30 = New System.Windows.Forms.Label()
		Me.PictureBox2 = New System.Windows.Forms.PictureBox()
		Me.cboEntidad = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
		Me.Label31 = New System.Windows.Forms.Label()
		Me.txtCtaCorriente = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
		Me.pnTipoCambio = New System.Windows.Forms.Panel()
		Me.PictureBox5 = New System.Windows.Forms.PictureBox()
		Me.txtTipoCambio = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
		Me.Label29 = New System.Windows.Forms.Label()
		Me.Label14 = New System.Windows.Forms.Label()
		Me.pnExtranjero = New System.Windows.Forms.Panel()
		Me.lblMontoE = New System.Windows.Forms.Label()
		Me.txtImporteComprame = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
		Me.nudDeudaPendientemn = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
		Me.pnNacional = New System.Windows.Forms.Panel()
		Me.lblMontoN = New System.Windows.Forms.Label()
		Me.txtImporteCompramn = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
		Me.txtNumeroOper = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Label34 = New System.Windows.Forms.Label()
		Me.GroupBox5 = New System.Windows.Forms.GroupBox()
		Me.pnImpMNDisp = New System.Windows.Forms.Panel()
		Me.Label18 = New System.Windows.Forms.Label()
		Me.pnImpMEDisp = New System.Windows.Forms.Panel()
		Me.Label19 = New System.Windows.Forms.Label()
		Me.Label35 = New System.Windows.Forms.Label()
		Me.GroupBox3 = New System.Windows.Forms.GroupBox()
		Me.pnFecha = New System.Windows.Forms.Panel()
		Me.Label32 = New System.Windows.Forms.Label()
		Me.txtFechaEmision = New System.Windows.Forms.DateTimePicker()
		Me.Label33 = New System.Windows.Forms.Label()
		Me.txtFechaCobro = New System.Windows.Forms.DateTimePicker()
		Me.Label7 = New System.Windows.Forms.Label()
		Me.cboMoneda = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
		Me.cboTipo = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
		Me.cboDepositoHijo = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
		Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
		Me.txtCuentaOrigen = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
		Me.txtSaldoPorPagar = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
		Me.lblMonedaCobro = New System.Windows.Forms.Label()
		Me.Label12 = New System.Windows.Forms.Label()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.txtFechaTrans = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
		Me.GroupBox4 = New System.Windows.Forms.GroupBox()
		Me.pnSaldoME = New System.Windows.Forms.Panel()
		Me.pnColorME = New System.Windows.Forms.Panel()
		Me.lblDeudaPendienteme = New System.Windows.Forms.Label()
		Me.Label38 = New System.Windows.Forms.Label()
		Me.pnSaldoMN = New System.Windows.Forms.Panel()
		Me.pnColorMN = New System.Windows.Forms.Panel()
		Me.lblDeudaPendiente = New System.Windows.Forms.Label()
		Me.Label40 = New System.Windows.Forms.Label()
		Me.Label41 = New System.Windows.Forms.Label()
		Me.tb19 = New Helios.Cont.Presentation.WinForm.ToggleButton2()
		Me.lblTipoCambio = New System.Windows.Forms.Label()
		Me.Label42 = New System.Windows.Forms.Label()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.txtFechaComprobante = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
		Me.Label23 = New System.Windows.Forms.Label()
		Me.txtNumeroCompr = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
		Me.Label26 = New System.Windows.Forms.Label()
		Me.txtSerieCompr = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
		Me.Label25 = New System.Windows.Forms.Label()
		Me.txtComprobante = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
		Me.txtProveedor = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
		Me.Label27 = New System.Windows.Forms.Label()
		Me.Label36 = New System.Windows.Forms.Label()
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.PopupControlContainer2 = New Syncfusion.Windows.Forms.PopupControlContainer()
		Me.pnListaTipoCambio = New System.Windows.Forms.Panel()
		Me.dgvTipoCambio = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
		Me.ButtonAdv2 = New Syncfusion.Windows.Forms.ButtonAdv()
		Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
		Me.PopupControlContainer3 = New Syncfusion.Windows.Forms.PopupControlContainer()
		Me.pn = New System.Windows.Forms.Panel()
		Me.dgvDiferencia = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
		Me.ButtonAdv6 = New Syncfusion.Windows.Forms.ButtonAdv()
		Me.ButtonAdv9 = New Syncfusion.Windows.Forms.ButtonAdv()
		Me.cbotipoOperacion = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
		Me.GradientPanel3 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
		Me.ButtonAdv3 = New Syncfusion.Windows.Forms.ButtonAdv()
		Me.btOperacion = New Syncfusion.Windows.Forms.ButtonAdv()
		Me.PanelError.SuspendLayout()
		CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.PanelDetallePagos.SuspendLayout()
		Me.pcEntidad.SuspendLayout()
		CType(Me.TextBoxExt1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.txtNomEntidadFinaciera, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.dgvDetalleItems, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Panel4.SuspendLayout()
		CType(Me.cboTipoDocumento, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.nudDeudaPendienteme, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.pnDiferencia.SuspendLayout()
		CType(Me.txtDiferenciaMontos, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.pnEntidad.SuspendLayout()
		CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.cboEntidad, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.txtCtaCorriente, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.pnTipoCambio.SuspendLayout()
		CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.txtTipoCambio, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.pnExtranjero.SuspendLayout()
		CType(Me.txtImporteComprame, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.nudDeudaPendientemn, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.pnNacional.SuspendLayout()
		CType(Me.txtImporteCompramn, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.txtNumeroOper, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.GroupBox5.SuspendLayout()
		Me.pnImpMNDisp.SuspendLayout()
		Me.pnImpMEDisp.SuspendLayout()
		Me.GroupBox3.SuspendLayout()
		Me.pnFecha.SuspendLayout()
		CType(Me.cboMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.cboTipo, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.cboDepositoHijo, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.txtSaldoPorPagar, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.txtFechaTrans, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.txtFechaTrans.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.GroupBox4.SuspendLayout()
		Me.pnSaldoME.SuspendLayout()
		Me.pnColorME.SuspendLayout()
		Me.pnSaldoMN.SuspendLayout()
		Me.pnColorMN.SuspendLayout()
		Me.GroupBox1.SuspendLayout()
		CType(Me.txtFechaComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.txtNumeroCompr, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.txtSerieCompr, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.txtComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.txtProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.GroupBox2.SuspendLayout()
		Me.PopupControlContainer2.SuspendLayout()
		Me.pnListaTipoCambio.SuspendLayout()
		CType(Me.dgvTipoCambio, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.PopupControlContainer3.SuspendLayout()
		Me.pn.SuspendLayout()
		CType(Me.dgvDiferencia, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.cbotipoOperacion, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.GradientPanel3.SuspendLayout()
		Me.SuspendLayout()
		'
		'PanelError
		'
		Me.PanelError.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(226, Byte), Integer))
		Me.PanelError.Controls.Add(Me.PictureBox3)
		Me.PanelError.Controls.Add(Me.lblEstado)
		Me.PanelError.Dock = System.Windows.Forms.DockStyle.Top
		Me.PanelError.Location = New System.Drawing.Point(0, 0)
		Me.PanelError.Name = "PanelError"
		Me.PanelError.Size = New System.Drawing.Size(852, 22)
		Me.PanelError.TabIndex = 432
		Me.PanelError.Visible = False
		'
		'PictureBox3
		'
		Me.PictureBox3.Cursor = System.Windows.Forms.Cursors.Hand
		Me.PictureBox3.Dock = System.Windows.Forms.DockStyle.Right
		Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
		Me.PictureBox3.Location = New System.Drawing.Point(833, 0)
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
		Me.lblEstado.ForeColor = System.Drawing.Color.White
		Me.lblEstado.Location = New System.Drawing.Point(9, 4)
		Me.lblEstado.Name = "lblEstado"
		Me.lblEstado.Size = New System.Drawing.Size(79, 13)
		Me.lblEstado.TabIndex = 0
		Me.lblEstado.Text = "Mensaje error"
		'
		'PanelDetallePagos
		'
		Me.PanelDetallePagos.Controls.Add(Me.pcEntidad)
		Me.PanelDetallePagos.Controls.Add(Me.dgvDetalleItems)
		Me.PanelDetallePagos.Location = New System.Drawing.Point(12, 354)
		Me.PanelDetallePagos.Name = "PanelDetallePagos"
		Me.PanelDetallePagos.Size = New System.Drawing.Size(826, 164)
		Me.PanelDetallePagos.TabIndex = 429
		'
		'pcEntidad
		'
		Me.pcEntidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.pcEntidad.Controls.Add(Me.TextBoxExt1)
		Me.pcEntidad.Controls.Add(Me.Label16)
		Me.pcEntidad.Controls.Add(Me.txtNomEntidadFinaciera)
		Me.pcEntidad.Controls.Add(Me.Label15)
		Me.pcEntidad.Controls.Add(Me.ButtonAdv7)
		Me.pcEntidad.Controls.Add(Me.ButtonAdv8)
		Me.pcEntidad.Location = New System.Drawing.Point(64, 26)
		Me.pcEntidad.Name = "pcEntidad"
		Me.pcEntidad.Size = New System.Drawing.Size(212, 139)
		Me.pcEntidad.TabIndex = 433
		Me.pcEntidad.Visible = False
		'
		'TextBoxExt1
		'
		Me.TextBoxExt1.BackColor = System.Drawing.Color.White
		Me.TextBoxExt1.BeforeTouchSize = New System.Drawing.Size(326, 20)
		Me.TextBoxExt1.BorderColor = System.Drawing.SystemColors.Highlight
		Me.TextBoxExt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.TextBoxExt1.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.TextBoxExt1.Location = New System.Drawing.Point(4, 74)
		Me.TextBoxExt1.MaxLength = 5
		Me.TextBoxExt1.Metrocolor = System.Drawing.SystemColors.Highlight
		Me.TextBoxExt1.Name = "TextBoxExt1"
		Me.TextBoxExt1.Size = New System.Drawing.Size(60, 22)
		Me.TextBoxExt1.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
		Me.TextBoxExt1.TabIndex = 214
		'
		'Label16
		'
		Me.Label16.AutoSize = True
		Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label16.Location = New System.Drawing.Point(3, 58)
		Me.Label16.Name = "Label16"
		Me.Label16.Size = New System.Drawing.Size(48, 13)
		Me.Label16.TabIndex = 213
		Me.Label16.Text = "Codigo:"
		'
		'txtNomEntidadFinaciera
		'
		Me.txtNomEntidadFinaciera.BackColor = System.Drawing.Color.White
		Me.txtNomEntidadFinaciera.BeforeTouchSize = New System.Drawing.Size(326, 20)
		Me.txtNomEntidadFinaciera.BorderColor = System.Drawing.SystemColors.Highlight
		Me.txtNomEntidadFinaciera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtNomEntidadFinaciera.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtNomEntidadFinaciera.Location = New System.Drawing.Point(4, 30)
		Me.txtNomEntidadFinaciera.MaxLength = 20
		Me.txtNomEntidadFinaciera.Metrocolor = System.Drawing.SystemColors.Highlight
		Me.txtNomEntidadFinaciera.Name = "txtNomEntidadFinaciera"
		Me.txtNomEntidadFinaciera.Size = New System.Drawing.Size(203, 22)
		Me.txtNomEntidadFinaciera.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
		Me.txtNomEntidadFinaciera.TabIndex = 212
		'
		'Label15
		'
		Me.Label15.AutoSize = True
		Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label15.Location = New System.Drawing.Point(3, 12)
		Me.Label15.Name = "Label15"
		Me.Label15.Size = New System.Drawing.Size(94, 13)
		Me.Label15.TabIndex = 210
		Me.Label15.Text = "Nombre entidad:"
		'
		'ButtonAdv7
		'
		Me.ButtonAdv7.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
		Me.ButtonAdv7.BackColor = System.Drawing.SystemColors.Highlight
		Me.ButtonAdv7.BeforeTouchSize = New System.Drawing.Size(60, 19)
		Me.ButtonAdv7.ForeColor = System.Drawing.Color.White
		Me.ButtonAdv7.IsBackStageButton = False
		Me.ButtonAdv7.Location = New System.Drawing.Point(64, 110)
		Me.ButtonAdv7.Name = "ButtonAdv7"
		Me.ButtonAdv7.Size = New System.Drawing.Size(60, 19)
		Me.ButtonAdv7.TabIndex = 209
		Me.ButtonAdv7.Text = "Cancelar"
		Me.ButtonAdv7.UseVisualStyle = True
		'
		'ButtonAdv8
		'
		Me.ButtonAdv8.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
		Me.ButtonAdv8.BackColor = System.Drawing.SystemColors.Highlight
		Me.ButtonAdv8.BeforeTouchSize = New System.Drawing.Size(60, 19)
		Me.ButtonAdv8.ForeColor = System.Drawing.Color.White
		Me.ButtonAdv8.IsBackStageButton = False
		Me.ButtonAdv8.Location = New System.Drawing.Point(4, 110)
		Me.ButtonAdv8.Name = "ButtonAdv8"
		Me.ButtonAdv8.Size = New System.Drawing.Size(60, 19)
		Me.ButtonAdv8.TabIndex = 208
		Me.ButtonAdv8.Text = "OK"
		Me.ButtonAdv8.UseVisualStyle = True
		'
		'dgvDetalleItems
		'
		Me.dgvDetalleItems.AllowUserToAddRows = False
		Me.dgvDetalleItems.BackgroundColor = System.Drawing.Color.DarkGray
		Me.dgvDetalleItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dgvDetalleItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colId, Me.colNameItem, Me.colum, Me.ColPrecUnit, Me.colMN, Me.colME, Me.colPagoMN, Me.colPagoME, Me.colSaldoMN, Me.colSaldoME, Me.colEstado, Me.colSec})
		Me.dgvDetalleItems.Dock = System.Windows.Forms.DockStyle.Fill
		Me.dgvDetalleItems.EnableHeadersVisualStyles = False
		Me.dgvDetalleItems.Location = New System.Drawing.Point(0, 0)
		Me.dgvDetalleItems.MultiSelect = False
		Me.dgvDetalleItems.Name = "dgvDetalleItems"
		Me.dgvDetalleItems.RowHeadersVisible = False
		Me.dgvDetalleItems.Size = New System.Drawing.Size(826, 164)
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
		Me.colEstado.Width = 50
		'
		'colSec
		'
		Me.colSec.HeaderText = "SecVenta"
		Me.colSec.Name = "colSec"
		Me.colSec.ReadOnly = True
		Me.colSec.Width = 50
		'
		'Timer1
		'
		'
		'Panel4
		'
		Me.Panel4.Controls.Add(Me.Label2)
		Me.Panel4.Controls.Add(Me.cboTipoDocumento)
		Me.Panel4.Controls.Add(Me.nudDeudaPendienteme)
		Me.Panel4.Controls.Add(Me.pnDiferencia)
		Me.Panel4.Controls.Add(Me.pnEntidad)
		Me.Panel4.Controls.Add(Me.pnTipoCambio)
		Me.Panel4.Controls.Add(Me.Label14)
		Me.Panel4.Controls.Add(Me.pnExtranjero)
		Me.Panel4.Controls.Add(Me.nudDeudaPendientemn)
		Me.Panel4.Controls.Add(Me.pnNacional)
		Me.Panel4.Controls.Add(Me.txtNumeroOper)
		Me.Panel4.Controls.Add(Me.Label1)
		Me.Panel4.Controls.Add(Me.Label34)
		Me.Panel4.Controls.Add(Me.GroupBox5)
		Me.Panel4.Controls.Add(Me.Label35)
		Me.Panel4.Controls.Add(Me.GroupBox3)
		Me.Panel4.Controls.Add(Me.Label7)
		Me.Panel4.Controls.Add(Me.cboMoneda)
		Me.Panel4.Controls.Add(Me.cboTipo)
		Me.Panel4.Controls.Add(Me.cboDepositoHijo)
		Me.Panel4.Controls.Add(Me.LinkLabel1)
		Me.Panel4.Controls.Add(Me.txtCuentaOrigen)
		Me.Panel4.Controls.Add(Me.txtSaldoPorPagar)
		Me.Panel4.Controls.Add(Me.lblMonedaCobro)
		Me.Panel4.Controls.Add(Me.Label12)
		Me.Panel4.Controls.Add(Me.Label5)
		Me.Panel4.Controls.Add(Me.txtFechaTrans)
		Me.Panel4.Controls.Add(Me.GroupBox4)
		Me.Panel4.Controls.Add(Me.GroupBox1)
		Me.Panel4.Controls.Add(Me.GroupBox2)
		Me.Panel4.Controls.Add(Me.PanelDetallePagos)
		Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
		Me.Panel4.Location = New System.Drawing.Point(0, 22)
		Me.Panel4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
		Me.Panel4.Name = "Panel4"
		Me.Panel4.Size = New System.Drawing.Size(852, 533)
		Me.Panel4.TabIndex = 434
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Font = New System.Drawing.Font("Corbel", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.Location = New System.Drawing.Point(20, 294)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(121, 15)
		Me.Label2.TabIndex = 539
		Me.Label2.Text = "Desembolsar montos"
		'
		'cboTipoDocumento
		'
		Me.cboTipoDocumento.BackColor = System.Drawing.Color.White
		Me.cboTipoDocumento.BeforeTouchSize = New System.Drawing.Size(219, 21)
		Me.cboTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboTipoDocumento.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cboTipoDocumento.Location = New System.Drawing.Point(151, 231)
		Me.cboTipoDocumento.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(226, Byte), Integer))
		Me.cboTipoDocumento.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(226, Byte), Integer))
		Me.cboTipoDocumento.Name = "cboTipoDocumento"
		Me.cboTipoDocumento.Size = New System.Drawing.Size(219, 21)
		Me.cboTipoDocumento.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
		Me.cboTipoDocumento.TabIndex = 471
		'
		'nudDeudaPendienteme
		'
		Me.nudDeudaPendienteme.BackColor = System.Drawing.Color.PaleGreen
		Me.nudDeudaPendienteme.BeforeTouchSize = New System.Drawing.Size(81, 22)
		Me.nudDeudaPendienteme.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
		Me.nudDeudaPendienteme.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.nudDeudaPendienteme.DecimalPlaces = 2
		Me.nudDeudaPendienteme.Enabled = False
		Me.nudDeudaPendienteme.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.nudDeudaPendienteme.Location = New System.Drawing.Point(647, 84)
		Me.nudDeudaPendienteme.Maximum = New Decimal(New Integer() {-159383552, 46653770, 5421, 0})
		Me.nudDeudaPendienteme.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
		Me.nudDeudaPendienteme.Name = "nudDeudaPendienteme"
		Me.nudDeudaPendienteme.Size = New System.Drawing.Size(81, 22)
		Me.nudDeudaPendienteme.TabIndex = 431
		Me.nudDeudaPendienteme.ThousandsSeparator = True
		Me.nudDeudaPendienteme.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
		'
		'pnDiferencia
		'
		Me.pnDiferencia.Controls.Add(Me.Label28)
		Me.pnDiferencia.Controls.Add(Me.txtDiferenciaMontos)
		Me.pnDiferencia.Location = New System.Drawing.Point(595, 315)
		Me.pnDiferencia.Name = "pnDiferencia"
		Me.pnDiferencia.Size = New System.Drawing.Size(187, 28)
		Me.pnDiferencia.TabIndex = 498
		'
		'Label28
		'
		Me.Label28.AutoSize = True
		Me.Label28.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
		Me.Label28.ForeColor = System.Drawing.Color.Black
		Me.Label28.Location = New System.Drawing.Point(12, 9)
		Me.Label28.Name = "Label28"
		Me.Label28.Size = New System.Drawing.Size(66, 12)
		Me.Label28.TabIndex = 204
		Me.Label28.Text = "DIFERENCIA"
		'
		'txtDiferenciaMontos
		'
		Me.txtDiferenciaMontos.BackColor = System.Drawing.Color.PaleGreen
		Me.txtDiferenciaMontos.BeforeTouchSize = New System.Drawing.Size(100, 21)
		Me.txtDiferenciaMontos.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
		Me.txtDiferenciaMontos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtDiferenciaMontos.DecimalPlaces = 2
		Me.txtDiferenciaMontos.Font = New System.Drawing.Font("Arial", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtDiferenciaMontos.ForeColor = System.Drawing.Color.Black
		Me.txtDiferenciaMontos.Location = New System.Drawing.Point(80, 3)
		Me.txtDiferenciaMontos.Maximum = New Decimal(New Integer() {-1304428544, 434162106, 542, 0})
		Me.txtDiferenciaMontos.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
		Me.txtDiferenciaMontos.Minimum = New Decimal(New Integer() {-1304428544, 434162106, 542, -2147483648})
		Me.txtDiferenciaMontos.Name = "txtDiferenciaMontos"
		Me.txtDiferenciaMontos.Size = New System.Drawing.Size(100, 21)
		Me.txtDiferenciaMontos.TabIndex = 398
		Me.txtDiferenciaMontos.TabStop = False
		Me.txtDiferenciaMontos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtDiferenciaMontos.ThousandsSeparator = True
		Me.txtDiferenciaMontos.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
		'
		'pnEntidad
		'
		Me.pnEntidad.BackColor = System.Drawing.Color.Transparent
		Me.pnEntidad.Controls.Add(Me.Label30)
		Me.pnEntidad.Controls.Add(Me.PictureBox2)
		Me.pnEntidad.Controls.Add(Me.cboEntidad)
		Me.pnEntidad.Controls.Add(Me.Label31)
		Me.pnEntidad.Controls.Add(Me.txtCtaCorriente)
		Me.pnEntidad.Location = New System.Drawing.Point(20, 255)
		Me.pnEntidad.Name = "pnEntidad"
		Me.pnEntidad.Size = New System.Drawing.Size(771, 33)
		Me.pnEntidad.TabIndex = 469
		'
		'Label30
		'
		Me.Label30.AutoSize = True
		Me.Label30.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
		Me.Label30.ForeColor = System.Drawing.Color.Black
		Me.Label30.Location = New System.Drawing.Point(7, 9)
		Me.Label30.Name = "Label30"
		Me.Label30.Size = New System.Drawing.Size(115, 12)
		Me.Label30.TabIndex = 430
		Me.Label30.Text = "ENTIDAD FINANCIERA:"
		'
		'PictureBox2
		'
		Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
		Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
		Me.PictureBox2.Location = New System.Drawing.Point(356, 4)
		Me.PictureBox2.Name = "PictureBox2"
		Me.PictureBox2.Size = New System.Drawing.Size(21, 21)
		Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.PictureBox2.TabIndex = 439
		Me.PictureBox2.TabStop = False
		'
		'cboEntidad
		'
		Me.cboEntidad.BackColor = System.Drawing.Color.White
		Me.cboEntidad.BeforeTouchSize = New System.Drawing.Size(219, 21)
		Me.cboEntidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboEntidad.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cboEntidad.Location = New System.Drawing.Point(131, 4)
		Me.cboEntidad.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(226, Byte), Integer))
		Me.cboEntidad.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(226, Byte), Integer))
		Me.cboEntidad.Name = "cboEntidad"
		Me.cboEntidad.Size = New System.Drawing.Size(219, 21)
		Me.cboEntidad.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
		Me.cboEntidad.TabIndex = 436
		'
		'Label31
		'
		Me.Label31.AutoSize = True
		Me.Label31.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
		Me.Label31.ForeColor = System.Drawing.Color.Black
		Me.Label31.Location = New System.Drawing.Point(472, 9)
		Me.Label31.Name = "Label31"
		Me.Label31.Size = New System.Drawing.Size(90, 12)
		Me.Label31.TabIndex = 438
		Me.Label31.Text = "CTA. CORRIENTE:"
		'
		'txtCtaCorriente
		'
		Me.txtCtaCorriente.BackColor = System.Drawing.Color.White
		Me.txtCtaCorriente.BeforeTouchSize = New System.Drawing.Size(326, 20)
		Me.txtCtaCorriente.BorderColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(226, Byte), Integer))
		Me.txtCtaCorriente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtCtaCorriente.CornerRadius = 5
		Me.txtCtaCorriente.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtCtaCorriente.Location = New System.Drawing.Point(568, 4)
		Me.txtCtaCorriente.MaxLength = 20
		Me.txtCtaCorriente.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(226, Byte), Integer))
		Me.txtCtaCorriente.MinimumSize = New System.Drawing.Size(14, 10)
		Me.txtCtaCorriente.Name = "txtCtaCorriente"
		Me.txtCtaCorriente.Size = New System.Drawing.Size(195, 22)
		Me.txtCtaCorriente.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
		Me.txtCtaCorriente.TabIndex = 437
		'
		'pnTipoCambio
		'
		Me.pnTipoCambio.Controls.Add(Me.PictureBox5)
		Me.pnTipoCambio.Controls.Add(Me.txtTipoCambio)
		Me.pnTipoCambio.Controls.Add(Me.Label29)
		Me.pnTipoCambio.Location = New System.Drawing.Point(225, 315)
		Me.pnTipoCambio.Name = "pnTipoCambio"
		Me.pnTipoCambio.Size = New System.Drawing.Size(135, 29)
		Me.pnTipoCambio.TabIndex = 403
		Me.pnTipoCambio.Visible = False
		'
		'PictureBox5
		'
		Me.PictureBox5.Cursor = System.Windows.Forms.Cursors.Hand
		Me.PictureBox5.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.indent_icon
		Me.PictureBox5.Location = New System.Drawing.Point(108, 6)
		Me.PictureBox5.Name = "PictureBox5"
		Me.PictureBox5.Size = New System.Drawing.Size(21, 20)
		Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.PictureBox5.TabIndex = 443
		Me.PictureBox5.TabStop = False
		'
		'txtTipoCambio
		'
		Me.txtTipoCambio.BackColor = System.Drawing.SystemColors.Info
		Me.txtTipoCambio.BeforeTouchSize = New System.Drawing.Size(70, 21)
		Me.txtTipoCambio.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
		Me.txtTipoCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtTipoCambio.DecimalPlaces = 3
		Me.txtTipoCambio.Font = New System.Drawing.Font("Arial", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtTipoCambio.Location = New System.Drawing.Point(32, 5)
		Me.txtTipoCambio.Maximum = New Decimal(New Integer() {-159383552, 46653770, 5421, 0})
		Me.txtTipoCambio.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
		Me.txtTipoCambio.Name = "txtTipoCambio"
		Me.txtTipoCambio.Size = New System.Drawing.Size(70, 21)
		Me.txtTipoCambio.TabIndex = 400
		Me.txtTipoCambio.TabStop = False
		Me.txtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtTipoCambio.ThousandsSeparator = True
		Me.txtTipoCambio.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
		'
		'Label29
		'
		Me.Label29.AutoSize = True
		Me.Label29.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
		Me.Label29.ForeColor = System.Drawing.Color.Black
		Me.Label29.Location = New System.Drawing.Point(1, 9)
		Me.Label29.Name = "Label29"
		Me.Label29.Size = New System.Drawing.Size(25, 14)
		Me.Label29.TabIndex = 399
		Me.Label29.Text = "T/C"
		'
		'Label14
		'
		Me.Label14.AutoSize = True
		Me.Label14.Location = New System.Drawing.Point(427, 64)
		Me.Label14.Name = "Label14"
		Me.Label14.Size = New System.Drawing.Size(50, 13)
		Me.Label14.TabIndex = 538
		Me.Label14.Text = "Moneda"
		'
		'pnExtranjero
		'
		Me.pnExtranjero.Controls.Add(Me.lblMontoE)
		Me.pnExtranjero.Controls.Add(Me.txtImporteComprame)
		Me.pnExtranjero.Location = New System.Drawing.Point(366, 315)
		Me.pnExtranjero.Name = "pnExtranjero"
		Me.pnExtranjero.Size = New System.Drawing.Size(216, 28)
		Me.pnExtranjero.TabIndex = 402
		'
		'lblMontoE
		'
		Me.lblMontoE.AutoSize = True
		Me.lblMontoE.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
		Me.lblMontoE.ForeColor = System.Drawing.Color.Black
		Me.lblMontoE.Location = New System.Drawing.Point(3, 9)
		Me.lblMontoE.Name = "lblMontoE"
		Me.lblMontoE.Size = New System.Drawing.Size(70, 12)
		Me.lblMontoE.TabIndex = 204
		Me.lblMontoE.Text = "IMPORTE ME"
		'
		'txtImporteComprame
		'
		Me.txtImporteComprame.BackColor = System.Drawing.Color.PaleGreen
		Me.txtImporteComprame.BeforeTouchSize = New System.Drawing.Size(121, 21)
		Me.txtImporteComprame.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
		Me.txtImporteComprame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtImporteComprame.DecimalPlaces = 2
		Me.txtImporteComprame.Font = New System.Drawing.Font("Arial", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtImporteComprame.ForeColor = System.Drawing.Color.Black
		Me.txtImporteComprame.Location = New System.Drawing.Point(80, 3)
		Me.txtImporteComprame.Maximum = New Decimal(New Integer() {-1304428544, 434162106, 542, 0})
		Me.txtImporteComprame.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
		Me.txtImporteComprame.Name = "txtImporteComprame"
		Me.txtImporteComprame.Size = New System.Drawing.Size(121, 21)
		Me.txtImporteComprame.TabIndex = 398
		Me.txtImporteComprame.TabStop = False
		Me.txtImporteComprame.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
		Me.txtImporteComprame.ThousandsSeparator = True
		Me.txtImporteComprame.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
		'
		'nudDeudaPendientemn
		'
		Me.nudDeudaPendientemn.BackColor = System.Drawing.Color.White
		Me.nudDeudaPendientemn.BeforeTouchSize = New System.Drawing.Size(82, 22)
		Me.nudDeudaPendientemn.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
		Me.nudDeudaPendientemn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.nudDeudaPendientemn.DecimalPlaces = 2
		Me.nudDeudaPendientemn.Enabled = False
		Me.nudDeudaPendientemn.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.nudDeudaPendientemn.Location = New System.Drawing.Point(552, 84)
		Me.nudDeudaPendientemn.Maximum = New Decimal(New Integer() {-159383552, 46653770, 5421, 0})
		Me.nudDeudaPendientemn.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
		Me.nudDeudaPendientemn.Name = "nudDeudaPendientemn"
		Me.nudDeudaPendientemn.Size = New System.Drawing.Size(82, 22)
		Me.nudDeudaPendientemn.TabIndex = 432
		Me.nudDeudaPendientemn.ThousandsSeparator = True
		Me.nudDeudaPendientemn.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
		'
		'pnNacional
		'
		Me.pnNacional.Controls.Add(Me.lblMontoN)
		Me.pnNacional.Controls.Add(Me.txtImporteCompramn)
		Me.pnNacional.Location = New System.Drawing.Point(20, 315)
		Me.pnNacional.Name = "pnNacional"
		Me.pnNacional.Size = New System.Drawing.Size(201, 29)
		Me.pnNacional.TabIndex = 401
		'
		'lblMontoN
		'
		Me.lblMontoN.AutoSize = True
		Me.lblMontoN.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
		Me.lblMontoN.ForeColor = System.Drawing.Color.Black
		Me.lblMontoN.Location = New System.Drawing.Point(7, 9)
		Me.lblMontoN.Name = "lblMontoN"
		Me.lblMontoN.Size = New System.Drawing.Size(73, 12)
		Me.lblMontoN.TabIndex = 203
		Me.lblMontoN.Text = "IMPORTE MN:"
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
		Me.txtImporteCompramn.Location = New System.Drawing.Point(88, 5)
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
		'txtNumeroOper
		'
		Me.txtNumeroOper.BackColor = System.Drawing.Color.White
		Me.txtNumeroOper.BeforeTouchSize = New System.Drawing.Size(326, 20)
		Me.txtNumeroOper.BorderColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(226, Byte), Integer))
		Me.txtNumeroOper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtNumeroOper.CornerRadius = 5
		Me.txtNumeroOper.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtNumeroOper.Location = New System.Drawing.Point(588, 232)
		Me.txtNumeroOper.MaxLength = 20
		Me.txtNumeroOper.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(226, Byte), Integer))
		Me.txtNumeroOper.MinimumSize = New System.Drawing.Size(14, 10)
		Me.txtNumeroOper.Name = "txtNumeroOper"
		Me.txtNumeroOper.Size = New System.Drawing.Size(195, 22)
		Me.txtNumeroOper.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
		Me.txtNumeroOper.TabIndex = 211
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Font = New System.Drawing.Font("Corbel", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.ForeColor = System.Drawing.Color.Black
		Me.Label1.Location = New System.Drawing.Point(549, 63)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(151, 15)
		Me.Label1.TabIndex = 537
		Me.Label1.Text = "Saldo disponible en cuenta"
		'
		'Label34
		'
		Me.Label34.AutoSize = True
		Me.Label34.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
		Me.Label34.ForeColor = System.Drawing.Color.Black
		Me.Label34.Location = New System.Drawing.Point(485, 240)
		Me.Label34.Name = "Label34"
		Me.Label34.Size = New System.Drawing.Size(97, 12)
		Me.Label34.TabIndex = 434
		Me.Label34.Text = "NRO. OPERACIÓN:"
		'
		'GroupBox5
		'
		Me.GroupBox5.Controls.Add(Me.pnImpMNDisp)
		Me.GroupBox5.Controls.Add(Me.pnImpMEDisp)
		Me.GroupBox5.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
		Me.GroupBox5.ForeColor = System.Drawing.Color.Black
		Me.GroupBox5.Location = New System.Drawing.Point(976, 37)
		Me.GroupBox5.Name = "GroupBox5"
		Me.GroupBox5.Size = New System.Drawing.Size(219, 51)
		Me.GroupBox5.TabIndex = 516
		Me.GroupBox5.TabStop = False
		Me.GroupBox5.Text = "IMPORTE DISPONIBLE"
		'
		'pnImpMNDisp
		'
		Me.pnImpMNDisp.Controls.Add(Me.Label18)
		Me.pnImpMNDisp.Location = New System.Drawing.Point(8, 19)
		Me.pnImpMNDisp.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
		Me.pnImpMNDisp.Name = "pnImpMNDisp"
		Me.pnImpMNDisp.Size = New System.Drawing.Size(162, 25)
		Me.pnImpMNDisp.TabIndex = 434
		'
		'Label18
		'
		Me.Label18.AutoSize = True
		Me.Label18.BackColor = System.Drawing.Color.Transparent
		Me.Label18.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
		Me.Label18.ForeColor = System.Drawing.Color.Brown
		Me.Label18.Location = New System.Drawing.Point(3, 7)
		Me.Label18.Name = "Label18"
		Me.Label18.Size = New System.Drawing.Size(64, 12)
		Me.Label18.TabIndex = 433
		Me.Label18.Text = "MONTO MN:"
		'
		'pnImpMEDisp
		'
		Me.pnImpMEDisp.Controls.Add(Me.Label19)
		Me.pnImpMEDisp.Location = New System.Drawing.Point(175, 17)
		Me.pnImpMEDisp.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
		Me.pnImpMEDisp.Name = "pnImpMEDisp"
		Me.pnImpMEDisp.Size = New System.Drawing.Size(153, 27)
		Me.pnImpMEDisp.TabIndex = 435
		'
		'Label19
		'
		Me.Label19.AutoSize = True
		Me.Label19.BackColor = System.Drawing.Color.Transparent
		Me.Label19.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
		Me.Label19.ForeColor = System.Drawing.Color.Brown
		Me.Label19.Location = New System.Drawing.Point(3, 9)
		Me.Label19.Name = "Label19"
		Me.Label19.Size = New System.Drawing.Size(64, 12)
		Me.Label19.TabIndex = 54
		Me.Label19.Text = "MONTO ME:"
		'
		'Label35
		'
		Me.Label35.AutoSize = True
		Me.Label35.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label35.ForeColor = System.Drawing.Color.Black
		Me.Label35.Location = New System.Drawing.Point(77, 262)
		Me.Label35.Name = "Label35"
		Me.Label35.Size = New System.Drawing.Size(63, 12)
		Me.Label35.TabIndex = 1
		Me.Label35.Text = "TIPO PAGO:"
		'
		'GroupBox3
		'
		Me.GroupBox3.Controls.Add(Me.pnFecha)
		Me.GroupBox3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.GroupBox3.ForeColor = System.Drawing.Color.Brown
		Me.GroupBox3.Location = New System.Drawing.Point(995, 300)
		Me.GroupBox3.Name = "GroupBox3"
		Me.GroupBox3.Size = New System.Drawing.Size(286, 66)
		Me.GroupBox3.TabIndex = 514
		Me.GroupBox3.TabStop = False
		Me.GroupBox3.Text = "MEDIO PAGO"
		'
		'pnFecha
		'
		Me.pnFecha.Controls.Add(Me.Label32)
		Me.pnFecha.Controls.Add(Me.txtFechaEmision)
		Me.pnFecha.Controls.Add(Me.Label33)
		Me.pnFecha.Controls.Add(Me.txtFechaCobro)
		Me.pnFecha.Location = New System.Drawing.Point(25, 82)
		Me.pnFecha.Name = "pnFecha"
		Me.pnFecha.Size = New System.Drawing.Size(771, 30)
		Me.pnFecha.TabIndex = 470
		'
		'Label32
		'
		Me.Label32.AutoSize = True
		Me.Label32.BackColor = System.Drawing.Color.Transparent
		Me.Label32.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label32.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
		Me.Label32.Location = New System.Drawing.Point(36, 13)
		Me.Label32.Name = "Label32"
		Me.Label32.Size = New System.Drawing.Size(89, 12)
		Me.Label32.TabIndex = 442
		Me.Label32.Text = "FECHA EMISIÓN:"
		'
		'txtFechaEmision
		'
		Me.txtFechaEmision.Format = System.Windows.Forms.DateTimePickerFormat.Custom
		Me.txtFechaEmision.Location = New System.Drawing.Point(131, 6)
		Me.txtFechaEmision.Name = "txtFechaEmision"
		Me.txtFechaEmision.Size = New System.Drawing.Size(181, 20)
		Me.txtFechaEmision.TabIndex = 466
		'
		'Label33
		'
		Me.Label33.AutoSize = True
		Me.Label33.BackColor = System.Drawing.Color.Transparent
		Me.Label33.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label33.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
		Me.Label33.Location = New System.Drawing.Point(451, 13)
		Me.Label33.Name = "Label33"
		Me.Label33.Size = New System.Drawing.Size(110, 12)
		Me.Label33.TabIndex = 440
		Me.Label33.Text = "COBRO A PARTIR DE:"
		'
		'txtFechaCobro
		'
		Me.txtFechaCobro.Format = System.Windows.Forms.DateTimePickerFormat.Custom
		Me.txtFechaCobro.Location = New System.Drawing.Point(567, 6)
		Me.txtFechaCobro.Name = "txtFechaCobro"
		Me.txtFechaCobro.Size = New System.Drawing.Size(181, 20)
		Me.txtFechaCobro.TabIndex = 467
		'
		'Label7
		'
		Me.Label7.AutoSize = True
		Me.Label7.Font = New System.Drawing.Font("Corbel", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label7.Location = New System.Drawing.Point(20, 62)
		Me.Label7.Name = "Label7"
		Me.Label7.Size = New System.Drawing.Size(108, 15)
		Me.Label7.TabIndex = 536
		Me.Label7.Text = "Seleccionar cuenta"
		'
		'cboMoneda
		'
		Me.cboMoneda.BackColor = System.Drawing.Color.White
		Me.cboMoneda.BeforeTouchSize = New System.Drawing.Size(110, 21)
		Me.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboMoneda.Enabled = False
		Me.cboMoneda.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cboMoneda.Location = New System.Drawing.Point(422, 86)
		Me.cboMoneda.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(226, Byte), Integer))
		Me.cboMoneda.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(226, Byte), Integer))
		Me.cboMoneda.Name = "cboMoneda"
		Me.cboMoneda.Size = New System.Drawing.Size(110, 21)
		Me.cboMoneda.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
		Me.cboMoneda.TabIndex = 222
		'
		'cboTipo
		'
		Me.cboTipo.BackColor = System.Drawing.Color.White
		Me.cboTipo.BeforeTouchSize = New System.Drawing.Size(143, 21)
		Me.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboTipo.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cboTipo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
		Me.cboTipo.Items.AddRange(New Object() {"", "CUENTAS EN EFECTIVO", "CUENTAS EN BANCO", "TARJETA DE CREDITO"})
		Me.cboTipo.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboTipo, ""))
		Me.cboTipo.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboTipo, "CUENTAS EN EFECTIVO"))
		Me.cboTipo.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboTipo, "CUENTAS EN BANCO"))
		Me.cboTipo.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboTipo, "TARJETA DE CREDITO"))
		Me.cboTipo.Location = New System.Drawing.Point(20, 86)
		Me.cboTipo.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(226, Byte), Integer))
		Me.cboTipo.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(226, Byte), Integer))
		Me.cboTipo.Name = "cboTipo"
		Me.cboTipo.Size = New System.Drawing.Size(143, 21)
		Me.cboTipo.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
		Me.cboTipo.TabIndex = 504
		'
		'cboDepositoHijo
		'
		Me.cboDepositoHijo.BackColor = System.Drawing.Color.White
		Me.cboDepositoHijo.BeforeTouchSize = New System.Drawing.Size(240, 21)
		Me.cboDepositoHijo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboDepositoHijo.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cboDepositoHijo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
		Me.cboDepositoHijo.Location = New System.Drawing.Point(176, 85)
		Me.cboDepositoHijo.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(226, Byte), Integer))
		Me.cboDepositoHijo.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(226, Byte), Integer))
		Me.cboDepositoHijo.Name = "cboDepositoHijo"
		Me.cboDepositoHijo.Size = New System.Drawing.Size(240, 21)
		Me.cboDepositoHijo.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
		Me.cboDepositoHijo.TabIndex = 500
		'
		'LinkLabel1
		'
		Me.LinkLabel1.AutoSize = True
		Me.LinkLabel1.Location = New System.Drawing.Point(292, 35)
		Me.LinkLabel1.Name = "LinkLabel1"
		Me.LinkLabel1.Size = New System.Drawing.Size(16, 13)
		Me.LinkLabel1.TabIndex = 535
		Me.LinkLabel1.TabStop = True
		Me.LinkLabel1.Text = "..."
		'
		'txtCuentaOrigen
		'
		Me.txtCuentaOrigen.Location = New System.Drawing.Point(176, 60)
		Me.txtCuentaOrigen.Name = "txtCuentaOrigen"
		Me.txtCuentaOrigen.ReadOnly = True
		Me.txtCuentaOrigen.Size = New System.Drawing.Size(46, 19)
		Me.txtCuentaOrigen.TabIndex = 7
		Me.txtCuentaOrigen.Visible = False
		'
		'txtSaldoPorPagar
		'
		Me.txtSaldoPorPagar.BackGroundColor = System.Drawing.SystemColors.Window
		Me.txtSaldoPorPagar.BeforeTouchSize = New System.Drawing.Size(326, 20)
		Me.txtSaldoPorPagar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
		Me.txtSaldoPorPagar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtSaldoPorPagar.CurrencySymbol = ""
		Me.txtSaldoPorPagar.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtSaldoPorPagar.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
		Me.txtSaldoPorPagar.Font = New System.Drawing.Font("Ebrima", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtSaldoPorPagar.ForeColor = System.Drawing.Color.White
		Me.txtSaldoPorPagar.Location = New System.Drawing.Point(186, 28)
		Me.txtSaldoPorPagar.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
		Me.txtSaldoPorPagar.Name = "txtSaldoPorPagar"
		Me.txtSaldoPorPagar.NullString = ""
		Me.txtSaldoPorPagar.PositiveColor = System.Drawing.Color.White
		Me.txtSaldoPorPagar.ReadOnly = True
		Me.txtSaldoPorPagar.ReadOnlyBackColor = System.Drawing.Color.MediumSeaGreen
		Me.txtSaldoPorPagar.Size = New System.Drawing.Size(100, 23)
		Me.txtSaldoPorPagar.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
		Me.txtSaldoPorPagar.TabIndex = 534
		Me.txtSaldoPorPagar.Text = "0.00"
		'
		'lblMonedaCobro
		'
		Me.lblMonedaCobro.AutoSize = True
		Me.lblMonedaCobro.Font = New System.Drawing.Font("Corbel", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMonedaCobro.ForeColor = System.Drawing.SystemColors.HotTrack
		Me.lblMonedaCobro.Location = New System.Drawing.Point(324, 37)
		Me.lblMonedaCobro.Name = "lblMonedaCobro"
		Me.lblMonedaCobro.Size = New System.Drawing.Size(49, 13)
		Me.lblMonedaCobro.TabIndex = 531
		Me.lblMonedaCobro.Text = "MONEDA"
		'
		'Label12
		'
		Me.Label12.AutoSize = True
		Me.Label12.Location = New System.Drawing.Point(183, 10)
		Me.Label12.Name = "Label12"
		Me.Label12.Size = New System.Drawing.Size(93, 13)
		Me.Label12.TabIndex = 533
		Me.Label12.Text = "Saldo por cobrar"
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.Location = New System.Drawing.Point(17, 10)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(115, 13)
		Me.Label5.TabIndex = 532
		Me.Label5.Text = "Fecha de Transacción"
		'
		'txtFechaTrans
		'
		Me.txtFechaTrans.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(226, Byte), Integer))
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
		Me.txtFechaTrans.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
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
		Me.txtFechaTrans.Calendar.Size = New System.Drawing.Size(152, 174)
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
		Me.txtFechaTrans.Calendar.NoneButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.txtFechaTrans.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
		Me.txtFechaTrans.Calendar.NoneButton.IsBackStageButton = False
		Me.txtFechaTrans.Calendar.NoneButton.Location = New System.Drawing.Point(80, 0)
		Me.txtFechaTrans.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
		Me.txtFechaTrans.Calendar.NoneButton.Text = "None"
		Me.txtFechaTrans.Calendar.NoneButton.UseVisualStyle = True
		'
		'
		'
		Me.txtFechaTrans.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
		Me.txtFechaTrans.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
		Me.txtFechaTrans.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
		Me.txtFechaTrans.Calendar.TodayButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.txtFechaTrans.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
		Me.txtFechaTrans.Calendar.TodayButton.IsBackStageButton = False
		Me.txtFechaTrans.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
		Me.txtFechaTrans.Calendar.TodayButton.Size = New System.Drawing.Size(80, 20)
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
		Me.txtFechaTrans.Location = New System.Drawing.Point(20, 30)
		Me.txtFechaTrans.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
		Me.txtFechaTrans.MinValue = New Date(CType(0, Long))
		Me.txtFechaTrans.Name = "txtFechaTrans"
		Me.txtFechaTrans.ShowCheckBox = False
		Me.txtFechaTrans.Size = New System.Drawing.Size(156, 20)
		Me.txtFechaTrans.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
		Me.txtFechaTrans.TabIndex = 530
		Me.txtFechaTrans.TabStop = False
		Me.txtFechaTrans.Tag = "0"
		Me.txtFechaTrans.Value = New Date(2015, 4, 14, 15, 59, 3, 447)
		'
		'GroupBox4
		'
		Me.GroupBox4.Controls.Add(Me.pnSaldoME)
		Me.GroupBox4.Controls.Add(Me.pnSaldoMN)
		Me.GroupBox4.Controls.Add(Me.Label41)
		Me.GroupBox4.Controls.Add(Me.tb19)
		Me.GroupBox4.Controls.Add(Me.lblTipoCambio)
		Me.GroupBox4.Controls.Add(Me.Label42)
		Me.GroupBox4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.GroupBox4.ForeColor = System.Drawing.Color.Black
		Me.GroupBox4.Location = New System.Drawing.Point(976, 97)
		Me.GroupBox4.Name = "GroupBox4"
		Me.GroupBox4.Size = New System.Drawing.Size(407, 117)
		Me.GroupBox4.TabIndex = 516
		Me.GroupBox4.TabStop = False
		Me.GroupBox4.Text = "SALDO DE LA COMPRA"
		'
		'pnSaldoME
		'
		Me.pnSaldoME.Controls.Add(Me.pnColorME)
		Me.pnSaldoME.Controls.Add(Me.Label38)
		Me.pnSaldoME.Location = New System.Drawing.Point(24, 72)
		Me.pnSaldoME.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
		Me.pnSaldoME.Name = "pnSaldoME"
		Me.pnSaldoME.Size = New System.Drawing.Size(228, 31)
		Me.pnSaldoME.TabIndex = 433
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
		'Label38
		'
		Me.Label38.AutoSize = True
		Me.Label38.BackColor = System.Drawing.Color.Transparent
		Me.Label38.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
		Me.Label38.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
		Me.Label38.Location = New System.Drawing.Point(9, 11)
		Me.Label38.Name = "Label38"
		Me.Label38.Size = New System.Drawing.Size(133, 12)
		Me.Label38.TabIndex = 54
		Me.Label38.Text = "PENDIENTE DE PAGO ME:"
		'
		'pnSaldoMN
		'
		Me.pnSaldoMN.Controls.Add(Me.pnColorMN)
		Me.pnSaldoMN.Controls.Add(Me.Label40)
		Me.pnSaldoMN.Location = New System.Drawing.Point(24, 43)
		Me.pnSaldoMN.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
		Me.pnSaldoMN.Name = "pnSaldoMN"
		Me.pnSaldoMN.Size = New System.Drawing.Size(228, 30)
		Me.pnSaldoMN.TabIndex = 432
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
		'Label40
		'
		Me.Label40.AutoSize = True
		Me.Label40.BackColor = System.Drawing.Color.Transparent
		Me.Label40.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
		Me.Label40.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
		Me.Label40.Location = New System.Drawing.Point(8, 8)
		Me.Label40.Name = "Label40"
		Me.Label40.Size = New System.Drawing.Size(133, 12)
		Me.Label40.TabIndex = 223
		Me.Label40.Text = "PENDIENTE DE PAGO MN:"
		'
		'Label41
		'
		Me.Label41.AutoSize = True
		Me.Label41.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label41.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
		Me.Label41.Location = New System.Drawing.Point(278, 36)
		Me.Label41.Name = "Label41"
		Me.Label41.Size = New System.Drawing.Size(98, 12)
		Me.Label41.TabIndex = 431
		Me.Label41.Text = "MONEDA COMPRA"
		'
		'tb19
		'
		Me.tb19.ActiveColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(226, Byte), Integer))
		Me.tb19.ActiveText = "Nacional"
		Me.tb19.BackColor = System.Drawing.Color.Transparent
		Me.tb19.Enabled = False
		Me.tb19.InActiveColor = System.Drawing.Color.WhiteSmoke
		Me.tb19.InActiveText = "Extranjera"
		Me.tb19.Location = New System.Drawing.Point(269, 51)
		Me.tb19.MaximumSize = New System.Drawing.Size(135, 51)
		Me.tb19.MinimumSize = New System.Drawing.Size(93, 30)
		Me.tb19.Name = "tb19"
		Me.tb19.Size = New System.Drawing.Size(116, 30)
		Me.tb19.SliderColor = System.Drawing.Color.Black
		Me.tb19.SlidingAngle = 8
		Me.tb19.TabIndex = 430
		Me.tb19.Text = "ToggleButton21"
		Me.tb19.TextColor = System.Drawing.Color.White
		Me.tb19.ToggleState = Helios.Cont.Presentation.WinForm.ToggleButton2.ToggleButtonState.[ON]
		Me.tb19.ToggleStyle = Helios.Cont.Presentation.WinForm.ToggleButton2.ToggleButtonStyle.IOS
		'
		'lblTipoCambio
		'
		Me.lblTipoCambio.AutoSize = True
		Me.lblTipoCambio.BackColor = System.Drawing.Color.Transparent
		Me.lblTipoCambio.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTipoCambio.ForeColor = System.Drawing.Color.Maroon
		Me.lblTipoCambio.Location = New System.Drawing.Point(177, 23)
		Me.lblTipoCambio.Name = "lblTipoCambio"
		Me.lblTipoCambio.Size = New System.Drawing.Size(31, 13)
		Me.lblTipoCambio.TabIndex = 428
		Me.lblTipoCambio.Text = "0.00"
		'
		'Label42
		'
		Me.Label42.AutoSize = True
		Me.Label42.BackColor = System.Drawing.Color.Transparent
		Me.Label42.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
		Me.Label42.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
		Me.Label42.Location = New System.Drawing.Point(134, 24)
		Me.Label42.Name = "Label42"
		Me.Label42.Size = New System.Drawing.Size(23, 12)
		Me.Label42.TabIndex = 429
		Me.Label42.Text = "T/C:"
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.txtFechaComprobante)
		Me.GroupBox1.Controls.Add(Me.Label23)
		Me.GroupBox1.Controls.Add(Me.txtNumeroCompr)
		Me.GroupBox1.Controls.Add(Me.Label26)
		Me.GroupBox1.Controls.Add(Me.txtSerieCompr)
		Me.GroupBox1.Controls.Add(Me.Label25)
		Me.GroupBox1.Controls.Add(Me.txtComprobante)
		Me.GroupBox1.Controls.Add(Me.txtProveedor)
		Me.GroupBox1.Controls.Add(Me.Label27)
		Me.GroupBox1.Controls.Add(Me.Label36)
		Me.GroupBox1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.GroupBox1.ForeColor = System.Drawing.Color.Black
		Me.GroupBox1.Location = New System.Drawing.Point(5, 117)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(733, 108)
		Me.GroupBox1.TabIndex = 515
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "DATOS DE LA COMPRA"
		'
		'txtFechaComprobante
		'
		Me.txtFechaComprobante.BackColor = System.Drawing.SystemColors.Info
		Me.txtFechaComprobante.BeforeTouchSize = New System.Drawing.Size(326, 20)
		Me.txtFechaComprobante.BorderColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(226, Byte), Integer))
		Me.txtFechaComprobante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtFechaComprobante.CornerRadius = 5
		Me.txtFechaComprobante.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtFechaComprobante.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtFechaComprobante.Location = New System.Drawing.Point(7, 77)
		Me.txtFechaComprobante.MaxLength = 20
		Me.txtFechaComprobante.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
		Me.txtFechaComprobante.MinimumSize = New System.Drawing.Size(14, 10)
		Me.txtFechaComprobante.Name = "txtFechaComprobante"
		Me.txtFechaComprobante.ReadOnly = True
		Me.txtFechaComprobante.Size = New System.Drawing.Size(189, 20)
		Me.txtFechaComprobante.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
		Me.txtFechaComprobante.TabIndex = 453
		'
		'Label23
		'
		Me.Label23.AutoSize = True
		Me.Label23.BackColor = System.Drawing.Color.Transparent
		Me.Label23.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label23.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
		Me.Label23.Location = New System.Drawing.Point(9, 62)
		Me.Label23.Name = "Label23"
		Me.Label23.Size = New System.Drawing.Size(39, 12)
		Me.Label23.TabIndex = 452
		Me.Label23.Text = "FECHA"
		'
		'txtNumeroCompr
		'
		Me.txtNumeroCompr.BackColor = System.Drawing.SystemColors.Info
		Me.txtNumeroCompr.BeforeTouchSize = New System.Drawing.Size(326, 20)
		Me.txtNumeroCompr.BorderColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(226, Byte), Integer))
		Me.txtNumeroCompr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtNumeroCompr.CornerRadius = 5
		Me.txtNumeroCompr.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtNumeroCompr.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtNumeroCompr.Location = New System.Drawing.Point(363, 77)
		Me.txtNumeroCompr.MaxLength = 20
		Me.txtNumeroCompr.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
		Me.txtNumeroCompr.MinimumSize = New System.Drawing.Size(14, 10)
		Me.txtNumeroCompr.Name = "txtNumeroCompr"
		Me.txtNumeroCompr.ReadOnly = True
		Me.txtNumeroCompr.Size = New System.Drawing.Size(150, 20)
		Me.txtNumeroCompr.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
		Me.txtNumeroCompr.TabIndex = 451
		'
		'Label26
		'
		Me.Label26.AutoSize = True
		Me.Label26.BackColor = System.Drawing.Color.Transparent
		Me.Label26.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label26.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
		Me.Label26.Location = New System.Drawing.Point(9, 20)
		Me.Label26.Name = "Label26"
		Me.Label26.Size = New System.Drawing.Size(70, 12)
		Me.Label26.TabIndex = 2
		Me.Label26.Text = "PROVEEDOR"
		'
		'txtSerieCompr
		'
		Me.txtSerieCompr.BackColor = System.Drawing.SystemColors.Info
		Me.txtSerieCompr.BeforeTouchSize = New System.Drawing.Size(326, 20)
		Me.txtSerieCompr.BorderColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(226, Byte), Integer))
		Me.txtSerieCompr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtSerieCompr.CornerRadius = 5
		Me.txtSerieCompr.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtSerieCompr.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtSerieCompr.Location = New System.Drawing.Point(535, 77)
		Me.txtSerieCompr.MaxLength = 20
		Me.txtSerieCompr.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
		Me.txtSerieCompr.MinimumSize = New System.Drawing.Size(14, 10)
		Me.txtSerieCompr.Name = "txtSerieCompr"
		Me.txtSerieCompr.ReadOnly = True
		Me.txtSerieCompr.Size = New System.Drawing.Size(75, 20)
		Me.txtSerieCompr.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
		Me.txtSerieCompr.TabIndex = 450
		'
		'Label25
		'
		Me.Label25.AutoSize = True
		Me.Label25.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
		Me.Label25.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
		Me.Label25.Location = New System.Drawing.Point(533, 62)
		Me.Label25.Name = "Label25"
		Me.Label25.Size = New System.Drawing.Size(36, 12)
		Me.Label25.TabIndex = 201
		Me.Label25.Text = "SERIE"
		'
		'txtComprobante
		'
		Me.txtComprobante.BackColor = System.Drawing.SystemColors.Info
		Me.txtComprobante.BeforeTouchSize = New System.Drawing.Size(326, 20)
		Me.txtComprobante.BorderColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(226, Byte), Integer))
		Me.txtComprobante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtComprobante.CornerRadius = 5
		Me.txtComprobante.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtComprobante.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtComprobante.Location = New System.Drawing.Point(363, 35)
		Me.txtComprobante.MaxLength = 20
		Me.txtComprobante.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
		Me.txtComprobante.MinimumSize = New System.Drawing.Size(14, 10)
		Me.txtComprobante.Name = "txtComprobante"
		Me.txtComprobante.ReadOnly = True
		Me.txtComprobante.Size = New System.Drawing.Size(269, 20)
		Me.txtComprobante.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
		Me.txtComprobante.TabIndex = 449
		'
		'txtProveedor
		'
		Me.txtProveedor.BackColor = System.Drawing.SystemColors.Info
		Me.txtProveedor.BeforeTouchSize = New System.Drawing.Size(326, 20)
		Me.txtProveedor.BorderColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(226, Byte), Integer))
		Me.txtProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
		Me.txtProveedor.CornerRadius = 5
		Me.txtProveedor.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtProveedor.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtProveedor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
		Me.txtProveedor.Location = New System.Drawing.Point(11, 35)
		Me.txtProveedor.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
		Me.txtProveedor.MinimumSize = New System.Drawing.Size(14, 10)
		Me.txtProveedor.Name = "txtProveedor"
		Me.txtProveedor.NearImage = CType(resources.GetObject("txtProveedor.NearImage"), System.Drawing.Image)
		Me.txtProveedor.ReadOnly = True
		Me.txtProveedor.Size = New System.Drawing.Size(326, 20)
		Me.txtProveedor.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
		Me.txtProveedor.TabIndex = 216
		'
		'Label27
		'
		Me.Label27.AutoSize = True
		Me.Label27.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
		Me.Label27.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
		Me.Label27.Location = New System.Drawing.Point(362, 62)
		Me.Label27.Name = "Label27"
		Me.Label27.Size = New System.Drawing.Size(50, 12)
		Me.Label27.TabIndex = 447
		Me.Label27.Text = "NUMERO"
		'
		'Label36
		'
		Me.Label36.AutoSize = True
		Me.Label36.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label36.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
		Me.Label36.Location = New System.Drawing.Point(361, 20)
		Me.Label36.Name = "Label36"
		Me.Label36.Size = New System.Drawing.Size(110, 12)
		Me.Label36.TabIndex = 445
		Me.Label36.Text = "TIPO COMPROBANTE"
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.PopupControlContainer2)
		Me.GroupBox2.Controls.Add(Me.PopupControlContainer3)
		Me.GroupBox2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.GroupBox2.ForeColor = System.Drawing.Color.Brown
		Me.GroupBox2.Location = New System.Drawing.Point(989, 380)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(863, 59)
		Me.GroupBox2.TabIndex = 513
		Me.GroupBox2.TabStop = False
		Me.GroupBox2.Text = "&IMPORTES"
		'
		'PopupControlContainer2
		'
		Me.PopupControlContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.PopupControlContainer2.Controls.Add(Me.pnListaTipoCambio)
		Me.PopupControlContainer2.Controls.Add(Me.ButtonAdv2)
		Me.PopupControlContainer2.Controls.Add(Me.ButtonAdv1)
		Me.PopupControlContainer2.Location = New System.Drawing.Point(10, 106)
		Me.PopupControlContainer2.Name = "PopupControlContainer2"
		Me.PopupControlContainer2.Size = New System.Drawing.Size(377, 166)
		Me.PopupControlContainer2.TabIndex = 514
		'
		'pnListaTipoCambio
		'
		Me.pnListaTipoCambio.Controls.Add(Me.dgvTipoCambio)
		Me.pnListaTipoCambio.Dock = System.Windows.Forms.DockStyle.Fill
		Me.pnListaTipoCambio.Location = New System.Drawing.Point(0, 0)
		Me.pnListaTipoCambio.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
		Me.pnListaTipoCambio.Name = "pnListaTipoCambio"
		Me.pnListaTipoCambio.Size = New System.Drawing.Size(375, 164)
		Me.pnListaTipoCambio.TabIndex = 210
		'
		'dgvTipoCambio
		'
		Me.dgvTipoCambio.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
		Me.dgvTipoCambio.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
		Me.dgvTipoCambio.BackColor = System.Drawing.SystemColors.Window
		Me.dgvTipoCambio.Dock = System.Windows.Forms.DockStyle.Fill
		Me.dgvTipoCambio.FreezeCaption = False
		Me.dgvTipoCambio.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
		Me.dgvTipoCambio.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
		Me.dgvTipoCambio.Location = New System.Drawing.Point(0, 0)
		Me.dgvTipoCambio.Name = "dgvTipoCambio"
		Me.dgvTipoCambio.Size = New System.Drawing.Size(375, 164)
		Me.dgvTipoCambio.TabIndex = 295
		Me.dgvTipoCambio.TableDescriptor.AllowNew = False
		Me.dgvTipoCambio.TableDescriptor.Appearance.AnyCell.Font.Facename = "Segoe UI"
		Me.dgvTipoCambio.TableDescriptor.Appearance.AnyCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
		Me.dgvTipoCambio.TableDescriptor.Appearance.AnyGroupCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
		Me.dgvTipoCambio.TableDescriptor.Appearance.AnyGroupCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
		Me.dgvTipoCambio.TableDescriptor.Appearance.AnyGroupCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer)))
		Me.dgvTipoCambio.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
		Me.dgvTipoCambio.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
		Me.dgvTipoCambio.TableDescriptor.Appearance.AnySummaryCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
		Me.dgvTipoCambio.TableDescriptor.Appearance.AnySummaryCell.Borders.Top = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
		Me.dgvTipoCambio.TableDescriptor.Appearance.AnySummaryCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)))
		Me.dgvTipoCambio.TableDescriptor.Appearance.ColumnHeaderCell.Font.Bold = True
		Me.dgvTipoCambio.TableDescriptor.Appearance.ColumnHeaderCell.Font.Italic = False
		Me.dgvTipoCambio.TableDescriptor.Appearance.ColumnHeaderCell.Font.Size = 8.0!
		Me.dgvTipoCambio.TableDescriptor.Appearance.GroupCaptionCell.CellType = """ColumnHeader"""
		GridColumnDescriptor1.HeaderImage = Nothing
		GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
		GridColumnDescriptor1.HeaderText = "T/C"
		GridColumnDescriptor1.MappingName = "TC"
		GridColumnDescriptor1.Name = "TC"
		GridColumnDescriptor1.ReadOnly = True
		GridColumnDescriptor1.SerializedImageArray = ""
		GridColumnDescriptor1.Width = 60
		GridColumnDescriptor2.AllowSort = False
		GridColumnDescriptor2.Appearance.AnyRecordFieldCell.CellType = "Currency"
		GridColumnDescriptor2.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
		GridColumnDescriptor2.HeaderImage = Nothing
		GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
		GridColumnDescriptor2.HeaderText = "Importe MN"
		GridColumnDescriptor2.MappingName = "importeMN"
		GridColumnDescriptor2.Name = "importeMN"
		GridColumnDescriptor2.ReadOnly = True
		GridColumnDescriptor2.SerializedImageArray = ""
		GridColumnDescriptor2.Width = 100
		GridColumnDescriptor3.AllowSort = False
		GridColumnDescriptor3.Appearance.AnyRecordFieldCell.CellType = "Currency"
		GridColumnDescriptor3.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
		GridColumnDescriptor3.HeaderImage = Nothing
		GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
		GridColumnDescriptor3.HeaderText = "Importe ME"
		GridColumnDescriptor3.MappingName = "importeME"
		GridColumnDescriptor3.Name = "importeME"
		GridColumnDescriptor3.ReadOnly = True
		GridColumnDescriptor3.SerializedImageArray = ""
		GridColumnDescriptor3.Width = 100
		Me.dgvTipoCambio.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3})
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
		Me.dgvTipoCambio.TableDescriptor.SummaryRows.Add(GridSummaryRowDescriptor1)
		Me.dgvTipoCambio.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
		Me.dgvTipoCambio.TableDescriptor.TableOptions.RecordRowHeight = 20
		Me.dgvTipoCambio.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("TC"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("importeME"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("importeMN")})
		Me.dgvTipoCambio.Text = "GridGroupingControl2"
		Me.dgvTipoCambio.VersionInfo = "12.4400.0.24"
		'
		'ButtonAdv2
		'
		Me.ButtonAdv2.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
		Me.ButtonAdv2.BackColor = System.Drawing.SystemColors.Highlight
		Me.ButtonAdv2.BeforeTouchSize = New System.Drawing.Size(60, 19)
		Me.ButtonAdv2.ForeColor = System.Drawing.Color.White
		Me.ButtonAdv2.IsBackStageButton = False
		Me.ButtonAdv2.Location = New System.Drawing.Point(64, 110)
		Me.ButtonAdv2.Name = "ButtonAdv2"
		Me.ButtonAdv2.Size = New System.Drawing.Size(60, 19)
		Me.ButtonAdv2.TabIndex = 209
		Me.ButtonAdv2.Text = "Cancelar"
		Me.ButtonAdv2.UseVisualStyle = True
		'
		'ButtonAdv1
		'
		Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
		Me.ButtonAdv1.BackColor = System.Drawing.SystemColors.Highlight
		Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(60, 19)
		Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
		Me.ButtonAdv1.IsBackStageButton = False
		Me.ButtonAdv1.Location = New System.Drawing.Point(4, 110)
		Me.ButtonAdv1.Name = "ButtonAdv1"
		Me.ButtonAdv1.Size = New System.Drawing.Size(60, 19)
		Me.ButtonAdv1.TabIndex = 208
		Me.ButtonAdv1.Text = "OK"
		Me.ButtonAdv1.UseVisualStyle = True
		'
		'PopupControlContainer3
		'
		Me.PopupControlContainer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.PopupControlContainer3.Controls.Add(Me.pn)
		Me.PopupControlContainer3.Controls.Add(Me.ButtonAdv6)
		Me.PopupControlContainer3.Controls.Add(Me.ButtonAdv9)
		Me.PopupControlContainer3.Location = New System.Drawing.Point(53, 80)
		Me.PopupControlContainer3.Name = "PopupControlContainer3"
		Me.PopupControlContainer3.Size = New System.Drawing.Size(670, 166)
		Me.PopupControlContainer3.TabIndex = 513
		'
		'pn
		'
		Me.pn.Controls.Add(Me.dgvDiferencia)
		Me.pn.Dock = System.Windows.Forms.DockStyle.Fill
		Me.pn.Location = New System.Drawing.Point(0, 0)
		Me.pn.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
		Me.pn.Name = "pn"
		Me.pn.Size = New System.Drawing.Size(668, 164)
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
		Me.dgvDiferencia.Size = New System.Drawing.Size(668, 164)
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
		GridColumnDescriptor4.AllowSort = False
		GridColumnDescriptor4.HeaderImage = Nothing
		GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
		GridColumnDescriptor4.HeaderText = "ID"
		GridColumnDescriptor4.MappingName = "idDocumento"
		GridColumnDescriptor4.Name = "idDocumento"
		GridColumnDescriptor4.ReadOnly = True
		GridColumnDescriptor4.SerializedImageArray = ""
		GridColumnDescriptor4.Width = 50
		GridColumnDescriptor5.Appearance.AnyRecordFieldCell.CellType = "Currency"
		GridColumnDescriptor5.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencyDecimalDigits = 3
		GridColumnDescriptor5.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
		GridColumnDescriptor5.HeaderImage = Nothing
		GridColumnDescriptor5.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
		GridColumnDescriptor5.HeaderText = "T/C"
		GridColumnDescriptor5.MappingName = "TC"
		GridColumnDescriptor5.Name = "TC"
		GridColumnDescriptor5.ReadOnly = True
		GridColumnDescriptor5.SerializedImageArray = ""
		GridColumnDescriptor5.Width = 50
		GridColumnDescriptor6.AllowSort = False
		GridColumnDescriptor6.Appearance.AnyRecordFieldCell.CellType = "Currency"
		GridColumnDescriptor6.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
		GridColumnDescriptor6.HeaderImage = Nothing
		GridColumnDescriptor6.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
		GridColumnDescriptor6.HeaderText = "Importe MN"
		GridColumnDescriptor6.MappingName = "importeMN"
		GridColumnDescriptor6.Name = "importeMN"
		GridColumnDescriptor6.ReadOnly = True
		GridColumnDescriptor6.SerializedImageArray = ""
		GridColumnDescriptor6.Width = 90
		GridColumnDescriptor7.AllowSort = False
		GridColumnDescriptor7.Appearance.AnyRecordFieldCell.CellType = "Currency"
		GridColumnDescriptor7.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
		GridColumnDescriptor7.HeaderImage = Nothing
		GridColumnDescriptor7.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
		GridColumnDescriptor7.HeaderText = "Importe ME"
		GridColumnDescriptor7.MappingName = "importeME"
		GridColumnDescriptor7.Name = "importeME"
		GridColumnDescriptor7.ReadOnly = True
		GridColumnDescriptor7.SerializedImageArray = ""
		GridColumnDescriptor7.Width = 90
		GridColumnDescriptor8.Appearance.AnyRecordFieldCell.CellType = "Currency"
		GridColumnDescriptor8.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencyDecimalDigits = 3
		GridColumnDescriptor8.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
		GridColumnDescriptor8.HeaderImage = Nothing
		GridColumnDescriptor8.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
		GridColumnDescriptor8.HeaderText = "T/C"
		GridColumnDescriptor8.MappingName = "TCCompra"
		GridColumnDescriptor8.Name = "TCCompra"
		GridColumnDescriptor8.SerializedImageArray = ""
		GridColumnDescriptor8.Width = 50
		GridColumnDescriptor9.AllowSort = False
		GridColumnDescriptor9.Appearance.AnyRecordFieldCell.CellType = "Currency"
		GridColumnDescriptor9.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
		GridColumnDescriptor9.HeaderImage = Nothing
		GridColumnDescriptor9.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
		GridColumnDescriptor9.HeaderText = "Importe MN"
		GridColumnDescriptor9.MappingName = "importeCompraMN"
		GridColumnDescriptor9.Name = "importeCompraMN"
		GridColumnDescriptor9.ReadOnly = True
		GridColumnDescriptor9.SerializedImageArray = ""
		GridColumnDescriptor9.Width = 90
		GridColumnDescriptor10.AllowSort = False
		GridColumnDescriptor10.Appearance.AnyRecordFieldCell.CellType = "Currency"
		GridColumnDescriptor10.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
		GridColumnDescriptor10.HeaderImage = Nothing
		GridColumnDescriptor10.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
		GridColumnDescriptor10.HeaderText = "Importe ME"
		GridColumnDescriptor10.MappingName = "importeCompraME"
		GridColumnDescriptor10.Name = "importeCompraME"
		GridColumnDescriptor10.ReadOnly = True
		GridColumnDescriptor10.SerializedImageArray = ""
		GridColumnDescriptor10.Width = 90
		GridColumnDescriptor11.AllowSort = False
		GridColumnDescriptor11.Appearance.AnyRecordFieldCell.CellType = "Currency"
		GridColumnDescriptor11.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
		GridColumnDescriptor11.HeaderImage = Nothing
		GridColumnDescriptor11.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
		GridColumnDescriptor11.HeaderText = "Importe MN"
		GridColumnDescriptor11.MappingName = "difMNCajaMN"
		GridColumnDescriptor11.Name = "difMNCajaMN"
		GridColumnDescriptor11.ReadOnly = True
		GridColumnDescriptor11.SerializedImageArray = ""
		GridColumnDescriptor11.Width = 90
		GridColumnDescriptor12.AllowSort = False
		GridColumnDescriptor12.Appearance.AnyRecordFieldCell.CellType = "Currency"
		GridColumnDescriptor12.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
		GridColumnDescriptor12.HeaderImage = Nothing
		GridColumnDescriptor12.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
		GridColumnDescriptor12.HeaderText = "Importe ME"
		GridColumnDescriptor12.MappingName = "difMNCajaME"
		GridColumnDescriptor12.Name = "difMNCajaME"
		GridColumnDescriptor12.ReadOnly = True
		GridColumnDescriptor12.SerializedImageArray = ""
		GridColumnDescriptor12.Width = 90
		Me.dgvDiferencia.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7, GridColumnDescriptor8, GridColumnDescriptor9, GridColumnDescriptor10, GridColumnDescriptor11, GridColumnDescriptor12})
		GridSummaryRowDescriptor2.Name = "Row 1"
		GridSummaryColumnDescriptor3.Appearance.AnySummaryCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
		GridSummaryColumnDescriptor3.Appearance.AnySummaryCell.TextAlign = Syncfusion.Windows.Forms.Grid.GridTextAlign.[Default]
		GridSummaryColumnDescriptor3.DataMember = "difMNCajaMN"
		GridSummaryColumnDescriptor3.Format = "{Sum}"
		GridSummaryColumnDescriptor3.Name = "difMNCajaMN"
		GridSummaryColumnDescriptor3.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
		GridSummaryColumnDescriptor4.Appearance.AnySummaryCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
		GridSummaryColumnDescriptor4.Appearance.AnySummaryCell.TextAlign = Syncfusion.Windows.Forms.Grid.GridTextAlign.[Default]
		GridSummaryColumnDescriptor4.DataMember = "difMNCajaME"
		GridSummaryColumnDescriptor4.Format = "{Sum}"
		GridSummaryColumnDescriptor4.Name = "difMNCajaME"
		GridSummaryColumnDescriptor4.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
		GridSummaryRowDescriptor2.SummaryColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor() {GridSummaryColumnDescriptor3, GridSummaryColumnDescriptor4})
		Me.dgvDiferencia.TableDescriptor.SummaryRows.Add(GridSummaryRowDescriptor2)
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
		'cbotipoOperacion
		'
		Me.cbotipoOperacion.BackColor = System.Drawing.Color.White
		Me.cbotipoOperacion.BeforeTouchSize = New System.Drawing.Size(332, 21)
		Me.cbotipoOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cbotipoOperacion.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cbotipoOperacion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
		Me.cbotipoOperacion.Location = New System.Drawing.Point(173, 89)
		Me.cbotipoOperacion.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
		Me.cbotipoOperacion.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
		Me.cbotipoOperacion.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
		Me.cbotipoOperacion.Name = "cbotipoOperacion"
		Me.cbotipoOperacion.Size = New System.Drawing.Size(332, 21)
		Me.cbotipoOperacion.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
		Me.cbotipoOperacion.TabIndex = 511
		'
		'GradientPanel3
		'
		Me.GradientPanel3.BackColor = System.Drawing.Color.WhiteSmoke
		Me.GradientPanel3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.GradientPanel3.Controls.Add(Me.ButtonAdv3)
		Me.GradientPanel3.Controls.Add(Me.btOperacion)
		Me.GradientPanel3.Dock = System.Windows.Forms.DockStyle.Top
		Me.GradientPanel3.Location = New System.Drawing.Point(0, 555)
		Me.GradientPanel3.Name = "GradientPanel3"
		Me.GradientPanel3.Size = New System.Drawing.Size(852, 85)
		Me.GradientPanel3.TabIndex = 510
		'
		'ButtonAdv3
		'
		Me.ButtonAdv3.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
		Me.ButtonAdv3.BackColor = System.Drawing.Color.White
		Me.ButtonAdv3.BeforeTouchSize = New System.Drawing.Size(100, 32)
		Me.ButtonAdv3.FlatAppearance.BorderColor = System.Drawing.Color.Gray
		Me.ButtonAdv3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.ButtonAdv3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.ButtonAdv3.ForeColor = System.Drawing.Color.Black
		Me.ButtonAdv3.IsBackStageButton = False
		Me.ButtonAdv3.Location = New System.Drawing.Point(735, 6)
		Me.ButtonAdv3.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
		Me.ButtonAdv3.Name = "ButtonAdv3"
		Me.ButtonAdv3.Size = New System.Drawing.Size(100, 32)
		Me.ButtonAdv3.TabIndex = 9
		Me.ButtonAdv3.Text = "Cancel"
		Me.ButtonAdv3.UseVisualStyle = True
		'
		'btOperacion
		'
		Me.btOperacion.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
		Me.btOperacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
		Me.btOperacion.BeforeTouchSize = New System.Drawing.Size(110, 32)
		Me.btOperacion.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btOperacion.ForeColor = System.Drawing.Color.White
		Me.btOperacion.IsBackStageButton = False
		Me.btOperacion.Location = New System.Drawing.Point(610, 6)
		Me.btOperacion.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
		Me.btOperacion.Name = "btOperacion"
		Me.btOperacion.Size = New System.Drawing.Size(110, 32)
		Me.btOperacion.TabIndex = 8
		Me.btOperacion.Text = "Grabar"
		Me.btOperacion.UseVisualStyle = True
		'
		'frmDevolucionAproveedor
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
		Me.BorderThickness = 0
		Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(255, Byte), Integer))
		Me.CaptionBarHeight = 50
		Me.ClientSize = New System.Drawing.Size(852, 603)
		Me.Controls.Add(Me.GradientPanel3)
		Me.Controls.Add(Me.Panel4)
		Me.Controls.Add(Me.PanelError)
		Me.Name = "frmDevolucionAproveedor"
		Me.ShowIcon = False
		Me.Text = ""
		Me.PanelError.ResumeLayout(False)
		Me.PanelError.PerformLayout()
		CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
		Me.PanelDetallePagos.ResumeLayout(False)
		Me.pcEntidad.ResumeLayout(False)
		Me.pcEntidad.PerformLayout()
		CType(Me.TextBoxExt1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.txtNomEntidadFinaciera, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.dgvDetalleItems, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Panel4.ResumeLayout(False)
		Me.Panel4.PerformLayout()
		CType(Me.cboTipoDocumento, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.nudDeudaPendienteme, System.ComponentModel.ISupportInitialize).EndInit()
		Me.pnDiferencia.ResumeLayout(False)
		Me.pnDiferencia.PerformLayout()
		CType(Me.txtDiferenciaMontos, System.ComponentModel.ISupportInitialize).EndInit()
		Me.pnEntidad.ResumeLayout(False)
		Me.pnEntidad.PerformLayout()
		CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.cboEntidad, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.txtCtaCorriente, System.ComponentModel.ISupportInitialize).EndInit()
		Me.pnTipoCambio.ResumeLayout(False)
		Me.pnTipoCambio.PerformLayout()
		CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.txtTipoCambio, System.ComponentModel.ISupportInitialize).EndInit()
		Me.pnExtranjero.ResumeLayout(False)
		Me.pnExtranjero.PerformLayout()
		CType(Me.txtImporteComprame, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.nudDeudaPendientemn, System.ComponentModel.ISupportInitialize).EndInit()
		Me.pnNacional.ResumeLayout(False)
		Me.pnNacional.PerformLayout()
		CType(Me.txtImporteCompramn, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.txtNumeroOper, System.ComponentModel.ISupportInitialize).EndInit()
		Me.GroupBox5.ResumeLayout(False)
		Me.pnImpMNDisp.ResumeLayout(False)
		Me.pnImpMNDisp.PerformLayout()
		Me.pnImpMEDisp.ResumeLayout(False)
		Me.pnImpMEDisp.PerformLayout()
		Me.GroupBox3.ResumeLayout(False)
		Me.pnFecha.ResumeLayout(False)
		Me.pnFecha.PerformLayout()
		CType(Me.cboMoneda, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.cboTipo, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.cboDepositoHijo, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.txtSaldoPorPagar, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.txtFechaTrans.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.txtFechaTrans, System.ComponentModel.ISupportInitialize).EndInit()
		Me.GroupBox4.ResumeLayout(False)
		Me.GroupBox4.PerformLayout()
		Me.pnSaldoME.ResumeLayout(False)
		Me.pnSaldoME.PerformLayout()
		Me.pnColorME.ResumeLayout(False)
		Me.pnColorME.PerformLayout()
		Me.pnSaldoMN.ResumeLayout(False)
		Me.pnSaldoMN.PerformLayout()
		Me.pnColorMN.ResumeLayout(False)
		Me.pnColorMN.PerformLayout()
		Me.GroupBox1.ResumeLayout(False)
		Me.GroupBox1.PerformLayout()
		CType(Me.txtFechaComprobante, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.txtNumeroCompr, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.txtSerieCompr, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.txtComprobante, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.txtProveedor, System.ComponentModel.ISupportInitialize).EndInit()
		Me.GroupBox2.ResumeLayout(False)
		Me.PopupControlContainer2.ResumeLayout(False)
		Me.pnListaTipoCambio.ResumeLayout(False)
		CType(Me.dgvTipoCambio, System.ComponentModel.ISupportInitialize).EndInit()
		Me.PopupControlContainer3.ResumeLayout(False)
		Me.pn.ResumeLayout(False)
		CType(Me.dgvDiferencia, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.cbotipoOperacion, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).EndInit()
		Me.GradientPanel3.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents PanelError As System.Windows.Forms.Panel
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents PanelDetallePagos As System.Windows.Forms.Panel
    Private WithEvents pcEntidad As Syncfusion.Windows.Forms.PopupControlContainer
    Friend WithEvents TextBoxExt1 As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtNomEntidadFinaciera As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Private WithEvents ButtonAdv7 As Syncfusion.Windows.Forms.ButtonAdv
    Private WithEvents ButtonAdv8 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents dgvDetalleItems As System.Windows.Forms.DataGridView
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents BannerTextProvider1 As Syncfusion.Windows.Forms.BannerTextProvider
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
    Friend WithEvents colSec As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents pnImpMNDisp As System.Windows.Forms.Panel
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents nudDeudaPendientemn As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents pnImpMEDisp As System.Windows.Forms.Panel
    Friend WithEvents nudDeudaPendienteme As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cboTipo As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents cboMoneda As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents cboDepositoHijo As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents txtCuentaOrigen As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents cbotipoOperacion As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents PopupControlContainer2 As Syncfusion.Windows.Forms.PopupControlContainer
    Friend WithEvents pnListaTipoCambio As System.Windows.Forms.Panel
    Friend WithEvents dgvTipoCambio As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Private WithEvents ButtonAdv2 As Syncfusion.Windows.Forms.ButtonAdv
    Private WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Private WithEvents PopupControlContainer3 As Syncfusion.Windows.Forms.PopupControlContainer
    Friend WithEvents pn As System.Windows.Forms.Panel
    Friend WithEvents dgvDiferencia As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Private WithEvents ButtonAdv6 As Syncfusion.Windows.Forms.ButtonAdv
    Private WithEvents ButtonAdv9 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents pnDiferencia As System.Windows.Forms.Panel
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtDiferenciaMontos As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents pnTipoCambio As System.Windows.Forms.Panel
    Friend WithEvents txtTipoCambio As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents pnExtranjero As System.Windows.Forms.Panel
    Friend WithEvents lblMontoE As System.Windows.Forms.Label
    Friend WithEvents txtImporteComprame As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents pnNacional As System.Windows.Forms.Panel
    Friend WithEvents lblMontoN As System.Windows.Forms.Label
    Friend WithEvents txtImporteCompramn As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cboTipoDocumento As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents pnEntidad As System.Windows.Forms.Panel
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents cboEntidad As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtCtaCorriente As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents pnFecha As System.Windows.Forms.Panel
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents txtFechaEmision As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtFechaCobro As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtNumeroOper As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtFechaComprobante As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtNumeroCompr As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtSerieCompr As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtComprobante As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtProveedor As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents pnSaldoME As System.Windows.Forms.Panel
    Friend WithEvents pnColorME As System.Windows.Forms.Panel
    Friend WithEvents lblDeudaPendienteme As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents pnSaldoMN As System.Windows.Forms.Panel
    Friend WithEvents pnColorMN As System.Windows.Forms.Panel
    Friend WithEvents lblDeudaPendiente As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents tb19 As Helios.Cont.Presentation.WinForm.ToggleButton2
    Friend WithEvents lblTipoCambio As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents GradientPanel3 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents ButtonAdv3 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents btOperacion As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents txtSaldoPorPagar As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents lblMonedaCobro As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFechaTrans As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents Label2 As Label
	Friend WithEvents PictureBox5 As PictureBox
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDevolucionAcliente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDevolucionAcliente))
        Dim BannerTextInfo1 As Syncfusion.Windows.Forms.BannerTextInfo = New Syncfusion.Windows.Forms.BannerTextInfo()
        Dim BannerTextInfo2 As Syncfusion.Windows.Forms.BannerTextInfo = New Syncfusion.Windows.Forms.BannerTextInfo()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.ToolStrip5 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.lblIdDocumento = New System.Windows.Forms.ToolStripLabel()
        Me.PanelError = New System.Windows.Forms.Panel()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.DockingClientPanel1 = New Syncfusion.Windows.Forms.Tools.DockingClientPanel()
        Me.txtMontoME = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtGlosa = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtTipoCambio = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtMontoMN = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PanelDetallePagos = New System.Windows.Forms.Panel()
        Me.pcEntidad = New Syncfusion.Windows.Forms.PopupControlContainer()
        Me.TextBoxExt1 = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtNomEntidadFinaciera = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ButtonAdv7 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv8 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.dgvDetalleItems = New System.Windows.Forms.DataGridView()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblSaldoFinalme = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblDeudaPendienteme = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblSaldoFinal = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblDeudaPendiente = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GradientPanel3 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCuentaCorriente = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtNumOper = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cboEntidades = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.gpVSBehavior = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboMoneda = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.cboTipoDoc = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.txtFechaComprobante = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.txtNumero = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.BannerTextProvider1 = New Syncfusion.Windows.Forms.BannerTextProvider(Me.components)
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
        Me.Panel6.SuspendLayout()
        Me.ToolStrip5.SuspendLayout()
        Me.PanelError.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DockingClientPanel1.SuspendLayout()
        CType(Me.txtMontoME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGlosa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoCambio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMontoMN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelDetallePagos.SuspendLayout()
        Me.pcEntidad.SuspendLayout()
        CType(Me.TextBoxExt1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNomEntidadFinaciera, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDetalleItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel3.SuspendLayout()
        CType(Me.txtCuentaCorriente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumOper, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.cboEntidades, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gpVSBehavior, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpVSBehavior.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.cboMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTipoDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaComprobante.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.ToolStrip5)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(797, 45)
        Me.Panel6.TabIndex = 430
        '
        'ToolStrip5
        '
        Me.ToolStrip5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStrip5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip5.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip5.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.lblIdDocumento})
        Me.ToolStrip5.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip5.Name = "ToolStrip5"
        Me.ToolStrip5.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip5.Size = New System.Drawing.Size(797, 45)
        Me.ToolStrip5.TabIndex = 1
        Me.ToolStrip5.Text = "ToolStrip5"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton1.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.ToolStripButton1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(86, 42)
        Me.ToolStripButton1.Text = "Grabar"
        '
        'lblIdDocumento
        '
        Me.lblIdDocumento.Name = "lblIdDocumento"
        Me.lblIdDocumento.Size = New System.Drawing.Size(13, 42)
        Me.lblIdDocumento.Text = "0"
        '
        'PanelError
        '
        Me.PanelError.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PanelError.Controls.Add(Me.PictureBox3)
        Me.PanelError.Controls.Add(Me.lblEstado)
        Me.PanelError.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelError.Location = New System.Drawing.Point(0, 45)
        Me.PanelError.Name = "PanelError"
        Me.PanelError.Size = New System.Drawing.Size(797, 22)
        Me.PanelError.TabIndex = 431
        Me.PanelError.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox3.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(778, 0)
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
        'DockingClientPanel1
        '
        Me.DockingClientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DockingClientPanel1.Controls.Add(Me.txtMontoME)
        Me.DockingClientPanel1.Controls.Add(Me.Label13)
        Me.DockingClientPanel1.Controls.Add(Me.txtGlosa)
        Me.DockingClientPanel1.Controls.Add(Me.Label20)
        Me.DockingClientPanel1.Controls.Add(Me.txtTipoCambio)
        Me.DockingClientPanel1.Controls.Add(Me.Label8)
        Me.DockingClientPanel1.Controls.Add(Me.txtMontoMN)
        Me.DockingClientPanel1.Controls.Add(Me.Label6)
        Me.DockingClientPanel1.Controls.Add(Me.PanelDetallePagos)
        Me.DockingClientPanel1.Controls.Add(Me.GradientPanel1)
        Me.DockingClientPanel1.Controls.Add(Me.Label12)
        Me.DockingClientPanel1.Controls.Add(Me.GradientPanel3)
        Me.DockingClientPanel1.Controls.Add(Me.gpVSBehavior)
        Me.DockingClientPanel1.Location = New System.Drawing.Point(0, 69)
        Me.DockingClientPanel1.Name = "DockingClientPanel1"
        Me.DockingClientPanel1.Size = New System.Drawing.Size(797, 453)
        Me.DockingClientPanel1.TabIndex = 432
        '
        'txtMontoME
        '
        Me.txtMontoME.BackGroundColor = System.Drawing.Color.Honeydew
        Me.txtMontoME.BeforeTouchSize = New System.Drawing.Size(207, 20)
        Me.txtMontoME.BorderColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.txtMontoME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMontoME.CornerRadius = 5
        Me.txtMontoME.CurrencySymbol = ""
        Me.txtMontoME.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMontoME.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoME.Location = New System.Drawing.Point(612, 209)
        Me.txtMontoME.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.txtMontoME.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtMontoME.Name = "txtMontoME"
        Me.txtMontoME.NullString = ""
        Me.txtMontoME.Size = New System.Drawing.Size(136, 20)
        Me.txtMontoME.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtMontoME.TabIndex = 407
        Me.txtMontoME.Text = "0.00"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label13.Location = New System.Drawing.Point(610, 190)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(73, 12)
        Me.Label13.TabIndex = 406
        Me.Label13.Text = "IMPORTE ME."
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtGlosa
        '
        Me.txtGlosa.BackColor = System.Drawing.Color.White
        Me.txtGlosa.BeforeTouchSize = New System.Drawing.Size(207, 20)
        Me.txtGlosa.BorderColor = System.Drawing.Color.DarkGray
        Me.txtGlosa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGlosa.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtGlosa.Location = New System.Drawing.Point(12, 172)
        Me.txtGlosa.Metrocolor = System.Drawing.Color.DarkGray
        Me.txtGlosa.Multiline = True
        Me.txtGlosa.Name = "txtGlosa"
        Me.txtGlosa.Size = New System.Drawing.Size(343, 57)
        Me.txtGlosa.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtGlosa.TabIndex = 442
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(15, 155)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(83, 12)
        Me.Label20.TabIndex = 441
        Me.Label20.Text = "NOTAS - GLOSA"
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.BackGroundColor = System.Drawing.Color.Honeydew
        Me.txtTipoCambio.BeforeTouchSize = New System.Drawing.Size(207, 20)
        Me.txtTipoCambio.BorderColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.txtTipoCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTipoCambio.CornerRadius = 5
        Me.txtTipoCambio.CurrencySymbol = ""
        Me.txtTipoCambio.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTipoCambio.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTipoCambio.Location = New System.Drawing.Point(527, 209)
        Me.txtTipoCambio.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.txtTipoCambio.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.NullString = ""
        Me.txtTipoCambio.Size = New System.Drawing.Size(70, 20)
        Me.txtTipoCambio.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtTipoCambio.TabIndex = 405
        Me.txtTipoCambio.Text = "0.00"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label8.Location = New System.Drawing.Point(531, 190)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(23, 12)
        Me.Label8.TabIndex = 404
        Me.Label8.Text = "T/C."
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMontoMN
        '
        Me.txtMontoMN.BackGroundColor = System.Drawing.Color.Honeydew
        Me.txtMontoMN.BeforeTouchSize = New System.Drawing.Size(207, 20)
        Me.txtMontoMN.BorderColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.txtMontoMN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMontoMN.CornerRadius = 5
        Me.txtMontoMN.CurrencySymbol = ""
        Me.txtMontoMN.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMontoMN.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMontoMN.Location = New System.Drawing.Point(385, 209)
        Me.txtMontoMN.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.txtMontoMN.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtMontoMN.Name = "txtMontoMN"
        Me.txtMontoMN.NullString = ""
        Me.txtMontoMN.Size = New System.Drawing.Size(136, 20)
        Me.txtMontoMN.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtMontoMN.TabIndex = 403
        Me.txtMontoMN.Text = "0.00"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label6.Location = New System.Drawing.Point(383, 190)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 12)
        Me.Label6.TabIndex = 402
        Me.Label6.Text = "IMPORTE MN."
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PanelDetallePagos
        '
        Me.PanelDetallePagos.Controls.Add(Me.pcEntidad)
        Me.PanelDetallePagos.Controls.Add(Me.dgvDetalleItems)
        Me.PanelDetallePagos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelDetallePagos.Location = New System.Drawing.Point(0, 246)
        Me.PanelDetallePagos.Name = "PanelDetallePagos"
        Me.PanelDetallePagos.Size = New System.Drawing.Size(797, 207)
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
        Me.TextBoxExt1.BeforeTouchSize = New System.Drawing.Size(207, 20)
        Me.TextBoxExt1.BorderColor = System.Drawing.SystemColors.Highlight
        Me.TextBoxExt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxExt1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBoxExt1.Location = New System.Drawing.Point(4, 74)
        Me.TextBoxExt1.MaxLength = 5
        Me.TextBoxExt1.Metrocolor = System.Drawing.SystemColors.Highlight
        Me.TextBoxExt1.Name = "TextBoxExt1"
        Me.TextBoxExt1.Size = New System.Drawing.Size(60, 20)
        Me.TextBoxExt1.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextBoxExt1.TabIndex = 214
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(3, 58)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(44, 13)
        Me.Label16.TabIndex = 213
        Me.Label16.Text = "Codigo:"
        '
        'txtNomEntidadFinaciera
        '
        Me.txtNomEntidadFinaciera.BackColor = System.Drawing.Color.White
        Me.txtNomEntidadFinaciera.BeforeTouchSize = New System.Drawing.Size(207, 20)
        Me.txtNomEntidadFinaciera.BorderColor = System.Drawing.SystemColors.Highlight
        Me.txtNomEntidadFinaciera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNomEntidadFinaciera.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNomEntidadFinaciera.Location = New System.Drawing.Point(4, 30)
        Me.txtNomEntidadFinaciera.MaxLength = 20
        Me.txtNomEntidadFinaciera.Metrocolor = System.Drawing.SystemColors.Highlight
        Me.txtNomEntidadFinaciera.Name = "txtNomEntidadFinaciera"
        Me.txtNomEntidadFinaciera.Size = New System.Drawing.Size(203, 20)
        Me.txtNomEntidadFinaciera.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtNomEntidadFinaciera.TabIndex = 212
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(3, 12)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(87, 13)
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
        Me.dgvDetalleItems.Size = New System.Drawing.Size(797, 207)
        Me.dgvDetalleItems.TabIndex = 114
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BackColor = System.Drawing.Color.White
        Me.GradientPanel1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.Panel3)
        Me.GradientPanel1.Controls.Add(Me.lblSaldoFinalme)
        Me.GradientPanel1.Controls.Add(Me.Label7)
        Me.GradientPanel1.Controls.Add(Me.lblDeudaPendienteme)
        Me.GradientPanel1.Controls.Add(Me.Label9)
        Me.GradientPanel1.Controls.Add(Me.lblSaldoFinal)
        Me.GradientPanel1.Controls.Add(Me.Label10)
        Me.GradientPanel1.Controls.Add(Me.lblDeudaPendiente)
        Me.GradientPanel1.Controls.Add(Me.Label14)
        Me.GradientPanel1.Location = New System.Drawing.Point(543, 3)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(249, 138)
        Me.GradientPanel1.TabIndex = 428
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(247, 24)
        Me.Panel3.TabIndex = 439
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label11.Location = New System.Drawing.Point(10, 3)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(194, 19)
        Me.Label11.TabIndex = 170
        Me.Label11.Text = "SALDOS"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSaldoFinalme
        '
        Me.lblSaldoFinalme.AutoSize = True
        Me.lblSaldoFinalme.BackColor = System.Drawing.Color.Transparent
        Me.lblSaldoFinalme.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaldoFinalme.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblSaldoFinalme.Location = New System.Drawing.Point(152, 109)
        Me.lblSaldoFinalme.Name = "lblSaldoFinalme"
        Me.lblSaldoFinalme.Size = New System.Drawing.Size(31, 13)
        Me.lblSaldoFinalme.TabIndex = 57
        Me.lblSaldoFinalme.Text = "0.00"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(43, 109)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(103, 13)
        Me.Label7.TabIndex = 56
        Me.Label7.Text = "Saldo a cuenta m.e:"
        '
        'lblDeudaPendienteme
        '
        Me.lblDeudaPendienteme.AutoSize = True
        Me.lblDeudaPendienteme.BackColor = System.Drawing.Color.Transparent
        Me.lblDeudaPendienteme.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeudaPendienteme.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblDeudaPendienteme.Location = New System.Drawing.Point(152, 88)
        Me.lblDeudaPendienteme.Name = "lblDeudaPendienteme"
        Me.lblDeudaPendienteme.Size = New System.Drawing.Size(31, 13)
        Me.lblDeudaPendienteme.TabIndex = 55
        Me.lblDeudaPendienteme.Text = "0.00"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(24, 88)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(122, 13)
        Me.Label9.TabIndex = 54
        Me.Label9.Text = "Pendiente de Pago m.e:"
        '
        'lblSaldoFinal
        '
        Me.lblSaldoFinal.AutoSize = True
        Me.lblSaldoFinal.BackColor = System.Drawing.Color.Transparent
        Me.lblSaldoFinal.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaldoFinal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblSaldoFinal.Location = New System.Drawing.Point(152, 62)
        Me.lblSaldoFinal.Name = "lblSaldoFinal"
        Me.lblSaldoFinal.Size = New System.Drawing.Size(31, 13)
        Me.lblSaldoFinal.TabIndex = 53
        Me.lblSaldoFinal.Text = "0.00"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(64, 62)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(82, 13)
        Me.Label10.TabIndex = 52
        Me.Label10.Text = "Saldo a cuenta:"
        '
        'lblDeudaPendiente
        '
        Me.lblDeudaPendiente.AutoSize = True
        Me.lblDeudaPendiente.BackColor = System.Drawing.Color.Transparent
        Me.lblDeudaPendiente.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeudaPendiente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblDeudaPendiente.Location = New System.Drawing.Point(152, 41)
        Me.lblDeudaPendiente.Name = "lblDeudaPendiente"
        Me.lblDeudaPendiente.Size = New System.Drawing.Size(31, 13)
        Me.lblDeudaPendiente.TabIndex = 51
        Me.lblDeudaPendiente.Text = "0.00"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(45, 41)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(101, 13)
        Me.Label14.TabIndex = 50
        Me.Label14.Text = "Pendiente de Pago:"
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label12.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label12.Location = New System.Drawing.Point(383, 151)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(194, 19)
        Me.Label12.TabIndex = 401
        Me.Label12.Text = "IMPORTE A DESEMBOLSAR"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GradientPanel3
        '
        Me.GradientPanel3.BackColor = System.Drawing.Color.White
        Me.GradientPanel3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.GradientPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel3.Controls.Add(Me.Label4)
        Me.GradientPanel3.Controls.Add(Me.txtCuentaCorriente)
        Me.GradientPanel3.Controls.Add(Me.PictureBox1)
        Me.GradientPanel3.Controls.Add(Me.txtNumOper)
        Me.GradientPanel3.Controls.Add(Me.Panel1)
        Me.GradientPanel3.Controls.Add(Me.cboEntidades)
        Me.GradientPanel3.Location = New System.Drawing.Point(292, 3)
        Me.GradientPanel3.Name = "GradientPanel3"
        Me.GradientPanel3.Size = New System.Drawing.Size(249, 138)
        Me.GradientPanel3.TabIndex = 426
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label4.Location = New System.Drawing.Point(10, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 12)
        Me.Label4.TabIndex = 440
        Me.Label4.Text = "ENTIDAD FINANCIERA"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCuentaCorriente
        '
        Me.txtCuentaCorriente.BackColor = System.Drawing.Color.Honeydew
        BannerTextInfo1.Text = "NRO. CUENTA CORRIENTE"
        BannerTextInfo1.Visible = True
        Me.BannerTextProvider1.SetBannerText(Me.txtCuentaCorriente, BannerTextInfo1)
        Me.txtCuentaCorriente.BeforeTouchSize = New System.Drawing.Size(207, 20)
        Me.txtCuentaCorriente.BorderColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.txtCuentaCorriente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuentaCorriente.CornerRadius = 5
        Me.txtCuentaCorriente.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCuentaCorriente.Location = New System.Drawing.Point(10, 107)
        Me.txtCuentaCorriente.MaxLength = 20
        Me.txtCuentaCorriente.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.txtCuentaCorriente.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtCuentaCorriente.Name = "txtCuentaCorriente"
        Me.txtCuentaCorriente.Size = New System.Drawing.Size(207, 20)
        Me.txtCuentaCorriente.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtCuentaCorriente.TabIndex = 437
        '
        'PictureBox1
        '
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(223, 52)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(21, 21)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 439
        Me.PictureBox1.TabStop = False
        '
        'txtNumOper
        '
        Me.txtNumOper.BackColor = System.Drawing.Color.Honeydew
        BannerTextInfo2.Text = "NRO. OPERACION"
        BannerTextInfo2.Visible = True
        Me.BannerTextProvider1.SetBannerText(Me.txtNumOper, BannerTextInfo2)
        Me.txtNumOper.BeforeTouchSize = New System.Drawing.Size(207, 20)
        Me.txtNumOper.BorderColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.txtNumOper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumOper.CornerRadius = 5
        Me.txtNumOper.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNumOper.Location = New System.Drawing.Point(10, 80)
        Me.txtNumOper.MaxLength = 20
        Me.txtNumOper.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.txtNumOper.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtNumOper.Name = "txtNumOper"
        Me.txtNumOper.Size = New System.Drawing.Size(207, 20)
        Me.txtNumOper.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtNumOper.TabIndex = 211
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.Label21)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(247, 24)
        Me.Panel1.TabIndex = 438
        '
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label21.Location = New System.Drawing.Point(10, 3)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(194, 19)
        Me.Label21.TabIndex = 170
        Me.Label21.Text = "TRANSFERENCIAS"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboEntidades
        '
        Me.cboEntidades.BackColor = System.Drawing.Color.White
        Me.cboEntidades.BeforeTouchSize = New System.Drawing.Size(207, 21)
        Me.cboEntidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEntidades.FlatBorderColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.cboEntidades.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEntidades.Location = New System.Drawing.Point(10, 52)
        Me.cboEntidades.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.cboEntidades.Name = "cboEntidades"
        Me.cboEntidades.Size = New System.Drawing.Size(207, 21)
        Me.cboEntidades.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboEntidades.TabIndex = 436
        '
        'gpVSBehavior
        '
        Me.gpVSBehavior.BackColor = System.Drawing.Color.White
        Me.gpVSBehavior.BorderColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.gpVSBehavior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.gpVSBehavior.Controls.Add(Me.Panel2)
        Me.gpVSBehavior.Controls.Add(Me.Label5)
        Me.gpVSBehavior.Controls.Add(Me.Label3)
        Me.gpVSBehavior.Controls.Add(Me.Label2)
        Me.gpVSBehavior.Controls.Add(Me.Label1)
        Me.gpVSBehavior.Controls.Add(Me.cboMoneda)
        Me.gpVSBehavior.Controls.Add(Me.cboTipoDoc)
        Me.gpVSBehavior.Controls.Add(Me.txtFechaComprobante)
        Me.gpVSBehavior.Controls.Add(Me.txtNumero)
        Me.gpVSBehavior.Location = New System.Drawing.Point(3, 3)
        Me.gpVSBehavior.Name = "gpVSBehavior"
        Me.gpVSBehavior.Size = New System.Drawing.Size(287, 138)
        Me.gpVSBehavior.TabIndex = 414
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(285, 24)
        Me.Panel2.TabIndex = 439
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label17.Location = New System.Drawing.Point(10, 3)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(194, 19)
        Me.Label17.TabIndex = 170
        Me.Label17.Text = "DATOS DEL COMPROBANTE"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label5.Location = New System.Drawing.Point(30, 113)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 12)
        Me.Label5.TabIndex = 406
        Me.Label5.Text = "MONEDA"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label3.Location = New System.Drawing.Point(30, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 12)
        Me.Label3.TabIndex = 405
        Me.Label3.Text = "NUMERO"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label2.Location = New System.Drawing.Point(24, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 12)
        Me.Label2.TabIndex = 404
        Me.Label2.Text = "TIPO DOC."
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Location = New System.Drawing.Point(41, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 12)
        Me.Label1.TabIndex = 403
        Me.Label1.Text = "FECHA"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboMoneda
        '
        Me.cboMoneda.BackColor = System.Drawing.Color.White
        Me.cboMoneda.BeforeTouchSize = New System.Drawing.Size(181, 21)
        Me.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMoneda.FlatBorderColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.cboMoneda.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMoneda.Location = New System.Drawing.Point(89, 107)
        Me.cboMoneda.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.cboMoneda.Name = "cboMoneda"
        Me.cboMoneda.Size = New System.Drawing.Size(181, 21)
        Me.cboMoneda.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboMoneda.TabIndex = 401
        '
        'cboTipoDoc
        '
        Me.cboTipoDoc.BackColor = System.Drawing.Color.White
        Me.cboTipoDoc.BeforeTouchSize = New System.Drawing.Size(181, 21)
        Me.cboTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoDoc.Enabled = False
        Me.cboTipoDoc.FlatBorderColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.cboTipoDoc.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoDoc.Location = New System.Drawing.Point(89, 55)
        Me.cboTipoDoc.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.cboTipoDoc.Name = "cboTipoDoc"
        Me.cboTipoDoc.Size = New System.Drawing.Size(181, 21)
        Me.cboTipoDoc.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboTipoDoc.TabIndex = 212
        Me.cboTipoDoc.TabStop = False
        '
        'txtFechaComprobante
        '
        Me.txtFechaComprobante.BackColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.txtFechaComprobante.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtFechaComprobante.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaComprobante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtFechaComprobante.Calendar.AllowMultipleSelection = False
        Me.txtFechaComprobante.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaComprobante.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaComprobante.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechaComprobante.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaComprobante.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFechaComprobante.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtFechaComprobante.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFechaComprobante.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaComprobante.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaComprobante.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtFechaComprobante.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtFechaComprobante.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtFechaComprobante.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtFechaComprobante.Calendar.Iso8601CalenderFormat = False
        Me.txtFechaComprobante.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaComprobante.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaComprobante.Calendar.Name = "monthCalendar"
        Me.txtFechaComprobante.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtFechaComprobante.Calendar.SelectedDates = New Date(-1) {}
        Me.txtFechaComprobante.Calendar.Size = New System.Drawing.Size(177, 174)
        Me.txtFechaComprobante.Calendar.SizeToFit = True
        Me.txtFechaComprobante.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaComprobante.Calendar.TabIndex = 0
        Me.txtFechaComprobante.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtFechaComprobante.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaComprobante.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaComprobante.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaComprobante.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaComprobante.Calendar.NoneButton.IsBackStageButton = False
        Me.txtFechaComprobante.Calendar.NoneButton.Location = New System.Drawing.Point(105, 0)
        Me.txtFechaComprobante.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtFechaComprobante.Calendar.NoneButton.Text = "None"
        Me.txtFechaComprobante.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtFechaComprobante.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaComprobante.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaComprobante.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaComprobante.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaComprobante.Calendar.TodayButton.IsBackStageButton = False
        Me.txtFechaComprobante.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaComprobante.Calendar.TodayButton.Size = New System.Drawing.Size(105, 20)
        Me.txtFechaComprobante.Calendar.TodayButton.Text = "Today"
        Me.txtFechaComprobante.Calendar.TodayButton.UseVisualStyle = True
        Me.txtFechaComprobante.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaComprobante.CalendarForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaComprobante.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtFechaComprobante.CustomFormat = "dd/MM/yyyy hh:mm:ss tt"
        Me.txtFechaComprobante.DropDownImage = Nothing
        Me.txtFechaComprobante.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaComprobante.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaComprobante.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtFechaComprobante.ForeColor = System.Drawing.Color.White
        Me.txtFechaComprobante.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFechaComprobante.Location = New System.Drawing.Point(89, 30)
        Me.txtFechaComprobante.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaComprobante.MinValue = New Date(CType(0, Long))
        Me.txtFechaComprobante.Name = "txtFechaComprobante"
        Me.txtFechaComprobante.ShowCheckBox = False
        Me.txtFechaComprobante.ShowDropButton = False
        Me.txtFechaComprobante.Size = New System.Drawing.Size(181, 20)
        Me.txtFechaComprobante.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaComprobante.TabIndex = 208
        Me.txtFechaComprobante.TabStop = False
        Me.txtFechaComprobante.Value = New Date(2015, 4, 14, 15, 59, 3, 447)
        '
        'txtNumero
        '
        Me.txtNumero.Location = New System.Drawing.Point(89, 82)
        Me.txtNumero.MaxLength = 20
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(181, 19)
        Me.txtNumero.TabIndex = 206
        Me.txtNumero.TabStop = False
        '
        'Timer1
        '
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
        Me.colSec.HeaderText = "sec"
        Me.colSec.Name = "colSec"
        Me.colSec.ReadOnly = True
        Me.colSec.Width = 50
        '
        'frmDevolucionAcliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.Color.ForestGreen
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.CaptionBarHeight = 50
        Me.CaptionButtonColor = System.Drawing.Color.White
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.White
        CaptionLabel1.Location = New System.Drawing.Point(30, 8)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(280, 24)
        CaptionLabel1.Text = "Devolución Por Nota de Crédito"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(797, 524)
        Me.Controls.Add(Me.DockingClientPanel1)
        Me.Controls.Add(Me.PanelError)
        Me.Controls.Add(Me.Panel6)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDevolucionAcliente"
        Me.ShowIcon = False
        Me.Text = ""
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.ToolStrip5.ResumeLayout(False)
        Me.ToolStrip5.PerformLayout()
        Me.PanelError.ResumeLayout(False)
        Me.PanelError.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DockingClientPanel1.ResumeLayout(False)
        Me.DockingClientPanel1.PerformLayout()
        CType(Me.txtMontoME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGlosa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoCambio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMontoMN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelDetallePagos.ResumeLayout(False)
        Me.pcEntidad.ResumeLayout(False)
        Me.pcEntidad.PerformLayout()
        CType(Me.TextBoxExt1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNomEntidadFinaciera, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDetalleItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel3.ResumeLayout(False)
        Me.GradientPanel3.PerformLayout()
        CType(Me.txtCuentaCorriente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumOper, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.cboEntidades, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gpVSBehavior, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpVSBehavior.ResumeLayout(False)
        Me.gpVSBehavior.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.cboMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTipoDoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaComprobante.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaComprobante, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents ToolStrip5 As System.Windows.Forms.ToolStrip
    Friend WithEvents PanelError As System.Windows.Forms.Panel
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents DockingClientPanel1 As Syncfusion.Windows.Forms.Tools.DockingClientPanel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txtCuentaCorriente As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents cboEntidades As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents txtNumOper As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents PanelDetallePagos As System.Windows.Forms.Panel
    Private WithEvents pcEntidad As Syncfusion.Windows.Forms.PopupControlContainer
    Friend WithEvents TextBoxExt1 As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtNomEntidadFinaciera As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Private WithEvents ButtonAdv7 As Syncfusion.Windows.Forms.ButtonAdv
    Private WithEvents ButtonAdv8 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents dgvDetalleItems As System.Windows.Forms.DataGridView
    Private WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents lblSaldoFinalme As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblDeudaPendienteme As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblSaldoFinal As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblDeudaPendiente As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents GradientPanel3 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Private WithEvents gpVSBehavior As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents cboMoneda As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents cboTipoDoc As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents txtFechaComprobante As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents txtNumero As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents txtMontoME As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Private WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtTipoCambio As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Private WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtMontoMN As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Private WithEvents Label6 As System.Windows.Forms.Label
    Private WithEvents Label12 As System.Windows.Forms.Label
    Private WithEvents Label5 As System.Windows.Forms.Label
    Private WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lblIdDocumento As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txtGlosa As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Private WithEvents Panel1 As System.Windows.Forms.Panel
    Private WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents BannerTextProvider1 As Syncfusion.Windows.Forms.BannerTextProvider
    Private WithEvents Panel3 As System.Windows.Forms.Panel
    Private WithEvents Label11 As System.Windows.Forms.Label
    Private WithEvents Panel2 As System.Windows.Forms.Panel
    Private WithEvents Label17 As System.Windows.Forms.Label
    Private WithEvents Label4 As System.Windows.Forms.Label
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
End Class

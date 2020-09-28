<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCobroPrestamo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCobroPrestamo))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.lblEstado = New System.Windows.Forms.ToolStripButton()
        Me.lblTipoPres = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.GuardarToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.lblPerido = New System.Windows.Forms.ToolStripLabel()
        Me.PegarToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblIdDocumento = New System.Windows.Forms.ToolStripLabel()
        Me.lbldDocCaja = New System.Windows.Forms.ToolStripLabel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.btnConfigCaja = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.lblSaldoFinalme = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblSaldoFinal = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GradientPanel3 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.panel15 = New System.Windows.Forms.Panel()
        Me.label35 = New System.Windows.Forms.Label()
        Me.DockingClientPanel1 = New Syncfusion.Windows.Forms.Tools.DockingClientPanel()
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtCuentaCorriente = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cboEntidades = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNumOper = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label18 = New System.Windows.Forms.Label()
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
        Me.GradientPanel4 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblDeudaPendienteme = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblDeudaPendiente = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.GradientPanel5 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboEntidadFinanciera = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.cboTipo = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.txtTipoCambio = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtImporteComprame = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.txtImporteCompramn = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.gpVSBehavior = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.cboMoneda = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.cboTipoDoc = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.txtFechaComprobante = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.txtNumero = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.QGlobalColorSchemeManager1 = New Qios.DevSuite.Components.QGlobalColorSchemeManager(Me.components)
        Me.dockingManager1 = New Syncfusion.Windows.Forms.Tools.DockingManager(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStrip1.SuspendLayout()
        Me.ToolStrip3.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel3.SuspendLayout()
        Me.panel15.SuspendLayout()
        Me.DockingClientPanel1.SuspendLayout()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCuentaCorriente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboEntidades, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumOper, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.PanelDetallePagos.SuspendLayout()
        Me.pcEntidad.SuspendLayout()
        CType(Me.TextBoxExt1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNomEntidadFinaciera, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDetalleItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.GradientPanel5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel5.SuspendLayout()
        CType(Me.cboEntidadFinanciera, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoCambio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtImporteComprame, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtImporteCompramn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.gpVSBehavior, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpVSBehavior.SuspendLayout()
        CType(Me.cboMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTipoDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaComprobante.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dockingManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblEstado, Me.lblTipoPres})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 25)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(858, 25)
        Me.ToolStrip1.TabIndex = 411
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'lblEstado
        '
        Me.lblEstado.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblEstado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblEstado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(112, 22)
        Me.lblEstado.Text = "Estado: nuevo pago."
        '
        'lblTipoPres
        '
        Me.lblTipoPres.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblTipoPres.Name = "lblTipoPres"
        Me.lblTipoPres.Size = New System.Drawing.Size(57, 22)
        Me.lblTipoPres.Text = "Prestamo"
        '
        'ToolStrip3
        '
        Me.ToolStrip3.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GuardarToolStripButton, Me.lblPerido, Me.PegarToolStripButton, Me.toolStripSeparator1, Me.lblIdDocumento, Me.lbldDocCaja})
        Me.ToolStrip3.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip3.Size = New System.Drawing.Size(858, 25)
        Me.ToolStrip3.TabIndex = 412
        Me.ToolStrip3.Text = "ToolStrip3"
        '
        'GuardarToolStripButton
        '
        Me.GuardarToolStripButton.Image = CType(resources.GetObject("GuardarToolStripButton.Image"), System.Drawing.Image)
        Me.GuardarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.GuardarToolStripButton.Name = "GuardarToolStripButton"
        Me.GuardarToolStripButton.Size = New System.Drawing.Size(62, 22)
        Me.GuardarToolStripButton.Text = "&Grabar"
        '
        'lblPerido
        '
        Me.lblPerido.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblPerido.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblPerido.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblPerido.Name = "lblPerido"
        Me.lblPerido.Size = New System.Drawing.Size(55, 22)
        Me.lblPerido.Text = "01/2014"
        Me.lblPerido.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'PegarToolStripButton
        '
        Me.PegarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PegarToolStripButton.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.arrow_circle_135_left
        Me.PegarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PegarToolStripButton.Name = "PegarToolStripButton"
        Me.PegarToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PegarToolStripButton.Text = "&Cancelar"
        Me.PegarToolStripButton.Visible = False
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'lblIdDocumento
        '
        Me.lblIdDocumento.Name = "lblIdDocumento"
        Me.lblIdDocumento.Size = New System.Drawing.Size(19, 22)
        Me.lblIdDocumento.Text = "00"
        Me.lblIdDocumento.Visible = False
        '
        'lbldDocCaja
        '
        Me.lbldDocCaja.Name = "lbldDocCaja"
        Me.lbldDocCaja.Size = New System.Drawing.Size(13, 22)
        Me.lbldDocCaja.Text = "0"
        Me.lbldDocCaja.Visible = False
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.btnConfigCaja)
        Me.Panel7.Controls.Add(Me.Label23)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 50)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(858, 20)
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
        Me.Label23.Size = New System.Drawing.Size(51, 13)
        Me.Label23.TabIndex = 416
        Me.Label23.Text = "CAPITAL"
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BackColor = System.Drawing.Color.White
        Me.GradientPanel1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.lblSaldoFinalme)
        Me.GradientPanel1.Controls.Add(Me.Label7)
        Me.GradientPanel1.Controls.Add(Me.Label9)
        Me.GradientPanel1.Controls.Add(Me.lblSaldoFinal)
        Me.GradientPanel1.Controls.Add(Me.Label10)
        Me.GradientPanel1.Controls.Add(Me.Label14)
        Me.GradientPanel1.Location = New System.Drawing.Point(543, 28)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(249, 113)
        Me.GradientPanel1.TabIndex = 428
        '
        'lblSaldoFinalme
        '
        Me.lblSaldoFinalme.AutoSize = True
        Me.lblSaldoFinalme.BackColor = System.Drawing.Color.Transparent
        Me.lblSaldoFinalme.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaldoFinalme.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.lblSaldoFinalme.Location = New System.Drawing.Point(140, 83)
        Me.lblSaldoFinalme.Name = "lblSaldoFinalme"
        Me.lblSaldoFinalme.Size = New System.Drawing.Size(31, 13)
        Me.lblSaldoFinalme.TabIndex = 57
        Me.lblSaldoFinalme.Text = "0.00"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label7.Location = New System.Drawing.Point(31, 83)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(102, 13)
        Me.Label7.TabIndex = 56
        Me.Label7.Text = "Saldo a cuenta m.e:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label9.Location = New System.Drawing.Point(12, 62)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(121, 13)
        Me.Label9.TabIndex = 54
        Me.Label9.Text = "Pendiente de Pago m.e:"
        '
        'lblSaldoFinal
        '
        Me.lblSaldoFinal.AutoSize = True
        Me.lblSaldoFinal.BackColor = System.Drawing.Color.Transparent
        Me.lblSaldoFinal.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaldoFinal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.lblSaldoFinal.Location = New System.Drawing.Point(140, 36)
        Me.lblSaldoFinal.Name = "lblSaldoFinal"
        Me.lblSaldoFinal.Size = New System.Drawing.Size(31, 13)
        Me.lblSaldoFinal.TabIndex = 53
        Me.lblSaldoFinal.Text = "0.00"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label10.Location = New System.Drawing.Point(52, 36)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(82, 13)
        Me.Label10.TabIndex = 52
        Me.Label10.Text = "Saldo a cuenta:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label14.Location = New System.Drawing.Point(33, 15)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(101, 13)
        Me.Label14.TabIndex = 50
        Me.Label14.Text = "Pendiente de Pago:"
        '
        'GradientPanel3
        '
        Me.GradientPanel3.BackColor = System.Drawing.Color.White
        Me.GradientPanel3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.GradientPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel3.Controls.Add(Me.Label13)
        Me.GradientPanel3.Controls.Add(Me.Label8)
        Me.GradientPanel3.Controls.Add(Me.Label6)
        Me.GradientPanel3.Location = New System.Drawing.Point(292, 28)
        Me.GradientPanel3.Name = "GradientPanel3"
        Me.GradientPanel3.Size = New System.Drawing.Size(249, 113)
        Me.GradientPanel3.TabIndex = 426
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(53, 30)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(27, 13)
        Me.Label13.TabIndex = 399
        Me.Label13.Text = "t/c.:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(11, 81)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 13)
        Me.Label8.TabIndex = 204
        Me.Label8.Text = "Importe me.:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(11, 55)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 13)
        Me.Label6.TabIndex = 203
        Me.Label6.Text = "Importe mn.:"
        '
        'panel15
        '
        Me.panel15.BackColor = System.Drawing.Color.Transparent
        Me.panel15.BackgroundImage = CType(resources.GetObject("panel15.BackgroundImage"), System.Drawing.Image)
        Me.panel15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.panel15.Controls.Add(Me.label35)
        Me.panel15.Location = New System.Drawing.Point(3, 4)
        Me.panel15.Name = "panel15"
        Me.panel15.Size = New System.Drawing.Size(287, 24)
        Me.panel15.TabIndex = 413
        '
        'label35
        '
        Me.label35.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label35.ForeColor = System.Drawing.Color.Black
        Me.label35.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.label35.Location = New System.Drawing.Point(10, 3)
        Me.label35.Name = "label35"
        Me.label35.Size = New System.Drawing.Size(194, 19)
        Me.label35.TabIndex = 170
        Me.label35.Text = "Datos del comprobante de pago"
        Me.label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DockingClientPanel1
        '
        Me.DockingClientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DockingClientPanel1.Controls.Add(Me.GradientPanel2)
        Me.DockingClientPanel1.Controls.Add(Me.Panel3)
        Me.DockingClientPanel1.Controls.Add(Me.PanelDetallePagos)
        Me.DockingClientPanel1.Controls.Add(Me.GradientPanel4)
        Me.DockingClientPanel1.Controls.Add(Me.Panel2)
        Me.DockingClientPanel1.Controls.Add(Me.GradientPanel5)
        Me.DockingClientPanel1.Controls.Add(Me.Panel1)
        Me.DockingClientPanel1.Controls.Add(Me.Panel4)
        Me.DockingClientPanel1.Controls.Add(Me.gpVSBehavior)
        Me.DockingClientPanel1.Location = New System.Drawing.Point(0, 71)
        Me.DockingClientPanel1.Name = "DockingClientPanel1"
        Me.DockingClientPanel1.Size = New System.Drawing.Size(857, 405)
        Me.DockingClientPanel1.TabIndex = 414
        '
        'GradientPanel2
        '
        Me.GradientPanel2.BackColor = System.Drawing.Color.White
        Me.GradientPanel2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.GradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel2.Controls.Add(Me.PictureBox1)
        Me.GradientPanel2.Controls.Add(Me.txtCuentaCorriente)
        Me.GradientPanel2.Controls.Add(Me.Label19)
        Me.GradientPanel2.Controls.Add(Me.cboEntidades)
        Me.GradientPanel2.Controls.Add(Me.Label4)
        Me.GradientPanel2.Controls.Add(Me.txtNumOper)
        Me.GradientPanel2.Controls.Add(Me.Label17)
        Me.GradientPanel2.Location = New System.Drawing.Point(3, 189)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(851, 38)
        Me.GradientPanel2.TabIndex = 438
        '
        'PictureBox1
        '
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(251, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(21, 21)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 439
        Me.PictureBox1.TabStop = False
        '
        'txtCuentaCorriente
        '
        Me.txtCuentaCorriente.BackColor = System.Drawing.Color.White
        Me.txtCuentaCorriente.BeforeTouchSize = New System.Drawing.Size(306, 20)
        Me.txtCuentaCorriente.BorderColor = System.Drawing.SystemColors.Highlight
        Me.txtCuentaCorriente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuentaCorriente.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCuentaCorriente.Location = New System.Drawing.Point(550, 8)
        Me.txtCuentaCorriente.MaxLength = 20
        Me.txtCuentaCorriente.Metrocolor = System.Drawing.SystemColors.Highlight
        Me.txtCuentaCorriente.Name = "txtCuentaCorriente"
        Me.txtCuentaCorriente.Size = New System.Drawing.Size(227, 20)
        Me.txtCuentaCorriente.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtCuentaCorriente.TabIndex = 437
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(472, 12)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(78, 13)
        Me.Label19.TabIndex = 438
        Me.Label19.Text = "Cta. corriente:"
        '
        'cboEntidades
        '
        Me.cboEntidades.BackColor = System.Drawing.Color.White
        Me.cboEntidades.BeforeTouchSize = New System.Drawing.Size(190, 21)
        Me.cboEntidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEntidades.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEntidades.Location = New System.Drawing.Point(60, 8)
        Me.cboEntidades.Name = "cboEntidades"
        Me.cboEntidades.Size = New System.Drawing.Size(190, 21)
        Me.cboEntidades.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboEntidades.TabIndex = 436
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(25, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 13)
        Me.Label4.TabIndex = 430
        Me.Label4.Text = "E.F.:"
        '
        'txtNumOper
        '
        Me.txtNumOper.BackColor = System.Drawing.Color.White
        Me.txtNumOper.BeforeTouchSize = New System.Drawing.Size(306, 20)
        Me.txtNumOper.BorderColor = System.Drawing.SystemColors.Highlight
        Me.txtNumOper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumOper.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNumOper.Location = New System.Drawing.Point(341, 9)
        Me.txtNumOper.MaxLength = 20
        Me.txtNumOper.Metrocolor = System.Drawing.SystemColors.Highlight
        Me.txtNumOper.Name = "txtNumOper"
        Me.txtNumOper.Size = New System.Drawing.Size(126, 20)
        Me.txtNumOper.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtNumOper.TabIndex = 211
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(279, 13)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(61, 13)
        Me.Label17.TabIndex = 434
        Me.Label17.Text = "Nro. oper.:"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.BackgroundImage = CType(resources.GetObject("Panel3.BackgroundImage"), System.Drawing.Image)
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel3.Controls.Add(Me.Label18)
        Me.Panel3.Location = New System.Drawing.Point(3, 168)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(851, 24)
        Me.Panel3.TabIndex = 437
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label18.Location = New System.Drawing.Point(10, 3)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(194, 19)
        Me.Label18.TabIndex = 170
        Me.Label18.Text = "Proveedor transferencias:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PanelDetallePagos
        '
        Me.PanelDetallePagos.Controls.Add(Me.pcEntidad)
        Me.PanelDetallePagos.Controls.Add(Me.dgvDetalleItems)
        Me.PanelDetallePagos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelDetallePagos.Location = New System.Drawing.Point(0, 233)
        Me.PanelDetallePagos.Name = "PanelDetallePagos"
        Me.PanelDetallePagos.Size = New System.Drawing.Size(857, 172)
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
        Me.TextBoxExt1.BeforeTouchSize = New System.Drawing.Size(306, 20)
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
        Me.txtNomEntidadFinaciera.BeforeTouchSize = New System.Drawing.Size(306, 20)
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
        Me.dgvDetalleItems.BackgroundColor = System.Drawing.Color.White
        Me.dgvDetalleItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalleItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colId, Me.colNameItem, Me.colum, Me.ColPrecUnit, Me.colMN, Me.colME, Me.colPagoMN, Me.colPagoME, Me.colSaldoMN, Me.colSaldoME, Me.colEstado})
        Me.dgvDetalleItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDetalleItems.EnableHeadersVisualStyles = False
        Me.dgvDetalleItems.Location = New System.Drawing.Point(0, 0)
        Me.dgvDetalleItems.MultiSelect = False
        Me.dgvDetalleItems.Name = "dgvDetalleItems"
        Me.dgvDetalleItems.RowHeadersVisible = False
        Me.dgvDetalleItems.Size = New System.Drawing.Size(857, 172)
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
        'GradientPanel4
        '
        Me.GradientPanel4.BackColor = System.Drawing.Color.White
        Me.GradientPanel4.BorderColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.GradientPanel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel4.Controls.Add(Me.Label1)
        Me.GradientPanel4.Controls.Add(Me.Label2)
        Me.GradientPanel4.Controls.Add(Me.lblDeudaPendienteme)
        Me.GradientPanel4.Controls.Add(Me.Label5)
        Me.GradientPanel4.Controls.Add(Me.Label11)
        Me.GradientPanel4.Controls.Add(Me.Label12)
        Me.GradientPanel4.Controls.Add(Me.lblDeudaPendiente)
        Me.GradientPanel4.Controls.Add(Me.Label21)
        Me.GradientPanel4.Location = New System.Drawing.Point(601, 28)
        Me.GradientPanel4.Name = "GradientPanel4"
        Me.GradientPanel4.Size = New System.Drawing.Size(249, 134)
        Me.GradientPanel4.TabIndex = 428
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(140, 83)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 57
        Me.Label1.Text = "0.00"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.Location = New System.Drawing.Point(31, 83)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 13)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "Saldo a cuenta m.e:"
        '
        'lblDeudaPendienteme
        '
        Me.lblDeudaPendienteme.AutoSize = True
        Me.lblDeudaPendienteme.BackColor = System.Drawing.Color.Transparent
        Me.lblDeudaPendienteme.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeudaPendienteme.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.lblDeudaPendienteme.Location = New System.Drawing.Point(140, 62)
        Me.lblDeudaPendienteme.Name = "lblDeudaPendienteme"
        Me.lblDeudaPendienteme.Size = New System.Drawing.Size(31, 13)
        Me.lblDeudaPendienteme.TabIndex = 55
        Me.lblDeudaPendienteme.Text = "0.00"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label5.Location = New System.Drawing.Point(12, 62)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(122, 13)
        Me.Label5.TabIndex = 54
        Me.Label5.Text = "Pendiente de Pago m.e:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(140, 36)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(31, 13)
        Me.Label11.TabIndex = 53
        Me.Label11.Text = "0.00"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label12.Location = New System.Drawing.Point(52, 36)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(82, 13)
        Me.Label12.TabIndex = 52
        Me.Label12.Text = "Saldo a cuenta:"
        '
        'lblDeudaPendiente
        '
        Me.lblDeudaPendiente.AutoSize = True
        Me.lblDeudaPendiente.BackColor = System.Drawing.Color.Transparent
        Me.lblDeudaPendiente.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeudaPendiente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.lblDeudaPendiente.Location = New System.Drawing.Point(140, 15)
        Me.lblDeudaPendiente.Name = "lblDeudaPendiente"
        Me.lblDeudaPendiente.Size = New System.Drawing.Size(31, 13)
        Me.lblDeudaPendiente.TabIndex = 51
        Me.lblDeudaPendiente.Text = "0.00"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label21.Location = New System.Drawing.Point(33, 15)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(101, 13)
        Me.Label21.TabIndex = 50
        Me.Label21.Text = "Pendiente de Pago:"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), System.Drawing.Image)
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Controls.Add(Me.Label22)
        Me.Panel2.Location = New System.Drawing.Point(601, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(249, 24)
        Me.Panel2.TabIndex = 427
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label22.Location = New System.Drawing.Point(10, 3)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(194, 19)
        Me.Label22.TabIndex = 170
        Me.Label22.Text = "Saldo de la compra:"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GradientPanel5
        '
        Me.GradientPanel5.BackColor = System.Drawing.Color.White
        Me.GradientPanel5.BorderColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.GradientPanel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel5.Controls.Add(Me.Label20)
        Me.GradientPanel5.Controls.Add(Me.Label3)
        Me.GradientPanel5.Controls.Add(Me.cboEntidadFinanciera)
        Me.GradientPanel5.Controls.Add(Me.cboTipo)
        Me.GradientPanel5.Controls.Add(Me.txtTipoCambio)
        Me.GradientPanel5.Controls.Add(Me.Label24)
        Me.GradientPanel5.Controls.Add(Me.txtImporteComprame)
        Me.GradientPanel5.Controls.Add(Me.txtImporteCompramn)
        Me.GradientPanel5.Controls.Add(Me.Label25)
        Me.GradientPanel5.Controls.Add(Me.Label26)
        Me.GradientPanel5.Location = New System.Drawing.Point(292, 28)
        Me.GradientPanel5.Name = "GradientPanel5"
        Me.GradientPanel5.Size = New System.Drawing.Size(303, 134)
        Me.GradientPanel5.TabIndex = 426
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label20.Location = New System.Drawing.Point(11, 28)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(99, 13)
        Me.Label20.TabIndex = 436
        Me.Label20.Text = "Entidad Financiera:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(11, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 435
        Me.Label3.Text = "Tipo:"
        '
        'cboEntidadFinanciera
        '
        Me.cboEntidadFinanciera.BackColor = System.Drawing.Color.White
        Me.cboEntidadFinanciera.BeforeTouchSize = New System.Drawing.Size(172, 21)
        Me.cboEntidadFinanciera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEntidadFinanciera.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEntidadFinanciera.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cboEntidadFinanciera.Location = New System.Drawing.Point(112, 28)
        Me.cboEntidadFinanciera.Name = "cboEntidadFinanciera"
        Me.cboEntidadFinanciera.Size = New System.Drawing.Size(172, 21)
        Me.cboEntidadFinanciera.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboEntidadFinanciera.TabIndex = 434
        '
        'cboTipo
        '
        Me.cboTipo.BackColor = System.Drawing.Color.White
        Me.cboTipo.BeforeTouchSize = New System.Drawing.Size(172, 21)
        Me.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipo.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cboTipo.Items.AddRange(New Object() {"CUENTAS EN EFECTIVO", "CUENTAS EN BANCO"})
        Me.cboTipo.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboTipo, "CUENTAS EN EFECTIVO"))
        Me.cboTipo.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboTipo, "CUENTAS EN BANCO"))
        Me.cboTipo.Location = New System.Drawing.Point(112, 5)
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(172, 21)
        Me.cboTipo.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboTipo.TabIndex = 433
        Me.cboTipo.Text = "CUENTAS EN EFECTIVO"
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.txtTipoCambio.BeforeTouchSize = New System.Drawing.Size(148, 20)
        Me.txtTipoCambio.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTipoCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTipoCambio.DecimalPlaces = 2
        Me.txtTipoCambio.Location = New System.Drawing.Point(112, 55)
        Me.txtTipoCambio.Maximum = New Decimal(New Integer() {-159383552, 46653770, 5421, 0})
        Me.txtTipoCambio.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.Size = New System.Drawing.Size(148, 20)
        Me.txtTipoCambio.TabIndex = 400
        Me.txtTipoCambio.TabStop = False
        Me.txtTipoCambio.ThousandsSeparator = True
        Me.txtTipoCambio.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label24.Location = New System.Drawing.Point(53, 59)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(28, 13)
        Me.Label24.TabIndex = 399
        Me.Label24.Text = "t/c.:"
        '
        'txtImporteComprame
        '
        Me.txtImporteComprame.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.txtImporteComprame.BeforeTouchSize = New System.Drawing.Size(148, 20)
        Me.txtImporteComprame.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtImporteComprame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtImporteComprame.DecimalPlaces = 2
        Me.txtImporteComprame.Enabled = False
        Me.txtImporteComprame.Location = New System.Drawing.Point(113, 107)
        Me.txtImporteComprame.Maximum = New Decimal(New Integer() {-1304428544, 434162106, 542, 0})
        Me.txtImporteComprame.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtImporteComprame.Name = "txtImporteComprame"
        Me.txtImporteComprame.Size = New System.Drawing.Size(148, 20)
        Me.txtImporteComprame.TabIndex = 398
        Me.txtImporteComprame.TabStop = False
        Me.txtImporteComprame.ThousandsSeparator = True
        Me.txtImporteComprame.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'txtImporteCompramn
        '
        Me.txtImporteCompramn.BackColor = System.Drawing.Color.White
        Me.txtImporteCompramn.BeforeTouchSize = New System.Drawing.Size(148, 20)
        Me.txtImporteCompramn.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtImporteCompramn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtImporteCompramn.DecimalPlaces = 2
        Me.txtImporteCompramn.Location = New System.Drawing.Point(112, 81)
        Me.txtImporteCompramn.Maximum = New Decimal(New Integer() {-159383552, 46653770, 5421, 0})
        Me.txtImporteCompramn.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtImporteCompramn.Name = "txtImporteCompramn"
        Me.txtImporteCompramn.Size = New System.Drawing.Size(148, 20)
        Me.txtImporteCompramn.TabIndex = 397
        Me.txtImporteCompramn.TabStop = False
        Me.txtImporteCompramn.ThousandsSeparator = True
        Me.txtImporteCompramn.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label25.Location = New System.Drawing.Point(11, 110)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(70, 13)
        Me.Label25.TabIndex = 204
        Me.Label25.Text = "Importe me.:"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label26.Location = New System.Drawing.Point(11, 84)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(70, 13)
        Me.Label26.TabIndex = 203
        Me.Label26.Text = "Importe mn.:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.Label27)
        Me.Panel1.Location = New System.Drawing.Point(292, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(303, 24)
        Me.Panel1.TabIndex = 425
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label27.Location = New System.Drawing.Point(10, 3)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(194, 19)
        Me.Label27.TabIndex = 170
        Me.Label27.Text = "Importe a pagar:"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.BackgroundImage = CType(resources.GetObject("Panel4.BackgroundImage"), System.Drawing.Image)
        Me.Panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel4.Controls.Add(Me.Label28)
        Me.Panel4.Location = New System.Drawing.Point(3, 4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(287, 24)
        Me.Panel4.TabIndex = 413
        '
        'Label28
        '
        Me.Label28.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label28.Location = New System.Drawing.Point(10, 3)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(194, 19)
        Me.Label28.TabIndex = 170
        Me.Label28.Text = "Datos del comprobante de pago"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpVSBehavior
        '
        Me.gpVSBehavior.BackColor = System.Drawing.Color.White
        Me.gpVSBehavior.BorderColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpVSBehavior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.gpVSBehavior.Controls.Add(Me.cboMoneda)
        Me.gpVSBehavior.Controls.Add(Me.Label29)
        Me.gpVSBehavior.Controls.Add(Me.cboTipoDoc)
        Me.gpVSBehavior.Controls.Add(Me.txtFechaComprobante)
        Me.gpVSBehavior.Controls.Add(Me.txtNumero)
        Me.gpVSBehavior.Controls.Add(Me.Label30)
        Me.gpVSBehavior.Controls.Add(Me.Label31)
        Me.gpVSBehavior.Controls.Add(Me.Label32)
        Me.gpVSBehavior.Location = New System.Drawing.Point(3, 29)
        Me.gpVSBehavior.Name = "gpVSBehavior"
        Me.gpVSBehavior.Size = New System.Drawing.Size(287, 133)
        Me.gpVSBehavior.TabIndex = 414
        '
        'cboMoneda
        '
        Me.cboMoneda.BackColor = System.Drawing.Color.White
        Me.cboMoneda.BeforeTouchSize = New System.Drawing.Size(181, 21)
        Me.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMoneda.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMoneda.Location = New System.Drawing.Point(89, 83)
        Me.cboMoneda.Name = "cboMoneda"
        Me.cboMoneda.Size = New System.Drawing.Size(181, 21)
        Me.cboMoneda.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboMoneda.TabIndex = 401
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label29.Location = New System.Drawing.Point(35, 90)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(49, 13)
        Me.Label29.TabIndex = 400
        Me.Label29.Text = "Moneda:"
        '
        'cboTipoDoc
        '
        Me.cboTipoDoc.BackColor = System.Drawing.Color.White
        Me.cboTipoDoc.BeforeTouchSize = New System.Drawing.Size(181, 21)
        Me.cboTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoDoc.Enabled = False
        Me.cboTipoDoc.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoDoc.Location = New System.Drawing.Point(89, 34)
        Me.cboTipoDoc.Name = "cboTipoDoc"
        Me.cboTipoDoc.Size = New System.Drawing.Size(181, 21)
        Me.cboTipoDoc.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboTipoDoc.TabIndex = 212
        Me.cboTipoDoc.TabStop = False
        '
        'txtFechaComprobante
        '
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
        Me.txtFechaComprobante.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtFechaComprobante.CustomFormat = "dd/MM/yyyy hh:mm:ss tt"
        Me.txtFechaComprobante.DropDownImage = Nothing
        Me.txtFechaComprobante.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaComprobante.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaComprobante.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtFechaComprobante.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFechaComprobante.Location = New System.Drawing.Point(89, 10)
        Me.txtFechaComprobante.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaComprobante.MinValue = New Date(CType(0, Long))
        Me.txtFechaComprobante.Name = "txtFechaComprobante"
        Me.txtFechaComprobante.ShowCheckBox = False
        Me.txtFechaComprobante.Size = New System.Drawing.Size(181, 20)
        Me.txtFechaComprobante.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaComprobante.TabIndex = 208
        Me.txtFechaComprobante.TabStop = False
        Me.txtFechaComprobante.Value = New Date(2015, 4, 14, 15, 59, 3, 447)
        '
        'txtNumero
        '
        Me.txtNumero.Location = New System.Drawing.Point(89, 59)
        Me.txtNumero.MaxLength = 20
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(181, 19)
        Me.txtNumero.TabIndex = 206
        Me.txtNumero.TabStop = False
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label30.Location = New System.Drawing.Point(27, 62)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(48, 13)
        Me.Label30.TabIndex = 201
        Me.Label30.Text = "Número:"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label31.Location = New System.Drawing.Point(27, 37)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(56, 13)
        Me.Label31.TabIndex = 200
        Me.Label31.Text = "Tipo Doc.:"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label32.Location = New System.Drawing.Point(43, 15)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(40, 13)
        Me.Label32.TabIndex = 199
        Me.Label32.Text = "Fecha:"
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
        'frmCobroPrestamo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(858, 477)
        Me.Controls.Add(Me.DockingClientPanel1)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.ToolStrip3)
        Me.Name = "frmCobroPrestamo"
        Me.Text = "Cuota"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel3.ResumeLayout(False)
        Me.GradientPanel3.PerformLayout()
        Me.panel15.ResumeLayout(False)
        Me.DockingClientPanel1.ResumeLayout(False)
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        Me.GradientPanel2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCuentaCorriente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboEntidades, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumOper, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.PanelDetallePagos.ResumeLayout(False)
        Me.pcEntidad.ResumeLayout(False)
        Me.pcEntidad.PerformLayout()
        CType(Me.TextBoxExt1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNomEntidadFinaciera, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDetalleItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel4.ResumeLayout(False)
        Me.GradientPanel4.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.GradientPanel5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel5.ResumeLayout(False)
        Me.GradientPanel5.PerformLayout()
        CType(Me.cboEntidadFinanciera, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoCambio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtImporteComprame, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtImporteCompramn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        CType(Me.gpVSBehavior, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpVSBehavior.ResumeLayout(False)
        Me.gpVSBehavior.PerformLayout()
        CType(Me.cboMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTipoDoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaComprobante.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaComprobante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dockingManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents lblEstado As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents GuardarToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblPerido As System.Windows.Forms.ToolStripLabel
    Friend WithEvents PegarToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblIdDocumento As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lbldDocCaja As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents btnConfigCaja As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Private WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents lblSaldoFinalme As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label

    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblSaldoFinal As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label

    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents GradientPanel3 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Private WithEvents panel15 As System.Windows.Forms.Panel
    Private WithEvents label35 As System.Windows.Forms.Label
    Friend WithEvents DockingClientPanel1 As Syncfusion.Windows.Forms.Tools.DockingClientPanel
    Private WithEvents GradientPanel2 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txtCuentaCorriente As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cboEntidades As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtNumOper As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Private WithEvents Panel3 As System.Windows.Forms.Panel
    Private WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents PanelDetallePagos As System.Windows.Forms.Panel
    Private WithEvents pcEntidad As Syncfusion.Windows.Forms.PopupControlContainer
    Friend WithEvents TextBoxExt1 As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtNomEntidadFinaciera As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Private WithEvents ButtonAdv7 As Syncfusion.Windows.Forms.ButtonAdv
    Private WithEvents ButtonAdv8 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents dgvDetalleItems As System.Windows.Forms.DataGridView
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
    Private WithEvents GradientPanel4 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblDeudaPendienteme As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblDeudaPendiente As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Private WithEvents Panel2 As System.Windows.Forms.Panel
    Private WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents GradientPanel5 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents txtTipoCambio As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtImporteComprame As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents txtImporteCompramn As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Private WithEvents Panel1 As System.Windows.Forms.Panel
    Private WithEvents Label27 As System.Windows.Forms.Label
    Private WithEvents Panel4 As System.Windows.Forms.Panel
    Private WithEvents Label28 As System.Windows.Forms.Label
    Private WithEvents gpVSBehavior As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents cboMoneda As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents cboTipoDoc As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents txtFechaComprobante As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents txtNumero As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents QGlobalColorSchemeManager1 As Qios.DevSuite.Components.QGlobalColorSchemeManager
    Private WithEvents dockingManager1 As Syncfusion.Windows.Forms.Tools.DockingManager
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents lblTipoPres As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cboTipo As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents cboEntidadFinanciera As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class

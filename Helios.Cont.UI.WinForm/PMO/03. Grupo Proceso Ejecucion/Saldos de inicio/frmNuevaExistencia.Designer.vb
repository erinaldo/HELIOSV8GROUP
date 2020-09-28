<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmNuevaExistencia
    Inherits Helios.Cont.Presentation.WinForm.frmMaster

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNuevaExistencia))
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.ButtonAdv5 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv4 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.lblEstado = New System.Windows.Forms.ToolStripButton()
        Me.AutoComplete1 = New Syncfusion.Windows.Forms.Tools.AutoComplete(Me.components)
        Me.AutoComplete2 = New Syncfusion.Windows.Forms.Tools.AutoComplete(Me.components)
        Me.PopupControlContainer2 = New Syncfusion.Windows.Forms.PopupControlContainer()
        Me.lstCategoria = New System.Windows.Forms.ListBox()
        Me.pcClasificacion = New Syncfusion.Windows.Forms.PopupControlContainer()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txtNewClasificacion = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.btmGrabarClasificacion = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.pcMercaderia = New Syncfusion.Windows.Forms.PopupControlContainer()
        Me.lstProductos = New System.Windows.Forms.ListBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.nudCantMax = New System.Windows.Forms.NumericUpDown()
        Me.nudCantMin = New System.Windows.Forms.NumericUpDown()
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.btOperacion = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.pcLikeCategoria = New Syncfusion.Windows.Forms.PopupControlContainer()
        Me.lsvCategoria = New System.Windows.Forms.ListBox()
        Me.ButtonAdv3 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv10 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.pcSubCategoria = New Syncfusion.Windows.Forms.PopupControlContainer()
        Me.lsvSubCategoria = New System.Windows.Forms.ListBox()
        Me.ButtonAdv11 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv12 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.BunifuFlatButton2 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.BunifuFlatButton1 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.BunifuFlatButton15 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtValorPercepcion = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtValorRetencion = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ChVenta = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.ChCompra = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ChPercepcion = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ChRetencion = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BannerTextProvider1 = New Syncfusion.Windows.Forms.BannerTextProvider(Me.components)
        Me.PanelBody = New System.Windows.Forms.Panel()
        Me.sliderTop = New System.Windows.Forms.PictureBox()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.AutoComplete1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AutoComplete2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PopupControlContainer2.SuspendLayout()
        Me.pcClasificacion.SuspendLayout()
        Me.Panel16.SuspendLayout()
        CType(Me.txtNewClasificacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pcMercaderia.SuspendLayout()
        CType(Me.nudCantMax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudCantMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        Me.pcLikeCategoria.SuspendLayout()
        Me.pcSubCategoria.SuspendLayout()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtValorPercepcion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValorRetencion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sliderTop, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonAdv5
        '
        Me.ButtonAdv5.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv5.BackColor = System.Drawing.Color.FromArgb(CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.ButtonAdv5.BeforeTouchSize = New System.Drawing.Size(69, 25)
        Me.ButtonAdv5.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv5.IsBackStageButton = False
        Me.ButtonAdv5.Location = New System.Drawing.Point(706, 436)
        Me.ButtonAdv5.Name = "ButtonAdv5"
        Me.ButtonAdv5.Size = New System.Drawing.Size(69, 25)
        Me.ButtonAdv5.TabIndex = 404
        Me.ButtonAdv5.Text = "Cancel"
        Me.ButtonAdv5.UseVisualStyle = True
        Me.ButtonAdv5.Visible = False
        '
        'ButtonAdv4
        '
        Me.ButtonAdv4.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv4.BackColor = System.Drawing.Color.FromArgb(CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.ButtonAdv4.BeforeTouchSize = New System.Drawing.Size(69, 25)
        Me.ButtonAdv4.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv4.IsBackStageButton = False
        Me.ButtonAdv4.Location = New System.Drawing.Point(635, 436)
        Me.ButtonAdv4.Name = "ButtonAdv4"
        Me.ButtonAdv4.Size = New System.Drawing.Size(69, 25)
        Me.ButtonAdv4.TabIndex = 403
        Me.ButtonAdv4.Text = "Grabar"
        Me.ButtonAdv4.UseVisualStyle = True
        Me.ButtonAdv4.Visible = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblEstado})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(665, 25)
        Me.ToolStrip1.TabIndex = 406
        Me.ToolStrip1.Text = "ToolStrip1"
        Me.ToolStrip1.Visible = False
        '
        'lblEstado
        '
        Me.lblEstado.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblEstado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblEstado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(85, 22)
        Me.lblEstado.Text = "Estado: nuevo."
        '
        'AutoComplete1
        '
        Me.AutoComplete1.HeaderFont = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.AutoComplete1.ItemFont = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.AutoComplete1.MetroColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.AutoComplete1.OverrideCombo = True
        Me.AutoComplete1.ParentForm = Me
        Me.AutoComplete1.Style = Syncfusion.Windows.Forms.Tools.AutoCompleteStyle.[Default]
        '
        'AutoComplete2
        '
        Me.AutoComplete2.HeaderFont = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.AutoComplete2.ItemFont = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.AutoComplete2.MetroColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.AutoComplete2.OverrideCombo = True
        Me.AutoComplete2.ParentForm = Me
        Me.AutoComplete2.Style = Syncfusion.Windows.Forms.Tools.AutoCompleteStyle.[Default]
        '
        'PopupControlContainer2
        '
        Me.PopupControlContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PopupControlContainer2.Controls.Add(Me.lstCategoria)
        Me.PopupControlContainer2.Location = New System.Drawing.Point(823, 422)
        Me.PopupControlContainer2.Name = "PopupControlContainer2"
        Me.PopupControlContainer2.Size = New System.Drawing.Size(49, 39)
        Me.PopupControlContainer2.TabIndex = 407
        Me.PopupControlContainer2.Visible = False
        '
        'lstCategoria
        '
        Me.lstCategoria.Dock = System.Windows.Forms.DockStyle.Top
        Me.lstCategoria.FormattingEnabled = True
        Me.lstCategoria.Location = New System.Drawing.Point(0, 0)
        Me.lstCategoria.Name = "lstCategoria"
        Me.lstCategoria.Size = New System.Drawing.Size(47, 108)
        Me.lstCategoria.TabIndex = 3
        Me.lstCategoria.TabStop = False
        '
        'pcClasificacion
        '
        Me.pcClasificacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pcClasificacion.Controls.Add(Me.Panel16)
        Me.pcClasificacion.Controls.Add(Me.txtNewClasificacion)
        Me.pcClasificacion.Controls.Add(Me.Label36)
        Me.pcClasificacion.Controls.Add(Me.ButtonAdv1)
        Me.pcClasificacion.Controls.Add(Me.btmGrabarClasificacion)
        Me.pcClasificacion.Location = New System.Drawing.Point(979, 110)
        Me.pcClasificacion.Name = "pcClasificacion"
        Me.pcClasificacion.Size = New System.Drawing.Size(357, 153)
        Me.pcClasificacion.TabIndex = 411
        Me.pcClasificacion.Visible = False
        '
        'Panel16
        '
        Me.Panel16.BackColor = System.Drawing.Color.FromArgb(CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.Panel16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel16.Controls.Add(Me.Label34)
        Me.Panel16.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel16.Location = New System.Drawing.Point(0, 0)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(355, 24)
        Me.Panel16.TabIndex = 405
        '
        'Label34
        '
        Me.Label34.BackColor = System.Drawing.Color.Transparent
        Me.Label34.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.White
        Me.Label34.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label34.Location = New System.Drawing.Point(1, 3)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(143, 19)
        Me.Label34.TabIndex = 170
        Me.Label34.Text = "Nueva Clasificación"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtNewClasificacion
        '
        Me.txtNewClasificacion.BackColor = System.Drawing.Color.White
        Me.txtNewClasificacion.BeforeTouchSize = New System.Drawing.Size(257, 22)
        Me.txtNewClasificacion.BorderColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.txtNewClasificacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNewClasificacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNewClasificacion.CornerRadius = 5
        Me.txtNewClasificacion.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNewClasificacion.Location = New System.Drawing.Point(7, 49)
        Me.txtNewClasificacion.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.txtNewClasificacion.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtNewClasificacion.Name = "txtNewClasificacion"
        Me.txtNewClasificacion.Size = New System.Drawing.Size(304, 22)
        Me.txtNewClasificacion.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtNewClasificacion.TabIndex = 404
        Me.txtNewClasificacion.TabStop = False
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label36.Location = New System.Drawing.Point(4, 30)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(116, 13)
        Me.Label36.TabIndex = 403
        Me.Label36.Text = "Nombre clasificación:"
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.FromArgb(CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(60, 19)
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(272, 117)
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(60, 19)
        Me.ButtonAdv1.TabIndex = 209
        Me.ButtonAdv1.TabStop = False
        Me.ButtonAdv1.Text = "Cancelar"
        Me.ButtonAdv1.UseVisualStyle = True
        '
        'btmGrabarClasificacion
        '
        Me.btmGrabarClasificacion.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btmGrabarClasificacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.btmGrabarClasificacion.BeforeTouchSize = New System.Drawing.Size(60, 19)
        Me.btmGrabarClasificacion.ForeColor = System.Drawing.Color.White
        Me.btmGrabarClasificacion.IsBackStageButton = False
        Me.btmGrabarClasificacion.Location = New System.Drawing.Point(210, 117)
        Me.btmGrabarClasificacion.Name = "btmGrabarClasificacion"
        Me.btmGrabarClasificacion.Size = New System.Drawing.Size(60, 19)
        Me.btmGrabarClasificacion.TabIndex = 208
        Me.btmGrabarClasificacion.TabStop = False
        Me.btmGrabarClasificacion.Text = "OK"
        Me.btmGrabarClasificacion.UseVisualStyle = True
        '
        'pcMercaderia
        '
        Me.pcMercaderia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pcMercaderia.Controls.Add(Me.lstProductos)
        Me.pcMercaderia.Location = New System.Drawing.Point(922, 423)
        Me.pcMercaderia.Name = "pcMercaderia"
        Me.pcMercaderia.Size = New System.Drawing.Size(48, 57)
        Me.pcMercaderia.TabIndex = 413
        Me.pcMercaderia.Visible = False
        '
        'lstProductos
        '
        Me.lstProductos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstProductos.FormattingEnabled = True
        Me.lstProductos.Location = New System.Drawing.Point(0, 0)
        Me.lstProductos.Name = "lstProductos"
        Me.lstProductos.Size = New System.Drawing.Size(46, 55)
        Me.lstProductos.TabIndex = 0
        '
        'nudCantMax
        '
        Me.nudCantMax.Location = New System.Drawing.Point(892, 395)
        Me.nudCantMax.Maximum = New Decimal(New Integer() {1874919424, 2328306, 0, 0})
        Me.nudCantMax.Name = "nudCantMax"
        Me.nudCantMax.Size = New System.Drawing.Size(89, 22)
        Me.nudCantMax.TabIndex = 426
        Me.nudCantMax.Visible = False
        '
        'nudCantMin
        '
        Me.nudCantMin.Location = New System.Drawing.Point(795, 395)
        Me.nudCantMin.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.nudCantMin.Name = "nudCantMin"
        Me.nudCantMin.Size = New System.Drawing.Size(91, 22)
        Me.nudCantMin.TabIndex = 427
        Me.nudCantMin.Visible = False
        '
        'GradientPanel2
        '
        Me.GradientPanel2.BackColor = System.Drawing.Color.Transparent
        Me.GradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GradientPanel2.Controls.Add(Me.btOperacion)
        Me.GradientPanel2.Controls.Add(Me.pcLikeCategoria)
        Me.GradientPanel2.Controls.Add(Me.pcSubCategoria)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 553)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(627, 45)
        Me.GradientPanel2.TabIndex = 430
        '
        'btOperacion
        '
        Me.btOperacion.ActiveBorderThickness = 1
        Me.btOperacion.ActiveCornerRadius = 20
        Me.btOperacion.ActiveFillColor = System.Drawing.SystemColors.HotTrack
        Me.btOperacion.ActiveForecolor = System.Drawing.Color.White
        Me.btOperacion.ActiveLineColor = System.Drawing.SystemColors.HotTrack
        Me.btOperacion.BackColor = System.Drawing.Color.Transparent
        Me.btOperacion.BackgroundImage = CType(resources.GetObject("btOperacion.BackgroundImage"), System.Drawing.Image)
        Me.btOperacion.ButtonText = "Aceptar"
        Me.btOperacion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btOperacion.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btOperacion.ForeColor = System.Drawing.Color.Black
        Me.btOperacion.IdleBorderThickness = 1
        Me.btOperacion.IdleCornerRadius = 20
        Me.btOperacion.IdleFillColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.btOperacion.IdleForecolor = System.Drawing.Color.White
        Me.btOperacion.IdleLineColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.btOperacion.Location = New System.Drawing.Point(250, 1)
        Me.btOperacion.Margin = New System.Windows.Forms.Padding(5)
        Me.btOperacion.Name = "btOperacion"
        Me.btOperacion.Size = New System.Drawing.Size(123, 45)
        Me.btOperacion.TabIndex = 679
        Me.btOperacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pcLikeCategoria
        '
        Me.pcLikeCategoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pcLikeCategoria.Controls.Add(Me.lsvCategoria)
        Me.pcLikeCategoria.Controls.Add(Me.ButtonAdv3)
        Me.pcLikeCategoria.Controls.Add(Me.ButtonAdv10)
        Me.pcLikeCategoria.Location = New System.Drawing.Point(27, 73)
        Me.pcLikeCategoria.Name = "pcLikeCategoria"
        Me.pcLikeCategoria.Size = New System.Drawing.Size(193, 80)
        Me.pcLikeCategoria.TabIndex = 490
        Me.pcLikeCategoria.Visible = False
        '
        'lsvCategoria
        '
        Me.lsvCategoria.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lsvCategoria.Dock = System.Windows.Forms.DockStyle.Top
        Me.lsvCategoria.FormattingEnabled = True
        Me.lsvCategoria.Location = New System.Drawing.Point(0, 0)
        Me.lsvCategoria.Name = "lsvCategoria"
        Me.lsvCategoria.Size = New System.Drawing.Size(191, 104)
        Me.lsvCategoria.TabIndex = 3
        '
        'ButtonAdv3
        '
        Me.ButtonAdv3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonAdv3.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv3.BackColor = System.Drawing.SystemColors.Highlight
        Me.ButtonAdv3.BeforeTouchSize = New System.Drawing.Size(171, 42)
        Me.ButtonAdv3.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv3.IsBackStageButton = False
        Me.ButtonAdv3.Location = New System.Drawing.Point(59, 110)
        Me.ButtonAdv3.Name = "ButtonAdv3"
        Me.ButtonAdv3.Size = New System.Drawing.Size(171, 42)
        Me.ButtonAdv3.TabIndex = 2
        Me.ButtonAdv3.Text = "Cancel"
        Me.ButtonAdv3.UseVisualStyle = True
        '
        'ButtonAdv10
        '
        Me.ButtonAdv10.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonAdv10.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv10.BackColor = System.Drawing.SystemColors.Highlight
        Me.ButtonAdv10.BeforeTouchSize = New System.Drawing.Size(171, 42)
        Me.ButtonAdv10.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv10.IsBackStageButton = False
        Me.ButtonAdv10.Location = New System.Drawing.Point(3, 110)
        Me.ButtonAdv10.Name = "ButtonAdv10"
        Me.ButtonAdv10.Size = New System.Drawing.Size(171, 42)
        Me.ButtonAdv10.TabIndex = 1
        Me.ButtonAdv10.Text = "OK"
        Me.ButtonAdv10.UseVisualStyle = True
        '
        'pcSubCategoria
        '
        Me.pcSubCategoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pcSubCategoria.Controls.Add(Me.lsvSubCategoria)
        Me.pcSubCategoria.Controls.Add(Me.ButtonAdv11)
        Me.pcSubCategoria.Controls.Add(Me.ButtonAdv12)
        Me.pcSubCategoria.Location = New System.Drawing.Point(134, 55)
        Me.pcSubCategoria.Name = "pcSubCategoria"
        Me.pcSubCategoria.Size = New System.Drawing.Size(193, 80)
        Me.pcSubCategoria.TabIndex = 491
        Me.pcSubCategoria.Visible = False
        '
        'lsvSubCategoria
        '
        Me.lsvSubCategoria.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lsvSubCategoria.Dock = System.Windows.Forms.DockStyle.Top
        Me.lsvSubCategoria.FormattingEnabled = True
        Me.lsvSubCategoria.Location = New System.Drawing.Point(0, 0)
        Me.lsvSubCategoria.Name = "lsvSubCategoria"
        Me.lsvSubCategoria.Size = New System.Drawing.Size(191, 104)
        Me.lsvSubCategoria.TabIndex = 3
        '
        'ButtonAdv11
        '
        Me.ButtonAdv11.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonAdv11.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv11.BackColor = System.Drawing.SystemColors.Highlight
        Me.ButtonAdv11.BeforeTouchSize = New System.Drawing.Size(171, 42)
        Me.ButtonAdv11.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv11.IsBackStageButton = False
        Me.ButtonAdv11.Location = New System.Drawing.Point(59, 110)
        Me.ButtonAdv11.Name = "ButtonAdv11"
        Me.ButtonAdv11.Size = New System.Drawing.Size(171, 42)
        Me.ButtonAdv11.TabIndex = 2
        Me.ButtonAdv11.Text = "Cancel"
        Me.ButtonAdv11.UseVisualStyle = True
        '
        'ButtonAdv12
        '
        Me.ButtonAdv12.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonAdv12.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv12.BackColor = System.Drawing.SystemColors.Highlight
        Me.ButtonAdv12.BeforeTouchSize = New System.Drawing.Size(171, 42)
        Me.ButtonAdv12.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv12.IsBackStageButton = False
        Me.ButtonAdv12.Location = New System.Drawing.Point(3, 110)
        Me.ButtonAdv12.Name = "ButtonAdv12"
        Me.ButtonAdv12.Size = New System.Drawing.Size(171, 42)
        Me.ButtonAdv12.TabIndex = 1
        Me.ButtonAdv12.Text = "OK"
        Me.ButtonAdv12.UseVisualStyle = True
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.GradientPanel1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.GradientPanel1.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.BunifuFlatButton2)
        Me.GradientPanel1.Controls.Add(Me.BunifuFlatButton1)
        Me.GradientPanel1.Controls.Add(Me.BunifuFlatButton15)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(627, 36)
        Me.GradientPanel1.TabIndex = 431
        '
        'BunifuFlatButton2
        '
        Me.BunifuFlatButton2.Activecolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.BunifuFlatButton2.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.BunifuFlatButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton2.BorderRadius = 0
        Me.BunifuFlatButton2.ButtonText = "COMPONENTES KIT"
        Me.BunifuFlatButton2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton2.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton2.Font = New System.Drawing.Font("Segoe UI", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton2.ForeColor = System.Drawing.Color.White
        Me.BunifuFlatButton2.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton2.Iconimage = Nothing
        Me.BunifuFlatButton2.Iconimage_right = Nothing
        Me.BunifuFlatButton2.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton2.Iconimage_Selected = Nothing
        Me.BunifuFlatButton2.IconMarginLeft = 0
        Me.BunifuFlatButton2.IconMarginRight = 0
        Me.BunifuFlatButton2.IconRightVisible = True
        Me.BunifuFlatButton2.IconRightZoom = 0R
        Me.BunifuFlatButton2.IconVisible = True
        Me.BunifuFlatButton2.IconZoom = 90.0R
        Me.BunifuFlatButton2.IsTab = False
        Me.BunifuFlatButton2.Location = New System.Drawing.Point(335, 12)
        Me.BunifuFlatButton2.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton2.Name = "BunifuFlatButton2"
        Me.BunifuFlatButton2.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.BunifuFlatButton2.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.BunifuFlatButton2.OnHoverTextColor = System.Drawing.Color.WhiteSmoke
        Me.BunifuFlatButton2.selected = False
        Me.BunifuFlatButton2.Size = New System.Drawing.Size(127, 16)
        Me.BunifuFlatButton2.TabIndex = 24
        Me.BunifuFlatButton2.Text = "COMPONENTES KIT"
        Me.BunifuFlatButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton2.Textcolor = System.Drawing.Color.White
        Me.BunifuFlatButton2.TextFont = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton2.Visible = False
        '
        'BunifuFlatButton1
        '
        Me.BunifuFlatButton1.Activecolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.BunifuFlatButton1.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.BunifuFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton1.BorderRadius = 0
        Me.BunifuFlatButton1.ButtonText = "UNIDAD COMERCIAL"
        Me.BunifuFlatButton1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton1.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton1.Font = New System.Drawing.Font("Segoe UI", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton1.ForeColor = System.Drawing.Color.White
        Me.BunifuFlatButton1.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton1.Iconimage = Nothing
        Me.BunifuFlatButton1.Iconimage_right = Nothing
        Me.BunifuFlatButton1.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton1.Iconimage_Selected = Nothing
        Me.BunifuFlatButton1.IconMarginLeft = 0
        Me.BunifuFlatButton1.IconMarginRight = 0
        Me.BunifuFlatButton1.IconRightVisible = True
        Me.BunifuFlatButton1.IconRightZoom = 0R
        Me.BunifuFlatButton1.IconVisible = True
        Me.BunifuFlatButton1.IconZoom = 90.0R
        Me.BunifuFlatButton1.IsTab = False
        Me.BunifuFlatButton1.Location = New System.Drawing.Point(185, 12)
        Me.BunifuFlatButton1.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton1.Name = "BunifuFlatButton1"
        Me.BunifuFlatButton1.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.BunifuFlatButton1.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.BunifuFlatButton1.OnHoverTextColor = System.Drawing.Color.WhiteSmoke
        Me.BunifuFlatButton1.selected = False
        Me.BunifuFlatButton1.Size = New System.Drawing.Size(147, 16)
        Me.BunifuFlatButton1.TabIndex = 23
        Me.BunifuFlatButton1.Text = "UNIDAD COMERCIAL"
        Me.BunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton1.Textcolor = System.Drawing.Color.White
        Me.BunifuFlatButton1.TextFont = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'BunifuFlatButton15
        '
        Me.BunifuFlatButton15.Activecolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.BunifuFlatButton15.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.BunifuFlatButton15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton15.BorderRadius = 0
        Me.BunifuFlatButton15.ButtonText = "INFORMACION GENERAL"
        Me.BunifuFlatButton15.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton15.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton15.Font = New System.Drawing.Font("Segoe UI", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton15.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BunifuFlatButton15.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton15.Iconimage = Nothing
        Me.BunifuFlatButton15.Iconimage_right = Nothing
        Me.BunifuFlatButton15.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton15.Iconimage_Selected = Nothing
        Me.BunifuFlatButton15.IconMarginLeft = 0
        Me.BunifuFlatButton15.IconMarginRight = 0
        Me.BunifuFlatButton15.IconRightVisible = True
        Me.BunifuFlatButton15.IconRightZoom = 0R
        Me.BunifuFlatButton15.IconVisible = True
        Me.BunifuFlatButton15.IconZoom = 90.0R
        Me.BunifuFlatButton15.IsTab = False
        Me.BunifuFlatButton15.Location = New System.Drawing.Point(19, 12)
        Me.BunifuFlatButton15.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton15.Name = "BunifuFlatButton15"
        Me.BunifuFlatButton15.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.BunifuFlatButton15.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.BunifuFlatButton15.OnHoverTextColor = System.Drawing.Color.WhiteSmoke
        Me.BunifuFlatButton15.selected = False
        Me.BunifuFlatButton15.Size = New System.Drawing.Size(164, 16)
        Me.BunifuFlatButton15.TabIndex = 22
        Me.BunifuFlatButton15.Text = "INFORMACION GENERAL"
        Me.BunifuFlatButton15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton15.Textcolor = System.Drawing.Color.WhiteSmoke
        Me.BunifuFlatButton15.TextFont = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtValorPercepcion)
        Me.GroupBox1.Controls.Add(Me.txtValorRetencion)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.ChVenta)
        Me.GroupBox1.Controls.Add(Me.ChCompra)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.ChPercepcion)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.ChRetencion)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(982, 24)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(272, 130)
        Me.GroupBox1.TabIndex = 439
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Afecto a recaudación"
        Me.GroupBox1.Visible = False
        '
        'txtValorPercepcion
        '
        Me.txtValorPercepcion.BackGroundColor = System.Drawing.Color.White
        Me.txtValorPercepcion.BeforeTouchSize = New System.Drawing.Size(257, 22)
        Me.txtValorPercepcion.BorderColor = System.Drawing.Color.Gray
        Me.txtValorPercepcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtValorPercepcion.CornerRadius = 3
        Me.txtValorPercepcion.CurrencySymbol = "% "
        Me.txtValorPercepcion.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtValorPercepcion.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtValorPercepcion.Enabled = False
        Me.txtValorPercepcion.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValorPercepcion.ForeColor = System.Drawing.Color.Black
        Me.txtValorPercepcion.Location = New System.Drawing.Point(148, 50)
        Me.txtValorPercepcion.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtValorPercepcion.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtValorPercepcion.Name = "txtValorPercepcion"
        Me.txtValorPercepcion.NullString = ""
        Me.txtValorPercepcion.PositiveColor = System.Drawing.Color.Black
        Me.txtValorPercepcion.ReadOnlyBackColor = System.Drawing.Color.White
        Me.txtValorPercepcion.Size = New System.Drawing.Size(77, 22)
        Me.txtValorPercepcion.TabIndex = 497
        Me.txtValorPercepcion.Text = "% 0.00"
        Me.txtValorPercepcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtValorRetencion
        '
        Me.txtValorRetencion.BackGroundColor = System.Drawing.Color.White
        Me.txtValorRetencion.BeforeTouchSize = New System.Drawing.Size(257, 22)
        Me.txtValorRetencion.BorderColor = System.Drawing.Color.Gray
        Me.txtValorRetencion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtValorRetencion.CornerRadius = 3
        Me.txtValorRetencion.CurrencySymbol = "% "
        Me.txtValorRetencion.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtValorRetencion.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtValorRetencion.Enabled = False
        Me.txtValorRetencion.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValorRetencion.ForeColor = System.Drawing.Color.Black
        Me.txtValorRetencion.Location = New System.Drawing.Point(21, 50)
        Me.txtValorRetencion.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtValorRetencion.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtValorRetencion.Name = "txtValorRetencion"
        Me.txtValorRetencion.NullString = ""
        Me.txtValorRetencion.PositiveColor = System.Drawing.Color.Black
        Me.txtValorRetencion.ReadOnlyBackColor = System.Drawing.Color.White
        Me.txtValorRetencion.Size = New System.Drawing.Size(77, 22)
        Me.txtValorRetencion.TabIndex = 496
        Me.txtValorRetencion.Text = "% 0.00"
        Me.txtValorRetencion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(172, 94)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(78, 14)
        Me.Label15.TabIndex = 446
        Me.Label15.Text = "Afecto a venta"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(44, 94)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(88, 14)
        Me.Label12.TabIndex = 445
        Me.Label12.Text = "Afecto a compra"
        '
        'ChVenta
        '
        Me.ChVenta.BackColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.ChVenta.ChechedOffColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.ChVenta.Checked = False
        Me.ChVenta.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.ChVenta.Enabled = False
        Me.ChVenta.ForeColor = System.Drawing.Color.White
        Me.ChVenta.Location = New System.Drawing.Point(148, 91)
        Me.ChVenta.Name = "ChVenta"
        Me.ChVenta.Size = New System.Drawing.Size(20, 20)
        Me.ChVenta.TabIndex = 444
        '
        'ChCompra
        '
        Me.ChCompra.BackColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.ChCompra.ChechedOffColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.ChCompra.Checked = False
        Me.ChCompra.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.ChCompra.Enabled = False
        Me.ChCompra.ForeColor = System.Drawing.Color.White
        Me.ChCompra.Location = New System.Drawing.Point(21, 91)
        Me.ChCompra.Name = "ChCompra"
        Me.ChCompra.Size = New System.Drawing.Size(20, 20)
        Me.ChCompra.TabIndex = 442
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(172, 28)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(60, 14)
        Me.Label14.TabIndex = 441
        Me.Label14.Text = "Percepción"
        '
        'ChPercepcion
        '
        Me.ChPercepcion.BackColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.ChPercepcion.ChechedOffColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.ChPercepcion.Checked = False
        Me.ChPercepcion.CheckedOnColor = System.Drawing.SystemColors.HotTrack
        Me.ChPercepcion.ForeColor = System.Drawing.Color.White
        Me.ChPercepcion.Location = New System.Drawing.Point(148, 24)
        Me.ChPercepcion.Name = "ChPercepcion"
        Me.ChPercepcion.Size = New System.Drawing.Size(20, 20)
        Me.ChPercepcion.TabIndex = 440
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(44, 28)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(55, 14)
        Me.Label13.TabIndex = 439
        Me.Label13.Text = "Retención"
        '
        'ChRetencion
        '
        Me.ChRetencion.BackColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.ChRetencion.ChechedOffColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.ChRetencion.Checked = False
        Me.ChRetencion.CheckedOnColor = System.Drawing.SystemColors.HotTrack
        Me.ChRetencion.ForeColor = System.Drawing.Color.White
        Me.ChRetencion.Location = New System.Drawing.Point(21, 24)
        Me.ChRetencion.Name = "ChRetencion"
        Me.ChRetencion.Size = New System.Drawing.Size(20, 20)
        Me.ChRetencion.TabIndex = 438
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(31, 303)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 438
        Me.Label2.Text = "IVA."
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.DimGray
        Me.Label11.Location = New System.Drawing.Point(792, 372)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(94, 13)
        Me.Label11.TabIndex = 436
        Me.Label11.Text = "Cantidad mínima"
        Me.Label11.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DimGray
        Me.Label4.Location = New System.Drawing.Point(889, 372)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 13)
        Me.Label4.TabIndex = 437
        Me.Label4.Text = "Cantidad máxima"
        Me.Label4.Visible = False
        '
        'PanelBody
        '
        Me.PanelBody.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.PanelBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelBody.Location = New System.Drawing.Point(0, 36)
        Me.PanelBody.Name = "PanelBody"
        Me.PanelBody.Size = New System.Drawing.Size(627, 517)
        Me.PanelBody.TabIndex = 502
        '
        'sliderTop
        '
        Me.sliderTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.sliderTop.Location = New System.Drawing.Point(19, 32)
        Me.sliderTop.Name = "sliderTop"
        Me.sliderTop.Size = New System.Drawing.Size(164, 4)
        Me.sliderTop.TabIndex = 501
        Me.sliderTop.TabStop = False
        '
        'frmNuevaExistencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.BorderColor = System.Drawing.Color.DimGray
        Me.BorderThickness = 2
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.CaptionBarHeight = 35
        Me.CaptionButtonColor = System.Drawing.Color.White
        Me.CaptionButtonHoverColor = System.Drawing.Color.White
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.ForeColor = System.Drawing.Color.WhiteSmoke
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(15, 12)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(20, 20)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.White
        CaptionLabel1.Location = New System.Drawing.Point(45, 9)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(200, 24)
        CaptionLabel1.Text = "Administración de existencias"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(627, 598)
        Me.Controls.Add(Me.PanelBody)
        Me.Controls.Add(Me.sliderTop)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.GradientPanel2)
        Me.Controls.Add(Me.nudCantMin)
        Me.Controls.Add(Me.nudCantMax)
        Me.Controls.Add(Me.pcMercaderia)
        Me.Controls.Add(Me.pcClasificacion)
        Me.Controls.Add(Me.PopupControlContainer2)
        Me.Controls.Add(Me.ButtonAdv5)
        Me.Controls.Add(Me.ButtonAdv4)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmNuevaExistencia"
        Me.ShowIcon = False
        Me.ShowMaximizeBox = False
        Me.ShowMinimizeBox = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = ""
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.AutoComplete1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AutoComplete2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PopupControlContainer2.ResumeLayout(False)
        Me.pcClasificacion.ResumeLayout(False)
        Me.pcClasificacion.PerformLayout()
        Me.Panel16.ResumeLayout(False)
        CType(Me.txtNewClasificacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pcMercaderia.ResumeLayout(False)
        CType(Me.nudCantMax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudCantMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        Me.pcLikeCategoria.ResumeLayout(False)
        Me.pcSubCategoria.ResumeLayout(False)
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtValorPercepcion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValorRetencion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sliderTop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonAdv5 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents ButtonAdv4 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents lblEstado As System.Windows.Forms.ToolStripButton
    Friend WithEvents AutoComplete1 As Syncfusion.Windows.Forms.Tools.AutoComplete
    Friend WithEvents AutoComplete2 As Syncfusion.Windows.Forms.Tools.AutoComplete
    Private WithEvents PopupControlContainer2 As Syncfusion.Windows.Forms.PopupControlContainer
    Friend WithEvents lstCategoria As System.Windows.Forms.ListBox
    Private WithEvents pcClasificacion As Syncfusion.Windows.Forms.PopupControlContainer
    Private WithEvents Panel16 As System.Windows.Forms.Panel
    Private WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents txtNewClasificacion As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Private WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Private WithEvents btmGrabarClasificacion As Syncfusion.Windows.Forms.ButtonAdv
    Private WithEvents pcMercaderia As Syncfusion.Windows.Forms.PopupControlContainer
    Friend WithEvents lstProductos As System.Windows.Forms.ListBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents nudCantMin As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudCantMax As System.Windows.Forms.NumericUpDown
    Friend WithEvents GradientPanel2 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents pcSubCategoria As Syncfusion.Windows.Forms.PopupControlContainer
    Friend WithEvents lsvSubCategoria As System.Windows.Forms.ListBox
    Private WithEvents ButtonAdv11 As Syncfusion.Windows.Forms.ButtonAdv
    Private WithEvents ButtonAdv12 As Syncfusion.Windows.Forms.ButtonAdv
    Private WithEvents pcLikeCategoria As Syncfusion.Windows.Forms.PopupControlContainer
    Friend WithEvents lsvCategoria As System.Windows.Forms.ListBox
    Private WithEvents ButtonAdv3 As Syncfusion.Windows.Forms.ButtonAdv
    Private WithEvents ButtonAdv10 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents BannerTextProvider1 As Syncfusion.Windows.Forms.BannerTextProvider
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label14 As Label
    Friend WithEvents ChPercepcion As Bunifu.Framework.UI.BunifuCheckbox
    Friend WithEvents Label13 As Label
    Friend WithEvents ChRetencion As Bunifu.Framework.UI.BunifuCheckbox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents ChVenta As Bunifu.Framework.UI.BunifuCheckbox
    Friend WithEvents ChCompra As Bunifu.Framework.UI.BunifuCheckbox
    Friend WithEvents txtValorPercepcion As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtValorRetencion As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Private WithEvents sliderTop As PictureBox
    Private WithEvents BunifuFlatButton15 As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents BunifuFlatButton1 As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents PanelBody As Panel
    Friend WithEvents btOperacion As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents BunifuFlatButton2 As Bunifu.Framework.UI.BunifuFlatButton
End Class

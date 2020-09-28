<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModalCajaApertura
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmModalCajaApertura))
        Dim MetroColorTable1 As Syncfusion.Windows.Forms.MetroColorTable = New Syncfusion.Windows.Forms.MetroColorTable()
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.ToolStrip5 = New System.Windows.Forms.ToolStrip()
        Me.btGrabar = New System.Windows.Forms.ToolStripButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtTipoCambio = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.lbltipoCambio = New System.Windows.Forms.Label()
        Me.txtBalanceInicialme = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.lblBalanceME = New System.Windows.Forms.Label()
        Me.txtCodigoCuenta = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.cboCuenta = New Syncfusion.Windows.Forms.Tools.MultiColumnComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtFecha = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtBalanceInicial = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNumCuentaCorriente = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboTipoCuenta = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.cboMoneda = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDescripcion = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboBanco = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel7.SuspendLayout()
        Me.ToolStrip5.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.txtTipoCambio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBalanceInicialme, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodigoCuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBalanceInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumCuentaCorriente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTipoCuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescripcion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboBanco, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.ToolStrip5)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(576, 45)
        Me.Panel7.TabIndex = 424
        '
        'ToolStrip5
        '
        Me.ToolStrip5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ToolStrip5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStrip5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip5.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip5.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btGrabar})
        Me.ToolStrip5.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip5.Name = "ToolStrip5"
        Me.ToolStrip5.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip5.Size = New System.Drawing.Size(576, 45)
        Me.ToolStrip5.TabIndex = 2
        Me.ToolStrip5.Text = "ToolStrip5"
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
        Me.btGrabar.Text = "Guardar compra"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtTipoCambio)
        Me.Panel1.Controls.Add(Me.lbltipoCambio)
        Me.Panel1.Controls.Add(Me.txtBalanceInicialme)
        Me.Panel1.Controls.Add(Me.lblBalanceME)
        Me.Panel1.Controls.Add(Me.txtCodigoCuenta)
        Me.Panel1.Controls.Add(Me.cboCuenta)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.txtFecha)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtBalanceInicial)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtNumCuentaCorriente)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.cboTipoCuenta)
        Me.Panel1.Controls.Add(Me.cboMoneda)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.txtDescripcion)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.cboBanco)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 45)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(576, 304)
        Me.Panel1.TabIndex = 425
        Me.Panel1.Text = "QRibbonCaption1"
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtTipoCambio.BeforeTouchSize = New System.Drawing.Size(141, 20)
        Me.txtTipoCambio.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTipoCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTipoCambio.CurrencyDecimalDigits = 3
        Me.txtTipoCambio.CurrencySymbol = ""
        Me.txtTipoCambio.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTipoCambio.DecimalValue = New Decimal(New Integer() {1000, 0, 0, 196608})
        Me.txtTipoCambio.Location = New System.Drawing.Point(161, 258)
        Me.txtTipoCambio.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.NullString = ""
        Me.txtTipoCambio.Size = New System.Drawing.Size(63, 20)
        Me.txtTipoCambio.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtTipoCambio.TabIndex = 489
        Me.txtTipoCambio.Text = "1.000"
        '
        'lbltipoCambio
        '
        Me.lbltipoCambio.AutoSize = True
        Me.lbltipoCambio.Font = New System.Drawing.Font("Arial", 6.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltipoCambio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbltipoCambio.Location = New System.Drawing.Point(159, 237)
        Me.lbltipoCambio.Name = "lbltipoCambio"
        Me.lbltipoCambio.Size = New System.Drawing.Size(23, 11)
        Me.lbltipoCambio.TabIndex = 488
        Me.lbltipoCambio.Text = "T/C."
        '
        'txtBalanceInicialme
        '
        Me.txtBalanceInicialme.BackGroundColor = System.Drawing.Color.MediumSeaGreen
        Me.txtBalanceInicialme.BeforeTouchSize = New System.Drawing.Size(141, 20)
        Me.txtBalanceInicialme.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtBalanceInicialme.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBalanceInicialme.CurrencySymbol = ""
        Me.txtBalanceInicialme.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBalanceInicialme.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtBalanceInicialme.ForeColor = System.Drawing.Color.White
        Me.txtBalanceInicialme.Location = New System.Drawing.Point(230, 258)
        Me.txtBalanceInicialme.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtBalanceInicialme.Name = "txtBalanceInicialme"
        Me.txtBalanceInicialme.NullString = ""
        Me.txtBalanceInicialme.PositiveColor = System.Drawing.Color.White
        Me.txtBalanceInicialme.Size = New System.Drawing.Size(141, 20)
        Me.txtBalanceInicialme.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtBalanceInicialme.TabIndex = 487
        Me.txtBalanceInicialme.Text = "0.00"
        '
        'lblBalanceME
        '
        Me.lblBalanceME.AutoSize = True
        Me.lblBalanceME.Font = New System.Drawing.Font("Arial", 6.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBalanceME.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblBalanceME.Location = New System.Drawing.Point(230, 237)
        Me.lblBalanceME.Name = "lblBalanceME"
        Me.lblBalanceME.Size = New System.Drawing.Size(104, 11)
        Me.lblBalanceME.TabIndex = 486
        Me.lblBalanceME.Text = "BALANCE INICIAL ME."
        '
        'txtCodigoCuenta
        '
        Me.txtCodigoCuenta.BackColor = System.Drawing.Color.White
        Me.txtCodigoCuenta.BeforeTouchSize = New System.Drawing.Size(141, 20)
        Me.txtCodigoCuenta.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtCodigoCuenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigoCuenta.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCodigoCuenta.Location = New System.Drawing.Point(314, 196)
        Me.txtCodigoCuenta.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtCodigoCuenta.Name = "txtCodigoCuenta"
        Me.txtCodigoCuenta.Size = New System.Drawing.Size(89, 20)
        Me.txtCodigoCuenta.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtCodigoCuenta.TabIndex = 485
        Me.txtCodigoCuenta.Text = "101"
        '
        'cboCuenta
        '
        Me.cboCuenta.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.cboCuenta.BackColor = System.Drawing.Color.White
        Me.cboCuenta.BeforeTouchSize = New System.Drawing.Size(294, 21)
        Me.cboCuenta.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCuenta.Location = New System.Drawing.Point(14, 196)
        Me.cboCuenta.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.cboCuenta.Name = "cboCuenta"
        MetroColorTable1.ArrowChecked = System.Drawing.Color.FromArgb(CType(CType(147, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(152, Byte), Integer))
        MetroColorTable1.ArrowInActive = System.Drawing.Color.White
        MetroColorTable1.ArrowNormal = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(198, Byte), Integer))
        MetroColorTable1.ArrowNormalBackGround = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(198, Byte), Integer))
        MetroColorTable1.ArrowPushed = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(90, Byte), Integer))
        MetroColorTable1.ArrowPushedBackGround = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(90, Byte), Integer))
        MetroColorTable1.ScrollerBackground = System.Drawing.Color.White
        MetroColorTable1.ThumbChecked = System.Drawing.Color.FromArgb(CType(CType(147, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(152, Byte), Integer))
        MetroColorTable1.ThumbInActive = System.Drawing.Color.White
        MetroColorTable1.ThumbNormal = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(198, Byte), Integer))
        MetroColorTable1.ThumbPushed = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(90, Byte), Integer))
        MetroColorTable1.ThumbPushedBorder = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.cboCuenta.ScrollMetroColorTable = MetroColorTable1
        Me.cboCuenta.Size = New System.Drawing.Size(294, 21)
        Me.cboCuenta.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboCuenta.TabIndex = 484
        Me.cboCuenta.Text = "Selecione una cuenta contable"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 6.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(14, 178)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(93, 11)
        Me.Label9.TabIndex = 483
        Me.Label9.Text = "CUENTA CONTABLE"
        '
        'txtFecha
        '
        Me.txtFecha.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtFecha.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtFecha.Calendar.AllowMultipleSelection = False
        Me.txtFecha.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFecha.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFecha.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFecha.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecha.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFecha.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtFecha.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFecha.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFecha.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtFecha.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtFecha.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtFecha.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtFecha.Calendar.Iso8601CalenderFormat = False
        Me.txtFecha.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtFecha.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecha.Calendar.Name = "monthCalendar"
        Me.txtFecha.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtFecha.Calendar.SelectedDates = New Date(-1) {}
        Me.txtFecha.Calendar.Size = New System.Drawing.Size(161, 174)
        Me.txtFecha.Calendar.SizeToFit = True
        Me.txtFecha.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFecha.Calendar.TabIndex = 0
        Me.txtFecha.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtFecha.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFecha.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecha.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFecha.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtFecha.Calendar.NoneButton.IsBackStageButton = False
        Me.txtFecha.Calendar.NoneButton.Location = New System.Drawing.Point(89, 0)
        Me.txtFecha.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtFecha.Calendar.NoneButton.Text = "None"
        Me.txtFecha.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtFecha.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFecha.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecha.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFecha.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtFecha.Calendar.TodayButton.IsBackStageButton = False
        Me.txtFecha.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtFecha.Calendar.TodayButton.Size = New System.Drawing.Size(89, 20)
        Me.txtFecha.Calendar.TodayButton.Text = "Today"
        Me.txtFecha.Calendar.TodayButton.UseVisualStyle = True
        Me.txtFecha.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtFecha.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFecha.CustomFormat = "dd/MM/yyyy HH:mm tt"
        Me.txtFecha.DropDownImage = Nothing
        Me.txtFecha.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecha.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecha.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFecha.Location = New System.Drawing.Point(398, 258)
        Me.txtFecha.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecha.MinValue = New Date(CType(0, Long))
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ShowCheckBox = False
        Me.txtFecha.Size = New System.Drawing.Size(165, 20)
        Me.txtFecha.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFecha.TabIndex = 482
        Me.txtFecha.Value = New Date(2016, 1, 11, 17, 2, 53, 38)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 6.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(397, 237)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 11)
        Me.Label3.TabIndex = 481
        Me.Label3.Text = "FECHA BALANCE"
        '
        'txtBalanceInicial
        '
        Me.txtBalanceInicial.BackGroundColor = System.Drawing.SystemColors.HotTrack
        Me.txtBalanceInicial.BeforeTouchSize = New System.Drawing.Size(141, 20)
        Me.txtBalanceInicial.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtBalanceInicial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBalanceInicial.CurrencySymbol = ""
        Me.txtBalanceInicial.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBalanceInicial.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtBalanceInicial.ForeColor = System.Drawing.Color.White
        Me.txtBalanceInicial.Location = New System.Drawing.Point(14, 258)
        Me.txtBalanceInicial.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtBalanceInicial.Name = "txtBalanceInicial"
        Me.txtBalanceInicial.NullString = ""
        Me.txtBalanceInicial.PositiveColor = System.Drawing.Color.White
        Me.txtBalanceInicial.Size = New System.Drawing.Size(141, 20)
        Me.txtBalanceInicial.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtBalanceInicial.TabIndex = 480
        Me.txtBalanceInicial.Text = "0.00"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 6.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(14, 237)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 11)
        Me.Label2.TabIndex = 479
        Me.Label2.Text = "BALANCE INICIAL MN."
        '
        'txtNumCuentaCorriente
        '
        Me.txtNumCuentaCorriente.BackColor = System.Drawing.Color.White
        Me.txtNumCuentaCorriente.BeforeTouchSize = New System.Drawing.Size(141, 20)
        Me.txtNumCuentaCorriente.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtNumCuentaCorriente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumCuentaCorriente.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNumCuentaCorriente.Location = New System.Drawing.Point(16, 148)
        Me.txtNumCuentaCorriente.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtNumCuentaCorriente.Name = "txtNumCuentaCorriente"
        Me.txtNumCuentaCorriente.NearImage = CType(resources.GetObject("txtNumCuentaCorriente.NearImage"), System.Drawing.Image)
        Me.txtNumCuentaCorriente.Size = New System.Drawing.Size(259, 20)
        Me.txtNumCuentaCorriente.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtNumCuentaCorriente.TabIndex = 478
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 6.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(14, 129)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 11)
        Me.Label8.TabIndex = 477
        Me.Label8.Text = "NO. CUENTA"
        '
        'cboTipoCuenta
        '
        Me.cboTipoCuenta.BackColor = System.Drawing.Color.White
        Me.cboTipoCuenta.BeforeTouchSize = New System.Drawing.Size(261, 21)
        Me.cboTipoCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoCuenta.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoCuenta.Items.AddRange(New Object() {"Banco", "Efectivo", "Tarjeta de Crédito"})
        Me.cboTipoCuenta.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboTipoCuenta, "Banco"))
        Me.cboTipoCuenta.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboTipoCuenta, "Efectivo"))
        Me.cboTipoCuenta.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboTipoCuenta, "Tarjeta de Crédito"))
        Me.cboTipoCuenta.Location = New System.Drawing.Point(14, 48)
        Me.cboTipoCuenta.Name = "cboTipoCuenta"
        Me.cboTipoCuenta.Size = New System.Drawing.Size(261, 21)
        Me.cboTipoCuenta.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboTipoCuenta.TabIndex = 476
        Me.cboTipoCuenta.Text = "Banco"
        '
        'cboMoneda
        '
        Me.cboMoneda.BackColor = System.Drawing.Color.White
        Me.cboMoneda.BeforeTouchSize = New System.Drawing.Size(261, 21)
        Me.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMoneda.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMoneda.Items.AddRange(New Object() {"MONEDA NACIONAL", "MONEDA EXTRANJERA"})
        Me.cboMoneda.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboMoneda, "MONEDA NACIONAL"))
        Me.cboMoneda.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboMoneda, "MONEDA EXTRANJERA"))
        Me.cboMoneda.Location = New System.Drawing.Point(302, 147)
        Me.cboMoneda.Name = "cboMoneda"
        Me.cboMoneda.Size = New System.Drawing.Size(261, 21)
        Me.cboMoneda.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboMoneda.TabIndex = 475
        Me.cboMoneda.Text = "MONEDA NACIONAL"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 6.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(300, 127)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 11)
        Me.Label7.TabIndex = 474
        Me.Label7.Text = "MONEDA"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.BackColor = System.Drawing.Color.White
        Me.txtDescripcion.BeforeTouchSize = New System.Drawing.Size(141, 20)
        Me.txtDescripcion.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDescripcion.Location = New System.Drawing.Point(302, 98)
        Me.txtDescripcion.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(261, 20)
        Me.txtDescripcion.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtDescripcion.TabIndex = 473
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 6.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(300, 78)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 11)
        Me.Label6.TabIndex = 472
        Me.Label6.Text = "DESCRIPCION"
        '
        'cboBanco
        '
        Me.cboBanco.BackColor = System.Drawing.Color.White
        Me.cboBanco.BeforeTouchSize = New System.Drawing.Size(259, 21)
        Me.cboBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBanco.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBanco.Location = New System.Drawing.Point(16, 98)
        Me.cboBanco.Name = "cboBanco"
        Me.cboBanco.Size = New System.Drawing.Size(259, 21)
        Me.cboBanco.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboBanco.TabIndex = 471
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 6.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(14, 78)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(146, 11)
        Me.Label5.TabIndex = 470
        Me.Label5.Text = "BANCO - ENTIDAD FINANCIERA"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 6.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(14, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 11)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "CUENTA"
        '
        'frmModalCajaApertura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.Color.White
        Me.CaptionBarHeight = 50
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(20, 9)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(30, 30)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        CaptionLabel1.Location = New System.Drawing.Point(53, 10)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(250, 24)
        CaptionLabel1.Text = "Entidad Financiera de Apertura"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(576, 349)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel7)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmModalCajaApertura"
        Me.ShowIcon = False
        Me.Text = ""
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.ToolStrip5.ResumeLayout(False)
        Me.ToolStrip5.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.txtTipoCambio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBalanceInicialme, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodigoCuenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCuenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBalanceInicial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumCuentaCorriente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTipoCuenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescripcion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboBanco, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents ToolStrip5 As System.Windows.Forms.ToolStrip
    Friend WithEvents btGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtCodigoCuenta As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents cboCuenta As Syncfusion.Windows.Forms.Tools.MultiColumnComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtFecha As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtBalanceInicial As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNumCuentaCorriente As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboTipoCuenta As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents cboMoneda As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboBanco As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtBalanceInicialme As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents lblBalanceME As System.Windows.Forms.Label
    Friend WithEvents txtTipoCambio As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents lbltipoCambio As System.Windows.Forms.Label
End Class

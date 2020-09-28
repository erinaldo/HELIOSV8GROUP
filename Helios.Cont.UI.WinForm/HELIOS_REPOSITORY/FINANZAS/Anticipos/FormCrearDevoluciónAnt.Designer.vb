Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormCrearDevoluciónAnt
    Inherits MetroForm

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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCrearDevoluciónAnt))
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor6 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor7 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor8 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridSummaryRowDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor()
        Dim GridSummaryColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor()
        Me.ButtonSalir = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.TextRuc = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.ButtonGrabar = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TextPersona = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.textFecha = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.ComboCaja = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.TextCodigoVendedor = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.PanelMontos = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.GradientPanel5 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.GradientPanel6 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.txtTotalPagar = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.GradientPanel4 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.dgvCuentas = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.ChBanco = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.ChEfectivo = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.textMontoBase = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextValorReclamacion = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Line21 = New Helios.Cont.Presentation.WinForm.Line2()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        CType(Me.TextRuc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextPersona, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.textFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.textFecha.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextCodigoVendedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelMontos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelMontos.SuspendLayout()
        CType(Me.GradientPanel5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel5.SuspendLayout()
        CType(Me.GradientPanel6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel6.SuspendLayout()
        CType(Me.txtTotalPagar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel4.SuspendLayout()
        CType(Me.dgvCuentas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.textMontoBase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextValorReclamacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonSalir
        '
        Me.ButtonSalir.Activecolor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.ButtonSalir.BackColor = System.Drawing.Color.Gainsboro
        Me.ButtonSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonSalir.BorderRadius = 7
        Me.ButtonSalir.ButtonText = "    Cancelar"
        Me.ButtonSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonSalir.DisabledColor = System.Drawing.Color.Gray
        Me.ButtonSalir.Iconcolor = System.Drawing.Color.Transparent
        Me.ButtonSalir.Iconimage = CType(resources.GetObject("ButtonSalir.Iconimage"), System.Drawing.Image)
        Me.ButtonSalir.Iconimage_right = Nothing
        Me.ButtonSalir.Iconimage_right_Selected = Nothing
        Me.ButtonSalir.Iconimage_Selected = Nothing
        Me.ButtonSalir.IconMarginLeft = 0
        Me.ButtonSalir.IconMarginRight = 0
        Me.ButtonSalir.IconRightVisible = True
        Me.ButtonSalir.IconRightZoom = 0R
        Me.ButtonSalir.IconVisible = False
        Me.ButtonSalir.IconZoom = 40.0R
        Me.ButtonSalir.IsTab = False
        Me.ButtonSalir.Location = New System.Drawing.Point(462, 439)
        Me.ButtonSalir.Name = "ButtonSalir"
        Me.ButtonSalir.Normalcolor = System.Drawing.Color.Gainsboro
        Me.ButtonSalir.OnHovercolor = System.Drawing.Color.Gainsboro
        Me.ButtonSalir.OnHoverTextColor = System.Drawing.Color.DimGray
        Me.ButtonSalir.selected = False
        Me.ButtonSalir.Size = New System.Drawing.Size(121, 40)
        Me.ButtonSalir.TabIndex = 610
        Me.ButtonSalir.Text = "    Cancelar"
        Me.ButtonSalir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ButtonSalir.Textcolor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonSalir.TextFont = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'TextRuc
        '
        Me.TextRuc.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextRuc.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TextRuc.BorderColor = System.Drawing.Color.Silver
        Me.TextRuc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextRuc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextRuc.CornerRadius = 4
        Me.TextRuc.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextRuc.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextRuc.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextRuc.Location = New System.Drawing.Point(590, 57)
        Me.TextRuc.Metrocolor = System.Drawing.Color.Silver
        Me.TextRuc.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextRuc.Name = "TextRuc"
        Me.TextRuc.Size = New System.Drawing.Size(121, 24)
        Me.TextRuc.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextRuc.TabIndex = 607
        '
        'ButtonGrabar
        '
        Me.ButtonGrabar.Activecolor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.ButtonGrabar.BackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.ButtonGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonGrabar.BorderRadius = 7
        Me.ButtonGrabar.ButtonText = "Guardar"
        Me.ButtonGrabar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonGrabar.DisabledColor = System.Drawing.Color.Gray
        Me.ButtonGrabar.Iconcolor = System.Drawing.Color.Transparent
        Me.ButtonGrabar.Iconimage = CType(resources.GetObject("ButtonGrabar.Iconimage"), System.Drawing.Image)
        Me.ButtonGrabar.Iconimage_right = Nothing
        Me.ButtonGrabar.Iconimage_right_Selected = Nothing
        Me.ButtonGrabar.Iconimage_Selected = Nothing
        Me.ButtonGrabar.IconMarginLeft = 0
        Me.ButtonGrabar.IconMarginRight = 0
        Me.ButtonGrabar.IconRightVisible = True
        Me.ButtonGrabar.IconRightZoom = 0R
        Me.ButtonGrabar.IconVisible = True
        Me.ButtonGrabar.IconZoom = 40.0R
        Me.ButtonGrabar.IsTab = False
        Me.ButtonGrabar.Location = New System.Drawing.Point(589, 439)
        Me.ButtonGrabar.Name = "ButtonGrabar"
        Me.ButtonGrabar.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.ButtonGrabar.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.ButtonGrabar.OnHoverTextColor = System.Drawing.Color.White
        Me.ButtonGrabar.selected = False
        Me.ButtonGrabar.Size = New System.Drawing.Size(121, 40)
        Me.ButtonGrabar.TabIndex = 602
        Me.ButtonGrabar.Text = "Guardar"
        Me.ButtonGrabar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ButtonGrabar.Textcolor = System.Drawing.Color.White
        Me.ButtonGrabar.TextFont = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(6, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 19)
        Me.Label2.TabIndex = 599
        Me.Label2.Text = "Comprobante"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(215, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(135, 19)
        Me.Label8.TabIndex = 598
        Me.Label8.Text = "Persona beneficiaria"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(216, 40)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(122, 14)
        Me.Label14.TabIndex = 597
        Me.Label14.Text = "Razón social / Nombres"
        '
        'TextPersona
        '
        Me.TextPersona.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextPersona.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TextPersona.BorderColor = System.Drawing.Color.Silver
        Me.TextPersona.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextPersona.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextPersona.CornerRadius = 4
        Me.TextPersona.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextPersona.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextPersona.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextPersona.Location = New System.Drawing.Point(219, 57)
        Me.TextPersona.Metrocolor = System.Drawing.SystemColors.MenuHighlight
        Me.TextPersona.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextPersona.Name = "TextPersona"
        Me.TextPersona.NearImage = CType(resources.GetObject("TextPersona.NearImage"), System.Drawing.Image)
        Me.TextPersona.Size = New System.Drawing.Size(365, 24)
        Me.TextPersona.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextPersona.TabIndex = 596
        '
        'textFecha
        '
        Me.textFecha.BackColor = System.Drawing.Color.White
        Me.textFecha.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.textFecha.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.textFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.textFecha.Calendar.AllowMultipleSelection = False
        Me.textFecha.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.textFecha.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.textFecha.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.textFecha.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.textFecha.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.textFecha.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.textFecha.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.textFecha.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textFecha.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.textFecha.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.textFecha.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.textFecha.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.textFecha.Calendar.HighlightColor = System.Drawing.Color.White
        Me.textFecha.Calendar.Iso8601CalenderFormat = False
        Me.textFecha.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.textFecha.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.textFecha.Calendar.Name = "monthCalendar"
        Me.textFecha.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.textFecha.Calendar.SelectedDates = New Date(-1) {}
        Me.textFecha.Calendar.Size = New System.Drawing.Size(201, 174)
        Me.textFecha.Calendar.SizeToFit = True
        Me.textFecha.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.textFecha.Calendar.TabIndex = 0
        Me.textFecha.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.textFecha.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.textFecha.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.textFecha.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.textFecha.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.textFecha.Calendar.NoneButton.IsBackStageButton = False
        Me.textFecha.Calendar.NoneButton.Location = New System.Drawing.Point(125, 0)
        Me.textFecha.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.textFecha.Calendar.NoneButton.Text = "None"
        Me.textFecha.Calendar.NoneButton.UseVisualStyle = True
        Me.textFecha.Calendar.NoneButton.Visible = False
        '
        '
        '
        Me.textFecha.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.textFecha.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.textFecha.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.textFecha.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.textFecha.Calendar.TodayButton.IsBackStageButton = False
        Me.textFecha.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.textFecha.Calendar.TodayButton.Size = New System.Drawing.Size(201, 20)
        Me.textFecha.Calendar.TodayButton.Text = "Today"
        Me.textFecha.Calendar.TodayButton.UseVisualStyle = True
        Me.textFecha.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textFecha.CalendarSize = New System.Drawing.Size(189, 176)
        Me.textFecha.Checked = False
        Me.textFecha.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.textFecha.CustomFormat = "dd/MM/yyyy HH:mm:ss tt"
        Me.textFecha.DropDownImage = Nothing
        Me.textFecha.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.textFecha.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.textFecha.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.textFecha.Enabled = False
        Me.textFecha.EnableNullDate = False
        Me.textFecha.EnableNullKeys = False
        Me.textFecha.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textFecha.ForeColor = System.Drawing.SystemColors.ControlText
        Me.textFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.textFecha.Location = New System.Drawing.Point(10, 57)
        Me.textFecha.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.textFecha.MinValue = New Date(CType(0, Long))
        Me.textFecha.Name = "textFecha"
        Me.textFecha.ShowCheckBox = False
        Me.textFecha.ShowDropButton = False
        Me.textFecha.Size = New System.Drawing.Size(203, 24)
        Me.textFecha.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.textFecha.TabIndex = 592
        Me.textFecha.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(7, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 14)
        Me.Label1.TabIndex = 591
        Me.Label1.Text = "Fecha emisión"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft JhengHei UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label6.Location = New System.Drawing.Point(21, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(249, 20)
        Me.Label6.TabIndex = 590
        Me.Label6.Text = "Devoluciòn de Dinero Anticipos"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(587, 40)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(77, 14)
        Me.Label15.TabIndex = 618
        Me.Label15.Text = "Nro. Identidad"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(22, 36)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(105, 19)
        Me.Label16.TabIndex = 619
        Me.Label16.Text = "Usuario de caja"
        '
        'ComboCaja
        '
        Me.ComboCaja.BackColor = System.Drawing.Color.White
        Me.ComboCaja.BeforeTouchSize = New System.Drawing.Size(197, 21)
        Me.ComboCaja.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboCaja.Location = New System.Drawing.Point(130, 64)
        Me.ComboCaja.MetroBorderColor = System.Drawing.Color.Silver
        Me.ComboCaja.Name = "ComboCaja"
        Me.ComboCaja.Size = New System.Drawing.Size(197, 21)
        Me.ComboCaja.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboCaja.TabIndex = 621
        '
        'TextCodigoVendedor
        '
        Me.TextCodigoVendedor.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextCodigoVendedor.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TextCodigoVendedor.BorderColor = System.Drawing.Color.Silver
        Me.TextCodigoVendedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextCodigoVendedor.CornerRadius = 4
        Me.TextCodigoVendedor.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextCodigoVendedor.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextCodigoVendedor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextCodigoVendedor.Location = New System.Drawing.Point(26, 62)
        Me.TextCodigoVendedor.MaxLength = 5
        Me.TextCodigoVendedor.Metrocolor = System.Drawing.Color.YellowGreen
        Me.TextCodigoVendedor.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextCodigoVendedor.Name = "TextCodigoVendedor"
        Me.TextCodigoVendedor.NearImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.ok_icon
        Me.TextCodigoVendedor.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextCodigoVendedor.Size = New System.Drawing.Size(98, 23)
        Me.TextCodigoVendedor.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextCodigoVendedor.TabIndex = 620
        Me.TextCodigoVendedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(333, 70)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(42, 13)
        Me.LinkLabel1.TabIndex = 623
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Mostrar"
        '
        'PanelMontos
        '
        Me.PanelMontos.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PanelMontos.BackgroundColor = New Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.PatternStyle.Weave, System.Drawing.Color.White, System.Drawing.Color.White)
        Me.PanelMontos.Border3DStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.PanelMontos.BorderColor = System.Drawing.Color.Silver
        Me.PanelMontos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelMontos.Controls.Add(Me.GradientPanel5)
        Me.PanelMontos.Controls.Add(Me.GradientPanel4)
        Me.PanelMontos.Controls.Add(Me.Label21)
        Me.PanelMontos.Controls.Add(Me.ChBanco)
        Me.PanelMontos.Controls.Add(Me.Label23)
        Me.PanelMontos.Controls.Add(Me.ChEfectivo)
        Me.PanelMontos.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanelMontos.Location = New System.Drawing.Point(10, 87)
        Me.PanelMontos.Name = "PanelMontos"
        Me.PanelMontos.Size = New System.Drawing.Size(701, 287)
        Me.PanelMontos.TabIndex = 624
        '
        'GradientPanel5
        '
        Me.GradientPanel5.BackColor = System.Drawing.Color.Gainsboro
        Me.GradientPanel5.BorderColor = System.Drawing.Color.LightGray
        Me.GradientPanel5.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GradientPanel5.Controls.Add(Me.GradientPanel6)
        Me.GradientPanel5.Location = New System.Drawing.Point(3, 3)
        Me.GradientPanel5.Name = "GradientPanel5"
        Me.GradientPanel5.Size = New System.Drawing.Size(693, 29)
        Me.GradientPanel5.TabIndex = 405
        '
        'GradientPanel6
        '
        Me.GradientPanel6.BackColor = System.Drawing.Color.DarkOrchid
        Me.GradientPanel6.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.GradientPanel6.BorderSides = System.Windows.Forms.Border3DSide.Top
        Me.GradientPanel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel6.Controls.Add(Me.txtTotalPagar)
        Me.GradientPanel6.Controls.Add(Me.Label13)
        Me.GradientPanel6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel6.Location = New System.Drawing.Point(0, -3)
        Me.GradientPanel6.Name = "GradientPanel6"
        Me.GradientPanel6.Size = New System.Drawing.Size(693, 32)
        Me.GradientPanel6.TabIndex = 222
        '
        'txtTotalPagar
        '
        Me.txtTotalPagar.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.txtTotalPagar.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtTotalPagar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalPagar.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotalPagar.CornerRadius = 5
        Me.txtTotalPagar.CurrencySymbol = ""
        Me.txtTotalPagar.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotalPagar.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalPagar.Font = New System.Drawing.Font("Segoe UI Semibold", 12.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPagar.ForeColor = System.Drawing.Color.White
        Me.txtTotalPagar.Location = New System.Drawing.Point(509, 5)
        Me.txtTotalPagar.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalPagar.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtTotalPagar.Name = "txtTotalPagar"
        Me.txtTotalPagar.NullString = ""
        Me.txtTotalPagar.PositiveColor = System.Drawing.Color.White
        Me.txtTotalPagar.ReadOnly = True
        Me.txtTotalPagar.ReadOnlyBackColor = System.Drawing.Color.DarkOrchid
        Me.txtTotalPagar.Size = New System.Drawing.Size(179, 23)
        Me.txtTotalPagar.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtTotalPagar.TabIndex = 495
        Me.txtTotalPagar.Text = "0.00"
        Me.txtTotalPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(16, 10)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(120, 15)
        Me.Label13.TabIndex = 7
        Me.Label13.Text = "TOTAL DEVOLUCION"
        '
        'GradientPanel4
        '
        Me.GradientPanel4.BackgroundColor = New Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.PatternStyle.Weave, System.Drawing.Color.White, System.Drawing.Color.White)
        Me.GradientPanel4.BorderColor = System.Drawing.Color.Silver
        Me.GradientPanel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel4.Controls.Add(Me.dgvCuentas)
        Me.GradientPanel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel4.Location = New System.Drawing.Point(0, 36)
        Me.GradientPanel4.Name = "GradientPanel4"
        Me.GradientPanel4.Size = New System.Drawing.Size(699, 249)
        Me.GradientPanel4.TabIndex = 523
        '
        'dgvCuentas
        '
        Me.dgvCuentas.Appearance.AlternateRecordFieldCell.Font.Size = 8.0!
        Me.dgvCuentas.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        Me.dgvCuentas.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.dgvCuentas.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dgvCuentas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvCuentas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCuentas.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvCuentas.FreezeCaption = False
        Me.dgvCuentas.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgvCuentas.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.dgvCuentas.Location = New System.Drawing.Point(0, 0)
        Me.dgvCuentas.Name = "dgvCuentas"
        Me.dgvCuentas.Size = New System.Drawing.Size(697, 247)
        Me.dgvCuentas.TabIndex = 426
        Me.dgvCuentas.TableDescriptor.AllowNew = False
        Me.dgvCuentas.TableDescriptor.Appearance.AnyCell.Font.Facename = "Segoe UI"
        Me.dgvCuentas.TableDescriptor.Appearance.AnyCell.Font.Size = 12.0!
        Me.dgvCuentas.TableDescriptor.Appearance.AnyCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.dgvCuentas.TableDescriptor.Appearance.AnyGroupCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCuentas.TableDescriptor.Appearance.AnyGroupCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCuentas.TableDescriptor.Appearance.AnyGroupCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer)))
        Me.dgvCuentas.TableDescriptor.Appearance.AnyHeaderCell.Font.Size = 8.0!
        Me.dgvCuentas.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCuentas.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCuentas.TableDescriptor.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        Me.dgvCuentas.TableDescriptor.Appearance.AnySummaryCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCuentas.TableDescriptor.Appearance.AnySummaryCell.Borders.Top = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCuentas.TableDescriptor.Appearance.AnySummaryCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)))
        Me.dgvCuentas.TableDescriptor.Appearance.ColumnHeaderCell.Font.Bold = True
        Me.dgvCuentas.TableDescriptor.Appearance.ColumnHeaderCell.Font.Italic = False
        Me.dgvCuentas.TableDescriptor.Appearance.ColumnHeaderCell.Font.Size = 8.0!
        Me.dgvCuentas.TableDescriptor.Appearance.GroupCaptionCell.CellType = """ColumnHeader"""
        GridColumnDescriptor1.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.LavenderBlush)
        GridColumnDescriptor1.Appearance.AnyRecordFieldCell.Text = ""
        GridColumnDescriptor1.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.MappingName = "tipo"
        GridColumnDescriptor1.ReadOnly = True
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.MappingName = "identidad"
        GridColumnDescriptor2.ReadOnly = True
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor2.Width = 19
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.MappingName = "entidad"
        GridColumnDescriptor3.ReadOnly = True
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor3.Width = 250
        GridColumnDescriptor4.Appearance.AnyRecordFieldCell.CellType = "Currency"
        GridColumnDescriptor4.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
        GridColumnDescriptor4.Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = System.Drawing.SystemColors.HotTrack
        GridColumnDescriptor4.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
        GridColumnDescriptor4.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer)))
        GridColumnDescriptor4.Appearance.AnyRecordFieldCell.TextAlign = Syncfusion.Windows.Forms.Grid.GridTextAlign.Right
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.HeaderText = "Abono"
        GridColumnDescriptor4.MappingName = "abonado"
        GridColumnDescriptor4.SerializedImageArray = ""
        GridColumnDescriptor4.Width = 150
        GridColumnDescriptor5.Appearance.AnyRecordFieldCell.CellType = "Currency"
        GridColumnDescriptor5.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
        GridColumnDescriptor5.HeaderImage = Nothing
        GridColumnDescriptor5.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor5.MappingName = "Saldo"
        GridColumnDescriptor5.ReadOnly = True
        GridColumnDescriptor5.SerializedImageArray = ""
        GridColumnDescriptor5.Width = 110
        GridColumnDescriptor6.HeaderImage = Nothing
        GridColumnDescriptor6.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor6.HeaderText = "T/C"
        GridColumnDescriptor6.MappingName = "tipocambio"
        GridColumnDescriptor6.ReadOnly = True
        GridColumnDescriptor6.SerializedImageArray = ""
        GridColumnDescriptor6.Width = 50
        GridColumnDescriptor7.HeaderImage = Nothing
        GridColumnDescriptor7.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor7.MappingName = "idforma"
        GridColumnDescriptor7.SerializedImageArray = ""
        GridColumnDescriptor7.Width = 20
        GridColumnDescriptor8.HeaderImage = Nothing
        GridColumnDescriptor8.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor8.HeaderText = "Forma de Pago"
        GridColumnDescriptor8.MappingName = "formaPago"
        GridColumnDescriptor8.ReadOnly = True
        GridColumnDescriptor8.SerializedImageArray = ""
        GridColumnDescriptor8.Width = 400
        Me.dgvCuentas.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7, GridColumnDescriptor8})
        GridSummaryRowDescriptor1.Appearance.AnySummaryCell.CellType = "TextBox"
        GridSummaryRowDescriptor1.Appearance.AnySummaryCell.CurrencyEdit.CurrencySymbol = ""
        GridSummaryRowDescriptor1.Appearance.AnySummaryCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
        GridSummaryRowDescriptor1.Appearance.AnySummaryCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.GradientInactiveCaption)
        GridSummaryRowDescriptor1.Appearance.AnySummaryCell.TextColor = System.Drawing.Color.Black
        GridSummaryRowDescriptor1.Name = "Row 1"
        GridSummaryColumnDescriptor1.Appearance.AnySummaryCell.CellType = "Currency"
        GridSummaryColumnDescriptor1.Appearance.AnySummaryCell.Font.Bold = True
        GridSummaryColumnDescriptor1.Appearance.AnySummaryCell.Font.Size = 12.0!
        GridSummaryColumnDescriptor1.Appearance.AnySummaryCell.TextColor = System.Drawing.Color.Black
        GridSummaryColumnDescriptor1.DataMember = "abonado"
        GridSummaryColumnDescriptor1.Format = "{Sum}"
        GridSummaryColumnDescriptor1.Name = "abonado"
        GridSummaryColumnDescriptor1.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        GridSummaryRowDescriptor1.SummaryColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor() {GridSummaryColumnDescriptor1})
        GridSummaryRowDescriptor1.Title = "Total devolución"
        Me.dgvCuentas.TableDescriptor.SummaryRows.Add(GridSummaryRowDescriptor1)
        Me.dgvCuentas.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.dgvCuentas.TableDescriptor.TableOptions.RecordRowHeight = 20
        Me.dgvCuentas.TableDescriptor.TopLevelGroupOptions.ShowCaption = False
        Me.dgvCuentas.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("formaPago"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("abonado"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("Saldo")})
        Me.dgvCuentas.Text = "GridGroupingControl2"
        Me.dgvCuentas.VersionInfo = "12.4400.0.24"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label21.Location = New System.Drawing.Point(596, 345)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(43, 17)
        Me.Label21.TabIndex = 520
        Me.Label21.Text = "Banco"
        '
        'ChBanco
        '
        Me.ChBanco.BackColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.ChBanco.ChechedOffColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.ChBanco.Checked = False
        Me.ChBanco.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.ChBanco.ForeColor = System.Drawing.Color.White
        Me.ChBanco.Location = New System.Drawing.Point(573, 344)
        Me.ChBanco.Name = "ChBanco"
        Me.ChBanco.Size = New System.Drawing.Size(20, 20)
        Me.ChBanco.TabIndex = 519
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label23.Location = New System.Drawing.Point(508, 345)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(53, 17)
        Me.Label23.TabIndex = 518
        Me.Label23.Text = "Efectivo"
        '
        'ChEfectivo
        '
        Me.ChEfectivo.BackColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.ChEfectivo.ChechedOffColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.ChEfectivo.Checked = False
        Me.ChEfectivo.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.ChEfectivo.ForeColor = System.Drawing.Color.White
        Me.ChEfectivo.Location = New System.Drawing.Point(485, 344)
        Me.ChEfectivo.Name = "ChEfectivo"
        Me.ChEfectivo.Size = New System.Drawing.Size(20, 20)
        Me.ChEfectivo.TabIndex = 517
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(444, 387)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 14)
        Me.Label3.TabIndex = 603
        Me.Label3.Text = "Reclamación disponible"
        '
        'textMontoBase
        '
        Me.textMontoBase.BackGroundColor = System.Drawing.Color.WhiteSmoke
        Me.textMontoBase.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.textMontoBase.BorderColor = System.Drawing.Color.Silver
        Me.textMontoBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.textMontoBase.CornerRadius = 5
        Me.textMontoBase.CurrencySymbol = ""
        Me.textMontoBase.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.textMontoBase.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.textMontoBase.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textMontoBase.ForeColor = System.Drawing.Color.Maroon
        Me.textMontoBase.Location = New System.Drawing.Point(569, 381)
        Me.textMontoBase.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.textMontoBase.MinimumSize = New System.Drawing.Size(14, 10)
        Me.textMontoBase.Name = "textMontoBase"
        Me.textMontoBase.NullString = ""
        Me.textMontoBase.PositiveColor = System.Drawing.Color.Maroon
        Me.textMontoBase.ReadOnly = True
        Me.textMontoBase.ReadOnlyBackColor = System.Drawing.Color.Thistle
        Me.textMontoBase.Size = New System.Drawing.Size(141, 23)
        Me.textMontoBase.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.textMontoBase.TabIndex = 604
        Me.textMontoBase.Text = "0.00"
        Me.textMontoBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(475, 415)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 14)
        Me.Label4.TabIndex = 605
        Me.Label4.Text = "Importe devuelto"
        Me.Label4.Visible = False
        '
        'TextValorReclamacion
        '
        Me.TextValorReclamacion.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextValorReclamacion.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TextValorReclamacion.BorderColor = System.Drawing.Color.Silver
        Me.TextValorReclamacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextValorReclamacion.CornerRadius = 5
        Me.TextValorReclamacion.CurrencySymbol = ""
        Me.TextValorReclamacion.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextValorReclamacion.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextValorReclamacion.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextValorReclamacion.ForeColor = System.Drawing.Color.Black
        Me.TextValorReclamacion.Location = New System.Drawing.Point(569, 410)
        Me.TextValorReclamacion.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextValorReclamacion.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextValorReclamacion.Name = "TextValorReclamacion"
        Me.TextValorReclamacion.NullString = ""
        Me.TextValorReclamacion.PositiveColor = System.Drawing.Color.Black
        Me.TextValorReclamacion.ReadOnly = True
        Me.TextValorReclamacion.ReadOnlyBackColor = System.Drawing.Color.WhiteSmoke
        Me.TextValorReclamacion.Size = New System.Drawing.Size(141, 23)
        Me.TextValorReclamacion.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextValorReclamacion.TabIndex = 606
        Me.TextValorReclamacion.Text = "0.00"
        Me.TextValorReclamacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TextValorReclamacion.Visible = False
        '
        'Line21
        '
        Me.Line21.LineColor = System.Drawing.Color.DarkGray
        Me.Line21.Location = New System.Drawing.Point(25, 96)
        Me.Line21.Name = "Line21"
        Me.Line21.Size = New System.Drawing.Size(497, 1)
        Me.Line21.TabIndex = 622
        Me.Line21.Text = "Line21"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.PanelMontos)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.textFecha)
        Me.GroupBox1.Controls.Add(Me.TextPersona)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.ButtonSalir)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.TextValorReclamacion)
        Me.GroupBox1.Controls.Add(Me.TextRuc)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.textMontoBase)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.ButtonGrabar)
        Me.GroupBox1.Location = New System.Drawing.Point(26, 95)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(723, 486)
        Me.GroupBox1.TabIndex = 625
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Visible = False
        '
        'FormCrearDevoluciónAnt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionForeColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(766, 583)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Line21)
        Me.Controls.Add(Me.ComboCaja)
        Me.Controls.Add(Me.TextCodigoVendedor)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label6)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormCrearDevoluciónAnt"
        Me.ShowIcon = False
        Me.Text = "Crear Devolución"
        CType(Me.TextRuc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextPersona, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.textFecha.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.textFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboCaja, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextCodigoVendedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelMontos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelMontos.ResumeLayout(False)
        Me.PanelMontos.PerformLayout()
        CType(Me.GradientPanel5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel5.ResumeLayout(False)
        CType(Me.GradientPanel6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel6.ResumeLayout(False)
        Me.GradientPanel6.PerformLayout()
        CType(Me.txtTotalPagar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel4.ResumeLayout(False)
        CType(Me.dgvCuentas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.textMontoBase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextValorReclamacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ButtonSalir As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents TextRuc As Tools.TextBoxExt
    Friend WithEvents ButtonGrabar As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents Label2 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents TextPersona As Tools.TextBoxExt
    Friend WithEvents textFecha As Tools.DateTimePickerAdv
    Friend WithEvents Label1 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents ComboCaja As Tools.ComboBoxAdv
    Friend WithEvents TextCodigoVendedor As Tools.TextBoxExt

    Friend WithEvents Line21 As Line2
    Friend WithEvents LinkLabel1 As LinkLabel
    Private WithEvents PanelMontos As Tools.GradientPanel
    Friend WithEvents GradientPanel5 As Tools.GradientPanel
    Friend WithEvents GradientPanel6 As Tools.GradientPanel
    Friend WithEvents txtTotalPagar As Tools.CurrencyTextBox
    Friend WithEvents Label13 As Label
    Private WithEvents GradientPanel4 As Tools.GradientPanel
    Friend WithEvents dgvCuentas As Grid.Grouping.GridGroupingControl
    Friend WithEvents Label21 As Label
    Friend WithEvents ChBanco As Bunifu.Framework.UI.BunifuCheckbox
    Friend WithEvents Label23 As Label
    Friend WithEvents ChEfectivo As Bunifu.Framework.UI.BunifuCheckbox
    Friend WithEvents Label3 As Label
    Friend WithEvents textMontoBase As Tools.CurrencyTextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TextValorReclamacion As Tools.CurrencyTextBox
    Friend WithEvents GroupBox1 As GroupBox
End Class

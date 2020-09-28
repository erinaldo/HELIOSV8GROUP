Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormCambiarDestino
    Inherits MetroForm

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
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"1", "JIUNI PALACIOS SANTOS", "44924569"}, -1)
        Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"1", "JIUNI PALACIOS SANTOS", "44924569"}, -1)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCambiarDestino))
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor6 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridSummaryRowDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor()
        Dim GridSummaryColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor()
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Dim CaptionLabel2 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.PanelCrearEncomienda = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.TextfechaVcto = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.CurrencyTextBox1 = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.texHoraEnvio = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.TextFechaEnvio = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.ComboAgenciaDestino = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.pcLikeCategoria = New Syncfusion.Windows.Forms.PopupControlContainer()
        Me.LsvProveedor = New System.Windows.Forms.ListView()
        Me.colID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colRUC = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTipoDoc = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PCEmpresas = New Syncfusion.Windows.Forms.PopupControlContainer()
        Me.ListEmpresas = New System.Windows.Forms.ListView()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.RoundButton22 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GradientPanel11 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.GridEncomiendas = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.textPersona = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtruc = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TextEmpresaPasajero = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextNumIdentrazon = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ComboAgenciaOrigen = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.PictureLoad = New System.Windows.Forms.PictureBox()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        CType(Me.PanelCrearEncomienda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelCrearEncomienda.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        CType(Me.TextfechaVcto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextfechaVcto.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CurrencyTextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox7.SuspendLayout()
        CType(Me.texHoraEnvio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.texHoraEnvio.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextFechaEnvio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextFechaEnvio.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        CType(Me.ComboAgenciaDestino, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pcLikeCategoria.SuspendLayout()
        Me.PCEmpresas.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.GradientPanel11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel11.SuspendLayout()
        CType(Me.GridEncomiendas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.textPersona, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtruc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.TextEmpresaPasajero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextNumIdentrazon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ComboAgenciaOrigen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureLoad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelCrearEncomienda
        '
        Me.PanelCrearEncomienda.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PanelCrearEncomienda.BorderColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.PanelCrearEncomienda.BorderSingle = System.Windows.Forms.ButtonBorderStyle.Dashed
        Me.PanelCrearEncomienda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelCrearEncomienda.Controls.Add(Me.LinkLabel1)
        Me.PanelCrearEncomienda.Controls.Add(Me.GroupBox8)
        Me.PanelCrearEncomienda.Controls.Add(Me.GroupBox7)
        Me.PanelCrearEncomienda.Controls.Add(Me.GroupBox6)
        Me.PanelCrearEncomienda.Controls.Add(Me.pcLikeCategoria)
        Me.PanelCrearEncomienda.Controls.Add(Me.PCEmpresas)
        Me.PanelCrearEncomienda.Controls.Add(Me.RoundButton22)
        Me.PanelCrearEncomienda.Controls.Add(Me.GroupBox4)
        Me.PanelCrearEncomienda.Controls.Add(Me.GroupBox3)
        Me.PanelCrearEncomienda.Controls.Add(Me.GroupBox2)
        Me.PanelCrearEncomienda.Controls.Add(Me.GroupBox1)
        Me.PanelCrearEncomienda.Location = New System.Drawing.Point(0, 1)
        Me.PanelCrearEncomienda.Name = "PanelCrearEncomienda"
        Me.PanelCrearEncomienda.Size = New System.Drawing.Size(806, 524)
        Me.PanelCrearEncomienda.TabIndex = 612
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Segoe UI", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.Location = New System.Drawing.Point(802, 85)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(40, 12)
        Me.LinkLabel1.TabIndex = 591
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Guardar"
        Me.LinkLabel1.Visible = False
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.TextfechaVcto)
        Me.GroupBox8.Controls.Add(Me.CurrencyTextBox1)
        Me.GroupBox8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox8.Location = New System.Drawing.Point(808, 31)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(393, 52)
        Me.GroupBox8.TabIndex = 617
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Fecha de vencimiento"
        '
        'TextfechaVcto
        '
        Me.TextfechaVcto.BackColor = System.Drawing.Color.White
        Me.TextfechaVcto.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.TextfechaVcto.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextfechaVcto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TextfechaVcto.Calendar.AllowMultipleSelection = False
        Me.TextfechaVcto.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextfechaVcto.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextfechaVcto.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.TextfechaVcto.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextfechaVcto.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TextfechaVcto.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.TextfechaVcto.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextfechaVcto.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextfechaVcto.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TextfechaVcto.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.TextfechaVcto.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.TextfechaVcto.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.TextfechaVcto.Calendar.HighlightColor = System.Drawing.Color.White
        Me.TextfechaVcto.Calendar.Iso8601CalenderFormat = False
        Me.TextfechaVcto.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.TextfechaVcto.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextfechaVcto.Calendar.Name = "monthCalendar"
        Me.TextfechaVcto.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.TextfechaVcto.Calendar.SelectedDates = New Date(-1) {}
        Me.TextfechaVcto.Calendar.Size = New System.Drawing.Size(86, 174)
        Me.TextfechaVcto.Calendar.SizeToFit = True
        Me.TextfechaVcto.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.TextfechaVcto.Calendar.TabIndex = 0
        Me.TextfechaVcto.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.TextfechaVcto.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.TextfechaVcto.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextfechaVcto.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.TextfechaVcto.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.TextfechaVcto.Calendar.NoneButton.IsBackStageButton = False
        Me.TextfechaVcto.Calendar.NoneButton.Location = New System.Drawing.Point(10, 0)
        Me.TextfechaVcto.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.TextfechaVcto.Calendar.NoneButton.Text = "None"
        Me.TextfechaVcto.Calendar.NoneButton.UseVisualStyle = True
        Me.TextfechaVcto.Calendar.NoneButton.Visible = False
        '
        '
        '
        Me.TextfechaVcto.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.TextfechaVcto.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextfechaVcto.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.TextfechaVcto.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.TextfechaVcto.Calendar.TodayButton.IsBackStageButton = False
        Me.TextfechaVcto.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.TextfechaVcto.Calendar.TodayButton.Size = New System.Drawing.Size(86, 20)
        Me.TextfechaVcto.Calendar.TodayButton.Text = "Today"
        Me.TextfechaVcto.Calendar.TodayButton.UseVisualStyle = True
        Me.TextfechaVcto.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextfechaVcto.CalendarSize = New System.Drawing.Size(189, 176)
        Me.TextfechaVcto.Checked = False
        Me.TextfechaVcto.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.TextfechaVcto.CustomFormat = "dd/MM/yyyy"
        Me.TextfechaVcto.DropDownImage = Nothing
        Me.TextfechaVcto.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextfechaVcto.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextfechaVcto.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.TextfechaVcto.Enabled = False
        Me.TextfechaVcto.EnableNullDate = False
        Me.TextfechaVcto.EnableNullKeys = False
        Me.TextfechaVcto.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextfechaVcto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TextfechaVcto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TextfechaVcto.Location = New System.Drawing.Point(87, 23)
        Me.TextfechaVcto.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextfechaVcto.MinValue = New Date(CType(0, Long))
        Me.TextfechaVcto.Name = "TextfechaVcto"
        Me.TextfechaVcto.ShowCheckBox = False
        Me.TextfechaVcto.ShowDropButton = False
        Me.TextfechaVcto.Size = New System.Drawing.Size(88, 20)
        Me.TextfechaVcto.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.TextfechaVcto.TabIndex = 611
        Me.TextfechaVcto.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'CurrencyTextBox1
        '
        Me.CurrencyTextBox1.BackGroundColor = System.Drawing.Color.White
        Me.CurrencyTextBox1.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.CurrencyTextBox1.BorderColor = System.Drawing.Color.Silver
        Me.CurrencyTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CurrencyTextBox1.CurrencyDecimalDigits = 0
        Me.CurrencyTextBox1.CurrencySymbol = "días:  "
        Me.CurrencyTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.CurrencyTextBox1.DecimalValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.CurrencyTextBox1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CurrencyTextBox1.ForeColor = System.Drawing.Color.Black
        Me.CurrencyTextBox1.Location = New System.Drawing.Point(10, 21)
        Me.CurrencyTextBox1.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CurrencyTextBox1.MinimumSize = New System.Drawing.Size(14, 10)
        Me.CurrencyTextBox1.Name = "CurrencyTextBox1"
        Me.CurrencyTextBox1.NullString = ""
        Me.CurrencyTextBox1.PositiveColor = System.Drawing.Color.Black
        Me.CurrencyTextBox1.ReadOnlyBackColor = System.Drawing.Color.White
        Me.CurrencyTextBox1.Size = New System.Drawing.Size(71, 22)
        Me.CurrencyTextBox1.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.CurrencyTextBox1.TabIndex = 590
        Me.CurrencyTextBox1.Text = "días:  1"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.texHoraEnvio)
        Me.GroupBox7.Controls.Add(Me.TextFechaEnvio)
        Me.GroupBox7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox7.Location = New System.Drawing.Point(8, 11)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(10, 53)
        Me.GroupBox7.TabIndex = 616
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Fecha de envío de la encomienda"
        Me.GroupBox7.Visible = False
        '
        'texHoraEnvio
        '
        Me.texHoraEnvio.BackColor = System.Drawing.SystemColors.Info
        Me.texHoraEnvio.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.texHoraEnvio.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.texHoraEnvio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.texHoraEnvio.Calendar.AllowMultipleSelection = False
        Me.texHoraEnvio.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.texHoraEnvio.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.texHoraEnvio.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.texHoraEnvio.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.texHoraEnvio.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.texHoraEnvio.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.texHoraEnvio.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.texHoraEnvio.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.texHoraEnvio.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.texHoraEnvio.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.texHoraEnvio.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.texHoraEnvio.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.texHoraEnvio.Calendar.HighlightColor = System.Drawing.Color.White
        Me.texHoraEnvio.Calendar.Iso8601CalenderFormat = False
        Me.texHoraEnvio.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.texHoraEnvio.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.texHoraEnvio.Calendar.Name = "monthCalendar"
        Me.texHoraEnvio.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.texHoraEnvio.Calendar.SelectedDates = New Date(-1) {}
        Me.texHoraEnvio.Calendar.Size = New System.Drawing.Size(135, 174)
        Me.texHoraEnvio.Calendar.SizeToFit = True
        Me.texHoraEnvio.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.texHoraEnvio.Calendar.TabIndex = 0
        Me.texHoraEnvio.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.texHoraEnvio.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.texHoraEnvio.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.texHoraEnvio.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.texHoraEnvio.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.texHoraEnvio.Calendar.NoneButton.IsBackStageButton = False
        Me.texHoraEnvio.Calendar.NoneButton.Location = New System.Drawing.Point(59, 0)
        Me.texHoraEnvio.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.texHoraEnvio.Calendar.NoneButton.Text = "None"
        Me.texHoraEnvio.Calendar.NoneButton.UseVisualStyle = True
        Me.texHoraEnvio.Calendar.NoneButton.Visible = False
        '
        '
        '
        Me.texHoraEnvio.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.texHoraEnvio.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.texHoraEnvio.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.texHoraEnvio.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.texHoraEnvio.Calendar.TodayButton.IsBackStageButton = False
        Me.texHoraEnvio.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.texHoraEnvio.Calendar.TodayButton.Size = New System.Drawing.Size(135, 20)
        Me.texHoraEnvio.Calendar.TodayButton.Text = "Today"
        Me.texHoraEnvio.Calendar.TodayButton.UseVisualStyle = True
        Me.texHoraEnvio.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.texHoraEnvio.CalendarSize = New System.Drawing.Size(189, 176)
        Me.texHoraEnvio.Checked = False
        Me.texHoraEnvio.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.texHoraEnvio.CustomFormat = "HH:mm:ss tt"
        Me.texHoraEnvio.DropDownImage = Nothing
        Me.texHoraEnvio.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.texHoraEnvio.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.texHoraEnvio.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.texHoraEnvio.EnableNullDate = False
        Me.texHoraEnvio.EnableNullKeys = False
        Me.texHoraEnvio.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.texHoraEnvio.ForeColor = System.Drawing.SystemColors.ControlText
        Me.texHoraEnvio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.texHoraEnvio.Location = New System.Drawing.Point(164, 23)
        Me.texHoraEnvio.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.texHoraEnvio.MinValue = New Date(CType(0, Long))
        Me.texHoraEnvio.Name = "texHoraEnvio"
        Me.texHoraEnvio.ShowCheckBox = False
        Me.texHoraEnvio.ShowDropButton = False
        Me.texHoraEnvio.Size = New System.Drawing.Size(137, 20)
        Me.texHoraEnvio.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.texHoraEnvio.TabIndex = 611
        Me.texHoraEnvio.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'TextFechaEnvio
        '
        Me.TextFechaEnvio.BackColor = System.Drawing.SystemColors.Info
        Me.TextFechaEnvio.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.TextFechaEnvio.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextFechaEnvio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TextFechaEnvio.Calendar.AllowMultipleSelection = False
        Me.TextFechaEnvio.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextFechaEnvio.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextFechaEnvio.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.TextFechaEnvio.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaEnvio.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TextFechaEnvio.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.TextFechaEnvio.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextFechaEnvio.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextFechaEnvio.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TextFechaEnvio.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.TextFechaEnvio.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.TextFechaEnvio.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.TextFechaEnvio.Calendar.HighlightColor = System.Drawing.Color.White
        Me.TextFechaEnvio.Calendar.Iso8601CalenderFormat = False
        Me.TextFechaEnvio.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.TextFechaEnvio.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaEnvio.Calendar.Name = "monthCalendar"
        Me.TextFechaEnvio.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.TextFechaEnvio.Calendar.SelectedDates = New Date(-1) {}
        Me.TextFechaEnvio.Calendar.Size = New System.Drawing.Size(135, 174)
        Me.TextFechaEnvio.Calendar.SizeToFit = True
        Me.TextFechaEnvio.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.TextFechaEnvio.Calendar.TabIndex = 0
        Me.TextFechaEnvio.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.TextFechaEnvio.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.TextFechaEnvio.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaEnvio.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.TextFechaEnvio.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.TextFechaEnvio.Calendar.NoneButton.IsBackStageButton = False
        Me.TextFechaEnvio.Calendar.NoneButton.Location = New System.Drawing.Point(59, 0)
        Me.TextFechaEnvio.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.TextFechaEnvio.Calendar.NoneButton.Text = "None"
        Me.TextFechaEnvio.Calendar.NoneButton.UseVisualStyle = True
        Me.TextFechaEnvio.Calendar.NoneButton.Visible = False
        '
        '
        '
        Me.TextFechaEnvio.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.TextFechaEnvio.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaEnvio.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.TextFechaEnvio.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.TextFechaEnvio.Calendar.TodayButton.IsBackStageButton = False
        Me.TextFechaEnvio.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.TextFechaEnvio.Calendar.TodayButton.Size = New System.Drawing.Size(135, 20)
        Me.TextFechaEnvio.Calendar.TodayButton.Text = "Today"
        Me.TextFechaEnvio.Calendar.TodayButton.UseVisualStyle = True
        Me.TextFechaEnvio.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextFechaEnvio.CalendarSize = New System.Drawing.Size(189, 176)
        Me.TextFechaEnvio.Checked = False
        Me.TextFechaEnvio.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.TextFechaEnvio.CustomFormat = "dd/MM/yyyy"
        Me.TextFechaEnvio.DropDownImage = Nothing
        Me.TextFechaEnvio.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaEnvio.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaEnvio.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.TextFechaEnvio.EnableNullDate = False
        Me.TextFechaEnvio.EnableNullKeys = False
        Me.TextFechaEnvio.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextFechaEnvio.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TextFechaEnvio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TextFechaEnvio.Location = New System.Drawing.Point(15, 23)
        Me.TextFechaEnvio.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaEnvio.MinValue = New Date(CType(0, Long))
        Me.TextFechaEnvio.Name = "TextFechaEnvio"
        Me.TextFechaEnvio.ShowCheckBox = False
        Me.TextFechaEnvio.Size = New System.Drawing.Size(137, 20)
        Me.TextFechaEnvio.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.TextFechaEnvio.TabIndex = 610
        Me.TextFechaEnvio.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.ComboAgenciaDestino)
        Me.GroupBox6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox6.Location = New System.Drawing.Point(8, 73)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(328, 76)
        Me.GroupBox6.TabIndex = 615
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Agencia de destino"
        '
        'ComboAgenciaDestino
        '
        Me.ComboAgenciaDestino.BackColor = System.Drawing.Color.White
        Me.ComboAgenciaDestino.BeforeTouchSize = New System.Drawing.Size(287, 24)
        Me.ComboAgenciaDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboAgenciaDestino.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboAgenciaDestino.Location = New System.Drawing.Point(16, 26)
        Me.ComboAgenciaDestino.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.ComboAgenciaDestino.Name = "ComboAgenciaDestino"
        Me.ComboAgenciaDestino.Size = New System.Drawing.Size(287, 24)
        Me.ComboAgenciaDestino.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboAgenciaDestino.TabIndex = 588
        '
        'pcLikeCategoria
        '
        Me.pcLikeCategoria.Controls.Add(Me.LsvProveedor)
        Me.pcLikeCategoria.Location = New System.Drawing.Point(503, -134)
        Me.pcLikeCategoria.Name = "pcLikeCategoria"
        Me.pcLikeCategoria.Size = New System.Drawing.Size(282, 128)
        Me.pcLikeCategoria.TabIndex = 614
        '
        'LsvProveedor
        '
        Me.LsvProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LsvProveedor.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colID, Me.colCliente, Me.colRUC, Me.colTipoDoc})
        Me.LsvProveedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LsvProveedor.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LsvProveedor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(187, Byte), Integer))
        Me.LsvProveedor.FullRowSelect = True
        Me.LsvProveedor.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.LsvProveedor.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1})
        Me.LsvProveedor.Location = New System.Drawing.Point(0, 0)
        Me.LsvProveedor.MultiSelect = False
        Me.LsvProveedor.Name = "LsvProveedor"
        Me.LsvProveedor.Size = New System.Drawing.Size(282, 128)
        Me.LsvProveedor.TabIndex = 1
        Me.LsvProveedor.UseCompatibleStateImageBehavior = False
        Me.LsvProveedor.View = System.Windows.Forms.View.Details
        '
        'colID
        '
        Me.colID.Text = "ID"
        Me.colID.Width = 0
        '
        'colCliente
        '
        Me.colCliente.Text = "Cliente"
        Me.colCliente.Width = 219
        '
        'colRUC
        '
        Me.colRUC.Text = "RUC"
        '
        'PCEmpresas
        '
        Me.PCEmpresas.Controls.Add(Me.ListEmpresas)
        Me.PCEmpresas.Location = New System.Drawing.Point(365, -129)
        Me.PCEmpresas.Name = "PCEmpresas"
        Me.PCEmpresas.Size = New System.Drawing.Size(126, 101)
        Me.PCEmpresas.TabIndex = 613
        '
        'ListEmpresas
        '
        Me.ListEmpresas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListEmpresas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8})
        Me.ListEmpresas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListEmpresas.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListEmpresas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(187, Byte), Integer))
        Me.ListEmpresas.FullRowSelect = True
        Me.ListEmpresas.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.ListEmpresas.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem2})
        Me.ListEmpresas.Location = New System.Drawing.Point(0, 0)
        Me.ListEmpresas.MultiSelect = False
        Me.ListEmpresas.Name = "ListEmpresas"
        Me.ListEmpresas.Size = New System.Drawing.Size(126, 101)
        Me.ListEmpresas.TabIndex = 1
        Me.ListEmpresas.UseCompatibleStateImageBehavior = False
        Me.ListEmpresas.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "ID"
        Me.ColumnHeader5.Width = 0
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Cliente"
        Me.ColumnHeader6.Width = 219
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "RUC"
        '
        'RoundButton22
        '
        Me.RoundButton22.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton22.BackColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.RoundButton22.BeforeTouchSize = New System.Drawing.Size(132, 31)
        Me.RoundButton22.Font = New System.Drawing.Font("Yu Gothic UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundButton22.ForeColor = System.Drawing.Color.White
        Me.RoundButton22.Image = CType(resources.GetObject("RoundButton22.Image"), System.Drawing.Image)
        Me.RoundButton22.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.RoundButton22.IsBackStageButton = False
        Me.RoundButton22.Location = New System.Drawing.Point(335, 484)
        Me.RoundButton22.Name = "RoundButton22"
        Me.RoundButton22.Size = New System.Drawing.Size(132, 31)
        Me.RoundButton22.TabIndex = 612
        Me.RoundButton22.Text = "GUARDAR"
        Me.RoundButton22.UseVisualStyle = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.GradientPanel11)
        Me.GroupBox4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox4.Location = New System.Drawing.Point(8, 154)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(782, 324)
        Me.GroupBox4.TabIndex = 611
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Detalle de la encomienda o envío"
        '
        'GradientPanel11
        '
        Me.GradientPanel11.BorderColor = System.Drawing.SystemColors.Highlight
        Me.GradientPanel11.BorderSingle = System.Windows.Forms.ButtonBorderStyle.Dotted
        Me.GradientPanel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel11.Controls.Add(Me.PictureLoad)
        Me.GradientPanel11.Controls.Add(Me.GridEncomiendas)
        Me.GradientPanel11.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel11.Location = New System.Drawing.Point(3, 21)
        Me.GradientPanel11.Name = "GradientPanel11"
        Me.GradientPanel11.Size = New System.Drawing.Size(776, 300)
        Me.GradientPanel11.TabIndex = 610
        '
        'GridEncomiendas
        '
        Me.GridEncomiendas.Appearance.AlternateRecordFieldCell.Font.Size = 8.0!
        Me.GridEncomiendas.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        Me.GridEncomiendas.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.GridEncomiendas.BackColor = System.Drawing.Color.White
        Me.GridEncomiendas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GridEncomiendas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridEncomiendas.Enabled = False
        Me.GridEncomiendas.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridEncomiendas.FreezeCaption = False
        Me.GridEncomiendas.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.GridEncomiendas.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.GridEncomiendas.Location = New System.Drawing.Point(0, 0)
        Me.GridEncomiendas.Name = "GridEncomiendas"
        Me.GridEncomiendas.Size = New System.Drawing.Size(774, 298)
        Me.GridEncomiendas.TabIndex = 609
        Me.GridEncomiendas.TableDescriptor.AllowNew = False
        Me.GridEncomiendas.TableDescriptor.Appearance.AnyCell.Font.Facename = "Segoe UI"
        Me.GridEncomiendas.TableDescriptor.Appearance.AnyCell.Font.Size = 12.0!
        Me.GridEncomiendas.TableDescriptor.Appearance.AnyCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.GridEncomiendas.TableDescriptor.Appearance.AnyGroupCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.GridEncomiendas.TableDescriptor.Appearance.AnyGroupCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.GridEncomiendas.TableDescriptor.Appearance.AnyGroupCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer)))
        Me.GridEncomiendas.TableDescriptor.Appearance.AnyHeaderCell.Font.Size = 8.0!
        Me.GridEncomiendas.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.GridEncomiendas.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.GridEncomiendas.TableDescriptor.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        Me.GridEncomiendas.TableDescriptor.Appearance.AnySummaryCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.GridEncomiendas.TableDescriptor.Appearance.AnySummaryCell.Borders.Top = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.GridEncomiendas.TableDescriptor.Appearance.AnySummaryCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)))
        Me.GridEncomiendas.TableDescriptor.Appearance.ColumnHeaderCell.Font.Bold = True
        Me.GridEncomiendas.TableDescriptor.Appearance.ColumnHeaderCell.Font.Italic = False
        Me.GridEncomiendas.TableDescriptor.Appearance.ColumnHeaderCell.Font.Size = 8.0!
        Me.GridEncomiendas.TableDescriptor.Appearance.GroupCaptionCell.CellType = """ColumnHeader"""
        GridColumnDescriptor1.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.MappingName = "codigo"
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor1.Width = 0
        GridColumnDescriptor2.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.HeaderText = "Tipo"
        GridColumnDescriptor2.MappingName = "tipo"
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor2.Width = 105
        GridColumnDescriptor3.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.HeaderText = "Contenido"
        GridColumnDescriptor3.MappingName = "detalle"
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor3.Width = 219
        GridColumnDescriptor4.Appearance.AnyRecordFieldCell.CellType = "Currency"
        GridColumnDescriptor4.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
        GridColumnDescriptor4.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.HeaderText = "Cantidad"
        GridColumnDescriptor4.MappingName = "cantidad"
        GridColumnDescriptor4.SerializedImageArray = ""
        GridColumnDescriptor4.Width = 72
        GridColumnDescriptor5.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor5.HeaderImage = Nothing
        GridColumnDescriptor5.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor5.HeaderText = "U.M."
        GridColumnDescriptor5.MappingName = "unidad"
        GridColumnDescriptor5.SerializedImageArray = ""
        GridColumnDescriptor5.Width = 90
        GridColumnDescriptor6.Appearance.AnyRecordFieldCell.CellType = "Currency"
        GridColumnDescriptor6.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
        GridColumnDescriptor6.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor6.HeaderImage = Nothing
        GridColumnDescriptor6.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor6.HeaderText = "Total"
        GridColumnDescriptor6.MappingName = "importe"
        GridColumnDescriptor6.SerializedImageArray = ""
        GridColumnDescriptor6.Width = 104
        Me.GridEncomiendas.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6})
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
        GridSummaryColumnDescriptor1.DataMember = "importe"
        GridSummaryColumnDescriptor1.Format = "{Sum}"
        GridSummaryColumnDescriptor1.Name = "importe"
        GridSummaryColumnDescriptor1.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        GridSummaryRowDescriptor1.SummaryColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor() {GridSummaryColumnDescriptor1})
        GridSummaryRowDescriptor1.Title = "Total pagos: "
        Me.GridEncomiendas.TableDescriptor.SummaryRows.Add(GridSummaryRowDescriptor1)
        Me.GridEncomiendas.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.GridEncomiendas.TableDescriptor.TableOptions.RecordRowHeight = 20
        Me.GridEncomiendas.TableDescriptor.TopLevelGroupOptions.ShowCaption = False
        Me.GridEncomiendas.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("codigo"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipo"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("detalle"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("cantidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("unidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("importe")})
        Me.GridEncomiendas.Text = "GridGroupingControl2"
        Me.GridEncomiendas.VersionInfo = "12.4400.0.24"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.LinkLabel3)
        Me.GroupBox3.Controls.Add(Me.RadioButton2)
        Me.GroupBox3.Controls.Add(Me.RadioButton1)
        Me.GroupBox3.Controls.Add(Me.textPersona)
        Me.GroupBox3.Controls.Add(Me.txtruc)
        Me.GroupBox3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox3.Location = New System.Drawing.Point(345, 72)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(449, 77)
        Me.GroupBox3.TabIndex = 610
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Consignado"
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Checked = True
        Me.RadioButton2.Location = New System.Drawing.Point(146, 23)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(114, 17)
        Me.RadioButton2.TabIndex = 591
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Sin identificación"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(10, 23)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(119, 17)
        Me.RadioButton1.TabIndex = 590
        Me.RadioButton1.Text = "Con identificación"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'textPersona
        '
        Me.textPersona.BackColor = System.Drawing.Color.White
        Me.textPersona.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.textPersona.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.textPersona.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.textPersona.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textPersona.CornerRadius = 3
        Me.textPersona.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.textPersona.Enabled = False
        Me.textPersona.FarImage = CType(resources.GetObject("textPersona.FarImage"), System.Drawing.Image)
        Me.textPersona.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.textPersona.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textPersona.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.textPersona.Location = New System.Drawing.Point(128, 46)
        Me.textPersona.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.textPersona.MinimumSize = New System.Drawing.Size(14, 10)
        Me.textPersona.Name = "textPersona"
        Me.textPersona.ReadOnly = True
        Me.textPersona.Size = New System.Drawing.Size(310, 22)
        Me.textPersona.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.textPersona.TabIndex = 586
        '
        'txtruc
        '
        Me.txtruc.BackColor = System.Drawing.Color.White
        Me.txtruc.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtruc.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtruc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtruc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtruc.CornerRadius = 3
        Me.txtruc.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtruc.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtruc.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtruc.Location = New System.Drawing.Point(10, 46)
        Me.txtruc.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtruc.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtruc.Name = "txtruc"
        Me.txtruc.Size = New System.Drawing.Size(112, 23)
        Me.txtruc.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtruc.TabIndex = 587
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TextEmpresaPasajero)
        Me.GroupBox2.Controls.Add(Me.TextNumIdentrazon)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox2.Location = New System.Drawing.Point(345, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(449, 61)
        Me.GroupBox2.TabIndex = 609
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Remitente: Ingrese el dni o ruc de la persona:"
        '
        'TextEmpresaPasajero
        '
        Me.TextEmpresaPasajero.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextEmpresaPasajero.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TextEmpresaPasajero.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextEmpresaPasajero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextEmpresaPasajero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextEmpresaPasajero.CornerRadius = 3
        Me.TextEmpresaPasajero.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextEmpresaPasajero.Enabled = False
        Me.TextEmpresaPasajero.FarImage = CType(resources.GetObject("TextEmpresaPasajero.FarImage"), System.Drawing.Image)
        Me.TextEmpresaPasajero.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextEmpresaPasajero.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEmpresaPasajero.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextEmpresaPasajero.Location = New System.Drawing.Point(128, 23)
        Me.TextEmpresaPasajero.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextEmpresaPasajero.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextEmpresaPasajero.Name = "TextEmpresaPasajero"
        Me.TextEmpresaPasajero.ReadOnly = True
        Me.TextEmpresaPasajero.Size = New System.Drawing.Size(310, 22)
        Me.TextEmpresaPasajero.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextEmpresaPasajero.TabIndex = 590
        '
        'TextNumIdentrazon
        '
        Me.TextNumIdentrazon.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TextNumIdentrazon.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TextNumIdentrazon.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextNumIdentrazon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextNumIdentrazon.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNumIdentrazon.CornerRadius = 3
        Me.TextNumIdentrazon.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextNumIdentrazon.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNumIdentrazon.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextNumIdentrazon.Location = New System.Drawing.Point(10, 23)
        Me.TextNumIdentrazon.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextNumIdentrazon.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextNumIdentrazon.Name = "TextNumIdentrazon"
        Me.TextNumIdentrazon.ReadOnly = True
        Me.TextNumIdentrazon.Size = New System.Drawing.Size(112, 23)
        Me.TextNumIdentrazon.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextNumIdentrazon.TabIndex = 589
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ComboAgenciaOrigen)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(10, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(328, 61)
        Me.GroupBox1.TabIndex = 608
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Agencia de origen"
        '
        'ComboAgenciaOrigen
        '
        Me.ComboAgenciaOrigen.BackColor = System.Drawing.Color.White
        Me.ComboAgenciaOrigen.BeforeTouchSize = New System.Drawing.Size(287, 24)
        Me.ComboAgenciaOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboAgenciaOrigen.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboAgenciaOrigen.Location = New System.Drawing.Point(14, 23)
        Me.ComboAgenciaOrigen.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.ComboAgenciaOrigen.Name = "ComboAgenciaOrigen"
        Me.ComboAgenciaOrigen.Size = New System.Drawing.Size(287, 24)
        Me.ComboAgenciaOrigen.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboAgenciaOrigen.TabIndex = 587
        '
        'PictureLoad
        '
        Me.PictureLoad.BackColor = System.Drawing.Color.Transparent
        Me.PictureLoad.Image = CType(resources.GetObject("PictureLoad.Image"), System.Drawing.Image)
        Me.PictureLoad.Location = New System.Drawing.Point(729, 3)
        Me.PictureLoad.Name = "PictureLoad"
        Me.PictureLoad.Size = New System.Drawing.Size(42, 44)
        Me.PictureLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureLoad.TabIndex = 619
        Me.PictureLoad.TabStop = False
        Me.PictureLoad.Visible = False
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.ForeColor = System.Drawing.Color.SteelBlue
        Me.LinkLabel3.LinkColor = System.Drawing.Color.SteelBlue
        Me.LinkLabel3.Location = New System.Drawing.Point(398, 25)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(40, 13)
        Me.LinkLabel3.TabIndex = 593
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "Nuevo"
        '
        'FormCambiarDestino
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(156, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.BorderThickness = 2
        Me.CaptionBarHeight = 55
        Me.CaptionButtonColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(156, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.CaptionButtonHoverColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(156, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.CaptionForeColor = System.Drawing.Color.White
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(15, 12)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(32, 32)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.Location = New System.Drawing.Point(55, 8)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Text = "Encomiendas"
        CaptionLabel2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(141, Byte), Integer))
        CaptionLabel2.Location = New System.Drawing.Point(55, 22)
        CaptionLabel2.Name = "CaptionLabel2"
        CaptionLabel2.Size = New System.Drawing.Size(150, 24)
        CaptionLabel2.Text = "Modificar ruta de destino"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.CaptionLabels.Add(CaptionLabel2)
        Me.ClientSize = New System.Drawing.Size(806, 525)
        Me.Controls.Add(Me.PanelCrearEncomienda)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormCambiarDestino"
        Me.ShowIcon = False
        Me.Text = "Cambiar ruta de la encomienda"
        CType(Me.PanelCrearEncomienda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelCrearEncomienda.ResumeLayout(False)
        Me.PanelCrearEncomienda.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        CType(Me.TextfechaVcto.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextfechaVcto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CurrencyTextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox7.ResumeLayout(False)
        CType(Me.texHoraEnvio.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.texHoraEnvio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextFechaEnvio.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextFechaEnvio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        CType(Me.ComboAgenciaDestino, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pcLikeCategoria.ResumeLayout(False)
        Me.PCEmpresas.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.GradientPanel11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel11.ResumeLayout(False)
        CType(Me.GridEncomiendas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.textPersona, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtruc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.TextEmpresaPasajero, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextNumIdentrazon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.ComboAgenciaOrigen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureLoad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelCrearEncomienda As Tools.GradientPanel
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents GroupBox8 As GroupBox
    Friend WithEvents TextfechaVcto As Tools.DateTimePickerAdv
    Friend WithEvents CurrencyTextBox1 As Tools.CurrencyTextBox
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents texHoraEnvio As Tools.DateTimePickerAdv
    Friend WithEvents TextFechaEnvio As Tools.DateTimePickerAdv
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents ComboAgenciaDestino As Tools.ComboBoxAdv
    Private WithEvents pcLikeCategoria As PopupControlContainer
    Friend WithEvents LsvProveedor As ListView
    Friend WithEvents colID As ColumnHeader
    Friend WithEvents colCliente As ColumnHeader
    Friend WithEvents colRUC As ColumnHeader
    Friend WithEvents colTipoDoc As ColumnHeader
    Private WithEvents PCEmpresas As PopupControlContainer
    Friend WithEvents ListEmpresas As ListView
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents RoundButton22 As RoundButton2
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents GradientPanel11 As Tools.GradientPanel
    Friend WithEvents GridEncomiendas As Grid.Grouping.GridGroupingControl
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents textPersona As Tools.TextBoxExt
    Friend WithEvents txtruc As Tools.TextBoxExt
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents TextEmpresaPasajero As Tools.TextBoxExt
    Friend WithEvents TextNumIdentrazon As Tools.TextBoxExt
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents ComboAgenciaOrigen As Tools.ComboBoxAdv
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents PictureLoad As PictureBox
    Friend WithEvents LinkLabel3 As LinkLabel
End Class

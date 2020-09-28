<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormOfertaVentas
    Inherits Syncfusion.Windows.Forms.MetroForm

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
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormOfertaVentas))
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Dim CaptionLabel2 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextNomCorto = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextDescripcion = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextInicio = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.TextFinaliza = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.ComboTipo = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextPrecioVenta = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.GridOferta = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.ButtonAdv19 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.Line21 = New Helios.Cont.Presentation.WinForm.Line2()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TextCodigo = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.TextNomCorto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextDescripcion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextInicio.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextFinaliza, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextFinaliza.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextPrecioVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridOferta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.TextCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(38, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre corto"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(38, 116)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 14)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "descripción"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(38, 187)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 14)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Tipo"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(38, 238)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 14)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Fecha Inicio"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(138, 238)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 14)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Fecha finaliza"
        '
        'TextNomCorto
        '
        Me.TextNomCorto.BackColor = System.Drawing.Color.White
        Me.TextNomCorto.BeforeTouchSize = New System.Drawing.Size(250, 22)
        Me.TextNomCorto.BorderColor = System.Drawing.Color.Silver
        Me.TextNomCorto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextNomCorto.CornerRadius = 4
        Me.TextNomCorto.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextNomCorto.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNomCorto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextNomCorto.Location = New System.Drawing.Point(41, 88)
        Me.TextNomCorto.MaxLength = 80
        Me.TextNomCorto.Metrocolor = System.Drawing.Color.YellowGreen
        Me.TextNomCorto.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextNomCorto.Name = "TextNomCorto"
        Me.TextNomCorto.Size = New System.Drawing.Size(250, 22)
        Me.TextNomCorto.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextNomCorto.TabIndex = 5
        '
        'TextDescripcion
        '
        Me.TextDescripcion.BackColor = System.Drawing.Color.White
        Me.TextDescripcion.BeforeTouchSize = New System.Drawing.Size(250, 22)
        Me.TextDescripcion.BorderColor = System.Drawing.Color.Silver
        Me.TextDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextDescripcion.CornerRadius = 4
        Me.TextDescripcion.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextDescripcion.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextDescripcion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextDescripcion.Location = New System.Drawing.Point(41, 135)
        Me.TextDescripcion.MaxLength = 180
        Me.TextDescripcion.Metrocolor = System.Drawing.Color.YellowGreen
        Me.TextDescripcion.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextDescripcion.Multiline = True
        Me.TextDescripcion.Name = "TextDescripcion"
        Me.TextDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextDescripcion.Size = New System.Drawing.Size(250, 44)
        Me.TextDescripcion.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextDescripcion.TabIndex = 6
        '
        'TextInicio
        '
        Me.TextInicio.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextInicio.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.TextInicio.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextInicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TextInicio.Calendar.AllowMultipleSelection = False
        Me.TextInicio.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextInicio.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextInicio.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.TextInicio.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextInicio.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TextInicio.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.TextInicio.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextInicio.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextInicio.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TextInicio.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.TextInicio.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.TextInicio.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.TextInicio.Calendar.HighlightColor = System.Drawing.Color.White
        Me.TextInicio.Calendar.Iso8601CalenderFormat = False
        Me.TextInicio.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.TextInicio.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextInicio.Calendar.Name = "monthCalendar"
        Me.TextInicio.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.TextInicio.Calendar.SelectedDates = New Date(-1) {}
        Me.TextInicio.Calendar.Size = New System.Drawing.Size(86, 174)
        Me.TextInicio.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.TextInicio.Calendar.TabIndex = 0
        Me.TextInicio.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.TextInicio.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.TextInicio.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextInicio.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.TextInicio.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.TextInicio.Calendar.NoneButton.IsBackStageButton = False
        Me.TextInicio.Calendar.NoneButton.Location = New System.Drawing.Point(12, 0)
        Me.TextInicio.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.TextInicio.Calendar.NoneButton.Text = "None"
        Me.TextInicio.Calendar.NoneButton.UseVisualStyle = True
        Me.TextInicio.Calendar.NoneButton.Visible = False
        '
        '
        '
        Me.TextInicio.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.TextInicio.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextInicio.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.TextInicio.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.TextInicio.Calendar.TodayButton.IsBackStageButton = False
        Me.TextInicio.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.TextInicio.Calendar.TodayButton.Size = New System.Drawing.Size(86, 20)
        Me.TextInicio.Calendar.TodayButton.Text = "Today"
        Me.TextInicio.Calendar.TodayButton.UseVisualStyle = True
        Me.TextInicio.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextInicio.CalendarForeColor = System.Drawing.SystemColors.ControlText
        Me.TextInicio.CalendarSize = New System.Drawing.Size(189, 176)
        Me.TextInicio.Checked = False
        Me.TextInicio.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.TextInicio.CustomFormat = "dd/MM/yyyy"
        Me.TextInicio.DropDownImage = Nothing
        Me.TextInicio.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextInicio.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextInicio.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.TextInicio.EnableNullDate = False
        Me.TextInicio.EnableNullKeys = False
        Me.TextInicio.ForeColor = System.Drawing.Color.Black
        Me.TextInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TextInicio.Location = New System.Drawing.Point(41, 260)
        Me.TextInicio.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextInicio.MinValue = New Date(CType(0, Long))
        Me.TextInicio.Name = "TextInicio"
        Me.TextInicio.ShowCheckBox = False
        Me.TextInicio.ShowDropButton = False
        Me.TextInicio.Size = New System.Drawing.Size(90, 20)
        Me.TextInicio.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.TextInicio.TabIndex = 506
        Me.TextInicio.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'TextFinaliza
        '
        Me.TextFinaliza.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextFinaliza.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.TextFinaliza.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextFinaliza.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TextFinaliza.Calendar.AllowMultipleSelection = False
        Me.TextFinaliza.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextFinaliza.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextFinaliza.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.TextFinaliza.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFinaliza.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TextFinaliza.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.TextFinaliza.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextFinaliza.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextFinaliza.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TextFinaliza.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.TextFinaliza.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.TextFinaliza.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.TextFinaliza.Calendar.HighlightColor = System.Drawing.Color.White
        Me.TextFinaliza.Calendar.Iso8601CalenderFormat = False
        Me.TextFinaliza.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.TextFinaliza.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFinaliza.Calendar.Name = "monthCalendar"
        Me.TextFinaliza.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.TextFinaliza.Calendar.SelectedDates = New Date(-1) {}
        Me.TextFinaliza.Calendar.Size = New System.Drawing.Size(86, 174)
        Me.TextFinaliza.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.TextFinaliza.Calendar.TabIndex = 0
        Me.TextFinaliza.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.TextFinaliza.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.TextFinaliza.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFinaliza.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.TextFinaliza.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.TextFinaliza.Calendar.NoneButton.IsBackStageButton = False
        Me.TextFinaliza.Calendar.NoneButton.Location = New System.Drawing.Point(12, 0)
        Me.TextFinaliza.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.TextFinaliza.Calendar.NoneButton.Text = "None"
        Me.TextFinaliza.Calendar.NoneButton.UseVisualStyle = True
        Me.TextFinaliza.Calendar.NoneButton.Visible = False
        '
        '
        '
        Me.TextFinaliza.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.TextFinaliza.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFinaliza.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.TextFinaliza.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.TextFinaliza.Calendar.TodayButton.IsBackStageButton = False
        Me.TextFinaliza.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.TextFinaliza.Calendar.TodayButton.Size = New System.Drawing.Size(86, 20)
        Me.TextFinaliza.Calendar.TodayButton.Text = "Today"
        Me.TextFinaliza.Calendar.TodayButton.UseVisualStyle = True
        Me.TextFinaliza.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextFinaliza.CalendarForeColor = System.Drawing.SystemColors.ControlText
        Me.TextFinaliza.CalendarSize = New System.Drawing.Size(189, 176)
        Me.TextFinaliza.Checked = False
        Me.TextFinaliza.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.TextFinaliza.CustomFormat = "dd/MM/yyyy"
        Me.TextFinaliza.DropDownImage = Nothing
        Me.TextFinaliza.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFinaliza.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFinaliza.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.TextFinaliza.EnableNullDate = False
        Me.TextFinaliza.EnableNullKeys = False
        Me.TextFinaliza.ForeColor = System.Drawing.Color.Black
        Me.TextFinaliza.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TextFinaliza.Location = New System.Drawing.Point(141, 260)
        Me.TextFinaliza.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFinaliza.MinValue = New Date(CType(0, Long))
        Me.TextFinaliza.Name = "TextFinaliza"
        Me.TextFinaliza.ShowCheckBox = False
        Me.TextFinaliza.ShowDropButton = False
        Me.TextFinaliza.Size = New System.Drawing.Size(90, 20)
        Me.TextFinaliza.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.TextFinaliza.TabIndex = 507
        Me.TextFinaliza.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'ComboTipo
        '
        Me.ComboTipo.BackColor = System.Drawing.Color.White
        Me.ComboTipo.BeforeTouchSize = New System.Drawing.Size(250, 21)
        Me.ComboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboTipo.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboTipo.Items.AddRange(New Object() {"BASICO", "INTERMEDIO", "PREMIUM"})
        Me.ComboTipo.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboTipo, "BASICO"))
        Me.ComboTipo.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboTipo, "INTERMEDIO"))
        Me.ComboTipo.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboTipo, "PREMIUM"))
        Me.ComboTipo.Location = New System.Drawing.Point(41, 208)
        Me.ComboTipo.MetroBorderColor = System.Drawing.Color.Silver
        Me.ComboTipo.Name = "ComboTipo"
        Me.ComboTipo.Size = New System.Drawing.Size(250, 21)
        Me.ComboTipo.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboTipo.TabIndex = 508
        Me.ComboTipo.Text = "BASICO"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(38, 289)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 14)
        Me.Label6.TabIndex = 509
        Me.Label6.Text = "Precio de venta"
        '
        'TextPrecioVenta
        '
        Me.TextPrecioVenta.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextPrecioVenta.BeforeTouchSize = New System.Drawing.Size(250, 22)
        Me.TextPrecioVenta.BorderColor = System.Drawing.Color.Silver
        Me.TextPrecioVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextPrecioVenta.CurrencyDecimalDigits = 3
        Me.TextPrecioVenta.CurrencySymbol = ""
        Me.TextPrecioVenta.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextPrecioVenta.DecimalValue = New Decimal(New Integer() {0, 0, 0, 196608})
        Me.TextPrecioVenta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextPrecioVenta.Location = New System.Drawing.Point(41, 308)
        Me.TextPrecioVenta.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextPrecioVenta.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextPrecioVenta.Name = "TextPrecioVenta"
        Me.TextPrecioVenta.NullString = ""
        Me.TextPrecioVenta.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextPrecioVenta.ReadOnlyBackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextPrecioVenta.Size = New System.Drawing.Size(90, 22)
        Me.TextPrecioVenta.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextPrecioVenta.TabIndex = 510
        Me.TextPrecioVenta.Text = "0.000"
        '
        'GridOferta
        '
        Me.GridOferta.Appearance.AlternateRecordFieldCell.Font.Size = 8.0!
        Me.GridOferta.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        Me.GridOferta.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.GridOferta.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GridOferta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridOferta.FreezeCaption = False
        Me.GridOferta.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.GridOferta.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2010Blue
        Me.GridOferta.Location = New System.Drawing.Point(0, 0)
        Me.GridOferta.Name = "GridOferta"
        Me.GridOferta.Size = New System.Drawing.Size(386, 232)
        Me.GridOferta.TabIndex = 512
        Me.GridOferta.TableDescriptor.AllowNew = False
        Me.GridOferta.TableDescriptor.Appearance.AnyCell.Font.Facename = "Segoe UI"
        Me.GridOferta.TableDescriptor.Appearance.AnyCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.GridOferta.TableDescriptor.Appearance.AnyGroupCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.GridOferta.TableDescriptor.Appearance.AnyGroupCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.GridOferta.TableDescriptor.Appearance.AnyGroupCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer)))
        Me.GridOferta.TableDescriptor.Appearance.AnyHeaderCell.Font.Size = 8.0!
        Me.GridOferta.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.GridOferta.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.GridOferta.TableDescriptor.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        Me.GridOferta.TableDescriptor.Appearance.AnySummaryCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.GridOferta.TableDescriptor.Appearance.AnySummaryCell.Borders.Top = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.GridOferta.TableDescriptor.Appearance.AnySummaryCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)))
        Me.GridOferta.TableDescriptor.Appearance.ColumnHeaderCell.Font.Bold = True
        Me.GridOferta.TableDescriptor.Appearance.ColumnHeaderCell.Font.Italic = False
        Me.GridOferta.TableDescriptor.Appearance.ColumnHeaderCell.Font.Size = 8.0!
        Me.GridOferta.TableDescriptor.Appearance.GroupCaptionCell.CellType = """ColumnHeader"""
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.MappingName = "iditem"
        GridColumnDescriptor1.ReadOnly = True
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor1.Width = 32
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.MappingName = "detalle"
        GridColumnDescriptor2.ReadOnly = True
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor2.Width = 196
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.MappingName = "UM"
        GridColumnDescriptor3.ReadOnly = True
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor4.Appearance.AnyRecordFieldCell.CellType = "Currency"
        GridColumnDescriptor4.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
        GridColumnDescriptor4.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer)))
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.MappingName = "cantidad"
        GridColumnDescriptor4.SerializedImageArray = ""
        Me.GridOferta.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4})
        Me.GridOferta.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.GridOferta.TableDescriptor.TableOptions.RecordRowHeight = 20
        Me.GridOferta.TableDescriptor.TopLevelGroupOptions.ShowCaption = False
        Me.GridOferta.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("detalle"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("UM"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("cantidad")})
        Me.GridOferta.Text = "GridGroupingControl2"
        Me.GridOferta.VersionInfo = "12.4400.0.24"
        '
        'ButtonAdv19
        '
        Me.ButtonAdv19.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv19.BackColor = System.Drawing.SystemColors.Highlight
        Me.ButtonAdv19.BeforeTouchSize = New System.Drawing.Size(114, 31)
        Me.ButtonAdv19.Font = New System.Drawing.Font("Corbel", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv19.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv19.Image = CType(resources.GetObject("ButtonAdv19.Image"), System.Drawing.Image)
        Me.ButtonAdv19.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv19.IsBackStageButton = False
        Me.ButtonAdv19.Location = New System.Drawing.Point(486, 299)
        Me.ButtonAdv19.Name = "ButtonAdv19"
        Me.ButtonAdv19.Size = New System.Drawing.Size(114, 31)
        Me.ButtonAdv19.TabIndex = 513
        Me.ButtonAdv19.Text = "       Grabar"
        Me.ButtonAdv19.UseVisualStyle = True
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.LinkColor = System.Drawing.SystemColors.Highlight
        Me.LinkLabel1.Location = New System.Drawing.Point(338, 20)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(92, 14)
        Me.LinkLabel1.TabIndex = 514
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Agregar producto"
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BorderColor = System.Drawing.SystemColors.Highlight
        Me.GradientPanel1.BorderSides = System.Windows.Forms.Border3DSide.Top
        Me.GradientPanel1.BorderSingle = System.Windows.Forms.ButtonBorderStyle.Dotted
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(740, 10)
        Me.GradientPanel1.TabIndex = 515
        '
        'Line21
        '
        Me.Line21.LineColor = System.Drawing.Color.WhiteSmoke
        Me.Line21.Location = New System.Drawing.Point(310, 12)
        Me.Line21.Name = "Line21"
        Me.Line21.Size = New System.Drawing.Size(1, 326)
        Me.Line21.TabIndex = 511
        Me.Line21.Text = "Line21"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.GridOferta)
        Me.Panel1.Location = New System.Drawing.Point(340, 46)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(388, 234)
        Me.Panel1.TabIndex = 516
        '
        'TextCodigo
        '
        Me.TextCodigo.BackColor = System.Drawing.Color.White
        Me.TextCodigo.BeforeTouchSize = New System.Drawing.Size(250, 22)
        Me.TextCodigo.BorderColor = System.Drawing.Color.Silver
        Me.TextCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextCodigo.CornerRadius = 4
        Me.TextCodigo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextCodigo.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextCodigo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextCodigo.Location = New System.Drawing.Point(41, 40)
        Me.TextCodigo.MaxLength = 20
        Me.TextCodigo.Metrocolor = System.Drawing.Color.YellowGreen
        Me.TextCodigo.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextCodigo.Name = "TextCodigo"
        Me.TextCodigo.Size = New System.Drawing.Size(250, 22)
        Me.TextCodigo.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextCodigo.TabIndex = 518
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(38, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 14)
        Me.Label7.TabIndex = 517
        Me.Label7.Text = "Codigo"
        '
        'FormOfertaVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.SystemColors.HotTrack
        Me.CaptionBarHeight = 55
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(15, 11)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(35, 35)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.DimGray
        CaptionLabel1.Location = New System.Drawing.Point(55, 8)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Text = "Nuevo ingreso"
        CaptionLabel2.Font = New System.Drawing.Font("Calibri Light", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel2.ForeColor = System.Drawing.SystemColors.Highlight
        CaptionLabel2.Location = New System.Drawing.Point(55, 25)
        CaptionLabel2.Name = "CaptionLabel2"
        CaptionLabel2.Size = New System.Drawing.Size(200, 24)
        CaptionLabel2.Text = "Ofertas"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.CaptionLabels.Add(CaptionLabel2)
        Me.ClientSize = New System.Drawing.Size(740, 341)
        Me.Controls.Add(Me.TextCodigo)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.ButtonAdv19)
        Me.Controls.Add(Me.Line21)
        Me.Controls.Add(Me.TextPrecioVenta)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ComboTipo)
        Me.Controls.Add(Me.TextFinaliza)
        Me.Controls.Add(Me.TextInicio)
        Me.Controls.Add(Me.TextDescripcion)
        Me.Controls.Add(Me.TextNomCorto)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FormOfertaVentas"
        Me.ShowIcon = False
        Me.ShowMaximizeBox = False
        Me.ShowMinimizeBox = False
        CType(Me.TextNomCorto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextDescripcion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextInicio.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextFinaliza.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextFinaliza, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextPrecioVenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridOferta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.TextCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TextNomCorto As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents TextDescripcion As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents TextInicio As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents TextFinaliza As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents ComboTipo As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label6 As Label
    Friend WithEvents TextPrecioVenta As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Line21 As Line2
    Friend WithEvents GridOferta As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents ButtonAdv19 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TextCodigo As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label7 As Label
End Class

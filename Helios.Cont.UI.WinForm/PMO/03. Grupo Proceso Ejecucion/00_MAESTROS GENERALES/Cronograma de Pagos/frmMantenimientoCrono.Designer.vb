<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMantenimientoCrono
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMantenimientoCrono))
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv15 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtGlosa = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtImporteME = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.txtImporteMN = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.txtProveedor = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblIdCronograma = New System.Windows.Forms.Label()
        Me.txtFecha = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtfechapago = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        CType(Me.txtGlosa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtImporteME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtImporteMN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtfechapago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtfechapago.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.Sienna
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(65, 33)
        Me.ButtonAdv1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(144, 231)
        Me.ButtonAdv1.MetroColor = System.Drawing.Color.GreenYellow
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(65, 33)
        Me.ButtonAdv1.TabIndex = 537
        Me.ButtonAdv1.Text = "Cancelar"
        Me.ButtonAdv1.UseVisualStyle = True
        Me.ButtonAdv1.UseVisualStyleBackColor = False
        '
        'ButtonAdv15
        '
        Me.ButtonAdv15.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv15.BackColor = System.Drawing.Color.Sienna
        Me.ButtonAdv15.BeforeTouchSize = New System.Drawing.Size(65, 33)
        Me.ButtonAdv15.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv15.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv15.IsBackStageButton = False
        Me.ButtonAdv15.Location = New System.Drawing.Point(56, 231)
        Me.ButtonAdv15.MetroColor = System.Drawing.Color.GreenYellow
        Me.ButtonAdv15.Name = "ButtonAdv15"
        Me.ButtonAdv15.Size = New System.Drawing.Size(65, 33)
        Me.ButtonAdv15.TabIndex = 536
        Me.ButtonAdv15.Text = "Grabar"
        Me.ButtonAdv15.UseVisualStyle = True
        Me.ButtonAdv15.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(19, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 12)
        Me.Label1.TabIndex = 534
        Me.Label1.Text = "MOTIVO"
        '
        'txtGlosa
        '
        Me.txtGlosa.BackColor = System.Drawing.Color.White
        Me.txtGlosa.BeforeTouchSize = New System.Drawing.Size(359, 22)
        Me.txtGlosa.BorderColor = System.Drawing.Color.DarkGray
        Me.txtGlosa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGlosa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtGlosa.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtGlosa.Location = New System.Drawing.Point(21, 117)
        Me.txtGlosa.Metrocolor = System.Drawing.Color.DarkGray
        Me.txtGlosa.Multiline = True
        Me.txtGlosa.Name = "txtGlosa"
        Me.txtGlosa.ReadOnly = True
        Me.txtGlosa.Size = New System.Drawing.Size(359, 39)
        Me.txtGlosa.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtGlosa.TabIndex = 533
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(137, 162)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 12)
        Me.Label4.TabIndex = 532
        Me.Label4.Text = "IMPORTE ME"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(19, 162)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 12)
        Me.Label3.TabIndex = 531
        Me.Label3.Text = "IMPORTE MN"
        '
        'txtImporteME
        '
        Me.txtImporteME.BackColor = System.Drawing.Color.White
        Me.txtImporteME.BeforeTouchSize = New System.Drawing.Size(100, 22)
        Me.txtImporteME.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtImporteME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtImporteME.DecimalPlaces = 2
        Me.txtImporteME.Location = New System.Drawing.Point(139, 183)
        Me.txtImporteME.Maximum = New Decimal(New Integer() {-1304428544, 434162106, 542, 0})
        Me.txtImporteME.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtImporteME.Name = "txtImporteME"
        Me.txtImporteME.Size = New System.Drawing.Size(100, 22)
        Me.txtImporteME.TabIndex = 530
        Me.txtImporteME.TabStop = False
        Me.txtImporteME.ThousandsSeparator = True
        Me.txtImporteME.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'txtImporteMN
        '
        Me.txtImporteMN.BackColor = System.Drawing.Color.White
        Me.txtImporteMN.BeforeTouchSize = New System.Drawing.Size(100, 22)
        Me.txtImporteMN.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtImporteMN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtImporteMN.DecimalPlaces = 2
        Me.txtImporteMN.Location = New System.Drawing.Point(21, 183)
        Me.txtImporteMN.Maximum = New Decimal(New Integer() {-1304428544, 434162106, 542, 0})
        Me.txtImporteMN.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtImporteMN.Name = "txtImporteMN"
        Me.txtImporteMN.Size = New System.Drawing.Size(100, 22)
        Me.txtImporteMN.TabIndex = 529
        Me.txtImporteMN.TabStop = False
        Me.txtImporteMN.ThousandsSeparator = True
        Me.txtImporteMN.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'txtProveedor
        '
        Me.txtProveedor.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtProveedor.BeforeTouchSize = New System.Drawing.Size(359, 22)
        Me.txtProveedor.BorderColor = System.Drawing.Color.DarkGray
        Me.txtProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProveedor.CornerRadius = 5
        Me.txtProveedor.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtProveedor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtProveedor.Location = New System.Drawing.Point(21, 28)
        Me.txtProveedor.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtProveedor.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.NearImage = CType(resources.GetObject("txtProveedor.NearImage"), System.Drawing.Image)
        Me.txtProveedor.ReadOnly = True
        Me.txtProveedor.Size = New System.Drawing.Size(359, 22)
        Me.txtProveedor.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtProveedor.TabIndex = 518
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(19, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 12)
        Me.Label7.TabIndex = 517
        Me.Label7.Text = "IDENTIFICACION"
        '
        'lblIdCronograma
        '
        Me.lblIdCronograma.AutoSize = True
        Me.lblIdCronograma.Location = New System.Drawing.Point(386, 35)
        Me.lblIdCronograma.Name = "lblIdCronograma"
        Me.lblIdCronograma.Size = New System.Drawing.Size(40, 13)
        Me.lblIdCronograma.TabIndex = 538
        Me.lblIdCronograma.Text = "Label2"
        Me.lblIdCronograma.Visible = False
        '
        'txtFecha
        '
        Me.txtFecha.BackColor = System.Drawing.Color.DarkGoldenrod
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
        Me.txtFecha.Calendar.Size = New System.Drawing.Size(129, 174)
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
        Me.txtFecha.Calendar.NoneButton.Location = New System.Drawing.Point(57, 0)
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
        Me.txtFecha.Calendar.TodayButton.Size = New System.Drawing.Size(57, 20)
        Me.txtFecha.Calendar.TodayButton.Text = "Today"
        Me.txtFecha.Calendar.TodayButton.UseVisualStyle = True
        Me.txtFecha.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha.CalendarForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFecha.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtFecha.Checked = False
        Me.txtFecha.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFecha.CustomFormat = "dd/MM/yyyy HH:mm:ss tt"
        Me.txtFecha.DropDownImage = Nothing
        Me.txtFecha.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecha.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecha.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtFecha.ForeColor = System.Drawing.Color.White
        Me.txtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFecha.Location = New System.Drawing.Point(21, 72)
        Me.txtFecha.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecha.MinValue = New Date(CType(0, Long))
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ShowCheckBox = False
        Me.txtFecha.ShowDropButton = False
        Me.txtFecha.Size = New System.Drawing.Size(133, 20)
        Me.txtFecha.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFecha.TabIndex = 539
        Me.txtFecha.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(19, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 12)
        Me.Label2.TabIndex = 540
        Me.Label2.Text = "FECHA"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(179, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 12)
        Me.Label5.TabIndex = 542
        Me.Label5.Text = "FECHA PAGO"
        '
        'txtfechapago
        '
        Me.txtfechapago.BackColor = System.Drawing.Color.DarkGoldenrod
        Me.txtfechapago.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtfechapago.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtfechapago.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtfechapago.Calendar.AllowMultipleSelection = False
        Me.txtfechapago.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtfechapago.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtfechapago.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtfechapago.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtfechapago.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtfechapago.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtfechapago.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtfechapago.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfechapago.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtfechapago.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtfechapago.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtfechapago.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtfechapago.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtfechapago.Calendar.Iso8601CalenderFormat = False
        Me.txtfechapago.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtfechapago.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtfechapago.Calendar.Name = "monthCalendar"
        Me.txtfechapago.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtfechapago.Calendar.SelectedDates = New Date(-1) {}
        Me.txtfechapago.Calendar.Size = New System.Drawing.Size(129, 174)
        Me.txtfechapago.Calendar.SizeToFit = True
        Me.txtfechapago.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtfechapago.Calendar.TabIndex = 0
        Me.txtfechapago.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtfechapago.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtfechapago.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtfechapago.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtfechapago.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtfechapago.Calendar.NoneButton.IsBackStageButton = False
        Me.txtfechapago.Calendar.NoneButton.Location = New System.Drawing.Point(57, 0)
        Me.txtfechapago.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtfechapago.Calendar.NoneButton.Text = "None"
        Me.txtfechapago.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtfechapago.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtfechapago.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtfechapago.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtfechapago.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtfechapago.Calendar.TodayButton.IsBackStageButton = False
        Me.txtfechapago.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtfechapago.Calendar.TodayButton.Size = New System.Drawing.Size(57, 20)
        Me.txtfechapago.Calendar.TodayButton.Text = "Today"
        Me.txtfechapago.Calendar.TodayButton.UseVisualStyle = True
        Me.txtfechapago.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfechapago.CalendarForeColor = System.Drawing.SystemColors.ControlText
        Me.txtfechapago.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtfechapago.Checked = False
        Me.txtfechapago.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtfechapago.CustomFormat = "dd/MM/yyyy HH:mm:ss tt"
        Me.txtfechapago.DropDownImage = Nothing
        Me.txtfechapago.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtfechapago.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtfechapago.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtfechapago.ForeColor = System.Drawing.Color.White
        Me.txtfechapago.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtfechapago.Location = New System.Drawing.Point(181, 72)
        Me.txtfechapago.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtfechapago.MinValue = New Date(CType(0, Long))
        Me.txtfechapago.Name = "txtfechapago"
        Me.txtfechapago.ShowCheckBox = False
        Me.txtfechapago.ShowDropButton = False
        Me.txtfechapago.Size = New System.Drawing.Size(133, 20)
        Me.txtfechapago.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtfechapago.TabIndex = 541
        Me.txtfechapago.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'frmMantenimientoCrono
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.Color.SteelBlue
        Me.CaptionBarHeight = 50
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.White
        CaptionLabel1.Location = New System.Drawing.Point(55, 15)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Text = "Mantenimiento"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(389, 269)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtfechapago)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtFecha)
        Me.Controls.Add(Me.lblIdCronograma)
        Me.Controls.Add(Me.ButtonAdv1)
        Me.Controls.Add(Me.ButtonAdv15)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtProveedor)
        Me.Controls.Add(Me.txtGlosa)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtImporteME)
        Me.Controls.Add(Me.txtImporteMN)
        Me.Name = "frmMantenimientoCrono"
        Me.ShowIcon = False
        Me.ShowMouseOver = True
        Me.Text = ""
        CType(Me.txtGlosa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtImporteME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtImporteMN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtfechapago.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtfechapago, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents ButtonAdv15 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtGlosa As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtImporteME As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents txtImporteMN As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents txtProveedor As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblIdCronograma As System.Windows.Forms.Label
    Friend WithEvents txtFecha As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtfechapago As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
End Class

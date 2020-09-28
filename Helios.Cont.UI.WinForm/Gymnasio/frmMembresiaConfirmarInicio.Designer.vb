<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMembresiaConfirmarInicio
    Inherits frmMaster

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMembresiaConfirmarInicio))
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Dim CaptionLabel2 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TXTcLIENTE = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFechaInicio = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.GradientPanel11 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv6 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.txtdni = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtFechaVcto = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.GradientPanel3 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.txtMembresia = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtDuracion = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtValDuracion = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtValido = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.cboPeriodicida = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.txtCongela_dia = New System.Windows.Forms.NumericUpDown()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtInfoExtra = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.TXTcLIENTE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaInicio.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtdni, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaVcto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaVcto.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel3.SuspendLayout()
        CType(Me.txtMembresia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDuracion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValDuracion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValido, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValido.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboPeriodicida, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCongela_dia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtInfoExtra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(22, 17)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(81, 13)
        Me.Label21.TabIndex = 1
        Me.Label21.Text = "Cliente / Socio"
        '
        'TXTcLIENTE
        '
        Me.TXTcLIENTE.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TXTcLIENTE.BeforeTouchSize = New System.Drawing.Size(361, 20)
        Me.TXTcLIENTE.BorderColor = System.Drawing.Color.Silver
        Me.TXTcLIENTE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXTcLIENTE.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TXTcLIENTE.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTcLIENTE.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TXTcLIENTE.Location = New System.Drawing.Point(25, 37)
        Me.TXTcLIENTE.MaxLength = 10
        Me.TXTcLIENTE.Metrocolor = System.Drawing.Color.YellowGreen
        Me.TXTcLIENTE.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TXTcLIENTE.Name = "TXTcLIENTE"
        Me.TXTcLIENTE.ReadOnly = True
        Me.TXTcLIENTE.Size = New System.Drawing.Size(321, 20)
        Me.TXTcLIENTE.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TXTcLIENTE.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(491, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Inicio de membresia"
        '
        'txtFechaInicio
        '
        Me.txtFechaInicio.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtFechaInicio.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtFechaInicio.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaInicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtFechaInicio.Calendar.AllowMultipleSelection = False
        Me.txtFechaInicio.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaInicio.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaInicio.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechaInicio.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaInicio.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFechaInicio.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtFechaInicio.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFechaInicio.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaInicio.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaInicio.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtFechaInicio.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtFechaInicio.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtFechaInicio.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtFechaInicio.Calendar.Iso8601CalenderFormat = False
        Me.txtFechaInicio.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaInicio.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaInicio.Calendar.Name = "monthCalendar"
        Me.txtFechaInicio.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtFechaInicio.Calendar.SelectedDates = New Date(-1) {}
        Me.txtFechaInicio.Calendar.Size = New System.Drawing.Size(129, 174)
        Me.txtFechaInicio.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaInicio.Calendar.TabIndex = 0
        Me.txtFechaInicio.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtFechaInicio.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaInicio.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaInicio.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaInicio.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaInicio.Calendar.NoneButton.IsBackStageButton = False
        Me.txtFechaInicio.Calendar.NoneButton.Location = New System.Drawing.Point(57, 0)
        Me.txtFechaInicio.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtFechaInicio.Calendar.NoneButton.Text = "None"
        Me.txtFechaInicio.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtFechaInicio.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaInicio.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaInicio.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaInicio.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaInicio.Calendar.TodayButton.IsBackStageButton = False
        Me.txtFechaInicio.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaInicio.Calendar.TodayButton.Size = New System.Drawing.Size(57, 20)
        Me.txtFechaInicio.Calendar.TodayButton.Text = "Today"
        Me.txtFechaInicio.Calendar.TodayButton.UseVisualStyle = True
        Me.txtFechaInicio.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaInicio.CalendarForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaInicio.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtFechaInicio.Checked = False
        Me.txtFechaInicio.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechaInicio.CustomFormat = "dd/MM/yyyy"
        Me.txtFechaInicio.DropDownImage = Nothing
        Me.txtFechaInicio.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaInicio.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaInicio.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtFechaInicio.ForeColor = System.Drawing.Color.Black
        Me.txtFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFechaInicio.Location = New System.Drawing.Point(495, 64)
        Me.txtFechaInicio.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaInicio.MinValue = New Date(CType(0, Long))
        Me.txtFechaInicio.Name = "txtFechaInicio"
        Me.txtFechaInicio.ShowCheckBox = False
        Me.txtFechaInicio.Size = New System.Drawing.Size(133, 20)
        Me.txtFechaInicio.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaInicio.TabIndex = 506
        Me.txtFechaInicio.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'GradientPanel11
        '
        Me.GradientPanel11.BackColor = System.Drawing.Color.White
        Me.GradientPanel11.BorderColor = System.Drawing.Color.OrangeRed
        Me.GradientPanel11.BorderSides = System.Windows.Forms.Border3DSide.Top
        Me.GradientPanel11.BorderSingle = System.Windows.Forms.ButtonBorderStyle.Dotted
        Me.GradientPanel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel11.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel11.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel11.Name = "GradientPanel11"
        Me.GradientPanel11.Size = New System.Drawing.Size(716, 10)
        Me.GradientPanel11.TabIndex = 507
        '
        'ButtonAdv6
        '
        Me.ButtonAdv6.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv6.BackColor = System.Drawing.Color.OrangeRed
        Me.ButtonAdv6.BeforeTouchSize = New System.Drawing.Size(107, 41)
        Me.ButtonAdv6.Font = New System.Drawing.Font("Corbel", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv6.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv6.IsBackStageButton = False
        Me.ButtonAdv6.Location = New System.Drawing.Point(25, 65)
        Me.ButtonAdv6.Name = "ButtonAdv6"
        Me.ButtonAdv6.Size = New System.Drawing.Size(107, 41)
        Me.ButtonAdv6.TabIndex = 3
        Me.ButtonAdv6.Text = "Grabar"
        Me.ButtonAdv6.UseVisualStyle = True
        '
        'txtdni
        '
        Me.txtdni.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtdni.BeforeTouchSize = New System.Drawing.Size(361, 20)
        Me.txtdni.BorderColor = System.Drawing.Color.Silver
        Me.txtdni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtdni.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtdni.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdni.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtdni.Location = New System.Drawing.Point(352, 37)
        Me.txtdni.MaxLength = 10
        Me.txtdni.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtdni.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtdni.Name = "txtdni"
        Me.txtdni.ReadOnly = True
        Me.txtdni.Size = New System.Drawing.Size(164, 20)
        Me.txtdni.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtdni.TabIndex = 509
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(349, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 13)
        Me.Label3.TabIndex = 508
        Me.Label3.Text = "Nro. DNI. / otro"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(492, 97)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 13)
        Me.Label5.TabIndex = 512
        Me.Label5.Text = "Fecha Vencimiento"
        '
        'txtFechaVcto
        '
        Me.txtFechaVcto.BackColor = System.Drawing.Color.IndianRed
        Me.txtFechaVcto.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtFechaVcto.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaVcto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtFechaVcto.Calendar.AllowMultipleSelection = False
        Me.txtFechaVcto.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaVcto.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaVcto.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechaVcto.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaVcto.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFechaVcto.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtFechaVcto.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFechaVcto.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaVcto.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaVcto.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtFechaVcto.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtFechaVcto.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtFechaVcto.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtFechaVcto.Calendar.Iso8601CalenderFormat = False
        Me.txtFechaVcto.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaVcto.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaVcto.Calendar.Name = "monthCalendar"
        Me.txtFechaVcto.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtFechaVcto.Calendar.SelectedDates = New Date(-1) {}
        Me.txtFechaVcto.Calendar.Size = New System.Drawing.Size(129, 174)
        Me.txtFechaVcto.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaVcto.Calendar.TabIndex = 0
        Me.txtFechaVcto.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtFechaVcto.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaVcto.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaVcto.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaVcto.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaVcto.Calendar.NoneButton.IsBackStageButton = False
        Me.txtFechaVcto.Calendar.NoneButton.Location = New System.Drawing.Point(57, 0)
        Me.txtFechaVcto.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtFechaVcto.Calendar.NoneButton.Text = "None"
        Me.txtFechaVcto.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtFechaVcto.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaVcto.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaVcto.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaVcto.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaVcto.Calendar.TodayButton.IsBackStageButton = False
        Me.txtFechaVcto.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaVcto.Calendar.TodayButton.Size = New System.Drawing.Size(57, 20)
        Me.txtFechaVcto.Calendar.TodayButton.Text = "Today"
        Me.txtFechaVcto.Calendar.TodayButton.UseVisualStyle = True
        Me.txtFechaVcto.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaVcto.CalendarForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaVcto.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtFechaVcto.Checked = False
        Me.txtFechaVcto.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechaVcto.CustomFormat = "dd/MM/yyyy"
        Me.txtFechaVcto.DropDownImage = Nothing
        Me.txtFechaVcto.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaVcto.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaVcto.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtFechaVcto.ForeColor = System.Drawing.Color.White
        Me.txtFechaVcto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFechaVcto.Location = New System.Drawing.Point(495, 117)
        Me.txtFechaVcto.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaVcto.MinValue = New Date(CType(0, Long))
        Me.txtFechaVcto.Name = "txtFechaVcto"
        Me.txtFechaVcto.ReadOnly = True
        Me.txtFechaVcto.ShowCheckBox = False
        Me.txtFechaVcto.ShowDropButton = False
        Me.txtFechaVcto.Size = New System.Drawing.Size(133, 20)
        Me.txtFechaVcto.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaVcto.TabIndex = 513
        Me.txtFechaVcto.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'GradientPanel3
        '
        Me.GradientPanel3.BackColor = System.Drawing.Color.DarkGray
        Me.GradientPanel3.BackgroundColor = New Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.None, System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.InactiveBorder)
        Me.GradientPanel3.BorderColor = System.Drawing.Color.DarkTurquoise
        Me.GradientPanel3.BorderSingle = System.Windows.Forms.ButtonBorderStyle.Dotted
        Me.GradientPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel3.Controls.Add(Me.txtMembresia)
        Me.GradientPanel3.Controls.Add(Me.Label20)
        Me.GradientPanel3.Controls.Add(Me.txtFechaVcto)
        Me.GradientPanel3.Controls.Add(Me.txtDuracion)
        Me.GradientPanel3.Controls.Add(Me.Label5)
        Me.GradientPanel3.Controls.Add(Me.txtValDuracion)
        Me.GradientPanel3.Controls.Add(Me.Label23)
        Me.GradientPanel3.Controls.Add(Me.txtValido)
        Me.GradientPanel3.Controls.Add(Me.cboPeriodicida)
        Me.GradientPanel3.Controls.Add(Me.txtCongela_dia)
        Me.GradientPanel3.Controls.Add(Me.txtFechaInicio)
        Me.GradientPanel3.Controls.Add(Me.Label12)
        Me.GradientPanel3.Controls.Add(Me.Label2)
        Me.GradientPanel3.Controls.Add(Me.txtInfoExtra)
        Me.GradientPanel3.Controls.Add(Me.Label9)
        Me.GradientPanel3.Controls.Add(Me.Label8)
        Me.GradientPanel3.Controls.Add(Me.Label7)
        Me.GradientPanel3.Controls.Add(Me.Label1)
        Me.GradientPanel3.Location = New System.Drawing.Point(25, 116)
        Me.GradientPanel3.Name = "GradientPanel3"
        Me.GradientPanel3.Size = New System.Drawing.Size(667, 185)
        Me.GradientPanel3.TabIndex = 515
        '
        'txtMembresia
        '
        Me.txtMembresia.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.txtMembresia.BeforeTouchSize = New System.Drawing.Size(361, 20)
        Me.txtMembresia.BorderColor = System.Drawing.Color.MediumSeaGreen
        Me.txtMembresia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMembresia.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMembresia.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMembresia.ForeColor = System.Drawing.Color.White
        Me.txtMembresia.Location = New System.Drawing.Point(30, 35)
        Me.txtMembresia.MaxLength = 10
        Me.txtMembresia.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtMembresia.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtMembresia.Name = "txtMembresia"
        Me.txtMembresia.NearImage = CType(resources.GetObject("txtMembresia.NearImage"), System.Drawing.Image)
        Me.txtMembresia.ReadOnly = True
        Me.txtMembresia.Size = New System.Drawing.Size(361, 20)
        Me.txtMembresia.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtMembresia.TabIndex = 515
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(155, 60)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(95, 14)
        Me.Label20.TabIndex = 474
        Me.Label20.Text = "Días de congelado"
        '
        'txtDuracion
        '
        Me.txtDuracion.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtDuracion.BeforeTouchSize = New System.Drawing.Size(361, 20)
        Me.txtDuracion.BorderColor = System.Drawing.Color.Silver
        Me.txtDuracion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDuracion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDuracion.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDuracion.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDuracion.ForeColor = System.Drawing.Color.Black
        Me.txtDuracion.Location = New System.Drawing.Point(68, 84)
        Me.txtDuracion.MaxLength = 10
        Me.txtDuracion.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtDuracion.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtDuracion.Name = "txtDuracion"
        Me.txtDuracion.ReadOnly = True
        Me.txtDuracion.Size = New System.Drawing.Size(83, 20)
        Me.txtDuracion.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtDuracion.TabIndex = 469
        '
        'txtValDuracion
        '
        Me.txtValDuracion.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtValDuracion.BeforeTouchSize = New System.Drawing.Size(361, 20)
        Me.txtValDuracion.BorderColor = System.Drawing.Color.Silver
        Me.txtValDuracion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtValDuracion.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtValDuracion.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValDuracion.ForeColor = System.Drawing.Color.Black
        Me.txtValDuracion.Location = New System.Drawing.Point(30, 84)
        Me.txtValDuracion.MaxLength = 10
        Me.txtValDuracion.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtValDuracion.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtValDuracion.Name = "txtValDuracion"
        Me.txtValDuracion.ReadOnly = True
        Me.txtValDuracion.Size = New System.Drawing.Size(35, 20)
        Me.txtValDuracion.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtValDuracion.TabIndex = 468
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(27, 64)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(51, 14)
        Me.Label23.TabIndex = 467
        Me.Label23.Text = "Duración"
        '
        'txtValido
        '
        Me.txtValido.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtValido.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtValido.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtValido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtValido.Calendar.AllowMultipleSelection = False
        Me.txtValido.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtValido.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtValido.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtValido.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtValido.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtValido.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtValido.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtValido.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValido.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtValido.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtValido.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtValido.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtValido.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtValido.Calendar.Iso8601CalenderFormat = False
        Me.txtValido.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtValido.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtValido.Calendar.Name = "monthCalendar"
        Me.txtValido.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtValido.Calendar.SelectedDates = New Date(-1) {}
        Me.txtValido.Calendar.Size = New System.Drawing.Size(86, 174)
        Me.txtValido.Calendar.SizeToFit = True
        Me.txtValido.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtValido.Calendar.TabIndex = 0
        Me.txtValido.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtValido.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtValido.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtValido.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtValido.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtValido.Calendar.NoneButton.IsBackStageButton = False
        Me.txtValido.Calendar.NoneButton.Location = New System.Drawing.Point(14, 0)
        Me.txtValido.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtValido.Calendar.NoneButton.Text = "None"
        Me.txtValido.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtValido.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtValido.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtValido.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtValido.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtValido.Calendar.TodayButton.IsBackStageButton = False
        Me.txtValido.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtValido.Calendar.TodayButton.Size = New System.Drawing.Size(14, 20)
        Me.txtValido.Calendar.TodayButton.Text = "Today"
        Me.txtValido.Calendar.TodayButton.UseVisualStyle = True
        Me.txtValido.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValido.CalendarForeColor = System.Drawing.SystemColors.ControlText
        Me.txtValido.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtValido.Checked = False
        Me.txtValido.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtValido.CustomFormat = "dd/MM/yyyy"
        Me.txtValido.DropDownImage = Nothing
        Me.txtValido.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtValido.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtValido.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtValido.Enabled = False
        Me.txtValido.ForeColor = System.Drawing.Color.Black
        Me.txtValido.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtValido.Location = New System.Drawing.Point(301, 84)
        Me.txtValido.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtValido.MinValue = New Date(CType(0, Long))
        Me.txtValido.Name = "txtValido"
        Me.txtValido.ReadOnly = True
        Me.txtValido.ShowCheckBox = False
        Me.txtValido.ShowDropButton = False
        Me.txtValido.Size = New System.Drawing.Size(90, 20)
        Me.txtValido.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtValido.TabIndex = 462
        Me.txtValido.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        Me.txtValido.Visible = False
        '
        'cboPeriodicida
        '
        Me.cboPeriodicida.BackColor = System.Drawing.Color.LightGray
        Me.cboPeriodicida.BeforeTouchSize = New System.Drawing.Size(135, 21)
        Me.cboPeriodicida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPeriodicida.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPeriodicida.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.cboPeriodicida.Items.AddRange(New Object() {"AL CONTADO", "AL CREDITO", "PAGO PARCIAL"})
        Me.cboPeriodicida.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboPeriodicida, "AL CONTADO"))
        Me.cboPeriodicida.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboPeriodicida, "AL CREDITO"))
        Me.cboPeriodicida.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboPeriodicida, "PAGO PARCIAL"))
        Me.cboPeriodicida.Location = New System.Drawing.Point(157, 153)
        Me.cboPeriodicida.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboPeriodicida.MetroColor = System.Drawing.Color.Silver
        Me.cboPeriodicida.Name = "cboPeriodicida"
        Me.cboPeriodicida.ReadOnly = True
        Me.cboPeriodicida.Size = New System.Drawing.Size(135, 21)
        Me.cboPeriodicida.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboPeriodicida.TabIndex = 461
        Me.cboPeriodicida.Text = "AL CONTADO"
        Me.cboPeriodicida.Visible = False
        '
        'txtCongela_dia
        '
        Me.txtCongela_dia.Enabled = False
        Me.txtCongela_dia.Location = New System.Drawing.Point(157, 82)
        Me.txtCongela_dia.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.txtCongela_dia.Name = "txtCongela_dia"
        Me.txtCongela_dia.Size = New System.Drawing.Size(57, 22)
        Me.txtCongela_dia.TabIndex = 422
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(218, 86)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(37, 14)
        Me.Label12.TabIndex = 417
        Me.Label12.Text = "Día(s)"
        '
        'txtInfoExtra
        '
        Me.txtInfoExtra.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtInfoExtra.BeforeTouchSize = New System.Drawing.Size(361, 20)
        Me.txtInfoExtra.BorderColor = System.Drawing.Color.Silver
        Me.txtInfoExtra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInfoExtra.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtInfoExtra.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInfoExtra.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtInfoExtra.Location = New System.Drawing.Point(30, 129)
        Me.txtInfoExtra.MaxLength = 20
        Me.txtInfoExtra.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtInfoExtra.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtInfoExtra.Multiline = True
        Me.txtInfoExtra.Name = "txtInfoExtra"
        Me.txtInfoExtra.ReadOnly = True
        Me.txtInfoExtra.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtInfoExtra.Size = New System.Drawing.Size(361, 45)
        Me.txtInfoExtra.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtInfoExtra.TabIndex = 414
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(27, 111)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(97, 14)
        Me.Label9.TabIndex = 411
        Me.Label9.Text = "Detalle (info adic.)"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(298, 64)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 14)
        Me.Label8.TabIndex = 410
        Me.Label8.Text = "Promo. válida"
        Me.Label8.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(154, 134)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 14)
        Me.Label7.TabIndex = 409
        Me.Label7.Text = "Periodicidad"
        Me.Label7.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(27, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(163, 14)
        Me.Label1.TabIndex = 404
        Me.Label1.Text = "Información de la membresía"
        '
        'frmMembresiaConfirmarInicio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.Color.OrangeRed
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.Color.White
        Me.CaptionBarHeight = 55
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(15, 12)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(30, 30)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Corbel", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.OrangeRed
        CaptionLabel1.Location = New System.Drawing.Point(55, 8)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Text = "Confirmación"
        CaptionLabel2.Font = New System.Drawing.Font("Corbel", 9.0!)
        CaptionLabel2.ForeColor = System.Drawing.Color.DimGray
        CaptionLabel2.Location = New System.Drawing.Point(55, 24)
        CaptionLabel2.Name = "CaptionLabel2"
        CaptionLabel2.Size = New System.Drawing.Size(200, 24)
        CaptionLabel2.Text = "Inicio de socios"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.CaptionLabels.Add(CaptionLabel2)
        Me.ClientSize = New System.Drawing.Size(716, 315)
        Me.Controls.Add(Me.GradientPanel3)
        Me.Controls.Add(Me.txtdni)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ButtonAdv6)
        Me.Controls.Add(Me.GradientPanel11)
        Me.Controls.Add(Me.TXTcLIENTE)
        Me.Controls.Add(Me.Label21)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMembresiaConfirmarInicio"
        Me.ShowIcon = False
        Me.Text = ""
        CType(Me.TXTcLIENTE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaInicio.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtdni, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaVcto.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaVcto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel3.ResumeLayout(False)
        Me.GradientPanel3.PerformLayout()
        CType(Me.txtMembresia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDuracion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValDuracion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValido.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValido, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboPeriodicida, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCongela_dia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtInfoExtra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label21 As Label
    Friend WithEvents TXTcLIENTE As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label2 As Label
    Friend WithEvents txtFechaInicio As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents GradientPanel11 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents ButtonAdv6 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents txtdni As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtFechaVcto As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Private WithEvents GradientPanel3 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents Label20 As Label
    Friend WithEvents txtDuracion As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtValDuracion As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label23 As Label
    Friend WithEvents txtValido As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents cboPeriodicida As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents txtCongela_dia As NumericUpDown
    Friend WithEvents Label12 As Label
    Friend WithEvents txtInfoExtra As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtMembresia As Syncfusion.Windows.Forms.Tools.TextBoxExt
End Class

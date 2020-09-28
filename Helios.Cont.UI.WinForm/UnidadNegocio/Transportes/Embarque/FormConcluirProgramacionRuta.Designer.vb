Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormConcluirProgramacionRuta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormConcluirProgramacionRuta))
        Me.Label8 = New System.Windows.Forms.Label()
        Me.RoundButton21 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.CirclePictureBox1 = New Helios.Cont.Presentation.WinForm.CirclePictureBox()
        Me.TextTipoEmbarque = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextRuta = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextCodigoPlaca = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextNroTripulantes = New Syncfusion.Windows.Forms.Tools.IntegerTextBox()
        Me.TextNumPasajeros = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextSeriePlaca = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextFechaProgramada = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.TextFechaEmbarque = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.CirclePictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextTipoEmbarque, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextRuta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextCodigoPlaca, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextNroTripulantes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextNumPasajeros, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextSeriePlaca, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextFechaProgramada, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextFechaProgramada.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextFechaEmbarque, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextFechaEmbarque.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(27, 3)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(212, 18)
        Me.Label8.TabIndex = 633
        Me.Label8.Text = "Consolidación y termino de ruta"
        '
        'RoundButton21
        '
        Me.RoundButton21.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton21.BackColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.RoundButton21.BeforeTouchSize = New System.Drawing.Size(152, 40)
        Me.RoundButton21.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundButton21.ForeColor = System.Drawing.Color.White
        Me.RoundButton21.IsBackStageButton = False
        Me.RoundButton21.Location = New System.Drawing.Point(490, 281)
        Me.RoundButton21.Name = "RoundButton21"
        Me.RoundButton21.Size = New System.Drawing.Size(152, 40)
        Me.RoundButton21.TabIndex = 632
        Me.RoundButton21.Text = "Guardar"
        Me.RoundButton21.UseVisualStyle = True
        '
        'CirclePictureBox1
        '
        Me.CirclePictureBox1.Image = CType(resources.GetObject("CirclePictureBox1.Image"), System.Drawing.Image)
        Me.CirclePictureBox1.Location = New System.Drawing.Point(469, 58)
        Me.CirclePictureBox1.Name = "CirclePictureBox1"
        Me.CirclePictureBox1.Size = New System.Drawing.Size(190, 185)
        Me.CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.CirclePictureBox1.TabIndex = 631
        Me.CirclePictureBox1.TabStop = False
        '
        'TextTipoEmbarque
        '
        Me.TextTipoEmbarque.BackColor = System.Drawing.Color.White
        Me.TextTipoEmbarque.BeforeTouchSize = New System.Drawing.Size(255, 24)
        Me.TextTipoEmbarque.BorderColor = System.Drawing.Color.Silver
        Me.TextTipoEmbarque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextTipoEmbarque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextTipoEmbarque.CornerRadius = 3
        Me.TextTipoEmbarque.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextTipoEmbarque.Enabled = False
        Me.TextTipoEmbarque.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextTipoEmbarque.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextTipoEmbarque.ForeColor = System.Drawing.Color.SeaGreen
        Me.TextTipoEmbarque.Location = New System.Drawing.Point(280, 111)
        Me.TextTipoEmbarque.MaxLength = 70
        Me.TextTipoEmbarque.Metrocolor = System.Drawing.Color.Silver
        Me.TextTipoEmbarque.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextTipoEmbarque.Name = "TextTipoEmbarque"
        Me.TextTipoEmbarque.Size = New System.Drawing.Size(136, 23)
        Me.TextTipoEmbarque.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextTipoEmbarque.TabIndex = 630
        Me.TextTipoEmbarque.Text = "IDA/VUELTA"
        Me.TextTipoEmbarque.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(277, 91)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(27, 13)
        Me.Label7.TabIndex = 629
        Me.Label7.Text = "Tipo"
        '
        'TextRuta
        '
        Me.TextRuta.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextRuta.BeforeTouchSize = New System.Drawing.Size(255, 24)
        Me.TextRuta.BorderColor = System.Drawing.Color.Silver
        Me.TextRuta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextRuta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextRuta.CornerRadius = 4
        Me.TextRuta.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextRuta.Enabled = False
        Me.TextRuta.FarImage = CType(resources.GetObject("TextRuta.FarImage"), System.Drawing.Image)
        Me.TextRuta.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextRuta.ForeColor = System.Drawing.Color.Black
        Me.TextRuta.Location = New System.Drawing.Point(31, 57)
        Me.TextRuta.Metrocolor = System.Drawing.Color.Silver
        Me.TextRuta.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextRuta.Name = "TextRuta"
        Me.TextRuta.Size = New System.Drawing.Size(385, 25)
        Me.TextRuta.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextRuta.TabIndex = 628
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(28, 36)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 13)
        Me.Label6.TabIndex = 627
        Me.Label6.Text = "Ruta - Destino"
        '
        'TextCodigoPlaca
        '
        Me.TextCodigoPlaca.BackColor = System.Drawing.Color.White
        Me.TextCodigoPlaca.BeforeTouchSize = New System.Drawing.Size(255, 24)
        Me.TextCodigoPlaca.BorderColor = System.Drawing.Color.Silver
        Me.TextCodigoPlaca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextCodigoPlaca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextCodigoPlaca.CornerRadius = 3
        Me.TextCodigoPlaca.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextCodigoPlaca.Enabled = False
        Me.TextCodigoPlaca.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextCodigoPlaca.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextCodigoPlaca.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextCodigoPlaca.Location = New System.Drawing.Point(292, 224)
        Me.TextCodigoPlaca.MaxLength = 70
        Me.TextCodigoPlaca.Metrocolor = System.Drawing.Color.Silver
        Me.TextCodigoPlaca.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextCodigoPlaca.Name = "TextCodigoPlaca"
        Me.TextCodigoPlaca.Size = New System.Drawing.Size(124, 22)
        Me.TextCodigoPlaca.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextCodigoPlaca.TabIndex = 626
        '
        'TextNroTripulantes
        '
        Me.TextNroTripulantes.BackGroundColor = System.Drawing.Color.WhiteSmoke
        Me.TextNroTripulantes.BeforeTouchSize = New System.Drawing.Size(255, 24)
        Me.TextNroTripulantes.BorderColor = System.Drawing.Color.Gainsboro
        Me.TextNroTripulantes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextNroTripulantes.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextNroTripulantes.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNroTripulantes.ForeColor = System.Drawing.Color.ForestGreen
        Me.TextNroTripulantes.IntegerValue = CType(1, Long)
        Me.TextNroTripulantes.Location = New System.Drawing.Point(125, 277)
        Me.TextNroTripulantes.Metrocolor = System.Drawing.Color.Silver
        Me.TextNroTripulantes.Name = "TextNroTripulantes"
        Me.TextNroTripulantes.NullString = ""
        Me.TextNroTripulantes.PositiveColor = System.Drawing.Color.ForestGreen
        Me.TextNroTripulantes.Size = New System.Drawing.Size(81, 25)
        Me.TextNroTripulantes.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextNroTripulantes.TabIndex = 625
        Me.TextNroTripulantes.Text = "1"
        '
        'TextNumPasajeros
        '
        Me.TextNumPasajeros.BackColor = System.Drawing.Color.White
        Me.TextNumPasajeros.BeforeTouchSize = New System.Drawing.Size(255, 24)
        Me.TextNumPasajeros.BorderColor = System.Drawing.Color.Silver
        Me.TextNumPasajeros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextNumPasajeros.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNumPasajeros.CornerRadius = 3
        Me.TextNumPasajeros.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextNumPasajeros.Enabled = False
        Me.TextNumPasajeros.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextNumPasajeros.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNumPasajeros.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextNumPasajeros.Location = New System.Drawing.Point(31, 276)
        Me.TextNumPasajeros.MaxLength = 70
        Me.TextNumPasajeros.Metrocolor = System.Drawing.Color.Silver
        Me.TextNumPasajeros.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextNumPasajeros.Multiline = True
        Me.TextNumPasajeros.Name = "TextNumPasajeros"
        Me.TextNumPasajeros.Size = New System.Drawing.Size(71, 26)
        Me.TextNumPasajeros.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextNumPasajeros.TabIndex = 624
        '
        'TextSeriePlaca
        '
        Me.TextSeriePlaca.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextSeriePlaca.BeforeTouchSize = New System.Drawing.Size(255, 24)
        Me.TextSeriePlaca.BorderColor = System.Drawing.Color.Silver
        Me.TextSeriePlaca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextSeriePlaca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextSeriePlaca.CornerRadius = 4
        Me.TextSeriePlaca.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextSeriePlaca.FarImage = CType(resources.GetObject("TextSeriePlaca.FarImage"), System.Drawing.Image)
        Me.TextSeriePlaca.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextSeriePlaca.ForeColor = System.Drawing.Color.Black
        Me.TextSeriePlaca.Location = New System.Drawing.Point(31, 224)
        Me.TextSeriePlaca.Metrocolor = System.Drawing.Color.Silver
        Me.TextSeriePlaca.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextSeriePlaca.Name = "TextSeriePlaca"
        Me.TextSeriePlaca.Size = New System.Drawing.Size(255, 24)
        Me.TextSeriePlaca.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextSeriePlaca.TabIndex = 622
        '
        'TextFechaProgramada
        '
        Me.TextFechaProgramada.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextFechaProgramada.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.TextFechaProgramada.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextFechaProgramada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TextFechaProgramada.Calendar.AllowMultipleSelection = False
        Me.TextFechaProgramada.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextFechaProgramada.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextFechaProgramada.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.TextFechaProgramada.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaProgramada.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TextFechaProgramada.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.TextFechaProgramada.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextFechaProgramada.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextFechaProgramada.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TextFechaProgramada.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.TextFechaProgramada.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.TextFechaProgramada.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.TextFechaProgramada.Calendar.HighlightColor = System.Drawing.Color.White
        Me.TextFechaProgramada.Calendar.Iso8601CalenderFormat = False
        Me.TextFechaProgramada.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.TextFechaProgramada.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaProgramada.Calendar.Name = "monthCalendar"
        Me.TextFechaProgramada.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.TextFechaProgramada.Calendar.SelectedDates = New Date(-1) {}
        Me.TextFechaProgramada.Calendar.Size = New System.Drawing.Size(241, 174)
        Me.TextFechaProgramada.Calendar.SizeToFit = True
        Me.TextFechaProgramada.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.TextFechaProgramada.Calendar.TabIndex = 0
        Me.TextFechaProgramada.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.TextFechaProgramada.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.TextFechaProgramada.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaProgramada.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.TextFechaProgramada.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.TextFechaProgramada.Calendar.NoneButton.IsBackStageButton = False
        Me.TextFechaProgramada.Calendar.NoneButton.Location = New System.Drawing.Point(165, 0)
        Me.TextFechaProgramada.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.TextFechaProgramada.Calendar.NoneButton.Text = "None"
        Me.TextFechaProgramada.Calendar.NoneButton.UseVisualStyle = True
        Me.TextFechaProgramada.Calendar.NoneButton.Visible = False
        '
        '
        '
        Me.TextFechaProgramada.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.TextFechaProgramada.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaProgramada.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.TextFechaProgramada.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.TextFechaProgramada.Calendar.TodayButton.IsBackStageButton = False
        Me.TextFechaProgramada.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.TextFechaProgramada.Calendar.TodayButton.Size = New System.Drawing.Size(241, 20)
        Me.TextFechaProgramada.Calendar.TodayButton.Text = "Today"
        Me.TextFechaProgramada.Calendar.TodayButton.UseVisualStyle = True
        Me.TextFechaProgramada.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextFechaProgramada.CalendarSize = New System.Drawing.Size(189, 176)
        Me.TextFechaProgramada.Checked = False
        Me.TextFechaProgramada.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.TextFechaProgramada.CustomFormat = "dd/MM/yyyy HH:mm:ss tt"
        Me.TextFechaProgramada.DropDownImage = Nothing
        Me.TextFechaProgramada.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaProgramada.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaProgramada.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.TextFechaProgramada.Enabled = False
        Me.TextFechaProgramada.EnableNullDate = False
        Me.TextFechaProgramada.EnableNullKeys = False
        Me.TextFechaProgramada.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextFechaProgramada.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TextFechaProgramada.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TextFechaProgramada.Location = New System.Drawing.Point(31, 112)
        Me.TextFechaProgramada.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaProgramada.MinValue = New Date(CType(0, Long))
        Me.TextFechaProgramada.Name = "TextFechaProgramada"
        Me.TextFechaProgramada.ShowCheckBox = False
        Me.TextFechaProgramada.ShowDropButton = False
        Me.TextFechaProgramada.ShowUpDownOnFocus = True
        Me.TextFechaProgramada.Size = New System.Drawing.Size(243, 21)
        Me.TextFechaProgramada.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.TextFechaProgramada.TabIndex = 621
        Me.TextFechaProgramada.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'TextFechaEmbarque
        '
        Me.TextFechaEmbarque.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextFechaEmbarque.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.TextFechaEmbarque.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextFechaEmbarque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TextFechaEmbarque.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextFechaEmbarque.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextFechaEmbarque.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.TextFechaEmbarque.Calendar.DayNamesColor = System.Drawing.Color.Empty
        Me.TextFechaEmbarque.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TextFechaEmbarque.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextFechaEmbarque.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TextFechaEmbarque.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.TextFechaEmbarque.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.TextFechaEmbarque.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.TextFechaEmbarque.Calendar.HighlightColor = System.Drawing.Color.White
        Me.TextFechaEmbarque.Calendar.Iso8601CalenderFormat = False
        Me.TextFechaEmbarque.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.TextFechaEmbarque.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaEmbarque.Calendar.Name = "monthCalendar"
        Me.TextFechaEmbarque.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.TextFechaEmbarque.Calendar.SelectedDates = New Date(-1) {}
        Me.TextFechaEmbarque.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.TextFechaEmbarque.Calendar.TabIndex = 0
        Me.TextFechaEmbarque.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.TextFechaEmbarque.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.TextFechaEmbarque.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaEmbarque.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.TextFechaEmbarque.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.TextFechaEmbarque.Calendar.NoneButton.IsBackStageButton = False
        Me.TextFechaEmbarque.Calendar.NoneButton.Location = New System.Drawing.Point(78, 0)
        Me.TextFechaEmbarque.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.TextFechaEmbarque.Calendar.NoneButton.UseVisualStyle = True
        Me.TextFechaEmbarque.Calendar.NoneButton.Visible = False
        '
        '
        '
        Me.TextFechaEmbarque.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.TextFechaEmbarque.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaEmbarque.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.TextFechaEmbarque.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.TextFechaEmbarque.Calendar.TodayButton.IsBackStageButton = False
        Me.TextFechaEmbarque.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.TextFechaEmbarque.Calendar.TodayButton.Size = New System.Drawing.Size(150, 20)
        Me.TextFechaEmbarque.Calendar.TodayButton.UseVisualStyle = True
        Me.TextFechaEmbarque.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextFechaEmbarque.CalendarSize = New System.Drawing.Size(189, 176)
        Me.TextFechaEmbarque.Checked = False
        Me.TextFechaEmbarque.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.TextFechaEmbarque.CustomFormat = "dd/MM/yyyy HH:mm:ss tt"
        Me.TextFechaEmbarque.DropDownImage = Nothing
        Me.TextFechaEmbarque.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaEmbarque.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaEmbarque.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.TextFechaEmbarque.EnableNullDate = False
        Me.TextFechaEmbarque.EnableNullKeys = False
        Me.TextFechaEmbarque.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextFechaEmbarque.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TextFechaEmbarque.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TextFechaEmbarque.Location = New System.Drawing.Point(31, 170)
        Me.TextFechaEmbarque.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaEmbarque.MinValue = New Date(CType(0, Long))
        Me.TextFechaEmbarque.Name = "TextFechaEmbarque"
        Me.TextFechaEmbarque.ShowCheckBox = False
        Me.TextFechaEmbarque.ShowUpDownOnFocus = True
        Me.TextFechaEmbarque.Size = New System.Drawing.Size(243, 21)
        Me.TextFechaEmbarque.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.TextFechaEmbarque.TabIndex = 620
        Me.TextFechaEmbarque.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(124, 256)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 13)
        Me.Label5.TabIndex = 619
        Me.Label5.Text = "Nro. tripulantes"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(28, 256)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 618
        Me.Label4.Text = "Nro. pasajeros"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(28, 204)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 13)
        Me.Label3.TabIndex = 617
        Me.Label3.Text = "Vehículo/Bus en uso"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(28, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(153, 13)
        Me.Label2.TabIndex = 616
        Me.Label2.Text = "Fecha programada de llegada:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(28, 148)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 13)
        Me.Label1.TabIndex = 615
        Me.Label1.Text = "Fecha de llegada"
        '
        'FormConcluirProgramacionRuta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.Color.Gray
        Me.BorderThickness = 2
        Me.CaptionForeColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(686, 325)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.RoundButton21)
        Me.Controls.Add(Me.CirclePictureBox1)
        Me.Controls.Add(Me.TextTipoEmbarque)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TextRuta)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TextCodigoPlaca)
        Me.Controls.Add(Me.TextNroTripulantes)
        Me.Controls.Add(Me.TextNumPasajeros)
        Me.Controls.Add(Me.TextSeriePlaca)
        Me.Controls.Add(Me.TextFechaProgramada)
        Me.Controls.Add(Me.TextFechaEmbarque)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormConcluirProgramacionRuta"
        Me.ShowIcon = False
        Me.Text = "Terminar ruta"
        CType(Me.CirclePictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextTipoEmbarque, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextRuta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextCodigoPlaca, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextNroTripulantes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextNumPasajeros, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextSeriePlaca, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextFechaProgramada.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextFechaProgramada, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextFechaEmbarque.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextFechaEmbarque, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label8 As Label
    Friend WithEvents RoundButton21 As RoundButton2
    Friend WithEvents CirclePictureBox1 As CirclePictureBox
    Friend WithEvents TextTipoEmbarque As Tools.TextBoxExt
    Friend WithEvents Label7 As Label
    Friend WithEvents TextRuta As Tools.TextBoxExt
    Friend WithEvents Label6 As Label
    Friend WithEvents TextCodigoPlaca As Tools.TextBoxExt
    Friend WithEvents TextNroTripulantes As Tools.IntegerTextBox
    Friend WithEvents TextNumPasajeros As Tools.TextBoxExt
    Friend WithEvents TextSeriePlaca As Tools.TextBoxExt
    Friend WithEvents TextFechaProgramada As Tools.DateTimePickerAdv
    Friend WithEvents TextFechaEmbarque As Tools.DateTimePickerAdv
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class

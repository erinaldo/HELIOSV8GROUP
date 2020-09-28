Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormCrearTripulante
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
        Dim BannerTextInfo1 As Syncfusion.Windows.Forms.BannerTextInfo = New Syncfusion.Windows.Forms.BannerTextInfo()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCrearTripulante))
        Dim BannerTextInfo2 As Syncfusion.Windows.Forms.BannerTextInfo = New Syncfusion.Windows.Forms.BannerTextInfo()
        Me.GradientPanel8 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextNombres = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextFechaVcto = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextCodigoLic = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextEdad = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.PictureLoad = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RoundButton26 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.RoundButton25 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.Label17 = New System.Windows.Forms.Label()
        Me.ComboComprobante = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.TextCodigoPersona = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextNacionalidad = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BannerTextProvider1 = New Syncfusion.Windows.Forms.BannerTextProvider(Me.components)
        CType(Me.GradientPanel8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel8.SuspendLayout()
        CType(Me.TextNombres, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextFechaVcto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextFechaVcto.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextCodigoLic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureLoad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextCodigoPersona, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextNacionalidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GradientPanel8
        '
        Me.GradientPanel8.BackColor = System.Drawing.Color.White
        Me.GradientPanel8.BorderColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(97, Byte), Integer))
        Me.GradientPanel8.BorderSides = System.Windows.Forms.Border3DSide.Left
        Me.GradientPanel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel8.Controls.Add(Me.Label4)
        Me.GradientPanel8.Controls.Add(Me.TextNombres)
        Me.GradientPanel8.Controls.Add(Me.TextFechaVcto)
        Me.GradientPanel8.Controls.Add(Me.Label3)
        Me.GradientPanel8.Controls.Add(Me.TextCodigoLic)
        Me.GradientPanel8.Controls.Add(Me.Label2)
        Me.GradientPanel8.Controls.Add(Me.TextEdad)
        Me.GradientPanel8.Controls.Add(Me.PictureLoad)
        Me.GradientPanel8.Controls.Add(Me.Label1)
        Me.GradientPanel8.Controls.Add(Me.RoundButton26)
        Me.GradientPanel8.Controls.Add(Me.RoundButton25)
        Me.GradientPanel8.Controls.Add(Me.Label17)
        Me.GradientPanel8.Controls.Add(Me.ComboComprobante)
        Me.GradientPanel8.Controls.Add(Me.TextCodigoPersona)
        Me.GradientPanel8.Controls.Add(Me.TextNacionalidad)
        Me.GradientPanel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel8.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel8.Name = "GradientPanel8"
        Me.GradientPanel8.Size = New System.Drawing.Size(397, 388)
        Me.GradientPanel8.TabIndex = 576
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(30, 132)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(102, 13)
        Me.Label4.TabIndex = 604
        Me.Label4.Text = "Nombres y apellidos"
        '
        'TextNombres
        '
        Me.TextNombres.BackColor = System.Drawing.Color.White
        BannerTextInfo1.Text = "Nombres"
        BannerTextInfo1.Visible = True
        Me.BannerTextProvider1.SetBannerText(Me.TextNombres, BannerTextInfo1)
        Me.TextNombres.BeforeTouchSize = New System.Drawing.Size(321, 22)
        Me.TextNombres.BorderColor = System.Drawing.Color.Silver
        Me.TextNombres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextNombres.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNombres.CornerRadius = 3
        Me.TextNombres.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextNombres.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextNombres.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNombres.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextNombres.Location = New System.Drawing.Point(32, 150)
        Me.TextNombres.MaxLength = 70
        Me.TextNombres.Metrocolor = System.Drawing.Color.Silver
        Me.TextNombres.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextNombres.Name = "TextNombres"
        Me.TextNombres.Size = New System.Drawing.Size(322, 22)
        Me.TextNombres.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextNombres.TabIndex = 602
        '
        'TextFechaVcto
        '
        Me.TextFechaVcto.BackColor = System.Drawing.Color.White
        Me.TextFechaVcto.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.TextFechaVcto.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextFechaVcto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TextFechaVcto.Calendar.AllowMultipleSelection = False
        Me.TextFechaVcto.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextFechaVcto.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextFechaVcto.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.TextFechaVcto.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaVcto.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TextFechaVcto.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.TextFechaVcto.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextFechaVcto.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextFechaVcto.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TextFechaVcto.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.TextFechaVcto.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.TextFechaVcto.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.TextFechaVcto.Calendar.HighlightColor = System.Drawing.Color.White
        Me.TextFechaVcto.Calendar.Iso8601CalenderFormat = False
        Me.TextFechaVcto.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.TextFechaVcto.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaVcto.Calendar.Name = "monthCalendar"
        Me.TextFechaVcto.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.TextFechaVcto.Calendar.SelectedDates = New Date(-1) {}
        Me.TextFechaVcto.Calendar.Size = New System.Drawing.Size(240, 174)
        Me.TextFechaVcto.Calendar.SizeToFit = True
        Me.TextFechaVcto.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.TextFechaVcto.Calendar.TabIndex = 0
        Me.TextFechaVcto.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.TextFechaVcto.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.TextFechaVcto.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaVcto.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.TextFechaVcto.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.TextFechaVcto.Calendar.NoneButton.IsBackStageButton = False
        Me.TextFechaVcto.Calendar.NoneButton.Location = New System.Drawing.Point(165, 0)
        Me.TextFechaVcto.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.TextFechaVcto.Calendar.NoneButton.Text = "None"
        Me.TextFechaVcto.Calendar.NoneButton.UseVisualStyle = True
        Me.TextFechaVcto.Calendar.NoneButton.Visible = False
        '
        '
        '
        Me.TextFechaVcto.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.TextFechaVcto.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaVcto.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.TextFechaVcto.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.TextFechaVcto.Calendar.TodayButton.IsBackStageButton = False
        Me.TextFechaVcto.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.TextFechaVcto.Calendar.TodayButton.Size = New System.Drawing.Size(240, 20)
        Me.TextFechaVcto.Calendar.TodayButton.Text = "Today"
        Me.TextFechaVcto.Calendar.TodayButton.UseVisualStyle = True
        Me.TextFechaVcto.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextFechaVcto.CalendarSize = New System.Drawing.Size(189, 176)
        Me.TextFechaVcto.Checked = False
        Me.TextFechaVcto.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.TextFechaVcto.CustomFormat = "dd/MM/yyyy HH:mm:ss tt"
        Me.TextFechaVcto.DropDownImage = Nothing
        Me.TextFechaVcto.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaVcto.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaVcto.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.TextFechaVcto.EnableNullDate = False
        Me.TextFechaVcto.EnableNullKeys = False
        Me.TextFechaVcto.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextFechaVcto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TextFechaVcto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TextFechaVcto.Location = New System.Drawing.Point(34, 242)
        Me.TextFechaVcto.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TextFechaVcto.MinValue = New Date(CType(0, Long))
        Me.TextFechaVcto.Name = "TextFechaVcto"
        Me.TextFechaVcto.ShowCheckBox = False
        Me.TextFechaVcto.ShowUpDownOnFocus = True
        Me.TextFechaVcto.Size = New System.Drawing.Size(242, 21)
        Me.TextFechaVcto.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.TextFechaVcto.TabIndex = 601
        Me.TextFechaVcto.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        Me.TextFechaVcto.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(37, 226)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 589
        Me.Label3.Text = "Fecha Vcto."
        Me.Label3.Visible = False
        '
        'TextCodigoLic
        '
        Me.TextCodigoLic.BackColor = System.Drawing.Color.White
        Me.TextCodigoLic.BeforeTouchSize = New System.Drawing.Size(321, 22)
        Me.TextCodigoLic.BorderColor = System.Drawing.Color.Silver
        Me.TextCodigoLic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextCodigoLic.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextCodigoLic.CornerRadius = 3
        Me.TextCodigoLic.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextCodigoLic.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextCodigoLic.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextCodigoLic.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextCodigoLic.Location = New System.Drawing.Point(33, 196)
        Me.TextCodigoLic.MaxLength = 20
        Me.TextCodigoLic.Metrocolor = System.Drawing.Color.Silver
        Me.TextCodigoLic.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextCodigoLic.Name = "TextCodigoLic"
        Me.TextCodigoLic.Size = New System.Drawing.Size(322, 22)
        Me.TextCodigoLic.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextCodigoLic.TabIndex = 588
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(36, 180)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 587
        Me.Label2.Text = "Codigo licencia"
        '
        'TextEdad
        '
        Me.TextEdad.BackGroundColor = System.Drawing.SystemColors.Window
        Me.TextEdad.BeforeTouchSize = New System.Drawing.Size(321, 22)
        Me.TextEdad.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextEdad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextEdad.CurrencyDecimalDigits = 0
        Me.TextEdad.CurrencySymbol = "Edad: "
        Me.TextEdad.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextEdad.DecimalValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TextEdad.Location = New System.Drawing.Point(239, 105)
        Me.TextEdad.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextEdad.Name = "TextEdad"
        Me.TextEdad.NullString = ""
        Me.TextEdad.Size = New System.Drawing.Size(112, 20)
        Me.TextEdad.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextEdad.TabIndex = 586
        Me.TextEdad.Text = "Edad: 1"
        Me.TextEdad.Visible = False
        '
        'PictureLoad
        '
        Me.PictureLoad.Image = CType(resources.GetObject("PictureLoad.Image"), System.Drawing.Image)
        Me.PictureLoad.Location = New System.Drawing.Point(191, 57)
        Me.PictureLoad.Name = "PictureLoad"
        Me.PictureLoad.Size = New System.Drawing.Size(42, 41)
        Me.PictureLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureLoad.TabIndex = 585
        Me.PictureLoad.TabStop = False
        Me.PictureLoad.Visible = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(97, Byte), Integer))
        Me.Label1.Image = CType(resources.GetObject("Label1.Image"), System.Drawing.Image)
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label1.Location = New System.Drawing.Point(29, -8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(143, 52)
        Me.Label1.TabIndex = 582
        Me.Label1.Text = "Crear tripulante"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'RoundButton26
        '
        Me.RoundButton26.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton26.BackColor = System.Drawing.Color.Gray
        Me.RoundButton26.BeforeTouchSize = New System.Drawing.Size(85, 35)
        Me.RoundButton26.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundButton26.ForeColor = System.Drawing.Color.White
        Me.RoundButton26.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.RoundButton26.IsBackStageButton = False
        Me.RoundButton26.Location = New System.Drawing.Point(169, 336)
        Me.RoundButton26.Name = "RoundButton26"
        Me.RoundButton26.Size = New System.Drawing.Size(85, 35)
        Me.RoundButton26.TabIndex = 581
        Me.RoundButton26.Text = "CANCELAR"
        Me.RoundButton26.UseVisualStyle = True
        '
        'RoundButton25
        '
        Me.RoundButton25.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton25.BackColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(97, Byte), Integer))
        Me.RoundButton25.BeforeTouchSize = New System.Drawing.Size(94, 35)
        Me.RoundButton25.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundButton25.ForeColor = System.Drawing.Color.White
        Me.RoundButton25.Image = CType(resources.GetObject("RoundButton25.Image"), System.Drawing.Image)
        Me.RoundButton25.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.RoundButton25.IsBackStageButton = False
        Me.RoundButton25.Location = New System.Drawing.Point(260, 336)
        Me.RoundButton25.Name = "RoundButton25"
        Me.RoundButton25.Size = New System.Drawing.Size(94, 35)
        Me.RoundButton25.TabIndex = 576
        Me.RoundButton25.Text = "GUARDAR"
        Me.RoundButton25.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RoundButton25.UseVisualStyle = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(29, 56)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(114, 14)
        Me.Label17.TabIndex = 573
        Me.Label17.Text = "Datos del tripulante"
        '
        'ComboComprobante
        '
        Me.ComboComprobante.BackColor = System.Drawing.Color.White
        Me.ComboComprobante.BeforeTouchSize = New System.Drawing.Size(202, 21)
        Me.ComboComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboComprobante.Enabled = False
        Me.ComboComprobante.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboComprobante.Items.AddRange(New Object() {"DNI", "RUC", "CARNET EXTRANJERIA"})
        Me.ComboComprobante.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboComprobante, "DNI"))
        Me.ComboComprobante.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboComprobante, "RUC"))
        Me.ComboComprobante.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboComprobante, "CARNET EXTRANJERIA"))
        Me.ComboComprobante.Location = New System.Drawing.Point(31, 104)
        Me.ComboComprobante.MetroBorderColor = System.Drawing.Color.Silver
        Me.ComboComprobante.Name = "ComboComprobante"
        Me.ComboComprobante.Size = New System.Drawing.Size(202, 21)
        Me.ComboComprobante.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboComprobante.TabIndex = 565
        Me.ComboComprobante.Text = "DNI"
        '
        'TextCodigoPersona
        '
        Me.TextCodigoPersona.BackColor = System.Drawing.SystemColors.Info
        BannerTextInfo2.Text = "Número DNI..."
        BannerTextInfo2.Visible = True
        Me.BannerTextProvider1.SetBannerText(Me.TextCodigoPersona, BannerTextInfo2)
        Me.TextCodigoPersona.BeforeTouchSize = New System.Drawing.Size(321, 22)
        Me.TextCodigoPersona.BorderColor = System.Drawing.Color.Silver
        Me.TextCodigoPersona.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextCodigoPersona.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextCodigoPersona.CornerRadius = 3
        Me.TextCodigoPersona.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextCodigoPersona.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextCodigoPersona.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextCodigoPersona.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextCodigoPersona.Location = New System.Drawing.Point(31, 76)
        Me.TextCodigoPersona.MaxLength = 12
        Me.TextCodigoPersona.Metrocolor = System.Drawing.Color.Silver
        Me.TextCodigoPersona.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextCodigoPersona.Name = "TextCodigoPersona"
        Me.TextCodigoPersona.NearImage = CType(resources.GetObject("TextCodigoPersona.NearImage"), System.Drawing.Image)
        Me.TextCodigoPersona.Size = New System.Drawing.Size(154, 22)
        Me.TextCodigoPersona.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextCodigoPersona.TabIndex = 566
        '
        'TextNacionalidad
        '
        Me.TextNacionalidad.BackColor = System.Drawing.Color.White
        Me.TextNacionalidad.BeforeTouchSize = New System.Drawing.Size(321, 22)
        Me.TextNacionalidad.BorderColor = System.Drawing.Color.Silver
        Me.TextNacionalidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextNacionalidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNacionalidad.CornerRadius = 3
        Me.TextNacionalidad.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextNacionalidad.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextNacionalidad.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNacionalidad.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextNacionalidad.Location = New System.Drawing.Point(414, 322)
        Me.TextNacionalidad.Metrocolor = System.Drawing.Color.Silver
        Me.TextNacionalidad.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextNacionalidad.Name = "TextNacionalidad"
        Me.TextNacionalidad.NearImage = CType(resources.GetObject("TextNacionalidad.NearImage"), System.Drawing.Image)
        Me.TextNacionalidad.Size = New System.Drawing.Size(321, 22)
        Me.TextNacionalidad.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextNacionalidad.TabIndex = 571
        Me.TextNacionalidad.Text = "PERUANO"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'FormCrearTripulante
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionButtonColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(97, Byte), Integer))
        Me.CaptionButtonHoverColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(97, Byte), Integer))
        Me.CaptionForeColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(397, 388)
        Me.Controls.Add(Me.GradientPanel8)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormCrearTripulante"
        Me.ShowIcon = False
        Me.Text = "Crear Tripulante"
        CType(Me.GradientPanel8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel8.ResumeLayout(False)
        Me.GradientPanel8.PerformLayout()
        CType(Me.TextNombres, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextFechaVcto.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextFechaVcto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextCodigoLic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureLoad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboComprobante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextCodigoPersona, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextNacionalidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GradientPanel8 As Tools.GradientPanel
    Friend WithEvents PictureLoad As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents RoundButton26 As RoundButton2
    Friend WithEvents RoundButton25 As RoundButton2
    Friend WithEvents Label17 As Label
    Friend WithEvents ComboComprobante As Tools.ComboBoxAdv
    Friend WithEvents TextCodigoPersona As Tools.TextBoxExt
    Friend WithEvents TextEdad As Tools.CurrencyTextBox
    Friend WithEvents TextNacionalidad As Tools.TextBoxExt
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents BannerTextProvider1 As BannerTextProvider
    Friend WithEvents TextCodigoLic As Tools.TextBoxExt
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TextFechaVcto As Tools.DateTimePickerAdv
    Friend WithEvents Label4 As Label
    Friend WithEvents TextNombres As Tools.TextBoxExt
End Class

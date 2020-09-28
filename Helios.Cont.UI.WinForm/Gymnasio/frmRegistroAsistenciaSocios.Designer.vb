<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRegistroAsistenciaSocios
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRegistroAsistenciaSocios))
        Dim DigitalClockRenderer1 As Syncfusion.Windows.Forms.Tools.DigitalClockRenderer = New Syncfusion.Windows.Forms.Tools.DigitalClockRenderer()
        Dim ClockRenderer1 As Syncfusion.Windows.Forms.Tools.ClockRenderer = New Syncfusion.Windows.Forms.Tools.ClockRenderer()
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Dim CaptionLabel2 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.GradientPanel3 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.GradientPanel5 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ImagenHuella = New System.Windows.Forms.PictureBox()
        Me.chHuella = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.cboAcceso = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFecha = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.txtTrabajador = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtCodigoFiltrar = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.Clock1 = New Syncfusion.Windows.Forms.Tools.Clock()
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblInicio = New System.Windows.Forms.Label()
        Me.lblVence = New System.Windows.Forms.Label()
        Me.lblDiasDisponibles = New System.Windows.Forms.Label()
        Me.lblCodigoMembresia = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.ToggleButton22 = New Helios.Cont.Presentation.WinForm.ToggleButton2()
        Me.ToggleButton21 = New Helios.Cont.Presentation.WinForm.ToggleButton2()
        Me.GradientPanel4 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.RoundButton21 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.Line21 = New Helios.Cont.Presentation.WinForm.Line2()
        Me.PredictedText = New System.Windows.Forms.Label()
        Me.illustration = New System.Windows.Forms.Label()
        Me.AuditPredicted = New System.Windows.Forms.Label()
        Me.thumb = New System.Windows.Forms.PictureBox()
        Me.ImageListAdv1 = New Syncfusion.Windows.Forms.Tools.ImageListAdv(Me.components)
        Me.ImageListAdv2 = New Syncfusion.Windows.Forms.Tools.ImageListAdv(Me.components)
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel3.SuspendLayout()
        CType(Me.GradientPanel5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel5.SuspendLayout()
        CType(Me.ImagenHuella, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboAcceso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTrabajador, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodigoFiltrar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        CType(Me.GradientPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel4.SuspendLayout()
        CType(Me.thumb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GradientPanel3
        '
        Me.GradientPanel3.BorderColor = System.Drawing.Color.Silver
        Me.GradientPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel3.Controls.Add(Me.GradientPanel5)
        Me.GradientPanel3.Controls.Add(Me.chHuella)
        Me.GradientPanel3.Controls.Add(Me.Label4)
        Me.GradientPanel3.Controls.Add(Me.Label1)
        Me.GradientPanel3.Controls.Add(Me.Label11)
        Me.GradientPanel3.Controls.Add(Me.lblInfo)
        Me.GradientPanel3.Controls.Add(Me.cboAcceso)
        Me.GradientPanel3.Controls.Add(Me.Label2)
        Me.GradientPanel3.Controls.Add(Me.txtFecha)
        Me.GradientPanel3.Controls.Add(Me.txtTrabajador)
        Me.GradientPanel3.Controls.Add(Me.txtCodigoFiltrar)
        Me.GradientPanel3.Location = New System.Drawing.Point(15, 24)
        Me.GradientPanel3.Name = "GradientPanel3"
        Me.GradientPanel3.Size = New System.Drawing.Size(368, 550)
        Me.GradientPanel3.TabIndex = 3
        '
        'GradientPanel5
        '
        Me.GradientPanel5.BackgroundColor = New Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.PatternStyle.Weave, System.Drawing.Color.White, System.Drawing.Color.White)
        Me.GradientPanel5.BorderColor = System.Drawing.Color.DarkTurquoise
        Me.GradientPanel5.BorderSingle = System.Windows.Forms.ButtonBorderStyle.Dotted
        Me.GradientPanel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel5.Controls.Add(Me.ImagenHuella)
        Me.GradientPanel5.Location = New System.Drawing.Point(48, 174)
        Me.GradientPanel5.Name = "GradientPanel5"
        Me.GradientPanel5.Size = New System.Drawing.Size(254, 250)
        Me.GradientPanel5.TabIndex = 408
        '
        'ImagenHuella
        '
        Me.ImagenHuella.BackColor = System.Drawing.Color.White
        Me.ImagenHuella.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImagenHuella.Image = CType(resources.GetObject("ImagenHuella.Image"), System.Drawing.Image)
        Me.ImagenHuella.Location = New System.Drawing.Point(0, 0)
        Me.ImagenHuella.Name = "ImagenHuella"
        Me.ImagenHuella.Size = New System.Drawing.Size(252, 248)
        Me.ImagenHuella.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ImagenHuella.TabIndex = 0
        Me.ImagenHuella.TabStop = False
        '
        'chHuella
        '
        Me.chHuella.AutoSize = True
        Me.chHuella.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chHuella.Location = New System.Drawing.Point(48, 146)
        Me.chHuella.Name = "chHuella"
        Me.chHuella.Size = New System.Drawing.Size(158, 17)
        Me.chHuella.TabIndex = 407
        Me.chHuella.Text = "Activar detección de huella"
        Me.chHuella.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DimGray
        Me.Label4.Location = New System.Drawing.Point(19, 461)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(122, 19)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Fecha de ingreso"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(19, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 19)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "DNI."
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.DimGray
        Me.Label11.Location = New System.Drawing.Point(19, 76)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(71, 19)
        Me.Label11.TabIndex = 13
        Me.Label11.Text = "Nombres"
        '
        'lblInfo
        '
        Me.lblInfo.AutoSize = True
        Me.lblInfo.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(95, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.lblInfo.Location = New System.Drawing.Point(173, 439)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(11, 14)
        Me.lblInfo.TabIndex = 12
        Me.lblInfo.Text = "-"
        Me.lblInfo.Visible = False
        '
        'cboAcceso
        '
        Me.cboAcceso.BackColor = System.Drawing.Color.White
        Me.cboAcceso.BeforeTouchSize = New System.Drawing.Size(245, 21)
        Me.cboAcceso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAcceso.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAcceso.Location = New System.Drawing.Point(23, 488)
        Me.cboAcceso.Name = "cboAcceso"
        Me.cboAcceso.Size = New System.Drawing.Size(245, 21)
        Me.cboAcceso.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboAcceso.TabIndex = 11
        Me.cboAcceso.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Gray
        Me.Label2.Location = New System.Drawing.Point(19, 460)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 19)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Tipo de acceso"
        Me.Label2.Visible = False
        '
        'txtFecha
        '
        Me.txtFecha.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
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
        Me.txtFecha.Calendar.Size = New System.Drawing.Size(296, 174)
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
        Me.txtFecha.Calendar.NoneButton.Location = New System.Drawing.Point(224, 0)
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
        Me.txtFecha.Calendar.TodayButton.Size = New System.Drawing.Size(224, 20)
        Me.txtFecha.Calendar.TodayButton.Text = "Today"
        Me.txtFecha.Calendar.TodayButton.UseVisualStyle = True
        Me.txtFecha.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtFecha.Checked = False
        Me.txtFecha.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFecha.DropDownImage = Nothing
        Me.txtFecha.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecha.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecha.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtFecha.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha.Location = New System.Drawing.Point(23, 488)
        Me.txtFecha.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecha.MinValue = New Date(CType(0, Long))
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ReadOnly = True
        Me.txtFecha.ShowCheckBox = False
        Me.txtFecha.ShowDropButton = False
        Me.txtFecha.Size = New System.Drawing.Size(298, 21)
        Me.txtFecha.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFecha.TabIndex = 8
        Me.txtFecha.Value = New Date(2017, 5, 29, 23, 28, 20, 18)
        '
        'txtTrabajador
        '
        Me.txtTrabajador.BackColor = System.Drawing.Color.White
        Me.txtTrabajador.BeforeTouchSize = New System.Drawing.Size(298, 25)
        Me.txtTrabajador.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTrabajador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTrabajador.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTrabajador.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTrabajador.Location = New System.Drawing.Point(23, 103)
        Me.txtTrabajador.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTrabajador.Name = "txtTrabajador"
        Me.txtTrabajador.ReadOnly = True
        Me.txtTrabajador.Size = New System.Drawing.Size(298, 23)
        Me.txtTrabajador.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtTrabajador.TabIndex = 5
        '
        'txtCodigoFiltrar
        '
        Me.txtCodigoFiltrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtCodigoFiltrar.BeforeTouchSize = New System.Drawing.Size(298, 25)
        Me.txtCodigoFiltrar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtCodigoFiltrar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigoFiltrar.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCodigoFiltrar.FarImage = CType(resources.GetObject("txtCodigoFiltrar.FarImage"), System.Drawing.Image)
        Me.txtCodigoFiltrar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoFiltrar.Location = New System.Drawing.Point(23, 45)
        Me.txtCodigoFiltrar.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtCodigoFiltrar.Name = "txtCodigoFiltrar"
        Me.txtCodigoFiltrar.Size = New System.Drawing.Size(298, 25)
        Me.txtCodigoFiltrar.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtCodigoFiltrar.TabIndex = 1
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GradientPanel1.BorderColor = System.Drawing.Color.Silver
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.Clock1)
        Me.GradientPanel1.Location = New System.Drawing.Point(393, 24)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(368, 189)
        Me.GradientPanel1.TabIndex = 4
        '
        'Clock1
        '
        Me.Clock1.BackgroundColor = System.Drawing.SystemColors.Control
        Me.Clock1.BeforeTouchSize = New System.Drawing.Size(360, 180)
        Me.Clock1.ClockFormat = "HH:mm:ss"
        Me.Clock1.ClockFrame = Syncfusion.Windows.Forms.Tools.ClockFrames.RectangularFrame
        Me.Clock1.ClockShape = Syncfusion.Windows.Forms.Tools.ClockShapes.Rectangle
        Me.Clock1.ClockType = Syncfusion.Windows.Forms.Tools.ClockTypes.Digital
        Me.Clock1.CurrentDateTime = New Date(2017, 6, 2, 15, 19, 54, 468)
        Me.Clock1.CustomTime = New Date(2017, 6, 2, 15, 19, 54, 468)
        Me.Clock1.DigitalRenderer = DigitalClockRenderer1
        Me.Clock1.DisplayDates = False
        Me.Clock1.Location = New System.Drawing.Point(3, 13)
        Me.Clock1.MinimumSize = New System.Drawing.Size(75, 75)
        Me.Clock1.Name = "Clock1"
        Me.Clock1.Now = New Date(CType(0, Long))
        Me.Clock1.Remainder = New Date(2017, 6, 2, 15, 19, 54, 404)
        Me.Clock1.Renderer = ClockRenderer1
        Me.Clock1.ShowAMorPM = True
        Me.Clock1.ShowClockFrame = False
        Me.Clock1.ShowCustomTimeClock = False
        Me.Clock1.ShowHourDesignator = True
        Me.Clock1.Size = New System.Drawing.Size(360, 180)
        Me.Clock1.StopTimer = False
        Me.Clock1.TabIndex = 0
        Me.Clock1.Text = "Reloj"
        '
        'GradientPanel2
        '
        Me.GradientPanel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GradientPanel2.BorderColor = System.Drawing.Color.Silver
        Me.GradientPanel2.BorderSides = CType((((System.Windows.Forms.Border3DSide.Left Or System.Windows.Forms.Border3DSide.Top) _
            Or System.Windows.Forms.Border3DSide.Right) _
            Or System.Windows.Forms.Border3DSide.Bottom), System.Windows.Forms.Border3DSide)
        Me.GradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel2.Controls.Add(Me.Label13)
        Me.GradientPanel2.Controls.Add(Me.LinkLabel2)
        Me.GradientPanel2.Controls.Add(Me.Label7)
        Me.GradientPanel2.Controls.Add(Me.Label8)
        Me.GradientPanel2.Controls.Add(Me.Label9)
        Me.GradientPanel2.Controls.Add(Me.Label10)
        Me.GradientPanel2.Controls.Add(Me.lblInicio)
        Me.GradientPanel2.Controls.Add(Me.lblVence)
        Me.GradientPanel2.Controls.Add(Me.lblDiasDisponibles)
        Me.GradientPanel2.Controls.Add(Me.lblCodigoMembresia)
        Me.GradientPanel2.Controls.Add(Me.LinkLabel1)
        Me.GradientPanel2.Controls.Add(Me.ToggleButton22)
        Me.GradientPanel2.Controls.Add(Me.ToggleButton21)
        Me.GradientPanel2.Location = New System.Drawing.Point(393, 219)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(368, 355)
        Me.GradientPanel2.TabIndex = 5
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.DimGray
        Me.Label13.Location = New System.Drawing.Point(27, 52)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(132, 19)
        Me.Label13.TabIndex = 474
        Me.Label13.Text = "Estado membresía"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Font = New System.Drawing.Font("Ebrima", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel2.LinkColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.LinkLabel2.Location = New System.Drawing.Point(68, 145)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(92, 19)
        Me.LinkLabel2.TabIndex = 473
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Ver asistencia"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DimGray
        Me.Label7.Location = New System.Drawing.Point(129, 243)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 19)
        Me.Label7.TabIndex = 472
        Me.Label7.Text = "Inicio:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DimGray
        Me.Label8.Location = New System.Drawing.Point(126, 269)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 19)
        Me.Label8.TabIndex = 471
        Me.Label8.Text = "Vence:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DimGray
        Me.Label9.Location = New System.Drawing.Point(57, 215)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(121, 19)
        Me.Label9.TabIndex = 470
        Me.Label9.Text = "Días dispónibles:"
        Me.Label9.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DimGray
        Me.Label10.Location = New System.Drawing.Point(37, 187)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(141, 19)
        Me.Label10.TabIndex = 469
        Me.Label10.Text = "Código Membresía:"
        '
        'lblInicio
        '
        Me.lblInicio.AutoSize = True
        Me.lblInicio.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInicio.Location = New System.Drawing.Point(191, 243)
        Me.lblInicio.Name = "lblInicio"
        Me.lblInicio.Size = New System.Drawing.Size(15, 19)
        Me.lblInicio.TabIndex = 468
        Me.lblInicio.Text = "-"
        '
        'lblVence
        '
        Me.lblVence.AutoSize = True
        Me.lblVence.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVence.Location = New System.Drawing.Point(191, 269)
        Me.lblVence.Name = "lblVence"
        Me.lblVence.Size = New System.Drawing.Size(15, 19)
        Me.lblVence.TabIndex = 467
        Me.lblVence.Text = "-"
        '
        'lblDiasDisponibles
        '
        Me.lblDiasDisponibles.AutoSize = True
        Me.lblDiasDisponibles.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiasDisponibles.Location = New System.Drawing.Point(191, 215)
        Me.lblDiasDisponibles.Name = "lblDiasDisponibles"
        Me.lblDiasDisponibles.Size = New System.Drawing.Size(15, 19)
        Me.lblDiasDisponibles.TabIndex = 466
        Me.lblDiasDisponibles.Text = "-"
        Me.lblDiasDisponibles.Visible = False
        '
        'lblCodigoMembresia
        '
        Me.lblCodigoMembresia.AutoSize = True
        Me.lblCodigoMembresia.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigoMembresia.Location = New System.Drawing.Point(191, 187)
        Me.lblCodigoMembresia.Name = "lblCodigoMembresia"
        Me.lblCodigoMembresia.Size = New System.Drawing.Size(15, 19)
        Me.lblCodigoMembresia.TabIndex = 465
        Me.lblCodigoMembresia.Text = "-"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.LinkLabel1.Location = New System.Drawing.Point(54, 92)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(106, 19)
        Me.LinkLabel1.TabIndex = 463
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Deudas X pagar"
        '
        'ToggleButton22
        '
        Me.ToggleButton22.ActiveColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.ToggleButton22.ActiveText = "SI"
        Me.ToggleButton22.BackColor = System.Drawing.Color.Transparent
        Me.ToggleButton22.Enabled = False
        Me.ToggleButton22.InActiveColor = System.Drawing.Color.WhiteSmoke
        Me.ToggleButton22.InActiveText = "NO"
        Me.ToggleButton22.Location = New System.Drawing.Point(202, 87)
        Me.ToggleButton22.MaximumSize = New System.Drawing.Size(135, 51)
        Me.ToggleButton22.MinimumSize = New System.Drawing.Size(93, 30)
        Me.ToggleButton22.Name = "ToggleButton22"
        Me.ToggleButton22.Size = New System.Drawing.Size(93, 30)
        Me.ToggleButton22.SliderColor = System.Drawing.Color.Black
        Me.ToggleButton22.SlidingAngle = 8
        Me.ToggleButton22.TabIndex = 462
        Me.ToggleButton22.Text = "ToggleButton22"
        Me.ToggleButton22.TextColor = System.Drawing.Color.White
        Me.ToggleButton22.ToggleState = Helios.Cont.Presentation.WinForm.ToggleButton2.ToggleButtonState.OFF
        Me.ToggleButton22.ToggleStyle = Helios.Cont.Presentation.WinForm.ToggleButton2.ToggleButtonStyle.IOS
        Me.ToggleButton22.Visible = False
        '
        'ToggleButton21
        '
        Me.ToggleButton21.ActiveColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.ToggleButton21.ActiveText = "Activo"
        Me.ToggleButton21.BackColor = System.Drawing.Color.Transparent
        Me.ToggleButton21.Enabled = False
        Me.ToggleButton21.InActiveColor = System.Drawing.Color.WhiteSmoke
        Me.ToggleButton21.InActiveText = "Vencido"
        Me.ToggleButton21.Location = New System.Drawing.Point(202, 46)
        Me.ToggleButton21.MaximumSize = New System.Drawing.Size(135, 51)
        Me.ToggleButton21.MinimumSize = New System.Drawing.Size(93, 30)
        Me.ToggleButton21.Name = "ToggleButton21"
        Me.ToggleButton21.Size = New System.Drawing.Size(93, 30)
        Me.ToggleButton21.SliderColor = System.Drawing.Color.Black
        Me.ToggleButton21.SlidingAngle = 8
        Me.ToggleButton21.TabIndex = 460
        Me.ToggleButton21.Text = "ToggleButton21"
        Me.ToggleButton21.TextColor = System.Drawing.Color.White
        Me.ToggleButton21.ToggleState = Helios.Cont.Presentation.WinForm.ToggleButton2.ToggleButtonState.[ON]
        Me.ToggleButton21.ToggleStyle = Helios.Cont.Presentation.WinForm.ToggleButton2.ToggleButtonStyle.IOS
        Me.ToggleButton21.Visible = False
        '
        'GradientPanel4
        '
        Me.GradientPanel4.BackColor = System.Drawing.Color.White
        Me.GradientPanel4.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.GradientPanel4.BorderColor = System.Drawing.SystemColors.ScrollBar
        Me.GradientPanel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel4.Controls.Add(Me.RoundButton21)
        Me.GradientPanel4.Controls.Add(Me.Line21)
        Me.GradientPanel4.Controls.Add(Me.PredictedText)
        Me.GradientPanel4.Controls.Add(Me.illustration)
        Me.GradientPanel4.Controls.Add(Me.AuditPredicted)
        Me.GradientPanel4.Controls.Add(Me.thumb)
        Me.GradientPanel4.Location = New System.Drawing.Point(770, 24)
        Me.GradientPanel4.Name = "GradientPanel4"
        Me.GradientPanel4.Size = New System.Drawing.Size(443, 550)
        Me.GradientPanel4.TabIndex = 42
        '
        'RoundButton21
        '
        Me.RoundButton21.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton21.BackColor = System.Drawing.Color.FromArgb(CType(CType(206, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.RoundButton21.BeforeTouchSize = New System.Drawing.Size(404, 42)
        Me.RoundButton21.BorderStyleAdv = Syncfusion.Windows.Forms.ButtonAdvBorderStyle.None
        Me.RoundButton21.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundButton21.ForeColor = System.Drawing.Color.White
        Me.RoundButton21.IsBackStageButton = False
        Me.RoundButton21.Location = New System.Drawing.Point(18, 488)
        Me.RoundButton21.Name = "RoundButton21"
        Me.RoundButton21.Size = New System.Drawing.Size(404, 42)
        Me.RoundButton21.TabIndex = 43
        Me.RoundButton21.Text = "Registrar asistencia !"
        Me.RoundButton21.UseVisualStyle = True
        '
        'Line21
        '
        Me.Line21.LineColor = System.Drawing.Color.LightGray
        Me.Line21.Location = New System.Drawing.Point(40, 70)
        Me.Line21.Name = "Line21"
        Me.Line21.Size = New System.Drawing.Size(364, 2)
        Me.Line21.TabIndex = 30
        Me.Line21.Text = "Line21"
        '
        'PredictedText
        '
        Me.PredictedText.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PredictedText.Location = New System.Drawing.Point(125, 360)
        Me.PredictedText.Name = "PredictedText"
        Me.PredictedText.Size = New System.Drawing.Size(433, 114)
        Me.PredictedText.TabIndex = 29
        '
        'illustration
        '
        Me.illustration.AutoSize = True
        Me.illustration.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.illustration.ForeColor = System.Drawing.Color.DimGray
        Me.illustration.Location = New System.Drawing.Point(128, 19)
        Me.illustration.Name = "illustration"
        Me.illustration.Size = New System.Drawing.Size(178, 30)
        Me.illustration.TabIndex = 26
        Me.illustration.Text = "Resultado acceso"
        '
        'AuditPredicted
        '
        Me.AuditPredicted.Font = New System.Drawing.Font("Segoe UI", 26.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AuditPredicted.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.AuditPredicted.Location = New System.Drawing.Point(174, 290)
        Me.AuditPredicted.Name = "AuditPredicted"
        Me.AuditPredicted.Size = New System.Drawing.Size(156, 62)
        Me.AuditPredicted.TabIndex = 28
        '
        'thumb
        '
        Me.thumb.Location = New System.Drawing.Point(168, 156)
        Me.thumb.Name = "thumb"
        Me.thumb.Size = New System.Drawing.Size(162, 131)
        Me.thumb.TabIndex = 27
        Me.thumb.TabStop = False
        '
        'ImageListAdv1
        '
        Me.ImageListAdv1.Images.AddRange(New System.Drawing.Image() {CType(resources.GetObject("ImageListAdv1.Images"), System.Drawing.Image), CType(resources.GetObject("ImageListAdv1.Images1"), System.Drawing.Image)})
        Me.ImageListAdv1.ImageSize = New System.Drawing.Size(104, 104)
        '
        'ImageListAdv2
        '
        Me.ImageListAdv2.Images.AddRange(New System.Drawing.Image() {CType(resources.GetObject("ImageListAdv2.Images"), System.Drawing.Image)})
        Me.ImageListAdv2.ImageSize = New System.Drawing.Size(256, 256)
        '
        'frmRegistroAsistenciaSocios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BorderColor = System.Drawing.Color.LightGray
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.CaptionBarHeight = 60
        Me.CaptionButtonColor = System.Drawing.Color.White
        Me.CaptionButtonHoverColor = System.Drawing.Color.White
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(15, 12)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(35, 35)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Ebrima", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.White
        CaptionLabel1.Location = New System.Drawing.Point(55, 7)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(200, 24)
        CaptionLabel1.Text = "Registro de asistencia"
        CaptionLabel2.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        CaptionLabel2.Location = New System.Drawing.Point(55, 24)
        CaptionLabel2.Name = "CaptionLabel2"
        CaptionLabel2.Size = New System.Drawing.Size(200, 24)
        CaptionLabel2.Text = "Control Personal"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.CaptionLabels.Add(CaptionLabel2)
        Me.ClientSize = New System.Drawing.Size(1225, 583)
        Me.Controls.Add(Me.GradientPanel4)
        Me.Controls.Add(Me.GradientPanel2)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.GradientPanel3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmRegistroAsistenciaSocios"
        Me.ShowIcon = False
        Me.ShowMaximizeBox = False
        Me.Text = ""
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel3.ResumeLayout(False)
        Me.GradientPanel3.PerformLayout()
        CType(Me.GradientPanel5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel5.ResumeLayout(False)
        CType(Me.ImagenHuella, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboAcceso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTrabajador, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodigoFiltrar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        Me.GradientPanel2.PerformLayout()
        CType(Me.GradientPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel4.ResumeLayout(False)
        Me.GradientPanel4.PerformLayout()
        CType(Me.thumb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GradientPanel3 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents txtFecha As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents txtTrabajador As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtCodigoFiltrar As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents Clock1 As Syncfusion.Windows.Forms.Tools.Clock
    Friend WithEvents GradientPanel2 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents ToggleButton22 As ToggleButton2
    Friend WithEvents ToggleButton21 As ToggleButton2
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents cboAcceso As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label2 As Label
    Friend WithEvents lblDiasDisponibles As Label
    Friend WithEvents lblCodigoMembresia As Label
    Friend WithEvents lblVence As Label
    Friend WithEvents lblInicio As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents lblInfo As Label
    Friend WithEvents LinkLabel2 As LinkLabel
    Private WithEvents GradientPanel4 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Private WithEvents PredictedText As Label
    Private WithEvents illustration As Label
    Private WithEvents AuditPredicted As Label
    Private WithEvents thumb As PictureBox
    Friend WithEvents Line21 As Line2
    Friend WithEvents RoundButton21 As RoundButton2
    Private WithEvents Label11 As Label
    Private WithEvents Label1 As Label
    Private WithEvents Label13 As Label
    Private WithEvents Label4 As Label
    Private WithEvents ImageListAdv1 As Syncfusion.Windows.Forms.Tools.ImageListAdv
    Private WithEvents GradientPanel5 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents ImagenHuella As PictureBox
    Friend WithEvents chHuella As CheckBox
    Private WithEvents ImageListAdv2 As Syncfusion.Windows.Forms.Tools.ImageListAdv
End Class

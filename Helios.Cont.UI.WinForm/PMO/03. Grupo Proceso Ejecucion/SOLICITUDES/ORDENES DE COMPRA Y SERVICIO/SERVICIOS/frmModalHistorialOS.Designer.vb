<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModalHistorialOS
    Inherits Helios.Cont.Presentation.WinForm.frmMaster

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
        Dim ActiveStateCollection1 As Syncfusion.Windows.Forms.Tools.ActiveStateCollection = New Syncfusion.Windows.Forms.Tools.ActiveStateCollection()
        Dim InactiveStateCollection1 As Syncfusion.Windows.Forms.Tools.InactiveStateCollection = New Syncfusion.Windows.Forms.Tools.InactiveStateCollection()
        Dim ToggleButtonRenderer1 As Syncfusion.Windows.Forms.Tools.ToggleButtonRenderer = New Syncfusion.Windows.Forms.Tools.ToggleButtonRenderer()
        Dim SliderCollection1 As Syncfusion.Windows.Forms.Tools.SliderCollection = New Syncfusion.Windows.Forms.Tools.SliderCollection()
        Dim ActiveStateCollection2 As Syncfusion.Windows.Forms.Tools.ActiveStateCollection = New Syncfusion.Windows.Forms.Tools.ActiveStateCollection()
        Dim InactiveStateCollection2 As Syncfusion.Windows.Forms.Tools.InactiveStateCollection = New Syncfusion.Windows.Forms.Tools.InactiveStateCollection()
        Dim ToggleButtonRenderer2 As Syncfusion.Windows.Forms.Tools.ToggleButtonRenderer = New Syncfusion.Windows.Forms.Tools.ToggleButtonRenderer()
        Dim SliderCollection2 As Syncfusion.Windows.Forms.Tools.SliderCollection = New Syncfusion.Windows.Forms.Tools.SliderCollection()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmModalHistorialOS))
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblDetracciones = New System.Windows.Forms.Label()
        Me.lblFGarantia = New System.Windows.Forms.Label()
        Me.txtDetracciones = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.txtFGarantia = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.ToggleButton1 = New Syncfusion.Windows.Forms.Tools.ToggleButton()
        Me.cboObjetoContratacion = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtImporteContratacionME = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.txtImporteContratacion = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNombreEntregable = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.fechainicio = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.fechafin = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.tbDetraccion = New Syncfusion.Windows.Forms.Tools.ToggleButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtContra = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ToolStrip5 = New System.Windows.Forms.ToolStrip()
        Me.lblPerido = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.PanelError = New System.Windows.Forms.Panel()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.GroupBox3.SuspendLayout()
        CType(Me.ToggleButton1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtImporteContratacionME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtImporteContratacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.fechainicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fechainicio.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fechafin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fechafin.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbDetraccion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip5.SuspendLayout()
        Me.PanelError.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblDetracciones)
        Me.GroupBox3.Controls.Add(Me.lblFGarantia)
        Me.GroupBox3.Controls.Add(Me.txtDetracciones)
        Me.GroupBox3.Controls.Add(Me.txtFGarantia)
        Me.GroupBox3.Controls.Add(Me.ToggleButton1)
        Me.GroupBox3.Controls.Add(Me.cboObjetoContratacion)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.txtImporteContratacionME)
        Me.GroupBox3.Controls.Add(Me.txtImporteContratacion)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.txtNombreEntregable)
        Me.GroupBox3.Controls.Add(Me.GroupBox2)
        Me.GroupBox3.Controls.Add(Me.tbDetraccion)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.txtContra)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Enabled = False
        Me.GroupBox3.Location = New System.Drawing.Point(0, 66)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(392, 278)
        Me.GroupBox3.TabIndex = 447
        Me.GroupBox3.TabStop = False
        '
        'lblDetracciones
        '
        Me.lblDetracciones.AutoSize = True
        Me.lblDetracciones.ForeColor = System.Drawing.Color.Black
        Me.lblDetracciones.Location = New System.Drawing.Point(309, 374)
        Me.lblDetracciones.Name = "lblDetracciones"
        Me.lblDetracciones.Size = New System.Drawing.Size(16, 13)
        Me.lblDetracciones.TabIndex = 442
        Me.lblDetracciones.Text = "%"
        Me.lblDetracciones.Visible = False
        '
        'lblFGarantia
        '
        Me.lblFGarantia.AutoSize = True
        Me.lblFGarantia.ForeColor = System.Drawing.Color.Black
        Me.lblFGarantia.Location = New System.Drawing.Point(306, 346)
        Me.lblFGarantia.Name = "lblFGarantia"
        Me.lblFGarantia.Size = New System.Drawing.Size(19, 13)
        Me.lblFGarantia.TabIndex = 441
        Me.lblFGarantia.Text = " %"
        Me.lblFGarantia.Visible = False
        '
        'txtDetracciones
        '
        Me.txtDetracciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDetracciones.Location = New System.Drawing.Point(258, 371)
        Me.txtDetracciones.Name = "txtDetracciones"
        Me.txtDetracciones.Size = New System.Drawing.Size(45, 19)
        Me.txtDetracciones.TabIndex = 440
        Me.txtDetracciones.Visible = False
        '
        'txtFGarantia
        '
        Me.txtFGarantia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFGarantia.Location = New System.Drawing.Point(258, 343)
        Me.txtFGarantia.Name = "txtFGarantia"
        Me.txtFGarantia.Size = New System.Drawing.Size(45, 19)
        Me.txtFGarantia.TabIndex = 439
        Me.txtFGarantia.Visible = False
        '
        'ToggleButton1
        '
        ActiveStateCollection1.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer))
        ActiveStateCollection1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        ActiveStateCollection1.HoverColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer))
        ActiveStateCollection1.Text = "SI"
        Me.ToggleButton1.ActiveState = ActiveStateCollection1
        Me.ToggleButton1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.ToggleButton1.ForeColor = System.Drawing.Color.Black
        InactiveStateCollection1.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer))
        InactiveStateCollection1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        InactiveStateCollection1.ForeColor = System.Drawing.Color.White
        InactiveStateCollection1.HoverColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer))
        InactiveStateCollection1.Text = "NO"
        Me.ToggleButton1.InactiveState = InactiveStateCollection1
        Me.ToggleButton1.Location = New System.Drawing.Point(183, 342)
        Me.ToggleButton1.MinimumSize = New System.Drawing.Size(52, 20)
        Me.ToggleButton1.Name = "ToggleButton1"
        Me.ToggleButton1.Renderer = ToggleButtonRenderer1
        Me.ToggleButton1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ToggleButton1.Size = New System.Drawing.Size(69, 20)
        SliderCollection1.BackColor = System.Drawing.Color.White
        SliderCollection1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        SliderCollection1.ForeColor = System.Drawing.Color.White
        SliderCollection1.HoverColor = System.Drawing.Color.FromArgb(CType(CType(8, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(171, Byte), Integer))
        SliderCollection1.Width = 30
        Me.ToggleButton1.Slider = SliderCollection1
        Me.ToggleButton1.TabIndex = 438
        Me.ToggleButton1.Text = "Button1"
        Me.ToggleButton1.Visible = False
        '
        'cboObjetoContratacion
        '
        Me.cboObjetoContratacion.FormattingEnabled = True
        Me.cboObjetoContratacion.Items.AddRange(New Object() {"DIARIO", "SEMANAL", "QUINCENAL", "MENSUAL", "BIMESTRAL", "TRIMESTRAL", "SEMESTRAL", "ANUAL", "OTROS"})
        Me.cboObjetoContratacion.Location = New System.Drawing.Point(139, 119)
        Me.cboObjetoContratacion.Name = "cboObjetoContratacion"
        Me.cboObjetoContratacion.Size = New System.Drawing.Size(179, 21)
        Me.cboObjetoContratacion.TabIndex = 436
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(252, 153)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 433
        Me.Label2.Text = "ME.:"
        Me.Label2.Visible = False
        '
        'txtImporteContratacionME
        '
        Me.txtImporteContratacionME.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.txtImporteContratacionME.BeforeTouchSize = New System.Drawing.Size(96, 23)
        Me.txtImporteContratacionME.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtImporteContratacionME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtImporteContratacionME.DecimalPlaces = 2
        Me.txtImporteContratacionME.Enabled = False
        Me.txtImporteContratacionME.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImporteContratacionME.Location = New System.Drawing.Point(287, 146)
        Me.txtImporteContratacionME.Maximum = New Decimal(New Integer() {268435456, 1042612833, 542101086, 0})
        Me.txtImporteContratacionME.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtImporteContratacionME.Name = "txtImporteContratacionME"
        Me.txtImporteContratacionME.Size = New System.Drawing.Size(96, 23)
        Me.txtImporteContratacionME.TabIndex = 426
        Me.txtImporteContratacionME.TabStop = False
        Me.txtImporteContratacionME.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtImporteContratacionME.ThousandsSeparator = True
        Me.txtImporteContratacionME.Visible = False
        Me.txtImporteContratacionME.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'txtImporteContratacion
        '
        Me.txtImporteContratacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.txtImporteContratacion.BeforeTouchSize = New System.Drawing.Size(96, 23)
        Me.txtImporteContratacion.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtImporteContratacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtImporteContratacion.DecimalPlaces = 2
        Me.txtImporteContratacion.Enabled = False
        Me.txtImporteContratacion.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImporteContratacion.Location = New System.Drawing.Point(139, 146)
        Me.txtImporteContratacion.Maximum = New Decimal(New Integer() {268435456, 1042612833, 542101086, 0})
        Me.txtImporteContratacion.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtImporteContratacion.Name = "txtImporteContratacion"
        Me.txtImporteContratacion.Size = New System.Drawing.Size(96, 23)
        Me.txtImporteContratacion.TabIndex = 425
        Me.txtImporteContratacion.TabStop = False
        Me.txtImporteContratacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtImporteContratacion.ThousandsSeparator = True
        Me.txtImporteContratacion.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(7, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 13)
        Me.Label1.TabIndex = 418
        Me.Label1.Text = "Nombre de entregable:"
        '
        'txtNombreEntregable
        '
        Me.txtNombreEntregable.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombreEntregable.Location = New System.Drawing.Point(139, 11)
        Me.txtNombreEntregable.Multiline = True
        Me.txtNombreEntregable.Name = "txtNombreEntregable"
        Me.txtNombreEntregable.Size = New System.Drawing.Size(244, 57)
        Me.txtNombreEntregable.TabIndex = 419
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.fechainicio)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.fechafin)
        Me.GroupBox2.ForeColor = System.Drawing.Color.SteelBlue
        Me.GroupBox2.Location = New System.Drawing.Point(14, 182)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(369, 84)
        Me.GroupBox2.TabIndex = 417
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Plazo de Contratación"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label3.Location = New System.Drawing.Point(121, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 209
        Me.Label3.Text = "Desde:"
        '
        'fechainicio
        '
        Me.fechainicio.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.fechainicio.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.fechainicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.fechainicio.Calendar.AllowMultipleSelection = False
        Me.fechainicio.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.fechainicio.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.fechainicio.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.fechainicio.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.fechainicio.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.fechainicio.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.fechainicio.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fechainicio.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fechainicio.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fechainicio.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.fechainicio.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.fechainicio.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.fechainicio.Calendar.HighlightColor = System.Drawing.Color.White
        Me.fechainicio.Calendar.Iso8601CalenderFormat = False
        Me.fechainicio.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.fechainicio.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.fechainicio.Calendar.Name = "monthCalendar"
        Me.fechainicio.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.fechainicio.Calendar.SelectedDates = New Date(-1) {}
        Me.fechainicio.Calendar.Size = New System.Drawing.Size(147, 174)
        Me.fechainicio.Calendar.SizeToFit = True
        Me.fechainicio.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.fechainicio.Calendar.TabIndex = 0
        Me.fechainicio.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.fechainicio.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.fechainicio.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.fechainicio.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.fechainicio.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.fechainicio.Calendar.NoneButton.IsBackStageButton = False
        Me.fechainicio.Calendar.NoneButton.Location = New System.Drawing.Point(75, 0)
        Me.fechainicio.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.fechainicio.Calendar.NoneButton.Text = "None"
        Me.fechainicio.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.fechainicio.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.fechainicio.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.fechainicio.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.fechainicio.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.fechainicio.Calendar.TodayButton.IsBackStageButton = False
        Me.fechainicio.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.fechainicio.Calendar.TodayButton.Size = New System.Drawing.Size(75, 20)
        Me.fechainicio.Calendar.TodayButton.Text = "Today"
        Me.fechainicio.Calendar.TodayButton.UseVisualStyle = True
        Me.fechainicio.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fechainicio.CalendarForeColor = System.Drawing.SystemColors.ControlText
        Me.fechainicio.CalendarSize = New System.Drawing.Size(189, 176)
        Me.fechainicio.CustomFormat = "dd/MM/yyyy"
        Me.fechainicio.DropDownImage = Nothing
        Me.fechainicio.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.fechainicio.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.fechainicio.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.fechainicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.fechainicio.Location = New System.Drawing.Point(169, 16)
        Me.fechainicio.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.fechainicio.MinValue = New Date(CType(0, Long))
        Me.fechainicio.Name = "fechainicio"
        Me.fechainicio.ShowCheckBox = False
        Me.fechainicio.Size = New System.Drawing.Size(151, 20)
        Me.fechainicio.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.fechainicio.TabIndex = 210
        Me.fechainicio.Value = New Date(2015, 9, 18, 8, 21, 28, 552)
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label10.Location = New System.Drawing.Point(121, 38)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(39, 13)
        Me.Label10.TabIndex = 252
        Me.Label10.Text = "Hasta:"
        '
        'fechafin
        '
        Me.fechafin.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.fechafin.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.fechafin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.fechafin.Calendar.AllowMultipleSelection = False
        Me.fechafin.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.fechafin.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.fechafin.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.fechafin.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.fechafin.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.fechafin.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.fechafin.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fechafin.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fechafin.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fechafin.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.fechafin.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.fechafin.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.fechafin.Calendar.HighlightColor = System.Drawing.Color.White
        Me.fechafin.Calendar.Iso8601CalenderFormat = False
        Me.fechafin.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.fechafin.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.fechafin.Calendar.Name = "monthCalendar"
        Me.fechafin.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.fechafin.Calendar.SelectedDates = New Date(-1) {}
        Me.fechafin.Calendar.Size = New System.Drawing.Size(148, 174)
        Me.fechafin.Calendar.SizeToFit = True
        Me.fechafin.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.fechafin.Calendar.TabIndex = 0
        Me.fechafin.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.fechafin.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.fechafin.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.fechafin.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.fechafin.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.fechafin.Calendar.NoneButton.IsBackStageButton = False
        Me.fechafin.Calendar.NoneButton.Location = New System.Drawing.Point(76, 0)
        Me.fechafin.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.fechafin.Calendar.NoneButton.Text = "None"
        Me.fechafin.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.fechafin.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.fechafin.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.fechafin.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.fechafin.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.fechafin.Calendar.TodayButton.IsBackStageButton = False
        Me.fechafin.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.fechafin.Calendar.TodayButton.Size = New System.Drawing.Size(76, 20)
        Me.fechafin.Calendar.TodayButton.Text = "Today"
        Me.fechafin.Calendar.TodayButton.UseVisualStyle = True
        Me.fechafin.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fechafin.CalendarForeColor = System.Drawing.SystemColors.ControlText
        Me.fechafin.CalendarSize = New System.Drawing.Size(189, 176)
        Me.fechafin.CustomFormat = "dd/MM/yyyy "
        Me.fechafin.DropDownImage = Nothing
        Me.fechafin.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.fechafin.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.fechafin.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.fechafin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.fechafin.Location = New System.Drawing.Point(169, 40)
        Me.fechafin.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.fechafin.MinValue = New Date(CType(0, Long))
        Me.fechafin.Name = "fechafin"
        Me.fechafin.ShowCheckBox = False
        Me.fechafin.Size = New System.Drawing.Size(152, 20)
        Me.fechafin.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.fechafin.TabIndex = 253
        Me.fechafin.Value = New Date(2015, 9, 18, 8, 21, 31, 962)
        '
        'tbDetraccion
        '
        ActiveStateCollection2.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer))
        ActiveStateCollection2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        ActiveStateCollection2.HoverColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer))
        ActiveStateCollection2.Text = "SI"
        Me.tbDetraccion.ActiveState = ActiveStateCollection2
        Me.tbDetraccion.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.tbDetraccion.ForeColor = System.Drawing.Color.Black
        InactiveStateCollection2.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer))
        InactiveStateCollection2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        InactiveStateCollection2.ForeColor = System.Drawing.Color.White
        InactiveStateCollection2.HoverColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer))
        InactiveStateCollection2.Text = "NO"
        Me.tbDetraccion.InactiveState = InactiveStateCollection2
        Me.tbDetraccion.Location = New System.Drawing.Point(182, 370)
        Me.tbDetraccion.MinimumSize = New System.Drawing.Size(52, 20)
        Me.tbDetraccion.Name = "tbDetraccion"
        Me.tbDetraccion.Renderer = ToggleButtonRenderer2
        Me.tbDetraccion.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbDetraccion.Size = New System.Drawing.Size(69, 20)
        SliderCollection2.BackColor = System.Drawing.Color.White
        SliderCollection2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        SliderCollection2.ForeColor = System.Drawing.Color.White
        SliderCollection2.HoverColor = System.Drawing.Color.FromArgb(CType(CType(8, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(171, Byte), Integer))
        SliderCollection2.Width = 30
        Me.tbDetraccion.Slider = SliderCollection2
        Me.tbDetraccion.TabIndex = 415
        Me.tbDetraccion.Text = "Button1"
        Me.tbDetraccion.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(3, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(130, 13)
        Me.Label6.TabIndex = 403
        Me.Label6.Text = "Objeto de contratación:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(100, 370)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 13)
        Me.Label4.TabIndex = 402
        Me.Label4.Text = "Detracciones:"
        Me.Label4.Visible = False
        '
        'txtContra
        '
        Me.txtContra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtContra.Location = New System.Drawing.Point(139, 74)
        Me.txtContra.Multiline = True
        Me.txtContra.Name = "txtContra"
        Me.txtContra.Size = New System.Drawing.Size(244, 39)
        Me.txtContra.TabIndex = 404
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(1, 153)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(136, 13)
        Me.Label8.TabIndex = 405
        Me.Label8.Text = "Importe de Contratación:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(2, 122)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(131, 13)
        Me.Label12.TabIndex = 406
        Me.Label12.Text = "Periodo de Valorizacion:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(84, 342)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(94, 13)
        Me.Label14.TabIndex = 409
        Me.Label14.Text = "Fondo Garantia.:"
        Me.Label14.Visible = False
        '
        'Timer1
        '
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ToolStrip5)
        Me.Panel1.Controls.Add(Me.PanelError)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(392, 66)
        Me.Panel1.TabIndex = 448
        '
        'ToolStrip5
        '
        Me.ToolStrip5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ToolStrip5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStrip5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip5.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip5.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblPerido, Me.ToolStripSeparator1, Me.ToolStripButton1})
        Me.ToolStrip5.Location = New System.Drawing.Point(0, 22)
        Me.ToolStrip5.Name = "ToolStrip5"
        Me.ToolStrip5.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip5.Size = New System.Drawing.Size(392, 44)
        Me.ToolStrip5.TabIndex = 423
        Me.ToolStrip5.Text = "ToolStrip5"
        '
        'lblPerido
        '
        Me.lblPerido.BackColor = System.Drawing.Color.Transparent
        Me.lblPerido.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!)
        Me.lblPerido.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblPerido.Image = CType(resources.GetObject("lblPerido.Image"), System.Drawing.Image)
        Me.lblPerido.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblPerido.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.lblPerido.Name = "lblPerido"
        Me.lblPerido.Size = New System.Drawing.Size(115, 41)
        Me.lblPerido.Text = "Período: 2017"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 44)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(84, 41)
        Me.ToolStripButton1.Text = " serv"
        '
        'PanelError
        '
        Me.PanelError.BackColor = System.Drawing.Color.Maroon
        Me.PanelError.Controls.Add(Me.PictureBox3)
        Me.PanelError.Controls.Add(Me.lblEstado)
        Me.PanelError.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelError.Location = New System.Drawing.Point(0, 0)
        Me.PanelError.Name = "PanelError"
        Me.PanelError.Size = New System.Drawing.Size(392, 22)
        Me.PanelError.TabIndex = 424
        Me.PanelError.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(373, 0)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(19, 22)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 288
        Me.PictureBox3.TabStop = False
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.BackColor = System.Drawing.Color.Transparent
        Me.lblEstado.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.Color.White
        Me.lblEstado.Location = New System.Drawing.Point(9, 4)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(79, 13)
        Me.lblEstado.TabIndex = 0
        Me.lblEstado.Text = "Mensaje error"
        '
        'frmModalHistorialOS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.Color.White
        Me.CaptionBarHeight = 50
        CaptionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.Location = New System.Drawing.Point(50, 10)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(300, 24)
        CaptionLabel1.Text = "DETALLES - ORDEN DE SERVICIO"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(392, 344)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmModalHistorialOS"
        Me.ShowIcon = False
        Me.Text = ""
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.ToggleButton1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtImporteContratacionME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtImporteContratacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.fechainicio.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fechainicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fechafin.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fechafin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbDetraccion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip5.ResumeLayout(False)
        Me.ToolStrip5.PerformLayout()
        Me.PanelError.ResumeLayout(False)
        Me.PanelError.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lblDetracciones As System.Windows.Forms.Label
    Friend WithEvents lblFGarantia As System.Windows.Forms.Label
    Friend WithEvents txtDetracciones As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents txtFGarantia As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Private WithEvents ToggleButton1 As Syncfusion.Windows.Forms.Tools.ToggleButton
    Friend WithEvents cboObjetoContratacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtImporteContratacionME As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents txtImporteContratacion As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNombreEntregable As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents fechainicio As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents fechafin As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Private WithEvents tbDetraccion As Syncfusion.Windows.Forms.Tools.ToggleButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtContra As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ToolStrip5 As System.Windows.Forms.ToolStrip
    Friend WithEvents lblPerido As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents PanelError As System.Windows.Forms.Panel
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
End Class

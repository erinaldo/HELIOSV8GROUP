<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReporteKardexXproducto
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
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReporteKardexXproducto))
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cboTipoExistencia = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pcProductos = New Syncfusion.Windows.Forms.PopupControlContainer()
        Me.lstProductos = New System.Windows.Forms.ListBox()
        Me.txtBuscarProducto = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtHasta = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.txtINic = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboAlmace = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.cboEstable = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        CType(Me.cboTipoExistencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pcProductos.SuspendLayout()
        CType(Me.txtBuscarProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHasta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHasta.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtINic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtINic.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboAlmace, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboEstable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportViewer1.Location = New System.Drawing.Point(90, 172)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(898, 290)
        Me.ReportViewer1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.cboTipoExistencia)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.pcProductos)
        Me.Panel1.Controls.Add(Me.txtBuscarProducto)
        Me.Panel1.Controls.Add(Me.txtHasta)
        Me.Panel1.Controls.Add(Me.txtINic)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.cboAlmace)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.ButtonAdv1)
        Me.Panel1.Controls.Add(Me.cboEstable)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.GradientPanel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1078, 144)
        Me.Panel1.TabIndex = 1
        '
        'cboTipoExistencia
        '
        Me.cboTipoExistencia.BackColor = System.Drawing.Color.White
        Me.cboTipoExistencia.BeforeTouchSize = New System.Drawing.Size(244, 21)
        Me.cboTipoExistencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoExistencia.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoExistencia.Location = New System.Drawing.Point(288, 116)
        Me.cboTipoExistencia.Name = "cboTipoExistencia"
        Me.cboTipoExistencia.Size = New System.Drawing.Size(244, 21)
        Me.cboTipoExistencia.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboTipoExistencia.TabIndex = 403
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(292, 98)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(108, 12)
        Me.Label7.TabIndex = 403
        Me.Label7.Text = "TIPO DE EXISTENCIA"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'pcProductos
        '
        Me.pcProductos.Controls.Add(Me.lstProductos)
        Me.pcProductos.Location = New System.Drawing.Point(361, 147)
        Me.pcProductos.Name = "pcProductos"
        Me.pcProductos.Size = New System.Drawing.Size(266, 151)
        Me.pcProductos.TabIndex = 402
        '
        'lstProductos
        '
        Me.lstProductos.BackColor = System.Drawing.Color.White
        Me.lstProductos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstProductos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lstProductos.FormattingEnabled = True
        Me.lstProductos.Location = New System.Drawing.Point(0, 0)
        Me.lstProductos.Name = "lstProductos"
        Me.lstProductos.Size = New System.Drawing.Size(266, 151)
        Me.lstProductos.TabIndex = 0
        '
        'txtBuscarProducto
        '
        Me.txtBuscarProducto.BackColor = System.Drawing.Color.White
        Me.txtBuscarProducto.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtBuscarProducto.BorderColor = System.Drawing.Color.YellowGreen
        Me.txtBuscarProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBuscarProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBuscarProducto.CornerRadius = 5
        Me.txtBuscarProducto.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBuscarProducto.Location = New System.Drawing.Point(288, 72)
        Me.txtBuscarProducto.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtBuscarProducto.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtBuscarProducto.Name = "txtBuscarProducto"
        Me.txtBuscarProducto.NearImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.IC6329681
        Me.txtBuscarProducto.Size = New System.Drawing.Size(244, 20)
        Me.txtBuscarProducto.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtBuscarProducto.TabIndex = 215
        '
        'txtHasta
        '
        Me.txtHasta.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtHasta.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtHasta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtHasta.Calendar.AllowMultipleSelection = False
        Me.txtHasta.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtHasta.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHasta.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtHasta.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtHasta.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtHasta.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtHasta.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtHasta.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHasta.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtHasta.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtHasta.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtHasta.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtHasta.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtHasta.Calendar.Iso8601CalenderFormat = False
        Me.txtHasta.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtHasta.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtHasta.Calendar.Name = "monthCalendar"
        Me.txtHasta.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtHasta.Calendar.SelectedDates = New Date(-1) {}
        Me.txtHasta.Calendar.Size = New System.Drawing.Size(105, 174)
        Me.txtHasta.Calendar.SizeToFit = True
        Me.txtHasta.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtHasta.Calendar.TabIndex = 0
        Me.txtHasta.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtHasta.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtHasta.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtHasta.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtHasta.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtHasta.Calendar.NoneButton.IsBackStageButton = False
        Me.txtHasta.Calendar.NoneButton.Location = New System.Drawing.Point(33, 0)
        Me.txtHasta.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtHasta.Calendar.NoneButton.Text = "None"
        Me.txtHasta.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtHasta.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtHasta.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtHasta.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtHasta.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtHasta.Calendar.TodayButton.IsBackStageButton = False
        Me.txtHasta.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtHasta.Calendar.TodayButton.Size = New System.Drawing.Size(33, 20)
        Me.txtHasta.Calendar.TodayButton.Text = "Today"
        Me.txtHasta.Calendar.TodayButton.UseVisualStyle = True
        Me.txtHasta.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHasta.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtHasta.CustomFormat = "dd/MM/yyyy"
        Me.txtHasta.DropDownImage = Nothing
        Me.txtHasta.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtHasta.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtHasta.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtHasta.Location = New System.Drawing.Point(676, 72)
        Me.txtHasta.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtHasta.MinValue = New Date(CType(0, Long))
        Me.txtHasta.Name = "txtHasta"
        Me.txtHasta.ShowCheckBox = False
        Me.txtHasta.Size = New System.Drawing.Size(109, 20)
        Me.txtHasta.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtHasta.TabIndex = 18
        Me.txtHasta.Value = New Date(2015, 12, 30, 16, 33, 14, 694)
        '
        'txtINic
        '
        Me.txtINic.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtINic.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtINic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtINic.Calendar.AllowMultipleSelection = False
        Me.txtINic.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtINic.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtINic.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtINic.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtINic.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtINic.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtINic.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtINic.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtINic.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtINic.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtINic.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtINic.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtINic.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtINic.Calendar.Iso8601CalenderFormat = False
        Me.txtINic.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtINic.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtINic.Calendar.Name = "monthCalendar"
        Me.txtINic.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtINic.Calendar.SelectedDates = New Date(-1) {}
        Me.txtINic.Calendar.Size = New System.Drawing.Size(105, 174)
        Me.txtINic.Calendar.SizeToFit = True
        Me.txtINic.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtINic.Calendar.TabIndex = 0
        Me.txtINic.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtINic.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtINic.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtINic.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtINic.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtINic.Calendar.NoneButton.IsBackStageButton = False
        Me.txtINic.Calendar.NoneButton.Location = New System.Drawing.Point(33, 0)
        Me.txtINic.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtINic.Calendar.NoneButton.Text = "None"
        Me.txtINic.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtINic.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtINic.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtINic.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtINic.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtINic.Calendar.TodayButton.IsBackStageButton = False
        Me.txtINic.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtINic.Calendar.TodayButton.Size = New System.Drawing.Size(33, 20)
        Me.txtINic.Calendar.TodayButton.Text = "Today"
        Me.txtINic.Calendar.TodayButton.UseVisualStyle = True
        Me.txtINic.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtINic.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtINic.CustomFormat = "dd/MM/yyyy"
        Me.txtINic.DropDownImage = Nothing
        Me.txtINic.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtINic.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtINic.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtINic.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtINic.Location = New System.Drawing.Point(552, 72)
        Me.txtINic.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtINic.MinValue = New Date(CType(0, Long))
        Me.txtINic.Name = "txtINic"
        Me.txtINic.ShowCheckBox = False
        Me.txtINic.Size = New System.Drawing.Size(109, 20)
        Me.txtINic.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtINic.TabIndex = 15
        Me.txtINic.Value = New Date(2015, 12, 30, 16, 33, 14, 694)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(674, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 12)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "FECHA HASTA"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(550, 53)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 12)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "FECHA DESDE"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(286, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 12)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "PRODUCTO"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'cboAlmace
        '
        Me.cboAlmace.BackColor = System.Drawing.Color.White
        Me.cboAlmace.BeforeTouchSize = New System.Drawing.Size(246, 21)
        Me.cboAlmace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAlmace.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAlmace.Location = New System.Drawing.Point(18, 116)
        Me.cboAlmace.Name = "cboAlmace"
        Me.cboAlmace.Size = New System.Drawing.Size(246, 21)
        Me.cboAlmace.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboAlmace.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 12)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "ALMACEN"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(101, 32)
        Me.ButtonAdv1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(814, 60)
        Me.ButtonAdv1.MetroColor = System.Drawing.Color.Green
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(101, 32)
        Me.ButtonAdv1.TabIndex = 9
        Me.ButtonAdv1.Text = "Generar"
        Me.ButtonAdv1.UseVisualStyle = True
        Me.ButtonAdv1.UseVisualStyleBackColor = False
        '
        'cboEstable
        '
        Me.cboEstable.BackColor = System.Drawing.Color.White
        Me.cboEstable.BeforeTouchSize = New System.Drawing.Size(246, 21)
        Me.cboEstable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstable.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEstable.Location = New System.Drawing.Point(18, 71)
        Me.cboEstable.Name = "cboEstable"
        Me.cboEstable.Size = New System.Drawing.Size(246, 21)
        Me.cboEstable.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboEstable.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 12)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "ESTABLECIMIENTO"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.GradientPanel1.Controls.Add(Me.Label1)
        Me.GradientPanel1.Location = New System.Drawing.Point(18, 9)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(922, 37)
        Me.GradientPanel1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(6, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(204, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "MOVIMIENTOS DE PRODUCTOS"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel2.Location = New System.Drawing.Point(0, 144)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1078, 28)
        Me.Panel2.TabIndex = 2
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 172)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(90, 290)
        Me.Panel3.TabIndex = 3
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(988, 172)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(90, 290)
        Me.Panel4.TabIndex = 4
        '
        'ReporteKardexXproducto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CaptionBarHeight = 50
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(30, 8)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(40, 40)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.Location = New System.Drawing.Point(65, 22)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Text = "Reporte"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(1078, 462)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "ReporteKardexXproducto"
        Me.ShowIcon = False
        Me.Text = ""
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.cboTipoExistencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pcProductos.ResumeLayout(False)
        CType(Me.txtBuscarProducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHasta.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHasta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtINic.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtINic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboAlmace, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboEstable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Private WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents cboAlmace As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents cboEstable As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtHasta As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents txtINic As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtBuscarProducto As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents pcProductos As Syncfusion.Windows.Forms.PopupControlContainer
    Friend WithEvents lstProductos As System.Windows.Forms.ListBox
    Friend WithEvents cboTipoExistencia As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label7 As System.Windows.Forms.Label

End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptClaseReporte
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRptClaseReporte))
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtClase = New System.Windows.Forms.TextBox()
        Me.cboMes = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboAnios = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.dtpfin = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.dtpini = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.rbTodo = New System.Windows.Forms.RadioButton()
        Me.rbAcumulado = New System.Windows.Forms.RadioButton()
        Me.rbMensual = New System.Windows.Forms.RadioButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.rptInformeClase = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.Panel1.SuspendLayout()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.cboMes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboAnios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpfin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpfin.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpini, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpini.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.GradientPanel1)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.txtClase)
        Me.Panel1.Controls.Add(Me.cboMes)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cboAnios)
        Me.Panel1.Controls.Add(Me.dtpfin)
        Me.Panel1.Controls.Add(Me.dtpini)
        Me.Panel1.Controls.Add(Me.ButtonAdv1)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.rbTodo)
        Me.Panel1.Controls.Add(Me.rbAcumulado)
        Me.Panel1.Controls.Add(Me.rbMensual)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(986, 136)
        Me.Panel1.TabIndex = 5
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.GradientPanel1.Controls.Add(Me.Label1)
        Me.GradientPanel1.Location = New System.Drawing.Point(25, 10)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(922, 37)
        Me.GradientPanel1.TabIndex = 231
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(6, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(143, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "REPORTE POR CLASES"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(400, 87)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 12)
        Me.Label7.TabIndex = 230
        Me.Label7.Text = "NÚMERO CLASE"
        '
        'txtClase
        '
        Me.txtClase.Location = New System.Drawing.Point(401, 105)
        Me.txtClase.Name = "txtClase"
        Me.txtClase.Size = New System.Drawing.Size(143, 20)
        Me.txtClase.TabIndex = 0
        '
        'cboMes
        '
        Me.cboMes.BackColor = System.Drawing.Color.White
        Me.cboMes.BeforeTouchSize = New System.Drawing.Size(121, 21)
        Me.cboMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMes.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMes.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.cboMes.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboMes, "ENERO"))
        Me.cboMes.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboMes, "FEBRERO"))
        Me.cboMes.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboMes, "MARZO"))
        Me.cboMes.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboMes, "ABRIL"))
        Me.cboMes.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboMes, "MAYO"))
        Me.cboMes.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboMes, "JUNIO"))
        Me.cboMes.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboMes, "JULIO"))
        Me.cboMes.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboMes, "AGOSTO"))
        Me.cboMes.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboMes, "SETIEMBRE"))
        Me.cboMes.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboMes, "OCTUBRE"))
        Me.cboMes.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboMes, "NOVIEMBRE"))
        Me.cboMes.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboMes, "DICIEMBRE"))
        Me.cboMes.Location = New System.Drawing.Point(264, 104)
        Me.cboMes.Name = "cboMes"
        Me.cboMes.Size = New System.Drawing.Size(121, 21)
        Me.cboMes.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboMes.TabIndex = 229
        Me.cboMes.Text = "ENERO"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(261, 84)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(28, 12)
        Me.Label6.TabIndex = 227
        Me.Label6.Text = "MES"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label2.Location = New System.Drawing.Point(148, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 12)
        Me.Label2.TabIndex = 225
        Me.Label2.Text = "AÑO"
        '
        'cboAnios
        '
        Me.cboAnios.BackColor = System.Drawing.Color.White
        Me.cboAnios.BeforeTouchSize = New System.Drawing.Size(94, 21)
        Me.cboAnios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAnios.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAnios.Location = New System.Drawing.Point(151, 104)
        Me.cboAnios.Name = "cboAnios"
        Me.cboAnios.Size = New System.Drawing.Size(94, 21)
        Me.cboAnios.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboAnios.TabIndex = 224
        '
        'dtpfin
        '
        Me.dtpfin.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.dtpfin.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.dtpfin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.dtpfin.Calendar.AllowMultipleSelection = False
        Me.dtpfin.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.dtpfin.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dtpfin.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.dtpfin.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.dtpfin.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.dtpfin.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.dtpfin.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpfin.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfin.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dtpfin.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.dtpfin.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.dtpfin.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.dtpfin.Calendar.HighlightColor = System.Drawing.Color.White
        Me.dtpfin.Calendar.Iso8601CalenderFormat = False
        Me.dtpfin.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.dtpfin.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.dtpfin.Calendar.Name = "monthCalendar"
        Me.dtpfin.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.dtpfin.Calendar.SelectedDates = New Date(-1) {}
        Me.dtpfin.Calendar.Size = New System.Drawing.Size(105, 174)
        Me.dtpfin.Calendar.SizeToFit = True
        Me.dtpfin.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.dtpfin.Calendar.TabIndex = 0
        Me.dtpfin.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.dtpfin.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.dtpfin.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.dtpfin.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.dtpfin.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.dtpfin.Calendar.NoneButton.IsBackStageButton = False
        Me.dtpfin.Calendar.NoneButton.Location = New System.Drawing.Point(33, 0)
        Me.dtpfin.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.dtpfin.Calendar.NoneButton.Text = "None"
        Me.dtpfin.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.dtpfin.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.dtpfin.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.dtpfin.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.dtpfin.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.dtpfin.Calendar.TodayButton.IsBackStageButton = False
        Me.dtpfin.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.dtpfin.Calendar.TodayButton.Size = New System.Drawing.Size(33, 20)
        Me.dtpfin.Calendar.TodayButton.Text = "Today"
        Me.dtpfin.Calendar.TodayButton.UseVisualStyle = True
        Me.dtpfin.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfin.CalendarSize = New System.Drawing.Size(189, 176)
        Me.dtpfin.CustomFormat = "dd/MM/yyyy"
        Me.dtpfin.DropDownImage = Nothing
        Me.dtpfin.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.dtpfin.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.dtpfin.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.dtpfin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpfin.Location = New System.Drawing.Point(277, 105)
        Me.dtpfin.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.dtpfin.MinValue = New Date(CType(0, Long))
        Me.dtpfin.Name = "dtpfin"
        Me.dtpfin.ShowCheckBox = False
        Me.dtpfin.Size = New System.Drawing.Size(109, 20)
        Me.dtpfin.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.dtpfin.TabIndex = 81
        Me.dtpfin.Value = New Date(2015, 12, 30, 16, 33, 14, 694)
        '
        'dtpini
        '
        Me.dtpini.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.dtpini.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.dtpini.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.dtpini.Calendar.AllowMultipleSelection = False
        Me.dtpini.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.dtpini.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dtpini.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.dtpini.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.dtpini.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.dtpini.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.dtpini.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpini.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpini.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dtpini.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.dtpini.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.dtpini.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.dtpini.Calendar.HighlightColor = System.Drawing.Color.White
        Me.dtpini.Calendar.Iso8601CalenderFormat = False
        Me.dtpini.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.dtpini.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.dtpini.Calendar.Name = "monthCalendar"
        Me.dtpini.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.dtpini.Calendar.SelectedDates = New Date(-1) {}
        Me.dtpini.Calendar.Size = New System.Drawing.Size(105, 174)
        Me.dtpini.Calendar.SizeToFit = True
        Me.dtpini.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.dtpini.Calendar.TabIndex = 0
        Me.dtpini.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.dtpini.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.dtpini.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.dtpini.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.dtpini.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.dtpini.Calendar.NoneButton.IsBackStageButton = False
        Me.dtpini.Calendar.NoneButton.Location = New System.Drawing.Point(33, 0)
        Me.dtpini.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.dtpini.Calendar.NoneButton.Text = "None"
        Me.dtpini.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.dtpini.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.dtpini.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.dtpini.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.dtpini.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.dtpini.Calendar.TodayButton.IsBackStageButton = False
        Me.dtpini.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.dtpini.Calendar.TodayButton.Size = New System.Drawing.Size(33, 20)
        Me.dtpini.Calendar.TodayButton.Text = "Today"
        Me.dtpini.Calendar.TodayButton.UseVisualStyle = True
        Me.dtpini.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpini.CalendarSize = New System.Drawing.Size(189, 176)
        Me.dtpini.CustomFormat = "dd/MM/yyyy"
        Me.dtpini.DropDownImage = Nothing
        Me.dtpini.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.dtpini.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.dtpini.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.dtpini.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpini.Location = New System.Drawing.Point(152, 105)
        Me.dtpini.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.dtpini.MinValue = New Date(CType(0, Long))
        Me.dtpini.Name = "dtpini"
        Me.dtpini.ShowCheckBox = False
        Me.dtpini.Size = New System.Drawing.Size(109, 20)
        Me.dtpini.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.dtpini.TabIndex = 79
        Me.dtpini.Value = New Date(2015, 12, 30, 16, 33, 14, 694)
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(101, 32)
        Me.ButtonAdv1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(559, 93)
        Me.ButtonAdv1.MetroColor = System.Drawing.Color.Green
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(101, 32)
        Me.ButtonAdv1.TabIndex = 80
        Me.ButtonAdv1.Text = "Generar"
        Me.ButtonAdv1.UseVisualStyle = True
        Me.ButtonAdv1.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(276, 84)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 12)
        Me.Label5.TabIndex = 78
        Me.Label5.Text = "FECHA HASTA"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(151, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 12)
        Me.Label4.TabIndex = 77
        Me.Label4.Text = "FECHA DESDE"
        '
        'rbTodo
        '
        Me.rbTodo.AutoSize = True
        Me.rbTodo.Checked = True
        Me.rbTodo.Location = New System.Drawing.Point(36, 108)
        Me.rbTodo.Name = "rbTodo"
        Me.rbTodo.Size = New System.Drawing.Size(52, 17)
        Me.rbTodo.TabIndex = 74
        Me.rbTodo.TabStop = True
        Me.rbTodo.Text = "Anual"
        Me.rbTodo.UseVisualStyleBackColor = True
        '
        'rbAcumulado
        '
        Me.rbAcumulado.AutoSize = True
        Me.rbAcumulado.Location = New System.Drawing.Point(36, 62)
        Me.rbAcumulado.Name = "rbAcumulado"
        Me.rbAcumulado.Size = New System.Drawing.Size(77, 17)
        Me.rbAcumulado.TabIndex = 66
        Me.rbAcumulado.TabStop = True
        Me.rbAcumulado.Text = "Acumulado"
        Me.rbAcumulado.UseVisualStyleBackColor = True
        Me.rbAcumulado.Visible = False
        '
        'rbMensual
        '
        Me.rbMensual.AutoSize = True
        Me.rbMensual.Location = New System.Drawing.Point(36, 85)
        Me.rbMensual.Name = "rbMensual"
        Me.rbMensual.Size = New System.Drawing.Size(64, 17)
        Me.rbMensual.TabIndex = 65
        Me.rbMensual.TabStop = True
        Me.rbMensual.Text = "Mensual"
        Me.rbMensual.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel2.Location = New System.Drawing.Point(0, 136)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(986, 28)
        Me.Panel2.TabIndex = 6
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 164)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(90, 292)
        Me.Panel3.TabIndex = 7
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(896, 164)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(90, 292)
        Me.Panel4.TabIndex = 8
        '
        'rptInformeClase
        '
        Me.rptInformeClase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rptInformeClase.Location = New System.Drawing.Point(90, 164)
        Me.rptInformeClase.Name = "rptInformeClase"
        Me.rptInformeClase.Size = New System.Drawing.Size(806, 292)
        Me.rptInformeClase.TabIndex = 9
        '
        'frmRptClaseReporte
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
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        CaptionLabel1.Location = New System.Drawing.Point(65, 22)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Text = "Reporte"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(986, 456)
        Me.Controls.Add(Me.rptInformeClase)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmRptClaseReporte"
        Me.ShowIcon = False
        Me.Text = ""
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        CType(Me.cboMes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboAnios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpfin.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpfin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpini.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpini, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Private WithEvents rptInformeClase As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents txtClase As System.Windows.Forms.TextBox
    Friend WithEvents rbTodo As System.Windows.Forms.RadioButton
    Friend WithEvents rbAcumulado As System.Windows.Forms.RadioButton
    Friend WithEvents rbMensual As System.Windows.Forms.RadioButton
    Friend WithEvents dtpfin As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents dtpini As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboAnios As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents cboMes As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class

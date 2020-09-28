<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModalMovimientosMN
    Inherits frmMaster

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
        Dim ActiveStateCollection1 As Syncfusion.Windows.Forms.Tools.ActiveStateCollection = New Syncfusion.Windows.Forms.Tools.ActiveStateCollection()
        Dim InactiveStateCollection1 As Syncfusion.Windows.Forms.Tools.InactiveStateCollection = New Syncfusion.Windows.Forms.Tools.InactiveStateCollection()
        Dim ToggleButtonRenderer1 As Syncfusion.Windows.Forms.Tools.ToggleButtonRenderer = New Syncfusion.Windows.Forms.Tools.ToggleButtonRenderer()
        Dim SliderCollection1 As Syncfusion.Windows.Forms.Tools.SliderCollection = New Syncfusion.Windows.Forms.Tools.SliderCollection()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmModalMovimientosMN))
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor6 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor7 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor8 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor9 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor10 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor11 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor12 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor13 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor14 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor15 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor16 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor17 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor18 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridStackedHeaderDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.cboTipoMovimiento = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtMonedaKardex = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.cboEntidadFinanciera = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.cboTipo = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtPeriodoAFC = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.cboConsulta = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.ButtonAdv14 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.tbIGV = New Syncfusion.Windows.Forms.Tools.ToggleButton()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.dgvKardex2 = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.Panel8.SuspendLayout()
        CType(Me.cboTipoMovimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboEntidadFinanciera, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPeriodoAFC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPeriodoAFC.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboConsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbIGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        CType(Me.dgvKardex2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.Snow
        Me.Panel8.Controls.Add(Me.cboTipoMovimiento)
        Me.Panel8.Controls.Add(Me.Label1)
        Me.Panel8.Controls.Add(Me.txtMonedaKardex)
        Me.Panel8.Controls.Add(Me.Label24)
        Me.Panel8.Controls.Add(Me.cboEntidadFinanciera)
        Me.Panel8.Controls.Add(Me.cboTipo)
        Me.Panel8.Controls.Add(Me.Label25)
        Me.Panel8.Controls.Add(Me.txtPeriodoAFC)
        Me.Panel8.Controls.Add(Me.cboConsulta)
        Me.Panel8.Controls.Add(Me.Label26)
        Me.Panel8.Controls.Add(Me.ButtonAdv14)
        Me.Panel8.Controls.Add(Me.Label27)
        Me.Panel8.Controls.Add(Me.tbIGV)
        Me.Panel8.Controls.Add(Me.Label28)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel8.Location = New System.Drawing.Point(0, 37)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(1138, 64)
        Me.Panel8.TabIndex = 318
        '
        'cboTipoMovimiento
        '
        Me.cboTipoMovimiento.BackColor = System.Drawing.Color.LightGray
        Me.cboTipoMovimiento.BeforeTouchSize = New System.Drawing.Size(162, 21)
        Me.cboTipoMovimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoMovimiento.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoMovimiento.Items.AddRange(New Object() {"SIN MOV. DOCUMENTARIO", "CON MOV. DOCUMENTARIO"})
        Me.cboTipoMovimiento.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboTipoMovimiento, "SIN MOV. DOCUMENTARIO"))
        Me.cboTipoMovimiento.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboTipoMovimiento, "CON MOV. DOCUMENTARIO"))
        Me.cboTipoMovimiento.Location = New System.Drawing.Point(575, 33)
        Me.cboTipoMovimiento.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboTipoMovimiento.Name = "cboTipoMovimiento"
        Me.cboTipoMovimiento.ReadOnly = True
        Me.cboTipoMovimiento.Size = New System.Drawing.Size(162, 21)
        Me.cboTipoMovimiento.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboTipoMovimiento.TabIndex = 436
        Me.cboTipoMovimiento.Text = "SIN MOV. DOCUMENTARIO"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(575, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 12)
        Me.Label1.TabIndex = 435
        Me.Label1.Text = "TIPO MOVIMIENTO"
        '
        'txtMonedaKardex
        '
        Me.txtMonedaKardex.Enabled = False
        Me.txtMonedaKardex.Location = New System.Drawing.Point(444, 33)
        Me.txtMonedaKardex.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtMonedaKardex.Multiline = True
        Me.txtMonedaKardex.Name = "txtMonedaKardex"
        Me.txtMonedaKardex.Size = New System.Drawing.Size(127, 21)
        Me.txtMonedaKardex.TabIndex = 432
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.Black
        Me.Label24.Location = New System.Drawing.Point(442, 15)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(50, 12)
        Me.Label24.TabIndex = 431
        Me.Label24.Text = "MONEDA"
        '
        'cboEntidadFinanciera
        '
        Me.cboEntidadFinanciera.BackColor = System.Drawing.Color.White
        Me.cboEntidadFinanciera.BeforeTouchSize = New System.Drawing.Size(255, 21)
        Me.cboEntidadFinanciera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEntidadFinanciera.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEntidadFinanciera.Location = New System.Drawing.Point(183, 33)
        Me.cboEntidadFinanciera.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboEntidadFinanciera.Name = "cboEntidadFinanciera"
        Me.cboEntidadFinanciera.Size = New System.Drawing.Size(255, 21)
        Me.cboEntidadFinanciera.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboEntidadFinanciera.TabIndex = 429
        '
        'cboTipo
        '
        Me.cboTipo.BackColor = System.Drawing.Color.White
        Me.cboTipo.BeforeTouchSize = New System.Drawing.Size(159, 21)
        Me.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipo.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipo.Items.AddRange(New Object() {"CUENTAS EN EFECTIVO", "CUENTAS EN BANCO", "TARJETA DE CREDITO"})
        Me.cboTipo.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboTipo, "CUENTAS EN EFECTIVO"))
        Me.cboTipo.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboTipo, "CUENTAS EN BANCO"))
        Me.cboTipo.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboTipo, "TARJETA DE CREDITO"))
        Me.cboTipo.Location = New System.Drawing.Point(18, 33)
        Me.cboTipo.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(159, 21)
        Me.cboTipo.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboTipo.TabIndex = 211
        Me.cboTipo.Text = "CUENTAS EN EFECTIVO"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(16, 15)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(113, 12)
        Me.Label25.TabIndex = 209
        Me.Label25.Text = "TIPO CUENTA FINANC."
        Me.Label25.Visible = False
        '
        'txtPeriodoAFC
        '
        Me.txtPeriodoAFC.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtPeriodoAFC.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtPeriodoAFC.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtPeriodoAFC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtPeriodoAFC.Calendar.AllowMultipleSelection = False
        Me.txtPeriodoAFC.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtPeriodoAFC.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPeriodoAFC.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtPeriodoAFC.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtPeriodoAFC.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtPeriodoAFC.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtPeriodoAFC.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPeriodoAFC.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPeriodoAFC.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPeriodoAFC.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtPeriodoAFC.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtPeriodoAFC.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtPeriodoAFC.Calendar.HeadForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPeriodoAFC.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtPeriodoAFC.Calendar.Iso8601CalenderFormat = False
        Me.txtPeriodoAFC.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtPeriodoAFC.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtPeriodoAFC.Calendar.Name = "monthCalendar"
        Me.txtPeriodoAFC.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtPeriodoAFC.Calendar.SelectedDates = New Date(-1) {}
        Me.txtPeriodoAFC.Calendar.Size = New System.Drawing.Size(83, 174)
        Me.txtPeriodoAFC.Calendar.SizeToFit = True
        Me.txtPeriodoAFC.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtPeriodoAFC.Calendar.TabIndex = 0
        Me.txtPeriodoAFC.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtPeriodoAFC.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtPeriodoAFC.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtPeriodoAFC.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtPeriodoAFC.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtPeriodoAFC.Calendar.NoneButton.IsBackStageButton = False
        Me.txtPeriodoAFC.Calendar.NoneButton.Location = New System.Drawing.Point(11, 0)
        Me.txtPeriodoAFC.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtPeriodoAFC.Calendar.NoneButton.Text = "None"
        Me.txtPeriodoAFC.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtPeriodoAFC.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtPeriodoAFC.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtPeriodoAFC.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtPeriodoAFC.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtPeriodoAFC.Calendar.TodayButton.IsBackStageButton = False
        Me.txtPeriodoAFC.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtPeriodoAFC.Calendar.TodayButton.Size = New System.Drawing.Size(11, 20)
        Me.txtPeriodoAFC.Calendar.TodayButton.Text = "Today"
        Me.txtPeriodoAFC.Calendar.TodayButton.UseVisualStyle = True
        Me.txtPeriodoAFC.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPeriodoAFC.CalendarForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPeriodoAFC.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtPeriodoAFC.CalendarTitleForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPeriodoAFC.Checked = False
        Me.txtPeriodoAFC.CustomFormat = "MM/yyyy"
        Me.txtPeriodoAFC.DropDownImage = Nothing
        Me.txtPeriodoAFC.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtPeriodoAFC.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtPeriodoAFC.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtPeriodoAFC.ForeColor = System.Drawing.Color.White
        Me.txtPeriodoAFC.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtPeriodoAFC.Location = New System.Drawing.Point(879, 34)
        Me.txtPeriodoAFC.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtPeriodoAFC.MinValue = New Date(CType(0, Long))
        Me.txtPeriodoAFC.Name = "txtPeriodoAFC"
        Me.txtPeriodoAFC.ShowCheckBox = False
        Me.txtPeriodoAFC.ShowDropButton = False
        Me.txtPeriodoAFC.ShowUpDown = True
        Me.txtPeriodoAFC.Size = New System.Drawing.Size(87, 20)
        Me.txtPeriodoAFC.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtPeriodoAFC.TabIndex = 425
        Me.txtPeriodoAFC.Value = New Date(2017, 1, 3, 10, 18, 7, 310)
        '
        'cboConsulta
        '
        Me.cboConsulta.BackColor = System.Drawing.Color.White
        Me.cboConsulta.BeforeTouchSize = New System.Drawing.Size(127, 21)
        Me.cboConsulta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboConsulta.Enabled = False
        Me.cboConsulta.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboConsulta.Items.AddRange(New Object() {"POR PERIODO", "RANGO DE FECHA"})
        Me.cboConsulta.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboConsulta, "POR PERIODO"))
        Me.cboConsulta.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboConsulta, "RANGO DE FECHA"))
        Me.cboConsulta.Location = New System.Drawing.Point(744, 33)
        Me.cboConsulta.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboConsulta.Name = "cboConsulta"
        Me.cboConsulta.Size = New System.Drawing.Size(127, 21)
        Me.cboConsulta.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboConsulta.TabIndex = 424
        Me.cboConsulta.Text = "POR PERIODO"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(742, 15)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(102, 12)
        Me.Label26.TabIndex = 423
        Me.Label26.Text = "VER MOVIMIENTOS"
        '
        'ButtonAdv14
        '
        Me.ButtonAdv14.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv14.BackColor = System.Drawing.Color.Goldenrod
        Me.ButtonAdv14.BeforeTouchSize = New System.Drawing.Size(101, 32)
        Me.ButtonAdv14.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv14.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv14.IsBackStageButton = False
        Me.ButtonAdv14.Location = New System.Drawing.Point(982, 22)
        Me.ButtonAdv14.MetroColor = System.Drawing.Color.Green
        Me.ButtonAdv14.Name = "ButtonAdv14"
        Me.ButtonAdv14.Size = New System.Drawing.Size(101, 32)
        Me.ButtonAdv14.TabIndex = 421
        Me.ButtonAdv14.Text = "CONSULTAR"
        Me.ButtonAdv14.UseVisualStyle = True
        Me.ButtonAdv14.UseVisualStyleBackColor = False
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label27.Location = New System.Drawing.Point(22, 68)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(96, 13)
        Me.Label27.TabIndex = 406
        Me.Label27.Text = "Modo de búsqueda"
        Me.Label27.Visible = False
        '
        'tbIGV
        '
        ActiveStateCollection1.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer))
        ActiveStateCollection1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        ActiveStateCollection1.HoverColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer))
        ActiveStateCollection1.Text = "producto"
        Me.tbIGV.ActiveState = ActiveStateCollection1
        Me.tbIGV.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.tbIGV.ForeColor = System.Drawing.Color.Black
        InactiveStateCollection1.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer))
        InactiveStateCollection1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        InactiveStateCollection1.ForeColor = System.Drawing.Color.White
        InactiveStateCollection1.HoverColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer))
        InactiveStateCollection1.Text = "Acumulado"
        Me.tbIGV.InactiveState = InactiveStateCollection1
        Me.tbIGV.Location = New System.Drawing.Point(123, 64)
        Me.tbIGV.MinimumSize = New System.Drawing.Size(52, 19)
        Me.tbIGV.Name = "tbIGV"
        Me.tbIGV.Renderer = ToggleButtonRenderer1
        Me.tbIGV.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbIGV.Size = New System.Drawing.Size(109, 19)
        SliderCollection1.BackColor = System.Drawing.Color.White
        SliderCollection1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        SliderCollection1.ForeColor = System.Drawing.Color.White
        SliderCollection1.HoverColor = System.Drawing.Color.FromArgb(CType(CType(8, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(171, Byte), Integer))
        SliderCollection1.Width = 30
        Me.tbIGV.Slider = SliderCollection1
        Me.tbIGV.TabIndex = 405
        Me.tbIGV.TabStop = False
        Me.tbIGV.Text = "Button1"
        Me.tbIGV.ToggleState = Syncfusion.Windows.Forms.Tools.ToggleButtonState.Active
        Me.tbIGV.Visible = False
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(186, 15)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(112, 12)
        Me.Label28.TabIndex = 0
        Me.Label28.Text = "ENTIDAD FINANCIERA"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel5.Controls.Add(Me.Label29)
        Me.Panel5.Controls.Add(Me.Label30)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1138, 37)
        Me.Panel5.TabIndex = 317
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label29.Location = New System.Drawing.Point(183, 12)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(105, 13)
        Me.Label29.TabIndex = 1
        Me.Label29.Text = "/ Moneda Nacional"
        '
        'Label30
        '
        Me.Label30.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.Image = CType(resources.GetObject("Label30.Image"), System.Drawing.Image)
        Me.Label30.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label30.Location = New System.Drawing.Point(5, 6)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(178, 25)
        Me.Label30.TabIndex = 0
        Me.Label30.Text = "ANALISIS FLUJO DE CAJA"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgvKardex2
        '
        Me.dgvKardex2.BackColor = System.Drawing.SystemColors.Window
        Me.dgvKardex2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvKardex2.FreezeCaption = False
        Me.dgvKardex2.Location = New System.Drawing.Point(0, 101)
        Me.dgvKardex2.Name = "dgvKardex2"
        Me.dgvKardex2.ShowNavigationBar = True
        Me.dgvKardex2.Size = New System.Drawing.Size(1138, 276)
        Me.dgvKardex2.TabIndex = 319
        GridColumnDescriptor1.AllowSort = False
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.HeaderText = "id"
        GridColumnDescriptor1.MappingName = "idDocumento"
        GridColumnDescriptor1.ReadOnly = True
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor1.Width = 40
        GridColumnDescriptor2.AllowSort = False
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.MappingName = "fecha"
        GridColumnDescriptor2.ReadOnly = True
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor2.Width = 150
        GridColumnDescriptor3.AllowSort = False
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.HeaderText = "Usuario Caja"
        GridColumnDescriptor3.MappingName = "UsuarioCaja"
        GridColumnDescriptor3.ReadOnly = True
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor3.Width = 120
        GridColumnDescriptor4.AllowSort = False
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.HeaderText = "Tipo Usuario"
        GridColumnDescriptor4.MappingName = "tipoUsuario"
        GridColumnDescriptor4.ReadOnly = True
        GridColumnDescriptor4.SerializedImageArray = ""
        GridColumnDescriptor4.Width = 120
        GridColumnDescriptor5.AllowSort = False
        GridColumnDescriptor5.HeaderImage = Nothing
        GridColumnDescriptor5.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor5.HeaderText = "movimiento"
        GridColumnDescriptor5.MappingName = "mov"
        GridColumnDescriptor5.ReadOnly = True
        GridColumnDescriptor5.SerializedImageArray = ""
        GridColumnDescriptor5.Width = 120
        GridColumnDescriptor6.AllowSort = False
        GridColumnDescriptor6.HeaderImage = Nothing
        GridColumnDescriptor6.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor6.MappingName = "item"
        GridColumnDescriptor6.ReadOnly = True
        GridColumnDescriptor6.SerializedImageArray = ""
        GridColumnDescriptor6.Width = 150
        GridColumnDescriptor7.AllowSort = False
        GridColumnDescriptor7.HeaderImage = Nothing
        GridColumnDescriptor7.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor7.HeaderText = "Tipo Pago"
        GridColumnDescriptor7.MappingName = "tipoDoc"
        GridColumnDescriptor7.ReadOnly = True
        GridColumnDescriptor7.SerializedImageArray = ""
        GridColumnDescriptor7.Width = 70
        GridColumnDescriptor8.AllowSort = False
        GridColumnDescriptor8.HeaderImage = Nothing
        GridColumnDescriptor8.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor8.MappingName = "numero"
        GridColumnDescriptor8.ReadOnly = True
        GridColumnDescriptor8.SerializedImageArray = ""
        GridColumnDescriptor8.Width = 70
        GridColumnDescriptor9.AllowSort = False
        GridColumnDescriptor9.HeaderImage = Nothing
        GridColumnDescriptor9.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor9.MappingName = "moneda"
        GridColumnDescriptor9.ReadOnly = True
        GridColumnDescriptor9.SerializedImageArray = ""
        GridColumnDescriptor9.Width = 50
        GridColumnDescriptor10.AllowSort = False
        GridColumnDescriptor10.HeaderImage = Nothing
        GridColumnDescriptor10.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor10.HeaderText = "T/c"
        GridColumnDescriptor10.MappingName = "tipoCambio"
        GridColumnDescriptor10.ReadOnly = True
        GridColumnDescriptor10.SerializedImageArray = ""
        GridColumnDescriptor10.Width = 50
        GridColumnDescriptor11.AllowSort = False
        GridColumnDescriptor11.HeaderImage = Nothing
        GridColumnDescriptor11.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor11.HeaderText = "MN."
        GridColumnDescriptor11.MappingName = "entradaMN"
        GridColumnDescriptor11.ReadOnly = True
        GridColumnDescriptor11.SerializedImageArray = ""
        GridColumnDescriptor11.Width = 80
        GridColumnDescriptor12.AllowSort = False
        GridColumnDescriptor12.HeaderImage = Nothing
        GridColumnDescriptor12.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor12.MappingName = "entradaME"
        GridColumnDescriptor12.ReadOnly = True
        GridColumnDescriptor12.SerializedImageArray = ""
        GridColumnDescriptor13.AllowSort = False
        GridColumnDescriptor13.HeaderImage = Nothing
        GridColumnDescriptor13.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor13.HeaderText = "MN."
        GridColumnDescriptor13.MappingName = "salidaMN"
        GridColumnDescriptor13.ReadOnly = True
        GridColumnDescriptor13.SerializedImageArray = ""
        GridColumnDescriptor13.Width = 80
        GridColumnDescriptor14.AllowSort = False
        GridColumnDescriptor14.HeaderImage = Nothing
        GridColumnDescriptor14.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor14.MappingName = "salidaME"
        GridColumnDescriptor14.ReadOnly = True
        GridColumnDescriptor14.SerializedImageArray = ""
        GridColumnDescriptor14.Width = 70
        GridColumnDescriptor15.AllowSort = False
        GridColumnDescriptor15.HeaderImage = Nothing
        GridColumnDescriptor15.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor15.HeaderText = "MN."
        GridColumnDescriptor15.MappingName = "saldoMN"
        GridColumnDescriptor15.ReadOnly = True
        GridColumnDescriptor15.SerializedImageArray = ""
        GridColumnDescriptor15.Width = 80
        GridColumnDescriptor16.AllowSort = False
        GridColumnDescriptor16.HeaderImage = Nothing
        GridColumnDescriptor16.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor16.MappingName = "saldoME"
        GridColumnDescriptor16.ReadOnly = True
        GridColumnDescriptor16.SerializedImageArray = ""
        GridColumnDescriptor16.Width = 70
        GridColumnDescriptor17.HeaderImage = Nothing
        GridColumnDescriptor17.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor17.MappingName = "idDocumentoRef"
        GridColumnDescriptor17.Name = "idDocumentoRef"
        GridColumnDescriptor17.SerializedImageArray = ""
        GridColumnDescriptor18.HeaderImage = Nothing
        GridColumnDescriptor18.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor18.MappingName = "tipoOperacion "
        GridColumnDescriptor18.Name = "tipoOperacion "
        GridColumnDescriptor18.SerializedImageArray = ""
        GridColumnDescriptor18.Width = 250
        Me.dgvKardex2.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7, GridColumnDescriptor8, GridColumnDescriptor9, GridColumnDescriptor10, GridColumnDescriptor11, GridColumnDescriptor12, GridColumnDescriptor13, GridColumnDescriptor14, GridColumnDescriptor15, GridColumnDescriptor16, GridColumnDescriptor17, GridColumnDescriptor18})
        GridStackedHeaderDescriptor1.HeaderText = "E N T R A D A"
        GridStackedHeaderDescriptor1.Name = "StackedHeader 2"
        GridStackedHeaderDescriptor1.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("entradaMN"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("entradaME")})
        Me.dgvKardex2.TableDescriptor.StackedHeaderRows.Add(New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderRowDescriptor("Row 1", New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor() {GridStackedHeaderDescriptor1, New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor("StackedHeader 3", "S A L I D A", New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("salidaMN"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("salidaME")}), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor("StackedHeader 4", "S A L D O", New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("saldoMN"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("saldoME")}), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor("ST", "T R A N S A C C I O N", New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("idDocumento"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("UsuarioCaja"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("tipoUsuario"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("mov"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("fecha"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("item"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("tipoDoc"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("numero"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("moneda"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("tipoCambio")})}))
        Me.dgvKardex2.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("fecha"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("mov"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("item"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipoDoc"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("numero"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("moneda"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipoCambio"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("entradaMN"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("entradaME"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("salidaMN"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("salidaME"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("saldoMN"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("saldoME")})
        Me.dgvKardex2.TableOptions.GridLineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder()
        Me.dgvKardex2.TableOptions.ListBoxSelectionOutlineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.Transparent)
        Me.dgvKardex2.TableOptions.TreeLineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.White)
        Me.dgvKardex2.Text = "gridGroupingControl1"
        Me.dgvKardex2.VersionInfo = "12.2400.0.20"
        '
        'frmModalMovimientosMN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1138, 377)
        Me.Controls.Add(Me.dgvKardex2)
        Me.Controls.Add(Me.Panel8)
        Me.Controls.Add(Me.Panel5)
        Me.Name = "frmModalMovimientosMN"
        Me.ShowIcon = False
        Me.Text = "Movimientos Caja M.N."
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        CType(Me.cboTipoMovimiento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboEntidadFinanciera, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPeriodoAFC.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPeriodoAFC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboConsulta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbIGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.dgvKardex2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel8 As Panel
    Friend WithEvents txtMonedaKardex As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents cboEntidadFinanciera As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents cboTipo As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label25 As Label
    Friend WithEvents txtPeriodoAFC As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents cboConsulta As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label26 As Label
    Friend WithEvents ButtonAdv14 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents Label27 As Label
    Private WithEvents tbIGV As Syncfusion.Windows.Forms.Tools.ToggleButton
    Friend WithEvents Label28 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label29 As Label
    Friend WithEvents Label30 As Label
    Private WithEvents dgvKardex2 As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents cboTipoMovimiento As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label1 As Label
End Class

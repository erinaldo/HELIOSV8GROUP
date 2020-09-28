<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCierreGestionado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCierreGestionado))
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.cboAnio = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.chValidarCierre = New System.Windows.Forms.CheckBox()
        Me.cboMesCompra = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.txtDia = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.swFinanzas = New Bunifu.Framework.UI.BunifuiOSSwitch()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.swLogistica = New Bunifu.Framework.UI.BunifuiOSSwitch()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.swAsientos = New Bunifu.Framework.UI.BunifuiOSSwitch()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtImpuestoRenta = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.txtUilidad = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.ButtonAdv2 = New Syncfusion.Windows.Forms.ButtonAdv()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.cboAnio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboMesCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDia.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtImpuestoRenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUilidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GradientPanel1.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.GradientPanel1.BorderSingle = System.Windows.Forms.ButtonBorderStyle.Dotted
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.ButtonAdv2)
        Me.GradientPanel1.Controls.Add(Me.ProgressBar1)
        Me.GradientPanel1.Controls.Add(Me.Label2)
        Me.GradientPanel1.Controls.Add(Me.cboAnio)
        Me.GradientPanel1.Controls.Add(Me.chValidarCierre)
        Me.GradientPanel1.Controls.Add(Me.cboMesCompra)
        Me.GradientPanel1.Controls.Add(Me.txtDia)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(693, 69)
        Me.GradientPanel1.TabIndex = 0
        '
        'cboAnio
        '
        Me.cboAnio.BackColor = System.Drawing.Color.White
        Me.cboAnio.BeforeTouchSize = New System.Drawing.Size(60, 21)
        Me.cboAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAnio.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAnio.Location = New System.Drawing.Point(207, 34)
        Me.cboAnio.Name = "cboAnio"
        Me.cboAnio.Office2007ColorTheme = Syncfusion.Windows.Forms.Office2007Theme.Black
        Me.cboAnio.Office2010ColorTheme = Syncfusion.Windows.Forms.Office2010Theme.Black
        Me.cboAnio.Size = New System.Drawing.Size(60, 21)
        Me.cboAnio.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboAnio.TabIndex = 517
        '
        'chValidarCierre
        '
        Me.chValidarCierre.AutoSize = True
        Me.chValidarCierre.Checked = True
        Me.chValidarCierre.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chValidarCierre.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chValidarCierre.Location = New System.Drawing.Point(273, 38)
        Me.chValidarCierre.Name = "chValidarCierre"
        Me.chValidarCierre.Size = New System.Drawing.Size(133, 18)
        Me.chValidarCierre.TabIndex = 516
        Me.chValidarCierre.Text = "Validar cierre anterior"
        Me.chValidarCierre.UseVisualStyleBackColor = True
        '
        'cboMesCompra
        '
        Me.cboMesCompra.BackColor = System.Drawing.Color.White
        Me.cboMesCompra.BeforeTouchSize = New System.Drawing.Size(127, 21)
        Me.cboMesCompra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMesCompra.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMesCompra.Location = New System.Drawing.Point(22, 34)
        Me.cboMesCompra.Name = "cboMesCompra"
        Me.cboMesCompra.Size = New System.Drawing.Size(127, 21)
        Me.cboMesCompra.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboMesCompra.TabIndex = 515
        '
        'txtDia
        '
        Me.txtDia.BackColor = System.Drawing.Color.OrangeRed
        Me.txtDia.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtDia.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtDia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtDia.Calendar.AllowMultipleSelection = False
        Me.txtDia.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtDia.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDia.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtDia.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtDia.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtDia.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtDia.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDia.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDia.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtDia.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtDia.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtDia.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtDia.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtDia.Calendar.Iso8601CalenderFormat = False
        Me.txtDia.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtDia.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtDia.Calendar.Name = "monthCalendar"
        Me.txtDia.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtDia.Calendar.SelectedDates = New Date(-1) {}
        Me.txtDia.Calendar.Size = New System.Drawing.Size(48, 174)
        Me.txtDia.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtDia.Calendar.TabIndex = 0
        Me.txtDia.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtDia.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtDia.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtDia.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtDia.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtDia.Calendar.NoneButton.IsBackStageButton = False
        Me.txtDia.Calendar.NoneButton.Location = New System.Drawing.Point(-24, 0)
        Me.txtDia.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtDia.Calendar.NoneButton.Text = "None"
        Me.txtDia.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtDia.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtDia.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtDia.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtDia.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtDia.Calendar.TodayButton.IsBackStageButton = False
        Me.txtDia.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtDia.Calendar.TodayButton.Size = New System.Drawing.Size(-24, 20)
        Me.txtDia.Calendar.TodayButton.Text = "Today"
        Me.txtDia.Calendar.TodayButton.UseVisualStyle = True
        Me.txtDia.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDia.CalendarForeColor = System.Drawing.SystemColors.ControlText
        Me.txtDia.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtDia.Checked = False
        Me.txtDia.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtDia.CustomFormat = "dd"
        Me.txtDia.DropDownImage = Nothing
        Me.txtDia.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtDia.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtDia.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtDia.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDia.ForeColor = System.Drawing.Color.White
        Me.txtDia.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtDia.Location = New System.Drawing.Point(155, 35)
        Me.txtDia.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtDia.MinValue = New Date(CType(0, Long))
        Me.txtDia.Name = "txtDia"
        Me.txtDia.ShowCheckBox = False
        Me.txtDia.ShowDropButton = False
        Me.txtDia.ShowUpDown = True
        Me.txtDia.Size = New System.Drawing.Size(50, 20)
        Me.txtDia.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtDia.TabIndex = 514
        Me.txtDia.Value = New Date(2016, 1, 1, 11, 17, 0, 0)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(19, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(148, 15)
        Me.Label2.TabIndex = 518
        Me.Label2.Text = "SELECCIONAR Y CERRAR MES"
        '
        'GradientPanel2
        '
        Me.GradientPanel2.BorderColor = System.Drawing.Color.DarkGray
        Me.GradientPanel2.BorderSides = System.Windows.Forms.Border3DSide.Right
        Me.GradientPanel2.BorderSingle = System.Windows.Forms.ButtonBorderStyle.Dashed
        Me.GradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel2.Controls.Add(Me.ListView1)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 69)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(206, 226)
        Me.GradientPanel2.TabIndex = 1
        '
        'ListView1
        '
        Me.ListView1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.ListView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.Location = New System.Drawing.Point(0, 0)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(204, 224)
        Me.ListView1.TabIndex = 2
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "año"
        Me.ColumnHeader1.Width = 98
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "..."
        Me.ColumnHeader2.Width = 0
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Mes"
        Me.ColumnHeader3.Width = 106
        '
        'swFinanzas
        '
        Me.swFinanzas.BackColor = System.Drawing.Color.Transparent
        Me.swFinanzas.BackgroundImage = CType(resources.GetObject("swFinanzas.BackgroundImage"), System.Drawing.Image)
        Me.swFinanzas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.swFinanzas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.swFinanzas.Location = New System.Drawing.Point(384, 96)
        Me.swFinanzas.Name = "swFinanzas"
        Me.swFinanzas.OffColor = System.Drawing.Color.Gray
        Me.swFinanzas.OnColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.swFinanzas.Size = New System.Drawing.Size(43, 25)
        Me.swFinanzas.TabIndex = 2
        Me.swFinanzas.Value = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(237, 106)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 519
        Me.Label1.Text = "Finanzas"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(237, 139)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 13)
        Me.Label3.TabIndex = 520
        Me.Label3.Text = "Logistica (Inventario)"
        '
        'swLogistica
        '
        Me.swLogistica.BackColor = System.Drawing.Color.Transparent
        Me.swLogistica.BackgroundImage = CType(resources.GetObject("swLogistica.BackgroundImage"), System.Drawing.Image)
        Me.swLogistica.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.swLogistica.Cursor = System.Windows.Forms.Cursors.Hand
        Me.swLogistica.Location = New System.Drawing.Point(384, 129)
        Me.swLogistica.Name = "swLogistica"
        Me.swLogistica.OffColor = System.Drawing.Color.Gray
        Me.swLogistica.OnColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.swLogistica.Size = New System.Drawing.Size(43, 25)
        Me.swLogistica.TabIndex = 521
        Me.swLogistica.Value = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(237, 174)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 13)
        Me.Label4.TabIndex = 522
        Me.Label4.Text = "Asientos contables"
        '
        'swAsientos
        '
        Me.swAsientos.BackColor = System.Drawing.Color.Transparent
        Me.swAsientos.BackgroundImage = CType(resources.GetObject("swAsientos.BackgroundImage"), System.Drawing.Image)
        Me.swAsientos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.swAsientos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.swAsientos.Location = New System.Drawing.Point(384, 164)
        Me.swAsientos.Name = "swAsientos"
        Me.swAsientos.OffColor = System.Drawing.Color.Gray
        Me.swAsientos.OnColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.swAsientos.Size = New System.Drawing.Size(43, 25)
        Me.swAsientos.TabIndex = 523
        Me.swAsientos.Value = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtImpuestoRenta)
        Me.GroupBox1.Controls.Add(Me.txtUilidad)
        Me.GroupBox1.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(469, 84)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(210, 121)
        Me.GroupBox1.TabIndex = 524
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cierre de Resultados"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(40, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(118, 13)
        Me.Label5.TabIndex = 510
        Me.Label5.Text = "Resultado del Ejercicio"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(40, 70)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 511
        Me.Label6.Text = "Utilidad"
        '
        'txtImpuestoRenta
        '
        Me.txtImpuestoRenta.BackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.txtImpuestoRenta.BeforeTouchSize = New System.Drawing.Size(119, 21)
        Me.txtImpuestoRenta.BorderColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.txtImpuestoRenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtImpuestoRenta.DecimalPlaces = 2
        Me.txtImpuestoRenta.Font = New System.Drawing.Font("Arial", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImpuestoRenta.ForeColor = System.Drawing.Color.Black
        Me.txtImpuestoRenta.Location = New System.Drawing.Point(39, 42)
        Me.txtImpuestoRenta.Maximum = New Decimal(New Integer() {-159383552, 46653770, 5421, 0})
        Me.txtImpuestoRenta.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtImpuestoRenta.Minimum = New Decimal(New Integer() {-159383552, 46653770, 5421, -2147483648})
        Me.txtImpuestoRenta.Name = "txtImpuestoRenta"
        Me.txtImpuestoRenta.Size = New System.Drawing.Size(119, 21)
        Me.txtImpuestoRenta.TabIndex = 508
        Me.txtImpuestoRenta.TabStop = False
        Me.txtImpuestoRenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtImpuestoRenta.ThousandsSeparator = True
        Me.txtImpuestoRenta.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'txtUilidad
        '
        Me.txtUilidad.BackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.txtUilidad.BeforeTouchSize = New System.Drawing.Size(119, 21)
        Me.txtUilidad.BorderColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(106, Byte), Integer), CType(CType(106, Byte), Integer))
        Me.txtUilidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUilidad.DecimalPlaces = 2
        Me.txtUilidad.Font = New System.Drawing.Font("Arial", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUilidad.ForeColor = System.Drawing.Color.Black
        Me.txtUilidad.Location = New System.Drawing.Point(39, 89)
        Me.txtUilidad.Maximum = New Decimal(New Integer() {-159383552, 46653770, 5421, 0})
        Me.txtUilidad.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtUilidad.Name = "txtUilidad"
        Me.txtUilidad.Size = New System.Drawing.Size(119, 21)
        Me.txtUilidad.TabIndex = 509
        Me.txtUilidad.TabStop = False
        Me.txtUilidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtUilidad.ThousandsSeparator = True
        Me.txtUilidad.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(628, 38)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(60, 10)
        Me.ProgressBar1.TabIndex = 519
        Me.ProgressBar1.Visible = False
        '
        'ButtonAdv2
        '
        Me.ButtonAdv2.BeforeTouchSize = New System.Drawing.Size(38, 42)
        Me.ButtonAdv2.BorderStyleAdv = Syncfusion.Windows.Forms.ButtonAdvBorderStyle.None
        Me.ButtonAdv2.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.ButtonAdv2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAdv2.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.ButtonAdv2.Image = CType(resources.GetObject("ButtonAdv2.Image"), System.Drawing.Image)
        Me.ButtonAdv2.IsBackStageButton = False
        Me.ButtonAdv2.Location = New System.Drawing.Point(412, 22)
        Me.ButtonAdv2.Name = "ButtonAdv2"
        Me.ButtonAdv2.Size = New System.Drawing.Size(38, 42)
        Me.ButtonAdv2.TabIndex = 521
        '
        'frmCierreGestionado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.CaptionBarHeight = 60
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(15, 14)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(30, 30)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Calibri Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(120, Byte), Integer))
        CaptionLabel1.Location = New System.Drawing.Point(55, 17)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(300, 24)
        CaptionLabel1.Text = "Mantenimiento de cierres"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(693, 295)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.swAsientos)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.swLogistica)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.swFinanzas)
        Me.Controls.Add(Me.GradientPanel2)
        Me.Controls.Add(Me.GradientPanel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCierreGestionado"
        Me.ShowIcon = False
        Me.Text = ""
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        CType(Me.cboAnio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboMesCompra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDia.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtImpuestoRenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUilidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents cboAnio As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents chValidarCierre As CheckBox
    Friend WithEvents cboMesCompra As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents txtDia As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents Label2 As Label
    Friend WithEvents GradientPanel2 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents ListView1 As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents swFinanzas As Bunifu.Framework.UI.BunifuiOSSwitch
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents swLogistica As Bunifu.Framework.UI.BunifuiOSSwitch
    Friend WithEvents Label4 As Label
    Friend WithEvents swAsientos As Bunifu.Framework.UI.BunifuiOSSwitch
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtImpuestoRenta As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents txtUilidad As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents ButtonAdv2 As Syncfusion.Windows.Forms.ButtonAdv
End Class

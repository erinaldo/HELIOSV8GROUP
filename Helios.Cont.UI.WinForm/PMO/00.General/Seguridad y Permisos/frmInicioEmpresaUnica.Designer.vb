<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInicioEmpresaUnica
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInicioEmpresaUnica))
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Dim CaptionLabel2 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.nudTipoCambioVenta = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.nudTipoCambioCompra = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.PictureBox19 = New System.Windows.Forms.PictureBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.ButtonAdv3 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.cboEstablecimiento = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtFechaTC = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cboAnio = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        CType(Me.nudTipoCambioVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudTipoCambioCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox19, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboEstablecimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.txtFechaTC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaTC.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.cboAnio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'nudTipoCambioVenta
        '
        Me.nudTipoCambioVenta.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.nudTipoCambioVenta.BeforeTouchSize = New System.Drawing.Size(304, 22)
        Me.nudTipoCambioVenta.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.nudTipoCambioVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nudTipoCambioVenta.CurrencyDecimalDigits = 3
        Me.nudTipoCambioVenta.CurrencySymbol = "VT- "
        Me.nudTipoCambioVenta.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.nudTipoCambioVenta.DecimalValue = New Decimal(New Integer() {0, 0, 0, 196608})
        Me.nudTipoCambioVenta.ForeColor = System.Drawing.Color.White
        Me.nudTipoCambioVenta.Location = New System.Drawing.Point(80, 21)
        Me.nudTipoCambioVenta.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.nudTipoCambioVenta.MinimumSize = New System.Drawing.Size(14, 10)
        Me.nudTipoCambioVenta.Name = "nudTipoCambioVenta"
        Me.nudTipoCambioVenta.NullString = ""
        Me.nudTipoCambioVenta.PositiveColor = System.Drawing.Color.White
        Me.nudTipoCambioVenta.ReadOnlyBackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.nudTipoCambioVenta.Size = New System.Drawing.Size(62, 22)
        Me.nudTipoCambioVenta.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.nudTipoCambioVenta.TabIndex = 508
        Me.nudTipoCambioVenta.Text = "VT- 0.000"
        '
        'nudTipoCambioCompra
        '
        Me.nudTipoCambioCompra.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.nudTipoCambioCompra.BeforeTouchSize = New System.Drawing.Size(304, 22)
        Me.nudTipoCambioCompra.BorderColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.nudTipoCambioCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nudTipoCambioCompra.CurrencyDecimalDigits = 3
        Me.nudTipoCambioCompra.CurrencySymbol = "CM- "
        Me.nudTipoCambioCompra.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.nudTipoCambioCompra.DecimalValue = New Decimal(New Integer() {0, 0, 0, 196608})
        Me.nudTipoCambioCompra.ForeColor = System.Drawing.Color.White
        Me.nudTipoCambioCompra.Location = New System.Drawing.Point(13, 21)
        Me.nudTipoCambioCompra.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.nudTipoCambioCompra.MinimumSize = New System.Drawing.Size(14, 10)
        Me.nudTipoCambioCompra.Name = "nudTipoCambioCompra"
        Me.nudTipoCambioCompra.NullString = ""
        Me.nudTipoCambioCompra.PositiveColor = System.Drawing.Color.White
        Me.nudTipoCambioCompra.ReadOnlyBackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.nudTipoCambioCompra.Size = New System.Drawing.Size(62, 22)
        Me.nudTipoCambioCompra.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.nudTipoCambioCompra.TabIndex = 507
        Me.nudTipoCambioCompra.Text = "CM- 0.000"
        '
        'PictureBox19
        '
        Me.PictureBox19.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox19.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox19.Image = CType(resources.GetObject("PictureBox19.Image"), System.Drawing.Image)
        Me.PictureBox19.Location = New System.Drawing.Point(155, 25)
        Me.PictureBox19.Name = "PictureBox19"
        Me.PictureBox19.Size = New System.Drawing.Size(21, 21)
        Me.PictureBox19.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox19.TabIndex = 497
        Me.PictureBox19.TabStop = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(189, Byte), Integer))
        Me.LinkLabel1.Location = New System.Drawing.Point(10, 63)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(38, 13)
        Me.LinkLabel1.TabIndex = 509
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Nuevo"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel2.LinkColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(189, Byte), Integer))
        Me.LinkLabel2.Location = New System.Drawing.Point(65, 63)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(47, 13)
        Me.LinkLabel2.TabIndex = 510
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Eliminar"
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel3.LinkColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(189, Byte), Integer))
        Me.LinkLabel3.Location = New System.Drawing.Point(122, 63)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(101, 13)
        Me.LinkLabel3.TabIndex = 511
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "Obtener último T/C"
        '
        'ButtonAdv3
        '
        Me.ButtonAdv3.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv3.BackColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.ButtonAdv3.BeforeTouchSize = New System.Drawing.Size(167, 36)
        Me.ButtonAdv3.Font = New System.Drawing.Font("Ebrima", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv3.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv3.Image = CType(resources.GetObject("ButtonAdv3.Image"), System.Drawing.Image)
        Me.ButtonAdv3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv3.IsBackStageButton = False
        Me.ButtonAdv3.Location = New System.Drawing.Point(116, 260)
        Me.ButtonAdv3.MetroColor = System.Drawing.SystemColors.Highlight
        Me.ButtonAdv3.Name = "ButtonAdv3"
        Me.ButtonAdv3.Size = New System.Drawing.Size(167, 36)
        Me.ButtonAdv3.TabIndex = 512
        Me.ButtonAdv3.Text = "           Grabar configuración"
        Me.ButtonAdv3.UseVisualStyle = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.cboEstablecimiento)
        Me.GroupBox1.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(23, 15)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(350, 60)
        Me.GroupBox1.TabIndex = 513
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Seleccionar establecimiento"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(323, 26)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(21, 21)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 498
        Me.PictureBox1.TabStop = False
        '
        'cboEstablecimiento
        '
        Me.cboEstablecimiento.BackColor = System.Drawing.Color.White
        Me.cboEstablecimiento.BeforeTouchSize = New System.Drawing.Size(306, 21)
        Me.cboEstablecimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstablecimiento.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEstablecimiento.Location = New System.Drawing.Point(13, 26)
        Me.cboEstablecimiento.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.cboEstablecimiento.Name = "cboEstablecimiento"
        Me.cboEstablecimiento.Size = New System.Drawing.Size(306, 21)
        Me.cboEstablecimiento.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboEstablecimiento.TabIndex = 497
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtFechaTC)
        Me.GroupBox2.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(23, 81)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(162, 60)
        Me.GroupBox2.TabIndex = 514
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Fecha laboral -  tipo cambio"
        '
        'txtFechaTC
        '
        Me.txtFechaTC.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtFechaTC.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtFechaTC.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaTC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtFechaTC.Calendar.AllowMultipleSelection = False
        Me.txtFechaTC.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaTC.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaTC.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechaTC.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaTC.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFechaTC.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtFechaTC.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFechaTC.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaTC.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaTC.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtFechaTC.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtFechaTC.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtFechaTC.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtFechaTC.Calendar.Iso8601CalenderFormat = False
        Me.txtFechaTC.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaTC.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaTC.Calendar.Name = "monthCalendar"
        Me.txtFechaTC.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtFechaTC.Calendar.SelectedDates = New Date(-1) {}
        Me.txtFechaTC.Calendar.Size = New System.Drawing.Size(129, 174)
        Me.txtFechaTC.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaTC.Calendar.TabIndex = 0
        Me.txtFechaTC.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtFechaTC.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaTC.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaTC.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaTC.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaTC.Calendar.NoneButton.IsBackStageButton = False
        Me.txtFechaTC.Calendar.NoneButton.Location = New System.Drawing.Point(57, 0)
        Me.txtFechaTC.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtFechaTC.Calendar.NoneButton.Text = "None"
        Me.txtFechaTC.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtFechaTC.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaTC.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaTC.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaTC.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaTC.Calendar.TodayButton.IsBackStageButton = False
        Me.txtFechaTC.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaTC.Calendar.TodayButton.Size = New System.Drawing.Size(57, 20)
        Me.txtFechaTC.Calendar.TodayButton.Text = "Today"
        Me.txtFechaTC.Calendar.TodayButton.UseVisualStyle = True
        Me.txtFechaTC.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaTC.CalendarForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaTC.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtFechaTC.Checked = False
        Me.txtFechaTC.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechaTC.CustomFormat = "dd/MM/yyyy"
        Me.txtFechaTC.DropDownImage = Nothing
        Me.txtFechaTC.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaTC.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaTC.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtFechaTC.ForeColor = System.Drawing.Color.Black
        Me.txtFechaTC.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFechaTC.Location = New System.Drawing.Point(16, 25)
        Me.txtFechaTC.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaTC.MinValue = New Date(CType(0, Long))
        Me.txtFechaTC.Name = "txtFechaTC"
        Me.txtFechaTC.ShowCheckBox = False
        Me.txtFechaTC.ShowDropButton = False
        Me.txtFechaTC.Size = New System.Drawing.Size(133, 20)
        Me.txtFechaTC.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaTC.TabIndex = 506
        Me.txtFechaTC.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.nudTipoCambioCompra)
        Me.GroupBox3.Controls.Add(Me.nudTipoCambioVenta)
        Me.GroupBox3.Controls.Add(Me.LinkLabel1)
        Me.GroupBox3.Controls.Add(Me.LinkLabel3)
        Me.GroupBox3.Controls.Add(Me.LinkLabel2)
        Me.GroupBox3.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(23, 147)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(350, 93)
        Me.GroupBox3.TabIndex = 515
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Tipo de cambio del día"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cboAnio)
        Me.GroupBox4.Controls.Add(Me.PictureBox19)
        Me.GroupBox4.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(191, 81)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(182, 60)
        Me.GroupBox4.TabIndex = 516
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Año laboral"
        '
        'cboAnio
        '
        Me.cboAnio.BackColor = System.Drawing.Color.White
        Me.cboAnio.BeforeTouchSize = New System.Drawing.Size(145, 21)
        Me.cboAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAnio.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAnio.Location = New System.Drawing.Point(6, 25)
        Me.cboAnio.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.cboAnio.Name = "cboAnio"
        Me.cboAnio.Size = New System.Drawing.Size(145, 21)
        Me.cboAnio.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboAnio.TabIndex = 498
        '
        'frmInicioEmpresaUnica
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.CaptionBarHeight = 60
        Me.CaptionButtonColor = System.Drawing.Color.White
        Me.CaptionButtonHoverColor = System.Drawing.Color.White
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(15, 14)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(30, 30)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Ebrima", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.White
        CaptionLabel1.Location = New System.Drawing.Point(55, 8)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(200, 24)
        CaptionLabel1.Text = "Estación de trabajo"
        CaptionLabel2.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        CaptionLabel2.Location = New System.Drawing.Point(55, 25)
        CaptionLabel2.Name = "CaptionLabel2"
        CaptionLabel2.Size = New System.Drawing.Size(200, 24)
        CaptionLabel2.Text = "Empresa nombre corto"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.CaptionLabels.Add(CaptionLabel2)
        Me.ClientSize = New System.Drawing.Size(401, 308)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ButtonAdv3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInicioEmpresaUnica"
        Me.ShowIcon = False
        Me.Text = ""
        CType(Me.nudTipoCambioVenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudTipoCambioCompra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox19, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboEstablecimiento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.txtFechaTC.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaTC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.cboAnio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents nudTipoCambioVenta As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents nudTipoCambioCompra As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents PictureBox19 As PictureBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents ButtonAdv3 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cboEstablecimiento As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents txtFechaTC As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents cboAnio As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNuevaMembresia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNuevaMembresia))
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Dim CaptionLabel2 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtProducto = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtDetalle = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.cboServicio = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.cboPeriodicidad = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.btRegistrar = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCosto = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtValido = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.txtFechaActual = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ComboBoxAdv1 = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.txtNumdiasPromo = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtDiasCongelados = New System.Windows.Forms.NumericUpDown()
        Me.txtCalculo = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.txtProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboServicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboPeriodicidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValido, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValido.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaActual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaActual.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboBoxAdv1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumdiasPromo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDiasCongelados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCalculo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 14)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Membresía"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(24, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 14)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Tipo membresía"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(24, 115)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 14)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Detalle"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(158, 189)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 14)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Periodicidad"
        Me.Label4.Visible = False
        '
        'txtProducto
        '
        Me.txtProducto.BeforeTouchSize = New System.Drawing.Size(282, 22)
        Me.txtProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProducto.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtProducto.Location = New System.Drawing.Point(27, 86)
        Me.txtProducto.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.Size = New System.Drawing.Size(282, 22)
        Me.txtProducto.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtProducto.TabIndex = 6
        '
        'txtDetalle
        '
        Me.txtDetalle.BeforeTouchSize = New System.Drawing.Size(282, 22)
        Me.txtDetalle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDetalle.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDetalle.Location = New System.Drawing.Point(27, 134)
        Me.txtDetalle.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtDetalle.Multiline = True
        Me.txtDetalle.Name = "txtDetalle"
        Me.txtDetalle.Size = New System.Drawing.Size(282, 44)
        Me.txtDetalle.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtDetalle.TabIndex = 7
        '
        'cboServicio
        '
        Me.cboServicio.BackColor = System.Drawing.Color.White
        Me.cboServicio.BeforeTouchSize = New System.Drawing.Size(149, 21)
        Me.cboServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboServicio.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboServicio.Location = New System.Drawing.Point(27, 34)
        Me.cboServicio.Name = "cboServicio"
        Me.cboServicio.Size = New System.Drawing.Size(149, 21)
        Me.cboServicio.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboServicio.TabIndex = 8
        '
        'cboPeriodicidad
        '
        Me.cboPeriodicidad.BackColor = System.Drawing.Color.White
        Me.cboPeriodicidad.BeforeTouchSize = New System.Drawing.Size(148, 19)
        Me.cboPeriodicidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPeriodicidad.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPeriodicidad.Location = New System.Drawing.Point(161, 209)
        Me.cboPeriodicidad.Name = "cboPeriodicidad"
        Me.cboPeriodicidad.Size = New System.Drawing.Size(148, 19)
        Me.cboPeriodicidad.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboPeriodicidad.TabIndex = 9
        Me.cboPeriodicidad.Visible = False
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BorderColor = System.Drawing.Color.DarkGray
        Me.GradientPanel1.BorderSides = System.Windows.Forms.Border3DSide.Right
        Me.GradientPanel1.BorderSingle = System.Windows.Forms.ButtonBorderStyle.Dotted
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Location = New System.Drawing.Point(315, 12)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(10, 173)
        Me.GradientPanel1.TabIndex = 10
        '
        'GradientPanel2
        '
        Me.GradientPanel2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GradientPanel2.BorderSides = System.Windows.Forms.Border3DSide.Top
        Me.GradientPanel2.BorderSingle = System.Windows.Forms.ButtonBorderStyle.Dotted
        Me.GradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(598, 10)
        Me.GradientPanel2.TabIndex = 11
        '
        'btRegistrar
        '
        Me.btRegistrar.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btRegistrar.BackColor = System.Drawing.Color.OrangeRed
        Me.btRegistrar.BeforeTouchSize = New System.Drawing.Size(107, 35)
        Me.btRegistrar.Font = New System.Drawing.Font("Corbel", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btRegistrar.ForeColor = System.Drawing.Color.White
        Me.btRegistrar.Image = CType(resources.GetObject("btRegistrar.Image"), System.Drawing.Image)
        Me.btRegistrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btRegistrar.IsBackStageButton = False
        Me.btRegistrar.Location = New System.Drawing.Point(348, 12)
        Me.btRegistrar.Name = "btRegistrar"
        Me.btRegistrar.Size = New System.Drawing.Size(107, 35)
        Me.btRegistrar.TabIndex = 12
        Me.btRegistrar.Text = "     Grabar"
        Me.btRegistrar.UseVisualStyle = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(435, 70)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 14)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Costo"
        '
        'txtCosto
        '
        Me.txtCosto.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtCosto.BeforeTouchSize = New System.Drawing.Size(282, 22)
        Me.txtCosto.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCosto.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCosto.Location = New System.Drawing.Point(438, 88)
        Me.txtCosto.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtCosto.Name = "txtCosto"
        Me.txtCosto.NullString = ""
        Me.txtCosto.Size = New System.Drawing.Size(129, 22)
        Me.txtCosto.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtCosto.TabIndex = 14
        Me.txtCosto.Text = "S/.0.00"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.ButtonAdv1)
        Me.Panel1.Controls.Add(Me.btRegistrar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 204)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(598, 59)
        Me.Panel1.TabIndex = 15
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.Gray
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(107, 35)
        Me.ButtonAdv1.Font = New System.Drawing.Font("Corbel", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(235, 12)
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(107, 35)
        Me.ButtonAdv1.TabIndex = 13
        Me.ButtonAdv1.Text = "Cancel"
        Me.ButtonAdv1.UseVisualStyle = True
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(446, 188)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(95, 14)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Membresía válida"
        Me.Label6.Visible = False
        '
        'txtValido
        '
        Me.txtValido.BackColor = System.Drawing.Color.MistyRose
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
        Me.txtValido.Calendar.Size = New System.Drawing.Size(114, 174)
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
        Me.txtValido.Calendar.NoneButton.Location = New System.Drawing.Point(42, 0)
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
        Me.txtValido.Calendar.TodayButton.Size = New System.Drawing.Size(42, 20)
        Me.txtValido.Calendar.TodayButton.Text = "Today"
        Me.txtValido.Calendar.TodayButton.UseVisualStyle = True
        Me.txtValido.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValido.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtValido.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtValido.DropDownImage = Nothing
        Me.txtValido.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtValido.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtValido.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtValido.Enabled = False
        Me.txtValido.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtValido.Location = New System.Drawing.Point(449, 209)
        Me.txtValido.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtValido.MinValue = New Date(CType(0, Long))
        Me.txtValido.Name = "txtValido"
        Me.txtValido.ShowCheckBox = False
        Me.txtValido.ShowDropButton = False
        Me.txtValido.Size = New System.Drawing.Size(118, 20)
        Me.txtValido.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtValido.TabIndex = 17
        Me.txtValido.Value = New Date(2017, 11, 9, 11, 49, 28, 230)
        Me.txtValido.Visible = False
        '
        'txtFechaActual
        '
        Me.txtFechaActual.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtFechaActual.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtFechaActual.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaActual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtFechaActual.Calendar.AllowMultipleSelection = False
        Me.txtFechaActual.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaActual.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaActual.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechaActual.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaActual.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFechaActual.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtFechaActual.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFechaActual.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaActual.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaActual.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtFechaActual.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtFechaActual.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtFechaActual.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtFechaActual.Calendar.Iso8601CalenderFormat = False
        Me.txtFechaActual.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaActual.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaActual.Calendar.Name = "monthCalendar"
        Me.txtFechaActual.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtFechaActual.Calendar.SelectedDates = New Date(-1) {}
        Me.txtFechaActual.Calendar.Size = New System.Drawing.Size(81, 174)
        Me.txtFechaActual.Calendar.SizeToFit = True
        Me.txtFechaActual.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaActual.Calendar.TabIndex = 0
        Me.txtFechaActual.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtFechaActual.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaActual.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaActual.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaActual.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaActual.Calendar.NoneButton.IsBackStageButton = False
        Me.txtFechaActual.Calendar.NoneButton.Location = New System.Drawing.Point(9, 0)
        Me.txtFechaActual.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtFechaActual.Calendar.NoneButton.Text = "None"
        Me.txtFechaActual.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtFechaActual.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaActual.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaActual.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaActual.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaActual.Calendar.TodayButton.IsBackStageButton = False
        Me.txtFechaActual.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaActual.Calendar.TodayButton.Size = New System.Drawing.Size(9, 20)
        Me.txtFechaActual.Calendar.TodayButton.Text = "Today"
        Me.txtFechaActual.Calendar.TodayButton.UseVisualStyle = True
        Me.txtFechaActual.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaActual.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtFechaActual.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechaActual.DropDownImage = Nothing
        Me.txtFechaActual.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaActual.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaActual.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtFechaActual.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaActual.Location = New System.Drawing.Point(224, 35)
        Me.txtFechaActual.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaActual.MinValue = New Date(CType(0, Long))
        Me.txtFechaActual.Name = "txtFechaActual"
        Me.txtFechaActual.ShowCheckBox = False
        Me.txtFechaActual.Size = New System.Drawing.Size(85, 20)
        Me.txtFechaActual.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaActual.TabIndex = 429
        Me.txtFechaActual.Value = New Date(2017, 11, 9, 11, 49, 28, 230)
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(221, 15)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(68, 14)
        Me.Label11.TabIndex = 428
        Me.Label11.Text = "Fecha actual"
        '
        'ComboBoxAdv1
        '
        Me.ComboBoxAdv1.BackColor = System.Drawing.Color.White
        Me.ComboBoxAdv1.BeforeTouchSize = New System.Drawing.Size(130, 21)
        Me.ComboBoxAdv1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxAdv1.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxAdv1.Items.AddRange(New Object() {"mes", "días"})
        Me.ComboBoxAdv1.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboBoxAdv1, "mes"))
        Me.ComboBoxAdv1.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboBoxAdv1, "días"))
        Me.ComboBoxAdv1.Location = New System.Drawing.Point(437, 34)
        Me.ComboBoxAdv1.Name = "ComboBoxAdv1"
        Me.ComboBoxAdv1.Size = New System.Drawing.Size(130, 21)
        Me.ComboBoxAdv1.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboBoxAdv1.TabIndex = 431
        Me.ComboBoxAdv1.Text = "mes"
        '
        'txtNumdiasPromo
        '
        Me.txtNumdiasPromo.BeforeTouchSize = New System.Drawing.Size(282, 22)
        Me.txtNumdiasPromo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNumdiasPromo.Location = New System.Drawing.Point(613, 35)
        Me.txtNumdiasPromo.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtNumdiasPromo.Name = "txtNumdiasPromo"
        Me.txtNumdiasPromo.ReadOnly = True
        Me.txtNumdiasPromo.Size = New System.Drawing.Size(80, 22)
        Me.txtNumdiasPromo.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtNumdiasPromo.TabIndex = 433
        Me.txtNumdiasPromo.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(597, 39)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(13, 14)
        Me.Label12.TabIndex = 434
        Me.Label12.Text = "="
        Me.Label12.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(345, 69)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(80, 14)
        Me.Label14.TabIndex = 436
        Me.Label14.Text = "Días de congel."
        '
        'txtDiasCongelados
        '
        Me.txtDiasCongelados.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtDiasCongelados.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiasCongelados.Location = New System.Drawing.Point(348, 88)
        Me.txtDiasCongelados.Name = "txtDiasCongelados"
        Me.txtDiasCongelados.Size = New System.Drawing.Size(83, 22)
        Me.txtDiasCongelados.TabIndex = 437
        '
        'txtCalculo
        '
        Me.txtCalculo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtCalculo.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCalculo.Location = New System.Drawing.Point(348, 33)
        Me.txtCalculo.Name = "txtCalculo"
        Me.txtCalculo.Size = New System.Drawing.Size(83, 22)
        Me.txtCalculo.TabIndex = 438
        Me.txtCalculo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(345, 13)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(134, 14)
        Me.Label7.TabIndex = 439
        Me.Label7.Text = "Duración de la membresía"
        '
        'frmNuevaMembresia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.Color.White
        Me.CaptionBarHeight = 55
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(15, 15)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(32, 32)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Corbel", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.Location = New System.Drawing.Point(55, 8)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Text = "Membresías"
        CaptionLabel2.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel2.ForeColor = System.Drawing.Color.OrangeRed
        CaptionLabel2.Location = New System.Drawing.Point(55, 24)
        CaptionLabel2.Name = "CaptionLabel2"
        CaptionLabel2.Size = New System.Drawing.Size(200, 24)
        CaptionLabel2.Text = "Creación interactiva"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.CaptionLabels.Add(CaptionLabel2)
        Me.ClientSize = New System.Drawing.Size(598, 263)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtCalculo)
        Me.Controls.Add(Me.txtDiasCongelados)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtNumdiasPromo)
        Me.Controls.Add(Me.ComboBoxAdv1)
        Me.Controls.Add(Me.txtFechaActual)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtValido)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtCosto)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GradientPanel2)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.cboPeriodicidad)
        Me.Controls.Add(Me.cboServicio)
        Me.Controls.Add(Me.txtDetalle)
        Me.Controls.Add(Me.txtProducto)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNuevaMembresia"
        Me.ShowIcon = False
        Me.Text = ""
        CType(Me.txtProducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboServicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboPeriodicidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCosto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValido.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValido, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaActual.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaActual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboBoxAdv1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumdiasPromo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDiasCongelados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCalculo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtProducto As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtDetalle As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents cboServicio As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents cboPeriodicidad As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents GradientPanel2 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents btRegistrar As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents Label5 As Label
    Friend WithEvents txtCosto As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents txtValido As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents Label6 As Label
    Friend WithEvents txtFechaActual As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents txtNumdiasPromo As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents ComboBoxAdv1 As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents txtDiasCongelados As NumericUpDown
    Friend WithEvents Label14 As Label
    Friend WithEvents txtCalculo As NumericUpDown
    Friend WithEvents Label7 As Label
End Class

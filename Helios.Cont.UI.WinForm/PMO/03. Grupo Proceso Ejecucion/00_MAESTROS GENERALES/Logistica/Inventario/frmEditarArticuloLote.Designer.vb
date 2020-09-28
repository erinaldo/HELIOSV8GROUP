<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditarArticuloLote
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEditarArticuloLote))
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Dim CaptionLabel2 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.txtCodigoBarra = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtProductoNew = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboUnidades = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.GradientPanel3 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.txtCodigoLote = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFechaproduccion = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.txtFechalote = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv2 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.btOperacion = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodigoBarra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProductoNew, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboUnidades, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodigoLote, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaproduccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaproduccion.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechalote, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechalote.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BorderColor = System.Drawing.Color.Gainsboro
        Me.GradientPanel1.BorderSides = System.Windows.Forms.Border3DSide.Top
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(633, 10)
        Me.GradientPanel1.TabIndex = 432
        '
        'txtCodigoBarra
        '
        Me.txtCodigoBarra.BackColor = System.Drawing.Color.White
        Me.txtCodigoBarra.BeforeTouchSize = New System.Drawing.Size(175, 22)
        Me.txtCodigoBarra.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtCodigoBarra.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtCodigoBarra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigoBarra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoBarra.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCodigoBarra.Enabled = False
        Me.txtCodigoBarra.Location = New System.Drawing.Point(26, 37)
        Me.txtCodigoBarra.MaxLength = 30
        Me.txtCodigoBarra.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtCodigoBarra.Name = "txtCodigoBarra"
        Me.txtCodigoBarra.NearImage = CType(resources.GetObject("txtCodigoBarra.NearImage"), System.Drawing.Image)
        Me.txtCodigoBarra.Size = New System.Drawing.Size(175, 22)
        Me.txtCodigoBarra.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtCodigoBarra.TabIndex = 442
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DimGray
        Me.Label6.Location = New System.Drawing.Point(27, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(150, 13)
        Me.Label6.TabIndex = 441
        Me.Label6.Text = "Código de barras (opcional)"
        '
        'txtProductoNew
        '
        Me.txtProductoNew.BackColor = System.Drawing.Color.White
        Me.txtProductoNew.BeforeTouchSize = New System.Drawing.Size(175, 22)
        Me.txtProductoNew.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtProductoNew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProductoNew.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProductoNew.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtProductoNew.Location = New System.Drawing.Point(26, 99)
        Me.txtProductoNew.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtProductoNew.Multiline = True
        Me.txtProductoNew.Name = "txtProductoNew"
        Me.txtProductoNew.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtProductoNew.Size = New System.Drawing.Size(274, 74)
        Me.txtProductoNew.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtProductoNew.TabIndex = 443
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(26, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 13)
        Me.Label1.TabIndex = 444
        Me.Label1.Text = "Nombre del producto"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DimGray
        Me.Label9.Location = New System.Drawing.Point(24, 186)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(102, 13)
        Me.Label9.TabIndex = 446
        Me.Label9.Text = "Unidad de medida"
        '
        'cboUnidades
        '
        Me.cboUnidades.BackColor = System.Drawing.Color.White
        Me.cboUnidades.BeforeTouchSize = New System.Drawing.Size(273, 21)
        Me.cboUnidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUnidades.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboUnidades.Location = New System.Drawing.Point(27, 208)
        Me.cboUnidades.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.cboUnidades.Name = "cboUnidades"
        Me.cboUnidades.Size = New System.Drawing.Size(273, 21)
        Me.cboUnidades.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboUnidades.TabIndex = 445
        '
        'GradientPanel3
        '
        Me.GradientPanel3.BorderColor = System.Drawing.Color.Gainsboro
        Me.GradientPanel3.BorderSides = System.Windows.Forms.Border3DSide.Left
        Me.GradientPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel3.Location = New System.Drawing.Point(319, 12)
        Me.GradientPanel3.Name = "GradientPanel3"
        Me.GradientPanel3.Size = New System.Drawing.Size(10, 265)
        Me.GradientPanel3.TabIndex = 447
        '
        'txtCodigoLote
        '
        Me.txtCodigoLote.BackColor = System.Drawing.Color.White
        Me.txtCodigoLote.BeforeTouchSize = New System.Drawing.Size(175, 22)
        Me.txtCodigoLote.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtCodigoLote.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtCodigoLote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigoLote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoLote.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtCodigoLote.Enabled = False
        Me.txtCodigoLote.Location = New System.Drawing.Point(353, 37)
        Me.txtCodigoLote.MaxLength = 30
        Me.txtCodigoLote.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtCodigoLote.Name = "txtCodigoLote"
        Me.txtCodigoLote.NearImage = CType(resources.GetObject("txtCodigoLote.NearImage"), System.Drawing.Image)
        Me.txtCodigoLote.ReadOnly = True
        Me.txtCodigoLote.Size = New System.Drawing.Size(108, 22)
        Me.txtCodigoLote.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtCodigoLote.TabIndex = 449
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(354, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 13)
        Me.Label2.TabIndex = 448
        Me.Label2.Text = "Código de lote aut."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(350, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 13)
        Me.Label3.TabIndex = 450
        Me.Label3.Text = "Fecha producción"
        '
        'txtFechaproduccion
        '
        Me.txtFechaproduccion.BackColor = System.Drawing.Color.ForestGreen
        Me.txtFechaproduccion.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtFechaproduccion.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaproduccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtFechaproduccion.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaproduccion.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaproduccion.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechaproduccion.Calendar.DayNamesColor = System.Drawing.Color.Empty
        Me.txtFechaproduccion.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFechaproduccion.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaproduccion.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaproduccion.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtFechaproduccion.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtFechaproduccion.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtFechaproduccion.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtFechaproduccion.Calendar.Iso8601CalenderFormat = False
        Me.txtFechaproduccion.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaproduccion.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaproduccion.Calendar.Name = "monthCalendar"
        Me.txtFechaproduccion.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtFechaproduccion.Calendar.SelectedDates = New Date(-1) {}
        Me.txtFechaproduccion.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaproduccion.Calendar.TabIndex = 0
        Me.txtFechaproduccion.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtFechaproduccion.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaproduccion.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaproduccion.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaproduccion.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaproduccion.Calendar.NoneButton.IsBackStageButton = False
        Me.txtFechaproduccion.Calendar.NoneButton.Location = New System.Drawing.Point(78, 0)
        Me.txtFechaproduccion.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtFechaproduccion.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtFechaproduccion.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaproduccion.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaproduccion.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaproduccion.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaproduccion.Calendar.TodayButton.IsBackStageButton = False
        Me.txtFechaproduccion.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaproduccion.Calendar.TodayButton.Size = New System.Drawing.Size(78, 20)
        Me.txtFechaproduccion.Calendar.TodayButton.UseVisualStyle = True
        Me.txtFechaproduccion.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaproduccion.CalendarForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaproduccion.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtFechaproduccion.Checked = False
        Me.txtFechaproduccion.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechaproduccion.CustomFormat = "dd/MM/yyyy"
        Me.txtFechaproduccion.DropDownImage = Nothing
        Me.txtFechaproduccion.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaproduccion.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaproduccion.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtFechaproduccion.Font = New System.Drawing.Font("Century Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaproduccion.ForeColor = System.Drawing.Color.White
        Me.txtFechaproduccion.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFechaproduccion.Location = New System.Drawing.Point(353, 99)
        Me.txtFechaproduccion.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaproduccion.MinValue = New Date(CType(0, Long))
        Me.txtFechaproduccion.Name = "txtFechaproduccion"
        Me.txtFechaproduccion.ShowCheckBox = False
        Me.txtFechaproduccion.Size = New System.Drawing.Size(200, 20)
        Me.txtFechaproduccion.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaproduccion.TabIndex = 507
        Me.txtFechaproduccion.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'txtFechalote
        '
        Me.txtFechalote.BackColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.txtFechalote.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtFechalote.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechalote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtFechalote.Calendar.AllowMultipleSelection = False
        Me.txtFechalote.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechalote.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechalote.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechalote.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechalote.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFechalote.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtFechalote.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFechalote.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechalote.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechalote.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtFechalote.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtFechalote.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtFechalote.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtFechalote.Calendar.Iso8601CalenderFormat = False
        Me.txtFechalote.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtFechalote.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechalote.Calendar.Name = "monthCalendar"
        Me.txtFechalote.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtFechalote.Calendar.SelectedDates = New Date(-1) {}
        Me.txtFechalote.Calendar.Size = New System.Drawing.Size(198, 174)
        Me.txtFechalote.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechalote.Calendar.TabIndex = 0
        Me.txtFechalote.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtFechalote.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechalote.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechalote.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechalote.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtFechalote.Calendar.NoneButton.IsBackStageButton = False
        Me.txtFechalote.Calendar.NoneButton.Location = New System.Drawing.Point(126, 0)
        Me.txtFechalote.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtFechalote.Calendar.NoneButton.Text = "None"
        Me.txtFechalote.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtFechalote.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechalote.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechalote.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechalote.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtFechalote.Calendar.TodayButton.IsBackStageButton = False
        Me.txtFechalote.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtFechalote.Calendar.TodayButton.Size = New System.Drawing.Size(126, 20)
        Me.txtFechalote.Calendar.TodayButton.Text = "Today"
        Me.txtFechalote.Calendar.TodayButton.UseVisualStyle = True
        Me.txtFechalote.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechalote.CalendarForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechalote.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtFechalote.Checked = False
        Me.txtFechalote.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechalote.CustomFormat = "dd/MM/yyyy HH:mm.ss tt"
        Me.txtFechalote.DropDownImage = Nothing
        Me.txtFechalote.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechalote.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechalote.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtFechalote.Font = New System.Drawing.Font("Century Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechalote.ForeColor = System.Drawing.Color.White
        Me.txtFechalote.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFechalote.Location = New System.Drawing.Point(353, 149)
        Me.txtFechalote.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechalote.MinValue = New Date(CType(0, Long))
        Me.txtFechalote.Name = "txtFechalote"
        Me.txtFechalote.ShowCheckBox = False
        Me.txtFechalote.ShowUpDownOnFocus = True
        Me.txtFechalote.Size = New System.Drawing.Size(200, 20)
        Me.txtFechalote.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechalote.TabIndex = 509
        Me.txtFechalote.Value = New Date(2016, 1, 25, 11, 17, 0, 0)
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(350, 129)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(96, 13)
        Me.Label12.TabIndex = 508
        Me.Label12.Text = "Fecha Vcto. (Lote)"
        '
        'GradientPanel2
        '
        Me.GradientPanel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GradientPanel2.Controls.Add(Me.ButtonAdv2)
        Me.GradientPanel2.Controls.Add(Me.btOperacion)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 285)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(633, 45)
        Me.GradientPanel2.TabIndex = 510
        '
        'ButtonAdv2
        '
        Me.ButtonAdv2.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv2.BackColor = System.Drawing.Color.White
        Me.ButtonAdv2.BeforeTouchSize = New System.Drawing.Size(100, 32)
        Me.ButtonAdv2.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.ButtonAdv2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAdv2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv2.ForeColor = System.Drawing.Color.Black
        Me.ButtonAdv2.IsBackStageButton = False
        Me.ButtonAdv2.Location = New System.Drawing.Point(326, 9)
        Me.ButtonAdv2.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonAdv2.Name = "ButtonAdv2"
        Me.ButtonAdv2.Size = New System.Drawing.Size(100, 32)
        Me.ButtonAdv2.TabIndex = 9
        Me.ButtonAdv2.Text = "Cancel"
        Me.ButtonAdv2.UseVisualStyle = True
        '
        'btOperacion
        '
        Me.btOperacion.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btOperacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.btOperacion.BeforeTouchSize = New System.Drawing.Size(100, 32)
        Me.btOperacion.Font = New System.Drawing.Font("Ebrima", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btOperacion.ForeColor = System.Drawing.Color.White
        Me.btOperacion.IsBackStageButton = False
        Me.btOperacion.Location = New System.Drawing.Point(211, 10)
        Me.btOperacion.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btOperacion.Name = "btOperacion"
        Me.btOperacion.Size = New System.Drawing.Size(100, 32)
        Me.btOperacion.TabIndex = 8
        Me.btOperacion.Text = "Grabar"
        Me.btOperacion.UseVisualStyle = True
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'frmEditarArticuloLote
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.Color.White
        Me.CaptionBarHeight = 55
        CaptionLabel1.Font = New System.Drawing.Font("Ebrima", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.Gray
        CaptionLabel1.Location = New System.Drawing.Point(55, 8)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(200, 24)
        CaptionLabel1.Text = "Modificar artículo"
        CaptionLabel2.Font = New System.Drawing.Font("Ebrima", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        CaptionLabel2.Location = New System.Drawing.Point(55, 24)
        CaptionLabel2.Name = "CaptionLabel2"
        CaptionLabel2.Size = New System.Drawing.Size(200, 24)
        CaptionLabel2.Text = "Matenimiento"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.CaptionLabels.Add(CaptionLabel2)
        Me.ClientSize = New System.Drawing.Size(633, 330)
        Me.Controls.Add(Me.GradientPanel2)
        Me.Controls.Add(Me.txtFechalote)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtFechaproduccion)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCodigoLote)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GradientPanel3)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cboUnidades)
        Me.Controls.Add(Me.txtProductoNew)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCodigoBarra)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.GradientPanel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEditarArticuloLote"
        Me.ShowIcon = False
        Me.Text = ""
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodigoBarra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProductoNew, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboUnidades, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodigoLote, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaproduccion.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaproduccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechalote.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechalote, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents txtCodigoBarra As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label6 As Label
    Friend WithEvents txtProductoNew As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label1 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents cboUnidades As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents GradientPanel3 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents txtCodigoLote As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtFechaproduccion As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents txtFechalote As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents Label12 As Label
    Friend WithEvents GradientPanel2 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents ButtonAdv2 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents btOperacion As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents ErrorProvider1 As ErrorProvider
End Class

Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmGestionarLotes
    Inherits MetroForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGestionarLotes))
        Dim BannerTextInfo1 As Syncfusion.Windows.Forms.BannerTextInfo = New Syncfusion.Windows.Forms.BannerTextInfo()
        Dim BannerTextInfo2 As Syncfusion.Windows.Forms.BannerTextInfo = New Syncfusion.Windows.Forms.BannerTextInfo()
        Dim BannerTextInfo3 As Syncfusion.Windows.Forms.BannerTextInfo = New Syncfusion.Windows.Forms.BannerTextInfo()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Dim CaptionLabel2 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.txtProductoNew = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCodigoBarra = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtFechaVcto = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtFechaproduccion = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCodigoLote = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtSerie = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.GradientPanel3 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.btOperacion = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.BannerTextProvider1 = New Syncfusion.Windows.Forms.BannerTextProvider(Me.components)
        Me.TxtSku = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextBoxExt3 = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtComposicion = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtNroLote = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProductoNew, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodigoBarra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaVcto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaVcto.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaproduccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaproduccion.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodigoLote, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtSerie, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtSku, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxExt3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtComposicion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNroLote, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.GradientPanel1.Size = New System.Drawing.Size(749, 10)
        Me.GradientPanel1.TabIndex = 433
        '
        'txtProductoNew
        '
        Me.txtProductoNew.BackColor = System.Drawing.Color.Gainsboro
        Me.txtProductoNew.BeforeTouchSize = New System.Drawing.Size(175, 22)
        Me.txtProductoNew.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtProductoNew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProductoNew.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProductoNew.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtProductoNew.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductoNew.Location = New System.Drawing.Point(30, 100)
        Me.txtProductoNew.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtProductoNew.Name = "txtProductoNew"
        Me.txtProductoNew.ReadOnly = True
        Me.txtProductoNew.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtProductoNew.Size = New System.Drawing.Size(314, 22)
        Me.txtProductoNew.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtProductoNew.TabIndex = 447
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(30, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 14)
        Me.Label1.TabIndex = 448
        Me.Label1.Text = "Nombre del producto"
        '
        'txtCodigoBarra
        '
        Me.txtCodigoBarra.BackColor = System.Drawing.Color.Gainsboro
        Me.txtCodigoBarra.BeforeTouchSize = New System.Drawing.Size(175, 22)
        Me.txtCodigoBarra.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtCodigoBarra.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtCodigoBarra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigoBarra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoBarra.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCodigoBarra.Enabled = False
        Me.txtCodigoBarra.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoBarra.Location = New System.Drawing.Point(30, 45)
        Me.txtCodigoBarra.MaxLength = 30
        Me.txtCodigoBarra.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtCodigoBarra.Name = "txtCodigoBarra"
        Me.txtCodigoBarra.NearImage = CType(resources.GetObject("txtCodigoBarra.NearImage"), System.Drawing.Image)
        Me.txtCodigoBarra.Size = New System.Drawing.Size(175, 22)
        Me.txtCodigoBarra.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtCodigoBarra.TabIndex = 446
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(31, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(148, 14)
        Me.Label6.TabIndex = 445
        Me.Label6.Text = "Código de barra del producto"
        '
        'txtFechaVcto
        '
        Me.txtFechaVcto.BackColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.txtFechaVcto.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtFechaVcto.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaVcto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtFechaVcto.Calendar.AllowMultipleSelection = False
        Me.txtFechaVcto.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaVcto.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaVcto.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechaVcto.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaVcto.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFechaVcto.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtFechaVcto.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFechaVcto.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaVcto.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaVcto.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtFechaVcto.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtFechaVcto.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtFechaVcto.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtFechaVcto.Calendar.Iso8601CalenderFormat = False
        Me.txtFechaVcto.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaVcto.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaVcto.Calendar.Name = "monthCalendar"
        Me.txtFechaVcto.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtFechaVcto.Calendar.SelectedDates = New Date(-1) {}
        Me.txtFechaVcto.Calendar.Size = New System.Drawing.Size(198, 174)
        Me.txtFechaVcto.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaVcto.Calendar.TabIndex = 0
        Me.txtFechaVcto.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtFechaVcto.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaVcto.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaVcto.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaVcto.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaVcto.Calendar.NoneButton.IsBackStageButton = False
        Me.txtFechaVcto.Calendar.NoneButton.Location = New System.Drawing.Point(126, 0)
        Me.txtFechaVcto.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtFechaVcto.Calendar.NoneButton.Text = "None"
        Me.txtFechaVcto.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtFechaVcto.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaVcto.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaVcto.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaVcto.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaVcto.Calendar.TodayButton.IsBackStageButton = False
        Me.txtFechaVcto.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaVcto.Calendar.TodayButton.Size = New System.Drawing.Size(126, 20)
        Me.txtFechaVcto.Calendar.TodayButton.Text = "Today"
        Me.txtFechaVcto.Calendar.TodayButton.UseVisualStyle = True
        Me.txtFechaVcto.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaVcto.CalendarForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaVcto.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtFechaVcto.Checked = False
        Me.txtFechaVcto.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechaVcto.CustomFormat = "dd/MM/yyyy HH:mm.ss tt"
        Me.txtFechaVcto.DropDownImage = Nothing
        Me.txtFechaVcto.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaVcto.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaVcto.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtFechaVcto.Font = New System.Drawing.Font("Century Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaVcto.ForeColor = System.Drawing.Color.White
        Me.txtFechaVcto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFechaVcto.Location = New System.Drawing.Point(30, 253)
        Me.txtFechaVcto.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaVcto.MinValue = New Date(CType(0, Long))
        Me.txtFechaVcto.Name = "txtFechaVcto"
        Me.txtFechaVcto.ShowCheckBox = False
        Me.txtFechaVcto.ShowUpDownOnFocus = True
        Me.txtFechaVcto.Size = New System.Drawing.Size(200, 20)
        Me.txtFechaVcto.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaVcto.TabIndex = 515
        Me.txtFechaVcto.Value = New Date(2016, 1, 25, 11, 17, 0, 0)
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(31, 234)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(95, 14)
        Me.Label12.TabIndex = 514
        Me.Label12.Text = "Fecha Vcto. (Lote)"
        '
        'txtFechaproduccion
        '
        Me.txtFechaproduccion.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(162, Byte), Integer), CType(CType(255, Byte), Integer))
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
        Me.txtFechaproduccion.Location = New System.Drawing.Point(30, 202)
        Me.txtFechaproduccion.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaproduccion.MinValue = New Date(CType(0, Long))
        Me.txtFechaproduccion.Name = "txtFechaproduccion"
        Me.txtFechaproduccion.ShowCheckBox = False
        Me.txtFechaproduccion.Size = New System.Drawing.Size(200, 20)
        Me.txtFechaproduccion.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaproduccion.TabIndex = 513
        Me.txtFechaproduccion.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(31, 181)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 14)
        Me.Label3.TabIndex = 512
        Me.Label3.Text = "Fecha producción"
        '
        'txtCodigoLote
        '
        Me.txtCodigoLote.BackColor = System.Drawing.Color.Gainsboro
        Me.txtCodigoLote.BeforeTouchSize = New System.Drawing.Size(175, 22)
        Me.txtCodigoLote.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtCodigoLote.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtCodigoLote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigoLote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoLote.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCodigoLote.Enabled = False
        Me.txtCodigoLote.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoLote.Location = New System.Drawing.Point(30, 151)
        Me.txtCodigoLote.MaxLength = 30
        Me.txtCodigoLote.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtCodigoLote.Name = "txtCodigoLote"
        Me.txtCodigoLote.NearImage = CType(resources.GetObject("txtCodigoLote.NearImage"), System.Drawing.Image)
        Me.txtCodigoLote.ReadOnly = True
        Me.txtCodigoLote.Size = New System.Drawing.Size(108, 22)
        Me.txtCodigoLote.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtCodigoLote.TabIndex = 511
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(31, 130)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 14)
        Me.Label2.TabIndex = 510
        Me.Label2.Text = "Código de lote aut."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(424, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 14)
        Me.Label4.TabIndex = 516
        Me.Label4.Text = "Información adicional"
        '
        'TxtSerie
        '
        Me.TxtSerie.BackColor = System.Drawing.Color.White
        BannerTextInfo1.Text = "Serie: XXXXX-XXXXXX"
        BannerTextInfo1.Visible = True
        Me.BannerTextProvider1.SetBannerText(Me.TxtSerie, BannerTextInfo1)
        Me.TxtSerie.BeforeTouchSize = New System.Drawing.Size(175, 22)
        Me.TxtSerie.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TxtSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtSerie.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtSerie.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSerie.Location = New System.Drawing.Point(427, 70)
        Me.TxtSerie.MaxLength = 50
        Me.TxtSerie.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TxtSerie.Name = "TxtSerie"
        Me.TxtSerie.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtSerie.Size = New System.Drawing.Size(279, 22)
        Me.TxtSerie.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TxtSerie.TabIndex = 517
        '
        'GradientPanel3
        '
        Me.GradientPanel3.BorderColor = System.Drawing.Color.Gainsboro
        Me.GradientPanel3.BorderSides = System.Windows.Forms.Border3DSide.Left
        Me.GradientPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel3.Location = New System.Drawing.Point(373, 17)
        Me.GradientPanel3.Name = "GradientPanel3"
        Me.GradientPanel3.Size = New System.Drawing.Size(10, 265)
        Me.GradientPanel3.TabIndex = 518
        '
        'btOperacion
        '
        Me.btOperacion.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btOperacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.btOperacion.BeforeTouchSize = New System.Drawing.Size(152, 40)
        Me.btOperacion.Font = New System.Drawing.Font("Calibri Light", 9.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btOperacion.ForeColor = System.Drawing.Color.White
        Me.btOperacion.IsBackStageButton = False
        Me.btOperacion.Location = New System.Drawing.Point(296, 302)
        Me.btOperacion.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btOperacion.Name = "btOperacion"
        Me.btOperacion.Size = New System.Drawing.Size(152, 40)
        Me.btOperacion.TabIndex = 8
        Me.btOperacion.Text = "Grabar información"
        Me.btOperacion.UseVisualStyle = True
        '
        'TxtSku
        '
        Me.TxtSku.BackColor = System.Drawing.Color.White
        BannerTextInfo2.Text = "TROP-XX-XX-00"
        BannerTextInfo2.Visible = True
        Me.BannerTextProvider1.SetBannerText(Me.TxtSku, BannerTextInfo2)
        Me.TxtSku.BeforeTouchSize = New System.Drawing.Size(175, 22)
        Me.TxtSku.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TxtSku.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtSku.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtSku.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtSku.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSku.Location = New System.Drawing.Point(427, 118)
        Me.TxtSku.MaxLength = 50
        Me.TxtSku.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TxtSku.Name = "TxtSku"
        Me.TxtSku.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtSku.Size = New System.Drawing.Size(279, 22)
        Me.TxtSku.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TxtSku.TabIndex = 519
        '
        'TextBoxExt3
        '
        Me.TextBoxExt3.BackColor = System.Drawing.Color.White
        BannerTextInfo3.Text = "Partida Registral... (opcional)"
        BannerTextInfo3.Visible = True
        Me.BannerTextProvider1.SetBannerText(Me.TextBoxExt3, BannerTextInfo3)
        Me.TextBoxExt3.BeforeTouchSize = New System.Drawing.Size(175, 22)
        Me.TextBoxExt3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextBoxExt3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxExt3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBoxExt3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBoxExt3.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxExt3.Location = New System.Drawing.Point(427, 226)
        Me.TextBoxExt3.MaxLength = 50
        Me.TextBoxExt3.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextBoxExt3.Name = "TextBoxExt3"
        Me.TextBoxExt3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBoxExt3.Size = New System.Drawing.Size(279, 22)
        Me.TextBoxExt3.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextBoxExt3.TabIndex = 520
        Me.TextBoxExt3.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(424, 157)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 14)
        Me.Label5.TabIndex = 521
        Me.Label5.Text = "Composición (opc.)"
        '
        'TxtComposicion
        '
        Me.TxtComposicion.BackColor = System.Drawing.Color.White
        Me.TxtComposicion.BeforeTouchSize = New System.Drawing.Size(175, 22)
        Me.TxtComposicion.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TxtComposicion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtComposicion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtComposicion.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtComposicion.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtComposicion.Location = New System.Drawing.Point(427, 181)
        Me.TxtComposicion.MaxLength = 180
        Me.TxtComposicion.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TxtComposicion.Multiline = True
        Me.TxtComposicion.Name = "TxtComposicion"
        Me.TxtComposicion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtComposicion.Size = New System.Drawing.Size(279, 92)
        Me.TxtComposicion.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TxtComposicion.TabIndex = 522
        '
        'txtNroLote
        '
        Me.txtNroLote.BackColor = System.Drawing.Color.White
        Me.txtNroLote.BeforeTouchSize = New System.Drawing.Size(175, 22)
        Me.txtNroLote.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtNroLote.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtNroLote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNroLote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNroLote.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNroLote.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNroLote.Location = New System.Drawing.Point(144, 151)
        Me.txtNroLote.MaxLength = 50
        Me.txtNroLote.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtNroLote.Name = "txtNroLote"
        Me.txtNroLote.NearImage = CType(resources.GetObject("txtNroLote.NearImage"), System.Drawing.Image)
        Me.txtNroLote.Size = New System.Drawing.Size(86, 22)
        Me.txtNroLote.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtNroLote.TabIndex = 524
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(145, 130)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 14)
        Me.Label7.TabIndex = 523
        Me.Label7.Text = "Nro. de lote"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(426, 51)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(31, 14)
        Me.Label8.TabIndex = 525
        Me.Label8.Text = "Serie"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(426, 100)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(35, 14)
        Me.Label9.TabIndex = 526
        Me.Label9.Text = "S.K.U."
        '
        'frmGestionarLotes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarHeight = 55
        CaptionLabel1.Font = New System.Drawing.Font("Ebrima", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.Gray
        CaptionLabel1.Location = New System.Drawing.Point(55, 8)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(200, 24)
        CaptionLabel1.Text = "Información del Lote"
        CaptionLabel2.Font = New System.Drawing.Font("Calibri Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(2, Byte), Integer), CType(CType(2, Byte), Integer))
        CaptionLabel2.Location = New System.Drawing.Point(55, 24)
        CaptionLabel2.Name = "CaptionLabel2"
        CaptionLabel2.Size = New System.Drawing.Size(200, 24)
        CaptionLabel2.Text = "Matenimiento"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.CaptionLabels.Add(CaptionLabel2)
        Me.ClientSize = New System.Drawing.Size(749, 346)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtNroLote)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtComposicion)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TextBoxExt3)
        Me.Controls.Add(Me.TxtSku)
        Me.Controls.Add(Me.btOperacion)
        Me.Controls.Add(Me.GradientPanel3)
        Me.Controls.Add(Me.TxtSerie)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtFechaVcto)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtFechaproduccion)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCodigoLote)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtProductoNew)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCodigoBarra)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.GradientPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmGestionarLotes"
        Me.ShowIcon = False
        Me.ShowMaximizeBox = False
        Me.ShowMinimizeBox = False
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProductoNew, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodigoBarra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaVcto.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaVcto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaproduccion.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaproduccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodigoLote, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtSerie, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtSku, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxExt3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtComposicion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNroLote, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GradientPanel1 As Tools.GradientPanel
    Friend WithEvents txtProductoNew As Tools.TextBoxExt
    Friend WithEvents Label1 As Label
    Friend WithEvents txtCodigoBarra As Tools.TextBoxExt
    Friend WithEvents Label6 As Label
    Friend WithEvents txtFechaVcto As Tools.DateTimePickerAdv
    Friend WithEvents Label12 As Label
    Friend WithEvents txtFechaproduccion As Tools.DateTimePickerAdv
    Friend WithEvents Label3 As Label
    Friend WithEvents txtCodigoLote As Tools.TextBoxExt
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtSerie As Tools.TextBoxExt
    Friend WithEvents GradientPanel3 As Tools.GradientPanel
    Friend WithEvents btOperacion As ButtonAdv
    Friend WithEvents BannerTextProvider1 As BannerTextProvider
    Friend WithEvents TxtSku As Tools.TextBoxExt
    Friend WithEvents TextBoxExt3 As Tools.TextBoxExt
    Friend WithEvents Label5 As Label
    Friend WithEvents TxtComposicion As Tools.TextBoxExt
    Friend WithEvents txtNroLote As Tools.TextBoxExt
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
End Class

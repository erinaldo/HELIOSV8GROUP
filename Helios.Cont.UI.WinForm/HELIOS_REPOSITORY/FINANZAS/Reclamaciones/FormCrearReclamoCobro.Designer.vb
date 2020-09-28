Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormCrearReclamoCobro
    Inherits MetroForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCrearReclamoCobro))
        Me.ButtonSalir = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.TextBaseImponible = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextRuc = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextValorReclamacion = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.textMontoBase = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ButtonGrabar = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.TextValorIva = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TextPersona = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.textFecha = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextNumero = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextSerie = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.cboTipoOperacion = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        CType(Me.TextBaseImponible, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextRuc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextValorReclamacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.textMontoBase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextValorIva, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextPersona, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.textFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.textFecha.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextNumero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextSerie, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonSalir
        '
        Me.ButtonSalir.Activecolor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.ButtonSalir.BackColor = System.Drawing.Color.Gainsboro
        Me.ButtonSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonSalir.BorderRadius = 7
        Me.ButtonSalir.ButtonText = "    Cancelar"
        Me.ButtonSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonSalir.DisabledColor = System.Drawing.Color.Gray
        Me.ButtonSalir.Iconcolor = System.Drawing.Color.Transparent
        Me.ButtonSalir.Iconimage = CType(resources.GetObject("ButtonSalir.Iconimage"), System.Drawing.Image)
        Me.ButtonSalir.Iconimage_right = Nothing
        Me.ButtonSalir.Iconimage_right_Selected = Nothing
        Me.ButtonSalir.Iconimage_Selected = Nothing
        Me.ButtonSalir.IconMarginLeft = 0
        Me.ButtonSalir.IconMarginRight = 0
        Me.ButtonSalir.IconRightVisible = True
        Me.ButtonSalir.IconRightZoom = 0R
        Me.ButtonSalir.IconVisible = False
        Me.ButtonSalir.IconZoom = 40.0R
        Me.ButtonSalir.IsTab = False
        Me.ButtonSalir.Location = New System.Drawing.Point(219, 298)
        Me.ButtonSalir.Name = "ButtonSalir"
        Me.ButtonSalir.Normalcolor = System.Drawing.Color.Gainsboro
        Me.ButtonSalir.OnHovercolor = System.Drawing.Color.Gainsboro
        Me.ButtonSalir.OnHoverTextColor = System.Drawing.Color.DimGray
        Me.ButtonSalir.selected = False
        Me.ButtonSalir.Size = New System.Drawing.Size(121, 40)
        Me.ButtonSalir.TabIndex = 627
        Me.ButtonSalir.Text = "    Cancelar"
        Me.ButtonSalir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ButtonSalir.Textcolor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonSalir.TextFont = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'TextBaseImponible
        '
        Me.TextBaseImponible.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBaseImponible.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TextBaseImponible.BorderColor = System.Drawing.Color.Silver
        Me.TextBaseImponible.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBaseImponible.CornerRadius = 5
        Me.TextBaseImponible.CurrencySymbol = ""
        Me.TextBaseImponible.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBaseImponible.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextBaseImponible.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBaseImponible.ForeColor = System.Drawing.Color.Black
        Me.TextBaseImponible.Location = New System.Drawing.Point(326, 216)
        Me.TextBaseImponible.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextBaseImponible.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextBaseImponible.Name = "TextBaseImponible"
        Me.TextBaseImponible.NullString = ""
        Me.TextBaseImponible.PositiveColor = System.Drawing.Color.Black
        Me.TextBaseImponible.ReadOnly = True
        Me.TextBaseImponible.ReadOnlyBackColor = System.Drawing.Color.WhiteSmoke
        Me.TextBaseImponible.Size = New System.Drawing.Size(141, 23)
        Me.TextBaseImponible.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextBaseImponible.TabIndex = 626
        Me.TextBaseImponible.Text = "0.00"
        Me.TextBaseImponible.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(241, 221)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 14)
        Me.Label7.TabIndex = 625
        Me.Label7.Text = "Base imponible"
        '
        'TextRuc
        '
        Me.TextRuc.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextRuc.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TextRuc.BorderColor = System.Drawing.SystemColors.MenuHighlight
        Me.TextRuc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextRuc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextRuc.CornerRadius = 4
        Me.TextRuc.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextRuc.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextRuc.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextRuc.Location = New System.Drawing.Point(346, 123)
        Me.TextRuc.Metrocolor = System.Drawing.Color.Silver
        Me.TextRuc.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextRuc.Name = "TextRuc"
        Me.TextRuc.Size = New System.Drawing.Size(121, 24)
        Me.TextRuc.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextRuc.TabIndex = 624
        '
        'TextValorReclamacion
        '
        Me.TextValorReclamacion.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextValorReclamacion.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TextValorReclamacion.BorderColor = System.Drawing.Color.Silver
        Me.TextValorReclamacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextValorReclamacion.CornerRadius = 5
        Me.TextValorReclamacion.CurrencySymbol = ""
        Me.TextValorReclamacion.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextValorReclamacion.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextValorReclamacion.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextValorReclamacion.ForeColor = System.Drawing.Color.Black
        Me.TextValorReclamacion.Location = New System.Drawing.Point(326, 187)
        Me.TextValorReclamacion.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextValorReclamacion.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextValorReclamacion.Name = "TextValorReclamacion"
        Me.TextValorReclamacion.NullString = ""
        Me.TextValorReclamacion.PositiveColor = System.Drawing.Color.Black
        Me.TextValorReclamacion.ReadOnlyBackColor = System.Drawing.Color.WhiteSmoke
        Me.TextValorReclamacion.Size = New System.Drawing.Size(141, 23)
        Me.TextValorReclamacion.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextValorReclamacion.TabIndex = 623
        Me.TextValorReclamacion.Text = "0.00"
        Me.TextValorReclamacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(200, 194)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(125, 14)
        Me.Label4.TabIndex = 622
        Me.Label4.Text = "Importe de compromiso"
        '
        'textMontoBase
        '
        Me.textMontoBase.BackGroundColor = System.Drawing.Color.WhiteSmoke
        Me.textMontoBase.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.textMontoBase.BorderColor = System.Drawing.Color.Silver
        Me.textMontoBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.textMontoBase.CornerRadius = 5
        Me.textMontoBase.CurrencySymbol = ""
        Me.textMontoBase.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.textMontoBase.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.textMontoBase.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textMontoBase.ForeColor = System.Drawing.Color.Maroon
        Me.textMontoBase.Location = New System.Drawing.Point(326, 158)
        Me.textMontoBase.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.textMontoBase.MinimumSize = New System.Drawing.Size(14, 10)
        Me.textMontoBase.Name = "textMontoBase"
        Me.textMontoBase.NullString = ""
        Me.textMontoBase.PositiveColor = System.Drawing.Color.Maroon
        Me.textMontoBase.ReadOnly = True
        Me.textMontoBase.ReadOnlyBackColor = System.Drawing.Color.Thistle
        Me.textMontoBase.Size = New System.Drawing.Size(141, 23)
        Me.textMontoBase.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.textMontoBase.TabIndex = 621
        Me.textMontoBase.Text = "0.00"
        Me.textMontoBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(221, 165)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 14)
        Me.Label3.TabIndex = 620
        Me.Label3.Text = "Reclamacion disponible"
        '
        'ButtonGrabar
        '
        Me.ButtonGrabar.Activecolor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.ButtonGrabar.BackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.ButtonGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonGrabar.BorderRadius = 7
        Me.ButtonGrabar.ButtonText = "Guardar"
        Me.ButtonGrabar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonGrabar.DisabledColor = System.Drawing.Color.Gray
        Me.ButtonGrabar.Iconcolor = System.Drawing.Color.Transparent
        Me.ButtonGrabar.Iconimage = CType(resources.GetObject("ButtonGrabar.Iconimage"), System.Drawing.Image)
        Me.ButtonGrabar.Iconimage_right = Nothing
        Me.ButtonGrabar.Iconimage_right_Selected = Nothing
        Me.ButtonGrabar.Iconimage_Selected = Nothing
        Me.ButtonGrabar.IconMarginLeft = 0
        Me.ButtonGrabar.IconMarginRight = 0
        Me.ButtonGrabar.IconRightVisible = True
        Me.ButtonGrabar.IconRightZoom = 0R
        Me.ButtonGrabar.IconVisible = True
        Me.ButtonGrabar.IconZoom = 40.0R
        Me.ButtonGrabar.IsTab = False
        Me.ButtonGrabar.Location = New System.Drawing.Point(346, 298)
        Me.ButtonGrabar.Name = "ButtonGrabar"
        Me.ButtonGrabar.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.ButtonGrabar.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.ButtonGrabar.OnHoverTextColor = System.Drawing.Color.White
        Me.ButtonGrabar.selected = False
        Me.ButtonGrabar.Size = New System.Drawing.Size(121, 40)
        Me.ButtonGrabar.TabIndex = 619
        Me.ButtonGrabar.Text = "Guardar"
        Me.ButtonGrabar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ButtonGrabar.Textcolor = System.Drawing.Color.White
        Me.ButtonGrabar.TextFont = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'TextValorIva
        '
        Me.TextValorIva.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextValorIva.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TextValorIva.BorderColor = System.Drawing.Color.Silver
        Me.TextValorIva.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextValorIva.CornerRadius = 5
        Me.TextValorIva.CurrencySymbol = ""
        Me.TextValorIva.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextValorIva.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextValorIva.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextValorIva.ForeColor = System.Drawing.Color.Black
        Me.TextValorIva.Location = New System.Drawing.Point(326, 244)
        Me.TextValorIva.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextValorIva.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextValorIva.Name = "TextValorIva"
        Me.TextValorIva.NullString = ""
        Me.TextValorIva.PositiveColor = System.Drawing.Color.Black
        Me.TextValorIva.ReadOnly = True
        Me.TextValorIva.ReadOnlyBackColor = System.Drawing.Color.WhiteSmoke
        Me.TextValorIva.Size = New System.Drawing.Size(141, 23)
        Me.TextValorIva.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextValorIva.TabIndex = 618
        Me.TextValorIva.Text = "0.00"
        Me.TextValorIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(298, 248)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(26, 14)
        Me.Label5.TabIndex = 617
        Me.Label5.Text = "IVA."
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(19, 83)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(135, 19)
        Me.Label8.TabIndex = 616
        Me.Label8.Text = "Persona beneficiaria"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(20, 106)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(67, 14)
        Me.Label14.TabIndex = 615
        Me.Label14.Text = "Razón social"
        '
        'TextPersona
        '
        Me.TextPersona.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextPersona.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TextPersona.BorderColor = System.Drawing.SystemColors.MenuHighlight
        Me.TextPersona.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextPersona.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextPersona.CornerRadius = 4
        Me.TextPersona.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextPersona.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextPersona.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextPersona.Location = New System.Drawing.Point(23, 123)
        Me.TextPersona.Metrocolor = System.Drawing.SystemColors.MenuHighlight
        Me.TextPersona.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextPersona.Name = "TextPersona"
        Me.TextPersona.NearImage = CType(resources.GetObject("TextPersona.NearImage"), System.Drawing.Image)
        Me.TextPersona.Size = New System.Drawing.Size(317, 24)
        Me.TextPersona.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextPersona.TabIndex = 614
        '
        'textFecha
        '
        Me.textFecha.BackColor = System.Drawing.Color.White
        Me.textFecha.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.textFecha.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.textFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.textFecha.Calendar.AllowMultipleSelection = False
        Me.textFecha.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.textFecha.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.textFecha.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.textFecha.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.textFecha.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.textFecha.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.textFecha.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.textFecha.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textFecha.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.textFecha.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.textFecha.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.textFecha.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.textFecha.Calendar.HighlightColor = System.Drawing.Color.White
        Me.textFecha.Calendar.Iso8601CalenderFormat = False
        Me.textFecha.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.textFecha.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.textFecha.Calendar.Name = "monthCalendar"
        Me.textFecha.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.textFecha.Calendar.SelectedDates = New Date(-1) {}
        Me.textFecha.Calendar.Size = New System.Drawing.Size(233, 174)
        Me.textFecha.Calendar.SizeToFit = True
        Me.textFecha.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.textFecha.Calendar.TabIndex = 0
        Me.textFecha.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.textFecha.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.textFecha.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.textFecha.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.textFecha.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.textFecha.Calendar.NoneButton.IsBackStageButton = False
        Me.textFecha.Calendar.NoneButton.Location = New System.Drawing.Point(157, 0)
        Me.textFecha.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.textFecha.Calendar.NoneButton.Text = "None"
        Me.textFecha.Calendar.NoneButton.UseVisualStyle = True
        Me.textFecha.Calendar.NoneButton.Visible = False
        '
        '
        '
        Me.textFecha.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.textFecha.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.textFecha.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.textFecha.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.textFecha.Calendar.TodayButton.IsBackStageButton = False
        Me.textFecha.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.textFecha.Calendar.TodayButton.Size = New System.Drawing.Size(233, 20)
        Me.textFecha.Calendar.TodayButton.Text = "Today"
        Me.textFecha.Calendar.TodayButton.UseVisualStyle = True
        Me.textFecha.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textFecha.CalendarSize = New System.Drawing.Size(189, 176)
        Me.textFecha.Checked = False
        Me.textFecha.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.textFecha.CustomFormat = "dd/MM/yyyy HH:mm:ss tt"
        Me.textFecha.DropDownImage = Nothing
        Me.textFecha.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.textFecha.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.textFecha.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.textFecha.Enabled = False
        Me.textFecha.EnableNullDate = False
        Me.textFecha.EnableNullKeys = False
        Me.textFecha.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textFecha.ForeColor = System.Drawing.SystemColors.ControlText
        Me.textFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.textFecha.Location = New System.Drawing.Point(23, 55)
        Me.textFecha.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.textFecha.MinValue = New Date(CType(0, Long))
        Me.textFecha.Name = "textFecha"
        Me.textFecha.ShowCheckBox = False
        Me.textFecha.ShowDropButton = False
        Me.textFecha.Size = New System.Drawing.Size(235, 21)
        Me.textFecha.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.textFecha.TabIndex = 613
        Me.textFecha.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(20, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 14)
        Me.Label1.TabIndex = 612
        Me.Label1.Text = "Fecha emisión"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft JhengHei UI", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label6.Location = New System.Drawing.Point(19, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(156, 19)
        Me.Label6.TabIndex = 611
        Me.Label6.Text = "Nuevo Compromiso"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(632, 123)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 19)
        Me.Label2.TabIndex = 631
        Me.Label2.Text = "Comprobante"
        '
        'TextNumero
        '
        Me.TextNumero.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextNumero.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TextNumero.BorderColor = System.Drawing.Color.Silver
        Me.TextNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNumero.CornerRadius = 4
        Me.TextNumero.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextNumero.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNumero.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextNumero.Location = New System.Drawing.Point(732, 216)
        Me.TextNumero.Metrocolor = System.Drawing.Color.Silver
        Me.TextNumero.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextNumero.Name = "TextNumero"
        Me.TextNumero.Size = New System.Drawing.Size(107, 24)
        Me.TextNumero.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextNumero.TabIndex = 630
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(633, 196)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(77, 14)
        Me.Label10.TabIndex = 629
        Me.Label10.Text = "Serie - número"
        '
        'TextSerie
        '
        Me.TextSerie.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextSerie.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TextSerie.BorderColor = System.Drawing.Color.Silver
        Me.TextSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextSerie.CornerRadius = 4
        Me.TextSerie.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextSerie.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextSerie.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextSerie.Location = New System.Drawing.Point(636, 216)
        Me.TextSerie.Metrocolor = System.Drawing.Color.Silver
        Me.TextSerie.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextSerie.Name = "TextSerie"
        Me.TextSerie.Size = New System.Drawing.Size(90, 24)
        Me.TextSerie.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextSerie.TabIndex = 628
        '
        'cboTipoOperacion
        '
        Me.cboTipoOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoOperacion.FormattingEnabled = True
        Me.cboTipoOperacion.Items.AddRange(New Object() {"COMPENSACION", "DEVOLUCION"})
        Me.cboTipoOperacion.Location = New System.Drawing.Point(313, 55)
        Me.cboTipoOperacion.Name = "cboTipoOperacion"
        Me.cboTipoOperacion.Size = New System.Drawing.Size(135, 21)
        Me.cboTipoOperacion.TabIndex = 632
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(309, 31)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(74, 19)
        Me.Label9.TabIndex = 633
        Me.Label9.Text = "Operaciòn"
        '
        'FormCrearReclamoCobro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.Color.Black
        Me.CaptionBarColor = System.Drawing.Color.Black
        Me.CaptionButtonColor = System.Drawing.Color.White
        Me.CaptionButtonHoverColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(487, 349)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cboTipoOperacion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextNumero)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TextSerie)
        Me.Controls.Add(Me.ButtonSalir)
        Me.Controls.Add(Me.TextBaseImponible)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TextRuc)
        Me.Controls.Add(Me.TextValorReclamacion)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.textMontoBase)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ButtonGrabar)
        Me.Controls.Add(Me.TextValorIva)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.TextPersona)
        Me.Controls.Add(Me.textFecha)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label6)
        Me.Name = "FormCrearReclamoCobro"
        Me.ShowIcon = False
        CType(Me.TextBaseImponible, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextRuc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextValorReclamacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.textMontoBase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextValorIva, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextPersona, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.textFecha.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.textFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextNumero, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextSerie, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ButtonSalir As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents TextBaseImponible As Tools.CurrencyTextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TextRuc As Tools.TextBoxExt
    Friend WithEvents TextValorReclamacion As Tools.CurrencyTextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents textMontoBase As Tools.CurrencyTextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents ButtonGrabar As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents TextValorIva As Tools.CurrencyTextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents TextPersona As Tools.TextBoxExt
    Friend WithEvents textFecha As Tools.DateTimePickerAdv
    Friend WithEvents Label1 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextNumero As Tools.TextBoxExt
    Friend WithEvents Label10 As Label
    Friend WithEvents TextSerie As Tools.TextBoxExt
    Friend WithEvents cboTipoOperacion As ComboBox
    Friend WithEvents Label9 As Label
End Class

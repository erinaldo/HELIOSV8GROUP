Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormBeneficioRegalos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormBeneficioRegalos))
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Dim CaptionLabel2 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.btGrabar = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CbotipoAfectacion = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.LabelAlmacen = New System.Windows.Forms.Label()
        Me.TextImporteBase = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CboAlmacen = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.TextDetalleBeneficio = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.TextNroDocEntidad = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextEntidad = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtVigencia = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.chAfectoComprobante = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ButtonAdv2 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.TextCantidadRef = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextProductoRef = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.TextProduccion = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.PcProductsRefer = New Syncfusion.Windows.Forms.PopupControlContainer()
        Me.ListProductsRef = New System.Windows.Forms.ListBox()
        Me.pcProductos = New Syncfusion.Windows.Forms.PopupControlContainer()
        Me.LstProducts = New System.Windows.Forms.ListBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LsvProducts = New System.Windows.Forms.ListView()
        Me.colID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colItem = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColCantidad = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColAlmacen = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox5.SuspendLayout()
        CType(Me.CbotipoAfectacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextImporteBase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextDetalleBeneficio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.TextNroDocEntidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEntidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.txtVigencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVigencia.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.TextCantidadRef, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextProductoRef, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextProduccion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        Me.PcProductsRefer.SuspendLayout()
        Me.pcProductos.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btGrabar
        '
        Me.btGrabar.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btGrabar.BackColor = System.Drawing.Color.Chocolate
        Me.btGrabar.BeforeTouchSize = New System.Drawing.Size(117, 41)
        Me.btGrabar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btGrabar.ForeColor = System.Drawing.Color.White
        Me.btGrabar.Image = CType(resources.GetObject("btGrabar.Image"), System.Drawing.Image)
        Me.btGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btGrabar.IsBackStageButton = False
        Me.btGrabar.Location = New System.Drawing.Point(835, 330)
        Me.btGrabar.MetroColor = System.Drawing.Color.Chocolate
        Me.btGrabar.Name = "btGrabar"
        Me.btGrabar.Size = New System.Drawing.Size(117, 41)
        Me.btGrabar.TabIndex = 237
        Me.btGrabar.Text = "Grabar"
        Me.btGrabar.UseVisualStyle = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label1)
        Me.GroupBox5.Controls.Add(Me.CbotipoAfectacion)
        Me.GroupBox5.Controls.Add(Me.LabelAlmacen)
        Me.GroupBox5.Controls.Add(Me.TextImporteBase)
        Me.GroupBox5.Controls.Add(Me.Label6)
        Me.GroupBox5.Controls.Add(Me.CboAlmacen)
        Me.GroupBox5.Controls.Add(Me.TextDetalleBeneficio)
        Me.GroupBox5.Location = New System.Drawing.Point(13, 76)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(471, 110)
        Me.GroupBox5.TabIndex = 235
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Datos del producto beneficiado"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(204, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 523
        Me.Label1.Text = "Tipo afectación"
        '
        'CbotipoAfectacion
        '
        Me.CbotipoAfectacion.BackColor = System.Drawing.Color.White
        Me.CbotipoAfectacion.BeforeTouchSize = New System.Drawing.Size(162, 21)
        Me.CbotipoAfectacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbotipoAfectacion.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbotipoAfectacion.Items.AddRange(New Object() {"IMPORTE", "CANTIDAD"})
        Me.CbotipoAfectacion.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.CbotipoAfectacion, "IMPORTE"))
        Me.CbotipoAfectacion.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.CbotipoAfectacion, "CANTIDAD"))
        Me.CbotipoAfectacion.Location = New System.Drawing.Point(207, 46)
        Me.CbotipoAfectacion.MetroBorderColor = System.Drawing.Color.Silver
        Me.CbotipoAfectacion.Name = "CbotipoAfectacion"
        Me.CbotipoAfectacion.Size = New System.Drawing.Size(162, 21)
        Me.CbotipoAfectacion.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.CbotipoAfectacion.TabIndex = 522
        Me.CbotipoAfectacion.Text = "IMPORTE"
        '
        'LabelAlmacen
        '
        Me.LabelAlmacen.AutoSize = True
        Me.LabelAlmacen.Location = New System.Drawing.Point(10, 25)
        Me.LabelAlmacen.Name = "LabelAlmacen"
        Me.LabelAlmacen.Size = New System.Drawing.Size(48, 13)
        Me.LabelAlmacen.TabIndex = 512
        Me.LabelAlmacen.Text = "Almacén"
        '
        'TextImporteBase
        '
        Me.TextImporteBase.BackGroundColor = System.Drawing.Color.White
        Me.TextImporteBase.BeforeTouchSize = New System.Drawing.Size(284, 22)
        Me.TextImporteBase.BorderColor = System.Drawing.Color.Silver
        Me.TextImporteBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextImporteBase.CurrencySymbol = ""
        Me.TextImporteBase.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextImporteBase.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextImporteBase.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextImporteBase.ForeColor = System.Drawing.Color.Black
        Me.TextImporteBase.Location = New System.Drawing.Point(375, 44)
        Me.TextImporteBase.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextImporteBase.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextImporteBase.Name = "TextImporteBase"
        Me.TextImporteBase.NullString = ""
        Me.TextImporteBase.PositiveColor = System.Drawing.Color.Black
        Me.TextImporteBase.ReadOnlyBackColor = System.Drawing.Color.WhiteSmoke
        Me.TextImporteBase.Size = New System.Drawing.Size(77, 23)
        Me.TextImporteBase.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextImporteBase.TabIndex = 510
        Me.TextImporteBase.Text = "0.00"
        Me.TextImporteBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(376, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 13)
        Me.Label6.TabIndex = 226
        Me.Label6.Text = "Importe base"
        '
        'CboAlmacen
        '
        Me.CboAlmacen.BackColor = System.Drawing.Color.White
        Me.CboAlmacen.BeforeTouchSize = New System.Drawing.Size(188, 21)
        Me.CboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboAlmacen.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboAlmacen.Location = New System.Drawing.Point(13, 46)
        Me.CboAlmacen.MetroBorderColor = System.Drawing.Color.Silver
        Me.CboAlmacen.Name = "CboAlmacen"
        Me.CboAlmacen.Size = New System.Drawing.Size(188, 21)
        Me.CboAlmacen.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.CboAlmacen.TabIndex = 513
        '
        'TextDetalleBeneficio
        '
        Me.TextDetalleBeneficio.BackColor = System.Drawing.Color.White
        Me.TextDetalleBeneficio.BeforeTouchSize = New System.Drawing.Size(284, 22)
        Me.TextDetalleBeneficio.BorderColor = System.Drawing.Color.Silver
        Me.TextDetalleBeneficio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextDetalleBeneficio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextDetalleBeneficio.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextDetalleBeneficio.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextDetalleBeneficio.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextDetalleBeneficio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextDetalleBeneficio.Location = New System.Drawing.Point(13, 75)
        Me.TextDetalleBeneficio.MaxLength = 150
        Me.TextDetalleBeneficio.Metrocolor = System.Drawing.Color.Silver
        Me.TextDetalleBeneficio.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextDetalleBeneficio.Name = "TextDetalleBeneficio"
        Me.TextDetalleBeneficio.NearImage = CType(resources.GetObject("TextDetalleBeneficio.NearImage"), System.Drawing.Image)
        Me.TextDetalleBeneficio.Size = New System.Drawing.Size(439, 22)
        Me.TextDetalleBeneficio.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextDetalleBeneficio.TabIndex = 223
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.TextNroDocEntidad)
        Me.GroupBox4.Controls.Add(Me.TextEntidad)
        Me.GroupBox4.Location = New System.Drawing.Point(13, 6)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(471, 68)
        Me.GroupBox4.TabIndex = 234
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Datos del Cliente"
        '
        'TextNroDocEntidad
        '
        Me.TextNroDocEntidad.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextNroDocEntidad.BeforeTouchSize = New System.Drawing.Size(284, 22)
        Me.TextNroDocEntidad.BorderColor = System.Drawing.Color.Silver
        Me.TextNroDocEntidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextNroDocEntidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNroDocEntidad.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextNroDocEntidad.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextNroDocEntidad.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNroDocEntidad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextNroDocEntidad.Location = New System.Drawing.Point(354, 27)
        Me.TextNroDocEntidad.Metrocolor = System.Drawing.Color.Silver
        Me.TextNroDocEntidad.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextNroDocEntidad.Name = "TextNroDocEntidad"
        Me.TextNroDocEntidad.ReadOnly = True
        Me.TextNroDocEntidad.Size = New System.Drawing.Size(98, 22)
        Me.TextNroDocEntidad.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextNroDocEntidad.TabIndex = 225
        '
        'TextEntidad
        '
        Me.TextEntidad.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextEntidad.BeforeTouchSize = New System.Drawing.Size(284, 22)
        Me.TextEntidad.BorderColor = System.Drawing.Color.Silver
        Me.TextEntidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextEntidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextEntidad.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextEntidad.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextEntidad.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEntidad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextEntidad.Location = New System.Drawing.Point(13, 27)
        Me.TextEntidad.Metrocolor = System.Drawing.Color.Silver
        Me.TextEntidad.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextEntidad.Name = "TextEntidad"
        Me.TextEntidad.NearImage = CType(resources.GetObject("TextEntidad.NearImage"), System.Drawing.Image)
        Me.TextEntidad.ReadOnly = True
        Me.TextEntidad.Size = New System.Drawing.Size(335, 22)
        Me.TextEntidad.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextEntidad.TabIndex = 224
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtVigencia)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.chAfectoComprobante)
        Me.GroupBox3.Location = New System.Drawing.Point(13, 192)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(471, 68)
        Me.GroupBox3.TabIndex = 233
        Me.GroupBox3.TabStop = False
        '
        'txtVigencia
        '
        Me.txtVigencia.BackColor = System.Drawing.Color.White
        Me.txtVigencia.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtVigencia.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtVigencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtVigencia.Calendar.AllowMultipleSelection = False
        Me.txtVigencia.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtVigencia.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVigencia.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtVigencia.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtVigencia.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtVigencia.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtVigencia.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtVigencia.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVigencia.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtVigencia.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtVigencia.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtVigencia.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtVigencia.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtVigencia.Calendar.Iso8601CalenderFormat = False
        Me.txtVigencia.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtVigencia.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtVigencia.Calendar.Name = "monthCalendar"
        Me.txtVigencia.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtVigencia.Calendar.SelectedDates = New Date(-1) {}
        Me.txtVigencia.Calendar.Size = New System.Drawing.Size(175, 174)
        Me.txtVigencia.Calendar.SizeToFit = True
        Me.txtVigencia.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtVigencia.Calendar.TabIndex = 0
        Me.txtVigencia.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtVigencia.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtVigencia.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtVigencia.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtVigencia.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtVigencia.Calendar.NoneButton.IsBackStageButton = False
        Me.txtVigencia.Calendar.NoneButton.Location = New System.Drawing.Point(99, 0)
        Me.txtVigencia.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtVigencia.Calendar.NoneButton.Text = "None"
        Me.txtVigencia.Calendar.NoneButton.UseVisualStyle = True
        Me.txtVigencia.Calendar.NoneButton.Visible = False
        '
        '
        '
        Me.txtVigencia.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtVigencia.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtVigencia.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtVigencia.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtVigencia.Calendar.TodayButton.IsBackStageButton = False
        Me.txtVigencia.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtVigencia.Calendar.TodayButton.Size = New System.Drawing.Size(175, 20)
        Me.txtVigencia.Calendar.TodayButton.Text = "Today"
        Me.txtVigencia.Calendar.TodayButton.UseVisualStyle = True
        Me.txtVigencia.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVigencia.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtVigencia.Checked = False
        Me.txtVigencia.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtVigencia.CustomFormat = "dd/MM/yyyy HH:mm:ss tt"
        Me.txtVigencia.DropDownImage = Nothing
        Me.txtVigencia.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtVigencia.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtVigencia.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtVigencia.EnableNullDate = False
        Me.txtVigencia.EnableNullKeys = False
        Me.txtVigencia.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVigencia.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtVigencia.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtVigencia.Location = New System.Drawing.Point(256, 37)
        Me.txtVigencia.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtVigencia.MinValue = New Date(CType(0, Long))
        Me.txtVigencia.Name = "txtVigencia"
        Me.txtVigencia.ShowCheckBox = False
        Me.txtVigencia.ShowDropButton = False
        Me.txtVigencia.Size = New System.Drawing.Size(177, 20)
        Me.txtVigencia.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtVigencia.TabIndex = 513
        Me.txtVigencia.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(37, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(127, 13)
        Me.Label5.TabIndex = 521
        Me.Label5.Text = "Afecto a un comprobante"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(253, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 13)
        Me.Label8.TabIndex = 512
        Me.Label8.Text = "Vigente hasta"
        '
        'chAfectoComprobante
        '
        Me.chAfectoComprobante.BackColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.chAfectoComprobante.ChechedOffColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.chAfectoComprobante.Checked = False
        Me.chAfectoComprobante.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.chAfectoComprobante.ForeColor = System.Drawing.Color.White
        Me.chAfectoComprobante.Location = New System.Drawing.Point(15, 37)
        Me.chAfectoComprobante.Name = "chAfectoComprobante"
        Me.chAfectoComprobante.Size = New System.Drawing.Size(20, 20)
        Me.chAfectoComprobante.TabIndex = 520
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ButtonAdv2)
        Me.GroupBox1.Controls.Add(Me.ButtonAdv1)
        Me.GroupBox1.Controls.Add(Me.TextCantidadRef)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TextProductoRef)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(491, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(461, 68)
        Me.GroupBox1.TabIndex = 231
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Producto bonificado o regalado"
        '
        'ButtonAdv2
        '
        Me.ButtonAdv2.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv2.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.ButtonAdv2.BeforeTouchSize = New System.Drawing.Size(45, 23)
        Me.ButtonAdv2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv2.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv2.IsBackStageButton = False
        Me.ButtonAdv2.Location = New System.Drawing.Point(406, 37)
        Me.ButtonAdv2.MetroColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.ButtonAdv2.Name = "ButtonAdv2"
        Me.ButtonAdv2.Size = New System.Drawing.Size(45, 23)
        Me.ButtonAdv2.TabIndex = 510
        Me.ButtonAdv2.Text = "Del"
        Me.ButtonAdv2.UseVisualStyle = True
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.SystemColors.Highlight
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(45, 23)
        Me.ButtonAdv1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(359, 37)
        Me.ButtonAdv1.MetroColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(45, 23)
        Me.ButtonAdv1.TabIndex = 436
        Me.ButtonAdv1.Text = "Add"
        Me.ButtonAdv1.UseVisualStyle = True
        '
        'TextCantidadRef
        '
        Me.TextCantidadRef.BackGroundColor = System.Drawing.Color.White
        Me.TextCantidadRef.BeforeTouchSize = New System.Drawing.Size(284, 22)
        Me.TextCantidadRef.BorderColor = System.Drawing.Color.Silver
        Me.TextCantidadRef.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextCantidadRef.CurrencySymbol = ""
        Me.TextCantidadRef.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextCantidadRef.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextCantidadRef.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextCantidadRef.ForeColor = System.Drawing.Color.Black
        Me.TextCantidadRef.Location = New System.Drawing.Point(299, 37)
        Me.TextCantidadRef.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextCantidadRef.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextCantidadRef.Name = "TextCantidadRef"
        Me.TextCantidadRef.NullString = ""
        Me.TextCantidadRef.PositiveColor = System.Drawing.Color.Black
        Me.TextCantidadRef.ReadOnlyBackColor = System.Drawing.Color.WhiteSmoke
        Me.TextCantidadRef.Size = New System.Drawing.Size(54, 23)
        Me.TextCantidadRef.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextCantidadRef.TabIndex = 509
        Me.TextCantidadRef.Text = "0.00"
        Me.TextCantidadRef.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(299, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 225
        Me.Label4.Text = "Cantidad"
        '
        'TextProductoRef
        '
        Me.TextProductoRef.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextProductoRef.BeforeTouchSize = New System.Drawing.Size(284, 22)
        Me.TextProductoRef.BorderColor = System.Drawing.Color.Silver
        Me.TextProductoRef.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextProductoRef.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextProductoRef.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextProductoRef.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextProductoRef.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextProductoRef.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextProductoRef.Location = New System.Drawing.Point(10, 38)
        Me.TextProductoRef.Metrocolor = System.Drawing.Color.Silver
        Me.TextProductoRef.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextProductoRef.Name = "TextProductoRef"
        Me.TextProductoRef.NearImage = CType(resources.GetObject("TextProductoRef.NearImage"), System.Drawing.Image)
        Me.TextProductoRef.ReadOnly = True
        Me.TextProductoRef.Size = New System.Drawing.Size(284, 22)
        Me.TextProductoRef.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextProductoRef.TabIndex = 224
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel2.Location = New System.Drawing.Point(255, 34)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(65, 13)
        Me.LinkLabel2.TabIndex = 511
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Seleccionar"
        '
        'TextProduccion
        '
        Me.TextProduccion.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextProduccion.BeforeTouchSize = New System.Drawing.Size(284, 22)
        Me.TextProduccion.BorderColor = System.Drawing.Color.Silver
        Me.TextProduccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextProduccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextProduccion.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextProduccion.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextProduccion.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextProduccion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextProduccion.Location = New System.Drawing.Point(15, 26)
        Me.TextProduccion.Metrocolor = System.Drawing.Color.Silver
        Me.TextProduccion.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextProduccion.Name = "TextProduccion"
        Me.TextProduccion.NearImage = CType(resources.GetObject("TextProduccion.NearImage"), System.Drawing.Image)
        Me.TextProduccion.ReadOnly = True
        Me.TextProduccion.Size = New System.Drawing.Size(236, 22)
        Me.TextProduccion.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextProduccion.TabIndex = 512
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.TextProduccion)
        Me.GroupBox6.Controls.Add(Me.LinkLabel2)
        Me.GroupBox6.Location = New System.Drawing.Point(13, 266)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(471, 58)
        Me.GroupBox6.TabIndex = 236
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Producción"
        '
        'PcProductsRefer
        '
        Me.PcProductsRefer.Controls.Add(Me.ListProductsRef)
        Me.PcProductsRefer.Location = New System.Drawing.Point(505, 634)
        Me.PcProductsRefer.Name = "PcProductsRefer"
        Me.PcProductsRefer.Size = New System.Drawing.Size(282, 128)
        Me.PcProductsRefer.TabIndex = 435
        '
        'ListProductsRef
        '
        Me.ListProductsRef.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListProductsRef.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListProductsRef.FormattingEnabled = True
        Me.ListProductsRef.Location = New System.Drawing.Point(0, 0)
        Me.ListProductsRef.Name = "ListProductsRef"
        Me.ListProductsRef.Size = New System.Drawing.Size(282, 128)
        Me.ListProductsRef.TabIndex = 0
        '
        'pcProductos
        '
        Me.pcProductos.Controls.Add(Me.LstProducts)
        Me.pcProductos.Location = New System.Drawing.Point(297, 444)
        Me.pcProductos.Name = "pcProductos"
        Me.pcProductos.Size = New System.Drawing.Size(282, 128)
        Me.pcProductos.TabIndex = 434
        '
        'LstProducts
        '
        Me.LstProducts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LstProducts.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstProducts.FormattingEnabled = True
        Me.LstProducts.Location = New System.Drawing.Point(0, 0)
        Me.LstProducts.Name = "LstProducts"
        Me.LstProducts.Size = New System.Drawing.Size(282, 128)
        Me.LstProducts.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.LsvProducts)
        Me.Panel1.Location = New System.Drawing.Point(491, 80)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(461, 244)
        Me.Panel1.TabIndex = 436
        '
        'LsvProducts
        '
        Me.LsvProducts.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colID, Me.colItem, Me.ColCantidad, Me.ColAlmacen})
        Me.LsvProducts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LsvProducts.FullRowSelect = True
        Me.LsvProducts.GridLines = True
        Me.LsvProducts.Location = New System.Drawing.Point(0, 0)
        Me.LsvProducts.Name = "LsvProducts"
        Me.LsvProducts.Size = New System.Drawing.Size(461, 244)
        Me.LsvProducts.TabIndex = 0
        Me.LsvProducts.UseCompatibleStateImageBehavior = False
        Me.LsvProducts.View = System.Windows.Forms.View.Details
        '
        'colID
        '
        Me.colID.Text = "ID"
        Me.colID.Width = 37
        '
        'colItem
        '
        Me.colItem.Text = "ITEM"
        Me.colItem.Width = 304
        '
        'ColCantidad
        '
        Me.ColCantidad.Text = "Cantidad"
        Me.ColCantidad.Width = 63
        '
        'ColAlmacen
        '
        Me.ColAlmacen.Text = "ALM"
        Me.ColAlmacen.Width = 50
        '
        'FormBeneficioRegalos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.Color.WhiteSmoke
        Me.CaptionBarHeight = 55
        Me.CaptionForeColor = System.Drawing.Color.White
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(15, 14)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(30, 30)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.DimGray
        CaptionLabel1.Location = New System.Drawing.Point(55, 8)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(200, 24)
        CaptionLabel1.Text = "Beneficio: Regalos, bonificación"
        CaptionLabel2.Font = New System.Drawing.Font("Calibri Light", 11.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel2.ForeColor = System.Drawing.Color.Chocolate
        CaptionLabel2.Location = New System.Drawing.Point(55, 22)
        CaptionLabel2.Name = "CaptionLabel2"
        CaptionLabel2.Text = "Clientes"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.CaptionLabels.Add(CaptionLabel2)
        Me.ClientSize = New System.Drawing.Size(963, 376)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PcProductsRefer)
        Me.Controls.Add(Me.pcProductos)
        Me.Controls.Add(Me.btGrabar)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FormBeneficioRegalos"
        Me.ShowIcon = False
        Me.ShowMaximizeBox = False
        Me.ShowMinimizeBox = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Beneficio Regalos"
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.CbotipoAfectacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextImporteBase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextDetalleBeneficio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.TextNroDocEntidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEntidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.txtVigencia.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVigencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.TextCantidadRef, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextProductoRef, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextProduccion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.PcProductsRefer.ResumeLayout(False)
        Me.pcProductos.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btGrabar As ButtonAdv
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents LabelAlmacen As Label
    Friend WithEvents CboAlmacen As Tools.ComboBoxAdv
    Friend WithEvents TextDetalleBeneficio As Tools.TextBoxExt
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents TextNroDocEntidad As Tools.TextBoxExt
    Friend WithEvents TextEntidad As Tools.TextBoxExt
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents txtVigencia As Tools.DateTimePickerAdv
    Friend WithEvents Label5 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents chAfectoComprobante As Bunifu.Framework.UI.BunifuCheckbox
    Friend WithEvents CbotipoAfectacion As Tools.ComboBoxAdv
    Friend WithEvents TextImporteBase As Tools.CurrencyTextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TextCantidadRef As Tools.CurrencyTextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TextProductoRef As Tools.TextBoxExt
    Friend WithEvents Label1 As Label
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents TextProduccion As Tools.TextBoxExt
    Friend WithEvents GroupBox6 As GroupBox
    Private WithEvents PcProductsRefer As PopupControlContainer
    Friend WithEvents ListProductsRef As ListBox
    Private WithEvents pcProductos As PopupControlContainer
    Friend WithEvents LstProducts As ListBox
    Friend WithEvents ButtonAdv1 As ButtonAdv
    Friend WithEvents Panel1 As Panel
    Friend WithEvents LsvProducts As ListView
    Friend WithEvents colID As ColumnHeader
    Friend WithEvents colItem As ColumnHeader
    Friend WithEvents ColCantidad As ColumnHeader
    Friend WithEvents ColAlmacen As ColumnHeader
    Friend WithEvents ButtonAdv2 As ButtonAdv
End Class

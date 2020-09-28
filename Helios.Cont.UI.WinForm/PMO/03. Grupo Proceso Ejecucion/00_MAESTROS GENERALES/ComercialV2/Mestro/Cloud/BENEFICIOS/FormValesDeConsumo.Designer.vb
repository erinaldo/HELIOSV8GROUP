Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormValesDeConsumo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormValesDeConsumo))
        Me.btGrabar = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.TextProduccion = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.TextDetalleBeneficio = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.CboTipoTabla = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CboTipoBeneficio = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.TextNroDocEntidad = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextEntidad = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtVigencia = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.chAfectoComprobante = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.CbotipoAfectacion = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.TextImporteBase = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextValorConvertido = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.GroupBox6.SuspendLayout()
        CType(Me.TextProduccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextDetalleBeneficio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.CboTipoTabla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboTipoBeneficio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.TextNroDocEntidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEntidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.txtVigencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVigencia.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.CbotipoAfectacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextImporteBase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextValorConvertido, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btGrabar
        '
        Me.btGrabar.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btGrabar.BackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.btGrabar.BeforeTouchSize = New System.Drawing.Size(117, 41)
        Me.btGrabar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btGrabar.ForeColor = System.Drawing.Color.White
        Me.btGrabar.Image = CType(resources.GetObject("btGrabar.Image"), System.Drawing.Image)
        Me.btGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btGrabar.IsBackStageButton = False
        Me.btGrabar.Location = New System.Drawing.Point(201, 401)
        Me.btGrabar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.btGrabar.Name = "btGrabar"
        Me.btGrabar.Size = New System.Drawing.Size(117, 41)
        Me.btGrabar.TabIndex = 236
        Me.btGrabar.Text = "Grabar"
        Me.btGrabar.UseVisualStyle = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.TextProduccion)
        Me.GroupBox6.Controls.Add(Me.LinkLabel2)
        Me.GroupBox6.Controls.Add(Me.TextDetalleBeneficio)
        Me.GroupBox6.Controls.Add(Me.Label7)
        Me.GroupBox6.Controls.Add(Me.TextValorConvertido)
        Me.GroupBox6.Location = New System.Drawing.Point(24, 157)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(471, 89)
        Me.GroupBox6.TabIndex = 235
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Beneficio en cupones"
        '
        'TextProduccion
        '
        Me.TextProduccion.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextProduccion.BeforeTouchSize = New System.Drawing.Size(353, 22)
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
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel2.Location = New System.Drawing.Point(255, 34)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(91, 13)
        Me.LinkLabel2.TabIndex = 511
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Cupones activos"
        '
        'TextDetalleBeneficio
        '
        Me.TextDetalleBeneficio.BackColor = System.Drawing.Color.White
        Me.TextDetalleBeneficio.BeforeTouchSize = New System.Drawing.Size(353, 22)
        Me.TextDetalleBeneficio.BorderColor = System.Drawing.Color.Silver
        Me.TextDetalleBeneficio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextDetalleBeneficio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextDetalleBeneficio.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextDetalleBeneficio.Enabled = False
        Me.TextDetalleBeneficio.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextDetalleBeneficio.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextDetalleBeneficio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextDetalleBeneficio.Location = New System.Drawing.Point(16, 56)
        Me.TextDetalleBeneficio.MaxLength = 150
        Me.TextDetalleBeneficio.Metrocolor = System.Drawing.Color.Silver
        Me.TextDetalleBeneficio.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextDetalleBeneficio.Name = "TextDetalleBeneficio"
        Me.TextDetalleBeneficio.NearImage = CType(resources.GetObject("TextDetalleBeneficio.NearImage"), System.Drawing.Image)
        Me.TextDetalleBeneficio.Size = New System.Drawing.Size(353, 22)
        Me.TextDetalleBeneficio.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextDetalleBeneficio.TabIndex = 223
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.CboTipoTabla)
        Me.GroupBox5.Controls.Add(Me.Label1)
        Me.GroupBox5.Controls.Add(Me.Label3)
        Me.GroupBox5.Controls.Add(Me.CboTipoBeneficio)
        Me.GroupBox5.Location = New System.Drawing.Point(24, 77)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(471, 74)
        Me.GroupBox5.TabIndex = 234
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Datos del beneficio"
        '
        'CboTipoTabla
        '
        Me.CboTipoTabla.BackColor = System.Drawing.Color.White
        Me.CboTipoTabla.BeforeTouchSize = New System.Drawing.Size(279, 21)
        Me.CboTipoTabla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipoTabla.Enabled = False
        Me.CboTipoTabla.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboTipoTabla.Items.AddRange(New Object() {"VALE DE DESCUENTO"})
        Me.CboTipoTabla.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.CboTipoTabla, "VALE DE DESCUENTO"))
        Me.CboTipoTabla.Location = New System.Drawing.Point(13, 42)
        Me.CboTipoTabla.MetroBorderColor = System.Drawing.Color.Silver
        Me.CboTipoTabla.Name = "CboTipoTabla"
        Me.CboTipoTabla.Size = New System.Drawing.Size(279, 21)
        Me.CboTipoTabla.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.CboTipoTabla.TabIndex = 219
        Me.CboTipoTabla.Text = "VALE DE DESCUENTO"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tipo tabla"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(295, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 13)
        Me.Label3.TabIndex = 221
        Me.Label3.Text = "Tipo beneficio"
        '
        'CboTipoBeneficio
        '
        Me.CboTipoBeneficio.BackColor = System.Drawing.Color.White
        Me.CboTipoBeneficio.BeforeTouchSize = New System.Drawing.Size(154, 21)
        Me.CboTipoBeneficio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipoBeneficio.Enabled = False
        Me.CboTipoBeneficio.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboTipoBeneficio.Items.AddRange(New Object() {"DOCUMENTO"})
        Me.CboTipoBeneficio.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.CboTipoBeneficio, "DOCUMENTO"))
        Me.CboTipoBeneficio.Location = New System.Drawing.Point(298, 42)
        Me.CboTipoBeneficio.MetroBorderColor = System.Drawing.Color.Silver
        Me.CboTipoBeneficio.Name = "CboTipoBeneficio"
        Me.CboTipoBeneficio.Size = New System.Drawing.Size(154, 21)
        Me.CboTipoBeneficio.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.CboTipoBeneficio.TabIndex = 222
        Me.CboTipoBeneficio.Text = "DOCUMENTO"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.TextNroDocEntidad)
        Me.GroupBox4.Controls.Add(Me.TextEntidad)
        Me.GroupBox4.Location = New System.Drawing.Point(24, 7)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(471, 68)
        Me.GroupBox4.TabIndex = 233
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Datos del Cliente"
        '
        'TextNroDocEntidad
        '
        Me.TextNroDocEntidad.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextNroDocEntidad.BeforeTouchSize = New System.Drawing.Size(353, 22)
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
        Me.TextEntidad.BeforeTouchSize = New System.Drawing.Size(353, 22)
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
        Me.GroupBox3.Location = New System.Drawing.Point(24, 248)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(471, 68)
        Me.GroupBox3.TabIndex = 232
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CbotipoAfectacion)
        Me.GroupBox2.Controls.Add(Me.TextImporteBase)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(24, 322)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(472, 64)
        Me.GroupBox2.TabIndex = 231
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Afectación del beneficio a traves de:"
        '
        'CbotipoAfectacion
        '
        Me.CbotipoAfectacion.BackColor = System.Drawing.Color.White
        Me.CbotipoAfectacion.BeforeTouchSize = New System.Drawing.Size(185, 21)
        Me.CbotipoAfectacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbotipoAfectacion.Enabled = False
        Me.CbotipoAfectacion.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CbotipoAfectacion.Items.AddRange(New Object() {"IMPORTE", "CANTIDAD"})
        Me.CbotipoAfectacion.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.CbotipoAfectacion, "IMPORTE"))
        Me.CbotipoAfectacion.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.CbotipoAfectacion, "CANTIDAD"))
        Me.CbotipoAfectacion.Location = New System.Drawing.Point(16, 36)
        Me.CbotipoAfectacion.MetroBorderColor = System.Drawing.Color.Silver
        Me.CbotipoAfectacion.Name = "CbotipoAfectacion"
        Me.CbotipoAfectacion.Size = New System.Drawing.Size(185, 21)
        Me.CbotipoAfectacion.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.CbotipoAfectacion.TabIndex = 522
        Me.CbotipoAfectacion.Text = "IMPORTE"
        '
        'TextImporteBase
        '
        Me.TextImporteBase.BackGroundColor = System.Drawing.Color.White
        Me.TextImporteBase.BeforeTouchSize = New System.Drawing.Size(353, 22)
        Me.TextImporteBase.BorderColor = System.Drawing.Color.Silver
        Me.TextImporteBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextImporteBase.CurrencySymbol = ""
        Me.TextImporteBase.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextImporteBase.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextImporteBase.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextImporteBase.ForeColor = System.Drawing.Color.Black
        Me.TextImporteBase.Location = New System.Drawing.Point(267, 34)
        Me.TextImporteBase.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextImporteBase.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextImporteBase.Name = "TextImporteBase"
        Me.TextImporteBase.NullString = ""
        Me.TextImporteBase.PositiveColor = System.Drawing.Color.Black
        Me.TextImporteBase.ReadOnlyBackColor = System.Drawing.Color.WhiteSmoke
        Me.TextImporteBase.Size = New System.Drawing.Size(102, 23)
        Me.TextImporteBase.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextImporteBase.TabIndex = 510
        Me.TextImporteBase.Text = "0.00"
        Me.TextImporteBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(267, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 13)
        Me.Label6.TabIndex = 226
        Me.Label6.Text = "Importe base"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(372, 35)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 13)
        Me.Label7.TabIndex = 227
        Me.Label7.Text = "Valor ganado"
        '
        'TextValorConvertido
        '
        Me.TextValorConvertido.BackGroundColor = System.Drawing.Color.White
        Me.TextValorConvertido.BeforeTouchSize = New System.Drawing.Size(353, 22)
        Me.TextValorConvertido.BorderColor = System.Drawing.Color.Silver
        Me.TextValorConvertido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextValorConvertido.CurrencySymbol = ""
        Me.TextValorConvertido.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextValorConvertido.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextValorConvertido.Enabled = False
        Me.TextValorConvertido.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextValorConvertido.ForeColor = System.Drawing.Color.Black
        Me.TextValorConvertido.Location = New System.Drawing.Point(375, 55)
        Me.TextValorConvertido.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextValorConvertido.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextValorConvertido.Name = "TextValorConvertido"
        Me.TextValorConvertido.NullString = ""
        Me.TextValorConvertido.PositiveColor = System.Drawing.Color.Black
        Me.TextValorConvertido.ReadOnlyBackColor = System.Drawing.Color.WhiteSmoke
        Me.TextValorConvertido.Size = New System.Drawing.Size(77, 23)
        Me.TextValorConvertido.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextValorConvertido.TabIndex = 511
        Me.TextValorConvertido.Text = "0.00"
        Me.TextValorConvertido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'FormValesDeConsumo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.Color.WhiteSmoke
        Me.CaptionBarHeight = 55
        Me.CaptionForeColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(519, 452)
        Me.Controls.Add(Me.btGrabar)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormValesDeConsumo"
        Me.ShowIcon = False
        Me.Text = "Vales De Consumo"
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.TextProduccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextDetalleBeneficio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.CboTipoTabla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboTipoBeneficio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.TextNroDocEntidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEntidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.txtVigencia.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVigencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.CbotipoAfectacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextImporteBase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextValorConvertido, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btGrabar As ButtonAdv
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents TextProduccion As Tools.TextBoxExt
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents CboTipoTabla As Tools.ComboBoxAdv
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents CboTipoBeneficio As Tools.ComboBoxAdv
    Friend WithEvents TextDetalleBeneficio As Tools.TextBoxExt
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents TextNroDocEntidad As Tools.TextBoxExt
    Friend WithEvents TextEntidad As Tools.TextBoxExt
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents txtVigencia As Tools.DateTimePickerAdv
    Friend WithEvents Label5 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents chAfectoComprobante As Bunifu.Framework.UI.BunifuCheckbox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents CbotipoAfectacion As Tools.ComboBoxAdv
    Friend WithEvents TextImporteBase As Tools.CurrencyTextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents TextValorConvertido As Tools.CurrencyTextBox
End Class

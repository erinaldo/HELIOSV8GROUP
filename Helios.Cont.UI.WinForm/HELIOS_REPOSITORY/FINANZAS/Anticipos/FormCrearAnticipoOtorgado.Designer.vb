Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormCrearAnticipoOtorgado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCrearAnticipoOtorgado))
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"1", "JIUNI PALACIOS SANTOS", "44924569"}, -1)
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextNumeroDocumento = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.ComboTipoDoc = New Bunifu.Framework.UI.BunifuDropdown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.textFecha = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.ComboFormaDeposito = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboTipoAnticipo = New Bunifu.Framework.UI.BunifuDropdown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextRuc = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.TextBaseImponible = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TextValorIva = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ComboCuentaFinanciera = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextValorPrestamo = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ButtonSalir = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.TextNroCuenta = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ButtonGrabar = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TextPersona = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.pcLikeCategoria = New Syncfusion.Windows.Forms.PopupControlContainer()
        Me.LsvProveedor = New System.Windows.Forms.ListView()
        Me.colID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colRUC = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTipoDoc = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtSaldoCaja = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        CType(Me.TextNumeroDocumento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.textFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.textFecha.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboFormaDeposito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextRuc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBaseImponible, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextValorIva, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboCuentaFinanciera, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextValorPrestamo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextNroCuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextPersona, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pcLikeCategoria.SuspendLayout()
        CType(Me.txtSaldoCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(282, 104)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(86, 14)
        Me.Label10.TabIndex = 581
        Me.Label10.Text = "Nro. documento"
        '
        'TextNumeroDocumento
        '
        Me.TextNumeroDocumento.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextNumeroDocumento.BeforeTouchSize = New System.Drawing.Size(194, 24)
        Me.TextNumeroDocumento.BorderColor = System.Drawing.Color.Silver
        Me.TextNumeroDocumento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextNumeroDocumento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNumeroDocumento.CornerRadius = 4
        Me.TextNumeroDocumento.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextNumeroDocumento.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNumeroDocumento.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextNumeroDocumento.Location = New System.Drawing.Point(285, 124)
        Me.TextNumeroDocumento.Metrocolor = System.Drawing.Color.Silver
        Me.TextNumeroDocumento.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextNumeroDocumento.Name = "TextNumeroDocumento"
        Me.TextNumeroDocumento.Size = New System.Drawing.Size(194, 24)
        Me.TextNumeroDocumento.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextNumeroDocumento.TabIndex = 580
        '
        'ComboTipoDoc
        '
        Me.ComboTipoDoc.BackColor = System.Drawing.Color.Transparent
        Me.ComboTipoDoc.BorderRadius = 5
        Me.ComboTipoDoc.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ComboTipoDoc.ForeColor = System.Drawing.Color.White
        Me.ComboTipoDoc.Items = New String() {"FACTURA", "VOUCHER"}
        Me.ComboTipoDoc.Location = New System.Drawing.Point(285, 71)
        Me.ComboTipoDoc.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboTipoDoc.Name = "ComboTipoDoc"
        Me.ComboTipoDoc.NomalColor = System.Drawing.SystemColors.HotTrack
        Me.ComboTipoDoc.onHoverColor = System.Drawing.SystemColors.HotTrack
        Me.ComboTipoDoc.selectedIndex = 0
        Me.ComboTipoDoc.Size = New System.Drawing.Size(194, 25)
        Me.ComboTipoDoc.TabIndex = 579
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(282, 50)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(86, 14)
        Me.Label9.TabIndex = 578
        Me.Label9.Text = "Tipo documento"
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
        Me.textFecha.EnableNullDate = False
        Me.textFecha.EnableNullKeys = False
        Me.textFecha.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textFecha.ForeColor = System.Drawing.SystemColors.ControlText
        Me.textFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.textFecha.Location = New System.Drawing.Point(35, 124)
        Me.textFecha.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.textFecha.MinValue = New Date(CType(0, Long))
        Me.textFecha.Name = "textFecha"
        Me.textFecha.ShowCheckBox = False
        Me.textFecha.ShowDropButton = False
        Me.textFecha.Size = New System.Drawing.Size(235, 21)
        Me.textFecha.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.textFecha.TabIndex = 577
        Me.textFecha.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'ComboFormaDeposito
        '
        Me.ComboFormaDeposito.BackColor = System.Drawing.Color.White
        Me.ComboFormaDeposito.BeforeTouchSize = New System.Drawing.Size(235, 24)
        Me.ComboFormaDeposito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboFormaDeposito.Font = New System.Drawing.Font("Tahoma", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboFormaDeposito.Location = New System.Drawing.Point(35, 180)
        Me.ComboFormaDeposito.MetroBorderColor = System.Drawing.Color.Silver
        Me.ComboFormaDeposito.Name = "ComboFormaDeposito"
        Me.ComboFormaDeposito.Size = New System.Drawing.Size(235, 24)
        Me.ComboFormaDeposito.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboFormaDeposito.TabIndex = 576
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(32, 159)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 14)
        Me.Label3.TabIndex = 575
        Me.Label3.Text = "Forma de depósito"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(32, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 14)
        Me.Label2.TabIndex = 574
        Me.Label2.Text = "Fecha de registro"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(32, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 14)
        Me.Label1.TabIndex = 573
        Me.Label1.Text = "Tipo anticipo"
        '
        'ComboTipoAnticipo
        '
        Me.ComboTipoAnticipo.BackColor = System.Drawing.Color.Transparent
        Me.ComboTipoAnticipo.BorderRadius = 5
        Me.ComboTipoAnticipo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ComboTipoAnticipo.ForeColor = System.Drawing.Color.White
        Me.ComboTipoAnticipo.Items = New String() {"Anticipo otorgado", "Anticipo recibido"}
        Me.ComboTipoAnticipo.Location = New System.Drawing.Point(35, 71)
        Me.ComboTipoAnticipo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboTipoAnticipo.Name = "ComboTipoAnticipo"
        Me.ComboTipoAnticipo.NomalColor = System.Drawing.SystemColors.HotTrack
        Me.ComboTipoAnticipo.onHoverColor = System.Drawing.SystemColors.HotTrack
        Me.ComboTipoAnticipo.selectedIndex = 1
        Me.ComboTipoAnticipo.Size = New System.Drawing.Size(235, 25)
        Me.ComboTipoAnticipo.TabIndex = 572
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft JhengHei UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label6.Location = New System.Drawing.Point(31, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(206, 20)
        Me.Label6.TabIndex = 571
        Me.Label6.Text = "Nuevo Anticipo Otorgado"
        '
        'TextRuc
        '
        Me.TextRuc.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextRuc.BeforeTouchSize = New System.Drawing.Size(194, 24)
        Me.TextRuc.BorderColor = System.Drawing.Color.Silver
        Me.TextRuc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextRuc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextRuc.CornerRadius = 4
        Me.TextRuc.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextRuc.Enabled = False
        Me.TextRuc.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextRuc.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextRuc.Location = New System.Drawing.Point(343, 369)
        Me.TextRuc.Metrocolor = System.Drawing.Color.Silver
        Me.TextRuc.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextRuc.Name = "TextRuc"
        Me.TextRuc.NearImage = CType(resources.GetObject("TextRuc.NearImage"), System.Drawing.Image)
        Me.TextRuc.Size = New System.Drawing.Size(136, 24)
        Me.TextRuc.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextRuc.TabIndex = 611
        Me.TextRuc.Visible = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(446, 353)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(33, 10)
        Me.ProgressBar1.TabIndex = 610
        Me.ProgressBar1.Visible = False
        '
        'TextBaseImponible
        '
        Me.TextBaseImponible.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextBaseImponible.BeforeTouchSize = New System.Drawing.Size(194, 24)
        Me.TextBaseImponible.BorderColor = System.Drawing.Color.Silver
        Me.TextBaseImponible.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBaseImponible.CornerRadius = 5
        Me.TextBaseImponible.CurrencySymbol = ""
        Me.TextBaseImponible.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextBaseImponible.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextBaseImponible.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBaseImponible.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextBaseImponible.Location = New System.Drawing.Point(191, 433)
        Me.TextBaseImponible.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextBaseImponible.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextBaseImponible.Name = "TextBaseImponible"
        Me.TextBaseImponible.NullString = ""
        Me.TextBaseImponible.PositiveColor = System.Drawing.SystemColors.HotTrack
        Me.TextBaseImponible.ReadOnly = True
        Me.TextBaseImponible.ReadOnlyBackColor = System.Drawing.Color.WhiteSmoke
        Me.TextBaseImponible.Size = New System.Drawing.Size(141, 23)
        Me.TextBaseImponible.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextBaseImponible.TabIndex = 609
        Me.TextBaseImponible.Text = "0.00"
        Me.TextBaseImponible.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(188, 414)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(82, 14)
        Me.Label11.TabIndex = 608
        Me.Label11.Text = "Base imponible"
        '
        'TextValorIva
        '
        Me.TextValorIva.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextValorIva.BeforeTouchSize = New System.Drawing.Size(194, 24)
        Me.TextValorIva.BorderColor = System.Drawing.Color.Silver
        Me.TextValorIva.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextValorIva.CornerRadius = 5
        Me.TextValorIva.CurrencySymbol = ""
        Me.TextValorIva.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextValorIva.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextValorIva.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextValorIva.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextValorIva.Location = New System.Drawing.Point(343, 433)
        Me.TextValorIva.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextValorIva.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextValorIva.Name = "TextValorIva"
        Me.TextValorIva.NullString = ""
        Me.TextValorIva.PositiveColor = System.Drawing.SystemColors.HotTrack
        Me.TextValorIva.ReadOnly = True
        Me.TextValorIva.ReadOnlyBackColor = System.Drawing.Color.WhiteSmoke
        Me.TextValorIva.Size = New System.Drawing.Size(141, 23)
        Me.TextValorIva.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextValorIva.TabIndex = 607
        Me.TextValorIva.Text = "0.00"
        Me.TextValorIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(342, 416)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(26, 14)
        Me.Label12.TabIndex = 606
        Me.Label12.Text = "IVA."
        '
        'ComboCuentaFinanciera
        '
        Me.ComboCuentaFinanciera.BackColor = System.Drawing.Color.White
        Me.ComboCuentaFinanciera.BeforeTouchSize = New System.Drawing.Size(302, 24)
        Me.ComboCuentaFinanciera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboCuentaFinanciera.Font = New System.Drawing.Font("Tahoma", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboCuentaFinanciera.Location = New System.Drawing.Point(35, 259)
        Me.ComboCuentaFinanciera.MetroBorderColor = System.Drawing.Color.Silver
        Me.ComboCuentaFinanciera.Name = "ComboCuentaFinanciera"
        Me.ComboCuentaFinanciera.Size = New System.Drawing.Size(302, 24)
        Me.ComboCuentaFinanciera.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboCuentaFinanciera.TabIndex = 605
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(31, 299)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(135, 19)
        Me.Label8.TabIndex = 604
        Me.Label8.Text = "Persona beneficiaria"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(31, 214)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(124, 19)
        Me.Label7.TabIndex = 603
        Me.Label7.Text = "Entidad Financiera"
        '
        'TextValorPrestamo
        '
        Me.TextValorPrestamo.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextValorPrestamo.BeforeTouchSize = New System.Drawing.Size(194, 24)
        Me.TextValorPrestamo.BorderColor = System.Drawing.Color.Silver
        Me.TextValorPrestamo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextValorPrestamo.CornerRadius = 5
        Me.TextValorPrestamo.CurrencySymbol = ""
        Me.TextValorPrestamo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextValorPrestamo.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextValorPrestamo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextValorPrestamo.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextValorPrestamo.Location = New System.Drawing.Point(35, 433)
        Me.TextValorPrestamo.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextValorPrestamo.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextValorPrestamo.Name = "TextValorPrestamo"
        Me.TextValorPrestamo.NullString = ""
        Me.TextValorPrestamo.PositiveColor = System.Drawing.SystemColors.HotTrack
        Me.TextValorPrestamo.ReadOnlyBackColor = System.Drawing.Color.WhiteSmoke
        Me.TextValorPrestamo.Size = New System.Drawing.Size(141, 23)
        Me.TextValorPrestamo.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextValorPrestamo.TabIndex = 602
        Me.TextValorPrestamo.Text = "0.00"
        Me.TextValorPrestamo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(36, 414)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 14)
        Me.Label5.TabIndex = 601
        Me.Label5.Text = "Valor del anticipo"
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
        Me.ButtonSalir.Location = New System.Drawing.Point(231, 496)
        Me.ButtonSalir.Name = "ButtonSalir"
        Me.ButtonSalir.Normalcolor = System.Drawing.Color.Gainsboro
        Me.ButtonSalir.OnHovercolor = System.Drawing.Color.Gainsboro
        Me.ButtonSalir.OnHoverTextColor = System.Drawing.Color.DimGray
        Me.ButtonSalir.selected = False
        Me.ButtonSalir.Size = New System.Drawing.Size(121, 40)
        Me.ButtonSalir.TabIndex = 600
        Me.ButtonSalir.Text = "    Cancelar"
        Me.ButtonSalir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ButtonSalir.Textcolor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonSalir.TextFont = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'TextNroCuenta
        '
        Me.TextNroCuenta.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextNroCuenta.BeforeTouchSize = New System.Drawing.Size(194, 24)
        Me.TextNroCuenta.BorderColor = System.Drawing.Color.Silver
        Me.TextNroCuenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextNroCuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNroCuenta.CornerRadius = 4
        Me.TextNroCuenta.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextNroCuenta.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNroCuenta.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextNroCuenta.Location = New System.Drawing.Point(350, 207)
        Me.TextNroCuenta.Metrocolor = System.Drawing.Color.Silver
        Me.TextNroCuenta.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextNroCuenta.Name = "TextNroCuenta"
        Me.TextNroCuenta.NearImage = CType(resources.GetObject("TextNroCuenta.NearImage"), System.Drawing.Image)
        Me.TextNroCuenta.Size = New System.Drawing.Size(136, 24)
        Me.TextNroCuenta.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextNroCuenta.TabIndex = 599
        Me.TextNroCuenta.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(32, 239)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 14)
        Me.Label4.TabIndex = 598
        Me.Label4.Text = "Cuenta bancaria"
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
        Me.ButtonGrabar.Location = New System.Drawing.Point(358, 496)
        Me.ButtonGrabar.Name = "ButtonGrabar"
        Me.ButtonGrabar.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.ButtonGrabar.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.ButtonGrabar.OnHoverTextColor = System.Drawing.Color.White
        Me.ButtonGrabar.selected = False
        Me.ButtonGrabar.Size = New System.Drawing.Size(121, 40)
        Me.ButtonGrabar.TabIndex = 597
        Me.ButtonGrabar.Text = "Guardar"
        Me.ButtonGrabar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ButtonGrabar.Textcolor = System.Drawing.Color.White
        Me.ButtonGrabar.TextFont = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(32, 322)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(67, 14)
        Me.Label14.TabIndex = 596
        Me.Label14.Text = "Razón social"
        '
        'TextPersona
        '
        Me.TextPersona.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextPersona.BeforeTouchSize = New System.Drawing.Size(194, 24)
        Me.TextPersona.BorderColor = System.Drawing.SystemColors.MenuHighlight
        Me.TextPersona.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextPersona.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextPersona.CornerRadius = 4
        Me.TextPersona.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextPersona.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextPersona.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextPersona.Location = New System.Drawing.Point(35, 339)
        Me.TextPersona.Metrocolor = System.Drawing.SystemColors.MenuHighlight
        Me.TextPersona.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextPersona.Name = "TextPersona"
        Me.TextPersona.NearImage = CType(resources.GetObject("TextPersona.NearImage"), System.Drawing.Image)
        Me.TextPersona.Size = New System.Drawing.Size(444, 24)
        Me.TextPersona.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextPersona.TabIndex = 595
        '
        'pcLikeCategoria
        '
        Me.pcLikeCategoria.Controls.Add(Me.LsvProveedor)
        Me.pcLikeCategoria.Location = New System.Drawing.Point(572, 114)
        Me.pcLikeCategoria.Name = "pcLikeCategoria"
        Me.pcLikeCategoria.Size = New System.Drawing.Size(282, 128)
        Me.pcLikeCategoria.TabIndex = 612
        '
        'LsvProveedor
        '
        Me.LsvProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LsvProveedor.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colID, Me.colCliente, Me.colRUC, Me.colTipoDoc})
        Me.LsvProveedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LsvProveedor.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LsvProveedor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(187, Byte), Integer))
        Me.LsvProveedor.FullRowSelect = True
        Me.LsvProveedor.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.LsvProveedor.HideSelection = False
        Me.LsvProveedor.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1})
        Me.LsvProveedor.Location = New System.Drawing.Point(0, 0)
        Me.LsvProveedor.MultiSelect = False
        Me.LsvProveedor.Name = "LsvProveedor"
        Me.LsvProveedor.Size = New System.Drawing.Size(282, 128)
        Me.LsvProveedor.TabIndex = 1
        Me.LsvProveedor.UseCompatibleStateImageBehavior = False
        Me.LsvProveedor.View = System.Windows.Forms.View.Details
        '
        'colID
        '
        Me.colID.Text = "ID"
        Me.colID.Width = 0
        '
        'colCliente
        '
        Me.colCliente.Text = "Cliente"
        Me.colCliente.Width = 219
        '
        'colRUC
        '
        Me.colRUC.Text = "RUC"
        '
        'txtSaldoCaja
        '
        Me.txtSaldoCaja.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtSaldoCaja.BeforeTouchSize = New System.Drawing.Size(194, 24)
        Me.txtSaldoCaja.BorderColor = System.Drawing.Color.Silver
        Me.txtSaldoCaja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSaldoCaja.CornerRadius = 5
        Me.txtSaldoCaja.CurrencySymbol = ""
        Me.txtSaldoCaja.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSaldoCaja.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtSaldoCaja.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSaldoCaja.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtSaldoCaja.Location = New System.Drawing.Point(345, 259)
        Me.txtSaldoCaja.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtSaldoCaja.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtSaldoCaja.Name = "txtSaldoCaja"
        Me.txtSaldoCaja.NullString = ""
        Me.txtSaldoCaja.PositiveColor = System.Drawing.SystemColors.HotTrack
        Me.txtSaldoCaja.ReadOnlyBackColor = System.Drawing.Color.WhiteSmoke
        Me.txtSaldoCaja.Size = New System.Drawing.Size(141, 23)
        Me.txtSaldoCaja.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtSaldoCaja.TabIndex = 613
        Me.txtSaldoCaja.Text = "0.00"
        Me.txtSaldoCaja.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(404, 234)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(75, 19)
        Me.Label13.TabIndex = 614
        Me.Label13.Text = "Saldo Caja"
        '
        'FormCrearAnticipoOtorgado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(508, 539)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtSaldoCaja)
        Me.Controls.Add(Me.pcLikeCategoria)
        Me.Controls.Add(Me.TextRuc)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.TextBaseImponible)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TextValorIva)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.ComboCuentaFinanciera)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TextValorPrestamo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ButtonSalir)
        Me.Controls.Add(Me.TextNroCuenta)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ButtonGrabar)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.TextPersona)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TextNumeroDocumento)
        Me.Controls.Add(Me.ComboTipoDoc)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.textFecha)
        Me.Controls.Add(Me.ComboFormaDeposito)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboTipoAnticipo)
        Me.Controls.Add(Me.Label6)
        Me.Name = "FormCrearAnticipoOtorgado"
        Me.ShowIcon = False
        CType(Me.TextNumeroDocumento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.textFecha.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.textFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboFormaDeposito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextRuc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBaseImponible, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextValorIva, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboCuentaFinanciera, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextValorPrestamo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextNroCuenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextPersona, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pcLikeCategoria.ResumeLayout(False)
        CType(Me.txtSaldoCaja, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label10 As Label
    Friend WithEvents TextNumeroDocumento As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents ComboTipoDoc As Bunifu.Framework.UI.BunifuDropdown
    Friend WithEvents Label9 As Label
    Friend WithEvents textFecha As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents ComboFormaDeposito As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents ComboTipoAnticipo As Bunifu.Framework.UI.BunifuDropdown
    Friend WithEvents Label6 As Label
    Friend WithEvents TextRuc As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents TextBaseImponible As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents TextValorIva As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents ComboCuentaFinanciera As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents TextValorPrestamo As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents ButtonSalir As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents TextNroCuenta As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label4 As Label
    Friend WithEvents ButtonGrabar As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents Label14 As Label
    Friend WithEvents TextPersona As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Private WithEvents pcLikeCategoria As PopupControlContainer
    Friend WithEvents LsvProveedor As ListView
    Friend WithEvents colID As ColumnHeader
    Friend WithEvents colCliente As ColumnHeader
    Friend WithEvents colRUC As ColumnHeader
    Friend WithEvents colTipoDoc As ColumnHeader
    Friend WithEvents txtSaldoCaja As Tools.CurrencyTextBox
    Friend WithEvents Label13 As Label
End Class

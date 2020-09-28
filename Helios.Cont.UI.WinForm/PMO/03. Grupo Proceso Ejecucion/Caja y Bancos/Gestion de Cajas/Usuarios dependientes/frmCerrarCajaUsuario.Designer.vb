<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCerrarCajaUsuario
    Inherits Helios.Cont.Presentation.WinForm.frmMaster

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCerrarCajaUsuario))
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtfecCierre = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btGrabar = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.txtfecApertura = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtUsuariocaja = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSaldoME = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtVentasME = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtFondoInicioME = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtSaldoMN = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtVentas = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtFondoInicioMN = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboMoneda = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.cboDepositoHijo = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtfecCierre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtfecCierre.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtfecApertura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUsuariocaja, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSaldoME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVentasME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFondoInicioME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSaldoMN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVentas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFondoInicioMN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDepositoHijo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtfecCierre)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btGrabar)
        Me.GroupBox1.Controls.Add(Me.txtfecApertura)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtUsuariocaja)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtSaldoME)
        Me.GroupBox1.Controls.Add(Me.txtVentasME)
        Me.GroupBox1.Controls.Add(Me.txtFondoInicioME)
        Me.GroupBox1.Controls.Add(Me.txtSaldoMN)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtVentas)
        Me.GroupBox1.Controls.Add(Me.txtFondoInicioMN)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI Light", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(10, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(494, 257)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "CERRAR CAJA"
        '
        'txtfecCierre
        '
        Me.txtfecCierre.BackColor = System.Drawing.Color.White
        Me.txtfecCierre.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtfecCierre.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtfecCierre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtfecCierre.Calendar.AllowMultipleSelection = False
        Me.txtfecCierre.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtfecCierre.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtfecCierre.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtfecCierre.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtfecCierre.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtfecCierre.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtfecCierre.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtfecCierre.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfecCierre.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtfecCierre.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtfecCierre.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtfecCierre.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtfecCierre.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtfecCierre.Calendar.Iso8601CalenderFormat = False
        Me.txtfecCierre.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtfecCierre.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtfecCierre.Calendar.Name = "monthCalendar"
        Me.txtfecCierre.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtfecCierre.Calendar.SelectedDates = New Date(-1) {}
        Me.txtfecCierre.Calendar.Size = New System.Drawing.Size(181, 174)
        Me.txtfecCierre.Calendar.SizeToFit = True
        Me.txtfecCierre.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtfecCierre.Calendar.TabIndex = 0
        Me.txtfecCierre.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtfecCierre.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtfecCierre.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtfecCierre.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtfecCierre.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtfecCierre.Calendar.NoneButton.IsBackStageButton = False
        Me.txtfecCierre.Calendar.NoneButton.Location = New System.Drawing.Point(109, 0)
        Me.txtfecCierre.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtfecCierre.Calendar.NoneButton.Text = "None"
        Me.txtfecCierre.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtfecCierre.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtfecCierre.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtfecCierre.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtfecCierre.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtfecCierre.Calendar.TodayButton.IsBackStageButton = False
        Me.txtfecCierre.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtfecCierre.Calendar.TodayButton.Size = New System.Drawing.Size(109, 20)
        Me.txtfecCierre.Calendar.TodayButton.Text = "Today"
        Me.txtfecCierre.Calendar.TodayButton.UseVisualStyle = True
        Me.txtfecCierre.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfecCierre.CalendarForeColor = System.Drawing.SystemColors.ControlText
        Me.txtfecCierre.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtfecCierre.Checked = False
        Me.txtfecCierre.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtfecCierre.CustomFormat = "dd/MM/yyyy HH:mm:ss tt"
        Me.txtfecCierre.DropDownImage = Nothing
        Me.txtfecCierre.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtfecCierre.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtfecCierre.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtfecCierre.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfecCierre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtfecCierre.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtfecCierre.Location = New System.Drawing.Point(207, 93)
        Me.txtfecCierre.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtfecCierre.MinValue = New Date(CType(0, Long))
        Me.txtfecCierre.Name = "txtfecCierre"
        Me.txtfecCierre.ShowCheckBox = False
        Me.txtfecCierre.Size = New System.Drawing.Size(183, 20)
        Me.txtfecCierre.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtfecCierre.TabIndex = 525
        Me.txtfecCierre.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(202, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 13)
        Me.Label1.TabIndex = 524
        Me.Label1.Text = "FECHA CIERRE"
        '
        'btGrabar
        '
        Me.btGrabar.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btGrabar.BackColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.btGrabar.BeforeTouchSize = New System.Drawing.Size(141, 32)
        Me.btGrabar.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btGrabar.ForeColor = System.Drawing.Color.White
        Me.btGrabar.Image = CType(resources.GetObject("btGrabar.Image"), System.Drawing.Image)
        Me.btGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btGrabar.IsBackStageButton = False
        Me.btGrabar.Location = New System.Drawing.Point(321, 209)
        Me.btGrabar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btGrabar.Name = "btGrabar"
        Me.btGrabar.Size = New System.Drawing.Size(141, 32)
        Me.btGrabar.TabIndex = 523
        Me.btGrabar.Text = "CERRAR CAJA"
        Me.btGrabar.UseVisualStyle = True
        '
        'txtfecApertura
        '
        Me.txtfecApertura.BackColor = System.Drawing.Color.White
        Me.txtfecApertura.BeforeTouchSize = New System.Drawing.Size(141, 20)
        Me.txtfecApertura.BorderColor = System.Drawing.Color.Gray
        Me.txtfecApertura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtfecApertura.CornerRadius = 5
        Me.txtfecApertura.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtfecApertura.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtfecApertura.Location = New System.Drawing.Point(25, 93)
        Me.txtfecApertura.Metrocolor = System.Drawing.Color.Gray
        Me.txtfecApertura.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtfecApertura.Name = "txtfecApertura"
        Me.txtfecApertura.NearImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources._Date
        Me.txtfecApertura.ReadOnly = True
        Me.txtfecApertura.Size = New System.Drawing.Size(176, 22)
        Me.txtfecApertura.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtfecApertura.TabIndex = 521
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(22, 75)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(81, 13)
        Me.Label7.TabIndex = 520
        Me.Label7.Text = "FEC. APERTURA"
        '
        'txtUsuariocaja
        '
        Me.txtUsuariocaja.BackColor = System.Drawing.Color.White
        Me.txtUsuariocaja.BeforeTouchSize = New System.Drawing.Size(141, 20)
        Me.txtUsuariocaja.BorderColor = System.Drawing.Color.Gray
        Me.txtUsuariocaja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUsuariocaja.CornerRadius = 5
        Me.txtUsuariocaja.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtUsuariocaja.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtUsuariocaja.Location = New System.Drawing.Point(25, 45)
        Me.txtUsuariocaja.Metrocolor = System.Drawing.Color.Gray
        Me.txtUsuariocaja.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtUsuariocaja.Name = "txtUsuariocaja"
        Me.txtUsuariocaja.NearImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources._003
        Me.txtUsuariocaja.ReadOnly = True
        Me.txtUsuariocaja.Size = New System.Drawing.Size(365, 22)
        Me.txtUsuariocaja.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtUsuariocaja.TabIndex = 517
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(22, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 13)
        Me.Label5.TabIndex = 516
        Me.Label5.Text = "USUARIO - CAJA"
        '
        'txtSaldoME
        '
        Me.txtSaldoME.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtSaldoME.BeforeTouchSize = New System.Drawing.Size(141, 20)
        Me.txtSaldoME.BorderColor = System.Drawing.Color.Gray
        Me.txtSaldoME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSaldoME.CornerRadius = 5
        Me.txtSaldoME.CurrencySymbol = "ME. "
        Me.txtSaldoME.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSaldoME.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtSaldoME.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSaldoME.ForeColor = System.Drawing.Color.Black
        Me.txtSaldoME.Location = New System.Drawing.Point(321, 171)
        Me.txtSaldoME.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtSaldoME.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtSaldoME.Name = "txtSaldoME"
        Me.txtSaldoME.NullString = ""
        Me.txtSaldoME.PositiveColor = System.Drawing.Color.Black
        Me.txtSaldoME.ReadOnly = True
        Me.txtSaldoME.ReadOnlyBackColor = System.Drawing.Color.Honeydew
        Me.txtSaldoME.Size = New System.Drawing.Size(141, 20)
        Me.txtSaldoME.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtSaldoME.TabIndex = 515
        Me.txtSaldoME.Text = "ME. 0.00"
        '
        'txtVentasME
        '
        Me.txtVentasME.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtVentasME.BeforeTouchSize = New System.Drawing.Size(141, 20)
        Me.txtVentasME.BorderColor = System.Drawing.Color.Gray
        Me.txtVentasME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVentasME.CornerRadius = 5
        Me.txtVentasME.CurrencySymbol = "ME. "
        Me.txtVentasME.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtVentasME.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtVentasME.ForeColor = System.Drawing.Color.Black
        Me.txtVentasME.Location = New System.Drawing.Point(174, 171)
        Me.txtVentasME.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtVentasME.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtVentasME.Name = "txtVentasME"
        Me.txtVentasME.NullString = ""
        Me.txtVentasME.PositiveColor = System.Drawing.Color.Black
        Me.txtVentasME.ReadOnly = True
        Me.txtVentasME.ReadOnlyBackColor = System.Drawing.Color.Honeydew
        Me.txtVentasME.Size = New System.Drawing.Size(141, 22)
        Me.txtVentasME.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtVentasME.TabIndex = 514
        Me.txtVentasME.Text = "ME. 0.00"
        '
        'txtFondoInicioME
        '
        Me.txtFondoInicioME.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtFondoInicioME.BeforeTouchSize = New System.Drawing.Size(141, 20)
        Me.txtFondoInicioME.BorderColor = System.Drawing.Color.Gray
        Me.txtFondoInicioME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFondoInicioME.CornerRadius = 5
        Me.txtFondoInicioME.CurrencySymbol = "ME. "
        Me.txtFondoInicioME.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFondoInicioME.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtFondoInicioME.ForeColor = System.Drawing.Color.Black
        Me.txtFondoInicioME.Location = New System.Drawing.Point(25, 171)
        Me.txtFondoInicioME.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtFondoInicioME.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtFondoInicioME.Name = "txtFondoInicioME"
        Me.txtFondoInicioME.NullString = ""
        Me.txtFondoInicioME.PositiveColor = System.Drawing.Color.Black
        Me.txtFondoInicioME.ReadOnly = True
        Me.txtFondoInicioME.ReadOnlyBackColor = System.Drawing.Color.Honeydew
        Me.txtFondoInicioME.Size = New System.Drawing.Size(141, 22)
        Me.txtFondoInicioME.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtFondoInicioME.TabIndex = 513
        Me.txtFondoInicioME.Text = "ME. 0.00"
        '
        'txtSaldoMN
        '
        Me.txtSaldoMN.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtSaldoMN.BeforeTouchSize = New System.Drawing.Size(141, 20)
        Me.txtSaldoMN.BorderColor = System.Drawing.Color.Gray
        Me.txtSaldoMN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSaldoMN.CornerRadius = 5
        Me.txtSaldoMN.CurrencySymbol = "MN. "
        Me.txtSaldoMN.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSaldoMN.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtSaldoMN.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSaldoMN.ForeColor = System.Drawing.Color.Black
        Me.txtSaldoMN.Location = New System.Drawing.Point(321, 143)
        Me.txtSaldoMN.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtSaldoMN.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtSaldoMN.Name = "txtSaldoMN"
        Me.txtSaldoMN.NullString = ""
        Me.txtSaldoMN.PositiveColor = System.Drawing.Color.Black
        Me.txtSaldoMN.ReadOnly = True
        Me.txtSaldoMN.ReadOnlyBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtSaldoMN.Size = New System.Drawing.Size(141, 20)
        Me.txtSaldoMN.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtSaldoMN.TabIndex = 512
        Me.txtSaldoMN.Text = "MN. 0.00"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(318, 124)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 511
        Me.Label4.Text = "SALDO"
        '
        'txtVentas
        '
        Me.txtVentas.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtVentas.BeforeTouchSize = New System.Drawing.Size(141, 20)
        Me.txtVentas.BorderColor = System.Drawing.Color.Gray
        Me.txtVentas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVentas.CornerRadius = 5
        Me.txtVentas.CurrencySymbol = "MN. "
        Me.txtVentas.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtVentas.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtVentas.ForeColor = System.Drawing.Color.Black
        Me.txtVentas.Location = New System.Drawing.Point(174, 143)
        Me.txtVentas.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtVentas.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtVentas.Name = "txtVentas"
        Me.txtVentas.NullString = ""
        Me.txtVentas.PositiveColor = System.Drawing.Color.Black
        Me.txtVentas.ReadOnly = True
        Me.txtVentas.ReadOnlyBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtVentas.Size = New System.Drawing.Size(141, 22)
        Me.txtVentas.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtVentas.TabIndex = 510
        Me.txtVentas.Text = "MN. 0.00"
        '
        'txtFondoInicioMN
        '
        Me.txtFondoInicioMN.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.txtFondoInicioMN.BeforeTouchSize = New System.Drawing.Size(141, 20)
        Me.txtFondoInicioMN.BorderColor = System.Drawing.Color.Gray
        Me.txtFondoInicioMN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFondoInicioMN.CornerRadius = 5
        Me.txtFondoInicioMN.CurrencySymbol = "MN. "
        Me.txtFondoInicioMN.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtFondoInicioMN.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtFondoInicioMN.ForeColor = System.Drawing.Color.Black
        Me.txtFondoInicioMN.Location = New System.Drawing.Point(25, 143)
        Me.txtFondoInicioMN.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtFondoInicioMN.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtFondoInicioMN.Name = "txtFondoInicioMN"
        Me.txtFondoInicioMN.NullString = ""
        Me.txtFondoInicioMN.PositiveColor = System.Drawing.Color.Black
        Me.txtFondoInicioMN.ReadOnly = True
        Me.txtFondoInicioMN.ReadOnlyBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtFondoInicioMN.Size = New System.Drawing.Size(141, 22)
        Me.txtFondoInicioMN.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtFondoInicioMN.TabIndex = 509
        Me.txtFondoInicioMN.Text = "MN. 0.00"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(171, 124)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "VENTAS"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 124)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "FONDO INICIO"
        '
        'cboMoneda
        '
        Me.cboMoneda.BackColor = System.Drawing.Color.White
        Me.cboMoneda.BeforeTouchSize = New System.Drawing.Size(129, 21)
        Me.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMoneda.Enabled = False
        Me.cboMoneda.FlatBorderColor = System.Drawing.SystemColors.AppWorkspace
        Me.cboMoneda.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMoneda.Location = New System.Drawing.Point(300, 44)
        Me.cboMoneda.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.cboMoneda.MetroColor = System.Drawing.Color.Gray
        Me.cboMoneda.Name = "cboMoneda"
        Me.cboMoneda.Size = New System.Drawing.Size(129, 21)
        Me.cboMoneda.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboMoneda.TabIndex = 401
        '
        'cboDepositoHijo
        '
        Me.cboDepositoHijo.BackColor = System.Drawing.Color.White
        Me.cboDepositoHijo.BeforeTouchSize = New System.Drawing.Size(273, 21)
        Me.cboDepositoHijo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDepositoHijo.FlatBorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cboDepositoHijo.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDepositoHijo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cboDepositoHijo.Location = New System.Drawing.Point(21, 44)
        Me.cboDepositoHijo.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.cboDepositoHijo.MetroColor = System.Drawing.Color.Gray
        Me.cboDepositoHijo.Name = "cboDepositoHijo"
        Me.cboDepositoHijo.Size = New System.Drawing.Size(273, 21)
        Me.cboDepositoHijo.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboDepositoHijo.TabIndex = 500
        '
        'frmCerrarCajaUsuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.Color.WhiteSmoke
        Me.CaptionBarHeight = 50
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(15, 8)
        CaptionImage1.Name = "CaptionImage1"
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        CaptionLabel1.Location = New System.Drawing.Point(50, 9)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Text = "Resumen Venta"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(515, 275)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCerrarCajaUsuario"
        Me.ShowIcon = False
        Me.Text = ""
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtfecCierre.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtfecCierre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtfecApertura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUsuariocaja, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSaldoME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVentasME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFondoInicioME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSaldoMN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVentas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFondoInicioMN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDepositoHijo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSaldoME As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtVentasME As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtFondoInicioME As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtSaldoMN As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtVentas As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtFondoInicioMN As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtUsuariocaja As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtfecApertura As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboMoneda As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents cboDepositoHijo As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents btGrabar As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtfecCierre As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
End Class

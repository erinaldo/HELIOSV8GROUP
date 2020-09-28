<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPagoMembresia
    Inherits frmMaster

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPagoMembresia))
        Dim BannerTextInfo1 As Syncfusion.Windows.Forms.BannerTextInfo = New Syncfusion.Windows.Forms.BannerTextInfo()
        Dim BannerTextInfo2 As Syncfusion.Windows.Forms.BannerTextInfo = New Syncfusion.Windows.Forms.BannerTextInfo()
        Dim BannerTextInfo3 As Syncfusion.Windows.Forms.BannerTextInfo = New Syncfusion.Windows.Forms.BannerTextInfo()
        Dim BannerTextInfo4 As Syncfusion.Windows.Forms.BannerTextInfo = New Syncfusion.Windows.Forms.BannerTextInfo()
        Dim BannerTextInfo5 As Syncfusion.Windows.Forms.BannerTextInfo = New Syncfusion.Windows.Forms.BannerTextInfo()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PanelError = New System.Windows.Forms.Panel()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.txtTipoEntidad = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtNroDocEntidad = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtEntidad = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtAnioCompra = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.cboMesCompra = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.txtDia = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.txtPeriodo = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtSaldoPorPagar = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblMonedaCobro = New System.Windows.Forms.Label()
        Me.SaldoEFME = New Syncfusion.Windows.Forms.Tools.DoubleTextBox()
        Me.SaldoEFMN = New Syncfusion.Windows.Forms.Tools.DoubleTextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboTipoDoc = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.txtNumOper = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.cboEntidades = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblMoneda = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GradientPanel7 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.txtPagoAcuenta = New System.Windows.Forms.LinkLabel()
        Me.BannerTextProvider1 = New Syncfusion.Windows.Forms.BannerTextProvider(Me.components)
        Me.txtCuentaCorriente = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtCF_tipo = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtCF_name = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtCF_moneda = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtPagoMN = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.txtTipoCambio = New Syncfusion.Windows.Forms.Tools.DoubleTextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtPagoME = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.dgvDetalleItems = New System.Windows.Forms.DataGridView()
        Me.colId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNameItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPrecUnit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPagoMN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPagoME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSaldoMN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSaldoME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSecuencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TXTVENTA = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GradientPanel5 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv4 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv5 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.txtCF_cuentaContable = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.PanelError.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoEntidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNroDocEntidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEntidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAnioCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboMesCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDia.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPeriodo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPeriodo.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSaldoPorPagar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SaldoEFME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SaldoEFMN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTipoDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumOper, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboEntidades, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel7.SuspendLayout()
        CType(Me.txtCuentaCorriente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCF_tipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCF_name, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCF_moneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPagoMN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoCambio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPagoME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDetalleItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TXTVENTA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.GradientPanel5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel5.SuspendLayout()
        CType(Me.txtCF_cuentaContable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelError
        '
        Me.PanelError.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.PanelError.Controls.Add(Me.lblEstado)
        Me.PanelError.Controls.Add(Me.PictureBox3)
        Me.PanelError.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelError.Location = New System.Drawing.Point(0, 0)
        Me.PanelError.Name = "PanelError"
        Me.PanelError.Size = New System.Drawing.Size(745, 22)
        Me.PanelError.TabIndex = 413
        Me.PanelError.Visible = False
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.BackColor = System.Drawing.Color.Transparent
        Me.lblEstado.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblEstado.Location = New System.Drawing.Point(8, 4)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(76, 13)
        Me.lblEstado.TabIndex = 289
        Me.lblEstado.Text = "Mensaje error"
        '
        'PictureBox3
        '
        Me.PictureBox3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox3.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(726, 0)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(19, 22)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 288
        Me.PictureBox3.TabStop = False
        '
        'txtTipoEntidad
        '
        Me.txtTipoEntidad.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtTipoEntidad.BeforeTouchSize = New System.Drawing.Size(114, 22)
        Me.txtTipoEntidad.BorderColor = System.Drawing.Color.DarkGray
        Me.txtTipoEntidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTipoEntidad.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTipoEntidad.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoEntidad.Location = New System.Drawing.Point(500, 53)
        Me.txtTipoEntidad.MaxLength = 20
        Me.txtTipoEntidad.Metrocolor = System.Drawing.Color.DarkGray
        Me.txtTipoEntidad.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtTipoEntidad.Name = "txtTipoEntidad"
        Me.txtTipoEntidad.ReadOnly = True
        Me.txtTipoEntidad.Size = New System.Drawing.Size(53, 22)
        Me.txtTipoEntidad.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtTipoEntidad.TabIndex = 538
        Me.txtTipoEntidad.Visible = False
        '
        'txtNroDocEntidad
        '
        Me.txtNroDocEntidad.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtNroDocEntidad.BeforeTouchSize = New System.Drawing.Size(114, 22)
        Me.txtNroDocEntidad.BorderColor = System.Drawing.Color.DarkGray
        Me.txtNroDocEntidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNroDocEntidad.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNroDocEntidad.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNroDocEntidad.Location = New System.Drawing.Point(385, 53)
        Me.txtNroDocEntidad.MaxLength = 20
        Me.txtNroDocEntidad.Metrocolor = System.Drawing.Color.DarkGray
        Me.txtNroDocEntidad.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtNroDocEntidad.Name = "txtNroDocEntidad"
        Me.txtNroDocEntidad.ReadOnly = True
        Me.txtNroDocEntidad.Size = New System.Drawing.Size(112, 22)
        Me.txtNroDocEntidad.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtNroDocEntidad.TabIndex = 537
        '
        'txtEntidad
        '
        Me.txtEntidad.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtEntidad.BeforeTouchSize = New System.Drawing.Size(114, 22)
        Me.txtEntidad.BorderColor = System.Drawing.Color.DarkGray
        Me.txtEntidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEntidad.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtEntidad.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEntidad.Location = New System.Drawing.Point(28, 53)
        Me.txtEntidad.MaxLength = 20
        Me.txtEntidad.Metrocolor = System.Drawing.Color.DarkGray
        Me.txtEntidad.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtEntidad.Name = "txtEntidad"
        Me.txtEntidad.NearImage = CType(resources.GetObject("txtEntidad.NearImage"), System.Drawing.Image)
        Me.txtEntidad.ReadOnly = True
        Me.txtEntidad.Size = New System.Drawing.Size(353, 22)
        Me.txtEntidad.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtEntidad.TabIndex = 536
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(25, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 14)
        Me.Label1.TabIndex = 539
        Me.Label1.Text = "Información del cliente"
        '
        'txtAnioCompra
        '
        Me.txtAnioCompra.BackColor = System.Drawing.Color.White
        Me.txtAnioCompra.BeforeTouchSize = New System.Drawing.Size(114, 22)
        Me.txtAnioCompra.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtAnioCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAnioCompra.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAnioCompra.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtAnioCompra.Location = New System.Drawing.Point(212, 272)
        Me.txtAnioCompra.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtAnioCompra.Name = "txtAnioCompra"
        Me.txtAnioCompra.ReadOnly = True
        Me.txtAnioCompra.Size = New System.Drawing.Size(56, 22)
        Me.txtAnioCompra.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtAnioCompra.TabIndex = 548
        Me.txtAnioCompra.Text = "2016"
        Me.txtAnioCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cboMesCompra
        '
        Me.cboMesCompra.BackColor = System.Drawing.Color.White
        Me.cboMesCompra.BeforeTouchSize = New System.Drawing.Size(127, 21)
        Me.cboMesCompra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMesCompra.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMesCompra.Location = New System.Drawing.Point(28, 273)
        Me.cboMesCompra.Name = "cboMesCompra"
        Me.cboMesCompra.Size = New System.Drawing.Size(127, 21)
        Me.cboMesCompra.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboMesCompra.TabIndex = 547
        '
        'txtDia
        '
        Me.txtDia.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
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
        Me.txtDia.Calendar.TodayButton.Size = New System.Drawing.Size(0, 20)
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
        Me.txtDia.Location = New System.Drawing.Point(159, 274)
        Me.txtDia.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtDia.MinValue = New Date(CType(0, Long))
        Me.txtDia.Name = "txtDia"
        Me.txtDia.ShowCheckBox = False
        Me.txtDia.ShowDropButton = False
        Me.txtDia.ShowUpDown = True
        Me.txtDia.Size = New System.Drawing.Size(50, 20)
        Me.txtDia.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtDia.TabIndex = 546
        Me.txtDia.Value = New Date(2016, 1, 1, 11, 17, 0, 0)
        '
        'txtPeriodo
        '
        Me.txtPeriodo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtPeriodo.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtPeriodo.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtPeriodo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtPeriodo.Calendar.AllowMultipleSelection = False
        Me.txtPeriodo.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtPeriodo.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPeriodo.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtPeriodo.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtPeriodo.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtPeriodo.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtPeriodo.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPeriodo.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPeriodo.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPeriodo.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtPeriodo.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtPeriodo.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtPeriodo.Calendar.HeadForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPeriodo.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtPeriodo.Calendar.Iso8601CalenderFormat = False
        Me.txtPeriodo.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtPeriodo.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtPeriodo.Calendar.Name = "monthCalendar"
        Me.txtPeriodo.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtPeriodo.Calendar.SelectedDates = New Date(-1) {}
        Me.txtPeriodo.Calendar.Size = New System.Drawing.Size(83, 174)
        Me.txtPeriodo.Calendar.SizeToFit = True
        Me.txtPeriodo.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtPeriodo.Calendar.TabIndex = 0
        Me.txtPeriodo.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtPeriodo.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtPeriodo.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtPeriodo.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtPeriodo.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtPeriodo.Calendar.NoneButton.IsBackStageButton = False
        Me.txtPeriodo.Calendar.NoneButton.Location = New System.Drawing.Point(11, 0)
        Me.txtPeriodo.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtPeriodo.Calendar.NoneButton.Text = "None"
        Me.txtPeriodo.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtPeriodo.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtPeriodo.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtPeriodo.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtPeriodo.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtPeriodo.Calendar.TodayButton.IsBackStageButton = False
        Me.txtPeriodo.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtPeriodo.Calendar.TodayButton.Size = New System.Drawing.Size(11, 20)
        Me.txtPeriodo.Calendar.TodayButton.Text = "Today"
        Me.txtPeriodo.Calendar.TodayButton.UseVisualStyle = True
        Me.txtPeriodo.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPeriodo.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtPeriodo.CalendarTitleForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPeriodo.Checked = False
        Me.txtPeriodo.CustomFormat = "MM/yyyy"
        Me.txtPeriodo.DropDownImage = Nothing
        Me.txtPeriodo.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtPeriodo.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtPeriodo.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtPeriodo.Enabled = False
        Me.txtPeriodo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtPeriodo.Location = New System.Drawing.Point(274, 273)
        Me.txtPeriodo.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtPeriodo.MinValue = New Date(CType(0, Long))
        Me.txtPeriodo.Name = "txtPeriodo"
        Me.txtPeriodo.ShowCheckBox = False
        Me.txtPeriodo.ShowDropButton = False
        Me.txtPeriodo.ShowUpDown = True
        Me.txtPeriodo.Size = New System.Drawing.Size(87, 20)
        Me.txtPeriodo.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtPeriodo.TabIndex = 545
        Me.txtPeriodo.Value = New Date(2016, 3, 2, 12, 27, 4, 289)
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(270, 248)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(44, 14)
        Me.Label18.TabIndex = 544
        Me.Label18.Text = "Período"
        '
        'txtSaldoPorPagar
        '
        Me.txtSaldoPorPagar.BackGroundColor = System.Drawing.SystemColors.Window
        Me.txtSaldoPorPagar.BeforeTouchSize = New System.Drawing.Size(114, 22)
        Me.txtSaldoPorPagar.BorderColor = System.Drawing.Color.MediumSeaGreen
        Me.txtSaldoPorPagar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSaldoPorPagar.CurrencySymbol = ""
        Me.txtSaldoPorPagar.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSaldoPorPagar.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtSaldoPorPagar.Font = New System.Drawing.Font("Ebrima", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSaldoPorPagar.ForeColor = System.Drawing.Color.White
        Me.txtSaldoPorPagar.Location = New System.Drawing.Point(298, 103)
        Me.txtSaldoPorPagar.Metrocolor = System.Drawing.Color.MediumSeaGreen
        Me.txtSaldoPorPagar.Name = "txtSaldoPorPagar"
        Me.txtSaldoPorPagar.NullString = ""
        Me.txtSaldoPorPagar.PositiveColor = System.Drawing.Color.White
        Me.txtSaldoPorPagar.ReadOnly = True
        Me.txtSaldoPorPagar.ReadOnlyBackColor = System.Drawing.Color.MediumSeaGreen
        Me.txtSaldoPorPagar.Size = New System.Drawing.Size(134, 23)
        Me.txtSaldoPorPagar.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtSaldoPorPagar.TabIndex = 543
        Me.txtSaldoPorPagar.Text = "0.00"
        Me.txtSaldoPorPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label12.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(298, 85)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(134, 18)
        Me.Label12.TabIndex = 542
        Me.Label12.Text = "X PAGAR"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(26, 248)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(109, 14)
        Me.Label5.TabIndex = 541
        Me.Label5.Text = "Fecha de Transacción"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(25, 218)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 14)
        Me.Label2.TabIndex = 549
        Me.Label2.Text = "Información del pago"
        '
        'lblMonedaCobro
        '
        Me.lblMonedaCobro.AutoSize = True
        Me.lblMonedaCobro.Font = New System.Drawing.Font("Corbel", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonedaCobro.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblMonedaCobro.Location = New System.Drawing.Point(601, 33)
        Me.lblMonedaCobro.Name = "lblMonedaCobro"
        Me.lblMonedaCobro.Size = New System.Drawing.Size(49, 13)
        Me.lblMonedaCobro.TabIndex = 550
        Me.lblMonedaCobro.Text = "MONEDA"
        Me.lblMonedaCobro.Visible = False
        '
        'SaldoEFME
        '
        Me.SaldoEFME.BackGroundColor = System.Drawing.SystemColors.Window
        Me.SaldoEFME.BeforeTouchSize = New System.Drawing.Size(114, 22)
        Me.SaldoEFME.BorderColor = System.Drawing.Color.YellowGreen
        Me.SaldoEFME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SaldoEFME.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.SaldoEFME.DoubleValue = 0R
        Me.SaldoEFME.Location = New System.Drawing.Point(600, 171)
        Me.SaldoEFME.Metrocolor = System.Drawing.Color.YellowGreen
        Me.SaldoEFME.Name = "SaldoEFME"
        Me.SaldoEFME.NullString = ""
        Me.SaldoEFME.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.SaldoEFME.ReadOnly = True
        Me.SaldoEFME.Size = New System.Drawing.Size(114, 22)
        Me.SaldoEFME.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.SaldoEFME.TabIndex = 559
        Me.SaldoEFME.Text = "0.00"
        '
        'SaldoEFMN
        '
        Me.SaldoEFMN.BackGroundColor = System.Drawing.SystemColors.Window
        Me.SaldoEFMN.BeforeTouchSize = New System.Drawing.Size(114, 22)
        Me.SaldoEFMN.BorderColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.SaldoEFMN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SaldoEFMN.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.SaldoEFMN.DoubleValue = 0R
        Me.SaldoEFMN.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.SaldoEFMN.Location = New System.Drawing.Point(483, 171)
        Me.SaldoEFMN.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.SaldoEFMN.Name = "SaldoEFMN"
        Me.SaldoEFMN.NullString = ""
        Me.SaldoEFMN.PositiveColor = System.Drawing.SystemColors.HotTrack
        Me.SaldoEFMN.ReadOnly = True
        Me.SaldoEFMN.Size = New System.Drawing.Size(114, 22)
        Me.SaldoEFMN.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.SaldoEFMN.TabIndex = 558
        Me.SaldoEFMN.Text = "0.00"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(364, 148)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(47, 14)
        Me.Label14.TabIndex = 556
        Me.Label14.Text = "Moneda"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(480, 148)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(76, 14)
        Me.Label15.TabIndex = 555
        Me.Label15.Text = "Disponible EF."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(27, 305)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 14)
        Me.Label3.TabIndex = 563
        Me.Label3.Text = "Forma de pago"
        '
        'cboTipoDoc
        '
        Me.cboTipoDoc.BackColor = System.Drawing.Color.White
        Me.cboTipoDoc.BeforeTouchSize = New System.Drawing.Size(242, 21)
        Me.cboTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoDoc.Font = New System.Drawing.Font("Corbel", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoDoc.Location = New System.Drawing.Point(28, 329)
        Me.cboTipoDoc.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboTipoDoc.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.cboTipoDoc.Name = "cboTipoDoc"
        Me.cboTipoDoc.Size = New System.Drawing.Size(242, 21)
        Me.cboTipoDoc.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboTipoDoc.TabIndex = 562
        '
        'txtNumOper
        '
        Me.txtNumOper.BackColor = System.Drawing.Color.White
        BannerTextInfo1.Text = "Nro. de operación"
        BannerTextInfo1.Visible = True
        Me.BannerTextProvider1.SetBannerText(Me.txtNumOper, BannerTextInfo1)
        Me.txtNumOper.BeforeTouchSize = New System.Drawing.Size(114, 22)
        Me.txtNumOper.BorderColor = System.Drawing.Color.DarkGray
        Me.txtNumOper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumOper.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNumOper.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumOper.Location = New System.Drawing.Point(273, 328)
        Me.txtNumOper.MaxLength = 20
        Me.txtNumOper.Metrocolor = System.Drawing.Color.DarkGray
        Me.txtNumOper.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtNumOper.Name = "txtNumOper"
        Me.txtNumOper.Size = New System.Drawing.Size(114, 22)
        Me.txtNumOper.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtNumOper.TabIndex = 560
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(25, 142)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(165, 14)
        Me.Label6.TabIndex = 565
        Me.Label6.Text = "Seleccionar cuenta financiera"
        '
        'PictureBox1
        '
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(250, 358)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(21, 21)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 569
        Me.PictureBox1.TabStop = False
        '
        'cboEntidades
        '
        Me.cboEntidades.BackColor = System.Drawing.Color.White
        Me.cboEntidades.BeforeTouchSize = New System.Drawing.Size(220, 21)
        Me.cboEntidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEntidades.Font = New System.Drawing.Font("Corbel", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEntidades.Location = New System.Drawing.Point(28, 358)
        Me.cboEntidades.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboEntidades.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.cboEntidades.Name = "cboEntidades"
        Me.cboEntidades.Size = New System.Drawing.Size(220, 21)
        Me.cboEntidades.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboEntidades.TabIndex = 566
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(433, 85)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(134, 18)
        Me.Label7.TabIndex = 570
        Me.Label7.Text = "MONEDA"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMoneda
        '
        Me.lblMoneda.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.lblMoneda.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMoneda.ForeColor = System.Drawing.Color.White
        Me.lblMoneda.Location = New System.Drawing.Point(433, 103)
        Me.lblMoneda.Name = "lblMoneda"
        Me.lblMoneda.Size = New System.Drawing.Size(134, 23)
        Me.lblMoneda.TabIndex = 571
        Me.lblMoneda.Text = "NAC"
        Me.lblMoneda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label8.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(163, 85)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(134, 18)
        Me.Label8.TabIndex = 572
        Me.Label8.Text = "A CUENTA"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GradientPanel7
        '
        Me.GradientPanel7.BorderColor = System.Drawing.Color.Gray
        Me.GradientPanel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel7.Controls.Add(Me.txtPagoAcuenta)
        Me.GradientPanel7.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GradientPanel7.Location = New System.Drawing.Point(163, 103)
        Me.GradientPanel7.Name = "GradientPanel7"
        Me.GradientPanel7.Size = New System.Drawing.Size(134, 23)
        Me.GradientPanel7.TabIndex = 573
        '
        'txtPagoAcuenta
        '
        Me.txtPagoAcuenta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPagoAcuenta.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPagoAcuenta.Location = New System.Drawing.Point(0, 0)
        Me.txtPagoAcuenta.Name = "txtPagoAcuenta"
        Me.txtPagoAcuenta.Size = New System.Drawing.Size(132, 21)
        Me.txtPagoAcuenta.TabIndex = 574
        Me.txtPagoAcuenta.TabStop = True
        Me.txtPagoAcuenta.Text = "0.00"
        Me.txtPagoAcuenta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCuentaCorriente
        '
        Me.txtCuentaCorriente.BackColor = System.Drawing.Color.White
        BannerTextInfo2.Text = "Nro. cuenta corriente"
        BannerTextInfo2.Visible = True
        Me.BannerTextProvider1.SetBannerText(Me.txtCuentaCorriente, BannerTextInfo2)
        Me.txtCuentaCorriente.BeforeTouchSize = New System.Drawing.Size(114, 22)
        Me.txtCuentaCorriente.BorderColor = System.Drawing.Color.DarkGray
        Me.txtCuentaCorriente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuentaCorriente.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCuentaCorriente.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCuentaCorriente.Location = New System.Drawing.Point(273, 357)
        Me.txtCuentaCorriente.MaxLength = 20
        Me.txtCuentaCorriente.Metrocolor = System.Drawing.Color.DarkGray
        Me.txtCuentaCorriente.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtCuentaCorriente.Name = "txtCuentaCorriente"
        Me.txtCuentaCorriente.Size = New System.Drawing.Size(114, 22)
        Me.txtCuentaCorriente.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtCuentaCorriente.TabIndex = 580
        '
        'txtCF_tipo
        '
        Me.txtCF_tipo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        BannerTextInfo3.Text = "Tipo cuenta"
        BannerTextInfo3.Visible = True
        Me.BannerTextProvider1.SetBannerText(Me.txtCF_tipo, BannerTextInfo3)
        Me.txtCF_tipo.BeforeTouchSize = New System.Drawing.Size(114, 22)
        Me.txtCF_tipo.BorderColor = System.Drawing.Color.DarkGray
        Me.txtCF_tipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCF_tipo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCF_tipo.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCF_tipo.Location = New System.Drawing.Point(28, 171)
        Me.txtCF_tipo.MaxLength = 20
        Me.txtCF_tipo.Metrocolor = System.Drawing.Color.DarkGray
        Me.txtCF_tipo.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtCF_tipo.Name = "txtCF_tipo"
        Me.txtCF_tipo.ReadOnly = True
        Me.txtCF_tipo.Size = New System.Drawing.Size(114, 22)
        Me.txtCF_tipo.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtCF_tipo.TabIndex = 588
        '
        'txtCF_name
        '
        Me.txtCF_name.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        BannerTextInfo4.Text = "Cuenta financiera"
        BannerTextInfo4.Visible = True
        Me.BannerTextProvider1.SetBannerText(Me.txtCF_name, BannerTextInfo4)
        Me.txtCF_name.BeforeTouchSize = New System.Drawing.Size(114, 22)
        Me.txtCF_name.BorderColor = System.Drawing.Color.DarkGray
        Me.txtCF_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCF_name.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCF_name.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCF_name.Location = New System.Drawing.Point(146, 171)
        Me.txtCF_name.MaxLength = 20
        Me.txtCF_name.Metrocolor = System.Drawing.Color.DarkGray
        Me.txtCF_name.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtCF_name.Name = "txtCF_name"
        Me.txtCF_name.ReadOnly = True
        Me.txtCF_name.Size = New System.Drawing.Size(213, 22)
        Me.txtCF_name.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtCF_name.TabIndex = 589
        '
        'txtCF_moneda
        '
        Me.txtCF_moneda.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        BannerTextInfo5.Text = "Moneda"
        BannerTextInfo5.Visible = True
        Me.BannerTextProvider1.SetBannerText(Me.txtCF_moneda, BannerTextInfo5)
        Me.txtCF_moneda.BeforeTouchSize = New System.Drawing.Size(114, 22)
        Me.txtCF_moneda.BorderColor = System.Drawing.Color.DarkGray
        Me.txtCF_moneda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCF_moneda.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCF_moneda.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCF_moneda.Location = New System.Drawing.Point(363, 171)
        Me.txtCF_moneda.MaxLength = 20
        Me.txtCF_moneda.Metrocolor = System.Drawing.Color.DarkGray
        Me.txtCF_moneda.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtCF_moneda.Name = "txtCF_moneda"
        Me.txtCF_moneda.ReadOnly = True
        Me.txtCF_moneda.Size = New System.Drawing.Size(114, 22)
        Me.txtCF_moneda.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtCF_moneda.TabIndex = 590
        '
        'txtPagoMN
        '
        Me.txtPagoMN.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtPagoMN.BeforeTouchSize = New System.Drawing.Size(135, 21)
        Me.txtPagoMN.BorderColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtPagoMN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPagoMN.DecimalPlaces = 2
        Me.txtPagoMN.Font = New System.Drawing.Font("Arial", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPagoMN.ForeColor = System.Drawing.Color.Black
        Me.txtPagoMN.Location = New System.Drawing.Point(433, 272)
        Me.txtPagoMN.Maximum = New Decimal(New Integer() {-159383552, 46653770, 5421, 0})
        Me.txtPagoMN.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtPagoMN.Name = "txtPagoMN"
        Me.txtPagoMN.Size = New System.Drawing.Size(135, 21)
        Me.txtPagoMN.TabIndex = 397
        Me.txtPagoMN.TabStop = False
        Me.txtPagoMN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPagoMN.ThousandsSeparator = True
        Me.txtPagoMN.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.BackGroundColor = System.Drawing.SystemColors.Window
        Me.txtTipoCambio.BeforeTouchSize = New System.Drawing.Size(114, 22)
        Me.txtTipoCambio.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTipoCambio.DoubleValue = 1.0R
        Me.txtTipoCambio.Location = New System.Drawing.Point(574, 271)
        Me.txtTipoCambio.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTipoCambio.MinValue = 1.0R
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.NullString = ""
        Me.txtTipoCambio.NumberDecimalDigits = 3
        Me.txtTipoCambio.Size = New System.Drawing.Size(66, 22)
        Me.txtTipoCambio.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtTipoCambio.TabIndex = 579
        Me.txtTipoCambio.Text = "1.000"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Corbel", 7.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(588, 250)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(25, 13)
        Me.Label13.TabIndex = 578
        Me.Label13.Text = "T/C:"
        '
        'txtPagoME
        '
        Me.txtPagoME.BackColor = System.Drawing.Color.PaleGreen
        Me.txtPagoME.BeforeTouchSize = New System.Drawing.Size(135, 21)
        Me.txtPagoME.BorderColor = System.Drawing.Color.DimGray
        Me.txtPagoME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPagoME.DecimalPlaces = 2
        Me.txtPagoME.Font = New System.Drawing.Font("Arial", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPagoME.ForeColor = System.Drawing.Color.Black
        Me.txtPagoME.Location = New System.Drawing.Point(433, 299)
        Me.txtPagoME.Maximum = New Decimal(New Integer() {-1304428544, 434162106, 542, 0})
        Me.txtPagoME.MetroColor = System.Drawing.Color.DimGray
        Me.txtPagoME.Name = "txtPagoME"
        Me.txtPagoME.Size = New System.Drawing.Size(135, 21)
        Me.txtPagoME.TabIndex = 577
        Me.txtPagoME.TabStop = False
        Me.txtPagoME.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtPagoME.ThousandsSeparator = True
        Me.txtPagoME.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BorderColor = System.Drawing.SystemColors.Highlight
        Me.GradientPanel1.BorderSides = System.Windows.Forms.Border3DSide.Right
        Me.GradientPanel1.BorderSingle = System.Windows.Forms.ButtonBorderStyle.Dotted
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Location = New System.Drawing.Point(399, 218)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(10, 163)
        Me.GradientPanel1.TabIndex = 581
        '
        'dgvDetalleItems
        '
        Me.dgvDetalleItems.AllowUserToAddRows = False
        Me.dgvDetalleItems.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgvDetalleItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalleItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colId, Me.colNameItem, Me.colum, Me.ColPrecUnit, Me.colMN, Me.colME, Me.colPagoMN, Me.colPagoME, Me.colSaldoMN, Me.colSaldoME, Me.colEstado, Me.colSecuencia})
        Me.dgvDetalleItems.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvDetalleItems.Location = New System.Drawing.Point(0, 399)
        Me.dgvDetalleItems.MultiSelect = False
        Me.dgvDetalleItems.Name = "dgvDetalleItems"
        Me.dgvDetalleItems.RowHeadersVisible = False
        Me.dgvDetalleItems.Size = New System.Drawing.Size(745, 154)
        Me.dgvDetalleItems.TabIndex = 583
        '
        'colId
        '
        Me.colId.HeaderText = "ID"
        Me.colId.Name = "colId"
        Me.colId.ReadOnly = True
        Me.colId.Visible = False
        Me.colId.Width = 50
        '
        'colNameItem
        '
        Me.colNameItem.HeaderText = "Descripción"
        Me.colNameItem.Name = "colNameItem"
        Me.colNameItem.ReadOnly = True
        Me.colNameItem.Width = 300
        '
        'colum
        '
        Me.colum.HeaderText = "U.M."
        Me.colum.Name = "colum"
        Me.colum.ReadOnly = True
        Me.colum.Visible = False
        Me.colum.Width = 40
        '
        'ColPrecUnit
        '
        Me.ColPrecUnit.HeaderText = "Prec Unit"
        Me.ColPrecUnit.Name = "ColPrecUnit"
        Me.ColPrecUnit.ReadOnly = True
        Me.ColPrecUnit.Visible = False
        '
        'colMN
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.colMN.DefaultCellStyle = DataGridViewCellStyle1
        Me.colMN.HeaderText = "Importe MN"
        Me.colMN.Name = "colMN"
        Me.colMN.ReadOnly = True
        Me.colMN.Width = 80
        '
        'colME
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.colME.DefaultCellStyle = DataGridViewCellStyle2
        Me.colME.HeaderText = "Importe ME"
        Me.colME.Name = "colME"
        Me.colME.ReadOnly = True
        Me.colME.Width = 80
        '
        'colPagoMN
        '
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.colPagoMN.DefaultCellStyle = DataGridViewCellStyle3
        Me.colPagoMN.HeaderText = "Pago MN"
        Me.colPagoMN.Name = "colPagoMN"
        Me.colPagoMN.ReadOnly = True
        Me.colPagoMN.Width = 80
        '
        'colPagoME
        '
        DataGridViewCellStyle4.NullValue = Nothing
        Me.colPagoME.DefaultCellStyle = DataGridViewCellStyle4
        Me.colPagoME.HeaderText = "Pago ME"
        Me.colPagoME.Name = "colPagoME"
        Me.colPagoME.ReadOnly = True
        Me.colPagoME.Width = 80
        '
        'colSaldoMN
        '
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.LavenderBlush
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.colSaldoMN.DefaultCellStyle = DataGridViewCellStyle5
        Me.colSaldoMN.HeaderText = "Saldo MN"
        Me.colSaldoMN.Name = "colSaldoMN"
        Me.colSaldoMN.ReadOnly = True
        Me.colSaldoMN.Width = 80
        '
        'colSaldoME
        '
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.LavenderBlush
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.colSaldoME.DefaultCellStyle = DataGridViewCellStyle6
        Me.colSaldoME.HeaderText = "Saldo ME"
        Me.colSaldoME.Name = "colSaldoME"
        Me.colSaldoME.ReadOnly = True
        Me.colSaldoME.Width = 80
        '
        'colEstado
        '
        Me.colEstado.HeaderText = "EST"
        Me.colEstado.Name = "colEstado"
        Me.colEstado.ReadOnly = True
        Me.colEstado.Visible = False
        Me.colEstado.Width = 5
        '
        'colSecuencia
        '
        Me.colSecuencia.HeaderText = "Sec"
        Me.colSecuencia.Name = "colSecuencia"
        Me.colSecuencia.ReadOnly = True
        Me.colSecuencia.Visible = False
        Me.colSecuencia.Width = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(431, 248)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 14)
        Me.Label4.TabIndex = 584
        Me.Label4.Text = "Monto MN."
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(431, 218)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(99, 14)
        Me.Label10.TabIndex = 582
        Me.Label10.Text = "Importe a cobrar"
        '
        'TXTVENTA
        '
        Me.TXTVENTA.BackGroundColor = System.Drawing.SystemColors.Window
        Me.TXTVENTA.BeforeTouchSize = New System.Drawing.Size(114, 22)
        Me.TXTVENTA.BorderColor = System.Drawing.Color.DodgerBlue
        Me.TXTVENTA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXTVENTA.CurrencySymbol = ""
        Me.TXTVENTA.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TXTVENTA.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TXTVENTA.Font = New System.Drawing.Font("Ebrima", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTVENTA.ForeColor = System.Drawing.Color.White
        Me.TXTVENTA.Location = New System.Drawing.Point(28, 103)
        Me.TXTVENTA.Metrocolor = System.Drawing.Color.MediumSeaGreen
        Me.TXTVENTA.Name = "TXTVENTA"
        Me.TXTVENTA.NullString = ""
        Me.TXTVENTA.PositiveColor = System.Drawing.Color.White
        Me.TXTVENTA.ReadOnly = True
        Me.TXTVENTA.ReadOnlyBackColor = System.Drawing.Color.DodgerBlue
        Me.TXTVENTA.Size = New System.Drawing.Size(134, 23)
        Me.TXTVENTA.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TXTVENTA.TabIndex = 586
        Me.TXTVENTA.Text = "0.00"
        Me.TXTVENTA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(28, 85)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(134, 18)
        Me.Label9.TabIndex = 585
        Me.Label9.Text = "VENTA"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Timer1
        '
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Panel1.Controls.Add(Me.GradientPanel5)
        Me.Panel1.Controls.Add(Me.ButtonAdv5)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 553)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(745, 50)
        Me.Panel1.TabIndex = 587
        '
        'GradientPanel5
        '
        Me.GradientPanel5.BackColor = System.Drawing.Color.White
        Me.GradientPanel5.BorderColor = System.Drawing.Color.Silver
        Me.GradientPanel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel5.Controls.Add(Me.ButtonAdv4)
        Me.GradientPanel5.Location = New System.Drawing.Point(633, 9)
        Me.GradientPanel5.Name = "GradientPanel5"
        Me.GradientPanel5.Size = New System.Drawing.Size(100, 32)
        Me.GradientPanel5.TabIndex = 12
        '
        'ButtonAdv4
        '
        Me.ButtonAdv4.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv4.BackColor = System.Drawing.Color.White
        Me.ButtonAdv4.BeforeTouchSize = New System.Drawing.Size(98, 30)
        Me.ButtonAdv4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAdv4.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.ButtonAdv4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAdv4.Font = New System.Drawing.Font("Corbel", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonAdv4.IsBackStageButton = False
        Me.ButtonAdv4.Location = New System.Drawing.Point(0, 0)
        Me.ButtonAdv4.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonAdv4.Name = "ButtonAdv4"
        Me.ButtonAdv4.Size = New System.Drawing.Size(98, 30)
        Me.ButtonAdv4.TabIndex = 9
        Me.ButtonAdv4.Text = "Cancel"
        Me.ButtonAdv4.UseVisualStyle = True
        '
        'ButtonAdv5
        '
        Me.ButtonAdv5.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv5.BackColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.ButtonAdv5.BeforeTouchSize = New System.Drawing.Size(100, 32)
        Me.ButtonAdv5.Font = New System.Drawing.Font("Corbel", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv5.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv5.IsBackStageButton = False
        Me.ButtonAdv5.Location = New System.Drawing.Point(527, 9)
        Me.ButtonAdv5.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonAdv5.Name = "ButtonAdv5"
        Me.ButtonAdv5.Size = New System.Drawing.Size(100, 32)
        Me.ButtonAdv5.TabIndex = 11
        Me.ButtonAdv5.Text = "Grabar"
        Me.ButtonAdv5.UseVisualStyle = True
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.Location = New System.Drawing.Point(601, 148)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(99, 14)
        Me.LinkLabel1.TabIndex = 591
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Seleccionar cuenta"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCF_cuentaContable
        '
        Me.txtCF_cuentaContable.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtCF_cuentaContable.BeforeTouchSize = New System.Drawing.Size(114, 22)
        Me.txtCF_cuentaContable.BorderColor = System.Drawing.Color.DarkGray
        Me.txtCF_cuentaContable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCF_cuentaContable.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCF_cuentaContable.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCF_cuentaContable.Location = New System.Drawing.Point(646, 271)
        Me.txtCF_cuentaContable.MaxLength = 20
        Me.txtCF_cuentaContable.Metrocolor = System.Drawing.Color.DarkGray
        Me.txtCF_cuentaContable.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtCF_cuentaContable.Name = "txtCF_cuentaContable"
        Me.txtCF_cuentaContable.ReadOnly = True
        Me.txtCF_cuentaContable.Size = New System.Drawing.Size(53, 22)
        Me.txtCF_cuentaContable.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtCF_cuentaContable.TabIndex = 592
        Me.txtCF_cuentaContable.Visible = False
        '
        'frmPagoMembresia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BorderColor = System.Drawing.SystemColors.Highlight
        Me.BorderThickness = 0
        Me.CaptionBarHeight = 55
        Me.CaptionButtonColor = System.Drawing.SystemColors.Highlight
        Me.CaptionButtonHoverColor = System.Drawing.SystemColors.Highlight
        Me.ClientSize = New System.Drawing.Size(745, 603)
        Me.Controls.Add(Me.txtCF_cuentaContable)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.txtCF_moneda)
        Me.Controls.Add(Me.txtCF_name)
        Me.Controls.Add(Me.txtCF_tipo)
        Me.Controls.Add(Me.TXTVENTA)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dgvDetalleItems)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.txtCuentaCorriente)
        Me.Controls.Add(Me.txtTipoCambio)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtPagoME)
        Me.Controls.Add(Me.txtPagoMN)
        Me.Controls.Add(Me.GradientPanel7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lblMoneda)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.cboEntidades)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboTipoDoc)
        Me.Controls.Add(Me.txtNumOper)
        Me.Controls.Add(Me.SaldoEFME)
        Me.Controls.Add(Me.SaldoEFMN)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.lblMonedaCobro)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtAnioCompra)
        Me.Controls.Add(Me.cboMesCompra)
        Me.Controls.Add(Me.txtDia)
        Me.Controls.Add(Me.txtPeriodo)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtSaldoPorPagar)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtTipoEntidad)
        Me.Controls.Add(Me.txtNroDocEntidad)
        Me.Controls.Add(Me.txtEntidad)
        Me.Controls.Add(Me.PanelError)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPagoMembresia"
        Me.ShowIcon = False
        Me.Text = ""
        Me.PanelError.ResumeLayout(False)
        Me.PanelError.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoEntidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNroDocEntidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEntidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAnioCompra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboMesCompra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDia.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPeriodo.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPeriodo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSaldoPorPagar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SaldoEFME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SaldoEFMN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTipoDoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumOper, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboEntidades, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel7.ResumeLayout(False)
        CType(Me.txtCuentaCorriente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCF_tipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCF_name, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCF_moneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPagoMN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoCambio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPagoME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDetalleItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TXTVENTA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.GradientPanel5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel5.ResumeLayout(False)
        CType(Me.txtCF_cuentaContable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PanelError As Panel
    Friend WithEvents lblEstado As Label
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents txtTipoEntidad As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtNroDocEntidad As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtEntidad As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label1 As Label
    Friend WithEvents txtAnioCompra As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents cboMesCompra As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents txtDia As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents txtPeriodo As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents Label18 As Label
    Friend WithEvents txtSaldoPorPagar As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblMonedaCobro As Label
    Friend WithEvents SaldoEFME As Syncfusion.Windows.Forms.Tools.DoubleTextBox
    Friend WithEvents SaldoEFMN As Syncfusion.Windows.Forms.Tools.DoubleTextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cboTipoDoc As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents txtNumOper As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label6 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents cboEntidades As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label7 As Label
    Friend WithEvents lblMoneda As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents GradientPanel7 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents txtPagoAcuenta As LinkLabel
    Friend WithEvents BannerTextProvider1 As Syncfusion.Windows.Forms.BannerTextProvider
    Friend WithEvents txtPagoMN As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents txtTipoCambio As Syncfusion.Windows.Forms.Tools.DoubleTextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtPagoME As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents txtCuentaCorriente As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents dgvDetalleItems As DataGridView
    Friend WithEvents colId As DataGridViewTextBoxColumn
    Friend WithEvents colNameItem As DataGridViewTextBoxColumn
    Friend WithEvents colum As DataGridViewTextBoxColumn
    Friend WithEvents ColPrecUnit As DataGridViewTextBoxColumn
    Friend WithEvents colMN As DataGridViewTextBoxColumn
    Friend WithEvents colME As DataGridViewTextBoxColumn
    Friend WithEvents colPagoMN As DataGridViewTextBoxColumn
    Friend WithEvents colPagoME As DataGridViewTextBoxColumn
    Friend WithEvents colSaldoMN As DataGridViewTextBoxColumn
    Friend WithEvents colSaldoME As DataGridViewTextBoxColumn
    Friend WithEvents colEstado As DataGridViewTextBoxColumn
    Friend WithEvents colSecuencia As DataGridViewTextBoxColumn
    Friend WithEvents Label4 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents TXTVENTA As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GradientPanel5 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents ButtonAdv4 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents ButtonAdv5 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents txtCF_tipo As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtCF_name As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtCF_moneda As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents txtCF_cuentaContable As Syncfusion.Windows.Forms.Tools.TextBoxExt
End Class

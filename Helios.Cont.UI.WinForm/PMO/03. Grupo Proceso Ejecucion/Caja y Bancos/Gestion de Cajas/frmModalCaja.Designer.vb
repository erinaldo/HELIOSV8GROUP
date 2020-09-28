<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModalCaja
    Inherits Helios.Cont.Presentation.WinForm.frmMaster

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
        Dim BannerTextInfo1 As Syncfusion.Windows.Forms.BannerTextInfo = New Syncfusion.Windows.Forms.BannerTextInfo()
        Dim MetroColorTable1 As Syncfusion.Windows.Forms.MetroColorTable = New Syncfusion.Windows.Forms.MetroColorTable()
        Dim BannerTextInfo2 As Syncfusion.Windows.Forms.BannerTextInfo = New Syncfusion.Windows.Forms.BannerTextInfo()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmModalCaja))
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.QGlobalColorSchemeManager1 = New Qios.DevSuite.Components.QGlobalColorSchemeManager(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtCodigoCuenta = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.cboCuenta = New Syncfusion.Windows.Forms.Tools.MultiColumnComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtFecha = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtBalanceInicial = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNumCuentaCorriente = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboTipoCuenta = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.cboMoneda = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDescripcion = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboBanco = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCuenta = New System.Windows.Forms.TextBox()
        Me.txtCuentaID = New Femiani.Forms.UI.Input.CoolTextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.lblEstado = New System.Windows.Forms.ToolStripButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.QRibbonApplicationButton1 = New Qios.DevSuite.Components.Ribbon.QRibbonApplicationButton()
        Me.QRibbonLaunchBar1 = New Qios.DevSuite.Components.Ribbon.QRibbonLaunchBar()
        Me.QRibbonApplicationButton2 = New Qios.DevSuite.Components.Ribbon.QRibbonApplicationButton()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.GuardarToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.PegarToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblIdDocumento = New System.Windows.Forms.ToolStripLabel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.ToolStrip5 = New System.Windows.Forms.ToolStrip()
        Me.btGrabar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.BannerTextProvider1 = New Syncfusion.Windows.Forms.BannerTextProvider(Me.components)
        Me.lblmodalidad = New System.Windows.Forms.Label()
        Me.cboModalidadCtaBancaria = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.txtNroCuentaInterbancaria = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.txtCodigoCuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBalanceInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumCuentaCorriente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTipoCuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescripcion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboBanco, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.ToolStrip3.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.ToolStrip5.SuspendLayout()
        CType(Me.cboModalidadCtaBancaria, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNroCuentaInterbancaria, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtNroCuentaInterbancaria)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.cboModalidadCtaBancaria)
        Me.Panel1.Controls.Add(Me.lblmodalidad)
        Me.Panel1.Controls.Add(Me.txtCodigoCuenta)
        Me.Panel1.Controls.Add(Me.cboCuenta)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.txtFecha)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtBalanceInicial)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtNumCuentaCorriente)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.cboTipoCuenta)
        Me.Panel1.Controls.Add(Me.cboMoneda)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.txtDescripcion)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.cboBanco)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtCuenta)
        Me.Panel1.Controls.Add(Me.txtCuentaID)
        Me.Panel1.Controls.Add(Me.ToolStrip1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(576, 309)
        Me.Panel1.TabIndex = 1
        Me.Panel1.Text = "QRibbonCaption1"
        '
        'txtCodigoCuenta
        '
        Me.txtCodigoCuenta.BackColor = System.Drawing.Color.White
        BannerTextInfo1.Text = "CODIGO"
        BannerTextInfo1.Visible = True
        Me.BannerTextProvider1.SetBannerText(Me.txtCodigoCuenta, BannerTextInfo1)
        Me.txtCodigoCuenta.BeforeTouchSize = New System.Drawing.Size(259, 22)
        Me.txtCodigoCuenta.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtCodigoCuenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigoCuenta.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCodigoCuenta.Location = New System.Drawing.Point(312, 278)
        Me.txtCodigoCuenta.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtCodigoCuenta.Name = "txtCodigoCuenta"
        Me.txtCodigoCuenta.Size = New System.Drawing.Size(89, 22)
        Me.txtCodigoCuenta.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtCodigoCuenta.TabIndex = 485
        Me.txtCodigoCuenta.Text = "101"
        '
        'cboCuenta
        '
        Me.cboCuenta.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.cboCuenta.BackColor = System.Drawing.Color.White
        Me.cboCuenta.BeforeTouchSize = New System.Drawing.Size(294, 21)
        Me.cboCuenta.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCuenta.Location = New System.Drawing.Point(12, 278)
        Me.cboCuenta.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.cboCuenta.Name = "cboCuenta"
        MetroColorTable1.ArrowChecked = System.Drawing.Color.FromArgb(CType(CType(147, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(152, Byte), Integer))
        MetroColorTable1.ArrowCheckedBorderColor = System.Drawing.Color.Empty
        MetroColorTable1.ArrowInActive = System.Drawing.Color.White
        MetroColorTable1.ArrowNormal = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(198, Byte), Integer))
        MetroColorTable1.ArrowNormalBackGround = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(198, Byte), Integer))
        MetroColorTable1.ArrowNormalBorderColor = System.Drawing.Color.Empty
        MetroColorTable1.ArrowPushed = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(90, Byte), Integer))
        MetroColorTable1.ArrowPushedBackGround = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(90, Byte), Integer))
        MetroColorTable1.ArrowPushedBorderColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(90, Byte), Integer))
        MetroColorTable1.ScrollerBackground = System.Drawing.Color.White
        MetroColorTable1.ThumbChecked = System.Drawing.Color.FromArgb(CType(CType(147, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(152, Byte), Integer))
        MetroColorTable1.ThumbCheckedBorderColor = System.Drawing.Color.Empty
        MetroColorTable1.ThumbInActive = System.Drawing.Color.White
        MetroColorTable1.ThumbNormal = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(198, Byte), Integer))
        MetroColorTable1.ThumbNormalBorderColor = System.Drawing.Color.Empty
        MetroColorTable1.ThumbPushed = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(90, Byte), Integer))
        MetroColorTable1.ThumbPushedBorder = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(90, Byte), Integer))
        MetroColorTable1.ThumbPushedBorderColor = System.Drawing.Color.Empty
        Me.cboCuenta.ScrollMetroColorTable = MetroColorTable1
        Me.cboCuenta.Size = New System.Drawing.Size(294, 21)
        Me.cboCuenta.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboCuenta.TabIndex = 484
        Me.cboCuenta.Text = "Selecione una cuenta contable"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 6.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(12, 260)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(93, 11)
        Me.Label9.TabIndex = 483
        Me.Label9.Text = "CUENTA CONTABLE"
        '
        'txtFecha
        '
        Me.txtFecha.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtFecha.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFecha.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtFecha.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFecha.CustomFormat = "dd/MM/yyyy HH:mm tt"
        Me.txtFecha.DropDownImage = Nothing
        Me.txtFecha.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecha.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecha.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtFecha.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFecha.Location = New System.Drawing.Point(470, 343)
        Me.txtFecha.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecha.MinValue = New Date(CType(0, Long))
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ShowCheckBox = False
        Me.txtFecha.Size = New System.Drawing.Size(165, 20)
        Me.txtFecha.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFecha.TabIndex = 482
        Me.txtFecha.Value = New Date(2016, 1, 11, 17, 2, 53, 38)
        Me.txtFecha.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 6.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(468, 324)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 11)
        Me.Label3.TabIndex = 481
        Me.Label3.Text = "FECHA BALANCE"
        Me.Label3.Visible = False
        '
        'txtBalanceInicial
        '
        Me.txtBalanceInicial.BeforeTouchSize = New System.Drawing.Size(259, 22)
        Me.txtBalanceInicial.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtBalanceInicial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBalanceInicial.CurrencySymbol = ""
        Me.txtBalanceInicial.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBalanceInicial.DecimalValue = New Decimal(New Integer() {100, 0, 0, 131072})
        Me.txtBalanceInicial.Location = New System.Drawing.Point(302, 343)
        Me.txtBalanceInicial.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtBalanceInicial.Name = "txtBalanceInicial"
        Me.txtBalanceInicial.NearImage = CType(resources.GetObject("txtBalanceInicial.NearImage"), System.Drawing.Image)
        Me.txtBalanceInicial.NullString = ""
        Me.txtBalanceInicial.Size = New System.Drawing.Size(141, 22)
        Me.txtBalanceInicial.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtBalanceInicial.TabIndex = 480
        Me.txtBalanceInicial.Text = "1.00"
        Me.txtBalanceInicial.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 6.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(301, 324)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 11)
        Me.Label2.TabIndex = 479
        Me.Label2.Text = "BALANCE INICIAL"
        Me.Label2.Visible = False
        '
        'txtNumCuentaCorriente
        '
        Me.txtNumCuentaCorriente.BackColor = System.Drawing.Color.White
        Me.txtNumCuentaCorriente.BeforeTouchSize = New System.Drawing.Size(259, 22)
        Me.txtNumCuentaCorriente.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtNumCuentaCorriente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumCuentaCorriente.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNumCuentaCorriente.Location = New System.Drawing.Point(14, 186)
        Me.txtNumCuentaCorriente.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtNumCuentaCorriente.Name = "txtNumCuentaCorriente"
        Me.txtNumCuentaCorriente.NearImage = CType(resources.GetObject("txtNumCuentaCorriente.NearImage"), System.Drawing.Image)
        Me.txtNumCuentaCorriente.Size = New System.Drawing.Size(259, 22)
        Me.txtNumCuentaCorriente.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtNumCuentaCorriente.TabIndex = 478
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 6.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(12, 167)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 11)
        Me.Label8.TabIndex = 477
        Me.Label8.Text = "NO. CUENTA"
        '
        'cboTipoCuenta
        '
        Me.cboTipoCuenta.BackColor = System.Drawing.Color.White
        Me.cboTipoCuenta.BeforeTouchSize = New System.Drawing.Size(261, 21)
        Me.cboTipoCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoCuenta.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoCuenta.Items.AddRange(New Object() {"Cuenta Bancaria", "Caja especial"})
        Me.cboTipoCuenta.Location = New System.Drawing.Point(12, 86)
        Me.cboTipoCuenta.Name = "cboTipoCuenta"
        Me.cboTipoCuenta.Size = New System.Drawing.Size(261, 21)
        Me.cboTipoCuenta.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboTipoCuenta.TabIndex = 476
        Me.cboTipoCuenta.Text = "Cuenta Bancaria"
        '
        'cboMoneda
        '
        Me.cboMoneda.BackColor = System.Drawing.Color.White
        Me.cboMoneda.BeforeTouchSize = New System.Drawing.Size(261, 21)
        Me.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMoneda.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMoneda.Items.AddRange(New Object() {"MONEDA NACIONAL", "MONEDA EXTRANJERA"})
        Me.cboMoneda.Location = New System.Drawing.Point(14, 233)
        Me.cboMoneda.Name = "cboMoneda"
        Me.cboMoneda.Size = New System.Drawing.Size(261, 21)
        Me.cboMoneda.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboMoneda.TabIndex = 475
        Me.cboMoneda.Text = "MONEDA NACIONAL"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 6.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(12, 213)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 11)
        Me.Label7.TabIndex = 474
        Me.Label7.Text = "MONEDA"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.BackColor = System.Drawing.Color.White
        BannerTextInfo2.Text = "EJ. CUENTA CORRIENTE MI EMPRESA"
        BannerTextInfo2.Visible = True
        Me.BannerTextProvider1.SetBannerText(Me.txtDescripcion, BannerTextInfo2)
        Me.txtDescripcion.BeforeTouchSize = New System.Drawing.Size(259, 22)
        Me.txtDescripcion.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDescripcion.Location = New System.Drawing.Point(300, 136)
        Me.txtDescripcion.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(261, 22)
        Me.txtDescripcion.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtDescripcion.TabIndex = 473
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 6.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(298, 116)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 11)
        Me.Label6.TabIndex = 472
        Me.Label6.Text = "DESCRIPCION"
        '
        'cboBanco
        '
        Me.cboBanco.BackColor = System.Drawing.Color.White
        Me.cboBanco.BeforeTouchSize = New System.Drawing.Size(259, 21)
        Me.cboBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBanco.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBanco.Location = New System.Drawing.Point(14, 136)
        Me.cboBanco.Name = "cboBanco"
        Me.cboBanco.Size = New System.Drawing.Size(259, 21)
        Me.cboBanco.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboBanco.TabIndex = 471
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 6.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(12, 116)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(146, 11)
        Me.Label5.TabIndex = 470
        Me.Label5.Text = "BANCO - ENTIDAD FINANCIERA"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 6.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(12, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 11)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "TIPO DE CUENTA"
        '
        'txtCuenta
        '
        Me.txtCuenta.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtCuenta.Location = New System.Drawing.Point(214, 400)
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.ReadOnly = True
        Me.txtCuenta.Size = New System.Drawing.Size(262, 22)
        Me.txtCuenta.TabIndex = 465
        Me.txtCuenta.Visible = False
        '
        'txtCuentaID
        '
        Me.txtCuentaID.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.txtCuentaID.BackColor = System.Drawing.SystemColors.Window
        Me.txtCuentaID.BorderColor = System.Drawing.Color.LightSteelBlue
        Me.txtCuentaID.Enabled = False
        Me.txtCuentaID.Location = New System.Drawing.Point(142, 400)
        Me.txtCuentaID.Name = "txtCuentaID"
        Me.txtCuentaID.Padding = New System.Windows.Forms.Padding(4)
        Me.txtCuentaID.PopupWidth = 120
        Me.txtCuentaID.SelectedItemBackColor = System.Drawing.SystemColors.Highlight
        Me.txtCuentaID.SelectedItemForeColor = System.Drawing.SystemColors.HighlightText
        Me.txtCuentaID.Size = New System.Drawing.Size(70, 23)
        Me.txtCuentaID.TabIndex = 461
        Me.txtCuentaID.Visible = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblEstado})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(576, 25)
        Me.ToolStrip1.TabIndex = 4
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'lblEstado
        '
        Me.lblEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblEstado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(46, 22)
        Me.lblEstado.Text = "Estado"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(60, 405)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Cta. contable:"
        Me.Label1.Visible = False
        '
        'QRibbonApplicationButton1
        '
        Me.QRibbonApplicationButton1.Checked = True
        Me.QRibbonApplicationButton1.Configuration.Padding = New Qios.DevSuite.Components.QPadding(12, 11, -10, -9)
        Me.QRibbonApplicationButton1.ForegroundImage = CType(resources.GetObject("QRibbonApplicationButton1.ForegroundImage"), System.Drawing.Image)
        '
        'QRibbonApplicationButton2
        '
        Me.QRibbonApplicationButton2.Checked = True
        Me.QRibbonApplicationButton2.Configuration.Padding = New Qios.DevSuite.Components.QPadding(12, 11, -10, -9)
        Me.QRibbonApplicationButton2.ForegroundImage = CType(resources.GetObject("QRibbonApplicationButton2.ForegroundImage"), System.Drawing.Image)
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'ToolStrip3
        '
        Me.ToolStrip3.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GuardarToolStripButton, Me.PegarToolStripButton, Me.toolStripSeparator1, Me.lblIdDocumento})
        Me.ToolStrip3.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip3.Size = New System.Drawing.Size(486, 25)
        Me.ToolStrip3.TabIndex = 407
        Me.ToolStrip3.Text = "ToolStrip3"
        Me.ToolStrip3.Visible = False
        '
        'GuardarToolStripButton
        '
        Me.GuardarToolStripButton.Image = CType(resources.GetObject("GuardarToolStripButton.Image"), System.Drawing.Image)
        Me.GuardarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.GuardarToolStripButton.Name = "GuardarToolStripButton"
        Me.GuardarToolStripButton.Size = New System.Drawing.Size(62, 22)
        Me.GuardarToolStripButton.Text = "&Grabar"
        '
        'PegarToolStripButton
        '
        Me.PegarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PegarToolStripButton.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.arrow_circle_135_left
        Me.PegarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PegarToolStripButton.Name = "PegarToolStripButton"
        Me.PegarToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PegarToolStripButton.Text = "&Cancelar"
        Me.PegarToolStripButton.Visible = False
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'lblIdDocumento
        '
        Me.lblIdDocumento.Name = "lblIdDocumento"
        Me.lblIdDocumento.Size = New System.Drawing.Size(19, 22)
        Me.lblIdDocumento.Text = "00"
        Me.lblIdDocumento.Visible = False
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.ToolStrip5)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(576, 45)
        Me.Panel7.TabIndex = 423
        '
        'ToolStrip5
        '
        Me.ToolStrip5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ToolStrip5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStrip5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip5.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip5.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btGrabar, Me.ToolStripButton4})
        Me.ToolStrip5.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip5.Name = "ToolStrip5"
        Me.ToolStrip5.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip5.Size = New System.Drawing.Size(576, 45)
        Me.ToolStrip5.TabIndex = 2
        Me.ToolStrip5.Text = "ToolStrip5"
        '
        'btGrabar
        '
        Me.btGrabar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btGrabar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btGrabar.Image = CType(resources.GetObject("btGrabar.Image"), System.Drawing.Image)
        Me.btGrabar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btGrabar.Name = "btGrabar"
        Me.btGrabar.Size = New System.Drawing.Size(44, 42)
        Me.btGrabar.Text = "Guardar"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(44, 42)
        '
        'lblmodalidad
        '
        Me.lblmodalidad.AutoSize = True
        Me.lblmodalidad.Font = New System.Drawing.Font("Arial", 6.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmodalidad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblmodalidad.Location = New System.Drawing.Point(298, 66)
        Me.lblmodalidad.Name = "lblmodalidad"
        Me.lblmodalidad.Size = New System.Drawing.Size(59, 11)
        Me.lblmodalidad.TabIndex = 486
        Me.lblmodalidad.Text = "MODALIDAD"
        '
        'cboModalidadCtaBancaria
        '
        Me.cboModalidadCtaBancaria.BackColor = System.Drawing.Color.White
        Me.cboModalidadCtaBancaria.BeforeTouchSize = New System.Drawing.Size(261, 21)
        Me.cboModalidadCtaBancaria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboModalidadCtaBancaria.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboModalidadCtaBancaria.Items.AddRange(New Object() {"Cuenta Corriente", "Cuenta de Ahorros", "Cuenta Plazo Fijo"})
        Me.cboModalidadCtaBancaria.Location = New System.Drawing.Point(300, 86)
        Me.cboModalidadCtaBancaria.Name = "cboModalidadCtaBancaria"
        Me.cboModalidadCtaBancaria.Size = New System.Drawing.Size(261, 21)
        Me.cboModalidadCtaBancaria.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboModalidadCtaBancaria.TabIndex = 487
        Me.cboModalidadCtaBancaria.Text = "Cuenta Corriente"
        '
        'txtNroCuentaInterbancaria
        '
        Me.txtNroCuentaInterbancaria.BackColor = System.Drawing.Color.White
        Me.txtNroCuentaInterbancaria.BeforeTouchSize = New System.Drawing.Size(259, 22)
        Me.txtNroCuentaInterbancaria.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtNroCuentaInterbancaria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNroCuentaInterbancaria.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNroCuentaInterbancaria.Location = New System.Drawing.Point(300, 186)
        Me.txtNroCuentaInterbancaria.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtNroCuentaInterbancaria.Name = "txtNroCuentaInterbancaria"
        Me.txtNroCuentaInterbancaria.NearImage = CType(resources.GetObject("txtNroCuentaInterbancaria.NearImage"), System.Drawing.Image)
        Me.txtNroCuentaInterbancaria.Size = New System.Drawing.Size(259, 22)
        Me.txtNroCuentaInterbancaria.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtNroCuentaInterbancaria.TabIndex = 489
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 6.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(298, 167)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(138, 11)
        Me.Label10.TabIndex = 488
        Me.Label10.Text = "NO. CUENTA INTERBANCARIA"
        '
        'frmModalCaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.CaptionBarHeight = 50
        Me.CaptionButtonColor = System.Drawing.Color.WhiteSmoke
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(2, 8)
        CaptionImage1.Name = "CaptionImage1"
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.White
        CaptionLabel1.Location = New System.Drawing.Point(30, 8)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(150, 24)
        CaptionLabel1.Text = "Entidad financiera"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(576, 309)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmModalCaja"
        Me.ShowIcon = False
        Me.Text = ""
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.txtCodigoCuenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCuenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBalanceInicial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumCuentaCorriente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTipoCuenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescripcion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboBanco, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.ToolStrip5.ResumeLayout(False)
        Me.ToolStrip5.PerformLayout()
        CType(Me.cboModalidadCtaBancaria, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNroCuentaInterbancaria, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout

End Sub
    Friend WithEvents QGlobalColorSchemeManager1 As Qios.DevSuite.Components.QGlobalColorSchemeManager
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents QRibbonApplicationButton1 As Qios.DevSuite.Components.Ribbon.QRibbonApplicationButton
    Friend WithEvents txtCuenta As System.Windows.Forms.TextBox
    Friend WithEvents txtCuentaID As Femiani.Forms.UI.Input.CoolTextBox
    Friend WithEvents lblEstado As System.Windows.Forms.ToolStripButton
    Friend WithEvents QRibbonLaunchBar1 As Qios.DevSuite.Components.Ribbon.QRibbonLaunchBar
    Friend WithEvents QRibbonApplicationButton2 As Qios.DevSuite.Components.Ribbon.QRibbonApplicationButton
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents GuardarToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PegarToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblIdDocumento As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboBanco As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents txtDescripcion As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboMoneda As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboTipoCuenta As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents txtNumCuentaCorriente As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents BannerTextProvider1 As Syncfusion.Windows.Forms.BannerTextProvider
    Friend WithEvents txtBalanceInicial As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFecha As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip5 As System.Windows.Forms.ToolStrip
    Friend WithEvents btGrabar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboCuenta As Syncfusion.Windows.Forms.Tools.MultiColumnComboBox
    Friend WithEvents txtCodigoCuenta As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents cboModalidadCtaBancaria As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents lblmodalidad As Label
    Friend WithEvents txtNroCuentaInterbancaria As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label10 As Label
End Class

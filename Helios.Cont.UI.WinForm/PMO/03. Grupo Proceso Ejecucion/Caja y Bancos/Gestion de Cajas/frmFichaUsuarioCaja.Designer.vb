<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFichaUsuarioCaja
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFichaUsuarioCaja))
        Dim BannerTextInfo1 As Syncfusion.Windows.Forms.BannerTextInfo = New Syncfusion.Windows.Forms.BannerTextInfo()
        Dim BannerTextInfo2 As Syncfusion.Windows.Forms.BannerTextInfo = New Syncfusion.Windows.Forms.BannerTextInfo()
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.lblEstado = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.GuardarToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.PegarToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.lblNivel = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblEstadoCaja = New System.Windows.Forms.Label()
        Me.txtFechaApertura = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDni = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.BannerTextProvider1 = New Syncfusion.Windows.Forms.BannerTextProvider(Me.components)
        Me.txtClave = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtBalanceInicial = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtBalanceInicialME = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txSaldoME = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txSaldo = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTipoCambio = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CurrencyTextBox1 = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.CurrencyTextBox3 = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.CurrencyTextBox2 = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ToolStrip1.SuspendLayout()
        Me.ToolStrip3.SuspendLayout()
        CType(Me.txtDni, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtClave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBalanceInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBalanceInicialME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txSaldoME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txSaldo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoCambio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CurrencyTextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CurrencyTextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CurrencyTextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblEstado})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 25)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(410, 25)
        Me.ToolStrip1.TabIndex = 476
        Me.ToolStrip1.Text = "ToolStrip1"
        Me.ToolStrip1.Visible = False
        '
        'lblEstado
        '
        Me.lblEstado.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblEstado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblEstado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(123, 22)
        Me.lblEstado.Text = "Estado: nueva compra."
        '
        'ToolStrip3
        '
        Me.ToolStrip3.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.ToolStrip3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GuardarToolStripButton, Me.PegarToolStripButton})
        Me.ToolStrip3.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip3.Size = New System.Drawing.Size(385, 25)
        Me.ToolStrip3.TabIndex = 477
        Me.ToolStrip3.Text = "ToolStrip3"
        '
        'GuardarToolStripButton
        '
        Me.GuardarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.GuardarToolStripButton.Font = New System.Drawing.Font("Segoe UI Semilight", 8.0!)
        Me.GuardarToolStripButton.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.GuardarToolStripButton.Image = CType(resources.GetObject("GuardarToolStripButton.Image"), System.Drawing.Image)
        Me.GuardarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.GuardarToolStripButton.Name = "GuardarToolStripButton"
        Me.GuardarToolStripButton.Size = New System.Drawing.Size(48, 22)
        Me.GuardarToolStripButton.Text = "&Aceptar"
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
        'lblNivel
        '
        Me.lblNivel.AutoSize = True
        Me.lblNivel.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblNivel.Location = New System.Drawing.Point(313, 35)
        Me.lblNivel.Name = "lblNivel"
        Me.lblNivel.Size = New System.Drawing.Size(85, 13)
        Me.lblNivel.TabIndex = 475
        Me.lblNivel.Text = "Punto de Venta."
        Me.lblNivel.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(260, 35)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 13)
        Me.Label5.TabIndex = 474
        Me.Label5.Text = "Usuario:"
        Me.Label5.Visible = False
        '
        'lblEstadoCaja
        '
        Me.lblEstadoCaja.AutoSize = True
        Me.lblEstadoCaja.Font = New System.Drawing.Font("Segoe UI", 7.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstadoCaja.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.lblEstadoCaja.Location = New System.Drawing.Point(10, 422)
        Me.lblEstadoCaja.Name = "lblEstadoCaja"
        Me.lblEstadoCaja.Size = New System.Drawing.Size(93, 12)
        Me.lblEstadoCaja.TabIndex = 467
        Me.lblEstadoCaja.Text = "Estado: Habilitado."
        Me.lblEstadoCaja.Visible = False
        '
        'txtFechaApertura
        '
        Me.txtFechaApertura.Enabled = False
        Me.txtFechaApertura.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaApertura.Location = New System.Drawing.Point(302, 59)
        Me.txtFechaApertura.Name = "txtFechaApertura"
        Me.txtFechaApertura.Size = New System.Drawing.Size(97, 20)
        Me.txtFechaApertura.TabIndex = 465
        Me.txtFechaApertura.Visible = False
        '
        'Label1
        '
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label1.Image = CType(resources.GetObject("Label1.Image"), System.Drawing.Image)
        Me.Label1.Location = New System.Drawing.Point(175, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 25)
        Me.Label1.TabIndex = 464
        '
        'txtDni
        '
        Me.txtDni.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        BannerTextInfo1.Text = "Ingresar D.N.I."
        BannerTextInfo1.Visible = True
        Me.BannerTextProvider1.SetBannerText(Me.txtDni, BannerTextInfo1)
        Me.txtDni.BeforeTouchSize = New System.Drawing.Size(141, 20)
        Me.txtDni.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.txtDni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDni.CornerRadius = 5
        Me.txtDni.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDni.Location = New System.Drawing.Point(12, 36)
        Me.txtDni.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.txtDni.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtDni.Name = "txtDni"
        Me.txtDni.Size = New System.Drawing.Size(160, 20)
        Me.txtDni.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtDni.TabIndex = 479
        '
        'txtClave
        '
        Me.txtClave.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        BannerTextInfo2.Text = "Password"
        BannerTextInfo2.Visible = True
        Me.BannerTextProvider1.SetBannerText(Me.txtClave, BannerTextInfo2)
        Me.txtClave.BeforeTouchSize = New System.Drawing.Size(141, 20)
        Me.txtClave.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.txtClave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtClave.CornerRadius = 5
        Me.txtClave.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtClave.Location = New System.Drawing.Point(12, 62)
        Me.txtClave.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.txtClave.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtClave.Name = "txtClave"
        Me.txtClave.Size = New System.Drawing.Size(160, 20)
        Me.txtClave.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtClave.TabIndex = 480
        '
        'txtBalanceInicial
        '
        Me.txtBalanceInicial.BackGroundColor = System.Drawing.SystemColors.Window
        Me.txtBalanceInicial.BeforeTouchSize = New System.Drawing.Size(141, 20)
        Me.txtBalanceInicial.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.txtBalanceInicial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBalanceInicial.CurrencySymbol = ""
        Me.txtBalanceInicial.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBalanceInicial.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtBalanceInicial.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtBalanceInicial.Location = New System.Drawing.Point(12, 126)
        Me.txtBalanceInicial.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.txtBalanceInicial.Name = "txtBalanceInicial"
        Me.txtBalanceInicial.NearImage = CType(resources.GetObject("txtBalanceInicial.NearImage"), System.Drawing.Image)
        Me.txtBalanceInicial.NullString = ""
        Me.txtBalanceInicial.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtBalanceInicial.ReadOnly = True
        Me.txtBalanceInicial.ReadOnlyBackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtBalanceInicial.Size = New System.Drawing.Size(141, 20)
        Me.txtBalanceInicial.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtBalanceInicial.TabIndex = 482
        Me.txtBalanceInicial.Text = "0.00"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 6.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(12, 107)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 11)
        Me.Label3.TabIndex = 481
        Me.Label3.Text = "BALANCE INICIAL"
        '
        'txtBalanceInicialME
        '
        Me.txtBalanceInicialME.BackGroundColor = System.Drawing.SystemColors.Window
        Me.txtBalanceInicialME.BeforeTouchSize = New System.Drawing.Size(141, 20)
        Me.txtBalanceInicialME.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.txtBalanceInicialME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBalanceInicialME.CurrencySymbol = ""
        Me.txtBalanceInicialME.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBalanceInicialME.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtBalanceInicialME.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtBalanceInicialME.Location = New System.Drawing.Point(236, 126)
        Me.txtBalanceInicialME.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.txtBalanceInicialME.Name = "txtBalanceInicialME"
        Me.txtBalanceInicialME.NearImage = CType(resources.GetObject("txtBalanceInicialME.NearImage"), System.Drawing.Image)
        Me.txtBalanceInicialME.NullString = ""
        Me.txtBalanceInicialME.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtBalanceInicialME.ReadOnly = True
        Me.txtBalanceInicialME.ReadOnlyBackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtBalanceInicialME.Size = New System.Drawing.Size(141, 20)
        Me.txtBalanceInicialME.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtBalanceInicialME.TabIndex = 484
        Me.txtBalanceInicialME.Text = "0.00"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 6.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(234, 107)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 11)
        Me.Label4.TabIndex = 485
        Me.Label4.Text = "BALANCE INICIAL (ME)"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 6.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(234, 159)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 11)
        Me.Label6.TabIndex = 489
        Me.Label6.Text = "SALDO (ME)"
        '
        'txSaldoME
        '
        Me.txSaldoME.BackGroundColor = System.Drawing.SystemColors.Window
        Me.txSaldoME.BeforeTouchSize = New System.Drawing.Size(141, 20)
        Me.txSaldoME.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.txSaldoME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txSaldoME.CurrencySymbol = ""
        Me.txSaldoME.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txSaldoME.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txSaldoME.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txSaldoME.Location = New System.Drawing.Point(236, 178)
        Me.txSaldoME.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.txSaldoME.Name = "txSaldoME"
        Me.txSaldoME.NearImage = CType(resources.GetObject("txSaldoME.NearImage"), System.Drawing.Image)
        Me.txSaldoME.NullString = ""
        Me.txSaldoME.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txSaldoME.ReadOnly = True
        Me.txSaldoME.ReadOnlyBackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txSaldoME.Size = New System.Drawing.Size(141, 20)
        Me.txSaldoME.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txSaldoME.TabIndex = 488
        Me.txSaldoME.Text = "0.00"
        '
        'txSaldo
        '
        Me.txSaldo.BackGroundColor = System.Drawing.SystemColors.Window
        Me.txSaldo.BeforeTouchSize = New System.Drawing.Size(141, 20)
        Me.txSaldo.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.txSaldo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txSaldo.CurrencySymbol = ""
        Me.txSaldo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txSaldo.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txSaldo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txSaldo.Location = New System.Drawing.Point(13, 178)
        Me.txSaldo.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.txSaldo.Name = "txSaldo"
        Me.txSaldo.NearImage = CType(resources.GetObject("txSaldo.NearImage"), System.Drawing.Image)
        Me.txSaldo.NullString = ""
        Me.txSaldo.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txSaldo.ReadOnly = True
        Me.txSaldo.ReadOnlyBackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txSaldo.Size = New System.Drawing.Size(141, 20)
        Me.txSaldo.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txSaldo.TabIndex = 487
        Me.txSaldo.Text = "0.00"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 6.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(11, 159)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 11)
        Me.Label7.TabIndex = 486
        Me.Label7.Text = "SALDO"
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.BackGroundColor = System.Drawing.SystemColors.Window
        Me.txtTipoCambio.BeforeTouchSize = New System.Drawing.Size(141, 20)
        Me.txtTipoCambio.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.txtTipoCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTipoCambio.CurrencySymbol = ""
        Me.txtTipoCambio.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTipoCambio.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTipoCambio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTipoCambio.Location = New System.Drawing.Point(163, 126)
        Me.txtTipoCambio.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.NullString = ""
        Me.txtTipoCambio.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTipoCambio.ReadOnly = True
        Me.txtTipoCambio.ReadOnlyBackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtTipoCambio.Size = New System.Drawing.Size(62, 20)
        Me.txtTipoCambio.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtTipoCambio.TabIndex = 490
        Me.txtTipoCambio.Text = "0.00"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 6.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(166, 107)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(21, 11)
        Me.Label8.TabIndex = 491
        Me.Label8.Text = "T/c."
        '
        'CurrencyTextBox1
        '
        Me.CurrencyTextBox1.BackGroundColor = System.Drawing.SystemColors.Window
        Me.CurrencyTextBox1.BeforeTouchSize = New System.Drawing.Size(141, 20)
        Me.CurrencyTextBox1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.CurrencyTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CurrencyTextBox1.CurrencySymbol = ""
        Me.CurrencyTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.CurrencyTextBox1.DecimalValue = New Decimal(New Integer() {100, 0, 0, 131072})
        Me.CurrencyTextBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CurrencyTextBox1.Location = New System.Drawing.Point(236, 185)
        Me.CurrencyTextBox1.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.CurrencyTextBox1.Name = "CurrencyTextBox1"
        Me.CurrencyTextBox1.NearImage = CType(resources.GetObject("CurrencyTextBox1.NearImage"), System.Drawing.Image)
        Me.CurrencyTextBox1.NullString = ""
        Me.CurrencyTextBox1.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CurrencyTextBox1.ReadOnly = True
        Me.CurrencyTextBox1.ReadOnlyBackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.CurrencyTextBox1.Size = New System.Drawing.Size(141, 20)
        Me.CurrencyTextBox1.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.CurrencyTextBox1.TabIndex = 484
        Me.CurrencyTextBox1.Text = "1.00"
        '
        'CurrencyTextBox3
        '
        Me.CurrencyTextBox3.BackGroundColor = System.Drawing.SystemColors.Window
        Me.CurrencyTextBox3.BeforeTouchSize = New System.Drawing.Size(141, 20)
        Me.CurrencyTextBox3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.CurrencyTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CurrencyTextBox3.CurrencySymbol = ""
        Me.CurrencyTextBox3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.CurrencyTextBox3.DecimalValue = New Decimal(New Integer() {100, 0, 0, 131072})
        Me.CurrencyTextBox3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CurrencyTextBox3.Location = New System.Drawing.Point(13, 247)
        Me.CurrencyTextBox3.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.CurrencyTextBox3.Name = "CurrencyTextBox3"
        Me.CurrencyTextBox3.NearImage = CType(resources.GetObject("CurrencyTextBox3.NearImage"), System.Drawing.Image)
        Me.CurrencyTextBox3.NullString = ""
        Me.CurrencyTextBox3.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CurrencyTextBox3.ReadOnly = True
        Me.CurrencyTextBox3.ReadOnlyBackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.CurrencyTextBox3.Size = New System.Drawing.Size(141, 20)
        Me.CurrencyTextBox3.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.CurrencyTextBox3.TabIndex = 487
        Me.CurrencyTextBox3.Text = "1.00"
        '
        'CurrencyTextBox2
        '
        Me.CurrencyTextBox2.BackGroundColor = System.Drawing.SystemColors.Window
        Me.CurrencyTextBox2.BeforeTouchSize = New System.Drawing.Size(141, 20)
        Me.CurrencyTextBox2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.CurrencyTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CurrencyTextBox2.CurrencySymbol = ""
        Me.CurrencyTextBox2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.CurrencyTextBox2.DecimalValue = New Decimal(New Integer() {100, 0, 0, 131072})
        Me.CurrencyTextBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CurrencyTextBox2.Location = New System.Drawing.Point(236, 247)
        Me.CurrencyTextBox2.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.CurrencyTextBox2.Name = "CurrencyTextBox2"
        Me.CurrencyTextBox2.NearImage = CType(resources.GetObject("CurrencyTextBox2.NearImage"), System.Drawing.Image)
        Me.CurrencyTextBox2.NullString = ""
        Me.CurrencyTextBox2.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CurrencyTextBox2.ReadOnly = True
        Me.CurrencyTextBox2.ReadOnlyBackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.CurrencyTextBox2.Size = New System.Drawing.Size(141, 20)
        Me.CurrencyTextBox2.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.CurrencyTextBox2.TabIndex = 488
        Me.CurrencyTextBox2.Text = "1.00"
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BorderColor = System.Drawing.Color.DarkGray
        Me.GradientPanel1.BorderSides = System.Windows.Forms.Border3DSide.Top
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Location = New System.Drawing.Point(12, 95)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(366, 10)
        Me.GradientPanel1.TabIndex = 492
        '
        'frmFichaUsuarioCaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.BorderThickness = 3
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.CaptionBarHeight = 50
        Me.CaptionButtonColor = System.Drawing.Color.White
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(0, 4)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(40, 40)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.White
        CaptionLabel1.Location = New System.Drawing.Point(40, 15)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(150, 24)
        CaptionLabel1.Text = "Login Usuario de Caja"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(385, 203)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtTipoCambio)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txSaldoME)
        Me.Controls.Add(Me.txSaldo)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtBalanceInicialME)
        Me.Controls.Add(Me.txtBalanceInicial)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtClave)
        Me.Controls.Add(Me.txtDni)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.ToolStrip3)
        Me.Controls.Add(Me.lblNivel)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblEstadoCaja)
        Me.Controls.Add(Me.txtFechaApertura)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFichaUsuarioCaja"
        Me.ShowIcon = False
        Me.Text = ""
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        CType(Me.txtDni, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtClave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBalanceInicial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBalanceInicialME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txSaldoME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txSaldo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoCambio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CurrencyTextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CurrencyTextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CurrencyTextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtFechaApertura As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblEstadoCaja As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblNivel As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents lblEstado As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents GuardarToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PegarToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtDni As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents BannerTextProvider1 As Syncfusion.Windows.Forms.BannerTextProvider
    Friend WithEvents txtClave As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtBalanceInicial As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtBalanceInicialME As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txSaldoME As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txSaldo As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTipoCambio As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents CurrencyTextBox1 As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents CurrencyTextBox3 As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents CurrencyTextBox2 As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
End Class

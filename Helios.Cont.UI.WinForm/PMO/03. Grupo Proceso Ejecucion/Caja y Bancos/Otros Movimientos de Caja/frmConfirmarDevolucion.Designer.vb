﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmConfirmarDevolucion
    Inherits Helios.Cont.Presentation.WinForm.frmMaster



    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConfirmarDevolucion))
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Dim CaptionLabel2 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.lblMovimiento = New System.Windows.Forms.Label()
        Me.btnConfiguracion = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.cboEntidadFinanciera = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.cboTipo = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.PanelError = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.txtCuentaCorriente = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.cboEntidad = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.cboTipoDocumento = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.txtNumOper = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.dockingManager1 = New Syncfusion.Windows.Forms.Tools.DockingManager(Me.components)
        Me.cbotipoOperacion = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.txtTipoCambio = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.txtFondoME = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.txtFondoMN = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDescripcion = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtComprobante = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.txtCF_moneda = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtCF_name = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtCF_tipo = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SaldoEFME = New Syncfusion.Windows.Forms.Tools.DoubleTextBox()
        Me.SaldoEFMN = New Syncfusion.Windows.Forms.Tools.DoubleTextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtCF_cuentaContable = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtPeriodo = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GradientPanel3 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GradientPanel4 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtAnioCompra = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.cboMesCompra = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.txtDia = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ButtonAdv5 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DigitalGauge2 = New Syncfusion.Windows.Forms.Gauge.DigitalGauge()
        Me.GradientPanel5 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.txtHora = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.GradientPanel6 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.txtRuc2 = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.txtCliente2 = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.bgwCombos = New System.ComponentModel.BackgroundWorker()
        Me.Panel7.SuspendLayout()
        CType(Me.cboEntidadFinanciera, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelError.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCuentaCorriente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboEntidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTipoDocumento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumOper, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dockingManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbotipoOperacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoCambio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFondoME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFondoMN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescripcion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCF_moneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCF_name, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCF_tipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SaldoEFME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SaldoEFMN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCF_cuentaContable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPeriodo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPeriodo.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel3.SuspendLayout()
        CType(Me.GradientPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel4.SuspendLayout()
        CType(Me.txtAnioCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboMesCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDia.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel5.SuspendLayout()
        CType(Me.txtHora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHora.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel6.SuspendLayout()
        CType(Me.txtRuc2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCliente2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.lblMovimiento)
        Me.Panel7.Controls.Add(Me.btnConfiguracion)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(805, 0)
        Me.Panel7.TabIndex = 412
        '
        'lblMovimiento
        '
        Me.lblMovimiento.AutoSize = True
        Me.lblMovimiento.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMovimiento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.lblMovimiento.Location = New System.Drawing.Point(58, 3)
        Me.lblMovimiento.Name = "lblMovimiento"
        Me.lblMovimiento.Size = New System.Drawing.Size(162, 13)
        Me.lblMovimiento.TabIndex = 402
        Me.lblMovimiento.Text = "Transferencia entre almacenes"
        '
        'btnConfiguracion
        '
        Me.btnConfiguracion.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btnConfiguracion.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.btnConfiguracion.BeforeTouchSize = New System.Drawing.Size(28, 20)
        Me.btnConfiguracion.ForeColor = System.Drawing.Color.White
        Me.btnConfiguracion.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.b_engine
        Me.btnConfiguracion.IsBackStageButton = False
        Me.btnConfiguracion.Location = New System.Drawing.Point(28, -1)
        Me.btnConfiguracion.Name = "btnConfiguracion"
        Me.btnConfiguracion.Size = New System.Drawing.Size(28, 20)
        Me.btnConfiguracion.TabIndex = 211
        Me.btnConfiguracion.TabStop = False
        Me.btnConfiguracion.UseVisualStyle = True
        '
        'cboEntidadFinanciera
        '
        Me.cboEntidadFinanciera.BackColor = System.Drawing.Color.White
        Me.cboEntidadFinanciera.BeforeTouchSize = New System.Drawing.Size(151, 21)
        Me.cboEntidadFinanciera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEntidadFinanciera.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEntidadFinanciera.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cboEntidadFinanciera.Location = New System.Drawing.Point(170, 4)
        Me.cboEntidadFinanciera.Name = "cboEntidadFinanciera"
        Me.cboEntidadFinanciera.Size = New System.Drawing.Size(151, 21)
        Me.cboEntidadFinanciera.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboEntidadFinanciera.TabIndex = 434
        '
        'cboTipo
        '
        Me.cboTipo.BackColor = System.Drawing.Color.White
        Me.cboTipo.BeforeTouchSize = New System.Drawing.Size(140, 21)
        Me.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipo.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cboTipo.Location = New System.Drawing.Point(12, 4)
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(140, 21)
        Me.cboTipo.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboTipo.TabIndex = 433
        '
        'PanelError
        '
        Me.PanelError.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.PanelError.Controls.Add(Me.PictureBox2)
        Me.PanelError.Controls.Add(Me.lblEstado)
        Me.PanelError.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelError.Location = New System.Drawing.Point(0, 0)
        Me.PanelError.Name = "PanelError"
        Me.PanelError.Size = New System.Drawing.Size(805, 22)
        Me.PanelError.TabIndex = 428
        Me.PanelError.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(786, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(19, 22)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 288
        Me.PictureBox2.TabStop = False
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.BackColor = System.Drawing.Color.Transparent
        Me.lblEstado.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblEstado.Location = New System.Drawing.Point(9, 4)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(76, 13)
        Me.lblEstado.TabIndex = 0
        Me.lblEstado.Text = "Mensaje error"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'txtCuentaCorriente
        '
        Me.txtCuentaCorriente.BackColor = System.Drawing.Color.White
        Me.txtCuentaCorriente.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtCuentaCorriente.BorderColor = System.Drawing.Color.Silver
        Me.txtCuentaCorriente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuentaCorriente.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCuentaCorriente.Location = New System.Drawing.Point(266, 62)
        Me.txtCuentaCorriente.MaxLength = 20
        Me.txtCuentaCorriente.Metrocolor = System.Drawing.Color.Silver
        Me.txtCuentaCorriente.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtCuentaCorriente.Name = "txtCuentaCorriente"
        Me.txtCuentaCorriente.Size = New System.Drawing.Size(180, 22)
        Me.txtCuentaCorriente.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtCuentaCorriente.TabIndex = 437
        '
        'cboEntidad
        '
        Me.cboEntidad.BackColor = System.Drawing.Color.White
        Me.cboEntidad.BeforeTouchSize = New System.Drawing.Size(220, 21)
        Me.cboEntidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEntidad.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEntidad.Location = New System.Drawing.Point(21, 63)
        Me.cboEntidad.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboEntidad.MetroColor = System.Drawing.Color.Silver
        Me.cboEntidad.Name = "cboEntidad"
        Me.cboEntidad.Size = New System.Drawing.Size(220, 21)
        Me.cboEntidad.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboEntidad.TabIndex = 436
        '
        'cboTipoDocumento
        '
        Me.cboTipoDocumento.BackColor = System.Drawing.Color.White
        Me.cboTipoDocumento.BeforeTouchSize = New System.Drawing.Size(220, 21)
        Me.cboTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoDocumento.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoDocumento.Location = New System.Drawing.Point(21, 36)
        Me.cboTipoDocumento.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboTipoDocumento.MetroColor = System.Drawing.Color.Silver
        Me.cboTipoDocumento.Name = "cboTipoDocumento"
        Me.cboTipoDocumento.Size = New System.Drawing.Size(220, 21)
        Me.cboTipoDocumento.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboTipoDocumento.TabIndex = 212
        Me.cboTipoDocumento.TabStop = False
        '
        'txtNumOper
        '
        Me.txtNumOper.BackColor = System.Drawing.Color.White
        Me.txtNumOper.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtNumOper.BorderColor = System.Drawing.Color.Silver
        Me.txtNumOper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumOper.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNumOper.Location = New System.Drawing.Point(266, 35)
        Me.txtNumOper.MaxLength = 20
        Me.txtNumOper.Metrocolor = System.Drawing.Color.Silver
        Me.txtNumOper.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtNumOper.Name = "txtNumOper"
        Me.txtNumOper.Size = New System.Drawing.Size(180, 22)
        Me.txtNumOper.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtNumOper.TabIndex = 211
        '
        'dockingManager1
        '
        Me.dockingManager1.ActiveCaptionFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.dockingManager1.AutoHideTabFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.dockingManager1.DockLayoutStream = CType(resources.GetObject("dockingManager1.DockLayoutStream"), System.IO.MemoryStream)
        Me.dockingManager1.DockTabFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.dockingManager1.HostControl = Me
        Me.dockingManager1.InActiveCaptionBackground = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer)))
        Me.dockingManager1.InActiveCaptionFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.dockingManager1.MetroButtonColor = System.Drawing.Color.White
        Me.dockingManager1.MetroCaptionColor = System.Drawing.Color.White
        Me.dockingManager1.MetroColor = System.Drawing.Color.FromArgb(CType(CType(137, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(137, Byte), Integer))
        Me.dockingManager1.MetroSplitterBackColor = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.dockingManager1.ReduceFlickeringInRtl = False
        Me.dockingManager1.SplitterWidth = 1
        Me.dockingManager1.ThemesEnabled = True
        Me.dockingManager1.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.dockingManager1.CaptionButtons.Add(New Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Close, "CloseButton"))
        Me.dockingManager1.CaptionButtons.Add(New Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Pin, "PinButton"))
        Me.dockingManager1.CaptionButtons.Add(New Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Maximize, "MaximizeButton"))
        Me.dockingManager1.CaptionButtons.Add(New Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Restore, "RestoreButton"))
        Me.dockingManager1.CaptionButtons.Add(New Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Menu, "MenuButton"))
        '
        'cbotipoOperacion
        '
        Me.cbotipoOperacion.BackColor = System.Drawing.Color.White
        Me.cbotipoOperacion.BeforeTouchSize = New System.Drawing.Size(263, 21)
        Me.cbotipoOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbotipoOperacion.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbotipoOperacion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cbotipoOperacion.Items.AddRange(New Object() {"", "CUENTAS EN EFECTIVO", "CUENTAS EN BANCO"})
        Me.cbotipoOperacion.Location = New System.Drawing.Point(17, 65)
        Me.cbotipoOperacion.MetroBorderColor = System.Drawing.Color.Silver
        Me.cbotipoOperacion.MetroColor = System.Drawing.Color.Silver
        Me.cbotipoOperacion.Name = "cbotipoOperacion"
        Me.cbotipoOperacion.Size = New System.Drawing.Size(263, 21)
        Me.cbotipoOperacion.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cbotipoOperacion.TabIndex = 507
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.BackColor = System.Drawing.SystemColors.Info
        Me.txtTipoCambio.BeforeTouchSize = New System.Drawing.Size(58, 21)
        Me.txtTipoCambio.BorderColor = System.Drawing.SystemColors.HotTrack
        Me.txtTipoCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTipoCambio.DecimalPlaces = 3
        Me.txtTipoCambio.Font = New System.Drawing.Font("Arial", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoCambio.InterceptArrowKeys = False
        Me.txtTipoCambio.Location = New System.Drawing.Point(131, 59)
        Me.txtTipoCambio.Maximum = New Decimal(New Integer() {-159383552, 46653770, 5421, 0})
        Me.txtTipoCambio.MetroColor = System.Drawing.SystemColors.HotTrack
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.ReadOnly = True
        Me.txtTipoCambio.Size = New System.Drawing.Size(58, 21)
        Me.txtTipoCambio.TabIndex = 400
        Me.txtTipoCambio.TabStop = False
        Me.txtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTipoCambio.ThousandsSeparator = True
        Me.txtTipoCambio.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'txtFondoME
        '
        Me.txtFondoME.BackColor = System.Drawing.Color.PaleGreen
        Me.txtFondoME.BeforeTouchSize = New System.Drawing.Size(118, 21)
        Me.txtFondoME.BorderColor = System.Drawing.SystemColors.HotTrack
        Me.txtFondoME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFondoME.DecimalPlaces = 2
        Me.txtFondoME.Font = New System.Drawing.Font("Arial", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFondoME.ForeColor = System.Drawing.Color.Black
        Me.txtFondoME.InterceptArrowKeys = False
        Me.txtFondoME.Location = New System.Drawing.Point(195, 59)
        Me.txtFondoME.Maximum = New Decimal(New Integer() {-1304428544, 434162106, 542, 0})
        Me.txtFondoME.MetroColor = System.Drawing.SystemColors.HotTrack
        Me.txtFondoME.Name = "txtFondoME"
        Me.txtFondoME.ReadOnly = True
        Me.txtFondoME.Size = New System.Drawing.Size(118, 21)
        Me.txtFondoME.TabIndex = 398
        Me.txtFondoME.TabStop = False
        Me.txtFondoME.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtFondoME.ThousandsSeparator = True
        Me.txtFondoME.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'txtFondoMN
        '
        Me.txtFondoMN.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtFondoMN.BeforeTouchSize = New System.Drawing.Size(112, 21)
        Me.txtFondoMN.BorderColor = System.Drawing.SystemColors.HotTrack
        Me.txtFondoMN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFondoMN.DecimalPlaces = 2
        Me.txtFondoMN.Font = New System.Drawing.Font("Arial", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFondoMN.ForeColor = System.Drawing.Color.Black
        Me.txtFondoMN.Location = New System.Drawing.Point(13, 59)
        Me.txtFondoMN.Maximum = New Decimal(New Integer() {-159383552, 46653770, 5421, 0})
        Me.txtFondoMN.MetroColor = System.Drawing.SystemColors.HotTrack
        Me.txtFondoMN.Name = "txtFondoMN"
        Me.txtFondoMN.Size = New System.Drawing.Size(112, 21)
        Me.txtFondoMN.TabIndex = 397
        Me.txtFondoMN.TabStop = False
        Me.txtFondoMN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtFondoMN.ThousandsSeparator = True
        Me.txtFondoMN.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(291, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 14)
        Me.Label3.TabIndex = 607
        Me.Label3.Text = "Detalle motivo"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.BackColor = System.Drawing.SystemColors.Info
        Me.txtDescripcion.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtDescripcion.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtDescripcion.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDescripcion.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcion.Location = New System.Drawing.Point(294, 37)
        Me.txtDescripcion.MaxLength = 150
        Me.txtDescripcion.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(183, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtDescripcion.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescripcion.Size = New System.Drawing.Size(409, 43)
        Me.txtDescripcion.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtDescripcion.TabIndex = 508
        Me.txtDescripcion.Text = "Ingreso por devolución de anticipo  a cuenta financiera"
        '
        'txtComprobante
        '
        Me.txtComprobante.BackColor = System.Drawing.Color.White
        Me.txtComprobante.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtComprobante.BorderColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtComprobante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComprobante.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtComprobante.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComprobante.Location = New System.Drawing.Point(17, 37)
        Me.txtComprobante.MaxLength = 20
        Me.txtComprobante.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtComprobante.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtComprobante.Name = "txtComprobante"
        Me.txtComprobante.ReadOnly = True
        Me.txtComprobante.Size = New System.Drawing.Size(263, 22)
        Me.txtComprobante.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtComprobante.TabIndex = 505
        Me.txtComprobante.Text = "COMPROBANTE DE CAJA"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.Location = New System.Drawing.Point(590, 17)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(99, 14)
        Me.LinkLabel1.TabIndex = 600
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Seleccionar cuenta"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCF_moneda
        '
        Me.txtCF_moneda.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtCF_moneda.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtCF_moneda.BorderColor = System.Drawing.Color.DarkGray
        Me.txtCF_moneda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCF_moneda.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCF_moneda.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCF_moneda.Location = New System.Drawing.Point(352, 40)
        Me.txtCF_moneda.MaxLength = 20
        Me.txtCF_moneda.Metrocolor = System.Drawing.Color.DarkGray
        Me.txtCF_moneda.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtCF_moneda.Name = "txtCF_moneda"
        Me.txtCF_moneda.ReadOnly = True
        Me.txtCF_moneda.Size = New System.Drawing.Size(114, 22)
        Me.txtCF_moneda.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtCF_moneda.TabIndex = 599
        '
        'txtCF_name
        '
        Me.txtCF_name.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtCF_name.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtCF_name.BorderColor = System.Drawing.Color.DarkGray
        Me.txtCF_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCF_name.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCF_name.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCF_name.Location = New System.Drawing.Point(135, 40)
        Me.txtCF_name.MaxLength = 20
        Me.txtCF_name.Metrocolor = System.Drawing.Color.DarkGray
        Me.txtCF_name.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtCF_name.Name = "txtCF_name"
        Me.txtCF_name.ReadOnly = True
        Me.txtCF_name.Size = New System.Drawing.Size(213, 22)
        Me.txtCF_name.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtCF_name.TabIndex = 598
        '
        'txtCF_tipo
        '
        Me.txtCF_tipo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtCF_tipo.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtCF_tipo.BorderColor = System.Drawing.Color.DarkGray
        Me.txtCF_tipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCF_tipo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCF_tipo.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCF_tipo.Location = New System.Drawing.Point(17, 40)
        Me.txtCF_tipo.MaxLength = 20
        Me.txtCF_tipo.Metrocolor = System.Drawing.Color.DarkGray
        Me.txtCF_tipo.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtCF_tipo.Name = "txtCF_tipo"
        Me.txtCF_tipo.ReadOnly = True
        Me.txtCF_tipo.Size = New System.Drawing.Size(114, 22)
        Me.txtCF_tipo.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtCF_tipo.TabIndex = 597
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label4.Location = New System.Drawing.Point(14, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(165, 14)
        Me.Label4.TabIndex = 596
        Me.Label4.Text = "Seleccionar cuenta financiera"
        '
        'SaldoEFME
        '
        Me.SaldoEFME.BackGroundColor = System.Drawing.SystemColors.Window
        Me.SaldoEFME.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.SaldoEFME.BorderColor = System.Drawing.Color.YellowGreen
        Me.SaldoEFME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SaldoEFME.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.SaldoEFME.DoubleValue = 0R
        Me.SaldoEFME.Location = New System.Drawing.Point(589, 40)
        Me.SaldoEFME.Metrocolor = System.Drawing.Color.YellowGreen
        Me.SaldoEFME.Name = "SaldoEFME"
        Me.SaldoEFME.NullString = ""
        Me.SaldoEFME.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.SaldoEFME.ReadOnly = True
        Me.SaldoEFME.Size = New System.Drawing.Size(114, 22)
        Me.SaldoEFME.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.SaldoEFME.TabIndex = 595
        Me.SaldoEFME.Text = "0.00"
        '
        'SaldoEFMN
        '
        Me.SaldoEFMN.BackGroundColor = System.Drawing.SystemColors.Window
        Me.SaldoEFMN.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.SaldoEFMN.BorderColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.SaldoEFMN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SaldoEFMN.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.SaldoEFMN.DoubleValue = 0R
        Me.SaldoEFMN.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.SaldoEFMN.Location = New System.Drawing.Point(472, 40)
        Me.SaldoEFMN.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.SaldoEFMN.Name = "SaldoEFMN"
        Me.SaldoEFMN.NullString = ""
        Me.SaldoEFMN.PositiveColor = System.Drawing.SystemColors.HotTrack
        Me.SaldoEFMN.ReadOnly = True
        Me.SaldoEFMN.Size = New System.Drawing.Size(114, 22)
        Me.SaldoEFMN.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.SaldoEFMN.TabIndex = 594
        Me.SaldoEFMN.Text = "0.00"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(353, 17)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(47, 14)
        Me.Label14.TabIndex = 593
        Me.Label14.Text = "Moneda"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(469, 17)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(76, 14)
        Me.Label15.TabIndex = 592
        Me.Label15.Text = "Disponible EF."
        '
        'txtCF_cuentaContable
        '
        Me.txtCF_cuentaContable.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtCF_cuentaContable.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtCF_cuentaContable.BorderColor = System.Drawing.Color.DarkGray
        Me.txtCF_cuentaContable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCF_cuentaContable.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCF_cuentaContable.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCF_cuentaContable.Location = New System.Drawing.Point(704, 40)
        Me.txtCF_cuentaContable.MaxLength = 20
        Me.txtCF_cuentaContable.Metrocolor = System.Drawing.Color.DarkGray
        Me.txtCF_cuentaContable.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtCF_cuentaContable.Name = "txtCF_cuentaContable"
        Me.txtCF_cuentaContable.ReadOnly = True
        Me.txtCF_cuentaContable.Size = New System.Drawing.Size(48, 22)
        Me.txtCF_cuentaContable.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtCF_cuentaContable.TabIndex = 601
        '
        'txtPeriodo
        '
        Me.txtPeriodo.BackColor = System.Drawing.SystemColors.HotTrack
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
        Me.txtPeriodo.CalendarForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPeriodo.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtPeriodo.CalendarTitleForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPeriodo.Checked = False
        Me.txtPeriodo.CustomFormat = "MMM/yyyy"
        Me.txtPeriodo.DropDownImage = Nothing
        Me.txtPeriodo.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtPeriodo.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtPeriodo.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtPeriodo.ForeColor = System.Drawing.Color.White
        Me.txtPeriodo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtPeriodo.Location = New System.Drawing.Point(403, 42)
        Me.txtPeriodo.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtPeriodo.MinValue = New Date(CType(0, Long))
        Me.txtPeriodo.Name = "txtPeriodo"
        Me.txtPeriodo.ReadOnly = True
        Me.txtPeriodo.ShowCheckBox = False
        Me.txtPeriodo.ShowDropButton = False
        Me.txtPeriodo.Size = New System.Drawing.Size(87, 20)
        Me.txtPeriodo.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtPeriodo.TabIndex = 602
        Me.txtPeriodo.Value = New Date(2016, 3, 2, 12, 27, 4, 289)
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label18.Location = New System.Drawing.Point(400, 15)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(44, 14)
        Me.Label18.TabIndex = 603
        Me.Label18.Text = "Período"
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BackgroundColor = New Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.PatternStyle.Weave, System.Drawing.Color.White, System.Drawing.Color.White)
        Me.GradientPanel1.BorderColor = System.Drawing.Color.Blue
        Me.GradientPanel1.BorderSingle = System.Windows.Forms.ButtonBorderStyle.Dotted
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.txtCF_tipo)
        Me.GradientPanel1.Controls.Add(Me.Label15)
        Me.GradientPanel1.Controls.Add(Me.Label14)
        Me.GradientPanel1.Controls.Add(Me.SaldoEFMN)
        Me.GradientPanel1.Controls.Add(Me.SaldoEFME)
        Me.GradientPanel1.Controls.Add(Me.Label4)
        Me.GradientPanel1.Controls.Add(Me.txtCF_name)
        Me.GradientPanel1.Controls.Add(Me.txtCF_cuentaContable)
        Me.GradientPanel1.Controls.Add(Me.txtCF_moneda)
        Me.GradientPanel1.Controls.Add(Me.LinkLabel1)
        Me.GradientPanel1.Location = New System.Drawing.Point(18, 138)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(786, 75)
        Me.GradientPanel1.TabIndex = 606
        '
        'GradientPanel2
        '
        Me.GradientPanel2.BackgroundColor = New Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.PatternStyle.Weave, System.Drawing.Color.White, System.Drawing.Color.White)
        Me.GradientPanel2.BorderColor = System.Drawing.Color.Blue
        Me.GradientPanel2.BorderSingle = System.Windows.Forms.ButtonBorderStyle.Dotted
        Me.GradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel2.Controls.Add(Me.Label2)
        Me.GradientPanel2.Controls.Add(Me.txtDescripcion)
        Me.GradientPanel2.Controls.Add(Me.Label3)
        Me.GradientPanel2.Controls.Add(Me.txtComprobante)
        Me.GradientPanel2.Controls.Add(Me.cbotipoOperacion)
        Me.GradientPanel2.Location = New System.Drawing.Point(18, 219)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(786, 98)
        Me.GradientPanel2.TabIndex = 607
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.Location = New System.Drawing.Point(18, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(132, 14)
        Me.Label2.TabIndex = 608
        Me.Label2.Text = "Información del motivo"
        '
        'GradientPanel3
        '
        Me.GradientPanel3.BackgroundColor = New Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.PatternStyle.Weave, System.Drawing.Color.White, System.Drawing.Color.White)
        Me.GradientPanel3.BorderColor = System.Drawing.Color.Blue
        Me.GradientPanel3.BorderSingle = System.Windows.Forms.ButtonBorderStyle.Dotted
        Me.GradientPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel3.Controls.Add(Me.Label10)
        Me.GradientPanel3.Controls.Add(Me.cboTipoDocumento)
        Me.GradientPanel3.Controls.Add(Me.txtCuentaCorriente)
        Me.GradientPanel3.Controls.Add(Me.txtNumOper)
        Me.GradientPanel3.Controls.Add(Me.cboEntidad)
        Me.GradientPanel3.Location = New System.Drawing.Point(18, 323)
        Me.GradientPanel3.Name = "GradientPanel3"
        Me.GradientPanel3.Size = New System.Drawing.Size(457, 98)
        Me.GradientPanel3.TabIndex = 608
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label10.Location = New System.Drawing.Point(18, 9)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(109, 14)
        Me.Label10.TabIndex = 608
        Me.Label10.Text = "Forma de depósito"
        '
        'GradientPanel4
        '
        Me.GradientPanel4.BackgroundColor = New Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.PatternStyle.Weave, System.Drawing.Color.White, System.Drawing.Color.White)
        Me.GradientPanel4.BorderColor = System.Drawing.Color.Blue
        Me.GradientPanel4.BorderSingle = System.Windows.Forms.ButtonBorderStyle.Dotted
        Me.GradientPanel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel4.Controls.Add(Me.Label8)
        Me.GradientPanel4.Controls.Add(Me.Label6)
        Me.GradientPanel4.Controls.Add(Me.Label9)
        Me.GradientPanel4.Controls.Add(Me.txtFondoME)
        Me.GradientPanel4.Controls.Add(Me.txtTipoCambio)
        Me.GradientPanel4.Controls.Add(Me.Label7)
        Me.GradientPanel4.Controls.Add(Me.txtFondoMN)
        Me.GradientPanel4.Location = New System.Drawing.Point(481, 323)
        Me.GradientPanel4.Name = "GradientPanel4"
        Me.GradientPanel4.Size = New System.Drawing.Size(323, 98)
        Me.GradientPanel4.TabIndex = 609
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(195, 37)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 14)
        Me.Label8.TabIndex = 611
        Me.Label8.Text = "Importe ME"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(10, 37)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 14)
        Me.Label6.TabIndex = 610
        Me.Label6.Text = "Importe MN"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(130, 37)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 14)
        Me.Label9.TabIndex = 609
        Me.Label9.Text = "tip.cambio"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label7.Location = New System.Drawing.Point(13, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(96, 14)
        Me.Label7.TabIndex = 608
        Me.Label7.Text = "Ingresar montos"
        '
        'txtAnioCompra
        '
        Me.txtAnioCompra.BackColor = System.Drawing.Color.White
        Me.txtAnioCompra.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtAnioCompra.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtAnioCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAnioCompra.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAnioCompra.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtAnioCompra.Location = New System.Drawing.Point(228, 41)
        Me.txtAnioCompra.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtAnioCompra.Name = "txtAnioCompra"
        Me.txtAnioCompra.ReadOnly = True
        Me.txtAnioCompra.Size = New System.Drawing.Size(56, 22)
        Me.txtAnioCompra.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtAnioCompra.TabIndex = 613
        Me.txtAnioCompra.Text = "2016"
        Me.txtAnioCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cboMesCompra
        '
        Me.cboMesCompra.BackColor = System.Drawing.Color.White
        Me.cboMesCompra.BeforeTouchSize = New System.Drawing.Size(152, 21)
        Me.cboMesCompra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMesCompra.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMesCompra.Location = New System.Drawing.Point(17, 42)
        Me.cboMesCompra.Name = "cboMesCompra"
        Me.cboMesCompra.Size = New System.Drawing.Size(152, 21)
        Me.cboMesCompra.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboMesCompra.TabIndex = 612
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
        Me.txtDia.Location = New System.Drawing.Point(175, 43)
        Me.txtDia.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtDia.MinValue = New Date(CType(0, Long))
        Me.txtDia.Name = "txtDia"
        Me.txtDia.ShowCheckBox = False
        Me.txtDia.ShowDropButton = False
        Me.txtDia.ShowUpDown = True
        Me.txtDia.Size = New System.Drawing.Size(50, 20)
        Me.txtDia.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtDia.TabIndex = 611
        Me.txtDia.Value = New Date(2016, 1, 1, 11, 17, 0, 0)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label5.Location = New System.Drawing.Point(14, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(109, 14)
        Me.Label5.TabIndex = 610
        Me.Label5.Text = "Fecha de Transacción"
        '
        'ButtonAdv5
        '
        Me.ButtonAdv5.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv5.BackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.ButtonAdv5.BeforeTouchSize = New System.Drawing.Size(110, 40)
        Me.ButtonAdv5.Font = New System.Drawing.Font("Corbel", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv5.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv5.IsBackStageButton = False
        Me.ButtonAdv5.Location = New System.Drawing.Point(694, 484)
        Me.ButtonAdv5.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonAdv5.Name = "ButtonAdv5"
        Me.ButtonAdv5.Size = New System.Drawing.Size(110, 40)
        Me.ButtonAdv5.TabIndex = 614
        Me.ButtonAdv5.Text = "Grabar"
        Me.ButtonAdv5.UseVisualStyle = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label1.Location = New System.Drawing.Point(610, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 14)
        Me.Label1.TabIndex = 616
        Me.Label1.Text = "MONTO   TOTAL"
        '
        'DigitalGauge2
        '
        Me.DigitalGauge2.BackgroundGradientEndColor = System.Drawing.Color.White
        Me.DigitalGauge2.BackgroundGradientStartColor = System.Drawing.Color.White
        Me.DigitalGauge2.CharacterCount = 10
        Me.DigitalGauge2.DisplayRecordIndex = 0
        Me.DigitalGauge2.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.DigitalGauge2.ForeColor = System.Drawing.Color.Gray
        Me.DigitalGauge2.Location = New System.Drawing.Point(519, 41)
        Me.DigitalGauge2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DigitalGauge2.MaximumSize = New System.Drawing.Size(583, 222)
        Me.DigitalGauge2.MinimumSize = New System.Drawing.Size(90, 90)
        Me.DigitalGauge2.Name = "DigitalGauge2"
        Me.DigitalGauge2.OuterFrameGradientEndColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.DigitalGauge2.OuterFrameGradientStartColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.DigitalGauge2.Size = New System.Drawing.Size(283, 90)
        Me.DigitalGauge2.TabIndex = 615
        Me.DigitalGauge2.Value = "0.00"
        Me.DigitalGauge2.VisualStyle = Syncfusion.Windows.Forms.Gauge.ThemeStyle.Metro
        '
        'GradientPanel5
        '
        Me.GradientPanel5.BackgroundColor = New Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.PatternStyle.Weave, System.Drawing.Color.White, System.Drawing.Color.White)
        Me.GradientPanel5.BorderColor = System.Drawing.Color.Blue
        Me.GradientPanel5.BorderSingle = System.Windows.Forms.ButtonBorderStyle.Dotted
        Me.GradientPanel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel5.Controls.Add(Me.txtHora)
        Me.GradientPanel5.Controls.Add(Me.Label5)
        Me.GradientPanel5.Controls.Add(Me.txtPeriodo)
        Me.GradientPanel5.Controls.Add(Me.Label18)
        Me.GradientPanel5.Controls.Add(Me.txtDia)
        Me.GradientPanel5.Controls.Add(Me.txtAnioCompra)
        Me.GradientPanel5.Controls.Add(Me.cboMesCompra)
        Me.GradientPanel5.Location = New System.Drawing.Point(18, 41)
        Me.GradientPanel5.Name = "GradientPanel5"
        Me.GradientPanel5.Size = New System.Drawing.Size(495, 90)
        Me.GradientPanel5.TabIndex = 617
        '
        'txtHora
        '
        Me.txtHora.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtHora.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtHora.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtHora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtHora.Calendar.AllowMultipleSelection = False
        Me.txtHora.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtHora.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHora.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtHora.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtHora.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtHora.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtHora.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtHora.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHora.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtHora.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtHora.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtHora.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtHora.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtHora.Calendar.Iso8601CalenderFormat = False
        Me.txtHora.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtHora.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtHora.Calendar.Name = "monthCalendar"
        Me.txtHora.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtHora.Calendar.SelectedDates = New Date(-1) {}
        Me.txtHora.Calendar.Size = New System.Drawing.Size(103, 174)
        Me.txtHora.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtHora.Calendar.TabIndex = 0
        Me.txtHora.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtHora.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtHora.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtHora.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtHora.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtHora.Calendar.NoneButton.IsBackStageButton = False
        Me.txtHora.Calendar.NoneButton.Location = New System.Drawing.Point(31, 0)
        Me.txtHora.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtHora.Calendar.NoneButton.Text = "None"
        Me.txtHora.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtHora.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtHora.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtHora.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtHora.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtHora.Calendar.TodayButton.IsBackStageButton = False
        Me.txtHora.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtHora.Calendar.TodayButton.Size = New System.Drawing.Size(31, 20)
        Me.txtHora.Calendar.TodayButton.Text = "Today"
        Me.txtHora.Calendar.TodayButton.UseVisualStyle = True
        Me.txtHora.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHora.CalendarForeColor = System.Drawing.SystemColors.ControlText
        Me.txtHora.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtHora.Checked = False
        Me.txtHora.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtHora.CustomFormat = "hh:mm:ss tt"
        Me.txtHora.DropDownImage = Nothing
        Me.txtHora.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtHora.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtHora.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtHora.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHora.ForeColor = System.Drawing.Color.White
        Me.txtHora.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtHora.Location = New System.Drawing.Point(290, 41)
        Me.txtHora.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtHora.MinValue = New Date(CType(0, Long))
        Me.txtHora.Name = "txtHora"
        Me.txtHora.ShowCheckBox = False
        Me.txtHora.ShowDropButton = False
        Me.txtHora.ShowUpDown = True
        Me.txtHora.Size = New System.Drawing.Size(105, 22)
        Me.txtHora.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtHora.TabIndex = 620
        Me.txtHora.Value = New Date(2016, 1, 1, 11, 17, 0, 0)
        '
        'GradientPanel6
        '
        Me.GradientPanel6.BackgroundColor = New Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.PatternStyle.Weave, System.Drawing.Color.White, System.Drawing.Color.White)
        Me.GradientPanel6.BorderColor = System.Drawing.Color.Blue
        Me.GradientPanel6.BorderSingle = System.Windows.Forms.ButtonBorderStyle.Dotted
        Me.GradientPanel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel6.Controls.Add(Me.txtRuc2)
        Me.GradientPanel6.Controls.Add(Me.Label72)
        Me.GradientPanel6.Controls.Add(Me.Label71)
        Me.GradientPanel6.Controls.Add(Me.txtCliente2)
        Me.GradientPanel6.Location = New System.Drawing.Point(18, 427)
        Me.GradientPanel6.Name = "GradientPanel6"
        Me.GradientPanel6.Size = New System.Drawing.Size(786, 51)
        Me.GradientPanel6.TabIndex = 619
        '
        'txtRuc2
        '
        Me.txtRuc2.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.txtRuc2.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtRuc2.BorderColor = System.Drawing.Color.Silver
        Me.txtRuc2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRuc2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRuc2.Enabled = False
        Me.txtRuc2.Location = New System.Drawing.Point(351, 22)
        Me.txtRuc2.Metrocolor = System.Drawing.Color.Silver
        Me.txtRuc2.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtRuc2.Name = "txtRuc2"
        Me.txtRuc2.ReadOnly = True
        Me.txtRuc2.Size = New System.Drawing.Size(96, 22)
        Me.txtRuc2.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtRuc2.TabIndex = 511
        '
        'Label72
        '
        Me.Label72.AutoSize = True
        Me.Label72.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label72.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label72.Location = New System.Drawing.Point(18, 6)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(71, 14)
        Me.Label72.TabIndex = 508
        Me.Label72.Text = "Información"
        '
        'Label71
        '
        Me.Label71.AutoSize = True
        Me.Label71.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label71.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label71.Location = New System.Drawing.Point(354, 5)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(29, 14)
        Me.Label71.TabIndex = 510
        Me.Label71.Text = "RUC"
        '
        'txtCliente2
        '
        Me.txtCliente2.BackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.txtCliente2.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtCliente2.BorderColor = System.Drawing.Color.Silver
        Me.txtCliente2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCliente2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCliente2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCliente2.Enabled = False
        Me.txtCliente2.Location = New System.Drawing.Point(21, 22)
        Me.txtCliente2.Metrocolor = System.Drawing.Color.Silver
        Me.txtCliente2.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtCliente2.Name = "txtCliente2"
        Me.txtCliente2.NearImage = CType(resources.GetObject("txtCliente2.NearImage"), System.Drawing.Image)
        Me.txtCliente2.ReadOnly = True
        Me.txtCliente2.Size = New System.Drawing.Size(325, 22)
        Me.txtCliente2.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtCliente2.TabIndex = 509
        '
        'bgwCombos
        '
        '
        'frmConfirmarDevolucion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.SystemColors.HotTrack
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CaptionBarHeight = 50
        Me.CaptionButtonColor = System.Drawing.SystemColors.HotTrack
        Me.CaptionButtonHoverColor = System.Drawing.SystemColors.HotTrack
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(15, 10)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(40, 40)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.SystemColors.HotTrack
        CaptionLabel1.Location = New System.Drawing.Point(55, 8)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(220, 24)
        CaptionLabel1.Text = "Devolución de dinero"
        CaptionLabel2.Font = New System.Drawing.Font("Ebrima", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel2.ForeColor = System.Drawing.Color.DimGray
        CaptionLabel2.Location = New System.Drawing.Point(55, 23)
        CaptionLabel2.Name = "CaptionLabel2"
        CaptionLabel2.Text = "Confirmar"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.CaptionLabels.Add(CaptionLabel2)
        Me.ClientSize = New System.Drawing.Size(805, 524)
        Me.Controls.Add(Me.GradientPanel6)
        Me.Controls.Add(Me.GradientPanel5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DigitalGauge2)
        Me.Controls.Add(Me.ButtonAdv5)
        Me.Controls.Add(Me.GradientPanel4)
        Me.Controls.Add(Me.GradientPanel3)
        Me.Controls.Add(Me.GradientPanel2)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.PanelError)
        Me.Controls.Add(Me.Panel7)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConfirmarDevolucion"
        Me.ShowIcon = False
        Me.Text = ""
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        CType(Me.cboEntidadFinanciera, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelError.ResumeLayout(False)
        Me.PanelError.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCuentaCorriente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboEntidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTipoDocumento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumOper, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dockingManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbotipoOperacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoCambio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFondoME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFondoMN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescripcion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtComprobante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCF_moneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCF_name, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCF_tipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SaldoEFME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SaldoEFMN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCF_cuentaContable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPeriodo.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPeriodo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        Me.GradientPanel2.PerformLayout()
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel3.ResumeLayout(False)
        Me.GradientPanel3.PerformLayout()
        CType(Me.GradientPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel4.ResumeLayout(False)
        Me.GradientPanel4.PerformLayout()
        CType(Me.txtAnioCompra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboMesCompra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDia.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel5.ResumeLayout(False)
        Me.GradientPanel5.PerformLayout()
        CType(Me.txtHora.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel6.ResumeLayout(False)
        Me.GradientPanel6.PerformLayout()
        CType(Me.txtRuc2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCliente2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents lblIdDocumento As System.Windows.Forms.ToolStripLabel
    Friend WithEvents PanelError As System.Windows.Forms.Panel
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents cboTipo As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents cboEntidadFinanciera As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents txtCuentaCorriente As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents cboEntidad As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents cboTipoDocumento As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents txtNumOper As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Private WithEvents dockingManager1 As Syncfusion.Windows.Forms.Tools.DockingManager
    Friend WithEvents cbotipoOperacion As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents txtTipoCambio As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents txtFondoME As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents txtFondoMN As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents txtCF_moneda As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtCF_name As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtCF_tipo As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label4 As Label
    Friend WithEvents SaldoEFME As Syncfusion.Windows.Forms.Tools.DoubleTextBox
    Friend WithEvents SaldoEFMN As Syncfusion.Windows.Forms.Tools.DoubleTextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents txtCF_cuentaContable As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtPeriodo As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents Label18 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtDescripcion As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtComprobante As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Private WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Private WithEvents GradientPanel2 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents Label2 As Label
    Private WithEvents GradientPanel3 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents Label10 As Label
    Private WithEvents GradientPanel4 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents Label7 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtAnioCompra As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents cboMesCompra As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents txtDia As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents Label5 As Label
    Friend WithEvents ButtonAdv5 As Syncfusion.Windows.Forms.ButtonAdv
    Private WithEvents GradientPanel5 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DigitalGauge2 As Syncfusion.Windows.Forms.Gauge.DigitalGauge
    Private WithEvents GradientPanel6 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents txtRuc2 As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label72 As System.Windows.Forms.Label
    Friend WithEvents Label71 As System.Windows.Forms.Label
    Friend WithEvents txtCliente2 As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtHora As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents Label8 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents bgwCombos As System.ComponentModel.BackgroundWorker
    Friend WithEvents lblMovimiento As Label
    Friend WithEvents btnConfiguracion As Syncfusion.Windows.Forms.ButtonAdv
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSalidaAnticipo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSalidaAnticipo))
        Dim BannerTextInfo1 As Syncfusion.Windows.Forms.BannerTextInfo = New Syncfusion.Windows.Forms.BannerTextInfo()
        Me.PanelError = New System.Windows.Forms.Panel()
        Me.lblIdDocumento = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.txtProveedor = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtVoucher = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dropDownBtn = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.popupControlContainer1 = New Syncfusion.Windows.Forms.PopupControlContainer()
        Me.lsvProveedor = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cancel = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.OK = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.GradientPanel3 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.txtAnticipoME = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtAnticipoMN = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtMontoCobrarME = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMontoCobrarMN = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtTipoCambio = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.nudMonedaExtranjero = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.nudMonedaNacional = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.DigitalGauge2 = New Syncfusion.Windows.Forms.Gauge.DigitalGauge()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.BannerTextProvider1 = New Syncfusion.Windows.Forms.BannerTextProvider(Me.components)
        Me.PanelError.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.txtProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVoucher, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.popupControlContainer1.SuspendLayout()
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel3.SuspendLayout()
        CType(Me.txtAnticipoME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAnticipoMN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMontoCobrarME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMontoCobrarMN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoCambio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudMonedaExtranjero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudMonedaNacional, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelError
        '
        Me.PanelError.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PanelError.Controls.Add(Me.lblIdDocumento)
        Me.PanelError.Controls.Add(Me.PictureBox2)
        Me.PanelError.Controls.Add(Me.lblEstado)
        Me.PanelError.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelError.Location = New System.Drawing.Point(0, 89)
        Me.PanelError.Name = "PanelError"
        Me.PanelError.Size = New System.Drawing.Size(362, 25)
        Me.PanelError.TabIndex = 426
        '
        'lblIdDocumento
        '
        Me.lblIdDocumento.AutoSize = True
        Me.lblIdDocumento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblIdDocumento.Location = New System.Drawing.Point(586, 4)
        Me.lblIdDocumento.Name = "lblIdDocumento"
        Me.lblIdDocumento.Size = New System.Drawing.Size(98, 13)
        Me.lblIdDocumento.TabIndex = 224
        Me.lblIdDocumento.Text = "Fecha de anticipo"
        '
        'PictureBox2
        '
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(343, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(19, 25)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 288
        Me.PictureBox2.TabStop = False
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.BackColor = System.Drawing.Color.Transparent
        Me.lblEstado.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblEstado.Location = New System.Drawing.Point(9, 4)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(79, 13)
        Me.lblEstado.TabIndex = 0
        Me.lblEstado.Text = "Mensaje error"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Location = New System.Drawing.Point(0, 89)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(361, 24)
        Me.Panel2.TabIndex = 429
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label4.Location = New System.Drawing.Point(10, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(194, 19)
        Me.Label4.TabIndex = 170
        Me.Label4.Text = "Buscar cliente:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BackColor = System.Drawing.Color.White
        Me.GradientPanel1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.txtProveedor)
        Me.GradientPanel1.Controls.Add(Me.txtVoucher)
        Me.GradientPanel1.Controls.Add(Me.Label9)
        Me.GradientPanel1.Controls.Add(Me.dropDownBtn)
        Me.GradientPanel1.Controls.Add(Me.popupControlContainer1)
        Me.GradientPanel1.Location = New System.Drawing.Point(1, 116)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(361, 37)
        Me.GradientPanel1.TabIndex = 432
        '
        'txtProveedor
        '
        Me.txtProveedor.BackColor = System.Drawing.Color.White
        BannerTextInfo1.Text = "Buscar Cliente"
        BannerTextInfo1.Visible = True
        Me.BannerTextProvider1.SetBannerText(Me.txtProveedor, BannerTextInfo1)
        Me.txtProveedor.BeforeTouchSize = New System.Drawing.Size(157, 22)
        Me.txtProveedor.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProveedor.CornerRadius = 5
        Me.txtProveedor.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtProveedor.Location = New System.Drawing.Point(13, 7)
        Me.txtProveedor.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtProveedor.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.NearImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.IC6329681
        Me.txtProveedor.Size = New System.Drawing.Size(311, 22)
        Me.txtProveedor.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtProveedor.TabIndex = 428
        '
        'txtVoucher
        '
        Me.txtVoucher.BackColor = System.Drawing.Color.White
        Me.txtVoucher.BeforeTouchSize = New System.Drawing.Size(157, 22)
        Me.txtVoucher.BorderColor = System.Drawing.Color.YellowGreen
        Me.txtVoucher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVoucher.CornerRadius = 5
        Me.txtVoucher.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtVoucher.Location = New System.Drawing.Point(102, 35)
        Me.txtVoucher.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtVoucher.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtVoucher.Name = "txtVoucher"
        Me.txtVoucher.NearImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.IC6329681
        Me.txtVoucher.Size = New System.Drawing.Size(157, 22)
        Me.txtVoucher.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtVoucher.TabIndex = 427
        '
        'Label9
        '
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label9.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label9.Location = New System.Drawing.Point(10, 31)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(86, 23)
        Me.Label9.TabIndex = 219
        Me.Label9.Text = "Nro. voucher:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dropDownBtn
        '
        Me.dropDownBtn.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.dropDownBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.dropDownBtn.BeforeTouchSize = New System.Drawing.Size(26, 19)
        Me.dropDownBtn.ForeColor = System.Drawing.Color.White
        Me.dropDownBtn.Image = CType(resources.GetObject("dropDownBtn.Image"), System.Drawing.Image)
        Me.dropDownBtn.IsBackStageButton = False
        Me.dropDownBtn.Location = New System.Drawing.Point(330, 7)
        Me.dropDownBtn.Name = "dropDownBtn"
        Me.dropDownBtn.Size = New System.Drawing.Size(26, 19)
        Me.dropDownBtn.TabIndex = 207
        Me.dropDownBtn.UseVisualStyle = True
        Me.dropDownBtn.Visible = False
        '
        'popupControlContainer1
        '
        Me.popupControlContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.popupControlContainer1.Controls.Add(Me.lsvProveedor)
        Me.popupControlContainer1.Controls.Add(Me.cancel)
        Me.popupControlContainer1.Controls.Add(Me.OK)
        Me.popupControlContainer1.Location = New System.Drawing.Point(5, 70)
        Me.popupControlContainer1.Name = "popupControlContainer1"
        Me.popupControlContainer1.Size = New System.Drawing.Size(279, 147)
        Me.popupControlContainer1.TabIndex = 201
        Me.popupControlContainer1.Visible = False
        '
        'lsvProveedor
        '
        Me.lsvProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lsvProveedor.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lsvProveedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvProveedor.FullRowSelect = True
        Me.lsvProveedor.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lsvProveedor.Location = New System.Drawing.Point(0, 0)
        Me.lsvProveedor.MultiSelect = False
        Me.lsvProveedor.Name = "lsvProveedor"
        Me.lsvProveedor.Size = New System.Drawing.Size(277, 145)
        Me.lsvProveedor.TabIndex = 3
        Me.lsvProveedor.UseCompatibleStateImageBehavior = False
        Me.lsvProveedor.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "IdProveedor"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Proveedor"
        Me.ColumnHeader2.Width = 250
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Cuenta"
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Numero"
        '
        'cancel
        '
        Me.cancel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cancel.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.cancel.BackColor = System.Drawing.SystemColors.Highlight
        Me.cancel.BeforeTouchSize = New System.Drawing.Size(60, 21)
        Me.cancel.ForeColor = System.Drawing.Color.White
        Me.cancel.IsBackStageButton = False
        Me.cancel.Location = New System.Drawing.Point(65, 120)
        Me.cancel.Name = "cancel"
        Me.cancel.Size = New System.Drawing.Size(60, 21)
        Me.cancel.TabIndex = 2
        Me.cancel.Text = "Cancel"
        Me.cancel.UseVisualStyle = True
        '
        'OK
        '
        Me.OK.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OK.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.OK.BackColor = System.Drawing.SystemColors.Highlight
        Me.OK.BeforeTouchSize = New System.Drawing.Size(59, 21)
        Me.OK.ForeColor = System.Drawing.Color.White
        Me.OK.IsBackStageButton = False
        Me.OK.Location = New System.Drawing.Point(5, 120)
        Me.OK.Name = "OK"
        Me.OK.Size = New System.Drawing.Size(59, 21)
        Me.OK.TabIndex = 1
        Me.OK.Text = "OK"
        Me.OK.UseVisualStyle = True
        '
        'GradientPanel3
        '
        Me.GradientPanel3.BackColor = System.Drawing.Color.White
        Me.GradientPanel3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.GradientPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel3.Controls.Add(Me.txtAnticipoME)
        Me.GradientPanel3.Controls.Add(Me.Label5)
        Me.GradientPanel3.Controls.Add(Me.txtAnticipoMN)
        Me.GradientPanel3.Controls.Add(Me.Label6)
        Me.GradientPanel3.Controls.Add(Me.txtMontoCobrarME)
        Me.GradientPanel3.Controls.Add(Me.Label2)
        Me.GradientPanel3.Controls.Add(Me.txtMontoCobrarMN)
        Me.GradientPanel3.Controls.Add(Me.Label3)
        Me.GradientPanel3.Controls.Add(Me.Label13)
        Me.GradientPanel3.Controls.Add(Me.txtTipoCambio)
        Me.GradientPanel3.Controls.Add(Me.nudMonedaExtranjero)
        Me.GradientPanel3.Controls.Add(Me.Label12)
        Me.GradientPanel3.Controls.Add(Me.nudMonedaNacional)
        Me.GradientPanel3.Controls.Add(Me.Label10)
        Me.GradientPanel3.Controls.Add(Me.Label35)
        Me.GradientPanel3.Location = New System.Drawing.Point(2, 186)
        Me.GradientPanel3.Name = "GradientPanel3"
        Me.GradientPanel3.Size = New System.Drawing.Size(361, 118)
        Me.GradientPanel3.TabIndex = 436
        '
        'txtAnticipoME
        '
        Me.txtAnticipoME.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.txtAnticipoME.BeforeTouchSize = New System.Drawing.Size(99, 22)
        Me.txtAnticipoME.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtAnticipoME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAnticipoME.DecimalPlaces = 2
        Me.txtAnticipoME.Enabled = False
        Me.txtAnticipoME.Location = New System.Drawing.Point(257, 83)
        Me.txtAnticipoME.Maximum = New Decimal(New Integer() {-559939584, 902409669, 54, 0})
        Me.txtAnticipoME.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtAnticipoME.Name = "txtAnticipoME"
        Me.txtAnticipoME.Size = New System.Drawing.Size(99, 22)
        Me.txtAnticipoME.TabIndex = 409
        Me.txtAnticipoME.ThousandsSeparator = True
        Me.txtAnticipoME.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(195, 86)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 13)
        Me.Label5.TabIndex = 408
        Me.Label5.Text = "Importe ME.:"
        '
        'txtAnticipoMN
        '
        Me.txtAnticipoMN.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.txtAnticipoMN.BeforeTouchSize = New System.Drawing.Size(99, 22)
        Me.txtAnticipoMN.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtAnticipoMN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAnticipoMN.DecimalPlaces = 2
        Me.txtAnticipoMN.Location = New System.Drawing.Point(90, 83)
        Me.txtAnticipoMN.Maximum = New Decimal(New Integer() {1661992960, 1808227885, 5, 0})
        Me.txtAnticipoMN.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtAnticipoMN.Name = "txtAnticipoMN"
        Me.txtAnticipoMN.Size = New System.Drawing.Size(99, 22)
        Me.txtAnticipoMN.TabIndex = 407
        Me.txtAnticipoMN.ThousandsSeparator = True
        Me.txtAnticipoMN.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(-2, 86)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 13)
        Me.Label6.TabIndex = 406
        Me.Label6.Text = "Anticipo x pagar:"
        '
        'txtMontoCobrarME
        '
        Me.txtMontoCobrarME.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.txtMontoCobrarME.BeforeTouchSize = New System.Drawing.Size(99, 22)
        Me.txtMontoCobrarME.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtMontoCobrarME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMontoCobrarME.DecimalPlaces = 2
        Me.txtMontoCobrarME.Enabled = False
        Me.txtMontoCobrarME.Location = New System.Drawing.Point(257, 57)
        Me.txtMontoCobrarME.Maximum = New Decimal(New Integer() {-559939584, 902409669, 54, 0})
        Me.txtMontoCobrarME.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtMontoCobrarME.Name = "txtMontoCobrarME"
        Me.txtMontoCobrarME.Size = New System.Drawing.Size(99, 22)
        Me.txtMontoCobrarME.TabIndex = 405
        Me.txtMontoCobrarME.ThousandsSeparator = True
        Me.txtMontoCobrarME.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Yellow
        Me.Label2.Location = New System.Drawing.Point(195, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 404
        Me.Label2.Text = "Importe ME.:"
        '
        'txtMontoCobrarMN
        '
        Me.txtMontoCobrarMN.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.txtMontoCobrarMN.BeforeTouchSize = New System.Drawing.Size(99, 22)
        Me.txtMontoCobrarMN.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtMontoCobrarMN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMontoCobrarMN.DecimalPlaces = 2
        Me.txtMontoCobrarMN.Enabled = False
        Me.txtMontoCobrarMN.Location = New System.Drawing.Point(90, 57)
        Me.txtMontoCobrarMN.Maximum = New Decimal(New Integer() {1661992960, 1808227885, 5, 0})
        Me.txtMontoCobrarMN.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtMontoCobrarMN.Name = "txtMontoCobrarMN"
        Me.txtMontoCobrarMN.Size = New System.Drawing.Size(99, 22)
        Me.txtMontoCobrarMN.TabIndex = 403
        Me.txtMontoCobrarMN.ThousandsSeparator = True
        Me.txtMontoCobrarMN.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Yellow
        Me.Label3.Location = New System.Drawing.Point(3, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 402
        Me.Label3.Text = "Monto x cobrar:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(58, 7)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(26, 13)
        Me.Label13.TabIndex = 401
        Me.Label13.Text = "t/c.:"
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.txtTipoCambio.BeforeTouchSize = New System.Drawing.Size(73, 22)
        Me.txtTipoCambio.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTipoCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTipoCambio.DecimalPlaces = 2
        Me.txtTipoCambio.Enabled = False
        Me.txtTipoCambio.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoCambio.Location = New System.Drawing.Point(90, 3)
        Me.txtTipoCambio.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.Size = New System.Drawing.Size(73, 22)
        Me.txtTipoCambio.TabIndex = 400
        Me.txtTipoCambio.ThousandsSeparator = True
        Me.txtTipoCambio.Value = New Decimal(New Integer() {3, 0, 0, 0})
        Me.txtTipoCambio.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'nudMonedaExtranjero
        '
        Me.nudMonedaExtranjero.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.nudMonedaExtranjero.BeforeTouchSize = New System.Drawing.Size(99, 22)
        Me.nudMonedaExtranjero.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.nudMonedaExtranjero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nudMonedaExtranjero.DecimalPlaces = 2
        Me.nudMonedaExtranjero.Enabled = False
        Me.nudMonedaExtranjero.Location = New System.Drawing.Point(257, 31)
        Me.nudMonedaExtranjero.Maximum = New Decimal(New Integer() {-559939584, 902409669, 54, 0})
        Me.nudMonedaExtranjero.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.nudMonedaExtranjero.Name = "nudMonedaExtranjero"
        Me.nudMonedaExtranjero.Size = New System.Drawing.Size(99, 22)
        Me.nudMonedaExtranjero.TabIndex = 399
        Me.nudMonedaExtranjero.ThousandsSeparator = True
        Me.nudMonedaExtranjero.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(195, 34)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(69, 13)
        Me.Label12.TabIndex = 398
        Me.Label12.Text = "Fondo M.E.:"
        '
        'nudMonedaNacional
        '
        Me.nudMonedaNacional.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.nudMonedaNacional.BeforeTouchSize = New System.Drawing.Size(99, 22)
        Me.nudMonedaNacional.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.nudMonedaNacional.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nudMonedaNacional.DecimalPlaces = 2
        Me.nudMonedaNacional.Enabled = False
        Me.nudMonedaNacional.Location = New System.Drawing.Point(90, 31)
        Me.nudMonedaNacional.Maximum = New Decimal(New Integer() {1661992960, 1808227885, 5, 0})
        Me.nudMonedaNacional.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.nudMonedaNacional.Name = "nudMonedaNacional"
        Me.nudMonedaNacional.Size = New System.Drawing.Size(99, 22)
        Me.nudMonedaNacional.TabIndex = 397
        Me.nudMonedaNacional.ThousandsSeparator = True
        Me.nudMonedaNacional.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(24, 34)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(68, 13)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Fondo MN.:"
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.Color.Yellow
        Me.Label35.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label35.Location = New System.Drawing.Point(-2, 57)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(367, 20)
        Me.Label35.TabIndex = 422
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.Panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel4.Controls.Add(Me.Label8)
        Me.Panel4.Location = New System.Drawing.Point(2, 160)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(361, 24)
        Me.Panel4.TabIndex = 435
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label8.Location = New System.Drawing.Point(5, 3)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(194, 19)
        Me.Label8.TabIndex = 170
        Me.Label8.Text = "Fondo de anticipo:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GradientPanel2
        '
        Me.GradientPanel2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.GradientPanel2.BorderColor = System.Drawing.Color.White
        Me.GradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel2.Controls.Add(Me.DigitalGauge2)
        Me.GradientPanel2.Controls.Add(Me.PictureBox6)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(362, 89)
        Me.GradientPanel2.TabIndex = 437
        '
        'DigitalGauge2
        '
        Me.DigitalGauge2.BackgroundGradientEndColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.DigitalGauge2.BackgroundGradientStartColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.DigitalGauge2.CharacterCount = 8
        Me.DigitalGauge2.CharacterType = Syncfusion.Windows.Forms.Gauge.CharacterType.FourteenSegment
        Me.DigitalGauge2.DisplayRecordIndex = 0
        Me.DigitalGauge2.Dock = System.Windows.Forms.DockStyle.Right
        Me.DigitalGauge2.ForeColor = System.Drawing.Color.Gray
        Me.DigitalGauge2.Location = New System.Drawing.Point(192, 0)
        Me.DigitalGauge2.MaximumSize = New System.Drawing.Size(500, 180)
        Me.DigitalGauge2.MinimumSize = New System.Drawing.Size(90, 90)
        Me.DigitalGauge2.Name = "DigitalGauge2"
        Me.DigitalGauge2.Size = New System.Drawing.Size(168, 90)
        Me.DigitalGauge2.TabIndex = 410
        Me.DigitalGauge2.Value = "0.00"
        Me.DigitalGauge2.VisualStyle = Syncfusion.Windows.Forms.Gauge.ThemeStyle.Silver
        '
        'PictureBox6
        '
        Me.PictureBox6.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.PictureBox6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(1, 28)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(53, 43)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox6.TabIndex = 2
        Me.PictureBox6.TabStop = False
        '
        'frmSalidaAnticipo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.CaptionForeColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(362, 306)
        Me.Controls.Add(Me.PanelError)
        Me.Controls.Add(Me.GradientPanel2)
        Me.Controls.Add(Me.GradientPanel3)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSalidaAnticipo"
        Me.ShowIcon = False
        Me.Text = "Anticipo"
        Me.PanelError.ResumeLayout(False)
        Me.PanelError.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        CType(Me.txtProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVoucher, System.ComponentModel.ISupportInitialize).EndInit()
        Me.popupControlContainer1.ResumeLayout(False)
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel3.ResumeLayout(False)
        Me.GradientPanel3.PerformLayout()
        CType(Me.txtAnticipoME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAnticipoMN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMontoCobrarME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMontoCobrarMN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoCambio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudMonedaExtranjero, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudMonedaNacional, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelError As System.Windows.Forms.Panel
    Friend WithEvents lblIdDocumento As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Private WithEvents Panel2 As System.Windows.Forms.Panel
    Private WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents txtVoucher As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Private WithEvents dropDownBtn As Syncfusion.Windows.Forms.ButtonAdv
    Private WithEvents popupControlContainer1 As Syncfusion.Windows.Forms.PopupControlContainer
    Friend WithEvents lsvProveedor As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Private WithEvents cancel As Syncfusion.Windows.Forms.ButtonAdv
    Private WithEvents OK As Syncfusion.Windows.Forms.ButtonAdv
    Private WithEvents GradientPanel3 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtTipoCambio As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents nudMonedaExtranjero As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents nudMonedaNacional As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Private WithEvents Panel4 As System.Windows.Forms.Panel
    Private WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtMontoCobrarME As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMontoCobrarMN As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtAnticipoME As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtAnticipoMN As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Private WithEvents GradientPanel2 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents DigitalGauge2 As Syncfusion.Windows.Forms.Gauge.DigitalGauge
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents txtProveedor As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents BannerTextProvider1 As Syncfusion.Windows.Forms.BannerTextProvider
End Class

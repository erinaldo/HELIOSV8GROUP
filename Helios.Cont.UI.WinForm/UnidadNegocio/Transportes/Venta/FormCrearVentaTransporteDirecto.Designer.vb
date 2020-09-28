Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormCrearVentaTransporteDirecto
    Inherits MetroForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCrearVentaTransporteDirecto))
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.QrCodeImgControl1 = New Gma.QrCodeNet.Encoding.Windows.Forms.QrCodeImgControl()
        Me.RoundButton21 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.BtConfirmarVenta = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextCiudadDestino = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextDestinoUbigeo = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextOrigenUbigeo = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextCiudadOrigen = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextNombres = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextTipoDocIdentidad = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextCodigoIdentidad = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.textEdad = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextNumIdent = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar()
        Me.txtFecha = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboMoneda = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.cboTipoDoc = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.GradientPanel3 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.TextRaZonSocial = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextCodigoComprobanteRazon = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextTipoDocIdentidadRazon = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextRuc = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GradientPanel6 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.txtTotalPagar = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.GradientPanel4 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.TextTotalDescuentos = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtTotalBase = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtTotalBase2 = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtTotalBase3 = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtTotalIva = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.lblTotalPercepcion = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.LabelfechaProg = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.GradientPanel5 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.txtHora = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.GradientPanel7 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.LabelAsientoSel = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.GradientPanel8 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.txtNroImpresion = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtFormato = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.ComboBox1 = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboFormato = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog()
        Me.Panel11.SuspendLayout()
        CType(Me.QrCodeImgControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextCiudadDestino, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextDestinoUbigeo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextOrigenUbigeo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextCiudadOrigen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextNombres, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextTipoDocIdentidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextCodigoIdentidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.textEdad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextNumIdent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTipoDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel3.SuspendLayout()
        CType(Me.TextRaZonSocial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextCodigoComprobanteRazon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextTipoDocIdentidadRazon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextRuc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.GradientPanel6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel6.SuspendLayout()
        CType(Me.txtTotalPagar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel4.SuspendLayout()
        CType(Me.TextTotalDescuentos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalBase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalBase2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalBase3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalIva, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTotalPercepcion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.GradientPanel5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel5.SuspendLayout()
        CType(Me.txtHora, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.GradientPanel7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel7.SuspendLayout()
        CType(Me.LabelAsientoSel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel8.SuspendLayout()
        CType(Me.txtNroImpresion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFormato, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboFormato, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.White
        Me.Panel11.Controls.Add(Me.QrCodeImgControl1)
        Me.Panel11.Controls.Add(Me.RoundButton21)
        Me.Panel11.Controls.Add(Me.BtConfirmarVenta)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel11.Location = New System.Drawing.Point(0, 0)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(614, 48)
        Me.Panel11.TabIndex = 504
        '
        'QrCodeImgControl1
        '
        Me.QrCodeImgControl1.ErrorCorrectLevel = Gma.QrCodeNet.Encoding.ErrorCorrectionLevel.M
        Me.QrCodeImgControl1.Image = CType(resources.GetObject("QrCodeImgControl1.Image"), System.Drawing.Image)
        Me.QrCodeImgControl1.Location = New System.Drawing.Point(268, -63)
        Me.QrCodeImgControl1.Name = "QrCodeImgControl1"
        Me.QrCodeImgControl1.QuietZoneModule = Gma.QrCodeNet.Encoding.Windows.Render.QuietZoneModules.Two
        Me.QrCodeImgControl1.Size = New System.Drawing.Size(79, 64)
        Me.QrCodeImgControl1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.QrCodeImgControl1.TabIndex = 642
        Me.QrCodeImgControl1.TabStop = False
        Me.QrCodeImgControl1.Text = "QrCodeImgControl1"
        Me.QrCodeImgControl1.Visible = False
        '
        'RoundButton21
        '
        Me.RoundButton21.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton21.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.RoundButton21.BeforeTouchSize = New System.Drawing.Size(153, 30)
        Me.RoundButton21.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.RoundButton21.ForeColor = System.Drawing.Color.White
        Me.RoundButton21.IsBackStageButton = False
        Me.RoundButton21.Location = New System.Drawing.Point(169, 9)
        Me.RoundButton21.MetroColor = System.Drawing.Color.IndianRed
        Me.RoundButton21.Name = "RoundButton21"
        Me.RoundButton21.Size = New System.Drawing.Size(153, 30)
        Me.RoundButton21.TabIndex = 605
        Me.RoundButton21.Text = "Cancelar"
        Me.RoundButton21.UseVisualStyle = True
        '
        'BtConfirmarVenta
        '
        Me.BtConfirmarVenta.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.BtConfirmarVenta.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(89, Byte), Integer))
        Me.BtConfirmarVenta.BeforeTouchSize = New System.Drawing.Size(153, 30)
        Me.BtConfirmarVenta.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.BtConfirmarVenta.ForeColor = System.Drawing.Color.White
        Me.BtConfirmarVenta.IsBackStageButton = False
        Me.BtConfirmarVenta.Location = New System.Drawing.Point(12, 9)
        Me.BtConfirmarVenta.MetroColor = System.Drawing.SystemColors.Highlight
        Me.BtConfirmarVenta.Name = "BtConfirmarVenta"
        Me.BtConfirmarVenta.Size = New System.Drawing.Size(153, 30)
        Me.BtConfirmarVenta.TabIndex = 604
        Me.BtConfirmarVenta.Text = "Confirmar venta"
        Me.BtConfirmarVenta.UseVisualStyle = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label3.Location = New System.Drawing.Point(17, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 17)
        Me.Label3.TabIndex = 583
        Me.Label3.Text = "Datos del Servicio"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(300, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(173, 13)
        Me.Label2.TabIndex = 586
        Me.Label2.Text = "Ciudad o lugar de destino (Ubigeo)"
        '
        'TextCiudadDestino
        '
        Me.TextCiudadDestino.BackColor = System.Drawing.Color.White
        Me.TextCiudadDestino.BeforeTouchSize = New System.Drawing.Size(71, 22)
        Me.TextCiudadDestino.BorderColor = System.Drawing.Color.Silver
        Me.TextCiudadDestino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextCiudadDestino.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextCiudadDestino.CornerRadius = 3
        Me.TextCiudadDestino.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextCiudadDestino.Enabled = False
        Me.TextCiudadDestino.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextCiudadDestino.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextCiudadDestino.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextCiudadDestino.Location = New System.Drawing.Point(300, 54)
        Me.TextCiudadDestino.MaxLength = 70
        Me.TextCiudadDestino.Metrocolor = System.Drawing.Color.Silver
        Me.TextCiudadDestino.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextCiudadDestino.Name = "TextCiudadDestino"
        Me.TextCiudadDestino.NearImage = CType(resources.GetObject("TextCiudadDestino.NearImage"), System.Drawing.Image)
        Me.TextCiudadDestino.Size = New System.Drawing.Size(243, 22)
        Me.TextCiudadDestino.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextCiudadDestino.TabIndex = 587
        '
        'TextDestinoUbigeo
        '
        Me.TextDestinoUbigeo.BackColor = System.Drawing.Color.White
        Me.TextDestinoUbigeo.BeforeTouchSize = New System.Drawing.Size(71, 22)
        Me.TextDestinoUbigeo.BorderColor = System.Drawing.Color.Silver
        Me.TextDestinoUbigeo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextDestinoUbigeo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextDestinoUbigeo.CornerRadius = 3
        Me.TextDestinoUbigeo.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextDestinoUbigeo.Enabled = False
        Me.TextDestinoUbigeo.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextDestinoUbigeo.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextDestinoUbigeo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextDestinoUbigeo.Location = New System.Drawing.Point(303, 82)
        Me.TextDestinoUbigeo.MaxLength = 70
        Me.TextDestinoUbigeo.Metrocolor = System.Drawing.Color.Silver
        Me.TextDestinoUbigeo.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextDestinoUbigeo.Name = "TextDestinoUbigeo"
        Me.TextDestinoUbigeo.Size = New System.Drawing.Size(71, 22)
        Me.TextDestinoUbigeo.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextDestinoUbigeo.TabIndex = 588
        '
        'TextOrigenUbigeo
        '
        Me.TextOrigenUbigeo.BackColor = System.Drawing.Color.White
        Me.TextOrigenUbigeo.BeforeTouchSize = New System.Drawing.Size(71, 22)
        Me.TextOrigenUbigeo.BorderColor = System.Drawing.Color.Silver
        Me.TextOrigenUbigeo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextOrigenUbigeo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextOrigenUbigeo.CornerRadius = 3
        Me.TextOrigenUbigeo.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextOrigenUbigeo.Enabled = False
        Me.TextOrigenUbigeo.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextOrigenUbigeo.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextOrigenUbigeo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextOrigenUbigeo.Location = New System.Drawing.Point(17, 82)
        Me.TextOrigenUbigeo.MaxLength = 70
        Me.TextOrigenUbigeo.Metrocolor = System.Drawing.Color.Silver
        Me.TextOrigenUbigeo.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextOrigenUbigeo.Name = "TextOrigenUbigeo"
        Me.TextOrigenUbigeo.Size = New System.Drawing.Size(71, 22)
        Me.TextOrigenUbigeo.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextOrigenUbigeo.TabIndex = 591
        '
        'TextCiudadOrigen
        '
        Me.TextCiudadOrigen.BackColor = System.Drawing.Color.White
        Me.TextCiudadOrigen.BeforeTouchSize = New System.Drawing.Size(71, 22)
        Me.TextCiudadOrigen.BorderColor = System.Drawing.Color.Silver
        Me.TextCiudadOrigen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextCiudadOrigen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextCiudadOrigen.CornerRadius = 3
        Me.TextCiudadOrigen.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextCiudadOrigen.Enabled = False
        Me.TextCiudadOrigen.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextCiudadOrigen.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextCiudadOrigen.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextCiudadOrigen.Location = New System.Drawing.Point(17, 54)
        Me.TextCiudadOrigen.MaxLength = 70
        Me.TextCiudadOrigen.Metrocolor = System.Drawing.Color.Silver
        Me.TextCiudadOrigen.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextCiudadOrigen.Name = "TextCiudadOrigen"
        Me.TextCiudadOrigen.NearImage = CType(resources.GetObject("TextCiudadOrigen.NearImage"), System.Drawing.Image)
        Me.TextCiudadOrigen.Size = New System.Drawing.Size(243, 22)
        Me.TextCiudadOrigen.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextCiudadOrigen.TabIndex = 590
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(17, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(168, 13)
        Me.Label4.TabIndex = 589
        Me.Label4.Text = "Ciudad o lugar de origen (Ubigeo)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label5.Location = New System.Drawing.Point(15, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(121, 17)
        Me.Label5.TabIndex = 592
        Me.Label5.Text = "Datos del Pasajero"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextNombres
        '
        Me.TextNombres.BackColor = System.Drawing.Color.White
        Me.TextNombres.BeforeTouchSize = New System.Drawing.Size(71, 22)
        Me.TextNombres.BorderColor = System.Drawing.Color.Silver
        Me.TextNombres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextNombres.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNombres.CornerRadius = 3
        Me.TextNombres.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextNombres.Enabled = False
        Me.TextNombres.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextNombres.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNombres.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextNombres.Location = New System.Drawing.Point(18, 28)
        Me.TextNombres.MaxLength = 70
        Me.TextNombres.Metrocolor = System.Drawing.Color.Silver
        Me.TextNombres.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextNombres.Name = "TextNombres"
        Me.TextNombres.NearImage = CType(resources.GetObject("TextNombres.NearImage"), System.Drawing.Image)
        Me.TextNombres.Size = New System.Drawing.Size(317, 22)
        Me.TextNombres.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextNombres.TabIndex = 593
        '
        'TextTipoDocIdentidad
        '
        Me.TextTipoDocIdentidad.BackColor = System.Drawing.Color.White
        Me.TextTipoDocIdentidad.BeforeTouchSize = New System.Drawing.Size(71, 22)
        Me.TextTipoDocIdentidad.BorderColor = System.Drawing.Color.Silver
        Me.TextTipoDocIdentidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextTipoDocIdentidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextTipoDocIdentidad.CornerRadius = 3
        Me.TextTipoDocIdentidad.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextTipoDocIdentidad.Enabled = False
        Me.TextTipoDocIdentidad.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextTipoDocIdentidad.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextTipoDocIdentidad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextTipoDocIdentidad.Location = New System.Drawing.Point(18, 54)
        Me.TextTipoDocIdentidad.MaxLength = 70
        Me.TextTipoDocIdentidad.Metrocolor = System.Drawing.Color.Silver
        Me.TextTipoDocIdentidad.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextTipoDocIdentidad.Name = "TextTipoDocIdentidad"
        Me.TextTipoDocIdentidad.Size = New System.Drawing.Size(240, 22)
        Me.TextTipoDocIdentidad.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextTipoDocIdentidad.TabIndex = 594
        '
        'TextCodigoIdentidad
        '
        Me.TextCodigoIdentidad.BackColor = System.Drawing.Color.White
        Me.TextCodigoIdentidad.BeforeTouchSize = New System.Drawing.Size(71, 22)
        Me.TextCodigoIdentidad.BorderColor = System.Drawing.Color.Silver
        Me.TextCodigoIdentidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextCodigoIdentidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextCodigoIdentidad.CornerRadius = 3
        Me.TextCodigoIdentidad.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextCodigoIdentidad.Enabled = False
        Me.TextCodigoIdentidad.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextCodigoIdentidad.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextCodigoIdentidad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextCodigoIdentidad.Location = New System.Drawing.Point(391, 4)
        Me.TextCodigoIdentidad.MaxLength = 70
        Me.TextCodigoIdentidad.Metrocolor = System.Drawing.Color.Silver
        Me.TextCodigoIdentidad.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextCodigoIdentidad.Name = "TextCodigoIdentidad"
        Me.TextCodigoIdentidad.Size = New System.Drawing.Size(71, 22)
        Me.TextCodigoIdentidad.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextCodigoIdentidad.TabIndex = 595
        Me.TextCodigoIdentidad.Visible = False
        '
        'textEdad
        '
        Me.textEdad.BackColor = System.Drawing.Color.White
        Me.textEdad.BeforeTouchSize = New System.Drawing.Size(71, 22)
        Me.textEdad.BorderColor = System.Drawing.Color.Silver
        Me.textEdad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.textEdad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textEdad.CornerRadius = 3
        Me.textEdad.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.textEdad.Enabled = False
        Me.textEdad.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.textEdad.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textEdad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.textEdad.Location = New System.Drawing.Point(341, 28)
        Me.textEdad.MaxLength = 70
        Me.textEdad.Metrocolor = System.Drawing.Color.Silver
        Me.textEdad.MinimumSize = New System.Drawing.Size(14, 10)
        Me.textEdad.Name = "textEdad"
        Me.textEdad.Size = New System.Drawing.Size(71, 22)
        Me.textEdad.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.textEdad.TabIndex = 597
        '
        'TextNumIdent
        '
        Me.TextNumIdent.BackColor = System.Drawing.Color.White
        Me.TextNumIdent.BeforeTouchSize = New System.Drawing.Size(71, 22)
        Me.TextNumIdent.BorderColor = System.Drawing.Color.Silver
        Me.TextNumIdent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextNumIdent.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNumIdent.CornerRadius = 3
        Me.TextNumIdent.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextNumIdent.Enabled = False
        Me.TextNumIdent.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextNumIdent.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNumIdent.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextNumIdent.Location = New System.Drawing.Point(264, 54)
        Me.TextNumIdent.MaxLength = 70
        Me.TextNumIdent.Metrocolor = System.Drawing.Color.Silver
        Me.TextNumIdent.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextNumIdent.Name = "TextNumIdent"
        Me.TextNumIdent.Size = New System.Drawing.Size(148, 22)
        Me.TextNumIdent.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextNumIdent.TabIndex = 596
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BorderColor = System.Drawing.Color.White
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.Label3)
        Me.GradientPanel1.Controls.Add(Me.Label2)
        Me.GradientPanel1.Controls.Add(Me.TextCiudadDestino)
        Me.GradientPanel1.Controls.Add(Me.TextDestinoUbigeo)
        Me.GradientPanel1.Controls.Add(Me.ProgressBar2)
        Me.GradientPanel1.Controls.Add(Me.Label4)
        Me.GradientPanel1.Controls.Add(Me.TextCiudadOrigen)
        Me.GradientPanel1.Controls.Add(Me.TextOrigenUbigeo)
        Me.GradientPanel1.Controls.Add(Me.txtFecha)
        Me.GradientPanel1.Controls.Add(Me.Label6)
        Me.GradientPanel1.Controls.Add(Me.cboMoneda)
        Me.GradientPanel1.Controls.Add(Me.cboTipoDoc)
        Me.GradientPanel1.Location = New System.Drawing.Point(11, 235)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(591, 179)
        Me.GradientPanel1.TabIndex = 600
        '
        'ProgressBar2
        '
        Me.ProgressBar2.Location = New System.Drawing.Point(592, 161)
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(33, 10)
        Me.ProgressBar2.TabIndex = 591
        Me.ProgressBar2.Visible = False
        '
        'txtFecha
        '
        Me.txtFecha.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtFecha.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFecha.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtFecha.Checked = False
        Me.txtFecha.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFecha.CustomFormat = "dd/MM/yyyy HH:mm:ss tt"
        Me.txtFecha.DropDownImage = Nothing
        Me.txtFecha.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecha.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecha.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtFecha.Enabled = False
        Me.txtFecha.EnableNullDate = False
        Me.txtFecha.EnableNullKeys = False
        Me.txtFecha.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFecha.Location = New System.Drawing.Point(20, 151)
        Me.txtFecha.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecha.MinValue = New Date(CType(0, Long))
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ShowCheckBox = False
        Me.txtFecha.ShowDropButton = False
        Me.txtFecha.Size = New System.Drawing.Size(137, 20)
        Me.txtFecha.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFecha.TabIndex = 589
        Me.txtFecha.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label6.Location = New System.Drawing.Point(17, 122)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(102, 17)
        Me.Label6.TabIndex = 584
        Me.Label6.Text = "Datos de venta"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboMoneda
        '
        Me.cboMoneda.BackColor = System.Drawing.Color.White
        Me.cboMoneda.BeforeTouchSize = New System.Drawing.Size(111, 21)
        Me.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMoneda.Enabled = False
        Me.cboMoneda.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMoneda.Items.AddRange(New Object() {"NACIONAL", "EXTRANJERA"})
        Me.cboMoneda.Location = New System.Drawing.Point(161, 151)
        Me.cboMoneda.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboMoneda.Name = "cboMoneda"
        Me.cboMoneda.Size = New System.Drawing.Size(111, 21)
        Me.cboMoneda.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboMoneda.TabIndex = 586
        Me.cboMoneda.Text = "NACIONAL"
        '
        'cboTipoDoc
        '
        Me.cboTipoDoc.BackColor = System.Drawing.Color.White
        Me.cboTipoDoc.BeforeTouchSize = New System.Drawing.Size(187, 21)
        Me.cboTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoDoc.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoDoc.Location = New System.Drawing.Point(275, 151)
        Me.cboTipoDoc.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboTipoDoc.Name = "cboTipoDoc"
        Me.cboTipoDoc.Size = New System.Drawing.Size(187, 21)
        Me.cboTipoDoc.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboTipoDoc.TabIndex = 585
        '
        'GradientPanel3
        '
        Me.GradientPanel3.BorderColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.GradientPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel3.Controls.Add(Me.TextRaZonSocial)
        Me.GradientPanel3.Controls.Add(Me.textEdad)
        Me.GradientPanel3.Controls.Add(Me.TextCodigoComprobanteRazon)
        Me.GradientPanel3.Controls.Add(Me.TextTipoDocIdentidadRazon)
        Me.GradientPanel3.Controls.Add(Me.TextRuc)
        Me.GradientPanel3.Controls.Add(Me.TextNumIdent)
        Me.GradientPanel3.Controls.Add(Me.Label9)
        Me.GradientPanel3.Controls.Add(Me.Label5)
        Me.GradientPanel3.Controls.Add(Me.TextCodigoIdentidad)
        Me.GradientPanel3.Controls.Add(Me.TextNombres)
        Me.GradientPanel3.Controls.Add(Me.TextTipoDocIdentidad)
        Me.GradientPanel3.Location = New System.Drawing.Point(12, 425)
        Me.GradientPanel3.Name = "GradientPanel3"
        Me.GradientPanel3.Size = New System.Drawing.Size(591, 178)
        Me.GradientPanel3.TabIndex = 601
        '
        'TextRaZonSocial
        '
        Me.TextRaZonSocial.BackColor = System.Drawing.Color.White
        Me.TextRaZonSocial.BeforeTouchSize = New System.Drawing.Size(71, 22)
        Me.TextRaZonSocial.BorderColor = System.Drawing.Color.Silver
        Me.TextRaZonSocial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextRaZonSocial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextRaZonSocial.CornerRadius = 3
        Me.TextRaZonSocial.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextRaZonSocial.Enabled = False
        Me.TextRaZonSocial.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextRaZonSocial.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextRaZonSocial.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextRaZonSocial.Location = New System.Drawing.Point(18, 114)
        Me.TextRaZonSocial.MaxLength = 70
        Me.TextRaZonSocial.Metrocolor = System.Drawing.Color.Silver
        Me.TextRaZonSocial.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextRaZonSocial.Name = "TextRaZonSocial"
        Me.TextRaZonSocial.NearImage = CType(resources.GetObject("TextRaZonSocial.NearImage"), System.Drawing.Image)
        Me.TextRaZonSocial.Size = New System.Drawing.Size(330, 22)
        Me.TextRaZonSocial.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextRaZonSocial.TabIndex = 608
        '
        'TextCodigoComprobanteRazon
        '
        Me.TextCodigoComprobanteRazon.BackColor = System.Drawing.Color.White
        Me.TextCodigoComprobanteRazon.BeforeTouchSize = New System.Drawing.Size(71, 22)
        Me.TextCodigoComprobanteRazon.BorderColor = System.Drawing.Color.Silver
        Me.TextCodigoComprobanteRazon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextCodigoComprobanteRazon.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextCodigoComprobanteRazon.CornerRadius = 3
        Me.TextCodigoComprobanteRazon.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextCodigoComprobanteRazon.Enabled = False
        Me.TextCodigoComprobanteRazon.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextCodigoComprobanteRazon.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextCodigoComprobanteRazon.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextCodigoComprobanteRazon.Location = New System.Drawing.Point(354, 114)
        Me.TextCodigoComprobanteRazon.MaxLength = 70
        Me.TextCodigoComprobanteRazon.Metrocolor = System.Drawing.Color.Silver
        Me.TextCodigoComprobanteRazon.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextCodigoComprobanteRazon.Name = "TextCodigoComprobanteRazon"
        Me.TextCodigoComprobanteRazon.Size = New System.Drawing.Size(108, 22)
        Me.TextCodigoComprobanteRazon.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextCodigoComprobanteRazon.TabIndex = 607
        Me.TextCodigoComprobanteRazon.Visible = False
        '
        'TextTipoDocIdentidadRazon
        '
        Me.TextTipoDocIdentidadRazon.BackColor = System.Drawing.Color.White
        Me.TextTipoDocIdentidadRazon.BeforeTouchSize = New System.Drawing.Size(71, 22)
        Me.TextTipoDocIdentidadRazon.BorderColor = System.Drawing.Color.Silver
        Me.TextTipoDocIdentidadRazon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextTipoDocIdentidadRazon.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextTipoDocIdentidadRazon.CornerRadius = 3
        Me.TextTipoDocIdentidadRazon.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextTipoDocIdentidadRazon.Enabled = False
        Me.TextTipoDocIdentidadRazon.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextTipoDocIdentidadRazon.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextTipoDocIdentidadRazon.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextTipoDocIdentidadRazon.Location = New System.Drawing.Point(18, 142)
        Me.TextTipoDocIdentidadRazon.MaxLength = 70
        Me.TextTipoDocIdentidadRazon.Metrocolor = System.Drawing.Color.Silver
        Me.TextTipoDocIdentidadRazon.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextTipoDocIdentidadRazon.Name = "TextTipoDocIdentidadRazon"
        Me.TextTipoDocIdentidadRazon.Size = New System.Drawing.Size(330, 22)
        Me.TextTipoDocIdentidadRazon.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextTipoDocIdentidadRazon.TabIndex = 606
        '
        'TextRuc
        '
        Me.TextRuc.BackColor = System.Drawing.Color.White
        Me.TextRuc.BeforeTouchSize = New System.Drawing.Size(71, 22)
        Me.TextRuc.BorderColor = System.Drawing.Color.Silver
        Me.TextRuc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextRuc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextRuc.CornerRadius = 3
        Me.TextRuc.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextRuc.Enabled = False
        Me.TextRuc.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextRuc.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextRuc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextRuc.Location = New System.Drawing.Point(354, 142)
        Me.TextRuc.MaxLength = 70
        Me.TextRuc.Metrocolor = System.Drawing.Color.Silver
        Me.TextRuc.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextRuc.Name = "TextRuc"
        Me.TextRuc.Size = New System.Drawing.Size(108, 22)
        Me.TextRuc.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextRuc.TabIndex = 605
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label9.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label9.Location = New System.Drawing.Point(15, 93)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 17)
        Me.Label9.TabIndex = 601
        Me.Label9.Text = "Razón Social"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GradientPanel6)
        Me.Panel1.Location = New System.Drawing.Point(311, 103)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(292, 30)
        Me.Panel1.TabIndex = 536
        '
        'GradientPanel6
        '
        Me.GradientPanel6.BackColor = System.Drawing.SystemColors.Highlight
        Me.GradientPanel6.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.GradientPanel6.BorderSides = System.Windows.Forms.Border3DSide.Top
        Me.GradientPanel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel6.Controls.Add(Me.txtTotalPagar)
        Me.GradientPanel6.Controls.Add(Me.Label13)
        Me.GradientPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel6.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel6.Name = "GradientPanel6"
        Me.GradientPanel6.Size = New System.Drawing.Size(292, 30)
        Me.GradientPanel6.TabIndex = 222
        '
        'txtTotalPagar
        '
        Me.txtTotalPagar.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.txtTotalPagar.BeforeTouchSize = New System.Drawing.Size(71, 22)
        Me.txtTotalPagar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalPagar.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotalPagar.CornerRadius = 5
        Me.txtTotalPagar.CurrencySymbol = ""
        Me.txtTotalPagar.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtTotalPagar.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalPagar.Dock = System.Windows.Forms.DockStyle.Right
        Me.txtTotalPagar.Font = New System.Drawing.Font("Segoe UI", 17.0!, System.Drawing.FontStyle.Bold)
        Me.txtTotalPagar.ForeColor = System.Drawing.Color.White
        Me.txtTotalPagar.Location = New System.Drawing.Point(171, 0)
        Me.txtTotalPagar.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalPagar.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtTotalPagar.Name = "txtTotalPagar"
        Me.txtTotalPagar.NullString = ""
        Me.txtTotalPagar.PositiveColor = System.Drawing.Color.White
        Me.txtTotalPagar.ReadOnly = True
        Me.txtTotalPagar.ReadOnlyBackColor = System.Drawing.SystemColors.Highlight
        Me.txtTotalPagar.Size = New System.Drawing.Size(119, 31)
        Me.txtTotalPagar.TabIndex = 495
        Me.txtTotalPagar.Text = "0.00"
        Me.txtTotalPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label13.Font = New System.Drawing.Font("Calibri", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(0, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(136, 28)
        Me.Label13.TabIndex = 7
        Me.Label13.Text = "TOTAL A PAGAR"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'GradientPanel4
        '
        Me.GradientPanel4.Border3DStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.GradientPanel4.BorderColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.GradientPanel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel4.Controls.Add(Me.TextTotalDescuentos)
        Me.GradientPanel4.Controls.Add(Me.Label19)
        Me.GradientPanel4.Controls.Add(Me.txtTotalBase)
        Me.GradientPanel4.Controls.Add(Me.txtTotalBase2)
        Me.GradientPanel4.Controls.Add(Me.Label11)
        Me.GradientPanel4.Controls.Add(Me.Label14)
        Me.GradientPanel4.Controls.Add(Me.txtTotalBase3)
        Me.GradientPanel4.Controls.Add(Me.txtTotalIva)
        Me.GradientPanel4.Controls.Add(Me.lblTotalPercepcion)
        Me.GradientPanel4.Controls.Add(Me.Label10)
        Me.GradientPanel4.Controls.Add(Me.Label22)
        Me.GradientPanel4.Controls.Add(Me.Label12)
        Me.GradientPanel4.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GradientPanel4.Location = New System.Drawing.Point(1, 602)
        Me.GradientPanel4.Name = "GradientPanel4"
        Me.GradientPanel4.Size = New System.Drawing.Size(601, 48)
        Me.GradientPanel4.TabIndex = 602
        '
        'TextTotalDescuentos
        '
        Me.TextTotalDescuentos.BackGroundColor = System.Drawing.Color.Gainsboro
        Me.TextTotalDescuentos.BeforeTouchSize = New System.Drawing.Size(71, 22)
        Me.TextTotalDescuentos.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextTotalDescuentos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextTotalDescuentos.CornerRadius = 5
        Me.TextTotalDescuentos.CurrencySymbol = ""
        Me.TextTotalDescuentos.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextTotalDescuentos.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextTotalDescuentos.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextTotalDescuentos.ForeColor = System.Drawing.Color.Black
        Me.TextTotalDescuentos.Location = New System.Drawing.Point(722, 26)
        Me.TextTotalDescuentos.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextTotalDescuentos.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextTotalDescuentos.Name = "TextTotalDescuentos"
        Me.TextTotalDescuentos.NullString = ""
        Me.TextTotalDescuentos.PositiveColor = System.Drawing.Color.Black
        Me.TextTotalDescuentos.ReadOnly = True
        Me.TextTotalDescuentos.ReadOnlyBackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.TextTotalDescuentos.Size = New System.Drawing.Size(141, 15)
        Me.TextTotalDescuentos.TabIndex = 500
        Me.TextTotalDescuentos.Text = "0.00"
        Me.TextTotalDescuentos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(644, 28)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(67, 13)
        Me.Label19.TabIndex = 499
        Me.Label19.Text = "Descuentos"
        '
        'txtTotalBase
        '
        Me.txtTotalBase.BackGroundColor = System.Drawing.Color.Gainsboro
        Me.txtTotalBase.BeforeTouchSize = New System.Drawing.Size(71, 22)
        Me.txtTotalBase.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalBase.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotalBase.CornerRadius = 5
        Me.txtTotalBase.CurrencySymbol = ""
        Me.txtTotalBase.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotalBase.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalBase.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalBase.ForeColor = System.Drawing.Color.Black
        Me.txtTotalBase.Location = New System.Drawing.Point(103, 6)
        Me.txtTotalBase.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalBase.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtTotalBase.Name = "txtTotalBase"
        Me.txtTotalBase.NullString = ""
        Me.txtTotalBase.PositiveColor = System.Drawing.Color.Black
        Me.txtTotalBase.ReadOnly = True
        Me.txtTotalBase.ReadOnlyBackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.txtTotalBase.Size = New System.Drawing.Size(141, 15)
        Me.txtTotalBase.TabIndex = 494
        Me.txtTotalBase.Text = "0.00"
        Me.txtTotalBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalBase2
        '
        Me.txtTotalBase2.BackGroundColor = System.Drawing.Color.Gainsboro
        Me.txtTotalBase2.BeforeTouchSize = New System.Drawing.Size(71, 22)
        Me.txtTotalBase2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalBase2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotalBase2.CornerRadius = 5
        Me.txtTotalBase2.CurrencySymbol = ""
        Me.txtTotalBase2.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtTotalBase2.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalBase2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalBase2.ForeColor = System.Drawing.Color.Black
        Me.txtTotalBase2.Location = New System.Drawing.Point(103, 26)
        Me.txtTotalBase2.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalBase2.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtTotalBase2.Name = "txtTotalBase2"
        Me.txtTotalBase2.NullString = ""
        Me.txtTotalBase2.PositiveColor = System.Drawing.Color.Black
        Me.txtTotalBase2.ReadOnly = True
        Me.txtTotalBase2.ReadOnlyBackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.txtTotalBase2.Size = New System.Drawing.Size(141, 15)
        Me.txtTotalBase2.TabIndex = 492
        Me.txtTotalBase2.Text = "0.00"
        Me.txtTotalBase2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(17, 26)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(83, 13)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Op. Exonerada"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(17, 6)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(71, 13)
        Me.Label14.TabIndex = 6
        Me.Label14.Text = "Op. Gravada"
        '
        'txtTotalBase3
        '
        Me.txtTotalBase3.BackGroundColor = System.Drawing.Color.Gainsboro
        Me.txtTotalBase3.BeforeTouchSize = New System.Drawing.Size(71, 22)
        Me.txtTotalBase3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalBase3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotalBase3.CornerRadius = 5
        Me.txtTotalBase3.CurrencySymbol = ""
        Me.txtTotalBase3.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtTotalBase3.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalBase3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalBase3.ForeColor = System.Drawing.Color.Black
        Me.txtTotalBase3.Location = New System.Drawing.Point(405, 6)
        Me.txtTotalBase3.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalBase3.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtTotalBase3.Name = "txtTotalBase3"
        Me.txtTotalBase3.NullString = ""
        Me.txtTotalBase3.PositiveColor = System.Drawing.Color.Black
        Me.txtTotalBase3.ReadOnly = True
        Me.txtTotalBase3.ReadOnlyBackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.txtTotalBase3.Size = New System.Drawing.Size(141, 15)
        Me.txtTotalBase3.TabIndex = 498
        Me.txtTotalBase3.Text = "0.00"
        Me.txtTotalBase3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalIva
        '
        Me.txtTotalIva.BackGroundColor = System.Drawing.Color.Gainsboro
        Me.txtTotalIva.BeforeTouchSize = New System.Drawing.Size(71, 22)
        Me.txtTotalIva.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalIva.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotalIva.CornerRadius = 5
        Me.txtTotalIva.CurrencySymbol = ""
        Me.txtTotalIva.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtTotalIva.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalIva.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalIva.ForeColor = System.Drawing.Color.Black
        Me.txtTotalIva.Location = New System.Drawing.Point(405, 28)
        Me.txtTotalIva.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalIva.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtTotalIva.Name = "txtTotalIva"
        Me.txtTotalIva.NullString = ""
        Me.txtTotalIva.PositiveColor = System.Drawing.Color.Black
        Me.txtTotalIva.ReadOnly = True
        Me.txtTotalIva.ReadOnlyBackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.txtTotalIva.Size = New System.Drawing.Size(141, 15)
        Me.txtTotalIva.TabIndex = 493
        Me.txtTotalIva.Text = "0.00"
        Me.txtTotalIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalPercepcion
        '
        Me.lblTotalPercepcion.BackGroundColor = System.Drawing.Color.Gainsboro
        Me.lblTotalPercepcion.BeforeTouchSize = New System.Drawing.Size(71, 22)
        Me.lblTotalPercepcion.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTotalPercepcion.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblTotalPercepcion.CornerRadius = 5
        Me.lblTotalPercepcion.CurrencySymbol = ""
        Me.lblTotalPercepcion.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.lblTotalPercepcion.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.lblTotalPercepcion.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPercepcion.ForeColor = System.Drawing.Color.Black
        Me.lblTotalPercepcion.Location = New System.Drawing.Point(722, 6)
        Me.lblTotalPercepcion.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblTotalPercepcion.MinimumSize = New System.Drawing.Size(14, 10)
        Me.lblTotalPercepcion.Name = "lblTotalPercepcion"
        Me.lblTotalPercepcion.NullString = ""
        Me.lblTotalPercepcion.PositiveColor = System.Drawing.Color.Black
        Me.lblTotalPercepcion.ReadOnly = True
        Me.lblTotalPercepcion.ReadOnlyBackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.lblTotalPercepcion.Size = New System.Drawing.Size(141, 15)
        Me.lblTotalPercepcion.TabIndex = 496
        Me.lblTotalPercepcion.Text = "0.00"
        Me.lblTotalPercepcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(329, 8)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(70, 13)
        Me.Label10.TabIndex = 497
        Me.Label10.Text = "Op. Inafecta"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(643, 6)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(68, 13)
        Me.Label22.TabIndex = 495
        Me.Label22.Text = "Rendondeo"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(329, 30)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(25, 13)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "IGV"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GradientPanel2)
        Me.Panel2.Location = New System.Drawing.Point(12, 66)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(293, 30)
        Me.Panel2.TabIndex = 629
        '
        'GradientPanel2
        '
        Me.GradientPanel2.BackColor = System.Drawing.SystemColors.Highlight
        Me.GradientPanel2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.GradientPanel2.BorderSides = System.Windows.Forms.Border3DSide.Top
        Me.GradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel2.Controls.Add(Me.LabelfechaProg)
        Me.GradientPanel2.Controls.Add(Me.Label1)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(293, 30)
        Me.GradientPanel2.TabIndex = 222
        '
        'LabelfechaProg
        '
        Me.LabelfechaProg.BackColor = System.Drawing.Color.White
        Me.LabelfechaProg.Dock = System.Windows.Forms.DockStyle.Right
        Me.LabelfechaProg.Font = New System.Drawing.Font("Segoe UI", 17.0!, System.Drawing.FontStyle.Bold)
        Me.LabelfechaProg.ForeColor = System.Drawing.Color.Black
        Me.LabelfechaProg.Location = New System.Drawing.Point(142, 0)
        Me.LabelfechaProg.Name = "LabelfechaProg"
        Me.LabelfechaProg.Size = New System.Drawing.Size(149, 28)
        Me.LabelfechaProg.TabIndex = 8
        Me.LabelfechaProg.Text = "20/25/2020"
        Me.LabelfechaProg.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label1.Font = New System.Drawing.Font("Calibri", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 28)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "FECHA"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.GradientPanel5)
        Me.Panel3.Location = New System.Drawing.Point(12, 103)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(293, 30)
        Me.Panel3.TabIndex = 631
        '
        'GradientPanel5
        '
        Me.GradientPanel5.BackColor = System.Drawing.SystemColors.Highlight
        Me.GradientPanel5.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.GradientPanel5.BorderSides = System.Windows.Forms.Border3DSide.Top
        Me.GradientPanel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel5.Controls.Add(Me.txtHora)
        Me.GradientPanel5.Controls.Add(Me.Label21)
        Me.GradientPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel5.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel5.Name = "GradientPanel5"
        Me.GradientPanel5.Size = New System.Drawing.Size(293, 30)
        Me.GradientPanel5.TabIndex = 222
        '
        'txtHora
        '
        Me.txtHora.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtHora.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtHora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHora.CalendarForeColor = System.Drawing.Color.White
        Me.txtHora.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtHora.Checked = False
        Me.txtHora.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtHora.CustomFormat = "HH:mm tt"
        Me.txtHora.DropDownImage = Nothing
        Me.txtHora.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtHora.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtHora.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtHora.EnableNullDate = False
        Me.txtHora.EnableNullKeys = False
        Me.txtHora.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHora.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtHora.Location = New System.Drawing.Point(142, 0)
        Me.txtHora.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtHora.MinValue = New Date(CType(0, Long))
        Me.txtHora.Name = "txtHora"
        Me.txtHora.ReadOnly = True
        Me.txtHora.ShowCheckBox = False
        Me.txtHora.ShowDropButton = False
        Me.txtHora.Size = New System.Drawing.Size(150, 30)
        Me.txtHora.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtHora.TabIndex = 650
        Me.txtHora.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'Label21
        '
        Me.Label21.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label21.Font = New System.Drawing.Font("Calibri", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(0, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(136, 28)
        Me.Label21.TabIndex = 7
        Me.Label21.Text = "HORA"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.GradientPanel7)
        Me.Panel4.Location = New System.Drawing.Point(311, 67)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(292, 30)
        Me.Panel4.TabIndex = 630
        '
        'GradientPanel7
        '
        Me.GradientPanel7.BackColor = System.Drawing.SystemColors.Highlight
        Me.GradientPanel7.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.GradientPanel7.BorderSides = System.Windows.Forms.Border3DSide.Top
        Me.GradientPanel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel7.Controls.Add(Me.LabelAsientoSel)
        Me.GradientPanel7.Controls.Add(Me.Label23)
        Me.GradientPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel7.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel7.Name = "GradientPanel7"
        Me.GradientPanel7.Size = New System.Drawing.Size(292, 30)
        Me.GradientPanel7.TabIndex = 222
        '
        'LabelAsientoSel
        '
        Me.LabelAsientoSel.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.LabelAsientoSel.BeforeTouchSize = New System.Drawing.Size(71, 22)
        Me.LabelAsientoSel.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelAsientoSel.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LabelAsientoSel.CornerRadius = 5
        Me.LabelAsientoSel.CurrencyDecimalDigits = 0
        Me.LabelAsientoSel.CurrencySymbol = ""
        Me.LabelAsientoSel.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.LabelAsientoSel.DecimalValue = New Decimal(New Integer() {4, 0, 0, 0})
        Me.LabelAsientoSel.Dock = System.Windows.Forms.DockStyle.Right
        Me.LabelAsientoSel.Font = New System.Drawing.Font("Segoe UI", 17.0!, System.Drawing.FontStyle.Bold)
        Me.LabelAsientoSel.ForeColor = System.Drawing.Color.White
        Me.LabelAsientoSel.Location = New System.Drawing.Point(171, 0)
        Me.LabelAsientoSel.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelAsientoSel.MinimumSize = New System.Drawing.Size(14, 10)
        Me.LabelAsientoSel.Name = "LabelAsientoSel"
        Me.LabelAsientoSel.NullString = ""
        Me.LabelAsientoSel.PositiveColor = System.Drawing.Color.White
        Me.LabelAsientoSel.ReadOnly = True
        Me.LabelAsientoSel.ReadOnlyBackColor = System.Drawing.SystemColors.Highlight
        Me.LabelAsientoSel.Size = New System.Drawing.Size(119, 31)
        Me.LabelAsientoSel.TabIndex = 495
        Me.LabelAsientoSel.Text = "4"
        Me.LabelAsientoSel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label23.Font = New System.Drawing.Font("Calibri", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label23.ForeColor = System.Drawing.Color.White
        Me.Label23.Location = New System.Drawing.Point(0, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(136, 28)
        Me.Label23.TabIndex = 7
        Me.Label23.Text = "ASIENTO"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'GradientPanel8
        '
        Me.GradientPanel8.BorderColor = System.Drawing.Color.White
        Me.GradientPanel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel8.Controls.Add(Me.txtNroImpresion)
        Me.GradientPanel8.Controls.Add(Me.txtFormato)
        Me.GradientPanel8.Controls.Add(Me.ComboBox1)
        Me.GradientPanel8.Controls.Add(Me.Label8)
        Me.GradientPanel8.Controls.Add(Me.cboFormato)
        Me.GradientPanel8.Controls.Add(Me.Label15)
        Me.GradientPanel8.Controls.Add(Me.Label16)
        Me.GradientPanel8.Controls.Add(Me.Label17)
        Me.GradientPanel8.Controls.Add(Me.Label7)
        Me.GradientPanel8.Location = New System.Drawing.Point(12, 137)
        Me.GradientPanel8.Name = "GradientPanel8"
        Me.GradientPanel8.Size = New System.Drawing.Size(591, 92)
        Me.GradientPanel8.TabIndex = 632
        '
        'txtNroImpresion
        '
        Me.txtNroImpresion.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.txtNroImpresion.BeforeTouchSize = New System.Drawing.Size(71, 22)
        Me.txtNroImpresion.BorderColor = System.Drawing.Color.Silver
        Me.txtNroImpresion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNroImpresion.CornerRadius = 4
        Me.txtNroImpresion.CurrencyDecimalDigits = 0
        Me.txtNroImpresion.CurrencySymbol = ""
        Me.txtNroImpresion.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtNroImpresion.DecimalValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtNroImpresion.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNroImpresion.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.txtNroImpresion.Location = New System.Drawing.Point(517, 52)
        Me.txtNroImpresion.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtNroImpresion.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtNroImpresion.Name = "txtNroImpresion"
        Me.txtNroImpresion.NullString = ""
        Me.txtNroImpresion.PositiveColor = System.Drawing.Color.WhiteSmoke
        Me.txtNroImpresion.ReadOnlyBackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtNroImpresion.Size = New System.Drawing.Size(69, 23)
        Me.txtNroImpresion.TabIndex = 648
        Me.txtNroImpresion.Text = "1"
        '
        'txtFormato
        '
        Me.txtFormato.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.txtFormato.BeforeTouchSize = New System.Drawing.Size(71, 22)
        Me.txtFormato.BorderColor = System.Drawing.Color.Silver
        Me.txtFormato.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFormato.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFormato.CornerRadius = 3
        Me.txtFormato.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtFormato.Enabled = False
        Me.txtFormato.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFormato.ForeColor = System.Drawing.Color.White
        Me.txtFormato.Location = New System.Drawing.Point(417, 52)
        Me.txtFormato.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtFormato.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtFormato.Name = "txtFormato"
        Me.txtFormato.Size = New System.Drawing.Size(91, 23)
        Me.txtFormato.TabIndex = 647
        '
        'ComboBox1
        '
        Me.ComboBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.ComboBox1.BeforeTouchSize = New System.Drawing.Size(217, 21)
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FlatBorderColor = System.Drawing.Color.Gray
        Me.ComboBox1.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.ComboBox1.Location = New System.Drawing.Point(23, 54)
        Me.ComboBox1.MetroBorderColor = System.Drawing.Color.Silver
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(217, 21)
        Me.ComboBox1.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Black
        Me.ComboBox1.TabIndex = 646
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(20, 33)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(132, 13)
        Me.Label8.TabIndex = 641
        Me.Label8.Text = "Seleccionar una impresora"
        '
        'cboFormato
        '
        Me.cboFormato.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.cboFormato.BeforeTouchSize = New System.Drawing.Size(165, 21)
        Me.cboFormato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFormato.FlatBorderColor = System.Drawing.Color.Gray
        Me.cboFormato.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFormato.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.cboFormato.Location = New System.Drawing.Point(246, 54)
        Me.cboFormato.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboFormato.Name = "cboFormato"
        Me.cboFormato.Size = New System.Drawing.Size(165, 21)
        Me.cboFormato.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Black
        Me.cboFormato.TabIndex = 645
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(243, 33)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(137, 13)
        Me.Label15.TabIndex = 642
        Me.Label15.Text = "Tipo de impresión (Formato)"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(414, 33)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(45, 13)
        Me.Label16.TabIndex = 644
        Me.Label16.Text = "Formato"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(514, 33)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(75, 13)
        Me.Label17.TabIndex = 643
        Me.Label17.Text = "Nro. Impresión"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label7.Location = New System.Drawing.Point(17, 7)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(127, 17)
        Me.Label7.TabIndex = 583
        Me.Label7.Text = "Datos de Impresión"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'FormCrearVentaTransporteDirecto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.BorderColor = System.Drawing.SystemColors.Highlight
        Me.BorderThickness = 2
        Me.CaptionBarColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.CaptionButtonColor = System.Drawing.SystemColors.HotTrack
        Me.CaptionButtonHoverColor = System.Drawing.SystemColors.HotTrack
        Me.CaptionForeColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(614, 659)
        Me.Controls.Add(Me.GradientPanel8)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GradientPanel3)
        Me.Controls.Add(Me.GradientPanel4)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.Panel11)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormCrearVentaTransporteDirecto"
        Me.ShowIcon = False
        Me.Text = "Venta"
        Me.Panel11.ResumeLayout(False)
        CType(Me.QrCodeImgControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextCiudadDestino, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextDestinoUbigeo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextOrigenUbigeo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextCiudadOrigen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextNombres, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextTipoDocIdentidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextCodigoIdentidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.textEdad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextNumIdent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTipoDoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel3.ResumeLayout(False)
        Me.GradientPanel3.PerformLayout()
        CType(Me.TextRaZonSocial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextCodigoComprobanteRazon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextTipoDocIdentidadRazon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextRuc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.GradientPanel6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel6.ResumeLayout(False)
        Me.GradientPanel6.PerformLayout()
        CType(Me.txtTotalPagar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel4.ResumeLayout(False)
        Me.GradientPanel4.PerformLayout()
        CType(Me.TextTotalDescuentos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalBase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalBase2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalBase3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalIva, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTotalPercepcion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.GradientPanel5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel5.ResumeLayout(False)
        CType(Me.txtHora, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        CType(Me.GradientPanel7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel7.ResumeLayout(False)
        Me.GradientPanel7.PerformLayout()
        CType(Me.LabelAsientoSel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel8.ResumeLayout(False)
        Me.GradientPanel8.PerformLayout()
        CType(Me.txtNroImpresion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFormato, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboFormato, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel11 As Panel

    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextCiudadDestino As Tools.TextBoxExt
    Friend WithEvents TextDestinoUbigeo As Tools.TextBoxExt
    Friend WithEvents TextOrigenUbigeo As Tools.TextBoxExt
    Friend WithEvents TextCiudadOrigen As Tools.TextBoxExt
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TextNombres As Tools.TextBoxExt
    Friend WithEvents TextTipoDocIdentidad As Tools.TextBoxExt
    Friend WithEvents TextCodigoIdentidad As Tools.TextBoxExt
    Friend WithEvents textEdad As Tools.TextBoxExt
    Friend WithEvents TextNumIdent As Tools.TextBoxExt
    Friend WithEvents GradientPanel1 As Tools.GradientPanel
    Friend WithEvents GradientPanel3 As Tools.GradientPanel
    Friend WithEvents Label6 As Label
    Friend WithEvents cboTipoDoc As Tools.ComboBoxAdv
    Friend WithEvents cboMoneda As Tools.ComboBoxAdv
    Private WithEvents GradientPanel4 As Tools.GradientPanel
    Friend WithEvents TextTotalDescuentos As Tools.CurrencyTextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents txtTotalBase As Tools.CurrencyTextBox
    Friend WithEvents txtTotalBase2 As Tools.CurrencyTextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents txtTotalBase3 As Tools.CurrencyTextBox
    Friend WithEvents txtTotalIva As Tools.CurrencyTextBox
    Friend WithEvents lblTotalPercepcion As Tools.CurrencyTextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents txtFecha As Tools.DateTimePickerAdv
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GradientPanel6 As Tools.GradientPanel
    Friend WithEvents txtTotalPagar As Tools.CurrencyTextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents ProgressBar2 As ProgressBar
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label9 As Label
    Friend WithEvents TextRuc As Tools.TextBoxExt
    Friend WithEvents TextCodigoComprobanteRazon As Tools.TextBoxExt
    Friend WithEvents TextTipoDocIdentidadRazon As Tools.TextBoxExt
    Friend WithEvents TextRaZonSocial As Tools.TextBoxExt
    Friend WithEvents RoundButton21 As RoundButton2
    Friend WithEvents BtConfirmarVenta As RoundButton2
    Friend WithEvents Panel3 As Panel
    Friend WithEvents GradientPanel5 As Tools.GradientPanel
    Friend WithEvents Label21 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents GradientPanel7 As Tools.GradientPanel
    Friend WithEvents LabelAsientoSel As Tools.CurrencyTextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents GradientPanel2 As Tools.GradientPanel
    Friend WithEvents LabelfechaProg As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GradientPanel8 As Tools.GradientPanel
    Friend WithEvents Label7 As Label
    Friend WithEvents txtNroImpresion As Tools.CurrencyTextBox
    Friend WithEvents txtFormato As Tools.TextBoxExt
    Friend WithEvents ComboBox1 As Tools.ComboBoxAdv
    Friend WithEvents Label8 As Label
    Friend WithEvents cboFormato As Tools.ComboBoxAdv
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
    Friend WithEvents PageSetupDialog1 As PageSetupDialog
    Friend WithEvents QrCodeImgControl1 As Gma.QrCodeNet.Encoding.Windows.Forms.QrCodeImgControl
    Friend WithEvents txtHora As Tools.DateTimePickerAdv
End Class

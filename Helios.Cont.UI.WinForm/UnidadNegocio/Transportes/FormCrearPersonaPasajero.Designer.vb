Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormCrearPersonaPasajero
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCrearPersonaPasajero))
        Dim BannerTextInfo1 As Syncfusion.Windows.Forms.BannerTextInfo = New Syncfusion.Windows.Forms.BannerTextInfo()
        Dim BannerTextInfo2 As Syncfusion.Windows.Forms.BannerTextInfo = New Syncfusion.Windows.Forms.BannerTextInfo()
        Dim BannerTextInfo3 As Syncfusion.Windows.Forms.BannerTextInfo = New Syncfusion.Windows.Forms.BannerTextInfo()
        Dim BannerTextInfo4 As Syncfusion.Windows.Forms.BannerTextInfo = New Syncfusion.Windows.Forms.BannerTextInfo()
        Dim BannerTextInfo5 As Syncfusion.Windows.Forms.BannerTextInfo = New Syncfusion.Windows.Forms.BannerTextInfo()
        Me.GradientPanel8 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.TextEdad = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.PictureLoad = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RoundButton26 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.Label19 = New System.Windows.Forms.Label()
        Me.RoundButton25 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.TextMail = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TextFono = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.ComboComprobante = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.TextDistrito = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextCodigoPersona = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextLocalidad = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextNombres = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextNacionalidad = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.BannerTextProvider1 = New Syncfusion.Windows.Forms.BannerTextProvider(Me.components)
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.GradientPanel8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel8.SuspendLayout()
        CType(Me.TextEdad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureLoad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextMail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextFono, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextDistrito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextCodigoPersona, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextLocalidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextNombres, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextNacionalidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GradientPanel8
        '
        Me.GradientPanel8.BackColor = System.Drawing.Color.White
        Me.GradientPanel8.BorderColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.GradientPanel8.BorderSides = System.Windows.Forms.Border3DSide.Left
        Me.GradientPanel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel8.Controls.Add(Me.TextEdad)
        Me.GradientPanel8.Controls.Add(Me.PictureLoad)
        Me.GradientPanel8.Controls.Add(Me.Label1)
        Me.GradientPanel8.Controls.Add(Me.RoundButton26)
        Me.GradientPanel8.Controls.Add(Me.Label19)
        Me.GradientPanel8.Controls.Add(Me.RoundButton25)
        Me.GradientPanel8.Controls.Add(Me.TextMail)
        Me.GradientPanel8.Controls.Add(Me.Label17)
        Me.GradientPanel8.Controls.Add(Me.TextFono)
        Me.GradientPanel8.Controls.Add(Me.ComboComprobante)
        Me.GradientPanel8.Controls.Add(Me.TextDistrito)
        Me.GradientPanel8.Controls.Add(Me.TextCodigoPersona)
        Me.GradientPanel8.Controls.Add(Me.TextLocalidad)
        Me.GradientPanel8.Controls.Add(Me.TextNombres)
        Me.GradientPanel8.Controls.Add(Me.TextNacionalidad)
        Me.GradientPanel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel8.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel8.Name = "GradientPanel8"
        Me.GradientPanel8.Size = New System.Drawing.Size(397, 244)
        Me.GradientPanel8.TabIndex = 575
        '
        'TextEdad
        '
        Me.TextEdad.BackGroundColor = System.Drawing.SystemColors.Window
        Me.TextEdad.BeforeTouchSize = New System.Drawing.Size(321, 22)
        Me.TextEdad.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextEdad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextEdad.CurrencyDecimalDigits = 0
        Me.TextEdad.CurrencySymbol = "Edad: "
        Me.TextEdad.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextEdad.DecimalValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TextEdad.Location = New System.Drawing.Point(257, 105)
        Me.TextEdad.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TextEdad.Name = "TextEdad"
        Me.TextEdad.NullString = ""
        Me.TextEdad.Size = New System.Drawing.Size(93, 20)
        Me.TextEdad.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextEdad.TabIndex = 587
        Me.TextEdad.Text = "Edad: 1"
        '
        'PictureLoad
        '
        Me.PictureLoad.Image = CType(resources.GetObject("PictureLoad.Image"), System.Drawing.Image)
        Me.PictureLoad.Location = New System.Drawing.Point(191, 57)
        Me.PictureLoad.Name = "PictureLoad"
        Me.PictureLoad.Size = New System.Drawing.Size(42, 41)
        Me.PictureLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureLoad.TabIndex = 585
        Me.PictureLoad.TabStop = False
        Me.PictureLoad.Visible = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label1.Image = CType(resources.GetObject("Label1.Image"), System.Drawing.Image)
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label1.Location = New System.Drawing.Point(29, -8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(143, 52)
        Me.Label1.TabIndex = 582
        Me.Label1.Text = "Crear Pasajero"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'RoundButton26
        '
        Me.RoundButton26.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RoundButton26.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton26.BackColor = System.Drawing.Color.Gray
        Me.RoundButton26.BeforeTouchSize = New System.Drawing.Size(85, 35)
        Me.RoundButton26.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundButton26.ForeColor = System.Drawing.Color.White
        Me.RoundButton26.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.RoundButton26.IsBackStageButton = False
        Me.RoundButton26.Location = New System.Drawing.Point(168, 204)
        Me.RoundButton26.Name = "RoundButton26"
        Me.RoundButton26.Size = New System.Drawing.Size(85, 35)
        Me.RoundButton26.TabIndex = 581
        Me.RoundButton26.Text = "CANCELAR"
        Me.RoundButton26.UseVisualStyle = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(29, 134)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(49, 13)
        Me.Label19.TabIndex = 579
        Me.Label19.Text = "Nombres"
        '
        'RoundButton25
        '
        Me.RoundButton25.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RoundButton25.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton25.BackColor = System.Drawing.Color.FromArgb(CType(CType(6, Byte), Integer), CType(CType(56, Byte), Integer), CType(CType(135, Byte), Integer))
        Me.RoundButton25.BeforeTouchSize = New System.Drawing.Size(94, 35)
        Me.RoundButton25.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundButton25.ForeColor = System.Drawing.Color.White
        Me.RoundButton25.Image = CType(resources.GetObject("RoundButton25.Image"), System.Drawing.Image)
        Me.RoundButton25.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.RoundButton25.IsBackStageButton = False
        Me.RoundButton25.Location = New System.Drawing.Point(259, 204)
        Me.RoundButton25.Name = "RoundButton25"
        Me.RoundButton25.Size = New System.Drawing.Size(94, 35)
        Me.RoundButton25.TabIndex = 576
        Me.RoundButton25.Text = "GUARDAR"
        Me.RoundButton25.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RoundButton25.UseVisualStyle = True
        '
        'TextMail
        '
        Me.TextMail.BackColor = System.Drawing.Color.White
        BannerTextInfo1.Text = "Correo - Email"
        BannerTextInfo1.Visible = True
        Me.BannerTextProvider1.SetBannerText(Me.TextMail, BannerTextInfo1)
        Me.TextMail.BeforeTouchSize = New System.Drawing.Size(321, 22)
        Me.TextMail.BorderColor = System.Drawing.Color.Silver
        Me.TextMail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextMail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextMail.CornerRadius = 3
        Me.TextMail.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextMail.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextMail.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextMail.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextMail.Location = New System.Drawing.Point(31, 309)
        Me.TextMail.MaxLength = 150
        Me.TextMail.Metrocolor = System.Drawing.Color.Silver
        Me.TextMail.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextMail.Name = "TextMail"
        Me.TextMail.NearImage = CType(resources.GetObject("TextMail.NearImage"), System.Drawing.Image)
        Me.TextMail.Size = New System.Drawing.Size(321, 22)
        Me.TextMail.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextMail.TabIndex = 570
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label17.Location = New System.Drawing.Point(29, 56)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(107, 14)
        Me.Label17.TabIndex = 573
        Me.Label17.Text = "Datos del pasajero"
        '
        'TextFono
        '
        Me.TextFono.BackColor = System.Drawing.Color.White
        BannerTextInfo2.Text = "Telefono"
        BannerTextInfo2.Visible = True
        Me.BannerTextProvider1.SetBannerText(Me.TextFono, BannerTextInfo2)
        Me.TextFono.BeforeTouchSize = New System.Drawing.Size(321, 22)
        Me.TextFono.BorderColor = System.Drawing.Color.Silver
        Me.TextFono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextFono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextFono.CornerRadius = 3
        Me.TextFono.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextFono.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextFono.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextFono.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextFono.Location = New System.Drawing.Point(31, 283)
        Me.TextFono.MaxLength = 20
        Me.TextFono.Metrocolor = System.Drawing.Color.Silver
        Me.TextFono.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextFono.Name = "TextFono"
        Me.TextFono.NearImage = CType(resources.GetObject("TextFono.NearImage"), System.Drawing.Image)
        Me.TextFono.Size = New System.Drawing.Size(321, 22)
        Me.TextFono.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextFono.TabIndex = 569
        '
        'ComboComprobante
        '
        Me.ComboComprobante.BackColor = System.Drawing.Color.White
        Me.ComboComprobante.BeforeTouchSize = New System.Drawing.Size(220, 21)
        Me.ComboComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboComprobante.Enabled = False
        Me.ComboComprobante.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboComprobante.Items.AddRange(New Object() {"DNI", "RUC", "CARNET EXTRANJERIA"})
        Me.ComboComprobante.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboComprobante, "DNI"))
        Me.ComboComprobante.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboComprobante, "RUC"))
        Me.ComboComprobante.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboComprobante, "CARNET EXTRANJERIA"))
        Me.ComboComprobante.Location = New System.Drawing.Point(31, 104)
        Me.ComboComprobante.MetroBorderColor = System.Drawing.Color.Silver
        Me.ComboComprobante.Name = "ComboComprobante"
        Me.ComboComprobante.Size = New System.Drawing.Size(220, 21)
        Me.ComboComprobante.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboComprobante.TabIndex = 565
        Me.ComboComprobante.Text = "DNI"
        '
        'TextDistrito
        '
        Me.TextDistrito.BackColor = System.Drawing.Color.White
        BannerTextInfo3.Text = "Distrito"
        BannerTextInfo3.Visible = True
        Me.BannerTextProvider1.SetBannerText(Me.TextDistrito, BannerTextInfo3)
        Me.TextDistrito.BeforeTouchSize = New System.Drawing.Size(321, 22)
        Me.TextDistrito.BorderColor = System.Drawing.Color.Silver
        Me.TextDistrito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextDistrito.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextDistrito.CornerRadius = 3
        Me.TextDistrito.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextDistrito.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextDistrito.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextDistrito.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextDistrito.Location = New System.Drawing.Point(31, 257)
        Me.TextDistrito.MaxLength = 150
        Me.TextDistrito.Metrocolor = System.Drawing.Color.Silver
        Me.TextDistrito.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextDistrito.Name = "TextDistrito"
        Me.TextDistrito.Size = New System.Drawing.Size(321, 22)
        Me.TextDistrito.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextDistrito.TabIndex = 568
        '
        'TextCodigoPersona
        '
        Me.TextCodigoPersona.BackColor = System.Drawing.Color.White
        BannerTextInfo4.Text = "nro. comprobante"
        BannerTextInfo4.Visible = True
        Me.BannerTextProvider1.SetBannerText(Me.TextCodigoPersona, BannerTextInfo4)
        Me.TextCodigoPersona.BeforeTouchSize = New System.Drawing.Size(321, 22)
        Me.TextCodigoPersona.BorderColor = System.Drawing.Color.Silver
        Me.TextCodigoPersona.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextCodigoPersona.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextCodigoPersona.CornerRadius = 3
        Me.TextCodigoPersona.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextCodigoPersona.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextCodigoPersona.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextCodigoPersona.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextCodigoPersona.Location = New System.Drawing.Point(31, 76)
        Me.TextCodigoPersona.MaxLength = 12
        Me.TextCodigoPersona.Metrocolor = System.Drawing.Color.Silver
        Me.TextCodigoPersona.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextCodigoPersona.Name = "TextCodigoPersona"
        Me.TextCodigoPersona.NearImage = CType(resources.GetObject("TextCodigoPersona.NearImage"), System.Drawing.Image)
        Me.TextCodigoPersona.Size = New System.Drawing.Size(154, 22)
        Me.TextCodigoPersona.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextCodigoPersona.TabIndex = 566
        '
        'TextLocalidad
        '
        Me.TextLocalidad.BackColor = System.Drawing.Color.White
        BannerTextInfo5.Text = "Localidad"
        BannerTextInfo5.Visible = True
        Me.BannerTextProvider1.SetBannerText(Me.TextLocalidad, BannerTextInfo5)
        Me.TextLocalidad.BeforeTouchSize = New System.Drawing.Size(321, 22)
        Me.TextLocalidad.BorderColor = System.Drawing.Color.Silver
        Me.TextLocalidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextLocalidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextLocalidad.CornerRadius = 3
        Me.TextLocalidad.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextLocalidad.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextLocalidad.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextLocalidad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextLocalidad.Location = New System.Drawing.Point(31, 231)
        Me.TextLocalidad.MaxLength = 150
        Me.TextLocalidad.Metrocolor = System.Drawing.Color.Silver
        Me.TextLocalidad.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextLocalidad.Name = "TextLocalidad"
        Me.TextLocalidad.NearImage = CType(resources.GetObject("TextLocalidad.NearImage"), System.Drawing.Image)
        Me.TextLocalidad.Size = New System.Drawing.Size(321, 22)
        Me.TextLocalidad.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextLocalidad.TabIndex = 567
        Me.TextLocalidad.Visible = False
        '
        'TextNombres
        '
        Me.TextNombres.BackColor = System.Drawing.Color.White
        Me.TextNombres.BeforeTouchSize = New System.Drawing.Size(321, 22)
        Me.TextNombres.BorderColor = System.Drawing.Color.Silver
        Me.TextNombres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextNombres.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNombres.CornerRadius = 3
        Me.TextNombres.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextNombres.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextNombres.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNombres.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextNombres.Location = New System.Drawing.Point(31, 152)
        Me.TextNombres.MaxLength = 70
        Me.TextNombres.Metrocolor = System.Drawing.Color.Silver
        Me.TextNombres.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextNombres.Multiline = True
        Me.TextNombres.Name = "TextNombres"
        Me.TextNombres.Size = New System.Drawing.Size(322, 42)
        Me.TextNombres.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextNombres.TabIndex = 567
        '
        'TextNacionalidad
        '
        Me.TextNacionalidad.BackColor = System.Drawing.Color.White
        Me.TextNacionalidad.BeforeTouchSize = New System.Drawing.Size(321, 22)
        Me.TextNacionalidad.BorderColor = System.Drawing.Color.Silver
        Me.TextNacionalidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextNacionalidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNacionalidad.CornerRadius = 3
        Me.TextNacionalidad.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextNacionalidad.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextNacionalidad.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNacionalidad.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextNacionalidad.Location = New System.Drawing.Point(32, 201)
        Me.TextNacionalidad.Metrocolor = System.Drawing.Color.Silver
        Me.TextNacionalidad.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextNacionalidad.Name = "TextNacionalidad"
        Me.TextNacionalidad.NearImage = CType(resources.GetObject("TextNacionalidad.NearImage"), System.Drawing.Image)
        Me.TextNacionalidad.Size = New System.Drawing.Size(321, 22)
        Me.TextNacionalidad.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextNacionalidad.TabIndex = 571
        Me.TextNacionalidad.Text = "PERUANO"
        Me.TextNacionalidad.Visible = False
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'FormCrearPersonaPasajero
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.SystemColors.Highlight
        Me.BorderThickness = 2
        Me.ClientSize = New System.Drawing.Size(397, 244)
        Me.Controls.Add(Me.GradientPanel8)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormCrearPersonaPasajero"
        Me.ShowIcon = False
        CType(Me.GradientPanel8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel8.ResumeLayout(False)
        Me.GradientPanel8.PerformLayout()
        CType(Me.TextEdad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureLoad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextMail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextFono, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboComprobante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextDistrito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextCodigoPersona, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextLocalidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextNombres, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextNacionalidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GradientPanel8 As Tools.GradientPanel
    Friend WithEvents RoundButton26 As RoundButton2
    Friend WithEvents Label19 As Label
    Friend WithEvents RoundButton25 As RoundButton2
    Friend WithEvents TextMail As Tools.TextBoxExt
    Friend WithEvents Label17 As Label
    Friend WithEvents TextFono As Tools.TextBoxExt
    Friend WithEvents ComboComprobante As Tools.ComboBoxAdv
    Friend WithEvents TextDistrito As Tools.TextBoxExt
    Friend WithEvents TextCodigoPersona As Tools.TextBoxExt
    Friend WithEvents TextLocalidad As Tools.TextBoxExt
    Friend WithEvents TextNombres As Tools.TextBoxExt
    Friend WithEvents TextNacionalidad As Tools.TextBoxExt
    Friend WithEvents Label1 As Label
    Friend WithEvents BannerTextProvider1 As BannerTextProvider
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents PictureLoad As PictureBox
    Friend WithEvents TextEdad As Tools.CurrencyTextBox
End Class

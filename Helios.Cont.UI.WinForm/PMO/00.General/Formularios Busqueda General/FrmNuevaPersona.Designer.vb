<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNuevaPersona
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
        Dim BannerTextInfo1 As Syncfusion.Windows.Forms.BannerTextInfo = New Syncfusion.Windows.Forms.BannerTextInfo()
        Dim BannerTextInfo2 As Syncfusion.Windows.Forms.BannerTextInfo = New Syncfusion.Windows.Forms.BannerTextInfo()
        Dim MetroColorTable1 As Syncfusion.Windows.Forms.MetroColorTable = New Syncfusion.Windows.Forms.MetroColorTable()
        Dim BannerTextInfo3 As Syncfusion.Windows.Forms.BannerTextInfo = New Syncfusion.Windows.Forms.BannerTextInfo()
        Dim BannerTextInfo4 As Syncfusion.Windows.Forms.BannerTextInfo = New Syncfusion.Windows.Forms.BannerTextInfo()
        Dim BannerTextInfo5 As Syncfusion.Windows.Forms.BannerTextInfo = New Syncfusion.Windows.Forms.BannerTextInfo()
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmNuevaPersona))
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.btOperacion = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.txtdni = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.cboTipoDoc = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.ComboBoxAdv1 = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.txtRazon = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.cboCuenta = New Syncfusion.Windows.Forms.Tools.MultiColumnComboBox()
        Me.txtnombres = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtmaterno = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtpaterno = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.BannerTextProvider1 = New Syncfusion.Windows.Forms.BannerTextProvider(Me.components)
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtdni, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTipoDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboBoxAdv1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRazon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtnombres, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtmaterno, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtpaterno, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GradientPanel2
        '
        Me.GradientPanel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GradientPanel2.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.GradientPanel2.BorderSides = System.Windows.Forms.Border3DSide.Top
        Me.GradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel2.Controls.Add(Me.btOperacion)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 242)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(382, 50)
        Me.GradientPanel2.TabIndex = 416
        '
        'btOperacion
        '
        Me.btOperacion.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btOperacion.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btOperacion.BeforeTouchSize = New System.Drawing.Size(100, 32)
        Me.btOperacion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btOperacion.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btOperacion.ForeColor = System.Drawing.Color.White
        Me.btOperacion.IsBackStageButton = False
        Me.btOperacion.Location = New System.Drawing.Point(143, 11)
        Me.btOperacion.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btOperacion.Name = "btOperacion"
        Me.btOperacion.Size = New System.Drawing.Size(100, 32)
        Me.btOperacion.TabIndex = 8
        Me.btOperacion.Text = "Grabar"
        Me.btOperacion.UseVisualStyle = True
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BorderColor = System.Drawing.Color.Gainsboro
        Me.GradientPanel1.BorderSides = System.Windows.Forms.Border3DSide.Top
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(382, 10)
        Me.GradientPanel1.TabIndex = 417
        '
        'txtdni
        '
        Me.txtdni.BackColor = System.Drawing.Color.White
        BannerTextInfo1.Text = "Número de documento"
        BannerTextInfo1.Visible = True
        Me.BannerTextProvider1.SetBannerText(Me.txtdni, BannerTextInfo1)
        Me.txtdni.BeforeTouchSize = New System.Drawing.Size(306, 22)
        Me.txtdni.BorderColor = System.Drawing.Color.Silver
        Me.txtdni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtdni.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdni.CornerRadius = 4
        Me.txtdni.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtdni.Location = New System.Drawing.Point(37, 79)
        Me.txtdni.MaxLength = 10
        Me.txtdni.Metrocolor = System.Drawing.Color.Silver
        Me.txtdni.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtdni.Name = "txtdni"
        Me.txtdni.Size = New System.Drawing.Size(190, 22)
        Me.txtdni.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtdni.TabIndex = 419
        '
        'cboTipoDoc
        '
        Me.cboTipoDoc.BackColor = System.Drawing.Color.White
        Me.cboTipoDoc.BeforeTouchSize = New System.Drawing.Size(190, 21)
        Me.cboTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoDoc.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoDoc.Location = New System.Drawing.Point(37, 51)
        Me.cboTipoDoc.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboTipoDoc.Name = "cboTipoDoc"
        Me.cboTipoDoc.Size = New System.Drawing.Size(190, 21)
        Me.cboTipoDoc.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboTipoDoc.TabIndex = 458
        '
        'ComboBoxAdv1
        '
        Me.ComboBoxAdv1.BackColor = System.Drawing.Color.White
        Me.ComboBoxAdv1.BeforeTouchSize = New System.Drawing.Size(190, 22)
        Me.ComboBoxAdv1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxAdv1.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxAdv1.Items.AddRange(New Object() {"NATURAL", "JURIDICO"})
        Me.ComboBoxAdv1.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboBoxAdv1, "NATURAL"))
        Me.ComboBoxAdv1.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboBoxAdv1, "JURIDICO"))
        Me.ComboBoxAdv1.Location = New System.Drawing.Point(37, 22)
        Me.ComboBoxAdv1.MetroBorderColor = System.Drawing.Color.Silver
        Me.ComboBoxAdv1.Name = "ComboBoxAdv1"
        Me.ComboBoxAdv1.Size = New System.Drawing.Size(190, 22)
        Me.ComboBoxAdv1.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboBoxAdv1.TabIndex = 460
        Me.ComboBoxAdv1.Text = "NATURAL"
        '
        'txtRazon
        '
        Me.txtRazon.BackColor = System.Drawing.Color.White
        BannerTextInfo2.Text = "Razón Social"
        BannerTextInfo2.Visible = True
        Me.BannerTextProvider1.SetBannerText(Me.txtRazon, BannerTextInfo2)
        Me.txtRazon.BeforeTouchSize = New System.Drawing.Size(306, 22)
        Me.txtRazon.BorderColor = System.Drawing.Color.Silver
        Me.txtRazon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRazon.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRazon.CornerRadius = 4
        Me.txtRazon.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRazon.Location = New System.Drawing.Point(38, 108)
        Me.txtRazon.Metrocolor = System.Drawing.Color.Silver
        Me.txtRazon.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtRazon.Name = "txtRazon"
        Me.txtRazon.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRazon.Size = New System.Drawing.Size(306, 22)
        Me.txtRazon.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtRazon.TabIndex = 462
        '
        'cboCuenta
        '
        Me.cboCuenta.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.cboCuenta.BackColor = System.Drawing.Color.White
        Me.cboCuenta.BeforeTouchSize = New System.Drawing.Size(306, 21)
        Me.cboCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCuenta.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCuenta.Location = New System.Drawing.Point(38, 192)
        Me.cboCuenta.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboCuenta.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.cboCuenta.Name = "cboCuenta"
        MetroColorTable1.ArrowChecked = System.Drawing.Color.FromArgb(CType(CType(147, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(152, Byte), Integer))
        MetroColorTable1.ArrowInActive = System.Drawing.Color.White
        MetroColorTable1.ArrowNormal = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(198, Byte), Integer))
        MetroColorTable1.ArrowNormalBackGround = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(198, Byte), Integer))
        MetroColorTable1.ArrowPushed = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(90, Byte), Integer))
        MetroColorTable1.ArrowPushedBackGround = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(90, Byte), Integer))
        MetroColorTable1.ScrollerBackground = System.Drawing.Color.White
        MetroColorTable1.ThumbChecked = System.Drawing.Color.FromArgb(CType(CType(147, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(152, Byte), Integer))
        MetroColorTable1.ThumbInActive = System.Drawing.Color.White
        MetroColorTable1.ThumbNormal = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(198, Byte), Integer), CType(CType(198, Byte), Integer))
        MetroColorTable1.ThumbPushed = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(90, Byte), Integer))
        MetroColorTable1.ThumbPushedBorder = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.cboCuenta.ScrollMetroColorTable = MetroColorTable1
        Me.cboCuenta.Size = New System.Drawing.Size(306, 21)
        Me.cboCuenta.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboCuenta.TabIndex = 488
        Me.cboCuenta.Visible = False
        '
        'txtnombres
        '
        Me.txtnombres.BackColor = System.Drawing.Color.White
        BannerTextInfo3.Text = "Nombres"
        BannerTextInfo3.Visible = True
        Me.BannerTextProvider1.SetBannerText(Me.txtnombres, BannerTextInfo3)
        Me.txtnombres.BeforeTouchSize = New System.Drawing.Size(306, 22)
        Me.txtnombres.BorderColor = System.Drawing.Color.Silver
        Me.txtnombres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtnombres.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnombres.CornerRadius = 4
        Me.txtnombres.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtnombres.Location = New System.Drawing.Point(37, 164)
        Me.txtnombres.MaxLength = 10
        Me.txtnombres.Metrocolor = System.Drawing.Color.Silver
        Me.txtnombres.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtnombres.Name = "txtnombres"
        Me.txtnombres.Size = New System.Drawing.Size(307, 22)
        Me.txtnombres.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtnombres.TabIndex = 489
        '
        'txtmaterno
        '
        Me.txtmaterno.BackColor = System.Drawing.Color.White
        BannerTextInfo4.Text = "Apellido Materno"
        BannerTextInfo4.Visible = True
        Me.BannerTextProvider1.SetBannerText(Me.txtmaterno, BannerTextInfo4)
        Me.txtmaterno.BeforeTouchSize = New System.Drawing.Size(306, 22)
        Me.txtmaterno.BorderColor = System.Drawing.Color.Silver
        Me.txtmaterno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtmaterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtmaterno.CornerRadius = 4
        Me.txtmaterno.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtmaterno.Location = New System.Drawing.Point(37, 137)
        Me.txtmaterno.MaxLength = 10
        Me.txtmaterno.Metrocolor = System.Drawing.Color.Silver
        Me.txtmaterno.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtmaterno.Name = "txtmaterno"
        Me.txtmaterno.Size = New System.Drawing.Size(307, 22)
        Me.txtmaterno.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtmaterno.TabIndex = 490
        '
        'txtpaterno
        '
        Me.txtpaterno.BackColor = System.Drawing.Color.White
        BannerTextInfo5.Text = "Apellido Paterno"
        BannerTextInfo5.Visible = True
        Me.BannerTextProvider1.SetBannerText(Me.txtpaterno, BannerTextInfo5)
        Me.txtpaterno.BeforeTouchSize = New System.Drawing.Size(306, 22)
        Me.txtpaterno.BorderColor = System.Drawing.Color.Silver
        Me.txtpaterno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtpaterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtpaterno.CornerRadius = 4
        Me.txtpaterno.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtpaterno.Location = New System.Drawing.Point(37, 108)
        Me.txtpaterno.MaxLength = 10
        Me.txtpaterno.Metrocolor = System.Drawing.Color.Silver
        Me.txtpaterno.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtpaterno.Name = "txtpaterno"
        Me.txtpaterno.Size = New System.Drawing.Size(307, 22)
        Me.txtpaterno.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtpaterno.TabIndex = 491
        '
        'FrmNuevaPersona
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BorderColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.CaptionBarColor = System.Drawing.Color.White
        Me.CaptionBarHeight = 50
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(15, 9)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(30, 30)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        CaptionLabel1.Location = New System.Drawing.Point(53, 15)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Text = "Nuevo Personal"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(382, 292)
        Me.Controls.Add(Me.txtRazon)
        Me.Controls.Add(Me.txtmaterno)
        Me.Controls.Add(Me.txtnombres)
        Me.Controls.Add(Me.cboCuenta)
        Me.Controls.Add(Me.ComboBoxAdv1)
        Me.Controls.Add(Me.cboTipoDoc)
        Me.Controls.Add(Me.txtdni)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.GradientPanel2)
        Me.Controls.Add(Me.txtpaterno)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmNuevaPersona"
        Me.ShowIcon = False
        Me.Text = ""
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtdni, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTipoDoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboBoxAdv1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRazon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCuenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtnombres, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtmaterno, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtpaterno, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GradientPanel2 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents btOperacion As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents txtdni As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents cboTipoDoc As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents ComboBoxAdv1 As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents txtRazon As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents cboCuenta As Syncfusion.Windows.Forms.Tools.MultiColumnComboBox
    Friend WithEvents txtnombres As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtmaterno As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtpaterno As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents BannerTextProvider1 As Syncfusion.Windows.Forms.BannerTextProvider
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGeneral_BusquedaPersona
    Inherits frmMaster

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGeneral_BusquedaPersona))
        Dim BannerTextInfo2 As Syncfusion.Windows.Forms.BannerTextInfo = New Syncfusion.Windows.Forms.BannerTextInfo()
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Dim CaptionLabel2 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.txtPersona = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.BannerTextProvider1 = New Syncfusion.Windows.Forms.BannerTextProvider(Me.components)
        Me.TextBoxExt1 = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.GradientPanel17 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.lsvListadoItems = New System.Windows.Forms.ListView()
        Me.GradientPanel4 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        CType(Me.txtPersona, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxExt1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtPersona
        '
        Me.txtPersona.BackColor = System.Drawing.Color.White
        BannerTextInfo1.Text = "Escribir indicios de nombres"
        BannerTextInfo1.Visible = True
        Me.BannerTextProvider1.SetBannerText(Me.txtPersona, BannerTextInfo1)
        Me.txtPersona.BeforeTouchSize = New System.Drawing.Size(274, 22)
        Me.txtPersona.BorderColor = System.Drawing.Color.Silver
        Me.txtPersona.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPersona.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPersona.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtPersona.Enabled = False
        Me.txtPersona.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtPersona.Location = New System.Drawing.Point(137, 33)
        Me.txtPersona.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtPersona.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtPersona.Name = "txtPersona"
        Me.txtPersona.NearImage = CType(resources.GetObject("txtPersona.NearImage"), System.Drawing.Image)
        Me.txtPersona.Size = New System.Drawing.Size(274, 22)
        Me.txtPersona.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtPersona.TabIndex = 497
        '
        'TextBoxExt1
        '
        Me.TextBoxExt1.BackColor = System.Drawing.Color.White
        BannerTextInfo2.Text = "Buscar x número"
        BannerTextInfo2.Visible = True
        Me.BannerTextProvider1.SetBannerText(Me.TextBoxExt1, BannerTextInfo2)
        Me.TextBoxExt1.BeforeTouchSize = New System.Drawing.Size(274, 22)
        Me.TextBoxExt1.BorderColor = System.Drawing.Color.Silver
        Me.TextBoxExt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxExt1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBoxExt1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBoxExt1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextBoxExt1.Location = New System.Drawing.Point(12, 33)
        Me.TextBoxExt1.Metrocolor = System.Drawing.Color.YellowGreen
        Me.TextBoxExt1.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextBoxExt1.Name = "TextBoxExt1"
        Me.TextBoxExt1.NearImage = CType(resources.GetObject("TextBoxExt1.NearImage"), System.Drawing.Image)
        Me.TextBoxExt1.Size = New System.Drawing.Size(119, 22)
        Me.TextBoxExt1.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextBoxExt1.TabIndex = 498
        '
        'GradientPanel17
        '
        Me.GradientPanel17.BackColor = System.Drawing.Color.White
        Me.GradientPanel17.BorderColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GradientPanel17.BorderSides = System.Windows.Forms.Border3DSide.Top
        Me.GradientPanel17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel17.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel17.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel17.Name = "GradientPanel17"
        Me.GradientPanel17.Size = New System.Drawing.Size(428, 10)
        Me.GradientPanel17.TabIndex = 499
        '
        'lsvListadoItems
        '
        Me.lsvListadoItems.BackColor = System.Drawing.Color.White
        Me.lsvListadoItems.CheckBoxes = True
        Me.lsvListadoItems.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lsvListadoItems.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lsvListadoItems.FullRowSelect = True
        Me.lsvListadoItems.Location = New System.Drawing.Point(0, 61)
        Me.lsvListadoItems.MultiSelect = False
        Me.lsvListadoItems.Name = "lsvListadoItems"
        Me.lsvListadoItems.Size = New System.Drawing.Size(428, 285)
        Me.lsvListadoItems.TabIndex = 500
        Me.lsvListadoItems.UseCompatibleStateImageBehavior = False
        Me.lsvListadoItems.View = System.Windows.Forms.View.Details
        '
        'GradientPanel4
        '
        Me.GradientPanel4.BorderColor = System.Drawing.Color.OrangeRed
        Me.GradientPanel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel4.Controls.Add(Me.ButtonAdv1)
        Me.GradientPanel4.Location = New System.Drawing.Point(348, 352)
        Me.GradientPanel4.Name = "GradientPanel4"
        Me.GradientPanel4.Size = New System.Drawing.Size(80, 26)
        Me.GradientPanel4.TabIndex = 534
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(78, 24)
        Me.ButtonAdv1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAdv1.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonAdv1.Image = CType(resources.GetObject("ButtonAdv1.Image"), System.Drawing.Image)
        Me.ButtonAdv1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(0, 0)
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(78, 24)
        Me.ButtonAdv1.TabIndex = 53
        Me.ButtonAdv1.Text = "Agregar"
        Me.ButtonAdv1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonAdv1.UseVisualStyle = True
        '
        'frmGeneral_BusquedaPersona
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.SystemColors.HotTrack
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.Color.White
        Me.CaptionBarHeight = 55
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(15, 15)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(35, 35)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Ebrima", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.DimGray
        CaptionLabel1.Location = New System.Drawing.Point(55, 8)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(200, 24)
        CaptionLabel1.Text = "Entidad"
        CaptionLabel2.Font = New System.Drawing.Font("Ebrima", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel2.ForeColor = System.Drawing.SystemColors.Highlight
        CaptionLabel2.Location = New System.Drawing.Point(55, 23)
        CaptionLabel2.Name = "CaptionLabel2"
        CaptionLabel2.Size = New System.Drawing.Size(200, 24)
        CaptionLabel2.Text = "Búsqueda avanzada"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.CaptionLabels.Add(CaptionLabel2)
        Me.ClientSize = New System.Drawing.Size(428, 383)
        Me.Controls.Add(Me.GradientPanel4)
        Me.Controls.Add(Me.lsvListadoItems)
        Me.Controls.Add(Me.GradientPanel17)
        Me.Controls.Add(Me.TextBoxExt1)
        Me.Controls.Add(Me.txtPersona)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGeneral_BusquedaPersona"
        Me.ShowIcon = False
        Me.Text = ""
        CType(Me.txtPersona, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxExt1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtPersona As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents BannerTextProvider1 As Syncfusion.Windows.Forms.BannerTextProvider
    Friend WithEvents TextBoxExt1 As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents GradientPanel17 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents lsvListadoItems As System.Windows.Forms.ListView
    Friend WithEvents GradientPanel4 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormRepositoryRRHHApoyo
    Inherits System.Windows.Forms.Form

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
        Dim Animation1 As BunifuAnimatorNS.Animation = New BunifuAnimatorNS.Animation()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormRepositoryRRHHApoyo))
        Dim Animation2 As BunifuAnimatorNS.Animation = New BunifuAnimatorNS.Animation()
        Me.PanelBody = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.bunifuDragControl1 = New Bunifu.Framework.UI.BunifuDragControl(Me.components)
        Me.panelheader = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.BunifuImageButton1 = New Bunifu.Framework.UI.BunifuImageButton()
        Me.bunifuImageButton2 = New Bunifu.Framework.UI.BunifuImageButton()
        Me.BunifuFlatButton4 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.BunifuFlatButton16 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.BunifuFlatButton15 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.sliderTop = New System.Windows.Forms.PictureBox()
        Me.bunifuCustomLabel1 = New Bunifu.Framework.UI.BunifuCustomLabel()
        Me.PanelAnimator = New BunifuAnimatorNS.BunifuTransition(Me.components)
        Me.LogoAnimator = New BunifuAnimatorNS.BunifuTransition(Me.components)
        CType(Me.PanelBody, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.panelheader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelheader.SuspendLayout()
        CType(Me.BunifuImageButton1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bunifuImageButton2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sliderTop, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelBody
        '
        Me.PanelBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelAnimator.SetDecoration(Me.PanelBody, BunifuAnimatorNS.DecorationType.None)
        Me.LogoAnimator.SetDecoration(Me.PanelBody, BunifuAnimatorNS.DecorationType.None)
        Me.PanelBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelBody.Location = New System.Drawing.Point(0, 77)
        Me.PanelBody.Name = "PanelBody"
        Me.PanelBody.Size = New System.Drawing.Size(1109, 562)
        Me.PanelBody.TabIndex = 5
        '
        'bunifuDragControl1
        '
        Me.bunifuDragControl1.Fixed = True
        Me.bunifuDragControl1.Horizontal = True
        Me.bunifuDragControl1.TargetControl = Me.panelheader
        Me.bunifuDragControl1.Vertical = True
        '
        'panelheader
        '
        Me.panelheader.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.panelheader.BackgroundImage = CType(resources.GetObject("panelheader.BackgroundImage"), System.Drawing.Image)
        Me.panelheader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.panelheader.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.panelheader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelheader.Controls.Add(Me.BunifuImageButton1)
        Me.panelheader.Controls.Add(Me.bunifuImageButton2)
        Me.panelheader.Controls.Add(Me.BunifuFlatButton4)
        Me.panelheader.Controls.Add(Me.BunifuFlatButton16)
        Me.panelheader.Controls.Add(Me.BunifuFlatButton15)
        Me.panelheader.Controls.Add(Me.sliderTop)
        Me.panelheader.Controls.Add(Me.bunifuCustomLabel1)
        Me.PanelAnimator.SetDecoration(Me.panelheader, BunifuAnimatorNS.DecorationType.None)
        Me.LogoAnimator.SetDecoration(Me.panelheader, BunifuAnimatorNS.DecorationType.None)
        Me.panelheader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelheader.Location = New System.Drawing.Point(0, 0)
        Me.panelheader.Name = "panelheader"
        Me.panelheader.Size = New System.Drawing.Size(1109, 77)
        Me.panelheader.TabIndex = 4
        '
        'BunifuImageButton1
        '
        Me.BunifuImageButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BunifuImageButton1.BackColor = System.Drawing.Color.Transparent
        Me.LogoAnimator.SetDecoration(Me.BunifuImageButton1, BunifuAnimatorNS.DecorationType.None)
        Me.PanelAnimator.SetDecoration(Me.BunifuImageButton1, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuImageButton1.Image = CType(resources.GetObject("BunifuImageButton1.Image"), System.Drawing.Image)
        Me.BunifuImageButton1.ImageActive = Nothing
        Me.BunifuImageButton1.Location = New System.Drawing.Point(1057, 10)
        Me.BunifuImageButton1.Name = "BunifuImageButton1"
        Me.BunifuImageButton1.Size = New System.Drawing.Size(20, 20)
        Me.BunifuImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.BunifuImageButton1.TabIndex = 29
        Me.BunifuImageButton1.TabStop = False
        Me.BunifuImageButton1.Zoom = 10
        '
        'bunifuImageButton2
        '
        Me.bunifuImageButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bunifuImageButton2.BackColor = System.Drawing.Color.Transparent
        Me.LogoAnimator.SetDecoration(Me.bunifuImageButton2, BunifuAnimatorNS.DecorationType.None)
        Me.PanelAnimator.SetDecoration(Me.bunifuImageButton2, BunifuAnimatorNS.DecorationType.None)
        Me.bunifuImageButton2.Image = CType(resources.GetObject("bunifuImageButton2.Image"), System.Drawing.Image)
        Me.bunifuImageButton2.ImageActive = Nothing
        Me.bunifuImageButton2.Location = New System.Drawing.Point(1079, 10)
        Me.bunifuImageButton2.Name = "bunifuImageButton2"
        Me.bunifuImageButton2.Size = New System.Drawing.Size(20, 20)
        Me.bunifuImageButton2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.bunifuImageButton2.TabIndex = 28
        Me.bunifuImageButton2.TabStop = False
        Me.bunifuImageButton2.Zoom = 10
        '
        'BunifuFlatButton4
        '
        Me.BunifuFlatButton4.Activecolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton4.BackColor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton4.BorderRadius = 0
        Me.BunifuFlatButton4.ButtonText = "REPORTES"
        Me.BunifuFlatButton4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LogoAnimator.SetDecoration(Me.BunifuFlatButton4, BunifuAnimatorNS.DecorationType.None)
        Me.PanelAnimator.SetDecoration(Me.BunifuFlatButton4, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuFlatButton4.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.BunifuFlatButton4.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton4.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton4.Iconimage = Nothing
        Me.BunifuFlatButton4.Iconimage_right = Nothing
        Me.BunifuFlatButton4.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton4.Iconimage_Selected = Nothing
        Me.BunifuFlatButton4.IconMarginLeft = 0
        Me.BunifuFlatButton4.IconMarginRight = 0
        Me.BunifuFlatButton4.IconRightVisible = True
        Me.BunifuFlatButton4.IconRightZoom = 0R
        Me.BunifuFlatButton4.IconVisible = True
        Me.BunifuFlatButton4.IconZoom = 90.0R
        Me.BunifuFlatButton4.IsTab = False
        Me.BunifuFlatButton4.Location = New System.Drawing.Point(226, 48)
        Me.BunifuFlatButton4.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton4.Name = "BunifuFlatButton4"
        Me.BunifuFlatButton4.Normalcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton4.OnHovercolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton4.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton4.selected = False
        Me.BunifuFlatButton4.Size = New System.Drawing.Size(97, 18)
        Me.BunifuFlatButton4.TabIndex = 27
        Me.BunifuFlatButton4.Text = "REPORTES"
        Me.BunifuFlatButton4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton4.Textcolor = System.Drawing.Color.White
        Me.BunifuFlatButton4.TextFont = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton4.Visible = False
        '
        'BunifuFlatButton16
        '
        Me.BunifuFlatButton16.Activecolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton16.BackColor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton16.BorderRadius = 0
        Me.BunifuFlatButton16.ButtonText = "COLABORADORES"
        Me.BunifuFlatButton16.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LogoAnimator.SetDecoration(Me.BunifuFlatButton16, BunifuAnimatorNS.DecorationType.None)
        Me.PanelAnimator.SetDecoration(Me.BunifuFlatButton16, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuFlatButton16.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.BunifuFlatButton16.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton16.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton16.Iconimage = Nothing
        Me.BunifuFlatButton16.Iconimage_right = Nothing
        Me.BunifuFlatButton16.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton16.Iconimage_Selected = Nothing
        Me.BunifuFlatButton16.IconMarginLeft = 0
        Me.BunifuFlatButton16.IconMarginRight = 0
        Me.BunifuFlatButton16.IconRightVisible = True
        Me.BunifuFlatButton16.IconRightZoom = 0R
        Me.BunifuFlatButton16.IconVisible = True
        Me.BunifuFlatButton16.IconZoom = 90.0R
        Me.BunifuFlatButton16.IsTab = False
        Me.BunifuFlatButton16.Location = New System.Drawing.Point(94, 48)
        Me.BunifuFlatButton16.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton16.Name = "BunifuFlatButton16"
        Me.BunifuFlatButton16.Normalcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton16.OnHovercolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton16.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton16.selected = False
        Me.BunifuFlatButton16.Size = New System.Drawing.Size(128, 18)
        Me.BunifuFlatButton16.TabIndex = 22
        Me.BunifuFlatButton16.Text = "COLABORADORES"
        Me.BunifuFlatButton16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton16.Textcolor = System.Drawing.Color.White
        Me.BunifuFlatButton16.TextFont = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'BunifuFlatButton15
        '
        Me.BunifuFlatButton15.Activecolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton15.BackColor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton15.BorderRadius = 0
        Me.BunifuFlatButton15.ButtonText = "CARGOS"
        Me.BunifuFlatButton15.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LogoAnimator.SetDecoration(Me.BunifuFlatButton15, BunifuAnimatorNS.DecorationType.None)
        Me.PanelAnimator.SetDecoration(Me.BunifuFlatButton15, BunifuAnimatorNS.DecorationType.None)
        Me.BunifuFlatButton15.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton15.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton15.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton15.Iconimage = Nothing
        Me.BunifuFlatButton15.Iconimage_right = Nothing
        Me.BunifuFlatButton15.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton15.Iconimage_Selected = Nothing
        Me.BunifuFlatButton15.IconMarginLeft = 0
        Me.BunifuFlatButton15.IconMarginRight = 0
        Me.BunifuFlatButton15.IconRightVisible = True
        Me.BunifuFlatButton15.IconRightZoom = 0R
        Me.BunifuFlatButton15.IconVisible = True
        Me.BunifuFlatButton15.IconZoom = 90.0R
        Me.BunifuFlatButton15.IsTab = False
        Me.BunifuFlatButton15.Location = New System.Drawing.Point(5, 48)
        Me.BunifuFlatButton15.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton15.Name = "BunifuFlatButton15"
        Me.BunifuFlatButton15.Normalcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton15.OnHovercolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton15.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton15.selected = False
        Me.BunifuFlatButton15.Size = New System.Drawing.Size(85, 18)
        Me.BunifuFlatButton15.TabIndex = 21
        Me.BunifuFlatButton15.Text = "CARGOS"
        Me.BunifuFlatButton15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton15.Textcolor = System.Drawing.Color.White
        Me.BunifuFlatButton15.TextFont = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'sliderTop
        '
        Me.sliderTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.PanelAnimator.SetDecoration(Me.sliderTop, BunifuAnimatorNS.DecorationType.None)
        Me.LogoAnimator.SetDecoration(Me.sliderTop, BunifuAnimatorNS.DecorationType.None)
        Me.sliderTop.Location = New System.Drawing.Point(4, 70)
        Me.sliderTop.Name = "sliderTop"
        Me.sliderTop.Size = New System.Drawing.Size(82, 10)
        Me.sliderTop.TabIndex = 10
        Me.sliderTop.TabStop = False
        '
        'bunifuCustomLabel1
        '
        Me.bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent
        Me.PanelAnimator.SetDecoration(Me.bunifuCustomLabel1, BunifuAnimatorNS.DecorationType.None)
        Me.LogoAnimator.SetDecoration(Me.bunifuCustomLabel1, BunifuAnimatorNS.DecorationType.None)
        Me.bunifuCustomLabel1.Font = New System.Drawing.Font("Yu Gothic UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bunifuCustomLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.bunifuCustomLabel1.Image = CType(resources.GetObject("bunifuCustomLabel1.Image"), System.Drawing.Image)
        Me.bunifuCustomLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bunifuCustomLabel1.Location = New System.Drawing.Point(11, 10)
        Me.bunifuCustomLabel1.Name = "bunifuCustomLabel1"
        Me.bunifuCustomLabel1.Size = New System.Drawing.Size(90, 21)
        Me.bunifuCustomLabel1.TabIndex = 1
        Me.bunifuCustomLabel1.Text = "RR.HH."
        Me.bunifuCustomLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PanelAnimator
        '
        Me.PanelAnimator.AnimationType = BunifuAnimatorNS.AnimationType.Particles
        Me.PanelAnimator.Cursor = Nothing
        Animation1.AnimateOnlyDifferences = True
        Animation1.BlindCoeff = CType(resources.GetObject("Animation1.BlindCoeff"), System.Drawing.PointF)
        Animation1.LeafCoeff = 0!
        Animation1.MaxTime = 1.0!
        Animation1.MinTime = 0!
        Animation1.MosaicCoeff = CType(resources.GetObject("Animation1.MosaicCoeff"), System.Drawing.PointF)
        Animation1.MosaicShift = CType(resources.GetObject("Animation1.MosaicShift"), System.Drawing.PointF)
        Animation1.MosaicSize = 1
        Animation1.Padding = New System.Windows.Forms.Padding(100, 50, 100, 150)
        Animation1.RotateCoeff = 0!
        Animation1.RotateLimit = 0!
        Animation1.ScaleCoeff = CType(resources.GetObject("Animation1.ScaleCoeff"), System.Drawing.PointF)
        Animation1.SlideCoeff = CType(resources.GetObject("Animation1.SlideCoeff"), System.Drawing.PointF)
        Animation1.TimeCoeff = 2.0!
        Animation1.TransparencyCoeff = 0!
        Me.PanelAnimator.DefaultAnimation = Animation1
        '
        'LogoAnimator
        '
        Me.LogoAnimator.AnimationType = BunifuAnimatorNS.AnimationType.ScaleAndRotate
        Me.LogoAnimator.Cursor = Nothing
        Animation2.AnimateOnlyDifferences = True
        Animation2.BlindCoeff = CType(resources.GetObject("Animation2.BlindCoeff"), System.Drawing.PointF)
        Animation2.LeafCoeff = 0!
        Animation2.MaxTime = 1.0!
        Animation2.MinTime = 0!
        Animation2.MosaicCoeff = CType(resources.GetObject("Animation2.MosaicCoeff"), System.Drawing.PointF)
        Animation2.MosaicShift = CType(resources.GetObject("Animation2.MosaicShift"), System.Drawing.PointF)
        Animation2.MosaicSize = 0
        Animation2.Padding = New System.Windows.Forms.Padding(30)
        Animation2.RotateCoeff = 0.5!
        Animation2.RotateLimit = 0.2!
        Animation2.ScaleCoeff = CType(resources.GetObject("Animation2.ScaleCoeff"), System.Drawing.PointF)
        Animation2.SlideCoeff = CType(resources.GetObject("Animation2.SlideCoeff"), System.Drawing.PointF)
        Animation2.TimeCoeff = 0!
        Animation2.TransparencyCoeff = 0!
        Me.LogoAnimator.DefaultAnimation = Animation2
        '
        'FormRepositoryRRHHApoyo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1109, 639)
        Me.Controls.Add(Me.PanelBody)
        Me.Controls.Add(Me.panelheader)
        Me.PanelAnimator.SetDecoration(Me, BunifuAnimatorNS.DecorationType.None)
        Me.LogoAnimator.SetDecoration(Me, BunifuAnimatorNS.DecorationType.None)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FormRepositoryRRHHApoyo"
        Me.Text = "Finanzas"
        CType(Me.PanelBody, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.panelheader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelheader.ResumeLayout(False)
        CType(Me.BunifuImageButton1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bunifuImageButton2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sliderTop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents panelheader As Syncfusion.Windows.Forms.Tools.GradientPanel
    Private WithEvents BunifuImageButton1 As Bunifu.Framework.UI.BunifuImageButton
    Private WithEvents bunifuImageButton2 As Bunifu.Framework.UI.BunifuImageButton
    Private WithEvents BunifuFlatButton4 As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents BunifuFlatButton16 As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents BunifuFlatButton15 As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents sliderTop As PictureBox
    Private WithEvents bunifuCustomLabel1 As Bunifu.Framework.UI.BunifuCustomLabel
    Friend WithEvents PanelBody As Syncfusion.Windows.Forms.Tools.GradientPanel
    Private WithEvents LogoAnimator As BunifuAnimatorNS.BunifuTransition
    Private WithEvents PanelAnimator As BunifuAnimatorNS.BunifuTransition
    Private WithEvents bunifuDragControl1 As Bunifu.Framework.UI.BunifuDragControl
End Class

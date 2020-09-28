<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UC_CrearActivo
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UC_CrearActivo))
        Me.PanelBody = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.BunifuFlatButton3 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.BunifuFlatButton2 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.sliderTop = New System.Windows.Forms.PictureBox()
        Me.BunifuFlatButton1 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.RoundButton27 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.RoundButton26 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        CType(Me.PanelBody, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.sliderTop, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelBody
        '
        Me.PanelBody.BorderColor = System.Drawing.SystemColors.Highlight
        Me.PanelBody.BorderSides = CType(((System.Windows.Forms.Border3DSide.Left Or System.Windows.Forms.Border3DSide.Right) _
            Or System.Windows.Forms.Border3DSide.Bottom), System.Windows.Forms.Border3DSide)
        Me.PanelBody.BorderSingle = System.Windows.Forms.ButtonBorderStyle.Dotted
        Me.PanelBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelBody.Location = New System.Drawing.Point(0, 43)
        Me.PanelBody.Name = "PanelBody"
        Me.PanelBody.Size = New System.Drawing.Size(1109, 468)
        Me.PanelBody.TabIndex = 594
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BackColor = System.Drawing.Color.White
        Me.GradientPanel1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GradientPanel1.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.BunifuFlatButton3)
        Me.GradientPanel1.Controls.Add(Me.BunifuFlatButton2)
        Me.GradientPanel1.Controls.Add(Me.sliderTop)
        Me.GradientPanel1.Controls.Add(Me.BunifuFlatButton1)
        Me.GradientPanel1.Controls.Add(Me.RoundButton27)
        Me.GradientPanel1.Controls.Add(Me.RoundButton26)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(1109, 43)
        Me.GradientPanel1.TabIndex = 595
        '
        'BunifuFlatButton3
        '
        Me.BunifuFlatButton3.Activecolor = System.Drawing.Color.White
        Me.BunifuFlatButton3.BackColor = System.Drawing.Color.White
        Me.BunifuFlatButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton3.BorderRadius = 0
        Me.BunifuFlatButton3.ButtonText = "Culminados"
        Me.BunifuFlatButton3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton3.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton3.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton3.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton3.Iconimage = Nothing
        Me.BunifuFlatButton3.Iconimage_right = Nothing
        Me.BunifuFlatButton3.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton3.Iconimage_Selected = Nothing
        Me.BunifuFlatButton3.IconMarginLeft = 0
        Me.BunifuFlatButton3.IconMarginRight = 0
        Me.BunifuFlatButton3.IconRightVisible = True
        Me.BunifuFlatButton3.IconRightZoom = 0R
        Me.BunifuFlatButton3.IconVisible = True
        Me.BunifuFlatButton3.IconZoom = 90.0R
        Me.BunifuFlatButton3.IsTab = False
        Me.BunifuFlatButton3.Location = New System.Drawing.Point(213, 14)
        Me.BunifuFlatButton3.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton3.Name = "BunifuFlatButton3"
        Me.BunifuFlatButton3.Normalcolor = System.Drawing.Color.White
        Me.BunifuFlatButton3.OnHovercolor = System.Drawing.Color.White
        Me.BunifuFlatButton3.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton3.selected = False
        Me.BunifuFlatButton3.Size = New System.Drawing.Size(126, 18)
        Me.BunifuFlatButton3.TabIndex = 605
        Me.BunifuFlatButton3.Text = "Culminados"
        Me.BunifuFlatButton3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton3.Textcolor = System.Drawing.Color.Black
        Me.BunifuFlatButton3.TextFont = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'BunifuFlatButton2
        '
        Me.BunifuFlatButton2.Activecolor = System.Drawing.Color.White
        Me.BunifuFlatButton2.BackColor = System.Drawing.Color.White
        Me.BunifuFlatButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton2.BorderRadius = 0
        Me.BunifuFlatButton2.ButtonText = "En Curso"
        Me.BunifuFlatButton2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton2.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton2.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton2.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton2.Iconimage = Nothing
        Me.BunifuFlatButton2.Iconimage_right = Nothing
        Me.BunifuFlatButton2.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton2.Iconimage_Selected = Nothing
        Me.BunifuFlatButton2.IconMarginLeft = 0
        Me.BunifuFlatButton2.IconMarginRight = 0
        Me.BunifuFlatButton2.IconRightVisible = True
        Me.BunifuFlatButton2.IconRightZoom = 0R
        Me.BunifuFlatButton2.IconVisible = True
        Me.BunifuFlatButton2.IconZoom = 90.0R
        Me.BunifuFlatButton2.IsTab = False
        Me.BunifuFlatButton2.Location = New System.Drawing.Point(108, 14)
        Me.BunifuFlatButton2.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton2.Name = "BunifuFlatButton2"
        Me.BunifuFlatButton2.Normalcolor = System.Drawing.Color.White
        Me.BunifuFlatButton2.OnHovercolor = System.Drawing.Color.White
        Me.BunifuFlatButton2.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton2.selected = False
        Me.BunifuFlatButton2.Size = New System.Drawing.Size(103, 18)
        Me.BunifuFlatButton2.TabIndex = 604
        Me.BunifuFlatButton2.Text = "En Curso"
        Me.BunifuFlatButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton2.Textcolor = System.Drawing.Color.Black
        Me.BunifuFlatButton2.TextFont = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'sliderTop
        '
        Me.sliderTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(96, Byte), Integer))
        Me.sliderTop.Location = New System.Drawing.Point(0, 35)
        Me.sliderTop.Name = "sliderTop"
        Me.sliderTop.Size = New System.Drawing.Size(106, 6)
        Me.sliderTop.TabIndex = 603
        Me.sliderTop.TabStop = False
        '
        'BunifuFlatButton1
        '
        Me.BunifuFlatButton1.Activecolor = System.Drawing.Color.White
        Me.BunifuFlatButton1.BackColor = System.Drawing.Color.White
        Me.BunifuFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton1.BorderRadius = 0
        Me.BunifuFlatButton1.ButtonText = "En Espera"
        Me.BunifuFlatButton1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton1.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton1.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton1.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton1.Iconimage = Nothing
        Me.BunifuFlatButton1.Iconimage_right = Nothing
        Me.BunifuFlatButton1.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton1.Iconimage_Selected = Nothing
        Me.BunifuFlatButton1.IconMarginLeft = 0
        Me.BunifuFlatButton1.IconMarginRight = 0
        Me.BunifuFlatButton1.IconRightVisible = True
        Me.BunifuFlatButton1.IconRightZoom = 0R
        Me.BunifuFlatButton1.IconVisible = True
        Me.BunifuFlatButton1.IconZoom = 90.0R
        Me.BunifuFlatButton1.IsTab = False
        Me.BunifuFlatButton1.Location = New System.Drawing.Point(3, 14)
        Me.BunifuFlatButton1.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton1.Name = "BunifuFlatButton1"
        Me.BunifuFlatButton1.Normalcolor = System.Drawing.Color.White
        Me.BunifuFlatButton1.OnHovercolor = System.Drawing.Color.White
        Me.BunifuFlatButton1.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton1.selected = False
        Me.BunifuFlatButton1.Size = New System.Drawing.Size(103, 18)
        Me.BunifuFlatButton1.TabIndex = 602
        Me.BunifuFlatButton1.Text = "En Espera"
        Me.BunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton1.Textcolor = System.Drawing.Color.Black
        Me.BunifuFlatButton1.TextFont = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'RoundButton27
        '
        Me.RoundButton27.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton27.BackColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.RoundButton27.BeforeTouchSize = New System.Drawing.Size(128, 29)
        Me.RoundButton27.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundButton27.ForeColor = System.Drawing.Color.White
        Me.RoundButton27.Image = CType(resources.GetObject("RoundButton27.Image"), System.Drawing.Image)
        Me.RoundButton27.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.RoundButton27.IsBackStageButton = False
        Me.RoundButton27.Location = New System.Drawing.Point(859, 6)
        Me.RoundButton27.Name = "RoundButton27"
        Me.RoundButton27.Size = New System.Drawing.Size(128, 29)
        Me.RoundButton27.TabIndex = 601
        Me.RoundButton27.Text = "Consolidar salida"
        Me.RoundButton27.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RoundButton27.UseVisualStyle = True
        '
        'RoundButton26
        '
        Me.RoundButton26.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton26.BackColor = System.Drawing.Color.Gray
        Me.RoundButton26.BeforeTouchSize = New System.Drawing.Size(103, 29)
        Me.RoundButton26.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundButton26.ForeColor = System.Drawing.Color.White
        Me.RoundButton26.IsBackStageButton = False
        Me.RoundButton26.Location = New System.Drawing.Point(993, 6)
        Me.RoundButton26.Name = "RoundButton26"
        Me.RoundButton26.Size = New System.Drawing.Size(103, 29)
        Me.RoundButton26.TabIndex = 1
        Me.RoundButton26.Text = "Cancelar"
        Me.RoundButton26.UseVisualStyle = True
        '
        'UCPantallaEmbarque
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PanelBody)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Name = "UCPantallaEmbarque"
        Me.Size = New System.Drawing.Size(1109, 511)
        CType(Me.PanelBody, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        CType(Me.sliderTop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelBody As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents RoundButton27 As RoundButton2
    Private WithEvents BunifuFlatButton3 As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents BunifuFlatButton2 As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents sliderTop As PictureBox
    Private WithEvents BunifuFlatButton1 As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents RoundButton26 As RoundButton2
End Class

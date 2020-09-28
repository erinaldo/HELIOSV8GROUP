<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UCPrincipalKardex
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCPrincipalKardex))
        Me.PanelTop = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.BunifuFlatButton2 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.btnKardexMovimientos = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.btnKardex = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.sliderTop = New System.Windows.Forms.PictureBox()
        Me.PanelBody = New System.Windows.Forms.Panel()
        CType(Me.PanelTop, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelTop.SuspendLayout()
        CType(Me.sliderTop, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.PanelTop.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.PanelTop.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.PanelTop.Controls.Add(Me.BunifuFlatButton2)
        Me.PanelTop.Controls.Add(Me.btnKardexMovimientos)
        Me.PanelTop.Controls.Add(Me.btnKardex)
        Me.PanelTop.Controls.Add(Me.sliderTop)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Margin = New System.Windows.Forms.Padding(2)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(994, 45)
        Me.PanelTop.TabIndex = 2
        '
        'BunifuFlatButton2
        '
        Me.BunifuFlatButton2.Activecolor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.BunifuFlatButton2.BackColor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton2.BorderRadius = 0
        Me.BunifuFlatButton2.ButtonText = ""
        Me.BunifuFlatButton2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton2.DisabledColor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton2.Enabled = False
        Me.BunifuFlatButton2.ForeColor = System.Drawing.Color.Black
        Me.BunifuFlatButton2.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton2.Iconimage = CType(resources.GetObject("BunifuFlatButton2.Iconimage"), System.Drawing.Image)
        Me.BunifuFlatButton2.Iconimage_right = Nothing
        Me.BunifuFlatButton2.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton2.Iconimage_Selected = Nothing
        Me.BunifuFlatButton2.IconMarginLeft = 0
        Me.BunifuFlatButton2.IconMarginRight = 0
        Me.BunifuFlatButton2.IconRightVisible = True
        Me.BunifuFlatButton2.IconRightZoom = 0R
        Me.BunifuFlatButton2.IconVisible = True
        Me.BunifuFlatButton2.IconZoom = 60.0R
        Me.BunifuFlatButton2.IsTab = False
        Me.BunifuFlatButton2.Location = New System.Drawing.Point(3, 5)
        Me.BunifuFlatButton2.Name = "BunifuFlatButton2"
        Me.BunifuFlatButton2.Normalcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton2.OnHovercolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton2.OnHoverTextColor = System.Drawing.Color.White
        Me.BunifuFlatButton2.selected = False
        Me.BunifuFlatButton2.Size = New System.Drawing.Size(35, 29)
        Me.BunifuFlatButton2.TabIndex = 771
        Me.BunifuFlatButton2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BunifuFlatButton2.Textcolor = System.Drawing.Color.White
        Me.BunifuFlatButton2.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'btnKardexMovimientos
        '
        Me.btnKardexMovimientos.Activecolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.btnKardexMovimientos.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.btnKardexMovimientos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnKardexMovimientos.BorderRadius = 0
        Me.btnKardexMovimientos.ButtonText = "MOVIMIENTOS DE KARDEX"
        Me.btnKardexMovimientos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnKardexMovimientos.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.btnKardexMovimientos.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnKardexMovimientos.Iconcolor = System.Drawing.Color.Transparent
        Me.btnKardexMovimientos.Iconimage = Nothing
        Me.btnKardexMovimientos.Iconimage_right = Nothing
        Me.btnKardexMovimientos.Iconimage_right_Selected = Nothing
        Me.btnKardexMovimientos.Iconimage_Selected = Nothing
        Me.btnKardexMovimientos.IconMarginLeft = 0
        Me.btnKardexMovimientos.IconMarginRight = 0
        Me.btnKardexMovimientos.IconRightVisible = True
        Me.btnKardexMovimientos.IconRightZoom = 0R
        Me.btnKardexMovimientos.IconVisible = True
        Me.btnKardexMovimientos.IconZoom = 90.0R
        Me.btnKardexMovimientos.IsTab = False
        Me.btnKardexMovimientos.Location = New System.Drawing.Point(122, 13)
        Me.btnKardexMovimientos.Margin = New System.Windows.Forms.Padding(2)
        Me.btnKardexMovimientos.Name = "btnKardexMovimientos"
        Me.btnKardexMovimientos.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.btnKardexMovimientos.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.btnKardexMovimientos.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.btnKardexMovimientos.selected = False
        Me.btnKardexMovimientos.Size = New System.Drawing.Size(188, 18)
        Me.btnKardexMovimientos.TabIndex = 767
        Me.btnKardexMovimientos.Text = "MOVIMIENTOS DE KARDEX"
        Me.btnKardexMovimientos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnKardexMovimientos.Textcolor = System.Drawing.Color.White
        Me.btnKardexMovimientos.TextFont = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'btnKardex
        '
        Me.btnKardex.Activecolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.btnKardex.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.btnKardex.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnKardex.BorderRadius = 0
        Me.btnKardex.ButtonText = "KARDEX"
        Me.btnKardex.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnKardex.DisabledColor = System.Drawing.Color.Gray
        Me.btnKardex.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnKardex.Iconcolor = System.Drawing.Color.Transparent
        Me.btnKardex.Iconimage = Nothing
        Me.btnKardex.Iconimage_right = Nothing
        Me.btnKardex.Iconimage_right_Selected = Nothing
        Me.btnKardex.Iconimage_Selected = Nothing
        Me.btnKardex.IconMarginLeft = 0
        Me.btnKardex.IconMarginRight = 0
        Me.btnKardex.IconRightVisible = True
        Me.btnKardex.IconRightZoom = 0R
        Me.btnKardex.IconVisible = True
        Me.btnKardex.IconZoom = 90.0R
        Me.btnKardex.IsTab = False
        Me.btnKardex.Location = New System.Drawing.Point(40, 13)
        Me.btnKardex.Margin = New System.Windows.Forms.Padding(2)
        Me.btnKardex.Name = "btnKardex"
        Me.btnKardex.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.btnKardex.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.btnKardex.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.btnKardex.selected = False
        Me.btnKardex.Size = New System.Drawing.Size(75, 18)
        Me.btnKardex.TabIndex = 766
        Me.btnKardex.Text = "KARDEX"
        Me.btnKardex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnKardex.Textcolor = System.Drawing.Color.White
        Me.btnKardex.TextFont = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'sliderTop
        '
        Me.sliderTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.sliderTop.Location = New System.Drawing.Point(40, 36)
        Me.sliderTop.Name = "sliderTop"
        Me.sliderTop.Size = New System.Drawing.Size(75, 6)
        Me.sliderTop.TabIndex = 765
        Me.sliderTop.TabStop = False
        '
        'PanelBody
        '
        Me.PanelBody.BackColor = System.Drawing.Color.White
        Me.PanelBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelBody.Location = New System.Drawing.Point(0, 45)
        Me.PanelBody.Name = "PanelBody"
        Me.PanelBody.Size = New System.Drawing.Size(994, 526)
        Me.PanelBody.TabIndex = 3
        '
        'UCPrincipalKaredex
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PanelBody)
        Me.Controls.Add(Me.PanelTop)
        Me.Name = "UCPrincipalKaredex"
        Me.Size = New System.Drawing.Size(994, 571)
        CType(Me.PanelTop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelTop.ResumeLayout(False)
        CType(Me.sliderTop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelTop As Syncfusion.Windows.Forms.Tools.GradientPanel
    Private WithEvents btnKardexMovimientos As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents btnKardex As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents sliderTop As PictureBox
    Friend WithEvents PanelBody As Panel
    Friend WithEvents BunifuFlatButton2 As Bunifu.Framework.UI.BunifuFlatButton
End Class

Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormInfraestructuraSPK
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.panelheader = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.BunifuFlatButton3 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.BunifuFlatButton2 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.BunifuFlatButton1 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.BunifuFlatButton16 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.BunifuFlatButton15 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.sliderTop = New System.Windows.Forms.PictureBox()
        Me.PanelBody = New System.Windows.Forms.Panel()
        Me.bunifuDragControl1 = New Bunifu.Framework.UI.BunifuDragControl(Me.components)
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        CType(Me.panelheader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelheader.SuspendLayout()
        CType(Me.sliderTop, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelheader
        '
        Me.panelheader.BackColor = System.Drawing.Color.White
        Me.panelheader.BorderColor = System.Drawing.Color.Transparent
        Me.panelheader.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.panelheader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelheader.Controls.Add(Me.BunifuFlatButton3)
        Me.panelheader.Controls.Add(Me.BunifuFlatButton2)
        Me.panelheader.Controls.Add(Me.BunifuFlatButton1)
        Me.panelheader.Controls.Add(Me.BunifuFlatButton16)
        Me.panelheader.Controls.Add(Me.BunifuFlatButton15)
        Me.panelheader.Controls.Add(Me.sliderTop)
        Me.panelheader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelheader.Location = New System.Drawing.Point(0, 0)
        Me.panelheader.Name = "panelheader"
        Me.panelheader.Size = New System.Drawing.Size(1107, 30)
        Me.panelheader.TabIndex = 4
        '
        'BunifuFlatButton3
        '
        Me.BunifuFlatButton3.Activecolor = System.Drawing.Color.White
        Me.BunifuFlatButton3.BackColor = System.Drawing.Color.White
        Me.BunifuFlatButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton3.BorderRadius = 0
        Me.BunifuFlatButton3.ButtonText = "Clasificación"
        Me.BunifuFlatButton3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton3.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.BunifuFlatButton3.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton3.ForeColor = System.Drawing.Color.White
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
        Me.BunifuFlatButton3.Location = New System.Drawing.Point(415, 2)
        Me.BunifuFlatButton3.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton3.Name = "BunifuFlatButton3"
        Me.BunifuFlatButton3.Normalcolor = System.Drawing.Color.White
        Me.BunifuFlatButton3.OnHovercolor = System.Drawing.Color.White
        Me.BunifuFlatButton3.OnHoverTextColor = System.Drawing.Color.White
        Me.BunifuFlatButton3.selected = False
        Me.BunifuFlatButton3.Size = New System.Drawing.Size(98, 18)
        Me.BunifuFlatButton3.TabIndex = 37
        Me.BunifuFlatButton3.Text = "Clasificación"
        Me.BunifuFlatButton3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton3.Textcolor = System.Drawing.Color.Black
        Me.BunifuFlatButton3.TextFont = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'BunifuFlatButton2
        '
        Me.BunifuFlatButton2.Activecolor = System.Drawing.Color.White
        Me.BunifuFlatButton2.BackColor = System.Drawing.Color.White
        Me.BunifuFlatButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton2.BorderRadius = 0
        Me.BunifuFlatButton2.ButtonText = "Sub Clasificación"
        Me.BunifuFlatButton2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton2.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.BunifuFlatButton2.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton2.ForeColor = System.Drawing.Color.White
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
        Me.BunifuFlatButton2.Location = New System.Drawing.Point(302, 2)
        Me.BunifuFlatButton2.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton2.Name = "BunifuFlatButton2"
        Me.BunifuFlatButton2.Normalcolor = System.Drawing.Color.White
        Me.BunifuFlatButton2.OnHovercolor = System.Drawing.Color.White
        Me.BunifuFlatButton2.OnHoverTextColor = System.Drawing.Color.White
        Me.BunifuFlatButton2.selected = False
        Me.BunifuFlatButton2.Size = New System.Drawing.Size(98, 18)
        Me.BunifuFlatButton2.TabIndex = 36
        Me.BunifuFlatButton2.Text = "Sub Clasificación"
        Me.BunifuFlatButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton2.Textcolor = System.Drawing.Color.Black
        Me.BunifuFlatButton2.TextFont = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'BunifuFlatButton1
        '
        Me.BunifuFlatButton1.Activecolor = System.Drawing.Color.White
        Me.BunifuFlatButton1.BackColor = System.Drawing.Color.White
        Me.BunifuFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton1.BorderRadius = 0
        Me.BunifuFlatButton1.ButtonText = "Distribución"
        Me.BunifuFlatButton1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton1.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.BunifuFlatButton1.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton1.ForeColor = System.Drawing.Color.White
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
        Me.BunifuFlatButton1.Location = New System.Drawing.Point(200, 2)
        Me.BunifuFlatButton1.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton1.Name = "BunifuFlatButton1"
        Me.BunifuFlatButton1.Normalcolor = System.Drawing.Color.White
        Me.BunifuFlatButton1.OnHovercolor = System.Drawing.Color.White
        Me.BunifuFlatButton1.OnHoverTextColor = System.Drawing.Color.White
        Me.BunifuFlatButton1.selected = False
        Me.BunifuFlatButton1.Size = New System.Drawing.Size(98, 18)
        Me.BunifuFlatButton1.TabIndex = 35
        Me.BunifuFlatButton1.Text = "Distribución"
        Me.BunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton1.Textcolor = System.Drawing.Color.Black
        Me.BunifuFlatButton1.TextFont = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'BunifuFlatButton16
        '
        Me.BunifuFlatButton16.Activecolor = System.Drawing.Color.White
        Me.BunifuFlatButton16.BackColor = System.Drawing.Color.White
        Me.BunifuFlatButton16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton16.BorderRadius = 0
        Me.BunifuFlatButton16.ButtonText = "Componente"
        Me.BunifuFlatButton16.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton16.DisabledColor = System.Drawing.Color.FromArgb(CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(33, Byte), Integer))
        Me.BunifuFlatButton16.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton16.ForeColor = System.Drawing.Color.White
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
        Me.BunifuFlatButton16.Location = New System.Drawing.Point(98, 2)
        Me.BunifuFlatButton16.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton16.Name = "BunifuFlatButton16"
        Me.BunifuFlatButton16.Normalcolor = System.Drawing.Color.White
        Me.BunifuFlatButton16.OnHovercolor = System.Drawing.Color.White
        Me.BunifuFlatButton16.OnHoverTextColor = System.Drawing.Color.White
        Me.BunifuFlatButton16.selected = False
        Me.BunifuFlatButton16.Size = New System.Drawing.Size(98, 18)
        Me.BunifuFlatButton16.TabIndex = 22
        Me.BunifuFlatButton16.Text = "Componente"
        Me.BunifuFlatButton16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton16.Textcolor = System.Drawing.Color.Black
        Me.BunifuFlatButton16.TextFont = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'BunifuFlatButton15
        '
        Me.BunifuFlatButton15.Activecolor = System.Drawing.Color.White
        Me.BunifuFlatButton15.BackColor = System.Drawing.Color.White
        Me.BunifuFlatButton15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton15.BorderRadius = 0
        Me.BunifuFlatButton15.ButtonText = "Infraestructura"
        Me.BunifuFlatButton15.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton15.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton15.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton15.ForeColor = System.Drawing.Color.White
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
        Me.BunifuFlatButton15.Location = New System.Drawing.Point(5, 2)
        Me.BunifuFlatButton15.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton15.Name = "BunifuFlatButton15"
        Me.BunifuFlatButton15.Normalcolor = System.Drawing.Color.White
        Me.BunifuFlatButton15.OnHovercolor = System.Drawing.Color.White
        Me.BunifuFlatButton15.OnHoverTextColor = System.Drawing.Color.White
        Me.BunifuFlatButton15.selected = False
        Me.BunifuFlatButton15.Size = New System.Drawing.Size(89, 18)
        Me.BunifuFlatButton15.TabIndex = 21
        Me.BunifuFlatButton15.Text = "Infraestructura"
        Me.BunifuFlatButton15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton15.Textcolor = System.Drawing.Color.Black
        Me.BunifuFlatButton15.TextFont = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'sliderTop
        '
        Me.sliderTop.BackColor = System.Drawing.SystemColors.HotTrack
        Me.sliderTop.Location = New System.Drawing.Point(-1, 23)
        Me.sliderTop.Name = "sliderTop"
        Me.sliderTop.Size = New System.Drawing.Size(98, 6)
        Me.sliderTop.TabIndex = 10
        Me.sliderTop.TabStop = False
        '
        'PanelBody
        '
        Me.PanelBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelBody.Location = New System.Drawing.Point(0, 30)
        Me.PanelBody.Name = "PanelBody"
        Me.PanelBody.Size = New System.Drawing.Size(1107, 505)
        Me.PanelBody.TabIndex = 5
        '
        'bunifuDragControl1
        '
        Me.bunifuDragControl1.Fixed = True
        Me.bunifuDragControl1.Horizontal = True
        Me.bunifuDragControl1.TargetControl = Me.panelheader
        Me.bunifuDragControl1.Vertical = True
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BorderColor = System.Drawing.SystemColors.HotTrack
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.PanelBody)
        Me.GradientPanel1.Controls.Add(Me.panelheader)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(1109, 537)
        Me.GradientPanel1.TabIndex = 0
        '
        'FormInfraestructuraSPK
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Controls.Add(Me.GradientPanel1)
        Me.Name = "FormInfraestructuraSPK"
        Me.Size = New System.Drawing.Size(1109, 537)
        CType(Me.panelheader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelheader.ResumeLayout(False)
        CType(Me.sliderTop, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents panelheader As Tools.GradientPanel
    Private WithEvents BunifuFlatButton16 As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents BunifuFlatButton15 As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents sliderTop As PictureBox
    Friend WithEvents PanelBody As Panel
    Private WithEvents bunifuDragControl1 As Bunifu.Framework.UI.BunifuDragControl
    Friend WithEvents GradientPanel1 As Tools.GradientPanel
    Private WithEvents BunifuFlatButton1 As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents BunifuFlatButton3 As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents BunifuFlatButton2 As Bunifu.Framework.UI.BunifuFlatButton
End Class

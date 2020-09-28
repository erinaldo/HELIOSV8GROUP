<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UCAdministrarCuentasXEmpresa
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
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.sliderTop = New System.Windows.Forms.PictureBox()
        Me.BunifuFlatButton1 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.BunifuFlatButton15 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.PanelBody = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.sliderTop, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelBody, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BackColor = System.Drawing.Color.White
        Me.GradientPanel1.BorderColor = System.Drawing.Color.Gainsboro
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.sliderTop)
        Me.GradientPanel1.Controls.Add(Me.BunifuFlatButton1)
        Me.GradientPanel1.Controls.Add(Me.BunifuFlatButton15)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(867, 32)
        Me.GradientPanel1.TabIndex = 2
        '
        'sliderTop
        '
        Me.sliderTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.sliderTop.Location = New System.Drawing.Point(-1, 27)
        Me.sliderTop.Name = "sliderTop"
        Me.sliderTop.Size = New System.Drawing.Size(132, 3)
        Me.sliderTop.TabIndex = 11
        Me.sliderTop.TabStop = False
        '
        'BunifuFlatButton1
        '
        Me.BunifuFlatButton1.Activecolor = System.Drawing.Color.White
        Me.BunifuFlatButton1.BackColor = System.Drawing.Color.White
        Me.BunifuFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton1.BorderRadius = 0
        Me.BunifuFlatButton1.ButtonText = "Resumen general"
        Me.BunifuFlatButton1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton1.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton1.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
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
        Me.BunifuFlatButton1.Location = New System.Drawing.Point(135, 7)
        Me.BunifuFlatButton1.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton1.Name = "BunifuFlatButton1"
        Me.BunifuFlatButton1.Normalcolor = System.Drawing.Color.White
        Me.BunifuFlatButton1.OnHovercolor = System.Drawing.Color.White
        Me.BunifuFlatButton1.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton1.selected = False
        Me.BunifuFlatButton1.Size = New System.Drawing.Size(120, 18)
        Me.BunifuFlatButton1.TabIndex = 23
        Me.BunifuFlatButton1.Text = "Resumen general"
        Me.BunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton1.Textcolor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BunifuFlatButton1.TextFont = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'BunifuFlatButton15
        '
        Me.BunifuFlatButton15.Activecolor = System.Drawing.Color.White
        Me.BunifuFlatButton15.BackColor = System.Drawing.Color.White
        Me.BunifuFlatButton15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton15.BorderRadius = 0
        Me.BunifuFlatButton15.ButtonText = "Administrar cuentas"
        Me.BunifuFlatButton15.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton15.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton15.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
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
        Me.BunifuFlatButton15.Location = New System.Drawing.Point(2, 7)
        Me.BunifuFlatButton15.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton15.Name = "BunifuFlatButton15"
        Me.BunifuFlatButton15.Normalcolor = System.Drawing.Color.White
        Me.BunifuFlatButton15.OnHovercolor = System.Drawing.Color.White
        Me.BunifuFlatButton15.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton15.selected = False
        Me.BunifuFlatButton15.Size = New System.Drawing.Size(129, 18)
        Me.BunifuFlatButton15.TabIndex = 22
        Me.BunifuFlatButton15.Text = "Administrar cuentas"
        Me.BunifuFlatButton15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton15.Textcolor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BunifuFlatButton15.TextFont = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'PanelBody
        '
        Me.PanelBody.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.PanelBody.BorderColor = System.Drawing.Color.Gainsboro
        Me.PanelBody.BorderSides = CType((System.Windows.Forms.Border3DSide.Left Or System.Windows.Forms.Border3DSide.Right), System.Windows.Forms.Border3DSide)
        Me.PanelBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelBody.Location = New System.Drawing.Point(0, 32)
        Me.PanelBody.Name = "PanelBody"
        Me.PanelBody.Size = New System.Drawing.Size(867, 490)
        Me.PanelBody.TabIndex = 3
        '
        'UCAdministrarCuentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PanelBody)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Name = "UCAdministrarCuentas"
        Me.Size = New System.Drawing.Size(867, 522)
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        CType(Me.sliderTop, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelBody, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Private WithEvents sliderTop As PictureBox
    Private WithEvents BunifuFlatButton1 As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents BunifuFlatButton15 As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents PanelBody As Syncfusion.Windows.Forms.Tools.GradientPanel
End Class

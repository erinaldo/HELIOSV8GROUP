Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormCalculadoraTouch
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCalculadoraTouch))
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.TextCodigoVendedor = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.pnBuscardor = New System.Windows.Forms.Panel()
        Me.Button15 = New System.Windows.Forms.Button()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        CType(Me.TextCodigoVendedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        Me.pnBuscardor.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextCodigoVendedor
        '
        Me.TextCodigoVendedor.BackColor = System.Drawing.Color.White
        Me.TextCodigoVendedor.BeforeTouchSize = New System.Drawing.Size(232, 48)
        Me.TextCodigoVendedor.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextCodigoVendedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextCodigoVendedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextCodigoVendedor.CornerRadius = 3
        Me.TextCodigoVendedor.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextCodigoVendedor.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextCodigoVendedor.Font = New System.Drawing.Font("Calibri Light", 25.0!)
        Me.TextCodigoVendedor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextCodigoVendedor.Location = New System.Drawing.Point(18, 3)
        Me.TextCodigoVendedor.MaxLength = 30
        Me.TextCodigoVendedor.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextCodigoVendedor.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextCodigoVendedor.Name = "TextCodigoVendedor"
        Me.TextCodigoVendedor.NearImage = CType(resources.GetObject("TextCodigoVendedor.NearImage"), System.Drawing.Image)
        Me.TextCodigoVendedor.Size = New System.Drawing.Size(232, 48)
        Me.TextCodigoVendedor.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextCodigoVendedor.TabIndex = 410
        Me.TextCodigoVendedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GradientPanel2
        '
        Me.GradientPanel2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(162, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.GradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel2.Controls.Add(Me.ButtonAdv1)
        Me.GradientPanel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.GradientPanel2.Location = New System.Drawing.Point(18, 57)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(283, 45)
        Me.GradientPanel2.TabIndex = 522
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.White
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(281, 43)
        Me.ButtonAdv1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAdv1.Font = New System.Drawing.Font("Calibri Light", 20.0!)
        Me.ButtonAdv1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.ButtonAdv1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(0, 0)
        Me.ButtonAdv1.MetroColor = System.Drawing.Color.White
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(281, 43)
        Me.ButtonAdv1.TabIndex = 53
        Me.ButtonAdv1.Text = "ACEPTAR"
        Me.ButtonAdv1.UseVisualStyle = True
        '
        'pnBuscardor
        '
        Me.pnBuscardor.Controls.Add(Me.Button15)
        Me.pnBuscardor.Controls.Add(Me.Button14)
        Me.pnBuscardor.Controls.Add(Me.Button13)
        Me.pnBuscardor.Controls.Add(Me.Button10)
        Me.pnBuscardor.Controls.Add(Me.Button6)
        Me.pnBuscardor.Controls.Add(Me.Button5)
        Me.pnBuscardor.Controls.Add(Me.GradientPanel2)
        Me.pnBuscardor.Controls.Add(Me.Button11)
        Me.pnBuscardor.Controls.Add(Me.TextCodigoVendedor)
        Me.pnBuscardor.Controls.Add(Me.Button7)
        Me.pnBuscardor.Controls.Add(Me.Button8)
        Me.pnBuscardor.Controls.Add(Me.Button9)
        Me.pnBuscardor.Controls.Add(Me.Button4)
        Me.pnBuscardor.Controls.Add(Me.Button3)
        Me.pnBuscardor.Controls.Add(Me.Button2)
        Me.pnBuscardor.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnBuscardor.Location = New System.Drawing.Point(3, 0)
        Me.pnBuscardor.Name = "pnBuscardor"
        Me.pnBuscardor.Size = New System.Drawing.Size(313, 497)
        Me.pnBuscardor.TabIndex = 691
        Me.pnBuscardor.Visible = False
        '
        'Button15
        '
        Me.Button15.BackColor = System.Drawing.Color.White
        Me.Button15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button15.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button15.Font = New System.Drawing.Font("Segoe UI", 18.0!)
        Me.Button15.Location = New System.Drawing.Point(211, 396)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(90, 90)
        Me.Button15.TabIndex = 654
        Me.Button15.Text = "."
        Me.Button15.UseVisualStyleBackColor = False
        '
        'Button14
        '
        Me.Button14.BackColor = System.Drawing.Color.Transparent
        Me.Button14.BackgroundImage = CType(resources.GetObject("Button14.BackgroundImage"), System.Drawing.Image)
        Me.Button14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button14.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button14.Font = New System.Drawing.Font("Segoe UI", 18.0!)
        Me.Button14.ForeColor = System.Drawing.Color.White
        Me.Button14.Location = New System.Drawing.Point(256, 3)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(48, 48)
        Me.Button14.TabIndex = 653
        Me.Button14.UseVisualStyleBackColor = False
        '
        'Button13
        '
        Me.Button13.BackColor = System.Drawing.Color.White
        Me.Button13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button13.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button13.Font = New System.Drawing.Font("Segoe UI", 18.0!)
        Me.Button13.Location = New System.Drawing.Point(18, 396)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(90, 90)
        Me.Button13.TabIndex = 651
        Me.Button13.Text = "C"
        Me.Button13.UseVisualStyleBackColor = False
        '
        'Button10
        '
        Me.Button10.BackColor = System.Drawing.Color.Transparent
        Me.Button10.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button10.Font = New System.Drawing.Font("Segoe UI", 18.0!)
        Me.Button10.Location = New System.Drawing.Point(18, 106)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(90, 90)
        Me.Button10.TabIndex = 7
        Me.Button10.Text = "7"
        Me.Button10.UseVisualStyleBackColor = False
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.Transparent
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button6.Font = New System.Drawing.Font("Segoe UI", 18.0!)
        Me.Button6.Location = New System.Drawing.Point(115, 106)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(90, 90)
        Me.Button6.TabIndex = 8
        Me.Button6.Text = "8"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.Transparent
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button5.Font = New System.Drawing.Font("Segoe UI", 18.0!)
        Me.Button5.Location = New System.Drawing.Point(211, 106)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(90, 90)
        Me.Button5.TabIndex = 9
        Me.Button5.Text = "9"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Button11
        '
        Me.Button11.BackColor = System.Drawing.Color.Transparent
        Me.Button11.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button11.Font = New System.Drawing.Font("Segoe UI", 18.0!)
        Me.Button11.Location = New System.Drawing.Point(115, 396)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(90, 90)
        Me.Button11.TabIndex = 10
        Me.Button11.Text = "0"
        Me.Button11.UseVisualStyleBackColor = False
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.Transparent
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button7.Font = New System.Drawing.Font("Segoe UI", 18.0!)
        Me.Button7.Location = New System.Drawing.Point(211, 202)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(90, 90)
        Me.Button7.TabIndex = 6
        Me.Button7.Text = "6"
        Me.Button7.UseVisualStyleBackColor = False
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.Color.Transparent
        Me.Button8.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button8.Font = New System.Drawing.Font("Segoe UI", 18.0!)
        Me.Button8.Location = New System.Drawing.Point(115, 202)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(90, 90)
        Me.Button8.TabIndex = 5
        Me.Button8.Text = "5"
        Me.Button8.UseVisualStyleBackColor = False
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.Color.Transparent
        Me.Button9.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button9.Font = New System.Drawing.Font("Segoe UI", 18.0!)
        Me.Button9.Location = New System.Drawing.Point(18, 202)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(90, 90)
        Me.Button9.TabIndex = 4
        Me.Button9.Text = "4"
        Me.Button9.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Transparent
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button4.Font = New System.Drawing.Font("Segoe UI", 18.0!)
        Me.Button4.Location = New System.Drawing.Point(211, 300)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(90, 90)
        Me.Button4.TabIndex = 2
        Me.Button4.Text = "3"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button3.Font = New System.Drawing.Font("Segoe UI", 18.0!)
        Me.Button3.Location = New System.Drawing.Point(115, 300)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(90, 90)
        Me.Button3.TabIndex = 1
        Me.Button3.Text = "2"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Font = New System.Drawing.Font("Segoe UI", 18.0!)
        Me.Button2.Location = New System.Drawing.Point(18, 300)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(90, 90)
        Me.Button2.TabIndex = 0
        Me.Button2.Text = "1"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'FormCalculadoraTouch
        '
        Me.AcceptButton = Me.ButtonAdv1
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.SystemColors.Highlight
        Me.BorderThickness = 2
        Me.CaptionBarHeight = 35
        Me.CaptionForeColor = System.Drawing.Color.White
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        CaptionLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Text = "Calculadora"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(316, 497)
        Me.Controls.Add(Me.pnBuscardor)
        Me.ForeColor = System.Drawing.Color.Black
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormCalculadoraTouch"
        Me.ShowIcon = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Codigo de Vendedor"
        CType(Me.TextCodigoVendedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        Me.pnBuscardor.ResumeLayout(False)
        Me.pnBuscardor.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TextCodigoVendedor As Tools.TextBoxExt
    Friend WithEvents GradientPanel2 As Tools.GradientPanel
    Friend WithEvents ButtonAdv1 As ButtonAdv
    Friend WithEvents pnBuscardor As Panel
    Friend WithEvents Button13 As Button
    Friend WithEvents Button11 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button10 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents Button9 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button14 As Button
    Friend WithEvents Button15 As Button
End Class

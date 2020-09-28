Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormCodigoAcceso
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCodigoAcceso))
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.TextCodigoVendedor = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        CType(Me.TextCodigoVendedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextCodigoVendedor
        '
        Me.TextCodigoVendedor.BackColor = System.Drawing.Color.White
        Me.TextCodigoVendedor.BeforeTouchSize = New System.Drawing.Size(189, 27)
        Me.TextCodigoVendedor.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextCodigoVendedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextCodigoVendedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextCodigoVendedor.CornerRadius = 3
        Me.TextCodigoVendedor.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextCodigoVendedor.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextCodigoVendedor.Font = New System.Drawing.Font("Calibri Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextCodigoVendedor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextCodigoVendedor.Location = New System.Drawing.Point(78, 48)
        Me.TextCodigoVendedor.MaxLength = 30
        Me.TextCodigoVendedor.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextCodigoVendedor.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextCodigoVendedor.Name = "TextCodigoVendedor"
        Me.TextCodigoVendedor.NearImage = CType(resources.GetObject("TextCodigoVendedor.NearImage"), System.Drawing.Image)
        Me.TextCodigoVendedor.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextCodigoVendedor.Size = New System.Drawing.Size(189, 27)
        Me.TextCodigoVendedor.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextCodigoVendedor.TabIndex = 410
        Me.TextCodigoVendedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(142, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 17)
        Me.Label1.TabIndex = 411
        Me.Label1.Text = "Código"
        '
        'GradientPanel2
        '
        Me.GradientPanel2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(162, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.GradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel2.Controls.Add(Me.ButtonAdv1)
        Me.GradientPanel2.Location = New System.Drawing.Point(135, 86)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(78, 30)
        Me.GradientPanel2.TabIndex = 522
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.White
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(76, 28)
        Me.ButtonAdv1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAdv1.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.ButtonAdv1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(0, 0)
        Me.ButtonAdv1.MetroColor = System.Drawing.Color.White
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(76, 28)
        Me.ButtonAdv1.TabIndex = 53
        Me.ButtonAdv1.Text = "ACEPTAR"
        Me.ButtonAdv1.UseVisualStyle = True
        '
        'FormCodigoVendedor
        '
        Me.AcceptButton = Me.ButtonAdv1
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.SystemColors.Highlight
        Me.BorderThickness = 2
        Me.CaptionForeColor = System.Drawing.Color.White
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Text = "Identificar usuario"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(353, 125)
        Me.Controls.Add(Me.GradientPanel2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextCodigoVendedor)
        Me.ForeColor = System.Drawing.Color.Black
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormCodigoVendedor"
        Me.ShowIcon = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Codigo de Vendedor"
        CType(Me.TextCodigoVendedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextCodigoVendedor As Tools.TextBoxExt
    Friend WithEvents Label1 As Label
    Friend WithEvents GradientPanel2 As Tools.GradientPanel
    Friend WithEvents ButtonAdv1 As ButtonAdv
End Class

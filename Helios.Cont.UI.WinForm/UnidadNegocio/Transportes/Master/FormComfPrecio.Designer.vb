Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormComfPrecio
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
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.pnBuscardor = New System.Windows.Forms.Panel()
        Me.TextCodigoVendedor = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        Me.pnBuscardor.SuspendLayout()
        CType(Me.TextCodigoVendedor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.pnBuscardor.Controls.Add(Me.TextCodigoVendedor)
        Me.pnBuscardor.Controls.Add(Me.GradientPanel2)
        Me.pnBuscardor.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnBuscardor.Location = New System.Drawing.Point(3, 0)
        Me.pnBuscardor.Name = "pnBuscardor"
        Me.pnBuscardor.Size = New System.Drawing.Size(313, 113)
        Me.pnBuscardor.TabIndex = 691
        Me.pnBuscardor.Visible = False
        '
        'TextCodigoVendedor
        '
        Me.TextCodigoVendedor.BackGroundColor = System.Drawing.Color.White
        Me.TextCodigoVendedor.BeforeTouchSize = New System.Drawing.Size(97, 30)
        Me.TextCodigoVendedor.BorderColor = System.Drawing.Color.Silver
        Me.TextCodigoVendedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextCodigoVendedor.CornerRadius = 5
        Me.TextCodigoVendedor.CurrencySymbol = "S/ "
        Me.TextCodigoVendedor.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextCodigoVendedor.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextCodigoVendedor.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold)
        Me.TextCodigoVendedor.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextCodigoVendedor.Location = New System.Drawing.Point(19, 12)
        Me.TextCodigoVendedor.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextCodigoVendedor.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextCodigoVendedor.Name = "TextCodigoVendedor"
        Me.TextCodigoVendedor.NullString = ""
        Me.TextCodigoVendedor.PositiveColor = System.Drawing.SystemColors.HotTrack
        Me.TextCodigoVendedor.ReadOnlyBackColor = System.Drawing.SystemColors.Info
        Me.TextCodigoVendedor.Size = New System.Drawing.Size(281, 37)
        Me.TextCodigoVendedor.TabIndex = 594
        Me.TextCodigoVendedor.Text = "S/ 0.00"
        Me.TextCodigoVendedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'FormComfPrecio
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
        CaptionLabel1.Text = "Importe"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(316, 113)
        Me.Controls.Add(Me.pnBuscardor)
        Me.ForeColor = System.Drawing.Color.Black
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormComfPrecio"
        Me.ShowIcon = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Codigo de Vendedor"
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        Me.pnBuscardor.ResumeLayout(False)
        Me.pnBuscardor.PerformLayout()
        CType(Me.TextCodigoVendedor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GradientPanel2 As Tools.GradientPanel
    Friend WithEvents ButtonAdv1 As ButtonAdv
    Friend WithEvents pnBuscardor As Panel
    Friend WithEvents TextCodigoVendedor As Tools.CurrencyTextBox
End Class

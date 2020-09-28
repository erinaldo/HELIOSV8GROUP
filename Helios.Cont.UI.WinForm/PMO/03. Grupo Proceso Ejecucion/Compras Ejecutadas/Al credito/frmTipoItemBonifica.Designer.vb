<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTipoItemBonifica
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
        Me.rbIgual = New System.Windows.Forms.RadioButton()
        Me.rbRef = New System.Windows.Forms.RadioButton()
        Me.ButtonCategoria = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.SuspendLayout()
        '
        'rbIgual
        '
        Me.rbIgual.AutoSize = True
        Me.rbIgual.Checked = True
        Me.rbIgual.ForeColor = System.Drawing.Color.DimGray
        Me.rbIgual.Location = New System.Drawing.Point(5, 19)
        Me.rbIgual.Name = "rbIgual"
        Me.rbIgual.Size = New System.Drawing.Size(110, 17)
        Me.rbIgual.TabIndex = 0
        Me.rbIgual.TabStop = True
        Me.rbIgual.Text = "Igual al comprado"
        Me.rbIgual.UseVisualStyleBackColor = True
        '
        'rbRef
        '
        Me.rbRef.AutoSize = True
        Me.rbRef.ForeColor = System.Drawing.Color.DimGray
        Me.rbRef.Location = New System.Drawing.Point(128, 12)
        Me.rbRef.Name = "rbRef"
        Me.rbRef.Size = New System.Drawing.Size(142, 30)
        Me.rbRef.TabIndex = 1
        Me.rbRef.Text = "Distinto al comprado" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "y referenciado a un item"
        Me.rbRef.UseVisualStyleBackColor = True
        '
        'ButtonCategoria
        '
        Me.ButtonCategoria.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonCategoria.BackColor = System.Drawing.SystemColors.Highlight
        Me.ButtonCategoria.BeforeTouchSize = New System.Drawing.Size(91, 26)
        Me.ButtonCategoria.ForeColor = System.Drawing.Color.White
        Me.ButtonCategoria.IsBackStageButton = False
        Me.ButtonCategoria.Location = New System.Drawing.Point(97, 54)
        Me.ButtonCategoria.Name = "ButtonCategoria"
        Me.ButtonCategoria.Size = New System.Drawing.Size(91, 26)
        Me.ButtonCategoria.TabIndex = 215
        Me.ButtonCategoria.Text = "Aceptar"
        Me.ButtonCategoria.UseVisualStyle = True
        '
        'frmTipoItemBonifica
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.CaptionForeColor = System.Drawing.Color.DarkOliveGreen
        Me.ClientSize = New System.Drawing.Size(282, 78)
        Me.Controls.Add(Me.ButtonCategoria)
        Me.Controls.Add(Me.rbRef)
        Me.Controls.Add(Me.rbIgual)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTipoItemBonifica"
        Me.Text = "Bonificación?"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rbIgual As System.Windows.Forms.RadioButton
    Friend WithEvents rbRef As System.Windows.Forms.RadioButton
    Private WithEvents ButtonCategoria As Syncfusion.Windows.Forms.ButtonAdv
End Class

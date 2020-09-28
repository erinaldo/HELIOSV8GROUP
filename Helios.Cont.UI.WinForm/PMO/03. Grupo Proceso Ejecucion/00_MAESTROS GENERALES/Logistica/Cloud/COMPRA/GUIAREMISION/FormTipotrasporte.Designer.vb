Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormTipotrasporte
    Inherits MetroForm

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbTipotras = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        CType(Me.cbTipotras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(23, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 13)
        Me.Label5.TabIndex = 684
        Me.Label5.Text = "Tipo de trasporte"
        '
        'cbTipotras
        '
        Me.cbTipotras.BackColor = System.Drawing.Color.White
        Me.cbTipotras.BeforeTouchSize = New System.Drawing.Size(259, 21)
        Me.cbTipotras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTipotras.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTipotras.Location = New System.Drawing.Point(12, 36)
        Me.cbTipotras.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.cbTipotras.MetroColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.cbTipotras.Name = "cbTipotras"
        Me.cbTipotras.Size = New System.Drawing.Size(259, 21)
        Me.cbTipotras.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cbTipotras.TabIndex = 683
        '
        'FormTipotrasporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.CaptionButtonColor = System.Drawing.Color.White
        Me.CaptionButtonHoverColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(334, 69)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cbTipotras)
        Me.Name = "FormTipotrasporte"
        Me.ShowIcon = False
        Me.Text = "Tipo de Trasnporte"
        CType(Me.cbTipotras, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label5 As Label
    Friend WithEvents cbTipotras As Tools.ComboBoxAdv
End Class

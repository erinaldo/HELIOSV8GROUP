<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UCVentaDescripcion
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
        Me.txtDescripcionVenta = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'txtDescripcionVenta
        '
        Me.txtDescripcionVenta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDescripcionVenta.Location = New System.Drawing.Point(0, 0)
        Me.txtDescripcionVenta.Multiline = True
        Me.txtDescripcionVenta.Name = "txtDescripcionVenta"
        Me.txtDescripcionVenta.Size = New System.Drawing.Size(746, 180)
        Me.txtDescripcionVenta.TabIndex = 0
        '
        'UCVentaDescripcion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txtDescripcionVenta)
        Me.Name = "UCVentaDescripcion"
        Me.Size = New System.Drawing.Size(746, 180)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtDescripcionVenta As TextBox
End Class

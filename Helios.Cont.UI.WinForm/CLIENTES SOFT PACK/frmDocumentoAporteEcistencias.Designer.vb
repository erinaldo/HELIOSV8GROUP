<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDocumentoAporteEcistencias
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Uc_inicio_existencias1 = New Helios.Cont.Presentation.WinForm.uc_inicio_existencias()
        Me.SuspendLayout()
        '
        'Uc_inicio_existencias1
        '
        Me.Uc_inicio_existencias1.BackColor = System.Drawing.Color.LightGray
        Me.Uc_inicio_existencias1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Uc_inicio_existencias1.Location = New System.Drawing.Point(12, 12)
        Me.Uc_inicio_existencias1.Name = "Uc_inicio_existencias1"
        Me.Uc_inicio_existencias1.Size = New System.Drawing.Size(909, 406)
        Me.Uc_inicio_existencias1.TabIndex = 0
        '
        'frmDocumentoAporteEcistencias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(933, 427)
        Me.Controls.Add(Me.Uc_inicio_existencias1)
        Me.Name = "frmDocumentoAporteEcistencias"
        Me.Text = "frmDocumentoAporteEcistencias"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Uc_inicio_existencias1 As uc_inicio_existencias
End Class

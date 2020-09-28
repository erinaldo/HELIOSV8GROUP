<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmArqueoCaja
    Inherits Helios.Cont.Presentation.WinForm.frmMaster

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
        Me.rptCaja = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.SuspendLayout()
        '
        'rptCaja
        '
        Me.rptCaja.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rptCaja.Location = New System.Drawing.Point(0, 0)
        Me.rptCaja.Name = "rptCaja"
        Me.rptCaja.Size = New System.Drawing.Size(638, 363)
        Me.rptCaja.TabIndex = 2
        '
        'frmArqueoCaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(638, 363)
        Me.Controls.Add(Me.rptCaja)
        Me.Name = "frmArqueoCaja"
        Me.ShowIcon = False
        Me.Text = "Reporte Arqueo de caja"
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents rptCaja As Microsoft.Reporting.WinForms.ReportViewer
End Class

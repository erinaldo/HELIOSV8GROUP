<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteLibroMayor
    Inherits Qios.DevSuite.Components.Ribbon.QRibbonForm

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
        Me.QRibbonCaption1 = New Qios.DevSuite.Components.Ribbon.QRibbonCaption()
        Me.rptLibroMayor = New Microsoft.Reporting.WinForms.ReportViewer()
        CType(Me.QRibbonCaption1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'QRibbonCaption1
        '
        Me.QRibbonCaption1.Location = New System.Drawing.Point(0, 0)
        Me.QRibbonCaption1.Name = "QRibbonCaption1"
        Me.QRibbonCaption1.Size = New System.Drawing.Size(581, 28)
        Me.QRibbonCaption1.TabIndex = 50
        Me.QRibbonCaption1.Text = "Reporte Libro Mayor"
        '
        'rptLibroMayor
        '
        Me.rptLibroMayor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rptLibroMayor.Location = New System.Drawing.Point(0, 28)
        Me.rptLibroMayor.Name = "rptLibroMayor"
        Me.rptLibroMayor.Size = New System.Drawing.Size(581, 335)
        Me.rptLibroMayor.TabIndex = 51
        '
        'frmReporteLibroMayor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(581, 363)
        Me.Controls.Add(Me.rptLibroMayor)
        Me.Controls.Add(Me.QRibbonCaption1)
        Me.Name = "frmReporteLibroMayor"
        Me.Text = "Reporte Libro Mayor"
        CType(Me.QRibbonCaption1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents QRibbonCaption1 As Qios.DevSuite.Components.Ribbon.QRibbonCaption
    Friend WithEvents rptLibroMayor As Microsoft.Reporting.WinForms.ReportViewer
End Class

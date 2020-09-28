<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteHojaTrabajoFinal
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
        Me.rptHojaTrabajoFinal = New Microsoft.Reporting.WinForms.ReportViewer()
        CType(Me.QRibbonCaption1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'QRibbonCaption1
        '
        Me.QRibbonCaption1.Location = New System.Drawing.Point(0, 0)
        Me.QRibbonCaption1.Name = "QRibbonCaption1"
        Me.QRibbonCaption1.Size = New System.Drawing.Size(602, 28)
        Me.QRibbonCaption1.TabIndex = 5
        Me.QRibbonCaption1.Text = "Reporte -  Hoja de trabajo Final"
        '
        'rptHojaTrabajoFinal
        '
        Me.rptHojaTrabajoFinal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rptHojaTrabajoFinal.Location = New System.Drawing.Point(0, 28)
        Me.rptHojaTrabajoFinal.Name = "rptHojaTrabajoFinal"
        Me.rptHojaTrabajoFinal.Size = New System.Drawing.Size(602, 345)
        Me.rptHojaTrabajoFinal.TabIndex = 6
        '
        'frmReporteHojaTrabajoFinal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(602, 373)
        Me.Controls.Add(Me.rptHojaTrabajoFinal)
        Me.Controls.Add(Me.QRibbonCaption1)
        Me.Name = "frmReporteHojaTrabajoFinal"
        Me.Text = "Reporte -  Hoja de trabajo Final"
        CType(Me.QRibbonCaption1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents QRibbonCaption1 As Qios.DevSuite.Components.Ribbon.QRibbonCaption
    Friend WithEvents rptHojaTrabajoFinal As Microsoft.Reporting.WinForms.ReportViewer
End Class

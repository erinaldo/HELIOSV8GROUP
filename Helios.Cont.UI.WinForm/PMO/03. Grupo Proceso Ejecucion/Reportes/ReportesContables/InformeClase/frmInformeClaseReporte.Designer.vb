<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInformeClaseReporte
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
        Me.rptInformeClase = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.QRibbonCaption1 = New Qios.DevSuite.Components.Ribbon.QRibbonCaption()
        CType(Me.QRibbonCaption1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rptInformeClase
        '
        Me.rptInformeClase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rptInformeClase.Location = New System.Drawing.Point(0, 28)
        Me.rptInformeClase.Name = "rptInformeClase"
        Me.rptInformeClase.Size = New System.Drawing.Size(605, 346)
        Me.rptInformeClase.TabIndex = 53
        '
        'QRibbonCaption1
        '
        Me.QRibbonCaption1.Location = New System.Drawing.Point(0, 0)
        Me.QRibbonCaption1.Name = "QRibbonCaption1"
        Me.QRibbonCaption1.Size = New System.Drawing.Size(605, 28)
        Me.QRibbonCaption1.TabIndex = 52
        Me.QRibbonCaption1.Text = "&Reporte - Informe por clase"
        '
        'frmInformeClaseReporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(605, 374)
        Me.Controls.Add(Me.rptInformeClase)
        Me.Controls.Add(Me.QRibbonCaption1)
        Me.Name = "frmInformeClaseReporte"
        Me.Text = "&Reporte - Informe por clase"
        CType(Me.QRibbonCaption1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rptInformeClase As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents QRibbonCaption1 As Qios.DevSuite.Components.Ribbon.QRibbonCaption
End Class

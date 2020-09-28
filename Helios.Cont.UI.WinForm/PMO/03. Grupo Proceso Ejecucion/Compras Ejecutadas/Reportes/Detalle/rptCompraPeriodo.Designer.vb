<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rptCompraPeriodo
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
        Me.components = New System.ComponentModel.Container()
        Me.QGlobalColorSchemeManager1 = New Qios.DevSuite.Components.QGlobalColorSchemeManager(Me.components)
        Me.QRibbonCaption1 = New Qios.DevSuite.Components.Ribbon.QRibbonCaption()
        Me.rptCompras = New Microsoft.Reporting.WinForms.ReportViewer()
        CType(Me.QRibbonCaption1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'QGlobalColorSchemeManager1
        '
        Me.QGlobalColorSchemeManager1.Global.CurrentTheme = "LunaBlue"
        Me.QGlobalColorSchemeManager1.Global.InheritCurrentThemeFromWindows = False
        '
        'QRibbonCaption1
        '
        Me.QRibbonCaption1.Location = New System.Drawing.Point(0, 0)
        Me.QRibbonCaption1.Name = "QRibbonCaption1"
        Me.QRibbonCaption1.Size = New System.Drawing.Size(631, 28)
        Me.QRibbonCaption1.TabIndex = 0
        Me.QRibbonCaption1.Text = "Reporte de compras por Período."
        '
        'rptCompras
        '
        Me.rptCompras.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rptCompras.Location = New System.Drawing.Point(0, 28)
        Me.rptCompras.Name = "rptCompras"
        Me.rptCompras.Size = New System.Drawing.Size(631, 318)
        Me.rptCompras.TabIndex = 3
        '
        'rptCompraPeriodo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(631, 346)
        Me.Controls.Add(Me.rptCompras)
        Me.Controls.Add(Me.QRibbonCaption1)
        Me.Name = "rptCompraPeriodo"
        Me.Text = "Reporte de compras por Período."
        CType(Me.QRibbonCaption1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents QGlobalColorSchemeManager1 As Qios.DevSuite.Components.QGlobalColorSchemeManager
    Friend WithEvents QRibbonCaption1 As Qios.DevSuite.Components.Ribbon.QRibbonCaption
    Friend WithEvents rptCompras As Microsoft.Reporting.WinForms.ReportViewer
End Class

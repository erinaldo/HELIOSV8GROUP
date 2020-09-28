<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModalPersonas
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
        Me.txtFiltro = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.lstPersonas = New System.Windows.Forms.ListBox()
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
        Me.QRibbonCaption1.Size = New System.Drawing.Size(336, 28)
        Me.QRibbonCaption1.TabIndex = 0
        Me.QRibbonCaption1.Text = "Búsqueda de personas"
        '
        'txtFiltro
        '
        Me.txtFiltro.Location = New System.Drawing.Point(15, 55)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(300, 19)
        Me.txtFiltro.TabIndex = 1
        '
        'lstPersonas
        '
        Me.lstPersonas.BackColor = System.Drawing.SystemColors.Info
        Me.lstPersonas.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lstPersonas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lstPersonas.FormattingEnabled = True
        Me.lstPersonas.Location = New System.Drawing.Point(0, 88)
        Me.lstPersonas.Name = "lstPersonas"
        Me.lstPersonas.Size = New System.Drawing.Size(336, 173)
        Me.lstPersonas.TabIndex = 2
        '
        'frmModalPersonas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(336, 261)
        Me.Controls.Add(Me.lstPersonas)
        Me.Controls.Add(Me.txtFiltro)
        Me.Controls.Add(Me.QRibbonCaption1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmModalPersonas"
        Me.Text = "Búsqueda de personas"
        CType(Me.QRibbonCaption1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents QGlobalColorSchemeManager1 As Qios.DevSuite.Components.QGlobalColorSchemeManager
    Friend WithEvents QRibbonCaption1 As Qios.DevSuite.Components.Ribbon.QRibbonCaption
    Friend WithEvents txtFiltro As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents lstPersonas As System.Windows.Forms.ListBox
End Class

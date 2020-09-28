<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLibroMayorTipoReporte
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboCuentas = New System.Windows.Forms.ComboBox()
        Me.rbTodo = New System.Windows.Forms.RadioButton()
        Me.rbPorCuenta = New System.Windows.Forms.RadioButton()
        Me.btnAceptar = New System.Windows.Forms.Button()
        CType(Me.QRibbonCaption1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'QRibbonCaption1
        '
        Me.QRibbonCaption1.Location = New System.Drawing.Point(0, 0)
        Me.QRibbonCaption1.Name = "QRibbonCaption1"
        Me.QRibbonCaption1.Size = New System.Drawing.Size(377, 28)
        Me.QRibbonCaption1.TabIndex = 49
        Me.QRibbonCaption1.Text = "Tipo de Reporte"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbPorCuenta)
        Me.GroupBox1.Controls.Add(Me.rbTodo)
        Me.GroupBox1.Controls.Add(Me.cboCuentas)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 34)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(259, 91)
        Me.GroupBox1.TabIndex = 51
        Me.GroupBox1.TabStop = False
        '
        'cboCuentas
        '
        Me.cboCuentas.Enabled = False
        Me.cboCuentas.FormattingEnabled = True
        Me.cboCuentas.Location = New System.Drawing.Point(96, 54)
        Me.cboCuentas.Name = "cboCuentas"
        Me.cboCuentas.Size = New System.Drawing.Size(137, 21)
        Me.cboCuentas.TabIndex = 66
        '
        'rbTodo
        '
        Me.rbTodo.AutoSize = True
        Me.rbTodo.Checked = True
        Me.rbTodo.Location = New System.Drawing.Point(12, 23)
        Me.rbTodo.Name = "rbTodo"
        Me.rbTodo.Size = New System.Drawing.Size(50, 17)
        Me.rbTodo.TabIndex = 67
        Me.rbTodo.TabStop = True
        Me.rbTodo.Text = "Todo"
        Me.rbTodo.UseVisualStyleBackColor = True
        '
        'rbPorCuenta
        '
        Me.rbPorCuenta.AutoSize = True
        Me.rbPorCuenta.Location = New System.Drawing.Point(12, 55)
        Me.rbPorCuenta.Name = "rbPorCuenta"
        Me.rbPorCuenta.Size = New System.Drawing.Size(78, 17)
        Me.rbPorCuenta.TabIndex = 68
        Me.rbPorCuenta.Text = "Por Cuenta"
        Me.rbPorCuenta.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(265, 41)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(100, 25)
        Me.btnAceptar.TabIndex = 52
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'frmLibroMayorTipoReporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(377, 131)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.QRibbonCaption1)
        Me.Name = "frmLibroMayorTipoReporte"
        Me.Text = "Tipo de Reporte"
        CType(Me.QRibbonCaption1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents QRibbonCaption1 As Qios.DevSuite.Components.Ribbon.QRibbonCaption
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbPorCuenta As System.Windows.Forms.RadioButton
    Friend WithEvents rbTodo As System.Windows.Forms.RadioButton
    Friend WithEvents cboCuentas As System.Windows.Forms.ComboBox
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
End Class

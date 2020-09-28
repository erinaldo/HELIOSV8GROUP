<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormImpresionCaja
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbA4 = New System.Windows.Forms.RadioButton()
        Me.rbTicket = New System.Windows.Forms.RadioButton()
        Me.cboImpresoras = New System.Windows.Forms.ComboBox()
        Me.brnImprimir = New System.Windows.Forms.Button()
        Me.ComboCaja = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.btnConfigurar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ComboCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.Location = New System.Drawing.Point(82, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 14)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "¿Desea imprImir?"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(133, 186)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 16
        Me.Button1.Text = "Cerrar"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 14)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Seleccionar una impresora"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbA4)
        Me.GroupBox1.Controls.Add(Me.rbTicket)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 71)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(226, 68)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo Documento"
        '
        'rbA4
        '
        Me.rbA4.AutoSize = True
        Me.rbA4.Location = New System.Drawing.Point(22, 42)
        Me.rbA4.Name = "rbA4"
        Me.rbA4.Size = New System.Drawing.Size(119, 18)
        Me.rbA4.TabIndex = 6
        Me.rbA4.TabStop = True
        Me.rbA4.Text = "A4 (210 x 297 mm)"
        Me.rbA4.UseVisualStyleBackColor = True
        '
        'rbTicket
        '
        Me.rbTicket.AutoSize = True
        Me.rbTicket.Checked = True
        Me.rbTicket.Location = New System.Drawing.Point(22, 19)
        Me.rbTicket.Name = "rbTicket"
        Me.rbTicket.Size = New System.Drawing.Size(129, 18)
        Me.rbTicket.TabIndex = 5
        Me.rbTicket.TabStop = True
        Me.rbTicket.Text = "Ticket (80 x 297 mm)"
        Me.rbTicket.UseVisualStyleBackColor = True
        '
        'cboImpresoras
        '
        Me.cboImpresoras.FormattingEnabled = True
        Me.cboImpresoras.Location = New System.Drawing.Point(15, 43)
        Me.cboImpresoras.Name = "cboImpresoras"
        Me.cboImpresoras.Size = New System.Drawing.Size(226, 22)
        Me.cboImpresoras.TabIndex = 13
        '
        'brnImprimir
        '
        Me.brnImprimir.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.brnImprimir.FlatAppearance.BorderSize = 0
        Me.brnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.brnImprimir.ForeColor = System.Drawing.Color.White
        Me.brnImprimir.Location = New System.Drawing.Point(53, 186)
        Me.brnImprimir.Name = "brnImprimir"
        Me.brnImprimir.Size = New System.Drawing.Size(75, 23)
        Me.brnImprimir.TabIndex = 12
        Me.brnImprimir.Text = "Imprimir"
        Me.brnImprimir.UseVisualStyleBackColor = False
        '
        'ComboCaja
        '
        Me.ComboCaja.BackColor = System.Drawing.Color.White
        Me.ComboCaja.BeforeTouchSize = New System.Drawing.Size(226, 21)
        Me.ComboCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboCaja.Enabled = False
        Me.ComboCaja.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboCaja.Location = New System.Drawing.Point(15, 153)
        Me.ComboCaja.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ComboCaja.Name = "ComboCaja"
        Me.ComboCaja.Size = New System.Drawing.Size(226, 21)
        Me.ComboCaja.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboCaja.TabIndex = 219
        '
        'btnConfigurar
        '
        Me.btnConfigurar.Location = New System.Drawing.Point(186, 233)
        Me.btnConfigurar.Name = "btnConfigurar"
        Me.btnConfigurar.Size = New System.Drawing.Size(75, 23)
        Me.btnConfigurar.TabIndex = 220
        Me.btnConfigurar.Text = "Configurar"
        Me.btnConfigurar.UseVisualStyleBackColor = True
        Me.btnConfigurar.Visible = False
        '
        'FormImpresionCaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(253, 217)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnConfigurar)
        Me.Controls.Add(Me.ComboCaja)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cboImpresoras)
        Me.Controls.Add(Me.brnImprimir)
        Me.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "FormImpresionCaja"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ComboCaja, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rbA4 As RadioButton
    Friend WithEvents rbTicket As RadioButton
    Friend WithEvents cboImpresoras As ComboBox
    Friend WithEvents brnImprimir As Button
    Friend WithEvents ComboCaja As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents btnConfigurar As Button
End Class

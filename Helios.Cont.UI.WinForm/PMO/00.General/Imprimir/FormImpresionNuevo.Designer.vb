<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormImpresionNuevo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormImpresionNuevo))
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtFormato = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnCorreo = New System.Windows.Forms.Button()
        Me.txtNroImpresion = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.btnPdf = New System.Windows.Forms.Button()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        CType(Me.txtNroImpresion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(9, 32)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(217, 21)
        Me.ComboBox1.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(132, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Seleccionar una impresora"
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtFormato)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.btnCorreo)
        Me.GroupBox2.Controls.Add(Me.txtNroImpresion)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.ComboBox1)
        Me.GroupBox2.Location = New System.Drawing.Point(2, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(246, 170)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "                    ¿Desea imprImir?"
        '
        'txtFormato
        '
        Me.txtFormato.BackColor = System.Drawing.Color.White
        Me.txtFormato.Location = New System.Drawing.Point(9, 82)
        Me.txtFormato.Name = "txtFormato"
        Me.txtFormato.ReadOnly = True
        Me.txtFormato.Size = New System.Drawing.Size(120, 20)
        Me.txtFormato.TabIndex = 16
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Enabled = False
        Me.Label5.Location = New System.Drawing.Point(6, 66)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Formato"
        '
        'btnCorreo
        '
        Me.btnCorreo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCorreo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCorreo.Image = CType(resources.GetObject("btnCorreo.Image"), System.Drawing.Image)
        Me.btnCorreo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCorreo.Location = New System.Drawing.Point(54, 173)
        Me.btnCorreo.Name = "btnCorreo"
        Me.btnCorreo.Size = New System.Drawing.Size(156, 45)
        Me.btnCorreo.TabIndex = 468
        Me.btnCorreo.Text = "          Enviar correo [F3]"
        Me.btnCorreo.UseVisualStyleBackColor = True
        Me.btnCorreo.Visible = False
        '
        'txtNroImpresion
        '
        Me.txtNroImpresion.Location = New System.Drawing.Point(9, 135)
        Me.txtNroImpresion.Name = "txtNroImpresion"
        Me.txtNroImpresion.Size = New System.Drawing.Size(120, 20)
        Me.txtNroImpresion.TabIndex = 15
        Me.txtNroImpresion.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Enabled = False
        Me.Label2.Location = New System.Drawing.Point(6, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Nro. Impresión"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button5)
        Me.GroupBox3.Controls.Add(Me.btnPdf)
        Me.GroupBox3.Controls.Add(Me.btnImprimir)
        Me.GroupBox3.Location = New System.Drawing.Point(254, 2)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(169, 170)
        Me.GroupBox3.TabIndex = 15
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "                 Opciones"
        '
        'Button5
        '
        Me.Button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button5.Location = New System.Drawing.Point(7, 116)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(156, 45)
        Me.Button5.TabIndex = 470
        Me.Button5.Text = "     Salir [ESC]"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'btnPdf
        '
        Me.btnPdf.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPdf.Image = CType(resources.GetObject("btnPdf.Image"), System.Drawing.Image)
        Me.btnPdf.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPdf.Location = New System.Drawing.Point(7, 66)
        Me.btnPdf.Name = "btnPdf"
        Me.btnPdf.Size = New System.Drawing.Size(156, 45)
        Me.btnPdf.TabIndex = 469
        Me.btnPdf.Text = "          Guardar PDF [F4]"
        Me.btnPdf.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImprimir.Location = New System.Drawing.Point(6, 16)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(156, 45)
        Me.btnImprimir.TabIndex = 466
        Me.btnImprimir.Text = "     Imprimir [F2]"
        Me.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'FormImpresionNuevo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(426, 179)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormImpresionNuevo"
        Me.ShowIcon = False
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.txtNroImpresion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rbA4 As RadioButton
    Friend WithEvents rbTicket As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
    Friend WithEvents PageSetupDialog1 As PageSetupDialog
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents btnImprimir As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents txtNroImpresion As NumericUpDown
    Friend WithEvents Button5 As Button
    Friend WithEvents btnPdf As Button
    Friend WithEvents btnCorreo As Button
    Friend WithEvents txtFormato As TextBox
    Friend WithEvents Label5 As Label
End Class

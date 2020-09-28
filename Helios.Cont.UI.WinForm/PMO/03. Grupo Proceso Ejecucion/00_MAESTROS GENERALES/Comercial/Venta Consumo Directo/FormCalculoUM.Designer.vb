<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormCalculoUM
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCalculoUM))
        Me.btnImportar = New System.Windows.Forms.Button()
        Me.btnConfigurar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTotalPies = New System.Windows.Forms.TextBox()
        Me.btnCalcular = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtMedida1 = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.txtMedida2 = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.txtCantidad = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.txtMedida1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMedida2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnImportar
        '
        Me.btnImportar.Location = New System.Drawing.Point(145, 126)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(75, 23)
        Me.btnImportar.TabIndex = 4
        Me.btnImportar.Text = "Aceptar"
        Me.btnImportar.UseVisualStyleBackColor = True
        '
        'btnConfigurar
        '
        Me.btnConfigurar.Location = New System.Drawing.Point(206, 285)
        Me.btnConfigurar.Name = "btnConfigurar"
        Me.btnConfigurar.Size = New System.Drawing.Size(75, 23)
        Me.btnConfigurar.TabIndex = 9
        Me.btnConfigurar.Text = "Configurar"
        Me.btnConfigurar.UseVisualStyleBackColor = True
        Me.btnConfigurar.Visible = False
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(225, 126)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 10
        Me.btnCancelar.Text = "Cerrar"
        Me.btnCancelar.UseVisualStyleBackColor = True
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(83, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(147, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Calculo de Unidad de Medida"
        '
        'txtTotalPies
        '
        Me.txtTotalPies.Location = New System.Drawing.Point(86, 100)
        Me.txtTotalPies.Name = "txtTotalPies"
        Me.txtTotalPies.ReadOnly = True
        Me.txtTotalPies.Size = New System.Drawing.Size(151, 20)
        Me.txtTotalPies.TabIndex = 4
        Me.txtTotalPies.Text = "0"
        Me.txtTotalPies.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnCalcular
        '
        Me.btnCalcular.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCalcular.Location = New System.Drawing.Point(243, 39)
        Me.btnCalcular.Name = "btnCalcular"
        Me.btnCalcular.Size = New System.Drawing.Size(55, 21)
        Me.btnCalcular.TabIndex = 16
        Me.btnCalcular.Text = "Calcular"
        Me.btnCalcular.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label3.Location = New System.Drawing.Point(155, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(14, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "X"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(32, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Medida :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 107)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Total pies :"
        '
        'txtMedida1
        '
        Me.txtMedida1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtMedida1.BeforeTouchSize = New System.Drawing.Size(63, 21)
        Me.txtMedida1.BorderColor = System.Drawing.Color.Silver
        Me.txtMedida1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMedida1.DecimalPlaces = 3
        Me.txtMedida1.Font = New System.Drawing.Font("Arial", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMedida1.ForeColor = System.Drawing.Color.Black
        Me.txtMedida1.Location = New System.Drawing.Point(86, 38)
        Me.txtMedida1.Maximum = New Decimal(New Integer() {-159383552, 46653770, 5421, 0})
        Me.txtMedida1.MetroColor = System.Drawing.Color.Silver
        Me.txtMedida1.Name = "txtMedida1"
        Me.txtMedida1.Size = New System.Drawing.Size(63, 21)
        Me.txtMedida1.TabIndex = 1
        Me.txtMedida1.TabStop = False
        Me.txtMedida1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtMedida1.ThousandsSeparator = True
        Me.txtMedida1.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'txtMedida2
        '
        Me.txtMedida2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtMedida2.BeforeTouchSize = New System.Drawing.Size(63, 21)
        Me.txtMedida2.BorderColor = System.Drawing.Color.Silver
        Me.txtMedida2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMedida2.DecimalPlaces = 3
        Me.txtMedida2.Font = New System.Drawing.Font("Arial", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMedida2.ForeColor = System.Drawing.Color.Black
        Me.txtMedida2.Location = New System.Drawing.Point(174, 38)
        Me.txtMedida2.Maximum = New Decimal(New Integer() {-159383552, 46653770, 5421, 0})
        Me.txtMedida2.MetroColor = System.Drawing.Color.Silver
        Me.txtMedida2.Name = "txtMedida2"
        Me.txtMedida2.Size = New System.Drawing.Size(63, 21)
        Me.txtMedida2.TabIndex = 2
        Me.txtMedida2.TabStop = False
        Me.txtMedida2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtMedida2.ThousandsSeparator = True
        Me.txtMedida2.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'txtCantidad
        '
        Me.txtCantidad.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtCantidad.BeforeTouchSize = New System.Drawing.Size(63, 21)
        Me.txtCantidad.BorderColor = System.Drawing.Color.Silver
        Me.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCantidad.Font = New System.Drawing.Font("Arial", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad.ForeColor = System.Drawing.Color.Black
        Me.txtCantidad.Location = New System.Drawing.Point(86, 67)
        Me.txtCantidad.Maximum = New Decimal(New Integer() {-159383552, 46653770, 5421, 0})
        Me.txtCantidad.MetroColor = System.Drawing.Color.Silver
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(63, 21)
        Me.txtCantidad.TabIndex = 20
        Me.txtCantidad.TabStop = False
        Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtCantidad.ThousandsSeparator = True
        Me.txtCantidad.Value = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtCantidad.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(25, 75)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 13)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Cantidad :"
        '
        'FormCalculoUM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(310, 158)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtCantidad)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtMedida2)
        Me.Controls.Add(Me.txtMedida1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnCalcular)
        Me.Controls.Add(Me.txtTotalPies)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnConfigurar)
        Me.Controls.Add(Me.btnImportar)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormCalculoUM"
        Me.ShowIcon = False
        CType(Me.txtMedida1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMedida2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnImportar As Button
    Friend WithEvents btnConfigurar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
    Friend WithEvents PageSetupDialog1 As PageSetupDialog
    Friend WithEvents Label2 As Label
    Friend WithEvents txtTotalPies As TextBox
    Friend WithEvents btnCalcular As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtMedida1 As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents txtMedida2 As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents txtCantidad As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents Label5 As Label
End Class

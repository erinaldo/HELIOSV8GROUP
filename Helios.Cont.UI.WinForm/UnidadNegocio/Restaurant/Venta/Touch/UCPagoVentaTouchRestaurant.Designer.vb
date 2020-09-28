<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UCPagoVentaTouchRestaurant
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.RBNo = New System.Windows.Forms.RadioButton()
        Me.RBSi = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RadioButton5 = New System.Windows.Forms.RadioButton()
        Me.RBCronograma = New System.Windows.Forms.RadioButton()
        Me.RBPagoAcumulado = New System.Windows.Forms.RadioButton()
        Me.PanelBody = New System.Windows.Forms.Panel()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GradientPanel2
        '
        Me.GradientPanel2.BackColor = System.Drawing.Color.White
        Me.GradientPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GradientPanel2.BorderColor = System.Drawing.Color.LightGray
        Me.GradientPanel2.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.GradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel2.Controls.Add(Me.GroupBox1)
        Me.GradientPanel2.Controls.Add(Me.GroupBox3)
        Me.GradientPanel2.Controls.Add(Me.GroupBox2)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(1131, 64)
        Me.GradientPanel2.TabIndex = 10
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(205, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(220, 53)
        Me.GroupBox1.TabIndex = 620
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "2. Modalidad de pago"
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Enabled = False
        Me.RadioButton2.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton2.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.RadioButton2.Location = New System.Drawing.Point(224, 28)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(84, 17)
        Me.RadioButton2.TabIndex = 622
        Me.RadioButton2.Text = "Pago x item"
        Me.RadioButton2.UseVisualStyleBackColor = True
        Me.RadioButton2.Visible = False
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton1.ForeColor = System.Drawing.Color.Black
        Me.RadioButton1.Location = New System.Drawing.Point(26, 28)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(154, 17)
        Me.RadioButton1.TabIndex = 621
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "PAGO POR DOCUMENTO"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.RBNo)
        Me.GroupBox3.Controls.Add(Me.RBSi)
        Me.GroupBox3.Enabled = False
        Me.GroupBox3.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(15, 5)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(184, 53)
        Me.GroupBox3.TabIndex = 628
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "1. Desea realizar el cobro ?"
        '
        'RBNo
        '
        Me.RBNo.AutoSize = True
        Me.RBNo.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBNo.ForeColor = System.Drawing.Color.Black
        Me.RBNo.Location = New System.Drawing.Point(97, 27)
        Me.RBNo.Name = "RBNo"
        Me.RBNo.Size = New System.Drawing.Size(42, 17)
        Me.RBNo.TabIndex = 622
        Me.RBNo.Text = "NO"
        Me.RBNo.UseVisualStyleBackColor = True
        '
        'RBSi
        '
        Me.RBSi.AutoSize = True
        Me.RBSi.Checked = True
        Me.RBSi.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBSi.ForeColor = System.Drawing.Color.Black
        Me.RBSi.Location = New System.Drawing.Point(27, 28)
        Me.RBSi.Name = "RBSi"
        Me.RBSi.Size = New System.Drawing.Size(34, 17)
        Me.RBSi.TabIndex = 621
        Me.RBSi.TabStop = True
        Me.RBSi.Text = "SI"
        Me.RBSi.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RadioButton5)
        Me.GroupBox2.Controls.Add(Me.RBCronograma)
        Me.GroupBox2.Controls.Add(Me.RBPagoAcumulado)
        Me.GroupBox2.Enabled = False
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(431, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(321, 53)
        Me.GroupBox2.TabIndex = 627
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "3. Modo de cobro"
        '
        'RadioButton5
        '
        Me.RadioButton5.AutoSize = True
        Me.RadioButton5.Enabled = False
        Me.RadioButton5.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton5.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.RadioButton5.Location = New System.Drawing.Point(321, 27)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(83, 17)
        Me.RadioButton5.TabIndex = 625
        Me.RadioButton5.Text = "Compensar"
        Me.RadioButton5.UseVisualStyleBackColor = True
        Me.RadioButton5.Visible = False
        '
        'RBCronograma
        '
        Me.RBCronograma.AutoSize = True
        Me.RBCronograma.Enabled = False
        Me.RBCronograma.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBCronograma.ForeColor = System.Drawing.Color.Black
        Me.RBCronograma.Location = New System.Drawing.Point(195, 27)
        Me.RBCronograma.Name = "RBCronograma"
        Me.RBCronograma.Size = New System.Drawing.Size(106, 17)
        Me.RBCronograma.TabIndex = 624
        Me.RBCronograma.Text = "CRONOGRAMA"
        Me.RBCronograma.UseVisualStyleBackColor = True
        '
        'RBPagoAcumulado
        '
        Me.RBPagoAcumulado.AutoSize = True
        Me.RBPagoAcumulado.Checked = True
        Me.RBPagoAcumulado.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBPagoAcumulado.ForeColor = System.Drawing.Color.Black
        Me.RBPagoAcumulado.Location = New System.Drawing.Point(29, 27)
        Me.RBPagoAcumulado.Name = "RBPagoAcumulado"
        Me.RBPagoAcumulado.Size = New System.Drawing.Size(157, 17)
        Me.RBPagoAcumulado.TabIndex = 623
        Me.RBPagoAcumulado.TabStop = True
        Me.RBPagoAcumulado.Text = "COBRO TOTAL O PARCIAL"
        Me.RBPagoAcumulado.UseVisualStyleBackColor = True
        '
        'PanelBody
        '
        Me.PanelBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelBody.Location = New System.Drawing.Point(0, 64)
        Me.PanelBody.Name = "PanelBody"
        Me.PanelBody.Size = New System.Drawing.Size(1131, 496)
        Me.PanelBody.TabIndex = 11
        '
        'UCPagoVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PanelBody)
        Me.Controls.Add(Me.GradientPanel2)
        Me.Name = "UCPagoVenta"
        Me.Size = New System.Drawing.Size(1131, 560)
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GradientPanel2 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents RBNo As RadioButton
    Friend WithEvents RBSi As RadioButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents RadioButton5 As RadioButton
    Friend WithEvents RBCronograma As RadioButton
    Friend WithEvents RBPagoAcumulado As RadioButton
    Friend WithEvents PanelBody As Panel
End Class

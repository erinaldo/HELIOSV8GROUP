<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucSaldos
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.label1 = New System.Windows.Forms.Label()
        Me.pictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblSaldoMN = New System.Windows.Forms.Label()
        Me.lblSaldoME = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblImporteNCme = New System.Windows.Forms.Label()
        Me.lblImporteNCmn = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblImporteNBme = New System.Windows.Forms.Label()
        Me.lblImporteNBmn = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.BackColor = System.Drawing.Color.Transparent
        Me.label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.label1.Location = New System.Drawing.Point(34, 14)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(131, 14)
        Me.label1.TabIndex = 5
        Me.label1.Text = "Documento compra:"
        '
        'pictureBox1
        '
        Me.pictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.pictureBox1.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.Information_icon
        Me.pictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.pictureBox1.Name = "pictureBox1"
        Me.pictureBox1.Size = New System.Drawing.Size(16, 16)
        Me.pictureBox1.TabIndex = 4
        Me.pictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(34, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Saldo mn:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(34, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Saldo me:"
        '
        'lblSaldoMN
        '
        Me.lblSaldoMN.AutoSize = True
        Me.lblSaldoMN.Location = New System.Drawing.Point(94, 42)
        Me.lblSaldoMN.Name = "lblSaldoMN"
        Me.lblSaldoMN.Size = New System.Drawing.Size(29, 13)
        Me.lblSaldoMN.TabIndex = 8
        Me.lblSaldoMN.Text = "0.00"
        '
        'lblSaldoME
        '
        Me.lblSaldoME.AutoSize = True
        Me.lblSaldoME.Location = New System.Drawing.Point(94, 68)
        Me.lblSaldoME.Name = "lblSaldoME"
        Me.lblSaldoME.Size = New System.Drawing.Size(29, 13)
        Me.lblSaldoME.TabIndex = 9
        Me.lblSaldoME.Text = "0.00"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblImporteNCme)
        Me.GroupBox1.Controls.Add(Me.lblImporteNCmn)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.GroupBox1.Location = New System.Drawing.Point(12, 92)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 74)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Importe nota crédito:"
        '
        'lblImporteNCme
        '
        Me.lblImporteNCme.AutoSize = True
        Me.lblImporteNCme.Location = New System.Drawing.Point(82, 52)
        Me.lblImporteNCme.Name = "lblImporteNCme"
        Me.lblImporteNCme.Size = New System.Drawing.Size(29, 13)
        Me.lblImporteNCme.TabIndex = 13
        Me.lblImporteNCme.Text = "0.00"
        '
        'lblImporteNCmn
        '
        Me.lblImporteNCmn.AutoSize = True
        Me.lblImporteNCmn.Location = New System.Drawing.Point(82, 26)
        Me.lblImporteNCmn.Name = "lblImporteNCmn"
        Me.lblImporteNCmn.Size = New System.Drawing.Size(29, 13)
        Me.lblImporteNCmn.TabIndex = 12
        Me.lblImporteNCmn.Text = "0.00"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(10, 52)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Importe me:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(10, 26)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Importe mn:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblImporteNBme)
        Me.GroupBox2.Controls.Add(Me.lblImporteNBmn)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.GroupBox2.Location = New System.Drawing.Point(12, 172)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(200, 74)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Importe nota débito:"
        '
        'lblImporteNBme
        '
        Me.lblImporteNBme.AutoSize = True
        Me.lblImporteNBme.Location = New System.Drawing.Point(82, 52)
        Me.lblImporteNBme.Name = "lblImporteNBme"
        Me.lblImporteNBme.Size = New System.Drawing.Size(29, 13)
        Me.lblImporteNBme.TabIndex = 13
        Me.lblImporteNBme.Text = "0.00"
        '
        'lblImporteNBmn
        '
        Me.lblImporteNBmn.AutoSize = True
        Me.lblImporteNBmn.Location = New System.Drawing.Point(82, 26)
        Me.lblImporteNBmn.Name = "lblImporteNBmn"
        Me.lblImporteNBmn.Size = New System.Drawing.Size(29, 13)
        Me.lblImporteNBmn.TabIndex = 12
        Me.lblImporteNBmn.Text = "0.00"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(10, 52)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(66, 13)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "Importe me:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(10, 26)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(66, 13)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "Importe mn:"
        '
        'ucSaldos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblSaldoME)
        Me.Controls.Add(Me.lblSaldoMN)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.pictureBox1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ucSaldos"
        Me.Size = New System.Drawing.Size(231, 268)
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents pictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblSaldoMN As System.Windows.Forms.Label
    Friend WithEvents lblSaldoME As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblImporteNCme As System.Windows.Forms.Label
    Friend WithEvents lblImporteNCmn As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblImporteNBme As System.Windows.Forms.Label
    Friend WithEvents lblImporteNBmn As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label

End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormVendedorCode
    Inherits Syncfusion.Windows.Forms.MetroForm

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormVendedorCode))
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextCodigoVendedor = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.ComboCaja = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbA4 = New System.Windows.Forms.RadioButton()
        Me.rbTicket = New System.Windows.Forms.RadioButton()
        Me.cboImpresoras = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.brnImprimir = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.bunifuDragControl1 = New Bunifu.Framework.UI.BunifuDragControl(Me.components)
        CType(Me.TextCodigoVendedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.cboImpresoras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(183, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 14)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Codigo de vendedor"
        '
        'TextCodigoVendedor
        '
        Me.TextCodigoVendedor.BackColor = System.Drawing.Color.White
        Me.TextCodigoVendedor.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TextCodigoVendedor.BorderColor = System.Drawing.Color.Silver
        Me.TextCodigoVendedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextCodigoVendedor.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextCodigoVendedor.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextCodigoVendedor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextCodigoVendedor.Location = New System.Drawing.Point(186, 27)
        Me.TextCodigoVendedor.MaxLength = 5
        Me.TextCodigoVendedor.Metrocolor = System.Drawing.Color.YellowGreen
        Me.TextCodigoVendedor.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextCodigoVendedor.Name = "TextCodigoVendedor"
        Me.TextCodigoVendedor.NearImage = CType(resources.GetObject("TextCodigoVendedor.NearImage"), System.Drawing.Image)
        Me.TextCodigoVendedor.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextCodigoVendedor.Size = New System.Drawing.Size(100, 20)
        Me.TextCodigoVendedor.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextCodigoVendedor.TabIndex = 17
        Me.TextCodigoVendedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ComboCaja
        '
        Me.ComboCaja.BackColor = System.Drawing.Color.White
        Me.ComboCaja.BeforeTouchSize = New System.Drawing.Size(226, 21)
        Me.ComboCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboCaja.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboCaja.Location = New System.Drawing.Point(186, 180)
        Me.ComboCaja.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ComboCaja.Name = "ComboCaja"
        Me.ComboCaja.Size = New System.Drawing.Size(226, 21)
        Me.ComboCaja.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboCaja.TabIndex = 223
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(183, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 14)
        Me.Label2.TabIndex = 222
        Me.Label2.Text = "Seleccionar una impresora"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbA4)
        Me.GroupBox1.Controls.Add(Me.rbTicket)
        Me.GroupBox1.Location = New System.Drawing.Point(186, 104)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(226, 68)
        Me.GroupBox1.TabIndex = 221
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
        Me.cboImpresoras.BackColor = System.Drawing.Color.White
        Me.cboImpresoras.BeforeTouchSize = New System.Drawing.Size(226, 21)
        Me.cboImpresoras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboImpresoras.Enabled = False
        Me.cboImpresoras.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboImpresoras.Location = New System.Drawing.Point(186, 76)
        Me.cboImpresoras.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.cboImpresoras.Name = "cboImpresoras"
        Me.cboImpresoras.Size = New System.Drawing.Size(226, 21)
        Me.cboImpresoras.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboImpresoras.TabIndex = 224
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(334, 214)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(78, 29)
        Me.Button1.TabIndex = 226
        Me.Button1.Text = "Cerrar"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'brnImprimir
        '
        Me.brnImprimir.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.brnImprimir.FlatAppearance.BorderSize = 0
        Me.brnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.brnImprimir.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.brnImprimir.ForeColor = System.Drawing.Color.White
        Me.brnImprimir.Location = New System.Drawing.Point(252, 214)
        Me.brnImprimir.Name = "brnImprimir"
        Me.brnImprimir.Size = New System.Drawing.Size(78, 29)
        Me.brnImprimir.TabIndex = 225
        Me.brnImprimir.Text = "Confirmar"
        Me.brnImprimir.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(175, 253)
        Me.Panel1.TabIndex = 227
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Bahnschrift Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(37, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 14)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Confirmar venta"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(834, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(22, 23)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "X"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(536, 141)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 17)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Estado"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(34, 73)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(107, 111)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'bunifuDragControl1
        '
        Me.bunifuDragControl1.Fixed = True
        Me.bunifuDragControl1.Horizontal = True
        Me.bunifuDragControl1.TargetControl = Nothing
        Me.bunifuDragControl1.Vertical = True
        '
        'FormVendedorCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.SystemColors.HotTrack
        CaptionLabel1.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.DimGray
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Text = "Confirmar venta"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(422, 253)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.brnImprimir)
        Me.Controls.Add(Me.cboImpresoras)
        Me.Controls.Add(Me.ComboCaja)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TextCodigoVendedor)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FormVendedorCode"
        Me.ShowIcon = False
        CType(Me.TextCodigoVendedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboCaja, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.cboImpresoras, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TextCodigoVendedor As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents ComboCaja As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rbA4 As RadioButton
    Friend WithEvents rbTicket As RadioButton
    Friend WithEvents cboImpresoras As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Button1 As Button
    Friend WithEvents brnImprimir As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label4 As Label
    Private WithEvents bunifuDragControl1 As Bunifu.Framework.UI.BunifuDragControl
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModalNotaCreditoGastos
    Inherits frmMaster

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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboMotivo = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.txtBaseDev = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtBaseMov = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.cboMotivo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBaseDev, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBaseMov, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel16.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.cboMotivo)
        Me.Panel1.Controls.Add(Me.txtBaseDev)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtBaseMov)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(476, 109)
        Me.Panel1.TabIndex = 408
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(19, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(180, 14)
        Me.Label5.TabIndex = 501
        Me.Label5.Text = "Movimiento : nota de crédito gastos"
        '
        'cboMotivo
        '
        Me.cboMotivo.BackColor = System.Drawing.Color.White
        Me.cboMotivo.BeforeTouchSize = New System.Drawing.Size(272, 21)
        Me.cboMotivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMotivo.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMotivo.Location = New System.Drawing.Point(22, 28)
        Me.cboMotivo.Name = "cboMotivo"
        Me.cboMotivo.Size = New System.Drawing.Size(272, 21)
        Me.cboMotivo.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboMotivo.TabIndex = 500
        '
        'txtBaseDev
        '
        Me.txtBaseDev.BackColor = System.Drawing.SystemColors.Info
        Me.txtBaseDev.BeforeTouchSize = New System.Drawing.Size(94, 22)
        Me.txtBaseDev.BorderColor = System.Drawing.Color.Chocolate
        Me.txtBaseDev.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBaseDev.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBaseDev.Font = New System.Drawing.Font("Ebrima", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBaseDev.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtBaseDev.Location = New System.Drawing.Point(311, 76)
        Me.txtBaseDev.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtBaseDev.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtBaseDev.Name = "txtBaseDev"
        Me.txtBaseDev.ReadOnly = True
        Me.txtBaseDev.Size = New System.Drawing.Size(114, 24)
        Me.txtBaseDev.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtBaseDev.TabIndex = 499
        Me.txtBaseDev.Tag = "07"
        Me.txtBaseDev.Text = "0.00"
        Me.txtBaseDev.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(311, 57)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 14)
        Me.Label4.TabIndex = 498
        Me.Label4.Text = "Importe dev. (s/IGV.)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(308, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 14)
        Me.Label3.TabIndex = 497
        Me.Label3.Text = "Base imp. (sin IGV.)"
        '
        'txtBaseMov
        '
        Me.txtBaseMov.BackGroundColor = System.Drawing.Color.White
        Me.txtBaseMov.BeforeTouchSize = New System.Drawing.Size(94, 22)
        Me.txtBaseMov.BorderColor = System.Drawing.Color.Silver
        Me.txtBaseMov.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBaseMov.CurrencyDecimalDigits = 4
        Me.txtBaseMov.CurrencySymbol = ""
        Me.txtBaseMov.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBaseMov.DecimalValue = New Decimal(New Integer() {0, 0, 0, 262144})
        Me.txtBaseMov.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtBaseMov.Location = New System.Drawing.Point(311, 27)
        Me.txtBaseMov.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtBaseMov.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtBaseMov.Name = "txtBaseMov"
        Me.txtBaseMov.NullString = ""
        Me.txtBaseMov.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtBaseMov.ReadOnlyBackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtBaseMov.Size = New System.Drawing.Size(114, 22)
        Me.txtBaseMov.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtBaseMov.TabIndex = 496
        Me.txtBaseMov.Text = "0.0000"
        Me.txtBaseMov.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel16
        '
        Me.Panel16.BackColor = System.Drawing.Color.White
        Me.Panel16.Controls.Add(Me.Button1)
        Me.Panel16.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel16.Location = New System.Drawing.Point(0, 110)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(476, 47)
        Me.Panel16.TabIndex = 407
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.OrangeRed
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(185, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(109, 36)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Aceptar"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'frmModalNotaCreditoGastos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.Color.White
        Me.CaptionBarHeight = 55
        Me.ClientSize = New System.Drawing.Size(476, 157)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel16)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmModalNotaCreditoGastos"
        Me.ShowIcon = False
        Me.Text = ""
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.cboMotivo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBaseDev, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBaseMov, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel16.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboMotivo As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents txtBaseDev As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtBaseMov As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Panel16 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class

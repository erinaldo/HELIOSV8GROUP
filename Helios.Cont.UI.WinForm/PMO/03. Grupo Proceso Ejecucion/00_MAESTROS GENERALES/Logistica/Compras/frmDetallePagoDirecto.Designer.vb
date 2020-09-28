<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDetallePagoDirecto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDetallePagoDirecto))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.pnEntidad = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.cboEntidad = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtCuentaCorriente = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.pnFecha = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFechaEmision = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtFechaCobro = New System.Windows.Forms.DateTimePicker()
        Me.cboTipoDocumento = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.pnEntidad.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboEntidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCuentaCorriente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnFecha.SuspendLayout()
        CType(Me.cboTipoDocumento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Controls.Add(Me.Button5)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(477, 154)
        Me.Panel1.TabIndex = 514
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.pnEntidad)
        Me.GroupBox3.Controls.Add(Me.pnFecha)
        Me.GroupBox3.Controls.Add(Me.cboTipoDocumento)
        Me.GroupBox3.Controls.Add(Me.Label33)
        Me.GroupBox3.Font = New System.Drawing.Font("Ebrima", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.GroupBox3.Location = New System.Drawing.Point(4, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(455, 99)
        Me.GroupBox3.TabIndex = 511
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "MEDIO PAGO"
        '
        'pnEntidad
        '
        Me.pnEntidad.BackColor = System.Drawing.Color.Transparent
        Me.pnEntidad.Controls.Add(Me.Label2)
        Me.pnEntidad.Controls.Add(Me.PictureBox2)
        Me.pnEntidad.Controls.Add(Me.cboEntidad)
        Me.pnEntidad.Controls.Add(Me.Label19)
        Me.pnEntidad.Controls.Add(Me.txtCuentaCorriente)
        Me.pnEntidad.Enabled = False
        Me.pnEntidad.Location = New System.Drawing.Point(25, 40)
        Me.pnEntidad.Name = "pnEntidad"
        Me.pnEntidad.Size = New System.Drawing.Size(424, 59)
        Me.pnEntidad.TabIndex = 469
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Ebrima", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(134, 15)
        Me.Label2.TabIndex = 430
        Me.Label2.Text = "ENTIDAD FINANCIERA:"
        '
        'PictureBox2
        '
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(378, 4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(21, 21)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 439
        Me.PictureBox2.TabStop = False
        '
        'cboEntidad
        '
        Me.cboEntidad.BackColor = System.Drawing.Color.White
        Me.cboEntidad.BeforeTouchSize = New System.Drawing.Size(219, 21)
        Me.cboEntidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEntidad.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEntidad.Location = New System.Drawing.Point(153, 4)
        Me.cboEntidad.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboEntidad.MetroColor = System.Drawing.Color.Silver
        Me.cboEntidad.Name = "cboEntidad"
        Me.cboEntidad.Size = New System.Drawing.Size(219, 21)
        Me.cboEntidad.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboEntidad.TabIndex = 436
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Ebrima", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(40, 35)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(102, 15)
        Me.Label19.TabIndex = 438
        Me.Label19.Text = "CTA. CORRIENTE:"
        '
        'txtCuentaCorriente
        '
        Me.txtCuentaCorriente.BackColor = System.Drawing.Color.White
        Me.txtCuentaCorriente.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtCuentaCorriente.BorderColor = System.Drawing.Color.Silver
        Me.txtCuentaCorriente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuentaCorriente.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCuentaCorriente.Font = New System.Drawing.Font("Ebrima", 9.0!, System.Drawing.FontStyle.Bold)
        Me.txtCuentaCorriente.Location = New System.Drawing.Point(153, 30)
        Me.txtCuentaCorriente.MaxLength = 20
        Me.txtCuentaCorriente.Metrocolor = System.Drawing.Color.Silver
        Me.txtCuentaCorriente.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtCuentaCorriente.Name = "txtCuentaCorriente"
        Me.txtCuentaCorriente.Size = New System.Drawing.Size(195, 23)
        Me.txtCuentaCorriente.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtCuentaCorriente.TabIndex = 437
        '
        'pnFecha
        '
        Me.pnFecha.Controls.Add(Me.Label3)
        Me.pnFecha.Controls.Add(Me.txtFechaEmision)
        Me.pnFecha.Controls.Add(Me.Label12)
        Me.pnFecha.Controls.Add(Me.txtFechaCobro)
        Me.pnFecha.Location = New System.Drawing.Point(25, 99)
        Me.pnFecha.Name = "pnFecha"
        Me.pnFecha.Size = New System.Drawing.Size(538, 55)
        Me.pnFecha.TabIndex = 470
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(36, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 12)
        Me.Label3.TabIndex = 442
        Me.Label3.Text = "FECHA EMISIÓN:"
        '
        'txtFechaEmision
        '
        Me.txtFechaEmision.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFechaEmision.Location = New System.Drawing.Point(131, 6)
        Me.txtFechaEmision.Name = "txtFechaEmision"
        Me.txtFechaEmision.Size = New System.Drawing.Size(195, 20)
        Me.txtFechaEmision.TabIndex = 466
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(12, 39)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(110, 12)
        Me.Label12.TabIndex = 440
        Me.Label12.Text = "COBRO A PARTIR DE:"
        '
        'txtFechaCobro
        '
        Me.txtFechaCobro.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFechaCobro.Location = New System.Drawing.Point(131, 32)
        Me.txtFechaCobro.Name = "txtFechaCobro"
        Me.txtFechaCobro.Size = New System.Drawing.Size(195, 20)
        Me.txtFechaCobro.TabIndex = 467
        '
        'cboTipoDocumento
        '
        Me.cboTipoDocumento.BackColor = System.Drawing.Color.White
        Me.cboTipoDocumento.BeforeTouchSize = New System.Drawing.Size(259, 21)
        Me.cboTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoDocumento.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoDocumento.Location = New System.Drawing.Point(178, 16)
        Me.cboTipoDocumento.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboTipoDocumento.MetroColor = System.Drawing.Color.Silver
        Me.cboTipoDocumento.Name = "cboTipoDocumento"
        Me.cboTipoDocumento.Size = New System.Drawing.Size(259, 21)
        Me.cboTipoDocumento.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboTipoDocumento.TabIndex = 212
        Me.cboTipoDocumento.TabStop = False
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Ebrima", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.Black
        Me.Label33.Location = New System.Drawing.Point(94, 22)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(73, 15)
        Me.Label33.TabIndex = 1
        Me.Label33.Text = "TIPO PAGO:"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(374, 111)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(78, 34)
        Me.Button4.TabIndex = 533
        Me.Button4.Text = "&Cerrar"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(286, 111)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(86, 34)
        Me.Button5.TabIndex = 532
        Me.Button5.Text = "&Aceptar"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'frmDetallePagoDirecto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(477, 154)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmDetallePagoDirecto"
        Me.ShowIcon = False
        Me.Text = ""
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.pnEntidad.ResumeLayout(False)
        Me.pnEntidad.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboEntidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCuentaCorriente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnFecha.ResumeLayout(False)
        Me.pnFecha.PerformLayout()
        CType(Me.cboTipoDocumento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents pnEntidad As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents cboEntidad As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtCuentaCorriente As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents pnFecha As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFechaEmision As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtFechaCobro As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboTipoDocumento As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
End Class

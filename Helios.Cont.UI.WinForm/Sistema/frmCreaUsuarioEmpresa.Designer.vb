<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCreaUsuarioEmpresa
    Inherits Helios.Cont.Presentation.WinForm.frmMaster

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
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCreaUsuarioEmpresa))
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.txtPass = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtAappat = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDNI = New System.Windows.Forms.MaskedTextBox()
        Me.txtNombres = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.btncancelar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.pnAdmin = New System.Windows.Forms.Panel()
        Me.rbAdmin = New System.Windows.Forms.RadioButton()
        Me.pnVendedor = New System.Windows.Forms.Panel()
        Me.rbUser = New System.Windows.Forms.RadioButton()
        Me.pnCajero = New System.Windows.Forms.Panel()
        Me.rbInvitado = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtApmat = New System.Windows.Forms.TextBox()
        Me.lblAlias = New System.Windows.Forms.Label()
        Me.txtAlias = New System.Windows.Forms.TextBox()
        Me.dtpFechaIniVigencia = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaFinVigencia = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.chkTrial = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.pnAdmin.SuspendLayout()
        Me.pnVendedor.SuspendLayout()
        Me.pnCajero.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtPass
        '
        Me.txtPass.Location = New System.Drawing.Point(179, 172)
        Me.txtPass.MaxLength = 11
        Me.txtPass.Name = "txtPass"
        Me.txtPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPass.Size = New System.Drawing.Size(204, 26)
        Me.txtPass.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(176, 146)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 19)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Contraseña:"
        '
        'txtAappat
        '
        Me.txtAappat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAappat.Location = New System.Drawing.Point(15, 95)
        Me.txtAappat.MaxLength = 60
        Me.txtAappat.Name = "txtAappat"
        Me.txtAappat.Size = New System.Drawing.Size(202, 26)
        Me.txtAappat.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(12, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 19)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Apellido paterno:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 19)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Nombres:"
        '
        'txtDNI
        '
        Me.txtDNI.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtDNI.Location = New System.Drawing.Point(442, 95)
        Me.txtDNI.Mask = "99999999"
        Me.txtDNI.Name = "txtDNI"
        Me.txtDNI.Size = New System.Drawing.Size(65, 26)
        Me.txtDNI.TabIndex = 3
        Me.txtDNI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtNombres
        '
        Me.txtNombres.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombres.Location = New System.Drawing.Point(15, 34)
        Me.txtNombres.MaxLength = 50
        Me.txtNombres.Name = "txtNombres"
        Me.txtNombres.Size = New System.Drawing.Size(260, 26)
        Me.txtNombres.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(439, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 19)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "DNI/LE:"
        '
        'btnGrabar
        '
        Me.btnGrabar.BackColor = System.Drawing.Color.FromArgb(CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGrabar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrabar.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.btnGrabar.Location = New System.Drawing.Point(420, 353)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(87, 31)
        Me.btnGrabar.TabIndex = 12
        Me.btnGrabar.Text = "Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = False
        '
        'btncancelar
        '
        Me.btncancelar.BackColor = System.Drawing.Color.FromArgb(CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.btncancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btncancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncancelar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncancelar.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.btncancelar.Location = New System.Drawing.Point(327, 353)
        Me.btncancelar.Name = "btncancelar"
        Me.btncancelar.Size = New System.Drawing.Size(87, 31)
        Me.btncancelar.TabIndex = 13
        Me.btncancelar.Text = "Cancelar"
        Me.btncancelar.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.pnAdmin)
        Me.GroupBox1.Controls.Add(Me.pnVendedor)
        Me.GroupBox1.Controls.Add(Me.pnCajero)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 284)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(492, 63)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Nivel"
        '
        'pnAdmin
        '
        Me.pnAdmin.Controls.Add(Me.rbAdmin)
        Me.pnAdmin.Location = New System.Drawing.Point(5, 22)
        Me.pnAdmin.Name = "pnAdmin"
        Me.pnAdmin.Size = New System.Drawing.Size(104, 35)
        Me.pnAdmin.TabIndex = 14
        Me.pnAdmin.Visible = False
        '
        'rbAdmin
        '
        Me.rbAdmin.AutoSize = True
        Me.rbAdmin.Location = New System.Drawing.Point(13, 3)
        Me.rbAdmin.Name = "rbAdmin"
        Me.rbAdmin.Size = New System.Drawing.Size(70, 23)
        Me.rbAdmin.TabIndex = 9
        Me.rbAdmin.TabStop = True
        Me.rbAdmin.Text = "Admin"
        Me.rbAdmin.UseVisualStyleBackColor = True
        '
        'pnVendedor
        '
        Me.pnVendedor.Controls.Add(Me.rbUser)
        Me.pnVendedor.Location = New System.Drawing.Point(117, 22)
        Me.pnVendedor.Name = "pnVendedor"
        Me.pnVendedor.Size = New System.Drawing.Size(116, 35)
        Me.pnVendedor.TabIndex = 13
        Me.pnVendedor.Visible = False
        '
        'rbUser
        '
        Me.rbUser.AutoSize = True
        Me.rbUser.Location = New System.Drawing.Point(13, 3)
        Me.rbUser.Name = "rbUser"
        Me.rbUser.Size = New System.Drawing.Size(90, 23)
        Me.rbUser.TabIndex = 11
        Me.rbUser.Text = "Vendedor"
        Me.rbUser.UseVisualStyleBackColor = True
        '
        'pnCajero
        '
        Me.pnCajero.Controls.Add(Me.rbInvitado)
        Me.pnCajero.Location = New System.Drawing.Point(242, 22)
        Me.pnCajero.Name = "pnCajero"
        Me.pnCajero.Size = New System.Drawing.Size(104, 35)
        Me.pnCajero.TabIndex = 12
        Me.pnCajero.Visible = False
        '
        'rbInvitado
        '
        Me.rbInvitado.AutoSize = True
        Me.rbInvitado.Checked = True
        Me.rbInvitado.Location = New System.Drawing.Point(12, 3)
        Me.rbInvitado.Name = "rbInvitado"
        Me.rbInvitado.Size = New System.Drawing.Size(69, 23)
        Me.rbInvitado.TabIndex = 10
        Me.rbInvitado.TabStop = True
        Me.rbInvitado.Text = "Cajero"
        Me.rbInvitado.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(220, 68)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(118, 19)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Apellido Materno:"
        '
        'txtApmat
        '
        Me.txtApmat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtApmat.Location = New System.Drawing.Point(223, 95)
        Me.txtApmat.MaxLength = 60
        Me.txtApmat.Name = "txtApmat"
        Me.txtApmat.Size = New System.Drawing.Size(213, 26)
        Me.txtApmat.TabIndex = 2
        '
        'lblAlias
        '
        Me.lblAlias.AutoSize = True
        Me.lblAlias.BackColor = System.Drawing.Color.Transparent
        Me.lblAlias.Location = New System.Drawing.Point(12, 146)
        Me.lblAlias.Name = "lblAlias"
        Me.lblAlias.Size = New System.Drawing.Size(40, 19)
        Me.lblAlias.TabIndex = 22
        Me.lblAlias.Text = "Alias:"
        '
        'txtAlias
        '
        Me.txtAlias.Location = New System.Drawing.Point(15, 172)
        Me.txtAlias.MaxLength = 20
        Me.txtAlias.Name = "txtAlias"
        Me.txtAlias.Size = New System.Drawing.Size(158, 26)
        Me.txtAlias.TabIndex = 4
        '
        'dtpFechaIniVigencia
        '
        Me.dtpFechaIniVigencia.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaIniVigencia.Location = New System.Drawing.Point(98, 229)
        Me.dtpFechaIniVigencia.Name = "dtpFechaIniVigencia"
        Me.dtpFechaIniVigencia.Size = New System.Drawing.Size(97, 26)
        Me.dtpFechaIniVigencia.TabIndex = 7
        Me.dtpFechaIniVigencia.Visible = False
        '
        'dtpFechaFinVigencia
        '
        Me.dtpFechaFinVigencia.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFinVigencia.Location = New System.Drawing.Point(201, 229)
        Me.dtpFechaFinVigencia.Name = "dtpFechaFinVigencia"
        Me.dtpFechaFinVigencia.Size = New System.Drawing.Size(96, 26)
        Me.dtpFechaFinVigencia.TabIndex = 8
        Me.dtpFechaFinVigencia.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(12, 216)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 19)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "Vigencia:"
        Me.Label6.Visible = False
        '
        'chkTrial
        '
        Me.chkTrial.AutoSize = True
        Me.chkTrial.BackColor = System.Drawing.Color.Transparent
        Me.chkTrial.Location = New System.Drawing.Point(15, 234)
        Me.chkTrial.Name = "chkTrial"
        Me.chkTrial.Size = New System.Drawing.Size(74, 23)
        Me.chkTrial.TabIndex = 6
        Me.chkTrial.Text = "Prueba"
        Me.chkTrial.UseVisualStyleBackColor = False
        Me.chkTrial.Visible = False
        '
        'frmCreaUsuarioEmpresa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer))
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(2, 4)
        CaptionImage1.Name = "CaptionImage1"
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.White
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(330, 24)
        CaptionLabel1.Text = "Usuarios: Ingreso Interactivo:"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(511, 392)
        Me.Controls.Add(Me.chkTrial)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dtpFechaFinVigencia)
        Me.Controls.Add(Me.dtpFechaIniVigencia)
        Me.Controls.Add(Me.lblAlias)
        Me.Controls.Add(Me.txtAlias)
        Me.Controls.Add(Me.txtApmat)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.btncancelar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtPass)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtAappat)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtDNI)
        Me.Controls.Add(Me.txtNombres)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCreaUsuarioEmpresa"
        Me.ShowIcon = False
        Me.Text = ""
        Me.GroupBox1.ResumeLayout(False)
        Me.pnAdmin.ResumeLayout(False)
        Me.pnAdmin.PerformLayout()
        Me.pnVendedor.ResumeLayout(False)
        Me.pnVendedor.PerformLayout()
        Me.pnCajero.ResumeLayout(False)
        Me.pnCajero.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPass As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtAappat As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDNI As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtNombres As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents btncancelar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbInvitado As System.Windows.Forms.RadioButton
    Friend WithEvents rbAdmin As System.Windows.Forms.RadioButton
    Friend WithEvents rbUser As System.Windows.Forms.RadioButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtApmat As System.Windows.Forms.TextBox
    Friend WithEvents lblAlias As System.Windows.Forms.Label
    Friend WithEvents txtAlias As System.Windows.Forms.TextBox
    Friend WithEvents dtpFechaIniVigencia As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaFinVigencia As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkTrial As System.Windows.Forms.CheckBox
    Friend WithEvents pnAdmin As System.Windows.Forms.Panel
    Friend WithEvents pnVendedor As System.Windows.Forms.Panel
    Friend WithEvents pnCajero As System.Windows.Forms.Panel
End Class

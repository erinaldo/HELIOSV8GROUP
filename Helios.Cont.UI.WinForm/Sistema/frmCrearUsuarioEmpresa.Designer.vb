<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCrearUsuarioEmpresa
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
        Me.components = New System.ComponentModel.Container()
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCrearUsuarioEmpresa))
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.btOperacion = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv2 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.chkTrial = New System.Windows.Forms.CheckBox()
        Me.dtpFechaFinVigencia = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaIniVigencia = New System.Windows.Forms.DateTimePicker()
        Me.txtAlias = New System.Windows.Forms.TextBox()
        Me.txtApmat = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbCajeroVentaDirecta = New System.Windows.Forms.RadioButton()
        Me.rbCajeroCentral = New System.Windows.Forms.RadioButton()
        Me.txtPass = New System.Windows.Forms.TextBox()
        Me.txtAappat = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDNI = New System.Windows.Forms.MaskedTextBox()
        Me.txtNombres = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GradientPanel2)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.GradientPanel1)
        Me.Panel1.Controls.Add(Me.chkTrial)
        Me.Panel1.Controls.Add(Me.dtpFechaFinVigencia)
        Me.Panel1.Controls.Add(Me.dtpFechaIniVigencia)
        Me.Panel1.Controls.Add(Me.txtAlias)
        Me.Panel1.Controls.Add(Me.txtApmat)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.txtPass)
        Me.Panel1.Controls.Add(Me.txtAappat)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtDNI)
        Me.Panel1.Controls.Add(Me.txtNombres)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(456, 319)
        Me.Panel1.TabIndex = 0
        '
        'GradientPanel2
        '
        Me.GradientPanel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GradientPanel2.BorderColor = System.Drawing.Color.LightGray
        Me.GradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel2.Controls.Add(Me.btOperacion)
        Me.GradientPanel2.Controls.Add(Me.ButtonAdv2)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel2.EnableTouchMode = True
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 258)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(456, 61)
        Me.GradientPanel2.TabIndex = 52
        '
        'btOperacion
        '
        Me.btOperacion.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btOperacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.btOperacion.BeforeTouchSize = New System.Drawing.Size(100, 32)
        Me.btOperacion.EnableTouchMode = True
        Me.btOperacion.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btOperacion.ForeColor = System.Drawing.Color.White
        Me.btOperacion.IsBackStageButton = False
        Me.btOperacion.Location = New System.Drawing.Point(123, 17)
        Me.btOperacion.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btOperacion.Name = "btOperacion"
        Me.btOperacion.Size = New System.Drawing.Size(150, 48)
        Me.btOperacion.TabIndex = 8
        Me.btOperacion.Text = "Grabar"
        Me.btOperacion.UseVisualStyle = True
        '
        'ButtonAdv2
        '
        Me.ButtonAdv2.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv2.BackColor = System.Drawing.Color.Gray
        Me.ButtonAdv2.BeforeTouchSize = New System.Drawing.Size(100, 32)
        Me.ButtonAdv2.EnableTouchMode = True
        Me.ButtonAdv2.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.ButtonAdv2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAdv2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv2.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv2.IsBackStageButton = False
        Me.ButtonAdv2.Location = New System.Drawing.Point(238, 16)
        Me.ButtonAdv2.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonAdv2.Name = "ButtonAdv2"
        Me.ButtonAdv2.Size = New System.Drawing.Size(150, 48)
        Me.ButtonAdv2.TabIndex = 9
        Me.ButtonAdv2.Text = "Cancel"
        Me.ButtonAdv2.UseVisualStyle = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(20, 304)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 12)
        Me.Label6.TabIndex = 51
        Me.Label6.Text = "VIGENCIA"
        Me.Label6.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(198, 137)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 12)
        Me.Label4.TabIndex = 50
        Me.Label4.Text = "CONTRASEÑA"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(20, 137)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 12)
        Me.Label5.TabIndex = 49
        Me.Label5.Text = "ALIAS"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(386, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "DNI/LE."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(198, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 12)
        Me.Label3.TabIndex = 47
        Me.Label3.Text = "APELLIDO MATERNO"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(20, 79)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(105, 12)
        Me.Label7.TabIndex = 46
        Me.Label7.Text = "APELLIDO PATERNO"
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.GradientPanel1.BorderSides = System.Windows.Forms.Border3DSide.Top
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel1.EnableTouchMode = True
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(456, 10)
        Me.GradientPanel1.TabIndex = 45
        '
        'chkTrial
        '
        Me.chkTrial.AutoSize = True
        Me.chkTrial.BackColor = System.Drawing.Color.Transparent
        Me.chkTrial.Location = New System.Drawing.Point(26, 325)
        Me.chkTrial.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chkTrial.Name = "chkTrial"
        Me.chkTrial.Size = New System.Drawing.Size(62, 17)
        Me.chkTrial.TabIndex = 32
        Me.chkTrial.Text = "Prueba"
        Me.chkTrial.UseVisualStyleBackColor = False
        Me.chkTrial.Visible = False
        '
        'dtpFechaFinVigencia
        '
        Me.dtpFechaFinVigencia.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFinVigencia.Location = New System.Drawing.Point(185, 321)
        Me.dtpFechaFinVigencia.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtpFechaFinVigencia.Name = "dtpFechaFinVigencia"
        Me.dtpFechaFinVigencia.Size = New System.Drawing.Size(83, 22)
        Me.dtpFechaFinVigencia.TabIndex = 35
        Me.dtpFechaFinVigencia.Visible = False
        '
        'dtpFechaIniVigencia
        '
        Me.dtpFechaIniVigencia.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaIniVigencia.Location = New System.Drawing.Point(97, 321)
        Me.dtpFechaIniVigencia.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtpFechaIniVigencia.Name = "dtpFechaIniVigencia"
        Me.dtpFechaIniVigencia.Size = New System.Drawing.Size(84, 22)
        Me.dtpFechaIniVigencia.TabIndex = 33
        Me.dtpFechaIniVigencia.Visible = False
        '
        'txtAlias
        '
        Me.txtAlias.Location = New System.Drawing.Point(22, 158)
        Me.txtAlias.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtAlias.MaxLength = 20
        Me.txtAlias.Name = "txtAlias"
        Me.txtAlias.Size = New System.Drawing.Size(174, 22)
        Me.txtAlias.TabIndex = 30
        '
        'txtApmat
        '
        Me.txtApmat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtApmat.Location = New System.Drawing.Point(200, 101)
        Me.txtApmat.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtApmat.MaxLength = 60
        Me.txtApmat.Name = "txtApmat"
        Me.txtApmat.Size = New System.Drawing.Size(183, 22)
        Me.txtApmat.TabIndex = 28
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.rbCajeroVentaDirecta)
        Me.GroupBox1.Controls.Add(Me.rbCajeroCentral)
        Me.GroupBox1.Location = New System.Drawing.Point(22, 195)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(422, 57)
        Me.GroupBox1.TabIndex = 41
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Nivel"
        Me.GroupBox1.Visible = False
        '
        'rbCajeroVentaDirecta
        '
        Me.rbCajeroVentaDirecta.AutoSize = True
        Me.rbCajeroVentaDirecta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rbCajeroVentaDirecta.Location = New System.Drawing.Point(218, 24)
        Me.rbCajeroVentaDirecta.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.rbCajeroVentaDirecta.Name = "rbCajeroVentaDirecta"
        Me.rbCajeroVentaDirecta.Size = New System.Drawing.Size(135, 17)
        Me.rbCajeroVentaDirecta.TabIndex = 10
        Me.rbCajeroVentaDirecta.Text = "Cajero (Venta Directa)"
        Me.rbCajeroVentaDirecta.UseVisualStyleBackColor = True
        '
        'rbCajeroCentral
        '
        Me.rbCajeroCentral.AutoSize = True
        Me.rbCajeroCentral.Checked = True
        Me.rbCajeroCentral.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rbCajeroCentral.Location = New System.Drawing.Point(28, 24)
        Me.rbCajeroCentral.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.rbCajeroCentral.Name = "rbCajeroCentral"
        Me.rbCajeroCentral.Size = New System.Drawing.Size(154, 17)
        Me.rbCajeroCentral.TabIndex = 9
        Me.rbCajeroCentral.TabStop = True
        Me.rbCajeroCentral.Text = "Cajero (Caja centralizada)"
        Me.rbCajeroCentral.UseVisualStyleBackColor = True
        '
        'txtPass
        '
        Me.txtPass.Location = New System.Drawing.Point(200, 158)
        Me.txtPass.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtPass.MaxLength = 11
        Me.txtPass.Name = "txtPass"
        Me.txtPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPass.Size = New System.Drawing.Size(175, 22)
        Me.txtPass.TabIndex = 31
        '
        'txtAappat
        '
        Me.txtAappat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAappat.Location = New System.Drawing.Point(22, 101)
        Me.txtAappat.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtAappat.MaxLength = 60
        Me.txtAappat.Name = "txtAappat"
        Me.txtAappat.Size = New System.Drawing.Size(174, 22)
        Me.txtAappat.TabIndex = 27
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(20, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 12)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "NOMBRES"
        '
        'txtDNI
        '
        Me.txtDNI.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtDNI.Location = New System.Drawing.Point(388, 101)
        Me.txtDNI.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtDNI.Mask = "99999999"
        Me.txtDNI.Name = "txtDNI"
        Me.txtDNI.Size = New System.Drawing.Size(56, 22)
        Me.txtDNI.TabIndex = 29
        Me.txtDNI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtNombres
        '
        Me.txtNombres.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombres.Location = New System.Drawing.Point(22, 46)
        Me.txtNombres.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtNombres.MaxLength = 50
        Me.txtNombres.Name = "txtNombres"
        Me.txtNombres.Size = New System.Drawing.Size(223, 22)
        Me.txtNombres.TabIndex = 26
        '
        'frmCrearUsuarioEmpresa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.Color.White
        Me.CaptionBarHeight = 50
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(15, 9)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(30, 30)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.SystemColors.HotTrack
        CaptionLabel1.Location = New System.Drawing.Point(50, 9)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(330, 24)
        CaptionLabel1.Text = "Usuarios de caja"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(456, 319)
        Me.Controls.Add(Me.Panel1)
        Me.EnableTouchMode = True
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "frmCrearUsuarioEmpresa"
        Me.ShowIcon = False
        Me.ShowMaximizeBox = False
        Me.ShowMinimizeBox = False
        Me.Text = ""
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents chkTrial As System.Windows.Forms.CheckBox
    Friend WithEvents dtpFechaFinVigencia As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaIniVigencia As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtAlias As System.Windows.Forms.TextBox
    Friend WithEvents txtApmat As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbCajeroCentral As System.Windows.Forms.RadioButton
    Friend WithEvents rbCajeroVentaDirecta As System.Windows.Forms.RadioButton
    Friend WithEvents txtPass As System.Windows.Forms.TextBox
    Friend WithEvents txtAappat As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDNI As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtNombres As System.Windows.Forms.TextBox
    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ButtonAdv2 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents btOperacion As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents GradientPanel2 As Syncfusion.Windows.Forms.Tools.GradientPanel
End Class

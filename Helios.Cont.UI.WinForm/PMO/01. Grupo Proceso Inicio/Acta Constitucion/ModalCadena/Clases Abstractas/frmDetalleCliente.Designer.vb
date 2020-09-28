<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDetalleCliente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDetalleCliente))
        Me.tipEntidad = New System.Windows.Forms.ToolTip(Me.components)
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.miniToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.GuardarToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ImprimirToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.lsvCorreos = New System.Windows.Forms.ListView()
        Me.colCodigo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colIdEntidad = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTipoCorreo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colEmail = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.COLEstado = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtMail2 = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.rbHotmail = New System.Windows.Forms.RadioButton()
        Me.rbGmail = New System.Windows.Forms.RadioButton()
        Me.rbYahoo = New System.Windows.Forms.RadioButton()
        Me.rbOut = New System.Windows.Forms.RadioButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.lblEstado = New System.Windows.Forms.ToolStripButton()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCodDocumento = New System.Windows.Forms.TextBox()
        Me.cboDocumento = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNumDoc = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDir = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtFono = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtcelular = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtnextel = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtMail = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtCodigoCliente = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtSiglas = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboTipoPersona = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblrazon = New System.Windows.Forms.Label()
        Me.txtRazon = New System.Windows.Forms.TextBox()
        Me.lblappat = New System.Windows.Forms.Label()
        Me.txtAppat = New System.Windows.Forms.TextBox()
        Me.txtApmat = New System.Windows.Forms.TextBox()
        Me.lblapmat = New System.Windows.Forms.Label()
        Me.txtNombre1 = New System.Windows.Forms.TextBox()
        Me.lblnom1 = New System.Windows.Forms.Label()
        Me.txtNombre2 = New System.Windows.Forms.TextBox()
        Me.lblnom2 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.chActivo = New System.Windows.Forms.CheckBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtCuenta = New System.Windows.Forms.TextBox()
        Me.cboCuenta = New Helios.Cont.Presentation.WinForm.MultiColumnComboBox()
        Me.rb42 = New System.Windows.Forms.RadioButton()
        Me.rb43 = New System.Windows.Forms.RadioButton()
        Me.rbAll = New System.Windows.Forms.RadioButton()
        Me.lnkAgregar = New System.Windows.Forms.LinkLabel()
        Me.TabClientes = New System.Windows.Forms.TabControl()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.GuardarToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.AyudaToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabClientes.SuspendLayout()
        Me.ToolStrip3.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.ToolStrip1)
        Me.TabPage2.Controls.Add(Me.GroupBox4)
        Me.TabPage2.Controls.Add(Me.txtMail2)
        Me.TabPage2.Controls.Add(Me.Label17)
        Me.TabPage2.Controls.Add(Me.lsvCorreos)
        Me.TabPage2.Controls.Add(Me.ToolStrip3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(470, 339)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Correos"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'miniToolStrip
        '
        Me.miniToolStrip.AutoSize = False
        Me.miniToolStrip.BackgroundImage = CType(resources.GetObject("miniToolStrip.BackgroundImage"), System.Drawing.Image)
        Me.miniToolStrip.CanOverflow = False
        Me.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None
        Me.miniToolStrip.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.miniToolStrip.Location = New System.Drawing.Point(302, 3)
        Me.miniToolStrip.Name = "miniToolStrip"
        Me.miniToolStrip.Size = New System.Drawing.Size(464, 25)
        Me.miniToolStrip.TabIndex = 41
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Font = New System.Drawing.Font("Segoe UI", 7.0!)
        Me.ToolStripLabel2.ForeColor = System.Drawing.Color.White
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(167, 22)
        Me.ToolStripLabel2.Text = "AGREGAR CORREOS DE LA ENTIDAD"
        '
        'toolStripSeparator2
        '
        Me.toolStripSeparator2.Name = "toolStripSeparator2"
        Me.toolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'GuardarToolStripButton1
        '
        Me.GuardarToolStripButton1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GuardarToolStripButton1.Image = CType(resources.GetObject("GuardarToolStripButton1.Image"), System.Drawing.Image)
        Me.GuardarToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.GuardarToolStripButton1.Name = "GuardarToolStripButton1"
        Me.GuardarToolStripButton1.Size = New System.Drawing.Size(69, 22)
        Me.GuardarToolStripButton1.Text = "Agregar"
        '
        'ImprimirToolStripButton1
        '
        Me.ImprimirToolStripButton1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ImprimirToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ImprimirToolStripButton1.Name = "ImprimirToolStripButton1"
        Me.ImprimirToolStripButton1.Size = New System.Drawing.Size(54, 22)
        Me.ImprimirToolStripButton1.Text = "&Eliminar"
        '
        'lsvCorreos
        '
        Me.lsvCorreos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colCodigo, Me.colIdEntidad, Me.colTipoCorreo, Me.colEmail, Me.COLEstado})
        Me.lsvCorreos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lsvCorreos.FullRowSelect = True
        Me.lsvCorreos.Location = New System.Drawing.Point(3, 45)
        Me.lsvCorreos.Name = "lsvCorreos"
        Me.lsvCorreos.Size = New System.Drawing.Size(464, 291)
        Me.lsvCorreos.TabIndex = 42
        Me.lsvCorreos.UseCompatibleStateImageBehavior = False
        Me.lsvCorreos.View = System.Windows.Forms.View.Details
        '
        'colCodigo
        '
        Me.colCodigo.Text = "ID"
        Me.colCodigo.Width = 0
        '
        'colIdEntidad
        '
        Me.colIdEntidad.Text = "IdEntidad"
        Me.colIdEntidad.Width = 0
        '
        'colTipoCorreo
        '
        Me.colTipoCorreo.Text = "Cuenta"
        Me.colTipoCorreo.Width = 118
        '
        'colEmail
        '
        Me.colEmail.Text = "E-mail"
        Me.colEmail.Width = 345
        '
        'COLEstado
        '
        Me.COLEstado.Text = "Estado"
        Me.COLEstado.Width = 0
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(14, 128)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(41, 13)
        Me.Label17.TabIndex = 43
        Me.Label17.Text = "E-mail:"
        '
        'txtMail2
        '
        Me.txtMail2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtMail2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMail2.Location = New System.Drawing.Point(57, 123)
        Me.txtMail2.Name = "txtMail2"
        Me.txtMail2.Size = New System.Drawing.Size(284, 22)
        Me.txtMail2.TabIndex = 44
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rbOut)
        Me.GroupBox4.Controls.Add(Me.rbYahoo)
        Me.GroupBox4.Controls.Add(Me.rbGmail)
        Me.GroupBox4.Controls.Add(Me.rbHotmail)
        Me.GroupBox4.Location = New System.Drawing.Point(15, 64)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(416, 51)
        Me.GroupBox4.TabIndex = 45
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Tipo"
        '
        'rbHotmail
        '
        Me.rbHotmail.AutoSize = True
        Me.rbHotmail.Checked = True
        Me.rbHotmail.Location = New System.Drawing.Point(48, 21)
        Me.rbHotmail.Name = "rbHotmail"
        Me.rbHotmail.Size = New System.Drawing.Size(65, 17)
        Me.rbHotmail.TabIndex = 0
        Me.rbHotmail.TabStop = True
        Me.rbHotmail.Text = "Hotmail"
        Me.rbHotmail.UseVisualStyleBackColor = True
        '
        'rbGmail
        '
        Me.rbGmail.AutoSize = True
        Me.rbGmail.Location = New System.Drawing.Point(143, 21)
        Me.rbGmail.Name = "rbGmail"
        Me.rbGmail.Size = New System.Drawing.Size(54, 17)
        Me.rbGmail.TabIndex = 1
        Me.rbGmail.Text = "Gmail"
        Me.rbGmail.UseVisualStyleBackColor = True
        '
        'rbYahoo
        '
        Me.rbYahoo.AutoSize = True
        Me.rbYahoo.Location = New System.Drawing.Point(235, 21)
        Me.rbYahoo.Name = "rbYahoo"
        Me.rbYahoo.Size = New System.Drawing.Size(56, 17)
        Me.rbYahoo.TabIndex = 2
        Me.rbYahoo.Text = "Yahoo"
        Me.rbYahoo.UseVisualStyleBackColor = True
        '
        'rbOut
        '
        Me.rbOut.AutoSize = True
        Me.rbOut.Enabled = False
        Me.rbOut.Location = New System.Drawing.Point(310, 21)
        Me.rbOut.Name = "rbOut"
        Me.rbOut.Size = New System.Drawing.Size(68, 17)
        Me.rbOut.TabIndex = 3
        Me.rbOut.Text = "Outlook"
        Me.rbOut.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblEstado})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 28)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(464, 25)
        Me.ToolStrip1.TabIndex = 46
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'lblEstado
        '
        Me.lblEstado.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblEstado.ForeColor = System.Drawing.Color.DarkGreen
        Me.lblEstado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblEstado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(120, 22)
        Me.lblEstado.Text = "Estado: nuevo correo"
        '
        'TabPage1
        '
        Me.TabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TabPage1.Controls.Add(Me.lnkAgregar)
        Me.TabPage1.Controls.Add(Me.rbAll)
        Me.TabPage1.Controls.Add(Me.rb43)
        Me.TabPage1.Controls.Add(Me.rb42)
        Me.TabPage1.Controls.Add(Me.cboCuenta)
        Me.TabPage1.Controls.Add(Me.txtCuenta)
        Me.TabPage1.Controls.Add(Me.txtSiglas)
        Me.TabPage1.Controls.Add(Me.txtCodigoCliente)
        Me.TabPage1.Controls.Add(Me.txtMail)
        Me.TabPage1.Controls.Add(Me.txtnextel)
        Me.TabPage1.Controls.Add(Me.txtcelular)
        Me.TabPage1.Controls.Add(Me.txtFono)
        Me.TabPage1.Controls.Add(Me.txtDir)
        Me.TabPage1.Controls.Add(Me.txtNumDoc)
        Me.TabPage1.Controls.Add(Me.txtCodDocumento)
        Me.TabPage1.Controls.Add(Me.Label16)
        Me.TabPage1.Controls.Add(Me.chActivo)
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.cboTipoPersona)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.cboDocumento)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(470, 339)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Datos"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Maroon
        Me.Label3.Location = New System.Drawing.Point(10, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 13)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "*"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(37, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Tipo Documento:"
        '
        'txtCodDocumento
        '
        Me.txtCodDocumento.Enabled = False
        Me.txtCodDocumento.Location = New System.Drawing.Point(401, 38)
        Me.txtCodDocumento.Name = "txtCodDocumento"
        Me.txtCodDocumento.Size = New System.Drawing.Size(44, 22)
        Me.txtCodDocumento.TabIndex = 7
        '
        'cboDocumento
        '
        Me.cboDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDocumento.DropDownWidth = 250
        Me.cboDocumento.FormattingEnabled = True
        Me.cboDocumento.Items.AddRange(New Object() {"1", "2"})
        Me.cboDocumento.Location = New System.Drawing.Point(135, 39)
        Me.cboDocumento.Name = "cboDocumento"
        Me.cboDocumento.Size = New System.Drawing.Size(264, 21)
        Me.cboDocumento.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(17, 92)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(114, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Número Documento:"
        '
        'txtNumDoc
        '
        Me.txtNumDoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumDoc.Location = New System.Drawing.Point(136, 89)
        Me.txtNumDoc.MaxLength = 20
        Me.txtNumDoc.Name = "txtNumDoc"
        Me.txtNumDoc.Size = New System.Drawing.Size(263, 22)
        Me.txtNumDoc.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(72, 221)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Dirección:"
        '
        'txtDir
        '
        Me.txtDir.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDir.Location = New System.Drawing.Point(135, 218)
        Me.txtDir.Multiline = True
        Me.txtDir.Name = "txtDir"
        Me.txtDir.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDir.Size = New System.Drawing.Size(314, 33)
        Me.txtDir.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(73, 258)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Teléfono:"
        '
        'txtFono
        '
        Me.txtFono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFono.Location = New System.Drawing.Point(135, 254)
        Me.txtFono.MaxLength = 20
        Me.txtFono.Name = "txtFono"
        Me.txtFono.Size = New System.Drawing.Size(232, 22)
        Me.txtFono.TabIndex = 14
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(82, 283)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Celular:"
        '
        'txtcelular
        '
        Me.txtcelular.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcelular.Location = New System.Drawing.Point(135, 278)
        Me.txtcelular.MaxLength = 20
        Me.txtcelular.Name = "txtcelular"
        Me.txtcelular.Size = New System.Drawing.Size(232, 22)
        Me.txtcelular.TabIndex = 16
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(84, 307)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 13)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Nextel:"
        '
        'txtnextel
        '
        Me.txtnextel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnextel.Location = New System.Drawing.Point(135, 302)
        Me.txtnextel.MaxLength = 20
        Me.txtnextel.Name = "txtnextel"
        Me.txtnextel.Size = New System.Drawing.Size(232, 22)
        Me.txtnextel.TabIndex = 18
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(91, 282)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(37, 13)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "Email:"
        Me.Label11.Visible = False
        '
        'txtMail
        '
        Me.txtMail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMail.Location = New System.Drawing.Point(135, 326)
        Me.txtMail.MaxLength = 200
        Me.txtMail.Multiline = True
        Me.txtMail.Name = "txtMail"
        Me.txtMail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMail.Size = New System.Drawing.Size(314, 33)
        Me.txtMail.TabIndex = 22
        Me.txtMail.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Beige
        Me.Label12.Location = New System.Drawing.Point(339, 14)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(22, 13)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "ID:"
        '
        'txtCodigoCliente
        '
        Me.txtCodigoCliente.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoCliente.Location = New System.Drawing.Point(362, 8)
        Me.txtCodigoCliente.Name = "txtCodigoCliente"
        Me.txtCodigoCliente.Size = New System.Drawing.Size(93, 21)
        Me.txtCodigoCliente.TabIndex = 26
        Me.txtCodigoCliente.Text = "00000000"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Label10.ForeColor = System.Drawing.Color.Beige
        Me.Label10.Location = New System.Drawing.Point(242, 13)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(44, 13)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "Código:"
        '
        'txtSiglas
        '
        Me.txtSiglas.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSiglas.ForeColor = System.Drawing.Color.YellowGreen
        Me.txtSiglas.Location = New System.Drawing.Point(283, 8)
        Me.txtSiglas.MaxLength = 0
        Me.txtSiglas.Name = "txtSiglas"
        Me.txtSiglas.Size = New System.Drawing.Size(50, 21)
        Me.txtSiglas.TabIndex = 28
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(56, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Tipo Persona:"
        '
        'cboTipoPersona
        '
        Me.cboTipoPersona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoPersona.FormattingEnabled = True
        Me.cboTipoPersona.Items.AddRange(New Object() {"01 NATURAL", "02 JURIDICO"})
        Me.cboTipoPersona.Location = New System.Drawing.Point(135, 64)
        Me.cboTipoPersona.Name = "cboTipoPersona"
        Me.cboTipoPersona.Size = New System.Drawing.Size(167, 21)
        Me.cboTipoPersona.TabIndex = 30
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.lblnom2)
        Me.GroupBox1.Controls.Add(Me.txtNombre2)
        Me.GroupBox1.Controls.Add(Me.lblnom1)
        Me.GroupBox1.Controls.Add(Me.txtNombre1)
        Me.GroupBox1.Controls.Add(Me.lblapmat)
        Me.GroupBox1.Controls.Add(Me.txtApmat)
        Me.GroupBox1.Controls.Add(Me.txtAppat)
        Me.GroupBox1.Controls.Add(Me.lblappat)
        Me.GroupBox1.Controls.Add(Me.txtRazon)
        Me.GroupBox1.Controls.Add(Me.lblrazon)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 117)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(441, 96)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Nombre Entidad."
        '
        'lblrazon
        '
        Me.lblrazon.AutoSize = True
        Me.lblrazon.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblrazon.Location = New System.Drawing.Point(1, 46)
        Me.lblrazon.Name = "lblrazon"
        Me.lblrazon.Size = New System.Drawing.Size(120, 13)
        Me.lblrazon.TabIndex = 0
        Me.lblrazon.Text = "Nombre/Razón Social:"
        Me.lblrazon.Visible = False
        '
        'txtRazon
        '
        Me.txtRazon.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRazon.Location = New System.Drawing.Point(122, 41)
        Me.txtRazon.MaxLength = 150
        Me.txtRazon.Name = "txtRazon"
        Me.txtRazon.Size = New System.Drawing.Size(314, 22)
        Me.txtRazon.TabIndex = 1
        Me.txtRazon.Visible = False
        '
        'lblappat
        '
        Me.lblappat.AutoSize = True
        Me.lblappat.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblappat.Location = New System.Drawing.Point(104, 14)
        Me.lblappat.Name = "lblappat"
        Me.lblappat.Size = New System.Drawing.Size(93, 13)
        Me.lblappat.TabIndex = 32
        Me.lblappat.Text = "Apellido Paterno"
        '
        'txtAppat
        '
        Me.txtAppat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAppat.Location = New System.Drawing.Point(102, 31)
        Me.txtAppat.Name = "txtAppat"
        Me.txtAppat.Size = New System.Drawing.Size(161, 22)
        Me.txtAppat.TabIndex = 31
        '
        'txtApmat
        '
        Me.txtApmat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtApmat.Location = New System.Drawing.Point(275, 31)
        Me.txtApmat.Name = "txtApmat"
        Me.txtApmat.Size = New System.Drawing.Size(161, 22)
        Me.txtApmat.TabIndex = 33
        '
        'lblapmat
        '
        Me.lblapmat.AutoSize = True
        Me.lblapmat.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblapmat.Location = New System.Drawing.Point(272, 14)
        Me.lblapmat.Name = "lblapmat"
        Me.lblapmat.Size = New System.Drawing.Size(97, 13)
        Me.lblapmat.TabIndex = 34
        Me.lblapmat.Text = "Apellido Materno"
        '
        'txtNombre1
        '
        Me.txtNombre1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre1.Location = New System.Drawing.Point(102, 68)
        Me.txtNombre1.Name = "txtNombre1"
        Me.txtNombre1.Size = New System.Drawing.Size(161, 22)
        Me.txtNombre1.TabIndex = 35
        '
        'lblnom1
        '
        Me.lblnom1.AutoSize = True
        Me.lblnom1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblnom1.Location = New System.Drawing.Point(104, 54)
        Me.lblnom1.Name = "lblnom1"
        Me.lblnom1.Size = New System.Drawing.Size(61, 13)
        Me.lblnom1.TabIndex = 36
        Me.lblnom1.Text = "1° Nombre"
        '
        'txtNombre2
        '
        Me.txtNombre2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre2.Location = New System.Drawing.Point(275, 68)
        Me.txtNombre2.Name = "txtNombre2"
        Me.txtNombre2.Size = New System.Drawing.Size(161, 22)
        Me.txtNombre2.TabIndex = 37
        '
        'lblnom2
        '
        Me.lblnom2.AutoSize = True
        Me.lblnom2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblnom2.Location = New System.Drawing.Point(277, 54)
        Me.lblnom2.Name = "lblnom2"
        Me.lblnom2.Size = New System.Drawing.Size(61, 13)
        Me.lblnom2.TabIndex = 38
        Me.lblnom2.Text = "2° Nombre"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.Maroon
        Me.Label15.Location = New System.Drawing.Point(8, 18)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(12, 13)
        Me.Label15.TabIndex = 39
        Me.Label15.Text = "*"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(46, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(12, 13)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "*"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.Maroon
        Me.Label13.Location = New System.Drawing.Point(27, 44)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(12, 13)
        Me.Label13.TabIndex = 33
        Me.Label13.Text = "*"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.Maroon
        Me.Label14.Location = New System.Drawing.Point(54, 221)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(12, 13)
        Me.Label14.TabIndex = 34
        Me.Label14.Text = "*"
        '
        'chActivo
        '
        Me.chActivo.AutoSize = True
        Me.chActivo.Checked = True
        Me.chActivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chActivo.Location = New System.Drawing.Point(394, 439)
        Me.chActivo.Name = "chActivo"
        Me.chActivo.Size = New System.Drawing.Size(57, 17)
        Me.chActivo.TabIndex = 23
        Me.chActivo.Text = "Activo"
        Me.chActivo.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(43, 392)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(88, 13)
        Me.Label16.TabIndex = 36
        Me.Label16.Text = "Asignar cuenta:"
        '
        'txtCuenta
        '
        Me.txtCuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCuenta.Location = New System.Drawing.Point(190, 388)
        Me.txtCuenta.MaxLength = 20
        Me.txtCuenta.Multiline = True
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.ReadOnly = True
        Me.txtCuenta.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtCuenta.Size = New System.Drawing.Size(259, 47)
        Me.txtCuenta.TabIndex = 37
        Me.txtCuenta.TabStop = False
        '
        'cboCuenta
        '
        Me.cboCuenta.AutoComplete = True
        Me.cboCuenta.AutoDropdown = False
        Me.cboCuenta.BackColor = System.Drawing.Color.Yellow
        Me.cboCuenta.BackColorEven = System.Drawing.Color.White
        Me.cboCuenta.BackColorOdd = System.Drawing.Color.White
        Me.cboCuenta.ColumnNames = ""
        Me.cboCuenta.ColumnWidthDefault = 75
        Me.cboCuenta.ColumnWidths = "50;150"
        Me.cboCuenta.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cboCuenta.DropDownWidth = 200
        Me.cboCuenta.FormattingEnabled = True
        Me.cboCuenta.LinkedColumnIndex = 1
        Me.cboCuenta.LinkedTextBox = Me.txtCuenta
        Me.cboCuenta.Location = New System.Drawing.Point(136, 388)
        Me.cboCuenta.Name = "cboCuenta"
        Me.cboCuenta.Size = New System.Drawing.Size(53, 23)
        Me.cboCuenta.TabIndex = 85
        '
        'rb42
        '
        Me.rb42.AutoSize = True
        Me.rb42.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb42.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rb42.Location = New System.Drawing.Point(136, 365)
        Me.rb42.Name = "rb42"
        Me.rb42.Size = New System.Drawing.Size(37, 17)
        Me.rb42.TabIndex = 86
        Me.rb42.Tag = "42"
        Me.rb42.Text = "42"
        Me.rb42.UseVisualStyleBackColor = True
        '
        'rb43
        '
        Me.rb43.AutoSize = True
        Me.rb43.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rb43.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rb43.Location = New System.Drawing.Point(179, 365)
        Me.rb43.Name = "rb43"
        Me.rb43.Size = New System.Drawing.Size(37, 17)
        Me.rb43.TabIndex = 87
        Me.rb43.Tag = "43"
        Me.rb43.Text = "43"
        Me.rb43.UseVisualStyleBackColor = True
        '
        'rbAll
        '
        Me.rbAll.AutoSize = True
        Me.rbAll.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbAll.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rbAll.Location = New System.Drawing.Point(222, 365)
        Me.rbAll.Name = "rbAll"
        Me.rbAll.Size = New System.Drawing.Size(39, 17)
        Me.rbAll.TabIndex = 88
        Me.rbAll.Tag = "All"
        Me.rbAll.Text = "All"
        Me.rbAll.UseVisualStyleBackColor = True
        '
        'lnkAgregar
        '
        Me.lnkAgregar.AutoSize = True
        Me.lnkAgregar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lnkAgregar.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lnkAgregar.Location = New System.Drawing.Point(272, 367)
        Me.lnkAgregar.Name = "lnkAgregar"
        Me.lnkAgregar.Size = New System.Drawing.Size(88, 13)
        Me.lnkAgregar.TabIndex = 89
        Me.lnkAgregar.TabStop = True
        Me.lnkAgregar.Text = "Agregar Cuenta"
        '
        'TabClientes
        '
        Me.TabClientes.Controls.Add(Me.TabPage1)
        Me.TabClientes.Controls.Add(Me.TabPage2)
        Me.TabClientes.Location = New System.Drawing.Point(0, 144)
        Me.TabClientes.Name = "TabClientes"
        Me.TabClientes.SelectedIndex = 0
        Me.TabClientes.Size = New System.Drawing.Size(478, 365)
        Me.TabClientes.TabIndex = 5
        '
        'ToolStrip3
        '
        Me.ToolStrip3.BackgroundImage = CType(resources.GetObject("ToolStrip3.BackgroundImage"), System.Drawing.Image)
        Me.ToolStrip3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel2, Me.toolStripSeparator2, Me.GuardarToolStripButton1, Me.ImprimirToolStripButton1})
        Me.ToolStrip3.Location = New System.Drawing.Point(3, 3)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.Size = New System.Drawing.Size(464, 25)
        Me.ToolStrip3.TabIndex = 41
        Me.ToolStrip3.Text = "ToolStrip3"
        '
        'GuardarToolStripButton
        '
        Me.GuardarToolStripButton.Image = CType(resources.GetObject("GuardarToolStripButton.Image"), System.Drawing.Image)
        Me.GuardarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.GuardarToolStripButton.Name = "GuardarToolStripButton"
        Me.GuardarToolStripButton.Size = New System.Drawing.Size(62, 22)
        Me.GuardarToolStripButton.Text = "&Grabar"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'AyudaToolStripButton
        '
        Me.AyudaToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.AyudaToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.AyudaToolStripButton.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.door_open_out
        Me.AyudaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AyudaToolStripButton.Name = "AyudaToolStripButton"
        Me.AyudaToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.AyudaToolStripButton.Text = "Salir"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.BackgroundImage = CType(resources.GetObject("ToolStrip2.BackgroundImage"), System.Drawing.Image)
        Me.ToolStrip2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GuardarToolStripButton, Me.toolStripSeparator, Me.AyudaToolStripButton})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(478, 25)
        Me.ToolStrip2.TabIndex = 6
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'frmDetalleCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(478, 509)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabClientes)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmDetalleCliente"
        Me.Text = "Entidades"
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabClientes.ResumeLayout(False)
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tipEntidad As System.Windows.Forms.ToolTip
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents lblEstado As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents rbOut As System.Windows.Forms.RadioButton
    Friend WithEvents rbYahoo As System.Windows.Forms.RadioButton
    Friend WithEvents rbGmail As System.Windows.Forms.RadioButton
    Friend WithEvents rbHotmail As System.Windows.Forms.RadioButton
    Friend WithEvents txtMail2 As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lsvCorreos As System.Windows.Forms.ListView
    Friend WithEvents colCodigo As System.Windows.Forms.ColumnHeader
    Friend WithEvents colIdEntidad As System.Windows.Forms.ColumnHeader
    Friend WithEvents colTipoCorreo As System.Windows.Forms.ColumnHeader
    Friend WithEvents colEmail As System.Windows.Forms.ColumnHeader
    Friend WithEvents COLEstado As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GuardarToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ImprimirToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents miniToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents lnkAgregar As System.Windows.Forms.LinkLabel
    Friend WithEvents rbAll As System.Windows.Forms.RadioButton
    Friend WithEvents rb43 As System.Windows.Forms.RadioButton
    Friend WithEvents rb42 As System.Windows.Forms.RadioButton
    Friend WithEvents cboCuenta As Helios.Cont.Presentation.WinForm.MultiColumnComboBox
    Friend WithEvents txtCuenta As System.Windows.Forms.TextBox
    Friend WithEvents txtSiglas As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtMail As System.Windows.Forms.TextBox
    Friend WithEvents txtnextel As System.Windows.Forms.TextBox
    Friend WithEvents txtcelular As System.Windows.Forms.TextBox
    Friend WithEvents txtFono As System.Windows.Forms.TextBox
    Friend WithEvents txtDir As System.Windows.Forms.TextBox
    Friend WithEvents txtNumDoc As System.Windows.Forms.TextBox
    Friend WithEvents txtCodDocumento As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents chActivo As System.Windows.Forms.CheckBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblnom2 As System.Windows.Forms.Label
    Friend WithEvents txtNombre2 As System.Windows.Forms.TextBox
    Friend WithEvents lblnom1 As System.Windows.Forms.Label
    Friend WithEvents txtNombre1 As System.Windows.Forms.TextBox
    Friend WithEvents lblapmat As System.Windows.Forms.Label
    Friend WithEvents txtApmat As System.Windows.Forms.TextBox
    Friend WithEvents txtAppat As System.Windows.Forms.TextBox
    Friend WithEvents lblappat As System.Windows.Forms.Label
    Friend WithEvents txtRazon As System.Windows.Forms.TextBox
    Friend WithEvents lblrazon As System.Windows.Forms.Label
    Friend WithEvents cboTipoPersona As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboDocumento As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TabClientes As System.Windows.Forms.TabControl
    Friend WithEvents GuardarToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AyudaToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
End Class

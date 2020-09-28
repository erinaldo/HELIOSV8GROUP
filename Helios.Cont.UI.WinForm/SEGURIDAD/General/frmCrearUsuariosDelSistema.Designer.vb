<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCrearUsuariosDelSistema
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCrearUsuariosDelSistema))
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Dim CaptionLabel2 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPaterno = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtMaterno = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtNombres = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDni = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtPass = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtAlias = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboSeguridad = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.txtEmail = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GradientPanel7 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv6 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.txtNombreProducto = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCodigoAsig = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboCargos = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblidPermiso = New System.Windows.Forms.Label()
        CType(Me.txtPaterno, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMaterno, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNombres, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDni, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPass, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAlias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboSeguridad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEmail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel7.SuspendLayout()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNombreProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodigoAsig, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCargos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(42, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombres"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(42, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 14)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Apellido Paterno"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(251, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 14)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Apellido Materno"
        '
        'txtPaterno
        '
        Me.txtPaterno.BackColor = System.Drawing.Color.White
        Me.txtPaterno.BeforeTouchSize = New System.Drawing.Size(199, 20)
        Me.txtPaterno.BorderColor = System.Drawing.Color.Silver
        Me.txtPaterno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPaterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPaterno.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPaterno.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPaterno.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtPaterno.Location = New System.Drawing.Point(45, 50)
        Me.txtPaterno.MaxLength = 50
        Me.txtPaterno.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtPaterno.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtPaterno.Name = "txtPaterno"
        Me.txtPaterno.Size = New System.Drawing.Size(201, 20)
        Me.txtPaterno.TabIndex = 0
        '
        'txtMaterno
        '
        Me.txtMaterno.BackColor = System.Drawing.Color.White
        Me.txtMaterno.BeforeTouchSize = New System.Drawing.Size(199, 20)
        Me.txtMaterno.BorderColor = System.Drawing.Color.Silver
        Me.txtMaterno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMaterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMaterno.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMaterno.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMaterno.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtMaterno.Location = New System.Drawing.Point(254, 50)
        Me.txtMaterno.MaxLength = 50
        Me.txtMaterno.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtMaterno.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtMaterno.Name = "txtMaterno"
        Me.txtMaterno.Size = New System.Drawing.Size(201, 20)
        Me.txtMaterno.TabIndex = 1
        '
        'txtNombres
        '
        Me.txtNombres.BackColor = System.Drawing.Color.White
        Me.txtNombres.BeforeTouchSize = New System.Drawing.Size(199, 20)
        Me.txtNombres.BorderColor = System.Drawing.Color.Silver
        Me.txtNombres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNombres.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombres.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNombres.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombres.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtNombres.Location = New System.Drawing.Point(45, 98)
        Me.txtNombres.MaxLength = 50
        Me.txtNombres.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtNombres.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtNombres.Name = "txtNombres"
        Me.txtNombres.Size = New System.Drawing.Size(201, 20)
        Me.txtNombres.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(251, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 14)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Nro. DNI."
        '
        'txtDni
        '
        Me.txtDni.BackColor = System.Drawing.Color.White
        Me.txtDni.BeforeTouchSize = New System.Drawing.Size(199, 20)
        Me.txtDni.BorderColor = System.Drawing.Color.Silver
        Me.txtDni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDni.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDni.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDni.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDni.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtDni.Location = New System.Drawing.Point(252, 98)
        Me.txtDni.MaxLength = 8
        Me.txtDni.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtDni.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtDni.Name = "txtDni"
        Me.txtDni.Size = New System.Drawing.Size(201, 20)
        Me.txtDni.TabIndex = 3
        '
        'txtPass
        '
        Me.txtPass.BackColor = System.Drawing.Color.White
        Me.txtPass.BeforeTouchSize = New System.Drawing.Size(199, 20)
        Me.txtPass.BorderColor = System.Drawing.Color.YellowGreen
        Me.txtPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPass.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPass.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPass.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtPass.Location = New System.Drawing.Point(252, 148)
        Me.txtPass.MaxLength = 11
        Me.txtPass.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtPass.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPass.Size = New System.Drawing.Size(201, 20)
        Me.txtPass.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtPass.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(251, 130)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 14)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Contraseña"
        '
        'txtAlias
        '
        Me.txtAlias.BackColor = System.Drawing.Color.White
        Me.txtAlias.BeforeTouchSize = New System.Drawing.Size(199, 20)
        Me.txtAlias.BorderColor = System.Drawing.Color.YellowGreen
        Me.txtAlias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAlias.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAlias.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAlias.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAlias.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtAlias.Location = New System.Drawing.Point(45, 148)
        Me.txtAlias.MaxLength = 10
        Me.txtAlias.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtAlias.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtAlias.Name = "txtAlias"
        Me.txtAlias.Size = New System.Drawing.Size(201, 20)
        Me.txtAlias.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtAlias.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(42, 130)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(101, 14)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Nombre de Usuario"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(42, 406)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 14)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Permisos de usuario"
        Me.Label7.Visible = False
        '
        'cboSeguridad
        '
        Me.cboSeguridad.BackColor = System.Drawing.Color.White
        Me.cboSeguridad.BeforeTouchSize = New System.Drawing.Size(201, 21)
        Me.cboSeguridad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSeguridad.FlatBorderColor = System.Drawing.Color.OrangeRed
        Me.cboSeguridad.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSeguridad.Items.AddRange(New Object() {"ATENCION (PRE VENTA)", "CAJA CENTRALIZADA", "CAJA VENTA DIRECTA", "ADMINISTRADOR POS"})
        Me.cboSeguridad.Location = New System.Drawing.Point(45, 426)
        Me.cboSeguridad.MetroBorderColor = System.Drawing.Color.YellowGreen
        Me.cboSeguridad.MetroColor = System.Drawing.Color.YellowGreen
        Me.cboSeguridad.Name = "cboSeguridad"
        Me.cboSeguridad.Size = New System.Drawing.Size(201, 21)
        Me.cboSeguridad.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboSeguridad.TabIndex = 6
        Me.cboSeguridad.Text = "ATENCION (PRE VENTA)"
        Me.cboSeguridad.Visible = False
        '
        'txtEmail
        '
        Me.txtEmail.BackColor = System.Drawing.Color.White
        Me.txtEmail.BeforeTouchSize = New System.Drawing.Size(199, 20)
        Me.txtEmail.BorderColor = System.Drawing.Color.YellowGreen
        Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtEmail.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtEmail.Location = New System.Drawing.Point(43, 200)
        Me.txtEmail.MaxLength = 80
        Me.txtEmail.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtEmail.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(410, 20)
        Me.txtEmail.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtEmail.TabIndex = 6
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(42, 180)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 14)
        Me.Label8.TabIndex = 216
        Me.Label8.Text = "E-mail"
        '
        'GradientPanel7
        '
        Me.GradientPanel7.BorderColor = System.Drawing.Color.OrangeRed
        Me.GradientPanel7.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GradientPanel7.Controls.Add(Me.ButtonAdv6)
        Me.GradientPanel7.Location = New System.Drawing.Point(235, 285)
        Me.GradientPanel7.Name = "GradientPanel7"
        Me.GradientPanel7.Size = New System.Drawing.Size(108, 41)
        Me.GradientPanel7.TabIndex = 499
        '
        'ButtonAdv6
        '
        Me.ButtonAdv6.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv6.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(107, Byte), Integer))
        Me.ButtonAdv6.BeforeTouchSize = New System.Drawing.Size(108, 41)
        Me.ButtonAdv6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAdv6.Font = New System.Drawing.Font("Ebrima", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv6.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv6.Image = CType(resources.GetObject("ButtonAdv6.Image"), System.Drawing.Image)
        Me.ButtonAdv6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv6.IsBackStageButton = False
        Me.ButtonAdv6.Location = New System.Drawing.Point(0, 0)
        Me.ButtonAdv6.MetroColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(107, Byte), Integer))
        Me.ButtonAdv6.Name = "ButtonAdv6"
        Me.ButtonAdv6.Size = New System.Drawing.Size(108, 41)
        Me.ButtonAdv6.TabIndex = 9
        Me.ButtonAdv6.Text = "     Grabar"
        Me.ButtonAdv6.UseVisualStyle = True
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BorderColor = System.Drawing.Color.Silver
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.ButtonAdv1)
        Me.GradientPanel1.Location = New System.Drawing.Point(351, 285)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(105, 41)
        Me.GradientPanel1.TabIndex = 500
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.White
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(103, 39)
        Me.ButtonAdv1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonAdv1.Font = New System.Drawing.Font("Ebrima", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonAdv1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(0, 0)
        Me.ButtonAdv1.MetroColor = System.Drawing.Color.White
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(103, 39)
        Me.ButtonAdv1.TabIndex = 0
        Me.ButtonAdv1.Text = "Cancelar"
        Me.ButtonAdv1.UseVisualStyle = True
        '
        'GradientPanel2
        '
        Me.GradientPanel2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(107, Byte), Integer))
        Me.GradientPanel2.BorderSides = System.Windows.Forms.Border3DSide.Top
        Me.GradientPanel2.BorderSingle = System.Windows.Forms.ButtonBorderStyle.Dotted
        Me.GradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel2.EnableTouchMode = True
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(496, 10)
        Me.GradientPanel2.TabIndex = 501
        '
        'txtNombreProducto
        '
        Me.txtNombreProducto.BackColor = System.Drawing.Color.White
        Me.txtNombreProducto.BeforeTouchSize = New System.Drawing.Size(199, 20)
        Me.txtNombreProducto.BorderColor = System.Drawing.Color.YellowGreen
        Me.txtNombreProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNombreProducto.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNombreProducto.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreProducto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtNombreProducto.Location = New System.Drawing.Point(44, 296)
        Me.txtNombreProducto.MaxLength = 80
        Me.txtNombreProducto.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtNombreProducto.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtNombreProducto.Name = "txtNombreProducto"
        Me.txtNombreProducto.ReadOnly = True
        Me.txtNombreProducto.Size = New System.Drawing.Size(160, 20)
        Me.txtNombreProducto.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtNombreProducto.TabIndex = 8
        Me.txtNombreProducto.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(43, 276)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 14)
        Me.Label9.TabIndex = 503
        Me.Label9.Text = "Producto"
        Me.Label9.Visible = False
        '
        'txtCodigoAsig
        '
        Me.txtCodigoAsig.BackColor = System.Drawing.Color.White
        Me.txtCodigoAsig.BeforeTouchSize = New System.Drawing.Size(199, 20)
        Me.txtCodigoAsig.BorderColor = System.Drawing.Color.YellowGreen
        Me.txtCodigoAsig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigoAsig.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCodigoAsig.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoAsig.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtCodigoAsig.Location = New System.Drawing.Point(257, 247)
        Me.txtCodigoAsig.MaxLength = 80
        Me.txtCodigoAsig.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtCodigoAsig.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtCodigoAsig.Name = "txtCodigoAsig"
        Me.txtCodigoAsig.Size = New System.Drawing.Size(199, 20)
        Me.txtCodigoAsig.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtCodigoAsig.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(254, 227)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(176, 14)
        Me.Label10.TabIndex = 505
        Me.Label10.Text = "Código de identificación (Opcional)"
        '
        'cboCargos
        '
        Me.cboCargos.BackColor = System.Drawing.Color.White
        Me.cboCargos.BeforeTouchSize = New System.Drawing.Size(201, 21)
        Me.cboCargos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCargos.FlatBorderColor = System.Drawing.Color.OrangeRed
        Me.cboCargos.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCargos.Location = New System.Drawing.Point(43, 246)
        Me.cboCargos.MetroBorderColor = System.Drawing.Color.YellowGreen
        Me.cboCargos.MetroColor = System.Drawing.Color.YellowGreen
        Me.cboCargos.Name = "cboCargos"
        Me.cboCargos.Size = New System.Drawing.Size(201, 21)
        Me.cboCargos.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboCargos.TabIndex = 506
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(40, 226)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(112, 14)
        Me.Label11.TabIndex = 507
        Me.Label11.Text = "Cargo Organizacional"
        '
        'lblidPermiso
        '
        Me.lblidPermiso.AutoSize = True
        Me.lblidPermiso.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblidPermiso.Location = New System.Drawing.Point(40, 329)
        Me.lblidPermiso.Name = "lblidPermiso"
        Me.lblidPermiso.Size = New System.Drawing.Size(13, 14)
        Me.lblidPermiso.TabIndex = 508
        Me.lblidPermiso.Text = "0"
        Me.lblidPermiso.Visible = False
        '
        'frmCrearUsuariosDelSistema
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.Color.White
        Me.CaptionBarHeight = 55
        CaptionLabel1.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.Gray
        CaptionLabel1.Location = New System.Drawing.Point(55, 8)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(200, 24)
        CaptionLabel1.Text = "Usuarios del Sistema"
        CaptionLabel2.Font = New System.Drawing.Font("Corbel", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel2.ForeColor = System.Drawing.Color.MediumSeaGreen
        CaptionLabel2.Location = New System.Drawing.Point(55, 22)
        CaptionLabel2.Name = "CaptionLabel2"
        CaptionLabel2.Size = New System.Drawing.Size(200, 24)
        CaptionLabel2.Text = "Seguridad"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.CaptionLabels.Add(CaptionLabel2)
        Me.ClientSize = New System.Drawing.Size(496, 352)
        Me.Controls.Add(Me.lblidPermiso)
        Me.Controls.Add(Me.cboCargos)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtCodigoAsig)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtNombreProducto)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.GradientPanel2)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.GradientPanel7)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cboSeguridad)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtPass)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtAlias)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtDni)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtNombres)
        Me.Controls.Add(Me.txtMaterno)
        Me.Controls.Add(Me.txtPaterno)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCrearUsuariosDelSistema"
        Me.ShowIcon = False
        Me.Text = ""
        CType(Me.txtPaterno, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMaterno, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNombres, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDni, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPass, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAlias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboSeguridad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEmail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel7.ResumeLayout(False)
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNombreProducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodigoAsig, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCargos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPaterno As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtMaterno As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtNombres As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDni As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtPass As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtAlias As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboSeguridad As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents txtEmail As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GradientPanel7 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents ButtonAdv6 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents GradientPanel2 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents txtNombreProducto As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label9 As Label
    Friend WithEvents txtCodigoAsig As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label10 As Label
    Friend WithEvents cboCargos As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label11 As Label
    Friend WithEvents lblidPermiso As Label
End Class

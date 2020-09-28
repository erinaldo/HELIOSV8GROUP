<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCrearVehiculo
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
        Dim BannerTextInfo1 As Syncfusion.Windows.Forms.BannerTextInfo = New Syncfusion.Windows.Forms.BannerTextInfo()
        Dim BannerTextInfo2 As Syncfusion.Windows.Forms.BannerTextInfo = New Syncfusion.Windows.Forms.BannerTextInfo()
        Dim BannerTextInfo3 As Syncfusion.Windows.Forms.BannerTextInfo = New Syncfusion.Windows.Forms.BannerTextInfo()
        Dim BannerTextInfo4 As Syncfusion.Windows.Forms.BannerTextInfo = New Syncfusion.Windows.Forms.BannerTextInfo()
        Dim BannerTextInfo5 As Syncfusion.Windows.Forms.BannerTextInfo = New Syncfusion.Windows.Forms.BannerTextInfo()
        Me.BannerTextProvider1 = New Syncfusion.Windows.Forms.BannerTextProvider(Me.components)
        Me.TextCliente = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextMatricula = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextColor = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextOdometro = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextAnio = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ComboMarca = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboModelo = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboMotor = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ComboTransmision = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ComboTipoVehiculo = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ComboCombustible = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ComboSistemaCombustion = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ComboDireccion = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.RoundButton22 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.RoundButton21 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        CType(Me.TextCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextMatricula, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextColor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextOdometro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextAnio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboMarca, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboModelo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboMotor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboTransmision, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboTipoVehiculo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboCombustible, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboSistemaCombustion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextCliente
        '
        Me.TextCliente.BackColor = System.Drawing.Color.WhiteSmoke
        BannerTextInfo1.Text = "BUSCAR CLIENTE . . . ."
        BannerTextInfo1.Visible = True
        Me.BannerTextProvider1.SetBannerText(Me.TextCliente, BannerTextInfo1)
        Me.TextCliente.BeforeTouchSize = New System.Drawing.Size(444, 24)
        Me.TextCliente.BorderColor = System.Drawing.SystemColors.MenuHighlight
        Me.TextCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextCliente.CornerRadius = 4
        Me.TextCliente.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextCliente.Enabled = False
        Me.TextCliente.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextCliente.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextCliente.Location = New System.Drawing.Point(46, 44)
        Me.TextCliente.Metrocolor = System.Drawing.SystemColors.MenuHighlight
        Me.TextCliente.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextCliente.Name = "TextCliente"
        Me.TextCliente.Size = New System.Drawing.Size(444, 24)
        Me.TextCliente.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextCliente.TabIndex = 515
        '
        'TextMatricula
        '
        Me.TextMatricula.BackColor = System.Drawing.Color.WhiteSmoke
        BannerTextInfo2.Text = "MATRICULA"
        BannerTextInfo2.Visible = True
        Me.BannerTextProvider1.SetBannerText(Me.TextMatricula, BannerTextInfo2)
        Me.TextMatricula.BeforeTouchSize = New System.Drawing.Size(444, 24)
        Me.TextMatricula.BorderColor = System.Drawing.Color.Silver
        Me.TextMatricula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextMatricula.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextMatricula.CornerRadius = 4
        Me.TextMatricula.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextMatricula.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextMatricula.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextMatricula.Location = New System.Drawing.Point(46, 94)
        Me.TextMatricula.Metrocolor = System.Drawing.Color.Silver
        Me.TextMatricula.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextMatricula.Name = "TextMatricula"
        Me.TextMatricula.Size = New System.Drawing.Size(200, 24)
        Me.TextMatricula.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextMatricula.TabIndex = 516
        '
        'TextColor
        '
        Me.TextColor.BackColor = System.Drawing.Color.WhiteSmoke
        BannerTextInfo3.Text = "COLOR"
        BannerTextInfo3.Visible = True
        Me.BannerTextProvider1.SetBannerText(Me.TextColor, BannerTextInfo3)
        Me.TextColor.BeforeTouchSize = New System.Drawing.Size(444, 24)
        Me.TextColor.BorderColor = System.Drawing.Color.Silver
        Me.TextColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextColor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextColor.CornerRadius = 4
        Me.TextColor.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextColor.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextColor.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextColor.Location = New System.Drawing.Point(46, 260)
        Me.TextColor.Metrocolor = System.Drawing.Color.Silver
        Me.TextColor.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextColor.Name = "TextColor"
        Me.TextColor.Size = New System.Drawing.Size(143, 24)
        Me.TextColor.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextColor.TabIndex = 532
        '
        'TextOdometro
        '
        Me.TextOdometro.BackColor = System.Drawing.Color.WhiteSmoke
        BannerTextInfo4.Text = "ODOMETRO KM ..."
        BannerTextInfo4.Visible = True
        Me.BannerTextProvider1.SetBannerText(Me.TextOdometro, BannerTextInfo4)
        Me.TextOdometro.BeforeTouchSize = New System.Drawing.Size(444, 24)
        Me.TextOdometro.BorderColor = System.Drawing.Color.Silver
        Me.TextOdometro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextOdometro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextOdometro.CornerRadius = 4
        Me.TextOdometro.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextOdometro.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextOdometro.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextOdometro.Location = New System.Drawing.Point(195, 260)
        Me.TextOdometro.Metrocolor = System.Drawing.Color.Silver
        Me.TextOdometro.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextOdometro.Name = "TextOdometro"
        Me.TextOdometro.Size = New System.Drawing.Size(144, 24)
        Me.TextOdometro.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextOdometro.TabIndex = 533
        '
        'TextAnio
        '
        Me.TextAnio.BackColor = System.Drawing.Color.WhiteSmoke
        BannerTextInfo5.Text = "YYYY ...."
        BannerTextInfo5.Visible = True
        Me.BannerTextProvider1.SetBannerText(Me.TextAnio, BannerTextInfo5)
        Me.TextAnio.BeforeTouchSize = New System.Drawing.Size(444, 24)
        Me.TextAnio.BorderColor = System.Drawing.Color.Silver
        Me.TextAnio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextAnio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextAnio.CornerRadius = 4
        Me.TextAnio.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextAnio.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextAnio.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextAnio.Location = New System.Drawing.Point(46, 171)
        Me.TextAnio.MaxLength = 4
        Me.TextAnio.Metrocolor = System.Drawing.Color.Silver
        Me.TextAnio.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextAnio.Name = "TextAnio"
        Me.TextAnio.Size = New System.Drawing.Size(144, 24)
        Me.TextAnio.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextAnio.TabIndex = 546
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft JhengHei UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label6.Location = New System.Drawing.Point(42, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(120, 20)
        Me.Label6.TabIndex = 509
        Me.Label6.Text = "Crear Vehículo"
        '
        'ComboMarca
        '
        Me.ComboMarca.BackColor = System.Drawing.Color.White
        Me.ComboMarca.BeforeTouchSize = New System.Drawing.Size(238, 24)
        Me.ComboMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboMarca.Enabled = False
        Me.ComboMarca.Font = New System.Drawing.Font("Tahoma", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboMarca.Location = New System.Drawing.Point(252, 94)
        Me.ComboMarca.MetroBorderColor = System.Drawing.Color.Silver
        Me.ComboMarca.Name = "ComboMarca"
        Me.ComboMarca.Size = New System.Drawing.Size(238, 24)
        Me.ComboMarca.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboMarca.TabIndex = 517
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(42, 125)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 19)
        Me.Label1.TabIndex = 518
        Me.Label1.Text = "Modelo"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(48, 152)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(26, 14)
        Me.Label7.TabIndex = 520
        Me.Label7.Text = "Año"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(198, 152)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 14)
        Me.Label2.TabIndex = 522
        Me.Label2.Text = "Modelo"
        '
        'ComboModelo
        '
        Me.ComboModelo.BackColor = System.Drawing.Color.White
        Me.ComboModelo.BeforeTouchSize = New System.Drawing.Size(144, 24)
        Me.ComboModelo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboModelo.Enabled = False
        Me.ComboModelo.Font = New System.Drawing.Font("Tahoma", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboModelo.Location = New System.Drawing.Point(196, 171)
        Me.ComboModelo.MetroBorderColor = System.Drawing.Color.Silver
        Me.ComboModelo.Name = "ComboModelo"
        Me.ComboModelo.Size = New System.Drawing.Size(144, 24)
        Me.ComboModelo.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboModelo.TabIndex = 521
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(348, 152)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 14)
        Me.Label3.TabIndex = 524
        Me.Label3.Text = "Motor"
        '
        'ComboMotor
        '
        Me.ComboMotor.BackColor = System.Drawing.Color.White
        Me.ComboMotor.BeforeTouchSize = New System.Drawing.Size(144, 24)
        Me.ComboMotor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboMotor.Enabled = False
        Me.ComboMotor.Font = New System.Drawing.Font("Tahoma", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboMotor.Location = New System.Drawing.Point(346, 171)
        Me.ComboMotor.MetroBorderColor = System.Drawing.Color.Silver
        Me.ComboMotor.Name = "ComboMotor"
        Me.ComboMotor.Size = New System.Drawing.Size(144, 24)
        Me.ComboMotor.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboMotor.TabIndex = 523
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(42, 213)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(163, 19)
        Me.Label4.TabIndex = 525
        Me.Label4.Text = "Descripción del vehículo"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(347, 241)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 14)
        Me.Label5.TabIndex = 531
        Me.Label5.Text = "Transmisión"
        '
        'ComboTransmision
        '
        Me.ComboTransmision.BackColor = System.Drawing.Color.White
        Me.ComboTransmision.BeforeTouchSize = New System.Drawing.Size(144, 24)
        Me.ComboTransmision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboTransmision.Enabled = False
        Me.ComboTransmision.Font = New System.Drawing.Font("Tahoma", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboTransmision.Location = New System.Drawing.Point(345, 260)
        Me.ComboTransmision.MetroBorderColor = System.Drawing.Color.Silver
        Me.ComboTransmision.Name = "ComboTransmision"
        Me.ComboTransmision.Size = New System.Drawing.Size(144, 24)
        Me.ComboTransmision.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboTransmision.TabIndex = 530
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(197, 241)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(89, 14)
        Me.Label8.TabIndex = 529
        Me.Label8.Text = "Odómetro / K.m."
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(47, 241)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 14)
        Me.Label9.TabIndex = 527
        Me.Label9.Text = "Color"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(48, 290)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(71, 14)
        Me.Label10.TabIndex = 535
        Me.Label10.Text = "Tipo vehículo"
        '
        'ComboTipoVehiculo
        '
        Me.ComboTipoVehiculo.BackColor = System.Drawing.Color.White
        Me.ComboTipoVehiculo.BeforeTouchSize = New System.Drawing.Size(144, 24)
        Me.ComboTipoVehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboTipoVehiculo.Enabled = False
        Me.ComboTipoVehiculo.Font = New System.Drawing.Font("Tahoma", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboTipoVehiculo.Location = New System.Drawing.Point(46, 309)
        Me.ComboTipoVehiculo.MetroBorderColor = System.Drawing.Color.Silver
        Me.ComboTipoVehiculo.Name = "ComboTipoVehiculo"
        Me.ComboTipoVehiculo.Size = New System.Drawing.Size(144, 24)
        Me.ComboTipoVehiculo.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboTipoVehiculo.TabIndex = 534
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(48, 340)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(68, 14)
        Me.Label11.TabIndex = 537
        Me.Label11.Text = "Combustible"
        '
        'ComboCombustible
        '
        Me.ComboCombustible.BackColor = System.Drawing.Color.White
        Me.ComboCombustible.BeforeTouchSize = New System.Drawing.Size(144, 24)
        Me.ComboCombustible.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboCombustible.Enabled = False
        Me.ComboCombustible.Font = New System.Drawing.Font("Tahoma", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboCombustible.Location = New System.Drawing.Point(46, 359)
        Me.ComboCombustible.MetroBorderColor = System.Drawing.Color.Silver
        Me.ComboCombustible.Name = "ComboCombustible"
        Me.ComboCombustible.Size = New System.Drawing.Size(144, 24)
        Me.ComboCombustible.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboCombustible.TabIndex = 536
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(198, 290)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(122, 14)
        Me.Label12.TabIndex = 539
        Me.Label12.Text = "Sistema de Combustión"
        '
        'ComboSistemaCombustion
        '
        Me.ComboSistemaCombustion.BackColor = System.Drawing.Color.White
        Me.ComboSistemaCombustion.BeforeTouchSize = New System.Drawing.Size(293, 24)
        Me.ComboSistemaCombustion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboSistemaCombustion.Enabled = False
        Me.ComboSistemaCombustion.Font = New System.Drawing.Font("Tahoma", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboSistemaCombustion.Location = New System.Drawing.Point(196, 309)
        Me.ComboSistemaCombustion.MetroBorderColor = System.Drawing.Color.Silver
        Me.ComboSistemaCombustion.Name = "ComboSistemaCombustion"
        Me.ComboSistemaCombustion.Size = New System.Drawing.Size(293, 24)
        Me.ComboSistemaCombustion.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboSistemaCombustion.TabIndex = 538
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(198, 340)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(110, 14)
        Me.Label13.TabIndex = 541
        Me.Label13.Text = "Dirección de vehículo"
        '
        'ComboDireccion
        '
        Me.ComboDireccion.BackColor = System.Drawing.Color.White
        Me.ComboDireccion.BeforeTouchSize = New System.Drawing.Size(293, 24)
        Me.ComboDireccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboDireccion.Enabled = False
        Me.ComboDireccion.Font = New System.Drawing.Font("Tahoma", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboDireccion.Location = New System.Drawing.Point(196, 359)
        Me.ComboDireccion.MetroBorderColor = System.Drawing.Color.Silver
        Me.ComboDireccion.Name = "ComboDireccion"
        Me.ComboDireccion.Size = New System.Drawing.Size(293, 24)
        Me.ComboDireccion.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboDireccion.TabIndex = 540
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(48, 75)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(54, 14)
        Me.Label14.TabIndex = 544
        Me.Label14.Text = "Matrícula"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(249, 75)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(38, 14)
        Me.Label15.TabIndex = 545
        Me.Label15.Text = "Marca"
        '
        'RoundButton22
        '
        Me.RoundButton22.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton22.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.RoundButton22.BeforeTouchSize = New System.Drawing.Size(115, 27)
        Me.RoundButton22.BorderStyleAdv = Syncfusion.Windows.Forms.ButtonAdvBorderStyle.Sunken
        Me.RoundButton22.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundButton22.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.RoundButton22.IsBackStageButton = False
        Me.RoundButton22.Location = New System.Drawing.Point(256, 410)
        Me.RoundButton22.Name = "RoundButton22"
        Me.RoundButton22.Size = New System.Drawing.Size(115, 27)
        Me.RoundButton22.TabIndex = 543
        Me.RoundButton22.Text = "CANCELAR"
        Me.RoundButton22.UseVisualStyle = True
        '
        'RoundButton21
        '
        Me.RoundButton21.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton21.BackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.RoundButton21.BeforeTouchSize = New System.Drawing.Size(112, 36)
        Me.RoundButton21.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundButton21.ForeColor = System.Drawing.Color.White
        Me.RoundButton21.IsBackStageButton = False
        Me.RoundButton21.Location = New System.Drawing.Point(377, 402)
        Me.RoundButton21.Name = "RoundButton21"
        Me.RoundButton21.Size = New System.Drawing.Size(112, 36)
        Me.RoundButton21.TabIndex = 542
        Me.RoundButton21.Text = "GUARDAR"
        Me.RoundButton21.UseVisualStyle = True
        '
        'FormCrearVehiculo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionButtonColor = System.Drawing.SystemColors.HotTrack
        Me.CaptionButtonHoverColor = System.Drawing.SystemColors.HotTrack
        Me.CaptionForeColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(537, 450)
        Me.Controls.Add(Me.TextAnio)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.RoundButton22)
        Me.Controls.Add(Me.RoundButton21)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.ComboDireccion)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.ComboSistemaCombustion)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.ComboCombustible)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.ComboTipoVehiculo)
        Me.Controls.Add(Me.TextOdometro)
        Me.Controls.Add(Me.TextColor)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ComboTransmision)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ComboMotor)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ComboModelo)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboMarca)
        Me.Controls.Add(Me.TextMatricula)
        Me.Controls.Add(Me.TextCliente)
        Me.Controls.Add(Me.Label6)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormCrearVehiculo"
        Me.ShowIcon = False
        Me.Text = "Crear Vehiculo"
        CType(Me.TextCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextMatricula, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextColor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextOdometro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextAnio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboMarca, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboModelo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboMotor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboTransmision, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboTipoVehiculo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboCombustible, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboSistemaCombustion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboDireccion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BannerTextProvider1 As Syncfusion.Windows.Forms.BannerTextProvider
    Friend WithEvents Label6 As Label
    Friend WithEvents TextCliente As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents TextMatricula As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents ComboMarca As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label1 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ComboModelo As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label3 As Label
    Friend WithEvents ComboMotor As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents ComboTransmision As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents TextColor As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents TextOdometro As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label10 As Label
    Friend WithEvents ComboTipoVehiculo As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label11 As Label
    Friend WithEvents ComboCombustible As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label12 As Label
    Friend WithEvents ComboSistemaCombustion As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label13 As Label
    Friend WithEvents ComboDireccion As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents RoundButton21 As RoundButton2
    Friend WithEvents RoundButton22 As RoundButton2
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents TextAnio As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents ColorDialog1 As ColorDialog
End Class

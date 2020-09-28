Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormCrearActivo
    Inherits MetroForm

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
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCrearActivo))
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Dim CaptionLabel2 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.TextAnio = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.RoundButton22 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.RoundButton21 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ComboDireccion = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ComboSistemaCombustion = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ComboCombustible = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ComboTipoVehiculo = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.TextOdometro = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextColor = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ComboTransmision = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboMotor = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboModelo = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboMarca = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.TextMatricula = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextDescripcion = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.TextAnio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboSistemaCombustion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboCombustible, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboTipoVehiculo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextOdometro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextColor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboTransmision, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboMotor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboModelo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboMarca, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextMatricula, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextDescripcion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextAnio
        '
        Me.TextAnio.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextAnio.BeforeTouchSize = New System.Drawing.Size(68, 28)
        Me.TextAnio.BorderColor = System.Drawing.Color.Silver
        Me.TextAnio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextAnio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextAnio.CornerRadius = 4
        Me.TextAnio.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextAnio.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextAnio.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextAnio.Location = New System.Drawing.Point(33, 141)
        Me.TextAnio.MaxLength = 4
        Me.TextAnio.Metrocolor = System.Drawing.Color.Silver
        Me.TextAnio.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextAnio.Name = "TextAnio"
        Me.TextAnio.Size = New System.Drawing.Size(144, 24)
        Me.TextAnio.TabIndex = 576
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Enabled = False
        Me.Label15.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(238, 38)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(38, 14)
        Me.Label15.TabIndex = 575
        Me.Label15.Text = "Marca"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(29, 33)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(42, 19)
        Me.Label14.TabIndex = 574
        Me.Label14.Text = "Placa"
        '
        'RoundButton22
        '
        Me.RoundButton22.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundButton22.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton22.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.RoundButton22.BeforeTouchSize = New System.Drawing.Size(115, 26)
        Me.RoundButton22.BorderStyleAdv = Syncfusion.Windows.Forms.ButtonAdvBorderStyle.Sunken
        Me.RoundButton22.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundButton22.ForeColor = System.Drawing.Color.White
        Me.RoundButton22.IsBackStageButton = False
        Me.RoundButton22.Location = New System.Drawing.Point(285, 443)
        Me.RoundButton22.Name = "RoundButton22"
        Me.RoundButton22.Size = New System.Drawing.Size(115, 26)
        Me.RoundButton22.TabIndex = 573
        Me.RoundButton22.Text = "CANCELAR"
        Me.RoundButton22.UseVisualStyle = True
        '
        'RoundButton21
        '
        Me.RoundButton21.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RoundButton21.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton21.BackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.RoundButton21.BeforeTouchSize = New System.Drawing.Size(112, 27)
        Me.RoundButton21.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundButton21.ForeColor = System.Drawing.Color.White
        Me.RoundButton21.IsBackStageButton = False
        Me.RoundButton21.Location = New System.Drawing.Point(406, 443)
        Me.RoundButton21.Name = "RoundButton21"
        Me.RoundButton21.Size = New System.Drawing.Size(112, 27)
        Me.RoundButton21.TabIndex = 572
        Me.RoundButton21.Text = "GUARDAR"
        Me.RoundButton21.UseVisualStyle = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Enabled = False
        Me.Label13.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(185, 316)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(110, 14)
        Me.Label13.TabIndex = 571
        Me.Label13.Text = "Dirección de vehículo"
        '
        'ComboDireccion
        '
        Me.ComboDireccion.BackColor = System.Drawing.Color.White
        Me.ComboDireccion.BeforeTouchSize = New System.Drawing.Size(293, 24)
        Me.ComboDireccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboDireccion.Enabled = False
        Me.ComboDireccion.Font = New System.Drawing.Font("Tahoma", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboDireccion.Location = New System.Drawing.Point(183, 335)
        Me.ComboDireccion.MetroBorderColor = System.Drawing.Color.Silver
        Me.ComboDireccion.Name = "ComboDireccion"
        Me.ComboDireccion.Size = New System.Drawing.Size(293, 24)
        Me.ComboDireccion.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboDireccion.TabIndex = 570
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Enabled = False
        Me.Label12.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(185, 266)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(122, 14)
        Me.Label12.TabIndex = 569
        Me.Label12.Text = "Sistema de Combustión"
        '
        'ComboSistemaCombustion
        '
        Me.ComboSistemaCombustion.BackColor = System.Drawing.Color.White
        Me.ComboSistemaCombustion.BeforeTouchSize = New System.Drawing.Size(293, 24)
        Me.ComboSistemaCombustion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboSistemaCombustion.Enabled = False
        Me.ComboSistemaCombustion.Font = New System.Drawing.Font("Tahoma", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboSistemaCombustion.Location = New System.Drawing.Point(183, 285)
        Me.ComboSistemaCombustion.MetroBorderColor = System.Drawing.Color.Silver
        Me.ComboSistemaCombustion.Name = "ComboSistemaCombustion"
        Me.ComboSistemaCombustion.Size = New System.Drawing.Size(293, 24)
        Me.ComboSistemaCombustion.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboSistemaCombustion.TabIndex = 568
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Enabled = False
        Me.Label11.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(35, 316)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(68, 14)
        Me.Label11.TabIndex = 567
        Me.Label11.Text = "Combustible"
        '
        'ComboCombustible
        '
        Me.ComboCombustible.BackColor = System.Drawing.Color.White
        Me.ComboCombustible.BeforeTouchSize = New System.Drawing.Size(144, 24)
        Me.ComboCombustible.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboCombustible.Enabled = False
        Me.ComboCombustible.Font = New System.Drawing.Font("Tahoma", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboCombustible.Location = New System.Drawing.Point(33, 335)
        Me.ComboCombustible.MetroBorderColor = System.Drawing.Color.Silver
        Me.ComboCombustible.Name = "ComboCombustible"
        Me.ComboCombustible.Size = New System.Drawing.Size(144, 24)
        Me.ComboCombustible.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboCombustible.TabIndex = 566
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Enabled = False
        Me.Label10.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(35, 266)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(71, 14)
        Me.Label10.TabIndex = 565
        Me.Label10.Text = "Tipo vehículo"
        '
        'ComboTipoVehiculo
        '
        Me.ComboTipoVehiculo.BackColor = System.Drawing.Color.White
        Me.ComboTipoVehiculo.BeforeTouchSize = New System.Drawing.Size(144, 24)
        Me.ComboTipoVehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboTipoVehiculo.Enabled = False
        Me.ComboTipoVehiculo.Font = New System.Drawing.Font("Tahoma", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboTipoVehiculo.Location = New System.Drawing.Point(33, 285)
        Me.ComboTipoVehiculo.MetroBorderColor = System.Drawing.Color.Silver
        Me.ComboTipoVehiculo.Name = "ComboTipoVehiculo"
        Me.ComboTipoVehiculo.Size = New System.Drawing.Size(144, 24)
        Me.ComboTipoVehiculo.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboTipoVehiculo.TabIndex = 564
        '
        'TextOdometro
        '
        Me.TextOdometro.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextOdometro.BeforeTouchSize = New System.Drawing.Size(68, 28)
        Me.TextOdometro.BorderColor = System.Drawing.Color.Silver
        Me.TextOdometro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextOdometro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextOdometro.CornerRadius = 4
        Me.TextOdometro.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextOdometro.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextOdometro.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextOdometro.Location = New System.Drawing.Point(182, 236)
        Me.TextOdometro.Metrocolor = System.Drawing.Color.Silver
        Me.TextOdometro.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextOdometro.Name = "TextOdometro"
        Me.TextOdometro.Size = New System.Drawing.Size(144, 24)
        Me.TextOdometro.TabIndex = 563
        '
        'TextColor
        '
        Me.TextColor.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextColor.BeforeTouchSize = New System.Drawing.Size(68, 28)
        Me.TextColor.BorderColor = System.Drawing.Color.Silver
        Me.TextColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextColor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextColor.CornerRadius = 4
        Me.TextColor.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextColor.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextColor.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextColor.Location = New System.Drawing.Point(33, 236)
        Me.TextColor.Metrocolor = System.Drawing.Color.Silver
        Me.TextColor.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextColor.Name = "TextColor"
        Me.TextColor.Size = New System.Drawing.Size(143, 24)
        Me.TextColor.TabIndex = 562
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(334, 217)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 14)
        Me.Label5.TabIndex = 561
        Me.Label5.Text = "Transmisión"
        '
        'ComboTransmision
        '
        Me.ComboTransmision.BackColor = System.Drawing.Color.White
        Me.ComboTransmision.BeforeTouchSize = New System.Drawing.Size(144, 24)
        Me.ComboTransmision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboTransmision.Enabled = False
        Me.ComboTransmision.Font = New System.Drawing.Font("Tahoma", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboTransmision.Location = New System.Drawing.Point(332, 236)
        Me.ComboTransmision.MetroBorderColor = System.Drawing.Color.Silver
        Me.ComboTransmision.Name = "ComboTransmision"
        Me.ComboTransmision.Size = New System.Drawing.Size(144, 24)
        Me.ComboTransmision.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboTransmision.TabIndex = 560
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(184, 217)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(89, 14)
        Me.Label8.TabIndex = 559
        Me.Label8.Text = "Odómetro / K.m."
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(34, 217)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 14)
        Me.Label9.TabIndex = 558
        Me.Label9.Text = "Color"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(29, 189)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(163, 19)
        Me.Label4.TabIndex = 557
        Me.Label4.Text = "Descripción del vehículo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Enabled = False
        Me.Label3.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(335, 122)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 14)
        Me.Label3.TabIndex = 556
        Me.Label3.Text = "Motor"
        '
        'ComboMotor
        '
        Me.ComboMotor.BackColor = System.Drawing.Color.White
        Me.ComboMotor.BeforeTouchSize = New System.Drawing.Size(144, 24)
        Me.ComboMotor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboMotor.Enabled = False
        Me.ComboMotor.Font = New System.Drawing.Font("Tahoma", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboMotor.Location = New System.Drawing.Point(333, 141)
        Me.ComboMotor.MetroBorderColor = System.Drawing.Color.Silver
        Me.ComboMotor.Name = "ComboMotor"
        Me.ComboMotor.Size = New System.Drawing.Size(144, 24)
        Me.ComboMotor.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboMotor.TabIndex = 555
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Enabled = False
        Me.Label2.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(185, 122)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 14)
        Me.Label2.TabIndex = 554
        Me.Label2.Text = "Modelo"
        '
        'ComboModelo
        '
        Me.ComboModelo.BackColor = System.Drawing.Color.White
        Me.ComboModelo.BeforeTouchSize = New System.Drawing.Size(144, 24)
        Me.ComboModelo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboModelo.Enabled = False
        Me.ComboModelo.Font = New System.Drawing.Font("Tahoma", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboModelo.Location = New System.Drawing.Point(183, 141)
        Me.ComboModelo.MetroBorderColor = System.Drawing.Color.Silver
        Me.ComboModelo.Name = "ComboModelo"
        Me.ComboModelo.Size = New System.Drawing.Size(144, 24)
        Me.ComboModelo.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboModelo.TabIndex = 553
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(37, 122)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(26, 14)
        Me.Label7.TabIndex = 552
        Me.Label7.Text = "Año"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(29, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 19)
        Me.Label1.TabIndex = 551
        Me.Label1.Text = "Modelo"
        '
        'ComboMarca
        '
        Me.ComboMarca.BackColor = System.Drawing.Color.White
        Me.ComboMarca.BeforeTouchSize = New System.Drawing.Size(238, 24)
        Me.ComboMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboMarca.Enabled = False
        Me.ComboMarca.Font = New System.Drawing.Font("Tahoma", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboMarca.Location = New System.Drawing.Point(241, 57)
        Me.ComboMarca.MetroBorderColor = System.Drawing.Color.Silver
        Me.ComboMarca.Name = "ComboMarca"
        Me.ComboMarca.Size = New System.Drawing.Size(238, 24)
        Me.ComboMarca.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboMarca.TabIndex = 550
        '
        'TextMatricula
        '
        Me.TextMatricula.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextMatricula.BeforeTouchSize = New System.Drawing.Size(68, 28)
        Me.TextMatricula.BorderColor = System.Drawing.Color.Silver
        Me.TextMatricula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextMatricula.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextMatricula.CornerRadius = 4
        Me.TextMatricula.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextMatricula.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextMatricula.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextMatricula.Location = New System.Drawing.Point(28, 57)
        Me.TextMatricula.Metrocolor = System.Drawing.Color.Silver
        Me.TextMatricula.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextMatricula.Name = "TextMatricula"
        Me.TextMatricula.Size = New System.Drawing.Size(200, 24)
        Me.TextMatricula.TabIndex = 549
        '
        'TextDescripcion
        '
        Me.TextDescripcion.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextDescripcion.BeforeTouchSize = New System.Drawing.Size(68, 28)
        Me.TextDescripcion.BorderColor = System.Drawing.SystemColors.MenuHighlight
        Me.TextDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextDescripcion.CornerRadius = 4
        Me.TextDescripcion.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextDescripcion.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextDescripcion.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextDescripcion.Location = New System.Drawing.Point(33, 387)
        Me.TextDescripcion.Metrocolor = System.Drawing.SystemColors.MenuHighlight
        Me.TextDescripcion.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextDescripcion.Name = "TextDescripcion"
        Me.TextDescripcion.Size = New System.Drawing.Size(449, 24)
        Me.TextDescripcion.TabIndex = 548
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.TextDescripcion)
        Me.GroupBox1.Controls.Add(Me.TextMatricula)
        Me.GroupBox1.Controls.Add(Me.ComboMarca)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.ComboModelo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.ComboMotor)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TextAnio)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.ComboTransmision)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.TextColor)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.TextOdometro)
        Me.GroupBox1.Controls.Add(Me.ComboDireccion)
        Me.GroupBox1.Controls.Add(Me.ComboTipoVehiculo)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.ComboSistemaCombustion)
        Me.GroupBox1.Controls.Add(Me.ComboCombustible)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft JhengHei UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(26, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(492, 425)
        Me.GroupBox1.TabIndex = 587
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Vehiculo"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Enabled = False
        Me.Label6.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(30, 370)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 14)
        Me.Label6.TabIndex = 577
        Me.Label6.Text = "Descripción"
        '
        'FormCrearActivo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.SystemColors.Highlight
        Me.BorderThickness = 2
        Me.CaptionBarHeight = 45
        Me.CaptionForeColor = System.Drawing.Color.White
        CaptionImage1.BackColor = System.Drawing.Color.White
        CaptionImage1.ForeColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(30, 8)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(40, 40)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Microsoft JhengHei UI", 14.0!, System.Drawing.FontStyle.Bold)
        CaptionLabel1.ForeColor = System.Drawing.Color.SteelBlue
        CaptionLabel1.Location = New System.Drawing.Point(80, 4)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(500, 24)
        CaptionLabel1.Text = "Transporte"
        CaptionLabel2.Font = New System.Drawing.Font("Microsoft JhengHei UI", 8.0!, System.Drawing.FontStyle.Bold)
        CaptionLabel2.Location = New System.Drawing.Point(80, 25)
        CaptionLabel2.Name = "CaptionLabel2"
        CaptionLabel2.Size = New System.Drawing.Size(300, 24)
        CaptionLabel2.Text = "Creación Activo"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.CaptionLabels.Add(CaptionLabel2)
        Me.ClientSize = New System.Drawing.Size(538, 473)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.RoundButton22)
        Me.Controls.Add(Me.RoundButton21)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormCrearActivo"
        Me.ShowIcon = False
        Me.Text = "Crear Bus"
        CType(Me.TextAnio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboDireccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboSistemaCombustion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboCombustible, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboTipoVehiculo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextOdometro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextColor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboTransmision, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboMotor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboModelo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboMarca, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextMatricula, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextDescripcion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TextAnio As Tools.TextBoxExt
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents RoundButton22 As RoundButton2
    Friend WithEvents RoundButton21 As RoundButton2
    Friend WithEvents Label13 As Label
    Friend WithEvents ComboDireccion As Tools.ComboBoxAdv
    Friend WithEvents Label12 As Label
    Friend WithEvents ComboSistemaCombustion As Tools.ComboBoxAdv
    Friend WithEvents Label11 As Label
    Friend WithEvents ComboCombustible As Tools.ComboBoxAdv
    Friend WithEvents Label10 As Label
    Friend WithEvents ComboTipoVehiculo As Tools.ComboBoxAdv
    Friend WithEvents TextOdometro As Tools.TextBoxExt
    Friend WithEvents TextColor As Tools.TextBoxExt
    Friend WithEvents Label5 As Label
    Friend WithEvents ComboTransmision As Tools.ComboBoxAdv
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ComboMotor As Tools.ComboBoxAdv
    Friend WithEvents Label2 As Label
    Friend WithEvents ComboModelo As Tools.ComboBoxAdv
    Friend WithEvents Label7 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents ComboMarca As Tools.ComboBoxAdv
    Friend WithEvents TextMatricula As Tools.TextBoxExt
    Friend WithEvents TextDescripcion As Tools.TextBoxExt
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label6 As Label
End Class

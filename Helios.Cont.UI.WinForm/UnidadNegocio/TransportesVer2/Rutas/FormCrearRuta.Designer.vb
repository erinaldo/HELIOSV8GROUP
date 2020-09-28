Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormCrearRuta
    Inherits MetroForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCrearRuta))
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TextCodigoRuta = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TexDomicilioOrigen = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TexDomicilioDestino = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.BtGrabar = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GBDestino = New System.Windows.Forms.GroupBox()
        Me.txtProvinciaDestino = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtRegionDestino = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtCiudadDestino = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.ComboAgenciaDestino = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.GBOrigen = New System.Windows.Forms.GroupBox()
        Me.txtProvinciaOrigen = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtRegionOrigen = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtDistritoOrigen = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.ComboAgenciaOrigen = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.RoundButton21 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.btnQuitar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.chHabilitarRutas = New System.Windows.Forms.CheckBox()
        Me.GBRuta = New System.Windows.Forms.GroupBox()
        Me.txtRutaDestino = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtRutaOrigen = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GridTotales = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.bgCombos = New System.ComponentModel.BackgroundWorker()
        Me.tabSubRutas = New Syncfusion.Windows.Forms.Tools.TabPageAdv()
        Me.TabPageAdv1 = New Syncfusion.Windows.Forms.Tools.TabPageAdv()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxExt1 = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TabControlAdv1 = New Syncfusion.Windows.Forms.Tools.TabControlAdv()
        CType(Me.TextCodigoRuta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TexDomicilioOrigen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TexDomicilioDestino, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBDestino.SuspendLayout()
        CType(Me.txtProvinciaDestino, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRegionDestino, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCiudadDestino, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboAgenciaDestino, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBOrigen.SuspendLayout()
        CType(Me.txtProvinciaOrigen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRegionOrigen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDistritoOrigen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboAgenciaOrigen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBRuta.SuspendLayout()
        CType(Me.txtRutaDestino, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRutaOrigen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridTotales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabSubRutas.SuspendLayout()
        Me.TabPageAdv1.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.TextBoxExt1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabControlAdv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlAdv1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(415, 15)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(40, 14)
        Me.Label14.TabIndex = 576
        Me.Label14.Text = "Codigo"
        Me.Label14.Visible = False
        '
        'TextCodigoRuta
        '
        Me.TextCodigoRuta.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextCodigoRuta.BeforeTouchSize = New System.Drawing.Size(280, 24)
        Me.TextCodigoRuta.BorderColor = System.Drawing.Color.Silver
        Me.TextCodigoRuta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextCodigoRuta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextCodigoRuta.CornerRadius = 4
        Me.TextCodigoRuta.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextCodigoRuta.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextCodigoRuta.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextCodigoRuta.Location = New System.Drawing.Point(461, 12)
        Me.TextCodigoRuta.MaxLength = 20
        Me.TextCodigoRuta.Metrocolor = System.Drawing.Color.Silver
        Me.TextCodigoRuta.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextCodigoRuta.Name = "TextCodigoRuta"
        Me.TextCodigoRuta.Size = New System.Drawing.Size(95, 24)
        Me.TextCodigoRuta.TabIndex = 575
        Me.TextCodigoRuta.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(371, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 580
        Me.Label2.Text = "Distrito"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(25, 136)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(50, 13)
        Me.Label17.TabIndex = 599
        Me.Label17.Text = "Dirección"
        '
        'TexDomicilioOrigen
        '
        Me.TexDomicilioOrigen.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TexDomicilioOrigen.BeforeTouchSize = New System.Drawing.Size(280, 24)
        Me.TexDomicilioOrigen.BorderColor = System.Drawing.Color.Silver
        Me.TexDomicilioOrigen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TexDomicilioOrigen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TexDomicilioOrigen.CornerRadius = 4
        Me.TexDomicilioOrigen.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TexDomicilioOrigen.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TexDomicilioOrigen.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TexDomicilioOrigen.Location = New System.Drawing.Point(27, 152)
        Me.TexDomicilioOrigen.Metrocolor = System.Drawing.Color.Silver
        Me.TexDomicilioOrigen.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TexDomicilioOrigen.Name = "TexDomicilioOrigen"
        Me.TexDomicilioOrigen.Size = New System.Drawing.Size(529, 24)
        Me.TexDomicilioOrigen.TabIndex = 578
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(199, 74)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(50, 13)
        Me.Label27.TabIndex = 607
        Me.Label27.Text = "Provincia"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(25, 74)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(40, 13)
        Me.Label28.TabIndex = 605
        Me.Label28.Text = "Region"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(24, 128)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(50, 13)
        Me.Label18.TabIndex = 600
        Me.Label18.Text = "Dirección"
        '
        'TexDomicilioDestino
        '
        Me.TexDomicilioDestino.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TexDomicilioDestino.BeforeTouchSize = New System.Drawing.Size(280, 24)
        Me.TexDomicilioDestino.BorderColor = System.Drawing.Color.Silver
        Me.TexDomicilioDestino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TexDomicilioDestino.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TexDomicilioDestino.CornerRadius = 4
        Me.TexDomicilioDestino.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TexDomicilioDestino.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TexDomicilioDestino.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TexDomicilioDestino.Location = New System.Drawing.Point(27, 144)
        Me.TexDomicilioDestino.Metrocolor = System.Drawing.Color.Silver
        Me.TexDomicilioDestino.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TexDomicilioDestino.Name = "TexDomicilioDestino"
        Me.TexDomicilioDestino.Size = New System.Drawing.Size(529, 24)
        Me.TexDomicilioDestino.TabIndex = 578
        '
        'BtGrabar
        '
        Me.BtGrabar.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.BtGrabar.BackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.BtGrabar.BeforeTouchSize = New System.Drawing.Size(112, 27)
        Me.BtGrabar.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtGrabar.ForeColor = System.Drawing.Color.White
        Me.BtGrabar.IsBackStageButton = False
        Me.BtGrabar.Location = New System.Drawing.Point(698, 549)
        Me.BtGrabar.Name = "BtGrabar"
        Me.BtGrabar.Size = New System.Drawing.Size(112, 27)
        Me.BtGrabar.TabIndex = 581
        Me.BtGrabar.Text = "GUARDAR"
        Me.BtGrabar.UseVisualStyle = True
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'GBDestino
        '
        Me.GBDestino.Controls.Add(Me.txtProvinciaDestino)
        Me.GBDestino.Controls.Add(Me.txtRegionDestino)
        Me.GBDestino.Controls.Add(Me.txtCiudadDestino)
        Me.GBDestino.Controls.Add(Me.Label6)
        Me.GBDestino.Controls.Add(Me.Label31)
        Me.GBDestino.Controls.Add(Me.Label34)
        Me.GBDestino.Controls.Add(Me.Label33)
        Me.GBDestino.Controls.Add(Me.ComboAgenciaDestino)
        Me.GBDestino.Controls.Add(Me.Label17)
        Me.GBDestino.Controls.Add(Me.TexDomicilioOrigen)
        Me.GBDestino.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.GBDestino.ForeColor = System.Drawing.Color.Navy
        Me.GBDestino.Location = New System.Drawing.Point(8, 189)
        Me.GBDestino.Name = "GBDestino"
        Me.GBDestino.Size = New System.Drawing.Size(573, 185)
        Me.GBDestino.TabIndex = 617
        Me.GBDestino.TabStop = False
        Me.GBDestino.Text = "Agencia Destino"
        '
        'txtProvinciaDestino
        '
        Me.txtProvinciaDestino.BackColor = System.Drawing.Color.White
        Me.txtProvinciaDestino.BeforeTouchSize = New System.Drawing.Size(280, 24)
        Me.txtProvinciaDestino.BorderColor = System.Drawing.Color.Silver
        Me.txtProvinciaDestino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProvinciaDestino.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProvinciaDestino.CornerRadius = 4
        Me.txtProvinciaDestino.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtProvinciaDestino.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProvinciaDestino.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtProvinciaDestino.Location = New System.Drawing.Point(203, 98)
        Me.txtProvinciaDestino.Metrocolor = System.Drawing.Color.White
        Me.txtProvinciaDestino.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtProvinciaDestino.Name = "txtProvinciaDestino"
        Me.txtProvinciaDestino.Size = New System.Drawing.Size(166, 24)
        Me.txtProvinciaDestino.TabIndex = 620
        '
        'txtRegionDestino
        '
        Me.txtRegionDestino.BackColor = System.Drawing.Color.White
        Me.txtRegionDestino.BeforeTouchSize = New System.Drawing.Size(280, 24)
        Me.txtRegionDestino.BorderColor = System.Drawing.Color.Silver
        Me.txtRegionDestino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRegionDestino.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRegionDestino.CornerRadius = 4
        Me.txtRegionDestino.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtRegionDestino.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegionDestino.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtRegionDestino.Location = New System.Drawing.Point(28, 98)
        Me.txtRegionDestino.Metrocolor = System.Drawing.Color.White
        Me.txtRegionDestino.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtRegionDestino.Name = "txtRegionDestino"
        Me.txtRegionDestino.Size = New System.Drawing.Size(168, 24)
        Me.txtRegionDestino.TabIndex = 619
        '
        'txtCiudadDestino
        '
        Me.txtCiudadDestino.BackColor = System.Drawing.Color.White
        Me.txtCiudadDestino.BeforeTouchSize = New System.Drawing.Size(280, 24)
        Me.txtCiudadDestino.BorderColor = System.Drawing.Color.Silver
        Me.txtCiudadDestino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCiudadDestino.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCiudadDestino.CornerRadius = 4
        Me.txtCiudadDestino.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtCiudadDestino.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCiudadDestino.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtCiudadDestino.Location = New System.Drawing.Point(375, 98)
        Me.txtCiudadDestino.Metrocolor = System.Drawing.Color.White
        Me.txtCiudadDestino.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtCiudadDestino.Name = "txtCiudadDestino"
        Me.txtCiudadDestino.Size = New System.Drawing.Size(182, 24)
        Me.txtCiudadDestino.TabIndex = 618
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(371, 79)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 13)
        Me.Label6.TabIndex = 609
        Me.Label6.Text = "Distrito"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.Black
        Me.Label31.Location = New System.Drawing.Point(199, 79)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(50, 13)
        Me.Label31.TabIndex = 613
        Me.Label31.Text = "Provincia"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.BackColor = System.Drawing.Color.Transparent
        Me.Label34.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.Black
        Me.Label34.Location = New System.Drawing.Point(25, 79)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(40, 13)
        Me.Label34.TabIndex = 611
        Me.Label34.Text = "Region"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.Black
        Me.Label33.Location = New System.Drawing.Point(24, 28)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(46, 14)
        Me.Label33.TabIndex = 601
        Me.Label33.Text = "Agencia"
        '
        'ComboAgenciaDestino
        '
        Me.ComboAgenciaDestino.BackColor = System.Drawing.Color.White
        Me.ComboAgenciaDestino.BeforeTouchSize = New System.Drawing.Size(529, 24)
        Me.ComboAgenciaDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboAgenciaDestino.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboAgenciaDestino.Location = New System.Drawing.Point(27, 45)
        Me.ComboAgenciaDestino.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.ComboAgenciaDestino.Name = "ComboAgenciaDestino"
        Me.ComboAgenciaDestino.Size = New System.Drawing.Size(529, 24)
        Me.ComboAgenciaDestino.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboAgenciaDestino.TabIndex = 588
        '
        'GBOrigen
        '
        Me.GBOrigen.Controls.Add(Me.txtProvinciaOrigen)
        Me.GBOrigen.Controls.Add(Me.txtRegionOrigen)
        Me.GBOrigen.Controls.Add(Me.txtDistritoOrigen)
        Me.GBOrigen.Controls.Add(Me.Label32)
        Me.GBOrigen.Controls.Add(Me.Label2)
        Me.GBOrigen.Controls.Add(Me.Label27)
        Me.GBOrigen.Controls.Add(Me.Label14)
        Me.GBOrigen.Controls.Add(Me.TextCodigoRuta)
        Me.GBOrigen.Controls.Add(Me.ComboAgenciaOrigen)
        Me.GBOrigen.Controls.Add(Me.Label28)
        Me.GBOrigen.Controls.Add(Me.Label18)
        Me.GBOrigen.Controls.Add(Me.TexDomicilioDestino)
        Me.GBOrigen.Enabled = False
        Me.GBOrigen.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.GBOrigen.ForeColor = System.Drawing.Color.Navy
        Me.GBOrigen.Location = New System.Drawing.Point(8, 3)
        Me.GBOrigen.Name = "GBOrigen"
        Me.GBOrigen.Size = New System.Drawing.Size(573, 180)
        Me.GBOrigen.TabIndex = 616
        Me.GBOrigen.TabStop = False
        Me.GBOrigen.Text = "Agencia Origen"
        '
        'txtProvinciaOrigen
        '
        Me.txtProvinciaOrigen.BackColor = System.Drawing.Color.White
        Me.txtProvinciaOrigen.BeforeTouchSize = New System.Drawing.Size(280, 24)
        Me.txtProvinciaOrigen.BorderColor = System.Drawing.Color.Silver
        Me.txtProvinciaOrigen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProvinciaOrigen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProvinciaOrigen.CornerRadius = 4
        Me.txtProvinciaOrigen.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtProvinciaOrigen.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProvinciaOrigen.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtProvinciaOrigen.Location = New System.Drawing.Point(202, 90)
        Me.txtProvinciaOrigen.Metrocolor = System.Drawing.Color.White
        Me.txtProvinciaOrigen.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtProvinciaOrigen.Name = "txtProvinciaOrigen"
        Me.txtProvinciaOrigen.Size = New System.Drawing.Size(166, 24)
        Me.txtProvinciaOrigen.TabIndex = 617
        '
        'txtRegionOrigen
        '
        Me.txtRegionOrigen.BackColor = System.Drawing.Color.White
        Me.txtRegionOrigen.BeforeTouchSize = New System.Drawing.Size(280, 24)
        Me.txtRegionOrigen.BorderColor = System.Drawing.Color.Silver
        Me.txtRegionOrigen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRegionOrigen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRegionOrigen.CornerRadius = 4
        Me.txtRegionOrigen.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtRegionOrigen.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegionOrigen.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtRegionOrigen.Location = New System.Drawing.Point(27, 90)
        Me.txtRegionOrigen.Metrocolor = System.Drawing.Color.White
        Me.txtRegionOrigen.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtRegionOrigen.Name = "txtRegionOrigen"
        Me.txtRegionOrigen.Size = New System.Drawing.Size(168, 24)
        Me.txtRegionOrigen.TabIndex = 616
        '
        'txtDistritoOrigen
        '
        Me.txtDistritoOrigen.BackColor = System.Drawing.Color.White
        Me.txtDistritoOrigen.BeforeTouchSize = New System.Drawing.Size(280, 24)
        Me.txtDistritoOrigen.BorderColor = System.Drawing.Color.Silver
        Me.txtDistritoOrigen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDistritoOrigen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDistritoOrigen.CornerRadius = 4
        Me.txtDistritoOrigen.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtDistritoOrigen.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDistritoOrigen.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtDistritoOrigen.Location = New System.Drawing.Point(374, 90)
        Me.txtDistritoOrigen.Metrocolor = System.Drawing.Color.White
        Me.txtDistritoOrigen.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtDistritoOrigen.Name = "txtDistritoOrigen"
        Me.txtDistritoOrigen.Size = New System.Drawing.Size(182, 24)
        Me.txtDistritoOrigen.TabIndex = 615
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.BackColor = System.Drawing.Color.Transparent
        Me.Label32.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.Black
        Me.Label32.Location = New System.Drawing.Point(24, 27)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(46, 14)
        Me.Label32.TabIndex = 590
        Me.Label32.Text = "Agencia"
        '
        'ComboAgenciaOrigen
        '
        Me.ComboAgenciaOrigen.BackColor = System.Drawing.Color.White
        Me.ComboAgenciaOrigen.BeforeTouchSize = New System.Drawing.Size(529, 24)
        Me.ComboAgenciaOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboAgenciaOrigen.Enabled = False
        Me.ComboAgenciaOrigen.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboAgenciaOrigen.Location = New System.Drawing.Point(27, 44)
        Me.ComboAgenciaOrigen.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.ComboAgenciaOrigen.Name = "ComboAgenciaOrigen"
        Me.ComboAgenciaOrigen.Size = New System.Drawing.Size(529, 24)
        Me.ComboAgenciaOrigen.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboAgenciaOrigen.TabIndex = 587
        '
        'RoundButton21
        '
        Me.RoundButton21.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton21.BackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.RoundButton21.BeforeTouchSize = New System.Drawing.Size(112, 27)
        Me.RoundButton21.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundButton21.ForeColor = System.Drawing.Color.White
        Me.RoundButton21.IsBackStageButton = False
        Me.RoundButton21.Location = New System.Drawing.Point(816, 549)
        Me.RoundButton21.Name = "RoundButton21"
        Me.RoundButton21.Size = New System.Drawing.Size(112, 27)
        Me.RoundButton21.TabIndex = 618
        Me.RoundButton21.Text = "CERRAR"
        Me.RoundButton21.UseVisualStyle = True
        '
        'btnQuitar
        '
        Me.btnQuitar.BackColor = System.Drawing.Color.SteelBlue
        Me.btnQuitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnQuitar.Font = New System.Drawing.Font("Cooper Black", 20.25!)
        Me.btnQuitar.ForeColor = System.Drawing.Color.White
        Me.btnQuitar.Location = New System.Drawing.Point(819, 131)
        Me.btnQuitar.Name = "btnQuitar"
        Me.btnQuitar.Size = New System.Drawing.Size(42, 41)
        Me.btnQuitar.TabIndex = 632
        Me.btnQuitar.Text = "-"
        Me.btnQuitar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnQuitar.UseVisualStyleBackColor = False
        '
        'btnAgregar
        '
        Me.btnAgregar.BackColor = System.Drawing.Color.SteelBlue
        Me.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregar.Font = New System.Drawing.Font("Cooper Black", 20.25!)
        Me.btnAgregar.ForeColor = System.Drawing.Color.White
        Me.btnAgregar.Location = New System.Drawing.Point(771, 131)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(42, 41)
        Me.btnAgregar.TabIndex = 631
        Me.btnAgregar.Text = "+"
        Me.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btnAgregar.UseVisualStyleBackColor = False
        '
        'chHabilitarRutas
        '
        Me.chHabilitarRutas.AutoSize = True
        Me.chHabilitarRutas.Location = New System.Drawing.Point(223, 44)
        Me.chHabilitarRutas.Name = "chHabilitarRutas"
        Me.chHabilitarRutas.Size = New System.Drawing.Size(99, 25)
        Me.chHabilitarRutas.TabIndex = 630
        Me.chHabilitarRutas.Text = "Sub Rutas"
        Me.chHabilitarRutas.UseVisualStyleBackColor = True
        '
        'GBRuta
        '
        Me.GBRuta.Controls.Add(Me.btnAgregar)
        Me.GBRuta.Controls.Add(Me.btnQuitar)
        Me.GBRuta.Controls.Add(Me.txtRutaDestino)
        Me.GBRuta.Controls.Add(Me.txtRutaOrigen)
        Me.GBRuta.Controls.Add(Me.PictureBox3)
        Me.GBRuta.Controls.Add(Me.Label3)
        Me.GBRuta.Controls.Add(Me.PictureBox2)
        Me.GBRuta.Controls.Add(Me.PictureBox1)
        Me.GBRuta.Controls.Add(Me.Label5)
        Me.GBRuta.Controls.Add(Me.GridTotales)
        Me.GBRuta.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.GBRuta.ForeColor = System.Drawing.Color.Navy
        Me.GBRuta.Location = New System.Drawing.Point(8, 28)
        Me.GBRuta.Name = "GBRuta"
        Me.GBRuta.Size = New System.Drawing.Size(885, 467)
        Me.GBRuta.TabIndex = 629
        Me.GBRuta.TabStop = False
        Me.GBRuta.Text = "Sub Rutas"
        '
        'txtRutaDestino
        '
        Me.txtRutaDestino.BackColor = System.Drawing.Color.White
        Me.txtRutaDestino.BeforeTouchSize = New System.Drawing.Size(280, 24)
        Me.txtRutaDestino.BorderColor = System.Drawing.Color.Silver
        Me.txtRutaDestino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRutaDestino.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRutaDestino.CornerRadius = 4
        Me.txtRutaDestino.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtRutaDestino.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRutaDestino.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtRutaDestino.Location = New System.Drawing.Point(581, 88)
        Me.txtRutaDestino.Metrocolor = System.Drawing.Color.White
        Me.txtRutaDestino.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtRutaDestino.Name = "txtRutaDestino"
        Me.txtRutaDestino.Size = New System.Drawing.Size(280, 24)
        Me.txtRutaDestino.TabIndex = 633
        '
        'txtRutaOrigen
        '
        Me.txtRutaOrigen.BackColor = System.Drawing.Color.White
        Me.txtRutaOrigen.BeforeTouchSize = New System.Drawing.Size(280, 24)
        Me.txtRutaOrigen.BorderColor = System.Drawing.Color.Silver
        Me.txtRutaOrigen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRutaOrigen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRutaOrigen.CornerRadius = 4
        Me.txtRutaOrigen.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtRutaOrigen.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRutaOrigen.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtRutaOrigen.Location = New System.Drawing.Point(26, 88)
        Me.txtRutaOrigen.Metrocolor = System.Drawing.Color.White
        Me.txtRutaOrigen.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtRutaOrigen.Name = "txtRutaOrigen"
        Me.txtRutaOrigen.Size = New System.Drawing.Size(280, 24)
        Me.txtRutaOrigen.TabIndex = 632
        '
        'PictureBox3
        '
        Me.PictureBox3.BackgroundImage = CType(resources.GetObject("PictureBox3.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(321, 64)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(247, 48)
        Me.PictureBox3.TabIndex = 630
        Me.PictureBox3.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(688, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 13)
        Me.Label3.TabIndex = 629
        Me.Label3.Text = "Ruta Destino"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Location = New System.Drawing.Point(700, 28)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(43, 41)
        Me.PictureBox2.TabIndex = 628
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(135, 28)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(43, 41)
        Me.PictureBox1.TabIndex = 627
        Me.PictureBox1.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(128, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 13)
        Me.Label5.TabIndex = 626
        Me.Label5.Text = "Ruta Origen"
        '
        'GridTotales
        '
        Me.GridTotales.ActivateCurrentCellBehavior = Syncfusion.Windows.Forms.Grid.GridCellActivateAction.SelectAll
        Me.GridTotales.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.GridTotales.BackColor = System.Drawing.SystemColors.Window
        Me.GridTotales.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.GridTotales.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.GridTotales.Location = New System.Drawing.Point(22, 178)
        Me.GridTotales.Name = "GridTotales"
        Me.GridTotales.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.GridTotales.Size = New System.Drawing.Size(839, 273)
        Me.GridTotales.TabIndex = 418
        Me.GridTotales.TableDescriptor.AllowNew = False
        GridColumnDescriptor1.MappingName = "ID"
        GridColumnDescriptor1.Name = "ID"
        GridColumnDescriptor1.Width = 0
        GridColumnDescriptor2.Appearance.AnyRecordFieldCell.CellType = "ComboBox"
        GridColumnDescriptor2.MappingName = "ORIGEN"
        GridColumnDescriptor2.Name = "ORIGEN"
        GridColumnDescriptor2.Width = 300
        GridColumnDescriptor3.Appearance.AnyRecordFieldCell.CellType = "ComboBox"
        GridColumnDescriptor3.MappingName = "DESTINO"
        GridColumnDescriptor3.Name = "DESTINO"
        GridColumnDescriptor3.Width = 300
        GridColumnDescriptor4.MappingName = "RECORRIDO"
        GridColumnDescriptor4.Name = "RECORRIDO"
        GridColumnDescriptor4.Width = 100
        GridColumnDescriptor5.Appearance.AnyRecordFieldCell.CellType = "CheckBox"
        GridColumnDescriptor5.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center
        GridColumnDescriptor5.MappingName = "MANUAL"
        GridColumnDescriptor5.Name = "MANUAL"
        GridColumnDescriptor5.Width = 80
        Me.GridTotales.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5})
        Me.GridTotales.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.GridTotales.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.GridTotales.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("ID"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("ORIGEN"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("DESTINO"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("RECORRIDO"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("MANUAL")})
        Me.GridTotales.TableOptions.GridLineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder()
        Me.GridTotales.TableOptions.ListBoxSelectionOutlineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.Transparent)
        Me.GridTotales.TableOptions.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.GridTotales.TableOptions.SelectionTextColor = System.Drawing.SystemColors.HighlightText
        Me.GridTotales.TableOptions.TreeLineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.White)
        Me.GridTotales.Text = "GridGroupingControl2"
        Me.GridTotales.TopLevelGroupOptions.IsExpandedInitialValue = True
        Me.GridTotales.TopLevelGroupOptions.RepaintCaptionWhenItemsChanged = True
        Me.GridTotales.TopLevelGroupOptions.ShowAddNewRecordAfterDetails = False
        Me.GridTotales.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = True
        Me.GridTotales.TopLevelGroupOptions.ShowCaption = False
        Me.GridTotales.TopLevelGroupOptions.ShowColumnHeaders = True
        Me.GridTotales.UseRightToLeftCompatibleTextBox = True
        Me.GridTotales.VersionInfo = "12.4400.0.24"
        Me.GridTotales.VerticalScrollTips = True
        Me.GridTotales.WantTabKey = False
        '
        'bgCombos
        '
        Me.bgCombos.WorkerSupportsCancellation = True
        '
        'tabSubRutas
        '
        Me.tabSubRutas.BackColor = System.Drawing.Color.White
        Me.tabSubRutas.Controls.Add(Me.GBRuta)
        Me.tabSubRutas.ForeColor = System.Drawing.SystemColors.ControlText
        Me.tabSubRutas.Image = Nothing
        Me.tabSubRutas.ImageSize = New System.Drawing.Size(16, 16)
        Me.tabSubRutas.Location = New System.Drawing.Point(1, 27)
        Me.tabSubRutas.Name = "tabSubRutas"
        Me.tabSubRutas.ShowCloseButton = True
        Me.tabSubRutas.Size = New System.Drawing.Size(907, 511)
        Me.tabSubRutas.TabIndex = 2
        Me.tabSubRutas.TabVisible = False
        Me.tabSubRutas.Text = "SUB RUTAS"
        Me.tabSubRutas.ThemesEnabled = False
        '
        'TabPageAdv1
        '
        Me.TabPageAdv1.BackColor = System.Drawing.Color.White
        Me.TabPageAdv1.Controls.Add(Me.PictureBox4)
        Me.TabPageAdv1.Controls.Add(Me.GroupBox1)
        Me.TabPageAdv1.Controls.Add(Me.GBOrigen)
        Me.TabPageAdv1.Controls.Add(Me.GBDestino)
        Me.TabPageAdv1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TabPageAdv1.Image = Nothing
        Me.TabPageAdv1.ImageSize = New System.Drawing.Size(16, 16)
        Me.TabPageAdv1.Location = New System.Drawing.Point(1, 27)
        Me.TabPageAdv1.Name = "TabPageAdv1"
        Me.TabPageAdv1.ShowCloseButton = True
        Me.TabPageAdv1.Size = New System.Drawing.Size(907, 511)
        Me.TabPageAdv1.TabBackColor = System.Drawing.Color.White
        Me.TabPageAdv1.TabIndex = 1
        Me.TabPageAdv1.Text = "RUTA PRINCIPAL"
        Me.TabPageAdv1.ThemesEnabled = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(587, 15)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(307, 457)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 623
        Me.PictureBox4.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.chHabilitarRutas)
        Me.GroupBox1.Controls.Add(Me.TextBoxExt1)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(8, 380)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(573, 92)
        Me.GroupBox1.TabIndex = 622
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos Generales"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(220, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 13)
        Me.Label7.TabIndex = 632
        Me.Label7.Text = "Habilitar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(24, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 620
        Me.Label1.Text = "Recorrido (KM)"
        '
        'TextBoxExt1
        '
        Me.TextBoxExt1.BackColor = System.Drawing.Color.White
        Me.TextBoxExt1.BeforeTouchSize = New System.Drawing.Size(280, 24)
        Me.TextBoxExt1.BorderColor = System.Drawing.Color.Silver
        Me.TextBoxExt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxExt1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBoxExt1.CornerRadius = 4
        Me.TextBoxExt1.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextBoxExt1.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxExt1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextBoxExt1.Location = New System.Drawing.Point(27, 44)
        Me.TextBoxExt1.Metrocolor = System.Drawing.Color.White
        Me.TextBoxExt1.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextBoxExt1.Name = "TextBoxExt1"
        Me.TextBoxExt1.Size = New System.Drawing.Size(168, 24)
        Me.TextBoxExt1.TabIndex = 621
        '
        'TabControlAdv1
        '
        Me.TabControlAdv1.ActiveTabForeColor = System.Drawing.Color.Empty
        Me.TabControlAdv1.BeforeTouchSize = New System.Drawing.Size(910, 540)
        Me.TabControlAdv1.CloseButtonForeColor = System.Drawing.Color.Empty
        Me.TabControlAdv1.CloseButtonHoverForeColor = System.Drawing.Color.Empty
        Me.TabControlAdv1.CloseButtonPressedForeColor = System.Drawing.Color.Empty
        Me.TabControlAdv1.Controls.Add(Me.TabPageAdv1)
        Me.TabControlAdv1.Controls.Add(Me.tabSubRutas)
        Me.TabControlAdv1.FocusOnTabClick = False
        Me.TabControlAdv1.InActiveTabForeColor = System.Drawing.Color.Empty
        Me.TabControlAdv1.Location = New System.Drawing.Point(20, 3)
        Me.TabControlAdv1.Name = "TabControlAdv1"
        Me.TabControlAdv1.SeparatorColor = System.Drawing.SystemColors.ControlDark
        Me.TabControlAdv1.ShowSeparator = False
        Me.TabControlAdv1.Size = New System.Drawing.Size(910, 540)
        Me.TabControlAdv1.TabIndex = 633
        Me.TabControlAdv1.TabStyle = GetType(Syncfusion.Windows.Forms.Tools.TabRendererVS2010)
        '
        'FormCrearRuta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.SystemColors.Highlight
        Me.BorderThickness = 2
        Me.CaptionBarHeight = 50
        Me.CaptionForeColor = System.Drawing.Color.White
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.ForeColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(30, 7)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(35, 35)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.CornflowerBlue
        CaptionLabel1.Location = New System.Drawing.Point(70, 12)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(300, 24)
        CaptionLabel1.Text = "Crear Rutas"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(942, 587)
        Me.Controls.Add(Me.TabControlAdv1)
        Me.Controls.Add(Me.RoundButton21)
        Me.Controls.Add(Me.BtGrabar)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormCrearRuta"
        Me.ShowIcon = False
        Me.Text = " Crear Ruta"
        CType(Me.TextCodigoRuta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TexDomicilioOrigen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TexDomicilioDestino, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBDestino.ResumeLayout(False)
        Me.GBDestino.PerformLayout()
        CType(Me.txtProvinciaDestino, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRegionDestino, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCiudadDestino, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboAgenciaDestino, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBOrigen.ResumeLayout(False)
        Me.GBOrigen.PerformLayout()
        CType(Me.txtProvinciaOrigen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRegionOrigen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDistritoOrigen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboAgenciaOrigen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBRuta.ResumeLayout(False)
        Me.GBRuta.PerformLayout()
        CType(Me.txtRutaDestino, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRutaOrigen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridTotales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabSubRutas.ResumeLayout(False)
        Me.TabPageAdv1.ResumeLayout(False)
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.TextBoxExt1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabControlAdv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlAdv1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label14 As Label
    Friend WithEvents TextCodigoRuta As Tools.TextBoxExt
    Friend WithEvents Label2 As Label
    Friend WithEvents BtGrabar As RoundButton2
    Friend WithEvents TexDomicilioOrigen As Tools.TextBoxExt
    Friend WithEvents TexDomicilioDestino As Tools.TextBoxExt
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents GBDestino As GroupBox
    Friend WithEvents ComboAgenciaDestino As Tools.ComboBoxAdv
    Friend WithEvents GBOrigen As GroupBox
    Friend WithEvents ComboAgenciaOrigen As Tools.ComboBoxAdv
    Friend WithEvents Label33 As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents RoundButton21 As RoundButton2
    Friend WithEvents txtProvinciaDestino As Tools.TextBoxExt
    Friend WithEvents txtRegionDestino As Tools.TextBoxExt
    Friend WithEvents txtCiudadDestino As Tools.TextBoxExt
    Friend WithEvents txtProvinciaOrigen As Tools.TextBoxExt
    Friend WithEvents txtRegionOrigen As Tools.TextBoxExt
    Friend WithEvents txtDistritoOrigen As Tools.TextBoxExt
    Friend WithEvents btnQuitar As Button
    Friend WithEvents btnAgregar As Button
    Friend WithEvents chHabilitarRutas As CheckBox
    Friend WithEvents GBRuta As GroupBox
    Friend WithEvents GridTotales As Grid.Grouping.GridGroupingControl
    Friend WithEvents bgCombos As System.ComponentModel.BackgroundWorker
    Friend WithEvents TabControlAdv1 As Tools.TabControlAdv
    Friend WithEvents TabPageAdv1 As Tools.TabPageAdv
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBoxExt1 As Tools.TextBoxExt
    Friend WithEvents tabSubRutas As Tools.TabPageAdv
    Friend WithEvents txtRutaDestino As Tools.TextBoxExt
    Friend WithEvents txtRutaOrigen As Tools.TextBoxExt
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents PictureBox4 As PictureBox
End Class

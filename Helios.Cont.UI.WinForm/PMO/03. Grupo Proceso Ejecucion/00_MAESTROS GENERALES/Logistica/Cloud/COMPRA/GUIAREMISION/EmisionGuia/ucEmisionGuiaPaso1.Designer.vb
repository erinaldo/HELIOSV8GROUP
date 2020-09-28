<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucEmisionGuiaPaso1
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucEmisionGuiaPaso1))
        Dim ActiveStateCollection1 As Syncfusion.Windows.Forms.Tools.ActiveStateCollection = New Syncfusion.Windows.Forms.Tools.ActiveStateCollection()
        Dim InactiveStateCollection1 As Syncfusion.Windows.Forms.Tools.InactiveStateCollection = New Syncfusion.Windows.Forms.Tools.InactiveStateCollection()
        Dim Office2016DarkGrayToggleButtonRenderer1 As Syncfusion.Windows.Forms.Tools.Office2016DarkGrayToggleButtonRenderer = New Syncfusion.Windows.Forms.Tools.Office2016DarkGrayToggleButtonRenderer()
        Dim SliderCollection1 As Syncfusion.Windows.Forms.Tools.SliderCollection = New Syncfusion.Windows.Forms.Tools.SliderCollection()
        Me.textDescripcionTraslado = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.label18 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextNumDocRemitente = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.comboRemitente = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.TextRemitente = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbomotivotrasl = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.TextNumeracionDam = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ComboDocDestinatario = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.TextNumDocDestinatario = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextDestinatario = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.BannerTextProvider1 = New Syncfusion.Windows.Forms.BannerTextProvider(Me.components)
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ComboTipoTransporte = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ToggleButton1 = New Syncfusion.Windows.Forms.Tools.ToggleButton()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cbOtroDocRelac = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TextNroDocRelacionados = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.BunifuFlatButton4 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.sfButton1 = New Syncfusion.WinForms.Controls.SfButton()
        Me.SfButton2 = New Syncfusion.WinForms.Controls.SfButton()
        Me.ToggleConsultas = New Helios.Cont.Presentation.WinForm.ToggleButton2()
        Me.BgProveedor = New System.ComponentModel.BackgroundWorker()
        Me.ListOtrosDoc = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.textDescripcionTraslado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextNumDocRemitente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.comboRemitente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextRemitente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbomotivotrasl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextNumeracionDam, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboDocDestinatario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextNumDocDestinatario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextDestinatario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboTipoTransporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ToggleButton1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbOtroDocRelac, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextNroDocRelacionados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'textDescripcionTraslado
        '
        Me.textDescripcionTraslado.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.textDescripcionTraslado.BeforeTouchSize = New System.Drawing.Size(410, 48)
        Me.textDescripcionTraslado.BorderColor = System.Drawing.Color.DimGray
        Me.textDescripcionTraslado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.textDescripcionTraslado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textDescripcionTraslado.CornerRadius = 4
        Me.textDescripcionTraslado.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.textDescripcionTraslado.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textDescripcionTraslado.ForeColor = System.Drawing.Color.White
        Me.textDescripcionTraslado.Location = New System.Drawing.Point(323, 128)
        Me.textDescripcionTraslado.MaxLength = 100
        Me.textDescripcionTraslado.Metrocolor = System.Drawing.Color.LightGray
        Me.textDescripcionTraslado.MinimumSize = New System.Drawing.Size(14, 10)
        Me.textDescripcionTraslado.Name = "textDescripcionTraslado"
        Me.textDescripcionTraslado.NearImage = CType(resources.GetObject("textDescripcionTraslado.NearImage"), System.Drawing.Image)
        Me.textDescripcionTraslado.Size = New System.Drawing.Size(368, 22)
        Me.textDescripcionTraslado.TabIndex = 822
        '
        'label18
        '
        Me.label18.BackColor = System.Drawing.Color.SeaGreen
        Me.label18.Font = New System.Drawing.Font("Yu Gothic UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label18.ForeColor = System.Drawing.Color.White
        Me.label18.Location = New System.Drawing.Point(3, 16)
        Me.label18.Name = "label18"
        Me.label18.Size = New System.Drawing.Size(120, 17)
        Me.label18.TabIndex = 821
        Me.label18.Text = "EMISIÓN DE GUÍA"
        Me.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(29, 46)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(263, 13)
        Me.Label8.TabIndex = 823
        Me.Label8.Text = "TIPO Y NUMERO DE DOCUMENTO DEL REMITENTE"
        '
        'TextNumDocRemitente
        '
        Me.TextNumDocRemitente.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TextNumDocRemitente.BeforeTouchSize = New System.Drawing.Size(410, 48)
        Me.TextNumDocRemitente.BorderColor = System.Drawing.Color.DimGray
        Me.TextNumDocRemitente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextNumDocRemitente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNumDocRemitente.CornerRadius = 4
        Me.TextNumDocRemitente.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextNumDocRemitente.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNumDocRemitente.ForeColor = System.Drawing.Color.White
        Me.TextNumDocRemitente.Location = New System.Drawing.Point(457, 37)
        Me.TextNumDocRemitente.MaxLength = 10
        Me.TextNumDocRemitente.Metrocolor = System.Drawing.Color.LightGray
        Me.TextNumDocRemitente.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextNumDocRemitente.Name = "TextNumDocRemitente"
        Me.TextNumDocRemitente.NearImage = CType(resources.GetObject("TextNumDocRemitente.NearImage"), System.Drawing.Image)
        Me.TextNumDocRemitente.ReadOnly = True
        Me.TextNumDocRemitente.Size = New System.Drawing.Size(234, 22)
        Me.TextNumDocRemitente.TabIndex = 825
        '
        'comboRemitente
        '
        Me.comboRemitente.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.comboRemitente.BeforeTouchSize = New System.Drawing.Size(130, 21)
        Me.comboRemitente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboRemitente.Enabled = False
        Me.comboRemitente.Items.AddRange(New Object() {"RUC", "CARNET EXTRANJERIA", "DNI"})
        Me.comboRemitente.Location = New System.Drawing.Point(323, 38)
        Me.comboRemitente.MaxLength = 50
        Me.comboRemitente.Name = "comboRemitente"
        Me.comboRemitente.Size = New System.Drawing.Size(130, 21)
        Me.comboRemitente.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Black
        Me.comboRemitente.TabIndex = 826
        Me.comboRemitente.Text = "RUC"
        '
        'TextRemitente
        '
        Me.TextRemitente.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TextRemitente.BeforeTouchSize = New System.Drawing.Size(410, 48)
        Me.TextRemitente.BorderColor = System.Drawing.Color.DimGray
        Me.TextRemitente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextRemitente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextRemitente.CornerRadius = 4
        Me.TextRemitente.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextRemitente.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextRemitente.ForeColor = System.Drawing.Color.White
        Me.TextRemitente.Location = New System.Drawing.Point(323, 65)
        Me.TextRemitente.MaxLength = 10
        Me.TextRemitente.Metrocolor = System.Drawing.Color.LightGray
        Me.TextRemitente.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextRemitente.Name = "TextRemitente"
        Me.TextRemitente.NearImage = CType(resources.GetObject("TextRemitente.NearImage"), System.Drawing.Image)
        Me.TextRemitente.ReadOnly = True
        Me.TextRemitente.Size = New System.Drawing.Size(368, 22)
        Me.TextRemitente.TabIndex = 827
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(29, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(258, 13)
        Me.Label1.TabIndex = 828
        Me.Label1.Text = "APE. Y NOMBRES, RAZON SOCIAL DEL REMITENTE"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(29, 106)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(131, 13)
        Me.Label2.TabIndex = 829
        Me.Label2.Text = "MOTIVO DEL TRASLADO"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(29, 137)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(199, 13)
        Me.Label3.TabIndex = 830
        Me.Label3.Text = "DESCRIPCION MOTIVO DE TRASLADO"
        '
        'cbomotivotrasl
        '
        Me.cbomotivotrasl.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.cbomotivotrasl.BeforeTouchSize = New System.Drawing.Size(368, 21)
        Me.cbomotivotrasl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbomotivotrasl.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbomotivotrasl.Location = New System.Drawing.Point(323, 98)
        Me.cbomotivotrasl.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.cbomotivotrasl.MetroColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.cbomotivotrasl.Name = "cbomotivotrasl"
        Me.cbomotivotrasl.Size = New System.Drawing.Size(368, 21)
        Me.cbomotivotrasl.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Black
        Me.cbomotivotrasl.TabIndex = 844
        '
        'TextNumeracionDam
        '
        Me.TextNumeracionDam.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TextNumeracionDam.BeforeTouchSize = New System.Drawing.Size(410, 48)
        Me.TextNumeracionDam.BorderColor = System.Drawing.Color.DimGray
        Me.TextNumeracionDam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextNumeracionDam.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNumeracionDam.CornerRadius = 4
        Me.TextNumeracionDam.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextNumeracionDam.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNumeracionDam.ForeColor = System.Drawing.Color.White
        Me.TextNumeracionDam.Location = New System.Drawing.Point(323, 159)
        Me.TextNumeracionDam.MaxLength = 55
        Me.TextNumeracionDam.Metrocolor = System.Drawing.Color.LightGray
        Me.TextNumeracionDam.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextNumeracionDam.Name = "TextNumeracionDam"
        Me.TextNumeracionDam.NearImage = CType(resources.GetObject("TextNumeracionDam.NearImage"), System.Drawing.Image)
        Me.TextNumeracionDam.Size = New System.Drawing.Size(368, 22)
        Me.TextNumeracionDam.TabIndex = 845
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(29, 168)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(249, 13)
        Me.Label4.TabIndex = 846
        Me.Label4.Text = "NUMERACIÓN DAM. (###- ####- ##- ###### )"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(29, 201)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(279, 13)
        Me.Label5.TabIndex = 847
        Me.Label5.Text = "TIPO Y NUMERO DE DOCUMENTO DEL DESTINATARIO"
        '
        'ComboDocDestinatario
        '
        Me.ComboDocDestinatario.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.ComboDocDestinatario.BeforeTouchSize = New System.Drawing.Size(130, 21)
        Me.ComboDocDestinatario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboDocDestinatario.Items.AddRange(New Object() {"RUC", "CARNET EXTRANJERIA", "DNI"})
        Me.ComboDocDestinatario.Location = New System.Drawing.Point(323, 193)
        Me.ComboDocDestinatario.MaxLength = 50
        Me.ComboDocDestinatario.Name = "ComboDocDestinatario"
        Me.ComboDocDestinatario.Size = New System.Drawing.Size(130, 21)
        Me.ComboDocDestinatario.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Black
        Me.ComboDocDestinatario.TabIndex = 849
        Me.ComboDocDestinatario.Text = "RUC"
        '
        'TextNumDocDestinatario
        '
        Me.TextNumDocDestinatario.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TextNumDocDestinatario.BeforeTouchSize = New System.Drawing.Size(410, 48)
        Me.TextNumDocDestinatario.BorderColor = System.Drawing.Color.DimGray
        Me.TextNumDocDestinatario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextNumDocDestinatario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNumDocDestinatario.CornerRadius = 4
        Me.TextNumDocDestinatario.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextNumDocDestinatario.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNumDocDestinatario.ForeColor = System.Drawing.Color.White
        Me.TextNumDocDestinatario.Location = New System.Drawing.Point(457, 192)
        Me.TextNumDocDestinatario.MaxLength = 10
        Me.TextNumDocDestinatario.Metrocolor = System.Drawing.Color.LightGray
        Me.TextNumDocDestinatario.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextNumDocDestinatario.Name = "TextNumDocDestinatario"
        Me.TextNumDocDestinatario.NearImage = CType(resources.GetObject("TextNumDocDestinatario.NearImage"), System.Drawing.Image)
        Me.TextNumDocDestinatario.Size = New System.Drawing.Size(234, 22)
        Me.TextNumDocDestinatario.TabIndex = 848
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(29, 231)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(274, 13)
        Me.Label6.TabIndex = 850
        Me.Label6.Text = "APE. Y NOMBRES, RAZON SOCIAL DEL DESTINATARIO"
        '
        'TextDestinatario
        '
        Me.TextDestinatario.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TextDestinatario.BeforeTouchSize = New System.Drawing.Size(410, 48)
        Me.TextDestinatario.BorderColor = System.Drawing.Color.DimGray
        Me.TextDestinatario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextDestinatario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextDestinatario.CornerRadius = 4
        Me.TextDestinatario.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextDestinatario.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextDestinatario.ForeColor = System.Drawing.Color.White
        Me.TextDestinatario.Location = New System.Drawing.Point(323, 222)
        Me.TextDestinatario.MaxLength = 10
        Me.TextDestinatario.Metrocolor = System.Drawing.Color.LightGray
        Me.TextDestinatario.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextDestinatario.Name = "TextDestinatario"
        Me.TextDestinatario.NearImage = CType(resources.GetObject("TextDestinatario.NearImage"), System.Drawing.Image)
        Me.TextDestinatario.ReadOnly = True
        Me.TextDestinatario.Size = New System.Drawing.Size(368, 22)
        Me.TextDestinatario.TabIndex = 851
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(29, 263)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(119, 13)
        Me.Label7.TabIndex = 852
        Me.Label7.Text = "TIPO DE TRANSPORTE"
        '
        'ComboTipoTransporte
        '
        Me.ComboTipoTransporte.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.ComboTipoTransporte.BeforeTouchSize = New System.Drawing.Size(212, 21)
        Me.ComboTipoTransporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboTipoTransporte.Items.AddRange(New Object() {"PRIVADO", "PUBLICO"})
        Me.ComboTipoTransporte.Location = New System.Drawing.Point(323, 255)
        Me.ComboTipoTransporte.MaxLength = 50
        Me.ComboTipoTransporte.Name = "ComboTipoTransporte"
        Me.ComboTipoTransporte.Size = New System.Drawing.Size(212, 21)
        Me.ComboTipoTransporte.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Black
        Me.ComboTipoTransporte.TabIndex = 853
        Me.ComboTipoTransporte.Text = "PRIVADO"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(29, 292)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(172, 13)
        Me.Label9.TabIndex = 854
        Me.Label9.Text = "MULTIPLES PUNTOS DE DESTINO"
        '
        'ToggleButton1
        '
        ActiveStateCollection1.BackColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(199, Byte), Integer))
        ActiveStateCollection1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(199, Byte), Integer))
        ActiveStateCollection1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        ActiveStateCollection1.HoverColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.ToggleButton1.ActiveState = ActiveStateCollection1
        Me.ToggleButton1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToggleButton1.ForeColor = System.Drawing.Color.Black
        InactiveStateCollection1.BackColor = System.Drawing.Color.FromArgb(CType(CType(178, Byte), Integer), CType(CType(178, Byte), Integer), CType(CType(178, Byte), Integer))
        InactiveStateCollection1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        InactiveStateCollection1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        InactiveStateCollection1.HoverColor = System.Drawing.Color.FromArgb(CType(CType(178, Byte), Integer), CType(CType(178, Byte), Integer), CType(CType(178, Byte), Integer))
        Me.ToggleButton1.InactiveState = InactiveStateCollection1
        Me.ToggleButton1.Location = New System.Drawing.Point(323, 285)
        Me.ToggleButton1.MinimumSize = New System.Drawing.Size(52, 20)
        Me.ToggleButton1.Name = "ToggleButton1"
        Me.ToggleButton1.Renderer = Office2016DarkGrayToggleButtonRenderer1
        Me.ToggleButton1.Size = New System.Drawing.Size(90, 20)
        SliderCollection1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        SliderCollection1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer))
        SliderCollection1.HoverColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        SliderCollection1.InactiveBackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        SliderCollection1.InactiveHoverColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.ToggleButton1.Slider = SliderCollection1
        Me.ToggleButton1.TabIndex = 855
        Me.ToggleButton1.Text = "ToggleButton1"
        Me.ToggleButton1.VisualStyle = Syncfusion.Windows.Forms.Tools.ToggleButtonStyle.Office2016DarkGray
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Label10.Font = New System.Drawing.Font("Yu Gothic UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(3, 318)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(289, 17)
        Me.Label10.TabIndex = 856
        Me.Label10.Text = "OTROS DOCUMENTOS RELACIONADOS"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbOtroDocRelac
        '
        Me.cbOtroDocRelac.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.cbOtroDocRelac.BeforeTouchSize = New System.Drawing.Size(260, 21)
        Me.cbOtroDocRelac.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbOtroDocRelac.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbOtroDocRelac.Location = New System.Drawing.Point(32, 367)
        Me.cbOtroDocRelac.Name = "cbOtroDocRelac"
        Me.cbOtroDocRelac.Size = New System.Drawing.Size(260, 21)
        Me.cbOtroDocRelac.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Black
        Me.cbOtroDocRelac.TabIndex = 858
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(29, 347)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(137, 13)
        Me.Label11.TabIndex = 859
        Me.Label11.Text = "TIPO Y NÚMERO DE DOC."
        '
        'TextNroDocRelacionados
        '
        Me.TextNroDocRelacionados.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TextNroDocRelacionados.BeforeTouchSize = New System.Drawing.Size(410, 48)
        Me.TextNroDocRelacionados.BorderColor = System.Drawing.Color.DimGray
        Me.TextNroDocRelacionados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextNroDocRelacionados.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNroDocRelacionados.CornerRadius = 4
        Me.TextNroDocRelacionados.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextNroDocRelacionados.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNroDocRelacionados.ForeColor = System.Drawing.Color.White
        Me.TextNroDocRelacionados.Location = New System.Drawing.Point(32, 396)
        Me.TextNroDocRelacionados.MaxLength = 10
        Me.TextNroDocRelacionados.Metrocolor = System.Drawing.Color.LightGray
        Me.TextNroDocRelacionados.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextNroDocRelacionados.Name = "TextNroDocRelacionados"
        Me.TextNroDocRelacionados.NearImage = CType(resources.GetObject("TextNroDocRelacionados.NearImage"), System.Drawing.Image)
        Me.TextNroDocRelacionados.Size = New System.Drawing.Size(209, 22)
        Me.TextNroDocRelacionados.TabIndex = 860
        '
        'BunifuFlatButton4
        '
        Me.BunifuFlatButton4.Activecolor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.BunifuFlatButton4.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.BunifuFlatButton4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton4.BorderRadius = 5
        Me.BunifuFlatButton4.ButtonText = "+"
        Me.BunifuFlatButton4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton4.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton4.Font = New System.Drawing.Font("Segoe UI", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BunifuFlatButton4.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton4.Iconimage = Nothing
        Me.BunifuFlatButton4.Iconimage_right = Nothing
        Me.BunifuFlatButton4.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton4.Iconimage_Selected = Nothing
        Me.BunifuFlatButton4.IconMarginLeft = 0
        Me.BunifuFlatButton4.IconMarginRight = 0
        Me.BunifuFlatButton4.IconRightVisible = True
        Me.BunifuFlatButton4.IconRightZoom = 0R
        Me.BunifuFlatButton4.IconVisible = True
        Me.BunifuFlatButton4.IconZoom = 90.0R
        Me.BunifuFlatButton4.IsTab = False
        Me.BunifuFlatButton4.Location = New System.Drawing.Point(246, 395)
        Me.BunifuFlatButton4.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton4.Name = "BunifuFlatButton4"
        Me.BunifuFlatButton4.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.BunifuFlatButton4.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.BunifuFlatButton4.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton4.selected = False
        Me.BunifuFlatButton4.Size = New System.Drawing.Size(46, 23)
        Me.BunifuFlatButton4.TabIndex = 861
        Me.BunifuFlatButton4.Text = "+"
        Me.BunifuFlatButton4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton4.Textcolor = System.Drawing.Color.White
        Me.BunifuFlatButton4.TextFont = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'sfButton1
        '
        Me.sfButton1.AccessibleName = "Button"
        Me.sfButton1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.sfButton1.Location = New System.Drawing.Point(321, 452)
        Me.sfButton1.Name = "sfButton1"
        Me.sfButton1.Size = New System.Drawing.Size(127, 31)
        Me.sfButton1.Style.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.sfButton1.Style.DisabledBackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.sfButton1.Style.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.sfButton1.Style.FocusedBackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.sfButton1.Style.FocusedForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.sfButton1.Style.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.sfButton1.Style.HoverBackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.sfButton1.Style.PressedBackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.sfButton1.Style.PressedForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.sfButton1.TabIndex = 862
        Me.sfButton1.Text = "CONTINUAR"
        '
        'SfButton2
        '
        Me.SfButton2.AccessibleName = "Button"
        Me.SfButton2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.SfButton2.ForeColor = System.Drawing.Color.LightCoral
        Me.SfButton2.Location = New System.Drawing.Point(454, 452)
        Me.SfButton2.Name = "SfButton2"
        Me.SfButton2.Size = New System.Drawing.Size(127, 31)
        Me.SfButton2.Style.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.SfButton2.Style.DisabledBackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.SfButton2.Style.DisabledForeColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.SfButton2.Style.FocusedBackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.SfButton2.Style.FocusedForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.SfButton2.Style.ForeColor = System.Drawing.Color.LightCoral
        Me.SfButton2.Style.HoverBackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.SfButton2.Style.PressedBackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.SfButton2.Style.PressedForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.SfButton2.TabIndex = 863
        Me.SfButton2.Text = "CANCELAR"
        '
        'ToggleConsultas
        '
        Me.ToggleConsultas.ActiveColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.ToggleConsultas.ActiveText = "Web"
        Me.ToggleConsultas.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.ToggleConsultas.InActiveColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.ToggleConsultas.InActiveText = "API"
        Me.ToggleConsultas.Location = New System.Drawing.Point(541, 255)
        Me.ToggleConsultas.MaximumSize = New System.Drawing.Size(119, 32)
        Me.ToggleConsultas.MinimumSize = New System.Drawing.Size(75, 23)
        Me.ToggleConsultas.Name = "ToggleConsultas"
        Me.ToggleConsultas.Size = New System.Drawing.Size(76, 23)
        Me.ToggleConsultas.SliderColor = System.Drawing.Color.Black
        Me.ToggleConsultas.SlidingAngle = 8
        Me.ToggleConsultas.TabIndex = 864
        Me.ToggleConsultas.Text = "ToggleButton21"
        Me.ToggleConsultas.TextColor = System.Drawing.Color.White
        Me.ToggleConsultas.ToggleState = Helios.Cont.Presentation.WinForm.ToggleButton2.ToggleButtonState.OFF
        Me.ToggleConsultas.ToggleStyle = Helios.Cont.Presentation.WinForm.ToggleButton2.ToggleButtonStyle.Android
        Me.ToggleConsultas.Visible = False
        '
        'BgProveedor
        '
        Me.BgProveedor.WorkerSupportsCancellation = True
        '
        'ListOtrosDoc
        '
        Me.ListOtrosDoc.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.ListOtrosDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListOtrosDoc.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.ListOtrosDoc.ForeColor = System.Drawing.Color.White
        Me.ListOtrosDoc.FullRowSelect = True
        Me.ListOtrosDoc.HideSelection = False
        Me.ListOtrosDoc.Location = New System.Drawing.Point(323, 337)
        Me.ListOtrosDoc.Name = "ListOtrosDoc"
        Me.ListOtrosDoc.Size = New System.Drawing.Size(368, 81)
        Me.ListOtrosDoc.TabIndex = 865
        Me.ListOtrosDoc.UseCompatibleStateImageBehavior = False
        Me.ListOtrosDoc.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        Me.ColumnHeader1.Width = 88
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Número"
        Me.ColumnHeader2.Width = 118
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "cod"
        Me.ColumnHeader3.Width = 0
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'ucEmisionGuiaPaso1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.Controls.Add(Me.ListOtrosDoc)
        Me.Controls.Add(Me.ToggleConsultas)
        Me.Controls.Add(Me.SfButton2)
        Me.Controls.Add(Me.sfButton1)
        Me.Controls.Add(Me.BunifuFlatButton4)
        Me.Controls.Add(Me.TextNroDocRelacionados)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.cbOtroDocRelac)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.ToggleButton1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.ComboTipoTransporte)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TextDestinatario)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ComboDocDestinatario)
        Me.Controls.Add(Me.TextNumDocDestinatario)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextNumeracionDam)
        Me.Controls.Add(Me.cbomotivotrasl)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextRemitente)
        Me.Controls.Add(Me.comboRemitente)
        Me.Controls.Add(Me.TextNumDocRemitente)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.textDescripcionTraslado)
        Me.Controls.Add(Me.label18)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ucEmisionGuiaPaso1"
        Me.Size = New System.Drawing.Size(911, 497)
        CType(Me.textDescripcionTraslado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextNumDocRemitente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.comboRemitente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextRemitente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbomotivotrasl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextNumeracionDam, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboDocDestinatario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextNumDocDestinatario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextDestinatario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboTipoTransporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ToggleButton1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbOtroDocRelac, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextNroDocRelacionados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents textDescripcionTraslado As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Private WithEvents label18 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents TextNumDocRemitente As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Public WithEvents comboRemitente As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents TextRemitente As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cbomotivotrasl As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents TextNumeracionDam As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Public WithEvents ComboDocDestinatario As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents TextNumDocDestinatario As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label6 As Label
    Friend WithEvents TextDestinatario As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents BannerTextProvider1 As Syncfusion.Windows.Forms.BannerTextProvider
    Friend WithEvents Label7 As Label
    Public WithEvents ComboTipoTransporte As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label9 As Label
    Friend WithEvents ToggleButton1 As Syncfusion.Windows.Forms.Tools.ToggleButton
    Private WithEvents Label10 As Label
    Friend WithEvents cbOtroDocRelac As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label11 As Label
    Friend WithEvents TextNroDocRelacionados As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Private WithEvents BunifuFlatButton4 As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents sfButton1 As Syncfusion.WinForms.Controls.SfButton
    Private WithEvents SfButton2 As Syncfusion.WinForms.Controls.SfButton
    Friend WithEvents ToggleConsultas As ToggleButton2
    Friend WithEvents BgProveedor As System.ComponentModel.BackgroundWorker
    Friend WithEvents ListOtrosDoc As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ErrorProvider1 As ErrorProvider
End Class

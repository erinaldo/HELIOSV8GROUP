<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPagoEgreso
    Inherits Syncfusion.Windows.Forms.MetroForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPagoEgreso))
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"1", "JIUNI PALACIOS SANTOS", "44924569"}, -1)
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.RoundButton21 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.TextGlosa = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ToggleConsultas = New Helios.Cont.Presentation.WinForm.ToggleButton2()
        Me.PictureLoad = New System.Windows.Forms.PictureBox()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Chentregado = New System.Windows.Forms.CheckBox()
        Me.RBCPlanilla = New System.Windows.Forms.RadioButton()
        Me.RBOtros = New System.Windows.Forms.RadioButton()
        Me.RBProveedor = New System.Windows.Forms.RadioButton()
        Me.RBCliente = New System.Windows.Forms.RadioButton()
        Me.TextDNI = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextPersona = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.cboFormaPago = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.txtNumOper = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TextBoxExt1 = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtComprobante = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TxtDia = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.cboMesCompra = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.txtHora = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.txtAnioCompra = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtCF_tipo = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.SaldoEFMN = New Syncfusion.Windows.Forms.Tools.DoubleTextBox()
        Me.SaldoEFME = New Syncfusion.Windows.Forms.Tools.DoubleTextBox()
        Me.txtCF_name = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtCF_cuentaContable = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtCF_moneda = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.PopupControlContainer4 = New Syncfusion.Windows.Forms.PopupControlContainer()
        Me.lsvProveedor = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colRUC = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.txtFondoME = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.txtTipoCambio = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.txtFondoMN = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.BgProveedor = New System.ComponentModel.BackgroundWorker()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.TextGlosa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PictureLoad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextDNI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextPersona, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.cboFormaPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumOper, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.TextBoxExt1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboMesCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAnioCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtCF_tipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SaldoEFMN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SaldoEFME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCF_name, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCF_cuentaContable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCF_moneda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PopupControlContainer4.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.txtFondoME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoCambio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFondoMN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'RoundButton21
        '
        Me.RoundButton21.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton21.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.RoundButton21.BeforeTouchSize = New System.Drawing.Size(110, 37)
        Me.RoundButton21.Font = New System.Drawing.Font("Calibri Light", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundButton21.ForeColor = System.Drawing.Color.White
        Me.RoundButton21.Image = CType(resources.GetObject("RoundButton21.Image"), System.Drawing.Image)
        Me.RoundButton21.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.RoundButton21.IsBackStageButton = False
        Me.RoundButton21.Location = New System.Drawing.Point(293, 406)
        Me.RoundButton21.MetroColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.RoundButton21.Name = "RoundButton21"
        Me.RoundButton21.Size = New System.Drawing.Size(110, 37)
        Me.RoundButton21.TabIndex = 639
        Me.RoundButton21.Text = "       Grabar"
        Me.RoundButton21.UseVisualStyle = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.TextGlosa)
        Me.GroupBox4.Location = New System.Drawing.Point(22, 325)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(645, 70)
        Me.GroupBox4.TabIndex = 638
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Glosa, detalle motivo"
        '
        'TextGlosa
        '
        Me.TextGlosa.BackColor = System.Drawing.Color.White
        Me.TextGlosa.BeforeTouchSize = New System.Drawing.Size(102, 22)
        Me.TextGlosa.BorderColor = System.Drawing.Color.Silver
        Me.TextGlosa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextGlosa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextGlosa.CornerRadius = 4
        Me.TextGlosa.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextGlosa.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextGlosa.Location = New System.Drawing.Point(19, 21)
        Me.TextGlosa.Metrocolor = System.Drawing.Color.Silver
        Me.TextGlosa.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextGlosa.Multiline = True
        Me.TextGlosa.Name = "TextGlosa"
        Me.TextGlosa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextGlosa.Size = New System.Drawing.Size(579, 37)
        Me.TextGlosa.TabIndex = 402
        Me.TextGlosa.Text = "OTROS GASTOS DE CAJA"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ToggleConsultas)
        Me.GroupBox3.Controls.Add(Me.PictureLoad)
        Me.GroupBox3.Controls.Add(Me.RadioButton1)
        Me.GroupBox3.Controls.Add(Me.Chentregado)
        Me.GroupBox3.Controls.Add(Me.RBCPlanilla)
        Me.GroupBox3.Controls.Add(Me.RBOtros)
        Me.GroupBox3.Controls.Add(Me.RBProveedor)
        Me.GroupBox3.Controls.Add(Me.RBCliente)
        Me.GroupBox3.Controls.Add(Me.TextDNI)
        Me.GroupBox3.Controls.Add(Me.TextPersona)
        Me.GroupBox3.Location = New System.Drawing.Point(22, 239)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(645, 81)
        Me.GroupBox3.TabIndex = 637
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Persona encargada de la recepción o entrega del dinero"
        '
        'ToggleConsultas
        '
        Me.ToggleConsultas.ActiveColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.ToggleConsultas.ActiveText = "Web"
        Me.ToggleConsultas.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.ToggleConsultas.InActiveColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.ToggleConsultas.InActiveText = "API"
        Me.ToggleConsultas.Location = New System.Drawing.Point(322, 21)
        Me.ToggleConsultas.MaximumSize = New System.Drawing.Size(119, 32)
        Me.ToggleConsultas.MinimumSize = New System.Drawing.Size(75, 23)
        Me.ToggleConsultas.Name = "ToggleConsultas"
        Me.ToggleConsultas.Size = New System.Drawing.Size(76, 23)
        Me.ToggleConsultas.SliderColor = System.Drawing.Color.Black
        Me.ToggleConsultas.SlidingAngle = 8
        Me.ToggleConsultas.TabIndex = 696
        Me.ToggleConsultas.Text = "ToggleButton21"
        Me.ToggleConsultas.TextColor = System.Drawing.Color.White
        Me.ToggleConsultas.ToggleState = Helios.Cont.Presentation.WinForm.ToggleButton2.ToggleButtonState.OFF
        Me.ToggleConsultas.ToggleStyle = Helios.Cont.Presentation.WinForm.ToggleButton2.ToggleButtonStyle.Android
        '
        'PictureLoad
        '
        Me.PictureLoad.BackColor = System.Drawing.Color.Transparent
        Me.PictureLoad.Image = CType(resources.GetObject("PictureLoad.Image"), System.Drawing.Image)
        Me.PictureLoad.Location = New System.Drawing.Point(438, 50)
        Me.PictureLoad.Name = "PictureLoad"
        Me.PictureLoad.Size = New System.Drawing.Size(22, 21)
        Me.PictureLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureLoad.TabIndex = 686
        Me.PictureLoad.TabStop = False
        Me.PictureLoad.Visible = False
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.RadioButton1.Location = New System.Drawing.Point(234, 26)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(55, 18)
        Me.RadioButton1.TabIndex = 412
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Varios"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'Chentregado
        '
        Me.Chentregado.AutoSize = True
        Me.Chentregado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.Chentregado.Location = New System.Drawing.Point(518, 54)
        Me.Chentregado.Name = "Chentregado"
        Me.Chentregado.Size = New System.Drawing.Size(111, 18)
        Me.Chentregado.TabIndex = 410
        Me.Chentregado.Text = "Dinero entregado"
        Me.Chentregado.UseVisualStyleBackColor = True
        '
        'RBCPlanilla
        '
        Me.RBCPlanilla.AutoSize = True
        Me.RBCPlanilla.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.RBCPlanilla.Location = New System.Drawing.Point(518, 26)
        Me.RBCPlanilla.Name = "RBCPlanilla"
        Me.RBCPlanilla.Size = New System.Drawing.Size(61, 18)
        Me.RBCPlanilla.TabIndex = 408
        Me.RBCPlanilla.Text = "Planilla"
        Me.RBCPlanilla.UseVisualStyleBackColor = True
        Me.RBCPlanilla.Visible = False
        '
        'RBOtros
        '
        Me.RBOtros.AutoSize = True
        Me.RBOtros.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.RBOtros.Location = New System.Drawing.Point(173, 26)
        Me.RBOtros.Name = "RBOtros"
        Me.RBOtros.Size = New System.Drawing.Size(55, 18)
        Me.RBOtros.TabIndex = 407
        Me.RBOtros.Text = "Otros."
        Me.RBOtros.UseVisualStyleBackColor = True
        Me.RBOtros.Visible = False
        '
        'RBProveedor
        '
        Me.RBProveedor.AutoSize = True
        Me.RBProveedor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.RBProveedor.Location = New System.Drawing.Point(93, 26)
        Me.RBProveedor.Name = "RBProveedor"
        Me.RBProveedor.Size = New System.Drawing.Size(74, 18)
        Me.RBProveedor.TabIndex = 406
        Me.RBProveedor.Text = "Proveedor"
        Me.RBProveedor.UseVisualStyleBackColor = True
        '
        'RBCliente
        '
        Me.RBCliente.AutoSize = True
        Me.RBCliente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.RBCliente.Location = New System.Drawing.Point(22, 26)
        Me.RBCliente.Name = "RBCliente"
        Me.RBCliente.Size = New System.Drawing.Size(59, 18)
        Me.RBCliente.TabIndex = 405
        Me.RBCliente.Text = "Cliente"
        Me.RBCliente.UseVisualStyleBackColor = True
        '
        'TextDNI
        '
        Me.TextDNI.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextDNI.BeforeTouchSize = New System.Drawing.Size(102, 22)
        Me.TextDNI.BorderColor = System.Drawing.Color.Silver
        Me.TextDNI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextDNI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextDNI.CornerRadius = 4
        Me.TextDNI.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextDNI.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextDNI.Location = New System.Drawing.Point(22, 50)
        Me.TextDNI.Metrocolor = System.Drawing.Color.Silver
        Me.TextDNI.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextDNI.Name = "TextDNI"
        Me.TextDNI.Size = New System.Drawing.Size(118, 22)
        Me.TextDNI.TabIndex = 404
        '
        'TextPersona
        '
        Me.TextPersona.BackColor = System.Drawing.Color.White
        Me.TextPersona.BeforeTouchSize = New System.Drawing.Size(102, 22)
        Me.TextPersona.BorderColor = System.Drawing.Color.Silver
        Me.TextPersona.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextPersona.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextPersona.CornerRadius = 4
        Me.TextPersona.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextPersona.Enabled = False
        Me.TextPersona.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextPersona.Location = New System.Drawing.Point(146, 50)
        Me.TextPersona.Metrocolor = System.Drawing.Color.Silver
        Me.TextPersona.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextPersona.Name = "TextPersona"
        Me.TextPersona.NearImage = CType(resources.GetObject("TextPersona.NearImage"), System.Drawing.Image)
        Me.TextPersona.Size = New System.Drawing.Size(314, 22)
        Me.TextPersona.TabIndex = 402
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.cboFormaPago)
        Me.GroupBox5.Controls.Add(Me.txtNumOper)
        Me.GroupBox5.Location = New System.Drawing.Point(22, 172)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(316, 62)
        Me.GroupBox5.TabIndex = 636
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Forma de Pago"
        '
        'cboFormaPago
        '
        Me.cboFormaPago.BackColor = System.Drawing.Color.White
        Me.cboFormaPago.BeforeTouchSize = New System.Drawing.Size(185, 21)
        Me.cboFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFormaPago.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFormaPago.Location = New System.Drawing.Point(8, 29)
        Me.cboFormaPago.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboFormaPago.MetroColor = System.Drawing.Color.Silver
        Me.cboFormaPago.Name = "cboFormaPago"
        Me.cboFormaPago.Size = New System.Drawing.Size(185, 21)
        Me.cboFormaPago.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboFormaPago.TabIndex = 214
        Me.cboFormaPago.TabStop = False
        '
        'txtNumOper
        '
        Me.txtNumOper.BackColor = System.Drawing.Color.White
        Me.txtNumOper.BeforeTouchSize = New System.Drawing.Size(102, 22)
        Me.txtNumOper.BorderColor = System.Drawing.Color.Silver
        Me.txtNumOper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumOper.CornerRadius = 4
        Me.txtNumOper.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNumOper.Location = New System.Drawing.Point(199, 28)
        Me.txtNumOper.MaxLength = 20
        Me.txtNumOper.Metrocolor = System.Drawing.Color.Silver
        Me.txtNumOper.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtNumOper.Name = "txtNumOper"
        Me.txtNumOper.Size = New System.Drawing.Size(103, 22)
        Me.txtNumOper.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtNumOper.TabIndex = 213
        Me.txtNumOper.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TextBoxExt1)
        Me.GroupBox2.Controls.Add(Me.txtComprobante)
        Me.GroupBox2.Controls.Add(Me.TxtDia)
        Me.GroupBox2.Controls.Add(Me.cboMesCompra)
        Me.GroupBox2.Controls.Add(Me.txtHora)
        Me.GroupBox2.Controls.Add(Me.txtAnioCompra)
        Me.GroupBox2.Location = New System.Drawing.Point(22, 24)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(645, 68)
        Me.GroupBox2.TabIndex = 635
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos del Comprobante"
        '
        'TextBoxExt1
        '
        Me.TextBoxExt1.BackColor = System.Drawing.Color.White
        Me.TextBoxExt1.BeforeTouchSize = New System.Drawing.Size(102, 22)
        Me.TextBoxExt1.BorderColor = System.Drawing.Color.Silver
        Me.TextBoxExt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxExt1.CornerRadius = 4
        Me.TextBoxExt1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBoxExt1.Enabled = False
        Me.TextBoxExt1.Location = New System.Drawing.Point(481, 27)
        Me.TextBoxExt1.MaxLength = 20
        Me.TextBoxExt1.Metrocolor = System.Drawing.Color.Silver
        Me.TextBoxExt1.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextBoxExt1.Name = "TextBoxExt1"
        Me.TextBoxExt1.Size = New System.Drawing.Size(141, 22)
        Me.TextBoxExt1.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextBoxExt1.TabIndex = 626
        Me.TextBoxExt1.Text = "SALIDA DE DINERO"
        '
        'txtComprobante
        '
        Me.txtComprobante.BackColor = System.Drawing.Color.LavenderBlush
        Me.txtComprobante.BeforeTouchSize = New System.Drawing.Size(102, 22)
        Me.txtComprobante.BorderColor = System.Drawing.Color.Silver
        Me.txtComprobante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComprobante.CornerRadius = 4
        Me.txtComprobante.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtComprobante.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComprobante.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtComprobante.Location = New System.Drawing.Point(332, 27)
        Me.txtComprobante.MaxLength = 20
        Me.txtComprobante.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtComprobante.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtComprobante.Name = "txtComprobante"
        Me.txtComprobante.ReadOnly = True
        Me.txtComprobante.Size = New System.Drawing.Size(146, 22)
        Me.txtComprobante.TabIndex = 506
        Me.txtComprobante.Text = "COMPROBANTE DE CAJA"
        '
        'TxtDia
        '
        Me.TxtDia.AllowNull = True
        Me.TxtDia.BackGroundColor = System.Drawing.Color.AliceBlue
        Me.TxtDia.BeforeTouchSize = New System.Drawing.Size(102, 22)
        Me.TxtDia.BorderColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TxtDia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtDia.CornerRadius = 4
        Me.TxtDia.CurrencyDecimalDigits = 0
        Me.TxtDia.CurrencySymbol = ""
        Me.TxtDia.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtDia.DecimalValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TxtDia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(106, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(7, Byte), Integer))
        Me.TxtDia.Location = New System.Drawing.Point(6, 27)
        Me.TxtDia.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TxtDia.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TxtDia.Name = "TxtDia"
        Me.TxtDia.NegativeColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TxtDia.NullString = ""
        Me.TxtDia.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(106, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(7, Byte), Integer))
        Me.TxtDia.ReadOnly = True
        Me.TxtDia.ReadOnlyBackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TxtDia.Size = New System.Drawing.Size(51, 22)
        Me.TxtDia.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TxtDia.TabIndex = 624
        '
        'cboMesCompra
        '
        Me.cboMesCompra.BackColor = System.Drawing.Color.White
        Me.cboMesCompra.BeforeTouchSize = New System.Drawing.Size(109, 21)
        Me.cboMesCompra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMesCompra.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMesCompra.Location = New System.Drawing.Point(61, 28)
        Me.cboMesCompra.Name = "cboMesCompra"
        Me.cboMesCompra.Size = New System.Drawing.Size(109, 21)
        Me.cboMesCompra.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboMesCompra.TabIndex = 621
        '
        'txtHora
        '
        Me.txtHora.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtHora.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtHora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHora.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtHora.Checked = False
        Me.txtHora.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtHora.CustomFormat = "hh:mm:ss tt"
        Me.txtHora.DropDownImage = Nothing
        Me.txtHora.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtHora.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtHora.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtHora.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHora.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtHora.Location = New System.Drawing.Point(221, 27)
        Me.txtHora.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtHora.MinValue = New Date(CType(0, Long))
        Me.txtHora.Name = "txtHora"
        Me.txtHora.ShowCheckBox = False
        Me.txtHora.ShowDropButton = False
        Me.txtHora.ShowUpDown = True
        Me.txtHora.Size = New System.Drawing.Size(105, 22)
        Me.txtHora.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtHora.TabIndex = 623
        Me.txtHora.Value = New Date(2016, 1, 1, 11, 17, 0, 0)
        '
        'txtAnioCompra
        '
        Me.txtAnioCompra.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.txtAnioCompra.BeforeTouchSize = New System.Drawing.Size(102, 22)
        Me.txtAnioCompra.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.txtAnioCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAnioCompra.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAnioCompra.ForeColor = System.Drawing.Color.White
        Me.txtAnioCompra.Location = New System.Drawing.Point(172, 27)
        Me.txtAnioCompra.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtAnioCompra.MinimumSize = New System.Drawing.Size(12, 8)
        Me.txtAnioCompra.Name = "txtAnioCompra"
        Me.txtAnioCompra.ReadOnly = True
        Me.txtAnioCompra.Size = New System.Drawing.Size(46, 22)
        Me.txtAnioCompra.TabIndex = 622
        Me.txtAnioCompra.Text = "2016"
        Me.txtAnioCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LinkLabel1.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.LinkLabel1.Location = New System.Drawing.Point(9, 14)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(122, 14)
        Me.LinkLabel1.TabIndex = 609
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Elegir cuenta financiera"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtCF_tipo)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.LinkLabel1)
        Me.GroupBox1.Controls.Add(Me.SaldoEFMN)
        Me.GroupBox1.Controls.Add(Me.SaldoEFME)
        Me.GroupBox1.Controls.Add(Me.txtCF_name)
        Me.GroupBox1.Controls.Add(Me.txtCF_cuentaContable)
        Me.GroupBox1.Controls.Add(Me.txtCF_moneda)
        Me.GroupBox1.Location = New System.Drawing.Point(22, 95)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(645, 71)
        Me.GroupBox1.TabIndex = 634
        Me.GroupBox1.TabStop = False
        '
        'txtCF_tipo
        '
        Me.txtCF_tipo.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtCF_tipo.BeforeTouchSize = New System.Drawing.Size(102, 22)
        Me.txtCF_tipo.BorderColor = System.Drawing.Color.Silver
        Me.txtCF_tipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCF_tipo.CornerRadius = 4
        Me.txtCF_tipo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCF_tipo.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCF_tipo.Location = New System.Drawing.Point(219, 39)
        Me.txtCF_tipo.MaxLength = 20
        Me.txtCF_tipo.Metrocolor = System.Drawing.Color.Silver
        Me.txtCF_tipo.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtCF_tipo.Name = "txtCF_tipo"
        Me.txtCF_tipo.ReadOnly = True
        Me.txtCF_tipo.Size = New System.Drawing.Size(83, 22)
        Me.txtCF_tipo.TabIndex = 606
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(373, 16)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(76, 14)
        Me.Label15.TabIndex = 602
        Me.Label15.Text = "Disponible EF."
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(306, 16)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(47, 14)
        Me.Label14.TabIndex = 603
        Me.Label14.Text = "Moneda"
        '
        'SaldoEFMN
        '
        Me.SaldoEFMN.BackGroundColor = System.Drawing.Color.Honeydew
        Me.SaldoEFMN.BeforeTouchSize = New System.Drawing.Size(102, 22)
        Me.SaldoEFMN.BorderColor = System.Drawing.Color.Silver
        Me.SaldoEFMN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SaldoEFMN.CornerRadius = 4
        Me.SaldoEFMN.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.SaldoEFMN.DoubleValue = 0R
        Me.SaldoEFMN.FocusBorderColor = System.Drawing.Color.Silver
        Me.SaldoEFMN.Location = New System.Drawing.Point(376, 39)
        Me.SaldoEFMN.Metrocolor = System.Drawing.Color.Silver
        Me.SaldoEFMN.MinimumSize = New System.Drawing.Size(12, 8)
        Me.SaldoEFMN.Name = "SaldoEFMN"
        Me.SaldoEFMN.NullString = ""
        Me.SaldoEFMN.PositiveColor = System.Drawing.SystemColors.HotTrack
        Me.SaldoEFMN.ReadOnly = True
        Me.SaldoEFMN.ReadOnlyBackColor = System.Drawing.Color.Honeydew
        Me.SaldoEFMN.Size = New System.Drawing.Size(102, 22)
        Me.SaldoEFMN.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.SaldoEFMN.TabIndex = 604
        Me.SaldoEFMN.Text = "0.00"
        '
        'SaldoEFME
        '
        Me.SaldoEFME.BeforeTouchSize = New System.Drawing.Size(102, 22)
        Me.SaldoEFME.BorderColor = System.Drawing.Color.Silver
        Me.SaldoEFME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SaldoEFME.CornerRadius = 4
        Me.SaldoEFME.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.SaldoEFME.DoubleValue = 0R
        Me.SaldoEFME.Location = New System.Drawing.Point(481, 39)
        Me.SaldoEFME.Metrocolor = System.Drawing.Color.Silver
        Me.SaldoEFME.MinimumSize = New System.Drawing.Size(12, 8)
        Me.SaldoEFME.Name = "SaldoEFME"
        Me.SaldoEFME.NullString = ""
        Me.SaldoEFME.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.SaldoEFME.ReadOnly = True
        Me.SaldoEFME.Size = New System.Drawing.Size(102, 22)
        Me.SaldoEFME.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.SaldoEFME.TabIndex = 605
        Me.SaldoEFME.Text = "0.00"
        '
        'txtCF_name
        '
        Me.txtCF_name.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtCF_name.BeforeTouchSize = New System.Drawing.Size(102, 22)
        Me.txtCF_name.BorderColor = System.Drawing.Color.Silver
        Me.txtCF_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCF_name.CornerRadius = 4
        Me.txtCF_name.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCF_name.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCF_name.Location = New System.Drawing.Point(6, 32)
        Me.txtCF_name.MaxLength = 20
        Me.txtCF_name.Metrocolor = System.Drawing.Color.Silver
        Me.txtCF_name.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtCF_name.Multiline = True
        Me.txtCF_name.Name = "txtCF_name"
        Me.txtCF_name.ReadOnly = True
        Me.txtCF_name.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtCF_name.Size = New System.Drawing.Size(210, 30)
        Me.txtCF_name.TabIndex = 607
        '
        'txtCF_cuentaContable
        '
        Me.txtCF_cuentaContable.BackColor = System.Drawing.Color.AliceBlue
        Me.txtCF_cuentaContable.BeforeTouchSize = New System.Drawing.Size(102, 22)
        Me.txtCF_cuentaContable.BorderColor = System.Drawing.Color.Silver
        Me.txtCF_cuentaContable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCF_cuentaContable.CornerRadius = 4
        Me.txtCF_cuentaContable.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCF_cuentaContable.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCF_cuentaContable.Location = New System.Drawing.Point(587, 39)
        Me.txtCF_cuentaContable.MaxLength = 20
        Me.txtCF_cuentaContable.Metrocolor = System.Drawing.Color.Silver
        Me.txtCF_cuentaContable.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtCF_cuentaContable.Name = "txtCF_cuentaContable"
        Me.txtCF_cuentaContable.ReadOnly = True
        Me.txtCF_cuentaContable.Size = New System.Drawing.Size(48, 22)
        Me.txtCF_cuentaContable.TabIndex = 610
        '
        'txtCF_moneda
        '
        Me.txtCF_moneda.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtCF_moneda.BeforeTouchSize = New System.Drawing.Size(102, 22)
        Me.txtCF_moneda.BorderColor = System.Drawing.Color.Silver
        Me.txtCF_moneda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCF_moneda.CornerRadius = 4
        Me.txtCF_moneda.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCF_moneda.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCF_moneda.Location = New System.Drawing.Point(305, 39)
        Me.txtCF_moneda.MaxLength = 20
        Me.txtCF_moneda.Metrocolor = System.Drawing.Color.Silver
        Me.txtCF_moneda.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtCF_moneda.Name = "txtCF_moneda"
        Me.txtCF_moneda.ReadOnly = True
        Me.txtCF_moneda.Size = New System.Drawing.Size(67, 22)
        Me.txtCF_moneda.TabIndex = 608
        '
        'PopupControlContainer4
        '
        Me.PopupControlContainer4.Controls.Add(Me.lsvProveedor)
        Me.PopupControlContainer4.Location = New System.Drawing.Point(701, 95)
        Me.PopupControlContainer4.Name = "PopupControlContainer4"
        Me.PopupControlContainer4.Size = New System.Drawing.Size(319, 128)
        Me.PopupControlContainer4.TabIndex = 640
        '
        'lsvProveedor
        '
        Me.lsvProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lsvProveedor.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.colCliente, Me.colRUC})
        Me.lsvProveedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvProveedor.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lsvProveedor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(187, Byte), Integer))
        Me.lsvProveedor.FullRowSelect = True
        Me.lsvProveedor.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lsvProveedor.HideSelection = False
        Me.lsvProveedor.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1})
        Me.lsvProveedor.Location = New System.Drawing.Point(0, 0)
        Me.lsvProveedor.MultiSelect = False
        Me.lsvProveedor.Name = "lsvProveedor"
        Me.lsvProveedor.Size = New System.Drawing.Size(319, 128)
        Me.lsvProveedor.TabIndex = 1
        Me.lsvProveedor.UseCompatibleStateImageBehavior = False
        Me.lsvProveedor.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        Me.ColumnHeader1.Width = 0
        '
        'colCliente
        '
        Me.colCliente.Text = "Cliente"
        Me.colCliente.Width = 219
        '
        'colRUC
        '
        Me.colRUC.Text = "RUC"
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.White
        Me.GroupBox6.Controls.Add(Me.txtFondoME)
        Me.GroupBox6.Controls.Add(Me.txtTipoCambio)
        Me.GroupBox6.Controls.Add(Me.txtFondoMN)
        Me.GroupBox6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.GroupBox6.Location = New System.Drawing.Point(344, 172)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(323, 62)
        Me.GroupBox6.TabIndex = 641
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Importe del gasto"
        '
        'txtFondoME
        '
        Me.txtFondoME.BackColor = System.Drawing.Color.PaleGreen
        Me.txtFondoME.BeforeTouchSize = New System.Drawing.Size(118, 21)
        Me.txtFondoME.BorderColor = System.Drawing.Color.Silver
        Me.txtFondoME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFondoME.DecimalPlaces = 2
        Me.txtFondoME.Font = New System.Drawing.Font("Arial", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFondoME.ForeColor = System.Drawing.Color.Black
        Me.txtFondoME.Location = New System.Drawing.Point(197, 28)
        Me.txtFondoME.Maximum = New Decimal(New Integer() {-1304428544, 434162106, 542, 0})
        Me.txtFondoME.MetroColor = System.Drawing.Color.Silver
        Me.txtFondoME.Name = "txtFondoME"
        Me.txtFondoME.Size = New System.Drawing.Size(118, 21)
        Me.txtFondoME.TabIndex = 402
        Me.txtFondoME.TabStop = False
        Me.txtFondoME.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtFondoME.ThousandsSeparator = True
        Me.txtFondoME.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.BackColor = System.Drawing.Color.LavenderBlush
        Me.txtTipoCambio.BeforeTouchSize = New System.Drawing.Size(58, 21)
        Me.txtTipoCambio.BorderColor = System.Drawing.Color.Silver
        Me.txtTipoCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTipoCambio.DecimalPlaces = 3
        Me.txtTipoCambio.Font = New System.Drawing.Font("Arial", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoCambio.Location = New System.Drawing.Point(133, 28)
        Me.txtTipoCambio.Maximum = New Decimal(New Integer() {-159383552, 46653770, 5421, 0})
        Me.txtTipoCambio.MetroColor = System.Drawing.Color.Silver
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.Size = New System.Drawing.Size(58, 21)
        Me.txtTipoCambio.TabIndex = 403
        Me.txtTipoCambio.TabStop = False
        Me.txtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTipoCambio.ThousandsSeparator = True
        Me.txtTipoCambio.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'txtFondoMN
        '
        Me.txtFondoMN.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtFondoMN.BeforeTouchSize = New System.Drawing.Size(112, 21)
        Me.txtFondoMN.BorderColor = System.Drawing.Color.Silver
        Me.txtFondoMN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFondoMN.DecimalPlaces = 2
        Me.txtFondoMN.Font = New System.Drawing.Font("Arial", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFondoMN.ForeColor = System.Drawing.Color.Black
        Me.txtFondoMN.Location = New System.Drawing.Point(15, 28)
        Me.txtFondoMN.Maximum = New Decimal(New Integer() {-159383552, 46653770, 5421, 0})
        Me.txtFondoMN.MetroColor = System.Drawing.Color.Silver
        Me.txtFondoMN.Name = "txtFondoMN"
        Me.txtFondoMN.Size = New System.Drawing.Size(112, 21)
        Me.txtFondoMN.TabIndex = 401
        Me.txtFondoMN.TabStop = False
        Me.txtFondoMN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtFondoMN.ThousandsSeparator = True
        Me.txtFondoMN.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'BgProveedor
        '
        Me.BgProveedor.WorkerSupportsCancellation = True
        '
        'FormPagoEgreso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(134, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(134, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.CaptionButtonColor = System.Drawing.Color.White
        Me.CaptionButtonHoverColor = System.Drawing.Color.White
        CaptionLabel1.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.White
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(200, 24)
        CaptionLabel1.Text = "Registro de otros egresos"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(688, 451)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.PopupControlContainer4)
        Me.Controls.Add(Me.RoundButton21)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FormPagoEgreso"
        Me.ShowIcon = False
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.TextGlosa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.PictureLoad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextDNI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextPersona, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.cboFormaPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumOper, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.TextBoxExt1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtComprobante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboMesCompra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAnioCompra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtCF_tipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SaldoEFMN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SaldoEFME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCF_name, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCF_cuentaContable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCF_moneda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PopupControlContainer4.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        CType(Me.txtFondoME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoCambio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFondoMN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents RoundButton21 As RoundButton2
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents TextGlosa As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Chentregado As CheckBox
    Friend WithEvents RBCPlanilla As RadioButton
    Friend WithEvents RBOtros As RadioButton
    Friend WithEvents RBProveedor As RadioButton
    Friend WithEvents RBCliente As RadioButton
    Friend WithEvents TextDNI As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents TextPersona As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents cboFormaPago As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents txtNumOper As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtComprobante As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents TxtDia As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents cboMesCompra As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents txtHora As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents txtAnioCompra As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtCF_tipo As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents SaldoEFMN As Syncfusion.Windows.Forms.Tools.DoubleTextBox
    Friend WithEvents SaldoEFME As Syncfusion.Windows.Forms.Tools.DoubleTextBox
    Friend WithEvents txtCF_name As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtCF_cuentaContable As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtCF_moneda As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Private WithEvents PopupControlContainer4 As Syncfusion.Windows.Forms.PopupControlContainer
    Friend WithEvents lsvProveedor As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents colCliente As ColumnHeader
    Friend WithEvents colRUC As ColumnHeader
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents txtFondoME As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents txtTipoCambio As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents txtFondoMN As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents BgProveedor As System.ComponentModel.BackgroundWorker
    Friend WithEvents PictureLoad As PictureBox
    Friend WithEvents ToggleConsultas As ToggleButton2
    Friend WithEvents TextBoxExt1 As Syncfusion.Windows.Forms.Tools.TextBoxExt
End Class

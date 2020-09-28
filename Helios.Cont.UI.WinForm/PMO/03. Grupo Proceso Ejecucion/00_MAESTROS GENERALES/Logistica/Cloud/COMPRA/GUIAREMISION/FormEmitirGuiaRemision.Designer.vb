Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormEmitirGuiaRemision
    Inherits MetroForm

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEmitirGuiaRemision))
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridSummaryColumnDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor()
        Dim GridSummaryColumnDescriptor6 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor()
        Me.GradientPanel12 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.txtotraguia = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.combotipoGuia = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cb = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.GradientPanel5 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.cbTipoDocdes = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.txtmotivotraslado = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtDAM = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbtipoDesOtro = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.txtDnidesti = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtdatosDesti = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.cbomotivotrasl = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.lsvDetOtroOpera = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BunifuFlatButton1 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.TextBoxExt6 = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.BunifuFlatButton4 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.btnEliminarBien = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.BunifuFlatButton5 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.BgProveedor = New System.ComponentModel.BackgroundWorker()
        Me.dgAgregarBien = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.txtTipoDoc = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtNumeroTD = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtRemitente = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtnumerAfec = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtcomprane = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtserieAfec = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtTotalPB = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.BunifuFlatButton7 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.BunifuFlatButton8 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.BunifuFlatButton9 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnConfirmar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.GradientPanel4 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ToggleConsultas = New Helios.Cont.Presentation.WinForm.ToggleButton2()
        Me.gpbProveedor = New System.Windows.Forms.GroupBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtdocprovee = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtRazoSocprovee = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtnumprovee = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GradientPanel9 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.BunifuFlatButton3 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.BunifuFlatButton6 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.bfbRemitente = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.PictureLoad = New System.Windows.Forms.PictureBox()
        Me.GradientPanel7 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Line21 = New Helios.Cont.Presentation.WinForm.Line2()
        Me.GradientPanel8 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.sliderTop = New System.Windows.Forms.PictureBox()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.GradientPanel6 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.GradientPanel3 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.cbTipotras = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        CType(Me.GradientPanel12, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel12.SuspendLayout()
        CType(Me.txtotraguia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.combotipoGuia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel5.SuspendLayout()
        CType(Me.cbTipoDocdes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtmotivotraslado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDAM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbtipoDesOtro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDnidesti, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtdatosDesti, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbomotivotrasl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxExt6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgAgregarBien, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumeroTD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRemitente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtnumerAfec, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcomprane, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtserieAfec, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalPB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.GradientPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel4.SuspendLayout()
        Me.gpbProveedor.SuspendLayout()
        CType(Me.txtdocprovee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRazoSocprovee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtnumprovee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel9.SuspendLayout()
        CType(Me.PictureLoad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel7.SuspendLayout()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        CType(Me.GradientPanel8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel8.SuspendLayout()
        CType(Me.sliderTop, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.GradientPanel6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel6.SuspendLayout()
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel3.SuspendLayout()
        CType(Me.cbTipotras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GradientPanel12
        '
        Me.GradientPanel12.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GradientPanel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel12.Controls.Add(Me.txtotraguia)
        Me.GradientPanel12.Controls.Add(Me.Label1)
        Me.GradientPanel12.Controls.Add(Me.GroupBox1)
        Me.GradientPanel12.Controls.Add(Me.combotipoGuia)
        Me.GradientPanel12.Controls.Add(Me.Label25)
        Me.GradientPanel12.Location = New System.Drawing.Point(715, 52)
        Me.GradientPanel12.Name = "GradientPanel12"
        Me.GradientPanel12.Size = New System.Drawing.Size(353, 183)
        Me.GradientPanel12.TabIndex = 683
        '
        'txtotraguia
        '
        Me.txtotraguia.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtotraguia.BeforeTouchSize = New System.Drawing.Size(263, 23)
        Me.txtotraguia.BorderColor = System.Drawing.Color.Silver
        Me.txtotraguia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtotraguia.CornerRadius = 4
        Me.txtotraguia.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtotraguia.Enabled = False
        Me.txtotraguia.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtotraguia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtotraguia.Location = New System.Drawing.Point(12, 149)
        Me.txtotraguia.MaxLength = 180
        Me.txtotraguia.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtotraguia.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtotraguia.Name = "txtotraguia"
        Me.txtotraguia.Size = New System.Drawing.Size(324, 23)
        Me.txtotraguia.TabIndex = 847
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 135)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 846
        Me.Label1.Text = "Otra Guìa"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(150, 56)
        Me.GroupBox1.TabIndex = 834
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Asignar guía remisión"
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(72, 28)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(39, 17)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.Text = "No"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(24, 28)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(34, 17)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Si"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'combotipoGuia
        '
        Me.combotipoGuia.BackColor = System.Drawing.Color.White
        Me.combotipoGuia.BeforeTouchSize = New System.Drawing.Size(324, 21)
        Me.combotipoGuia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combotipoGuia.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combotipoGuia.Location = New System.Drawing.Point(12, 103)
        Me.combotipoGuia.Name = "combotipoGuia"
        Me.combotipoGuia.Size = New System.Drawing.Size(324, 21)
        Me.combotipoGuia.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.combotipoGuia.TabIndex = 831
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(20, 87)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(72, 13)
        Me.Label25.TabIndex = 830
        Me.Label25.Text = "Tipo de guía"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(162, 67)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(129, 14)
        Me.Label15.TabIndex = 832
        Me.Label15.Text = "(###- ####- ##- ###### )"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(22, 8)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(102, 14)
        Me.Label12.TabIndex = 646
        Me.Label12.Text = "Motivo del traslado"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(9, 5)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(152, 13)
        Me.Label10.TabIndex = 642
        Me.Label10.Text = "Descripcion Motivo Traslado"
        '
        'cb
        '
        Me.cb.BackColor = System.Drawing.Color.White
        Me.cb.BeforeTouchSize = New System.Drawing.Size(114, 21)
        Me.cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cb.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb.Location = New System.Drawing.Point(3, 56)
        Me.cb.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.cb.MetroColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.cb.Name = "cb"
        Me.cb.Size = New System.Drawing.Size(114, 21)
        Me.cb.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cb.TabIndex = 678
        '
        'GradientPanel5
        '
        Me.GradientPanel5.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GradientPanel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel5.Controls.Add(Me.cbTipoDocdes)
        Me.GradientPanel5.Controls.Add(Me.txtmotivotraslado)
        Me.GradientPanel5.Controls.Add(Me.txtDAM)
        Me.GradientPanel5.Controls.Add(Me.Label4)
        Me.GradientPanel5.Controls.Add(Me.Label2)
        Me.GradientPanel5.Controls.Add(Me.Label15)
        Me.GradientPanel5.Controls.Add(Me.cbtipoDesOtro)
        Me.GradientPanel5.Controls.Add(Me.Label10)
        Me.GradientPanel5.Controls.Add(Me.txtDnidesti)
        Me.GradientPanel5.Controls.Add(Me.txtdatosDesti)
        Me.GradientPanel5.Controls.Add(Me.PictureBox2)
        Me.GradientPanel5.Controls.Add(Me.Label41)
        Me.GradientPanel5.Controls.Add(Me.Label40)
        Me.GradientPanel5.Location = New System.Drawing.Point(11, 52)
        Me.GradientPanel5.Name = "GradientPanel5"
        Me.GradientPanel5.Size = New System.Drawing.Size(344, 183)
        Me.GradientPanel5.TabIndex = 684
        '
        'cbTipoDocdes
        '
        Me.cbTipoDocdes.BackColor = System.Drawing.Color.White
        Me.cbTipoDocdes.BeforeTouchSize = New System.Drawing.Size(149, 21)
        Me.cbTipoDocdes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTipoDocdes.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTipoDocdes.Location = New System.Drawing.Point(7, 110)
        Me.cbTipoDocdes.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.cbTipoDocdes.MetroColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.cbTipoDocdes.Name = "cbTipoDocdes"
        Me.cbTipoDocdes.Size = New System.Drawing.Size(149, 21)
        Me.cbTipoDocdes.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cbTipoDocdes.TabIndex = 678
        '
        'txtmotivotraslado
        '
        Me.txtmotivotraslado.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtmotivotraslado.BeforeTouchSize = New System.Drawing.Size(263, 23)
        Me.txtmotivotraslado.BorderColor = System.Drawing.Color.Silver
        Me.txtmotivotraslado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtmotivotraslado.CornerRadius = 4
        Me.txtmotivotraslado.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtmotivotraslado.Enabled = False
        Me.txtmotivotraslado.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmotivotraslado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtmotivotraslado.Location = New System.Drawing.Point(7, 22)
        Me.txtmotivotraslado.MaxLength = 180
        Me.txtmotivotraslado.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtmotivotraslado.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtmotivotraslado.Name = "txtmotivotraslado"
        Me.txtmotivotraslado.Size = New System.Drawing.Size(322, 23)
        Me.txtmotivotraslado.TabIndex = 845
        '
        'txtDAM
        '
        Me.txtDAM.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtDAM.BeforeTouchSize = New System.Drawing.Size(263, 23)
        Me.txtDAM.BorderColor = System.Drawing.Color.Silver
        Me.txtDAM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDAM.CornerRadius = 4
        Me.txtDAM.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtDAM.Enabled = False
        Me.txtDAM.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDAM.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtDAM.Location = New System.Drawing.Point(7, 65)
        Me.txtDAM.MaxLength = 180
        Me.txtDAM.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtDAM.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtDAM.Name = "txtDAM"
        Me.txtDAM.Size = New System.Drawing.Size(149, 23)
        Me.txtDAM.TabIndex = 844
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 92)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 13)
        Me.Label4.TabIndex = 679
        Me.Label4.Text = "Tipo Doc Destino:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 13)
        Me.Label2.TabIndex = 679
        Me.Label2.Text = "Numeración DAM"
        '
        'cbtipoDesOtro
        '
        Me.cbtipoDesOtro.BackColor = System.Drawing.Color.White
        Me.cbtipoDesOtro.BeforeTouchSize = New System.Drawing.Size(149, 21)
        Me.cbtipoDesOtro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbtipoDesOtro.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbtipoDesOtro.Location = New System.Drawing.Point(7, 110)
        Me.cbtipoDesOtro.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.cbtipoDesOtro.MetroColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.cbtipoDesOtro.Name = "cbtipoDesOtro"
        Me.cbtipoDesOtro.Size = New System.Drawing.Size(149, 21)
        Me.cbtipoDesOtro.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cbtipoDesOtro.TabIndex = 838
        Me.cbtipoDesOtro.Visible = False
        '
        'txtDnidesti
        '
        Me.txtDnidesti.BackColor = System.Drawing.Color.White
        Me.txtDnidesti.BeforeTouchSize = New System.Drawing.Size(263, 23)
        Me.txtDnidesti.BorderColor = System.Drawing.Color.Silver
        Me.txtDnidesti.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDnidesti.CornerRadius = 4
        Me.txtDnidesti.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtDnidesti.Enabled = False
        Me.txtDnidesti.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDnidesti.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtDnidesti.Location = New System.Drawing.Point(177, 110)
        Me.txtDnidesti.MaxLength = 180
        Me.txtDnidesti.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtDnidesti.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtDnidesti.Name = "txtDnidesti"
        Me.txtDnidesti.Size = New System.Drawing.Size(128, 23)
        Me.txtDnidesti.TabIndex = 676
        '
        'txtdatosDesti
        '
        Me.txtdatosDesti.BackColor = System.Drawing.Color.White
        Me.txtdatosDesti.BeforeTouchSize = New System.Drawing.Size(263, 23)
        Me.txtdatosDesti.BorderColor = System.Drawing.Color.Silver
        Me.txtdatosDesti.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtdatosDesti.CornerRadius = 4
        Me.txtdatosDesti.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtdatosDesti.Enabled = False
        Me.txtdatosDesti.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdatosDesti.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtdatosDesti.Location = New System.Drawing.Point(7, 151)
        Me.txtdatosDesti.MaxLength = 180
        Me.txtdatosDesti.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtdatosDesti.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtdatosDesti.Name = "txtdatosDesti"
        Me.txtdatosDesti.ReadOnly = True
        Me.txtdatosDesti.Size = New System.Drawing.Size(322, 23)
        Me.txtdatosDesti.TabIndex = 675
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(308, 111)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(22, 21)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 836
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(9, 136)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(168, 13)
        Me.Label41.TabIndex = 674
        Me.Label41.Text = "Nombre y Apellido Destinatario"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(180, 94)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(110, 13)
        Me.Label40.TabIndex = 677
        Me.Label40.Text = "Nro de Doc. destino"
        '
        'cbomotivotrasl
        '
        Me.cbomotivotrasl.BackColor = System.Drawing.Color.White
        Me.cbomotivotrasl.BeforeTouchSize = New System.Drawing.Size(334, 21)
        Me.cbomotivotrasl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbomotivotrasl.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbomotivotrasl.Location = New System.Drawing.Point(12, 25)
        Me.cbomotivotrasl.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.cbomotivotrasl.MetroColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.cbomotivotrasl.Name = "cbomotivotrasl"
        Me.cbomotivotrasl.Size = New System.Drawing.Size(334, 21)
        Me.cbomotivotrasl.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cbomotivotrasl.TabIndex = 843
        '
        'lsvDetOtroOpera
        '
        Me.lsvDetOtroOpera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lsvDetOtroOpera.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lsvDetOtroOpera.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lsvDetOtroOpera.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(187, Byte), Integer))
        Me.lsvDetOtroOpera.FullRowSelect = True
        Me.lsvDetOtroOpera.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lsvDetOtroOpera.HideSelection = False
        Me.lsvDetOtroOpera.Location = New System.Drawing.Point(364, 175)
        Me.lsvDetOtroOpera.MultiSelect = False
        Me.lsvDetOtroOpera.Name = "lsvDetOtroOpera"
        Me.lsvDetOtroOpera.Size = New System.Drawing.Size(337, 60)
        Me.lsvDetOtroOpera.TabIndex = 837
        Me.lsvDetOtroOpera.UseCompatibleStateImageBehavior = False
        Me.lsvDetOtroOpera.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "TIPO DOC"
        Me.ColumnHeader1.Width = 190
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "CANTIDAD"
        Me.ColumnHeader2.Width = 80
        '
        'BunifuFlatButton1
        '
        Me.BunifuFlatButton1.Activecolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton1.BackColor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton1.BorderRadius = 0
        Me.BunifuFlatButton1.ButtonText = "Otro Doc. a la operación"
        Me.BunifuFlatButton1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton1.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton1.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton1.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton1.Iconimage = Nothing
        Me.BunifuFlatButton1.Iconimage_right = Nothing
        Me.BunifuFlatButton1.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton1.Iconimage_Selected = Nothing
        Me.BunifuFlatButton1.IconMarginLeft = 0
        Me.BunifuFlatButton1.IconMarginRight = 0
        Me.BunifuFlatButton1.IconRightVisible = True
        Me.BunifuFlatButton1.IconRightZoom = 0R
        Me.BunifuFlatButton1.IconVisible = True
        Me.BunifuFlatButton1.IconZoom = 90.0R
        Me.BunifuFlatButton1.IsTab = False
        Me.BunifuFlatButton1.Location = New System.Drawing.Point(553, 150)
        Me.BunifuFlatButton1.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton1.Name = "BunifuFlatButton1"
        Me.BunifuFlatButton1.Normalcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton1.OnHovercolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton1.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton1.selected = False
        Me.BunifuFlatButton1.Size = New System.Drawing.Size(148, 27)
        Me.BunifuFlatButton1.TabIndex = 836
        Me.BunifuFlatButton1.Text = "Otro Doc. a la operación"
        Me.BunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton1.Textcolor = System.Drawing.SystemColors.HotTrack
        Me.BunifuFlatButton1.TextFont = New System.Drawing.Font("Segoe UI Semibold", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'TextBoxExt6
        '
        Me.TextBoxExt6.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextBoxExt6.BeforeTouchSize = New System.Drawing.Size(263, 23)
        Me.TextBoxExt6.BorderColor = System.Drawing.Color.Silver
        Me.TextBoxExt6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxExt6.CornerRadius = 4
        Me.TextBoxExt6.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextBoxExt6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxExt6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextBoxExt6.Location = New System.Drawing.Point(475, 25)
        Me.TextBoxExt6.MaxLength = 20
        Me.TextBoxExt6.Metrocolor = System.Drawing.Color.YellowGreen
        Me.TextBoxExt6.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextBoxExt6.Name = "TextBoxExt6"
        Me.TextBoxExt6.Size = New System.Drawing.Size(115, 23)
        Me.TextBoxExt6.TabIndex = 682
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(138, 31)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(80, 14)
        Me.Label14.TabIndex = 827
        Me.Label14.Text = "Lista de Bienes"
        '
        'BunifuFlatButton4
        '
        Me.BunifuFlatButton4.Activecolor = System.Drawing.Color.Green
        Me.BunifuFlatButton4.BackColor = System.Drawing.Color.Green
        Me.BunifuFlatButton4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton4.BorderRadius = 5
        Me.BunifuFlatButton4.ButtonText = "Agregar bienes"
        Me.BunifuFlatButton4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton4.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton4.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.BunifuFlatButton4.Location = New System.Drawing.Point(618, 24)
        Me.BunifuFlatButton4.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton4.Name = "BunifuFlatButton4"
        Me.BunifuFlatButton4.Normalcolor = System.Drawing.Color.Green
        Me.BunifuFlatButton4.OnHovercolor = System.Drawing.Color.Green
        Me.BunifuFlatButton4.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton4.selected = False
        Me.BunifuFlatButton4.Size = New System.Drawing.Size(115, 22)
        Me.BunifuFlatButton4.TabIndex = 828
        Me.BunifuFlatButton4.Text = "Agregar bienes"
        Me.BunifuFlatButton4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton4.Textcolor = System.Drawing.Color.White
        Me.BunifuFlatButton4.TextFont = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton4.Visible = False
        '
        'btnEliminarBien
        '
        Me.btnEliminarBien.Activecolor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.btnEliminarBien.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.btnEliminarBien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnEliminarBien.BorderRadius = 5
        Me.btnEliminarBien.ButtonText = "Eliminar "
        Me.btnEliminarBien.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEliminarBien.DisabledColor = System.Drawing.Color.Gray
        Me.btnEliminarBien.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminarBien.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnEliminarBien.Iconcolor = System.Drawing.Color.Transparent
        Me.btnEliminarBien.Iconimage = Nothing
        Me.btnEliminarBien.Iconimage_right = Nothing
        Me.btnEliminarBien.Iconimage_right_Selected = Nothing
        Me.btnEliminarBien.Iconimage_Selected = Nothing
        Me.btnEliminarBien.IconMarginLeft = 0
        Me.btnEliminarBien.IconMarginRight = 0
        Me.btnEliminarBien.IconRightVisible = True
        Me.btnEliminarBien.IconRightZoom = 0R
        Me.btnEliminarBien.IconVisible = True
        Me.btnEliminarBien.IconZoom = 90.0R
        Me.btnEliminarBien.IsTab = False
        Me.btnEliminarBien.Location = New System.Drawing.Point(313, 25)
        Me.btnEliminarBien.Margin = New System.Windows.Forms.Padding(2)
        Me.btnEliminarBien.Name = "btnEliminarBien"
        Me.btnEliminarBien.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.btnEliminarBien.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.btnEliminarBien.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.btnEliminarBien.selected = False
        Me.btnEliminarBien.Size = New System.Drawing.Size(91, 23)
        Me.btnEliminarBien.TabIndex = 829
        Me.btnEliminarBien.Text = "Eliminar "
        Me.btnEliminarBien.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnEliminarBien.Textcolor = System.Drawing.Color.White
        Me.btnEliminarBien.TextFont = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'BunifuFlatButton5
        '
        Me.BunifuFlatButton5.Activecolor = System.Drawing.Color.Green
        Me.BunifuFlatButton5.BackColor = System.Drawing.Color.Green
        Me.BunifuFlatButton5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton5.BorderRadius = 5
        Me.BunifuFlatButton5.ButtonText = "Consultar"
        Me.BunifuFlatButton5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton5.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton5.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BunifuFlatButton5.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton5.Iconimage = Nothing
        Me.BunifuFlatButton5.Iconimage_right = Nothing
        Me.BunifuFlatButton5.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton5.Iconimage_Selected = Nothing
        Me.BunifuFlatButton5.IconMarginLeft = 0
        Me.BunifuFlatButton5.IconMarginRight = 0
        Me.BunifuFlatButton5.IconRightVisible = True
        Me.BunifuFlatButton5.IconRightZoom = 0R
        Me.BunifuFlatButton5.IconVisible = True
        Me.BunifuFlatButton5.IconZoom = 90.0R
        Me.BunifuFlatButton5.IsTab = False
        Me.BunifuFlatButton5.Location = New System.Drawing.Point(220, 25)
        Me.BunifuFlatButton5.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton5.Name = "BunifuFlatButton5"
        Me.BunifuFlatButton5.Normalcolor = System.Drawing.Color.Green
        Me.BunifuFlatButton5.OnHovercolor = System.Drawing.Color.Green
        Me.BunifuFlatButton5.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton5.selected = False
        Me.BunifuFlatButton5.Size = New System.Drawing.Size(91, 22)
        Me.BunifuFlatButton5.TabIndex = 831
        Me.BunifuFlatButton5.Text = "Consultar"
        Me.BunifuFlatButton5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton5.Textcolor = System.Drawing.Color.White
        Me.BunifuFlatButton5.TextFont = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'BgProveedor
        '
        Me.BgProveedor.WorkerSupportsCancellation = True
        '
        'dgAgregarBien
        '
        Me.dgAgregarBien.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.dgAgregarBien.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        Me.dgAgregarBien.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.dgAgregarBien.BackColor = System.Drawing.SystemColors.Menu
        Me.dgAgregarBien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgAgregarBien.GridLineColor = System.Drawing.Color.White
        Me.dgAgregarBien.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgAgregarBien.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.dgAgregarBien.Location = New System.Drawing.Point(0, 0)
        Me.dgAgregarBien.Name = "dgAgregarBien"
        Me.dgAgregarBien.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.dgAgregarBien.Size = New System.Drawing.Size(1080, 167)
        Me.dgAgregarBien.TabIndex = 851
        Me.dgAgregarBien.TableDescriptor.AllowNew = False
        GridColumnDescriptor3.MappingName = "descripcionItem"
        GridColumnDescriptor3.Width = 280
        Me.dgAgregarBien.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor("idDocumento"), New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor("secuencia"), New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor("idItem"), GridColumnDescriptor3, New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor("unidadMedida"), New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor("cantidad")})
        GridSummaryColumnDescriptor5.Appearance.AnySummaryCell.CellType = "Currency"
        GridSummaryColumnDescriptor5.Appearance.AnySummaryCell.CurrencyEdit.CurrencySymbol = ""
        GridSummaryColumnDescriptor5.DataMember = "importeTotal"
        GridSummaryColumnDescriptor5.Format = "{Sum}"
        GridSummaryColumnDescriptor5.Name = "importeTotal"
        GridSummaryColumnDescriptor5.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        GridSummaryColumnDescriptor6.Appearance.AnySummaryCell.CellType = "Currency"
        GridSummaryColumnDescriptor6.Appearance.AnySummaryCell.CurrencyEdit.CurrencySymbol = ""
        GridSummaryColumnDescriptor6.DataMember = "importeUS"
        GridSummaryColumnDescriptor6.Format = "{Sum}"
        GridSummaryColumnDescriptor6.Name = "importeUS"
        GridSummaryColumnDescriptor6.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        Me.dgAgregarBien.TableDescriptor.SummaryRows.Add(New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor("Row 1", New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor() {GridSummaryColumnDescriptor5, GridSummaryColumnDescriptor6}))
        Me.dgAgregarBien.TableDescriptor.TableOptions.CaptionRowHeight = 29
        Me.dgAgregarBien.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.dgAgregarBien.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.dgAgregarBien.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("descripcionItem"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("unidadMedida"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("cantidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("idItem")})
        Me.dgAgregarBien.TableOptions.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.dgAgregarBien.TableOptions.SelectionTextColor = System.Drawing.SystemColors.HighlightText
        Me.dgAgregarBien.Text = "GridGroupingControl2"
        Me.dgAgregarBien.TopLevelGroupOptions.ShowColumnHeaders = True
        Me.dgAgregarBien.UseRightToLeftCompatibleTextBox = True
        Me.dgAgregarBien.VersionInfo = "12.4400.0.24"
        '
        'txtTipoDoc
        '
        Me.txtTipoDoc.BackColor = System.Drawing.SystemColors.Info
        Me.txtTipoDoc.BeforeTouchSize = New System.Drawing.Size(115, 23)
        Me.txtTipoDoc.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtTipoDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTipoDoc.CornerRadius = 4
        Me.txtTipoDoc.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtTipoDoc.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoDoc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTipoDoc.Location = New System.Drawing.Point(388, 51)
        Me.txtTipoDoc.MaxLength = 10
        Me.txtTipoDoc.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtTipoDoc.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtTipoDoc.Name = "txtTipoDoc"
        Me.txtTipoDoc.ReadOnly = True
        Me.txtTipoDoc.Size = New System.Drawing.Size(95, 22)
        Me.txtTipoDoc.TabIndex = 622
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(396, 37)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 14)
        Me.Label6.TabIndex = 678
        Me.Label6.Text = "Tipo Doc Emp:"
        '
        'txtNumeroTD
        '
        Me.txtNumeroTD.BackColor = System.Drawing.SystemColors.Info
        Me.txtNumeroTD.BeforeTouchSize = New System.Drawing.Size(115, 23)
        Me.txtNumeroTD.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtNumeroTD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumeroTD.CornerRadius = 4
        Me.txtNumeroTD.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtNumeroTD.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumeroTD.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtNumeroTD.Location = New System.Drawing.Point(490, 51)
        Me.txtNumeroTD.MaxLength = 20
        Me.txtNumeroTD.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtNumeroTD.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtNumeroTD.Name = "txtNumeroTD"
        Me.txtNumeroTD.ReadOnly = True
        Me.txtNumeroTD.Size = New System.Drawing.Size(100, 22)
        Me.txtNumeroTD.TabIndex = 623
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(498, 37)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(60, 14)
        Me.Label8.TabIndex = 678
        Me.Label8.Text = "Doc Empre"
        '
        'txtRemitente
        '
        Me.txtRemitente.BackColor = System.Drawing.SystemColors.Info
        Me.txtRemitente.BeforeTouchSize = New System.Drawing.Size(115, 23)
        Me.txtRemitente.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtRemitente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemitente.CornerRadius = 4
        Me.txtRemitente.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtRemitente.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemitente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtRemitente.Location = New System.Drawing.Point(603, 51)
        Me.txtRemitente.MaxLength = 180
        Me.txtRemitente.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtRemitente.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtRemitente.Name = "txtRemitente"
        Me.txtRemitente.ReadOnly = True
        Me.txtRemitente.Size = New System.Drawing.Size(374, 23)
        Me.txtRemitente.TabIndex = 651
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(18, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 14)
        Me.Label3.TabIndex = 667
        Me.Label3.Text = "Tipo comprobante"
        '
        'txtnumerAfec
        '
        Me.txtnumerAfec.BackColor = System.Drawing.SystemColors.Info
        Me.txtnumerAfec.BeforeTouchSize = New System.Drawing.Size(115, 23)
        Me.txtnumerAfec.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtnumerAfec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtnumerAfec.CornerRadius = 4
        Me.txtnumerAfec.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtnumerAfec.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnumerAfec.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtnumerAfec.Location = New System.Drawing.Point(252, 50)
        Me.txtnumerAfec.MaxLength = 20
        Me.txtnumerAfec.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtnumerAfec.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtnumerAfec.Name = "txtnumerAfec"
        Me.txtnumerAfec.ReadOnly = True
        Me.txtnumerAfec.Size = New System.Drawing.Size(104, 23)
        Me.txtnumerAfec.TabIndex = 629
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(252, 36)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(103, 14)
        Me.Label23.TabIndex = 665
        Me.Label23.Text = "Núm. Comprobante"
        '
        'txtcomprane
        '
        Me.txtcomprane.BackColor = System.Drawing.SystemColors.Info
        Me.txtcomprane.BeforeTouchSize = New System.Drawing.Size(115, 23)
        Me.txtcomprane.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtcomprane.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtcomprane.CornerRadius = 4
        Me.txtcomprane.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtcomprane.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcomprane.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtcomprane.Location = New System.Drawing.Point(13, 50)
        Me.txtcomprane.MaxLength = 20
        Me.txtcomprane.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtcomprane.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtcomprane.Name = "txtcomprane"
        Me.txtcomprane.ReadOnly = True
        Me.txtcomprane.Size = New System.Drawing.Size(131, 23)
        Me.txtcomprane.TabIndex = 666
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.Black
        Me.Label24.Location = New System.Drawing.Point(148, 36)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(100, 14)
        Me.Label24.TabIndex = 664
        Me.Label24.Text = "Serie Comprobante"
        '
        'txtserieAfec
        '
        Me.txtserieAfec.BackColor = System.Drawing.SystemColors.Info
        Me.txtserieAfec.BeforeTouchSize = New System.Drawing.Size(115, 23)
        Me.txtserieAfec.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.txtserieAfec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtserieAfec.CornerRadius = 4
        Me.txtserieAfec.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtserieAfec.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtserieAfec.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtserieAfec.Location = New System.Drawing.Point(150, 50)
        Me.txtserieAfec.MaxLength = 20
        Me.txtserieAfec.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtserieAfec.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtserieAfec.Name = "txtserieAfec"
        Me.txtserieAfec.ReadOnly = True
        Me.txtserieAfec.Size = New System.Drawing.Size(95, 23)
        Me.txtserieAfec.TabIndex = 627
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(235, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(22, 21)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 839
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'txtTotalPB
        '
        Me.txtTotalPB.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtTotalPB.BeforeTouchSize = New System.Drawing.Size(115, 23)
        Me.txtTotalPB.BorderColor = System.Drawing.Color.Silver
        Me.txtTotalPB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalPB.CornerRadius = 4
        Me.txtTotalPB.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtTotalPB.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPB.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTotalPB.Location = New System.Drawing.Point(948, 1)
        Me.txtTotalPB.MaxLength = 20
        Me.txtTotalPB.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtTotalPB.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtTotalPB.Name = "txtTotalPB"
        Me.txtTotalPB.Size = New System.Drawing.Size(115, 23)
        Me.txtTotalPB.TabIndex = 833
        '
        'BunifuFlatButton7
        '
        Me.BunifuFlatButton7.Activecolor = System.Drawing.Color.Green
        Me.BunifuFlatButton7.BackColor = System.Drawing.Color.Green
        Me.BunifuFlatButton7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton7.BorderRadius = 5
        Me.BunifuFlatButton7.ButtonText = "Consultar bienes"
        Me.BunifuFlatButton7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton7.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton7.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BunifuFlatButton7.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton7.Iconimage = Nothing
        Me.BunifuFlatButton7.Iconimage_right = Nothing
        Me.BunifuFlatButton7.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton7.Iconimage_Selected = Nothing
        Me.BunifuFlatButton7.IconMarginLeft = 0
        Me.BunifuFlatButton7.IconMarginRight = 0
        Me.BunifuFlatButton7.IconRightVisible = True
        Me.BunifuFlatButton7.IconRightZoom = 0R
        Me.BunifuFlatButton7.IconVisible = True
        Me.BunifuFlatButton7.IconZoom = 90.0R
        Me.BunifuFlatButton7.IsTab = False
        Me.BunifuFlatButton7.Location = New System.Drawing.Point(22, 1)
        Me.BunifuFlatButton7.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton7.Name = "BunifuFlatButton7"
        Me.BunifuFlatButton7.Normalcolor = System.Drawing.Color.Green
        Me.BunifuFlatButton7.OnHovercolor = System.Drawing.Color.Green
        Me.BunifuFlatButton7.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton7.selected = False
        Me.BunifuFlatButton7.Size = New System.Drawing.Size(95, 22)
        Me.BunifuFlatButton7.TabIndex = 838
        Me.BunifuFlatButton7.Text = "Consultar bienes"
        Me.BunifuFlatButton7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton7.Textcolor = System.Drawing.Color.White
        Me.BunifuFlatButton7.TextFont = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'BunifuFlatButton8
        '
        Me.BunifuFlatButton8.Activecolor = System.Drawing.Color.Green
        Me.BunifuFlatButton8.BackColor = System.Drawing.Color.Green
        Me.BunifuFlatButton8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton8.BorderRadius = 5
        Me.BunifuFlatButton8.ButtonText = "Agregar bienes"
        Me.BunifuFlatButton8.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton8.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton8.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BunifuFlatButton8.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton8.Iconimage = Nothing
        Me.BunifuFlatButton8.Iconimage_right = Nothing
        Me.BunifuFlatButton8.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton8.Iconimage_Selected = Nothing
        Me.BunifuFlatButton8.IconMarginLeft = 0
        Me.BunifuFlatButton8.IconMarginRight = 0
        Me.BunifuFlatButton8.IconRightVisible = True
        Me.BunifuFlatButton8.IconRightZoom = 0R
        Me.BunifuFlatButton8.IconVisible = True
        Me.BunifuFlatButton8.IconZoom = 90.0R
        Me.BunifuFlatButton8.IsTab = False
        Me.BunifuFlatButton8.Location = New System.Drawing.Point(601, 3)
        Me.BunifuFlatButton8.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton8.Name = "BunifuFlatButton8"
        Me.BunifuFlatButton8.Normalcolor = System.Drawing.Color.Green
        Me.BunifuFlatButton8.OnHovercolor = System.Drawing.Color.Green
        Me.BunifuFlatButton8.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton8.selected = False
        Me.BunifuFlatButton8.Size = New System.Drawing.Size(115, 22)
        Me.BunifuFlatButton8.TabIndex = 836
        Me.BunifuFlatButton8.Text = "Agregar bienes"
        Me.BunifuFlatButton8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton8.Textcolor = System.Drawing.Color.White
        Me.BunifuFlatButton8.TextFont = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton8.Visible = False
        '
        'BunifuFlatButton9
        '
        Me.BunifuFlatButton9.Activecolor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.BunifuFlatButton9.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.BunifuFlatButton9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton9.BorderRadius = 5
        Me.BunifuFlatButton9.ButtonText = "Eliminar bienes"
        Me.BunifuFlatButton9.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton9.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton9.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BunifuFlatButton9.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton9.Iconimage = Nothing
        Me.BunifuFlatButton9.Iconimage_right = Nothing
        Me.BunifuFlatButton9.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton9.Iconimage_Selected = Nothing
        Me.BunifuFlatButton9.IconMarginLeft = 0
        Me.BunifuFlatButton9.IconMarginRight = 0
        Me.BunifuFlatButton9.IconRightVisible = True
        Me.BunifuFlatButton9.IconRightZoom = 0R
        Me.BunifuFlatButton9.IconVisible = True
        Me.BunifuFlatButton9.IconZoom = 90.0R
        Me.BunifuFlatButton9.IsTab = False
        Me.BunifuFlatButton9.Location = New System.Drawing.Point(131, 1)
        Me.BunifuFlatButton9.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton9.Name = "BunifuFlatButton9"
        Me.BunifuFlatButton9.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.BunifuFlatButton9.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.BunifuFlatButton9.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton9.selected = False
        Me.BunifuFlatButton9.Size = New System.Drawing.Size(99, 23)
        Me.BunifuFlatButton9.TabIndex = 837
        Me.BunifuFlatButton9.Text = "Eliminar bienes"
        Me.BunifuFlatButton9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton9.Textcolor = System.Drawing.Color.White
        Me.BunifuFlatButton9.TextFont = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(824, 7)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(118, 14)
        Me.Label16.TabIndex = 683
        Me.Label16.Text = "Peso Bruto Total (kgm)"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.AliceBlue
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnConfirmar, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(1080, 30)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnConfirmar
        '
        Me.btnConfirmar.BackColor = System.Drawing.Color.Transparent
        Me.btnConfirmar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnConfirmar.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.btnConfirmar.Image = CType(resources.GetObject("btnConfirmar.Image"), System.Drawing.Image)
        Me.btnConfirmar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnConfirmar.Margin = New System.Windows.Forms.Padding(5, 1, 5, 2)
        Me.btnConfirmar.Name = "btnConfirmar"
        Me.btnConfirmar.Size = New System.Drawing.Size(76, 27)
        Me.btnConfirmar.Text = "Guardar - F2"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 30)
        '
        'GradientPanel4
        '
        Me.GradientPanel4.BackColor = System.Drawing.Color.White
        Me.GradientPanel4.BorderColor = System.Drawing.Color.Gainsboro
        Me.GradientPanel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel4.Controls.Add(Me.ToggleConsultas)
        Me.GradientPanel4.Controls.Add(Me.cbomotivotrasl)
        Me.GradientPanel4.Controls.Add(Me.gpbProveedor)
        Me.GradientPanel4.Controls.Add(Me.GradientPanel5)
        Me.GradientPanel4.Controls.Add(Me.Label12)
        Me.GradientPanel4.Controls.Add(Me.GradientPanel12)
        Me.GradientPanel4.Controls.Add(Me.lsvDetOtroOpera)
        Me.GradientPanel4.Controls.Add(Me.BunifuFlatButton1)
        Me.GradientPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel4.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel4.Name = "GradientPanel4"
        Me.GradientPanel4.Size = New System.Drawing.Size(1080, 250)
        Me.GradientPanel4.TabIndex = 692
        '
        'ToggleConsultas
        '
        Me.ToggleConsultas.ActiveColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.ToggleConsultas.ActiveText = "Web"
        Me.ToggleConsultas.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.ToggleConsultas.InActiveColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.ToggleConsultas.InActiveText = "API"
        Me.ToggleConsultas.Location = New System.Drawing.Point(981, 23)
        Me.ToggleConsultas.MaximumSize = New System.Drawing.Size(119, 32)
        Me.ToggleConsultas.MinimumSize = New System.Drawing.Size(75, 23)
        Me.ToggleConsultas.Name = "ToggleConsultas"
        Me.ToggleConsultas.Size = New System.Drawing.Size(76, 23)
        Me.ToggleConsultas.SliderColor = System.Drawing.Color.Black
        Me.ToggleConsultas.SlidingAngle = 8
        Me.ToggleConsultas.TabIndex = 837
        Me.ToggleConsultas.Text = "ToggleButton21"
        Me.ToggleConsultas.TextColor = System.Drawing.Color.White
        Me.ToggleConsultas.ToggleState = Helios.Cont.Presentation.WinForm.ToggleButton2.ToggleButtonState.OFF
        Me.ToggleConsultas.ToggleStyle = Helios.Cont.Presentation.WinForm.ToggleButton2.ToggleButtonStyle.Android
        '
        'gpbProveedor
        '
        Me.gpbProveedor.Controls.Add(Me.Label22)
        Me.gpbProveedor.Controls.Add(Me.txtdocprovee)
        Me.gpbProveedor.Controls.Add(Me.txtRazoSocprovee)
        Me.gpbProveedor.Controls.Add(Me.txtnumprovee)
        Me.gpbProveedor.Controls.Add(Me.Label19)
        Me.gpbProveedor.Controls.Add(Me.Label20)
        Me.gpbProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpbProveedor.Location = New System.Drawing.Point(364, 46)
        Me.gpbProveedor.Name = "gpbProveedor"
        Me.gpbProveedor.Size = New System.Drawing.Size(337, 106)
        Me.gpbProveedor.TabIndex = 849
        Me.gpbProveedor.TabStop = False
        Me.gpbProveedor.Text = "Proveedor"
        Me.gpbProveedor.Visible = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(20, 57)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(186, 14)
        Me.Label22.TabIndex = 852
        Me.Label22.Text = "Denominación / Apellidos y nombres"
        '
        'txtdocprovee
        '
        Me.txtdocprovee.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtdocprovee.BeforeTouchSize = New System.Drawing.Size(115, 23)
        Me.txtdocprovee.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtdocprovee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtdocprovee.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdocprovee.CornerRadius = 3
        Me.txtdocprovee.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtdocprovee.Enabled = False
        Me.txtdocprovee.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.txtdocprovee.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdocprovee.ForeColor = System.Drawing.SystemColors.Highlight
        Me.txtdocprovee.Location = New System.Drawing.Point(12, 31)
        Me.txtdocprovee.MaxLength = 11
        Me.txtdocprovee.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtdocprovee.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtdocprovee.Name = "txtdocprovee"
        Me.txtdocprovee.ReadOnly = True
        Me.txtdocprovee.Size = New System.Drawing.Size(113, 22)
        Me.txtdocprovee.TabIndex = 851
        '
        'txtRazoSocprovee
        '
        Me.txtRazoSocprovee.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtRazoSocprovee.BeforeTouchSize = New System.Drawing.Size(115, 23)
        Me.txtRazoSocprovee.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtRazoSocprovee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRazoSocprovee.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRazoSocprovee.CornerRadius = 3
        Me.txtRazoSocprovee.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtRazoSocprovee.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.txtRazoSocprovee.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRazoSocprovee.ForeColor = System.Drawing.Color.Black
        Me.txtRazoSocprovee.Location = New System.Drawing.Point(12, 74)
        Me.txtRazoSocprovee.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtRazoSocprovee.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtRazoSocprovee.Name = "txtRazoSocprovee"
        Me.txtRazoSocprovee.ReadOnly = True
        Me.txtRazoSocprovee.Size = New System.Drawing.Size(317, 22)
        Me.txtRazoSocprovee.TabIndex = 850
        '
        'txtnumprovee
        '
        Me.txtnumprovee.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtnumprovee.BeforeTouchSize = New System.Drawing.Size(115, 23)
        Me.txtnumprovee.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtnumprovee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtnumprovee.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnumprovee.CornerRadius = 3
        Me.txtnumprovee.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtnumprovee.FarImage = CType(resources.GetObject("txtnumprovee.FarImage"), System.Drawing.Image)
        Me.txtnumprovee.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.txtnumprovee.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnumprovee.ForeColor = System.Drawing.Color.Black
        Me.txtnumprovee.Location = New System.Drawing.Point(134, 31)
        Me.txtnumprovee.MaxLength = 11
        Me.txtnumprovee.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtnumprovee.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtnumprovee.Name = "txtnumprovee"
        Me.txtnumprovee.Size = New System.Drawing.Size(139, 22)
        Me.txtnumprovee.TabIndex = 849
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(143, 14)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(47, 14)
        Me.Label19.TabIndex = 665
        Me.Label19.Text = "Número"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(20, 16)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(52, 14)
        Me.Label20.TabIndex = 664
        Me.Label20.Text = "Tipo Doc:"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'GradientPanel9
        '
        Me.GradientPanel9.BackColor = System.Drawing.Color.White
        Me.GradientPanel9.BackgroundImage = CType(resources.GetObject("GradientPanel9.BackgroundImage"), System.Drawing.Image)
        Me.GradientPanel9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GradientPanel9.BorderColor = System.Drawing.Color.Silver
        Me.GradientPanel9.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GradientPanel9.Controls.Add(Me.BunifuFlatButton7)
        Me.GradientPanel9.Controls.Add(Me.BunifuFlatButton8)
        Me.GradientPanel9.Controls.Add(Me.BunifuFlatButton9)
        Me.GradientPanel9.Controls.Add(Me.PictureBox1)
        Me.GradientPanel9.Controls.Add(Me.Label16)
        Me.GradientPanel9.Controls.Add(Me.txtTotalPB)
        Me.GradientPanel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel9.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel9.Name = "GradientPanel9"
        Me.GradientPanel9.Size = New System.Drawing.Size(1080, 26)
        Me.GradientPanel9.TabIndex = 690
        '
        'BunifuFlatButton3
        '
        Me.BunifuFlatButton3.Activecolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton3.BackColor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton3.BorderRadius = 0
        Me.BunifuFlatButton3.ButtonText = "TIPO TRANSPORTE"
        Me.BunifuFlatButton3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton3.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton3.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton3.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton3.Iconimage = Nothing
        Me.BunifuFlatButton3.Iconimage_right = Nothing
        Me.BunifuFlatButton3.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton3.Iconimage_Selected = Nothing
        Me.BunifuFlatButton3.IconMarginLeft = 0
        Me.BunifuFlatButton3.IconMarginRight = 0
        Me.BunifuFlatButton3.IconRightVisible = True
        Me.BunifuFlatButton3.IconRightZoom = 0R
        Me.BunifuFlatButton3.IconVisible = True
        Me.BunifuFlatButton3.IconZoom = 90.0R
        Me.BunifuFlatButton3.IsTab = False
        Me.BunifuFlatButton3.Location = New System.Drawing.Point(393, 0)
        Me.BunifuFlatButton3.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton3.Name = "BunifuFlatButton3"
        Me.BunifuFlatButton3.Normalcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton3.OnHovercolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton3.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton3.selected = False
        Me.BunifuFlatButton3.Size = New System.Drawing.Size(130, 18)
        Me.BunifuFlatButton3.TabIndex = 27
        Me.BunifuFlatButton3.Text = "TIPO TRANSPORTE"
        Me.BunifuFlatButton3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton3.Textcolor = System.Drawing.SystemColors.ControlText
        Me.BunifuFlatButton3.TextFont = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'BunifuFlatButton6
        '
        Me.BunifuFlatButton6.Activecolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton6.BackColor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton6.BorderRadius = 0
        Me.BunifuFlatButton6.ButtonText = "PUNTO DE PARTIDA Y LLEGADA"
        Me.BunifuFlatButton6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton6.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton6.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton6.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton6.Iconimage = Nothing
        Me.BunifuFlatButton6.Iconimage_right = Nothing
        Me.BunifuFlatButton6.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton6.Iconimage_Selected = Nothing
        Me.BunifuFlatButton6.IconMarginLeft = 0
        Me.BunifuFlatButton6.IconMarginRight = 0
        Me.BunifuFlatButton6.IconRightVisible = True
        Me.BunifuFlatButton6.IconRightZoom = 0R
        Me.BunifuFlatButton6.IconVisible = True
        Me.BunifuFlatButton6.IconZoom = 90.0R
        Me.BunifuFlatButton6.IsTab = False
        Me.BunifuFlatButton6.Location = New System.Drawing.Point(191, 0)
        Me.BunifuFlatButton6.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton6.Name = "BunifuFlatButton6"
        Me.BunifuFlatButton6.Normalcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton6.OnHovercolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton6.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton6.selected = False
        Me.BunifuFlatButton6.Size = New System.Drawing.Size(175, 18)
        Me.BunifuFlatButton6.TabIndex = 26
        Me.BunifuFlatButton6.Text = "PUNTO DE PARTIDA Y LLEGADA"
        Me.BunifuFlatButton6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton6.Textcolor = System.Drawing.SystemColors.ControlText
        Me.BunifuFlatButton6.TextFont = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'bfbRemitente
        '
        Me.bfbRemitente.Activecolor = System.Drawing.Color.Transparent
        Me.bfbRemitente.BackColor = System.Drawing.Color.Transparent
        Me.bfbRemitente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bfbRemitente.BorderRadius = 0
        Me.bfbRemitente.ButtonText = "EMISION DE GUÍA"
        Me.bfbRemitente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bfbRemitente.DisabledColor = System.Drawing.Color.Gray
        Me.bfbRemitente.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bfbRemitente.Iconcolor = System.Drawing.Color.Transparent
        Me.bfbRemitente.Iconimage = Nothing
        Me.bfbRemitente.Iconimage_right = Nothing
        Me.bfbRemitente.Iconimage_right_Selected = Nothing
        Me.bfbRemitente.Iconimage_Selected = Nothing
        Me.bfbRemitente.IconMarginLeft = 0
        Me.bfbRemitente.IconMarginRight = 0
        Me.bfbRemitente.IconRightVisible = True
        Me.bfbRemitente.IconRightZoom = 0R
        Me.bfbRemitente.IconVisible = True
        Me.bfbRemitente.IconZoom = 90.0R
        Me.bfbRemitente.IsTab = False
        Me.bfbRemitente.Location = New System.Drawing.Point(38, 1)
        Me.bfbRemitente.Margin = New System.Windows.Forms.Padding(2)
        Me.bfbRemitente.Name = "bfbRemitente"
        Me.bfbRemitente.Normalcolor = System.Drawing.Color.Transparent
        Me.bfbRemitente.OnHovercolor = System.Drawing.Color.Transparent
        Me.bfbRemitente.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.bfbRemitente.selected = False
        Me.bfbRemitente.Size = New System.Drawing.Size(130, 18)
        Me.bfbRemitente.TabIndex = 25
        Me.bfbRemitente.Text = "EMISION DE GUÍA"
        Me.bfbRemitente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.bfbRemitente.Textcolor = System.Drawing.SystemColors.ControlText
        Me.bfbRemitente.TextFont = New System.Drawing.Font("Segoe UI Semibold", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'PictureLoad
        '
        Me.PictureLoad.BackColor = System.Drawing.Color.Transparent
        Me.PictureLoad.Image = CType(resources.GetObject("PictureLoad.Image"), System.Drawing.Image)
        Me.PictureLoad.Location = New System.Drawing.Point(405, 25)
        Me.PictureLoad.Name = "PictureLoad"
        Me.PictureLoad.Size = New System.Drawing.Size(22, 21)
        Me.PictureLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureLoad.TabIndex = 832
        Me.PictureLoad.TabStop = False
        Me.PictureLoad.Visible = False
        '
        'GradientPanel7
        '
        Me.GradientPanel7.BackColor = System.Drawing.Color.White
        Me.GradientPanel7.BorderColor = System.Drawing.Color.Gainsboro
        Me.GradientPanel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel7.Controls.Add(Me.ToolStrip1)
        Me.GradientPanel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel7.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel7.Name = "GradientPanel7"
        Me.GradientPanel7.Size = New System.Drawing.Size(1082, 32)
        Me.GradientPanel7.TabIndex = 850
        '
        'GradientPanel2
        '
        Me.GradientPanel2.BackColor = System.Drawing.Color.White
        Me.GradientPanel2.BorderColor = System.Drawing.Color.Gainsboro
        Me.GradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel2.Controls.Add(Me.Label9)
        Me.GradientPanel2.Controls.Add(Me.txtTipoDoc)
        Me.GradientPanel2.Controls.Add(Me.Line21)
        Me.GradientPanel2.Controls.Add(Me.Label6)
        Me.GradientPanel2.Controls.Add(Me.Label23)
        Me.GradientPanel2.Controls.Add(Me.txtRemitente)
        Me.GradientPanel2.Controls.Add(Me.GradientPanel8)
        Me.GradientPanel2.Controls.Add(Me.Label8)
        Me.GradientPanel2.Controls.Add(Me.Label3)
        Me.GradientPanel2.Controls.Add(Me.txtNumeroTD)
        Me.GradientPanel2.Controls.Add(Me.txtserieAfec)
        Me.GradientPanel2.Controls.Add(Me.txtcomprane)
        Me.GradientPanel2.Controls.Add(Me.Label24)
        Me.GradientPanel2.Controls.Add(Me.txtnumerAfec)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 32)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(1082, 86)
        Me.GradientPanel2.TabIndex = 851
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(609, 37)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(101, 14)
        Me.Label9.TabIndex = 679
        Me.Label9.Text = "Nombre Remitente"
        '
        'Line21
        '
        Me.Line21.LineColor = System.Drawing.Color.Gainsboro
        Me.Line21.Location = New System.Drawing.Point(375, 33)
        Me.Line21.Name = "Line21"
        Me.Line21.Size = New System.Drawing.Size(1, 45)
        Me.Line21.TabIndex = 850
        Me.Line21.Text = "Line21"
        '
        'GradientPanel8
        '
        Me.GradientPanel8.BorderColor = System.Drawing.Color.MediumBlue
        Me.GradientPanel8.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.GradientPanel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel8.Controls.Add(Me.sliderTop)
        Me.GradientPanel8.Controls.Add(Me.BunifuFlatButton3)
        Me.GradientPanel8.Controls.Add(Me.BunifuFlatButton6)
        Me.GradientPanel8.Controls.Add(Me.bfbRemitente)
        Me.GradientPanel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel8.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel8.Name = "GradientPanel8"
        Me.GradientPanel8.Size = New System.Drawing.Size(1080, 28)
        Me.GradientPanel8.TabIndex = 856
        '
        'sliderTop
        '
        Me.sliderTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.sliderTop.BackgroundImage = CType(resources.GetObject("sliderTop.BackgroundImage"), System.Drawing.Image)
        Me.sliderTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.sliderTop.Location = New System.Drawing.Point(28, 22)
        Me.sliderTop.Name = "sliderTop"
        Me.sliderTop.Size = New System.Drawing.Size(156, 4)
        Me.sliderTop.TabIndex = 521
        Me.sliderTop.TabStop = False
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BackColor = System.Drawing.Color.White
        Me.GradientPanel1.BorderColor = System.Drawing.Color.Gainsboro
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.GradientPanel4)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 118)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(1082, 252)
        Me.GradientPanel1.TabIndex = 853
        '
        'GradientPanel6
        '
        Me.GradientPanel6.BackColor = System.Drawing.Color.White
        Me.GradientPanel6.BorderColor = System.Drawing.Color.Gainsboro
        Me.GradientPanel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel6.Controls.Add(Me.GradientPanel9)
        Me.GradientPanel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel6.Location = New System.Drawing.Point(0, 370)
        Me.GradientPanel6.Name = "GradientPanel6"
        Me.GradientPanel6.Size = New System.Drawing.Size(1082, 28)
        Me.GradientPanel6.TabIndex = 854
        '
        'GradientPanel3
        '
        Me.GradientPanel3.BackColor = System.Drawing.Color.White
        Me.GradientPanel3.BorderColor = System.Drawing.Color.Gainsboro
        Me.GradientPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel3.Controls.Add(Me.dgAgregarBien)
        Me.GradientPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel3.Location = New System.Drawing.Point(0, 398)
        Me.GradientPanel3.Name = "GradientPanel3"
        Me.GradientPanel3.Size = New System.Drawing.Size(1082, 169)
        Me.GradientPanel3.TabIndex = 855
        '
        'cbTipotras
        '
        Me.cbTipotras.BackColor = System.Drawing.Color.White
        Me.cbTipotras.BeforeTouchSize = New System.Drawing.Size(278, 21)
        Me.cbTipotras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTipotras.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTipotras.Location = New System.Drawing.Point(-12, 44)
        Me.cbTipotras.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.cbTipotras.MetroColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.cbTipotras.Name = "cbTipotras"
        Me.cbTipotras.Size = New System.Drawing.Size(278, 21)
        Me.cbTipotras.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cbTipotras.TabIndex = 681
        '
        'FormEmitirGuiaRemision
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.CaptionForeColor = System.Drawing.SystemColors.HotTrack
        Me.ClientSize = New System.Drawing.Size(1082, 567)
        Me.Controls.Add(Me.GradientPanel3)
        Me.Controls.Add(Me.GradientPanel6)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.GradientPanel2)
        Me.Controls.Add(Me.GradientPanel7)
        Me.Name = "FormEmitirGuiaRemision"
        Me.ShowIcon = False
        Me.Text = "EMITIR GUIA DE REMISION"
        CType(Me.GradientPanel12, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel12.ResumeLayout(False)
        Me.GradientPanel12.PerformLayout()
        CType(Me.txtotraguia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.combotipoGuia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel5.ResumeLayout(False)
        Me.GradientPanel5.PerformLayout()
        CType(Me.cbTipoDocdes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtmotivotraslado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDAM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbtipoDesOtro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDnidesti, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtdatosDesti, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbomotivotrasl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxExt6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgAgregarBien, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoDoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumeroTD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRemitente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtnumerAfec, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcomprane, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtserieAfec, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalPB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.GradientPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel4.ResumeLayout(False)
        Me.GradientPanel4.PerformLayout()
        Me.gpbProveedor.ResumeLayout(False)
        Me.gpbProveedor.PerformLayout()
        CType(Me.txtdocprovee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRazoSocprovee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtnumprovee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel9.ResumeLayout(False)
        Me.GradientPanel9.PerformLayout()
        CType(Me.PictureLoad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel7.ResumeLayout(False)
        Me.GradientPanel7.PerformLayout()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        Me.GradientPanel2.PerformLayout()
        CType(Me.GradientPanel8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel8.ResumeLayout(False)
        CType(Me.sliderTop, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        CType(Me.GradientPanel6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel6.ResumeLayout(False)
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel3.ResumeLayout(False)
        CType(Me.cbTipotras, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GradientPanel12 As Tools.GradientPanel
    Friend WithEvents Label12 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents cb As Tools.ComboBoxAdv
    Friend WithEvents TextBoxExt6 As Tools.TextBoxExt
    Friend WithEvents Label14 As Label
    Private WithEvents BunifuFlatButton4 As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents btnEliminarBien As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents Label25 As Label
    Friend WithEvents combotipoGuia As Tools.ComboBoxAdv
    Friend WithEvents Label15 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Private WithEvents BunifuFlatButton5 As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents PictureLoad As PictureBox
    Friend WithEvents BgProveedor As System.ComponentModel.BackgroundWorker
    Friend WithEvents GradientPanel5 As Tools.GradientPanel
    Friend WithEvents GradientPanel4 As Tools.GradientPanel
    Friend WithEvents lsvDetOtroOpera As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Private WithEvents BunifuFlatButton1 As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents cbomotivotrasl As Tools.ComboBoxAdv
    Friend WithEvents Label2 As Label
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents dgAgregarBien As Grid.Grouping.GridGroupingControl
    Friend WithEvents Label16 As Label
    Friend WithEvents GradientPanel9 As Tools.GradientPanel
    Private WithEvents BunifuFlatButton3 As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents BunifuFlatButton6 As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents bfbRemitente As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents txtTotalPB As Tools.TextBoxExt
    Private WithEvents BunifuFlatButton7 As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents BunifuFlatButton8 As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents BunifuFlatButton9 As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnConfirmar As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents txtDAM As Tools.TextBoxExt
    Friend WithEvents txtmotivotraslado As Tools.TextBoxExt
    Friend WithEvents txtotraguia As Tools.TextBoxExt
    Friend WithEvents Label1 As Label
    Friend WithEvents gpbProveedor As GroupBox
    Friend WithEvents Label22 As Label
    Friend WithEvents txtdocprovee As Tools.TextBoxExt
    Friend WithEvents txtRazoSocprovee As Tools.TextBoxExt
    Friend WithEvents txtnumprovee As Tools.TextBoxExt
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents ToggleConsultas As ToggleButton2
    Friend WithEvents Label4 As Label
    Friend WithEvents cbtipoDesOtro As Tools.ComboBoxAdv
    Friend WithEvents Label41 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents txtdatosDesti As Tools.TextBoxExt
    Friend WithEvents txtDnidesti As Tools.TextBoxExt
    Friend WithEvents Label40 As Label
    Friend WithEvents cbTipoDocdes As Tools.ComboBoxAdv
    Friend WithEvents Label3 As Label
    Friend WithEvents txtnumerAfec As Tools.TextBoxExt
    Friend WithEvents Label23 As Label
    Friend WithEvents txtcomprane As Tools.TextBoxExt
    Friend WithEvents Label24 As Label
    Friend WithEvents txtserieAfec As Tools.TextBoxExt
    Friend WithEvents txtTipoDoc As Tools.TextBoxExt
    Friend WithEvents Label6 As Label
    Friend WithEvents txtNumeroTD As Tools.TextBoxExt
    Friend WithEvents Label8 As Label
    Friend WithEvents txtRemitente As Tools.TextBoxExt
    Friend WithEvents GradientPanel7 As Tools.GradientPanel
    Friend WithEvents GradientPanel2 As Tools.GradientPanel
    Friend WithEvents GradientPanel1 As Tools.GradientPanel
    Friend WithEvents GradientPanel6 As Tools.GradientPanel
    Friend WithEvents GradientPanel8 As Tools.GradientPanel
    Private WithEvents sliderTop As PictureBox
    Friend WithEvents Label9 As Label
    Friend WithEvents GradientPanel3 As Tools.GradientPanel
    Friend WithEvents cbTipotras As Tools.ComboBoxAdv
    Friend WithEvents Line21 As Line2
End Class

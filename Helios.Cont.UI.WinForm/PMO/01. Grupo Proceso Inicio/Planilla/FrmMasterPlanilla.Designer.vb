<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMasterPlanilla
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMasterPlanilla))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ImprimirToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.NuevoToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.AbrirToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.GuardarToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ImprimirToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.AyudaToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblEstado = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.txtOcupacion = New System.Windows.Forms.TextBox()
        Me.txtPeriodo = New System.Windows.Forms.TextBox()
        Me.txtPeriocidad = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.dgvPlazo = New System.Windows.Forms.DataGridView()
        Me.INICIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FINALIZACION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DIAS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MESES = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AÑOS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dgvIngresos = New System.Windows.Forms.DataGridView()
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodSunat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CtaCtble = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ordinaria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Sobretiempo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RemuneracionDiaDeDescanso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RecumneracionComplement = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OtrasDePeriocidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalIngresos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtminutosporhora = New System.Windows.Forms.TextBox()
        Me.txtmesporaño = New System.Windows.Forms.TextBox()
        Me.txtdiasalasemana = New System.Windows.Forms.TextBox()
        Me.txtdiasalmes = New System.Windows.Forms.TextBox()
        Me.txtdiasalaño = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.ToolStrip1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvPlazo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvIngresos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackgroundImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.background
        Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImprimirToolStripButton, Me.NuevoToolStripButton, Me.AbrirToolStripButton, Me.GuardarToolStripButton, Me.ImprimirToolStripButton1, Me.toolStripSeparator, Me.AyudaToolStripButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(708, 25)
        Me.ToolStrip1.TabIndex = 490
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ImprimirToolStripButton
        '
        Me.ImprimirToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ImprimirToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ImprimirToolStripButton.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.arrow_circle_135_left
        Me.ImprimirToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ImprimirToolStripButton.Name = "ImprimirToolStripButton"
        Me.ImprimirToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.ImprimirToolStripButton.Text = "Volver"
        '
        'NuevoToolStripButton
        '
        Me.NuevoToolStripButton.Image = CType(resources.GetObject("NuevoToolStripButton.Image"), System.Drawing.Image)
        Me.NuevoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NuevoToolStripButton.Name = "NuevoToolStripButton"
        Me.NuevoToolStripButton.Size = New System.Drawing.Size(58, 22)
        Me.NuevoToolStripButton.Text = "&Nuevo"
        '
        'AbrirToolStripButton
        '
        Me.AbrirToolStripButton.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.pencil
        Me.AbrirToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AbrirToolStripButton.Name = "AbrirToolStripButton"
        Me.AbrirToolStripButton.Size = New System.Drawing.Size(55, 22)
        Me.AbrirToolStripButton.Text = "&Editar"
        '
        'GuardarToolStripButton
        '
        Me.GuardarToolStripButton.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.cross
        Me.GuardarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.GuardarToolStripButton.Name = "GuardarToolStripButton"
        Me.GuardarToolStripButton.Size = New System.Drawing.Size(63, 22)
        Me.GuardarToolStripButton.Text = "Eliminar"
        '
        'ImprimirToolStripButton1
        '
        Me.ImprimirToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ImprimirToolStripButton1.Image = CType(resources.GetObject("ImprimirToolStripButton1.Image"), System.Drawing.Image)
        Me.ImprimirToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ImprimirToolStripButton1.Name = "ImprimirToolStripButton1"
        Me.ImprimirToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ImprimirToolStripButton1.Text = "&Imprimir"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'AyudaToolStripButton
        '
        Me.AyudaToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.AyudaToolStripButton.Image = CType(resources.GetObject("AyudaToolStripButton.Image"), System.Drawing.Image)
        Me.AyudaToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AyudaToolStripButton.Name = "AyudaToolStripButton"
        Me.AyudaToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.AyudaToolStripButton.Text = "Ay&uda"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'lblEstado
        '
        Me.lblEstado.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(81, 22)
        Me.lblEstado.Text = "Nuevo Registro"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.ToolStrip2.BackgroundImage = CType(resources.GetObject("ToolStrip2.BackgroundImage"), System.Drawing.Image)
        Me.ToolStrip2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.lblEstado})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 25)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(708, 25)
        Me.ToolStrip2.TabIndex = 491
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 501
        Me.Label1.Text = "PERIODO:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 44)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(127, 13)
        Me.Label5.TabIndex = 505
        Me.Label5.Text = "PERIOCIDAD DE PAGO:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(385, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(137, 13)
        Me.Label6.TabIndex = 506
        Me.Label6.Text = "OCUPACION ESPECIFICA:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(93, 13)
        Me.Label7.TabIndex = 507
        Me.Label7.Text = "Fecha de Ingreso:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LinkLabel1)
        Me.GroupBox1.Controls.Add(Me.txtOcupacion)
        Me.GroupBox1.Controls.Add(Me.txtPeriodo)
        Me.GroupBox1.Controls.Add(Me.txtPeriocidad)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 53)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(687, 73)
        Me.GroupBox1.TabIndex = 508
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos:"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.LinkColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LinkLabel1.Location = New System.Drawing.Point(525, 31)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(44, 13)
        Me.LinkLabel1.TabIndex = 515
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Agregar"
        '
        'txtOcupacion
        '
        Me.txtOcupacion.Location = New System.Drawing.Point(528, 47)
        Me.txtOcupacion.Name = "txtOcupacion"
        Me.txtOcupacion.Size = New System.Drawing.Size(137, 20)
        Me.txtOcupacion.TabIndex = 514
        '
        'txtPeriodo
        '
        Me.txtPeriodo.Location = New System.Drawing.Point(173, 9)
        Me.txtPeriodo.Name = "txtPeriodo"
        Me.txtPeriodo.Size = New System.Drawing.Size(137, 20)
        Me.txtPeriodo.TabIndex = 513
        '
        'txtPeriocidad
        '
        Me.txtPeriocidad.Location = New System.Drawing.Point(173, 41)
        Me.txtPeriocidad.Name = "txtPeriocidad"
        Me.txtPeriocidad.Size = New System.Drawing.Size(187, 20)
        Me.txtPeriocidad.TabIndex = 511
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DateTimePicker2)
        Me.GroupBox2.Controls.Add(Me.dgvPlazo)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Location = New System.Drawing.Point(259, 134)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(440, 137)
        Me.GroupBox2.TabIndex = 509
        Me.GroupBox2.TabStop = False
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Location = New System.Drawing.Point(110, 19)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker2.TabIndex = 514
        '
        'dgvPlazo
        '
        Me.dgvPlazo.AllowUserToDeleteRows = False
        Me.dgvPlazo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPlazo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.INICIO, Me.FINALIZACION, Me.DIAS, Me.MESES, Me.AÑOS})
        Me.dgvPlazo.Location = New System.Drawing.Point(110, 53)
        Me.dgvPlazo.Name = "dgvPlazo"
        Me.dgvPlazo.RowHeadersVisible = False
        Me.dgvPlazo.Size = New System.Drawing.Size(325, 78)
        Me.dgvPlazo.TabIndex = 509
        '
        'INICIO
        '
        Me.INICIO.HeaderText = "INICIO"
        Me.INICIO.Name = "INICIO"
        Me.INICIO.Width = 80
        '
        'FINALIZACION
        '
        Me.FINALIZACION.HeaderText = "FINALIZACION"
        Me.FINALIZACION.Name = "FINALIZACION"
        Me.FINALIZACION.Width = 90
        '
        'DIAS
        '
        Me.DIAS.HeaderText = "DIAS"
        Me.DIAS.Name = "DIAS"
        Me.DIAS.Width = 50
        '
        'MESES
        '
        Me.MESES.HeaderText = "MESES"
        Me.MESES.Name = "MESES"
        Me.MESES.Width = 50
        '
        'AÑOS
        '
        Me.AÑOS.HeaderText = "AÑOS"
        Me.AÑOS.Name = "AÑOS"
        Me.AÑOS.Width = 50
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(11, 53)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(93, 13)
        Me.Label8.TabIndex = 508
        Me.Label8.Text = "Plazo Contractual:"
        '
        'dgvIngresos
        '
        Me.dgvIngresos.AllowUserToDeleteRows = False
        Me.dgvIngresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvIngresos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Codigo, Me.CodSunat, Me.CtaCtble, Me.Descripcion, Me.Ordinaria, Me.Sobretiempo, Me.RemuneracionDiaDeDescanso, Me.RecumneracionComplement, Me.OtrasDePeriocidad, Me.TotalIngresos})
        Me.dgvIngresos.Location = New System.Drawing.Point(22, 327)
        Me.dgvIngresos.Name = "dgvIngresos"
        Me.dgvIngresos.RowHeadersVisible = False
        Me.dgvIngresos.Size = New System.Drawing.Size(655, 157)
        Me.dgvIngresos.TabIndex = 510
        '
        'Codigo
        '
        Me.Codigo.HeaderText = "Cod"
        Me.Codigo.Name = "Codigo"
        Me.Codigo.Width = 40
        '
        'CodSunat
        '
        Me.CodSunat.HeaderText = "CodSunat"
        Me.CodSunat.Name = "CodSunat"
        Me.CodSunat.Width = 40
        '
        'CtaCtble
        '
        Me.CtaCtble.HeaderText = "CtaCtlb"
        Me.CtaCtble.Name = "CtaCtble"
        Me.CtaCtble.Width = 40
        '
        'Descripcion
        '
        Me.Descripcion.HeaderText = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.Width = 170
        '
        'Ordinaria
        '
        Me.Ordinaria.HeaderText = "Ordinaria"
        Me.Ordinaria.Name = "Ordinaria"
        Me.Ordinaria.Width = 60
        '
        'Sobretiempo
        '
        Me.Sobretiempo.HeaderText = "Sobretiempo"
        Me.Sobretiempo.Name = "Sobretiempo"
        Me.Sobretiempo.Width = 60
        '
        'RemuneracionDiaDeDescanso
        '
        Me.RemuneracionDiaDeDescanso.HeaderText = "DescansoYFeriados"
        Me.RemuneracionDiaDeDescanso.Name = "RemuneracionDiaDeDescanso"
        Me.RemuneracionDiaDeDescanso.Width = 60
        '
        'RecumneracionComplement
        '
        Me.RecumneracionComplement.HeaderText = "ComplImpresi"
        Me.RecumneracionComplement.Name = "RecumneracionComplement"
        Me.RecumneracionComplement.Width = 60
        '
        'OtrasDePeriocidad
        '
        Me.OtrasDePeriocidad.HeaderText = "OtrasPeriocidad"
        Me.OtrasDePeriocidad.Name = "OtrasDePeriocidad"
        Me.OtrasDePeriocidad.Width = 60
        '
        'TotalIngresos
        '
        Me.TotalIngresos.HeaderText = "TotalIngresos"
        Me.TotalIngresos.Name = "TotalIngresos"
        Me.TotalIngresos.Width = 60
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TextBox1)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.txtminutosporhora)
        Me.GroupBox3.Controls.Add(Me.txtmesporaño)
        Me.GroupBox3.Controls.Add(Me.txtdiasalasemana)
        Me.GroupBox3.Controls.Add(Me.txtdiasalmes)
        Me.GroupBox3.Controls.Add(Me.txtdiasalaño)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Location = New System.Drawing.Point(26, 132)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(227, 166)
        Me.GroupBox3.TabIndex = 511
        Me.GroupBox3.TabStop = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(158, 117)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(55, 20)
        Me.TextBox1.TabIndex = 519
        Me.TextBox1.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 120)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(123, 13)
        Me.Label2.TabIndex = 518
        Me.Label2.Text = "Horas de labor por 1 dia:"
        '
        'txtminutosporhora
        '
        Me.txtminutosporhora.Location = New System.Drawing.Point(158, 140)
        Me.txtminutosporhora.Name = "txtminutosporhora"
        Me.txtminutosporhora.Size = New System.Drawing.Size(55, 20)
        Me.txtminutosporhora.TabIndex = 517
        Me.txtminutosporhora.Text = "0"
        '
        'txtmesporaño
        '
        Me.txtmesporaño.Location = New System.Drawing.Point(158, 93)
        Me.txtmesporaño.Name = "txtmesporaño"
        Me.txtmesporaño.Size = New System.Drawing.Size(55, 20)
        Me.txtmesporaño.TabIndex = 516
        Me.txtmesporaño.Text = "0"
        '
        'txtdiasalasemana
        '
        Me.txtdiasalasemana.Location = New System.Drawing.Point(158, 70)
        Me.txtdiasalasemana.Name = "txtdiasalasemana"
        Me.txtdiasalasemana.Size = New System.Drawing.Size(55, 20)
        Me.txtdiasalasemana.TabIndex = 515
        Me.txtdiasalasemana.Text = "0"
        '
        'txtdiasalmes
        '
        Me.txtdiasalmes.Location = New System.Drawing.Point(158, 46)
        Me.txtdiasalmes.Name = "txtdiasalmes"
        Me.txtdiasalmes.Size = New System.Drawing.Size(55, 20)
        Me.txtdiasalmes.TabIndex = 514
        Me.txtdiasalmes.Text = "0"
        '
        'txtdiasalaño
        '
        Me.txtdiasalaño.Location = New System.Drawing.Point(158, 20)
        Me.txtdiasalaño.Name = "txtdiasalaño"
        Me.txtdiasalaño.Size = New System.Drawing.Size(55, 20)
        Me.txtdiasalaño.TabIndex = 513
        Me.txtdiasalaño.Text = "0"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 150)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(84, 13)
        Me.Label13.TabIndex = 512
        Me.Label13.Text = "Minuto por hora:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(5, 96)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(130, 13)
        Me.Label12.TabIndex = 511
        Me.Label12.Text = "numero de mes de un año"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 73)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(149, 13)
        Me.Label11.TabIndex = 510
        Me.Label11.Text = "Numeros de dias a la semana:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 48)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(122, 13)
        Me.Label10.TabIndex = 509
        Me.Label10.Text = "Numeros de dias al mes:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(121, 13)
        Me.Label9.TabIndex = 508
        Me.Label9.Text = "Numeros de dias al año:"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.LinkColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LinkLabel2.Location = New System.Drawing.Point(23, 311)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(116, 13)
        Me.LinkLabel2.TabIndex = 516
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Agregar Ingreso Sunat:"
        '
        'FrmMasterPlanilla
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(708, 531)
        Me.Controls.Add(Me.LinkLabel2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.dgvIngresos)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FrmMasterPlanilla"
        Me.Text = "FrmMasterPlanilla"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgvPlazo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvIngresos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ImprimirToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents NuevoToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents AbrirToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents GuardarToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ImprimirToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AyudaToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblEstado As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPeriodo As System.Windows.Forms.TextBox
    Friend WithEvents txtPeriocidad As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgvPlazo As System.Windows.Forms.DataGridView
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dgvIngresos As System.Windows.Forms.DataGridView
    Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodSunat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CtaCtble As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ordinaria As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Sobretiempo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RemuneracionDiaDeDescanso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RecumneracionComplement As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OtrasDePeriocidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalIngresos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtminutosporhora As System.Windows.Forms.TextBox
    Friend WithEvents txtmesporaño As System.Windows.Forms.TextBox
    Friend WithEvents txtdiasalasemana As System.Windows.Forms.TextBox
    Friend WithEvents txtdiasalmes As System.Windows.Forms.TextBox
    Friend WithEvents txtdiasalaño As System.Windows.Forms.TextBox
    Friend WithEvents INICIO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FINALIZACION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DIAS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MESES As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AÑOS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtOcupacion As System.Windows.Forms.TextBox
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
End Class

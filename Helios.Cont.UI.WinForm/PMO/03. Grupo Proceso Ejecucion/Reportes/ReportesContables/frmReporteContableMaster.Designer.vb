<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteContableMaster
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReporteContableMaster))
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.ToolStrip4 = New System.Windows.Forms.ToolStrip()
        Me.lblTitulo = New System.Windows.Forms.ToolStripLabel()
        Me.lblPerido = New System.Windows.Forms.ToolStripLabel()
        Me.LinkLabel9 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel10 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel11 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel5 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel6 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel7 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel()
        Me.lblLibroDiario = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtpAnio = New System.Windows.Forms.DateTimePicker()
        Me.dtpPeriodoAnio = New System.Windows.Forms.DateTimePicker()
        Me.rbTodo = New System.Windows.Forms.RadioButton()
        Me.dtpPeriodoMes = New System.Windows.Forms.DateTimePicker()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.txtHastaAnio = New System.Windows.Forms.MaskedTextBox()
        Me.txtDesdeAnio = New System.Windows.Forms.MaskedTextBox()
        Me.txtHastaD = New System.Windows.Forms.TextBox()
        Me.txtDesdeA = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rbAcumulado = New System.Windows.Forms.RadioButton()
        Me.rbMensual = New System.Windows.Forms.RadioButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDebeSM = New System.Windows.Forms.TextBox()
        Me.txtHaberSM = New System.Windows.Forms.TextBox()
        Me.txtHaberDS = New System.Windows.Forms.TextBox()
        Me.txtDebeSS = New System.Windows.Forms.TextBox()
        Me.txtDebeDS = New System.Windows.Forms.TextBox()
        Me.txtHaberSS = New System.Windows.Forms.TextBox()
        Me.txtHaberDM = New System.Windows.Forms.TextBox()
        Me.txtDebeDM = New System.Windows.Forms.TextBox()
        Me.dgvMovimiento = New System.Windows.Forms.DataGridView()
        Me.cuenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.debeSoles = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.haberSoles = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.debeSaldo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.haberSaldo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.debeUSD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.haberUSD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.debeSaldoUSD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.haberSaldoUSD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Panel3.SuspendLayout()
        Me.ToolStrip4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvMovimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Panel3.Controls.Add(Me.ToolStrip4)
        Me.Panel3.Controls.Add(Me.LinkLabel9)
        Me.Panel3.Controls.Add(Me.LinkLabel10)
        Me.Panel3.Controls.Add(Me.LinkLabel11)
        Me.Panel3.Controls.Add(Me.LinkLabel5)
        Me.Panel3.Controls.Add(Me.LinkLabel6)
        Me.Panel3.Controls.Add(Me.LinkLabel7)
        Me.Panel3.Controls.Add(Me.LinkLabel4)
        Me.Panel3.Controls.Add(Me.lblLibroDiario)
        Me.Panel3.Controls.Add(Me.LinkLabel2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 507)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(897, 117)
        Me.Panel3.TabIndex = 16
        '
        'ToolStrip4
        '
        Me.ToolStrip4.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.ToolStrip4.BackgroundImage = CType(resources.GetObject("ToolStrip4.BackgroundImage"), System.Drawing.Image)
        Me.ToolStrip4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip4.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblTitulo, Me.lblPerido})
        Me.ToolStrip4.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip4.Name = "ToolStrip4"
        Me.ToolStrip4.Size = New System.Drawing.Size(897, 25)
        Me.ToolStrip4.TabIndex = 303
        Me.ToolStrip4.Text = "ToolStrip4"
        '
        'lblTitulo
        '
        Me.lblTitulo.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblTitulo.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.lblTitulo.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.Information_icon
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(74, 22)
        Me.lblTitulo.Text = "PERIODO:"
        Me.lblTitulo.Visible = False
        '
        'lblPerido
        '
        Me.lblPerido.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPerido.ForeColor = System.Drawing.Color.AliceBlue
        Me.lblPerido.Name = "lblPerido"
        Me.lblPerido.Size = New System.Drawing.Size(54, 22)
        Me.lblPerido.Text = "01/2014"
        Me.lblPerido.Visible = False
        '
        'LinkLabel9
        '
        Me.LinkLabel9.AutoSize = True
        Me.LinkLabel9.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.LinkLabel9.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel9.LinkColor = System.Drawing.SystemColors.HotTrack
        Me.LinkLabel9.Location = New System.Drawing.Point(595, 64)
        Me.LinkLabel9.Name = "LinkLabel9"
        Me.LinkLabel9.Size = New System.Drawing.Size(247, 13)
        Me.LinkLabel9.TabIndex = 302
        Me.LinkLabel9.TabStop = True
        Me.LinkLabel9.Text = "10. ESTADO DE GANANCIAS Y PERDIDAS (EXCEL)"
        '
        'LinkLabel10
        '
        Me.LinkLabel10.AutoSize = True
        Me.LinkLabel10.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.LinkLabel10.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel10.LinkColor = System.Drawing.SystemColors.HotTrack
        Me.LinkLabel10.Location = New System.Drawing.Point(595, 41)
        Me.LinkLabel10.Name = "LinkLabel10"
        Me.LinkLabel10.Size = New System.Drawing.Size(157, 13)
        Me.LinkLabel10.TabIndex = 301
        Me.LinkLabel10.TabStop = True
        Me.LinkLabel10.Text = "9.  BALANCE GENERAL (EXCEL)"
        '
        'LinkLabel11
        '
        Me.LinkLabel11.AutoSize = True
        Me.LinkLabel11.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.LinkLabel11.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel11.LinkColor = System.Drawing.SystemColors.HotTrack
        Me.LinkLabel11.Location = New System.Drawing.Point(595, 88)
        Me.LinkLabel11.Name = "LinkLabel11"
        Me.LinkLabel11.Size = New System.Drawing.Size(150, 13)
        Me.LinkLabel11.TabIndex = 300
        Me.LinkLabel11.TabStop = True
        Me.LinkLabel11.Text = "11. FLUJO EFECTIVO (EXCEL)"
        '
        'LinkLabel5
        '
        Me.LinkLabel5.AutoSize = True
        Me.LinkLabel5.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.LinkLabel5.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel5.LinkColor = System.Drawing.SystemColors.HotTrack
        Me.LinkLabel5.Location = New System.Drawing.Point(298, 85)
        Me.LinkLabel5.Name = "LinkLabel5"
        Me.LinkLabel5.Size = New System.Drawing.Size(127, 13)
        Me.LinkLabel5.TabIndex = 299
        Me.LinkLabel5.TabStop = True
        Me.LinkLabel5.Text = "6.  INFORME POR CLASE"
        '
        'LinkLabel6
        '
        Me.LinkLabel6.AutoSize = True
        Me.LinkLabel6.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.LinkLabel6.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel6.LinkColor = System.Drawing.SystemColors.HotTrack
        Me.LinkLabel6.Location = New System.Drawing.Point(298, 63)
        Me.LinkLabel6.Name = "LinkLabel6"
        Me.LinkLabel6.Size = New System.Drawing.Size(227, 13)
        Me.LinkLabel6.TabIndex = 298
        Me.LinkLabel6.TabStop = True
        Me.LinkLabel6.Text = "5.  INFORME SUNAT POR CUENTA CONTABLE"
        '
        'LinkLabel7
        '
        Me.LinkLabel7.AutoSize = True
        Me.LinkLabel7.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.LinkLabel7.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel7.LinkColor = System.Drawing.SystemColors.HotTrack
        Me.LinkLabel7.Location = New System.Drawing.Point(298, 41)
        Me.LinkLabel7.Name = "LinkLabel7"
        Me.LinkLabel7.Size = New System.Drawing.Size(191, 13)
        Me.LinkLabel7.TabIndex = 297
        Me.LinkLabel7.TabStop = True
        Me.LinkLabel7.Text = "4.  INFORME POR CUENTA CONTABLE"
        '
        'LinkLabel4
        '
        Me.LinkLabel4.AutoSize = True
        Me.LinkLabel4.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.LinkLabel4.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel4.LinkColor = System.Drawing.SystemColors.HotTrack
        Me.LinkLabel4.Location = New System.Drawing.Point(30, 85)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(92, 13)
        Me.LinkLabel4.TabIndex = 295
        Me.LinkLabel4.TabStop = True
        Me.LinkLabel4.Text = "3.  LIBRO MAYOR"
        '
        'lblLibroDiario
        '
        Me.lblLibroDiario.AutoSize = True
        Me.lblLibroDiario.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblLibroDiario.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.lblLibroDiario.LinkColor = System.Drawing.SystemColors.HotTrack
        Me.lblLibroDiario.Location = New System.Drawing.Point(30, 63)
        Me.lblLibroDiario.Name = "lblLibroDiario"
        Me.lblLibroDiario.Size = New System.Drawing.Size(93, 13)
        Me.lblLibroDiario.TabIndex = 294
        Me.lblLibroDiario.TabStop = True
        Me.lblLibroDiario.Text = "2.  LIBRO DIARIO"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.LinkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel2.LinkColor = System.Drawing.SystemColors.HotTrack
        Me.LinkLabel2.Location = New System.Drawing.Point(30, 41)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(147, 13)
        Me.LinkLabel2.TabIndex = 293
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "1.  HOJA DE TRABAJO FINAL"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtpAnio)
        Me.GroupBox1.Controls.Add(Me.dtpPeriodoAnio)
        Me.GroupBox1.Controls.Add(Me.rbTodo)
        Me.GroupBox1.Controls.Add(Me.dtpPeriodoMes)
        Me.GroupBox1.Controls.Add(Me.btnBuscar)
        Me.GroupBox1.Controls.Add(Me.txtHastaAnio)
        Me.GroupBox1.Controls.Add(Me.txtDesdeAnio)
        Me.GroupBox1.Controls.Add(Me.txtHastaD)
        Me.GroupBox1.Controls.Add(Me.txtDesdeA)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.rbAcumulado)
        Me.GroupBox1.Controls.Add(Me.rbMensual)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 435)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(897, 72)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Buscar por:"
        '
        'dtpAnio
        '
        Me.dtpAnio.CustomFormat = "yyyy"
        Me.dtpAnio.Enabled = False
        Me.dtpAnio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpAnio.Location = New System.Drawing.Point(776, 33)
        Me.dtpAnio.Name = "dtpAnio"
        Me.dtpAnio.ShowUpDown = True
        Me.dtpAnio.Size = New System.Drawing.Size(56, 20)
        Me.dtpAnio.TabIndex = 64
        '
        'dtpPeriodoAnio
        '
        Me.dtpPeriodoAnio.CustomFormat = "yyyy"
        Me.dtpPeriodoAnio.Enabled = False
        Me.dtpPeriodoAnio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpPeriodoAnio.Location = New System.Drawing.Point(266, 29)
        Me.dtpPeriodoAnio.Name = "dtpPeriodoAnio"
        Me.dtpPeriodoAnio.ShowUpDown = True
        Me.dtpPeriodoAnio.Size = New System.Drawing.Size(56, 20)
        Me.dtpPeriodoAnio.TabIndex = 63
        '
        'rbTodo
        '
        Me.rbTodo.AutoSize = True
        Me.rbTodo.Checked = True
        Me.rbTodo.Location = New System.Drawing.Point(725, 19)
        Me.rbTodo.Name = "rbTodo"
        Me.rbTodo.Size = New System.Drawing.Size(49, 17)
        Me.rbTodo.TabIndex = 62
        Me.rbTodo.TabStop = True
        Me.rbTodo.Text = "Todo"
        Me.rbTodo.UseVisualStyleBackColor = True
        '
        'dtpPeriodoMes
        '
        Me.dtpPeriodoMes.CustomFormat = "MMMM"
        Me.dtpPeriodoMes.Enabled = False
        Me.dtpPeriodoMes.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpPeriodoMes.Location = New System.Drawing.Point(143, 28)
        Me.dtpPeriodoMes.Name = "dtpPeriodoMes"
        Me.dtpPeriodoMes.ShowUpDown = True
        Me.dtpPeriodoMes.Size = New System.Drawing.Size(117, 20)
        Me.dtpPeriodoMes.TabIndex = 61
        '
        'btnBuscar
        '
        Me.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.Location = New System.Drawing.Point(848, 17)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(43, 47)
        Me.btnBuscar.TabIndex = 42
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'txtHastaAnio
        '
        Me.txtHastaAnio.Enabled = False
        Me.txtHastaAnio.Location = New System.Drawing.Point(607, 32)
        Me.txtHastaAnio.Mask = "00/00"
        Me.txtHastaAnio.Name = "txtHastaAnio"
        Me.txtHastaAnio.Size = New System.Drawing.Size(45, 20)
        Me.txtHastaAnio.TabIndex = 10
        '
        'txtDesdeAnio
        '
        Me.txtDesdeAnio.Enabled = False
        Me.txtDesdeAnio.Location = New System.Drawing.Point(470, 32)
        Me.txtDesdeAnio.Mask = "00/00"
        Me.txtDesdeAnio.Name = "txtDesdeAnio"
        Me.txtDesdeAnio.Size = New System.Drawing.Size(45, 20)
        Me.txtDesdeAnio.TabIndex = 9
        '
        'txtHastaD
        '
        Me.txtHastaD.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.txtHastaD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHastaD.Enabled = False
        Me.txtHastaD.Location = New System.Drawing.Point(654, 33)
        Me.txtHastaD.Name = "txtHastaD"
        Me.txtHastaD.Size = New System.Drawing.Size(34, 20)
        Me.txtHastaD.TabIndex = 8
        '
        'txtDesdeA
        '
        Me.txtDesdeA.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.txtDesdeA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDesdeA.Enabled = False
        Me.txtDesdeA.Location = New System.Drawing.Point(517, 32)
        Me.txtDesdeA.Name = "txtDesdeA"
        Me.txtDesdeA.Size = New System.Drawing.Size(36, 20)
        Me.txtDesdeA.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(567, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "&Hasta"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(426, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "&Desde"
        '
        'rbAcumulado
        '
        Me.rbAcumulado.AutoSize = True
        Me.rbAcumulado.Location = New System.Drawing.Point(342, 19)
        Me.rbAcumulado.Name = "rbAcumulado"
        Me.rbAcumulado.Size = New System.Drawing.Size(77, 17)
        Me.rbAcumulado.TabIndex = 1
        Me.rbAcumulado.TabStop = True
        Me.rbAcumulado.Text = "Acumulado"
        Me.rbAcumulado.UseVisualStyleBackColor = True
        '
        'rbMensual
        '
        Me.rbMensual.AutoSize = True
        Me.rbMensual.Location = New System.Drawing.Point(72, 19)
        Me.rbMensual.Name = "rbMensual"
        Me.rbMensual.Size = New System.Drawing.Size(64, 17)
        Me.rbMensual.TabIndex = 0
        Me.rbMensual.TabStop = True
        Me.rbMensual.Text = "Mensual"
        Me.rbMensual.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.txtDebeSM)
        Me.Panel2.Controls.Add(Me.txtHaberSM)
        Me.Panel2.Controls.Add(Me.txtHaberDS)
        Me.Panel2.Controls.Add(Me.txtDebeSS)
        Me.Panel2.Controls.Add(Me.txtDebeDS)
        Me.Panel2.Controls.Add(Me.txtHaberSS)
        Me.Panel2.Controls.Add(Me.txtHaberDM)
        Me.Panel2.Controls.Add(Me.txtDebeDM)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 399)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(897, 36)
        Me.Panel2.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(270, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "TOTALES:"
        '
        'txtDebeSM
        '
        Me.txtDebeSM.Location = New System.Drawing.Point(337, 6)
        Me.txtDebeSM.Name = "txtDebeSM"
        Me.txtDebeSM.Size = New System.Drawing.Size(66, 20)
        Me.txtDebeSM.TabIndex = 6
        Me.txtDebeSM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtHaberSM
        '
        Me.txtHaberSM.Location = New System.Drawing.Point(407, 6)
        Me.txtHaberSM.Name = "txtHaberSM"
        Me.txtHaberSM.Size = New System.Drawing.Size(66, 20)
        Me.txtHaberSM.TabIndex = 7
        Me.txtHaberSM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtHaberDS
        '
        Me.txtHaberDS.Location = New System.Drawing.Point(828, 6)
        Me.txtHaberDS.Name = "txtHaberDS"
        Me.txtHaberDS.Size = New System.Drawing.Size(66, 20)
        Me.txtHaberDS.TabIndex = 13
        Me.txtHaberDS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDebeSS
        '
        Me.txtDebeSS.Location = New System.Drawing.Point(476, 6)
        Me.txtDebeSS.Name = "txtDebeSS"
        Me.txtDebeSS.Size = New System.Drawing.Size(66, 20)
        Me.txtDebeSS.TabIndex = 8
        Me.txtDebeSS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDebeDS
        '
        Me.txtDebeDS.Location = New System.Drawing.Point(757, 6)
        Me.txtDebeDS.Name = "txtDebeDS"
        Me.txtDebeDS.Size = New System.Drawing.Size(66, 20)
        Me.txtDebeDS.TabIndex = 12
        Me.txtDebeDS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtHaberSS
        '
        Me.txtHaberSS.Location = New System.Drawing.Point(546, 6)
        Me.txtHaberSS.Name = "txtHaberSS"
        Me.txtHaberSS.Size = New System.Drawing.Size(66, 20)
        Me.txtHaberSS.TabIndex = 9
        Me.txtHaberSS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtHaberDM
        '
        Me.txtHaberDM.Location = New System.Drawing.Point(686, 6)
        Me.txtHaberDM.Name = "txtHaberDM"
        Me.txtHaberDM.Size = New System.Drawing.Size(66, 20)
        Me.txtHaberDM.TabIndex = 11
        Me.txtHaberDM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDebeDM
        '
        Me.txtDebeDM.Location = New System.Drawing.Point(615, 6)
        Me.txtDebeDM.Name = "txtDebeDM"
        Me.txtDebeDM.Size = New System.Drawing.Size(66, 20)
        Me.txtDebeDM.TabIndex = 10
        Me.txtDebeDM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dgvMovimiento
        '
        Me.dgvMovimiento.AllowUserToAddRows = False
        Me.dgvMovimiento.AllowUserToDeleteRows = False
        Me.dgvMovimiento.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.Format = "N2"
        DataGridViewCellStyle10.NullValue = Nothing
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMovimiento.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvMovimiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMovimiento.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cuenta, Me.descripcion, Me.debeSoles, Me.haberSoles, Me.debeSaldo, Me.haberSaldo, Me.debeUSD, Me.haberUSD, Me.debeSaldoUSD, Me.haberSaldoUSD})
        Me.dgvMovimiento.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgvMovimiento.Location = New System.Drawing.Point(0, 43)
        Me.dgvMovimiento.Name = "dgvMovimiento"
        Me.dgvMovimiento.ReadOnly = True
        Me.dgvMovimiento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMovimiento.Size = New System.Drawing.Size(897, 356)
        Me.dgvMovimiento.TabIndex = 3
        '
        'cuenta
        '
        Me.cuenta.HeaderText = "Cuenta"
        Me.cuenta.Name = "cuenta"
        Me.cuenta.ReadOnly = True
        Me.cuenta.Width = 70
        '
        'descripcion
        '
        Me.descripcion.HeaderText = "Descripción"
        Me.descripcion.Name = "descripcion"
        Me.descripcion.ReadOnly = True
        Me.descripcion.Width = 220
        '
        'debeSoles
        '
        DataGridViewCellStyle11.Format = "N2"
        Me.debeSoles.DefaultCellStyle = DataGridViewCellStyle11
        Me.debeSoles.HeaderText = "Debe Soles"
        Me.debeSoles.Name = "debeSoles"
        Me.debeSoles.ReadOnly = True
        Me.debeSoles.Width = 70
        '
        'haberSoles
        '
        DataGridViewCellStyle12.Format = "N2"
        Me.haberSoles.DefaultCellStyle = DataGridViewCellStyle12
        Me.haberSoles.HeaderText = "Haber Soles"
        Me.haberSoles.Name = "haberSoles"
        Me.haberSoles.ReadOnly = True
        Me.haberSoles.Width = 70
        '
        'debeSaldo
        '
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle13.Format = "N2"
        Me.debeSaldo.DefaultCellStyle = DataGridViewCellStyle13
        Me.debeSaldo.HeaderText = "Debe Soles"
        Me.debeSaldo.Name = "debeSaldo"
        Me.debeSaldo.ReadOnly = True
        Me.debeSaldo.Width = 70
        '
        'haberSaldo
        '
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle14.Format = "N2"
        Me.haberSaldo.DefaultCellStyle = DataGridViewCellStyle14
        Me.haberSaldo.HeaderText = "Haber Soles"
        Me.haberSaldo.Name = "haberSaldo"
        Me.haberSaldo.ReadOnly = True
        Me.haberSaldo.Width = 70
        '
        'debeUSD
        '
        DataGridViewCellStyle15.Format = "N2"
        Me.debeUSD.DefaultCellStyle = DataGridViewCellStyle15
        Me.debeUSD.HeaderText = "Debe USD"
        Me.debeUSD.Name = "debeUSD"
        Me.debeUSD.ReadOnly = True
        Me.debeUSD.Width = 70
        '
        'haberUSD
        '
        DataGridViewCellStyle16.Format = "N2"
        Me.haberUSD.DefaultCellStyle = DataGridViewCellStyle16
        Me.haberUSD.HeaderText = "Haber USD"
        Me.haberUSD.Name = "haberUSD"
        Me.haberUSD.ReadOnly = True
        Me.haberUSD.Width = 70
        '
        'debeSaldoUSD
        '
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle17.Format = "N2"
        Me.debeSaldoUSD.DefaultCellStyle = DataGridViewCellStyle17
        Me.debeSaldoUSD.HeaderText = "Debe USD"
        Me.debeSaldoUSD.Name = "debeSaldoUSD"
        Me.debeSaldoUSD.ReadOnly = True
        Me.debeSaldoUSD.Width = 70
        '
        'haberSaldoUSD
        '
        DataGridViewCellStyle18.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle18.Format = "N2"
        Me.haberSaldoUSD.DefaultCellStyle = DataGridViewCellStyle18
        Me.haberSaldoUSD.HeaderText = "Haber USD"
        Me.haberSaldoUSD.Name = "haberSaldoUSD"
        Me.haberSaldoUSD.ReadOnly = True
        Me.haberSaldoUSD.Width = 70
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.OldLace
        Me.Panel1.Controls.Add(Me.TextBox4)
        Me.Panel1.Controls.Add(Me.TextBox3)
        Me.Panel1.Controls.Add(Me.TextBox2)
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(897, 43)
        Me.Panel1.TabIndex = 4
        '
        'TextBox4
        '
        Me.TextBox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.TextBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox4.Location = New System.Drawing.Point(753, 17)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(141, 20)
        Me.TextBox4.TabIndex = 3
        Me.TextBox4.Text = "SALDO USD"
        Me.TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox3.Location = New System.Drawing.Point(611, 17)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(141, 20)
        Me.TextBox3.TabIndex = 2
        Me.TextBox3.Text = "MOVIMIENTO USD"
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox2.Location = New System.Drawing.Point(469, 17)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(145, 20)
        Me.TextBox2.TabIndex = 1
        Me.TextBox2.Text = "SALDO SOLES"
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Location = New System.Drawing.Point(331, 17)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(141, 20)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = "MOVIMIENTO SOLES"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frmReporteContableMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(897, 658)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.dgvMovimiento)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmReporteContableMaster"
        Me.Text = "Hoja de Trabajo"
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ToolStrip4.ResumeLayout(False)
        Me.ToolStrip4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgvMovimiento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvMovimiento As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDebeSM As System.Windows.Forms.TextBox
    Friend WithEvents txtHaberSM As System.Windows.Forms.TextBox
    Friend WithEvents txtHaberSS As System.Windows.Forms.TextBox
    Friend WithEvents txtDebeSS As System.Windows.Forms.TextBox
    Friend WithEvents txtHaberDS As System.Windows.Forms.TextBox
    Friend WithEvents txtDebeDS As System.Windows.Forms.TextBox
    Friend WithEvents txtHaberDM As System.Windows.Forms.TextBox
    Friend WithEvents txtDebeDM As System.Windows.Forms.TextBox
    Friend WithEvents cuenta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents debeSoles As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents haberSoles As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents debeSaldo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents haberSaldo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents debeUSD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents haberUSD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents debeSaldoUSD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents haberSaldoUSD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtHastaD As System.Windows.Forms.TextBox
    Friend WithEvents txtDesdeA As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rbAcumulado As System.Windows.Forms.RadioButton
    Friend WithEvents rbMensual As System.Windows.Forms.RadioButton
    Friend WithEvents txtDesdeAnio As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtHastaAnio As System.Windows.Forms.MaskedTextBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents dtpPeriodoMes As System.Windows.Forms.DateTimePicker
    Friend WithEvents rbTodo As System.Windows.Forms.RadioButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents LinkLabel4 As System.Windows.Forms.LinkLabel
    Friend WithEvents lblLibroDiario As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel5 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel6 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel7 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel9 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel10 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel11 As System.Windows.Forms.LinkLabel
    Friend WithEvents ToolStrip4 As System.Windows.Forms.ToolStrip
    Friend WithEvents lblTitulo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblPerido As System.Windows.Forms.ToolStripLabel
    Friend WithEvents dtpAnio As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpPeriodoAnio As System.Windows.Forms.DateTimePicker
End Class

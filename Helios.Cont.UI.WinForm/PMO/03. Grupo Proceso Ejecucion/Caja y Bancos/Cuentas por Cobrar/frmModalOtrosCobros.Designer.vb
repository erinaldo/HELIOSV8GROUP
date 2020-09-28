<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModalOtrosCobros
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmModalOtrosCobros))
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblCuentaCliente = New System.Windows.Forms.Label()
        Me.lblIdCliente = New System.Windows.Forms.Label()
        Me.lblNomCliente = New System.Windows.Forms.Label()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.ToolStrip4 = New System.Windows.Forms.ToolStrip()
        Me.lblEstado = New System.Windows.Forms.ToolStripButton()
        Me.lblIdDocumento = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.lbldDocCaja = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.GuardarToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtIDEstablecimientoCaja = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFechaComprobante = New System.Windows.Forms.DateTimePicker()
        Me.txtEstablecimientoCaja = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblCuenta = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.rbEfectivo = New System.Windows.Forms.RadioButton()
        Me.rbBanco = New System.Windows.Forms.RadioButton()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.LinkTipoDoc = New System.Windows.Forms.LinkLabel()
        Me.txtIdComprobante = New System.Windows.Forms.TextBox()
        Me.txtIdCaja = New System.Windows.Forms.TextBox()
        Me.txtNumeroComp = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtComprobante = New System.Windows.Forms.TextBox()
        Me.txtCaja = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbExt = New System.Windows.Forms.RadioButton()
        Me.rbNac = New System.Windows.Forms.RadioButton()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.lblSaldoFinalme = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblDeudaPendienteme = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblSaldoFinal = New System.Windows.Forms.Label()
        Me.nudImporteExt = New System.Windows.Forms.NumericUpDown()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.nudImporteNac = New System.Windows.Forms.NumericUpDown()
        Me.lblDeudaPendiente = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.nudTipoCambio = New System.Windows.Forms.NumericUpDown()
        Me.pnlDetalle = New System.Windows.Forms.Panel()
        Me.dgvDetalleItems = New System.Windows.Forms.DataGridView()
        Me.colId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNameItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPrecUnit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPagoMN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPagoME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSaldoMN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSaldoME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip4.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.nudImporteExt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudImporteNac, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudTipoCambio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDetalleItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Thistle
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.lblCuentaCliente)
        Me.Panel1.Controls.Add(Me.lblIdCliente)
        Me.Panel1.Controls.Add(Me.lblNomCliente)
        Me.Panel1.Controls.Add(Me.lblTipo)
        Me.Panel1.Controls.Add(Me.ToolStrip4)
        Me.Panel1.Controls.Add(Me.ToolStrip2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(803, 75)
        Me.Panel1.TabIndex = 8
        '
        'lblCuentaCliente
        '
        Me.lblCuentaCliente.AutoSize = True
        Me.lblCuentaCliente.BackColor = System.Drawing.Color.Transparent
        Me.lblCuentaCliente.Location = New System.Drawing.Point(477, 57)
        Me.lblCuentaCliente.Name = "lblCuentaCliente"
        Me.lblCuentaCliente.Size = New System.Drawing.Size(19, 13)
        Me.lblCuentaCliente.TabIndex = 5
        Me.lblCuentaCliente.Text = "00"
        Me.lblCuentaCliente.Visible = False
        '
        'lblIdCliente
        '
        Me.lblIdCliente.AutoSize = True
        Me.lblIdCliente.BackColor = System.Drawing.Color.Transparent
        Me.lblIdCliente.Location = New System.Drawing.Point(411, 57)
        Me.lblIdCliente.Name = "lblIdCliente"
        Me.lblIdCliente.Size = New System.Drawing.Size(19, 13)
        Me.lblIdCliente.TabIndex = 4
        Me.lblIdCliente.Text = "00"
        Me.lblIdCliente.Visible = False
        '
        'lblNomCliente
        '
        Me.lblNomCliente.AutoSize = True
        Me.lblNomCliente.BackColor = System.Drawing.Color.Transparent
        Me.lblNomCliente.Location = New System.Drawing.Point(120, 57)
        Me.lblNomCliente.Name = "lblNomCliente"
        Me.lblNomCliente.Size = New System.Drawing.Size(44, 13)
        Me.lblNomCliente.TabIndex = 3
        Me.lblNomCliente.Text = "Cliente:"
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.BackColor = System.Drawing.Color.Transparent
        Me.lblTipo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblTipo.Location = New System.Drawing.Point(56, 57)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(44, 13)
        Me.lblTipo.TabIndex = 2
        Me.lblTipo.Text = "Cliente:"
        '
        'ToolStrip4
        '
        Me.ToolStrip4.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.ToolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip4.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblEstado, Me.lblIdDocumento, Me.ToolStripButton1, Me.lbldDocCaja})
        Me.ToolStrip4.Location = New System.Drawing.Point(0, 25)
        Me.ToolStrip4.Name = "ToolStrip4"
        Me.ToolStrip4.Size = New System.Drawing.Size(803, 25)
        Me.ToolStrip4.TabIndex = 1
        Me.ToolStrip4.Text = "ToolStrip4"
        '
        'lblEstado
        '
        Me.lblEstado.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblEstado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblEstado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(117, 22)
        Me.lblEstado.Text = "Estado: nuevo pago."
        '
        'lblIdDocumento
        '
        Me.lblIdDocumento.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblIdDocumento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblIdDocumento.Name = "lblIdDocumento"
        Me.lblIdDocumento.Size = New System.Drawing.Size(13, 22)
        Me.lblIdDocumento.Text = "0"
        Me.lblIdDocumento.Visible = False
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        Me.ToolStripButton1.Visible = False
        '
        'lbldDocCaja
        '
        Me.lbldDocCaja.Name = "lbldDocCaja"
        Me.lbldDocCaja.Size = New System.Drawing.Size(13, 22)
        Me.lbldDocCaja.Text = "0"
        Me.lbldDocCaja.Visible = False
        '
        'ToolStrip2
        '
        Me.ToolStrip2.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ToolStrip2.BackgroundImage = CType(resources.GetObject("ToolStrip2.BackgroundImage"), System.Drawing.Image)
        Me.ToolStrip2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton2, Me.ToolStripLabel1, Me.ToolStripSeparator1, Me.GuardarToolStripButton2})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(803, 25)
        Me.ToolStrip2.TabIndex = 0
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.arrow_circle_135_left
        Me.ToolStripButton2.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "Salir"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(108, 22)
        Me.ToolStripLabel1.Text = "Cuentas por cobrar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'GuardarToolStripButton2
        '
        Me.GuardarToolStripButton2.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.GuardarToolStripButton2.ForeColor = System.Drawing.Color.Yellow
        Me.GuardarToolStripButton2.Image = CType(resources.GetObject("GuardarToolStripButton2.Image"), System.Drawing.Image)
        Me.GuardarToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.GuardarToolStripButton2.Name = "GuardarToolStripButton2"
        Me.GuardarToolStripButton2.Size = New System.Drawing.Size(60, 22)
        Me.GuardarToolStripButton2.Text = "&Grabar"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GroupBox2)
        Me.Panel2.Controls.Add(Me.GroupBox5)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 75)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(803, 223)
        Me.Panel2.TabIndex = 44
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtIDEstablecimientoCaja)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txtFechaComprobante)
        Me.GroupBox2.Controls.Add(Me.txtEstablecimientoCaja)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.lblCuenta)
        Me.GroupBox2.Controls.Add(Me.GroupBox4)
        Me.GroupBox2.Controls.Add(Me.LinkLabel2)
        Me.GroupBox2.Controls.Add(Me.LinkTipoDoc)
        Me.GroupBox2.Controls.Add(Me.txtIdComprobante)
        Me.GroupBox2.Controls.Add(Me.txtIdCaja)
        Me.GroupBox2.Controls.Add(Me.txtNumeroComp)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtComprobante)
        Me.GroupBox2.Controls.Add(Me.txtCaja)
        Me.GroupBox2.Controls.Add(Me.GroupBox1)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(505, 214)
        Me.GroupBox2.TabIndex = 41
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos del documento:"
        '
        'txtIDEstablecimientoCaja
        '
        Me.txtIDEstablecimientoCaja.BackColor = System.Drawing.Color.Thistle
        Me.txtIDEstablecimientoCaja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIDEstablecimientoCaja.Location = New System.Drawing.Point(383, 160)
        Me.txtIDEstablecimientoCaja.Name = "txtIDEstablecimientoCaja"
        Me.txtIDEstablecimientoCaja.ReadOnly = True
        Me.txtIDEstablecimientoCaja.Size = New System.Drawing.Size(33, 20)
        Me.txtIDEstablecimientoCaja.TabIndex = 342
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(71, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fecha:"
        '
        'txtFechaComprobante
        '
        Me.txtFechaComprobante.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaComprobante.Location = New System.Drawing.Point(115, 25)
        Me.txtFechaComprobante.Name = "txtFechaComprobante"
        Me.txtFechaComprobante.Size = New System.Drawing.Size(200, 20)
        Me.txtFechaComprobante.TabIndex = 0
        '
        'txtEstablecimientoCaja
        '
        Me.txtEstablecimientoCaja.BackColor = System.Drawing.Color.Thistle
        Me.txtEstablecimientoCaja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEstablecimientoCaja.Location = New System.Drawing.Point(114, 160)
        Me.txtEstablecimientoCaja.Name = "txtEstablecimientoCaja"
        Me.txtEstablecimientoCaja.ReadOnly = True
        Me.txtEstablecimientoCaja.Size = New System.Drawing.Size(267, 20)
        Me.txtEstablecimientoCaja.TabIndex = 341
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(26, 164)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(85, 13)
        Me.Label9.TabIndex = 340
        Me.Label9.Text = "Establecimiento:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(80, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Tipo:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Enabled = False
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(63, 83)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Número:"
        '
        'lblCuenta
        '
        Me.lblCuenta.AutoSize = True
        Me.lblCuenta.Location = New System.Drawing.Point(387, 189)
        Me.lblCuenta.Name = "lblCuenta"
        Me.lblCuenta.Size = New System.Drawing.Size(19, 13)
        Me.lblCuenta.TabIndex = 339
        Me.lblCuenta.Text = "00"
        Me.lblCuenta.Visible = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rbEfectivo)
        Me.GroupBox4.Controls.Add(Me.rbBanco)
        Me.GroupBox4.Location = New System.Drawing.Point(321, 106)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(178, 47)
        Me.GroupBox4.TabIndex = 338
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Entidad financiera:"
        '
        'rbEfectivo
        '
        Me.rbEfectivo.AutoSize = True
        Me.rbEfectivo.Checked = True
        Me.rbEfectivo.Location = New System.Drawing.Point(17, 24)
        Me.rbEfectivo.Name = "rbEfectivo"
        Me.rbEfectivo.Size = New System.Drawing.Size(79, 17)
        Me.rbEfectivo.TabIndex = 320
        Me.rbEfectivo.TabStop = True
        Me.rbEfectivo.Text = "en efectivo"
        Me.rbEfectivo.UseVisualStyleBackColor = True
        '
        'rbBanco
        '
        Me.rbBanco.AutoSize = True
        Me.rbBanco.Location = New System.Drawing.Point(112, 24)
        Me.rbBanco.Name = "rbBanco"
        Me.rbBanco.Size = New System.Drawing.Size(54, 17)
        Me.rbBanco.TabIndex = 321
        Me.rbBanco.Text = "Banco"
        Me.rbBanco.UseVisualStyleBackColor = True
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Location = New System.Drawing.Point(420, 190)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(46, 13)
        Me.LinkLabel2.TabIndex = 337
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Cambiar"
        '
        'LinkTipoDoc
        '
        Me.LinkTipoDoc.AutoSize = True
        Me.LinkTipoDoc.LinkColor = System.Drawing.SystemColors.Highlight
        Me.LinkTipoDoc.Location = New System.Drawing.Point(387, 54)
        Me.LinkTipoDoc.Name = "LinkTipoDoc"
        Me.LinkTipoDoc.Size = New System.Drawing.Size(46, 13)
        Me.LinkTipoDoc.TabIndex = 3
        Me.LinkTipoDoc.TabStop = True
        Me.LinkTipoDoc.Text = "Cambiar"
        '
        'txtIdComprobante
        '
        Me.txtIdComprobante.BackColor = System.Drawing.Color.Thistle
        Me.txtIdComprobante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIdComprobante.Location = New System.Drawing.Point(115, 51)
        Me.txtIdComprobante.Name = "txtIdComprobante"
        Me.txtIdComprobante.ReadOnly = True
        Me.txtIdComprobante.Size = New System.Drawing.Size(32, 20)
        Me.txtIdComprobante.TabIndex = 12
        Me.txtIdComprobante.Text = "109"
        Me.txtIdComprobante.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtIdCaja
        '
        Me.txtIdCaja.BackColor = System.Drawing.Color.Thistle
        Me.txtIdCaja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIdCaja.Location = New System.Drawing.Point(383, 186)
        Me.txtIdCaja.Name = "txtIdCaja"
        Me.txtIdCaja.ReadOnly = True
        Me.txtIdCaja.Size = New System.Drawing.Size(33, 20)
        Me.txtIdCaja.TabIndex = 336
        '
        'txtNumeroComp
        '
        Me.txtNumeroComp.BackColor = System.Drawing.SystemColors.Info
        Me.txtNumeroComp.Location = New System.Drawing.Point(115, 78)
        Me.txtNumeroComp.Name = "txtNumeroComp"
        Me.txtNumeroComp.Size = New System.Drawing.Size(200, 20)
        Me.txtNumeroComp.TabIndex = 4
        Me.txtNumeroComp.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(78, 190)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(33, 13)
        Me.Label10.TabIndex = 334
        Me.Label10.Text = "Caja:"
        '
        'txtComprobante
        '
        Me.txtComprobante.BackColor = System.Drawing.Color.Thistle
        Me.txtComprobante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComprobante.Location = New System.Drawing.Point(148, 51)
        Me.txtComprobante.Name = "txtComprobante"
        Me.txtComprobante.ReadOnly = True
        Me.txtComprobante.Size = New System.Drawing.Size(233, 20)
        Me.txtComprobante.TabIndex = 1
        Me.txtComprobante.Text = "EFECTIVO"
        '
        'txtCaja
        '
        Me.txtCaja.BackColor = System.Drawing.Color.Thistle
        Me.txtCaja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCaja.Location = New System.Drawing.Point(114, 186)
        Me.txtCaja.Name = "txtCaja"
        Me.txtCaja.ReadOnly = True
        Me.txtCaja.Size = New System.Drawing.Size(267, 20)
        Me.txtCaja.TabIndex = 335
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbExt)
        Me.GroupBox1.Controls.Add(Me.rbNac)
        Me.GroupBox1.Location = New System.Drawing.Point(115, 105)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 48)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Moneda:"
        '
        'rbExt
        '
        Me.rbExt.AutoSize = True
        Me.rbExt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rbExt.Location = New System.Drawing.Point(112, 22)
        Me.rbExt.Name = "rbExt"
        Me.rbExt.Size = New System.Drawing.Size(76, 17)
        Me.rbExt.TabIndex = 1
        Me.rbExt.Text = "Extranjera"
        Me.rbExt.UseVisualStyleBackColor = True
        '
        'rbNac
        '
        Me.rbNac.AutoSize = True
        Me.rbNac.Checked = True
        Me.rbNac.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rbNac.Location = New System.Drawing.Point(25, 22)
        Me.rbNac.Name = "rbNac"
        Me.rbNac.Size = New System.Drawing.Size(65, 17)
        Me.rbNac.TabIndex = 0
        Me.rbNac.TabStop = True
        Me.rbNac.Text = "Nacional"
        Me.rbNac.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.lblSaldoFinalme)
        Me.GroupBox5.Controls.Add(Me.Label8)
        Me.GroupBox5.Controls.Add(Me.lblDeudaPendienteme)
        Me.GroupBox5.Controls.Add(Me.Label13)
        Me.GroupBox5.Controls.Add(Me.lblSaldoFinal)
        Me.GroupBox5.Controls.Add(Me.nudImporteExt)
        Me.GroupBox5.Controls.Add(Me.Label11)
        Me.GroupBox5.Controls.Add(Me.nudImporteNac)
        Me.GroupBox5.Controls.Add(Me.lblDeudaPendiente)
        Me.GroupBox5.Controls.Add(Me.Label7)
        Me.GroupBox5.Controls.Add(Me.Label3)
        Me.GroupBox5.Controls.Add(Me.Label17)
        Me.GroupBox5.Controls.Add(Me.Label6)
        Me.GroupBox5.Controls.Add(Me.nudTipoCambio)
        Me.GroupBox5.Location = New System.Drawing.Point(523, 3)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(268, 214)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Importe a pagar:"
        '
        'lblSaldoFinalme
        '
        Me.lblSaldoFinalme.AutoSize = True
        Me.lblSaldoFinalme.BackColor = System.Drawing.Color.Transparent
        Me.lblSaldoFinalme.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaldoFinalme.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblSaldoFinalme.Location = New System.Drawing.Point(212, 176)
        Me.lblSaldoFinalme.Name = "lblSaldoFinalme"
        Me.lblSaldoFinalme.Size = New System.Drawing.Size(31, 13)
        Me.lblSaldoFinalme.TabIndex = 49
        Me.lblSaldoFinalme.Text = "0.00"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(103, 176)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(103, 13)
        Me.Label8.TabIndex = 48
        Me.Label8.Text = "Saldo a cuenta m.e:"
        '
        'lblDeudaPendienteme
        '
        Me.lblDeudaPendienteme.AutoSize = True
        Me.lblDeudaPendienteme.BackColor = System.Drawing.Color.Transparent
        Me.lblDeudaPendienteme.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeudaPendienteme.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblDeudaPendienteme.Location = New System.Drawing.Point(212, 155)
        Me.lblDeudaPendienteme.Name = "lblDeudaPendienteme"
        Me.lblDeudaPendienteme.Size = New System.Drawing.Size(31, 13)
        Me.lblDeudaPendienteme.TabIndex = 47
        Me.lblDeudaPendienteme.Text = "0.00"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(84, 155)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(122, 13)
        Me.Label13.TabIndex = 46
        Me.Label13.Text = "Pendiente de Pago m.e:"
        '
        'lblSaldoFinal
        '
        Me.lblSaldoFinal.AutoSize = True
        Me.lblSaldoFinal.BackColor = System.Drawing.Color.Transparent
        Me.lblSaldoFinal.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaldoFinal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblSaldoFinal.Location = New System.Drawing.Point(212, 129)
        Me.lblSaldoFinal.Name = "lblSaldoFinal"
        Me.lblSaldoFinal.Size = New System.Drawing.Size(31, 13)
        Me.lblSaldoFinal.TabIndex = 45
        Me.lblSaldoFinal.Text = "0.00"
        '
        'nudImporteExt
        '
        Me.nudImporteExt.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.nudImporteExt.DecimalPlaces = 2
        Me.nudImporteExt.Location = New System.Drawing.Point(92, 74)
        Me.nudImporteExt.Maximum = New Decimal(New Integer() {-159383552, 46653770, 5421, 0})
        Me.nudImporteExt.Name = "nudImporteExt"
        Me.nudImporteExt.Size = New System.Drawing.Size(153, 20)
        Me.nudImporteExt.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(124, 129)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(82, 13)
        Me.Label11.TabIndex = 44
        Me.Label11.Text = "Saldo a cuenta:"
        '
        'nudImporteNac
        '
        Me.nudImporteNac.BackColor = System.Drawing.SystemColors.Info
        Me.nudImporteNac.DecimalPlaces = 2
        Me.nudImporteNac.Location = New System.Drawing.Point(92, 49)
        Me.nudImporteNac.Maximum = New Decimal(New Integer() {-159383552, 46653770, 5421, 0})
        Me.nudImporteNac.Name = "nudImporteNac"
        Me.nudImporteNac.Size = New System.Drawing.Size(153, 20)
        Me.nudImporteNac.TabIndex = 0
        '
        'lblDeudaPendiente
        '
        Me.lblDeudaPendiente.AutoSize = True
        Me.lblDeudaPendiente.BackColor = System.Drawing.Color.Transparent
        Me.lblDeudaPendiente.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeudaPendiente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblDeudaPendiente.Location = New System.Drawing.Point(212, 108)
        Me.lblDeudaPendiente.Name = "lblDeudaPendiente"
        Me.lblDeudaPendiente.Size = New System.Drawing.Size(31, 13)
        Me.lblDeudaPendiente.TabIndex = 43
        Me.lblDeudaPendiente.Text = "0.00"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(17, 78)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Moneda ext.:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(105, 108)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 13)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "Pendiente de Pago:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(20, 29)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(69, 13)
        Me.Label17.TabIndex = 37
        Me.Label17.Text = "Tipo Cambio:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 53)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Moneda nac.:"
        '
        'nudTipoCambio
        '
        Me.nudTipoCambio.BackColor = System.Drawing.SystemColors.Info
        Me.nudTipoCambio.DecimalPlaces = 3
        Me.nudTipoCambio.Location = New System.Drawing.Point(92, 25)
        Me.nudTipoCambio.Name = "nudTipoCambio"
        Me.nudTipoCambio.Size = New System.Drawing.Size(55, 20)
        Me.nudTipoCambio.TabIndex = 38
        Me.nudTipoCambio.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'pnlDetalle
        '
        Me.pnlDetalle.BackColor = System.Drawing.Color.DarkMagenta
        Me.pnlDetalle.BackgroundImage = CType(resources.GetObject("pnlDetalle.BackgroundImage"), System.Drawing.Image)
        Me.pnlDetalle.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDetalle.Location = New System.Drawing.Point(0, 298)
        Me.pnlDetalle.Name = "pnlDetalle"
        Me.pnlDetalle.Size = New System.Drawing.Size(803, 20)
        Me.pnlDetalle.TabIndex = 45
        '
        'dgvDetalleItems
        '
        Me.dgvDetalleItems.AllowUserToAddRows = False
        Me.dgvDetalleItems.BackgroundColor = System.Drawing.Color.Thistle
        Me.dgvDetalleItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalleItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colId, Me.colNameItem, Me.colum, Me.ColPrecUnit, Me.colMN, Me.colME, Me.colPagoMN, Me.colPagoME, Me.colSaldoMN, Me.colSaldoME, Me.colEstado})
        Me.dgvDetalleItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDetalleItems.EnableHeadersVisualStyles = False
        Me.dgvDetalleItems.Location = New System.Drawing.Point(0, 318)
        Me.dgvDetalleItems.MultiSelect = False
        Me.dgvDetalleItems.Name = "dgvDetalleItems"
        Me.dgvDetalleItems.RowHeadersVisible = False
        Me.dgvDetalleItems.Size = New System.Drawing.Size(803, 137)
        Me.dgvDetalleItems.TabIndex = 114
        '
        'colId
        '
        Me.colId.HeaderText = "ID"
        Me.colId.Name = "colId"
        Me.colId.ReadOnly = True
        Me.colId.Visible = False
        Me.colId.Width = 50
        '
        'colNameItem
        '
        Me.colNameItem.HeaderText = "Descripción"
        Me.colNameItem.Name = "colNameItem"
        Me.colNameItem.ReadOnly = True
        Me.colNameItem.Width = 250
        '
        'colum
        '
        Me.colum.HeaderText = "U.M."
        Me.colum.Name = "colum"
        Me.colum.ReadOnly = True
        Me.colum.Visible = False
        Me.colum.Width = 40
        '
        'ColPrecUnit
        '
        Me.ColPrecUnit.HeaderText = "Prec Unit"
        Me.ColPrecUnit.Name = "ColPrecUnit"
        Me.ColPrecUnit.ReadOnly = True
        Me.ColPrecUnit.Visible = False
        '
        'colMN
        '
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.colMN.DefaultCellStyle = DataGridViewCellStyle9
        Me.colMN.HeaderText = "Importe MN"
        Me.colMN.Name = "colMN"
        Me.colMN.ReadOnly = True
        Me.colMN.Width = 70
        '
        'colME
        '
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.colME.DefaultCellStyle = DataGridViewCellStyle10
        Me.colME.HeaderText = "Importe ME"
        Me.colME.Name = "colME"
        Me.colME.ReadOnly = True
        Me.colME.Width = 70
        '
        'colPagoMN
        '
        Me.colPagoMN.HeaderText = "Pago MN"
        Me.colPagoMN.Name = "colPagoMN"
        Me.colPagoMN.Width = 70
        '
        'colPagoME
        '
        Me.colPagoME.HeaderText = "Pago ME"
        Me.colPagoME.Name = "colPagoME"
        Me.colPagoME.Width = 70
        '
        'colSaldoMN
        '
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.LavenderBlush
        Me.colSaldoMN.DefaultCellStyle = DataGridViewCellStyle11
        Me.colSaldoMN.HeaderText = "Saldo MN"
        Me.colSaldoMN.Name = "colSaldoMN"
        Me.colSaldoMN.ReadOnly = True
        Me.colSaldoMN.Width = 70
        '
        'colSaldoME
        '
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.LavenderBlush
        Me.colSaldoME.DefaultCellStyle = DataGridViewCellStyle12
        Me.colSaldoME.HeaderText = "Saldo ME"
        Me.colSaldoME.Name = "colSaldoME"
        Me.colSaldoME.ReadOnly = True
        Me.colSaldoME.Width = 70
        '
        'colEstado
        '
        Me.colEstado.HeaderText = "EST"
        Me.colEstado.Name = "colEstado"
        Me.colEstado.ReadOnly = True
        Me.colEstado.Width = 50
        '
        'frmModalOtrosCobros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.GhostWhite
        Me.ClientSize = New System.Drawing.Size(803, 455)
        Me.ControlBox = False
        Me.Controls.Add(Me.dgvDetalleItems)
        Me.Controls.Add(Me.pnlDetalle)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmModalOtrosCobros"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip4.ResumeLayout(False)
        Me.ToolStrip4.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.nudImporteExt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudImporteNac, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudTipoCambio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDetalleItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblCuentaCliente As System.Windows.Forms.Label
    Friend WithEvents lblIdCliente As System.Windows.Forms.Label
    Friend WithEvents lblNomCliente As System.Windows.Forms.Label
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents ToolStrip4 As System.Windows.Forms.ToolStrip
    Friend WithEvents lblEstado As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblIdDocumento As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents lbldDocCaja As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GuardarToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtIDEstablecimientoCaja As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFechaComprobante As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtEstablecimientoCaja As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblCuenta As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents rbEfectivo As System.Windows.Forms.RadioButton
    Friend WithEvents rbBanco As System.Windows.Forms.RadioButton
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkTipoDoc As System.Windows.Forms.LinkLabel
    Friend WithEvents txtIdComprobante As System.Windows.Forms.TextBox
    Friend WithEvents txtIdCaja As System.Windows.Forms.TextBox
    Friend WithEvents txtNumeroComp As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtComprobante As System.Windows.Forms.TextBox
    Friend WithEvents txtCaja As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbExt As System.Windows.Forms.RadioButton
    Friend WithEvents rbNac As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents lblSaldoFinalme As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblDeudaPendienteme As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblSaldoFinal As System.Windows.Forms.Label
    Friend WithEvents nudImporteExt As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents nudImporteNac As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblDeudaPendiente As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents nudTipoCambio As System.Windows.Forms.NumericUpDown
    Friend WithEvents pnlDetalle As System.Windows.Forms.Panel
    Friend WithEvents dgvDetalleItems As System.Windows.Forms.DataGridView
    Friend WithEvents colId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNameItem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPrecUnit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPagoMN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPagoME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSaldoMN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSaldoME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEstado As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

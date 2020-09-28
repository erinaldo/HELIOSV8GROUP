<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPagoTicket
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPagoTicket))
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cboPeriodo = New System.Windows.Forms.ToolStripComboBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.KryptonManager1 = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.PrintTikect = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewDialogTicket = New System.Windows.Forms.PrintPreviewDialog()
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog()
        Me.lsvDetalle = New System.Windows.Forms.ListView()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblTipoCambio = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtFechaPago = New System.Windows.Forms.DateTimePicker()
        Me.txtIdCliente = New System.Windows.Forms.TextBox()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.lbligvme = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lbligv = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblSerieDoc = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtIDEstablecimientoCaja = New System.Windows.Forms.TextBox()
        Me.txtEstablecimientoCaja = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtGlosa = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblCuenta = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rbEfectivo = New System.Windows.Forms.RadioButton()
        Me.rbBanco = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbNac = New System.Windows.Forms.RadioButton()
        Me.rbExtra = New System.Windows.Forms.RadioButton()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.txtIdCaja = New System.Windows.Forms.TextBox()
        Me.txtCaja = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblImporteme = New System.Windows.Forms.Label()
        Me.lblImporte = New System.Windows.Forms.Label()
        Me.lblNumDoc = New System.Windows.Forms.Label()
        Me.lblTipoDoc = New System.Windows.Forms.Label()
        Me.lblNombreCliente = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtSerie = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.rbFactura = New System.Windows.Forms.RadioButton()
        Me.rbBoleta = New System.Windows.Forms.RadioButton()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtNumFiltro = New System.Windows.Forms.TextBox()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblEstado = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblIdDoc = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.menbtnSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.lblDescripcion = New System.Windows.Forms.ToolStripButton()
        Me.lblPerido = New System.Windows.Forms.ToolStripLabel()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.ToolStrip3.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cboPeriodo})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(182, 29)
        '
        'cboPeriodo
        '
        Me.cboPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPeriodo.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.cboPeriodo.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.cboPeriodo.Name = "cboPeriodo"
        Me.cboPeriodo.Size = New System.Drawing.Size(121, 21)
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'PrintPreviewDialogTicket
        '
        Me.PrintPreviewDialogTicket.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialogTicket.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialogTicket.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialogTicket.Document = Me.PrintTikect
        Me.PrintPreviewDialogTicket.Enabled = True
        Me.PrintPreviewDialogTicket.Icon = CType(resources.GetObject("PrintPreviewDialogTicket.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialogTicket.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialogTicket.UseAntiAlias = True
        Me.PrintPreviewDialogTicket.Visible = False
        '
        'PageSetupDialog1
        '
        Me.PageSetupDialog1.Document = Me.PrintTikect
        Me.PageSetupDialog1.EnableMetric = True
        '
        'lsvDetalle
        '
        Me.lsvDetalle.BackColor = System.Drawing.Color.LavenderBlush
        Me.lsvDetalle.CheckBoxes = True
        Me.lsvDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvDetalle.GridLines = True
        Me.lsvDetalle.Location = New System.Drawing.Point(434, 115)
        Me.lsvDetalle.MultiSelect = False
        Me.lsvDetalle.Name = "lsvDetalle"
        Me.lsvDetalle.Size = New System.Drawing.Size(475, 391)
        Me.lsvDetalle.TabIndex = 317
        Me.lsvDetalle.UseCompatibleStateImageBehavior = False
        Me.lsvDetalle.View = System.Windows.Forms.View.Details
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackgroundImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.background
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.ToolStripButton1, Me.ToolStripSeparator4})
        Me.ToolStrip1.Location = New System.Drawing.Point(434, 506)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(475, 25)
        Me.ToolStrip1.TabIndex = 318
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripButton1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(152, 22)
        Me.ToolStripButton1.Text = "(Confirmar venta (click))"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Label18.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label18.Location = New System.Drawing.Point(434, 97)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(475, 18)
        Me.Label18.TabIndex = 316
        Me.Label18.Text = "Detalle de la venta"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.lblTipoCambio)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.Label19)
        Me.Panel2.Controls.Add(Me.LinkLabel2)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.txtFechaPago)
        Me.Panel2.Controls.Add(Me.txtIdCliente)
        Me.Panel2.Controls.Add(Me.txtCliente)
        Me.Panel2.Controls.Add(Me.lbligvme)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.lbligv)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.lblSerieDoc)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.lblImporteme)
        Me.Panel2.Controls.Add(Me.lblImporte)
        Me.Panel2.Controls.Add(Me.lblNumDoc)
        Me.Panel2.Controls.Add(Me.lblTipoDoc)
        Me.Panel2.Controls.Add(Me.lblNombreCliente)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 97)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(434, 434)
        Me.Panel2.TabIndex = 297
        '
        'lblTipoCambio
        '
        Me.lblTipoCambio.AutoSize = True
        Me.lblTipoCambio.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoCambio.Location = New System.Drawing.Point(375, 89)
        Me.lblTipoCambio.Name = "lblTipoCambio"
        Me.lblTipoCambio.Size = New System.Drawing.Size(31, 13)
        Me.lblTipoCambio.TabIndex = 331
        Me.lblTipoCambio.Text = "0.00"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label12.Location = New System.Drawing.Point(341, 89)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(28, 13)
        Me.Label12.TabIndex = 330
        Me.Label12.Text = "t/c.:"
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Label19.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label19.Location = New System.Drawing.Point(0, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(434, 18)
        Me.Label19.TabIndex = 328
        Me.Label19.Text = "Vendedor: "
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Location = New System.Drawing.Point(384, 159)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(46, 13)
        Me.LinkLabel2.TabIndex = 327
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Cambiar"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label7.Location = New System.Drawing.Point(48, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "fecha pago:"
        '
        'txtFechaPago
        '
        Me.txtFechaPago.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaPago.Location = New System.Drawing.Point(122, 36)
        Me.txtFechaPago.Name = "txtFechaPago"
        Me.txtFechaPago.Size = New System.Drawing.Size(99, 20)
        Me.txtFechaPago.TabIndex = 1
        '
        'txtIdCliente
        '
        Me.txtIdCliente.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtIdCliente.Location = New System.Drawing.Point(347, 155)
        Me.txtIdCliente.Name = "txtIdCliente"
        Me.txtIdCliente.ReadOnly = True
        Me.txtIdCliente.Size = New System.Drawing.Size(33, 20)
        Me.txtIdCliente.TabIndex = 326
        '
        'txtCliente
        '
        Me.txtCliente.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtCliente.Location = New System.Drawing.Point(122, 155)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(258, 20)
        Me.txtCliente.TabIndex = 325
        '
        'lbligvme
        '
        Me.lbligvme.AutoSize = True
        Me.lbligvme.Location = New System.Drawing.Point(296, 209)
        Me.lbligvme.Name = "lbligvme"
        Me.lbligvme.Size = New System.Drawing.Size(29, 13)
        Me.lbligvme.TabIndex = 315
        Me.lbligvme.Text = "0.00"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label13.Location = New System.Drawing.Point(229, 209)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(61, 13)
        Me.Label13.TabIndex = 314
        Me.Label13.Text = "I.G.V. me.:"
        '
        'lbligv
        '
        Me.lbligv.AutoSize = True
        Me.lbligv.Location = New System.Drawing.Point(296, 185)
        Me.lbligv.Name = "lbligv"
        Me.lbligv.Size = New System.Drawing.Size(29, 13)
        Me.lbligv.TabIndex = 313
        Me.lbligv.Text = "0.00"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label10.Location = New System.Drawing.Point(250, 185)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 13)
        Me.Label10.TabIndex = 312
        Me.Label10.Text = "I.G.V.:"
        '
        'lblSerieDoc
        '
        Me.lblSerieDoc.AutoSize = True
        Me.lblSerieDoc.Location = New System.Drawing.Point(119, 134)
        Me.lblSerieDoc.Name = "lblSerieDoc"
        Me.lblSerieDoc.Size = New System.Drawing.Size(19, 13)
        Me.lblSerieDoc.TabIndex = 311
        Me.lblSerieDoc.Text = "00"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label8.Location = New System.Drawing.Point(78, 134)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 13)
        Me.Label8.TabIndex = 310
        Me.Label8.Text = "Serie:"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.LavenderBlush
        Me.Panel3.Controls.Add(Me.txtIDEstablecimientoCaja)
        Me.Panel3.Controls.Add(Me.txtEstablecimientoCaja)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.txtGlosa)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.lblCuenta)
        Me.Panel3.Controls.Add(Me.GroupBox3)
        Me.Panel3.Controls.Add(Me.GroupBox2)
        Me.Panel3.Controls.Add(Me.LinkLabel1)
        Me.Panel3.Controls.Add(Me.txtIdCaja)
        Me.Panel3.Controls.Add(Me.txtCaja)
        Me.Panel3.Controls.Add(Me.Label17)
        Me.Panel3.Controls.Add(Me.Label14)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 245)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(434, 189)
        Me.Panel3.TabIndex = 309
        '
        'txtIDEstablecimientoCaja
        '
        Me.txtIDEstablecimientoCaja.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtIDEstablecimientoCaja.Location = New System.Drawing.Point(333, 79)
        Me.txtIDEstablecimientoCaja.Name = "txtIDEstablecimientoCaja"
        Me.txtIDEstablecimientoCaja.ReadOnly = True
        Me.txtIDEstablecimientoCaja.Size = New System.Drawing.Size(33, 20)
        Me.txtIDEstablecimientoCaja.TabIndex = 333
        '
        'txtEstablecimientoCaja
        '
        Me.txtEstablecimientoCaja.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtEstablecimientoCaja.Location = New System.Drawing.Point(51, 79)
        Me.txtEstablecimientoCaja.Name = "txtEstablecimientoCaja"
        Me.txtEstablecimientoCaja.ReadOnly = True
        Me.txtEstablecimientoCaja.Size = New System.Drawing.Size(280, 20)
        Me.txtEstablecimientoCaja.TabIndex = 332
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(52, 63)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(85, 13)
        Me.Label11.TabIndex = 331
        Me.Label11.Text = "Establecimiento:"
        '
        'txtGlosa
        '
        Me.txtGlosa.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtGlosa.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtGlosa.Location = New System.Drawing.Point(51, 131)
        Me.txtGlosa.Multiline = True
        Me.txtGlosa.Name = "txtGlosa"
        Me.txtGlosa.ReadOnly = True
        Me.txtGlosa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtGlosa.Size = New System.Drawing.Size(377, 46)
        Me.txtGlosa.TabIndex = 330
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 131)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 13)
        Me.Label9.TabIndex = 329
        Me.Label9.Text = "Glosa:"
        '
        'lblCuenta
        '
        Me.lblCuenta.AutoSize = True
        Me.lblCuenta.Location = New System.Drawing.Point(337, 108)
        Me.lblCuenta.Name = "lblCuenta"
        Me.lblCuenta.Size = New System.Drawing.Size(19, 13)
        Me.lblCuenta.TabIndex = 328
        Me.lblCuenta.Text = "00"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rbEfectivo)
        Me.GroupBox3.Controls.Add(Me.rbBanco)
        Me.GroupBox3.Location = New System.Drawing.Point(228, 21)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(200, 38)
        Me.GroupBox3.TabIndex = 327
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Entidad financiera:"
        '
        'rbEfectivo
        '
        Me.rbEfectivo.AutoSize = True
        Me.rbEfectivo.Checked = True
        Me.rbEfectivo.Location = New System.Drawing.Point(18, 15)
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
        Me.rbBanco.Location = New System.Drawing.Point(124, 15)
        Me.rbBanco.Name = "rbBanco"
        Me.rbBanco.Size = New System.Drawing.Size(54, 17)
        Me.rbBanco.TabIndex = 321
        Me.rbBanco.Text = "Banco"
        Me.rbBanco.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbNac)
        Me.GroupBox2.Controls.Add(Me.rbExtra)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 21)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(219, 38)
        Me.GroupBox2.TabIndex = 326
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Moneda:"
        '
        'rbNac
        '
        Me.rbNac.AutoSize = True
        Me.rbNac.Checked = True
        Me.rbNac.Location = New System.Drawing.Point(16, 15)
        Me.rbNac.Name = "rbNac"
        Me.rbNac.Size = New System.Drawing.Size(65, 17)
        Me.rbNac.TabIndex = 317
        Me.rbNac.TabStop = True
        Me.rbNac.Text = "Nacional"
        Me.rbNac.UseVisualStyleBackColor = True
        '
        'rbExtra
        '
        Me.rbExtra.AutoSize = True
        Me.rbExtra.Location = New System.Drawing.Point(122, 15)
        Me.rbExtra.Name = "rbExtra"
        Me.rbExtra.Size = New System.Drawing.Size(76, 17)
        Me.rbExtra.TabIndex = 318
        Me.rbExtra.Text = "Extranjero"
        Me.rbExtra.UseVisualStyleBackColor = True
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(370, 108)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(46, 13)
        Me.LinkLabel1.TabIndex = 325
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Cambiar"
        '
        'txtIdCaja
        '
        Me.txtIdCaja.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtIdCaja.Location = New System.Drawing.Point(333, 104)
        Me.txtIdCaja.Name = "txtIdCaja"
        Me.txtIdCaja.ReadOnly = True
        Me.txtIdCaja.Size = New System.Drawing.Size(33, 20)
        Me.txtIdCaja.TabIndex = 324
        '
        'txtCaja
        '
        Me.txtCaja.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtCaja.Location = New System.Drawing.Point(51, 104)
        Me.txtCaja.Name = "txtCaja"
        Me.txtCaja.ReadOnly = True
        Me.txtCaja.Size = New System.Drawing.Size(280, 20)
        Me.txtCaja.TabIndex = 323
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(16, 108)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(33, 13)
        Me.Label17.TabIndex = 322
        Me.Label17.Text = "Caja:"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Label14.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label14.Location = New System.Drawing.Point(0, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(434, 18)
        Me.Label14.TabIndex = 315
        Me.Label14.Text = "Datos de la transacción"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblImporteme
        '
        Me.lblImporteme.AutoSize = True
        Me.lblImporteme.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteme.Location = New System.Drawing.Point(119, 209)
        Me.lblImporteme.Name = "lblImporteme"
        Me.lblImporteme.Size = New System.Drawing.Size(31, 13)
        Me.lblImporteme.TabIndex = 308
        Me.lblImporteme.Text = "0.00"
        '
        'lblImporte
        '
        Me.lblImporte.AutoSize = True
        Me.lblImporte.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporte.Location = New System.Drawing.Point(119, 185)
        Me.lblImporte.Name = "lblImporte"
        Me.lblImporte.Size = New System.Drawing.Size(31, 13)
        Me.lblImporte.TabIndex = 307
        Me.lblImporte.Text = "0.00"
        '
        'lblNumDoc
        '
        Me.lblNumDoc.AutoSize = True
        Me.lblNumDoc.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumDoc.Location = New System.Drawing.Point(119, 112)
        Me.lblNumDoc.Name = "lblNumDoc"
        Me.lblNumDoc.Size = New System.Drawing.Size(54, 13)
        Me.lblNumDoc.TabIndex = 305
        Me.lblNumDoc.Text = "Nombre:"
        '
        'lblTipoDoc
        '
        Me.lblTipoDoc.AutoSize = True
        Me.lblTipoDoc.Location = New System.Drawing.Point(119, 89)
        Me.lblTipoDoc.Name = "lblTipoDoc"
        Me.lblTipoDoc.Size = New System.Drawing.Size(48, 13)
        Me.lblTipoDoc.TabIndex = 304
        Me.lblTipoDoc.Text = "Nombre:"
        '
        'lblNombreCliente
        '
        Me.lblNombreCliente.AutoSize = True
        Me.lblNombreCliente.BackColor = System.Drawing.Color.MidnightBlue
        Me.lblNombreCliente.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreCliente.ForeColor = System.Drawing.Color.White
        Me.lblNombreCliente.Location = New System.Drawing.Point(119, 65)
        Me.lblNombreCliente.Name = "lblNombreCliente"
        Me.lblNombreCliente.Size = New System.Drawing.Size(53, 13)
        Me.lblNombreCliente.TabIndex = 303
        Me.lblNombreCliente.Text = "Nombre:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label6.Location = New System.Drawing.Point(32, 209)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 13)
        Me.Label6.TabIndex = 302
        Me.Label6.Text = "Importe.me.:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label5.Location = New System.Drawing.Point(56, 185)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 13)
        Me.Label5.TabIndex = 301
        Me.Label5.Text = "Importe:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label4.Location = New System.Drawing.Point(6, 160)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 13)
        Me.Label4.TabIndex = 300
        Me.Label4.Text = "Razón Social/Cliente:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label3.Location = New System.Drawing.Point(25, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 13)
        Me.Label3.TabIndex = 299
        Me.Label3.Text = "Tipo Documento:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label2.Location = New System.Drawing.Point(59, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 298
        Me.Label2.Text = "Número:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.MidnightBlue
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(59, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 297
        Me.Label1.Text = "Nombre:"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel4.Location = New System.Drawing.Point(0, 63)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(434, 21)
        Me.Panel4.TabIndex = 329
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 50)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(909, 47)
        Me.Panel1.TabIndex = 290
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.txtSerie)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.rbFactura)
        Me.GroupBox1.Controls.Add(Me.rbBoleta)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.txtNumFiltro)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(909, 47)
        Me.GroupBox1.TabIndex = 289
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Consultar por:"
        '
        'txtSerie
        '
        Me.txtSerie.Location = New System.Drawing.Point(243, 17)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(72, 19)
        Me.txtSerie.TabIndex = 295
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label15.Location = New System.Drawing.Point(198, 21)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(39, 13)
        Me.Label15.TabIndex = 294
        Me.Label15.Text = "Serie:"
        '
        'rbFactura
        '
        Me.rbFactura.AutoSize = True
        Me.rbFactura.Enabled = False
        Me.rbFactura.ForeColor = System.Drawing.Color.MidnightBlue
        Me.rbFactura.Location = New System.Drawing.Point(103, 20)
        Me.rbFactura.Name = "rbFactura"
        Me.rbFactura.Size = New System.Drawing.Size(62, 17)
        Me.rbFactura.TabIndex = 292
        Me.rbFactura.Tag = "01"
        Me.rbFactura.Text = "Factura"
        Me.rbFactura.UseVisualStyleBackColor = True
        '
        'rbBoleta
        '
        Me.rbBoleta.AutoSize = True
        Me.rbBoleta.Checked = True
        Me.rbBoleta.Enabled = False
        Me.rbBoleta.ForeColor = System.Drawing.Color.MidnightBlue
        Me.rbBoleta.Location = New System.Drawing.Point(25, 20)
        Me.rbBoleta.Name = "rbBoleta"
        Me.rbBoleta.Size = New System.Drawing.Size(55, 17)
        Me.rbBoleta.TabIndex = 291
        Me.rbBoleta.TabStop = True
        Me.rbBoleta.Tag = "03"
        Me.rbBoleta.Text = "Boleta"
        Me.rbBoleta.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label22.Location = New System.Drawing.Point(321, 21)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(54, 13)
        Me.Label22.TabIndex = 290
        Me.Label22.Text = "Número:"
        '
        'txtNumFiltro
        '
        Me.txtNumFiltro.BackColor = System.Drawing.SystemColors.Info
        Me.txtNumFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumFiltro.Location = New System.Drawing.Point(378, 17)
        Me.txtNumFiltro.Name = "txtNumFiltro"
        Me.txtNumFiltro.Size = New System.Drawing.Size(111, 20)
        Me.txtNumFiltro.TabIndex = 288
        '
        'ToolStrip3
        '
        Me.ToolStrip3.BackColor = System.Drawing.Color.White
        Me.ToolStrip3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator3, Me.lblEstado, Me.ToolStripSeparator1, Me.lblIdDoc, Me.ToolStripButton2, Me.menbtnSave})
        Me.ToolStrip3.Location = New System.Drawing.Point(0, 25)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip3.Size = New System.Drawing.Size(909, 25)
        Me.ToolStrip3.TabIndex = 286
        Me.ToolStrip3.Text = "ToolStrip3"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'lblEstado
        '
        Me.lblEstado.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblEstado.ForeColor = System.Drawing.Color.Navy
        Me.lblEstado.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.ok4
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(182, 22)
        Me.lblEstado.Text = "Caja: Confirmar cobro de tickets"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'lblIdDoc
        '
        Me.lblIdDoc.Name = "lblIdDoc"
        Me.lblIdDoc.Size = New System.Drawing.Size(51, 22)
        Me.lblIdDoc.Text = "lblIdDoc"
        Me.lblIdDoc.Visible = False
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripButton2.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ToolStripButton2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(106, 22)
        Me.ToolStripButton2.Text = "Vista Preliminar"
        '
        'menbtnSave
        '
        Me.menbtnSave.BackColor = System.Drawing.Color.Transparent
        Me.menbtnSave.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.menbtnSave.ForeColor = System.Drawing.Color.MidnightBlue
        Me.menbtnSave.Image = CType(resources.GetObject("menbtnSave.Image"), System.Drawing.Image)
        Me.menbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.menbtnSave.Name = "menbtnSave"
        Me.menbtnSave.Size = New System.Drawing.Size(101, 22)
        Me.menbtnSave.Text = "Imprimir Ticket"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.ToolStrip2.BackgroundImage = CType(resources.GetObject("ToolStrip2.BackgroundImage"), System.Drawing.Image)
        Me.ToolStrip2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.lblDescripcion, Me.lblPerido})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip2.Size = New System.Drawing.Size(909, 25)
        Me.ToolStrip2.TabIndex = 319
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ToolStripLabel1.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ToolStripLabel1.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.Information_icon
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(74, 22)
        Me.ToolStripLabel1.Text = "PERIODO:"
        Me.ToolStripLabel1.Visible = False
        '
        'lblDescripcion
        '
        Me.lblDescripcion.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblDescripcion.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.lblDescripcion.Image = CType(resources.GetObject("lblDescripcion.Image"), System.Drawing.Image)
        Me.lblDescripcion.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(203, 22)
        Me.lblDescripcion.Text = "COBRO DE PEDIDOS INTERACTIVOS"
        '
        'lblPerido
        '
        Me.lblPerido.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblPerido.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPerido.ForeColor = System.Drawing.Color.AliceBlue
        Me.lblPerido.Name = "lblPerido"
        Me.lblPerido.Size = New System.Drawing.Size(54, 22)
        Me.lblPerido.Text = "01/2014"
        Me.lblPerido.Visible = False
        '
        'frmPagoTicket
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.GhostWhite
        Me.ClientSize = New System.Drawing.Size(909, 531)
        Me.Controls.Add(Me.lsvDetalle)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip3)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Name = "frmPagoTicket"
        Me.Text = " "
        Me.ContextMenuStrip1.ResumeLayout(false)
        Me.ToolStrip1.ResumeLayout(false)
        Me.ToolStrip1.PerformLayout
        Me.Panel2.ResumeLayout(false)
        Me.Panel2.PerformLayout
        Me.Panel3.ResumeLayout(false)
        Me.Panel3.PerformLayout
        Me.GroupBox3.ResumeLayout(false)
        Me.GroupBox3.PerformLayout
        Me.GroupBox2.ResumeLayout(false)
        Me.GroupBox2.PerformLayout
        Me.Panel1.ResumeLayout(false)
        Me.GroupBox1.ResumeLayout(false)
        Me.GroupBox1.PerformLayout
        Me.ToolStrip3.ResumeLayout(false)
        Me.ToolStrip3.PerformLayout
        Me.ToolStrip2.ResumeLayout(false)
        Me.ToolStrip2.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtNumFiltro As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lblImporteme As System.Windows.Forms.Label
    Friend WithEvents lblImporte As System.Windows.Forms.Label
    Friend WithEvents lblNumDoc As System.Windows.Forms.Label
    Friend WithEvents lblTipoDoc As System.Windows.Forms.Label
    Friend WithEvents lblNombreCliente As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFechaPago As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lbligvme As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lbligv As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblSerieDoc As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents txtIdCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents txtIdCaja As System.Windows.Forms.TextBox
    Friend WithEvents txtCaja As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents rbBanco As System.Windows.Forms.RadioButton
    Friend WithEvents rbEfectivo As System.Windows.Forms.RadioButton
    Friend WithEvents rbExtra As System.Windows.Forms.RadioButton
    Friend WithEvents rbNac As System.Windows.Forms.RadioButton
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lsvDetalle As System.Windows.Forms.ListView
    Friend WithEvents rbFactura As System.Windows.Forms.RadioButton
    Friend WithEvents rbBoleta As System.Windows.Forms.RadioButton
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cboPeriodo As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents lblCuenta As System.Windows.Forms.Label
    Friend WithEvents txtGlosa As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtIDEstablecimientoCaja As System.Windows.Forms.TextBox
    Friend WithEvents txtEstablecimientoCaja As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblTipoCambio As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lblEstado As System.Windows.Forms.ToolStripButton
    Friend WithEvents KryptonManager1 As ComponentFactory.Krypton.Toolkit.KryptonManager
    Private WithEvents PrintTikect As System.Drawing.Printing.PrintDocument
    Private WithEvents PrintPreviewDialogTicket As System.Windows.Forms.PrintPreviewDialog
    Private WithEvents PageSetupDialog1 As System.Windows.Forms.PageSetupDialog
    Friend WithEvents lblIdDoc As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents menbtnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblDescripcion As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblPerido As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtSerie As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
End Class

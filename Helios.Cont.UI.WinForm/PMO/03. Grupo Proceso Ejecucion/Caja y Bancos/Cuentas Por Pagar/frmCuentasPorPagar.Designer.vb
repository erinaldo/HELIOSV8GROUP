<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCuentasPorPagar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCuentasPorPagar))
        Me.ToolStrip4 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripComboBox1 = New System.Windows.Forms.ToolStripComboBox()
        Me.NuevoToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.lblIdCli = New System.Windows.Forms.ToolStripLabel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.lsvCanasta = New System.Windows.Forms.ListView()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.lblPagoME = New System.Windows.Forms.ToolStripLabel()
        Me.lblPagoMN = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStrip6 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel7 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.lsvDocs = New System.Windows.Forms.ListView()
        Me.colIdDocCompra = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColTipoDOc = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colNumDoc = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTipoCambio = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colImportemn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMoneda = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colImpme = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colEstado = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCuenta = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCuenta2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colSaldo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colSaldome = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTipoConpra = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.lblDocsEnct = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.lblPeriodo = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.txtRuc = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtNomProveedor = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtCuentaProv = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lsvDetalleItems = New System.Windows.Forms.ListView()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.lblSaldome = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lblImporteACuentame = New System.Windows.Forms.Label()
        Me.rbEnTramite = New System.Windows.Forms.RadioButton()
        Me.lblSaldo = New System.Windows.Forms.Label()
        Me.rbPagado = New System.Windows.Forms.RadioButton()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblImporteACuenta = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtTipoCompra = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPeriodo = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblIdCliente = New System.Windows.Forms.Label()
        Me.lblIdDocumento = New System.Windows.Forms.Label()
        Me.txtCuentaCliente = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtRucCliente = New System.Windows.Forms.TextBox()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtImporteme = New System.Windows.Forms.TextBox()
        Me.txtTipoCambio = New System.Windows.Forms.TextBox()
        Me.txtImportemn = New System.Windows.Forms.TextBox()
        Me.txtNumDoc = New System.Windows.Forms.TextBox()
        Me.txtTipoDoc = New System.Windows.Forms.TextBox()
        Me.txtIgv = New System.Windows.Forms.TextBox()
        Me.txtFechaVenta = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtMoneda = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtSerieFiltro = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtComprobante = New System.Windows.Forms.TextBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtNumDocFiltro = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtIdComprobante = New System.Windows.Forms.TextBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cboPeriodo = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStrip5 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton()
        Me.lblDescripcion = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStrip4.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.ToolStrip3.SuspendLayout()
        Me.ToolStrip6.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ToolStrip5.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip4
        '
        Me.ToolStrip4.BackColor = System.Drawing.Color.AliceBlue
        Me.ToolStrip4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip4.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton2, Me.ToolStripSeparator3, Me.ToolStripComboBox1, Me.NuevoToolStripButton, Me.ToolStripSeparator1, Me.ToolStripButton3, Me.lblIdCli})
        Me.ToolStrip4.Location = New System.Drawing.Point(0, 25)
        Me.ToolStrip4.Name = "ToolStrip4"
        Me.ToolStrip4.Size = New System.Drawing.Size(889, 25)
        Me.ToolStrip4.TabIndex = 67
        Me.ToolStrip4.Text = "ToolStrip4"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(137, 22)
        Me.ToolStripButton2.Text = "Busqueda interactiva"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripComboBox1
        '
        Me.ToolStripComboBox1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.ToolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ToolStripComboBox1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.ToolStripComboBox1.Items.AddRange(New Object() {"POR DOCUMENTO", "POR PROVEEDOR"})
        Me.ToolStripComboBox1.Name = "ToolStripComboBox1"
        Me.ToolStripComboBox1.Size = New System.Drawing.Size(121, 25)
        '
        'NuevoToolStripButton
        '
        Me.NuevoToolStripButton.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.NuevoToolStripButton.ForeColor = System.Drawing.Color.MidnightBlue
        Me.NuevoToolStripButton.Image = CType(resources.GetObject("NuevoToolStripButton.Image"), System.Drawing.Image)
        Me.NuevoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NuevoToolStripButton.Name = "NuevoToolStripButton"
        Me.NuevoToolStripButton.Size = New System.Drawing.Size(85, 22)
        Me.NuevoToolStripButton.Text = "&Nuevo Pago"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.ForeColor = System.Drawing.Color.Crimson
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(140, 22)
        Me.ToolStripButton3.Text = "Ver historial de Pagos"
        '
        'lblIdCli
        '
        Me.lblIdCli.Name = "lblIdCli"
        Me.lblIdCli.Size = New System.Drawing.Size(18, 22)
        Me.lblIdCli.Text = "ID"
        Me.lblIdCli.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 50)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(889, 433)
        Me.TabControl1.TabIndex = 68
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Panel8)
        Me.TabPage1.Controls.Add(Me.Panel6)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(881, 407)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Búsqueda interactiva por proveedor."
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.lsvCanasta)
        Me.Panel8.Controls.Add(Me.Panel10)
        Me.Panel8.Controls.Add(Me.ToolStrip6)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel8.Location = New System.Drawing.Point(3, 216)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(875, 188)
        Me.Panel8.TabIndex = 15
        '
        'lsvCanasta
        '
        Me.lsvCanasta.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.lsvCanasta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvCanasta.FullRowSelect = True
        Me.lsvCanasta.GridLines = True
        Me.lsvCanasta.Location = New System.Drawing.Point(0, 25)
        Me.lsvCanasta.Name = "lsvCanasta"
        Me.lsvCanasta.Size = New System.Drawing.Size(875, 140)
        Me.lsvCanasta.TabIndex = 5
        Me.lsvCanasta.UseCompatibleStateImageBehavior = False
        Me.lsvCanasta.View = System.Windows.Forms.View.Details
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.ToolStrip3)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel10.Location = New System.Drawing.Point(0, 165)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(875, 23)
        Me.Panel10.TabIndex = 6
        '
        'ToolStrip3
        '
        Me.ToolStrip3.BackgroundImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.background
        Me.ToolStrip3.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.ToolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblPagoME, Me.lblPagoMN, Me.ToolStripLabel3, Me.ToolStripSeparator4, Me.ToolStripSeparator5})
        Me.ToolStrip3.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip3.Size = New System.Drawing.Size(875, 25)
        Me.ToolStrip3.TabIndex = 0
        Me.ToolStrip3.Text = "ToolStrip3"
        '
        'lblPagoME
        '
        Me.lblPagoME.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblPagoME.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblPagoME.Name = "lblPagoME"
        Me.lblPagoME.Size = New System.Drawing.Size(29, 22)
        Me.lblPagoME.Text = "0.00"
        '
        'lblPagoMN
        '
        Me.lblPagoMN.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblPagoMN.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPagoMN.Name = "lblPagoMN"
        Me.lblPagoMN.Size = New System.Drawing.Size(35, 22)
        Me.lblPagoMN.Text = "0.00"
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(75, 22)
        Me.ToolStripLabel3.Text = "Total a Pagar:"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStrip6
        '
        Me.ToolStrip6.BackgroundImage = CType(resources.GetObject("ToolStrip6.BackgroundImage"), System.Drawing.Image)
        Me.ToolStrip6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip6.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip6.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel7, Me.ToolStripSeparator8})
        Me.ToolStrip6.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip6.Name = "ToolStrip6"
        Me.ToolStrip6.Size = New System.Drawing.Size(875, 25)
        Me.ToolStrip6.TabIndex = 2
        Me.ToolStrip6.Text = "ToolStrip6"
        '
        'ToolStripLabel7
        '
        Me.ToolStripLabel7.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripLabel7.Name = "ToolStripLabel7"
        Me.ToolStripLabel7.Size = New System.Drawing.Size(118, 22)
        Me.ToolStripLabel7.Text = "Canasta de compra::::"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.Panel9)
        Me.Panel6.Controls.Add(Me.Panel7)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(3, 3)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(875, 213)
        Me.Panel6.TabIndex = 13
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.lsvDocs)
        Me.Panel9.Controls.Add(Me.ToolStrip1)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel9.Location = New System.Drawing.Point(0, 33)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(875, 180)
        Me.Panel9.TabIndex = 24
        '
        'lsvDocs
        '
        Me.lsvDocs.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colIdDocCompra, Me.ColTipoDOc, Me.colNumDoc, Me.colTipoCambio, Me.colImportemn, Me.colMoneda, Me.colImpme, Me.colEstado, Me.colCuenta, Me.colCuenta2, Me.colSaldo, Me.colSaldome, Me.colTipoConpra})
        Me.lsvDocs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvDocs.FullRowSelect = True
        Me.lsvDocs.GridLines = True
        Me.lsvDocs.HideSelection = False
        Me.lsvDocs.Location = New System.Drawing.Point(0, 25)
        Me.lsvDocs.MultiSelect = False
        Me.lsvDocs.Name = "lsvDocs"
        Me.lsvDocs.Size = New System.Drawing.Size(875, 155)
        Me.lsvDocs.TabIndex = 0
        Me.lsvDocs.UseCompatibleStateImageBehavior = False
        Me.lsvDocs.View = System.Windows.Forms.View.Details
        '
        'colIdDocCompra
        '
        Me.colIdDocCompra.Text = "ID"
        Me.colIdDocCompra.Width = 0
        '
        'ColTipoDOc
        '
        Me.ColTipoDOc.Text = "Tipo Doc."
        Me.ColTipoDOc.Width = 65
        '
        'colNumDoc
        '
        Me.colNumDoc.Text = "Nro. documento"
        Me.colNumDoc.Width = 139
        '
        'colTipoCambio
        '
        Me.colTipoCambio.Text = "t/c"
        Me.colTipoCambio.Width = 43
        '
        'colImportemn
        '
        Me.colImportemn.Text = "Importe s/."
        Me.colImportemn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colImportemn.Width = 78
        '
        'colMoneda
        '
        Me.colMoneda.Text = "Moneda"
        Me.colMoneda.Width = 22
        '
        'colImpme
        '
        Me.colImpme.Text = "Importe m.e."
        Me.colImpme.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colImpme.Width = 81
        '
        'colEstado
        '
        Me.colEstado.Text = "Estado"
        Me.colEstado.Width = 47
        '
        'colCuenta
        '
        Me.colCuenta.Text = "A cuenta s/."
        Me.colCuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colCuenta.Width = 0
        '
        'colCuenta2
        '
        Me.colCuenta2.Text = "A cuenta m.e."
        Me.colCuenta2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colCuenta2.Width = 0
        '
        'colSaldo
        '
        Me.colSaldo.Text = "Saldo s/."
        Me.colSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colSaldo.Width = 0
        '
        'colSaldome
        '
        Me.colSaldome.Text = "Saldo m.e."
        Me.colSaldome.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colSaldome.Width = 0
        '
        'colTipoConpra
        '
        Me.colTipoConpra.Text = "Tipo compra"
        Me.colTipoConpra.Width = 120
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackgroundImage = CType(resources.GetObject("ToolStrip1.BackgroundImage"), System.Drawing.Image)
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel2, Me.lblDocsEnct, Me.ToolStripSeparator2, Me.ToolStripButton4, Me.lblPeriodo, Me.ToolStripLabel1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(875, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(147, 22)
        Me.ToolStripLabel2.Text = "Documentos Encontrados:"
        '
        'lblDocsEnct
        '
        Me.lblDocsEnct.Name = "lblDocsEnct"
        Me.lblDocsEnct.Size = New System.Drawing.Size(13, 22)
        Me.lblDocsEnct.Text = "0"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton4.Text = "Actulizar información"
        '
        'lblPeriodo
        '
        Me.lblPeriodo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblPeriodo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPeriodo.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblPeriodo.Name = "lblPeriodo"
        Me.lblPeriodo.Size = New System.Drawing.Size(54, 22)
        Me.lblPeriodo.Text = "01/2014"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ToolStripLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ToolStripLabel1.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.Information_icon
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(74, 22)
        Me.ToolStripLabel1.Text = "PERIODO:"
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.txtRuc)
        Me.Panel7.Controls.Add(Me.Label22)
        Me.Panel7.Controls.Add(Me.Label20)
        Me.Panel7.Controls.Add(Me.txtNomProveedor)
        Me.Panel7.Controls.Add(Me.Label17)
        Me.Panel7.Controls.Add(Me.txtCuentaProv)
        Me.Panel7.Controls.Add(Me.Button2)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(875, 33)
        Me.Panel7.TabIndex = 27
        '
        'txtRuc
        '
        Me.txtRuc.BackColor = System.Drawing.Color.Thistle
        Me.txtRuc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRuc.Location = New System.Drawing.Point(54, 6)
        Me.txtRuc.Name = "txtRuc"
        Me.txtRuc.ReadOnly = True
        Me.txtRuc.Size = New System.Drawing.Size(110, 20)
        Me.txtRuc.TabIndex = 2
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(170, 10)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(61, 13)
        Me.Label22.TabIndex = 26
        Me.Label22.Text = "Proveedor:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(7, 10)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(44, 13)
        Me.Label20.TabIndex = 5
        Me.Label20.Text = "R.U.C.:"
        '
        'txtNomProveedor
        '
        Me.txtNomProveedor.BackColor = System.Drawing.Color.Thistle
        Me.txtNomProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNomProveedor.Location = New System.Drawing.Point(234, 6)
        Me.txtNomProveedor.Name = "txtNomProveedor"
        Me.txtNomProveedor.ReadOnly = True
        Me.txtNomProveedor.Size = New System.Drawing.Size(258, 20)
        Me.txtNomProveedor.TabIndex = 25
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(537, 10)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(46, 13)
        Me.Label17.TabIndex = 4
        Me.Label17.Text = "Cuenta:"
        '
        'txtCuentaProv
        '
        Me.txtCuentaProv.BackColor = System.Drawing.Color.Thistle
        Me.txtCuentaProv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuentaProv.Location = New System.Drawing.Point(586, 6)
        Me.txtCuentaProv.Name = "txtCuentaProv"
        Me.txtCuentaProv.ReadOnly = True
        Me.txtCuentaProv.Size = New System.Drawing.Size(50, 20)
        Me.txtCuentaProv.TabIndex = 3
        '
        'Button2
        '
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(492, 5)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(36, 23)
        Me.Button2.TabIndex = 12
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Panel3)
        Me.TabPage2.Controls.Add(Me.Panel2)
        Me.TabPage2.Controls.Add(Me.Panel1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(881, 407)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Documento"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.LavenderBlush
        Me.Panel3.BackgroundImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.background
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel3.Controls.Add(Me.GroupBox3)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(457, 46)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(421, 358)
        Me.Panel3.TabIndex = 15
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.Panel4)
        Me.GroupBox3.Controls.Add(Me.Panel5)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(421, 358)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Estado de pago del documento"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.lsvDetalleItems)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 98)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(415, 257)
        Me.Panel4.TabIndex = 24
        '
        'lsvDetalleItems
        '
        Me.lsvDetalleItems.BackColor = System.Drawing.Color.GhostWhite
        Me.lsvDetalleItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvDetalleItems.FullRowSelect = True
        Me.lsvDetalleItems.Location = New System.Drawing.Point(0, 0)
        Me.lsvDetalleItems.Name = "lsvDetalleItems"
        Me.lsvDetalleItems.Size = New System.Drawing.Size(415, 257)
        Me.lsvDetalleItems.TabIndex = 4
        Me.lsvDetalleItems.UseCompatibleStateImageBehavior = False
        Me.lsvDetalleItems.View = System.Windows.Forms.View.Details
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.lblSaldome)
        Me.Panel5.Controls.Add(Me.Label18)
        Me.Panel5.Controls.Add(Me.Label19)
        Me.Panel5.Controls.Add(Me.lblImporteACuentame)
        Me.Panel5.Controls.Add(Me.rbEnTramite)
        Me.Panel5.Controls.Add(Me.lblSaldo)
        Me.Panel5.Controls.Add(Me.rbPagado)
        Me.Panel5.Controls.Add(Me.Label16)
        Me.Panel5.Controls.Add(Me.Label13)
        Me.Panel5.Controls.Add(Me.lblImporteACuenta)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(3, 16)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(415, 82)
        Me.Panel5.TabIndex = 23
        '
        'lblSaldome
        '
        Me.lblSaldome.AutoSize = True
        Me.lblSaldome.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaldome.Location = New System.Drawing.Point(319, 60)
        Me.lblSaldome.Name = "lblSaldome"
        Me.lblSaldome.Size = New System.Drawing.Size(31, 13)
        Me.lblSaldome.TabIndex = 26
        Me.lblSaldome.Text = "0.00"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(199, 60)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(117, 13)
        Me.Label18.TabIndex = 25
        Me.Label18.Text = "Saldo de la deuda m.e:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label19.Location = New System.Drawing.Point(14, 60)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(118, 13)
        Me.Label19.TabIndex = 23
        Me.Label19.Text = "Importe de abono m.e:"
        '
        'lblImporteACuentame
        '
        Me.lblImporteACuentame.AutoSize = True
        Me.lblImporteACuentame.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteACuentame.Location = New System.Drawing.Point(138, 60)
        Me.lblImporteACuentame.Name = "lblImporteACuentame"
        Me.lblImporteACuentame.Size = New System.Drawing.Size(31, 13)
        Me.lblImporteACuentame.TabIndex = 24
        Me.lblImporteACuentame.Text = "0.00"
        '
        'rbEnTramite
        '
        Me.rbEnTramite.AutoSize = True
        Me.rbEnTramite.Enabled = False
        Me.rbEnTramite.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.rbEnTramite.Location = New System.Drawing.Point(60, 10)
        Me.rbEnTramite.Name = "rbEnTramite"
        Me.rbEnTramite.Size = New System.Drawing.Size(116, 17)
        Me.rbEnTramite.TabIndex = 1
        Me.rbEnTramite.TabStop = True
        Me.rbEnTramite.Text = "En tramite de pago"
        Me.rbEnTramite.UseVisualStyleBackColor = True
        '
        'lblSaldo
        '
        Me.lblSaldo.AutoSize = True
        Me.lblSaldo.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaldo.Location = New System.Drawing.Point(319, 38)
        Me.lblSaldo.Name = "lblSaldo"
        Me.lblSaldo.Size = New System.Drawing.Size(31, 13)
        Me.lblSaldo.TabIndex = 22
        Me.lblSaldo.Text = "0.00"
        '
        'rbPagado
        '
        Me.rbPagado.AutoSize = True
        Me.rbPagado.Enabled = False
        Me.rbPagado.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.rbPagado.Location = New System.Drawing.Point(234, 10)
        Me.rbPagado.Name = "rbPagado"
        Me.rbPagado.Size = New System.Drawing.Size(61, 17)
        Me.rbPagado.TabIndex = 0
        Me.rbPagado.TabStop = True
        Me.rbPagado.Text = "Pagado"
        Me.rbPagado.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(199, 38)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(96, 13)
        Me.Label16.TabIndex = 21
        Me.Label16.Text = "Saldo de la deuda:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label13.Location = New System.Drawing.Point(35, 38)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(97, 13)
        Me.Label13.TabIndex = 19
        Me.Label13.Text = "Importe de abono:"
        '
        'lblImporteACuenta
        '
        Me.lblImporteACuenta.AutoSize = True
        Me.lblImporteACuenta.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteACuenta.Location = New System.Drawing.Point(138, 38)
        Me.lblImporteACuenta.Name = "lblImporteACuenta"
        Me.lblImporteACuenta.Size = New System.Drawing.Size(31, 13)
        Me.lblImporteACuenta.TabIndex = 20
        Me.lblImporteACuenta.Text = "0.00"
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.background
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(3, 46)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(454, 358)
        Me.Panel2.TabIndex = 14
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtTipoCompra)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtPeriodo)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.lblIdCliente)
        Me.GroupBox1.Controls.Add(Me.lblIdDocumento)
        Me.GroupBox1.Controls.Add(Me.txtCuentaCliente)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.txtRucCliente)
        Me.GroupBox1.Controls.Add(Me.txtCliente)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtImporteme)
        Me.GroupBox1.Controls.Add(Me.txtTipoCambio)
        Me.GroupBox1.Controls.Add(Me.txtImportemn)
        Me.GroupBox1.Controls.Add(Me.txtNumDoc)
        Me.GroupBox1.Controls.Add(Me.txtTipoDoc)
        Me.GroupBox1.Controls.Add(Me.txtIgv)
        Me.GroupBox1.Controls.Add(Me.txtFechaVenta)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtMoneda)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(454, 358)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Información del documento:"
        '
        'txtTipoCompra
        '
        Me.txtTipoCompra.BackColor = System.Drawing.Color.Thistle
        Me.txtTipoCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTipoCompra.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoCompra.Location = New System.Drawing.Point(105, 320)
        Me.txtTipoCompra.Name = "txtTipoCompra"
        Me.txtTipoCompra.ReadOnly = True
        Me.txtTipoCompra.Size = New System.Drawing.Size(138, 20)
        Me.txtTipoCompra.TabIndex = 28
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 324)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Tipo Compra:"
        '
        'txtPeriodo
        '
        Me.txtPeriodo.BackColor = System.Drawing.Color.LavenderBlush
        Me.txtPeriodo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPeriodo.Location = New System.Drawing.Point(105, 29)
        Me.txtPeriodo.Name = "txtPeriodo"
        Me.txtPeriodo.ReadOnly = True
        Me.txtPeriodo.Size = New System.Drawing.Size(68, 20)
        Me.txtPeriodo.TabIndex = 26
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(52, 33)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(47, 13)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "Período:"
        '
        'lblIdCliente
        '
        Me.lblIdCliente.AutoSize = True
        Me.lblIdCliente.Location = New System.Drawing.Point(197, 190)
        Me.lblIdCliente.Name = "lblIdCliente"
        Me.lblIdCliente.Size = New System.Drawing.Size(44, 13)
        Me.lblIdCliente.TabIndex = 24
        Me.lblIdCliente.Text = "Cliente:"
        Me.lblIdCliente.Visible = False
        '
        'lblIdDocumento
        '
        Me.lblIdDocumento.AutoSize = True
        Me.lblIdDocumento.Location = New System.Drawing.Point(318, 57)
        Me.lblIdDocumento.Name = "lblIdDocumento"
        Me.lblIdDocumento.Size = New System.Drawing.Size(18, 13)
        Me.lblIdDocumento.TabIndex = 23
        Me.lblIdDocumento.Text = "ID"
        Me.lblIdDocumento.Visible = False
        '
        'txtCuentaCliente
        '
        Me.txtCuentaCliente.BackColor = System.Drawing.Color.Thistle
        Me.txtCuentaCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuentaCliente.Location = New System.Drawing.Point(105, 185)
        Me.txtCuentaCliente.Name = "txtCuentaCliente"
        Me.txtCuentaCliente.ReadOnly = True
        Me.txtCuentaCliente.Size = New System.Drawing.Size(68, 20)
        Me.txtCuentaCliente.TabIndex = 22
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(7, 190)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(92, 13)
        Me.Label15.TabIndex = 21
        Me.Label15.Text = "Cuenta Contable:"
        '
        'txtRucCliente
        '
        Me.txtRucCliente.BackColor = System.Drawing.Color.Thistle
        Me.txtRucCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRucCliente.Location = New System.Drawing.Point(383, 159)
        Me.txtRucCliente.Name = "txtRucCliente"
        Me.txtRucCliente.ReadOnly = True
        Me.txtRucCliente.Size = New System.Drawing.Size(68, 20)
        Me.txtRucCliente.TabIndex = 20
        '
        'txtCliente
        '
        Me.txtCliente.BackColor = System.Drawing.Color.Thistle
        Me.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCliente.Location = New System.Drawing.Point(105, 159)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(277, 20)
        Me.txtCliente.TabIndex = 19
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(55, 163)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(44, 13)
        Me.Label11.TabIndex = 18
        Me.Label11.Text = "Cliente:"
        '
        'txtImporteme
        '
        Me.txtImporteme.BackColor = System.Drawing.Color.Thistle
        Me.txtImporteme.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtImporteme.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImporteme.Location = New System.Drawing.Point(105, 294)
        Me.txtImporteme.Name = "txtImporteme"
        Me.txtImporteme.ReadOnly = True
        Me.txtImporteme.Size = New System.Drawing.Size(138, 20)
        Me.txtImporteme.TabIndex = 17
        Me.txtImporteme.Text = "0.00"
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.BackColor = System.Drawing.Color.LavenderBlush
        Me.txtTipoCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTipoCambio.Location = New System.Drawing.Point(105, 133)
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.ReadOnly = True
        Me.txtTipoCambio.Size = New System.Drawing.Size(136, 20)
        Me.txtTipoCambio.TabIndex = 13
        '
        'txtImportemn
        '
        Me.txtImportemn.BackColor = System.Drawing.Color.Thistle
        Me.txtImportemn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtImportemn.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImportemn.Location = New System.Drawing.Point(105, 265)
        Me.txtImportemn.Name = "txtImportemn"
        Me.txtImportemn.ReadOnly = True
        Me.txtImportemn.Size = New System.Drawing.Size(138, 20)
        Me.txtImportemn.TabIndex = 16
        Me.txtImportemn.Text = "0.00"
        '
        'txtNumDoc
        '
        Me.txtNumDoc.BackColor = System.Drawing.Color.LavenderBlush
        Me.txtNumDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumDoc.Location = New System.Drawing.Point(105, 107)
        Me.txtNumDoc.Name = "txtNumDoc"
        Me.txtNumDoc.ReadOnly = True
        Me.txtNumDoc.Size = New System.Drawing.Size(198, 20)
        Me.txtNumDoc.TabIndex = 12
        '
        'txtTipoDoc
        '
        Me.txtTipoDoc.BackColor = System.Drawing.Color.LavenderBlush
        Me.txtTipoDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTipoDoc.Location = New System.Drawing.Point(105, 81)
        Me.txtTipoDoc.Name = "txtTipoDoc"
        Me.txtTipoDoc.ReadOnly = True
        Me.txtTipoDoc.Size = New System.Drawing.Size(198, 20)
        Me.txtTipoDoc.TabIndex = 11
        '
        'txtIgv
        '
        Me.txtIgv.BackColor = System.Drawing.Color.LavenderBlush
        Me.txtIgv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIgv.Location = New System.Drawing.Point(105, 239)
        Me.txtIgv.Name = "txtIgv"
        Me.txtIgv.ReadOnly = True
        Me.txtIgv.Size = New System.Drawing.Size(100, 20)
        Me.txtIgv.TabIndex = 15
        '
        'txtFechaVenta
        '
        Me.txtFechaVenta.BackColor = System.Drawing.Color.LavenderBlush
        Me.txtFechaVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaVenta.Location = New System.Drawing.Point(105, 55)
        Me.txtFechaVenta.Name = "txtFechaVenta"
        Me.txtFechaVenta.ReadOnly = True
        Me.txtFechaVenta.Size = New System.Drawing.Size(136, 20)
        Me.txtFechaVenta.TabIndex = 10
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(50, 217)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Moneda:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(30, 137)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Tipo Cambio:"
        '
        'txtMoneda
        '
        Me.txtMoneda.BackColor = System.Drawing.Color.LavenderBlush
        Me.txtMoneda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMoneda.Location = New System.Drawing.Point(105, 213)
        Me.txtMoneda.Name = "txtMoneda"
        Me.txtMoneda.ReadOnly = True
        Me.txtMoneda.Size = New System.Drawing.Size(100, 20)
        Me.txtMoneda.TabIndex = 14
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(59, 242)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "I.G.V.:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 110)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Serie - Número:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(29, 268)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 13)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Importe m.n."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Tipo documento:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(29, 298)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(70, 13)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Importe m.e."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Fecha de venta:"
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.background
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.txtSerieFiltro)
        Me.Panel1.Controls.Add(Me.Label21)
        Me.Panel1.Controls.Add(Me.txtComprobante)
        Me.Panel1.Controls.Add(Me.LinkLabel1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.txtNumDocFiltro)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.txtIdComprobante)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(875, 43)
        Me.Panel1.TabIndex = 13
        '
        'txtSerieFiltro
        '
        Me.txtSerieFiltro.BackColor = System.Drawing.SystemColors.Info
        Me.txtSerieFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSerieFiltro.Location = New System.Drawing.Point(436, 14)
        Me.txtSerieFiltro.Name = "txtSerieFiltro"
        Me.txtSerieFiltro.Size = New System.Drawing.Size(86, 20)
        Me.txtSerieFiltro.TabIndex = 14
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(398, 18)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(35, 13)
        Me.Label21.TabIndex = 13
        Me.Label21.Text = "Serie:"
        '
        'txtComprobante
        '
        Me.txtComprobante.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.txtComprobante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComprobante.Location = New System.Drawing.Point(123, 14)
        Me.txtComprobante.Name = "txtComprobante"
        Me.txtComprobante.Size = New System.Drawing.Size(189, 20)
        Me.txtComprobante.TabIndex = 10
        Me.txtComprobante.Text = "BOLETA DE VENTA"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(315, 18)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(44, 13)
        Me.LinkLabel1.TabIndex = 12
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "cambiar"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(530, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nro. documento:"
        '
        'Button1
        '
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(724, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(36, 23)
        Me.Button1.TabIndex = 11
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtNumDocFiltro
        '
        Me.txtNumDocFiltro.BackColor = System.Drawing.SystemColors.Info
        Me.txtNumDocFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumDocFiltro.Location = New System.Drawing.Point(621, 14)
        Me.txtNumDocFiltro.Name = "txtNumDocFiltro"
        Me.txtNumDocFiltro.Size = New System.Drawing.Size(103, 20)
        Me.txtNumDocFiltro.TabIndex = 2
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(9, 19)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(76, 13)
        Me.Label14.TabIndex = 8
        Me.Label14.Text = "Comprobante:"
        '
        'txtIdComprobante
        '
        Me.txtIdComprobante.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.txtIdComprobante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIdComprobante.Location = New System.Drawing.Point(91, 14)
        Me.txtIdComprobante.Name = "txtIdComprobante"
        Me.txtIdComprobante.Size = New System.Drawing.Size(30, 20)
        Me.txtIdComprobante.TabIndex = 9
        Me.txtIdComprobante.Tag = "03"
        Me.txtIdComprobante.Text = "03"
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
        'ToolStrip5
        '
        Me.ToolStrip5.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.ToolStrip5.BackgroundImage = CType(resources.GetObject("ToolStrip5.BackgroundImage"), System.Drawing.Image)
        Me.ToolStrip5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip5.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton7, Me.lblDescripcion})
        Me.ToolStrip5.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip5.Name = "ToolStrip5"
        Me.ToolStrip5.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip5.Size = New System.Drawing.Size(889, 25)
        Me.ToolStrip5.TabIndex = 292
        Me.ToolStrip5.Text = "ToolStrip5"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton7.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.arrow_circle_135_left
        Me.ToolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton7.Text = "Salir"
        Me.ToolStripButton7.Visible = False
        '
        'lblDescripcion
        '
        Me.lblDescripcion.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblDescripcion.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.lblDescripcion.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources._002
        Me.lblDescripcion.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(130, 22)
        Me.lblDescripcion.Text = "CUENTAS POR PAGAR"
        Me.lblDescripcion.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'frmCuentasPorPagar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.GhostWhite
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(889, 483)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ToolStrip4)
        Me.Controls.Add(Me.ToolStrip5)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmCuentasPorPagar"
        Me.Text = "Cuentas por pagar"
        Me.ToolStrip4.ResumeLayout(False)
        Me.ToolStrip4.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.ToolStrip6.ResumeLayout(False)
        Me.ToolStrip6.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ToolStrip5.ResumeLayout(False)
        Me.ToolStrip5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip4 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripComboBox1 As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents NuevoToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblIdCli As System.Windows.Forms.ToolStripLabel
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents lsvCanasta As System.Windows.Forms.ListView
    Friend WithEvents ToolStrip6 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel7 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents lsvDocs As System.Windows.Forms.ListView
    Friend WithEvents colIdDocCompra As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColTipoDOc As System.Windows.Forms.ColumnHeader
    Friend WithEvents colNumDoc As System.Windows.Forms.ColumnHeader
    Friend WithEvents colTipoCambio As System.Windows.Forms.ColumnHeader
    Friend WithEvents colImportemn As System.Windows.Forms.ColumnHeader
    Friend WithEvents colMoneda As System.Windows.Forms.ColumnHeader
    Friend WithEvents colImpme As System.Windows.Forms.ColumnHeader
    Friend WithEvents colEstado As System.Windows.Forms.ColumnHeader
    Friend WithEvents colCuenta As System.Windows.Forms.ColumnHeader
    Friend WithEvents colCuenta2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents colSaldo As System.Windows.Forms.ColumnHeader
    Friend WithEvents colSaldome As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblDocsEnct As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblPeriodo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents txtRuc As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtNomProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtCuentaProv As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents lsvDetalleItems As System.Windows.Forms.ListView
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents lblSaldome As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents lblImporteACuentame As System.Windows.Forms.Label
    Friend WithEvents rbEnTramite As System.Windows.Forms.RadioButton
    Friend WithEvents lblSaldo As System.Windows.Forms.Label
    Friend WithEvents rbPagado As System.Windows.Forms.RadioButton
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblImporteACuenta As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPeriodo As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblIdCliente As System.Windows.Forms.Label
    Friend WithEvents lblIdDocumento As System.Windows.Forms.Label
    Friend WithEvents txtCuentaCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtRucCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtImporteme As System.Windows.Forms.TextBox
    Friend WithEvents txtTipoCambio As System.Windows.Forms.TextBox
    Friend WithEvents txtImportemn As System.Windows.Forms.TextBox
    Friend WithEvents txtNumDoc As System.Windows.Forms.TextBox
    Friend WithEvents txtTipoDoc As System.Windows.Forms.TextBox
    Friend WithEvents txtIgv As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaVenta As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtMoneda As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtComprobante As System.Windows.Forms.TextBox
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtNumDocFiltro As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtIdComprobante As System.Windows.Forms.TextBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cboPeriodo As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents lblPagoME As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblPagoMN As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents colTipoConpra As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtTipoCompra As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSerieFiltro As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip5 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblDescripcion As System.Windows.Forms.ToolStripLabel
End Class

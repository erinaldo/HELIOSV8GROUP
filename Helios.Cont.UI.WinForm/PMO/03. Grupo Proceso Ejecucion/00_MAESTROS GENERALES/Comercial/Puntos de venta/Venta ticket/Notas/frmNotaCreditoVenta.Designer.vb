<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNotaCreditoVenta
    Inherits Helios.Cont.Presentation.WinForm.frmMaster

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNotaCreditoVenta))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.lblEstado = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.GuardarToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.lblPerido = New System.Windows.Forms.ToolStripLabel()
        Me.lblTitulo = New System.Windows.Forms.ToolStripLabel()
        Me.PegarToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblIdDocumento = New System.Windows.Forms.ToolStripLabel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.btnInfoCompra = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.dockingClientPanel1 = New Syncfusion.Windows.Forms.Tools.DockingClientPanel()
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.PanelDGV = New System.Windows.Forms.Panel()
        Me.PanelDetalleCompra = New System.Windows.Forms.Panel()
        Me.lsvCanasta = New System.Windows.Forms.ListView()
        Me.colSec = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colIdItem = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colItem = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colUM = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colPres = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCantidad = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colImportemn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colImporteme = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colIdAlmacen = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colIdActividad = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTipoEx = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colNotaMn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colNotaME = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colDebitoMN = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colNBMe = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTotalmn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTotalME = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCanCredito = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCantDebito = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTotalCant = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.dgvNuevoDoc = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.Secue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Gravado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDArticulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Art = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.uni2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cant2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Uni1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Can1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Prec = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecUnitUS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImporteNeto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImporteUS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kardex = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ISC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.igv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.otrostributos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Kardexus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ISCus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IGVus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OTCus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TipoExistencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cuenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cbopreEvento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Evento = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.IDDocref = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Movimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBonif = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colFecVcto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colValorCheck = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAlmacenRef = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCantidadBack = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colImporteBack = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtTipoCambio = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.txtIgv = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.btnVer = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblBonificaME = New System.Windows.Forms.Label()
        Me.lblBonificaMN = New System.Windows.Forms.Label()
        Me.lblTotalUS = New System.Windows.Forms.Label()
        Me.Label79 = New System.Windows.Forms.Label()
        Me.lblTotalAdquisiones = New System.Windows.Forms.Label()
        Me.lblTotales = New System.Windows.Forms.Label()
        Me.lblTotalMontoIgvUS = New System.Windows.Forms.Label()
        Me.lblTotalBaseUS = New System.Windows.Forms.Label()
        Me.lblTotalIScUS = New System.Windows.Forms.Label()
        Me.lblOtrostribTotalUS = New System.Windows.Forms.Label()
        Me.lblOtrostribTotal = New System.Windows.Forms.Label()
        Me.lblTotalMontoIgv = New System.Windows.Forms.Label()
        Me.lblTotalISc = New System.Windows.Forms.Label()
        Me.lblTotalBase = New System.Windows.Forms.Label()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.txtConf = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GradientPanel3 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.QRibbonInputBox2 = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.QRibbonInputBox1 = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtNumeroGuia = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.txtSerieGuia = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.panel15 = New System.Windows.Forms.Panel()
        Me.label35 = New System.Windows.Forms.Label()
        Me.gpVSBehavior = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.txtIdComprobanteNota = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.txtNota = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.txtFechaComprobante = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.txtNumero = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.txtSerie = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.dockingManager1 = New Syncfusion.Windows.Forms.Tools.DockingManager(Me.components)
        Me.QGlobalColorSchemeManager1 = New Qios.DevSuite.Components.QGlobalColorSchemeManager(Me.components)
        Me.ToolStrip1.SuspendLayout()
        Me.ToolStrip3.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.dockingClientPanel1.SuspendLayout()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        Me.PanelDGV.SuspendLayout()
        Me.PanelDetalleCompra.SuspendLayout()
        CType(Me.dgvNuevoDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        CType(Me.txtTipoCambio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel3.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.panel15.SuspendLayout()
        CType(Me.gpVSBehavior, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpVSBehavior.SuspendLayout()
        CType(Me.txtFechaComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaComprobante.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dockingManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblEstado})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 25)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(960, 25)
        Me.ToolStrip1.TabIndex = 411
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'lblEstado
        '
        Me.lblEstado.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblEstado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblEstado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(161, 22)
        Me.lblEstado.Text = "Estado: nueva nota de credito."
        '
        'ToolStrip3
        '
        Me.ToolStrip3.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GuardarToolStripButton, Me.lblPerido, Me.lblTitulo, Me.PegarToolStripButton, Me.toolStripSeparator1, Me.lblIdDocumento})
        Me.ToolStrip3.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip3.Size = New System.Drawing.Size(960, 25)
        Me.ToolStrip3.TabIndex = 412
        Me.ToolStrip3.Text = "ToolStrip3"
        '
        'GuardarToolStripButton
        '
        Me.GuardarToolStripButton.Image = CType(resources.GetObject("GuardarToolStripButton.Image"), System.Drawing.Image)
        Me.GuardarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.GuardarToolStripButton.Name = "GuardarToolStripButton"
        Me.GuardarToolStripButton.Size = New System.Drawing.Size(62, 22)
        Me.GuardarToolStripButton.Text = "&Grabar"
        '
        'lblPerido
        '
        Me.lblPerido.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblPerido.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblPerido.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblPerido.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.iconoBusqueda
        Me.lblPerido.Name = "lblPerido"
        Me.lblPerido.Size = New System.Drawing.Size(71, 22)
        Me.lblPerido.Text = "01/2014"
        Me.lblPerido.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'lblTitulo
        '
        Me.lblTitulo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblTitulo.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(57, 22)
        Me.lblTitulo.Text = "PERIODO:"
        '
        'PegarToolStripButton
        '
        Me.PegarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PegarToolStripButton.Image = CType(resources.GetObject("PegarToolStripButton.Image"), System.Drawing.Image)
        Me.PegarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PegarToolStripButton.Name = "PegarToolStripButton"
        Me.PegarToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PegarToolStripButton.Text = "&Cancelar"
        Me.PegarToolStripButton.Visible = False
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'lblIdDocumento
        '
        Me.lblIdDocumento.Name = "lblIdDocumento"
        Me.lblIdDocumento.Size = New System.Drawing.Size(19, 22)
        Me.lblIdDocumento.Text = "00"
        Me.lblIdDocumento.Visible = False
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.btnInfoCompra)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 50)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(960, 20)
        Me.Panel7.TabIndex = 413
        '
        'btnInfoCompra
        '
        Me.btnInfoCompra.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btnInfoCompra.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.btnInfoCompra.BeforeTouchSize = New System.Drawing.Size(28, 20)
        Me.btnInfoCompra.ForeColor = System.Drawing.Color.White
        Me.btnInfoCompra.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.b_docsql
        Me.btnInfoCompra.IsBackStageButton = False
        Me.btnInfoCompra.Location = New System.Drawing.Point(1, -1)
        Me.btnInfoCompra.Name = "btnInfoCompra"
        Me.btnInfoCompra.Size = New System.Drawing.Size(28, 20)
        Me.btnInfoCompra.TabIndex = 212
        Me.btnInfoCompra.TabStop = False
        Me.btnInfoCompra.UseVisualStyle = True
        '
        'dockingClientPanel1
        '
        Me.dockingClientPanel1.BackColor = System.Drawing.Color.Transparent
        Me.dockingClientPanel1.Controls.Add(Me.GradientPanel2)
        Me.dockingClientPanel1.Controls.Add(Me.Panel4)
        Me.dockingClientPanel1.Location = New System.Drawing.Point(0, 70)
        Me.dockingClientPanel1.Name = "dockingClientPanel1"
        Me.dockingClientPanel1.Size = New System.Drawing.Size(960, 470)
        Me.dockingClientPanel1.TabIndex = 414
        '
        'GradientPanel2
        '
        Me.GradientPanel2.Controls.Add(Me.PanelDGV)
        Me.GradientPanel2.Controls.Add(Me.Panel5)
        Me.GradientPanel2.Controls.Add(Me.ToolStrip2)
        Me.GradientPanel2.Controls.Add(Me.Panel6)
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel2.Location = New System.Drawing.Point(325, 0)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(635, 470)
        Me.GradientPanel2.TabIndex = 204
        '
        'PanelDGV
        '
        Me.PanelDGV.Controls.Add(Me.PanelDetalleCompra)
        Me.PanelDGV.Controls.Add(Me.dgvNuevoDoc)
        Me.PanelDGV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelDGV.Location = New System.Drawing.Point(0, 69)
        Me.PanelDGV.Name = "PanelDGV"
        Me.PanelDGV.Size = New System.Drawing.Size(631, 318)
        Me.PanelDGV.TabIndex = 401
        '
        'PanelDetalleCompra
        '
        Me.PanelDetalleCompra.BackColor = System.Drawing.Color.Transparent
        Me.PanelDetalleCompra.Controls.Add(Me.lsvCanasta)
        Me.PanelDetalleCompra.Location = New System.Drawing.Point(4, 30)
        Me.PanelDetalleCompra.Name = "PanelDetalleCompra"
        Me.PanelDetalleCompra.Size = New System.Drawing.Size(629, 152)
        Me.PanelDetalleCompra.TabIndex = 399
        '
        'lsvCanasta
        '
        Me.lsvCanasta.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.lsvCanasta.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colSec, Me.colIdItem, Me.colItem, Me.colUM, Me.colPres, Me.colCantidad, Me.colImportemn, Me.colImporteme, Me.colIdAlmacen, Me.colIdActividad, Me.colTipoEx, Me.colNotaMn, Me.colNotaME, Me.colDebitoMN, Me.colNBMe, Me.colTotalmn, Me.colTotalME, Me.colCanCredito, Me.colCantDebito, Me.colTotalCant})
        Me.lsvCanasta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lsvCanasta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvCanasta.FullRowSelect = True
        Me.lsvCanasta.GridLines = True
        Me.lsvCanasta.Location = New System.Drawing.Point(0, 0)
        Me.lsvCanasta.Name = "lsvCanasta"
        Me.lsvCanasta.Size = New System.Drawing.Size(629, 152)
        Me.lsvCanasta.TabIndex = 7
        Me.lsvCanasta.UseCompatibleStateImageBehavior = False
        Me.lsvCanasta.View = System.Windows.Forms.View.Details
        '
        'colSec
        '
        Me.colSec.Text = "Sec"
        Me.colSec.Width = 0
        '
        'colIdItem
        '
        Me.colIdItem.Text = "IDItem"
        Me.colIdItem.Width = 0
        '
        'colItem
        '
        Me.colItem.Text = "Descripción"
        Me.colItem.Width = 219
        '
        'colUM
        '
        Me.colUM.Text = "U.M."
        Me.colUM.Width = 47
        '
        'colPres
        '
        Me.colPres.Text = "Presentación"
        Me.colPres.Width = 70
        '
        'colCantidad
        '
        Me.colCantidad.Text = "Can"
        Me.colCantidad.Width = 54
        '
        'colImportemn
        '
        Me.colImportemn.Text = "Importe"
        Me.colImportemn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colImportemn.Width = 0
        '
        'colImporteme
        '
        Me.colImporteme.Text = "Importe me."
        Me.colImporteme.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colImporteme.Width = 0
        '
        'colIdAlmacen
        '
        Me.colIdAlmacen.Text = "Almacen"
        Me.colIdAlmacen.Width = 0
        '
        'colIdActividad
        '
        Me.colIdActividad.Text = "Actividad"
        Me.colIdActividad.Width = 0
        '
        'colTipoEx
        '
        Me.colTipoEx.Text = "Tipo Ex"
        Me.colTipoEx.Width = 0
        '
        'colNotaMn
        '
        Me.colNotaMn.Text = "NC. mn."
        Me.colNotaMn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colNotaMn.Width = 0
        '
        'colNotaME
        '
        Me.colNotaME.Text = "NC me."
        Me.colNotaME.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colNotaME.Width = 0
        '
        'colDebitoMN
        '
        Me.colDebitoMN.Text = "ND mn."
        Me.colDebitoMN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colDebitoMN.Width = 0
        '
        'colNBMe
        '
        Me.colNBMe.Text = "ND me."
        Me.colNBMe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colNBMe.Width = 0
        '
        'colTotalmn
        '
        Me.colTotalmn.Text = "Total mn."
        Me.colTotalmn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colTotalmn.Width = 80
        '
        'colTotalME
        '
        Me.colTotalME.Text = "Total me."
        Me.colTotalME.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colTotalME.Width = 78
        '
        'colCanCredito
        '
        Me.colCanCredito.Text = "NC cant."
        '
        'colCantDebito
        '
        Me.colCantDebito.Text = "ND cant."
        '
        'colTotalCant
        '
        Me.colTotalCant.Text = "Saldo cant."
        Me.colTotalCant.Width = 76
        '
        'dgvNuevoDoc
        '
        Me.dgvNuevoDoc.AllowUserToAddRows = False
        Me.dgvNuevoDoc.AllowUserToResizeColumns = False
        Me.dgvNuevoDoc.AllowUserToResizeRows = False
        Me.dgvNuevoDoc.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Secue, Me.Gravado, Me.IDArticulo, Me.Art, Me.uni2, Me.Cant2, Me.Uni1, Me.Can1, Me.Prec, Me.PrecUnitUS, Me.ImporteNeto, Me.ImporteUS, Me.kardex, Me.ISC, Me.igv, Me.otrostributos, Me.Kardexus, Me.ISCus, Me.IGVus, Me.OTCus, Me.Estado, Me.TipoExistencia, Me.Cuenta, Me.cbopreEvento, Me.Evento, Me.IDDocref, Me.Movimiento, Me.colBonif, Me.colFecVcto, Me.colValorCheck, Me.colAlmacenRef, Me.colCantidadBack, Me.colImporteBack})
        Me.dgvNuevoDoc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvNuevoDoc.Location = New System.Drawing.Point(0, 0)
        Me.dgvNuevoDoc.MultiSelect = False
        Me.dgvNuevoDoc.Name = "dgvNuevoDoc"
        Me.dgvNuevoDoc.RowHeadersVisible = False
        Me.dgvNuevoDoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvNuevoDoc.Size = New System.Drawing.Size(631, 318)
        Me.dgvNuevoDoc.TabIndex = 400
        '
        'Secue
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.InactiveBorder
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.DimGray
        Me.Secue.DefaultCellStyle = DataGridViewCellStyle1
        Me.Secue.Frozen = True
        Me.Secue.HeaderText = "Secuencia"
        Me.Secue.Name = "Secue"
        Me.Secue.Visible = False
        Me.Secue.Width = 30
        '
        'Gravado
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.InactiveBorder
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkRed
        Me.Gravado.DefaultCellStyle = DataGridViewCellStyle2
        Me.Gravado.Frozen = True
        Me.Gravado.HeaderText = "P.Grav"
        Me.Gravado.Name = "Gravado"
        Me.Gravado.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Gravado.Width = 25
        '
        'IDArticulo
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.InactiveBorder
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.DimGray
        Me.IDArticulo.DefaultCellStyle = DataGridViewCellStyle3
        Me.IDArticulo.Frozen = True
        Me.IDArticulo.HeaderText = "IDArticulo"
        Me.IDArticulo.Name = "IDArticulo"
        Me.IDArticulo.ReadOnly = True
        Me.IDArticulo.Visible = False
        Me.IDArticulo.Width = 50
        '
        'Art
        '
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.InactiveBorder
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Art.DefaultCellStyle = DataGridViewCellStyle4
        Me.Art.Frozen = True
        Me.Art.HeaderText = "Articulo"
        Me.Art.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.Art.Name = "Art"
        Me.Art.ReadOnly = True
        Me.Art.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Art.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Art.Width = 220
        '
        'uni2
        '
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.InactiveBorder
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.DimGray
        Me.uni2.DefaultCellStyle = DataGridViewCellStyle5
        Me.uni2.HeaderText = "IDPres"
        Me.uni2.Name = "uni2"
        Me.uni2.ReadOnly = True
        Me.uni2.Visible = False
        Me.uni2.Width = 40
        '
        'Cant2
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Cant2.DefaultCellStyle = DataGridViewCellStyle6
        Me.Cant2.HeaderText = "Presentación"
        Me.Cant2.Name = "Cant2"
        Me.Cant2.ReadOnly = True
        Me.Cant2.Width = 65
        '
        'Uni1
        '
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.InactiveBorder
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Uni1.DefaultCellStyle = DataGridViewCellStyle7
        Me.Uni1.HeaderText = "U.M."
        Me.Uni1.Name = "Uni1"
        Me.Uni1.ReadOnly = True
        Me.Uni1.Width = 50
        '
        'Can1
        '
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = Nothing
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        Me.Can1.DefaultCellStyle = DataGridViewCellStyle8
        Me.Can1.HeaderText = "Cant"
        Me.Can1.Name = "Can1"
        Me.Can1.Width = 50
        '
        'Prec
        '
        DataGridViewCellStyle9.Format = "N2"
        Me.Prec.DefaultCellStyle = DataGridViewCellStyle9
        Me.Prec.HeaderText = "Pr Unit (MN)"
        Me.Prec.Name = "Prec"
        Me.Prec.ReadOnly = True
        Me.Prec.Width = 50
        '
        'PrecUnitUS
        '
        DataGridViewCellStyle10.Format = "N2"
        Me.PrecUnitUS.DefaultCellStyle = DataGridViewCellStyle10
        Me.PrecUnitUS.HeaderText = "PrUnit (ME)"
        Me.PrecUnitUS.Name = "PrecUnitUS"
        Me.PrecUnitUS.ReadOnly = True
        Me.PrecUnitUS.Width = 45
        '
        'ImporteNeto
        '
        DataGridViewCellStyle11.Format = "N2"
        DataGridViewCellStyle11.NullValue = "0.00"
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black
        Me.ImporteNeto.DefaultCellStyle = DataGridViewCellStyle11
        Me.ImporteNeto.HeaderText = "Monto mn."
        Me.ImporteNeto.Name = "ImporteNeto"
        Me.ImporteNeto.Width = 60
        '
        'ImporteUS
        '
        DataGridViewCellStyle12.Format = "N2"
        DataGridViewCellStyle12.NullValue = "0.00"
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.Yellow
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black
        Me.ImporteUS.DefaultCellStyle = DataGridViewCellStyle12
        Me.ImporteUS.HeaderText = "Monto me."
        Me.ImporteUS.Name = "ImporteUS"
        Me.ImporteUS.Width = 65
        '
        'kardex
        '
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.LavenderBlush
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle13.Format = "N2"
        DataGridViewCellStyle13.NullValue = "0.00"
        Me.kardex.DefaultCellStyle = DataGridViewCellStyle13
        Me.kardex.HeaderText = "Valor Compra MN."
        Me.kardex.Name = "kardex"
        Me.kardex.ReadOnly = True
        Me.kardex.Visible = False
        Me.kardex.Width = 50
        '
        'ISC
        '
        DataGridViewCellStyle14.Format = "N2"
        DataGridViewCellStyle14.NullValue = "0.00"
        Me.ISC.DefaultCellStyle = DataGridViewCellStyle14
        Me.ISC.HeaderText = "ISC"
        Me.ISC.Name = "ISC"
        Me.ISC.Visible = False
        Me.ISC.Width = 50
        '
        'igv
        '
        DataGridViewCellStyle15.Format = "N2"
        DataGridViewCellStyle15.NullValue = "0.00"
        Me.igv.DefaultCellStyle = DataGridViewCellStyle15
        Me.igv.HeaderText = "IGV"
        Me.igv.Name = "igv"
        Me.igv.Visible = False
        Me.igv.Width = 50
        '
        'otrostributos
        '
        DataGridViewCellStyle16.Format = "N2"
        DataGridViewCellStyle16.NullValue = "0.00"
        Me.otrostributos.DefaultCellStyle = DataGridViewCellStyle16
        Me.otrostributos.HeaderText = "OTC"
        Me.otrostributos.Name = "otrostributos"
        Me.otrostributos.Visible = False
        Me.otrostributos.Width = 50
        '
        'Kardexus
        '
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        DataGridViewCellStyle17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle17.Format = "N2"
        Me.Kardexus.DefaultCellStyle = DataGridViewCellStyle17
        Me.Kardexus.HeaderText = "Valor Compra ME"
        Me.Kardexus.Name = "Kardexus"
        Me.Kardexus.ReadOnly = True
        Me.Kardexus.Visible = False
        Me.Kardexus.Width = 50
        '
        'ISCus
        '
        DataGridViewCellStyle18.Format = "N2"
        Me.ISCus.DefaultCellStyle = DataGridViewCellStyle18
        Me.ISCus.HeaderText = "ISC ME"
        Me.ISCus.Name = "ISCus"
        Me.ISCus.Visible = False
        Me.ISCus.Width = 50
        '
        'IGVus
        '
        DataGridViewCellStyle19.Format = "N2"
        Me.IGVus.DefaultCellStyle = DataGridViewCellStyle19
        Me.IGVus.HeaderText = "IGV ME"
        Me.IGVus.Name = "IGVus"
        Me.IGVus.Visible = False
        Me.IGVus.Width = 50
        '
        'OTCus
        '
        DataGridViewCellStyle20.Format = "N2"
        Me.OTCus.DefaultCellStyle = DataGridViewCellStyle20
        Me.OTCus.HeaderText = "OTC ME"
        Me.OTCus.Name = "OTCus"
        Me.OTCus.Visible = False
        Me.OTCus.Width = 50
        '
        'Estado
        '
        Me.Estado.HeaderText = "Estado"
        Me.Estado.Name = "Estado"
        Me.Estado.Visible = False
        Me.Estado.Width = 40
        '
        'TipoExistencia
        '
        Me.TipoExistencia.HeaderText = "Tipo Existencia"
        Me.TipoExistencia.Name = "TipoExistencia"
        Me.TipoExistencia.ReadOnly = True
        Me.TipoExistencia.Visible = False
        Me.TipoExistencia.Width = 50
        '
        'Cuenta
        '
        Me.Cuenta.HeaderText = "Cuenta"
        Me.Cuenta.Name = "Cuenta"
        Me.Cuenta.ReadOnly = True
        Me.Cuenta.Visible = False
        Me.Cuenta.Width = 80
        '
        'cbopreEvento
        '
        Me.cbopreEvento.HeaderText = "Pre Evento"
        Me.cbopreEvento.Name = "cbopreEvento"
        Me.cbopreEvento.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.cbopreEvento.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.cbopreEvento.Visible = False
        Me.cbopreEvento.Width = 50
        '
        'Evento
        '
        Me.Evento.HeaderText = "Evento"
        Me.Evento.Name = "Evento"
        Me.Evento.ReadOnly = True
        Me.Evento.Visible = False
        '
        'IDDocref
        '
        Me.IDDocref.HeaderText = "Documento referencia"
        Me.IDDocref.Name = "IDDocref"
        Me.IDDocref.ReadOnly = True
        Me.IDDocref.Visible = False
        '
        'Movimiento
        '
        Me.Movimiento.HeaderText = "Movimiento"
        Me.Movimiento.Name = "Movimiento"
        Me.Movimiento.ReadOnly = True
        Me.Movimiento.Visible = False
        '
        'colBonif
        '
        Me.colBonif.FalseValue = "N"
        Me.colBonif.HeaderText = "Bonificación"
        Me.colBonif.IndeterminateValue = "N"
        Me.colBonif.Name = "colBonif"
        Me.colBonif.TrueValue = "S"
        Me.colBonif.Visible = False
        Me.colBonif.Width = 80
        '
        'colFecVcto
        '
        Me.colFecVcto.HeaderText = "FecVcto"
        Me.colFecVcto.Name = "colFecVcto"
        Me.colFecVcto.ReadOnly = True
        Me.colFecVcto.Visible = False
        Me.colFecVcto.Width = 70
        '
        'colValorCheck
        '
        Me.colValorCheck.HeaderText = "ValorCk"
        Me.colValorCheck.Name = "colValorCheck"
        Me.colValorCheck.ReadOnly = True
        Me.colValorCheck.Visible = False
        Me.colValorCheck.Width = 50
        '
        'colAlmacenRef
        '
        Me.colAlmacenRef.HeaderText = "colAlmacen"
        Me.colAlmacenRef.Name = "colAlmacenRef"
        Me.colAlmacenRef.ReadOnly = True
        Me.colAlmacenRef.Width = 50
        '
        'colCantidadBack
        '
        Me.colCantidadBack.HeaderText = "Cantidad"
        Me.colCantidadBack.Name = "colCantidadBack"
        Me.colCantidadBack.ReadOnly = True
        Me.colCantidadBack.Visible = False
        '
        'colImporteBack
        '
        Me.colImporteBack.HeaderText = "ImporteBack"
        Me.colImporteBack.Name = "colImporteBack"
        Me.colImporteBack.ReadOnly = True
        Me.colImporteBack.Visible = False
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Label6)
        Me.Panel5.Controls.Add(Me.Label8)
        Me.Panel5.Controls.Add(Me.txtTipoCambio)
        Me.Panel5.Controls.Add(Me.txtIgv)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 25)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(631, 44)
        Me.Panel5.TabIndex = 402
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(3, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 13)
        Me.Label6.TabIndex = 393
        Me.Label6.Text = "Tipo Cambio:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(138, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 13)
        Me.Label8.TabIndex = 394
        Me.Label8.Text = "I.G.V.:"
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.txtTipoCambio.BeforeTouchSize = New System.Drawing.Size(51, 20)
        Me.txtTipoCambio.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTipoCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTipoCambio.DecimalPlaces = 2
        Me.txtTipoCambio.Location = New System.Drawing.Point(78, 13)
        Me.txtTipoCambio.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.Size = New System.Drawing.Size(51, 20)
        Me.txtTipoCambio.TabIndex = 395
        Me.txtTipoCambio.TabStop = False
        Me.txtTipoCambio.ThousandsSeparator = True
        Me.txtTipoCambio.Value = New Decimal(New Integer() {3, 0, 0, 0})
        Me.txtTipoCambio.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'txtIgv
        '
        Me.txtIgv.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.txtIgv.BeforeTouchSize = New System.Drawing.Size(61, 20)
        Me.txtIgv.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtIgv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIgv.DecimalPlaces = 2
        Me.txtIgv.InterceptArrowKeys = False
        Me.txtIgv.Location = New System.Drawing.Point(181, 13)
        Me.txtIgv.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtIgv.Name = "txtIgv"
        Me.txtIgv.ReadOnly = True
        Me.txtIgv.Size = New System.Drawing.Size(61, 20)
        Me.txtIgv.TabIndex = 396
        Me.txtIgv.TabStop = False
        Me.txtIgv.ThousandsSeparator = True
        Me.txtIgv.Value = New Decimal(New Integer() {18, 0, 0, 0})
        Me.txtIgv.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'ToolStrip2
        '
        Me.ToolStrip2.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ToolStrip2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnVer, Me.ToolStripButton1, Me.ToolStripSeparator2})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip2.Size = New System.Drawing.Size(631, 25)
        Me.ToolStrip2.TabIndex = 400
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'btnVer
        '
        Me.btnVer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnVer.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnVer.Image = CType(resources.GetObject("btnVer.Image"), System.Drawing.Image)
        Me.btnVer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnVer.Name = "btnVer"
        Me.btnVer.Size = New System.Drawing.Size(23, 22)
        Me.btnVer.Text = "Cesto de existencias"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.ToolStripButton1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.ToolStripButton1.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.images
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "Eliminar fila"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.Panel10)
        Me.Panel6.Controls.Add(Me.Panel13)
        Me.Panel6.Controls.Add(Me.Panel12)
        Me.Panel6.Controls.Add(Me.Label20)
        Me.Panel6.Controls.Add(Me.Label19)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel6.Location = New System.Drawing.Point(0, 387)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(631, 79)
        Me.Panel6.TabIndex = 4
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.Transparent
        Me.Panel10.Controls.Add(Me.Label15)
        Me.Panel10.Controls.Add(Me.Label13)
        Me.Panel10.Controls.Add(Me.Label14)
        Me.Panel10.Controls.Add(Me.lblBonificaME)
        Me.Panel10.Controls.Add(Me.lblBonificaMN)
        Me.Panel10.Controls.Add(Me.lblTotalUS)
        Me.Panel10.Controls.Add(Me.Label79)
        Me.Panel10.Controls.Add(Me.lblTotalAdquisiones)
        Me.Panel10.Controls.Add(Me.lblTotales)
        Me.Panel10.Controls.Add(Me.lblTotalMontoIgvUS)
        Me.Panel10.Controls.Add(Me.lblTotalBaseUS)
        Me.Panel10.Controls.Add(Me.lblTotalIScUS)
        Me.Panel10.Controls.Add(Me.lblOtrostribTotalUS)
        Me.Panel10.Controls.Add(Me.lblOtrostribTotal)
        Me.Panel10.Controls.Add(Me.lblTotalMontoIgv)
        Me.Panel10.Controls.Add(Me.lblTotalISc)
        Me.Panel10.Controls.Add(Me.lblTotalBase)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel10.Location = New System.Drawing.Point(144, 0)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(487, 79)
        Me.Panel10.TabIndex = 9
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label15.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label15.Location = New System.Drawing.Point(4, 23)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(36, 13)
        Me.Label15.TabIndex = 328
        Me.Label15.Text = "(SLS):"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(4, 6)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(31, 13)
        Me.Label13.TabIndex = 327
        Me.Label13.Text = "USD:"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label14.Location = New System.Drawing.Point(46, 39)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(74, 37)
        Me.Label14.TabIndex = 326
        Me.Label14.Text = "BONIF."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label14.Visible = False
        '
        'lblBonificaME
        '
        Me.lblBonificaME.AutoSize = True
        Me.lblBonificaME.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.lblBonificaME.Location = New System.Drawing.Point(127, 43)
        Me.lblBonificaME.Name = "lblBonificaME"
        Me.lblBonificaME.Size = New System.Drawing.Size(29, 13)
        Me.lblBonificaME.TabIndex = 325
        Me.lblBonificaME.Text = "0.00"
        Me.lblBonificaME.Visible = False
        '
        'lblBonificaMN
        '
        Me.lblBonificaMN.AutoSize = True
        Me.lblBonificaMN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.lblBonificaMN.Location = New System.Drawing.Point(127, 62)
        Me.lblBonificaMN.Name = "lblBonificaMN"
        Me.lblBonificaMN.Size = New System.Drawing.Size(29, 13)
        Me.lblBonificaMN.TabIndex = 324
        Me.lblBonificaMN.Text = "0.00"
        Me.lblBonificaMN.Visible = False
        '
        'lblTotalUS
        '
        Me.lblTotalUS.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.lblTotalUS.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalUS.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTotalUS.Location = New System.Drawing.Point(354, 57)
        Me.lblTotalUS.Name = "lblTotalUS"
        Me.lblTotalUS.Size = New System.Drawing.Size(130, 18)
        Me.lblTotalUS.TabIndex = 323
        Me.lblTotalUS.Text = "0.00"
        Me.lblTotalUS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label79
        '
        Me.Label79.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label79.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label79.ForeColor = System.Drawing.Color.White
        Me.Label79.Location = New System.Drawing.Point(211, 57)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(144, 18)
        Me.Label79.TabIndex = 322
        Me.Label79.Text = "Total M.E.:"
        Me.Label79.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalAdquisiones
        '
        Me.lblTotalAdquisiones.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.lblTotalAdquisiones.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalAdquisiones.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTotalAdquisiones.Location = New System.Drawing.Point(354, 39)
        Me.lblTotalAdquisiones.Name = "lblTotalAdquisiones"
        Me.lblTotalAdquisiones.Size = New System.Drawing.Size(130, 17)
        Me.lblTotalAdquisiones.TabIndex = 321
        Me.lblTotalAdquisiones.Text = "0.00"
        Me.lblTotalAdquisiones.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotales
        '
        Me.lblTotales.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.lblTotales.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotales.ForeColor = System.Drawing.Color.White
        Me.lblTotales.Location = New System.Drawing.Point(211, 39)
        Me.lblTotales.Name = "lblTotales"
        Me.lblTotales.Size = New System.Drawing.Size(144, 17)
        Me.lblTotales.TabIndex = 320
        Me.lblTotales.Text = "Total M.N.:"
        Me.lblTotales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalMontoIgvUS
        '
        Me.lblTotalMontoIgvUS.AutoSize = True
        Me.lblTotalMontoIgvUS.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalMontoIgvUS.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalMontoIgvUS.ForeColor = System.Drawing.Color.Crimson
        Me.lblTotalMontoIgvUS.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTotalMontoIgvUS.Location = New System.Drawing.Point(281, 5)
        Me.lblTotalMontoIgvUS.Name = "lblTotalMontoIgvUS"
        Me.lblTotalMontoIgvUS.Size = New System.Drawing.Size(29, 13)
        Me.lblTotalMontoIgvUS.TabIndex = 316
        Me.lblTotalMontoIgvUS.Text = "0.00"
        '
        'lblTotalBaseUS
        '
        Me.lblTotalBaseUS.AutoSize = True
        Me.lblTotalBaseUS.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalBaseUS.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalBaseUS.ForeColor = System.Drawing.Color.Purple
        Me.lblTotalBaseUS.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTotalBaseUS.Location = New System.Drawing.Point(92, 5)
        Me.lblTotalBaseUS.Name = "lblTotalBaseUS"
        Me.lblTotalBaseUS.Size = New System.Drawing.Size(29, 13)
        Me.lblTotalBaseUS.TabIndex = 315
        Me.lblTotalBaseUS.Text = "0.00"
        '
        'lblTotalIScUS
        '
        Me.lblTotalIScUS.AutoSize = True
        Me.lblTotalIScUS.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalIScUS.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalIScUS.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblTotalIScUS.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTotalIScUS.Location = New System.Drawing.Point(179, 5)
        Me.lblTotalIScUS.Name = "lblTotalIScUS"
        Me.lblTotalIScUS.Size = New System.Drawing.Size(29, 13)
        Me.lblTotalIScUS.TabIndex = 318
        Me.lblTotalIScUS.Text = "0.00"
        '
        'lblOtrostribTotalUS
        '
        Me.lblOtrostribTotalUS.AutoSize = True
        Me.lblOtrostribTotalUS.BackColor = System.Drawing.Color.Transparent
        Me.lblOtrostribTotalUS.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOtrostribTotalUS.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblOtrostribTotalUS.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblOtrostribTotalUS.Location = New System.Drawing.Point(388, 5)
        Me.lblOtrostribTotalUS.Name = "lblOtrostribTotalUS"
        Me.lblOtrostribTotalUS.Size = New System.Drawing.Size(29, 13)
        Me.lblOtrostribTotalUS.TabIndex = 319
        Me.lblOtrostribTotalUS.Text = "0.00"
        '
        'lblOtrostribTotal
        '
        Me.lblOtrostribTotal.AutoSize = True
        Me.lblOtrostribTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblOtrostribTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOtrostribTotal.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblOtrostribTotal.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblOtrostribTotal.Location = New System.Drawing.Point(388, 23)
        Me.lblOtrostribTotal.Name = "lblOtrostribTotal"
        Me.lblOtrostribTotal.Size = New System.Drawing.Size(29, 13)
        Me.lblOtrostribTotal.TabIndex = 314
        Me.lblOtrostribTotal.Text = "0.00"
        '
        'lblTotalMontoIgv
        '
        Me.lblTotalMontoIgv.AutoSize = True
        Me.lblTotalMontoIgv.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalMontoIgv.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalMontoIgv.ForeColor = System.Drawing.Color.Crimson
        Me.lblTotalMontoIgv.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTotalMontoIgv.Location = New System.Drawing.Point(281, 23)
        Me.lblTotalMontoIgv.Name = "lblTotalMontoIgv"
        Me.lblTotalMontoIgv.Size = New System.Drawing.Size(29, 13)
        Me.lblTotalMontoIgv.TabIndex = 311
        Me.lblTotalMontoIgv.Text = "0.00"
        '
        'lblTotalISc
        '
        Me.lblTotalISc.AutoSize = True
        Me.lblTotalISc.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalISc.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalISc.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTotalISc.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTotalISc.Location = New System.Drawing.Point(179, 23)
        Me.lblTotalISc.Name = "lblTotalISc"
        Me.lblTotalISc.Size = New System.Drawing.Size(29, 13)
        Me.lblTotalISc.TabIndex = 313
        Me.lblTotalISc.Text = "0.00"
        '
        'lblTotalBase
        '
        Me.lblTotalBase.AutoSize = True
        Me.lblTotalBase.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalBase.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalBase.ForeColor = System.Drawing.Color.Purple
        Me.lblTotalBase.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTotalBase.Location = New System.Drawing.Point(92, 23)
        Me.lblTotalBase.Name = "lblTotalBase"
        Me.lblTotalBase.Size = New System.Drawing.Size(29, 13)
        Me.lblTotalBase.TabIndex = 310
        Me.lblTotalBase.Text = "0.00"
        '
        'Panel13
        '
        Me.Panel13.BackColor = System.Drawing.Color.Crimson
        Me.Panel13.Location = New System.Drawing.Point(33, 23)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(10, 10)
        Me.Panel13.TabIndex = 8
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.Purple
        Me.Panel12.Location = New System.Drawing.Point(33, 6)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(10, 10)
        Me.Panel12.TabIndex = 7
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Location = New System.Drawing.Point(8, 22)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(28, 13)
        Me.Label20.TabIndex = 6
        Me.Label20.Text = "IGV."
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Location = New System.Drawing.Point(10, 4)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(25, 13)
        Me.Label19.TabIndex = 5
        Me.Label19.Text = "B.I."
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.txtConf)
        Me.Panel4.Controls.Add(Me.Panel1)
        Me.Panel4.Controls.Add(Me.GradientPanel3)
        Me.Panel4.Controls.Add(Me.Panel8)
        Me.Panel4.Controls.Add(Me.panel15)
        Me.Panel4.Controls.Add(Me.gpVSBehavior)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(325, 470)
        Me.Panel4.TabIndex = 205
        '
        'txtConf
        '
        Me.txtConf.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtConf.DisplayMember = "01"
        Me.txtConf.Location = New System.Drawing.Point(3, 33)
        Me.txtConf.Name = "txtConf"
        Me.txtConf.ReadOnly = True
        Me.txtConf.Size = New System.Drawing.Size(290, 19)
        Me.txtConf.TabIndex = 171
        Me.txtConf.Text = "DEVOLUCION DE EXISTENCIAS"
        Me.txtConf.ValueMember = "01"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Location = New System.Drawing.Point(3, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(314, 24)
        Me.Panel1.TabIndex = 205
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label5.Location = New System.Drawing.Point(10, 3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(194, 19)
        Me.Label5.TabIndex = 170
        Me.Label5.Text = "Tipo nota credito:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GradientPanel3
        '
        Me.GradientPanel3.BackColor = System.Drawing.Color.White
        Me.GradientPanel3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.GradientPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel3.Controls.Add(Me.QRibbonInputBox2)
        Me.GradientPanel3.Controls.Add(Me.QRibbonInputBox1)
        Me.GradientPanel3.Controls.Add(Me.Label17)
        Me.GradientPanel3.Controls.Add(Me.txtNumeroGuia)
        Me.GradientPanel3.Controls.Add(Me.txtSerieGuia)
        Me.GradientPanel3.Controls.Add(Me.Label16)
        Me.GradientPanel3.Location = New System.Drawing.Point(3, 228)
        Me.GradientPanel3.Name = "GradientPanel3"
        Me.GradientPanel3.Size = New System.Drawing.Size(314, 77)
        Me.GradientPanel3.TabIndex = 204
        '
        'QRibbonInputBox2
        '
        Me.QRibbonInputBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.QRibbonInputBox2.Location = New System.Drawing.Point(54, 5)
        Me.QRibbonInputBox2.Name = "QRibbonInputBox2"
        Me.QRibbonInputBox2.ReadOnly = True
        Me.QRibbonInputBox2.Size = New System.Drawing.Size(218, 19)
        Me.QRibbonInputBox2.TabIndex = 218
        Me.QRibbonInputBox2.TabStop = False
        Me.QRibbonInputBox2.Text = "GUIA DE REMISION"
        '
        'QRibbonInputBox1
        '
        Me.QRibbonInputBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.QRibbonInputBox1.Location = New System.Drawing.Point(9, 5)
        Me.QRibbonInputBox1.Name = "QRibbonInputBox1"
        Me.QRibbonInputBox1.ReadOnly = True
        Me.QRibbonInputBox1.Size = New System.Drawing.Size(43, 19)
        Me.QRibbonInputBox1.TabIndex = 217
        Me.QRibbonInputBox1.TabStop = False
        Me.QRibbonInputBox1.Text = "99"
        Me.QRibbonInputBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(42, 56)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(48, 13)
        Me.Label17.TabIndex = 216
        Me.Label17.Text = "Número:"
        '
        'txtNumeroGuia
        '
        Me.txtNumeroGuia.Location = New System.Drawing.Point(96, 53)
        Me.txtNumeroGuia.MaxLength = 20
        Me.txtNumeroGuia.Name = "txtNumeroGuia"
        Me.txtNumeroGuia.Size = New System.Drawing.Size(175, 19)
        Me.txtNumeroGuia.TabIndex = 215
        Me.txtNumeroGuia.TabStop = False
        '
        'txtSerieGuia
        '
        Me.txtSerieGuia.Location = New System.Drawing.Point(96, 30)
        Me.txtSerieGuia.MaxLength = 5
        Me.txtSerieGuia.Name = "txtSerieGuia"
        Me.txtSerieGuia.Size = New System.Drawing.Size(175, 19)
        Me.txtSerieGuia.TabIndex = 214
        Me.txtSerieGuia.TabStop = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(55, 33)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(35, 13)
        Me.Label16.TabIndex = 213
        Me.Label16.Text = "Serie:"
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Panel8.BackgroundImage = CType(resources.GetObject("Panel8.BackgroundImage"), System.Drawing.Image)
        Me.Panel8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel8.Controls.Add(Me.Label18)
        Me.Panel8.Location = New System.Drawing.Point(3, 203)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(314, 24)
        Me.Panel8.TabIndex = 203
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label18.Location = New System.Drawing.Point(10, 3)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(194, 19)
        Me.Label18.TabIndex = 170
        Me.Label18.Text = "Guía de remisión"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'panel15
        '
        Me.panel15.BackColor = System.Drawing.Color.Transparent
        Me.panel15.BackgroundImage = CType(resources.GetObject("panel15.BackgroundImage"), System.Drawing.Image)
        Me.panel15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.panel15.Controls.Add(Me.label35)
        Me.panel15.Location = New System.Drawing.Point(3, 62)
        Me.panel15.Name = "panel15"
        Me.panel15.Size = New System.Drawing.Size(314, 24)
        Me.panel15.TabIndex = 197
        '
        'label35
        '
        Me.label35.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label35.ForeColor = System.Drawing.Color.Black
        Me.label35.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.label35.Location = New System.Drawing.Point(10, 3)
        Me.label35.Name = "label35"
        Me.label35.Size = New System.Drawing.Size(194, 19)
        Me.label35.TabIndex = 170
        Me.label35.Text = "Datos del comprobante"
        Me.label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpVSBehavior
        '
        Me.gpVSBehavior.BackColor = System.Drawing.Color.White
        Me.gpVSBehavior.BorderColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpVSBehavior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.gpVSBehavior.Controls.Add(Me.txtIdComprobanteNota)
        Me.gpVSBehavior.Controls.Add(Me.txtNota)
        Me.gpVSBehavior.Controls.Add(Me.txtFechaComprobante)
        Me.gpVSBehavior.Controls.Add(Me.txtNumero)
        Me.gpVSBehavior.Controls.Add(Me.txtSerie)
        Me.gpVSBehavior.Controls.Add(Me.Label4)
        Me.gpVSBehavior.Controls.Add(Me.Label3)
        Me.gpVSBehavior.Controls.Add(Me.Label2)
        Me.gpVSBehavior.Controls.Add(Me.Label1)
        Me.gpVSBehavior.Location = New System.Drawing.Point(3, 87)
        Me.gpVSBehavior.Name = "gpVSBehavior"
        Me.gpVSBehavior.Size = New System.Drawing.Size(314, 112)
        Me.gpVSBehavior.TabIndex = 198
        '
        'txtIdComprobanteNota
        '
        Me.txtIdComprobanteNota.Location = New System.Drawing.Point(91, 39)
        Me.txtIdComprobanteNota.Name = "txtIdComprobanteNota"
        Me.txtIdComprobanteNota.ReadOnly = True
        Me.txtIdComprobanteNota.Size = New System.Drawing.Size(29, 19)
        Me.txtIdComprobanteNota.TabIndex = 401
        Me.txtIdComprobanteNota.Text = "07"
        '
        'txtNota
        '
        Me.txtNota.Location = New System.Drawing.Point(122, 39)
        Me.txtNota.Name = "txtNota"
        Me.txtNota.ReadOnly = True
        Me.txtNota.Size = New System.Drawing.Size(150, 19)
        Me.txtNota.TabIndex = 400
        Me.txtNota.Text = "NOTA DE CREDITO"
        '
        'txtFechaComprobante
        '
        Me.txtFechaComprobante.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtFechaComprobante.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaComprobante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtFechaComprobante.Calendar.AllowMultipleSelection = False
        Me.txtFechaComprobante.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaComprobante.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaComprobante.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechaComprobante.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaComprobante.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFechaComprobante.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtFechaComprobante.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFechaComprobante.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaComprobante.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaComprobante.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtFechaComprobante.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtFechaComprobante.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtFechaComprobante.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtFechaComprobante.Calendar.Iso8601CalenderFormat = False
        Me.txtFechaComprobante.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaComprobante.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaComprobante.Calendar.Name = "monthCalendar"
        Me.txtFechaComprobante.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtFechaComprobante.Calendar.SelectedDates = New Date(-1) {}
        Me.txtFechaComprobante.Calendar.Size = New System.Drawing.Size(177, 174)
        Me.txtFechaComprobante.Calendar.SizeToFit = True
        Me.txtFechaComprobante.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaComprobante.Calendar.TabIndex = 0
        Me.txtFechaComprobante.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtFechaComprobante.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaComprobante.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaComprobante.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaComprobante.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaComprobante.Calendar.NoneButton.IsBackStageButton = False
        Me.txtFechaComprobante.Calendar.NoneButton.Location = New System.Drawing.Point(105, 0)
        Me.txtFechaComprobante.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtFechaComprobante.Calendar.NoneButton.Text = "None"
        Me.txtFechaComprobante.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtFechaComprobante.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaComprobante.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaComprobante.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaComprobante.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaComprobante.Calendar.TodayButton.IsBackStageButton = False
        Me.txtFechaComprobante.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaComprobante.Calendar.TodayButton.Size = New System.Drawing.Size(105, 20)
        Me.txtFechaComprobante.Calendar.TodayButton.Text = "Today"
        Me.txtFechaComprobante.Calendar.TodayButton.UseVisualStyle = True
        Me.txtFechaComprobante.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaComprobante.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtFechaComprobante.CustomFormat = "dd/MM/yyyy hh:mm:ss tt"
        Me.txtFechaComprobante.DropDownImage = Nothing
        Me.txtFechaComprobante.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaComprobante.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaComprobante.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtFechaComprobante.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFechaComprobante.Location = New System.Drawing.Point(91, 13)
        Me.txtFechaComprobante.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaComprobante.MinValue = New Date(CType(0, Long))
        Me.txtFechaComprobante.Name = "txtFechaComprobante"
        Me.txtFechaComprobante.ShowCheckBox = False
        Me.txtFechaComprobante.Size = New System.Drawing.Size(181, 20)
        Me.txtFechaComprobante.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaComprobante.TabIndex = 208
        Me.txtFechaComprobante.TabStop = False
        Me.txtFechaComprobante.Value = New Date(2015, 4, 14, 15, 59, 3, 447)
        '
        'txtNumero
        '
        Me.txtNumero.Location = New System.Drawing.Point(91, 86)
        Me.txtNumero.MaxLength = 20
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(181, 19)
        Me.txtNumero.TabIndex = 206
        Me.txtNumero.TabStop = False
        '
        'txtSerie
        '
        Me.txtSerie.Location = New System.Drawing.Point(91, 63)
        Me.txtSerie.MaxLength = 5
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(181, 19)
        Me.txtSerie.TabIndex = 205
        Me.txtSerie.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(50, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 202
        Me.Label4.Text = "Serie:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(37, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 201
        Me.Label3.Text = "Número:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(9, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 200
        Me.Label2.Text = "Comprobante:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(45, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 199
        Me.Label1.Text = "Fecha:"
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        '
        'dockingManager1
        '
        Me.dockingManager1.ActiveCaptionFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.dockingManager1.AutoHideTabFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.dockingManager1.DockLayoutStream = CType(resources.GetObject("dockingManager1.DockLayoutStream"), System.IO.MemoryStream)
        Me.dockingManager1.DockTabFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.dockingManager1.HostControl = Me
        Me.dockingManager1.InActiveCaptionBackground = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer)))
        Me.dockingManager1.InActiveCaptionFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.dockingManager1.MetroButtonColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dockingManager1.MetroCaptionColor = System.Drawing.Color.White
        Me.dockingManager1.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.dockingManager1.MetroSplitterBackColor = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.dockingManager1.ReduceFlickeringInRtl = False
        Me.dockingManager1.SplitterWidth = 1
        Me.dockingManager1.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.dockingManager1.CaptionButtons.Add(New Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Close, "CloseButton"))
        Me.dockingManager1.CaptionButtons.Add(New Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Pin, "PinButton"))
        Me.dockingManager1.CaptionButtons.Add(New Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Maximize, "MaximizeButton"))
        Me.dockingManager1.CaptionButtons.Add(New Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Restore, "RestoreButton"))
        Me.dockingManager1.CaptionButtons.Add(New Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Menu, "MenuButton"))
        '
        'QGlobalColorSchemeManager1
        '
        Me.QGlobalColorSchemeManager1.Global.CurrentTheme = "LunaBlue"
        Me.QGlobalColorSchemeManager1.Global.InheritCurrentThemeFromWindows = False
        '
        'frmNotaCreditoVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(960, 547)
        Me.Controls.Add(Me.dockingClientPanel1)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.ToolStrip3)
        Me.Name = "frmNotaCreditoVenta"
        Me.Text = "Nota de crédito"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.dockingClientPanel1.ResumeLayout(False)
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        Me.GradientPanel2.PerformLayout()
        Me.PanelDGV.ResumeLayout(False)
        Me.PanelDetalleCompra.ResumeLayout(False)
        CType(Me.dgvNuevoDoc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.txtTipoCambio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel3.ResumeLayout(False)
        Me.GradientPanel3.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        Me.panel15.ResumeLayout(False)
        CType(Me.gpVSBehavior, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpVSBehavior.ResumeLayout(False)
        Me.gpVSBehavior.PerformLayout()
        CType(Me.txtFechaComprobante.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaComprobante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dockingManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents lblEstado As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents GuardarToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblPerido As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblTitulo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents PegarToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblIdDocumento As System.Windows.Forms.ToolStripLabel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents btnInfoCompra As Syncfusion.Windows.Forms.ButtonAdv
    Private WithEvents dockingClientPanel1 As Syncfusion.Windows.Forms.Tools.DockingClientPanel
    Friend WithEvents GradientPanel2 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents PanelDGV As System.Windows.Forms.Panel
    Private WithEvents PanelDetalleCompra As System.Windows.Forms.Panel
    Friend WithEvents lsvCanasta As System.Windows.Forms.ListView
    Friend WithEvents colSec As System.Windows.Forms.ColumnHeader
    Friend WithEvents colIdItem As System.Windows.Forms.ColumnHeader
    Friend WithEvents colItem As System.Windows.Forms.ColumnHeader
    Friend WithEvents colUM As System.Windows.Forms.ColumnHeader
    Friend WithEvents colPres As System.Windows.Forms.ColumnHeader
    Friend WithEvents colCantidad As System.Windows.Forms.ColumnHeader
    Friend WithEvents colImportemn As System.Windows.Forms.ColumnHeader
    Friend WithEvents colImporteme As System.Windows.Forms.ColumnHeader
    Friend WithEvents colIdAlmacen As System.Windows.Forms.ColumnHeader
    Friend WithEvents colIdActividad As System.Windows.Forms.ColumnHeader
    Friend WithEvents colTipoEx As System.Windows.Forms.ColumnHeader
    Friend WithEvents colNotaMn As System.Windows.Forms.ColumnHeader
    Friend WithEvents colNotaME As System.Windows.Forms.ColumnHeader
    Friend WithEvents colDebitoMN As System.Windows.Forms.ColumnHeader
    Friend WithEvents colNBMe As System.Windows.Forms.ColumnHeader
    Friend WithEvents colTotalmn As System.Windows.Forms.ColumnHeader
    Friend WithEvents colTotalME As System.Windows.Forms.ColumnHeader
    Friend WithEvents colCanCredito As System.Windows.Forms.ColumnHeader
    Friend WithEvents colCantDebito As System.Windows.Forms.ColumnHeader
    Friend WithEvents colTotalCant As System.Windows.Forms.ColumnHeader
    Friend WithEvents dgvNuevoDoc As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents Secue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Gravado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDArticulo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Art As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents uni2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cant2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Uni1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Can1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Prec As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrecUnitUS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ImporteNeto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ImporteUS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kardex As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ISC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents igv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents otrostributos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Kardexus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ISCus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IGVus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OTCus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Estado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TipoExistencia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cuenta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cbopreEvento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Evento As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents IDDocref As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Movimiento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBonif As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colFecVcto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colValorCheck As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAlmacenRef As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCantidadBack As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colImporteBack As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTipoCambio As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents txtIgv As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnVer As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblBonificaME As System.Windows.Forms.Label
    Friend WithEvents lblBonificaMN As System.Windows.Forms.Label
    Friend WithEvents lblTotalUS As System.Windows.Forms.Label
    Friend WithEvents Label79 As System.Windows.Forms.Label
    Friend WithEvents lblTotalAdquisiones As System.Windows.Forms.Label
    Friend WithEvents lblTotales As System.Windows.Forms.Label
    Friend WithEvents lblTotalMontoIgvUS As System.Windows.Forms.Label
    Friend WithEvents lblTotalBaseUS As System.Windows.Forms.Label
    Friend WithEvents lblTotalIScUS As System.Windows.Forms.Label
    Friend WithEvents lblOtrostribTotalUS As System.Windows.Forms.Label
    Friend WithEvents lblOtrostribTotal As System.Windows.Forms.Label
    Friend WithEvents lblTotalMontoIgv As System.Windows.Forms.Label
    Friend WithEvents lblTotalISc As System.Windows.Forms.Label
    Friend WithEvents lblTotalBase As System.Windows.Forms.Label
    Friend WithEvents Panel13 As System.Windows.Forms.Panel
    Friend WithEvents Panel12 As System.Windows.Forms.Panel
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents txtConf As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Private WithEvents Panel1 As System.Windows.Forms.Panel
    Private WithEvents Label5 As System.Windows.Forms.Label
    Private WithEvents GradientPanel3 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents QRibbonInputBox2 As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents QRibbonInputBox1 As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtNumeroGuia As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents txtSerieGuia As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Private WithEvents Panel8 As System.Windows.Forms.Panel
    Private WithEvents Label18 As System.Windows.Forms.Label
    Private WithEvents panel15 As System.Windows.Forms.Panel
    Private WithEvents label35 As System.Windows.Forms.Label
    Private WithEvents gpVSBehavior As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents txtIdComprobanteNota As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents txtNota As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents txtFechaComprobante As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents txtNumero As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents txtSerie As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Private WithEvents dockingManager1 As Syncfusion.Windows.Forms.Tools.DockingManager
    Friend WithEvents QGlobalColorSchemeManager1 As Qios.DevSuite.Components.QGlobalColorSchemeManager
End Class

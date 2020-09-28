<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormViewVentaGeneral
    Inherits Syncfusion.Windows.Forms.MetroForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormViewVentaGeneral))
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"1", "JIUNI PALACIOS SANTOS", "44924569"}, -1)
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor6 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor7 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor8 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor9 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor10 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor11 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor12 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextNumeroVenta = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboComprobante = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.TextComprador = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.PanelCliSel = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextCliente = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtTipoDocClie = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtruc = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.pcLikeCategoria = New Syncfusion.Windows.Forms.PopupControlContainer(Me.components)
        Me.LsvProveedor = New System.Windows.Forms.ListView()
        Me.colID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colRUC = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTipoDoc = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btGrabar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btServicio = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolImportar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.dgvCompra = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.DigitalGauge2 = New Syncfusion.Windows.Forms.Gauge.DigitalGauge()
        Me.PanelPrecios2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.TextTotal = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextIVA = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBaseImponible = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.LabelFecha = New System.Windows.Forms.Label()
        Me.Panel11.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.TextNumeroVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextComprador, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelCliSel.SuspendLayout()
        CType(Me.TextCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoDocClie, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtruc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pcLikeCategoria.SuspendLayout()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dgvCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelPrecios2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelPrecios2.SuspendLayout()
        CType(Me.TextTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextIVA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBaseImponible, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel11.Controls.Add(Me.Panel2)
        Me.Panel11.Controls.Add(Me.PanelCliSel)
        Me.Panel11.Controls.Add(Me.pcLikeCategoria)
        Me.Panel11.Controls.Add(Me.GradientPanel1)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel11.Location = New System.Drawing.Point(0, 0)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(1217, 89)
        Me.Panel11.TabIndex = 504
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.TextNumeroVenta)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.ComboComprobante)
        Me.Panel2.Controls.Add(Me.TextComprador)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(422, 33)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(485, 56)
        Me.Panel2.TabIndex = 521
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(356, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 13)
        Me.Label4.TabIndex = 524
        Me.Label4.Text = "Serie-número"
        '
        'TextNumeroVenta
        '
        Me.TextNumeroVenta.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextNumeroVenta.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TextNumeroVenta.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextNumeroVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextNumeroVenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNumeroVenta.CornerRadius = 3
        Me.TextNumeroVenta.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextNumeroVenta.Enabled = False
        Me.TextNumeroVenta.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNumeroVenta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextNumeroVenta.Location = New System.Drawing.Point(354, 26)
        Me.TextNumeroVenta.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextNumeroVenta.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextNumeroVenta.Name = "TextNumeroVenta"
        Me.TextNumeroVenta.NearImage = CType(resources.GetObject("TextNumeroVenta.NearImage"), System.Drawing.Image)
        Me.TextNumeroVenta.ReadOnly = True
        Me.TextNumeroVenta.Size = New System.Drawing.Size(111, 22)
        Me.TextNumeroVenta.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextNumeroVenta.TabIndex = 523
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(202, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 522
        Me.Label3.Text = "Comprobante"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 521
        Me.Label2.Text = "Comprador"
        '
        'ComboComprobante
        '
        Me.ComboComprobante.BackColor = System.Drawing.Color.White
        Me.ComboComprobante.BeforeTouchSize = New System.Drawing.Size(143, 21)
        Me.ComboComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboComprobante.Enabled = False
        Me.ComboComprobante.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboComprobante.Items.AddRange(New Object() {"NOTA DE VENTA", "FACTURA ELECTRONICA", "BOLETA ELECTRONICA", "PROFORMA"})
        Me.ComboComprobante.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboComprobante, "NOTA DE VENTA"))
        Me.ComboComprobante.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboComprobante, "FACTURA ELECTRONICA"))
        Me.ComboComprobante.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboComprobante, "BOLETA ELECTRONICA"))
        Me.ComboComprobante.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboComprobante, "PROFORMA"))
        Me.ComboComprobante.Location = New System.Drawing.Point(205, 26)
        Me.ComboComprobante.MetroBorderColor = System.Drawing.Color.Silver
        Me.ComboComprobante.Name = "ComboComprobante"
        Me.ComboComprobante.Size = New System.Drawing.Size(143, 21)
        Me.ComboComprobante.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboComprobante.TabIndex = 410
        Me.ComboComprobante.Text = "NOTA DE VENTA"
        '
        'TextComprador
        '
        Me.TextComprador.BackColor = System.Drawing.Color.White
        Me.TextComprador.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TextComprador.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextComprador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextComprador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextComprador.CornerRadius = 3
        Me.TextComprador.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextComprador.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextComprador.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextComprador.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextComprador.Location = New System.Drawing.Point(10, 25)
        Me.TextComprador.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextComprador.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextComprador.Name = "TextComprador"
        Me.TextComprador.NearImage = CType(resources.GetObject("TextComprador.NearImage"), System.Drawing.Image)
        Me.TextComprador.ReadOnly = True
        Me.TextComprador.Size = New System.Drawing.Size(189, 22)
        Me.TextComprador.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextComprador.TabIndex = 409
        '
        'PanelCliSel
        '
        Me.PanelCliSel.Controls.Add(Me.Label1)
        Me.PanelCliSel.Controls.Add(Me.TextCliente)
        Me.PanelCliSel.Controls.Add(Me.txtTipoDocClie)
        Me.PanelCliSel.Controls.Add(Me.txtruc)
        Me.PanelCliSel.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelCliSel.Location = New System.Drawing.Point(0, 33)
        Me.PanelCliSel.Name = "PanelCliSel"
        Me.PanelCliSel.Size = New System.Drawing.Size(422, 56)
        Me.PanelCliSel.TabIndex = 520
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 520
        Me.Label1.Text = "Razón Social"
        '
        'TextCliente
        '
        Me.TextCliente.BackColor = System.Drawing.Color.White
        Me.TextCliente.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TextCliente.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextCliente.CornerRadius = 3
        Me.TextCliente.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextCliente.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextCliente.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextCliente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextCliente.Location = New System.Drawing.Point(15, 25)
        Me.TextCliente.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextCliente.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextCliente.Name = "TextCliente"
        Me.TextCliente.NearImage = CType(resources.GetObject("TextCliente.NearImage"), System.Drawing.Image)
        Me.TextCliente.ReadOnly = True
        Me.TextCliente.Size = New System.Drawing.Size(282, 22)
        Me.TextCliente.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextCliente.TabIndex = 408
        '
        'txtTipoDocClie
        '
        Me.txtTipoDocClie.BackColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.txtTipoDocClie.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtTipoDocClie.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.txtTipoDocClie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTipoDocClie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTipoDocClie.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTipoDocClie.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoDocClie.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTipoDocClie.Location = New System.Drawing.Point(201, 26)
        Me.txtTipoDocClie.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtTipoDocClie.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtTipoDocClie.Name = "txtTipoDocClie"
        Me.txtTipoDocClie.NearImage = CType(resources.GetObject("txtTipoDocClie.NearImage"), System.Drawing.Image)
        Me.txtTipoDocClie.ReadOnly = True
        Me.txtTipoDocClie.Size = New System.Drawing.Size(96, 22)
        Me.txtTipoDocClie.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtTipoDocClie.TabIndex = 519
        Me.txtTipoDocClie.Visible = False
        Me.txtTipoDocClie.WordWrap = False
        '
        'txtruc
        '
        Me.txtruc.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtruc.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtruc.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtruc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtruc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtruc.CornerRadius = 3
        Me.txtruc.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtruc.Enabled = False
        Me.txtruc.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtruc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtruc.Location = New System.Drawing.Point(303, 25)
        Me.txtruc.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtruc.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtruc.Name = "txtruc"
        Me.txtruc.NearImage = CType(resources.GetObject("txtruc.NearImage"), System.Drawing.Image)
        Me.txtruc.ReadOnly = True
        Me.txtruc.Size = New System.Drawing.Size(111, 22)
        Me.txtruc.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtruc.TabIndex = 409
        '
        'pcLikeCategoria
        '
        Me.pcLikeCategoria.Controls.Add(Me.LsvProveedor)
        Me.pcLikeCategoria.Location = New System.Drawing.Point(574, 88)
        Me.pcLikeCategoria.Name = "pcLikeCategoria"
        Me.pcLikeCategoria.Size = New System.Drawing.Size(282, 128)
        Me.pcLikeCategoria.TabIndex = 509
        '
        'LsvProveedor
        '
        Me.LsvProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LsvProveedor.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colID, Me.colCliente, Me.colRUC, Me.colTipoDoc})
        Me.LsvProveedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LsvProveedor.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LsvProveedor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(187, Byte), Integer))
        Me.LsvProveedor.FullRowSelect = True
        Me.LsvProveedor.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.LsvProveedor.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1})
        Me.LsvProveedor.Location = New System.Drawing.Point(0, 0)
        Me.LsvProveedor.MultiSelect = False
        Me.LsvProveedor.Name = "LsvProveedor"
        Me.LsvProveedor.Size = New System.Drawing.Size(282, 128)
        Me.LsvProveedor.TabIndex = 1
        Me.LsvProveedor.UseCompatibleStateImageBehavior = False
        Me.LsvProveedor.View = System.Windows.Forms.View.Details
        '
        'colID
        '
        Me.colID.Text = "ID"
        Me.colID.Width = 0
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
        'GradientPanel1
        '
        Me.GradientPanel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GradientPanel1.BorderColor = System.Drawing.Color.LightGray
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.LabelFecha)
        Me.GradientPanel1.Controls.Add(Me.ToolStrip1)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(1217, 33)
        Me.GradientPanel1.TabIndex = 222
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btGrabar, Me.ToolStripSeparator2, Me.ToolStripLabel3, Me.ToolStripSeparator3, Me.ToolStripButton1, Me.ToolStripSeparator4, Me.btServicio, Me.ToolStripSeparator5, Me.ToolImportar, Me.ToolStripSeparator6, Me.ToolStripButton2, Me.ToolStripSeparator7, Me.ToolStripButton4, Me.ToolStripSeparator1, Me.ToolStripButton3})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(1215, 31)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        Me.ToolStrip1.Visible = False
        '
        'btGrabar
        '
        Me.btGrabar.BackColor = System.Drawing.Color.Transparent
        Me.btGrabar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btGrabar.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btGrabar.Image = CType(resources.GetObject("btGrabar.Image"), System.Drawing.Image)
        Me.btGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btGrabar.Margin = New System.Windows.Forms.Padding(5, 1, 5, 2)
        Me.btGrabar.Name = "btGrabar"
        Me.btGrabar.Size = New System.Drawing.Size(76, 28)
        Me.btGrabar.Text = "Guardar - F2"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripLabel3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripLabel3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ToolStripLabel3.Image = CType(resources.GetObject("ToolStripLabel3.Image"), System.Drawing.Image)
        Me.ToolStripLabel3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripLabel3.Margin = New System.Windows.Forms.Padding(5, 1, 5, 2)
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(57, 28)
        Me.ToolStripLabel3.Text = "Cancelar"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ToolStripButton1.ForeColor = System.Drawing.Color.Black
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Margin = New System.Windows.Forms.Padding(50, 1, 5, 2)
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(105, 28)
        Me.ToolStripButton1.Text = "Producto - F5"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        '
        'btServicio
        '
        Me.btServicio.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.btServicio.ForeColor = System.Drawing.Color.Black
        Me.btServicio.Image = CType(resources.GetObject("btServicio.Image"), System.Drawing.Image)
        Me.btServicio.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btServicio.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btServicio.Margin = New System.Windows.Forms.Padding(5, 1, 5, 2)
        Me.btServicio.Name = "btServicio"
        Me.btServicio.Size = New System.Drawing.Size(102, 28)
        Me.btServicio.Text = "Servicios - F6"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 31)
        '
        'ToolImportar
        '
        Me.ToolImportar.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ToolImportar.ForeColor = System.Drawing.Color.Black
        Me.ToolImportar.Image = CType(resources.GetObject("ToolImportar.Image"), System.Drawing.Image)
        Me.ToolImportar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolImportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolImportar.Margin = New System.Windows.Forms.Padding(5, 1, 5, 2)
        Me.ToolImportar.Name = "ToolImportar"
        Me.ToolImportar.Size = New System.Drawing.Size(102, 28)
        Me.ToolImportar.Text = "Importar - F7"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 31)
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ToolStripButton2.ForeColor = System.Drawing.Color.Black
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Margin = New System.Windows.Forms.Padding(5, 1, 5, 2)
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(89, 28)
        Me.ToolStripButton2.Text = "Precio - F8"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 31)
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ToolStripButton4.ForeColor = System.Drawing.Color.Black
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Margin = New System.Windows.Forms.Padding(5, 1, 5, 2)
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(102, 28)
        Me.ToolStripButton4.Text = "Comprar - F9"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ToolStripButton3.ForeColor = System.Drawing.Color.Black
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Margin = New System.Windows.Forms.Padding(5, 1, 5, 2)
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(142, 28)
        Me.ToolStripButton3.Text = "Quitar producto - F10"
        '
        'dgvCompra
        '
        Me.dgvCompra.Appearance.AlternateRecordFieldCell.Font.Size = 8.0!
        Me.dgvCompra.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        Me.dgvCompra.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.dgvCompra.BackColor = System.Drawing.Color.White
        Me.dgvCompra.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvCompra.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCompra.FreezeCaption = False
        Me.dgvCompra.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgvCompra.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.dgvCompra.Location = New System.Drawing.Point(0, 89)
        Me.dgvCompra.Name = "dgvCompra"
        Me.dgvCompra.Size = New System.Drawing.Size(1217, 526)
        Me.dgvCompra.TabIndex = 507
        Me.dgvCompra.TableDescriptor.AllowNew = False
        Me.dgvCompra.TableDescriptor.Appearance.AnyCell.Font.Facename = "Segoe UI"
        Me.dgvCompra.TableDescriptor.Appearance.AnyCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.dgvCompra.TableDescriptor.Appearance.AnyGroupCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCompra.TableDescriptor.Appearance.AnyGroupCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCompra.TableDescriptor.Appearance.AnyGroupCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer)))
        Me.dgvCompra.TableDescriptor.Appearance.AnyHeaderCell.Font.Size = 8.0!
        Me.dgvCompra.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCompra.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCompra.TableDescriptor.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        Me.dgvCompra.TableDescriptor.Appearance.AnySummaryCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCompra.TableDescriptor.Appearance.AnySummaryCell.Borders.Top = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCompra.TableDescriptor.Appearance.AnySummaryCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)))
        Me.dgvCompra.TableDescriptor.Appearance.ColumnHeaderCell.Font.Bold = True
        Me.dgvCompra.TableDescriptor.Appearance.ColumnHeaderCell.Font.Italic = False
        Me.dgvCompra.TableDescriptor.Appearance.ColumnHeaderCell.Font.Size = 8.0!
        Me.dgvCompra.TableDescriptor.Appearance.GroupCaptionCell.CellType = """ColumnHeader"""
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.MappingName = "codigo"
        GridColumnDescriptor1.ReadOnly = True
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor2.AllowSort = False
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.HeaderText = "GR."
        GridColumnDescriptor2.MappingName = "gravado"
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor2.Width = 30
        GridColumnDescriptor3.AllowSort = False
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.MappingName = "idProducto"
        GridColumnDescriptor3.ReadOnly = True
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor4.AllowSort = False
        GridColumnDescriptor4.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        GridColumnDescriptor4.Appearance.AnyRecordFieldCell.Text = ""
        GridColumnDescriptor4.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.HeaderText = "PRODUCTO"
        GridColumnDescriptor4.MappingName = "item"
        GridColumnDescriptor4.ReadOnly = True
        GridColumnDescriptor4.SerializedImageArray = ""
        GridColumnDescriptor4.Width = 300
        GridColumnDescriptor5.AllowSort = False
        GridColumnDescriptor5.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor5.HeaderImage = Nothing
        GridColumnDescriptor5.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor5.HeaderText = "U.M."
        GridColumnDescriptor5.MappingName = "um"
        GridColumnDescriptor5.ReadOnly = True
        GridColumnDescriptor5.SerializedImageArray = ""
        GridColumnDescriptor5.Width = 50
        GridColumnDescriptor6.AllowSort = False
        GridColumnDescriptor6.Appearance.AnyRecordFieldCell.CellType = "Currency"
        GridColumnDescriptor6.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencyDecimalDigits = 3
        GridColumnDescriptor6.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
        GridColumnDescriptor6.Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = System.Drawing.SystemColors.HotTrack
        GridColumnDescriptor6.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.InactiveBorder)
        GridColumnDescriptor6.HeaderImage = Nothing
        GridColumnDescriptor6.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor6.HeaderText = "CANT."
        GridColumnDescriptor6.MappingName = "cantidad"
        GridColumnDescriptor6.SerializedImageArray = ""
        GridColumnDescriptor6.Width = 70
        GridColumnDescriptor7.AllowSort = False
        GridColumnDescriptor7.Appearance.AnyRecordFieldCell.CellType = "Currency"
        GridColumnDescriptor7.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
        GridColumnDescriptor7.Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = System.Drawing.Color.Black
        GridColumnDescriptor7.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        GridColumnDescriptor7.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor7.HeaderImage = Nothing
        GridColumnDescriptor7.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor7.HeaderText = "V.V."
        GridColumnDescriptor7.MappingName = "vcmn"
        GridColumnDescriptor7.SerializedImageArray = ""
        GridColumnDescriptor7.Width = 65
        GridColumnDescriptor8.AllowSort = False
        GridColumnDescriptor8.Appearance.AnyRecordFieldCell.CellType = "Currency"
        GridColumnDescriptor8.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
        GridColumnDescriptor8.Appearance.AnyRecordFieldCell.CurrencyEdit.NegativeColor = System.Drawing.Color.White
        GridColumnDescriptor8.Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = System.Drawing.Color.Black
        GridColumnDescriptor8.Appearance.AnyRecordFieldCell.Font.Bold = False
        GridColumnDescriptor8.Appearance.AnyRecordFieldCell.Font.Size = 10.0!
        GridColumnDescriptor8.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.InactiveBorder)
        GridColumnDescriptor8.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.White
        GridColumnDescriptor8.HeaderImage = Nothing
        GridColumnDescriptor8.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor8.HeaderText = "TOTAL"
        GridColumnDescriptor8.MappingName = "totalmn"
        GridColumnDescriptor8.ReadOnly = True
        GridColumnDescriptor8.SerializedImageArray = ""
        GridColumnDescriptor8.Width = 70
        GridColumnDescriptor9.AllowSort = False
        GridColumnDescriptor9.Appearance.AnyRecordFieldCell.CellType = "Currency"
        GridColumnDescriptor9.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
        GridColumnDescriptor9.Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = System.Drawing.Color.Black
        GridColumnDescriptor9.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        GridColumnDescriptor9.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.White
        GridColumnDescriptor9.HeaderImage = Nothing
        GridColumnDescriptor9.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor9.HeaderText = "IGV"
        GridColumnDescriptor9.MappingName = "igvmn"
        GridColumnDescriptor9.ReadOnly = True
        GridColumnDescriptor9.SerializedImageArray = ""
        GridColumnDescriptor9.Width = 65
        GridColumnDescriptor10.AllowSort = False
        GridColumnDescriptor10.Appearance.AnyRecordFieldCell.CellType = "Currency"
        GridColumnDescriptor10.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencyDecimalDigits = 5
        GridColumnDescriptor10.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
        GridColumnDescriptor10.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        GridColumnDescriptor10.Appearance.AnyRecordFieldCell.Text = ""
        GridColumnDescriptor10.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor10.HeaderImage = Nothing
        GridColumnDescriptor10.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor10.HeaderText = "P.U."
        GridColumnDescriptor10.MappingName = "pumn"
        GridColumnDescriptor10.ReadOnly = True
        GridColumnDescriptor10.SerializedImageArray = ""
        GridColumnDescriptor10.Width = 60
        GridColumnDescriptor11.HeaderImage = Nothing
        GridColumnDescriptor11.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor11.MappingName = "tipoPrecio"
        GridColumnDescriptor11.ReadOnly = True
        GridColumnDescriptor11.SerializedImageArray = ""
        GridColumnDescriptor11.Width = 0
        GridColumnDescriptor12.AllowSort = False
        GridColumnDescriptor12.Appearance.AnyRecordFieldCell.CellType = "Currency"
        GridColumnDescriptor12.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
        GridColumnDescriptor12.Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = System.Drawing.Color.Black
        GridColumnDescriptor12.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor12.HeaderImage = Nothing
        GridColumnDescriptor12.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor12.HeaderText = "Total Pagar"
        GridColumnDescriptor12.MappingName = "totalpagar"
        GridColumnDescriptor12.ReadOnly = True
        GridColumnDescriptor12.SerializedImageArray = ""
        GridColumnDescriptor12.Width = 80
        Me.dgvCompra.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7, GridColumnDescriptor8, GridColumnDescriptor9, GridColumnDescriptor10, GridColumnDescriptor11, GridColumnDescriptor12})
        Me.dgvCompra.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 29
        Me.dgvCompra.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.dgvCompra.TableDescriptor.TopLevelGroupOptions.ShowCaption = False
        Me.dgvCompra.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("gravado"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("item"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("um"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("cantidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("vcmn"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("totalmn"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("igvmn"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("pumn"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipoPrecio"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("totalpagar")})
        Me.dgvCompra.TableOptions.ShowRecordPreviewRow = False
        Me.dgvCompra.Text = "GridGroupingControl2"
        Me.dgvCompra.TopLevelGroupOptions.ShowCaption = True
        Me.dgvCompra.TopLevelGroupOptions.ShowCaptionPlusMinus = False
        Me.dgvCompra.TopLevelGroupOptions.ShowCaptionSummaryCells = False
        Me.dgvCompra.VersionInfo = "12.4400.0.24"
        '
        'DigitalGauge2
        '
        Me.DigitalGauge2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DigitalGauge2.BackgroundGradientEndColor = System.Drawing.Color.White
        Me.DigitalGauge2.BackgroundGradientStartColor = System.Drawing.Color.White
        Me.DigitalGauge2.CharacterCount = 10
        Me.DigitalGauge2.DisplayRecordIndex = 0
        Me.DigitalGauge2.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.DigitalGauge2.ForeColor = System.Drawing.Color.Gray
        Me.DigitalGauge2.Location = New System.Drawing.Point(8, 5)
        Me.DigitalGauge2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DigitalGauge2.MaximumSize = New System.Drawing.Size(583, 222)
        Me.DigitalGauge2.MinimumSize = New System.Drawing.Size(90, 90)
        Me.DigitalGauge2.Name = "DigitalGauge2"
        Me.DigitalGauge2.OuterFrameGradientEndColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.DigitalGauge2.OuterFrameGradientStartColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.DigitalGauge2.ShowInvisibleSegments = True
        Me.DigitalGauge2.Size = New System.Drawing.Size(332, 99)
        Me.DigitalGauge2.TabIndex = 519
        Me.DigitalGauge2.Value = "0.00"
        Me.DigitalGauge2.VisualStyle = Syncfusion.Windows.Forms.Gauge.ThemeStyle.Metro
        '
        'PanelPrecios2
        '
        Me.PanelPrecios2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PanelPrecios2.BorderColor = System.Drawing.Color.Gainsboro
        Me.PanelPrecios2.BorderSides = System.Windows.Forms.Border3DSide.Left
        Me.PanelPrecios2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelPrecios2.Controls.Add(Me.TextTotal)
        Me.PanelPrecios2.Controls.Add(Me.Label6)
        Me.PanelPrecios2.Controls.Add(Me.TextIVA)
        Me.PanelPrecios2.Controls.Add(Me.Label5)
        Me.PanelPrecios2.Controls.Add(Me.TextBaseImponible)
        Me.PanelPrecios2.Controls.Add(Me.Label24)
        Me.PanelPrecios2.Controls.Add(Me.DigitalGauge2)
        Me.PanelPrecios2.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelPrecios2.Location = New System.Drawing.Point(867, 89)
        Me.PanelPrecios2.Name = "PanelPrecios2"
        Me.PanelPrecios2.Size = New System.Drawing.Size(350, 526)
        Me.PanelPrecios2.TabIndex = 508
        '
        'TextTotal
        '
        Me.TextTotal.BackGroundColor = System.Drawing.Color.WhiteSmoke
        Me.TextTotal.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TextTotal.BorderColor = System.Drawing.SystemColors.Highlight
        Me.TextTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextTotal.CornerRadius = 4
        Me.TextTotal.CurrencySymbol = ""
        Me.TextTotal.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextTotal.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextTotal.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextTotal.ForeColor = System.Drawing.Color.Black
        Me.TextTotal.Location = New System.Drawing.Point(237, 192)
        Me.TextTotal.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextTotal.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextTotal.Name = "TextTotal"
        Me.TextTotal.NullString = ""
        Me.TextTotal.PositiveColor = System.Drawing.Color.Black
        Me.TextTotal.ReadOnly = True
        Me.TextTotal.ReadOnlyBackColor = System.Drawing.Color.WhiteSmoke
        Me.TextTotal.Size = New System.Drawing.Size(100, 25)
        Me.TextTotal.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextTotal.TabIndex = 525
        Me.TextTotal.Text = "0.00"
        Me.TextTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(195, 199)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 15)
        Me.Label6.TabIndex = 524
        Me.Label6.Text = "Total:"
        '
        'TextIVA
        '
        Me.TextIVA.BackGroundColor = System.Drawing.Color.WhiteSmoke
        Me.TextIVA.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TextIVA.BorderColor = System.Drawing.SystemColors.Highlight
        Me.TextIVA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextIVA.CornerRadius = 4
        Me.TextIVA.CurrencySymbol = ""
        Me.TextIVA.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextIVA.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextIVA.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextIVA.ForeColor = System.Drawing.Color.Black
        Me.TextIVA.Location = New System.Drawing.Point(237, 161)
        Me.TextIVA.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextIVA.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextIVA.Name = "TextIVA"
        Me.TextIVA.NullString = ""
        Me.TextIVA.PositiveColor = System.Drawing.Color.Black
        Me.TextIVA.ReadOnly = True
        Me.TextIVA.ReadOnlyBackColor = System.Drawing.Color.WhiteSmoke
        Me.TextIVA.Size = New System.Drawing.Size(100, 25)
        Me.TextIVA.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextIVA.TabIndex = 523
        Me.TextIVA.Text = "0.00"
        Me.TextIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(203, 168)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(28, 15)
        Me.Label5.TabIndex = 522
        Me.Label5.Text = "Iva.:"
        '
        'TextBaseImponible
        '
        Me.TextBaseImponible.BackGroundColor = System.Drawing.Color.WhiteSmoke
        Me.TextBaseImponible.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TextBaseImponible.BorderColor = System.Drawing.SystemColors.Highlight
        Me.TextBaseImponible.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBaseImponible.CornerRadius = 4
        Me.TextBaseImponible.CurrencySymbol = ""
        Me.TextBaseImponible.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBaseImponible.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextBaseImponible.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBaseImponible.ForeColor = System.Drawing.Color.Black
        Me.TextBaseImponible.Location = New System.Drawing.Point(237, 128)
        Me.TextBaseImponible.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextBaseImponible.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextBaseImponible.Name = "TextBaseImponible"
        Me.TextBaseImponible.NullString = ""
        Me.TextBaseImponible.PositiveColor = System.Drawing.Color.Black
        Me.TextBaseImponible.ReadOnly = True
        Me.TextBaseImponible.ReadOnlyBackColor = System.Drawing.Color.WhiteSmoke
        Me.TextBaseImponible.Size = New System.Drawing.Size(100, 25)
        Me.TextBaseImponible.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextBaseImponible.TabIndex = 521
        Me.TextBaseImponible.Text = "0.00"
        Me.TextBaseImponible.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.Black
        Me.Label24.Location = New System.Drawing.Point(142, 135)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(91, 15)
        Me.Label24.TabIndex = 520
        Me.Label24.Text = "Base Imponible:"
        '
        'LabelFecha
        '
        Me.LabelFecha.AutoSize = True
        Me.LabelFecha.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelFecha.Location = New System.Drawing.Point(13, 8)
        Me.LabelFecha.Name = "LabelFecha"
        Me.LabelFecha.Size = New System.Drawing.Size(107, 15)
        Me.LabelFecha.TabIndex = 1
        Me.LabelFecha.Text = "VENTA: 2019/00/00"
        '
        'FormViewVentaGeneral
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionForeColor = System.Drawing.Color.White
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(15, 4)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(25, 25)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.Location = New System.Drawing.Point(40, 4)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Text = "Venta"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(1217, 615)
        Me.Controls.Add(Me.PanelPrecios2)
        Me.Controls.Add(Me.dgvCompra)
        Me.Controls.Add(Me.Panel11)
        Me.Name = "FormViewVentaGeneral"
        Me.ShowIcon = False
        Me.Text = "Ver Venta General"
        Me.Panel11.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.TextNumeroVenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboComprobante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextComprador, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelCliSel.ResumeLayout(False)
        Me.PanelCliSel.PerformLayout()
        CType(Me.TextCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoDocClie, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtruc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pcLikeCategoria.ResumeLayout(False)
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.dgvCompra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelPrecios2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelPrecios2.ResumeLayout(False)
        Me.PanelPrecios2.PerformLayout()
        CType(Me.TextTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextIVA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBaseImponible, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel11 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents ComboComprobante As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents TextComprador As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents PanelCliSel As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents TextCliente As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtTipoDocClie As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtruc As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Private WithEvents pcLikeCategoria As Syncfusion.Windows.Forms.PopupControlContainer
    Friend WithEvents LsvProveedor As ListView
    Friend WithEvents colID As ColumnHeader
    Friend WithEvents colCliente As ColumnHeader
    Friend WithEvents colRUC As ColumnHeader
    Friend WithEvents colTipoDoc As ColumnHeader
    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btGrabar As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripLabel3 As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents btServicio As ToolStripButton
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents ToolImportar As ToolStripButton
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents ToolStripButton4 As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripButton3 As ToolStripButton
    Friend WithEvents Label4 As Label
    Friend WithEvents TextNumeroVenta As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label3 As Label
    Friend WithEvents dgvCompra As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents DigitalGauge2 As Syncfusion.Windows.Forms.Gauge.DigitalGauge
    Friend WithEvents PanelPrecios2 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents TextTotal As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TextIVA As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBaseImponible As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents LabelFecha As Label
End Class

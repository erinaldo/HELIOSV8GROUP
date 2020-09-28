<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfigSistema
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConfigSistema))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.QGlobalColorSchemeManager1 = New Qios.DevSuite.Components.QGlobalColorSchemeManager(Me.components)
        Me.QRibbon1 = New Qios.DevSuite.Components.Ribbon.QRibbon()
        Me.QRibbonPage1 = New Qios.DevSuite.Components.Ribbon.QRibbonPage()
        Me.QCompositeImage1 = New Qios.DevSuite.Components.QCompositeImage()
        Me.QCompositeSeparator1 = New Qios.DevSuite.Components.QCompositeSeparator()
        Me.QRibbonPanel4 = New Qios.DevSuite.Components.Ribbon.QRibbonPanel()
        Me.QRibbonItem2 = New Qios.DevSuite.Components.Ribbon.QRibbonItem()
        Me.lblCompra = New System.Windows.Forms.Label()
        Me.QRibbonPanel5 = New Qios.DevSuite.Components.Ribbon.QRibbonPanel()
        Me.QRibbonItem3 = New Qios.DevSuite.Components.Ribbon.QRibbonItem()
        Me.lblVenta = New System.Windows.Forms.Label()
        Me.QRibbonPanel6 = New Qios.DevSuite.Components.Ribbon.QRibbonPanel()
        Me.QRibbonItem4 = New Qios.DevSuite.Components.Ribbon.QRibbonItem()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.QRibbonPanel7 = New Qios.DevSuite.Components.Ribbon.QRibbonPanel()
        Me.QRibbonItemGroup3 = New Qios.DevSuite.Components.Ribbon.QRibbonItemGroup()
        Me.QCompositeImage2 = New Qios.DevSuite.Components.QCompositeImage()
        Me.QCompositeItemControl1 = New Qios.DevSuite.Components.QCompositeItemControl()
        Me.QRibbonItem5 = New Qios.DevSuite.Components.Ribbon.QRibbonItem()
        Me.QRibbonItem1 = New Qios.DevSuite.Components.Ribbon.QRibbonItem()
        Me.QCompositeItem1 = New Qios.DevSuite.Components.QCompositeItem()
        Me.QRibbonItemGroup1 = New Qios.DevSuite.Components.Ribbon.QRibbonItemGroup()
        Me.QRibbonPanel1 = New Qios.DevSuite.Components.Ribbon.QRibbonPanel()
        Me.QRibbonPanel2 = New Qios.DevSuite.Components.Ribbon.QRibbonPanel()
        Me.QRibbonItemGroup2 = New Qios.DevSuite.Components.Ribbon.QRibbonItemGroup()
        Me.QCompositeButton1 = New Qios.DevSuite.Components.QCompositeButton()
        Me.KryptonButton1 = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.QRibbonPanel3 = New Qios.DevSuite.Components.Ribbon.QRibbonPanel()
        Me.KryptonContextMenu1 = New ComponentFactory.Krypton.Toolkit.KryptonContextMenu()
        Me.KryptonLinkLabel1 = New ComponentFactory.Krypton.Toolkit.KryptonLinkLabel()
        Me.nudMaximo = New ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.nudINcremento = New ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.nudInicio = New ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSerie = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtComprobante = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.lblEstado = New System.Windows.Forms.ToolStripButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgvSeries = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.colID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCompC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSerieC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colValInicial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMAxim = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colElim = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.colEditC = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.lsvSeries = New System.Windows.Forms.ListView()
        Me.colTipD = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Colser = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColVal = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.GuardarToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dgvSerieVenta = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewButtonColumn1 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.DataGridViewButtonColumn2 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.lsvSerieVenta = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.QPanel1 = New Qios.DevSuite.Components.QPanel()
        Me.dgvConfiguraciones = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.coID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colModulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COLTipoConf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colComprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSerie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIDAlmacen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAlmacen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIdCaja = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEF = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEli = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbProgramado = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.rbManual = New ComponentFactory.Krypton.Toolkit.KryptonRadioButton()
        Me.txtSerieConf = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.cboComprobant = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.cboModulo = New ComponentFactory.Krypton.Toolkit.KryptonComboBox()
        Me.rbSalida = New System.Windows.Forms.RadioButton()
        Me.rbEntrada = New System.Windows.Forms.RadioButton()
        Me.ToolStrip4 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.KryptonContextMenuItems1 = New ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems()
        Me.KryptonContextMenuHeading2 = New ComponentFactory.Krypton.Toolkit.KryptonContextMenuHeading()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.QRibbon1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.QRibbon1.SuspendLayout()
        CType(Me.QRibbonPage1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.QRibbonPage1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvSeries, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvSerieVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip3.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.QPanel1.SuspendLayout()
        CType(Me.dgvConfiguraciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.cboComprobant, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboModulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip4.SuspendLayout()
        Me.SuspendLayout()
        '
        'QRibbon1
        '
        Me.QRibbon1.ActiveTabPage = Me.QRibbonPage1
        Me.QRibbon1.Controls.Add(Me.QRibbonPage1)
        Me.QRibbon1.Dock = System.Windows.Forms.DockStyle.Top
        Me.QRibbon1.Location = New System.Drawing.Point(0, 0)
        Me.QRibbon1.Name = "QRibbon1"
        Me.QRibbon1.PersistGuid = New System.Guid("88e8b3eb-8d9f-4f3b-aa83-f9ae673cb6f1")
        Me.QRibbon1.Size = New System.Drawing.Size(1169, 127)
        Me.QRibbon1.TabIndex = 1
        Me.QRibbon1.Text = "QRibbon1"
        '
        'QRibbonPage1
        '
        Me.QRibbonPage1.ButtonOrder = 0
        Me.QRibbonPage1.Items.Add(Me.QCompositeImage1)
        Me.QRibbonPage1.Items.Add(Me.QCompositeSeparator1)
        Me.QRibbonPage1.Items.Add(Me.QRibbonPanel4)
        Me.QRibbonPage1.Items.Add(Me.QRibbonPanel5)
        Me.QRibbonPage1.Items.Add(Me.QRibbonPanel6)
        Me.QRibbonPage1.Items.Add(Me.QRibbonPanel7)
        Me.QRibbonPage1.Location = New System.Drawing.Point(2, 31)
        Me.QRibbonPage1.Name = "QRibbonPage1"
        Me.QRibbonPage1.PersistGuid = New System.Guid("19b50020-6828-4c6d-adf0-07e5020dfde6")
        Me.QRibbonPage1.Size = New System.Drawing.Size(1163, 92)
        Me.QRibbonPage1.Text = "Configuración General"
        '
        'QRibbonPanel4
        '
        Me.QRibbonPanel4.Items.Add(Me.QRibbonItem2)
        Me.QRibbonPanel4.Title = "Entradas"
        '
        'QRibbonItem2
        '
        Me.QRibbonItem2.Configuration.AlignmentHorizontal = Qios.DevSuite.Components.QPartAlignment.Centered
        Me.QRibbonItem2.Configuration.AlignmentVertical = Qios.DevSuite.Components.QPartAlignment.Centered
        Me.QRibbonItem2.ContentType = Qios.DevSuite.Components.QCompositeMenuItemContentType.Control
        Me.QRibbonItem2.Control = Me.lblCompra
        Me.QRibbonItem2.ControlSize = New System.Drawing.Size(59, 57)
        Me.QRibbonItem2.Title = "QRibbonItem2"
        '
        'lblCompra
        '
        Me.lblCompra.BackColor = System.Drawing.Color.Transparent
        Me.lblCompra.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCompra.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblCompra.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.lblCompra.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.compra_icn
        Me.lblCompra.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.lblCompra.Location = New System.Drawing.Point(14, 8)
        Me.lblCompra.Name = "lblCompra"
        Me.lblCompra.Size = New System.Drawing.Size(59, 57)
        Me.lblCompra.TabIndex = 2
        Me.lblCompra.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'QRibbonPanel5
        '
        Me.QRibbonPanel5.Items.Add(Me.QRibbonItem3)
        Me.QRibbonPanel5.Title = "Sálidas"
        '
        'QRibbonItem3
        '
        Me.QRibbonItem3.Configuration.AlignmentHorizontal = Qios.DevSuite.Components.QPartAlignment.Centered
        Me.QRibbonItem3.Configuration.AlignmentVertical = Qios.DevSuite.Components.QPartAlignment.Centered
        Me.QRibbonItem3.ContentType = Qios.DevSuite.Components.QCompositeMenuItemContentType.Control
        Me.QRibbonItem3.Control = Me.lblVenta
        Me.QRibbonItem3.ControlSize = New System.Drawing.Size(59, 55)
        Me.QRibbonItem3.Title = "Ventas"
        '
        'lblVenta
        '
        Me.lblVenta.BackColor = System.Drawing.Color.Transparent
        Me.lblVenta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblVenta.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblVenta.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.lblVenta.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources._012
        Me.lblVenta.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.lblVenta.Location = New System.Drawing.Point(89, 9)
        Me.lblVenta.Name = "lblVenta"
        Me.lblVenta.Size = New System.Drawing.Size(59, 55)
        Me.lblVenta.TabIndex = 3
        Me.lblVenta.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'QRibbonPanel6
        '
        Me.QRibbonPanel6.Items.Add(Me.QRibbonItem4)
        Me.QRibbonPanel6.Title = "Gestión"
        '
        'QRibbonItem4
        '
        Me.QRibbonItem4.Configuration.AlignmentHorizontal = Qios.DevSuite.Components.QPartAlignment.Centered
        Me.QRibbonItem4.Configuration.AlignmentVertical = Qios.DevSuite.Components.QPartAlignment.Centered
        Me.QRibbonItem4.Configuration.ControlConfiguration.Visible = Qios.DevSuite.Components.QTristateBool.[True]
        Me.QRibbonItem4.ContentType = Qios.DevSuite.Components.QCompositeMenuItemContentType.Control
        Me.QRibbonItem4.Control = Me.lblUsuario
        Me.QRibbonItem4.ControlSize = New System.Drawing.Size(81, 55)
        Me.QRibbonItem4.Title = "QRibbonItem4"
        '
        'lblUsuario
        '
        Me.lblUsuario.BackColor = System.Drawing.Color.Transparent
        Me.lblUsuario.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblUsuario.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblUsuario.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.lblUsuario.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources._002
        Me.lblUsuario.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.lblUsuario.Location = New System.Drawing.Point(164, 9)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(81, 55)
        Me.lblUsuario.TabIndex = 4
        Me.lblUsuario.Text = "Usuarios"
        Me.lblUsuario.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'QRibbonPanel7
        '
        Me.QRibbonPanel7.Items.Add(Me.QRibbonItemGroup3)
        Me.QRibbonPanel7.Items.Add(Me.QCompositeImage2)
        Me.QRibbonPanel7.Items.Add(Me.QCompositeItemControl1)
        Me.QRibbonPanel7.Items.Add(Me.QRibbonItem5)
        Me.QRibbonPanel7.Title = "Configuración"
        '
        'QRibbonItem5
        '
        Me.QRibbonItem5.Configuration.AlignmentHorizontal = Qios.DevSuite.Components.QPartAlignment.Centered
        Me.QRibbonItem5.Configuration.AlignmentVertical = Qios.DevSuite.Components.QPartAlignment.Centered
        Me.QRibbonItem5.Configuration.CheckBehaviour = Qios.DevSuite.Components.QCompositeMenuItemCheckBehaviour.CheckIcon
        Me.QRibbonItem5.Configuration.TitleConfiguration.ContentAlignmentHorizontal = Qios.DevSuite.Components.QPartAlignment.Centered
        Me.QRibbonItem5.Configuration.TitleConfiguration.ContentAlignmentVertical = Qios.DevSuite.Components.QPartAlignment.Centered
        Me.QRibbonItem5.Configuration.TitleConfiguration.WrapText = True
        Me.QRibbonItem5.Icon = CType(resources.GetObject("QRibbonItem5.Icon"), System.Drawing.Icon)
        Me.QRibbonItem5.Title = "Módulos"
        '
        'QRibbonItem1
        '
        Me.QRibbonItem1.Title = "QRibbonItem1"
        '
        'QRibbonPanel1
        '
        Me.QRibbonPanel1.Items.Add(Me.QRibbonItemGroup1)
        Me.QRibbonPanel1.Items.Add(Me.QCompositeItem1)
        Me.QRibbonPanel1.Items.Add(Me.QRibbonItem1)
        Me.QRibbonPanel1.Title = "COMPRAS"
        '
        'QRibbonPanel2
        '
        Me.QRibbonPanel2.Items.Add(Me.QRibbonItemGroup2)
        Me.QRibbonPanel2.Items.Add(Me.QCompositeButton1)
        Me.QRibbonPanel2.Title = "Compras"
        '
        'QCompositeButton1
        '
        Me.QCompositeButton1.ContentType = Qios.DevSuite.Components.QCompositeMenuItemContentType.Control
        Me.QCompositeButton1.Control = Me.KryptonButton1
        Me.QCompositeButton1.ControlSize = New System.Drawing.Size(672, 92)
        Me.QCompositeButton1.Title = "QCompositeButton1"
        '
        'KryptonButton1
        '
        Me.KryptonButton1.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Cluster
        Me.KryptonButton1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonButton1.Location = New System.Drawing.Point(7, 7)
        Me.KryptonButton1.Name = "KryptonButton1"
        Me.KryptonButton1.Size = New System.Drawing.Size(672, 92)
        Me.KryptonButton1.TabIndex = 2
        Me.KryptonButton1.Values.Text = "Comprobantes"
        '
        'QRibbonPanel3
        '
        Me.QRibbonPanel3.Title = "QRibbonPanel3"
        '
        'KryptonLinkLabel1
        '
        Me.KryptonLinkLabel1.Location = New System.Drawing.Point(262, 33)
        Me.KryptonLinkLabel1.Name = "KryptonLinkLabel1"
        Me.KryptonLinkLabel1.Size = New System.Drawing.Size(19, 20)
        Me.KryptonLinkLabel1.TabIndex = 23
        Me.KryptonLinkLabel1.Values.Text = "..."
        '
        'nudMaximo
        '
        Me.nudMaximo.DecimalPlaces = 2
        Me.nudMaximo.Location = New System.Drawing.Point(523, 32)
        Me.nudMaximo.Maximum = New Decimal(New Integer() {-559939584, 902409669, 54, 0})
        Me.nudMaximo.Name = "nudMaximo"
        Me.nudMaximo.Size = New System.Drawing.Size(130, 22)
        Me.nudMaximo.TabIndex = 22
        Me.nudMaximo.Value = New Decimal(New Integer() {1000000000, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(447, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 13)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Valor máximo:"
        '
        'nudINcremento
        '
        Me.nudINcremento.Location = New System.Drawing.Point(380, 56)
        Me.nudINcremento.Maximum = New Decimal(New Integer() {-559939584, 902409669, 54, 0})
        Me.nudINcremento.Name = "nudINcremento"
        Me.nudINcremento.Size = New System.Drawing.Size(56, 22)
        Me.nudINcremento.TabIndex = 20
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(312, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 13)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Incremento:"
        '
        'nudInicio
        '
        Me.nudInicio.Location = New System.Drawing.Point(380, 32)
        Me.nudInicio.Maximum = New Decimal(New Integer() {-559939584, 902409669, 54, 0})
        Me.nudInicio.Name = "nudInicio"
        Me.nudInicio.Size = New System.Drawing.Size(56, 22)
        Me.nudInicio.TabIndex = 18
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(312, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Valor Inicial:"
        '
        'txtSerie
        '
        Me.txtSerie.Location = New System.Drawing.Point(104, 59)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(155, 19)
        Me.txtSerie.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(63, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Serie:"
        '
        'txtComprobante
        '
        Me.txtComprobante.Location = New System.Drawing.Point(104, 34)
        Me.txtComprobante.Name = "txtComprobante"
        Me.txtComprobante.ReadOnly = True
        Me.txtComprobante.Size = New System.Drawing.Size(155, 19)
        Me.txtComprobante.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(22, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Comprobante:"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ToolStrip2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.KryptonLinkLabel1)
        Me.Panel1.Controls.Add(Me.txtComprobante)
        Me.Panel1.Controls.Add(Me.nudMaximo)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txtSerie)
        Me.Panel1.Controls.Add(Me.nudINcremento)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.nudInicio)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 127)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1169, 86)
        Me.Panel1.TabIndex = 24
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblEstado})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(1169, 25)
        Me.ToolStrip2.TabIndex = 24
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'lblEstado
        '
        Me.lblEstado.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblEstado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(44, 22)
        Me.lblEstado.Text = "Estado"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TabControl1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 213)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1169, 408)
        Me.Panel2.TabIndex = 25
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1169, 408)
        Me.TabControl1.TabIndex = 4
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgvSeries)
        Me.TabPage1.Controls.Add(Me.lsvSeries)
        Me.TabPage1.Controls.Add(Me.ToolStrip1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1161, 382)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Configuraciones de comprobantes"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgvSeries
        '
        Me.dgvSeries.AllowUserToAddRows = False
        Me.dgvSeries.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colID, Me.colCompC, Me.colSerieC, Me.colValInicial, Me.colInc, Me.colMAxim, Me.colElim, Me.colEditC})
        Me.dgvSeries.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSeries.Location = New System.Drawing.Point(3, 28)
        Me.dgvSeries.Name = "dgvSeries"
        Me.dgvSeries.Size = New System.Drawing.Size(945, 351)
        Me.dgvSeries.TabIndex = 3
        '
        'colID
        '
        Me.colID.HeaderText = "ID"
        Me.colID.Name = "colID"
        Me.colID.ReadOnly = True
        Me.colID.Visible = False
        Me.colID.Width = 30
        '
        'colCompC
        '
        Me.colCompC.HeaderText = "Comprobante"
        Me.colCompC.Name = "colCompC"
        Me.colCompC.ReadOnly = True
        Me.colCompC.Width = 180
        '
        'colSerieC
        '
        Me.colSerieC.HeaderText = "Serie"
        Me.colSerieC.Name = "colSerieC"
        Me.colSerieC.ReadOnly = True
        Me.colSerieC.Width = 59
        '
        'colValInicial
        '
        Me.colValInicial.HeaderText = "Valor actual"
        Me.colValInicial.Name = "colValInicial"
        Me.colValInicial.ReadOnly = True
        '
        'colInc
        '
        Me.colInc.HeaderText = "Incremento"
        Me.colInc.Name = "colInc"
        Me.colInc.ReadOnly = True
        '
        'colMAxim
        '
        Me.colMAxim.HeaderText = "Máximo"
        Me.colMAxim.Name = "colMAxim"
        Me.colMAxim.ReadOnly = True
        Me.colMAxim.Width = 120
        '
        'colElim
        '
        Me.colElim.HeaderText = ""
        Me.colElim.Name = "colElim"
        Me.colElim.ReadOnly = True
        Me.colElim.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colElim.Width = 30
        '
        'colEditC
        '
        Me.colEditC.HeaderText = ""
        Me.colEditC.Name = "colEditC"
        Me.colEditC.ReadOnly = True
        Me.colEditC.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colEditC.Width = 30
        '
        'lsvSeries
        '
        Me.lsvSeries.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colTipD, Me.Colser, Me.ColVal})
        Me.lsvSeries.Dock = System.Windows.Forms.DockStyle.Right
        Me.lsvSeries.Location = New System.Drawing.Point(948, 28)
        Me.lsvSeries.Name = "lsvSeries"
        Me.lsvSeries.Size = New System.Drawing.Size(210, 351)
        Me.lsvSeries.TabIndex = 4
        Me.lsvSeries.UseCompatibleStateImageBehavior = False
        Me.lsvSeries.View = System.Windows.Forms.View.Details
        '
        'colTipD
        '
        Me.colTipD.Text = "Tipo Doc."
        Me.colTipD.Width = 71
        '
        'Colser
        '
        Me.Colser.Text = "Serie"
        '
        'ColVal
        '
        Me.ColVal.Text = "Valor actual"
        Me.ColVal.Width = 75
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GuardarToolStripButton, Me.toolStripSeparator, Me.ToolStripButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 3)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1155, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'GuardarToolStripButton
        '
        Me.GuardarToolStripButton.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.GuardarToolStripButton.Image = CType(resources.GetObject("GuardarToolStripButton.Image"), System.Drawing.Image)
        Me.GuardarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.GuardarToolStripButton.Name = "GuardarToolStripButton"
        Me.GuardarToolStripButton.Size = New System.Drawing.Size(60, 22)
        Me.GuardarToolStripButton.Text = "&Grabar"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.ToolStripButton1.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources._010
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(83, 22)
        Me.ToolStripButton1.Text = "Anclar serie"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dgvSerieVenta)
        Me.TabPage2.Controls.Add(Me.lsvSerieVenta)
        Me.TabPage2.Controls.Add(Me.ToolStrip3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1161, 354)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Configuraciones de comprobantes"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dgvSerieVenta
        '
        Me.dgvSerieVenta.AllowUserToAddRows = False
        Me.dgvSerieVenta.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewButtonColumn1, Me.DataGridViewButtonColumn2})
        Me.dgvSerieVenta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSerieVenta.Location = New System.Drawing.Point(3, 28)
        Me.dgvSerieVenta.Name = "dgvSerieVenta"
        Me.dgvSerieVenta.Size = New System.Drawing.Size(945, 323)
        Me.dgvSerieVenta.TabIndex = 6
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 30
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Comprobante"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 180
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Serie"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 59
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Valor actual"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Incremento"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Máximo"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 120
        '
        'DataGridViewButtonColumn1
        '
        Me.DataGridViewButtonColumn1.HeaderText = ""
        Me.DataGridViewButtonColumn1.Name = "DataGridViewButtonColumn1"
        Me.DataGridViewButtonColumn1.ReadOnly = True
        Me.DataGridViewButtonColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewButtonColumn1.Width = 30
        '
        'DataGridViewButtonColumn2
        '
        Me.DataGridViewButtonColumn2.HeaderText = ""
        Me.DataGridViewButtonColumn2.Name = "DataGridViewButtonColumn2"
        Me.DataGridViewButtonColumn2.ReadOnly = True
        Me.DataGridViewButtonColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewButtonColumn2.Width = 30
        '
        'lsvSerieVenta
        '
        Me.lsvSerieVenta.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.lsvSerieVenta.Dock = System.Windows.Forms.DockStyle.Right
        Me.lsvSerieVenta.Location = New System.Drawing.Point(948, 28)
        Me.lsvSerieVenta.Name = "lsvSerieVenta"
        Me.lsvSerieVenta.Size = New System.Drawing.Size(210, 323)
        Me.lsvSerieVenta.TabIndex = 7
        Me.lsvSerieVenta.UseCompatibleStateImageBehavior = False
        Me.lsvSerieVenta.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Tipo Doc."
        Me.ColumnHeader1.Width = 71
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Serie"
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Valor actual"
        Me.ColumnHeader3.Width = 75
        '
        'ToolStrip3
        '
        Me.ToolStrip3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton2, Me.ToolStripSeparator1, Me.ToolStripButton3})
        Me.ToolStrip3.Location = New System.Drawing.Point(3, 3)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.Size = New System.Drawing.Size(1155, 25)
        Me.ToolStrip3.TabIndex = 5
        Me.ToolStrip3.Text = "ToolStrip3"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(60, 22)
        Me.ToolStripButton2.Text = "&Grabar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.ToolStripButton3.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources._010
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(83, 22)
        Me.ToolStripButton3.Text = "Anclar serie"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.QPanel1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(1161, 354)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Configuración de módulos"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'QPanel1
        '
        Me.QPanel1.Appearance.BackgroundStyle = Qios.DevSuite.Components.QColorStyle.Metallic
        Me.QPanel1.Controls.Add(Me.dgvConfiguraciones)
        Me.QPanel1.Controls.Add(Me.Panel3)
        Me.QPanel1.Controls.Add(Me.ToolStrip4)
        Me.QPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.QPanel1.Location = New System.Drawing.Point(3, 3)
        Me.QPanel1.Name = "QPanel1"
        Me.QPanel1.Size = New System.Drawing.Size(1155, 348)
        Me.QPanel1.TabIndex = 0
        Me.QPanel1.Text = "QPanel1"
        '
        'dgvConfiguraciones
        '
        Me.dgvConfiguraciones.AllowUserToAddRows = False
        Me.dgvConfiguraciones.AllowUserToResizeColumns = False
        Me.dgvConfiguraciones.AllowUserToResizeRows = False
        Me.dgvConfiguraciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.coID, Me.colModulo, Me.COLTipoConf, Me.colComprobante, Me.colSerie, Me.colIDAlmacen, Me.colAlmacen, Me.colIdCaja, Me.colEF, Me.colEli})
        Me.dgvConfiguraciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvConfiguraciones.Location = New System.Drawing.Point(0, 94)
        Me.dgvConfiguraciones.MultiSelect = False
        Me.dgvConfiguraciones.Name = "dgvConfiguraciones"
        Me.dgvConfiguraciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvConfiguraciones.Size = New System.Drawing.Size(1153, 252)
        Me.dgvConfiguraciones.TabIndex = 7
        '
        'coID
        '
        Me.coID.HeaderText = "ID"
        Me.coID.Name = "coID"
        Me.coID.ReadOnly = True
        Me.coID.Width = 30
        '
        'colModulo
        '
        Me.colModulo.HeaderText = "Módulo"
        Me.colModulo.Name = "colModulo"
        Me.colModulo.ReadOnly = True
        Me.colModulo.Width = 180
        '
        'COLTipoConf
        '
        Me.COLTipoConf.HeaderText = "Configuración"
        Me.COLTipoConf.Name = "COLTipoConf"
        '
        'colComprobante
        '
        Me.colComprobante.HeaderText = "Comprobante"
        Me.colComprobante.Name = "colComprobante"
        Me.colComprobante.ReadOnly = True
        Me.colComprobante.Width = 120
        '
        'colSerie
        '
        Me.colSerie.HeaderText = "Serie"
        Me.colSerie.Name = "colSerie"
        Me.colSerie.ReadOnly = True
        Me.colSerie.Width = 85
        '
        'colIDAlmacen
        '
        Me.colIDAlmacen.HeaderText = "IDAlmacen"
        Me.colIDAlmacen.Name = "colIDAlmacen"
        Me.colIDAlmacen.ReadOnly = True
        Me.colIDAlmacen.Visible = False
        Me.colIDAlmacen.Width = 24
        '
        'colAlmacen
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.colAlmacen.DefaultCellStyle = DataGridViewCellStyle1
        Me.colAlmacen.HeaderText = "Almacén"
        Me.colAlmacen.Name = "colAlmacen"
        Me.colAlmacen.ReadOnly = True
        Me.colAlmacen.Width = 180
        '
        'colIdCaja
        '
        Me.colIdCaja.HeaderText = "ID"
        Me.colIdCaja.Name = "colIdCaja"
        Me.colIdCaja.ReadOnly = True
        Me.colIdCaja.Visible = False
        Me.colIdCaja.Width = 25
        '
        'colEF
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.colEF.DefaultCellStyle = DataGridViewCellStyle2
        Me.colEF.HeaderText = "E.F."
        Me.colEF.Name = "colEF"
        Me.colEF.ReadOnly = True
        Me.colEF.Width = 180
        '
        'colEli
        '
        Me.colEli.HeaderText = ""
        Me.colEli.Name = "colEli"
        Me.colEli.ReadOnly = True
        Me.colEli.Width = 25
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.GroupBox1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 25)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1153, 69)
        Me.Panel3.TabIndex = 8
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.cboModulo)
        Me.GroupBox1.Controls.Add(Me.rbSalida)
        Me.GroupBox1.Controls.Add(Me.rbEntrada)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1153, 69)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Módulo"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbProgramado)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.rbManual)
        Me.GroupBox2.Controls.Add(Me.txtSerieConf)
        Me.GroupBox2.Controls.Add(Me.cboComprobant)
        Me.GroupBox2.Location = New System.Drawing.Point(372, 10)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(761, 52)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Configuración comprobante:"
        '
        'rbProgramado
        '
        Me.rbProgramado.Location = New System.Drawing.Point(95, 18)
        Me.rbProgramado.Name = "rbProgramado"
        Me.rbProgramado.Size = New System.Drawing.Size(89, 20)
        Me.rbProgramado.TabIndex = 11
        Me.rbProgramado.Values.Text = "Programada"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(240, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Comprobante:"
        Me.Label6.Visible = False
        '
        'rbManual
        '
        Me.rbManual.Location = New System.Drawing.Point(26, 18)
        Me.rbManual.Name = "rbManual"
        Me.rbManual.Size = New System.Drawing.Size(63, 20)
        Me.rbManual.TabIndex = 10
        Me.rbManual.Values.Text = "Manual"
        '
        'txtSerieConf
        '
        Me.txtSerieConf.Location = New System.Drawing.Point(512, 15)
        Me.txtSerieConf.Name = "txtSerieConf"
        Me.txtSerieConf.Size = New System.Drawing.Size(117, 19)
        Me.txtSerieConf.TabIndex = 5
        Me.txtSerieConf.Visible = False
        '
        'cboComprobant
        '
        Me.cboComprobant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboComprobant.DropDownWidth = 352
        Me.cboComprobant.Location = New System.Drawing.Point(322, 13)
        Me.cboComprobant.Name = "cboComprobant"
        Me.cboComprobant.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue
        Me.cboComprobant.Size = New System.Drawing.Size(188, 21)
        Me.cboComprobant.TabIndex = 9
        Me.cboComprobant.Visible = False
        '
        'cboModulo
        '
        Me.cboModulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboModulo.DropDownWidth = 352
        Me.cboModulo.Location = New System.Drawing.Point(5, 42)
        Me.cboModulo.Name = "cboModulo"
        Me.cboModulo.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2007Blue
        Me.cboModulo.Size = New System.Drawing.Size(352, 21)
        Me.cboModulo.TabIndex = 6
        '
        'rbSalida
        '
        Me.rbSalida.AutoSize = True
        Me.rbSalida.Enabled = False
        Me.rbSalida.Location = New System.Drawing.Point(81, 20)
        Me.rbSalida.Name = "rbSalida"
        Me.rbSalida.Size = New System.Drawing.Size(53, 17)
        Me.rbSalida.TabIndex = 1
        Me.rbSalida.Text = "Sálida"
        Me.rbSalida.UseVisualStyleBackColor = True
        '
        'rbEntrada
        '
        Me.rbEntrada.AutoSize = True
        Me.rbEntrada.Checked = True
        Me.rbEntrada.Enabled = False
        Me.rbEntrada.Location = New System.Drawing.Point(6, 20)
        Me.rbEntrada.Name = "rbEntrada"
        Me.rbEntrada.Size = New System.Drawing.Size(63, 17)
        Me.rbEntrada.TabIndex = 0
        Me.rbEntrada.TabStop = True
        Me.rbEntrada.Text = "Entrada"
        Me.rbEntrada.UseVisualStyleBackColor = True
        '
        'ToolStrip4
        '
        Me.ToolStrip4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip4.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.ToolStripButton4})
        Me.ToolStrip4.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip4.Name = "ToolStrip4"
        Me.ToolStrip4.Size = New System.Drawing.Size(1153, 25)
        Me.ToolStrip4.TabIndex = 6
        Me.ToolStrip4.Text = "ToolStrip4"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(60, 22)
        Me.ToolStripButton4.Text = "&Grabar"
        '
        'KryptonContextMenuHeading2
        '
        Me.KryptonContextMenuHeading2.ExtraText = ""
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'frmConfigSistema
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1169, 621)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.QRibbon1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConfigSistema"
        Me.Text = "SISTEMA"
        CType(Me.QRibbon1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.QRibbon1.ResumeLayout(False)
        CType(Me.QRibbonPage1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.QRibbonPage1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.dgvSeries, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.dgvSerieVenta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.QPanel1.ResumeLayout(False)
        Me.QPanel1.PerformLayout()
        CType(Me.dgvConfiguraciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.cboComprobant, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboModulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip4.ResumeLayout(False)
        Me.ToolStrip4.PerformLayout()
        Me.ResumeLayout(False)

End Sub
    Friend WithEvents QGlobalColorSchemeManager1 As Qios.DevSuite.Components.QGlobalColorSchemeManager
    Friend WithEvents QRibbon1 As Qios.DevSuite.Components.Ribbon.QRibbon
    Friend WithEvents QRibbonPage1 As Qios.DevSuite.Components.Ribbon.QRibbonPage
    Friend WithEvents QRibbonItem1 As Qios.DevSuite.Components.Ribbon.QRibbonItem
    Friend WithEvents QCompositeItem1 As Qios.DevSuite.Components.QCompositeItem
    Friend WithEvents QRibbonItemGroup1 As Qios.DevSuite.Components.Ribbon.QRibbonItemGroup
    Friend WithEvents QRibbonPanel1 As Qios.DevSuite.Components.Ribbon.QRibbonPanel
    Friend WithEvents QRibbonPanel2 As Qios.DevSuite.Components.Ribbon.QRibbonPanel
    Friend WithEvents QRibbonItemGroup2 As Qios.DevSuite.Components.Ribbon.QRibbonItemGroup
    Friend WithEvents QCompositeButton1 As Qios.DevSuite.Components.QCompositeButton
    Friend WithEvents KryptonButton1 As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents QRibbonPanel3 As Qios.DevSuite.Components.Ribbon.QRibbonPanel
    Friend WithEvents QCompositeImage1 As Qios.DevSuite.Components.QCompositeImage
    Friend WithEvents QCompositeSeparator1 As Qios.DevSuite.Components.QCompositeSeparator
    Friend WithEvents QRibbonPanel4 As Qios.DevSuite.Components.Ribbon.QRibbonPanel
    Friend WithEvents QRibbonItem2 As Qios.DevSuite.Components.Ribbon.QRibbonItem
    Friend WithEvents lblCompra As System.Windows.Forms.Label
    Friend WithEvents QRibbonPanel5 As Qios.DevSuite.Components.Ribbon.QRibbonPanel
    Friend WithEvents QRibbonItem3 As Qios.DevSuite.Components.Ribbon.QRibbonItem
    Friend WithEvents lblVenta As System.Windows.Forms.Label
    Friend WithEvents QRibbonPanel6 As Qios.DevSuite.Components.Ribbon.QRibbonPanel
    Friend WithEvents QRibbonItem4 As Qios.DevSuite.Components.Ribbon.QRibbonItem
    Friend WithEvents lblUsuario As System.Windows.Forms.Label
    Friend WithEvents KryptonContextMenu1 As ComponentFactory.Krypton.Toolkit.KryptonContextMenu
    Friend WithEvents KryptonLinkLabel1 As ComponentFactory.Krypton.Toolkit.KryptonLinkLabel
    Friend WithEvents nudMaximo As ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents nudINcremento As ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents nudInicio As ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSerie As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtComprobante As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents GuardarToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents KryptonContextMenuItems1 As ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems
    Friend WithEvents KryptonContextMenuHeading2 As ComponentFactory.Krypton.Toolkit.KryptonContextMenuHeading
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents lblEstado As System.Windows.Forms.ToolStripButton
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents dgvSeries As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents colID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCompC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSerieC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colValInicial As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMAxim As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colElim As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents colEditC As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents lsvSeries As System.Windows.Forms.ListView
    Friend WithEvents colTipD As System.Windows.Forms.ColumnHeader
    Friend WithEvents Colser As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColVal As System.Windows.Forms.ColumnHeader
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dgvSerieVenta As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewButtonColumn1 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents DataGridViewButtonColumn2 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents lsvSerieVenta As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents QRibbonPanel7 As Qios.DevSuite.Components.Ribbon.QRibbonPanel
    Friend WithEvents QRibbonItemGroup3 As Qios.DevSuite.Components.Ribbon.QRibbonItemGroup
    Friend WithEvents QCompositeImage2 As Qios.DevSuite.Components.QCompositeImage
    Friend WithEvents QCompositeItemControl1 As Qios.DevSuite.Components.QCompositeItemControl
    Friend WithEvents QRibbonItem5 As Qios.DevSuite.Components.Ribbon.QRibbonItem
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents QPanel1 As Qios.DevSuite.Components.QPanel
    Friend WithEvents dgvConfiguraciones As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents ToolStrip4 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtSerieConf As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents rbSalida As System.Windows.Forms.RadioButton
    Friend WithEvents rbEntrada As System.Windows.Forms.RadioButton
    Friend WithEvents cboModulo As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents cboComprobant As ComponentFactory.Krypton.Toolkit.KryptonComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbProgramado As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents rbManual As ComponentFactory.Krypton.Toolkit.KryptonRadioButton
    Friend WithEvents coID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colModulo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COLTipoConf As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colComprobante As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSerie As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIDAlmacen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAlmacen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIdCaja As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEF As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEli As System.Windows.Forms.DataGridViewButtonColumn
End Class

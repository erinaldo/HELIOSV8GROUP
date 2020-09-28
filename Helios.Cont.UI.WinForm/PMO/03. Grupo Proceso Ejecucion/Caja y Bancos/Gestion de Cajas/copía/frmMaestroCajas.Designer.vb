<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMaestroCajas
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
        Dim Office2013ColorTable1 As Syncfusion.Windows.Forms.Tools.Office2013ColorTable = New Syncfusion.Windows.Forms.Tools.Office2013ColorTable()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMaestroCajas))
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor6 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor7 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor8 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Me.RibbonControlAdv1 = New Syncfusion.Windows.Forms.Tools.RibbonControlAdv()
        Me.ToolStripTabItem1 = New Syncfusion.Windows.Forms.Tools.ToolStripTabItem()
        Me.ToolStripEx1 = New Syncfusion.Windows.Forms.Tools.ToolStripEx()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripPanelItem1 = New Syncfusion.Windows.Forms.Tools.ToolStripPanelItem()
        Me.btnEditCompra = New System.Windows.Forms.ToolStripButton()
        Me.btnEliminarCompra = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripEx2 = New Syncfusion.Windows.Forms.Tools.ToolStripEx()
        Me.ToolStripPanelItem2 = New Syncfusion.Windows.Forms.Tools.ToolStripPanelItem()
        Me.toolStripPanelItem7 = New Syncfusion.Windows.Forms.Tools.ToolStripPanelItem()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.cboSerie = New System.Windows.Forms.ToolStripComboBox()
        Me.btnBuscarComprobate = New System.Windows.Forms.ToolStripButton()
        Me.toolStripPanelItem8 = New Syncfusion.Windows.Forms.Tools.ToolStripPanelItem()
        Me.btnComprasPeriodo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnComprasDia = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripEx4 = New Syncfusion.Windows.Forms.Tools.ToolStripEx()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripTabItem2 = New Syncfusion.Windows.Forms.Tools.ToolStripTabItem()
        Me.ToolStripEx5 = New Syncfusion.Windows.Forms.Tools.ToolStripEx()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripPanelItem4 = New Syncfusion.Windows.Forms.Tools.ToolStripPanelItem()
        Me.btnEditEF = New System.Windows.Forms.ToolStripButton()
        Me.btnElimibarEF = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripEx6 = New Syncfusion.Windows.Forms.Tools.ToolStripEx()
        Me.ToolStripButton8 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripEx7 = New Syncfusion.Windows.Forms.Tools.ToolStripEx()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton9 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton10 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripEx3 = New Syncfusion.Windows.Forms.Tools.ToolStripEx()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripPanelItem3 = New Syncfusion.Windows.Forms.Tools.ToolStripPanelItem()
        Me.btnVincular = New System.Windows.Forms.ToolStripSplitButton()
        Me.btnDiRecp = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnCompraDirSinRecep = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnCompraCredito = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnVerOrden = New System.Windows.Forms.ToolStripButton()
        Me.DOckingCajas = New Syncfusion.Windows.Forms.Tools.DockingClientPanel()
        Me.tabCajas = New Syncfusion.Windows.Forms.Tools.TabControlAdv()
        Me.TabPageAdv1 = New Syncfusion.Windows.Forms.Tools.TabPageAdv()
        Me.dgvCuentasFinanzas = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.TabPageAdv2 = New Syncfusion.Windows.Forms.Tools.TabPageAdv()
        Me.lsvCajas = New System.Windows.Forms.ListView()
        Me.colIdCaja = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCaja = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTipo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.COLcUENTA = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMoneda = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.QGlobalColorSchemeManager1 = New Qios.DevSuite.Components.QGlobalColorSchemeManager(Me.components)
        Me.dockingManager1 = New Syncfusion.Windows.Forms.Tools.DockingManager(Me.components)
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PanelError = New System.Windows.Forms.Panel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.RibbonControlAdv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RibbonControlAdv1.SuspendLayout()
        Me.ToolStripTabItem1.Panel.SuspendLayout()
        Me.ToolStripEx1.SuspendLayout()
        Me.ToolStripEx2.SuspendLayout()
        Me.ToolStripEx4.SuspendLayout()
        Me.ToolStripTabItem2.Panel.SuspendLayout()
        Me.ToolStripEx5.SuspendLayout()
        Me.ToolStripEx6.SuspendLayout()
        Me.ToolStripEx7.SuspendLayout()
        Me.ToolStripEx3.SuspendLayout()
        Me.DOckingCajas.SuspendLayout()
        CType(Me.tabCajas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabCajas.SuspendLayout()
        Me.TabPageAdv1.SuspendLayout()
        CType(Me.dgvCuentasFinanzas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPageAdv2.SuspendLayout()
        CType(Me.dockingManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelError.SuspendLayout()
        Me.SuspendLayout()
        '
        'RibbonControlAdv1
        '
        Me.RibbonControlAdv1.CaptionFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RibbonControlAdv1.Dock = Syncfusion.Windows.Forms.Tools.DockStyleEx.Top
        Me.RibbonControlAdv1.Header.AddMainItem(ToolStripTabItem1)
        Me.RibbonControlAdv1.Header.AddMainItem(ToolStripTabItem2)
        Me.RibbonControlAdv1.HideMenuButtonToolTip = False
        Me.RibbonControlAdv1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControlAdv1.MaximizeToolTip = "Maximize Ribbon"
        Me.RibbonControlAdv1.MenuButtonEnabled = True
        Me.RibbonControlAdv1.MenuButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RibbonControlAdv1.MenuButtonText = ""
        Me.RibbonControlAdv1.MenuButtonVisible = False
        Me.RibbonControlAdv1.MenuButtonWidth = 56
        Me.RibbonControlAdv1.MenuColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.RibbonControlAdv1.MinimizeToolTip = "Minimize Ribbon"
        Me.RibbonControlAdv1.Name = "RibbonControlAdv1"
        Me.RibbonControlAdv1.Office2013ColorScheme = Syncfusion.Windows.Forms.Tools.Office2013ColorScheme.White
        Office2013ColorTable1.ButtonBackgroundPressed = System.Drawing.Color.Empty
        Office2013ColorTable1.ButtonBackgroundSelected = System.Drawing.Color.Empty
        Office2013ColorTable1.CaptionBackColor = System.Drawing.Color.White
        Office2013ColorTable1.CaptionForeColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer))
        Office2013ColorTable1.CheckedTabColor = System.Drawing.Color.White
        Office2013ColorTable1.CheckedTabForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(198, Byte), Integer))
        Office2013ColorTable1.CloseButtonColor = System.Drawing.Color.Empty
        Office2013ColorTable1.ContextMenuBackColor = System.Drawing.Color.Empty
        Office2013ColorTable1.ContextMenuItemSelected = System.Drawing.Color.Empty
        Office2013ColorTable1.HeaderColor = System.Drawing.Color.White
        Office2013ColorTable1.HoverTabForeColor = System.Drawing.Color.Empty
        Office2013ColorTable1.LauncherBackColorSelected = System.Drawing.Color.Empty
        Office2013ColorTable1.LauncherColorNormal = System.Drawing.Color.Empty
        Office2013ColorTable1.LauncherColorSelected = System.Drawing.Color.Empty
        Office2013ColorTable1.MaximizeButtonColor = System.Drawing.Color.Empty
        Office2013ColorTable1.MinimizeButtonColor = System.Drawing.Color.Empty
        Office2013ColorTable1.PanelBackColor = System.Drawing.Color.White
        Office2013ColorTable1.RestoreButtonColor = System.Drawing.Color.Empty
        Office2013ColorTable1.RibbonPanelBorderColor = System.Drawing.Color.Empty
        Office2013ColorTable1.SelectedTabBorderColor = System.Drawing.Color.White
        Office2013ColorTable1.SelectedTabColor = System.Drawing.Color.White
        Office2013ColorTable1.SplitButtonBackgroundPressed = System.Drawing.Color.Empty
        Office2013ColorTable1.SplitButtonBackgroundSelected = System.Drawing.Color.Empty
        Office2013ColorTable1.SystemButtonBackground = System.Drawing.Color.Empty
        Office2013ColorTable1.TabBackColor = System.Drawing.Color.White
        Office2013ColorTable1.TabForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(2, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer))
        Office2013ColorTable1.TitleColor = System.Drawing.Color.Empty
        Office2013ColorTable1.ToolStripBackColor = System.Drawing.Color.White
        Office2013ColorTable1.ToolStripBorderColor = System.Drawing.Color.White
        Office2013ColorTable1.ToolStripItemForeColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer))
        Office2013ColorTable1.ToolStripSpliterColor = System.Drawing.Color.LightGray
        Office2013ColorTable1.UpDownButtonBackColor = System.Drawing.Color.Empty
        Me.RibbonControlAdv1.Office2013ColorTable = Office2013ColorTable1
        Me.RibbonControlAdv1.OfficeColorScheme = Syncfusion.Windows.Forms.Tools.ToolStripEx.ColorScheme.Silver
        '
        'RibbonControlAdv1.OfficeMenu
        '
        Me.RibbonControlAdv1.OfficeMenu.Name = "OfficeMenu"
        Me.RibbonControlAdv1.OfficeMenu.ShowItemToolTips = True
        Me.RibbonControlAdv1.OfficeMenu.Size = New System.Drawing.Size(12, 65)
        Me.RibbonControlAdv1.OverFlowButtonToolTip = "Show DropDown"
        Me.RibbonControlAdv1.QuickPanelImageLayout = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.RibbonControlAdv1.RibbonHeaderImage = Syncfusion.Windows.Forms.Tools.RibbonHeaderImage.None
        Me.RibbonControlAdv1.RibbonStyle = Syncfusion.Windows.Forms.Tools.RibbonStyle.Office2013
        Me.RibbonControlAdv1.SelectedTab = Me.ToolStripTabItem2
        Me.RibbonControlAdv1.Show2010CustomizeQuickItemDialog = False
        Me.RibbonControlAdv1.ShowRibbonDisplayOptionButton = False
        Me.RibbonControlAdv1.Size = New System.Drawing.Size(895, 142)
        Me.RibbonControlAdv1.SystemText.QuickAccessDialogDropDownName = "Start menu"
        Me.RibbonControlAdv1.TabIndex = 8
        Me.RibbonControlAdv1.Text = "RibbonControlAdv1"
        Me.RibbonControlAdv1.TitleAlignment = Syncfusion.Windows.Forms.Tools.TextAlignment.Center
        Me.RibbonControlAdv1.TitleColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        '
        'ToolStripTabItem1
        '
        Me.ToolStripTabItem1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripTabItem1.Name = "ToolStripTabItem1"
        '
        'RibbonControlAdv1.RibbonPanel1
        '
        Me.ToolStripTabItem1.Panel.Controls.Add(Me.ToolStripEx1)
        Me.ToolStripTabItem1.Panel.Controls.Add(Me.ToolStripEx2)
        Me.ToolStripTabItem1.Panel.Controls.Add(Me.ToolStripEx4)
        Me.ToolStripTabItem1.Panel.Name = "RibbonPanel1"
        Me.ToolStripTabItem1.Panel.ScrollPosition = 0
        Me.ToolStripTabItem1.Panel.TabIndex = 2
        Me.ToolStripTabItem1.Panel.Text = "CAJAS EN USO"
        Me.ToolStripTabItem1.Position = 0
        Me.ToolStripTabItem1.Size = New System.Drawing.Size(101, 25)
        Me.ToolStripTabItem1.Tag = "1"
        Me.ToolStripTabItem1.Text = "CAJAS EN USO"
        '
        'ToolStripEx1
        '
        Me.ToolStripEx1.AutoSize = False
        Me.ToolStripEx1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStripEx1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.ToolStripEx1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStripEx1.Image = Nothing
        Me.ToolStripEx1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton2, Me.ToolStripPanelItem1, Me.ToolStripButton3, Me.ToolStripButton4})
        Me.ToolStripEx1.Location = New System.Drawing.Point(0, 1)
        Me.ToolStripEx1.Name = "ToolStripEx1"
        Me.ToolStripEx1.Office12Mode = False
        Me.ToolStripEx1.Size = New System.Drawing.Size(326, 86)
        Me.ToolStripEx1.TabIndex = 0
        Me.ToolStripEx1.Text = "G e s t i ó n"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(52, 69)
        Me.ToolStripButton2.Text = "Nuevo"
        Me.ToolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripPanelItem1
        '
        Me.ToolStripPanelItem1.CausesValidation = False
        Me.ToolStripPanelItem1.Enabled = False
        Me.ToolStripPanelItem1.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ToolStripPanelItem1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.ToolStripPanelItem1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnEditCompra, Me.btnEliminarCompra})
        Me.ToolStripPanelItem1.Name = "ToolStripPanelItem1"
        Me.ToolStripPanelItem1.Size = New System.Drawing.Size(72, 72)
        Me.ToolStripPanelItem1.Text = "ToolStripPanelItem1"
        Me.ToolStripPanelItem1.Transparent = True
        '
        'btnEditCompra
        '
        Me.btnEditCompra.Enabled = False
        Me.btnEditCompra.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.btnEditCompra.Image = CType(resources.GetObject("btnEditCompra.Image"), System.Drawing.Image)
        Me.btnEditCompra.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEditCompra.Name = "btnEditCompra"
        Me.btnEditCompra.Size = New System.Drawing.Size(57, 20)
        Me.btnEditCompra.Text = "Editar"
        '
        'btnEliminarCompra
        '
        Me.btnEliminarCompra.Enabled = False
        Me.btnEliminarCompra.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.btnEliminarCompra.Image = CType(resources.GetObject("btnEliminarCompra.Image"), System.Drawing.Image)
        Me.btnEliminarCompra.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEliminarCompra.Name = "btnEliminarCompra"
        Me.btnEliminarCompra.Size = New System.Drawing.Size(68, 20)
        Me.btnEliminarCompra.Text = "Eliminar"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(83, 69)
        Me.ToolStripButton3.Text = "Generar cierre"
        Me.ToolStripButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripButton3.ToolTipText = "Generar cierre"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(81, 69)
        Me.ToolStripButton4.Text = "Apertura Caja"
        Me.ToolStripButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripEx2
        '
        Me.ToolStripEx2.AutoSize = False
        Me.ToolStripEx2.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStripEx2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.ToolStripEx2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStripEx2.Image = Nothing
        Me.ToolStripEx2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripPanelItem2})
        Me.ToolStripEx2.Location = New System.Drawing.Point(328, 1)
        Me.ToolStripEx2.Name = "ToolStripEx2"
        Me.ToolStripEx2.Office12Mode = False
        Me.ToolStripEx2.Size = New System.Drawing.Size(290, 86)
        Me.ToolStripEx2.TabIndex = 1
        Me.ToolStripEx2.Text = "C o n s u l t a s"
        '
        'ToolStripPanelItem2
        '
        Me.ToolStripPanelItem2.CausesValidation = False
        Me.ToolStripPanelItem2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.ToolStripPanelItem2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripPanelItem7, Me.toolStripPanelItem8})
        Me.ToolStripPanelItem2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow
        Me.ToolStripPanelItem2.Name = "ToolStripPanelItem2"
        Me.ToolStripPanelItem2.RowCount = 2
        Me.ToolStripPanelItem2.Size = New System.Drawing.Size(272, 72)
        Me.ToolStripPanelItem2.Text = "toolStripPanelItem2"
        Me.ToolStripPanelItem2.Transparent = False
        '
        'toolStripPanelItem7
        '
        Me.toolStripPanelItem7.CausesValidation = False
        Me.toolStripPanelItem7.ForeColor = System.Drawing.Color.MidnightBlue
        Me.toolStripPanelItem7.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.cboSerie, Me.btnBuscarComprobate})
        Me.toolStripPanelItem7.Name = "toolStripPanelItem7"
        Me.toolStripPanelItem7.RowCount = 1
        Me.toolStripPanelItem7.Size = New System.Drawing.Size(157, 27)
        Me.toolStripPanelItem7.Transparent = True
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 4)
        Me.ToolStripLabel1.Size = New System.Drawing.Size(38, 17)
        Me.ToolStripLabel1.Text = "D.N.I.:"
        '
        'cboSerie
        '
        Me.cboSerie.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.cboSerie.Name = "cboSerie"
        Me.cboSerie.Size = New System.Drawing.Size(90, 21)
        '
        'btnBuscarComprobate
        '
        Me.btnBuscarComprobate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnBuscarComprobate.Image = CType(resources.GetObject("btnBuscarComprobate.Image"), System.Drawing.Image)
        Me.btnBuscarComprobate.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnBuscarComprobate.Name = "btnBuscarComprobate"
        Me.btnBuscarComprobate.Size = New System.Drawing.Size(23, 20)
        Me.btnBuscarComprobate.Text = "ToolStripButton3"
        '
        'toolStripPanelItem8
        '
        Me.toolStripPanelItem8.CausesValidation = False
        Me.toolStripPanelItem8.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.toolStripPanelItem8.ForeColor = System.Drawing.Color.MidnightBlue
        Me.toolStripPanelItem8.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnComprasPeriodo, Me.ToolStripSeparator1, Me.btnComprasDia})
        Me.toolStripPanelItem8.Name = "toolStripPanelItem8"
        Me.toolStripPanelItem8.RowCount = 1
        Me.toolStripPanelItem8.Size = New System.Drawing.Size(266, 27)
        Me.toolStripPanelItem8.Text = "toolStripPanelItem4"
        Me.toolStripPanelItem8.Transparent = True
        '
        'btnComprasPeriodo
        '
        Me.btnComprasPeriodo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.btnComprasPeriodo.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.icono_fecha
        Me.btnComprasPeriodo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnComprasPeriodo.Name = "btnComprasPeriodo"
        Me.btnComprasPeriodo.Size = New System.Drawing.Size(140, 20)
        Me.btnComprasPeriodo.Text = "Registro general cajas"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 23)
        '
        'btnComprasDia
        '
        Me.btnComprasDia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.btnComprasDia.Image = CType(resources.GetObject("btnComprasDia.Image"), System.Drawing.Image)
        Me.btnComprasDia.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnComprasDia.Name = "btnComprasDia"
        Me.btnComprasDia.Size = New System.Drawing.Size(116, 20)
        Me.btnComprasDia.Text = "Cajas del Usuario"
        '
        'ToolStripEx4
        '
        Me.ToolStripEx4.AutoSize = False
        Me.ToolStripEx4.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStripEx4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.ToolStripEx4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStripEx4.Image = Nothing
        Me.ToolStripEx4.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton5})
        Me.ToolStripEx4.Location = New System.Drawing.Point(620, 1)
        Me.ToolStripEx4.Name = "ToolStripEx4"
        Me.ToolStripEx4.Office12Mode = False
        Me.ToolStripEx4.Size = New System.Drawing.Size(222, 86)
        Me.ToolStripEx4.TabIndex = 2
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ToolStripButton5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(65, 69)
        Me.ToolStripButton5.Text = "Ver Saldos"
        Me.ToolStripButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripTabItem2
        '
        Me.ToolStripTabItem2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripTabItem2.Name = "ToolStripTabItem2"
        '
        'RibbonControlAdv1.RibbonPanel2
        '
        Me.ToolStripTabItem2.Panel.Controls.Add(Me.ToolStripEx5)
        Me.ToolStripTabItem2.Panel.Controls.Add(Me.ToolStripEx6)
        Me.ToolStripTabItem2.Panel.Name = "RibbonPanel2"
        Me.ToolStripTabItem2.Panel.ScrollPosition = 0
        Me.ToolStripTabItem2.Panel.TabIndex = 3
        Me.ToolStripTabItem2.Panel.Text = "ENTIDAD FINANCIERA"
        Me.ToolStripTabItem2.Position = 1
        Me.ToolStripTabItem2.Size = New System.Drawing.Size(137, 25)
        Me.ToolStripTabItem2.Tag = "2"
        Me.ToolStripTabItem2.Text = "ENTIDAD FINANCIERA"
        '
        'ToolStripEx5
        '
        Me.ToolStripEx5.AutoSize = False
        Me.ToolStripEx5.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStripEx5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.ToolStripEx5.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStripEx5.Image = Nothing
        Me.ToolStripEx5.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton7, Me.ToolStripPanelItem4})
        Me.ToolStripEx5.Location = New System.Drawing.Point(0, 1)
        Me.ToolStripEx5.Name = "ToolStripEx5"
        Me.ToolStripEx5.Office12Mode = False
        Me.ToolStripEx5.Size = New System.Drawing.Size(250, 86)
        Me.ToolStripEx5.TabIndex = 0
        Me.ToolStripEx5.Text = "G e s t i ó n"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.Image = CType(resources.GetObject("ToolStripButton7.Image"), System.Drawing.Image)
        Me.ToolStripButton7.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(130, 69)
        Me.ToolStripButton7.Text = "Nueva Ent. F."
        '
        'ToolStripPanelItem4
        '
        Me.ToolStripPanelItem4.CausesValidation = False
        Me.ToolStripPanelItem4.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ToolStripPanelItem4.ForeColor = System.Drawing.Color.MidnightBlue
        Me.ToolStripPanelItem4.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnEditEF, Me.btnElimibarEF})
        Me.ToolStripPanelItem4.Name = "ToolStripPanelItem4"
        Me.ToolStripPanelItem4.Size = New System.Drawing.Size(72, 72)
        Me.ToolStripPanelItem4.Text = "ToolStripPanelItem1"
        Me.ToolStripPanelItem4.Transparent = True
        '
        'btnEditEF
        '
        Me.btnEditEF.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.btnEditEF.Image = CType(resources.GetObject("btnEditEF.Image"), System.Drawing.Image)
        Me.btnEditEF.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEditEF.Name = "btnEditEF"
        Me.btnEditEF.Size = New System.Drawing.Size(57, 20)
        Me.btnEditEF.Text = "Editar"
        '
        'btnElimibarEF
        '
        Me.btnElimibarEF.Enabled = False
        Me.btnElimibarEF.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.btnElimibarEF.Image = CType(resources.GetObject("btnElimibarEF.Image"), System.Drawing.Image)
        Me.btnElimibarEF.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnElimibarEF.Name = "btnElimibarEF"
        Me.btnElimibarEF.Size = New System.Drawing.Size(68, 20)
        Me.btnElimibarEF.Text = "Eliminar"
        '
        'ToolStripEx6
        '
        Me.ToolStripEx6.AutoSize = False
        Me.ToolStripEx6.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStripEx6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.ToolStripEx6.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStripEx6.Image = Nothing
        Me.ToolStripEx6.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton8})
        Me.ToolStripEx6.Location = New System.Drawing.Point(252, 1)
        Me.ToolStripEx6.Name = "ToolStripEx6"
        Me.ToolStripEx6.Office12Mode = False
        Me.ToolStripEx6.Size = New System.Drawing.Size(177, 86)
        Me.ToolStripEx6.TabIndex = 1
        Me.ToolStripEx6.Text = "L i s t a s"
        '
        'ToolStripButton8
        '
        Me.ToolStripButton8.Image = CType(resources.GetObject("ToolStripButton8.Image"), System.Drawing.Image)
        Me.ToolStripButton8.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton8.Name = "ToolStripButton8"
        Me.ToolStripButton8.Size = New System.Drawing.Size(75, 69)
        Me.ToolStripButton8.Text = "Registro E.F."
        Me.ToolStripButton8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripEx7
        '
        Me.ToolStripEx7.AutoSize = False
        Me.ToolStripEx7.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStripEx7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.ToolStripEx7.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStripEx7.Image = Nothing
        Me.ToolStripEx7.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton6, Me.ToolStripButton9, Me.ToolStripButton10})
        Me.ToolStripEx7.Location = New System.Drawing.Point(0, 1)
        Me.ToolStripEx7.Name = "ToolStripEx7"
        Me.ToolStripEx7.Office12Mode = False
        Me.ToolStripEx7.Size = New System.Drawing.Size(250, 86)
        Me.ToolStripEx7.TabIndex = 0
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ToolStripButton6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ToolStripButton6.Image = CType(resources.GetObject("ToolStripButton6.Image"), System.Drawing.Image)
        Me.ToolStripButton6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(83, 83)
        Me.ToolStripButton6.Text = "Generar cierre"
        Me.ToolStripButton6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripButton9
        '
        Me.ToolStripButton9.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ToolStripButton9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ToolStripButton9.Image = CType(resources.GetObject("ToolStripButton9.Image"), System.Drawing.Image)
        Me.ToolStripButton9.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton9.Name = "ToolStripButton9"
        Me.ToolStripButton9.Size = New System.Drawing.Size(70, 83)
        Me.ToolStripButton9.Text = "Volver abrir"
        Me.ToolStripButton9.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripButton10
        '
        Me.ToolStripButton10.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ToolStripButton10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ToolStripButton10.Image = CType(resources.GetObject("ToolStripButton10.Image"), System.Drawing.Image)
        Me.ToolStripButton10.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton10.Name = "ToolStripButton10"
        Me.ToolStripButton10.Size = New System.Drawing.Size(54, 83)
        Me.ToolStripButton10.Text = "Ver data"
        Me.ToolStripButton10.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripEx3
        '
        Me.ToolStripEx3.AutoSize = False
        Me.ToolStripEx3.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStripEx3.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ToolStripEx3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.ToolStripEx3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStripEx3.Image = Nothing
        Me.ToolStripEx3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripSeparator2, Me.ToolStripPanelItem3})
        Me.ToolStripEx3.Location = New System.Drawing.Point(0, 83)
        Me.ToolStripEx3.Name = "ToolStripEx3"
        Me.ToolStripEx3.Office12Mode = False
        Me.ToolStripEx3.Size = New System.Drawing.Size(250, 0)
        Me.ToolStripEx3.TabIndex = 7
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(88, 0)
        Me.ToolStripButton1.Text = "Ver Aprobados"
        Me.ToolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 0)
        '
        'ToolStripPanelItem3
        '
        Me.ToolStripPanelItem3.CausesValidation = False
        Me.ToolStripPanelItem3.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ToolStripPanelItem3.ForeColor = System.Drawing.Color.MidnightBlue
        Me.ToolStripPanelItem3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnVincular, Me.btnVerOrden})
        Me.ToolStripPanelItem3.Name = "ToolStripPanelItem3"
        Me.ToolStripPanelItem3.Size = New System.Drawing.Size(117, 0)
        Me.ToolStripPanelItem3.Text = "ToolStripPanelItem1"
        Me.ToolStripPanelItem3.Transparent = True
        '
        'btnVincular
        '
        Me.btnVincular.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnDiRecp, Me.btnCompraDirSinRecep, Me.btnCompraCredito})
        Me.btnVincular.Image = CType(resources.GetObject("btnVincular.Image"), System.Drawing.Image)
        Me.btnVincular.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnVincular.Name = "btnVincular"
        Me.btnVincular.Size = New System.Drawing.Size(113, 20)
        Me.btnVincular.Text = "vincular orden"
        '
        'btnDiRecp
        '
        Me.btnDiRecp.Name = "btnDiRecp"
        Me.btnDiRecp.Size = New System.Drawing.Size(183, 22)
        Me.btnDiRecp.Text = "C-Directa s/recepción"
        '
        'btnCompraDirSinRecep
        '
        Me.btnCompraDirSinRecep.Name = "btnCompraDirSinRecep"
        Me.btnCompraDirSinRecep.Size = New System.Drawing.Size(183, 22)
        Me.btnCompraDirSinRecep.Text = "C-Directa c/recepción"
        '
        'btnCompraCredito
        '
        Me.btnCompraCredito.Name = "btnCompraCredito"
        Me.btnCompraCredito.Size = New System.Drawing.Size(183, 22)
        Me.btnCompraCredito.Text = "C-Al crédito"
        '
        'btnVerOrden
        '
        Me.btnVerOrden.Image = CType(resources.GetObject("btnVerOrden.Image"), System.Drawing.Image)
        Me.btnVerOrden.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnVerOrden.Name = "btnVerOrden"
        Me.btnVerOrden.Size = New System.Drawing.Size(80, 20)
        Me.btnVerOrden.Text = "Ver Orden"
        '
        'DOckingCajas
        '
        Me.DOckingCajas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DOckingCajas.Controls.Add(Me.tabCajas)
        Me.DOckingCajas.Location = New System.Drawing.Point(0, 144)
        Me.DOckingCajas.Name = "DOckingCajas"
        Me.DOckingCajas.Size = New System.Drawing.Size(895, 378)
        Me.DOckingCajas.TabIndex = 289
        '
        'tabCajas
        '
        Me.tabCajas.BeforeTouchSize = New System.Drawing.Size(895, 378)
        Me.tabCajas.Controls.Add(Me.TabPageAdv1)
        Me.tabCajas.Controls.Add(Me.TabPageAdv2)
        Me.tabCajas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabCajas.FocusOnTabClick = False
        Me.tabCajas.Location = New System.Drawing.Point(0, 0)
        Me.tabCajas.Name = "tabCajas"
        Me.tabCajas.Size = New System.Drawing.Size(895, 378)
        Me.tabCajas.TabIndex = 213
        Me.tabCajas.TabStyle = GetType(Syncfusion.Windows.Forms.Tools.TabRendererMetro)
        '
        'TabPageAdv1
        '
        Me.TabPageAdv1.Controls.Add(Me.dgvCuentasFinanzas)
        Me.TabPageAdv1.Image = Nothing
        Me.TabPageAdv1.ImageSize = New System.Drawing.Size(16, 16)
        Me.TabPageAdv1.Location = New System.Drawing.Point(1, 22)
        Me.TabPageAdv1.Name = "TabPageAdv1"
        Me.TabPageAdv1.ShowCloseButton = True
        Me.TabPageAdv1.Size = New System.Drawing.Size(892, 354)
        Me.TabPageAdv1.TabIndex = 1
        Me.TabPageAdv1.Text = "Cajas interactivas"
        Me.TabPageAdv1.ThemesEnabled = False
        '
        'dgvCuentasFinanzas
        '
        Me.dgvCuentasFinanzas.BackColor = System.Drawing.SystemColors.Window
        Me.dgvCuentasFinanzas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCuentasFinanzas.FreezeCaption = False
        Me.dgvCuentasFinanzas.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgvCuentasFinanzas.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.dgvCuentasFinanzas.Location = New System.Drawing.Point(0, 0)
        Me.dgvCuentasFinanzas.Name = "dgvCuentasFinanzas"
        Me.dgvCuentasFinanzas.ShowGroupDropArea = True
        Me.dgvCuentasFinanzas.Size = New System.Drawing.Size(892, 354)
        Me.dgvCuentasFinanzas.TabIndex = 212
        Me.dgvCuentasFinanzas.TableDescriptor.AllowNew = False
        Me.dgvCuentasFinanzas.TableDescriptor.Appearance.AnyCell.Font.Facename = "Segoe UI"
        Me.dgvCuentasFinanzas.TableDescriptor.Appearance.AnyCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.dgvCuentasFinanzas.TableDescriptor.Appearance.AnyGroupCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCuentasFinanzas.TableDescriptor.Appearance.AnyGroupCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCuentasFinanzas.TableDescriptor.Appearance.AnyGroupCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer)))
        Me.dgvCuentasFinanzas.TableDescriptor.Appearance.AnyGroupCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.dgvCuentasFinanzas.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCuentasFinanzas.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCuentasFinanzas.TableDescriptor.Appearance.AnySummaryCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCuentasFinanzas.TableDescriptor.Appearance.AnySummaryCell.Borders.Top = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCuentasFinanzas.TableDescriptor.Appearance.AnySummaryCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)))
        Me.dgvCuentasFinanzas.TableDescriptor.Appearance.ColumnHeaderCell.Font.Bold = True
        Me.dgvCuentasFinanzas.TableDescriptor.Appearance.GroupCaptionCell.CellType = "ColumnHeader"
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.HeaderText = "ID"
        GridColumnDescriptor1.MappingName = "idcajaUsuario"
        GridColumnDescriptor1.Name = "idcajaUsuario"
        GridColumnDescriptor1.ReadOnly = True
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor1.Width = 0
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.MappingName = "fechaRegistro"
        GridColumnDescriptor2.Name = "fechaRegistro"
        GridColumnDescriptor2.ReadOnly = True
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor2.Width = 100
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.HeaderText = "Caja Origen"
        GridColumnDescriptor3.MappingName = "NombreCajaOrigen"
        GridColumnDescriptor3.Name = "NombreCajaOrigen"
        GridColumnDescriptor3.ReadOnly = True
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor3.Width = 180
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.HeaderText = "Usuario"
        GridColumnDescriptor4.MappingName = "NombrePersona"
        GridColumnDescriptor4.Name = "NombrePersona"
        GridColumnDescriptor4.ReadOnly = True
        GridColumnDescriptor4.SerializedImageArray = ""
        GridColumnDescriptor4.Width = 180
        GridColumnDescriptor5.HeaderImage = Nothing
        GridColumnDescriptor5.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor5.HeaderText = "Destino"
        GridColumnDescriptor5.MappingName = "NombreCajaDestino"
        GridColumnDescriptor5.Name = "NombreCajaDestino"
        GridColumnDescriptor5.ReadOnly = True
        GridColumnDescriptor5.SerializedImageArray = ""
        GridColumnDescriptor5.Width = 180
        GridColumnDescriptor6.HeaderImage = Nothing
        GridColumnDescriptor6.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor6.HeaderText = "Fondo mn."
        GridColumnDescriptor6.MappingName = "fondoMN"
        GridColumnDescriptor6.Name = "fondoMN"
        GridColumnDescriptor6.ReadOnly = True
        GridColumnDescriptor6.SerializedImageArray = ""
        GridColumnDescriptor7.HeaderImage = Nothing
        GridColumnDescriptor7.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor7.HeaderText = "Fondo me."
        GridColumnDescriptor7.MappingName = "fondoME"
        GridColumnDescriptor7.Name = "fondoME"
        GridColumnDescriptor7.ReadOnly = True
        GridColumnDescriptor7.SerializedImageArray = ""
        GridColumnDescriptor8.HeaderImage = Nothing
        GridColumnDescriptor8.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor8.HeaderText = "Estado"
        GridColumnDescriptor8.MappingName = "estadoCaja"
        GridColumnDescriptor8.Name = "estadoCaja"
        GridColumnDescriptor8.ReadOnly = True
        GridColumnDescriptor8.SerializedImageArray = ""
        GridColumnDescriptor8.Width = 50
        Me.dgvCuentasFinanzas.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7, GridColumnDescriptor8})
        Me.dgvCuentasFinanzas.TableDescriptor.SortedColumns.AddRange(New Syncfusion.Grouping.SortColumnDescriptor() {New Syncfusion.Grouping.SortColumnDescriptor("idcajaUsuario", System.ComponentModel.ListSortDirection.Ascending)})
        Me.dgvCuentasFinanzas.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.dgvCuentasFinanzas.TableDescriptor.TableOptions.RecordRowHeight = 20
        Me.dgvCuentasFinanzas.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("idcajaUsuario"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("fechaRegistro"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("NombreCajaOrigen"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("NombrePersona"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("NombreCajaDestino"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("fondoMN"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("fondoME"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("estadoCaja")})
        Me.dgvCuentasFinanzas.TableOptions.ShowRecordPlusMinus = False
        Me.dgvCuentasFinanzas.TableOptions.ShowTableIndent = False
        Me.dgvCuentasFinanzas.Text = "gridGroupingControl1"
        Me.dgvCuentasFinanzas.TopLevelGroupOptions.ShowAddNewRecordAfterDetails = False
        Me.dgvCuentasFinanzas.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = False
        Me.dgvCuentasFinanzas.TopLevelGroupOptions.ShowColumnHeaders = True
        Me.dgvCuentasFinanzas.TopLevelGroupOptions.ShowStackedHeaders = False
        Me.dgvCuentasFinanzas.TopLevelGroupOptions.ShowSummaries = False
        Me.dgvCuentasFinanzas.VersionInfo = "4.200.0.60"
        '
        'TabPageAdv2
        '
        Me.TabPageAdv2.Controls.Add(Me.lsvCajas)
        Me.TabPageAdv2.Image = Nothing
        Me.TabPageAdv2.ImageSize = New System.Drawing.Size(16, 16)
        Me.TabPageAdv2.Location = New System.Drawing.Point(1, 22)
        Me.TabPageAdv2.Name = "TabPageAdv2"
        Me.TabPageAdv2.ShowCloseButton = True
        Me.TabPageAdv2.Size = New System.Drawing.Size(892, 354)
        Me.TabPageAdv2.TabIndex = 2
        Me.TabPageAdv2.Text = "Entidades financieras"
        Me.TabPageAdv2.ThemesEnabled = False
        '
        'lsvCajas
        '
        Me.lsvCajas.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.lsvCajas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colIdCaja, Me.colCaja, Me.colTipo, Me.COLcUENTA, Me.colMoneda})
        Me.lsvCajas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvCajas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lsvCajas.FullRowSelect = True
        Me.lsvCajas.GridLines = True
        Me.lsvCajas.HideSelection = False
        Me.lsvCajas.Location = New System.Drawing.Point(0, 0)
        Me.lsvCajas.MultiSelect = False
        Me.lsvCajas.Name = "lsvCajas"
        Me.lsvCajas.Size = New System.Drawing.Size(892, 354)
        Me.lsvCajas.TabIndex = 289
        Me.lsvCajas.UseCompatibleStateImageBehavior = False
        Me.lsvCajas.View = System.Windows.Forms.View.Details
        '
        'colIdCaja
        '
        Me.colIdCaja.Text = "ID"
        Me.colIdCaja.Width = 0
        '
        'colCaja
        '
        Me.colCaja.Text = "Caja"
        Me.colCaja.Width = 261
        '
        'colTipo
        '
        Me.colTipo.Text = "Tipo"
        Me.colTipo.Width = 126
        '
        'COLcUENTA
        '
        Me.COLcUENTA.Text = "Cta. contable"
        Me.COLcUENTA.Width = 97
        '
        'colMoneda
        '
        Me.colMoneda.Text = "Moneda"
        Me.colMoneda.Width = 130
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
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.BackColor = System.Drawing.Color.Transparent
        Me.lblEstado.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblEstado.Location = New System.Drawing.Point(9, 4)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(79, 13)
        Me.lblEstado.TabIndex = 0
        Me.lblEstado.Text = "Mensaje error"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(876, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(19, 22)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 288
        Me.PictureBox1.TabStop = False
        '
        'PanelError
        '
        Me.PanelError.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PanelError.Controls.Add(Me.PictureBox1)
        Me.PanelError.Controls.Add(Me.lblEstado)
        Me.PanelError.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelError.Location = New System.Drawing.Point(0, 142)
        Me.PanelError.Name = "PanelError"
        Me.PanelError.Size = New System.Drawing.Size(895, 22)
        Me.PanelError.TabIndex = 290
        Me.PanelError.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'frmMaestroCajas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(895, 524)
        Me.Controls.Add(Me.DOckingCajas)
        Me.Controls.Add(Me.ToolStripEx3)
        Me.Controls.Add(Me.PanelError)
        Me.Controls.Add(Me.RibbonControlAdv1)
        Me.Name = "frmMaestroCajas"
        Me.Text = "Registro de cajas"
        CType(Me.RibbonControlAdv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RibbonControlAdv1.ResumeLayout(False)
        Me.RibbonControlAdv1.PerformLayout()
        Me.ToolStripTabItem1.Panel.ResumeLayout(False)
        Me.ToolStripEx1.ResumeLayout(False)
        Me.ToolStripEx1.PerformLayout()
        Me.ToolStripEx2.ResumeLayout(False)
        Me.ToolStripEx2.PerformLayout()
        Me.ToolStripEx4.ResumeLayout(False)
        Me.ToolStripEx4.PerformLayout()
        Me.ToolStripTabItem2.Panel.ResumeLayout(False)
        Me.ToolStripEx5.ResumeLayout(False)
        Me.ToolStripEx5.PerformLayout()
        Me.ToolStripEx6.ResumeLayout(False)
        Me.ToolStripEx6.PerformLayout()
        Me.ToolStripEx7.ResumeLayout(False)
        Me.ToolStripEx7.PerformLayout()
        Me.ToolStripEx3.ResumeLayout(False)
        Me.ToolStripEx3.PerformLayout()
        Me.DOckingCajas.ResumeLayout(False)
        CType(Me.tabCajas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabCajas.ResumeLayout(False)
        Me.TabPageAdv1.ResumeLayout(False)
        CType(Me.dgvCuentasFinanzas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPageAdv2.ResumeLayout(False)
        CType(Me.dockingManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelError.ResumeLayout(False)
        Me.PanelError.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RibbonControlAdv1 As Syncfusion.Windows.Forms.Tools.RibbonControlAdv
    Friend WithEvents ToolStripTabItem1 As Syncfusion.Windows.Forms.Tools.ToolStripTabItem
    Friend WithEvents ToolStripEx1 As Syncfusion.Windows.Forms.Tools.ToolStripEx
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripEx3 As Syncfusion.Windows.Forms.Tools.ToolStripEx
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripPanelItem3 As Syncfusion.Windows.Forms.Tools.ToolStripPanelItem
    Friend WithEvents btnVincular As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents btnDiRecp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnCompraDirSinRecep As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnCompraCredito As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnVerOrden As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripPanelItem1 As Syncfusion.Windows.Forms.Tools.ToolStripPanelItem
    Friend WithEvents btnEditCompra As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnEliminarCompra As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripEx2 As Syncfusion.Windows.Forms.Tools.ToolStripEx
    Private WithEvents ToolStripPanelItem2 As Syncfusion.Windows.Forms.Tools.ToolStripPanelItem
    Private WithEvents toolStripPanelItem7 As Syncfusion.Windows.Forms.Tools.ToolStripPanelItem
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Private WithEvents cboSerie As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents btnBuscarComprobate As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripPanelItem8 As Syncfusion.Windows.Forms.Tools.ToolStripPanelItem
    Friend WithEvents btnComprasDia As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnComprasPeriodo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents DOckingCajas As Syncfusion.Windows.Forms.Tools.DockingClientPanel
    Private WithEvents QGlobalColorSchemeManager1 As Qios.DevSuite.Components.QGlobalColorSchemeManager
    Private WithEvents dockingManager1 As Syncfusion.Windows.Forms.Tools.DockingManager
    Private WithEvents dgvCuentasFinanzas As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents PanelError As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ToolStripEx4 As Syncfusion.Windows.Forms.Tools.ToolStripEx
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripTabItem2 As Syncfusion.Windows.Forms.Tools.ToolStripTabItem
    Friend WithEvents ToolStripEx5 As Syncfusion.Windows.Forms.Tools.ToolStripEx
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripPanelItem4 As Syncfusion.Windows.Forms.Tools.ToolStripPanelItem
    Friend WithEvents btnEditEF As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnElimibarEF As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripEx6 As Syncfusion.Windows.Forms.Tools.ToolStripEx
    Friend WithEvents ToolStripButton8 As System.Windows.Forms.ToolStripButton
    Friend WithEvents tabCajas As Syncfusion.Windows.Forms.Tools.TabControlAdv
    Friend WithEvents TabPageAdv1 As Syncfusion.Windows.Forms.Tools.TabPageAdv
    Friend WithEvents TabPageAdv2 As Syncfusion.Windows.Forms.Tools.TabPageAdv
    Friend WithEvents lsvCajas As System.Windows.Forms.ListView
    Friend WithEvents colIdCaja As System.Windows.Forms.ColumnHeader
    Friend WithEvents colCaja As System.Windows.Forms.ColumnHeader
    Friend WithEvents colTipo As System.Windows.Forms.ColumnHeader
    Friend WithEvents COLcUENTA As System.Windows.Forms.ColumnHeader
    Friend WithEvents colMoneda As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStripEx7 As Syncfusion.Windows.Forms.Tools.ToolStripEx
    Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton9 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton10 As System.Windows.Forms.ToolStripButton
End Class

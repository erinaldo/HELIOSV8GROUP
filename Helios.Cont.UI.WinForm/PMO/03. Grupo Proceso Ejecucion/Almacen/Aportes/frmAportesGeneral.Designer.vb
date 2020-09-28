<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAportesGeneral
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAportesGeneral))
        Me.RibbonControlAdv1 = New Syncfusion.Windows.Forms.Tools.RibbonControlAdv()
        Me.ToolStripTabItem1 = New Syncfusion.Windows.Forms.Tools.ToolStripTabItem()
        Me.ToolStripEx1 = New Syncfusion.Windows.Forms.Tools.ToolStripEx()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.CompraDirectaConRecepciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripPanelItem1 = New Syncfusion.Windows.Forms.Tools.ToolStripPanelItem()
        Me.btnEditCompra = New System.Windows.Forms.ToolStripButton()
        Me.btnEliminarCompra = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripEx2 = New Syncfusion.Windows.Forms.Tools.ToolStripEx()
        Me.ToolStripPanelItem2 = New Syncfusion.Windows.Forms.Tools.ToolStripPanelItem()
        Me.toolStripPanelItem7 = New Syncfusion.Windows.Forms.Tools.ToolStripPanelItem()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.cboSerie = New System.Windows.Forms.ToolStripComboBox()
        Me.cboNumero = New System.Windows.Forms.ToolStripComboBox()
        Me.btnBuscarComprobate = New System.Windows.Forms.ToolStripButton()
        Me.toolStripPanelItem8 = New Syncfusion.Windows.Forms.Tools.ToolStripPanelItem()
        Me.btnComprasDia = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnComprasPeriodo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripEx3 = New Syncfusion.Windows.Forms.Tools.ToolStripEx()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripPanelItem3 = New Syncfusion.Windows.Forms.Tools.ToolStripPanelItem()
        Me.btnVincular = New System.Windows.Forms.ToolStripSplitButton()
        Me.btnDiRecp = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnCompraDirSinRecep = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnCompraCredito = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnVerOrden = New System.Windows.Forms.ToolStripButton()
        Me.PanelError = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.lsvAportes = New System.Windows.Forms.ListView()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStripTabItem2 = New Syncfusion.Windows.Forms.Tools.ToolStripTabItem()
        Me.ToolStripEx5 = New Syncfusion.Windows.Forms.Tools.ToolStripEx()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        CType(Me.RibbonControlAdv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RibbonControlAdv1.SuspendLayout()
        Me.ToolStripTabItem1.Panel.SuspendLayout()
        Me.ToolStripEx1.SuspendLayout()
        Me.ToolStripEx2.SuspendLayout()
        Me.ToolStripEx3.SuspendLayout()
        Me.PanelError.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStripTabItem2.Panel.SuspendLayout()
        Me.ToolStripEx5.SuspendLayout()
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
        Me.RibbonControlAdv1.TabIndex = 7
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
        Me.ToolStripTabItem1.Panel.Name = "RibbonPanel1"
        Me.ToolStripTabItem1.Panel.ScrollPosition = 0
        Me.ToolStripTabItem1.Panel.TabIndex = 2
        Me.ToolStripTabItem1.Panel.Text = "APORTE"
        Me.ToolStripTabItem1.Position = 0
        Me.ToolStripTabItem1.Size = New System.Drawing.Size(67, 25)
        Me.ToolStripTabItem1.Tag = "1"
        Me.ToolStripTabItem1.Text = "APORTE"
        '
        'ToolStripEx1
        '
        Me.ToolStripEx1.AutoSize = False
        Me.ToolStripEx1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStripEx1.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ToolStripEx1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.ToolStripEx1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStripEx1.Image = Nothing
        Me.ToolStripEx1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripDropDownButton1, Me.ToolStripPanelItem1})
        Me.ToolStripEx1.Location = New System.Drawing.Point(0, 1)
        Me.ToolStripEx1.Name = "ToolStripEx1"
        Me.ToolStripEx1.Office12Mode = False
        Me.ToolStripEx1.Size = New System.Drawing.Size(158, 86)
        Me.ToolStripEx1.TabIndex = 7
        Me.ToolStripEx1.Text = "G e s t i ó n"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CompraDirectaConRecepciónToolStripMenuItem})
        Me.ToolStripDropDownButton1.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.ToolStripDropDownButton1.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.icono_new_documento
        Me.ToolStripDropDownButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(61, 69)
        Me.ToolStripDropDownButton1.Text = "Nuevo"
        Me.ToolStripDropDownButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'CompraDirectaConRecepciónToolStripMenuItem
        '
        Me.CompraDirectaConRecepciónToolStripMenuItem.Name = "CompraDirectaConRecepciónToolStripMenuItem"
        Me.CompraDirectaConRecepciónToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.CompraDirectaConRecepciónToolStripMenuItem.Text = "Aporte de existencia"
        '
        'ToolStripPanelItem1
        '
        Me.ToolStripPanelItem1.CausesValidation = False
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
        Me.btnEditCompra.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.btnEditCompra.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.icono_editar_compra
        Me.btnEditCompra.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEditCompra.Name = "btnEditCompra"
        Me.btnEditCompra.Size = New System.Drawing.Size(57, 20)
        Me.btnEditCompra.Text = "Editar"
        '
        'btnEliminarCompra
        '
        Me.btnEliminarCompra.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.btnEliminarCompra.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.icono_eliminar_compra
        Me.btnEliminarCompra.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEliminarCompra.Name = "btnEliminarCompra"
        Me.btnEliminarCompra.Size = New System.Drawing.Size(68, 20)
        Me.btnEliminarCompra.Text = "Eliminar"
        '
        'ToolStripEx2
        '
        Me.ToolStripEx2.AutoSize = False
        Me.ToolStripEx2.CaptionStyle = Syncfusion.Windows.Forms.Tools.CaptionStyle.Bottom
        Me.ToolStripEx2.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStripEx2.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ToolStripEx2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.ToolStripEx2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStripEx2.Image = Nothing
        Me.ToolStripEx2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripPanelItem2})
        Me.ToolStripEx2.Location = New System.Drawing.Point(160, 1)
        Me.ToolStripEx2.Name = "ToolStripEx2"
        Me.ToolStripEx2.Office12Mode = False
        Me.ToolStripEx2.Size = New System.Drawing.Size(312, 86)
        Me.ToolStripEx2.TabIndex = 6
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
        Me.ToolStripPanelItem2.Size = New System.Drawing.Size(288, 72)
        Me.ToolStripPanelItem2.Text = "toolStripPanelItem2"
        Me.ToolStripPanelItem2.Transparent = False
        '
        'toolStripPanelItem7
        '
        Me.toolStripPanelItem7.CausesValidation = False
        Me.toolStripPanelItem7.ForeColor = System.Drawing.Color.MidnightBlue
        Me.toolStripPanelItem7.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.cboSerie, Me.cboNumero, Me.btnBuscarComprobate})
        Me.toolStripPanelItem7.Name = "toolStripPanelItem7"
        Me.toolStripPanelItem7.RowCount = 1
        Me.toolStripPanelItem7.Size = New System.Drawing.Size(282, 27)
        Me.toolStripPanelItem7.Transparent = True
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 4)
        Me.ToolStripLabel1.Size = New System.Drawing.Size(101, 17)
        Me.ToolStripLabel1.Text = "Nro. comprobante"
        '
        'cboSerie
        '
        Me.cboSerie.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.cboSerie.Name = "cboSerie"
        Me.cboSerie.Size = New System.Drawing.Size(75, 21)
        '
        'cboNumero
        '
        Me.cboNumero.AutoSize = False
        Me.cboNumero.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.cboNumero.Name = "cboNumero"
        Me.cboNumero.Size = New System.Drawing.Size(75, 21)
        '
        'btnBuscarComprobate
        '
        Me.btnBuscarComprobate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnBuscarComprobate.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.icono_buscar_compra
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
        Me.toolStripPanelItem8.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnComprasDia, Me.ToolStripSeparator1, Me.btnComprasPeriodo})
        Me.toolStripPanelItem8.Name = "toolStripPanelItem8"
        Me.toolStripPanelItem8.RowCount = 1
        Me.toolStripPanelItem8.Size = New System.Drawing.Size(247, 27)
        Me.toolStripPanelItem8.Text = "toolStripPanelItem4"
        Me.toolStripPanelItem8.Transparent = True
        '
        'btnComprasDia
        '
        Me.btnComprasDia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.btnComprasDia.Image = CType(resources.GetObject("btnComprasDia.Image"), System.Drawing.Image)
        Me.btnComprasDia.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnComprasDia.Name = "btnComprasDia"
        Me.btnComprasDia.Size = New System.Drawing.Size(105, 20)
        Me.btnComprasDia.Text = "Aportes del día"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 23)
        '
        'btnComprasPeriodo
        '
        Me.btnComprasPeriodo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.btnComprasPeriodo.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.icono_fecha
        Me.btnComprasPeriodo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnComprasPeriodo.Name = "btnComprasPeriodo"
        Me.btnComprasPeriodo.Size = New System.Drawing.Size(132, 20)
        Me.btnComprasPeriodo.Text = "Aportes por período"
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
        Me.ToolStripEx3.Location = New System.Drawing.Point(0, 114)
        Me.ToolStripEx3.Name = "ToolStripEx3"
        Me.ToolStripEx3.Office12Mode = False
        Me.ToolStripEx3.Size = New System.Drawing.Size(250, 0)
        Me.ToolStripEx3.TabIndex = 6
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
        'PanelError
        '
        Me.PanelError.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PanelError.Controls.Add(Me.PictureBox1)
        Me.PanelError.Controls.Add(Me.lblEstado)
        Me.PanelError.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelError.Location = New System.Drawing.Point(0, 142)
        Me.PanelError.Name = "PanelError"
        Me.PanelError.Size = New System.Drawing.Size(895, 22)
        Me.PanelError.TabIndex = 288
        Me.PanelError.Visible = False
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
        'lsvAportes
        '
        Me.lsvAportes.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.lsvAportes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvAportes.FullRowSelect = True
        Me.lsvAportes.GridLines = True
        Me.lsvAportes.HideSelection = False
        Me.lsvAportes.Location = New System.Drawing.Point(0, 164)
        Me.lsvAportes.MultiSelect = False
        Me.lsvAportes.Name = "lsvAportes"
        Me.lsvAportes.Size = New System.Drawing.Size(895, 205)
        Me.lsvAportes.TabIndex = 293
        Me.lsvAportes.UseCompatibleStateImageBehavior = False
        Me.lsvAportes.View = System.Windows.Forms.View.Details
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'ToolStripTabItem2
        '
        Me.ToolStripTabItem2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripTabItem2.Name = "ToolStripTabItem2"
        '
        'RibbonControlAdv1.RibbonPanel2
        '
        Me.ToolStripTabItem2.Panel.Controls.Add(Me.ToolStripEx5)
        Me.ToolStripTabItem2.Panel.Name = "RibbonPanel2"
        Me.ToolStripTabItem2.Panel.ScrollPosition = 0
        Me.ToolStripTabItem2.Panel.TabIndex = 3
        Me.ToolStripTabItem2.Panel.Text = "REPORTE"
        Me.ToolStripTabItem2.Position = 1
        Me.ToolStripTabItem2.Size = New System.Drawing.Size(73, 25)
        Me.ToolStripTabItem2.Tag = "2"
        Me.ToolStripTabItem2.Text = "REPORTE"
        '
        'ToolStripEx5
        '
        Me.ToolStripEx5.AutoSize = False
        Me.ToolStripEx5.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStripEx5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.ToolStripEx5.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStripEx5.Image = Nothing
        Me.ToolStripEx5.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton3, Me.ToolStripButton4})
        Me.ToolStripEx5.Location = New System.Drawing.Point(0, 1)
        Me.ToolStripEx5.Name = "ToolStripEx5"
        Me.ToolStripEx5.Office12Mode = False
        Me.ToolStripEx5.Size = New System.Drawing.Size(243, 86)
        Me.ToolStripEx5.TabIndex = 4
        Me.ToolStripEx5.Text = "C o n s u l t a s"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ToolStripButton3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ToolStripButton3.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.compra_icn
        Me.ToolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(89, 69)
        Me.ToolStripButton3.Text = "Aportes del día"
        Me.ToolStripButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ToolStripButton4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ToolStripButton4.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.icono_fecha
        Me.ToolStripButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(115, 69)
        Me.ToolStripButton4.Text = "Sportes por período"
        Me.ToolStripButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'frmAportesGeneral
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(895, 369)
        Me.Controls.Add(Me.lsvAportes)
        Me.Controls.Add(Me.PanelError)
        Me.Controls.Add(Me.RibbonControlAdv1)
        Me.Controls.Add(Me.ToolStripEx3)
        Me.Name = "frmAportesGeneral"
        Me.Text = "Registro de Aporte de existencias"
        CType(Me.RibbonControlAdv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RibbonControlAdv1.ResumeLayout(False)
        Me.RibbonControlAdv1.PerformLayout()
        Me.ToolStripTabItem1.Panel.ResumeLayout(False)
        Me.ToolStripEx1.ResumeLayout(False)
        Me.ToolStripEx1.PerformLayout()
        Me.ToolStripEx2.ResumeLayout(False)
        Me.ToolStripEx2.PerformLayout()
        Me.ToolStripEx3.ResumeLayout(False)
        Me.ToolStripEx3.PerformLayout()
        Me.PanelError.ResumeLayout(False)
        Me.PanelError.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStripTabItem2.Panel.ResumeLayout(False)
        Me.ToolStripEx5.ResumeLayout(False)
        Me.ToolStripEx5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RibbonControlAdv1 As Syncfusion.Windows.Forms.Tools.RibbonControlAdv
    Friend WithEvents ToolStripEx3 As Syncfusion.Windows.Forms.Tools.ToolStripEx
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripPanelItem3 As Syncfusion.Windows.Forms.Tools.ToolStripPanelItem
    Friend WithEvents btnVincular As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents btnDiRecp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnCompraDirSinRecep As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnCompraCredito As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnVerOrden As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripTabItem1 As Syncfusion.Windows.Forms.Tools.ToolStripTabItem
    Friend WithEvents ToolStripEx1 As Syncfusion.Windows.Forms.Tools.ToolStripEx
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents CompraDirectaConRecepciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripPanelItem1 As Syncfusion.Windows.Forms.Tools.ToolStripPanelItem
    Friend WithEvents btnEditCompra As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnEliminarCompra As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripEx2 As Syncfusion.Windows.Forms.Tools.ToolStripEx
    Private WithEvents ToolStripPanelItem2 As Syncfusion.Windows.Forms.Tools.ToolStripPanelItem
    Private WithEvents toolStripPanelItem7 As Syncfusion.Windows.Forms.Tools.ToolStripPanelItem
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Private WithEvents cboSerie As System.Windows.Forms.ToolStripComboBox
    Private WithEvents cboNumero As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents btnBuscarComprobate As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripPanelItem8 As Syncfusion.Windows.Forms.Tools.ToolStripPanelItem
    Friend WithEvents btnComprasDia As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnComprasPeriodo As System.Windows.Forms.ToolStripButton
    Friend WithEvents PanelError As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents lsvAportes As System.Windows.Forms.ListView
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ToolStripTabItem2 As Syncfusion.Windows.Forms.Tools.ToolStripTabItem
    Friend WithEvents ToolStripEx5 As Syncfusion.Windows.Forms.Tools.ToolStripEx
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
End Class

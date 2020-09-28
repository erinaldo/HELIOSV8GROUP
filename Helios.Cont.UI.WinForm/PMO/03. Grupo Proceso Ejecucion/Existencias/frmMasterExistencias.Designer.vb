<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExistencias
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmExistencias))
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
        Me.RibbonControlAdv1 = New Syncfusion.Windows.Forms.Tools.RibbonControlAdv()
        Me.ToolStripTabItem = New Syncfusion.Windows.Forms.Tools.ToolStripTabItem()
        Me.ToolStripEx1 = New Syncfusion.Windows.Forms.Tools.ToolStripEx()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.CompraDirectaConRecepciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExistenciasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripPanelItem1 = New Syncfusion.Windows.Forms.Tools.ToolStripPanelItem()
        Me.btnEditCompra = New System.Windows.Forms.ToolStripButton()
        Me.btnEliminarCompra = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripEx2 = New Syncfusion.Windows.Forms.Tools.ToolStripEx()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.txtBuscarClasif = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripTabItem1 = New Syncfusion.Windows.Forms.Tools.ToolStripTabItem()
        Me.DockingManager1 = New Syncfusion.Windows.Forms.Tools.DockingManager(Me.components)
        Me.PanelNuevoItem = New System.Windows.Forms.Panel()
        Me.btnAgregarClasificacion = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.nudPorcentajeTributo = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.txtFechaComprobante = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.txtClasificacion = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.panelDetalleItems = New System.Windows.Forms.Panel()
        Me.dgvDetalleItems = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.panel15 = New System.Windows.Forms.Panel()
        Me.GradientLabel1 = New Syncfusion.Windows.Forms.Tools.GradientLabel()
        Me.panelNuevoDetalleItem = New System.Windows.Forms.Panel()
        Me.txtExisClasificacion = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCodigoCuenta = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCuenta = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTipoExitencia = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPresentacion = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.txtUnidad = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtExistencia = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.txtCodigoUnidad = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.txtCodigoPresentación = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.txtCodigoTExistencia = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgvCompra = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.DockingClientPanel1 = New Syncfusion.Windows.Forms.Tools.DockingClientPanel()
        CType(Me.RibbonControlAdv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RibbonControlAdv1.SuspendLayout()
        Me.ToolStripTabItem.Panel.SuspendLayout()
        Me.ToolStripEx1.SuspendLayout()
        Me.ToolStripEx2.SuspendLayout()
        CType(Me.DockingManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelNuevoItem.SuspendLayout()
        CType(Me.nudPorcentajeTributo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaComprobante.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelDetalleItems.SuspendLayout()
        CType(Me.dgvDetalleItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel15.SuspendLayout()
        Me.panelNuevoDetalleItem.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DockingClientPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'RibbonControlAdv1
        '
        Me.RibbonControlAdv1.CaptionFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RibbonControlAdv1.Dock = Syncfusion.Windows.Forms.Tools.DockStyleEx.Top
        Me.RibbonControlAdv1.Header.AddMainItem(ToolStripTabItem)
        Me.RibbonControlAdv1.Header.AddMainItem(ToolStripTabItem1)
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
        Me.RibbonControlAdv1.SelectedTab = Me.ToolStripTabItem
        Me.RibbonControlAdv1.Show2010CustomizeQuickItemDialog = False
        Me.RibbonControlAdv1.ShowRibbonDisplayOptionButton = False
        Me.RibbonControlAdv1.Size = New System.Drawing.Size(863, 142)
        Me.RibbonControlAdv1.SystemText.QuickAccessDialogDropDownName = "Start menu"
        Me.RibbonControlAdv1.TabIndex = 8
        Me.RibbonControlAdv1.Text = "RibbonControlAdv1"
        Me.RibbonControlAdv1.TitleAlignment = Syncfusion.Windows.Forms.Tools.TextAlignment.Center
        Me.RibbonControlAdv1.TitleColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        '
        'ToolStripTabItem
        '
        Me.ToolStripTabItem.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripTabItem.Name = "ToolStripTabItem"
        '
        'RibbonControlAdv1.RibbonPanel1
        '
        Me.ToolStripTabItem.Panel.Controls.Add(Me.ToolStripEx1)
        Me.ToolStripTabItem.Panel.Controls.Add(Me.ToolStripEx2)
        Me.ToolStripTabItem.Panel.Name = "RibbonPanel1"
        Me.ToolStripTabItem.Panel.ScrollPosition = 0
        Me.ToolStripTabItem.Panel.TabIndex = 2
        Me.ToolStripTabItem.Panel.Text = "Existencias"
        Me.ToolStripTabItem.Position = 0
        Me.ToolStripTabItem.Size = New System.Drawing.Size(82, 25)
        Me.ToolStripTabItem.Tag = "1"
        Me.ToolStripTabItem.Text = "Existencias"
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
        Me.ToolStripEx1.Size = New System.Drawing.Size(189, 86)
        Me.ToolStripEx1.TabIndex = 12
        Me.ToolStripEx1.Text = "G e s t i ó n"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CompraDirectaConRecepciónToolStripMenuItem, Me.ExistenciasToolStripMenuItem})
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
        Me.CompraDirectaConRecepciónToolStripMenuItem.BackColor = System.Drawing.SystemColors.Info
        Me.CompraDirectaConRecepciónToolStripMenuItem.Name = "CompraDirectaConRecepciónToolStripMenuItem"
        Me.CompraDirectaConRecepciónToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.CompraDirectaConRecepciónToolStripMenuItem.Text = "Clasificación"
        '
        'ExistenciasToolStripMenuItem
        '
        Me.ExistenciasToolStripMenuItem.Name = "ExistenciasToolStripMenuItem"
        Me.ExistenciasToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ExistenciasToolStripMenuItem.Text = "Existencias"
        '
        'ToolStripPanelItem1
        '
        Me.ToolStripPanelItem1.CausesValidation = False
        Me.ToolStripPanelItem1.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ToolStripPanelItem1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.ToolStripPanelItem1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnEditCompra, Me.btnEliminarCompra})
        Me.ToolStripPanelItem1.Name = "ToolStripPanelItem1"
        Me.ToolStripPanelItem1.Size = New System.Drawing.Size(95, 72)
        Me.ToolStripPanelItem1.Text = "ToolStripPanelItem1"
        Me.ToolStripPanelItem1.Transparent = True
        '
        'btnEditCompra
        '
        Me.btnEditCompra.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.btnEditCompra.Image = CType(resources.GetObject("btnEditCompra.Image"), System.Drawing.Image)
        Me.btnEditCompra.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEditCompra.Name = "btnEditCompra"
        Me.btnEditCompra.Size = New System.Drawing.Size(91, 20)
        Me.btnEditCompra.Text = "Clasificación"
        '
        'btnEliminarCompra
        '
        Me.btnEliminarCompra.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.btnEliminarCompra.Image = CType(resources.GetObject("btnEliminarCompra.Image"), System.Drawing.Image)
        Me.btnEliminarCompra.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEliminarCompra.Name = "btnEliminarCompra"
        Me.btnEliminarCompra.Size = New System.Drawing.Size(82, 20)
        Me.btnEliminarCompra.Text = "Existencias"
        '
        'ToolStripEx2
        '
        Me.ToolStripEx2.AutoSize = False
        Me.ToolStripEx2.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStripEx2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.ToolStripEx2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStripEx2.Image = Nothing
        Me.ToolStripEx2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton2, Me.txtBuscarClasif})
        Me.ToolStripEx2.Location = New System.Drawing.Point(191, 1)
        Me.ToolStripEx2.Name = "ToolStripEx2"
        Me.ToolStripEx2.Office12Mode = False
        Me.ToolStripEx2.Size = New System.Drawing.Size(296, 86)
        Me.ToolStripEx2.TabIndex = 11
        Me.ToolStripEx2.Text = "C o n s u l t a s"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ToolStripButton2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ToolStripButton2.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources._0021
        Me.ToolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(106, 69)
        Me.ToolStripButton2.Text = "Existencias"
        '
        'txtBuscarClasif
        '
        Me.txtBuscarClasif.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBuscarClasif.Name = "txtBuscarClasif"
        Me.txtBuscarClasif.Size = New System.Drawing.Size(150, 72)
        '
        'ToolStripTabItem1
        '
        Me.ToolStripTabItem1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripTabItem1.Name = "ToolStripTabItem1"
        '
        'RibbonControlAdv1.RibbonPanel2
        '
        Me.ToolStripTabItem1.Panel.Name = "RibbonPanel2"
        Me.ToolStripTabItem1.Panel.ScrollPosition = 0
        Me.ToolStripTabItem1.Panel.TabIndex = 3
        Me.ToolStripTabItem1.Panel.Text = "Reporte"
        Me.ToolStripTabItem1.Position = 1
        Me.ToolStripTabItem1.Size = New System.Drawing.Size(68, 25)
        Me.ToolStripTabItem1.Tag = "1"
        Me.ToolStripTabItem1.Text = "Reporte"
        '
        'DockingManager1
        '
        Me.DockingManager1.ActiveCaptionFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.DockingManager1.AutoHideTabFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.DockingManager1.DockLayoutStream = CType(resources.GetObject("DockingManager1.DockLayoutStream"), System.IO.MemoryStream)
        Me.DockingManager1.DockTabFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.DockingManager1.HostControl = Me
        Me.DockingManager1.InActiveCaptionFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.DockingManager1.MetroButtonColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DockingManager1.MetroCaptionColor = System.Drawing.Color.White
        Me.DockingManager1.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DockingManager1.MetroSplitterBackColor = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.DockingManager1.ReduceFlickeringInRtl = False
        Me.DockingManager1.CaptionButtons.Add(New Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Close, "CloseButton"))
        Me.DockingManager1.CaptionButtons.Add(New Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Pin, "PinButton"))
        Me.DockingManager1.CaptionButtons.Add(New Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Maximize, "MaximizeButton"))
        Me.DockingManager1.CaptionButtons.Add(New Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Restore, "RestoreButton"))
        Me.DockingManager1.CaptionButtons.Add(New Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Menu, "MenuButton"))
        '
        'PanelNuevoItem
        '
        Me.PanelNuevoItem.Controls.Add(Me.btnAgregarClasificacion)
        Me.PanelNuevoItem.Controls.Add(Me.Label22)
        Me.PanelNuevoItem.Controls.Add(Me.nudPorcentajeTributo)
        Me.PanelNuevoItem.Controls.Add(Me.txtFechaComprobante)
        Me.PanelNuevoItem.Controls.Add(Me.txtClasificacion)
        Me.PanelNuevoItem.Controls.Add(Me.Label4)
        Me.PanelNuevoItem.Controls.Add(Me.Label1)
        Me.PanelNuevoItem.Location = New System.Drawing.Point(217, 3)
        Me.PanelNuevoItem.Name = "PanelNuevoItem"
        Me.PanelNuevoItem.Size = New System.Drawing.Size(270, 103)
        Me.PanelNuevoItem.TabIndex = 292
        '
        'btnAgregarClasificacion
        '
        Me.btnAgregarClasificacion.BeforeTouchSize = New System.Drawing.Size(87, 20)
        Me.btnAgregarClasificacion.IsBackStageButton = False
        Me.btnAgregarClasificacion.Location = New System.Drawing.Point(176, 82)
        Me.btnAgregarClasificacion.Name = "btnAgregarClasificacion"
        Me.btnAgregarClasificacion.Size = New System.Drawing.Size(87, 20)
        Me.btnAgregarClasificacion.TabIndex = 405
        Me.btnAgregarClasificacion.Text = "Grabar"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.Location = New System.Drawing.Point(14, 63)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(60, 13)
        Me.Label22.TabIndex = 404
        Me.Label22.Text = "Utilidad %:"
        '
        'nudPorcentajeTributo
        '
        Me.nudPorcentajeTributo.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.nudPorcentajeTributo.BeforeTouchSize = New System.Drawing.Size(51, 20)
        Me.nudPorcentajeTributo.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.nudPorcentajeTributo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nudPorcentajeTributo.DecimalPlaces = 2
        Me.nudPorcentajeTributo.Location = New System.Drawing.Point(82, 56)
        Me.nudPorcentajeTributo.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.nudPorcentajeTributo.Name = "nudPorcentajeTributo"
        Me.nudPorcentajeTributo.Size = New System.Drawing.Size(51, 20)
        Me.nudPorcentajeTributo.TabIndex = 403
        Me.nudPorcentajeTributo.ThousandsSeparator = True
        Me.nudPorcentajeTributo.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
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
        Me.txtFechaComprobante.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaComprobante.Location = New System.Drawing.Point(82, 5)
        Me.txtFechaComprobante.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaComprobante.MinValue = New Date(CType(0, Long))
        Me.txtFechaComprobante.Name = "txtFechaComprobante"
        Me.txtFechaComprobante.ShowCheckBox = False
        Me.txtFechaComprobante.Size = New System.Drawing.Size(181, 20)
        Me.txtFechaComprobante.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaComprobante.TabIndex = 402
        Me.txtFechaComprobante.Value = New Date(2015, 9, 7, 12, 12, 25, 172)
        '
        'txtClasificacion
        '
        Me.txtClasificacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtClasificacion.Location = New System.Drawing.Point(82, 31)
        Me.txtClasificacion.MaxLength = 10000000
        Me.txtClasificacion.Name = "txtClasificacion"
        Me.txtClasificacion.Size = New System.Drawing.Size(181, 19)
        Me.txtClasificacion.TabIndex = 401
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(5, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 13)
        Me.Label4.TabIndex = 400
        Me.Label4.Text = "Clasificación:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(32, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 399
        Me.Label1.Text = "Fecha:"
        '
        'panelDetalleItems
        '
        Me.panelDetalleItems.Controls.Add(Me.dgvDetalleItems)
        Me.panelDetalleItems.Controls.Add(Me.panel15)
        Me.panelDetalleItems.Controls.Add(Me.PanelNuevoItem)
        Me.panelDetalleItems.Controls.Add(Me.panelNuevoDetalleItem)
        Me.panelDetalleItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelDetalleItems.Location = New System.Drawing.Point(390, 0)
        Me.panelDetalleItems.Name = "panelDetalleItems"
        Me.panelDetalleItems.Size = New System.Drawing.Size(473, 252)
        Me.panelDetalleItems.TabIndex = 293
        '
        'dgvDetalleItems
        '
        Me.dgvDetalleItems.BackColor = System.Drawing.SystemColors.Window
        Me.dgvDetalleItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDetalleItems.FreezeCaption = False
        Me.dgvDetalleItems.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgvDetalleItems.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2010Blue
        Me.dgvDetalleItems.Location = New System.Drawing.Point(22, 0)
        Me.dgvDetalleItems.Name = "dgvDetalleItems"
        Me.dgvDetalleItems.Size = New System.Drawing.Size(451, 252)
        Me.dgvDetalleItems.TabIndex = 199
        Me.dgvDetalleItems.TableDescriptor.AllowNew = False
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.MappingName = "codigoDetalle"
        GridColumnDescriptor1.Name = "codigoDetalle"
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.MappingName = "idItem"
        GridColumnDescriptor2.Name = "idItem"
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.MappingName = "cuenta"
        GridColumnDescriptor3.Name = "cuenta"
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.HeaderText = "Descripción"
        GridColumnDescriptor4.MappingName = "descripcionItem"
        GridColumnDescriptor4.Name = "descripcionItem"
        GridColumnDescriptor4.SerializedImageArray = ""
        GridColumnDescriptor4.Width = 250
        GridColumnDescriptor5.HeaderImage = Nothing
        GridColumnDescriptor5.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor5.MappingName = "presentación"
        GridColumnDescriptor5.Name = "presentación"
        GridColumnDescriptor5.SerializedImageArray = ""
        GridColumnDescriptor6.HeaderImage = Nothing
        GridColumnDescriptor6.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor6.MappingName = "unidad"
        GridColumnDescriptor6.Name = "unidad"
        GridColumnDescriptor6.SerializedImageArray = ""
        GridColumnDescriptor7.HeaderImage = Nothing
        GridColumnDescriptor7.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor7.HeaderText = "Tipo existencia"
        GridColumnDescriptor7.MappingName = "tipoExistencia"
        GridColumnDescriptor7.Name = "tipoExistencia"
        GridColumnDescriptor7.SerializedImageArray = ""
        GridColumnDescriptor7.Width = 150
        Me.dgvDetalleItems.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7})
        Me.dgvDetalleItems.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.dgvDetalleItems.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.dgvDetalleItems.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("descripcionItem"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipoExistencia")})
        Me.dgvDetalleItems.Text = "GridGroupingControl1"
        Me.dgvDetalleItems.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = False
        Me.dgvDetalleItems.VersionInfo = "12.4400.0.24"
        '
        'panel15
        '
        Me.panel15.BackColor = System.Drawing.Color.Transparent
        Me.panel15.BackgroundImage = CType(resources.GetObject("panel15.BackgroundImage"), System.Drawing.Image)
        Me.panel15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.panel15.Controls.Add(Me.GradientLabel1)
        Me.panel15.Dock = System.Windows.Forms.DockStyle.Left
        Me.panel15.Location = New System.Drawing.Point(0, 0)
        Me.panel15.Name = "panel15"
        Me.panel15.Size = New System.Drawing.Size(22, 252)
        Me.panel15.TabIndex = 198
        '
        'GradientLabel1
        '
        Me.GradientLabel1.AutoEllipsis = True
        Me.GradientLabel1.BackgroundColor = New Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.None, System.Drawing.Color.Transparent, System.Drawing.Color.Transparent)
        Me.GradientLabel1.BeforeTouchSize = New System.Drawing.Size(14, 207)
        Me.GradientLabel1.BorderAppearance = System.Windows.Forms.BorderStyle.None
        Me.GradientLabel1.BorderSides = CType((((System.Windows.Forms.Border3DSide.Left Or System.Windows.Forms.Border3DSide.Top) _
            Or System.Windows.Forms.Border3DSide.Right) _
            Or System.Windows.Forms.Border3DSide.Bottom), System.Windows.Forms.Border3DSide)
        Me.GradientLabel1.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GradientLabel1.Location = New System.Drawing.Point(4, 7)
        Me.GradientLabel1.Name = "GradientLabel1"
        Me.GradientLabel1.Size = New System.Drawing.Size(14, 207)
        Me.GradientLabel1.TabIndex = 200
        Me.GradientLabel1.Text = "EXISTENCIAS"
        Me.GradientLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'panelNuevoDetalleItem
        '
        Me.panelNuevoDetalleItem.Controls.Add(Me.txtExisClasificacion)
        Me.panelNuevoDetalleItem.Controls.Add(Me.Label2)
        Me.panelNuevoDetalleItem.Controls.Add(Me.txtCodigoCuenta)
        Me.panelNuevoDetalleItem.Controls.Add(Me.Label7)
        Me.panelNuevoDetalleItem.Controls.Add(Me.txtCuenta)
        Me.panelNuevoDetalleItem.Controls.Add(Me.Label3)
        Me.panelNuevoDetalleItem.Controls.Add(Me.txtTipoExitencia)
        Me.panelNuevoDetalleItem.Controls.Add(Me.Label8)
        Me.panelNuevoDetalleItem.Controls.Add(Me.txtPresentacion)
        Me.panelNuevoDetalleItem.Controls.Add(Me.txtUnidad)
        Me.panelNuevoDetalleItem.Controls.Add(Me.Label6)
        Me.panelNuevoDetalleItem.Controls.Add(Me.txtExistencia)
        Me.panelNuevoDetalleItem.Controls.Add(Me.Label5)
        Me.panelNuevoDetalleItem.Controls.Add(Me.ButtonAdv1)
        Me.panelNuevoDetalleItem.Controls.Add(Me.txtCodigoUnidad)
        Me.panelNuevoDetalleItem.Controls.Add(Me.txtCodigoPresentación)
        Me.panelNuevoDetalleItem.Controls.Add(Me.txtCodigoTExistencia)
        Me.panelNuevoDetalleItem.Location = New System.Drawing.Point(113, 75)
        Me.panelNuevoDetalleItem.Name = "panelNuevoDetalleItem"
        Me.panelNuevoDetalleItem.Size = New System.Drawing.Size(324, 167)
        Me.panelNuevoDetalleItem.TabIndex = 295
        '
        'txtExisClasificacion
        '
        Me.txtExisClasificacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtExisClasificacion.Location = New System.Drawing.Point(92, 3)
        Me.txtExisClasificacion.MaxLength = 5
        Me.txtExisClasificacion.Name = "txtExisClasificacion"
        Me.txtExisClasificacion.ReadOnly = True
        Me.txtExisClasificacion.Size = New System.Drawing.Size(188, 19)
        Me.txtExisClasificacion.TabIndex = 430
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(21, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 429
        Me.Label2.Text = "Clasificación"
        '
        'txtCodigoCuenta
        '
        Me.txtCodigoCuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoCuenta.Location = New System.Drawing.Point(92, 126)
        Me.txtCodigoCuenta.Name = "txtCodigoCuenta"
        Me.txtCodigoCuenta.ReadOnly = True
        Me.txtCodigoCuenta.Size = New System.Drawing.Size(44, 19)
        Me.txtCodigoCuenta.TabIndex = 427
        Me.txtCodigoCuenta.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(42, 129)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 13)
        Me.Label7.TabIndex = 426
        Me.Label7.Text = "Cuenta"
        Me.Label7.Visible = False
        '
        'txtCuenta
        '
        Me.txtCuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCuenta.Location = New System.Drawing.Point(142, 126)
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.ReadOnly = True
        Me.txtCuenta.Size = New System.Drawing.Size(138, 19)
        Me.txtCuenta.TabIndex = 425
        Me.txtCuenta.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(8, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 13)
        Me.Label3.TabIndex = 422
        Me.Label3.Text = "Tipo existencia:"
        '
        'txtTipoExitencia
        '
        Me.txtTipoExitencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTipoExitencia.Location = New System.Drawing.Point(92, 101)
        Me.txtTipoExitencia.Name = "txtTipoExitencia"
        Me.txtTipoExitencia.ReadOnly = True
        Me.txtTipoExitencia.Size = New System.Drawing.Size(166, 19)
        Me.txtTipoExitencia.TabIndex = 421
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(13, 79)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 13)
        Me.Label8.TabIndex = 420
        Me.Label8.Text = "Presentación:"
        '
        'txtPresentacion
        '
        Me.txtPresentacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPresentacion.Location = New System.Drawing.Point(92, 76)
        Me.txtPresentacion.Name = "txtPresentacion"
        Me.txtPresentacion.ReadOnly = True
        Me.txtPresentacion.Size = New System.Drawing.Size(166, 19)
        Me.txtPresentacion.TabIndex = 419
        '
        'txtUnidad
        '
        Me.txtUnidad.Location = New System.Drawing.Point(92, 51)
        Me.txtUnidad.MaxLength = 5
        Me.txtUnidad.Name = "txtUnidad"
        Me.txtUnidad.ReadOnly = True
        Me.txtUnidad.Size = New System.Drawing.Size(126, 19)
        Me.txtUnidad.TabIndex = 418
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(42, 54)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 13)
        Me.Label6.TabIndex = 417
        Me.Label6.Text = "Unidad:"
        '
        'txtExistencia
        '
        Me.txtExistencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtExistencia.Location = New System.Drawing.Point(92, 26)
        Me.txtExistencia.MaxLength = 100000000
        Me.txtExistencia.Name = "txtExistencia"
        Me.txtExistencia.Size = New System.Drawing.Size(188, 19)
        Me.txtExistencia.TabIndex = 416
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(36, 29)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 13)
        Me.Label5.TabIndex = 415
        Me.Label5.Text = "Nombre:"
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(87, 20)
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(193, 151)
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(87, 20)
        Me.ButtonAdv1.TabIndex = 405
        Me.ButtonAdv1.Text = "Grabar"
        '
        'txtCodigoUnidad
        '
        Me.txtCodigoUnidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoUnidad.Location = New System.Drawing.Point(92, 51)
        Me.txtCodigoUnidad.Name = "txtCodigoUnidad"
        Me.txtCodigoUnidad.Size = New System.Drawing.Size(33, 19)
        Me.txtCodigoUnidad.TabIndex = 424
        Me.txtCodigoUnidad.Visible = False
        '
        'txtCodigoPresentación
        '
        Me.txtCodigoPresentación.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoPresentación.Location = New System.Drawing.Point(92, 76)
        Me.txtCodigoPresentación.Name = "txtCodigoPresentación"
        Me.txtCodigoPresentación.Size = New System.Drawing.Size(33, 19)
        Me.txtCodigoPresentación.TabIndex = 423
        Me.txtCodigoPresentación.Visible = False
        '
        'txtCodigoTExistencia
        '
        Me.txtCodigoTExistencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoTExistencia.Location = New System.Drawing.Point(92, 101)
        Me.txtCodigoTExistencia.Name = "txtCodigoTExistencia"
        Me.txtCodigoTExistencia.Size = New System.Drawing.Size(33, 19)
        Me.txtCodigoTExistencia.TabIndex = 428
        Me.txtCodigoTExistencia.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dgvCompra)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(390, 252)
        Me.Panel1.TabIndex = 294
        '
        'dgvCompra
        '
        Me.dgvCompra.BackColor = System.Drawing.SystemColors.Window
        Me.dgvCompra.Dock = System.Windows.Forms.DockStyle.Left
        Me.dgvCompra.FreezeCaption = False
        Me.dgvCompra.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgvCompra.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2010Blue
        Me.dgvCompra.Location = New System.Drawing.Point(0, 0)
        Me.dgvCompra.Name = "dgvCompra"
        Me.dgvCompra.Size = New System.Drawing.Size(389, 252)
        Me.dgvCompra.TabIndex = 296
        Me.dgvCompra.TableDescriptor.AllowNew = False
        GridColumnDescriptor8.HeaderImage = Nothing
        GridColumnDescriptor8.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor8.MappingName = "idItem"
        GridColumnDescriptor8.Name = "idItem"
        GridColumnDescriptor8.SerializedImageArray = ""
        GridColumnDescriptor9.HeaderImage = Nothing
        GridColumnDescriptor9.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor9.HeaderText = "Descripción"
        GridColumnDescriptor9.MappingName = "descripcion"
        GridColumnDescriptor9.Name = "descripcion"
        GridColumnDescriptor9.SerializedImageArray = ""
        GridColumnDescriptor9.Width = 250
        GridColumnDescriptor10.HeaderImage = Nothing
        GridColumnDescriptor10.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor10.HeaderText = "% Utilidad"
        GridColumnDescriptor10.MappingName = "utilidad"
        GridColumnDescriptor10.Name = "utilidad"
        GridColumnDescriptor10.SerializedImageArray = ""
        GridColumnDescriptor10.Width = 100
        GridColumnDescriptor11.HeaderImage = Nothing
        GridColumnDescriptor11.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor11.MappingName = "fechaIngreso"
        GridColumnDescriptor11.Name = "fechaIngreso"
        GridColumnDescriptor11.SerializedImageArray = ""
        GridColumnDescriptor12.HeaderImage = Nothing
        GridColumnDescriptor12.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor12.MappingName = "estado"
        GridColumnDescriptor12.Name = "estado"
        GridColumnDescriptor12.SerializedImageArray = ""
        Me.dgvCompra.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor8, GridColumnDescriptor9, GridColumnDescriptor10, GridColumnDescriptor11, GridColumnDescriptor12})
        Me.dgvCompra.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.dgvCompra.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.dgvCompra.TableDescriptor.TopLevelGroupOptions.ShowAddNewRecordAfterDetails = False
        Me.dgvCompra.TableDescriptor.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = False
        Me.dgvCompra.TableDescriptor.TopLevelGroupOptions.ShowCaption = False
        Me.dgvCompra.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("descripcion"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("utilidad")})
        Me.dgvCompra.Text = "GridGroupingControl1"
        Me.dgvCompra.VersionInfo = "12.4400.0.24"
        '
        'DockingClientPanel1
        '
        Me.DockingClientPanel1.Controls.Add(Me.panelDetalleItems)
        Me.DockingClientPanel1.Controls.Add(Me.Panel1)
        Me.DockingClientPanel1.Location = New System.Drawing.Point(0, 144)
        Me.DockingClientPanel1.Name = "DockingClientPanel1"
        Me.DockingClientPanel1.Size = New System.Drawing.Size(863, 252)
        Me.DockingClientPanel1.TabIndex = 200
        '
        'frmExistencias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(863, 398)
        Me.Controls.Add(Me.DockingClientPanel1)
        Me.Controls.Add(Me.RibbonControlAdv1)
        Me.Name = "frmExistencias"
        Me.Text = "Master Existencias"
        CType(Me.RibbonControlAdv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RibbonControlAdv1.ResumeLayout(False)
        Me.RibbonControlAdv1.PerformLayout()
        Me.ToolStripTabItem.Panel.ResumeLayout(False)
        Me.ToolStripEx1.ResumeLayout(False)
        Me.ToolStripEx1.PerformLayout()
        Me.ToolStripEx2.ResumeLayout(False)
        Me.ToolStripEx2.PerformLayout()
        CType(Me.DockingManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelNuevoItem.ResumeLayout(False)
        Me.PanelNuevoItem.PerformLayout()
        CType(Me.nudPorcentajeTributo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaComprobante.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaComprobante, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelDetalleItems.ResumeLayout(False)
        CType(Me.dgvDetalleItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel15.ResumeLayout(False)
        Me.panelNuevoDetalleItem.ResumeLayout(False)
        Me.panelNuevoDetalleItem.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvCompra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DockingClientPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RibbonControlAdv1 As Syncfusion.Windows.Forms.Tools.RibbonControlAdv
    Friend WithEvents ToolStripTabItem As Syncfusion.Windows.Forms.Tools.ToolStripTabItem
    Friend WithEvents ToolStripTabItem1 As Syncfusion.Windows.Forms.Tools.ToolStripTabItem
    Friend WithEvents ToolStripEx1 As Syncfusion.Windows.Forms.Tools.ToolStripEx
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents CompraDirectaConRecepciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripEx2 As Syncfusion.Windows.Forms.Tools.ToolStripEx
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ExistenciasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DockingManager1 As Syncfusion.Windows.Forms.Tools.DockingManager
    Friend WithEvents PanelNuevoItem As System.Windows.Forms.Panel
    Friend WithEvents btnAgregarClasificacion As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents nudPorcentajeTributo As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents txtFechaComprobante As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents txtClasificacion As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents panelDetalleItems As System.Windows.Forms.Panel
    Private WithEvents panel15 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents panelNuevoDetalleItem As System.Windows.Forms.Panel
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents txtCodigoCuenta As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCuenta As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents txtCodigoUnidad As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents txtCodigoPresentación As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTipoExitencia As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtPresentacion As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents txtUnidad As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtExistencia As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCodigoTExistencia As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents txtExisClasificacion As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgvCompra As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents dgvDetalleItems As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents txtBuscarClasif As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripPanelItem1 As Syncfusion.Windows.Forms.Tools.ToolStripPanelItem
    Friend WithEvents btnEditCompra As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnEliminarCompra As System.Windows.Forms.ToolStripButton
    Friend WithEvents DockingClientPanel1 As Syncfusion.Windows.Forms.Tools.DockingClientPanel
    Friend WithEvents GradientLabel1 As Syncfusion.Windows.Forms.Tools.GradientLabel
End Class

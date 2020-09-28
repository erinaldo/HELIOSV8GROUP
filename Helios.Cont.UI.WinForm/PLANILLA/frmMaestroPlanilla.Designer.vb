<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMaestroPlanilla
    Inherits Syncfusion.Windows.Forms.Tools.RibbonForm

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
        Dim Office2013ColorTable2 As Syncfusion.Windows.Forms.Tools.Office2013ColorTable = New Syncfusion.Windows.Forms.Tools.Office2013ColorTable()
        Dim ToolStripTabGroup2 As Syncfusion.Windows.Forms.Tools.ToolStripTabGroup = New Syncfusion.Windows.Forms.Tools.ToolStripTabGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMaestroPlanilla))
        Me.tabMDImgr = New Syncfusion.Windows.Forms.Tools.TabbedMDIManager(Me.components)
        Me.sbPrincipal = New Syncfusion.Windows.Forms.Tools.StatusBarAdv()
        Me.ContextMenuStripEx1 = New Syncfusion.Windows.Forms.Tools.ContextMenuStripEx()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.imageListAdv1 = New Syncfusion.Windows.Forms.Tools.ImageListAdv(Me.components)
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.btnInicio = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.rbnPrincipal = New Syncfusion.Windows.Forms.Tools.RibbonControlAdv()
        Me.gbNavegador = New Syncfusion.Windows.Forms.Tools.GroupBar()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnAnio = New System.Windows.Forms.ToolStripButton()
        Me.cboAnio = New System.Windows.Forms.ToolStripComboBox()
        Me.dockingManager1 = New Syncfusion.Windows.Forms.Tools.DockingManager(Me.components)
        Me.cmsNotificacion = New Syncfusion.Windows.Forms.Tools.ContextMenuStripEx()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.sbPrincipal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStripEx1.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.rbnPrincipal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbNavegador, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbNavegador.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dockingManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsNotificacion.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabMDImgr
        '
        Me.tabMDImgr.AttachedTo = Me
        Me.tabMDImgr.CloseButtonBackColor = System.Drawing.Color.White
        Me.tabMDImgr.ImageSize = New System.Drawing.Size(16, 16)
        Me.tabMDImgr.NeedUpdateHostedForm = False
        '
        'sbPrincipal
        '
        Me.sbPrincipal.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.sbPrincipal.BeforeTouchSize = New System.Drawing.Size(894, 22)
        Me.sbPrincipal.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.sbPrincipal.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.sbPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.sbPrincipal.CustomLayoutBounds = New System.Drawing.Rectangle(0, 0, 0, 0)
        Me.sbPrincipal.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.sbPrincipal.ForeColor = System.Drawing.Color.White
        Me.sbPrincipal.Location = New System.Drawing.Point(1, 371)
        Me.sbPrincipal.Name = "sbPrincipal"
        Me.sbPrincipal.Padding = New System.Windows.Forms.Padding(3)
        Me.sbPrincipal.Size = New System.Drawing.Size(894, 22)
        Me.sbPrincipal.SizingGrip = False
        Me.sbPrincipal.Spacing = New System.Drawing.Size(2, 2)
        Me.sbPrincipal.Style = Syncfusion.Windows.Forms.Tools.StatusbarStyle.Metro
        Me.sbPrincipal.TabIndex = 2
        '
        'ContextMenuStripEx1
        '
        Me.ContextMenuStripEx1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2, Me.ToolStripMenuItem3})
        Me.ContextMenuStripEx1.MetroColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.ContextMenuStripEx1.Name = "ContextMenuStripEx1"
        Me.ContextMenuStripEx1.Size = New System.Drawing.Size(244, 102)
        Me.ContextMenuStripEx1.Style = Syncfusion.Windows.Forms.Tools.ContextMenuStripEx.ContextMenuStyle.[Default]
        Me.ContextMenuStripEx1.Text = "Nuevo"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(243, 22)
        Me.ToolStripMenuItem1.Text = "ToolStripMenuItem1"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(183, 23)
        Me.ToolStripMenuItem2.Text = "ToolStripMenuItem2"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(243, 22)
        Me.ToolStripMenuItem3.Text = "ToolStripMenuItem3"
        '
        'imageListAdv1
        '
        Me.imageListAdv1.Images.AddRange(New System.Drawing.Image() {CType(resources.GetObject("imageListAdv1.Images"), System.Drawing.Image), CType(resources.GetObject("imageListAdv1.Images1"), System.Drawing.Image), CType(resources.GetObject("imageListAdv1.Images2"), System.Drawing.Image), CType(resources.GetObject("imageListAdv1.Images3"), System.Drawing.Image), CType(resources.GetObject("imageListAdv1.Images4"), System.Drawing.Image), CType(resources.GetObject("imageListAdv1.Images5"), System.Drawing.Image), CType(resources.GetObject("imageListAdv1.Images6"), System.Drawing.Image), CType(resources.GetObject("imageListAdv1.Images7"), System.Drawing.Image), CType(resources.GetObject("imageListAdv1.Images8"), System.Drawing.Image), CType(resources.GetObject("imageListAdv1.Images9"), System.Drawing.Image), CType(resources.GetObject("imageListAdv1.Images10"), System.Drawing.Image), CType(resources.GetObject("imageListAdv1.Images11"), System.Drawing.Image), CType(resources.GetObject("imageListAdv1.Images12"), System.Drawing.Image), CType(resources.GetObject("imageListAdv1.Images13"), System.Drawing.Image), CType(resources.GetObject("imageListAdv1.Images14"), System.Drawing.Image), CType(resources.GetObject("imageListAdv1.Images15"), System.Drawing.Image), CType(resources.GetObject("imageListAdv1.Images16"), System.Drawing.Image), CType(resources.GetObject("imageListAdv1.Images17"), System.Drawing.Image), CType(resources.GetObject("imageListAdv1.Images18"), System.Drawing.Image), CType(resources.GetObject("imageListAdv1.Images19"), System.Drawing.Image)})
        Me.imageListAdv1.ImageSize = New System.Drawing.Size(32, 32)
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Snow
        Me.Panel7.Controls.Add(Me.ButtonAdv1)
        Me.Panel7.Controls.Add(Me.btnInicio)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(1, 32)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(894, 38)
        Me.Panel7.TabIndex = 216
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(95, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(144, 28)
        Me.ButtonAdv1.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.Image = CType(resources.GetObject("ButtonAdv1.Image"), System.Drawing.Image)
        Me.ButtonAdv1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(76, 5)
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(144, 28)
        Me.ButtonAdv1.TabIndex = 218
        Me.ButtonAdv1.Text = "           Registrar asistencia"
        Me.ButtonAdv1.UseVisualStyle = True
        '
        'btnInicio
        '
        Me.btnInicio.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btnInicio.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(154, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.btnInicio.BeforeTouchSize = New System.Drawing.Size(58, 38)
        Me.btnInicio.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnInicio.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnInicio.ForeColor = System.Drawing.Color.White
        Me.btnInicio.Image = CType(resources.GetObject("btnInicio.Image"), System.Drawing.Image)
        Me.btnInicio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnInicio.IsBackStageButton = False
        Me.btnInicio.Location = New System.Drawing.Point(836, 0)
        Me.btnInicio.Name = "btnInicio"
        Me.btnInicio.Size = New System.Drawing.Size(58, 38)
        Me.btnInicio.TabIndex = 214
        Me.btnInicio.Text = "Inicio"
        Me.btnInicio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnInicio, "Establecimiento de Inicio")
        Me.btnInicio.UseVisualStyle = True
        '
        'rbnPrincipal
        '
        Me.rbnPrincipal.CaptionFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbnPrincipal.HideMenuButtonToolTip = False
        Me.rbnPrincipal.LauncherStyle = Syncfusion.Windows.Forms.Tools.LauncherStyle.Metro
        Me.rbnPrincipal.Location = New System.Drawing.Point(1, 1)
        Me.rbnPrincipal.MaximizeToolTip = "Maximize Ribbon"
        Me.rbnPrincipal.MenuButtonAutoSize = True
        Me.rbnPrincipal.MenuButtonEnabled = True
        Me.rbnPrincipal.MenuButtonFont = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbnPrincipal.MenuButtonText = ""
        Me.rbnPrincipal.MenuButtonVisible = False
        Me.rbnPrincipal.MenuButtonWidth = 56
        Me.rbnPrincipal.MenuColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.rbnPrincipal.MinimizeToolTip = "Minimize Ribbon"
        Me.rbnPrincipal.Name = "rbnPrincipal"
        Me.rbnPrincipal.Office2013ColorScheme = Syncfusion.Windows.Forms.Tools.Office2013ColorScheme.White
        Office2013ColorTable2.ButtonBackgroundPressed = System.Drawing.Color.Empty
        Office2013ColorTable2.ButtonBackgroundSelected = System.Drawing.Color.Empty
        Office2013ColorTable2.CaptionBackColor = System.Drawing.Color.White
        Office2013ColorTable2.CaptionForeColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer))
        Office2013ColorTable2.CheckedTabColor = System.Drawing.Color.White
        Office2013ColorTable2.CheckedTabForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(198, Byte), Integer))
        Office2013ColorTable2.CloseButtonColor = System.Drawing.Color.Empty
        Office2013ColorTable2.ContextMenuBackColor = System.Drawing.Color.Empty
        Office2013ColorTable2.ContextMenuItemSelected = System.Drawing.Color.Empty
        Office2013ColorTable2.HeaderColor = System.Drawing.Color.White
        Office2013ColorTable2.HoverTabForeColor = System.Drawing.Color.Empty
        Office2013ColorTable2.LauncherBackColorSelected = System.Drawing.Color.Empty
        Office2013ColorTable2.LauncherColorNormal = System.Drawing.Color.Empty
        Office2013ColorTable2.LauncherColorSelected = System.Drawing.Color.Empty
        Office2013ColorTable2.MaximizeButtonColor = System.Drawing.Color.Empty
        Office2013ColorTable2.MinimizeButtonColor = System.Drawing.Color.Empty
        Office2013ColorTable2.PanelBackColor = System.Drawing.Color.White
        Office2013ColorTable2.RestoreButtonColor = System.Drawing.Color.Empty
        Office2013ColorTable2.RibbonPanelBorderColor = System.Drawing.Color.Empty
        Office2013ColorTable2.SelectedTabBorderColor = System.Drawing.Color.White
        Office2013ColorTable2.SelectedTabColor = System.Drawing.Color.White
        Office2013ColorTable2.SplitButtonBackgroundPressed = System.Drawing.Color.Empty
        Office2013ColorTable2.SplitButtonBackgroundSelected = System.Drawing.Color.Empty
        Office2013ColorTable2.SystemButtonBackground = System.Drawing.Color.Empty
        Office2013ColorTable2.TabBackColor = System.Drawing.Color.White
        Office2013ColorTable2.TabForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(2, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer))
        Office2013ColorTable2.TitleColor = System.Drawing.Color.Empty
        Office2013ColorTable2.ToolStripBackColor = System.Drawing.Color.White
        Office2013ColorTable2.ToolStripBorderColor = System.Drawing.Color.White
        Office2013ColorTable2.ToolStripItemForeColor = System.Drawing.Color.FromArgb(CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer))
        Office2013ColorTable2.ToolStripSpliterColor = System.Drawing.Color.LightGray
        Office2013ColorTable2.UpDownButtonBackColor = System.Drawing.Color.Empty
        Me.rbnPrincipal.Office2013ColorTable = Office2013ColorTable2
        Me.rbnPrincipal.OfficeColorScheme = Syncfusion.Windows.Forms.Tools.ToolStripEx.ColorScheme.Managed
        '
        'rbnPrincipal.OfficeMenu
        '
        Me.rbnPrincipal.OfficeMenu.Name = "OfficeMenu"
        Me.rbnPrincipal.OfficeMenu.ShowItemToolTips = True
        Me.rbnPrincipal.OfficeMenu.Size = New System.Drawing.Size(12, 65)
        Me.rbnPrincipal.OverFlowButtonToolTip = "Show DropDown"
        Me.rbnPrincipal.QuickPanelImageLayout = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.rbnPrincipal.QuickPanelVisible = False
        Me.rbnPrincipal.RibbonHeaderImage = Syncfusion.Windows.Forms.Tools.RibbonHeaderImage.Circles
        Me.rbnPrincipal.RibbonStyle = Syncfusion.Windows.Forms.Tools.RibbonStyle.Office2013
        Me.rbnPrincipal.SelectedTab = Nothing
        Me.rbnPrincipal.Show2010CustomizeQuickItemDialog = False
        Me.rbnPrincipal.ShowLauncher = False
        Me.rbnPrincipal.ShowRibbonDisplayOptionButton = True
        Me.rbnPrincipal.Size = New System.Drawing.Size(896, 32)
        Me.rbnPrincipal.SystemText.QuickAccessDialogDropDownName = "Start menu"
        ToolStripTabGroup2.Color = System.Drawing.Color.Empty
        ToolStripTabGroup2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ToolStripTabGroup2.Name = Nothing
        ToolStripTabGroup2.Visible = True
        Me.rbnPrincipal.TabGroups.Add(ToolStripTabGroup2)
        Me.rbnPrincipal.TabIndex = 5
        Me.rbnPrincipal.TitleAlignment = Syncfusion.Windows.Forms.Tools.TextAlignment.Center
        Me.rbnPrincipal.TitleColor = System.Drawing.SystemColors.HotTrack
        '
        'gbNavegador
        '
        Me.gbNavegador.AllowCollapse = True
        Me.gbNavegador.AllowDrop = True
        Me.gbNavegador.AnimatedSelection = False
        Me.gbNavegador.ApplyDefaultVisualStyleColor = False
        Me.gbNavegador.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(154, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.gbNavegador.BeforeTouchSize = New System.Drawing.Size(220, 301)
        Me.gbNavegador.BorderColor = System.Drawing.Color.White
        Me.gbNavegador.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.gbNavegador.CollapseImage = CType(resources.GetObject("gbNavegador.CollapseImage"), System.Drawing.Image)
        Me.gbNavegador.Controls.Add(Me.ToolStrip1)
        Me.gbNavegador.Dock = System.Windows.Forms.DockStyle.Left
        Me.gbNavegador.ExpandButtonToolTip = Nothing
        Me.gbNavegador.ExpandedWidth = 220
        Me.gbNavegador.ExpandImage = CType(resources.GetObject("gbNavegador.ExpandImage"), System.Drawing.Image)
        Me.gbNavegador.FlatLook = True
        Me.gbNavegador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.gbNavegador.ForeColor = System.Drawing.Color.White
        Me.gbNavegador.GroupBarDropDownToolTip = Nothing
        Me.gbNavegador.HeaderBackColor = System.Drawing.Color.White
        Me.gbNavegador.IndexOnVisibleItems = True
        Me.gbNavegador.Location = New System.Drawing.Point(1, 70)
        Me.gbNavegador.MinimizeButtonToolTip = Nothing
        Me.gbNavegador.Name = "gbNavegador"
        Me.gbNavegador.NavigationPaneTooltip = Nothing
        Me.gbNavegador.PopupClientSize = New System.Drawing.Size(0, 0)
        Me.gbNavegador.ShowItemImageInHeader = True
        Me.gbNavegador.Size = New System.Drawing.Size(220, 301)
        Me.gbNavegador.StackedMode = True
        Me.gbNavegador.TabIndex = 4
        Me.gbNavegador.Text = "GroupBar1"
        Me.gbNavegador.TextAlign = Syncfusion.Windows.Forms.Tools.TextAlignment.Left
        Me.gbNavegador.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.btnAnio, Me.cboAnio})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(220, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        Me.ToolStrip1.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnAnio
        '
        Me.btnAnio.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAnio.Name = "btnAnio"
        Me.btnAnio.Size = New System.Drawing.Size(36, 22)
        Me.btnAnio.Text = "Año:"
        Me.btnAnio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAnio.Visible = False
        '
        'cboAnio
        '
        Me.cboAnio.AutoSize = False
        Me.cboAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAnio.DropDownWidth = 75
        Me.cboAnio.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.cboAnio.Name = "cboAnio"
        Me.cboAnio.Size = New System.Drawing.Size(55, 21)
        Me.cboAnio.Visible = False
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
        'cmsNotificacion
        '
        Me.cmsNotificacion.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem6})
        Me.cmsNotificacion.MetroColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.cmsNotificacion.Name = "ContextMenuStripEx1"
        Me.cmsNotificacion.Size = New System.Drawing.Size(118, 53)
        Me.cmsNotificacion.Style = Syncfusion.Windows.Forms.Tools.ContextMenuStripEx.ContextMenuStyle.[Default]
        Me.cmsNotificacion.Text = "Nuevo"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(117, 22)
        Me.ToolStripMenuItem6.Text = "Eliminar"
        '
        'frmMaestroPlanilla
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(896, 393)
        Me.Controls.Add(Me.rbnPrincipal)
        Me.Controls.Add(Me.gbNavegador)
        Me.Controls.Add(Me.sbPrincipal)
        Me.Controls.Add(Me.Panel7)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsMdiContainer = True
        Me.Name = "frmMaestroPlanilla"
        Me.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.ShowIcon = False
        Me.Text = "S O F T - P A C K"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        CType(Me.sbPrincipal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStripEx1.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        CType(Me.rbnPrincipal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbNavegador, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbNavegador.ResumeLayout(False)
        Me.gbNavegador.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.dockingManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsNotificacion.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbNavegador As Syncfusion.Windows.Forms.Tools.GroupBar
    Friend WithEvents sbPrincipal As Syncfusion.Windows.Forms.Tools.StatusBarAdv
    Private WithEvents tabMDImgr As Syncfusion.Windows.Forms.Tools.TabbedMDIManager
    Friend WithEvents rbnPrincipal As Syncfusion.Windows.Forms.Tools.RibbonControlAdv

    Friend WithEvents ContextMenuStripEx1 As Syncfusion.Windows.Forms.Tools.ContextMenuStripEx
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents cboAnio As System.Windows.Forms.ToolStripComboBox
    Private WithEvents imageListAdv1 As Syncfusion.Windows.Forms.Tools.ImageListAdv
    Private WithEvents btnAnio As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents btnInicio As Syncfusion.Windows.Forms.ButtonAdv
    Private WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents dockingManager1 As Syncfusion.Windows.Forms.Tools.DockingManager
    Private WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmsNotificacion As Syncfusion.Windows.Forms.Tools.ContextMenuStripEx
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
End Class

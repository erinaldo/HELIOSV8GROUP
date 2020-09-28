Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMantenimientoGeneral
    Inherits MetroForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMantenimientoGeneral))
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.bunifuElipse1 = New Bunifu.Framework.UI.BunifuElipse(Me.components)
        Me.RibbonControlAdv1 = New Syncfusion.Windows.Forms.Tools.RibbonControlAdv()
        Me.ToolStripTabItem1 = New Syncfusion.Windows.Forms.Tools.ToolStripTabItem()
        Me.ToolStripEx1 = New Syncfusion.Windows.Forms.Tools.ToolStripEx()
        Me.ToolStripDropDownButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripEx2 = New Syncfusion.Windows.Forms.Tools.ToolStripEx()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripTabItem2 = New Syncfusion.Windows.Forms.Tools.ToolStripTabItem()
        Me.ToolStripEx3 = New Syncfusion.Windows.Forms.Tools.ToolStripEx()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripTabItem3 = New Syncfusion.Windows.Forms.Tools.ToolStripTabItem()
        Me.ToolStripEx4 = New Syncfusion.Windows.Forms.Tools.ToolStripEx()
        Me.btNuevoServicio = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton9 = New System.Windows.Forms.ToolStripButton()
        Me.btListaServicio = New System.Windows.Forms.ToolStripButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PanelBody = New System.Windows.Forms.Panel()
        CType(Me.RibbonControlAdv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RibbonControlAdv1.SuspendLayout()
        Me.ToolStripTabItem1.Panel.SuspendLayout()
        Me.ToolStripEx1.SuspendLayout()
        Me.ToolStripEx2.SuspendLayout()
        Me.ToolStripTabItem2.Panel.SuspendLayout()
        Me.ToolStripEx3.SuspendLayout()
        Me.ToolStripTabItem3.Panel.SuspendLayout()
        Me.ToolStripEx4.SuspendLayout()
        Me.SuspendLayout()
        '
        'bunifuElipse1
        '
        Me.bunifuElipse1.ElipseRadius = 22
        Me.bunifuElipse1.TargetControl = Me
        '
        'RibbonControlAdv1
        '
        Me.RibbonControlAdv1.CaptionFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RibbonControlAdv1.Dock = Syncfusion.Windows.Forms.Tools.DockStyleEx.Top
        Me.RibbonControlAdv1.Header.AddMainItem(ToolStripTabItem1)
        Me.RibbonControlAdv1.Header.AddMainItem(ToolStripTabItem2)
        Me.RibbonControlAdv1.Header.AddMainItem(ToolStripTabItem3)
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
        Me.RibbonControlAdv1.RibbonHeaderImage = Syncfusion.Windows.Forms.Tools.RibbonHeaderImage.Lines
        Me.RibbonControlAdv1.RibbonStyle = Syncfusion.Windows.Forms.Tools.RibbonStyle.Office2013
        Me.RibbonControlAdv1.SelectedTab = Me.ToolStripTabItem2
        Me.RibbonControlAdv1.Show2010CustomizeQuickItemDialog = False
        Me.RibbonControlAdv1.ShowQuickItemsDropDownButton = False
        Me.RibbonControlAdv1.ShowRibbonDisplayOptionButton = False
        Me.RibbonControlAdv1.Size = New System.Drawing.Size(1032, 142)
        Me.RibbonControlAdv1.SystemText.QuickAccessDialogDropDownName = "Start menu"
        Me.RibbonControlAdv1.TabIndex = 31
        Me.RibbonControlAdv1.Text = "RibbonControlAdv1"
        Me.RibbonControlAdv1.TitleAlignment = Syncfusion.Windows.Forms.Tools.TextAlignment.Center
        Me.RibbonControlAdv1.TitleColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.RibbonControlAdv1.TitleFont = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.ToolStripTabItem1.Panel.Text = "TABLAS GENERALES"
        Me.ToolStripTabItem1.Position = 0
        Me.ToolStripTabItem1.Size = New System.Drawing.Size(125, 25)
        Me.ToolStripTabItem1.Tag = "1"
        Me.ToolStripTabItem1.Text = "TABLAS GENERALES"
        '
        'ToolStripEx1
        '
        Me.ToolStripEx1.AutoSize = False
        Me.ToolStripEx1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStripEx1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.ToolStripEx1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStripEx1.Image = Nothing
        Me.ToolStripEx1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripDropDownButton4, Me.ToolStripButton1})
        Me.ToolStripEx1.Location = New System.Drawing.Point(0, 1)
        Me.ToolStripEx1.Name = "ToolStripEx1"
        Me.ToolStripEx1.Office12Mode = False
        Me.ToolStripEx1.Size = New System.Drawing.Size(201, 86)
        Me.ToolStripEx1.TabIndex = 0
        Me.ToolStripEx1.Text = "- C a t a l o g o -"
        '
        'ToolStripDropDownButton4
        '
        Me.ToolStripDropDownButton4.Font = New System.Drawing.Font("Calibri Light", 9.0!)
        Me.ToolStripDropDownButton4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ToolStripDropDownButton4.Image = CType(resources.GetObject("ToolStripDropDownButton4.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripDropDownButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton4.Margin = New System.Windows.Forms.Padding(20, 1, 0, 1)
        Me.ToolStripDropDownButton4.Name = "ToolStripDropDownButton4"
        Me.ToolStripDropDownButton4.Size = New System.Drawing.Size(50, 70)
        Me.ToolStripDropDownButton4.Text = "Nuevo"
        Me.ToolStripDropDownButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripDropDownButton4.ToolTipText = "Nuevo item"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Calibri Light", 9.0!)
        Me.ToolStripButton1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Margin = New System.Windows.Forms.Padding(40, 1, 0, 1)
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(50, 70)
        Me.ToolStripButton1.Text = "Lista"
        Me.ToolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripButton1.ToolTipText = "Catalogo de Tablas"
        '
        'ToolStripEx2
        '
        Me.ToolStripEx2.AutoSize = False
        Me.ToolStripEx2.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStripEx2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.ToolStripEx2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStripEx2.Image = Nothing
        Me.ToolStripEx2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton2, Me.ToolStripButton3})
        Me.ToolStripEx2.Location = New System.Drawing.Point(203, 1)
        Me.ToolStripEx2.Name = "ToolStripEx2"
        Me.ToolStripEx2.Office12Mode = False
        Me.ToolStripEx2.Size = New System.Drawing.Size(195, 86)
        Me.ToolStripEx2.TabIndex = 1
        Me.ToolStripEx2.Text = "T i p o - d e - C a m b i o"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Font = New System.Drawing.Font("Calibri Light", 9.0!)
        Me.ToolStripButton2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Margin = New System.Windows.Forms.Padding(20, 1, 0, 1)
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(50, 70)
        Me.ToolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripButton2.ToolTipText = "Nuevo"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Font = New System.Drawing.Font("Calibri Light", 9.0!)
        Me.ToolStripButton3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Margin = New System.Windows.Forms.Padding(40, 1, 0, 1)
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(50, 70)
        Me.ToolStripButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripButton3.ToolTipText = "Listado"
        '
        'ToolStripTabItem2
        '
        Me.ToolStripTabItem2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripTabItem2.Name = "ToolStripTabItem2"
        '
        'RibbonControlAdv1.RibbonPanel2
        '
        Me.ToolStripTabItem2.Panel.Controls.Add(Me.ToolStripEx3)
        Me.ToolStripTabItem2.Panel.Name = "RibbonPanel2"
        Me.ToolStripTabItem2.Panel.ScrollPosition = 0
        Me.ToolStripTabItem2.Panel.TabIndex = 3
        Me.ToolStripTabItem2.Panel.Text = "PRODUCTOS Y/O ARTICULOS"
        Me.ToolStripTabItem2.Position = 1
        Me.ToolStripTabItem2.Size = New System.Drawing.Size(172, 25)
        Me.ToolStripTabItem2.Tag = "2"
        Me.ToolStripTabItem2.Text = "PRODUCTOS Y/O ARTICULOS"
        '
        'ToolStripEx3
        '
        Me.ToolStripEx3.AutoSize = False
        Me.ToolStripEx3.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStripEx3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.ToolStripEx3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStripEx3.Image = Nothing
        Me.ToolStripEx3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton4, Me.ToolStripButton6, Me.ToolStripButton7, Me.ToolStripButton5})
        Me.ToolStripEx3.Location = New System.Drawing.Point(0, 1)
        Me.ToolStripEx3.Name = "ToolStripEx3"
        Me.ToolStripEx3.Office12Mode = False
        Me.ToolStripEx3.Size = New System.Drawing.Size(306, 86)
        Me.ToolStripEx3.TabIndex = 0
        Me.ToolStripEx3.Text = "- P r o d u c t o s -"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.Font = New System.Drawing.Font("Calibri Light", 9.0!)
        Me.ToolStripButton4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Margin = New System.Windows.Forms.Padding(20, 1, 0, 1)
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(50, 70)
        Me.ToolStripButton4.Text = "Nuevo"
        Me.ToolStripButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripButton4.ToolTipText = "Nuevo item"
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.Font = New System.Drawing.Font("Calibri Light", 9.0!)
        Me.ToolStripButton6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ToolStripButton6.Image = CType(resources.GetObject("ToolStripButton6.Image"), System.Drawing.Image)
        Me.ToolStripButton6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.Margin = New System.Windows.Forms.Padding(10, 1, 0, 1)
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(101, 70)
        Me.ToolStripButton6.Text = "Agrupar productos"
        Me.ToolStripButton6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripButton6.ToolTipText = "Catalogo de Tablas"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.Font = New System.Drawing.Font("Calibri Light", 9.0!)
        Me.ToolStripButton7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ToolStripButton7.Image = CType(resources.GetObject("ToolStripButton7.Image"), System.Drawing.Image)
        Me.ToolStripButton7.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton7.Margin = New System.Windows.Forms.Padding(10, 1, 0, 1)
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(87, 70)
        Me.ToolStripButton7.Text = "Generar Aporte"
        Me.ToolStripButton7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripButton7.ToolTipText = "Catalogo de Tablas"
        Me.ToolStripButton7.Visible = False
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.Font = New System.Drawing.Font("Calibri Light", 9.0!)
        Me.ToolStripButton5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Margin = New System.Windows.Forms.Padding(10, 1, 0, 1)
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(50, 70)
        Me.ToolStripButton5.Text = "Lista"
        Me.ToolStripButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripButton5.ToolTipText = "Catalogo de Tablas"
        '
        'ToolStripTabItem3
        '
        Me.ToolStripTabItem3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripTabItem3.Name = "ToolStripTabItem3"
        '
        'RibbonControlAdv1.RibbonPanel3
        '
        Me.ToolStripTabItem3.Panel.Controls.Add(Me.ToolStripEx4)
        Me.ToolStripTabItem3.Panel.Name = "RibbonPanel3"
        Me.ToolStripTabItem3.Panel.ScrollPosition = 0
        Me.ToolStripTabItem3.Panel.TabIndex = 4
        Me.ToolStripTabItem3.Panel.Text = "SERVICIO"
        Me.ToolStripTabItem3.Position = 2
        Me.ToolStripTabItem3.Size = New System.Drawing.Size(75, 25)
        Me.ToolStripTabItem3.Tag = "3"
        Me.ToolStripTabItem3.Text = "SERVICIO"
        '
        'ToolStripEx4
        '
        Me.ToolStripEx4.AutoSize = False
        Me.ToolStripEx4.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStripEx4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.ToolStripEx4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStripEx4.Image = Nothing
        Me.ToolStripEx4.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btNuevoServicio, Me.ToolStripButton9, Me.btListaServicio})
        Me.ToolStripEx4.Location = New System.Drawing.Point(0, 1)
        Me.ToolStripEx4.Name = "ToolStripEx4"
        Me.ToolStripEx4.Office12Mode = False
        Me.ToolStripEx4.Size = New System.Drawing.Size(306, 86)
        Me.ToolStripEx4.TabIndex = 1
        Me.ToolStripEx4.Text = "- S e r v i c i o s -"
        '
        'btNuevoServicio
        '
        Me.btNuevoServicio.Font = New System.Drawing.Font("Calibri Light", 9.0!)
        Me.btNuevoServicio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btNuevoServicio.Image = CType(resources.GetObject("btNuevoServicio.Image"), System.Drawing.Image)
        Me.btNuevoServicio.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btNuevoServicio.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btNuevoServicio.Margin = New System.Windows.Forms.Padding(20, 1, 0, 1)
        Me.btNuevoServicio.Name = "btNuevoServicio"
        Me.btNuevoServicio.Size = New System.Drawing.Size(50, 70)
        Me.btNuevoServicio.Text = "Nuevo"
        Me.btNuevoServicio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btNuevoServicio.ToolTipText = "Nuevo item"
        '
        'ToolStripButton9
        '
        Me.ToolStripButton9.Font = New System.Drawing.Font("Calibri Light", 9.0!)
        Me.ToolStripButton9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ToolStripButton9.Image = CType(resources.GetObject("ToolStripButton9.Image"), System.Drawing.Image)
        Me.ToolStripButton9.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton9.Margin = New System.Windows.Forms.Padding(10, 1, 0, 1)
        Me.ToolStripButton9.Name = "ToolStripButton9"
        Me.ToolStripButton9.Size = New System.Drawing.Size(95, 70)
        Me.ToolStripButton9.Text = "Agrupar servicios"
        Me.ToolStripButton9.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripButton9.ToolTipText = "Catalogo de Tablas"
        '
        'btListaServicio
        '
        Me.btListaServicio.Font = New System.Drawing.Font("Calibri Light", 9.0!)
        Me.btListaServicio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btListaServicio.Image = CType(resources.GetObject("btListaServicio.Image"), System.Drawing.Image)
        Me.btListaServicio.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btListaServicio.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btListaServicio.Margin = New System.Windows.Forms.Padding(10, 1, 0, 1)
        Me.btListaServicio.Name = "btListaServicio"
        Me.btListaServicio.Size = New System.Drawing.Size(50, 70)
        Me.btListaServicio.Text = "Lista"
        Me.btListaServicio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btListaServicio.ToolTipText = "Catalogo de Tablas"
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 142)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1032, 10)
        Me.Panel1.TabIndex = 32
        '
        'PanelBody
        '
        Me.PanelBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelBody.Location = New System.Drawing.Point(0, 152)
        Me.PanelBody.Name = "PanelBody"
        Me.PanelBody.Size = New System.Drawing.Size(1032, 483)
        Me.PanelBody.TabIndex = 33
        '
        'FormMantenimientoGeneral
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BorderColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.CaptionButtonColor = System.Drawing.Color.White
        Me.CaptionButtonHoverColor = System.Drawing.Color.White
        Me.CaptionForeColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(155, Byte), Integer))
        CaptionLabel1.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.White
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(200, 24)
        CaptionLabel1.Text = "Mantenimiento General"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(1032, 635)
        Me.Controls.Add(Me.PanelBody)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.RibbonControlAdv1)
        Me.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FormMantenimientoGeneral"
        Me.ShowIcon = False
        Me.Text = "Mantenimiento general"
        CType(Me.RibbonControlAdv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RibbonControlAdv1.ResumeLayout(False)
        Me.RibbonControlAdv1.PerformLayout()
        Me.ToolStripTabItem1.Panel.ResumeLayout(False)
        Me.ToolStripEx1.ResumeLayout(False)
        Me.ToolStripEx1.PerformLayout()
        Me.ToolStripEx2.ResumeLayout(False)
        Me.ToolStripEx2.PerformLayout()
        Me.ToolStripTabItem2.Panel.ResumeLayout(False)
        Me.ToolStripEx3.ResumeLayout(False)
        Me.ToolStripEx3.PerformLayout()
        Me.ToolStripTabItem3.Panel.ResumeLayout(False)
        Me.ToolStripEx4.ResumeLayout(False)
        Me.ToolStripEx4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents bunifuElipse1 As Bunifu.Framework.UI.BunifuElipse
    Friend WithEvents RibbonControlAdv1 As Tools.RibbonControlAdv
    Friend WithEvents ToolStripTabItem1 As Tools.ToolStripTabItem
    Friend WithEvents ToolStripEx1 As Tools.ToolStripEx
    Friend WithEvents ToolStripDropDownButton4 As ToolStripButton
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripEx2 As Tools.ToolStripEx
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents ToolStripButton3 As ToolStripButton
    Friend WithEvents PanelBody As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ToolStripTabItem2 As Tools.ToolStripTabItem
    Friend WithEvents ToolStripEx3 As Tools.ToolStripEx
    Friend WithEvents ToolStripButton4 As ToolStripButton
    Friend WithEvents ToolStripButton5 As ToolStripButton
    Friend WithEvents ToolStripButton6 As ToolStripButton
    Friend WithEvents ToolStripButton7 As ToolStripButton
    Friend WithEvents ToolStripTabItem3 As Tools.ToolStripTabItem
    Friend WithEvents ToolStripEx4 As Tools.ToolStripEx
    Friend WithEvents btNuevoServicio As ToolStripButton
    Friend WithEvents ToolStripButton9 As ToolStripButton
    Friend WithEvents btListaServicio As ToolStripButton
End Class

Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormUltimasVentas
    Inherits MetroForm

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
        Dim Office2013ColorTable1 As Syncfusion.Windows.Forms.Tools.Office2013ColorTable = New Syncfusion.Windows.Forms.Tools.Office2013ColorTable()
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"1", "JIUNI PALACIOS SANTOS", "44924569"}, -1)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormUltimasVentas))
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor6 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.RibbonControlAdv1 = New Syncfusion.Windows.Forms.Tools.RibbonControlAdv()
        Me.ToolStripTabItem1 = New Syncfusion.Windows.Forms.Tools.ToolStripTabItem()
        Me.ToolStripEx4 = New Syncfusion.Windows.Forms.Tools.ToolStripEx()
        Me.PanelRegistro = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.pcLikeCategoria = New Syncfusion.Windows.Forms.PopupControlContainer(Me.components)
        Me.LsvProveedor = New System.Windows.Forms.ListView()
        Me.colID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colRUC = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTipoDoc = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtruc = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TXTcOMPRADOR = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GridEscan = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.ToolStripPanelItem14 = New Syncfusion.Windows.Forms.Tools.ToolStripPanelItem()
        Me.ToolStripButton45 = New System.Windows.Forms.ToolStripButton()
        Me.ToolVentas = New System.Windows.Forms.ToolStripButton()
        Me.ToolNotas = New System.Windows.Forms.ToolStripButton()
        Me.ToolTotal = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripEx1 = New Syncfusion.Windows.Forms.Tools.ToolStripEx()
        Me.ToolStripEx2 = New Syncfusion.Windows.Forms.Tools.ToolStripEx()
        CType(Me.RibbonControlAdv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RibbonControlAdv1.SuspendLayout()
        Me.ToolStripTabItem1.Panel.SuspendLayout()
        Me.ToolStripEx4.SuspendLayout()
        CType(Me.PanelRegistro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelRegistro.SuspendLayout()
        Me.pcLikeCategoria.SuspendLayout()
        CType(Me.txtruc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TXTcOMPRADOR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridEscan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControlAdv1
        '
        Me.RibbonControlAdv1.CaptionFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RibbonControlAdv1.Dock = Syncfusion.Windows.Forms.Tools.DockStyleEx.Top
        Me.RibbonControlAdv1.Header.AddMainItem(ToolStripTabItem1)
        Me.RibbonControlAdv1.HideMenuButtonToolTip = False
        Me.RibbonControlAdv1.LauncherStyle = Syncfusion.Windows.Forms.Tools.LauncherStyle.Metro
        Me.RibbonControlAdv1.Location = New System.Drawing.Point(0, 41)
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
        Me.RibbonControlAdv1.RibbonHeaderImage = Syncfusion.Windows.Forms.Tools.RibbonHeaderImage.Nodes
        Me.RibbonControlAdv1.RibbonStyle = Syncfusion.Windows.Forms.Tools.RibbonStyle.Office2013
        Me.RibbonControlAdv1.SelectedTab = Me.ToolStripTabItem1
        Me.RibbonControlAdv1.Show2010CustomizeQuickItemDialog = False
        Me.RibbonControlAdv1.ShowQuickItemsDropDownButton = False
        Me.RibbonControlAdv1.ShowRibbonDisplayOptionButton = False
        Me.RibbonControlAdv1.Size = New System.Drawing.Size(750, 142)
        Me.RibbonControlAdv1.SystemText.QuickAccessDialogDropDownName = "Start menu"
        Me.RibbonControlAdv1.TabIndex = 41
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
        Me.ToolStripTabItem1.Panel.Controls.Add(Me.ToolStripEx4)
        Me.ToolStripTabItem1.Panel.Controls.Add(Me.ToolStripEx1)
        Me.ToolStripTabItem1.Panel.Controls.Add(Me.ToolStripEx2)
        Me.ToolStripTabItem1.Panel.Name = "RibbonPanel1"
        Me.ToolStripTabItem1.Panel.ScrollPosition = 0
        Me.ToolStripTabItem1.Panel.TabIndex = 2
        Me.ToolStripTabItem1.Panel.Text = "RECIENTES"
        Me.ToolStripTabItem1.Position = 0
        Me.ToolStripTabItem1.Size = New System.Drawing.Size(81, 25)
        Me.ToolStripTabItem1.Tag = "1"
        Me.ToolStripTabItem1.Text = "RECIENTES"
        '
        'ToolStripEx4
        '
        Me.ToolStripEx4.AutoSize = False
        Me.ToolStripEx4.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStripEx4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.ToolStripEx4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStripEx4.Image = Nothing
        Me.ToolStripEx4.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripPanelItem14, Me.ToolTotal})
        Me.ToolStripEx4.Location = New System.Drawing.Point(0, 1)
        Me.ToolStripEx4.Name = "ToolStripEx4"
        Me.ToolStripEx4.Office12Mode = False
        Me.ToolStripEx4.Size = New System.Drawing.Size(180, 86)
        Me.ToolStripEx4.TabIndex = 3
        Me.ToolStripEx4.Text = "R E S U L T A D O S"
        Me.ToolStripEx4.UseWaitCursor = True
        '
        'PanelRegistro
        '
        Me.PanelRegistro.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PanelRegistro.BorderColor = System.Drawing.Color.Silver
        Me.PanelRegistro.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.PanelRegistro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelRegistro.Controls.Add(Me.ProgressBar1)
        Me.PanelRegistro.Controls.Add(Me.pcLikeCategoria)
        Me.PanelRegistro.Controls.Add(Me.txtruc)
        Me.PanelRegistro.Controls.Add(Me.TXTcOMPRADOR)
        Me.PanelRegistro.Controls.Add(Me.Label1)
        Me.PanelRegistro.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelRegistro.Location = New System.Drawing.Point(0, 0)
        Me.PanelRegistro.Name = "PanelRegistro"
        Me.PanelRegistro.Size = New System.Drawing.Size(750, 41)
        Me.PanelRegistro.TabIndex = 413
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(521, 21)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(33, 10)
        Me.ProgressBar1.TabIndex = 507
        Me.ProgressBar1.Visible = False
        '
        'pcLikeCategoria
        '
        Me.pcLikeCategoria.Controls.Add(Me.LsvProveedor)
        Me.pcLikeCategoria.Location = New System.Drawing.Point(277, 41)
        Me.pcLikeCategoria.Name = "pcLikeCategoria"
        Me.pcLikeCategoria.Size = New System.Drawing.Size(282, 128)
        Me.pcLikeCategoria.TabIndex = 432
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
        'txtruc
        '
        Me.txtruc.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtruc.BeforeTouchSize = New System.Drawing.Size(194, 22)
        Me.txtruc.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtruc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtruc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtruc.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtruc.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtruc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtruc.Location = New System.Drawing.Point(409, 9)
        Me.txtruc.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtruc.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtruc.Name = "txtruc"
        Me.txtruc.NearImage = CType(resources.GetObject("txtruc.NearImage"), System.Drawing.Image)
        Me.txtruc.ReadOnly = True
        Me.txtruc.Size = New System.Drawing.Size(106, 22)
        Me.txtruc.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtruc.TabIndex = 408
        '
        'TXTcOMPRADOR
        '
        Me.TXTcOMPRADOR.BackColor = System.Drawing.Color.White
        Me.TXTcOMPRADOR.BeforeTouchSize = New System.Drawing.Size(194, 22)
        Me.TXTcOMPRADOR.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TXTcOMPRADOR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXTcOMPRADOR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTcOMPRADOR.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TXTcOMPRADOR.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TXTcOMPRADOR.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTcOMPRADOR.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TXTcOMPRADOR.Location = New System.Drawing.Point(124, 9)
        Me.TXTcOMPRADOR.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TXTcOMPRADOR.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TXTcOMPRADOR.Name = "TXTcOMPRADOR"
        Me.TXTcOMPRADOR.NearImage = CType(resources.GetObject("TXTcOMPRADOR.NearImage"), System.Drawing.Image)
        Me.TXTcOMPRADOR.Size = New System.Drawing.Size(282, 22)
        Me.TXTcOMPRADOR.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TXTcOMPRADOR.TabIndex = 220
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Buscar Documento"
        '
        'GridEscan
        '
        Me.GridEscan.BackColor = System.Drawing.SystemColors.Window
        Me.GridEscan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridEscan.FreezeCaption = False
        Me.GridEscan.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.GridEscan.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.GridEscan.Location = New System.Drawing.Point(0, 183)
        Me.GridEscan.Name = "GridEscan"
        Me.GridEscan.Size = New System.Drawing.Size(750, 267)
        Me.GridEscan.TabIndex = 414
        Me.GridEscan.TableDescriptor.AllowNew = False
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.MappingName = "nrodoc"
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor1.Width = 143
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.MappingName = "importe"
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor2.Width = 83
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.MappingName = "proveedor"
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor3.Width = 196
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.HeaderText = "Estado de validación"
        GridColumnDescriptor4.MappingName = "estado"
        GridColumnDescriptor4.SerializedImageArray = ""
        GridColumnDescriptor4.Width = 139
        GridColumnDescriptor5.HeaderImage = Nothing
        GridColumnDescriptor5.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor5.MappingName = "fecha"
        GridColumnDescriptor5.SerializedImageArray = ""
        GridColumnDescriptor5.Width = 93
        GridColumnDescriptor6.HeaderImage = Nothing
        GridColumnDescriptor6.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor6.MappingName = "iddoc"
        GridColumnDescriptor6.ReadOnly = True
        GridColumnDescriptor6.SerializedImageArray = ""
        Me.GridEscan.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6})
        Me.GridEscan.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.GridEscan.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.GridEscan.Text = "GridGroupingControl1"
        Me.GridEscan.VersionInfo = "12.4400.0.24"
        '
        'ToolStripPanelItem14
        '
        Me.ToolStripPanelItem14.CausesValidation = False
        Me.ToolStripPanelItem14.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ToolStripPanelItem14.ForeColor = System.Drawing.Color.MidnightBlue
        Me.ToolStripPanelItem14.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton45, Me.ToolVentas, Me.ToolNotas})
        Me.ToolStripPanelItem14.Name = "ToolStripPanelItem14"
        Me.ToolStripPanelItem14.Size = New System.Drawing.Size(81, 72)
        Me.ToolStripPanelItem14.Text = "ToolStripPanelItem1"
        Me.ToolStripPanelItem14.Transparent = True
        '
        'ToolStripButton45
        '
        Me.ToolStripButton45.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripButton45.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.ToolStripButton45.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton45.Name = "ToolStripButton45"
        Me.ToolStripButton45.Size = New System.Drawing.Size(55, 17)
        Me.ToolStripButton45.Text = "24 horas"
        '
        'ToolVentas
        '
        Me.ToolVentas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ToolVentas.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.b_nextpage
        Me.ToolVentas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolVentas.Name = "ToolVentas"
        Me.ToolVentas.Size = New System.Drawing.Size(77, 20)
        Me.ToolVentas.Text = "0 - Ventas"
        '
        'ToolNotas
        '
        Me.ToolNotas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ToolNotas.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.b_nextpage
        Me.ToolNotas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolNotas.Name = "ToolNotas"
        Me.ToolNotas.Size = New System.Drawing.Size(73, 20)
        Me.ToolNotas.Text = "0 - Notas"
        '
        'ToolTotal
        '
        Me.ToolTotal.Font = New System.Drawing.Font("Segoe UI", 30.0!)
        Me.ToolTotal.ForeColor = System.Drawing.Color.Black
        Me.ToolTotal.Name = "ToolTotal"
        Me.ToolTotal.Size = New System.Drawing.Size(45, 69)
        Me.ToolTotal.Text = "0"
        '
        'ToolStripEx1
        '
        Me.ToolStripEx1.AutoSize = False
        Me.ToolStripEx1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStripEx1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.ToolStripEx1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStripEx1.Image = Nothing
        Me.ToolStripEx1.Location = New System.Drawing.Point(182, 1)
        Me.ToolStripEx1.Name = "ToolStripEx1"
        Me.ToolStripEx1.Office12Mode = False
        Me.ToolStripEx1.Size = New System.Drawing.Size(183, 86)
        Me.ToolStripEx1.TabIndex = 4
        Me.ToolStripEx1.Text = "A V A N Z A D O"
        '
        'ToolStripEx2
        '
        Me.ToolStripEx2.AutoSize = False
        Me.ToolStripEx2.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStripEx2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.ToolStripEx2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStripEx2.Image = Nothing
        Me.ToolStripEx2.Location = New System.Drawing.Point(367, 1)
        Me.ToolStripEx2.Name = "ToolStripEx2"
        Me.ToolStripEx2.Office12Mode = False
        Me.ToolStripEx2.Size = New System.Drawing.Size(210, 86)
        Me.ToolStripEx2.TabIndex = 5
        Me.ToolStripEx2.Text = "C O B R A N Z A"
        '
        'FormUltimasVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.SystemColors.HotTrack
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.CaptionButtonColor = System.Drawing.Color.White
        Me.CaptionButtonHoverColor = System.Drawing.Color.White
        Me.CaptionForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(218, Byte), Integer))
        CaptionLabel1.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.White
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(250, 24)
        CaptionLabel1.Text = "Movimientos del cliente"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(750, 450)
        Me.Controls.Add(Me.GridEscan)
        Me.Controls.Add(Me.RibbonControlAdv1)
        Me.Controls.Add(Me.PanelRegistro)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormUltimasVentas"
        Me.ShowIcon = False
        Me.Text = "Ultimas Ventas"
        CType(Me.RibbonControlAdv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RibbonControlAdv1.ResumeLayout(False)
        Me.RibbonControlAdv1.PerformLayout()
        Me.ToolStripTabItem1.Panel.ResumeLayout(False)
        Me.ToolStripEx4.ResumeLayout(False)
        Me.ToolStripEx4.PerformLayout()
        CType(Me.PanelRegistro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelRegistro.ResumeLayout(False)
        Me.PanelRegistro.PerformLayout()
        Me.pcLikeCategoria.ResumeLayout(False)
        CType(Me.txtruc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TXTcOMPRADOR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridEscan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents RibbonControlAdv1 As Tools.RibbonControlAdv
    Friend WithEvents ToolStripTabItem1 As Tools.ToolStripTabItem
    Friend WithEvents PanelRegistro As Tools.GradientPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents TXTcOMPRADOR As Tools.TextBoxExt
    Friend WithEvents GridEscan As Grid.Grouping.GridGroupingControl
    Friend WithEvents txtruc As Tools.TextBoxExt
    Private WithEvents pcLikeCategoria As PopupControlContainer
    Friend WithEvents LsvProveedor As ListView
    Friend WithEvents colID As ColumnHeader
    Friend WithEvents colCliente As ColumnHeader
    Friend WithEvents colRUC As ColumnHeader
    Friend WithEvents colTipoDoc As ColumnHeader
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents ToolStripEx4 As Tools.ToolStripEx
    Friend WithEvents ToolStripPanelItem14 As Tools.ToolStripPanelItem
    Friend WithEvents ToolStripButton45 As ToolStripButton
    Friend WithEvents ToolVentas As ToolStripButton
    Friend WithEvents ToolNotas As ToolStripButton
    Friend WithEvents ToolTotal As ToolStripLabel
    Friend WithEvents ToolStripEx1 As Tools.ToolStripEx
    Friend WithEvents ToolStripEx2 As Tools.ToolStripEx
End Class

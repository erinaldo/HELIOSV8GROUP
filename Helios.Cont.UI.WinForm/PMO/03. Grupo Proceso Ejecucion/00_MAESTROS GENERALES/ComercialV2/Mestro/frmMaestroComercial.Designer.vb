<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMaestroComercial
    Inherits Syncfusion.Windows.Forms.Tools.RibbonForm

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
        Dim ToolStripTabGroup1 As Syncfusion.Windows.Forms.Tools.ToolStripTabGroup = New Syncfusion.Windows.Forms.Tools.ToolStripTabGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMaestroComercial))
        Me.rbnPrincipal = New Syncfusion.Windows.Forms.Tools.RibbonControlAdv()
        Me.sbPrincipal = New Syncfusion.Windows.Forms.Tools.StatusBarAdv()
        Me.gbNavegador = New Syncfusion.Windows.Forms.Tools.GroupBar()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnAnio = New System.Windows.Forms.ToolStripButton()
        Me.cboAnio = New System.Windows.Forms.ToolStripComboBox()
        Me.tabMDImgr = New Syncfusion.Windows.Forms.Tools.TabbedMDIManager(Me.components)
        Me.ContextMenuStripEx1 = New Syncfusion.Windows.Forms.Tools.ContextMenuStripEx()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.imageListAdv1 = New Syncfusion.Windows.Forms.Tools.ImageListAdv(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmsNotificacion = New Syncfusion.Windows.Forms.Tools.ContextMenuStripEx()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageListAdv2 = New Syncfusion.Windows.Forms.Tools.ImageListAdv(Me.components)
        CType(Me.rbnPrincipal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sbPrincipal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbNavegador, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbNavegador.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.ContextMenuStripEx1.SuspendLayout()
        Me.cmsNotificacion.SuspendLayout()
        Me.SuspendLayout()
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
        Me.rbnPrincipal.MenuColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.rbnPrincipal.MinimizeToolTip = "Minimize Ribbon"
        Me.rbnPrincipal.Name = "rbnPrincipal"
        Me.rbnPrincipal.Office2013ColorScheme = Syncfusion.Windows.Forms.Tools.Office2013ColorScheme.DarkGray
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
        Me.rbnPrincipal.Office2013ColorTable = Office2013ColorTable1
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
        Me.rbnPrincipal.RibbonHeaderImage = Syncfusion.Windows.Forms.Tools.RibbonHeaderImage.Nodes
        Me.rbnPrincipal.RibbonStyle = Syncfusion.Windows.Forms.Tools.RibbonStyle.Office2013
        Me.rbnPrincipal.SelectedTab = Nothing
        Me.rbnPrincipal.Show2010CustomizeQuickItemDialog = False
        Me.rbnPrincipal.ShowLauncher = False
        Me.rbnPrincipal.ShowRibbonDisplayOptionButton = True
        Me.rbnPrincipal.Size = New System.Drawing.Size(1048, 34)
        Me.rbnPrincipal.SystemText.QuickAccessDialogDropDownName = "Start menu"
        ToolStripTabGroup1.Color = System.Drawing.Color.Empty
        ToolStripTabGroup1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ToolStripTabGroup1.Name = Nothing
        ToolStripTabGroup1.Visible = True
        Me.rbnPrincipal.TabGroups.Add(ToolStripTabGroup1)
        Me.rbnPrincipal.TabIndex = 7
        Me.rbnPrincipal.TitleAlignment = Syncfusion.Windows.Forms.Tools.TextAlignment.Center
        Me.rbnPrincipal.TitleColor = System.Drawing.Color.Chocolate
        '
        'sbPrincipal
        '
        Me.sbPrincipal.Alignment = Syncfusion.Windows.Forms.Tools.FlowAlignment.Near
        Me.sbPrincipal.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.sbPrincipal.BackgroundColor = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.LightGray)
        Me.sbPrincipal.BeforeTouchSize = New System.Drawing.Size(1046, 22)
        Me.sbPrincipal.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.sbPrincipal.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.sbPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.sbPrincipal.CustomLayoutBounds = New System.Drawing.Rectangle(0, 0, 0, 0)
        Me.sbPrincipal.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.sbPrincipal.ForeColor = System.Drawing.Color.White
        Me.sbPrincipal.Location = New System.Drawing.Point(1, 445)
        Me.sbPrincipal.Name = "sbPrincipal"
        Me.sbPrincipal.Padding = New System.Windows.Forms.Padding(3)
        Me.sbPrincipal.Size = New System.Drawing.Size(1046, 22)
        Me.sbPrincipal.SizingGrip = False
        Me.sbPrincipal.Spacing = New System.Drawing.Size(2, 2)
        Me.sbPrincipal.Style = Syncfusion.Windows.Forms.Tools.StatusbarStyle.Metro
        Me.sbPrincipal.TabIndex = 219
        '
        'gbNavegador
        '
        Me.gbNavegador.AllowCollapse = True
        Me.gbNavegador.AllowDrop = True
        Me.gbNavegador.AnimatedSelection = False
        Me.gbNavegador.ApplyDefaultVisualStyleColor = False
        Me.gbNavegador.BackColor = System.Drawing.Color.Gray
        Me.gbNavegador.BeforeTouchSize = New System.Drawing.Size(220, 411)
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
        Me.gbNavegador.Location = New System.Drawing.Point(1, 34)
        Me.gbNavegador.MinimizeButtonToolTip = Nothing
        Me.gbNavegador.Name = "gbNavegador"
        Me.gbNavegador.NavigationPaneTooltip = Nothing
        Me.gbNavegador.PopupClientSize = New System.Drawing.Size(0, 0)
        Me.gbNavegador.ShowItemImageInHeader = True
        Me.gbNavegador.Size = New System.Drawing.Size(220, 411)
        Me.gbNavegador.StackedMode = True
        Me.gbNavegador.TabIndex = 220
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
        'tabMDImgr
        '
        Me.tabMDImgr.AttachedTo = Me
        Me.tabMDImgr.CloseButtonBackColor = System.Drawing.Color.White
        Me.tabMDImgr.ImageSize = New System.Drawing.Size(16, 16)
        Me.tabMDImgr.NeedUpdateHostedForm = False
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
        'ImageListAdv2
        '
        Me.ImageListAdv2.Images.AddRange(New System.Drawing.Image() {CType(resources.GetObject("ImageListAdv2.Images"), System.Drawing.Image), CType(resources.GetObject("ImageListAdv2.Images1"), System.Drawing.Image), CType(resources.GetObject("ImageListAdv2.Images2"), System.Drawing.Image), CType(resources.GetObject("ImageListAdv2.Images3"), System.Drawing.Image), CType(resources.GetObject("ImageListAdv2.Images4"), System.Drawing.Image), CType(resources.GetObject("ImageListAdv2.Images5"), System.Drawing.Image)})
        Me.ImageListAdv2.ImageSize = New System.Drawing.Size(32, 32)
        '
        'frmMaestroComercial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1048, 467)
        Me.Controls.Add(Me.gbNavegador)
        Me.Controls.Add(Me.sbPrincipal)
        Me.Controls.Add(Me.rbnPrincipal)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.IsMdiContainer = True
        Me.Name = "frmMaestroComercial"
        Me.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.ShowIcon = False
        Me.Text = "C O M E R C I A L"
        CType(Me.rbnPrincipal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sbPrincipal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbNavegador, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbNavegador.ResumeLayout(False)
        Me.gbNavegador.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ContextMenuStripEx1.ResumeLayout(False)
        Me.cmsNotificacion.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents rbnPrincipal As Syncfusion.Windows.Forms.Tools.RibbonControlAdv
    Friend WithEvents sbPrincipal As Syncfusion.Windows.Forms.Tools.StatusBarAdv
    Friend WithEvents gbNavegador As Syncfusion.Windows.Forms.Tools.GroupBar
    Friend WithEvents ToolStrip1 As ToolStrip
    Private WithEvents ToolStripSeparator1 As ToolStripSeparator
    Private WithEvents btnAnio As ToolStripButton
    Friend WithEvents cboAnio As ToolStripComboBox
    Private WithEvents tabMDImgr As Syncfusion.Windows.Forms.Tools.TabbedMDIManager
    Friend WithEvents ContextMenuStripEx1 As Syncfusion.Windows.Forms.Tools.ContextMenuStripEx
    Private WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Private WithEvents ToolStripMenuItem2 As ToolStripComboBox
    Private WithEvents ToolStripMenuItem3 As ToolStripMenuItem
    Private WithEvents imageListAdv1 As Syncfusion.Windows.Forms.Tools.ImageListAdv
    Private WithEvents ToolTip1 As ToolTip
    Friend WithEvents cmsNotificacion As Syncfusion.Windows.Forms.Tools.ContextMenuStripEx
    Friend WithEvents ToolStripMenuItem6 As ToolStripMenuItem
    Private WithEvents ImageListAdv2 As Syncfusion.Windows.Forms.Tools.ImageListAdv
End Class

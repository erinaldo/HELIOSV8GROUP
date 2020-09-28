Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMantenimientoGeneralEspecial
    Inherits MetroForm

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim Office2013ColorTable1 As Syncfusion.Windows.Forms.Tools.Office2013ColorTable = New Syncfusion.Windows.Forms.Tools.Office2013ColorTable()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMantenimientoGeneralEspecial))
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.bunifuElipse1 = New Bunifu.Framework.UI.BunifuElipse(Me.components)
        Me.RibbonControlAdv1 = New Syncfusion.Windows.Forms.Tools.RibbonControlAdv()
        Me.ToolStripTabItem2 = New Syncfusion.Windows.Forms.Tools.ToolStripTabItem()
        Me.ToolStripEx3 = New Syncfusion.Windows.Forms.Tools.ToolStripEx()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PanelBody = New System.Windows.Forms.Panel()
        CType(Me.RibbonControlAdv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RibbonControlAdv1.SuspendLayout()
        Me.ToolStripTabItem2.Panel.SuspendLayout()
        Me.ToolStripEx3.SuspendLayout()
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
        Me.RibbonControlAdv1.RibbonHeaderImage = Syncfusion.Windows.Forms.Tools.RibbonHeaderImage.Lines
        Me.RibbonControlAdv1.RibbonStyle = Syncfusion.Windows.Forms.Tools.RibbonStyle.Office2013
        Me.RibbonControlAdv1.SelectedTab = Me.ToolStripTabItem2
        Me.RibbonControlAdv1.Show2010CustomizeQuickItemDialog = False
        Me.RibbonControlAdv1.ShowQuickItemsDropDownButton = False
        Me.RibbonControlAdv1.ShowRibbonDisplayOptionButton = False
        Me.RibbonControlAdv1.Size = New System.Drawing.Size(1087, 142)
        Me.RibbonControlAdv1.SystemText.QuickAccessDialogDropDownName = "Start menu"
        Me.RibbonControlAdv1.TabIndex = 31
        Me.RibbonControlAdv1.Text = "RibbonControlAdv1"
        Me.RibbonControlAdv1.TitleAlignment = Syncfusion.Windows.Forms.Tools.TextAlignment.Center
        Me.RibbonControlAdv1.TitleColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.RibbonControlAdv1.TitleFont = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.ToolStripTabItem2.Position = 0
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
        Me.ToolStripEx3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton4, Me.ToolStripButton5})
        Me.ToolStripEx3.Location = New System.Drawing.Point(0, 1)
        Me.ToolStripEx3.Name = "ToolStripEx3"
        Me.ToolStripEx3.Office12Mode = False
        Me.ToolStripEx3.Size = New System.Drawing.Size(162, 86)
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
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 142)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1087, 10)
        Me.Panel1.TabIndex = 32
        '
        'PanelBody
        '
        Me.PanelBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelBody.Location = New System.Drawing.Point(0, 152)
        Me.PanelBody.Name = "PanelBody"
        Me.PanelBody.Size = New System.Drawing.Size(1087, 483)
        Me.PanelBody.TabIndex = 33
        '
        'FormMantenimientoGeneralEspecial
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
        Me.ClientSize = New System.Drawing.Size(1087, 635)
        Me.Controls.Add(Me.PanelBody)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.RibbonControlAdv1)
        Me.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FormMantenimientoGeneralEspecial"
        Me.ShowIcon = False
        Me.Text = "Mantenimiento general"
        CType(Me.RibbonControlAdv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RibbonControlAdv1.ResumeLayout(False)
        Me.RibbonControlAdv1.PerformLayout()
        Me.ToolStripTabItem2.Panel.ResumeLayout(False)
        Me.ToolStripEx3.ResumeLayout(False)
        Me.ToolStripEx3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents bunifuElipse1 As Bunifu.Framework.UI.BunifuElipse
    Friend WithEvents RibbonControlAdv1 As Tools.RibbonControlAdv
    Friend WithEvents PanelBody As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ToolStripTabItem2 As Tools.ToolStripTabItem
    Friend WithEvents ToolStripEx3 As Tools.ToolStripEx
    Friend WithEvents ToolStripButton4 As ToolStripButton
    Friend WithEvents ToolStripButton5 As ToolStripButton
End Class

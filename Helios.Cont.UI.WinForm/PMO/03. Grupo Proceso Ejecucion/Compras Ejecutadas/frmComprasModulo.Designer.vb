<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmComprasModulo
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
        Dim Office2013ColorTable1 As Syncfusion.Windows.Forms.Tools.Office2013ColorTable = New Syncfusion.Windows.Forms.Tools.Office2013ColorTable()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmComprasModulo))
        Me.RibbonControlAdv1 = New Syncfusion.Windows.Forms.Tools.RibbonControlAdv()
        Me.ToolStripTabItem1 = New Syncfusion.Windows.Forms.Tools.ToolStripTabItem()
        Me.ToolStripEx1 = New Syncfusion.Windows.Forms.Tools.ToolStripEx()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.CompraDirectaConRecepciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CompraDirectaSinRecepciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CompraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripPanelItem1 = New Syncfusion.Windows.Forms.Tools.ToolStripPanelItem()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
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
        CType(Me.RibbonControlAdv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RibbonControlAdv1.SuspendLayout()
        Me.ToolStripTabItem1.Panel.SuspendLayout()
        Me.ToolStripEx1.SuspendLayout()
        Me.ToolStripEx2.SuspendLayout()
        Me.SuspendLayout()
        '
        'RibbonControlAdv1
        '
        Me.RibbonControlAdv1.CaptionFont = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RibbonControlAdv1.Header.AddMainItem(ToolStripTabItem1)
        Me.RibbonControlAdv1.HideMenuButtonToolTip = False
        Me.RibbonControlAdv1.Location = New System.Drawing.Point(1, 1)
        Me.RibbonControlAdv1.MaximizeToolTip = "Maximize Ribbon"
        Me.RibbonControlAdv1.MenuButtonEnabled = True
        Me.RibbonControlAdv1.MenuButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RibbonControlAdv1.MenuButtonText = "Archivo"
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
        Me.RibbonControlAdv1.SelectedTab = Me.ToolStripTabItem1
        Me.RibbonControlAdv1.Show2010CustomizeQuickItemDialog = False
        Me.RibbonControlAdv1.ShowRibbonDisplayOptionButton = True
        Me.RibbonControlAdv1.Size = New System.Drawing.Size(1189, 142)
        Me.RibbonControlAdv1.SystemText.QuickAccessDialogDropDownName = "Start menu"
        Me.RibbonControlAdv1.TabIndex = 0
        Me.RibbonControlAdv1.Text = "Registro de Compras"
        Me.RibbonControlAdv1.TitleAlignment = Syncfusion.Windows.Forms.Tools.TextAlignment.Center
        Me.RibbonControlAdv1.TitleColor = System.Drawing.Color.Black
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
        Me.ToolStripTabItem1.Panel.Text = "COMPRA"
        Me.ToolStripTabItem1.Position = 0
        Me.ToolStripTabItem1.Size = New System.Drawing.Size(73, 25)
        Me.ToolStripTabItem1.Tag = "1"
        Me.ToolStripTabItem1.Text = "COMPRA"
        '
        'ToolStripEx1
        '
        Me.ToolStripEx1.AutoSize = False
        Me.ToolStripEx1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStripEx1.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ToolStripEx1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.ToolStripEx1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStripEx1.Image = Nothing
        Me.ToolStripEx1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripDropDownButton1, Me.ToolStripPanelItem1})
        Me.ToolStripEx1.Location = New System.Drawing.Point(0, 1)
        Me.ToolStripEx1.Name = "ToolStripEx1"
        Me.ToolStripEx1.Office12Mode = False
        Me.ToolStripEx1.Size = New System.Drawing.Size(158, 83)
        Me.ToolStripEx1.TabIndex = 0
        Me.ToolStripEx1.Text = "Gestión"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CompraDirectaConRecepciónToolStripMenuItem, Me.CompraDirectaSinRecepciónToolStripMenuItem, Me.CompraToolStripMenuItem})
        Me.ToolStripDropDownButton1.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.ToolStripDropDownButton1.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.icono_new_documento
        Me.ToolStripDropDownButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(61, 66)
        Me.ToolStripDropDownButton1.Text = "Nuevo"
        Me.ToolStripDropDownButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'CompraDirectaConRecepciónToolStripMenuItem
        '
        Me.CompraDirectaConRecepciónToolStripMenuItem.Name = "CompraDirectaConRecepciónToolStripMenuItem"
        Me.CompraDirectaConRecepciónToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.CompraDirectaConRecepciónToolStripMenuItem.Text = "C-Directa con recepción"
        '
        'CompraDirectaSinRecepciónToolStripMenuItem
        '
        Me.CompraDirectaSinRecepciónToolStripMenuItem.Name = "CompraDirectaSinRecepciónToolStripMenuItem"
        Me.CompraDirectaSinRecepciónToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.CompraDirectaSinRecepciónToolStripMenuItem.Text = "C-Directa sin recepción"
        '
        'CompraToolStripMenuItem
        '
        Me.CompraToolStripMenuItem.Name = "CompraToolStripMenuItem"
        Me.CompraToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.CompraToolStripMenuItem.Text = "C-Al crédito"
        '
        'ToolStripPanelItem1
        '
        Me.ToolStripPanelItem1.CausesValidation = False
        Me.ToolStripPanelItem1.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ToolStripPanelItem1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.ToolStripPanelItem1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton2})
        Me.ToolStripPanelItem1.Name = "ToolStripPanelItem1"
        Me.ToolStripPanelItem1.Size = New System.Drawing.Size(72, 69)
        Me.ToolStripPanelItem1.Text = "ToolStripPanelItem1"
        Me.ToolStripPanelItem1.Transparent = True
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.icono_editar_compra
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(57, 20)
        Me.ToolStripButton1.Text = "Editar"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.icono_eliminar_compra
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(68, 20)
        Me.ToolStripButton2.Text = "Eliminar"
        '
        'ToolStripEx2
        '
        Me.ToolStripEx2.AutoSize = False
        Me.ToolStripEx2.CaptionStyle = Syncfusion.Windows.Forms.Tools.CaptionStyle.Bottom
        Me.ToolStripEx2.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStripEx2.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ToolStripEx2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.ToolStripEx2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStripEx2.Image = Nothing
        Me.ToolStripEx2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripPanelItem2})
        Me.ToolStripEx2.Location = New System.Drawing.Point(160, 1)
        Me.ToolStripEx2.Name = "ToolStripEx2"
        Me.ToolStripEx2.Office12Mode = False
        Me.ToolStripEx2.Size = New System.Drawing.Size(314, 83)
        Me.ToolStripEx2.TabIndex = 1
        Me.ToolStripEx2.Text = "Consultas"
        '
        'ToolStripPanelItem2
        '
        Me.ToolStripPanelItem2.CausesValidation = False
        Me.ToolStripPanelItem2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.ToolStripPanelItem2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripPanelItem7, Me.toolStripPanelItem8})
        Me.ToolStripPanelItem2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow
        Me.ToolStripPanelItem2.Name = "ToolStripPanelItem2"
        Me.ToolStripPanelItem2.RowCount = 2
        Me.ToolStripPanelItem2.Size = New System.Drawing.Size(288, 69)
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
        Me.toolStripPanelItem8.Size = New System.Drawing.Size(255, 27)
        Me.toolStripPanelItem8.Text = "toolStripPanelItem4"
        Me.toolStripPanelItem8.Transparent = True
        '
        'btnComprasDia
        '
        Me.btnComprasDia.Image = CType(resources.GetObject("btnComprasDia.Image"), System.Drawing.Image)
        Me.btnComprasDia.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnComprasDia.Name = "btnComprasDia"
        Me.btnComprasDia.Size = New System.Drawing.Size(110, 20)
        Me.btnComprasDia.Text = "Compras del día"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 23)
        '
        'btnComprasPeriodo
        '
        Me.btnComprasPeriodo.Image = CType(resources.GetObject("btnComprasPeriodo.Image"), System.Drawing.Image)
        Me.btnComprasPeriodo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnComprasPeriodo.Name = "btnComprasPeriodo"
        Me.btnComprasPeriodo.Size = New System.Drawing.Size(135, 20)
        Me.btnComprasPeriodo.Text = "Compras del período"
        '
        'frmComprasModulo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1189, 705)
        Me.ColorScheme = Syncfusion.Windows.Forms.Tools.RibbonForm.ColorSchemeType.Silver
        Me.Controls.Add(Me.RibbonControlAdv1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmComprasModulo"
        Me.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.Text = "Registro de Compras"
        CType(Me.RibbonControlAdv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RibbonControlAdv1.ResumeLayout(False)
        Me.RibbonControlAdv1.PerformLayout()
        Me.ToolStripTabItem1.Panel.ResumeLayout(False)
        Me.ToolStripEx1.ResumeLayout(False)
        Me.ToolStripEx1.PerformLayout()
        Me.ToolStripEx2.ResumeLayout(False)
        Me.ToolStripEx2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RibbonControlAdv1 As Syncfusion.Windows.Forms.Tools.RibbonControlAdv
    Friend WithEvents ToolStripTabItem1 As Syncfusion.Windows.Forms.Tools.ToolStripTabItem
    Friend WithEvents ToolStripEx1 As Syncfusion.Windows.Forms.Tools.ToolStripEx
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents CompraDirectaConRecepciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CompraDirectaSinRecepciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CompraToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripPanelItem1 As Syncfusion.Windows.Forms.Tools.ToolStripPanelItem
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
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
End Class

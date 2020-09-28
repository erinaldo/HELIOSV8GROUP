<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMasterAportes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMasterAportes))
        Dim DockPanelSkin1 As WeifenLuo.WinFormsUI.Docking.DockPanelSkin = New WeifenLuo.WinFormsUI.Docking.DockPanelSkin()
        Dim AutoHideStripSkin1 As WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin = New WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin()
        Dim DockPanelGradient1 As WeifenLuo.WinFormsUI.Docking.DockPanelGradient = New WeifenLuo.WinFormsUI.Docking.DockPanelGradient()
        Dim TabGradient1 As WeifenLuo.WinFormsUI.Docking.TabGradient = New WeifenLuo.WinFormsUI.Docking.TabGradient()
        Dim DockPaneStripSkin1 As WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin = New WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin()
        Dim DockPaneStripGradient1 As WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient = New WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient()
        Dim TabGradient2 As WeifenLuo.WinFormsUI.Docking.TabGradient = New WeifenLuo.WinFormsUI.Docking.TabGradient()
        Dim DockPanelGradient2 As WeifenLuo.WinFormsUI.Docking.DockPanelGradient = New WeifenLuo.WinFormsUI.Docking.DockPanelGradient()
        Dim TabGradient3 As WeifenLuo.WinFormsUI.Docking.TabGradient = New WeifenLuo.WinFormsUI.Docking.TabGradient()
        Dim DockPaneStripToolWindowGradient1 As WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient = New WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient()
        Dim TabGradient4 As WeifenLuo.WinFormsUI.Docking.TabGradient = New WeifenLuo.WinFormsUI.Docking.TabGradient()
        Dim TabGradient5 As WeifenLuo.WinFormsUI.Docking.TabGradient = New WeifenLuo.WinFormsUI.Docking.TabGradient()
        Dim DockPanelGradient3 As WeifenLuo.WinFormsUI.Docking.DockPanelGradient = New WeifenLuo.WinFormsUI.Docking.DockPanelGradient()
        Dim TabGradient6 As WeifenLuo.WinFormsUI.Docking.TabGradient = New WeifenLuo.WinFormsUI.Docking.TabGradient()
        Dim TabGradient7 As WeifenLuo.WinFormsUI.Docking.TabGradient = New WeifenLuo.WinFormsUI.Docking.TabGradient()
        Me.QGlobalColorSchemeManager1 = New Qios.DevSuite.Components.QGlobalColorSchemeManager(Me.components)
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblEstado = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.NuevoToolStripButton = New System.Windows.Forms.ToolStripSplitButton()
        Me.CompraPagadaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConpraAlCréditoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AbrirToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.GuardarToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.DockPanel1 = New WeifenLuo.WinFormsUI.Docking.DockPanel()
        Me.lsvAportes = New System.Windows.Forms.ListView()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripSplitButton()
        Me.PorDiaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PorMesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSplitButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStrip4 = New System.Windows.Forms.ToolStrip()
        Me.lblTitulo = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton()
        Me.lblDescripcion = New System.Windows.Forms.ToolStripButton()
        Me.lblPerido = New System.Windows.Forms.ToolStripLabel()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cboPeriodo = New System.Windows.Forms.ToolStripComboBox()
        Me.QGlobalColorSchemeManager2 = New Qios.DevSuite.Components.QGlobalColorSchemeManager(Me.components)
        Me.lblhasta = New System.Windows.Forms.Label()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.lbldesde = New System.Windows.Forms.Label()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.ToolStrip3.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.ToolStrip4.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip3
        '
        Me.ToolStrip3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ToolStrip3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip3.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.ToolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator3, Me.lblEstado, Me.ToolStripSeparator1, Me.NuevoToolStripButton, Me.AbrirToolStripButton, Me.GuardarToolStripButton, Me.toolStripSeparator, Me.ToolStripButton1})
        Me.ToolStrip3.Location = New System.Drawing.Point(0, 28)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.Size = New System.Drawing.Size(777, 25)
        Me.ToolStrip3.TabIndex = 285
        Me.ToolStrip3.Text = "ToolStrip3"
        Me.ToolStrip3.Visible = False
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'lblEstado
        '
        Me.lblEstado.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblEstado.ForeColor = System.Drawing.Color.Navy
        Me.lblEstado.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.ok4
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(101, 22)
        Me.lblEstado.Text = "Lista de Aportes"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'NuevoToolStripButton
        '
        Me.NuevoToolStripButton.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CompraPagadaToolStripMenuItem, Me.ConpraAlCréditoToolStripMenuItem})
        Me.NuevoToolStripButton.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.NuevoToolStripButton.ForeColor = System.Drawing.Color.MidnightBlue
        Me.NuevoToolStripButton.Image = CType(resources.GetObject("NuevoToolStripButton.Image"), System.Drawing.Image)
        Me.NuevoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NuevoToolStripButton.Name = "NuevoToolStripButton"
        Me.NuevoToolStripButton.Size = New System.Drawing.Size(70, 22)
        Me.NuevoToolStripButton.Text = "&Nuevo"
        '
        'CompraPagadaToolStripMenuItem
        '
        Me.CompraPagadaToolStripMenuItem.Name = "CompraPagadaToolStripMenuItem"
        Me.CompraPagadaToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.CompraPagadaToolStripMenuItem.Text = "Compra pagada"
        '
        'ConpraAlCréditoToolStripMenuItem
        '
        Me.ConpraAlCréditoToolStripMenuItem.Name = "ConpraAlCréditoToolStripMenuItem"
        Me.ConpraAlCréditoToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.ConpraAlCréditoToolStripMenuItem.Text = "Compra al crédito"
        '
        'AbrirToolStripButton
        '
        Me.AbrirToolStripButton.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.AbrirToolStripButton.ForeColor = System.Drawing.Color.MidnightBlue
        Me.AbrirToolStripButton.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.pencil
        Me.AbrirToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AbrirToolStripButton.Name = "AbrirToolStripButton"
        Me.AbrirToolStripButton.Size = New System.Drawing.Size(55, 22)
        Me.AbrirToolStripButton.Text = "&Editar"
        '
        'GuardarToolStripButton
        '
        Me.GuardarToolStripButton.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.GuardarToolStripButton.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GuardarToolStripButton.Image = CType(resources.GetObject("GuardarToolStripButton.Image"), System.Drawing.Image)
        Me.GuardarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.GuardarToolStripButton.Name = "GuardarToolStripButton"
        Me.GuardarToolStripButton.Size = New System.Drawing.Size(63, 22)
        Me.GuardarToolStripButton.Text = "Eliminar"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.ToolStripButton1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(116, 22)
        Me.ToolStripButton1.Text = "Consultar compras"
        '
        'DockPanel1
        '
        Me.DockPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DockPanel1.DockBackColor = System.Drawing.Color.Transparent
        Me.DockPanel1.DockLeftPortion = 0.175R
        Me.DockPanel1.Location = New System.Drawing.Point(0, 0)
        Me.DockPanel1.Name = "DockPanel1"
        Me.DockPanel1.Size = New System.Drawing.Size(1006, 333)
        DockPanelGradient1.EndColor = System.Drawing.SystemColors.ControlLight
        DockPanelGradient1.StartColor = System.Drawing.SystemColors.ControlLight
        AutoHideStripSkin1.DockStripGradient = DockPanelGradient1
        TabGradient1.EndColor = System.Drawing.SystemColors.Control
        TabGradient1.StartColor = System.Drawing.SystemColors.Control
        TabGradient1.TextColor = System.Drawing.SystemColors.ControlDarkDark
        AutoHideStripSkin1.TabGradient = TabGradient1
        AutoHideStripSkin1.TextFont = New System.Drawing.Font("Segoe UI", 9.0!)
        DockPanelSkin1.AutoHideStripSkin = AutoHideStripSkin1
        TabGradient2.EndColor = System.Drawing.SystemColors.ControlLightLight
        TabGradient2.StartColor = System.Drawing.SystemColors.ControlLightLight
        TabGradient2.TextColor = System.Drawing.SystemColors.ControlText
        DockPaneStripGradient1.ActiveTabGradient = TabGradient2
        DockPanelGradient2.EndColor = System.Drawing.SystemColors.Control
        DockPanelGradient2.StartColor = System.Drawing.SystemColors.Control
        DockPaneStripGradient1.DockStripGradient = DockPanelGradient2
        TabGradient3.EndColor = System.Drawing.SystemColors.ControlLight
        TabGradient3.StartColor = System.Drawing.SystemColors.ControlLight
        TabGradient3.TextColor = System.Drawing.SystemColors.ControlText
        DockPaneStripGradient1.InactiveTabGradient = TabGradient3
        DockPaneStripSkin1.DocumentGradient = DockPaneStripGradient1
        DockPaneStripSkin1.TextFont = New System.Drawing.Font("Segoe UI", 9.0!)
        TabGradient4.EndColor = System.Drawing.SystemColors.ActiveCaption
        TabGradient4.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        TabGradient4.StartColor = System.Drawing.SystemColors.GradientActiveCaption
        TabGradient4.TextColor = System.Drawing.SystemColors.ActiveCaptionText
        DockPaneStripToolWindowGradient1.ActiveCaptionGradient = TabGradient4
        TabGradient5.EndColor = System.Drawing.SystemColors.Control
        TabGradient5.StartColor = System.Drawing.SystemColors.Control
        TabGradient5.TextColor = System.Drawing.SystemColors.ControlText
        DockPaneStripToolWindowGradient1.ActiveTabGradient = TabGradient5
        DockPanelGradient3.EndColor = System.Drawing.SystemColors.ControlLight
        DockPanelGradient3.StartColor = System.Drawing.SystemColors.ControlLight
        DockPaneStripToolWindowGradient1.DockStripGradient = DockPanelGradient3
        TabGradient6.EndColor = System.Drawing.SystemColors.InactiveCaption
        TabGradient6.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        TabGradient6.StartColor = System.Drawing.SystemColors.GradientInactiveCaption
        TabGradient6.TextColor = System.Drawing.SystemColors.InactiveCaptionText
        DockPaneStripToolWindowGradient1.InactiveCaptionGradient = TabGradient6
        TabGradient7.EndColor = System.Drawing.Color.Transparent
        TabGradient7.StartColor = System.Drawing.Color.Transparent
        TabGradient7.TextColor = System.Drawing.SystemColors.ControlDarkDark
        DockPaneStripToolWindowGradient1.InactiveTabGradient = TabGradient7
        DockPaneStripSkin1.ToolWindowGradient = DockPaneStripToolWindowGradient1
        DockPanelSkin1.DockPaneStripSkin = DockPaneStripSkin1
        Me.DockPanel1.Skin = DockPanelSkin1
        Me.DockPanel1.TabIndex = 287
        '
        'lsvAportes
        '
        Me.lsvAportes.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.lsvAportes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvAportes.FullRowSelect = True
        Me.lsvAportes.GridLines = True
        Me.lsvAportes.HideSelection = False
        Me.lsvAportes.Location = New System.Drawing.Point(0, 50)
        Me.lsvAportes.MultiSelect = False
        Me.lsvAportes.Name = "lsvAportes"
        Me.lsvAportes.Size = New System.Drawing.Size(1006, 283)
        Me.lsvAportes.TabIndex = 292
        Me.lsvAportes.UseCompatibleStateImageBehavior = False
        Me.lsvAportes.View = System.Windows.Forms.View.Details
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.ToolStripLabel1, Me.ToolStripSeparator4, Me.ToolStripSplitButton1, Me.ToolStripButton2, Me.ToolStripButton3, Me.ToolStripSeparator5})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 25)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(1006, 25)
        Me.ToolStrip1.TabIndex = 294
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PorDiaToolStripMenuItem, Me.PorMesToolStripMenuItem})
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.ToolStripLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.ToolStripLabel1.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.ok4
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(116, 22)
        Me.ToolStripLabel1.Text = "Lista de aportes"
        '
        'PorDiaToolStripMenuItem
        '
        Me.PorDiaToolStripMenuItem.Name = "PorDiaToolStripMenuItem"
        Me.PorDiaToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.PorDiaToolStripMenuItem.Text = "Por día"
        '
        'PorMesToolStripMenuItem
        '
        Me.PorMesToolStripMenuItem.Name = "PorMesToolStripMenuItem"
        Me.PorMesToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.PorMesToolStripMenuItem.Text = "Por mes"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSplitButton1
        '
        Me.ToolStripSplitButton1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.ToolStripSplitButton1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.ToolStripSplitButton1.Image = CType(resources.GetObject("ToolStripSplitButton1.Image"), System.Drawing.Image)
        Me.ToolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton1.Name = "ToolStripSplitButton1"
        Me.ToolStripSplitButton1.Size = New System.Drawing.Size(58, 22)
        Me.ToolStripSplitButton1.Text = "&Nuevo"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.ToolStripButton2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.ToolStripButton2.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.ResumeRequest
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(55, 22)
        Me.ToolStripButton2.Text = "&Editar"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.ToolStripButton3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.ToolStripButton3.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.icono_eliminar
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(63, 22)
        Me.ToolStripButton3.Text = "Eliminar"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStrip4
        '
        Me.ToolStrip4.BackColor = System.Drawing.Color.White
        Me.ToolStrip4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip4.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblTitulo, Me.ToolStripButton7, Me.lblDescripcion, Me.lblPerido})
        Me.ToolStrip4.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip4.Name = "ToolStrip4"
        Me.ToolStrip4.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip4.Size = New System.Drawing.Size(1006, 25)
        Me.ToolStrip4.TabIndex = 293
        Me.ToolStrip4.Text = "ToolStrip4"
        '
        'lblTitulo
        '
        Me.lblTitulo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.lblTitulo.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.Information_icon
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(73, 22)
        Me.lblTitulo.Text = "PERIODO:"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton7.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.arrow_circle_135_left
        Me.ToolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton7.Text = "Salir"
        Me.ToolStripButton7.Visible = False
        '
        'lblDescripcion
        '
        Me.lblDescripcion.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblDescripcion.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.lblDescripcion.Image = CType(resources.GetObject("lblDescripcion.Image"), System.Drawing.Image)
        Me.lblDescripcion.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(135, 22)
        Me.lblDescripcion.Text = "LISTADO DE APORTES"
        '
        'lblPerido
        '
        Me.lblPerido.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPerido.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.lblPerido.Name = "lblPerido"
        Me.lblPerido.Size = New System.Drawing.Size(47, 22)
        Me.lblPerido.Text = "01/2014"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cboPeriodo})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(182, 29)
        '
        'cboPeriodo
        '
        Me.cboPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPeriodo.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.cboPeriodo.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.cboPeriodo.Name = "cboPeriodo"
        Me.cboPeriodo.Size = New System.Drawing.Size(121, 21)
        '
        'lblhasta
        '
        Me.lblhasta.AutoSize = True
        Me.lblhasta.BackColor = System.Drawing.Color.Transparent
        Me.lblhasta.Location = New System.Drawing.Point(761, 32)
        Me.lblhasta.Name = "lblhasta"
        Me.lblhasta.Size = New System.Drawing.Size(39, 13)
        Me.lblhasta.TabIndex = 326
        Me.lblhasta.Text = "Hasta:"
        Me.lblhasta.Visible = False
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(447, 31)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(76, 17)
        Me.CheckBox3.TabIndex = 322
        Me.CheckBox3.Text = "Por Rango"
        Me.CheckBox3.UseVisualStyleBackColor = True
        Me.CheckBox3.Visible = False
        '
        'lbldesde
        '
        Me.lbldesde.AutoSize = True
        Me.lbldesde.BackColor = System.Drawing.Color.Transparent
        Me.lbldesde.Location = New System.Drawing.Point(543, 32)
        Me.lbldesde.Name = "lbldesde"
        Me.lbldesde.Size = New System.Drawing.Size(41, 13)
        Me.lbldesde.TabIndex = 325
        Me.lbldesde.Text = "Desde:"
        Me.lbldesde.Visible = False
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.CustomFormat = "dd/MM/yyyy hh:mm:ss tt"
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker2.Location = New System.Drawing.Point(806, 28)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(168, 20)
        Me.DateTimePicker2.TabIndex = 324
        Me.DateTimePicker2.Visible = False
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "dd/MM/yyyy hh:mm:ss tt"
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(590, 28)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(165, 20)
        Me.DateTimePicker1.TabIndex = 323
        Me.DateTimePicker1.Visible = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(315, 31)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(60, 17)
        Me.CheckBox1.TabIndex = 320
        Me.CheckBox1.Text = "Por Dia"
        Me.CheckBox1.UseVisualStyleBackColor = True
        Me.CheckBox1.Visible = False
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(381, 31)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(64, 17)
        Me.CheckBox2.TabIndex = 321
        Me.CheckBox2.Text = "Por Mes"
        Me.CheckBox2.UseVisualStyleBackColor = True
        Me.CheckBox2.Visible = False
        '
        'frmMasterAportes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1006, 333)
        Me.Controls.Add(Me.lblhasta)
        Me.Controls.Add(Me.CheckBox3)
        Me.Controls.Add(Me.lbldesde)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.lsvAportes)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.ToolStrip4)
        Me.Controls.Add(Me.DockPanel1)
        Me.Controls.Add(Me.ToolStrip3)
        Me.Name = "frmMasterAportes"
        Me.Text = "Aporte de Existencias"
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ToolStrip4.ResumeLayout(False)
        Me.ToolStrip4.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents QGlobalColorSchemeManager1 As Qios.DevSuite.Components.QGlobalColorSchemeManager
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblEstado As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents NuevoToolStripButton As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents CompraPagadaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConpraAlCréditoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AbrirToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents GuardarToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents DockPanel1 As WeifenLuo.WinFormsUI.Docking.DockPanel
    Friend WithEvents lsvAportes As System.Windows.Forms.ListView
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStrip4 As System.Windows.Forms.ToolStrip
    Friend WithEvents lblTitulo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblDescripcion As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblPerido As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cboPeriodo As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents QGlobalColorSchemeManager2 As Qios.DevSuite.Components.QGlobalColorSchemeManager
    Friend WithEvents lblhasta As System.Windows.Forms.Label
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents lbldesde As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents PorDiaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PorMesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSplitButton1 As System.Windows.Forms.ToolStripButton
End Class

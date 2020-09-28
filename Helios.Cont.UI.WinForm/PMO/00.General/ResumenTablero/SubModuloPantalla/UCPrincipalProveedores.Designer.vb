<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UCPrincipalProveedores
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCPrincipalProveedores))
        Dim GridColumnDescriptor37 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor38 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor39 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor40 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor41 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor42 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor43 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor44 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor45 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridSummaryRowDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor()
        Dim GridSummaryColumnDescriptor21 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor()
        Dim GridSummaryColumnDescriptor22 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor()
        Dim GridSummaryColumnDescriptor23 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor()
        Dim GridSummaryColumnDescriptor24 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor()
        Dim GridSummaryColumnDescriptor25 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor()
        Me.PanelTop = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.btnDocumentos = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.btnVerDetalle = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.btnImprimir = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.btnImportarExcel = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.btnEditarCliente = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.btnRegistrar = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.BunifuCustomLabel1 = New Bunifu.Framework.UI.BunifuCustomLabel()
        Me.txtBuscarProveedor = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.BunifuFlatButton1 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.BunifuFlatButton2 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.btnKardex = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.sliderTop = New System.Windows.Forms.PictureBox()
        Me.PanelBody = New System.Windows.Forms.Panel()
        Me.DgvProveedores = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        CType(Me.PanelTop, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelTop.SuspendLayout()
        CType(Me.txtBuscarProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sliderTop, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBody.SuspendLayout()
        CType(Me.DgvProveedores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(176, Byte), Integer), CType(CType(162, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.PanelTop.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.PanelTop.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.PanelTop.Controls.Add(Me.btnDocumentos)
        Me.PanelTop.Controls.Add(Me.btnVerDetalle)
        Me.PanelTop.Controls.Add(Me.btnImprimir)
        Me.PanelTop.Controls.Add(Me.btnImportarExcel)
        Me.PanelTop.Controls.Add(Me.btnEditarCliente)
        Me.PanelTop.Controls.Add(Me.btnRegistrar)
        Me.PanelTop.Controls.Add(Me.BunifuCustomLabel1)
        Me.PanelTop.Controls.Add(Me.txtBuscarProveedor)
        Me.PanelTop.Controls.Add(Me.BunifuFlatButton1)
        Me.PanelTop.Controls.Add(Me.BunifuFlatButton2)
        Me.PanelTop.Controls.Add(Me.btnKardex)
        Me.PanelTop.Controls.Add(Me.sliderTop)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Margin = New System.Windows.Forms.Padding(2)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(994, 60)
        Me.PanelTop.TabIndex = 3
        '
        'btnDocumentos
        '
        Me.btnDocumentos.Activecolor = System.Drawing.Color.Chocolate
        Me.btnDocumentos.BackColor = System.Drawing.Color.Chocolate
        Me.btnDocumentos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDocumentos.BorderRadius = 7
        Me.btnDocumentos.ButtonText = "Ver Detalle"
        Me.btnDocumentos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDocumentos.DisabledColor = System.Drawing.Color.Gray
        Me.btnDocumentos.Iconcolor = System.Drawing.Color.Transparent
        Me.btnDocumentos.Iconimage = CType(resources.GetObject("btnDocumentos.Iconimage"), System.Drawing.Image)
        Me.btnDocumentos.Iconimage_right = Nothing
        Me.btnDocumentos.Iconimage_right_Selected = Nothing
        Me.btnDocumentos.Iconimage_Selected = Nothing
        Me.btnDocumentos.IconMarginLeft = 0
        Me.btnDocumentos.IconMarginRight = 0
        Me.btnDocumentos.IconRightVisible = True
        Me.btnDocumentos.IconRightZoom = 0R
        Me.btnDocumentos.IconVisible = True
        Me.btnDocumentos.IconZoom = 40.0R
        Me.btnDocumentos.IsTab = True
        Me.btnDocumentos.Location = New System.Drawing.Point(648, 22)
        Me.btnDocumentos.Name = "btnDocumentos"
        Me.btnDocumentos.Normalcolor = System.Drawing.Color.Chocolate
        Me.btnDocumentos.OnHovercolor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnDocumentos.OnHoverTextColor = System.Drawing.Color.White
        Me.btnDocumentos.selected = False
        Me.btnDocumentos.Size = New System.Drawing.Size(26, 25)
        Me.btnDocumentos.TabIndex = 783
        Me.btnDocumentos.Text = "Ver Detalle"
        Me.btnDocumentos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnDocumentos.Textcolor = System.Drawing.Color.White
        Me.btnDocumentos.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'btnVerDetalle
        '
        Me.btnVerDetalle.Activecolor = System.Drawing.Color.MediumPurple
        Me.btnVerDetalle.BackColor = System.Drawing.Color.MediumPurple
        Me.btnVerDetalle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnVerDetalle.BorderRadius = 7
        Me.btnVerDetalle.ButtonText = "Ver Detalle"
        Me.btnVerDetalle.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnVerDetalle.DisabledColor = System.Drawing.Color.Gray
        Me.btnVerDetalle.Iconcolor = System.Drawing.Color.Transparent
        Me.btnVerDetalle.Iconimage = CType(resources.GetObject("btnVerDetalle.Iconimage"), System.Drawing.Image)
        Me.btnVerDetalle.Iconimage_right = Nothing
        Me.btnVerDetalle.Iconimage_right_Selected = Nothing
        Me.btnVerDetalle.Iconimage_Selected = Nothing
        Me.btnVerDetalle.IconMarginLeft = 0
        Me.btnVerDetalle.IconMarginRight = 0
        Me.btnVerDetalle.IconRightVisible = True
        Me.btnVerDetalle.IconRightZoom = 0R
        Me.btnVerDetalle.IconVisible = True
        Me.btnVerDetalle.IconZoom = 40.0R
        Me.btnVerDetalle.IsTab = True
        Me.btnVerDetalle.Location = New System.Drawing.Point(593, 22)
        Me.btnVerDetalle.Name = "btnVerDetalle"
        Me.btnVerDetalle.Normalcolor = System.Drawing.Color.MediumPurple
        Me.btnVerDetalle.OnHovercolor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnVerDetalle.OnHoverTextColor = System.Drawing.Color.White
        Me.btnVerDetalle.selected = False
        Me.btnVerDetalle.Size = New System.Drawing.Size(26, 25)
        Me.btnVerDetalle.TabIndex = 782
        Me.btnVerDetalle.Text = "Ver Detalle"
        Me.btnVerDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnVerDetalle.Textcolor = System.Drawing.Color.White
        Me.btnVerDetalle.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'btnImprimir
        '
        Me.btnImprimir.Activecolor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnImprimir.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnImprimir.BorderRadius = 7
        Me.btnImprimir.ButtonText = "Imprimir"
        Me.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnImprimir.DisabledColor = System.Drawing.Color.Gray
        Me.btnImprimir.Iconcolor = System.Drawing.Color.Transparent
        Me.btnImprimir.Iconimage = CType(resources.GetObject("btnImprimir.Iconimage"), System.Drawing.Image)
        Me.btnImprimir.Iconimage_right = Nothing
        Me.btnImprimir.Iconimage_right_Selected = Nothing
        Me.btnImprimir.Iconimage_Selected = Nothing
        Me.btnImprimir.IconMarginLeft = 0
        Me.btnImprimir.IconMarginRight = 0
        Me.btnImprimir.IconRightVisible = True
        Me.btnImprimir.IconRightZoom = 0R
        Me.btnImprimir.IconVisible = True
        Me.btnImprimir.IconZoom = 50.0R
        Me.btnImprimir.IsTab = True
        Me.btnImprimir.Location = New System.Drawing.Point(565, 22)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Normalcolor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnImprimir.OnHovercolor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnImprimir.OnHoverTextColor = System.Drawing.Color.White
        Me.btnImprimir.selected = False
        Me.btnImprimir.Size = New System.Drawing.Size(26, 25)
        Me.btnImprimir.TabIndex = 781
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnImprimir.Textcolor = System.Drawing.Color.White
        Me.btnImprimir.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'btnImportarExcel
        '
        Me.btnImportarExcel.Activecolor = System.Drawing.Color.Black
        Me.btnImportarExcel.BackColor = System.Drawing.Color.SeaGreen
        Me.btnImportarExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnImportarExcel.BorderRadius = 7
        Me.btnImportarExcel.ButtonText = "Exportar Excel"
        Me.btnImportarExcel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnImportarExcel.DisabledColor = System.Drawing.Color.Gray
        Me.btnImportarExcel.Iconcolor = System.Drawing.Color.Transparent
        Me.btnImportarExcel.Iconimage = CType(resources.GetObject("btnImportarExcel.Iconimage"), System.Drawing.Image)
        Me.btnImportarExcel.Iconimage_right = Nothing
        Me.btnImportarExcel.Iconimage_right_Selected = Nothing
        Me.btnImportarExcel.Iconimage_Selected = Nothing
        Me.btnImportarExcel.IconMarginLeft = 0
        Me.btnImportarExcel.IconMarginRight = 0
        Me.btnImportarExcel.IconRightVisible = True
        Me.btnImportarExcel.IconRightZoom = 0R
        Me.btnImportarExcel.IconVisible = True
        Me.btnImportarExcel.IconZoom = 40.0R
        Me.btnImportarExcel.IsTab = True
        Me.btnImportarExcel.Location = New System.Drawing.Point(621, 22)
        Me.btnImportarExcel.Name = "btnImportarExcel"
        Me.btnImportarExcel.Normalcolor = System.Drawing.Color.SeaGreen
        Me.btnImportarExcel.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(188, Byte), Integer))
        Me.btnImportarExcel.OnHoverTextColor = System.Drawing.Color.White
        Me.btnImportarExcel.selected = False
        Me.btnImportarExcel.Size = New System.Drawing.Size(25, 25)
        Me.btnImportarExcel.TabIndex = 780
        Me.btnImportarExcel.Text = "Exportar Excel"
        Me.btnImportarExcel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnImportarExcel.Textcolor = System.Drawing.Color.White
        Me.btnImportarExcel.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'btnEditarCliente
        '
        Me.btnEditarCliente.Activecolor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.btnEditarCliente.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.btnEditarCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnEditarCliente.BorderRadius = 5
        Me.btnEditarCliente.ButtonText = "Editar"
        Me.btnEditarCliente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEditarCliente.DisabledColor = System.Drawing.Color.Gray
        Me.btnEditarCliente.Iconcolor = System.Drawing.Color.Transparent
        Me.btnEditarCliente.Iconimage = CType(resources.GetObject("btnEditarCliente.Iconimage"), System.Drawing.Image)
        Me.btnEditarCliente.Iconimage_right = Nothing
        Me.btnEditarCliente.Iconimage_right_Selected = Nothing
        Me.btnEditarCliente.Iconimage_Selected = Nothing
        Me.btnEditarCliente.IconMarginLeft = 0
        Me.btnEditarCliente.IconMarginRight = 0
        Me.btnEditarCliente.IconRightVisible = True
        Me.btnEditarCliente.IconRightZoom = 0R
        Me.btnEditarCliente.IconVisible = True
        Me.btnEditarCliente.IconZoom = 40.0R
        Me.btnEditarCliente.IsTab = False
        Me.btnEditarCliente.Location = New System.Drawing.Point(108, 29)
        Me.btnEditarCliente.Name = "btnEditarCliente"
        Me.btnEditarCliente.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.btnEditarCliente.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.btnEditarCliente.OnHoverTextColor = System.Drawing.Color.White
        Me.btnEditarCliente.selected = False
        Me.btnEditarCliente.Size = New System.Drawing.Size(69, 24)
        Me.btnEditarCliente.TabIndex = 779
        Me.btnEditarCliente.Text = "Editar"
        Me.btnEditarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEditarCliente.Textcolor = System.Drawing.Color.White
        Me.btnEditarCliente.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'btnRegistrar
        '
        Me.btnRegistrar.Activecolor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(188, Byte), Integer))
        Me.btnRegistrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(188, Byte), Integer))
        Me.btnRegistrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRegistrar.BorderRadius = 5
        Me.btnRegistrar.ButtonText = "Registrar"
        Me.btnRegistrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRegistrar.DisabledColor = System.Drawing.Color.Gray
        Me.btnRegistrar.Iconcolor = System.Drawing.Color.Transparent
        Me.btnRegistrar.Iconimage = CType(resources.GetObject("btnRegistrar.Iconimage"), System.Drawing.Image)
        Me.btnRegistrar.Iconimage_right = Nothing
        Me.btnRegistrar.Iconimage_right_Selected = Nothing
        Me.btnRegistrar.Iconimage_Selected = Nothing
        Me.btnRegistrar.IconMarginLeft = 0
        Me.btnRegistrar.IconMarginRight = 0
        Me.btnRegistrar.IconRightVisible = True
        Me.btnRegistrar.IconRightZoom = 0R
        Me.btnRegistrar.IconVisible = True
        Me.btnRegistrar.IconZoom = 40.0R
        Me.btnRegistrar.IsTab = False
        Me.btnRegistrar.Location = New System.Drawing.Point(16, 29)
        Me.btnRegistrar.Name = "btnRegistrar"
        Me.btnRegistrar.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(188, Byte), Integer))
        Me.btnRegistrar.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(188, Byte), Integer))
        Me.btnRegistrar.OnHoverTextColor = System.Drawing.Color.White
        Me.btnRegistrar.selected = False
        Me.btnRegistrar.Size = New System.Drawing.Size(89, 24)
        Me.btnRegistrar.TabIndex = 778
        Me.btnRegistrar.Text = "Registrar"
        Me.btnRegistrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRegistrar.Textcolor = System.Drawing.Color.White
        Me.btnRegistrar.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'BunifuCustomLabel1
        '
        Me.BunifuCustomLabel1.AutoSize = True
        Me.BunifuCustomLabel1.ForeColor = System.Drawing.Color.White
        Me.BunifuCustomLabel1.Location = New System.Drawing.Point(191, 29)
        Me.BunifuCustomLabel1.Name = "BunifuCustomLabel1"
        Me.BunifuCustomLabel1.Size = New System.Drawing.Size(95, 13)
        Me.BunifuCustomLabel1.TabIndex = 777
        Me.BunifuCustomLabel1.Text = "Buscar Proveedor:"
        '
        'txtBuscarProveedor
        '
        Me.txtBuscarProveedor.BackColor = System.Drawing.Color.White
        Me.txtBuscarProveedor.BeforeTouchSize = New System.Drawing.Size(271, 22)
        Me.txtBuscarProveedor.BorderColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.txtBuscarProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBuscarProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBuscarProveedor.CornerRadius = 4
        Me.txtBuscarProveedor.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtBuscarProveedor.FarImage = CType(resources.GetObject("txtBuscarProveedor.FarImage"), System.Drawing.Image)
        Me.txtBuscarProveedor.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuscarProveedor.ForeColor = System.Drawing.Color.Black
        Me.txtBuscarProveedor.Location = New System.Drawing.Point(288, 25)
        Me.txtBuscarProveedor.Metrocolor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtBuscarProveedor.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtBuscarProveedor.Name = "txtBuscarProveedor"
        Me.txtBuscarProveedor.Office2007ColorScheme = Syncfusion.Windows.Forms.Office2007Theme.Black
        Me.txtBuscarProveedor.Office2010ColorScheme = Syncfusion.Windows.Forms.Office2010Theme.Black
        Me.txtBuscarProveedor.Size = New System.Drawing.Size(271, 22)
        Me.txtBuscarProveedor.TabIndex = 776
        Me.txtBuscarProveedor.ThemesEnabled = False
        '
        'BunifuFlatButton1
        '
        Me.BunifuFlatButton1.Activecolor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.BunifuFlatButton1.BackColor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton1.BorderRadius = 0
        Me.BunifuFlatButton1.ButtonText = "Gestión de Proveedores"
        Me.BunifuFlatButton1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton1.DisabledColor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton1.Enabled = False
        Me.BunifuFlatButton1.ForeColor = System.Drawing.Color.Black
        Me.BunifuFlatButton1.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton1.Iconimage = CType(resources.GetObject("BunifuFlatButton1.Iconimage"), System.Drawing.Image)
        Me.BunifuFlatButton1.Iconimage_right = Nothing
        Me.BunifuFlatButton1.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton1.Iconimage_Selected = Nothing
        Me.BunifuFlatButton1.IconMarginLeft = 0
        Me.BunifuFlatButton1.IconMarginRight = 0
        Me.BunifuFlatButton1.IconRightVisible = True
        Me.BunifuFlatButton1.IconRightZoom = 0R
        Me.BunifuFlatButton1.IconVisible = True
        Me.BunifuFlatButton1.IconZoom = 50.0R
        Me.BunifuFlatButton1.IsTab = False
        Me.BunifuFlatButton1.Location = New System.Drawing.Point(3, 3)
        Me.BunifuFlatButton1.Name = "BunifuFlatButton1"
        Me.BunifuFlatButton1.Normalcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton1.OnHovercolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton1.OnHoverTextColor = System.Drawing.Color.White
        Me.BunifuFlatButton1.selected = False
        Me.BunifuFlatButton1.Size = New System.Drawing.Size(182, 24)
        Me.BunifuFlatButton1.TabIndex = 769
        Me.BunifuFlatButton1.Text = "Gestión de Proveedores"
        Me.BunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BunifuFlatButton1.Textcolor = System.Drawing.Color.White
        Me.BunifuFlatButton1.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'BunifuFlatButton2
        '
        Me.BunifuFlatButton2.Activecolor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.BunifuFlatButton2.BackColor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton2.BorderRadius = 0
        Me.BunifuFlatButton2.ButtonText = ""
        Me.BunifuFlatButton2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton2.DisabledColor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton2.Enabled = False
        Me.BunifuFlatButton2.ForeColor = System.Drawing.Color.Black
        Me.BunifuFlatButton2.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton2.Iconimage = CType(resources.GetObject("BunifuFlatButton2.Iconimage"), System.Drawing.Image)
        Me.BunifuFlatButton2.Iconimage_right = Nothing
        Me.BunifuFlatButton2.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton2.Iconimage_Selected = Nothing
        Me.BunifuFlatButton2.IconMarginLeft = 0
        Me.BunifuFlatButton2.IconMarginRight = 0
        Me.BunifuFlatButton2.IconRightVisible = True
        Me.BunifuFlatButton2.IconRightZoom = 0R
        Me.BunifuFlatButton2.IconVisible = True
        Me.BunifuFlatButton2.IconZoom = 60.0R
        Me.BunifuFlatButton2.IsTab = False
        Me.BunifuFlatButton2.Location = New System.Drawing.Point(723, 81)
        Me.BunifuFlatButton2.Name = "BunifuFlatButton2"
        Me.BunifuFlatButton2.Normalcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton2.OnHovercolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton2.OnHoverTextColor = System.Drawing.Color.White
        Me.BunifuFlatButton2.selected = False
        Me.BunifuFlatButton2.Size = New System.Drawing.Size(35, 29)
        Me.BunifuFlatButton2.TabIndex = 768
        Me.BunifuFlatButton2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BunifuFlatButton2.Textcolor = System.Drawing.Color.White
        Me.BunifuFlatButton2.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton2.Visible = False
        '
        'btnKardex
        '
        Me.btnKardex.Activecolor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnKardex.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnKardex.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnKardex.BorderRadius = 0
        Me.btnKardex.ButtonText = "PROVEEDORES"
        Me.btnKardex.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnKardex.DisabledColor = System.Drawing.Color.Gray
        Me.btnKardex.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnKardex.Iconcolor = System.Drawing.Color.Transparent
        Me.btnKardex.Iconimage = Nothing
        Me.btnKardex.Iconimage_right = Nothing
        Me.btnKardex.Iconimage_right_Selected = Nothing
        Me.btnKardex.Iconimage_Selected = Nothing
        Me.btnKardex.IconMarginLeft = 0
        Me.btnKardex.IconMarginRight = 0
        Me.btnKardex.IconRightVisible = True
        Me.btnKardex.IconRightZoom = 0R
        Me.btnKardex.IconVisible = True
        Me.btnKardex.IconZoom = 90.0R
        Me.btnKardex.IsTab = False
        Me.btnKardex.Location = New System.Drawing.Point(760, 88)
        Me.btnKardex.Margin = New System.Windows.Forms.Padding(2)
        Me.btnKardex.Name = "btnKardex"
        Me.btnKardex.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(83, Byte), Integer))
        Me.btnKardex.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.btnKardex.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.btnKardex.selected = False
        Me.btnKardex.Size = New System.Drawing.Size(110, 18)
        Me.btnKardex.TabIndex = 766
        Me.btnKardex.Text = "PROVEEDORES"
        Me.btnKardex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnKardex.Textcolor = System.Drawing.Color.White
        Me.btnKardex.TextFont = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnKardex.Visible = False
        '
        'sliderTop
        '
        Me.sliderTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(121, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.sliderTop.Location = New System.Drawing.Point(760, 111)
        Me.sliderTop.Name = "sliderTop"
        Me.sliderTop.Size = New System.Drawing.Size(105, 6)
        Me.sliderTop.TabIndex = 765
        Me.sliderTop.TabStop = False
        Me.sliderTop.Visible = False
        '
        'PanelBody
        '
        Me.PanelBody.BackColor = System.Drawing.Color.White
        Me.PanelBody.Controls.Add(Me.DgvProveedores)
        Me.PanelBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelBody.Location = New System.Drawing.Point(0, 60)
        Me.PanelBody.Name = "PanelBody"
        Me.PanelBody.Size = New System.Drawing.Size(994, 511)
        Me.PanelBody.TabIndex = 4
        '
        'DgvProveedores
        '
        Me.DgvProveedores.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.DgvProveedores.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        Me.DgvProveedores.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.DgvProveedores.BackColor = System.Drawing.SystemColors.Window
        Me.DgvProveedores.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvProveedores.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvProveedores.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.DgvProveedores.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.DgvProveedores.InvalidateAllWhenListChanged = True
        Me.DgvProveedores.Location = New System.Drawing.Point(0, 0)
        Me.DgvProveedores.Name = "DgvProveedores"
        Me.DgvProveedores.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.DgvProveedores.Size = New System.Drawing.Size(994, 511)
        Me.DgvProveedores.TabIndex = 420
        Me.DgvProveedores.TableDescriptor.AllowNew = False
        GridColumnDescriptor37.MappingName = "idEntidad"
        GridColumnDescriptor37.Width = 0
        GridColumnDescriptor38.HeaderText = "Tipo"
        GridColumnDescriptor38.MappingName = "tipoDoc"
        GridColumnDescriptor38.Width = 70
        GridColumnDescriptor39.HeaderText = "Nº Doc."
        GridColumnDescriptor39.MappingName = "nroDoc"
        GridColumnDescriptor39.Width = 80
        GridColumnDescriptor40.MappingName = "tipo"
        GridColumnDescriptor40.Width = 0
        GridColumnDescriptor41.HeaderText = "Razon Social"
        GridColumnDescriptor41.MappingName = "razon"
        GridColumnDescriptor41.Width = 320
        GridColumnDescriptor42.HeaderText = "Teléfono"
        GridColumnDescriptor42.MappingName = "fono"
        GridColumnDescriptor42.Width = 70
        GridColumnDescriptor43.HeaderText = "Celular"
        GridColumnDescriptor43.MappingName = "celular"
        GridColumnDescriptor43.Width = 90
        GridColumnDescriptor44.HeaderText = "Correo"
        GridColumnDescriptor44.MappingName = "email"
        GridColumnDescriptor44.Width = 150
        GridColumnDescriptor45.HeaderText = "Dirección"
        GridColumnDescriptor45.MappingName = "direc"
        GridColumnDescriptor45.Width = 170
        Me.DgvProveedores.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor37, GridColumnDescriptor38, GridColumnDescriptor39, GridColumnDescriptor40, GridColumnDescriptor41, GridColumnDescriptor42, GridColumnDescriptor43, GridColumnDescriptor44, GridColumnDescriptor45})
        GridSummaryRowDescriptor5.Name = "Row 1"
        GridSummaryColumnDescriptor21.Appearance.AnySummaryCell.CellType = "Currency"
        GridSummaryColumnDescriptor21.Appearance.AnySummaryCell.CurrencyEdit.CurrencySymbol = ""
        GridSummaryColumnDescriptor21.DataMember = "bi"
        GridSummaryColumnDescriptor21.Format = "{Sum}"
        GridSummaryColumnDescriptor21.Name = "bi"
        GridSummaryColumnDescriptor21.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        GridSummaryColumnDescriptor22.Appearance.AnySummaryCell.CellType = "Currency"
        GridSummaryColumnDescriptor22.Appearance.AnySummaryCell.CurrencyEdit.CurrencySymbol = ""
        GridSummaryColumnDescriptor22.DataMember = "bi02"
        GridSummaryColumnDescriptor22.Format = "{Sum}"
        GridSummaryColumnDescriptor22.Name = "bi02"
        GridSummaryColumnDescriptor22.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        GridSummaryColumnDescriptor23.Appearance.AnySummaryCell.CellType = "Currency"
        GridSummaryColumnDescriptor23.Appearance.AnySummaryCell.CurrencyEdit.CurrencySymbol = ""
        GridSummaryColumnDescriptor23.DataMember = "igv"
        GridSummaryColumnDescriptor23.Format = "{Sum}"
        GridSummaryColumnDescriptor23.Name = "igv"
        GridSummaryColumnDescriptor23.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        GridSummaryColumnDescriptor24.Appearance.AnySummaryCell.CellType = "Currency"
        GridSummaryColumnDescriptor24.Appearance.AnySummaryCell.CurrencyEdit.CurrencySymbol = ""
        GridSummaryColumnDescriptor24.DataMember = "icbper"
        GridSummaryColumnDescriptor24.Format = "{Sum}"
        GridSummaryColumnDescriptor24.Name = "icbper"
        GridSummaryColumnDescriptor24.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        GridSummaryColumnDescriptor25.Appearance.AnySummaryCell.CellType = "Currency"
        GridSummaryColumnDescriptor25.Appearance.AnySummaryCell.CurrencyEdit.CurrencySymbol = ""
        GridSummaryColumnDescriptor25.DataMember = "total"
        GridSummaryColumnDescriptor25.Format = "{Sum}"
        GridSummaryColumnDescriptor25.Name = "total"
        GridSummaryColumnDescriptor25.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        GridSummaryRowDescriptor5.SummaryColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor() {GridSummaryColumnDescriptor21, GridSummaryColumnDescriptor22, GridSummaryColumnDescriptor23, GridSummaryColumnDescriptor24, GridSummaryColumnDescriptor25})
        GridSummaryRowDescriptor5.Title = "Total ventas"
        Me.DgvProveedores.TableDescriptor.SummaryRows.Add(GridSummaryRowDescriptor5)
        Me.DgvProveedores.TableDescriptor.TableOptions.AllowSortColumns = True
        Me.DgvProveedores.TableDescriptor.TableOptions.CaptionRowHeight = 29
        Me.DgvProveedores.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.DgvProveedores.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.DgvProveedores.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("idEntidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipoDoc"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("nroDoc"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipo"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("razon"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("fono"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("celular"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("email"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("direc")})
        Me.DgvProveedores.TableOptions.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.DgvProveedores.TableOptions.SelectionTextColor = System.Drawing.SystemColors.HighlightText
        Me.DgvProveedores.TableOptions.ShowRecordPlusMinus = True
        Me.DgvProveedores.TableOptions.ShowRowHeader = True
        Me.DgvProveedores.TableOptions.ShowTableIndent = True
        Me.DgvProveedores.Text = "GridGroupingControl2"
        Me.DgvProveedores.TopLevelGroupOptions.ShowCaption = False
        Me.DgvProveedores.TopLevelGroupOptions.ShowColumnHeaders = True
        Me.DgvProveedores.UseRightToLeftCompatibleTextBox = True
        Me.DgvProveedores.VersionInfo = "12.4400.0.24"
        '
        'UCPrincipalProveedores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PanelBody)
        Me.Controls.Add(Me.PanelTop)
        Me.Name = "UCPrincipalProveedores"
        Me.Size = New System.Drawing.Size(994, 571)
        CType(Me.PanelTop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelTop.ResumeLayout(False)
        Me.PanelTop.PerformLayout()
        CType(Me.txtBuscarProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sliderTop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBody.ResumeLayout(False)
        CType(Me.DgvProveedores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelTop As Syncfusion.Windows.Forms.Tools.GradientPanel
    Private WithEvents btnKardex As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents sliderTop As PictureBox
    Friend WithEvents PanelBody As Panel
    Friend WithEvents BunifuFlatButton2 As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents BunifuFlatButton1 As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents BunifuCustomLabel1 As Bunifu.Framework.UI.BunifuCustomLabel
    Friend WithEvents txtBuscarProveedor As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents btnEditarCliente As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents btnRegistrar As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents btnDocumentos As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents btnVerDetalle As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents btnImprimir As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents btnImportarExcel As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents DgvProveedores As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UCPrincipalCompras
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
        Dim GridColumnDescriptor13 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor14 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor15 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor16 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridSummaryRowDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor()
        Dim GridSummaryColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor()
        Dim GridSummaryColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor()
        Dim GridSummaryColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor()
        Dim GridSummaryColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor()
        Dim GridSummaryColumnDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCPrincipalCompras))
        Me.PanelTop = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.btnImprimir = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.BunifuFlatButton2 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.cboComprobantesAdicional = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.btnNuevoComprobanteAdicional = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.btnAnularCompra = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.btnBuscarCompra = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.btnImportarExcel = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.cboTipoBusqueda = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.btnNuevaCompra = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.PanelBody = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.DgvComprobantes = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.btnVerDetalle = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.PictureLoad = New System.Windows.Forms.PictureBox()
        CType(Me.PanelTop, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelTop.SuspendLayout()
        CType(Me.cboComprobantesAdicional, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTipoBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelBody, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBody.SuspendLayout()
        CType(Me.DgvComprobantes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureLoad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.Teal
        Me.PanelTop.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.PanelTop.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.PanelTop.Controls.Add(Me.PictureLoad)
        Me.PanelTop.Controls.Add(Me.btnVerDetalle)
        Me.PanelTop.Controls.Add(Me.btnImprimir)
        Me.PanelTop.Controls.Add(Me.BunifuFlatButton2)
        Me.PanelTop.Controls.Add(Me.cboComprobantesAdicional)
        Me.PanelTop.Controls.Add(Me.btnNuevoComprobanteAdicional)
        Me.PanelTop.Controls.Add(Me.btnAnularCompra)
        Me.PanelTop.Controls.Add(Me.btnBuscarCompra)
        Me.PanelTop.Controls.Add(Me.btnImportarExcel)
        Me.PanelTop.Controls.Add(Me.cboTipoBusqueda)
        Me.PanelTop.Controls.Add(Me.btnNuevaCompra)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Margin = New System.Windows.Forms.Padding(2)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(994, 60)
        Me.PanelTop.TabIndex = 2
        '
        'btnImprimir
        '
        Me.btnImprimir.Activecolor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnImprimir.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnImprimir.BorderRadius = 7
        Me.btnImprimir.ButtonText = ""
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
        Me.btnImprimir.Location = New System.Drawing.Point(442, 30)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Normalcolor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnImprimir.OnHovercolor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnImprimir.OnHoverTextColor = System.Drawing.Color.White
        Me.btnImprimir.selected = False
        Me.btnImprimir.Size = New System.Drawing.Size(26, 25)
        Me.btnImprimir.TabIndex = 764
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnImprimir.Textcolor = System.Drawing.Color.White
        Me.btnImprimir.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'BunifuFlatButton2
        '
        Me.BunifuFlatButton2.Activecolor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.BunifuFlatButton2.BackColor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton2.BorderRadius = 0
        Me.BunifuFlatButton2.ButtonText = "Registro de Compras"
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
        Me.BunifuFlatButton2.IconZoom = 35.0R
        Me.BunifuFlatButton2.IsTab = False
        Me.BunifuFlatButton2.Location = New System.Drawing.Point(10, 3)
        Me.BunifuFlatButton2.Name = "BunifuFlatButton2"
        Me.BunifuFlatButton2.Normalcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton2.OnHovercolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton2.OnHoverTextColor = System.Drawing.Color.White
        Me.BunifuFlatButton2.selected = False
        Me.BunifuFlatButton2.Size = New System.Drawing.Size(164, 24)
        Me.BunifuFlatButton2.TabIndex = 763
        Me.BunifuFlatButton2.Text = "Registro de Compras"
        Me.BunifuFlatButton2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BunifuFlatButton2.Textcolor = System.Drawing.Color.White
        Me.BunifuFlatButton2.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'cboComprobantesAdicional
        '
        Me.cboComprobantesAdicional.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cboComprobantesAdicional.BeforeTouchSize = New System.Drawing.Size(161, 21)
        Me.cboComprobantesAdicional.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboComprobantesAdicional.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboComprobantesAdicional.Items.AddRange(New Object() {"NOTA DE CREDITO", "NOTA DE DEBITO", "GUIA DE REMISON"})
        Me.cboComprobantesAdicional.Location = New System.Drawing.Point(685, 32)
        Me.cboComprobantesAdicional.Name = "cboComprobantesAdicional"
        Me.cboComprobantesAdicional.Size = New System.Drawing.Size(161, 21)
        Me.cboComprobantesAdicional.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016White
        Me.cboComprobantesAdicional.TabIndex = 762
        Me.cboComprobantesAdicional.Text = "NOTA DE CREDITO"
        '
        'btnNuevoComprobanteAdicional
        '
        Me.btnNuevoComprobanteAdicional.Activecolor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.btnNuevoComprobanteAdicional.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnNuevoComprobanteAdicional.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnNuevoComprobanteAdicional.BorderRadius = 5
        Me.btnNuevoComprobanteAdicional.ButtonText = ""
        Me.btnNuevoComprobanteAdicional.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNuevoComprobanteAdicional.DisabledColor = System.Drawing.Color.Gray
        Me.btnNuevoComprobanteAdicional.Iconcolor = System.Drawing.Color.Transparent
        Me.btnNuevoComprobanteAdicional.Iconimage = CType(resources.GetObject("btnNuevoComprobanteAdicional.Iconimage"), System.Drawing.Image)
        Me.btnNuevoComprobanteAdicional.Iconimage_right = Nothing
        Me.btnNuevoComprobanteAdicional.Iconimage_right_Selected = Nothing
        Me.btnNuevoComprobanteAdicional.Iconimage_Selected = Nothing
        Me.btnNuevoComprobanteAdicional.IconMarginLeft = 0
        Me.btnNuevoComprobanteAdicional.IconMarginRight = 0
        Me.btnNuevoComprobanteAdicional.IconRightVisible = True
        Me.btnNuevoComprobanteAdicional.IconRightZoom = 0R
        Me.btnNuevoComprobanteAdicional.IconVisible = True
        Me.btnNuevoComprobanteAdicional.IconZoom = 40.0R
        Me.btnNuevoComprobanteAdicional.IsTab = False
        Me.btnNuevoComprobanteAdicional.Location = New System.Drawing.Point(852, 30)
        Me.btnNuevoComprobanteAdicional.Name = "btnNuevoComprobanteAdicional"
        Me.btnNuevoComprobanteAdicional.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnNuevoComprobanteAdicional.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(77, Byte), Integer))
        Me.btnNuevoComprobanteAdicional.OnHoverTextColor = System.Drawing.Color.White
        Me.btnNuevoComprobanteAdicional.selected = False
        Me.btnNuevoComprobanteAdicional.Size = New System.Drawing.Size(25, 25)
        Me.btnNuevoComprobanteAdicional.TabIndex = 761
        Me.btnNuevoComprobanteAdicional.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevoComprobanteAdicional.Textcolor = System.Drawing.Color.White
        Me.btnNuevoComprobanteAdicional.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'btnAnularCompra
        '
        Me.btnAnularCompra.Activecolor = System.Drawing.Color.Crimson
        Me.btnAnularCompra.BackColor = System.Drawing.Color.Crimson
        Me.btnAnularCompra.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAnularCompra.BorderRadius = 5
        Me.btnAnularCompra.ButtonText = "Anular"
        Me.btnAnularCompra.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAnularCompra.DisabledColor = System.Drawing.Color.Gray
        Me.btnAnularCompra.Iconcolor = System.Drawing.Color.Transparent
        Me.btnAnularCompra.Iconimage = CType(resources.GetObject("btnAnularCompra.Iconimage"), System.Drawing.Image)
        Me.btnAnularCompra.Iconimage_right = Nothing
        Me.btnAnularCompra.Iconimage_right_Selected = Nothing
        Me.btnAnularCompra.Iconimage_Selected = Nothing
        Me.btnAnularCompra.IconMarginLeft = 0
        Me.btnAnularCompra.IconMarginRight = 0
        Me.btnAnularCompra.IconRightVisible = True
        Me.btnAnularCompra.IconRightZoom = 0R
        Me.btnAnularCompra.IconVisible = True
        Me.btnAnularCompra.IconZoom = 40.0R
        Me.btnAnularCompra.IsTab = False
        Me.btnAnularCompra.Location = New System.Drawing.Point(525, 30)
        Me.btnAnularCompra.Name = "btnAnularCompra"
        Me.btnAnularCompra.Normalcolor = System.Drawing.Color.Crimson
        Me.btnAnularCompra.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(77, Byte), Integer))
        Me.btnAnularCompra.OnHoverTextColor = System.Drawing.Color.White
        Me.btnAnularCompra.selected = False
        Me.btnAnularCompra.Size = New System.Drawing.Size(71, 25)
        Me.btnAnularCompra.TabIndex = 759
        Me.btnAnularCompra.Text = "Anular"
        Me.btnAnularCompra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAnularCompra.Textcolor = System.Drawing.Color.White
        Me.btnAnularCompra.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'btnBuscarCompra
        '
        Me.btnBuscarCompra.Activecolor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.btnBuscarCompra.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnBuscarCompra.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBuscarCompra.BorderRadius = 5
        Me.btnBuscarCompra.ButtonText = "Buscar"
        Me.btnBuscarCompra.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscarCompra.DisabledColor = System.Drawing.Color.Gray
        Me.btnBuscarCompra.Iconcolor = System.Drawing.Color.Transparent
        Me.btnBuscarCompra.Iconimage = CType(resources.GetObject("btnBuscarCompra.Iconimage"), System.Drawing.Image)
        Me.btnBuscarCompra.Iconimage_right = Nothing
        Me.btnBuscarCompra.Iconimage_right_Selected = Nothing
        Me.btnBuscarCompra.Iconimage_Selected = Nothing
        Me.btnBuscarCompra.IconMarginLeft = 0
        Me.btnBuscarCompra.IconMarginRight = 0
        Me.btnBuscarCompra.IconRightVisible = True
        Me.btnBuscarCompra.IconRightZoom = 0R
        Me.btnBuscarCompra.IconVisible = True
        Me.btnBuscarCompra.IconZoom = 40.0R
        Me.btnBuscarCompra.IsTab = False
        Me.btnBuscarCompra.Location = New System.Drawing.Point(355, 30)
        Me.btnBuscarCompra.Name = "btnBuscarCompra"
        Me.btnBuscarCompra.Normalcolor = System.Drawing.SystemColors.Highlight
        Me.btnBuscarCompra.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(77, Byte), Integer))
        Me.btnBuscarCompra.OnHoverTextColor = System.Drawing.Color.White
        Me.btnBuscarCompra.selected = False
        Me.btnBuscarCompra.Size = New System.Drawing.Size(81, 25)
        Me.btnBuscarCompra.TabIndex = 758
        Me.btnBuscarCompra.Text = "Buscar"
        Me.btnBuscarCompra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarCompra.Textcolor = System.Drawing.Color.White
        Me.btnBuscarCompra.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'btnImportarExcel
        '
        Me.btnImportarExcel.Activecolor = System.Drawing.Color.Black
        Me.btnImportarExcel.BackColor = System.Drawing.Color.SeaGreen
        Me.btnImportarExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnImportarExcel.BorderRadius = 7
        Me.btnImportarExcel.ButtonText = ""
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
        Me.btnImportarExcel.Location = New System.Drawing.Point(496, 30)
        Me.btnImportarExcel.Name = "btnImportarExcel"
        Me.btnImportarExcel.Normalcolor = System.Drawing.Color.SeaGreen
        Me.btnImportarExcel.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(188, Byte), Integer))
        Me.btnImportarExcel.OnHoverTextColor = System.Drawing.Color.White
        Me.btnImportarExcel.selected = False
        Me.btnImportarExcel.Size = New System.Drawing.Size(26, 25)
        Me.btnImportarExcel.TabIndex = 746
        Me.btnImportarExcel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnImportarExcel.Textcolor = System.Drawing.Color.White
        Me.btnImportarExcel.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'cboTipoBusqueda
        '
        Me.cboTipoBusqueda.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cboTipoBusqueda.BeforeTouchSize = New System.Drawing.Size(161, 21)
        Me.cboTipoBusqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoBusqueda.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoBusqueda.Items.AddRange(New Object() {"COMPRAS DEL PERIODO", "COMPRAS POR PROVEEDOR", "BUSCAR COMPROBANTE"})
        Me.cboTipoBusqueda.Location = New System.Drawing.Point(188, 32)
        Me.cboTipoBusqueda.Name = "cboTipoBusqueda"
        Me.cboTipoBusqueda.Size = New System.Drawing.Size(161, 21)
        Me.cboTipoBusqueda.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016White
        Me.cboTipoBusqueda.TabIndex = 757
        Me.cboTipoBusqueda.Text = "COMPRAS DEL PERIODO"
        '
        'btnNuevaCompra
        '
        Me.btnNuevaCompra.Activecolor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnNuevaCompra.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnNuevaCompra.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnNuevaCompra.BorderRadius = 5
        Me.btnNuevaCompra.ButtonText = "Compra"
        Me.btnNuevaCompra.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNuevaCompra.DisabledColor = System.Drawing.Color.Gray
        Me.btnNuevaCompra.Iconcolor = System.Drawing.Color.Transparent
        Me.btnNuevaCompra.Iconimage = CType(resources.GetObject("btnNuevaCompra.Iconimage"), System.Drawing.Image)
        Me.btnNuevaCompra.Iconimage_right = Nothing
        Me.btnNuevaCompra.Iconimage_right_Selected = Nothing
        Me.btnNuevaCompra.Iconimage_Selected = Nothing
        Me.btnNuevaCompra.IconMarginLeft = 0
        Me.btnNuevaCompra.IconMarginRight = 0
        Me.btnNuevaCompra.IconRightVisible = True
        Me.btnNuevaCompra.IconRightZoom = 0R
        Me.btnNuevaCompra.IconVisible = True
        Me.btnNuevaCompra.IconZoom = 40.0R
        Me.btnNuevaCompra.IsTab = False
        Me.btnNuevaCompra.Location = New System.Drawing.Point(10, 30)
        Me.btnNuevaCompra.Name = "btnNuevaCompra"
        Me.btnNuevaCompra.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnNuevaCompra.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(77, Byte), Integer))
        Me.btnNuevaCompra.OnHoverTextColor = System.Drawing.Color.White
        Me.btnNuevaCompra.selected = False
        Me.btnNuevaCompra.Size = New System.Drawing.Size(83, 25)
        Me.btnNuevaCompra.TabIndex = 753
        Me.btnNuevaCompra.Text = "Compra"
        Me.btnNuevaCompra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevaCompra.Textcolor = System.Drawing.Color.White
        Me.btnNuevaCompra.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'PanelBody
        '
        Me.PanelBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelBody.Controls.Add(Me.DgvComprobantes)
        Me.PanelBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelBody.Location = New System.Drawing.Point(0, 60)
        Me.PanelBody.Margin = New System.Windows.Forms.Padding(2)
        Me.PanelBody.Name = "PanelBody"
        Me.PanelBody.Size = New System.Drawing.Size(994, 511)
        Me.PanelBody.TabIndex = 4
        '
        'DgvComprobantes
        '
        Me.DgvComprobantes.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.DgvComprobantes.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        Me.DgvComprobantes.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.DgvComprobantes.BackColor = System.Drawing.SystemColors.Window
        Me.DgvComprobantes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgvComprobantes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvComprobantes.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.DgvComprobantes.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.DgvComprobantes.InvalidateAllWhenListChanged = True
        Me.DgvComprobantes.Location = New System.Drawing.Point(0, 0)
        Me.DgvComprobantes.Name = "DgvComprobantes"
        Me.DgvComprobantes.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.DgvComprobantes.Size = New System.Drawing.Size(992, 509)
        Me.DgvComprobantes.TabIndex = 419
        Me.DgvComprobantes.TableDescriptor.AllowNew = False
        GridColumnDescriptor1.MappingName = "idDocumento"
        GridColumnDescriptor1.Width = 0
        GridColumnDescriptor2.HeaderText = "Fecha"
        GridColumnDescriptor2.MappingName = "fechaDoc"
        GridColumnDescriptor2.ReadOnly = True
        GridColumnDescriptor2.Width = 100
        GridColumnDescriptor3.MappingName = "tipoDocumento"
        GridColumnDescriptor3.ReadOnly = True
        GridColumnDescriptor3.Width = 0
        GridColumnDescriptor4.HeaderText = "Tipo"
        GridColumnDescriptor4.MappingName = "comprobante"
        GridColumnDescriptor4.ReadOnly = True
        GridColumnDescriptor4.Width = 70
        GridColumnDescriptor5.HeaderText = "Serie"
        GridColumnDescriptor5.MappingName = "serie"
        GridColumnDescriptor5.ReadOnly = True
        GridColumnDescriptor5.Width = 70
        GridColumnDescriptor6.HeaderText = "Numero"
        GridColumnDescriptor6.MappingName = "numero"
        GridColumnDescriptor6.Width = 80
        GridColumnDescriptor7.HeaderText = "Ruc/Dni"
        GridColumnDescriptor7.MappingName = "NroDocEntidad"
        GridColumnDescriptor7.Width = 80
        GridColumnDescriptor8.HeaderText = "Razon Social"
        GridColumnDescriptor8.MappingName = "NombreEntidad"
        GridColumnDescriptor8.ReadOnly = True
        GridColumnDescriptor8.Width = 180
        GridColumnDescriptor9.HeaderText = "Grav."
        GridColumnDescriptor9.MappingName = "bi"
        GridColumnDescriptor9.Width = 70
        GridColumnDescriptor10.HeaderText = "Exo."
        GridColumnDescriptor10.MappingName = "bi02"
        GridColumnDescriptor10.Width = 70
        GridColumnDescriptor11.HeaderText = "Igv"
        GridColumnDescriptor11.MappingName = "igv"
        GridColumnDescriptor11.ReadOnly = True
        GridColumnDescriptor11.Width = 70
        GridColumnDescriptor12.HeaderText = "Icbper"
        GridColumnDescriptor12.MappingName = "icbper"
        GridColumnDescriptor12.ReadOnly = True
        GridColumnDescriptor12.Width = 70
        GridColumnDescriptor13.HeaderText = "Total"
        GridColumnDescriptor13.MappingName = "total"
        GridColumnDescriptor13.ReadOnly = True
        GridColumnDescriptor13.Width = 70
        GridColumnDescriptor14.HeaderText = "Estado"
        GridColumnDescriptor14.MappingName = "estado"
        GridColumnDescriptor14.ReadOnly = True
        GridColumnDescriptor14.Width = 70
        GridColumnDescriptor15.HeaderText = "Control"
        GridColumnDescriptor15.MappingName = "aprobado"
        GridColumnDescriptor15.ReadOnly = True
        GridColumnDescriptor15.Width = 70
        GridColumnDescriptor16.MappingName = "tipoCompra"
        GridColumnDescriptor16.Width = 0
        Me.DgvComprobantes.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7, GridColumnDescriptor8, GridColumnDescriptor9, GridColumnDescriptor10, GridColumnDescriptor11, GridColumnDescriptor12, GridColumnDescriptor13, GridColumnDescriptor14, GridColumnDescriptor15, GridColumnDescriptor16})
        GridSummaryRowDescriptor1.Name = "Row 1"
        GridSummaryColumnDescriptor1.Appearance.AnySummaryCell.CellType = "Currency"
        GridSummaryColumnDescriptor1.Appearance.AnySummaryCell.CurrencyEdit.CurrencySymbol = ""
        GridSummaryColumnDescriptor1.DataMember = "bi"
        GridSummaryColumnDescriptor1.Format = "{Sum}"
        GridSummaryColumnDescriptor1.Name = "bi"
        GridSummaryColumnDescriptor1.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        GridSummaryColumnDescriptor2.Appearance.AnySummaryCell.CellType = "Currency"
        GridSummaryColumnDescriptor2.Appearance.AnySummaryCell.CurrencyEdit.CurrencySymbol = ""
        GridSummaryColumnDescriptor2.DataMember = "bi02"
        GridSummaryColumnDescriptor2.Format = "{Sum}"
        GridSummaryColumnDescriptor2.Name = "bi02"
        GridSummaryColumnDescriptor2.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        GridSummaryColumnDescriptor3.Appearance.AnySummaryCell.CellType = "Currency"
        GridSummaryColumnDescriptor3.Appearance.AnySummaryCell.CurrencyEdit.CurrencySymbol = ""
        GridSummaryColumnDescriptor3.DataMember = "igv"
        GridSummaryColumnDescriptor3.Format = "{Sum}"
        GridSummaryColumnDescriptor3.Name = "igv"
        GridSummaryColumnDescriptor3.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        GridSummaryColumnDescriptor4.Appearance.AnySummaryCell.CellType = "Currency"
        GridSummaryColumnDescriptor4.Appearance.AnySummaryCell.CurrencyEdit.CurrencySymbol = ""
        GridSummaryColumnDescriptor4.DataMember = "icbper"
        GridSummaryColumnDescriptor4.Format = "{Sum}"
        GridSummaryColumnDescriptor4.Name = "icbper"
        GridSummaryColumnDescriptor4.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        GridSummaryColumnDescriptor5.Appearance.AnySummaryCell.CellType = "Currency"
        GridSummaryColumnDescriptor5.Appearance.AnySummaryCell.CurrencyEdit.CurrencySymbol = ""
        GridSummaryColumnDescriptor5.DataMember = "total"
        GridSummaryColumnDescriptor5.Format = "{Sum}"
        GridSummaryColumnDescriptor5.Name = "total"
        GridSummaryColumnDescriptor5.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        GridSummaryRowDescriptor1.SummaryColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor() {GridSummaryColumnDescriptor1, GridSummaryColumnDescriptor2, GridSummaryColumnDescriptor3, GridSummaryColumnDescriptor4, GridSummaryColumnDescriptor5})
        GridSummaryRowDescriptor1.Title = "Total ventas"
        Me.DgvComprobantes.TableDescriptor.SummaryRows.Add(GridSummaryRowDescriptor1)
        Me.DgvComprobantes.TableDescriptor.TableOptions.AllowSortColumns = True
        Me.DgvComprobantes.TableDescriptor.TableOptions.CaptionRowHeight = 29
        Me.DgvComprobantes.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.DgvComprobantes.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.DgvComprobantes.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("idDocumento"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("fechaDoc"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipoDocumento"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("comprobante"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("serie"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("numero"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("NroDocEntidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("NombreEntidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("bi"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("bi02"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("igv"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("icbper"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("total"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("estado"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("aprobado"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipoCompra")})
        Me.DgvComprobantes.TableOptions.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.DgvComprobantes.TableOptions.SelectionTextColor = System.Drawing.SystemColors.HighlightText
        Me.DgvComprobantes.TableOptions.ShowRecordPlusMinus = True
        Me.DgvComprobantes.TableOptions.ShowRowHeader = True
        Me.DgvComprobantes.TableOptions.ShowTableIndent = True
        Me.DgvComprobantes.Text = "GridGroupingControl2"
        Me.DgvComprobantes.TopLevelGroupOptions.ShowCaption = False
        Me.DgvComprobantes.TopLevelGroupOptions.ShowColumnHeaders = True
        Me.DgvComprobantes.UseRightToLeftCompatibleTextBox = True
        Me.DgvComprobantes.VersionInfo = "12.4400.0.24"
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
        Me.btnVerDetalle.Location = New System.Drawing.Point(468, 30)
        Me.btnVerDetalle.Name = "btnVerDetalle"
        Me.btnVerDetalle.Normalcolor = System.Drawing.Color.MediumPurple
        Me.btnVerDetalle.OnHovercolor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnVerDetalle.OnHoverTextColor = System.Drawing.Color.White
        Me.btnVerDetalle.selected = False
        Me.btnVerDetalle.Size = New System.Drawing.Size(26, 25)
        Me.btnVerDetalle.TabIndex = 767
        Me.btnVerDetalle.Text = "Ver Detalle"
        Me.btnVerDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnVerDetalle.Textcolor = System.Drawing.Color.White
        Me.btnVerDetalle.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'PictureLoad
        '
        Me.PictureLoad.BackColor = System.Drawing.Color.Transparent
        Me.PictureLoad.Image = CType(resources.GetObject("PictureLoad.Image"), System.Drawing.Image)
        Me.PictureLoad.Location = New System.Drawing.Point(603, 31)
        Me.PictureLoad.Name = "PictureLoad"
        Me.PictureLoad.Size = New System.Drawing.Size(22, 21)
        Me.PictureLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureLoad.TabIndex = 768
        Me.PictureLoad.TabStop = False
        Me.PictureLoad.Visible = False
        '
        'UCPrincipalCompras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PanelBody)
        Me.Controls.Add(Me.PanelTop)
        Me.Name = "UCPrincipalCompras"
        Me.Size = New System.Drawing.Size(994, 571)
        CType(Me.PanelTop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelTop.ResumeLayout(False)
        CType(Me.cboComprobantesAdicional, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTipoBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelBody, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBody.ResumeLayout(False)
        CType(Me.DgvComprobantes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureLoad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelTop As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents BunifuFlatButton2 As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents cboComprobantesAdicional As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents btnNuevoComprobanteAdicional As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents btnAnularCompra As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents btnBuscarCompra As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents btnImportarExcel As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents cboTipoBusqueda As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents btnNuevaCompra As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents PanelBody As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents DgvComprobantes As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents btnImprimir As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents btnVerDetalle As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents PictureLoad As PictureBox
End Class

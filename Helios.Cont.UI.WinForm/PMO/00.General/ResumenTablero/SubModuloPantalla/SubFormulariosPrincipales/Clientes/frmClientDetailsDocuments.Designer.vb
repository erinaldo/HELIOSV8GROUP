Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmClientDetailsDocuments
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmClientDetailsDocuments))
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
        Me.PanelHeader = New System.Windows.Forms.Panel()
        Me.btnGenerarVenta = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.btnImportarExcel = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.btnImprimir = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.btnVerDetalle = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.lblIdCliente = New Bunifu.Framework.UI.BunifuCustomLabel()
        Me.btnEnvioCorreo = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.btnBuscarVenta = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.lblClient = New Bunifu.Framework.UI.BunifuCustomLabel()
        Me.lblNameClient = New Bunifu.Framework.UI.BunifuCustomLabel()
        Me.BunifuFlatButton2 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.btnCerrar = New Bunifu.Framework.UI.BunifuImageButton()
        Me.btnMinimizar = New Bunifu.Framework.UI.BunifuImageButton()
        Me.cboTipoBusqueda = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.PanelCentral = New System.Windows.Forms.Panel()
        Me.DgvComprobantes = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.PanelTittle = New System.Windows.Forms.Panel()
        Me.lblTittleReport = New Bunifu.Framework.UI.BunifuCustomLabel()
        Me.bunifuDragControl1 = New Bunifu.Framework.UI.BunifuDragControl(Me.components)
        Me.PanelHeader.SuspendLayout()
        CType(Me.btnCerrar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnMinimizar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTipoBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelCentral.SuspendLayout()
        CType(Me.DgvComprobantes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelTittle.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelHeader
        '
        Me.PanelHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(95, Byte), Integer), CType(CType(135, Byte), Integer))
        Me.PanelHeader.Controls.Add(Me.btnGenerarVenta)
        Me.PanelHeader.Controls.Add(Me.btnImportarExcel)
        Me.PanelHeader.Controls.Add(Me.btnImprimir)
        Me.PanelHeader.Controls.Add(Me.btnVerDetalle)
        Me.PanelHeader.Controls.Add(Me.lblIdCliente)
        Me.PanelHeader.Controls.Add(Me.btnEnvioCorreo)
        Me.PanelHeader.Controls.Add(Me.btnBuscarVenta)
        Me.PanelHeader.Controls.Add(Me.lblClient)
        Me.PanelHeader.Controls.Add(Me.lblNameClient)
        Me.PanelHeader.Controls.Add(Me.BunifuFlatButton2)
        Me.PanelHeader.Controls.Add(Me.btnCerrar)
        Me.PanelHeader.Controls.Add(Me.btnMinimizar)
        Me.PanelHeader.Controls.Add(Me.cboTipoBusqueda)
        Me.PanelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelHeader.Location = New System.Drawing.Point(0, 0)
        Me.PanelHeader.Name = "PanelHeader"
        Me.PanelHeader.Size = New System.Drawing.Size(1109, 60)
        Me.PanelHeader.TabIndex = 0
        '
        'btnGenerarVenta
        '
        Me.btnGenerarVenta.Activecolor = System.Drawing.Color.Chocolate
        Me.btnGenerarVenta.BackColor = System.Drawing.Color.Chocolate
        Me.btnGenerarVenta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnGenerarVenta.BorderRadius = 5
        Me.btnGenerarVenta.ButtonText = "Generar Venta"
        Me.btnGenerarVenta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGenerarVenta.DisabledColor = System.Drawing.Color.Gray
        Me.btnGenerarVenta.Iconcolor = System.Drawing.Color.Transparent
        Me.btnGenerarVenta.Iconimage = CType(resources.GetObject("btnGenerarVenta.Iconimage"), System.Drawing.Image)
        Me.btnGenerarVenta.Iconimage_right = Nothing
        Me.btnGenerarVenta.Iconimage_right_Selected = Nothing
        Me.btnGenerarVenta.Iconimage_Selected = Nothing
        Me.btnGenerarVenta.IconMarginLeft = 0
        Me.btnGenerarVenta.IconMarginRight = 0
        Me.btnGenerarVenta.IconRightVisible = True
        Me.btnGenerarVenta.IconRightZoom = 0R
        Me.btnGenerarVenta.IconVisible = True
        Me.btnGenerarVenta.IconZoom = 40.0R
        Me.btnGenerarVenta.IsTab = False
        Me.btnGenerarVenta.Location = New System.Drawing.Point(815, 29)
        Me.btnGenerarVenta.Name = "btnGenerarVenta"
        Me.btnGenerarVenta.Normalcolor = System.Drawing.Color.Chocolate
        Me.btnGenerarVenta.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(77, Byte), Integer))
        Me.btnGenerarVenta.OnHoverTextColor = System.Drawing.Color.White
        Me.btnGenerarVenta.selected = False
        Me.btnGenerarVenta.Size = New System.Drawing.Size(120, 25)
        Me.btnGenerarVenta.TabIndex = 780
        Me.btnGenerarVenta.Text = "Generar Venta"
        Me.btnGenerarVenta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGenerarVenta.Textcolor = System.Drawing.Color.White
        Me.btnGenerarVenta.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.btnImportarExcel.Location = New System.Drawing.Point(755, 29)
        Me.btnImportarExcel.Name = "btnImportarExcel"
        Me.btnImportarExcel.Normalcolor = System.Drawing.Color.SeaGreen
        Me.btnImportarExcel.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(188, Byte), Integer))
        Me.btnImportarExcel.OnHoverTextColor = System.Drawing.Color.White
        Me.btnImportarExcel.selected = False
        Me.btnImportarExcel.Size = New System.Drawing.Size(25, 25)
        Me.btnImportarExcel.TabIndex = 776
        Me.btnImportarExcel.Text = "Exportar Excel"
        Me.btnImportarExcel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnImportarExcel.Textcolor = System.Drawing.Color.White
        Me.btnImportarExcel.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.btnImprimir.Location = New System.Drawing.Point(698, 29)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Normalcolor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnImprimir.OnHovercolor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnImprimir.OnHoverTextColor = System.Drawing.Color.White
        Me.btnImprimir.selected = False
        Me.btnImprimir.Size = New System.Drawing.Size(26, 25)
        Me.btnImprimir.TabIndex = 775
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnImprimir.Textcolor = System.Drawing.Color.White
        Me.btnImprimir.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.btnVerDetalle.Location = New System.Drawing.Point(727, 29)
        Me.btnVerDetalle.Name = "btnVerDetalle"
        Me.btnVerDetalle.Normalcolor = System.Drawing.Color.MediumPurple
        Me.btnVerDetalle.OnHovercolor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnVerDetalle.OnHoverTextColor = System.Drawing.Color.White
        Me.btnVerDetalle.selected = False
        Me.btnVerDetalle.Size = New System.Drawing.Size(26, 25)
        Me.btnVerDetalle.TabIndex = 774
        Me.btnVerDetalle.Text = "Ver Detalle"
        Me.btnVerDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnVerDetalle.Textcolor = System.Drawing.Color.White
        Me.btnVerDetalle.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'lblIdCliente
        '
        Me.lblIdCliente.AutoSize = True
        Me.lblIdCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.lblIdCliente.ForeColor = System.Drawing.Color.White
        Me.lblIdCliente.Location = New System.Drawing.Point(990, 29)
        Me.lblIdCliente.Name = "lblIdCliente"
        Me.lblIdCliente.Size = New System.Drawing.Size(18, 20)
        Me.lblIdCliente.TabIndex = 769
        Me.lblIdCliente.Text = "0"
        Me.lblIdCliente.Visible = False
        '
        'btnEnvioCorreo
        '
        Me.btnEnvioCorreo.Activecolor = System.Drawing.SystemColors.Highlight
        Me.btnEnvioCorreo.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnEnvioCorreo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnEnvioCorreo.BorderRadius = 7
        Me.btnEnvioCorreo.ButtonText = "Imprimir"
        Me.btnEnvioCorreo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEnvioCorreo.DisabledColor = System.Drawing.Color.Gray
        Me.btnEnvioCorreo.Iconcolor = System.Drawing.Color.Transparent
        Me.btnEnvioCorreo.Iconimage = CType(resources.GetObject("btnEnvioCorreo.Iconimage"), System.Drawing.Image)
        Me.btnEnvioCorreo.Iconimage_right = Nothing
        Me.btnEnvioCorreo.Iconimage_right_Selected = Nothing
        Me.btnEnvioCorreo.Iconimage_Selected = Nothing
        Me.btnEnvioCorreo.IconMarginLeft = 0
        Me.btnEnvioCorreo.IconMarginRight = 0
        Me.btnEnvioCorreo.IconRightVisible = True
        Me.btnEnvioCorreo.IconRightZoom = 0R
        Me.btnEnvioCorreo.IconVisible = True
        Me.btnEnvioCorreo.IconZoom = 50.0R
        Me.btnEnvioCorreo.IsTab = True
        Me.btnEnvioCorreo.Location = New System.Drawing.Point(783, 29)
        Me.btnEnvioCorreo.Name = "btnEnvioCorreo"
        Me.btnEnvioCorreo.Normalcolor = System.Drawing.SystemColors.Highlight
        Me.btnEnvioCorreo.OnHovercolor = System.Drawing.SystemColors.ControlDarkDark
        Me.btnEnvioCorreo.OnHoverTextColor = System.Drawing.Color.White
        Me.btnEnvioCorreo.selected = False
        Me.btnEnvioCorreo.Size = New System.Drawing.Size(26, 25)
        Me.btnEnvioCorreo.TabIndex = 768
        Me.btnEnvioCorreo.Text = "Imprimir"
        Me.btnEnvioCorreo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnEnvioCorreo.Textcolor = System.Drawing.Color.White
        Me.btnEnvioCorreo.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'btnBuscarVenta
        '
        Me.btnBuscarVenta.Activecolor = System.Drawing.Color.Crimson
        Me.btnBuscarVenta.BackColor = System.Drawing.Color.Crimson
        Me.btnBuscarVenta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBuscarVenta.BorderRadius = 5
        Me.btnBuscarVenta.ButtonText = "Buscar"
        Me.btnBuscarVenta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscarVenta.DisabledColor = System.Drawing.Color.Gray
        Me.btnBuscarVenta.Iconcolor = System.Drawing.Color.Transparent
        Me.btnBuscarVenta.Iconimage = CType(resources.GetObject("btnBuscarVenta.Iconimage"), System.Drawing.Image)
        Me.btnBuscarVenta.Iconimage_right = Nothing
        Me.btnBuscarVenta.Iconimage_right_Selected = Nothing
        Me.btnBuscarVenta.Iconimage_Selected = Nothing
        Me.btnBuscarVenta.IconMarginLeft = 0
        Me.btnBuscarVenta.IconMarginRight = 0
        Me.btnBuscarVenta.IconRightVisible = True
        Me.btnBuscarVenta.IconRightZoom = 0R
        Me.btnBuscarVenta.IconVisible = True
        Me.btnBuscarVenta.IconZoom = 40.0R
        Me.btnBuscarVenta.IsTab = False
        Me.btnBuscarVenta.Location = New System.Drawing.Point(607, 29)
        Me.btnBuscarVenta.Name = "btnBuscarVenta"
        Me.btnBuscarVenta.Normalcolor = System.Drawing.Color.Crimson
        Me.btnBuscarVenta.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(77, Byte), Integer))
        Me.btnBuscarVenta.OnHoverTextColor = System.Drawing.Color.White
        Me.btnBuscarVenta.selected = False
        Me.btnBuscarVenta.Size = New System.Drawing.Size(81, 25)
        Me.btnBuscarVenta.TabIndex = 767
        Me.btnBuscarVenta.Text = "Buscar"
        Me.btnBuscarVenta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarVenta.Textcolor = System.Drawing.Color.White
        Me.btnBuscarVenta.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'lblClient
        '
        Me.lblClient.AutoSize = True
        Me.lblClient.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClient.ForeColor = System.Drawing.Color.White
        Me.lblClient.Location = New System.Drawing.Point(16, 34)
        Me.lblClient.Name = "lblClient"
        Me.lblClient.Size = New System.Drawing.Size(48, 15)
        Me.lblClient.TabIndex = 766
        Me.lblClient.Text = "Cliente:"
        '
        'lblNameClient
        '
        Me.lblNameClient.AutoSize = True
        Me.lblNameClient.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNameClient.ForeColor = System.Drawing.Color.White
        Me.lblNameClient.Location = New System.Drawing.Point(68, 34)
        Me.lblNameClient.Name = "lblNameClient"
        Me.lblNameClient.Size = New System.Drawing.Size(121, 13)
        Me.lblNameClient.TabIndex = 765
        Me.lblNameClient.Text = "Samuel Palacios Santos"
        '
        'BunifuFlatButton2
        '
        Me.BunifuFlatButton2.Activecolor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.BunifuFlatButton2.BackColor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton2.BorderRadius = 0
        Me.BunifuFlatButton2.ButtonText = "Documentacion "
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
        Me.BunifuFlatButton2.Location = New System.Drawing.Point(7, 5)
        Me.BunifuFlatButton2.Name = "BunifuFlatButton2"
        Me.BunifuFlatButton2.Normalcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton2.OnHovercolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton2.OnHoverTextColor = System.Drawing.Color.White
        Me.BunifuFlatButton2.selected = False
        Me.BunifuFlatButton2.Size = New System.Drawing.Size(128, 24)
        Me.BunifuFlatButton2.TabIndex = 764
        Me.BunifuFlatButton2.Text = "Documentacion "
        Me.BunifuFlatButton2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BunifuFlatButton2.Textcolor = System.Drawing.Color.White
        Me.BunifuFlatButton2.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'btnCerrar
        '
        Me.btnCerrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(95, Byte), Integer), CType(CType(135, Byte), Integer))
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Image)
        Me.btnCerrar.ImageActive = Nothing
        Me.btnCerrar.Location = New System.Drawing.Point(1069, 3)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(34, 31)
        Me.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnCerrar.TabIndex = 759
        Me.btnCerrar.TabStop = False
        Me.btnCerrar.Zoom = 10
        '
        'btnMinimizar
        '
        Me.btnMinimizar.BackColor = System.Drawing.Color.FromArgb(CType(CType(11, Byte), Integer), CType(CType(95, Byte), Integer), CType(CType(135, Byte), Integer))
        Me.btnMinimizar.Image = CType(resources.GetObject("btnMinimizar.Image"), System.Drawing.Image)
        Me.btnMinimizar.ImageActive = Nothing
        Me.btnMinimizar.Location = New System.Drawing.Point(1033, 3)
        Me.btnMinimizar.Name = "btnMinimizar"
        Me.btnMinimizar.Size = New System.Drawing.Size(34, 31)
        Me.btnMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnMinimizar.TabIndex = 760
        Me.btnMinimizar.TabStop = False
        Me.btnMinimizar.Zoom = 10
        '
        'cboTipoBusqueda
        '
        Me.cboTipoBusqueda.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cboTipoBusqueda.BeforeTouchSize = New System.Drawing.Size(122, 21)
        Me.cboTipoBusqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoBusqueda.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoBusqueda.Items.AddRange(New Object() {"POR PERIODO", "POR DIA"})
        Me.cboTipoBusqueda.Location = New System.Drawing.Point(476, 33)
        Me.cboTipoBusqueda.Name = "cboTipoBusqueda"
        Me.cboTipoBusqueda.Size = New System.Drawing.Size(122, 21)
        Me.cboTipoBusqueda.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016White
        Me.cboTipoBusqueda.TabIndex = 758
        Me.cboTipoBusqueda.Text = "POR PERIODO"
        '
        'PanelCentral
        '
        Me.PanelCentral.Controls.Add(Me.DgvComprobantes)
        Me.PanelCentral.Controls.Add(Me.PanelTittle)
        Me.PanelCentral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelCentral.Location = New System.Drawing.Point(0, 60)
        Me.PanelCentral.Name = "PanelCentral"
        Me.PanelCentral.Size = New System.Drawing.Size(1109, 579)
        Me.PanelCentral.TabIndex = 1
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
        Me.DgvComprobantes.Location = New System.Drawing.Point(0, 25)
        Me.DgvComprobantes.Name = "DgvComprobantes"
        Me.DgvComprobantes.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.DgvComprobantes.Size = New System.Drawing.Size(1109, 554)
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
        GridColumnDescriptor15.HeaderText = "Envio"
        GridColumnDescriptor15.MappingName = "enviosunat"
        GridColumnDescriptor15.ReadOnly = True
        GridColumnDescriptor15.Width = 70
        GridColumnDescriptor16.MappingName = "tipoVenta"
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
        Me.DgvComprobantes.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("idDocumento"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("fechaDoc"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipoDocumento"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("comprobante"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("serie"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("numero"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("NroDocEntidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("NombreEntidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("bi"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("bi02"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("igv"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("icbper"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("total"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("estado"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("enviosunat"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipoVenta")})
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
        'PanelTittle
        '
        Me.PanelTittle.BackColor = System.Drawing.Color.White
        Me.PanelTittle.Controls.Add(Me.lblTittleReport)
        Me.PanelTittle.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTittle.Location = New System.Drawing.Point(0, 0)
        Me.PanelTittle.Name = "PanelTittle"
        Me.PanelTittle.Size = New System.Drawing.Size(1109, 25)
        Me.PanelTittle.TabIndex = 420
        '
        'lblTittleReport
        '
        Me.lblTittleReport.AutoSize = True
        Me.lblTittleReport.Location = New System.Drawing.Point(376, 6)
        Me.lblTittleReport.Name = "lblTittleReport"
        Me.lblTittleReport.Size = New System.Drawing.Size(100, 13)
        Me.lblTittleReport.TabIndex = 0
        Me.lblTittleReport.Text = "Corizaciones - 2020"
        '
        'bunifuDragControl1
        '
        Me.bunifuDragControl1.Fixed = True
        Me.bunifuDragControl1.Horizontal = True
        Me.bunifuDragControl1.TargetControl = Me.PanelHeader
        Me.bunifuDragControl1.Vertical = True
        '
        'frmClientDetailsDocuments
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CaptionBarColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.CaptionButtonColor = System.Drawing.Color.White
        Me.CaptionButtonHoverColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1109, 639)
        Me.Controls.Add(Me.PanelCentral)
        Me.Controls.Add(Me.PanelHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmClientDetailsDocuments"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.PanelHeader.ResumeLayout(False)
        Me.PanelHeader.PerformLayout()
        CType(Me.btnCerrar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnMinimizar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTipoBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelCentral.ResumeLayout(False)
        CType(Me.DgvComprobantes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelTittle.ResumeLayout(False)
        Me.PanelTittle.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelHeader As Panel
    Friend WithEvents PanelCentral As Panel
    Friend WithEvents DgvComprobantes As Grid.Grouping.GridGroupingControl
    Friend WithEvents cboTipoBusqueda As Tools.ComboBoxAdv
    Friend WithEvents btnCerrar As Bunifu.Framework.UI.BunifuImageButton
    Friend WithEvents btnMinimizar As Bunifu.Framework.UI.BunifuImageButton
    Friend WithEvents PanelTittle As Panel
    Friend WithEvents lblTittleReport As Bunifu.Framework.UI.BunifuCustomLabel
    Friend WithEvents BunifuFlatButton2 As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents lblClient As Bunifu.Framework.UI.BunifuCustomLabel
    Friend WithEvents lblNameClient As Bunifu.Framework.UI.BunifuCustomLabel
    Friend WithEvents btnBuscarVenta As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents btnEnvioCorreo As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents lblIdCliente As Bunifu.Framework.UI.BunifuCustomLabel
    Private WithEvents bunifuDragControl1 As Bunifu.Framework.UI.BunifuDragControl
    Friend WithEvents btnVerDetalle As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents btnImprimir As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents btnImportarExcel As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents btnGenerarVenta As Bunifu.Framework.UI.BunifuFlatButton
End Class

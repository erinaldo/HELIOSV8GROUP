<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCSubCajaAdmiPos
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCSubCajaAdmiPos))
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridSummaryRowDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor()
        Dim GridSummaryColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor()
        Dim GridSummaryColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor()
        Dim GridSummaryColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor()
        Dim GridSummaryColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor()
        Dim GridSummaryColumnDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor()
        Me.GradientPanel8 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.btnEntradaDeDinero = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.btnSalidaDeDinero = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.PictureLoad = New System.Windows.Forms.PictureBox()
        Me.btnCobranza = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.btnCerrarCaja = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.btnAbrirCaja = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.PanelBody = New System.Windows.Forms.Panel()
        Me.DgvComprobantes = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.cboTipo = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.BunifuFlatButton4 = New Bunifu.Framework.UI.BunifuFlatButton()
        CType(Me.GradientPanel8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel8.SuspendLayout()
        CType(Me.PictureLoad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBody.SuspendLayout()
        CType(Me.DgvComprobantes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GradientPanel8
        '
        Me.GradientPanel8.BackColor = System.Drawing.Color.White
        Me.GradientPanel8.BackgroundImage = CType(resources.GetObject("GradientPanel8.BackgroundImage"), System.Drawing.Image)
        Me.GradientPanel8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GradientPanel8.BorderColor = System.Drawing.Color.Silver
        Me.GradientPanel8.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GradientPanel8.Controls.Add(Me.cboTipo)
        Me.GradientPanel8.Controls.Add(Me.BunifuFlatButton4)
        Me.GradientPanel8.Controls.Add(Me.btnEntradaDeDinero)
        Me.GradientPanel8.Controls.Add(Me.btnSalidaDeDinero)
        Me.GradientPanel8.Controls.Add(Me.PictureLoad)
        Me.GradientPanel8.Controls.Add(Me.btnCobranza)
        Me.GradientPanel8.Controls.Add(Me.btnCerrarCaja)
        Me.GradientPanel8.Controls.Add(Me.btnAbrirCaja)
        Me.GradientPanel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel8.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel8.Name = "GradientPanel8"
        Me.GradientPanel8.Size = New System.Drawing.Size(994, 38)
        Me.GradientPanel8.TabIndex = 302
        '
        'btnEntradaDeDinero
        '
        Me.btnEntradaDeDinero.Activecolor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(182, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.btnEntradaDeDinero.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(182, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.btnEntradaDeDinero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnEntradaDeDinero.BorderRadius = 5
        Me.btnEntradaDeDinero.ButtonText = "ENTRADA DE DINERO"
        Me.btnEntradaDeDinero.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEntradaDeDinero.DisabledColor = System.Drawing.Color.Gray
        Me.btnEntradaDeDinero.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEntradaDeDinero.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnEntradaDeDinero.Iconcolor = System.Drawing.Color.Transparent
        Me.btnEntradaDeDinero.Iconimage = Nothing
        Me.btnEntradaDeDinero.Iconimage_right = Nothing
        Me.btnEntradaDeDinero.Iconimage_right_Selected = Nothing
        Me.btnEntradaDeDinero.Iconimage_Selected = Nothing
        Me.btnEntradaDeDinero.IconMarginLeft = 0
        Me.btnEntradaDeDinero.IconMarginRight = 0
        Me.btnEntradaDeDinero.IconRightVisible = True
        Me.btnEntradaDeDinero.IconRightZoom = 0R
        Me.btnEntradaDeDinero.IconVisible = True
        Me.btnEntradaDeDinero.IconZoom = 90.0R
        Me.btnEntradaDeDinero.IsTab = False
        Me.btnEntradaDeDinero.Location = New System.Drawing.Point(703, 7)
        Me.btnEntradaDeDinero.Margin = New System.Windows.Forms.Padding(2)
        Me.btnEntradaDeDinero.Name = "btnEntradaDeDinero"
        Me.btnEntradaDeDinero.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(182, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.btnEntradaDeDinero.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(182, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.btnEntradaDeDinero.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.btnEntradaDeDinero.selected = False
        Me.btnEntradaDeDinero.Size = New System.Drawing.Size(113, 23)
        Me.btnEntradaDeDinero.TabIndex = 663
        Me.btnEntradaDeDinero.Text = "ENTRADA DE DINERO"
        Me.btnEntradaDeDinero.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnEntradaDeDinero.Textcolor = System.Drawing.Color.White
        Me.btnEntradaDeDinero.TextFont = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'btnSalidaDeDinero
        '
        Me.btnSalidaDeDinero.Activecolor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnSalidaDeDinero.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnSalidaDeDinero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSalidaDeDinero.BorderRadius = 5
        Me.btnSalidaDeDinero.ButtonText = "SALIDA DE DINERO"
        Me.btnSalidaDeDinero.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSalidaDeDinero.DisabledColor = System.Drawing.Color.Gray
        Me.btnSalidaDeDinero.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalidaDeDinero.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnSalidaDeDinero.Iconcolor = System.Drawing.Color.Transparent
        Me.btnSalidaDeDinero.Iconimage = Nothing
        Me.btnSalidaDeDinero.Iconimage_right = Nothing
        Me.btnSalidaDeDinero.Iconimage_right_Selected = Nothing
        Me.btnSalidaDeDinero.Iconimage_Selected = Nothing
        Me.btnSalidaDeDinero.IconMarginLeft = 0
        Me.btnSalidaDeDinero.IconMarginRight = 0
        Me.btnSalidaDeDinero.IconRightVisible = True
        Me.btnSalidaDeDinero.IconRightZoom = 0R
        Me.btnSalidaDeDinero.IconVisible = True
        Me.btnSalidaDeDinero.IconZoom = 90.0R
        Me.btnSalidaDeDinero.IsTab = False
        Me.btnSalidaDeDinero.Location = New System.Drawing.Point(586, 8)
        Me.btnSalidaDeDinero.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSalidaDeDinero.Name = "btnSalidaDeDinero"
        Me.btnSalidaDeDinero.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnSalidaDeDinero.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(182, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.btnSalidaDeDinero.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.btnSalidaDeDinero.selected = False
        Me.btnSalidaDeDinero.Size = New System.Drawing.Size(113, 23)
        Me.btnSalidaDeDinero.TabIndex = 662
        Me.btnSalidaDeDinero.Text = "SALIDA DE DINERO"
        Me.btnSalidaDeDinero.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnSalidaDeDinero.Textcolor = System.Drawing.Color.White
        Me.btnSalidaDeDinero.TextFont = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'PictureLoad
        '
        Me.PictureLoad.BackColor = System.Drawing.Color.Transparent
        Me.PictureLoad.Image = CType(resources.GetObject("PictureLoad.Image"), System.Drawing.Image)
        Me.PictureLoad.Location = New System.Drawing.Point(834, 9)
        Me.PictureLoad.Name = "PictureLoad"
        Me.PictureLoad.Size = New System.Drawing.Size(22, 21)
        Me.PictureLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureLoad.TabIndex = 661
        Me.PictureLoad.TabStop = False
        Me.PictureLoad.Visible = False
        '
        'btnCobranza
        '
        Me.btnCobranza.Activecolor = System.Drawing.Color.FromArgb(CType(CType(122, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(122, Byte), Integer))
        Me.btnCobranza.BackColor = System.Drawing.Color.FromArgb(CType(CType(122, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(122, Byte), Integer))
        Me.btnCobranza.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCobranza.BorderRadius = 5
        Me.btnCobranza.ButtonText = "COBRAR PEDIDOS"
        Me.btnCobranza.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCobranza.DisabledColor = System.Drawing.Color.Gray
        Me.btnCobranza.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCobranza.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnCobranza.Iconcolor = System.Drawing.Color.Transparent
        Me.btnCobranza.Iconimage = Nothing
        Me.btnCobranza.Iconimage_right = Nothing
        Me.btnCobranza.Iconimage_right_Selected = Nothing
        Me.btnCobranza.Iconimage_Selected = Nothing
        Me.btnCobranza.IconMarginLeft = 0
        Me.btnCobranza.IconMarginRight = 0
        Me.btnCobranza.IconRightVisible = True
        Me.btnCobranza.IconRightZoom = 0R
        Me.btnCobranza.IconVisible = True
        Me.btnCobranza.IconZoom = 90.0R
        Me.btnCobranza.IsTab = False
        Me.btnCobranza.Location = New System.Drawing.Point(473, 8)
        Me.btnCobranza.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCobranza.Name = "btnCobranza"
        Me.btnCobranza.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(122, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(122, Byte), Integer))
        Me.btnCobranza.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(122, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(122, Byte), Integer))
        Me.btnCobranza.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.btnCobranza.selected = False
        Me.btnCobranza.Size = New System.Drawing.Size(108, 23)
        Me.btnCobranza.TabIndex = 29
        Me.btnCobranza.Text = "COBRAR PEDIDOS"
        Me.btnCobranza.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnCobranza.Textcolor = System.Drawing.Color.White
        Me.btnCobranza.TextFont = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'btnCerrarCaja
        '
        Me.btnCerrarCaja.Activecolor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.btnCerrarCaja.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.btnCerrarCaja.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCerrarCaja.BorderRadius = 5
        Me.btnCerrarCaja.ButtonText = "CERRAR CAJA"
        Me.btnCerrarCaja.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCerrarCaja.DisabledColor = System.Drawing.Color.Gray
        Me.btnCerrarCaja.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrarCaja.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnCerrarCaja.Iconcolor = System.Drawing.Color.Transparent
        Me.btnCerrarCaja.Iconimage = Nothing
        Me.btnCerrarCaja.Iconimage_right = Nothing
        Me.btnCerrarCaja.Iconimage_right_Selected = Nothing
        Me.btnCerrarCaja.Iconimage_Selected = Nothing
        Me.btnCerrarCaja.IconMarginLeft = 0
        Me.btnCerrarCaja.IconMarginRight = 0
        Me.btnCerrarCaja.IconRightVisible = True
        Me.btnCerrarCaja.IconRightZoom = 0R
        Me.btnCerrarCaja.IconVisible = True
        Me.btnCerrarCaja.IconZoom = 90.0R
        Me.btnCerrarCaja.IsTab = False
        Me.btnCerrarCaja.Location = New System.Drawing.Point(362, 8)
        Me.btnCerrarCaja.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCerrarCaja.Name = "btnCerrarCaja"
        Me.btnCerrarCaja.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.btnCerrarCaja.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.btnCerrarCaja.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.btnCerrarCaja.selected = False
        Me.btnCerrarCaja.Size = New System.Drawing.Size(108, 23)
        Me.btnCerrarCaja.TabIndex = 28
        Me.btnCerrarCaja.Text = "CERRAR CAJA"
        Me.btnCerrarCaja.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnCerrarCaja.Textcolor = System.Drawing.Color.White
        Me.btnCerrarCaja.TextFont = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'btnAbrirCaja
        '
        Me.btnAbrirCaja.Activecolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.btnAbrirCaja.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.btnAbrirCaja.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAbrirCaja.BorderRadius = 5
        Me.btnAbrirCaja.ButtonText = "ABRIR CAJA"
        Me.btnAbrirCaja.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAbrirCaja.DisabledColor = System.Drawing.Color.Gray
        Me.btnAbrirCaja.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAbrirCaja.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnAbrirCaja.Iconcolor = System.Drawing.Color.Transparent
        Me.btnAbrirCaja.Iconimage = Nothing
        Me.btnAbrirCaja.Iconimage_right = Nothing
        Me.btnAbrirCaja.Iconimage_right_Selected = Nothing
        Me.btnAbrirCaja.Iconimage_Selected = Nothing
        Me.btnAbrirCaja.IconMarginLeft = 0
        Me.btnAbrirCaja.IconMarginRight = 0
        Me.btnAbrirCaja.IconRightVisible = True
        Me.btnAbrirCaja.IconRightZoom = 0R
        Me.btnAbrirCaja.IconVisible = True
        Me.btnAbrirCaja.IconZoom = 90.0R
        Me.btnAbrirCaja.IsTab = False
        Me.btnAbrirCaja.Location = New System.Drawing.Point(250, 8)
        Me.btnAbrirCaja.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAbrirCaja.Name = "btnAbrirCaja"
        Me.btnAbrirCaja.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.btnAbrirCaja.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.btnAbrirCaja.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.btnAbrirCaja.selected = False
        Me.btnAbrirCaja.Size = New System.Drawing.Size(108, 23)
        Me.btnAbrirCaja.TabIndex = 27
        Me.btnAbrirCaja.Text = "ABRIR CAJA"
        Me.btnAbrirCaja.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnAbrirCaja.Textcolor = System.Drawing.Color.White
        Me.btnAbrirCaja.TextFont = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'PanelBody
        '
        Me.PanelBody.BackColor = System.Drawing.Color.White
        Me.PanelBody.Controls.Add(Me.DgvComprobantes)
        Me.PanelBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelBody.Location = New System.Drawing.Point(0, 38)
        Me.PanelBody.Name = "PanelBody"
        Me.PanelBody.Size = New System.Drawing.Size(994, 488)
        Me.PanelBody.TabIndex = 303
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
        Me.DgvComprobantes.Size = New System.Drawing.Size(994, 488)
        Me.DgvComprobantes.TabIndex = 420
        Me.DgvComprobantes.TableDescriptor.AllowNew = False
        GridColumnDescriptor1.MappingName = "idestado"
        GridColumnDescriptor1.Width = 0
        GridColumnDescriptor2.HeaderText = " Cuenta Financiera"
        GridColumnDescriptor2.MappingName = "descripcion"
        GridColumnDescriptor2.Width = 280
        GridColumnDescriptor3.MappingName = "moneda"
        GridColumnDescriptor3.Width = 0
        GridColumnDescriptor4.HeaderText = "Monto"
        GridColumnDescriptor4.MappingName = "monto"
        GridColumnDescriptor4.Width = 80
        Me.DgvComprobantes.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4})
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
        Me.DgvComprobantes.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("idDocumento"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("idestado"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("descripcion"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("moneda"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("monto")})
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
        'cboTipo
        '
        Me.cboTipo.BackColor = System.Drawing.Color.White
        Me.cboTipo.BeforeTouchSize = New System.Drawing.Size(148, 21)
        Me.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipo.FlatBorderColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.cboTipo.Font = New System.Drawing.Font("Corbel", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipo.ForeColor = System.Drawing.Color.Black
        Me.cboTipo.Items.AddRange(New Object() {"EFECTIVO CAJERO"})
        Me.cboTipo.Location = New System.Drawing.Point(14, 8)
        Me.cboTipo.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboTipo.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(148, 21)
        Me.cboTipo.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboTipo.TabIndex = 668
        Me.cboTipo.Text = "EFECTIVO CAJERO"
        '
        'BunifuFlatButton4
        '
        Me.BunifuFlatButton4.Activecolor = System.Drawing.Color.ForestGreen
        Me.BunifuFlatButton4.BackColor = System.Drawing.Color.ForestGreen
        Me.BunifuFlatButton4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton4.BorderRadius = 5
        Me.BunifuFlatButton4.ButtonText = "Actualizar"
        Me.BunifuFlatButton4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton4.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton4.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BunifuFlatButton4.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton4.Iconimage = Nothing
        Me.BunifuFlatButton4.Iconimage_right = Nothing
        Me.BunifuFlatButton4.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton4.Iconimage_Selected = Nothing
        Me.BunifuFlatButton4.IconMarginLeft = 0
        Me.BunifuFlatButton4.IconMarginRight = 0
        Me.BunifuFlatButton4.IconRightVisible = True
        Me.BunifuFlatButton4.IconRightZoom = 0R
        Me.BunifuFlatButton4.IconVisible = True
        Me.BunifuFlatButton4.IconZoom = 90.0R
        Me.BunifuFlatButton4.IsTab = False
        Me.BunifuFlatButton4.Location = New System.Drawing.Point(171, 8)
        Me.BunifuFlatButton4.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton4.Name = "BunifuFlatButton4"
        Me.BunifuFlatButton4.Normalcolor = System.Drawing.Color.ForestGreen
        Me.BunifuFlatButton4.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.BunifuFlatButton4.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton4.selected = False
        Me.BunifuFlatButton4.Size = New System.Drawing.Size(68, 23)
        Me.BunifuFlatButton4.TabIndex = 667
        Me.BunifuFlatButton4.Text = "Actualizar"
        Me.BunifuFlatButton4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton4.Textcolor = System.Drawing.Color.White
        Me.BunifuFlatButton4.TextFont = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'UCSubCajaAdmiPos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PanelBody)
        Me.Controls.Add(Me.GradientPanel8)
        Me.Name = "UCSubCajaAdmiPos"
        Me.Size = New System.Drawing.Size(994, 526)
        CType(Me.GradientPanel8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel8.ResumeLayout(False)
        CType(Me.PictureLoad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBody.ResumeLayout(False)
        CType(Me.DgvComprobantes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GradientPanel8 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Private WithEvents btnSalidaDeDinero As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents PictureLoad As PictureBox
    Private WithEvents btnCobranza As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents btnCerrarCaja As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents btnAbrirCaja As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents btnEntradaDeDinero As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents PanelBody As Panel
    Friend WithEvents DgvComprobantes As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents cboTipo As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Private WithEvents BunifuFlatButton4 As Bunifu.Framework.UI.BunifuFlatButton
End Class

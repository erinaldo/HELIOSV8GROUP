Imports Syncfusion.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TabListaHospedadosActivos
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TabListaHospedadosActivos))
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor6 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor7 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor8 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor9 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"1", "JIUNI PALACIOS SANTOS", "44924569"}, -1)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.panelMesa = New System.Windows.Forms.Panel()
        Me.dgvPedidoDetalle = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.PanelMontos = New System.Windows.Forms.Panel()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.TextGMayor = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.TextMayor = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.TextMenor = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.TextProduct = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.TextCompra = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.GradientPanel5 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.txtVentaTotal = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtTotalNotaVenta = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtTotalBase3 = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextTotalDescuentos = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtTotalBase = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtTotalIva = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtTotalBase2 = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.GradientPanel6 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.txtTotalPagar = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtGlosa = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cboalmacen = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BunifuFlatButton17 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.TXTcOMPRADOR = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtruc = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.pcLikeCategoria = New Syncfusion.Windows.Forms.PopupControlContainer()
        Me.LsvProveedor = New System.Windows.Forms.ListView()
        Me.colID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colRUC = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTipoDoc = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.panelMesa.SuspendLayout()
        CType(Me.dgvPedidoDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.PanelMontos.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.TextGMayor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextMayor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextMenor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel5.SuspendLayout()
        CType(Me.txtVentaTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalNotaVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalBase3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextTotalDescuentos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalBase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalIva, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalBase2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel6.SuspendLayout()
        CType(Me.txtTotalPagar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGlosa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboalmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel8.SuspendLayout()
        Me.Panel10.SuspendLayout()
        CType(Me.TXTcOMPRADOR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtruc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pcLikeCategoria.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.ToolStrip1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(872, 38)
        Me.Panel1.TabIndex = 301
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator3, Me.ToolStripSeparator6, Me.ToolStripButton1, Me.ToolStripSeparator4})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(872, 38)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 38)
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 38)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ToolStripButton1.ForeColor = System.Drawing.Color.Black
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Margin = New System.Windows.Forms.Padding(5, 1, 5, 2)
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(93, 35)
        Me.ToolStripButton1.Text = "Actualizar"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 38)
        '
        'panelMesa
        '
        Me.panelMesa.BackColor = System.Drawing.Color.White
        Me.panelMesa.Controls.Add(Me.dgvPedidoDetalle)
        Me.panelMesa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelMesa.Location = New System.Drawing.Point(0, 85)
        Me.panelMesa.Name = "panelMesa"
        Me.panelMesa.Size = New System.Drawing.Size(872, 434)
        Me.panelMesa.TabIndex = 302
        '
        'dgvPedidoDetalle
        '
        Me.dgvPedidoDetalle.Appearance.AlternateRecordFieldCell.Font.Size = 8.0!
        Me.dgvPedidoDetalle.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        Me.dgvPedidoDetalle.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.dgvPedidoDetalle.BackColor = System.Drawing.Color.White
        Me.dgvPedidoDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvPedidoDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPedidoDetalle.FreezeCaption = False
        Me.dgvPedidoDetalle.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgvPedidoDetalle.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.dgvPedidoDetalle.Location = New System.Drawing.Point(0, 0)
        Me.dgvPedidoDetalle.Name = "dgvPedidoDetalle"
        Me.dgvPedidoDetalle.Size = New System.Drawing.Size(872, 434)
        Me.dgvPedidoDetalle.TabIndex = 510
        Me.dgvPedidoDetalle.TableDescriptor.AllowNew = False
        Me.dgvPedidoDetalle.TableDescriptor.Appearance.AnyCell.Font.Facename = "Segoe UI"
        Me.dgvPedidoDetalle.TableDescriptor.Appearance.AnyCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.dgvPedidoDetalle.TableDescriptor.Appearance.AnyGroupCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvPedidoDetalle.TableDescriptor.Appearance.AnyGroupCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvPedidoDetalle.TableDescriptor.Appearance.AnyGroupCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer)))
        Me.dgvPedidoDetalle.TableDescriptor.Appearance.AnyHeaderCell.Font.Size = 8.0!
        Me.dgvPedidoDetalle.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvPedidoDetalle.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvPedidoDetalle.TableDescriptor.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        Me.dgvPedidoDetalle.TableDescriptor.Appearance.AnySummaryCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvPedidoDetalle.TableDescriptor.Appearance.AnySummaryCell.Borders.Top = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvPedidoDetalle.TableDescriptor.Appearance.AnySummaryCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)))
        Me.dgvPedidoDetalle.TableDescriptor.Appearance.ColumnHeaderCell.Font.Bold = True
        Me.dgvPedidoDetalle.TableDescriptor.Appearance.ColumnHeaderCell.Font.Italic = False
        Me.dgvPedidoDetalle.TableDescriptor.Appearance.ColumnHeaderCell.Font.Size = 8.0!
        Me.dgvPedidoDetalle.TableDescriptor.Appearance.GroupCaptionCell.CellType = """ColumnHeader"""
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.MappingName = "ID"
        GridColumnDescriptor1.Name = "ID"
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor1.Width = 0
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.HeaderText = "Fecha"
        GridColumnDescriptor2.MappingName = "fecha"
        GridColumnDescriptor2.Name = "fecha"
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor2.Width = 120
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.HeaderText = "DNI"
        GridColumnDescriptor3.MappingName = "dni"
        GridColumnDescriptor3.Name = "dni"
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor3.Width = 90
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.HeaderText = "NOMBRE"
        GridColumnDescriptor4.MappingName = "nombre"
        GridColumnDescriptor4.Name = "nombre"
        GridColumnDescriptor4.SerializedImageArray = ""
        GridColumnDescriptor4.Width = 350
        GridColumnDescriptor5.HeaderImage = Nothing
        GridColumnDescriptor5.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor5.HeaderText = "Sexo"
        GridColumnDescriptor5.MappingName = "sexo"
        GridColumnDescriptor5.Name = "sexo"
        GridColumnDescriptor5.SerializedImageArray = ""
        GridColumnDescriptor5.Width = 70
        GridColumnDescriptor6.HeaderImage = Nothing
        GridColumnDescriptor6.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor6.HeaderText = "Nacionalidad"
        GridColumnDescriptor6.MappingName = "nacionalidad"
        GridColumnDescriptor6.Name = "nacionalidad"
        GridColumnDescriptor6.SerializedImageArray = ""
        GridColumnDescriptor6.Width = 90
        GridColumnDescriptor7.HeaderImage = Nothing
        GridColumnDescriptor7.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor7.MappingName = "idhabitacion"
        GridColumnDescriptor7.Name = "idhabitacion"
        GridColumnDescriptor7.SerializedImageArray = ""
        GridColumnDescriptor7.Width = 0
        GridColumnDescriptor8.HeaderImage = Nothing
        GridColumnDescriptor8.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor8.HeaderText = "Habitación"
        GridColumnDescriptor8.MappingName = "habitacion"
        GridColumnDescriptor8.Name = "habitacion"
        GridColumnDescriptor8.SerializedImageArray = ""
        GridColumnDescriptor8.Width = 140
        GridColumnDescriptor9.HeaderImage = Nothing
        GridColumnDescriptor9.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor9.HeaderText = "Uso"
        GridColumnDescriptor9.MappingName = "uso"
        GridColumnDescriptor9.Name = "uso"
        GridColumnDescriptor9.SerializedImageArray = ""
        GridColumnDescriptor9.Width = 100
        Me.dgvPedidoDetalle.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7, GridColumnDescriptor8, GridColumnDescriptor9})
        Me.dgvPedidoDetalle.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 29
        Me.dgvPedidoDetalle.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.dgvPedidoDetalle.TableDescriptor.TopLevelGroupOptions.ShowCaption = False
        Me.dgvPedidoDetalle.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("ID"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("fecha"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("dni"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("nombre"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("sexo"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("nacionalidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("idhabitacion"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("habitacion"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("uso")})
        Me.dgvPedidoDetalle.Text = "GridGroupingControl2"
        Me.dgvPedidoDetalle.VersionInfo = "12.4400.0.24"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "boxU.jpg")
        Me.ImageList1.Images.SetKeyName(1, "MESA2.jpg")
        Me.ImageList1.Images.SetKeyName(2, "boton2.png")
        Me.ImageList1.Images.SetKeyName(3, "boxB.jpg")
        Me.ImageList1.Images.SetKeyName(4, "MESA3.jpg")
        Me.ImageList1.Images.SetKeyName(5, "SillaL.jpg")
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.PanelMontos)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(0, 519)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(872, 10)
        Me.Panel5.TabIndex = 305
        '
        'PanelMontos
        '
        Me.PanelMontos.BackColor = System.Drawing.Color.White
        Me.PanelMontos.Controls.Add(Me.Label32)
        Me.PanelMontos.Controls.Add(Me.Label31)
        Me.PanelMontos.Controls.Add(Me.Label30)
        Me.PanelMontos.Controls.Add(Me.Panel6)
        Me.PanelMontos.Controls.Add(Me.TextCompra)
        Me.PanelMontos.Controls.Add(Me.Label19)
        Me.PanelMontos.Controls.Add(Me.GradientPanel5)
        Me.PanelMontos.Controls.Add(Me.txtGlosa)
        Me.PanelMontos.Controls.Add(Me.Label14)
        Me.PanelMontos.Controls.Add(Me.cboalmacen)
        Me.PanelMontos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMontos.Location = New System.Drawing.Point(0, 0)
        Me.PanelMontos.Name = "PanelMontos"
        Me.PanelMontos.Size = New System.Drawing.Size(872, 10)
        Me.PanelMontos.TabIndex = 504
        Me.PanelMontos.Visible = False
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label32.Location = New System.Drawing.Point(509, 15)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(80, 13)
        Me.Label32.TabIndex = 505
        Me.Label32.Text = "Tipo beneficio"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label31.Location = New System.Drawing.Point(521, 65)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(68, 13)
        Me.Label31.TabIndex = 503
        Me.Label31.Text = "Valor afecto"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label30.Location = New System.Drawing.Point(528, 40)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(60, 13)
        Me.Label30.TabIndex = 501
        Me.Label30.Text = "Valor base"
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.Panel7)
        Me.Panel6.Controls.Add(Me.TextGMayor)
        Me.Panel6.Controls.Add(Me.TextMayor)
        Me.Panel6.Controls.Add(Me.TextMenor)
        Me.Panel6.Controls.Add(Me.Label26)
        Me.Panel6.Controls.Add(Me.Label27)
        Me.Panel6.Controls.Add(Me.Label28)
        Me.Panel6.Controls.Add(Me.TextProduct)
        Me.Panel6.Controls.Add(Me.Label25)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(474, 10)
        Me.Panel6.TabIndex = 499
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.DimGray
        Me.Panel7.Controls.Add(Me.Label29)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(472, 22)
        Me.Panel7.TabIndex = 509
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.White
        Me.Label29.Location = New System.Drawing.Point(11, 4)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(166, 15)
        Me.Label29.TabIndex = 414
        Me.Label29.Text = "Precios de venta configurados"
        '
        'TextGMayor
        '
        Me.TextGMayor.BackGroundColor = System.Drawing.Color.WhiteSmoke
        Me.TextGMayor.BeforeTouchSize = New System.Drawing.Size(141, 19)
        Me.TextGMayor.BorderColor = System.Drawing.Color.Red
        Me.TextGMayor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextGMayor.CornerRadius = 4
        Me.TextGMayor.CurrencyDecimalDigits = 5
        Me.TextGMayor.CurrencySymbol = ""
        Me.TextGMayor.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextGMayor.DecimalValue = New Decimal(New Integer() {0, 0, 0, 327680})
        Me.TextGMayor.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextGMayor.ForeColor = System.Drawing.Color.Black
        Me.TextGMayor.Location = New System.Drawing.Point(287, 114)
        Me.TextGMayor.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextGMayor.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextGMayor.Name = "TextGMayor"
        Me.TextGMayor.NullString = ""
        Me.TextGMayor.PositiveColor = System.Drawing.Color.Black
        Me.TextGMayor.ReadOnly = True
        Me.TextGMayor.ReadOnlyBackColor = System.Drawing.Color.WhiteSmoke
        Me.TextGMayor.Size = New System.Drawing.Size(121, 25)
        Me.TextGMayor.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextGMayor.TabIndex = 508
        Me.TextGMayor.Text = "0.00000"
        Me.TextGMayor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextMayor
        '
        Me.TextMayor.BackGroundColor = System.Drawing.Color.WhiteSmoke
        Me.TextMayor.BeforeTouchSize = New System.Drawing.Size(141, 19)
        Me.TextMayor.BorderColor = System.Drawing.Color.OrangeRed
        Me.TextMayor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextMayor.CornerRadius = 4
        Me.TextMayor.CurrencyDecimalDigits = 5
        Me.TextMayor.CurrencySymbol = ""
        Me.TextMayor.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextMayor.DecimalValue = New Decimal(New Integer() {0, 0, 0, 327680})
        Me.TextMayor.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextMayor.ForeColor = System.Drawing.Color.Black
        Me.TextMayor.Location = New System.Drawing.Point(153, 114)
        Me.TextMayor.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextMayor.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextMayor.Name = "TextMayor"
        Me.TextMayor.NullString = ""
        Me.TextMayor.PositiveColor = System.Drawing.Color.Black
        Me.TextMayor.ReadOnly = True
        Me.TextMayor.ReadOnlyBackColor = System.Drawing.Color.WhiteSmoke
        Me.TextMayor.Size = New System.Drawing.Size(121, 25)
        Me.TextMayor.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextMayor.TabIndex = 507
        Me.TextMayor.Text = "0.00000"
        Me.TextMayor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextMenor
        '
        Me.TextMenor.BackGroundColor = System.Drawing.Color.WhiteSmoke
        Me.TextMenor.BeforeTouchSize = New System.Drawing.Size(141, 19)
        Me.TextMenor.BorderColor = System.Drawing.SystemColors.Highlight
        Me.TextMenor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextMenor.CornerRadius = 4
        Me.TextMenor.CurrencyDecimalDigits = 5
        Me.TextMenor.CurrencySymbol = ""
        Me.TextMenor.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextMenor.DecimalValue = New Decimal(New Integer() {0, 0, 0, 327680})
        Me.TextMenor.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextMenor.ForeColor = System.Drawing.Color.Black
        Me.TextMenor.Location = New System.Drawing.Point(19, 114)
        Me.TextMenor.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextMenor.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextMenor.Name = "TextMenor"
        Me.TextMenor.NullString = ""
        Me.TextMenor.PositiveColor = System.Drawing.Color.Black
        Me.TextMenor.ReadOnly = True
        Me.TextMenor.ReadOnlyBackColor = System.Drawing.Color.WhiteSmoke
        Me.TextMenor.Size = New System.Drawing.Size(121, 25)
        Me.TextMenor.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextMenor.TabIndex = 506
        Me.TextMenor.Text = "0.00000"
        Me.TextMenor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(285, 93)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(112, 15)
        Me.Label26.TabIndex = 505
        Me.Label26.Text = "Precio x gran mayor"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(155, 93)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(85, 15)
        Me.Label27.TabIndex = 504
        Me.Label27.Text = "Precio x mayor"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(20, 93)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(86, 15)
        Me.Label28.TabIndex = 503
        Me.Label28.Text = "Precio x menor"
        '
        'TextProduct
        '
        Me.TextProduct.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextProduct.BeforeTouchSize = New System.Drawing.Size(141, 19)
        Me.TextProduct.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextProduct.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextProduct.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextProduct.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextProduct.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextProduct.ForeColor = System.Drawing.Color.Black
        Me.TextProduct.Location = New System.Drawing.Point(19, 57)
        Me.TextProduct.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextProduct.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextProduct.Name = "TextProduct"
        Me.TextProduct.NearImage = CType(resources.GetObject("TextProduct.NearImage"), System.Drawing.Image)
        Me.TextProduct.ReadOnly = True
        Me.TextProduct.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextProduct.Size = New System.Drawing.Size(389, 23)
        Me.TextProduct.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextProduct.TabIndex = 414
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(16, 36)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(132, 15)
        Me.Label25.TabIndex = 413
        Me.Label25.Text = "Producto seleccionado"
        '
        'TextCompra
        '
        Me.TextCompra.BackGroundColor = System.Drawing.Color.WhiteSmoke
        Me.TextCompra.BeforeTouchSize = New System.Drawing.Size(141, 19)
        Me.TextCompra.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextCompra.CurrencyDecimalDigits = 5
        Me.TextCompra.CurrencySymbol = ""
        Me.TextCompra.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextCompra.DecimalValue = New Decimal(New Integer() {0, 0, 0, 327680})
        Me.TextCompra.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextCompra.ForeColor = System.Drawing.Color.Black
        Me.TextCompra.Location = New System.Drawing.Point(641, 154)
        Me.TextCompra.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextCompra.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextCompra.Name = "TextCompra"
        Me.TextCompra.NullString = ""
        Me.TextCompra.PositiveColor = System.Drawing.Color.Black
        Me.TextCompra.ReadOnly = True
        Me.TextCompra.ReadOnlyBackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextCompra.Size = New System.Drawing.Size(96, 23)
        Me.TextCompra.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextCompra.TabIndex = 498
        Me.TextCompra.Text = "0.00000"
        Me.TextCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TextCompra.Visible = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(614, 133)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(123, 15)
        Me.Label19.TabIndex = 497
        Me.Label19.Text = "Ultimo prec./compra"
        Me.Label19.Visible = False
        '
        'GradientPanel5
        '
        Me.GradientPanel5.BackColor = System.Drawing.Color.Gainsboro
        Me.GradientPanel5.BorderColor = System.Drawing.Color.LightGray
        Me.GradientPanel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel5.Controls.Add(Me.txtVentaTotal)
        Me.GradientPanel5.Controls.Add(Me.Label15)
        Me.GradientPanel5.Controls.Add(Me.txtTotalNotaVenta)
        Me.GradientPanel5.Controls.Add(Me.Label9)
        Me.GradientPanel5.Controls.Add(Me.txtTotalBase3)
        Me.GradientPanel5.Controls.Add(Me.Label3)
        Me.GradientPanel5.Controls.Add(Me.TextTotalDescuentos)
        Me.GradientPanel5.Controls.Add(Me.Label22)
        Me.GradientPanel5.Controls.Add(Me.txtTotalBase)
        Me.GradientPanel5.Controls.Add(Me.txtTotalIva)
        Me.GradientPanel5.Controls.Add(Me.txtTotalBase2)
        Me.GradientPanel5.Controls.Add(Me.GradientPanel6)
        Me.GradientPanel5.Controls.Add(Me.Label11)
        Me.GradientPanel5.Controls.Add(Me.Label10)
        Me.GradientPanel5.Controls.Add(Me.Label12)
        Me.GradientPanel5.Dock = System.Windows.Forms.DockStyle.Right
        Me.GradientPanel5.Location = New System.Drawing.Point(436, 0)
        Me.GradientPanel5.Name = "GradientPanel5"
        Me.GradientPanel5.Size = New System.Drawing.Size(436, 10)
        Me.GradientPanel5.TabIndex = 221
        '
        'txtVentaTotal
        '
        Me.txtVentaTotal.BackGroundColor = System.Drawing.Color.Gainsboro
        Me.txtVentaTotal.BeforeTouchSize = New System.Drawing.Size(141, 19)
        Me.txtVentaTotal.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtVentaTotal.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtVentaTotal.CornerRadius = 5
        Me.txtVentaTotal.CurrencySymbol = ""
        Me.txtVentaTotal.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtVentaTotal.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtVentaTotal.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVentaTotal.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtVentaTotal.Location = New System.Drawing.Point(316, 109)
        Me.txtVentaTotal.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtVentaTotal.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtVentaTotal.Name = "txtVentaTotal"
        Me.txtVentaTotal.NullString = ""
        Me.txtVentaTotal.PositiveColor = System.Drawing.SystemColors.HotTrack
        Me.txtVentaTotal.ReadOnly = True
        Me.txtVentaTotal.ReadOnlyBackColor = System.Drawing.Color.Gainsboro
        Me.txtVentaTotal.Size = New System.Drawing.Size(141, 15)
        Me.txtVentaTotal.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtVentaTotal.TabIndex = 502
        Me.txtVentaTotal.Text = "0.00"
        Me.txtVentaTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label15.Location = New System.Drawing.Point(17, 111)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(89, 13)
        Me.Label15.TabIndex = 501
        Me.Label15.Text = "Venta Total Doc."
        '
        'txtTotalNotaVenta
        '
        Me.txtTotalNotaVenta.BackGroundColor = System.Drawing.Color.Gainsboro
        Me.txtTotalNotaVenta.BeforeTouchSize = New System.Drawing.Size(141, 19)
        Me.txtTotalNotaVenta.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalNotaVenta.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotalNotaVenta.CornerRadius = 5
        Me.txtTotalNotaVenta.CurrencySymbol = ""
        Me.txtTotalNotaVenta.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotalNotaVenta.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalNotaVenta.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalNotaVenta.ForeColor = System.Drawing.Color.Green
        Me.txtTotalNotaVenta.Location = New System.Drawing.Point(316, 129)
        Me.txtTotalNotaVenta.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalNotaVenta.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtTotalNotaVenta.Name = "txtTotalNotaVenta"
        Me.txtTotalNotaVenta.NullString = ""
        Me.txtTotalNotaVenta.PositiveColor = System.Drawing.Color.Green
        Me.txtTotalNotaVenta.ReadOnly = True
        Me.txtTotalNotaVenta.ReadOnlyBackColor = System.Drawing.Color.Gainsboro
        Me.txtTotalNotaVenta.Size = New System.Drawing.Size(141, 15)
        Me.txtTotalNotaVenta.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtTotalNotaVenta.TabIndex = 500
        Me.txtTotalNotaVenta.Text = "0.00"
        Me.txtTotalNotaVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalNotaVenta.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Green
        Me.Label9.Location = New System.Drawing.Point(17, 131)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 13)
        Me.Label9.TabIndex = 499
        Me.Label9.Text = "Venta Total Not."
        Me.Label9.Visible = False
        '
        'txtTotalBase3
        '
        Me.txtTotalBase3.BackGroundColor = System.Drawing.Color.Gainsboro
        Me.txtTotalBase3.BeforeTouchSize = New System.Drawing.Size(141, 19)
        Me.txtTotalBase3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalBase3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotalBase3.CornerRadius = 5
        Me.txtTotalBase3.CurrencySymbol = ""
        Me.txtTotalBase3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotalBase3.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalBase3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalBase3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTotalBase3.Location = New System.Drawing.Point(316, 44)
        Me.txtTotalBase3.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalBase3.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtTotalBase3.Name = "txtTotalBase3"
        Me.txtTotalBase3.NullString = ""
        Me.txtTotalBase3.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTotalBase3.ReadOnly = True
        Me.txtTotalBase3.ReadOnlyBackColor = System.Drawing.Color.Gainsboro
        Me.txtTotalBase3.Size = New System.Drawing.Size(141, 15)
        Me.txtTotalBase3.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtTotalBase3.TabIndex = 498
        Me.txtTotalBase3.Text = "0.00"
        Me.txtTotalBase3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(17, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 497
        Me.Label3.Text = "Op. Inafecta"
        '
        'TextTotalDescuentos
        '
        Me.TextTotalDescuentos.BackGroundColor = System.Drawing.Color.Gainsboro
        Me.TextTotalDescuentos.BeforeTouchSize = New System.Drawing.Size(141, 19)
        Me.TextTotalDescuentos.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextTotalDescuentos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextTotalDescuentos.CornerRadius = 5
        Me.TextTotalDescuentos.CurrencySymbol = ""
        Me.TextTotalDescuentos.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextTotalDescuentos.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.TextTotalDescuentos.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextTotalDescuentos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextTotalDescuentos.Location = New System.Drawing.Point(316, 87)
        Me.TextTotalDescuentos.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextTotalDescuentos.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextTotalDescuentos.Name = "TextTotalDescuentos"
        Me.TextTotalDescuentos.NullString = ""
        Me.TextTotalDescuentos.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextTotalDescuentos.ReadOnly = True
        Me.TextTotalDescuentos.ReadOnlyBackColor = System.Drawing.Color.Gainsboro
        Me.TextTotalDescuentos.Size = New System.Drawing.Size(141, 15)
        Me.TextTotalDescuentos.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextTotalDescuentos.TabIndex = 496
        Me.TextTotalDescuentos.Text = "0.00"
        Me.TextTotalDescuentos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(17, 89)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(67, 13)
        Me.Label22.TabIndex = 495
        Me.Label22.Text = "Descuentos"
        '
        'txtTotalBase
        '
        Me.txtTotalBase.BackGroundColor = System.Drawing.Color.Gainsboro
        Me.txtTotalBase.BeforeTouchSize = New System.Drawing.Size(141, 19)
        Me.txtTotalBase.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalBase.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotalBase.CornerRadius = 5
        Me.txtTotalBase.CurrencySymbol = ""
        Me.txtTotalBase.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotalBase.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalBase.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalBase.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTotalBase.Location = New System.Drawing.Point(316, 3)
        Me.txtTotalBase.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalBase.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtTotalBase.Name = "txtTotalBase"
        Me.txtTotalBase.NullString = ""
        Me.txtTotalBase.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTotalBase.ReadOnly = True
        Me.txtTotalBase.ReadOnlyBackColor = System.Drawing.Color.Gainsboro
        Me.txtTotalBase.Size = New System.Drawing.Size(141, 15)
        Me.txtTotalBase.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtTotalBase.TabIndex = 494
        Me.txtTotalBase.Text = "0.00"
        Me.txtTotalBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalIva
        '
        Me.txtTotalIva.BackGroundColor = System.Drawing.Color.Gainsboro
        Me.txtTotalIva.BeforeTouchSize = New System.Drawing.Size(141, 19)
        Me.txtTotalIva.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalIva.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotalIva.CornerRadius = 5
        Me.txtTotalIva.CurrencySymbol = ""
        Me.txtTotalIva.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtTotalIva.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalIva.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalIva.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTotalIva.Location = New System.Drawing.Point(316, 66)
        Me.txtTotalIva.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalIva.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtTotalIva.Name = "txtTotalIva"
        Me.txtTotalIva.NullString = ""
        Me.txtTotalIva.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTotalIva.ReadOnly = True
        Me.txtTotalIva.ReadOnlyBackColor = System.Drawing.Color.Gainsboro
        Me.txtTotalIva.Size = New System.Drawing.Size(141, 15)
        Me.txtTotalIva.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtTotalIva.TabIndex = 493
        Me.txtTotalIva.Text = "0.00"
        Me.txtTotalIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalBase2
        '
        Me.txtTotalBase2.BackGroundColor = System.Drawing.Color.Gainsboro
        Me.txtTotalBase2.BeforeTouchSize = New System.Drawing.Size(141, 19)
        Me.txtTotalBase2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalBase2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotalBase2.CornerRadius = 5
        Me.txtTotalBase2.CurrencySymbol = ""
        Me.txtTotalBase2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotalBase2.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalBase2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalBase2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTotalBase2.Location = New System.Drawing.Point(316, 23)
        Me.txtTotalBase2.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalBase2.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtTotalBase2.Name = "txtTotalBase2"
        Me.txtTotalBase2.NullString = ""
        Me.txtTotalBase2.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTotalBase2.ReadOnly = True
        Me.txtTotalBase2.ReadOnlyBackColor = System.Drawing.Color.Gainsboro
        Me.txtTotalBase2.Size = New System.Drawing.Size(141, 15)
        Me.txtTotalBase2.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtTotalBase2.TabIndex = 492
        Me.txtTotalBase2.Text = "0.00"
        Me.txtTotalBase2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GradientPanel6
        '
        Me.GradientPanel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.GradientPanel6.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.GradientPanel6.BorderSides = System.Windows.Forms.Border3DSide.Top
        Me.GradientPanel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel6.Controls.Add(Me.txtTotalPagar)
        Me.GradientPanel6.Controls.Add(Me.Label13)
        Me.GradientPanel6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel6.Location = New System.Drawing.Point(0, -24)
        Me.GradientPanel6.Name = "GradientPanel6"
        Me.GradientPanel6.Size = New System.Drawing.Size(434, 32)
        Me.GradientPanel6.TabIndex = 222
        '
        'txtTotalPagar
        '
        Me.txtTotalPagar.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.txtTotalPagar.BeforeTouchSize = New System.Drawing.Size(141, 19)
        Me.txtTotalPagar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalPagar.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotalPagar.CornerRadius = 5
        Me.txtTotalPagar.CurrencySymbol = ""
        Me.txtTotalPagar.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtTotalPagar.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalPagar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPagar.ForeColor = System.Drawing.Color.Black
        Me.txtTotalPagar.Location = New System.Drawing.Point(315, 5)
        Me.txtTotalPagar.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotalPagar.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtTotalPagar.Name = "txtTotalPagar"
        Me.txtTotalPagar.NullString = ""
        Me.txtTotalPagar.PositiveColor = System.Drawing.Color.Black
        Me.txtTotalPagar.ReadOnly = True
        Me.txtTotalPagar.ReadOnlyBackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtTotalPagar.Size = New System.Drawing.Size(141, 19)
        Me.txtTotalPagar.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtTotalPagar.TabIndex = 495
        Me.txtTotalPagar.Text = "0.00"
        Me.txtTotalPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(16, 10)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(44, 15)
        Me.Label13.TabIndex = 7
        Me.Label13.Text = "TOTAL"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(17, 25)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(83, 13)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Op. Exonerada"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(17, 68)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(25, 13)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "IGV"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(17, 5)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(71, 13)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "Op. Gravada"
        '
        'txtGlosa
        '
        Me.txtGlosa.BackColor = System.Drawing.Color.White
        Me.txtGlosa.BeforeTouchSize = New System.Drawing.Size(141, 19)
        Me.txtGlosa.BorderColor = System.Drawing.Color.DarkGray
        Me.txtGlosa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGlosa.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtGlosa.Location = New System.Drawing.Point(12, 92)
        Me.txtGlosa.Metrocolor = System.Drawing.Color.DarkGray
        Me.txtGlosa.Multiline = True
        Me.txtGlosa.Name = "txtGlosa"
        Me.txtGlosa.Size = New System.Drawing.Size(63, 61)
        Me.txtGlosa.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtGlosa.TabIndex = 3
        Me.txtGlosa.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(15, 159)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(41, 12)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "NOTAS "
        Me.Label14.Visible = False
        '
        'cboalmacen
        '
        Me.cboalmacen.BackColor = System.Drawing.Color.White
        Me.cboalmacen.BeforeTouchSize = New System.Drawing.Size(250, 19)
        Me.cboalmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboalmacen.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboalmacen.Location = New System.Drawing.Point(412, 153)
        Me.cboalmacen.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboalmacen.Name = "cboalmacen"
        Me.cboalmacen.Size = New System.Drawing.Size(250, 19)
        Me.cboalmacen.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboalmacen.TabIndex = 406
        Me.cboalmacen.Visible = False
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.Panel10)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel8.Location = New System.Drawing.Point(0, 38)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(872, 47)
        Me.Panel8.TabIndex = 306
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.Label5)
        Me.Panel10.Controls.Add(Me.BunifuFlatButton17)
        Me.Panel10.Controls.Add(Me.ProgressBar1)
        Me.Panel10.Controls.Add(Me.TXTcOMPRADOR)
        Me.Panel10.Controls.Add(Me.txtruc)
        Me.Panel10.Controls.Add(Me.pcLikeCategoria)
        Me.Panel10.Location = New System.Drawing.Point(0, 0)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(872, 43)
        Me.Panel10.TabIndex = 308
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(18, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 14)
        Me.Label5.TabIndex = 532
        Me.Label5.Text = "Cliente"
        '
        'BunifuFlatButton17
        '
        Me.BunifuFlatButton17.Activecolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.BunifuFlatButton17.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.BunifuFlatButton17.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton17.BorderRadius = 5
        Me.BunifuFlatButton17.ButtonText = "CONSULTAR"
        Me.BunifuFlatButton17.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton17.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton17.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton17.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BunifuFlatButton17.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton17.Iconimage = Nothing
        Me.BunifuFlatButton17.Iconimage_right = Nothing
        Me.BunifuFlatButton17.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton17.Iconimage_Selected = Nothing
        Me.BunifuFlatButton17.IconMarginLeft = 0
        Me.BunifuFlatButton17.IconMarginRight = 0
        Me.BunifuFlatButton17.IconRightVisible = True
        Me.BunifuFlatButton17.IconRightZoom = 0R
        Me.BunifuFlatButton17.IconVisible = True
        Me.BunifuFlatButton17.IconZoom = 90.0R
        Me.BunifuFlatButton17.IsTab = False
        Me.BunifuFlatButton17.Location = New System.Drawing.Point(480, 9)
        Me.BunifuFlatButton17.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton17.Name = "BunifuFlatButton17"
        Me.BunifuFlatButton17.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.BunifuFlatButton17.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.BunifuFlatButton17.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton17.selected = False
        Me.BunifuFlatButton17.Size = New System.Drawing.Size(108, 23)
        Me.BunifuFlatButton17.TabIndex = 669
        Me.BunifuFlatButton17.Text = "CONSULTAR"
        Me.BunifuFlatButton17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton17.Textcolor = System.Drawing.Color.White
        Me.BunifuFlatButton17.TextFont = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(488, 9)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(33, 10)
        Me.ProgressBar1.TabIndex = 537
        Me.ProgressBar1.Visible = False
        '
        'TXTcOMPRADOR
        '
        Me.TXTcOMPRADOR.BackColor = System.Drawing.Color.White
        Me.TXTcOMPRADOR.BeforeTouchSize = New System.Drawing.Size(141, 19)
        Me.TXTcOMPRADOR.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TXTcOMPRADOR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXTcOMPRADOR.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTcOMPRADOR.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TXTcOMPRADOR.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TXTcOMPRADOR.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTcOMPRADOR.ForeColor = System.Drawing.Color.Navy
        Me.TXTcOMPRADOR.Location = New System.Drawing.Point(65, 10)
        Me.TXTcOMPRADOR.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TXTcOMPRADOR.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TXTcOMPRADOR.Name = "TXTcOMPRADOR"
        Me.TXTcOMPRADOR.NearImage = CType(resources.GetObject("TXTcOMPRADOR.NearImage"), System.Drawing.Image)
        Me.TXTcOMPRADOR.Size = New System.Drawing.Size(301, 22)
        Me.TXTcOMPRADOR.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TXTcOMPRADOR.TabIndex = 531
        '
        'txtruc
        '
        Me.txtruc.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtruc.BeforeTouchSize = New System.Drawing.Size(141, 19)
        Me.txtruc.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtruc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtruc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtruc.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtruc.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtruc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtruc.Location = New System.Drawing.Point(372, 10)
        Me.txtruc.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtruc.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtruc.Name = "txtruc"
        Me.txtruc.NearImage = CType(resources.GetObject("txtruc.NearImage"), System.Drawing.Image)
        Me.txtruc.ReadOnly = True
        Me.txtruc.Size = New System.Drawing.Size(96, 22)
        Me.txtruc.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtruc.TabIndex = 533
        '
        'pcLikeCategoria
        '
        Me.pcLikeCategoria.Controls.Add(Me.LsvProveedor)
        Me.pcLikeCategoria.Location = New System.Drawing.Point(455, 76)
        Me.pcLikeCategoria.Name = "pcLikeCategoria"
        Me.pcLikeCategoria.Size = New System.Drawing.Size(282, 128)
        Me.pcLikeCategoria.TabIndex = 536
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
        'TabListaHospedadosActivos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.panelMesa)
        Me.Controls.Add(Me.Panel8)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "TabListaHospedadosActivos"
        Me.Size = New System.Drawing.Size(872, 529)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.panelMesa.ResumeLayout(False)
        CType(Me.dgvPedidoDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.PanelMontos.ResumeLayout(False)
        Me.PanelMontos.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        CType(Me.TextGMayor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextMayor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextMenor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextCompra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel5.ResumeLayout(False)
        Me.GradientPanel5.PerformLayout()
        CType(Me.txtVentaTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalNotaVenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalBase3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextTotalDescuentos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalBase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalIva, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalBase2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel6.ResumeLayout(False)
        Me.GradientPanel6.PerformLayout()
        CType(Me.txtTotalPagar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGlosa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboalmacen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel8.ResumeLayout(False)
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        CType(Me.TXTcOMPRADOR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtruc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pcLikeCategoria.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents panelMesa As Panel
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Panel5 As Panel
    Friend WithEvents PanelMontos As Panel
    Friend WithEvents Label32 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Label29 As Label
    Friend WithEvents TextGMayor As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents TextMayor As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents TextMenor As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents TextProduct As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label25 As Label
    Friend WithEvents TextCompra As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents GradientPanel5 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents txtVentaTotal As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtTotalNotaVenta As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtTotalBase3 As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TextTotalDescuentos As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents txtTotalBase As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtTotalIva As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtTotalBase2 As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents GradientPanel6 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents txtTotalPagar As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents txtGlosa As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label14 As Label
    Friend WithEvents cboalmacen As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Panel10 As Panel
    Friend WithEvents txtruc As Tools.TextBoxExt
    Friend WithEvents Label5 As Label
    Friend WithEvents TXTcOMPRADOR As Tools.TextBoxExt
    Private WithEvents pcLikeCategoria As PopupControlContainer
    Friend WithEvents LsvProveedor As ListView
    Friend WithEvents colID As ColumnHeader
    Friend WithEvents colCliente As ColumnHeader
    Friend WithEvents colRUC As ColumnHeader
    Friend WithEvents colTipoDoc As ColumnHeader
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents dgvPedidoDetalle As Grid.Grouping.GridGroupingControl
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Private WithEvents BunifuFlatButton17 As Bunifu.Framework.UI.BunifuFlatButton
End Class

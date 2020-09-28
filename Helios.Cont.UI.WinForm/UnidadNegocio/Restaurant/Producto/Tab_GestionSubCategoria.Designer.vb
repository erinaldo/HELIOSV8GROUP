<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Tab_GestionSubCategoria
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Tab_GestionSubCategoria))
        Dim GridColumnDescriptor7 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor8 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor9 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor10 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor11 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor12 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridSummaryRowDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor()
        Dim GridSummaryColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.pnCategoria = New System.Windows.Forms.Panel()
        Me.dgvPedidoDetalle = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnContenedorCategoria = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.flowCategoria = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.BunifuFlatButton2 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.BunifuFlatButton1 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.pnCategoria.SuspendLayout()
        CType(Me.dgvPedidoDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnContenedorCategoria.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel10.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel9.SuspendLayout()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "icons8_delete_32.png")
        Me.ImageList1.Images.SetKeyName(1, "icons8_software_installer_32.png")
        '
        'pnCategoria
        '
        Me.pnCategoria.Controls.Add(Me.dgvPedidoDetalle)
        Me.pnCategoria.Controls.Add(Me.Panel3)
        Me.pnCategoria.Controls.Add(Me.Label1)
        Me.pnCategoria.Controls.Add(Me.Panel1)
        Me.pnCategoria.Controls.Add(Me.pnContenedorCategoria)
        Me.pnCategoria.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnCategoria.Location = New System.Drawing.Point(0, 48)
        Me.pnCategoria.Name = "pnCategoria"
        Me.pnCategoria.Size = New System.Drawing.Size(1135, 542)
        Me.pnCategoria.TabIndex = 304
        '
        'dgvPedidoDetalle
        '
        Me.dgvPedidoDetalle.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.dgvPedidoDetalle.Appearance.AlternateRecordFieldCell.Font.Size = 8.0!
        Me.dgvPedidoDetalle.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        Me.dgvPedidoDetalle.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.dgvPedidoDetalle.BackColor = System.Drawing.Color.White
        Me.dgvPedidoDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvPedidoDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPedidoDetalle.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgvPedidoDetalle.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.dgvPedidoDetalle.Location = New System.Drawing.Point(201, 73)
        Me.dgvPedidoDetalle.Name = "dgvPedidoDetalle"
        Me.dgvPedidoDetalle.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.dgvPedidoDetalle.Size = New System.Drawing.Size(934, 469)
        Me.dgvPedidoDetalle.TabIndex = 417
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
        GridColumnDescriptor7.MappingName = "ID"
        GridColumnDescriptor7.Name = "ID"
        GridColumnDescriptor7.Width = 0
        GridColumnDescriptor8.HeaderText = "DESCRIPCIÓN"
        GridColumnDescriptor8.MappingName = "descripcion"
        GridColumnDescriptor8.Name = "descripcion"
        GridColumnDescriptor8.Width = 400
        GridColumnDescriptor9.HeaderText = "ESTADO"
        GridColumnDescriptor9.MappingName = "estado"
        GridColumnDescriptor9.Name = "estado"
        GridColumnDescriptor9.Width = 150
        GridColumnDescriptor10.Appearance.AnyRecordFieldCell.CellType = "PushButton"
        GridColumnDescriptor10.HeaderText = "E"
        GridColumnDescriptor10.MappingName = "eliminar"
        GridColumnDescriptor10.Name = "eliminar"
        GridColumnDescriptor10.Width = 25
        GridColumnDescriptor11.Appearance.AnyRecordFieldCell.CellType = "PushButton"
        GridColumnDescriptor11.HeaderText = "A"
        GridColumnDescriptor11.MappingName = "actualizar"
        GridColumnDescriptor11.Name = "actualizar"
        GridColumnDescriptor11.Width = 25
        GridColumnDescriptor12.Appearance.AnyRecordFieldCell.CellType = "CheckBox"
        GridColumnDescriptor12.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center
        GridColumnDescriptor12.HeaderText = "INHABILITAR"
        GridColumnDescriptor12.MappingName = "inhabilitar"
        GridColumnDescriptor12.Name = "inhabilitar"
        GridColumnDescriptor12.Width = 100
        Me.dgvPedidoDetalle.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor7, GridColumnDescriptor8, GridColumnDescriptor9, GridColumnDescriptor10, GridColumnDescriptor11, GridColumnDescriptor12})
        GridSummaryRowDescriptor2.Appearance.AnySummaryCell.CurrencyEdit.CurrencySymbol = ""
        GridSummaryRowDescriptor2.Appearance.AnySummaryCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.LightSteelBlue)
        GridSummaryRowDescriptor2.Name = "Row 1"
        GridSummaryColumnDescriptor2.Appearance.AnySummaryCell.CellType = "Currency"
        GridSummaryColumnDescriptor2.Appearance.AnySummaryCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
        GridSummaryColumnDescriptor2.Appearance.AnySummaryCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        GridSummaryColumnDescriptor2.DataMember = "total"
        GridSummaryColumnDescriptor2.Format = "{Sum}"
        GridSummaryColumnDescriptor2.Name = "Summary 1"
        GridSummaryColumnDescriptor2.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        GridSummaryRowDescriptor2.SummaryColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor() {GridSummaryColumnDescriptor2})
        Me.dgvPedidoDetalle.TableDescriptor.SummaryRows.Add(GridSummaryRowDescriptor2)
        Me.dgvPedidoDetalle.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 29
        Me.dgvPedidoDetalle.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.dgvPedidoDetalle.TableDescriptor.TopLevelGroupOptions.ShowCaption = False
        Me.dgvPedidoDetalle.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("ID"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("descripcion"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("estado"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("eliminar"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("actualizar"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("inhabilitar")})
        Me.dgvPedidoDetalle.TableOptions.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.dgvPedidoDetalle.TableOptions.SelectionTextColor = System.Drawing.SystemColors.HighlightText
        Me.dgvPedidoDetalle.Text = "GridGroupingControl2"
        Me.dgvPedidoDetalle.UseRightToLeftCompatibleTextBox = True
        Me.dgvPedidoDetalle.VersionInfo = "12.4400.0.24"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.PictureBox1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(201, 24)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(934, 49)
        Me.Panel3.TabIndex = 421
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Location = New System.Drawing.Point(4, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(41, 40)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(201, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(934, 24)
        Me.Label1.TabIndex = 419
        Me.Label1.Text = "Sub Categoria"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(191, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(10, 542)
        Me.Panel1.TabIndex = 420
        '
        'pnContenedorCategoria
        '
        Me.pnContenedorCategoria.Controls.Add(Me.Panel6)
        Me.pnContenedorCategoria.Controls.Add(Me.Panel10)
        Me.pnContenedorCategoria.Controls.Add(Me.Panel9)
        Me.pnContenedorCategoria.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnContenedorCategoria.Location = New System.Drawing.Point(0, 0)
        Me.pnContenedorCategoria.Name = "pnContenedorCategoria"
        Me.pnContenedorCategoria.Size = New System.Drawing.Size(191, 542)
        Me.pnContenedorCategoria.TabIndex = 418
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.flowCategoria)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(0, 73)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(191, 469)
        Me.Panel6.TabIndex = 4
        '
        'flowCategoria
        '
        Me.flowCategoria.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flowCategoria.Location = New System.Drawing.Point(0, 0)
        Me.flowCategoria.Name = "flowCategoria"
        Me.flowCategoria.Size = New System.Drawing.Size(191, 469)
        Me.flowCategoria.TabIndex = 2
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.PictureBox2)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel10.Location = New System.Drawing.Point(0, 24)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(191, 49)
        Me.Panel10.TabIndex = 6
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox2.Location = New System.Drawing.Point(4, 6)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(41, 40)
        Me.PictureBox2.TabIndex = 0
        Me.PictureBox2.TabStop = False
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel9.Controls.Add(Me.Label20)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel9.Location = New System.Drawing.Point(0, 0)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(191, 24)
        Me.Panel9.TabIndex = 6
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Label20.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label20.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(0, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(191, 24)
        Me.Label20.TabIndex = 0
        Me.Label20.Text = "Categoria"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 578)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1135, 12)
        Me.Panel2.TabIndex = 305
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BackColor = System.Drawing.Color.White
        Me.GradientPanel1.BackgroundImage = CType(resources.GetObject("GradientPanel1.BackgroundImage"), System.Drawing.Image)
        Me.GradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GradientPanel1.BorderColor = System.Drawing.Color.Silver
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GradientPanel1.Controls.Add(Me.BunifuFlatButton2)
        Me.GradientPanel1.Controls.Add(Me.BunifuFlatButton1)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(1135, 48)
        Me.GradientPanel1.TabIndex = 302
        '
        'BunifuFlatButton2
        '
        Me.BunifuFlatButton2.Activecolor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BunifuFlatButton2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BunifuFlatButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton2.BorderRadius = 5
        Me.BunifuFlatButton2.ButtonText = "ACTUALIZAR"
        Me.BunifuFlatButton2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton2.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton2.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BunifuFlatButton2.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton2.Iconimage = Nothing
        Me.BunifuFlatButton2.Iconimage_right = Nothing
        Me.BunifuFlatButton2.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton2.Iconimage_Selected = Nothing
        Me.BunifuFlatButton2.IconMarginLeft = 0
        Me.BunifuFlatButton2.IconMarginRight = 0
        Me.BunifuFlatButton2.IconRightVisible = True
        Me.BunifuFlatButton2.IconRightZoom = 0R
        Me.BunifuFlatButton2.IconVisible = True
        Me.BunifuFlatButton2.IconZoom = 90.0R
        Me.BunifuFlatButton2.IsTab = False
        Me.BunifuFlatButton2.Location = New System.Drawing.Point(12, 11)
        Me.BunifuFlatButton2.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton2.Name = "BunifuFlatButton2"
        Me.BunifuFlatButton2.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BunifuFlatButton2.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BunifuFlatButton2.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton2.selected = False
        Me.BunifuFlatButton2.Size = New System.Drawing.Size(118, 23)
        Me.BunifuFlatButton2.TabIndex = 697
        Me.BunifuFlatButton2.Text = "ACTUALIZAR"
        Me.BunifuFlatButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton2.Textcolor = System.Drawing.Color.White
        Me.BunifuFlatButton2.TextFont = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'BunifuFlatButton1
        '
        Me.BunifuFlatButton1.Activecolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.BunifuFlatButton1.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.BunifuFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton1.BorderRadius = 5
        Me.BunifuFlatButton1.ButtonText = "NUEVO"
        Me.BunifuFlatButton1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton1.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton1.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BunifuFlatButton1.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton1.Iconimage = Nothing
        Me.BunifuFlatButton1.Iconimage_right = Nothing
        Me.BunifuFlatButton1.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton1.Iconimage_Selected = Nothing
        Me.BunifuFlatButton1.IconMarginLeft = 0
        Me.BunifuFlatButton1.IconMarginRight = 0
        Me.BunifuFlatButton1.IconRightVisible = True
        Me.BunifuFlatButton1.IconRightZoom = 0R
        Me.BunifuFlatButton1.IconVisible = True
        Me.BunifuFlatButton1.IconZoom = 90.0R
        Me.BunifuFlatButton1.IsTab = False
        Me.BunifuFlatButton1.Location = New System.Drawing.Point(146, 11)
        Me.BunifuFlatButton1.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton1.Name = "BunifuFlatButton1"
        Me.BunifuFlatButton1.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.BunifuFlatButton1.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.BunifuFlatButton1.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton1.selected = False
        Me.BunifuFlatButton1.Size = New System.Drawing.Size(118, 23)
        Me.BunifuFlatButton1.TabIndex = 696
        Me.BunifuFlatButton1.Text = "NUEVO"
        Me.BunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton1.Textcolor = System.Drawing.Color.White
        Me.BunifuFlatButton1.TextFont = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton1.Visible = False
        '
        'Tab_GestionSubCategoria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnCategoria)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "Tab_GestionSubCategoria"
        Me.Size = New System.Drawing.Size(1135, 590)
        Me.pnCategoria.ResumeLayout(False)
        CType(Me.dgvPedidoDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnContenedorCategoria.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel10.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel9.ResumeLayout(False)
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents pnCategoria As Panel
    Friend WithEvents Panel2 As Panel
    Private WithEvents BunifuFlatButton1 As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents dgvPedidoDetalle As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Private WithEvents BunifuFlatButton2 As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents pnContenedorCategoria As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents flowCategoria As FlowLayoutPanel
    Friend WithEvents Panel10 As Panel
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Label20 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents PictureBox1 As PictureBox
End Class

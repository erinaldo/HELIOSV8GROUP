Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormClasificacionItem
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormClasificacionItem))
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.txtCategoria = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtModelo = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BunifuFlatButton1 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.GradientPanel3 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.dgvDetalles = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.PopupProductos = New Syncfusion.Windows.Forms.PopupControlContainer(Me.components)
        Me.GradientPanel6 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ListProductos = New System.Windows.Forms.ListView()
        Me.ID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.pcModelo = New Syncfusion.Windows.Forms.PopupControlContainer()
        Me.lsvModelo = New System.Windows.Forms.ListBox()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv2 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.pcLikeCategoria = New Syncfusion.Windows.Forms.PopupControlContainer()
        Me.lsvCategoria = New System.Windows.Forms.ListBox()
        Me.ButtonAdv3 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv10 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.BunifuFlatButton2 = New Bunifu.Framework.UI.BunifuFlatButton()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCategoria, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtModelo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel3.SuspendLayout()
        CType(Me.dgvDetalles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PopupProductos.SuspendLayout()
        CType(Me.GradientPanel6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel6.SuspendLayout()
        Me.pcModelo.SuspendLayout()
        Me.pcLikeCategoria.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(403, 29)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(21, 21)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 534
        Me.PictureBox3.TabStop = False
        '
        'txtCategoria
        '
        Me.txtCategoria.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.txtCategoria.BeforeTouchSize = New System.Drawing.Size(253, 22)
        Me.txtCategoria.BorderColor = System.Drawing.Color.DimGray
        Me.txtCategoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCategoria.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCategoria.CornerRadius = 4
        Me.txtCategoria.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtCategoria.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCategoria.ForeColor = System.Drawing.Color.White
        Me.txtCategoria.Location = New System.Drawing.Point(12, 29)
        Me.txtCategoria.Metrocolor = System.Drawing.Color.LightGray
        Me.txtCategoria.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtCategoria.Name = "txtCategoria"
        Me.txtCategoria.NearImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.IC632968
        Me.txtCategoria.Size = New System.Drawing.Size(253, 22)
        Me.txtCategoria.TabIndex = 533
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Silver
        Me.Label8.Location = New System.Drawing.Point(9, 11)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(108, 13)
        Me.Label8.TabIndex = 532
        Me.Label8.Text = "SUB CLASIFICACION"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(475, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(21, 21)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 537
        Me.PictureBox1.TabStop = False
        '
        'txtModelo
        '
        Me.txtModelo.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.txtModelo.BeforeTouchSize = New System.Drawing.Size(253, 22)
        Me.txtModelo.BorderColor = System.Drawing.Color.DimGray
        Me.txtModelo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtModelo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtModelo.CornerRadius = 4
        Me.txtModelo.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtModelo.Enabled = False
        Me.txtModelo.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtModelo.ForeColor = System.Drawing.Color.White
        Me.txtModelo.Location = New System.Drawing.Point(12, 79)
        Me.txtModelo.Metrocolor = System.Drawing.Color.LightGray
        Me.txtModelo.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtModelo.Name = "txtModelo"
        Me.txtModelo.NearImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.IC632968
        Me.txtModelo.Size = New System.Drawing.Size(253, 22)
        Me.txtModelo.TabIndex = 536
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Silver
        Me.Label1.Location = New System.Drawing.Point(9, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 535
        Me.Label1.Text = "MODELO"
        '
        'BunifuFlatButton1
        '
        Me.BunifuFlatButton1.Activecolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.BunifuFlatButton1.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.BunifuFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton1.BorderRadius = 5
        Me.BunifuFlatButton1.ButtonText = "Agregar Caracteristica"
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
        Me.BunifuFlatButton1.Location = New System.Drawing.Point(275, 78)
        Me.BunifuFlatButton1.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton1.Name = "BunifuFlatButton1"
        Me.BunifuFlatButton1.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.BunifuFlatButton1.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.BunifuFlatButton1.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton1.selected = False
        Me.BunifuFlatButton1.Size = New System.Drawing.Size(69, 27)
        Me.BunifuFlatButton1.TabIndex = 681
        Me.BunifuFlatButton1.Text = "Agregar Caracteristica"
        Me.BunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton1.Textcolor = System.Drawing.Color.White
        Me.BunifuFlatButton1.TextFont = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'GradientPanel3
        '
        Me.GradientPanel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GradientPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel3.Controls.Add(Me.dgvDetalles)
        Me.GradientPanel3.Controls.Add(Me.PopupProductos)
        Me.GradientPanel3.Location = New System.Drawing.Point(6, 110)
        Me.GradientPanel3.Name = "GradientPanel3"
        Me.GradientPanel3.Size = New System.Drawing.Size(342, 419)
        Me.GradientPanel3.TabIndex = 682
        '
        'dgvDetalles
        '
        Me.dgvDetalles.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.dgvDetalles.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        Me.dgvDetalles.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.dgvDetalles.BackColor = System.Drawing.Color.Black
        Me.dgvDetalles.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvDetalles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDetalles.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvDetalles.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgvDetalles.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2010Black
        Me.dgvDetalles.Location = New System.Drawing.Point(0, 0)
        Me.dgvDetalles.Name = "dgvDetalles"
        Me.dgvDetalles.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.dgvDetalles.Size = New System.Drawing.Size(340, 417)
        Me.dgvDetalles.TabIndex = 518
        Me.dgvDetalles.TableDescriptor.AllowNew = False
        Me.dgvDetalles.TableDescriptor.Appearance.AnyRecordFieldCell.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        GridColumnDescriptor1.HeaderText = "Nº"
        GridColumnDescriptor1.MappingName = "idCaracteristica"
        GridColumnDescriptor1.ReadOnly = True
        GridColumnDescriptor1.Width = 50
        GridColumnDescriptor2.HeaderText = "campo"
        GridColumnDescriptor2.MappingName = "campo"
        GridColumnDescriptor2.ReadOnly = True
        GridColumnDescriptor2.Width = 100
        GridColumnDescriptor3.MappingName = "descripcion"
        GridColumnDescriptor3.Width = 150
        Me.dgvDetalles.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3})
        Me.dgvDetalles.TableDescriptor.TableOptions.CaptionRowHeight = 29
        Me.dgvDetalles.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.dgvDetalles.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.dgvDetalles.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("idCaracteristica"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("campo"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("descripcion")})
        Me.dgvDetalles.Text = "gridGroupingControl1"
        Me.dgvDetalles.UseRightToLeftCompatibleTextBox = True
        Me.dgvDetalles.VersionInfo = "12.2400.0.20"
        '
        'PopupProductos
        '
        Me.PopupProductos.Controls.Add(Me.GradientPanel6)
        Me.PopupProductos.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PopupProductos.Location = New System.Drawing.Point(233, 171)
        Me.PopupProductos.Name = "PopupProductos"
        Me.PopupProductos.Size = New System.Drawing.Size(562, 147)
        Me.PopupProductos.TabIndex = 715
        Me.PopupProductos.Visible = False
        '
        'GradientPanel6
        '
        Me.GradientPanel6.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.GradientPanel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel6.Controls.Add(Me.ListProductos)
        Me.GradientPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel6.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel6.Name = "GradientPanel6"
        Me.GradientPanel6.Size = New System.Drawing.Size(562, 147)
        Me.GradientPanel6.TabIndex = 0
        '
        'ListProductos
        '
        Me.ListProductos.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.ListProductos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListProductos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ID, Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5})
        Me.ListProductos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListProductos.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListProductos.FullRowSelect = True
        Me.ListProductos.GridLines = True
        Me.ListProductos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListProductos.HideSelection = False
        Me.ListProductos.Location = New System.Drawing.Point(0, 0)
        Me.ListProductos.Name = "ListProductos"
        Me.ListProductos.Size = New System.Drawing.Size(560, 145)
        Me.ListProductos.TabIndex = 0
        Me.ListProductos.UseCompatibleStateImageBehavior = False
        Me.ListProductos.View = System.Windows.Forms.View.Details
        '
        'ID
        '
        Me.ID.Text = "ID"
        Me.ID.Width = 0
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Producto"
        Me.ColumnHeader1.Width = 289
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "U.M."
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Contenido"
        Me.ColumnHeader3.Width = 74
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Ultima compra"
        Me.ColumnHeader4.Width = 0
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Precio"
        Me.ColumnHeader5.Width = 91
        '
        'pcModelo
        '
        Me.pcModelo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pcModelo.Controls.Add(Me.lsvModelo)
        Me.pcModelo.Controls.Add(Me.ButtonAdv1)
        Me.pcModelo.Controls.Add(Me.ButtonAdv2)
        Me.pcModelo.Location = New System.Drawing.Point(451, 98)
        Me.pcModelo.Name = "pcModelo"
        Me.pcModelo.Size = New System.Drawing.Size(193, 80)
        Me.pcModelo.TabIndex = 711
        Me.pcModelo.Visible = False
        '
        'lsvModelo
        '
        Me.lsvModelo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lsvModelo.Dock = System.Windows.Forms.DockStyle.Top
        Me.lsvModelo.FormattingEnabled = True
        Me.lsvModelo.Location = New System.Drawing.Point(0, 0)
        Me.lsvModelo.Name = "lsvModelo"
        Me.lsvModelo.Size = New System.Drawing.Size(191, 104)
        Me.lsvModelo.TabIndex = 3
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.SystemColors.Highlight
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(171, 42)
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(59, 110)
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(171, 42)
        Me.ButtonAdv1.TabIndex = 2
        Me.ButtonAdv1.Text = "Cancel"
        Me.ButtonAdv1.UseVisualStyle = True
        '
        'ButtonAdv2
        '
        Me.ButtonAdv2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonAdv2.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv2.BackColor = System.Drawing.SystemColors.Highlight
        Me.ButtonAdv2.BeforeTouchSize = New System.Drawing.Size(171, 42)
        Me.ButtonAdv2.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv2.IsBackStageButton = False
        Me.ButtonAdv2.Location = New System.Drawing.Point(3, 110)
        Me.ButtonAdv2.Name = "ButtonAdv2"
        Me.ButtonAdv2.Size = New System.Drawing.Size(171, 42)
        Me.ButtonAdv2.TabIndex = 1
        Me.ButtonAdv2.Text = "OK"
        Me.ButtonAdv2.UseVisualStyle = True
        '
        'pcLikeCategoria
        '
        Me.pcLikeCategoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pcLikeCategoria.Controls.Add(Me.lsvCategoria)
        Me.pcLikeCategoria.Controls.Add(Me.ButtonAdv3)
        Me.pcLikeCategoria.Controls.Add(Me.ButtonAdv10)
        Me.pcLikeCategoria.Location = New System.Drawing.Point(447, 9)
        Me.pcLikeCategoria.Name = "pcLikeCategoria"
        Me.pcLikeCategoria.Size = New System.Drawing.Size(193, 80)
        Me.pcLikeCategoria.TabIndex = 712
        Me.pcLikeCategoria.Visible = False
        '
        'lsvCategoria
        '
        Me.lsvCategoria.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lsvCategoria.Dock = System.Windows.Forms.DockStyle.Top
        Me.lsvCategoria.FormattingEnabled = True
        Me.lsvCategoria.Location = New System.Drawing.Point(0, 0)
        Me.lsvCategoria.Name = "lsvCategoria"
        Me.lsvCategoria.Size = New System.Drawing.Size(191, 104)
        Me.lsvCategoria.TabIndex = 3
        '
        'ButtonAdv3
        '
        Me.ButtonAdv3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonAdv3.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv3.BackColor = System.Drawing.SystemColors.Highlight
        Me.ButtonAdv3.BeforeTouchSize = New System.Drawing.Size(171, 42)
        Me.ButtonAdv3.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv3.IsBackStageButton = False
        Me.ButtonAdv3.Location = New System.Drawing.Point(59, 110)
        Me.ButtonAdv3.Name = "ButtonAdv3"
        Me.ButtonAdv3.Size = New System.Drawing.Size(171, 42)
        Me.ButtonAdv3.TabIndex = 2
        Me.ButtonAdv3.Text = "Cancel"
        Me.ButtonAdv3.UseVisualStyle = True
        '
        'ButtonAdv10
        '
        Me.ButtonAdv10.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonAdv10.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv10.BackColor = System.Drawing.SystemColors.Highlight
        Me.ButtonAdv10.BeforeTouchSize = New System.Drawing.Size(171, 42)
        Me.ButtonAdv10.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv10.IsBackStageButton = False
        Me.ButtonAdv10.Location = New System.Drawing.Point(3, 110)
        Me.ButtonAdv10.Name = "ButtonAdv10"
        Me.ButtonAdv10.Size = New System.Drawing.Size(171, 42)
        Me.ButtonAdv10.TabIndex = 1
        Me.ButtonAdv10.Text = "OK"
        Me.ButtonAdv10.UseVisualStyle = True
        '
        'BunifuFlatButton2
        '
        Me.BunifuFlatButton2.Activecolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.BunifuFlatButton2.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.BunifuFlatButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton2.BorderRadius = 5
        Me.BunifuFlatButton2.ButtonText = "Agregar Plantilla"
        Me.BunifuFlatButton2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton2.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton2.Enabled = False
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
        Me.BunifuFlatButton2.Location = New System.Drawing.Point(429, 47)
        Me.BunifuFlatButton2.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton2.Name = "BunifuFlatButton2"
        Me.BunifuFlatButton2.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.BunifuFlatButton2.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.BunifuFlatButton2.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton2.selected = False
        Me.BunifuFlatButton2.Size = New System.Drawing.Size(83, 27)
        Me.BunifuFlatButton2.TabIndex = 713
        Me.BunifuFlatButton2.Text = "Agregar Plantilla"
        Me.BunifuFlatButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton2.Textcolor = System.Drawing.Color.White
        Me.BunifuFlatButton2.TextFont = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton2.Visible = False
        '
        'FormClasificacionItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.BorderColor = System.Drawing.Color.Cyan
        Me.CaptionBarColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.CaptionButtonColor = System.Drawing.Color.White
        Me.CaptionButtonHoverColor = System.Drawing.Color.White
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.Cyan
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(300, 24)
        CaptionLabel1.Text = "Caracteristicas Por Modelo"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(355, 532)
        Me.Controls.Add(Me.BunifuFlatButton2)
        Me.Controls.Add(Me.pcLikeCategoria)
        Me.Controls.Add(Me.BunifuFlatButton1)
        Me.Controls.Add(Me.pcModelo)
        Me.Controls.Add(Me.GradientPanel3)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.txtModelo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.txtCategoria)
        Me.Controls.Add(Me.Label8)
        Me.Name = "FormClasificacionItem"
        Me.ShowIcon = False
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCategoria, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtModelo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel3.ResumeLayout(False)
        CType(Me.dgvDetalles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PopupProductos.ResumeLayout(False)
        CType(Me.GradientPanel6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel6.ResumeLayout(False)
        Me.pcModelo.ResumeLayout(False)
        Me.pcLikeCategoria.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents txtCategoria As Tools.TextBoxExt
    Friend WithEvents Label8 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents txtModelo As Tools.TextBoxExt
    Friend WithEvents Label1 As Label
    Private WithEvents BunifuFlatButton1 As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents GradientPanel3 As Tools.GradientPanel
    Private WithEvents dgvDetalles As Grid.Grouping.GridGroupingControl
    Private WithEvents PopupProductos As PopupControlContainer
    Friend WithEvents GradientPanel6 As Tools.GradientPanel
    Friend WithEvents ListProductos As ListView
    Friend WithEvents ID As ColumnHeader
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Private WithEvents pcModelo As PopupControlContainer
    Friend WithEvents lsvModelo As ListBox
    Private WithEvents ButtonAdv1 As ButtonAdv
    Private WithEvents ButtonAdv2 As ButtonAdv
    Private WithEvents pcLikeCategoria As PopupControlContainer
    Friend WithEvents lsvCategoria As ListBox
    Private WithEvents ButtonAdv3 As ButtonAdv
    Private WithEvents ButtonAdv10 As ButtonAdv
    Private WithEvents BunifuFlatButton2 As Bunifu.Framework.UI.BunifuFlatButton
End Class

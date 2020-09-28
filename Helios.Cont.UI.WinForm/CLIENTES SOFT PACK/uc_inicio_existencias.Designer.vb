<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uc_inicio_existencias
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(uc_inicio_existencias))
        Dim GridColumnDescriptor25 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor26 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor27 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor28 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor29 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor30 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor31 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor32 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridConditionalFormatDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridConditionalFormatDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridConditionalFormatDescriptor()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CurrencyTextBox1 = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtTipoCambio = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboalmacenKardex = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv14 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtArticulo = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Panel22 = New System.Windows.Forms.Panel()
        Me.dgvExistencias = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.pcExistencias = New Syncfusion.Windows.Forms.PopupControlContainer()
        Me.lsvArticulos = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ButtonAdv11 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv12 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.cboTipoExistencia = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.CurrencyTextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoCambio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboalmacenKardex, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtArticulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvExistencias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pcExistencias.SuspendLayout()
        CType(Me.cboTipoExistencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.cboTipoExistencia)
        Me.Panel1.Controls.Add(Me.CurrencyTextBox1)
        Me.Panel1.Controls.Add(Me.txtTipoCambio)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.cboalmacenKardex)
        Me.Panel1.Controls.Add(Me.Label28)
        Me.Panel1.Controls.Add(Me.ButtonAdv1)
        Me.Panel1.Controls.Add(Me.ButtonAdv14)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtArticulo)
        Me.Panel1.Controls.Add(Me.Panel22)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(966, 71)
        Me.Panel1.TabIndex = 3
        '
        'CurrencyTextBox1
        '
        Me.CurrencyTextBox1.BackGroundColor = System.Drawing.Color.White
        Me.CurrencyTextBox1.BeforeTouchSize = New System.Drawing.Size(248, 22)
        Me.CurrencyTextBox1.BorderColor = System.Drawing.Color.Silver
        Me.CurrencyTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CurrencyTextBox1.CurrencyDecimalDigits = 3
        Me.CurrencyTextBox1.CurrencySymbol = ""
        Me.CurrencyTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.CurrencyTextBox1.DecimalValue = New Decimal(New Integer() {0, 0, 0, 196608})
        Me.CurrencyTextBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CurrencyTextBox1.Location = New System.Drawing.Point(806, 34)
        Me.CurrencyTextBox1.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CurrencyTextBox1.MinimumSize = New System.Drawing.Size(14, 10)
        Me.CurrencyTextBox1.Name = "CurrencyTextBox1"
        Me.CurrencyTextBox1.NullString = ""
        Me.CurrencyTextBox1.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CurrencyTextBox1.ReadOnlyBackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.CurrencyTextBox1.Size = New System.Drawing.Size(62, 22)
        Me.CurrencyTextBox1.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.CurrencyTextBox1.TabIndex = 512
        Me.CurrencyTextBox1.Text = "0.000"
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.BackGroundColor = System.Drawing.Color.White
        Me.txtTipoCambio.BeforeTouchSize = New System.Drawing.Size(248, 22)
        Me.txtTipoCambio.BorderColor = System.Drawing.Color.Silver
        Me.txtTipoCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTipoCambio.CurrencyDecimalDigits = 3
        Me.txtTipoCambio.CurrencySymbol = ""
        Me.txtTipoCambio.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTipoCambio.DecimalValue = New Decimal(New Integer() {0, 0, 0, 196608})
        Me.txtTipoCambio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTipoCambio.Location = New System.Drawing.Point(738, 34)
        Me.txtTipoCambio.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTipoCambio.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.NullString = ""
        Me.txtTipoCambio.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTipoCambio.ReadOnlyBackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtTipoCambio.Size = New System.Drawing.Size(62, 22)
        Me.txtTipoCambio.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtTipoCambio.TabIndex = 511
        Me.txtTipoCambio.Text = "0.000"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(803, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 16)
        Me.Label3.TabIndex = 510
        Me.Label3.Text = "Monto"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(735, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 16)
        Me.Label1.TabIndex = 509
        Me.Label1.Text = "Cant."
        '
        'cboalmacenKardex
        '
        Me.cboalmacenKardex.BackColor = System.Drawing.Color.White
        Me.cboalmacenKardex.BeforeTouchSize = New System.Drawing.Size(191, 21)
        Me.cboalmacenKardex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboalmacenKardex.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboalmacenKardex.Location = New System.Drawing.Point(11, 35)
        Me.cboalmacenKardex.Name = "cboalmacenKardex"
        Me.cboalmacenKardex.Size = New System.Drawing.Size(191, 21)
        Me.cboalmacenKardex.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboalmacenKardex.TabIndex = 508
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Century Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(10, 17)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(56, 16)
        Me.Label28.TabIndex = 507
        Me.Label28.Text = "Almacén"
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(75, 32)
        Me.ButtonAdv1.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.Image = CType(resources.GetObject("ButtonAdv1.Image"), System.Drawing.Image)
        Me.ButtonAdv1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(660, 24)
        Me.ButtonAdv1.MetroColor = System.Drawing.Color.Green
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(75, 32)
        Me.ButtonAdv1.TabIndex = 506
        Me.ButtonAdv1.Text = "          Nuevo"
        Me.ButtonAdv1.UseVisualStyle = True
        Me.ButtonAdv1.UseVisualStyleBackColor = False
        '
        'ButtonAdv14
        '
        Me.ButtonAdv14.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv14.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.ButtonAdv14.BeforeTouchSize = New System.Drawing.Size(62, 32)
        Me.ButtonAdv14.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv14.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv14.Image = CType(resources.GetObject("ButtonAdv14.Image"), System.Drawing.Image)
        Me.ButtonAdv14.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv14.IsBackStageButton = False
        Me.ButtonAdv14.Location = New System.Drawing.Point(873, 24)
        Me.ButtonAdv14.MetroColor = System.Drawing.Color.Green
        Me.ButtonAdv14.Name = "ButtonAdv14"
        Me.ButtonAdv14.Size = New System.Drawing.Size(62, 32)
        Me.ButtonAdv14.TabIndex = 505
        Me.ButtonAdv14.Text = "         Add"
        Me.ButtonAdv14.UseVisualStyle = True
        Me.ButtonAdv14.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(406, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 16)
        Me.Label2.TabIndex = 504
        Me.Label2.Text = "Artículo"
        '
        'txtArticulo
        '
        Me.txtArticulo.BackColor = System.Drawing.Color.White
        Me.txtArticulo.BeforeTouchSize = New System.Drawing.Size(248, 22)
        Me.txtArticulo.BorderColor = System.Drawing.Color.Silver
        Me.txtArticulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtArticulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtArticulo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtArticulo.Enabled = False
        Me.txtArticulo.Location = New System.Drawing.Point(406, 34)
        Me.txtArticulo.Metrocolor = System.Drawing.Color.Silver
        Me.txtArticulo.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtArticulo.Name = "txtArticulo"
        Me.txtArticulo.Size = New System.Drawing.Size(248, 22)
        Me.txtArticulo.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtArticulo.TabIndex = 502
        '
        'Panel22
        '
        Me.Panel22.BackgroundImage = CType(resources.GetObject("Panel22.BackgroundImage"), System.Drawing.Image)
        Me.Panel22.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Panel22.Location = New System.Drawing.Point(905, 71)
        Me.Panel22.Name = "Panel22"
        Me.Panel22.Size = New System.Drawing.Size(30, 30)
        Me.Panel22.TabIndex = 429
        '
        'dgvExistencias
        '
        Me.dgvExistencias.BackColor = System.Drawing.Color.Gainsboro
        Me.dgvExistencias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvExistencias.FreezeCaption = False
        Me.dgvExistencias.Location = New System.Drawing.Point(0, 71)
        Me.dgvExistencias.Name = "dgvExistencias"
        Me.dgvExistencias.Size = New System.Drawing.Size(966, 335)
        Me.dgvExistencias.TabIndex = 5
        GridColumnDescriptor25.HeaderImage = Nothing
        GridColumnDescriptor25.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor25.MappingName = "iditem"
        GridColumnDescriptor25.SerializedImageArray = ""
        GridColumnDescriptor26.HeaderImage = Nothing
        GridColumnDescriptor26.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor26.MappingName = "secuencia"
        GridColumnDescriptor26.SerializedImageArray = ""
        GridColumnDescriptor26.Width = 36
        GridColumnDescriptor27.HeaderImage = Nothing
        GridColumnDescriptor27.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor27.MappingName = "detalle"
        GridColumnDescriptor27.SerializedImageArray = ""
        GridColumnDescriptor27.Width = 255
        GridColumnDescriptor28.HeaderImage = Nothing
        GridColumnDescriptor28.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor28.MappingName = "unidad"
        GridColumnDescriptor28.SerializedImageArray = ""
        GridColumnDescriptor29.HeaderImage = Nothing
        GridColumnDescriptor29.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor29.MappingName = "tipoexistencia"
        GridColumnDescriptor29.SerializedImageArray = ""
        GridColumnDescriptor29.Width = 82
        GridColumnDescriptor30.HeaderImage = Nothing
        GridColumnDescriptor30.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor30.MappingName = "cantidad"
        GridColumnDescriptor30.SerializedImageArray = ""
        GridColumnDescriptor31.HeaderImage = Nothing
        GridColumnDescriptor31.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor31.MappingName = "costo"
        GridColumnDescriptor31.SerializedImageArray = ""
        GridColumnDescriptor31.Width = 87
        GridColumnDescriptor32.HeaderImage = Nothing
        GridColumnDescriptor32.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor32.MappingName = "almacen"
        GridColumnDescriptor32.SerializedImageArray = ""
        GridColumnDescriptor32.Width = 154
        Me.dgvExistencias.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor25, GridColumnDescriptor26, GridColumnDescriptor27, GridColumnDescriptor28, GridColumnDescriptor29, GridColumnDescriptor30, GridColumnDescriptor31, GridColumnDescriptor32})
        GridConditionalFormatDescriptor4.Name = "ConditionalFormat 1"
        Me.dgvExistencias.TableDescriptor.ConditionalFormats.Add(GridConditionalFormatDescriptor4)
        Me.dgvExistencias.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("iditem"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("secuencia"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("detalle"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("unidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipoexistencia"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("cantidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("costo"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("almacen")})
        Me.dgvExistencias.TableOptions.GridLineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder()
        Me.dgvExistencias.TableOptions.ListBoxSelectionOutlineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.Transparent)
        Me.dgvExistencias.TableOptions.TreeLineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.White)
        Me.dgvExistencias.Text = "GridGroupingControl1"
        Me.dgvExistencias.VersionInfo = "12.4400.0.24"
        '
        'pcExistencias
        '
        Me.pcExistencias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pcExistencias.Controls.Add(Me.lsvArticulos)
        Me.pcExistencias.Controls.Add(Me.ButtonAdv11)
        Me.pcExistencias.Controls.Add(Me.ButtonAdv12)
        Me.pcExistencias.Location = New System.Drawing.Point(222, 94)
        Me.pcExistencias.Name = "pcExistencias"
        Me.pcExistencias.Size = New System.Drawing.Size(193, 80)
        Me.pcExistencias.TabIndex = 492
        Me.pcExistencias.Visible = False
        '
        'lsvArticulos
        '
        Me.lsvArticulos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lsvArticulos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lsvArticulos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvArticulos.Location = New System.Drawing.Point(0, 0)
        Me.lsvArticulos.Name = "lsvArticulos"
        Me.lsvArticulos.Size = New System.Drawing.Size(191, 78)
        Me.lsvArticulos.TabIndex = 492
        Me.lsvArticulos.UseCompatibleStateImageBehavior = False
        Me.lsvArticulos.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Artículo"
        Me.ColumnHeader2.Width = 195
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Gr."
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader3.Width = 30
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Tipo existencia"
        Me.ColumnHeader4.Width = 93
        '
        'ButtonAdv11
        '
        Me.ButtonAdv11.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonAdv11.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv11.BackColor = System.Drawing.SystemColors.Highlight
        Me.ButtonAdv11.BeforeTouchSize = New System.Drawing.Size(171, 42)
        Me.ButtonAdv11.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv11.IsBackStageButton = False
        Me.ButtonAdv11.Location = New System.Drawing.Point(59, 110)
        Me.ButtonAdv11.Name = "ButtonAdv11"
        Me.ButtonAdv11.Size = New System.Drawing.Size(171, 42)
        Me.ButtonAdv11.TabIndex = 2
        Me.ButtonAdv11.Text = "Cancel"
        Me.ButtonAdv11.UseVisualStyle = True
        '
        'ButtonAdv12
        '
        Me.ButtonAdv12.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonAdv12.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv12.BackColor = System.Drawing.SystemColors.Highlight
        Me.ButtonAdv12.BeforeTouchSize = New System.Drawing.Size(171, 42)
        Me.ButtonAdv12.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv12.IsBackStageButton = False
        Me.ButtonAdv12.Location = New System.Drawing.Point(3, 110)
        Me.ButtonAdv12.Name = "ButtonAdv12"
        Me.ButtonAdv12.Size = New System.Drawing.Size(171, 42)
        Me.ButtonAdv12.TabIndex = 1
        Me.ButtonAdv12.Text = "OK"
        Me.ButtonAdv12.UseVisualStyle = True
        '
        'cboTipoExistencia
        '
        Me.cboTipoExistencia.BackColor = System.Drawing.Color.White
        Me.cboTipoExistencia.BeforeTouchSize = New System.Drawing.Size(191, 21)
        Me.cboTipoExistencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoExistencia.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoExistencia.Location = New System.Drawing.Point(209, 35)
        Me.cboTipoExistencia.Name = "cboTipoExistencia"
        Me.cboTipoExistencia.Size = New System.Drawing.Size(191, 21)
        Me.cboTipoExistencia.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboTipoExistencia.TabIndex = 513
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Century Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(209, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 16)
        Me.Label4.TabIndex = 514
        Me.Label4.Text = "Tipo existencia"
        '
        'uc_inicio_existencias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.Controls.Add(Me.pcExistencias)
        Me.Controls.Add(Me.dgvExistencias)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "uc_inicio_existencias"
        Me.Size = New System.Drawing.Size(966, 406)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.CurrencyTextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoCambio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboalmacenKardex, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtArticulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvExistencias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pcExistencias.ResumeLayout(False)
        CType(Me.cboTipoExistencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents dgvExistencias As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents Panel22 As Panel
    Friend WithEvents txtArticulo As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label2 As Label
    Friend WithEvents ButtonAdv14 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents cboalmacenKardex As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label28 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents CurrencyTextBox1 As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtTipoCambio As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Private WithEvents pcExistencias As Syncfusion.Windows.Forms.PopupControlContainer
    Friend WithEvents lsvArticulos As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Private WithEvents ButtonAdv11 As Syncfusion.Windows.Forms.ButtonAdv
    Private WithEvents ButtonAdv12 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents Label4 As Label
    Friend WithEvents cboTipoExistencia As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
End Class

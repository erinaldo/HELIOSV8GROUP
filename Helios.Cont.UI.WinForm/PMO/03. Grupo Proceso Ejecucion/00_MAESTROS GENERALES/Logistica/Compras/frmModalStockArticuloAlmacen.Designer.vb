<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModalStockArticuloAlmacen
    Inherits frmMaster

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
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor6 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor7 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor8 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor9 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmModalStockArticuloAlmacen))
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Dim CaptionLabel2 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.dgvArticulos = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboMotivo = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.txtBaseDev = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtBaseMov = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCanMov = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtCanDev = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.dgvArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel16.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.cboMotivo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBaseDev, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBaseMov, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCanMov, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCanDev, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvArticulos
        '
        Me.dgvArticulos.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        Me.dgvArticulos.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.dgvArticulos.BackColor = System.Drawing.SystemColors.Window
        Me.dgvArticulos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvArticulos.FreezeCaption = False
        Me.dgvArticulos.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgvArticulos.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.dgvArticulos.Location = New System.Drawing.Point(0, 0)
        Me.dgvArticulos.Name = "dgvArticulos"
        Me.dgvArticulos.Size = New System.Drawing.Size(695, 224)
        Me.dgvArticulos.TabIndex = 404
        Me.dgvArticulos.TableDescriptor.AllowNew = False
        Me.dgvArticulos.TableDescriptor.Appearance.AnyCell.Font.Facename = "Segoe UI"
        Me.dgvArticulos.TableDescriptor.Appearance.AnyCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.dgvArticulos.TableDescriptor.Appearance.AnyGroupCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvArticulos.TableDescriptor.Appearance.AnyGroupCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvArticulos.TableDescriptor.Appearance.AnyGroupCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer)))
        Me.dgvArticulos.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvArticulos.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvArticulos.TableDescriptor.Appearance.AnySummaryCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvArticulos.TableDescriptor.Appearance.AnySummaryCell.Borders.Top = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvArticulos.TableDescriptor.Appearance.AnySummaryCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)))
        Me.dgvArticulos.TableDescriptor.Appearance.ColumnHeaderCell.Font.Bold = True
        Me.dgvArticulos.TableDescriptor.Appearance.ColumnHeaderCell.Font.Italic = False
        Me.dgvArticulos.TableDescriptor.Appearance.ColumnHeaderCell.Font.Size = 8.0!
        Me.dgvArticulos.TableDescriptor.Appearance.GroupCaptionCell.CellType = """ColumnHeader"""
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.MappingName = "idAlmacen"
        GridColumnDescriptor1.ReadOnly = True
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor1.Width = 40
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.MappingName = "idItem"
        GridColumnDescriptor2.ReadOnly = True
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor2.Width = 40
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.HeaderText = "Almacén"
        GridColumnDescriptor3.MappingName = "almacen"
        GridColumnDescriptor3.ReadOnly = True
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor3.Width = 120
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.MappingName = "item"
        GridColumnDescriptor4.ReadOnly = True
        GridColumnDescriptor4.SerializedImageArray = ""
        GridColumnDescriptor4.Width = 180
        GridColumnDescriptor5.HeaderImage = Nothing
        GridColumnDescriptor5.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor5.HeaderText = "U.M."
        GridColumnDescriptor5.MappingName = "unidad"
        GridColumnDescriptor5.ReadOnly = True
        GridColumnDescriptor5.SerializedImageArray = ""
        GridColumnDescriptor5.Width = 70
        GridColumnDescriptor6.HeaderImage = Nothing
        GridColumnDescriptor6.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor6.HeaderText = "Stock"
        GridColumnDescriptor6.MappingName = "cant"
        GridColumnDescriptor6.ReadOnly = True
        GridColumnDescriptor6.SerializedImageArray = ""
        GridColumnDescriptor6.Width = 70
        GridColumnDescriptor7.HeaderImage = Nothing
        GridColumnDescriptor7.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor7.HeaderText = "Costo MN."
        GridColumnDescriptor7.MappingName = "monto"
        GridColumnDescriptor7.ReadOnly = True
        GridColumnDescriptor7.SerializedImageArray = ""
        GridColumnDescriptor7.Width = 75
        GridColumnDescriptor8.HeaderImage = Nothing
        GridColumnDescriptor8.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor8.HeaderText = "Costo ME."
        GridColumnDescriptor8.MappingName = "montoME"
        GridColumnDescriptor8.ReadOnly = True
        GridColumnDescriptor8.SerializedImageArray = ""
        GridColumnDescriptor8.Width = 75
        GridColumnDescriptor9.HeaderImage = Nothing
        GridColumnDescriptor9.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor9.MappingName = "codigoLote"
        GridColumnDescriptor9.ReadOnly = True
        GridColumnDescriptor9.SerializedImageArray = ""
        GridColumnDescriptor9.Width = 50
        Me.dgvArticulos.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7, GridColumnDescriptor8, GridColumnDescriptor9})
        Me.dgvArticulos.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.dgvArticulos.TableDescriptor.TableOptions.RecordRowHeight = 20
        Me.dgvArticulos.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("almacen"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("item"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("unidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("cant"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("monto"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("montoME"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("codigoLote")})
        Me.dgvArticulos.Text = "GridGroupingControl2"
        Me.dgvArticulos.VersionInfo = "12.4400.0.24"
        '
        'Panel16
        '
        Me.Panel16.BackColor = System.Drawing.Color.White
        Me.Panel16.Controls.Add(Me.Button1)
        Me.Panel16.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel16.Location = New System.Drawing.Point(0, 333)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(695, 47)
        Me.Panel16.TabIndex = 405
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.OrangeRed
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(294, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(109, 36)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Aceptar"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.cboMotivo)
        Me.Panel1.Controls.Add(Me.txtBaseDev)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtBaseMov)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtCanMov)
        Me.Panel1.Controls.Add(Me.txtCanDev)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 224)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(695, 109)
        Me.Panel1.TabIndex = 406
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(19, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(146, 14)
        Me.Label5.TabIndex = 501
        Me.Label5.Text = "Movimiento : nota de crédito"
        '
        'cboMotivo
        '
        Me.cboMotivo.BackColor = System.Drawing.Color.White
        Me.cboMotivo.BeforeTouchSize = New System.Drawing.Size(236, 21)
        Me.cboMotivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMotivo.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMotivo.Location = New System.Drawing.Point(22, 28)
        Me.cboMotivo.Name = "cboMotivo"
        Me.cboMotivo.Size = New System.Drawing.Size(236, 21)
        Me.cboMotivo.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboMotivo.TabIndex = 500
        '
        'txtBaseDev
        '
        Me.txtBaseDev.BackColor = System.Drawing.SystemColors.Info
        Me.txtBaseDev.BeforeTouchSize = New System.Drawing.Size(94, 22)
        Me.txtBaseDev.BorderColor = System.Drawing.Color.Chocolate
        Me.txtBaseDev.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBaseDev.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBaseDev.Font = New System.Drawing.Font("Ebrima", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBaseDev.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtBaseDev.Location = New System.Drawing.Point(391, 76)
        Me.txtBaseDev.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtBaseDev.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtBaseDev.Name = "txtBaseDev"
        Me.txtBaseDev.ReadOnly = True
        Me.txtBaseDev.Size = New System.Drawing.Size(114, 24)
        Me.txtBaseDev.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtBaseDev.TabIndex = 499
        Me.txtBaseDev.Tag = "07"
        Me.txtBaseDev.Text = "0.00"
        Me.txtBaseDev.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(391, 57)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 14)
        Me.Label4.TabIndex = 498
        Me.Label4.Text = "Importe dev. (s/IGV.)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(388, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 14)
        Me.Label3.TabIndex = 497
        Me.Label3.Text = "Base imp. (sin IGV.)"
        '
        'txtBaseMov
        '
        Me.txtBaseMov.BackGroundColor = System.Drawing.Color.White
        Me.txtBaseMov.BeforeTouchSize = New System.Drawing.Size(94, 22)
        Me.txtBaseMov.BorderColor = System.Drawing.Color.Silver
        Me.txtBaseMov.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBaseMov.CurrencyDecimalDigits = 4
        Me.txtBaseMov.CurrencySymbol = ""
        Me.txtBaseMov.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBaseMov.DecimalValue = New Decimal(New Integer() {0, 0, 0, 262144})
        Me.txtBaseMov.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtBaseMov.Location = New System.Drawing.Point(391, 27)
        Me.txtBaseMov.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtBaseMov.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtBaseMov.Name = "txtBaseMov"
        Me.txtBaseMov.NullString = ""
        Me.txtBaseMov.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtBaseMov.ReadOnlyBackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtBaseMov.Size = New System.Drawing.Size(114, 22)
        Me.txtBaseMov.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtBaseMov.TabIndex = 496
        Me.txtBaseMov.Text = "0.0000"
        Me.txtBaseMov.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(272, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 14)
        Me.Label2.TabIndex = 495
        Me.Label2.Text = "Cantidad a mover"
        '
        'txtCanMov
        '
        Me.txtCanMov.BackGroundColor = System.Drawing.Color.White
        Me.txtCanMov.BeforeTouchSize = New System.Drawing.Size(94, 22)
        Me.txtCanMov.BorderColor = System.Drawing.Color.Silver
        Me.txtCanMov.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCanMov.CurrencyDecimalDigits = 3
        Me.txtCanMov.CurrencySymbol = ""
        Me.txtCanMov.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCanMov.DecimalValue = New Decimal(New Integer() {0, 0, 0, 196608})
        Me.txtCanMov.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtCanMov.Location = New System.Drawing.Point(275, 27)
        Me.txtCanMov.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtCanMov.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtCanMov.Name = "txtCanMov"
        Me.txtCanMov.NullString = ""
        Me.txtCanMov.PositiveColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtCanMov.ReadOnlyBackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtCanMov.Size = New System.Drawing.Size(94, 22)
        Me.txtCanMov.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtCanMov.TabIndex = 494
        Me.txtCanMov.Text = "0.000"
        Me.txtCanMov.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCanDev
        '
        Me.txtCanDev.BackColor = System.Drawing.SystemColors.Info
        Me.txtCanDev.BeforeTouchSize = New System.Drawing.Size(94, 22)
        Me.txtCanDev.BorderColor = System.Drawing.Color.Chocolate
        Me.txtCanDev.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCanDev.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCanDev.Font = New System.Drawing.Font("Ebrima", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCanDev.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtCanDev.Location = New System.Drawing.Point(275, 76)
        Me.txtCanDev.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtCanDev.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtCanDev.Name = "txtCanDev"
        Me.txtCanDev.ReadOnly = True
        Me.txtCanDev.Size = New System.Drawing.Size(94, 24)
        Me.txtCanDev.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtCanDev.TabIndex = 217
        Me.txtCanDev.Tag = "07"
        Me.txtCanDev.Text = "0.00"
        Me.txtCanDev.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(272, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cant. a devolver"
        '
        'frmModalStockArticuloAlmacen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.SystemColors.Window
        Me.CaptionBarHeight = 55
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(15, 15)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(30, 30)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.Location = New System.Drawing.Point(55, 8)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(200, 24)
        CaptionLabel1.Text = "Artículos Disponibles"
        CaptionLabel2.Font = New System.Drawing.Font("Corbel", 13.0!)
        CaptionLabel2.ForeColor = System.Drawing.Color.OrangeRed
        CaptionLabel2.Location = New System.Drawing.Point(55, 23)
        CaptionLabel2.Name = "CaptionLabel2"
        CaptionLabel2.Size = New System.Drawing.Size(200, 24)
        CaptionLabel2.Text = "Inventario"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.CaptionLabels.Add(CaptionLabel2)
        Me.ClientSize = New System.Drawing.Size(695, 380)
        Me.Controls.Add(Me.dgvArticulos)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel16)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmModalStockArticuloAlmacen"
        Me.ShowIcon = False
        Me.Text = ""
        CType(Me.dgvArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel16.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.cboMotivo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBaseDev, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBaseMov, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCanMov, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCanDev, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvArticulos As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents Panel16 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtCanDev As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtBaseMov As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCanMov As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtBaseDev As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboMotivo As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
End Class

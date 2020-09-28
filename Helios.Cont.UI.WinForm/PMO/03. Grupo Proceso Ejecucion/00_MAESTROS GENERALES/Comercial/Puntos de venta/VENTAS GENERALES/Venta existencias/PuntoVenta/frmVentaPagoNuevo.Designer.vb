Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmVentaPagoNuevo
    Inherits MetroForm

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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
        Dim GridColumnDescriptor11 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor12 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor13 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor14 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor15 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridSummaryRowDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor()
        Dim GridSummaryColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv2 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.btOperacion = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.cboCajas = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.gradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.dgvCuentas = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.txtMontoXcobrar = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ChBanco = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ChEfectivo = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GradientPanel3 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCajas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gradientPanel2.SuspendLayout()
        CType(Me.dgvCuentas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMontoXcobrar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BackgroundColor = New Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.PatternStyle.Weave, System.Drawing.Color.White, System.Drawing.Color.White)
        Me.GradientPanel1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.GradientPanel1.BorderSides = System.Windows.Forms.Border3DSide.Top
        Me.GradientPanel1.BorderSingle = System.Windows.Forms.ButtonBorderStyle.Dotted
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(894, 10)
        Me.GradientPanel1.TabIndex = 418
        '
        'ButtonAdv2
        '
        Me.ButtonAdv2.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.ButtonAdv2.BeforeTouchSize = New System.Drawing.Size(53, 26)
        Me.ButtonAdv2.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv2.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv2.IsBackStageButton = False
        Me.ButtonAdv2.Location = New System.Drawing.Point(405, 66)
        Me.ButtonAdv2.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonAdv2.Name = "ButtonAdv2"
        Me.ButtonAdv2.Size = New System.Drawing.Size(53, 26)
        Me.ButtonAdv2.TabIndex = 524
        Me.ButtonAdv2.Text = "Quitar"
        Me.ButtonAdv2.UseVisualStyle = True
        '
        'btOperacion
        '
        Me.btOperacion.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btOperacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.btOperacion.BeforeTouchSize = New System.Drawing.Size(51, 26)
        Me.btOperacion.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btOperacion.ForeColor = System.Drawing.Color.White
        Me.btOperacion.IsBackStageButton = False
        Me.btOperacion.Location = New System.Drawing.Point(351, 66)
        Me.btOperacion.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btOperacion.Name = "btOperacion"
        Me.btOperacion.Size = New System.Drawing.Size(51, 26)
        Me.btOperacion.TabIndex = 523
        Me.btOperacion.Text = "Agregar"
        Me.btOperacion.UseVisualStyle = True
        '
        'cboCajas
        '
        Me.cboCajas.BackColor = System.Drawing.Color.White
        Me.cboCajas.BeforeTouchSize = New System.Drawing.Size(312, 21)
        Me.cboCajas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCajas.Enabled = False
        Me.cboCajas.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCajas.Location = New System.Drawing.Point(33, 71)
        Me.cboCajas.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboCajas.Name = "cboCajas"
        Me.cboCajas.Size = New System.Drawing.Size(312, 21)
        Me.cboCajas.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboCajas.TabIndex = 522
        '
        'gradientPanel2
        '
        Me.gradientPanel2.BackgroundColor = New Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.PatternStyle.Weave, System.Drawing.Color.White, System.Drawing.Color.White)
        Me.gradientPanel2.BorderColor = System.Drawing.Color.Silver
        Me.gradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.gradientPanel2.Controls.Add(Me.dgvCuentas)
        Me.gradientPanel2.Location = New System.Drawing.Point(33, 100)
        Me.gradientPanel2.Name = "gradientPanel2"
        Me.gradientPanel2.Size = New System.Drawing.Size(426, 242)
        Me.gradientPanel2.TabIndex = 521
        '
        'dgvCuentas
        '
        Me.dgvCuentas.Appearance.AlternateRecordFieldCell.Font.Size = 8.0!
        Me.dgvCuentas.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        Me.dgvCuentas.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.dgvCuentas.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dgvCuentas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvCuentas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCuentas.FreezeCaption = False
        Me.dgvCuentas.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgvCuentas.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2007Silver
        Me.dgvCuentas.Location = New System.Drawing.Point(0, 0)
        Me.dgvCuentas.Name = "dgvCuentas"
        Me.dgvCuentas.Size = New System.Drawing.Size(424, 240)
        Me.dgvCuentas.TabIndex = 426
        Me.dgvCuentas.TableDescriptor.AllowNew = False
        Me.dgvCuentas.TableDescriptor.Appearance.AnyCell.Font.Facename = "Segoe UI"
        Me.dgvCuentas.TableDescriptor.Appearance.AnyCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.dgvCuentas.TableDescriptor.Appearance.AnyGroupCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCuentas.TableDescriptor.Appearance.AnyGroupCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCuentas.TableDescriptor.Appearance.AnyGroupCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer)))
        Me.dgvCuentas.TableDescriptor.Appearance.AnyHeaderCell.Font.Size = 8.0!
        Me.dgvCuentas.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCuentas.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCuentas.TableDescriptor.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        Me.dgvCuentas.TableDescriptor.Appearance.AnySummaryCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCuentas.TableDescriptor.Appearance.AnySummaryCell.Borders.Top = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCuentas.TableDescriptor.Appearance.AnySummaryCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)))
        Me.dgvCuentas.TableDescriptor.Appearance.ColumnHeaderCell.Font.Bold = True
        Me.dgvCuentas.TableDescriptor.Appearance.ColumnHeaderCell.Font.Italic = False
        Me.dgvCuentas.TableDescriptor.Appearance.ColumnHeaderCell.Font.Size = 8.0!
        Me.dgvCuentas.TableDescriptor.Appearance.GroupCaptionCell.CellType = """ColumnHeader"""
        GridColumnDescriptor11.HeaderImage = Nothing
        GridColumnDescriptor11.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor11.MappingName = "tipo"
        GridColumnDescriptor11.ReadOnly = True
        GridColumnDescriptor11.SerializedImageArray = ""
        GridColumnDescriptor12.HeaderImage = Nothing
        GridColumnDescriptor12.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor12.MappingName = "identidad"
        GridColumnDescriptor12.ReadOnly = True
        GridColumnDescriptor12.SerializedImageArray = ""
        GridColumnDescriptor12.Width = 19
        GridColumnDescriptor13.HeaderImage = Nothing
        GridColumnDescriptor13.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor13.MappingName = "entidad"
        GridColumnDescriptor13.ReadOnly = True
        GridColumnDescriptor13.SerializedImageArray = ""
        GridColumnDescriptor13.Width = 224
        GridColumnDescriptor14.Appearance.AnyRecordFieldCell.CellType = "Currency"
        GridColumnDescriptor14.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
        GridColumnDescriptor14.HeaderImage = Nothing
        GridColumnDescriptor14.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor14.MappingName = "abonado"
        GridColumnDescriptor14.SerializedImageArray = ""
        GridColumnDescriptor14.Width = 92
        GridColumnDescriptor15.HeaderImage = Nothing
        GridColumnDescriptor15.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor15.MappingName = "tipocambio"
        GridColumnDescriptor15.ReadOnly = True
        GridColumnDescriptor15.SerializedImageArray = ""
        GridColumnDescriptor15.Width = 92
        Me.dgvCuentas.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor11, GridColumnDescriptor12, GridColumnDescriptor13, GridColumnDescriptor14, GridColumnDescriptor15})
        GridSummaryRowDescriptor3.Appearance.AnySummaryCell.CellType = "TextBox"
        GridSummaryRowDescriptor3.Appearance.AnySummaryCell.CurrencyEdit.CurrencySymbol = ""
        GridSummaryRowDescriptor3.Name = "Row 1"
        GridSummaryColumnDescriptor3.Appearance.AnySummaryCell.CellType = "Currency"
        GridSummaryColumnDescriptor3.DataMember = "abonado"
        GridSummaryColumnDescriptor3.Format = "{Sum}"
        GridSummaryColumnDescriptor3.Name = "abonado"
        GridSummaryColumnDescriptor3.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        GridSummaryRowDescriptor3.SummaryColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor() {GridSummaryColumnDescriptor3})
        GridSummaryRowDescriptor3.Title = "Total pagos: "
        Me.dgvCuentas.TableDescriptor.SummaryRows.Add(GridSummaryRowDescriptor3)
        Me.dgvCuentas.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.dgvCuentas.TableDescriptor.TableOptions.RecordRowHeight = 20
        Me.dgvCuentas.TableDescriptor.TopLevelGroupOptions.ShowCaption = False
        Me.dgvCuentas.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipo"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("identidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("entidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("abonado"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipocambio")})
        Me.dgvCuentas.Text = "GridGroupingControl2"
        Me.dgvCuentas.VersionInfo = "12.4400.0.24"
        '
        'txtMontoXcobrar
        '
        Me.txtMontoXcobrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.txtMontoXcobrar.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtMontoXcobrar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.txtMontoXcobrar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMontoXcobrar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMontoXcobrar.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMontoXcobrar.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoXcobrar.ForeColor = System.Drawing.Color.White
        Me.txtMontoXcobrar.Location = New System.Drawing.Point(351, 40)
        Me.txtMontoXcobrar.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtMontoXcobrar.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtMontoXcobrar.Name = "txtMontoXcobrar"
        Me.txtMontoXcobrar.ReadOnly = True
        Me.txtMontoXcobrar.Size = New System.Drawing.Size(104, 20)
        Me.txtMontoXcobrar.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtMontoXcobrar.TabIndex = 520
        Me.txtMontoXcobrar.Text = "0.00"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(348, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 14)
        Me.Label3.TabIndex = 519
        Me.Label3.Text = "Importe por cobrar"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(141, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 14)
        Me.Label2.TabIndex = 518
        Me.Label2.Text = "Banco"
        '
        'ChBanco
        '
        Me.ChBanco.BackColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.ChBanco.ChechedOffColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.ChBanco.Checked = False
        Me.ChBanco.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.ChBanco.ForeColor = System.Drawing.Color.White
        Me.ChBanco.Location = New System.Drawing.Point(118, 43)
        Me.ChBanco.Name = "ChBanco"
        Me.ChBanco.Size = New System.Drawing.Size(20, 20)
        Me.ChBanco.TabIndex = 517
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(56, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 14)
        Me.Label5.TabIndex = 516
        Me.Label5.Text = "Efectivo"
        '
        'ChEfectivo
        '
        Me.ChEfectivo.BackColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.ChEfectivo.ChechedOffColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.ChEfectivo.Checked = False
        Me.ChEfectivo.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.ChEfectivo.ForeColor = System.Drawing.Color.White
        Me.ChEfectivo.Location = New System.Drawing.Point(33, 43)
        Me.ChEfectivo.Name = "ChEfectivo"
        Me.ChEfectivo.Size = New System.Drawing.Size(20, 20)
        Me.ChEfectivo.TabIndex = 515
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(31, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 14)
        Me.Label1.TabIndex = 514
        Me.Label1.Text = "Forma de pago"
        '
        'GradientPanel3
        '
        Me.GradientPanel3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(221, Byte), Integer))
        Me.GradientPanel3.BorderSingle = System.Windows.Forms.ButtonBorderStyle.Dotted
        Me.GradientPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel3.Controls.Add(Me.ListView1)
        Me.GradientPanel3.Location = New System.Drawing.Point(465, 40)
        Me.GradientPanel3.Name = "GradientPanel3"
        Me.GradientPanel3.Size = New System.Drawing.Size(417, 301)
        Me.GradientPanel3.TabIndex = 525
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader1, Me.ColumnHeader4, Me.ColumnHeader5})
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.Location = New System.Drawing.Point(0, 0)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(415, 299)
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "IdEntidad"
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Entidad"
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "iditem"
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Producto"
        Me.ColumnHeader4.Width = 140
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Pago abonado"
        Me.ColumnHeader5.Width = 88
        '
        'frmVentaPagoNuevo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderThickness = 0
        Me.CaptionBarHeight = 55
        Me.ClientSize = New System.Drawing.Size(894, 346)
        Me.Controls.Add(Me.GradientPanel3)
        Me.Controls.Add(Me.ButtonAdv2)
        Me.Controls.Add(Me.btOperacion)
        Me.Controls.Add(Me.cboCajas)
        Me.Controls.Add(Me.gradientPanel2)
        Me.Controls.Add(Me.txtMontoXcobrar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ChBanco)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ChEfectivo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmVentaPagoNuevo"
        Me.ShowIcon = False
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCajas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gradientPanel2.ResumeLayout(False)
        CType(Me.dgvCuentas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMontoXcobrar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents GradientPanel1 As Tools.GradientPanel
    Friend WithEvents ButtonAdv2 As ButtonAdv
    Friend WithEvents btOperacion As ButtonAdv
    Friend WithEvents cboCajas As Tools.ComboBoxAdv
    Private WithEvents gradientPanel2 As Tools.GradientPanel
    Friend WithEvents dgvCuentas As Grid.Grouping.GridGroupingControl
    Friend WithEvents txtMontoXcobrar As Tools.TextBoxExt
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ChBanco As Bunifu.Framework.UI.BunifuCheckbox
    Friend WithEvents Label5 As Label
    Friend WithEvents ChEfectivo As Bunifu.Framework.UI.BunifuCheckbox
    Friend WithEvents Label1 As Label
    Friend WithEvents GradientPanel3 As Tools.GradientPanel
    Friend WithEvents ListView1 As ListView
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
End Class

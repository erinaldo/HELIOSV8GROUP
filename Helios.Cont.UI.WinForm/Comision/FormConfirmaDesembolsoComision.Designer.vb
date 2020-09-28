Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormConfirmaDesembolsoComision
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
        Dim GridColumnDescriptor10 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor11 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor12 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor13 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor14 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor15 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor16 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor17 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor18 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridSummaryRowDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor()
        Dim GridSummaryColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor()
        Dim GridSummaryColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormConfirmaDesembolsoComision))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgvCuentas = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.bunifuFlatButton6 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.ComboCaja = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.txtTotalPagar = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DateConsulta = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.BtActivar = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextProveedor = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvCuentas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalPagar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateConsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dgvCuentas)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 133)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(861, 247)
        Me.Panel1.TabIndex = 0
        '
        'dgvCuentas
        '
        Me.dgvCuentas.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.dgvCuentas.Appearance.AlternateRecordFieldCell.Font.Size = 8.0!
        Me.dgvCuentas.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        Me.dgvCuentas.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.dgvCuentas.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dgvCuentas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvCuentas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCuentas.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvCuentas.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgvCuentas.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2007Blue
        Me.dgvCuentas.Location = New System.Drawing.Point(0, 0)
        Me.dgvCuentas.Name = "dgvCuentas"
        Me.dgvCuentas.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.dgvCuentas.Size = New System.Drawing.Size(861, 247)
        Me.dgvCuentas.TabIndex = 427
        Me.dgvCuentas.TableDescriptor.AllowNew = False
        Me.dgvCuentas.TableDescriptor.Appearance.AnyCell.Font.Facename = "Segoe UI"
        Me.dgvCuentas.TableDescriptor.Appearance.AnyCell.Font.Size = 12.0!
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
        GridColumnDescriptor10.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.LavenderBlush)
        GridColumnDescriptor10.Appearance.AnyRecordFieldCell.Text = ""
        GridColumnDescriptor10.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        GridColumnDescriptor10.MappingName = "tipo"
        GridColumnDescriptor10.ReadOnly = True
        GridColumnDescriptor11.MappingName = "identidad"
        GridColumnDescriptor11.ReadOnly = True
        GridColumnDescriptor11.Width = 19
        GridColumnDescriptor12.Appearance.AnyRecordFieldCell.Error = "Object reference not set to an instance of an object."
        GridColumnDescriptor12.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor12.HeaderText = "Cuenta"
        GridColumnDescriptor12.MappingName = "entidad"
        GridColumnDescriptor12.ReadOnly = True
        GridColumnDescriptor12.Width = 190
        GridColumnDescriptor13.Appearance.AnyRecordFieldCell.CellType = "Currency"
        GridColumnDescriptor13.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
        GridColumnDescriptor13.Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = System.Drawing.SystemColors.HotTrack
        GridColumnDescriptor13.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
        GridColumnDescriptor13.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        GridColumnDescriptor13.Appearance.AnyRecordFieldCell.TextAlign = Syncfusion.Windows.Forms.Grid.GridTextAlign.Right
        GridColumnDescriptor13.HeaderText = "Abono"
        GridColumnDescriptor13.MappingName = "abonado"
        GridColumnDescriptor13.Width = 150
        GridColumnDescriptor14.Appearance.AnyRecordFieldCell.CellType = "Currency"
        GridColumnDescriptor14.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencyDecimalDigits = 3
        GridColumnDescriptor14.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
        GridColumnDescriptor14.HeaderText = "T/C"
        GridColumnDescriptor14.MappingName = "tipocambio"
        GridColumnDescriptor14.Width = 60
        GridColumnDescriptor15.MappingName = "idforma"
        GridColumnDescriptor15.Width = 20
        GridColumnDescriptor16.Appearance.AnyRecordFieldCell.Error = "Object reference not set to an instance of an object."
        GridColumnDescriptor16.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor16.HeaderText = "Forma de Pago"
        GridColumnDescriptor16.MappingName = "formaPago"
        GridColumnDescriptor16.ReadOnly = True
        GridColumnDescriptor16.Width = 190
        GridColumnDescriptor17.HeaderText = "N°Op"
        GridColumnDescriptor17.MappingName = "nrooperacion"
        GridColumnDescriptor17.Width = 70
        GridColumnDescriptor18.Appearance.AnyRecordFieldCell.CellType = "Currency"
        GridColumnDescriptor18.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = "$ "
        GridColumnDescriptor18.Appearance.AnyRecordFieldCell.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        GridColumnDescriptor18.HeaderText = "Abono ME."
        GridColumnDescriptor18.MappingName = "abonadoME"
        GridColumnDescriptor18.Width = 100
        Me.dgvCuentas.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor10, GridColumnDescriptor11, GridColumnDescriptor12, GridColumnDescriptor13, GridColumnDescriptor14, GridColumnDescriptor15, GridColumnDescriptor16, GridColumnDescriptor17, New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor("moneda"), GridColumnDescriptor18})
        GridSummaryRowDescriptor2.Appearance.AnySummaryCell.CellType = "TextBox"
        GridSummaryRowDescriptor2.Appearance.AnySummaryCell.CurrencyEdit.CurrencySymbol = ""
        GridSummaryRowDescriptor2.Appearance.AnySummaryCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
        GridSummaryRowDescriptor2.Appearance.AnySummaryCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.GradientInactiveCaption)
        GridSummaryRowDescriptor2.Appearance.AnySummaryCell.TextColor = System.Drawing.Color.Black
        GridSummaryRowDescriptor2.Name = "Row 1"
        GridSummaryColumnDescriptor3.Appearance.AnySummaryCell.CellType = "Currency"
        GridSummaryColumnDescriptor3.Appearance.AnySummaryCell.Font.Bold = True
        GridSummaryColumnDescriptor3.Appearance.AnySummaryCell.Font.Size = 12.0!
        GridSummaryColumnDescriptor3.Appearance.AnySummaryCell.TextColor = System.Drawing.Color.Black
        GridSummaryColumnDescriptor3.DataMember = "abonado"
        GridSummaryColumnDescriptor3.Format = "{Sum}"
        GridSummaryColumnDescriptor3.Name = "abonado"
        GridSummaryColumnDescriptor3.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        GridSummaryColumnDescriptor4.Appearance.AnySummaryCell.CellType = "Currency"
        GridSummaryColumnDescriptor4.Appearance.AnySummaryCell.Font.Bold = True
        GridSummaryColumnDescriptor4.DataMember = "abonadoME"
        GridSummaryColumnDescriptor4.Format = "{Sum}"
        GridSummaryColumnDescriptor4.Name = "abonadoME"
        GridSummaryColumnDescriptor4.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        GridSummaryRowDescriptor2.SummaryColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor() {GridSummaryColumnDescriptor3, GridSummaryColumnDescriptor4})
        GridSummaryRowDescriptor2.Title = "Total pagos: "
        Me.dgvCuentas.TableDescriptor.SummaryRows.Add(GridSummaryRowDescriptor2)
        Me.dgvCuentas.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 22
        Me.dgvCuentas.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.dgvCuentas.TableDescriptor.TopLevelGroupOptions.ShowCaption = False
        Me.dgvCuentas.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("formaPago"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("entidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipocambio"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("abonado"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("abonadoME"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("nrooperacion"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("moneda")})
        Me.dgvCuentas.Text = "GridGroupingControl2"
        Me.dgvCuentas.UseRightToLeftCompatibleTextBox = True
        Me.dgvCuentas.VersionInfo = "12.4400.0.24"
        '
        'bunifuFlatButton6
        '
        Me.bunifuFlatButton6.Activecolor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.bunifuFlatButton6.BackColor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.bunifuFlatButton6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bunifuFlatButton6.BorderRadius = 5
        Me.bunifuFlatButton6.ButtonText = "CONSULTAR"
        Me.bunifuFlatButton6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bunifuFlatButton6.DisabledColor = System.Drawing.Color.Gray
        Me.bunifuFlatButton6.Font = New System.Drawing.Font("Tahoma", 7.0!)
        Me.bunifuFlatButton6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.bunifuFlatButton6.Iconcolor = System.Drawing.Color.Transparent
        Me.bunifuFlatButton6.Iconimage = CType(resources.GetObject("bunifuFlatButton6.Iconimage"), System.Drawing.Image)
        Me.bunifuFlatButton6.Iconimage_right = Nothing
        Me.bunifuFlatButton6.Iconimage_right_Selected = Nothing
        Me.bunifuFlatButton6.Iconimage_Selected = Nothing
        Me.bunifuFlatButton6.IconMarginLeft = 0
        Me.bunifuFlatButton6.IconMarginRight = 0
        Me.bunifuFlatButton6.IconRightVisible = True
        Me.bunifuFlatButton6.IconRightZoom = 0R
        Me.bunifuFlatButton6.IconVisible = True
        Me.bunifuFlatButton6.IconZoom = 40.0R
        Me.bunifuFlatButton6.IsTab = False
        Me.bunifuFlatButton6.Location = New System.Drawing.Point(239, 37)
        Me.bunifuFlatButton6.Margin = New System.Windows.Forms.Padding(2)
        Me.bunifuFlatButton6.Name = "bunifuFlatButton6"
        Me.bunifuFlatButton6.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.bunifuFlatButton6.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(72, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.bunifuFlatButton6.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.bunifuFlatButton6.selected = False
        Me.bunifuFlatButton6.Size = New System.Drawing.Size(90, 23)
        Me.bunifuFlatButton6.TabIndex = 668
        Me.bunifuFlatButton6.Text = "CONSULTAR"
        Me.bunifuFlatButton6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.bunifuFlatButton6.Textcolor = System.Drawing.Color.White
        Me.bunifuFlatButton6.TextFont = New System.Drawing.Font("Quicksand Medium", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(24, 17)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(71, 13)
        Me.Label24.TabIndex = 670
        Me.Label24.Text = "Cajas activas"
        '
        'ComboCaja
        '
        Me.ComboCaja.BackColor = System.Drawing.Color.White
        Me.ComboCaja.BeforeTouchSize = New System.Drawing.Size(207, 21)
        Me.ComboCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboCaja.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboCaja.Location = New System.Drawing.Point(27, 38)
        Me.ComboCaja.MetroBorderColor = System.Drawing.Color.Silver
        Me.ComboCaja.Name = "ComboCaja"
        Me.ComboCaja.Size = New System.Drawing.Size(207, 21)
        Me.ComboCaja.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboCaja.TabIndex = 669
        '
        'txtTotalPagar
        '
        Me.txtTotalPagar.BackGroundColor = System.Drawing.Color.Gainsboro
        Me.txtTotalPagar.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtTotalPagar.BorderColor = System.Drawing.Color.Gray
        Me.txtTotalPagar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalPagar.CornerRadius = 5
        Me.txtTotalPagar.CurrencySymbol = ""
        Me.txtTotalPagar.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtTotalPagar.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalPagar.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPagar.ForeColor = System.Drawing.Color.Black
        Me.txtTotalPagar.Location = New System.Drawing.Point(650, 38)
        Me.txtTotalPagar.Metrocolor = System.Drawing.Color.Gray
        Me.txtTotalPagar.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtTotalPagar.Name = "txtTotalPagar"
        Me.txtTotalPagar.NullString = ""
        Me.txtTotalPagar.PositiveColor = System.Drawing.Color.Black
        Me.txtTotalPagar.ReadOnly = True
        Me.txtTotalPagar.ReadOnlyBackColor = System.Drawing.Color.White
        Me.txtTotalPagar.Size = New System.Drawing.Size(121, 22)
        Me.txtTotalPagar.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtTotalPagar.TabIndex = 672
        Me.txtTotalPagar.Text = "0.00"
        Me.txtTotalPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(647, 17)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(73, 13)
        Me.Label22.TabIndex = 671
        Me.Label22.Text = "Total x pagar"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(24, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 13)
        Me.Label2.TabIndex = 675
        Me.Label2.Text = "Fecha desembolso"
        '
        'DateConsulta
        '
        Me.DateConsulta.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.DateConsulta.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.DateConsulta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DateConsulta.CalendarForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.DateConsulta.CalendarMonthBackground = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.DateConsulta.CalendarSize = New System.Drawing.Size(189, 176)
        Me.DateConsulta.CalendarTitleBackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.DateConsulta.CalendarTitleForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DateConsulta.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DateConsulta.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.DateConsulta.CustomFormat = "MM/yyyy"
        Me.DateConsulta.DropDownImage = Nothing
        Me.DateConsulta.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DateConsulta.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DateConsulta.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.DateConsulta.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateConsulta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateConsulta.Location = New System.Drawing.Point(27, 94)
        Me.DateConsulta.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DateConsulta.MinValue = New Date(CType(0, Long))
        Me.DateConsulta.Name = "DateConsulta"
        Me.DateConsulta.ShowCheckBox = False
        Me.DateConsulta.Size = New System.Drawing.Size(107, 20)
        Me.DateConsulta.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.DateConsulta.TabIndex = 676
        Me.DateConsulta.Value = New Date(2020, 1, 2, 13, 55, 13, 331)
        '
        'BtActivar
        '
        Me.BtActivar.Activecolor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.BtActivar.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.BtActivar.BackgroundImage = CType(resources.GetObject("BtActivar.BackgroundImage"), System.Drawing.Image)
        Me.BtActivar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtActivar.BorderRadius = 5
        Me.BtActivar.ButtonText = "DESEMBOLSAR"
        Me.BtActivar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtActivar.DisabledColor = System.Drawing.Color.Gray
        Me.BtActivar.Font = New System.Drawing.Font("Tahoma", 7.0!)
        Me.BtActivar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BtActivar.Iconcolor = System.Drawing.Color.Transparent
        Me.BtActivar.Iconimage = CType(resources.GetObject("BtActivar.Iconimage"), System.Drawing.Image)
        Me.BtActivar.Iconimage_right = Nothing
        Me.BtActivar.Iconimage_right_Selected = Nothing
        Me.BtActivar.Iconimage_Selected = Nothing
        Me.BtActivar.IconMarginLeft = 0
        Me.BtActivar.IconMarginRight = 0
        Me.BtActivar.IconRightVisible = True
        Me.BtActivar.IconRightZoom = 0R
        Me.BtActivar.IconVisible = True
        Me.BtActivar.IconZoom = 40.0R
        Me.BtActivar.IsTab = False
        Me.BtActivar.Location = New System.Drawing.Point(140, 92)
        Me.BtActivar.Margin = New System.Windows.Forms.Padding(2)
        Me.BtActivar.Name = "BtActivar"
        Me.BtActivar.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.BtActivar.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.BtActivar.OnHoverTextColor = System.Drawing.Color.White
        Me.BtActivar.selected = False
        Me.BtActivar.Size = New System.Drawing.Size(114, 23)
        Me.BtActivar.TabIndex = 677
        Me.BtActivar.Text = "DESEMBOLSAR"
        Me.BtActivar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BtActivar.Textcolor = System.Drawing.Color.Black
        Me.BtActivar.TextFont = New System.Drawing.Font("Quicksand Medium", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtActivar.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(331, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(111, 13)
        Me.Label3.TabIndex = 678
        Me.Label3.Text = "Usuario beneficiario"
        '
        'TextProveedor
        '
        Me.TextProveedor.BackColor = System.Drawing.Color.White
        Me.TextProveedor.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TextProveedor.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextProveedor.CornerRadius = 3
        Me.TextProveedor.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextProveedor.Enabled = False
        Me.TextProveedor.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextProveedor.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextProveedor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextProveedor.Location = New System.Drawing.Point(334, 38)
        Me.TextProveedor.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextProveedor.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextProveedor.Name = "TextProveedor"
        Me.TextProveedor.Size = New System.Drawing.Size(310, 22)
        Me.TextProveedor.TabIndex = 687
        '
        'FormConfirmaDesembolsoComision
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(861, 380)
        Me.Controls.Add(Me.TextProveedor)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BtActivar)
        Me.Controls.Add(Me.DateConsulta)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtTotalPagar)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.ComboCaja)
        Me.Controls.Add(Me.bunifuFlatButton6)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FormConfirmaDesembolsoComision"
        Me.ShowIcon = False
        Me.Text = "Confirmar pago"
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvCuentas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboCaja, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalPagar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateConsulta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents dgvCuentas As Grid.Grouping.GridGroupingControl
    Private WithEvents bunifuFlatButton6 As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents Label24 As Label
    Friend WithEvents ComboCaja As Tools.ComboBoxAdv
    Friend WithEvents txtTotalPagar As Tools.CurrencyTextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents DateConsulta As Tools.DateTimePickerAdv
    Private WithEvents BtActivar As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents Label3 As Label
    Friend WithEvents TextProveedor As Tools.TextBoxExt
End Class

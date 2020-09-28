Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormViewResumenLiquidacion
    Inherits MetroForm

    'Form overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Dim GridColumnDescriptor13 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor14 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor15 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor16 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor17 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor18 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridSummaryRowDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor()
        Dim GridSummaryColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormViewResumenLiquidacion))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GradientPanel8 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.dgvCuentas = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtTotalDescuento = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtTotalVEntas = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.RoundButton21 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.txtTotalAPagar = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtTotal = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtAcuenta = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtCotizacion = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtDescuento = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtHora = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtFecha = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtdestino = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextSeriePlaca = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextCodigoPlaca = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextRuta = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        CType(Me.GradientPanel8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel8.SuspendLayout()
        CType(Me.dgvCuentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.txtTotalDescuento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalVEntas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalAPagar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAcuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCotizacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescuento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtdestino, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextSeriePlaca, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextCodigoPlaca, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextRuta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        Me.Label1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(365, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Liquidación: Resumen de venta de pasajes"
        '
        'GradientPanel8
        '
        Me.GradientPanel8.BorderColor = System.Drawing.SystemColors.Highlight
        Me.GradientPanel8.BorderSingle = System.Windows.Forms.ButtonBorderStyle.Dotted
        Me.GradientPanel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel8.Controls.Add(Me.dgvCuentas)
        Me.GradientPanel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel8.Location = New System.Drawing.Point(555, 46)
        Me.GradientPanel8.Name = "GradientPanel8"
        Me.GradientPanel8.Size = New System.Drawing.Size(558, 507)
        Me.GradientPanel8.TabIndex = 593
        '
        'dgvCuentas
        '
        Me.dgvCuentas.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.dgvCuentas.Appearance.AlternateRecordFieldCell.Font.Size = 8.0!
        Me.dgvCuentas.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        Me.dgvCuentas.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.dgvCuentas.BackColor = System.Drawing.Color.White
        Me.dgvCuentas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvCuentas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCuentas.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvCuentas.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgvCuentas.Location = New System.Drawing.Point(0, 0)
        Me.dgvCuentas.Name = "dgvCuentas"
        Me.dgvCuentas.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.dgvCuentas.Size = New System.Drawing.Size(556, 505)
        Me.dgvCuentas.TabIndex = 540
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
        GridColumnDescriptor13.MappingName = "id"
        GridColumnDescriptor13.Width = 43
        GridColumnDescriptor14.HeaderText = "Asiento"
        GridColumnDescriptor14.MappingName = "asiento"
        GridColumnDescriptor14.Width = 96
        GridColumnDescriptor15.HeaderText = "Fecha venta"
        GridColumnDescriptor15.MappingName = "fechaventa"
        GridColumnDescriptor15.Width = 134
        GridColumnDescriptor16.HeaderText = "Tipo doc."
        GridColumnDescriptor16.MappingName = "tipodoc"
        GridColumnDescriptor16.Width = 70
        GridColumnDescriptor17.HeaderText = "Número venta"
        GridColumnDescriptor17.MappingName = "numero"
        GridColumnDescriptor17.Width = 115
        GridColumnDescriptor18.HeaderText = "Importe"
        GridColumnDescriptor18.MappingName = "importe"
        GridColumnDescriptor18.Width = 115
        Me.dgvCuentas.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor13, GridColumnDescriptor14, GridColumnDescriptor15, GridColumnDescriptor16, GridColumnDescriptor17, GridColumnDescriptor18})
        GridSummaryRowDescriptor3.Appearance.AnySummaryCell.CellType = "TextBox"
        GridSummaryRowDescriptor3.Appearance.AnySummaryCell.CurrencyEdit.CurrencySymbol = ""
        GridSummaryRowDescriptor3.Appearance.AnySummaryCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
        GridSummaryRowDescriptor3.Appearance.AnySummaryCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.GradientInactiveCaption)
        GridSummaryRowDescriptor3.Appearance.AnySummaryCell.TextColor = System.Drawing.Color.Black
        GridSummaryRowDescriptor3.Name = "Row 1"
        GridSummaryColumnDescriptor3.Appearance.AnySummaryCell.CellType = "Currency"
        GridSummaryColumnDescriptor3.Appearance.AnySummaryCell.Font.Bold = True
        GridSummaryColumnDescriptor3.Appearance.AnySummaryCell.Font.Size = 12.0!
        GridSummaryColumnDescriptor3.Appearance.AnySummaryCell.TextColor = System.Drawing.Color.Black
        GridSummaryColumnDescriptor3.DataMember = "importe"
        GridSummaryColumnDescriptor3.Format = "{Sum}"
        GridSummaryColumnDescriptor3.Name = "abonado"
        GridSummaryColumnDescriptor3.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        GridSummaryRowDescriptor3.SummaryColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor() {GridSummaryColumnDescriptor3})
        GridSummaryRowDescriptor3.Title = "Total pagos: "
        Me.dgvCuentas.TableDescriptor.SummaryRows.Add(GridSummaryRowDescriptor3)
        Me.dgvCuentas.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.dgvCuentas.TableDescriptor.TableOptions.RecordRowHeight = 20
        Me.dgvCuentas.TableDescriptor.TopLevelGroupOptions.ShowCaption = False
        Me.dgvCuentas.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("asiento"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("fechaventa"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipodoc"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("numero"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("importe")})
        Me.dgvCuentas.Text = "GridGroupingControl2"
        Me.dgvCuentas.UseRightToLeftCompatibleTextBox = True
        Me.dgvCuentas.VersionInfo = "12.4400.0.24"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1113, 46)
        Me.Panel1.TabIndex = 595
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label15)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Controls.Add(Me.txtTotalDescuento)
        Me.Panel2.Controls.Add(Me.txtTotalVEntas)
        Me.Panel2.Controls.Add(Me.RoundButton21)
        Me.Panel2.Controls.Add(Me.txtTotalAPagar)
        Me.Panel2.Controls.Add(Me.txtTotal)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.txtAcuenta)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.txtCotizacion)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.txtDescuento)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.txtHora)
        Me.Panel2.Controls.Add(Me.txtFecha)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.txtdestino)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.TextSeriePlaca)
        Me.Panel2.Controls.Add(Me.TextCodigoPlaca)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.TextRuta)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 46)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(555, 507)
        Me.Panel2.TabIndex = 596
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Maroon
        Me.Label15.Location = New System.Drawing.Point(290, 469)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(20, 29)
        Me.Label15.TabIndex = 718
        Me.Label15.Text = "%"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label15.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Maroon
        Me.Label14.Location = New System.Drawing.Point(110, 550)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(94, 18)
        Me.Label14.TabIndex = 717
        Me.Label14.Text = "SUB TOTAL"
        Me.Label14.Visible = False
        '
        'txtTotalDescuento
        '
        Me.txtTotalDescuento.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtTotalDescuento.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtTotalDescuento.BorderColor = System.Drawing.Color.Silver
        Me.txtTotalDescuento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalDescuento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalDescuento.CornerRadius = 4
        Me.txtTotalDescuento.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtTotalDescuento.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
        Me.txtTotalDescuento.ForeColor = System.Drawing.Color.Black
        Me.txtTotalDescuento.Location = New System.Drawing.Point(314, 469)
        Me.txtTotalDescuento.Metrocolor = System.Drawing.Color.Silver
        Me.txtTotalDescuento.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtTotalDescuento.Name = "txtTotalDescuento"
        Me.txtTotalDescuento.ReadOnly = True
        Me.txtTotalDescuento.Size = New System.Drawing.Size(204, 29)
        Me.txtTotalDescuento.TabIndex = 716
        Me.txtTotalDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtTotalDescuento.Visible = False
        '
        'txtTotalVEntas
        '
        Me.txtTotalVEntas.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtTotalVEntas.BeforeTouchSize = New System.Drawing.Size(204, 29)
        Me.txtTotalVEntas.BorderColor = System.Drawing.SystemColors.HotTrack
        Me.txtTotalVEntas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalVEntas.DecimalPlaces = 2
        Me.txtTotalVEntas.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
        Me.txtTotalVEntas.ForeColor = System.Drawing.Color.Black
        Me.txtTotalVEntas.InterceptArrowKeys = False
        Me.txtTotalVEntas.Location = New System.Drawing.Point(314, 197)
        Me.txtTotalVEntas.Maximum = New Decimal(New Integer() {-159383552, 46653770, 5421, 0})
        Me.txtTotalVEntas.MetroColor = System.Drawing.SystemColors.HotTrack
        Me.txtTotalVEntas.Name = "txtTotalVEntas"
        Me.txtTotalVEntas.ReadOnly = True
        Me.txtTotalVEntas.Size = New System.Drawing.Size(204, 29)
        Me.txtTotalVEntas.TabIndex = 715
        Me.txtTotalVEntas.TabStop = False
        Me.txtTotalVEntas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtTotalVEntas.ThousandsSeparator = True
        Me.txtTotalVEntas.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'RoundButton21
        '
        Me.RoundButton21.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton21.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.RoundButton21.BeforeTouchSize = New System.Drawing.Size(208, 32)
        Me.RoundButton21.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
        Me.RoundButton21.ForeColor = System.Drawing.Color.White
        Me.RoundButton21.IsBackStageButton = False
        Me.RoundButton21.Location = New System.Drawing.Point(314, 291)
        Me.RoundButton21.Name = "RoundButton21"
        Me.RoundButton21.Size = New System.Drawing.Size(208, 32)
        Me.RoundButton21.TabIndex = 594
        Me.RoundButton21.Text = "Imprimir"
        Me.RoundButton21.UseVisualStyle = True
        '
        'txtTotalAPagar
        '
        Me.txtTotalAPagar.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtTotalAPagar.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtTotalAPagar.BorderColor = System.Drawing.Color.Silver
        Me.txtTotalAPagar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalAPagar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalAPagar.CornerRadius = 4
        Me.txtTotalAPagar.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtTotalAPagar.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
        Me.txtTotalAPagar.ForeColor = System.Drawing.Color.Black
        Me.txtTotalAPagar.Location = New System.Drawing.Point(314, 243)
        Me.txtTotalAPagar.Metrocolor = System.Drawing.Color.Silver
        Me.txtTotalAPagar.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtTotalAPagar.Name = "txtTotalAPagar"
        Me.txtTotalAPagar.ReadOnly = True
        Me.txtTotalAPagar.Size = New System.Drawing.Size(204, 29)
        Me.txtTotalAPagar.TabIndex = 714
        Me.txtTotalAPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtTotal.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtTotal.BorderColor = System.Drawing.Color.Silver
        Me.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotal.CornerRadius = 4
        Me.txtTotal.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtTotal.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
        Me.txtTotal.ForeColor = System.Drawing.Color.Black
        Me.txtTotal.Location = New System.Drawing.Point(314, 539)
        Me.txtTotal.Metrocolor = System.Drawing.Color.Silver
        Me.txtTotal.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(204, 29)
        Me.txtTotal.TabIndex = 713
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtTotal.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Maroon
        Me.Label12.Location = New System.Drawing.Point(70, 254)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(128, 18)
        Me.Label12.TabIndex = 710
        Me.Label12.Text = "TOTAL A PAGAR"
        '
        'txtAcuenta
        '
        Me.txtAcuenta.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtAcuenta.BeforeTouchSize = New System.Drawing.Size(204, 29)
        Me.txtAcuenta.BorderColor = System.Drawing.SystemColors.HotTrack
        Me.txtAcuenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAcuenta.DecimalPlaces = 2
        Me.txtAcuenta.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
        Me.txtAcuenta.ForeColor = System.Drawing.Color.Black
        Me.txtAcuenta.Location = New System.Drawing.Point(314, 574)
        Me.txtAcuenta.Maximum = New Decimal(New Integer() {-159383552, 46653770, 5421, 0})
        Me.txtAcuenta.MetroColor = System.Drawing.SystemColors.HotTrack
        Me.txtAcuenta.Name = "txtAcuenta"
        Me.txtAcuenta.Size = New System.Drawing.Size(204, 29)
        Me.txtAcuenta.TabIndex = 709
        Me.txtAcuenta.TabStop = False
        Me.txtAcuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtAcuenta.ThousandsSeparator = True
        Me.txtAcuenta.Visible = False
        Me.txtAcuenta.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Maroon
        Me.Label13.Location = New System.Drawing.Point(121, 585)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(83, 18)
        Me.Label13.TabIndex = 708
        Me.Label13.Text = "ACUENTA"
        Me.Label13.Visible = False
        '
        'txtCotizacion
        '
        Me.txtCotizacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtCotizacion.BeforeTouchSize = New System.Drawing.Size(204, 29)
        Me.txtCotizacion.BorderColor = System.Drawing.SystemColors.HotTrack
        Me.txtCotizacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCotizacion.DecimalPlaces = 2
        Me.txtCotizacion.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
        Me.txtCotizacion.ForeColor = System.Drawing.Color.Black
        Me.txtCotizacion.Location = New System.Drawing.Point(314, 504)
        Me.txtCotizacion.Maximum = New Decimal(New Integer() {-159383552, 46653770, 5421, 0})
        Me.txtCotizacion.MetroColor = System.Drawing.SystemColors.HotTrack
        Me.txtCotizacion.Name = "txtCotizacion"
        Me.txtCotizacion.Size = New System.Drawing.Size(204, 29)
        Me.txtCotizacion.TabIndex = 705
        Me.txtCotizacion.TabStop = False
        Me.txtCotizacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtCotizacion.ThousandsSeparator = True
        Me.txtCotizacion.Visible = False
        Me.txtCotizacion.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Maroon
        Me.Label11.Location = New System.Drawing.Point(97, 515)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(102, 18)
        Me.Label11.TabIndex = 704
        Me.Label11.Text = "COTIZACIÒN"
        Me.Label11.Visible = False
        '
        'txtDescuento
        '
        Me.txtDescuento.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtDescuento.BeforeTouchSize = New System.Drawing.Size(80, 29)
        Me.txtDescuento.BorderColor = System.Drawing.SystemColors.HotTrack
        Me.txtDescuento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescuento.DecimalPlaces = 2
        Me.txtDescuento.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
        Me.txtDescuento.ForeColor = System.Drawing.Color.Black
        Me.txtDescuento.Location = New System.Drawing.Point(208, 469)
        Me.txtDescuento.Maximum = New Decimal(New Integer() {-159383552, 46653770, 5421, 0})
        Me.txtDescuento.MetroColor = System.Drawing.SystemColors.HotTrack
        Me.txtDescuento.Name = "txtDescuento"
        Me.txtDescuento.Size = New System.Drawing.Size(80, 29)
        Me.txtDescuento.TabIndex = 703
        Me.txtDescuento.TabStop = False
        Me.txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtDescuento.ThousandsSeparator = True
        Me.txtDescuento.Visible = False
        Me.txtDescuento.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Maroon
        Me.Label7.Location = New System.Drawing.Point(96, 480)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(108, 18)
        Me.Label7.TabIndex = 702
        Me.Label7.Text = "DESCUENTO"
        Me.Label7.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(24, 143)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 13)
        Me.Label10.TabIndex = 701
        Me.Label10.Text = "Chofer"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(379, 143)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 700
        Me.Label2.Text = "Unidad"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(276, 88)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 13)
        Me.Label8.TabIndex = 698
        Me.Label8.Text = "Destino"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(24, 88)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 13)
        Me.Label9.TabIndex = 699
        Me.Label9.Text = "Origen"
        '
        'txtHora
        '
        Me.txtHora.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtHora.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtHora.BorderColor = System.Drawing.Color.Silver
        Me.txtHora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHora.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtHora.CornerRadius = 4
        Me.txtHora.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtHora.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHora.ForeColor = System.Drawing.Color.Black
        Me.txtHora.Location = New System.Drawing.Point(279, 45)
        Me.txtHora.Metrocolor = System.Drawing.Color.Silver
        Me.txtHora.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtHora.Name = "txtHora"
        Me.txtHora.ReadOnly = True
        Me.txtHora.Size = New System.Drawing.Size(243, 24)
        Me.txtHora.TabIndex = 697
        '
        'txtFecha
        '
        Me.txtFecha.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtFecha.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtFecha.BorderColor = System.Drawing.Color.Silver
        Me.txtFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFecha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFecha.CornerRadius = 4
        Me.txtFecha.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtFecha.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha.ForeColor = System.Drawing.Color.Black
        Me.txtFecha.Location = New System.Drawing.Point(27, 45)
        Me.txtFecha.Metrocolor = System.Drawing.Color.Silver
        Me.txtFecha.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ReadOnly = True
        Me.txtFecha.Size = New System.Drawing.Size(243, 24)
        Me.txtFecha.TabIndex = 696
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Maroon
        Me.Label5.Location = New System.Drawing.Point(14, 208)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(190, 18)
        Me.Label5.TabIndex = 693
        Me.Label5.Text = "TOTAL VENTA BOLETOS"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 628
        Me.Label3.Text = "Programaciòn"
        '
        'txtdestino
        '
        Me.txtdestino.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtdestino.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtdestino.BorderColor = System.Drawing.Color.Silver
        Me.txtdestino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtdestino.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdestino.CornerRadius = 4
        Me.txtdestino.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtdestino.Enabled = False
        Me.txtdestino.FarImage = CType(resources.GetObject("txtdestino.FarImage"), System.Drawing.Image)
        Me.txtdestino.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdestino.ForeColor = System.Drawing.Color.Black
        Me.txtdestino.Location = New System.Drawing.Point(279, 104)
        Me.txtdestino.Metrocolor = System.Drawing.Color.Silver
        Me.txtdestino.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtdestino.Name = "txtdestino"
        Me.txtdestino.ReadOnly = True
        Me.txtdestino.Size = New System.Drawing.Size(243, 24)
        Me.txtdestino.TabIndex = 636
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(276, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 629
        Me.Label4.Text = "Hora"
        '
        'TextSeriePlaca
        '
        Me.TextSeriePlaca.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextSeriePlaca.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TextSeriePlaca.BorderColor = System.Drawing.Color.Silver
        Me.TextSeriePlaca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextSeriePlaca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextSeriePlaca.CornerRadius = 4
        Me.TextSeriePlaca.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextSeriePlaca.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextSeriePlaca.ForeColor = System.Drawing.Color.Black
        Me.TextSeriePlaca.Location = New System.Drawing.Point(382, 159)
        Me.TextSeriePlaca.Metrocolor = System.Drawing.Color.Silver
        Me.TextSeriePlaca.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextSeriePlaca.Name = "TextSeriePlaca"
        Me.TextSeriePlaca.ReadOnly = True
        Me.TextSeriePlaca.Size = New System.Drawing.Size(140, 24)
        Me.TextSeriePlaca.TabIndex = 632
        '
        'TextCodigoPlaca
        '
        Me.TextCodigoPlaca.BackColor = System.Drawing.Color.White
        Me.TextCodigoPlaca.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TextCodigoPlaca.BorderColor = System.Drawing.Color.Silver
        Me.TextCodigoPlaca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextCodigoPlaca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextCodigoPlaca.CornerRadius = 3
        Me.TextCodigoPlaca.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextCodigoPlaca.Enabled = False
        Me.TextCodigoPlaca.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextCodigoPlaca.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextCodigoPlaca.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextCodigoPlaca.Location = New System.Drawing.Point(27, 159)
        Me.TextCodigoPlaca.MaxLength = 70
        Me.TextCodigoPlaca.Metrocolor = System.Drawing.Color.Silver
        Me.TextCodigoPlaca.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextCodigoPlaca.Name = "TextCodigoPlaca"
        Me.TextCodigoPlaca.Size = New System.Drawing.Size(342, 22)
        Me.TextCodigoPlaca.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextCodigoPlaca.TabIndex = 633
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(24, 29)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 13)
        Me.Label6.TabIndex = 634
        Me.Label6.Text = "Fecha"
        '
        'TextRuta
        '
        Me.TextRuta.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextRuta.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TextRuta.BorderColor = System.Drawing.Color.Silver
        Me.TextRuta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextRuta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextRuta.CornerRadius = 4
        Me.TextRuta.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextRuta.Enabled = False
        Me.TextRuta.FarImage = CType(resources.GetObject("TextRuta.FarImage"), System.Drawing.Image)
        Me.TextRuta.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextRuta.ForeColor = System.Drawing.Color.Black
        Me.TextRuta.Location = New System.Drawing.Point(27, 104)
        Me.TextRuta.Metrocolor = System.Drawing.Color.Silver
        Me.TextRuta.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextRuta.Name = "TextRuta"
        Me.TextRuta.ReadOnly = True
        Me.TextRuta.Size = New System.Drawing.Size(243, 24)
        Me.TextRuta.TabIndex = 635
        '
        'FormViewResumenLiquidacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionForeColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1113, 553)
        Me.Controls.Add(Me.GradientPanel8)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormViewResumenLiquidacion"
        Me.ShowIcon = False
        Me.Text = "Resumen Liquidacion"
        CType(Me.GradientPanel8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel8.ResumeLayout(False)
        CType(Me.dgvCuentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.txtTotalDescuento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalVEntas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalAPagar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAcuenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCotizacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescuento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtdestino, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextSeriePlaca, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextCodigoPlaca, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextRuta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents GradientPanel8 As Tools.GradientPanel
    Friend WithEvents dgvCuentas As Grid.Grouping.GridGroupingControl
    Friend WithEvents RoundButton21 As RoundButton2
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents txtdestino As Tools.TextBoxExt
    Friend WithEvents Label4 As Label
    Friend WithEvents TextSeriePlaca As Tools.TextBoxExt
    Friend WithEvents TextCodigoPlaca As Tools.TextBoxExt
    Friend WithEvents Label6 As Label
    Friend WithEvents TextRuta As Tools.TextBoxExt
    Friend WithEvents txtTotalAPagar As Tools.TextBoxExt
    Friend WithEvents txtTotal As Tools.TextBoxExt
    Friend WithEvents Label12 As Label
    Friend WithEvents txtAcuenta As Tools.NumericUpDownExt
    Friend WithEvents Label13 As Label
    Friend WithEvents txtCotizacion As Tools.NumericUpDownExt
    Friend WithEvents Label11 As Label
    Friend WithEvents txtDescuento As Tools.NumericUpDownExt
    Friend WithEvents Label7 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtHora As Tools.TextBoxExt
    Friend WithEvents txtFecha As Tools.TextBoxExt
    Friend WithEvents Label5 As Label
    Friend WithEvents txtTotalVEntas As Tools.NumericUpDownExt
    Friend WithEvents txtTotalDescuento As Tools.TextBoxExt
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
End Class

Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormConfiguracionPago
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormConfiguracionPago))
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor6 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridSummaryRowDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor()
        Dim GridSummaryColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor()
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Dim CaptionLabel2 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CboFormaPago = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ButtonAdv2 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.btOperacion = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.cboCajas = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.gradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.dgvCuentas = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ChBanco = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ChEfectivo = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        CType(Me.CboFormaPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCajas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gradientPanel2.SuspendLayout()
        CType(Me.dgvCuentas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(253, 46)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 14)
        Me.Label6.TabIndex = 529
        Me.Label6.Text = "Forma de pago"
        '
        'CboFormaPago
        '
        Me.CboFormaPago.BackColor = System.Drawing.Color.White
        Me.CboFormaPago.BeforeTouchSize = New System.Drawing.Size(229, 21)
        Me.CboFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboFormaPago.Enabled = False
        Me.CboFormaPago.FlatBorderColor = System.Drawing.SystemColors.HotTrack
        Me.CboFormaPago.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboFormaPago.Location = New System.Drawing.Point(256, 67)
        Me.CboFormaPago.MetroBorderColor = System.Drawing.SystemColors.HotTrack
        Me.CboFormaPago.MetroColor = System.Drawing.SystemColors.HotTrack
        Me.CboFormaPago.Name = "CboFormaPago"
        Me.CboFormaPago.Size = New System.Drawing.Size(229, 21)
        Me.CboFormaPago.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.CboFormaPago.TabIndex = 528
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(18, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 14)
        Me.Label4.TabIndex = 527
        Me.Label4.Text = "Cuenta financiera"
        '
        'ButtonAdv2
        '
        Me.ButtonAdv2.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv2.BackColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.ButtonAdv2.BeforeTouchSize = New System.Drawing.Size(25, 25)
        Me.ButtonAdv2.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv2.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv2.Image = CType(resources.GetObject("ButtonAdv2.Image"), System.Drawing.Image)
        Me.ButtonAdv2.IsBackStageButton = False
        Me.ButtonAdv2.Location = New System.Drawing.Point(622, 63)
        Me.ButtonAdv2.MetroColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.ButtonAdv2.Name = "ButtonAdv2"
        Me.ButtonAdv2.Size = New System.Drawing.Size(25, 25)
        Me.ButtonAdv2.TabIndex = 526
        Me.ButtonAdv2.UseVisualStyle = True
        '
        'btOperacion
        '
        Me.btOperacion.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btOperacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(163, Byte), Integer))
        Me.btOperacion.BeforeTouchSize = New System.Drawing.Size(25, 25)
        Me.btOperacion.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btOperacion.ForeColor = System.Drawing.Color.White
        Me.btOperacion.Image = CType(resources.GetObject("btOperacion.Image"), System.Drawing.Image)
        Me.btOperacion.IsBackStageButton = False
        Me.btOperacion.Location = New System.Drawing.Point(595, 63)
        Me.btOperacion.MetroColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(163, Byte), Integer))
        Me.btOperacion.Name = "btOperacion"
        Me.btOperacion.Size = New System.Drawing.Size(25, 25)
        Me.btOperacion.TabIndex = 525
        Me.btOperacion.UseVisualStyle = True
        '
        'cboCajas
        '
        Me.cboCajas.BackColor = System.Drawing.Color.White
        Me.cboCajas.BeforeTouchSize = New System.Drawing.Size(229, 21)
        Me.cboCajas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCajas.Enabled = False
        Me.cboCajas.FlatBorderColor = System.Drawing.SystemColors.HotTrack
        Me.cboCajas.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCajas.Location = New System.Drawing.Point(21, 67)
        Me.cboCajas.MetroBorderColor = System.Drawing.SystemColors.HotTrack
        Me.cboCajas.MetroColor = System.Drawing.SystemColors.HotTrack
        Me.cboCajas.Name = "cboCajas"
        Me.cboCajas.Size = New System.Drawing.Size(229, 21)
        Me.cboCajas.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboCajas.TabIndex = 524
        '
        'gradientPanel2
        '
        Me.gradientPanel2.BackgroundColor = New Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.PatternStyle.Weave, System.Drawing.Color.White, System.Drawing.Color.White)
        Me.gradientPanel2.BorderColor = System.Drawing.Color.Silver
        Me.gradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.gradientPanel2.Controls.Add(Me.dgvCuentas)
        Me.gradientPanel2.Location = New System.Drawing.Point(21, 93)
        Me.gradientPanel2.Name = "gradientPanel2"
        Me.gradientPanel2.Size = New System.Drawing.Size(626, 222)
        Me.gradientPanel2.TabIndex = 523
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
        Me.dgvCuentas.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgvCuentas.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2007Silver
        Me.dgvCuentas.Location = New System.Drawing.Point(0, 0)
        Me.dgvCuentas.Name = "dgvCuentas"
        Me.dgvCuentas.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.dgvCuentas.Size = New System.Drawing.Size(624, 220)
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
        GridColumnDescriptor1.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.LavenderBlush)
        GridColumnDescriptor1.Appearance.AnyRecordFieldCell.Text = ""
        GridColumnDescriptor1.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        GridColumnDescriptor1.MappingName = "tipo"
        GridColumnDescriptor1.ReadOnly = True
        GridColumnDescriptor2.MappingName = "identidad"
        GridColumnDescriptor2.ReadOnly = True
        GridColumnDescriptor2.Width = 19
        GridColumnDescriptor3.HeaderText = "Cuenta"
        GridColumnDescriptor3.MappingName = "entidad"
        GridColumnDescriptor3.ReadOnly = True
        GridColumnDescriptor3.Width = 272
        GridColumnDescriptor4.MappingName = "idforma"
        GridColumnDescriptor4.Width = 20
        GridColumnDescriptor5.HeaderText = "Forma de Pago"
        GridColumnDescriptor5.MappingName = "formaPago"
        GridColumnDescriptor5.ReadOnly = True
        GridColumnDescriptor5.Width = 200
        GridColumnDescriptor6.HeaderText = "Moneda"
        GridColumnDescriptor6.MappingName = "moneda"
        GridColumnDescriptor6.Width = 90
        Me.dgvCuentas.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6})
        GridSummaryRowDescriptor1.Appearance.AnySummaryCell.CellType = "TextBox"
        GridSummaryRowDescriptor1.Appearance.AnySummaryCell.CurrencyEdit.CurrencySymbol = ""
        GridSummaryRowDescriptor1.Name = "Row 1"
        GridSummaryColumnDescriptor1.Appearance.AnySummaryCell.CellType = "Currency"
        GridSummaryColumnDescriptor1.DataMember = "abonado"
        GridSummaryColumnDescriptor1.Format = "{Sum}"
        GridSummaryColumnDescriptor1.Name = "abonado"
        GridSummaryColumnDescriptor1.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        GridSummaryRowDescriptor1.SummaryColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor() {GridSummaryColumnDescriptor1})
        GridSummaryRowDescriptor1.Title = "Total pagos: "
        Me.dgvCuentas.TableDescriptor.SummaryRows.Add(GridSummaryRowDescriptor1)
        Me.dgvCuentas.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.dgvCuentas.TableDescriptor.TableOptions.RecordRowHeight = 20
        Me.dgvCuentas.TableDescriptor.TopLevelGroupOptions.ShowCaption = False
        Me.dgvCuentas.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("formaPago"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("entidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("moneda")})
        Me.dgvCuentas.Text = "GridGroupingControl2"
        Me.dgvCuentas.UseRightToLeftCompatibleTextBox = True
        Me.dgvCuentas.VersionInfo = "12.4400.0.24"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(131, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 520
        Me.Label2.Text = "Banco"
        '
        'ChBanco
        '
        Me.ChBanco.BackColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.ChBanco.ChechedOffColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.ChBanco.Checked = False
        Me.ChBanco.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.ChBanco.ForeColor = System.Drawing.Color.White
        Me.ChBanco.Location = New System.Drawing.Point(108, 17)
        Me.ChBanco.Name = "ChBanco"
        Me.ChBanco.Size = New System.Drawing.Size(20, 20)
        Me.ChBanco.TabIndex = 519
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(45, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 518
        Me.Label5.Text = "Efectivo"
        '
        'ChEfectivo
        '
        Me.ChEfectivo.BackColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.ChEfectivo.ChechedOffColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.ChEfectivo.Checked = False
        Me.ChEfectivo.CheckedOnColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(117, Byte), Integer))
        Me.ChEfectivo.ForeColor = System.Drawing.Color.White
        Me.ChEfectivo.Location = New System.Drawing.Point(22, 17)
        Me.ChEfectivo.Name = "ChEfectivo"
        Me.ChEfectivo.Size = New System.Drawing.Size(20, 20)
        Me.ChEfectivo.TabIndex = 517
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
        Me.GradientPanel1.Size = New System.Drawing.Size(668, 10)
        Me.GradientPanel1.TabIndex = 530
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.SystemColors.HotTrack
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(127, 32)
        Me.ButtonAdv1.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(268, 327)
        Me.ButtonAdv1.MetroColor = System.Drawing.SystemColors.HotTrack
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(127, 32)
        Me.ButtonAdv1.TabIndex = 531
        Me.ButtonAdv1.Text = "Aceptar"
        Me.ButtonAdv1.UseVisualStyle = True
        '
        'FormConfiguracionPago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarHeight = 55
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(15, 12)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(30, 30)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.SystemColors.HotTrack
        CaptionLabel1.Location = New System.Drawing.Point(55, 8)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(200, 24)
        CaptionLabel1.Text = "Configuración pagos"
        CaptionLabel2.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel2.Location = New System.Drawing.Point(55, 24)
        CaptionLabel2.Name = "CaptionLabel2"
        CaptionLabel2.Size = New System.Drawing.Size(200, 24)
        CaptionLabel2.Text = "Cuentas financieras"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.CaptionLabels.Add(CaptionLabel2)
        Me.ClientSize = New System.Drawing.Size(668, 361)
        Me.Controls.Add(Me.ButtonAdv1)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.CboFormaPago)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ButtonAdv2)
        Me.Controls.Add(Me.btOperacion)
        Me.Controls.Add(Me.cboCajas)
        Me.Controls.Add(Me.gradientPanel2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ChBanco)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ChEfectivo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FormConfiguracionPago"
        Me.ShowIcon = False
        Me.ShowMaximizeBox = False
        Me.ShowMinimizeBox = False
        CType(Me.CboFormaPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCajas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gradientPanel2.ResumeLayout(False)
        CType(Me.dgvCuentas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label6 As Label
    Friend WithEvents CboFormaPago As Tools.ComboBoxAdv
    Friend WithEvents Label4 As Label
    Friend WithEvents ButtonAdv2 As ButtonAdv
    Friend WithEvents btOperacion As ButtonAdv
    Friend WithEvents cboCajas As Tools.ComboBoxAdv
    Private WithEvents gradientPanel2 As Tools.GradientPanel
    Friend WithEvents dgvCuentas As Grid.Grouping.GridGroupingControl
    Friend WithEvents Label2 As Label
    Friend WithEvents ChBanco As Bunifu.Framework.UI.BunifuCheckbox
    Friend WithEvents Label5 As Label
    Friend WithEvents ChEfectivo As Bunifu.Framework.UI.BunifuCheckbox
    Private WithEvents GradientPanel1 As Tools.GradientPanel
    Friend WithEvents ButtonAdv1 As ButtonAdv
End Class

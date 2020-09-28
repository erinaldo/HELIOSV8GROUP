<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDetalleCuotas
    Inherits Helios.Cont.Presentation.WinForm.frmMaster

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
        Dim GridColumnDescriptor6 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor7 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor8 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor9 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor10 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.txtTipoProv = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtCliente = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtCuenta = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtRuc = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtDescripcion = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtSerie = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtNumero = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txttipocambio = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMoneda = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtImporteCompramn = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtImporteComprame = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dgvPagosProgramados = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtTipoProv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRuc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescripcion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSerie, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txttipocambio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtImporteCompramn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtImporteComprame, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvPagosProgramados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label32)
        Me.GroupBox1.Controls.Add(Me.txtTipoProv)
        Me.GroupBox1.Controls.Add(Me.txtCliente)
        Me.GroupBox1.Controls.Add(Me.Label33)
        Me.GroupBox1.Controls.Add(Me.txtCuenta)
        Me.GroupBox1.Controls.Add(Me.txtRuc)
        Me.GroupBox1.Controls.Add(Me.txtDescripcion)
        Me.GroupBox1.Controls.Add(Me.txtSerie)
        Me.GroupBox1.Controls.Add(Me.txtNumero)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txttipocambio)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtMoneda)
        Me.GroupBox1.Controls.Add(Me.txtImporteCompramn)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtImporteComprame)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(636, 117)
        Me.GroupBox1.TabIndex = 563
        Me.GroupBox1.TabStop = False
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.Black
        Me.Label32.Location = New System.Drawing.Point(10, 18)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(85, 12)
        Me.Label32.TabIndex = 12
        Me.Label32.Text = "IDENTIFICACIÓN"
        '
        'txtTipoProv
        '
        Me.txtTipoProv.BackColor = System.Drawing.Color.White
        Me.txtTipoProv.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtTipoProv.BorderColor = System.Drawing.Color.Silver
        Me.txtTipoProv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTipoProv.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTipoProv.Location = New System.Drawing.Point(9, 118)
        Me.txtTipoProv.Metrocolor = System.Drawing.Color.Silver
        Me.txtTipoProv.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtTipoProv.Name = "txtTipoProv"
        Me.txtTipoProv.ReadOnly = True
        Me.txtTipoProv.Size = New System.Drawing.Size(57, 22)
        Me.txtTipoProv.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtTipoProv.TabIndex = 557
        Me.txtTipoProv.Visible = False
        '
        'txtCliente
        '
        Me.txtCliente.BackColor = System.Drawing.Color.White
        Me.txtCliente.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtCliente.BorderColor = System.Drawing.Color.Silver
        Me.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCliente.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCliente.Location = New System.Drawing.Point(12, 36)
        Me.txtCliente.Metrocolor = System.Drawing.Color.Silver
        Me.txtCliente.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(257, 22)
        Me.txtCliente.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtCliente.TabIndex = 13
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.Black
        Me.Label33.Location = New System.Drawing.Point(277, 18)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(26, 12)
        Me.Label33.TabIndex = 424
        Me.Label33.Text = "RUC"
        '
        'txtCuenta
        '
        Me.txtCuenta.BackColor = System.Drawing.Color.White
        Me.txtCuenta.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtCuenta.BorderColor = System.Drawing.Color.Silver
        Me.txtCuenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuenta.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCuenta.Location = New System.Drawing.Point(279, 156)
        Me.txtCuenta.Metrocolor = System.Drawing.Color.Silver
        Me.txtCuenta.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.ReadOnly = True
        Me.txtCuenta.Size = New System.Drawing.Size(57, 22)
        Me.txtCuenta.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtCuenta.TabIndex = 559
        Me.txtCuenta.Visible = False
        '
        'txtRuc
        '
        Me.txtRuc.BackColor = System.Drawing.Color.White
        Me.txtRuc.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtRuc.BorderColor = System.Drawing.Color.Silver
        Me.txtRuc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRuc.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRuc.Location = New System.Drawing.Point(275, 36)
        Me.txtRuc.Metrocolor = System.Drawing.Color.Silver
        Me.txtRuc.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtRuc.Name = "txtRuc"
        Me.txtRuc.ReadOnly = True
        Me.txtRuc.Size = New System.Drawing.Size(96, 22)
        Me.txtRuc.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtRuc.TabIndex = 425
        '
        'txtDescripcion
        '
        Me.txtDescripcion.BackColor = System.Drawing.Color.White
        Me.txtDescripcion.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtDescripcion.BorderColor = System.Drawing.Color.Silver
        Me.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDescripcion.Location = New System.Drawing.Point(12, 156)
        Me.txtDescripcion.Metrocolor = System.Drawing.Color.Silver
        Me.txtDescripcion.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.ReadOnly = True
        Me.txtDescripcion.Size = New System.Drawing.Size(257, 22)
        Me.txtDescripcion.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtDescripcion.TabIndex = 558
        Me.txtDescripcion.Visible = False
        '
        'txtSerie
        '
        Me.txtSerie.BackColor = System.Drawing.Color.White
        Me.txtSerie.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtSerie.BorderColor = System.Drawing.Color.Silver
        Me.txtSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSerie.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSerie.Location = New System.Drawing.Point(12, 80)
        Me.txtSerie.Metrocolor = System.Drawing.Color.Silver
        Me.txtSerie.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.ReadOnly = True
        Me.txtSerie.Size = New System.Drawing.Size(96, 22)
        Me.txtSerie.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtSerie.TabIndex = 538
        '
        'txtNumero
        '
        Me.txtNumero.BackColor = System.Drawing.Color.White
        Me.txtNumero.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtNumero.BorderColor = System.Drawing.Color.Silver
        Me.txtNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumero.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNumero.Location = New System.Drawing.Point(140, 80)
        Me.txtNumero.Metrocolor = System.Drawing.Color.Silver
        Me.txtNumero.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.ReadOnly = True
        Me.txtNumero.Size = New System.Drawing.Size(217, 22)
        Me.txtNumero.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtNumero.TabIndex = 539
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(10, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 12)
        Me.Label1.TabIndex = 541
        Me.Label1.Text = "SERIE"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(442, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 12)
        Me.Label5.TabIndex = 554
        Me.Label5.Text = "MONEDA"
        '
        'txttipocambio
        '
        Me.txttipocambio.BackColor = System.Drawing.Color.White
        Me.txttipocambio.BeforeTouchSize = New System.Drawing.Size(68, 22)
        Me.txttipocambio.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txttipocambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txttipocambio.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttipocambio.Location = New System.Drawing.Point(566, 168)
        Me.txttipocambio.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txttipocambio.Name = "txttipocambio"
        Me.txttipocambio.Size = New System.Drawing.Size(68, 22)
        Me.txttipocambio.TabIndex = 553
        Me.txttipocambio.TabStop = False
        Me.txttipocambio.ThousandsSeparator = True
        Me.txttipocambio.Visible = False
        Me.txttipocambio.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(138, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 12)
        Me.Label2.TabIndex = 542
        Me.Label2.Text = "NUMERO"
        '
        'txtMoneda
        '
        Me.txtMoneda.BackColor = System.Drawing.Color.White
        Me.txtMoneda.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtMoneda.BorderColor = System.Drawing.Color.Silver
        Me.txtMoneda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMoneda.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMoneda.Location = New System.Drawing.Point(444, 34)
        Me.txtMoneda.Metrocolor = System.Drawing.Color.Silver
        Me.txtMoneda.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtMoneda.Name = "txtMoneda"
        Me.txtMoneda.ReadOnly = True
        Me.txtMoneda.Size = New System.Drawing.Size(96, 22)
        Me.txtMoneda.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtMoneda.TabIndex = 552
        '
        'txtImporteCompramn
        '
        Me.txtImporteCompramn.BackColor = System.Drawing.Color.White
        Me.txtImporteCompramn.BeforeTouchSize = New System.Drawing.Size(100, 22)
        Me.txtImporteCompramn.BorderColor = System.Drawing.Color.White
        Me.txtImporteCompramn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtImporteCompramn.DecimalPlaces = 2
        Me.txtImporteCompramn.InterceptArrowKeys = False
        Me.txtImporteCompramn.Location = New System.Drawing.Point(410, 81)
        Me.txtImporteCompramn.Maximum = New Decimal(New Integer() {-159383552, 46653770, 5421, 0})
        Me.txtImporteCompramn.MetroColor = System.Drawing.Color.White
        Me.txtImporteCompramn.Name = "txtImporteCompramn"
        Me.txtImporteCompramn.ReadOnly = True
        Me.txtImporteCompramn.Size = New System.Drawing.Size(100, 22)
        Me.txtImporteCompramn.TabIndex = 548
        Me.txtImporteCompramn.TabStop = False
        Me.txtImporteCompramn.ThousandsSeparator = True
        Me.txtImporteCompramn.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(517, 65)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 13)
        Me.Label8.TabIndex = 547
        Me.Label8.Text = "Importe ME:"
        '
        'txtImporteComprame
        '
        Me.txtImporteComprame.BackColor = System.Drawing.Color.White
        Me.txtImporteComprame.BeforeTouchSize = New System.Drawing.Size(100, 22)
        Me.txtImporteComprame.BorderColor = System.Drawing.Color.White
        Me.txtImporteComprame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtImporteComprame.DecimalPlaces = 2
        Me.txtImporteComprame.InterceptArrowKeys = False
        Me.txtImporteComprame.Location = New System.Drawing.Point(520, 82)
        Me.txtImporteComprame.Maximum = New Decimal(New Integer() {-1304428544, 434162106, 542, 0})
        Me.txtImporteComprame.MetroColor = System.Drawing.Color.White
        Me.txtImporteComprame.Name = "txtImporteComprame"
        Me.txtImporteComprame.ReadOnly = True
        Me.txtImporteComprame.Size = New System.Drawing.Size(100, 22)
        Me.txtImporteComprame.TabIndex = 549
        Me.txtImporteComprame.TabStop = False
        Me.txtImporteComprame.ThousandsSeparator = True
        Me.txtImporteComprame.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(407, 65)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 13)
        Me.Label6.TabIndex = 546
        Me.Label6.Text = "Importe MN:"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(648, 128)
        Me.Panel1.TabIndex = 564
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.dgvPagosProgramados)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 128)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(648, 246)
        Me.Panel2.TabIndex = 565
        '
        'dgvPagosProgramados
        '
        Me.dgvPagosProgramados.BackColor = System.Drawing.SystemColors.Window
        Me.dgvPagosProgramados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPagosProgramados.FreezeCaption = False
        Me.dgvPagosProgramados.Location = New System.Drawing.Point(0, 0)
        Me.dgvPagosProgramados.Name = "dgvPagosProgramados"
        Me.dgvPagosProgramados.Size = New System.Drawing.Size(648, 246)
        Me.dgvPagosProgramados.TabIndex = 423
        GridColumnDescriptor6.HeaderImage = Nothing
        GridColumnDescriptor6.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor6.HeaderText = "N°Cuota"
        GridColumnDescriptor6.MappingName = "cuota"
        GridColumnDescriptor6.SerializedImageArray = ""
        GridColumnDescriptor6.Width = 70
        GridColumnDescriptor7.Appearance.AnyRecordFieldCell.CellType = "Currency"
        GridColumnDescriptor7.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
        GridColumnDescriptor7.HeaderImage = Nothing
        GridColumnDescriptor7.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor7.HeaderText = "Pagos MN"
        GridColumnDescriptor7.MappingName = "pago"
        GridColumnDescriptor7.SerializedImageArray = ""
        GridColumnDescriptor7.Width = 70
        GridColumnDescriptor8.Appearance.AnyRecordFieldCell.CellType = "Currency"
        GridColumnDescriptor8.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
        GridColumnDescriptor8.HeaderImage = Nothing
        GridColumnDescriptor8.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor8.HeaderText = "Pagos ME"
        GridColumnDescriptor8.MappingName = "pagome"
        GridColumnDescriptor8.SerializedImageArray = ""
        GridColumnDescriptor8.Width = 0
        GridColumnDescriptor9.HeaderImage = Nothing
        GridColumnDescriptor9.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor9.HeaderText = "Fecha Pago"
        GridColumnDescriptor9.MappingName = "fechaPago"
        GridColumnDescriptor9.SerializedImageArray = ""
        GridColumnDescriptor9.Width = 140
        GridColumnDescriptor10.HeaderImage = Nothing
        GridColumnDescriptor10.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor10.HeaderText = "Estado"
        GridColumnDescriptor10.MappingName = "estado"
        GridColumnDescriptor10.SerializedImageArray = ""
        Me.dgvPagosProgramados.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor6, GridColumnDescriptor7, GridColumnDescriptor8, GridColumnDescriptor9, GridColumnDescriptor10})
        Me.dgvPagosProgramados.TableDescriptor.SummaryRows.Add(New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor("Row 1", New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor("Summary 1", Syncfusion.Grouping.SummaryType.DoubleAggregate, "saldoMN", "{Sum:###,###,##0.00}"), New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor("Summary 2", Syncfusion.Grouping.SummaryType.DoubleAggregate, "montoVenc", "{Sum:###,###,##0.00}"), New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor("Summary 3", Syncfusion.Grouping.SummaryType.DoubleAggregate, "pago", "{Sum:###,###,##0.00}"), New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor("Summary 4", Syncfusion.Grouping.SummaryType.DoubleAggregate, "pagome", "{Sum:###,###,##0.00}"), New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor("Summary 5", Syncfusion.Grouping.SummaryType.DoubleAggregate, "abonoMN", "{Sum:###,###,##0.00}"), New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor("Summary 6", Syncfusion.Grouping.SummaryType.DoubleAggregate, "abonoME", "{Sum:###,###,##0.00}"), New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor("Summary 7", Syncfusion.Grouping.SummaryType.DoubleAggregate, "importeMN", "{Sum:###,###,##0.00}"), New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor("Summary 8", Syncfusion.Grouping.SummaryType.DoubleAggregate, "importeME", "{Sum:###,###,##0.00}")}))
        Me.dgvPagosProgramados.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("cuota"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("pago"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("pagome"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("fechaPago"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("estado")})
        Me.dgvPagosProgramados.TableOptions.GridLineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder()
        Me.dgvPagosProgramados.TableOptions.ListBoxSelectionOutlineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.Transparent)
        Me.dgvPagosProgramados.TableOptions.TreeLineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.White)
        Me.dgvPagosProgramados.Text = "gridGroupingControl1"
        Me.dgvPagosProgramados.VersionInfo = "12.2400.0.20"
        '
        'frmDetalleCuotas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.Color.CadetBlue
        Me.CaptionBarHeight = 50
        Me.CaptionForeColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(648, 374)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmDetalleCuotas"
        Me.ShowIcon = False
        Me.Text = "Cronograma de Cuotas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtTipoProv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCuenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRuc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescripcion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSerie, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumero, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txttipocambio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtImporteCompramn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtImporteComprame, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgvPagosProgramados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents txtCliente As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtCuenta As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtRuc As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtDescripcion As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtSerie As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtNumero As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txttipocambio As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMoneda As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtImporteCompramn As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtImporteComprame As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTipoProv As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Private WithEvents dgvPagosProgramados As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
End Class

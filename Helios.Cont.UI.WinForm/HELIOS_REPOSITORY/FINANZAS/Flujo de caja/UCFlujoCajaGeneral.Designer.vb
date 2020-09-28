<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UCFlujoCajaGeneral
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCFlujoCajaGeneral))
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim ChartSeries1 As Syncfusion.Windows.Forms.Chart.ChartSeries = New Syncfusion.Windows.Forms.Chart.ChartSeries()
        Dim ChartCustomShapeInfo1 As Syncfusion.Windows.Forms.Chart.ChartCustomShapeInfo = New Syncfusion.Windows.Forms.Chart.ChartCustomShapeInfo()
        Dim ChartLineInfo1 As Syncfusion.Windows.Forms.Chart.ChartLineInfo = New Syncfusion.Windows.Forms.Chart.ChartLineInfo()
        Dim ChartSeries2 As Syncfusion.Windows.Forms.Chart.ChartSeries = New Syncfusion.Windows.Forms.Chart.ChartSeries()
        Dim ChartCustomShapeInfo2 As Syncfusion.Windows.Forms.Chart.ChartCustomShapeInfo = New Syncfusion.Windows.Forms.Chart.ChartCustomShapeInfo()
        Me.BunifuThinButton23 = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.txtFechaLaboral = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.ComboUnidad = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.LabelTotalSaldo = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LabelTotalGastos = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.LabelTotalVentas = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.panel5 = New System.Windows.Forms.Panel()
        Me.gridGroupingControl1 = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chartControl1 = New Syncfusion.Windows.Forms.Chart.ChartControl()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.pictureBox2 = New System.Windows.Forms.PictureBox()
        Me.pictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        CType(Me.txtFechaLaboral, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboUnidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.panel5.SuspendLayout()
        CType(Me.gridGroupingControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BunifuThinButton23
        '
        Me.BunifuThinButton23.ActiveBorderThickness = 1
        Me.BunifuThinButton23.ActiveCornerRadius = 20
        Me.BunifuThinButton23.ActiveFillColor = System.Drawing.SystemColors.HotTrack
        Me.BunifuThinButton23.ActiveForecolor = System.Drawing.Color.White
        Me.BunifuThinButton23.ActiveLineColor = System.Drawing.SystemColors.HotTrack
        Me.BunifuThinButton23.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.BunifuThinButton23.BackgroundImage = CType(resources.GetObject("BunifuThinButton23.BackgroundImage"), System.Drawing.Image)
        Me.BunifuThinButton23.ButtonText = "CONSULTAR"
        Me.BunifuThinButton23.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuThinButton23.Font = New System.Drawing.Font("Yu Gothic", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuThinButton23.ForeColor = System.Drawing.Color.Black
        Me.BunifuThinButton23.IdleBorderThickness = 1
        Me.BunifuThinButton23.IdleCornerRadius = 20
        Me.BunifuThinButton23.IdleFillColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.BunifuThinButton23.IdleForecolor = System.Drawing.Color.White
        Me.BunifuThinButton23.IdleLineColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.BunifuThinButton23.Location = New System.Drawing.Point(362, 18)
        Me.BunifuThinButton23.Margin = New System.Windows.Forms.Padding(4)
        Me.BunifuThinButton23.Name = "BunifuThinButton23"
        Me.BunifuThinButton23.Size = New System.Drawing.Size(99, 35)
        Me.BunifuThinButton23.TabIndex = 678
        Me.BunifuThinButton23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtFechaLaboral
        '
        Me.txtFechaLaboral.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.txtFechaLaboral.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtFechaLaboral.BorderColor = System.Drawing.Color.FromArgb(CType(CType(104, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.txtFechaLaboral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaLaboral.CalendarForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaLaboral.CalendarMonthBackground = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.txtFechaLaboral.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtFechaLaboral.CalendarTitleBackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.txtFechaLaboral.CalendarTitleForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtFechaLaboral.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtFechaLaboral.Checked = False
        Me.txtFechaLaboral.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechaLaboral.CustomFormat = "dd/MM/yyyy"
        Me.txtFechaLaboral.DropDownImage = Nothing
        Me.txtFechaLaboral.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.txtFechaLaboral.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaLaboral.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtFechaLaboral.EnableNullDate = False
        Me.txtFechaLaboral.EnableNullKeys = False
        Me.txtFechaLaboral.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaLaboral.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtFechaLaboral.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFechaLaboral.Location = New System.Drawing.Point(261, 25)
        Me.txtFechaLaboral.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaLaboral.MinValue = New Date(CType(0, Long))
        Me.txtFechaLaboral.Name = "txtFechaLaboral"
        Me.txtFechaLaboral.ShowCheckBox = False
        Me.txtFechaLaboral.ShowDropButton = False
        Me.txtFechaLaboral.Size = New System.Drawing.Size(96, 23)
        Me.txtFechaLaboral.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Black
        Me.txtFechaLaboral.TabIndex = 676
        Me.txtFechaLaboral.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'ComboUnidad
        '
        Me.ComboUnidad.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.ComboUnidad.BeforeTouchSize = New System.Drawing.Size(241, 21)
        Me.ComboUnidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboUnidad.Enabled = False
        Me.ComboUnidad.FlatBorderColor = System.Drawing.Color.DimGray
        Me.ComboUnidad.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboUnidad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.ComboUnidad.Location = New System.Drawing.Point(15, 27)
        Me.ComboUnidad.MetroBorderColor = System.Drawing.Color.DimGray
        Me.ComboUnidad.Name = "ComboUnidad"
        Me.ComboUnidad.Size = New System.Drawing.Size(241, 21)
        Me.ComboUnidad.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Black
        Me.ComboUnidad.TabIndex = 680
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(22, Byte), Integer))
        Me.Panel3.Controls.Add(Me.LabelTotalSaldo)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Location = New System.Drawing.Point(880, 13)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(200, 77)
        Me.Panel3.TabIndex = 698
        '
        'LabelTotalSaldo
        '
        Me.LabelTotalSaldo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LabelTotalSaldo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelTotalSaldo.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTotalSaldo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.LabelTotalSaldo.Location = New System.Drawing.Point(0, 0)
        Me.LabelTotalSaldo.Name = "LabelTotalSaldo"
        Me.LabelTotalSaldo.Size = New System.Drawing.Size(200, 51)
        Me.LabelTotalSaldo.TabIndex = 56
        Me.LabelTotalSaldo.Text = "S/0.00"
        Me.LabelTotalSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label11.Font = New System.Drawing.Font("Yu Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(0, 51)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(200, 26)
        Me.Label11.TabIndex = 691
        Me.Label11.Text = "Saldo en caja"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(22, Byte), Integer))
        Me.Panel1.Controls.Add(Me.LabelTotalGastos)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Location = New System.Drawing.Point(674, 13)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(200, 77)
        Me.Panel1.TabIndex = 697
        '
        'LabelTotalGastos
        '
        Me.LabelTotalGastos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LabelTotalGastos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelTotalGastos.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTotalGastos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LabelTotalGastos.Location = New System.Drawing.Point(0, 0)
        Me.LabelTotalGastos.Name = "LabelTotalGastos"
        Me.LabelTotalGastos.Size = New System.Drawing.Size(200, 51)
        Me.LabelTotalGastos.TabIndex = 56
        Me.LabelTotalGastos.Text = "S/0.00"
        Me.LabelTotalGastos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label9.Font = New System.Drawing.Font("Yu Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Silver
        Me.Label9.Location = New System.Drawing.Point(0, 51)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(200, 26)
        Me.Label9.TabIndex = 691
        Me.Label9.Text = "Total Gastos "
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(22, Byte), Integer))
        Me.Panel2.Controls.Add(Me.LabelTotalVentas)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Location = New System.Drawing.Point(468, 13)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(200, 77)
        Me.Panel2.TabIndex = 696
        '
        'LabelTotalVentas
        '
        Me.LabelTotalVentas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LabelTotalVentas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelTotalVentas.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTotalVentas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LabelTotalVentas.Location = New System.Drawing.Point(0, 0)
        Me.LabelTotalVentas.Name = "LabelTotalVentas"
        Me.LabelTotalVentas.Size = New System.Drawing.Size(200, 51)
        Me.LabelTotalVentas.TabIndex = 56
        Me.LabelTotalVentas.Text = "S/0.00"
        Me.LabelTotalVentas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label8.Font = New System.Drawing.Font("Yu Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Silver
        Me.Label8.Location = New System.Drawing.Point(0, 51)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(200, 26)
        Me.Label8.TabIndex = 691
        Me.Label8.Text = "Ventas e ingresos"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'panel5
        '
        Me.panel5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(22, Byte), Integer))
        Me.panel5.Controls.Add(Me.gridGroupingControl1)
        Me.panel5.Controls.Add(Me.Label5)
        Me.panel5.Controls.Add(Me.chartControl1)
        Me.panel5.Location = New System.Drawing.Point(15, 100)
        Me.panel5.Name = "panel5"
        Me.panel5.Size = New System.Drawing.Size(1065, 407)
        Me.panel5.TabIndex = 699
        '
        'gridGroupingControl1
        '
        Me.gridGroupingControl1.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.gridGroupingControl1.BackColor = System.Drawing.Color.Black
        Me.gridGroupingControl1.ColorStyles = Syncfusion.Windows.Forms.ColorStyles.Office2010Black
        Me.gridGroupingControl1.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridGroupingControl1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gridGroupingControl1.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Office2010
        Me.gridGroupingControl1.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2010Black
        Me.gridGroupingControl1.Location = New System.Drawing.Point(17, 36)
        Me.gridGroupingControl1.Name = "gridGroupingControl1"
        Me.gridGroupingControl1.Office2010ScrollBarsColorScheme = Syncfusion.Windows.Forms.Office2010ColorScheme.Black
        Me.gridGroupingControl1.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.gridGroupingControl1.Size = New System.Drawing.Size(1032, 360)
        Me.gridGroupingControl1.TabIndex = 696
        Me.gridGroupingControl1.TableDescriptor.AllowNew = False
        GridColumnDescriptor1.HeaderText = "Operación"
        GridColumnDescriptor1.MappingName = "tipooper"
        GridColumnDescriptor1.Width = 184
        GridColumnDescriptor2.HeaderText = "Detalle"
        GridColumnDescriptor2.MappingName = "detalle"
        GridColumnDescriptor2.Width = 203
        GridColumnDescriptor3.HeaderText = "Total"
        GridColumnDescriptor3.MappingName = "montosoles"
        GridColumnDescriptor3.Width = 150
        Me.gridGroupingControl1.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3})
        Me.gridGroupingControl1.TableDescriptor.TableOptions.CaptionRowHeight = 22
        Me.gridGroupingControl1.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.gridGroupingControl1.TableDescriptor.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.None
        Me.gridGroupingControl1.TableDescriptor.TableOptions.ListBoxSelectionMode = System.Windows.Forms.SelectionMode.One
        Me.gridGroupingControl1.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.gridGroupingControl1.Text = "gridGroupingControl1"
        Me.gridGroupingControl1.UseRightToLeftCompatibleTextBox = True
        Me.gridGroupingControl1.VersionInfo = "12.1400.0.43"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label5.Location = New System.Drawing.Point(22, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(153, 20)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Resumen Fujo de caja"
        '
        'chartControl1
        '
        Me.chartControl1.BackInterior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(22, Byte), Integer)))
        Me.chartControl1.ChartArea.BackInterior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.Transparent)
        Me.chartControl1.ChartArea.CursorLocation = New System.Drawing.Point(0, 0)
        Me.chartControl1.ChartArea.CursorReDraw = False
        Me.chartControl1.ChartInterior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.Transparent)
        Me.chartControl1.CustomPalette = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(144, Byte), Integer), CType(CType(34, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(190, Byte), Integer), CType(CType(82, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(37, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(158, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(153, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(140, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(36, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(38, Byte), Integer))}
        Me.chartControl1.DataSourceName = "[none]"
        Me.chartControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.chartControl1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(182, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.chartControl1.IsWindowLess = False
        '
        '
        '
        Me.chartControl1.Legend.Location = New System.Drawing.Point(502, 30)
        Me.chartControl1.Legend.Visible = False
        Me.chartControl1.Localize = Nothing
        Me.chartControl1.Location = New System.Drawing.Point(0, 75)
        Me.chartControl1.Name = "chartControl1"
        Me.chartControl1.Palette = Syncfusion.Windows.Forms.Chart.ChartColorPalette.Custom
        Me.chartControl1.PrimaryXAxis.DrawGrid = False
        Me.chartControl1.PrimaryXAxis.GridLineType.ForeColor = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(182, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.chartControl1.PrimaryXAxis.LineType.ForeColor = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(182, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.chartControl1.PrimaryXAxis.LogLabelsDisplayMode = Syncfusion.Windows.Forms.Chart.LogLabelsDisplayMode.[Default]
        Me.chartControl1.PrimaryXAxis.Margin = True
        Me.chartControl1.PrimaryXAxis.TickColor = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(182, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.chartControl1.PrimaryXAxis.TitleColor = System.Drawing.SystemColors.ControlText
        Me.chartControl1.PrimaryYAxis.DrawGrid = False
        Me.chartControl1.PrimaryYAxis.GridLineType.ForeColor = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(182, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.chartControl1.PrimaryYAxis.LineType.ForeColor = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(182, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.chartControl1.PrimaryYAxis.LogLabelsDisplayMode = Syncfusion.Windows.Forms.Chart.LogLabelsDisplayMode.[Default]
        Me.chartControl1.PrimaryYAxis.Margin = True
        Me.chartControl1.PrimaryYAxis.TickColor = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(182, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.chartControl1.PrimaryYAxis.TitleColor = System.Drawing.SystemColors.ControlText
        ChartSeries1.FancyToolTip.ResizeInsideSymbol = True
        ChartSeries1.Name = "Default0"
        ChartSeries1.Points.Add(1.0R, CType(55.0R, Double))
        ChartSeries1.Points.Add(2.0R, CType(70.0R, Double))
        ChartSeries1.Points.Add(3.0R, CType(80.0R, Double))
        ChartSeries1.Points.Add(4.0R, CType(65.0R, Double))
        ChartSeries1.Points.Add(5.0R, CType(75.0R, Double))
        ChartSeries1.Resolution = 0R
        ChartSeries1.StackingGroup = "Default Group"
        ChartSeries1.Style.AltTagFormat = ""
        ChartSeries1.Style.DrawTextShape = False
        ChartSeries1.Style.Font.Facename = "Microsoft Sans Serif"
        ChartLineInfo1.Alignment = System.Drawing.Drawing2D.PenAlignment.Center
        ChartLineInfo1.Color = System.Drawing.SystemColors.ControlText
        ChartLineInfo1.DashPattern = Nothing
        ChartLineInfo1.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid
        ChartLineInfo1.Width = 1.0!
        ChartCustomShapeInfo1.Border = ChartLineInfo1
        ChartCustomShapeInfo1.Color = System.Drawing.SystemColors.HighlightText
        ChartCustomShapeInfo1.Type = Syncfusion.Windows.Forms.Chart.ChartCustomShape.Square
        ChartSeries1.Style.TextShape = ChartCustomShapeInfo1
        ChartSeries1.Text = "Default0"
        ChartSeries2.FancyToolTip.ResizeInsideSymbol = True
        ChartSeries2.Name = "Default1"
        ChartSeries2.Points.Add(1.0R, CType(70.0R, Double))
        ChartSeries2.Points.Add(2.0R, CType(35.0R, Double))
        ChartSeries2.Points.Add(3.0R, CType(65.0R, Double))
        ChartSeries2.Points.Add(4.0R, CType(25.0R, Double))
        ChartSeries2.Points.Add(5.0R, CType(50.0R, Double))
        ChartSeries2.Resolution = 0R
        ChartSeries2.StackingGroup = "Default Group"
        ChartSeries2.Style.AltTagFormat = ""
        ChartSeries2.Style.DrawTextShape = False
        ChartSeries2.Style.Font.Facename = "Microsoft Sans Serif"
        ChartCustomShapeInfo2.Border = ChartLineInfo1
        ChartCustomShapeInfo2.Color = System.Drawing.SystemColors.HighlightText
        ChartCustomShapeInfo2.Type = Syncfusion.Windows.Forms.Chart.ChartCustomShape.Square
        ChartSeries2.Style.TextShape = ChartCustomShapeInfo2
        ChartSeries2.Text = "Default1"
        Me.chartControl1.Series.Add(ChartSeries1)
        Me.chartControl1.Series.Add(ChartSeries2)
        Me.chartControl1.ShowToolbarInImage = False
        Me.chartControl1.ShowToolTips = True
        Me.chartControl1.Size = New System.Drawing.Size(1065, 332)
        Me.chartControl1.StyleDialogOptions.ShowInteriorTab = False
        Me.chartControl1.TabIndex = 0
        Me.chartControl1.Tilt = 10.0!
        '
        '
        '
        Me.chartControl1.Title.Name = "Default"
        Me.chartControl1.VisualTheme = ""
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(108, 55)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox3.TabIndex = 702
        Me.PictureBox3.TabStop = False
        '
        'pictureBox2
        '
        Me.pictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.pictureBox2.Image = CType(resources.GetObject("pictureBox2.Image"), System.Drawing.Image)
        Me.pictureBox2.Location = New System.Drawing.Point(62, 55)
        Me.pictureBox2.Name = "pictureBox2"
        Me.pictureBox2.Size = New System.Drawing.Size(40, 40)
        Me.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pictureBox2.TabIndex = 701
        Me.pictureBox2.TabStop = False
        '
        'pictureBox1
        '
        Me.pictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.pictureBox1.Image = CType(resources.GetObject("pictureBox1.Image"), System.Drawing.Image)
        Me.pictureBox1.Location = New System.Drawing.Point(15, 55)
        Me.pictureBox1.Name = "pictureBox1"
        Me.pictureBox1.Size = New System.Drawing.Size(40, 40)
        Me.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pictureBox1.TabIndex = 700
        Me.pictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Yu Gothic", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Silver
        Me.Label1.Location = New System.Drawing.Point(13, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 13)
        Me.Label1.TabIndex = 703
        Me.Label1.Text = "UNIDAD DE NEGOCIO"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(154, 55)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox4.TabIndex = 704
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Visible = False
        '
        'UCFlujoCajaGeneral
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.pictureBox2)
        Me.Controls.Add(Me.pictureBox1)
        Me.Controls.Add(Me.panel5)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.ComboUnidad)
        Me.Controls.Add(Me.BunifuThinButton23)
        Me.Controls.Add(Me.txtFechaLaboral)
        Me.Name = "UCFlujoCajaGeneral"
        Me.Size = New System.Drawing.Size(1107, 525)
        CType(Me.txtFechaLaboral, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboUnidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.panel5.ResumeLayout(False)
        Me.panel5.PerformLayout()
        CType(Me.gridGroupingControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BunifuThinButton23 As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents txtFechaLaboral As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents ComboUnidad As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Panel3 As Panel
    Friend WithEvents LabelTotalSaldo As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents LabelTotalGastos As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents LabelTotalVentas As Label
    Friend WithEvents Label8 As Label
    Private WithEvents panel5 As Panel
    Private WithEvents gridGroupingControl1 As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Private WithEvents Label5 As Label
    Private WithEvents chartControl1 As Syncfusion.Windows.Forms.Chart.ChartControl
    Private WithEvents PictureBox3 As PictureBox
    Private WithEvents pictureBox2 As PictureBox
    Private WithEvents pictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Private WithEvents PictureBox4 As PictureBox
End Class

Imports Syncfusion.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TabMG_Dashboard
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
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridSummaryRowDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor()
        Dim GridColumnDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor6 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor7 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor8 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridSummaryRowDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor()
        Dim ChartSeries1 As Syncfusion.Windows.Forms.Chart.ChartSeries = New Syncfusion.Windows.Forms.Chart.ChartSeries()
        Dim ChartCustomShapeInfo1 As Syncfusion.Windows.Forms.Chart.ChartCustomShapeInfo = New Syncfusion.Windows.Forms.Chart.ChartCustomShapeInfo()
        Dim ChartLineInfo1 As Syncfusion.Windows.Forms.Chart.ChartLineInfo = New Syncfusion.Windows.Forms.Chart.ChartLineInfo()
        Dim ChartSeries2 As Syncfusion.Windows.Forms.Chart.ChartSeries = New Syncfusion.Windows.Forms.Chart.ChartSeries()
        Dim ChartCustomShapeInfo2 As Syncfusion.Windows.Forms.Chart.ChartCustomShapeInfo = New Syncfusion.Windows.Forms.Chart.ChartCustomShapeInfo()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TabMG_Dashboard))
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextProveedor = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextNumIdentrazon = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.pnPrincipal = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.labelventaTotal = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TabControlAdv1 = New Syncfusion.Windows.Forms.Tools.TabControlAdv()
        Me.TabPageAdv4 = New Syncfusion.Windows.Forms.Tools.TabPageAdv()
        Me.gridServicios = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.TabPageAdv1 = New Syncfusion.Windows.Forms.Tools.TabPageAdv()
        Me.gridHabitaciones = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.gridEstadistica = New Syncfusion.Windows.Forms.Tools.TabPageAdv()
        Me.panel5 = New System.Windows.Forms.Panel()
        Me.chartControl1 = New Syncfusion.Windows.Forms.Chart.ChartControl()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.labelConteoHabPendiente = New System.Windows.Forms.Label()
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel()
        Me.labelConteoHabUso = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LinkLabel10 = New System.Windows.Forms.LinkLabel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.labelCtaXCobrar = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BunifuThinButton23 = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.LabelIngresosEspeciales = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.LabelTotalSaldo = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.LabelTotalGastos = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.labelAnticiposRecibidos = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.lblGarantiasRecibidas = New System.Windows.Forms.Label()
        Me.lblOtrosIngresos = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.lblAnticiposRecibidas = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblCuentasPorCobrar = New System.Windows.Forms.Label()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.btnConfirmar = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.BunifuFlatButton3 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.PictureLoad = New System.Windows.Forms.PictureBox()
        Me.pnBusqueda = New System.Windows.Forms.Panel()
        Me.labelEstado = New System.Windows.Forms.Label()
        Me.btnAceptar = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BunifuFlatButton2 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.BunifuFlatButton1 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.ComboEstable = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.BunifuFlatButton4 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.ComboBoxAdv2 = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.BgProveedor = New System.ComponentModel.BackgroundWorker()
        CType(Me.TextProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextNumIdentrazon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnPrincipal.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.TabControlAdv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlAdv1.SuspendLayout()
        Me.TabPageAdv4.SuspendLayout()
        CType(Me.gridServicios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPageAdv1.SuspendLayout()
        CType(Me.gridHabitaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gridEstadistica.SuspendLayout()
        Me.panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel9.SuspendLayout()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.PictureLoad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnBusqueda.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboEstable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboBoxAdv2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(30, 40)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Maroon
        Me.Label10.Location = New System.Drawing.Point(13, 10)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(153, 15)
        Me.Label10.TabIndex = 693
        Me.Label10.Text = "INFORMACION PERSONAL"
        '
        'TextProveedor
        '
        Me.TextProveedor.BackColor = System.Drawing.Color.White
        Me.TextProveedor.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TextProveedor.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextProveedor.CornerRadius = 3
        Me.TextProveedor.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextProveedor.Enabled = False
        Me.TextProveedor.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextProveedor.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextProveedor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextProveedor.Location = New System.Drawing.Point(111, 35)
        Me.TextProveedor.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextProveedor.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextProveedor.Name = "TextProveedor"
        Me.TextProveedor.Size = New System.Drawing.Size(336, 22)
        Me.TextProveedor.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextProveedor.TabIndex = 702
        '
        'TextNumIdentrazon
        '
        Me.TextNumIdentrazon.BackColor = System.Drawing.SystemColors.Info
        Me.TextNumIdentrazon.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TextNumIdentrazon.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextNumIdentrazon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextNumIdentrazon.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNumIdentrazon.CornerRadius = 3
        Me.TextNumIdentrazon.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextNumIdentrazon.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNumIdentrazon.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextNumIdentrazon.Location = New System.Drawing.Point(15, 35)
        Me.TextNumIdentrazon.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextNumIdentrazon.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextNumIdentrazon.Name = "TextNumIdentrazon"
        Me.TextNumIdentrazon.Size = New System.Drawing.Size(92, 23)
        Me.TextNumIdentrazon.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextNumIdentrazon.TabIndex = 698
        '
        'pnPrincipal
        '
        Me.pnPrincipal.BackColor = System.Drawing.Color.Black
        Me.pnPrincipal.Controls.Add(Me.Panel1)
        Me.pnPrincipal.Controls.Add(Me.GradientPanel1)
        Me.pnPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.pnPrincipal.Name = "pnPrincipal"
        Me.pnPrincipal.Size = New System.Drawing.Size(1055, 547)
        Me.pnPrincipal.TabIndex = 8
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.TabControlAdv1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.LinkLabel1)
        Me.Panel1.Controls.Add(Me.labelConteoHabPendiente)
        Me.Panel1.Controls.Add(Me.LinkLabel4)
        Me.Panel1.Controls.Add(Me.labelConteoHabUso)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.LinkLabel10)
        Me.Panel1.Controls.Add(Me.Panel6)
        Me.Panel1.Controls.Add(Me.LabelIngresosEspeciales)
        Me.Panel1.Controls.Add(Me.Panel7)
        Me.Panel1.Controls.Add(Me.Panel8)
        Me.Panel1.Controls.Add(Me.Panel9)
        Me.Panel1.Controls.Add(Me.lblGarantiasRecibidas)
        Me.Panel1.Controls.Add(Me.lblOtrosIngresos)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.LinkLabel2)
        Me.Panel1.Controls.Add(Me.LinkLabel3)
        Me.Panel1.Controls.Add(Me.lblAnticiposRecibidas)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.lblCuentasPorCobrar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 87)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1055, 460)
        Me.Panel1.TabIndex = 734
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(22, Byte), Integer))
        Me.Panel2.Controls.Add(Me.labelventaTotal)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Location = New System.Drawing.Point(16, 9)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(200, 77)
        Me.Panel2.TabIndex = 715
        '
        'labelventaTotal
        '
        Me.labelventaTotal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.labelventaTotal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labelventaTotal.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelventaTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(126, Byte), Integer))
        Me.labelventaTotal.Location = New System.Drawing.Point(0, 0)
        Me.labelventaTotal.Name = "labelventaTotal"
        Me.labelventaTotal.Size = New System.Drawing.Size(200, 51)
        Me.labelventaTotal.TabIndex = 56
        Me.labelventaTotal.Text = "S/0.00"
        Me.labelventaTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label7.Font = New System.Drawing.Font("Yu Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(0, 51)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(200, 26)
        Me.Label7.TabIndex = 691
        Me.Label7.Text = "Ventas"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabControlAdv1
        '
        Me.TabControlAdv1.ActiveTabColor = System.Drawing.Color.DarkOliveGreen
        Me.TabControlAdv1.BeforeTouchSize = New System.Drawing.Size(1024, 279)
        Me.TabControlAdv1.Controls.Add(Me.TabPageAdv4)
        Me.TabControlAdv1.Controls.Add(Me.TabPageAdv1)
        Me.TabControlAdv1.Controls.Add(Me.gridEstadistica)
        Me.TabControlAdv1.FocusOnTabClick = False
        Me.TabControlAdv1.Font = New System.Drawing.Font("Yu Gothic UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControlAdv1.InactiveTabColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.TabControlAdv1.ItemSize = New System.Drawing.Size(79, 22)
        Me.TabControlAdv1.Location = New System.Drawing.Point(16, 95)
        Me.TabControlAdv1.Name = "TabControlAdv1"
        Me.TabControlAdv1.Office2007ColorScheme = Syncfusion.Windows.Forms.Office2007Theme.Black
        Me.TabControlAdv1.Office2010ColorTheme = Syncfusion.Windows.Forms.Office2010Theme.Black
        Me.TabControlAdv1.Size = New System.Drawing.Size(1024, 279)
        Me.TabControlAdv1.TabIndex = 714
        Me.TabControlAdv1.TabStyle = GetType(Syncfusion.Windows.Forms.Tools.TabRendererBlendDark)
        '
        'TabPageAdv4
        '
        Me.TabPageAdv4.Controls.Add(Me.gridServicios)
        Me.TabPageAdv4.Image = Nothing
        Me.TabPageAdv4.ImageSize = New System.Drawing.Size(16, 16)
        Me.TabPageAdv4.Location = New System.Drawing.Point(1, 22)
        Me.TabPageAdv4.Name = "TabPageAdv4"
        Me.TabPageAdv4.ShowCloseButton = True
        Me.TabPageAdv4.Size = New System.Drawing.Size(1021, 255)
        Me.TabPageAdv4.TabFont = New System.Drawing.Font("Yu Gothic UI", 10.0!)
        Me.TabPageAdv4.TabIndex = 4
        Me.TabPageAdv4.Text = "General: Servicios"
        Me.TabPageAdv4.ThemesEnabled = False
        '
        'gridServicios
        '
        Me.gridServicios.BackColor = System.Drawing.Color.Black
        Me.gridServicios.ColorStyles = Syncfusion.Windows.Forms.ColorStyles.Office2010Black
        Me.gridServicios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridServicios.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridServicios.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gridServicios.FreezeCaption = False
        Me.gridServicios.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Office2010
        Me.gridServicios.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2010Black
        Me.gridServicios.Location = New System.Drawing.Point(0, 0)
        Me.gridServicios.Name = "gridServicios"
        Me.gridServicios.Office2010ScrollBarsColorScheme = Syncfusion.Windows.Forms.Office2010ColorScheme.Black
        Me.gridServicios.Size = New System.Drawing.Size(1021, 255)
        Me.gridServicios.TabIndex = 696
        Me.gridServicios.TableDescriptor.AllowNew = False
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.HeaderText = "N°"
        GridColumnDescriptor1.MappingName = "nro"
        GridColumnDescriptor1.Name = "nro"
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor1.Width = 60
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.MappingName = "descripcion"
        GridColumnDescriptor2.Name = "descripcion"
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor2.Width = 450
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.HeaderText = "Cantidad"
        GridColumnDescriptor3.MappingName = "cantidad"
        GridColumnDescriptor3.Name = "cantidad"
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor3.Width = 100
        GridColumnDescriptor4.Appearance.AnyRecordFieldCell.CellType = "PushButton"
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.MappingName = "ver"
        GridColumnDescriptor4.Name = "ver"
        GridColumnDescriptor4.SerializedImageArray = ""
        GridColumnDescriptor4.Width = 100
        Me.gridServicios.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4})
        GridSummaryRowDescriptor1.Appearance.AnySummaryCell.TextColor = System.Drawing.Color.Black
        GridSummaryRowDescriptor1.Name = "Row 1"
        GridSummaryRowDescriptor1.SummaryColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor("montosoles", Syncfusion.Grouping.SummaryType.DoubleAggregate, "montosoles", "{Sum}")})
        GridSummaryRowDescriptor1.Title = "Totales"
        Me.gridServicios.TableDescriptor.SummaryRows.Add(GridSummaryRowDescriptor1)
        Me.gridServicios.TableDescriptor.TableOptions.CaptionRowHeight = 22
        Me.gridServicios.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.gridServicios.TableDescriptor.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.None
        Me.gridServicios.TableDescriptor.TableOptions.ListBoxSelectionMode = System.Windows.Forms.SelectionMode.One
        Me.gridServicios.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.gridServicios.Text = "gridGroupingControl1"
        Me.gridServicios.VersionInfo = "12.1400.0.43"
        '
        'TabPageAdv1
        '
        Me.TabPageAdv1.Controls.Add(Me.gridHabitaciones)
        Me.TabPageAdv1.Image = Nothing
        Me.TabPageAdv1.ImageSize = New System.Drawing.Size(16, 16)
        Me.TabPageAdv1.Location = New System.Drawing.Point(1, 22)
        Me.TabPageAdv1.Name = "TabPageAdv1"
        Me.TabPageAdv1.ShowCloseButton = True
        Me.TabPageAdv1.Size = New System.Drawing.Size(1021, 255)
        Me.TabPageAdv1.TabFont = New System.Drawing.Font("Yu Gothic UI", 10.0!)
        Me.TabPageAdv1.TabIndex = 6
        Me.TabPageAdv1.Text = "Habitaciones"
        Me.TabPageAdv1.ThemesEnabled = False
        '
        'gridHabitaciones
        '
        Me.gridHabitaciones.BackColor = System.Drawing.Color.Black
        Me.gridHabitaciones.ColorStyles = Syncfusion.Windows.Forms.ColorStyles.Office2010Black
        Me.gridHabitaciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridHabitaciones.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridHabitaciones.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.gridHabitaciones.FreezeCaption = False
        Me.gridHabitaciones.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Office2010
        Me.gridHabitaciones.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2010Black
        Me.gridHabitaciones.Location = New System.Drawing.Point(0, 0)
        Me.gridHabitaciones.Name = "gridHabitaciones"
        Me.gridHabitaciones.Office2010ScrollBarsColorScheme = Syncfusion.Windows.Forms.Office2010ColorScheme.Black
        Me.gridHabitaciones.Size = New System.Drawing.Size(1021, 255)
        Me.gridHabitaciones.TabIndex = 697
        Me.gridHabitaciones.TableDescriptor.AllowNew = False
        GridColumnDescriptor5.HeaderImage = Nothing
        GridColumnDescriptor5.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor5.HeaderText = "N°"
        GridColumnDescriptor5.MappingName = "nro"
        GridColumnDescriptor5.Name = "nro"
        GridColumnDescriptor5.SerializedImageArray = ""
        GridColumnDescriptor5.Width = 60
        GridColumnDescriptor6.HeaderImage = Nothing
        GridColumnDescriptor6.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor6.MappingName = "descripcion"
        GridColumnDescriptor6.Name = "descripcion"
        GridColumnDescriptor6.SerializedImageArray = ""
        GridColumnDescriptor6.Width = 450
        GridColumnDescriptor7.HeaderImage = Nothing
        GridColumnDescriptor7.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor7.HeaderText = "Cantidad"
        GridColumnDescriptor7.MappingName = "cantidad"
        GridColumnDescriptor7.Name = "cantidad"
        GridColumnDescriptor7.SerializedImageArray = ""
        GridColumnDescriptor7.Width = 100
        GridColumnDescriptor8.Appearance.AnyRecordFieldCell.CellType = "PushButton"
        GridColumnDescriptor8.HeaderImage = Nothing
        GridColumnDescriptor8.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor8.MappingName = "ver"
        GridColumnDescriptor8.Name = "ver"
        GridColumnDescriptor8.SerializedImageArray = ""
        GridColumnDescriptor8.Width = 100
        Me.gridHabitaciones.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7, GridColumnDescriptor8})
        GridSummaryRowDescriptor2.Appearance.AnySummaryCell.TextColor = System.Drawing.Color.Black
        GridSummaryRowDescriptor2.Name = "Row 1"
        GridSummaryRowDescriptor2.SummaryColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor("montosoles", Syncfusion.Grouping.SummaryType.DoubleAggregate, "montosoles", "{Sum}")})
        GridSummaryRowDescriptor2.Title = "Totales"
        Me.gridHabitaciones.TableDescriptor.SummaryRows.Add(GridSummaryRowDescriptor2)
        Me.gridHabitaciones.TableDescriptor.TableOptions.CaptionRowHeight = 22
        Me.gridHabitaciones.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.gridHabitaciones.TableDescriptor.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.None
        Me.gridHabitaciones.TableDescriptor.TableOptions.ListBoxSelectionMode = System.Windows.Forms.SelectionMode.One
        Me.gridHabitaciones.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.gridHabitaciones.Text = "GridGroupingControl2"
        Me.gridHabitaciones.VersionInfo = "12.1400.0.43"
        '
        'gridEstadistica
        '
        Me.gridEstadistica.Controls.Add(Me.panel5)
        Me.gridEstadistica.Image = Nothing
        Me.gridEstadistica.ImageSize = New System.Drawing.Size(16, 16)
        Me.gridEstadistica.Location = New System.Drawing.Point(1, 22)
        Me.gridEstadistica.Name = "gridEstadistica"
        Me.gridEstadistica.ShowCloseButton = True
        Me.gridEstadistica.Size = New System.Drawing.Size(1021, 255)
        Me.gridEstadistica.TabFont = New System.Drawing.Font("Yu Gothic UI", 10.0!)
        Me.gridEstadistica.TabIndex = 5
        Me.gridEstadistica.Text = "Estadísticas"
        Me.gridEstadistica.ThemesEnabled = False
        '
        'panel5
        '
        Me.panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(22, Byte), Integer))
        Me.panel5.Controls.Add(Me.chartControl1)
        Me.panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panel5.Location = New System.Drawing.Point(0, 0)
        Me.panel5.Name = "panel5"
        Me.panel5.Size = New System.Drawing.Size(1021, 255)
        Me.panel5.TabIndex = 676
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
        Me.chartControl1.Dock = System.Windows.Forms.DockStyle.Left
        Me.chartControl1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(182, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.chartControl1.IsWindowLess = False
        '
        '
        '
        Me.chartControl1.Legend.Location = New System.Drawing.Point(502, 30)
        Me.chartControl1.Legend.Visible = False
        Me.chartControl1.Localize = Nothing
        Me.chartControl1.Location = New System.Drawing.Point(0, 0)
        Me.chartControl1.Name = "chartControl1"
        Me.chartControl1.Palette = Syncfusion.Windows.Forms.Chart.ChartColorPalette.Custom
        Me.chartControl1.PrimaryXAxis.Crossing = Double.NaN
        Me.chartControl1.PrimaryXAxis.DrawGrid = False
        Me.chartControl1.PrimaryXAxis.GridLineType.ForeColor = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(182, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.chartControl1.PrimaryXAxis.LineType.ForeColor = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(182, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.chartControl1.PrimaryXAxis.Margin = True
        Me.chartControl1.PrimaryXAxis.TickColor = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(182, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.chartControl1.PrimaryXAxis.TitleColor = System.Drawing.SystemColors.ControlText
        Me.chartControl1.PrimaryYAxis.Crossing = Double.NaN
        Me.chartControl1.PrimaryYAxis.DrawGrid = False
        Me.chartControl1.PrimaryYAxis.GridLineType.ForeColor = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(182, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.chartControl1.PrimaryYAxis.LineType.ForeColor = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(182, Byte), Integer), CType(CType(183, Byte), Integer))
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
        Me.chartControl1.Size = New System.Drawing.Size(701, 255)
        Me.chartControl1.StyleDialogOptions.ShowInteriorTab = False
        Me.chartControl1.TabIndex = 0
        Me.chartControl1.Tilt = 10.0!
        '
        '
        '
        Me.chartControl1.Title.Name = "Default"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.Location = New System.Drawing.Point(438, 107)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 19)
        Me.Label2.TabIndex = 713
        Me.Label2.Text = "Habitaciones"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.LinkLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel1.Location = New System.Drawing.Point(439, 153)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(137, 15)
        Me.LinkLabel1.TabIndex = 712
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Habitaciones pendientes"
        '
        'labelConteoHabPendiente
        '
        Me.labelConteoHabPendiente.AllowDrop = True
        Me.labelConteoHabPendiente.BackColor = System.Drawing.Color.Transparent
        Me.labelConteoHabPendiente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.labelConteoHabPendiente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.labelConteoHabPendiente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(8, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(135, Byte), Integer))
        Me.labelConteoHabPendiente.Location = New System.Drawing.Point(686, 150)
        Me.labelConteoHabPendiente.Name = "labelConteoHabPendiente"
        Me.labelConteoHabPendiente.Size = New System.Drawing.Size(134, 19)
        Me.labelConteoHabPendiente.TabIndex = 711
        Me.labelConteoHabPendiente.Text = "0"
        Me.labelConteoHabPendiente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LinkLabel4
        '
        Me.LinkLabel4.AutoSize = True
        Me.LinkLabel4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.LinkLabel4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.LinkLabel4.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel4.Location = New System.Drawing.Point(439, 129)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(114, 15)
        Me.LinkLabel4.TabIndex = 709
        Me.LinkLabel4.TabStop = True
        Me.LinkLabel4.Text = "Habitaciones en uso"
        '
        'labelConteoHabUso
        '
        Me.labelConteoHabUso.AllowDrop = True
        Me.labelConteoHabUso.BackColor = System.Drawing.Color.Transparent
        Me.labelConteoHabUso.Cursor = System.Windows.Forms.Cursors.Hand
        Me.labelConteoHabUso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.labelConteoHabUso.ForeColor = System.Drawing.Color.FromArgb(CType(CType(8, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(135, Byte), Integer))
        Me.labelConteoHabUso.Location = New System.Drawing.Point(686, 126)
        Me.labelConteoHabUso.Name = "labelConteoHabUso"
        Me.labelConteoHabUso.Size = New System.Drawing.Size(134, 19)
        Me.labelConteoHabUso.TabIndex = 707
        Me.labelConteoHabUso.Text = "0"
        Me.labelConteoHabUso.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label1.Location = New System.Drawing.Point(17, 107)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 19)
        Me.Label1.TabIndex = 675
        Me.Label1.Text = "Servicios"
        '
        'LinkLabel10
        '
        Me.LinkLabel10.AutoSize = True
        Me.LinkLabel10.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.LinkLabel10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel10.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel10.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel10.Location = New System.Drawing.Point(18, 153)
        Me.LinkLabel10.Name = "LinkLabel10"
        Me.LinkLabel10.Size = New System.Drawing.Size(162, 15)
        Me.LinkLabel10.TabIndex = 674
        Me.LinkLabel10.TabStop = True
        Me.LinkLabel10.Text = "Control de servicios ofrecidos"
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(22, Byte), Integer))
        Me.Panel6.Controls.Add(Me.labelCtaXCobrar)
        Me.Panel6.Controls.Add(Me.Label3)
        Me.Panel6.Controls.Add(Me.BunifuThinButton23)
        Me.Panel6.Location = New System.Drawing.Point(222, 9)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(200, 77)
        Me.Panel6.TabIndex = 702
        '
        'labelCtaXCobrar
        '
        Me.labelCtaXCobrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.labelCtaXCobrar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labelCtaXCobrar.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelCtaXCobrar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(126, Byte), Integer))
        Me.labelCtaXCobrar.Location = New System.Drawing.Point(0, 0)
        Me.labelCtaXCobrar.Name = "labelCtaXCobrar"
        Me.labelCtaXCobrar.Size = New System.Drawing.Size(200, 51)
        Me.labelCtaXCobrar.TabIndex = 56
        Me.labelCtaXCobrar.Text = "S/0.00"
        Me.labelCtaXCobrar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label3.Font = New System.Drawing.Font("Yu Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(0, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(200, 26)
        Me.Label3.TabIndex = 691
        Me.Label3.Text = "Cuentas por Cobrar"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BunifuThinButton23
        '
        Me.BunifuThinButton23.ActiveBorderThickness = 1
        Me.BunifuThinButton23.ActiveCornerRadius = 20
        Me.BunifuThinButton23.ActiveFillColor = System.Drawing.SystemColors.HotTrack
        Me.BunifuThinButton23.ActiveForecolor = System.Drawing.Color.White
        Me.BunifuThinButton23.ActiveLineColor = System.Drawing.SystemColors.HotTrack
        Me.BunifuThinButton23.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(22, Byte), Integer))
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
        Me.BunifuThinButton23.Location = New System.Drawing.Point(0, 0)
        Me.BunifuThinButton23.Margin = New System.Windows.Forms.Padding(4)
        Me.BunifuThinButton23.Name = "BunifuThinButton23"
        Me.BunifuThinButton23.Size = New System.Drawing.Size(83, 35)
        Me.BunifuThinButton23.TabIndex = 673
        Me.BunifuThinButton23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelIngresosEspeciales
        '
        Me.LabelIngresosEspeciales.AllowDrop = True
        Me.LabelIngresosEspeciales.BackColor = System.Drawing.Color.Transparent
        Me.LabelIngresosEspeciales.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LabelIngresosEspeciales.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.LabelIngresosEspeciales.ForeColor = System.Drawing.Color.FromArgb(CType(CType(8, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(135, Byte), Integer))
        Me.LabelIngresosEspeciales.Location = New System.Drawing.Point(265, 150)
        Me.LabelIngresosEspeciales.Name = "LabelIngresosEspeciales"
        Me.LabelIngresosEspeciales.Size = New System.Drawing.Size(134, 19)
        Me.LabelIngresosEspeciales.TabIndex = 673
        Me.LabelIngresosEspeciales.Text = "0"
        Me.LabelIngresosEspeciales.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(22, Byte), Integer))
        Me.Panel7.Controls.Add(Me.LabelTotalSaldo)
        Me.Panel7.Controls.Add(Me.Label5)
        Me.Panel7.Location = New System.Drawing.Point(840, 9)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(200, 77)
        Me.Panel7.TabIndex = 701
        '
        'LabelTotalSaldo
        '
        Me.LabelTotalSaldo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LabelTotalSaldo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelTotalSaldo.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTotalSaldo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(126, Byte), Integer))
        Me.LabelTotalSaldo.Location = New System.Drawing.Point(0, 0)
        Me.LabelTotalSaldo.Name = "LabelTotalSaldo"
        Me.LabelTotalSaldo.Size = New System.Drawing.Size(200, 51)
        Me.LabelTotalSaldo.TabIndex = 56
        Me.LabelTotalSaldo.Text = "S/0.00"
        Me.LabelTotalSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label5.Font = New System.Drawing.Font("Yu Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(0, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(200, 26)
        Me.Label5.TabIndex = 691
        Me.Label5.Text = "Compensaciones"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(22, Byte), Integer))
        Me.Panel8.Controls.Add(Me.LabelTotalGastos)
        Me.Panel8.Controls.Add(Me.Label19)
        Me.Panel8.Location = New System.Drawing.Point(634, 9)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(200, 77)
        Me.Panel8.TabIndex = 700
        '
        'LabelTotalGastos
        '
        Me.LabelTotalGastos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LabelTotalGastos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelTotalGastos.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTotalGastos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(126, Byte), Integer))
        Me.LabelTotalGastos.Location = New System.Drawing.Point(0, 0)
        Me.LabelTotalGastos.Name = "LabelTotalGastos"
        Me.LabelTotalGastos.Size = New System.Drawing.Size(200, 51)
        Me.LabelTotalGastos.TabIndex = 56
        Me.LabelTotalGastos.Text = "S/0.00"
        Me.LabelTotalGastos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label19
        '
        Me.Label19.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label19.Font = New System.Drawing.Font("Yu Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(0, 51)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(200, 26)
        Me.Label19.TabIndex = 691
        Me.Label19.Text = "Garantías Recibidas"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(22, Byte), Integer))
        Me.Panel9.Controls.Add(Me.labelAnticiposRecibidos)
        Me.Panel9.Controls.Add(Me.Label20)
        Me.Panel9.Location = New System.Drawing.Point(428, 9)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(200, 77)
        Me.Panel9.TabIndex = 699
        '
        'labelAnticiposRecibidos
        '
        Me.labelAnticiposRecibidos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.labelAnticiposRecibidos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.labelAnticiposRecibidos.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelAnticiposRecibidos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(126, Byte), Integer))
        Me.labelAnticiposRecibidos.Location = New System.Drawing.Point(0, 0)
        Me.labelAnticiposRecibidos.Name = "labelAnticiposRecibidos"
        Me.labelAnticiposRecibidos.Size = New System.Drawing.Size(200, 51)
        Me.labelAnticiposRecibidos.TabIndex = 56
        Me.labelAnticiposRecibidos.Text = "S/0.00"
        Me.labelAnticiposRecibidos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label20
        '
        Me.Label20.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label20.Font = New System.Drawing.Font("Yu Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(0, 51)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(200, 26)
        Me.Label20.TabIndex = 691
        Me.Label20.Text = "Anticipos Recibidos"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblGarantiasRecibidas
        '
        Me.lblGarantiasRecibidas.AllowDrop = True
        Me.lblGarantiasRecibidas.BackColor = System.Drawing.Color.Transparent
        Me.lblGarantiasRecibidas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblGarantiasRecibidas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.lblGarantiasRecibidas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(8, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(135, Byte), Integer))
        Me.lblGarantiasRecibidas.Location = New System.Drawing.Point(265, 221)
        Me.lblGarantiasRecibidas.Name = "lblGarantiasRecibidas"
        Me.lblGarantiasRecibidas.Size = New System.Drawing.Size(134, 19)
        Me.lblGarantiasRecibidas.TabIndex = 631
        Me.lblGarantiasRecibidas.Text = "0"
        Me.lblGarantiasRecibidas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblOtrosIngresos
        '
        Me.lblOtrosIngresos.AllowDrop = True
        Me.lblOtrosIngresos.BackColor = System.Drawing.Color.Transparent
        Me.lblOtrosIngresos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblOtrosIngresos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.lblOtrosIngresos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(8, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(135, Byte), Integer))
        Me.lblOtrosIngresos.Location = New System.Drawing.Point(265, 175)
        Me.lblOtrosIngresos.Name = "lblOtrosIngresos"
        Me.lblOtrosIngresos.Size = New System.Drawing.Size(134, 19)
        Me.lblOtrosIngresos.TabIndex = 641
        Me.lblOtrosIngresos.Text = "0"
        Me.lblOtrosIngresos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.AllowDrop = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label11.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(18, 222)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(214, 19)
        Me.Label11.TabIndex = 630
        Me.Label11.Text = "Proximo cumplimiento de atender"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.LinkLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.LinkLabel2.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel2.Location = New System.Drawing.Point(18, 129)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(162, 15)
        Me.LinkLabel2.TabIndex = 661
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Pedidos pendientes x atender"
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.LinkLabel3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel3.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LinkLabel3.Location = New System.Drawing.Point(18, 178)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(196, 15)
        Me.LinkLabel3.TabIndex = 662
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "Control de bienes en uso - (Entrega)"
        '
        'lblAnticiposRecibidas
        '
        Me.lblAnticiposRecibidas.AllowDrop = True
        Me.lblAnticiposRecibidas.BackColor = System.Drawing.Color.Transparent
        Me.lblAnticiposRecibidas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblAnticiposRecibidas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.lblAnticiposRecibidas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(8, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(135, Byte), Integer))
        Me.lblAnticiposRecibidas.Location = New System.Drawing.Point(265, 197)
        Me.lblAnticiposRecibidas.Name = "lblAnticiposRecibidas"
        Me.lblAnticiposRecibidas.Size = New System.Drawing.Size(134, 19)
        Me.lblAnticiposRecibidas.TabIndex = 633
        Me.lblAnticiposRecibidas.Text = "0"
        Me.lblAnticiposRecibidas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.AllowDrop = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label13.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(18, 198)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(229, 19)
        Me.Label13.TabIndex = 632
        Me.Label13.Text = "Control de bienes recepción - (Custodia)"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCuentasPorCobrar
        '
        Me.lblCuentasPorCobrar.AllowDrop = True
        Me.lblCuentasPorCobrar.BackColor = System.Drawing.Color.Transparent
        Me.lblCuentasPorCobrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblCuentasPorCobrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.lblCuentasPorCobrar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(8, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(135, Byte), Integer))
        Me.lblCuentasPorCobrar.Location = New System.Drawing.Point(265, 126)
        Me.lblCuentasPorCobrar.Name = "lblCuentasPorCobrar"
        Me.lblCuentasPorCobrar.Size = New System.Drawing.Size(134, 19)
        Me.lblCuentasPorCobrar.TabIndex = 635
        Me.lblCuentasPorCobrar.Text = "0"
        Me.lblCuentasPorCobrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BackColor = System.Drawing.Color.Black
        Me.GradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GradientPanel1.BorderColor = System.Drawing.Color.Silver
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GradientPanel1.Controls.Add(Me.btnConfirmar)
        Me.GradientPanel1.Controls.Add(Me.BunifuFlatButton3)
        Me.GradientPanel1.Controls.Add(Me.PictureLoad)
        Me.GradientPanel1.Controls.Add(Me.pnBusqueda)
        Me.GradientPanel1.Controls.Add(Me.BunifuFlatButton2)
        Me.GradientPanel1.Controls.Add(Me.Label16)
        Me.GradientPanel1.Controls.Add(Me.BunifuFlatButton1)
        Me.GradientPanel1.Controls.Add(Me.ComboEstable)
        Me.GradientPanel1.Controls.Add(Me.BunifuFlatButton4)
        Me.GradientPanel1.Controls.Add(Me.Label10)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(1055, 87)
        Me.GradientPanel1.TabIndex = 735
        '
        'btnConfirmar
        '
        Me.btnConfirmar.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.btnConfirmar.BeforeTouchSize = New System.Drawing.Size(99, 27)
        Me.btnConfirmar.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirmar.ForeColor = System.Drawing.Color.White
        Me.btnConfirmar.IsBackStageButton = False
        Me.btnConfirmar.Location = New System.Drawing.Point(266, 49)
        Me.btnConfirmar.Name = "btnConfirmar"
        Me.btnConfirmar.Size = New System.Drawing.Size(99, 27)
        Me.btnConfirmar.TabIndex = 735
        Me.btnConfirmar.Text = "CONSULTAR"
        Me.btnConfirmar.UseVisualStyle = True
        '
        'BunifuFlatButton3
        '
        Me.BunifuFlatButton3.Activecolor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(182, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.BunifuFlatButton3.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(182, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.BunifuFlatButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton3.BorderRadius = 5
        Me.BunifuFlatButton3.ButtonText = "LISTAR"
        Me.BunifuFlatButton3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton3.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton3.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BunifuFlatButton3.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton3.Iconimage = Nothing
        Me.BunifuFlatButton3.Iconimage_right = Nothing
        Me.BunifuFlatButton3.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton3.Iconimage_Selected = Nothing
        Me.BunifuFlatButton3.IconMarginLeft = 0
        Me.BunifuFlatButton3.IconMarginRight = 0
        Me.BunifuFlatButton3.IconRightVisible = True
        Me.BunifuFlatButton3.IconRightZoom = 0R
        Me.BunifuFlatButton3.IconVisible = True
        Me.BunifuFlatButton3.IconZoom = 90.0R
        Me.BunifuFlatButton3.IsTab = False
        Me.BunifuFlatButton3.Location = New System.Drawing.Point(352, 96)
        Me.BunifuFlatButton3.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton3.Name = "BunifuFlatButton3"
        Me.BunifuFlatButton3.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(182, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.BunifuFlatButton3.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(182, Byte), Integer), CType(CType(82, Byte), Integer))
        Me.BunifuFlatButton3.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton3.selected = False
        Me.BunifuFlatButton3.Size = New System.Drawing.Size(138, 23)
        Me.BunifuFlatButton3.TabIndex = 663
        Me.BunifuFlatButton3.Text = "LISTAR"
        Me.BunifuFlatButton3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton3.Textcolor = System.Drawing.Color.White
        Me.BunifuFlatButton3.TextFont = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'PictureLoad
        '
        Me.PictureLoad.BackColor = System.Drawing.Color.Transparent
        Me.PictureLoad.Image = CType(resources.GetObject("PictureLoad.Image"), System.Drawing.Image)
        Me.PictureLoad.Location = New System.Drawing.Point(492, 96)
        Me.PictureLoad.Name = "PictureLoad"
        Me.PictureLoad.Size = New System.Drawing.Size(22, 21)
        Me.PictureLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureLoad.TabIndex = 661
        Me.PictureLoad.TabStop = False
        Me.PictureLoad.Visible = False
        '
        'pnBusqueda
        '
        Me.pnBusqueda.BackColor = System.Drawing.Color.Transparent
        Me.pnBusqueda.Controls.Add(Me.labelEstado)
        Me.pnBusqueda.Controls.Add(Me.btnAceptar)
        Me.pnBusqueda.Controls.Add(Me.Label4)
        Me.pnBusqueda.Controls.Add(Me.TextProveedor)
        Me.pnBusqueda.Controls.Add(Me.TextNumIdentrazon)
        Me.pnBusqueda.Controls.Add(Me.PictureBox1)
        Me.pnBusqueda.Location = New System.Drawing.Point(297, 15)
        Me.pnBusqueda.Name = "pnBusqueda"
        Me.pnBusqueda.Size = New System.Drawing.Size(568, 65)
        Me.pnBusqueda.TabIndex = 733
        Me.pnBusqueda.Visible = False
        '
        'labelEstado
        '
        Me.labelEstado.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelEstado.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.labelEstado.Location = New System.Drawing.Point(357, 13)
        Me.labelEstado.Name = "labelEstado"
        Me.labelEstado.Size = New System.Drawing.Size(90, 19)
        Me.labelEstado.TabIndex = 736
        Me.labelEstado.Text = "Estado"
        '
        'btnAceptar
        '
        Me.btnAceptar.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btnAceptar.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.btnAceptar.BeforeTouchSize = New System.Drawing.Size(99, 27)
        Me.btnAceptar.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.ForeColor = System.Drawing.Color.White
        Me.btnAceptar.IsBackStageButton = False
        Me.btnAceptar.Location = New System.Drawing.Point(453, 30)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(99, 27)
        Me.btnAceptar.TabIndex = 734
        Me.btnAceptar.Text = "CONSULTAR"
        Me.btnAceptar.UseVisualStyle = True
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Image = CType(resources.GetObject("Label4.Image"), System.Drawing.Image)
        Me.Label4.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Label4.Location = New System.Drawing.Point(13, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 25)
        Me.Label4.TabIndex = 699
        Me.Label4.Text = "Identificar"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(111, 35)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(22, 21)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 706
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'BunifuFlatButton2
        '
        Me.BunifuFlatButton2.Activecolor = System.Drawing.Color.FromArgb(CType(CType(122, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(122, Byte), Integer))
        Me.BunifuFlatButton2.BackColor = System.Drawing.Color.FromArgb(CType(CType(122, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(122, Byte), Integer))
        Me.BunifuFlatButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton2.BorderRadius = 5
        Me.BunifuFlatButton2.ButtonText = "VER/EDITAR"
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
        Me.BunifuFlatButton2.Location = New System.Drawing.Point(128, 96)
        Me.BunifuFlatButton2.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton2.Name = "BunifuFlatButton2"
        Me.BunifuFlatButton2.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(122, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(122, Byte), Integer))
        Me.BunifuFlatButton2.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(122, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(122, Byte), Integer))
        Me.BunifuFlatButton2.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton2.selected = False
        Me.BunifuFlatButton2.Size = New System.Drawing.Size(108, 23)
        Me.BunifuFlatButton2.TabIndex = 29
        Me.BunifuFlatButton2.Text = "VER/EDITAR"
        Me.BunifuFlatButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton2.Textcolor = System.Drawing.Color.White
        Me.BunifuFlatButton2.TextFont = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(16, 36)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(98, 14)
        Me.Label16.TabIndex = 732
        Me.Label16.Text = "Unidad de negocio"
        '
        'BunifuFlatButton1
        '
        Me.BunifuFlatButton1.Activecolor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.BunifuFlatButton1.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.BunifuFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton1.BorderRadius = 5
        Me.BunifuFlatButton1.ButtonText = "ELIMINAR"
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
        Me.BunifuFlatButton1.Location = New System.Drawing.Point(240, 96)
        Me.BunifuFlatButton1.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton1.Name = "BunifuFlatButton1"
        Me.BunifuFlatButton1.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.BunifuFlatButton1.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.BunifuFlatButton1.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton1.selected = False
        Me.BunifuFlatButton1.Size = New System.Drawing.Size(108, 23)
        Me.BunifuFlatButton1.TabIndex = 28
        Me.BunifuFlatButton1.Text = "ELIMINAR"
        Me.BunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton1.Textcolor = System.Drawing.Color.White
        Me.BunifuFlatButton1.TextFont = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'ComboEstable
        '
        Me.ComboEstable.BackColor = System.Drawing.Color.White
        Me.ComboEstable.BeforeTouchSize = New System.Drawing.Size(244, 21)
        Me.ComboEstable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboEstable.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboEstable.Items.AddRange(New Object() {"GENERAL", "CLIENTE", "HUESPED", "TERCEROS"})
        Me.ComboEstable.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboEstable, "GENERAL"))
        Me.ComboEstable.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboEstable, "CLIENTE"))
        Me.ComboEstable.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboEstable, "HUESPED"))
        Me.ComboEstable.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboEstable, "TERCEROS"))
        Me.ComboEstable.Location = New System.Drawing.Point(16, 55)
        Me.ComboEstable.MetroBorderColor = System.Drawing.Color.Silver
        Me.ComboEstable.Name = "ComboEstable"
        Me.ComboEstable.Size = New System.Drawing.Size(244, 21)
        Me.ComboEstable.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboEstable.TabIndex = 730
        Me.ComboEstable.Text = "GENERAL"
        '
        'BunifuFlatButton4
        '
        Me.BunifuFlatButton4.Activecolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.BunifuFlatButton4.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.BunifuFlatButton4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton4.BorderRadius = 5
        Me.BunifuFlatButton4.ButtonText = "NUEVO"
        Me.BunifuFlatButton4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton4.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton4.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BunifuFlatButton4.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton4.Iconimage = Nothing
        Me.BunifuFlatButton4.Iconimage_right = Nothing
        Me.BunifuFlatButton4.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton4.Iconimage_Selected = Nothing
        Me.BunifuFlatButton4.IconMarginLeft = 0
        Me.BunifuFlatButton4.IconMarginRight = 0
        Me.BunifuFlatButton4.IconRightVisible = True
        Me.BunifuFlatButton4.IconRightZoom = 0R
        Me.BunifuFlatButton4.IconVisible = True
        Me.BunifuFlatButton4.IconZoom = 90.0R
        Me.BunifuFlatButton4.IsTab = False
        Me.BunifuFlatButton4.Location = New System.Drawing.Point(16, 96)
        Me.BunifuFlatButton4.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton4.Name = "BunifuFlatButton4"
        Me.BunifuFlatButton4.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.BunifuFlatButton4.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.BunifuFlatButton4.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton4.selected = False
        Me.BunifuFlatButton4.Size = New System.Drawing.Size(108, 23)
        Me.BunifuFlatButton4.TabIndex = 27
        Me.BunifuFlatButton4.Text = "NUEVO"
        Me.BunifuFlatButton4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton4.Textcolor = System.Drawing.Color.White
        Me.BunifuFlatButton4.TextFont = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'ComboBoxAdv2
        '
        Me.ComboBoxAdv2.BackColor = System.Drawing.Color.White
        Me.ComboBoxAdv2.BeforeTouchSize = New System.Drawing.Size(121, 21)
        Me.ComboBoxAdv2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxAdv2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxAdv2.Location = New System.Drawing.Point(5, 31)
        Me.ComboBoxAdv2.Name = "ComboBoxAdv2"
        Me.ComboBoxAdv2.Size = New System.Drawing.Size(121, 21)
        Me.ComboBoxAdv2.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboBoxAdv2.TabIndex = 1
        '
        'BgProveedor
        '
        Me.BgProveedor.WorkerSupportsCancellation = True
        '
        'TabMG_Dashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.Controls.Add(Me.pnPrincipal)
        Me.Name = "TabMG_Dashboard"
        Me.Size = New System.Drawing.Size(1055, 547)
        CType(Me.TextProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextNumIdentrazon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnPrincipal.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.TabControlAdv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlAdv1.ResumeLayout(False)
        Me.TabPageAdv4.ResumeLayout(False)
        CType(Me.gridServicios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPageAdv1.ResumeLayout(False)
        CType(Me.gridHabitaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gridEstadistica.ResumeLayout(False)
        Me.panel5.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        CType(Me.PictureLoad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnBusqueda.ResumeLayout(False)
        Me.pnBusqueda.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboEstable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboBoxAdv2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents Label10 As Label
    Friend WithEvents TextProveedor As Tools.TextBoxExt
    Friend WithEvents TextNumIdentrazon As Tools.TextBoxExt
    Friend WithEvents Label4 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents pnPrincipal As Panel
    Friend WithEvents BgProveedor As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label16 As Label
    Friend WithEvents ComboEstable As Tools.ComboBoxAdv
    Friend WithEvents pnBusqueda As Panel
    Friend WithEvents btnAceptar As ButtonAdv
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GradientPanel1 As Tools.GradientPanel
    Private WithEvents BunifuFlatButton3 As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents PictureLoad As PictureBox
    Private WithEvents BunifuFlatButton2 As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents BunifuFlatButton1 As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents BunifuFlatButton4 As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents ComboBoxAdv2 As Tools.ComboBoxAdv
    Friend WithEvents Label1 As Label
    Friend WithEvents LinkLabel10 As LinkLabel
    Friend WithEvents LabelIngresosEspeciales As Label
    Friend WithEvents lblGarantiasRecibidas As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents lblAnticiposRecibidas As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents lblCuentasPorCobrar As Label
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents lblOtrosIngresos As Label
    Friend WithEvents btnConfirmar As ButtonAdv
    Friend WithEvents Panel6 As Panel
    Friend WithEvents labelCtaXCobrar As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents BunifuThinButton23 As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents Panel7 As Panel
    Friend WithEvents LabelTotalSaldo As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel8 As Panel
    Friend WithEvents LabelTotalGastos As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Panel9 As Panel
    Friend WithEvents labelAnticiposRecibidos As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents labelConteoHabPendiente As Label
    Friend WithEvents LinkLabel4 As LinkLabel
    Friend WithEvents labelConteoHabUso As Label
    Friend WithEvents labelEstado As Label
    Friend WithEvents TabControlAdv1 As Tools.TabControlAdv
    Friend WithEvents TabPageAdv4 As Tools.TabPageAdv
    Private WithEvents gridServicios As Grid.Grouping.GridGroupingControl
    Friend WithEvents gridEstadistica As Tools.TabPageAdv
    Private WithEvents panel5 As Panel
    Private WithEvents chartControl1 As Chart.ChartControl
    Friend WithEvents Panel2 As Panel
    Friend WithEvents labelventaTotal As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents TabPageAdv1 As Tools.TabPageAdv
    Private WithEvents gridHabitaciones As Grid.Grouping.GridGroupingControl
End Class

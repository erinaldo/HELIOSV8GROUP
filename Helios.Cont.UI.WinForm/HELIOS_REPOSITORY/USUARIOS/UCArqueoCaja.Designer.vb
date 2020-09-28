<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCArqueoCaja
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCArqueoCaja))
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ComboUsuarios = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ListViewHistorialCajas = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextAnio = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.cboMesCompra = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.BunifuThinButton21 = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.LabelTotalSaldo = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LabelTotalSaldoUSD = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.LabelFechaInicio = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TxtCajero = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TxtResponsable = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.lblIdCierre = New System.Windows.Forms.Label()
        Me.GridCajas = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.LabelFecha = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LabelFondoInicioUSD = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LabelFondoInicio = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LabelTotalGastosUSD = New System.Windows.Forms.Label()
        Me.LabelTotalGastos = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.LabelTotalVentasUSD = New System.Windows.Forms.Label()
        Me.LabelTotalVentas = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        CType(Me.ComboUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        CType(Me.TextAnio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboMesCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.TxtCajero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtResponsable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridCajas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label4.Location = New System.Drawing.Point(33, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Cajeros"
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(266, 95)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(39, 25)
        Me.Button1.TabIndex = 30
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ComboUsuarios
        '
        Me.ComboUsuarios.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.ComboUsuarios.BeforeTouchSize = New System.Drawing.Size(323, 21)
        Me.ComboUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboUsuarios.FlatBorderColor = System.Drawing.Color.Gray
        Me.ComboUsuarios.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboUsuarios.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.ComboUsuarios.Location = New System.Drawing.Point(35, 40)
        Me.ComboUsuarios.Name = "ComboUsuarios"
        Me.ComboUsuarios.Size = New System.Drawing.Size(323, 21)
        Me.ComboUsuarios.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Black
        Me.ComboUsuarios.TabIndex = 29
        '
        'GradientPanel2
        '
        Me.GradientPanel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GradientPanel2.BorderColor = System.Drawing.Color.Silver
        Me.GradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel2.Controls.Add(Me.ListViewHistorialCajas)
        Me.GradientPanel2.Location = New System.Drawing.Point(35, 160)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(369, 354)
        Me.GradientPanel2.TabIndex = 28
        '
        'ListViewHistorialCajas
        '
        Me.ListViewHistorialCajas.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(22, Byte), Integer))
        Me.ListViewHistorialCajas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListViewHistorialCajas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6})
        Me.ListViewHistorialCajas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListViewHistorialCajas.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.ListViewHistorialCajas.FullRowSelect = True
        Me.ListViewHistorialCajas.HideSelection = False
        Me.ListViewHistorialCajas.Location = New System.Drawing.Point(0, 0)
        Me.ListViewHistorialCajas.Name = "ListViewHistorialCajas"
        Me.ListViewHistorialCajas.Size = New System.Drawing.Size(367, 352)
        Me.ListViewHistorialCajas.TabIndex = 16
        Me.ListViewHistorialCajas.UseCompatibleStateImageBehavior = False
        Me.ListViewHistorialCajas.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Fecha registro"
        Me.ColumnHeader2.Width = 144
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Fecha cierre"
        Me.ColumnHeader3.Width = 141
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Estado"
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Gastos"
        Me.ColumnHeader5.Width = 0
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Saldo"
        Me.ColumnHeader6.Width = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label2.Location = New System.Drawing.Point(32, 138)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(139, 13)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Cierres Sin Rendir Cuentas"
        '
        'TextAnio
        '
        Me.TextAnio.AllowNull = True
        Me.TextAnio.BackGroundColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TextAnio.BeforeTouchSize = New System.Drawing.Size(69, 25)
        Me.TextAnio.BorderColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TextAnio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextAnio.CornerRadius = 4
        Me.TextAnio.CurrencyDecimalDigits = 0
        Me.TextAnio.CurrencyGroupSeparator = ""
        Me.TextAnio.CurrencySymbol = ""
        Me.TextAnio.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TextAnio.DecimalValue = New Decimal(New Integer() {2019, 0, 0, 0})
        Me.TextAnio.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextAnio.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.TextAnio.Location = New System.Drawing.Point(191, 95)
        Me.TextAnio.MaxValue = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.TextAnio.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TextAnio.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextAnio.Name = "TextAnio"
        Me.TextAnio.NegativeColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.TextAnio.NullString = ""
        Me.TextAnio.PositiveColor = System.Drawing.Color.WhiteSmoke
        Me.TextAnio.ReadOnlyBackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextAnio.Size = New System.Drawing.Size(69, 25)
        Me.TextAnio.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.TextAnio.TabIndex = 26
        Me.TextAnio.Text = "2019"
        Me.TextAnio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cboMesCompra
        '
        Me.cboMesCompra.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.cboMesCompra.BeforeTouchSize = New System.Drawing.Size(151, 21)
        Me.cboMesCompra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMesCompra.FlatBorderColor = System.Drawing.Color.Gray
        Me.cboMesCompra.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMesCompra.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.cboMesCompra.Location = New System.Drawing.Point(35, 98)
        Me.cboMesCompra.Name = "cboMesCompra"
        Me.cboMesCompra.Size = New System.Drawing.Size(151, 21)
        Me.cboMesCompra.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Black
        Me.cboMesCompra.TabIndex = 25
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(32, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Período/mes"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label6.Location = New System.Drawing.Point(34, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 13)
        Me.Label6.TabIndex = 709
        Me.Label6.Text = "Responsable"
        '
        'BunifuThinButton21
        '
        Me.BunifuThinButton21.ActiveBorderThickness = 1
        Me.BunifuThinButton21.ActiveCornerRadius = 20
        Me.BunifuThinButton21.ActiveFillColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.BunifuThinButton21.ActiveForecolor = System.Drawing.Color.White
        Me.BunifuThinButton21.ActiveLineColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.BunifuThinButton21.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.BunifuThinButton21.BackgroundImage = CType(resources.GetObject("BunifuThinButton21.BackgroundImage"), System.Drawing.Image)
        Me.BunifuThinButton21.ButtonText = "CONFIRMAR"
        Me.BunifuThinButton21.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuThinButton21.Font = New System.Drawing.Font("Yu Gothic UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuThinButton21.ForeColor = System.Drawing.Color.White
        Me.BunifuThinButton21.IdleBorderThickness = 1
        Me.BunifuThinButton21.IdleCornerRadius = 20
        Me.BunifuThinButton21.IdleFillColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.BunifuThinButton21.IdleForecolor = System.Drawing.Color.White
        Me.BunifuThinButton21.IdleLineColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.BunifuThinButton21.Location = New System.Drawing.Point(231, 355)
        Me.BunifuThinButton21.Margin = New System.Windows.Forms.Padding(4)
        Me.BunifuThinButton21.Name = "BunifuThinButton21"
        Me.BunifuThinButton21.Size = New System.Drawing.Size(85, 37)
        Me.BunifuThinButton21.TabIndex = 711
        Me.BunifuThinButton21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelTotalSaldo
        '
        Me.LabelTotalSaldo.AutoSize = True
        Me.LabelTotalSaldo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LabelTotalSaldo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTotalSaldo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LabelTotalSaldo.Location = New System.Drawing.Point(147, 277)
        Me.LabelTotalSaldo.Name = "LabelTotalSaldo"
        Me.LabelTotalSaldo.Size = New System.Drawing.Size(57, 21)
        Me.LabelTotalSaldo.TabIndex = 702
        Me.LabelTotalSaldo.Text = "S/0.00"
        Me.LabelTotalSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Yu Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Yellow
        Me.Label5.Location = New System.Drawing.Point(34, 281)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 18)
        Me.Label5.TabIndex = 703
        Me.Label5.Text = "Importe Soles"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelTotalSaldoUSD
        '
        Me.LabelTotalSaldoUSD.AutoSize = True
        Me.LabelTotalSaldoUSD.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LabelTotalSaldoUSD.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTotalSaldoUSD.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LabelTotalSaldoUSD.Location = New System.Drawing.Point(359, 275)
        Me.LabelTotalSaldoUSD.Name = "LabelTotalSaldoUSD"
        Me.LabelTotalSaldoUSD.Size = New System.Drawing.Size(50, 21)
        Me.LabelTotalSaldoUSD.TabIndex = 707
        Me.LabelTotalSaldoUSD.Text = "$0.00"
        Me.LabelTotalSaldoUSD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Yu Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(229, 278)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 18)
        Me.Label3.TabIndex = 708
        Me.Label3.Text = "Importe Dolares"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.LabelFechaInicio)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.TxtCajero)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.TxtResponsable)
        Me.GroupBox1.Controls.Add(Me.lblIdCierre)
        Me.GroupBox1.Controls.Add(Me.GridCajas)
        Me.GroupBox1.Controls.Add(Me.LabelFecha)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.BunifuThinButton21)
        Me.GroupBox1.Controls.Add(Me.LabelTotalSaldo)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.LabelTotalSaldoUSD)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(443, 19)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(521, 494)
        Me.GroupBox1.TabIndex = 712
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Resumen De Arqueo"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(33, 219)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(157, 21)
        Me.Label13.TabIndex = 721
        Me.Label13.Text = "MONTOS A RECIBIR"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelFechaInicio
        '
        Me.LabelFechaInicio.AutoSize = True
        Me.LabelFechaInicio.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LabelFechaInicio.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelFechaInicio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LabelFechaInicio.Location = New System.Drawing.Point(39, 170)
        Me.LabelFechaInicio.Name = "LabelFechaInicio"
        Me.LabelFechaInicio.Size = New System.Drawing.Size(16, 21)
        Me.LabelFechaInicio.TabIndex = 720
        Me.LabelFechaInicio.Text = "-"
        Me.LabelFechaInicio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label14.Location = New System.Drawing.Point(34, 142)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(66, 13)
        Me.Label14.TabIndex = 719
        Me.Label14.Text = "Fecha Inicio"
        '
        'TxtCajero
        '
        Me.TxtCajero.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TxtCajero.BeforeTouchSize = New System.Drawing.Size(69, 25)
        Me.TxtCajero.BorderColor = System.Drawing.Color.DimGray
        Me.TxtCajero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCajero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCajero.CornerRadius = 4
        Me.TxtCajero.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TxtCajero.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCajero.ForeColor = System.Drawing.Color.White
        Me.TxtCajero.Location = New System.Drawing.Point(37, 109)
        Me.TxtCajero.Metrocolor = System.Drawing.Color.LightGray
        Me.TxtCajero.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TxtCajero.Name = "TxtCajero"
        Me.TxtCajero.ReadOnly = True
        Me.TxtCajero.Size = New System.Drawing.Size(468, 22)
        Me.TxtCajero.TabIndex = 718
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label11.Location = New System.Drawing.Point(34, 87)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(40, 13)
        Me.Label11.TabIndex = 717
        Me.Label11.Text = "Cajero"
        '
        'TxtResponsable
        '
        Me.TxtResponsable.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TxtResponsable.BeforeTouchSize = New System.Drawing.Size(69, 25)
        Me.TxtResponsable.BorderColor = System.Drawing.Color.DimGray
        Me.TxtResponsable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtResponsable.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtResponsable.CornerRadius = 4
        Me.TxtResponsable.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TxtResponsable.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtResponsable.ForeColor = System.Drawing.Color.White
        Me.TxtResponsable.Location = New System.Drawing.Point(37, 51)
        Me.TxtResponsable.Metrocolor = System.Drawing.Color.LightGray
        Me.TxtResponsable.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TxtResponsable.Name = "TxtResponsable"
        Me.TxtResponsable.ReadOnly = True
        Me.TxtResponsable.Size = New System.Drawing.Size(468, 22)
        Me.TxtResponsable.TabIndex = 716
        '
        'lblIdCierre
        '
        Me.lblIdCierre.AutoSize = True
        Me.lblIdCierre.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblIdCierre.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdCierre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblIdCierre.Location = New System.Drawing.Point(426, 170)
        Me.lblIdCierre.Name = "lblIdCierre"
        Me.lblIdCierre.Size = New System.Drawing.Size(19, 21)
        Me.lblIdCierre.TabIndex = 715
        Me.lblIdCierre.Text = "0"
        Me.lblIdCierre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblIdCierre.Visible = False
        '
        'GridCajas
        '
        Me.GridCajas.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.GridCajas.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        Me.GridCajas.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.GridCajas.BackColor = System.Drawing.Color.Black
        Me.GridCajas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GridCajas.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridCajas.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.GridCajas.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2010Black
        Me.GridCajas.Location = New System.Drawing.Point(537, 120)
        Me.GridCajas.Name = "GridCajas"
        Me.GridCajas.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.GridCajas.Size = New System.Drawing.Size(468, 148)
        Me.GridCajas.TabIndex = 714
        Me.GridCajas.TableDescriptor.AllowNew = False
        GridColumnDescriptor1.HeaderText = "idCaja"
        GridColumnDescriptor1.MappingName = "idCaja"
        GridColumnDescriptor1.ReadOnly = True
        GridColumnDescriptor1.Width = 101
        GridColumnDescriptor2.HeaderText = "idEntidad"
        GridColumnDescriptor2.MappingName = "idEntidad"
        GridColumnDescriptor2.ReadOnly = True
        GridColumnDescriptor2.Width = 52
        GridColumnDescriptor3.MappingName = "entidad"
        GridColumnDescriptor3.Width = 80
        Me.GridCajas.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3})
        Me.GridCajas.TableDescriptor.TableOptions.CaptionRowHeight = 29
        Me.GridCajas.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.GridCajas.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.GridCajas.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("idCaja"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("idEntidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("entidad")})
        Me.GridCajas.Text = "gridGroupingControl1"
        Me.GridCajas.UseRightToLeftCompatibleTextBox = True
        Me.GridCajas.VersionInfo = "12.2400.0.20"
        Me.GridCajas.Visible = False
        '
        'LabelFecha
        '
        Me.LabelFecha.AutoSize = True
        Me.LabelFecha.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LabelFecha.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelFecha.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LabelFecha.Location = New System.Drawing.Point(237, 170)
        Me.LabelFecha.Name = "LabelFecha"
        Me.LabelFecha.Size = New System.Drawing.Size(16, 21)
        Me.LabelFecha.TabIndex = 713
        Me.LabelFecha.Text = "-"
        Me.LabelFecha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label7.Location = New System.Drawing.Point(230, 143)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 13)
        Me.Label7.TabIndex = 712
        Me.Label7.Text = "Fecha Cierre"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Yu Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(161, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(753, 175)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(136, 18)
        Me.Label8.TabIndex = 719
        Me.Label8.Text = "Fondo de inicio Usd"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label8.Visible = False
        '
        'LabelFondoInicioUSD
        '
        Me.LabelFondoInicioUSD.AutoSize = True
        Me.LabelFondoInicioUSD.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LabelFondoInicioUSD.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelFondoInicioUSD.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LabelFondoInicioUSD.Location = New System.Drawing.Point(902, 172)
        Me.LabelFondoInicioUSD.Name = "LabelFondoInicioUSD"
        Me.LabelFondoInicioUSD.Size = New System.Drawing.Size(50, 21)
        Me.LabelFondoInicioUSD.TabIndex = 718
        Me.LabelFondoInicioUSD.Text = "$0.00"
        Me.LabelFondoInicioUSD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LabelFondoInicioUSD.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Yu Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(161, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(558, 178)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(107, 18)
        Me.Label9.TabIndex = 714
        Me.Label9.Text = "Fondo de inicio"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label9.Visible = False
        '
        'LabelFondoInicio
        '
        Me.LabelFondoInicio.AutoSize = True
        Me.LabelFondoInicio.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LabelFondoInicio.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelFondoInicio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LabelFondoInicio.Location = New System.Drawing.Point(671, 174)
        Me.LabelFondoInicio.Name = "LabelFondoInicio"
        Me.LabelFondoInicio.Size = New System.Drawing.Size(57, 21)
        Me.LabelFondoInicio.TabIndex = 713
        Me.LabelFondoInicio.Text = "S/0.00"
        Me.LabelFondoInicio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LabelFondoInicio.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(22, Byte), Integer))
        Me.Panel1.Controls.Add(Me.LabelTotalGastosUSD)
        Me.Panel1.Controls.Add(Me.LabelTotalGastos)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Location = New System.Drawing.Point(751, 200)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(201, 99)
        Me.Panel1.TabIndex = 716
        Me.Panel1.Visible = False
        '
        'LabelTotalGastosUSD
        '
        Me.LabelTotalGastosUSD.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LabelTotalGastosUSD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelTotalGastosUSD.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTotalGastosUSD.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LabelTotalGastosUSD.Location = New System.Drawing.Point(0, 37)
        Me.LabelTotalGastosUSD.Name = "LabelTotalGastosUSD"
        Me.LabelTotalGastosUSD.Size = New System.Drawing.Size(201, 36)
        Me.LabelTotalGastosUSD.TabIndex = 693
        Me.LabelTotalGastosUSD.Text = "$0.00"
        Me.LabelTotalGastosUSD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelTotalGastos
        '
        Me.LabelTotalGastos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LabelTotalGastos.Dock = System.Windows.Forms.DockStyle.Top
        Me.LabelTotalGastos.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTotalGastos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LabelTotalGastos.Location = New System.Drawing.Point(0, 0)
        Me.LabelTotalGastos.Name = "LabelTotalGastos"
        Me.LabelTotalGastos.Size = New System.Drawing.Size(201, 37)
        Me.LabelTotalGastos.TabIndex = 56
        Me.LabelTotalGastos.Text = "S/0.00"
        Me.LabelTotalGastos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label10.Font = New System.Drawing.Font("Yu Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Silver
        Me.Label10.Location = New System.Drawing.Point(0, 73)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(201, 26)
        Me.Label10.TabIndex = 691
        Me.Label10.Text = "Total Gastos "
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(22, Byte), Integer))
        Me.Panel2.Controls.Add(Me.LabelTotalVentasUSD)
        Me.Panel2.Controls.Add(Me.LabelTotalVentas)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Location = New System.Drawing.Point(549, 200)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(195, 99)
        Me.Panel2.TabIndex = 715
        Me.Panel2.Visible = False
        '
        'LabelTotalVentasUSD
        '
        Me.LabelTotalVentasUSD.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LabelTotalVentasUSD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelTotalVentasUSD.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTotalVentasUSD.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LabelTotalVentasUSD.Location = New System.Drawing.Point(0, 37)
        Me.LabelTotalVentasUSD.Name = "LabelTotalVentasUSD"
        Me.LabelTotalVentasUSD.Size = New System.Drawing.Size(195, 36)
        Me.LabelTotalVentasUSD.TabIndex = 692
        Me.LabelTotalVentasUSD.Text = "$0.00"
        Me.LabelTotalVentasUSD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelTotalVentas
        '
        Me.LabelTotalVentas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LabelTotalVentas.Dock = System.Windows.Forms.DockStyle.Top
        Me.LabelTotalVentas.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTotalVentas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LabelTotalVentas.Location = New System.Drawing.Point(0, 0)
        Me.LabelTotalVentas.Name = "LabelTotalVentas"
        Me.LabelTotalVentas.Size = New System.Drawing.Size(195, 37)
        Me.LabelTotalVentas.TabIndex = 56
        Me.LabelTotalVentas.Text = "S/0.00"
        Me.LabelTotalVentas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label12.Font = New System.Drawing.Font("Yu Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Silver
        Me.Label12.Location = New System.Drawing.Point(0, 73)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(195, 26)
        Me.Label12.TabIndex = 691
        Me.Label12.Text = "Ventas e ingresos"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button2
        '
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(364, 36)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(39, 25)
        Me.Button2.TabIndex = 720
        Me.Button2.UseVisualStyleBackColor = True
        '
        'UCArqueoCaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.LabelFondoInicioUSD)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.LabelFondoInicio)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ComboUsuarios)
        Me.Controls.Add(Me.GradientPanel2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextAnio)
        Me.Controls.Add(Me.cboMesCompra)
        Me.Controls.Add(Me.Label1)
        Me.Name = "UCArqueoCaja"
        Me.Size = New System.Drawing.Size(994, 526)
        CType(Me.ComboUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        CType(Me.TextAnio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboMesCompra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.TxtCajero, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtResponsable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridCajas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label4 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents ComboUsuarios As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents GradientPanel2 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents ListViewHistorialCajas As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents Label2 As Label
    Friend WithEvents TextAnio As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents cboMesCompra As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label1 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents BunifuThinButton21 As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents LabelTotalSaldo As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents LabelTotalSaldoUSD As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents LabelFecha As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents LabelFondoInicioUSD As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents LabelFondoInicio As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents LabelTotalGastosUSD As Label
    Friend WithEvents LabelTotalGastos As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents LabelTotalVentasUSD As Label
    Friend WithEvents LabelTotalVentas As Label
    Friend WithEvents Label12 As Label
    Private WithEvents GridCajas As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents lblIdCierre As Label
    Friend WithEvents TxtResponsable As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents LabelFechaInicio As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents TxtCajero As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label11 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Button2 As Button
End Class

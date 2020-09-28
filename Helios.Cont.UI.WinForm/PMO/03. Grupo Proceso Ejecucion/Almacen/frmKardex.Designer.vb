<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKardex
    Inherits Helios.Cont.Presentation.WinForm.frmMaster

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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
        Dim ActiveStateCollection1 As Syncfusion.Windows.Forms.Tools.ActiveStateCollection = New Syncfusion.Windows.Forms.Tools.ActiveStateCollection()
        Dim InactiveStateCollection1 As Syncfusion.Windows.Forms.Tools.InactiveStateCollection = New Syncfusion.Windows.Forms.Tools.InactiveStateCollection()
        Dim ToggleButtonRenderer1 As Syncfusion.Windows.Forms.Tools.ToggleButtonRenderer = New Syncfusion.Windows.Forms.Tools.ToggleButtonRenderer()
        Dim SliderCollection1 As Syncfusion.Windows.Forms.Tools.SliderCollection = New Syncfusion.Windows.Forms.Tools.SliderCollection()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmKardex))
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor6 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor7 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor8 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor9 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor10 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor11 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor12 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor13 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor14 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor15 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor16 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridStackedHeaderRowDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderRowDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderRowDescriptor()
        Dim GridStackedHeaderDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor()
        Dim GridStackedHeaderDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor()
        Dim GridSummaryRowDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor()
        Dim GridSummaryColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor()
        Dim GridSummaryColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStrip4 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.lblProducto = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.lblCanDisponible = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel()
        Me.lblUnidad = New System.Windows.Forms.ToolStripLabel()
        Me.cboPeriodo = New System.Windows.Forms.ToolStripComboBox()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.tbIGV = New Syncfusion.Windows.Forms.Tools.ToggleButton()
        Me.pcProductos = New Syncfusion.Windows.Forms.PopupControlContainer()
        Me.lstProductos = New System.Windows.Forms.ListBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbAnio = New Syncfusion.Windows.Forms.Tools.RadioButtonAdv()
        Me.rbPeriodo = New Syncfusion.Windows.Forms.Tools.RadioButtonAdv()
        Me.rbDia = New Syncfusion.Windows.Forms.Tools.RadioButtonAdv()
        Me.btnReporte = New System.Windows.Forms.Button()
        Me.ButtonAdv2 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.txtCategoria = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.txtBuscarProducto = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.cboTipoExistencia = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.pcAlmacen = New Syncfusion.Windows.Forms.PopupControlContainer()
        Me.lstAlmacen = New System.Windows.Forms.ListBox()
        Me.ButtonAdv4 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv5 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.txtAlmacen = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvCompra = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.lblhasta = New System.Windows.Forms.Label()
        Me.lbldesde = New System.Windows.Forms.Label()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblTipoExistencia = New System.Windows.Forms.ToolStripLabel()
        Me.lblIdTipoEx = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.lblEstado = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStrip5 = New System.Windows.Forms.ToolStrip()
        Me.lblPerido = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel6 = New System.Windows.Forms.ToolStripLabel()
        Me.lblDescripcion = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.dockingManager1 = New Syncfusion.Windows.Forms.Tools.DockingManager(Me.components)
        Me.QGlobalColorSchemeManager1 = New Qios.DevSuite.Components.QGlobalColorSchemeManager(Me.components)
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolStrip4.SuspendLayout()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.tbIGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pcProductos.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.rbAnio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rbPeriodo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rbDia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBuscarProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTipoExistencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pcAlmacen.SuspendLayout()
        CType(Me.dgvCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip3.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.ToolStrip5.SuspendLayout()
        CType(Me.dockingManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'ToolStrip4
        '
        Me.ToolStrip4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ToolStrip4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip4.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.lblProducto, Me.ToolStripSeparator1, Me.ToolStripLabel3, Me.lblCanDisponible, Me.ToolStripSeparator3, Me.ToolStripLabel4, Me.lblUnidad})
        Me.ToolStrip4.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip4.Name = "ToolStrip4"
        Me.ToolStrip4.Size = New System.Drawing.Size(1016, 25)
        Me.ToolStrip4.TabIndex = 0
        Me.ToolStrip4.Text = "ToolStrip4"
        Me.ToolStrip4.Visible = False
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.ForeColor = System.Drawing.Color.Navy
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(59, 22)
        Me.ToolStripLabel1.Text = "Producto:"
        '
        'lblProducto
        '
        Me.lblProducto.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblProducto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(39, 22)
        Me.lblProducto.Text = "Name"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.ForeColor = System.Drawing.Color.Navy
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(86, 22)
        Me.ToolStripLabel3.Text = "Cantidad disp.:"
        '
        'lblCanDisponible
        '
        Me.lblCanDisponible.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblCanDisponible.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblCanDisponible.Name = "lblCanDisponible"
        Me.lblCanDisponible.Size = New System.Drawing.Size(14, 22)
        Me.lblCanDisponible.Text = "0"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.ForeColor = System.Drawing.Color.Navy
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(32, 22)
        Me.ToolStripLabel4.Text = "U.M:"
        '
        'lblUnidad
        '
        Me.lblUnidad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.lblUnidad.Name = "lblUnidad"
        Me.lblUnidad.Size = New System.Drawing.Size(39, 22)
        Me.lblUnidad.Text = "Name"
        '
        'cboPeriodo
        '
        Me.cboPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPeriodo.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.cboPeriodo.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.cboPeriodo.Name = "cboPeriodo"
        Me.cboPeriodo.Size = New System.Drawing.Size(121, 21)
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cboPeriodo})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(182, 29)
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Label23)
        Me.Panel1.Controls.Add(Me.tbIGV)
        Me.Panel1.Controls.Add(Me.pcProductos)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.btnReporte)
        Me.Panel1.Controls.Add(Me.ButtonAdv2)
        Me.Panel1.Controls.Add(Me.txtCategoria)
        Me.Panel1.Controls.Add(Me.txtBuscarProducto)
        Me.Panel1.Controls.Add(Me.cboTipoExistencia)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.pcAlmacen)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.ButtonAdv1)
        Me.Panel1.Controls.Add(Me.txtAlmacen)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1016, 109)
        Me.Panel1.TabIndex = 312
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label23.Location = New System.Drawing.Point(281, 35)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(65, 13)
        Me.Label23.TabIndex = 406
        Me.Label23.Text = "Filtrar por - "
        '
        'tbIGV
        '
        ActiveStateCollection1.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer))
        ActiveStateCollection1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        ActiveStateCollection1.HoverColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer))
        ActiveStateCollection1.Text = "producto"
        Me.tbIGV.ActiveState = ActiveStateCollection1
        Me.tbIGV.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.tbIGV.ForeColor = System.Drawing.Color.Black
        InactiveStateCollection1.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer))
        InactiveStateCollection1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        InactiveStateCollection1.ForeColor = System.Drawing.Color.White
        InactiveStateCollection1.HoverColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer))
        InactiveStateCollection1.Text = "Acumulado"
        Me.tbIGV.InactiveState = InactiveStateCollection1
        Me.tbIGV.Location = New System.Drawing.Point(352, 31)
        Me.tbIGV.MinimumSize = New System.Drawing.Size(52, 19)
        Me.tbIGV.Name = "tbIGV"
        Me.tbIGV.Renderer = ToggleButtonRenderer1
        Me.tbIGV.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbIGV.Size = New System.Drawing.Size(106, 20)
        SliderCollection1.BackColor = System.Drawing.Color.White
        SliderCollection1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        SliderCollection1.ForeColor = System.Drawing.Color.White
        SliderCollection1.HoverColor = System.Drawing.Color.FromArgb(CType(CType(8, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(171, Byte), Integer))
        SliderCollection1.Width = 30
        Me.tbIGV.Slider = SliderCollection1
        Me.tbIGV.TabIndex = 405
        Me.tbIGV.TabStop = False
        Me.tbIGV.Text = "Button1"
        Me.tbIGV.ToggleState = Syncfusion.Windows.Forms.Tools.ToggleButtonState.Active
        '
        'pcProductos
        '
        Me.pcProductos.Controls.Add(Me.lstProductos)
        Me.pcProductos.Location = New System.Drawing.Point(525, 86)
        Me.pcProductos.Name = "pcProductos"
        Me.pcProductos.Size = New System.Drawing.Size(266, 151)
        Me.pcProductos.TabIndex = 401
        '
        'lstProductos
        '
        Me.lstProductos.BackColor = System.Drawing.Color.White
        Me.lstProductos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstProductos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.lstProductos.FormattingEnabled = True
        Me.lstProductos.Location = New System.Drawing.Point(0, 0)
        Me.lstProductos.Name = "lstProductos"
        Me.lstProductos.Size = New System.Drawing.Size(266, 151)
        Me.lstProductos.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbAnio)
        Me.GroupBox1.Controls.Add(Me.rbPeriodo)
        Me.GroupBox1.Controls.Add(Me.rbDia)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(159, 96)
        Me.GroupBox1.TabIndex = 404
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Consultar kardex por:"
        '
        'rbAnio
        '
        Me.rbAnio.BeforeTouchSize = New System.Drawing.Size(106, 21)
        Me.rbAnio.Checked = True
        Me.rbAnio.DrawFocusRectangle = False
        Me.rbAnio.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbAnio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.rbAnio.Location = New System.Drawing.Point(28, 18)
        Me.rbAnio.MetroColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.rbAnio.Name = "rbAnio"
        Me.rbAnio.Size = New System.Drawing.Size(106, 21)
        Me.rbAnio.Style = Syncfusion.Windows.Forms.Tools.RadioButtonAdvStyle.Metro
        Me.rbAnio.TabIndex = 212
        Me.rbAnio.Text = "Por año:"
        Me.rbAnio.ThemesEnabled = False
        '
        'rbPeriodo
        '
        Me.rbPeriodo.BeforeTouchSize = New System.Drawing.Size(106, 21)
        Me.rbPeriodo.DrawFocusRectangle = False
        Me.rbPeriodo.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPeriodo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.rbPeriodo.Location = New System.Drawing.Point(28, 43)
        Me.rbPeriodo.MetroColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.rbPeriodo.Name = "rbPeriodo"
        Me.rbPeriodo.Size = New System.Drawing.Size(106, 21)
        Me.rbPeriodo.Style = Syncfusion.Windows.Forms.Tools.RadioButtonAdvStyle.Metro
        Me.rbPeriodo.TabIndex = 210
        Me.rbPeriodo.TabStop = False
        Me.rbPeriodo.Text = "Por Período"
        Me.rbPeriodo.ThemesEnabled = False
        '
        'rbDia
        '
        Me.rbDia.BeforeTouchSize = New System.Drawing.Size(106, 21)
        Me.rbDia.DrawFocusRectangle = False
        Me.rbDia.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbDia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.rbDia.Location = New System.Drawing.Point(28, 68)
        Me.rbDia.MetroColor = System.Drawing.Color.FromArgb(CType(CType(88, Byte), Integer), CType(CType(89, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.rbDia.Name = "rbDia"
        Me.rbDia.Size = New System.Drawing.Size(106, 21)
        Me.rbDia.Style = Syncfusion.Windows.Forms.Tools.RadioButtonAdvStyle.Metro
        Me.rbDia.TabIndex = 211
        Me.rbDia.TabStop = False
        Me.rbDia.Text = "Por Día"
        Me.rbDia.ThemesEnabled = False
        '
        'btnReporte
        '
        Me.btnReporte.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnReporte.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnReporte.FlatAppearance.BorderSize = 2
        Me.btnReporte.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReporte.Location = New System.Drawing.Point(524, 14)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(54, 54)
        Me.btnReporte.TabIndex = 403
        Me.btnReporte.Text = "Reporte"
        Me.btnReporte.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnReporte.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnReporte.UseVisualStyleBackColor = True
        '
        'ButtonAdv2
        '
        Me.ButtonAdv2.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv2.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ButtonAdv2.BeforeTouchSize = New System.Drawing.Size(26, 19)
        Me.ButtonAdv2.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv2.Image = CType(resources.GetObject("ButtonAdv2.Image"), System.Drawing.Image)
        Me.ButtonAdv2.IsBackStageButton = False
        Me.ButtonAdv2.Location = New System.Drawing.Point(464, 32)
        Me.ButtonAdv2.Name = "ButtonAdv2"
        Me.ButtonAdv2.Size = New System.Drawing.Size(26, 19)
        Me.ButtonAdv2.TabIndex = 402
        Me.ToolTip1.SetToolTip(Me.ButtonAdv2, "Actulizar consulta")
        Me.ButtonAdv2.UseVisualStyle = True
        '
        'txtCategoria
        '
        Me.txtCategoria.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCategoria.Location = New System.Drawing.Point(778, 119)
        Me.txtCategoria.Name = "txtCategoria"
        Me.txtCategoria.Size = New System.Drawing.Size(10, 19)
        Me.txtCategoria.TabIndex = 213
        Me.txtCategoria.Visible = False
        '
        'txtBuscarProducto
        '
        Me.txtBuscarProducto.BackColor = System.Drawing.Color.White
        Me.txtBuscarProducto.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtBuscarProducto.BorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.txtBuscarProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBuscarProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBuscarProducto.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBuscarProducto.Location = New System.Drawing.Point(240, 56)
        Me.txtBuscarProducto.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.txtBuscarProducto.Name = "txtBuscarProducto"
        Me.txtBuscarProducto.Size = New System.Drawing.Size(218, 22)
        Me.txtBuscarProducto.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtBuscarProducto.TabIndex = 214
        '
        'cboTipoExistencia
        '
        Me.cboTipoExistencia.BackColor = System.Drawing.Color.White
        Me.cboTipoExistencia.BeforeTouchSize = New System.Drawing.Size(218, 21)
        Me.cboTipoExistencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoExistencia.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoExistencia.Location = New System.Drawing.Point(240, 82)
        Me.cboTipoExistencia.Name = "cboTipoExistencia"
        Me.cboTipoExistencia.Size = New System.Drawing.Size(218, 21)
        Me.cboTipoExistencia.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboTipoExistencia.TabIndex = 211
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.DimGray
        Me.Label12.Location = New System.Drawing.Point(174, 86)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(61, 13)
        Me.Label12.TabIndex = 209
        Me.Label12.Text = "Tipo Exist.:"
        '
        'pcAlmacen
        '
        Me.pcAlmacen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pcAlmacen.Controls.Add(Me.lstAlmacen)
        Me.pcAlmacen.Controls.Add(Me.ButtonAdv4)
        Me.pcAlmacen.Controls.Add(Me.ButtonAdv5)
        Me.pcAlmacen.Location = New System.Drawing.Point(791, 6)
        Me.pcAlmacen.Name = "pcAlmacen"
        Me.pcAlmacen.Size = New System.Drawing.Size(220, 133)
        Me.pcAlmacen.TabIndex = 206
        Me.pcAlmacen.Visible = False
        '
        'lstAlmacen
        '
        Me.lstAlmacen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstAlmacen.FormattingEnabled = True
        Me.lstAlmacen.Location = New System.Drawing.Point(0, 0)
        Me.lstAlmacen.Name = "lstAlmacen"
        Me.lstAlmacen.Size = New System.Drawing.Size(218, 131)
        Me.lstAlmacen.TabIndex = 3
        '
        'ButtonAdv4
        '
        Me.ButtonAdv4.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv4.BackColor = System.Drawing.SystemColors.Highlight
        Me.ButtonAdv4.BeforeTouchSize = New System.Drawing.Size(60, 19)
        Me.ButtonAdv4.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv4.IsBackStageButton = False
        Me.ButtonAdv4.Location = New System.Drawing.Point(63, 86)
        Me.ButtonAdv4.Name = "ButtonAdv4"
        Me.ButtonAdv4.Size = New System.Drawing.Size(60, 19)
        Me.ButtonAdv4.TabIndex = 209
        Me.ButtonAdv4.Text = "Cancelar"
        Me.ButtonAdv4.UseVisualStyle = True
        '
        'ButtonAdv5
        '
        Me.ButtonAdv5.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv5.BackColor = System.Drawing.SystemColors.Highlight
        Me.ButtonAdv5.BeforeTouchSize = New System.Drawing.Size(60, 19)
        Me.ButtonAdv5.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv5.IsBackStageButton = False
        Me.ButtonAdv5.Location = New System.Drawing.Point(1, 86)
        Me.ButtonAdv5.Name = "ButtonAdv5"
        Me.ButtonAdv5.Size = New System.Drawing.Size(60, 19)
        Me.ButtonAdv5.TabIndex = 208
        Me.ButtonAdv5.Text = "OK"
        Me.ButtonAdv5.UseVisualStyle = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(180, 60)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(57, 13)
        Me.Label10.TabIndex = 204
        Me.Label10.Text = "Producto:"
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.SystemColors.Highlight
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(26, 19)
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.Image = CType(resources.GetObject("ButtonAdv1.Image"), System.Drawing.Image)
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(464, 7)
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(26, 19)
        Me.ButtonAdv1.TabIndex = 209
        Me.ButtonAdv1.UseVisualStyle = True
        '
        'txtAlmacen
        '
        Me.txtAlmacen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAlmacen.Location = New System.Drawing.Point(240, 7)
        Me.txtAlmacen.Name = "txtAlmacen"
        Me.txtAlmacen.ReadOnly = True
        Me.txtAlmacen.Size = New System.Drawing.Size(218, 19)
        Me.txtAlmacen.TabIndex = 208
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(184, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Almacén:"
        '
        'dgvCompra
        '
        Me.dgvCompra.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        Me.dgvCompra.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.dgvCompra.BackColor = System.Drawing.SystemColors.Window
        Me.dgvCompra.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCompra.FreezeCaption = False
        Me.dgvCompra.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgvCompra.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.dgvCompra.Location = New System.Drawing.Point(0, 0)
        Me.dgvCompra.Name = "dgvCompra"
        Me.dgvCompra.ShowGroupDropArea = True
        Me.dgvCompra.Size = New System.Drawing.Size(1016, 246)
        Me.dgvCompra.TabIndex = 401
        Me.dgvCompra.TableDescriptor.AllowNew = False
        Me.dgvCompra.TableDescriptor.Appearance.AnyCell.Font.Facename = "Segoe UI"
        Me.dgvCompra.TableDescriptor.Appearance.AnyCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.dgvCompra.TableDescriptor.Appearance.AnyGroupCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCompra.TableDescriptor.Appearance.AnyGroupCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCompra.TableDescriptor.Appearance.AnyGroupCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer)))
        Me.dgvCompra.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCompra.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCompra.TableDescriptor.Appearance.AnySummaryCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCompra.TableDescriptor.Appearance.AnySummaryCell.Borders.Top = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCompra.TableDescriptor.Appearance.AnySummaryCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)))
        Me.dgvCompra.TableDescriptor.Appearance.ColumnHeaderCell.Font.Bold = True
        Me.dgvCompra.TableDescriptor.Appearance.ColumnHeaderCell.Font.Italic = False
        Me.dgvCompra.TableDescriptor.Appearance.ColumnHeaderCell.Font.Size = 8.0!
        Me.dgvCompra.TableDescriptor.Appearance.GroupCaptionCell.CellType = """ColumnHeader"""
        GridColumnDescriptor1.AllowSort = False
        GridColumnDescriptor1.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Info)
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.HeaderText = "Operación"
        GridColumnDescriptor1.MappingName = "Movimiento"
        GridColumnDescriptor1.ReadOnly = True
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor1.Width = 100
        GridColumnDescriptor2.AllowSort = False
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.HeaderText = "Fecha"
        GridColumnDescriptor2.MappingName = "fecha"
        GridColumnDescriptor2.ReadOnly = True
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor2.Width = 87
        GridColumnDescriptor3.AllowSort = False
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.HeaderText = "Gr"
        GridColumnDescriptor3.MappingName = "destinoGravadoItem"
        GridColumnDescriptor3.ReadOnly = True
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor3.Width = 20
        GridColumnDescriptor4.AllowSort = False
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.HeaderText = "Item"
        GridColumnDescriptor4.MappingName = "nombreItem"
        GridColumnDescriptor4.ReadOnly = True
        GridColumnDescriptor4.SerializedImageArray = ""
        GridColumnDescriptor4.Width = 150
        GridColumnDescriptor5.AllowSort = False
        GridColumnDescriptor5.HeaderImage = Nothing
        GridColumnDescriptor5.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor5.HeaderText = "T.E."
        GridColumnDescriptor5.MappingName = "tipoProducto"
        GridColumnDescriptor5.ReadOnly = True
        GridColumnDescriptor5.SerializedImageArray = ""
        GridColumnDescriptor6.AllowSort = False
        GridColumnDescriptor6.HeaderImage = Nothing
        GridColumnDescriptor6.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor6.HeaderText = "U.M."
        GridColumnDescriptor6.MappingName = "unidad"
        GridColumnDescriptor6.ReadOnly = True
        GridColumnDescriptor6.SerializedImageArray = ""
        GridColumnDescriptor7.AllowSort = False
        GridColumnDescriptor7.Appearance.AnyRecordFieldCell.CellType = "Currency"
        GridColumnDescriptor7.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
        GridColumnDescriptor7.HeaderImage = Nothing
        GridColumnDescriptor7.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor7.HeaderText = "Cant."
        GridColumnDescriptor7.MappingName = "cantidad"
        GridColumnDescriptor7.ReadOnly = True
        GridColumnDescriptor7.SerializedImageArray = ""
        GridColumnDescriptor7.Width = 80
        GridColumnDescriptor8.AllowSort = False
        GridColumnDescriptor8.Appearance.AnyRecordFieldCell.CellType = "Currency"
        GridColumnDescriptor8.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
        GridColumnDescriptor8.HeaderImage = Nothing
        GridColumnDescriptor8.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor8.HeaderText = "P.U."
        GridColumnDescriptor8.MappingName = "precUnite"
        GridColumnDescriptor8.ReadOnly = True
        GridColumnDescriptor8.SerializedImageArray = ""
        GridColumnDescriptor8.Width = 70
        GridColumnDescriptor9.AllowSort = False
        GridColumnDescriptor9.Appearance.AnyRecordFieldCell.CellType = "Currency"
        GridColumnDescriptor9.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
        GridColumnDescriptor9.HeaderImage = Nothing
        GridColumnDescriptor9.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor9.HeaderText = "M.N."
        GridColumnDescriptor9.MappingName = "monto"
        GridColumnDescriptor9.ReadOnly = True
        GridColumnDescriptor9.SerializedImageArray = ""
        GridColumnDescriptor9.Width = 80
        GridColumnDescriptor10.AllowSort = False
        GridColumnDescriptor10.Appearance.AnyRecordFieldCell.CellType = "Currency"
        GridColumnDescriptor10.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
        GridColumnDescriptor10.HeaderImage = Nothing
        GridColumnDescriptor10.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor10.HeaderText = "Cant."
        GridColumnDescriptor10.MappingName = "cantidad1"
        GridColumnDescriptor10.ReadOnly = True
        GridColumnDescriptor10.SerializedImageArray = ""
        GridColumnDescriptor10.Width = 80
        GridColumnDescriptor11.AllowSort = False
        GridColumnDescriptor11.Appearance.AnyRecordFieldCell.CellType = "Currency"
        GridColumnDescriptor11.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
        GridColumnDescriptor11.HeaderImage = Nothing
        GridColumnDescriptor11.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor11.HeaderText = "P.U."
        GridColumnDescriptor11.MappingName = "precUnite1"
        GridColumnDescriptor11.ReadOnly = True
        GridColumnDescriptor11.SerializedImageArray = ""
        GridColumnDescriptor11.Width = 70
        GridColumnDescriptor12.AllowSort = False
        GridColumnDescriptor12.Appearance.AnyRecordFieldCell.CellType = "Currency"
        GridColumnDescriptor12.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
        GridColumnDescriptor12.HeaderImage = Nothing
        GridColumnDescriptor12.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor12.HeaderText = "M.N."
        GridColumnDescriptor12.MappingName = "monto1"
        GridColumnDescriptor12.SerializedImageArray = ""
        GridColumnDescriptor13.AllowSort = False
        GridColumnDescriptor13.Appearance.AnyRecordFieldCell.CellType = "Currency"
        GridColumnDescriptor13.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
        GridColumnDescriptor13.HeaderImage = Nothing
        GridColumnDescriptor13.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor13.HeaderText = "Cant."
        GridColumnDescriptor13.MappingName = "cantidad2"
        GridColumnDescriptor13.ReadOnly = True
        GridColumnDescriptor13.SerializedImageArray = ""
        GridColumnDescriptor14.AllowSort = False
        GridColumnDescriptor14.Appearance.AnyRecordFieldCell.CellType = "Currency"
        GridColumnDescriptor14.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
        GridColumnDescriptor14.HeaderImage = Nothing
        GridColumnDescriptor14.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor14.HeaderText = "P.M."
        GridColumnDescriptor14.MappingName = "monto2"
        GridColumnDescriptor14.ReadOnly = True
        GridColumnDescriptor14.SerializedImageArray = ""
        GridColumnDescriptor14.Width = 80
        GridColumnDescriptor15.AllowSort = False
        GridColumnDescriptor15.Appearance.AnyRecordFieldCell.CellType = "Currency"
        GridColumnDescriptor15.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
        GridColumnDescriptor15.HeaderImage = Nothing
        GridColumnDescriptor15.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor15.HeaderText = "Costo"
        GridColumnDescriptor15.MappingName = "precUnite2"
        GridColumnDescriptor15.ReadOnly = True
        GridColumnDescriptor15.SerializedImageArray = ""
        GridColumnDescriptor15.Width = 80
        GridColumnDescriptor16.AllowSort = False
        GridColumnDescriptor16.HeaderImage = Nothing
        GridColumnDescriptor16.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor16.MappingName = "idDocumento"
        GridColumnDescriptor16.ReadOnly = True
        GridColumnDescriptor16.SerializedImageArray = ""
        Me.dgvCompra.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7, GridColumnDescriptor8, GridColumnDescriptor9, GridColumnDescriptor10, GridColumnDescriptor11, GridColumnDescriptor12, GridColumnDescriptor13, GridColumnDescriptor14, GridColumnDescriptor15, GridColumnDescriptor16})
        Me.dgvCompra.TableDescriptor.SortedColumns.AddRange(New Syncfusion.Grouping.SortColumnDescriptor() {New Syncfusion.Grouping.SortColumnDescriptor("fechaCobro", System.ComponentModel.ListSortDirection.Descending)})
        GridStackedHeaderRowDescriptor1.Appearance.StackedHeaderCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        GridStackedHeaderRowDescriptor1.Appearance.StackedHeaderCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        GridStackedHeaderDescriptor1.HeaderText = "S A L I D A"
        GridStackedHeaderDescriptor1.Name = "StackedHeader 4"
        GridStackedHeaderDescriptor1.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("cantidad1"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("precUnite1"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("monto1")})
        GridStackedHeaderDescriptor2.Appearance.StackedHeaderCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer)))
        GridStackedHeaderDescriptor2.Appearance.StackedHeaderCell.TextColor = System.Drawing.Color.White
        GridStackedHeaderDescriptor2.Appearance.StackedHeaderCell.Themed = False
        GridStackedHeaderDescriptor2.HeaderText = "S A L D O S"
        GridStackedHeaderDescriptor2.Name = "StackedHeader 5"
        GridStackedHeaderDescriptor2.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("cantidad2"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("monto2"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("precUnite2")})
        GridStackedHeaderRowDescriptor1.Headers.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor("StackedHeader 1", "P R O D U C T O", New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("fecha"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("destinoGravadoItem"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("nombreItem"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("tipoProducto"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("unidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("Movimiento")}), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor("StackedHeader 3", "E N T R A D A", New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("cantidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("precUnite"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("monto")}), GridStackedHeaderDescriptor1, GridStackedHeaderDescriptor2})
        GridStackedHeaderRowDescriptor1.Name = "Row 1"
        Me.dgvCompra.TableDescriptor.StackedHeaderRows.Add(GridStackedHeaderRowDescriptor1)
        GridSummaryRowDescriptor1.Name = "Row 1"
        GridSummaryColumnDescriptor1.Appearance.AnySummaryCell.Font.Bold = True
        GridSummaryColumnDescriptor1.Appearance.AnySummaryCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center
        GridSummaryColumnDescriptor1.Appearance.AnySummaryCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        GridSummaryColumnDescriptor1.DataMember = "importeTotal"
        GridSummaryColumnDescriptor1.Format = "{Sum:S/###,###,##0.00}"
        GridSummaryColumnDescriptor1.Name = "TSoles"
        GridSummaryColumnDescriptor1.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        GridSummaryColumnDescriptor2.Appearance.AnySummaryCell.Font.Bold = True
        GridSummaryColumnDescriptor2.Appearance.AnySummaryCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        GridSummaryColumnDescriptor2.DataMember = "importeUS"
        GridSummaryColumnDescriptor2.Format = "{Sum:$###,###,##0.00}"
        GridSummaryColumnDescriptor2.Name = "TUsd"
        GridSummaryColumnDescriptor2.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        GridSummaryRowDescriptor1.SummaryColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor() {GridSummaryColumnDescriptor1, GridSummaryColumnDescriptor2})
        GridSummaryRowDescriptor1.Title = "Totales"
        Me.dgvCompra.TableDescriptor.SummaryRows.Add(GridSummaryRowDescriptor1)
        Me.dgvCompra.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.dgvCompra.TableDescriptor.TableOptions.RecordRowHeight = 20
        Me.dgvCompra.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("Movimiento"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("fecha"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("destinoGravadoItem"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("nombreItem"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipoProducto"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("unidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("cantidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("precUnite"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("monto"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("cantidad1"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("precUnite1"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("monto1"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("cantidad2"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("precUnite2"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("monto2")})
        Me.dgvCompra.Text = "GridGroupingControl2"
        Me.dgvCompra.VersionInfo = "12.4400.0.24"
        '
        'lblhasta
        '
        Me.lblhasta.AutoSize = True
        Me.lblhasta.BackColor = System.Drawing.Color.Transparent
        Me.lblhasta.Location = New System.Drawing.Point(852, 34)
        Me.lblhasta.Name = "lblhasta"
        Me.lblhasta.Size = New System.Drawing.Size(39, 13)
        Me.lblhasta.TabIndex = 311
        Me.lblhasta.Text = "Hasta:"
        '
        'lbldesde
        '
        Me.lbldesde.AutoSize = True
        Me.lbldesde.BackColor = System.Drawing.Color.Transparent
        Me.lbldesde.Location = New System.Drawing.Point(634, 34)
        Me.lbldesde.Name = "lbldesde"
        Me.lbldesde.Size = New System.Drawing.Size(42, 13)
        Me.lbldesde.TabIndex = 310
        Me.lbldesde.Text = "Desde:"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.CustomFormat = "dd/MM/yyyy hh:mm:ss tt"
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker2.Location = New System.Drawing.Point(896, 28)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(168, 22)
        Me.DateTimePicker2.TabIndex = 309
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "dd/MM/yyyy hh:mm:ss tt"
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(681, 28)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(165, 22)
        Me.DateTimePicker1.TabIndex = 308
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(541, 33)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(80, 17)
        Me.CheckBox3.TabIndex = 307
        Me.CheckBox3.Text = "Por Rango"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'ToolStrip3
        '
        Me.ToolStrip3.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.ToolStrip3.BackgroundImage = CType(resources.GetObject("ToolStrip3.BackgroundImage"), System.Drawing.Image)
        Me.ToolStrip3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.lblTipoExistencia, Me.lblIdTipoEx, Me.ToolStripLabel2, Me.ToolStripTextBox1})
        Me.ToolStrip3.Location = New System.Drawing.Point(0, 50)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.Size = New System.Drawing.Size(718, 25)
        Me.ToolStrip3.TabIndex = 286
        Me.ToolStrip3.Text = "ToolStrip3"
        Me.ToolStrip3.Visible = False
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'lblTipoExistencia
        '
        Me.lblTipoExistencia.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblTipoExistencia.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblTipoExistencia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.lblTipoExistencia.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblTipoExistencia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblTipoExistencia.Image = CType(resources.GetObject("lblTipoExistencia.Image"), System.Drawing.Image)
        Me.lblTipoExistencia.Name = "lblTipoExistencia"
        Me.lblTipoExistencia.Size = New System.Drawing.Size(100, 22)
        Me.lblTipoExistencia.Text = "Tipo existencia"
        Me.lblTipoExistencia.ToolTipText = "Seleccionar tipo de existencia"
        '
        'lblIdTipoEx
        '
        Me.lblIdTipoEx.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblIdTipoEx.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblIdTipoEx.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblIdTipoEx.Name = "lblIdTipoEx"
        Me.lblIdTipoEx.Size = New System.Drawing.Size(19, 22)
        Me.lblIdTipoEx.Text = "01"
        Me.lblIdTipoEx.Visible = False
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.ToolStripLabel2.Image = CType(resources.GetObject("ToolStripLabel2.Image"), System.Drawing.Image)
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(105, 22)
        Me.ToolStripLabel2.Text = "Buscar producto:"
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        Me.ToolStripTextBox1.Size = New System.Drawing.Size(200, 25)
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(475, 33)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(67, 17)
        Me.CheckBox2.TabIndex = 306
        Me.CheckBox2.Text = "Por Mes"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(409, 33)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(63, 17)
        Me.CheckBox1.TabIndex = 305
        Me.CheckBox1.Text = "Por Dia"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ToolStrip1.BackgroundImage = CType(resources.GetObject("ToolStrip1.BackgroundImage"), System.Drawing.Image)
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblEstado})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 50)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(718, 25)
        Me.ToolStrip1.TabIndex = 285
        Me.ToolStrip1.Text = "ToolStrip1"
        Me.ToolStrip1.Visible = False
        '
        'lblEstado
        '
        Me.lblEstado.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblEstado.ForeColor = System.Drawing.Color.Black
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(109, 22)
        Me.lblEstado.Text = "Distribución de items"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.BackColor = System.Drawing.Color.White
        Me.ToolStrip2.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 25)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip2.Size = New System.Drawing.Size(1098, 25)
        Me.ToolStrip2.TabIndex = 284
        Me.ToolStrip2.Text = "ToolStrip2"
        Me.ToolStrip2.Visible = False
        '
        'ToolStrip5
        '
        Me.ToolStrip5.BackColor = System.Drawing.Color.White
        Me.ToolStrip5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip5.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip5.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblPerido, Me.ToolStripLabel6, Me.lblDescripcion, Me.ToolStripSeparator5, Me.ToolStripButton1})
        Me.ToolStrip5.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip5.Name = "ToolStrip5"
        Me.ToolStrip5.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip5.Size = New System.Drawing.Size(1016, 25)
        Me.ToolStrip5.TabIndex = 289
        Me.ToolStrip5.Text = "ToolStrip5"
        '
        'lblPerido
        '
        Me.lblPerido.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblPerido.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPerido.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.lblPerido.LinkColor = System.Drawing.Color.White
        Me.lblPerido.Name = "lblPerido"
        Me.lblPerido.Size = New System.Drawing.Size(54, 22)
        Me.lblPerido.Text = "01/2014"
        '
        'ToolStripLabel6
        '
        Me.ToolStripLabel6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel6.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.ToolStripLabel6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.ToolStripLabel6.LinkColor = System.Drawing.Color.White
        Me.ToolStripLabel6.Name = "ToolStripLabel6"
        Me.ToolStripLabel6.Size = New System.Drawing.Size(58, 22)
        Me.ToolStripLabel6.Text = "PERIODO:"
        '
        'lblDescripcion
        '
        Me.lblDescripcion.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.lblDescripcion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblDescripcion.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(88, 22)
        Me.lblDescripcion.Text = "STOCK GENERAL"
        Me.lblDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "Ver Existencias"
        Me.ToolStripButton1.Visible = False
        '
        'dockingManager1
        '
        Me.dockingManager1.ActiveCaptionFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.dockingManager1.AutoHideActiveControl = True
        Me.dockingManager1.AutoHideTabFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.dockingManager1.DockLayoutStream = CType(resources.GetObject("dockingManager1.DockLayoutStream"), System.IO.MemoryStream)
        Me.dockingManager1.DockTabFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.dockingManager1.HostControl = Me
        Me.dockingManager1.InActiveCaptionBackground = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer)))
        Me.dockingManager1.InActiveCaptionFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.dockingManager1.MetroButtonColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dockingManager1.MetroCaptionColor = System.Drawing.Color.White
        Me.dockingManager1.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.dockingManager1.MetroSplitterBackColor = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.dockingManager1.ReduceFlickeringInRtl = False
        Me.dockingManager1.SplitterWidth = 1
        Me.dockingManager1.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.dockingManager1.CaptionButtons.Add(New Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Close, "CloseButton"))
        Me.dockingManager1.CaptionButtons.Add(New Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Pin, "PinButton"))
        Me.dockingManager1.CaptionButtons.Add(New Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Maximize, "MaximizeButton"))
        Me.dockingManager1.CaptionButtons.Add(New Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Restore, "RestoreButton"))
        Me.dockingManager1.CaptionButtons.Add(New Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Menu, "MenuButton"))
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.dgvCompra)
        Me.Panel4.Controls.Add(Me.ToolStrip4)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 134)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1016, 246)
        Me.Panel4.TabIndex = 402
        '
        'frmKardex
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1016, 380)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblhasta)
        Me.Controls.Add(Me.lbldesde)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.CheckBox3)
        Me.Controls.Add(Me.ToolStrip3)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Controls.Add(Me.ToolStrip5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmKardex"
        Me.Text = "Kardex de existencias"
        Me.ToolStrip4.ResumeLayout(False)
        Me.ToolStrip4.PerformLayout()
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.tbIGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pcProductos.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.rbAnio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rbPeriodo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rbDia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBuscarProducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTipoExistencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pcAlmacen.ResumeLayout(False)
        CType(Me.dgvCompra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ToolStrip5.ResumeLayout(False)
        Me.ToolStrip5.PerformLayout()
        CType(Me.dockingManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblTipoExistencia As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblIdTipoEx As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripTextBox1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStrip4 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblProducto As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblCanDisponible As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel4 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblUnidad As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lstProductos As System.Windows.Forms.ListBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ToolStrip5 As System.Windows.Forms.ToolStrip
    Friend WithEvents lblDescripcion As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblEstado As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel6 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblPerido As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblhasta As System.Windows.Forms.Label
    Friend WithEvents lbldesde As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cboPeriodo As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rbDia As Syncfusion.Windows.Forms.Tools.RadioButtonAdv
    Friend WithEvents rbPeriodo As Syncfusion.Windows.Forms.Tools.RadioButtonAdv
    Private WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents txtAlmacen As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Private WithEvents pcAlmacen As Syncfusion.Windows.Forms.PopupControlContainer
    Private WithEvents ButtonAdv4 As Syncfusion.Windows.Forms.ButtonAdv
    Private WithEvents ButtonAdv5 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents lstAlmacen As System.Windows.Forms.ListBox
    Friend WithEvents txtCategoria As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents cboTipoExistencia As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Private WithEvents dockingManager1 As Syncfusion.Windows.Forms.Tools.DockingManager
    Friend WithEvents QGlobalColorSchemeManager1 As Qios.DevSuite.Components.QGlobalColorSchemeManager
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvCompra As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents txtBuscarProducto As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents pcProductos As Syncfusion.Windows.Forms.PopupControlContainer
    Private WithEvents ButtonAdv2 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnReporte As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbAnio As Syncfusion.Windows.Forms.Tools.RadioButtonAdv
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Private WithEvents tbIGV As Syncfusion.Windows.Forms.Tools.ToggleButton
End Class

Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormCrearEquivalenciasArticulo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCrearEquivalenciasArticulo))
        Dim GridColumnDescriptor9 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor10 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor11 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor12 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor13 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor14 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor15 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor16 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtProveedor = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.BunifuThinButton26 = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.BunifuThinButton25 = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.BunifuThinButton24 = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.BunifuThinButton23 = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.BunifuThinButton22 = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.BunifuThinButton21 = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboUnidades = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.textValUnidades = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.GridEquivalencia = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.GridPrecios = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.BunifuThinButton27 = New Bunifu.Framework.UI.BunifuThinButton2()
        CType(Me.txtProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboUnidades, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.textValUnidades, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridEquivalencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        CType(Me.GridPrecios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(33, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Producto"
        '
        'txtProveedor
        '
        Me.txtProveedor.BackColor = System.Drawing.Color.White
        Me.txtProveedor.BeforeTouchSize = New System.Drawing.Size(175, 22)
        Me.txtProveedor.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProveedor.CornerRadius = 4
        Me.txtProveedor.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtProveedor.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProveedor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtProveedor.Location = New System.Drawing.Point(36, 59)
        Me.txtProveedor.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.txtProveedor.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtProveedor.Multiline = True
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.NearImage = CType(resources.GetObject("txtProveedor.NearImage"), System.Drawing.Image)
        Me.txtProveedor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtProveedor.Size = New System.Drawing.Size(319, 42)
        Me.txtProveedor.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtProveedor.TabIndex = 500
        '
        'BunifuThinButton26
        '
        Me.BunifuThinButton26.ActiveBorderThickness = 1
        Me.BunifuThinButton26.ActiveCornerRadius = 20
        Me.BunifuThinButton26.ActiveFillColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.BunifuThinButton26.ActiveForecolor = System.Drawing.Color.White
        Me.BunifuThinButton26.ActiveLineColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.BunifuThinButton26.BackColor = System.Drawing.Color.White
        Me.BunifuThinButton26.BackgroundImage = CType(resources.GetObject("BunifuThinButton26.BackgroundImage"), System.Drawing.Image)
        Me.BunifuThinButton26.ButtonText = "Otro"
        Me.BunifuThinButton26.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuThinButton26.Font = New System.Drawing.Font("Century Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuThinButton26.ForeColor = System.Drawing.Color.Black
        Me.BunifuThinButton26.IdleBorderThickness = 1
        Me.BunifuThinButton26.IdleCornerRadius = 20
        Me.BunifuThinButton26.IdleFillColor = System.Drawing.Color.White
        Me.BunifuThinButton26.IdleForecolor = System.Drawing.Color.Black
        Me.BunifuThinButton26.IdleLineColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.BunifuThinButton26.Location = New System.Drawing.Point(454, 108)
        Me.BunifuThinButton26.Margin = New System.Windows.Forms.Padding(4)
        Me.BunifuThinButton26.Name = "BunifuThinButton26"
        Me.BunifuThinButton26.Size = New System.Drawing.Size(77, 38)
        Me.BunifuThinButton26.TabIndex = 507
        Me.BunifuThinButton26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BunifuThinButton25
        '
        Me.BunifuThinButton25.ActiveBorderThickness = 1
        Me.BunifuThinButton25.ActiveCornerRadius = 20
        Me.BunifuThinButton25.ActiveFillColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.BunifuThinButton25.ActiveForecolor = System.Drawing.Color.White
        Me.BunifuThinButton25.ActiveLineColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.BunifuThinButton25.BackColor = System.Drawing.Color.White
        Me.BunifuThinButton25.BackgroundImage = CType(resources.GetObject("BunifuThinButton25.BackgroundImage"), System.Drawing.Image)
        Me.BunifuThinButton25.ButtonText = "Unidad"
        Me.BunifuThinButton25.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuThinButton25.Font = New System.Drawing.Font("Century Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuThinButton25.ForeColor = System.Drawing.Color.Black
        Me.BunifuThinButton25.IdleBorderThickness = 1
        Me.BunifuThinButton25.IdleCornerRadius = 20
        Me.BunifuThinButton25.IdleFillColor = System.Drawing.Color.White
        Me.BunifuThinButton25.IdleForecolor = System.Drawing.Color.Black
        Me.BunifuThinButton25.IdleLineColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.BunifuThinButton25.Location = New System.Drawing.Point(369, 108)
        Me.BunifuThinButton25.Margin = New System.Windows.Forms.Padding(4)
        Me.BunifuThinButton25.Name = "BunifuThinButton25"
        Me.BunifuThinButton25.Size = New System.Drawing.Size(77, 38)
        Me.BunifuThinButton25.TabIndex = 506
        Me.BunifuThinButton25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BunifuThinButton24
        '
        Me.BunifuThinButton24.ActiveBorderThickness = 1
        Me.BunifuThinButton24.ActiveCornerRadius = 20
        Me.BunifuThinButton24.ActiveFillColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.BunifuThinButton24.ActiveForecolor = System.Drawing.Color.White
        Me.BunifuThinButton24.ActiveLineColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.BunifuThinButton24.BackColor = System.Drawing.Color.White
        Me.BunifuThinButton24.BackgroundImage = CType(resources.GetObject("BunifuThinButton24.BackgroundImage"), System.Drawing.Image)
        Me.BunifuThinButton24.ButtonText = "Docena"
        Me.BunifuThinButton24.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuThinButton24.Font = New System.Drawing.Font("Century Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuThinButton24.ForeColor = System.Drawing.Color.Black
        Me.BunifuThinButton24.IdleBorderThickness = 1
        Me.BunifuThinButton24.IdleCornerRadius = 20
        Me.BunifuThinButton24.IdleFillColor = System.Drawing.Color.White
        Me.BunifuThinButton24.IdleForecolor = System.Drawing.Color.Black
        Me.BunifuThinButton24.IdleLineColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.BunifuThinButton24.Location = New System.Drawing.Point(284, 108)
        Me.BunifuThinButton24.Margin = New System.Windows.Forms.Padding(4)
        Me.BunifuThinButton24.Name = "BunifuThinButton24"
        Me.BunifuThinButton24.Size = New System.Drawing.Size(77, 38)
        Me.BunifuThinButton24.TabIndex = 505
        Me.BunifuThinButton24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BunifuThinButton23
        '
        Me.BunifuThinButton23.ActiveBorderThickness = 1
        Me.BunifuThinButton23.ActiveCornerRadius = 20
        Me.BunifuThinButton23.ActiveFillColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.BunifuThinButton23.ActiveForecolor = System.Drawing.Color.White
        Me.BunifuThinButton23.ActiveLineColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.BunifuThinButton23.BackColor = System.Drawing.Color.White
        Me.BunifuThinButton23.BackgroundImage = CType(resources.GetObject("BunifuThinButton23.BackgroundImage"), System.Drawing.Image)
        Me.BunifuThinButton23.ButtonText = "1/2 Caja"
        Me.BunifuThinButton23.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuThinButton23.Font = New System.Drawing.Font("Century Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuThinButton23.ForeColor = System.Drawing.Color.Black
        Me.BunifuThinButton23.IdleBorderThickness = 1
        Me.BunifuThinButton23.IdleCornerRadius = 20
        Me.BunifuThinButton23.IdleFillColor = System.Drawing.Color.White
        Me.BunifuThinButton23.IdleForecolor = System.Drawing.Color.Black
        Me.BunifuThinButton23.IdleLineColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.BunifuThinButton23.Location = New System.Drawing.Point(201, 108)
        Me.BunifuThinButton23.Margin = New System.Windows.Forms.Padding(4)
        Me.BunifuThinButton23.Name = "BunifuThinButton23"
        Me.BunifuThinButton23.Size = New System.Drawing.Size(77, 38)
        Me.BunifuThinButton23.TabIndex = 504
        Me.BunifuThinButton23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BunifuThinButton22
        '
        Me.BunifuThinButton22.ActiveBorderThickness = 1
        Me.BunifuThinButton22.ActiveCornerRadius = 20
        Me.BunifuThinButton22.ActiveFillColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.BunifuThinButton22.ActiveForecolor = System.Drawing.Color.White
        Me.BunifuThinButton22.ActiveLineColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.BunifuThinButton22.BackColor = System.Drawing.Color.White
        Me.BunifuThinButton22.BackgroundImage = CType(resources.GetObject("BunifuThinButton22.BackgroundImage"), System.Drawing.Image)
        Me.BunifuThinButton22.ButtonText = "3/4 Caja"
        Me.BunifuThinButton22.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuThinButton22.Font = New System.Drawing.Font("Century Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuThinButton22.ForeColor = System.Drawing.Color.Black
        Me.BunifuThinButton22.IdleBorderThickness = 1
        Me.BunifuThinButton22.IdleCornerRadius = 20
        Me.BunifuThinButton22.IdleFillColor = System.Drawing.Color.White
        Me.BunifuThinButton22.IdleForecolor = System.Drawing.Color.Black
        Me.BunifuThinButton22.IdleLineColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.BunifuThinButton22.Location = New System.Drawing.Point(119, 108)
        Me.BunifuThinButton22.Margin = New System.Windows.Forms.Padding(4)
        Me.BunifuThinButton22.Name = "BunifuThinButton22"
        Me.BunifuThinButton22.Size = New System.Drawing.Size(77, 38)
        Me.BunifuThinButton22.TabIndex = 503
        Me.BunifuThinButton22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BunifuThinButton21
        '
        Me.BunifuThinButton21.ActiveBorderThickness = 1
        Me.BunifuThinButton21.ActiveCornerRadius = 20
        Me.BunifuThinButton21.ActiveFillColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.BunifuThinButton21.ActiveForecolor = System.Drawing.Color.White
        Me.BunifuThinButton21.ActiveLineColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.BunifuThinButton21.BackColor = System.Drawing.Color.White
        Me.BunifuThinButton21.BackgroundImage = CType(resources.GetObject("BunifuThinButton21.BackgroundImage"), System.Drawing.Image)
        Me.BunifuThinButton21.ButtonText = "Caja"
        Me.BunifuThinButton21.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuThinButton21.Font = New System.Drawing.Font("Century Gothic", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuThinButton21.ForeColor = System.Drawing.Color.Black
        Me.BunifuThinButton21.IdleBorderThickness = 1
        Me.BunifuThinButton21.IdleCornerRadius = 20
        Me.BunifuThinButton21.IdleFillColor = System.Drawing.Color.White
        Me.BunifuThinButton21.IdleForecolor = System.Drawing.Color.Black
        Me.BunifuThinButton21.IdleLineColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.BunifuThinButton21.Location = New System.Drawing.Point(36, 108)
        Me.BunifuThinButton21.Margin = New System.Windows.Forms.Padding(4)
        Me.BunifuThinButton21.Name = "BunifuThinButton21"
        Me.BunifuThinButton21.Size = New System.Drawing.Size(77, 38)
        Me.BunifuThinButton21.TabIndex = 502
        Me.BunifuThinButton21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(366, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 13)
        Me.Label2.TabIndex = 508
        Me.Label2.Text = "Unidad Medida"
        '
        'cboUnidades
        '
        Me.cboUnidades.BackColor = System.Drawing.Color.White
        Me.cboUnidades.BeforeTouchSize = New System.Drawing.Size(162, 21)
        Me.cboUnidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUnidades.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboUnidades.Location = New System.Drawing.Point(369, 60)
        Me.cboUnidades.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.cboUnidades.Name = "cboUnidades"
        Me.cboUnidades.Size = New System.Drawing.Size(162, 21)
        Me.cboUnidades.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboUnidades.TabIndex = 509
        '
        'textValUnidades
        '
        Me.textValUnidades.BackGroundColor = System.Drawing.Color.White
        Me.textValUnidades.BeforeTouchSize = New System.Drawing.Size(175, 22)
        Me.textValUnidades.BorderColor = System.Drawing.Color.Silver
        Me.textValUnidades.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.textValUnidades.CurrencyDecimalDigits = 3
        Me.textValUnidades.CurrencySymbol = ""
        Me.textValUnidades.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.textValUnidades.DecimalValue = New Decimal(New Integer() {0, 0, 0, 196608})
        Me.textValUnidades.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textValUnidades.ForeColor = System.Drawing.Color.Black
        Me.textValUnidades.Location = New System.Drawing.Point(534, 58)
        Me.textValUnidades.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.textValUnidades.MinimumSize = New System.Drawing.Size(14, 10)
        Me.textValUnidades.Name = "textValUnidades"
        Me.textValUnidades.NullString = ""
        Me.textValUnidades.PositiveColor = System.Drawing.Color.Black
        Me.textValUnidades.ReadOnly = True
        Me.textValUnidades.ReadOnlyBackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.textValUnidades.Size = New System.Drawing.Size(46, 23)
        Me.textValUnidades.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.textValUnidades.TabIndex = 510
        Me.textValUnidades.Text = "0.000"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Yu Gothic UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(33, 148)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(223, 19)
        Me.Label3.TabIndex = 511
        Me.Label3.Text = "Establecer conversión de unidades"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Yu Gothic", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label4.Location = New System.Drawing.Point(32, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(207, 18)
        Me.Label4.TabIndex = 512
        Me.Label4.Text = "Crear Equivalencias y Precios"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.LinkColor = System.Drawing.SystemColors.HotTrack
        Me.LinkLabel1.Location = New System.Drawing.Point(549, 154)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(35, 13)
        Me.LinkLabel1.TabIndex = 513
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Quitar"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Yu Gothic UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(33, 368)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(218, 19)
        Me.Label5.TabIndex = 514
        Me.Label5.Text = "Precios de venta por equivalencia"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.LinkColor = System.Drawing.SystemColors.HotTrack
        Me.LinkLabel2.Location = New System.Drawing.Point(549, 372)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(35, 13)
        Me.LinkLabel2.TabIndex = 516
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Quitar"
        '
        'GridEquivalencia
        '
        Me.GridEquivalencia.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        Me.GridEquivalencia.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.GridEquivalencia.BackColor = System.Drawing.SystemColors.Window
        Me.GridEquivalencia.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GridEquivalencia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridEquivalencia.FreezeCaption = False
        Me.GridEquivalencia.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.GridEquivalencia.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.GridEquivalencia.Location = New System.Drawing.Point(0, 0)
        Me.GridEquivalencia.Name = "GridEquivalencia"
        Me.GridEquivalencia.Size = New System.Drawing.Size(545, 186)
        Me.GridEquivalencia.TabIndex = 518
        Me.GridEquivalencia.TableDescriptor.AllowNew = False
        GridColumnDescriptor9.AllowSort = False
        GridColumnDescriptor9.HeaderImage = Nothing
        GridColumnDescriptor9.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor9.HeaderText = "ID"
        GridColumnDescriptor9.MappingName = "IDEQ"
        GridColumnDescriptor9.ReadOnly = True
        GridColumnDescriptor9.SerializedImageArray = ""
        GridColumnDescriptor9.Width = 0
        GridColumnDescriptor10.AllowSort = False
        GridColumnDescriptor10.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor10.HeaderImage = Nothing
        GridColumnDescriptor10.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor10.HeaderText = "Detalle"
        GridColumnDescriptor10.MappingName = "detalle"
        GridColumnDescriptor10.SerializedImageArray = ""
        GridColumnDescriptor10.Width = 225
        GridColumnDescriptor11.AllowSort = False
        GridColumnDescriptor11.Appearance.AnyRecordFieldCell.CellType = "Currency"
        GridColumnDescriptor11.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
        GridColumnDescriptor11.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor11.HeaderImage = Nothing
        GridColumnDescriptor11.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor11.HeaderText = "Fraccion de la unid."
        GridColumnDescriptor11.MappingName = "fraccion"
        GridColumnDescriptor11.SerializedImageArray = ""
        GridColumnDescriptor11.Width = 142
        GridColumnDescriptor12.AllowSort = False
        GridColumnDescriptor12.Appearance.AnyRecordFieldCell.CellType = "PushButton"
        GridColumnDescriptor12.HeaderImage = Nothing
        GridColumnDescriptor12.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor12.HeaderText = "Agregar"
        GridColumnDescriptor12.MappingName = "btNuevoPrecio"
        GridColumnDescriptor12.SerializedImageArray = ""
        Me.GridEquivalencia.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor9, GridColumnDescriptor10, GridColumnDescriptor11, GridColumnDescriptor12})
        Me.GridEquivalencia.TableDescriptor.TableOptions.CaptionRowHeight = 29
        Me.GridEquivalencia.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.GridEquivalencia.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.GridEquivalencia.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("IDEQ"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("detalle"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("fraccion"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("btNuevoPrecio")})
        Me.GridEquivalencia.Text = "gridGroupingControl1"
        Me.GridEquivalencia.VersionInfo = "12.2400.0.20"
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BorderColor = System.Drawing.Color.Silver
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.GridEquivalencia)
        Me.GradientPanel1.Location = New System.Drawing.Point(37, 172)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(547, 188)
        Me.GradientPanel1.TabIndex = 519
        '
        'GradientPanel2
        '
        Me.GradientPanel2.BorderColor = System.Drawing.Color.Silver
        Me.GradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel2.Controls.Add(Me.GridPrecios)
        Me.GradientPanel2.Location = New System.Drawing.Point(37, 394)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(547, 122)
        Me.GradientPanel2.TabIndex = 520
        '
        'GridPrecios
        '
        Me.GridPrecios.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        Me.GridPrecios.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.GridPrecios.BackColor = System.Drawing.SystemColors.Window
        Me.GridPrecios.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GridPrecios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridPrecios.FreezeCaption = False
        Me.GridPrecios.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.GridPrecios.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.GridPrecios.Location = New System.Drawing.Point(0, 0)
        Me.GridPrecios.Name = "GridPrecios"
        Me.GridPrecios.Size = New System.Drawing.Size(545, 120)
        Me.GridPrecios.TabIndex = 518
        Me.GridPrecios.TableDescriptor.AllowNew = False
        GridColumnDescriptor13.AllowSort = False
        GridColumnDescriptor13.HeaderImage = Nothing
        GridColumnDescriptor13.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor13.HeaderText = "ID"
        GridColumnDescriptor13.MappingName = "IdPrecio"
        GridColumnDescriptor13.ReadOnly = True
        GridColumnDescriptor13.SerializedImageArray = ""
        GridColumnDescriptor13.Width = 0
        GridColumnDescriptor14.AllowSort = False
        GridColumnDescriptor14.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor14.HeaderImage = Nothing
        GridColumnDescriptor14.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor14.HeaderText = "Detalle"
        GridColumnDescriptor14.MappingName = "detalle"
        GridColumnDescriptor14.SerializedImageArray = ""
        GridColumnDescriptor14.Width = 225
        GridColumnDescriptor15.AllowSort = False
        GridColumnDescriptor15.Appearance.AnyRecordFieldCell.CellType = "Currency"
        GridColumnDescriptor15.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
        GridColumnDescriptor15.Appearance.AnyRecordFieldCell.TextColor = System.Drawing.Color.Black
        GridColumnDescriptor15.HeaderImage = Nothing
        GridColumnDescriptor15.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor15.HeaderText = "Valor"
        GridColumnDescriptor15.MappingName = "fraccion"
        GridColumnDescriptor15.SerializedImageArray = ""
        GridColumnDescriptor15.Width = 107
        GridColumnDescriptor16.HeaderImage = Nothing
        GridColumnDescriptor16.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor16.MappingName = "idparent"
        GridColumnDescriptor16.ReadOnly = True
        GridColumnDescriptor16.SerializedImageArray = ""
        GridColumnDescriptor16.Width = 50
        Me.GridPrecios.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor13, GridColumnDescriptor14, GridColumnDescriptor15, GridColumnDescriptor16})
        Me.GridPrecios.TableDescriptor.TableOptions.CaptionRowHeight = 29
        Me.GridPrecios.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.GridPrecios.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.GridPrecios.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("IdPrecio"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("detalle"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("fraccion"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("idparent")})
        Me.GridPrecios.Text = "gridGroupingControl1"
        Me.GridPrecios.VersionInfo = "12.2400.0.20"
        '
        'BunifuThinButton27
        '
        Me.BunifuThinButton27.ActiveBorderThickness = 1
        Me.BunifuThinButton27.ActiveCornerRadius = 20
        Me.BunifuThinButton27.ActiveFillColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.BunifuThinButton27.ActiveForecolor = System.Drawing.Color.White
        Me.BunifuThinButton27.ActiveLineColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.BunifuThinButton27.BackColor = System.Drawing.Color.White
        Me.BunifuThinButton27.BackgroundImage = CType(resources.GetObject("BunifuThinButton27.BackgroundImage"), System.Drawing.Image)
        Me.BunifuThinButton27.ButtonText = "Aceptar"
        Me.BunifuThinButton27.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuThinButton27.Font = New System.Drawing.Font("Century Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuThinButton27.ForeColor = System.Drawing.Color.Black
        Me.BunifuThinButton27.IdleBorderThickness = 1
        Me.BunifuThinButton27.IdleCornerRadius = 20
        Me.BunifuThinButton27.IdleFillColor = System.Drawing.Color.White
        Me.BunifuThinButton27.IdleForecolor = System.Drawing.Color.Black
        Me.BunifuThinButton27.IdleLineColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.BunifuThinButton27.Location = New System.Drawing.Point(248, 520)
        Me.BunifuThinButton27.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BunifuThinButton27.Name = "BunifuThinButton27"
        Me.BunifuThinButton27.Size = New System.Drawing.Size(121, 43)
        Me.BunifuThinButton27.TabIndex = 521
        Me.BunifuThinButton27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FormCrearEquivalenciasArticulo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionForeColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(623, 562)
        Me.Controls.Add(Me.BunifuThinButton27)
        Me.Controls.Add(Me.GradientPanel2)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Controls.Add(Me.LinkLabel2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.textValUnidades)
        Me.Controls.Add(Me.cboUnidades)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BunifuThinButton26)
        Me.Controls.Add(Me.BunifuThinButton25)
        Me.Controls.Add(Me.BunifuThinButton24)
        Me.Controls.Add(Me.BunifuThinButton23)
        Me.Controls.Add(Me.BunifuThinButton22)
        Me.Controls.Add(Me.BunifuThinButton21)
        Me.Controls.Add(Me.txtProveedor)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FormCrearEquivalenciasArticulo"
        Me.ShowIcon = False
        Me.Text = "Crear Equivalencias Articulo"
        CType(Me.txtProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboUnidades, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.textValUnidades, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridEquivalencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        CType(Me.GridPrecios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtProveedor As Tools.TextBoxExt
    Friend WithEvents BunifuThinButton26 As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents BunifuThinButton25 As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents BunifuThinButton24 As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents BunifuThinButton23 As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents BunifuThinButton22 As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents BunifuThinButton21 As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents Label2 As Label
    Friend WithEvents cboUnidades As Tools.ComboBoxAdv
    Friend WithEvents textValUnidades As Tools.CurrencyTextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Label5 As Label
    Friend WithEvents LinkLabel2 As LinkLabel
    Private WithEvents GridEquivalencia As Grid.Grouping.GridGroupingControl
    Friend WithEvents GradientPanel1 As Tools.GradientPanel
    Friend WithEvents GradientPanel2 As Tools.GradientPanel
    Private WithEvents GridPrecios As Grid.Grouping.GridGroupingControl
    Friend WithEvents BunifuThinButton27 As Bunifu.Framework.UI.BunifuThinButton2
End Class

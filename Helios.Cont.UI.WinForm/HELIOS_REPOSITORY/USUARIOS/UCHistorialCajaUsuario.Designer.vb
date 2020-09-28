<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UCHistorialCajaUsuario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCHistorialCajaUsuario))
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.BunifuFlatButton6 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.BunifuFlatButton5 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.BunifuFlatButton4 = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.sliderTop = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextAnio = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.cboMesCompra = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ListViewHistorialCajas = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ComboUsuarios = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.LabelTotalSaldoUSD = New System.Windows.Forms.Label()
        Me.LabelTotalSaldo = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LabelTotalGastosUSD = New System.Windows.Forms.Label()
        Me.LabelTotalGastos = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.LabelTotalVentasUSD = New System.Windows.Forms.Label()
        Me.LabelTotalVentas = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.gridGroupingControl1 = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.Line21 = New Helios.Cont.Presentation.WinForm.Line2()
        Me.LabelFondoInicio = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LabelFondoInicioUSD = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.sliderTop, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextAnio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboMesCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        CType(Me.ComboUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.gridGroupingControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BackColor = System.Drawing.Color.White
        Me.GradientPanel1.BorderColor = System.Drawing.Color.Gainsboro
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.BunifuFlatButton6)
        Me.GradientPanel1.Controls.Add(Me.BunifuFlatButton5)
        Me.GradientPanel1.Controls.Add(Me.BunifuFlatButton4)
        Me.GradientPanel1.Controls.Add(Me.sliderTop)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(994, 0)
        Me.GradientPanel1.TabIndex = 1
        '
        'BunifuFlatButton6
        '
        Me.BunifuFlatButton6.Activecolor = System.Drawing.Color.White
        Me.BunifuFlatButton6.BackColor = System.Drawing.Color.White
        Me.BunifuFlatButton6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton6.BorderRadius = 0
        Me.BunifuFlatButton6.ButtonText = "Historial de cajas"
        Me.BunifuFlatButton6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton6.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton6.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BunifuFlatButton6.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton6.Iconimage = Nothing
        Me.BunifuFlatButton6.Iconimage_right = Nothing
        Me.BunifuFlatButton6.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton6.Iconimage_Selected = Nothing
        Me.BunifuFlatButton6.IconMarginLeft = 0
        Me.BunifuFlatButton6.IconMarginRight = 0
        Me.BunifuFlatButton6.IconRightVisible = True
        Me.BunifuFlatButton6.IconRightZoom = 0R
        Me.BunifuFlatButton6.IconVisible = True
        Me.BunifuFlatButton6.IconZoom = 90.0R
        Me.BunifuFlatButton6.IsTab = False
        Me.BunifuFlatButton6.Location = New System.Drawing.Point(1, 7)
        Me.BunifuFlatButton6.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton6.Name = "BunifuFlatButton6"
        Me.BunifuFlatButton6.Normalcolor = System.Drawing.Color.White
        Me.BunifuFlatButton6.OnHovercolor = System.Drawing.Color.White
        Me.BunifuFlatButton6.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton6.selected = False
        Me.BunifuFlatButton6.Size = New System.Drawing.Size(106, 18)
        Me.BunifuFlatButton6.TabIndex = 28
        Me.BunifuFlatButton6.Text = "Historial de cajas"
        Me.BunifuFlatButton6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton6.Textcolor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BunifuFlatButton6.TextFont = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'BunifuFlatButton5
        '
        Me.BunifuFlatButton5.Activecolor = System.Drawing.Color.White
        Me.BunifuFlatButton5.BackColor = System.Drawing.Color.White
        Me.BunifuFlatButton5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton5.BorderRadius = 0
        Me.BunifuFlatButton5.ButtonText = "Cajas activas"
        Me.BunifuFlatButton5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuFlatButton5.DisabledColor = System.Drawing.Color.Gray
        Me.BunifuFlatButton5.Enabled = False
        Me.BunifuFlatButton5.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuFlatButton5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BunifuFlatButton5.Iconcolor = System.Drawing.Color.Transparent
        Me.BunifuFlatButton5.Iconimage = Nothing
        Me.BunifuFlatButton5.Iconimage_right = Nothing
        Me.BunifuFlatButton5.Iconimage_right_Selected = Nothing
        Me.BunifuFlatButton5.Iconimage_Selected = Nothing
        Me.BunifuFlatButton5.IconMarginLeft = 0
        Me.BunifuFlatButton5.IconMarginRight = 0
        Me.BunifuFlatButton5.IconRightVisible = True
        Me.BunifuFlatButton5.IconRightZoom = 0R
        Me.BunifuFlatButton5.IconVisible = True
        Me.BunifuFlatButton5.IconZoom = 90.0R
        Me.BunifuFlatButton5.IsTab = False
        Me.BunifuFlatButton5.Location = New System.Drawing.Point(111, 7)
        Me.BunifuFlatButton5.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton5.Name = "BunifuFlatButton5"
        Me.BunifuFlatButton5.Normalcolor = System.Drawing.Color.White
        Me.BunifuFlatButton5.OnHovercolor = System.Drawing.Color.White
        Me.BunifuFlatButton5.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton5.selected = False
        Me.BunifuFlatButton5.Size = New System.Drawing.Size(92, 18)
        Me.BunifuFlatButton5.TabIndex = 27
        Me.BunifuFlatButton5.Text = "Cajas activas"
        Me.BunifuFlatButton5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton5.Textcolor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BunifuFlatButton5.TextFont = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'BunifuFlatButton4
        '
        Me.BunifuFlatButton4.Activecolor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.BunifuFlatButton4.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.BunifuFlatButton4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuFlatButton4.BorderRadius = 5
        Me.BunifuFlatButton4.ButtonText = "Nuevo"
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
        Me.BunifuFlatButton4.Location = New System.Drawing.Point(230, 4)
        Me.BunifuFlatButton4.Margin = New System.Windows.Forms.Padding(2)
        Me.BunifuFlatButton4.Name = "BunifuFlatButton4"
        Me.BunifuFlatButton4.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.BunifuFlatButton4.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.BunifuFlatButton4.OnHoverTextColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.BunifuFlatButton4.selected = False
        Me.BunifuFlatButton4.Size = New System.Drawing.Size(108, 23)
        Me.BunifuFlatButton4.TabIndex = 26
        Me.BunifuFlatButton4.Text = "Nuevo"
        Me.BunifuFlatButton4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.BunifuFlatButton4.Textcolor = System.Drawing.Color.White
        Me.BunifuFlatButton4.TextFont = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'sliderTop
        '
        Me.sliderTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.sliderTop.Location = New System.Drawing.Point(-1, 27)
        Me.sliderTop.Name = "sliderTop"
        Me.sliderTop.Size = New System.Drawing.Size(106, 3)
        Me.sliderTop.TabIndex = 11
        Me.sliderTop.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(19, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Período/mes"
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
        Me.TextAnio.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextAnio.DecimalValue = New Decimal(New Integer() {2019, 0, 0, 0})
        Me.TextAnio.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextAnio.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.TextAnio.Location = New System.Drawing.Point(178, 92)
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
        Me.TextAnio.TabIndex = 14
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
        Me.cboMesCompra.Location = New System.Drawing.Point(22, 95)
        Me.cboMesCompra.Name = "cboMesCompra"
        Me.cboMesCompra.Size = New System.Drawing.Size(151, 21)
        Me.cboMesCompra.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Black
        Me.cboMesCompra.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label2.Location = New System.Drawing.Point(19, 135)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(157, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Resúmen de cajas registradas"
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
        Me.ListViewHistorialCajas.Size = New System.Drawing.Size(344, 352)
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
        'GradientPanel2
        '
        Me.GradientPanel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GradientPanel2.BorderColor = System.Drawing.Color.Silver
        Me.GradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel2.Controls.Add(Me.ListViewHistorialCajas)
        Me.GradientPanel2.Location = New System.Drawing.Point(22, 157)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(346, 354)
        Me.GradientPanel2.TabIndex = 17
        '
        'ComboUsuarios
        '
        Me.ComboUsuarios.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.ComboUsuarios.BeforeTouchSize = New System.Drawing.Size(301, 21)
        Me.ComboUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboUsuarios.FlatBorderColor = System.Drawing.Color.Gray
        Me.ComboUsuarios.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboUsuarios.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.ComboUsuarios.Location = New System.Drawing.Point(22, 37)
        Me.ComboUsuarios.Name = "ComboUsuarios"
        Me.ComboUsuarios.Size = New System.Drawing.Size(301, 21)
        Me.ComboUsuarios.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Black
        Me.ComboUsuarios.TabIndex = 21
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(253, 92)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(39, 25)
        Me.Button1.TabIndex = 22
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label4.Location = New System.Drawing.Point(20, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Usuarios"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(22, Byte), Integer))
        Me.Panel3.Controls.Add(Me.LabelTotalSaldoUSD)
        Me.Panel3.Controls.Add(Me.LabelTotalSaldo)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Location = New System.Drawing.Point(804, 33)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(172, 99)
        Me.Panel3.TabIndex = 698
        '
        'LabelTotalSaldoUSD
        '
        Me.LabelTotalSaldoUSD.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LabelTotalSaldoUSD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelTotalSaldoUSD.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTotalSaldoUSD.ForeColor = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.LabelTotalSaldoUSD.Location = New System.Drawing.Point(0, 37)
        Me.LabelTotalSaldoUSD.Name = "LabelTotalSaldoUSD"
        Me.LabelTotalSaldoUSD.Size = New System.Drawing.Size(172, 36)
        Me.LabelTotalSaldoUSD.TabIndex = 700
        Me.LabelTotalSaldoUSD.Text = "$0.00"
        Me.LabelTotalSaldoUSD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelTotalSaldo
        '
        Me.LabelTotalSaldo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LabelTotalSaldo.Dock = System.Windows.Forms.DockStyle.Top
        Me.LabelTotalSaldo.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTotalSaldo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.LabelTotalSaldo.Location = New System.Drawing.Point(0, 0)
        Me.LabelTotalSaldo.Name = "LabelTotalSaldo"
        Me.LabelTotalSaldo.Size = New System.Drawing.Size(172, 37)
        Me.LabelTotalSaldo.TabIndex = 56
        Me.LabelTotalSaldo.Text = "S/0.00"
        Me.LabelTotalSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label11.Font = New System.Drawing.Font("Yu Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(0, 73)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(172, 26)
        Me.Label11.TabIndex = 691
        Me.Label11.Text = "Saldo en caja"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(22, Byte), Integer))
        Me.Panel1.Controls.Add(Me.LabelTotalGastosUSD)
        Me.Panel1.Controls.Add(Me.LabelTotalGastos)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Location = New System.Drawing.Point(597, 33)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(201, 99)
        Me.Panel1.TabIndex = 697
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
        'Label9
        '
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label9.Font = New System.Drawing.Font("Yu Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Silver
        Me.Label9.Location = New System.Drawing.Point(0, 73)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(201, 26)
        Me.Label9.TabIndex = 691
        Me.Label9.Text = "Total Gastos "
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(22, Byte), Integer))
        Me.Panel2.Controls.Add(Me.LabelTotalVentasUSD)
        Me.Panel2.Controls.Add(Me.LabelTotalVentas)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Location = New System.Drawing.Point(395, 33)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(195, 99)
        Me.Panel2.TabIndex = 696
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
        'Label8
        '
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label8.Font = New System.Drawing.Font("Yu Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Silver
        Me.Label8.Location = New System.Drawing.Point(0, 73)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(195, 26)
        Me.Label8.TabIndex = 691
        Me.Label8.Text = "Ventas e ingresos"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.gridGroupingControl1.Location = New System.Drawing.Point(396, 138)
        Me.gridGroupingControl1.Name = "gridGroupingControl1"
        Me.gridGroupingControl1.Office2010ScrollBarsColorScheme = Syncfusion.Windows.Forms.Office2010ColorScheme.Black
        Me.gridGroupingControl1.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.gridGroupingControl1.Size = New System.Drawing.Size(580, 372)
        Me.gridGroupingControl1.TabIndex = 699
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
        'Line21
        '
        Me.Line21.LineColor = System.Drawing.Color.Gray
        Me.Line21.Location = New System.Drawing.Point(381, 9)
        Me.Line21.Name = "Line21"
        Me.Line21.Size = New System.Drawing.Size(1, 510)
        Me.Line21.TabIndex = 18
        Me.Line21.Text = "Line21"
        '
        'LabelFondoInicio
        '
        Me.LabelFondoInicio.AutoSize = True
        Me.LabelFondoInicio.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LabelFondoInicio.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelFondoInicio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LabelFondoInicio.Location = New System.Drawing.Point(517, 7)
        Me.LabelFondoInicio.Name = "LabelFondoInicio"
        Me.LabelFondoInicio.Size = New System.Drawing.Size(57, 21)
        Me.LabelFondoInicio.TabIndex = 56
        Me.LabelFondoInicio.Text = "S/0.00"
        Me.LabelFondoInicio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Yu Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(161, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(404, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(107, 18)
        Me.Label5.TabIndex = 691
        Me.Label5.Text = "Fondo de inicio"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelFondoInicioUSD
        '
        Me.LabelFondoInicioUSD.AutoSize = True
        Me.LabelFondoInicioUSD.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LabelFondoInicioUSD.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelFondoInicioUSD.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LabelFondoInicioUSD.Location = New System.Drawing.Point(748, 5)
        Me.LabelFondoInicioUSD.Name = "LabelFondoInicioUSD"
        Me.LabelFondoInicioUSD.Size = New System.Drawing.Size(50, 21)
        Me.LabelFondoInicioUSD.TabIndex = 700
        Me.LabelFondoInicioUSD.Text = "$0.00"
        Me.LabelFondoInicioUSD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Yu Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(161, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(599, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(136, 18)
        Me.Label3.TabIndex = 701
        Me.Label3.Text = "Fondo de inicio Usd"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button2
        '
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(334, 33)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(39, 25)
        Me.Button2.TabIndex = 702
        Me.Button2.UseVisualStyleBackColor = True
        '
        'UCHistorialCajaUsuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LabelFondoInicioUSD)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LabelFondoInicio)
        Me.Controls.Add(Me.gridGroupingControl1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ComboUsuarios)
        Me.Controls.Add(Me.Line21)
        Me.Controls.Add(Me.GradientPanel2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextAnio)
        Me.Controls.Add(Me.cboMesCompra)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "UCHistorialCajaUsuario"
        Me.Size = New System.Drawing.Size(994, 526)
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        CType(Me.sliderTop, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextAnio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboMesCompra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        CType(Me.ComboUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.gridGroupingControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Private WithEvents BunifuFlatButton6 As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents BunifuFlatButton5 As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents BunifuFlatButton4 As Bunifu.Framework.UI.BunifuFlatButton
    Private WithEvents sliderTop As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TextAnio As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents cboMesCompra As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label2 As Label
    Friend WithEvents ListViewHistorialCajas As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents GradientPanel2 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents Line21 As Line2
    Friend WithEvents ComboUsuarios As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Button1 As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents LabelTotalSaldo As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents LabelTotalGastos As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents LabelTotalVentas As Label
    Friend WithEvents Label8 As Label
    Private WithEvents gridGroupingControl1 As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents LabelFondoInicio As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents LabelTotalSaldoUSD As Label
    Friend WithEvents LabelTotalGastosUSD As Label
    Friend WithEvents LabelTotalVentasUSD As Label
    Friend WithEvents LabelFondoInicioUSD As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Button2 As Button
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCCierresDelPeriodo
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCCierresDelPeriodo))
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.cboAnio = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtImpuestoRenta = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.txtUilidad = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.chValidarCierre = New System.Windows.Forms.CheckBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cboMesCompra = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.txtDia = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Cerrar = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel5 = New System.Windows.Forms.LinkLabel()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.bg = New System.ComponentModel.BackgroundWorker()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        CType(Me.cboAnio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtImpuestoRenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUilidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboMesCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(505, 82)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(100, 23)
        Me.ProgressBar1.TabIndex = 525
        Me.ProgressBar1.Visible = False
        '
        'cboAnio
        '
        Me.cboAnio.BackColor = System.Drawing.Color.White
        Me.cboAnio.BeforeTouchSize = New System.Drawing.Size(60, 21)
        Me.cboAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAnio.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAnio.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboAnio.Location = New System.Drawing.Point(197, 41)
        Me.cboAnio.Name = "cboAnio"
        Me.cboAnio.Office2007ColorTheme = Syncfusion.Windows.Forms.Office2007Theme.Black
        Me.cboAnio.Office2010ColorTheme = Syncfusion.Windows.Forms.Office2010Theme.Black
        Me.cboAnio.Size = New System.Drawing.Size(60, 21)
        Me.cboAnio.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboAnio.TabIndex = 524
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtImpuestoRenta)
        Me.GroupBox1.Controls.Add(Me.txtUilidad)
        Me.GroupBox1.Location = New System.Drawing.Point(447, 15)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(282, 68)
        Me.GroupBox1.TabIndex = 523
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cierre de Resultados"
        Me.GroupBox1.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Corbel", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 13)
        Me.Label1.TabIndex = 510
        Me.Label1.Text = "Resultado del Ejercicio"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Corbel", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(149, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 511
        Me.Label3.Text = "Utilidad"
        '
        'txtImpuestoRenta
        '
        Me.txtImpuestoRenta.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtImpuestoRenta.BeforeTouchSize = New System.Drawing.Size(119, 21)
        Me.txtImpuestoRenta.BorderColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtImpuestoRenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtImpuestoRenta.DecimalPlaces = 2
        Me.txtImpuestoRenta.Font = New System.Drawing.Font("Arial", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImpuestoRenta.ForeColor = System.Drawing.Color.Black
        Me.txtImpuestoRenta.Location = New System.Drawing.Point(9, 36)
        Me.txtImpuestoRenta.Maximum = New Decimal(New Integer() {-159383552, 46653770, 5421, 0})
        Me.txtImpuestoRenta.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtImpuestoRenta.Minimum = New Decimal(New Integer() {-159383552, 46653770, 5421, -2147483648})
        Me.txtImpuestoRenta.Name = "txtImpuestoRenta"
        Me.txtImpuestoRenta.Size = New System.Drawing.Size(119, 21)
        Me.txtImpuestoRenta.TabIndex = 508
        Me.txtImpuestoRenta.TabStop = False
        Me.txtImpuestoRenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtImpuestoRenta.ThousandsSeparator = True
        Me.txtImpuestoRenta.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'txtUilidad
        '
        Me.txtUilidad.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtUilidad.BeforeTouchSize = New System.Drawing.Size(119, 21)
        Me.txtUilidad.BorderColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtUilidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUilidad.DecimalPlaces = 2
        Me.txtUilidad.Font = New System.Drawing.Font("Arial", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUilidad.ForeColor = System.Drawing.Color.Black
        Me.txtUilidad.Location = New System.Drawing.Point(152, 36)
        Me.txtUilidad.Maximum = New Decimal(New Integer() {-159383552, 46653770, 5421, 0})
        Me.txtUilidad.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(157, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtUilidad.Name = "txtUilidad"
        Me.txtUilidad.Size = New System.Drawing.Size(119, 21)
        Me.txtUilidad.TabIndex = 509
        Me.txtUilidad.TabStop = False
        Me.txtUilidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtUilidad.ThousandsSeparator = True
        Me.txtUilidad.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'chValidarCierre
        '
        Me.chValidarCierre.AutoSize = True
        Me.chValidarCierre.Checked = True
        Me.chValidarCierre.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chValidarCierre.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chValidarCierre.Location = New System.Drawing.Point(263, 45)
        Me.chValidarCierre.Name = "chValidarCierre"
        Me.chValidarCierre.Size = New System.Drawing.Size(132, 18)
        Me.chValidarCierre.TabIndex = 522
        Me.chValidarCierre.Text = "Validar cierre anterior"
        Me.chValidarCierre.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.OrangeRed
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Corbel", 8.5!)
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(115, 75)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(99, 30)
        Me.Button2.TabIndex = 521
        Me.Button2.Text = "Actualizar"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.DimGray
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Corbel", 8.5!)
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(12, 75)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(99, 30)
        Me.Button1.TabIndex = 520
        Me.Button1.Text = "Eliminar Cierre"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'cboMesCompra
        '
        Me.cboMesCompra.BackColor = System.Drawing.Color.White
        Me.cboMesCompra.BeforeTouchSize = New System.Drawing.Size(127, 21)
        Me.cboMesCompra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMesCompra.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMesCompra.Location = New System.Drawing.Point(12, 41)
        Me.cboMesCompra.Name = "cboMesCompra"
        Me.cboMesCompra.Size = New System.Drawing.Size(127, 21)
        Me.cboMesCompra.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboMesCompra.TabIndex = 519
        '
        'txtDia
        '
        Me.txtDia.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtDia.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtDia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDia.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtDia.Checked = False
        Me.txtDia.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtDia.CustomFormat = "dd"
        Me.txtDia.DropDownImage = Nothing
        Me.txtDia.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtDia.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtDia.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtDia.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDia.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtDia.Location = New System.Drawing.Point(145, 42)
        Me.txtDia.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtDia.MinValue = New Date(CType(0, Long))
        Me.txtDia.Name = "txtDia"
        Me.txtDia.ShowCheckBox = False
        Me.txtDia.ShowDropButton = False
        Me.txtDia.ShowUpDown = True
        Me.txtDia.Size = New System.Drawing.Size(50, 20)
        Me.txtDia.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtDia.TabIndex = 518
        Me.txtDia.Value = New Date(2016, 1, 1, 11, 17, 0, 0)
        '
        'Cerrar
        '
        Me.Cerrar.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.Cerrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Cerrar.BeforeTouchSize = New System.Drawing.Size(100, 30)
        Me.Cerrar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cerrar.ForeColor = System.Drawing.Color.White
        Me.Cerrar.Image = CType(resources.GetObject("Cerrar.Image"), System.Drawing.Image)
        Me.Cerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cerrar.IsBackStageButton = False
        Me.Cerrar.Location = New System.Drawing.Point(399, 75)
        Me.Cerrar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(188, Byte), Integer))
        Me.Cerrar.Name = "Cerrar"
        Me.Cerrar.Size = New System.Drawing.Size(100, 30)
        Me.Cerrar.TabIndex = 517
        Me.Cerrar.Text = "Cerrar mes"
        Me.Cerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cerrar.UseVisualStyle = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Corbel", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 13)
        Me.Label2.TabIndex = 516
        Me.Label2.Text = "CIERRE DEL PERIODO"
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(100, 30)
        Me.ButtonAdv1.Font = New System.Drawing.Font("Corbel", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(217, 75)
        Me.ButtonAdv1.MetroColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(188, Byte), Integer))
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(100, 30)
        Me.ButtonAdv1.TabIndex = 515
        Me.ButtonAdv1.Text = "Cancelar / salir"
        Me.ButtonAdv1.UseVisualStyle = True
        Me.ButtonAdv1.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.LinkLabel4)
        Me.Panel1.Controls.Add(Me.LinkLabel1)
        Me.Panel1.Controls.Add(Me.LinkLabel2)
        Me.Panel1.Controls.Add(Me.LinkLabel3)
        Me.Panel1.Controls.Add(Me.LinkLabel5)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(832, 348)
        Me.Panel1.TabIndex = 526
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView1.Font = New System.Drawing.Font("Ebrima", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.FullRowSelect = True
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(0, 0)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(832, 235)
        Me.ListView1.TabIndex = 1
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "año"
        Me.ColumnHeader1.Width = 73
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "..."
        Me.ColumnHeader2.Width = 0
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Mes"
        Me.ColumnHeader3.Width = 130
        '
        'LinkLabel4
        '
        Me.LinkLabel4.AutoSize = True
        Me.LinkLabel4.Font = New System.Drawing.Font("Ebrima", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel4.ForeColor = System.Drawing.Color.Gray
        Me.LinkLabel4.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel4.LinkColor = System.Drawing.Color.DimGray
        Me.LinkLabel4.Location = New System.Drawing.Point(328, 39)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(152, 15)
        Me.LinkLabel4.TabIndex = 4
        Me.LinkLabel4.TabStop = True
        Me.LinkLabel4.Text = "Cierre de Costo de Ventas ..."
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Ebrima", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.ForeColor = System.Drawing.Color.Gray
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.DimGray
        Me.LinkLabel1.Location = New System.Drawing.Point(327, 39)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(126, 15)
        Me.LinkLabel1.TabIndex = 0
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Cierre de Inventarios ..."
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Font = New System.Drawing.Font("Ebrima", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel2.ForeColor = System.Drawing.Color.Gray
        Me.LinkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel2.LinkColor = System.Drawing.Color.DimGray
        Me.LinkLabel2.Location = New System.Drawing.Point(327, 39)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(172, 15)
        Me.LinkLabel2.TabIndex = 2
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Cierre de Cuentas Financieras ..."
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.Font = New System.Drawing.Font("Ebrima", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel3.ForeColor = System.Drawing.Color.Gray
        Me.LinkLabel3.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel3.LinkColor = System.Drawing.Color.DimGray
        Me.LinkLabel3.Location = New System.Drawing.Point(328, 39)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(165, 15)
        Me.LinkLabel3.TabIndex = 3
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "Cierre de Cuentas Contables ..."
        '
        'LinkLabel5
        '
        Me.LinkLabel5.AutoSize = True
        Me.LinkLabel5.Font = New System.Drawing.Font("Ebrima", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel5.ForeColor = System.Drawing.Color.Gray
        Me.LinkLabel5.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.LinkLabel5.LinkColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.LinkLabel5.Location = New System.Drawing.Point(65, 39)
        Me.LinkLabel5.Name = "LinkLabel5"
        Me.LinkLabel5.Size = New System.Drawing.Size(92, 15)
        Me.LinkLabel5.TabIndex = 7
        Me.LinkLabel5.TabStop = True
        Me.LinkLabel5.Text = "Maestro general"
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(188, Byte), Integer))
        Me.GradientPanel1.BorderSides = System.Windows.Forms.Border3DSide.Top
        Me.GradientPanel1.BorderSingle = System.Windows.Forms.ButtonBorderStyle.Dotted
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(832, 28)
        Me.GradientPanel1.TabIndex = 527
        '
        'GradientPanel2
        '
        Me.GradientPanel2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(188, Byte), Integer))
        Me.GradientPanel2.BorderSides = System.Windows.Forms.Border3DSide.Top
        Me.GradientPanel2.BorderSingle = System.Windows.Forms.ButtonBorderStyle.Dotted
        Me.GradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 28)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(832, 20)
        Me.GradientPanel2.TabIndex = 528
        '
        'bg
        '
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GradientPanel2)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.GradientPanel1)
        Me.Panel2.Controls.Add(Me.ButtonAdv1)
        Me.Panel2.Controls.Add(Me.Cerrar)
        Me.Panel2.Controls.Add(Me.txtDia)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.ProgressBar1)
        Me.Panel2.Controls.Add(Me.cboMesCompra)
        Me.Panel2.Controls.Add(Me.cboAnio)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Controls.Add(Me.chValidarCierre)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(832, 113)
        Me.Panel2.TabIndex = 529
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.ListView1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 113)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(832, 235)
        Me.Panel3.TabIndex = 530
        '
        'UCCierresDelPeriodo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Panel1)
        Me.Name = "UCCierresDelPeriodo"
        Me.Size = New System.Drawing.Size(832, 348)
        CType(Me.cboAnio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtImpuestoRenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUilidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboMesCompra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents cboAnio As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtImpuestoRenta As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents txtUilidad As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents chValidarCierre As CheckBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents cboMesCompra As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents txtDia As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents Cerrar As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents Label2 As Label
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ListView1 As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents LinkLabel4 As LinkLabel
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents LinkLabel5 As LinkLabel
    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents GradientPanel2 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents bg As System.ComponentModel.BackgroundWorker
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
End Class

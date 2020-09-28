<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmselectCierre
    Inherits frmMaster

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmselectCierre))
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.LinkLabel5 = New System.Windows.Forms.LinkLabel()
        Me.bg = New System.ComponentModel.BackgroundWorker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Cerrar = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.cboMesCompra = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.txtDia = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.chValidarCierre = New System.Windows.Forms.CheckBox()
        Me.txtImpuestoRenta = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.txtUilidad = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboAnio = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboMesCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.txtImpuestoRenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUilidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.cboAnio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        'GradientPanel1
        '
        Me.GradientPanel1.BorderColor = System.Drawing.Color.OrangeRed
        Me.GradientPanel1.BorderSides = System.Windows.Forms.Border3DSide.Top
        Me.GradientPanel1.BorderSingle = System.Windows.Forms.ButtonBorderStyle.Dotted
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(688, 10)
        Me.GradientPanel1.TabIndex = 5
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(100, 30)
        Me.ButtonAdv1.Font = New System.Drawing.Font("Corbel", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(217, 81)
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(100, 30)
        Me.ButtonAdv1.TabIndex = 6
        Me.ButtonAdv1.Text = "Cancelar / salir"
        Me.ButtonAdv1.UseVisualStyle = True
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
        'bg
        '
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Corbel", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "CIERRE DEL PERIODO"
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
        Me.Cerrar.Location = New System.Drawing.Point(399, 81)
        Me.Cerrar.Name = "Cerrar"
        Me.Cerrar.Size = New System.Drawing.Size(100, 30)
        Me.Cerrar.TabIndex = 10
        Me.Cerrar.Text = "Cerrar mes"
        Me.Cerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cerrar.UseVisualStyle = True
        '
        'cboMesCompra
        '
        Me.cboMesCompra.BackColor = System.Drawing.Color.White
        Me.cboMesCompra.BeforeTouchSize = New System.Drawing.Size(127, 21)
        Me.cboMesCompra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMesCompra.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMesCompra.Location = New System.Drawing.Point(12, 47)
        Me.cboMesCompra.Name = "cboMesCompra"
        Me.cboMesCompra.Size = New System.Drawing.Size(127, 21)
        Me.cboMesCompra.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboMesCompra.TabIndex = 502
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
        Me.txtDia.Location = New System.Drawing.Point(145, 48)
        Me.txtDia.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtDia.MinValue = New Date(CType(0, Long))
        Me.txtDia.Name = "txtDia"
        Me.txtDia.ShowCheckBox = False
        Me.txtDia.ShowDropButton = False
        Me.txtDia.ShowUpDown = True
        Me.txtDia.Size = New System.Drawing.Size(50, 20)
        Me.txtDia.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtDia.TabIndex = 501
        Me.txtDia.Value = New Date(2016, 1, 1, 11, 17, 0, 0)
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ListView1)
        Me.Panel1.Controls.Add(Me.LinkLabel4)
        Me.Panel1.Controls.Add(Me.LinkLabel1)
        Me.Panel1.Controls.Add(Me.LinkLabel2)
        Me.Panel1.Controls.Add(Me.LinkLabel3)
        Me.Panel1.Controls.Add(Me.LinkLabel5)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 121)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(688, 178)
        Me.Panel1.TabIndex = 504
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
        Me.ListView1.Size = New System.Drawing.Size(688, 178)
        Me.ListView1.TabIndex = 1
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "año"
        Me.ColumnHeader1.Width = 98
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
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.OrangeRed
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Corbel", 8.5!)
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(115, 81)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(99, 30)
        Me.Button2.TabIndex = 506
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
        Me.Button1.Location = New System.Drawing.Point(12, 81)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(99, 30)
        Me.Button1.TabIndex = 505
        Me.Button1.Text = "Eliminar Cierre"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'chValidarCierre
        '
        Me.chValidarCierre.AutoSize = True
        Me.chValidarCierre.Checked = True
        Me.chValidarCierre.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chValidarCierre.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chValidarCierre.Location = New System.Drawing.Point(263, 51)
        Me.chValidarCierre.Name = "chValidarCierre"
        Me.chValidarCierre.Size = New System.Drawing.Size(132, 18)
        Me.chValidarCierre.TabIndex = 507
        Me.chValidarCierre.Text = "Validar cierre anterior"
        Me.chValidarCierre.UseVisualStyleBackColor = True
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtImpuestoRenta)
        Me.GroupBox1.Controls.Add(Me.txtUilidad)
        Me.GroupBox1.Location = New System.Drawing.Point(397, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(282, 68)
        Me.GroupBox1.TabIndex = 512
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cierre de Resultados"
        Me.GroupBox1.Visible = False
        '
        'cboAnio
        '
        Me.cboAnio.BackColor = System.Drawing.Color.White
        Me.cboAnio.BeforeTouchSize = New System.Drawing.Size(60, 21)
        Me.cboAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAnio.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAnio.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboAnio.Location = New System.Drawing.Point(197, 47)
        Me.cboAnio.Name = "cboAnio"
        Me.cboAnio.Office2007ColorTheme = Syncfusion.Windows.Forms.Office2007Theme.Black
        Me.cboAnio.Office2010ColorTheme = Syncfusion.Windows.Forms.Office2010Theme.Black
        Me.cboAnio.Size = New System.Drawing.Size(60, 21)
        Me.cboAnio.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboAnio.TabIndex = 513
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(505, 88)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(100, 23)
        Me.ProgressBar1.TabIndex = 514
        Me.ProgressBar1.Visible = False
        '
        'frmselectCierre
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.Color.White
        Me.CaptionBarHeight = 55
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(15, 15)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(35, 35)
        Me.CaptionImages.Add(CaptionImage1)
        Me.ClientSize = New System.Drawing.Size(688, 299)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.cboAnio)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.chValidarCierre)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.cboMesCompra)
        Me.Controls.Add(Me.txtDia)
        Me.Controls.Add(Me.Cerrar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ButtonAdv1)
        Me.Controls.Add(Me.GradientPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmselectCierre"
        Me.ShowIcon = False
        Me.Text = ""
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboMesCompra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.txtImpuestoRenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUilidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.cboAnio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents LinkLabel4 As LinkLabel
    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents LinkLabel5 As LinkLabel
    Friend WithEvents bg As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label2 As Label
    Friend WithEvents Cerrar As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents cboMesCompra As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents txtDia As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents chValidarCierre As System.Windows.Forms.CheckBox
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtImpuestoRenta As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents txtUilidad As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboAnio As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents ProgressBar1 As ProgressBar
End Class

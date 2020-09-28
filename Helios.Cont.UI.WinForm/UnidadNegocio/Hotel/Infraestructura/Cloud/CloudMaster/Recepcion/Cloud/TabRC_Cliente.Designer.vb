Imports Syncfusion.Windows.Forms
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TabRC_Cliente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TabRC_Cliente))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnRetorno = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextProveedor = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextNumIdentrazon = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.pnPrincipal = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.textBox1 = New System.Windows.Forms.TextBox()
        Me.MonthCalendarAdv2 = New Syncfusion.Windows.Forms.Tools.MonthCalendarAdv()
        Me.monthCalendarAdv1 = New Syncfusion.Windows.Forms.Tools.MonthCalendarAdv()
        Me.textDireccion = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.textTelefono = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Line21 = New Helios.Cont.Presentation.WinForm.Line2()
        Me.txtdias = New System.Windows.Forms.TextBox()
        Me.ToggleConsultas = New Helios.Cont.Presentation.WinForm.ToggleButton2()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.textEmail = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.BgProveedor = New System.ComponentModel.BackgroundWorker()
        Me.pnBody = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip3.SuspendLayout()
        CType(Me.TextProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextNumIdentrazon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnPrincipal.SuspendLayout()
        CType(Me.MonthCalendarAdv2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.monthCalendarAdv1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.textDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.textTelefono, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.textEmail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnBody.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ToolStrip3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1055, 40)
        Me.Panel1.TabIndex = 0
        '
        'ToolStrip3
        '
        Me.ToolStrip3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStrip3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.btnRetorno, Me.ToolStripSeparator3, Me.ToolStripButton1, Me.ToolStripSeparator9, Me.ToolStripSeparator1})
        Me.ToolStrip3.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip3.Size = New System.Drawing.Size(1055, 40)
        Me.ToolStrip3.TabIndex = 7
        Me.ToolStrip3.Text = "ToolStrip3"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 40)
        '
        'btnRetorno
        '
        Me.btnRetorno.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnRetorno.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnRetorno.ForeColor = System.Drawing.Color.Black
        Me.btnRetorno.Image = CType(resources.GetObject("btnRetorno.Image"), System.Drawing.Image)
        Me.btnRetorno.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnRetorno.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnRetorno.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRetorno.Margin = New System.Windows.Forms.Padding(5, 1, 5, 2)
        Me.btnRetorno.Name = "btnRetorno"
        Me.btnRetorno.Size = New System.Drawing.Size(161, 37)
        Me.btnRetorno.Text = "Siquiente - [F2]"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 40)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton1.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.ToolStripButton1.ForeColor = System.Drawing.Color.Black
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Margin = New System.Windows.Forms.Padding(5, 1, 5, 2)
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(166, 37)
        Me.ToolStripButton1.Text = "Retornar - [ESC]"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 40)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 40)
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(30, 40)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(21, 184)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Email"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Maroon
        Me.Label10.Location = New System.Drawing.Point(22, 24)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(153, 15)
        Me.Label10.TabIndex = 693
        Me.Label10.Text = "INFORMACION PERSONAL"
        '
        'TextProveedor
        '
        Me.TextProveedor.BackColor = System.Drawing.Color.White
        Me.TextProveedor.BeforeTouchSize = New System.Drawing.Size(431, 22)
        Me.TextProveedor.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextProveedor.CornerRadius = 3
        Me.TextProveedor.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextProveedor.Enabled = False
        Me.TextProveedor.FocusBorderColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(194, Byte), Integer))
        Me.TextProveedor.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextProveedor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextProveedor.Location = New System.Drawing.Point(119, 84)
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
        Me.TextNumIdentrazon.BeforeTouchSize = New System.Drawing.Size(431, 22)
        Me.TextNumIdentrazon.BorderColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextNumIdentrazon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextNumIdentrazon.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNumIdentrazon.CornerRadius = 3
        Me.TextNumIdentrazon.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextNumIdentrazon.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNumIdentrazon.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextNumIdentrazon.Location = New System.Drawing.Point(23, 84)
        Me.TextNumIdentrazon.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TextNumIdentrazon.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextNumIdentrazon.Name = "TextNumIdentrazon"
        Me.TextNumIdentrazon.Size = New System.Drawing.Size(92, 23)
        Me.TextNumIdentrazon.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextNumIdentrazon.TabIndex = 698
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkColor = System.Drawing.SystemColors.Highlight
        Me.LinkLabel1.Location = New System.Drawing.Point(267, 64)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(38, 13)
        Me.LinkLabel1.TabIndex = 703
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Nuevo"
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(204, 62)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(57, 17)
        Me.RadioButton1.TabIndex = 700
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Cliente"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel2.LinkColor = System.Drawing.SystemColors.Highlight
        Me.LinkLabel2.Location = New System.Drawing.Point(306, 64)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(35, 13)
        Me.LinkLabel2.TabIndex = 704
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Editar"
        '
        'pnPrincipal
        '
        Me.pnPrincipal.BackColor = System.Drawing.Color.White
        Me.pnPrincipal.Controls.Add(Me.Label2)
        Me.pnPrincipal.Controls.Add(Me.Label3)
        Me.pnPrincipal.Controls.Add(Me.Label5)
        Me.pnPrincipal.Controls.Add(Me.Label6)
        Me.pnPrincipal.Controls.Add(Me.TextBox2)
        Me.pnPrincipal.Controls.Add(Me.textBox1)
        Me.pnPrincipal.Controls.Add(Me.MonthCalendarAdv2)
        Me.pnPrincipal.Controls.Add(Me.monthCalendarAdv1)
        Me.pnPrincipal.Controls.Add(Me.textDireccion)
        Me.pnPrincipal.Controls.Add(Me.Label11)
        Me.pnPrincipal.Controls.Add(Me.textTelefono)
        Me.pnPrincipal.Controls.Add(Me.Label8)
        Me.pnPrincipal.Controls.Add(Me.Line21)
        Me.pnPrincipal.Controls.Add(Me.txtdias)
        Me.pnPrincipal.Controls.Add(Me.ToggleConsultas)
        Me.pnPrincipal.Controls.Add(Me.PictureBox1)
        Me.pnPrincipal.Controls.Add(Me.Label4)
        Me.pnPrincipal.Controls.Add(Me.LinkLabel2)
        Me.pnPrincipal.Controls.Add(Me.RadioButton1)
        Me.pnPrincipal.Controls.Add(Me.LinkLabel1)
        Me.pnPrincipal.Controls.Add(Me.TextNumIdentrazon)
        Me.pnPrincipal.Controls.Add(Me.TextProveedor)
        Me.pnPrincipal.Controls.Add(Me.textEmail)
        Me.pnPrincipal.Controls.Add(Me.Label10)
        Me.pnPrincipal.Controls.Add(Me.Label1)
        Me.pnPrincipal.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.pnPrincipal.Name = "pnPrincipal"
        Me.pnPrincipal.Size = New System.Drawing.Size(1055, 378)
        Me.pnPrincipal.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Maroon
        Me.Label2.Location = New System.Drawing.Point(503, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(161, 15)
        Me.Label2.TabIndex = 756
        Me.Label2.Text = "INFORMACION DE RESERVA"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(684, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 15)
        Me.Label3.TabIndex = 755
        Me.Label3.Text = "Dias"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(777, 58)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 15)
        Me.Label5.TabIndex = 754
        Me.Label5.Text = "Salida"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(503, 58)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 15)
        Me.Label6.TabIndex = 753
        Me.Label6.Text = "Llegada"
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.TextBox2.Location = New System.Drawing.Point(780, 79)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(252, 23)
        Me.TextBox2.TabIndex = 751
        '
        'textBox1
        '
        Me.textBox1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.textBox1.Location = New System.Drawing.Point(506, 79)
        Me.textBox1.Name = "textBox1"
        Me.textBox1.ReadOnly = True
        Me.textBox1.Size = New System.Drawing.Size(255, 23)
        Me.textBox1.TabIndex = 750
        '
        'MonthCalendarAdv2
        '
        Me.MonthCalendarAdv2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.MonthCalendarAdv2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MonthCalendarAdv2.BottomHeight = 16
        Me.MonthCalendarAdv2.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.MonthCalendarAdv2.DayNamesColor = System.Drawing.Color.Transparent
        Me.MonthCalendarAdv2.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.MonthCalendarAdv2.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.MonthCalendarAdv2.DaysHeaderInterior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Window)
        Me.MonthCalendarAdv2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.MonthCalendarAdv2.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.MonthCalendarAdv2.HeaderHeight = 34
        Me.MonthCalendarAdv2.HeaderStartColor = System.Drawing.Color.White
        Me.MonthCalendarAdv2.HighlightColor = System.Drawing.Color.Black
        Me.MonthCalendarAdv2.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
        Me.MonthCalendarAdv2.Iso8601CalenderFormat = False
        Me.MonthCalendarAdv2.Location = New System.Drawing.Point(777, 107)
        Me.MonthCalendarAdv2.Margin = New System.Windows.Forms.Padding(2)
        Me.MonthCalendarAdv2.MetroColor = System.Drawing.Color.Transparent
        Me.MonthCalendarAdv2.Name = "MonthCalendarAdv2"
        Me.MonthCalendarAdv2.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.MonthCalendarAdv2.SelectedDates = New Date() {New Date(2019, 9, 1, 0, 0, 0, 0)}
        Me.MonthCalendarAdv2.Size = New System.Drawing.Size(255, 219)
        Me.MonthCalendarAdv2.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.MonthCalendarAdv2.TabIndex = 749
        Me.MonthCalendarAdv2.ThemedEnabledScrollButtons = False
        Me.MonthCalendarAdv2.TodayFontColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.MonthCalendarAdv2.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.MonthCalendarAdv2.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.MonthCalendarAdv2.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.MonthCalendarAdv2.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.MonthCalendarAdv2.NoneButton.ForeColor = System.Drawing.Color.White
        Me.MonthCalendarAdv2.NoneButton.IsBackStageButton = False
        Me.MonthCalendarAdv2.NoneButton.Location = New System.Drawing.Point(151, 0)
        Me.MonthCalendarAdv2.NoneButton.Margin = New System.Windows.Forms.Padding(2)
        Me.MonthCalendarAdv2.NoneButton.Size = New System.Drawing.Size(104, 16)
        Me.MonthCalendarAdv2.NoneButton.Text = "None"
        Me.MonthCalendarAdv2.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.MonthCalendarAdv2.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.MonthCalendarAdv2.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.MonthCalendarAdv2.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.MonthCalendarAdv2.TodayButton.ForeColor = System.Drawing.Color.White
        Me.MonthCalendarAdv2.TodayButton.IsBackStageButton = False
        Me.MonthCalendarAdv2.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.MonthCalendarAdv2.TodayButton.Margin = New System.Windows.Forms.Padding(2)
        Me.MonthCalendarAdv2.TodayButton.Size = New System.Drawing.Size(151, 16)
        Me.MonthCalendarAdv2.TodayButton.Text = "Today"
        Me.MonthCalendarAdv2.TodayButton.UseVisualStyle = True
        '
        'monthCalendarAdv1
        '
        Me.monthCalendarAdv1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.monthCalendarAdv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.monthCalendarAdv1.BottomHeight = 16
        Me.monthCalendarAdv1.ClearSelectionOnNone = True
        Me.monthCalendarAdv1.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.monthCalendarAdv1.DayNamesColor = System.Drawing.Color.Transparent
        Me.monthCalendarAdv1.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.monthCalendarAdv1.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.monthCalendarAdv1.DaysHeaderInterior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Window)
        Me.monthCalendarAdv1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.monthCalendarAdv1.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.monthCalendarAdv1.HeaderHeight = 34
        Me.monthCalendarAdv1.HeaderStartColor = System.Drawing.Color.White
        Me.monthCalendarAdv1.HighlightColor = System.Drawing.Color.Black
        Me.monthCalendarAdv1.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
        Me.monthCalendarAdv1.Iso8601CalenderFormat = False
        Me.monthCalendarAdv1.Location = New System.Drawing.Point(506, 107)
        Me.monthCalendarAdv1.Margin = New System.Windows.Forms.Padding(2)
        Me.monthCalendarAdv1.MetroColor = System.Drawing.Color.Transparent
        Me.monthCalendarAdv1.Name = "monthCalendarAdv1"
        Me.monthCalendarAdv1.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.monthCalendarAdv1.SelectedDates = New Date() {New Date(2019, 9, 7, 0, 0, 0, 0)}
        Me.monthCalendarAdv1.Size = New System.Drawing.Size(255, 219)
        Me.monthCalendarAdv1.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.monthCalendarAdv1.TabIndex = 748
        Me.monthCalendarAdv1.ThemedEnabledScrollButtons = False
        Me.monthCalendarAdv1.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.monthCalendarAdv1.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.monthCalendarAdv1.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.monthCalendarAdv1.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.monthCalendarAdv1.NoneButton.ForeColor = System.Drawing.Color.White
        Me.monthCalendarAdv1.NoneButton.IsBackStageButton = False
        Me.monthCalendarAdv1.NoneButton.Location = New System.Drawing.Point(151, 0)
        Me.monthCalendarAdv1.NoneButton.Margin = New System.Windows.Forms.Padding(2)
        Me.monthCalendarAdv1.NoneButton.Size = New System.Drawing.Size(104, 16)
        Me.monthCalendarAdv1.NoneButton.Text = "None"
        Me.monthCalendarAdv1.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.monthCalendarAdv1.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.monthCalendarAdv1.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.monthCalendarAdv1.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.monthCalendarAdv1.TodayButton.ForeColor = System.Drawing.Color.White
        Me.monthCalendarAdv1.TodayButton.IsBackStageButton = False
        Me.monthCalendarAdv1.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.monthCalendarAdv1.TodayButton.Margin = New System.Windows.Forms.Padding(2)
        Me.monthCalendarAdv1.TodayButton.Size = New System.Drawing.Size(151, 16)
        Me.monthCalendarAdv1.TodayButton.Text = "Today"
        Me.monthCalendarAdv1.TodayButton.UseVisualStyle = True
        '
        'textDireccion
        '
        Me.textDireccion.BackColor = System.Drawing.Color.White
        Me.textDireccion.BeforeTouchSize = New System.Drawing.Size(431, 22)
        Me.textDireccion.BorderColor = System.Drawing.Color.FromArgb(CType(CType(164, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(178, Byte), Integer))
        Me.textDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.textDireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textDireccion.CornerRadius = 4
        Me.textDireccion.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.textDireccion.FarImage = CType(resources.GetObject("textDireccion.FarImage"), System.Drawing.Image)
        Me.textDireccion.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textDireccion.ForeColor = System.Drawing.Color.Black
        Me.textDireccion.Location = New System.Drawing.Point(24, 135)
        Me.textDireccion.Metrocolor = System.Drawing.SystemColors.GradientActiveCaption
        Me.textDireccion.MinimumSize = New System.Drawing.Size(14, 10)
        Me.textDireccion.Multiline = True
        Me.textDireccion.Name = "textDireccion"
        Me.textDireccion.Office2007ColorScheme = Syncfusion.Windows.Forms.Office2007Theme.Black
        Me.textDireccion.Office2010ColorScheme = Syncfusion.Windows.Forms.Office2010Theme.Black
        Me.textDireccion.Size = New System.Drawing.Size(431, 37)
        Me.textDireccion.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.textDireccion.TabIndex = 745
        Me.textDireccion.ThemesEnabled = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(21, 119)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(55, 13)
        Me.Label11.TabIndex = 744
        Me.Label11.Text = "Dirección"
        '
        'textTelefono
        '
        Me.textTelefono.BackColor = System.Drawing.Color.White
        Me.textTelefono.BeforeTouchSize = New System.Drawing.Size(431, 22)
        Me.textTelefono.BorderColor = System.Drawing.Color.FromArgb(CType(CType(164, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(178, Byte), Integer))
        Me.textTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.textTelefono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textTelefono.CornerRadius = 4
        Me.textTelefono.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.textTelefono.FarImage = CType(resources.GetObject("textTelefono.FarImage"), System.Drawing.Image)
        Me.textTelefono.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textTelefono.ForeColor = System.Drawing.Color.Black
        Me.textTelefono.Location = New System.Drawing.Point(28, 255)
        Me.textTelefono.Metrocolor = System.Drawing.SystemColors.GradientActiveCaption
        Me.textTelefono.MinimumSize = New System.Drawing.Size(14, 10)
        Me.textTelefono.Name = "textTelefono"
        Me.textTelefono.Office2007ColorScheme = Syncfusion.Windows.Forms.Office2007Theme.Black
        Me.textTelefono.Office2010ColorScheme = Syncfusion.Windows.Forms.Office2010Theme.Black
        Me.textTelefono.Size = New System.Drawing.Size(145, 22)
        Me.textTelefono.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.textTelefono.TabIndex = 742
        Me.textTelefono.ThemesEnabled = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(25, 239)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 13)
        Me.Label8.TabIndex = 741
        Me.Label8.Text = "Telefono"
        '
        'Line21
        '
        Me.Line21.LineColor = System.Drawing.Color.Gainsboro
        Me.Line21.Location = New System.Drawing.Point(485, 20)
        Me.Line21.Name = "Line21"
        Me.Line21.Size = New System.Drawing.Size(1, 320)
        Me.Line21.TabIndex = 729
        Me.Line21.Text = "Line21"
        '
        'txtdias
        '
        Me.txtdias.BackColor = System.Drawing.Color.Black
        Me.txtdias.Font = New System.Drawing.Font("Arial", 15.0!, System.Drawing.FontStyle.Bold)
        Me.txtdias.ForeColor = System.Drawing.Color.White
        Me.txtdias.Location = New System.Drawing.Point(720, 13)
        Me.txtdias.Name = "txtdias"
        Me.txtdias.Size = New System.Drawing.Size(96, 30)
        Me.txtdias.TabIndex = 725
        Me.txtdias.Text = "1"
        Me.txtdias.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ToggleConsultas
        '
        Me.ToggleConsultas.ActiveColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.ToggleConsultas.ActiveText = "Web"
        Me.ToggleConsultas.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.ToggleConsultas.InActiveColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.ToggleConsultas.InActiveText = "API"
        Me.ToggleConsultas.Location = New System.Drawing.Point(121, 56)
        Me.ToggleConsultas.MaximumSize = New System.Drawing.Size(119, 32)
        Me.ToggleConsultas.MinimumSize = New System.Drawing.Size(75, 23)
        Me.ToggleConsultas.Name = "ToggleConsultas"
        Me.ToggleConsultas.Size = New System.Drawing.Size(76, 23)
        Me.ToggleConsultas.SliderColor = System.Drawing.Color.Black
        Me.ToggleConsultas.SlidingAngle = 8
        Me.ToggleConsultas.TabIndex = 707
        Me.ToggleConsultas.Text = "ToggleButton21"
        Me.ToggleConsultas.TextColor = System.Drawing.Color.White
        Me.ToggleConsultas.ToggleState = Helios.Cont.Presentation.WinForm.ToggleButton2.ToggleButtonState.OFF
        Me.ToggleConsultas.ToggleStyle = Helios.Cont.Presentation.WinForm.ToggleButton2.ToggleButtonStyle.Android
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(119, 84)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(22, 21)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 706
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label4.Image = CType(resources.GetObject("Label4.Image"), System.Drawing.Image)
        Me.Label4.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Label4.Location = New System.Drawing.Point(21, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 25)
        Me.Label4.TabIndex = 699
        Me.Label4.Text = "Identificar"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'textEmail
        '
        Me.textEmail.BackColor = System.Drawing.Color.White
        Me.textEmail.BeforeTouchSize = New System.Drawing.Size(431, 22)
        Me.textEmail.BorderColor = System.Drawing.Color.FromArgb(CType(CType(164, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(178, Byte), Integer))
        Me.textEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.textEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textEmail.CornerRadius = 4
        Me.textEmail.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.textEmail.FarImage = CType(resources.GetObject("textEmail.FarImage"), System.Drawing.Image)
        Me.textEmail.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textEmail.ForeColor = System.Drawing.Color.Black
        Me.textEmail.Location = New System.Drawing.Point(24, 200)
        Me.textEmail.Metrocolor = System.Drawing.SystemColors.GradientActiveCaption
        Me.textEmail.MinimumSize = New System.Drawing.Size(14, 10)
        Me.textEmail.Name = "textEmail"
        Me.textEmail.Office2007ColorScheme = Syncfusion.Windows.Forms.Office2007Theme.Black
        Me.textEmail.Office2010ColorScheme = Syncfusion.Windows.Forms.Office2010Theme.Black
        Me.textEmail.Size = New System.Drawing.Size(431, 22)
        Me.textEmail.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.textEmail.TabIndex = 697
        Me.textEmail.ThemesEnabled = False
        '
        'BgProveedor
        '
        Me.BgProveedor.WorkerSupportsCancellation = True
        '
        'pnBody
        '
        Me.pnBody.BackColor = System.Drawing.Color.White
        Me.pnBody.Controls.Add(Me.pnPrincipal)
        Me.pnBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnBody.Location = New System.Drawing.Point(0, 40)
        Me.pnBody.Name = "pnBody"
        Me.pnBody.Size = New System.Drawing.Size(1055, 378)
        Me.pnBody.TabIndex = 9
        '
        'TabRC_Cliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.Controls.Add(Me.pnBody)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "TabRC_Cliente"
        Me.Size = New System.Drawing.Size(1055, 418)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        CType(Me.TextProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextNumIdentrazon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnPrincipal.ResumeLayout(False)
        Me.pnPrincipal.PerformLayout()
        CType(Me.MonthCalendarAdv2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.monthCalendarAdv1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.textDireccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.textTelefono, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.textEmail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnBody.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents ToolStrip3 As ToolStrip
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents btnRetorno As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator9 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents Label1 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents textEmail As Tools.TextBoxExt
    Friend WithEvents TextProveedor As Tools.TextBoxExt
    Friend WithEvents TextNumIdentrazon As Tools.TextBoxExt
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents Label4 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents pnPrincipal As Panel
    Friend WithEvents BgProveedor As System.ComponentModel.BackgroundWorker
    Friend WithEvents textDireccion As Tools.TextBoxExt
    Friend WithEvents Label11 As Label
    Friend WithEvents textTelefono As Tools.TextBoxExt
    Friend WithEvents Label8 As Label
    Friend WithEvents pnBody As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Private WithEvents TextBox2 As TextBox
    Private WithEvents textBox1 As TextBox
    Private WithEvents MonthCalendarAdv2 As Tools.MonthCalendarAdv
    Private WithEvents monthCalendarAdv1 As Tools.MonthCalendarAdv
    Friend WithEvents txtdias As TextBox
    Private WithEvents ToggleConsultas As ToggleButton2
    Private WithEvents Line21 As Line2
End Class

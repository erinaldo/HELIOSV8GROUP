Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormBuscarVentasGeneral
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormBuscarVentasGeneral))
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"1", "JIUNI PALACIOS SANTOS", "44924569"}, -1)
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor6 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor7 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFiltrar = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.ComboFiltros = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TXTdIA = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.ChMes = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ChDia = New Bunifu.Framework.UI.BunifuCheckbox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtFechapERIODO = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pcLikeCategoria = New Syncfusion.Windows.Forms.PopupControlContainer()
        Me.LsvProveedor = New System.Windows.Forms.ListView()
        Me.colID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colRUC = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colTipoDoc = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.RoundButton21 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ComboCriterio = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.GridEscan = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFiltrar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboFiltros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.TXTdIA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TXTdIA.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechapERIODO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechapERIODO.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pcLikeCategoria.SuspendLayout()
        CType(Me.ComboCriterio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridEscan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(175, 168)
        Me.Panel1.TabIndex = 229
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Bahnschrift Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(24, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(131, 14)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "BÚSQUEDA AVANZADA"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(834, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 25)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "X"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(536, 141)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 15)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Estado"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(34, 46)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(107, 111)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(295, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(133, 13)
        Me.Label2.TabIndex = 406
        Me.Label2.Text = "CRITERIO DE BÚSQUEDA"
        '
        'txtFiltrar
        '
        Me.txtFiltrar.BackColor = System.Drawing.Color.White
        Me.txtFiltrar.BeforeTouchSize = New System.Drawing.Size(340, 22)
        Me.txtFiltrar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFiltrar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFiltrar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFiltrar.CornerRadius = 4
        Me.txtFiltrar.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFiltrar.FarImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.IC632968
        Me.txtFiltrar.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFiltrar.Location = New System.Drawing.Point(298, 87)
        Me.txtFiltrar.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFiltrar.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtFiltrar.Name = "txtFiltrar"
        Me.txtFiltrar.Size = New System.Drawing.Size(340, 22)
        Me.txtFiltrar.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtFiltrar.TabIndex = 405
        '
        'ComboFiltros
        '
        Me.ComboFiltros.BackColor = System.Drawing.Color.White
        Me.ComboFiltros.BeforeTouchSize = New System.Drawing.Size(180, 21)
        Me.ComboFiltros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboFiltros.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboFiltros.Items.AddRange(New Object() {"CLIENTE"})
        Me.ComboFiltros.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.ComboFiltros, "CLIENTE"))
        Me.ComboFiltros.Location = New System.Drawing.Point(210, 36)
        Me.ComboFiltros.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ComboFiltros.Name = "ComboFiltros"
        Me.ComboFiltros.Size = New System.Drawing.Size(180, 21)
        Me.ComboFiltros.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboFiltros.TabIndex = 404
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(207, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 403
        Me.Label1.Text = "FILTRAR POR"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel2.Controls.Add(Me.TXTdIA)
        Me.Panel2.Controls.Add(Me.ChMes)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.ChDia)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.txtFechapERIODO)
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.pcLikeCategoria)
        Me.Panel2.Controls.Add(Me.RoundButton21)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.ComboCriterio)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.ComboFiltros)
        Me.Panel2.Controls.Add(Me.txtFiltrar)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(868, 168)
        Me.Panel2.TabIndex = 407
        '
        'TXTdIA
        '
        Me.TXTdIA.BackColor = System.Drawing.Color.Gainsboro
        Me.TXTdIA.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.TXTdIA.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TXTdIA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.TXTdIA.Calendar.AllowMultipleSelection = False
        Me.TXTdIA.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.TXTdIA.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXTdIA.Calendar.BottomHeight = 30
        Me.TXTdIA.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.TXTdIA.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TXTdIA.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TXTdIA.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.TXTdIA.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TXTdIA.Calendar.EnableTouchMode = True
        Me.TXTdIA.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTdIA.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TXTdIA.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.TXTdIA.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.TXTdIA.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.TXTdIA.Calendar.HighlightColor = System.Drawing.Color.White
        Me.TXTdIA.Calendar.Iso8601CalenderFormat = False
        Me.TXTdIA.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.TXTdIA.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TXTdIA.Calendar.Name = "monthCalendar"
        Me.TXTdIA.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.TXTdIA.Calendar.SelectedDates = New Date(-1) {}
        Me.TXTdIA.Calendar.Size = New System.Drawing.Size(80, 174)
        Me.TXTdIA.Calendar.SizeToFit = True
        Me.TXTdIA.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.TXTdIA.Calendar.TabIndex = 0
        Me.TXTdIA.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.TXTdIA.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.TXTdIA.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TXTdIA.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.TXTdIA.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.TXTdIA.Calendar.NoneButton.IsBackStageButton = False
        Me.TXTdIA.Calendar.NoneButton.Location = New System.Drawing.Point(4, 0)
        Me.TXTdIA.Calendar.NoneButton.Size = New System.Drawing.Size(72, 30)
        Me.TXTdIA.Calendar.NoneButton.Text = "None"
        Me.TXTdIA.Calendar.NoneButton.UseVisualStyle = True
        Me.TXTdIA.Calendar.NoneButton.Visible = False
        '
        '
        '
        Me.TXTdIA.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.TXTdIA.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TXTdIA.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.TXTdIA.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.TXTdIA.Calendar.TodayButton.IsBackStageButton = False
        Me.TXTdIA.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.TXTdIA.Calendar.TodayButton.Size = New System.Drawing.Size(80, 30)
        Me.TXTdIA.Calendar.TodayButton.Text = "Today"
        Me.TXTdIA.Calendar.TodayButton.UseVisualStyle = True
        Me.TXTdIA.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTdIA.CalendarSize = New System.Drawing.Size(189, 176)
        Me.TXTdIA.Checked = False
        Me.TXTdIA.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.TXTdIA.CustomFormat = "dd/MM/yyyy"
        Me.TXTdIA.DropDownImage = Nothing
        Me.TXTdIA.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TXTdIA.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TXTdIA.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.TXTdIA.EnableNullDate = False
        Me.TXTdIA.EnableNullKeys = False
        Me.TXTdIA.EnableTouchMode = True
        Me.TXTdIA.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTdIA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TXTdIA.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TXTdIA.Location = New System.Drawing.Point(210, 89)
        Me.TXTdIA.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TXTdIA.MinValue = New Date(CType(0, Long))
        Me.TXTdIA.Name = "TXTdIA"
        Me.TXTdIA.ShowCheckBox = False
        Me.TXTdIA.ShowDropButton = False
        Me.TXTdIA.Size = New System.Drawing.Size(82, 20)
        Me.TXTdIA.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.TXTdIA.TabIndex = 519
        Me.TXTdIA.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        '
        'ChMes
        '
        Me.ChMes.BackColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.ChMes.ChechedOffColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.ChMes.Checked = False
        Me.ChMes.CheckedOnColor = System.Drawing.SystemColors.HotTrack
        Me.ChMes.ForeColor = System.Drawing.Color.White
        Me.ChMes.Location = New System.Drawing.Point(729, 36)
        Me.ChMes.Name = "ChMes"
        Me.ChMes.Size = New System.Drawing.Size(20, 20)
        Me.ChMes.TabIndex = 518
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(750, 38)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 14)
        Me.Label9.TabIndex = 517
        Me.Label9.Text = "POR MES"
        '
        'ChDia
        '
        Me.ChDia.BackColor = System.Drawing.SystemColors.HotTrack
        Me.ChDia.ChechedOffColor = System.Drawing.Color.FromArgb(CType(CType(132, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.ChDia.Checked = True
        Me.ChDia.CheckedOnColor = System.Drawing.SystemColors.HotTrack
        Me.ChDia.ForeColor = System.Drawing.Color.White
        Me.ChDia.Location = New System.Drawing.Point(650, 36)
        Me.ChDia.Name = "ChDia"
        Me.ChDia.Size = New System.Drawing.Size(20, 20)
        Me.ChDia.TabIndex = 516
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(671, 38)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 14)
        Me.Label8.TabIndex = 515
        Me.Label8.Text = "POR DIA"
        '
        'txtFechapERIODO
        '
        Me.txtFechapERIODO.BackColor = System.Drawing.Color.Gainsboro
        Me.txtFechapERIODO.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtFechapERIODO.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechapERIODO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtFechapERIODO.Calendar.AllowMultipleSelection = False
        Me.txtFechapERIODO.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechapERIODO.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechapERIODO.Calendar.BottomHeight = 30
        Me.txtFechapERIODO.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechapERIODO.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechapERIODO.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFechapERIODO.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtFechapERIODO.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFechapERIODO.Calendar.EnableTouchMode = True
        Me.txtFechapERIODO.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechapERIODO.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechapERIODO.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtFechapERIODO.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtFechapERIODO.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtFechapERIODO.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtFechapERIODO.Calendar.Iso8601CalenderFormat = False
        Me.txtFechapERIODO.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtFechapERIODO.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechapERIODO.Calendar.Name = "monthCalendar"
        Me.txtFechapERIODO.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtFechapERIODO.Calendar.SelectedDates = New Date(-1) {}
        Me.txtFechapERIODO.Calendar.Size = New System.Drawing.Size(80, 174)
        Me.txtFechapERIODO.Calendar.SizeToFit = True
        Me.txtFechapERIODO.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechapERIODO.Calendar.TabIndex = 0
        Me.txtFechapERIODO.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtFechapERIODO.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechapERIODO.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechapERIODO.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechapERIODO.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtFechapERIODO.Calendar.NoneButton.IsBackStageButton = False
        Me.txtFechapERIODO.Calendar.NoneButton.Location = New System.Drawing.Point(4, 0)
        Me.txtFechapERIODO.Calendar.NoneButton.Size = New System.Drawing.Size(72, 30)
        Me.txtFechapERIODO.Calendar.NoneButton.Text = "None"
        Me.txtFechapERIODO.Calendar.NoneButton.UseVisualStyle = True
        Me.txtFechapERIODO.Calendar.NoneButton.Visible = False
        '
        '
        '
        Me.txtFechapERIODO.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechapERIODO.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechapERIODO.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechapERIODO.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtFechapERIODO.Calendar.TodayButton.IsBackStageButton = False
        Me.txtFechapERIODO.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtFechapERIODO.Calendar.TodayButton.Size = New System.Drawing.Size(80, 30)
        Me.txtFechapERIODO.Calendar.TodayButton.Text = "Today"
        Me.txtFechapERIODO.Calendar.TodayButton.UseVisualStyle = True
        Me.txtFechapERIODO.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechapERIODO.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtFechapERIODO.Checked = False
        Me.txtFechapERIODO.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechapERIODO.CustomFormat = "MM/yyyy"
        Me.txtFechapERIODO.DropDownImage = Nothing
        Me.txtFechapERIODO.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechapERIODO.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechapERIODO.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtFechapERIODO.EnableNullDate = False
        Me.txtFechapERIODO.EnableNullKeys = False
        Me.txtFechapERIODO.EnableTouchMode = True
        Me.txtFechapERIODO.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechapERIODO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechapERIODO.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFechapERIODO.Location = New System.Drawing.Point(210, 89)
        Me.txtFechapERIODO.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechapERIODO.MinValue = New Date(CType(0, Long))
        Me.txtFechapERIODO.Name = "txtFechapERIODO"
        Me.txtFechapERIODO.ShowCheckBox = False
        Me.txtFechapERIODO.ShowDropButton = False
        Me.txtFechapERIODO.Size = New System.Drawing.Size(82, 20)
        Me.txtFechapERIODO.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechapERIODO.TabIndex = 435
        Me.txtFechapERIODO.Value = New Date(2016, 1, 25, 11, 17, 26, 137)
        Me.txtFechapERIODO.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(207, 68)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 13)
        Me.Label7.TabIndex = 434
        Me.Label7.Text = "PERIODO"
        '
        'pcLikeCategoria
        '
        Me.pcLikeCategoria.Controls.Add(Me.LsvProveedor)
        Me.pcLikeCategoria.Location = New System.Drawing.Point(445, 194)
        Me.pcLikeCategoria.Name = "pcLikeCategoria"
        Me.pcLikeCategoria.Size = New System.Drawing.Size(282, 128)
        Me.pcLikeCategoria.TabIndex = 433
        '
        'LsvProveedor
        '
        Me.LsvProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LsvProveedor.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colID, Me.colCliente, Me.colRUC, Me.colTipoDoc})
        Me.LsvProveedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LsvProveedor.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LsvProveedor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(187, Byte), Integer))
        Me.LsvProveedor.FullRowSelect = True
        Me.LsvProveedor.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.LsvProveedor.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1})
        Me.LsvProveedor.Location = New System.Drawing.Point(0, 0)
        Me.LsvProveedor.MultiSelect = False
        Me.LsvProveedor.Name = "LsvProveedor"
        Me.LsvProveedor.Size = New System.Drawing.Size(282, 128)
        Me.LsvProveedor.TabIndex = 1
        Me.LsvProveedor.UseCompatibleStateImageBehavior = False
        Me.LsvProveedor.View = System.Windows.Forms.View.Details
        '
        'colID
        '
        Me.colID.Text = "ID"
        Me.colID.Width = 0
        '
        'colCliente
        '
        Me.colCliente.Text = "Cliente"
        Me.colCliente.Width = 219
        '
        'colRUC
        '
        Me.colRUC.Text = "RUC"
        '
        'RoundButton21
        '
        Me.RoundButton21.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton21.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.RoundButton21.BeforeTouchSize = New System.Drawing.Size(121, 29)
        Me.RoundButton21.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundButton21.ForeColor = System.Drawing.Color.White
        Me.RoundButton21.IsBackStageButton = False
        Me.RoundButton21.Location = New System.Drawing.Point(210, 123)
        Me.RoundButton21.Name = "RoundButton21"
        Me.RoundButton21.Size = New System.Drawing.Size(121, 29)
        Me.RoundButton21.TabIndex = 409
        Me.RoundButton21.Text = "CONSULTAR"
        Me.RoundButton21.UseVisualStyle = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(393, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 13)
        Me.Label6.TabIndex = 407
        Me.Label6.Text = "COMPROBANTE"
        '
        'ComboCriterio
        '
        Me.ComboCriterio.BackColor = System.Drawing.Color.White
        Me.ComboCriterio.BeforeTouchSize = New System.Drawing.Size(242, 21)
        Me.ComboCriterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboCriterio.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboCriterio.Location = New System.Drawing.Point(396, 36)
        Me.ComboCriterio.MetroBorderColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ComboCriterio.Name = "ComboCriterio"
        Me.ComboCriterio.Size = New System.Drawing.Size(242, 21)
        Me.ComboCriterio.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.ComboCriterio.TabIndex = 408
        '
        'GridEscan
        '
        Me.GridEscan.BackColor = System.Drawing.SystemColors.Window
        Me.GridEscan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridEscan.FreezeCaption = False
        Me.GridEscan.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.GridEscan.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.GridEscan.Location = New System.Drawing.Point(0, 0)
        Me.GridEscan.Name = "GridEscan"
        Me.GridEscan.Size = New System.Drawing.Size(868, 1)
        Me.GridEscan.TabIndex = 415
        Me.GridEscan.TableDescriptor.AllowNew = False
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.HeaderText = "Nro. doc."
        GridColumnDescriptor1.MappingName = "nrodoc"
        GridColumnDescriptor1.ReadOnly = True
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor1.Width = 143
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.HeaderText = "Importe venta"
        GridColumnDescriptor2.MappingName = "importe"
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor2.Width = 90
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.HeaderText = "Cliente"
        GridColumnDescriptor3.MappingName = "proveedor"
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor3.Width = 250
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.HeaderText = "Estado"
        GridColumnDescriptor4.MappingName = "estado"
        GridColumnDescriptor4.SerializedImageArray = ""
        GridColumnDescriptor4.Width = 100
        GridColumnDescriptor5.HeaderImage = Nothing
        GridColumnDescriptor5.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor5.HeaderText = "Fecha"
        GridColumnDescriptor5.MappingName = "fecha"
        GridColumnDescriptor5.SerializedImageArray = ""
        GridColumnDescriptor5.Width = 93
        GridColumnDescriptor6.HeaderImage = Nothing
        GridColumnDescriptor6.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor6.MappingName = "iddoc"
        GridColumnDescriptor6.ReadOnly = True
        GridColumnDescriptor6.SerializedImageArray = ""
        GridColumnDescriptor6.Width = 0
        GridColumnDescriptor7.HeaderImage = Nothing
        GridColumnDescriptor7.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor7.HeaderText = "Tipo doc."
        GridColumnDescriptor7.MappingName = "tipodoc"
        GridColumnDescriptor7.ReadOnly = True
        GridColumnDescriptor7.SerializedImageArray = ""
        GridColumnDescriptor7.Width = 70
        Me.GridEscan.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7})
        Me.GridEscan.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.GridEscan.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.GridEscan.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipodoc"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("nrodoc"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("importe"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("proveedor"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("estado"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("fecha"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("iddoc")})
        Me.GridEscan.Text = "GridGroupingControl1"
        Me.GridEscan.VersionInfo = "12.4400.0.24"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.GridEscan)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 168)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(868, 1)
        Me.Panel3.TabIndex = 408
        '
        'FormBuscarVentasGeneral
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.CaptionButtonColor = System.Drawing.Color.White
        Me.CaptionButtonHoverColor = System.Drawing.Color.White
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.White
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(200, 24)
        CaptionLabel1.Text = "Importar ventas"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(868, 169)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FormBuscarVentasGeneral"
        Me.ShowIcon = False
        Me.ShowMaximizeBox = False
        Me.ShowMinimizeBox = False
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFiltrar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboFiltros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.TXTdIA.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TXTdIA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechapERIODO.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechapERIODO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pcLikeCategoria.ResumeLayout(False)
        CType(Me.ComboCriterio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridEscan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtFiltrar As Tools.TextBoxExt
    Friend WithEvents ComboFiltros As Tools.ComboBoxAdv
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents GridEscan As Grid.Grouping.GridGroupingControl
    Friend WithEvents Label6 As Label
    Friend WithEvents ComboCriterio As Tools.ComboBoxAdv
    Private WithEvents pcLikeCategoria As PopupControlContainer
    Friend WithEvents LsvProveedor As ListView
    Friend WithEvents colID As ColumnHeader
    Friend WithEvents colCliente As ColumnHeader
    Friend WithEvents colRUC As ColumnHeader
    Friend WithEvents colTipoDoc As ColumnHeader
    Friend WithEvents RoundButton21 As RoundButton2
    Friend WithEvents Label7 As Label
    Friend WithEvents txtFechapERIODO As Tools.DateTimePickerAdv
    Friend WithEvents Panel3 As Panel
    Friend WithEvents ChMes As Bunifu.Framework.UI.BunifuCheckbox
    Friend WithEvents Label9 As Label
    Friend WithEvents ChDia As Bunifu.Framework.UI.BunifuCheckbox
    Friend WithEvents Label8 As Label
    Friend WithEvents TXTdIA As Tools.DateTimePickerAdv
End Class

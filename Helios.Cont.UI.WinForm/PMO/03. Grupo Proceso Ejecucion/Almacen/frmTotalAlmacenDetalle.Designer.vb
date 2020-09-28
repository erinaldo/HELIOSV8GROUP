<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTotalAlmacenDetalle
    Inherits Helios.Cont.Presentation.WinForm.frmMaster

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
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor6 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor7 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTotalAlmacenDetalle))
        Dim ActiveStateCollection1 As Syncfusion.Windows.Forms.Tools.ActiveStateCollection = New Syncfusion.Windows.Forms.Tools.ActiveStateCollection()
        Dim InactiveStateCollection1 As Syncfusion.Windows.Forms.Tools.InactiveStateCollection = New Syncfusion.Windows.Forms.Tools.InactiveStateCollection()
        Dim ToggleButtonRenderer1 As Syncfusion.Windows.Forms.Tools.ToggleButtonRenderer = New Syncfusion.Windows.Forms.Tools.ToggleButtonRenderer()
        Dim SliderCollection1 As Syncfusion.Windows.Forms.Tools.SliderCollection = New Syncfusion.Windows.Forms.Tools.SliderCollection()
        Dim ActiveStateCollection2 As Syncfusion.Windows.Forms.Tools.ActiveStateCollection = New Syncfusion.Windows.Forms.Tools.ActiveStateCollection()
        Dim InactiveStateCollection2 As Syncfusion.Windows.Forms.Tools.InactiveStateCollection = New Syncfusion.Windows.Forms.Tools.InactiveStateCollection()
        Dim ToggleButtonRenderer2 As Syncfusion.Windows.Forms.Tools.ToggleButtonRenderer = New Syncfusion.Windows.Forms.Tools.ToggleButtonRenderer()
        Dim SliderCollection2 As Syncfusion.Windows.Forms.Tools.SliderCollection = New Syncfusion.Windows.Forms.Tools.SliderCollection()
        Me.dgvTotalesDetalle = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GradientPanel3 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.txtExistencias = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chAgrupa2 = New Syncfusion.Windows.Forms.Tools.ToggleButton()
        Me.chAgrupa1 = New Syncfusion.Windows.Forms.Tools.ToggleButton()
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.txtAlmacen = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblEstado = New System.Windows.Forms.ToolStripButton()
        CType(Me.dgvTotalesDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel3.SuspendLayout()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.chAgrupa2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chAgrupa1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.ToolStrip3.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvTotalesDetalle
        '
        Me.dgvTotalesDetalle.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        Me.dgvTotalesDetalle.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.dgvTotalesDetalle.BackColor = System.Drawing.SystemColors.Window
        Me.dgvTotalesDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvTotalesDetalle.FreezeCaption = False
        Me.dgvTotalesDetalle.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgvTotalesDetalle.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.dgvTotalesDetalle.Location = New System.Drawing.Point(0, 88)
        Me.dgvTotalesDetalle.Name = "dgvTotalesDetalle"
        Me.dgvTotalesDetalle.ShowNavigationBar = True
        Me.dgvTotalesDetalle.Size = New System.Drawing.Size(842, 191)
        Me.dgvTotalesDetalle.TabIndex = 403
        Me.dgvTotalesDetalle.TableDescriptor.AllowNew = False
        Me.dgvTotalesDetalle.TableDescriptor.Appearance.AnyCell.Font.Facename = "Segoe UI"
        Me.dgvTotalesDetalle.TableDescriptor.Appearance.AnyCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.dgvTotalesDetalle.TableDescriptor.Appearance.AnyGroupCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvTotalesDetalle.TableDescriptor.Appearance.AnyGroupCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvTotalesDetalle.TableDescriptor.Appearance.AnyGroupCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer)))
        Me.dgvTotalesDetalle.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvTotalesDetalle.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvTotalesDetalle.TableDescriptor.Appearance.AnySummaryCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvTotalesDetalle.TableDescriptor.Appearance.AnySummaryCell.Borders.Top = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvTotalesDetalle.TableDescriptor.Appearance.AnySummaryCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)))
        Me.dgvTotalesDetalle.TableDescriptor.Appearance.ColumnHeaderCell.Font.Bold = True
        Me.dgvTotalesDetalle.TableDescriptor.Appearance.ColumnHeaderCell.Font.Italic = False
        Me.dgvTotalesDetalle.TableDescriptor.Appearance.ColumnHeaderCell.Font.Size = 8.0!
        Me.dgvTotalesDetalle.TableDescriptor.Appearance.GroupCaptionCell.CellType = """ColumnHeader"""
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.HeaderText = "Nombre Proveedor"
        GridColumnDescriptor1.MappingName = "NombreProveedor"
        GridColumnDescriptor1.Name = "NombreProveedor"
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor1.Width = 200
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.HeaderText = "Tipo Existencia"
        GridColumnDescriptor2.MappingName = "tipoExistencia"
        GridColumnDescriptor2.Name = "tipoExistencia"
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor2.Width = 100
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.HeaderText = "Cantidad"
        GridColumnDescriptor3.MappingName = "monto1"
        GridColumnDescriptor3.Name = "monto1"
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor3.Width = 100
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.HeaderText = "Importe MN"
        GridColumnDescriptor4.MappingName = "importe"
        GridColumnDescriptor4.Name = "importe"
        GridColumnDescriptor4.SerializedImageArray = ""
        GridColumnDescriptor4.Width = 100
        GridColumnDescriptor5.HeaderImage = Nothing
        GridColumnDescriptor5.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor5.HeaderText = "Importe ME"
        GridColumnDescriptor5.MappingName = "importeUS"
        GridColumnDescriptor5.Name = "importeUS"
        GridColumnDescriptor5.SerializedImageArray = ""
        GridColumnDescriptor5.Width = 100
        GridColumnDescriptor6.HeaderImage = Nothing
        GridColumnDescriptor6.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor6.HeaderText = "PU MN"
        GridColumnDescriptor6.MappingName = "precioUnitario"
        GridColumnDescriptor6.Name = "precioUnitario"
        GridColumnDescriptor6.SerializedImageArray = ""
        GridColumnDescriptor6.Width = 100
        GridColumnDescriptor7.HeaderImage = Nothing
        GridColumnDescriptor7.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor7.HeaderText = "PU ME"
        GridColumnDescriptor7.MappingName = "precioUnitarioUS"
        GridColumnDescriptor7.Name = "precioUnitarioUS"
        GridColumnDescriptor7.SerializedImageArray = ""
        GridColumnDescriptor7.Width = 100
        Me.dgvTotalesDetalle.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7})
        Me.dgvTotalesDetalle.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.dgvTotalesDetalle.TableDescriptor.TableOptions.RecordRowHeight = 20
        Me.dgvTotalesDetalle.TableDescriptor.TopLevelGroupOptions.ShowCaption = False
        Me.dgvTotalesDetalle.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("NombreProveedor"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tipoExistencia"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("monto1"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("importe"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("importeUS"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("precioUnitario"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("precioUnitarioUS")})
        Me.dgvTotalesDetalle.Text = "GridGroupingControl2"
        Me.dgvTotalesDetalle.VersionInfo = "12.4400.0.24"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.Panel1)
        Me.Panel3.Controls.Add(Me.GradientPanel3)
        Me.Panel3.Controls.Add(Me.GradientPanel1)
        Me.Panel3.Controls.Add(Me.GradientPanel2)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 25)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(842, 63)
        Me.Panel3.TabIndex = 293
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(258, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(249, 24)
        Me.Panel1.TabIndex = 303
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Location = New System.Drawing.Point(10, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(235, 19)
        Me.Label1.TabIndex = 170
        Me.Label1.Text = "Producto:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GradientPanel3
        '
        Me.GradientPanel3.BackColor = System.Drawing.Color.White
        Me.GradientPanel3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.GradientPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel3.Controls.Add(Me.txtExistencias)
        Me.GradientPanel3.Location = New System.Drawing.Point(258, 28)
        Me.GradientPanel3.Name = "GradientPanel3"
        Me.GradientPanel3.Size = New System.Drawing.Size(249, 32)
        Me.GradientPanel3.TabIndex = 302
        '
        'txtExistencias
        '
        Me.txtExistencias.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtExistencias.Location = New System.Drawing.Point(5, 5)
        Me.txtExistencias.Name = "txtExistencias"
        Me.txtExistencias.ReadOnly = True
        Me.txtExistencias.Size = New System.Drawing.Size(239, 19)
        Me.txtExistencias.TabIndex = 206
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BackColor = System.Drawing.Color.White
        Me.GradientPanel1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.Label3)
        Me.GradientPanel1.Controls.Add(Me.Label2)
        Me.GradientPanel1.Controls.Add(Me.chAgrupa2)
        Me.GradientPanel1.Controls.Add(Me.chAgrupa1)
        Me.GradientPanel1.Location = New System.Drawing.Point(684, 6)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(242, 51)
        Me.GradientPanel1.TabIndex = 300
        Me.GradientPanel1.Visible = False
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label3.Location = New System.Drawing.Point(62, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 22)
        Me.Label3.TabIndex = 233
        Me.Label3.Text = "Filtro dinámico"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label2.Location = New System.Drawing.Point(44, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 22)
        Me.Label2.TabIndex = 232
        Me.Label2.Text = "Filtro en columnas"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chAgrupa2
        '
        ActiveStateCollection1.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer))
        ActiveStateCollection1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        ActiveStateCollection1.HoverColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer))
        ActiveStateCollection1.Text = "Si"
        Me.chAgrupa2.ActiveState = ActiveStateCollection1
        Me.chAgrupa2.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.chAgrupa2.ForeColor = System.Drawing.Color.Black
        InactiveStateCollection1.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer))
        InactiveStateCollection1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        InactiveStateCollection1.ForeColor = System.Drawing.Color.White
        InactiveStateCollection1.HoverColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer))
        InactiveStateCollection1.Text = "No"
        Me.chAgrupa2.InactiveState = InactiveStateCollection1
        Me.chAgrupa2.Location = New System.Drawing.Point(145, 26)
        Me.chAgrupa2.MinimumSize = New System.Drawing.Size(52, 19)
        Me.chAgrupa2.Name = "chAgrupa2"
        Me.chAgrupa2.Renderer = ToggleButtonRenderer1
        Me.chAgrupa2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chAgrupa2.Size = New System.Drawing.Size(92, 20)
        SliderCollection1.BackColor = System.Drawing.Color.White
        SliderCollection1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        SliderCollection1.ForeColor = System.Drawing.Color.White
        SliderCollection1.HoverColor = System.Drawing.Color.FromArgb(CType(CType(8, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(171, Byte), Integer))
        SliderCollection1.Width = 30
        Me.chAgrupa2.Slider = SliderCollection1
        Me.chAgrupa2.TabIndex = 231
        Me.chAgrupa2.Text = "Button1"
        '
        'chAgrupa1
        '
        ActiveStateCollection2.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer))
        ActiveStateCollection2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        ActiveStateCollection2.HoverColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer))
        ActiveStateCollection2.Text = "Si"
        Me.chAgrupa1.ActiveState = ActiveStateCollection2
        Me.chAgrupa1.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.chAgrupa1.ForeColor = System.Drawing.Color.Black
        InactiveStateCollection2.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer))
        InactiveStateCollection2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        InactiveStateCollection2.ForeColor = System.Drawing.Color.White
        InactiveStateCollection2.HoverColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer))
        InactiveStateCollection2.Text = "No"
        Me.chAgrupa1.InactiveState = InactiveStateCollection2
        Me.chAgrupa1.Location = New System.Drawing.Point(145, 3)
        Me.chAgrupa1.MinimumSize = New System.Drawing.Size(52, 19)
        Me.chAgrupa1.Name = "chAgrupa1"
        Me.chAgrupa1.Renderer = ToggleButtonRenderer2
        Me.chAgrupa1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chAgrupa1.Size = New System.Drawing.Size(92, 20)
        SliderCollection2.BackColor = System.Drawing.Color.White
        SliderCollection2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        SliderCollection2.ForeColor = System.Drawing.Color.White
        SliderCollection2.HoverColor = System.Drawing.Color.FromArgb(CType(CType(8, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(171, Byte), Integer))
        SliderCollection2.Width = 30
        Me.chAgrupa1.Slider = SliderCollection2
        Me.chAgrupa1.TabIndex = 230
        Me.chAgrupa1.Text = "Button1"
        '
        'GradientPanel2
        '
        Me.GradientPanel2.BackColor = System.Drawing.Color.White
        Me.GradientPanel2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.GradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel2.Controls.Add(Me.txtAlmacen)
        Me.GradientPanel2.Location = New System.Drawing.Point(3, 28)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(249, 32)
        Me.GradientPanel2.TabIndex = 296
        '
        'txtAlmacen
        '
        Me.txtAlmacen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAlmacen.Location = New System.Drawing.Point(5, 5)
        Me.txtAlmacen.Name = "txtAlmacen"
        Me.txtAlmacen.ReadOnly = True
        Me.txtAlmacen.Size = New System.Drawing.Size(239, 19)
        Me.txtAlmacen.TabIndex = 206
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Panel4.BackgroundImage = CType(resources.GetObject("Panel4.BackgroundImage"), System.Drawing.Image)
        Me.Panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Location = New System.Drawing.Point(3, 4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(249, 24)
        Me.Panel4.TabIndex = 295
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label7.Location = New System.Drawing.Point(10, 3)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(268, 19)
        Me.Label7.TabIndex = 170
        Me.Label7.Text = "Almacén"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStrip3
        '
        Me.ToolStrip3.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ToolStrip3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.lblEstado})
        Me.ToolStrip3.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip3.Size = New System.Drawing.Size(842, 25)
        Me.ToolStrip3.TabIndex = 291
        Me.ToolStrip3.Text = "ToolStrip3"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'lblEstado
        '
        Me.lblEstado.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(102, 22)
        Me.lblEstado.Text = "Precios de compra."
        '
        'frmTotalAlmacenDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(842, 279)
        Me.Controls.Add(Me.dgvTotalesDetalle)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.ToolStrip3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTotalAlmacenDetalle"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Precios x Proveedor"
        CType(Me.dgvTotalesDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel3.ResumeLayout(False)
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        CType(Me.chAgrupa2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chAgrupa1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblEstado As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Private WithEvents Panel1 As System.Windows.Forms.Panel
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents GradientPanel3 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents txtExistencias As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Private WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents chAgrupa2 As Syncfusion.Windows.Forms.Tools.ToggleButton
    Private WithEvents chAgrupa1 As Syncfusion.Windows.Forms.Tools.ToggleButton
    Private WithEvents GradientPanel2 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents txtAlmacen As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Private WithEvents Panel4 As System.Windows.Forms.Panel
    Private WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dgvTotalesDetalle As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
End Class

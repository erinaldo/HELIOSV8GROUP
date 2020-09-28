Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormOrgainizacionV2
    Inherits MetroForm

    'Form overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormOrgainizacionV2))
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim BannerTextInfo1 As Syncfusion.Windows.Forms.BannerTextInfo = New Syncfusion.Windows.Forms.BannerTextInfo()
        Dim BannerTextInfo2 As Syncfusion.Windows.Forms.BannerTextInfo = New Syncfusion.Windows.Forms.BannerTextInfo()
        Dim BannerTextInfo3 As Syncfusion.Windows.Forms.BannerTextInfo = New Syncfusion.Windows.Forms.BannerTextInfo()
        Me.TextEmpresa = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboUnidadNegocio = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.PanelLogin = New System.Windows.Forms.Panel()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.PNCARGOS = New System.Windows.Forms.Panel()
        Me.dgPerfilesUsuario = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtRuc = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar()
        Me.RoundButton23 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.UsernameTextBox = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.PasswordTextBox = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.bunifuImageButton2 = New Bunifu.Framework.UI.BunifuImageButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.splashControl1 = New Syncfusion.Windows.Forms.Tools.SplashControl()
        Me.bannerTextProvider1 = New Syncfusion.Windows.Forms.BannerTextProvider(Me.components)
        Me.RoundButton22 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        Me.RoundButton21 = New Helios.Cont.Presentation.WinForm.RoundButton2(Me.components)
        CType(Me.TextEmpresa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComboUnidadNegocio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelLogin.SuspendLayout()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        Me.PNCARGOS.SuspendLayout()
        CType(Me.dgPerfilesUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRuc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel6.SuspendLayout()
        CType(Me.UsernameTextBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PasswordTextBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bunifuImageButton2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextEmpresa
        '
        Me.TextEmpresa.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextEmpresa.BeforeTouchSize = New System.Drawing.Size(429, 24)
        Me.TextEmpresa.BorderColor = System.Drawing.SystemColors.MenuHighlight
        Me.TextEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextEmpresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextEmpresa.CornerRadius = 4
        Me.TextEmpresa.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextEmpresa.Enabled = False
        Me.TextEmpresa.Font = New System.Drawing.Font("Calibri Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEmpresa.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TextEmpresa.Location = New System.Drawing.Point(43, 72)
        Me.TextEmpresa.Metrocolor = System.Drawing.SystemColors.MenuHighlight
        Me.TextEmpresa.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextEmpresa.Name = "TextEmpresa"
        Me.TextEmpresa.Size = New System.Drawing.Size(429, 24)
        Me.TextEmpresa.TabIndex = 516
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(80, 111)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 19)
        Me.Label1.TabIndex = 519
        Me.Label1.Text = "Rubro"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(80, 174)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 19)
        Me.Label2.TabIndex = 523
        Me.Label2.Text = "Segmento"
        '
        'ComboUnidadNegocio
        '
        Me.ComboUnidadNegocio.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.ComboUnidadNegocio.BeforeTouchSize = New System.Drawing.Size(267, 24)
        Me.ComboUnidadNegocio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboUnidadNegocio.FlatBorderColor = System.Drawing.Color.DarkGray
        Me.ComboUnidadNegocio.Font = New System.Drawing.Font("Tahoma", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboUnidadNegocio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.ComboUnidadNegocio.Location = New System.Drawing.Point(33, 131)
        Me.ComboUnidadNegocio.MetroBorderColor = System.Drawing.Color.Silver
        Me.ComboUnidadNegocio.Name = "ComboUnidadNegocio"
        Me.ComboUnidadNegocio.Size = New System.Drawing.Size(267, 24)
        Me.ComboUnidadNegocio.Style = Syncfusion.Windows.Forms.VisualStyle.Office2016Black
        Me.ComboUnidadNegocio.TabIndex = 526
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label3.Location = New System.Drawing.Point(30, 110)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(134, 19)
        Me.Label3.TabIndex = 525
        Me.Label3.Text = "Unidad de Órganica"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkColor = System.Drawing.SystemColors.Highlight
        Me.LinkLabel1.Location = New System.Drawing.Point(478, 141)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(42, 15)
        Me.LinkLabel1.TabIndex = 546
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Nuevo"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel2.LinkColor = System.Drawing.SystemColors.Highlight
        Me.LinkLabel2.Location = New System.Drawing.Point(478, 205)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(42, 15)
        Me.LinkLabel2.TabIndex = 547
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Nuevo"
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel3.LinkColor = System.Drawing.SystemColors.Highlight
        Me.LinkLabel3.Location = New System.Drawing.Point(804, 18)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(42, 15)
        Me.LinkLabel3.TabIndex = 548
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "Nuevo"
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel1.Location = New System.Drawing.Point(43, 129)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(33, 38)
        Me.Panel1.TabIndex = 549
        '
        'LinkLabel4
        '
        Me.LinkLabel4.AutoSize = True
        Me.LinkLabel4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel4.LinkColor = System.Drawing.SystemColors.Highlight
        Me.LinkLabel4.Location = New System.Drawing.Point(477, 78)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(37, 15)
        Me.LinkLabel4.TabIndex = 550
        Me.LinkLabel4.TabStop = True
        Me.LinkLabel4.Text = "Editar"
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), System.Drawing.Image)
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel2.Location = New System.Drawing.Point(43, 193)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(33, 38)
        Me.Panel2.TabIndex = 551
        '
        'Panel3
        '
        Me.Panel3.BackgroundImage = CType(resources.GetObject("Panel3.BackgroundImage"), System.Drawing.Image)
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel3.Location = New System.Drawing.Point(43, 253)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(33, 38)
        Me.Panel3.TabIndex = 552
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(40, 53)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(50, 14)
        Me.Label14.TabIndex = 553
        Me.Label14.Text = "Empresa"
        '
        'PanelLogin
        '
        Me.PanelLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PanelLogin.Controls.Add(Me.GradientPanel1)
        Me.PanelLogin.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelLogin.Location = New System.Drawing.Point(0, 0)
        Me.PanelLogin.Name = "PanelLogin"
        Me.PanelLogin.Size = New System.Drawing.Size(320, 411)
        Me.PanelLogin.TabIndex = 554
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BackgroundImage = CType(resources.GetObject("GradientPanel1.BackgroundImage"), System.Drawing.Image)
        Me.GradientPanel1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(156, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.PNCARGOS)
        Me.GradientPanel1.Controls.Add(Me.Button1)
        Me.GradientPanel1.Controls.Add(Me.Label7)
        Me.GradientPanel1.Controls.Add(Me.txtRuc)
        Me.GradientPanel1.Controls.Add(Me.ComboUnidadNegocio)
        Me.GradientPanel1.Controls.Add(Me.Label3)
        Me.GradientPanel1.Controls.Add(Me.Label8)
        Me.GradientPanel1.Controls.Add(Me.Panel4)
        Me.GradientPanel1.Controls.Add(Me.bunifuImageButton2)
        Me.GradientPanel1.Controls.Add(Me.Label5)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(320, 411)
        Me.GradientPanel1.TabIndex = 563
        '
        'PNCARGOS
        '
        Me.PNCARGOS.BackColor = System.Drawing.Color.Transparent
        Me.PNCARGOS.Controls.Add(Me.dgPerfilesUsuario)
        Me.PNCARGOS.Controls.Add(Me.Label11)
        Me.PNCARGOS.Location = New System.Drawing.Point(22, 43)
        Me.PNCARGOS.Name = "PNCARGOS"
        Me.PNCARGOS.Size = New System.Drawing.Size(290, 267)
        Me.PNCARGOS.TabIndex = 578
        Me.PNCARGOS.Visible = False
        '
        'dgPerfilesUsuario
        '
        Me.dgPerfilesUsuario.ActivateCurrentCellBehavior = Syncfusion.Windows.Forms.Grid.GridCellActivateAction.SelectAll
        Me.dgPerfilesUsuario.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.dgPerfilesUsuario.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        Me.dgPerfilesUsuario.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.dgPerfilesUsuario.BackColor = System.Drawing.Color.Black
        Me.dgPerfilesUsuario.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Office2016
        Me.dgPerfilesUsuario.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.dgPerfilesUsuario.Location = New System.Drawing.Point(12, 33)
        Me.dgPerfilesUsuario.Name = "dgPerfilesUsuario"
        Me.dgPerfilesUsuario.Office2016ScrollBarsColorScheme = Syncfusion.Windows.Forms.ScrollBarOffice2016ColorScheme.Black
        Me.dgPerfilesUsuario.ShowColumnHeaders = False
        Me.dgPerfilesUsuario.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.dgPerfilesUsuario.Size = New System.Drawing.Size(266, 226)
        Me.dgPerfilesUsuario.TabIndex = 577
        Me.dgPerfilesUsuario.TableDescriptor.AllowNew = False
        Me.dgPerfilesUsuario.TableDescriptor.Appearance.AnyCell.Font.Facename = "Segoe UI"
        Me.dgPerfilesUsuario.TableDescriptor.Appearance.AnyCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.dgPerfilesUsuario.TableDescriptor.Appearance.AnyGroupCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgPerfilesUsuario.TableDescriptor.Appearance.AnyGroupCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgPerfilesUsuario.TableDescriptor.Appearance.AnyGroupCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer)))
        Me.dgPerfilesUsuario.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgPerfilesUsuario.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgPerfilesUsuario.TableDescriptor.Appearance.AnySummaryCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgPerfilesUsuario.TableDescriptor.Appearance.AnySummaryCell.Borders.Top = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgPerfilesUsuario.TableDescriptor.Appearance.AnySummaryCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)))
        Me.dgPerfilesUsuario.TableDescriptor.Appearance.ColumnHeaderCell.Font.Bold = True
        Me.dgPerfilesUsuario.TableDescriptor.Appearance.ColumnHeaderCell.Font.Italic = False
        Me.dgPerfilesUsuario.TableDescriptor.Appearance.ColumnHeaderCell.Font.Size = 8.0!
        Me.dgPerfilesUsuario.TableDescriptor.Appearance.GroupCaptionCell.CellType = """ColumnHeader"""
        GridColumnDescriptor1.MappingName = "ID"
        GridColumnDescriptor1.Name = "ID"
        GridColumnDescriptor1.Width = 0
        GridColumnDescriptor2.MappingName = "CARGO"
        GridColumnDescriptor2.Name = "CARGO"
        GridColumnDescriptor2.ReadOnly = True
        GridColumnDescriptor2.Width = 250
        Me.dgPerfilesUsuario.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2})
        Me.dgPerfilesUsuario.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.dgPerfilesUsuario.TableDescriptor.TableOptions.RecordRowHeight = 20
        Me.dgPerfilesUsuario.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("ID"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("CARGO")})
        Me.dgPerfilesUsuario.TableOptions.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.dgPerfilesUsuario.TableOptions.SelectionTextColor = System.Drawing.SystemColors.HighlightText
        Me.dgPerfilesUsuario.Text = "GridGroupingControl2"
        Me.dgPerfilesUsuario.TopLevelGroupOptions.IsExpandedInitialValue = True
        Me.dgPerfilesUsuario.TopLevelGroupOptions.RepaintCaptionWhenItemsChanged = True
        Me.dgPerfilesUsuario.TopLevelGroupOptions.ShowAddNewRecordAfterDetails = False
        Me.dgPerfilesUsuario.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = True
        Me.dgPerfilesUsuario.TopLevelGroupOptions.ShowCaption = False
        Me.dgPerfilesUsuario.TopLevelGroupOptions.ShowCaptionPlusMinus = False
        Me.dgPerfilesUsuario.TopLevelGroupOptions.ShowCaptionSummaryCells = True
        Me.dgPerfilesUsuario.TopLevelGroupOptions.ShowColumnHeaders = False
        Me.dgPerfilesUsuario.TopLevelGroupOptions.ShowFilterBar = False
        Me.dgPerfilesUsuario.TopLevelGroupOptions.ShowGroupFooter = False
        Me.dgPerfilesUsuario.TopLevelGroupOptions.ShowGroupHeader = False
        Me.dgPerfilesUsuario.TopLevelGroupOptions.ShowGroupIndentAsCoveredRange = False
        Me.dgPerfilesUsuario.TopLevelGroupOptions.ShowGroupPreview = False
        Me.dgPerfilesUsuario.TopLevelGroupOptions.ShowGroupSummaryWhenCollapsed = False
        Me.dgPerfilesUsuario.TopLevelGroupOptions.ShowStackedHeaders = True
        Me.dgPerfilesUsuario.TopLevelGroupOptions.ShowSummaries = True
        Me.dgPerfilesUsuario.UseRightToLeftCompatibleTextBox = True
        Me.dgPerfilesUsuario.VersionInfo = "12.4400.0.24"
        Me.dgPerfilesUsuario.WantTabKey = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(8, 9)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(192, 19)
        Me.Label11.TabIndex = 573
        Me.Label11.Text = "Cargos (Seleccione un cargo)"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.arrow_circle_135_left
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Location = New System.Drawing.Point(282, 71)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(18, 27)
        Me.Button1.TabIndex = 576
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(29, 43)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 19)
        Me.Label7.TabIndex = 574
        Me.Label7.Text = "Empresa"
        '
        'txtRuc
        '
        Me.txtRuc.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        BannerTextInfo1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        BannerTextInfo1.Text = "Ingrese usuario..."
        BannerTextInfo1.Visible = True
        Me.bannerTextProvider1.SetBannerText(Me.txtRuc, BannerTextInfo1)
        Me.txtRuc.BeforeTouchSize = New System.Drawing.Size(429, 24)
        Me.txtRuc.BorderColor = System.Drawing.Color.Gray
        Me.txtRuc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRuc.CornerRadius = 4
        Me.txtRuc.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txtRuc.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRuc.ForeColor = System.Drawing.Color.White
        Me.txtRuc.Location = New System.Drawing.Point(32, 69)
        Me.txtRuc.MaxLength = 70
        Me.txtRuc.Metrocolor = System.Drawing.Color.Silver
        Me.txtRuc.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtRuc.Name = "txtRuc"
        Me.txtRuc.NearImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.almacen
        Me.txtRuc.Size = New System.Drawing.Size(244, 29)
        Me.txtRuc.TabIndex = 573
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(11, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(16, 13)
        Me.Label8.TabIndex = 568
        Me.Label8.Text = "..."
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.Controls.Add(Me.Panel6)
        Me.Panel4.Controls.Add(Me.Label10)
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Controls.Add(Me.UsernameTextBox)
        Me.Panel4.Controls.Add(Me.PasswordTextBox)
        Me.Panel4.Location = New System.Drawing.Point(19, 162)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(293, 240)
        Me.Panel4.TabIndex = 568
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Transparent
        Me.Panel6.Controls.Add(Me.Label4)
        Me.Panel6.Controls.Add(Me.ProgressBar2)
        Me.Panel6.Controls.Add(Me.RoundButton23)
        Me.Panel6.Location = New System.Drawing.Point(8, 146)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(273, 89)
        Me.Panel6.TabIndex = 571
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Black
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label4.Location = New System.Drawing.Point(62, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(142, 19)
        Me.Label4.TabIndex = 560
        Me.Label4.Text = "Validando usuario . . ."
        '
        'ProgressBar2
        '
        Me.ProgressBar2.Location = New System.Drawing.Point(116, 74)
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(33, 10)
        Me.ProgressBar2.TabIndex = 561
        Me.ProgressBar2.Visible = False
        '
        'RoundButton23
        '
        Me.RoundButton23.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton23.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(156, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.RoundButton23.BeforeTouchSize = New System.Drawing.Size(262, 36)
        Me.RoundButton23.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundButton23.ForeColor = System.Drawing.Color.White
        Me.RoundButton23.IsBackStageButton = False
        Me.RoundButton23.Location = New System.Drawing.Point(7, 8)
        Me.RoundButton23.MetroColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(156, Byte), Integer), CType(CType(104, Byte), Integer))
        Me.RoundButton23.Name = "RoundButton23"
        Me.RoundButton23.Size = New System.Drawing.Size(262, 36)
        Me.RoundButton23.TabIndex = 559
        Me.RoundButton23.Text = "INGRESAR"
        Me.RoundButton23.UseVisualStyle = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(9, 4)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(57, 19)
        Me.Label10.TabIndex = 572
        Me.Label10.Text = "Usuario"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(9, 75)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(79, 19)
        Me.Label9.TabIndex = 571
        Me.Label9.Text = "Contraseña"
        '
        'UsernameTextBox
        '
        Me.UsernameTextBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        BannerTextInfo2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        BannerTextInfo2.Text = "Ingrese usuario..."
        BannerTextInfo2.Visible = True
        Me.bannerTextProvider1.SetBannerText(Me.UsernameTextBox, BannerTextInfo2)
        Me.UsernameTextBox.BeforeTouchSize = New System.Drawing.Size(429, 24)
        Me.UsernameTextBox.BorderColor = System.Drawing.Color.Gray
        Me.UsernameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UsernameTextBox.CornerRadius = 4
        Me.UsernameTextBox.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.UsernameTextBox.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UsernameTextBox.ForeColor = System.Drawing.Color.White
        Me.UsernameTextBox.Location = New System.Drawing.Point(12, 30)
        Me.UsernameTextBox.MaxLength = 70
        Me.UsernameTextBox.Metrocolor = System.Drawing.Color.Silver
        Me.UsernameTextBox.MinimumSize = New System.Drawing.Size(14, 10)
        Me.UsernameTextBox.Name = "UsernameTextBox"
        Me.UsernameTextBox.NearImage = CType(resources.GetObject("UsernameTextBox.NearImage"), System.Drawing.Image)
        Me.UsernameTextBox.Size = New System.Drawing.Size(268, 29)
        Me.UsernameTextBox.TabIndex = 14
        '
        'PasswordTextBox
        '
        Me.PasswordTextBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        BannerTextInfo3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        BannerTextInfo3.Text = "Ingrese contraseña... "
        BannerTextInfo3.Visible = True
        Me.bannerTextProvider1.SetBannerText(Me.PasswordTextBox, BannerTextInfo3)
        Me.PasswordTextBox.BeforeTouchSize = New System.Drawing.Size(429, 24)
        Me.PasswordTextBox.BorderColor = System.Drawing.Color.Gray
        Me.PasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PasswordTextBox.CornerRadius = 4
        Me.PasswordTextBox.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.PasswordTextBox.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PasswordTextBox.ForeColor = System.Drawing.Color.White
        Me.PasswordTextBox.Location = New System.Drawing.Point(13, 99)
        Me.PasswordTextBox.MaxLength = 20
        Me.PasswordTextBox.Metrocolor = System.Drawing.Color.Silver
        Me.PasswordTextBox.MinimumSize = New System.Drawing.Size(14, 10)
        Me.PasswordTextBox.Name = "PasswordTextBox"
        Me.PasswordTextBox.NearImage = CType(resources.GetObject("PasswordTextBox.NearImage"), System.Drawing.Image)
        Me.PasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.PasswordTextBox.Size = New System.Drawing.Size(267, 29)
        Me.PasswordTextBox.TabIndex = 15
        '
        'bunifuImageButton2
        '
        Me.bunifuImageButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bunifuImageButton2.BackColor = System.Drawing.Color.Black
        Me.bunifuImageButton2.Image = CType(resources.GetObject("bunifuImageButton2.Image"), System.Drawing.Image)
        Me.bunifuImageButton2.ImageActive = Nothing
        Me.bunifuImageButton2.Location = New System.Drawing.Point(292, -1)
        Me.bunifuImageButton2.Name = "bunifuImageButton2"
        Me.bunifuImageButton2.Size = New System.Drawing.Size(27, 27)
        Me.bunifuImageButton2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.bunifuImageButton2.TabIndex = 563
        Me.bunifuImageButton2.TabStop = False
        Me.bunifuImageButton2.Zoom = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Black
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(144, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 28)
        Me.Label5.TabIndex = 547
        Me.Label5.Text = "Login"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'splashControl1
        '
        Me.splashControl1.HideHostForm = True
        Me.splashControl1.HostForm = Me
        Me.splashControl1.SplashImage = CType(resources.GetObject("splashControl1.SplashImage"), System.Drawing.Image)
        Me.splashControl1.TimerInterval = 5500
        '
        'RoundButton22
        '
        Me.RoundButton22.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton22.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.RoundButton22.BeforeTouchSize = New System.Drawing.Size(115, 27)
        Me.RoundButton22.BorderStyleAdv = Syncfusion.Windows.Forms.ButtonAdvBorderStyle.Sunken
        Me.RoundButton22.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundButton22.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.RoundButton22.IsBackStageButton = False
        Me.RoundButton22.Location = New System.Drawing.Point(239, 318)
        Me.RoundButton22.Name = "RoundButton22"
        Me.RoundButton22.Size = New System.Drawing.Size(115, 27)
        Me.RoundButton22.TabIndex = 545
        Me.RoundButton22.Text = "CANCELAR"
        Me.RoundButton22.UseVisualStyle = True
        '
        'RoundButton21
        '
        Me.RoundButton21.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.RoundButton21.BackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.RoundButton21.BeforeTouchSize = New System.Drawing.Size(112, 36)
        Me.RoundButton21.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundButton21.ForeColor = System.Drawing.Color.White
        Me.RoundButton21.IsBackStageButton = False
        Me.RoundButton21.Location = New System.Drawing.Point(360, 310)
        Me.RoundButton21.Name = "RoundButton21"
        Me.RoundButton21.Size = New System.Drawing.Size(112, 36)
        Me.RoundButton21.TabIndex = 544
        Me.RoundButton21.Text = "ACCEDER"
        Me.RoundButton21.UseVisualStyle = True
        '
        'FormOrgainizacionV2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.CaptionForeColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(320, 411)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelLogin)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.LinkLabel4)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.LinkLabel3)
        Me.Controls.Add(Me.LinkLabel2)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.RoundButton22)
        Me.Controls.Add(Me.RoundButton21)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextEmpresa)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormOrgainizacionV2"
        Me.ShowIcon = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Organizacion"
        CType(Me.TextEmpresa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComboUnidadNegocio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelLogin.ResumeLayout(False)
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        Me.PNCARGOS.ResumeLayout(False)
        Me.PNCARGOS.PerformLayout()
        CType(Me.dgPerfilesUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRuc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        CType(Me.UsernameTextBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PasswordTextBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bunifuImageButton2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextEmpresa As Tools.TextBoxExt
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ComboUnidadNegocio As Tools.ComboBoxAdv
    Friend WithEvents Label3 As Label
    Friend WithEvents RoundButton22 As RoundButton2
    Friend WithEvents RoundButton21 As RoundButton2
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents LinkLabel4 As LinkLabel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label14 As Label
    Friend WithEvents PanelLogin As Panel
    Friend WithEvents PasswordTextBox As Tools.TextBoxExt
    Friend WithEvents UsernameTextBox As Tools.TextBoxExt
    Friend WithEvents Label5 As Label
    Friend WithEvents RoundButton23 As RoundButton2
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents ProgressBar2 As ProgressBar
    Friend WithEvents Label4 As Label
    Private WithEvents splashControl1 As Tools.SplashControl
    Friend WithEvents GradientPanel1 As Tools.GradientPanel
    Private WithEvents bunifuImageButton2 As Bunifu.Framework.UI.BunifuImageButton
    Private WithEvents bannerTextProvider1 As BannerTextProvider
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtRuc As Tools.TextBoxExt
    Friend WithEvents Button1 As Button
    Friend WithEvents dgPerfilesUsuario As Grid.Grouping.GridGroupingControl
    Friend WithEvents PNCARGOS As Panel
End Class

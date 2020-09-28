<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmContabilidadAsientosManuales
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmContabilidadAsientosManuales))
        Me.dgvCompra = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.GradientPanel17 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv2 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.cboAnio = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv12 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv13 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv18 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv19 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.cboMesCompra = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label85 = New System.Windows.Forms.Label()
        CType(Me.dgvCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel17, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel17.SuspendLayout()
        CType(Me.cboAnio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboMesCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvCompra
        '
        Me.dgvCompra.Appearance.AlternateRecordFieldCell.Font.Size = 8.0!
        Me.dgvCompra.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        Me.dgvCompra.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.dgvCompra.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dgvCompra.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCompra.FreezeCaption = False
        Me.dgvCompra.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgvCompra.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2010Blue
        Me.dgvCompra.Location = New System.Drawing.Point(0, 77)
        Me.dgvCompra.Name = "dgvCompra"
        Me.dgvCompra.Size = New System.Drawing.Size(1133, 339)
        Me.dgvCompra.TabIndex = 421
        Me.dgvCompra.TableDescriptor.AllowNew = False
        Me.dgvCompra.TableDescriptor.Appearance.AnyCell.Font.Facename = "Segoe UI"
        Me.dgvCompra.TableDescriptor.Appearance.AnyCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.dgvCompra.TableDescriptor.Appearance.AnyGroupCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCompra.TableDescriptor.Appearance.AnyGroupCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCompra.TableDescriptor.Appearance.AnyGroupCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer)))
        Me.dgvCompra.TableDescriptor.Appearance.AnyHeaderCell.Font.Size = 8.0!
        Me.dgvCompra.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCompra.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCompra.TableDescriptor.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White)
        Me.dgvCompra.TableDescriptor.Appearance.AnySummaryCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCompra.TableDescriptor.Appearance.AnySummaryCell.Borders.Top = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCompra.TableDescriptor.Appearance.AnySummaryCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)))
        Me.dgvCompra.TableDescriptor.Appearance.ColumnHeaderCell.Font.Bold = True
        Me.dgvCompra.TableDescriptor.Appearance.ColumnHeaderCell.Font.Italic = False
        Me.dgvCompra.TableDescriptor.Appearance.ColumnHeaderCell.Font.Size = 8.0!
        Me.dgvCompra.TableDescriptor.Appearance.GroupCaptionCell.CellType = """ColumnHeader"""
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.MappingName = "idDocumento"
        GridColumnDescriptor1.ReadOnly = True
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor1.Width = 0
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.HeaderText = "Descripcion"
        GridColumnDescriptor2.MappingName = "descripcion"
        GridColumnDescriptor2.ReadOnly = True
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor2.Width = 190
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.HeaderText = "Tipo"
        GridColumnDescriptor3.MappingName = "tipoBen"
        GridColumnDescriptor3.ReadOnly = True
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor3.Width = 50
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.HeaderText = "Nombres"
        GridColumnDescriptor4.MappingName = "beneficiario"
        GridColumnDescriptor4.ReadOnly = True
        GridColumnDescriptor4.SerializedImageArray = ""
        GridColumnDescriptor4.Width = 100
        GridColumnDescriptor5.HeaderImage = Nothing
        GridColumnDescriptor5.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor5.HeaderText = "TipoDoc"
        GridColumnDescriptor5.MappingName = "tipodoc"
        GridColumnDescriptor5.ReadOnly = True
        GridColumnDescriptor5.SerializedImageArray = ""
        GridColumnDescriptor5.Width = 60
        GridColumnDescriptor6.HeaderImage = Nothing
        GridColumnDescriptor6.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor6.HeaderText = "NroDoc."
        GridColumnDescriptor6.MappingName = "nrodoc"
        GridColumnDescriptor6.ReadOnly = True
        GridColumnDescriptor6.SerializedImageArray = ""
        GridColumnDescriptor6.Width = 80
        GridColumnDescriptor7.HeaderImage = Nothing
        GridColumnDescriptor7.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor7.HeaderText = "Moneda"
        GridColumnDescriptor7.MappingName = "moneda"
        GridColumnDescriptor7.ReadOnly = True
        GridColumnDescriptor7.SerializedImageArray = ""
        GridColumnDescriptor7.Width = 0
        GridColumnDescriptor8.HeaderImage = Nothing
        GridColumnDescriptor8.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor8.HeaderText = "T/C."
        GridColumnDescriptor8.MappingName = "tipoc"
        GridColumnDescriptor8.ReadOnly = True
        GridColumnDescriptor8.SerializedImageArray = ""
        GridColumnDescriptor8.Width = 0
        GridColumnDescriptor9.HeaderImage = Nothing
        GridColumnDescriptor9.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor9.HeaderText = "Importe MN"
        GridColumnDescriptor9.MappingName = "importemn"
        GridColumnDescriptor9.ReadOnly = True
        GridColumnDescriptor9.SerializedImageArray = ""
        GridColumnDescriptor9.Width = 0
        GridColumnDescriptor10.HeaderImage = Nothing
        GridColumnDescriptor10.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor10.HeaderText = "Importe ME"
        GridColumnDescriptor10.MappingName = "importeme"
        GridColumnDescriptor10.ReadOnly = True
        GridColumnDescriptor10.SerializedImageArray = ""
        GridColumnDescriptor10.Width = 0
        GridColumnDescriptor11.HeaderImage = Nothing
        GridColumnDescriptor11.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor11.HeaderText = "Fecha"
        GridColumnDescriptor11.MappingName = "fecha"
        GridColumnDescriptor11.ReadOnly = True
        GridColumnDescriptor11.SerializedImageArray = ""
        GridColumnDescriptor11.Width = 80
        GridColumnDescriptor12.HeaderImage = Nothing
        GridColumnDescriptor12.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor12.HeaderText = "Fecha Vcto."
        GridColumnDescriptor12.MappingName = "fechavct"
        GridColumnDescriptor12.ReadOnly = True
        GridColumnDescriptor12.SerializedImageArray = ""
        GridColumnDescriptor12.Width = 80
        GridColumnDescriptor13.HeaderImage = Nothing
        GridColumnDescriptor13.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor13.MappingName = "idBene"
        GridColumnDescriptor13.ReadOnly = True
        GridColumnDescriptor13.SerializedImageArray = ""
        GridColumnDescriptor13.Width = 0
        GridColumnDescriptor14.HeaderImage = Nothing
        GridColumnDescriptor14.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor14.MappingName = "identificacion"
        GridColumnDescriptor14.ReadOnly = True
        GridColumnDescriptor14.SerializedImageArray = ""
        GridColumnDescriptor14.Width = 0
        Me.dgvCompra.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7, GridColumnDescriptor8, GridColumnDescriptor9, GridColumnDescriptor10, GridColumnDescriptor11, GridColumnDescriptor12, GridColumnDescriptor13, GridColumnDescriptor14})
        Me.dgvCompra.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.dgvCompra.TableDescriptor.TableOptions.RecordRowHeight = 20
        Me.dgvCompra.TableDescriptor.TopLevelGroupOptions.ShowCaption = False
        Me.dgvCompra.Text = "GridGroupingControl2"
        Me.dgvCompra.VersionInfo = "12.4400.0.24"
        '
        'GradientPanel17
        '
        Me.GradientPanel17.BackColor = System.Drawing.Color.White
        Me.GradientPanel17.BorderColor = System.Drawing.Color.Silver
        Me.GradientPanel17.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.GradientPanel17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel17.Controls.Add(Me.ButtonAdv2)
        Me.GradientPanel17.Controls.Add(Me.cboAnio)
        Me.GradientPanel17.Controls.Add(Me.ProgressBar1)
        Me.GradientPanel17.Controls.Add(Me.ButtonAdv1)
        Me.GradientPanel17.Controls.Add(Me.ButtonAdv12)
        Me.GradientPanel17.Controls.Add(Me.ButtonAdv13)
        Me.GradientPanel17.Controls.Add(Me.ButtonAdv18)
        Me.GradientPanel17.Controls.Add(Me.ButtonAdv19)
        Me.GradientPanel17.Controls.Add(Me.cboMesCompra)
        Me.GradientPanel17.Controls.Add(Me.Label85)
        Me.GradientPanel17.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel17.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel17.Name = "GradientPanel17"
        Me.GradientPanel17.Size = New System.Drawing.Size(1133, 77)
        Me.GradientPanel17.TabIndex = 420
        '
        'ButtonAdv2
        '
        Me.ButtonAdv2.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv2.BackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(156, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.ButtonAdv2.BeforeTouchSize = New System.Drawing.Size(175, 46)
        Me.ButtonAdv2.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv2.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv2.IsBackStageButton = False
        Me.ButtonAdv2.Location = New System.Drawing.Point(620, 11)
        Me.ButtonAdv2.Name = "ButtonAdv2"
        Me.ButtonAdv2.Size = New System.Drawing.Size(175, 46)
        Me.ButtonAdv2.TabIndex = 533
        Me.ButtonAdv2.Text = "ASIENTOS CONTABLES QUE DETERMIAN COSTO O GASTO"
        Me.ButtonAdv2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv2.UseVisualStyle = True
        '
        'cboAnio
        '
        Me.cboAnio.BackColor = System.Drawing.Color.White
        Me.cboAnio.BeforeTouchSize = New System.Drawing.Size(60, 21)
        Me.cboAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAnio.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAnio.Location = New System.Drawing.Point(189, 19)
        Me.cboAnio.Name = "cboAnio"
        Me.cboAnio.Office2007ColorTheme = Syncfusion.Windows.Forms.Office2007Theme.Black
        Me.cboAnio.Office2010ColorTheme = Syncfusion.Windows.Forms.Office2010Theme.Black
        Me.cboAnio.Size = New System.Drawing.Size(60, 21)
        Me.cboAnio.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboAnio.TabIndex = 532
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(341, 17)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(100, 23)
        Me.ProgressBar1.TabIndex = 531
        Me.ProgressBar1.Visible = False
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.FromArgb(CType(CType(19, Byte), Integer), CType(CType(156, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(76, 23)
        Me.ButtonAdv1.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv1.Image = CType(resources.GetObject("ButtonAdv1.Image"), System.Drawing.Image)
        Me.ButtonAdv1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(447, 17)
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(76, 23)
        Me.ButtonAdv1.TabIndex = 530
        Me.ButtonAdv1.Text = "Nuevo"
        Me.ButtonAdv1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonAdv1.UseVisualStyle = True
        '
        'ButtonAdv12
        '
        Me.ButtonAdv12.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv12.BackColor = System.Drawing.Color.Silver
        Me.ButtonAdv12.BeforeTouchSize = New System.Drawing.Size(25, 23)
        Me.ButtonAdv12.BorderStyleAdv = Syncfusion.Windows.Forms.ButtonAdvBorderStyle.None
        Me.ButtonAdv12.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv12.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv12.Image = CType(resources.GetObject("ButtonAdv12.Image"), System.Drawing.Image)
        Me.ButtonAdv12.IsBackStageButton = False
        Me.ButtonAdv12.Location = New System.Drawing.Point(555, 17)
        Me.ButtonAdv12.Name = "ButtonAdv12"
        Me.ButtonAdv12.Size = New System.Drawing.Size(25, 23)
        Me.ButtonAdv12.TabIndex = 529
        Me.ButtonAdv12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv12.UseVisualStyle = True
        '
        'ButtonAdv13
        '
        Me.ButtonAdv13.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv13.BackColor = System.Drawing.Color.Gray
        Me.ButtonAdv13.BeforeTouchSize = New System.Drawing.Size(25, 23)
        Me.ButtonAdv13.BorderStyleAdv = Syncfusion.Windows.Forms.ButtonAdvBorderStyle.None
        Me.ButtonAdv13.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv13.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv13.Image = CType(resources.GetObject("ButtonAdv13.Image"), System.Drawing.Image)
        Me.ButtonAdv13.IsBackStageButton = False
        Me.ButtonAdv13.Location = New System.Drawing.Point(527, 17)
        Me.ButtonAdv13.Name = "ButtonAdv13"
        Me.ButtonAdv13.Size = New System.Drawing.Size(25, 23)
        Me.ButtonAdv13.TabIndex = 528
        Me.ButtonAdv13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv13.UseVisualStyle = True
        '
        'ButtonAdv18
        '
        Me.ButtonAdv18.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv18.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(131, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonAdv18.BeforeTouchSize = New System.Drawing.Size(119, 23)
        Me.ButtonAdv18.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv18.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv18.Image = CType(resources.GetObject("ButtonAdv18.Image"), System.Drawing.Image)
        Me.ButtonAdv18.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv18.IsBackStageButton = False
        Me.ButtonAdv18.Location = New System.Drawing.Point(900, 14)
        Me.ButtonAdv18.Name = "ButtonAdv18"
        Me.ButtonAdv18.Size = New System.Drawing.Size(119, 23)
        Me.ButtonAdv18.TabIndex = 5
        Me.ButtonAdv18.Text = "Cambiar período"
        Me.ButtonAdv18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonAdv18.UseVisualStyle = True
        Me.ButtonAdv18.Visible = False
        '
        'ButtonAdv19
        '
        Me.ButtonAdv19.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv19.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.ButtonAdv19.BeforeTouchSize = New System.Drawing.Size(86, 23)
        Me.ButtonAdv19.Font = New System.Drawing.Font("Corbel", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv19.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv19.Image = CType(resources.GetObject("ButtonAdv19.Image"), System.Drawing.Image)
        Me.ButtonAdv19.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv19.IsBackStageButton = False
        Me.ButtonAdv19.Location = New System.Drawing.Point(253, 17)
        Me.ButtonAdv19.Name = "ButtonAdv19"
        Me.ButtonAdv19.Size = New System.Drawing.Size(86, 23)
        Me.ButtonAdv19.TabIndex = 3
        Me.ButtonAdv19.Text = "Consultar"
        Me.ButtonAdv19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonAdv19.UseVisualStyle = True
        '
        'cboMesCompra
        '
        Me.cboMesCompra.BackColor = System.Drawing.Color.White
        Me.cboMesCompra.BeforeTouchSize = New System.Drawing.Size(121, 21)
        Me.cboMesCompra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMesCompra.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMesCompra.Location = New System.Drawing.Point(65, 19)
        Me.cboMesCompra.Name = "cboMesCompra"
        Me.cboMesCompra.Size = New System.Drawing.Size(121, 21)
        Me.cboMesCompra.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboMesCompra.TabIndex = 1
        '
        'Label85
        '
        Me.Label85.AutoSize = True
        Me.Label85.Location = New System.Drawing.Point(14, 24)
        Me.Label85.Name = "Label85"
        Me.Label85.Size = New System.Drawing.Size(47, 13)
        Me.Label85.TabIndex = 0
        Me.Label85.Text = "Período"
        '
        'frmContabilidadAsientosManuales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1133, 416)
        Me.Controls.Add(Me.dgvCompra)
        Me.Controls.Add(Me.GradientPanel17)
        Me.Name = "frmContabilidadAsientosManuales"
        Me.ShowIcon = False
        Me.Text = "Asientos Manuales"
        CType(Me.dgvCompra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel17, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel17.ResumeLayout(False)
        Me.GradientPanel17.PerformLayout()
        CType(Me.cboAnio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboMesCompra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvCompra As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents GradientPanel17 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents ButtonAdv12 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents ButtonAdv13 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents ButtonAdv18 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents ButtonAdv19 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents cboMesCompra As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label85 As Label
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents cboAnio As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents ButtonAdv2 As Syncfusion.Windows.Forms.ButtonAdv
End Class

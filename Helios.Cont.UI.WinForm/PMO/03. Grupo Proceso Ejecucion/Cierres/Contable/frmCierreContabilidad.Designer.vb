<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCierreContabilidad
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCierreContabilidad))
        Dim GridColumnDescriptor8 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor9 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor10 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor11 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor12 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor13 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor14 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridStackedHeaderRowDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderRowDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderRowDescriptor()
        Dim GridSummaryRowDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor()
        Dim GridSummaryColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor()
        Dim GridSummaryColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor()
        Me.PanelError = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnCard = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.txtfecha = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvCierre = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.PanelError.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.txtfecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtfecha.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCierre, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelError
        '
        Me.PanelError.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PanelError.Controls.Add(Me.PictureBox1)
        Me.PanelError.Controls.Add(Me.lblEstado)
        Me.PanelError.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelError.Location = New System.Drawing.Point(0, 0)
        Me.PanelError.Name = "PanelError"
        Me.PanelError.Size = New System.Drawing.Size(878, 22)
        Me.PanelError.TabIndex = 292
        Me.PanelError.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(859, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(19, 22)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 288
        Me.PictureBox1.TabStop = False
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.BackColor = System.Drawing.Color.Transparent
        Me.lblEstado.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblEstado.Location = New System.Drawing.Point(9, 4)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(79, 13)
        Me.lblEstado.TabIndex = 0
        Me.lblEstado.Text = "Mensaje error"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnCard)
        Me.Panel1.Controls.Add(Me.txtfecha)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 22)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(878, 61)
        Me.Panel1.TabIndex = 293
        '
        'btnCard
        '
        Me.btnCard.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btnCard.BackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.btnCard.BeforeTouchSize = New System.Drawing.Size(93, 30)
        Me.btnCard.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCard.ForeColor = System.Drawing.Color.White
        Me.btnCard.Image = CType(resources.GetObject("btnCard.Image"), System.Drawing.Image)
        Me.btnCard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCard.IsBackStageButton = False
        Me.btnCard.Location = New System.Drawing.Point(141, 21)
        Me.btnCard.MetroColor = System.Drawing.Color.Green
        Me.btnCard.Name = "btnCard"
        Me.btnCard.Size = New System.Drawing.Size(93, 30)
        Me.btnCard.TabIndex = 423
        Me.btnCard.Text = "CERRAR"
        Me.btnCard.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCard.UseVisualStyle = True
        Me.btnCard.UseVisualStyleBackColor = False
        '
        'txtfecha
        '
        Me.txtfecha.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtfecha.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtfecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtfecha.Calendar.AllowMultipleSelection = False
        Me.txtfecha.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtfecha.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtfecha.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtfecha.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtfecha.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtfecha.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtfecha.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtfecha.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfecha.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtfecha.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtfecha.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtfecha.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtfecha.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtfecha.Calendar.Iso8601CalenderFormat = False
        Me.txtfecha.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtfecha.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtfecha.Calendar.Name = "monthCalendar"
        Me.txtfecha.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtfecha.Calendar.SelectedDates = New Date(-1) {}
        Me.txtfecha.Calendar.Size = New System.Drawing.Size(117, 174)
        Me.txtfecha.Calendar.SizeToFit = True
        Me.txtfecha.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtfecha.Calendar.TabIndex = 0
        Me.txtfecha.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtfecha.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtfecha.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtfecha.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtfecha.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtfecha.Calendar.NoneButton.IsBackStageButton = False
        Me.txtfecha.Calendar.NoneButton.Location = New System.Drawing.Point(45, 0)
        Me.txtfecha.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtfecha.Calendar.NoneButton.Text = "None"
        Me.txtfecha.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtfecha.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtfecha.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtfecha.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtfecha.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtfecha.Calendar.TodayButton.IsBackStageButton = False
        Me.txtfecha.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtfecha.Calendar.TodayButton.Size = New System.Drawing.Size(45, 20)
        Me.txtfecha.Calendar.TodayButton.Text = "Today"
        Me.txtfecha.Calendar.TodayButton.UseVisualStyle = True
        Me.txtfecha.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfecha.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtfecha.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtfecha.DropDownImage = Nothing
        Me.txtfecha.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtfecha.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtfecha.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtfecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtfecha.Location = New System.Drawing.Point(14, 31)
        Me.txtfecha.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtfecha.MinValue = New Date(CType(0, Long))
        Me.txtfecha.Name = "txtfecha"
        Me.txtfecha.ShowCheckBox = False
        Me.txtfecha.Size = New System.Drawing.Size(121, 20)
        Me.txtfecha.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtfecha.TabIndex = 1
        Me.txtfecha.Value = New Date(2016, 3, 1, 12, 9, 27, 875)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "FECHA DEL CIERRE"
        '
        'dgvCierre
        '
        Me.dgvCierre.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        Me.dgvCierre.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.dgvCierre.BackColor = System.Drawing.SystemColors.Window
        Me.dgvCierre.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCierre.FreezeCaption = False
        Me.dgvCierre.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgvCierre.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.dgvCierre.Location = New System.Drawing.Point(0, 83)
        Me.dgvCierre.Name = "dgvCierre"
        Me.dgvCierre.Size = New System.Drawing.Size(878, 296)
        Me.dgvCierre.TabIndex = 294
        Me.dgvCierre.TableDescriptor.AllowNew = False
        Me.dgvCierre.TableDescriptor.Appearance.AnyCell.Font.Facename = "Segoe UI"
        Me.dgvCierre.TableDescriptor.Appearance.AnyCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.dgvCierre.TableDescriptor.Appearance.AnyGroupCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCierre.TableDescriptor.Appearance.AnyGroupCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCierre.TableDescriptor.Appearance.AnyGroupCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer)))
        Me.dgvCierre.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCierre.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCierre.TableDescriptor.Appearance.AnySummaryCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCierre.TableDescriptor.Appearance.AnySummaryCell.Borders.Top = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCierre.TableDescriptor.Appearance.AnySummaryCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)))
        Me.dgvCierre.TableDescriptor.Appearance.ColumnHeaderCell.Font.Bold = True
        Me.dgvCierre.TableDescriptor.Appearance.ColumnHeaderCell.Font.Italic = False
        Me.dgvCierre.TableDescriptor.Appearance.ColumnHeaderCell.Font.Size = 8.0!
        Me.dgvCierre.TableDescriptor.Appearance.GroupCaptionCell.CellType = """ColumnHeader"""
        GridColumnDescriptor8.HeaderImage = Nothing
        GridColumnDescriptor8.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor8.HeaderText = "Código"
        GridColumnDescriptor8.MappingName = "cuenta"
        GridColumnDescriptor8.ReadOnly = True
        GridColumnDescriptor8.SerializedImageArray = ""
        GridColumnDescriptor8.Width = 70
        GridColumnDescriptor9.HeaderImage = Nothing
        GridColumnDescriptor9.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor9.HeaderText = "Denominación"
        GridColumnDescriptor9.MappingName = "descripcion"
        GridColumnDescriptor9.Name = "descripcion"
        GridColumnDescriptor9.ReadOnly = True
        GridColumnDescriptor9.SerializedImageArray = ""
        GridColumnDescriptor9.Width = 350
        GridColumnDescriptor10.HeaderImage = Nothing
        GridColumnDescriptor10.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor10.HeaderText = "Debe"
        GridColumnDescriptor10.MappingName = "debe"
        GridColumnDescriptor10.ReadOnly = True
        GridColumnDescriptor10.SerializedImageArray = ""
        GridColumnDescriptor10.Width = 100
        GridColumnDescriptor11.HeaderImage = Nothing
        GridColumnDescriptor11.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor11.HeaderText = "Haber"
        GridColumnDescriptor11.MappingName = "haber"
        GridColumnDescriptor11.ReadOnly = True
        GridColumnDescriptor11.SerializedImageArray = ""
        GridColumnDescriptor11.Width = 100
        GridColumnDescriptor12.HeaderImage = Nothing
        GridColumnDescriptor12.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor12.HeaderText = "Debe"
        GridColumnDescriptor12.MappingName = "debeus"
        GridColumnDescriptor12.ReadOnly = True
        GridColumnDescriptor12.SerializedImageArray = ""
        GridColumnDescriptor12.Width = 100
        GridColumnDescriptor13.HeaderImage = Nothing
        GridColumnDescriptor13.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor13.HeaderText = "Haber"
        GridColumnDescriptor13.MappingName = "haberus"
        GridColumnDescriptor13.ReadOnly = True
        GridColumnDescriptor13.SerializedImageArray = ""
        GridColumnDescriptor13.Width = 100
        GridColumnDescriptor14.HeaderImage = Nothing
        GridColumnDescriptor14.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor14.MappingName = "tipoasiento"
        GridColumnDescriptor14.ReadOnly = True
        GridColumnDescriptor14.SerializedImageArray = ""
        GridColumnDescriptor14.Width = 30
        Me.dgvCierre.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor8, GridColumnDescriptor9, GridColumnDescriptor10, GridColumnDescriptor11, GridColumnDescriptor12, GridColumnDescriptor13, GridColumnDescriptor14})
        GridStackedHeaderRowDescriptor2.Headers.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor("StackedHeader 1", "N A C I O N A L", New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("debe"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("haber")}), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor("StackedHeader 2", "E X T R A N J E R O", New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("debeus"), New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("haberus")})})
        GridStackedHeaderRowDescriptor2.Name = "Row 1"
        Me.dgvCierre.TableDescriptor.StackedHeaderRows.Add(GridStackedHeaderRowDescriptor2)
        GridSummaryRowDescriptor2.Name = "Row 1"
        GridSummaryColumnDescriptor3.Appearance.AnySummaryCell.Font.Bold = True
        GridSummaryColumnDescriptor3.Appearance.AnySummaryCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center
        GridSummaryColumnDescriptor3.Appearance.AnySummaryCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        GridSummaryColumnDescriptor3.DataMember = "importeTotal"
        GridSummaryColumnDescriptor3.Format = "{Sum:S/###,###,##0.00}"
        GridSummaryColumnDescriptor3.Name = "TSoles"
        GridSummaryColumnDescriptor3.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        GridSummaryColumnDescriptor4.Appearance.AnySummaryCell.Font.Bold = True
        GridSummaryColumnDescriptor4.Appearance.AnySummaryCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        GridSummaryColumnDescriptor4.DataMember = "importeUS"
        GridSummaryColumnDescriptor4.Format = "{Sum:$###,###,##0.00}"
        GridSummaryColumnDescriptor4.Name = "TUsd"
        GridSummaryColumnDescriptor4.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        GridSummaryRowDescriptor2.SummaryColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor() {GridSummaryColumnDescriptor3, GridSummaryColumnDescriptor4})
        GridSummaryRowDescriptor2.Title = "Totales"
        Me.dgvCierre.TableDescriptor.SummaryRows.Add(GridSummaryRowDescriptor2)
        Me.dgvCierre.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.dgvCierre.TableDescriptor.TableOptions.RecordRowHeight = 20
        Me.dgvCierre.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("cuenta"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("descripcion"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("debe"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("haber"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("debeus"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("haberus")})
        Me.dgvCierre.Text = "GridGroupingControl2"
        Me.dgvCierre.VersionInfo = "12.4400.0.24"
        '
        'frmCierreContabilidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(158, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.CaptionBarHeight = 50
        Me.CaptionButtonColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(878, 379)
        Me.Controls.Add(Me.dgvCierre)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PanelError)
        Me.Name = "frmCierreContabilidad"
        Me.ShowIcon = False
        Me.Text = ""
        Me.PanelError.ResumeLayout(False)
        Me.PanelError.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.txtfecha.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtfecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCierre, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelError As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnCard As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents txtfecha As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvCierre As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
End Class

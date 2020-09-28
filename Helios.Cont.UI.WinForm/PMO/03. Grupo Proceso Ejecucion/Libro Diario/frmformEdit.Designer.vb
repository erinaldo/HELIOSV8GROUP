<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmformEdit
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
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor6 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor7 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor8 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridSummaryColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmformEdit))
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.dgvCompra = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.txtGlosa = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFechaComprobante = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.btnConfiguracion = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTipoCambio = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.lblIdDocumento = New System.Windows.Forms.Label()
        Me.PanelError = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.dgvCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGlosa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaComprobante.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoCambio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelError.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvCompra
        '
        Me.dgvCompra.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer)))
        Me.dgvCompra.Appearance.AlternateRecordFieldCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.dgvCompra.BackColor = System.Drawing.SystemColors.Window
        Me.dgvCompra.ChildGroupOptions.ShowCaption = True
        Me.dgvCompra.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvCompra.FreezeCaption = False
        Me.dgvCompra.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgvCompra.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2007Silver
        Me.dgvCompra.Location = New System.Drawing.Point(0, 127)
        Me.dgvCompra.Name = "dgvCompra"
        Me.dgvCompra.Size = New System.Drawing.Size(619, 235)
        Me.dgvCompra.TabIndex = 450
        Me.dgvCompra.TableDescriptor.AllowNew = False
        Me.dgvCompra.TableDescriptor.Appearance.AnyCell.Font.Facename = "Segoe UI"
        Me.dgvCompra.TableDescriptor.Appearance.AnyCell.TextColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.dgvCompra.TableDescriptor.Appearance.AnyGroupCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCompra.TableDescriptor.Appearance.AnyGroupCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCompra.TableDescriptor.Appearance.AnyGroupCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer)))
        Me.dgvCompra.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Bottom = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCompra.TableDescriptor.Appearance.AnyRecordFieldCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCompra.TableDescriptor.Appearance.AnySummaryCell.Borders.Right = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCompra.TableDescriptor.Appearance.AnySummaryCell.Borders.Top = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)), Syncfusion.Windows.Forms.Grid.GridBorderWeight.ExtraThin)
        Me.dgvCompra.TableDescriptor.Appearance.AnySummaryCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer)))
        Me.dgvCompra.TableDescriptor.Appearance.ColumnHeaderCell.Font.Bold = True
        Me.dgvCompra.TableDescriptor.Appearance.ColumnHeaderCell.Font.Italic = False
        Me.dgvCompra.TableDescriptor.Appearance.ColumnHeaderCell.Font.Size = 8.0!
        Me.dgvCompra.TableDescriptor.Appearance.GroupCaptionCell.CellType = """ColumnHeader"""
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.MappingName = "id"
        GridColumnDescriptor1.ReadOnly = True
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor2.AllowSort = False
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.HeaderText = "Descripción"
        GridColumnDescriptor2.MappingName = "Modulo"
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor2.Width = 190
        GridColumnDescriptor3.AllowSort = False
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.MappingName = "cuenta"
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor3.Width = 75
        GridColumnDescriptor4.AllowSort = False
        GridColumnDescriptor4.Appearance.AnyRecordFieldCell.CellType = "ComboBox"
        GridColumnDescriptor4.Appearance.AnyRecordFieldCell.DropDownStyle = Syncfusion.Windows.Forms.Grid.GridDropDownStyle.AutoComplete
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.HeaderText = "Asiento"
        GridColumnDescriptor4.MappingName = "tipoAsiento"
        GridColumnDescriptor4.SerializedImageArray = ""
        GridColumnDescriptor4.Width = 70
        GridColumnDescriptor5.AllowSort = False
        GridColumnDescriptor5.Appearance.AnyRecordFieldCell.CellType = "Currency"
        GridColumnDescriptor5.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
        GridColumnDescriptor5.HeaderImage = Nothing
        GridColumnDescriptor5.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor5.HeaderText = "Debe"
        GridColumnDescriptor5.MappingName = "importeMN"
        GridColumnDescriptor5.SerializedImageArray = ""
        GridColumnDescriptor5.Width = 90
        GridColumnDescriptor6.AllowSort = False
        GridColumnDescriptor6.Appearance.AnyRecordFieldCell.CellType = "Currency"
        GridColumnDescriptor6.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
        GridColumnDescriptor6.HeaderImage = Nothing
        GridColumnDescriptor6.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor6.HeaderText = "Haber"
        GridColumnDescriptor6.MappingName = "HaberMN"
        GridColumnDescriptor6.Name = "HaberMN"
        GridColumnDescriptor6.SerializedImageArray = ""
        GridColumnDescriptor6.Width = 95
        GridColumnDescriptor7.AllowSort = False
        GridColumnDescriptor7.Appearance.AnyRecordFieldCell.CellType = "Currency"
        GridColumnDescriptor7.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
        GridColumnDescriptor7.HeaderImage = Nothing
        GridColumnDescriptor7.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor7.HeaderText = "Debe"
        GridColumnDescriptor7.MappingName = "importeME"
        GridColumnDescriptor7.ReadOnly = True
        GridColumnDescriptor7.SerializedImageArray = ""
        GridColumnDescriptor7.Width = 70
        GridColumnDescriptor8.AllowSort = False
        GridColumnDescriptor8.Appearance.AnyRecordFieldCell.CellType = "Currency"
        GridColumnDescriptor8.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
        GridColumnDescriptor8.HeaderImage = Nothing
        GridColumnDescriptor8.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor8.HeaderText = "Haber"
        GridColumnDescriptor8.MappingName = "HaberME"
        GridColumnDescriptor8.ReadOnly = True
        GridColumnDescriptor8.SerializedImageArray = ""
        GridColumnDescriptor8.Width = 70
        Me.dgvCompra.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7, GridColumnDescriptor8})
        Me.dgvCompra.TableDescriptor.PrimaryKeyColumns.AddRange(New Syncfusion.Grouping.SortColumnDescriptor() {New Syncfusion.Grouping.SortColumnDescriptor("idModulo", System.ComponentModel.ListSortDirection.Ascending)})
        GridSummaryColumnDescriptor1.DataMember = "importeMN"
        GridSummaryColumnDescriptor1.Format = "{Sum:S/###,###,##0.00}"
        GridSummaryColumnDescriptor1.Name = "TDebeMN"
        GridSummaryColumnDescriptor1.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        Me.dgvCompra.TableDescriptor.SummaryRows.Add(New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor("Row 1", "Totales", New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor() {GridSummaryColumnDescriptor1, New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor("TDebeME", Syncfusion.Grouping.SummaryType.DoubleAggregate, "importeME", "{Sum:$###,###,##0.00}"), New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor("THaberMN", Syncfusion.Grouping.SummaryType.DoubleAggregate, "HaberMN", "{Sum:S/###,###,##0.00}"), New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor("THaberME", Syncfusion.Grouping.SummaryType.DoubleAggregate, "HaberME", "{Sum:$###,###,##0.00}")}))
        Me.dgvCompra.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.dgvCompra.TableDescriptor.TableOptions.RecordRowHeight = 20
        Me.dgvCompra.TableDescriptor.TopLevelGroupOptions.ShowCaption = False
        Me.dgvCompra.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("Modulo"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("cuenta"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("importeMN"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("HaberMN"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("importeME"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("HaberME")})
        Me.dgvCompra.Text = "GridGroupingControl2"
        Me.dgvCompra.VersionInfo = "12.4400.0.24"
        '
        'txtGlosa
        '
        Me.txtGlosa.BackColor = System.Drawing.Color.White
        Me.txtGlosa.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtGlosa.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtGlosa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGlosa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtGlosa.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtGlosa.Location = New System.Drawing.Point(15, 76)
        Me.txtGlosa.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtGlosa.Multiline = True
        Me.txtGlosa.Name = "txtGlosa"
        Me.txtGlosa.Size = New System.Drawing.Size(454, 42)
        Me.txtGlosa.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtGlosa.TabIndex = 452
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(15, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 451
        Me.Label1.Text = "Glosa:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(15, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 453
        Me.Label2.Text = "Fecha:"
        '
        'txtFechaComprobante
        '
        Me.txtFechaComprobante.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtFechaComprobante.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaComprobante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtFechaComprobante.Calendar.AllowMultipleSelection = False
        Me.txtFechaComprobante.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFechaComprobante.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaComprobante.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFechaComprobante.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaComprobante.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFechaComprobante.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtFechaComprobante.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFechaComprobante.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaComprobante.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFechaComprobante.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtFechaComprobante.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtFechaComprobante.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtFechaComprobante.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtFechaComprobante.Calendar.Iso8601CalenderFormat = False
        Me.txtFechaComprobante.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaComprobante.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaComprobante.Calendar.Name = "monthCalendar"
        Me.txtFechaComprobante.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtFechaComprobante.Calendar.SelectedDates = New Date(-1) {}
        Me.txtFechaComprobante.Calendar.Size = New System.Drawing.Size(177, 174)
        Me.txtFechaComprobante.Calendar.SizeToFit = True
        Me.txtFechaComprobante.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaComprobante.Calendar.TabIndex = 0
        Me.txtFechaComprobante.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtFechaComprobante.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaComprobante.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaComprobante.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaComprobante.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaComprobante.Calendar.NoneButton.IsBackStageButton = False
        Me.txtFechaComprobante.Calendar.NoneButton.Location = New System.Drawing.Point(105, 0)
        Me.txtFechaComprobante.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtFechaComprobante.Calendar.NoneButton.Text = "None"
        Me.txtFechaComprobante.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtFechaComprobante.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFechaComprobante.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaComprobante.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFechaComprobante.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtFechaComprobante.Calendar.TodayButton.IsBackStageButton = False
        Me.txtFechaComprobante.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtFechaComprobante.Calendar.TodayButton.Size = New System.Drawing.Size(105, 20)
        Me.txtFechaComprobante.Calendar.TodayButton.Text = "Today"
        Me.txtFechaComprobante.Calendar.TodayButton.UseVisualStyle = True
        Me.txtFechaComprobante.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaComprobante.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtFechaComprobante.CustomFormat = "dd/MM/yyyy hh:mm:ss tt"
        Me.txtFechaComprobante.DropDownImage = Nothing
        Me.txtFechaComprobante.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaComprobante.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaComprobante.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtFechaComprobante.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFechaComprobante.Location = New System.Drawing.Point(15, 32)
        Me.txtFechaComprobante.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaComprobante.MinValue = New Date(CType(0, Long))
        Me.txtFechaComprobante.Name = "txtFechaComprobante"
        Me.txtFechaComprobante.ShowCheckBox = False
        Me.txtFechaComprobante.Size = New System.Drawing.Size(181, 20)
        Me.txtFechaComprobante.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaComprobante.TabIndex = 454
        Me.txtFechaComprobante.Value = New Date(2015, 4, 14, 15, 59, 3, 447)
        '
        'btnConfiguracion
        '
        Me.btnConfiguracion.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btnConfiguracion.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnConfiguracion.BeforeTouchSize = New System.Drawing.Size(58, 42)
        Me.btnConfiguracion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConfiguracion.ForeColor = System.Drawing.Color.White
        Me.btnConfiguracion.IsBackStageButton = False
        Me.btnConfiguracion.Location = New System.Drawing.Point(549, 76)
        Me.btnConfiguracion.Name = "btnConfiguracion"
        Me.btnConfiguracion.Size = New System.Drawing.Size(58, 42)
        Me.btnConfiguracion.TabIndex = 455
        Me.btnConfiguracion.TabStop = False
        Me.btnConfiguracion.Text = "Grabar"
        Me.btnConfiguracion.UseVisualStyle = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(203, 36)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 13)
        Me.Label6.TabIndex = 456
        Me.Label6.Text = "Tipo Cambio:"
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.txtTipoCambio.BeforeTouchSize = New System.Drawing.Size(51, 20)
        Me.txtTipoCambio.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTipoCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTipoCambio.DecimalPlaces = 2
        Me.txtTipoCambio.Location = New System.Drawing.Point(277, 32)
        Me.txtTipoCambio.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.Size = New System.Drawing.Size(51, 20)
        Me.txtTipoCambio.TabIndex = 457
        Me.txtTipoCambio.ThousandsSeparator = True
        Me.txtTipoCambio.Value = New Decimal(New Integer() {3, 0, 0, 0})
        Me.txtTipoCambio.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'lblIdDocumento
        '
        Me.lblIdDocumento.AutoSize = True
        Me.lblIdDocumento.Location = New System.Drawing.Point(569, 15)
        Me.lblIdDocumento.Name = "lblIdDocumento"
        Me.lblIdDocumento.Size = New System.Drawing.Size(38, 13)
        Me.lblIdDocumento.TabIndex = 458
        Me.lblIdDocumento.Text = "Label3"
        Me.lblIdDocumento.Visible = False
        '
        'PanelError
        '
        Me.PanelError.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PanelError.Controls.Add(Me.PictureBox1)
        Me.PanelError.Controls.Add(Me.lblEstado)
        Me.PanelError.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelError.Location = New System.Drawing.Point(0, 0)
        Me.PanelError.Name = "PanelError"
        Me.PanelError.Size = New System.Drawing.Size(619, 22)
        Me.PanelError.TabIndex = 459
        Me.PanelError.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(600, 0)
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
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'frmformEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderThickness = 0
        Me.CaptionBarColor = System.Drawing.Color.White
        Me.CaptionForeColor = System.Drawing.Color.White
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Name = "CaptionImage1"
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.White
        CaptionLabel1.Location = New System.Drawing.Point(59, 4)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Text = "Editar asiento"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.CaptionVerticalAlignment = Syncfusion.Windows.Forms.VerticalAlignment.Bottom
        Me.ClientSize = New System.Drawing.Size(619, 362)
        Me.Controls.Add(Me.PanelError)
        Me.Controls.Add(Me.lblIdDocumento)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtTipoCambio)
        Me.Controls.Add(Me.btnConfiguracion)
        Me.Controls.Add(Me.txtFechaComprobante)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtGlosa)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvCompra)
        Me.Name = "frmformEdit"
        Me.ShowIcon = False
        Me.ShowMaximizeBox = False
        Me.ShowMinimizeBox = False
        Me.Text = ""
        CType(Me.dgvCompra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGlosa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaComprobante.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaComprobante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoCambio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelError.ResumeLayout(False)
        Me.PanelError.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvCompra As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents txtGlosa As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFechaComprobante As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents btnConfiguracion As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTipoCambio As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents lblIdDocumento As System.Windows.Forms.Label
    Friend WithEvents PanelError As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAperturaCajaXUsuario
    Inherits Helios.Cont.Presentation.WinForm.frmMaster

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAperturaCajaXUsuario))
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor6 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor7 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor8 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridSummaryRowDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor()
        Dim GridSummaryColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor()
        Dim GridSummaryColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor()
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtNombreCaja = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtDni = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgvAperturaCajaXUsuario = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.btOperacion = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.txtFecHaApertura = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.PanelError = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtNombreCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDni, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvAperturaCajaXUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.txtFecHaApertura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecHaApertura.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelError.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtNombreCaja)
        Me.GroupBox1.Controls.Add(Me.txtDni)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(3, 78)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(530, 79)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "RESPONSABLE"
        '
        'txtNombreCaja
        '
        Me.txtNombreCaja.BackColor = System.Drawing.Color.White
        Me.txtNombreCaja.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtNombreCaja.BorderColor = System.Drawing.Color.Gray
        Me.txtNombreCaja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNombreCaja.CornerRadius = 5
        Me.txtNombreCaja.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNombreCaja.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtNombreCaja.Location = New System.Drawing.Point(20, 45)
        Me.txtNombreCaja.Metrocolor = System.Drawing.Color.Gray
        Me.txtNombreCaja.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtNombreCaja.Name = "txtNombreCaja"
        Me.txtNombreCaja.NearImage = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources._003
        Me.txtNombreCaja.ReadOnly = True
        Me.txtNombreCaja.Size = New System.Drawing.Size(286, 20)
        Me.txtNombreCaja.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtNombreCaja.TabIndex = 518
        '
        'txtDni
        '
        Me.txtDni.BackColor = System.Drawing.Color.White
        Me.txtDni.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtDni.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtDni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDni.CornerRadius = 5
        Me.txtDni.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDni.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtDni.Location = New System.Drawing.Point(319, 45)
        Me.txtDni.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtDni.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtDni.Name = "txtDni"
        Me.txtDni.NearImage = CType(resources.GetObject("txtDni.NearImage"), System.Drawing.Image)
        Me.txtDni.ReadOnly = True
        Me.txtDni.Size = New System.Drawing.Size(158, 20)
        Me.txtDni.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtDni.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(318, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 14)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "IDENTIFICACION"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(17, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 14)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "USUARIO CAJERO"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dgvAperturaCajaXUsuario)
        Me.Panel1.Location = New System.Drawing.Point(3, 163)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(530, 305)
        Me.Panel1.TabIndex = 4
        '
        'dgvAperturaCajaXUsuario
        '
        Me.dgvAperturaCajaXUsuario.BackColor = System.Drawing.Color.White
        Me.dgvAperturaCajaXUsuario.ColorStyles = Syncfusion.Windows.Forms.ColorStyles.Office2010Silver
        Me.dgvAperturaCajaXUsuario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvAperturaCajaXUsuario.Enabled = False
        Me.dgvAperturaCajaXUsuario.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvAperturaCajaXUsuario.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgvAperturaCajaXUsuario.FreezeCaption = False
        Me.dgvAperturaCajaXUsuario.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Office2010
        Me.dgvAperturaCajaXUsuario.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.dgvAperturaCajaXUsuario.Location = New System.Drawing.Point(0, 0)
        Me.dgvAperturaCajaXUsuario.Name = "dgvAperturaCajaXUsuario"
        Me.dgvAperturaCajaXUsuario.Office2010ScrollBarsColorScheme = Syncfusion.Windows.Forms.Office2010ColorScheme.Silver
        Me.dgvAperturaCajaXUsuario.Size = New System.Drawing.Size(530, 305)
        Me.dgvAperturaCajaXUsuario.TabIndex = 16
        Me.dgvAperturaCajaXUsuario.TableDescriptor.AllowNew = False
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.HeaderText = "ID"
        GridColumnDescriptor1.MappingName = "codigo"
        GridColumnDescriptor1.ReadOnly = True
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor1.Width = 50
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.MappingName = "IdEntidad"
        GridColumnDescriptor2.ReadOnly = True
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor2.Width = 50
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.MappingName = "entidad"
        GridColumnDescriptor3.ReadOnly = True
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor3.Width = 250
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.MappingName = "moneda"
        GridColumnDescriptor4.ReadOnly = True
        GridColumnDescriptor4.SerializedImageArray = ""
        GridColumnDescriptor4.Width = 80
        GridColumnDescriptor5.HeaderImage = Nothing
        GridColumnDescriptor5.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor5.HeaderText = "T/c. Ref."
        GridColumnDescriptor5.MappingName = "tc"
        GridColumnDescriptor5.ReadOnly = True
        GridColumnDescriptor5.SerializedImageArray = ""
        GridColumnDescriptor5.Width = 0
        GridColumnDescriptor6.Appearance.AnyRecordFieldCell.CellType = "Currency"
        GridColumnDescriptor6.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
        GridColumnDescriptor6.Appearance.AnyRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Info)
        GridColumnDescriptor6.HeaderImage = Nothing
        GridColumnDescriptor6.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor6.HeaderText = "MN."
        GridColumnDescriptor6.MappingName = "importeMN"
        GridColumnDescriptor6.SerializedImageArray = ""
        GridColumnDescriptor6.Width = 100
        GridColumnDescriptor7.Appearance.AnyRecordFieldCell.CellType = "Currency"
        GridColumnDescriptor7.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
        GridColumnDescriptor7.HeaderImage = Nothing
        GridColumnDescriptor7.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor7.HeaderText = "ME."
        GridColumnDescriptor7.MappingName = "importeME"
        GridColumnDescriptor7.SerializedImageArray = ""
        GridColumnDescriptor7.Width = 100
        GridColumnDescriptor8.HeaderImage = Nothing
        GridColumnDescriptor8.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor8.MappingName = "montoMax"
        GridColumnDescriptor8.ReadOnly = True
        GridColumnDescriptor8.SerializedImageArray = ""
        GridColumnDescriptor8.Width = 80
        Me.dgvAperturaCajaXUsuario.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7, GridColumnDescriptor8})
        GridSummaryRowDescriptor1.Name = "Row 2"
        GridSummaryColumnDescriptor1.Appearance.AnySummaryCell.CellType = "Currency"
        GridSummaryColumnDescriptor1.Appearance.AnySummaryCell.CurrencyEdit.CurrencySymbol = ""
        GridSummaryColumnDescriptor1.DataMember = "importeMN"
        GridSummaryColumnDescriptor1.Format = "{Sum}"
        GridSummaryColumnDescriptor1.Name = "importeMN"
        GridSummaryColumnDescriptor1.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        GridSummaryColumnDescriptor2.Appearance.AnySummaryCell.CellType = "Currency"
        GridSummaryColumnDescriptor2.Appearance.AnySummaryCell.CurrencyEdit.CurrencySymbol = ""
        GridSummaryColumnDescriptor2.DataMember = "importeME"
        GridSummaryColumnDescriptor2.Format = "{Sum}"
        GridSummaryColumnDescriptor2.Name = "importeME"
        GridSummaryColumnDescriptor2.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        GridSummaryRowDescriptor1.SummaryColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor() {GridSummaryColumnDescriptor1, GridSummaryColumnDescriptor2})
        GridSummaryRowDescriptor1.Title = "TOTAL"
        Me.dgvAperturaCajaXUsuario.TableDescriptor.SummaryRows.Add(GridSummaryRowDescriptor1)
        Me.dgvAperturaCajaXUsuario.TableDescriptor.TableOptions.CaptionRowHeight = 22
        Me.dgvAperturaCajaXUsuario.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.dgvAperturaCajaXUsuario.TableDescriptor.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.None
        Me.dgvAperturaCajaXUsuario.TableDescriptor.TableOptions.ListBoxSelectionMode = System.Windows.Forms.SelectionMode.One
        Me.dgvAperturaCajaXUsuario.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.dgvAperturaCajaXUsuario.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("entidad"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("moneda"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("tc"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("importeMN"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("importeME")})
        Me.dgvAperturaCajaXUsuario.Tag = "1"
        Me.dgvAperturaCajaXUsuario.Text = "gridGroupingControl1"
        Me.dgvAperturaCajaXUsuario.VersionInfo = "12.1400.0.43"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.ButtonAdv1)
        Me.Panel2.Controls.Add(Me.btOperacion)
        Me.Panel2.Location = New System.Drawing.Point(3, 474)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(530, 43)
        Me.Panel2.TabIndex = 5
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.White
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(100, 32)
        Me.ButtonAdv1.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.ButtonAdv1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonAdv1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.Black
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(418, 5)
        Me.ButtonAdv1.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(100, 32)
        Me.ButtonAdv1.TabIndex = 13
        Me.ButtonAdv1.Text = "&Cancel"
        Me.ButtonAdv1.UseVisualStyle = True
        '
        'btOperacion
        '
        Me.btOperacion.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btOperacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btOperacion.BeforeTouchSize = New System.Drawing.Size(110, 32)
        Me.btOperacion.Font = New System.Drawing.Font("Segoe UI Semibold", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btOperacion.ForeColor = System.Drawing.Color.White
        Me.btOperacion.IsBackStageButton = False
        Me.btOperacion.Location = New System.Drawing.Point(294, 5)
        Me.btOperacion.MetroColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btOperacion.Name = "btOperacion"
        Me.btOperacion.Size = New System.Drawing.Size(110, 32)
        Me.btOperacion.TabIndex = 12
        Me.btOperacion.Text = "&Grabar"
        Me.btOperacion.UseVisualStyle = True
        '
        'txtFecHaApertura
        '
        Me.txtFecHaApertura.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtFecHaApertura.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtFecHaApertura.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFecHaApertura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtFecHaApertura.Calendar.AllowMultipleSelection = False
        Me.txtFecHaApertura.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFecHaApertura.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFecHaApertura.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFecHaApertura.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecHaApertura.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFecHaApertura.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.txtFecHaApertura.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFecHaApertura.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecHaApertura.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFecHaApertura.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtFecHaApertura.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtFecHaApertura.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtFecHaApertura.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtFecHaApertura.Calendar.Iso8601CalenderFormat = False
        Me.txtFecHaApertura.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtFecHaApertura.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecHaApertura.Calendar.Name = "monthCalendar"
        Me.txtFecHaApertura.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtFecHaApertura.Calendar.SelectedDates = New Date(-1) {}
        Me.txtFecHaApertura.Calendar.Size = New System.Drawing.Size(188, 174)
        Me.txtFecHaApertura.Calendar.SizeToFit = True
        Me.txtFecHaApertura.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFecHaApertura.Calendar.TabIndex = 0
        Me.txtFecHaApertura.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtFecHaApertura.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFecHaApertura.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecHaApertura.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFecHaApertura.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtFecHaApertura.Calendar.NoneButton.IsBackStageButton = False
        Me.txtFecHaApertura.Calendar.NoneButton.Location = New System.Drawing.Point(116, 0)
        Me.txtFecHaApertura.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtFecHaApertura.Calendar.NoneButton.Text = "None"
        Me.txtFecHaApertura.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtFecHaApertura.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFecHaApertura.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecHaApertura.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFecHaApertura.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtFecHaApertura.Calendar.TodayButton.IsBackStageButton = False
        Me.txtFecHaApertura.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtFecHaApertura.Calendar.TodayButton.Size = New System.Drawing.Size(116, 20)
        Me.txtFecHaApertura.Calendar.TodayButton.Text = "Today"
        Me.txtFecHaApertura.Calendar.TodayButton.UseVisualStyle = True
        Me.txtFecHaApertura.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecHaApertura.CalendarForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFecHaApertura.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtFecHaApertura.CustomFormat = "dd/MM/yyyy HH:mm tt"
        Me.txtFecHaApertura.DropDownImage = Nothing
        Me.txtFecHaApertura.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecHaApertura.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecHaApertura.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtFecHaApertura.ForeColor = System.Drawing.Color.White
        Me.txtFecHaApertura.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFecHaApertura.Location = New System.Drawing.Point(20, 19)
        Me.txtFecHaApertura.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecHaApertura.MinValue = New Date(CType(0, Long))
        Me.txtFecHaApertura.Name = "txtFecHaApertura"
        Me.txtFecHaApertura.ReadOnly = True
        Me.txtFecHaApertura.ShowCheckBox = False
        Me.txtFecHaApertura.ShowDropButton = False
        Me.txtFecHaApertura.Size = New System.Drawing.Size(192, 20)
        Me.txtFecHaApertura.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFecHaApertura.TabIndex = 7
        Me.txtFecHaApertura.Value = New Date(2016, 1, 25, 9, 58, 0, 0)
        '
        'PanelError
        '
        Me.PanelError.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.PanelError.Controls.Add(Me.PictureBox2)
        Me.PanelError.Controls.Add(Me.lblEstado)
        Me.PanelError.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelError.Location = New System.Drawing.Point(0, 0)
        Me.PanelError.Name = "PanelError"
        Me.PanelError.Size = New System.Drawing.Size(535, 22)
        Me.PanelError.TabIndex = 511
        Me.PanelError.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(516, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(19, 22)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 288
        Me.PictureBox2.TabStop = False
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtFecHaApertura)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 28)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(530, 44)
        Me.GroupBox2.TabIndex = 512
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "FECHA DE APERTURA"
        '
        'frmAperturaCajaXUsuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CaptionBarColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CaptionBarHeight = 70
        CaptionImage1.Location = New System.Drawing.Point(30, 10)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(40, 40)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI Semibold", 13.0!)
        CaptionLabel1.ForeColor = System.Drawing.Color.White
        CaptionLabel1.Location = New System.Drawing.Point(80, 25)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(300, 24)
        CaptionLabel1.Text = "APERTURA DE CAJA"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(535, 517)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.PanelError)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.Name = "frmAperturaCajaXUsuario"
        Me.ShowIcon = False
        Me.Text = ""
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtNombreCaja, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDni, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvAperturaCajaXUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.txtFecHaApertura.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecHaApertura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelError.ResumeLayout(False)
        Me.PanelError.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDni As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Private WithEvents dgvAperturaCajaXUsuario As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtFecHaApertura As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents btOperacion As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents txtNombreCaja As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents PanelError As System.Windows.Forms.Panel
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportarCuentasContables
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImportarCuentasContables))
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor6 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor7 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.GradientPanel2 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.lblruta = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnAdCuenta = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.txtfecha = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GradientPanel3 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv15 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.dgvCuentas = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dgvAddcuentas = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.txtfecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtfecha.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel3.SuspendLayout()
        CType(Me.dgvCuentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvAddcuentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BorderColor = System.Drawing.Color.Gainsboro
        Me.GradientPanel1.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.GradientPanel2)
        Me.GradientPanel1.Controls.Add(Me.lblruta)
        Me.GradientPanel1.Controls.Add(Me.Label1)
        Me.GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(1040, 43)
        Me.GradientPanel1.TabIndex = 2
        '
        'GradientPanel2
        '
        Me.GradientPanel2.BorderColor = System.Drawing.Color.Gainsboro
        Me.GradientPanel2.BorderSides = System.Windows.Forms.Border3DSide.Top
        Me.GradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GradientPanel2.Location = New System.Drawing.Point(0, 0)
        Me.GradientPanel2.Name = "GradientPanel2"
        Me.GradientPanel2.Size = New System.Drawing.Size(1038, 10)
        Me.GradientPanel2.TabIndex = 2
        '
        'lblruta
        '
        Me.lblruta.AutoSize = True
        Me.lblruta.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblruta.ForeColor = System.Drawing.Color.DimGray
        Me.lblruta.Location = New System.Drawing.Point(86, 17)
        Me.lblruta.Name = "lblruta"
        Me.lblruta.Size = New System.Drawing.Size(54, 12)
        Me.lblruta.TabIndex = 1
        Me.lblruta.Text = "ARCHIVO:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(26, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ARCHIVO:"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnAdCuenta)
        Me.Panel1.Controls.Add(Me.txtfecha)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 43)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1040, 50)
        Me.Panel1.TabIndex = 3
        '
        'btnAdCuenta
        '
        Me.btnAdCuenta.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btnAdCuenta.BackColor = System.Drawing.Color.RoyalBlue
        Me.btnAdCuenta.BeforeTouchSize = New System.Drawing.Size(89, 34)
        Me.btnAdCuenta.ForeColor = System.Drawing.Color.White
        Me.btnAdCuenta.IsBackStageButton = False
        Me.btnAdCuenta.Location = New System.Drawing.Point(939, 9)
        Me.btnAdCuenta.MetroColor = System.Drawing.Color.RoyalBlue
        Me.btnAdCuenta.Name = "btnAdCuenta"
        Me.btnAdCuenta.Size = New System.Drawing.Size(89, 34)
        Me.btnAdCuenta.TabIndex = 8
        Me.btnAdCuenta.Text = "Agregar Cuentas"
        Me.btnAdCuenta.UseVisualStyle = True
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
        Me.txtfecha.Calendar.Size = New System.Drawing.Size(228, 174)
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
        Me.txtfecha.Calendar.NoneButton.Location = New System.Drawing.Point(156, 0)
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
        Me.txtfecha.Calendar.TodayButton.Size = New System.Drawing.Size(156, 20)
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
        Me.txtfecha.Location = New System.Drawing.Point(310, 14)
        Me.txtfecha.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtfecha.MinValue = New Date(CType(0, Long))
        Me.txtfecha.Name = "txtfecha"
        Me.txtfecha.ShowCheckBox = False
        Me.txtfecha.Size = New System.Drawing.Size(119, 20)
        Me.txtfecha.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtfecha.TabIndex = 7
        Me.txtfecha.Value = New Date(2016, 5, 18, 11, 48, 28, 539)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(186, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(118, 12)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "PERIODO DE INICIO   - "
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Image = CType(resources.GetObject("Label3.Image"), System.Drawing.Image)
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label3.Location = New System.Drawing.Point(25, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(131, 31)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "VISTA PREVIA"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GradientPanel3
        '
        Me.GradientPanel3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GradientPanel3.BorderColor = System.Drawing.Color.Gainsboro
        Me.GradientPanel3.BorderSides = System.Windows.Forms.Border3DSide.Top
        Me.GradientPanel3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GradientPanel3.Controls.Add(Me.ButtonAdv1)
        Me.GradientPanel3.Controls.Add(Me.ButtonAdv15)
        Me.GradientPanel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GradientPanel3.Location = New System.Drawing.Point(0, 461)
        Me.GradientPanel3.Name = "GradientPanel3"
        Me.GradientPanel3.Size = New System.Drawing.Size(1040, 56)
        Me.GradientPanel3.TabIndex = 4
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv1.BackColor = System.Drawing.Color.Gainsboro
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(89, 32)
        Me.ButtonAdv1.BorderStyleAdv = Syncfusion.Windows.Forms.ButtonAdvBorderStyle.Flat
        Me.ButtonAdv1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv1.ForeColor = System.Drawing.Color.Black
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(939, 12)
        Me.ButtonAdv1.MetroColor = System.Drawing.Color.Green
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(89, 32)
        Me.ButtonAdv1.TabIndex = 425
        Me.ButtonAdv1.Text = "Cancel"
        Me.ButtonAdv1.UseVisualStyle = True
        Me.ButtonAdv1.UseVisualStyleBackColor = False
        '
        'ButtonAdv15
        '
        Me.ButtonAdv15.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.ButtonAdv15.BackColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.ButtonAdv15.BeforeTouchSize = New System.Drawing.Size(87, 32)
        Me.ButtonAdv15.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonAdv15.ForeColor = System.Drawing.Color.White
        Me.ButtonAdv15.IsBackStageButton = False
        Me.ButtonAdv15.Location = New System.Drawing.Point(843, 12)
        Me.ButtonAdv15.MetroColor = System.Drawing.Color.Green
        Me.ButtonAdv15.Name = "ButtonAdv15"
        Me.ButtonAdv15.Size = New System.Drawing.Size(87, 32)
        Me.ButtonAdv15.TabIndex = 424
        Me.ButtonAdv15.Text = "Grabar"
        Me.ButtonAdv15.UseVisualStyle = True
        Me.ButtonAdv15.UseVisualStyleBackColor = False
        '
        'dgvCuentas
        '
        Me.dgvCuentas.BackColor = System.Drawing.SystemColors.Window
        Me.dgvCuentas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCuentas.FreezeCaption = False
        Me.dgvCuentas.Location = New System.Drawing.Point(0, 93)
        Me.dgvCuentas.Name = "dgvCuentas"
        Me.dgvCuentas.Size = New System.Drawing.Size(658, 368)
        Me.dgvCuentas.TabIndex = 5
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.HeaderText = "Cuenta"
        GridColumnDescriptor1.MappingName = "cuenta"
        GridColumnDescriptor1.ReadOnly = True
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor1.Width = 75
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.HeaderText = "Descripción"
        GridColumnDescriptor2.MappingName = "descripcion"
        GridColumnDescriptor2.ReadOnly = True
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor2.Width = 350
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.HeaderText = "Tipo"
        GridColumnDescriptor3.MappingName = "tipoAsiento"
        GridColumnDescriptor3.ReadOnly = True
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor3.Width = 40
        GridColumnDescriptor4.Appearance.AnyRecordFieldCell.CellType = "Currency"
        GridColumnDescriptor4.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.MappingName = "debe"
        GridColumnDescriptor4.ReadOnly = True
        GridColumnDescriptor4.SerializedImageArray = ""
        GridColumnDescriptor4.Width = 80
        GridColumnDescriptor5.Appearance.AnyRecordFieldCell.CellType = "Currency"
        GridColumnDescriptor5.Appearance.AnyRecordFieldCell.CurrencyEdit.CurrencySymbol = ""
        GridColumnDescriptor5.HeaderImage = Nothing
        GridColumnDescriptor5.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor5.MappingName = "haber"
        GridColumnDescriptor5.ReadOnly = True
        GridColumnDescriptor5.SerializedImageArray = ""
        GridColumnDescriptor5.Width = 80
        Me.dgvCuentas.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5})
        Me.dgvCuentas.TableDescriptor.SummaryRows.Add(New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowDescriptor("Row 1", New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor("debe", Syncfusion.Grouping.SummaryType.DoubleAggregate, "debe", "{Sum:###,###,##0.00}"), New Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryColumnDescriptor("haber", Syncfusion.Grouping.SummaryType.DoubleAggregate, "haber", "{Sum:###,###,##0.00}")}))
        Me.dgvCuentas.Text = "GridGroupingControl1"
        Me.dgvCuentas.VersionInfo = "12.4400.0.24"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.dgvAddcuentas)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(658, 93)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(382, 368)
        Me.Panel2.TabIndex = 6
        '
        'dgvAddcuentas
        '
        Me.dgvAddcuentas.BackColor = System.Drawing.SystemColors.Window
        Me.dgvAddcuentas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvAddcuentas.FreezeCaption = False
        Me.dgvAddcuentas.Location = New System.Drawing.Point(0, 0)
        Me.dgvAddcuentas.Name = "dgvAddcuentas"
        Me.dgvAddcuentas.Size = New System.Drawing.Size(382, 368)
        Me.dgvAddcuentas.TabIndex = 0
        GridColumnDescriptor6.HeaderImage = Nothing
        GridColumnDescriptor6.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor6.HeaderText = "Cuenta"
        GridColumnDescriptor6.MappingName = "cuenta"
        GridColumnDescriptor6.ReadOnly = True
        GridColumnDescriptor6.SerializedImageArray = ""
        GridColumnDescriptor6.Width = 100
        GridColumnDescriptor7.HeaderImage = Nothing
        GridColumnDescriptor7.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor7.HeaderText = "Descripción"
        GridColumnDescriptor7.MappingName = "nomCuenta"
        GridColumnDescriptor7.ReadOnly = True
        GridColumnDescriptor7.SerializedImageArray = ""
        GridColumnDescriptor7.Width = 255
        Me.dgvAddcuentas.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor6, GridColumnDescriptor7})
        Me.dgvAddcuentas.Text = "GridGroupingControl1"
        Me.dgvAddcuentas.VersionInfo = "12.4400.0.24"
        '
        'frmImportarCuentasContables
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.Color.FromArgb(CType(CType(92, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.CaptionBarColor = System.Drawing.Color.White
        Me.CaptionBarHeight = 50
        CaptionLabel1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.DimGray
        CaptionLabel1.Location = New System.Drawing.Point(30, 9)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(180, 24)
        CaptionLabel1.Text = "Importar Cuentas contables."
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(1040, 517)
        Me.Controls.Add(Me.dgvCuentas)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.GradientPanel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GradientPanel1)
        Me.Name = "frmImportarCuentasContables"
        Me.ShowIcon = False
        Me.Text = ""
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        CType(Me.GradientPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.txtfecha.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtfecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel3.ResumeLayout(False)
        CType(Me.dgvCuentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgvAddcuentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents GradientPanel2 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents lblruta As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GradientPanel3 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents ButtonAdv15 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents dgvCuentas As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtfecha As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents dgvAddcuentas As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents btnAdCuenta As Syncfusion.Windows.Forms.ButtonAdv
End Class

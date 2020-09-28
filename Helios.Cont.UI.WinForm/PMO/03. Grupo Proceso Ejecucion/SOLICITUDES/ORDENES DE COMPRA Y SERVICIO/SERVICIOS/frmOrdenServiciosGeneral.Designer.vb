<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrdenServiciosGeneral
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
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor4 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim ActiveStateCollection1 As Syncfusion.Windows.Forms.Tools.ActiveStateCollection = New Syncfusion.Windows.Forms.Tools.ActiveStateCollection()
        Dim InactiveStateCollection1 As Syncfusion.Windows.Forms.Tools.InactiveStateCollection = New Syncfusion.Windows.Forms.Tools.InactiveStateCollection()
        Dim ToggleButtonRenderer1 As Syncfusion.Windows.Forms.Tools.ToggleButtonRenderer = New Syncfusion.Windows.Forms.Tools.ToggleButtonRenderer()
        Dim SliderCollection1 As Syncfusion.Windows.Forms.Tools.SliderCollection = New Syncfusion.Windows.Forms.Tools.SliderCollection()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOrdenServiciosGeneral))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgvServicio = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.cboModalidad2 = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.cboCondPago = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.txtCajaOrigen = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.dtpFechaVencimiento = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtcto = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.panel15 = New System.Windows.Forms.Panel()
        Me.label35 = New System.Windows.Forms.Label()
        Me.gpVSBehavior = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtRuc = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtComprobante = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.nudImporteMe = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtProveedor = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.txtCuenta = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.nudImporteMN = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.nudPorcentajeTributo = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.txtFechaComprobante = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboObjetoContratacion = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.nudDetraccion = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.txtFondoGarantia = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.txtAdelanto = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.nudDetraccionME = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.txtFondoGarantiaME = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.txtAdelantoME = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.txtImporteContratacionME = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.txtImporteContratacion = New Syncfusion.Windows.Forms.Tools.NumericUpDownExt()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNombreEntregable = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.fechainicio = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.fechafin = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.tbDetraccion = New Syncfusion.Windows.Forms.Tools.ToggleButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtContra = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtPenalidades = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.dockingManager1 = New Syncfusion.Windows.Forms.Tools.DockingManager(Me.components)
        Me.QGlobalColorSchemeManager1 = New Qios.DevSuite.Components.QGlobalColorSchemeManager(Me.components)
        Me.DockingClientPanel1 = New Syncfusion.Windows.Forms.Tools.DockingClientPanel()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvServicio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.dtpFechaVencimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpFechaVencimiento.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel15.SuspendLayout()
        CType(Me.gpVSBehavior, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpVSBehavior.SuspendLayout()
        CType(Me.txtRuc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudImporteMe, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudImporteMN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPorcentajeTributo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaComprobante.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.nudDetraccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFondoGarantia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAdelanto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudDetraccionME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFondoGarantiaME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAdelantoME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtImporteContratacionME, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtImporteContratacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.fechainicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fechainicio.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fechafin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fechafin.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbDetraccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dockingManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DockingClientPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dgvServicio)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(446, 367)
        Me.Panel1.TabIndex = 450
        '
        'dgvServicio
        '
        Me.dgvServicio.BackColor = System.Drawing.SystemColors.Window
        Me.dgvServicio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvServicio.FreezeCaption = False
        Me.dgvServicio.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgvServicio.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.dgvServicio.Location = New System.Drawing.Point(325, 0)
        Me.dgvServicio.Name = "dgvServicio"
        Me.dgvServicio.Size = New System.Drawing.Size(121, 367)
        Me.dgvServicio.TabIndex = 425
        Me.dgvServicio.TableDescriptor.AllowNew = False
        GridColumnDescriptor1.HeaderImage = Nothing
        GridColumnDescriptor1.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor1.MappingName = "idDocumento"
        GridColumnDescriptor1.Name = "idDocumento"
        GridColumnDescriptor1.SerializedImageArray = ""
        GridColumnDescriptor2.HeaderImage = Nothing
        GridColumnDescriptor2.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor2.MappingName = "secuencia"
        GridColumnDescriptor2.Name = "secuencia"
        GridColumnDescriptor2.ReadOnly = True
        GridColumnDescriptor2.SerializedImageArray = ""
        GridColumnDescriptor2.Width = 50
        GridColumnDescriptor3.HeaderImage = Nothing
        GridColumnDescriptor3.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor3.HeaderText = "N°"
        GridColumnDescriptor3.MappingName = "nroEntregable"
        GridColumnDescriptor3.Name = "nroEntregable"
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor3.Width = 70
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.HeaderText = "Nombre"
        GridColumnDescriptor4.MappingName = "descripcionItem"
        GridColumnDescriptor4.Name = "descripcionItem"
        GridColumnDescriptor4.ReadOnly = True
        GridColumnDescriptor4.SerializedImageArray = ""
        GridColumnDescriptor4.Width = 350
        Me.dgvServicio.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4})
        Me.dgvServicio.TableDescriptor.StackedHeaderRows.Add(New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderRowDescriptor("Row 1", New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor("ENTREGABLES")}))
        Me.dgvServicio.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.dgvServicio.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.dgvServicio.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("nroEntregable"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("descripcionItem")})
        Me.dgvServicio.Text = "GridGroupingControl1"
        Me.dgvServicio.VersionInfo = "13.1400.0.21"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Panel2)
        Me.Panel4.Controls.Add(Me.Panel7)
        Me.Panel4.Controls.Add(Me.GradientPanel1)
        Me.Panel4.Controls.Add(Me.panel15)
        Me.Panel4.Controls.Add(Me.gpVSBehavior)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(325, 367)
        Me.Panel4.TabIndex = 451
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Controls.Add(Me.Label32)
        Me.Panel2.Location = New System.Drawing.Point(3, 86)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(320, 24)
        Me.Panel2.TabIndex = 199
        '
        'Label32
        '
        Me.Label32.BackColor = System.Drawing.Color.Transparent
        Me.Label32.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.Black
        Me.Label32.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label32.Location = New System.Drawing.Point(6, 3)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(194, 19)
        Me.Label32.TabIndex = 170
        Me.Label32.Text = "Datos del Proveedor"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.Panel7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel7.Controls.Add(Me.Label28)
        Me.Panel7.Location = New System.Drawing.Point(3, 194)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(320, 24)
        Me.Panel7.TabIndex = 443
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label28.Location = New System.Drawing.Point(6, 4)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(194, 19)
        Me.Label28.TabIndex = 170
        Me.Label28.Text = "Datos del Pago"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BackColor = System.Drawing.Color.White
        Me.GradientPanel1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.cboModalidad2)
        Me.GradientPanel1.Controls.Add(Me.cboCondPago)
        Me.GradientPanel1.Controls.Add(Me.txtCajaOrigen)
        Me.GradientPanel1.Controls.Add(Me.dtpFechaVencimiento)
        Me.GradientPanel1.Controls.Add(Me.Label23)
        Me.GradientPanel1.Controls.Add(Me.txtcto)
        Me.GradientPanel1.Controls.Add(Me.Label24)
        Me.GradientPanel1.Controls.Add(Me.Label26)
        Me.GradientPanel1.Controls.Add(Me.Label25)
        Me.GradientPanel1.Controls.Add(Me.Label27)
        Me.GradientPanel1.Location = New System.Drawing.Point(3, 221)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(320, 134)
        Me.GradientPanel1.TabIndex = 200
        '
        'cboModalidad2
        '
        Me.cboModalidad2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.cboModalidad2.Location = New System.Drawing.Point(125, 32)
        Me.cboModalidad2.Name = "cboModalidad2"
        Me.cboModalidad2.ReadOnly = True
        Me.cboModalidad2.Size = New System.Drawing.Size(183, 19)
        Me.cboModalidad2.TabIndex = 273
        Me.cboModalidad2.TabStop = False
        '
        'cboCondPago
        '
        Me.cboCondPago.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.cboCondPago.Location = New System.Drawing.Point(125, 9)
        Me.cboCondPago.Name = "cboCondPago"
        Me.cboCondPago.ReadOnly = True
        Me.cboCondPago.Size = New System.Drawing.Size(183, 19)
        Me.cboCondPago.TabIndex = 272
        Me.cboCondPago.TabStop = False
        '
        'txtCajaOrigen
        '
        Me.txtCajaOrigen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCajaOrigen.Location = New System.Drawing.Point(124, 84)
        Me.txtCajaOrigen.Name = "txtCajaOrigen"
        Me.txtCajaOrigen.ReadOnly = True
        Me.txtCajaOrigen.Size = New System.Drawing.Size(183, 19)
        Me.txtCajaOrigen.TabIndex = 271
        Me.txtCajaOrigen.TabStop = False
        '
        'dtpFechaVencimiento
        '
        Me.dtpFechaVencimiento.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.dtpFechaVencimiento.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.dtpFechaVencimiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.dtpFechaVencimiento.Calendar.AllowMultipleSelection = False
        Me.dtpFechaVencimiento.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.dtpFechaVencimiento.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dtpFechaVencimiento.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.dtpFechaVencimiento.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.dtpFechaVencimiento.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.dtpFechaVencimiento.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.dtpFechaVencimiento.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtpFechaVencimiento.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaVencimiento.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dtpFechaVencimiento.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.dtpFechaVencimiento.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.dtpFechaVencimiento.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.dtpFechaVencimiento.Calendar.HighlightColor = System.Drawing.Color.White
        Me.dtpFechaVencimiento.Calendar.Iso8601CalenderFormat = False
        Me.dtpFechaVencimiento.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.dtpFechaVencimiento.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.dtpFechaVencimiento.Calendar.Name = "monthCalendar"
        Me.dtpFechaVencimiento.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.dtpFechaVencimiento.Calendar.SelectedDates = New Date(-1) {}
        Me.dtpFechaVencimiento.Calendar.Size = New System.Drawing.Size(178, 174)
        Me.dtpFechaVencimiento.Calendar.SizeToFit = True
        Me.dtpFechaVencimiento.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.dtpFechaVencimiento.Calendar.TabIndex = 0
        Me.dtpFechaVencimiento.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.dtpFechaVencimiento.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.dtpFechaVencimiento.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.dtpFechaVencimiento.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.dtpFechaVencimiento.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.dtpFechaVencimiento.Calendar.NoneButton.IsBackStageButton = False
        Me.dtpFechaVencimiento.Calendar.NoneButton.Location = New System.Drawing.Point(106, 0)
        Me.dtpFechaVencimiento.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.dtpFechaVencimiento.Calendar.NoneButton.Text = "None"
        Me.dtpFechaVencimiento.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.dtpFechaVencimiento.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.dtpFechaVencimiento.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.dtpFechaVencimiento.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.dtpFechaVencimiento.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.dtpFechaVencimiento.Calendar.TodayButton.IsBackStageButton = False
        Me.dtpFechaVencimiento.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.dtpFechaVencimiento.Calendar.TodayButton.Size = New System.Drawing.Size(106, 20)
        Me.dtpFechaVencimiento.Calendar.TodayButton.Text = "Today"
        Me.dtpFechaVencimiento.Calendar.TodayButton.UseVisualStyle = True
        Me.dtpFechaVencimiento.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaVencimiento.CalendarForeColor = System.Drawing.SystemColors.ControlText
        Me.dtpFechaVencimiento.CalendarSize = New System.Drawing.Size(189, 176)
        Me.dtpFechaVencimiento.Checked = False
        Me.dtpFechaVencimiento.CustomFormat = "dd/MM/yyyy "
        Me.dtpFechaVencimiento.DropDownImage = Nothing
        Me.dtpFechaVencimiento.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.dtpFechaVencimiento.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.dtpFechaVencimiento.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.dtpFechaVencimiento.ForeColor = System.Drawing.Color.Black
        Me.dtpFechaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaVencimiento.Location = New System.Drawing.Point(125, 57)
        Me.dtpFechaVencimiento.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.dtpFechaVencimiento.MinValue = New Date(CType(0, Long))
        Me.dtpFechaVencimiento.Name = "dtpFechaVencimiento"
        Me.dtpFechaVencimiento.ReadOnly = True
        Me.dtpFechaVencimiento.ShowCheckBox = False
        Me.dtpFechaVencimiento.Size = New System.Drawing.Size(182, 20)
        Me.dtpFechaVencimiento.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.dtpFechaVencimiento.TabIndex = 270
        Me.dtpFechaVencimiento.Value = New Date(2015, 9, 16, 16, 21, 44, 579)
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label23.Location = New System.Drawing.Point(4, 84)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(113, 13)
        Me.Label23.TabIndex = 268
        Me.Label23.Text = "Institucion Financiera:"
        '
        'txtcto
        '
        Me.txtcto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcto.Location = New System.Drawing.Point(124, 107)
        Me.txtcto.Name = "txtcto"
        Me.txtcto.ReadOnly = True
        Me.txtcto.Size = New System.Drawing.Size(183, 19)
        Me.txtcto.TabIndex = 267
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label24.Location = New System.Drawing.Point(62, 110)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(55, 13)
        Me.Label24.TabIndex = 266
        Me.Label24.Text = "Nro. Cta :"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label26.Location = New System.Drawing.Point(54, 61)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(64, 13)
        Me.Label26.TabIndex = 265
        Me.Label26.Text = "Fecha Vcto:"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label25.Location = New System.Drawing.Point(59, 38)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(59, 13)
        Me.Label25.TabIndex = 264
        Me.Label25.Text = "Modalidad:"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label27.Location = New System.Drawing.Point(19, 12)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(99, 13)
        Me.Label27.TabIndex = 262
        Me.Label27.Text = "Condicion de Pago:"
        '
        'panel15
        '
        Me.panel15.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.panel15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.panel15.Controls.Add(Me.label35)
        Me.panel15.Location = New System.Drawing.Point(3, 3)
        Me.panel15.Name = "panel15"
        Me.panel15.Size = New System.Drawing.Size(320, 24)
        Me.panel15.TabIndex = 197
        '
        'label35
        '
        Me.label35.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label35.ForeColor = System.Drawing.Color.Black
        Me.label35.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.label35.Location = New System.Drawing.Point(10, 3)
        Me.label35.Name = "label35"
        Me.label35.Size = New System.Drawing.Size(194, 19)
        Me.label35.TabIndex = 170
        Me.label35.Text = "Datos del comprobante"
        Me.label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpVSBehavior
        '
        Me.gpVSBehavior.BackColor = System.Drawing.Color.White
        Me.gpVSBehavior.BorderColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.gpVSBehavior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.gpVSBehavior.Controls.Add(Me.Label17)
        Me.gpVSBehavior.Controls.Add(Me.txtRuc)
        Me.gpVSBehavior.Controls.Add(Me.txtComprobante)
        Me.gpVSBehavior.Controls.Add(Me.Label11)
        Me.gpVSBehavior.Controls.Add(Me.nudImporteMe)
        Me.gpVSBehavior.Controls.Add(Me.txtProveedor)
        Me.gpVSBehavior.Controls.Add(Me.txtCuenta)
        Me.gpVSBehavior.Controls.Add(Me.nudImporteMN)
        Me.gpVSBehavior.Controls.Add(Me.Label16)
        Me.gpVSBehavior.Controls.Add(Me.Label22)
        Me.gpVSBehavior.Controls.Add(Me.nudPorcentajeTributo)
        Me.gpVSBehavior.Controls.Add(Me.txtFechaComprobante)
        Me.gpVSBehavior.Controls.Add(Me.Label30)
        Me.gpVSBehavior.Controls.Add(Me.Label31)
        Me.gpVSBehavior.Location = New System.Drawing.Point(3, 28)
        Me.gpVSBehavior.Name = "gpVSBehavior"
        Me.gpVSBehavior.Size = New System.Drawing.Size(320, 159)
        Me.gpVSBehavior.TabIndex = 198
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(47, 90)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(48, 13)
        Me.Label17.TabIndex = 429
        Me.Label17.Text = "Nombre:"
        '
        'txtRuc
        '
        Me.txtRuc.BackColor = System.Drawing.Color.White
        Me.txtRuc.BeforeTouchSize = New System.Drawing.Size(152, 20)
        Me.txtRuc.BorderColor = System.Drawing.Color.YellowGreen
        Me.txtRuc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRuc.CornerRadius = 5
        Me.txtRuc.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRuc.Location = New System.Drawing.Point(100, 111)
        Me.txtRuc.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtRuc.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtRuc.Name = "txtRuc"
        Me.txtRuc.ReadOnly = True
        Me.txtRuc.Size = New System.Drawing.Size(152, 20)
        Me.txtRuc.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.txtRuc.TabIndex = 428
        '
        'txtComprobante
        '
        Me.txtComprobante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtComprobante.Location = New System.Drawing.Point(101, 8)
        Me.txtComprobante.Name = "txtComprobante"
        Me.txtComprobante.ReadOnly = True
        Me.txtComprobante.Size = New System.Drawing.Size(207, 19)
        Me.txtComprobante.TabIndex = 400
        Me.txtComprobante.Text = "ORDEN DE SERVICIO"
        '
        'Label11
        '
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label11.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label11.Location = New System.Drawing.Point(61, 110)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(34, 23)
        Me.Label11.TabIndex = 220
        Me.Label11.Text = "Nro.:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'nudImporteMe
        '
        Me.nudImporteMe.BackColor = System.Drawing.Color.White
        Me.nudImporteMe.BeforeTouchSize = New System.Drawing.Size(152, 20)
        Me.nudImporteMe.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.nudImporteMe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nudImporteMe.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.nudImporteMe.Location = New System.Drawing.Point(189, 188)
        Me.nudImporteMe.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.nudImporteMe.Name = "nudImporteMe"
        Me.nudImporteMe.ReadOnly = True
        Me.nudImporteMe.Size = New System.Drawing.Size(97, 20)
        Me.nudImporteMe.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.nudImporteMe.TabIndex = 399
        '
        'txtProveedor
        '
        Me.txtProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProveedor.Location = New System.Drawing.Point(101, 87)
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.ReadOnly = True
        Me.txtProveedor.Size = New System.Drawing.Size(207, 19)
        Me.txtProveedor.TabIndex = 206
        '
        'txtCuenta
        '
        Me.txtCuenta.Location = New System.Drawing.Point(100, 135)
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.ReadOnly = True
        Me.txtCuenta.Size = New System.Drawing.Size(152, 19)
        Me.txtCuenta.TabIndex = 205
        '
        'nudImporteMN
        '
        Me.nudImporteMN.BackColor = System.Drawing.Color.White
        Me.nudImporteMN.BeforeTouchSize = New System.Drawing.Size(152, 20)
        Me.nudImporteMN.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.nudImporteMN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nudImporteMN.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.nudImporteMN.Location = New System.Drawing.Point(89, 188)
        Me.nudImporteMN.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.nudImporteMN.Name = "nudImporteMN"
        Me.nudImporteMN.ReadOnly = True
        Me.nudImporteMN.Size = New System.Drawing.Size(97, 20)
        Me.nudImporteMN.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.Metro
        Me.nudImporteMN.TabIndex = 398
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(49, 138)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(46, 13)
        Me.Label16.TabIndex = 202
        Me.Label16.Text = "Cuenta:"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label22.Location = New System.Drawing.Point(8, 192)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(22, 13)
        Me.Label22.TabIndex = 397
        Me.Label22.Text = "%:"
        '
        'nudPorcentajeTributo
        '
        Me.nudPorcentajeTributo.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.nudPorcentajeTributo.BeforeTouchSize = New System.Drawing.Size(51, 20)
        Me.nudPorcentajeTributo.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.nudPorcentajeTributo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nudPorcentajeTributo.DecimalPlaces = 2
        Me.nudPorcentajeTributo.Location = New System.Drawing.Point(32, 188)
        Me.nudPorcentajeTributo.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.nudPorcentajeTributo.Name = "nudPorcentajeTributo"
        Me.nudPorcentajeTributo.Size = New System.Drawing.Size(51, 20)
        Me.nudPorcentajeTributo.TabIndex = 396
        Me.nudPorcentajeTributo.ThousandsSeparator = True
        Me.nudPorcentajeTributo.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
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
        Me.txtFechaComprobante.Calendar.Size = New System.Drawing.Size(203, 174)
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
        Me.txtFechaComprobante.Calendar.NoneButton.Location = New System.Drawing.Point(131, 0)
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
        Me.txtFechaComprobante.Calendar.TodayButton.Size = New System.Drawing.Size(131, 20)
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
        Me.txtFechaComprobante.Location = New System.Drawing.Point(101, 31)
        Me.txtFechaComprobante.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaComprobante.MinValue = New Date(CType(0, Long))
        Me.txtFechaComprobante.Name = "txtFechaComprobante"
        Me.txtFechaComprobante.ReadOnly = True
        Me.txtFechaComprobante.ShowCheckBox = False
        Me.txtFechaComprobante.ShowDropButton = False
        Me.txtFechaComprobante.Size = New System.Drawing.Size(207, 20)
        Me.txtFechaComprobante.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaComprobante.TabIndex = 208
        Me.txtFechaComprobante.Value = New Date(2015, 4, 14, 15, 59, 3, 447)
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label30.Location = New System.Drawing.Point(19, 11)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(76, 13)
        Me.Label30.TabIndex = 200
        Me.Label30.Text = "Comprobante:"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label31.Location = New System.Drawing.Point(52, 34)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(40, 13)
        Me.Label31.TabIndex = 199
        Me.Label31.Text = "Fecha:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Panel3)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.cboObjetoContratacion)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.nudDetraccion)
        Me.GroupBox3.Controls.Add(Me.txtFondoGarantia)
        Me.GroupBox3.Controls.Add(Me.txtAdelanto)
        Me.GroupBox3.Controls.Add(Me.nudDetraccionME)
        Me.GroupBox3.Controls.Add(Me.txtFondoGarantiaME)
        Me.GroupBox3.Controls.Add(Me.txtAdelantoME)
        Me.GroupBox3.Controls.Add(Me.txtImporteContratacionME)
        Me.GroupBox3.Controls.Add(Me.txtImporteContratacion)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.txtNombreEntregable)
        Me.GroupBox3.Controls.Add(Me.GroupBox2)
        Me.GroupBox3.Controls.Add(Me.tbDetraccion)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.txtContra)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.txtPenalidades)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Location = New System.Drawing.Point(446, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(419, 367)
        Me.GroupBox3.TabIndex = 447
        Me.GroupBox3.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel3.Controls.Add(Me.Label18)
        Me.Panel3.Location = New System.Drawing.Point(5, 13)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(381, 24)
        Me.Panel3.TabIndex = 444
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label18.Location = New System.Drawing.Point(6, 4)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(194, 19)
        Me.Label18.TabIndex = 170
        Me.Label18.Text = "Objeto de Contratación"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(295, 239)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(11, 13)
        Me.Label9.TabIndex = 437
        Me.Label9.Text = "-"
        '
        'cboObjetoContratacion
        '
        Me.cboObjetoContratacion.Enabled = False
        Me.cboObjetoContratacion.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboObjetoContratacion.FormattingEnabled = True
        Me.cboObjetoContratacion.Items.AddRange(New Object() {"DIARIO", "SEMANAL", "QUINCENAL", "MENSUAL", "BIMESTRAL", "TRIMESTRAL", "SEMESTRAL", "ANUAL", "OTROS"})
        Me.cboObjetoContratacion.Location = New System.Drawing.Point(141, 93)
        Me.cboObjetoContratacion.Name = "cboObjetoContratacion"
        Me.cboObjetoContratacion.Size = New System.Drawing.Size(179, 21)
        Me.cboObjetoContratacion.TabIndex = 436
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(255, 210)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(29, 13)
        Me.Label7.TabIndex = 435
        Me.Label7.Text = "ME.:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(252, 184)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 13)
        Me.Label5.TabIndex = 434
        Me.Label5.Text = " ME.:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(255, 154)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 433
        Me.Label2.Text = "ME.:"
        '
        'nudDetraccion
        '
        Me.nudDetraccion.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.nudDetraccion.BeforeTouchSize = New System.Drawing.Size(73, 23)
        Me.nudDetraccion.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.nudDetraccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nudDetraccion.DecimalPlaces = 2
        Me.nudDetraccion.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudDetraccion.InterceptArrowKeys = False
        Me.nudDetraccion.Location = New System.Drawing.Point(218, 234)
        Me.nudDetraccion.Maximum = New Decimal(New Integer() {268435456, 1042612833, 542101086, 0})
        Me.nudDetraccion.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.nudDetraccion.Name = "nudDetraccion"
        Me.nudDetraccion.ReadOnly = True
        Me.nudDetraccion.Size = New System.Drawing.Size(73, 23)
        Me.nudDetraccion.TabIndex = 432
        Me.nudDetraccion.TabStop = False
        Me.nudDetraccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudDetraccion.ThousandsSeparator = True
        Me.nudDetraccion.Visible = False
        Me.nudDetraccion.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'txtFondoGarantia
        '
        Me.txtFondoGarantia.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.txtFondoGarantia.BeforeTouchSize = New System.Drawing.Size(96, 23)
        Me.txtFondoGarantia.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFondoGarantia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFondoGarantia.DecimalPlaces = 2
        Me.txtFondoGarantia.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFondoGarantia.InterceptArrowKeys = False
        Me.txtFondoGarantia.Location = New System.Drawing.Point(141, 205)
        Me.txtFondoGarantia.Maximum = New Decimal(New Integer() {268435456, 1042612833, 542101086, 0})
        Me.txtFondoGarantia.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFondoGarantia.Name = "txtFondoGarantia"
        Me.txtFondoGarantia.ReadOnly = True
        Me.txtFondoGarantia.Size = New System.Drawing.Size(96, 23)
        Me.txtFondoGarantia.TabIndex = 431
        Me.txtFondoGarantia.TabStop = False
        Me.txtFondoGarantia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtFondoGarantia.ThousandsSeparator = True
        Me.txtFondoGarantia.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'txtAdelanto
        '
        Me.txtAdelanto.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.txtAdelanto.BeforeTouchSize = New System.Drawing.Size(96, 23)
        Me.txtAdelanto.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtAdelanto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAdelanto.DecimalPlaces = 2
        Me.txtAdelanto.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAdelanto.InterceptArrowKeys = False
        Me.txtAdelanto.Location = New System.Drawing.Point(141, 176)
        Me.txtAdelanto.Maximum = New Decimal(New Integer() {268435456, 1042612833, 542101086, 0})
        Me.txtAdelanto.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtAdelanto.Name = "txtAdelanto"
        Me.txtAdelanto.ReadOnly = True
        Me.txtAdelanto.Size = New System.Drawing.Size(96, 23)
        Me.txtAdelanto.TabIndex = 430
        Me.txtAdelanto.TabStop = False
        Me.txtAdelanto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtAdelanto.ThousandsSeparator = True
        Me.txtAdelanto.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'nudDetraccionME
        '
        Me.nudDetraccionME.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.nudDetraccionME.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.nudDetraccionME.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.nudDetraccionME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nudDetraccionME.DecimalPlaces = 2
        Me.nudDetraccionME.Enabled = False
        Me.nudDetraccionME.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudDetraccionME.InterceptArrowKeys = False
        Me.nudDetraccionME.Location = New System.Drawing.Point(311, 234)
        Me.nudDetraccionME.Maximum = New Decimal(New Integer() {268435456, 1042612833, 542101086, 0})
        Me.nudDetraccionME.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.nudDetraccionME.Name = "nudDetraccionME"
        Me.nudDetraccionME.ReadOnly = True
        Me.nudDetraccionME.Size = New System.Drawing.Size(75, 23)
        Me.nudDetraccionME.TabIndex = 429
        Me.nudDetraccionME.TabStop = False
        Me.nudDetraccionME.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudDetraccionME.ThousandsSeparator = True
        Me.nudDetraccionME.Visible = False
        Me.nudDetraccionME.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'txtFondoGarantiaME
        '
        Me.txtFondoGarantiaME.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.txtFondoGarantiaME.BeforeTouchSize = New System.Drawing.Size(96, 23)
        Me.txtFondoGarantiaME.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFondoGarantiaME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFondoGarantiaME.DecimalPlaces = 2
        Me.txtFondoGarantiaME.Enabled = False
        Me.txtFondoGarantiaME.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFondoGarantiaME.InterceptArrowKeys = False
        Me.txtFondoGarantiaME.Location = New System.Drawing.Point(290, 205)
        Me.txtFondoGarantiaME.Maximum = New Decimal(New Integer() {268435456, 1042612833, 542101086, 0})
        Me.txtFondoGarantiaME.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFondoGarantiaME.Name = "txtFondoGarantiaME"
        Me.txtFondoGarantiaME.ReadOnly = True
        Me.txtFondoGarantiaME.Size = New System.Drawing.Size(96, 23)
        Me.txtFondoGarantiaME.TabIndex = 428
        Me.txtFondoGarantiaME.TabStop = False
        Me.txtFondoGarantiaME.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtFondoGarantiaME.ThousandsSeparator = True
        Me.txtFondoGarantiaME.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'txtAdelantoME
        '
        Me.txtAdelantoME.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.txtAdelantoME.BeforeTouchSize = New System.Drawing.Size(96, 23)
        Me.txtAdelantoME.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtAdelantoME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAdelantoME.DecimalPlaces = 2
        Me.txtAdelantoME.Enabled = False
        Me.txtAdelantoME.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAdelantoME.InterceptArrowKeys = False
        Me.txtAdelantoME.Location = New System.Drawing.Point(290, 176)
        Me.txtAdelantoME.Maximum = New Decimal(New Integer() {268435456, 1042612833, 542101086, 0})
        Me.txtAdelantoME.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtAdelantoME.Name = "txtAdelantoME"
        Me.txtAdelantoME.ReadOnly = True
        Me.txtAdelantoME.Size = New System.Drawing.Size(96, 23)
        Me.txtAdelantoME.TabIndex = 427
        Me.txtAdelantoME.TabStop = False
        Me.txtAdelantoME.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtAdelantoME.ThousandsSeparator = True
        Me.txtAdelantoME.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'txtImporteContratacionME
        '
        Me.txtImporteContratacionME.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.txtImporteContratacionME.BeforeTouchSize = New System.Drawing.Size(96, 23)
        Me.txtImporteContratacionME.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtImporteContratacionME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtImporteContratacionME.DecimalPlaces = 2
        Me.txtImporteContratacionME.Enabled = False
        Me.txtImporteContratacionME.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImporteContratacionME.InterceptArrowKeys = False
        Me.txtImporteContratacionME.Location = New System.Drawing.Point(290, 147)
        Me.txtImporteContratacionME.Maximum = New Decimal(New Integer() {268435456, 1042612833, 542101086, 0})
        Me.txtImporteContratacionME.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtImporteContratacionME.Name = "txtImporteContratacionME"
        Me.txtImporteContratacionME.ReadOnly = True
        Me.txtImporteContratacionME.Size = New System.Drawing.Size(96, 23)
        Me.txtImporteContratacionME.TabIndex = 426
        Me.txtImporteContratacionME.TabStop = False
        Me.txtImporteContratacionME.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtImporteContratacionME.ThousandsSeparator = True
        Me.txtImporteContratacionME.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'txtImporteContratacion
        '
        Me.txtImporteContratacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.txtImporteContratacion.BeforeTouchSize = New System.Drawing.Size(96, 23)
        Me.txtImporteContratacion.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtImporteContratacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtImporteContratacion.DecimalPlaces = 2
        Me.txtImporteContratacion.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImporteContratacion.InterceptArrowKeys = False
        Me.txtImporteContratacion.Location = New System.Drawing.Point(141, 147)
        Me.txtImporteContratacion.Maximum = New Decimal(New Integer() {268435456, 1042612833, 542101086, 0})
        Me.txtImporteContratacion.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtImporteContratacion.Name = "txtImporteContratacion"
        Me.txtImporteContratacion.ReadOnly = True
        Me.txtImporteContratacion.Size = New System.Drawing.Size(96, 23)
        Me.txtImporteContratacion.TabIndex = 425
        Me.txtImporteContratacion.TabStop = False
        Me.txtImporteContratacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtImporteContratacion.ThousandsSeparator = True
        Me.txtImporteContratacion.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(17, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 13)
        Me.Label1.TabIndex = 418
        Me.Label1.Text = "Nombre de entregable:"
        '
        'txtNombreEntregable
        '
        Me.txtNombreEntregable.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombreEntregable.Location = New System.Drawing.Point(141, 43)
        Me.txtNombreEntregable.Name = "txtNombreEntregable"
        Me.txtNombreEntregable.ReadOnly = True
        Me.txtNombreEntregable.Size = New System.Drawing.Size(244, 19)
        Me.txtNombreEntregable.TabIndex = 419
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.fechainicio)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.fechafin)
        Me.GroupBox2.ForeColor = System.Drawing.Color.SteelBlue
        Me.GroupBox2.Location = New System.Drawing.Point(17, 263)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(369, 66)
        Me.GroupBox2.TabIndex = 417
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Plazo de Contratación"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label3.Location = New System.Drawing.Point(121, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 209
        Me.Label3.Text = "Desde:"
        '
        'fechainicio
        '
        Me.fechainicio.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.fechainicio.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.fechainicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.fechainicio.Calendar.AllowMultipleSelection = False
        Me.fechainicio.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.fechainicio.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.fechainicio.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.fechainicio.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.fechainicio.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.fechainicio.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.fechainicio.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fechainicio.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fechainicio.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fechainicio.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.fechainicio.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.fechainicio.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.fechainicio.Calendar.HighlightColor = System.Drawing.Color.White
        Me.fechainicio.Calendar.Iso8601CalenderFormat = False
        Me.fechainicio.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.fechainicio.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.fechainicio.Calendar.Name = "monthCalendar"
        Me.fechainicio.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.fechainicio.Calendar.SelectedDates = New Date(-1) {}
        Me.fechainicio.Calendar.Size = New System.Drawing.Size(147, 174)
        Me.fechainicio.Calendar.SizeToFit = True
        Me.fechainicio.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.fechainicio.Calendar.TabIndex = 0
        Me.fechainicio.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.fechainicio.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.fechainicio.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.fechainicio.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.fechainicio.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.fechainicio.Calendar.NoneButton.IsBackStageButton = False
        Me.fechainicio.Calendar.NoneButton.Location = New System.Drawing.Point(75, 0)
        Me.fechainicio.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.fechainicio.Calendar.NoneButton.Text = "None"
        Me.fechainicio.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.fechainicio.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.fechainicio.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.fechainicio.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.fechainicio.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.fechainicio.Calendar.TodayButton.IsBackStageButton = False
        Me.fechainicio.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.fechainicio.Calendar.TodayButton.Size = New System.Drawing.Size(75, 20)
        Me.fechainicio.Calendar.TodayButton.Text = "Today"
        Me.fechainicio.Calendar.TodayButton.UseVisualStyle = True
        Me.fechainicio.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fechainicio.CalendarForeColor = System.Drawing.SystemColors.ControlText
        Me.fechainicio.CalendarSize = New System.Drawing.Size(189, 176)
        Me.fechainicio.CustomFormat = "dd/MM/yyyy"
        Me.fechainicio.DropDownImage = Nothing
        Me.fechainicio.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.fechainicio.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.fechainicio.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.fechainicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.fechainicio.Location = New System.Drawing.Point(169, 16)
        Me.fechainicio.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.fechainicio.MinValue = New Date(CType(0, Long))
        Me.fechainicio.Name = "fechainicio"
        Me.fechainicio.ReadOnly = True
        Me.fechainicio.ShowCheckBox = False
        Me.fechainicio.Size = New System.Drawing.Size(151, 20)
        Me.fechainicio.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.fechainicio.TabIndex = 210
        Me.fechainicio.Value = New Date(2015, 9, 18, 8, 21, 28, 552)
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label10.Location = New System.Drawing.Point(121, 38)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(39, 13)
        Me.Label10.TabIndex = 252
        Me.Label10.Text = "Hasta:"
        '
        'fechafin
        '
        Me.fechafin.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.fechafin.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.fechafin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.fechafin.Calendar.AllowMultipleSelection = False
        Me.fechafin.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.fechafin.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.fechafin.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.fechafin.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.fechafin.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.fechafin.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.fechafin.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fechafin.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fechafin.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fechafin.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.fechafin.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.fechafin.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.fechafin.Calendar.HighlightColor = System.Drawing.Color.White
        Me.fechafin.Calendar.Iso8601CalenderFormat = False
        Me.fechafin.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.fechafin.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.fechafin.Calendar.Name = "monthCalendar"
        Me.fechafin.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.fechafin.Calendar.SelectedDates = New Date(-1) {}
        Me.fechafin.Calendar.Size = New System.Drawing.Size(148, 174)
        Me.fechafin.Calendar.SizeToFit = True
        Me.fechafin.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.fechafin.Calendar.TabIndex = 0
        Me.fechafin.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.fechafin.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.fechafin.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.fechafin.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.fechafin.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.fechafin.Calendar.NoneButton.IsBackStageButton = False
        Me.fechafin.Calendar.NoneButton.Location = New System.Drawing.Point(76, 0)
        Me.fechafin.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.fechafin.Calendar.NoneButton.Text = "None"
        Me.fechafin.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.fechafin.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.fechafin.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.fechafin.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.fechafin.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.fechafin.Calendar.TodayButton.IsBackStageButton = False
        Me.fechafin.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.fechafin.Calendar.TodayButton.Size = New System.Drawing.Size(76, 20)
        Me.fechafin.Calendar.TodayButton.Text = "Today"
        Me.fechafin.Calendar.TodayButton.UseVisualStyle = True
        Me.fechafin.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fechafin.CalendarForeColor = System.Drawing.SystemColors.ControlText
        Me.fechafin.CalendarSize = New System.Drawing.Size(189, 176)
        Me.fechafin.CustomFormat = "dd/MM/yyyy "
        Me.fechafin.DropDownImage = Nothing
        Me.fechafin.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.fechafin.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.fechafin.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.fechafin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.fechafin.Location = New System.Drawing.Point(169, 40)
        Me.fechafin.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.fechafin.MinValue = New Date(CType(0, Long))
        Me.fechafin.Name = "fechafin"
        Me.fechafin.ReadOnly = True
        Me.fechafin.ShowCheckBox = False
        Me.fechafin.Size = New System.Drawing.Size(152, 20)
        Me.fechafin.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.fechafin.TabIndex = 253
        Me.fechafin.Value = New Date(2015, 9, 18, 8, 21, 31, 962)
        '
        'tbDetraccion
        '
        ActiveStateCollection1.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer))
        ActiveStateCollection1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        ActiveStateCollection1.HoverColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer))
        ActiveStateCollection1.Text = "ON"
        Me.tbDetraccion.ActiveState = ActiveStateCollection1
        Me.tbDetraccion.Enabled = False
        Me.tbDetraccion.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.tbDetraccion.ForeColor = System.Drawing.Color.Black
        InactiveStateCollection1.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer))
        InactiveStateCollection1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        InactiveStateCollection1.ForeColor = System.Drawing.Color.White
        InactiveStateCollection1.HoverColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer))
        InactiveStateCollection1.Text = "OFF"
        Me.tbDetraccion.InactiveState = InactiveStateCollection1
        Me.tbDetraccion.Location = New System.Drawing.Point(140, 237)
        Me.tbDetraccion.MinimumSize = New System.Drawing.Size(52, 20)
        Me.tbDetraccion.Name = "tbDetraccion"
        Me.tbDetraccion.Renderer = ToggleButtonRenderer1
        Me.tbDetraccion.Size = New System.Drawing.Size(69, 20)
        SliderCollection1.BackColor = System.Drawing.Color.White
        SliderCollection1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        SliderCollection1.ForeColor = System.Drawing.Color.White
        SliderCollection1.HoverColor = System.Drawing.Color.FromArgb(CType(CType(8, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(171, Byte), Integer))
        SliderCollection1.Width = 30
        Me.tbDetraccion.Slider = SliderCollection1
        Me.tbDetraccion.TabIndex = 415
        Me.tbDetraccion.Text = "Button1"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(13, 71)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(122, 13)
        Me.Label6.TabIndex = 403
        Me.Label6.Text = "Objeto de contratación:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(62, 239)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 13)
        Me.Label4.TabIndex = 402
        Me.Label4.Text = "Detracciones:"
        '
        'txtContra
        '
        Me.txtContra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtContra.Location = New System.Drawing.Point(141, 68)
        Me.txtContra.Name = "txtContra"
        Me.txtContra.ReadOnly = True
        Me.txtContra.Size = New System.Drawing.Size(244, 19)
        Me.txtContra.TabIndex = 404
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(6, 154)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(129, 13)
        Me.Label8.TabIndex = 405
        Me.Label8.Text = "Importe de Contratación:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(14, 96)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(121, 13)
        Me.Label12.TabIndex = 406
        Me.Label12.Text = "Periodo de Valorizacion:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(59, 184)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(76, 13)
        Me.Label13.TabIndex = 408
        Me.Label13.Text = "Adelanto MN.:"
        '
        'txtPenalidades
        '
        Me.txtPenalidades.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPenalidades.Location = New System.Drawing.Point(141, 120)
        Me.txtPenalidades.Name = "txtPenalidades"
        Me.txtPenalidades.ReadOnly = True
        Me.txtPenalidades.Size = New System.Drawing.Size(244, 19)
        Me.txtPenalidades.TabIndex = 411
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(46, 210)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(89, 13)
        Me.Label14.TabIndex = 409
        Me.Label14.Text = "Fondo Garantia.:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(67, 123)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(68, 13)
        Me.Label15.TabIndex = 410
        Me.Label15.Text = "Penalidades:"
        '
        'dockingManager1
        '
        Me.dockingManager1.ActiveCaptionFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.dockingManager1.AutoHideTabFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.dockingManager1.DockLayoutStream = CType(resources.GetObject("dockingManager1.DockLayoutStream"), System.IO.MemoryStream)
        Me.dockingManager1.DockTabFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.dockingManager1.HostControl = Me
        Me.dockingManager1.InActiveCaptionBackground = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer)))
        Me.dockingManager1.InActiveCaptionFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.dockingManager1.MetroButtonColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dockingManager1.MetroCaptionColor = System.Drawing.Color.White
        Me.dockingManager1.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.dockingManager1.MetroSplitterBackColor = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(183, Byte), Integer))
        Me.dockingManager1.ReduceFlickeringInRtl = False
        Me.dockingManager1.SplitterWidth = 1
        Me.dockingManager1.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.dockingManager1.CaptionButtons.Add(New Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Close, "CloseButton"))
        Me.dockingManager1.CaptionButtons.Add(New Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Pin, "PinButton"))
        Me.dockingManager1.CaptionButtons.Add(New Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Maximize, "MaximizeButton"))
        Me.dockingManager1.CaptionButtons.Add(New Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Restore, "RestoreButton"))
        Me.dockingManager1.CaptionButtons.Add(New Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Menu, "MenuButton"))
        '
        'DockingClientPanel1
        '
        Me.DockingClientPanel1.Controls.Add(Me.GroupBox3)
        Me.DockingClientPanel1.Controls.Add(Me.Panel1)
        Me.DockingClientPanel1.Location = New System.Drawing.Point(0, 2)
        Me.DockingClientPanel1.Name = "DockingClientPanel1"
        Me.DockingClientPanel1.Size = New System.Drawing.Size(865, 367)
        Me.DockingClientPanel1.TabIndex = 451
        '
        'frmOrdenServiciosGeneral
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(870, 441)
        Me.Controls.Add(Me.DockingClientPanel1)
        Me.Name = "frmOrdenServiciosGeneral"
        Me.Text = "Orden Servicio General"
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvServicio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        CType(Me.dtpFechaVencimiento.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpFechaVencimiento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel15.ResumeLayout(False)
        CType(Me.gpVSBehavior, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpVSBehavior.ResumeLayout(False)
        Me.gpVSBehavior.PerformLayout()
        CType(Me.txtRuc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudImporteMe, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudImporteMN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPorcentajeTributo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaComprobante.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaComprobante, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        CType(Me.nudDetraccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFondoGarantia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAdelanto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudDetraccionME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFondoGarantiaME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAdelantoME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtImporteContratacionME, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtImporteContratacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.fechainicio.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fechainicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fechafin.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fechafin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbDetraccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dockingManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DockingClientPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgvServicio As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboObjetoContratacion As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents nudDetraccion As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents txtFondoGarantia As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents txtAdelanto As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents nudDetraccionME As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents txtFondoGarantiaME As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents txtAdelantoME As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents txtImporteContratacionME As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents txtImporteContratacion As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNombreEntregable As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents fechainicio As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents fechafin As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Private WithEvents tbDetraccion As Syncfusion.Windows.Forms.Tools.ToggleButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtContra As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtPenalidades As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Private WithEvents Panel2 As System.Windows.Forms.Panel
    Private WithEvents Label32 As System.Windows.Forms.Label
    Private WithEvents Panel7 As System.Windows.Forms.Panel
    Private WithEvents Label28 As System.Windows.Forms.Label
    Private WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Private WithEvents panel15 As System.Windows.Forms.Panel
    Private WithEvents label35 As System.Windows.Forms.Label
    Private WithEvents gpVSBehavior As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents txtRuc As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtComprobante As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents nudImporteMe As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtProveedor As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents txtCuenta As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents nudImporteMN As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents nudPorcentajeTributo As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Friend WithEvents txtFechaComprobante As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Private WithEvents Panel3 As System.Windows.Forms.Panel
    Private WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtCajaOrigen As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents dtpFechaVencimiento As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Public WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtcto As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Public WithEvents Label24 As System.Windows.Forms.Label
    Public WithEvents Label26 As System.Windows.Forms.Label
    Public WithEvents Label25 As System.Windows.Forms.Label
    Public WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cboModalidad2 As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents cboCondPago As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Private WithEvents dockingManager1 As Syncfusion.Windows.Forms.Tools.DockingManager
    Friend WithEvents QGlobalColorSchemeManager1 As Qios.DevSuite.Components.QGlobalColorSchemeManager
    Friend WithEvents DockingClientPanel1 As Syncfusion.Windows.Forms.Tools.DockingClientPanel
End Class

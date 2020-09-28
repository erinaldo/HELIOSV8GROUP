<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDetalleOrdenServicio
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
        Dim GridColumnDescriptor5 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor6 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor7 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim ActiveStateCollection1 As Syncfusion.Windows.Forms.Tools.ActiveStateCollection = New Syncfusion.Windows.Forms.Tools.ActiveStateCollection()
        Dim InactiveStateCollection1 As Syncfusion.Windows.Forms.Tools.InactiveStateCollection = New Syncfusion.Windows.Forms.Tools.InactiveStateCollection()
        Dim ToggleButtonRenderer1 As Syncfusion.Windows.Forms.Tools.ToggleButtonRenderer = New Syncfusion.Windows.Forms.Tools.ToggleButtonRenderer()
        Dim SliderCollection1 As Syncfusion.Windows.Forms.Tools.SliderCollection = New Syncfusion.Windows.Forms.Tools.SliderCollection()
        Dim ActiveStateCollection2 As Syncfusion.Windows.Forms.Tools.ActiveStateCollection = New Syncfusion.Windows.Forms.Tools.ActiveStateCollection()
        Dim InactiveStateCollection2 As Syncfusion.Windows.Forms.Tools.InactiveStateCollection = New Syncfusion.Windows.Forms.Tools.InactiveStateCollection()
        Dim ToggleButtonRenderer2 As Syncfusion.Windows.Forms.Tools.ToggleButtonRenderer = New Syncfusion.Windows.Forms.Tools.ToggleButtonRenderer()
        Dim SliderCollection2 As Syncfusion.Windows.Forms.Tools.SliderCollection = New Syncfusion.Windows.Forms.Tools.SliderCollection()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDetalleOrdenServicio))
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgvServicio = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblDetracciones = New System.Windows.Forms.Label()
        Me.lblFGarantia = New System.Windows.Forms.Label()
        Me.ToggleButton1 = New Syncfusion.Windows.Forms.Tools.ToggleButton()
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.fechainicio = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.fechafin = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.tbDetraccion = New Syncfusion.Windows.Forms.Tools.ToggleButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtDetracciones = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.txtFGarantia = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.txtNombreEntregable = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.txtContra = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.txtPenalidades = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.PanelError = New System.Windows.Forms.Panel()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.Panel17 = New System.Windows.Forms.Panel()
        Me.ToolStrip5 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.lblPerido = New System.Windows.Forms.ToolStripLabel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.GradientPanel4 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.txtMoneda = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TextBoxExt1 = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.TextBoxExt2 = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.GradientPanel3 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.popupControlContainer1 = New Syncfusion.Windows.Forms.PopupControlContainer()
        Me.lsvProveedor = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cancel = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.OK = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.txtRuc = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtProveedorServicio = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.txtNumero = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.cboTipoDoc = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.txtSerie = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtFecha = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbDetallesEntrega = New System.Windows.Forms.ToolStripButton()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvServicio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.ToggleButton1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.PanelError.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel17.SuspendLayout()
        Me.ToolStrip5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.GradientPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel4.SuspendLayout()
        CType(Me.txtMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxExt1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxExt2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel3.SuspendLayout()
        Me.popupControlContainer1.SuspendLayout()
        CType(Me.txtRuc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProveedorServicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        CType(Me.txtNumero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTipoDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSerie, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dgvServicio)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 211)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(958, 273)
        Me.Panel1.TabIndex = 449
        '
        'dgvServicio
        '
        Me.dgvServicio.BackColor = System.Drawing.SystemColors.Window
        Me.dgvServicio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvServicio.FreezeCaption = False
        Me.dgvServicio.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.dgvServicio.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.dgvServicio.Location = New System.Drawing.Point(0, 0)
        Me.dgvServicio.Name = "dgvServicio"
        Me.dgvServicio.Size = New System.Drawing.Size(958, 273)
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
        GridColumnDescriptor3.HeaderText = "Nombre"
        GridColumnDescriptor3.MappingName = "descripcionItem"
        GridColumnDescriptor3.Name = "descripcionItem"
        GridColumnDescriptor3.ReadOnly = True
        GridColumnDescriptor3.SerializedImageArray = ""
        GridColumnDescriptor3.Width = 300
        GridColumnDescriptor4.HeaderImage = Nothing
        GridColumnDescriptor4.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor4.HeaderText = "Estado"
        GridColumnDescriptor4.MappingName = "descripcionEstado"
        GridColumnDescriptor4.Name = "descripcionEstado"
        GridColumnDescriptor4.ReadOnly = True
        GridColumnDescriptor4.SerializedImageArray = ""
        GridColumnDescriptor4.Width = 200
        GridColumnDescriptor5.Appearance.AnyRecordFieldCell.CellType = "CheckBox"
        GridColumnDescriptor5.Appearance.AnyRecordFieldCell.CellValueType = GetType(Boolean)
        GridColumnDescriptor5.HeaderImage = Nothing
        GridColumnDescriptor5.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor5.HeaderText = """"""
        GridColumnDescriptor5.MappingName = "estado"
        GridColumnDescriptor5.Name = "estado"
        GridColumnDescriptor5.ReadOnly = True
        GridColumnDescriptor5.SerializedImageArray = ""
        GridColumnDescriptor5.Width = 20
        GridColumnDescriptor6.HeaderImage = Nothing
        GridColumnDescriptor6.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor6.MappingName = "importe"
        GridColumnDescriptor6.Name = "importe"
        GridColumnDescriptor6.SerializedImageArray = ""
        GridColumnDescriptor6.Width = 100
        GridColumnDescriptor7.HeaderImage = Nothing
        GridColumnDescriptor7.HeaderImageAlignment = Syncfusion.Windows.Forms.Grid.Grouping.HeaderImageAlignment.Left
        GridColumnDescriptor7.MappingName = "importeUS"
        GridColumnDescriptor7.Name = "importeUS"
        GridColumnDescriptor7.SerializedImageArray = ""
        GridColumnDescriptor7.Width = 100
        Me.dgvServicio.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3, GridColumnDescriptor4, GridColumnDescriptor5, GridColumnDescriptor6, GridColumnDescriptor7})
        Me.dgvServicio.TableDescriptor.StackedHeaderRows.Add(New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderRowDescriptor("Row 1", New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor("ENTREGABLES")}))
        Me.dgvServicio.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.dgvServicio.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.dgvServicio.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("descripcionItem"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("importe"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("importeUS"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("descripcionEstado"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("estado")})
        Me.dgvServicio.Text = "GridGroupingControl1"
        Me.dgvServicio.VersionInfo = "13.1400.0.21"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblDetracciones)
        Me.GroupBox3.Controls.Add(Me.lblFGarantia)
        Me.GroupBox3.Controls.Add(Me.ToggleButton1)
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
        Me.GroupBox3.Controls.Add(Me.GroupBox2)
        Me.GroupBox3.Controls.Add(Me.tbDetraccion)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Enabled = False
        Me.GroupBox3.Location = New System.Drawing.Point(661, 17)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(400, 428)
        Me.GroupBox3.TabIndex = 446
        Me.GroupBox3.TabStop = False
        '
        'lblDetracciones
        '
        Me.lblDetracciones.AutoSize = True
        Me.lblDetracciones.ForeColor = System.Drawing.Color.Black
        Me.lblDetracciones.Location = New System.Drawing.Point(265, 185)
        Me.lblDetracciones.Name = "lblDetracciones"
        Me.lblDetracciones.Size = New System.Drawing.Size(16, 13)
        Me.lblDetracciones.TabIndex = 442
        Me.lblDetracciones.Text = "%"
        Me.lblDetracciones.Visible = False
        '
        'lblFGarantia
        '
        Me.lblFGarantia.AutoSize = True
        Me.lblFGarantia.ForeColor = System.Drawing.Color.Black
        Me.lblFGarantia.Location = New System.Drawing.Point(262, 157)
        Me.lblFGarantia.Name = "lblFGarantia"
        Me.lblFGarantia.Size = New System.Drawing.Size(19, 13)
        Me.lblFGarantia.TabIndex = 441
        Me.lblFGarantia.Text = " %"
        Me.lblFGarantia.Visible = False
        '
        'ToggleButton1
        '
        ActiveStateCollection1.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer))
        ActiveStateCollection1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        ActiveStateCollection1.HoverColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer))
        ActiveStateCollection1.Text = "SI"
        Me.ToggleButton1.ActiveState = ActiveStateCollection1
        Me.ToggleButton1.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.ToggleButton1.ForeColor = System.Drawing.Color.Black
        InactiveStateCollection1.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer))
        InactiveStateCollection1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        InactiveStateCollection1.ForeColor = System.Drawing.Color.White
        InactiveStateCollection1.HoverColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer))
        InactiveStateCollection1.Text = "NO"
        Me.ToggleButton1.InactiveState = InactiveStateCollection1
        Me.ToggleButton1.Location = New System.Drawing.Point(139, 153)
        Me.ToggleButton1.MinimumSize = New System.Drawing.Size(52, 20)
        Me.ToggleButton1.Name = "ToggleButton1"
        Me.ToggleButton1.Renderer = ToggleButtonRenderer1
        Me.ToggleButton1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ToggleButton1.Size = New System.Drawing.Size(69, 20)
        SliderCollection1.BackColor = System.Drawing.Color.White
        SliderCollection1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        SliderCollection1.ForeColor = System.Drawing.Color.White
        SliderCollection1.HoverColor = System.Drawing.Color.FromArgb(CType(CType(8, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(171, Byte), Integer))
        SliderCollection1.Width = 30
        Me.ToggleButton1.Slider = SliderCollection1
        Me.ToggleButton1.TabIndex = 438
        Me.ToggleButton1.Text = "Button1"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(248, 382)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(11, 13)
        Me.Label9.TabIndex = 437
        Me.Label9.Text = "-"
        Me.Label9.Visible = False
        '
        'cboObjetoContratacion
        '
        Me.cboObjetoContratacion.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cboObjetoContratacion.FormattingEnabled = True
        Me.cboObjetoContratacion.Items.AddRange(New Object() {"DIARIO", "SEMANAL", "QUINCENAL", "MENSUAL", "BIMESTRAL", "TRIMESTRAL", "SEMESTRAL", "ANUAL", "OTROS"})
        Me.cboObjetoContratacion.Location = New System.Drawing.Point(139, 61)
        Me.cboObjetoContratacion.Name = "cboObjetoContratacion"
        Me.cboObjetoContratacion.Size = New System.Drawing.Size(179, 21)
        Me.cboObjetoContratacion.TabIndex = 436
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(250, 353)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(29, 13)
        Me.Label7.TabIndex = 435
        Me.Label7.Text = "ME.:"
        Me.Label7.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(247, 327)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 13)
        Me.Label5.TabIndex = 434
        Me.Label5.Text = " ME.:"
        Me.Label5.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(253, 122)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 433
        Me.Label2.Text = "ME.:"
        Me.Label2.Visible = False
        '
        'nudDetraccion
        '
        Me.nudDetraccion.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.nudDetraccion.BeforeTouchSize = New System.Drawing.Size(73, 23)
        Me.nudDetraccion.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.nudDetraccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nudDetraccion.DecimalPlaces = 2
        Me.nudDetraccion.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudDetraccion.Location = New System.Drawing.Point(171, 377)
        Me.nudDetraccion.Maximum = New Decimal(New Integer() {268435456, 1042612833, 542101086, 0})
        Me.nudDetraccion.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.nudDetraccion.Name = "nudDetraccion"
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
        Me.txtFondoGarantia.Location = New System.Drawing.Point(136, 348)
        Me.txtFondoGarantia.Maximum = New Decimal(New Integer() {268435456, 1042612833, 542101086, 0})
        Me.txtFondoGarantia.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFondoGarantia.Name = "txtFondoGarantia"
        Me.txtFondoGarantia.Size = New System.Drawing.Size(96, 23)
        Me.txtFondoGarantia.TabIndex = 431
        Me.txtFondoGarantia.TabStop = False
        Me.txtFondoGarantia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtFondoGarantia.ThousandsSeparator = True
        Me.txtFondoGarantia.Visible = False
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
        Me.txtAdelanto.Location = New System.Drawing.Point(136, 319)
        Me.txtAdelanto.Maximum = New Decimal(New Integer() {268435456, 1042612833, 542101086, 0})
        Me.txtAdelanto.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtAdelanto.Name = "txtAdelanto"
        Me.txtAdelanto.Size = New System.Drawing.Size(96, 23)
        Me.txtAdelanto.TabIndex = 430
        Me.txtAdelanto.TabStop = False
        Me.txtAdelanto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtAdelanto.ThousandsSeparator = True
        Me.txtAdelanto.Visible = False
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
        Me.nudDetraccionME.Location = New System.Drawing.Point(263, 377)
        Me.nudDetraccionME.Maximum = New Decimal(New Integer() {268435456, 1042612833, 542101086, 0})
        Me.nudDetraccionME.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.nudDetraccionME.Name = "nudDetraccionME"
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
        Me.txtFondoGarantiaME.Location = New System.Drawing.Point(285, 348)
        Me.txtFondoGarantiaME.Maximum = New Decimal(New Integer() {268435456, 1042612833, 542101086, 0})
        Me.txtFondoGarantiaME.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFondoGarantiaME.Name = "txtFondoGarantiaME"
        Me.txtFondoGarantiaME.Size = New System.Drawing.Size(96, 23)
        Me.txtFondoGarantiaME.TabIndex = 428
        Me.txtFondoGarantiaME.TabStop = False
        Me.txtFondoGarantiaME.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtFondoGarantiaME.ThousandsSeparator = True
        Me.txtFondoGarantiaME.Visible = False
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
        Me.txtAdelantoME.Location = New System.Drawing.Point(285, 319)
        Me.txtAdelantoME.Maximum = New Decimal(New Integer() {268435456, 1042612833, 542101086, 0})
        Me.txtAdelantoME.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtAdelantoME.Name = "txtAdelantoME"
        Me.txtAdelantoME.Size = New System.Drawing.Size(96, 23)
        Me.txtAdelantoME.TabIndex = 427
        Me.txtAdelantoME.TabStop = False
        Me.txtAdelantoME.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtAdelantoME.ThousandsSeparator = True
        Me.txtAdelantoME.Visible = False
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
        Me.txtImporteContratacionME.Location = New System.Drawing.Point(288, 115)
        Me.txtImporteContratacionME.Maximum = New Decimal(New Integer() {268435456, 1042612833, 542101086, 0})
        Me.txtImporteContratacionME.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtImporteContratacionME.Name = "txtImporteContratacionME"
        Me.txtImporteContratacionME.Size = New System.Drawing.Size(96, 23)
        Me.txtImporteContratacionME.TabIndex = 426
        Me.txtImporteContratacionME.TabStop = False
        Me.txtImporteContratacionME.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtImporteContratacionME.ThousandsSeparator = True
        Me.txtImporteContratacionME.Visible = False
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
        Me.txtImporteContratacion.Location = New System.Drawing.Point(139, 115)
        Me.txtImporteContratacion.Maximum = New Decimal(New Integer() {268435456, 1042612833, 542101086, 0})
        Me.txtImporteContratacion.MetroColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtImporteContratacion.Name = "txtImporteContratacion"
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
        Me.Label1.Location = New System.Drawing.Point(12, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 13)
        Me.Label1.TabIndex = 418
        Me.Label1.Text = "Nombre de entregable:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.fechainicio)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.fechafin)
        Me.GroupBox2.ForeColor = System.Drawing.Color.SteelBlue
        Me.GroupBox2.Location = New System.Drawing.Point(15, 207)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(369, 72)
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
        Me.Label3.Size = New System.Drawing.Size(42, 13)
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
        Me.fechainicio.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.fechainicio.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.fechainicio.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.fechainicio.Calendar.DayNamesColor = System.Drawing.Color.Empty
        Me.fechainicio.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
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
        Me.fechainicio.Calendar.NoneButton.Location = New System.Drawing.Point(78, 0)
        Me.fechainicio.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
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
        Me.fechainicio.Calendar.TodayButton.Size = New System.Drawing.Size(78, 20)
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
        Me.fechafin.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.fechafin.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.fechafin.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.fechafin.Calendar.DayNamesColor = System.Drawing.Color.Empty
        Me.fechafin.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
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
        Me.fechafin.Calendar.NoneButton.Location = New System.Drawing.Point(78, 0)
        Me.fechafin.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
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
        Me.fechafin.Calendar.TodayButton.Size = New System.Drawing.Size(78, 20)
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
        Me.fechafin.ShowCheckBox = False
        Me.fechafin.Size = New System.Drawing.Size(152, 20)
        Me.fechafin.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.fechafin.TabIndex = 253
        Me.fechafin.Value = New Date(2015, 9, 18, 8, 21, 31, 962)
        '
        'tbDetraccion
        '
        ActiveStateCollection2.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer))
        ActiveStateCollection2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        ActiveStateCollection2.HoverColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer))
        ActiveStateCollection2.Text = "SI"
        Me.tbDetraccion.ActiveState = ActiveStateCollection2
        Me.tbDetraccion.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.tbDetraccion.ForeColor = System.Drawing.Color.Black
        InactiveStateCollection2.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(34, Byte), Integer))
        InactiveStateCollection2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        InactiveStateCollection2.ForeColor = System.Drawing.Color.White
        InactiveStateCollection2.HoverColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(71, Byte), Integer))
        InactiveStateCollection2.Text = "NO"
        Me.tbDetraccion.InactiveState = InactiveStateCollection2
        Me.tbDetraccion.Location = New System.Drawing.Point(138, 181)
        Me.tbDetraccion.MinimumSize = New System.Drawing.Size(52, 20)
        Me.tbDetraccion.Name = "tbDetraccion"
        Me.tbDetraccion.Renderer = ToggleButtonRenderer2
        Me.tbDetraccion.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tbDetraccion.Size = New System.Drawing.Size(69, 20)
        SliderCollection2.BackColor = System.Drawing.Color.White
        SliderCollection2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        SliderCollection2.ForeColor = System.Drawing.Color.White
        SliderCollection2.HoverColor = System.Drawing.Color.FromArgb(CType(CType(8, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(171, Byte), Integer))
        SliderCollection2.Width = 30
        Me.tbDetraccion.Slider = SliderCollection2
        Me.tbDetraccion.TabIndex = 415
        Me.tbDetraccion.Text = "Button1"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(8, 39)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(130, 13)
        Me.Label6.TabIndex = 403
        Me.Label6.Text = "Objeto de contratación:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(56, 181)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 13)
        Me.Label4.TabIndex = 402
        Me.Label4.Text = "Detracciones:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(1, 122)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(136, 13)
        Me.Label8.TabIndex = 405
        Me.Label8.Text = "Importe de Contratación:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(9, 64)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(131, 13)
        Me.Label12.TabIndex = 406
        Me.Label12.Text = "Periodo de Valorizacion:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(51, 327)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(81, 13)
        Me.Label13.TabIndex = 408
        Me.Label13.Text = "Adelanto MN.:"
        Me.Label13.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(40, 153)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(94, 13)
        Me.Label14.TabIndex = 409
        Me.Label14.Text = "Fondo Garantia.:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(62, 91)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(72, 13)
        Me.Label15.TabIndex = 410
        Me.Label15.Text = "Penalidades:"
        '
        'txtDetracciones
        '
        Me.txtDetracciones.Location = New System.Drawing.Point(0, 0)
        Me.txtDetracciones.Name = "txtDetracciones"
        Me.txtDetracciones.Size = New System.Drawing.Size(100, 19)
        Me.txtDetracciones.TabIndex = 0
        '
        'txtFGarantia
        '
        Me.txtFGarantia.Location = New System.Drawing.Point(0, 0)
        Me.txtFGarantia.Name = "txtFGarantia"
        Me.txtFGarantia.Size = New System.Drawing.Size(100, 19)
        Me.txtFGarantia.TabIndex = 0
        '
        'txtNombreEntregable
        '
        Me.txtNombreEntregable.Location = New System.Drawing.Point(0, 0)
        Me.txtNombreEntregable.Name = "txtNombreEntregable"
        Me.txtNombreEntregable.Size = New System.Drawing.Size(100, 19)
        Me.txtNombreEntregable.TabIndex = 0
        '
        'txtContra
        '
        Me.txtContra.Location = New System.Drawing.Point(0, 0)
        Me.txtContra.Name = "txtContra"
        Me.txtContra.Size = New System.Drawing.Size(100, 19)
        Me.txtContra.TabIndex = 0
        '
        'txtPenalidades
        '
        Me.txtPenalidades.Location = New System.Drawing.Point(0, 0)
        Me.txtPenalidades.Name = "txtPenalidades"
        Me.txtPenalidades.Size = New System.Drawing.Size(100, 19)
        Me.txtPenalidades.TabIndex = 0
        '
        'PanelError
        '
        Me.PanelError.BackColor = System.Drawing.Color.Maroon
        Me.PanelError.Controls.Add(Me.PictureBox3)
        Me.PanelError.Controls.Add(Me.lblEstado)
        Me.PanelError.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelError.Location = New System.Drawing.Point(0, 45)
        Me.PanelError.Name = "PanelError"
        Me.PanelError.Size = New System.Drawing.Size(958, 22)
        Me.PanelError.TabIndex = 448
        Me.PanelError.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(939, 0)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(19, 22)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 288
        Me.PictureBox3.TabStop = False
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.BackColor = System.Drawing.Color.Transparent
        Me.lblEstado.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.Color.White
        Me.lblEstado.Location = New System.Drawing.Point(9, 4)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(79, 13)
        Me.lblEstado.TabIndex = 0
        Me.lblEstado.Text = "Mensaje error"
        '
        'Panel17
        '
        Me.Panel17.Controls.Add(Me.ToolStrip5)
        Me.Panel17.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel17.Location = New System.Drawing.Point(0, 0)
        Me.Panel17.Name = "Panel17"
        Me.Panel17.Size = New System.Drawing.Size(958, 45)
        Me.Panel17.TabIndex = 447
        '
        'ToolStrip5
        '
        Me.ToolStrip5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ToolStrip5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStrip5.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip5.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip5.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1})
        Me.ToolStrip5.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip5.Name = "ToolStrip5"
        Me.ToolStrip5.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip5.Size = New System.Drawing.Size(958, 45)
        Me.ToolStrip5.TabIndex = 1
        Me.ToolStrip5.Text = "ToolStrip5"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(74, 42)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        Me.ToolStripButton1.Visible = False
        '
        'lblPerido
        '
        Me.lblPerido.BackColor = System.Drawing.Color.Transparent
        Me.lblPerido.Font = New System.Drawing.Font("Segoe UI Semibold", 8.0!)
        Me.lblPerido.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblPerido.Image = CType(resources.GetObject("lblPerido.Image"), System.Drawing.Image)
        Me.lblPerido.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblPerido.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.lblPerido.Name = "lblPerido"
        Me.lblPerido.Size = New System.Drawing.Size(115, 42)
        Me.lblPerido.Text = "Período: 2017"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.GradientPanel4)
        Me.Panel4.Controls.Add(Me.GradientPanel3)
        Me.Panel4.Controls.Add(Me.GradientPanel1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 67)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(958, 112)
        Me.Panel4.TabIndex = 450
        '
        'GradientPanel4
        '
        Me.GradientPanel4.BackgroundColor = New Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.PatternStyle.Weave, System.Drawing.Color.White, System.Drawing.Color.White)
        Me.GradientPanel4.BorderColor = System.Drawing.Color.Gainsboro
        Me.GradientPanel4.BorderSingle = System.Windows.Forms.ButtonBorderStyle.Dotted
        Me.GradientPanel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel4.Controls.Add(Me.txtMoneda)
        Me.GradientPanel4.Controls.Add(Me.Label11)
        Me.GradientPanel4.Controls.Add(Me.TextBoxExt1)
        Me.GradientPanel4.Controls.Add(Me.TextBoxExt2)
        Me.GradientPanel4.Controls.Add(Me.Label18)
        Me.GradientPanel4.Location = New System.Drawing.Point(628, 6)
        Me.GradientPanel4.Name = "GradientPanel4"
        Me.GradientPanel4.Size = New System.Drawing.Size(193, 97)
        Me.GradientPanel4.TabIndex = 19
        '
        'txtMoneda
        '
        Me.txtMoneda.BackColor = System.Drawing.Color.White
        Me.txtMoneda.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtMoneda.BorderColor = System.Drawing.Color.Silver
        Me.txtMoneda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMoneda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMoneda.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMoneda.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtMoneda.Location = New System.Drawing.Point(32, 66)
        Me.txtMoneda.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtMoneda.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtMoneda.Name = "txtMoneda"
        Me.txtMoneda.NearImage = CType(resources.GetObject("txtMoneda.NearImage"), System.Drawing.Image)
        Me.txtMoneda.Size = New System.Drawing.Size(151, 22)
        Me.txtMoneda.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtMoneda.TabIndex = 501
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.DimGray
        Me.Label11.Location = New System.Drawing.Point(15, 13)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(120, 14)
        Me.Label11.TabIndex = 500
        Me.Label11.Text = "Información adicional"
        '
        'TextBoxExt1
        '
        Me.TextBoxExt1.BackColor = System.Drawing.Color.White
        Me.TextBoxExt1.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TextBoxExt1.BorderColor = System.Drawing.Color.Silver
        Me.TextBoxExt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxExt1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBoxExt1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxExt1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextBoxExt1.Location = New System.Drawing.Point(127, 182)
        Me.TextBoxExt1.MaxLength = 20
        Me.TextBoxExt1.Metrocolor = System.Drawing.Color.YellowGreen
        Me.TextBoxExt1.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextBoxExt1.Name = "TextBoxExt1"
        Me.TextBoxExt1.Size = New System.Drawing.Size(174, 20)
        Me.TextBoxExt1.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextBoxExt1.TabIndex = 215
        Me.TextBoxExt1.Visible = False
        '
        'TextBoxExt2
        '
        Me.TextBoxExt2.BackColor = System.Drawing.Color.White
        Me.TextBoxExt2.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.TextBoxExt2.BorderColor = System.Drawing.Color.Silver
        Me.TextBoxExt2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxExt2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBoxExt2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxExt2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextBoxExt2.Location = New System.Drawing.Point(20, 182)
        Me.TextBoxExt2.MaxLength = 10
        Me.TextBoxExt2.Metrocolor = System.Drawing.Color.YellowGreen
        Me.TextBoxExt2.MinimumSize = New System.Drawing.Size(14, 10)
        Me.TextBoxExt2.Name = "TextBoxExt2"
        Me.TextBoxExt2.Size = New System.Drawing.Size(101, 20)
        Me.TextBoxExt2.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.TextBoxExt2.TabIndex = 4
        Me.TextBoxExt2.Visible = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.DimGray
        Me.Label18.Location = New System.Drawing.Point(29, 44)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(50, 14)
        Me.Label18.TabIndex = 497
        Me.Label18.Text = "Moneda"
        '
        'GradientPanel3
        '
        Me.GradientPanel3.BackgroundColor = New Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.PatternStyle.Weave, System.Drawing.Color.White, System.Drawing.Color.White)
        Me.GradientPanel3.BorderColor = System.Drawing.Color.Gainsboro
        Me.GradientPanel3.BorderSingle = System.Windows.Forms.ButtonBorderStyle.Dotted
        Me.GradientPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel3.Controls.Add(Me.Label19)
        Me.GradientPanel3.Controls.Add(Me.popupControlContainer1)
        Me.GradientPanel3.Controls.Add(Me.txtRuc)
        Me.GradientPanel3.Controls.Add(Me.txtProveedorServicio)
        Me.GradientPanel3.Location = New System.Drawing.Point(280, 6)
        Me.GradientPanel3.Name = "GradientPanel3"
        Me.GradientPanel3.Size = New System.Drawing.Size(342, 97)
        Me.GradientPanel3.TabIndex = 18
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.DimGray
        Me.Label19.Location = New System.Drawing.Point(16, 13)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(151, 14)
        Me.Label19.TabIndex = 496
        Me.Label19.Text = "Información del Proveedor"
        '
        'popupControlContainer1
        '
        Me.popupControlContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.popupControlContainer1.Controls.Add(Me.lsvProveedor)
        Me.popupControlContainer1.Controls.Add(Me.cancel)
        Me.popupControlContainer1.Controls.Add(Me.OK)
        Me.popupControlContainer1.Location = New System.Drawing.Point(366, 99)
        Me.popupControlContainer1.Name = "popupControlContainer1"
        Me.popupControlContainer1.Size = New System.Drawing.Size(279, 147)
        Me.popupControlContainer1.TabIndex = 494
        Me.popupControlContainer1.Visible = False
        '
        'lsvProveedor
        '
        Me.lsvProveedor.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lsvProveedor.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lsvProveedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvProveedor.FullRowSelect = True
        Me.lsvProveedor.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lsvProveedor.Location = New System.Drawing.Point(0, 0)
        Me.lsvProveedor.MultiSelect = False
        Me.lsvProveedor.Name = "lsvProveedor"
        Me.lsvProveedor.Size = New System.Drawing.Size(277, 145)
        Me.lsvProveedor.TabIndex = 3
        Me.lsvProveedor.UseCompatibleStateImageBehavior = False
        Me.lsvProveedor.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "IdProveedor"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Proveedor"
        Me.ColumnHeader2.Width = 250
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Cuenta"
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Numero"
        '
        'cancel
        '
        Me.cancel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cancel.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.cancel.BackColor = System.Drawing.SystemColors.Highlight
        Me.cancel.BeforeTouchSize = New System.Drawing.Size(60, 21)
        Me.cancel.ForeColor = System.Drawing.Color.White
        Me.cancel.IsBackStageButton = False
        Me.cancel.Location = New System.Drawing.Point(65, 120)
        Me.cancel.Name = "cancel"
        Me.cancel.Size = New System.Drawing.Size(60, 21)
        Me.cancel.TabIndex = 2
        Me.cancel.Text = "Cancel"
        Me.cancel.UseVisualStyle = True
        '
        'OK
        '
        Me.OK.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OK.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.OK.BackColor = System.Drawing.SystemColors.Highlight
        Me.OK.BeforeTouchSize = New System.Drawing.Size(59, 21)
        Me.OK.ForeColor = System.Drawing.Color.White
        Me.OK.IsBackStageButton = False
        Me.OK.Location = New System.Drawing.Point(5, 120)
        Me.OK.Name = "OK"
        Me.OK.Size = New System.Drawing.Size(59, 21)
        Me.OK.TabIndex = 1
        Me.OK.Text = "OK"
        Me.OK.UseVisualStyle = True
        '
        'txtRuc
        '
        Me.txtRuc.BackColor = System.Drawing.Color.White
        Me.txtRuc.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtRuc.BorderColor = System.Drawing.Color.Silver
        Me.txtRuc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRuc.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRuc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtRuc.Location = New System.Drawing.Point(19, 70)
        Me.txtRuc.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtRuc.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtRuc.Name = "txtRuc"
        Me.txtRuc.NearImage = CType(resources.GetObject("txtRuc.NearImage"), System.Drawing.Image)
        Me.txtRuc.Size = New System.Drawing.Size(153, 22)
        Me.txtRuc.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtRuc.TabIndex = 218
        Me.txtRuc.Visible = False
        '
        'txtProveedorServicio
        '
        Me.txtProveedorServicio.BackColor = System.Drawing.Color.White
        Me.txtProveedorServicio.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtProveedorServicio.BorderColor = System.Drawing.Color.Silver
        Me.txtProveedorServicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProveedorServicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProveedorServicio.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtProveedorServicio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtProveedorServicio.Location = New System.Drawing.Point(19, 41)
        Me.txtProveedorServicio.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtProveedorServicio.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtProveedorServicio.Name = "txtProveedorServicio"
        Me.txtProveedorServicio.NearImage = CType(resources.GetObject("txtProveedorServicio.NearImage"), System.Drawing.Image)
        Me.txtProveedorServicio.Size = New System.Drawing.Size(315, 22)
        Me.txtProveedorServicio.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtProveedorServicio.TabIndex = 216
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BackgroundColor = New Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.PatternStyle.Weave, System.Drawing.Color.White, System.Drawing.Color.White)
        Me.GradientPanel1.BorderColor = System.Drawing.Color.Gainsboro
        Me.GradientPanel1.BorderSingle = System.Windows.Forms.ButtonBorderStyle.Dotted
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.txtNumero)
        Me.GradientPanel1.Controls.Add(Me.Label30)
        Me.GradientPanel1.Controls.Add(Me.cboTipoDoc)
        Me.GradientPanel1.Controls.Add(Me.txtSerie)
        Me.GradientPanel1.Controls.Add(Me.txtFecha)
        Me.GradientPanel1.Location = New System.Drawing.Point(12, 6)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(266, 97)
        Me.GradientPanel1.TabIndex = 17
        '
        'txtNumero
        '
        Me.txtNumero.BackColor = System.Drawing.Color.White
        Me.txtNumero.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtNumero.BorderColor = System.Drawing.Color.Silver
        Me.txtNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumero.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNumero.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumero.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtNumero.Location = New System.Drawing.Point(127, 182)
        Me.txtNumero.MaxLength = 20
        Me.txtNumero.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtNumero.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(174, 20)
        Me.txtNumero.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtNumero.TabIndex = 215
        Me.txtNumero.Visible = False
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.DimGray
        Me.Label30.Location = New System.Drawing.Point(17, 13)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(169, 14)
        Me.Label30.TabIndex = 495
        Me.Label30.Text = "Información del Comprobante"
        '
        'cboTipoDoc
        '
        Me.cboTipoDoc.BackColor = System.Drawing.Color.White
        Me.cboTipoDoc.BeforeTouchSize = New System.Drawing.Size(240, 21)
        Me.cboTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoDoc.Enabled = False
        Me.cboTipoDoc.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoDoc.Items.AddRange(New Object() {"ORDEN DE COMPRA"})
        Me.cboTipoDoc.ItemsImageIndexes.Add(New Syncfusion.Windows.Forms.Tools.ComboBoxAdv.ImageIndexItem(Me.cboTipoDoc, "ORDEN DE COMPRA"))
        Me.cboTipoDoc.Location = New System.Drawing.Point(21, 71)
        Me.cboTipoDoc.MetroBorderColor = System.Drawing.Color.Silver
        Me.cboTipoDoc.Name = "cboTipoDoc"
        Me.cboTipoDoc.Size = New System.Drawing.Size(240, 21)
        Me.cboTipoDoc.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboTipoDoc.TabIndex = 213
        Me.cboTipoDoc.Text = "ORDEN DE COMPRA"
        '
        'txtSerie
        '
        Me.txtSerie.BackColor = System.Drawing.Color.White
        Me.txtSerie.BeforeTouchSize = New System.Drawing.Size(100, 20)
        Me.txtSerie.BorderColor = System.Drawing.Color.Silver
        Me.txtSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSerie.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSerie.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerie.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtSerie.Location = New System.Drawing.Point(20, 182)
        Me.txtSerie.MaxLength = 10
        Me.txtSerie.Metrocolor = System.Drawing.Color.YellowGreen
        Me.txtSerie.MinimumSize = New System.Drawing.Size(14, 10)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(101, 20)
        Me.txtSerie.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtSerie.TabIndex = 4
        Me.txtSerie.Visible = False
        '
        'txtFecha
        '
        Me.txtFecha.BackColor = System.Drawing.Color.DarkGoldenrod
        Me.txtFecha.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.txtFecha.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.txtFecha.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtFecha.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFecha.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFecha.Calendar.DayNamesColor = System.Drawing.Color.Empty
        Me.txtFecha.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtFecha.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFecha.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.txtFecha.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.txtFecha.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.txtFecha.Calendar.HighlightColor = System.Drawing.Color.White
        Me.txtFecha.Calendar.Iso8601CalenderFormat = False
        Me.txtFecha.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.txtFecha.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecha.Calendar.Name = "monthCalendar"
        Me.txtFecha.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.txtFecha.Calendar.SelectedDates = New Date(-1) {}
        Me.txtFecha.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFecha.Calendar.TabIndex = 0
        Me.txtFecha.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.txtFecha.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFecha.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecha.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFecha.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.txtFecha.Calendar.NoneButton.IsBackStageButton = False
        Me.txtFecha.Calendar.NoneButton.Location = New System.Drawing.Point(78, 0)
        Me.txtFecha.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.txtFecha.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.txtFecha.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.txtFecha.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecha.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.txtFecha.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.txtFecha.Calendar.TodayButton.IsBackStageButton = False
        Me.txtFecha.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.txtFecha.Calendar.TodayButton.Size = New System.Drawing.Size(78, 20)
        Me.txtFecha.Calendar.TodayButton.UseVisualStyle = True
        Me.txtFecha.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha.CalendarForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFecha.CalendarSize = New System.Drawing.Size(189, 176)
        Me.txtFecha.Checked = False
        Me.txtFecha.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.txtFecha.CustomFormat = "dd/MM/yyyy HH:mm:ss tt"
        Me.txtFecha.DropDownImage = Nothing
        Me.txtFecha.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecha.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecha.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.txtFecha.ForeColor = System.Drawing.Color.White
        Me.txtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtFecha.Location = New System.Drawing.Point(20, 38)
        Me.txtFecha.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFecha.MinValue = New Date(CType(0, Long))
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ShowCheckBox = False
        Me.txtFecha.ShowDropButton = False
        Me.txtFecha.Size = New System.Drawing.Size(133, 20)
        Me.txtFecha.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFecha.TabIndex = 1
        Me.txtFecha.Value = New Date(2017, 1, 13, 16, 41, 14, 288)
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.ToolStrip2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 179)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(958, 32)
        Me.Panel2.TabIndex = 451
        '
        'ToolStrip2
        '
        Me.ToolStrip2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStrip2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton2})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip2.Size = New System.Drawing.Size(958, 32)
        Me.ToolStrip2.TabIndex = 16
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(34, 29)
        Me.ToolStripButton2.Text = "ToolStripButton2"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(50, 29)
        Me.ToolStripLabel1.Text = "Entrega:"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 32)
        '
        'tsbDetallesEntrega
        '
        Me.tsbDetallesEntrega.BackColor = System.Drawing.Color.Red
        Me.tsbDetallesEntrega.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbDetallesEntrega.ForeColor = System.Drawing.Color.White
        Me.tsbDetallesEntrega.Image = CType(resources.GetObject("tsbDetallesEntrega.Image"), System.Drawing.Image)
        Me.tsbDetallesEntrega.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbDetallesEntrega.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDetallesEntrega.Name = "tsbDetallesEntrega"
        Me.tsbDetallesEntrega.Size = New System.Drawing.Size(34, 29)
        Me.tsbDetallesEntrega.Text = "Detalle"
        '
        'frmDetalleOrdenServicio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.Color.Maroon
        Me.CaptionBarHeight = 55
        CaptionImage1.Location = New System.Drawing.Point(30, 10)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(35, 35)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.White
        CaptionLabel1.Location = New System.Drawing.Point(70, 10)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(400, 40)
        CaptionLabel1.Text = "DETALLES DE ORDEN DE SERVICIO"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(958, 484)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.PanelError)
        Me.Controls.Add(Me.Panel17)
        Me.MetroColor = System.Drawing.Color.Maroon
        Me.Name = "frmDetalleOrdenServicio"
        Me.ShowIcon = False
        Me.Text = ""
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvServicio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.ToggleButton1, System.ComponentModel.ISupportInitialize).EndInit()
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
        Me.PanelError.ResumeLayout(False)
        Me.PanelError.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel17.ResumeLayout(False)
        Me.Panel17.PerformLayout()
        Me.ToolStrip5.ResumeLayout(False)
        Me.ToolStrip5.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        CType(Me.GradientPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel4.ResumeLayout(False)
        Me.GradientPanel4.PerformLayout()
        CType(Me.txtMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxExt1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxExt2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel3.ResumeLayout(False)
        Me.GradientPanel3.PerformLayout()
        Me.popupControlContainer1.ResumeLayout(False)
        CType(Me.txtRuc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProveedorServicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        CType(Me.txtNumero, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTipoDoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSerie, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents tbDetraccion As Syncfusion.Windows.Forms.Tools.ToggleButton
    Friend WithEvents ToolStrip5 As System.Windows.Forms.ToolStrip
    Friend WithEvents dgvServicio As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl
    Private WithEvents ToggleButton1 As Syncfusion.Windows.Forms.Tools.ToggleButton
    Private WithEvents GradientPanel4 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Private WithEvents GradientPanel3 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Private WithEvents popupControlContainer1 As Syncfusion.Windows.Forms.PopupControlContainer
    Private WithEvents cancel As Syncfusion.Windows.Forms.ButtonAdv
    Private WithEvents OK As Syncfusion.Windows.Forms.ButtonAdv
    Private WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Private WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Private WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents fechainicio As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Private WithEvents Label10 As System.Windows.Forms.Label
    Private WithEvents fechafin As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Private WithEvents Label6 As System.Windows.Forms.Label
    Private WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents txtContra As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Private WithEvents Label8 As System.Windows.Forms.Label
    Private WithEvents Label12 As System.Windows.Forms.Label
    Private WithEvents Label13 As System.Windows.Forms.Label
    Private WithEvents txtPenalidades As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Private WithEvents Label14 As System.Windows.Forms.Label
    Private WithEvents Label15 As System.Windows.Forms.Label
    Private WithEvents PanelError As System.Windows.Forms.Panel
    Private WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Private WithEvents lblEstado As System.Windows.Forms.Label
    Private WithEvents Panel17 As System.Windows.Forms.Panel
    Private WithEvents Panel1 As System.Windows.Forms.Panel
    Private WithEvents Timer1 As System.Windows.Forms.Timer
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents txtNombreEntregable As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Private WithEvents txtImporteContratacion As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Private WithEvents txtImporteContratacionME As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Private WithEvents txtAdelanto As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Private WithEvents nudDetraccionME As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Private WithEvents txtFondoGarantiaME As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Private WithEvents txtAdelantoME As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Private WithEvents txtFondoGarantia As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Private WithEvents nudDetraccion As Syncfusion.Windows.Forms.Tools.NumericUpDownExt
    Private WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents cboObjetoContratacion As System.Windows.Forms.ComboBox
    Private WithEvents Label7 As System.Windows.Forms.Label
    Private WithEvents Label5 As System.Windows.Forms.Label
    Private WithEvents Label9 As System.Windows.Forms.Label
    Private WithEvents lblPerido As System.Windows.Forms.ToolStripLabel
    Private WithEvents lblDetracciones As System.Windows.Forms.Label
    Private WithEvents lblFGarantia As System.Windows.Forms.Label
    Private WithEvents txtDetracciones As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Private WithEvents txtFGarantia As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Private WithEvents Panel4 As System.Windows.Forms.Panel
    Private WithEvents Label11 As System.Windows.Forms.Label
    Private WithEvents TextBoxExt1 As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Private WithEvents TextBoxExt2 As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Private WithEvents Label18 As System.Windows.Forms.Label
    Private WithEvents Label19 As System.Windows.Forms.Label
    Private WithEvents lsvProveedor As System.Windows.Forms.ListView
    Private WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Private WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Private WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Private WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Private WithEvents txtNumero As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Private WithEvents Label30 As System.Windows.Forms.Label
    Private WithEvents txtSerie As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Private WithEvents Panel2 As System.Windows.Forms.Panel
    Private WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Private WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Private WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents tsbDetallesEntrega As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtRuc As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents cboTipoDoc As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents txtFecha As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents txtMoneda As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtProveedorServicio As Syncfusion.Windows.Forms.Tools.TextBoxExt
End Class

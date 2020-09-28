<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLibroDiarioMaster
    Inherits Qios.DevSuite.Components.Ribbon.QRibbonForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLibroDiarioMaster))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.lblEstado = New System.Windows.Forms.ToolStripButton()
        Me.QRibbonCaption1 = New Qios.DevSuite.Components.Ribbon.QRibbonCaption()
        Me.ExpandCollapsePanel1 = New MakarovDev.ExpandCollapsePanel.ExpandCollapsePanel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.QComboBox1 = New Qios.DevSuite.Components.QComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtpPeriodoMes = New System.Windows.Forms.DateTimePicker()
        Me.dtpPeriodoAnio = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.txtFechaFin = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.txtidProveedor = New System.Windows.Forms.TextBox()
        Me.LinkTipoDoc = New System.Windows.Forms.LinkLabel()
        Me.txtDocumento = New System.Windows.Forms.TextBox()
        Me.txtComprobante = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtProveedor = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LinkProveedor = New System.Windows.Forms.LinkLabel()
        Me.txtIdComprobante = New System.Windows.Forms.TextBox()
        Me.dgvLibroAsiento = New System.Windows.Forms.DataGridView()
        Me.idAsiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idDocumento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idAlmacen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NombreAlmacen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idEntidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombreEntidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaProceso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tipoAsiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImporteMN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.importeME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.glosario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgvMovimiento = New System.Windows.Forms.DataGridView()
        Me.AsientoID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCuenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDescripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDebHAber = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.colImporteMNDebe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colImporteMEDebe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHaberMN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHaberME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMovimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.QRibbonCaption1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExpandCollapsePanel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvLibroAsiento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvMovimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ToolStrip1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblEstado})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 28)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(661, 25)
        Me.ToolStrip1.TabIndex = 46
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'lblEstado
        '
        Me.lblEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblEstado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(44, 22)
        Me.lblEstado.Text = "Estado"
        '
        'QRibbonCaption1
        '
        Me.QRibbonCaption1.Location = New System.Drawing.Point(0, 0)
        Me.QRibbonCaption1.Name = "QRibbonCaption1"
        Me.QRibbonCaption1.Size = New System.Drawing.Size(661, 28)
        Me.QRibbonCaption1.TabIndex = 45
        Me.QRibbonCaption1.Text = "Libro Diario"
        '
        'ExpandCollapsePanel1
        '
        Me.ExpandCollapsePanel1.BackColor = System.Drawing.Color.Transparent
        Me.ExpandCollapsePanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ExpandCollapsePanel1.ButtonSize = MakarovDev.ExpandCollapsePanel.ExpandCollapseButton.ExpandButtonSize.Normal
        Me.ExpandCollapsePanel1.ButtonStyle = MakarovDev.ExpandCollapsePanel.ExpandCollapseButton.ExpandButtonStyle.Circle
        Me.ExpandCollapsePanel1.Controls.Add(Me.GroupBox2)
        Me.ExpandCollapsePanel1.Controls.Add(Me.GroupBox1)
        Me.ExpandCollapsePanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ExpandCollapsePanel1.ExpandedHeight = 0
        Me.ExpandCollapsePanel1.IsExpanded = True
        Me.ExpandCollapsePanel1.Location = New System.Drawing.Point(0, 53)
        Me.ExpandCollapsePanel1.Name = "ExpandCollapsePanel1"
        Me.ExpandCollapsePanel1.Size = New System.Drawing.Size(661, 174)
        Me.ExpandCollapsePanel1.TabIndex = 48
        Me.ExpandCollapsePanel1.Text = "Buscar:"
        Me.ExpandCollapsePanel1.UseAnimation = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.QComboBox1)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(39, 36)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(616, 39)
        Me.GroupBox2.TabIndex = 42
        Me.GroupBox2.TabStop = False
        '
        'QComboBox1
        '
        Me.QComboBox1.Items.AddRange(New Object() {"Documento", "Entidad", "Código Libro", "Fecha Progreso", "Período"})
        Me.QComboBox1.Location = New System.Drawing.Point(82, 14)
        Me.QComboBox1.Name = "QComboBox1"
        Me.QComboBox1.SelectedIndex = 0
        Me.QComboBox1.SelectedItem = "Documento"
        Me.QComboBox1.Size = New System.Drawing.Size(228, 21)
        Me.QComboBox1.TabIndex = 37
        Me.QComboBox1.Text = "Documento"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 15)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "Buscar por:"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.dtpPeriodoMes)
        Me.GroupBox1.Controls.Add(Me.dtpPeriodoAnio)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.btnBuscar)
        Me.GroupBox1.Controls.Add(Me.txtidProveedor)
        Me.GroupBox1.Controls.Add(Me.LinkTipoDoc)
        Me.GroupBox1.Controls.Add(Me.txtDocumento)
        Me.GroupBox1.Controls.Add(Me.txtComprobante)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtProveedor)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.LinkProveedor)
        Me.GroupBox1.Controls.Add(Me.txtIdComprobante)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.SteelBlue
        Me.GroupBox1.Location = New System.Drawing.Point(39, 77)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(616, 90)
        Me.GroupBox1.TabIndex = 41
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Detalle de Busqueda:"
        '
        'dtpPeriodoMes
        '
        Me.dtpPeriodoMes.CustomFormat = "MMMM"
        Me.dtpPeriodoMes.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpPeriodoMes.Location = New System.Drawing.Point(104, 25)
        Me.dtpPeriodoMes.Name = "dtpPeriodoMes"
        Me.dtpPeriodoMes.ShowUpDown = True
        Me.dtpPeriodoMes.Size = New System.Drawing.Size(117, 20)
        Me.dtpPeriodoMes.TabIndex = 47
        Me.dtpPeriodoMes.Visible = False
        '
        'dtpPeriodoAnio
        '
        Me.dtpPeriodoAnio.CustomFormat = "yyyy"
        Me.dtpPeriodoAnio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpPeriodoAnio.Location = New System.Drawing.Point(227, 25)
        Me.dtpPeriodoAnio.Name = "dtpPeriodoAnio"
        Me.dtpPeriodoAnio.ShowUpDown = True
        Me.dtpPeriodoAnio.Size = New System.Drawing.Size(99, 20)
        Me.dtpPeriodoAnio.TabIndex = 46
        Me.dtpPeriodoAnio.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.txtFechaInicio)
        Me.GroupBox3.Controls.Add(Me.txtFechaFin)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.GroupBox3.Location = New System.Drawing.Point(56, 49)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(449, 36)
        Me.GroupBox3.TabIndex = 47
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Fecha:"
        Me.GroupBox3.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(48, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "Desde:"
        '
        'txtFechaInicio
        '
        Me.txtFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaInicio.Location = New System.Drawing.Point(98, 11)
        Me.txtFechaInicio.Name = "txtFechaInicio"
        Me.txtFechaInicio.Size = New System.Drawing.Size(135, 20)
        Me.txtFechaInicio.TabIndex = 44
        '
        'txtFechaFin
        '
        Me.txtFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaFin.Location = New System.Drawing.Point(301, 11)
        Me.txtFechaFin.Name = "txtFechaFin"
        Me.txtFechaFin.Size = New System.Drawing.Size(135, 20)
        Me.txtFechaFin.TabIndex = 46
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(254, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 13)
        Me.Label7.TabIndex = 45
        Me.Label7.Text = "Hasta:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(45, 27)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 13)
        Me.Label8.TabIndex = 45
        Me.Label8.Text = "Periodo:"
        Me.Label8.Visible = False
        '
        'btnBuscar
        '
        Me.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.Location = New System.Drawing.Point(332, 22)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(37, 26)
        Me.btnBuscar.TabIndex = 41
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'txtidProveedor
        '
        Me.txtidProveedor.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.txtidProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtidProveedor.Location = New System.Drawing.Point(104, 25)
        Me.txtidProveedor.Name = "txtidProveedor"
        Me.txtidProveedor.ReadOnly = True
        Me.txtidProveedor.Size = New System.Drawing.Size(32, 20)
        Me.txtidProveedor.TabIndex = 39
        Me.txtidProveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtidProveedor.Visible = False
        '
        'LinkTipoDoc
        '
        Me.LinkTipoDoc.AutoSize = True
        Me.LinkTipoDoc.LinkColor = System.Drawing.SystemColors.HotTrack
        Me.LinkTipoDoc.Location = New System.Drawing.Point(364, 29)
        Me.LinkTipoDoc.Name = "LinkTipoDoc"
        Me.LinkTipoDoc.Size = New System.Drawing.Size(46, 13)
        Me.LinkTipoDoc.TabIndex = 43
        Me.LinkTipoDoc.TabStop = True
        Me.LinkTipoDoc.Text = "Cambiar"
        Me.LinkTipoDoc.Visible = False
        '
        'txtDocumento
        '
        Me.txtDocumento.Location = New System.Drawing.Point(107, 25)
        Me.txtDocumento.Name = "txtDocumento"
        Me.txtDocumento.Size = New System.Drawing.Size(219, 20)
        Me.txtDocumento.TabIndex = 35
        '
        'txtComprobante
        '
        Me.txtComprobante.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.txtComprobante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComprobante.Location = New System.Drawing.Point(137, 25)
        Me.txtComprobante.Name = "txtComprobante"
        Me.txtComprobante.ReadOnly = True
        Me.txtComprobante.Size = New System.Drawing.Size(221, 20)
        Me.txtComprobante.TabIndex = 44
        Me.txtComprobante.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(36, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Documento:"
        '
        'txtProveedor
        '
        Me.txtProveedor.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.txtProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProveedor.Location = New System.Drawing.Point(137, 25)
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.ReadOnly = True
        Me.txtProveedor.Size = New System.Drawing.Size(273, 20)
        Me.txtProveedor.TabIndex = 38
        Me.txtProveedor.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label3.Location = New System.Drawing.Point(67, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "Tipo:"
        Me.Label3.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 30)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 13)
        Me.Label6.TabIndex = 36
        Me.Label6.Text = "Nombre/Razón:"
        Me.Label6.Visible = False
        '
        'LinkProveedor
        '
        Me.LinkProveedor.AutoSize = True
        Me.LinkProveedor.LinkColor = System.Drawing.SystemColors.Highlight
        Me.LinkProveedor.Location = New System.Drawing.Point(416, 28)
        Me.LinkProveedor.Name = "LinkProveedor"
        Me.LinkProveedor.Size = New System.Drawing.Size(46, 13)
        Me.LinkProveedor.TabIndex = 37
        Me.LinkProveedor.TabStop = True
        Me.LinkProveedor.Text = "Cambiar"
        Me.LinkProveedor.Visible = False
        '
        'txtIdComprobante
        '
        Me.txtIdComprobante.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.txtIdComprobante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIdComprobante.Location = New System.Drawing.Point(104, 25)
        Me.txtIdComprobante.Name = "txtIdComprobante"
        Me.txtIdComprobante.ReadOnly = True
        Me.txtIdComprobante.Size = New System.Drawing.Size(32, 20)
        Me.txtIdComprobante.TabIndex = 45
        Me.txtIdComprobante.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtIdComprobante.Visible = False
        '
        'dgvLibroAsiento
        '
        Me.dgvLibroAsiento.AllowUserToAddRows = False
        Me.dgvLibroAsiento.AllowUserToDeleteRows = False
        Me.dgvLibroAsiento.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvLibroAsiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLibroAsiento.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idAsiento, Me.idDocumento, Me.idAlmacen, Me.NombreAlmacen, Me.idEntidad, Me.nombreEntidad, Me.FechaProceso, Me.tipoAsiento, Me.ImporteMN, Me.importeME, Me.glosario})
        Me.dgvLibroAsiento.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgvLibroAsiento.Location = New System.Drawing.Point(0, 227)
        Me.dgvLibroAsiento.Name = "dgvLibroAsiento"
        Me.dgvLibroAsiento.ReadOnly = True
        Me.dgvLibroAsiento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvLibroAsiento.Size = New System.Drawing.Size(661, 198)
        Me.dgvLibroAsiento.TabIndex = 49
        '
        'idAsiento
        '
        Me.idAsiento.HeaderText = "ID"
        Me.idAsiento.Name = "idAsiento"
        Me.idAsiento.ReadOnly = True
        Me.idAsiento.Visible = False
        Me.idAsiento.Width = 5
        '
        'idDocumento
        '
        Me.idDocumento.HeaderText = "ID Documento"
        Me.idDocumento.Name = "idDocumento"
        Me.idDocumento.ReadOnly = True
        Me.idDocumento.Visible = False
        Me.idDocumento.Width = 5
        '
        'idAlmacen
        '
        Me.idAlmacen.HeaderText = "ID Almacen"
        Me.idAlmacen.Name = "idAlmacen"
        Me.idAlmacen.ReadOnly = True
        Me.idAlmacen.Visible = False
        Me.idAlmacen.Width = 5
        '
        'NombreAlmacen
        '
        Me.NombreAlmacen.HeaderText = "Nombre Almacen"
        Me.NombreAlmacen.Name = "NombreAlmacen"
        Me.NombreAlmacen.ReadOnly = True
        Me.NombreAlmacen.Visible = False
        Me.NombreAlmacen.Width = 5
        '
        'idEntidad
        '
        Me.idEntidad.HeaderText = "ID Entidad"
        Me.idEntidad.Name = "idEntidad"
        Me.idEntidad.ReadOnly = True
        Me.idEntidad.Visible = False
        Me.idEntidad.Width = 5
        '
        'nombreEntidad
        '
        Me.nombreEntidad.HeaderText = "Nombre Entidad"
        Me.nombreEntidad.Name = "nombreEntidad"
        Me.nombreEntidad.ReadOnly = True
        Me.nombreEntidad.Width = 150
        '
        'FechaProceso
        '
        Me.FechaProceso.HeaderText = "Fecha Proceso"
        Me.FechaProceso.Name = "FechaProceso"
        Me.FechaProceso.ReadOnly = True
        '
        'tipoAsiento
        '
        Me.tipoAsiento.HeaderText = "Tipo Asiento"
        Me.tipoAsiento.Name = "tipoAsiento"
        Me.tipoAsiento.ReadOnly = True
        '
        'ImporteMN
        '
        Me.ImporteMN.HeaderText = "Importe MN"
        Me.ImporteMN.Name = "ImporteMN"
        Me.ImporteMN.ReadOnly = True
        '
        'importeME
        '
        Me.importeME.HeaderText = "Importe ME"
        Me.importeME.Name = "importeME"
        Me.importeME.ReadOnly = True
        '
        'glosario
        '
        Me.glosario.HeaderText = "Glosario"
        Me.glosario.Name = "glosario"
        Me.glosario.ReadOnly = True
        Me.glosario.Width = 170
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 425)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(661, 20)
        Me.Panel1.TabIndex = 50
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(283, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Lista de Movimientos"
        '
        'dgvMovimiento
        '
        Me.dgvMovimiento.AllowUserToAddRows = False
        Me.dgvMovimiento.AllowUserToDeleteRows = False
        Me.dgvMovimiento.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvMovimiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMovimiento.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AsientoID, Me.colCuenta, Me.colDescripcion, Me.ColDebHAber, Me.colImporteMNDebe, Me.colImporteMEDebe, Me.colHaberMN, Me.colHaberME, Me.colMovimiento})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = Nothing
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvMovimiento.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvMovimiento.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgvMovimiento.Location = New System.Drawing.Point(0, 445)
        Me.dgvMovimiento.Name = "dgvMovimiento"
        Me.dgvMovimiento.ReadOnly = True
        Me.dgvMovimiento.RowHeadersVisible = False
        Me.dgvMovimiento.Size = New System.Drawing.Size(661, 147)
        Me.dgvMovimiento.TabIndex = 51
        '
        'AsientoID
        '
        Me.AsientoID.HeaderText = "ID"
        Me.AsientoID.Name = "AsientoID"
        Me.AsientoID.ReadOnly = True
        Me.AsientoID.Visible = False
        Me.AsientoID.Width = 30
        '
        'colCuenta
        '
        Me.colCuenta.HeaderText = "Cuenta"
        Me.colCuenta.Name = "colCuenta"
        Me.colCuenta.ReadOnly = True
        Me.colCuenta.Width = 50
        '
        'colDescripcion
        '
        Me.colDescripcion.HeaderText = "Descripción"
        Me.colDescripcion.Name = "colDescripcion"
        Me.colDescripcion.ReadOnly = True
        Me.colDescripcion.Width = 180
        '
        'ColDebHAber
        '
        Me.ColDebHAber.HeaderText = "(D/H)"
        Me.ColDebHAber.Name = "ColDebHAber"
        Me.ColDebHAber.ReadOnly = True
        Me.ColDebHAber.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColDebHAber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ColDebHAber.Text = "D"
        Me.ColDebHAber.ToolTipText = "D"
        Me.ColDebHAber.Width = 40
        '
        'colImporteMNDebe
        '
        Me.colImporteMNDebe.HeaderText = "Importemn."
        Me.colImporteMNDebe.Name = "colImporteMNDebe"
        Me.colImporteMNDebe.ReadOnly = True
        '
        'colImporteMEDebe
        '
        Me.colImporteMEDebe.HeaderText = "ImporteME"
        Me.colImporteMEDebe.Name = "colImporteMEDebe"
        Me.colImporteMEDebe.ReadOnly = True
        '
        'colHaberMN
        '
        Me.colHaberMN.HeaderText = "Haber(mn)"
        Me.colHaberMN.Name = "colHaberMN"
        Me.colHaberMN.ReadOnly = True
        '
        'colHaberME
        '
        Me.colHaberME.HeaderText = "Haber(me)"
        Me.colHaberME.Name = "colHaberME"
        Me.colHaberME.ReadOnly = True
        '
        'colMovimiento
        '
        Me.colMovimiento.HeaderText = "IDMOv"
        Me.colMovimiento.Name = "colMovimiento"
        Me.colMovimiento.ReadOnly = True
        '
        'frmLibroDiarioMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(661, 591)
        Me.Controls.Add(Me.dgvMovimiento)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dgvLibroAsiento)
        Me.Controls.Add(Me.ExpandCollapsePanel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.QRibbonCaption1)
        Me.Name = "frmLibroDiarioMaster"
        Me.Text = "Libro Diario"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.QRibbonCaption1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExpandCollapsePanel1.ResumeLayout(False)
        Me.ExpandCollapsePanel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgvLibroAsiento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvMovimiento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents lblEstado As System.Windows.Forms.ToolStripButton
    Friend WithEvents QRibbonCaption1 As Qios.DevSuite.Components.Ribbon.QRibbonCaption
    Friend WithEvents ExpandCollapsePanel1 As MakarovDev.ExpandCollapsePanel.ExpandCollapsePanel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents QComboBox1 As Qios.DevSuite.Components.QComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvLibroAsiento As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgvMovimiento As System.Windows.Forms.DataGridView
    Friend WithEvents AsientoID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCuenta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDebHAber As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents colImporteMNDebe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colImporteMEDebe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHaberMN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHaberME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMovimiento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtDocumento As System.Windows.Forms.TextBox
    Friend WithEvents txtidProveedor As System.Windows.Forms.TextBox
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents LinkProveedor As System.Windows.Forms.LinkLabel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents txtIdComprobante As System.Windows.Forms.TextBox
    Friend WithEvents txtComprobante As System.Windows.Forms.TextBox
    Friend WithEvents LinkTipoDoc As System.Windows.Forms.LinkLabel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents idAsiento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents idDocumento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents idAlmacen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NombreAlmacen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents idEntidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nombreEntidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaProceso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tipoAsiento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ImporteMN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents importeME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents glosario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtpPeriodoAnio As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpPeriodoMes As System.Windows.Forms.DateTimePicker
End Class

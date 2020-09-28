<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMantenimientoComprasPagadas
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
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMantenimientoComprasPagadas))
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cboPeriodo = New System.Windows.Forms.ToolStripComboBox()
        Me.QGlobalColorSchemeManager1 = New Qios.DevSuite.Components.QGlobalColorSchemeManager(Me.components)
        Me.rmiNotaCredito = New Syncfusion.Windows.Forms.Tools.RadialMenuItem()
        Me.rmiNotaDebito = New Syncfusion.Windows.Forms.Tools.RadialMenuItem()
        Me.rmiDetraccion = New Syncfusion.Windows.Forms.Tools.RadialMenuItem()
        Me.rmiRetencion = New Syncfusion.Windows.Forms.Tools.RadialMenuItem()
        Me.rmiPercepcion = New Syncfusion.Windows.Forms.Tools.RadialMenuItem()
        Me.rmiVerGuia = New Syncfusion.Windows.Forms.Tools.RadialMenuItem()
        Me.rmiCompraAlcredito = New Syncfusion.Windows.Forms.Tools.RadialMenuItem()
        Me.rmiCompraAlContado = New Syncfusion.Windows.Forms.Tools.RadialMenuItem()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AsignarNotaDeCréditoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AsignarNotaDeDébitoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AsignarTributoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AsinarRetenciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AsignarPercepciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenGuia = New System.Windows.Forms.ToolStripMenuItem()
        Me.KryptonContextMenuItems1 = New ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewImageColumn3 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewImageColumn4 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewImageColumn5 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewImageColumn6 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.lblhasta = New System.Windows.Forms.Label()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.lbldesde = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rmCompra = New Syncfusion.Windows.Forms.Tools.RadialMenu()
        Me.rmEditarCompra = New Syncfusion.Windows.Forms.Tools.RadialMenuItem()
        Me.rmEliminarDoc = New Syncfusion.Windows.Forms.Tools.RadialMenuItem()
        Me.rmNotas = New Syncfusion.Windows.Forms.Tools.RadialMenuItem()
        Me.rmTributos = New Syncfusion.Windows.Forms.Tools.RadialMenuItem()
        Me.rmRemision = New Syncfusion.Windows.Forms.Tools.RadialMenuItem()
        Me.rmNuevaCompra = New Syncfusion.Windows.Forms.Tools.RadialMenuItem()
        Me.lsvProduccion = New System.Windows.Forms.ListView()
        Me.exNotas = New MakarovDev.ExpandCollapsePanel.ExpandCollapsePanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgvNotaCredito = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTipoMOV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colImporteC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colImporteME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDetalleNC = New System.Windows.Forms.DataGridViewImageColumn()
        Me.colExcel2 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.colDeleteNC = New System.Windows.Forms.DataGridViewImageColumn()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dgvNotaDebito = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewImageColumn2 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.colExcel1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.colDeleteND = New System.Windows.Forms.DataGridViewImageColumn()
        Me.colEditND = New System.Windows.Forms.DataGridViewImageColumn()
        Me.EXGuias = New MakarovDev.ExpandCollapsePanel.ExpandCollapsePanel()
        Me.KryptonDataGridView1 = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.colIdDocGuia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFechaGuia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDocumentoGuia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSerieGuia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNumeroGuia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDetalle = New System.Windows.Forms.DataGridViewImageColumn()
        Me.ExpandCollapsePanel1 = New MakarovDev.ExpandCollapsePanel.ExpandCollapsePanel()
        Me.dgvObligacion = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.colIdDoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTipoTributo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSerie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNumero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMoneda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPorcentaje = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDepmn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDepME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBtnEliminar = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.colBtnEditar = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.lblEstado = New System.Windows.Forms.ToolStripSplitButton()
        Me.PorDiaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DelMesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.NuevoToolStripButton = New System.Windows.Forms.ToolStripDropDownButton()
        Me.CompraPagadaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConpraAlCréditoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CompraAlContadoSinRecepcionDeExistenciaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AbrirToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.GuardarToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip4 = New System.Windows.Forms.ToolStrip()
        Me.lblTitulo = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton()
        Me.lblDescripcion = New System.Windows.Forms.ToolStripLabel()
        Me.lblPerido = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.rmCompra.SuspendLayout()
        Me.exNotas.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvNotaCredito, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvNotaDebito, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EXGuias.SuspendLayout()
        CType(Me.KryptonDataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExpandCollapsePanel1.SuspendLayout()
        CType(Me.dgvObligacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip3.SuspendLayout()
        Me.ToolStrip4.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cboPeriodo})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(182, 29)
        '
        'cboPeriodo
        '
        Me.cboPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPeriodo.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.cboPeriodo.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SETIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.cboPeriodo.Name = "cboPeriodo"
        Me.cboPeriodo.Size = New System.Drawing.Size(121, 21)
        '
        'rmiNotaCredito
        '
        Me.rmiNotaCredito.BackColor = System.Drawing.Color.WhiteSmoke
        Me.rmiNotaCredito.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rmiNotaCredito.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rmiNotaCredito.Location = New System.Drawing.Point(0, 0)
        Me.rmiNotaCredito.Name = "rmiNotaCredito"
        Me.rmiNotaCredito.Size = New System.Drawing.Size(0, 0)
        Me.rmiNotaCredito.TabIndex = 2
        Me.rmiNotaCredito.Text = "Asignar N.crédito"
        Me.ToolTip1.SetToolTip(Me.rmiNotaCredito, "Asignar a documento")
        '
        'rmiNotaDebito
        '
        Me.rmiNotaDebito.BackColor = System.Drawing.Color.WhiteSmoke
        Me.rmiNotaDebito.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rmiNotaDebito.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rmiNotaDebito.Location = New System.Drawing.Point(0, 0)
        Me.rmiNotaDebito.Name = "rmiNotaDebito"
        Me.rmiNotaDebito.Size = New System.Drawing.Size(0, 0)
        Me.rmiNotaDebito.TabIndex = 3
        Me.rmiNotaDebito.Text = "Asignar N.dédito"
        Me.ToolTip1.SetToolTip(Me.rmiNotaDebito, "Asignar a documento")
        '
        'rmiDetraccion
        '
        Me.rmiDetraccion.BackColor = System.Drawing.Color.WhiteSmoke
        Me.rmiDetraccion.Location = New System.Drawing.Point(0, 0)
        Me.rmiDetraccion.Name = "rmiDetraccion"
        Me.rmiDetraccion.Size = New System.Drawing.Size(0, 0)
        Me.rmiDetraccion.TabIndex = 2
        Me.rmiDetraccion.Text = "Detracción"
        '
        'rmiRetencion
        '
        Me.rmiRetencion.Location = New System.Drawing.Point(0, 0)
        Me.rmiRetencion.Name = "rmiRetencion"
        Me.rmiRetencion.Size = New System.Drawing.Size(0, 0)
        Me.rmiRetencion.TabIndex = 3
        Me.rmiRetencion.Text = "Retención"
        '
        'rmiPercepcion
        '
        Me.rmiPercepcion.BackColor = System.Drawing.Color.WhiteSmoke
        Me.rmiPercepcion.Location = New System.Drawing.Point(0, 0)
        Me.rmiPercepcion.Name = "rmiPercepcion"
        Me.rmiPercepcion.Size = New System.Drawing.Size(0, 0)
        Me.rmiPercepcion.TabIndex = 4
        Me.rmiPercepcion.Text = "Percepción"
        '
        'rmiVerGuia
        '
        Me.rmiVerGuia.BackColor = System.Drawing.Color.WhiteSmoke
        Me.rmiVerGuia.Location = New System.Drawing.Point(0, 0)
        Me.rmiVerGuia.Name = "rmiVerGuia"
        Me.rmiVerGuia.Size = New System.Drawing.Size(0, 0)
        Me.rmiVerGuia.TabIndex = 2
        Me.rmiVerGuia.Text = "Ver guía"
        '
        'rmiCompraAlcredito
        '
        Me.rmiCompraAlcredito.BackColor = System.Drawing.Color.WhiteSmoke
        Me.rmiCompraAlcredito.Location = New System.Drawing.Point(0, 0)
        Me.rmiCompraAlcredito.Name = "rmiCompraAlcredito"
        Me.rmiCompraAlcredito.Size = New System.Drawing.Size(0, 0)
        Me.rmiCompraAlcredito.TabIndex = 2
        Me.rmiCompraAlcredito.Text = "Al crédito"
        '
        'rmiCompraAlContado
        '
        Me.rmiCompraAlContado.BackColor = System.Drawing.Color.WhiteSmoke
        Me.rmiCompraAlContado.Location = New System.Drawing.Point(0, 0)
        Me.rmiCompraAlContado.Name = "rmiCompraAlContado"
        Me.rmiCompraAlContado.Size = New System.Drawing.Size(0, 0)
        Me.rmiCompraAlContado.TabIndex = 3
        Me.rmiCompraAlContado.Text = "Al contado"
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AsignarNotaDeCréditoToolStripMenuItem, Me.AsignarNotaDeDébitoToolStripMenuItem, Me.AsignarTributoToolStripMenuItem, Me.AsinarRetenciónToolStripMenuItem, Me.AsignarPercepciónToolStripMenuItem, Me.MenGuia})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(187, 136)
        '
        'AsignarNotaDeCréditoToolStripMenuItem
        '
        Me.AsignarNotaDeCréditoToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.AsignarNotaDeCréditoToolStripMenuItem.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.b_nextpage
        Me.AsignarNotaDeCréditoToolStripMenuItem.Name = "AsignarNotaDeCréditoToolStripMenuItem"
        Me.AsignarNotaDeCréditoToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.AsignarNotaDeCréditoToolStripMenuItem.Text = "Asignar nota de crédito"
        '
        'AsignarNotaDeDébitoToolStripMenuItem
        '
        Me.AsignarNotaDeDébitoToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.AsignarNotaDeDébitoToolStripMenuItem.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.b_nextpage
        Me.AsignarNotaDeDébitoToolStripMenuItem.Name = "AsignarNotaDeDébitoToolStripMenuItem"
        Me.AsignarNotaDeDébitoToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.AsignarNotaDeDébitoToolStripMenuItem.Text = "Asignar nota de débito"
        '
        'AsignarTributoToolStripMenuItem
        '
        Me.AsignarTributoToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.AsignarTributoToolStripMenuItem.Name = "AsignarTributoToolStripMenuItem"
        Me.AsignarTributoToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.AsignarTributoToolStripMenuItem.Text = "Asignar Detracción"
        '
        'AsinarRetenciónToolStripMenuItem
        '
        Me.AsinarRetenciónToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.AsinarRetenciónToolStripMenuItem.Name = "AsinarRetenciónToolStripMenuItem"
        Me.AsinarRetenciónToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.AsinarRetenciónToolStripMenuItem.Text = "Asignar Retención"
        '
        'AsignarPercepciónToolStripMenuItem
        '
        Me.AsignarPercepciónToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.AsignarPercepciónToolStripMenuItem.Name = "AsignarPercepciónToolStripMenuItem"
        Me.AsignarPercepciónToolStripMenuItem.Size = New System.Drawing.Size(186, 22)
        Me.AsignarPercepciónToolStripMenuItem.Text = "Asignar Percepción"
        '
        'MenGuia
        '
        Me.MenGuia.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.MenGuia.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.icon_detalle_compra
        Me.MenGuia.Name = "MenGuia"
        Me.MenGuia.Size = New System.Drawing.Size(186, 22)
        Me.MenGuia.Text = "Ver guías de remisión"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'DataGridViewImageColumn1
        '
        Me.DataGridViewImageColumn1.HeaderText = ""
        Me.DataGridViewImageColumn1.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.b_export
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.ReadOnly = True
        Me.DataGridViewImageColumn1.Width = 30
        '
        'DataGridViewImageColumn3
        '
        Me.DataGridViewImageColumn3.HeaderText = ""
        Me.DataGridViewImageColumn3.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.export_excel1
        Me.DataGridViewImageColumn3.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch
        Me.DataGridViewImageColumn3.Name = "DataGridViewImageColumn3"
        Me.DataGridViewImageColumn3.ReadOnly = True
        Me.DataGridViewImageColumn3.ToolTipText = "Exportar datos"
        Me.DataGridViewImageColumn3.Width = 30
        '
        'DataGridViewImageColumn4
        '
        Me.DataGridViewImageColumn4.HeaderText = ""
        Me.DataGridViewImageColumn4.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.b_drop
        Me.DataGridViewImageColumn4.Name = "DataGridViewImageColumn4"
        Me.DataGridViewImageColumn4.ReadOnly = True
        Me.DataGridViewImageColumn4.ToolTipText = "Eliminar"
        Me.DataGridViewImageColumn4.Width = 30
        '
        'DataGridViewImageColumn5
        '
        Me.DataGridViewImageColumn5.HeaderText = ""
        Me.DataGridViewImageColumn5.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.b_edit
        Me.DataGridViewImageColumn5.Name = "DataGridViewImageColumn5"
        Me.DataGridViewImageColumn5.ReadOnly = True
        Me.DataGridViewImageColumn5.ToolTipText = "Ver detalle"
        Me.DataGridViewImageColumn5.Width = 30
        '
        'DataGridViewImageColumn6
        '
        Me.DataGridViewImageColumn6.HeaderText = ""
        Me.DataGridViewImageColumn6.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.b_edit
        Me.DataGridViewImageColumn6.Name = "DataGridViewImageColumn6"
        Me.DataGridViewImageColumn6.ReadOnly = True
        Me.DataGridViewImageColumn6.Width = 30
        '
        'lblhasta
        '
        Me.lblhasta.AutoSize = True
        Me.lblhasta.BackColor = System.Drawing.Color.Transparent
        Me.lblhasta.Location = New System.Drawing.Point(709, 32)
        Me.lblhasta.Name = "lblhasta"
        Me.lblhasta.Size = New System.Drawing.Size(39, 13)
        Me.lblhasta.TabIndex = 323
        Me.lblhasta.Text = "Hasta:"
        Me.lblhasta.Visible = False
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(400, 28)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(76, 17)
        Me.CheckBox3.TabIndex = 316
        Me.CheckBox3.Text = "Por Rango"
        Me.CheckBox3.UseVisualStyleBackColor = True
        Me.CheckBox3.Visible = False
        '
        'lbldesde
        '
        Me.lbldesde.AutoSize = True
        Me.lbldesde.BackColor = System.Drawing.Color.Transparent
        Me.lbldesde.Location = New System.Drawing.Point(491, 32)
        Me.lbldesde.Name = "lbldesde"
        Me.lbldesde.Size = New System.Drawing.Size(41, 13)
        Me.lbldesde.TabIndex = 322
        Me.lbldesde.Text = "Desde:"
        Me.lbldesde.Visible = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(268, 28)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(60, 17)
        Me.CheckBox1.TabIndex = 314
        Me.CheckBox1.Text = "Por Dia"
        Me.CheckBox1.UseVisualStyleBackColor = True
        Me.CheckBox1.Visible = False
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.CustomFormat = "dd/MM/yyyy hh:mm:ss tt"
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker2.Location = New System.Drawing.Point(754, 28)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(168, 20)
        Me.DateTimePicker2.TabIndex = 321
        Me.DateTimePicker2.Visible = False
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(334, 28)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(64, 17)
        Me.CheckBox2.TabIndex = 315
        Me.CheckBox2.Text = "Por Mes"
        Me.CheckBox2.UseVisualStyleBackColor = True
        Me.CheckBox2.Visible = False
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "dd/MM/yyyy hh:mm:ss tt"
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(538, 28)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(165, 20)
        Me.DateTimePicker1.TabIndex = 320
        Me.DateTimePicker1.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rmCompra)
        Me.Panel1.Controls.Add(Me.lsvProduccion)
        Me.Panel1.Controls.Add(Me.exNotas)
        Me.Panel1.Controls.Add(Me.EXGuias)
        Me.Panel1.Controls.Add(Me.ExpandCollapsePanel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 50)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1113, 388)
        Me.Panel1.TabIndex = 287
        '
        'rmCompra
        '
        Me.rmCompra.CenterCircleRimColor = System.Drawing.Color.LightBlue
        Me.rmCompra.Controls.Add(Me.rmEditarCompra)
        Me.rmCompra.Controls.Add(Me.rmEliminarDoc)
        Me.rmCompra.Controls.Add(Me.rmNotas)
        Me.rmCompra.Controls.Add(Me.rmTributos)
        Me.rmCompra.Controls.Add(Me.rmRemision)
        Me.rmCompra.Controls.Add(Me.rmNuevaCompra)
        Me.rmCompra.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rmCompra.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.rmCompra.HighlightedArcColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rmCompra.Items.Add(Me.rmEditarCompra)
        Me.rmCompra.Items.Add(Me.rmEliminarDoc)
        Me.rmCompra.Items.Add(Me.rmNotas)
        Me.rmCompra.Items.Add(Me.rmTributos)
        Me.rmCompra.Items.Add(Me.rmRemision)
        Me.rmCompra.Items.Add(Me.rmNuevaCompra)
        Me.rmCompra.Location = New System.Drawing.Point(61, 27)
        Me.rmCompra.MaximumSize = New System.Drawing.Size(700, 700)
        Me.rmCompra.MinimumSize = New System.Drawing.Size(150, 150)
        Me.rmCompra.Name = "rmCompra"
        Me.rmCompra.OuterArcColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.rmCompra.OuterRimThickness = 20
        Me.rmCompra.RimBackground = System.Drawing.Color.LightBlue
        Me.rmCompra.Size = New System.Drawing.Size(230, 230)
        Me.rmCompra.TabIndex = 4
        Me.rmCompra.Visible = False
        Me.rmCompra.WedgeCount = 6
        '
        'rmEditarCompra
        '
        Me.rmEditarCompra.BackColor = System.Drawing.Color.GhostWhite
        Me.rmEditarCompra.Location = New System.Drawing.Point(0, 0)
        Me.rmEditarCompra.Name = "rmEditarCompra"
        Me.rmEditarCompra.Size = New System.Drawing.Size(0, 0)
        Me.rmEditarCompra.TabIndex = 2
        Me.rmEditarCompra.Text = "Editar"
        '
        'rmEliminarDoc
        '
        Me.rmEliminarDoc.BackColor = System.Drawing.Color.GhostWhite
        Me.rmEliminarDoc.Location = New System.Drawing.Point(0, 0)
        Me.rmEliminarDoc.Name = "rmEliminarDoc"
        Me.rmEliminarDoc.Size = New System.Drawing.Size(0, 0)
        Me.rmEliminarDoc.TabIndex = 2
        Me.rmEliminarDoc.Text = "Eliminar"
        '
        'rmNotas
        '
        Me.rmNotas.BackColor = System.Drawing.Color.GhostWhite
        Me.rmNotas.Items.Add(Me.rmiNotaCredito)
        Me.rmNotas.Items.Add(Me.rmiNotaDebito)
        Me.rmNotas.Location = New System.Drawing.Point(0, 0)
        Me.rmNotas.Name = "rmNotas"
        Me.rmNotas.Size = New System.Drawing.Size(0, 0)
        Me.rmNotas.TabIndex = 2
        Me.rmNotas.Text = "Notas"
        '
        'rmTributos
        '
        Me.rmTributos.BackColor = System.Drawing.Color.GhostWhite
        Me.rmTributos.Items.Add(Me.rmiDetraccion)
        Me.rmTributos.Items.Add(Me.rmiRetencion)
        Me.rmTributos.Items.Add(Me.rmiPercepcion)
        Me.rmTributos.Location = New System.Drawing.Point(0, 0)
        Me.rmTributos.Name = "rmTributos"
        Me.rmTributos.Size = New System.Drawing.Size(0, 0)
        Me.rmTributos.TabIndex = 2
        Me.rmTributos.Text = "Tributos"
        '
        'rmRemision
        '
        Me.rmRemision.BackColor = System.Drawing.Color.GhostWhite
        Me.rmRemision.Items.Add(Me.rmiVerGuia)
        Me.rmRemision.Location = New System.Drawing.Point(0, 0)
        Me.rmRemision.Name = "rmRemision"
        Me.rmRemision.Size = New System.Drawing.Size(0, 0)
        Me.rmRemision.TabIndex = 2
        Me.rmRemision.Text = "Guías"
        '
        'rmNuevaCompra
        '
        Me.rmNuevaCompra.BackColor = System.Drawing.Color.GhostWhite
        Me.rmNuevaCompra.Items.Add(Me.rmiCompraAlcredito)
        Me.rmNuevaCompra.Items.Add(Me.rmiCompraAlContado)
        Me.rmNuevaCompra.Location = New System.Drawing.Point(0, 0)
        Me.rmNuevaCompra.Name = "rmNuevaCompra"
        Me.rmNuevaCompra.Size = New System.Drawing.Size(0, 0)
        Me.rmNuevaCompra.TabIndex = 2
        Me.rmNuevaCompra.Text = "Compra"
        '
        'lsvProduccion
        '
        Me.lsvProduccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lsvProduccion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvProduccion.FullRowSelect = True
        Me.lsvProduccion.GridLines = True
        Me.lsvProduccion.HideSelection = False
        Me.lsvProduccion.Location = New System.Drawing.Point(0, 0)
        Me.lsvProduccion.MultiSelect = False
        Me.lsvProduccion.Name = "lsvProduccion"
        Me.lsvProduccion.Size = New System.Drawing.Size(1113, 136)
        Me.lsvProduccion.TabIndex = 285
        Me.lsvProduccion.UseCompatibleStateImageBehavior = False
        Me.lsvProduccion.View = System.Windows.Forms.View.Details
        '
        'exNotas
        '
        Me.exNotas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.exNotas.ButtonSize = MakarovDev.ExpandCollapsePanel.ExpandCollapseButton.ExpandButtonSize.Normal
        Me.exNotas.ButtonStyle = MakarovDev.ExpandCollapsePanel.ExpandCollapseButton.ExpandButtonStyle.Circle
        Me.exNotas.Controls.Add(Me.Panel2)
        Me.exNotas.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.exNotas.ExpandedHeight = 168
        Me.exNotas.IsExpanded = False
        Me.exNotas.Location = New System.Drawing.Point(0, 136)
        Me.exNotas.Name = "exNotas"
        Me.exNotas.Size = New System.Drawing.Size(1113, 35)
        Me.exNotas.TabIndex = 290
        Me.exNotas.Text = "NOTAS DE CREDITO Y DEBITO"
        Me.exNotas.UseAnimation = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.Panel2.Controls.Add(Me.TabControl1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.Panel2.Location = New System.Drawing.Point(0, -86)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1111, 119)
        Me.Panel2.TabIndex = 3
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1111, 119)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgvNotaCredito)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1103, 93)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "NOTAS DE CREDITO"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgvNotaCredito
        '
        Me.dgvNotaCredito.AllowUserToAddRows = False
        Me.dgvNotaCredito.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.colTipoMOV, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.colImporteC, Me.colImporteME, Me.colDetalleNC, Me.colExcel2, Me.colDeleteNC})
        Me.dgvNotaCredito.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvNotaCredito.Location = New System.Drawing.Point(3, 3)
        Me.dgvNotaCredito.Name = "dgvNotaCredito"
        Me.dgvNotaCredito.RowHeadersVisible = False
        Me.dgvNotaCredito.Size = New System.Drawing.Size(1097, 87)
        Me.dgvNotaCredito.TabIndex = 4
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 50
        '
        'DataGridViewTextBoxColumn2
        '
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridViewTextBoxColumn2.HeaderText = "Fecha"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 180
        '
        'colTipoMOV
        '
        Me.colTipoMOV.HeaderText = "Movimiento"
        Me.colTipoMOV.Name = "colTipoMOV"
        Me.colTipoMOV.ReadOnly = True
        Me.colTipoMOV.Width = 220
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Serie"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 70
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Número"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 180
        '
        'colImporteC
        '
        Me.colImporteC.HeaderText = "Importe mn."
        Me.colImporteC.Name = "colImporteC"
        Me.colImporteC.ReadOnly = True
        '
        'colImporteME
        '
        Me.colImporteME.HeaderText = "Importe me."
        Me.colImporteME.Name = "colImporteME"
        Me.colImporteME.ReadOnly = True
        '
        'colDetalleNC
        '
        Me.colDetalleNC.HeaderText = ""
        Me.colDetalleNC.Name = "colDetalleNC"
        Me.colDetalleNC.ReadOnly = True
        Me.colDetalleNC.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colDetalleNC.Width = 30
        '
        'colExcel2
        '
        Me.colExcel2.HeaderText = ""
        Me.colExcel2.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.b_export
        Me.colExcel2.Name = "colExcel2"
        Me.colExcel2.ReadOnly = True
        Me.colExcel2.Width = 30
        '
        'colDeleteNC
        '
        Me.colDeleteNC.HeaderText = ""
        Me.colDeleteNC.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.b_drop
        Me.colDeleteNC.Name = "colDeleteNC"
        Me.colDeleteNC.ReadOnly = True
        Me.colDeleteNC.Width = 30
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dgvNotaDebito)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1103, 93)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "NOTAS DE DEBITO"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dgvNotaDebito
        '
        Me.dgvNotaDebito.AllowUserToAddRows = False
        Me.dgvNotaDebito.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewImageColumn2, Me.colExcel1, Me.colDeleteND, Me.colEditND})
        Me.dgvNotaDebito.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvNotaDebito.Location = New System.Drawing.Point(3, 3)
        Me.dgvNotaDebito.Name = "dgvNotaDebito"
        Me.dgvNotaDebito.RowHeadersVisible = False
        Me.dgvNotaDebito.Size = New System.Drawing.Size(1097, 87)
        Me.dgvNotaDebito.TabIndex = 5
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Visible = False
        Me.DataGridViewTextBoxColumn3.Width = 50
        '
        'DataGridViewTextBoxColumn6
        '
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridViewTextBoxColumn6.HeaderText = "Fecha"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 180
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Serie"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 70
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "Número"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 180
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "Importe mn."
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "Importe me."
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        '
        'DataGridViewImageColumn2
        '
        Me.DataGridViewImageColumn2.HeaderText = ""
        Me.DataGridViewImageColumn2.Name = "DataGridViewImageColumn2"
        Me.DataGridViewImageColumn2.ReadOnly = True
        Me.DataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewImageColumn2.Width = 30
        '
        'colExcel1
        '
        Me.colExcel1.HeaderText = ""
        Me.colExcel1.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.b_export
        Me.colExcel1.Name = "colExcel1"
        Me.colExcel1.ReadOnly = True
        Me.colExcel1.Width = 30
        '
        'colDeleteND
        '
        Me.colDeleteND.HeaderText = ""
        Me.colDeleteND.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.b_drop
        Me.colDeleteND.Name = "colDeleteND"
        Me.colDeleteND.ReadOnly = True
        Me.colDeleteND.Width = 30
        '
        'colEditND
        '
        Me.colEditND.HeaderText = ""
        Me.colEditND.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.b_edit
        Me.colEditND.Name = "colEditND"
        Me.colEditND.ReadOnly = True
        Me.colEditND.Width = 30
        '
        'EXGuias
        '
        Me.EXGuias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.EXGuias.ButtonSize = MakarovDev.ExpandCollapsePanel.ExpandCollapseButton.ExpandButtonSize.Normal
        Me.EXGuias.ButtonStyle = MakarovDev.ExpandCollapsePanel.ExpandCollapseButton.ExpandButtonStyle.Circle
        Me.EXGuias.Controls.Add(Me.KryptonDataGridView1)
        Me.EXGuias.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.EXGuias.ExpandedHeight = 168
        Me.EXGuias.IsExpanded = False
        Me.EXGuias.Location = New System.Drawing.Point(0, 171)
        Me.EXGuias.Name = "EXGuias"
        Me.EXGuias.Size = New System.Drawing.Size(1113, 35)
        Me.EXGuias.TabIndex = 289
        Me.EXGuias.Text = "GUIAS DE REMISION"
        Me.EXGuias.UseAnimation = True
        '
        'KryptonDataGridView1
        '
        Me.KryptonDataGridView1.AllowUserToAddRows = False
        Me.KryptonDataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colIdDocGuia, Me.colFechaGuia, Me.colDocumentoGuia, Me.colSerieGuia, Me.colNumeroGuia, Me.colDetalle})
        Me.KryptonDataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.KryptonDataGridView1.Location = New System.Drawing.Point(0, -83)
        Me.KryptonDataGridView1.Name = "KryptonDataGridView1"
        Me.KryptonDataGridView1.RowHeadersVisible = False
        Me.KryptonDataGridView1.Size = New System.Drawing.Size(1111, 116)
        Me.KryptonDataGridView1.TabIndex = 2
        '
        'colIdDocGuia
        '
        Me.colIdDocGuia.HeaderText = "ID"
        Me.colIdDocGuia.Name = "colIdDocGuia"
        Me.colIdDocGuia.ReadOnly = True
        Me.colIdDocGuia.Visible = False
        Me.colIdDocGuia.Width = 50
        '
        'colFechaGuia
        '
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.colFechaGuia.DefaultCellStyle = DataGridViewCellStyle10
        Me.colFechaGuia.HeaderText = "Fecha"
        Me.colFechaGuia.Name = "colFechaGuia"
        Me.colFechaGuia.ReadOnly = True
        Me.colFechaGuia.Width = 180
        '
        'colDocumentoGuia
        '
        Me.colDocumentoGuia.HeaderText = "Comprobante"
        Me.colDocumentoGuia.Name = "colDocumentoGuia"
        Me.colDocumentoGuia.ReadOnly = True
        Me.colDocumentoGuia.Width = 200
        '
        'colSerieGuia
        '
        Me.colSerieGuia.HeaderText = "Serie"
        Me.colSerieGuia.Name = "colSerieGuia"
        Me.colSerieGuia.ReadOnly = True
        Me.colSerieGuia.Width = 70
        '
        'colNumeroGuia
        '
        Me.colNumeroGuia.HeaderText = "Número"
        Me.colNumeroGuia.Name = "colNumeroGuia"
        Me.colNumeroGuia.ReadOnly = True
        Me.colNumeroGuia.Width = 180
        '
        'colDetalle
        '
        Me.colDetalle.HeaderText = ""
        Me.colDetalle.Name = "colDetalle"
        Me.colDetalle.ReadOnly = True
        Me.colDetalle.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colDetalle.ToolTipText = "Ver Detalle"
        Me.colDetalle.Width = 30
        '
        'ExpandCollapsePanel1
        '
        Me.ExpandCollapsePanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.ExpandCollapsePanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ExpandCollapsePanel1.ButtonSize = MakarovDev.ExpandCollapsePanel.ExpandCollapseButton.ExpandButtonSize.Normal
        Me.ExpandCollapsePanel1.ButtonStyle = MakarovDev.ExpandCollapsePanel.ExpandCollapseButton.ExpandButtonStyle.Circle
        Me.ExpandCollapsePanel1.Controls.Add(Me.dgvObligacion)
        Me.ExpandCollapsePanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ExpandCollapsePanel1.ExpandedHeight = 182
        Me.ExpandCollapsePanel1.IsExpanded = True
        Me.ExpandCollapsePanel1.Location = New System.Drawing.Point(0, 206)
        Me.ExpandCollapsePanel1.Name = "ExpandCollapsePanel1"
        Me.ExpandCollapsePanel1.Size = New System.Drawing.Size(1113, 182)
        Me.ExpandCollapsePanel1.TabIndex = 288
        Me.ExpandCollapsePanel1.Text = "OBLIGACIONES TRIBUTARIAS"
        Me.ExpandCollapsePanel1.UseAnimation = True
        '
        'dgvObligacion
        '
        Me.dgvObligacion.AllowUserToAddRows = False
        Me.dgvObligacion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colIdDoc, Me.colTipoTributo, Me.colFecha, Me.colSerie, Me.colNumero, Me.colProveedor, Me.colMoneda, Me.colPorcentaje, Me.colDepmn, Me.colDepME, Me.colBtnEliminar, Me.colBtnEditar})
        Me.dgvObligacion.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvObligacion.Location = New System.Drawing.Point(0, 53)
        Me.dgvObligacion.Name = "dgvObligacion"
        Me.dgvObligacion.RowHeadersVisible = False
        Me.dgvObligacion.Size = New System.Drawing.Size(1111, 127)
        Me.dgvObligacion.TabIndex = 1
        '
        'colIdDoc
        '
        Me.colIdDoc.HeaderText = "ID"
        Me.colIdDoc.Name = "colIdDoc"
        Me.colIdDoc.ReadOnly = True
        Me.colIdDoc.Visible = False
        Me.colIdDoc.Width = 30
        '
        'colTipoTributo
        '
        Me.colTipoTributo.HeaderText = "Tributo"
        Me.colTipoTributo.Name = "colTipoTributo"
        Me.colTipoTributo.ReadOnly = True
        '
        'colFecha
        '
        Me.colFecha.HeaderText = "Fecha registro"
        Me.colFecha.Name = "colFecha"
        Me.colFecha.ReadOnly = True
        '
        'colSerie
        '
        Me.colSerie.HeaderText = "Serie"
        Me.colSerie.Name = "colSerie"
        Me.colSerie.ReadOnly = True
        Me.colSerie.Width = 55
        '
        'colNumero
        '
        Me.colNumero.HeaderText = "Número"
        Me.colNumero.Name = "colNumero"
        Me.colNumero.ReadOnly = True
        Me.colNumero.Width = 180
        '
        'colProveedor
        '
        Me.colProveedor.HeaderText = "Proveedor"
        Me.colProveedor.Name = "colProveedor"
        Me.colProveedor.ReadOnly = True
        Me.colProveedor.Width = 220
        '
        'colMoneda
        '
        Me.colMoneda.HeaderText = "Moneda"
        Me.colMoneda.Name = "colMoneda"
        Me.colMoneda.ReadOnly = True
        Me.colMoneda.Width = 50
        '
        'colPorcentaje
        '
        Me.colPorcentaje.HeaderText = "%"
        Me.colPorcentaje.Name = "colPorcentaje"
        Me.colPorcentaje.ReadOnly = True
        Me.colPorcentaje.Width = 35
        '
        'colDepmn
        '
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = "0"
        Me.colDepmn.DefaultCellStyle = DataGridViewCellStyle6
        Me.colDepmn.HeaderText = "Importe mn."
        Me.colDepmn.Name = "colDepmn"
        Me.colDepmn.ReadOnly = True
        '
        'colDepME
        '
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = "0"
        Me.colDepME.DefaultCellStyle = DataGridViewCellStyle7
        Me.colDepME.HeaderText = "Importe me."
        Me.colDepME.Name = "colDepME"
        Me.colDepME.ReadOnly = True
        '
        'colBtnEliminar
        '
        Me.colBtnEliminar.HeaderText = ""
        Me.colBtnEliminar.Name = "colBtnEliminar"
        Me.colBtnEliminar.ReadOnly = True
        Me.colBtnEliminar.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colBtnEliminar.Text = ""
        Me.colBtnEliminar.ToolTipText = "Eliminar fila"
        Me.colBtnEliminar.Width = 27
        '
        'colBtnEditar
        '
        Me.colBtnEditar.HeaderText = ""
        Me.colBtnEditar.Name = "colBtnEditar"
        Me.colBtnEditar.ReadOnly = True
        Me.colBtnEditar.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colBtnEditar.Text = ""
        Me.colBtnEditar.ToolTipText = "Editar"
        Me.colBtnEditar.Width = 27
        '
        'ToolStrip3
        '
        Me.ToolStrip3.BackColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(199, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ToolStrip3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblEstado, Me.ToolStripSeparator1, Me.NuevoToolStripButton, Me.AbrirToolStripButton, Me.GuardarToolStripButton, Me.toolStripSeparator, Me.ToolStripButton1})
        Me.ToolStrip3.Location = New System.Drawing.Point(0, 25)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip3.Size = New System.Drawing.Size(1113, 25)
        Me.ToolStrip3.TabIndex = 284
        Me.ToolStrip3.Text = "ToolStrip3"
        '
        'lblEstado
        '
        Me.lblEstado.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PorDiaToolStripMenuItem, Me.DelMesToolStripMenuItem})
        Me.lblEstado.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblEstado.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(123, 22)
        Me.lblEstado.Text = "Registro de Compras"
        '
        'PorDiaToolStripMenuItem
        '
        Me.PorDiaToolStripMenuItem.Name = "PorDiaToolStripMenuItem"
        Me.PorDiaToolStripMenuItem.Size = New System.Drawing.Size(111, 22)
        Me.PorDiaToolStripMenuItem.Text = "Del día"
        '
        'DelMesToolStripMenuItem
        '
        Me.DelMesToolStripMenuItem.Name = "DelMesToolStripMenuItem"
        Me.DelMesToolStripMenuItem.Size = New System.Drawing.Size(111, 22)
        Me.DelMesToolStripMenuItem.Text = "Del mes"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'NuevoToolStripButton
        '
        Me.NuevoToolStripButton.AutoToolTip = False
        Me.NuevoToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NuevoToolStripButton.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CompraPagadaToolStripMenuItem, Me.ConpraAlCréditoToolStripMenuItem, Me.CompraAlContadoSinRecepcionDeExistenciaToolStripMenuItem})
        Me.NuevoToolStripButton.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.NuevoToolStripButton.ForeColor = System.Drawing.Color.MidnightBlue
        Me.NuevoToolStripButton.Image = CType(resources.GetObject("NuevoToolStripButton.Image"), System.Drawing.Image)
        Me.NuevoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NuevoToolStripButton.Name = "NuevoToolStripButton"
        Me.NuevoToolStripButton.Size = New System.Drawing.Size(29, 22)
        Me.NuevoToolStripButton.Text = "&Nuevo"
        '
        'CompraPagadaToolStripMenuItem
        '
        Me.CompraPagadaToolStripMenuItem.Name = "CompraPagadaToolStripMenuItem"
        Me.CompraPagadaToolStripMenuItem.Size = New System.Drawing.Size(299, 22)
        Me.CompraPagadaToolStripMenuItem.Text = "Compra al contado con recepción de existencia"
        '
        'ConpraAlCréditoToolStripMenuItem
        '
        Me.ConpraAlCréditoToolStripMenuItem.Name = "ConpraAlCréditoToolStripMenuItem"
        Me.ConpraAlCréditoToolStripMenuItem.Size = New System.Drawing.Size(299, 22)
        Me.ConpraAlCréditoToolStripMenuItem.Text = "Compra al crédito"
        '
        'CompraAlContadoSinRecepcionDeExistenciaToolStripMenuItem
        '
        Me.CompraAlContadoSinRecepcionDeExistenciaToolStripMenuItem.Name = "CompraAlContadoSinRecepcionDeExistenciaToolStripMenuItem"
        Me.CompraAlContadoSinRecepcionDeExistenciaToolStripMenuItem.Size = New System.Drawing.Size(299, 22)
        Me.CompraAlContadoSinRecepcionDeExistenciaToolStripMenuItem.Text = "Compra al contado sin recepción de existencia"
        '
        'AbrirToolStripButton
        '
        Me.AbrirToolStripButton.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.AbrirToolStripButton.ForeColor = System.Drawing.Color.MidnightBlue
        Me.AbrirToolStripButton.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.ResumeRequest
        Me.AbrirToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AbrirToolStripButton.Name = "AbrirToolStripButton"
        Me.AbrirToolStripButton.Size = New System.Drawing.Size(55, 22)
        Me.AbrirToolStripButton.Text = "&Editar"
        Me.AbrirToolStripButton.Visible = False
        '
        'GuardarToolStripButton
        '
        Me.GuardarToolStripButton.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.GuardarToolStripButton.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GuardarToolStripButton.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.icono_eliminar
        Me.GuardarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.GuardarToolStripButton.Name = "GuardarToolStripButton"
        Me.GuardarToolStripButton.Size = New System.Drawing.Size(63, 22)
        Me.GuardarToolStripButton.Text = "Eliminar"
        Me.GuardarToolStripButton.Visible = False
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.ToolStripButton1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.ToolStripButton1.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.document
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(116, 22)
        Me.ToolStripButton1.Text = "Consultar compras"
        Me.ToolStripButton1.Visible = False
        '
        'ToolStrip4
        '
        Me.ToolStrip4.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ToolStrip4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip4.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblTitulo, Me.ToolStripButton7, Me.lblDescripcion, Me.lblPerido, Me.ToolStripButton2})
        Me.ToolStrip4.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip4.Name = "ToolStrip4"
        Me.ToolStrip4.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip4.Size = New System.Drawing.Size(1113, 25)
        Me.ToolStrip4.TabIndex = 283
        Me.ToolStrip4.Text = "ToolStrip4"
        '
        'lblTitulo
        '
        Me.lblTitulo.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblTitulo.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.Information_icon
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(74, 22)
        Me.lblTitulo.Text = "PERIODO:"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton7.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.arrow_circle_135_left
        Me.ToolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton7.Text = "Salir"
        Me.ToolStripButton7.Visible = False
        '
        'lblDescripcion
        '
        Me.lblDescripcion.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblDescripcion.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblDescripcion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDescripcion.Image = CType(resources.GetObject("lblDescripcion.Image"), System.Drawing.Image)
        Me.lblDescripcion.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(134, 22)
        Me.lblDescripcion.Text = "LISTADO DE COMPRAS"
        '
        'lblPerido
        '
        Me.lblPerido.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblPerido.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblPerido.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.iconoBusqueda
        Me.lblPerido.Name = "lblPerido"
        Me.lblPerido.Size = New System.Drawing.Size(70, 22)
        Me.lblPerido.Text = "01/2014"
        Me.lblPerido.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.b_engine1
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(29, 22)
        Me.ToolStripButton2.Text = "ToolStripButton2"
        '
        'frmMantenimientoComprasPagadas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CaptionBarColor = System.Drawing.SystemColors.InactiveBorder
        Me.ClientSize = New System.Drawing.Size(1113, 438)
        Me.Controls.Add(Me.lblhasta)
        Me.Controls.Add(Me.CheckBox3)
        Me.Controls.Add(Me.lbldesde)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip3)
        Me.Controls.Add(Me.ToolStrip4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "frmMantenimientoComprasPagadas"
        Me.Text = "Registro de Compras"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.rmCompra.ResumeLayout(False)
        Me.rmCompra.PerformLayout()
        Me.exNotas.ResumeLayout(False)
        Me.exNotas.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgvNotaCredito, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgvNotaDebito, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EXGuias.ResumeLayout(False)
        Me.EXGuias.PerformLayout()
        CType(Me.KryptonDataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExpandCollapsePanel1.ResumeLayout(False)
        Me.ExpandCollapsePanel1.PerformLayout()
        CType(Me.dgvObligacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.ToolStrip4.ResumeLayout(False)
        Me.ToolStrip4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AbrirToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents GuardarToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStrip4 As System.Windows.Forms.ToolStrip
    Friend WithEvents lblTitulo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblPerido As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cboPeriodo As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents lsvProduccion As System.Windows.Forms.ListView
    Friend WithEvents QGlobalColorSchemeManager1 As Qios.DevSuite.Components.QGlobalColorSchemeManager
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ExpandCollapsePanel1 As MakarovDev.ExpandCollapsePanel.ExpandCollapsePanel
    Friend WithEvents dgvObligacion As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents EXGuias As MakarovDev.ExpandCollapsePanel.ExpandCollapsePanel
    Friend WithEvents KryptonDataGridView1 As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AsignarTributoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents colIdDoc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTipoTributo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSerie As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNumero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colProveedor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMoneda As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPorcentaje As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDepmn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDepME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBtnEliminar As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents colBtnEditar As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents KryptonContextMenuItems1 As ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems
    Friend WithEvents AsinarRetenciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AsignarPercepciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents colIdDocGuia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFechaGuia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDocumentoGuia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSerieGuia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNumeroGuia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDetalle As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents MenGuia As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents lblDescripcion As System.Windows.Forms.ToolStripLabel
    Friend WithEvents NuevoToolStripButton As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents CompraPagadaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConpraAlCréditoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents exNotas As MakarovDev.ExpandCollapsePanel.ExpandCollapsePanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents dgvNotaCredito As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dgvNotaDebito As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents DataGridViewImageColumn3 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents DataGridViewImageColumn4 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents DataGridViewImageColumn5 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewImageColumn2 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents colExcel1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents colDeleteND As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents colEditND As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTipoMOV As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colImporteC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colImporteME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDetalleNC As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents colExcel2 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents colDeleteNC As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents DataGridViewImageColumn1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents DataGridViewImageColumn6 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents AsignarNotaDeCréditoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AsignarNotaDeDébitoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents rmCompra As Syncfusion.Windows.Forms.Tools.RadialMenu
    Friend WithEvents rmEditarCompra As Syncfusion.Windows.Forms.Tools.RadialMenuItem
    Friend WithEvents rmEliminarDoc As Syncfusion.Windows.Forms.Tools.RadialMenuItem
    Friend WithEvents rmNotas As Syncfusion.Windows.Forms.Tools.RadialMenuItem
    Friend WithEvents rmiNotaCredito As Syncfusion.Windows.Forms.Tools.RadialMenuItem
    Friend WithEvents rmiNotaDebito As Syncfusion.Windows.Forms.Tools.RadialMenuItem
    Friend WithEvents rmTributos As Syncfusion.Windows.Forms.Tools.RadialMenuItem
    Friend WithEvents rmiDetraccion As Syncfusion.Windows.Forms.Tools.RadialMenuItem
    Friend WithEvents rmiRetencion As Syncfusion.Windows.Forms.Tools.RadialMenuItem
    Friend WithEvents rmiPercepcion As Syncfusion.Windows.Forms.Tools.RadialMenuItem
    Friend WithEvents rmRemision As Syncfusion.Windows.Forms.Tools.RadialMenuItem
    Friend WithEvents rmiVerGuia As Syncfusion.Windows.Forms.Tools.RadialMenuItem
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents rmNuevaCompra As Syncfusion.Windows.Forms.Tools.RadialMenuItem
    Friend WithEvents rmiCompraAlcredito As Syncfusion.Windows.Forms.Tools.RadialMenuItem
    Friend WithEvents rmiCompraAlContado As Syncfusion.Windows.Forms.Tools.RadialMenuItem
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents lblhasta As System.Windows.Forms.Label
    Friend WithEvents lbldesde As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents CompraAlContadoSinRecepcionDeExistenciaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblEstado As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents PorDiaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DelMesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class

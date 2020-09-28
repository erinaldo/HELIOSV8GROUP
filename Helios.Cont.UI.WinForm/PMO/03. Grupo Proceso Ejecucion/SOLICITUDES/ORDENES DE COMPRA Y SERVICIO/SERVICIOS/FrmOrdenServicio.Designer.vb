<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOrdenServicio
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmOrdenServicio))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.btnConfiguracion = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.lblEstado = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.GuardarToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.lblPerido = New System.Windows.Forms.ToolStripLabel()
        Me.lblTitulo = New System.Windows.Forms.ToolStripLabel()
        Me.PegarToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblIdDocumento = New System.Windows.Forms.ToolStripLabel()
        Me.cboCuentas = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.dockingManager1 = New Syncfusion.Windows.Forms.Tools.DockingManager(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cboPeriodo = New System.Windows.Forms.ToolStripComboBox()
        Me.QGlobalColorSchemeManager1 = New Qios.DevSuite.Components.QGlobalColorSchemeManager(Me.components)
        Me.ImageListAdv1 = New Syncfusion.Windows.Forms.Tools.ImageListAdv(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.PanelDGV = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.txtOrdenEntregable = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtDescripcion = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.fecha1 = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.dgvCompra = New ComponentFactory.Krypton.Toolkit.KryptonDataGridView()
        Me.Secue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Gravado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDArticulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Art = New System.Windows.Forms.DataGridViewLinkColumn()
        Me.Cant2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.uni2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.btnVer = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCuenta = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.dropDownBtn = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.txtProveedor = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.txtRuc = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.popupControlContainer1 = New Syncfusion.Windows.Forms.PopupControlContainer()
        Me.lsvProveedor = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cancel = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.OK = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.panel15 = New System.Windows.Forms.Panel()
        Me.label35 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.gpVSBehavior = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.TXTComprobante = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.cboMoneda = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.txtFechaComprobante = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.txtFinaciera = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtcto = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.CboMonedaPago = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtVcto = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.CboPago = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtDetracciones = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.txtPenalidades = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtFondoGarantia = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtAdelanto = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtPeriodoValorizacion = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.fechafin = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtImporteContratacion = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboModalidad = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.txtContratacion = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.fechainicio = New Syncfusion.Windows.Forms.Tools.DateTimePickerAdv()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dockingClientPanel1 = New Syncfusion.Windows.Forms.Tools.DockingClientPanel()
        Me.Panel7.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.ToolStrip3.SuspendLayout()
        CType(Me.cboCuentas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dockingManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.PanelDGV.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.fecha1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fecha1.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        Me.popupControlContainer1.SuspendLayout()
        Me.panel15.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.gpVSBehavior, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpVSBehavior.SuspendLayout()
        CType(Me.cboMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaComprobante.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.CboMonedaPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fechafin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fechafin.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboModalidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fechainicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fechainicio.Calendar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.dockingClientPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.btnConfiguracion)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 50)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(945, 20)
        Me.Panel7.TabIndex = 406
        '
        'btnConfiguracion
        '
        Me.btnConfiguracion.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.btnConfiguracion.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.btnConfiguracion.BeforeTouchSize = New System.Drawing.Size(28, 20)
        Me.btnConfiguracion.ForeColor = System.Drawing.Color.White
        Me.btnConfiguracion.IsBackStageButton = False
        Me.btnConfiguracion.Location = New System.Drawing.Point(28, -1)
        Me.btnConfiguracion.Name = "btnConfiguracion"
        Me.btnConfiguracion.Size = New System.Drawing.Size(28, 20)
        Me.btnConfiguracion.TabIndex = 211
        Me.btnConfiguracion.UseVisualStyle = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblEstado})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 25)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(945, 25)
        Me.ToolStrip1.TabIndex = 405
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'lblEstado
        '
        Me.lblEstado.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblEstado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblEstado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(140, 22)
        Me.lblEstado.Text = "Envio de Orden de Servicio"
        '
        'ToolStrip3
        '
        Me.ToolStrip3.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GuardarToolStripButton, Me.lblPerido, Me.lblTitulo, Me.PegarToolStripButton, Me.toolStripSeparator1, Me.lblIdDocumento})
        Me.ToolStrip3.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip3.Size = New System.Drawing.Size(945, 25)
        Me.ToolStrip3.TabIndex = 407
        Me.ToolStrip3.Text = "ToolStrip3"
        '
        'GuardarToolStripButton
        '
        Me.GuardarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.GuardarToolStripButton.Image = CType(resources.GetObject("GuardarToolStripButton.Image"), System.Drawing.Image)
        Me.GuardarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.GuardarToolStripButton.Name = "GuardarToolStripButton"
        Me.GuardarToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.GuardarToolStripButton.Text = "&Grabar"
        '
        'lblPerido
        '
        Me.lblPerido.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblPerido.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblPerido.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblPerido.Name = "lblPerido"
        Me.lblPerido.Size = New System.Drawing.Size(55, 22)
        Me.lblPerido.Text = "01/2014"
        Me.lblPerido.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'lblTitulo
        '
        Me.lblTitulo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblTitulo.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(57, 22)
        Me.lblTitulo.Text = "PERIODO:"
        '
        'PegarToolStripButton
        '
        Me.PegarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PegarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PegarToolStripButton.Name = "PegarToolStripButton"
        Me.PegarToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PegarToolStripButton.Text = "&Cancelar"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'lblIdDocumento
        '
        Me.lblIdDocumento.Name = "lblIdDocumento"
        Me.lblIdDocumento.Size = New System.Drawing.Size(19, 22)
        Me.lblIdDocumento.Text = "00"
        Me.lblIdDocumento.Visible = False
        '
        'cboCuentas
        '
        Me.cboCuentas.BackColor = System.Drawing.Color.White
        Me.cboCuentas.BeforeTouchSize = New System.Drawing.Size(279, 21)
        Me.cboCuentas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCuentas.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCuentas.Location = New System.Drawing.Point(47, 20)
        Me.cboCuentas.Name = "cboCuentas"
        Me.cboCuentas.Size = New System.Drawing.Size(279, 21)
        Me.cboCuentas.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboCuentas.TabIndex = 215
        '
        'dockingManager1
        '
        Me.dockingManager1.ActiveCaptionFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.dockingManager1.AutoHideTabFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        Me.dockingManager1.DockLayoutStream = CType(resources.GetObject("dockingManager1.DockLayoutStream"), System.IO.MemoryStream)
        Me.dockingManager1.DockTabFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World)
        '  Me.dockingManager1.EnableAutoAdjustCaption = True
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
        'Timer2
        '
        Me.Timer2.Enabled = True
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
        'ImageListAdv1
        '
        Me.ImageListAdv1.Images.AddRange(New System.Drawing.Image() {CType(resources.GetObject("ImageListAdv1.Images"), System.Drawing.Image), CType(resources.GetObject("ImageListAdv1.Images1"), System.Drawing.Image), CType(resources.GetObject("ImageListAdv1.Images2"), System.Drawing.Image)})
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(960, 483)
        Me.TabControl1.TabIndex = 409
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.PanelDGV)
        Me.TabPage1.Controls.Add(Me.Panel4)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(952, 457)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Datos Generales"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'PanelDGV
        '
        Me.PanelDGV.Controls.Add(Me.Panel2)
        Me.PanelDGV.Controls.Add(Me.dgvCompra)
        Me.PanelDGV.Controls.Add(Me.ToolStrip2)
        Me.PanelDGV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelDGV.Location = New System.Drawing.Point(326, 3)
        Me.PanelDGV.Name = "PanelDGV"
        Me.PanelDGV.Size = New System.Drawing.Size(623, 451)
        Me.PanelDGV.TabIndex = 401
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.btnAgregar)
        Me.Panel2.Controls.Add(Me.txtOrdenEntregable)
        Me.Panel2.Controls.Add(Me.Label19)
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Controls.Add(Me.txtDescripcion)
        Me.Panel2.Controls.Add(Me.fecha1)
        Me.Panel2.Controls.Add(Me.Label17)
        Me.Panel2.Location = New System.Drawing.Point(42, 59)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(395, 242)
        Me.Panel2.TabIndex = 400
        '
        'btnAgregar
        '
        Me.btnAgregar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(1, Byte), Integer))
        Me.btnAgregar.Location = New System.Drawing.Point(348, 55)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(26, 22)
        Me.btnAgregar.TabIndex = 409
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'txtOrdenEntregable
        '
        Me.txtOrdenEntregable.Location = New System.Drawing.Point(146, 94)
        Me.txtOrdenEntregable.Name = "txtOrdenEntregable"
        Me.txtOrdenEntregable.Size = New System.Drawing.Size(186, 19)
        Me.txtOrdenEntregable.TabIndex = 408
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label19.Location = New System.Drawing.Point(13, 100)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(107, 13)
        Me.Label19.TabIndex = 407
        Me.Label19.Text = "Orden de Entregable"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(13, 60)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(65, 13)
        Me.Label16.TabIndex = 405
        Me.Label16.Text = "Descripcion:"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(146, 57)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(186, 19)
        Me.txtDescripcion.TabIndex = 406
        '
        'fecha1
        '
        Me.fecha1.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.fecha1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.fecha1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.fecha1.Calendar.AllowMultipleSelection = False
        Me.fecha1.Calendar.BorderColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.fecha1.Calendar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.fecha1.Calendar.Culture = New System.Globalization.CultureInfo("es-PE")
        Me.fecha1.Calendar.DayNamesColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.fecha1.Calendar.DayNamesFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.fecha1.Calendar.DaysFont = New System.Drawing.Font("Verdana", 8.0!)
        Me.fecha1.Calendar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fecha1.Calendar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fecha1.Calendar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.fecha1.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None
        Me.fecha1.Calendar.HeaderEndColor = System.Drawing.Color.White
        Me.fecha1.Calendar.HeaderStartColor = System.Drawing.Color.White
        Me.fecha1.Calendar.HighlightColor = System.Drawing.Color.White
        Me.fecha1.Calendar.Iso8601CalenderFormat = False
        Me.fecha1.Calendar.Location = New System.Drawing.Point(0, 0)
        Me.fecha1.Calendar.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.fecha1.Calendar.Name = "monthCalendar"
        Me.fecha1.Calendar.ScrollButtonSize = New System.Drawing.Size(24, 24)
        Me.fecha1.Calendar.SelectedDates = New Date(-1) {}
        Me.fecha1.Calendar.Size = New System.Drawing.Size(177, 174)
        Me.fecha1.Calendar.SizeToFit = True
        Me.fecha1.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.fecha1.Calendar.TabIndex = 0
        Me.fecha1.Calendar.WeekFont = New System.Drawing.Font("Verdana", 8.0!)
        '
        '
        '
        Me.fecha1.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.fecha1.Calendar.NoneButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.fecha1.Calendar.NoneButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.fecha1.Calendar.NoneButton.ForeColor = System.Drawing.Color.White
        Me.fecha1.Calendar.NoneButton.IsBackStageButton = False
        Me.fecha1.Calendar.NoneButton.Location = New System.Drawing.Point(105, 0)
        Me.fecha1.Calendar.NoneButton.Size = New System.Drawing.Size(72, 20)
        Me.fecha1.Calendar.NoneButton.Text = "None"
        Me.fecha1.Calendar.NoneButton.UseVisualStyle = True
        '
        '
        '
        Me.fecha1.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.fecha1.Calendar.TodayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.fecha1.Calendar.TodayButton.BeforeTouchSize = New System.Drawing.Size(75, 23)
        Me.fecha1.Calendar.TodayButton.ForeColor = System.Drawing.Color.White
        Me.fecha1.Calendar.TodayButton.IsBackStageButton = False
        Me.fecha1.Calendar.TodayButton.Location = New System.Drawing.Point(0, 0)
        Me.fecha1.Calendar.TodayButton.Size = New System.Drawing.Size(105, 20)
        Me.fecha1.Calendar.TodayButton.Text = "Today"
        Me.fecha1.Calendar.TodayButton.UseVisualStyle = True
        Me.fecha1.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fecha1.CalendarSize = New System.Drawing.Size(189, 176)
        Me.fecha1.CustomFormat = "dd/MM/yyyy hh:mm:ss tt"
        Me.fecha1.DropDownImage = Nothing
        Me.fecha1.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.fecha1.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.fecha1.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.fecha1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.fecha1.Location = New System.Drawing.Point(146, 25)
        Me.fecha1.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.fecha1.MinValue = New Date(CType(0, Long))
        Me.fecha1.Name = "fecha1"
        Me.fecha1.Size = New System.Drawing.Size(181, 20)
        Me.fecha1.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.fecha1.TabIndex = 404
        Me.fecha1.Value = New Date(2015, 4, 14, 15, 59, 3, 447)
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(13, 32)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(40, 13)
        Me.Label17.TabIndex = 403
        Me.Label17.Text = "Fecha:"
        '
        'dgvCompra
        '
        Me.dgvCompra.AllowUserToAddRows = False
        Me.dgvCompra.AllowUserToResizeColumns = False
        Me.dgvCompra.AllowUserToResizeRows = False
        Me.dgvCompra.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Secue, Me.Gravado, Me.IDArticulo, Me.Art, Me.Cant2, Me.uni2, Me.Estado})
        Me.dgvCompra.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCompra.Location = New System.Drawing.Point(0, 25)
        Me.dgvCompra.Name = "dgvCompra"
        Me.dgvCompra.RowHeadersWidth = 25
        Me.dgvCompra.Size = New System.Drawing.Size(623, 426)
        Me.dgvCompra.TabIndex = 393
        '
        'Secue
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.InactiveBorder
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.DimGray
        Me.Secue.DefaultCellStyle = DataGridViewCellStyle1
        Me.Secue.Frozen = True
        Me.Secue.HeaderText = "Secuencia"
        Me.Secue.Name = "Secue"
        Me.Secue.Visible = False
        Me.Secue.Width = 30
        '
        'Gravado
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.InactiveBorder
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkRed
        Me.Gravado.DefaultCellStyle = DataGridViewCellStyle2
        Me.Gravado.Frozen = True
        Me.Gravado.HeaderText = "P.Grav"
        Me.Gravado.Name = "Gravado"
        Me.Gravado.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Gravado.Width = 25
        '
        'IDArticulo
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.InactiveBorder
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.DimGray
        Me.IDArticulo.DefaultCellStyle = DataGridViewCellStyle3
        Me.IDArticulo.Frozen = True
        Me.IDArticulo.HeaderText = "IDArticulo"
        Me.IDArticulo.Name = "IDArticulo"
        Me.IDArticulo.ReadOnly = True
        Me.IDArticulo.Visible = False
        Me.IDArticulo.Width = 50
        '
        'Art
        '
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.InactiveBorder
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Art.DefaultCellStyle = DataGridViewCellStyle4
        Me.Art.Frozen = True
        Me.Art.HeaderText = "Descripcion"
        Me.Art.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.Art.Name = "Art"
        Me.Art.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Art.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Art.Width = 220
        '
        'Cant2
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Cant2.DefaultCellStyle = DataGridViewCellStyle5
        Me.Cant2.HeaderText = "Entregable"
        Me.Cant2.Name = "Cant2"
        '
        'uni2
        '
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.InactiveBorder
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.DimGray
        Me.uni2.DefaultCellStyle = DataGridViewCellStyle6
        Me.uni2.HeaderText = "Fecha"
        Me.uni2.Name = "uni2"
        Me.uni2.ReadOnly = True
        Me.uni2.Width = 90
        '
        'Estado
        '
        Me.Estado.HeaderText = "Estado"
        Me.Estado.Name = "Estado"
        Me.Estado.Visible = False
        '
        'ToolStrip2
        '
        Me.ToolStrip2.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ToolStrip2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnVer, Me.ToolStripButton1, Me.ToolStripSeparator2, Me.ToolStripButton2})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip2.Size = New System.Drawing.Size(623, 25)
        Me.ToolStrip2.TabIndex = 400
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'btnVer
        '
        Me.btnVer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnVer.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnVer.Image = CType(resources.GetObject("btnVer.Image"), System.Drawing.Image)
        Me.btnVer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnVer.Name = "btnVer"
        Me.btnVer.Size = New System.Drawing.Size(23, 22)
        Me.btnVer.Text = "Cesto de existencias"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.ToolStripButton1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "Eliminar fila"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.ToolStripButton2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "Ver Importes"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.GradientPanel1)
        Me.Panel4.Controls.Add(Me.panel15)
        Me.Panel4.Controls.Add(Me.Panel1)
        Me.Panel4.Controls.Add(Me.gpVSBehavior)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel4.Location = New System.Drawing.Point(3, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(323, 451)
        Me.Panel4.TabIndex = 205
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BackColor = System.Drawing.Color.White
        Me.GradientPanel1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.Label7)
        Me.GradientPanel1.Controls.Add(Me.txtCuenta)
        Me.GradientPanel1.Controls.Add(Me.dropDownBtn)
        Me.GradientPanel1.Controls.Add(Me.txtProveedor)
        Me.GradientPanel1.Controls.Add(Me.txtRuc)
        Me.GradientPanel1.Controls.Add(Me.Label9)
        Me.GradientPanel1.Controls.Add(Me.popupControlContainer1)
        Me.GradientPanel1.Location = New System.Drawing.Point(7, 193)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(314, 246)
        Me.GradientPanel1.TabIndex = 200
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(104, 62)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 13)
        Me.Label7.TabIndex = 208
        Me.Label7.Text = "Cuenta:"
        '
        'txtCuenta
        '
        Me.txtCuenta.Location = New System.Drawing.Point(159, 62)
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.ReadOnly = True
        Me.txtCuenta.Size = New System.Drawing.Size(119, 19)
        Me.txtCuenta.TabIndex = 209
        '
        'dropDownBtn
        '
        Me.dropDownBtn.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
        Me.dropDownBtn.BackColor = System.Drawing.SystemColors.Highlight
        Me.dropDownBtn.BeforeTouchSize = New System.Drawing.Size(26, 19)
        Me.dropDownBtn.ForeColor = System.Drawing.Color.White
        Me.dropDownBtn.Image = CType(resources.GetObject("dropDownBtn.Image"), System.Drawing.Image)
        Me.dropDownBtn.IsBackStageButton = False
        Me.dropDownBtn.Location = New System.Drawing.Point(283, 14)
        Me.dropDownBtn.Name = "dropDownBtn"
        Me.dropDownBtn.Size = New System.Drawing.Size(26, 19)
        Me.dropDownBtn.TabIndex = 207
        Me.dropDownBtn.UseVisualStyle = True
        '
        'txtProveedor
        '
        Me.txtProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProveedor.Location = New System.Drawing.Point(14, 14)
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.Size = New System.Drawing.Size(264, 19)
        Me.txtProveedor.TabIndex = 206
        '
        'txtRuc
        '
        Me.txtRuc.Location = New System.Drawing.Point(159, 39)
        Me.txtRuc.Name = "txtRuc"
        Me.txtRuc.ReadOnly = True
        Me.txtRuc.Size = New System.Drawing.Size(119, 19)
        Me.txtRuc.TabIndex = 204
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(104, 42)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 13)
        Me.Label9.TabIndex = 200
        Me.Label9.Text = "RUC:"
        '
        'popupControlContainer1
        '
        Me.popupControlContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.popupControlContainer1.Controls.Add(Me.lsvProveedor)
        Me.popupControlContainer1.Controls.Add(Me.cancel)
        Me.popupControlContainer1.Controls.Add(Me.OK)
        Me.popupControlContainer1.Location = New System.Drawing.Point(13, 97)
        Me.popupControlContainer1.Name = "popupControlContainer1"
        Me.popupControlContainer1.Size = New System.Drawing.Size(279, 147)
        Me.popupControlContainer1.TabIndex = 201
        Me.popupControlContainer1.Visible = False
        '
        'lsvProveedor
        '
        Me.lsvProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lsvProveedor.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lsvProveedor.Dock = System.Windows.Forms.DockStyle.Top
        Me.lsvProveedor.FullRowSelect = True
        Me.lsvProveedor.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lsvProveedor.Location = New System.Drawing.Point(0, 0)
        Me.lsvProveedor.Name = "lsvProveedor"
        Me.lsvProveedor.Size = New System.Drawing.Size(277, 121)
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
        'panel15
        '
        Me.panel15.BackColor = System.Drawing.Color.Transparent
        Me.panel15.BackgroundImage = CType(resources.GetObject("panel15.BackgroundImage"), System.Drawing.Image)
        Me.panel15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.panel15.Controls.Add(Me.label35)
        Me.panel15.Location = New System.Drawing.Point(3, 3)
        Me.panel15.Name = "panel15"
        Me.panel15.Size = New System.Drawing.Size(314, 24)
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
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Location = New System.Drawing.Point(7, 168)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(314, 254)
        Me.Panel1.TabIndex = 199
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label11.Location = New System.Drawing.Point(10, 3)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(194, 19)
        Me.Label11.TabIndex = 170
        Me.Label11.Text = "Datos de Proveedor"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpVSBehavior
        '
        Me.gpVSBehavior.BackColor = System.Drawing.Color.White
        Me.gpVSBehavior.BorderColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpVSBehavior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.gpVSBehavior.Controls.Add(Me.TXTComprobante)
        Me.gpVSBehavior.Controls.Add(Me.cboMoneda)
        Me.gpVSBehavior.Controls.Add(Me.txtFechaComprobante)
        Me.gpVSBehavior.Controls.Add(Me.Label5)
        Me.gpVSBehavior.Controls.Add(Me.Label2)
        Me.gpVSBehavior.Controls.Add(Me.Label1)
        Me.gpVSBehavior.Location = New System.Drawing.Point(3, 28)
        Me.gpVSBehavior.Name = "gpVSBehavior"
        Me.gpVSBehavior.Size = New System.Drawing.Size(314, 134)
        Me.gpVSBehavior.TabIndex = 198
        '
        'TXTComprobante
        '
        Me.TXTComprobante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTComprobante.DisplayMember = "00"
        Me.TXTComprobante.Location = New System.Drawing.Point(91, 39)
        Me.TXTComprobante.Name = "TXTComprobante"
        Me.TXTComprobante.ReadOnly = True
        Me.TXTComprobante.Size = New System.Drawing.Size(181, 19)
        Me.TXTComprobante.TabIndex = 212
        Me.TXTComprobante.Text = "ORDEN DE SERVICIO"
        Me.TXTComprobante.ValueMember = "00"
        '
        'cboMoneda
        '
        Me.cboMoneda.BackColor = System.Drawing.Color.White
        Me.cboMoneda.BeforeTouchSize = New System.Drawing.Size(181, 21)
        Me.cboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMoneda.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMoneda.Location = New System.Drawing.Point(91, 64)
        Me.cboMoneda.Name = "cboMoneda"
        Me.cboMoneda.Size = New System.Drawing.Size(181, 21)
        Me.cboMoneda.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboMoneda.TabIndex = 210
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
        Me.txtFechaComprobante.Location = New System.Drawing.Point(91, 13)
        Me.txtFechaComprobante.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.txtFechaComprobante.MinValue = New Date(CType(0, Long))
        Me.txtFechaComprobante.Name = "txtFechaComprobante"
        Me.txtFechaComprobante.Size = New System.Drawing.Size(181, 20)
        Me.txtFechaComprobante.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.txtFechaComprobante.TabIndex = 208
        Me.txtFechaComprobante.Value = New Date(2015, 4, 14, 15, 59, 3, 447)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(37, 71)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 207
        Me.Label5.Text = "Moneda:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(9, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 200
        Me.Label2.Text = "Comprobante:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(45, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 199
        Me.Label1.Text = "Fecha:"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.txtFinaciera)
        Me.TabPage2.Controls.Add(Me.Label33)
        Me.TabPage2.Controls.Add(Me.txtcto)
        Me.TabPage2.Controls.Add(Me.Label31)
        Me.TabPage2.Controls.Add(Me.CboMonedaPago)
        Me.TabPage2.Controls.Add(Me.Label29)
        Me.TabPage2.Controls.Add(Me.txtVcto)
        Me.TabPage2.Controls.Add(Me.Label26)
        Me.TabPage2.Controls.Add(Me.CboPago)
        Me.TabPage2.Controls.Add(Me.Label24)
        Me.TabPage2.Controls.Add(Me.Label25)
        Me.TabPage2.Controls.Add(Me.Label18)
        Me.TabPage2.Controls.Add(Me.txtDetracciones)
        Me.TabPage2.Controls.Add(Me.txtPenalidades)
        Me.TabPage2.Controls.Add(Me.Label15)
        Me.TabPage2.Controls.Add(Me.txtFondoGarantia)
        Me.TabPage2.Controls.Add(Me.Label14)
        Me.TabPage2.Controls.Add(Me.txtAdelanto)
        Me.TabPage2.Controls.Add(Me.Label13)
        Me.TabPage2.Controls.Add(Me.txtPeriodoValorizacion)
        Me.TabPage2.Controls.Add(Me.Label12)
        Me.TabPage2.Controls.Add(Me.fechafin)
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.txtImporteContratacion)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.cboModalidad)
        Me.TabPage2.Controls.Add(Me.Label32)
        Me.TabPage2.Controls.Add(Me.txtContratacion)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.fechainicio)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(952, 457)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Pagos y Otros"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'txtFinaciera
        '
        Me.txtFinaciera.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFinaciera.Location = New System.Drawing.Point(163, 359)
        Me.txtFinaciera.Name = "txtFinaciera"
        Me.txtFinaciera.Size = New System.Drawing.Size(264, 19)
        Me.txtFinaciera.TabIndex = 275
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label33.Location = New System.Drawing.Point(14, 367)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(109, 13)
        Me.Label33.TabIndex = 274
        Me.Label33.Text = "Institucion Financiera"
        '
        'txtcto
        '
        Me.txtcto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcto.Location = New System.Drawing.Point(164, 334)
        Me.txtcto.Name = "txtcto"
        Me.txtcto.Size = New System.Drawing.Size(264, 19)
        Me.txtcto.TabIndex = 273
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label31.Location = New System.Drawing.Point(14, 334)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(123, 13)
        Me.Label31.TabIndex = 272
        Me.Label31.Text = "Nro. Cta para Desposito"
        '
        'CboMonedaPago
        '
        Me.CboMonedaPago.BackColor = System.Drawing.Color.White
        Me.CboMonedaPago.BeforeTouchSize = New System.Drawing.Size(181, 21)
        Me.CboMonedaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboMonedaPago.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboMonedaPago.Location = New System.Drawing.Point(166, 394)
        Me.CboMonedaPago.Name = "CboMonedaPago"
        Me.CboMonedaPago.Size = New System.Drawing.Size(181, 21)
        Me.CboMonedaPago.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.CboMonedaPago.TabIndex = 271
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label29.Location = New System.Drawing.Point(16, 394)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(49, 13)
        Me.Label29.TabIndex = 270
        Me.Label29.Text = "Moneda:"
        '
        'txtVcto
        '
        Me.txtVcto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVcto.Location = New System.Drawing.Point(163, 307)
        Me.txtVcto.Name = "txtVcto"
        Me.txtVcto.Size = New System.Drawing.Size(264, 19)
        Me.txtVcto.TabIndex = 269
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label26.Location = New System.Drawing.Point(14, 310)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(32, 13)
        Me.Label26.TabIndex = 268
        Me.Label26.Text = "Vcto:"
        '
        'CboPago
        '
        Me.CboPago.BackColor = System.Drawing.Color.White
        Me.CboPago.BeforeTouchSize = New System.Drawing.Size(181, 21)
        Me.CboPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboPago.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboPago.Location = New System.Drawing.Point(164, 249)
        Me.CboPago.Name = "CboPago"
        Me.CboPago.Size = New System.Drawing.Size(181, 21)
        Me.CboPago.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.CboPago.TabIndex = 266
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label24.Location = New System.Drawing.Point(14, 249)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(99, 13)
        Me.Label24.TabIndex = 265
        Me.Label24.Text = "Condicion de Pago:"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label25.Location = New System.Drawing.Point(8, 218)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(60, 13)
        Me.Label25.TabIndex = 264
        Me.Label25.Text = "DEL PAGO:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label18.Location = New System.Drawing.Point(500, 35)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(116, 13)
        Me.Label18.TabIndex = 263
        Me.Label18.Text = "Plazo de Contratacion:"
        '
        'txtDetracciones
        '
        Me.txtDetracciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDetracciones.Location = New System.Drawing.Point(177, 159)
        Me.txtDetracciones.Name = "txtDetracciones"
        Me.txtDetracciones.Size = New System.Drawing.Size(298, 19)
        Me.txtDetracciones.TabIndex = 262
        '
        'txtPenalidades
        '
        Me.txtPenalidades.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPenalidades.Location = New System.Drawing.Point(176, 125)
        Me.txtPenalidades.Name = "txtPenalidades"
        Me.txtPenalidades.Size = New System.Drawing.Size(298, 19)
        Me.txtPenalidades.TabIndex = 261
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(20, 128)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(68, 13)
        Me.Label15.TabIndex = 260
        Me.Label15.Text = "Penalidades:"
        '
        'txtFondoGarantia
        '
        Me.txtFondoGarantia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFondoGarantia.Location = New System.Drawing.Point(176, 187)
        Me.txtFondoGarantia.Name = "txtFondoGarantia"
        Me.txtFondoGarantia.Size = New System.Drawing.Size(112, 19)
        Me.txtFondoGarantia.TabIndex = 259
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(21, 193)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(85, 13)
        Me.Label14.TabIndex = 258
        Me.Label14.Text = "Fondo Garantia:"
        '
        'txtAdelanto
        '
        Me.txtAdelanto.Location = New System.Drawing.Point(599, 159)
        Me.txtAdelanto.Name = "txtAdelanto"
        Me.txtAdelanto.Size = New System.Drawing.Size(112, 19)
        Me.txtAdelanto.TabIndex = 257
        Me.txtAdelanto.Text = "0.00"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(498, 162)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(54, 13)
        Me.Label13.TabIndex = 256
        Me.Label13.Text = "Adelanto:"
        '
        'txtPeriodoValorizacion
        '
        Me.txtPeriodoValorizacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPeriodoValorizacion.Location = New System.Drawing.Point(177, 95)
        Me.txtPeriodoValorizacion.Name = "txtPeriodoValorizacion"
        Me.txtPeriodoValorizacion.Size = New System.Drawing.Size(298, 19)
        Me.txtPeriodoValorizacion.TabIndex = 255
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(21, 98)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(121, 13)
        Me.Label12.TabIndex = 254
        Me.Label12.Text = "Periodo de Valorizacion:"
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
        Me.fechafin.Calendar.Size = New System.Drawing.Size(177, 174)
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
        Me.fechafin.Calendar.NoneButton.Location = New System.Drawing.Point(105, 0)
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
        Me.fechafin.Calendar.TodayButton.Size = New System.Drawing.Size(105, 20)
        Me.fechafin.Calendar.TodayButton.Text = "Today"
        Me.fechafin.Calendar.TodayButton.UseVisualStyle = True
        Me.fechafin.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fechafin.CalendarSize = New System.Drawing.Size(189, 176)
        Me.fechafin.CustomFormat = "dd/MM/yyyy hh:mm:ss tt"
        Me.fechafin.DropDownImage = Nothing
        Me.fechafin.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.fechafin.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.fechafin.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.fechafin.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.fechafin.Location = New System.Drawing.Point(577, 91)
        Me.fechafin.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.fechafin.MinValue = New Date(CType(0, Long))
        Me.fechafin.Name = "fechafin"
        Me.fechafin.Size = New System.Drawing.Size(181, 20)
        Me.fechafin.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.fechafin.TabIndex = 253
        Me.fechafin.Value = New Date(2015, 4, 14, 15, 59, 3, 447)
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(500, 98)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(39, 13)
        Me.Label10.TabIndex = 252
        Me.Label10.Text = "Hasta:"
        '
        'txtImporteContratacion
        '
        Me.txtImporteContratacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtImporteContratacion.Location = New System.Drawing.Point(177, 66)
        Me.txtImporteContratacion.Name = "txtImporteContratacion"
        Me.txtImporteContratacion.Size = New System.Drawing.Size(112, 19)
        Me.txtImporteContratacion.TabIndex = 251
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(21, 69)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(136, 13)
        Me.Label8.TabIndex = 250
        Me.Label8.Text = "Importe de la Contratacion"
        '
        'cboModalidad
        '
        Me.cboModalidad.BackColor = System.Drawing.Color.White
        Me.cboModalidad.BeforeTouchSize = New System.Drawing.Size(181, 21)
        Me.cboModalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboModalidad.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboModalidad.Location = New System.Drawing.Point(163, 276)
        Me.cboModalidad.Name = "cboModalidad"
        Me.cboModalidad.Size = New System.Drawing.Size(181, 21)
        Me.cboModalidad.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboModalidad.TabIndex = 249
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label32.Location = New System.Drawing.Point(14, 283)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(59, 13)
        Me.Label32.TabIndex = 248
        Me.Label32.Text = "Modalidad:"
        '
        'txtContratacion
        '
        Me.txtContratacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtContratacion.Location = New System.Drawing.Point(177, 32)
        Me.txtContratacion.Name = "txtContratacion"
        Me.txtContratacion.Size = New System.Drawing.Size(298, 19)
        Me.txtContratacion.TabIndex = 215
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(21, 159)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 13)
        Me.Label4.TabIndex = 213
        Me.Label4.Text = "Detracciones:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(21, 35)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(150, 13)
        Me.Label6.TabIndex = 214
        Me.Label6.Text = "OBJETO DE CONTRATACION:"
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
        Me.fechainicio.Calendar.Size = New System.Drawing.Size(177, 174)
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
        Me.fechainicio.Calendar.NoneButton.Location = New System.Drawing.Point(105, 0)
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
        Me.fechainicio.Calendar.TodayButton.Size = New System.Drawing.Size(105, 20)
        Me.fechainicio.Calendar.TodayButton.Text = "Today"
        Me.fechainicio.Calendar.TodayButton.UseVisualStyle = True
        Me.fechainicio.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fechainicio.CalendarSize = New System.Drawing.Size(189, 176)
        Me.fechainicio.CustomFormat = "dd/MM/yyyy hh:mm:ss tt"
        Me.fechainicio.DropDownImage = Nothing
        Me.fechainicio.DropDownNormalColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.fechainicio.DropDownPressedColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.fechainicio.DropDownSelectedColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.fechainicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.fechainicio.Location = New System.Drawing.Point(575, 62)
        Me.fechainicio.MetroColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.fechainicio.MinValue = New Date(CType(0, Long))
        Me.fechainicio.Name = "fechainicio"
        Me.fechainicio.Size = New System.Drawing.Size(181, 20)
        Me.fechainicio.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.fechainicio.TabIndex = 210
        Me.fechainicio.Value = New Date(2015, 4, 14, 15, 59, 3, 447)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(498, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 209
        Me.Label3.Text = "Desde:"
        '
        'dockingClientPanel1
        '
        Me.dockingClientPanel1.BackColor = System.Drawing.Color.Transparent
        Me.dockingClientPanel1.Controls.Add(Me.TabControl1)
        Me.dockingClientPanel1.Location = New System.Drawing.Point(0, 76)
        Me.dockingClientPanel1.Name = "dockingClientPanel1"
        Me.dockingClientPanel1.Size = New System.Drawing.Size(960, 483)
        Me.dockingClientPanel1.TabIndex = 410
        '
        'FrmOrdenServicio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(945, 555)
        Me.Controls.Add(Me.dockingClientPanel1)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.ToolStrip3)
        Me.Name = "FrmOrdenServicio"
        Me.Text = "ORDEN DE SERVICIO"
        Me.Panel7.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        CType(Me.cboCuentas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dockingManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.PanelDGV.ResumeLayout(False)
        Me.PanelDGV.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.fecha1.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fecha1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCompra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        Me.popupControlContainer1.ResumeLayout(False)
        Me.panel15.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.gpVSBehavior, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpVSBehavior.ResumeLayout(False)
        Me.gpVSBehavior.PerformLayout()
        CType(Me.cboMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaComprobante.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaComprobante, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.CboMonedaPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fechafin.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fechafin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboModalidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fechainicio.Calendar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fechainicio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.dockingClientPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout

End Sub
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents btnConfiguracion As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents lblEstado As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents GuardarToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblPerido As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblTitulo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents PegarToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblIdDocumento As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cboCuentas As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Private WithEvents dockingManager1 As Syncfusion.Windows.Forms.Tools.DockingManager
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cboPeriodo As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents QGlobalColorSchemeManager1 As Qios.DevSuite.Components.QGlobalColorSchemeManager
    Friend WithEvents ImageListAdv1 As Syncfusion.Windows.Forms.Tools.ImageListAdv
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents txtContratacion As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents fechainicio As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents cboModalidad As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Public WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents txtDetracciones As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents txtPenalidades As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtFondoGarantia As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtAdelanto As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtPeriodoValorizacion As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents fechafin As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtImporteContratacion As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtFinaciera As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Public WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtcto As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Public WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents CboMonedaPago As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtVcto As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Public WithEvents Label26 As System.Windows.Forms.Label
    Public WithEvents CboPago As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Public WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Private WithEvents dockingClientPanel1 As Syncfusion.Windows.Forms.Tools.DockingClientPanel
    Friend WithEvents PanelDGV As System.Windows.Forms.Panel
    Private WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents txtOrdenEntregable As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents fecha1 As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents dgvCompra As ComponentFactory.Krypton.Toolkit.KryptonDataGridView
    Friend WithEvents Secue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Gravado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDArticulo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Art As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents Cant2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents uni2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Estado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnVer As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Private WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCuenta As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Private WithEvents dropDownBtn As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents txtProveedor As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents txtRuc As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Private WithEvents popupControlContainer1 As Syncfusion.Windows.Forms.PopupControlContainer
    Friend WithEvents lsvProveedor As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Private WithEvents cancel As Syncfusion.Windows.Forms.ButtonAdv
    Private WithEvents OK As Syncfusion.Windows.Forms.ButtonAdv
    Private WithEvents panel15 As System.Windows.Forms.Panel
    Private WithEvents label35 As System.Windows.Forms.Label
    Private WithEvents Panel1 As System.Windows.Forms.Panel
    Private WithEvents Label11 As System.Windows.Forms.Label
    Private WithEvents gpVSBehavior As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents TXTComprobante As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
    Friend WithEvents cboMoneda As Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    Friend WithEvents txtFechaComprobante As Syncfusion.Windows.Forms.Tools.DateTimePickerAdv
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
